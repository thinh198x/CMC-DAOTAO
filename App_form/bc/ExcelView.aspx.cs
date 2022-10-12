using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Cthuvien;

public partial class ExcelView : System.Web.UI.Page
{
    /// <summary>
    /// Khởi tạo excel dll
    /// </summary>
    private Excel.ApplicationClass appOP = null;
    /// <summary>
    /// Đường dẫn file
    /// </summary>
    protected static string m_strFileName = "";

    // khởi tạo kết quả trả về
    DataSet b_kq;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (appOP == null)
            {
                appOP = new Excel.ApplicationClass();
            }
            string b_md = kytu.C_NVL(Request.QueryString["md"]).ToUpper();
            DataTable b_dt_ct = (DataTable)HttpContext.Current.Session[b_md + "_SS"];
            // Lay so lieu tu tham so
            try { b_kq = bc.Fds_XEM_BC(b_md, ref b_dt_ct); }
            catch (Exception ex) { throw new Exception(ex.Message); }
            string b_ddan, b_ten_rp;
            // Kiet xuat dac biet
            string b_ma_bc = chuyen.OBJ_S(b_dt_ct.Rows[0]["ma_bc"]);
            b_ddan = chuyen.OBJ_S(b_dt_ct.Rows[0]["ddan"]);
            b_ten_rp = chuyen.OBJ_S(b_dt_ct.Rows[0]["ten_rp"]);
            if (P_XUAT_KH(b_md, b_ma_bc, b_ddan, b_ten_rp)) return;
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }

    protected override void OnUnload(EventArgs e)
    {
        try
        {
            if (appOP != null)
            {
                appOP.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(appOP);
                appOP = null;
            }
        }
        catch (Exception eqq)
        {
            Response.Write(eqq.ToString());
        }
        base.OnUnload(e);
    }

    private bool P_XUAT_KH(string b_md, string b_ma_bc, string b_ddan, string b_ten_rp)
    {
        string b_sout = "~/Outputs/"; DataRow b_dr = b_kq.Tables[0].Rows[0];
        string b_tenrp = chuyen.OBJ_S(b_dr["ten"]);
        ht_bc.P_XUAT_EXCEL(b_ddan, ref b_sout, b_tenrp, b_kq);
        var strFileName = HttpContext.Current.Server.MapPath(b_sout);
        output.Value = b_sout;
        DisplayExcelSheet(strFileName, "sheet1", true, lblErrText);
        return false;
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        string b_out = output.Value;
        Response.Redirect(b_out);
    }

    public bool DisplayExcelSheet(string strFileName, string strSheetName, bool bReadOnly, Label lblErrorText)
    {

        appOP.DisplayAlerts = false;
        Excel.Workbook workbook = null;
        Excel.Worksheet worksheet = null;
        try
        {
            workbook = appOP.Workbooks.Open(strFileName, 2, bReadOnly, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
            worksheet = (Excel.Worksheet)workbook.Sheets[strSheetName];
            this.ExcelPanel.Controls.Add(ExcelSheetRead(worksheet, lblErrText));

            if (!bReadOnly)
            {
                // save sau ghi
                workbook.Save();
                workbook = null;
            }
            else
            {
                // Đóng sau đọc
                workbook.Close(false, false, Type.Missing);
                workbook = null;
            }
        }
        catch (Exception expInterop)
        {
            lblErrText.Text = expInterop.ToString();
            return false;
        }
        finally
        {
            if (workbook != null)
            {
                if (!bReadOnly)
                {
                    workbook.Save();
                    workbook = null;
                }
                else
                {
                    workbook.Close(false, false, Type.Missing);
                    workbook = null;
                }
            }
            appOP.DisplayAlerts = true;
        }
        return true;
    }
    public Control ExcelSheetRead(Excel.Worksheet objExcelSheet, Label lblErrText)
    {

        int nMaxCol = ((Excel.Range)objExcelSheet.UsedRange).EntireColumn.Count;
        int nMaxRow = ((Excel.Range)objExcelSheet.UsedRange).EntireRow.Count;


        Table tblOutput = new Table();

        TableRow TRow = null;
        TableCell TCell = null;

        string strSize = "";
        int nSizeVal = 0;
        bool bMergeCells = false;
        int nMergeCellCount = 0;
        int nWidth = 0;


        if (objExcelSheet == null)
        {
            return (Control)tblOutput;
        }

        tblOutput.CellPadding = 0;
        tblOutput.CellSpacing = 0;
        tblOutput.GridLines = GridLines.Both;
        try
        {

            for (int nRowIndex = 1; nRowIndex <= nMaxRow; nRowIndex++)
            {
                TRow = null;
                TRow = new TableRow();


                for (int nColIndex = 1; nColIndex <= nMaxCol; nColIndex++)
                {

                    TCell = null;
                    TCell = new TableCell();
                    if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Value2 != null)
                    {

                        TCell.Text = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Text.ToString();
                        if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment != null)
                        {
                            TCell.ForeColor = System.Drawing.Color.Blue;
                            TCell.ToolTip = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment.Shape.AlternativeText;
                        }
                        else
                        {
                            TCell.ForeColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Color);
                        }

                        TCell.BorderWidth = 2;
                        TCell.Width = 140; //TCell.Width = 40;

                        //*
                        TCell.Font.Bold = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Bold;
                        TCell.Font.Italic = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Italic;
                        strSize = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Size.ToString();
                        nSizeVal = Convert.ToInt32(strSize);
                        TCell.Font.Size = FontUnit.Point(nSizeVal);
                        TCell.BackColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Interior.Color);

                        if ((bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeCells != false)
                        {
                            if (bMergeCells == false)
                            {
                                TCell.ColumnSpan = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                nMergeCellCount = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                nMergeCellCount--;
                                bMergeCells = true;
                            }
                            else if (nMergeCellCount == 0)
                            {
                                TCell.ColumnSpan = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                nMergeCellCount = (int)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeArea.Columns.Count;
                                nMergeCellCount--;
                            }
                        }
                        else
                        {
                            bMergeCells = false;
                        }

                        TCell.HorizontalAlign = ExcelHAlign2DotNetHAlign(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]));
                        TCell.VerticalAlign = ExcelVAlign2DotNetVAlign(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]));
                        TCell.Height = Unit.Point(Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).RowHeight.ToString()))));
                        nWidth = Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).ColumnWidth.ToString())));
                        TCell.Width = Unit.Point(nWidth * nWidth);
                        //*/

                    }
                    else
                    {
                        if ((bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).MergeCells == false)
                        {
                            bMergeCells = false;
                        }
                        if (bMergeCells == true)
                        {
                            nMergeCellCount--;
                            continue;
                        }
                        TCell.Text = "&nbsp;";
                        if (((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment != null)
                        {
                            TCell.ForeColor = System.Drawing.Color.Blue;
                            TCell.ToolTip = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Comment.Shape.AlternativeText;
                        }
                        else
                        {
                            TCell.ForeColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Color);
                        }
                        TCell.Font.Bold = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Bold;
                        TCell.Font.Italic = (bool)((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Italic;
                        strSize = ((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Font.Size.ToString();
                        nSizeVal = Convert.ToInt32(strSize);
                        TCell.Font.Size = FontUnit.Point(nSizeVal);
                        TCell.BackColor = ConvertExcelColor2DotNetColor(((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).Interior.Color);

                        TCell.Height = Unit.Point(Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).RowHeight.ToString()))));
                        nWidth = Decimal.ToInt32(Decimal.Parse((((Excel.Range)objExcelSheet.Cells[nRowIndex, nColIndex]).ColumnWidth.ToString())));
                        TCell.Width = Unit.Point(nWidth * nWidth);
                    }

                    TCell.BorderStyle = BorderStyle.Solid;
                    TCell.BorderWidth = Unit.Point(1);
                    TCell.BorderColor = System.Drawing.Color.Gray;
                    TRow.Cells.Add(TCell);

                }

                tblOutput.Rows.Add(TRow);

            }
        }
        catch (Exception ex)
        {
            lblErrText.Text = ex.Message ;
        }
        return (Control)tblOutput;
    }

    private System.Drawing.Color ConvertExcelColor2DotNetColor(object objExcelColor)
    {

        string strColor = "";
        uint uColor = 0;
        int nRed = 0;
        int nGreen = 0;
        int nBlue = 0;

        strColor = objExcelColor.ToString();
        uColor = checked((uint)Convert.ToUInt32(strColor));
        strColor = String.Format("{0:x2}", uColor);
        strColor = "000000" + strColor;
        strColor = strColor.Substring((strColor.Length - 6), 6);

        uColor = 0;
        uColor = Convert.ToUInt32(strColor.Substring(4, 2), 16);
        nRed = (int)uColor;

        uColor = 0;
        uColor = Convert.ToUInt32(strColor.Substring(2, 2), 16);
        nGreen = (int)uColor;

        uColor = 0;
        uColor = Convert.ToUInt32(strColor.Substring(0, 2), 16);
        nBlue = (int)uColor;

        return System.Drawing.Color.FromArgb(nRed, nGreen, nBlue);
    }
    private HorizontalAlign ExcelHAlign2DotNetHAlign(object objExcelAlign)
    {
        switch (((Excel.Range)objExcelAlign).HorizontalAlignment.ToString())
        {
            case "-4131":
                return HorizontalAlign.Left;
            case "-4108":
                return HorizontalAlign.Center;
            case "-4152":
                return HorizontalAlign.Right;
            default:
                return HorizontalAlign.Left;
        }
    }

    private VerticalAlign ExcelVAlign2DotNetVAlign(object objExcelAlign)
    {
        switch (((Excel.Range)objExcelAlign).VerticalAlignment.ToString())
        {
            case "-4160":
                return VerticalAlign.Top;
            case "-4108":
                return VerticalAlign.Middle;
            case "-4107":
                return VerticalAlign.Bottom;
            default:
                return VerticalAlign.Bottom;
        }

    }

    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }

}