using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_macvu : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_macvu"+khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_macvu_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "775,485";
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }
}
