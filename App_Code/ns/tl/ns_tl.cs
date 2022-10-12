using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
public class ns_tl
{
    #region MÃ NHÓM LƯƠNG
    public static object[] Faobj_NS_TL_MA_NL_MA(string b_ma, string b_ma_nn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_ma_nn, b_trangkt }, "NNR", "PNS_TL_MA_NL_MA");
    }
    public static DataTable Fdt_NS_TL_MA_NL_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_MA_NL_CT");
    }
    public static DataTable Fdt_NS_TL_MA_NL_XEM(string b_ma_dvi)
    {
        return dbora.Fdt_LKE_S(b_ma_dvi, "PNS_TL_MA_NL_XEM");
    }
    public static object[] Faobj_NS_TL_MA_NL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_MA_NL_LKE");
    }
    public static DataTable Fdt_NS_TL_MA_NL_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_NL_EXCEL");
    }
    public static void P_NS_TL_MA_NL_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_dr["so_id"]), b_dr["ma_nn"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_TL_MA_NL_NH");
        }
    }
    public static void Fs_NS_TL_MA_NL_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_TL_MA_NL_NH");
        }
    }
    public static void P_NS_TL_MA_NL_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_MA_NL_XOA");
    }
    #endregion MÃ NHÓM LƯƠNG

    #region THIẾT LẬP ĐỐI TƯỢNG BẢNG LƯƠNG
    public static object[] Fdt_NS_TL_DTUONG_BLUONG_LKE(string b_ma_bluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_bluong, b_tu_n, b_den_n }, "NR", "PNS_TL_DTUONG_BLUONG_LKE");
    }
    public static object[] Fdt_NS_TL_DTUONG_BLUONG_MA(string b_so_id, string b_ma_bluong, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_ma_bluong, b_trangkt }, "NNR", "PNS_TL_DTUONG_BLUONG_MA");
    }
    public static void PNS_TL_DTUONG_BLUONG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_khoi, DataTable b_dt_dtnv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
             
            object[] a_ma_khoi = bang.Fobj_COL_MANG(b_dt_khoi, "ma_khoi"); 
            object[] a_ma_dtnv = bang.Fobj_COL_MANG(b_dt_khoi, "ma_dtnv");


            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
             
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_khoi", 'S', a_ma_khoi); 
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_dtnv", 'S', a_ma_dtnv);


            string b_c = ",:so_id," + chuyen.OBJ_C(b_dt.Rows[0]["MA_BLUONG"]) + "," + chuyen.OBJ_C(b_dt.Rows[0]["ngay_ad"]);

            b_c += ",:a_ma_khoi,:a_ma_dtnv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_DTUONG_BLUONG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataSet Fds_NS_TL_DTUONG_BLUONG_CT(double b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 3, "PNS_TL_DTUONG_BLUONG_CT");
    }
    public static void PNS_TL_DTUONG_BLUONG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_DTUONG_BLUONG_XOA");
    }
    public static DataSet Fds_NS_TL_DTUONG_BLUONG_LKE_DATA()
    {
        return dbora.Fds_LKE(2, "PNS_TL_DTUONG_BLUONG_LKE_DATA");
    }
    #endregion THIẾT LẬP ĐỐI TƯỢNG BẢNG LƯƠNG

    #region THIẾT LẬP DANH MỤC LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_TL_MA_ML_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_ML_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_TL_MA_ML_LKE(string b_ma_dvi, string b_dtuong, double b_loai, double b_loai_ct, double b_bluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dvi, b_dtuong, b_loai, b_loai_ct, b_bluong, b_tu_n, b_den_n }, "NR", "PNS_TL_MA_ML_LKE");
    }
    public static DataTable Fdt_NS_TL_MA_ML_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_MA_CTLUONG_CT");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_TL_MA_ML_MA(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_TL_MA_ML_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_MA_ML_NH(double b_so_id, DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_so_id, b_dr["ap_dung_ct"], b_dr["ten_ct"], b_dr["sott_nhom"], b_dr["sott_hien_thi"], b_dr["sott_hien_thi_th"],
            b_dr["trang_thai"], b_dr["hien_thi_tk"], b_dr["hien_thi_th"], b_dr["sott_hien_thi_kd"], b_dr["hien_thi_kd"], b_dr["D_TUONG"] }, "PNS_TL_MA_ML_NH");
    }
    #endregion THIẾT LẬP DANH MỤC LƯƠNG

    #region  THIẾT LẬP CÔNG THỨC LƯƠNG
    public static DataTable Fdt_NS_TL_MA_CTLUONG_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_MA_CTLUONG_CT");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_TL_MA_CTLUONG_LKE(string b_ma_dvi, string b_dtuong, double b_loai, double b_bluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dvi, b_dtuong, b_loai, b_bluong, b_tu_n, b_den_n }, "NR", "PNS_TL_MA_CTLUONG_LKE");
    }
    public static object[] Faobj_NS_TL_MA_CTLUONG_LKE_DV(string b_ma_dvi, string b_dtuong, double b_loai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n }, "NR", "PNS_TL_MA_CTLUONG_LKE_DV");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_MA_CTLUONG_NH(double b_so_id, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count > 0)
        {
            DataRow dr = b_dt_ct.Rows[0];
            dbora.P_GOIHAM(new object[] { b_so_id, dr["congthuc"] }, "PNS_TL_MA_CTLUONG_NH");
        }
    }
    public static void P_NS_TL_MA_CTLUONG_KT(double b_loai, string b_cotct, string b_ct)
    {
        dbora.P_GOIHAM(new object[] { b_loai, b_cotct, b_ct }, "PNS_TL_MA_CTLUONG_KT");
    }
    #endregion THIẾT LẬP CÔNG THỨC LƯƠNG

    #region Thiết lập hỗ trợ ăn trưa theo vùng
    public static object[] Faobj_NS_TL_HTRO_ANTRUA_VUNG_MA(string b_vung, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_vung, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_TL_HTRO_ANTRUA_VUNG_MA");
    }
    public static DataTable Fdt_NS_TL_HTRO_ANTRUA_VUNG_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_HTRO_ANTRUA_VUNG_CT");
    }
    public static object[] Faobj_NS_TL_HTRO_ANTRUA_VUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_HTRO_ANTRUA_VUNG_LKE");
    }
    public static DataTable Fdt_NS_TL_HTRO_ANTRUA_VUNG_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TL_HTRO_ANTRUA_VUNG_EXCEL");
    }
    public static void P_NS_TL_HTRO_ANTRUA_VUNG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["vung"], chuyen.CNG_SO(b_dr["ngay_hl"].ToString()), chuyen.CNG_SO(b_dr["ngay_het_hl"].ToString()), chuyen.OBJ_N(b_dr["hotro"]), b_dr["mota"] }, "PNS_TL_HTRO_ANTRUA_VUNG_NH");
        }
    }
    public static void P_NS_TL_HTRO_ANTRUA_VUNG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_HTRO_ANTRUA_VUNG_XOA");
    }
    #endregion MÃ NHÓM LƯƠNG

    #region Thiết lập phụ cấp theo vùng
    public static object[] Faobj_NS_TL_PC_VUNG_MA(string b_pcap, string b_vung, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_pcap, b_vung, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_TL_PC_VUNG_MA");
    }
    public static DataTable Fdt_NS_TL_PC_VUNG_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_PC_VUNG_CT");
    }
    public static object[] Faobj_NS_TL_PC_VUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_PC_VUNG_LKE");
    }
    public static DataTable Fdt_NS_TL_PC_VUNG_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TL_PC_VUNG_EXCEL");
    }
    public static void P_NS_TL_PC_VUNG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["pcap"], b_dr["vung"], chuyen.CSO_SO(b_dr["sotien"].ToString()), b_dr["loaihuong"], chuyen.CNG_SO(b_dr["ngay_hl"].ToString()), chuyen.CNG_SO(b_dr["ngay_het_hl"].ToString()), b_dr["mota"] }, "PNS_TL_PC_VUNG_NH");
        }
    }
    public static void P_NS_TL_PC_VUNG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_PC_VUNG_XOA");
    }
    public static DataTable Faobj_NS_TL_PC_VUNG_PCAP(string b_pcap)
    {
        return dbora.Fdt_LKE_S(b_pcap, "PNS_TL_PC_VUNG_PCAP");
    }
    #endregion Thiết lập phụ cấp theo vùng

    #region THIẾT LẬP HỖ TRỢ ĂN TRƯA THEO PHÒNG
    public static DataSet Fdt_NS_TL_HTRO_ANTRUA_PHONG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 3, "PNS_TL_HTRO_ANTRUA_PHONG_CT");
    }

    public static object[] Fdt_DT_NS_CB(string b_phong, string b_lke, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_lke, "", "N'%%", b_tu, b_den }, "NR", "PNS_CB_LKE");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_TL_HTRO_ANTRUA_PHONG_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_TL_HTRO_ANTRUA_PHONG_LKE");
    }
    public static DataTable Fdt_NS_TL_HTRO_ANTRUA_PHONG_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TL_HTRO_ANTRUA_PHONG_EXCEL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TL_HTRO_ANTRUA_PHONG_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_TL_HTRO_ANTRUA_PHONG_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_HTRO_ANTRUA_PHONG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_dvi)
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

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_dvi, "stt");
            object[] a_ma_phong = bang.Fobj_COL_MANG(b_dt_dvi, "ma_phong");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt_dvi, "ten_phong");
            object[] a_so_tien = bang.Fobj_COL_MANG(b_dt_dvi, "so_tien");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_phong", 'S', a_ma_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_tien", 'N', a_so_tien);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ng_hluc"]) + "," + chuyen.OBJ_C(b_dr["ng_het_hluc"]) + "," + chuyen.OBJ_C(b_dr["sotien"]) + ","
                + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_C(b_dr["theo_nv"]) + "," + chuyen.OBJ_C(b_dr["theo_dvi"]) + "," + chuyen.OBJ_C(b_dr["phong_tk"])
                + ",:a_tt,:a_so_the,:a_ten,:a_phong,:a_stt,:a_ma_phong,:a_ten_phong,:a_so_tien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_HTRO_ANTRUA_PHONG_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TL_HTRO_ANTRUA_PHONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_HTRO_ANTRUA_PHONG_XOA");
    }
    #endregion

    #region THIẾT LẬP PHỤ CẤP
    public static DataSet Fdt_NS_TL_PC_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 5, "PNS_TL_PC_CT");
    }

    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_TL_PC_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NRRRR", "PNS_TL_PC_LKE");
    }
    public static DataTable Fdt_NS_TL_PC_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TL_PC_EXCEL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TL_PC_MA(string b_ma_pc, string b_ng_hluc, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_pc, chuyen.CNG_SO(b_ng_hluc), b_trangkt }, "NNR", "PNS_TL_PC_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TL_PC_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_pb, DataTable b_dt_cd, DataTable b_dt_td, DataTable b_dt_nv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            bang.P_CSO_SO(ref b_dt_nv, "tt");


            object[] a_ma_ph = bang.Fobj_COL_MANG(b_dt_pb, "ma");

            object[] a_ma_cd = bang.Fobj_COL_MANG(b_dt_cd, "ma");

            object[] a_ma_td = bang.Fobj_COL_MANG(b_dt_td, "ma");

            object[] a_tt = bang.Fobj_COL_MANG(b_dt_nv, "tt");
            object[] a_sothe_nv = bang.Fobj_COL_MANG(b_dt_nv, "so_the");
            object[] a_ten_nv = bang.Fobj_COL_MANG(b_dt_nv, "ten");
            object[] a_cd_nv = bang.Fobj_COL_MANG(b_dt_nv, "cdanh");
            object[] a_pb_nv = bang.Fobj_COL_MANG(b_dt_nv, "phong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ph", 'S', a_ma_ph);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd", 'S', a_ma_cd);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_td", 'S', a_ma_td);

            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_nv", 'S', a_sothe_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_nv", 'U', a_ten_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_cd_nv", 'U', a_cd_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_pb_nv", 'U', a_pb_nv);


            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ng_hluc"]) + "," + chuyen.OBJ_C(b_dr["ng_het_hluc"]) + "," + chuyen.OBJ_C(b_dr["ma_pc"]) + "," + chuyen.OBJ_C(b_dr["sotien"]) + ","
                + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_C(b_dr["loaihuong"]) + "," + chuyen.OBJ_C(b_dr["thietlap"]) + "," + chuyen.OBJ_C(b_dr["tuthang"]) + "," + chuyen.OBJ_C(b_dr["denthang"])
                + ",:a_ma_ph" + ",:a_ma_cd" + ",:a_ma_td" + ",:a_tt" + ",:a_sothe_nv" + ",:a_ten_nv" + ",:a_cd_nv" + ",:a_pb_nv";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_tl_pc_nh(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TL_PC_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_PC_XOA");
    }
    #endregion
}