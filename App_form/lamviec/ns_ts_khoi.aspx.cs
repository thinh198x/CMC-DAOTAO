using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ts_khoi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/sns_ts.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/lamviec/ns_ts_khoi1.js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ts_khoi_KD();", true);
                TU_NGAY_TK.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                DEN_NGAY_TK.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable b_dt = ns_ts.Fdt_MA_DU_AN();
                DataTable b_dt2 = ns_ts.Fdt_MA_PHONG_TS_LKE();
                bang.P_THEM_HANG(ref b_dt2, new object[] { "TC","","", "Tất cả" }, 0);
                form.P_DROP_BANG(phong, b_dt2);

                b_dt = ns_ts.Fdt_MA_DU_AN();
                bang.P_THEM_HANG(ref b_dt, new object[] { "TC", "Tất cả" }, 0);
                form.P_DROP_BANG(duan, b_dt);
                if (se.Fs_DUYET() == "INTERNETEXPLORER") kthuoc.Value = "900,470";
                else kthuoc.Value = "900,650";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    } 
}
