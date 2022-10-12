using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;
[System.Web.Script.Services.ScriptService]
public class sns_tl : System.Web.Services.WebService
{
    #region MÃ NHÓM LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_TL_MA_NL_MA(string b_login, string b_ma_nn, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_NL_MA(b_ma, b_ma_nn, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma_nn", "ma" }, new string[] { b_ma_nn, b_ma });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_NL_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_NL_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "ns_tl_ma_cm", "DT_NN", "MA_NN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_NL_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_NL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_NL_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tl.P_NS_TL_MA_NL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri), b_ma_nn = mang.Fs_TEN_GTRI("ma_nn", a_cot, a_gtri);
            return Fs_NS_TL_MA_NL_MA(b_login, b_ma_nn, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_NL_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try { ns_tl.P_NS_TL_MA_NL_XOA(b_so_id); return Fs_NS_TL_MA_NL_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NHÓM LƯƠNG

    #region THIẾT LẬP ĐỐI TƯỢNG BẢNG LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_MA(string b_login, string b_so_id, string b_ma_bluong, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tl.Fdt_NS_TL_DTUONG_BLUONG_MA(b_so_id, b_ma_bluong, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BACK", "Bảng lương Back");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "SALE", "Bảng lương Sale");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BB", "Bảng lương BB");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BS", "Bảng lương BS");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "TTS", "Bảng lương thực tập sinh");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "SO_ID", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_CT(string b_login, double b_so_id, string[] a_cot_khoi, string[] a_cot_dtnv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_tl.Fds_NS_TL_DTUONG_BLUONG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0], b_dt_khoi = b_ds.Tables[1], b_dt_dtnv = b_ds.Tables[2];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_khoi_s = b_dt_khoi.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_khoi, a_cot_khoi);
            string b_dt_dtnv_s = b_dt_dtnv.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_dtnv, a_cot_dtnv);
            return b_dt_s + "#" + b_dt_khoi_s + "#" + b_dt_dtnv_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_LKE(string b_login, string b_ma_bluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tl.Fdt_NS_TL_DTUONG_BLUONG_LKE(b_ma_bluong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BACK", "Bảng lương Back");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "SALE", "Bảng lương Sale");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BB", "Bảng lương cộng tác viên BB");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "BS", "Bảng lương cộng tác viên BS");
            bang.P_THAY_GTRI(ref b_dt, "ten_bluong", "TTS", "Bảng lương thực tập sinh");
            return chuyen.OBJ_N(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_NH(string b_login, string b_so_id, object[] a_dt, object[] a_dt_khoi, object[] a_dt_dtnv, string b_ma_bluong, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CNG_SO(ref b_dt, "ngay_ad");

            string[] a_cot_dv = chuyen.Fas_OBJ_STR((object[])a_dt_khoi[0]);
            object[] a_gtri_dv = (object[])a_dt_khoi[1];
            DataTable b_dt_dv = bang.Fdt_TAO_THEM(a_cot_dv, a_gtri_dv);

            string[] a_cot_cn = chuyen.Fas_OBJ_STR((object[])a_dt_dtnv[0]);
            object[] a_gtri_cn = (object[])a_dt_dtnv[1];
            DataTable b_dt_cn = bang.Fdt_TAO_THEM(a_cot_cn, a_gtri_cn);

            ns_tl.PNS_TL_DTUONG_BLUONG_NH(ref b_so_id, b_dt, b_dt_dv, b_dt_cn);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_TL_DTUONG_BLUONG, TEN_BANG.NS_TL_DTUONG_BLUONG);
            return Fs_NS_TL_DTUONG_BLUONG_MA(b_login, b_so_id, b_ma_bluong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_XOA(string b_login, double b_so_id, string b_ma_bluong, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try
        {
            ns_tl.PNS_TL_DTUONG_BLUONG_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_TL_DTUONG_BLUONG, TEN_BANG.NS_TL_DTUONG_BLUONG);
            return Fs_NS_TL_DTUONG_BLUONG_LKE(b_login, b_ma_bluong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_LKE_DATA(string b_login, string[] a_cot_dtnv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_tl.Fds_NS_TL_DTUONG_BLUONG_LKE_DATA();
            DataTable b_dt_khoi = b_ds.Tables[0], b_dt_dtnv = b_ds.Tables[1];
            return bang.Fs_BANG_CH(b_dt_dtnv, a_cot_dtnv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_DTUONG_BLUONG_THEM(string b_login, string b_ma_khoi, string b_ten_khoi, object[] a_dt_dtnv, object[] a_dt_th)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            string[] a_cot_dtnv = chuyen.Fas_OBJ_STR((object[])a_dt_dtnv[0]);
            object[] a_gtri_dtnv = (object[])a_dt_dtnv[1];
            DataTable b_dt_dtnv = bang.Fdt_TAO_THEM(a_cot_dtnv, a_gtri_dtnv);

            string[] a_cot_th = chuyen.Fas_OBJ_STR((object[])a_dt_th[0]);
            object[] a_gtri_th = (object[])a_dt_th[1];
            DataTable b_dt_th = bang.Fdt_TAO_THEM(a_cot_th, a_gtri_th);

            bang.P_THEM_COL(ref b_dt_dtnv, new string[] { "Ma_khoi", "ten_khoi" }, new string[] { b_ma_khoi, b_ten_khoi });
            bang.P_BO_HANG(ref b_dt_dtnv, "CHON_DTNV", "");
            bang.P_BO_HANG(ref b_dt_th, "MA_KHOI", "");
            if (b_dt_dtnv.Rows.Count <= 0)
            {
                return Thongbao_dch.ChuaChonBanGhiLuoi;
            }

            //bang.Fdt_HANG_COT("MA_KHOI", b_dt_dtnv);
            foreach (DataRow dr in b_dt_dtnv.Rows)
            {
                bang.P_THEM_HANG(ref b_dt_th, new object[] { dr["ma_khoi"].ToString(), dr["ten_khoi"].ToString(), dr["ma_dtnv"].ToString(), dr["ten_dtnv"].ToString() }, 0);
            }
            return bang.Fs_BANG_CH(b_dt_th, a_cot_th);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion THIẾT LẬP ĐỐI TƯỢNG BẢNG LƯƠNG
     
    #region THIẾT LẬP DANH MỤC LƯƠNG
    [WebMethod(true)]
    public void Fs_NS_TL_MA_ML_XEM(string b_login, string b_form, string b_ma_dvi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_NL_XEM(b_ma_dvi);
            se.P_TG_LUU(b_form, "DT_DT", b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_ML_LKE(string b_login, string b_ma_dvi, string b_dtuong, double b_loai, double b_loai_ct, double b_bluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_ML_LKE(b_ma_dvi, b_dtuong, b_loai, b_loai_ct, b_bluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt, "ten_ap_dung_ct", "0", "Dữ liệu cơ bản");
            bang.P_THAY_GTRI(ref b_dt, "ten_ap_dung_ct", "1", "Dữ liệu đầu vào");
            bang.P_THAY_GTRI(ref b_dt, "ten_ap_dung_ct", "2", "Dữ liệu import");
            bang.P_THAY_GTRI(ref b_dt, "ten_ap_dung_ct", "3", "Dữ liệu tính toán");
            bang.P_THAY_GTRI(ref b_dt, "ten_ap_dung_ct", "9", "Chưa xếp nhóm");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_ML_MA(string b_login, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_ML_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_ML_NH(string b_login, double b_so_id, string b_ma_dvi, string b_dtuong, double b_loai, double b_loai_ct, double b_bluong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tl.P_NS_TL_MA_ML_NH(b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_TL_MA_ML, TEN_BANG.NS_TL_MA_ML);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TL_MA_ML_LKE(b_login, b_ma_dvi, b_dtuong, b_loai, b_loai_ct, b_bluong, a_tso, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_ML_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_ML_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "NS_TL_MA_ML", "DT_DT", "D_TUONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP DANH MỤC LƯƠNG

    #region  THIẾT LẬP CÔNG THỨC LƯƠNG
    [WebMethod(true)]
    public void Fs_NS_TL_MA_CTLUONG_DOITUONG_XEM(string b_login, string b_form, string b_ma_dvi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_NL_XEM(b_ma_dvi);
            se.P_TG_LUU(b_form, "DT_DT", b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_CTLUONG_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_CTLUONG_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "NS_TL_MA_CTLUONG", "DT_DT", "D_TUONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_CTLUONG_LKE(string b_login, string b_ma_dvi, string b_dtuong, double b_loai, double b_bluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_CTLUONG_LKE(b_ma_dvi, b_dtuong, b_loai, b_bluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            return a_obj[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_CTLUONG_LKE_DV(string b_login, string b_ma_dvi, string b_dtuong, double b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_MA_CTLUONG_LKE_DV(b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            return a_obj[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_CTLUONG_NH(string b_login, double b_so_id, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (b_so_id <= 0) return Thongbao_dch.ChonCongThuc;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tl.P_NS_TL_MA_CTLUONG_NH(b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_MA_CTLUONG, TEN_BANG.NS_TL_MA_CTLUONG);
            return Thongbao_dch.CapnhatThanhcong;
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_CTLUONG_KT(string b_login, double b_loai, string b_cotct, string b_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tl.P_NS_TL_MA_CTLUONG_KT(b_loai, b_cotct, b_ct);
            return "";
        }
        catch (Exception) { return Thongbao_dch.Saicuphap; }
    }
    #endregion THIẾT LẬP CÔNG THỨC LƯƠNG

    #region Thiết lập hỗ trợ ăn trưa theo vùng
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_VUNG_MA(string b_login, string b_vung, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            switch (b_vung)
            {
                case "Vùng 1": b_vung = "1"; break;
                case "Vùng 2": b_vung = "2"; break;
                case "Vùng 3": b_vung = "3"; break;
                case "Vùng 4": b_vung = "4"; break;
                default:
                    break;
            }
            object[] a_obj = ns_tl.Faobj_NS_TL_HTRO_ANTRUA_VUNG_MA(b_vung, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            b_dt.AcceptChanges();
            bang.P_SO_CNG(ref b_dt, "ten_ngay_hl,ngay_het_hl");
            bang.P_SO_CSO(ref b_dt, "hotro");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "vung", "ten_ngay_hl" }, new string[] { b_vung, b_ngay_hl });
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "1", "Vùng 1");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "2", "Vùng 2");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "3", "Vùng 3");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "4", "Vùng 4");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_VUNG_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_HTRO_ANTRUA_VUNG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_het_hl");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_VUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_HTRO_ANTRUA_VUNG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "hotro");
            bang.P_SO_CNG(ref b_dt, "ten_ngay_hl,ngay_het_hl");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "1", "Vùng 1");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "2", "Vùng 2");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "3", "Vùng 3");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "4", "Vùng 4");
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_VUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tl.P_NS_TL_HTRO_ANTRUA_VUNG_NH(b_dt_ct);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_TL_HTRO_ANTRUA_VUNG, TEN_BANG.NS_TL_HTRO_ANTRUA_VUNG);
            string b_vung = mang.Fs_TEN_GTRI("vung", a_cot, a_gtri), b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_TL_HTRO_ANTRUA_VUNG_MA(b_login, b_vung, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_VUNG_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try
        {
            ns_tl.P_NS_TL_HTRO_ANTRUA_VUNG_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_TL_HTRO_ANTRUA_VUNG, TEN_BANG.NS_TL_HTRO_ANTRUA_VUNG);
            return Fs_NS_TL_HTRO_ANTRUA_VUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Thiết lập phụ cấp theo vùng
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_MA(string b_login, string b_pcap, string b_vung, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            switch (b_vung)
            {
                case "Vùng 1": b_vung = "1"; break;
                case "Vùng 2": b_vung = "2"; break;
                case "Vùng 3": b_vung = "3"; break;
                case "Vùng 4": b_vung = "4"; break;
                default:
                    break;
            }
            object[] a_obj = ns_tl.Faobj_NS_TL_PC_VUNG_MA(b_pcap, b_vung, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            b_dt.AcceptChanges();
            bang.P_SO_CNG(ref b_dt, "ten_ngay_hl,ngay_het_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "vung", "ten_ngay_hl" }, new string[] { b_vung, b_ngay_hl });
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "1", "Vùng 1");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "2", "Vùng 2");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "3", "Vùng 3");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "4", "Vùng 4");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_CT(string b_form, string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_PC_VUNG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_het_hl");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_PCAP", "PCAP");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tl.Faobj_NS_TL_PC_VUNG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_SO_CNG(ref b_dt, "ten_ngay_hl,ngay_het_hl");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "1", "Vùng 1");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "2", "Vùng 2");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "3", "Vùng 3");
            bang.P_THAY_GTRI(ref b_dt, "ten_vung", "4", "Vùng 4");
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tl.P_NS_TL_PC_VUNG_NH(b_dt_ct);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_TL_PC_VUNG, TEN_BANG.NS_TL_PC_VUNG);
            string b_pcap = mang.Fs_TEN_GTRI("pcap", a_cot, a_gtri), b_vung = mang.Fs_TEN_GTRI("vung", a_cot, a_gtri), b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_TL_PC_VUNG_MA(b_login, b_pcap, b_vung, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try
        {
            ns_tl.P_NS_TL_PC_VUNG_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_TL_PC_VUNG, TEN_BANG.NS_TL_PC_VUNG);
            return Fs_NS_TL_PC_VUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_VUNG_PCAP(string b_login, string b_pcap)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Faobj_NS_TL_PC_VUNG_PCAP(b_pcap);
            b_dt.AcceptChanges();
            var b_sotien = "";
            var b_loaihuong = "";
            if (b_dt.Rows.Count > 0)
            {
                var b_dr = b_dt.Rows[0];
                b_sotien = b_dr["sotien"].ToString();
                b_loaihuong = b_dr["hinhthuc"].ToString();
            }
            return b_sotien + "#" + b_loaihuong;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THIẾT LẬP ĂN TRƯA THEO PHÒNG
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_CT(string b_so_id, string[] a_cot_ct, string[] a_cot_dvi)
    {
        try
        {
            DataSet b_ds = ns_tl.Fdt_NS_TL_HTRO_ANTRUA_PHONG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_nv = b_ds.Tables[1]; DataTable b_dt_dv = b_ds.Tables[2];
            bang.P_SO_CNG(ref b_dt, new string[] { "ng_hluc,ng_het_hluc" });
            bang.P_SO_CSO(ref b_dt_dv, "so_tien");
            //bang.P_TIM_THEM(ref b_dt, "ns_tl_htro_antrua_phong", "DT_PHONG_TK", "PHONG_TK");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_ct),
                   b_dt_dvi_s = bang.Fb_TRANG(b_dt_dv) ? "" : bang.Fs_BANG_CH(b_dt_dv, a_cot_dvi);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dv.Rows.Count + "#" + b_dt_dvi_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DT_NS_CB(string b_phong, string b_lke, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tl.Fdt_DT_NS_CB(b_phong, b_lke, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_P_NV(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt_tk = ht_dungchung.Fdt_NS_THONGTIN_CANBO_QD(b_phong, 0);
            bang.P_THEM_COL(ref b_dt_tk, "tt");
            return chuyen.OBJ_S(1) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tl.Fdt_NS_TL_HTRO_ANTRUA_PHONG_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ng_hluc,ng_het_hluc");
            bang.P_SO_CSO(ref b_dt_tk, "sotien");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_MA(string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tl.Fdt_NS_TL_HTRO_ANTRUA_PHONG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_het_hluc");
            bang.P_SO_CSO(ref b_dt, "sotien");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            //int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NG_HLUC", "NG_HET_HLUC" }, new object[] { ng_hluc,ng_het_hluc});
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, object[] a_dt_dvi, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt, "ng_hluc,ng_het_hluc");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            string[] a_cot_dvi = chuyen.Fas_OBJ_STR((object[])a_dt_dvi[0]); object[] a_gtri_dvi = (object[])a_dt_dvi[1];
            DataTable b_dt_dvi = bang.Fdt_TAO_THEM(a_cot_dvi, a_gtri_dvi);
            bang.P_CSO_SO(ref b_dt_dvi, "stt,so_tien");

            for (int j = 0; j < b_dt_ct.Rows.Count; j++)
            {
                b_dt_ct.Rows[j]["tt"] = j + 1;
            }
            ns_tl.P_NS_TL_HTRO_ANTRUA_PHONG_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_dvi);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_TL_HTRO_ANTRUA_PHONG, TEN_BANG.NS_TL_HTRO_ANTRUA_PHONG);
            //string ng_hluc =mang.Fs_TEN_GTRI("NG_HLUC", a_cot, a_gtri);
            //string ng_het_hluc = mang.Fs_TEN_GTRI("NG_HET_HLUC", a_cot, a_gtri);
            return Fs_NS_TL_HTRO_ANTRUA_PHONG_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_HTRO_ANTRUA_PHONG_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tl.PNS_TL_HTRO_ANTRUA_PHONG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.TL_DT_CMD, TEN_BANG.TL_DT_CMD);
            return Fs_NS_TL_HTRO_ANTRUA_PHONG_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region THIẾT LẬP PHỤ CẤP
    [WebMethod(true)]
    public string Fs_NS_TL_PC_CT(string b_so_id, string[] a_cot_ct_pb, string[] a_cot_ct_cd, string[] a_cot_ct_td, string[] a_cot_ct_nv)
    {
        try
        {
            DataSet b_ds = ns_tl.Fdt_NS_TL_PC_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_pb = b_ds.Tables[1];
            DataTable b_dt_cd = b_ds.Tables[2];
            DataTable b_dt_td = b_ds.Tables[3];
            DataTable b_dt_nv = b_ds.Tables[4];
            bang.P_SO_CNG(ref b_dt, new string[] { "ng_hluc,ng_het_hluc" });
            bang.P_SO_CTH(ref b_dt, "tuthang,denthang");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_TIM_THEM(ref b_dt, "NS_TL_PC", "DT_PCAP", "MA_PC");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_pb_s = bang.Fb_TRANG(b_dt_pb) ? "" : bang.Fs_BANG_CH(b_dt_pb, a_cot_ct_pb),
                   b_dt_cd_s = bang.Fb_TRANG(b_dt_cd) ? "" : bang.Fs_BANG_CH(b_dt_cd, a_cot_ct_cd),
                   b_dt_td_s = bang.Fb_TRANG(b_dt_td) ? "" : bang.Fs_BANG_CH(b_dt_td, a_cot_ct_td),
                   b_dt_nv_s = bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_ct_nv);
            return b_dt_s + "#" + b_dt_pb_s + "#" + b_dt_cd_s + "#" + b_dt_td_s + "#" + b_dt_nv_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_PC_LKE(double[] a_tso, string[] a_cot, string[] a_cot_pb, string[] a_cot_cd, string[] a_cot_td)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tl.Fdt_NS_TL_PC_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            DataTable b_dt_pb = (DataTable)a_object[2];
            DataTable b_dt_cd = (DataTable)a_object[3];
            DataTable b_dt_td = (DataTable)a_object[4];
            bang.P_SO_CNG(ref b_dt_tk, "ng_hluc,ng_het_hluc");
            bang.P_SO_CSO(ref b_dt_tk, "sotien");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_pb, a_cot_pb) + "#" + bang.Fs_BANG_CH(b_dt_cd, a_cot_cd) + "#" + bang.Fs_BANG_CH(b_dt_td, a_cot_td);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_MA(string b_ma_pc, string b_ng_hluc, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tl.Fdt_NS_TL_PC_MA(b_ma_pc, b_ng_hluc, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_het_hluc");
            bang.P_SO_CSO(ref b_dt, "sotien");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma_pc", "ng_hluc" }, new string[] { b_ma_pc, b_ng_hluc });
            //int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NG_HLUC", "NG_HET_HLUC" }, new object[] { ng_hluc,ng_het_hluc});
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_PC_NH(double b_trangKT, string b_so_id, string b_thietlap, object[] a_dt, object[] a_dt_nv, object[] a_dt_td, object[] a_dt_pb, object[] a_dt_cd, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ng_hluc,ng_het_hluc");
            bang.P_CTH_SO(ref b_dt, "tuthang,denthang");
            bang.P_CSO_SO(ref b_dt, "sotien");

            string[] a_cot_nv = chuyen.Fas_OBJ_STR((object[])a_dt_nv[0]); object[] a_gtri_nv = (object[])a_dt_nv[1];
            DataTable b_dt_nv = bang.Fdt_TAO_THEM(a_cot_nv, a_gtri_nv);
            bang.P_BO_HANG(ref b_dt_nv, "so_the", "");

            if (b_thietlap == "NV")
            {
                if (b_dt_nv == null || b_dt_nv.Rows.Count <= 0)
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
                for (int j = 0; j < b_dt_nv.Rows.Count; j++)
                {
                    b_dt_nv.Rows[j]["tt"] = j + 1;
                }
            }


            string[] a_cot_td = chuyen.Fas_OBJ_STR((object[])a_dt_td[0]); object[] a_gtri_td = (object[])a_dt_td[1];
            DataTable b_dt_td = bang.Fdt_TAO_THEM(a_cot_td, a_gtri_td);
            bang.P_BO_HANG(ref b_dt_td, "ma", "");
            bang.P_BO_HANG(ref b_dt_td, "chon", "");

            string[] a_cot_pb = chuyen.Fas_OBJ_STR((object[])a_dt_pb[0]); object[] a_gtri_pb = (object[])a_dt_pb[1];
            DataTable b_dt_pb = bang.Fdt_TAO_THEM(a_cot_pb, a_gtri_pb);
            bang.P_BO_HANG(ref b_dt_pb, "ma", "");
            bang.P_BO_HANG(ref b_dt_pb, "chon", "");

            string[] a_cot_cd = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]); object[] a_gtri_cd = (object[])a_dt_cd[1];
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot_cd, a_gtri_cd);
            bang.P_BO_HANG(ref b_dt_cd, "ma", "");
            bang.P_BO_HANG(ref b_dt_cd, "chon", "");

            bang.P_THEM_HANG(ref b_dt_nv, new object[] { 0, "", "", "", "" }, 0);
            bang.P_THEM_HANG(ref b_dt_td, new object[] { "", "", "" }, 0);
            bang.P_THEM_HANG(ref b_dt_pb, new object[] { "", "", "" }, 0);
            bang.P_THEM_HANG(ref b_dt_cd, new object[] { "", "", "" }, 0);



            ns_tl.P_NS_TL_PC_NH(ref b_so_id, b_dt, b_dt_pb, b_dt_cd, b_dt_td, b_dt_nv);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_TL_PC, TEN_BANG.NS_TL_PC);
            string ma_pc = mang.Fs_TEN_GTRI("ma_pc", a_cot, a_gtri);
            string ng_hluc = mang.Fs_TEN_GTRI("NG_HLUC", a_cot, a_gtri);
            return Fs_NS_TL_PC_MA(ma_pc, ng_hluc, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PC_XOA(string b_so_id, double[] a_tso, string[] a_cot, string[] a_cot_pb, string[] a_cot_cd, string[] a_cot_td)
    {
        try
        {
            ns_tl.PNS_TL_PC_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_TL_PC, TEN_BANG.NS_TL_PC);

            return Fs_NS_TL_PC_LKE(a_tso, a_cot, a_cot_pb, a_cot_cd, a_cot_td);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion
}