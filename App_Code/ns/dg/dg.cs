using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
/// <summary>
/// Summary description for dg
/// </summary>
public class dg
{
    #region ĐÁNH GIÁ CÔNG NHÂN
    public static object[] Fdt_NS_DG_CONGNHAN_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_DG_CONGNHAN_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DG_CONGNHAN_MA(string b_phong, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay), b_trangkt }, "NNR", "PNS_DG_CONGNHAN_MA");
    }
    public static DataTable Fdt_NS_DG_CONGNHAN_CT(string b_phong, string b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_SO(b_ngay) }, "PNS_DG_CONGNHAN_CT");
    }

    public static void P_NS_DG_CONGNHAN_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_hieucv = bang.Fobj_COL_MANG(b_dt_ct, "hieucv");
            object[] a_bqthietbi = bang.Fobj_COL_MANG(b_dt_ct, "bqthietbi");
            object[] a_chatluong = bang.Fobj_COL_MANG(b_dt_ct, "chatluong");
            object[] a_atld = bang.Fobj_COL_MANG(b_dt_ct, "atld");
            object[] a_dongnghiep = bang.Fobj_COL_MANG(b_dt_ct, "dongnghiep");
            object[] a_khang = bang.Fobj_COL_MANG(b_dt_ct, "khang");
            object[] a_tiepthu = bang.Fobj_COL_MANG(b_dt_ct, "tiepthu");
            object[] a_thoigian = bang.Fobj_COL_MANG(b_dt_ct, "thoigian");
            object[] a_chaphanh = bang.Fobj_COL_MANG(b_dt_ct, "chaphanh");
            object[] a_ythuc = bang.Fobj_COL_MANG(b_dt_ct, "ythuc");
            object[] a_dongphuc = bang.Fobj_COL_MANG(b_dt_ct, "dongphuc");
            object[] a_sodiem = bang.Fobj_COL_MANG(b_dt_ct, "sodiem");
            object[] a_ap = bang.Fobj_COL_MANG(b_dt_ct, "ap");
            object[] a_a = bang.Fobj_COL_MANG(b_dt_ct, "a");
            object[] a_b = bang.Fobj_COL_MANG(b_dt_ct, "b");
            object[] a_c = bang.Fobj_COL_MANG(b_dt_ct, "c");
            object[] a_d = bang.Fobj_COL_MANG(b_dt_ct, "d");
            object[] a_db = bang.Fobj_COL_MANG(b_dt_ct, "db");
            object[] a_tq = bang.Fobj_COL_MANG(b_dt_ct, "tq");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_hieucv", 'U', a_hieucv);
            dbora.P_THEM_PAR(ref b_lenh, "a_bqthietbi", 'U', a_bqthietbi);
            dbora.P_THEM_PAR(ref b_lenh, "a_chatluong", 'U', a_chatluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_atld", 'U', a_atld);
            dbora.P_THEM_PAR(ref b_lenh, "a_dongnghiep", 'U', a_dongnghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_khang", 'U', a_khang);
            dbora.P_THEM_PAR(ref b_lenh, "a_tiepthu", 'U', a_tiepthu);
            dbora.P_THEM_PAR(ref b_lenh, "a_thoigian", 'U', a_thoigian);
            dbora.P_THEM_PAR(ref b_lenh, "a_chaphanh", 'U', a_chaphanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ythuc", 'U', a_ythuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_dongphuc", 'U', a_dongphuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodiem", 'U', a_sodiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_ap", 'U', a_ap);
            dbora.P_THEM_PAR(ref b_lenh, "a_a", 'U', a_a);
            dbora.P_THEM_PAR(ref b_lenh, "a_b", 'U', a_b);
            dbora.P_THEM_PAR(ref b_lenh, "a_c", 'U', a_c);
            dbora.P_THEM_PAR(ref b_lenh, "a_d", 'U', a_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_db", 'U', a_db);
            dbora.P_THEM_PAR(ref b_lenh, "a_tq", 'U', a_tq);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["ngay"])
                + ",:a_so_the,:a_ten,:a_hieucv,:a_bqthietbi,:a_chatluong,:a_atld,:a_dongnghiep,:a_khang,:a_tiepthu,:a_thoigian"
                + ",:a_chaphanh,:a_ythuc,:a_dongphuc,:a_sodiem,:a_ap,:a_a,:a_b,:a_c,:a_d,:a_db,:a_tq";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_CONGNHAN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_DG_CONGNHAN_XOA(string b_phong, string b_ngay)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CNG_SO(b_ngay) }, "PNS_DG_CONGNHAN_XOA");
    }
    public static DataTable Fdt_NS_DG_CONGNHAN_LKE_CB(string b_phong, string b_ngay)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_SO(b_ngay) }, "PNS_DG_CONGNHAN_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "hieucv", "bqthietbi", "chatluong", "atld", "dongnghiep", "khang", "tiepthu", "thoigian", "chaphanh", "ythuc", "dongphuc", "sodiem", "ap", "a", "b", "c", "d", "db", "tq" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }
    #endregion TÍNH LƯƠNG THÁNG

    #region DANH MỤC NHÓM NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static DataTable Fdt_DGNL_DM_N_NL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_DM_NHOM_NL_LKE_ALL");
    }
    public static object[] Fdt_DGNL_DM_N_NL_LKE(string b_luuday, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_tu_n, b_den_n }, "NR", "PNS_DG_DM_NHOM_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DGNL_DM_N_NL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_DM_NHOM_NL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DGNL_DM_N_NL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_DG_DM_NHOM_NL_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DGNL_DM_N_NL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_DM_NHOM_NL_XOA");
    }
    #endregion DANH MỤC NHÓM NĂNG LỰC

    #region DANH MỤC NĂNG LỰC - Cũ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_DGNL_DM_NL_LKE_DK(string b_nhom_nl)
    {
        return dbora.Fdt_LKE_S(b_nhom_nl, "PNS_DG_DM_NL_LKE_DK");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_MA_NL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_DM_NL_LKE_ALL");
    }
    public static object[] Fdt_DGNL_DM_NL_LKE(string b_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_tu_n, b_den_n }, "NR", "PNS_DG_DM_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DGNL_DM_NL_MA(string b_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_ma, b_trangkt }, "NNR", "PNS_DG_DM_NL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DGNL_DM_NL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ma_nhom"], b_dr["ng_bdau"], b_dr["ng_kthuc"], b_dr["tt"], b_dr["ghichu"] }, "PNS_DG_DM_NL_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DGNL_DM_NL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_NL_XOA");
    }
    #endregion

    #region DANH MỤC NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HDNS_MA_NL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_HDNS_MA_NL_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_HDNS_MA_NL_MA");
    }

    public static void P_NS_HDNS_MA_NL_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
            string b_ma_nhom = chuyen.OBJ_C(b_dr["MA_NHOM"]);
            string b_ma = chuyen.OBJ_C(b_dr["MA"]);
            string b_ten = chuyen.OBJ_C(b_dr["TEN"]);
            string b_tt = chuyen.OBJ_C(b_dr["TT"]);
            string b_dinhnghia = chuyen.OBJ_C(b_dr["ghichu"]);

            //object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl");
            object[] a_ten_muc_nl = bang.Fobj_COL_MANG(b_dt_ct, "ten_muc_nl");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_bieuhien = bang.Fobj_COL_MANG(b_dt_ct, "bieuhien");

            //dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_muc_nl", 'U', a_ten_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_bieuhien", 'U', a_bieuhien);

            string b_c = "," + b_so_id + "," + b_ma_nhom + "," + b_ma + "," + b_ten + "," + b_tt + "," + b_dinhnghia + ",:a_ten_muc_nl,:a_mota,:a_bieuhien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_NL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Liet ke chi tiet
    public static DataSet Fds_NS_HDNS_MA_NL_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_MA_NL_CT");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MA_NL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_NL_XOA");
    }
    public static DataTable Fdt_NS_HDNS_NHOM_NL_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_NHOM_NL_XEM");
    }
    #endregion

    #region XÂY DỰNG TỪ ĐIỂN NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static DataTable Fdt_DGNL_DM_XD_TD_NL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_DM_XD_TDNL_LKE_ALL");
    }
    public static object[] Fdt_DGNL_DM_XD_TD_NL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_DM_XD_TDNL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DGNL_DM_XD_TD_NL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_DM_XD_TDNL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DGNL_DM_XD_TD_NL_NH(string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nhom_nl"]) + "," + chuyen.OBJ_C(b_dr["nangluc"]) + "," + chuyen.OBJ_C(b_dr["muc_nl"]) + "," + chuyen.OBJ_C(b_dr["mota_theomuc"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_DM_XD_TDNL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_DGNL_DM_XD_TD_NL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_DM_XD_TDNL_XOA");
    }
    #endregion  XÂY DỰNG TỪ ĐIỂN NĂNG LỰC

    #region DANH MỤC ĐỢT ĐÁNH GIÁ NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DGNL_DM_DDG_NL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_DM_DG_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DGNL_DM_DDG_NL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_DM_DG_NL_MA");
    }

    public static object[] Fdt_DGNL_DM_DDG_NL_NAM(string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_trangkt }, "NNR", "PNS_DG_DM_DG_NL_NAM");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DGNL_DM_DDG_NL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["nam"], b_dr["gchu"] }, "PNS_DG_DM_DG_NL_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DGNL_DM_DDG_NL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_DM_DG_NL_XOA");
    }
    #endregion DANH MỤC ĐỢT ĐÁNH GIÁ NĂNG LỰC

    #region THIẾT LẬP NĂNG LỰC CHO CHỨC DANH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DGNL_TL_NL_CHO_CDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_TLNL_CHO_CDANH_LKE");
    }
    public static DataSet Fdt_DGNL_TL_NL_CHO_CDANH_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_DG_TLNL_CHO_CDANH_CT");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DGNL_TL_NL_CHO_CDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_TLNL_CHO_CDANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DGNL_TL_NL_CHO_CDANH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_ct, "sott");
            object[] a_nhom_nl = bang.Fobj_COL_MANG(b_dt_ct, "nhom_nl");
            object[] a_nangluc = bang.Fobj_COL_MANG(b_dt_ct, "nangluc");
            object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_ct, "muc_nl");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_nl", 'S', a_nhom_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_nangluc", 'S', a_nangluc);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl", 'S', a_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);


            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["cdanh"])
                + ",:a_sott,:a_nhom_nl,:a_nangluc,:a_muc_nl,:a_gchu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_TLNL_CHO_CDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_DGNL_TL_NL_CHO_CDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_TLNL_CHO_CDANH_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO CHỨC DANH

    #region THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_Fs_DGNL_TL_NL_CHO_NVIEN_LKE(double b_tu_n, double b_den_n)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("SO_THE", typeof(string));
        table.Columns.Add("HO_TEN", typeof(string));
        table.Columns.Add("ten_nhom", typeof(string));
        table.Columns.Add("ten_nl", typeof(string));
        table.Columns.Add("NHOMNL", typeof(string));
        table.Columns.Add("MANL", typeof(string));
        table.Columns.Add("MUCNL", typeof(string));
        table.Columns.Add("ghichu", typeof(string));
        table.Columns.Add("nsd", typeof(string));
        table.Columns.Add("SO_ID", typeof(double));
        table.Rows.Add("00017", "Hoàng Văn Nam", "Chuyên môn", "Năng lực 1", "01", "NL01", " 1/2", "ghi chú 1", b_se.nsd, 10000);
        table.Rows.Add("00018", "Phạm Thúy Vân", "Chuyên môn", "Năng lực 2", "01", "NL02", " 1/6", "ghi chú 2", b_se.nsd, 10001);
        table.Rows.Add("00019", "Vũ Thị Thu Hiền", "Chuyên môn", "Năng lực 1", "01", "NL03", "1/5", "", b_se.nsd, 10002);
        return table;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_DGNL_TL_NL_CHO_NVIEN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_DGNL_TL_NL_CHO_NVIEN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_DGNL_TL_NL_CHO_NVIEN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PFs_DGNL_TL_NL_CHO_NVIEN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_DGNL_TL_NL_CHO_NVIEN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_DGNL_TL_NL_CHO_NVIEN_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region THIẾT LẬP KHÓA HỌC THEO TIÊU CHUẨN NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_DGNL_TL_KH_THEO_TC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_NL_THEO_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_DGNL_TL_KH_THEO_TC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_NL_THEO_CDANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_DGNL_TL_KH_THEO_TC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["cdanh"], b_dr["nhom_nl"], b_dr["nangluc"], b_dr["muc_nl"], b_dr["ma"], b_dr["ten"], b_dr["gchu"] }, "PNS_DG_NL_THEO_CDANH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_DGNL_TL_KH_THEO_TC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_NL_THEO_CDANH_XOA");
    }
    #endregion THIẾT LẬP KHÓA HỌC THEO TIÊU CHUẨN NĂNG LỰC

    #region ĐÁNH GIÁ NĂNG LỰC CHO CÁN BỘ NHÂN VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_DGNL_NGV_NL_NV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_NVU_NL_NV_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static DataSet Fdt_DGNL_NGV_NL_NV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_DG_NVU_NL_NV_CT");
    }

    public static void P_Fs_DGNL_NGV_NL_NV_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_nhom_nl = bang.Fobj_COL_MANG(b_dt_ct, "nhom_nl");
            object[] a_nangluc = bang.Fobj_COL_MANG(b_dt_ct, "nangluc");
            object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_ct, "muc_nl");
            object[] a_muc_nl_cn = bang.Fobj_COL_MANG(b_dt_ct, "muc_nl_cn");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_nl", 'S', a_nhom_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_nangluc", 'S', a_nangluc);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl", 'U', a_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl_cn", 'U', a_muc_nl_cn);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            string b_c = ",:so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["dot_dgia"])
                + ",:a_tt" + ",:a_so_the" + ",:a_ten" + ",:a_phong" + ",:a_nhom_nl" + ",:a_nangluc" + ",:a_muc_nl" + ",:a_muc_nl_cn" + ",:a_gchu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_NVU_NL_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_DGNL_NGV_NL_NV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DG_NVU_NL_NV_XOA");
    }

    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_Fs_DGNL_NGV_NL_NV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_DGNL_NGV_NL_NV_MA");
    }
    #endregion DANH MỤC NĂNG LỰC

    #region DANH MỤC KỲ ĐÁNH GIÁ

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DG_MA_KDG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_KDG_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DG_DM_KDG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_KDG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DG_DM_KDG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_KDG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DG_DM_KDG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_N(b_dr["ng_hluc"]), chuyen.OBJ_N(b_dr["ng_het_hluc"]), b_dr["pbo_kdg"], b_dr["adung_kdg"], chuyen.OBJ_N(b_dr["ngay_dg_d"]), chuyen.OBJ_N(b_dr["ngay_dg_c"]), b_dr["gchu"] }, "PNS_DG_MA_KDG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DG_DM_KDG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_MA_KDG_XOA");
    }
    #endregion DANH MỤC NĂNG LỰC

    #region DANH MỤC NHÓM CÂU HỎI

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DG_MA_NHOM_CAUHOI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_NHOM_CAUHOI_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DG_DM_NHOM_CAUHOI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_NHOM_CAUHOI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DG_DM_NHOM_CAUHOI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_NHOM_CAUHOI_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DG_DM_NHOM_CAUHOI_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mo_ta"] }, "PNS_DG_MA_NHOM_CAUHOI_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DG_DM_NHOM_CAUHOI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_MA_NHOM_CAUHOI_XOA");
    }
    #endregion DANH MỤC NĂNG LỰC

    #region THIẾT LẬP ĐỐI TƯỢNG
    public static DataSet Fds_DG_DM_DTDG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_DM_DTDG_CT");
    }
    public static object[] Faobj_DG_DM_DTDG_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PDG_DM_DTDG_LKE");
    }
    public static object[] Faobj_DG_DM_DTDG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DM_DTDG_MA");
    }
    public static void PDG_DM_DTDG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            //object[] a_nhom_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ma_cd");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
            object[] a_thamnien = bang.Fobj_COL_MANG(b_dt_ct, "thamnien");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cdanh", 'U', a_nhom_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'U', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_thamnien", 'N', a_thamnien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_N(b_dr["ngay_ad"])
                +",:a_cdanh" + ",:a_capbac" + ",:a_thamnien" + ",:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_DTDG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_DM_DTDG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_DM_DTDG_XOA");
    }
    public static object[] Faobj_DG_DM_DTDG_CT_LKE(string b_kdg)
    {
        return dbora.Faobj_LKE(new object[] { b_kdg }, "R", "PDG_DM_DTDG_CT_LKE");
    }
    //public static DataTable Fdt_DG_DM_DTDG_NHL(string b_nam)
    //{
    //    return dbora.Fdt_LKE_S(b_nam, "PNS_DG_DM_DTDG_NHL");
    //}
    public static DataTable Fdt_NHOM_CDANH_DR()
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PNS_NHOM_CDANH_DR");
    }
    public static DataTable Fdt_NHUCAU_DT_DR()
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PNS_NHUCAU_DT_DR");
    }
    public static DataTable Fdt_NS_MA_DTDG_NCDANH(string b_ky_dg)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ky_dg }, "PNS_MA_DTDG_NCDANH");
    }
    public static DataTable Fdt_CDANH_TLAP_DTDG_DR(string b_nam, string b_ky_dg, string b_nhom_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_ky_dg, b_nhom_cdanh }, "PNS_CDANH_TLAP_DTDG_DR");
    }
    public static object[] Fdt_CDANH_DR(string b_nhom_cdanh, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom_cdanh, b_tu, b_den }, "NR", "PNS_CDANH_DR");
    }
    public static DataTable Fdt_CDANH_IMPORT()
    {
        return dbora.Fdt_LKE("PNS_CDANH_IMPORT");
    }
    public static DataTable Fdt_CDANH_DROP(string b_nhom_cdanh)
    {
        return dbora.Fdt_LKE_S(b_nhom_cdanh, "PNS_CDANH_DROP");
    }
    public static DataTable Fdt_CAPBAC_DR()
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PNS_CAPBAC_DR");
    }
    //lấy năm của kỳ đánh giá
    public static DataTable Fdt_DG_DM_MA_KDG_NAM()
    {
        return dbora.Fdt_LKE("PNS_DG_DM_KDG_NAM");
    }
    //lấy kỳ đánh giá theo năm - phân hệ Đánh giá 360
    public static DataTable Fdt_DG_DM_DTDG_KDG_NHL(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PDG_DM_DTDG_KDG_NHL");
    }
    //lấy kỳ đánh giá theo năm-import - phân hệ Đánh giá 360
    public static DataTable Fdt_DG_DM_DTDG_KDG_NHL_IMPORT(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PDG_DM_DTDG_KDG_NHL_IMPORT");
    }
    //lấy kỳ đánh giá theo năm - phân hệ Đánh giá
    public static DataTable Fdt_DG_DM_DTDG_KDG_DG_NHL(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PDG_DM_DTDG_KDG_DG_NHL");
    }
    //lấy đợt đánh giá theo kỳ đánh giá - phân hệ đánh giá
    public static DataTable Fdt_DG_DM_DTDG_DDG_DG_NHL(string b_kydg)
    {
        return dbora.Fdt_LKE_S(b_kydg, "PDG_DM_DTDG_DDG_DG_NHL");
    }
    #endregion THIẾT LẬP ĐỐI TƯỢNG

    #region THIẾT LẬP MẪU ĐÁNH GIÁ
    public static DataTable Fdt_DG_DM_MDG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PDG_DM_MDG_LKE_ALL");
    }
    public static DataSet Fds_DG_DM_MDG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_DM_MDG_CT");
    }
    public static object[] Faobj_DG_DM_MDG_LKE(string b_nam, string b_ky_dg, string b_dtuong_dg, string b_cdanh, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ky_dg, b_dtuong_dg, b_cdanh, b_tu, b_den }, "NR", "PDG_DM_MDG_LKE");
    }
    public static object[] Faobj_DG_DM_MDG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DM_MDG_MA");
    }
    public static void PDG_DM_MDG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_ma_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "ma_cauhoi");
            object[] a_nd_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nd_cauhoi");

            //b_dt_danh
            //object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "cdanh");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cauhoi", 'S', a_ma_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_cauhoi", 'U', a_nd_cauhoi);

            //dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["nhom_cdanh"]) + "," +
                chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["doituong_dg"]) + "," + chuyen.OBJ_S(b_dr["ngay_ad"]) + "," +
                chuyen.OBJ_C(b_dr["nhom_cauhoi"]) + "," + chuyen.OBJ_C(b_dr["mo_ta"])
                + ",:a_stt,:a_ma_cauhoi,:a_nd_cauhoi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_MDG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_DM_MDG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_DM_MDG_XOA");
    }
    public static void PDG_DM_MDG_IMPORT(/*ref string b_so_id, DataTable b_dt,*/ DataTable b_dt_ct /*DataTable b_dt_cdanh*/)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ad");
            object[] a_nam = bang.Fobj_COL_MANG(b_dt_ct, "nam");
            object[] a_ky_dg = bang.Fobj_COL_MANG(b_dt_ct, "ky_dg");
            object[] a_nhom_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_doituong_dg = bang.Fobj_COL_MANG(b_dt_ct, "doituong_dg");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ad");
            object[] a_nhom_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cauhoi");
            object[] a_ma_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "ma_cauhoi");
            object[] a_nd_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nd_cauhoi");
            object[] a_mo_ta = bang.Fobj_COL_MANG(b_dt_ct, "mo_ta");


            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_ky_dg", 'S', a_ky_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cdanh", 'S', a_nhom_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_doituong_dg", 'S', a_doituong_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cauhoi", 'S', a_nhom_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cauhoi", 'S', a_ma_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_cauhoi", 'U', a_nd_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_mo_ta", 'U', a_mo_ta);


            string b_c =
                ",:a_nam,:a_ky_dg,:a_nhom_cdanh,:a_cdanh,:a_doituong_dg,:a_ngay_ad,:a_nhom_cauhoi,:a_ma_cauhoi,:a_nd_cauhoi,:a_mo_ta";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_MDG_IMPORT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.IMPORT, TEN_FORM.DG_DM_MDG, TEN_BANG.DG_DM_MDG);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //lấy nhóm câu hỏi 
    public static DataTable Fdt_DG_DM_MA_NHOM_CAUHOI()
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PDG_DM_MA_NHOM_CAUHOI");
    }
    //lấy đối tượng đánh giá
    public static DataTable Fdt_DG_DM_MA_DTUONG_DG()
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PDG_DM_MA_DTUONG_DG");
    }
    public static DataTable Fdt_VITRI_DR()
    {
        return dbora.Fdt_LKE("PNS_VITRI_DR");
    }
    #endregion THIẾT LẬP MẪU ĐÁNH GIÁ

    #region TỔNG HỢP THỰC HIỆN ĐÁNH GIÁ
    public static object[] Faobj_DG_DS_THUCHIEN_DGIA_LKE(string b_kydg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_kydg, b_tu, b_den }, "NR", "PDG_DS_THUCHIEN_DGIA_LKE");
    }
    public static object[] Faobj_DG_DS_THUCHIEN_DGIA_TH(string b_kydg,string b_ngay_th, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_kydg,chuyen.CNG_SO(b_ngay_th), b_tu, b_den }, "NR", "PDG_DS_THUCHIEN_DGIA_TH");
    }
    public static object[] Faobj_DG_DS_THUCHIEN_DGIA_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DS_THUCHIEN_DGIA_MA");
    }
    public static DataSet Fds_DG_DS_THUCHIEN_DGIA_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_DS_THUCHIEN_DGIA_CT");
    }
    public static void PDG_DS_THUCHIEN_DGIA_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            
            object[] a_sothe = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_ngayth = bang.Fobj_COL_MANG(b_dt_ct, "ngay_th");
            object[] a_da_dg = bang.Fobj_COL_MANG(b_dt_ct, "da_dg");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cdanh", 'U', a_nhom_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe", 'S', a_sothe);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayth", 'N', a_ngayth);
            dbora.P_THEM_PAR(ref b_lenh, "a_da_dg", 'S', a_da_dg);

            string b_c = ",:so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_N(b_dr["ngayd"])
                + ",:a_sothe" + ",:a_ten" + ",:a_ngayth" + ",:a_da_dg";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DS_THUCHIEN_DGIA_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ NỘI BỘ
    public static object[] Faobj_DG_DM_TONGHOP_DGNB_LKE(string b_kydg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_kydg, b_tu, b_den }, "NR", "PDG_DM_TONGHOP_DGNB_LKE");
    }
    public static object[] Fdt_DG_NGV_TONGHOP_DGNB_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PDG_NGV_TONGHOP_DGNB_MA");
    }
    public static DataSet Fds_DG_DM_TONGHOP_DGNB_CT(string b_so_id, string b_ky_dg)
    {
        return dbora.Fds_LKE(new object[] { b_so_id, b_ky_dg }, 2, "PDG_NGV_TONGHOP_DGNB_CT");
    }
    public static void PDG_NGV_TONGHOP_DGNB_NH(string b_nam, string b_kydanhgia)
    {
        dbora.P_GOIHAM(new object[] { b_nam, b_kydanhgia }, "PDG_NGV_TONGHOP_DGNB_NH");
    }
    public static DataSet Fdt_DG_NGV_TONGHOP_DGNB_LKE_ALL(string b_nam)
    {
        return dbora.Fds_LKE(new object[] { b_nam }, 1, "PDG_NGV_TONGHOP_DGNB_LKE_ALL");
    }
    #endregion TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ NỘI BỘ

    #region TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ KHÁCH HÀNG
    public static object[] Faobj_DG_NGV_TONGHOP_DGKH_LKE(string b_kydg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_kydg, b_tu, b_den }, "NR", "PDG_NGV_TONGHOP_DGKH_LKE");
    }
    public static object[] Fdt_DG_NGV_TONGHOP_DGKH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PDG_NGV_TONGHOP_DGKH_MA");
    }
    public static DataSet Fds_DG_NGV_TONGHOP_DGKH_CT(string b_sothe, string b_ky_dg)
    {
        return dbora.Fds_LKE(new object[] { b_sothe, b_ky_dg }, 2, "PDG_NGV_TONGHOP_DGKH_CT");
    }
    public static void PDG_NGV_TONGHOP_DGKH_NH(string b_nam, string b_kydanhgia)
    {
        dbora.P_GOIHAM(new object[] { b_nam, b_kydanhgia }, "PDG_NGV_TONGHOP_DGKH_NH");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_DG_NGV_TONGHOP_DGKH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PDG_NGV_TONGHOP_DGKH_LKE_ALL");
    }
    #endregion TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ KHÁCH HÀNG

    #region DANH MỤC KỲ ĐÁNH GIÁ - PHÂN HỆ ĐÁNH GIÁ

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DG_MA_KDG_DG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_KDG_DG_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DG_MA_KDG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_KDG_DG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DG_MA_KDG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_KDG_DG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DG_MA_KDG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_N(b_dr["ng_hluc"]), chuyen.OBJ_N(b_dr["ng_het_hluc"]), b_dr["kdg_theo"], b_dr["pbo_kdg"], b_dr["adung_kdg"], chuyen.OBJ_N(b_dr["ngay_dg_d"]), chuyen.OBJ_N(b_dr["ngay_dg_c"]), b_dr["gchu"] }, "PNS_DG_MA_KDG_DG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DG_MA_KDG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_MA_KDG_DG_XOA");
    }
    #endregion DANH MỤC KỲ ĐÁNH GIÁ - PHÂN HỆ ĐÁNH GIÁ

    #region DANH MỤC NHÓM TIÊU CHÍ
    public static DataTable Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_NHOM_TCHI_LKE_ALL");
    }

    public static DataTable Fdt_NS_DG_MA_NHOM_TCHI_DR(string b_tt)
    {
        return dbora.Fdt_LKE_S(b_tt, "PNS_DG_MA_NHOM_TCHI_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DG_DM_NHOM_TIEUCHI_LKE(string b_tt, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt, b_tu_n, b_den_n }, "NR", "PNS_DG_MA_NHOM_TCHI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DG_DM_NHOM_TIEUCHI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_NHOM_TCHI_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DG_DM_NHOM_TIEUCHI_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["gchu"] }, "PNS_DG_MA_NHOM_TCHI_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DG_DM_NHOM_TIEUCHI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_MA_NHOM_TCHI_XOA");
    }
    #endregion DANH MỤC NHÓM TIÊU CHÍ

    #region DANH MỤC TIÊU CHÍ
    public static DataTable Fdt_NS_DG_MA_TCHI_LKE_TATCA()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_TCHI_LKE_TATCA");
    }
    public static DataTable Fdt_NS_DG_MA_TCHI_LKE_ALL(string b_ma_nhom)
    {
        return dbora.Fdt_LKE_S(b_ma_nhom, "PNS_DG_MA_TCHI_LKE_ALL");
    }
    public static object[] Fdt_NS_DG_MA_TCHI_LKE_ALL_NHOMTC(string b_ma_nhom)
    {
        return dbora.Faobj_LKE(b_ma_nhom, "NR", "PNS_DG_MA_TCHI_LKE_ALL_NHOMTC");
    }
    public static object[] Fdt_NS_DG_MA_TCHI_LKE_ALL_NHOMTC1(string b_ma_nhom, double b_tu, double b_den)  // load cho drop 
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nhom, b_tu, b_den }, "NR", "PNS_DG_MA_TCHI_LKE_ALL_NHOMTC1");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DG_DM_TIEUCHI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_TCHI_LKE");
    }
    public static object[] Fobj_DG_DM_TIEUCHI_LKE_NHOM(double b_tu_n, double b_den_n, string b_ma_nhom, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_ma_nhom, b_tt }, "NR", "PNS_DG_MA_TCHI_LKE_NHOM");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DG_DM_TIEUCHI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_TCHI_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_DG_DM_TIEUCHI_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra;
        if (chuyen.OBJ_S(b_dr["ma"]) == "") b_kiemtra = false;
        else b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "DG_DM_TIEUCHI", "MA");
        if (!b_kiemtra)
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TC", "DG_DM_TIEUCHI", "MA");

        dbora.P_GOIHAM(new object[] { b_dr["ma_nhom"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["gchu"] }, "PNS_DG_MA_TCHI_NH");
        return b_dr["ma"].ToString();
    }
    ///<summary> Xóa </summary>
    public static void P_DG_DM_TIEUCHI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_DG_MA_TCHI_XOA");
    }

    public static void P_DG_DM_TIEUCHI_FILE_NH(DataTable b_dt_ct)
    {
        bool b_kiemtra;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            if (chuyen.OBJ_S(b_dr["ma"]) == "") b_kiemtra = false;
            else b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "DG_DM_TIEUCHI", "MA");
            if (!b_kiemtra)
                b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TC", "DG_DM_TIEUCHI", "MA");
            dbora.P_GOIHAM(new object[] {b_dr["ma_nhom"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["gchu"] }, "PNS_DG_MA_TCHI_NH");
        }
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.IMPORT, TEN_FORM.DG_DM_TIEUCHI, TEN_BANG.DG_DM_TIEUCHI);
    } 
    #endregion DANH MỤC NĂNG LỰC

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ THEO CHỨC DANH
    public static DataSet Fds_DG_DM_TCDG_CD_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_DM_TCDG_CD_CT");
    }
    public static object[] Faobj_DG_DM_TCDG_CD_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PDG_DM_TCDG_CD_LKE");
    }
    public static object[] Faobj_DG_DM_TCDG_CD_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DM_TCDG_CD_MA");
    }
    public static void PDG_DM_TCDG_CD_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_nhom_tc = bang.Fobj_COL_MANG(b_dt_ct, "nhom_tc");
            object[] a_trongso_ntc = bang.Fobj_COL_MANG(b_dt_ct, "trongso_ntc");
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "tieuchi");
            object[] a_trongso_tc = bang.Fobj_COL_MANG(b_dt_ct, "trongso_tc");
            object[] a_donvitinh = bang.Fobj_COL_MANG(b_dt_ct, "donvitinh");
            object[] a_khongdat = bang.Fobj_COL_MANG(b_dt_ct, "khongdat");
            object[] a_cancaitien = bang.Fobj_COL_MANG(b_dt_ct, "cancaitien");
            object[] a_dat = bang.Fobj_COL_MANG(b_dt_ct, "dat");
            object[] a_tot = bang.Fobj_COL_MANG(b_dt_ct, "tot");
            object[] a_xuatsac = bang.Fobj_COL_MANG(b_dt_ct, "xuatsac");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_titrong = bang.Fobj_COL_MANG(b_dt_ct, "titrong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "so_idct", 'N', 'O', chuyen.OBJ_N(b_soid_ct));
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_tc", 'S', a_nhom_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_trongso_ntc", 'S', a_trongso_ntc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'S', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_trongso_tc", 'S', a_trongso_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvitinh", 'S', a_donvitinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_khongdat", 'S', a_khongdat);
            dbora.P_THEM_PAR(ref b_lenh, "a_cancaitien", 'S', a_cancaitien);
            dbora.P_THEM_PAR(ref b_lenh, "a_dat", 'S', a_dat);
            dbora.P_THEM_PAR(ref b_lenh, "a_tot", 'S', a_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_xuatsac", 'S', a_xuatsac);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_titrong", 'S', a_titrong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," +
                chuyen.OBJ_C(b_dr["ncd"]) + "," + chuyen.OBJ_C(b_dr["cd"]) + "," + chuyen.OBJ_C(b_dr["ngay_ad"])
                + ",:a_nhom_tc" + ",:a_trongso_ntc" + ",:a_tieuchi" + ",:a_trongso_tc" + ",:a_donvitinh" + ",:a_khongdat" + ",:a_cancaitien"
                + ",:a_dat" + ",:a_tot" + ",:a_xuatsac" + ",:a_mota" + ",:a_titrong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_TCDG_CD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_DM_TCDG_CD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_DM_TCDG_CD_XOA");
    }
    public static object[] Faobj_DG_DM_TCDG_CD_CT_LKE(string b_kdg)
    {
        return dbora.Faobj_LKE(new object[] { b_kdg }, "R", "PDG_DM_TCDG_CD_CT_LKE");
    }
    public static DataTable Fdt_CDANH_DR(string b_nhom_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom_cdanh }, "PNS_CDANH_DR");
    }
    public static DataSet Fdt_CAPBAC_DR(string b_cdanh)
    {
        return dbora.Fds_LKE(b_cdanh, 2, "pns_nhom_cd");
    }
    //lấy năm của kỳ đánh giá
    public static DataTable Fdt_DG_DM_TCDG_CD_KDG_NHL(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PDG_DM_TCDG_CD_KDG_NHL");
    }
    #endregion THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ THEO CHỨC DANH

    #region THIẾT LẬP NĂNG LỰC ĐÁNH GIÁ THEO NHÓM CHỨC DANH
    public static DataSet Fds_NS_DG_TLNL_CDANH_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_DG_TLNL_CDANH_CT");
    }
    public static object[] Faobj_NS_DG_TLNL_CDANH_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DG_TLNL_CDANH_LKE");
    }
    public static object[] Faobj_NS_DG_TLNL_CDANH_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DG_TLNL_CDANH_MA");
    }
    public static void PDG_NS_DG_TLNL_CDANH_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_tytrong = bang.Fobj_COL_MANG(b_dt_ct, "tytrong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_tytrong", 'N', a_tytrong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," +
                chuyen.OBJ_C(b_dr["ngay_ad"]) + "," + chuyen.OBJ_C(b_dr["ncd"]) + ",:a_mota" + ",:a_tytrong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_TLNL_CDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_NS_DG_TLNL_CDANH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DG_TLNL_CDANH_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC ĐÁNH GIÁ THEO NHÓM CHỨC DANH

    #region THIẾT LẬP QUY ĐỊNH XẾP LOẠI ĐÁNH GIÁ
    public static DataSet Fds_TL_QD_XL_DG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 1, "PTL_QD_XL_DG_CT");
    }
    public static object[] Faobj_TL_QD_XL_DG_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PTL_QD_XL_DG_LKE");
    }
    public static object[] Faobj_TL_QD_XL_DG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PTL_QD_XL_DG_MA");
    }
    public static void PTL_QD_XL_DG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_diemdanhgia_tu = bang.Fobj_COL_MANG(b_dt_ct, "diemdanhgia_tu");
            object[] a_diemdanhgia_den = bang.Fobj_COL_MANG(b_dt_ct, "diemdanhgia_den");
            object[] a_xeploai = bang.Fobj_COL_MANG(b_dt_ct, "xeploai");
            object[] a_heso = bang.Fobj_COL_MANG(b_dt_ct, "heso");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_diemdanhgia_tu", 'S', a_diemdanhgia_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_diemdanhgia_den", 'S', a_diemdanhgia_den);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai", 'U', a_xeploai);
            dbora.P_THEM_PAR(ref b_lenh, "a_heso", 'S', a_heso);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ngayhieuluc"]) + "," + chuyen.OBJ_C(b_dr["loai_dg"])
                + ",:a_diemdanhgia_tu" + ",:a_diemdanhgia_den" + ",:a_xeploai" + ",:a_heso" + ",:a_mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PTL_QD_XL_DG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PTL_QD_XL_DG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PTL_QD_XL_DG_XOA");
    }
    public static object[] Faobj_TL_QD_XL_DG_CT_LKE(string b_kdg)
    {
        return dbora.Faobj_LKE(new object[] { b_kdg }, "R", "PTL_QD_XL_DG_CT_LKE");
    } 
    public static DataTable Fdt_TL_QD_XL_DG_KDG_NHL(string b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PTL_QD_XL_DG_KDG_NHL");
    }
    #endregion THIẾT LẬP QUY ĐỊNH XẾP LOẠI ĐÁNH GIÁ

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ CHO CHỨC DANH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_DG_TL_NHOM_CDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_TL_NHOM_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_DG_TL_NHOM_CDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_TL_NHOM_CDANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_DG_TL_NHOM_CDANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["cdanh"], b_dr["nhom_tchi"], b_dr["tchi_dgia"], b_dr["trongso"], b_dr["gchu"] }, "PNS_DG_TL_NHOM_CDANH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_DG_TL_NHOM_CDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_TL_NHOM_CDANH_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO CHỨC DANH

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ CHO NHÂN VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_Fs_DG_TL_CB_NVIEN_LKE(double b_tu_n, double b_den_n)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("SO_THE", typeof(string));
        table.Columns.Add("HO_TEN", typeof(string));
        table.Columns.Add("DONVI", typeof(string));
        table.Columns.Add("CDANH", typeof(string));
        table.Columns.Add("ten_nhom", typeof(string));
        table.Columns.Add("ten_nl", typeof(string));
        table.Columns.Add("NHOMNL", typeof(string));
        table.Columns.Add("MANL", typeof(string));
        table.Columns.Add("MUCNL", typeof(string));
        table.Columns.Add("ghichu", typeof(string));
        table.Columns.Add("nsd", typeof(string));
        table.Columns.Add("SO_ID", typeof(double));
        table.Rows.Add("00017", "Hoàng Văn Nam", "IT", "Kế toán trưởng", "Chất lượng công việc", "Hoàn thành công việc", "01", "NL01", " 40%", "ghi chú 1", b_se.nsd, 10000);
        table.Rows.Add("00018", "Phạm Thúy Vân", "IT", "Lập trình viên", "Chất lượng công việc", "đạt tiêu chuẩn", "01", "NL02", " 60%", "ghi chú 2", b_se.nsd, 10001);
        table.Rows.Add("00019", "Vũ Thị Thu Hiền", "IT", "Giám đốc", "Ý thức công việc", "Phối hợp công việc", "01", "NL03", "80%", "", b_se.nsd, 10002);
        return table;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_DG_TL_CB_NVIEN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_DG_TL_CB_NVIEN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_DG_TL_CB_NVIEN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PFs_DG_TL_CB_NVIEN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_DG_TL_CB_NVIEN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_DG_TL_CB_NVIEN_XOA");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region THIẾT LẬP TỶ LỆ XẾP LOẠI ĐÁNH GIÁ NHÂN VIÊN THEO XẾP LOẠI BỘ PHẬN
    public static DataSet Fds_DG_DM_TLDGNV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_DM_TLDGNV_CT");
    }
    public static object[] Faobj_DG_DM_TLDGNV_LKE(string b_cty, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_cty, b_tu, b_den }, "NR", "PDG_DM_TLDGNV_LKE");
    }
    public static object[] Faobj_DG_DM_TLDGNV_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DM_TLDGNV_MA");
    }
    public static void PDG_DM_TLDGNV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_xeploai_bp = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_bp");
            object[] a_xeploai_xuatsac = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_xuatsac");
            object[] a_xeploai_tot = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_tot");
            object[] a_xeploai_dat = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_dat");
            object[] a_xeploai_caithien = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_caithien");
            object[] a_xeploai_kdat = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_kdat");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_bp", 'U', a_xeploai_bp);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_xuatsac", 'U', a_xeploai_xuatsac);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_tot", 'U', a_xeploai_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_dat", 'U', a_xeploai_dat);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_caithien", 'U', a_xeploai_caithien);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_kdat", 'U', a_xeploai_kdat);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["cty"]) + "," + chuyen.OBJ_N(b_dr["ngay_hl"])
                + ",:a_xeploai_bp" + ",:a_xeploai_xuatsac" + ",:a_xeploai_tot" + ",:a_xeploai_dat" + ",:a_xeploai_caithien" + ",:a_xeploai_kdat";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_TLDGNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_DM_TLDGNV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_DM_TLDGNV_XOA");
    }
    public static object[] Faobj_DG_DM_TLDGNV_CT_LKE(string b_kdg)
    {
        return dbora.Faobj_LKE(new object[] { b_kdg }, "R", "PDG_DM_TLDGNV_CT_LKE");
    }
    #endregion THIẾT LẬP TỶ LỆ XẾP LOẠI ĐÁNH GIÁ NHÂN VIÊN THEO XẾP LOẠI BỘ PHẬN

    #region NHẬP CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG
    //lấy năm của kỳ đánh giá
    public static DataTable Fdt_NS_DG_MA_KDG_DR()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_KDG_DR");
    }
    public static DataSet Fds_DG_NGV_CTCV_HT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_NGV_CTCV_HT_CT");
    }
    public static object[] Faobj_DG_NGV_CTCV_HT_LKE(string b_trangthai, string b_kydg_gtri, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_kydg_gtri, b_tu, b_den }, "NR", "PDG_NGV_CTCV_HT_LKE");
    }
    public static object[] Faobj_DG_NGV_CTCV_HT_MA(string b_so_id, string b_trangthai, string b_kydg_gtri, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangthai, b_kydg_gtri, b_trangkt }, "NNR", "PDG_NGV_CTCV_HT_MA");
    }
    public static void PDG_NGV_CTCV_HT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_nd_congviec = bang.Fobj_COL_MANG(b_dt_ct, "nd_congviec");
            object[] a_trongso = bang.Fobj_COL_MANG(b_dt_ct, "trongso");
            object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d");
            object[] a_ngay_ht = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ht");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_congviec", 'U', a_nd_congviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_trongso", 'S', a_trongso);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ht", 'N', a_ngay_ht);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," +
                chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) +
                ",:a_stt,:a_nd_congviec,:a_trongso,:a_ngay_d,:a_ngay_ht";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_NGV_CTCV_HT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }

        //se.se_nsd b_se = new se.se_nsd();
        //OracleConnection b_cnn = dbora.Fcn_KNOI();
        //try
        //{
        //    OracleCommand b_lenh = new OracleCommand();
        //    b_lenh.Connection = b_cnn;
        //    DataRow b_dr = b_dt.Rows[0];

        //    // stt,nd_congviec,trongso,ngay_d,ngay_ht,diengiai_kqth,tyle_ht_nv,tyle_ht_tso_nv,
        //    // kkhan_gphap_dxuat,ykien_kq_th,tyle_ht_ql,tyle_ht_tso_ql,gchu



        //    object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
        //    object[] a_nd_congviec = bang.Fobj_COL_MANG(b_dt_ct, "nd_congviec");
        //    object[] a_trongso = bang.Fobj_COL_MANG(b_dt_ct, "trongso");
        //    object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d");
        //    object[] a_ngay_ht = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ht");

        //    object[] a_diengiai_kqth = bang.Fobj_COL_MANG(b_dt_ct, "diengiai_kqth");
        //    object[] a_tyle_ht_nv = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_nv");
        //    object[] a_tyle_ht_tso_nv = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_tso_nv");
        //    object[] a_kkhan_gphap_dxuat = bang.Fobj_COL_MANG(b_dt_ct, "kkhan_gphap_dxuat");
        //    object[] a_ykien_kq_th = bang.Fobj_COL_MANG(b_dt_ct, "ykien_kq_th");
        //    object[] a_tyle_ht_ql = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_ql");
        //    object[] a_tyle_ht_tso_ql = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_tso_ql");
        //    object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");


        //    dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

        //    dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_nd_congviec", 'U', a_nd_congviec);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_trongso", 'S', a_trongso);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d", 'N', a_ngay_d);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ht", 'N', a_ngay_ht);

        //    dbora.P_THEM_PAR(ref b_lenh, "a_diengiai_kqth", 'U', a_diengiai_kqth);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_nv", 'S', a_tyle_ht_nv);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_tso_nv", 'S', a_tyle_ht_tso_nv);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_kkhan_gphap_dxuat", 'U', a_kkhan_gphap_dxuat);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_ykien_kq_th", 'U', a_ykien_kq_th);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_ql", 'S', a_tyle_ht_ql);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_tso_ql", 'S', a_tyle_ht_tso_ql);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);




        //    string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," +
        //        chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) +
        //        ",:a_stt,:a_nd_congviec,:a_trongso,:a_ngay_d,:a_ngay_ht,:a_diengiai_kqth,:a_tyle_ht_nv,:a_tyle_ht_tso_nv,:a_kkhan_gphap_dxuat,:a_ykien_kq_th,:a_tyle_ht_ql,:a_tyle_ht_tso_ql,:a_gchu";
        //    b_lenh.CommandText = "Begin " + b_se.dbo + ".PQL_DG_CV_HT_NH(" + b_se.tso + b_c + "); end;";
        //    try
        //    {
        //        b_lenh.ExecuteNonQuery();
        //        b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
        //    }
        //    finally { b_lenh.Parameters.Clear(); }
        //}
        //finally { b_cnn.Close(); }


    }
    public static void PDG_NGV_CTCV_HT_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PDG_NGV_CTCV_HT_GUI");
    }
    public static void PDG_NGV_CTCV_HT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_NGV_CTCV_HT_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO(string b_ma_nv)
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PNS_TTIN_CANBO");
    }
    #endregion NHẬP CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG

    #region NỘI BỘ ĐÁNH GIÁ
    public static DataSet Fds_DG_NGV_NBDG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_NGV_NBDG_CT");
    }
    public static object[] Faobj_DG_NGV_NBDG_LKE(string b_nam, string b_ky_dg, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ky_dg, b_trangthai, b_tu, b_den }, "NR", "PDG_NGV_NBDG_LKE");
    }
    public static object[] Faobj_DG_NGV_NBDG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_NGV_NBDG_MA");
    }
    public static void PDG_NGV_NBDG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_nhom_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cauhoi");
            object[] a_ma_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "ma_cauhoi");
            object[] a_nd_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nd_cauhoi");
            object[] a_diem5 = bang.Fobj_COL_MANG(b_dt_ct, "diem5");
            object[] a_diem4 = bang.Fobj_COL_MANG(b_dt_ct, "diem4");
            object[] a_diem3 = bang.Fobj_COL_MANG(b_dt_ct, "diem3");
            object[] a_diem2 = bang.Fobj_COL_MANG(b_dt_ct, "diem2");
            object[] a_diem1 = bang.Fobj_COL_MANG(b_dt_ct, "diem1");
            object[] a_cauhoi_id = bang.Fobj_COL_MANG(b_dt_ct, "cauhoi_id");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cauhoi", 'S', a_nhom_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cauhoi", 'S', a_ma_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_cauhoi", 'U', a_nd_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem5", 'S', a_diem5);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem4", 'S', a_diem4);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem3", 'S', a_diem3);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem2", 'S', a_diem2);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem1", 'S', a_diem1);
            dbora.P_THEM_PAR(ref b_lenh, "a_cauhoi_id", 'S', a_cauhoi_id);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_N(b_dr["ngay_d"]) + "," +
                chuyen.OBJ_N(b_dr["ngay_c"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["hoten"]) + "," + chuyen.OBJ_N(b_dr["tong_diem5"]) + "," +
                chuyen.OBJ_N(b_dr["tong_diem4"]) + "," + chuyen.OBJ_N(b_dr["tong_diem3"]) + "," + chuyen.OBJ_N(b_dr["tong_diem2"]) + "," +
                chuyen.OBJ_N(b_dr["tong_diem1"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) +
                ",:a_stt,:a_nhom_cauhoi,:a_ma_cauhoi,:a_nd_cauhoi,:a_diem5,:a_diem4,:a_diem3,:a_diem2,:a_diem1,:a_cauhoi_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_NGV_NBDG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_NGV_NBDG_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PDG_NGV_NBDG_GUI");
    }
    public static void PDG_NGV_NBDG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_NGV_NBDG_XOA");
    }
    //lấy bộ câu hỏi theo kỳ
    public static DataSet Fds_DG_NGV_DS_CAUHOI_NBDG_LKE(string b_donvi, string b_ky_dg, string cdanh)
    {
        return dbora.Fds_LKE(new object[] { b_donvi, b_ky_dg, cdanh }, 2, "PDG_NGV_DS_CAUHOI_NBDG_LKE");
    }
    //lấy điểm nếu nhân viên đã dc đánh giá
    public static object[] Fds_DG_NGV_DS_DIEM_LKE(string b_donvi, string b_manv, string b_ky_dg, string cdanh)
    {
        return dbora.Faobj_LKE(new object[] { b_donvi, b_manv, b_ky_dg, cdanh }, "R", "PDG_NGV_DS_DIEM_LKE");
    }
    //lấy chức danh theo kỳ đánh giá
    public static DataTable Fdt_DG_NGV_CDANH(string b_cty, string b_ky_dg)
    {
        return dbora.Fdt_LKE_S(new string[] { b_cty, b_ky_dg }, "PDG_NGV_CDANH");
    }
    //lấy chức danh theo kỳ đánh giá
    public static DataTable Fdt_DG_NGV_CHUCDANH(string b_cty, string b_ky_dg)
    {
        return dbora.Fdt_LKE_S(new string[] { b_cty, b_ky_dg }, "PDG_NGV_CDANH_CTY");
    }
    //lấy thông tin cán bộ theo chức danh
    public static DataTable Fdt_DG_NGV_TTCB(string b_congty, string b_ky_dg, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_congty, b_ky_dg, b_cdanh }, "PDG_NGV_TTCB");
    }
    // Lấy các công ty mời chức danh đang đăng nhập vào đánh giá
    public static DataTable Fdt_MA_DVI_NBDG()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_NBDG");
    }
    // lấy kỳ đánh giá theo công ty mời đánh giá và năm
    public static DataTable Fdt_DG_DM_KDG_NBDG(string b_cty, string b_nam)
    {
        return dbora.Fdt_LKE_S(new string[] { b_cty, b_nam }, "PDG_DM_KDG_NBDG");
    }
    #endregion NỘI BỘ ĐÁNH GIÁ

    #region KHÁCH HÀNG ĐÁNH GIÁ
    public static DataSet Fds_DG_NGV_KHDG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_NGV_KHDG_CT");
    }
    public static object[] Faobj_DG_NGV_KHDG_LKE(string b_nam, string b_ky_dg, string b_hoten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ky_dg, "N'" + b_hoten, b_tu, b_den }, "NR", "PDG_NGV_KHDG_LKE");
    }
    public static object[] Faobj_DG_NGV_KHDG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_NGV_KHDG_MA");
    }
    public static void PDG_NGV_KHDG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_nhom_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cauhoi");
            object[] a_ma_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "ma_cauhoi");
            object[] a_nd_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "nd_cauhoi");
            object[] a_diem5 = bang.Fobj_COL_MANG(b_dt_ct, "diem5");
            object[] a_diem4 = bang.Fobj_COL_MANG(b_dt_ct, "diem4");
            object[] a_diem3 = bang.Fobj_COL_MANG(b_dt_ct, "diem3");
            object[] a_diem2 = bang.Fobj_COL_MANG(b_dt_ct, "diem2");
            object[] a_diem1 = bang.Fobj_COL_MANG(b_dt_ct, "diem1");
            object[] a_cauhoi_id = bang.Fobj_COL_MANG(b_dt_ct, "cauhoi_id");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cauhoi", 'S', a_nhom_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cauhoi", 'S', a_ma_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_cauhoi", 'U', a_nd_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem5", 'S', a_diem5);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem4", 'S', a_diem4);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem3", 'S', a_diem3);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem2", 'S', a_diem2);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem1", 'S', a_diem1);
            dbora.P_THEM_PAR(ref b_lenh, "a_cauhoi_id", 'S', a_cauhoi_id);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_N(b_dr["ngay_d"]) + "," +
                chuyen.OBJ_N(b_dr["ngay_c"]) + "," + chuyen.OBJ_C(b_dr["ho_ten"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ma_kh"]) + "," +
                chuyen.OBJ_C(b_dr["ten_kh"]) + "," + chuyen.OBJ_C(b_dr["ttin_kh"]) + "," + chuyen.OBJ_N(b_dr["tong_diem5"]) + "," +
                chuyen.OBJ_N(b_dr["tong_diem4"]) + "," + chuyen.OBJ_N(b_dr["tong_diem3"]) + "," + chuyen.OBJ_N(b_dr["tong_diem2"]) + "," +
                chuyen.OBJ_N(b_dr["tong_diem1"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) +
                ",:a_stt,:a_nhom_cauhoi,:a_ma_cauhoi,:a_nd_cauhoi,:a_diem5,:a_diem4,:a_diem3,:a_diem2,:a_diem1,:a_cauhoi_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_NGV_KHDG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDG_NGV_KHDG_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PDG_NGV_KHDG_GUI");
    }
    public static void PDG_NGV_KHDG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDG_NGV_KHDG_XOA");
    }
    //lấy bộ câu hỏi theo kỳ đánh giá 
    public static DataSet Fds_DG_NGV_DS_CAUHOI_KHDG_LKE(string b_ky_dg, string b_cdanh)
    {
        return dbora.Fds_LKE(new object[] { b_ky_dg, b_cdanh }, 2, "PDG_NGV_DS_CAUHOI_KHDG_LKE");
    }
    //lấy điểm nếu nhân viên đã dc khách hàng đánh giá
    public static object[] Fds_DG_NGV_KHDG_DIEM_LKE(string b_manv, string b_makh, string b_ky_dg, string b_cdanh)
    {
        return dbora.Faobj_LKE(new object[] { b_manv, b_makh, b_ky_dg, b_cdanh }, "R", "PDG_NGV_KHDG_DIEM_LKE");
    }
    //lấy thông tin cán bộ theo kỳ đánh giá
    public static DataTable Fdt_DG_NGV_KHDG_TTCB(string b_ky_dg)
    {
        return dbora.Fdt_LKE_S(b_ky_dg, "PDG_NGV_KHDG_TTCB");
    }
    //lấy chức danh theo nhân viên
    public static DataTable Fdt_DG_NGV_KHDG_CDANH(string b_ma_nv)
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PDG_NGV_KHDG_CDANH");
    }
    #endregion KHÁCH HÀNG ĐÁNH GIÁ

    #region QUẢN LÝ XEM XÉT CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG
    public static DataSet Fds_CBQL_CTCV_HT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PDG_NGV_CTCV_HT_CT");  //PCBQL_CTCV_HT_CT
    }
    public static object[] Faobj_CBQL_CTCV_HT_LKE(string b_trangthai, double b_nam, string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_nam, b_ky_dg, b_tu, b_den }, "NR", "PCBQL_CTCV_HT_LKE");
    }
    public static object[] Faobj_CBQL_CTCV_HT_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PCBQL_CTCV_HT_MA");
    }
    public static void PCBQL_CTCV_HT_GUI(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PCBQL_CTCV_HT_GUI");
    }
    public static void PCBQL_CTCV_HT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PCBQL_CTCV_HT_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO1(string b_ma_nv)
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PNS_TTIN_CANBO");
    }
    #endregion QUẢN LÝ XEM XÉT CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG

    #region KẾT QUẢ ĐÁNH GIÁ CỦA CÔNG TY
    public static DataSet Fds_KQ_DG_CTY_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 1, "PKQ_DG_CTY_CT");  //PKQ_DG_CTY_CT
    }
    public static object[] Faobj_KQ_DG_CTY_LKE(string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ky_dg, b_tu, b_den }, "NR", "PKQ_DG_CTY_LKE");
    }
    public static object[] Faobj_KQ_DG_CTY_LKE_GRCT(string b_ky_dg, string b_soid, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ky_dg, b_soid, b_tu, b_den }, "NR", "PKQ_DG_CTY_LKE_GRCT");
    }
    public static object[] Faobj_KQ_DG_CTY_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PKQ_DG_CTY_MA");
    }
    public static void PKQ_DG_CTY_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        { // congty,ban_phong,phong_bophan,xeploai_danhgia,so_idct
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_congty = bang.Fobj_COL_MANG(b_dt_ct, "congty");
            object[] a_ban_phong = bang.Fobj_COL_MANG(b_dt_ct, "ban_phong");
            object[] a_phong_bophan = bang.Fobj_COL_MANG(b_dt_ct, "phong_bophan");
            object[] a_xeploai_danhgia = bang.Fobj_COL_MANG(b_dt_ct, "xeploai_danhgia");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_congty", 'U', a_congty);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban_phong", 'U', a_ban_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong_bophan", 'U', a_phong_bophan);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_danhgia", 'S', a_xeploai_danhgia);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["loai_dg"]) +
                ",:a_congty,:a_ban_phong,:a_phong_bophan,:a_xeploai_danhgia";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PKQ_DG_CTY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    } 
    public static void PKQ_DG_CTY_GUI(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PKQ_DG_CTY_GUI");
    }
    public static void PKQ_DG_CTY_XOA(string b_so_id, string b_nam, string b_ky_dg)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_nam, b_ky_dg }, "PKQ_DG_CTY_XOA");
    }
    //lấy kỳ đánh giá full
    public static DataTable Fdt_DG_DM_DTDG_KDG()
    {
        return dbora.Fdt_LKE("PDG_DM_DTDG_KDG");
    }
    // Lấy kỳ đánh giá full (kỳ đánh giá lấy từ phân hệ đánh giá)
    public static DataTable Fdt_DG_DM_DTDG_KDG_DG()
    {
        return dbora.Fdt_LKE("PDG_DM_DTDG_KDG_DG");
    }
    // Lấy xếp loại đánh giá 
    public static object[] Fdt_NS_TL_XL_DG(string b_loai_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_loai_dg, b_tu, b_den }, "NR", "PNS_TL_XL_DG_DR");
    }
    #endregion KẾT QUẢ ĐÁNH GIÁ CỦA CÔNG TY

    #region QUẢN LÝ ĐÁNH GIÁ CÔNG VIỆC HÀNG THÁNG CỦA NHÂN VIÊN
    public static DataSet Fds_QL_DG_CV_HT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PQL_DG_CV_HT_CT");  //PQL_DG_CV_HT_CT
    }
    public static object[] Faobj_QL_DG_CV_HT_LKE(string b_trangthai, double b_nam, string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_nam, b_ky_dg, b_tu, b_den }, "NR", "PQL_DG_CV_HT_LKE");
    }
    public static object[] Faobj_QL_DG_CV_HT_LKE_ALL(string b_trangthai, string b_nam, string b_ky_dg)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_nam, b_ky_dg }, "R", "PQL_DG_CV_HT_LKE_ALL");
    }
    public static object[] Faobj_QL_DG_CV_HT_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PQL_DG_CV_HT_MA");
    }
    public static void PQL_DG_CV_HT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_nd_congviec = bang.Fobj_COL_MANG(b_dt_ct, "nd_congviec");
            object[] a_trongso = bang.Fobj_COL_MANG(b_dt_ct, "trongso");
            object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d");
            object[] a_ngay_ht = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ht");

            object[] a_diengiai_kqth = bang.Fobj_COL_MANG(b_dt_ct, "diengiai_kqth");
            object[] a_ketqua = bang.Fobj_COL_MANG(b_dt_ct, "ketqua");
            object[] a_tyle_ht_nv = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_nv");
            object[] a_tyle_ht_tso_nv = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_tso_nv");
            object[] a_kkhan_gphap_dxuat = bang.Fobj_COL_MANG(b_dt_ct, "kkhan_gphap_dxuat");
            object[] a_ykien_kq_th = bang.Fobj_COL_MANG(b_dt_ct, "ykien_kq_th");
            object[] a_tyle_ht_ql = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_ql");
            object[] a_tyle_ht_tso_ql = bang.Fobj_COL_MANG(b_dt_ct, "tyle_ht_tso_ql");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");


            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_congviec", 'U', a_nd_congviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_trongso", 'S', a_trongso);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ht", 'N', a_ngay_ht);

            dbora.P_THEM_PAR(ref b_lenh, "a_diengiai_kqth", 'U', a_diengiai_kqth);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua", 'U', a_ketqua);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_nv", 'S', a_tyle_ht_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_tso_nv", 'S', a_tyle_ht_tso_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_kkhan_gphap_dxuat", 'U', a_kkhan_gphap_dxuat);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien_kq_th", 'U', a_ykien_kq_th);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_ql", 'S', a_tyle_ht_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_ht_tso_ql", 'S', a_tyle_ht_tso_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," +
                chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ketqua_tong"]) + "," + chuyen.OBJ_C(b_dr["xeploai"]) + "," + chuyen.OBJ_C(b_dr["heso"])
                + "," + chuyen.OBJ_C(b_dr["kq_ht"]) + "," + chuyen.OBJ_C(b_dr["kqchung"]) + "," + chuyen.OBJ_C(b_dr["xeploai_danhgia"]) + "," + chuyen.OBJ_C(b_dr["heso_danhgia"])
                + "," + chuyen.OBJ_C(b_dr["trangthai"]) + ",:a_stt,:a_nd_congviec,:a_trongso,:a_ngay_d,:a_ngay_ht,:a_diengiai_kqth,:a_ketqua,:a_tyle_ht_nv,:a_tyle_ht_tso_nv,:a_kkhan_gphap_dxuat,:a_ykien_kq_th,:a_tyle_ht_ql,:a_tyle_ht_tso_ql,:a_gchu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PQL_DG_CV_HT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PQL_DG_CV_HT_XACNHAN(string b_so_id, string b_xacnhan)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_xacnhan }, "PQL_DG_CV_HT_XACNHAN");
    }
    public static void PQL_DG_CV_HT_XOA(string b_so_id, string b_nam, string b_kydg, string b_manv)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_nam, b_kydg, b_manv }, "PQL_DG_CV_HT_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO111(string b_ma_nv)
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PNS_TTIN_CANBO");
    }
    public static DataTable PQL_DG_CV_HT_LAY_HESO_XEPLOAI(string b_loai_dg)
    {
        return dbora.Fdt_LKE_S(b_loai_dg, "PQL_DG_CV_HT_LAY_HESO_XEPLOAI");
    }
    #endregion QUẢN LÝ ĐÁNH GIÁ CÔNG VIỆC HÀNG THÁNG CỦA NHÂN VIÊN

    #region CBNV NHẬP CHỈ TIÊU GIAO KPI
    public static DataTable Fdt_NS_DG_CBNV_KPI_CT_BY_MA(string b_trangthai, string b_ky_dg, string b_ma_nsd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_trangthai, b_ky_dg, b_ma_nsd }, "PNS_DG_CBNV_KPI_CT_BY_MA");
    }
    public static DataSet Faobj_NS_DG_CBNV_KPI_BY_TLAP(string b_nam, string b_ky_dg, string b_ma_nsd)
    {
        return dbora.Fds_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ky_dg, b_ma_nsd }, 2, "PNS_DG_CBNV_KPI_BY_TLAP");
    }
    public static DataSet Fds_CBNV_CT_KPI_CT(string b_so_id, string b_ma_nsd, double b_nam, string b_kydg)
    {
        return dbora.Fds_LKE(new object[] { b_so_id, b_ma_nsd, b_nam, b_kydg }, 3, "PNS_DG_CBNV_CT_KPI_CT");  //PCBNV_CT_KPI_CT
    }
    public static object[] Faobj_CBNV_CT_KPI_LKE(string b_ma_nsd, string b_trangthai, string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nsd, b_trangthai, b_ky_dg, b_tu, b_den }, "NR", "PNS_DG_CBNV_CT_KPI_LKE");
    }
    public static object[] Faobj_CBNV_CT_KPI_MA(string b_so_id, string b_ky_dg, string b_trangthai, string b_ma_nsd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_ky_dg, b_trangthai, b_ma_nsd, b_trangkt }, "NNR", "PNS_DG_CBNV_CT_KPI_MA");
    }
    public static void PCBNV_CT_KPI_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_ct1)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_nhom_tc = bang.Fobj_COL_MANG(b_dt_ct, "nhom_tc");
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "tieuchi");
            object[] a_donvitinh = bang.Fobj_COL_MANG(b_dt_ct, "donvitinh");
            object[] a_khongdat = bang.Fobj_COL_MANG(b_dt_ct, "khongdat");
            object[] a_cancaitien = bang.Fobj_COL_MANG(b_dt_ct, "cancaitien");
            object[] a_dat = bang.Fobj_COL_MANG(b_dt_ct, "dat");
            object[] a_tot = bang.Fobj_COL_MANG(b_dt_ct, "tot");
            object[] a_xuatsac = bang.Fobj_COL_MANG(b_dt_ct, "xuatsac");
            object[] a_titrong_ct = bang.Fobj_COL_MANG(b_dt_ct, "titrong");

            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct1, "mota");
            object[] a_titrong = bang.Fobj_COL_MANG(b_dt_ct1, "titrong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_tc", 'S', a_nhom_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'U', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvitinh", 'S', a_donvitinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_khongdat", 'S', a_khongdat);
            dbora.P_THEM_PAR(ref b_lenh, "a_cancaitien", 'S', a_cancaitien);
            dbora.P_THEM_PAR(ref b_lenh, "a_dat", 'S', a_dat);
            dbora.P_THEM_PAR(ref b_lenh, "a_tot", 'S', a_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_xuatsac", 'S', a_xuatsac);
            dbora.P_THEM_PAR(ref b_lenh, "a_titrong_ct", 'S', a_titrong_ct);

            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_titrong", 'S', a_titrong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," +
                chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["ghichu"])
                + ",:a_nhom_tc,:a_tieuchi,:a_donvitinh,:a_khongdat,:a_cancaitien,:a_dat,:a_tot,:a_xuatsac,:a_titrong_ct,:a_mota,:a_titrong";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_CBNV_CT_KPI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PCBNV_CT_KPI_GUI(string b_so_id/*, string b_trangthai*/)
    {
        dbora.P_GOIHAM(new object[] { b_so_id/*, b_trangthai */}, "PNS_DG_CBNV_CT_KPI_GUI");
    }
    public static void PCBNV_CT_KPI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DG_CBNV_CT_KPI_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO11(string b_ma_nv)  //Son: Xem lai ?
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PNS_TTIN_CANBO");
    }
    #endregion CBNV NHẬP CHỈ TIÊU GIAO KPI

    #region QUẢN LÝ XEM XÉT CHỈ TIÊU GIAO KPIS
    public static DataSet Fds_NS_DG_QLXX_CT_KPI_CT(string b_so_id, string b_ma_nsd, double b_nam, string b_kydg)
    {
        return dbora.Fds_LKE(new object[] { b_so_id, b_ma_nsd, b_nam, b_kydg }, 3, "PNS_DG_CBNV_CT_KPI_CT");
    }
    public static object[] Faobj_NS_DG_QLXX_CT_KPI_LKE(string b_trangthai, string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_ky_dg, b_tu, b_den }, "NR", "PNS_DG_QLXX_CT_KPI_LKE");
    }
    public static object[] Faobj_NS_DG_QLXX_CT_KPI_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DG_QLXX_CT_KPI_MA");
    }
    public static void PNS_DG_QLXX_CT_KPI_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_ct1)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_nhom_tc = bang.Fobj_COL_MANG(b_dt_ct, "nhom_tc");
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "tieuchi");
            object[] a_donvitinh = bang.Fobj_COL_MANG(b_dt_ct, "donvitinh");
            object[] a_khongdat = bang.Fobj_COL_MANG(b_dt_ct, "khongdat");
            object[] a_cancaitien = bang.Fobj_COL_MANG(b_dt_ct, "cancaitien");
            object[] a_dat = bang.Fobj_COL_MANG(b_dt_ct, "dat");
            object[] a_tot = bang.Fobj_COL_MANG(b_dt_ct, "tot");
            object[] a_xuatsac = bang.Fobj_COL_MANG(b_dt_ct, "xuatsac");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct1, "mota");
            object[] a_titrong = bang.Fobj_COL_MANG(b_dt_ct1, "titrong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_tc", 'S', a_nhom_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'S', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvitinh", 'S', a_donvitinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_khongdat", 'S', a_khongdat);
            dbora.P_THEM_PAR(ref b_lenh, "a_cancaitien", 'S', a_cancaitien);
            dbora.P_THEM_PAR(ref b_lenh, "a_dat", 'S', a_dat);
            dbora.P_THEM_PAR(ref b_lenh, "a_tot", 'S', a_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_xuatsac", 'S', a_xuatsac);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_titrong", 'S', a_titrong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," +
                chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["ghichu"])
                + ",:a_nhom_tc" + ",:a_donvitinh" + ",:a_khongdat" + ",:a_cancaitien" + ",:a_dat" + ",:a_tot" + ",:a_xuatsac" + ",:a_mota" + ",:a_titrong";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_NS_DG_QLXX_CT_KPI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_DG_QLXX_CT_KPI_GUI(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PNS_DG_QLXX_CT_KPI_GUI");
    }
    public static void PNS_DG_QLXX_CT_KPI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DG_NS_QLXX_CT_KPI_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO110(string b_ma_nv)  //Son: Xem lai ?
    {
        return dbora.Fdt_LKE_S(b_ma_nv, "PNS_TTIN_CANBO");
    }
    #endregion QUẢN LÝ XEM XÉT CHỈ TIÊU GIAO KPIS

    #region ĐÁNH GIÁ BỘ PHẬN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_DG_NGV_BOPHAN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_NVU_BOPHAN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_DG_NGV_BOPHAN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_NVU_BOPHAN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_DG_NGV_BOPHAN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ky_dgia"], b_dr["bophan"], b_dr["kqua"], b_dr["gchu"] }, "PNS_DG_NVU_BOPHAN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_DG_NGV_BOPHAN_XOA(string b_ma, string b_bophan)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_bophan }, "PNS_DG_NVU_BOPHAN_XOA");
    }
    public static DataTable Fdt_KETQUA_CHUNG_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE2");
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region GIAO KPI
    public static DataTable Fdt_NS_DG_GIAO_KPI_LKE(double b_tu_n, double b_den_n)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("ngay", typeof(string));
        table.Columns.Add("SO_ID", typeof(double));
        table.Rows.Add("01/02/2017", 10001);
        table.Rows.Add("01/05/2017", 10002);

        return table;
    }

    public static DataTable Fdt_NS_DG_GIAO_KPI_CT(string b_so_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("gtrid", typeof(string));
        table.Columns.Add("gtric", typeof(string));
        table.Columns.Add("thuocdo", typeof(string));
        table.Columns.Add("trongso", typeof(string));
        table.Rows.Add("Công việc 1", "Kế hoạch 1", "10", "100");
        table.Rows.Add("Công việc 2", "Kế hoạch 2", "10", "90");
        table.Rows.Add("Công việc 3", "Kế hoạch 3", "10", "60");


        return table;
    }

    public static DataTable Fdt_NS_DG_GIAO_KPI_CBO_CB_LKE(double b_tu_n, double b_den_n)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("ngay", typeof(string));
        table.Columns.Add("SO_ID", typeof(double));
        table.Rows.Add("01/02/2017", 10001);
        table.Rows.Add("01/05/2017", 10002);

        return table;
    }

    public static DataTable Fs_NS_DG_GIAO_KPI_CHO_CB_CT(string b_so_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("SO_THE", typeof(string));
        table.Columns.Add("TEN", typeof(string));
        table.Columns.Add("LUONG_TG", typeof(string));
        table.Columns.Add("LUONG_SP", typeof(string));
        table.Columns.Add("LUONG_KHOAN", typeof(string));
        table.Columns.Add("ANCA", typeof(string));
        table.Columns.Add("PCAP", typeof(string));
        table.Columns.Add("TNHAP_CHIUTHUE", typeof(string));
        table.Columns.Add("TNHAP_KCHIUTHUE", typeof(string));
        table.Columns.Add("BHXH", typeof(string));
        table.Columns.Add("BHYT", typeof(string));
        table.Columns.Add("BHTN", typeof(string));
        table.Columns.Add("PCD", typeof(string));
        table.Columns.Add("KTRU_CHIUTHUE", typeof(string));
        table.Columns.Add("KTRU_KCHIUTHUE", typeof(string));
        table.Columns.Add("TRUTHUE", typeof(string));
        table.Columns.Add("TAM_UNG", typeof(string));
        table.Rows.Add("Công việc 1", "Kế hoạch 1", "10", "100", "Giờ", "3", "4", "2", "5", "1", "3.5", "10", "5", "4", "3", "5");
        table.Rows.Add("Công việc 2", "Kế hoạch 2", "10", "90", "Giờ", "3", "4", "2", "5", "1", "3.5", "10", "5", "4", "3", "5");
        table.Rows.Add("Công việc 3", "Kế hoạch 3", "10", "60", "Giờ", "3", "4", "2", "5", "1", "3.5", "10", "5", "4", "3", "5");


        return table;
    }
    #endregion

    #region TIÊU CHÍ ĐÁNH GIÁ CẤP NHÂN VIÊN THEO KỲ ĐÁNH GIÁ

    public static DataTable Fdt_NS_DG_TC_CNV_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DG_TC_CNV_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DG_TC_CNV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_TC_CNV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DG_TC_CNV_MA(double b_nam, string b_ma_kdg, string b_ma_plnv, string b_ma_capnv, double b_ngay_adung, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ngay_adung, b_trangkt }, "NNR", "PNS_DG_TC_CNV_MA");
    }
    public static DataSet Fds_NS_DG_TC_CNV_CT(double b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id }, 3, "PNS_DG_TC_CNV_CT");
        return b_ds;
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DG_TC_CNV_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
            object[] a_so_id_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ma_nhom_tc = bang.Fobj_COL_MANG(b_dt_ct, "ma_nhom_tc");
            object[] a_tso_nhom = bang.Fobj_COL_MANG(b_dt_ct, "tso_nhom");
            object[] a_ma_tc = bang.Fobj_COL_MANG(b_dt_ct, "ma_tc");
            object[] a_tso_tc = bang.Fobj_COL_MANG(b_dt_ct, "tso_tc");
            object[] a_dmuc_l1 = bang.Fobj_COL_MANG(b_dt_ct, "dmuc_l1");
            object[] a_dmuc_l2 = bang.Fobj_COL_MANG(b_dt_ct, "dmuc_l2");
            object[] a_luyke_kysau = bang.Fobj_COL_MANG(b_dt_ct, "luyke_kysau");
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ct", 'N', a_so_id_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nhom_tc", 'S', a_ma_nhom_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tso_nhom", 'N', a_tso_nhom);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tc", 'S', a_ma_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tso_tc", 'N', a_tso_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_dmuc_l1", 'N', a_dmuc_l1);
            dbora.P_THEM_PAR(ref b_lenh, "a_dmuc_l2", 'N', a_dmuc_l2);
            dbora.P_THEM_PAR(ref b_lenh, "a_luyke_kysau", 'S', a_luyke_kysau);
            string b_c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma_kdg"]) + "," + chuyen.OBJ_C(b_dr["ma_plnv"]) + ","
                + chuyen.OBJ_C(b_dr["ma_capnv"]) + "," + chuyen.OBJ_N(b_dr["ngay_adung"])
                + ",:a_so_id_ct,:a_ma_nhom_tc,:a_tso_nhom,:a_ma_tc,:a_tso_tc,:a_dmuc_l1,:a_dmuc_l2,:a_luyke_kysau";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_TC_CNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DG_TC_CNV_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_DG_TC_CNV_XOA");
    }

    #endregion TIÊU CHÍ ĐÁNH GIÁ CẤP NHÂN VIÊN THEO KỲ ĐÁNH GIÁ

    #region GÁN TIÊU CHÍ ĐÁNH GIÁ CHO CBNV

    public static DataTable Fdt_NS_DG_TC_CBNV_TIMNV(string b_phong, string b_cbnv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_cbnv }, "PNS_DG_TC_CBNV_TIMNV");
    }

    public static object[] Fdt_NS_DG_TC_CBNV_CT(double b_nam, string b_ma_kdg, string b_so_the, string b_ma_plnv, string b_ma_capnv)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv }, "NR", "PNS_DG_TC_CBNV_CT");
    }

    public static void P_NS_DG_TC_CBNV_NH(double b_nam, string b_ma_kdg, string b_so_the, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ma_nhom_tc = bang.Fobj_COL_MANG(b_dt_ct, "ma_nhom_tc");
            object[] a_tso_nhom = bang.Fobj_COL_MANG(b_dt_ct, "tso_nhom");
            object[] a_ma_tc = bang.Fobj_COL_MANG(b_dt_ct, "ma_tc");
            object[] a_tso_tc = bang.Fobj_COL_MANG(b_dt_ct, "tso_tc");
            object[] a_dmuc_l1 = bang.Fobj_COL_MANG(b_dt_ct, "dmuc_l1");
            object[] a_dmuc_l2 = bang.Fobj_COL_MANG(b_dt_ct, "dmuc_l2");
            object[] a_luyke_kysau = bang.Fobj_COL_MANG(b_dt_ct, "luyke_kysau");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nhom_tc", 'S', a_ma_nhom_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tso_nhom", 'N', a_tso_nhom);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tc", 'S', a_ma_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tso_tc", 'N', a_tso_tc);
            dbora.P_THEM_PAR(ref b_lenh, "a_dmuc_l1", 'N', a_dmuc_l1);
            dbora.P_THEM_PAR(ref b_lenh, "a_dmuc_l2", 'N', a_dmuc_l2);
            dbora.P_THEM_PAR(ref b_lenh, "a_luyke_kysau", 'S', a_luyke_kysau);
            string b_c = "," + chuyen.OBJ_N(b_nam) + "," + chuyen.OBJ_C(b_ma_kdg) + "," + chuyen.OBJ_C(b_so_the)
                + ",:a_so_id,:a_ma_nhom_tc,:a_tso_nhom,:a_ma_tc,:a_tso_tc,:a_dmuc_l1,:a_dmuc_l2,:a_luyke_kysau";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_TC_CBNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }

    #endregion GÁN TIÊU CHÍ ĐÁNH GIÁ CHO CBNV

    #region THIẾT LẬP CÔNG THỨC ĐÁNH GIÁ

    public static DataTable Fdt_NS_DG_CT_CT(double b_nam, string b_ma_kdg, string b_ma_plnv, string b_ma_capnv, string b_ma_ct)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ma_ct }, "PNS_DG_CT_CT");
    }

    public static void P_NS_DG_CT_NH(ref double b_so_id, string b_ma_ct, string b_congthuc, string b_field1, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            DataRow b_dr = b_dt.Rows[0];
            string b_c = ",:b_so_id," + +chuyen.OBJ_N(b_dr["NAM_DR"]) + "," + chuyen.OBJ_C(b_dr["MA_KDG_DR"]) + ","
                + chuyen.OBJ_C(b_dr["MA_PLNV_DR"]) + "," + chuyen.OBJ_C(b_dr["ma_cap_nv_dr"]) + "," + chuyen.OBJ_C(b_ma_ct) + "," + chuyen.OBJ_C(b_congthuc) + "," + chuyen.OBJ_C(b_field1);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_CT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_DG_CT_KT(string b_congthuc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_congthuc }, "PNS_DG_CT_KT");
    }

    #endregion THIẾT LẬP CÔNG THỨC ĐÁNH GIÁ

    #region THIẾT LẬP ĐỐI TƯỢNG ĐÁNH GIÁ
    public static object[] Faobj_DG_DM_TLAP_DTUONG_DGIA_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDG_DM_TLAP_DTUONG_DGIA_MA");
    }
    public static DataSet Fds_DG_DM_TLAP_DTUONG_DGIA_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 7, "PDG_DM_TLAP_DTUONG_DGIA_CT");
    }
    public static object[] Faobj_DG_DM_TLAP_DTUONG_DGIA_LKE(double b_tu_n, double b_den_n, string b_n_cdanh, string b_cdanh)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_n_cdanh, b_cdanh }, "NR", "PDG_DM_TLAP_DTUONG_DGIA_LKE");
    }
    public static void P_DG_DM_TLAP_DTUONG_DGIA_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_ct_cd, DataTable b_dt_ct_nc,
                                                  DataTable b_dt_ct_cdanh_nc, DataTable b_dt_ct_cdanh_ct, DataTable b_dt_ct_cdanh_cd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            if (b_dt_ct.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "" }); }
            if (b_dt_ct_cd.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_ct_cd, new object[] { "", "" }); }
            if (b_dt_ct_nc.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_ct_nc, new object[] { "", "" }); }

            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_sothe_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_the_ct");
            object[] a_ten_qlct = bang.Fobj_COL_MANG(b_dt_ct, "ten_ct");

            object[] a_sothe_cd = bang.Fobj_COL_MANG(b_dt_ct_cd, "so_the_cd");
            object[] a_ten_qlcd = bang.Fobj_COL_MANG(b_dt_ct_cd, "ten_cd");

            object[] a_sothe_nc = bang.Fobj_COL_MANG(b_dt_ct_nc, "so_the_nc");
            object[] a_ten_qlnc = bang.Fobj_COL_MANG(b_dt_ct_nc, "ten_nc");

            object[] a_cdanh_nc = bang.Fobj_COL_MANG(b_dt_ct_cdanh_nc, "ma_cd_nc");
            object[] a_ten_cdanh_nc = bang.Fobj_COL_MANG(b_dt_ct_cdanh_nc, "ten_cd_nc");

            object[] a_cdanh_ct = bang.Fobj_COL_MANG(b_dt_ct_cdanh_ct, "ma_cd_ct");
            object[] a_ten_cdanh_ct = bang.Fobj_COL_MANG(b_dt_ct_cdanh_ct, "ten_cd_ct");

            object[] a_cdanh_cd = bang.Fobj_COL_MANG(b_dt_ct_cdanh_cd, "ma_cd_cd");
            object[] a_ten_cdanh_cd = bang.Fobj_COL_MANG(b_dt_ct_cdanh_cd, "ten_cd_cd");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'S', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_ct", 'S', a_sothe_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_qlct", 'U', a_ten_qlct);

            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_cd", 'S', a_sothe_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_qlcd", 'U', a_ten_qlcd);

            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_nc", 'S', a_sothe_nc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_qlnc", 'U', a_ten_qlnc);

            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_nc", 'S', a_cdanh_nc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh_nc", 'U', a_ten_cdanh_nc);

            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_ct", 'S', a_cdanh_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh_ct", 'U', a_ten_cdanh_ct);

            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_cd", 'S', a_cdanh_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh_cd", 'U', a_ten_cdanh_cd);

            string b_c = ",:b_so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + ","
            + chuyen.OBJ_C(b_dr["nhom_cdanh"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) 
            + ",:a_sothe_ct,:a_ten_qlct,:a_sothe_cd,:a_ten_qlcd,:a_sothe_nc,:a_ten_qlnc,:a_cdanh_nc,:a_ten_cdanh_nc,:a_cdanh_ct,:a_ten_cdanh_ct,:a_cdanh_cd,:a_ten_cdanh_cd";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_DM_TLAP_DTUONG_DGIA_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_DG_DM_TLAP_DTUONG_DGIA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PDG_DM_TLAP_DTUONG_DGIA_XOA");
    }
    #endregion

    #region KẾT QUẢ ĐÁNH GIÁ SỦ DỤNG TÍNH LƯƠNG 
    /// dg_kq_dgia_thang
    public static object[] Fdt_Fs_DG_KQ_DGIA_THANG_LKE(string b_nam, string b_ky_dg, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ky_dg, b_phong, b_tu_n, b_den_n }, "NR", "DG_KQ_DGIA_THANG_LKE");
    }
    public static void P_Fs_DG_KQ_DGIA_THANG_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt_ct, "ho_ten");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_xeploai = bang.Fobj_COL_MANG(b_dt_ct, "xep_loai");
            object[] a_he_so = bang.Fobj_COL_MANG(b_dt_ct, "heso");
            object[] a_xac_nhan = bang.Fobj_COL_MANG(b_dt_ct, "xacnhan");
            object[] a_cttns = bang.Fobj_COL_MANG(b_dt_ct, "dl_cttns");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai", 'U', a_xeploai);
            dbora.P_THEM_PAR(ref b_lenh, "a_he_so", 'S', a_he_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_xac_nhan", 'S', a_xac_nhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_cttns", 'S', a_cttns);
            string b_c = "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["phongban"])
                + ",:a_so_the,:a_ho_ten,:a_cdanh,:a_phongban,:a_xeploai,:a_he_so,:a_xac_nhan,:a_cttns";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_KQ_DGIA_THANG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_Fs_DG_KQ_DGIA_THANG_NH_EXCEL(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt_ct, "ho_ten");
            object[] a_xeploai = bang.Fobj_COL_MANG(b_dt_ct, "xep_loai");
            object[] a_he_so = bang.Fobj_COL_MANG(b_dt_ct, "heso");
            object[] a_xac_nhan = bang.Fobj_COL_MANG(b_dt_ct, "xacnhan");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai", 'U', a_xeploai);
            dbora.P_THEM_PAR(ref b_lenh, "a_he_so", 'S', a_he_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_xac_nhan", 'S', a_xac_nhan);
            string b_c = "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) /*+ "," + chuyen.OBJ_C(b_dr["phongban"])*/
                + ",:a_so_the,:a_ho_ten,:a_xeploai,:a_he_so,:a_xac_nhan";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_KQ_DGIA_THANG_NH_EXCEL(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_Fs_DG_KQ_DGIA_THANG_TONGHOP(string b_nam, string b_ky_dg, string b_phong)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_nam), b_ky_dg, b_phong }, "PDG_KQ_DGIA_THANG_TONGHOP");
    }
    public static void P_Fs_DG_KQ_DGIA_THANG_XACNHAN(DataTable b_dt, DataTable b_dt_ct, string b_dk)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            string b_c = "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["phongban"]) + ",:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDG_KQ_DGIA_THANG_XN(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fds_Fs_DG_KQ_DGIA_THANG_EXCEL(string b_so_the, string b_ten, string b_phong)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_ten, b_phong }, 1, "PNS_DG_KQ_DGIA_THANG_EXCEL");
    }
    public static DataTable Fds_Fs_DG_KQ_DGIA_THANG_DS_CDG(string b_nam, string b_ky_dg, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_ky_dg, b_phong }, "PDG_KQ_DGIA_THANG_DS_CDG");
    }
    ///<summary>liet ke sau kiem tra </summary> 
    public static object[] Fdt_Fs_DG_KQ_DGIA_THANG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_DG_KQ_DGIA_THANG_MA");
    }
    #endregion

    #region ĐÁNH GIÁ CÔNG VIỆC THÁNG
    public static object[] Faobj_NS_DG_CV_THANG_MA(string b_so_id, string b_nam, string b_trangthai, string b_ma_nsd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_nam, b_trangthai, b_ma_nsd, b_trangkt }, "NNR", "PNS_DG_CV_THANG_MA");
    }
    public static DataSet Fds_NS_DG_CV_THANG_CT(string b_so_id, string b_nam, string b_kydg, string b_ma)
    {
        return dbora.Fds_LKE(new object[] { b_so_id, b_nam, b_kydg, b_ma }, 2, "PNS_DG_CV_THANG_CT");
    }
    public static object[] Faobj_NS_DG_CV_THANG_LKE(string b_nam, string b_trangthai, string b_ma_nsd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_trangthai, b_ma_nsd, b_tu_n, b_den_n }, "NR", "PNS_DG_CV_THANG_LKE");
    }
    public static void P_NS_DG_CV_THANG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_nd_cv = bang.Fobj_COL_MANG(b_dt_ct, "ndung_cv");
            object[] a_trong_so = bang.Fobj_COL_MANG(b_dt_ct, "trong_so");
            object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d");
            object[] a_ngay_dk = bang.Fobj_COL_MANG(b_dt_ct, "ngay_dk");
            object[] a_dien_giai = bang.Fobj_COL_MANG(b_dt_ct, "dien_giai");
            object[] a_ketqua = bang.Fobj_COL_MANG(b_dt_ct, "ketqua");
            object[] a_tl_hthanh = bang.Fobj_COL_MANG(b_dt_ct, "tl_hthanh");
            object[] a_tl_hthanh_ts = bang.Fobj_COL_MANG(b_dt_ct, "tl_hthanh_ts");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'S', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_nd_cv", 'U', a_nd_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_trong_so", 'S', a_trong_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_dk", 'N', a_ngay_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_dien_giai", 'U', a_dien_giai);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua", 'U', a_ketqua);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_hthanh", 'S', a_tl_hthanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_hthanh_ts", 'S', a_tl_hthanh_ts);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);
            string b_c = ",:b_so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + ","
                + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ketqua_tong"]) + ","
                + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["xeploai"]) + "," + chuyen.OBJ_C(b_dr["heso"])
                + ",:a_nd_cv,:a_trong_so,:a_ngay_d,:a_ngay_dk,:a_dien_giai,:a_ketqua,:a_tl_hthanh,:a_ti_le_trongso,:a_giai_phap";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DG_CV_THANG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_DG_CV_THANG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_CV_THANG_XOA");
    }
    public static void PDG_CV_THANG_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_DG_CV_THANG_GUI");
    }
    public static DataSet Fds_DG_CV_THANG_CT_LKE(string nam, string ky_dg)
    {
        return dbora.Fds_LKE(new object[] { nam, ky_dg }, 1, "PDG_CV_THANG_CT_LKE");
    }
    #endregion

    #region KẾT QUẢ ĐÁNH GIÁ KPI
    public static object[] Faobj_DG_NGV_KQUA_DG_KPI_LKE(string b_nam, string b_ky_dg, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ky_dg, b_phong, b_tu, b_den }, "NR", "dg_kq_dgia_thang_lke");
    }
    public static void Fdt_DG_NGV_KQUA_DG_KPI_P_XACNHAN(string b_so_id, string b_xacnhan)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_xacnhan }, "PNS_DG_NGV_KQUA_DG_KPI_P_XACNHAN");
    }
    #endregion

    #region ĐÁNH GIÁ KPIS
    public static DataSet Fds_DGIA_KPI_NV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "PDGIA_KPI_NV_CT");  //PDGIA_KPI_NV_CT
    }
    public static object[] Faobj_DGIA_KPI_NV_LKE(string b_nam, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_trangthai, b_tu, b_den }, "NR", "PDGIA_KPI_NV_LKE");
    }
    public static object[] Faobj_DGIA_KPI_NV_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PDGIA_KPI_NV_MA");
    }
    public static void PDGIA_KPI_NV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_nl_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "tieuchi");
            object[] a_dv_tinh = bang.Fobj_COL_MANG(b_dt_ct, "dv_tinh");
            object[] a_cac_chitieu_kd = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_kd");
            object[] a_cac_chitieu_ct = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_ct");
            object[] a_cac_chitieu_d = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_d");
            object[] a_cac_chitieu_t = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_t");
            object[] a_cac_chitieu_x = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_x");
            object[] a_trong_so = bang.Fobj_COL_MANG(b_dt_ct, "trong_so");
            object[] a_diem_dg = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg");
            object[] a_diem_dg_tt = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg_tt");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");

            object[] a_mota = bang.Fobj_COL_MANG(b_dt_nl_ct, "mota");
            object[] a_ti_trong = bang.Fobj_COL_MANG(b_dt_nl_ct, "ti_trong");
            object[] a_diem_dg_nl = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_nl");
            object[] a_diem_dg_s = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_s");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'U', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_dv_tinh", 'S', a_dv_tinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_kd", 'S', a_cac_chitieu_kd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_ct", 'S', a_cac_chitieu_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_d", 'S', a_cac_chitieu_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_t", 'S', a_cac_chitieu_t);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_x", 'S', a_cac_chitieu_x);
            dbora.P_THEM_PAR(ref b_lenh, "a_trong_so", 'S', a_trong_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg", 'S', a_diem_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_tt", 'S', a_diem_dg_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_ti_trong", 'S', a_ti_trong);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_nl", 'S', a_diem_dg_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_s", 'S', a_diem_dg_s);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["dot_dg"]) + "," +
                chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["diem_tb_kpi"]) + "," + chuyen.OBJ_C(b_dr["diem_tb_nl"]) + "," + chuyen.OBJ_C(b_dr["ketqua_xl"]) +
                "," + chuyen.OBJ_C(b_dr["ketqua_tn"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) +
                ",:a_tieuchi,:a_dv_tinh,:a_cac_chitieu_kd,:a_cac_chitieu_ct,:a_cac_chitieu_d,:a_cac_chitieu_t,:a_cac_chitieu_x,:a_trong_so,:a_diem_dg,:a_diem_dg_tt,:a_gchu" +
                ",:a_mota,:a_ti_trong,:a_diem_dg_nl,:a_diem_dg_s";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PDGIA_KPI_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PDGIA_KPI_NV_GUI(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PDGIA_KPI_NV_GUI");
    }
    public static void PDGIA_KPI_NV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PDGIA_KPI_NV_XOA");
    }
    public static DataSet Fds_DGIA_KPI_NV_QLXX_CT_KPI_LKE(string nam, string ky_dg)
    {
        return dbora.Fds_LKE(new object[] { nam, ky_dg }, 2, "PDGIA_KPI_NV_QLXX_CT_KPI_LKE");
    }
    #endregion

    #region QUẢN LÝ ĐÁNH GIÁ KPIS
    public static DataSet Fds_NS_CB_DGIA_KPI_NV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "PNS_CB_DGIA_KPI_NV_CT");  //PNS_CB_DGIA_KPI_NV_CT
    }
    public static object[] Faobj_NS_CB_DGIA_KPI_NV_LKE(string b_nam, string b_trangthai, string b_ky_dg, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_trangthai, b_ky_dg, b_tu, b_den }, "NR", "PNS_CB_DGIA_KPI_NV_LKE");
    }
    public static object[] Faobj_NS_CB_DGIA_KPI_NV_LKE_ALL(string b_nam, string b_trangthai, string b_ky_dg)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_trangthai, b_ky_dg }, "R", "PNS_CB_DGIA_KPI_NV_LKE_ALL");
    }
    public static object[] Faobj_NS_CB_DGIA_KPI_NV_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_CB_DGIA_KPI_NV_MA");
    }
    public static void PNS_CB_DGIA_KPI_NV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_nl_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ten_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "ten_tieuchi");
            object[] a_dv_tinh = bang.Fobj_COL_MANG(b_dt_ct, "dv_tinh");
            object[] a_cac_chitieu_kd = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_kd");
            object[] a_cac_chitieu_ct = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_ct");
            object[] a_cac_chitieu_d = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_d");
            object[] a_cac_chitieu_t = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_t");
            object[] a_cac_chitieu_x = bang.Fobj_COL_MANG(b_dt_ct, "cac_chitieu_x");
            object[] a_trong_so = bang.Fobj_COL_MANG(b_dt_ct, "trong_so");
            object[] a_diem_dg = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg");
            object[] a_diem_dg_tt = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg_tt");
            object[] a_diem_dg_ql = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg_ql");
            object[] a_diem_dg_tt_ql = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg_tt_ql");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_ct, "gchu");

            object[] a_mota = bang.Fobj_COL_MANG(b_dt_nl_ct, "mota");
            object[] a_ti_trong = bang.Fobj_COL_MANG(b_dt_nl_ct, "ti_trong");
            object[] a_diem_dg_nl = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_nl");
            object[] a_diem_dg_s = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_s");
            object[] a_diem_dg_ql_nl = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_ql");
            object[] a_diem_dg_s_ql = bang.Fobj_COL_MANG(b_dt_nl_ct, "diem_dg_s_ql");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ten_tieuchi", 'U', a_ten_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_dv_tinh", 'S', a_dv_tinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_kd", 'S', a_cac_chitieu_kd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_ct", 'S', a_cac_chitieu_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_d", 'S', a_cac_chitieu_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_t", 'S', a_cac_chitieu_t);
            dbora.P_THEM_PAR(ref b_lenh, "a_cac_chitieu_x", 'S', a_cac_chitieu_x);
            dbora.P_THEM_PAR(ref b_lenh, "a_trong_so", 'S', a_trong_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg", 'S', a_diem_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_tt", 'S', a_diem_dg_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_ql", 'S', a_diem_dg_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_tt_ql", 'S', a_diem_dg_tt_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_ti_trong", 'S', a_ti_trong);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_nl", 'S', a_diem_dg_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_s", 'S', a_diem_dg_s);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_ql_nl", 'S', a_diem_dg_ql_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg_s_ql", 'S', a_diem_dg_s_ql);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + "," + chuyen.OBJ_C(b_dr["dot_dg"]) + "," +
               chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["diem_tb_kpi_ql"]) + "," + chuyen.OBJ_C(b_dr["diem_tb_nl_ql"]) + "," + chuyen.OBJ_C(b_dr["ketqua_cb_dgia"]) +
               "," + chuyen.OBJ_C(b_dr["ketqua_tn"]) + "," + chuyen.OBJ_C(b_dr["xeploai"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["nd"]) +
               ",:a_ten_tieuchi,:a_dv_tinh,:a_cac_chitieu_kd,:a_cac_chitieu_ct,:a_cac_chitieu_d,:a_cac_chitieu_t,:a_cac_chitieu_x,:a_trong_so,:a_diem_dg,:a_diem_dg_tt,:a_diem_dg_ql,:a_diem_dg_tt_ql,:a_gchu" +
               ",:a_mota,:a_ti_trong,:a_diem_dg_nl,:a_diem_dg_s,:a_diem_dg_ql_nl,:a_diem_dg_s_ql";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_DGIA_KPI_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_CB_DGIA_KPI_NV_GUI(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PNS_CB_DGIA_KPI_NV_GUI");
    }
    public static void PNS_CB_DGIA_KPI_NV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_CB_DGIA_KPI_NV_XOA");
    }
    public static DataSet Fds_NS_CB_DGIA_KPI_NV_CT_LKE(string nam, string ky_dg)
    {
        return dbora.Fds_LKE(new object[] { nam, ky_dg }, 2, "PDGIA_KPI_NV_CT_LKE");
    }
    public static DataSet Faobj_NS_CB_DGIA_KPI_NV_PRINT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 5, "PNS_CB_DGIA_KPI_NV_PRINT");  //PNS_CB_DGIA_KPI_NV_CT
    }
    #endregion

    #region[KẾT QUẢ ĐÁNH GIÁ KPIs]
    public static object[] Fdt_DG_NGV_KQUA_DG_KPI_LKE(double b_tu_n, double b_den_n, string b_nam, string b_ky_dg, string b_phong)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ky_dg, b_phong, b_tu_n, b_den_n }, "NR", "DG_NGV_KQUA_DG_KPI_LKE");
    }
    public static void PNS_XACNHAN_KPI_NV_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ketqua_xl = bang.Fobj_COL_MANG(b_dt_ct, "ketqua_xl");
            object[] a_xeploai = bang.Fobj_COL_MANG(b_dt_ct, "xeploai");
            object[] a_heso = bang.Fobj_COL_MANG(b_dt_ct, "heso");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "trangthai");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua_xl", 'S', a_ketqua_xl);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai", 'S', a_xeploai);
            dbora.P_THEM_PAR(ref b_lenh, "a_heso", 'S', a_heso);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);

            string b_c = "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ky_dg"]) + ",:a_so_id,:a_so_the,:a_ketqua_xl,:a_xeploai,:a_heso,:a_trangthai";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_XACNHAN_KPI_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //Fdt_LKE
    public static DataTable DG_NGV_KQUA_DG_KPI_LKE_TTIN_CB()
    {
        return dbora.Fdt_LKE("DG_NGV_KQUA_DG_KPI_CB");
    }
    #endregion
}