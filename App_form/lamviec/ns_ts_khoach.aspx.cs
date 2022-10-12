using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ts_khoach : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/sns_ts.asmx"));
                string b_s = this.ResolveUrl("~/App_form/lamviec/ns_ts_khoach1.js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ts_khoach_KD();", true);
                DataTable b_dt = ns_ts.Fdt_MA_DU_AN();
                form.P_DROP_BANG(DU_AN, b_dt);
               
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
