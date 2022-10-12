using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class khud_ma : System.Web.UI.UserControl
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
        }
    }
}