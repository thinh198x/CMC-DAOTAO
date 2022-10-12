using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_log : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_log" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_log_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //lấy các phân hệ theo file ctmenu
        DataTable b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "MA", "TEN" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "TATCA", " " });
        bang.P_THEM_HANG(ref b_dt, new string[] { "HDNS", "Tổ chức nhân sự" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "TD", "Tuyển dụng" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "NS", "Hồ sơ" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "CD", "Bảo hiểm" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "CC", "Chấm công" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "DG360", "Đánh giá 360" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "DG", "Đánh giá" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "DT", "Đào tạo" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "DTO", "Đào tạo online" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "HT", "Quản trị" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "CN", "Cá nhân" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "PD", "Quản lý" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "BC", "Báo cáo" });
        se.P_TG_LUU(this.Title, "DT_PHANHE", b_dt);
        //lấy năm 
        DataTable b_dt_cn = new DataTable();
        bang.P_THEM_COL(ref b_dt_cn, new string[] { "MA", "TEN" });
        bang.P_THEM_HANG(ref b_dt_cn, new string[] { "TATCA", " " });
        bang.P_THEM_HANG(ref b_dt_cn, new string[] { "NV", "Nghiệp vụ" });
        bang.P_THEM_HANG(ref b_dt_cn, new string[] { "TL", "Thiết lập" });
        bang.P_THEM_HANG(ref b_dt_cn, new string[] { "DM", "Danh mục" });
        bang.P_THEM_HANG(ref b_dt_cn, new string[] { "BC", "Xuất báo cáo" });
        se.P_TG_LUU(this.Title, "DT_NHOM_CN", b_dt_cn);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_phanhe = aphanhe.Value, b_nhom_cn = anhom_cn.Value, b_ma_tk = ama_tk.Value, b_chucnang = achucnang.Value, b_tungay = atungay.Value, b_denngay = adenngay.Value;

            DataTable b_dt = ht_macb.Fdt_HT_LOG_LKE_ALL(b_phanhe, b_nhom_cn, b_ma_tk, b_chucnang, b_tungay, b_denngay);

            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_thaotac"); 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.HT_LOG, TEN_BANG.HT_LOG);
            Excel_dungchung.ExportTemplate("Templates/ht_log.xlsx", b_dt, null, "log_ht");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}