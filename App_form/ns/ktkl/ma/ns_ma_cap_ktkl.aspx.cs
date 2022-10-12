using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ma_cap_ktkl : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ktkl/sns_ktkl.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ktkl/ma/ns_ma_cap_ktkl"+khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_cap_ktkl_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "800,485";
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }
}
