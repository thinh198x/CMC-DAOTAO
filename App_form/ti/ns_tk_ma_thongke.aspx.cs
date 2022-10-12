using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tk_ma_thongke : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tk_ma_thongke_P_KD();", true);
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
