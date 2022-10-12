
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_sk : System.Web.Services.WebService
{

    #region THÔNG TIN SỨC KHỎE CÁN BỘ

    [WebMethod(true)]
    public string Fs_NS_SK_TT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_sk.Fdt_NS_SK_TT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_SK_TT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_sk.Fdt_NS_SK_TT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_SK_TT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_sk.PNS_SK_TT_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_SK_TT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            b_so_id = ns_sk.PNS_SK_TT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_SK_TT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_SK_TT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_sk.PNS_SK_TT_XOA(b_so_id); return Fs_NS_SK_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion THÔNG TIN SỨC KHỎE CÁN BỘ

    #region TIỂU SỬ BỆNH ÁN

    [WebMethod(true)]
    public string Fs_NS_SK_BA_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_sk.PNS_SK_BA_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_SK_BA_CT(string b_so_the, string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_sk.PNS_SK_BA_CT(b_so_the, b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_SK_BA_NH(string b_so_id, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_sk.PNS_SK_BA_NH(ref b_so_id, b_dt_ct); return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_SK_BA_XOA(string b_so_the, string b_so_id)
    {
        try
        {
            ns_sk.PNS_SK_BA_XOA(b_so_the, b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    #endregion TIỂU SỬ BỆNH ÁN

    #region KẾ HOẠCH BẢO HỘ LAO ĐỘNG

    [WebMethod(true)]
    public string Fs_NS_KHBH_LKE(string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_sk.Fdt_NS_KHBH_LKE(b_nam, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHBH_MA(string b_nam, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_sk.Fdt_NS_KHBH_MA(b_nam, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHBH_CT(string b_nam, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_sk.Fdt_NS_KHBH_CT(b_nam, b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHBH_NH(string b_ma, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_sk.P_NS_KHBH_NH(b_dt_ct);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_KHBH_MA(b_nam, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_KHBH_XOA(string b_nam, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        { ns_sk.PNS_KHBH_XOA(b_nam, b_ma); return Fs_NS_KHBH_LKE(b_nam, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KẾ HOẠCH BẢO HỘ LAO ĐỘNG

    #region TRANG THIẾT BỊ BẢO HỘ LAO ĐỘNG
    
    [WebMethod(true)]
    public string Fs_NS_TTB_LKE(string b_login, string b_phong, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_sk.Fdt_NS_TTB_LKE(b_phong, b_so_the, b_ten, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "C", "Chờ cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "D", "Đã cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "T", "Đã thu hồi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TTB_MA(string b_login, string b_phong, string b_so_the, string b_ten, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_sk.Fdt_NS_TTB_MA(b_phong, b_so_the, b_ten, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "C", "Chờ cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "D", "Đã cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "T", "Đã thu hồi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TTB_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_sk.PNS_TTB_CT(b_so_id);
            //bang.P_SO_CNG(ref b_dt, new string[] { "ngaycap", "NGAYTHU" });
            if (b_dt.Rows.Count > 0)
            {
                string b_nhom_ts = b_dt.Rows[0]["NHOM_TS"].ToString();
                DataTable b_dt_ts = ns_ma.Fdt_NS_MA_TAISAN_DR_NHOM(b_nhom_ts);
                se.P_TG_LUU("ns_ttb", "NS_TTB_MATS", b_dt_ts);
                bang.P_TIM_THEM(ref b_dt, "ns_ttb", "NS_TTB_MATS", "MATS");                
            }
            bang.P_TIM_THEM(ref b_dt, "ns_ttb", "NS_TTB_NHOM_TS", "NHOM_TS");            
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TTB_PHONG(string b_so_the)
    {
        try
        {            
           
            DataTable b_dt=ns_sk.PNS_TTB_PHONG(b_so_the);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TTB_PHONG_CB_GIAO(string b_so_the)
    {
        try
        {

            DataTable b_dt = ns_sk.PNS_TTB_PHONG(b_so_the);
            bang.P_DOI_TENCOL(ref b_dt, "so_the", "ma_cb_giao");
            bang.P_DOI_TENCOL(ref b_dt, "ten", "cb_giao");
            bang.P_DOI_TENCOL(ref b_dt, "phong", "phong_giao");
            bang.P_BO_COT(ref b_dt, "cdanh");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TTB_NH(string b_login, string b_phong, string b_so_the, string b_ten, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            //bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngaycap", "NGAYTHU" });
            bang.P_CSO_SO(ref b_dt_ct, new string[] { "sluong", "tien" });
            b_so_id = ns_sk.PNS_TTB_NH(ref b_so_id, b_dt_ct);
            return Fs_NS_TTB_MA(b_login, b_phong, b_so_the, b_ten, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TTB_XOA(string b_login, string b_so_id, string b_phong, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_sk.PNS_TTB_XOA(b_so_id);
            return Fs_NS_TTB_LKE(b_login, b_phong, b_so_the, b_ten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    #endregion TRANG THIẾT BỊ BẢO HỘ LAO ĐỘNG

    #region THAM GIA HUẤN LUYỆN BHLĐ
    [WebMethod(true)]
    public string Fs_NS_BHLD_TG_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_sk.Fdt_NS_BHLD_TG_CT(b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHLD_TG_LKE(string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_sk.Fdt_NS_BHLD_TG_LKE(b_nam, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_BHLD_TG_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                b_dt_ct.Rows[i]["tt"] = i + 1;
                if (b_dt_ct.Rows[i]["SO_THE"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            return ns_sk.P_NS_BHLD_TG_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_BHLD_TG_XOA(string b_so_id)
    {
        try
        {
            ns_sk.PNS_BHLD_TG_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    #endregion THAM GIA HUẤN LUYỆN BHLĐ

}
