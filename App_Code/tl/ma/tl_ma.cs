using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class tl_ma
{

    #region THÔNG SỐ PHÉP BÙ

    public static string P_NS_CC_MA_TSPB_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["ngay_hl"]) + "," + chuyen.OBJ_S(b_dr["tham_nien"]) + "," + chuyen.OBJ_S(b_dr["phep_tang"]) + "," + chuyen.OBJ_S(b_dr["ngay_cp"]) + "," + chuyen.OBJ_S(b_dr["ngay_cpb"]) + "," + chuyen.OBJ_C(b_dr["loai_huong"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_TSPB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_CC_MA_TSPB_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_CC_MA_TSPB_MA");
    }
    public static object[] Faobj_NS_CC_MA_TSPB_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_CC_MA_TSPB_LKE");
    }
    public static DataTable Fdt_NS_CC_MA_TSPB_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_CC_MA_TSPB_CT");
    }
    public static void P_NS_CC_MA_TSPB_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_MA_TSPB_XOA");
    }
    #endregion THÔNG SỐ PHÉP BÙ

    #region CHẤM CÔNG ĐẶC BIỆT 
    public static string P_NS_CC_MA_CCDB_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ncb"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_CCDB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_CC_MA_CCDB_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_CC_MA_CCDB_MA");
    }
    public static object[] Faobj_NS_CC_MA_CCDB_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_CC_MA_CCDB_LKE");
    }
    public static DataTable Fdt_NS_CC_MA_CCDB_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_CC_MA_CCDB_CT");
    }
    public static void P_NS_CC_MA_CCDB_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_MA_CCDB_XOA");
    }
    #endregion CHẤM CÔNG ĐẶC BIỆT

    #region THIẾT LẬP TỶ LỆ LÀM THÊM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_LAMTHEM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_LAMTHEM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_LAMTHEM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_LAMTHEM_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_LAMTHEM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_TLAP_LAMTHEM_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_LAMTHEM_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            DataRow b_dr = b_dt.Rows[0];
            int b_ngay = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay"]));

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_nguoi_ld = bang.Fobj_COL_MANG(b_dt_ct, "lamthem");
            object[] a_nguoi_sdld = bang.Fobj_COL_MANG(b_dt_ct, "lamdem");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'U', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "lamthem", 'N', a_nguoi_ld);
            dbora.P_THEM_PAR(ref b_lenh, "lamdem", 'N', a_nguoi_sdld);

            string b_c = ",:so_id," + b_ngay + ",:ma,:ten,:mota,:lamthem,:lamdem";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TLAP_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_TLAP_LAMTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_TLAP_LAMTHEM_XOA");
    }
    #endregion THIẾT LẬP TỶ LỆ THU BẢO HIỂM

    #region MÃ THAM SỐ LƯƠNG
    // Liet ke so lieu
    public static DataTable Fdt_TL_MA_TSL_LKE()
    {
        return dbora.Fdt_LKE("PTL_MA_TSL_LKE");
    }
    // Liet ke so lieu ma_ct
    public static DataTable Fdt_TL_MA_TSL_MA_CT_LKE(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PTL_MA_TSL_MA_CT_LKE");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_TL_MA_TSL_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PTL_MA_TSL_CT");
    }
    // Nhap so lieu
    public static void P_TL_MA_TSL_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt_ct, "tien");
            object[] a_mtran = bang.Fobj_COL_MANG(b_dt_ct, "mtran");

            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'S', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien", 'N', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "a_mtran", 'N', a_mtran);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ma_ct"]);
            b_c = b_c + ",:a_ngayd,:a_tien,:a_mtran";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PTL_MA_TSL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_TL_MA_TSL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PTL_MA_TSL_XOA");
    }
    #endregion MÃ THAM SỐ LƯƠNG

    #region MÃ BIỂU THUẾ
    // Liet ke so lieu
    public static DataTable Fdt_TL_MA_BT_LKE()
    {
        return dbora.Fdt_LKE("PTL_MA_BT_LKE");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_TL_MA_BT_CT(string b_ngayd)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngayd), "PTL_MA_BT_CT");
    }
    // Nhap so lieu
    public static void P_TL_MA_BT_NH(string b_ngayd, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_tu = bang.Fobj_COL_MANG(b_dt, "tu");
            object[] a_den = bang.Fobj_COL_MANG(b_dt, "den");
            object[] a_tsuat = bang.Fobj_COL_MANG(b_dt, "tsuat");

            dbora.P_THEM_PAR(ref b_lenh, "tu", 'N', a_tu);
            dbora.P_THEM_PAR(ref b_lenh, "den", 'N', a_den);
            dbora.P_THEM_PAR(ref b_lenh, "tsuat", 'N', a_tsuat);

            string b_c = "," + chuyen.CNG_CSO(b_ngayd) + ",:tu,:den,:tsuat";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PTL_MA_BT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion MÃ BIỂU THUẾ

    #region MÃ HỆ SỐ DOANH THU
    // Liet ke so lieu
    public static DataTable Fdt_NS_TL_MA_HSDT_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_HSDT_LKE");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_NS_TL_MA_HSDT_CT(string b_ngayd, string b_lcv)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_CSO(b_ngayd), b_lcv }, "PNS_TL_MA_HSDT_CT");
    }
    // Nhap so lieu
    public static void P_NS_TL_MA_HSDT_NH(string b_ngayd, string b_lcv, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_tient = bang.Fobj_COL_MANG(b_dt, "tient");
            object[] a_tiend = bang.Fobj_COL_MANG(b_dt, "tiend");
            object[] a_hsdt = bang.Fobj_COL_MANG(b_dt, "hsdt");

            dbora.P_THEM_PAR(ref b_lenh, "a_tient", 'N', a_tient);
            dbora.P_THEM_PAR(ref b_lenh, "a_tiend", 'N', a_tiend);
            dbora.P_THEM_PAR(ref b_lenh, "a_hsdt", 'N', a_hsdt);

            string b_c = "," + chuyen.CNG_CSO(b_ngayd) + "," + chuyen.OBJ_C(b_lcv) + ",:tient,:tiend,:hsdt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_MA_HSDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_NS_TL_MA_HSDT_XOA(string b_ngayd, string b_lcv)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CNG_CSO(b_ngayd), b_lcv }, "PNS_TL_MA_HSDT_XOA");
    }
    #endregion MÃ HỆ SỐ DOANH THU

    #region MÃ NGHIỆP VỤ LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_TL_MA_NV_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_NV_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_MA_NV_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_TL_MA_NV_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_TL_MA_NV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_MA_NV_XOA");
    }
    #endregion

    #region MÃ PHƯƠNG PHÁP
    // Liet ke so lieu
    public static DataTable Fdt_NS_TL_MA_PP_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_PP_LKE");
    }
    // Nhap so lieu
    public static void P_NS_TL_MA_PP_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ngayd"], b_dr["ten"], b_dr["hoi"] }, "PNS_TL_MA_PP_NH");
    }
    // Nhap so lieu
    public static void P_NS_TL_MA_PP_XOA(string b_ma, string b_ngayd)
    {
        dbora.P_GOIHAM(new object[] { b_ma, chuyen.CNG_CSO(b_ngayd) }, "PNS_TL_MA_PP_XOA");
    }
    #endregion PHƯƠNG PHÁP

    #region THIẾT LẬP TỶ LỆ THU BẢO HIỂM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_BH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_BH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_BH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_BH_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_BH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_TLAP_BH_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_BH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            DataRow b_dr = b_dt.Rows[0];
            int b_ngay = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay"]));

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_nguoi_ld = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_ld");
            object[] a_nguoi_sdld = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_sdld");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'U', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "nguoi_ld", 'N', a_nguoi_ld);
            dbora.P_THEM_PAR(ref b_lenh, "nguoi_sdld", 'N', a_nguoi_sdld);

            string b_c = ",:so_id," + b_ngay + ",:ma,:ten,:nguoi_ld,:nguoi_sdld";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TLAP_BH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_TLAP_BH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_TLAP_BH_XOA");
    }
    #endregion THIẾT LẬP TỶ LỆ THU BẢO HIỂM

    #region THIẾT LẬP THUẾ THU NHẬP CÁ NHÂN

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_THUE_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_THUE_LKE");
    }
    public static object[] Fdt_TL_TLAP_THUE_EXCEL(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "pns_tl_tlap_thue_excel");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_THUE_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_THUE_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_THUE_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_TLAP_THUE_CT");
    }

    // Nhap so lieu
    public static void P_TL_TLAP_THUE_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            int b_ngay = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay"]));

            object[] a_thunhaptu = bang.Fobj_COL_MANG(b_dt_ct, "thunhaptu");
            for (int i = 0; i < a_thunhaptu.Length; i++)
            {
                if (string.IsNullOrEmpty(a_thunhaptu[i].ToString()))
                {
                    a_thunhaptu[i] = 0;
                }
            }
            object[] a_thunhapden = bang.Fobj_COL_MANG(b_dt_ct, "thunhapden");
            object[] a_thuesuat = bang.Fobj_COL_MANG(b_dt_ct, "thuesuat");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "thunhaptu", 'N', a_thunhaptu);
            dbora.P_THEM_PAR(ref b_lenh, "thunhapden", 'N', a_thunhapden);
            dbora.P_THEM_PAR(ref b_lenh, "thuesuat", 'N', a_thuesuat);

            string b_c = ",:so_id," + b_ngay + "," + chuyen.OBJ_C(b_dr["DT_CUTRU"]) + ",:thunhaptu,:thunhapden,:thuesuat";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TLAP_THUE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_TLAP_THUE_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_TLAP_THUE_XOA");
    }
    #endregion THIẾT LẬP THUẾ THU NHẬP CÁ NHÂN

    #region THIẾT LẬP LƯƠNG TỐI THIỂU (NHÀ NƯỚC)
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_LUONGNN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_LUONGNN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_LUONGNN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_LUONGNN_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_LUONGNN_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_LUONGNN_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_LUONGNN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])), chuyen.OBJ_C(b_dr["so_qd"]), chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay_qd"])),
            chuyen.OBJ_S(b_dr["tien"]), chuyen.OBJ_C(b_dr["note"]) };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_LUONGNN_NH");
    }
    public static void P_TL_TLAP_LUONGNN_XOA(string b_ngay)
    {
        dbora.P_GOIHAM(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_LUONGNN_XOA");
    }
    #endregion THIẾT LẬP LƯƠNG TỐI THIỂU (NHÀ NƯỚC)

    #region THIẾT LẬP LƯƠNG TỐI THIỂU (CÔNG TY)
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_LUONGCT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_LUONGCT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_LUONGCT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_LUONGCT_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_LUONGCT_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_LUONGCT_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_LUONGCT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])), chuyen.OBJ_C(b_dr["so_qd"]), chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay_qd"])),
            chuyen.OBJ_S(b_dr["tien"]), chuyen.OBJ_C(b_dr["note"]) };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_LUONGCT_NH");
    }
    public static void P_TL_TLAP_LUONGCT_XOA(string b_ngay)
    {
        dbora.P_GOIHAM(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_LUONGCT_XOA");
    }
    #endregion THIẾT LẬP LƯƠNG TỐI THIỂU (CÔNG TY)

    #region THIẾT LẬP GIẢM TRỪ GIA CẢNH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_GTRU_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_GTRU_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_GTRU_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_GTRU_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_GTRU_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_GTRU_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_GTRU_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])), chuyen.OBJ_S(b_dr["giatri"]) };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_GTRU_NH");
    }
    public static void P_TL_TLAP_GTRU_XOA(string b_ngay)
    {
        dbora.P_GOIHAM(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_GTRU_XOA");
    }
    #endregion THIẾT LẬP GIẢM TRỪ GIA CẢNH

    #region THIẾT LẬP GIẢM TRỪ BẢN THÂN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_GTRU_BANTHAN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_GTRU_BANTHAN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_GTRU_BANTHAN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_GTRU_BANTHAN_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_GTRU_BANTHAN_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_GTRU_BANTHAN_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_GTRU_BANTHAN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])), chuyen.OBJ_S(b_dr["giatri"]) };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_GTRU_BANTHAN_NH");
    }
    public static void P_TL_TLAP_GTRU_BANTHAN_XOA(string b_ngay)
    {
        dbora.P_GOIHAM(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_GTRU_BANTHAN_XOA");
    }
    #endregion THIẾT LẬP GIẢM TRỪ BẢN THÂN

    #region THIẾT LẬP PHỤ CẤP
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_TL_TLAP_PCAP_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_PCAP_DROP_MA");
    }
    public static object[] Fdt_TL_TLAP_PCAP_LKE(double b_tu_n, double b_den_n, string b_day)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_day }, "NR", "PNS_TL_TLAP_PCAP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_PCAP_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_PCAP_MA");
    }

    // Nhap so lieu
    public static void P_TL_TLAP_PCAP_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_TL_TLAP_PCAP", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("PC", "NS_TL_TLAP_PCAP", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ngay"], b_dr["giatri"], b_dr["hinhthuc"], b_dr["tt"], b_dr["ghichu"] }, "PNS_TL_TLAP_PCAP_NH");
        b_ma = b_dr["ma"].ToString();
    }
    public static void P_TL_TLAP_PCAP_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_TLAP_PCAP_XOA");
    }
    #endregion THIẾT LẬP PHỤ CẤP

    #region MÃ SẢN PHẨM
    /// <summary>
    /// Liệt kê drop
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_TL_MA_SPHAM_LKE_DROP()
    {
        return dbora.Fdt_LKE("pns_TL_ma_SPHAM_drop_ma");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_SPHAM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_SPHAM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_SPHAM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_MA_SPHAM_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_SPHAM_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["donvi"] }, "PNS_TL_MA_SPHAM_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_MA_SPHAM_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_MA_SPHAM_XOA");
    }
    #endregion MÃ SẢN PHẨM

    #region MÃ CHẤT LƯỢNG
    /// <summary>
    /// Liệt kê drop
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_TL_MA_CHATLUONG_LKE_DROP()
    {
        return dbora.Fdt_LKE("pns_TL_ma_CHATLUONG_drop_ma");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_CHATLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_CHATLUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_CHATLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_MA_CHATLUONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_CHATLUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_TL_MA_CHATLUONG_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_MA_CHATLUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_MA_CHATLUONG_XOA");
    }
    #endregion MÃ CHẤT LƯỢNG

    #region MÃ ĐƠN GIÁ

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_DONGIA_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_DONGIA_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_DONGIA_MA(string b_masp, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_masp, chuyen.CNG_SO(b_ngay), b_trangkt }, "NNR", "PNS_TL_MA_DONGIA_MA");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_MA_DONGIA_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_MA_DONGIA_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_TL_MA_DONGIA_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["masp"]) + "," + chuyen.OBJ_C(b_dr["dongia"]) + "," + chuyen.OBJ_S(b_dr["ngay"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_tl_ma_dongia_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    ///<summary> Xóa </summary>
    ///
    public static void P_TL_MA_DONGIA_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_MA_DONGIA_XOA");
    }
    #endregion MÃ ĐƠN GIÁ

    #region MÃ HÌNH THỨC HƯỞNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_HTHUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTL_MA_HTHUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_HTHUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTL_MA_HTHUONG_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_HTHUONG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTL_MA_HTHUONG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_TL_MA_HTHUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PTL_MA_HTHUONG_XOA");
    }
    #endregion MÃ HUY HIỆU ĐẢNG

    #region THIẾT LẬP THƯỞNG SẢN PHẨM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_TL_TLAP_SPTHUONG_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_SPTHUONG_LKE");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_TLAP_SPTHUONG_CT(string b_ma, string b_cap)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_cap }, "PNS_TL_TLAP_SPTHUONG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TLAP_SPTHUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["cap"], b_dr["gtri"], b_dr["dongia"] }, "PNS_TL_TLAP_SPTHUONG_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_TLAP_SPTHUONG_XOA(string b_ma, string b_cap)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_cap }, "PNS_TL_TLAP_SPTHUONG_XOA");
    }
    #endregion THIẾT LẬP THƯỞNG SẢN PHẨM

    #region THIẾT LẬP THỜI LƯỢNG LÀM VIỆC
    public static object[] Fdt_TL_TLAP_THOILUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_THOILUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_THOILUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_THOILUONG_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_THOILUONG_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_CSO(b_ngay), "PNS_TL_TLAP_THOILUONG_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TLAP_THOILUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_S(b_dr["phong"]), chuyen.OBJ_S(b_dr["so_qd"]), chuyen.OBJ_S(b_dr["ngay_qd"]), chuyen.OBJ_S(b_dr["ngayd"]), chuyen.OBJ_S(b_dr["congcodinh"]), chuyen.OBJ_S(b_dr["cong"]), chuyen.OBJ_C(b_dr["songay"]), chuyen.OBJ_C(b_dr["sogio"]) }, "PNS_TL_TLAP_THOILUONG_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_TLAP_THOILUONG_XOA(string b_ngayd)
    {
        dbora.P_GOIHAM(chuyen.CNG_SO(b_ngayd), "PNS_TL_TLAP_THOILUONG_XOA");
    }
    #endregion THIẾT LẬP THƯỞNG SẢN PHẨM

    #region MÃ CHẤM CÔNG
    public static DataTable Fdt_CC_MA_CC_DR(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_CC_MA_CC_DR");
    }
    public static DataTable Fdt_CC_MA_CC_DR2(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_CC_MA_CC_DR2");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_MA_CC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_CC_LKE");
    }

    public static DataTable Fdt_CC_MA_CC_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_CC_MA_CC_EXCEL");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_MA_CC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_CC_MA");
    }

    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataSet Fdt_CC_MA_CC_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_CC_MA_CC_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_CC_MA_CC_NH(DataTable b_dt, DataTable b_dt_pc)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_mapc = bang.Fobj_COL_MANG(b_dt_pc, "mapc");
            object[] a_tenpc = bang.Fobj_COL_MANG(b_dt_pc, "tenpc");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_pc, "hso");

            dbora.P_THEM_PAR(ref b_lenh, "a_mapc", 'S', a_mapc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tenpc", 'U', a_tenpc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["tyle"])
                + "," + chuyen.OBJ_C(b_dr["ngoai"]) + "," + chuyen.OBJ_C(b_dr["anca"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["loai"])
                + "," + chuyen.OBJ_C(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["conggio"]) + "," + chuyen.OBJ_C(b_dr["tien2"])
                + "," + chuyen.OBJ_C(b_dr["conggio2"]) + "," + chuyen.OBJ_C(b_dr["sang"]) + "," + chuyen.OBJ_C(b_dr["chieu"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["mota"])
                + ",:a_mapc,:a_tenpc,:a_hso";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_CC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_CC_MA_CC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_MA_CC_XOA");
    }

    #endregion MÃ CHẤM CÔNG

    // lấy danh mục ca làm việc
    public static DataTable Fdt_NS_TL_TLAP_LAMCA_DR()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_LAMCA_DR");
    }
    #region THIẾT LẬP KIỂU CÔNG
    public static DataTable Fdt_CC_MA_TL_CC_DR(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_CC_MA_TL_CC_DR");
    }
    public static DataTable Fdt_CC_MA_TL_CC_DR2(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_CC_MA_TL_CC_DR2");
    }
    public static DataTable Fdt_NS_CC_MA_TL_CC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_CC_MA_TL_CC_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_CC_MA_TL_CC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_TL_CC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_CC_MA_TL_CC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_TL_CC_MA");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataSet Fdt_CC_MA_TL_CC_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_CC_MA_TL_CC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_CC_MA_TL_CC_NH(DataTable b_dt, DataTable b_dt_pc)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_mapc = bang.Fobj_COL_MANG(b_dt_pc, "mapc");
            object[] a_tenpc = bang.Fobj_COL_MANG(b_dt_pc, "tenpc");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_pc, "hso");
            dbora.P_THEM_PAR(ref b_lenh, "a_mapc", 'S', a_mapc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tenpc", 'U', a_tenpc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);
            string b_c = "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["tyle"])
                + "," + chuyen.OBJ_C(b_dr["ngoai"]) + "," + chuyen.OBJ_C(b_dr["anca"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["loai"]) + "," + chuyen.OBJ_C(b_dr["hluong"])
                + "," + chuyen.OBJ_C(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["conggio"]) + "," + chuyen.OBJ_C(b_dr["tien2"])
                + "," + chuyen.OBJ_C(b_dr["conggio2"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["mota"])
                + ",:a_mapc,:a_tenpc,:a_hso";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_TL_CC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_CC_MA_TL_CC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_MA_TL_CC_XOA");
    }

    #endregion MÃ CHẤM CÔNG

    #region PHƯƠNG PHÁP TÍNH LƯƠNG

    public static DataTable Fdt_NS_TL_PP_LUONG_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_PP_LUONG_LKE");
    }

    public static void PNS_TL_PP_LUONG_APDUNG(string b_pp)
    {
        dbora.P_GOIHAM(b_pp, "PNS_TL_PP_LUONG_APDUNG");
    }

    #endregion

    #region ĐƠN GIÁ LỢI NHUẬN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_LN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_LN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_LN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_MA_LN_MA");
    }

    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_MA_LN_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TL_MA_LN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_LN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten_dt"], b_dr["dongia"], b_dr["dvi"] }, "PNS_TL_MA_LN_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_MA_LN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_MA_LN_XOA");
    }
    #endregion

    #region MÃ CÔNG VIỆC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_CONGVIEC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_CONGVIEC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_CONGVIEC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_MA_CONGVIEC_MA");
    }
    public static DataTable Fdt_TL_MA_CONGVIEC_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TL_MA_CONGVIEC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_CONGVIEC_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), b_dr["donvi_tinh"], chuyen.OBJ_N(b_dr["gia"]), b_dr["mota"] }, "PNS_TL_MA_CONGVIEC_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_TL_MA_CONGVIEC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_MA_CONGVIEC_XOA");
    }
    #endregion MÃ CÔNG VIỆC

    #region THIẾT LẬP CA LÀM VIỆC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_LAMCA_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_LAMCA_LKE");
    }

    public static DataTable Fdt_TL_TLAP_LAMCA_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_LAMCA_LKE_ALL");
    }

    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_LAMCA_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_TLAP_LAMCA_MA");
    }

    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_TLAP_LAMCA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TL_TLAP_LAMCA_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TLAP_LAMCA_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["gio_bd"], b_dr["gio_kt"], b_dr["thoigian"], b_dr["hinhthuc"], b_dr["giovao_giuaca"], b_dr["giora_giuaca"], b_dr["ma_cong"], b_dr["quet_trua"], b_dr["trangthai"], b_dr["nghi_7_cn"], b_dr["duoc_dimuon"], b_dr["duoc_vesom"], b_dr["mota"] }, "PNS_TL_TLAP_LAMCA_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_TLAP_LAMCA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TL_TLAP_LAMCA_XOA");
    }
    // lấy giờ bắt đầu và giờ kết thúc theo mã ca làm việc
    public static DataTable Fdt_NS_TL_TLAP_LAMCA_BYMA(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TL_TLAP_LAMCA_BYMA");
    }
    #endregion THIẾT LẬP CA LÀM VIỆC

    #region THIẾT LẬP TÍNH NGHỈ PHÉP
    public static void P_NS_TL_TLAP_NGHIPHEP_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ngaycd"], b_dr["congdon"], b_dr["ma1ngay"], b_dr["manuangay"], b_dr["thamnien"], b_dr["ngaytang"], b_dr["ngaybdphep"] }, "PNS_TL_TLAP_NGHIPHEP_NH");
    }
    public static DataTable P_NS_TL_TLAP_NGHIPHEP_CT()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_NGHIPHEP_CT");
    }
    #endregion THIẾT LẬP TÍNH NGHỈ PHÉP

    #region THIẾT LẬP NGÀY NGHỈ ĐẶC BIỆT TRONG NĂM

    public static DataTable Fdt_NS_TL_TLAP_NGHI_NAM_CT(string ngay_thietlap)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(chuyen.CNG_SO(ngay_thietlap)) }, "ns_tl_tlap_ngaynghi_nam_ct");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static DataTable Fdt_NS_TL_TLAP_NGHI_NAM_LKE()
    {
        return dbora.Fdt_LKE("ns_tl_tlap_ngaynghi_nam_lke");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_TLAP_NGHI_NAM_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        bang.P_CNG_SO(ref b_dt, "ngay_thietlap");
        bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_ct, "noidung");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt_ct, "ngayc");
            object[] a_ma_nl = bang.Fobj_COL_MANG(b_dt_ct, "ma_nl");
            object[] a_ten_nl = bang.Fobj_COL_MANG(b_dt_ct, "ten_nl");
            //dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'U', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nl", 'U', a_ma_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_nl", 'U', a_ten_nl);
            string b_c = "," + chuyen.OBJ_S(b_dr["ngay_thietlap"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + ",:a_noidung,:a_ngayd,:a_ngayc,:a_ma_nl,:a_ten_nl";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".ns_tl_tlap_ngaynghi_nam_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                //return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_TL_TLAP_NGHI_NAM_XOA(string ngay_thietlap)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(chuyen.CNG_CSO(ngay_thietlap)) }, "ns_tl_tlap_ngaynghi_nam_xoa");
    }

    #endregion

    #region GÁN ID CHẤM CÔNG CHO CÁN BỘ
    public static object[] Fdt_TL_TN_GAN_CC_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_TN_GAN_CC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TN_GAN_CC_MA(string b_phong, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay), b_trangkt }, "NNR", "PNS_TL_TN_GAN_CC_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_TN_GAN_CC_CT(string b_phong, string b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_SO(b_ngay) }, "PNS_TL_TN_GAN_CC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TN_GAN_CC_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt_ct, "ten_phong");
            object[] a_id_cc = bang.Fobj_COL_MANG(b_dt_ct, "id_cc");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cdanh", 'S', a_id_cc);

            string b_c = "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])) + ",:a_so_the,:a_ten,:a_phong,:a_ten_phong,:a_id_cc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TN_GAN_CC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_TN_GAN_CC_XOA(string b_ngay)
    {
        dbora.P_GOIHAM(chuyen.CNG_CSO(b_ngay), "PNS_TL_TN_GAN_CC_XOA");
    }
    public static DataTable Fdt_TL_TN_GAN_CC_LKE_CB(string b_phong, string b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_SO(b_ngay) }, "PNS_TL_TN_GAN_CC_LKE_CB");
    }
    public static DataTable Fdt_TL_TN_GAN_CC_TINH_TU(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_TN_GAN_CC_TINH_TU");
        bang.P_THEM_COL(ref b_dt, new string[] { "ten", "cvu", "cdanh", "cdanhcv", "note" }, new string[] { "", "", "", "", "" });
        return b_dt;
    }
    #endregion GÁN ID CHẤM CÔNG CHO CÁN BỘ

    #region MÃ KỲ LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_KYLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_KYLUONG_LKE");
    }
    public static DataTable Fdt_NS_TL_MA_KYLUONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_KYLUONG_LKE_ALL");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_KYLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_MA_KYLUONG_MA");
    }

    public static object[] Fdt_TL_MA_KYLUONG_NAMTHANG(int b_nam, int b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_thang, b_trangkt }, "NNR", "PNS_TL_MA_KYLUONG_NAMTHANG");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static double P_TL_MA_KYLUONG_NH(double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);


            string b_c = ",:b_so_id,'',"
                + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_N(b_dr["nam"]) + ","
                + chuyen.OBJ_N(b_dr["thang"]) + ","
                + chuyen.OBJ_N(b_dr["ngay_bd"]) + ","
                + chuyen.OBJ_N(b_dr["ngay_kt"]) + ","
                + chuyen.OBJ_N(b_dr["cong_chuan"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_tl_ma_kyluong_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }

    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_TL_MA_KYLUONG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_MA_KYLUONG_XOA");
    }
    public static DataTable Fdt_TL_MA_KYLUONG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TL_MA_KYLUONG_CT");
    }
    public static DataTable Fdt_KIEMTRA_TONTAI_KYLUONG(string b_tungay, string b_denngay, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_tungay), chuyen.OBJ_N(b_denngay), b_ma }, "PNS_KIEMTRA_TONTAI_KYLUONG");
    }
    public static DataTable Fdt_KTRA_TONTAI_KYLUONG(double b_so_id, double b_nam, double b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_so_id }, "PNS_KTRA_TONTAI_KYLUONG");
    }
    public static DataTable Fdt_TL_MA_KYLUONG_BY_ID(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_MA_KYLUONG_BY_ID");
    }
    public static DataTable Fdt_TL_MA_KYLUONG_BY_DVID(string b_phong, double b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_so_id }, "PNS_TL_MA_KYLUONG_BY_DVID");
    }
    public static DataTable Fdt_CC_MA_CC_TOP()
    {
        return dbora.Fdt_LKE_S(0, "PNS_CC_MA_CC_TOP");
    }
    public static DataTable Fdt_CC_MA_CA_TOP()
    {
        return dbora.Fdt_LKE_S(0, "PNS_CC_MA_CA_TOP");
    }
    #endregion MÃ KỲ LƯƠNG

    #region DANH MỤC NHÓM NHÓM LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fs_TL_MA_NHOMLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTL_MA_NHOMLUONG_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_MA_NHOMLUONG_LKE()
    {
        return dbora.Fdt_LKE("PTL_MA_NHOMLUONG_LKE2");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_NHOMLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTL_MA_NHOMLUONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_NHOMLUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTL_MA_NHOMLUONG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_TL_MA_NHOMLUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PTL_MA_NHOMLUONG_XOA");
    }
    #endregion DANH MỤC NHÓM NĂNG LỰC

    #region THIẾT LẬP DANH MỤC LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_TL_MA_LUONG_LKE()
    {
        return dbora.Fdt_LKE("PTL_MA_LUONG_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_MA_LUONG_LKE(string b_nhomluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhomluong, b_tu_n, b_den_n }, "NR", "PTL_MA_LUONG_LKE");
    }
    public static DataTable Fdt_TL_MA_LUONG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PTL_MA_LUONG_CT");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_MA_LUONG_MA(string b_nhomluong, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nhomluong, b_ma, b_trangkt }, "NNR", "PTL_MA_LUONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_MA_LUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["nluong"], b_dr["kdl"], b_dr["tt"], b_dr["is_hienthi"], b_dr["is_dauvao"], b_dr["is_import"], b_dr["is_congthuc"] }, "PTL_MA_LUONG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_TL_MA_LUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PTL_MA_LUONG_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO CHỨC DANH

    #region THIẾT LẬP CA MẶC ĐỊNH
    public static DataSet Fdt_NS_DT_CMD_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 3, "PNS_DT_CMD_CT");
    }

    public static object[] Fdt_DT_NS_CB(string b_phong, string b_lke, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_lke, "", "N'%%", b_tu, b_den }, "NR", "PNS_CB_LKE");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_DT_CMD_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_CMD_LKE");
    }
    public static DataSet Fdt_NS_DT_CMD_EXCEL()
    {
        return dbora.Fds_LKE(2, "PNS_DT_CMD_EXCEL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_CMD_MA(string b_so_id, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_ma, b_trangkt }, "NNR", "PNS_DT_CMD_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_CMD_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_dvi)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");

            object[] a_chon = bang.Fobj_COL_MANG(b_dt_dvi, "chon");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_dvi, "stt");
            object[] a_ma_phong = bang.Fobj_COL_MANG(b_dt_dvi, "ma_phong");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt_dvi, "ten_phong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);

            dbora.P_THEM_PAR(ref b_lenh, "a_chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_phong", 'S', a_ma_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ng_hluc"]) + "," + chuyen.OBJ_C(b_dr["ng_het_hluc"]) + "," + chuyen.OBJ_C(b_dr["ma_ca"]) + ","
                + chuyen.OBJ_C(b_dr["mota"]) + "," + chuyen.OBJ_C(b_dr["theo_nv"]) + "," + chuyen.OBJ_C(b_dr["theo_dvi"]) + "," + chuyen.OBJ_C(b_dr["phong_tk"])
                 + ",:a_tt,:a_so_the,:a_ten,:a_phong,:a_chon,:a_stt,:a_ma_phong,:a_ten_phong";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_MA_CMD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_C(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_DT_CMD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_CMD_XOA");
    }
    #endregion

    #region MÃ TỰ SINH
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TUSINH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["sothe"], b_dr["tiento"], b_dr["DodaiSothe"], b_dr["hopdong"], b_dr["DodaiHD"], b_dr["quyetdinh"], b_dr["DoDaiQD"] }, "PNS_MA_TUSINH_NH");
        }
    }
    public static DataTable Fdt_HT_MA_TUSINH_MA(string b_ma)
    {
        return dbora.Fdt_LKE("PNS_HT_MA_TUSINH_MA");
    }
    #endregion MÃ KỲ LƯƠNG

    #region THIẾT LẬP ĐƠN GIÁ THỰC TẬP SINH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_DONGIA_TTS_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_DONGIA_TTS_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_DONGIA_TTS_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_DONGIA_TTS_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_DONGIA_TTS_CT(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CSO_SO(b_ngay), "PNS_TL_TLAP_DONGIA_TTS_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_DONGIA_TTS_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])),
                                        chuyen.OBJ_S(b_dr["giatri"]),
                                        chuyen.OBJ_S(b_dr["ghichu"])
        };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_DONGIA_TTS_NH");
    }
    public static void P_TL_TLAP_DONGIA_TTS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_TLAP_DONGIA_TTS_XOA");
    }
    #endregion

    #region THIẾT LẬP ĐIỀU KIỆN THIẾU PHIẾU LỆNH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_THIEU_PHIEULENH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_THIEU_PL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_THIEU_PHIEULENH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_THIEU_PHIEULENH_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_THIEU_PHIEULENH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.CSO_SO(b_so_id), "PNS_TL_TLAP_THIEU_PHIEULENH_CT");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_THIEU_PHIEULENH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"])),
                                        chuyen.OBJ_S(b_dr["LAN1"]),
                                        chuyen.OBJ_S(b_dr["LAN2"]),
                                        chuyen.OBJ_S(b_dr["LAN3"]),
                                        chuyen.OBJ_S(b_dr["LAN3_THU"]),
                                        chuyen.OBJ_S(b_dr["ghichu"])
        };
        dbora.P_GOIHAM(a_obj, "PNS_TL_TLAP_THIEU_PHIEULENH_NH");
    }
    public static void P_TL_TLAP_THIEU_PHIEULENH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_TL_TLAP_THIEU_PL_XOA");
    }
    #endregion

    #region THIẾT LẬP TỶ LÊ HOA HỒNG
    public static DataTable Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(string b_ngay)
    {
        return dbora.Fdt_LKE_S(chuyen.CNG_SO(b_ngay), "PNS_TL_TLAP_TYLE_HOAHONG_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TL_TLAP_TYLE_HOAHONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_TLAP_TYLE_HOAHONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TLAP_TYLE_HOAHONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ma), b_trangkt }, "NNR", "PNS_TL_TLAP_TYLE_HOAHONG_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TLAP_TYLE_HOAHONG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.CSO_SO(b_so_id), "PNS_TL_TLAP_TYLE_HOAHONG_CT");
    }
    public static DataTable Fdt_TL_TLAP_TYLE_HOAHONG_TRANG()
    {
        return dbora.Fdt_LKE("PNS_TL_TLAP_TYLE_HOAHONG_TRANG");
    }
    // Nhap so lieu
    public static void P_TL_TLAP_TYLE_HOAHONG_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_dtnv = bang.Fobj_COL_MANG(b_dt_ct, "dtnv");
            object[] a_phi_tu = bang.Fobj_COL_MANG(b_dt_ct, "phi_tu");
            object[] a_phi_den = bang.Fobj_COL_MANG(b_dt_ct, "phi_den");
            object[] a_tyle = bang.Fobj_COL_MANG(b_dt_ct, "tyle");

            dbora.P_THEM_PAR(ref b_lenh, "a_dtnv", 'S', a_dtnv);
            dbora.P_THEM_PAR(ref b_lenh, "a_phi_tu", 'N', a_phi_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_phi_den", 'N', a_phi_den);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle", 'N', a_tyle);

            string c = ",:so_id," + chuyen.OBJ_S(b_dr["ngay"]) + "," + chuyen.OBJ_C(b_dr["bmau"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            c = c + ",:a_dtnv,:a_phi_tu,:a_phi_den,:a_tyle";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TLAP_TYLE_HOAHONG_NH(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_TLAP_TYLE_HOAHONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_TL_TLAP_TYLE_HOAHONG_XOA");
    }
    #endregion

    #region GIA HẠN CẮT PHÉP


    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_CC_MA_GHCP_LKE(string b_so_the_tk, string b_ten_tk, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_tu_n, b_den_n }, "NR", "PNS_CC_MA_GHCP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_CC_MA_GHCP_MA(string b_so_the, string b_so_the_tk, string b_ten_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_the_tk, "N'" + b_ten_tk, b_trangkt }, "NNR", "PNS_CC_MA_GHCP_MA");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_CC_MA_GHCP_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CC_MA_GHCP_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_CC_MA_GHCP_NH(DataTable b_dt)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_ghcp"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_GHCP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_CC_MA_GHCP_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_CC_MA_GHCP_XOA");
    }

    #endregion

    #region FORM TEST
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_CC_MA_FORMTEST_LKE(string b_so_the_tk, string b_ten_tk, string b_cdanh_moi_tk, string b_trangthai_tk, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_cdanh_moi_tk, b_trangthai_tk, b_tu_n, b_den_n }, "NR", "PNS_CC_MA_FORMTEST_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_CC_MA_FORMTEST_MA(string b_so_the, string b_so_the_tk, string b_ten_tk, string b_cdanh_moi_tk, string b_trangthai_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_the_tk, "N'" + b_ten_tk, b_cdanh_moi_tk, b_trangthai_tk, b_trangkt }, "NNR", "PNS_CC_MA_FORMTEST_MA");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_NS_CC_MA_FORMTEST_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CC_MA_FORMTEST_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CC_MA_FORMTEST_NH(DataTable b_dt)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["cdanh_moi"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["tichdong_bh"]) + "," + chuyen.OBJ_C(b_dr["ngay_hl"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_FORMTEST_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_CC_MA_FORMTEST_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_CC_MA_FORMTEST_XOA");
    }

    #endregion

    #region THIẾT LẬP KHOẢN PHẢI THU
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] PNS_TL_KHOAN_PHAITHU_LKE(string b_so_the, string b_ten, string b_nam, string b_kyluong_id, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_kyluong_id), b_tu, b_den }, "NR", "PNS_TL_KHOAN_PHAITHU_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TL_KHOAN_PHAITHU_MA(string b_so_the, string b_ten, string b_nam, string b_kyluong_id, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_kyluong_id), b_so_id, b_trangkt }, "NNR", "PNS_TL_KHOAN_PHAITHU_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TL_KHOAN_PHAITHU_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TL_KHOAN_PHAITHU_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TL_KHOAN_PHAITHU_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"])
                        + "," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_N(b_dr["kyluong_id"]) + "," + chuyen.OBJ_N(b_dr["sotien_thu"]) + "," + chuyen.OBJ_N(b_dr["sotien_tra"])
                        + "," + chuyen.OBJ_N(b_dr["ngaytao"]) + "," + chuyen.OBJ_C(b_dr["noidung_thu"]) + "," + chuyen.OBJ_C(b_dr["noidung_tra"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_KHOAN_PHAITHU_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_TL_KHOAN_PHAITHU_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_KHOAN_PHAITHU_XOA");
    }
    // DÙNG CHUNG PROCEDURE
    public static object[] Fdt_NS_TL_KHOAN_PHAITHU_TRA(string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the }, "R", "PNS_KHOAN_HT_THEM_TRA");
    }
    public static DataTable PNS_TL_KHOAN_PHAITHU_EXPORT(string b_so_the, string b_ten_tk)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, "N'" + b_ten_tk }, "PNS_TL_KHOAN_PHAITHU_EXPORT");
    }
    #endregion THIẾT LẬP KHOẢN PHẢI THU
}