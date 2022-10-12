using System;
using System.Web.UI;
using Cthuvien;

public partial class kthtoan : UserControl
{
    public string rong
    {
        get {return kytu.C_NVL(chuyen.OBJ_S(ViewState["rong"]));}
        set { ViewState["rong"] = value; }
    }
    public int hang
    {
        get
        {
            int b_hang = chuyen.OBJ_I(ViewState["hang"]);
            return (b_hang == 0) ? 5 : b_hang;
        }
        set { ViewState["hang"] = value; }
    }
    public string ctr_truoc
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["ctr_truoc"])); }
        set { ViewState["ctr_truoc"] = value; }
    }
    public string ctr_sau
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["ctr_sau"])); }
        set { ViewState["ctr_sau"] = value; }
    }
    public string gchuId
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["gchuId"])); }
        set { ViewState["gchuId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/ktkt/kthtoan"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "kthtoan_P_KD('" + ktoan_GR_ct.ClientID + "','" + ktoan_no.ClientID + "','" + ktoan_co.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (this.rong!="") ktoan_GR_ct.cotRong = this.rong;
            ktoan_GR_ct.hangKt = this.hang; ktoan_GR_ct.gchuId = this.gchuId;
            ktoan_GR_ct.ctrT = this.ctr_truoc; ktoan_GR_ct.ctrS = this.ctr_sau;
        }
    }
}