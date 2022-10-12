using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ctt_pdkhdt_ct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ctt/ngv/ns_ctt_pdkhdt_ct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ctt_pdkhdt_ct_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";               
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}