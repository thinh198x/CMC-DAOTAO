using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Cthuvien;

/// <summary>
/// Summary description for Excelreport
/// </summary>
public class Excelreport
{

    #region DATATABLE TO EXCEL WORKBOOK
    //DataTable to Excel Workbook

    public static void DataTabletoExcelWorkbook(DataTable datatable,string worksheetname)
    {
        // Create a DataSet from an XML file.  Modify this code to use
        // any DataSet such as one returned from a database query.
        //String xmlfile = HttpContext.Current.Server.MapPath("App_temp/spiceorder.xml");
        //System.Data.DataSet dataset = new System.Data.DataSet();
        //dataset.ReadXml(xmlfile);
        //System.Data.DataTable datatable = dataset.Tables["OrderItems"];

        // Create a new workbook and worksheet.
        SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook();
        SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];
        //worksheet.Name = "Spice Order";
        worksheet.Name = worksheetname;

        // Get the top left cell for the DataTable.
        SpreadsheetGear.IRange range = worksheet.Cells["A1"];

        // Copy the DataTable to the worksheet range.
        range.CopyFromDataTable(datatable, SpreadsheetGear.Data.SetDataFlags.None);

        // Auto size all worksheet columns which contain data
        worksheet.UsedRange.Columns.AutoFit();

        // Stream the Excel spreadsheet to the client in a format
        // compatible with Excel 97/2000/XP/2003/2007/2010.
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=report.xls");
        workbook.SaveToStream(context.Response.OutputStream, SpreadsheetGear.FileFormat.Excel8);
        context.Response.End();
    }
    #endregion DATATABLE TO EXCEL WORKBOOK

    #region DATASET TO EXCEL WORKBOOK WITH FORMATS AND FORMULAS

    //DataSet to Excel Workbook with Formats and Formulas
    //public static void DataSet_ExcelWorkbook_FormatsFormulas(DataSet dataset,string b_duongdan, string b_format)
    public static void DataSet_ExcelWorkbook_FormatsFormulas(DataSet b_ds,DataTable b_tenbang, string b_duongdan,string b_ten, string b_format, int row, int col)
    {
        //khai báo giá trị đêm bảng = -1
        int b_tablecount = -1;
        // Create a workbook set to hold the template workbook and the report workbook.
        SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();

        // Open the template workbook which contains formats, borders and formulas.
        String filename = HttpContext.Current.Server.MapPath(b_duongdan);
        SpreadsheetGear.IWorkbook templateWorkbook = workbookSet.Workbooks.Open(filename);

        // Get the template range from a defined name in the template workbook.
        SpreadsheetGear.IRange templateRange = templateWorkbook.Names[b_format].RefersToRange;

        // Get the number of rows and columns in the template range.
        int templateRangeRowCount = templateRange.RowCount;
        int templateRangeColCount = templateRange.ColumnCount;

        // Create a new workbook with one blank worksheet to hold the new Excel Report.
        //SpreadsheetGear.IWorkbook reportWorkbook = workbookSet.Workbooks.Add();
        //SpreadsheetGear.IWorksheet reportWorksheet = reportWorkbook.Worksheets[0];
        // lấy mẫu báo cáo
        SpreadsheetGear.IWorkbook reportWorkbook = SpreadsheetGear.Factory.GetWorkbook(filename);
        SpreadsheetGear.IWorksheet reportWorksheet = reportWorkbook.Worksheets[0];

        reportWorksheet.WindowInfo.DisplayGridlines = false;
        reportWorksheet.Name = b_ds.DataSetName;

        // Start at cell B2
        //int row = 1;
        //int col = 1;

        // Insert each DataTable from the DataSet...
        foreach (System.Data.DataTable datatable in b_ds.Tables)
        {
            b_tablecount = b_tablecount + 1;
            // Get the destination range in the report worksheet.
            //SpreadsheetGear.IRange dstRange = reportWorksheet.Cells[row, col,
            //    row + templateRangeRowCount - 1, col + templateRangeColCount - 1];

            SpreadsheetGear.IRange dstRange = reportWorksheet.Cells[row, col,
                row + datatable.Rows.Count, col + templateRangeColCount - 1];

            // Copy the template range formats and formulas to the report worksheet.
            templateRange.Copy(dstRange, SpreadsheetGear.PasteType.All,
                SpreadsheetGear.PasteOperation.None, false, false);

            if (row == 1)
            {
                // Copy the template range column widths to the report worksheet once.
                templateRange.Copy(dstRange, SpreadsheetGear.PasteType.ColumnWidths,
                    SpreadsheetGear.PasteOperation.None, false, false);
            }

            // Use the TableName for the title of the range - this is a merged
            // cell centered across the top of the destination range.

            //add tên bảng vào hàng đầu tiên của format lặp lại
            //reportWorksheet.Cells[row, col].Formula = datatable.TableName;

            reportWorksheet.Cells[row, col].Formula = b_tenbang.Rows[b_tablecount]["tenbang"].ToString();

            // Add a defined name for the new destination range. This defined
            // name will be adjusted by IRange.CopyFromDataTable, allowing us
            // to skip over the newly inserted range and any summary rows
            // added by the template.
            SpreadsheetGear.IName dstRangeName = reportWorkbook.Names.Add(
                datatable.TableName.Replace(" ", ""), "=" + dstRange.Address);

            // truyền dữ liệu từ datatable vào trong từng format
            // nếu sử dụng SpreadsheetGear.Data.SetDataFlags.InsertCells thì columm names sẽ là hàng đầu tiên của excel
            // để bỏ columm name thì cùng SpreadsheetGear.Data.SetDataFlags.NoColumnNames hoặc SpreadsheetGear.Data.SetDataFlags.NoColumnHeaders

            reportWorksheet.Cells[row + 1, col, row + 3, col].CopyFromDataTable(datatable,
                SpreadsheetGear.Data.SetDataFlags.NoColumnHeaders);
            // không hiểu sao dùng NocolumnHeaders lại bị mất format border => phải gán lại
            SpreadsheetGear.IRange grandTotalCells = reportWorksheet.Cells[row, col,
                row + datatable.Rows.Count +1, col + templateRangeColCount - 1];
            //dọc
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.InsideHorizontal].LineStyle = SpreadsheetGear.LineStyle.Continous;
            //ngang
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.InsideVertical].LineStyle = SpreadsheetGear.LineStyle.Continous;
            //trái
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.EdgeLeft].LineStyle = SpreadsheetGear.LineStyle.Continous;
            //phải
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.EdgeRight].LineStyle = SpreadsheetGear.LineStyle.Continous;
            //trên
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.EdgeTop].LineStyle = SpreadsheetGear.LineStyle.Continous;
            //dưới
            grandTotalCells.Borders[SpreadsheetGear.BordersIndex.EdgeBottom].LineStyle = SpreadsheetGear.LineStyle.Continous;

            // xong phần gán border

            // Update lại số hàng sau khi chèn 1 bảng, để bảng sau bắt đầu chèn từ hàng mới
            SpreadsheetGear.IRange range = dstRangeName.RefersToRange;
            //row = range.Row + range.RowCount + 1;
            row = range.Row + datatable.Rows.Count + 1;
        }
        // Đẩy ra file excel (97/2000/XP/2003/2007/2010)

        reportWorksheet.UsedRange.Columns.AutoFit();
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + b_ten);
        reportWorkbook.SaveToStream(context.Response.OutputStream, SpreadsheetGear.FileFormat.Excel8);
        context.Response.End();
    }


    public static void DataSet_ExcelWorkbook_FormatsFormulas(DataSet b_ds)
    {
        // Create a DataSet from an XML file.
        //String xmlFileName = HttpContext.Current.Server.MapPath("App_temp/nfl.xml");
        //System.Data.DataSet dataset = new System.Data.DataSet();
        //dataset.ReadXml(xmlFileName);

        //String ssFile = HttpContext.Current.Server.MapPath("App_temp/chartdefinedname.xls");
        //SpreadsheetGear.IWorkbook workbook = SpreadsheetGear.Factory.GetWorkbook(ssFile);
        //SpreadsheetGear.IWorksheet worksheet = workbook.Worksheets["Sheet1"];

        // Create a workbook set to hold the template workbook and the report workbook.
        SpreadsheetGear.IWorkbookSet workbookSet = SpreadsheetGear.Factory.GetWorkbookSet();

        // Open the template workbook which contains formats, borders and formulas.
        //String filename = HttpContext.Current.Server.MapPath("App_temp/nfltemplate.xls");
        String filename = HttpContext.Current.Server.MapPath("~/App_rpt/ns/kyniemngaylv.xls");

        SpreadsheetGear.IWorkbook templateWorkbook = workbookSet.Workbooks.Open(filename);
        //SpreadsheetGear.IWorkbook templateWorkbook = SpreadsheetGear.Factory.GetWorkbook(filename);

        // Get the template range from a defined name in the template workbook.
        //SpreadsheetGear.IRange templateRange =
        //    templateWorkbook.Names["NFLDivisionFormat"].RefersToRange;

        SpreadsheetGear.IRange templateRange =
            templateWorkbook.Names["Format"].RefersToRange;

        // Get the number of rows and columns in the template range.
        int templateRangeRowCount = templateRange.RowCount;
        int templateRangeColCount = templateRange.ColumnCount;

        // Create a new workbook with one blank worksheet to hold the new Excel Report.
        //SpreadsheetGear.IWorkbook reportWorkbook = workbookSet.Workbooks.Add();
        //SpreadsheetGear.IWorksheet reportWorksheet = reportWorkbook.Worksheets[0];
        // lấy mẫu báo cáo
        SpreadsheetGear.IWorkbook reportWorkbook = SpreadsheetGear.Factory.GetWorkbook(filename);
        SpreadsheetGear.IWorksheet reportWorksheet = reportWorkbook.Worksheets[0];

        reportWorksheet.WindowInfo.DisplayGridlines = false;
        reportWorksheet.Name = b_ds.DataSetName;

        // Start at cell B2
        //int row = 1;
        //int col = 1;

        int row = 4;
        int col = 0;

        // Insert each DataTable from the DataSet...
        foreach (System.Data.DataTable datatable in b_ds.Tables)
        {
            // Get the destination range in the report worksheet.
            SpreadsheetGear.IRange dstRange = reportWorksheet.Cells[row, col,
                row + templateRangeRowCount - 1, col + templateRangeColCount - 1];

            // Copy the template range formats and formulas to the report worksheet.
            templateRange.Copy(dstRange, SpreadsheetGear.PasteType.All,
                SpreadsheetGear.PasteOperation.None, false, false);

            if (row == 1)
            {
                // Copy the template range column widths to the report worksheet once.
                templateRange.Copy(dstRange, SpreadsheetGear.PasteType.ColumnWidths,
                    SpreadsheetGear.PasteOperation.None, false, false);
            }

            // Use the TableName for the title of the range - this is a merged
            // cell centered across the top of the destination range.

            //add tên bảng vào hàng đầu tiên của format lặp lại
            reportWorksheet.Cells[row, col].Formula = datatable.TableName;

            // Add a defined name for the new destination range. This defined
            // name will be adjusted by IRange.CopyFromDataTable, allowing us
            // to skip over the newly inserted range and any summary rows
            // added by the template.
            SpreadsheetGear.IName dstRangeName = reportWorkbook.Names.Add(
                datatable.TableName.Replace(" ", ""), "=" + dstRange.Address);

            // truyền dữ liệu từ datatable vào trong từng format
            // nếu sử dụng SpreadsheetGear.Data.SetDataFlags.InsertCells thì columm names sẽ là hàng đầu tiên của excel
            // để bỏ columm name thì cùng SpreadsheetGear.Data.SetDataFlags.NoColumnNames hoặc SpreadsheetGear.Data.SetDataFlags.NoColumnHeaders

            reportWorksheet.Cells[row + 1, col, row + 3, col].CopyFromDataTable(datatable,
                SpreadsheetGear.Data.SetDataFlags.InsertCells);

            // Update lại số hàng sau khi chèn 1 bảng, để bảng sau bắt đầu chèn từ hàng mới
            SpreadsheetGear.IRange range = dstRangeName.RefersToRange;
            //row = range.Row + range.RowCount + 1;
            row = range.Row + range.RowCount;
        }
        // Đẩy ra file excel (97/2000/XP/2003/2007/2010)

        reportWorksheet.UsedRange.Columns.AutoFit();
        HttpContext context = HttpContext.Current;
        context.Response.Clear();
        context.Response.ContentType = "application/vnd.ms-excel";
        context.Response.AddHeader("Content-Disposition", "attachment; filename=report.xls");
        reportWorkbook.SaveToStream(context.Response.OutputStream, SpreadsheetGear.FileFormat.Excel8);
        context.Response.End();
    }
    #endregion DATASET TO EXCEL WORKBOOK WITH FORMATS AND FORMULAS
}