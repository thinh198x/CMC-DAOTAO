using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Aspose.Cells;
using Cthuvien;

public partial class f_tl_luong_imp : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/tl/tl_luong_imp" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_luong_imp_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        // nhóm lương
        b_dt = tl_ma.Fdt_MA_NHOMLUONG_LKE();
        se.P_TG_LUU(this.Title, "DT_NL", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_KY", null);
         

    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(akyluong.Value)) form.P_LOI(this, "Vui lòng chọn kỳ lương");
            DataSet b_ds = tl_ch.Fdt_BANGLUONG_IMP_DATA(aphong.Value, double.Parse(akyluong.Value), anhomluong.Value);
            DataTable b_dt = b_ds.Tables[1]; DataTable b_dt_clone = b_ds.Tables[1].Copy();
            DataTable b_dt1 = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            b_dt_clone.TableName = "DATA_CLONE";
            DataTable b_cot = tl_ch.Fdt_BANGLUONG_IMP_COT(anhomluong.Value);
            var cot_luong = "";
            for (int i = 0; i < b_cot.Rows.Count; i++)
            {
                if (i == 0)
                {
                    cot_luong = b_cot.Rows[i]["ma"].ToString();
                }
                else
                {
                    cot_luong = cot_luong + "," + b_cot.Rows[i]["ma"].ToString();
                }
            }
            if (!string.IsNullOrEmpty(cot_luong)) bang.P_SO_CSO(ref b_dt, cot_luong);
             
            string sPathTemplate = "/Templates/importmau/Bang_luong_import.xlsx";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            var istartColumn = 7;
            var istartRow = 7;
            // insert cột
            if (b_cot != null && b_cot.Rows.Count > 0)
            {
                for (int i = 0; i <= b_cot.Rows.Count - 1; i++)
                {
                    cells2.InsertColumns(istartColumn, 1, true);
                    cells2[istartRow - 1, istartColumn].PutValue(b_cot.Rows[i]["ten"].ToString());
                    cells2[istartRow, istartColumn].PutValue(b_cot.Rows[i]["ma"].ToString());
                    istartColumn = istartColumn + 1;
                }
                cells2.DeleteColumns(istartColumn, 1, true);
                istartColumn = 0;
                istartRow = 9;
                DataTable b_data = b_ds.Tables[1];
                if (b_ds != null && b_ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i < b_data.Rows.Count; i++)
                    {
                        cells2.InsertRows(istartRow, 1, true);
                        for (int j = 0; j < b_cot.Rows.Count + 7; j++)
                        {
                            style = new Aspose.Cells.Style();
                            cells2[istartRow - 1, istartColumn].PutValue(b_data.Rows[i][j].ToString());
                            style.Borders[BorderType.TopBorder].Color = System.Drawing.Color.Black;
                            style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.BottomBorder].Color = System.Drawing.Color.Black;
                            style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.LeftBorder].Color = System.Drawing.Color.Black;
                            style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                            style.Borders[BorderType.RightBorder].Color = System.Drawing.Color.Black;
                            style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;

                            if (istartColumn > 3)
                            {
                                style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Right;
                                style.Custom = ("#,##0");
                            }
                            cells2[istartRow - 1, istartColumn].SetStyle(style);
                            istartColumn = istartColumn + 1;
                        }
                        istartRow = istartRow + 1;
                        istartColumn = 0;
                    }
                }
                cells2["D3"].PutValue("Kỳ công: " + b_dt1.Rows[0]["thang"].ToString());
                int b_tungay, b_denngay = 0;
                b_tungay = chuyen.OBJ_I(b_dt1.Rows[0]["tungay"]);
                b_denngay = chuyen.OBJ_I(b_dt1.Rows[0]["denngay"]);
                cells2["D4"].PutValue("Từ ngày " + chuyen.SO_CNG(b_tungay) + " đến ngày " + chuyen.SO_CNG(b_denngay));
                //cells2["D5"].PutValue("Công chuẩn: " + b_dt1.Rows[0]["cong_chuan"].ToString());
                cells2.DeleteRow(istartRow);
                wBook.CalculateFormula();
                wBook.Save(HttpContext.Current.Response, "BangLuongImport.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
            }
            else { form.P_LOI(this, "loi:Không có khoản lương nào cần import:loi"); }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

}
