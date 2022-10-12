using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ed_dash : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
               // ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ed/sed_vb_chung.asmx"));
                string b_s = this.ResolveUrl("~/ed_dash" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}