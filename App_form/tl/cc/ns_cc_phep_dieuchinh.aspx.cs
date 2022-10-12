using System;
using System.Web.UI;
using Cthuvien;
using System.Data;
using System.Web;

public partial class f_ns_cc_phep_dieuchinh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_phep.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_phep_dieuchinh" + khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_phep_dieuchinh_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            string sPathTemplate = "/Templates/importmau/NS_CC_PHEP_DIEUCHINH.xlsx";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            wBook.CalculateFormula();
            wBook.Save(HttpContext.Current.Response, "NS_CC_PHEP_DIEUCHINH.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }


    protected void xuat_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_phep.Fdt_NS_CC_NGHIPHEP_DIEUCHINH_XUATEXCEL();
            bang.P_CSO_CNG(ref b_dt, new string[] { "ngayd_kttn", "ngayc_kttn", "thang_dieuchinh", "thang_giahan" });
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_phep_dieuchinh.xls", b_dt, null, "ns_cc_phep_dieuchinh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
