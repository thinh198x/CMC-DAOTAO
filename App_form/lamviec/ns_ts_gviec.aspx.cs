using Cthuvien;
using System;
using System.Data;
using System.Web.UI;

public partial class f_ns_ts_gviec : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bhc/sbhc_ht_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bhc/sns_ts_gviec.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bhc/sbhc_tk.asmx"));
                string b_s = this.ResolveUrl("~/App_form/lamviec/ns_ts_gviec1.js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                //b_s = "ns_ts_gviec_KD('" + khac.Fs_TMUCF(b_s) + "');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
