using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class stl_cc : System.Web.Services.WebService
{
    #region TỔNG HỢP CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_TH_LKE_COT(string b_login)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_TH_LKE_COT();
            DataTable b_dt2 = tl_cc.Fdt_NS_CC_TH_LKE_COT_STYLE();
            //string a_cot = "SOTT|STT;SO_THE_CB|Mã nhân viên;TEN|Tên nhân viên;PHONG|Phòng ban;CDANH|Chức danh;" + bang.Fs_BANG_CH(b_dt);
            //return a_cot;
            string a_cot = bang.Fs_BANG_CH(b_dt) + "#" + bang.Fs_BANG_CH(b_dt2);
            return a_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_KYLUONG_LKE(string b_login, double b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_th", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KYLUONG_CHUNG_LKE(string b_login, int b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_th", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KYLUONG_CHUNG2_LKE(string b_login, string b_form, double b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU(b_form, "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_KYLUONG_LKE(string b_login, int b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("tl_luong_imp", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_KYLUONG_GL_LKE(string b_login, int b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("tl_giuluong", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_LKE(string b_login, string b_phong, double b_kyluong, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_TH_LKE(b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_vao,ngayd,ngayc");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong.ToString());
            return b_kq + "#" + a_obj[0] + "#" + tt;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_TINH(string b_login, string b_phong, string b_kyluong, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);

            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1") return Thongbao_dch.KY_CONG_KHOA;

            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_TH_TINH(b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_TH, TEN_BANG.NS_CC_TH);
            DataTable b_dt = (DataTable)a_obj[1];

            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : a_obj[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_MO(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG(b_phong, b_kyluong_id);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_DADONG;
            ht_dungchung.P_NS_CC_TONGHOP_MO(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.MO_CC, TEN_FORM.NS_CC_TH, TEN_BANG.NS_CC_TH);

            return Thongbao_dch.KY_CONG_MO;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_DONG(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            ht_dungchung.P_NS_CC_TONGHOP_DONG(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_CC, TEN_FORM.NS_CC_TH, TEN_BANG.NS_CC_TH);
            return Thongbao_dch.KY_CONG_DONG;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    #endregion

    #region BẢNG CÔNG ĐỐI TƯỢNG THỰC TẬP SINH
    [WebMethod(true)]
    public string Fs_NS_CC_TH_TTS_LKE(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_TH_TTS_LKE(b_nam, b_kyluong_id, b_sothe, b_phong, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_TTS_TH(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_TH_TTS, TEN_BANG.NS_CC_TH_TTS);
            tl_cc.Fs_NS_CC_TH_TTS_TH(b_phong, b_kyluong_id, b_sothe);
            return Fs_NS_CC_TH_TTS_LKE(b_login, b_nam, b_kyluong_id, b_sothe, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion BẢNG CÔNG ĐỐI TƯỢNG THỰC TẬP SINH

    #region CHẤM CÔNG CÔNG NHẬT CHI TIẾT

    [WebMethod(true)]
    public string Fs_TL_PHANCA_LKE(string b_login, string b_loai, string b_thang, string b_ngayd, string b_phong, string[] a_cot_gt)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_TL_PHANCA_LKE(b_loai, b_thang, b_ngayd, b_phong);
            string b_dt = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                b_tt = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[2], 0),
                b_dt_ngay = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_gt),
                b_t7 = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["t7"].ToString(),
                b_cn = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["cn"].ToString();
            return b_dt + "#" + b_dt_ngay + "#" + b_t7 + "#" + b_cn + "#" + b_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_TEM_NGAY_LKE(string b_login, string b_loai, string b_thang, string b_ngayd, string b_phong, string[] a_cot_gt)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataSet b_ds = tl_cc.Fdt_TEM_NGAY_LKE(b_loai, b_thang, b_ngayd, b_phong);
            var b_dt2 = b_ds.Tables[0];
            bang.P_TIM_THEM(ref b_dt2, "tl_phanca", "DT_KY", "KYLUONG");
            bang.P_TIM_THEM(ref b_dt2, "tl_phanca", "DT_PHONG_TK", "PHONG");
            string b_dt = bang.Fb_TRANG(b_dt2) ? "" : bang.Fs_HANG_GOP(b_dt2, 0),
                b_tt = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[2], 0),
                b_dt_ngay = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_gt),
                b_t7 = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["t7"].ToString(),
                b_cn = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["cn"].ToString();
            return b_dt + "#" + b_dt_ngay + "#" + b_t7 + "#" + b_cn + "#" + b_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_CT_TEM_NGAY_LKE(string b_login, string b_loai, string b_thang, string b_ngayd, string b_phong, string[] a_cot_gt)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataSet b_ds = tl_cc.Fdt_TEM_NGAY_CC_CN_CT_LKE(b_loai, b_thang, b_ngayd, b_phong);
            var b_dt2 = b_ds.Tables[0];
            bang.P_TIM_THEM(ref b_dt2, "cc_cn_ct", "DT_KY", "KYLUONG");
            bang.P_TIM_THEM(ref b_dt2, "cc_cn_ct", "DT_PHONG_TK", "PHONG");
            string b_dt = bang.Fb_TRANG(b_dt2) ? "" : bang.Fs_HANG_GOP(b_dt2, 0),
                b_tt = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[2], 0),
                b_dt_ngay = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_gt),
                b_t7 = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["t7"].ToString(),
                b_cn = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["cn"].ToString();
            return b_dt + "#" + b_dt_ngay + "#" + b_t7 + "#" + b_cn + "#" + b_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TEM_NGAY_NAGASE_LKE(string b_thang, string b_ngayd, string b_phong, string[] a_cot_gt)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_TEM_NGAY_NAGASE_LKE(b_thang, b_ngayd, b_phong);
            string b_dt = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                b_dt_ngay = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_gt),
                b_t7 = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["t7"].ToString(),
                b_cn = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : b_ds.Tables[0].Rows[0]["cn"].ToString();
            return b_dt + "#" + b_dt_ngay + "#" + b_t7 + "#" + b_cn;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_PHANCA_KYLUONG_LKE(string b_login, string b_loai, int b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            if (b_loai == "CU") se.P_TG_LUU("tl_phanca", "DT_KY_CU", b_dt_ky.Copy());
            else se.P_TG_LUU("tl_phanca", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "so_id,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DANHSACH_KYLUONG_LKE(string b_login, string b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("tl_phanca", "DT_KY", b_dt_ky);
            return bang.Fs_BANG_CH(b_dt, "ma,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_CT_KYLUONG_LKE(string b_login, string b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("cc_cn_ct", "DT_KY", b_dt_ky);
            return bang.Fs_BANG_CH(b_dt, "ma,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DANHSACH_KYLUONG_LT_LKE(string b_login, string b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_tonghop_lthem", "DT_KY", b_dt_ky);
            return bang.Fs_BANG_CH(b_dt, "ma,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_CT_CT(string b_login, string b_phong, string b_sothe, double b_kyluong_id, string[] a_cot_cc, double[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_CN_CT_CT(b_phong, b_sothe, b_kyluong_id, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_XEP(ref b_dt, "so_the");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc),
                   b_t7 = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["t7"].ToString(),
                   b_cn = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["cn"].ToString();
            return b_dt_ct + "#" + b_dt_cc + "#" + b_t7 + "#" + b_cn + "#" + b_dt.Rows.Count + "#" + chuyen.OBJ_S(a_obj[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_CN_CT_NH(string b_login, object[] a_dt, object[] a_dt_cc, string b_t7, string b_cn)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc); bang.P_THEM_COL(ref b_dt_cc, new string[] { "cong", "anca" });
            bang.P_BO_HANG(ref b_dt_cc, "so_the", "");
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt, new string[] { "t7", "cn" }, new object[] { b_t7, b_cn });
            DateTime b_dayd = chuyen.CNG_NG(b_dt.Rows[0]["ngayd"].ToString());
            DateTime b_ngay_backup = b_dayd;
            DateTime b_dayc = chuyen.CNG_NG(b_dt.Rows[0]["ngaykt"].ToString());
            var b_day = (b_dayc - b_dayd).TotalDays + 1;
            DataTable b_kycong = tl_ma.Fdt_TL_MA_KYLUONG_BY_ID(chuyen.OBJ_N(b_dt.Rows[0]["KYLUONG"].ToString()));
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_dt.Rows[0]["phong"].ToString(), b_dt.Rows[0]["KYLUONG"].ToString());
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            bang.P_CNG_SO(ref b_dt, "ngayd"); bang.P_THEM_COL(ref b_dt, "THANGCC", b_kycong.Rows[0]["THANGCC"].ToString());
            DataTable b_maca2 = stl_cc.PNS_MA_CC_DR2();
            for (int i = 0; i < b_dt_cc.Rows.Count; i++)
            {
                for (int j = 2; j < b_dt_cc.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(b_dt_cc.Rows[i][j].ToString()))
                    {
                        DataRow[] row = b_maca2.Select("MA = '" + b_dt_cc.Rows[i][j].ToString() + "'");
                        if (row.Length > 0)
                        {
                            return "loi:Mã công " + b_dt_cc.Rows[i][j].ToString() + " đã ngừng áp dụng, không thể sử dụng :loi";
                        }
                    }
                }
            }
            DataTable b_macc = stl_cc.PNS_MA_CC_DR();
            for (int i = 0; i < b_dt_cc.Rows.Count; i++)
            {
                for (int j = 3; j < 34; j++)
                {
                    if (!string.IsNullOrEmpty(b_dt_cc.Rows[i][j].ToString()))
                    {
                        DataRow[] row = b_macc.Select("MA = '" + b_dt_cc.Rows[i][j].ToString() + "'");
                        if (row.Length <= 0)
                        {
                            return "loi:Mã công " + b_dt_cc.Rows[i][j].ToString() + " chưa đăng ký :loi";
                        }
                    }
                }
            }
            DataTable b_nv = ht_dungchung.Fdt_DS_NHANVIEN_LV(b_dt.Rows[0]["phong"].ToString(), chuyen.OBJ_N(b_dt.Rows[0]["kyluong"]));
            bang.P_SO_CNG(ref b_nv, "ngay_vao");
            for (int i = 0; i < b_nv.Rows.Count; i++)
            {
                DataRow[] row = b_dt_cc.Select("so_the = '" + b_nv.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    for (int k = 0; k < chuyen.OBJ_N(b_nv.Rows[i]["ngayd"].ToString()); k++)
                    {
                        if (!string.IsNullOrEmpty(row[0][k + 2].ToString()))
                        {
                            return "loi:Không thể xếp mã công nhỏ hơn ngày vào(" + b_nv.Rows[i]["ngay_vao"].ToString() + ") của nhân viên " + b_nv.Rows[i]["so_the"] + ":loi";
                        }
                    }
                }
            }
            DataTable b_nghiviec = ht_dungchung.Fdt_DS_NHANVIEN_NV_TT(b_dt.Rows[0]["phong"].ToString(), chuyen.OBJ_N(b_dt.Rows[0]["kyluong"]));
            bang.P_SO_CNG(ref b_nghiviec, "ngay_nghi_tt");
            for (int i = 0; i < b_nghiviec.Rows.Count; i++)
            {
                DataRow[] row = b_dt_cc.Select("so_the = '" + b_nghiviec.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    int k = chuyen.OBJ_I(b_nghiviec.Rows[i]["ngay_nghi"].ToString());
                    b_dayd = b_ngay_backup;
                    for (int j = 1; j < b_day; j++)
                    {
                        if (chuyen.OBJ_I((b_dayd.Month.ToString() + (b_dayd.Day < 10 ? "0" + b_dayd.Day.ToString() : b_dayd.Day.ToString()))) >= k)
                        {
                            if (!string.IsNullOrEmpty(row[0][j + 2].ToString()))
                            {
                                return "loi:Không thể xếp ca làm việc lớn hơn ngày nghỉ việc (" + b_nghiviec.Rows[i]["ngay_nghi_tt"].ToString() + ") của nhân viên " + b_nghiviec.Rows[i]["so_the"] + ":loi";
                            }
                        }
                        b_dayd = b_dayd.AddDays(1);
                    }
                }
            }
            tl_cc.PCC_CN_CT_NH(b_dt, b_dt_cc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CC_CN_CT, TEN_BANG.CC_CN_CT);
            DataRow b_dr_nghiphep = b_dt.Rows[0];
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_CN_CT_XOA(string b_login, string b_phong, string b_sothe, string b_thang, string b_ngay)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_thang);
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            tl_cc.PCC_CN_CT_XOA(b_phong, b_sothe, b_thang, b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CC_CN_CT, TEN_BANG.CC_CN_CT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_CT_LKE_CB(string b_login, string b_sothe, string b_phong, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Fdt_CC_CN_CT_LKE_CB(b_phong, b_sothe);
            DataTable b_dt = (DataTable)a_obj[1];
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_FILE(string b_login, string b_ten, string[] a_cot)
    {
        try
        {
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            string b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_cc + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    //[WebMethod(true)]
    //public string Fs_FILE_HAL(string b_ten, string[] a_cot)
    //{
    //    try
    //    {
    //        DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
    //        bang.P_BO_HANG(ref b_dt, "exception", "Repeat");
    //        string b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
    //        return b_dt_cc + "#" + b_dt.Rows.Count;
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    [WebMethod(true)]
    public string Fs_FILE_NAGASE(string b_ten, string[] a_cot)
    {
        string b_loi = "";
        try
        {
            b_loi = "loi:di toi o day 1:loi";
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            bang.P_DOI_TENCOL(ref b_dt, new string[] { "ID", "Name", "Date", "Attendance", "Leaving", "Work Time", "Late IN", "Early OUT", "Department" }, new string[] { "id_cc", "ten", "ngay_cc", "giovao", "giove", "time_lam", "dimuon", "vesom", "noi_lv" });
            bang.P_OBJ_CH(ref b_dt, new string[] { "giovao", "giove", "time_lam" });
            bang_replace(ref b_dt, "id_cc", " (None)", "");
            bang_replace(ref b_dt, "giovao", "30/12/1899 ", "");
            bang_replace(ref b_dt, "giovao", "12/30/1899 ", "");
            bang_replace(ref b_dt, "giovao", "31/12/1899 ", "");
            bang_replace(ref b_dt, "giovao", "12/31/1899 ", "");
            bang_replace(ref b_dt, "giove", "30/12/1899 ", "");
            bang_replace(ref b_dt, "giove", "12/30/1899 ", "");
            bang_replace(ref b_dt, "giove", "31/12/1899 ", "");
            bang_replace(ref b_dt, "giove", "12/31/1899 ", "");
            bang_replace(ref b_dt, "time_lam", "30/12/1899 ", "");
            bang_replace(ref b_dt, "time_lam", "12/30/1899 ", "");
            bang_replace(ref b_dt, "time_lam", "31/12/1899 ", "");
            bang_replace(ref b_dt, "time_lam", "12/31/1899 ", "");
            bang_replace(ref b_dt, "time_lam", " AM", "");
            bang_replace(ref b_dt, "time_lam", " PM", "");
            bang_replace(ref b_dt, "dimuon", "--", "");
            bang_replace(ref b_dt, "vesom", "--", "");
            bang_replace(ref b_dt, "giovao", "--", "");
            bang_replace(ref b_dt, "giove", "--", "");
            bang_replace(ref b_dt, "time_lam", "--", "");
            string b_gtr_cu = "", b_ngay_cc_thu = "";
            string b_ngay = "", b_thang = "", b_nam = "", b_ngay_cc_th = "", b_dimuon_gb = "", b_vesom_gb = "";
            double b_gio_s = 0, b_phut_s = 0, b_thoigian_vesom = 0;
            double b_gio_m = 0, b_phut_m = 0, b_thoigian_dimuon = 0, b_themgio = 0;
            double b_tong_time = 0, b_gio_tong = 0, b_phut_tong = 0;
            int b_tu = 0;
            b_loi = "loi:di toi o day 2:loi";
            bang.P_THEM_COL(ref b_dt, new string[] { "ngay_cc_thu", "ngay", "thang", "nam", "ngay_cc_th", "dimuon_gb", "vesom_gb", "thoigian_vesom", "thoigian_dimuon", "themgio", "tong_time" }, new object[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" });
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_loi = "loi:di toi o day 3 - " + i.ToString() + ":loi";

                b_gtr_cu = b_dt.Rows[i]["ngay_cc"].ToString();
                // lấy thứ
                b_tu = b_gtr_cu.IndexOf("(");
                b_ngay_cc_thu = b_gtr_cu.Substring(b_tu + 1, 3);
                // lấy tháng chấm công
                b_tu = b_gtr_cu.IndexOf("/");
                b_thang = b_gtr_cu.Substring(0, b_tu);
                if (Convert.ToInt32(b_thang) < 10) b_thang = "0" + b_thang;
                b_gtr_cu = b_gtr_cu.Substring(b_tu + 1, b_gtr_cu.Length - b_tu - 1);
                b_tu = b_gtr_cu.IndexOf("/");
                b_ngay = b_gtr_cu.Substring(0, b_tu);
                if (Convert.ToInt32(b_ngay) < 10) b_ngay = "0" + b_ngay;
                b_gtr_cu = b_gtr_cu.Substring(b_tu + 1, b_gtr_cu.Length - b_tu - 1);
                b_nam = b_gtr_cu.Substring(0, 4);
                b_ngay_cc_th = b_nam + b_thang + b_ngay;
                // lấy giờ vào và giờ ra good bad
                b_gtr_cu = b_dt.Rows[i]["dimuon"].ToString();
                b_loi = "loi:di toi o day 4 - " + i.ToString() + ":loi";
                if (b_gtr_cu != "" && b_gtr_cu != "--" && b_gtr_cu != " ")
                {
                    b_loi = "loi:di toi o day 5 - " + i.ToString() + ":loi";
                    b_dimuon_gb = b_gtr_cu.Substring(b_gtr_cu.Length - 4, 4);
                    b_dimuon_gb = b_dimuon_gb.Replace(" ", "");
                    b_gtr_cu = b_gtr_cu.Replace("(", "");
                    b_gtr_cu = b_gtr_cu.Replace(")", "");
                    b_gtr_cu = b_gtr_cu.Replace("+", "");
                    b_gtr_cu = b_gtr_cu.Replace("-", "");
                    b_gio_m = Convert.ToInt32(b_gtr_cu.Substring(0, 2));
                    b_gtr_cu = b_gtr_cu.Substring(3, b_gtr_cu.Length - 3);
                    b_phut_m = Convert.ToInt32(b_gtr_cu.Substring(0, 2));
                    b_phut_m = Math.Round(b_phut_m / 60, 2);
                    b_thoigian_dimuon = b_gio_m + b_phut_m;
                }
                b_loi = "loi:di toi o day 6 - " + i.ToString() + ":loi";
                b_gtr_cu = b_dt.Rows[i]["vesom"].ToString();
                if (b_gtr_cu != "" && b_gtr_cu != "--" && b_gtr_cu != " ")
                {
                    b_loi = "loi:di toi o day 7 - " + i.ToString() + ":loi";
                    b_vesom_gb = b_gtr_cu.Substring(b_gtr_cu.Length - 4, 4);
                    b_vesom_gb = b_vesom_gb.Replace(" ", "");
                    b_gtr_cu = b_gtr_cu.Replace("(", "");
                    b_gtr_cu = b_gtr_cu.Replace(")", "");
                    b_gtr_cu = b_gtr_cu.Replace("+", "");
                    b_gtr_cu = b_gtr_cu.Replace("-", "");
                    b_gio_s = Convert.ToInt32(b_gtr_cu.Substring(0, 2));
                    b_gtr_cu = b_gtr_cu.Substring(3, b_gtr_cu.Length - 3);
                    b_phut_s = Convert.ToInt32(b_gtr_cu.Substring(0, 2));
                    b_phut_s = Math.Round(b_phut_s / 60, 2);
                    b_thoigian_vesom = b_gio_s + b_phut_s;
                    // tính thời gian làm thêm giờ, chỉ tính sau thơi gian làm việc 15 phút (0.25 giờ) vậy nếu về sớm là Good và > 0.25 thì là làm thêm giờ
                    b_themgio = b_thoigian_vesom - 0.25;
                    b_loi = "loi:di toi o day 8 - " + i.ToString() + ":loi";
                }
                // đối với làm thêm ngày lễ và cuối tuần thì sẽ được tính trong data (điều kiện là ngày nghỉ (sat,sun) hoặc ngày lễ và tổng thời gian làm > 0.25)
                b_loi = "loi:di toi o day 9 - " + i.ToString() + ":loi";
                b_gtr_cu = b_dt.Rows[i]["time_lam"].ToString();
                if (b_gtr_cu != "" && b_gtr_cu != "--" && b_gtr_cu != " ")
                {
                    b_loi = "loi:di toi o day 10 - " + i.ToString() + ":loi";
                    b_tu = b_gtr_cu.IndexOf(":");
                    b_loi = "loi:di toi o day 1 10 - " + i.ToString() + "- " + b_gtr_cu.ToString() + " - " + b_tu.ToString() + ":loi";
                    b_gio_tong = Convert.ToInt32(b_gtr_cu.Substring(0, b_tu));
                    b_loi = "loi:di toi o day 2 10 - " + i.ToString() + ":loi";
                    b_gtr_cu = b_gtr_cu.Substring(b_tu + 1, b_gtr_cu.Length - b_tu - 1);
                    b_loi = "loi:di toi o day 3 10 - " + i.ToString() + ":loi";
                    b_phut_tong = Convert.ToInt32(b_gtr_cu.Substring(0, 2));
                    b_loi = "loi:di toi o day 4 10 - " + i.ToString() + ":loi";
                    b_phut_tong = Math.Round(b_phut_tong / 60, 2);
                    b_loi = "loi:di toi o day 5 10 - " + i.ToString() + ":loi";
                    b_tong_time = b_gio_tong + b_phut_tong;
                    b_loi = "loi:di toi o day 6 10 - " + i.ToString() + ":loi";
                }
                b_loi = "loi:di toi o day 11 - " + i.ToString() + ":loi";
                bang.P_DAT_GTRI(ref b_dt, new string[] { "ngay_cc_thu", "ngay", "thang", "nam", "ngay_cc_th", "dimuon_gb", "vesom_gb", "thoigian_vesom", "thoigian_dimuon", "themgio", "tong_time" }, new string[] { b_ngay_cc_thu, b_ngay, b_thang, b_nam, b_ngay_cc_th, b_dimuon_gb, b_vesom_gb, b_thoigian_vesom.ToString(), b_thoigian_dimuon.ToString(), b_themgio.ToString(), b_tong_time.ToString() }, i);
                b_loi = "loi:di toi o day 12 - " + i.ToString() + ":loi";
                b_gtr_cu = b_ngay_cc_thu = b_ngay = b_thang = b_nam = b_ngay_cc_th = b_dimuon_gb = b_vesom_gb = "";
                b_gio_s = b_phut_s = b_thoigian_vesom = b_gio_m = b_phut_m = b_thoigian_dimuon = b_themgio = 0;
                b_tong_time = b_gio_tong = b_phut_tong = 0;
                b_loi = "loi:di toi o day 13 - " + i.ToString() + ":loi";

            }
            string b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_cc + "#" + b_dt.Rows.Count;
        }
        //catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
        catch (Exception ex) { return form.Fs_LOC_LOI(b_loi); }
    }

    #region HAL
    public static object[] Fdt_CC_CN_CT_HAL_LKE(string b_phong, string b_thang, int b_tu, int b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_tu, b_den }, "NR", "CC_CN_CT_HAL_LKE");
    }

    [WebMethod(true)]
    public static string Fs_import_cc_hal_NH(object[] a_dt, object[] a_dt_cc)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc);
            bang.P_BO_HANG(ref b_dt_cc, "acno", "");

            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }


    }

    #endregion
    public static DataTable bang_replace(ref DataTable b_dt, string ten_cot, string gtr_cu, string gtr_moi)
    {
        string gtr_cu_bt, gtr_moi_bt;
        for (int i = 0; i < b_dt.Rows.Count; i++)
        {
            gtr_cu_bt = b_dt.Rows[i][ten_cot].ToString();
            if (gtr_cu_bt != "" && gtr_cu_bt != null)
            {
                gtr_moi_bt = gtr_cu_bt.Replace(gtr_cu, gtr_moi);
                bang.P_THAY_GTRI(ref b_dt, ten_cot, gtr_cu_bt, gtr_moi_bt);
            }
        }
        return b_dt;
    }

    public static DataTable bang_themcot_gtri(ref DataTable b_dt, string ten_cot_cu, string ten_cot_moi, int b_tu, int b_toi)
    {
        string gtr_moi = "";
        // thêm cột mới
        for (int i = 0; i < b_dt.Rows.Count; i++)
        {
            gtr_moi = b_dt.Rows[i][ten_cot_cu].ToString().Substring(b_tu, b_toi);
            bang.P_THEM_HANG(ref b_dt, ten_cot_moi, gtr_moi, i);
        }
        return b_dt;
    }
    #endregion CHẤM CÔNG CÔNG NHẬT CHI TIẾT

    #region BẢNG CHẤM CÔNG MÁY
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_LKE(string b_phong, string b_kyluong, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_TH_MAY_LKE(b_phong, b_tu, b_den, b_kyluong, b_so_the, b_hoten);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_CT(string b_phong, string b_kyluong_id, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = tl_cc.Fdt_NS_CC_TH_MAY_CT(b_phong, b_kyluong_id, b_so_the, b_hoten, b_tu, b_den);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_NS_CC_TH_MAY_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }




    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            tl_cc.P_NS_CC_TH_MAY_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_NS_CC_TH_MAY_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_cc.P_NS_CC_TH_MAY_XOA(b_phong, b_thang); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_TH_MAY_LKE_CB(b_phong, b_thang, 1, 30);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_TINH(string b_phong, string b_kyluong, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1") return Thongbao_dch.KY_CONG_KHOA;
            object[] a_object = tl_cc.Fdt_NS_CC_TH_MAY_TINH(b_phong, b_kyluong, b_so_the, b_hoten, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_TH_MAY, TEN_BANG.NS_CC_TH_MAY);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion "BẢNG CHẤM CÔNG MÁY"

    #region CHẤM CÔNG SẢN PHẨM TẬP THỂ
    [WebMethod(true)]
    public string Fs_CC_SP_TT_LKE(string b_phong, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_SP_TT_LKE(b_phong, b_ngayd, b_ngayc, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_TT_MA(string b_phong, string b_ngayd, string b_ngayc, string b_ngay, string b_ca, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_SP_TT_MA(b_phong, b_ngayd, b_ngayc, b_ngay, b_ca, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_TT_CT(string b_so_id, string[] a_cot_sp, string[] a_cot_ds)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_CC_SP_TT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_TIM_THEM(ref b_dt, "cc_sp_tt", "DT_PHONG", "phong");
            string s_dt_tt = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_dt_sp = b_ds.Tables[1], b_dt_ds = b_ds.Tables[2];
            bang.P_CSO_SO(ref b_dt_sp, "soluong");

            string s_dt_sp = bang.Fb_TRANG(b_dt_sp) ? "" : bang.Fs_BANG_CH(b_dt_sp, a_cot_sp);
            string s_dt_ds = bang.Fb_TRANG(b_dt_ds) ? "" : bang.Fs_BANG_CH(b_dt_ds, a_cot_ds);
            return s_dt_tt + "#" + s_dt_sp + "#" + s_dt_ds;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_TT_NH(string b_so_id, string b_phong, string b_ngayd, string b_ngayc, double b_trangKT, object[] a_dt, object[] a_dt_sp, object[] a_dt_ds, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_sp[0]); object[] a_gtri_sp = (object[])a_dt_sp[1];
            string[] a_cot_ds = chuyen.Fas_OBJ_STR((object[])a_dt_ds[0]); object[] a_gtri_ds = (object[])a_dt_ds[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            if (a_gtri_ds == null) a_gtri_ds = new object[a_cot_ds.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay");
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); bang.P_DON(ref b_dt_sp, "masp");
            DataTable b_dt_ds = bang.Fdt_TAO_THEM(a_cot_ds, a_gtri_ds); bang.P_DON(ref b_dt_ds, "so_the");
            //if (b_dt_sp.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_sp, new object[] { "K", "", "", "1" }); 
            bang.P_BO_HANG(ref b_dt_sp, "masp", "");
            //if (b_dt_ds.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ds, new object[] { "K", "", "", "", "1" }); 
            bang.P_BO_HANG(ref b_dt_ds, "so_the", "");
            bang.P_CSO_SO(ref b_dt_sp, "soluong");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.sanpham_congviec;
            }
            else
            {
                for (int i = 0; i < b_dt_sp.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(b_dt_sp.Rows[i]["soluong"].ToString()))
                    {
                        return Thongbao_dch.sanpham_SoLuong;
                    }
                    if (!string.IsNullOrEmpty(b_dt_sp.Rows[i]["chatluong"].ToString()) && chuyen.CSO_SO(b_dt_sp.Rows[i]["chatluong"].ToString()) > 100)
                    {
                        return Thongbao_dch.sanpham_ChatLuong_max;
                    }
                }
            }
            if (b_dt_ds == null || b_dt_ds.Rows.Count <= 0)
            {
                return Thongbao_dch.sanpham_canbo;
            }
            tl_cc.P_CC_SP_TT_NH(ref b_so_id, b_dt, b_dt_sp, b_dt_ds);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CC_SP_TT, TEN_BANG.CC_SP_TT);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri), b_ca = mang.Fs_TEN_GTRI("ca", a_cot, a_gtri);
            return Fs_CC_SP_TT_MA(b_phong, b_ngayd, b_ngayc, b_ngay, b_ca, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_TT_XOA(string b_so_id, string b_phong, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_cc.P_CC_SP_TT_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CC_SP_TT, TEN_BANG.CC_SP_TT);
            return Fs_CC_SP_TT_LKE(b_phong, b_ngayd, b_ngayc, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_TT_LKE_CB(string b_login, string b_phong, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_CC_SP_TT_LKE_CB(b_phong);
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_TT_TIM_DONGIA(string b_sanpham, string b_chatluong, string b_ngay)
    {
        var b_dt = tl_cc.Fdt_CC_SP_TT_TIM_DONGIA(b_sanpham, b_chatluong, b_ngay);
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    #endregion CHẤM CÔNG SẢN PHẨM TẬP THỂ

    #region CHẤM CÔNG SẢN PHẨM CÁ NHÂN RIÊNG

    [WebMethod(true)]
    public string Fs_CC_SP_CN_LKE(string b_so_the, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_SP_CN_LKE(b_so_the, b_ngayd, b_ngayc, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_CN_MA(string b_so_the, string b_ngayd, string b_ngayc, string b_ngay, string b_ca, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_SP_CN_MA(b_so_the, b_ngayd, b_ngayc, b_ngay, b_ca, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ngay", "ca" }, new object[] { b_ngay, b_ca });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_CN_CT(string b_so_id, string[] a_cot, string[] a_cot_sp)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_SP_CN_CT(b_so_id);
            var b_dt = (DataTable)a_object[0]; bang.P_SO_CNG(ref b_dt, "ngay");
            var b_dt_sp = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_sp, "soluong");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_sp_s = bang.Fb_TRANG(b_dt_sp) ? "" : bang.Fs_BANG_CH(b_dt_sp, a_cot_sp);
            return b_dt_kq + "#" + b_dt_sp_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_CN_NH(string b_so_id, string b_so_the, string b_ngayd, string b_ngayc, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay");
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); bang.P_DON(ref b_dt_sp, "masp");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_sp.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_sp.Rows[i]["CHATLUONG"].ToString()))
                {
                    return "loi:Chưa nhập chất lương:loi";
                }
                if (!string.IsNullOrEmpty(b_dt_sp.Rows[i]["chatluong"].ToString()) && chuyen.CSO_SO(b_dt_sp.Rows[i]["chatluong"].ToString()) > 100)
                {
                    return Thongbao_dch.sanpham_ChatLuong_max;
                }
                if (string.IsNullOrEmpty(b_dt_sp.Rows[i]["soluong"].ToString()))
                {
                    return "loi:Chưa nhập số lượng:loi";
                }
            }
            if (b_dt_sp.Rows.Count == 0)
                bang.P_THEM_HANG(ref b_dt_sp, new object[] { "", "", "", "-1", "" }); ; bang.P_BO_HANG(ref b_dt_sp, "masp", "");
            bang.P_CSO_SO(ref b_dt_sp, "soluong");
            tl_cc.P_CC_SP_CN_NH(b_so_id, b_dt, b_dt_sp);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CC_SP_CN, TEN_BANG.CC_SP_CN);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri),
                b_ca = mang.Fs_TEN_GTRI("ca", a_cot, a_gtri);
            return Fs_CC_SP_CN_MA(b_so_the, b_ngayd, b_ngayc, b_ngay, b_ca, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_SP_CN_XOA(string b_so_id, string b_so_the, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_cc.P_CC_SP_CN_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CC_SP_CN, TEN_BANG.CC_SP_CN);
            return Fs_CC_SP_CN_LKE(b_so_the, b_ngayd, b_ngayc, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CHẤM CÔNG SẢN PHẨM CÁ NHÂN RIÊNG

    #region CHẤM CÔNG SẢN PHẨM CÁ NHÂN CHUNG
    [WebMethod(true)]
    public string Fs_CC_SP_CN_CHUNG_LKE(string b_phong, string b_ngayd, string b_ngayc, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_SP_CN_CHUNG_LKE(b_phong, b_ngayd, b_ngayc);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_CN_CHUNG_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_SP_CN_CHUNG_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_CN_CHUNG_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_ct, "so_the");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "", "", "" });
            tl_cc.P_CC_SP_CN_CHUNG_NH(ref b_so_id, b_dt, b_dt_ct); return b_so_id;

        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_SP_CN_CHUNG_XOA(string b_so_id)
    {
        try
        {
            tl_cc.P_CC_SP_CN_CHUNG_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion CHẤM CÔNG SẢN PHẨM CÁ NHÂN CHUNG

    #region CHẤM CÔNG KHOÁN TẬP THỂ
    [WebMethod(true)]
    public string Fs_CC_KHOAN_TT_LKE(string b_phong, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_KHOAN_TT_LKE(b_phong, b_ngayd, b_ngayc, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CSO(ref b_dt, "tien");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHOAN_TT_MA(string b_phong, string b_masp, string b_ngayd, string b_ngayc, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_KHOAN_TT_MA(b_phong, b_masp, b_ngayd, b_ngayc, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ngay", "masp" }, new object[] { b_ngay, b_masp });
            bang.P_SO_CSO(ref b_dt, "tien");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHOAN_TT_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_KHOAN_TT_CT(b_so_id); bang.P_SO_CNG(ref b_dt, "ngay,ngayhoanthanh");
            bang.P_TIM_THEM(ref b_dt, "cc_khoan_tt", "DT_PHONG", "phong");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_KHOAN_TT_NH(string b_so_id, string b_phong, string b_ngayd, string b_ngayc, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_ct, "so_the");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", 0, 0, 0 });
            bang.P_BO_HANG(ref b_dt_ct, "so_the", ""); bang.P_CNG_SO(ref b_dt_ct, "ngayhoanthanh");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            else
            {
                for (int i = 0; i < b_dt_ct.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(b_dt_ct.Rows[i]["tyle"].ToString()) && chuyen.CSO_SO(b_dt_ct.Rows[i]["chatluong"].ToString()) > 100)
                    {
                        return Thongbao_dch.sanpham_ChatLuong_max;
                    }
                    if (!string.IsNullOrEmpty(b_dt_ct.Rows[i]["tyle"].ToString()) && chuyen.CSO_SO(b_dt_ct.Rows[i]["tyle"].ToString()) > 100)
                    {
                        return Thongbao_dch.sanpham_Tyle_max;
                    }
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["tyle"].ToString()) || string.IsNullOrEmpty(b_dt_ct.Rows[i]["ngayhoanthanh"].ToString()) || string.IsNullOrEmpty(b_dt_ct.Rows[i]["chatluong"].ToString()))
                    {
                        return Thongbao_dch.nhapdulieu_luoi;
                    }
                }
            }
            tl_cc.P_CC_KHOAN_TT_NH(b_so_id, b_dt, b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri),
                b_masp = mang.Fs_TEN_GTRI("masp", a_cot, a_gtri);
            return Fs_CC_KHOAN_TT_MA(b_phong, b_masp, b_ngayd, b_ngayc, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_KHOAN_TT_XOA(string b_so_id, string b_phong, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try { tl_cc.P_CC_KHOAN_TT_XOA(b_so_id); return Fs_CC_KHOAN_TT_LKE(b_phong, b_ngayd, b_ngayc, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CHẤM CÔNG KHOÁN TẬP THỂ

    #region CHẤM CÔNG KHOÁN CÁ NHÂN
    [WebMethod(true)]
    public string Fs_CC_KHOAN_CN_LKE(string b_so_the, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_KHOAN_CN_LKE(b_so_the, b_ngayd, b_ngayc, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHOAN_CN_MA(string b_so_the, string b_masp, string b_ngayd, string b_ngayc, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_KHOAN_CN_MA(b_so_the, b_masp, b_ngayd, b_ngayc, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ngay", "masp" }, new object[] { b_ngay, b_masp });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHOAN_CN_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_cc.PCC_KHOAN_CN_CT(b_so_id); bang.P_SO_CNG(ref b_dt, "ngay,ngayhoanthanh");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHOAN_CN_NH(string b_so_id, string b_so_the, string b_ngayd, string b_ngayc, double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay,ngayhoanthanh");
            tl_cc.P_CC_KHOAN_CN_NH(b_so_id, b_dt);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri),
                b_masp = mang.Fs_TEN_GTRI("masp", a_cot, a_gtri);
            return Fs_CC_KHOAN_CN_MA(b_so_the, b_masp, b_ngayd, b_ngayc, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_KHOAN_CN_XOA(string b_so_id, string b_so_the, string b_ngayd, string b_ngayc, double[] a_tso, string[] a_cot)
    {
        try { tl_cc.P_CC_KHOAN_CN_XOA(b_so_id); return Fs_CC_KHOAN_CN_LKE(b_so_the, b_ngayd, b_ngayc, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHẤM CÔNG KHOÁN CÁ NHÂN

    #region TỔNG HỢP CÔNG KHOÁN
    [WebMethod(true)]
    public string Fs_NS_CC_TH_KHOAN_SP_KYLUONG_LKE(string b_login, double b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_th_khoan_sp", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_KHOAN_SP_LKE(string b_login, string b_phong, double b_kyluong, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_TH_KHOAN_SP_LKE(b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "tungay,denngay,ngayd");
            bang.P_SO_CSO(ref b_dt, "cong_khoan,cong_sanpham,tien_khoan,tien_sanpham");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong.ToString());
            return b_kq + "#" + a_obj[0] + "#" + tt;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_KHOAN_SP_TINH(string b_login, string b_phong, string b_kyluong, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_TH_KHOAN_SP_TINH(b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_TH_KHOAN_SP, TEN_BANG.NS_CC_TH_KHOAN_SP);
            DataTable b_dt = (DataTable)a_obj[1];
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1") return Thongbao_dch.KY_CONG_KHOA;
            bang.P_SO_CNG(ref b_dt, "tungay,denngay,ngayd");
            bang.P_SO_CSO(ref b_dt, "cong_khoan,cong_sanpham,tien_khoan,tien_sanpham");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : a_obj[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_KHOAN_SP_MO(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG(b_phong, b_kyluong_id);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_DADONG;
            ht_dungchung.P_NS_CC_TONGHOP_MO(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.MO_CC, TEN_FORM.NS_CC_TH_KHOAN_SP, TEN_BANG.NS_CC_TH_KHOAN_SP);

            return Thongbao_dch.KY_CONG_MO;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_KHOAN_SP_DONG(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            ht_dungchung.P_NS_CC_TONGHOP_DONG(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_CC, TEN_FORM.NS_CC_TH_KHOAN_SP, TEN_BANG.NS_CC_TH_KHOAN_SP);
            return Thongbao_dch.KY_CONG_DONG;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    #endregion

    #region ĐÁNH GIÁ CÁN BỘ
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_CB_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_CB_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_CB_LKE(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_CB_LKE(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_CB_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            return tl_cc.P_TL_DANHGIA_CB_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_CB_XOA(string b_so_id)
    {
        try
        {
            tl_cc.P_TL_DANHGIA_CB_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_CB_LKE_CB(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_CB_LKE_CB(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region ĐÁNH GIÁ Phòng
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_DVI_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_DVI_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_DVI_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_DVI_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_DVI_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            return tl_cc.P_TL_DANHGIA_DVI_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_DVI_XOA(string b_so_id)
    {
        try
        {
            tl_cc.P_TL_DANHGIA_DVI_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_DANHGIA_DVI_LKE_PHONG(string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_DVI_LKE_PHONG();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region KHOÁN DOANH THU
    [WebMethod(true)]
    public string Fs_TL_KHOANDT_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_KHOANDT_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KHOANDT_CT(string b_so_the, string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_KHOANDT_CT(b_so_the, b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KHOANDT_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            return tl_cc.P_TL_KHOANDT_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_KHOANDT_XOA(string b_so_the, string b_so_id)
    {
        try
        {
            tl_cc.P_TL_KHOANDT_XOA(b_so_the, b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region NHÓM LÀM VIỆC
    [WebMethod(true)]
    public string Fs_NS_TL_NHOMLV_CT(string b_so_id, string b_dk, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_NS_TL_NHOMLV_CT(b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + b_dk + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_NHOMLV_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_TL_NHOMLV_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_NHOMLV_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            return tl_cc.P_NS_TL_NHOMLV_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_NHOMLV_XOA(string b_so_id)
    {
        try
        {
            tl_cc.PNS_TL_NHOMLV_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion NHÓM LÀM VIỆC

    #region PHÂN CA LÀM VIỆC
    [WebMethod(true)]
    public string Fs_CC_PHANCA_CT(string b_login, string b_phong, string b_sothe, string b_kyluong, string[] a_cot_cc, double[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_PHANCA_CT(b_phong, b_sothe, b_kyluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_XEP(ref b_dt, "so_the");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc),
                   b_t7 = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["t7"].ToString(),
                   b_cn = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["cn"].ToString();
            return b_dt_ct + "#" + b_dt_cc + "#" + b_t7 + "#" + b_cn + "#" + chuyen.OBJ_S(a_obj[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_PHANCA_MACDINH_CT(string b_login, string b_phong, string b_sothe, string b_kyluong, string[] a_cot_cc, double[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_PHANCA_MACDINH_CT(b_phong, b_sothe, b_kyluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_XEP(ref b_dt, "so_the");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc),
                   b_t7 = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["t7"].ToString(),
                   b_cn = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["cn"].ToString();
            return b_dt_ct + "#" + b_dt_cc + "#" + b_t7 + "#" + b_cn + "#" + chuyen.OBJ_S(a_obj[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_PHANCA_KYCU(string b_login, string b_phong, string b_kyluong, string b_kyluong_cu, string[] a_cot_cc)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_TL_PHANCA_KYCU(b_phong, b_kyluong, b_kyluong_cu);
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc),
                   b_t7 = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["t7"].ToString(),
                   b_cn = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["cn"].ToString();
            return b_dt_ct + "#" + b_dt_cc + "#" + b_t7 + "#" + b_cn;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_PHANCA_NH(string b_login, object[] a_dt, object[] a_dt_cc, string b_t7, string b_cn)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc);
            bang.P_BO_HANG(ref b_dt_cc, "so_the", "");
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt, new string[] { "t7", "cn" }, new object[] { b_t7, b_cn });
            DateTime b_dayd = chuyen.CNG_NG(b_dt.Rows[0]["ngayd"].ToString());
            DateTime b_ngay_backup = b_dayd;
            DateTime b_dayc = chuyen.CNG_NG(b_dt.Rows[0]["ngaykt"].ToString());
            var b_day = (b_dayc - b_dayd).TotalDays + 1;
            bang.P_CNG_SO(ref b_dt, "ngayd");
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_dt.Rows[0]["PHONG"].ToString(), b_dt.Rows[0]["KYLUONG"].ToString());
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            DataTable b_maca = ht_dungchung.Fdt_MA_CALV_DR();
            DataTable b_maca2 = ht_dungchung.Fdt_MA_CALV_DR2();
            for (int i = 0; i < b_dt_cc.Rows.Count; i++)
            {
                for (int j = 2; j < b_dt_cc.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(b_dt_cc.Rows[i][j].ToString()))
                    {
                        DataRow[] row = b_maca2.Select("MA = '" + b_dt_cc.Rows[i][j].ToString() + "'");
                        if (row.Length > 0)
                        {
                            return "loi:Ca " + b_dt_cc.Rows[i][j].ToString() + " đã ngừng áp dụng, không thể sử dụng :loi";
                        }
                    }
                }
            }
            for (int i = 0; i < b_dt_cc.Rows.Count; i++)
            {
                for (int j = 2; j < b_dt_cc.Columns.Count; j++)
                {
                    if (!string.IsNullOrEmpty(b_dt_cc.Rows[i][j].ToString()))
                    {
                        DataRow[] row = b_maca.Select("MA = '" + b_dt_cc.Rows[i][j].ToString() + "'");
                        if (row.Length <= 0)
                        {
                            return "loi:Ca " + b_dt_cc.Rows[i][j].ToString() + " chưa được đăng ký :loi";
                        }
                    }
                }
            }

            //kiểm tra ngày vào
            tl_cc.PCC_PHANCA_NH(b_dt, b_dt_cc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_PHANCA, TEN_BANG.TL_PHANCA);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_PHANCA_XOA(string b_login, string b_phong, string b_kyluong, string b_ngay)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            tl_cc.PCC_PHANCA_XOA(b_phong, b_kyluong, b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_PHANCA, TEN_BANG.TL_PHANCA);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_PHANCA_LKE_CB(string b_login, string b_sothe, string b_phong, string b_kyluongId, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_PHANCA_LKE_CB(b_phong, b_sothe, b_kyluongId);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_LAY_NAM(string b_login, string b_kyluongId)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_LAY_NAM(b_kyluongId);
            bang.P_SO_CNG(ref b_dt, "ng_hluc");
            bang.P_SO_CNG(ref b_dt, "ng_het_hluc");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_LAMCA_BYMA(string b_login, string b_ma)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_NS_TL_TLAP_LAMCA_BYMA(b_ma);
            string b_kieucong_nghi = "";
            if (b_dt.Rows.Count > 0)
            {
                b_kieucong_nghi = b_dt.Rows[0]["NGHI_7_CN"].ToString();
            }
            return b_kieucong_nghi;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion PHÂN CA LÀM VIỆC

    #region ĐĂNG KÝ LÀM THÊM GIỜ
    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_LKE(string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_TL_DKY_LAMTHEM_LKE(b_so_the, b_thang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd,ngay_kt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "3", "Hủy");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_NS_TL_DKY_LAMTHEM_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd,ngay_kt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "3", "Hủy");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_cc.PNS_TL_DKY_LAMTHEM_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_NH(string b_so_id, double b_tinhtrang, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_tinhtrang > 0)
            {
                return Thongbao_dch.thaydoi_pheduyet;
            }
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_bd,ngay_kt");
            b_so_id = tl_cc.PNS_TL_DKY_LAMTHEM_NH(ref b_so_id, b_dt_ct);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL("OT", b_so_id);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký làm thêm giờ cần phê duyệt";
                string b_body = "Bạn có đơn xin nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";

                //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                //string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                //string b_subject = "Overtime Application";
                //string b_body = "You received an Overtime Application which needs to be approved. \nPlease click following link http://nagase.cerp.vn to approve \n";

                SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_NS_TL_DKY_LAMTHEM_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_XOA(string b_so_id, string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_cc.PNS_TL_DKY_LAMTHEM_XOA(b_so_id); return Fs_NS_TL_DKY_LAMTHEM_LKE(b_so_the, b_thang, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_TL_DKY_LAMTHEM_HUY(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_cc.PNS_TL_DKY_LAMTHEM_HUY(b_so_id);
            if (b_dt.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt.Rows[0]["email"]);
                string b_subject = "You received an Cancelation request which needs to be approved";
                string b_body = "You received an Cancelation request which needs to be approved. \n Please click following link http://nagase.cerp.vn to approve \n";
                //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            return "";

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region ĐĂNG KÝ ĐI MUỘN VỀ SỚM PORTAL
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_LKE(string b_login, string b_so_the, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_CN_DKY_DMVS_LKE(b_so_the, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "VS", "Đăng ký về sớm");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_MA(string b_login, string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Faobj_CC_CN_DKY_DMVS_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "VS", "Đăng ký về sớm");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_CC_CN_DKY_DMVS_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_CT2(string b_login, string b_ngaydky, string b_loaidky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_CC_CN_DKY_DMVS_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            b_so_id = tl_cc.P_CC_CN_DKY_DMVS_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CC_CN_DKY_DMVS, TEN_BANG.CC_CN_DKY_DMVS);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "DMVS");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
                string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_CC_CN_DKY_DMVS_MA(b_login, b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_GUI(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_CC_CN_DKY_DMVS_GUI(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.CC_CN_DKY_DMVS, TEN_BANG.CC_CN_DKY_DMVS);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_DMVS_XOA(string b_login, string b_so_id, string b_so_the, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_CC_CN_DKY_DMVS_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CC_CN_DKY_DMVS, TEN_BANG.CC_CN_DKY_DMVS);
            return Fs_CC_CN_DKY_DMVS_LKE(b_login, b_so_the, b_trangthai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐĂNG KÝ ĐI MUỘN VỀ SỚM PORTAL

    #region PHÊ DUYỆT ĐI MUỘN VỀ SỚM

    [WebMethod(true)]
    public string Fs_CC_DKY_DMVSPD_LKE(string b_phong, string a_tinhtrang, string b_loai_dky_tk, string b_so_the_tk, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_DKY_DMVSPD_LKE(b_phong, a_tinhtrang, b_loai_dky_tk, b_so_the_tk, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAY_DKY");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "VS", "Đăng ký về sớm");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_DMVSPD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = tl_cc.Fdt_CC_DKY_DMVSPD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.CC_DKY_DMVSPD, TEN_BANG.CC_DKY_DMVSPD);

            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVSPD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = tl_cc.Fdt_CC_DKY_DMVSPD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.CC_DKY_DMVSPD, TEN_BANG.CC_DKY_DMVSPD);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT NGHỈ PHÉP

    #region PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_QT_NGHIPHEP_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_so_the_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAYD,NGAYC");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return form.Fs_LOC_LOI(ex.ToString());
        }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DXN" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = tl_cc.Fdt_NS_QT_NGHIPHEP_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_QT_NGHIPHEP_PD, TEN_BANG.NS_QT_NGHIPHEP_PD);

            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DXN" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = tl_cc.Fdt_NS_QT_NGHIPHEP_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_QT_NGHIPHEP_PD, TEN_BANG.NS_QT_NGHIPHEP_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    #region PHÊ DUYỆT ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_DKLV_NGOAI_CTY_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_so_the_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAY_DK");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return form.Fs_LOC_LOI(ex.ToString());
        }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_PD_PHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DKLVNCT" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKLV_NGOAI_CTY_PD_PHEDUYET(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_PD, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);

            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_PD_KOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DKLVNCT" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKLV_NGOAI_CTY_PD_KOPHEDUYET(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_PD, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    #region PHÊ DUYỆT ĐĂNG KÝ CA CON NHỎ DƯỚI 1 TUỔI

    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_PD_LKE(string b_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_DKC_CONNHO_PD_LKE(b_tinhtrang, b_tungay, b_denngay, b_so_the_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAYD,NGAYC");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return form.Fs_LOC_LOI(ex.ToString());
        }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DKCNCN" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id"); bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKC_CONNHO_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_CC_DKC_CONNHO_PD, TEN_BANG.NS_CC_DKC_CONNHO_PD);

            // đẩy dữ liệu sang xếp ca làm việc
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                // lấy danh sách ngày theo khoản thời gian đăng ký từ ngày đến ngày.
                DataTable b_dt_ds = new DataTable();
                b_dt_ds = ns_qt.Fdt_NS_CC_DKC_CONNHO_DS_PHANCA(dr["MA_NV"].ToString(), dr["ca"].ToString(), dr["ngayd"].ToString(), dr["ngayc"].ToString());

                // đẩy dữ liệu vào phân xếp ca làm việc
                ns_qt.PNS_CC_DKC_CONNHO_PHANCA(b_dt_ds);
            }


            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S");
            bang.P_THEM_HANG(ref b_dt, new object[] { "OT" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            //for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            //{
            //    if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
            //    {
            //        return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
            //    }
            //}
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKC_CONNHO_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_CC_DKC_CONNHO_PD, TEN_BANG.NS_CC_DKC_CONNHO_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi"))
                return form.Fs_LOC_LOI(ex.ToString());
            else
                return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ CA CON NHỎ DƯỚI 1 TUỔI

    /*#region PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM GIỜ
    //[WebMethod(true)]
    //public string Fs_NS_TL_LAMTHEMPD_LKE(string a_tinhtrang, string a_thang, double[] a_tso, string[] a_cot)
    //{
    //    try
    //    {
    //        double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
    //        object[] a_object = tl_cc.Fdt_NS_TL_LAMTHEMPD_LKE(a_tinhtrang, a_thang, b_tu, b_den);
    //        DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
    //        bang.P_SO_CNG(ref b_dt_tk, "ngay_bd,ngay_kt");
    //        bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "T", "OT ngày thường");
    //        bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "C", "OT cuối tuần");
    //        bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "H", "OT ngày nghỉ");
    //        return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TL_LAMTHEMPD_PHEDUYET(string b_tinhtrang, object[] a_dt_ct)
    //{
    //    try
    //    {
    //        string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
    //        DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
    //        if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
    //        {
    //            return Thongbao_dch.vuilong;
    //        }
    //        bang.P_BO_HANG(ref b_dt_ct, "chon", "");
    //        DataTable b_kq = tl_cc.Fdt_NS_TL_LAMTHEMPD_PHEDUYET(b_tinhtrang, b_dt_ct);
    //        string b_subject = "", b_body = "";
    //        //if (b_kq.Rows.Count > 0)
    //        //{
    //        //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
    //        //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
    //        //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
    //        //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
    //        //}
    //        if (b_kq.Rows.Count > 0)
    //        {
    //            for (int i = 0; i < b_kq.Rows.Count; i++)
    //            {
    //                string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
    //                if (b_tinhtrang == "1")
    //                {
    //                    b_subject = "Your Application has been approved.";
    //                    b_body = "Your Application has been approved.\n";
    //                }
    //                else
    //                {
    //                    b_subject = "Your application has been rejected.";
    //                    b_body = "Your application has been rejected.\n";
    //                }
    //                //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
    //                //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
    //            }
    //        }
    //        return "";
    //    }
    //    catch (Exception ex) { return Thongbao_dch.Pheduyet_thatbai; }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TL_LAMTHEMPD_KOPHEDUYET(object[] a_dt_ct)
    //{
    //    try
    //    {
    //        string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
    //        DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
    //        bang.P_BO_HANG(ref b_dt_ct, "chon", "");
    //        if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
    //        {
    //            return Thongbao_dch.vuilong;
    //        }
    //        tl_cc.Fdt_NS_TL_LAMTHEMPD_KOPHEDUYET(b_dt_ct);
    //        return "";
    //    }
    //    catch (Exception ex) { return Thongbao_dch.koPheduyet_thatbai; }
    //}
    #endregion PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM GIỜ*/

    #region PHÊ DUYỆT ĐĂNG KÝ NGHỈ LÃNH ĐẠO

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_LD_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_QT_NGHIPHEP_LD_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAYD,NGAYC");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_LD_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = tl_cc.Fdt_NS_QT_NGHIPHEP_LD_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_QT_NGHIPHEP_LD_PD, TEN_BANG.NS_QT_NGHIPHEP_LD_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_LD_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = tl_cc.Fdt_NS_QT_NGHIPHEP_LD_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_QT_NGHIPHEP_LD_PD, TEN_BANG.NS_QT_NGHIPHEP_LD_PD);

            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ LÃNH ĐẠO

    #region PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM

    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_PD_LKE(string b_kycong, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_DKY_LTHEM_PD_LKE(b_kycong, a_tinhtrang, b_tungay, b_denngay, b_so_the_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "T", "Ngày thường");
            bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "C", "Ngày cuối tuần");
            bang.P_THAY_GTRI(ref b_dt_tk, "hinhthuc", "H", "Ngày lễ");

            bang.P_THAY_GTRI(ref b_dt_tk, "lthem_theoluat", "C", "Làm thêm theo luật");
            bang.P_THAY_GTRI(ref b_dt_tk, "lthem_theoluat", "K", "Làm thêm không theo luật");
            bang.P_SO_CNG(ref b_dt_tk, "NGAY_BD");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "OT" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKY_LTHEM_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_CC_DKY_LTHEM_PD, TEN_BANG.NS_CC_DKY_LTHEM_PD);

            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "OT" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_kq = tl_cc.Fdt_NS_CC_DKY_LTHEM_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_CC_DKY_LTHEM_PD, TEN_BANG.NS_CC_DKY_LTHEM_PD);
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    #region TỔNG HỢP CHẤM CÔNG

    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_LKE(string b_phong, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_NS_CC_TONGHOP_LKE(b_phong);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thangcc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_NS_CC_TONGHOP_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thangcc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thangcc", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_CT(string b_phong, double b_kyluong, string[] a_cot, string[] a_cot_ma)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_NS_CC_TONGHOP_CT(b_phong, b_kyluong);
            DataTable b_dt_ma = b_ds.Tables[0]; bang.P_THEM_COL(ref b_dt_ma, new string[] { "so_the", "ten" }, new object[] { "", "" });
            DataTable b_dt = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAYD,NGAYC");

            string b_ma = (bang.Fb_TRANG(b_dt_ma)) ? "" : bang.Fs_BANG_CH(b_dt_ma, a_cot_ma);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);

            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong.ToString());


            return b_ma + "#" + b_kq + "#" + b_ds.Tables[1].Rows.Count + "#" + tt;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_NH(double b_trangKT, object[] a_dt, object[] a_dt_ma, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thangcc");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            string[] a_cot_ma = chuyen.Fas_OBJ_STR((object[])a_dt_ma[0]); object[] a_gtri_ma = (object[])a_dt_ma[1];
            DataTable b_dt_ma = bang.Fdt_TAO_THEM(a_cot_ma, a_gtri_ma);
            //tl_cc.P_NS_CC_TONGHOP_GOPDONG(b_dt_ct);
            tl_cc.P_NS_CC_TONGHOP_NH(b_dt, b_dt_ma, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_NS_CC_TONGHOP_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return Thongbao_dch.ThaoTac_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_MO(string b_phong, string b_kyluong_id)
    {
        try
        {
            ht_dungchung.P_NS_CC_TONGHOP_MO(b_phong, b_kyluong_id);
            return Thongbao_dch.KY_CONG_MO;
        }
        catch (Exception ex)
        {
            return Thongbao_dch.ThaoTac_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_DONG(string b_phong, string b_kyluong_id)
    {
        try
        {
            ht_dungchung.P_NS_CC_TONGHOP_DONG(b_phong, b_kyluong_id);
            return Thongbao_dch.KY_CONG_DONG;
        }
        catch (Exception ex)
        {
            return Thongbao_dch.ThaoTac_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_XOA(string b_phong, string b_thang, string[] a_cot)
    {
        try
        { tl_cc.P_NS_CC_TONGHOP_XOA(b_phong, b_thang); return Fs_NS_CC_TONGHOP_LKE(b_phong, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_LKE_CB(string b_phong, string[] a_cot, string[] a_cot_ma)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_NS_CC_TONGHOP_LKE_CB(b_phong);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ma = b_ds.Tables[1];
            bang.P_THEM_COL(ref b_dt, new string[] { "phong_cp", "n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10", "n11", "n12", "n13", "n14", "n15", "n16", "n17", "n18", "n19", "n20", "n21", "n22", "n23", "n24", "n25" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
            bang.P_THEM_COL(ref b_dt_ma, new string[] { "so_the", "ten" }, new object[] { "", "" });
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            int sodong = b_dt.Rows.Count;
            string b_ma = (bang.Fb_TRANG(b_dt_ma)) ? "" : bang.Fs_BANG_CH(b_dt_ma, a_cot_ma);
            return b_ma + "#" + b_kq + "#" + sodong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_LKE_COT(string[] a_cot_ma)
    {
        try
        {
            var cot_cong = "";
            DataTable b_dt = tl_cc.Fdt_NS_CC_TONGHOP_LKE_COT();
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                cot_cong = b_dt.Rows[i]["ten"].ToString() + "#" + cot_cong;
            }
            return cot_cong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_TINH(string b_phong, string b_kyluong, object[] a_dt_ct, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_TONGHOP_TINH(b_phong, chuyen.OBJ_N(b_kyluong));

            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            bang.P_SO_CNG(ref b_dt, "NGAYD,NGAYC");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    #endregion TỔNG HỢP CHẤM CÔNG

    #region CÔNG CHI TIẾT NAGASE
    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_TL_CC_CT_NAGASE_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt, "thangcc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_TL_CC_CT_NAGASE_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thangcc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thangcc", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_NAGASE_CT(b_phong, b_thang);
            bang.P_SO_CTH(ref b_dt, "thangcc");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "id_cc", "");
            //if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            tl_cc.P_TL_CC_CT_NAGASE_NH(b_dt, b_dt_ct);
            string b_thang = mang.Fs_TEN_GTRI("thangcc", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_TL_CC_CT_NAGASE_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try { tl_cc.P_TL_CC_CT_NAGASE_XOA(b_thang); return Fs_TL_CC_CT_NAGASE_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_NAGASE_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_LKE_CB2(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_NAGASE_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            bang.P_THEM_COL(ref b_dt, "diemso", "");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_NAGASE_TINH_TU(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_NAGASE_TINH_TU(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_CN_CT_NAGASE_TONGHOP(string b_phong, string b_thangcc, string[] a_cot_cc)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_CN_CT_NAGASE_TONGHOP(b_phong, b_thangcc);
            bang.P_SO_CSO(ref b_dt, "ngaythuong");
            //string b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc);
            return bang.Fs_BANG_CH(b_dt, a_cot_cc) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CÔNG CHI TIẾT HAL
    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_TL_CC_CT_HAL_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_TL_CC_CT_HAL_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_HAL_CT(b_phong, b_thang);
            bang.P_SO_CTH(ref b_dt, "thang");
            bang.P_DOI_TENCOL(ref b_dt, "id_cc", "id");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "id", "");
            //if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            tl_cc.P_TL_CC_CT_HAL_NH(b_dt, b_dt_ct);
            string b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_TL_CC_CT_HAL_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try { tl_cc.P_TL_CC_CT_HAL_XOA(b_thang); return Fs_TL_CC_CT_HAL_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_HAL_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CT_HAL_LKE_CB2(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_TL_CC_CT_HAL_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            bang.P_THEM_COL(ref b_dt, "diemso", "");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region TỔNG HỢP CHẤM CÔNG CÁ NHÂN HAL

    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_HAL_LKE(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_TONGHOP_HAL_LKE(b_phong, b_thang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            //bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_HAL_CT(string b_phong, string b_thang, string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_TONGHOP_HAL_CT(b_phong, b_thang, b_so_the);
            bang.P_CSO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CHẤM CÔNG CÔNG NHẬT CHI TIẾT NAGASE

    [WebMethod(true)]
    public string Fs_CC_CN_CT_NAGASE_CT(string b_phong, string b_ca, string b_loai, string b_thangcc, string[] a_cot_cc)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_CC_CN_CT_NAGASE_CT(b_phong, b_ca, b_loai, b_thangcc); bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cc = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_cc),
                   b_t7 = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["t7"].ToString(),
                   b_cn = bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0]["cn"].ToString();
            return b_dt_ct + "#" + b_dt_cc + "#" + b_t7 + "#" + b_cn + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_CC_CN_CT_NAGASE_NH(object[] a_dt, object[] a_dt_cc, string b_t7, string b_cn)
    {
        try
        {
            double a_cong = 0, a_anca = 0;
            string gtri, gtr1, gtr2;
            int index, index2;
            DataTable b_gtrcc; DataRow b_dr;
            string gio_so_the = "", gio_ma_cc = ""; double tonggio = 0;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc); bang.P_THEM_COL(ref b_dt_cc, new string[] { "cong", "anca" });
            bang.P_BO_HANG(ref b_dt_cc, "so_the", "");
            DataTable b_dt_cc_gio = bang.Fdt_TAO_BANG(new string[] { "so_the", "ma_cc", "gio", "tonggio" }, new object[] { "", "", "", "" });
            //DataTable b_dt_cc_giotonghop = bang.Fdt_TAO_BANG(new string[] { "so_the", "ma_cc", "tonggio", "conggio", "ancagio" }, new object[] { "", "", "", "", "" });
            //int k = 0;

            //for (int j = 0; j < b_dt_cc.Rows.Count; j++)
            //{
            //    object[] a_gtr_cong = (object[])a_gtri_cc[j];
            //    k = a_gtr_cong.Length - 1;
            //    for (int i = 3; i <= k; i++)
            //    {
            //        // tìm kí tự trong chuỗi
            //        gtri = a_gtr_cong[i].ToString();
            //        index = gtri.IndexOf(",");
            //        if (index > 0)
            //        {
            //            gtr1 = gtri.Substring(0, index);
            //            gtr2 = gtri.Substring(index + 1, gtri.Length - index - 1);
            //            mang.P_CAT(ref a_gtr_cong, i);
            //            mang.P_MO(ref a_gtr_cong, 1, gtr1);
            //            mang.P_MO(ref a_gtr_cong, 1, gtr2);
            //            k++; i--;
            //        }
            //        else
            //        {
            //            index2 = gtri.IndexOf("/");
            //            if (index2 > 0)
            //            {
            //                gtr1 = gtri.Substring(0, index2);
            //                gtr2 = gtri.Substring(index2 + 1, gtri.Length - index2 - 1);
            //                bang.P_THEM_HANG(ref b_dt_cc_gio, new string[] { "so_the", "ma_cc", "gio" }, new object[] { a_gtr_cong[0].ToString(), gtr1, gtr2 });
            //            }
            //        }
            //        b_gtrcc = tl_cc.PCC_CN_CT_GT(chuyen.OBJ_S(a_gtr_cong[i]));
            //        if (b_gtrcc.Rows.Count > 0)
            //        {
            //            b_dr = b_gtrcc.Rows[0];
            //            a_cong = a_cong + chuyen.OBJ_N(b_dr["tyle"]) / 100;
            //            a_anca = a_anca + chuyen.OBJ_N(b_dr["anca"]);
            //        }
            //    }
            //    bang.P_DAT_GTRI(ref b_dt_cc, new string[] { "cong", "anca" }, new object[] { a_cong, a_anca }, j); a_cong = 0; a_anca = 0; k = 32;
            //}
            // tính tổng h cho từng mã công trong bảng b_dt_cc_gio

            //for (int f = 0; f < b_dt_cc_gio.Rows.Count; f++)
            //{
            //    if (b_dt_cc_gio.Rows[f]["so_the"].ToString() != gio_so_the || b_dt_cc_gio.Rows[f]["ma_cc"].ToString() != gio_ma_cc)
            //    {
            //        gio_so_the = b_dt_cc_gio.Rows[f]["so_the"].ToString();
            //        gio_ma_cc = b_dt_cc_gio.Rows[f]["ma_cc"].ToString();
            //        tonggio = bang.Fn_TIM_TONG(b_dt_cc_gio, "gio", new string[] { "so_the", "ma_cc" }, new object[] { gio_so_the, gio_ma_cc });
            //    }
            //}
            DataTable b_dt_sogio = tl_cc.PCC_CN_CT_SOGIO();
            double sogio_ngay = chuyen.OBJ_N(b_dt_sogio.Rows[0]["sogio"]);
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt, new string[] { "t7", "cn" }, new object[] { b_t7, b_cn });
            bang.P_CTH_SO(ref b_dt, "thangcc"); bang.P_CNG_SO(ref b_dt, "ngayd");
            tl_cc.PCC_CN_CT_NAGASE_NH(b_dt, b_dt_cc);

            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_CT_NAGASE_XOA(string b_phong, string b_ca, string b_loai, string b_thang, string b_ngay)
    {
        try
        {
            tl_cc.PCC_CN_CT_NAGASE_XOA(b_phong, b_ca, b_loai, b_thang, b_ngay);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CHẤM CÔNG CÔNG NHẬT CHI TIẾT NAGASE

    #region GIẢI TRÌNH CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_GT_CC_LKE(string b_login, string b_so_the, string b_kyluong, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_GT_CC_LKE(b_so_the, b_kyluong, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_gt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_GT_CC_MA(string b_login, string b_so_the, string b_so_id, string b_trangthai, string b_kyluong, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Faobj_NS_GT_CC_MA(b_so_the, b_so_id, b_trangthai, b_kyluong, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_gt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GT_CC_CT(string b_login, string b_form, string b_so_id, string b_ngay_gt)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_GT_CC_CT(b_so_id, b_ngay_gt);
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            DataTable b_dt2 = new DataTable();
            if (b_dt.Rows.Count > 0)
                b_dt2 = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_dt.Rows[0]["NAM"].ToString()));
            se.P_TG_LUU("ns_gt_cc", "DT_KYLUONG", b_dt2);
            bang.P_TIM_THEM(ref b_dt, "ns_gt_cc", "DT_KIEUNGHI", "MACC_NGHI");
            bang.P_TIM_THEM(ref b_dt, "ns_gt_cc", "DT_KYLUONG", "KYLUONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_GT_CC_CT2(string b_login, string b_ngaydky, string b_loaidky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_GT_CC_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_GT_CC_NH(string b_login, string b_so_id, string b_trangthai, string b_kyluong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            b_so_id = tl_cc.P_NS_GT_CC_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_GT_CC, TEN_BANG.NS_GT_CC);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "DMVS");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                //string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                //string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
                //string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_NS_GT_CC_MA(b_login, b_so_the, b_so_id, b_trangthai, b_kyluong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_GT_CC_GUI(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_NS_GT_CC_GUI(b_so_the); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_GT_CC_XOA(string b_login, string b_so_id, string b_so_the, string b_kyluong, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        { if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_NS_GT_CC_XOA(b_so_id); return Fs_NS_GT_CC_LKE(b_login, b_so_the, b_kyluong, b_trangthai, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion GIẢI TRÌNH CHẤM CÔNG

    #region QUẢN LÝ GIẢI TRÌNH CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_GT_LKE(string b_login, string b_phong, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_GT_LKE(b_phong, b_kyluong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_gt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion GIẢI TRÌNH CHẤM CÔNG

    #region GIAI TRINH CHAM CONG
    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CHAMCONG_GIAITRINH_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_CT(string b_so_the, string b_thang, string[] a_cot_ct, string[] a_cot_kq)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_NS_CHAMCONG_GIAITRINH_CT(b_so_the, b_thang);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngay_cc");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            DataTable b_dt_kq = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_kq, "ngay_ot");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "2", "Không phê duyệt");
            string b_dt_kq_ct = bang.Fb_TRANG(b_dt_kq) ? "" : bang.Fs_BANG_CH(b_dt_kq, a_cot_kq);
            return b_dt_ct + "#" + b_dt_kq_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_NH(object[] a_dt, object[] a_dt_ct, object[] a_dt_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_lke = chuyen.Fas_OBJ_STR((object[])a_dt_lke[0]); object[] a_gtri_lke = (object[])a_dt_lke[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ngay_cc", "");
            DataTable b_dt_lke = bang.Fdt_TAO_THEM(a_cot_lke, a_gtri_lke); bang.P_BO_HANG(ref b_dt_lke, "ngay_ot", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" });
            if (b_dt_lke.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_lke, new object[] { "-1" });
            tl_cc.P_NS_CHAMCONG_GIAITRINH_NH(b_dt, b_dt_ct, b_dt_lke);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_XOA(string b_so_the)
    {
        try { ns_tt.P_NS_THS_XOA(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GT_CC_NH2(string b_login, string b_so_id, string b_trangthai, string b_kyluong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            b_so_id = tl_cc.P_NS_GT_CC_NH2(ref b_so_id, b_dt_ct);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "DMVS");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                //string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                //string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
                //string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng Ghi vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_NS_GT_CC_MA(b_login, b_so_the, b_so_id, b_trangthai, b_kyluong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }


    //PHẦN NÀY LÀ PHÊ DUYỆT
    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_PD_LKE(string b_tinhtrang, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CHAMCONG_GIAITRINH_PD_LKE(b_tinhtrang, b_thang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            //bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            // bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_PD_CT(string b_so_the, string b_thang, string[] a_cot_ct, string[] a_cot_kq)
    {
        try
        {
            DataSet b_ds = tl_cc.Fdt_NS_CHAMCONG_GIAITRINH_CT(b_so_the, b_thang);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngay_cc");
            string b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            DataTable b_dt_kq = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_kq, "ngay_ot");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "2", "Không phê duyệt");
            string b_dt_kq_ct = bang.Fb_TRANG(b_dt_kq) ? "" : bang.Fs_BANG_CH(b_dt_kq, a_cot_kq);
            return b_dt_ct + "#" + b_dt_kq_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CHAMCONG_GIAITRINH_PHEDUYET(string b_so_the, string b_thang, string b_tinhtrang, object[] a_dt_ct, object[] a_dt_lke)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_lke = chuyen.Fas_OBJ_STR((object[])a_dt_lke[0]); object[] a_gtri_lke = (object[])a_dt_lke[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ngay_cc", "");
            DataTable b_dt_lke = bang.Fdt_TAO_THEM(a_cot_lke, a_gtri_lke); bang.P_BO_HANG(ref b_dt_lke, "ngay_ot", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" });
            if (b_dt_lke.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_lke, new object[] { "-1" });
            tl_cc.P_NS_CHAMCONG_GIAITRINH_PHEDUYET(b_so_the, b_thang, b_tinhtrang, b_dt_ct, b_dt_lke);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    #endregion GIAI TRINH CHAM CONG

    #region QUẢN LÝ ĐI MUỘN VỀ SỚM
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_LKE(string b_login, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_DKY_DMVS_LKE(b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "VS", "Đăng ký về sớm");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_MA(string b_login, string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_object = tl_cc.Fdt_CC_DKY_DMVS_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt_tk, "LOAI_DKY", "VS", "Đăng ký về sớm");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.PCC_DKY_DMVS_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_CT2(string b_login, string b_ngaydky, string b_loaidky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.PCC_DKY_DMVS_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            b_so_id = tl_cc.PCC_DKY_DMVS_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CC_DKY_DMVS, TEN_BANG.CC_DKY_DMVS);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "DMVS");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
                string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_CC_DKY_DMVS_MA(b_login, b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_DMVS_XOA(string b_login, string b_so_id, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.PCC_DKY_DMVS_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CC_DKY_DMVS, TEN_BANG.CC_DKY_DMVS);
            return Fs_CC_DKY_DMVS_LKE(b_login, b_tungay, b_denngay, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐI MUỘN VỀ SỚM

    #region QUẢN LÝ LÀM THÊM
    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_LKE(string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_DKY_LAMTHEM_LKE(b_so_the, b_thang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KIEMTRA_GIO(string b_giobd, string b_giokt)
    {
        try
        {
            double b_phut, b_gio = 0;
            string b_loi = "loi:Giờ bắt đầu sai định dạng:loi";
            if (ht_dungchung.IsTime(b_giobd, b_loi) != "")
            {
                return b_loi;
            }
            b_loi = "loi:Giờ kết thúc sai định dạng:loi";
            if (ht_dungchung.IsTime(b_giokt, b_loi) != "")
            {
                return b_loi;
            }
            string[] b_bd = b_giobd.Split(':');
            string[] b_kt = b_giokt.Split(':');
            double b_phutbd = chuyen.OBJ_N(b_bd[1].ToString());
            double b_phutkt = chuyen.OBJ_N(b_kt[1].ToString());

            double b_gio_bd = chuyen.OBJ_N(b_bd[0].ToString());
            double b_gio_kt = chuyen.OBJ_N(b_kt[0].ToString());
            if (b_phutbd > b_phutkt) { b_phut = b_phutbd - b_phutkt; }
            else b_phut = b_phutkt - b_phutbd;
            if (b_gio_kt > b_gio_bd) { b_gio = b_gio_kt - b_gio_bd; }
            return (Math.Round(chuyen.OBJ_N(b_kt) - chuyen.OBJ_N(b_bd)) / 100).ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KIEMTRA_PHUT(string b_giobd, string b_giokt)
    {
        try
        {

            double b_phut, b_gio = 0;
            string b_kq = "";
            string b_loi = "loi:Giờ bắt đầu sai định dạng:loi";
            if (ht_dungchung.IsTime(b_giobd, b_loi) != "") return b_loi;
            b_loi = "loi:Giờ kết thúc sai định dạng:loi";
            if (ht_dungchung.IsTime(b_giokt, b_loi) != "") return b_loi;
            string[] b_bd = b_giobd.Split(':');
            string[] b_kt = b_giokt.Split(':');
            double b_phutbd = chuyen.OBJ_N(b_bd[1].ToString());
            double b_phutkt = chuyen.OBJ_N(b_kt[1].ToString());

            double b_gio_bd = chuyen.OBJ_N(b_bd[0].ToString());
            double b_gio_kt = chuyen.OBJ_N(b_kt[0].ToString());
            b_phut = b_phutkt - b_phutbd;
            if (b_gio_kt > b_gio_bd) { b_gio = b_gio_kt - b_gio_bd; }
            if (b_gio_bd > b_gio_kt) b_phut = 0;
            if (b_gio_kt == b_gio_bd) b_kq = (b_gio * 60 + b_phut).ToString();
            else b_kq = (b_gio * 60 + b_phut).ToString();
            return b_kq;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_DKY_LAMTHEM_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_cc.PCC_DKY_LAMTHEM_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_CT2(string b_ngaydky, string b_loaidky)
    {
        try
        {
            DataTable b_dt = tl_cc.PCC_DKY_LAMTHEM_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            b_so_id = tl_cc.PCC_DKY_LAMTHEM_NH(ref b_so_id, b_dt_ct);
            DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "OT");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                //string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                //string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
                //string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail + "#" + Fs_CC_DKY_LAMTHEM_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LAMTHEM_XOA(string b_so_id, string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_cc.PCC_DKY_LAMTHEM_XOA(b_so_id); return Fs_CC_DKY_LAMTHEM_LKE(b_so_the, b_thang, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐI MUỘN VỀ SỚM

    #region QUẢN LÝ KHAI BÁO LÀM THÊM
    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_LKE(string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_KHAIBAO_LAMTHEM_LKE(b_so_the, b_thang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_KHAIBAO_LAMTHEM_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_cc.PCC_KHAIBAO_LAMTHEM_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_CT2(string b_ngaydky, string b_loaidky)
    {
        try
        {
            DataTable b_dt = tl_cc.PCC_KHAIBAO_LAMTHEM_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            b_so_id = tl_cc.PCC_KHAIBAO_LAMTHEM_NH(ref b_so_id, b_dt_ct);
            //DataTable b_dt_kq = tl_cc.PNS_THONGTIN_EMAIL(b_so_id, "OT");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            //string b_guimail = "";
            //if (b_dt_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đơn đăng ký đi muộn về sớm cần phê duyệt";
            //    string b_body = "Bạn có đơn xin đi muộn về sớm cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            return "" + "#" + Fs_CC_KHAIBAO_LAMTHEM_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_KHAIBAO_LAMTHEM_XOA(string b_so_id, string b_so_the, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_cc.PCC_KHAIBAO_LAMTHEM_XOA(b_so_id); return Fs_CC_KHAIBAO_LAMTHEM_LKE(b_so_the, b_thang, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐI MUỘN VỀ SỚM

    #region TỔNG HỢP LÀM THÊM
    [WebMethod(true)]
    public string Fs_NS_CC_LTHEM_TONGHOP_CT(string b_login, string b_phong, double b_kyluong, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Fdt_NS_CC_LTHEM_TONGHOP_CT(b_phong, b_kyluong, b_so_the, b_hoten, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "tong_tt,sogio_lthem_ktl_it,sogio_lthem_ktl_lx,cong_anca_5_11,cong_anca_tren_11,tongcong_anca_ovt,tong_nghibu,tong_1_hientai,tong_trongthang");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong.ToString());
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TONGHOP_LTHEM_TINH(string b_login, string b_phong, string b_kyluong, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1") return Thongbao_dch.KY_CONG_KHOA;
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Fdt_NS_CC_TONGHOP_LTHEM_TINH(b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, b_hoten, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_TONGHOP_LTHEM, TEN_BANG.NS_CC_TONGHOP_LTHEM);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "tong_tt,sogio_lthem_ktl_it,sogio_lthem_ktl_lx,cong_anca_5_11,cong_anca_tren_11,tongcong_anca_ovt,tong_nghibu,tong_1_hientai,tong_trongthang");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_CC_LAMTHEM_COT(string b_login, string[] a_cot_ma)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            var cot_cong = "";
            DataTable b_dt = tl_cc.Fdt_CC_LAMTHEM_COT();
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                cot_cong = b_dt.Rows[i]["ten"].ToString() + "#" + cot_cong;
            }
            return cot_cong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion TỔNG HỢP LÀM THỀM

    #region DỮ LIỆU QUẸT THẺ
    [WebMethod(true)]
    public string Fs_CC_QUET_THE_LKE(string[] a_cot, double[] a_tso, string b_so_the, string b_ngaybd, string b_ngaykt)
    {
        try
        {
            double b_ngayd = 0;
            double b_ngayc = 0;
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            if (!string.IsNullOrEmpty(b_ngaybd))
            {
                b_ngayd = chuyen.CNG_SO(b_ngaybd);
            }
            if (!string.IsNullOrEmpty(b_ngaykt))
            {
                b_ngayc = chuyen.CNG_SO(b_ngaykt);
            }
            object[] a_object = tl_cc.Fdt_CC_QUET_THE_LKE(b_ngayd, b_ngayc, b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_TAI_QUET_THE_LKE(string[] a_cot, string b_may_cc, string b_ngaybd, string b_ngaykt)
    {
        try
        {
            DateTime b_ngayd;
            DateTime b_ngayc;
            if (string.IsNullOrEmpty(b_may_cc))
            {
                return "loi:Chưa chọn máy chấm công cần tải:loi";
            }
            if (!string.IsNullOrEmpty(b_ngaybd))
            {
                b_ngayd = chuyen.CNG_NG(b_ngaybd);
            }
            else
                b_ngayd = DateTime.Now;
            if (!string.IsNullOrEmpty(b_ngaykt))
            {
                b_ngayc = chuyen.CNG_NG(b_ngaykt);
            }
            else
                b_ngayc = DateTime.Now;
            DataTable b_dt_may = tl_cc.Fdt_CC_MAY_CC_MA(b_may_cc);
            if (b_dt_may == null || b_dt_may.Rows.Count <= 0)
            {
                return Thongbao_dch.MAY_CHAM_CONG_KHONG_TAN_TAI;
            }
            DataTable b_dt = sv_GetLogData(b_dt_may, b_ngayd, b_ngayc);

            tl_cc.P_CC_TAI_QUET_THE_NH(b_dt);

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    private DataTable sv_GetLogData(DataTable b_dt_may, DateTime p_tungay, DateTime p_Denngay)
    {
        zkemkeeper.CZKEMClass sv_SDK1 = new zkemkeeper.CZKEMClass();

        int sv_ErrorNo = 0;

        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("STT", typeof(int));
        b_dt.Columns.Add("MA_CC", typeof(string));
        b_dt.Columns.Add("VAN_TAY", typeof(string));

        DataRow row;
        int mv_Port = int.Parse(b_dt_may.Rows[0]["PORT"].ToString());
        string message = "";
        int sv_vErrorCode = 0;
        bool sv_vRet = false;
        string mv_IP = b_dt_may.Rows[0]["IP"].ToString();
        int mv_matkhau = 0;
        if (!string.IsNullOrEmpty(b_dt_may.Rows[0]["matkhau"].ToString()))
        {
            mv_matkhau = int.Parse(b_dt_may.Rows[0]["matkhau"].ToString());
        }
        var mv_MachineNumber = 1;
        try
        {
            if (!string.IsNullOrEmpty(mv_IP))
            {
                if (mv_matkhau > 0)
                {
                    sv_SDK1.SetCommPassword(mv_matkhau);
                }
                if (sv_SDK1.Connect_Net(mv_IP, mv_Port))
                {
                    sv_vRet = sv_SDK1.EnableDevice(1, false);
                    if (!sv_vRet)
                    {
                        return b_dt;
                    }
                    sv_SDK1.EnableDevice(1, false);
                    //disable the device
                    string idwEnrollNumber = "";
                    int idwVerifyMode = 0;
                    int idwInOutMode = 0;
                    int idwYear = 0;
                    int idwMonth = 0;
                    int idwDay = 0;
                    int idwHour = 0;
                    int idwMinute = 0;
                    int idwSecond = 0;
                    int idwWorkcode = 0;
                    int stt = 0;
                    if (mv_IP != "0")
                    {
                        b_dt.Clear();
                    }
                    if (sv_vRet)
                    {
                        sv_SDK1.GetLastError(ref sv_ErrorNo);
                        while (sv_ErrorNo != 0)
                        {
                            sv_SDK1.EnableDevice(mv_MachineNumber, false);
                            if (sv_SDK1.ReadGeneralLogData(mv_MachineNumber))
                            {
                                while (sv_SDK1.SSR_GetGeneralLogData(mv_MachineNumber, out idwEnrollNumber, out idwVerifyMode, out idwInOutMode, out idwYear, out idwMonth, out idwDay, out idwHour, out idwMinute, out idwSecond,
                                ref idwWorkcode))
                                {
                                    if (idwYear > System.DateTime.Now.Year)
                                    {
                                        continue;
                                    }
                                    if ((new System.DateTime(idwYear, idwMonth, idwDay) >= p_tungay && new System.DateTime(idwYear, idwMonth, idwDay) <= Convert.ToDateTime(p_Denngay)))
                                    {
                                        row = b_dt.NewRow();
                                        row["STT"] = stt = stt + 1;
                                        row["MA_CC"] = idwEnrollNumber;
                                        row["VAN_TAY"] = new System.DateTime(idwYear, idwMonth, idwDay, idwHour, idwMinute, 0).ToString("dd/MM/yyyy hh:mm:ss ");
                                        b_dt.Rows.Add(row);
                                    }
                                }
                            }
                            sv_SDK1.GetLastError(ref sv_ErrorNo);
                        }
                    }
                    else
                    {
                        sv_SDK1.GetLastError(ref sv_vErrorCode);
                    }
                    sv_SDK1.Disconnect();
                }
                else
                {
                    sv_SDK1.Disconnect();
                }
            }
            else
            {
                if (string.IsNullOrEmpty(mv_IP))
                {
                }
                else
                {
                    message += "IP " + mv_IP + " không đúng!" + "\n";
                }
            }
            sv_SDK1.Disconnect();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return b_dt;
    }

    #endregion

    #region DỮ LIỆU VÂN TAY
    [WebMethod(true)]
    public string Fs_CC_VANTAY_LKE(string b_login, string[] a_cot, string b_phong, string b_so_the, string b_ho_ten, string b_ngaybd, string b_ngaykt, string b_dimuon, string b_vesom, string b_cangay, double b_trangkt, string[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_QUET_THE_LKE(b_phong, chuyen.CNG_SO(b_ngaybd), chuyen.CNG_SO(b_ngaykt), b_so_the, b_ho_ten, b_dimuon, b_vesom, b_cangay, b_trangkt, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "NGAY");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_VANTAY_LKE_NSD(string b_login, string[] a_cot, string b_phong, string b_so_the, string b_ho_ten, string b_ngaybd, string b_ngaykt, string b_dimuon, string b_vesom, string b_cangay, double b_trangkt, string[] a_tso)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_CC_QUET_THE_LKE_NSD(b_phong, chuyen.CNG_SO(b_ngaybd), chuyen.CNG_SO(b_ngaykt), b_so_the, b_ho_ten, b_dimuon, b_vesom, b_cangay, b_trangkt, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "NGAY");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public static string Fs_CC_QUET_THE_NH(DataTable b_dt_cc)
    {
        try
        {
            bang.P_THEM_COL(ref b_dt_cc, "NGAY_Q"); tl_cc.P_CC_QUET_THE_NH(b_dt_cc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_QUETTHE, TEN_BANG.NS_CC_QUETTHE);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public static DataTable PNS_MA_CC_DR()
    {
        return dbora.Fdt_LKE_S(new object[] { "1" }, "PNS_MA_CC_DR");
    }
    public static DataTable PNS_MA_CC_DR2()
    {
        return dbora.Fdt_LKE_S(new object[] { "1" }, "PNS_MA_CC_DR2");
    }
    #endregion

    #region CHẤM CÔNG KHÁC GIỜ CÔNG TY
    [WebMethod(true)]
    public string Fs_CC_KHACGIO_CTY_LKE(string b_so_the, string b_tungay, string b_denngay, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_Fs_CC_KHACGIO_CTY_LKE(b_tu_n, b_den_n, b_phong, b_so_the, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay));
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay,tu_ngay_dk,den_ngay_dk");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHẤM CÔNG KHÁC GIỜ CÔNG TY

    #region HỆ SỐ LÀM THÊM
    [WebMethod(true)]
    public string Fs_CC_MA_HSO_LAMTHEM_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_CC_MA_HSO_LAMTHEM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "ma_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ma_tt", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_MA_HSO_LAMTHEM_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_CC_MA_HSO_LAMTHEM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ma_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ma_tt", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_HSO_LAMTHEM_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_cc.P_CC_MA_HSO_LAMTHEM_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_CC_MA_HSO_LAMTHEM_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_HSO_LAMTHEM_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_cc.P_CC_MA_HSO_LAMTHEM_XOA(b_ma); return Fs_CC_MA_HSO_LAMTHEM_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ HÌNH THỨC THÔI VIỆC

    #region QUẢN LÝ KHAI BÁO LÀM THÊM
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_LKE(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_KB_LTHEM_LKE(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_MA(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Faobj_NS_CC_KB_LTHEM_MA(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_CT(string b_login, string b_so_the, string b_ngay_dky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_KB_LTHEM_CT(b_so_the, b_ngay_dky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_kb_lthem", "DT_HSO", "HSO");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_CT2(string b_login, string b_ngaydky, string b_loaidky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_KB_LTHEM_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_kb_lthem", "DT_HSO", "HSO");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_NH(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            b_so_id = tl_cc.P_NS_CC_KB_LTHEM_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_KB_LTHEM, TEN_BANG.NS_CC_KB_LTHEM);
            return "" + "#" + Fs_NS_CC_KB_LTHEM_MA(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_KB_LTHEM_XOA(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_NS_CC_KB_LTHEM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_KB_LTHEM, TEN_BANG.NS_CC_KB_LTHEM);
            return Fs_NS_CC_KB_LTHEM_LKE(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐI MUỘN VỀ SỚM

    #region QUẢN LÝ ĐĂNG KÝ LÀM THÊM 
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_LKE(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_DKY_LTHEM_LKE(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_MA(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Faobj_NS_CC_DKY_LTHEM_MA(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_CT(string b_login, string b_so_the, string b_ngay_dky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_DKY_LTHEM_CT(b_so_the, b_ngay_dky);
            bang.P_SO_CNG(ref b_dt, "ngay_bd");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_dky_lthem", "DT_HSO", "HSO");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_NH(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_bd");
            b_so_id = tl_cc.P_NS_CC_DKY_LTHEM_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_DKY_LTHEM, TEN_BANG.NS_CC_DKY_LTHEM);
            return "" + "#" + Fs_NS_CC_DKY_LTHEM_MA(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_XOA(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_NS_CC_DKY_LTHEM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_DKY_LTHEM, TEN_BANG.NS_CC_DKY_LTHEM);
            return Fs_NS_CC_DKY_LTHEM_LKE(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_NS_CC_DKY_LTHEM_CT2(string b_login, string b_ngaydky, string b_loaidky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_DKY_LTHEM_CT2(chuyen.CNG_SO(b_ngaydky), b_loaidky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LAY_HINHTHUC_LT(string b_login, string b_ngaykd)
    {
        try
        {
            if (string.IsNullOrEmpty(b_ngaykd)) return "T";
            else
            {
                if (b_login != null) se.P_LOGIN(b_login);
                DataTable b_dt = tl_cc.Fdt_NS_CC_LAY_NGAYLE(chuyen.CNG_SO(b_ngaykd));
                DateTime ngaykd = DateTime.ParseExact(b_ngaykd, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                if (chuyen.OBJ_I(b_dt.Rows[0]["tontai"].ToString()) > 0) return "H";
                else if ((ngaykd.DayOfWeek == DayOfWeek.Saturday) || (ngaykd.DayOfWeek == DayOfWeek.Sunday)) return "C";
                else return "T";
            }
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LAY_HINHTHUC_LT_DL(string b_login, string b_ngaykd, string b_sothe)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_LAY_DULIEU_LT(chuyen.CNG_SO(b_ngaykd), b_sothe);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LAY_DULIEUKB_LT(string b_login, string b_ngaykd, string b_sothe)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_LAY_DULIEUKB_LT(chuyen.CNG_SO(b_ngaykd), b_sothe);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LAY_DULIEUDKY_LT(string b_login, string b_ngaykd, string b_sothe)
    {
        try
        {
            DataTable b_dt = tl_cc.Fdt_NS_CC_LAY_DULIEUDKY_LT(chuyen.CNG_SO(b_ngaykd), b_sothe);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_GIO_DANGKY_HOI(string b_gio_bd, string b_gio_kt)
    {
        try
        {
            string b_loi = "loi:Giờ bắt đầu sai định dạng:loi";
            if (!string.IsNullOrEmpty(b_gio_bd))
            {
                if (ht_dungchung.IsTime(b_gio_bd, b_loi) != "") { return b_loi; }
            }
            if (!string.IsNullOrEmpty(b_gio_kt))
            {
                b_loi = "loi:Giờ kết thúc sai định dạng:loi";
                if (ht_dungchung.IsTime(b_gio_kt, b_loi) != "") { return b_loi; }
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐI MUỘN VỀ SỚM

    #region ĐĂNG KÝ CÁ NHÂN LÀM THÊM
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKY_LTHEM_LKE(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_cc.Faobj_NS_CC_CN_DKY_LTHEM_LKE(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKY_LTHEM_MA(string b_login, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            object[] a_obj = tl_cc.Faobj_NS_CC_CN_DKY_LTHEM_MA(b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangkt);
            DataTable b_dt_tk = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            int b_hang = bang.Fi_TIM_ROW(b_dt_tk, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKY_LTHEM_CT(string b_login, string b_so_the, string b_ngay_dky)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_CN_DKY_LTHEM_CT(b_so_the, b_ngay_dky);
            bang.P_SO_CNG(ref b_dt, "ngay_bd");
            //bang.P_TIM_THEM(ref b_dt, "NS_CC_CN_DKY_LTHEM", "DT_HSO", "HSO");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKY_LTHEM_NH(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_bd");
            b_so_id = tl_cc.P_NS_CC_CN_DKY_LTHEM_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_CN_DKY_LTHEM, TEN_BANG.NS_CC_CN_DKY_LTHEM);

            b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return "" + "#" + Fs_NS_CC_CN_DKY_LTHEM_MA(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKY_LTHEM_XOA(string b_login, string b_so_id, string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_NS_CC_CN_DKY_LTHEM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_CN_DKY_LTHEM, TEN_BANG.NS_CC_CN_DKY_LTHEM);

            return Fs_NS_CC_CN_DKY_LTHEM_LKE(b_login, b_so_the, b_hoten, b_ngayd, b_ngayc, b_phong, a_tso, a_cot);
        }

        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_CN_DKY_LTHEM_GUI(string b_login, string b_so_id, string b_so_the)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); tl_cc.P_CC_CN_DKY_LTHEM_GUI(b_so_id, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_CC_CN_DKY_LTHEM, TEN_BANG.NS_CC_CN_DKY_LTHEM);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ CÁ NHÂN LÀM THÊM

    #region XEM PHÉP NĂM CỦA NHÂN VIÊN

    [WebMethod(true)]
    public string Fs_NS_QT_PHEP_NAM_LKE(string b_so_the, string b_nam, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_QT_PHEP_NAM_LKE(b_so_the, b_nam, b_kyluong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    [WebMethod(true)]
    public string Fs_DANHSACH_KYLUONG_DR(string b_form, string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            se.P_TG_LUU(b_form, "DT_KYLUONG", b_dt.Copy());
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #region THIẾT LẬP CÔNG CHUẨN NHÂN VIÊN 
    [WebMethod(true)]
    public string Fs_NS_CC_CCNV_LKE(string b_login, string b_form, string b_nam, string b_kyluong, string b_dtuong, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_cc.Fdt_NS_CC_CCNV_LKE(b_nam, b_kyluong, b_dtuong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CCNV_TUNG_DENNG(string b_login, string b_kyluong)
    {
        try
        {
            se.P_LOGIN(b_login);
            var b_dt = tl_cc.Fdt_NS_CC_CCNV_TUNG_DENNG(b_kyluong);
            string svalue = "";
            if (!bang.Fb_TRANG(b_dt))
            {
                svalue = b_dt.Rows[0]["TU_NGAY"].ToString() + "#" + b_dt.Rows[0]["DEN_NGAY"].ToString();
            }
            return svalue;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CCNV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_CSO_SO(ref b_dt_ct, "cong_chuan,so_qd");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct.Rows.Count <= 0) return "loi:Bạn chưa chọn nhân viên:loi";
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (Convert.ToInt32(b_dt_ct.Rows[i]["cong_chuan"]) <= 0)
                {
                    return "loi:Công chuẩn phải lớn hơn 0 :loi";
                }
            }
            b_so_id = tl_cc.P_NS_CC_CCNV_NH(ref b_so_id, b_dt, b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion 

}