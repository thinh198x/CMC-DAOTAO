using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_ungvien_nv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_ungvien_nv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_ungvien_nv_P_KD();", true);                
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    { 
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE(); 
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "PHONG_TK", b_dt.Copy());
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TIENTE");
        se.P_TG_LUU(this.Title, "DVI_TINH", b_dt.Copy());
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_TM");
        se.P_TG_LUU(this.Title, "TT_TM", b_dt.Copy());
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_UV");
        se.P_TG_LUU(this.Title, "TT_UV", b_dt.Copy());
    } 
}
