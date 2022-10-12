using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ht_doipass : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ht/ht_doipass" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_doipass_P_KD();", true);
            pascu.Focus();
        }
    }
}