using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_uv_yeucauTD : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_uv_yeucauTD" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_uv_yeucauTD_P_KD();", true);
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
        // TRẠNG THÁI ỨNG VIÊN
        b_dt = new DataTable(); b_dt = ht_dungchung.Fdt_CHUNG_LKE_ORDER("TT_UV"); se.P_TG_LUU(this.Title, "DT_UV", b_dt.Copy());
        bang.P_THEM_HANG(ref b_dt, new object[] { " ", " " }, 0); se.P_TG_LUU(this.Title, "DT_UV_TK", b_dt.Copy());
        // ĐỀ XUẤT TUYỂN DỤNG
        b_dt = new DataTable(); b_dt = ns_td.Fdt_NS_TD_DEXUAT_LKE_ALL();
        bang.P_THEM_HANG(ref b_dt, new object[] { " ", " " }, 0); se.P_TG_LUU(this.Title, "DT_MA_YC_TK", b_dt.Copy());
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_GAN_UV_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_UV_YEUCAUTD, TEN_BANG.NS_TD_UV_YEUCAUTD);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_uv_yeucauTD.xlsx", b_dt, null, "Danh_sach_ung_vien_duoc_gan_vao_yeu_cau");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}