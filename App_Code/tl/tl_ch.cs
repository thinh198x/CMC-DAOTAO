using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class tl_ch
{
    #region QUYẾT TOÁN THUẾ
    public static string P_NS_TL_QTTHUE_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_uyquyen = bang.Fobj_COL_MANG(b_dt_ct, "uyquyen");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_uyquyen", 'S', a_uyquyen);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_cdanh,:a_phong,:a_uyquyen";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_QTTHUE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string P_NS_TL_QTTHUE_IMP_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            var b_c = ",:a_nam,:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_QTTHUE_IMP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_TL_QTTHUE, TEN_BANG.NS_TL_QTTHUE);
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_TL_QTTHUE_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_TL_QTTHUE_MA");
    }
    public static object[] Faobj_NS_TL_QTTHUE_MA2(string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), b_trangkt }, "NNR", "PNS_TL_QTTHUE_MA2");
    }
    public static object[] Faobj_NS_TL_QTTHUE_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_TL_QTTHUE_LKE");
    }
    public static DataSet Fds_NS_TL_QTTHUE_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_TL_QTTHUE_CT");
    }
    public static void P_NS_TL_QTTHUE_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_QTTHUE_XOA");
    }
    public static DataTable Fdt_NS_TL_QTTHUE_EXPORT(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_TL_QTTHUE_EXPORT");
    }
    public static object[] Faobj_NS_TL_QTTHUE_UQUYEN_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_TL_QTTHUE_UQUYEN_LKE");
    }
    public static DataTable Fds_NS_TL_QTTHUE_UQUYEN_CT(string b_so_id, string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_so_id), b_so_the }, "PNS_TL_QTTHUE_UQUYEN_CT");
    }
    public static string P_NS_TL_QTTHUE_UQUYEN_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"])
                        + "," + chuyen.OBJ_C(b_dr["so_the"])
                        + "," + chuyen.OBJ_C(b_dr["ho_ten"])
                        + "," + chuyen.OBJ_C(b_dr["ten_cdanh"])
                        + "," + chuyen.OBJ_C(b_dr["ten_phong"])
                        + "," + chuyen.OBJ_C(b_dr["uyquyen"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_QTTHUE_UQUYEN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_TL_QTTHUE_UQUYEN_MA(string b_nam, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), b_so_the, b_trangkt }, "NNR", "PNS_TL_QTTHUE_UQUYEN_MA");
    }

    public static DataTable Fds_NS_TL_QTTHUE_XTTIN_CT(string b_nam, string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "PNS_TL_QTTHUE_XTTIN_CT");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_LNAM(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "N", "PNS_TL_QTTHUE_XTTIN_LNAM");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_TTNNAM(string b_nam, string b_so_the, string b_tu_ngay, string b_den_ngay)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the, chuyen.CSO_SO(b_tu_ngay), chuyen.CSO_SO(b_den_ngay) }, "N", "PNS_TL_QTTHUE_XTTIN_TTNNAM");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_TTNMTHUE(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "N", "PNS_TL_QTTHUE_XTTIN_TTNMTHUE");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_TTNTTHUE(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "N", "PNS_TL_QTTHUE_XTTIN_TTNTTHUE");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_TGTRU(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "N", "PNS_TL_QTTHUE_XTTIN_TGTRU");
    }
    public static object[] Fds_NS_TL_QTTHUE_XTTIN_BHIEM(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_so_the }, "N", "PNS_TL_QTTHUE_XTTIN_BHIEM");
    }
    #endregion QUYẾT TOÁN THUẾ

    #region XỬ LÝ VI PHẠM

    public static string P_NS_TL_VIPHAM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["loai_vp"]) + "," + chuyen.OBJ_S(b_dr["lan_vp"]) + "," + chuyen.OBJ_S(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["co_tinhluong"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["kyluong"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_VIPHAM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_TL_VIPHAM_MA(string b_so_id, string b_phong, string b_nam, string b_ky, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_phong, b_nam, chuyen.OBJ_N(b_ky), b_trangkt }, "NNR", "PNS_TL_VIPHAM_MA");
    }
    public static object[] Faobj_NS_TL_VIPHAM_LKE(string b_phong, string b_nam, string b_ky, string b_sothe, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam, chuyen.OBJ_N(b_ky), b_sothe, b_tu, b_den }, "NR", "PNS_TL_VIPHAM_LKE");
    }
    public static object[] Faobj_NS_TL_VIPHAM_LKE_ALL(string b_phong, string b_nam, string b_ky, string b_sothe, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam, chuyen.OBJ_N(b_ky), b_sothe, b_tu, b_den }, "NR", "PNS_TL_VIPHAM_LKE_ALL");
    }
    public static DataTable Fdt_NS_TL_VIPHAM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TL_VIPHAM_CT");
    }
    public static void P_NS_TL_VIPHAM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_VIPHAM_XOA");
    }
    #endregion XỬ LÝ VI PHẠM

    #region HƯỞNG PHỤ CẤP
    public static object[] Fdt_TL_TN_PCAP_LKE(string b_ma_goc, string b_phong, string b_theo, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_goc, b_phong, b_theo, b_tu_n, b_den_n }, "NR", "PNS_TL_TN_PCAP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TN_PCAP_MA(string b_ma_goc, string b_phong, string b_ngay, string b_theo, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_goc, b_phong, chuyen.CNG_CSO(b_ngay), b_theo, b_trangkt }, "NNR", "PNS_TL_TN_PCAP_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_TL_TN_PCAP_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_TN_PCAP_CT");
    }
    public static DataTable Fdt_TL_TN_PCAP_DSACH(string b_so_the, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CTH_SO(chuyen.OBJ_S(b_thang)) }, "pns_tinh_phucap_tke");
    }

    // Nhap so lieu
    public static void P_TL_TN_PCAP_NH(string b_so_id, string b_so_qd_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_mapc = bang.Fobj_COL_MANG(b_dt_ct, "mapc");
            object[] a_tenpc = bang.Fobj_COL_MANG(b_dt_ct, "tenpc");
            object[] a_giatri = bang.Fobj_COL_MANG(b_dt_ct, "giatri");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt_ct, "hinhthuc");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "mapc", 'S', a_mapc);
            dbora.P_THEM_PAR(ref b_lenh, "tenpc", 'U', a_tenpc);
            dbora.P_THEM_PAR(ref b_lenh, "giatri", 'N', a_giatri);
            dbora.P_THEM_PAR(ref b_lenh, "hinhthuc", 'S', a_hinhthuc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma_goc"]) + "," + chuyen.OBJ_C(b_dr["theo"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"]))
                + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay_qd"])) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"]))
                + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])) + b_so_qd_id + ",:mapc,:tenpc,:giatri,:hinhthuc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TN_PCAP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_TL_TN_PCAP_NH2(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_giatri = bang.Fobj_COL_MANG(b_dt_ct, "giatri");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt_ct, "hinhthuc");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "mapc", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "tenpc", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "giatri", 'N', a_giatri);
            dbora.P_THEM_PAR(ref b_lenh, "hinhthuc", 'S', a_hinhthuc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma_goc"]) + "," + chuyen.OBJ_C(b_dr["theo"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay"]))
                + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngay_qd"])) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])) + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])) + ",:so_the,:ten,:giatri,:hinhthuc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TN_PCAP_NH2(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_TL_TN_PCAP_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_TN_PCAP_XOA");
    }
    #endregion HƯỞNG PHỤ CẤP

    #region HỒI TỐ LƯƠNG
    // Liet ke so lieu
    public static DataTable Fdt_TL_HT_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_HT_LKE");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_TL_HT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_HT_CT");
    }
    // Nhap so lieu
    public static string P_TL_HT_NH(ref string b_so_id, string b_thang, string b_note, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_giatri = bang.Fobj_COL_MANG(b_dt, "giatri");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "giatri", 'N', a_giatri);
            dbora.P_THEM_PAR(ref b_lenh, "ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + chuyen.OBJ_S(chuyen.CTH_CSO(b_thang)) + "," + chuyen.OBJ_C(b_note) + ",:so_the,:ten,:phong,:giatri,:ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_HT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_HT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_HT_XOA");
    }
    #endregion HỒI TỐ LƯƠNG

    #region KHẤU TRỪ BẢO HIỂM
    public static object[] Fdt_TL_KTRU_BH_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TL_KTRU_BH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_TL_KTRU_BH_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_KTRU_BH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_KTRU_BH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_KTRU_BH_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_KTRU_BH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_ct, "hso");
            object[] a_hspc = bang.Fobj_COL_MANG(b_dt_ct, "hspc");
            object[] a_bhxh = bang.Fobj_COL_MANG(b_dt_ct, "bhxh");
            object[] a_bhyt = bang.Fobj_COL_MANG(b_dt_ct, "bhyt");
            object[] a_bhtn = bang.Fobj_COL_MANG(b_dt_ct, "bhtn");
            object[] a_pcd = bang.Fobj_COL_MANG(b_dt_ct, "pcd");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);
            dbora.P_THEM_PAR(ref b_lenh, "a_hspc", 'N', a_hspc);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'N', a_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhyt", 'N', a_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhtn", 'N', a_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_pcd", 'N', a_pcd);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"]))
                + ",:a_so_the" + ",:a_ten" + ",:a_hso" + ",:a_hspc" + ",:a_bhxh" + ",:a_bhyt" + ",:a_bhtn" + ",:a_pcd" + ",:a_note";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_KTRU_BH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_KTRU_BH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_KTRU_BH_XOA");
    }
    public static DataTable Fdt_TL_KTRU_BH_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_KTRU_BH_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "hso", "hspc", "bhxh", "bhyt", "bhtn", "pcd", "note" }, new string[] { "", "", "", "", "", "", "" });
        return b_dt;
    }
    public static DataTable Fdt_TL_KTRU_BH_LKE_BH(string b_thang, string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_CSO(b_thang), b_phong }, "PNS_TL_KTRU_BH_LKE_BH");
        bang.P_THEM_COL(ref b_dt, new string[] { "ten", "note" }, new string[] { "", "" });
        return b_dt;
    }
    #endregion KHẤU TRỪ BẢO HIỂM

    #region KHẤU TRỪ THUẾ
    public static object[] Fdt_TL_KTRU_THUE_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TL_KTRU_THUE_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_TL_KTRU_THUE_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_KTRU_THUE_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_KTRU_THUE_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_KTRU_THUE_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_KTRU_THUE_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_tongchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tongchiuthue");
            object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt_ct, "phuthuoc");
            object[] a_truthue = bang.Fobj_COL_MANG(b_dt_ct, "truthue");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongchiuthue", 'N', a_tongchiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'N', a_phuthuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_truthue", 'N', a_truthue);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thang"])
                + ",:a_so_the,:a_ten,:a_tongchiuthue,:a_phuthuoc,:a_truthue";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_KTRU_THUE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_KTRU_THUE_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_KTRU_THUE_XOA");
    }
    public static DataTable Fdt_TL_KTRU_THUE_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_KTRU_THUE_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "tongchiuthue", "phuthuoc", "truthue" },
            new string[] { "", "", "" });
        return b_dt;
    }

    ///<summary> tinh thue </summary>
    public static DataTable Fdt_TL_KTRU_THUE_TINH(string b_thang, string b_phong)
    {
        int a = chuyen.CTH_SO(b_thang);
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang), b_phong }, "PNS_TL_KTRU_THUE_TINH");
        bang.P_THEM_COL(ref b_dt, new string[] { "tongpc", "thunhap_khac" },
            new string[] { "", "" });
        return b_dt;
    }

    #endregion KHẤU TRỪ THUẾ

    #region THU NHẬP/KHẤU TRỪ KHÁC
    public static object[] Fdt_TL_TNKT_KHAC_LKE(string b_so_the, string b_loai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_loai, b_tu, b_den }, "NR", "PNS_TL_TNKT_KHAC_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_TL_TNKT_KHAC_MA(string b_so_the, string b_loai, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_loai, chuyen.CNG_CSO(b_ngay), b_trangkt }, "NNR", "PNS_TL_TNKT_KHAC_MA");
    }

    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_TNKT_KHAC_CT(string b_so_the, string b_loai, string b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_loai, chuyen.CNG_SO(b_ngay) }, "PNS_TL_TNKT_KHAC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TNKT_KHAC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["ngay"], b_dr["tien"], b_dr["chiuthue"], b_dr["loai"], b_dr["note"] }, "PNS_TL_TNKT_KHAC_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_TNKT_KHAC_XOA(string b_so_the, string b_loai, string b_ngay)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_loai, chuyen.CNG_CSO(b_ngay) }, "PNS_TL_TNKT_KHAC_XOA");
    }
    #endregion THU NHẬP/KHẤU TRỪ KHÁC

    #region KẾ HOẠCH LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_TL_KH_LUONG_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_KH_LUONG_LKE");
    }
    /// <summary>Liệt kê chi tiet số liệu</summary>
    public static DataTable Fdt_TL_KH_LUONG_CT(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_TL_KH_LUONG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_KH_LUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nam"], b_dr["ql_khoach"], b_dr["ql_chitra"], b_dr["ql_duphong"],
            b_dr["ql_khenthuong"], b_dr["note"] }, "PNS_TL_KH_LUONG_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_TL_KH_LUONG_XOA(string b_nam)
    {
        dbora.P_GOIHAM(b_nam, "PNS_TL_KH_LUONG_XOA");
    }
    #endregion KẾ HOẠCH LƯƠNG

    #region TẠM ỨNG
    public static object[] Fdt_TL_TN_TU_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_TN_TU_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_TN_TU_MA(string b_phong, string b_thang, double b_trangkt)
    {
        int thang = chuyen.CTH_SO(b_thang);
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_TN_TU_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_TN_TU_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_TN_TU_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_TN_TU_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_ma_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ma_cdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_tamung = bang.Fobj_COL_MANG(b_dt_ct, "tamung");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cdanh", 'S', a_ma_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tamung", 'N', a_tamung);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"])) + ",:a_so_the,:a_ten,:a_phong,:a_ten_phong,:a_ma_cdanh,:a_cdanh,:a_tamung,:a_note";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_TN_TU_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_TN_TU_XOA(string b_thang)
    {
        dbora.P_GOIHAM(chuyen.CTH_CSO(b_thang), "PNS_TL_TN_TU_XOA");
    }
    public static DataTable Fdt_TL_TN_TU_LKE_CB(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_TN_TU_LKE_CB");
    }
    public static DataTable Fdt_TL_TN_TU_TINH_TU(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_TN_TU_TINH_TU");
        bang.P_THEM_COL(ref b_dt, new string[] { "ten", "cvu", "cdanh", "cdanhcv", "note" }, new string[] { "", "", "", "", "" });
        return b_dt;
    }
    #endregion TẠM ỨNG

    #region KHAI BAO GIU LUONG

    public static DataTable Fdt_GET_LUONG_BY_SOTHE(string b_sothe, string b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_sothe, chuyen.OBJ_N(b_kyluong) }, "PNS_GET_LUONG_BY_SOTHE");
    }

    public static DataTable Fdt_GIULUONG_LKE_ALL(string b_phong, string b_ten, string b_kycong, double b_tu_n, double b_den_n)
    {
        object[] obj = dbora.Faobj_LKE(new object[] { b_phong, "N" + chuyen.OBJ_C(b_ten), chuyen.OBJ_N(b_kycong), b_tu_n, b_den_n }, "NR", "PNS_GIULUONG_LKE");
        if (obj.Length > 0)
        {
            return (DataTable)obj[1];
        }
        return null;
    }
    public static object[] Faobj_NS_TL_GIULUONG_LKE(string b_phong, string b_ten, string b_kycong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_ten, chuyen.OBJ_N(b_kycong), b_tu_n, b_den_n }, "NR", "PNS_NS_TL_GIULUONG_LKE");
    }
    public static DataTable Fdt_NS_TL_GIULUONG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_NS_TL_GIULUONG_CT");
    }
    public static string P_NS_TL_GIULUONG_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + ","
               + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]) + "," + chuyen.OBJ_S(b_dr["tien_luong"]) + "," + chuyen.OBJ_S(b_dr["tien_giu"]) + "," + chuyen.OBJ_S(b_dr["ngay_tt"]) + "," + chuyen.OBJ_C(b_dr["DIEN_GIAI"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_TL_GIULUONG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TL_GIULUONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_NS_TL_GIULUONG_XOA");
    }
    public static object[] Fdt_NS_TL_GIULUONG_MA(string b_so_the, string b_phong, string b_kyluong, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_phong, chuyen.OBJ_N(b_kyluong), b_trangkt }, "NNR", "PNS_NS_TL_GIULUONG_MA");
    }
    #endregion

    #region DDÙNG CHUNG CHO 4 BẢNG LƯƠNG TANVIET
    public static DataTable Fdt_NS_TL_BLUONG_COTTK(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_TL_BLUONG_COTTK");
    }
    public static DataTable Fdt_NS_TL_BLUONG_COTTK_STYLE(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_TL_BLUONG_COTTK_STYLE");
    }
    public static DataTable Fdt_NS_TL_BLUONG_COT(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_TL_BLUONG_COT");
    }
    public static DataTable Fdt_NS_TL_BLUONG_COT_STYLE(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_TL_BLUONG_COT_STYLE");
    }
    public static DataTable Fdt_NS_TL_BLUONGTK_LKE_COTSO(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_CC_CN_BLUONGTK_LKE_COTSO");
    }
    public static DataTable Fdt_NS_TL_BLUONG_LKE_COTSO(string b_dtuong)
    {
        return dbora.Fdt_LKE_S(b_dtuong, "PNS_CC_CN_BLUONG_LKE_COTSO");
    }
    #endregion DÙNG CHUNG CHO 4 BẢNG LƯƠNG TANVIET

    #region BẢNG LƯƠNG KHỐI BACK TANVIET
    public static object[] Faobj_NS_TL_BLUONG_CT(string b_phong, string b_kyluong_id, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_tu, b_den }, "NR", "PNS_TL_BLUONG_CT");
    }
    public static object[] Faobj_NS_TL_BLUONG_TK_CT(string b_phong, string b_kyluong_id, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_tu, b_den }, "NR", "PNS_TL_BLUONG_TK_CT");
    }
    public static DataSet Fdt_TL_BLUONG_TINH(string b_phong, string b_kyluong, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the }, 2, "pns_tl_bluong_th");
    }
    public static DataSet Fdt_NS_TL_BLUONG_EXCEL(string b_phong, string b_kyluong_id, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the }, 3, "PNS_TL_BLUONG_EXCEL");
    }
    #endregion BẢNG LƯƠNG KHỐI BACK TANVIET

    #region BẢNG LƯƠNG KHỐI SALE TANVIET
    public static object[] Faobj_NS_TL_BLUONG_SALE_CT(string b_phong, string b_kyluong_id, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_tu, b_den }, "NR", "PNS_TL_BLUONG_SALE_CT");
    }
    public static object[] Faobj_NS_TL_BLUONG_SALE_TK_CT(string b_phong, string b_kyluong_id, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_tu, b_den }, "NR", "PNS_TL_BLUONG_SALE_TK_CT");
    }
    public static DataSet Fdt_TL_BLUONG_SALE_TINH(string b_phong, string b_kyluong, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the }, 2, "PNS_TL_BLUONG_SALE_TH");
    }
    public static DataSet Fdt_NS_TL_BLUONG_SALE_EXCEL(string b_phong, string b_kyluong_id, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the }, 3, "PNS_TL_BLUONG_SALE_EXCEL");
    }
    #endregion BẢNG LƯƠNG KHỐI SALE TANVIET 

    #region BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BB
    public static object[] Fdt_NS_TL_BLUONG_BB_LKE(string b_nam, string b_kyluong_id, string b_so_the, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_BLUONG_BB_LKE");
    }
    public static void Fs_NS_TL_BLUONG_BB_TH(string b_nam, string b_kyluong_id, string b_so_the, string b_phong)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong }, "PNS_TL_BLUONG_BB_TH");
    }
    #endregion BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BB

    #region BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BS
    public static object[] Fdt_NS_TL_BLUONG_BS_LKE(string b_nam, string b_kyluong_id, string b_so_the, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_BLUONG_BS_LKE");
    }
    public static void Fs_NS_TL_BLUONG_BS_TH(string b_nam, string b_kyluong_id, string b_so_the, string b_phong)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong }, "PNS_TL_BLUONG_BS_TH");
    }
    #endregion BẢNG LƯƠNG CÔNG TÁC VIÊN KHỐI BS

    #region BẢNG LƯƠNG THỰC TẬP SINH
    public static object[] Fdt_NS_TL_BLUONG_TTS_LKE(string b_nam, string b_kyluong_id, string b_so_the, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_BLUONG_TTS_LKE");
    }
    public static void Fs_NS_TL_BLUONG_TTS_TH(string b_nam, string b_kyluong_id, string b_so_the, string b_phong)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong }, "PNS_TL_BLUONG_TTS_TH");
    }
    #endregion BẢNG LƯƠNG THỰC TẬP SINH

    #region IMPORT LƯƠNG THÁNG
    public static DataTable Fdt_BANGLUONG_IMP_COT(string b_nhomluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhomluong }, "PNS_BANGLUONG_IMP_COT");
    }
    public static DataSet Fdt_BANGLUONG_IMP_DATA(string b_phong, double b_kyluong, string b_nhomluong)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_kyluong, b_nhomluong }, 2, "PNS_BANGLUONG_IMP_DATA");
    }

    public static void Fdt_BANGLUONG_IMP_NH(DataTable b_dt)
    {
        DataTable dtData = new DataTable();
        dtData.Columns.Add("SO_THE");
        dtData.Columns.Add("KYLUONG_ID");
        dtData.Columns.Add("MA_LUONG");
        dtData.Columns.Add("GIATRI");
        dtData.Columns.Add("GHICHU");
        dtData.Columns.Add("NHOMLUONG");
        dtData.Columns.Add("PHONG");
        DataRow b_drow;
        foreach (DataRow row in b_dt.Rows)
        {
            for (int i = 7; i < b_dt.Columns.Count; i++)
            {
                b_drow = dtData.NewRow();
                b_drow["SO_THE"] = row["SO_THE"];
                b_drow["KYLUONG_ID"] = row["KYLUONG_ID"];
                b_drow["MA_LUONG"] = b_dt.Columns[i].ColumnName;
                b_drow["GIATRI"] = row[i];
                b_drow["GHICHU"] = "Dữ liệu import";
                b_drow["NHOMLUONG"] = row["NHOMLUONG"];
                b_drow["PHONG"] = row["PHONG"];
                dtData.Rows.Add(b_drow);
            }
        }

        bang.P_CSO_SO(ref dtData, "GIATRI");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = dtData.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(dtData, "SO_THE");
            object[] a_phong = bang.Fobj_COL_MANG(dtData, "PHONG");
            object[] a_ma_luong = bang.Fobj_COL_MANG(dtData, "MA_LUONG");
            object[] a_giatri = bang.Fobj_COL_MANG(dtData, "GIATRI");
            object[] a_ghichu = bang.Fobj_COL_MANG(dtData, "GHICHU");
            object[] a_nhomluong = bang.Fobj_COL_MANG(dtData, "NHOMLUONG");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_luong", 'S', a_ma_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_giatri", 'N', a_giatri);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhomluong", 'S', a_nhomluong);

            string b_c = "," + chuyen.OBJ_C(b_dr["PHONG"]) + "," + chuyen.OBJ_N(b_dr["KYLUONG_ID"])
                + ",:a_so_the,:a_phong,:a_ma_luong,:a_giatri,:a_ghichu,:a_nhomluong";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_BANGLUONG_IMP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.TL_LUONG_IMP, TEN_BANG.TL_LUONG_IMP);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static object[] Fdt_BANGLUONG_IMP_LKE(string b_phong, string b_nhomluong, double b_kycong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nhomluong, b_kycong, b_tu_n, b_den_n }, "NR", "PNS_BANGLUONG_IMP_LKE");
    }
    #endregion

    #region LƯƠNG XUÂN THÀNH
    public static DataTable Fdt_TL_BLUONG_XUANTHANH_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_XUANTHANH_CT");
    }
    public static object[] Fdt_TL_BLUONG_XUANTHANH_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TL_BLUONG_XUANTHANH_LKE");
    }
    public static void P_TL_BLUONG_XUANTHANH_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_XUANTHANH_XOA");
    }
    public static void P_TL_BLUONG_XUANTHANH_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_lv_thucte = bang.Fobj_COL_MANG(b_dt_ct, "lv_thucte");
            object[] a_phep = bang.Fobj_COL_MANG(b_dt_ct, "phep");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
            object[] a_hso_nn = bang.Fobj_COL_MANG(b_dt_ct, "hso_nn");
            object[] a_hspc_nn = bang.Fobj_COL_MANG(b_dt_ct, "hspc_nn");
            object[] a_luong_nn = bang.Fobj_COL_MANG(b_dt_ct, "luong_nn");
            object[] a_capbac_cv = bang.Fobj_COL_MANG(b_dt_ct, "capbac_cv");
            object[] a_hso_cv = bang.Fobj_COL_MANG(b_dt_ct, "hso_cv");
            object[] a_luong_cv = bang.Fobj_COL_MANG(b_dt_ct, "luong_cv");
            object[] a_doanhthu = bang.Fobj_COL_MANG(b_dt_ct, "doanhthu");
            object[] a_luong_doanhthu = bang.Fobj_COL_MANG(b_dt_ct, "luong_doanhthu");
            object[] a_tong_luong = bang.Fobj_COL_MANG(b_dt_ct, "tong_luong");
            object[] a_pcap = bang.Fobj_COL_MANG(b_dt_ct, "pcap");
            object[] a_anca = bang.Fobj_COL_MANG(b_dt_ct, "anca");
            object[] a_tnhap_chiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhap_chiuthue");
            object[] a_chenhca = bang.Fobj_COL_MANG(b_dt_ct, "chenhca");
            object[] a_phaitra_nld = bang.Fobj_COL_MANG(b_dt_ct, "phaitra_nld");
            object[] a_pcd = bang.Fobj_COL_MANG(b_dt_ct, "pcd");
            object[] a_bhxh = bang.Fobj_COL_MANG(b_dt_ct, "bhxh");
            object[] a_bhyt = bang.Fobj_COL_MANG(b_dt_ct, "bhyt");
            object[] a_bhtn = bang.Fobj_COL_MANG(b_dt_ct, "bhtn");
            object[] a_tnhapchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhapchiuthue");
            object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt_ct, "phuthuoc");
            object[] a_tn_tinhthue = bang.Fobj_COL_MANG(b_dt_ct, "tn_tinhthue");
            object[] a_truthue = bang.Fobj_COL_MANG(b_dt_ct, "truthue");
            object[] a_ktru_kchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "ktru_kchiuthue");
            object[] a_thuc_linh = bang.Fobj_COL_MANG(b_dt_ct, "thuc_linh");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_lv_thucte", 'N', a_lv_thucte);
            dbora.P_THEM_PAR(ref b_lenh, "a_phep", 'N', a_phep);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'U', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso_nn", 'N', a_hso_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_hspc_nn", 'N', a_hspc_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_nn", 'N', a_luong_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac_cv", 'U', a_capbac_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso_cv", 'N', a_hso_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cv", 'N', a_luong_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_doanhthu", 'N', a_doanhthu);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_doanhthu", 'N', a_luong_doanhthu);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_luong", 'N', a_tong_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_pcap", 'N', a_pcap);
            dbora.P_THEM_PAR(ref b_lenh, "a_anca", 'N', a_anca);
            dbora.P_THEM_PAR(ref b_lenh, "a_tnhap_chiuthue", 'N', a_tnhap_chiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_chenhca", 'N', a_chenhca);
            dbora.P_THEM_PAR(ref b_lenh, "a_phaitra_nld", 'N', a_phaitra_nld);
            dbora.P_THEM_PAR(ref b_lenh, "a_pcd", 'N', a_pcd);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'N', a_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhyt", 'N', a_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhtn", 'N', a_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_tnhapchiuthue", 'N', a_tnhapchiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'N', a_phuthuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tn_tinhthue", 'N', a_tn_tinhthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_truthue", 'N', a_truthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktru_kchiuthue", 'N', a_ktru_kchiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuc_linh", 'N', a_thuc_linh);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thang"])
                + ",:a_so_the,:a_ten,:a_lv_thucte,:a_phep,:a_capbac,:a_hso_nn,:a_hspc_nn,:a_luong_nn,:a_capbac_cv,:a_hso_cv"
                + ",:a_luong_cv,:a_doanhthu,:a_luong_doanhthu,:a_tong_luong,:a_pcap,:a_anca,:a_tnhap_chiuthue,:a_chenhca,:a_phaitra_nld"
            + ",:a_pcd,:a_bhxh,:a_bhyt,:a_bhtn,:a_tnhapchiuthue,:a_phuthuoc,:a_tn_tinhthue,:a_truthue,:a_ktru_kchiuthue,:a_thuc_linh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_BLUONG_XUANTHANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static object[] Fdt_TL_BLUONG_XUANTHANH_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_BLUONG_XUANTHANH_MA");
    }
    #endregion

    #region NGHỈ PHÉP
    public static DataTable Fdt_NS_TL_NGHIPHEP_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_CC_CN_CT_LKE_CB3");
        bang.P_THEM_COL(ref b_dt, new string[] { "phepnam", "loai1", "loai2", "loai3", "loai4", "loai5", "loai6", "loai7", "loai8", "loai9", "loai10", "loai11", "loai12", "tongnghi", "phepnamcu", "sophepcon" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }
    public static DataSet Fds_NS_TL_NGHIPHEP_TINH(string b_phong, string b_nam)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_nam }, 2, "PNS_TL_NGHIPHEP_TINH");
    }

    public static object[] Fdt_NS_TL_NGHIPHEP_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_NGHIPHEP_LKE");
    }
    public static object[] Fdt_NS_TL_NGHIPHEP_MA(string b_phong, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam, b_trangkt }, "NNR", "PNS_TL_NGHIPHEP_MA");
    }

    public static DataSet Fds_NS_TL_NGHIPHEP_CT(string b_phong, string b_nam)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_nam }, 2, "PNS_TL_NGHIPHEP_CT");
    }

    public static void P_NS_TL_NGHIPHEP_NH(DataTable b_dt_loai, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            DataRow b_dr_loai = b_dt_loai.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");

            bang.P_CSO_SO(ref b_dt_ct, "phepnam,loai1,loai2,loai3,loai4,loai5,loai6,loai7,loai8,loai9,loai10,loai11,loai12,tongnghi,phepnamcu,sophepcon");

            object[] a_phepnam = bang.Fobj_COL_MANG(b_dt_ct, "phepnam");
            object[] a_loai1 = bang.Fobj_COL_MANG(b_dt_ct, "loai1");
            object[] a_loai2 = bang.Fobj_COL_MANG(b_dt_ct, "loai2");
            object[] a_loai3 = bang.Fobj_COL_MANG(b_dt_ct, "loai3");
            object[] a_loai4 = bang.Fobj_COL_MANG(b_dt_ct, "loai4");
            object[] a_loai5 = bang.Fobj_COL_MANG(b_dt_ct, "loai5");
            object[] a_loai6 = bang.Fobj_COL_MANG(b_dt_ct, "loai6");
            object[] a_loai7 = bang.Fobj_COL_MANG(b_dt_ct, "loai7");
            object[] a_loai8 = bang.Fobj_COL_MANG(b_dt_ct, "loai8");
            object[] a_loai9 = bang.Fobj_COL_MANG(b_dt_ct, "loai9");
            object[] a_loai10 = bang.Fobj_COL_MANG(b_dt_ct, "loai10");
            object[] a_loai11 = bang.Fobj_COL_MANG(b_dt_ct, "loai11");
            object[] a_loai12 = bang.Fobj_COL_MANG(b_dt_ct, "loai12");
            object[] a_tongnghi = bang.Fobj_COL_MANG(b_dt_ct, "tongnghi");
            object[] a_phepnamcu = bang.Fobj_COL_MANG(b_dt_ct, "phepnamcu");
            object[] a_sophepcon = bang.Fobj_COL_MANG(b_dt_ct, "sophepcon");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phepnam", 'N', a_phepnam);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai1", 'N', a_loai1);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai2", 'N', a_loai2);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai3", 'N', a_loai3);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai4", 'N', a_loai4);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai5", 'N', a_loai5);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai6", 'N', a_loai6);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai7", 'N', a_loai7);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai8", 'N', a_loai8);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai9", 'N', a_loai9);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai10", 'N', a_loai10);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai11", 'N', a_loai11);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai12", 'N', a_loai12);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongnghi", 'N', a_tongnghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_phepnamcu", 'N', a_phepnamcu);
            dbora.P_THEM_PAR(ref b_lenh, "a_sophepcon", 'N', a_sophepcon);


            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["nam"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr_loai["loai1"]) + "," + chuyen.OBJ_C(b_dr_loai["loai2"]) + "," + chuyen.OBJ_C(b_dr_loai["loai3"]) + "," + chuyen.OBJ_C(b_dr_loai["loai4"])
                + "," + chuyen.OBJ_C(b_dr_loai["loai5"]) + "," + chuyen.OBJ_C(b_dr_loai["loai6"]) + "," + chuyen.OBJ_C(b_dr_loai["loai7"]) + "," + chuyen.OBJ_C(b_dr_loai["loai8"])
                + "," + chuyen.OBJ_C(b_dr_loai["loai9"]) + "," + chuyen.OBJ_C(b_dr_loai["loai10"]) + "," + chuyen.OBJ_C(b_dr_loai["loai11"]) + "," + chuyen.OBJ_C(b_dr_loai["loai12"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_phepnam,:a_loai1,:a_loai2,:a_loai3,:a_loai4,:a_loai5,:a_loai6,:a_loai7,:a_loai8,:a_loai9,:a_loai10,:a_loai11,:a_loai12,:a_tongnghi,:a_phepnamcu,:a_sophepcon";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_NGHIPHEP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TL_NGHIPHEP_XOA(string b_phong, string b_nam)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_nam }, "PNS_TL_NGHIPHEP_XOA");
    }
    #endregion NGHỈ PHÉP

    #region NGHỈ PHÉP NAGASE
    public static DataTable Fdt_NS_NGHIPHEP_NAGASE_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_CC_CN_CT_LKE_CB3");
        bang.P_THEM_COL(ref b_dt, new string[] { "phepnam", "loai1", "loai2", "loai3", "loai4", "loai5", "loai6", "loai7", "loai8", "loai9", "loai10", "loai11", "loai12", "tongnghi", "phepnamcu", "sophepcon" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }
    public static DataSet Fds_NS_NGHIPHEP_NAGASE_TINH(string b_phong, string b_nam)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_nam }, 2, "PNS_NGHIPHEP_NAGASE_TINH");
    }

    public static object[] Fdt_NS_NGHIPHEP_NAGASE_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_NGHIPHEP_NAGASE_LKE");
    }
    public static object[] Fdt_NS_NGHIPHEP_NAGASE_MA(string b_phong, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_nam, b_trangkt }, "NNR", "PNS_NGHIPHEP_NAGASE_MA");
    }

    public static DataSet Fds_NS_NGHIPHEP_NAGASE_CT(string b_phong, string b_nam)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_nam }, 2, "PNS_NGHIPHEP_NAGASE_CT");
    }

    public static void P_NS_NGHIPHEP_NAGASE_NH(DataTable b_dt_loai, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            DataRow b_dr_loai = b_dt_loai.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phepnam = bang.Fobj_COL_MANG(b_dt_ct, "phepnam");
            object[] a_loai1 = bang.Fobj_COL_MANG(b_dt_ct, "loai1");
            object[] a_loai2 = bang.Fobj_COL_MANG(b_dt_ct, "loai2");
            object[] a_loai3 = bang.Fobj_COL_MANG(b_dt_ct, "loai3");
            object[] a_loai4 = bang.Fobj_COL_MANG(b_dt_ct, "loai4");
            object[] a_loai5 = bang.Fobj_COL_MANG(b_dt_ct, "loai5");
            object[] a_loai6 = bang.Fobj_COL_MANG(b_dt_ct, "loai6");
            object[] a_loai7 = bang.Fobj_COL_MANG(b_dt_ct, "loai7");
            object[] a_loai8 = bang.Fobj_COL_MANG(b_dt_ct, "loai8");
            object[] a_loai9 = bang.Fobj_COL_MANG(b_dt_ct, "loai9");
            object[] a_loai10 = bang.Fobj_COL_MANG(b_dt_ct, "loai10");
            object[] a_loai11 = bang.Fobj_COL_MANG(b_dt_ct, "loai11");
            object[] a_loai12 = bang.Fobj_COL_MANG(b_dt_ct, "loai12");
            object[] a_tongnghi = bang.Fobj_COL_MANG(b_dt_ct, "tongnghi");
            object[] a_phepnamcu = bang.Fobj_COL_MANG(b_dt_ct, "phepnamcu");
            object[] a_sophepcon = bang.Fobj_COL_MANG(b_dt_ct, "sophepcon");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phepnam", 'U', a_phepnam);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai1", 'U', a_loai1);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai2", 'U', a_loai2);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai3", 'U', a_loai3);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai4", 'U', a_loai4);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai5", 'U', a_loai5);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai6", 'U', a_loai6);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai7", 'U', a_loai7);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai8", 'U', a_loai8);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai9", 'U', a_loai9);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai10", 'U', a_loai10);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai11", 'U', a_loai11);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai12", 'U', a_loai12);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongnghi", 'U', a_tongnghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_phepnamcu", 'U', a_phepnamcu);
            dbora.P_THEM_PAR(ref b_lenh, "a_sophepcon", 'U', a_sophepcon);


            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["nam"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr_loai["loai1"]) + "," + chuyen.OBJ_C(b_dr_loai["loai2"]) + "," + chuyen.OBJ_C(b_dr_loai["loai3"]) + "," + chuyen.OBJ_C(b_dr_loai["loai4"])
                + "," + chuyen.OBJ_C(b_dr_loai["loai5"]) + "," + chuyen.OBJ_C(b_dr_loai["loai6"]) + "," + chuyen.OBJ_C(b_dr_loai["loai7"]) + "," + chuyen.OBJ_C(b_dr_loai["loai8"])
                + "," + chuyen.OBJ_C(b_dr_loai["loai9"]) + "," + chuyen.OBJ_C(b_dr_loai["loai10"]) + "," + chuyen.OBJ_C(b_dr_loai["loai11"]) + "," + chuyen.OBJ_C(b_dr_loai["loai12"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_phepnam,:a_loai1,:a_loai2,:a_loai3,:a_loai4,:a_loai5,:a_loai6,:a_loai7,:a_loai8,:a_loai9,:a_loai10,:a_loai11,:a_loai12,:a_tongnghi,:a_phepnamcu,:a_sophepcon";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NGHIPHEP_NAGASE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void P_NS_NGHIPHEP_NAGASE_XOA(string b_phong, string b_nam)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_nam }, "PNS_NGHIPHEP_NAGASE_XOA");
    }
    #endregion NGHỈ PHÉP NAGASE

    #region LƯƠNG NAGASE
    public static DataTable Fdt_TL_BLUONG_NAGASE_VN_TINH(string b_phong, string b_thang, string b_ngaylam)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang), chuyen.OBJ_N(b_ngaylam) }, "pns_luong_nagase_vn_tinh");

    }
    public static DataTable Fdt_TL_BLUONG_NAGASE_NN_TINH(string b_phong, string b_thang, string b_ngaylam, string b_tygia)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang), chuyen.OBJ_N(b_ngaylam), chuyen.OBJ_N(b_tygia) }, "pns_luong_nagase_nn_tinh");

    }

    public static DataTable Fdt_TL_BLUONG_NAGASE_VN_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_NAGASE_VN_CT");
    }
    public static object[] Fdt_TL_BLUONG_NAGASE_VN_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TL_BLUONG_NAGASE_VN_LKE");
    }
    public static void P_TL_BLUONG_NAGASE_VN_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_NAGASE_VN_XOA");
    }
    public static void P_TL_BLUONG_NAGASE_VN_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CSO_SO(ref b_dt_ct, "DAYS,NORMALDAY,SALARYNETUSD,RATE,SALARYNETVND,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,ALLOWANCEVND,UNPAIDVND,INSURANCEFEE,TOTALPAY,TOTALNET,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,FAMILYSHUI,AFTERDECDUTION2,GROSSFORPIT2,PAYPIT2,MNETSALARY,GROSSUPSALARY,SALARYFORSOCIAL,CONTRIBUTION,SALARYFORUNEMPLOYMENT,UNEPLOYMENTINSURANCE,TOTALSHUI,GROSSSALARYVND");
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_days = bang.Fobj_COL_MANG(b_dt_ct, "days");
            object[] a_normalday = bang.Fobj_COL_MANG(b_dt_ct, "normalday");
            object[] a_sec = bang.Fobj_COL_MANG(b_dt_ct, "sec");
            object[] a_salarynetusd = bang.Fobj_COL_MANG(b_dt_ct, "salarynetusd");
            object[] a_rate = bang.Fobj_COL_MANG(b_dt_ct, "rate");
            object[] a_salarynetvnd = bang.Fobj_COL_MANG(b_dt_ct, "salarynetvnd");
            object[] a_ot_noweekday = bang.Fobj_COL_MANG(b_dt_ct, "ot_noweekday");
            object[] a_ot_weekday = bang.Fobj_COL_MANG(b_dt_ct, "ot_weekday");
            object[] a_ot_holiday = bang.Fobj_COL_MANG(b_dt_ct, "ot_holiday");
            object[] a_nt_noweekday = bang.Fobj_COL_MANG(b_dt_ct, "nt_noweekday");
            object[] a_nt_weekday = bang.Fobj_COL_MANG(b_dt_ct, "nt_weekday");
            object[] a_nt_holiday = bang.Fobj_COL_MANG(b_dt_ct, "nt_holiday");
            object[] a_salary_ot = bang.Fobj_COL_MANG(b_dt_ct, "salary_ot");
            object[] a_allowanceusd = bang.Fobj_COL_MANG(b_dt_ct, "allowanceusd");
            object[] a_allowancevnd = bang.Fobj_COL_MANG(b_dt_ct, "allowancevnd");
            object[] a_unpaidvnd = bang.Fobj_COL_MANG(b_dt_ct, "unpaidvnd");
            object[] a_insurancefee = bang.Fobj_COL_MANG(b_dt_ct, "insurancefee");
            object[] a_totalpay = bang.Fobj_COL_MANG(b_dt_ct, "totalpay");
            object[] a_totalnet = bang.Fobj_COL_MANG(b_dt_ct, "totalnet");
            object[] a_pitcal = bang.Fobj_COL_MANG(b_dt_ct, "pitcal");
            object[] a_afterdecdution = bang.Fobj_COL_MANG(b_dt_ct, "afterdecdution");
            object[] a_grossforpit = bang.Fobj_COL_MANG(b_dt_ct, "grossforpit");
            object[] a_paypit = bang.Fobj_COL_MANG(b_dt_ct, "paypit");
            object[] a_taxable = bang.Fobj_COL_MANG(b_dt_ct, "taxable");
            object[] a_familyshui = bang.Fobj_COL_MANG(b_dt_ct, "familyshui");
            object[] a_afterdecdution2 = bang.Fobj_COL_MANG(b_dt_ct, "afterdecdution2");
            object[] a_grossforpit2 = bang.Fobj_COL_MANG(b_dt_ct, "grossforpit2");
            object[] a_paypit2 = bang.Fobj_COL_MANG(b_dt_ct, "paypit2");
            object[] a_mnetsalary = bang.Fobj_COL_MANG(b_dt_ct, "mnetsalary");
            object[] a_grossupsalary = bang.Fobj_COL_MANG(b_dt_ct, "grossupsalary");
            object[] a_salaryforsocial = bang.Fobj_COL_MANG(b_dt_ct, "salaryforsocial");
            object[] a_contribution = bang.Fobj_COL_MANG(b_dt_ct, "contribution");
            object[] a_salaryforunemployment = bang.Fobj_COL_MANG(b_dt_ct, "salaryforunemployment");
            object[] a_uneploymentinsurance = bang.Fobj_COL_MANG(b_dt_ct, "uneploymentinsurance");
            object[] a_totalshui = bang.Fobj_COL_MANG(b_dt_ct, "totalshui");
            object[] a_grosssalaryvnd = bang.Fobj_COL_MANG(b_dt_ct, "grosssalaryvnd");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the ", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten ", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_days ", 'U', a_days);
            dbora.P_THEM_PAR(ref b_lenh, "a_normalday ", 'U', a_normalday);
            dbora.P_THEM_PAR(ref b_lenh, "a_sec ", 'U', a_sec);
            dbora.P_THEM_PAR(ref b_lenh, "a_salarynetusd ", 'U', a_salarynetusd);
            dbora.P_THEM_PAR(ref b_lenh, "a_rate ", 'U', a_rate);
            dbora.P_THEM_PAR(ref b_lenh, "a_salarynetvnd ", 'U', a_salarynetvnd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_noweekday ", 'U', a_ot_noweekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_weekday ", 'U', a_ot_weekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_holiday ", 'U', a_ot_holiday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_noweekday ", 'U', a_nt_noweekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_weekday ", 'U', a_nt_weekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_holiday ", 'U', a_nt_holiday);
            dbora.P_THEM_PAR(ref b_lenh, "a_salary_ot ", 'U', a_salary_ot);
            dbora.P_THEM_PAR(ref b_lenh, "a_allowanceusd ", 'U', a_allowanceusd);
            dbora.P_THEM_PAR(ref b_lenh, "a_allowancevnd ", 'U', a_allowancevnd);
            dbora.P_THEM_PAR(ref b_lenh, "a_unpaidvnd ", 'U', a_unpaidvnd);
            dbora.P_THEM_PAR(ref b_lenh, "a_insurancefee ", 'U', a_insurancefee);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalpay ", 'U', a_totalpay);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalnet ", 'U', a_totalnet);
            dbora.P_THEM_PAR(ref b_lenh, "a_pitcal ", 'U', a_pitcal);
            dbora.P_THEM_PAR(ref b_lenh, "a_afterdecdution ", 'U', a_afterdecdution);
            dbora.P_THEM_PAR(ref b_lenh, "a_grossforpit ", 'U', a_grossforpit);
            dbora.P_THEM_PAR(ref b_lenh, "a_paypit ", 'U', a_paypit);
            dbora.P_THEM_PAR(ref b_lenh, "a_taxable ", 'U', a_taxable);
            dbora.P_THEM_PAR(ref b_lenh, "a_familyshui ", 'U', a_familyshui);
            dbora.P_THEM_PAR(ref b_lenh, "a_afterdecdution2 ", 'U', a_afterdecdution2);
            dbora.P_THEM_PAR(ref b_lenh, "a_grossforpit2 ", 'U', a_grossforpit2);
            dbora.P_THEM_PAR(ref b_lenh, "a_paypit2 ", 'U', a_paypit2);
            dbora.P_THEM_PAR(ref b_lenh, "a_mnetsalary ", 'U', a_mnetsalary);
            dbora.P_THEM_PAR(ref b_lenh, "a_grossupsalary ", 'U', a_grossupsalary);
            dbora.P_THEM_PAR(ref b_lenh, "a_salaryforsocial ", 'U', a_salaryforsocial);
            dbora.P_THEM_PAR(ref b_lenh, "a_contribution ", 'U', a_contribution);
            dbora.P_THEM_PAR(ref b_lenh, "a_salaryforunemployment ", 'U', a_salaryforunemployment);
            dbora.P_THEM_PAR(ref b_lenh, "a_uneploymentinsurance ", 'U', a_uneploymentinsurance);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalshui ", 'U', a_totalshui);
            dbora.P_THEM_PAR(ref b_lenh, "a_grosssalaryvnd ", 'U', a_grosssalaryvnd);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong_cp"]) + "," + chuyen.OBJ_S(b_dr["thangcc"])
                + ",:a_so_the,:a_ten,:a_days,:a_normalday,:a_sec,:a_salarynetusd,:a_rate,:a_salarynetvnd,:a_ot_noweekday,:a_ot_weekday,:a_ot_holiday,:a_nt_noweekday,:a_nt_weekday"
                + ",:a_nt_holiday,:a_salary_ot,:a_allowanceusd,:a_allowancevnd,:a_unpaidvnd,:a_insurancefee,:a_totalpay,:a_totalnet,:a_pitcal"
                + ",:a_afterdecdution,:a_grossforpit,:a_paypit,:a_taxable,:a_familyshui,:a_afterdecdution2,:a_grossforpit2,:a_paypit2,:a_mnetsalary"
                + ",:a_grossupsalary,:a_salaryforsocial,:a_contribution,:a_salaryforunemployment,:a_uneploymentinsurance,:a_totalshui,:a_grosssalaryvnd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_BLUONG_NAGASE_VN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static object[] Fdt_TL_BLUONG_NAGASE_VN_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_BLUONG_NAGASE_VN_MA");
    }

    // NGUOI NUOC NGOAI

    public static DataTable Fdt_TL_BLUONG_NAGASE_NN_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_NAGASE_NN_CT");
    }
    public static object[] Fdt_TL_BLUONG_NAGASE_NN_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TL_BLUONG_NAGASE_NN_LKE");
    }
    public static void P_TL_BLUONG_NAGASE_NN_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_BLUONG_NAGASE_NN_XOA");
    }
    public static void P_TL_BLUONG_NAGASE_NN_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CSO_SO(ref b_dt_ct, "DAYS,NORMALDAY,SALARYNETUSD,RATE,OT_NOWEEKDAY,OT_WEEKDAY,OT_HOLIDAY,NT_NOWEEKDAY,NT_WEEKDAY,NT_HOLIDAY,SALARY_OT,ALLOWANCEUSD,UNPAIDUSD,INSURANCEFEE,TOTALPAY,TOTALNETUSD,TOTALNETVND,PITCAL,AFTERDECDUTION,GROSSFORPIT,PAYPIT,TAXABLE,GROSSSALARYUSD");
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_days = bang.Fobj_COL_MANG(b_dt_ct, "days");
            object[] a_normalday = bang.Fobj_COL_MANG(b_dt_ct, "normalday");
            object[] a_sec = bang.Fobj_COL_MANG(b_dt_ct, "sec");
            object[] a_salarynetusd = bang.Fobj_COL_MANG(b_dt_ct, "salarynetusd");
            object[] a_rate = bang.Fobj_COL_MANG(b_dt_ct, "rate");
            object[] a_ot_noweekday = bang.Fobj_COL_MANG(b_dt_ct, "ot_noweekday");
            object[] a_ot_weekday = bang.Fobj_COL_MANG(b_dt_ct, "ot_weekday");
            object[] a_ot_holiday = bang.Fobj_COL_MANG(b_dt_ct, "ot_holiday");
            object[] a_nt_noweekday = bang.Fobj_COL_MANG(b_dt_ct, "nt_noweekday");
            object[] a_nt_weekday = bang.Fobj_COL_MANG(b_dt_ct, "nt_weekday");
            object[] a_nt_holiday = bang.Fobj_COL_MANG(b_dt_ct, "nt_holiday");
            object[] a_salary_ot = bang.Fobj_COL_MANG(b_dt_ct, "salary_ot");
            object[] a_allowanceusd = bang.Fobj_COL_MANG(b_dt_ct, "allowanceusd");
            object[] a_unpaidvnd = bang.Fobj_COL_MANG(b_dt_ct, "unpaidusd");
            object[] a_insurancefee = bang.Fobj_COL_MANG(b_dt_ct, "insurancefee");
            object[] a_totalpay = bang.Fobj_COL_MANG(b_dt_ct, "totalpay");
            object[] a_totalnetusd = bang.Fobj_COL_MANG(b_dt_ct, "totalnetusd");
            object[] a_totalnetvnd = bang.Fobj_COL_MANG(b_dt_ct, "totalnetvnd");
            object[] a_pitcal = bang.Fobj_COL_MANG(b_dt_ct, "pitcal");
            object[] a_afterdecdution = bang.Fobj_COL_MANG(b_dt_ct, "afterdecdution");
            object[] a_grossforpit = bang.Fobj_COL_MANG(b_dt_ct, "grossforpit");
            object[] a_paypit = bang.Fobj_COL_MANG(b_dt_ct, "paypit");
            object[] a_taxable = bang.Fobj_COL_MANG(b_dt_ct, "taxable");
            object[] a_grosssalaryusd = bang.Fobj_COL_MANG(b_dt_ct, "grosssalaryusd");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the ", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten ", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_days ", 'U', a_days);
            dbora.P_THEM_PAR(ref b_lenh, "a_normalday ", 'U', a_normalday);
            dbora.P_THEM_PAR(ref b_lenh, "a_sec ", 'U', a_sec);
            dbora.P_THEM_PAR(ref b_lenh, "a_salarynetusd ", 'U', a_salarynetusd);
            dbora.P_THEM_PAR(ref b_lenh, "a_rate ", 'U', a_rate);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_noweekday ", 'U', a_ot_noweekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_weekday ", 'U', a_ot_weekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_holiday ", 'U', a_ot_holiday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_noweekday ", 'U', a_nt_noweekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_weekday ", 'U', a_nt_weekday);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_holiday ", 'U', a_nt_holiday);
            dbora.P_THEM_PAR(ref b_lenh, "a_salary_ot ", 'U', a_salary_ot);
            dbora.P_THEM_PAR(ref b_lenh, "a_allowanceusd ", 'U', a_allowanceusd);
            dbora.P_THEM_PAR(ref b_lenh, "a_unpaidvnd ", 'U', a_unpaidvnd);
            dbora.P_THEM_PAR(ref b_lenh, "a_insurancefee ", 'U', a_insurancefee);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalpay ", 'U', a_totalpay);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalnetusd", 'U', a_totalnetusd);
            dbora.P_THEM_PAR(ref b_lenh, "a_totalnetvnd", 'U', a_totalnetvnd);
            dbora.P_THEM_PAR(ref b_lenh, "a_pitcal ", 'U', a_pitcal);
            dbora.P_THEM_PAR(ref b_lenh, "a_afterdecdution ", 'U', a_afterdecdution);
            dbora.P_THEM_PAR(ref b_lenh, "a_grossforpit ", 'U', a_grossforpit);
            dbora.P_THEM_PAR(ref b_lenh, "a_paypit ", 'U', a_paypit);
            dbora.P_THEM_PAR(ref b_lenh, "a_taxable ", 'U', a_taxable);
            dbora.P_THEM_PAR(ref b_lenh, "a_grosssalaryusd ", 'U', a_grosssalaryusd);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong_cp"]) + "," + chuyen.OBJ_S(b_dr["thangcc"])
                + ",:a_so_the,:a_ten,:a_days,:a_normalday,:a_sec,:a_salarynetusd,:a_rate,:a_ot_noweekday,:a_ot_weekday,:a_ot_holiday,:a_nt_noweekday,:a_nt_weekday"
                + ",:a_nt_holiday,:a_salary_ot,:a_allowanceusd,:a_unpaidusd,:a_insurancefee,:a_totalpay,:a_totalnetusd,:a_totalnetvnd,:a_pitcal"
                + ",:a_afterdecdution,:a_grossforpit,:a_paypit,:a_taxable,:a_grosssalaryusd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_BLUONG_NAGASE_NN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static object[] Fdt_TL_BLUONG_NAGASE_NN_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_BLUONG_NAGASE_NN_MA");
    }

    #endregion LUONG NAGASE

    #region CÁ NHÂN NAGASE
    public static DataTable Fdt_TL_BLUONG_NAGASE_CN_CT(string b_so_the, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.OBJ_N(b_thang) }, "pns_tl_bluong_nagase_cn_ct");
    }
    public static object[] Fdt_TL_BLUONG_CN_LKE(string b_so_the, double b_kyluongId, string b_dtuong)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_kyluongId, b_dtuong }, "R", "pns_tl_bluong_cn_lke");
    }
    public static DataTable Fdt_TTLH_BLUONG_CN_LKE(string b_kyluong)
    {
        return dbora.Fdt_LKE_S(b_kyluong, "PNS_TTTL_BLUONG_CN_LKE");
    }
    #endregion

    #region THIẾT LẬP CÔNG THỨC LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_TL_CT_LUONG_LKE(string nluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { nluong, b_tu_n, b_den_n }, "NR", "PTL_TL_CT_LUONG_CONGTHUC");
    }
    public static object[] Fdt_Fs_TL_CT_LUONG_DV_LKE(string b_nluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nluong, b_tu_n, b_den_n }, "NR", "PTL_TL_CT_LUONG_DAUVAO");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_TL_CT_LUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_TL_CT_LUONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_TL_CT_LUONG_NH(string b_mact, string b_ct, int b_tt)
    {
        dbora.P_GOIHAM(new object[] { b_mact, b_ct, b_tt }, "PFs_TL_CT_LUONG_NH");
    }
    public static void P_Fs_TL_CT_LUONG_KT(string b_ct)
    {
        dbora.P_GOIHAM(new object[] { b_ct }, "PTL_TL_CT_LUONG_KT");
    }

    public static DataTable Fdt_TL_CT_LUONG_CT(string b_so_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("macl", typeof(int));
        table.Columns.Add("tencl", typeof(string));
        table.Columns.Add("STT", typeof(string));
        table.Columns.Add("nsd", typeof(string));
        table.Columns.Add("SO_ID", typeof(string));
        table.Rows.Add("COT1", "Tổng công làm việc thực tế", "1", b_se.nsd, 10000);
        table.Rows.Add("COT2", "Thuế TNCN", "2", b_se.nsd, 10001);
        table.Rows.Add("COT3", "Thu nhập chịu thuế", "3", b_se.nsd, 10002);
        table.Rows.Add("COT4", "Tổng lương theo ngày", "4", b_se.nsd, 10003);
        table.Rows.Add("COT5", "Thực lĩnh", "5", b_se.nsd, 10004);
        return table;
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_TL_CT_LUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_TL_CT_LUONG_XOA");
    }
    #endregion THIẾT LẬP CÔNG THỨC LƯƠNG

    #region THIẾT LẬP CÔNG THỨC CÔNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_TL_CC_CONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTL_TL_CC_CONG_CONGTHUC");
    }
    public static object[] Fdt_Fs_TL_CC_CONG_DV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTL_TL_CC_CONG_DAUVAO");
    }

    ///<summary>liet ke sau kiem tra </summary> 
    public static object[] Fdt_Fs_TL_CC_CONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_TL_CC_CONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_TL_CC_CONG_NH(string b_mact, string b_ct, int b_tt)
    {
        dbora.P_GOIHAM(new object[] { b_mact, b_ct, b_tt }, "PFs_TL_CC_CONG_NH");
    }
    public static void P_Fs_TL_CC_CONG_KT(string b_ct)
    {
        dbora.P_GOIHAM(new object[] { b_ct }, "PTL_TL_CC_CONG_KT");
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_TL_CC_CONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_TL_CC_CONG_XOA");
    }
    #endregion THIẾT LẬP CÔNG THỨC LƯƠNG

    #region IMPORT ĐÁNH GIÁ 360
    //lấy thông tin cán bộ theo kỳ đánh giá
    public static DataTable Fdt_BC_DG360_TTCB(string b_ky_dg)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ky_dg }, "PNS_BC_DG360_TTCB");
    }
    //lấy thông tin cán bộ theo đối tượng
    public static DataTable Fdt_BC_DG360_TTCB_DTUONG(string b_ky_dg, string b_dtuong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ky_dg, b_dtuong }, "PNS_BC_DG360_TTCB_DTUONG");
    }
    #endregion

    #region IMPORT EMS
    public static DataTable Fdt_EMS_IMP_DATA(string b_kyluong)
    {
        return dbora.Fdt_LKE_S(b_kyluong, "pns_tl_ems_imp_data");
    }
    public static string PNS_TL_EMS_IMP(string b_nam, string b_kyluongId, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            bang.P_CSO_SO(ref b_dt, "p_gd_tt,hqcv,ds,ttn_t_hqcv,t_pxmgxlv,hh_mg,hh_cs_gt_ht,ck_gt_hqcv,PH_5,DM_P_NSU,PHI_KHAC,T_PHI_HH,P_F1,P_F2,P_F3,P_FN,P_CTV,P_HH_MG_KHAC,HH_QLY,HH_MG_KHAC,HH_DNO,P_QLY,HH_MG_KHAC2");

            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_p_gd_tt = bang.Fobj_COL_MANG(b_dt, "p_gd_tt");
            object[] a_hqcv = bang.Fobj_COL_MANG(b_dt, "hqcv");
            object[] a_ds = bang.Fobj_COL_MANG(b_dt, "ds");
            object[] a_ttn_t_hqcv = bang.Fobj_COL_MANG(b_dt, "ttn_t_hqcv");
            object[] a_t_pxmgxlv = bang.Fobj_COL_MANG(b_dt, "t_pxmgxlv");
            object[] a_hh_mg = bang.Fobj_COL_MANG(b_dt, "hh_mg");
            object[] a_hh_cs_gt_ht = bang.Fobj_COL_MANG(b_dt, "hh_cs_gt_ht");
            object[] a_ck_gt_hqcv = bang.Fobj_COL_MANG(b_dt, "ck_gt_hqcv");
            object[] a_PH_5 = bang.Fobj_COL_MANG(b_dt, "PH_5");
            object[] a_DM_P_NSU = bang.Fobj_COL_MANG(b_dt, "DM_P_NSU");
            object[] a_PHI_KHAC = bang.Fobj_COL_MANG(b_dt, "PHI_KHAC");
            object[] a_T_PHI_HH = bang.Fobj_COL_MANG(b_dt, "T_PHI_HH");
            object[] a_P_F1 = bang.Fobj_COL_MANG(b_dt, "P_F1");
            object[] a_P_F2 = bang.Fobj_COL_MANG(b_dt, "P_F2");
            object[] a_P_F3 = bang.Fobj_COL_MANG(b_dt, "P_F3");
            object[] a_P_Fn = bang.Fobj_COL_MANG(b_dt, "P_Fn");
            object[] a_P_CTV = bang.Fobj_COL_MANG(b_dt, "P_CTV");
            object[] a_P_HH_MG_KHAC = bang.Fobj_COL_MANG(b_dt, "P_HH_MG_KHAC");
            object[] a_HH_QLY = bang.Fobj_COL_MANG(b_dt, "HH_QLY");
            object[] a_HH_MG_KHAC = bang.Fobj_COL_MANG(b_dt, "HH_MG_KHAC");
            object[] a_HH_DNO = bang.Fobj_COL_MANG(b_dt, "HH_DNO");
            object[] a_P_QLY = bang.Fobj_COL_MANG(b_dt, "P_QLY");
            object[] a_HH_MG_KHAC2 = bang.Fobj_COL_MANG(b_dt, "HH_MG_KHAC2");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_p_gd_tt", 'N', a_p_gd_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_hqcv", 'N', a_hqcv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ds", 'N', a_ds);
            dbora.P_THEM_PAR(ref b_lenh, "a_ttn_t_hqcv", 'N', a_ttn_t_hqcv);
            dbora.P_THEM_PAR(ref b_lenh, "a_t_pxmgxlv", 'N', a_t_pxmgxlv);
            dbora.P_THEM_PAR(ref b_lenh, "a_hh_mg", 'N', a_hh_mg);
            dbora.P_THEM_PAR(ref b_lenh, "a_hh_cs_gt_ht", 'N', a_hh_cs_gt_ht);
            dbora.P_THEM_PAR(ref b_lenh, "a_ck_gt_hqcv", 'N', a_ck_gt_hqcv);
            dbora.P_THEM_PAR(ref b_lenh, "a_PH_5", 'N', a_PH_5);
            dbora.P_THEM_PAR(ref b_lenh, "a_DM_P_NSU", 'N', a_DM_P_NSU);
            dbora.P_THEM_PAR(ref b_lenh, "a_PHI_KHAC", 'N', a_PHI_KHAC);
            dbora.P_THEM_PAR(ref b_lenh, "a_T_PHI_HH", 'N', a_T_PHI_HH);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_F1", 'N', a_P_F1);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_F2", 'N', a_P_F2);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_F3", 'N', a_P_F3);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_Fn", 'N', a_P_Fn);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_CTV", 'N', a_P_CTV);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_HH_MG_KHAC", 'N', a_P_HH_MG_KHAC);
            dbora.P_THEM_PAR(ref b_lenh, "a_HH_QLY", 'N', a_HH_QLY);
            dbora.P_THEM_PAR(ref b_lenh, "a_HH_MG_KHAC", 'N', a_HH_MG_KHAC);
            dbora.P_THEM_PAR(ref b_lenh, "a_HH_DNO", 'N', a_HH_DNO);
            dbora.P_THEM_PAR(ref b_lenh, "a_P_QLY", 'N', a_P_QLY);
            dbora.P_THEM_PAR(ref b_lenh, "a_HH_MG_KHAC2", 'N', a_HH_MG_KHAC2);

            string b_c = "," + chuyen.OBJ_S(b_nam)
                       + "," + chuyen.OBJ_S(b_kyluongId)
                       + ",:a_so_the,:a_p_gd_tt,:a_hqcv,:a_ds,:a_ttn_t_hqcv,:a_t_pxmgxlv,:a_hh_mg,:a_hh_cs_gt_ht,:a_ck_gt_hqcv,:a_PH_5,:a_DM_P_NSU,:a_PHI_KHAC,:a_T_PHI_HH,:a_P_F1,:a_P_F2,:a_P_F3,:a_P_Fn,:a_P_CTV,:a_P_HH_MG_KHAC,:a_HH_QLY,:a_HH_MG_KHAC,:a_HH_DNO,:a_P_QLY,:a_HH_MG_KHAC2";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_EMS_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Fdt_TL_EMS_IMP_LKE(string b_phong, string b_kycong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kycong, b_tu_n, b_den_n }, "NR", "pns_tl_ems_imp_lke");
    }
    #endregion

    #region IMPORT DANH SÁCH THIẾU PHIẾU LỆNH
    public static object[] Fdt_NS_DSACH_THIEU_PLENH_LKE(string b_nam, string b_ky_luong_id, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_ky_luong_id), b_tu_n, b_den_n }, "NR", "PNS_DSACH_THIEU_PLENH_LKE");
    }
    public static DataTable Fdt_NS_DSACH_THIEU_PLENH_CT(string b_nam, string b_kyluong_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_kyluong_id }, "PNS_DSACH_THIEU_PLENH_CT");
    }
    public static string PNS_DSACH_THIEU_PLENH_IMP(string b_nam, string b_kyluongId, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_so_plenh_thieu = bang.Fobj_COL_MANG(b_dt, "so_plenh_thieu");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_plenh_thieu", 'N', a_so_plenh_thieu);

            string b_c = "," + chuyen.OBJ_S(b_nam) + "," + chuyen.OBJ_S(b_kyluongId) + ",:a_so_the,:a_so_plenh_thieu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DSACH_THIEU_PLENH_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT DANH SÁCH THIẾU PHIẾU LỆNH

    #region DANH SÁCH THIẾU GIẤY TỜ BẮT BUỘC 
    public static object[] FS_NS_DSACH_GIAYTO_BBUOC_LKE(string b_sothe, string b_hoten, string b_kyluong, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, "N'" + b_hoten, b_kyluong, b_phong, b_tu, b_den }, "NR", "PNS_DSACH_GIAYTO_BBUOC_LKE");
    }

    public static void FS_NS_DSACH_GIAYTO_BBUOC_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_sothe = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_traluong = bang.Fobj_COL_MANG(b_dt, "is_traluong");
            object[] a_maky = bang.Fobj_COL_MANG(b_dt, "ky");

            dbora.P_THEM_PAR(ref b_lenh, "a_sothe", 'S', a_sothe);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_traluong", 'S', a_traluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_maky", 'S', a_maky);

            string b_c = ",:a_sothe,:a_cdanh,:a_phong,:a_traluong,:a_maky";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DSACH_GIAYTO_BBUOC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion
}