using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class tl_phep
{

    #region NGHỈ PHÉP

    public static object[] Fds_NS_CC_NGHIPHEP_TINH(string b_phong, string b_ky, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_ky,b_so_the, b_tu_n, b_den_n }, "NR", "pns_cc_nghiphep_tinh");
    }

    public static object[] Fdt_NS_CC_NGHIPHEP_LKE(string b_phong, double b_kyluong, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong,b_so_the, b_tu_n, b_den_n }, "NR", "pns_cc_nghiphep_lke");
    }


    public static DataTable Fdt_NS_CC_NGHIPHEP_XUATEXCEL(string b_phong, string b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong }, "pns_cc_nghiphep_xuatexcel");
    }

    public static object[] P_NS_CC_PHEP_DIEUCHINH_NH(double b_so_id, DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = { b_so_id, b_dr_ct["SO_THE"], b_dr_ct["thang_kttn"], b_dr_ct["ngayd_kttn"], b_dr_ct["lydo_kttn"], b_dr_ct["phep_dieuchinh"], b_dr_ct["thang_dieuchinh"], b_dr_ct["lydo_dieuchinh"], b_dr_ct["thang_giahan"] };
        return dbora.Faobj_LKE(a_obj, "N", "pns_cc_phep_dieuchinh_nh");
    }

    public static object[] Faobj_NS_CC_PHEP_DIEUCHINH_SOID(double b_so_id, double b_TrangKt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_TrangKt }, "NNR", "pht_ns_cc_phep_dieuchinh_soid");
    }

    public static object[] Fdt_NS_CC_PHEP_DIEUCHINH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "pht_ns_cc_phep_dieuchinh_lke");
    }


    public static DataTable Fdt_NS_CC_PHEP_DIEUCHINH_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "pns_cc_phep_dieuchinh_ct");
    }


    public static DataTable Fdt_NS_CC_NGHIPHEP_DIEUCHINH_XUATEXCEL()
    {
        return dbora.Fdt_LKE("pns_cc_phep_dieuchinh_xuat");
    }



    public static bool Fdt_NS_CC_PHEP_DIEUCHINH_IMP_NH(DataTable b_dt_ct, ref string b_loi)
    {

        bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngayd_kttn", "thang_dieuchinh", "thang_giahan" });
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "SO_THE");
            object[] a_thang_kttn = bang.Fobj_COL_MANG(b_dt_ct, "THANG_KTTN");
            object[] a_ngayd_kttn = bang.Fobj_COL_MANG(b_dt_ct, "NGAYD_KTTN");
            object[] a_lydo_kttn = bang.Fobj_COL_MANG(b_dt_ct, "LYDO_KTTN");
            object[] a_phep_dieuchinh = bang.Fobj_COL_MANG(b_dt_ct, "PHEP_DIEUCHINH");
            object[] a_thang_dieuchinh = bang.Fobj_COL_MANG(b_dt_ct, "THANG_DIEUCHINH");
            object[] a_lydo_dieuchinh = bang.Fobj_COL_MANG(b_dt_ct, "LYDO_DIEUCHINH");
            object[] a_thang_giahan = bang.Fobj_COL_MANG(b_dt_ct, "THANG_GIAHAN");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_kttn", 'N', a_thang_kttn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd_kttn", 'N', a_ngayd_kttn);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_kttn", 'U', a_lydo_kttn);
            dbora.P_THEM_PAR(ref b_lenh, "a_phep_dieuchinh", 'N', a_phep_dieuchinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_dieuchinh", 'N', a_thang_dieuchinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_dieuchinh", 'U', a_lydo_dieuchinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_giahan", 'N', a_thang_giahan);

            string b_c = ",:a_so_the,:a_thang_kttn,:a_ngayd_kttn,:a_lydo_kttn,:a_phep_dieuchinh,:a_thang_dieuchinh,:a_lydo_dieuchinh,:a_thang_giahan";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cc_phep_dieuchinh_imp_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                b_loi = ex.Message;
                return false;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_CC_PHEP_DIEUCHINH_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_cc_phep_dieuchinh_xoa");
    }
    #endregion NGHỈ PHÉP

    #region NGHỈ BÙ

    public static object[] Fds_NS_CC_NGHIBU_TINH(string b_phong, string b_nam, string b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam,b_kyluong, b_tu_n, b_den_n }, "NR", "pns_cc_nghibu_tinh");
    }
    public static object[] Fdt_NS_CC_NGHIBU_LKE(string b_phong, double b_nam, string b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam, b_kyluong,b_tu_n, b_den_n }, "NR", "pns_cc_nghibu_lke");
    }

    public static DataTable Fdt_NS_CC_NGHIBU_XUATEXCEL(string b_phong, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_nam }, "pns_cc_nghibu_xuatexcel");
    }
    #endregion NGHỈ BÙ
}