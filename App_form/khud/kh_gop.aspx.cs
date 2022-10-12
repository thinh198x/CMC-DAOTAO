using System;
using System.Web.UI;
using Cthuvien;

public partial class f_kh_gop : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                string b_s = this.ResolveUrl("~/App_form/khud/kh_gop"+khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ND.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }
}