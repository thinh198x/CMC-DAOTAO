using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_uv : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_uv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_uv_P_KD('" + XuatFileMau.UniqueID + "');", true);
                so_the.Text = ht_dungchung.Fdt_AutoGenCode("UV", "NS_TD_UV_CV", "SO_THE");
                P_NHAN_DROP(); so_the.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = b_dt = new DataTable();
        // Giới tính
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("GT"); se.P_TG_LUU(this.Title, "DT_GIOI_TINH", b_dt.Copy());
        // Nơi cấp CMT
        b_dt = new DataTable(); b_dt = ns_ma.Fdt_NS_MA_TT_DR(); se.P_TG_LUU(this.Title, "DT_NOICAP_CMT", b_dt.Copy());
        // Dân tộc
        b_dt = new DataTable(); b_dt = ht_dungchung.Fdt_NS_MA_DT_DR(); se.P_TG_LUU(this.Title, "DT_DT", b_dt.Copy());
        // TÔN GIÁO
        b_dt = new DataTable(); b_dt = ht_dungchung.Fdt_NS_MA_TG_DR(); se.P_TG_LUU(this.Title, "DT_TG", b_dt.Copy());
        // TÌNH TRẠNG HÔN NHÂN
        b_dt = new DataTable(); b_dt = hts_dungchung.Fdt_CHUNG_LKE("HN"); se.P_TG_LUU(this.Title, "DT_TT_HONNHAN", b_dt.Copy());
        // TRẠNG THÁI ỨNG VIÊN TRONG KHO
        b_dt = new DataTable(); b_dt = ht_dungchung.Fdt_CHUNG_LKE_ORDER("TT_UV_KHO"); se.P_TG_LUU(this.Title, "DT_UV", b_dt.Copy());
        bang.P_THEM_HANG(ref b_dt, new object[] { " ", " " }, 0); se.P_TG_LUU(this.Title, "DT_UV_TK", b_dt.Copy());
        // chức danh mong muốn tuyển dụng
        b_dt = new DataTable(); b_dt = ns_ma.Fdt_NS_MA_CDANH_LKE_DR("TATCA"); se.P_TG_LUU(this.Title, "DT_CDANH_UT", b_dt.Copy());
        bang.P_THEM_HANG(ref b_dt, new object[] { " ", " " }, 0); se.P_TG_LUU(this.Title, "DT_CDANH_UTTK", b_dt.Copy());

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_UV_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_UV_CV, TEN_BANG.NS_TD_UV_CV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_uv_cv.xlsx", b_dt, null, "Danh_sach_ung_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void XuatFileMau_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_dantoc = hts_dungchung.Fdt_NS_MA_DT_DR();
            DataTable b_dt_tongiao = hts_dungchung.Fdt_NS_MA_TG_DR();
            DataTable b_dt_tinhthanh = ns_ma.Fdt_NS_MA_TT_DR();
            DataTable b_dt_quanhuyen = hts_dungchung.Fdt_NS_MA_QH_DR("0");
            DataTable b_dt_xaphuong = hts_dungchung.Fdt_NS_MA_XP_DR("0");
            DataTable b_dt_gt = hts_dungchung.Fdt_CHUNG_LKE("GT");
            DataTable b_dt_honnhan = hts_dungchung.Fdt_CHUNG_LKE("HN");
            DataTable b_dt_th = ns_ma.Fdt_NS_MA_TRUONGHOC_DR();
            DataTable b_dt_chuyennganh = ns_ma.Fdt_NS_MA_CNDT_DR();
            DataTable b_dt_trinhdo = ns_ma.Fdt_NS_MA_BC_DR();
            DataTable b_dt_hinhthuc = ns_ma.Fdt_NS_MA_HTDT_DR();
            DataTable b_dt_lqh = ns_ma.Fdt_NS_MA_LQH_DR();

            b_dt_dantoc.TableName = "DATA1";
            b_dt_tongiao.TableName = "DATA2";
            b_dt_tinhthanh.TableName = "DATA3";
            b_dt_quanhuyen.TableName = "DATA4";
            b_dt_xaphuong.TableName = "DATA5";
            b_dt_gt.TableName = "DATA6";
            b_dt_honnhan.TableName = "DATA7";
            b_dt_th.TableName = "DATA8";
            b_dt_chuyennganh.TableName = "DATA9";
            b_dt_trinhdo.TableName = "DATA10";
            b_dt_hinhthuc.TableName = "DATA11";
            b_dt_lqh.TableName = "DATA12";

            b_ds.Tables.Add(b_dt_dantoc);
            b_ds.Tables.Add(b_dt_tongiao);
            b_ds.Tables.Add(b_dt_tinhthanh);
            b_ds.Tables.Add(b_dt_quanhuyen);
            b_ds.Tables.Add(b_dt_xaphuong);
            b_ds.Tables.Add(b_dt_gt);
            b_ds.Tables.Add(b_dt_honnhan);
            b_ds.Tables.Add(b_dt_th);
            b_ds.Tables.Add(b_dt_chuyennganh);
            b_ds.Tables.Add(b_dt_trinhdo);
            b_ds.Tables.Add(b_dt_hinhthuc);
            b_ds.Tables.Add(b_dt_lqh);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TD_UV_CV, TEN_BANG.NS_TD_UV_CV);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_uv_imp.xls", b_ds, null, "TD_KHO_UV" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}
