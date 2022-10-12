using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tl_phieuluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/ns_tl_phieuluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_phieuluong_P_KD();", true);
           MA.Focus();
        }
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "trangthai" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_tl_phieuluong_mau.xls", b_dt, null, "ns_tl_phieuluong_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = null;// ns_ma.Fdt_ns_tl_phieuluong_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_tl_phieuluong.xlsx", b_dt, null, "Danh_muc_truong_hoc");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
