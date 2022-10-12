using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;


public partial class f_ns_dt_kh_ct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_kh_ct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_kh_ct_P_KD();", true);
                this.P_MA_DTAC_DROP();
                this.P_NAM_DROP();
                this.P_THANG_DROP();
                this.P_MA_KDT_DROP();
                this.P_NND_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_LKE_ALL();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_KH_CT, TEN_BANG.NS_DT_KH_CT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_kh_ct.xlsx", b_dt, null, "Ke_hoach_dao_tao_chi_tiet");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NAM_DROP()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_KHDT_NAM_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_dt);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
    }
    private void P_THANG_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
        se.P_TG_LUU(this.Title, "DT_THANG_TK", b_dt);
    }
    private void P_MA_KDT_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        se.P_TG_LUU(this.Title, "DT_DM_KDT", b_dt);
    }
    private void P_MA_DTAC_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_DTAC_DR();
        se.P_TG_LUU(this.Title, "DT_DTAC", b_dt);
    }
    private void P_TrangThaiLop_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chưa diễn ra" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Đang diễn ra" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Đã kết thúc" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 0, "Hủy" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_LOP", b_dt);
    }
    private void P_TrangThaiPheDuyet_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Không phê duyệt" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_PD", b_dt);
    }
    private void P_NND_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NND", b_dt);
    }
}