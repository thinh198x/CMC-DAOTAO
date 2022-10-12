using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_gd_hc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_gd_hc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_gd_hc_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1020,700";
                SO_THE.Focus(); NGAYD.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}