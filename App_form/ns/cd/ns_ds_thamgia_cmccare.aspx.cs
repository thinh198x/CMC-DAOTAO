using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ds_thamgia_cmccare : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_ds_thamgia_cmccare" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ds_thamgia_cmccare_P_KD();", true);

            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}