using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_dm_tcdg_cd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_tcdg_cd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_tcdg_cd_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Đơn vị tìm kiếm
        DataTable b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NCD", b_dt.Copy());

        //lấy năm
        //DataRow drRow;
        DataTable b_dt1 = sdg.Fdt_DG_DM_MA_KDG_NAM();

        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1);

        // Nhom tieu chi
        DataTable b_dt2 = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
        bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ngay_nh", "nsd", "idvung", "sott" });
        se.P_TG_LUU(this.Title, "DT_NTC", b_dt2);

        //Chi tieu
        DataTable dtbChitieu = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "0", "" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "1", "Không đạt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "2", "Cần cải tiến" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "3", "Đạt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "4", "Tốt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "5", "Xuất sắc" });
        se.P_TG_LUU(this.Title, "DT_CHITIEU", dtbChitieu);
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = dg.Faobj_DG_DM_TCDG_CD_LKE(0, 0);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay_ad"); ;
            b_dt.TableName = "DATA";
            //bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            //bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_TCDG_CD, TEN_BANG.DG_DM_TCDG_CD);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_tcdg_cd.xlsx", b_dt, null, "Danh_sach tieu chi danh gia theo chuc danh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}