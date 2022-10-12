using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_sk
{
    #region THÔNG TIN SỨC KHỎE CÁN BỘ
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_SK_TT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_SK_TT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_SK_TT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_SK_TT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_SK_TT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_SK_TT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_SK_TT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(chuyen.OBJ_I(b_dr["nam"])) + ","
                + chuyen.OBJ_C(b_dr["huyetap"]) + "," + chuyen.OBJ_C(b_dr["thiluc"]) + "," + chuyen.OBJ_C(b_dr["cannang"]) + ","
                + chuyen.OBJ_C(b_dr["chieucao"]) + "," + chuyen.OBJ_C(b_dr["xeploai"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_SK_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id= chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_SK_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_SK_TT_XOA");
    }
    #endregion THÔNG TIN SỨC KHỎE CÁN BỘ

    #region TIỂU SỬ BỆNH ÁN
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_SK_BA_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_SK_BA_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_SK_BA_CT(string b_so_the, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.OBJ_N(b_so_id) }, "PNS_SK_BA_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_SK_BA_NH(ref string b_so_id, DataTable b_dt)
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
                + chuyen.OBJ_C(b_dr["benhvien"]) + "," + chuyen.OBJ_C(b_dr["tenbenh"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_SK_BA_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_SK_BA_XOA(string b_so_the, string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.OBJ_N(b_so_id) }, "PNS_SK_BA_XOA");
    }
    #endregion TIỂU SỬ BỆNH ÁN

    #region KẾ HOẠCH BẢO HỘ LAO ĐỘNG
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_KHBH_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), b_tu, b_den }, "NR", "PNS_KHBH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_KHBH_MA(string b_nam, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma, b_trangkt }, "NNR", "PNS_KHBH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_KHBH_CT(string b_nam, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_ma }, "PNS_KHBH_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_KHBH_NH(DataTable b_dt)
    {
            if (b_dt.Rows.Count > 0)
            {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[]{chuyen.OBJ_S(b_dr["loai_kh"]),chuyen.OBJ_S(b_dr["ma"]),chuyen.OBJ_C(b_dr["ten"]),
                chuyen.OBJ_S(b_dr["nam"]),chuyen.OBJ_S(b_dr["noidung"]),chuyen.OBJ_S(b_dr["ngayd"]),chuyen.OBJ_S(b_dr["ngayc"]),
                chuyen.OBJ_S(b_dr["note"]),chuyen.OBJ_S(b_dr["tien"])}, "PNS_KHBH_NH");
            }
    }
    public static void PNS_KHBH_XOA(string b_nam, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nam, b_ma }, "PNS_KHBH_XOA");
    }
    #endregion KẾ HOẠCH BẢO HỘ LAO ĐỘNG

    #region TRANG THIẾT BỊ BẢO HỘ LAO ĐỘNG
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_TTB_LKE(string b_phong, string b_so_the, string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_ten, b_tu, b_den }, "NR", "PNS_TTB_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TTB_MA(string b_phong, string b_so_the, string b_ten, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_ten, b_so_id, b_trangkt }, "NNR", "PNS_TTB_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TTB_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TTB_CT");
    }
    /// <summary>Liệt kê phòng, chức danh của nhân viên</summary>
    public static DataTable PNS_TTB_PHONG(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TTB_PHONG");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TTB_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ma_cb_giao"]) + "," + chuyen.OBJ_C(b_dr["nhom_ts"]) + "," + chuyen.OBJ_C(b_dr["mats"]) + ","
                + chuyen.OBJ_N(b_dr["sluong"]) + "," + chuyen.OBJ_N(b_dr["tien"]) + "," + chuyen.OBJ_N(b_dr["ngaycap"]) + "," + chuyen.OBJ_N(b_dr["ngaythu"]) + "," 
                + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["ht"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["tentb"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TTB_NH(" + b_se.tso + b_c + "); end;";
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
    public static DataTable PNS_TTB_EXPORT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PTTB_EXPORT");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_TTB_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TTB_XOA");
    }
    #endregion TRANG THIẾT BỊ BẢO HỘ LAO ĐỘNG

    #region THAM GIA HUẤN LUYỆN BHLĐ
    public static DataSet Fdt_NS_BHLD_TG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_BHLD_TG_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_BHLD_TG_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), b_tu, b_den }, "NR", "PNS_BHLD_TG_LKE");
        //return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_nam), b_tu, b_den }, "PNS_BHLD_TG_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_BHLD_TG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'U', a_phong);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + ","
                + chuyen.OBJ_C(b_dr["note"]) + ",:a_so_the" + ",:a_tt" + ",:a_ten" + ",:a_phong";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_BHLD_TG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_BHLD_TG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_BHLD_TG_XOA");
    }
    #endregion THAM GIA HUẤN LUYỆN BHLĐ
}