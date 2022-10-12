using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_bhxh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try 
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_bhxh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_bhxh_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "620,450";
                
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}