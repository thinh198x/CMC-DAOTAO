using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_mota_cdanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/ns_dg_mota_cdanh" + khac.Fs_runMode() +".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_mota_cdanh_P_KD();", true);
                //MASP.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}