using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ql_dg_cv_ht : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/ql_dg_cv_ht" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ql_dg_cv_ht_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));
        bang.P_THEM_HANG(ref b_dt, new object[] { "CG", "Chưa gửi" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] { "0", "Chờ xem xét" }, 1);
        bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Đã xem xét" }, 2);
        bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Không phê duyệt" }, 3);
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI_TK", b_dt);
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI", b_dt);

        ////lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);

        //Xeploai
        DataTable dtb_heso_xeploai = dg.PQL_DG_CV_HT_LAY_HESO_XEPLOAI("0"); // lấy hệ số xếp loại theo loại đánh giá tháng
        se.P_TG_LUU(this.Title, "DT_HS_XL", dtb_heso_xeploai);
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {

            object[] a_obj = dg.Faobj_QL_DG_CV_HT_LKE_ALL(trangthai_tk_an.Value, nam_tk_an.Value, ky_dg_tk_an.Value);
            DataTable b_dt = (DataTable)a_obj[0];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "Không phê duyệt");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.QL_DG_CV_HT, TEN_BANG.QL_DG_CV_HT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ql_dg_cv_ht.xlsx", b_dt, null, "Quan_ly_danh_gia_cong_viec_hang_thang");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}