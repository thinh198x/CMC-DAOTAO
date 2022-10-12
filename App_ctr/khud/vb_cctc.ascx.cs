using System;
using System.Web.UI;
using Cthuvien;

public partial class vb_cctc : System.Web.UI.UserControl
{
    public string tao
    {
        get { return chuyen.OBJ_S(ViewState["tao"], "K"); }
        set { ViewState["tao"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/khud/vb_cctc" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "vb_cctc_KD('" + this.tao + "','" + vb_CCTC.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
        }
    }
}
