using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_kh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_kh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver); ngay.Text = chuyen.NG_CNG(DateTime.Now);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_kh_P_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
