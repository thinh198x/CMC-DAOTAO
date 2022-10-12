using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_dm : System.Web.Services.WebService
{
    #region KỲ ĐÁNH GIÁ

    [WebMethod(true)]
    public string Fs_NS_DM_KY_DG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dm.Fdt_NS_DM_KY_DG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_c,ngay_d");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_KY_DG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dm.Fdt_NS_DM_KY_DG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_KY_DG_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_dm.Fdt_NS_DM_KY_DG_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_KY_DG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dm.P_NS_DM_KY_DG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DM_KY_DG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DM_KY_DG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_dm.P_NS_DM_KY_DG_XOA(b_ma); return Fs_NS_DM_KY_DG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH

    #region KỲ ĐÁNH GIÁ

    [WebMethod(true)]
    public string Fs_NS_DM_NHOM_CAUHOI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dm.Fdt_NS_DM_NHOM_CAUHOI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_c,ngay_d");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_NHOM_CAUHOI_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dm.Fdt_NS_DM_NHOM_CAUHOI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_NHOM_CAUHOI_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_dm.Fdt_NS_DM_NHOM_CAUHOI_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DM_NHOM_CAUHOI_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dm.P_NS_DM_NHOM_CAUHOI_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DM_NHOM_CAUHOI_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DM_NHOM_CAUHOI_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_dm.P_NS_DM_NHOM_CAUHOI_XOA(b_ma); return Fs_NS_DM_NHOM_CAUHOI_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH
}
