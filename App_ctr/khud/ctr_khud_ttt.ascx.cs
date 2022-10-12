using System;
using System.Web.UI;
using Cthuvien;

public partial class ctr_khud_ttt : System.Web.UI.UserControl
{
    /// <summary>Đặt chiều rộng các cột cách nhau dấu phẩy. Cú pháp ten_cot:rong</summary>
    public string rong
    {
        get { return chuyen.OBJ_S(ViewState["rong"]); }
        set { ViewState["rong"] = value; }
    }
    public int hang
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/khud/ctr_khud_ttt"+khac.Fs_runMode()+".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "khud_ttt_KD('" + this.ps + "','" + this.nv + "','" + khud_ttt_gchu.ClientID +"','" + khud_ttt_GR_dk.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (kytu.C_NVL(this.rong) != "") khud_ttt_GR_dk.cotRong = this.rong;
            if (this.hang != 0) khud_ttt_GR_dk.hangKt = this.hang;
            khud_ttt_GR_dk.ctrT = this.ctr_truoc; khud_ttt_GR_dk.ctrS = this.ctr_sau;
        }
    }
}
