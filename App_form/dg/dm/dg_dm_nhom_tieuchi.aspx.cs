using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dg_dm_nhom_tieuchi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_nhom_tieuchi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_nhom_tieuchi_P_KD();", true);
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_NHOM_TIEUCHI, TEN_BANG.DG_DM_NHOM_TIEUCHI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_nhom_tieuchi.xlsx", b_dt, null, "Danh_muc_nhom_tchi_danh_gia");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
