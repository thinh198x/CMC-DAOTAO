using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Text;

public class ns_dto
{
    #region MÃ LOẠI ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_LDT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LDT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_LDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LDT_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LDT_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LDT_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LDT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LDT_XOA");
    }
    #endregion MÃ LOẠI ĐÀO TẠO

    #region MÃ HỆ ĐÀO TẠO
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_HEDT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HEDT_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HEDT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HEDT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HEDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HEDT_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HEDT_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HEDT_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HEDT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HEDT_XOA");
    }
    #endregion MÃ HỆ ĐÀO TẠO

    #region MÃ NHÓM KỸ NĂNG ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_NKYNANG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_NKYNANG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_NKYNANG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_NKYNANG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_NKYNANG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_DT_MA_NKYNANG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DT_MA_NKYNANG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_NKYNANG_XOA");
    }
    #endregion MÃ NHÓM KỸ NĂNG ĐÀO TẠO

    #region MÃ KỸ NĂNG CẦN ĐÀO TẠO
    public static DataTable Fdt_NS_DT_MA_NKYNANG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_NKYNANG_LKE_ALL");
    }
    public static object[] Fdt_NS_DT_MA_KYNANG_LKE(string b_nkynang, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nkynang, b_tu_n, b_den_n }, "NR", "PNS_DT_MA_KYNANG_LKE");
    }
    public static DataTable Fds_NS_DT_MA_KYNANG_CT(string b_ma_plnv, string b_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ma_plnv, b_ma }, "PNS_DT_MA_KYNANG_CT");
        return b_dt;
    }
    public static object[] Fdt_NS_DT_MA_KYNANG_MA(string b_nkynang, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nkynang, b_ma, b_trangkt }, "NNR", "PNS_DT_MA_KYNANG_MA");
    }
    // Nhap so lieu
    public static void P_NS_DT_MA_KYNANG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nkynang"], b_dr["ma"], b_dr["ten"] }, "PNS_DT_MA_KYNANG_NH");
    }
    // Xoa so lieu
    public static void P_NS_DT_MA_KYNANG_XOA(string b_nkynang, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nkynang, b_ma }, "PNS_DT_MA_KYNANG_XOA");
    }
    #endregion MÃ KỸ NĂNG CẦN ĐÀO TẠO

    #region MÃ NGUỒN KINH PHÍ ĐÀO TẠO
    public static object[] Fdt_NS_DT_MA_NGUONKP_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_NGUONKP_LKE");
    }

    public static object[] Fdt_NS_DT_MA_NGUONKP_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_NGUONKP_MA");
    }
    public static void P_NS_DT_MA_NGUONKP_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_DT_MA_NGUONKP_NH");
    }
    public static void P_NS_DT_MA_NGUONKP_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_NGUONKP_XOA");
    }
    #endregion MÃ NGUỒN KINH PHÍ ĐÀO TẠO

    #region MÃ LĨNH VỰC ĐÀO TẠO
    public static DataTable Fdt_NS_MA_LVDAOTAO_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_LVDAOTAO_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_LVDAOTAO_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LVDAOTAO_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary> 
    public static object[] Fdt_NS_MA_LVDAOTAO_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LVDAOTAO_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LVDAOTAO_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LVDAOTAO_NH");
    }
    ///
    public static void P_NS_MA_LVDAOTAO_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LVDAOTAO_XOA");
    }
    #endregion MÃ LĨNH VỰC ĐÀO TẠO

    #region GIẢNG VIÊN ĐÀO TẠO
    public static DataSet Fdt_NS_DT_GVIEN_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_DT_GVIEN_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_DT_GVIEN_LKE(string b_lvdaotao, string b_lke, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_lvdaotao, b_lke, b_tu, b_den }, "NR", "PNS_DT_GVIEN_LKE");
    }

    public static object[] Fdt_NS_DT_GVIEN_MA(string b_so_id, string b_lvdaotao, string b_lke, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_lvdaotao, b_lke, b_so_the, b_trangkt }, "NNR", "PNS_DT_GVIEN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_DT_GVIEN_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_lvdaotao = bang.Fobj_COL_MANG(b_dt_ct, "wlvdaotao");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_ct, "noidung");
            object[] a_danhgia = bang.Fobj_COL_MANG(b_dt_ct, "danhgia");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_lvdaotao", 'S', a_lvdaotao);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_danhgia", 'U', a_danhgia);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["hoatdong"]) + "," + chuyen.OBJ_C(b_dr["lke"])
                + ",:a_lvdaotao" + ",:a_noidung" + ",:a_danhgia";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_GVIEN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_DT_GVIEN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_GVIEN_XOA");
    }
    public static DataTable Fdt_NS_DT_GVIEN_TT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_DT_GVIEN_TT");
    }

    #endregion GIẢNG VIÊN ĐÀO TẠO

    #region THIẾT LẬP NHU CẦU ĐÀO TẠO

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_NHUCAU_DT_LKE(string b_loaidt, string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_loaidt, b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_NHUCAU_DT_LKE");
    }
    public static object[] Fdt_NS_DT_NHUCAU_DT_EXCEL(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_NS_DT_NHUCAU_DT_EXCEL");
    }
    public static object[] Fdt_NS_DT_NHUCAU_DT_MA(string b_loaidt, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_loaidt, b_ma, b_trangkt }, "NNR", "PNS_NS_DT_NHUCAU_DT_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_NS_DT_NHUCAU_DT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_DT_NHUCAU_DT_CT");
    }
    // Nhap so lieu
    public static void P_NS_DT_NHUCAU_DT_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_hinhthuc = bang.Fobj_COL_MANG(b_dt_ct, "ten_hinhthuc");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_hinhthuc", 'U', a_ma_hinhthuc);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["loaidt"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + ",:a_ma_hinhthuc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_NHUCAU_DT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_NHUCAU_DT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_NHUCAU_DT_XOA");
    }
    #endregion THIẾT LẬP NHU CẦU ĐÀO TẠO

    #region KHỞI TẠO ĐỢT KHẢO SÁT
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_KHOITAO_KS_LKE(string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_KHOITAO_KS_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_KHOITAO_KS_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NS_DT_KHOITAO_KS_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_NS_DT_KHOITAO_KS_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_DT_KHOITAO_KS_CT");
    }
    // Nhap so lieu
    public static void P_NS_DT_KHOITAO_KS_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_nhucau = bang.Fobj_COL_MANG(b_dt_ct, "ma_nhucau");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nhucau", 'S', a_ma_nhucau);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_C(b_dr["tu_ngay"]) + "," + chuyen.OBJ_C(b_dr["den_ngay"]) + ",:a_ma_nhucau";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_KHOITAO_KS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_KHOITAO_KS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_KHOITAO_KS_XOA");
    }
    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region TỔNG HỢP PHIẾU KHẢO SÁT
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_TONGHOP_PHIEU_KS_LKE(string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_TONGHOP_PHIEU_KS_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_TONGHOP_PHIEU_KS_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NS_DT_TONGHOP_PHIEU_KS_MA");
    }

    // Chi tiet so lieu
    public static DataSet Fdt_NS_DT_TONGHOP_PHIEU_KS_CT(string b_dot)
    {
        return dbora.Fds_LKE(b_dot, 2, "PNS_NS_DT_TONGHOP_PHIEU_KS_CT");
    }
    // Nhap so lieu
    public static void P_NS_DT_TONGHOP_PHIEU_KS_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_nhucau = bang.Fobj_COL_MANG(b_dt_ct, "ma_nhucau");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nhucau", 'S', a_ma_nhucau);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_C(b_dr["tu_ngay"]) + "," + chuyen.OBJ_C(b_dr["den_ngay"]) + ",:a_ma_nhucau";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_TONGHOP_PHIEU_KS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_TONGHOP_PHIEU_KS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_TONGHOP_PHIEU_KS_XOA");
    }
    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region ĐỀ XUẤT ĐÀO TẠO
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_DXUAT_LKE(string b_loaidt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_loaidt, b_tu, b_den }, "NR", "PNS_DT_DXUAT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_DXUAT_MA(string b_loaidt, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_loaidt, b_ma, b_trangkt }, "NNR", "PNS_DT_DXUAT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_DXUAT_CT(string b_loaidt, string b_ma, string b_lan)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loaidt, b_ma, chuyen.OBJ_I(b_lan) }, "PNS_DT_DXUAT_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable P_NS_DT_DXUAT_NH(DataTable b_dt)
    {
        DataTable b_kq = null;
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            b_kq = dbora.Fdt_LKE_S(new object[] {b_dr["phong"],b_dr["loaidt"],b_dr["ma_nhucau"],b_dr["kynang"],b_dr["lan"], b_dr["ma"],chuyen.OBJ_S(b_dr["ngayd"]), 
                b_dr["ten"], b_dr["muctieu"], b_dr["noidung"], b_dr["thoiluong"],chuyen.OBJ_S(b_dr["thoigian"]), b_dr["so_the"], b_dr["dvtochuc"],
                b_dr["diadiem"],b_dr["chiphi"],b_dr["soluong"],b_dr["ykien"],b_dr["tinhtrang"] }, "PNS_DT_DXUAT_NH");
        }
        return b_kq;
    }

    public static void PNS_DT_DXUAT_XOA(string b_loaidt, string b_ma, string b_lan)
    {
        dbora.P_GOIHAM(new object[] { b_loaidt, b_ma, b_lan }, "PNS_DT_DXUAT_XOA");
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region KHOÁ ĐÀO TẠO
    public static DataSet Fdt_NS_DT_KDT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 4, "PNS_DT_KDT_CT");
    }
    public static DataSet Fdt_NS_DT_KDT_CT2(string b_ma, string b_ma_dt, string b_loaidt)
    {
        return dbora.Fds_LKE(new object[] { b_ma, b_ma_dt, b_loaidt }, 3, "PNS_DT_KDT_CT2");
    }
    public static DataSet Fdt_NS_DT_KDT_CDANH(string b_ma, string b_ma_dt, string b_loaidt)
    {
        return dbora.Fds_LKE(new object[] { b_ma, b_ma_dt, b_loaidt }, 2, "PNS_DT_KDT_CDANH");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_DT_KDT_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_KDT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_KDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_KDT_MA");
    }
    public static void Fdt_NS_DT_KDT_CHO_DK(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_KDT_CHO_DK");
    }
    public static void Fdt_NS_DT_KDT_TRINH_PD(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_KDT_TRINH_PD");
    }
    public static void Fdt_NS_DT_KDT_KHOA_DK(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_KDT_KHOA_DK");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_KDT_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_ct_cdanh, DataTable b_dt_ct_nhucau)
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
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");

            object[] a_so_the_cdanh = bang.Fobj_COL_MANG(b_dt_ct_cdanh, "so_the");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt_ct_cdanh, "ten");
            object[] a_phong_cdanh = bang.Fobj_COL_MANG(b_dt_ct_cdanh, "phong");
            object[] a_tt_cdanh = bang.Fobj_COL_MANG(b_dt_ct_cdanh, "tt");

            object[] a_so_the_nhucau = bang.Fobj_COL_MANG(b_dt_ct_nhucau, "so_the");
            object[] a_ten_nhucau = bang.Fobj_COL_MANG(b_dt_ct_nhucau, "ten");
            object[] a_phong_nhucau = bang.Fobj_COL_MANG(b_dt_ct_nhucau, "phong");
            object[] a_tt_nhucau = bang.Fobj_COL_MANG(b_dt_ct_nhucau, "tt");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);

            dbora.P_THEM_PAR(ref b_lenh, "a_tt_cdanh", 'N', a_tt_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_cdanh", 'S', a_so_the_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong_cdanh", 'S', a_phong_cdanh);

            dbora.P_THEM_PAR(ref b_lenh, "a_tt_nhucau", 'N', a_tt_nhucau);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_nhucau", 'S', a_so_the_nhucau);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_nhucau", 'U', a_ten_nhucau);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong_nhucau", 'S', a_phong_nhucau);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_N(b_dr["ngaytrinh"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_N(b_dr["tyle"]) + "," + chuyen.OBJ_C(b_dr["nhomcn"]) + "," + chuyen.OBJ_C(b_dr["chuyennganh"]) + ","
                + chuyen.OBJ_C(b_dr["noidt"]) + "," + chuyen.OBJ_C(b_dr["quocgia"]) + "," + chuyen.OBJ_N(b_dr["ngayd"]) + "," + chuyen.OBJ_N(b_dr["ngayc"]) + ","
                + chuyen.OBJ_C(b_dr["cap_dt"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["kinhphi"]) + ","
                + chuyen.OBJ_C(b_dr["giatri"]) + "," + chuyen.OBJ_C(b_dr["ykien"]) + "," + chuyen.OBJ_C(b_dr["loaidt"]) + "," + chuyen.OBJ_C(b_dr["ma_nhucau"]) + "," + chuyen.OBJ_C(b_dr["is_camket"])
                + ",:a_tt" + ",:a_so_the" + ",:a_ten" + ",:a_phong,:a_tt_cdanh,:a_so_the_cdanh,:a_ten_cdanh,:a_phong_cdanh,:a_tt_nhucau,:a_so_the_nhucau,:a_ten_nhucau,:a_phong_nhucau";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_DT_KDT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_KDT_XOA");
    }
    #endregion KHOÁ ĐÀO TẠO

    #region THƯ VIỆN CÂU HỎI ĐỀ THI
    public static object[] Fdt_NS_DT_THUVIEN_DTHI_LKE(string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_THUVIEN_DT_LKE");
    }
    public static DataTable Fdt_NS_DT_THUVIEN_DTHI_CHECK(string b_so_id,string b_ma_nhucau, string b_ma,string b_loai)
    {
        return dbora.Fdt_LKE_S(new object[] {chuyen.CSO_SO(b_so_id),b_ma_nhucau, b_ma, b_loai }, "PNS_NS_DT_THUVIEN_DT_NH_CHECK");
    }
    public static object[] Fdt_NS_DT_THUVIEN_DTHI_MA(string b_ma, string b_mach, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_mach, b_trangkt }, "NNR", "PNS_NS_DT_THUVIEN_DT_MA");
    }
    public static DataTable Fdt_NS_DT_THUVIEN_DTHI_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_DT_THUVIEN_DT_CT");
    }
    public static void P_NS_DT_THUVIEN_DTHI_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_traloi = bang.Fobj_COL_MANG(b_dt_ct, "traloi");
            object[] a_dapan = bang.Fobj_COL_MANG(b_dt_ct, "dapan");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "STT");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi", 'U', a_traloi);
            dbora.P_THEM_PAR(ref b_lenh, "a_dapan", 'S', a_dapan);
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            var a = chuyen.OBJ_C(b_dr["MA_NHUCAU"]);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA_NHUCAU"]) + "," + chuyen.OBJ_C(b_dr["CAUHOI"]) + "," + chuyen.OBJ_C(b_dr["MA"]) + ","
                + chuyen.OBJ_C(b_dr["loai"]) + ",:a_traloi,:a_dapan,:a_stt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_THUVIEN_DT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_THUVIEN_DTHI_IMPORT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_ma_ch = bang.Fobj_COL_MANG(b_dt, "ma_ch");
            object[] a_cauhoi = bang.Fobj_COL_MANG(b_dt, "cauhoi");
            object[] a_ma_loai = bang.Fobj_COL_MANG(b_dt, "ma_loai");
            object[] a_dap_an1 = bang.Fobj_COL_MANG(b_dt, "dap_an1");
            object[] a_traloi1 = bang.Fobj_COL_MANG(b_dt, "traloi_1");
            object[] a_dap_an2 = bang.Fobj_COL_MANG(b_dt, "dap_an2");
            object[] a_traloi2 = bang.Fobj_COL_MANG(b_dt, "traloi_2");
            object[] a_dap_an3 = bang.Fobj_COL_MANG(b_dt, "dap_an3");
            object[] a_traloi3 = bang.Fobj_COL_MANG(b_dt, "traloi_3");
            object[] a_dap_an4 = bang.Fobj_COL_MANG(b_dt, "dap_an4");
            object[] a_traloi4 = bang.Fobj_COL_MANG(b_dt, "traloi_4");
            object[] a_dap_an5 = bang.Fobj_COL_MANG(b_dt, "dap_an5");
            object[] a_traloi5 = bang.Fobj_COL_MANG(b_dt, "traloi_5");
            object[] a_dap_an6 = bang.Fobj_COL_MANG(b_dt, "dap_an6");
            object[] a_traloi6 = bang.Fobj_COL_MANG(b_dt, "traloi_6");
            object[] a_dap_an7 = bang.Fobj_COL_MANG(b_dt, "dap_an7");
            object[] a_traloi7 = bang.Fobj_COL_MANG(b_dt, "traloi_7");

            dbora.P_THEM_PAR(ref b_lenh, "a_cauhoi", 'U', a_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_loai", 'S', a_ma_loai);

            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an1", 'U', a_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi1", 'S', a_traloi1);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an2", 'U', a_dap_an2);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi2", 'S', a_traloi2);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an3", 'U', a_dap_an3);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi3", 'S', a_traloi3);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an4", 'U', a_dap_an4);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi4", 'S', a_traloi4);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an5", 'U', a_dap_an5);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi5", 'S', a_traloi5);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an6", 'U', a_dap_an6);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi6", 'S', a_traloi6);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an7", 'U', a_dap_an7);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi7", 'S', a_traloi7);

            string b_c = "''" + "," + chuyen.OBJ_C(b_dr["MA_CH"]) + "," + chuyen.OBJ_C(b_dr["CAUHOI"]) + "," + chuyen.OBJ_C(b_dr["MA_LOAI"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN1"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_1"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN2"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN3"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_3"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN4"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_4"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN5"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_5"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN6"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_6"]) + "," + chuyen.OBJ_C(b_dr["DAP_AN7"]) + "," + chuyen.OBJ_C(b_dr["TRALOI_7"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_THUVIEN_DT_IMPORT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_THUVIEN_DTHI_IMPORT(string b_ma_nhucau, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_ch = bang.Fobj_COL_MANG(b_dt, "ma_ch");
            object[] a_cauhoi = bang.Fobj_COL_MANG(b_dt, "cauhoi");
            object[] a_ma_loai = bang.Fobj_COL_MANG(b_dt, "ma_loai");
            object[] a_dap_an1 = bang.Fobj_COL_MANG(b_dt, "dap_an1");
            object[] a_traloi1 = bang.Fobj_COL_MANG(b_dt, "traloi_1");
            object[] a_dap_an2 = bang.Fobj_COL_MANG(b_dt, "dap_an2");
            object[] a_traloi2 = bang.Fobj_COL_MANG(b_dt, "traloi_2");
            object[] a_dap_an3 = bang.Fobj_COL_MANG(b_dt, "dap_an3");
            object[] a_traloi3 = bang.Fobj_COL_MANG(b_dt, "traloi_3");
            object[] a_dap_an4 = bang.Fobj_COL_MANG(b_dt, "dap_an4");
            object[] a_traloi4 = bang.Fobj_COL_MANG(b_dt, "traloi_4");
            object[] a_dap_an5 = bang.Fobj_COL_MANG(b_dt, "dap_an5");
            object[] a_traloi5 = bang.Fobj_COL_MANG(b_dt, "traloi_5");
            object[] a_dap_an6 = bang.Fobj_COL_MANG(b_dt, "dap_an6");
            object[] a_traloi6 = bang.Fobj_COL_MANG(b_dt, "traloi_6");
            object[] a_dap_an7 = bang.Fobj_COL_MANG(b_dt, "dap_an7");
            object[] a_traloi7 = bang.Fobj_COL_MANG(b_dt, "traloi_7");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ch", 'S', a_ma_ch);
            dbora.P_THEM_PAR(ref b_lenh, "a_cauhoi", 'U', a_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_loai", 'S', a_ma_loai);

            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an1", 'U', a_dap_an1);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi1", 'S', a_traloi1);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an2", 'U', a_dap_an2);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi2", 'S', a_traloi2);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an3", 'U', a_dap_an3);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi3", 'S', a_traloi3);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an4", 'U', a_dap_an4);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi4", 'S', a_traloi4);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an5", 'U', a_dap_an5);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi5", 'S', a_traloi5);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an6", 'U', a_dap_an6);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi6", 'S', a_traloi6);
            dbora.P_THEM_PAR(ref b_lenh, "a_dap_an7", 'U', a_dap_an7);
            dbora.P_THEM_PAR(ref b_lenh, "a_traloi7", 'S', a_traloi7);
            string b_c = "," + chuyen.OBJ_C(b_ma_nhucau);
            b_c = b_c + ",:a_ma_ch,:a_cauhoi,:a_ma_loai,:a_dap_an1,:a_traloi1,:a_dap_an2,:a_traloi2,:a_dap_an3,:a_traloi3,:a_dap_an4,:a_traloi4,:a_dap_an5,:a_traloi5,:a_dap_an6,:a_traloi6,:a_dap_an7,:a_traloi7";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_THUVIEN_DT_IMPORT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_THUVIEN_DTHI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_THUVIEN_DT_XOA");
    }
    #endregion THƯ VIỆN CÂU HỎI ĐỀ THI

    #region KHỞI TẠO ĐỀ THI
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_KHOITAO_DTHI_LKE(string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_KHOITAO_DTHI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_KHOITAO_DTHI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NS_DT_KHOITAO_DTHI_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_NS_DT_KHOITAO_DTHI_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_DT_KHOITAO_DTHI_CT");
    }
    // Nhap so lieu
    public static void P_NS_DT_KHOITAO_DTHI_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_cauhoi = bang.Fobj_COL_MANG(b_dt_ct, "ma_cauhoi");
            object[] a_so_id_ch = bang.Fobj_COL_MANG(b_dt_ct, "SO_ID_CH");
            object[] a_loaithi = bang.Fobj_COL_MANG(b_dt_ct, "loaithi");
            object[] a_diem = bang.Fobj_COL_MANG(b_dt_ct, "diem");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "STT");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ch", 'N', a_so_id_ch);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cauhoi", 'S', a_ma_cauhoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_loaithi", 'S', a_loaithi);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem", 'N', a_diem);
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_C(b_dr["TEN"]) + "," + chuyen.OBJ_C(b_dr["LOAI"]) + "," + chuyen.OBJ_C(b_dr["khoadt"]) + "," + chuyen.OBJ_C(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["datdiem"])
                + ",:a_so_id_ch,:a_ma_cauhoi,:a_loaithi,:a_diem,:a_stt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_KHOITAO_DTHI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_KHOITAO_DTHI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_KHOITAO_DTHI_XOA");
    }
    #endregion KHỞI TẠO ĐỀ THI

    #region TỔ CHỨC THI
    public static object[] Fdt_NS_DT_TOCHUC_THI_LKE(string b_ma, string b_loai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_TOCHUC_THI_LKE");
    }
    public static object[] Fdt_NS_DT_TOCHUC_THI_MA(string b_ma, string b_loai, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai, b_trangkt }, "NNR", "PNS_NS_DT_TOCHUC_THI_MA");
    }
    public static DataTable Fdt_NS_DT_TOCHUC_THI_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_DT_TOCHUC_THI_CT");
    }
    public static DataTable Fdt_NS_DT_TOCHUC_THI_NV(string b_makh)
    {
        return dbora.Fdt_LKE_S(b_makh, "PNS_NS_DT_TOCHUC_THI_NV");
    }
    public static void P_NS_DT_TOCHUC_THI_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_C(b_dr["TEN"]) + "," + chuyen.OBJ_C(b_dr["LOAI_KH"]) + "," + chuyen.OBJ_C(b_dr["MA_KH"]) + "," + chuyen.OBJ_C(b_dr["ngaythi"]) + "," + chuyen.OBJ_C(b_dr["ma_dt"]) + "," + chuyen.OBJ_C(b_dr["thitu"]) + "," + chuyen.OBJ_C(b_dr["thiden"]) + "," + chuyen.OBJ_C(b_dr["thoigian"]) + "," + chuyen.OBJ_C(b_dr["chamthi"]) + "," + chuyen.OBJ_C(b_dr["giamsat"])
                + ",:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_TOCHUC_THI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_TOCHUC_THI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_TOCHUC_THI_XOA");
    }
    #endregion TỔ CHỨC THI

    #region TÍNH ĐIỂM THI
    public static object[] Fdt_NS_DT_TINHDIEM_THI_LKE(string b_ma_kt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_kt, b_tu, b_den }, "NR", "PNS_NS_DT_TINHDIEMTHI_LKE");
    }
    public static DataTable Fdt_NS_DT_CHAMDIEM_TL_CT(string b_ma, string b_causo)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_causo }, "PNS_DT_CHAMDIEM_TL_CT");
    }
    public static DataTable Fdt_NS_DT_CHAMDIEM_TL_MA(string b_ma, string b_ma_dt, string b_causo, string b_so_the, double b_trangkt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_ma_dt, b_causo, b_so_the }, "PNS_DT_CHAMDIEM_TL_MA");
    }
    public static void P_NS_DT_CHAMDIEM_TL_NH(string b_ma, string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_so_id) + "," + chuyen.OBJ_C(b_ma) + "," + chuyen.OBJ_N(b_dr["diem_dat"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_CHAMDIEM_TL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_Fs_DT_TINHDIEM_NH(string b_ma_kt, string b_ngay_cham, DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_db, "so_the");
            object[] a_ma_dt = bang.Fobj_COL_MANG(b_dt_db, "ma_dt");
            dbora.P_THEM_PAR(ref b_lenh, "b_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "b_ma_dt", 'S', a_ma_dt);
            string b_c = "," + chuyen.OBJ_C(b_ma_kt) + "," + chuyen.CNG_SO(b_ngay_cham) + ",:b_so_the,:b_ma_dt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TINHDIEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion TÍNH ĐIỂM THI

    #region ĐÁNH GIÁ - KẾT QUẢ ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_DANHGIA_KQ_LKE(string b_ma, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_DANHGIA_KQ_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_DANHGIA_KQ_MA(string b_ma, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, chuyen.OBJ_N(b_so_id), b_trangkt }, "NNRRR", "PNS_NS_DT_DANHGIA_KQ_MA");
    }
    // Nhap so lieu
    public static void P_NS_DT_DANHGIA_KQ_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_nd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ketqua = bang.Fobj_COL_MANG(b_dt_ct, "ketqua");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_nd, "noidung");
            object[] a_diem_dg = bang.Fobj_COL_MANG(b_dt_nd, "diem_dg");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua", 'S', a_ketqua);

            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg", 'U', a_diem_dg);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA_DT"]) + "," + chuyen.OBJ_C(b_dr["ngay_dg"]) + "," + "''"
                + ",:a_so_the,:a_ketqua,:a_noidung,:a_diem_dg";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_DANHGIA_KQ_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_DANHGIA_KQ_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_DT_DANHGIA_KQ_XOA");
    }
    #endregion ĐÁNH GIÁ - KẾT QUẢ ĐÀO TẠO

    #region DANH SÁCH PHÚC KHẢO

    public static object[] Fdt_NS_DT_PHUCKHAO_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_PHUCKHAO_LKE");
    }
    #endregion MÃ HỆ ĐÀO TẠO

    #region DANH SÁCH ĐỂ ĐĂNG KÝ KHÓA HỌC
    public static object[] Fdt_NS_DT_DANGKYKH_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_DT_DANGKYKH_LKE");
    }

    //dang ky khoa hoc
    public static void Fdt_NS_DT_DANGKYKH_NH(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_DANGKYKH_NH");
    }
    //huy dang ky

    public static void Fdt_NS_DT_DANGKYKH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_DANGKYKH_XOA");
    }
    //Liet ke danh sach dang ky khoa hoc theo ma
    public static DataSet Fdt_NS_DT_DANGKYKH_DSACH(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_DT_DANGKYKH_DSACH");
    }
    //Phê duyệt danh sách đăng ký
    public static void Fdt_NS_DT_DANGKYKH_DUYET(string b_ma, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_tinhtrang = bang.Fobj_COL_MANG(b_dt, "tinhtrang");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang", 'S', a_tinhtrang);

            string b_c = "," + chuyen.OBJ_C(b_ma) + ",:a_so_the" + ",:a_tinhtrang";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANGKYKH_DUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fdt_NS_DT_DANGKYKH_HUYDUYET(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_DANGKYKH_HUYDUYET");
    }
    // tổ chức khóa học
    public static void Fdt_NS_DT_DANGKYKH_TOCHUC(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_DANGKYKH_TOCHUC");
    }

    #endregion DANH SÁCH ĐỂ ĐĂNG KÝ KHÓA HỌC

    #region PHIẾU KHẢO SÁT
    public static object[] Fdt_NS_NS_DT_PHIEU_KS_LKE(string b_ma, string b_tt, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tt, b_tu_n, b_den_n }, "NR", "PNS_NS_DT_PHIEU_KS_LKE");
    }
    public static object[] Fdt_NS_NS_DT_PHIEU_KS_MA(string b_ma, string b_lke, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_lke, b_trangkt }, "NNR", "PNS_NS_DT_PHIEU_KS_MA");
    }
    public static DataSet Fdt_NS_NS_DT_PHIEU_KS_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_NS_DT_PHIEU_KS_CT");
    }
    public static void P_NS_NS_DT_PHIEU_KS_NH(string b_so_id, string b_dot, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_nhucau = bang.Fobj_COL_MANG(b_dt_ct, "ten_nhucau");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt_ct, "hinhthuc");
            object[] a_thoidiem = bang.Fobj_COL_MANG(b_dt_ct, "nthoi_diem_tg");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nhucau", 'S', a_ma_nhucau);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc", 'S', a_hinhthuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_thoidiem", 'N', a_thoidiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_gui"]) + "," + chuyen.OBJ_C(b_dot) + ",:a_ma_nhucau,:a_hinhthuc,:a_thoidiem,:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_PHIEU_KS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_NS_DT_PHIEU_KS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_NS_DT_PHIEU_KS_XOA");
    }
    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region THỰC HIỆN THI
    public static object[] Fdt_NS_DT_DANHSACH_BAITHI_LKE(string b_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tinhtrang, b_tu, b_den }, "NR", "PNS_NS_DANHSACH_BAITHI_LKE");
    }
    public static DataSet Fdt_NS_DT_THUCHIEN_BT_CT(string b_ma, string b_causo, string b_tt_lam, string b_so_the, string b_ma_dt)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_ma_dt, b_ma, b_causo, b_tt_lam }, 2, "PNS_DT_THUCHIEN_BT_CT");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_MA(string b_ma, string b_causo, double b_trangkt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_causo }, "PNS_DT_THUCHIEN_BT_MA");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_KETQUA(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_DT_THUCHIEN_BT_KETQUA");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_PHUCKHAO(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_DT_THUCHIEN_BT_PHUCKHAO");
    }
    public static void P_NS_DT_THUCHIEN_BT_NH(string b_ma, string b_noidung_tl, string b_loai_cauhoi, string b_so_id, string b_guiId, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_danan = bang.Fobj_COL_MANG(b_dt_ct, "dapan");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_danan", 'S', a_danan);
            byte[] utf8Bytes = Encoding.UTF8.GetBytes(b_noidung_tl);

            String str2 = Encoding.UTF8.GetString(utf8Bytes);


            string b_c = "," + chuyen.OBJ_N(b_guiId) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_so_id) + "," + chuyen.OBJ_C(b_ma) + "," + "N" + chuyen.OBJ_C(str2) + "," + chuyen.OBJ_C(b_loai_cauhoi) + ",:a_so_id,:a_danan";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_THUCHIEN_BT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_THUCHIEN_BT_PHUCKHAO(string b_ma, string b_noidung)
    {
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(b_noidung);

        String str2 = Encoding.UTF8.GetString(utf8Bytes);
        dbora.P_GOIHAM(new object[] { b_ma, "N" + chuyen.OBJ_C(str2) }, "PNS_NS_DT_THUCHIEN_BT_PHUCKHAO");
    }
    #endregion THỰC HIỆN THI

    #region THỰC HIỆN THI
    public static object[] Fdt_NS_DT_THUCHIEN_BT_LKE(string b_ma_kt,string b_ma_ch,string b_causo,string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_kt, b_ma_ch, b_causo, b_so_the, b_tu, b_den }, "NR", "PNS_NS_DT_THUCHIEN_BT_LKE");
    }
    public static DataSet Fdt_NS_DT_THUCHIEN_BT_XEMLAI_CT(string b_ma, string b_causo, string b_tt_lam, string b_so_the, string b_ma_dt)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_ma_dt, b_ma, b_causo, b_tt_lam }, 2, "PNS_DT_THUCHIEN_BT_XEMLAI_CT");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_XEMLAI_MA(string b_ma, string b_causo, double b_trangkt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_causo }, "PNS_DT_THUCHIEN_BT_MA");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_XEMLAI_KETQUA(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_DT_THUCHIEN_BT_KETQUA");
    }
    public static DataTable Fdt_NS_DT_THUCHIEN_BT_XEMLAI_PHUCKHAO(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_DT_THUCHIEN_BT_PHUCKHAO");
    }
    public static void P_NS_DT_THUCHIEN_BT_XEMLAI_NH(string b_ma, string b_noidung_tl, string b_loai_cauhoi, string b_so_id, string b_guiId, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_danan = bang.Fobj_COL_MANG(b_dt_ct, "dapan");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_danan", 'S', a_danan);
            string b_c = "," + chuyen.OBJ_N(b_guiId) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_so_id) + "," + chuyen.OBJ_C(b_ma) + "," + chuyen.OBJ_C(b_noidung_tl) + "," + chuyen.OBJ_C(b_loai_cauhoi) + ",:a_so_id,:a_danan";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_THUCHIEN_BT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_THUCHIEN_BT_XEMLAI_PHUCKHAO(string b_ma, string b_noidung)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_noidung }, "PNS_NS_DT_THUCHIEN_BT_PHUCKHAO");
    }
    #endregion THỰC HIỆN THI

    #region DANH SÁCH KHÓA ĐÀO TẠO
    public static object[] Fdt_NS_DT_DSDAOTAO_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_DT_DSDAOTAO_LKE");
    }

    public static void Fdt_NS_DT_DSDAOTAO_PHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DSDAOTAO_PHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void Fdt_NS_DT_DSDAOTAO_HUYPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DSDAOTAO_HUYPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void Fdt_NS_DT_DSDAOTAO_KOPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DSDAOTAO_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion DANH SÁCH KHÓA ĐÀO TẠO
}