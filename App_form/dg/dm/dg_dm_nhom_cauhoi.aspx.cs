using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dg_dm_nhom_cauhoi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_nhom_cauhoi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_nhom_cauhoi_P_KD();", true); 

                //DataTable b_dt = new DataTable();
                //b_dt.Columns.Add("MA", typeof(string));
                //b_dt.Columns.Add("TEN", typeof(string)); 
                //bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" }, 0);
                //bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" }, 1);
                //form.P_DROP_BANG(TRANGTHAI, b_dt);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_MA_NHOM_CAUHOI_LKE_ALL();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_NHOM_CAUHOI, TEN_BANG.DG_DM_NHOM_CAUHOI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_nhom_cauhoi.xlsx", b_dt, null, "Danh_muc_nhom_cau_hoi");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
   
}
