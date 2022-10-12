using System;
using System.Web.UI;
using Cthuvien;

public partial class f_kh_dich : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                string b_s = this.ResolveUrl("~/App_form/khud/kh_dich" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                TMUC.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}