using System;
using System.Web.UI.HtmlControls;
using Cthuvien;

public partial class ctr_khud_divD : System.Web.UI.UserControl
{
    public string divDId
    {
        get { return chuyen.OBJ_S(ViewState["divDId"]); }
        set { ViewState["divDId"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HtmlGenericControl b_div = (HtmlGenericControl)form.Fc_CTR(this.Page, this.divDId);
            ctrDivD.Attributes.Add("kieu", "ctrDivD");
            ctrDivD.Attributes.Add("divDId", b_div.ClientID);
            b_div.Attributes.Add("divDId", ctrDivD.ClientID);
            ctrDivD.Attributes.Add("onmousedown", "ctrDivD_Keo(event)");
            ctrDivD.Attributes.Add("onmousemove", "ctrDivD_Keo(event)");
        }
    }
}