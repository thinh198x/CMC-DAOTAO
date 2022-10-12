using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_ls
{
    #region LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRONG CÔNG TY
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] PNS_LS_CT_TCT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_CT_TCT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_LS_CT_TCT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_LS_CT_TCT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_LS_CT_TCT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_LS_CT_TCT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_LS_CT_TCT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + ","
                + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + ","
                + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["tien_lcb"]) + "," + chuyen.OBJ_C(b_dr["tien_tdgt"]) + ","
                + chuyen.OBJ_C(b_dr["tien_tns"]) + "," + chuyen.OBJ_C(b_dr["phantram_luong"]) + "," + chuyen.OBJ_C(b_dr["nguoi_ky_qd"]) + ","
                + chuyen.OBJ_C(b_dr["chucdanh_nguoiky"]) + "," + chuyen.OBJ_C(b_dr["tongluong"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDCT_NH1(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_LS_CT_TCT_FILE_NH(DataTable b_dt)
    {
        string b_so_id = "";
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            //bang.P_CNG_NG(ref b_dt, new string[] { "ngay_qd", "ngayd", "ngayc" });
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + ","
                    + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + ","
                    + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["tien_lcb"]) + "," + chuyen.OBJ_C(b_dr["tien_tdgt"]) + ","
                    + chuyen.OBJ_C(b_dr["tien_tns"]) + "," + chuyen.OBJ_C(b_dr["phantram_luong"]) + "," + chuyen.OBJ_C("N'" + b_dr["nguoi_ky_qd"]) + ","
                    + chuyen.OBJ_C("N'" + b_dr["chucdanh_nguoiky"]) + "," + chuyen.OBJ_C(b_dr["tongluong"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDCT_NH1(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable PNS_LS_CT_TCT_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PLS_CT_TCT_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_LS_CT_TCT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LS_CT_TCT_XOA");
    }
    public static string Fn_TRA_TENPHONG(string b_sothe)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_sothe }, 'S', "PNS_TRA_TENPHONG"));
    }
    #endregion LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRONG CÔNG TY
    #region LỊCH SỬ QUÁ TRÌNH LUONG TRONG CÔNG TY
    public static object[] PNS_LS_LUONG_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_LUONG_LKE");
    }
    public static DataTable PNS_LS_LUONG_PCAP(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_LS_LUONG_PCAP");
    }
    public static DataTable PNS_LS_LUONG_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_LUONG_EXPORT");
    }
    #endregion
    #region LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRƯỚC KHI VÀO CÔNG TY
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] PNS_LSCT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LSCT_LKE");
    }
    public static object[] PNS_LSCT_TT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LSCT_TT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_LSCT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_LSCT_MA");
    }
    public static object[] Fdt_LSCT_TT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_LSCT_TT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_LSCT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_LSCT_CT");
    }
    public static DataTable PNS_LSCT_TT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_LSCT_TT_CT");
    }
    public static DataTable Fdt_NS_LSCT_EXCEL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LSCT_EXCEL");
    }
    public static DataTable Fdt_NS_LSCT_TT_EXCEL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LSCT_TT_EXCEL");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_LSCT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //string b_c = ",:so_id";
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["tencty"]) + ","
                + chuyen.OBJ_C(b_dr["dccty"]) + "," + chuyen.OBJ_C(b_dr["sodt"]) + "," + chuyen.OBJ_C(b_dr["ngayd"]) + ","
                + chuyen.OBJ_C(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["mucluong"]) + "," + chuyen.OBJ_C(b_dr["lydo"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_LSCT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string PNS_LSCT_TT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //string b_c = ",:so_id";
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["tencty"]) + ","
                + chuyen.OBJ_C(b_dr["dccty"]) + "," + chuyen.OBJ_C(b_dr["sodt"]) + "," + chuyen.OBJ_C(b_dr["ngayd"]) + ","
                + chuyen.OBJ_C(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["mucluong"]) + "," + chuyen.OBJ_C(b_dr["lydo"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_lsct_tt_nh(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_LSCT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LSCT_XOA");
    }
    public static void PNS_LSCT_TT_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LSCT_TT_GUI");
    }
    public static void PNS_LSCT_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LSCT_TT_XOA");
    }
    #endregion LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRƯỚC KHI VÀO CÔNG TY
    #region QUẢN LÝ CÁC KHOẢN HỖ TRỢ
    public static DataTable Fdt_NS_PCAP_IN(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_PCAP_IN");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] PNS_PCAP_LKE(string b_so_the,string b_loai_huong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the,b_loai_huong, b_tu, b_den }, "NR", "PNS_PCAP_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_PCAP_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_PCAP_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_PCAP_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_PCAP_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_PCAP_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["ma_phucap"]) + ","
                   + chuyen.OBJ_N(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["loaihuong"]) + "," + chuyen.OBJ_N(b_dr["ngayd"]) + "," + chuyen.OBJ_N(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_PCAP_NH(" + b_se.tso + b_c + "); end;";
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
    public static DataTable PNS_PCAP_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PCAP_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_PCAP_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_PCAP_XOA");
    }

    public static object[] Fdt_NS_PCAP_TRA(string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the }, "R", "PNS_PCAP_TRA");
    }


    #endregion QUẢN LÝ CÁC KHOẢN HỖ TRỢ
    #region LỊCH SỬ QUÁ TRÌNH HỢP ĐỒNG LAO ĐỘNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] PNS_LS_HD_LD_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_HD_LD_LKE");
    }
    public static DataTable PNS_LS_HD_LD_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PLS_CT_HD_LD_EXPORT");
    }
    #endregion LỊCH SỬ QUÁ TRÌNH HỢP ĐỒNG LAO ĐỘNG
    #region LỊCH SỬ QUÁ TRÌNH ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu đào tạo trong công ty của nhân viên</summary>
    public static object[] PNS_LS_QT_DT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_QT_DT_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu đào tạo trong công ty và ngoài công ty của nhân viên</summary>
    public static DataTable PNS_LS_QT_DT_LKE_ALL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_QT_DT_LKE_ALL");
    }

    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_LS_QT_DT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_LS_QT_DT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_LS_QT_DT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_LS_QT_DT_CT");
    }
    /// <summary>Nhập nội dung thông tin trong cong ty</summary>
    public static DataTable PNS_LS_QT_DT_NH(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten_kdt = bang.Fobj_COL_MANG(b_dt_ct, "ten_kdt");
            object[] a_lop = bang.Fobj_COL_MANG(b_dt_ct, "lop");
            object[] a_nd = bang.Fobj_COL_MANG(b_dt_ct, "nd");
            object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d");
            object[] a_ngay_c = bang.Fobj_COL_MANG(b_dt_ct, "ngay_c");
            object[] a_ldt = bang.Fobj_COL_MANG(b_dt_ct, "ldt");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_dvi_tc = bang.Fobj_COL_MANG(b_dt_ct, "dvi_tc");
            object[] a_dd_tc = bang.Fobj_COL_MANG(b_dt_ct, "dd_tc");
            object[] a_diem = bang.Fobj_COL_MANG(b_dt_ct, "diem");
            object[] a_kq = bang.Fobj_COL_MANG(b_dt_ct, "kq");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt_ct, "tien");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "b_ten_kdt", 'U', a_ten_kdt);
            dbora.P_THEM_PAR(ref b_lenh, "b_lop", 'U', a_lop);
            dbora.P_THEM_PAR(ref b_lenh, "b_nd", 'U', a_nd);
            dbora.P_THEM_PAR(ref b_lenh, "b_ngay_d", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "b_ngay_c", 'N', a_ngay_c);
            dbora.P_THEM_PAR(ref b_lenh, "b_ldt", 'S', a_ldt);
            dbora.P_THEM_PAR(ref b_lenh, "b_tt", 'S', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "b_dvi_tc", 'U', a_dvi_tc);
            dbora.P_THEM_PAR(ref b_lenh, "b_dd_tc", 'U', a_dd_tc);
            dbora.P_THEM_PAR(ref b_lenh, "b_diem", 'N', a_diem);
            dbora.P_THEM_PAR(ref b_lenh, "b_kq", 'S', a_kq);
            dbora.P_THEM_PAR(ref b_lenh, "b_tien", 'N', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "b_ghichu", 'U', a_ghichu);


            //dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            //string b_c = ",:b_so_the,:b_ten_kdt,:b_lop,:b_nd,:b_ngay_d,:b_ngay_c,:b_ldt,:b_tt,:b_dvi_tc,:b_dd_tc,:b_diem,:b_kq,:b_tien,:b_ghichu,:cs_1";
            string b_c = ",:b_so_the,:b_ten_kdt,:b_lop,:b_nd,:b_ngay_d,:b_ngay_c,:b_ldt,:b_tt,:b_dvi_tc,:b_dd_tc,:b_diem,:b_kq,:b_tien,:b_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_LS_QT_DT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
                //b_lenh.ExecuteNonQuery();
                //return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin ngoai cong ty</summary>
    public static string PNS_LS_QT_DT_NG_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten_kdt"]) + ","
                + chuyen.OBJ_C(b_dr["lop"]) + "," + chuyen.OBJ_C(b_dr["nd"]) + "," + chuyen.OBJ_C(b_dr["ngay_d"]) + ","
                + chuyen.OBJ_C(b_dr["ngay_c"]) + "," + chuyen.OBJ_C(b_dr["ldt"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["dvi_tc"]) + ","
                + chuyen.OBJ_C(b_dr["dd_tc"]) + "," + chuyen.OBJ_C(b_dr["diem"]) + "," + chuyen.OBJ_C(b_dr["kq"]) + ","
                + chuyen.OBJ_C(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_LS_QT_DT_NG_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_LS_QT_DT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LS_QT_DT_XOA");
    }

    public static void PNS_LS_QT_DT_NG_NH_FILE(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        OracleCommand b_lenh = new OracleCommand();
        try
        {
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', 0);
            try
            {
                foreach (DataRow b_dr in b_dt_ct.Rows)
                {
                    b_lenh.Parameters["so_id"].Value = 0;
                    string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C("N'" + b_dr["ten_kdt"]) + ","
                        + chuyen.OBJ_C(b_dr["lop"]) + "," + chuyen.OBJ_C(b_dr["nd"]) + "," + chuyen.OBJ_C(b_dr["ngay_d"]) + ","
                        + chuyen.OBJ_C(b_dr["ngay_c"]) + "," + chuyen.OBJ_C(b_dr["ldt"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["dvi_tc"]) + ","
                        + chuyen.OBJ_C(b_dr["dd_tc"]) + "," + chuyen.OBJ_C(b_dr["diem"]) + "," + chuyen.OBJ_C(b_dr["kq"]) + ","
                        + chuyen.OBJ_C(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
                    b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_LS_QT_DT_NG_NH(" + b_se.tso + b_c + "); end;";
                    b_lenh.ExecuteNonQuery();
                }
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRONG CÔNG TY 
    #region LỊCH SỬ QUÁ TRÌNH KHEN THƯỞNG
    public static object[] PNS_LS_KT_LKE(string b_so_the, int b_date, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_date, b_tu, b_den }, "NR", "PNS_LS_KT_LKE");
    }
    public static DataTable PNS_LS_KT_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_KT_EXPORT");
    }
    #endregion
    #region LỊCH SỬ QUÁ TRÌNH ĐÀO TẠO
    public static object[] PNS_LS_DT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_DT_LKE");
    }
    public static DataTable PNS_LS_DT_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_DT_EXPORT");
    }
    #endregion
    #region LỊCH SỬ QUÁ TRÌNH KỶ LUẬT
    public static object[] PNS_LS_KL_LKE(string b_so_the, int b_date, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_date, b_tu, b_den }, "NR", "PNS_LS_KL_LKE");
    }
    public static object[] PNS_LS_DG_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_LS_DG_LKE");
    }
    public static DataTable PNS_LS_KL_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_KL_EXPORT");
    }

    public static DataTable Pns_ls_dg_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_LS_DG_EXPORT");
    }
    #endregion
}
