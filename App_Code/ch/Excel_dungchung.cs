using Aspose.Cells;
using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
/// <summary>
/// Summary description for ImportKiemTra
/// </summary>
public class Excel_dungchung
{

    public static bool ExportTemplate(string sReportFileName, DataTable dsData, DataTable dtVariable, string filename)
    {
        WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");

            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            string filePath = strRoot + sReportFileName.Replace("/", "\\");
            if (!File.Exists(filePath))
            {
                return false;
            }
            designer = new WorkbookDesigner();
            designer.Open(filePath);
            designer.SetDataSource(dsData);

            if (dtVariable != null)
            {
                int intCols = dtVariable.Columns.Count;
                for (int i = 0; i <= intCols - 1; i++)
                {
                    designer.SetDataSource(dtVariable.Columns[i].ColumnName.ToString(), dtVariable.Rows[0].ItemArray[i].ToString());
                }
            }
            designer.Process();
            designer.Workbook.CalculateFormula();
            designer.Workbook.Save(HttpContext.Current.Response, filename + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }

    public static bool ExportExcelTemplate(string fileName)
    {
        WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            var _with1 = designer.Workbook;
            _with1.Save(HttpContext.Current.Response, fileName + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());
            _with1.CalculateFormula();
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public static bool ExportTemplate(string sReportFileName, DataSet dsData, DataTable dtVariable, string filename)
    {
        WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            designer = new WorkbookDesigner();
            designer.Open(filePath);
            designer.SetDataSource(dsData);
            if (dtVariable != null)
            {
                int intCols = dtVariable.Columns.Count;
                for (int i = 0; i <= intCols - 1; i++)
                {
                    designer.SetDataSource(dtVariable.Columns[i].ColumnName.ToString(), dtVariable.Rows[0].ItemArray[i].ToString());
                }
            }
            designer.Process();
            designer.Workbook.CalculateFormula();
            designer.Workbook.Save(HttpContext.Current.Response, filename + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }


    public static bool ExportTemplate(string sReportFileName, string filename, DataSet dsData, string[] b_thutu)
    {
        WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");

            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);

            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            designer = new WorkbookDesigner();
            designer.Open(filePath);

            for (int i = 0; i < b_thutu.Length; i++)
            {
                string[] b_sIndex = b_thutu[i].Split(',');
                DataSet b_dsDynamic = new DataSet();
                for (int j = 0; j < b_sIndex.Length; j++)
                {
                    int b_index = int.Parse(b_sIndex[j].Trim());
                    b_dsDynamic.Tables.Add(dsData.Tables[b_index].Copy());
                }
                designer.SetDataSource(b_dsDynamic);
                designer.Process();
                designer.Workbook.CalculateFormula();
            }
            designer.Workbook.Save(HttpContext.Current.Response, filename + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }


    public static bool ExportTemplate(string sReportFileName, string filename)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);

            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Open(filePath);
            designer.Workbook.Save(HttpContext.Current.Response, filename + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }


    public static bool ExportTemplate_Diem(string sReportFileName, DataTable dtData, DataTable dtVariable, string filename, string[] monThi)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);

            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Open(filePath);
            Worksheet sheet1 = designer.Workbook.Worksheets[0];
            int soMon = monThi.Length;
            sheet1.Cells.InsertColumns(2, soMon * 2);
            for (int i = 0; i < soMon; i++)
            {
                sheet1.Cells[3, i * 2 + 2].SetStyle(sheet1.Cells[3, 0].GetStyle());
                sheet1.Cells[3, i * 2 + 2].Value = "Ngày thi " + (i + 1);
                sheet1.Cells[4, i * 2 + 2].Value = "ngay_thi_" + i;

                sheet1.Cells[3, i * 2 + 3].SetStyle(sheet1.Cells[3, 0].GetStyle());
                sheet1.Cells[3, i * 2 + 3].Value = monThi[i];
                sheet1.Cells[4, i * 2 + 3].Value = "diem_" + i;
            }
            sheet1.Cells.Merge(1, 0, 1, 5 + soMon * 2);

            designer.SetDataSource(dtData);
            if (dtVariable != null)
            {
                int intCols = dtVariable.Columns.Count;
                for (int i = 0; i <= intCols - 1; i++)
                {
                    designer.SetDataSource(dtVariable.Columns[i].ColumnName.ToString(), dtVariable.Rows[0].ItemArray[i].ToString());
                }
            }
            designer.Process();
            designer.Workbook.CalculateFormula();

            designer.Workbook.Save(HttpContext.Current.Response, filename + ".xls", ContentDisposition.Attachment, new XlsSaveOptions());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }


    public static void export2Excel(string filePath, string saveFile, DataSet ds, DataTable dtVariable = null)
    {
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");

            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Lib\\Aspose.Cells.lic";
            l.SetLicense(strLicense);

            string path = strRoot + filePath;

            WorkbookDesigner designer = new WorkbookDesigner();
            designer.Open(path);

            designer.SetDataSource(ds);

            if (dtVariable != null)
            {
                int intRows = dtVariable.Rows.Count;
                if (intRows > 1)
                {
                    for (int i = 0; i < intRows; i++)
                    {
                        foreach (DataColumn dc in dtVariable.Columns)
                        {
                            designer.SetDataSource(string.Format("{0}{1}", dc.ColumnName, i + 1), dtVariable.Rows[i][dc.ColumnName]);
                        }
                    }
                }
                else if (intRows == 1)
                {
                    foreach (DataColumn dc in dtVariable.Columns)
                    {
                        designer.SetDataSource(dc.ColumnName, dtVariable.Rows[0][dc.ColumnName]);
                    }
                }
            }
            designer.Process();
            MemoryStream Stream = new MemoryStream();
            FileFormatType Format = new Aspose.Cells.FileFormatType();

            Format = Aspose.Cells.FileFormatType.Excel97To2003;
            saveFile += ".xls";

            designer.Workbook.Save(saveFile, SaveType.OpenInBrowser, Format, HttpContext.Current.Response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public static bool ExportExcel(string sReportFileName, DataSet dsData, DataTable dtVariable, string filename)
    {
        WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");

            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);

            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            designer = new WorkbookDesigner();
            designer.Open(filePath);
            designer.SetDataSource(dsData);

            if (dtVariable != null)
            {
                int intCols = dtVariable.Columns.Count;
                for (int i = 0; i <= intCols - 1; i++)
                {
                    designer.SetDataSource(dtVariable.Columns[i].ColumnName.ToString(), dtVariable.Rows[0].ItemArray[i].ToString());
                }
            }
            designer.Process();
            designer.Workbook.CalculateFormula();
            string ext = sReportFileName.Substring(sReportFileName.LastIndexOf(".") + 1).ToLower();
            XlsSaveOptions save = new XlsSaveOptions(SaveFormat.Xlsx);
            switch (ext)
            {
                case "xls":
                    save = new XlsSaveOptions(SaveFormat.Excel97To2003);
                    break;

                case "xlsx":
                    save = new XlsSaveOptions(SaveFormat.Xlsx);
                    break;

            }
            designer.Workbook.Save(HttpContext.Current.Response, filename + "." + ext, ContentDisposition.Attachment, save);

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }
}
