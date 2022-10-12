using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dg_dm_kdg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_kdg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_kdg_P_KD();", true);
                P_DROP(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_DROP()
    {
        DataTable b_dt_pbo = ns_ma.Fdt_PNS_DG_MA_CHUNG_DR("PBO_KDG", "A");
        se.P_TG_LUU(this.Title, "DT_MA_KDG_PBO", b_dt_pbo);

        DataTable b_dt_adung = ns_ma.Fdt_PNS_DG_MA_CHUNG_DR("ADUNG_KDG", "A");
        se.P_TG_LUU(this.Title, "DT_MA_KDG_ADUNG", b_dt_adung);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_MA_KDG_LKE_ALL();
            bang.P_SO_CNG(ref b_dt, new string[] { "NG_HLUC", "NG_HET_HLUC" });
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_KDG, TEN_BANG.DG_DM_KDG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_kdg.xlsx", b_dt, null, "Danh_muc_ky_danh_gia");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
   
}
