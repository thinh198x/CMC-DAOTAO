using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_giaitrinh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_cc_giaitrinh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_giaitrinh_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);                
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }    
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = null;// ns_ls.Pns_cc_giaitrinh_EXPORT(SO_THE.Text.Trim());
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_CSO_SO(ref b_dt, "sotien");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_giaitrinh_export.xlsx", b_dt, null, "Qua_trinh_khen_thuong");          
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
