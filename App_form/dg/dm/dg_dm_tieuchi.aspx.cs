using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dg_dm_tieuchi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_tieuchi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_tieuchi_P_KD();", true);
                P_NHOM_TIEUCHI_DROP();
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHOM_TIEUCHI_DROP()
    {
        DataTable b_dt = dg.Fdt_NS_DG_MA_NHOM_TCHI_DR("A");
        se.P_TG_LUU(this.Title, "DT_DG_NHOM_TCHI", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_MA_TCHI_LKE_ALL("");
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_TIEUCHI, TEN_BANG.DG_DM_TIEUCHI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_tieuchi.xlsx", b_dt, null, "Danh_muc_tchi_danh_gia");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void excel_mau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";

        DataTable b_dt_nhom = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
        b_dt_nhom.TableName = "DATA1";

        DataSet ds = new DataSet();
        ds.Tables.Add(b_dt);
        ds.Tables.Add(b_dt_nhom);

        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_MAU, TEN_FORM.DG_DM_TIEUCHI, TEN_BANG.DG_DM_TIEUCHI);
        Excel_dungchung.ExportTemplate("Templates/importhdns/dg_dm_tieuchi.xls", ds, null, "dg_dm_tieuchi");
    }
}
