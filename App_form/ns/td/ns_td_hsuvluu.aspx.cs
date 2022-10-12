using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_hsuv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_hsuv_P_KD('');", true);
                P_NHAN_DROP(); CMT.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "ma", "ten" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "NAM", "Nam" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "NU", "Nữ" });
        form.P_DROP_BANG(gtinh, b_dt);
    }
}
