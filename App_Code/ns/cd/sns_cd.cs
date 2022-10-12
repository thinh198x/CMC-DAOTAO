using System;
using System.Data;
using System.Web.Services;
using Cthuvien;
using System.Web;


[System.Web.Script.Services.ScriptService]
public class sns_cd : System.Web.Services.WebService
{
    #region BẢO HIỂM XÃ HỘI
    [WebMethod(true)]
    public string Fs_NS_BHXH_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_cd.Fdt_NS_BHXH_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_bhxh,ngayd,ngayc,ndongbhxh,ndongbhtn,ngay_trabhxh,ngay_trabhyt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_BHXH_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_cd.P_NS_BHXH_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_BHXH_XOA(string b_so_the)
    {
        try
        { ns_cd.P_NS_BHXH_XOA(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion BẢO HIỂM XÃ HỘI

    #region BẢO HIỂM THẤT NGHIỆP
    [WebMethod(true)]
    public string Fs_NS_BHTN_HOI(string b_login, string b_so_the)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_cd.Fdt_NS_BHTN_HOI(b_so_the);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {

            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_BHTN_LKE(string b_login, string b_so_the, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_cd.Fdt_NS_BHTN_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHTN_CT(string b_login, string b_so_the, string b_thangd)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_cd.Fdt_NS_BHTN_CT(b_so_the, b_thangd);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHTN_NH(string b_login, object[] a_dt_ct)
    {

        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_cd.P_NS_BHTN_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_BHTN_XOA(string b_login, string b_so_the, string b_thangd)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_cd.P_NS_BHTN_XOA(b_so_the, b_thangd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }

    #endregion BẢO HIỂM THẤT NGHIỆP

    #region KINH PHÍ CÔNG ĐOÀN

    [WebMethod(true)]
    public string Fs_NS_KPCD_LKE(string b_login, string b_so_the, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_cd.PNS_KPCD_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KPCD_CT(string b_login, string b_so_id, string b_so_the)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_cd.PNS_KPCD_CT(b_so_id, b_so_the);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KPCD_NH(string b_login, string b_so_id, object[] a_dt_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            return ns_cd.PNS_KPCD_NH(ref b_so_id, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KPCD_XOA(string b_login, string b_so_the, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_cd.PNS_KPCD_XOA(b_so_the, b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion KINH PHÍ CÔNG ĐOÀN

    #region CHẾ ĐỘ BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_BHXH_CHEDO_CB(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_cd.PNS_BHXH_CHEDO_CB(b_so_the);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_CHEDO_LKE(string b_so_the, string b_hoten, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_BHXH_CHEDO_LKE(b_so_the, b_hoten, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_CHEDO_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_cd.PNS_BHXH_CHEDO_CT(b_so_id);

            bang.P_SO_CNG(ref b_dt, "tungay_cd,denngay_cd,ngay_denghi_huong_cd,ngay_sinhcon_cd,ngay_gquyet_truoc_cd,ngay_dilam_lai_ts,tungay_ts," +
                                    "denngay_ts,ngay_denghi_huong_ts,ngay_sinh_con_ts,ngay_con_chet_ts,ngaynhan_connuoi_ts,ngaynhan_con_mth_ts,ngay_me_chet_ts,ngay_ketluat_ts," +
                                    "ngay_gquyet_truoc_ts,ngay_dilam_lai_phsk,tungay_phsk,denngay_phsk,ngay_denghi_huong_phsk,ngay_giamdinh_phsk,ngay_gquyet_truoc_phsk");
            bang.P_SO_CTH(ref b_dt, "thang_nam_gquyet_cd,thang_nam_bsung_cd,thang_nam_gquyet_ts,thang_nam_bsung_ts,thang_nam_gquyet_phsk,thang_nam_bsung_phsk");
            bang.P_SO_CSO(ref b_dt, "tong_so_ngay_cd,so_con_biom_cd,tong_so_ngay_ts,tuoithai_ts,socon_ts,socon_thai_chet_ts,phi_giamdinh_ts,tong_so_ngay_phsk,tyle_suygiam_phsk");
             
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_HINHTHUC_NHAN", "hinhthuc_nhan");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_DIEUKIEN_LV_CD", "dieukien_lv_cd");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_TUYEN_BV_CD", "tuyen_bv_cd");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_PHUONG_AN_CD", "phuong_an_cd");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_TH_HUONG_THAISAN_TS", "th_huong_thaisan_ts");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_DIEUKIEN_KHAMTHAI_TS", "dieukien_khamthai_ts");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_DIEUKIEN_SINHCON_TS", "dieukien_sinhcon_ts");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_PHUONG_AN_TS", "phuong_an_ts");
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_MANGTHAI_HO_TS", "mangthai_ho_ts"); 
            bang.P_TIM_THEM(ref b_dt, "ns_bhxh_chedo", "DT_PHUONG_AN_PHSK", "phuong_an_phsk"); 



            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_CHEDO_NH(string b_so_id, double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "tungay_cd,denngay_cd,ngay_denghi_huong_cd,ngay_sinhcon_cd,ngay_gquyet_truoc_cd,ngay_dilam_lai_ts,tungay_ts," +
                                    "denngay_ts,ngay_denghi_huong_ts,ngay_sinh_con_ts,ngay_con_chet_ts,ngaynhan_connuoi_ts,ngaynhan_con_mth_ts,ngay_me_chet_ts,ngay_ketluat_ts," +
                                    "ngay_gquyet_truoc_ts,ngay_dilam_lai_phsk,tungay_phsk,denngay_phsk,ngay_denghi_huong_phsk,ngay_giamdinh_phsk,ngay_gquyet_truoc_phsk");
            bang.P_CTH_SO(ref b_dt, "thang_nam_gquyet_cd,thang_nam_bsung_cd,thang_nam_gquyet_ts,thang_nam_bsung_ts,thang_nam_gquyet_phsk,thang_nam_bsung_phsk");
            bang.P_CSO_SO(ref b_dt, "tong_so_ngay_cd,so_con_biom_cd,tong_so_ngay_ts,tuoithai_ts,socon_ts,socon_thai_chet_ts,phi_giamdinh_ts,tong_so_ngay_phsk,tyle_suygiam_phsk");

            ns_cd.P_NS_BHXH_CHEDO_NH(b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_BHXH_CHEDO, TEN_BANG.NS_BHXH_CHEDO);

            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_BHXH_CHEDO_XOA(string b_so_id, string b_so_the, string b_hoten, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_cd.P_NS_BHXH_CHEDO_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_BHXH_CHEDO, TEN_BANG.NS_BHXH_CHEDO);
            return Fs_NS_BHXH_CHEDO_LKE(b_so_the, b_hoten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHẾ ĐỘ BẢO HIỂM

    #region KHAI BÁO ĐÓNG MỚI
    [WebMethod(true)]
    public string Fs_NS_KHAIBAO_DM_LKE(string b_phong, string b_thang_hd, string b_hoten, string b_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.FS_NS_KHAIBAO_DM_LKE(b_phong, b_thang_hd, b_hoten, b_tinhtrang, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "luongbh");
            bang.P_SO_CNG(ref b_dt, "ngayhl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHAIBAO_DM_NH(string b_phong, string b_thangbd, string b_hoten, string b_tinhtrang, double b_trangKT, double[] a_tso, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_grid)
    {
        try
        {
            string so_the = "";
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] a_gtri = (object[])a_dt_grid[1];
            string thang_bd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[1])[0];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt_ct, "CHON", "");
            bang.P_THEM_COL(ref b_dt_ct, "thang_bd", thang_bd); bang.P_CTH_SO(ref b_dt_ct, "thang_bd");
            if (b_dt_ct.Rows.Count <= 0) { return "loi:Chưa chọn bản ghi trên lưới.:loi"; }


            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows.Count <= 0) { return "loi:Chưa chọn bản ghi trên lưới.:loi"; }
                // validate thang bien dong
                string Thangbd = "Tháng biến động";
                if (skhac.CheckMonthYear(b_dt_ct.Rows[i]["thang_bd"].ToString(), ref Thangbd) == false)
                {
                    return Thangbd;
                }
            }

            bool b_check = ns_cd.Fdt_NS_KHAIBAO_CHECK_DATA(b_dt_ct, ref so_the);
            if (b_check)
            {
                //return "loi:Tháng biến động phải lớn hơn ngày bắt đầu hợp đồng của nhân viên " + so_the + ":loi";
                return "loi:Tháng biến động phải lớn hơn ngày bắt đầu hợp đồng của nhân viên :loi";
            }
            ns_cd.Fs_NS_KHAIBAO_DM_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_KHAIBAO_DM, TEN_BANG.NS_KHAIBAO_DM);
            return Fs_NS_KHAIBAO_DM_LKE(b_phong, b_thangbd, b_hoten, b_tinhtrang, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KHAIBAO_DM_XOA(string b_phong, string b_thangbd, string b_hoten, string b_tinhtrang, object[] a_dt_grid, double[] a_tso, string[] a_cot)
    {
        try
        {
            string[] cot = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] gtri = (object[])a_dt_grid[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(cot, gtri); bang.P_THEM_COL(ref b_dt_ct, "thang_bd", "");
            ns_cd.Fs_NS_KHAIBAO_DM_XOA(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_KHAIBAO_DM, TEN_BANG.NS_KHAIBAO_DM);
            return Fs_NS_KHAIBAO_DM_LKE(b_phong, b_thangbd, b_hoten, b_tinhtrang, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KHAI BÁO ĐÓNG MỚI

    #region BIẾN ĐỘNG BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_LKE(string b_so_the, string b_hoten, string b_phong, string b_thangd, string b_thangc, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            if (b_thangd != "")
            {
                string Thang_bd = "Tháng biến động từ";
                if (skhac.CheckYearMonth(b_thangd, ref Thang_bd) == false)
                {
                    return Thang_bd;
                }
            }
            if (b_thangc != "")
            {
                string Thang_bd = "Tháng biến động đến";
                if (skhac.CheckYearMonth(b_thangc, ref Thang_bd) == false)
                {
                    return Thang_bd;
                }
            }
            object[] a_object = ns_cd.Fdt_NS_BIENDONG_BH_LKE(b_so_the, b_hoten, b_phong, b_thangd, b_thangc, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_MA(string b_so_id, string b_so_the, string b_hoten, string b_phong, string b_thangd, string b_thangc, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_BIENDONG_BH_MA(b_so_id, b_so_the, b_hoten, b_phong, b_thangd, b_thangc, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_NH(string b_so_id, string b_so_the, string b_hoten, string b_phong, string b_thangd, string b_thangc, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CTH_SO(ref b_dt_ct, "thang_bd");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_hl,ngaytra_bhxh,ngaytra_bhyt,ngay_truythu_d,ngay_truythu_c,ngay_thoaithu_d,ngay_thoaithu_c");
            ns_cd.P_NS_BIENDONG_BH_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_BIENDONG_BH, TEN_BANG.NS_BIENDONG_BH);
            //return Fs_NS_BIENDONG_BH_LKE(a_tso, a_cot_lke);
            return Fs_NS_BIENDONG_BH_MA(b_so_id, b_so_the, b_hoten, b_phong, b_thangd, b_thangc, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_CHECKTHU(object[] a_dt_ct, string[] a_cot, int status_tt)
    {
        try
        {
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot1, a_gtri);
            // lấy tỷ lệ đóng bảo hiểm xã hội.
            DataTable b_dt = ns_cd.Fdt_MA_TILE_DONG_BH();

            if (b_dt.Rows.Count >= 0)
            {
                string b_tungay = "", b_denngay = "", b_luongc = b_dt_ct.Rows[0]["luong_c"].ToString(), b_luongm = b_dt_ct.Rows[0]["luong_m"].ToString();
                double b_luong = 0;
                if (status_tt == 1)
                {
                    // trường hợp truy thu
                    b_tungay = b_dt_ct.Rows[0]["ngay_truythu_d"].ToString(); b_denngay = b_dt_ct.Rows[0]["ngay_truythu_c"].ToString();
                    b_luong = chuyen.CSO_SO(b_luongm) - chuyen.CSO_SO(b_luongc);
                }
                else
                {
                    // trường hợp thoái thu
                    b_tungay = b_dt_ct.Rows[0]["ngay_thoaithu_d"].ToString(); b_denngay = b_dt_ct.Rows[0]["ngay_thoaithu_c"].ToString();
                    b_luong = chuyen.CSO_SO(b_luongc) - chuyen.CSO_SO(b_luongm);
                }
                if (b_tungay != "" && b_denngay != "")
                {
                    if (b_tungay.Length == 10 && b_denngay.Length == 10)
                    {
                        string thangd = "", thangc = "", b_tiento_thangd = "", b_tiento_thangc = "";
                        double day_tungay = chuyen.CSO_SO(b_tungay.Substring(0, 2)), thang_tungay = chuyen.CSO_SO(b_tungay.Substring(3, 2)), nam_tungay = chuyen.CSO_SO(b_tungay.Substring(6, 4));
                        double day_denngay = chuyen.CSO_SO(b_denngay.Substring(0, 2)), thang_denngay = chuyen.CSO_SO(b_denngay.Substring(3, 2)), nam_denngay = chuyen.CSO_SO(b_denngay.Substring(6, 4)); ;
                        // nếu trường hợp tháng nhỏ hơn 10 thì phải thêm số 0 phía trước của tháng.
                        if (thang_tungay < 10) b_tiento_thangd = "0"; else b_tiento_thangd = "";
                        if (thang_denngay < 10) b_tiento_thangc = "0"; else b_tiento_thangc = "";
                        // nếu ngày > 15 thì biến động vào tháng sau 
                        if (day_tungay > 15)
                        {
                            if (thang_tungay == 12) thangd = nam_tungay + 1 + "01"; else thangd = nam_tungay.ToString() + b_tiento_thangd + (thang_tungay + 1);
                        }
                        else thangd = nam_tungay.ToString() + b_tiento_thangd + thang_tungay;

                        if (day_denngay > 15)
                        {
                            if (thang_denngay == 12) thangc = nam_denngay + 1 + "01"; else thangc = nam_denngay.ToString() + b_tiento_thangc + (thang_denngay + 1).ToString();
                        }
                        else thangc = nam_denngay.ToString() + b_tiento_thangc + thang_denngay;

                        double b_bhxh = b_luong * (chuyen.CSO_SO(b_dt.Rows[0]["NV_BHXH"].ToString()) / 100) * ((chuyen.CSO_SO(thangc.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangc.Substring(4, 2))) - (chuyen.CSO_SO(thangd.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangd.Substring(4, 2)))),
                               b_bhyt = b_luong * (chuyen.CSO_SO(b_dt.Rows[0]["NV_BHYT"].ToString()) / 100) * ((chuyen.CSO_SO(thangc.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangc.Substring(4, 2))) - (chuyen.CSO_SO(thangd.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangd.Substring(4, 2)))),
                               b_bhtn = b_luong * (chuyen.CSO_SO(b_dt.Rows[0]["NV_BHTN"].ToString()) / 100) * ((chuyen.CSO_SO(thangc.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangc.Substring(4, 2))) - (chuyen.CSO_SO(thangd.Substring(0, 4)) * 12 + chuyen.CSO_SO(thangd.Substring(4, 2))));
                        return b_bhxh + "#" + b_bhyt + "#" + b_bhtn;
                    }
                    else { return "loi:Từ ngày hoặc đến ngày nhập sai định dạng:loi"; }
                }
                return null;
            }
            return null;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_XOA(string b_so_id, string b_so_the, string b_hoten, string b_phong, string b_thangd, string b_thangc, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_cd.P_NS_BIENDONG_BH_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_BIENDONG_BH, TEN_BANG.NS_BIENDONG_BH);
            return Fs_NS_BIENDONG_BH_LKE(b_so_the, b_hoten, b_phong, b_thangd, b_thangc, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BIENDONG_BH_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_cd.Fdt_NS_BIENDONG_CT(b_so_id);
            bang.P_SO_CTH(ref b_dt, "thang_bd");
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngaytra_bhxh,ngaytra_bhyt,ngay_truythu_d,ngay_truythu_c,ngay_thoaithu_d,ngay_thoaithu_c");
            bang.P_TIM_THEM(ref b_dt, "ns_biendong_bh", "DT_LOAI_BD", "LOAI_BD");
            bang.P_TIM_THEM(ref b_dt, "ns_biendong_bh", "DT_PHUONG_AN", "PHUONG_AN");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region THÔNG TIN BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_TT_BH_LKE(double[] a_tso, string[] a_cot, string b_phong, string b_so_the, string b_ten, string b_nghiviec)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_TT_BH_LKE(b_phong, b_so_the, b_ten, b_nghiviec, b_tu_n, b_den_n);

            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CTH(ref b_dt, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_SO_CNG(ref b_dt, "ngay_cap,ngay_hl,ngay_bangiaothe");
            bang.P_SO_CSO(ref b_dt, "luong_bh,tg_dongbh_truoc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TT_BH_MA(string b_so_id, string b_phong, string b_so_the, string b_ho_ten, string b_nghiviec, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_TT_BH_MA(b_so_id, b_phong, b_so_the, b_ho_ten, b_nghiviec, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CTH(ref b_dt, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_SO_CNG(ref b_dt, "ngay_cap,ngay_hl,ngay_bangiaothe");
            bang.P_SO_CSO(ref b_dt, "luong_bh,tg_dongbh_truoc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TT_BH_NH(string b_so_id, string b_phong, string b_so_the, string b_ten, string b_nghiviec, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CTH_SO(ref b_dt_ct, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_cap,ngay_hl,ngay_bangiaothe");
            bang.P_CSO_SO(ref b_dt_ct, "luong_bh,tg_dongbh_truoc");
            ns_cd.P_NS_TT_BH_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            //return Fs_NS_TT_BH_LKE(a_tso, a_cot_lke, b_so_the, b_ten, b_nghiviec);
            return Fs_NS_TT_BH_MA(b_so_id, b_phong, b_so_the, b_ten, b_nghiviec, b_trangKT, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TT_BH_XOA(string b_phong, string b_so_id, string b_so_the_tk, string b_ten, string b_nghiviec, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_cd.P_NS_TT_BH_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            return Fs_NS_TT_BH_LKE(a_tso, a_cot, b_phong, b_so_the_tk, b_ten, b_nghiviec);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TT_BH_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_cd.Fdt_NS_TT_BH_CT(b_so_the);
            bang.P_SO_CTH(ref b_dt, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_SO_CNG(ref b_dt, "ngay_cap,ngay_hl,ngay_bangiaothe"); 
            bang.P_SO_CSO(ref b_dt, "luong_bh,tg_dongbh_truoc");
            bang.P_THAY_GTRI(ref b_dt, "tuthang_bhxh", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt, "denthang_bhxh", "01/3000", "");
            bang.P_THAY_GTRI(ref b_dt, "tuthang_bhyt", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt, "denthang_bhyt", "01/3000", "");
            bang.P_THAY_GTRI(ref b_dt, "tuthang_bhxh", "/", ""); bang.P_THAY_GTRI(ref b_dt, "denthang_bhxh", "/", "");
            bang.P_THAY_GTRI(ref b_dt, "tuthang_bhyt", "/", ""); bang.P_THAY_GTRI(ref b_dt, "denthang_bhyt", "/", "");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region QUẢN LÝ THÔNG TIN BẢO HIỂM NGƯỜI THÂN
    [WebMethod(true)]
    public string Fs_NS_BH_NGUOITHAN_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_cd.Fdt_NS_BH_NGUOITHAN_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];

            bang.P_SO_CNG(ref b_dt, "ngay_xacnhan");
            bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt_ct, "chiphi");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_NGUOITHAN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_BH_NGUOITHAN_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_xacnhan");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_NGUOITHAN_NH(string b_so_id, object[] a_dt, object[] a_dt_ct, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "hoten", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["hoten"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            bang.P_CNG_SO(ref b_dt, "ngay_xacnhan");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt_ct, "chiphi");

            ns_cd.P_NS_BH_NGUOITHAN_NH(ref b_so_id, b_dt, b_dt_ct);
            return Fs_NS_BH_NGUOITHAN_LKE(a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_NGUOITHAN_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_cd.PNS_BH_NGUOITHAN_XOA(b_so_id); return Fs_NS_BH_NGUOITHAN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THAM GIA HUẤN LUYỆN BHLĐ

    #region BẢO HIỂM XÃ HÔI QUÁ TRÌNH
    //[WebMethod(true)]
    //public string Fs_NS_BHXH_QT_HOI(string b_login, string b_so_the)
    //{
    //    try
    //    {
    //        se.P_LOGIN(b_login);
    //        DataTable b_dt = ns_cd.Fdt_NS_BHXH_QT_HOI(b_so_the);
    //        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    //    }
    //    catch (Exception ex)
    //    {

    //        return form.Fs_LOC_LOI(ex.Message );
    //    }
    //}

    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_LKE(string b_loaibh, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_BHXH_QT_LKE(b_loaibh, b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CTH(ref b_dt_tk, "thangd,thangc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_MA(string b_loaibh, string b_so_the, string b_thangd, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_BHXH_QT_MA(b_loaibh, b_so_the, b_thangd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thangd", b_thangd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_CT(string b_loaibh, string b_so_the, string b_thangd, string[] a_cot_tt)
    {
        try
        {
            DataSet b_ds = ns_cd.Fdt_NS_BHXH_QT_CT(b_loaibh, b_so_the, b_thangd);
            string b_kq_tt;
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CTH(ref b_dt, "thangd,thangc"); bang.P_SO_CNG(ref b_dt, "ngay");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_dt_tt = b_ds.Tables[1];
            if (b_dt_tt.Rows.Count == 0)
            {
                b_dt_tt = ns_cd.Fdt_NS_MA_BHXHPC_LKE_PC();
                bang.P_THEM_COL(ref b_dt_tt, "muc", "0");
            }
            b_kq_tt = bang.Fb_TRANG(b_dt_tt) ? "" : bang.Fs_BANG_CH(b_dt_tt, a_cot_tt);

            return b_kq + "#" + b_kq_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ma_loai", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "-1" });
            ns_cd.P_NS_BHXH_QT_NH(b_dt, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_thangd = mang.Fs_TEN_GTRI("thangd", a_cot, a_gtri);
            string b_loaibh = mang.Fs_TEN_GTRI("loaibh", a_cot, a_gtri);
            return Fs_NS_BHXH_QT_MA(b_loaibh, b_so_the, b_thangd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_XOA(string b_loaibh, string b_so_the, string b_thangd, double[] a_tso, string[] a_cot)
    {
        try
        { ns_cd.PNS_BHXH_QT_XOA(b_loaibh, b_so_the, b_thangd); return Fs_NS_BHXH_QT_LKE(b_loaibh, b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_BHXH_QT_CB_HOI(string b_loaibh, string b_so_the, string[] a_cot_tt)
    {
        try
        {
            DataTable b_dt = ns_cd.Fdt_NS_BHXH_HOI_CT(b_loaibh, b_so_the);
            DataTable b_dt_tt = ns_cd.Fdt_NS_MA_BHXHPC_LKE_PC();
            bang.P_THEM_COL(ref b_dt_tt, "muc", "0");
            string b_kq_tt = bang.Fb_TRANG(b_dt_tt) ? "" : bang.Fs_BANG_CH(b_dt_tt, a_cot_tt);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq + "#" + b_kq_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion BẢO HIỂM XÃ HÔI QUÁ TRÌNH

    #region MÃ CẤP ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_MA_BHXHPC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_MA_BHXHPC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BHXHPC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_MA_BHXHPC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BHXHPC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_cd.P_NS_MA_BHXHPC_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_BHXHPC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BHXHPC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_cd.P_NS_MA_BHXHPC_XOA(b_ma); return Fs_NS_MA_BHXHPC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CHẾ ĐỘ ĐI MUỘN VỀ SỚM
    [WebMethod(true)]
    public string Fs_NS_CD_DSVM_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_CD_DSVM_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CD_DSVM_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_CD_DSVM_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CD_DSVM_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_cd.PNS_CD_DSVM_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CD_DSVM_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            b_so_id = ns_cd.PNS_CD_DSVM_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_CD_DSVM_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CD_DSVM_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_cd.PNS_CD_DSVM_XOA(b_so_id); return Fs_NS_CD_DSVM_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CHẾ ĐỘ ĐI MUỘN VỀ SỚM

    #region DANH SÁCH ĐỦ ĐIỀU KIỆN HƯỞNG CMC CARE
    [WebMethod(true)]
    public string Fs_NS_DS_THAMGIA_CMCCARE_LKE(string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.FS_NS_DS_THAMGIA_CMCCARE_LKE(b_tungay, b_denngay, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_hl,ngay_hhl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DS_THAMGIA_CMCCARE_NH(string b_tungay, string b_denngay, object[] a_dt, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_BO_HANG(ref b_dt, "chon", "");
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "", "-1" });
            ns_cd.Fs_NS_DS_THAMGIA_CMCCARE_NH(b_dt);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_thangd = mang.Fs_TEN_GTRI("thangd", a_cot, a_gtri);
            string b_loaibh = mang.Fs_TEN_GTRI("loaibh", a_cot, a_gtri);
            return Fs_NS_DS_THAMGIA_CMCCARE_LKE(b_tungay, b_denngay, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion DANH SÁCH ĐỦ ĐIỀU KIỆN HƯỞNG CMC CARE

    #region QUẢN LÝ BẢO HIỂM AETNA
    [WebMethod(true)]
    public string Fs_NS_BH_AETNA_LKE(string b_sothe, string b_ten, string b_goi_bh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_Fs_BH_AETNA_LKE(b_sothe, b_ten, b_goi_bh, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "nsinh,ngay_thamgia,ngay_hl");
            bang.P_SO_CSO(ref b_dt_tk, "mucphi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_AETNA_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_thamgia,ngay_hl");
            bang.P_CSO_SO(ref b_dt, "mucphi");
            ns_cd.P_BH_AETNA_NH(b_dt);
            string b_ma = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_BH_AETNA_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_AETNA_MA(string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_BH_AETNA_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_thamgia,ngay_hl");
            bang.P_SO_CSO(ref b_dt, "mucphi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_BH_AETNA_XOA(string b_sothe, string b_goibh, string b_so_the_tk, string b_ten_tk, string b_goi_bh_tk, double[] a_tso, string[] a_cot)
    {
        try { ns_cd.P_BH_AETNA_XOA(b_sothe, b_goibh); return Fs_NS_BH_AETNA_LKE(b_so_the_tk, b_ten_tk, b_goi_bh_tk, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region QUẢN LÝ THÔNG TIN BẢO HIỂM CMC CARE
    [WebMethod(true)]
    public string Fs_NS_TT_BH_CMCCARE_LKE(string b_sothe, string b_ten, string b_goi_bh, string b_ngay_hl, string b_ngay_hhl, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_TT_BH_CMCCARE_LKE(b_sothe, b_ten, b_goi_bh, b_ngay_hl, b_ngay_hhl, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "nsinh,ngay_thamgia,ngayd");
            bang.P_SO_CSO(ref b_dt_tk, "mucphi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TT_BH_CMCCARE_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_thamgia");
            bang.P_CSO_SO(ref b_dt, "mucphi");
            ns_cd.P_NS_TT_BH_CMCCARE_NH(b_dt);
            string b_ma = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TT_BH_CMCCARE_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TT_BH_CMCCARE_MA(string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_TT_BH_CMCCARE_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_thamgia,ngayd");
            bang.P_SO_CSO(ref b_dt, "mucphi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TT_BH_CMCCARE_XOA(string b_sothe, string b_goibh, string b_so_the_tk, string b_ten_tk, string b_goi_bh_tk, string b_ngayhl, string b_ngay_hhl, double[] a_tso, string[] a_cot)
    {
        try { ns_cd.P_NS_TT_BH_CMCCARE_XOA(b_sothe, b_goibh); return Fs_NS_TT_BH_CMCCARE_LKE(b_so_the_tk, b_ten_tk, b_goi_bh_tk, b_ngayhl, b_ngay_hhl, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region QUẢN LÝ ĐIỀU CHỈNH, GIẢM BẢO HIỂM CMC CARE
    [WebMethod(true)]
    public string Fs_THONGTIN_BH_CU(string b_sothe)
    {
        var b_dt = ns_cd.Fdt_NS_THONGTIN_BH_CU(b_sothe);
        bang.P_SO_CSO(ref b_dt, "mucphi_ht");
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public string Fs_NS_QL_BH_CMCCARE_LKE(string b_sothe, string b_ten, string b_donvi, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.Fdt_NS_QL_BH_CMCCARE_LKE(b_sothe, b_ten, b_donvi, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "nsinh,ngay_hl,ngaygiam_bh");
            bang.P_SO_CSO(ref b_dt_tk, "mucphi_ht,mucphi_dc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QL_BH_CMCCARE_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_hl,ngaygiam_bh");
            bang.P_CSO_SO(ref b_dt, "mucphi_ht,mucphi_dc");
            ns_cd.P_NS_QL_BH_CMCCARE_NH(b_dt);
            string b_ma = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_QL_BH_CMCCARE_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QL_BH_CMCCARE_MA(string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cd.Fdt_NS_QL_BH_CMCCARE_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_hl,ngaygiam_bh");
            bang.P_SO_CSO(ref b_dt, "mucphi_ht,mucphi_dc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QL_BH_CMCCARE_XOA(string b_sothe, string b_goibh_ht, string b_goibh_dc, string b_ngay_hl, string b_so_the_tk, string b_ten_tk, string b_donvi_tk, double[] a_tso, string[] a_cot)
    {
        try { ns_cd.P_NS_QL_BH_CMCCARE_XOA(b_sothe, b_goibh_ht, b_goibh_dc, b_ngay_hl); return Fs_NS_QL_BH_CMCCARE_LKE(b_so_the_tk, b_ten_tk, b_donvi_tk, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region KHAI BÁO DANH SÁCH KHÔNG ĐƯỢC ĐÓNG BHXH
    [WebMethod(true)]
    public string Fs_NS_DS_KDBHXH_LKE(string b_sothe, string b_hoten, string b_nam, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cd.FS_NS_DS_KDBHXH_LKE(b_sothe, b_hoten, b_nam, b_kyluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "luongbh");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "C", "Đã xác nhận");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "K", "Chưa xác nhận");
            //bang.P_SO_CNG(ref b_dt, "ngayhl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_DS_KDBHXH_NH(string b_sothe, string b_hoten, string b_nam, string b_kyluong, double b_trangKT, double[] a_tso, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_grid)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] a_gtri = (object[])a_dt_grid[1];
            string thang_bd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[1])[0];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt_ct, "CHON", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.ChuaChonBanGhiLuoi;
            }

            ns_cd.FS_NS_DS_KDBHXH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DS_KDDK_BH, TEN_BANG.NS_DS_KDDK_BH);
            return Fs_NS_DS_KDBHXH_LKE(b_sothe, b_hoten, b_nam, b_kyluong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion
}
