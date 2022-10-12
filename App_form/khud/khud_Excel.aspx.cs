using System;
using System.Data;
using System.IO;
using Cthuvien;
using System.Data.Common;
using Spire.Xls;

public partial class f_khud_Excel : fmau
{
    protected void nhap_Click(object sender, EventArgs e)
    {
        se.se_nsd b_se = new se.se_nsd();
        try
        {
            ten.Text = ""; se.P_KQ_XOA("file", "file");
            string b_excel = kytu.C_NVL(chon_file.PostedFile.FileName), b_tm, b_ten, b_loai;
            if (b_excel == "") throw new Exception("Chọn File");
            ten.Text = b_excel; b_excel=b_excel.ToUpper();
            b_tm = Server.MapPath("~/file_nhap");
            if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
            if (b_excel.Contains(".DBF")) b_loai=".dbf";
            else if (b_excel.Contains(".XLSX")) b_loai=".xlsx";
            else if (b_excel.Contains(".XLS")) b_loai=".xls";
            else throw new Exception("Chỉ mở File Excell, Dbf");
            b_ten = b_tm + "\\" + b_se.ma_dvi + "_" + b_se.nsd + b_loai;
            b_ten = b_ten.Replace("/", "_");
            try
            {
                if (File.Exists(b_ten)) File.Delete(b_ten);
                chon_file.PostedFile.SaveAs(b_ten);
            }
            catch { throw new Exception("Lỗi lưu File vào thư mục nháp"); }
            //DataTable b_dt = khac.Fdt_Excel(b_ten);
            DataTable b_dt = ExceltoTable(b_ten);
            try { File.Delete(b_ten); } catch { }
            if (!bang.Fb_TRANG(b_dt)) se.P_KQ_LUU("file", "file", b_dt);
        }
        catch (Exception ex) { form.P_LOI(this, khac.Fs_DICH_TIM(ex.Message, b_se.nuoc)); }
    }
    static DataTable ExceltoTable(string b_ten)
    {
        //return null;
        //Create a new workbook
        Workbook workbook = new Workbook();
       // Load a file and imports its data
        workbook.LoadFromFile(b_ten);
        //Initialize worksheet
        Worksheet sheet = workbook.Worksheets[0];
        // get the data source that the grid is displaying data for
        return sheet.ExportDataTable();
    }
}