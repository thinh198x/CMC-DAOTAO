using System;
using System.Web.UI;
using Cthuvien;

public partial class ktpbsp : UserControl
{
    public string gchuId
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["gchuId"])); }
        set { ViewState["gchuId"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/ktkt/ktpbsp" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "ktpbsp_KD('" + NPa_ktpbsp_tk.ClientID + "','" + ktpbsp_GR_tk.ClientID + "','" + ktpbsp_GR_sp.ClientID + "','"
                + ktpbsp_to_tk.ClientID + "','" + ktpbsp_to_sp.ClientID + "','" + ktpbsp_gchu.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (this.gchuId != "") ktpbsp_GR_sp.gchuId = ktpbsp_GR_tk.gchuId = this.gchuId;
        }
    }
}