using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_tt_hd_ld : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_tt_hd_ld" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_tt_hd_ld_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }    
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_HD_LD_EXPORT(this.ASOTHE.Value);
            bang.P_SO_CNG(ref b_dt, "ngay_ky"); bang.P_SO_CNG(ref b_dt, "ngayd");bang.P_SO_CNG(ref b_dt, "ngayc");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_tt_hd_ld_export.xlsx", b_dt, null, "Ls_quatrinhcongtac_trongcongty");          
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
