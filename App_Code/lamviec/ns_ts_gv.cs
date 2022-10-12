using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
public class ns_ts_gv
{
    #region Giao viec
    public static void P_NS_TS_GV_NH(ref string b_so_id, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_id", 'N', 'O', chuyen.CSO_SO(b_so_id));
            string c = ",:b_id," + chuyen.OBJ_N(b_dr["id_ct"]);
            c = c + "," + chuyen.OBJ_C(b_dr["uu_tien"]) + "," + chuyen.OBJ_C(b_dr["nd"]) + "," + chuyen.OBJ_C(b_dr["mo_ta"]) + "," + chuyen.OBJ_N(b_dr["tong_gio"]) + "," + chuyen.OBJ_N(b_dr["tong_gio_lsx"]);
            c = c + "," + chuyen.OBJ_C(b_dr["ngay_dk_ht"]) + "," + chuyen.OBJ_C(b_dr["ma_du_an"]) + "," + chuyen.OBJ_C(b_dr["ma_wbs"]);
            c = c + "," + chuyen.OBJ_C(b_dr["nhom_viec"]) + "," + chuyen.OBJ_C(b_dr["ng_nhan"]) + "," + chuyen.OBJ_C(b_dr["skill"]) + "," + chuyen.OBJ_C(b_dr["vi_tri"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_gv_nh(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_TS_GV_XOA(string b_so_id)
    { // Dan
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "pns_ts_gv_xoa");
    }
    public static DataTable P_NS_TS_GV_EMAIL(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_GV_EMAIL");
    }
    public static DataTable P_NS_TS_GV_KT(string b_so_id)
    {
        DataRow b_dr = kenh.Fdr_TSO_KNOI("LOGIN");
        OracleConnection b_cnn = new OracleConnection();
        b_cnn.ConnectionString = chuyen.OBJ_S(b_dr["kn_s"]);
        b_cnn.Open();
        return dbora.Fdt_LKE("PNS_GV_KT");
    }
    public static DataTable Fdt_NS_TS_GV_LKE(DataTable b_dt, DataTable b_dt_se, double b_tu, double b_den, ref string b_dong)
    { 
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenhsl = new OracleCommand();
            b_lenhsl.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenhsl, "b_dong", 'N', 'O', chuyen.CSO_SO(b_dong));
            object[] a_id = bang.Fobj_COL_MANG(b_dt_se, "id");
            dbora.P_THEM_PAR(ref b_lenhsl, "a_id", 'S', a_id);
            dbora.P_THEM_PAR(ref b_lenhsl, "cs1", 'R');
            dbora.P_THEM_PAR(ref b_lenhsl, "cs2", 'R');
            string b_c = "," + chuyen.OBJ_C(b_dr["loai_tk"]) + "," + chuyen.OBJ_C(b_dr["hoan_thanh_tk"]) + "," +
            chuyen.OBJ_C(b_dr["tu_ngay_tk"]) + "," + chuyen.OBJ_C(b_dr["den_ngay_tk"]) + "," + chuyen.OBJ_C(b_dr["ng_nhan_tk"]) + "," + chuyen.OBJ_C(b_dr["ma_vv"]) + "," + b_tu + "," + b_den + "," + chuyen.OBJ_C(b_dr["duan"]) + ",:b_dong,:a_id,:cs1,:cs2";
            // b_lenhsl.CommandText = "Begin " + b_se.dbo + ".pns_ts_gv_lke(" + b_se.tso + b_c + "); end;";
            b_lenhsl.CommandText = "Begin " + b_se.dbo + ".pns_ts_gv_lke3(" + b_se.tso + b_c + "); end;";
            try
            {
                DataSet b_ds_kq = dbora.Fds_TRA(b_lenhsl);
                b_dong = chuyen.OBJ_S(b_lenhsl.Parameters["b_dong"].Value);
                System.Web.HttpContext.Current.Session["b_ds_kq_in"] = b_ds_kq.Tables[1];
                return b_ds_kq.Tables[0];
            }
            finally { b_lenhsl.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_NS_TS_GV_CT(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "pns_ts_gv_ct");
    }

    public static DataTable Fdt_NS_TS_BOOK_CT(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_TS_BOOK_CT");
    }

    public static void P_NS_TS_GV_TC(string b_so_id, DataTable b_dt)
    { // Dan
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id), chuyen.OBJ_S(b_dr["ly_do"]) }, "pns_ts_gv_tc");
    }
    public static void P_NS_TS_GV_BACK(string b_so_id)
    { // Dan
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "pns_ts_gv_back");
    }

    public static void P_NS_TS_GV_DC(string b_so_id_tu, string b_so_id_den)
    { // Dan
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id_tu), chuyen.CSO_SO(b_so_id_den), }, "pns_ts_gv_dc");
    }
    public static DataTable Faobj_NS_TS_GV_LKE_ID(string b_so_id, DataTable b_dt, DataTable b_dt_se, double b_TrangKt, ref string b_trang, ref string b_dong)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenhsl = new OracleCommand();
            b_lenhsl.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_id = bang.Fobj_COL_MANG(b_dt_se, "id");
            dbora.P_THEM_PAR(ref b_lenhsl, "a_id", 'S', a_id);
            dbora.P_THEM_PAR(ref b_lenhsl, "b_trang", 'N', 'O', chuyen.CSO_SO(b_trang));
            dbora.P_THEM_PAR(ref b_lenhsl, "b_dong", 'N', 'O', chuyen.CSO_SO(b_dong));
            dbora.P_THEM_PAR(ref b_lenhsl, "cs_lke", 'R');
            dbora.P_THEM_PAR(ref b_lenhsl, "cs_lke2", 'R');
            string b_c = "," + b_so_id + "," + chuyen.OBJ_C(b_dr["loai_tk"]) + "," + chuyen.OBJ_C(b_dr["hoan_thanh_tk"]) + "," +
            chuyen.OBJ_C(b_dr["tu_ngay_tk"]) + "," + chuyen.OBJ_C(b_dr["den_ngay_tk"]) + "," + chuyen.OBJ_C(b_dr["ng_nhan_tk"]) + "," + b_TrangKt + ",:a_id,:b_trang,:b_dong,:cs_lke,:cs_lke2";
            b_lenhsl.CommandText = "Begin " + b_se.dbo + ".pns_ts_gv_lke_id(" + b_se.tso + b_c + "); end;";
            try
            {
                DataSet b_ds_kq = dbora.Fds_TRA(b_lenhsl);
                System.Web.HttpContext.Current.Session["b_ds_kq_in"] = b_ds_kq.Tables[1];
                b_dong = chuyen.OBJ_S(b_lenhsl.Parameters["b_dong"].Value);
                b_trang = chuyen.OBJ_S(b_lenhsl.Parameters["b_trang"].Value);
                return b_ds_kq.Tables[0];
            }
            finally { b_lenhsl.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TS_TT_NH(string b_so_id, string b_trang_thai)
    { // Dan
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id), b_trang_thai }, "pns_ts_gv_tt_nh");
    }
    public static DataTable P_NS_TS_TT_CV(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_so_id) }, "pns_ts_gv_tt_cv");
    }
    public static object[] Fdt_NS_TS_QL_LKE(DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["tu_ngay_tk"]), chuyen.OBJ_N(b_dr["den_ngay_tk"]), chuyen.OBJ_S(b_dr["ng_nhan_tk"]), chuyen.OBJ_S(b_dr["phong"]), b_tu, b_den }, "NR", "pns_ts_gv_ql_lke");
    }
    public static object[] Fdt_NS_TS_QL_LKE_EXCEL(DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["tu_ngay_tk"]), chuyen.OBJ_N(b_dr["den_ngay_tk"]), chuyen.OBJ_S(b_dr["ng_nhan_tk"]), chuyen.OBJ_S(b_dr["phong"]), b_tu, b_den }, "NR", "pns_ts_gv_ql_lke_excel");
    }
    public static object[] Fdt_NS_TS_KHOACH_LKE(DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_S(b_dr["du_an"]), b_tu, b_den }, "NR", "pns_ts_khoach_lke");
    }

    public static object[] Fdt_NS_TS_PHONG_KHOI_LKE(DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["tu_ngay_tk"]), chuyen.OBJ_N(b_dr["den_ngay_tk"]), chuyen.OBJ_S(b_dr["duan"]), chuyen.OBJ_S(b_dr["phong"]), b_tu, b_den },"NNR", "pns_ts_manday_dutru_lke");
    } 
    public static object[] Fdt_NS_TS_PHONG_KHOI2_LKE(DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["tu_ngay_tk"]), chuyen.OBJ_N(b_dr["den_ngay_tk"]), chuyen.OBJ_S(b_dr["duan"]), b_tu, b_den }, "NNR", "pns_ts_manday_dutru_phong_lke");
    }

    public static DataTable Fdt_NS_TS_TIMKIEM_LKE(DataTable b_dt, DataTable b_dt_ct)
    {
        bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            DataRow b_dr = b_dt.Rows[0];
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_dk = bang.Fobj_COL_MANG(b_dt_ct, "dk");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_tu = bang.Fobj_COL_MANG(b_dt_ct, "tu");
            object[] a_den = bang.Fobj_COL_MANG(b_dt_ct, "den");

            dbora.P_THEM_PAR(ref b_lenh, "a_dk", 'U', a_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'U', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_tu", 'U', a_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_den", 'U', a_den);

            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_tk_cn = "," + chuyen.OBJ_C(b_dr["loai"]) + "," + chuyen.OBJ_N(b_dr["ngayd"]) + "," + chuyen.OBJ_N(b_dr["ngayc"]) + "," + chuyen.OBJ_N(b_dr["ranh"]) + "," + chuyen.OBJ_C(b_dr["ng_nhan_tk"]);


            string b_c = ",:a_dk,:a_ma,:a_tu,:a_den,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_timkiem(" + b_se.tso + b_tk_cn + b_c + "); end;";
            try
            {
                // b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }



    public static DataTable Fdt_NS_TS_BOOKNS_LKE(DataTable b_dt)
    {
        bang.P_CNG_SO(ref b_dt, "tu_ngay_tk,den_ngay_tk");
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_S(b_dr["loai_tk"]), chuyen.OBJ_S(b_dr["tt_giao"]), chuyen.OBJ_S(b_dr["tt_nhan"]), chuyen.OBJ_N(b_dr["tu_ngay_tk"]), chuyen.OBJ_N(b_dr["den_ngay_tk"]) }, "pns_ts_bookns_lke");
    }

    #endregion
    public static DataTable Fdt_MA_CV()
    {
        return dbora.Fdt_LKE("pns_ts_gv_cv_lke");
    }
    public static DataTable Fdt_MA_TT()
    {
        return dbora.Fdt_LKE("pns_ts_gv_ma_tt_lke");
    }


    public static void P_NS_TS_BOOK_NH(string b_so_id_cv, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ng_nhan = bang.Fobj_COL_MANG(b_dt_ct, "ng_nhan");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");


            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id_cv));

            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan", 'U', a_ng_nhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:so_id,:a_ng_nhan,:a_ten";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_book_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }



    public static void P_NS_TS_BOOKNS_NH(ref string b_so_id, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        bang.P_CNG_SO(ref b_dt, "ngay_dk_ht,tu_ngay,toi_ngay");
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.CSO_SO(b_so_id));
            string c = ",:b_so_id";
            c = c + "," + chuyen.OBJ_C(b_dr["nhom_viec"]) + "," + chuyen.OBJ_C(b_dr["skill"]) + "," + chuyen.OBJ_C(b_dr["vi_tri"]) + "," + chuyen.OBJ_C(b_dr["uu_tien"]);
            c = c + "," + chuyen.OBJ_C(b_dr["nd"]) + "," + chuyen.OBJ_C(b_dr["mo_ta"]);
            c = c + "," + chuyen.OBJ_N(b_dr["tong_gio"]) + "," + chuyen.OBJ_C(b_dr["tu_gio"]) + "," + chuyen.OBJ_C(b_dr["toi_gio"]) + "," + chuyen.OBJ_N(b_dr["tu_ngay"]) + "," + chuyen.OBJ_N(b_dr["toi_ngay"]);
            c = c + "," + chuyen.OBJ_N(b_dr["ngay_dk_ht"]) + "," + chuyen.OBJ_C(b_dr["ma_du_an"]) + "," + chuyen.OBJ_C(b_dr["ng_nhan"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_bookns_nh(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_TS_BOOKNS_CT(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "pns_ts_bookns_ct");
    }

    public static void Fdt_NS_TS_BOOKNS_XACNHAN(string b_so_id, string b_xacnhan)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_so_id, b_xacnhan }, "pns_ts_bookns_xacnhan");
    }
}