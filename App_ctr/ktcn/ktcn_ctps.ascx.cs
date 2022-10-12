using System;
using System.Web.UI;
using Cthuvien;

public partial class ktcn_ctps : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/ktcn/ktcn_ctps"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "ktcn_ctps_P_KD('" + ktcn_ctps_GR_ct.ClientID + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
        }
    }
}
