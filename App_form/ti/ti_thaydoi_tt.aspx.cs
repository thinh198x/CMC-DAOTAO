using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ti_thaydoi_tt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                se.se_nsd b_se = new se.se_nsd();
                SO_THE.Text = b_se.nsd;
                string b_s = this.ResolveUrl("~/App_form/ti/ti_thaydoi_tt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_thaydoi_tt_P_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}