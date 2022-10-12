using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_tl_phep : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cc/sns_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cc/ns_cc_tl_phep" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_tl_phep_P_KD();", true);
                P_CONGTY_DR();
                DVI.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_CONGTY_DR()
    {
        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM_QUYEN();
        se.P_TG_LUU(this.Title, "NS_CC_TL_PHEP_DVI", b_dt);
    }


}