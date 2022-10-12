using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_ngv_kqua_dg_kpi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/dg_ngv_kqua_dg_kpi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_ngv_kqua_dg_kpi_P_KD();", true);
                NAM.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //lấy phòng ban
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        //lấy năm 
        DataTable b_dt1 = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nam = an_nam.Value, b_ky_dg = an_ky_dg.Value, b_phong = an_phong.Value;
            object[] a_obj = dg.Fdt_DG_NGV_KQUA_DG_KPI_LKE(1, 999999, b_nam, b_ky_dg, b_phong);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_COPY_COL(ref b_dt, "ten_xac_nhan", "xac_nhan");
            bang.P_THAY_GTRI(ref b_dt, "ten_xac_nhan", "0", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_dt, "ten_xac_nhan", "1", "Đã xác nhận");

            bang.P_THAY_GTRI(ref b_dt, "ten_xac_nhan_ns", "0", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_dt, "ten_xac_nhan_ns", "1", "Đã xác nhận"); 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_NGV_KQUA_DG_KPI, TEN_BANG.DG_NGV_KQUA_DG_KPI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_ngv_kqua_dg_kpi.xlsx", b_dt, null, "Tong_hop_ket_qua_danh_gia_kpi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}