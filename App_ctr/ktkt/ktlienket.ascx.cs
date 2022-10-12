using System;
using System.Web.UI;
using Cthuvien;

public partial class ktlienket : UserControl
{
    public string md
    {
        get { return chuyen.OBJ_S(ViewState["md"]); }
        set { ViewState["md"] = value;}

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/ktkt/ktlienket"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

            b_s = this.ResolveUrl("~/App_form/ktkt/ktkt_ct.aspx");
            int b_i=b_s.IndexOf("/App_form");
            b_s = "lienket_P_KD('" + md + "','" + lienket_div.ClientID + "','" + b_s.Substring(0,b_i) + "');";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
        }
    }
}
