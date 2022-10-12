using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ma_ht_setup : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ns_ma_ht_setup" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_ht_setup_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1000,710";
                dvi.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message );}
    }
}
