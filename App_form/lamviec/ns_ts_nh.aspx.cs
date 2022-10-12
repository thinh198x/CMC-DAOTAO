using System;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ns_ts_nh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/sns_ts.asmx"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/lamviec/ns_ts_nh" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss")));
                ngay.Text = DateTime.Now.ToString("dd/MM/yyyy");
                tu_ngay_ts.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                den_ngay_ts.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable b_dt = ns_ts_gv.Fdt_MA_CV(); form.P_DROP_BANG(cv, b_dt);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ts_nh_KD();", true);

                if (se.Fs_DUYET() == "INTERNETEXPLORER") kthuoc.Value = "740,580";
                else kthuoc.Value = "740,590";

            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
