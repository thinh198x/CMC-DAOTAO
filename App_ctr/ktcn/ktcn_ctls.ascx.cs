using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class ktcn_ctls : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = "ktcn_ctls_KD('" + ktcn_ctls_ppt.ClientID + "','" + ktcn_ctls_GR_ct.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            DataTable b_dt = Fdt_PPT(); form.P_DROP_BANG(ktcn_ctls_ppt, b_dt);
        }
    }
    private DataTable Fdt_PPT()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Tháng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Năm" });
        b_dt.AcceptChanges();
        return b_dt;
    }
}