using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hd_dg_tt_cbql : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/cbql/ns_hd_dg_tt_cbql" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hd_dg_tt_cbql_P_KD();", true);
                kthuoc.Value = "1000,820";
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
}