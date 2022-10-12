using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_bhxh_chedo : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_bhxh_chedo" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_bhxh_chedo_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();

        //b_dt = ns_ma.Fdt_NS_MA_LYDOBHXH_DR();
        //se.P_TG_LUU(this.Title, "DT_LYDO", b_dt.Copy());

        // hinh thức nhận chế độ
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("HINHTHUC_CDBH");
        se.P_TG_LUU(this.Title, "DT_HINHTHUC_NHAN", b_dt.Copy());

        // điều kiện làm việc
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DKLV");
        se.P_TG_LUU(this.Title, "DT_DIEUKIEN_LV_CD", b_dt.Copy());

        // Tuyến bệnh viên
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TUYEN_BV");
        se.P_TG_LUU(this.Title, "DT_TUYEN_BV_CD", b_dt.Copy());

        // Phương án chế độ ốm đau
        b_dt = ns_ma.Fdt_NS_MA_PHUONGANCHEDOBH_DR("CDOD");
        se.P_TG_LUU(this.Title, "DT_PHUONG_AN_CD", b_dt.Copy());

        // Phương án chế độ thai sản
        b_dt = ns_ma.Fdt_NS_MA_PHUONGANCHEDOBH_DR("CDTS");
        se.P_TG_LUU(this.Title, "DT_PHUONG_AN_TS", b_dt.Copy());

        //Trường hợp hưởng chế độ thai sản
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TH_TS");
        se.P_TG_LUU(this.Title, "DT_TH_HUONG_THAISAN_TS", b_dt.Copy());

        //Điều kiện khám thai
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DK_KT");
        se.P_TG_LUU(this.Title, "DT_DIEUKIEN_KHAMTHAI_TS", b_dt.Copy());

        //Điều kiện sinh con
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DK_SC");
        se.P_TG_LUU(this.Title, "DT_DIEUKIEN_SINHCON_TS", b_dt.Copy());

        //Mang thai hộ
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("MANG_THAI_HO");
        se.P_TG_LUU(this.Title, "DT_MANGTHAI_HO_TS", b_dt.Copy());

        // Phương án phục hồi sức khỏe
        b_dt = ns_ma.Fdt_NS_MA_PHUONGANCHEDOBH_DR("PHSK");
        se.P_TG_LUU(this.Title, "DT_PHUONG_AN_PHSK", b_dt.Copy());

    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_cd.PNS_BHXH_CHEDO_EXCEL(so_the_tk.Text, ten_tk.Text);
            b_dt.TableName = "DATA";

            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_CD", "P1", "DS hưởng chế độ mới phát sinh");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_CD", "P2", "DS đề nghị điều chỉnh số đã được giải quyết");

            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_TS", "P1", "DS hưởng chế độ mới phát sinh");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_TS", "P2", "DS đề nghị điều chỉnh số đã được giải quyết");

            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_PHSK", "P1", "DS hưởng chế độ mới phát sinh");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HINHTHUC_KEKHAI_PHSK", "P2", "DS đề nghị điều chỉnh số đã được giải quyết");


            bang.P_SO_CNG(ref b_dt, "tungay_cd,denngay_cd,ngay_denghi_huong_cd,ngay_sinhcon_cd,ngay_gquyet_truoc_cd,ngay_dilam_lai_ts,tungay_ts," +
                                   "denngay_ts,ngay_denghi_huong_ts,ngay_sinh_con_ts,ngay_con_chet_ts,ngaynhan_connuoi_ts,ngaynhan_con_mth_ts,ngay_me_chet_ts,ngay_ketluat_ts," +
                                   "ngay_gquyet_truoc_ts,ngay_dilam_lai_phsk,tungay_phsk,denngay_phsk,ngay_denghi_huong_phsk,ngay_giamdinh_phsk,ngay_gquyet_truoc_phsk");
            bang.P_SO_CTH(ref b_dt, "thang_nam_gquyet_cd,thang_nam_bsung_cd,thang_nam_gquyet_ts,thang_nam_bsung_ts,thang_nam_gquyet_phsk,thang_nam_bsung_phsk");
            bang.P_SO_CSO(ref b_dt, "tong_so_ngay_cd,so_con_biom_cd,tong_so_ngay_ts,tuoithai_ts,socon_ts,socon_thai_chet_ts,phi_giamdinh_ts,tong_so_ngay_phsk,tyle_suygiam_phsk");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_bhxh_chedo.xlsx", b_dt, null, "Danh sach nguoi huong che do bhxh");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}