using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
public class ht_maph
{
    public static string P_NS_CC_MA_CCDV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]) + "," + chuyen.OBJ_S(b_dr["cong_chuan"]);
            b_c = b_c + ",:a_ma";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_CCDV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static DataTable Fdt_MA_PH_XEM()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_XEM");
    }
    public static DataTable Fdt_MA_PH_DVI(string b_dvi)
    {
        return dbora.Fdt_LKE_S(b_dvi, "PHT_MA_PHONG_DVI");
    }
    public static DataTable Fdt_MA_PH_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE");
    }
    public static DataTable Fdt_MA_PH_LKE2()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE");
    } 
    public static DataTable Fdt_MA_PH_LKE_CAY(string b_ma, string b_gt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_gt }, "PHT_MA_PHONG_LKE_CAY");
    }
    public static string Fs_PH_QLY(string b_ma)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(b_ma, 'S', "PKH_MA_PHONG_QLY"));
    }
    public static DataTable Fdt_MA_PH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PHT_MA_PHONG_CT");
    }
    public static DataTable Fdt_MA_PH_DVI_CDANH_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PH_DVI_CDANH_LKE");
    }
    public static DataTable Fdt_MA_PH_LKE3(string b_tim)
    {
        return dbora.Fdt_LKE_S(b_tim, "PHT_MA_PHONG_LKE3");
    }
    public static DataTable Fdt_MA_PH_LKE_TEST(string b_tim)
    {
        return dbora.Fdt_LKE_S(b_tim, "pht_ma_phong_lke_test");
    }
    public static DataTable Fdt_MA_PH_LKE5(string b_tim, string b_ma_dvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_tim, b_ma_dvi }, "PHT_MA_PHONG_LKE5");
    }
    public static string P_MA_PH_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { chuyen.OBJ_S(b_dr_ct["ma"]),
                                        chuyen.OBJ_S(b_dr_ct["ten"]),
                                        chuyen.OBJ_S(b_dr_ct["ten_ta"]),
                                        chuyen.OBJ_S(b_dr_ct["ten_vt"]),
                                        b_dr_ct["sott"],
                                        chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_tl"])),
                                        chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_gt"])),
                                        chuyen.OBJ_S(b_dr_ct["sdt"]),
                                        chuyen.OBJ_S(b_dr_ct["fax"]),
                                        chuyen.OBJ_S(b_dr_ct["phong_ql"]),
                                        chuyen.OBJ_S(b_dr_ct["cdanh_ql"]),
                                        chuyen.OBJ_S(b_dr_ct["ma_thue"]),
                                        chuyen.OBJ_S(b_dr_ct["dia_chi"]),
                                        chuyen.OBJ_S(b_dr_ct["ghi_chu"]),
                                        chuyen.OBJ_S(b_dr_ct["ma_ct"]),
                                        chuyen.OBJ_N(b_dr_ct["cap"]),
                                        chuyen.OBJ_S(b_dr_ct["vung_mien"]) ,
                                        chuyen.OBJ_S(b_dr_ct["khoi"]) ,
                                        chuyen.OBJ_S(b_dr_ct["ma_pb"]) ,
                                        chuyen.OBJ_S(b_dr_ct["logo"]),
                                        chuyen.OBJ_N(b_dr_ct["trang_thai"])
        };
        return chuyen.OBJ_S(dbora.Fobj_LKE(a_obj, 'S', "PHT_MA_PHONG_NH"));
    }
    public static string P_MA_PH_GT(string b_ma, string b_ngay_gt)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_ma, chuyen.CNG_SO(b_ngay_gt) }, 'S', "PHT_MA_PHONG_GT"));
    }
    public static void P_MA_PH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHT_MA_PHONG_XOA");
    }
    public static void P_MA_PH_IMP(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ma_ts = bang.Fobj_COL_MANG(b_dt, "ma_ts");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ten_ta = bang.Fobj_COL_MANG(b_dt, "ten_ta");
            object[] a_ten_vt = bang.Fobj_COL_MANG(b_dt, "ten_vt");
            object[] a_sott = bang.Fobj_COL_MANG(b_dt, "sott");
            object[] a_ngay_tl = bang.Fobj_COL_MANG(b_dt, "ngay_tl");
            object[] a_ngay_gt = bang.Fobj_COL_MANG(b_dt, "ngay_gt");
            object[] a_sdt = bang.Fobj_COL_MANG(b_dt, "sdt");
            object[] a_fax = bang.Fobj_COL_MANG(b_dt, "fax");
            object[] a_cdanh_ql = bang.Fobj_COL_MANG(b_dt, "cdanh_ql");
            object[] a_ma_thue = bang.Fobj_COL_MANG(b_dt, "ma_thue");
            object[] a_dia_chi = bang.Fobj_COL_MANG(b_dt, "dia_chi");
            object[] a_ghi_chu = bang.Fobj_COL_MANG(b_dt, "ghi_chu");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ma_ct");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ts", 'S', a_ma_ts);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_ta", 'S', a_ten_ta);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_vt", 'S', a_ten_vt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_tl", 'N', a_ngay_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_gt", 'N', a_ngay_gt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sdt", 'S', a_sdt);
            dbora.P_THEM_PAR(ref b_lenh, "a_fax", 'S', a_fax);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_ql", 'S', a_cdanh_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_thue", 'S', a_ma_thue);
            dbora.P_THEM_PAR(ref b_lenh, "a_dia_chi", 'U', a_dia_chi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghi_chu", 'U', a_ghi_chu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ct", 'S', a_ma_ct);
            string b_c = ",:a_ma_ts,:a_ten,:a_ten_ta,:a_ten_vt,:a_sott,:a_ngay_tl,:a_ngay_gt,:a_sdt,:a_fax,:a_cdanh_ql,:a_ma_thue,:a_dia_chi,:a_ghi_chu,:a_ma_ct";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHT_MA_PH_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_HS_CCTC_CAY(string b_ma, string b_gt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_gt }, "PNS_HS_CCTC_CAY");
    }
    public static DataTable Fdt_NS_HS_CCTC_CAY_CONGCHUAN(string b_nam, string b_phong, string b_ma, string b_gt)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_nam), b_phong, b_ma, b_gt }, "PNS_HS_CCTC_CAY_CONGCHUAN");
    }
}