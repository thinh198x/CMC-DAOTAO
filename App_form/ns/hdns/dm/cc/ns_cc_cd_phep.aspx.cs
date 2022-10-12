using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
public partial class f_ns_cc_cd_phep : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cc/sns_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cc/ns_cc_cd_phep" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_cd_phep_P_KD();", true);
            P_NgachNgheNghiep_DR();
        }
    }

    private void P_NgachNgheNghiep_DR()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_XEM();
        DataRow b_dr = b_dt.NewRow();
        b_dt.Rows.InsertAt(b_dr, 0);
        se.P_TG_LUU(this.Title, "NS_CC_CD_PHEP_NNN", b_dt);
    }
}