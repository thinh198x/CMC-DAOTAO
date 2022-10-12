using System;
using System.Web.UI;
using Cthuvien;

public partial class ctr_khud_cay : System.Web.UI.UserControl
{
    /// <summary>
    /// Cho phep chon: K-Không, C-Chỉ chọn chi tiết, T-Chọn tất cả
    /// </summary>
    public string chon
    {
        get { return chuyen.OBJ_S(ViewState["chon"], "K"); }
        set { ViewState["chon"] = value; }
    }
    /// <summary>
    /// Cho phep chon: K-Không, C-Chỉ chọn chi tiết, T-Chọn tất cả
    /// </summary>
    public string ham
    {
        get { return chuyen.OBJ_S(ViewState["ham"]); }
        set { ViewState["ham"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_ctr/khud/ctr_khud_cay" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "ctr_khud_cay_KD('" + this.chon + "','" + this.ham + "','" + Upa_khud_cay.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
        }
    }
}
