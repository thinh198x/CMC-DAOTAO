using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_chiphi_bh_tn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/bhiem/ns_ma_chiphi_bh_tn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_chiphi_bh_tn_P_KD();", true);
            P_NHAN_DROP();
            MA.Focus();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_BH_TN_LKE_DR();
        se.P_TG_LUU(this.Title, "LOAI_BH", b_dt);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_MA_CHIPHI_BH_TN_EXCEL();
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_chiphi_bh_tn.xlsx", b_dt, null, "Danh_muc_chi_phi_bao_hiem_tu_nguyen");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
