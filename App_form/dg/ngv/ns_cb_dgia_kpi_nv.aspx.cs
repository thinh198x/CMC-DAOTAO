using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cb_dgia_kpi_nv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/ns_cb_dgia_kpi_nv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cb_dgia_kpi_nv_P_KD('" + b_so_the + "');", true);
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
        b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));

        ////lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);


        DataTable b_dt1 = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL("");
        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_KY_DG_TK", b_dt1);

        //Xeploai
        DataTable dtb_heso_xeploai = dg.PQL_DG_CV_HT_LAY_HESO_XEPLOAI("1"); // lấy hệ số xếp loại theo loại đánh giá năm(KPI)
        se.P_TG_LUU(this.Title, "DT_HS_XL", dtb_heso_xeploai);
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {

            object[] a_obj = dg.Faobj_NS_CB_DGIA_KPI_NV_LKE_ALL(nam_tk_an.Value, trangthai_tk_an.Value, ky_dg_tk_an.Value);
            DataTable b_dt = (DataTable)a_obj[0];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "Không phê duyệt");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CB_DGIA_KPI_NV, TEN_BANG.NS_CB_DGIA_KPI_NV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cb_dgia_kpi_nv.xlsx", b_dt, null, "Quan_ly_danh_gia_kpi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void Xuat_Excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet(); 
            DataSet b_ds_in = dg.Faobj_NS_CB_DGIA_KPI_NV_PRINT(so_id.Value);
            // Thông tin nhân viên
            DataTable b_dt = b_ds_in.Tables[0];
            // Thông tin quản lý
            DataTable b_dt2 = b_ds_in.Tables[1];
            // Thông tin đánh giá mức độ hoàn thành công việc
            DataTable b_dt3 = b_ds_in.Tables[2];
            // Thông tin đánh giá năng lực
            DataTable b_dt4 = b_ds_in.Tables[3];
            // Thông tin đánh giá chung
            DataTable b_dt5 = b_ds_in.Tables[4];
            b_dt.TableName = "DATA";
            b_dt2.TableName = "DATA2";
            b_dt3.TableName = "DATA3";
            b_dt4.TableName = "DATA4";
            b_dt5.TableName = "DATA5";
            b_ds.Tables.Add(b_dt.Copy());
            b_ds.Tables.Add(b_dt2.Copy());
            b_ds.Tables.Add(b_dt3.Copy());
            b_ds.Tables.Add(b_dt4.Copy());
            b_ds.Tables.Add(b_dt5.Copy());
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_CB_DGIA_KPI_NV, TEN_BANG.NS_CB_DGIA_KPI_NV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cb_dgia_kpi_nv_print.xlsx", b_ds, null, "Quan_ly_danh_gia_kpi_nhan_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    //private string P_SOTHE(string b_nsd)
    //{
    //    string b_so_the = "";
    //    DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
    //    if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
    //    return b_so_the;
    //}
}