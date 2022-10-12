using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_ma_cket : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_cket" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_cket_P_KD('');", true);
                P_NNNGHIEP();
                P_HTCK();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CKET_LKE_ALL();
            bang.P_SO_CSO(ref b_dt, "cp_tu");
            bang.P_SO_CSO(ref b_dt, "cp_den");
            bang.P_SO_CNG(ref b_dt, new string[] { "ng_hluc","ng_hhluc" });
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_MA_CKET, TEN_BANG.NS_DT_MA_CKET);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ma_cket.xlsx", b_dt, null, "Danh_muc_cam_ket_dao_tao");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NNNGHIEP()
    {
        DataTable b_dt;
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_XEM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NNNGHIEP", b_dt);
    }
    private void P_HTCK()
    {
        DataTable b_dt;
        b_dt = hts_dungchung.Fdt_DT_CHUNG_LKE("HTCK");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_HTCK", b_dt);
    }
}
