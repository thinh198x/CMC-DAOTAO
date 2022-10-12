using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_hso_lthem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_hso_lthem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_hso_lthem_P_KD();", true);
           MA.Focus();
        }
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "trangthai" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_cc_hso_lthem_mau.xls", b_dt, null, "ns_cc_hso_lthem_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_CC_HSO_LTHEM_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_TLAP_LAMTHEM, TEN_BANG.TL_TLAP_LAMTHEM);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_cc_hso_lthem.xlsx", b_dt, null, "He_so_lam_them");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
