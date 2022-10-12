using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;


[System.Web.Script.Services.ScriptService]
public class sns_ktkl : System.Web.Services.WebService
{
    #region MÃ NƠI KTKTL
    [WebMethod(true)]
    public string Fs_NS_MA_NOI_KTKL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.Fdt_NS_MA_NOI_KTKL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NOI_KTKL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_MA_NOI_KTKL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NOI_KTKL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ktkl.P_NS_MA_NOI_KTKL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NOI_KTKL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NOI_KTKL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ktkl.P_NS_MA_NOI_KTKL_XOA(b_ma); return Fs_NS_MA_NOI_KTKL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region MA CAP KTKL
    [WebMethod(true)]
    public string Fs_MA_CAP_KTKL_LKE(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ktkl.Fdt_MA_CAP_KTKL_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CAP_KTKL_NH(string b_login, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ktkl.P_MA_CAP_KTKL_NH(b_dt_ct);
            DataTable b_dt = ns_ktkl.Fdt_MA_CAP_KTKL_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CAP_KTKL_XOA(string b_login, string b_ma)
    {
        try { se.P_LOGIN(b_login); ns_ktkl.P_MA_CAP_KTKL_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA CAP KTKL

    #region KHEN THƯỞNG
    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_LKE_CB(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.PNS_KTKL_KT_LKE_CB(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.PNS_KTKL_KT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_KT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayqd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ktkl.PNS_KTKL_KT_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayqd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngayqd");
            b_so_id = ns_ktkl.PNS_KTKL_KT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_KTKL_KT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ktkl.PNS_KTKL_KT_XOA(b_so_id); return Fs_NS_KTKL_KT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KHEN THƯỞNG

    #region KHEN THƯỞNG CHUNG

    [WebMethod(true)]
    public string Fs_NS_KTKL_KTC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.PNS_KTKL_KTC_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KTC_MA(string b_soqd, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_KTC_MA(b_soqd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayqd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "soqd", b_soqd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KTC_CT(string b_soqd, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_ktkl.PNS_KTKL_KTC_CT(b_soqd);
            bang.P_SO_CNG(ref b_dt, "ngayqd"); bang.P_SO_CSO(ref b_dt, "mucthuong");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq + "#" + b_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KTC_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayqd");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            ns_ktkl.PNS_KTKL_KTC_NH(b_dt, b_dt_ct);
            string b_soqd = mang.Fs_TEN_GTRI("soqd", a_cot, a_gtri);
            return Fs_NS_KTKL_KTC_MA(b_soqd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KTC_XOA(string b_soqd, string b_ngayqd, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ktkl.PNS_KTKL_KTC_XOA(b_soqd, b_ngayqd); return Fs_NS_KTKL_KTC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KHEN THƯỞNG CHUNG

    #region KỶ LUẬT CHUNG

    [WebMethod(true)]
    public string Fs_NS_KTKL_KLC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.PNS_KTKL_KLC_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KLC_MA(string b_soqd, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_KLC_MA(b_soqd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayqd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "soqd", b_soqd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KLC_CT(string b_soqd, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_ktkl.PNS_KTKL_KLC_CT(b_soqd);
            bang.P_SO_CNG(ref b_dt, "ngayqd,ngayd,ngayc"); bang.P_SO_CSO(ref b_dt, "mucphat");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq + "#" + b_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KLC_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayqd,ngayd,ngayc");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["SO_THE"].ToString().Equals("") || b_dt_ct.Rows[i]["TEN"].ToString().Equals("") || b_dt_ct.Rows[i]["PHONG"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }


            ns_ktkl.PNS_KTKL_KLC_NH(b_dt, b_dt_ct);
            string b_soqd = mang.Fs_TEN_GTRI("soqd", a_cot, a_gtri);
            return Fs_NS_KTKL_KLC_MA(b_soqd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KLC_XOA(string b_soqd, string b_ngayqd, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ktkl.PNS_KTKL_KLC_XOA(b_soqd, b_ngayqd); return Fs_NS_KTKL_KLC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KỶ LUẬT CHUNG

    #region KỶ LUẬT

    [WebMethod(true)]
    public string Fs_NS_KTKL_KL_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ktkl.PNS_KTKL_KL_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KL_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_KL_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayqd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_KL_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ktkl.PNS_KTKL_KL_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayqd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KL_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngayqd");
            b_so_id = ns_ktkl.PNS_KTKL_KL_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_KTKL_KL_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_KL_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ktkl.PNS_KTKL_KL_XOA(b_so_id); return Fs_NS_KTKL_KL_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KỶ LUẬT

    #region QUẢN LÝ KHEN THƯỞNG
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_LKE(string b_login, object[] a_dt_tk, string b_phong, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]);
            object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKT_LKE(b_dt_tk, b_phong, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "ten_dtuong", "dtuong");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "TT", "Tập thể");
            string a = chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_KYLUONG_LKE(string b_form, double b_nam)
    {
        try
        {

            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            se.P_TG_LUU(b_form, "DT_KYLUONG", b_dt.Copy());
            //return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_MA(string b_login, string b_so_id, object[] a_dt, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri_tk = (object[])a_dt[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKT_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "ten_dtuong", "dtuong");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "TT", "Tập thể");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_CT(string b_login, string b_form, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            var b_ds = ns_ktkl.Fdt_NS_KTKL_QLKT_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
            bang.P_SO_NULL(ref b_dt, "NAM");
            bang.P_SO_CSO(ref b_dt, "nam");
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_hhl,ngayky");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_HTKT", "HINHTHUC");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NAM", "nam");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_KYLUONG", "KYLUONG");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_NH(string b_login, string b_so_id, object[] b_dt_tk, string b_phong, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke, double b_trangKT)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            if (chuyen.OBJ_S(b_dt.Rows[0]["DTUONG"]) == "TT")
            {
                bang.P_BO_HANG(ref b_dt_ct, "so_thenv", "");
                if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
                for (int i = 0; i < b_dt_ct.Rows.Count; i++)
                {
                    if (b_dt_ct.Rows[i]["so_thenv"].ToString().Equals(""))
                    {
                        return Thongbao_dch.nhapdulieu_luoi;
                    }
                }
            }
            else if (string.IsNullOrEmpty(chuyen.OBJ_S(b_dt.Rows[0]["so_the"]).ToString()))
            {
                return "loi:Chưa chọn nhân viên:loi";
            }
            bang.P_CNG_SO(ref b_dt, "ngay_hl,ngay_hhl,ngayky");
            ns_ktkl.P_NS_KTKL_QLKT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_KTKL_QLKT, TEN_BANG.NS_KTKL_QLKT);
            return Fs_NS_KTKL_QLKT_MA(b_login, b_so_id, b_dt_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_XOA(string b_login, object[] a_dt_tk, string b_phong, string b_so_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ktkl.PNS_KTKL_QLKT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_KTKL_QLKT, TEN_BANG.NS_KTKL_QLKT);
            return Fs_NS_KTKL_QLKT_LKE(b_login, a_dt_tk, b_phong, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKT_TRA(string b_so_the)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKT_TRA(b_so_the);
            DataTable b_dt = (DataTable)a_object[0];
            DataRow b_dr = b_dt.Rows[0];
            return chuyen.OBJ_S(b_dr["ten_dvi"]) + "#" + chuyen.OBJ_S(b_dr["ten_cdanh"]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HTKT_TRA(string b_ma)
    {
        try
        {
            object[] a_object = ns_ktkl.Faobj_NS_HTKT_TRA(b_ma);
            return chuyen.OBJ_S(a_object[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion QUẢN LÝ KHEN THƯỞNG

    #region QUẢN LÝ KỶ LUẬT

    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_LKE(string b_login, string b_phong, object[] a_dt_tk, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]);
            object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKL_LKE(b_phong, b_dt_tk, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "ten_dtuong", "dtuong");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "TT", "Tập thể");
            string a = chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_MA(string b_login, string b_so_id, object[] a_dt, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri_tk = (object[])a_dt[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKL_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "ten_dtuong", "dtuong");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong", "TT", "Tập thể");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_CT(string b_login, string b_form, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            var b_ds = ns_ktkl.Fdt_NS_KTKL_QLKL_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
            bang.P_SO_NULL(ref b_dt, "NAM");
            bang.P_SO_CSO(ref b_dt, "nam");
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_hhl,ngayky");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_HTKL", "HINHTHUC");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NAM", "NAM");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_KYLUONG", "KYLUONG");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_NH(string b_login, string b_so_id, object[] b_dt_tk, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke, double b_trangKT)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            bang.P_CNG_SO(ref b_dt, "ngay_hl,ngay_hhl,ngayky");
            if (chuyen.OBJ_S(b_dt.Rows[0]["DTUONG"]) == "TT")
            {
                bang.P_BO_HANG(ref b_dt_ct, "so_thenv", "");
                if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
                for (int i = 0; i < b_dt_ct.Rows.Count; i++)
                {
                    if (b_dt_ct.Rows[i]["so_thenv"].ToString().Equals(""))
                    {
                        return Thongbao_dch.nhapdulieu_luoi;
                    }
                }
            }
            else if (string.IsNullOrEmpty(chuyen.OBJ_S(b_dt.Rows[0]["so_the"]).ToString()))
            {
                return "loi:Chưa chọn nhân viên:loi";
            }
            ns_ktkl.P_NS_KTKL_QLKL_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_KTKL_QLKL, TEN_BANG.NS_KTKL_QLKL);
            return Fs_NS_KTKL_QLKL_MA(b_login, b_so_id, b_dt_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_XOA(string b_login, string b_phong, object[] a_dt_tk, string b_so_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ktkl.PNS_KTKL_QLKL_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_KTKL_QLKL, TEN_BANG.NS_KTKL_QLKL);
            return Fs_NS_KTKL_QLKL_LKE(b_login, b_phong, a_dt_tk, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_KYLUONG_LKE(string b_form, double b_nam)
    {
        try
        {

            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            se.P_TG_LUU(b_form, "DT_KYLUONG", b_dt.Copy());
            //return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KTKL_QLKL_TRA(string b_so_the)
    {
        try
        {
            object[] a_object = ns_ktkl.Fdt_NS_KTKL_QLKL_TRA(b_so_the);
            DataTable b_dt = (DataTable)a_object[0];
            DataRow b_dr = b_dt.Rows[0];
            return chuyen.OBJ_S(b_dr["ten_dvi"]) + "#" + chuyen.OBJ_S(b_dr["ten_cdanh"]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HTKL_TRA(string b_ma)
    {
        try
        {
            object[] a_object = ns_ktkl.Faobj_NS_HTKL_TRA(b_ma);
            return chuyen.OBJ_S(a_object[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion
}