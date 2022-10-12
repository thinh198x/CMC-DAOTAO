using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Xml.Linq;
using Oracle.DataAccess.Client;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Cthuvien;
using System.IO;
using iTextSharp.text.pdf;

public class ht_bc
{
    #region XUẤT BÁO CÁO RA EXCEL
    /// <summary>Xuất báo cáo ra Excel</summary>
    /// <param name="b_ds">truyền vào Dataset</param>
    /// <param name="b_mau">truyền vào đường dẫn chứa mẫu template</param>
    /// <param name="b_out">truyền vào đường dẫn xuất ra templete</param>
    /// <param name="b_ten">truyền vào ten mẫu file</param>
    /// <returns>trả về đường dẫn chứa file xuất</returns>
    public static void P_XUAT_EXCEL(string b_mau, ref string b_out, string b_ten, DataSet b_ds)
    {
        string templateFileName = HttpContext.Current.Server.MapPath(b_mau + b_ten + ".xml");
        b_out = b_out + b_ten + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xls";
        string copyFileName = HttpContext.Current.Server.MapPath(b_out);

        XmlDocument xmlTemplateDoc = new XmlDocument();
        xmlTemplateDoc.Load(templateFileName);

        CExcelMLFiller filler = new CExcelMLFiller(b_ds, xmlTemplateDoc.OuterXml);
        if (!filler.OperationFailed)
        {
            filler.Transform();
            if (filler.OperationFailed)
                foreach (string err in filler.ErrorList) return;
        }
        else
            foreach (string err in filler.ErrorList) return;
        filler.ExcelMLDocument.Save(copyFileName);
    }
    /// <summary>Xuất báo cáo ra PDF</summary>
    /// <param name="b_f">Đối tượng trang gọi</param>
    /// <param name="b_rpd">Đối tượng ReportDocument</param>
    /// <param name="b_out">truyền vào đường dẫn xuất ra templete</param>
    public static void P_XUAT_PDF(Page b_f, ReportDocument b_rpd, string b_out)
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_ten_file = DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + b_se.ma_dvi + "_" + b_se.nsd + ".pdf";
        string b_path = b_out + b_ten_file;
        ExportOptions CrExportOptions;
        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
        CrDiskFileDestinationOptions.DiskFileName = b_f.Server.MapPath(b_path);
        CrExportOptions = b_rpd.ExportOptions;
        {
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
        }
        b_rpd.Export(); b_rpd.Close();

        string b_file_in = b_f.Server.MapPath(b_path);
        string b_file_nen = b_f.Server.MapPath(b_out + "nen_" + b_ten_file);
        P_NEN_PDF(b_file_in, b_file_nen);
        string b_path_out = b_out + "nen_" + b_ten_file;
        File.Delete(b_f.Server.MapPath(b_out + b_ten_file));
        b_f.Response.Redirect(b_path_out, false);
        //b_f.Response.Redirect(b_path, false);
    }
    public static void P_NEN_PDF(string b_file_in, string b_file_out)
    { // Nén file pdf đã có sang dạng pdf nén
        PdfReader reader = new PdfReader(b_file_in);
        PdfStamper stamper = new PdfStamper(reader, new FileStream(b_file_out, FileMode.Create), PdfWriter.VERSION_1_5);
        stamper.FormFlattening = true;
        stamper.SetFullCompression();
        stamper.Close();
    }

    /// <summary> Xuất Report sang MS Word </summary>
    public static void P_XUAT_RP_WORD(Page b_f, ReportDocument b_rpd, string b_out)
    {
        string b_path = b_out + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + (new se.se_nsd()).nsd + ".doc";
        ExportOptions CrExportOptions;
        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
        CrDiskFileDestinationOptions.DiskFileName = b_f.Server.MapPath(b_path);
        CrExportOptions = b_rpd.ExportOptions;
        {
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.WordForWindows;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
        }
        b_rpd.Export(); b_f.Response.Redirect(b_path, false);
    }
    /// <summary> Xuất Report sang MS Excel </summary>
    public static void P_XUAT_RP_EXCEL(Page b_f, ReportDocument b_rpd, string b_out)
    {
        string b_path = b_out + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + (new se.se_nsd()).nsd + ".xls";
        ExportOptions CrExportOptions;
        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        ExcelFormatOptions CrExcelOption = new ExcelFormatOptions();
        CrDiskFileDestinationOptions.DiskFileName = b_f.Server.MapPath(b_path);
        CrExportOptions = b_rpd.ExportOptions;
        {
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.Excel;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrExcelOption;
        }
        b_rpd.Export(); b_f.Response.Redirect(b_path, false);
    }

    /// <summary>Xuất báo cáo ra Excel</summary>
    /// <param name="b_ds">truyền vào Dataset</param>
    /// <param name="b_mau">truyền vào đường dẫn chứa mẫu template</param>
    /// <param name="b_out">truyền vào đường dẫn xuất ra templete</param>
    /// <param name="b_ten">truyền vào ten mẫu file</param>
    /// <returns>trả về đường dẫn chứa file xuất</returns>
    public static void P_XUAT_EXCEL_ROW(string b_mau, ref string b_out, string b_ten, DataSet b_ds)
    {
        string templateFileName = HttpContext.Current.Server.MapPath(b_mau + b_ten + ".xml");
        b_out = b_out + b_ten + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".xls";
        string copyFileName = HttpContext.Current.Server.MapPath(b_out);

        XmlDocument xmlTemplateDoc = new XmlDocument();
        xmlTemplateDoc.Load(templateFileName);

        CExcelMLFiller filler = new CExcelMLFiller(b_ds, xmlTemplateDoc.OuterXml);
        if (!filler.OperationFailed)
        {
            filler.Transform_dong();
            if (filler.OperationFailed)
                foreach (string err in filler.ErrorList) return;
        }
        else
            foreach (string err in filler.ErrorList) return;
        filler.ExcelMLDocument.Save(copyFileName);
    }
    #endregion

    #region XUẤT BÁO CÁO RA WORD
    /// <summary>Xuất báo cáo ra word</summary>        
    /// <param name="b_ddan">truyền vào đường dẫn chứa mẫu template</param>
    /// <param name="b_out">truyền vào đường dẫn xuất ra templete</param>
    /// <param name="b_ten">truyền vào tên mẫu file</param>
    /// <param name="b_ds">truyền vào Dataset</param>
    /// <returns>trả về đường dẫn chứa file xuất</returns>
    public static void P_XUAT_WORD(string b_ddan, ref string b_out, string b_ten, DataSet b_ds)
    {
        string templateFileName = HttpContext.Current.Server.MapPath(b_ddan + b_ten + ".xml");
        b_out = b_out + b_ten + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".doc";
        string copyFileName = HttpContext.Current.Server.MapPath(b_out);

        XmlDocument xmlTemplateDoc = new XmlDocument();
        xmlTemplateDoc.Load(templateFileName);

        CExWordMLFiller filler = new CExWordMLFiller(b_ds, xmlTemplateDoc.OuterXml);
        if (!filler.OperationFailed)
        {
            filler.Transform();
            if (filler.OperationFailed)
                foreach (string err in filler.ErrorList) return;
        }
        else foreach (string err in filler.ErrorList) return;
        filler.WordMLDocument.Save(copyFileName);
    }
    /// <summary>Xuất báo cáo ra word</summary>        
    /// <param name="b_ddan">truyền vào đường dẫn chứa mẫu template</param>
    /// <param name="b_out">truyền vào đường dẫn xuất ra templete</param>
    /// <param name="b_ten">truyền vào tên mẫu file</param>
    /// <param name="b_ds">truyền vào Dataset</param>
    /// <returns>trả về đường dẫn chứa file xuất</returns>
    public static void P_XUAT_WORD_ROW(string b_ddan, ref string b_out, string b_ten, DataSet b_ds)
    {
        string templateFileName = HttpContext.Current.Server.MapPath(b_ddan + b_ten + ".xml");
        b_out = b_out + b_ten + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".doc";
        string copyFileName = HttpContext.Current.Server.MapPath(b_out);

        XmlDocument xmlTemplateDoc = new XmlDocument();
        xmlTemplateDoc.Load(templateFileName);

        CExWordMLFiller filler = new CExWordMLFiller(b_ds, xmlTemplateDoc.OuterXml);
        if (!filler.OperationFailed)
        {
            filler.Transform_row();
            if (filler.OperationFailed)
                foreach (string err in filler.ErrorList) return;
        }
        else foreach (string err in filler.ErrorList) return;
        filler.WordMLDocument.Save(copyFileName);
    }
    /// <summary>Xuất ra mẫu kiểu chứng chỉ</summary>
    /// <param name="b_mau">đường dẫn chứa file mẫu</param>
    /// <param name="b_out">đường dẫn chỉ ra file</param>
    /// <param name="b_ten">truyền vào tên mẫu file</param>
    /// <param name="b_dt">truyền vào tên của mẫu file</param>
    public static void P_XUAT_WORD_MAU(string b_mau, ref string b_out, string b_ten, DataTable b_dt)
    {
        try
        {
            const string b_const_header = "<wx:sect>", b_const_footer = "<w:sectPr>";
            const string b_break = "<w:p><w:r><w:rPr><w:sz w:val=\"28\" /><w:sz-cs w:val=\"28\" /></w:rPr><w:br w:type=\"page\" /></w:r></w:p>";

            b_mau = b_mau + b_ten + ".xml";
            b_out = b_out + b_ten + DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".doc";

            XmlDocument b_xdoc = new XmlDocument();
            b_xdoc.Load(HttpContext.Current.Server.MapPath(b_mau));
            string b_xmau = b_xdoc.OuterXml;
            int b_i = b_xmau.IndexOf(b_const_header) + 9; string b_header = b_xmau.Substring(0, b_i);
            int b_j = b_xmau.IndexOf(b_const_footer); string b_footer = b_xmau.Substring(b_j, b_xmau.Length - b_j);

            string b_str = ""; string b_luu = b_xmau;
            DataTable b_dt_add = new DataTable();
            for (int i = 0; i < b_dt.Columns.Count; i++) b_dt_add.Columns.Add(b_dt.Columns[i].ColumnName.ToLower());
            b_dt_add.AcceptChanges(); b_dt_add.TableName = b_dt.TableName;
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_xmau = b_luu; DataSet b_ds = new DataSet();
                b_dt_add.Clear(); b_dt_add.Rows.Add(b_dt.Rows[i].ItemArray);
                b_ds.Tables.Add(b_dt_add.Copy());
                CExWordMLFiller filler = new CExWordMLFiller(b_ds, b_xmau);
                if (!filler.OperationFailed)
                {
                    filler.Transform();
                    if (filler.OperationFailed)
                        foreach (string err in filler.ErrorList) return;
                }
                else foreach (string err in filler.ErrorList) return;
                string b_ct = filler.WordMLDocument.OuterXml;
                int b_q = b_ct.IndexOf(b_const_footer);
                b_str = b_str + b_ct.Substring(b_i, b_q - b_i) + b_break;
            }
            string b_kq = b_header + b_str + b_footer;
            XDocument b_doc = XDocument.Parse(b_kq);
            b_doc.Save(HttpContext.Current.Server.MapPath(b_out));
        }
        catch (Exception ex)
        { throw new Exception(ex.Message ); }
    }
    /// <summary>Đọc index của word để chỉ ra bookmark của word</summary>
    /// <param name="b_bien"></param>
    /// <param name="b_mau"></param>
    private static void P_DOC_INDEX(ref string b_bien, string b_mau)
    {
        const string b_const_index = "w:type=\"Word.Bookmark.Start\" w:name=\"";
        int b_i = b_mau.IndexOf(b_const_index);
        if (b_i > 0)
        {
            b_i = b_i + b_const_index.Length;
            string b_temp = b_mau.Substring(b_i, b_mau.Length - b_i);
            int b_j = b_temp.IndexOf(" />") - 2;
            string b_table = b_temp.Substring(0, b_j);
            if (b_bien == "") b_bien = b_table;
            else b_bien = b_bien + "," + b_table;
            if (b_temp.Length > 0) P_DOC_INDEX(ref b_bien, b_temp);
        }
    }
    /// <summary>Đọc bookmark của word</summary>
    /// <param name="b_mau">đường dẫn có file mẫu</param>
    /// <returns>trả về mảng tất cả bookmark của mẫu</returns>
    public static string[] P_DOC_BM(string b_mau)
    {
        XmlDocument b_xdoc = new XmlDocument();
        b_xdoc.Load(HttpContext.Current.Server.MapPath(b_mau));
        string b_xmau = b_xdoc.OuterXml;
        string b_bien = "";
        P_DOC_INDEX(ref b_bien, b_xmau);
        if (b_bien == "") return new string[] { };
        else return b_bien.Split(new char[] { ',' });
    }
    #endregion

    #region CHUẨN HÓA THỦ TỤ XUẤT RA CRYSTAL
    #endregion

    #region KHAI BÁO HÀM MỞ BÁO CÁO
    /// <summary>Mở form xem báo cáo cho dang word, excel</summary>
    /// <param name="b_f">trang gọi mở</param>
    /// <param name="b_url">Đường dẫn của trang xem</param>
    /// <param name="b_mau">Chiều rộng của trang xem</param>
    /// <param name="b_out">Chiều cao của trang xem</param>
    /// <param name="b_loai_bc">Loại báo cáo: WR: Word, EC: Excell</param>
    /// <param name="b_ten_bc">Tên file không có phần mở rộg</param>
    /// <param name="b_ds">Dữ liệu đẩy ra báo cáo</param>
    public static void P_MO(Page b_f, string b_url, string b_mau, string b_out, string b_loai_bc, string b_ten_bc, DataSet b_ds)
    {
        b_url = b_f.ResolveUrl(b_url) + "?loai=" + b_loai_bc + "&ten=" + b_ten_bc + "&mau=" + b_mau + "&out=" + b_out;
        HttpContext.Current.Session["kq_ds"] = b_ds; form.P_MO(b_f, b_url, "HTBC" + (new Random().Next()).ToString());
    }
    /// <summary>Mở form xem báo cáo cho dang crystal report</summary>
    /// <param name="b_f">trang gọi mở</param>
    /// <param name="b_url">Đường dẫn của trang xem</param>
    /// <param name="b_ten_bc">Đường dẫ chứa tên file có phần mở rộng</param>
    /// <param name="b_ds">Dữ liệu đẩy ra báo cáo</param>
    public static void P_MO(Page b_f, string b_url, string b_ten_bc, int b_width, int b_height, DataSet b_ds)
    {
        b_url = b_f.ResolveUrl(b_url);
        HttpContext.Current.Session["kq_ds"] = b_ds;
        string b_extra = "',true, 'resizable=yes,scrollbars=yes,height=" + b_height.ToString() + "px,width=" + b_width.ToString() + "px')";
        //form.P_MO(b_f, b_url, "HTBC" + (new Random().Next()).ToString());
        ScriptManager.RegisterStartupScript(b_f, b_f.GetType(), "HTBC" + (new Random().Next()).ToString(), "window.open('" + b_url + b_extra, true);
    }
    /// <summary>Mở form xem báo cáo cho dang crystal report</summary>
    /// <param name="b_f">trang gọi mở</param>
    /// <param name="b_url">Đường dẫn của trang xem</param>
    /// <param name="b_ten_bc">Đường dẫ chứa tên file có phần mở rộng</param>
    /// <param name="b_ds">Dữ liệu đẩy ra báo cáo</param>
    public static void P_MO(Page b_f, string b_url, string b_ten_bc, int b_width, int b_height, DataSet[] b_ds)
    {
        b_url = b_f.ResolveUrl(b_url);
        HttpContext.Current.Session["kq_ds"] = b_ds; //form.P_MO(b_f, b_url, "HTBC" + (new Random().Next()).ToString());
        string b_extra = "',true, 'resizable=yes,scrollbars=yes,height=" + b_height.ToString() + "px,width=" + b_width.ToString() + "px')";
        ScriptManager.RegisterStartupScript(b_f, b_f.GetType(), "HTBC" + (new Random().Next()).ToString(), "window.open('" + b_url + b_extra, true);
    }
    #endregion

    public static void InputExcel(Page b_f, DataSet b_ds, string b_url, string b_tenxml)
    {// "~/Templates/dk, dt, hd, kh"
        string templateFileName = HttpContext.Current.Server.MapPath(b_url + "/" + b_tenxml + ".xml");
        string sOut = "~/Outputs/" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + b_tenxml + ".xls";
        string copyFileName = HttpContext.Current.Server.MapPath(sOut);
        XmlDocument xmlTemplateDoc = new XmlDocument();
        xmlTemplateDoc.Load(templateFileName);
        CExcelMLFiller filler = new CExcelMLFiller(b_ds, xmlTemplateDoc.OuterXml);
        if (!filler.OperationFailed)
        {
            filler.Transform();
            if (filler.OperationFailed && filler.ErrorList.Count > 0) return;
        }
        else if (filler.ErrorList.Count > 0) return;
        filler.ExcelMLDocument.Save(copyFileName);
        b_f.Response.Redirect(sOut, false);
    }
}