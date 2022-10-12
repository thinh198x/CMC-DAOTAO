using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;


[System.Web.Script.Services.ScriptService]
public class stl_ma : System.Web.Services.WebService
{
    #region HỆ SỐ LÀM THÊM
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_CC_HSO_LTHEM_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_CC_HSO_LTHEM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_HSO_LTHEM_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_CC_HSO_LTHEM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_HSO_LTHEM_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_CC_HSO_LTHEM_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.TL_TLAP_LAMTHEM, TEN_BANG.TL_TLAP_LAMTHEM);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri); ;
            return Fs_NS_CC_HSO_LTHEM_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_HSO_LTHEM_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_CC_HSO_LTHEM_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.TL_TLAP_LAMTHEM, TEN_BANG.TL_TLAP_LAMTHEM);
            return Fs_NS_CC_HSO_LTHEM_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion HỆ SỐ LÀM THÊM

    #region THÔNG SỐ PHÉP BÙ
    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSPB_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "tham_nien,phep_tang");
            bang.P_CNG_SO(ref b_dt, "ngay_hl");
            bang.P_CNG_SO(ref b_dt, "ngay_cp,ngay_cpb");
            b_so_id = tl_ma.P_NS_CC_MA_TSPB_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_CC_MA_TSPB, TEN_BANG.NS_CC_MA_TSPB);
            return Fs_NS_CC_MA_TSPB_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSPB_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ma.Faobj_NS_CC_MA_TSPB_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_cp,ngay_cpb");
            bang.P_SO_CSO(ref b_dt, "tham_nien,phep_tang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSPB_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ma.Faobj_NS_CC_MA_TSPB_LKE(b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_hl");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSPB_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_NS_CC_MA_TSPB_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_cp,ngay_cpb");
            bang.P_SO_CSO(ref b_dt, "tham_nien,phep_tang");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSPB_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_NS_CC_MA_TSPB_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_CC_MA_TSPB, TEN_BANG.NS_CC_MA_TSPB);
            return Fs_NS_CC_MA_TSPB_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THÔNG SỐ PHÉP BÙ

    #region CHẤM CÔNG ĐẶC BIỆT

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDB_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_hl");
            b_so_id = tl_ma.P_NS_CC_MA_CCDB_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_CC_MA_CCDB, TEN_BANG.NS_CC_MA_CCDB);
            return Fs_NS_CC_MA_CCDB_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDB_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ma.Faobj_NS_CC_MA_CCDB_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDB_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ma.Faobj_NS_CC_MA_CCDB_LKE(b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_hl");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDB_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = tl_ma.Fdt_NS_CC_MA_CCDB_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            // bang.P_TIM_THEM(ref b_dt, "ns_cc_ma_ccdb", "DT_NCB", "NCB");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_ma_ccdb", "DT_CDANH", "CDANH");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDB_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_NS_CC_MA_CCDB_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_CC_MA_CCDB, TEN_BANG.NS_CC_MA_CCDB);
            return Fs_NS_CC_MA_CCDB_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHẤM CÔNG ĐẶC BIỆT

    #region THIẾT LẬP TỶ LỆ LÀM THÊM
    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_GT(string[] a_cot)
    {
        try
        {
            DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten", "mota", "lamthem", "lamdem" }, new string[] { "S", "S", "S", "N", "N" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "LT_T", "1. Ngày thường", "ngày thường", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "LT_C", "2. Ngày cuối tuần", "cuối tuần", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "LT_L", "3. Ngày lễ", "ngày lễ", "", "" });
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_LAMTHEM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_LAMTHEM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_LAMTHEM_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ma", "");
            for (int i = 0; i < b_dt_dk.Rows.Count; i++)
            {
                if (b_dt_dk.Rows[i]["lamthem"].ToString().Equals("") || b_dt_dk.Rows[i]["lamdem"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }

            tl_ma.P_TL_TLAP_LAMTHEM_NH(b_so_id, b_dt_ct, b_dt_dk);
            string b_ngayd = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_LAMTHEM_MA(b_ngayd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMTHEM_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_LAMTHEM_XOA(b_so_id); return Fs_TL_TLAP_LAMTHEM_LKE(a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP TỶ LỆ LÀM THÊM

    #region MÃ THAM SỐ LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_MA_TSL_CT(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_TSL_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_TSL_NH(object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_TSL_NH(b_dt, b_dt_ct);
            DataTable b_kq = tl_ma.Fdt_TL_MA_TSL_LKE();
            bang.P_SO_CNG(ref b_kq, "ngayd"); bang.P_XEP(ref b_kq, "ma", "ma_ct");
            return bang.Fb_TRANG(b_kq) ? "" : bang.Fs_BANG_CH(b_kq, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_TSL_XOA(string b_ma)
    {
        try
        {
            tl_ma.P_TL_MA_TSL_XOA(b_ma);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region MÃ BIỂU THUẾ
    [WebMethod(true)]
    public string Fs_TL_MA_BT_CT(string b_ngayd, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_BT_CT(b_ngayd);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_BT_NH(string b_ngayd, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_BT_NH(b_ngayd, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region MÃ HỆ SỐ DOANH THU
    [WebMethod(true)]
    public string Fs_NS_TL_MA_HSDT_CT(string b_ngayd, string b_lcv, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_MA_HSDT_CT(b_ngayd, b_lcv);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_HSDT_NH(string b_ngayd, string b_lcv, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_NS_TL_MA_HSDT_NH(b_ngayd, b_lcv, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_HSDT_XOA(string b_ngayd, string b_lcv)
    {
        try
        {
            tl_ma.P_NS_TL_MA_HSDT_XOA(b_ngayd, b_lcv);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region MÃ NGHIỆP VỤ LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_MA_NV_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_NS_TL_MA_NV_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_NV_XOA(string b_ma)
    {
        try
        {
            tl_ma.P_NS_TL_MA_NV_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ PHƯƠNG PHÁP
    [WebMethod(true)]
    public string Fs_NS_TL_MA_PP_NH(string b_ten, object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_THEM_COL(ref b_dt_ct, "ten", "N'" + b_ten);
            tl_ma.P_NS_TL_MA_PP_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_MA_PP_XOA(string b_ma, string b_ngayd)
    {
        try
        {
            tl_ma.P_NS_TL_MA_PP_XOA(b_ma, b_ngayd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region THIẾT LẬP TỶ LỆ THU BẢO HIỂM
    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_GT(string[] a_cot)
    {
        try
        {
            DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten", "nguoi_ld", "nguoi_sdld" }, new string[] { "S", "S", "N", "N" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "BHXH", "1. BH Xã Hội", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "BHYT", "2. BH Y Tế", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "BHTN", "3. BH Thất Nghiệp", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "PCD", "4. Phí Công Đoàn", "", "" });
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_BH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_BH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_BH_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ma", "");
            for (int i = 0; i < b_dt_dk.Rows.Count; i++)
            {
                if (b_dt_dk.Rows[i]["nguoi_ld"].ToString().Equals("") || b_dt_dk.Rows[i]["nguoi_sdld"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            tl_ma.P_TL_TLAP_BH_NH(b_so_id, b_dt_ct, b_dt_dk);
            string b_ngayd = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_BH_MA(b_ngayd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_BH_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_BH_XOA(b_so_id); return Fs_TL_TLAP_BH_LKE(a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP TỶ LỆ THU BẢO HIỂM

    #region THIẾT LẬP THUẾ THU NHẬP CÁ NHÂN
    [WebMethod(true)]
    public string Fs_TL_TLAP_THUE_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_THUE_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_COPY_COL(ref b_dt, "TEN_DT_CUTRU", "DT_CUTRU");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "CT", "Đối tượng cư trú");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "KCT", "Đối tượng không cư trú");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THUE_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_THUE_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            bang.P_COPY_COL(ref b_dt, "TEN_DT_CUTRU", "DT_CUTRU");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "CT", "Đối tượng cư trú");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "KCT", "Đối tượng không cư trú");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_THUE_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_THUE_CT(b_so_id);
            bang.P_SO_CSO(ref b_dt, new string[] { "thunhaptu", "thunhapden" });
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THUE_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null)
                b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else
            {
                b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
                bang.P_DON(ref b_dt_dk);
            }
            bang.P_BO_HANG(ref b_dt_dk, "thunhaptu", "");
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            double b_tu = 0, b_den = 0, b_gtri = 0;

            for (int i = 0; i < b_dt_dk.Rows.Count; i++)
            {
                if (b_dt_dk.Rows[i]["thunhaptu"].ToString().Equals("") || b_dt_dk.Rows[i]["thunhapden"].ToString().Equals("") || b_dt_dk.Rows[i]["thuesuat"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            for (int i = 0; i < b_dt_dk.Rows.Count; i++)
            {
                b_tu = chuyen.CSO_SO(b_dt_dk.Rows[i]["thunhaptu"].ToString());
                b_den = chuyen.CSO_SO(b_dt_dk.Rows[i]["thunhapden"].ToString());
                b_gtri = chuyen.CSO_SO(b_dt_dk.Rows[i]["thuesuat"].ToString());

                if (b_den <= b_tu)
                {
                    return Thongbao_dch.ThuNhap_NhoHon_Bang;
                }
                if (b_tu < 0 || b_den <= 0 || b_gtri < 0)
                {
                    return "loi:Thu nhập từ hoặc thu nhập đến hoặc thuế suất không được nhỏ hơn 0:loi";
                }
            }
            tl_ma.P_TL_TLAP_THUE_NH(b_so_id, b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_TLAP_THUE, TEN_BANG.TL_TLAP_THUE);
            string b_ngayd = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_THUE_MA(b_ngayd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_THUE_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_THUE_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_TLAP_THUE, TEN_BANG.TL_TLAP_THUE);
            return Fs_TL_TLAP_THUE_LKE(a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP THUẾ THU NHẬP CÁ NHÂN

    #region THIẾT LẬP LƯƠNG TỐI THIỂU (NHÀ NƯỚC)
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGNN_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_LUONGNN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGNN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_LUONGNN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGNN_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_LUONGNN_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGNN_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_LUONGNN_NH(b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_LUONGNN_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGNN_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_LUONGNN_XOA(b_ngay); return Fs_TL_TLAP_LUONGNN_LKE(a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP LƯƠNG TỐI THIỂU (NHÀ NƯỚC)

    #region THIẾT LẬP LƯƠNG TỐI THIỂU (CÔNG TY)
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGCT_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_LUONGCT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGCT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_LUONGCT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGCT_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_LUONGCT_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGCT_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_LUONGCT_NH(b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_LUONGCT_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LUONGCT_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_LUONGCT_XOA(b_ngay); return Fs_TL_TLAP_LUONGCT_LKE(a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP LƯƠNG TỐI THIỂU (CÔNG TY)

    #region THIẾT LẬP GIẢM TRỪ GIA CẢNH
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_GTRU_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_GTRU_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_GTRU_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_GTRU_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_TLAP_GTRU, TEN_BANG.TL_TLAP_GTRU);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_GTRU_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_GTRU_XOA(b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_TLAP_GTRU, TEN_BANG.TL_TLAP_GTRU);
            return Fs_TL_TLAP_GTRU_LKE(a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP GIẢM TRỪ GIA CẢNH

    #region THIẾT LẬP GIẢM TRỪ BẢN THÂN
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_BANTHAN_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_GTRU_BANTHAN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_BANTHAN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_GTRU_BANTHAN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_BANTHAN_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_GTRU_BANTHAN_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_BANTHAN_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_GTRU_BANTHAN_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_TLAP_GTRU_BANTHAN, TEN_BANG.NS_MA_PHUCLOI);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_GTRU_BANTHAN_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_GTRU_BANTHAN_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_GTRU_BANTHAN_XOA(b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_TLAP_GTRU_BANTHAN, TEN_BANG.NS_MA_PHUCLOI);
            return Fs_TL_TLAP_GTRU_BANTHAN_LKE(a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP GIẢM TRỪ BẢN THÂN

    #region THIẾT LẬP PHỤ CẤP
    [WebMethod(true)]
    public string Fs_TL_TLAP_PCAP_LKE(string[] a_cot, double[] a_tso, string b_day)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_PCAP_LKE(b_tu_n, b_den_n, b_day); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_PCAP_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_PCAP_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_PCAP_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "giatri");
            bang.P_CNG_SO(ref b_dt_ct, "ngay");
            string b_ma = "";
            tl_ma.P_TL_TLAP_PCAP_NH(b_dt_ct, ref b_ma);
            return Fs_TL_TLAP_PCAP_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_PCAP_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_PCAP_XOA(b_ma); return Fs_TL_TLAP_PCAP_LKE(a_cot, a_tso, ""); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP PHỤ CẤP

    #region MÃ CÔNG VIỆC

    [WebMethod(true)]
    public string Fs_TL_MA_CONGVIEC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_CONGVIEC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_CONGVIEC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_CONGVIEC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_CONGVIEC_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_TL_MA_CONGVIEC_CT(b_ma);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "gia");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_CONGVIEC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_CONGVIEC_NH(b_dt_ct);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_MA_CONGVIEC, TEN_BANG.TL_MA_CONGVIEC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_CONGVIEC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_CONGVIEC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_MA_CONGVIEC_XOA(b_ma);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_MA_CONGVIEC, TEN_BANG.TL_MA_CONGVIEC);
            return Fs_TL_MA_CONGVIEC_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ CÔNG VIỆC

    #region MÃ SẢN PHẨM
    [WebMethod(true)]
    public string Fs_TL_MA_SPHAM_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_SPHAM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_SPHAM_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_SPHAM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_SPHAM_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_SPHAM_NH(b_dt_ct);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_MA_SPHAM, TEN_BANG.TL_MA_SPHAM);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_SPHAM_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_SPHAM_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_MA_SPHAM_XOA(b_ma);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_MA_SPHAM, TEN_BANG.TL_MA_SPHAM);
            return Fs_TL_MA_SPHAM_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ CHẤT LƯỢNG
    [WebMethod(true)]
    public string Fs_TL_MA_CHATLUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_CHATLUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_CHATLUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_CHATLUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_CHATLUONG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_CHATLUONG_NH(b_dt_ct);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_MA_CHATLUONG, TEN_BANG.TL_MA_CHATLUONG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_CHATLUONG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_CHATLUONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_MA_CHATLUONG_XOA(b_ma);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_MA_CHATLUONG, TEN_BANG.TL_MA_CHATLUONG);
            return Fs_TL_MA_CHATLUONG_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHẤT LƯỢNG

    #region MÃ ĐƠN GIÁ

    [WebMethod(true)]
    public string Fs_TL_MA_DONGIA_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_DONGIA_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "dongia");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_DONGIA_MA(string b_masp, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_DONGIA_MA(b_masp, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "dongia");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "masp", "ngay" }, new string[] { b_masp, b_ngay });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_DONGIA_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_DONGIA_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "dongia");
            bang.P_TIM_THEM(ref b_dt, "tl_ma_dongia", "DT_SP", "masp");
            string b_kq = bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_GOP(b_dt);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_DONGIA_NH(string b_so_id, double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];

            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay");
            bang.P_CSO_SO(ref b_dt, "dongia");
            tl_ma.P_TL_MA_DONGIA_NH(ref b_so_id, b_dt);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_MA_DONGIA, TEN_BANG.TL_MA_DONGIA);
            string b_masp = mang.Fs_TEN_GTRI("masp", a_cot, a_gtri);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_MA_DONGIA_MA(b_masp, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_DONGIA_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_MA_DONGIA_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_MA_DONGIA, TEN_BANG.TL_MA_DONGIA);
            return Fs_TL_MA_DONGIA_LKE(a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion MÃ ĐƠN GIÁ

    #region MÃ HÌNH THỨC HƯỞNG
    [WebMethod(true)]
    public string Fs_TL_MA_HTHUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_HTHUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_HTHUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_HTHUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_HTHUONG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_HTHUONG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_HTHUONG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_HTHUONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_MA_HTHUONG_XOA(b_ma); return Fs_TL_MA_HTHUONG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ HUY HIỆU ĐẢNG

    #region THIẾT LẬP THƯỞNG SẢN PHẨM
    [WebMethod(true)]
    public string Fs_TL_TLAP_SPTHUONG_CT(string b_ma, string b_cap)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_SPTHUONG_CT(b_ma, b_cap);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_SPTHUONG_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_SPTHUONG_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_SPTHUONG_XOA(string b_ma, string b_cap)
    {
        try
        {
            tl_ma.P_TL_TLAP_SPTHUONG_XOA(b_ma, b_cap);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion THIẾT LẬP THƯỞNG SẢN PHẨM

    #region THIẾT LẬP THỜI LƯỢNG LÀM VIỆC
    [WebMethod(true)]
    public string Fs_TL_TLAP_THOILUONG_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_THOILUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THOILUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_THOILUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngayd", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THOILUONG_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_THOILUONG_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngay_qd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THOILUONG_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngay_qd"); bang.P_DON(ref b_dt_ct);
            tl_ma.P_TL_TLAP_THOILUONG_NH(b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngayd", a_cot, a_gtri);
            return Fs_TL_TLAP_THOILUONG_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_THOILUONG_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TLAP_THOILUONG_XOA(b_ngay); return Fs_TL_TLAP_THOILUONG_LKE(a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP THỜI LƯỢNG LÀM VIỆC

    #region MÃ CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_CC_MA_CC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_CC_MA_CC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_trangthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["trangthai"]) == "N") b_dr["ten_trangthai"] = "Ngừng áp dụng";
                else b_dr["ten_trangthai"] = "Áp dụng";
            }
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_MA_CC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_CC_MA_CC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_trangthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["trangthai"]) == "N") b_dr["ten_trangthai"] = "Ngừng áp dụng";
                else b_dr["ten_trangthai"] = "Áp dụng";
            }
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_CC_CT(string b_ma, string[] a_cot)
    {
        try
        {
            DataSet b_ds = tl_ma.Fdt_CC_MA_CC_CT(b_ma);
            DataTable b_dtct = b_ds.Tables[0];
            bang.P_TIM_THEM(ref b_dtct, "cc_ma_cc", "DT_CC", "SANG");
            bang.P_TIM_THEM(ref b_dtct, "cc_ma_cc", "DT_CC", "CHIEU");
            DataTable b_dtcot = b_ds.Tables[1];
            string b_kq = (bang.Fb_TRANG(b_ds.Tables[0])) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0);
            string b_dt_cot = (bang.Fb_TRANG(b_ds.Tables[1])) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_CC_NH(double b_trangKT, object[] a_dt_ct, object[] a_dt_pc, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_pc[0]); object[] a_gtri_pc = (object[])a_dt_pc[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc);
            bang.P_BO_HANG(ref b_dt_pc, "mapc", ""); bang.P_DON(ref b_dt_pc);
            if (b_dt_pc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_pc, new object[] { "-1", "-1", "-1" });
            bang.P_CSO_SO(ref b_dt_pc, "hso");
            tl_ma.P_CC_MA_CC_NH(b_dt_ct, b_dt_pc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.CC_MA_CC, TEN_BANG.CC_MA_CC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_CC_MA_CC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_CC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_CC_MA_CC_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.CC_MA_CC, TEN_BANG.CC_MA_CC);
            return Fs_CC_MA_CC_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region THIẾT LẬP KIỂU CÔNG
    [WebMethod(true)]
    public string Fs_CC_MA_TL_CC_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ma.Faobj_CC_MA_TL_CC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "loaicong", "loai");
            bang.P_THAY_GTRI(ref b_dt, "loaicong", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt, "loaicong", "N", "Nghỉ");
            bang.P_COPY_COL(ref b_dt, "huongluong", "hluong");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "NL", "Hưởng nguyên lương");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "LCT", "Không nhận lương từ công ty");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "KL", "Nghỉ không lương");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_MA_TL_CC_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ma.Faobj_CC_MA_TL_CC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_COPY_COL(ref b_dt, "loaicong", "loai");
            bang.P_THAY_GTRI(ref b_dt, "loaicong", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt, "loaicong", "N", "Nghỉ");
            bang.P_COPY_COL(ref b_dt, "huongluong", "hluong");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "NL", "Hưởng nguyên lương");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "LCT", "Không nhận lương từ công ty");
            bang.P_THAY_GTRI(ref b_dt, "huongluong", "KL", "Nghỉ không lương");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_TL_CC_CT(string b_login, string b_ma, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = tl_ma.Fdt_CC_MA_TL_CC_CT(b_ma);
            string b_kq = (bang.Fb_TRANG(b_ds.Tables[0])) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0);
            string b_dt_cot = (bang.Fb_TRANG(b_ds.Tables[1])) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_TL_CC_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_pc, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_pc[0]); object[] a_gtri_pc = (object[])a_dt_pc[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc);
            bang.P_BO_HANG(ref b_dt_pc, "mapc", ""); bang.P_DON(ref b_dt_pc);
            if (b_dt_pc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_pc, new object[] { "-1", "-1", "-1" });
            bang.P_CSO_SO(ref b_dt_pc, "hso");
            tl_ma.P_CC_MA_TL_CC_NH(b_dt_ct, b_dt_pc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.CC_MA_TL_CC, TEN_BANG.CC_MA_TL_CC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_CC_MA_TL_CC_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_TL_CC_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            tl_ma.P_CC_MA_TL_CC_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.CC_MA_TL_CC, TEN_BANG.CC_MA_TL_CC);
            return Fs_CC_MA_TL_CC_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region PHƯƠNG PHÁP TÍNH LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_TL_PP_LUONG_LKE()
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_PP_LUONG_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : b_dt.Rows[0][0].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_PP_LUONG_APDUNG(string b_pp)
    {
        try
        {
            tl_ma.PNS_TL_PP_LUONG_APDUNG(b_pp);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region ĐƠN GIÁ LỢI NHUẬN
    [WebMethod(true)]
    public string Fs_TL_MA_LN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_LN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_LN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_LN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_LN_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_LN_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_LN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_LN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_LN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_LN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_MA_LN_XOA(b_ma); return Fs_TL_MA_LN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THIẾT LẬP LÀM CA
    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMCA_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_LAMCA_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_TIM_THEM(ref b_dt, "tl_tlap_lamca", "DT_MA_CONG", "MA_CONG");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMCA_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = tl_ma.Fdt_TL_TLAP_LAMCA_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            //bang.P_THAY_GTRI(ref b_dt, "NGHI_7_CN", "1", "Nghỉ thứ 7,chủ nhật");
            //bang.P_THAY_GTRI(ref b_dt, "NGHI_7_CN", "2", "Nghỉ chủ nhật");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMCA_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_LAMCA_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, "tl_tlap_lamca", "DT_MA_CONG", "MA_CONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMCA_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_loi = "loi:Giờ bắt đầu sai định dạng:loi";
            if (ht_dungchung.IsTime(b_dt_ct.Rows[0]["gio_bd"].ToString(), b_loi) != "")
            {
                return b_loi;
            }
            b_loi = "loi:Giờ kết thúc sai định dạng:loi";
            if (ht_dungchung.IsTime(b_dt_ct.Rows[0]["gio_kt"].ToString(), b_loi) != "")
            {
                return b_loi;
            }
            if (b_dt_ct.Rows[0]["giora_giuaca"].ToString() != "")
            {
                b_loi = "loi:Giờ ra giữa ca sai định dạng:loi";
                if (ht_dungchung.IsTime(b_dt_ct.Rows[0]["giora_giuaca"].ToString(), b_loi) != "")
                {
                    return b_loi;
                }
            }
            if (b_dt_ct.Rows[0]["giovao_giuaca"].ToString() != "")
            {
                b_loi = "loi:Giờ vào giữa ca sai định dạng:loi";
                if (ht_dungchung.IsTime(b_dt_ct.Rows[0]["giovao_giuaca"].ToString(), b_loi) != "")
                {
                    return b_loi;
                }
            }
            if (b_dt_ct.Rows[0]["QUET_TRUA"].Equals("X"))
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["giora_giuaca"].ToString()) || string.IsNullOrEmpty(b_dt_ct.Rows[0]["giovao_giuaca"].ToString()))
                {
                    return Thongbao_dch.chuanhap_giora_vao_giuaca;
                }
            }
            bang.P_CSO_SO(ref b_dt_ct, "duoc_dimuon,duoc_vesom");
            tl_ma.P_TL_TLAP_LAMCA_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_TLAP_LAMCA, TEN_BANG.TL_TLAP_LAMCA);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_TLAP_LAMCA_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_LAMCA_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            tl_ma.P_TL_TLAP_LAMCA_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_TLAP_LAMCA, TEN_BANG.TL_TLAP_LAMCA);
            return Fs_TL_TLAP_LAMCA_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_LAMCA_BYMA(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_NS_TL_TLAP_LAMCA_BYMA(b_ma);
            return b_dt.Rows[0]["gio_bd"].ToString() + "#" + b_dt.Rows[0]["gio_kt"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    #endregion THIẾT LẬP LÀM CA

    #region THIẾT LẬP TÍNH NGHỈ PHÉP

    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHIPHEP_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_NS_TL_TLAP_NGHIPHEP_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHIPHEP_CT()
    {
        try
        {
            DataTable b_dt = tl_ma.P_NS_TL_TLAP_NGHIPHEP_CT();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP TÍNH NGHỈ PHÉP

    #region THIẾT LẬP NGÀY NGHỈ ĐẶC BIỆT TRONG NĂM
    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHI_NAM_CT(string b_ngay_thietlap, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_TLAP_NGHI_NAM_CT(b_ngay_thietlap);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHI_NAM_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_TLAP_NGHI_NAM_LKE();
            bang.P_SO_CNG(ref b_dt, "ngay_thietlap");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHI_NAM_NH(object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "noidung", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["NOIDUNG"].ToString().Equals("") || b_dt_ct.Rows[i]["NGAYD"].ToString().Equals("") || b_dt_ct.Rows[i]["NGAYC"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            tl_ma.P_NS_TL_TLAP_NGHI_NAM_NH(b_dt, b_dt_ct);
            return Fs_NS_TL_TLAP_NGHI_NAM_LKE(a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_TLAP_NGHI_NAM_XOA(string b_ngay_thietlap, string[] a_cot)
    {
        try
        {
            tl_ma.PNS_TL_TLAP_NGHI_NAM_XOA(b_ngay_thietlap);
            return Fs_NS_TL_TLAP_NGHI_NAM_LKE(a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion

    #region GÁN ID CHẤM CÔNG CHO CÁN BỘ
    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TN_GAN_CC_LKE(b_phong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_MA(string b_phong, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TN_GAN_CC_MA(b_phong, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_CT(string b_phong, string b_ngay, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TN_GAN_CC_CT(b_phong, b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "" });
            tl_ma.P_TL_TN_GAN_CC_NH(b_dt, b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri), b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_TL_TN_GAN_CC_MA(b_phong, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_XOA(string b_phong, string b_ngay, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_TN_GAN_CC_XOA(b_ngay); return Fs_TL_TN_GAN_CC_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_LKE_CB(string b_phong, string b_ngay, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TN_GAN_CC_LKE_CB(b_phong, b_ngay);
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_LKE_CB2(string b_phong, string b_ngay, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TN_GAN_CC_LKE_CB(b_phong, b_ngay);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TN_GAN_CC_TINH_TU(string b_phong, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TN_GAN_CC_TINH_TU(b_phong);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion GÁN ID CHẤM CÔNG CHO CÁN BỘ

    #region MÃ KỲ LƯƠNG

    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_KYLUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            bang.P_SO_CSO(ref b_dt, "THANG");
            bang.P_TIM_THEM(ref b_dt, "tl_ma_kyluong", "DT_THANG", "THANG");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = tl_ma.Fdt_TL_MA_KYLUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_NAMTHANG(string b_login, int b_nam, int b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = tl_ma.Fdt_TL_MA_KYLUONG_NAMTHANG(b_nam, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NAM", "THANG" }, new object[] { b_nam, b_thang });
            bang.P_SO_CSO(ref b_dt, "THANG");
            bang.P_TIM_THEM(ref b_dt, "tl_ma_kyluong", "DT_THANG", "THANG");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_NH(string b_login, double b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_bd,ngay_kt");

            DataTable checkTontai = tl_ma.Fdt_KTRA_TONTAI_KYLUONG(b_so_id, chuyen.CSO_SO(b_dt_ct.Rows[0]["nam"].ToString()),
                                                                           chuyen.CSO_SO(b_dt_ct.Rows[0]["thang"].ToString()));
            if (checkTontai != null && checkTontai.Rows.Count > 0 && chuyen.OBJ_N(checkTontai.Rows[0]["TONTAI"].ToString()) > 0)
            {
                return Thongbao_dch.TonTaiKyCongLuong;
            }
            b_so_id = tl_ma.P_TL_MA_KYLUONG_NH(b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.TL_MA_KYLUONG, TEN_BANG.TL_MA_KYLUONG);
            int b_nam = mang.Fi_TEN_GTRI("nam", a_cot, a_gtri);
            int b_thang = mang.Fi_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_TL_MA_KYLUONG_NAMTHANG(b_login, b_nam, b_thang, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CC_PHANCA, ht_dungchung.KYLUONG_ID, b_so_id.ToString(), ref b_thongbao);
            double b_tontai1 = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CC_TH, ht_dungchung.KY, b_so_id.ToString(), ref b_thongbao);
            double b_tontai2 = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CC_TH_MAY, ht_dungchung.KYLUONG_ID, b_so_id.ToString(), ref b_thongbao);
            if (b_tontai > 0 || b_tontai1 > 0 || b_tontai2 > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            tl_ma.P_TL_MA_KYLUONG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.TL_MA_KYLUONG, TEN_BANG.TL_MA_KYLUONG);
            return Fs_TL_MA_KYLUONG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_KYLUONG_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_KYLUONG_CT(b_ma);
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ CÔNG VIỆC

    #region DANH MỤC NHÓM LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_MA_NHOMLUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fs_TL_MA_NHOMLUONG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_NHOMLUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_NHOMLUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_NHOMLUONG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_NHOMLUONG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_NHOMLUONG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_NHOMLUONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_MA_NHOMLUONG_XOA(b_ma); return Fs_TL_MA_NHOMLUONG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NHÓM LƯƠNG"

    #region THIẾT LẬP DANH MỤC LƯƠNG
    [WebMethod(true)]
    public string Fs_TL_MA_LUONG_LKE(string b_nhomluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_MA_LUONG_LKE(b_nhomluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "0", "Kiếu số");
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "1", "Kiểu chữ");
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "2", "Kiểu ngày tháng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_LUONG_MA(string b_nhomluong, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_MA_LUONG_MA(b_nhomluong, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "0", "Kiếu số");
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "1", "Kiểu chữ");
            bang.P_THAY_GTRI(ref b_dt, "ten_kdl", "2", "Kiểu ngày tháng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_LUONG_NH(string b_nhomluong, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_MA_LUONG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TL_MA_LUONG_MA(b_nhomluong, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TL_MA_LUONG_XOA(string b_nhomluong, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { tl_ma.P_TL_MA_LUONG_XOA(b_ma); return Fs_TL_MA_LUONG_LKE(b_nhomluong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_MA_LUONG_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_MA_LUONG_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP DANH MỤC LƯƠNG

    #region THIẾT LẬP CA MẶC ĐỊNH
    [WebMethod(true)]
    public string Fs_NS_DT_CMD_CT(string b_so_id, string[] a_cot_ct, string[] a_cot_dvi)
    {
        try
        {
            DataSet b_ds = tl_ma.Fdt_NS_DT_CMD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_nv = b_ds.Tables[1]; DataTable b_dt_dv = b_ds.Tables[2];

            bang.P_SO_CNG(ref b_dt, new string[] { "ng_hluc,ng_het_hluc" });
            //bang.P_TIM_THEM(ref b_dt, "tl_dt_cmd", "DT_PHONG_TK", "PHONG_TK");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct),
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
            object[] a_object = tl_ma.Fdt_DT_NS_CB(b_phong, b_lke, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_DT_CMD_P_NV(string b_phong, string b_ngay, double[] a_tso, string[] a_cot)
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
    public string Fs_NS_DT_CMD_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_NS_DT_CMD_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ng_hluc,ng_het_hluc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CMD_MA(string b_so_id, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_NS_DT_CMD_MA(b_so_id, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_het_hluc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            //int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NG_HLUC", "NG_HET_HLUC" }, new object[] { ng_hluc,ng_het_hluc});
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_CMD_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, object[] a_dt_dvi, string[] a_cot_lke)
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
            bang.P_CSO_SO(ref b_dt_dvi, "stt");

            for (int j = 0; j < b_dt_ct.Rows.Count; j++)
            {
                b_dt_ct.Rows[j]["tt"] = j + 1;
            }

            tl_ma.P_NS_DT_CMD_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_dvi);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.TL_DT_CMD, TEN_BANG.TL_DT_CMD);
            string b_ma = mang.Fs_TEN_GTRI("ma_ca", a_cot, a_gtri);
            return Fs_NS_DT_CMD_MA(b_so_id, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CMD_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.PNS_DT_CMD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.TL_DT_CMD, TEN_BANG.TL_DT_CMD);
            return Fs_NS_DT_CMD_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ TỰ SINH

    [WebMethod(true)]
    public string Fs_HT_MA_TUSINH_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            if (b_dt_ct.Rows[0]["SOTHE"].Equals("TS"))
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["tiento"].ToString()))
                {
                    return Thongbao_dch.chuanhap_tiento;
                }
                if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["DodaiSothe"].ToString()) || b_dt_ct.Rows[0]["DodaiSothe"].Equals("0"))
                {
                    return Thongbao_dch.chuanhap_dodaist;
                }
            }
            if (b_dt_ct.Rows[0]["HOPDONG"].Equals("TS"))
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["dodaiHD"].ToString()) || b_dt_ct.Rows[0]["dodaiHD"].Equals("0"))
                {
                    return Thongbao_dch.chuanhap_dodaihd;
                }
            }
            if (b_dt_ct.Rows[0]["QUYETDINH"].Equals("TS"))
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["dodaiQD"].ToString()) || b_dt_ct.Rows[0]["dodaiQD"].Equals("0"))
                {
                    return Thongbao_dch.chuanhap_dodaiqd;
                }
            }
            bang.P_CSO_SO(ref b_dt_ct, "DodaiSothe,DodaiHD,DoDaiQD");
            tl_ma.P_NS_MA_TUSINH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HT_MA_TUSINH, TEN_BANG.HT_MA_TUSINH);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_HT_MA_TUSINH_MA(string b_ma)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_HT_MA_TUSINH_MA(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ TỰ SINH

    #region THIẾT LẬP ĐƠN GIÁ THỰC TẬP SINH
    [WebMethod(true)]
    public string Fs_TL_TLAP_DONGIA_TTS_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_DONGIA_TTS_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay"); bang.P_SO_CSO(ref b_dt, "giatri");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_DONGIA_TTS_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_DONGIA_TTS_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CSO(ref b_dt, "giatri");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_DONGIA_TTS_CT(string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_DONGIA_TTS_CT(b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_DONGIA_TTS_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_DONGIA_TTS_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_TLAP_DONGIA_TTS, TEN_BANG.TL_TLAP_DONGIA_TTS);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_DONGIA_TTS_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }

    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_DONGIA_TTS_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_DONGIA_TTS_XOA(b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_TLAP_DONGIA_TTS, TEN_BANG.TL_TLAP_DONGIA_TTS);
            return Fs_TL_TLAP_DONGIA_TTS_LKE(a_cot, a_tso);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion THIẾT LẬP ĐƠN GIÁ THỰC TẬP SINH

    #region THIẾT LẬP ĐIỀU KIỆN THIẾU PHIẾU LỆNH
    [WebMethod(true)]
    public string Fs_TL_TLAP_THIEU_PHIEULENH_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_THIEU_PHIEULENH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CSO(ref b_dt, "lan1");
            bang.P_SO_CSO(ref b_dt, "lan2");
            bang.P_SO_CSO(ref b_dt, "lan3");
            bang.P_SO_CSO(ref b_dt, "lan3_thu");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THIEU_PHIEULENH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_THIEU_PHIEULENH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CSO(ref b_dt, "lan1");
            bang.P_SO_CSO(ref b_dt, "lan2");
            bang.P_SO_CSO(ref b_dt, "lan3");
            bang.P_SO_CSO(ref b_dt, "lan3_thu");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THIEU_PHIEULENH_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_THIEU_PHIEULENH_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_THIEU_PHIEULENH_NH(double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            tl_ma.P_TL_TLAP_THIEU_PHIEULENH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_TLAP_THIEU_PHIEULENH, TEN_BANG.TL_TLAP_THIEU_PHIEULENH);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_THIEU_PHIEULENH_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }

    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_THIEU_PHIEULENH_XOA(string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_THIEU_PHIEULENH_XOA(b_ngay);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_TLAP_THIEU_PHIEULENH, TEN_BANG.TL_TLAP_THIEU_PHIEULENH);
            return Fs_TL_TLAP_THIEU_PHIEULENH_LKE(a_cot, a_tso);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region THIẾT LẬP TỶ LỆ HOA HỒNG
    [WebMethod(true)]
    public void Fs_NS_TL_TLAP_TYLE_HOAHONG_DR(string b_form, string b_ktra, string b_ngay)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_ngay);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { 0, "" }, 0);
            se.P_TG_LUU(b_form, b_ktra, b_dt.Copy());
        }
        catch (Exception ex) { throw ex; }
    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.Fdt_TL_TLAP_TYLE_HOAHONG_LKE(b_tu_n, b_den_n); 
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            //bang.P_SO_CSO(ref b_dt, "lan1");
            //bang.P_SO_CSO(ref b_dt, "lan2");
            //bang.P_SO_CSO(ref b_dt, "lan3");
            //bang.P_SO_CSO(ref b_dt, "lan3_thu");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_MA(string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_TYLE_HOAHONG_MA(b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay");
            //bang.P_SO_CSO(ref b_dt, "phi_tu");
            //bang.P_SO_CSO(ref b_dt, "phi_den");
            //bang.P_SO_CSO(ref b_dt, "tyle");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_TYLE_HOAHONG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CSO(ref b_dt, "phi_tu");
            bang.P_SO_CSO(ref b_dt, "phi_den");
            bang.P_SO_CSO(ref b_dt, "tyle");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_TRANG(string[] a_cot)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_TYLE_HOAHONG_TRANG();
            bang.P_SO_CNG(ref b_dt, "ngay");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "dtnv", "");
            bang.P_CNG_SO(ref b_dt, "ngay");
            tl_ma.P_TL_TLAP_TYLE_HOAHONG_NH(b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.TL_TLAP_TYLE_HOAHONG, TEN_BANG.TL_TLAP_TYLE_HOAHONG);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_TL_TLAP_TYLE_HOAHONG_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }

    }

    [WebMethod(true)]
    public string Fs_TL_TLAP_TYLE_HOAHONG_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.P_TL_TLAP_TYLE_HOAHONG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.TL_TLAP_TYLE_HOAHONG, TEN_BANG.TL_TLAP_TYLE_HOAHONG);
            return Fs_TL_TLAP_TYLE_HOAHONG_LKE(a_cot, a_tso);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion 

    #region GIA HẠN CẮT PHÉP
    [WebMethod(true)]
    public string Fs_CC_MA_GHCP_LKE(string b_login, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = tl_ma.Faobj_CC_MA_GHCP_LKE(b_so_the, b_ten, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_GHCP");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CC_MA_GHCP_MA(string b_login, string b_so_the, string b_so_the_tk, string b_ten_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = tl_ma.Faobj_CC_MA_GHCP_MA(b_so_the, b_so_the_tk, b_ten_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_GHCP");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_GHCP_CT(string b_login, string b_so_the, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = tl_ma.Fdt_CC_MA_GHCP_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_ghcp");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_GHCP_NH(string b_login, string b_so_the_tk, string b_ten_tk, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ghcp");
            tl_ma.P_CC_MA_GHCP_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.CC_MA_GHCP, TEN_BANG.CC_MA_GHCP);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_CC_MA_GHCP_MA(b_login, b_so_the, b_so_the_tk, b_ten_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CC_MA_GHCP_XOA(string b_login, string b_so_the, string b_so_the_tk, string b_ten_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            tl_ma.P_CC_MA_GHCP_XOA(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.CC_MA_GHCP, TEN_BANG.CC_MA_GHCP);
            return Fs_CC_MA_GHCP_LKE(b_login, b_so_the_tk, b_ten_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region THIẾT LẬP KHOẢN PHẢI THU
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_LKE(string b_so_the, string b_ten, string b_nam, string b_kyluong_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_ma.PNS_TL_KHOAN_PHAITHU_LKE(b_so_the, b_ten, b_nam, b_kyluong_id, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "sotien_thu,sotien_tra");
            bang.P_SO_CNG(ref b_dt_tk, "ngaytao");
            b_dt_tk.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_MA(string b_so_the, string b_ten, string b_nam, string b_kyluong_id, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_NS_TL_KHOAN_PHAITHU_MA(b_so_the, b_ten, b_nam, b_kyluong_id, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "sotien_thu,sotien_tra");
            bang.P_SO_CNG(ref b_dt, "ngaytao");
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = tl_ma.PNS_TL_KHOAN_PHAITHU_CT(b_so_id);
            bang.P_SO_CSO(ref b_dt, "sotien_thu,sotien_tra,kyluong_id");
            bang.P_SO_CNG(ref b_dt, "ngaytao");
            if (b_dt.Rows.Count > 0)
            {
                var b_nam = b_dt.Rows[0]["NAM"];
                DataTable b_dt_kyluong = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
                se.P_TG_LUU("ns_tl_khoan_phaithu", "DT_KY", b_dt_kyluong.Copy());
            }
            bang.P_TIM_THEM(ref b_dt, "ns_tl_khoan_phaithu", "DT_KY", "KYLUONG_ID");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_NH(string b_so_id, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong_id_tk, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); //bang.P_CNG_SO(ref b_dt_ct, "ngay_qd");
            bang.P_CSO_SO(ref b_dt_ct, "nam,kyluong_id,sotien_thu,sotien_tra");
            bang.P_CNG_SO(ref b_dt_ct, "ngaytao");
            b_so_id = tl_ma.PNS_TL_KHOAN_PHAITHU_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TL_KHOAN_PHAITHU, TEN_BANG.NS_TL_KHOAN_PHAITHU);
            return Fs_NS_TL_KHOAN_PHAITHU_MA(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong_id_tk, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_XOA(string b_so_id, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong_id_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            tl_ma.PNS_TL_KHOAN_PHAITHU_XOA(b_so_id); // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TL_KHOAN_PHAITHU, TEN_BANG.NS_TL_KHOAN_PHAITHU);
            return Fs_NS_TL_KHOAN_PHAITHU_LKE(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong_id_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_KHOAN_PHAITHU_TRA(string b_so_the)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_NS_TL_KHOAN_PHAITHU_TRA(b_so_the);
            DataTable b_dt = (DataTable)a_object[0];
            DataRow b_dr = b_dt.Rows[0];
            return chuyen.OBJ_S(b_dr["ten_dvi"]) + "#" + chuyen.OBJ_S(b_dr["ten_cdanh"]) + "#" + chuyen.OBJ_S(b_dr["phong"]) + "#" + chuyen.OBJ_S(b_dr["cdanh"]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion THIẾT LẬP KHOẢN PHẢI THU
}
