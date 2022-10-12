using System;
using System.Web.UI;
using Cthuvien;

public partial class ktvt_tonkho : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/ktvt/ktvt_tonkho"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "ktvt_tonKho_KD('" + ktvt_tonKho_GR_ct.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
        }
    }
}