using System;
using System.Web.UI.HtmlControls;
using Cthuvien;

public partial class ctr_khud_divC : System.Web.UI.UserControl
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
            b_gr.Attributes.Add("slideId", ctrdivC.ClientID);
            ctrdivC.Attributes.Add("gridId", b_gr.ClientID);
            ctrdivC.Attributes.Add("kieu", "C");
            ctrdivC.Attributes.Add("loai", this.loai);
            ctrdivC.Attributes.Add("ham", this.ham);
            int b_trangKT = b_gr.hangKt;
            if (b_gr.loai == "I")
            {
                se.se_nsd b_se = new se.se_nsd();
                int b_list_kt = (int)chuyen.CSO_SO(b_se.list_kt);
                if (b_list_kt > 1) b_trangKT = b_list_kt;
            }
            ctrdivC.Attributes.Add("TrangKt", b_trangKT.ToString());
            ctrdivC.Attributes.Add("onmousedown", "ctrdivC_Keo(event)");
            ctrdivC.Attributes.Add("onmousemove", "ctrdivC_Keo(event)");
            ctrdivC.Attributes.Add("onmouseout", "chuotUH()");
        }
    }
}
