using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_khud : System.Web.UI.UserControl
{
    /// <summary>Đặt chiều rộng các cột cách nhau dấu phẩy. Cú pháp ten_cot:rong</summary>
    public string rong
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["rong"])); }
        set { ViewState["rong"] = value; }
    }
    public int dong
    {
        get { return chuyen.OBJ_I(ViewState["hang"]); }
        set { ViewState["hang"] = value; }
    }
    public string ps
    {
        get { return chuyen.OBJ_S(ViewState["ps"]); }
        set { ViewState["ps"] = value; }
    }
    public string nv
    {
        get { return chuyen.OBJ_S(ViewState["nv"]); }
        set { ViewState["nv"] = value; }
    }
    public string kdvi
    {
        get { return chuyen.OBJ_S(ViewState["kdvi"],""); }
        set { ViewState["kdvi"] = value; }
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


    public string grid_id
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["grid_id"])); }
        set { ViewState["grid_id"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/khud/ns_khud"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "ns_khud_KD('" + this.ps + "','" + this.nv + "','" + ns_khud_gchu.ClientID
                + "','" + ns_khud_GR_dk.ClientID + "','" + this.kdvi + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (kytu.C_NVL(this.rong) != "") ns_khud_GR_dk.cotRong = this.rong;
            if (this.dong != 0) ns_khud_GR_dk.hangKt = this.dong;
            if (this.ctr_truoc!="") ns_khud_GR_dk.ctrT = this.ctr_truoc;
            if (this.ctr_sau!="") ns_khud_GR_dk.ctrS = this.ctr_sau;
        }
    }
}
