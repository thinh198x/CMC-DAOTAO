using System;
using System.Web.UI.HtmlControls;
using Cthuvien;

public partial class ctr_khud_divN : System.Web.UI.UserControl
{
    public string divNId
    {
        get { return chuyen.OBJ_S(ViewState["divNId"]); }
        set { ViewState["divNId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl b_div = (HtmlGenericControl)form.Fc_CTR(this.Page, this.divNId);
            ctrDivN.Attributes.Add("kieu", "ctrDivN");
            ctrDivN.Attributes.Add("divNId", b_div.ClientID);
            b_div.Attributes.Add("divNId", ctrDivN.ClientID);
            ctrDivN.Attributes.Add("onmousedown", "ctrDivN_Keo(event)");
            ctrDivN.Attributes.Add("onmousemove", "ctrDivN_Keo(event)");
        }
    }
}