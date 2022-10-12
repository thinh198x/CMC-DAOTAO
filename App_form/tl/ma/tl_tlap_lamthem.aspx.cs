using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_tlap_lamthem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/tl_tlap_lamthem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_tlap_lamthem_P_KD();", true);

            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}