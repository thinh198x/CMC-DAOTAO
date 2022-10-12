using System;
using System.Web.UI.HtmlControls;
using Cthuvien;

public partial class ctr_khud_divL : System.Web.UI.UserControl
{
    public string gridId
    {
        get { return chuyen.OBJ_S(ViewState["gridId"]); }
        set { ViewState["gridId"] = value; }
    }
    public string loai
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["loai"]), "X"); }
        set { ViewState["loai"] = value; }
    }
    public string ham
    {
        get { return kytu.C_NVL(chuyen.OBJ_S(ViewState["ham"])); }
        set { ViewState["ham"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridX b_gr = (GridX)form.Fc_CTR(this.Page, this.gridId);
            b_gr.Attributes.Add("slideId", ctrdivL.ClientID);
            ctrdivL.Attributes.Add("gridId", b_gr.ClientID);
            ctrdivL.Attributes.Add("kieu", "L");
            ctrdivL.Attributes.Add("loai", this.loai);
            ctrdivL.Attributes.Add("ham", this.ham);
            int b_trangKT = b_gr.hangKt;
            if (b_gr.loai == "I")
            {
                se.se_nsd b_se = new se.se_nsd();
                int b_list_kt = (int)chuyen.CSO_SO(b_se.list_kt);
                if (b_list_kt > 1) b_trangKT = b_list_kt;
            }
            ctrdivL.Attributes.Add("TrangKt", b_trangKT.ToString());
            ctrdivL.Attributes.Add("onmousedown", "ctrdivL_Keo(event)");
            ctrdivL.Attributes.Add("onmousemove", "ctrdivL_Keo(event)");
            ctrdivL.Attributes.Add("onmouseout", "chuotUH()");
        }
    }
}
