using System;
using Cthuvien;

public partial class khud_scrl : System.Web.UI.UserControl
{
    public string ham
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["ham"])); }
        set { ViewState["ham"] = value; }
    }
    public string gridId
    {
        get { return chuyen.OBJ_S(ViewState["gridId"]); }
        set { ViewState["gridId"] = value; }
    }
    public string loai
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["loai"])); }
        set { ViewState["loai"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_slideId = this.ClientID;
            GridX b_gr = (GridX)form.Fc_CTR(this.Page, this.gridId);
            int b_trangKT = b_gr.hangKt;
            slide.Length = b_trangKT * 21 - 16;
            an.Attributes.Add("gridId", b_gr.ClientID);
            an.Attributes.Add("ten_goc", this.ID + "_an");
            an.Attributes.Add("loai", this.loai);
            an.Attributes.Add("kieu", "D");
            string b_ham = (this.ham != "") ? this.ham : "slide_P_CHUYEN('" + b_slideId + "', '')";
            an.Attributes.Add("onchange", b_ham);
            an.Attributes.Add("TrangKt", b_trangKT.ToString());
            an.Attributes.Add("TrangCu", "1");
            len.Attributes.Add("onclick", "return slide_P_CHUYEN('" + b_slideId + "','T');");
            xuong.Attributes.Add("onclick", "return slide_P_CHUYEN('" + b_slideId + "','P');");
            b_gr.Attributes.Add("slideId", b_slideId);
        }
    }
}