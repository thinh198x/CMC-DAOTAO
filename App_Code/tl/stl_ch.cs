using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class stl_ch : System.Web.Services.WebService
{
    #region QUYẾT TOÁN THUẾ

    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "SO_THE", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            b_so_id = tl_ch.P_NS_TL_QTTHUE_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_QTTHUE, TEN_BANG.NS_TL_QTTHUE);
            return Fs_NS_TL_QTTHUE_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ch.Faobj_NS_TL_QTTHUE_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_MA2(string b_login, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ch.Faobj_NS_TL_QTTHUE_MA2(b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_QTTHUE_LKE(b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataSet b_ds = tl_ch.Fds_NS_TL_QTTHUE_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ch.P_NS_TL_QTTHUE_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TL_QTTHUE, TEN_BANG.NS_TL_QTTHUE);
            return Fs_NS_TL_QTTHUE_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_UQUYEN_LKE(string b_login, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_QTTHUE_UQUYEN_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_UQUYEN_CT(string b_login, string b_so_id, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ch.Fds_NS_TL_QTTHUE_UQUYEN_CT(b_so_id, b_so_the);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_UQUYEN_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_THEM_COL(ref b_dt, "SO_ID", b_so_id);

            b_so_id = tl_ch.P_NS_TL_QTTHUE_UQUYEN_NH(ref b_so_id, b_dt);

            DataRow b_dr = b_dt.Rows[0];

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_QTTHUE, TEN_BANG.NS_TL_QTTHUE);
            return Fs_NS_TL_QTTHUE_UQUYEN_MA(b_login, chuyen.OBJ_S(b_dr["nam"]), chuyen.OBJ_S(b_dr["so_the"]), b_trangKT , a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_UQUYEN_MA(string b_login, string b_nam, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ch.Faobj_NS_TL_QTTHUE_UQUYEN_MA(b_nam, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_QTTHUE_XTTIN_CT(string b_login, string b_nam, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_CT(b_nam, b_so_the);
            bang.P_THAY_GTRI(ref b_dt, "uyquyen", "", "Không");
            bang.P_THAY_GTRI(ref b_dt, "uyquyen", "X", "Có");
            //lương năm
            object[] a_obj_lnam = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_LNAM(b_nam, b_so_the);
            double b_lnam = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_lnam[0])) ? 0 : chuyen.OBJ_N(a_obj_lnam[0]);

            //tổng thu nhập năm
            var b_tu_ngay = b_nam + "0101"; //ngày đầu năm
            var b_den_ngay = b_nam + "1231"; // ngày cuối năm
            object[] a_obj_ttnnam = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_TTNNAM(b_nam, b_so_the, b_tu_ngay, b_den_ngay);
            double b_ttnnam = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_ttnnam[0])) ? 0 : chuyen.OBJ_N(a_obj_ttnnam[0]);

            //tổng thu nhập miễn thuế
            object[] a_obj_ttnmthue = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_TTNMTHUE(b_nam, b_so_the);
            double b_ttnmthue = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_ttnmthue[0])) ? 0 : chuyen.OBJ_N(a_obj_ttnmthue[0]);

            //tổng thu nhập tính thuế
            object[] a_obj_ttntthue = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_TTNTTHUE(b_nam, b_so_the);
            double b_ttntthue = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_ttntthue[0])) ? 0 : chuyen.OBJ_N(a_obj_ttntthue[0]);

            //tổng giảm trừ
            object[] a_obj_tgtru = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_TGTRU(b_nam, b_so_the);
            double b_tgtru = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_tgtru[0])) ? 0 : chuyen.OBJ_N(a_obj_tgtru[0]);

            //bảo hiểm người lao động nộp
            object[] a_obj_bhiem = tl_ch.Fds_NS_TL_QTTHUE_XTTIN_BHIEM(b_nam, b_so_the);
            double b_bhiem = string.IsNullOrEmpty(chuyen.OBJ_S(a_obj_bhiem[0])) ? 0 : chuyen.OBJ_N(a_obj_bhiem[0]);

            DataTable b_dt_grid = new DataTable();
            string[] a_cot = new string[] { "STT", "NOIDUNG", "GIATRI" };
            bang.P_THEM_COL(ref b_dt_grid, a_cot, "S,S,S");
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "1", "Lương năm", b_lnam });
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "2", "Tổng thu nhập năm", b_ttnnam });
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "3", "Tổng thu nhập miễn thuế", b_ttnmthue });
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "4", "Tổng thu nhập tính thuế", b_ttntthue });
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "5", "Tổng giảm trừ", b_tgtru });
            bang.P_THEM_HANG(ref b_dt_grid, new object[] { "6", "Bảo hiểm người lao động nộp", b_bhiem });

            bang.P_SO_CSO(ref b_dt_grid, "GIATRI");

            return ((bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0)) + "#" + bang.Fs_BANG_CH(b_dt_grid, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUYẾT TOÁN THUẾ

    #region XỬ LÝ VI PHẠM

    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_NH(string b_login, string b_so_id, string b_phong, string b_nam, string b_ky, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "lan_vp,tien,nam");
            if (b_dt.Rows[0]["co_tinhluong"].Equals("C"))
            {
                if (string.IsNullOrEmpty(b_dt.Rows[0]["nam"].ToString()))
                {
                    return "loi:Bạn chưa nhập năm:loi";
                }
                if (string.IsNullOrEmpty(b_dt.Rows[0]["kyluong"].ToString()))
                {
                    return "loi:Bạn chưa nhập kỳ lương:loi";
                }
            }
            b_so_id = tl_ch.P_NS_TL_VIPHAM_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_VIPHAM, TEN_BANG.NS_TL_VIPHAM);
            return Fs_NS_TL_VIPHAM_MA(b_login, b_so_id, b_phong, b_nam, b_ky, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_MA(string b_login, string b_so_id, string b_phong, string b_nam, string b_ky, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ch.Faobj_NS_TL_VIPHAM_MA(b_so_id, b_phong, b_nam, b_ky, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CSO(ref b_dt, "lan_vp,tien");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_LKE(string b_login, string b_phong, string b_nam, string b_ky, string b_sothe, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_VIPHAM_LKE(b_phong, b_nam, b_ky, b_sothe, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt_ct, "tien");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_LKE_ALL(string b_login, string b_phong, string b_nam, string b_ky, string b_sothe, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_VIPHAM_LKE_ALL(b_phong, b_nam, b_ky, b_sothe, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt_ct, "tien");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = tl_ch.Fdt_NS_TL_VIPHAM_CT(b_so_id);
            bang.P_SO_CSO(ref b_dt, "lan_vp,tien");
            DataTable b_dt2 = new DataTable();
            if (b_dt.Rows.Count > 0)
                b_dt2 = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_dt.Rows[0]["NAM"].ToString()));
            se.P_TG_LUU("ns_tl_vipham", "DT_KYLUONG", b_dt2.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_tl_vipham", "DT_KYLUONG", "KYLUONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_VIPHAM_XOA(string b_login, string b_so_id, string b_phong, string b_nam, string b_so_the, string b_ky, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ch.P_NS_TL_VIPHAM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TL_VIPHAM, TEN_BANG.NS_TL_VIPHAM);
            return Fs_NS_TL_VIPHAM_LKE(b_login, b_phong, b_nam, b_so_the, b_ky, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion XỬ LÝ VI PHẠM

    #region HƯỞNG PHỤ CẤP
    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_DSACH(string b_so_the, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_PCAP_DSACH(b_so_the, b_thang);
            bang.P_CSO_CNG(ref b_dt, new string[] { "ngayd" });
            bang.P_SO_CSO(ref b_dt, "giatri");
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_LKE(string b_ma_goc, string b_phong, string b_theo, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_TN_PCAP_LKE(b_ma_goc, b_phong, b_theo, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_MA(string b_ma_goc, string b_phong, string b_ngay, string b_theo, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_TN_PCAP_MA(b_ma_goc, b_phong, b_ngay, b_theo, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_PCAP_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay", "ngay_qd", "ngayd", "ngayc" });
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_NH(string b_so_id, string b_so_qd_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_pc = (object[])a_dt_ct[1];
            if (a_gtri_pc == null) a_gtri_pc = new object[a_cot_pc.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc); bang.P_DON(ref b_dt_pc, "mapc");
            bang.P_BO_HANG(ref b_dt_pc, "mapc", "");
            if (b_dt_pc == null || b_dt_pc.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }


            tl_ch.P_TL_TN_PCAP_NH(b_so_id, b_so_qd_id, b_dt, b_dt_pc);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("ma_goc", a_cot, a_gtri);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_theo = mang.Fs_TEN_GTRI("theo", a_cot, a_gtri);
            return Fs_TL_TN_PCAP_MA(b_so_the, b_phong, b_ngay, b_theo, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_NH2(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_pc = (object[])a_dt_ct[1];
            if (a_gtri_pc == null) a_gtri_pc = new object[a_cot_pc.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc); bang.P_DON(ref b_dt_pc, "so_the");
            bang.P_BO_HANG(ref b_dt_pc, "so_the", "");
            if (b_dt_pc == null || b_dt_pc.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            tl_ch.P_TL_TN_PCAP_NH2(b_so_id, b_dt, b_dt_pc);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("ma_goc", a_cot, a_gtri);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_theo = mang.Fs_TEN_GTRI("theo", a_cot, a_gtri);
            return Fs_TL_TN_PCAP_MA(b_so_the, b_phong, b_ngay, b_theo, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_PCAP_XOA(string b_so_id, string b_ma_goc, string b_phong, string b_theo, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_TL_TN_PCAP_XOA(b_so_id); return Fs_TL_TN_PCAP_LKE(b_ma_goc, b_phong, b_theo, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP PHỤ CẤP

    #region HỒI TỐ LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_HT_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_HT_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_HT_NH(string b_so_id, string b_thang, string b_note, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            return tl_ch.P_TL_HT_NH(ref b_so_id, b_thang, b_note, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_HT_XOA(string b_so_id)
    {
        try
        {
            tl_ch.P_TL_HT_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion HỒI TỐ LƯƠNG

    #region KHẤU TRỪ BẢO HIỂM
    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_KTRU_BH_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_KTRU_BH_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang ", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KTRU_BH_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            tl_ch.P_TL_KTRU_BH_NH(b_so_id, b_dt_ct, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_TL_KTRU_BH_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_XOA(string b_so_id, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_KTRU_BH_XOA(b_so_id); return Fs_TL_KTRU_BH_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_LKE_CB(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KTRU_BH_LKE_CB(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_BH_LKE_BH(string b_thang, string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KTRU_BH_LKE_BH(b_thang, b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KHẤU TRỪ BẢO HIỂM

    #region KHẤU TRỪ THUẾ
    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_KTRU_THUE_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_KTRU_THUE_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_kq = tl_ch.Fdt_TL_KTRU_THUE_CT(b_so_id); bang.P_SO_CTH(ref b_kq, "thang");
            bang.P_SO_CSO(ref b_kq, "tongchiuthue,phuthuoc,truthue");
            string b_dt = bang.Fb_TRANG(b_kq) ? "" : bang.Fs_HANG_GOP(b_kq, 0);
            string b_dt_ct = bang.Fb_TRANG(b_kq) ? "" : bang.Fs_BANG_CH(b_kq, a_cot);
            return b_dt + "#" + b_dt_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            tl_ch.P_TL_KTRU_THUE_NH(b_so_id, b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_TL_KTRU_THUE_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_XOA(string b_so_id, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_KTRU_THUE_XOA(b_so_id); return Fs_TL_KTRU_THUE_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_LKE_CB(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KTRU_THUE_LKE_CB(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_KTRU_THUE_TINH(string b_thang, string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KTRU_THUE_TINH(b_thang, b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KHẤU TRỪ THUẾ

    #region THU NHẬP/KHẤU TRỪ KHÁC
    [WebMethod(true)]
    public string Fs_TL_TNKT_KHAC_LKE(string b_so_the, string b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_TNKT_KHAC_LKE(b_so_the, b_loai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TNKT_KHAC_MA(string b_so_the, string b_loai, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_TNKT_KHAC_MA(b_so_the, b_loai, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TNKT_KHAC_CT(string b_so_the, string b_loai, string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TNKT_KHAC_CT(b_so_the, b_loai, b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TNKT_KHAC_NH(double b_trangKT, object[] b_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]); object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay");
            tl_ch.P_TL_TNKT_KHAC_NH(b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri),
                b_loai = mang.Fs_TEN_GTRI("loai", a_cot, a_gtri),
                b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TNKT_KHAC_MA(b_so_the, b_loai, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TNKT_KHAC_XOA(string b_so_the, string b_loai, string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_TNKT_KHAC_XOA(b_so_the, b_loai, b_ngay); return Fs_TL_TNKT_KHAC_LKE(b_so_the, b_loai, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THU NHẬP/KHẤU TRỪ KHÁC

    #region KẾ HOẠCH LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_KH_LUONG_CT(string b_nam)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_KH_LUONG_CT(b_nam);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KH_LUONG_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ch.P_TL_KH_LUONG_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_KH_LUONG_XOA(string b_nam)
    {
        try
        {
            tl_ch.P_TL_KH_LUONG_XOA(b_nam);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion KẾ HOẠCH LƯƠNG

    #region TẠM ỨNG
    [WebMethod(true)]
    public string Fs_TL_TN_TU_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_TN_TU_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_TU_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_TN_TU_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_TU_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_TU_CT(b_phong, b_thang);
            bang.P_SO_CTH(ref b_dt, "thang"); bang.P_SO_CSO(ref b_dt, "tamung");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_TU_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            tl_ch.P_TL_TN_TU_NH(b_dt, b_dt_ct);
            string b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_TL_TN_TU_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_TU_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_TL_TN_TU_XOA(b_thang); return Fs_TL_TN_TU_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_TU_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_TU_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_TU_LKE_CB2(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_TU_LKE_CB(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "tamung");
            bang.P_THEM_COL(ref b_dt, "diemso", "");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_TU_TINH_TU(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_TN_TU_TINH_TU(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion TẠM ỨNG

    #region DÙNG CHUNG CHO 4 BẢNG LƯƠNG TANVIET
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_COTTK(string b_dtuong)
    {
        try
        {
            var cot_luong = "";
            DataTable b_dt = tl_ch.Fdt_NS_TL_BLUONG_COTTK(b_dtuong);
            DataTable b_dt2 = tl_ch.Fdt_NS_TL_BLUONG_COTTK_STYLE(b_dtuong);
            cot_luong = bang.Fs_BANG_CH(b_dt) + "#" + bang.Fs_BANG_CH(b_dt2);
            return cot_luong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_COT(string b_dtuong)
    {
        try
        {
            var cot_luong = "";
            DataTable b_dt = tl_ch.Fdt_NS_TL_BLUONG_COT(b_dtuong);
            DataTable b_dt2 = tl_ch.Fdt_NS_TL_BLUONG_COT_STYLE(b_dtuong);
            cot_luong = bang.Fs_BANG_CH(b_dt) + "#" + bang.Fs_BANG_CH(b_dt2);
            return cot_luong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion DÙNG CHUNG CHO 4 BẢNG LƯƠNG TANVIET

    #region BẢNG LƯƠNG KHỐI BACK TANVIET
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_TK_CT(string b_login, string b_phong, string b_kyluong_id, string b_so_the, string[] a_cotTK, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_BLUONG_TK_CT(b_phong, b_kyluong_id, b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC");
            DataTable b_dttk_cot = tl_ch.Fdt_NS_TL_BLUONGTK_LKE_COTSO("BACK");
            for (int i = 0; i < b_dttk_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dttk_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dttk_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong)) bang.P_SO_CSO(ref b_dt, cot_luong);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cotTK) + "#" + b_dt.Rows.Count + "#" + a_obj[0];
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_CT(string b_login, string b_phong, string b_kyluong_id, string b_so_the, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_BLUONG_CT(b_phong, b_kyluong_id, b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1]; DataTable b_dt_clone = b_dt.Copy();
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            DataTable b_dt_cot = tl_ch.Fdt_NS_TL_BLUONG_LKE_COTSO("BACK");
            cot_luong = "";
            for (int i = 0; i < b_dt_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dt_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dt_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong)) bang.P_SO_CSO(ref b_dt, cot_luong);

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count + "#" + a_obj[0];
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_TINH(string b_login, string b_phong, string b_kyluong, string b_so_the, string[] a_cottk, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            DataSet b_ds = null;
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "0") return Thongbao_dch.Vuilong_dong_kycong;
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG(b_phong, b_kyluong);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_KHOA;
            b_ds = tl_ch.Fdt_TL_BLUONG_TINH(b_phong, b_kyluong, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);

            DataTable b_dt = b_ds.Tables[0]; DataTable b_dttk = b_ds.Tables[1];
            DataTable b_dt_clone = b_ds.Tables[0].Copy();
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_BO_COT(ref b_dttk, "sott");
            bang.P_COPY_COL(ref b_dttk, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            bang.P_SO_CNG(ref b_dttk, "NGAY_VAO,NGAYD,NGAYC");
            // các cột định dạng số bảng lương trong kỳ
            DataTable b_dttk_cot = tl_ch.Fdt_NS_TL_BLUONGTK_LKE_COTSO("BACK");
            for (int i = 0; i < b_dttk_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dttk_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dttk_cot.Rows[i]["ma"].ToString();
            }
            //if (!string.IsNullOrEmpty(cot_luong))
            //{
            //    bang.P_SO_CSO(ref b_dttk, cot_luong);
            //}
            // các cột định dạng số bảng lương tổng hợp
            DataTable b_dt_cot = tl_ch.Fdt_NS_TL_BLUONG_LKE_COTSO("BACK");
            cot_luong = "";
            for (int i = 0; i < b_dt_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dt_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dt_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong))
            {
                bang.P_SO_CSO(ref b_dt, cot_luong);
            }
            return (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count
                /*+ "#" + (bang.Fb_TRANG(b_dttk) ? "" : bang.Fs_BANG_CH(b_dttk, a_cottk) + "#" + b_dttk.Rows.Count)*/);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_MO(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            // Kiểm tra kỳ lương có được đóng vĩnh viên không?
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG_VV(b_phong, b_kyluong_id);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_DONG_VV;
            ht_dungchung.P_NS_TL_BLUONG_MO(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.MO_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_MO;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_DONG(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login); ht_dungchung.P_NS_TL_BLUONG_DONG(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_DONG;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_DONG_VV(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login); ht_dungchung.P_NS_CC_TONGHOP_DONG_VV(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_VV_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_DONG_VV;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    #endregion BẢNG LƯƠNG KHỐI BACK TANVIET

    #region BẢNG LƯƠNG KHỐI SALE TANVIET
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_TK_CT(string b_login, string b_phong, string b_kyluong_id, string b_so_the, string[] a_cotTK, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_BLUONG_SALE_TK_CT(b_phong, b_kyluong_id, b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC");
            DataTable b_dttk_cot = tl_ch.Fdt_NS_TL_BLUONGTK_LKE_COTSO("SALE");
            for (int i = 0; i < b_dttk_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dttk_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dttk_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong)) bang.P_SO_CSO(ref b_dt, cot_luong);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cotTK) + "#" + b_dt.Rows.Count + "#" + a_obj[0];
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_CT(string b_login, string b_phong, string b_kyluong_id, string b_so_the, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_BLUONG_SALE_CT(b_phong, b_kyluong_id, b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1]; DataTable b_dt_clone = b_dt.Copy();
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            DataTable b_dt_cot = tl_ch.Fdt_NS_TL_BLUONG_LKE_COTSO("SALE");
            cot_luong = "";
            for (int i = 0; i < b_dt_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dt_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dt_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong)) bang.P_SO_CSO(ref b_dt, cot_luong);

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count + "#" + a_obj[0];
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_TINH(string b_login, string b_phong, string b_kyluong, string b_so_the, string[] a_cottk, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            var cot_luong = "";
            DataSet b_ds = null;
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "0") return Thongbao_dch.Vuilong_dong_kycong;
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG(b_phong, b_kyluong);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_KHOA;
            b_ds = tl_ch.Fdt_TL_BLUONG_SALE_TINH(b_phong, b_kyluong, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);

            DataTable b_dt = b_ds.Tables[0]; DataTable b_dttk = b_ds.Tables[1];
            DataTable b_dt_clone = b_ds.Tables[0].Copy();
            bang.P_BO_COT(ref b_dt, "sott");
            bang.P_COPY_COL(ref b_dt, "sott", "stt");
            bang.P_BO_COT(ref b_dttk, "sott");
            bang.P_COPY_COL(ref b_dttk, "sott", "stt");
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            bang.P_SO_CNG(ref b_dttk, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            // các cột định dạng số bảng lương trong kỳ
            DataTable b_dttk_cot = tl_ch.Fdt_NS_TL_BLUONGTK_LKE_COTSO("SALE");
            for (int i = 0; i < b_dttk_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dttk_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dttk_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong))
            {
                bang.P_SO_CSO(ref b_dttk, cot_luong);
            }
            // các cột định dạng số bảng lương tổng hợp
            DataTable b_dt_cot = tl_ch.Fdt_NS_TL_BLUONG_LKE_COTSO("SALE");
            cot_luong = "";
            for (int i = 0; i < b_dt_cot.Rows.Count; i++)
            {
                if (i == 0) cot_luong = b_dt_cot.Rows[i]["ma"].ToString();
                else cot_luong = cot_luong + "," + b_dt_cot.Rows[i]["ma"].ToString();
            }
            if (!string.IsNullOrEmpty(cot_luong))
            {
                bang.P_SO_CSO(ref b_dt, cot_luong);
            }
            return (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count
                + "#" + (bang.Fb_TRANG(b_dttk) ? "" : bang.Fs_BANG_CH(b_dttk, a_cottk) + "#" + b_dttk.Rows.Count));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_MO(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            // Kiểm tra kỳ lương có được đóng vĩnh viên không?
            var tt_l = ht_dungchung.P_NS_CC_TRANGTHAI_KYLUONG_VV(b_phong, b_kyluong_id);
            if (tt_l == "1") return Thongbao_dch.KY_LUONG_DONG_VV;
            ht_dungchung.P_NS_TL_BLUONG_MO(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.MO_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_MO;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_DONG(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login); ht_dungchung.P_NS_TL_BLUONG_DONG(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_DONG;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_SALE_DONG_VV(string b_login, string b_phong, string b_kyluong_id)
    {
        try
        {
            se.P_LOGIN(b_login); ht_dungchung.P_NS_CC_TONGHOP_DONG_VV(b_phong, b_kyluong_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DONG_VV_BL, TEN_FORM.NS_TL_BLUONG, TEN_BANG.NS_TL_BLUONG);
            return Thongbao_dch.KY_LUONG_DONG_VV;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    #endregion BẢNG LƯƠNG KHỐI SALE TANVIET

    #region BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BB
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_BB_LKE(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_TL_BLUONG_BB_LKE(b_nam, b_kyluong_id, b_sothe, b_phong, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "thangtruoc_chuyensang,hoahong_traiphieu,thunhap_truocthue,thanhtoan_thangnay,xoa_no,truy_thu,chuyen_thangsau,thue_tncn,thuc_nhan");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_BB_TH(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong_id);
            if (tt == "0") return Thongbao_dch.Vuilong_dong_kycong;
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_BLUONG_BB, TEN_BANG.NS_TL_BLUONG_BB);
            tl_ch.Fs_NS_TL_BLUONG_BB_TH(b_nam, b_kyluong_id, b_sothe, b_phong);
            return Fs_NS_TL_BLUONG_BB_LKE(b_login, b_nam, b_kyluong_id, b_sothe, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BB

    #region BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BS
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_BS_LKE(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_TL_BLUONG_BS_LKE(b_nam, b_kyluong_id, b_sothe, b_phong, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "phi_gd_thucthu,tyle_hoahong,hoahong_hoptac,thangtruoc_chuyensang,truno_bhxh,truy_thu,hoahong_tienvay,hoahong_ir,hoahong_traiphieu,tong_thunhap_truocthue,thanhtoan_thangnay,chuyen_thangsau,thue_tncn,thuc_nhan");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_BS_TH(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong_id);
            if (tt == "0") return Thongbao_dch.Vuilong_dong_kycong;
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_BLUONG_BS, TEN_BANG.NS_TL_BLUONG_BS);
            tl_ch.Fs_NS_TL_BLUONG_BS_TH(b_nam, b_kyluong_id, b_sothe, b_phong);
            return Fs_NS_TL_BLUONG_BS_LKE(b_login, b_nam, b_kyluong_id, b_sothe, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BS

    #region BẢNG LƯƠNG THỰC TẬP SINH
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_TTS_LKE(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_TL_BLUONG_TTS_LKE(b_nam, b_kyluong_id, b_sothe, b_phong, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "tong_giocong,ovt,ovt_quydoi,cong_quydoi,dongia_giocong,dongia_ngaycong,thanh_tien,thue_tncn,thuc_nhan,tong_thuc_nhan");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_BLUONG_TTS_TH(string b_login, string b_nam, string b_kyluong_id, string b_sothe, string b_phong, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong_id);
            if (tt == "0") return Thongbao_dch.Vuilong_dong_kycong;
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_BLUONG_TTS, TEN_BANG.NS_TL_BLUONG_TTS);
            tl_ch.Fs_NS_TL_BLUONG_TTS_TH(b_nam, b_kyluong_id, b_sothe, b_phong);
            return Fs_NS_TL_BLUONG_TTS_LKE(b_login, b_nam, b_kyluong_id, b_sothe, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion BẢNG LƯƠNG THỰC TẬP SINH

    #region IMPORT LƯƠNG THÁNG
    [WebMethod(true)]
    public string Fs_DANHSACH_KYLUONG_LKE(string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.CSO_SO(b_nam));
            return bang.Fs_BANG_CH(b_dt, "ma,ten");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public void Fs_BANGLUONG_IMP_NH(DataTable b_dt_ct)
    {
        try
        {
            tl_ch.Fdt_BANGLUONG_IMP_NH(b_dt_ct);
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_BANGLUONG_IMP_LKE(string b_phong, string b_nhomluong, string b_kycong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Fdt_BANGLUONG_IMP_LKE(b_phong, b_nhomluong, chuyen.OBJ_N(b_kycong), b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "giatri");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region KHAI BÁO GIỮ LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_TL_GIULUONG_LKE(string b_login, string b_phong, string b_ten, string b_kycong, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Faobj_NS_TL_GIULUONG_LKE(b_phong, b_ten, b_kycong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "TIEN_LUONG,tien_giu");
            bang.P_SO_CNG(ref b_dt, "NGAY_TT");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_GIULUONG_CT(string b_login, string b_form, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = tl_ch.Fdt_NS_TL_GIULUONG_CT(b_so_id);
            DataTable b_dt2 = new DataTable();
            if (b_dt.Rows.Count > 0)
                b_dt2 = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_dt.Rows[0]["NAM"].ToString()));
            se.P_TG_LUU(b_form, "DT_KYLUONG", b_dt2.Copy());
            bang.P_TIM_THEM(ref b_dt, "tl_giuluong", "DT_KYLUONG", "KYLUONG");
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_GIULUONG_NH(string b_login, string b_so_id, string b_phong, string b_kyluong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tt");
            bang.P_CSO_SO(ref b_dt_ct, "KYLUONG,tien_luong,tien_giu");
            tl_ch.P_NS_TL_GIULUONG_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_GIULUONG, TEN_BANG.TL_GIULUONG);
            string b_so_the = mang.Fs_TEN_GTRI("SO_THE", a_cot, a_gtri);
            return Fs_NS_TL_GIULUONG_MA(b_login, b_so_the, b_phong, b_kyluong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_GIULUONG_XOA(string b_login, string b_so_id, string b_phong, string b_ten, string b_kycong, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); tl_ch.P_NS_TL_GIULUONG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_GIULUONG, TEN_BANG.TL_GIULUONG);
            return Fs_NS_TL_GIULUONG_LKE(b_login, b_phong, b_ten, b_kycong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_GET_LUONG_BY_SOTHE(string b_login, string b_so_the, string b_kyluong)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = tl_ch.Fdt_GET_LUONG_BY_SOTHE(b_so_the, b_kyluong);
            bang.P_SO_CSO(ref b_dt, "TIEN_LUONG");
            if (b_dt.Rows.Count > 0) return b_dt.Rows[0]["TIEN_LUONG"].ToString();
            else return "0";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_GIULUONG_MA(string b_login, string b_so_the, string b_phong, string b_kyluong, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = tl_ch.Fdt_NS_TL_GIULUONG_MA(b_so_the, b_phong, b_kyluong, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "SO_THE", b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region LƯƠNG XUÂN THÀNH
    [WebMethod(true)]
    public string Fs_TL_BLUONG_XUANTHANH_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_BLUONG_XUANTHANH_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_XUANTHANH_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_XUANTHANH_CT(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "luong_nn,luong_cv,doanhthu,luong_doanhthu,tong_luong,pcap,anca,tnhap_chiuthue,chenhca,phaitra_nld,pcd,bhxh,bhyt,bhtn,tnhapchiuthue,phuthuoc,tn_tinhthue,truthue,ktru_kchiuthue,thuc_linh");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_XUANTHANH_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_BLUONG_XUANTHANH_XOA(b_phong, b_thang); return Fs_TL_BLUONG_XUANTHANH_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_XUANTHANH_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            tl_ch.P_TL_BLUONG_XUANTHANH_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_TL_BLUONG_XUANTHANH_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_XUANTHANH_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_BLUONG_XUANTHANH_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region NGHỈ PHÉP
    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_LKE_CB(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_NS_TL_NGHIPHEP_LKE_CB(b_phong);
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_TINH(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = tl_ch.Fds_NS_TL_NGHIPHEP_TINH(b_phong, b_nam);
            object[] b_kq_obj = bang.Fobj_COL_MANG(b_ds.Tables[1], "title");
            string b_kq_title = chuyen.OBJ_S(b_kq_obj[0]) + ";" + chuyen.OBJ_S(b_kq_obj[1]) + ";" + chuyen.OBJ_S(b_kq_obj[2]) + ";" + chuyen.OBJ_S(b_kq_obj[3]) + ";" + chuyen.OBJ_S(b_kq_obj[4]) + ";" + chuyen.OBJ_S(b_kq_obj[5])
                 + ";" + chuyen.OBJ_S(b_kq_obj[6]) + ";" + chuyen.OBJ_S(b_kq_obj[7]) + ";" + chuyen.OBJ_S(b_kq_obj[8]) + ";" + chuyen.OBJ_S(b_kq_obj[9]) + ";" + chuyen.OBJ_S(b_kq_obj[10]) + ";" + chuyen.OBJ_S(b_kq_obj[11]);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_CSO_SO(ref b_dt, "sophepcon");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq_title + "#" + b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_TL_NGHIPHEP_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_CT(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = tl_ch.Fds_NS_TL_NGHIPHEP_CT(b_phong, b_nam);
            string b_dt_kq = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0);
            string b_dt_cot = (bang.Fb_TRANG(b_ds.Tables[1])) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_ds.Tables[1].Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_MA(string b_phong, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_NS_TL_NGHIPHEP_MA(b_phong, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_NH(double b_trangKT, string b_loai1, string b_loai2, string b_loai3, string b_loai4, string b_loai5, string b_loai6, string b_loai7, string b_loai8, string b_loai9, string b_loai10, string b_loai11, string b_loai12, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", ""); bang.P_BO_HANG(ref b_dt_ct, "phepnam", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            DataTable b_dt_loai = bang.Fdt_TAO_BANG(new string[] { "loai1", "loai2", "loai3", "loai4", "loai5", "loai6", "loai7", "loai8", "loai9", "loai10", "loai11", "loai12" }, new string[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" });
            bang.P_THEM_HANG(ref b_dt_loai, new object[] { b_loai1.Substring(b_loai1.Length - 2, 2), b_loai2.Substring(b_loai2.Length - 2, 2), b_loai3.Substring(b_loai3.Length - 2, 2), b_loai4.Substring(b_loai4.Length - 2, 2), b_loai5.Substring(b_loai5.Length - 2, 2), b_loai6.Substring(b_loai6.Length - 2, 2), b_loai7.Substring(b_loai7.Length - 2, 2), b_loai8.Substring(b_loai8.Length - 2, 2), b_loai9.Substring(b_loai9.Length - 2, 2), b_loai10.Substring(b_loai10.Length - 2, 2), b_loai11.Substring(b_loai11.Length - 2, 2), b_loai12.Substring(b_loai12.Length - 2, 2) });
            tl_ch.P_NS_TL_NGHIPHEP_NH(b_dt_loai, b_dt, b_dt_ct);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_NS_TL_NGHIPHEP_MA(b_phong, b_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_NGHIPHEP_XOA(string b_phong, string b_nam, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_NS_TL_NGHIPHEP_XOA(b_phong, b_nam); return Fs_NS_TL_NGHIPHEP_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NGHỈ PHÉP

    #region NGHỈ PHÉP NAGASE
    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_LKE_CB(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_NS_NGHIPHEP_NAGASE_LKE_CB(b_phong);
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_TINH(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = tl_ch.Fds_NS_NGHIPHEP_NAGASE_TINH(b_phong, b_nam);
            object[] b_kq_obj = bang.Fobj_COL_MANG(b_ds.Tables[1], "title");
            string b_kq_title = chuyen.OBJ_S(b_kq_obj[0]) + ";" + chuyen.OBJ_S(b_kq_obj[1]) + ";" + chuyen.OBJ_S(b_kq_obj[2]) + ";" + chuyen.OBJ_S(b_kq_obj[3]) + ";" + chuyen.OBJ_S(b_kq_obj[4]) + ";" + chuyen.OBJ_S(b_kq_obj[5])
                 + ";" + chuyen.OBJ_S(b_kq_obj[6]) + ";" + chuyen.OBJ_S(b_kq_obj[7]) + ";" + chuyen.OBJ_S(b_kq_obj[8]) + ";" + chuyen.OBJ_S(b_kq_obj[9]) + ";" + chuyen.OBJ_S(b_kq_obj[10]) + ";" + chuyen.OBJ_S(b_kq_obj[11]);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_CSO_SO(ref b_dt, "sophepcon");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq_title + "#" + b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_NGHIPHEP_NAGASE_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_CT(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = tl_ch.Fds_NS_NGHIPHEP_NAGASE_CT(b_phong, b_nam);
            string b_dt_kq = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0);
            string b_dt_cot = (bang.Fb_TRANG(b_ds.Tables[1])) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_ds.Tables[1].Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_MA(string b_phong, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_NS_NGHIPHEP_NAGASE_MA(b_phong, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_NH(double b_trangKT, string b_loai1, string b_loai2, string b_loai3, string b_loai4, string b_loai5, string b_loai6, string b_loai7, string b_loai8, string b_loai9, string b_loai10, string b_loai11, string b_loai12, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", ""); bang.P_BO_HANG(ref b_dt_ct, "phepnam", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            DataTable b_dt_loai = bang.Fdt_TAO_BANG(new string[] { "loai1", "loai2", "loai3", "loai4", "loai5", "loai6", "loai7", "loai8", "loai9", "loai10", "loai11", "loai12" }, new string[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S", "S" });
            bang.P_THEM_HANG(ref b_dt_loai, new object[] { b_loai1.Substring(b_loai1.Length - 2, 2), b_loai2.Substring(b_loai2.Length - 2, 2), b_loai3.Substring(b_loai3.Length - 2, 2), b_loai4.Substring(b_loai4.Length - 2, 2), b_loai5.Substring(b_loai5.Length - 2, 2), b_loai6.Substring(b_loai6.Length - 2, 2), b_loai7.Substring(b_loai7.Length - 2, 2), b_loai8.Substring(b_loai8.Length - 2, 2), b_loai9.Substring(b_loai9.Length - 2, 2), b_loai10.Substring(b_loai10.Length - 2, 2), b_loai11.Substring(b_loai11.Length - 2, 2), b_loai12.Substring(b_loai12.Length - 2, 2) });
            tl_ch.P_NS_NGHIPHEP_NAGASE_NH(b_dt_loai, b_dt, b_dt_ct);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_NS_NGHIPHEP_NAGASE_MA(b_phong, b_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_NGHIPHEP_NAGASE_XOA(string b_phong, string b_nam, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_NS_NGHIPHEP_NAGASE_XOA(b_phong, b_nam); return Fs_NS_NGHIPHEP_NAGASE_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NGHỈ PHÉP NAGASE

    #region BẢNG LƯƠNG NAGASE
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_TINH(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {

            string b_ngay = "01/" + b_thang;
            DataSet b_ds = tl_cc.Fdt_TEM_NGAY_NAGASE_LKE(b_thang, b_ngay, b_phong);
            string b_ngaylam = "";
            if (b_ds.Tables[0].Rows.Count > 0) b_ngaylam = b_ds.Tables[0].Rows[0]["ngaylam"].ToString();
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_VN_TINH(b_phong, b_thang, b_ngaylam);
            bang.P_SO_CSO(ref b_dt, "LUONGCU,NGHIKOLUONG,TIEN_KOLUONG,NGUOIPHUTHUOC,GIAMTRU,NGAY_LAMCU,DAYS,NORMALDAY,SALARYNETUSD,RATE,SALARYNETVND,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,ALLOWANCEVND,UNPAIDVND,INSURANCEFEE,TOTALPAY,TOTALNET,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,FAMILYSHUI,AFTERDECDUTION2,GROSSFORPIT2,PAYPIT2,MNETSALARY,GROSSUPSALARY,SALARYFORSOCIAL,CONTRIBUTION,SALARYFORUNEMPLOYMENT,UNEPLOYMENTINSURANCE,TOTALSHUI,GROSSSALARYVND");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_TINH(string b_phong, string b_thang, string b_tygia, string[] a_cot)
    {
        try
        {

            string b_ngay = "01/" + b_thang;
            DataSet b_ds = tl_cc.Fdt_TEM_NGAY_NAGASE_LKE(b_thang, b_ngay, b_phong);
            string b_ngaylam = "";
            if (b_ds.Tables[0].Rows.Count > 0) b_ngaylam = b_ds.Tables[0].Rows[0]["ngaylam"].ToString();
            chuyen.CSO_SO(b_tygia);
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_NN_TINH(b_phong, b_thang, b_ngaylam, b_tygia);
            bang.P_SO_CSO(ref b_dt, "LUONGCU,NGHIKOLUONG,TIEN_KOLUONG,NGUOIPHUTHUOC,GIAMTRU,NGAY_LAMCU,DAYS,NORMALDAY,SALARYNETUSD,RATE,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,UNPAIDUSD,INSURANCEFEE,TOTALPAY,TOTALNETUSD,TOTALNETVND,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,GROSSSALARYUSD");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_BLUONG_NAGASE_VN_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thangcc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_VN_CT(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "DAYS,NORMALDAY,SALARYNETUSD,RATE,SALARYNETVND,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,ALLOWANCEVND,UNPAIDVND,INSURANCEFEE,TOTALPAY,TOTALNET,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,FAMILYSHUI,AFTERDECDUTION2,GROSSFORPIT2,PAYPIT2,MNETSALARY,GROSSUPSALARY,SALARYFORSOCIAL,CONTRIBUTION,SALARYFORUNEMPLOYMENT,UNEPLOYMENTINSURANCE,TOTALSHUI,GROSSSALARYVND");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_BLUONG_NAGASE_VN_XOA(b_phong, b_thang); return Fs_TL_BLUONG_NAGASE_VN_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thangcc");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            tl_ch.P_TL_BLUONG_NAGASE_VN_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong_cp", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thangcc", a_cot, a_gtri);
            return Fs_TL_BLUONG_NAGASE_VN_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_VN_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_BLUONG_NAGASE_VN_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thangcc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thangcc", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    //NGUOI NUOC NGOAI

    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_TL_BLUONG_NAGASE_NN_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CTH(ref b_dt_tk, "thangcc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_CT(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_NN_CT(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "DAYS,NORMALDAY,SALARYNETUSD,RATE,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,UNPAIDUSD,INSURANCEFEE,TOTALPAY,TOTALNETUSD,TOTALNETVND,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,GROSSSALARYUSD");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count + "#" + b_dt.Rows[0]["RATE"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { tl_ch.P_TL_BLUONG_NAGASE_NN_XOA(b_phong, b_thang); return Fs_TL_BLUONG_NAGASE_NN_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thangcc");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            tl_ch.P_TL_BLUONG_NAGASE_NN_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong_cp", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thangcc", a_cot, a_gtri);
            return Fs_TL_BLUONG_NAGASE_NN_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_NN_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_TL_BLUONG_NAGASE_NN_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thangcc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thangcc", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region LƯƠNG CÁ NHÂN NAGASE
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_CN_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            //DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_CN_LKE(b_so_the);
            return "";// bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_BLUONG_NAGASE_CN_CT(string b_so_the, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TL_BLUONG_NAGASE_CN_CT(b_so_the, b_thang);
            bang.P_SO_CSO(ref b_dt, "GIATRI");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region LƯƠNG CÁ NHÂN
    [WebMethod(true)]
    public string Fs_TL_BLUONG_CN_LKE(string b_so_the, string b_kyluong, string b_dtuong, string[] a_cot)
    {
        try
        {
            object[] a_obj = tl_ch.Fdt_TL_BLUONG_CN_LKE(b_so_the, chuyen.OBJ_N(b_kyluong), b_dtuong);
            DataTable b_dt = (DataTable)a_obj[0];
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTLH_BLUONG_CN_LKE(string b_kyluong)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_TTLH_BLUONG_CN_LKE(b_kyluong);
            if (b_dt.Rows.Count > 0)
            {
                return b_dt.Rows[0]["NOIDUNG"].ToString() + "#" + b_dt.Rows[0]["THANG"].ToString() + "#" + b_dt.Rows[0]["NGAY"].ToString();
            }
            else return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THIẾT LẬP CÔNG THỨC LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_LKE(string a_nluong, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_Fs_TL_CT_LUONG_LKE(a_nluong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_DV_LKE(string b_nluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_Fs_TL_CT_LUONG_DV_LKE(b_nluong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_Fs_TL_CT_LUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_NH(string b_mact, string b_ct, int b_tt)
    {
        try
        {
            if (string.IsNullOrEmpty(b_mact))
            {
                return Thongbao_dch.ChonCongThuc;
            }
            tl_ch.P_Fs_TL_CT_LUONG_NH(b_mact, b_ct, b_tt);
            return Thongbao_dch.CapnhatThanhcong;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_KT(string b_ct)
    {
        try
        {
            tl_ch.P_Fs_TL_CT_LUONG_KT(b_ct);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.Saicuphap; }
    }

    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_CT(string b_ct, object[] a_dt_ct)
    {
        try
        {
            var kq = "";
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["chon"].Equals("X"))
                {
                    if (kq == "")
                    {
                        kq = "NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                    else
                    {
                        kq = kq + " + NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                }
            }
            return "#" + kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CT_LUONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_Fs_TL_CT_LUONG_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP CÔNG THỨC LƯƠNG

    #region THIẾT LẬP CÔNG THỨC CÔNG
    [WebMethod(true)]
    public string Fs_TL_CC_CONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_Fs_TL_CC_CONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CONG_DV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_Fs_TL_CC_CONG_DV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ch.Fdt_Fs_TL_CC_CONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CONG_NH(string b_mact, string b_ct, int b_tt)
    {
        try
        {
            if (string.IsNullOrEmpty(b_mact))
            {
                return Thongbao_dch.ChonCongThuc;
            }
            tl_ch.P_Fs_TL_CC_CONG_NH(b_mact, b_ct, b_tt);
            return Thongbao_dch.CapnhatThanhcong;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CONG_KT(string b_ct)
    {
        try
        {
            tl_ch.P_Fs_TL_CC_CONG_KT(b_ct);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.Saicuphap; }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CONG_CT(string b_ct, object[] a_dt_ct)
    {
        try
        {
            var kq = "";
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["chon"].Equals("X"))
                {
                    if (kq == "")
                    {
                        kq = "NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                    else
                    {
                        kq = kq + " + NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                }
            }
            return "#" + kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ch.P_Fs_TL_CC_CONG_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP CÔNG THỨC CÔNG

    #region IMPORT ĐÁNH GIÁ 360
    //lấy thông tin cán bộ theo kỳ
    [WebMethod(true)]
    public string Fdt_BC_DG360_TTCB(string b_form, string b_ky_dg, string b_ten_ktra)
    {
        DataTable b_dt = tl_ch.Fdt_BC_DG360_TTCB(b_ky_dg);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt.Copy());
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    //lấy thông tin cán bộ theo đối tượng
    [WebMethod(true)]
    public string Fdt_BC_DG360_TTCB_DTUONG(string b_form, string b_ky_dg, string b_dtuong, string b_ten_ktra)
    {
        DataTable b_dt = tl_ch.Fdt_BC_DG360_TTCB_DTUONG(b_ky_dg, b_dtuong);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt.Copy());
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    #endregion

    #region IMPORT DANH SÁCH THIẾU PHIẾU LỆNH
    [WebMethod(true)]
    public string Fs_NS_DSACH_THIEU_PLENH_LKE(string b_login, string b_nam, string b_kyluong_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.Fdt_NS_DSACH_THIEU_PLENH_LKE(b_nam, b_kyluong_id, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_DSACH_THIEU_PLENH_CT(string b_nam, string b_kydg, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_NS_DSACH_THIEU_PLENH_CT(b_nam, b_kydg);
            bang.P_SO_CSO(ref b_dt, "SO_PLENH_THIEU");
            return b_dt.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion IMPORT DANH SÁCH THIẾU PHIẾU LỆNH

    #region DANH SÁCH THIẾU GIẤY TỜ BẮT BUỘC 
    [WebMethod(true)]
    public string Fs_NS_DSACH_GIAYTO_BBUOC_LKE(string b_sothe, string b_hoten, string b_kyluong, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ch.FS_NS_DSACH_GIAYTO_BBUOC_LKE(b_sothe, b_hoten, b_kyluong, b_phong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            //bang.P_THAY_GTRI(ref b_dt, "trangthai", "C", "Có trả lương");
            //bang.P_THAY_GTRI(ref b_dt, "trangthai", "K", "Không trả lương");
            //bang.P_SO_CNG(ref b_dt, "ngayhl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_DSACH_GIAYTO_BBUOC_NH(string b_sothe, string b_hoten, string b_kyluong, string b_phong, double[] a_tso, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_grid)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] a_gtri = (object[])a_dt_grid[1];
            string thang_bd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[1])[0];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.ChuaChonBanGhiLuoi;
            }

            tl_ch.FS_NS_DSACH_GIAYTO_BBUOC_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DSACH_GIAYTO_BBUOC, TEN_BANG.NS_DSACH_GIAYTO_BBUOC);
            return Fs_NS_DSACH_GIAYTO_BBUOC_LKE(b_sothe, b_hoten, b_kyluong, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    #endregion DANH SÁCH THIẾU GIẤY TỜ BẮT BUỘC 

    #region IMPORT EMS
    [WebMethod(true)]
    public string Fs_TL_EMS_IMP_LKE(string b_phong, string b_kycong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ch.Fdt_TL_EMS_IMP_LKE(b_phong, b_kycong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "P_GD_TT,HQCV,DS,TTN_T_HQCV,T_PXMGXLV,HH_MG,HH_CS_GT_HT,CK_GT_HQCV,PH_5,DM_P_NSU,PHI_KHAC,T_PHI_HH,P_F1,P_F2,P_F3,P_FN,P_CTV,P_HH_MG_KHAC,HH_QLY,HH_MG_KHAC,HH_DNO,P_QLY,HH_MG_KHAC2");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion
}