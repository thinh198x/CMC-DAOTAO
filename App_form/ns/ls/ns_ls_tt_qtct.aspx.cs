using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_tt_qtct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_tt_qtct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_tt_qtct_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }    
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_ls.PNS_LS_CT_TCT_LKE(this.ASOTHE.Value, 1, 1000);
            DataTable b_dt =(DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "luongcb,tongluong,phucap,thuongthang");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_qtct_export.xlsx", b_dt, null, "Qua_trinh_cong_tac");          
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
