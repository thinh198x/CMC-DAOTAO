using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_hdns_kh_tuyendung : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/hdns_kh_tuyendung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hdns_kh_tuyendung_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1220,790";
                nam.Focus(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
}