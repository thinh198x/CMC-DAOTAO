using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_khud_ttt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sns_khud.asmx"));
            string b_s = this.ResolveUrl("~/App_form/khud/ns_khud_ttt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_khud_ttt_KD();", true);
        }
    }       
}
