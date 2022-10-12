using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_ktkl
{
    #region MÃ NƠI KTKL
    public static object[] Fdt_NS_MA_NOI_KTKL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NOI_KTKL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NOI_KTKL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NOI_KTKL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NOI_KTKL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["dchi"] }, "PNS_MA_NOI_KTKL_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_NOI_KTKL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NOI_KTKL_XOA");
    }
    #endregion MÃ NƠI KTKL

    #region MÃ CẤP KTKL
    public static DataTable Fdt_MA_CAP_KTKL_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_CAP_KTKL_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_MA_CAP_KTKL_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { b_dr_ct["ma"], b_dr_ct["ten"], chuyen.OBJ_S(b_dr_ct["ma_ct"], " ") };
        dbora.P_GOIHAM(a_obj, "PNS_MA_CAP_KTKL_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_MA_CAP_KTKL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CAP_KTKL_XOA");
    }
    #endregion MÃ CẤP KTKL

    #region KHEN THƯỞNG
    public static object[] PNS_KTKL_KT_LKE_CB(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_KTKL_KT_LKE_CB");
    }
    public static object[] PNS_KTKL_KT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_KTKL_KT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_KTKL_KT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_KTKL_KT_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KTKL_KT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_KTKL_KT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_KTKL_KT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["soqd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayqd"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["mucthuong"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + ","
                + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_C(b_dr["noi_ktkl"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_KT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable PNS_KTKL_KT_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_KTKL_KT_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_KTKL_KT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_KTKL_KT_XOA");
    }
    #endregion KHEN THƯỞNG

    #region KHEN THƯỞNG CHUNG
    public static object[] PNS_KTKL_KTC_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_KTKL_KTC_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_KTKL_KTC_MA(string b_soqd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_soqd, b_trangkt }, "NNR", "PNS_KTKL_KTC_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KTKL_KTC_CT(string b_soqd)
    {
        return dbora.Fdt_LKE_S(b_soqd, "PNS_KTKL_KTC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_KTKL_KTC_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt_ct, "lydo");
            object[] a_mucthuong = bang.Fobj_COL_MANG(b_dt_ct, "mucthuong");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucthuong", 'N', a_mucthuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = "," + chuyen.OBJ_C(b_dr["soqd"]) + "," + chuyen.OBJ_S(b_dr["ngayqd"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + ","
                + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_C(b_dr["noi_ktkl"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_phong,:a_lydo,:a_mucthuong,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_KTC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_KTKL_KTC_XOA(string b_soqd, string b_ngayqd)
    {
        dbora.P_GOIHAM(new object[] { b_soqd, chuyen.CNG_SO(b_ngayqd) }, "PNS_KTKL_KTC_XOA");
    }
    #endregion KHEN THƯỞNG CHUNG

    #region KỶ LUẬT CHUNG
    public static object[] PNS_KTKL_KLC_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_KTKL_KLC_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_KTKL_KLC_MA(string b_soqd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_soqd, b_trangkt }, "NNR", "PNS_KTKL_KLC_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KTKL_KLC_CT(string b_soqd)
    {
        return dbora.Fdt_LKE_S(b_soqd, "PNS_KTKL_KLC_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_KTKL_KLC_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_mucphat = bang.Fobj_COL_MANG(b_dt_ct, "mucphat");
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt_ct, "lydo");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucphat", 'N', a_mucphat);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = "," + chuyen.OBJ_C(b_dr["soqd"]) + "," + chuyen.OBJ_S(b_dr["ngayqd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + ","
                + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_C(b_dr["noi_ktkl"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_phong,:a_mucphat,:a_lydo,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_KLC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_KTKL_KLC_XOA(string b_soqd, string b_ngayqd)
    {
        dbora.P_GOIHAM(new object[] { b_soqd, chuyen.CNG_SO(b_ngayqd) }, "PNS_KTKL_KLC_XOA");
    }
    #endregion KỶ LUẬT CHUNG

    #region KỶ LUẬT
    public static object[] PNS_KTKL_KL_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_KTKL_KL_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_KTKL_KL_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_KTKL_KL_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KTKL_KL_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_KTKL_KL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_KTKL_KL_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["soqd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayqd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + ","
                + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_S(b_dr["mucphat"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + ","
                + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_C(b_dr["noi_ktkl"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_KL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable PNS_KTKL_KL_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_KTKL_KL_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_KTKL_KL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_KTKL_KL_XOA");
    }
    #endregion KỶ LUẬT

    #region QUẢN LÝ KHEN THƯỞNG
    /// <summary>Liệt kê</summary>
    public static object[] Fdt_NS_KTKL_QLKT_LKE(DataTable b_dt_tk,string b_phong, double b_tu_n, double b_den_n)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_dr["dtkt_tk"], chuyen.OBJ_N(b_dr["tungay_tk"]), chuyen.OBJ_N(b_dr["denngay_tk"]),
            b_dr["trangthai_tk"], b_phong,b_dr["so_the_tk"],b_dr["ten_tk"],b_dr["nghi_viec_tk"],
            b_tu_n, b_den_n }, "NR", "PNS_KTKL_QLKT_LKE");
    }
    /// <summary>Liệt kê</summary>
    public static DataTable Fdt_NS_KTKL_QLKT_EXCEL(string b_dtkl, string b_tungay, string b_denngay, string b_tthai,
        string b_phong, string b_sothe, string b_ten, string b_nv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dtkl,chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tthai, b_phong,
            b_sothe, b_ten, b_nv}, "PNS_KTKL_QLKT_EXCEL");
    }
    /// <summary>Liệt kê ra excel</summary>
    public static object[] Fdt_NS_KTKL_QLKT_LKE_ALL(string b_sothe, string b_ten, string phong, string b_nv)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, b_ten, phong, b_nv }, "R", "PNS_KTKL_QLKT_LKE_ALL");
    }
    ///<summary> Kiểm tra mã </summary>
    public static object[] Fdt_NS_KTKL_QLKT_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_KTKL_QLKT_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataSet Fdt_NS_KTKL_QLKT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_KTKL_QLKT_CT");
    }
    /// <summary>Liệt kê chi tiết(Dùng cho chức năng in)</summary>
    public static DataSet Fdt_NS_KTKL_QLKT_IN(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_KTKL_QLKT_IN");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_KTKL_QLKT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_so_thenv = bang.Fobj_COL_MANG(b_dt_ct, "so_thenv");
            object[] a_cdanhnv = bang.Fobj_COL_MANG(b_dt_ct, "cdanhnv");
            object[] a_dvinv = bang.Fobj_COL_MANG(b_dt_ct, "dvinv");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_thenv", 'S', a_so_thenv);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanhnv", 'S', a_cdanhnv);
            dbora.P_THEM_PAR(ref b_lenh, "a_dvinv", 'S', a_dvinv);

            string b_c = ",:so_id" + "," + chuyen.OBJ_N(b_dr["ngay_hl"]) + "," + chuyen.OBJ_N(b_dr["ngay_hhl"])
                + "," + chuyen.OBJ_C(b_dr["soqd"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"])
                + "," + chuyen.OBJ_N(b_dr["ngayky"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["dtuong"])
                + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_N(b_dr["sotien"])
                + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["cvluong"]) + "," + chuyen.OBJ_N(b_dr["nam"])
                + "," + chuyen.OBJ_C(b_dr["kyluong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["cdanh"])
                + "," + chuyen.OBJ_C(b_dr["dvi"]) + ",:a_so_thenv,:a_cdanhnv,:a_dvinv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_QLKT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            //catch (Exception ex) { form.P_LOI(ex.Message ); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_KTKL_QLKT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_KTKL_QLKT_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_QD(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "pns_thongtin_qd");
    }
    /// <summary>Trả dữ liệu</summary>
    public static object[] Fdt_NS_KTKL_QLKT_TRA(string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the }, "R", "PNS_KTKL_QLKT_TRA");
    }

    public static object[] Faobj_NS_HTKT_TRA(string b_ma)
    {
        return dbora.Faobj_LKE(new object[] { b_ma }, "S", "PNS_MA_HTKT_TRA");
    }
    #endregion QUẢN LÝ KHEN THƯỞNG

    #region [QUẢN LÝ KỶ LUẬT]
    public static object[] Fdt_NS_KTKL_QLKL_LKE(string b_phong, DataTable b_dt_tk, double b_tu_n, double b_den_n)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_dr["dtkl_tk"], chuyen.OBJ_N(b_dr["tungay_tk"]), chuyen.OBJ_N(b_dr["denngay_tk"]),
            b_dr["trangthai_tk"], b_phong ,b_dr["so_the_tk"],b_dr["ten_tk"],b_dr["nghi_viec_tk"],
            b_tu_n, b_den_n }, "NR", "PNS_KTKL_QLKL_LKE");
    }
    public static DataTable Fdt_NS_KTKL_QLKL_EXCEL(string b_dtkl, string b_tungay, string b_denngay, string b_tthai, string b_phong, string b_so_the, string b_ten, string b_nv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dtkl, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tthai, 
            b_phong, b_so_the, b_ten, b_nv}, "PNS_KTKL_QLKL_EXCEL");
    }
    public static object[] Fdt_NS_KTKL_QLKL_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_KTKL_QLKL_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataSet Fdt_NS_KTKL_QLKL_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_KTKL_QLKL_CT");
    }

    public static DataSet Fdt_NS_KTKL_QLKL_IN(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_KTKL_QLKL_IN");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_KTKL_QLKL_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_so_thenv = bang.Fobj_COL_MANG(b_dt_ct, "so_thenv");
            object[] a_cdanhnv = bang.Fobj_COL_MANG(b_dt_ct, "cdanhnv");
            object[] a_dvinv = bang.Fobj_COL_MANG(b_dt_ct, "dvinv");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_thenv", 'S', a_so_thenv);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanhnv", 'S', a_cdanhnv);
            dbora.P_THEM_PAR(ref b_lenh, "a_dvinv", 'S', a_dvinv);

            string b_c = ",:so_id" + "," + chuyen.OBJ_N(b_dr["ngay_hl"]) + "," + chuyen.OBJ_N(b_dr["ngay_hhl"])
                + "," + chuyen.OBJ_C(b_dr["soqd"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"])
                + "," + chuyen.OBJ_N(b_dr["ngayky"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["dtuong"])
                + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_N(b_dr["sotien"])
                + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["tvluong"]) + "," + chuyen.OBJ_N(b_dr["nam"])
                + "," + chuyen.OBJ_C(b_dr["kyluong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["cdanh"])
                + "," + chuyen.OBJ_C(b_dr["dvi"]) + ",:a_so_thenv,:a_cdanhnv,:a_dvinv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KTKL_QLKL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            //catch (Exception ex) { form.P_LOI(ex.Message ); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_KTKL_QLKL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_KTKL_QLKL_XOA");
    }

    /// <summary>Liệt kê ra excel</summary>
    public static DataTable Fdt_NS_KTKL_QLKL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_KTKL_QLKL_LKE_ALL");
    }
    /// <summary>Trả dữ liệu</summary>
    public static object[] Fdt_NS_KTKL_QLKL_TRA(string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the }, "R", "PNS_KTKL_QLKL_TRA");
    }
    public static DataTable Fdt_NS_MA_HTKL_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTKL_DR");
    }
    public static DataTable Fdt_NS_HS_KYLUONG_NAM(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_HS_KYLUONG_NAM");
    }
    public static object[] Faobj_NS_HTKL_TRA(string b_ma)
    {
        return dbora.Faobj_LKE(new object[] { b_ma }, "S", "PNS_MA_HTKL_TRA");
    }
    #endregion
}