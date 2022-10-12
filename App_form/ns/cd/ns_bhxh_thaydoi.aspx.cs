using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_bhxh_thaydoi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try 
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_bhxh_thaydoi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_bhxh_thaydoi_P_KD('');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "920,430";
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //form.P_DROP_BANG(PHONG, b_dt);
    }
}