using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class stl_phep : System.Web.Services.WebService
{

    #region NGHỈ PHÉP
    [WebMethod(true)]
    public string Fs_NS_CC_NGHIPHEP_TINH(string b_phong, string b_kyluong, string b_so_the, string[] a_cot, string[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_phep.Fds_NS_CC_NGHIPHEP_TINH(b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_PHEP_NAM, TEN_BANG.NS_CC_PHEP_NAM); 
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_CSO_CNG(ref b_dt, "ngay_vao");
            bang.P_CSO_CNG(ref b_dt, "ngay_cat_phep");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_NGHIPHEP_LKE(string b_phong, string b_kyluong, string b_so_the, string[] a_tso, string[] a_cot)
    {
        try
        {
            //double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            //object[] a_object = tl_phep.Fdt_NS_CC_NGHIPHEP_LKE(b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n); ;
            //DataTable b_dt = (DataTable)a_object[1];
            //bang.P_CSO_CNG(ref b_dt, "ngay_vao");
            //bang.P_SO_CNG(ref b_dt, "ngay_cat_phep");
            //return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return Fs_NS_CC_NGHIPHEP_TINH(b_phong, b_kyluong, b_so_the, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_CC_PHEP_DIEUCHINH_NH(string b_login, double b_trangKT, double b_so_id, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngayd_kttn", "thang_dieuchinh", "thang_giahan" });
            object[] b_kq = tl_phep.P_NS_CC_PHEP_DIEUCHINH_NH(b_so_id, b_dt_ct);
            return Fs_NS_CC_PHEP_DIEUCHINH_SOID(b_login, chuyen.OBJ_N(b_kq[0]), b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_PHEP_DIEUCHINH_SOID(string b_login, double b_so_id, double b_TrangKt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = tl_phep.Faobj_NS_CC_PHEP_DIEUCHINH_SOID(b_so_id, b_TrangKt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_CC_PHEP_DIEUCHINH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_phep.Fdt_NS_CC_PHEP_DIEUCHINH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            double b_dong = chuyen.OBJ_N(a_object[0]);
            return b_dong + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_PHEP_DIEUCHINH_CT(string b_login, double b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = tl_phep.Fdt_NS_CC_PHEP_DIEUCHINH_CT(chuyen.OBJ_N(b_so_id));
            bang.P_CSO_CNG(ref b_dt, new string[] { "ngayd_kttn", "thang_dieuchinh", "thang_giahan" });
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_PHEP_DIEUCHINH_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { se.P_LOGIN(b_login); tl_phep.P_NS_CC_PHEP_DIEUCHINH_XOA(b_so_id); return Fs_NS_CC_PHEP_DIEUCHINH_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion NGHỈ PHÉP

    #region NGHỈ BÙ

    [WebMethod(true)]
    public string Fs_NS_CC_NGHIBU_TINH(string b_phong, string b_nam, string b_kyluong, string[] a_cot, string[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_phep.Fds_NS_CC_NGHIBU_TINH(b_phong, b_nam, b_kyluong, b_tu_n, b_den_n);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_CC_NGHIBU, TEN_BANG.NS_CC_NGHIBU); 
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_NGHIBU_LKE(string b_phong, double b_nam, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = tl_phep.Fdt_NS_CC_NGHIBU_LKE(b_phong, b_nam, b_kyluong, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_CSO_CNG(ref b_dt, "ngay_vao");
            //bang.P_CSO_CTH(ref b_dt, "ngay_cat_phep");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion NGHỈ BÙ
}