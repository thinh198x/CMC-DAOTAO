using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_kq_hienthi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_kq_hienthi_P_KD();", true);
            LOAI.Focus(); 
        } 
    }
}
