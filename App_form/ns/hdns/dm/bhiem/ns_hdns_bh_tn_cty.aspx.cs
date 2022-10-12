using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_bh_tn_cty : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/bhiem/ns_hdns_bh_tn_cty" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_bh_tn_cty_P_KD();", true);
            P_NHAN_DROP(); NGAY_HL.Focus();
        }
    }

    private void P_NHAN_DROP()
    {
        //Ma dvi
        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM_QUYEN();
        se.P_TG_LUU(this.Title, "DT_DVI", b_dt.Copy());
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_BH_TN_LKE_DR();
        se.P_TG_LUU(this.Title, "DT_LBH", b_dt.Copy());
        
    }
}
