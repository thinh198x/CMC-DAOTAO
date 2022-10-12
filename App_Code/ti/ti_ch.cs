using System;
using System.Collections.Generic;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Data;
using Cthuvien;

/// <summary>
/// Summary description for ti_ch
/// </summary>
public class ti_ch
{
    #region MÃ NHÓM CHỈ TIÊU TÌM KIẾM
    public static DataTable Fdt_NS_TK_MA_NHTK_DR()
    {
        return dbora.Fdt_LKE("PNS_TK_MA_NHTK_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TK_MA_NHTK_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TK_MA_NHTK_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_TK_MA_NHTK_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TK_MA_NHTK_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TK_MA_NHTK_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["bang"] }, "PNS_TK_MA_NHTK_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_TK_MA_NHTK_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TK_MA_NHTK_XOA");
    }
    #endregion MÃ NHÓM CHỈ TIÊU TÌM KIẾM

    #region MÃ CHỈ TIÊU TÌM KIẾM

    //liet ke chi tieu
    public static DataTable Fdt_NS_TK_LKE_CT(string b_nhom)
    {
        return dbora.Fdt_LKE_S(b_nhom, "PNS_TK_MA_CHITIEU_HT");
    }
    // liet ke du lieu hien thi

    public static DataTable Fdt_PNS_MA_KQ_HIENTHI_LKECHECK()
    {
        return dbora.Fdt_LKE("PNS_MA_KQ_HIENTHI_LKECHECK");
    }
    public static object[] Fdt_NS_TK_MA_CHITIEU_LKE(string b_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_tu_n, b_den_n }, "NR", "PNS_TK_MA_CHITIEU_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_TK_MA_CHITIEU_MA(string b_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_ma, b_trangkt }, "NNR", "PNS_TK_MA_CHITIEU_MA");
    }
    // Liet ke chi tiet
    public static DataTable Fdt_NS_TK_MA_CHITIEU_CT(string b_nhom, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom, b_ma }, "PNS_TK_MA_CHITIEU_CT");
    }
    // Nhap so lieu
    public static void P_NS_TK_MA_CHITIEU_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom"], b_dr["ma"], b_dr["tt"], b_dr["ten"] }, "PNS_TK_MA_CHITIEU_NH");
    }
    // Xoa so lieu
    public static void P_NS_TK_MA_CHITIEU_XOA(string b_nhom, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nhom, b_ma }, "PNS_TK_MA_CHITIEU_XOA");
    }
    #endregion CHỈ TIÊU TÌM KIẾM

    #region MÃ KẾT QUẢ HIỂN THỊ
    //liet ke ket qua hien thi
    public static DataTable Fdt_NS_MA_KQ_HIENTHI_CT(string b_nhom)
    {
        return dbora.Fdt_LKE_S(b_nhom, "PNS_MA_KQ_HIENTHI_HT");
    }
    public static object[] Fdt_NS_MA_KQ_HIENTHI_LKE(string b_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_tu_n, b_den_n }, "NR", "PNS_MA_KQ_HIENTHI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_KQ_HIENTHI_MA(string b_loai, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_loai, b_ma, b_trangkt }, "NNR", "PNS_MA_KQ_HIENTHI_MA");
    }
    // Nhap so lieu
    public static void P_NS_MA_KQ_HIENTHI_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["loai"], b_dr["nhom"], b_dr["ma"], b_dr["tt"], b_dr["ten"], b_dr["dkthem"], b_dr["cot"], b_dr["kieu"] }, "PNS_MA_KQ_HIENTHI_NH");
    }
    // Xoa so lieu
    public static void P_NS_MA_KQ_HIENTHI_XOA(string b_loai, string b_nhom, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_loai, b_nhom, b_ma }, "PNS_MA_KQ_HIENTHI_XOA");
    }
    #endregion MÃ KẾT QUẢ HIỂN THỊ

    #region TÌM KIẾM

    public static DataTable Fdt_NS_TIMKIEM(DataTable b_dt_dk, DataTable b_dt_kq)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenhsl = new OracleCommand();
            b_lenhsl.Connection = b_cnn;
            DataRow b_dr = b_dt_dk.Rows[0];

            DataTable b_dieukien = dsdieukien(ref b_dt_dk, b_se.ma_dvi);

            object[] a_nhom = bang.Fobj_COL_MANG(b_dieukien, "nhom");
            object[] a_gtr = bang.Fobj_COL_MANG(b_dieukien, "ma");
            object[] a_dk = bang.Fobj_COL_MANG(b_dieukien, "dk");
            object[] a_gtrtu = bang.Fobj_COL_MANG(b_dieukien, "gtri_tu");
            object[] a_gtrtoi = bang.Fobj_COL_MANG(b_dieukien, "gtri_toi");

            dbora.P_THEM_PAR(ref b_lenhsl, "a_nhom", 'C', a_nhom);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_gtr", 'C', a_gtr);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_dk", 'C', a_dk);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_gtrtu", 'C', a_gtrtu);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_gtrtoi", 'C', a_gtrtoi);

            dbora.P_THEM_PAR(ref b_lenhsl, "cs1", 'R');

            bang.P_THEM_HANG(ref b_dt_kq, b_dt_dk);
            string b_join = dsjoin(b_dt_kq);
            string b_dkjoin = dkjoin(b_dt_kq);
            string b_gtri = dsgtri(b_dt_kq);
            string b_gtri_dk = dsgtri(b_dt_dk);
            //string b_lenh = "select distinct " + b_gtri + "," + b_gtri_dk + " from " + b_join + " where ";
            string b_lenh = "select " + b_gtri + "," + b_gtri_dk + " from " + b_join + " where ";

            string b_c = "," + chuyen.OBJ_C(b_lenh) + "," + chuyen.OBJ_C(b_dkjoin) + ",:a_nhom,:a_gtr,:a_dk,:a_gtrtu,:a_gtrtoi,:cs1";
            b_lenhsl.CommandText = "Begin " + b_se.dbo + ".PNS_TI_TIMKIEM(" + b_se.tso + b_c + "); end;";

            try
            {
                DataTable b_dt = dbora.Fdt_TRA(b_lenhsl);
                return b_dt;
            }
            finally { b_lenhsl.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable dk_replace(DataTable b_dk)
    {
        string b_gtri_tu, b_gtri_toi;
        DataTable b_dt = bang.Fdt_TAO_BANG(b_dk, new string[] { "gtri_tu", "gtri_toi" }); bang.P_THEM_HANG(ref b_dt, new object[] { "", "" });
        int b_hang = bang.Fi_TIM_ROW(b_dt, "gtri_tu", ""); bang.P_BO_HANG(ref b_dt, "gtri_tu", "");
        string[] m_gtri_tu = bang.Fs_COL_MANG(b_dt, "gtri_tu"); string[] m_gtri_toi = bang.Fs_COL_MANG(b_dt, "gtri_toi");
        for (int i = 0; i < b_hang; i++)
        {
            b_gtri_tu = m_gtri_tu[i]; b_gtri_toi = m_gtri_toi[i];
            if (b_gtri_tu != "" && b_gtri_tu != null)
            {
                b_gtri_tu = b_gtri_tu.Replace("\\u", "\\");
                b_gtri_tu = b_gtri_tu.Replace("\\U", "\\");
            }
            if (b_gtri_toi != "" && b_gtri_toi != null)
            {
                b_gtri_toi = b_gtri_toi.Replace("\\u", "\\");
                b_gtri_toi = b_gtri_toi.Replace("\\U", "\\");
            }
            bang.P_DAT_GTRI(ref b_dk, new string[] { "gtri_tu", "gtri_toi" }, new object[] { b_gtri_tu, b_gtri_toi }, i);
        }
        return b_dk;
    }

    public static DataTable dsdieukien(ref DataTable b_dt_dk, string dvi)
    {
        bang.P_THEM_COL(ref b_dt_dk, "dk", "S");
        string gtri_tu;
        for (int i = 0; i < b_dt_dk.Rows.Count; i++)
        {
            DataRow b_dr = b_dt_dk.Rows[i];
            if (chuyen.OBJ_S(b_dr["gtri_toi"]) != "")
            {
                bang.P_DAT_GTRI(ref b_dt_dk, "dk", "between", i);
            }
            else
            {
                bang.P_DAT_GTRI(ref b_dt_dk, "dk", "like", i);
                gtri_tu = "%" + b_dr["gtri_tu"].ToString() + "%";
                bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", gtri_tu, i);
            }
        }
        bang.P_THEM_HANG(ref b_dt_dk, new object[] { b_dt_dk.Rows[0]["nhom"], "ma_dvi", "", dvi, "", "=" });
        return b_dt_dk;
    }

    public static string dsjoin(DataTable b_dt_kq)
    {
        string[] joindk = bang.Fs_COL_MANG(b_dt_kq, "nhom");
        string join = joindk[0];
        for (int i = 0; i < joindk.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (joindk[i] == joindk[j]) break;
                else if (j == i - 1) { join = join + "," + joindk[i]; }
            }
        }
        return join;
    }
    public static string dsgtri(DataTable b_dt_kq)
    {
        string gtri = " ";
        for (int i = 0; i < b_dt_kq.Rows.Count; i++)
        {
            DataRow b_dr = b_dt_kq.Rows[i];
            gtri = gtri + chuyen.OBJ_S(b_dr["nhom"]) + "." + chuyen.OBJ_S(b_dr["ma"]) + " " + chuyen.OBJ_S(b_dr["ma"]) + ",";
        }
        return gtri.Substring(0, gtri.Length - 1);
    }

    public static string dkjoin(DataTable b_dt_kq)
    {
        string[] joindk = bang.Fs_COL_MANG(b_dt_kq, "nhom");
        string dkjoin = joindk[0], join = "";
        for (int i = 0; i < joindk.Length; i++)
        {
            for (int j = 0; j <= i; j++)
            {
                if (joindk[i] == joindk[j]) break;
                else if (j == i - 1) { join = join + dkjoin + ".so_the = " + joindk[i] + ".so_the and "; }
            }
        }
        return join;
    }

    #endregion TÌM KIẾM

    #region QUẢN LÝ FILES BÁO CÁO
    /// <summary>Thực hiện Liệt kê ban đầu</summary>
    public static DataTable Fdt_FILES_LKE(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TI_QL_FILES_LKE");
    }

    /// <summary>Thực hiện nhập dữ liệu về files</summary>
    public static void P_FILES_NH(string b_so_id, string b_ma, string b_tenbc, string b_tenf, string b_url)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_ma) + "," + chuyen.OBJ_C(b_tenbc) + "," + chuyen.OBJ_C(b_tenf) + "," + chuyen.OBJ_C(b_url);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TI_QL_FILES_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Thực hiện xoa dữ liệu về files</summary>
    public static void P_FILES_XOA(string b_ma, string b_tt)
    {
        dbora.P_GOIHAM(new object[] { b_ma, chuyen.CSO_SO(b_tt) }, "PNS_TI_QL_FILES_XOA");
    }
    #endregion QUẢN LÝ FILES BÁO CÁO

    #region MÃ THỐNG KÊ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TK_MA_THONGKE_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TK_MA_THONGKE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_TK_MA_THONGKE_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TK_MA_THONGKE_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TK_MA_THONGKE_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_TK_MA_THONGKE_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_TK_MA_THONGKE_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TK_MA_THONGKE_XOA");
    }
    #endregion MÃ THỐNG KÊ

    #region MÃ THỐNG KÊ CHI TIẾT

    // Liet ke toan bo
    public static DataTable Fdt_NS_TK_MA_THONGKECT_LKE()
    {
        return dbora.Fdt_LKE("PNS_TK_MA_THONGKECT_LKE");
    }
    // Liet ke chi tiet
    public static DataTable Fdt_NS_TK_MA_THONGKECT_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_TK_MA_THONGKECT_CT");
    }
    // Nhap so lieu
    public static void P_NS_TK_MA_THONGKECT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["bang"], b_dr["cot"], b_dr["giatri"], b_dr["ten"], b_dr["tt"] }, "PNS_TK_MA_THONGKECT_NH");
    }
    // Xoa so lieu
    public static void P_NS_TK_MA_THONGKECT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TK_MA_THONGKECT_XOA");
    }
    #endregion MÃ THỐNG KÊ CHI TIẾT

    #region THỐNG KÊ
    // Liet ke phong ban
    public static DataTable Fdt_NS_THONGKE_LKE_PHONG(string b_nhom)
    {
        return dbora.Fdt_LKE_S(b_nhom, "PNS_TK_THONGKE_MAPHONG");
    }

    // thong ke du lieu tong hop
    public static DataTable Fdt_NS_TK_MA_THONGKECT_DULIEU()
    {
        return dbora.Fdt_LKE("PNS_TK_MA_THONGKECT_DULIEU");
    }
    #endregion THỐNG KÊ

    #region MÃ TÌM KIẾM
    /// <summary> Hỏi có thống kê </summary>
    public static bool Fb_TI_MA_TK_HOI(string b_ps, string b_nv)
    { // Dan
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_TI_MA_TK_LKE");
        return !bang.Fb_TRANG(b_dt);
    }
    /// <summary> Liệt kê </summary>
    public static DataTable Fdt_TI_MA_TK_LKE(string b_ps, string b_nv)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_TI_MA_TK_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_TI_MA_TK_NH(string b_ps, string b_nv, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_loai_lke = bang.Fobj_COL_MANG(b_dt, "loai_lke");
            object[] a_nhom = bang.Fobj_COL_MANG(b_dt, "nhom");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt, "loai");
            object[] a_rong = bang.Fobj_COL_MANG(b_dt, "rong");
            object[] a_bb = bang.Fobj_COL_MANG(b_dt, "bb");
            object[] a_ktra = bang.Fobj_COL_MANG(b_dt, "ktra");
            object[] a_f_tkhao = bang.Fobj_COL_MANG(b_dt, "f_tkhao");
            object[] a_f_sht_tkhao = bang.Fobj_COL_MANG(b_dt, "f_sht_tkhao");
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_lke", 'S', a_loai_lke);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom", 'S', a_nhom);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_rong", 'N', a_rong);
            dbora.P_THEM_PAR(ref b_lenh, "a_bb", 'S', a_bb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktra", 'S', a_ktra);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_tkhao", 'S', a_f_tkhao);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_sht_tkhao", 'S', a_f_sht_tkhao);

            string c = ",'" + b_ps + "','" + b_nv + "',:a_loai_lke,:a_nhom,:a_ma,:a_ten,:a_loai,:a_rong,:a_bb,:a_ktra,:a_f_tkhao,:a_f_sht_tkhao";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TI_MA_TK_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary> Xóa </summary>
    public static void P_TI_MA_TK_XOA(string b_ps, string b_nv)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_ps, b_nv }, "PNS_TI_MA_TK_XOA");
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static DataTable Fdt_TI_MA_TK_TAO()
    {
        return bang.Fdt_TAO_BANG(new string[] { "so_id_dt", "ma", "nd" }, "NSS");
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static void P_TI_MA_TK_TS(ref OracleCommand b_lenh, DataTable b_dt, out string b_ts)
    {
        if (b_dt.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt, 1);
        if (bang.Fi_TIM_COL(b_dt, "so_id_dt") < 0) bang.P_THEM_COL(ref b_dt, "so_id_dt", 0);
        object[] ttt_so_id_dt = bang.Fobj_COL_MANG(b_dt, "so_id_dt");
        object[] ttt_ma = bang.Fobj_COL_MANG(b_dt, "ma");
        object[] ttt_nd = bang.Fobj_COL_MANG(b_dt, "nd");
        dbora.P_THEM_PAR(ref b_lenh, "ttt_so_id_dt", 'N', ttt_so_id_dt);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_ma", 'S', ttt_ma);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_nd", 'U', ttt_nd);
        b_ts = ",:ttt_so_id_dt,:ttt_ma,:ttt_nd";
    }
    public static void P_TI_MA_TK_CDOI(string b_ps, string b_nv, ref DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        DataTable b_dt_g = dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_TI_MA_TK_LKE");
        int b_hang; string b_ma;
        foreach (DataRow b_dr in b_dt_g.Rows)
        {
            if (chuyen.OBJ_S(b_dr["loai"]) == "S")
            {
                b_ma = chuyen.OBJ_S(b_dr["ma"]);
                b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
                if (b_hang >= 0) b_dt.Rows[b_hang]["nd"] = chuyen.CH_CSO(chuyen.OBJ_S(b_dt.Rows[b_hang]["nd"]), 6);
            }
        }
        b_dt.AcceptChanges();
    }
    #endregion

    #region CẬP NHẬP THÔNG TIN
    public static DataTable Fdt_NS_TI_THAYDOI_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TI_CN_NS_CB_CT");
    }
    public static void P_NS_TI_THAYDOI_NH(string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = b_cnn.CreateCommand();
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_so_the));
            string c = ",:so_the" + "," + chuyen.OBJ_C(b_dr["htks"]) + "," + chuyen.OBJ_C(b_dr["gtinh"]);
            c = c + "," + chuyen.OBJ_C(b_dr["tenkhac"]) + "," + chuyen.OBJ_S(b_dr["nsinh"]) + "," + chuyen.OBJ_C(b_dr["noisinh"]);
            c = c + "," + chuyen.OBJ_C(b_dr["qquan"]) + "," + chuyen.OBJ_C(b_dr["cmt"]) + "," + chuyen.OBJ_C(b_dr["noio"]);
            c = c + "," + chuyen.OBJ_C(b_dr["dtoc"]) + "," + chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["skhoe"]);
            c = c + "," + chuyen.OBJ_C(b_dr["cao"]) + "," + chuyen.OBJ_C(b_dr["can"]) + "," + chuyen.OBJ_C(b_dr["nhommau"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TI_CN_NS_CB_NH(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TI_THAYDOI_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TI_CN_NS_CB_XOA");
    }
    public static void P_NS_TI_THAYDOI_PD(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TI_CN_NS_CB_PD");
    }
    public static void P_NS_TI_THAYDOI_KPD(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TI_CN_NS_CB_KPD");
    }
    #endregion CẬP NHẬP THÔNG TIN

    #region THỐNG KÊ SỐ LIỆU
    public static DataTable P_TI_THONGKE_TIM(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);

            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_dr["dk_thamnien"]) + "," + chuyen.OBJ_C(b_dr["thamnien"]) + "," + chuyen.OBJ_C(b_dr["loai_thamnien"]) + ","
                + chuyen.OBJ_C(b_dr["dk_cdanh"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["thamnien_cdanh"]) + ","
                + chuyen.OBJ_C(b_dr["loai_tncdanh"]) + "," + chuyen.OBJ_C(b_dr["capdt"]) + "," + chuyen.OBJ_C(b_dr["dkien_luong"]) + ","
                + chuyen.OBJ_C(b_dr["mucluong"]) + "," + chuyen.OBJ_C(b_dr["dk_chualenluong"]) + "," + chuyen.OBJ_C(b_dr["tg_chualenluong"]) + "," + chuyen.OBJ_C(b_dr["loai_chualenluong"]) + ",:a_ma,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pti_thongke_tim(" + b_se.tso + b_c + "); end;";
            try
            {
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion THỐNG KÊ SỐ LIỆU

    #region BÁO CÁO ĐỘNG


    public static DataSet Fdt_NS_BC_DONG(string b_nhom, DataTable b_dt_dk, DataTable b_dt_kq)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenhsl = new OracleCommand();
            b_lenhsl.Connection = b_cnn;
            //DataTable b_dieukien = dsdieukien_dong(ref b_dt_dk, b_se.ma_dvi);
            int b_d = b_dt_dk.Rows.Count;
            if (b_d == 0) bang.P_THEM_HANG(ref b_dt_dk, new object[] { "" });

            object[] a_ng_mo = bang.Fobj_COL_MANG(b_dt_dk, "ng_mo");
            object[] a_kh = bang.Fobj_COL_MANG(b_dt_dk, "kh");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_dk, "ten");
            object[] a_pd = bang.Fobj_COL_MANG(b_dt_dk, "pd");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_dk, "tt");
            object[] a_gt = bang.Fobj_COL_MANG(b_dt_dk, "gt");
            object[] a_ng_dong = bang.Fobj_COL_MANG(b_dt_dk, "ng_dong");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt_dk, "loai");
            object[] a_cot = bang.Fobj_COL_MANG(b_dt_kq, "ma");
            object[] a_cot_loai = bang.Fobj_COL_MANG(b_dt_kq, "loai");

            dbora.P_THEM_PAR(ref b_lenhsl, "a_ng_mo", 'S', a_ng_mo);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_kh", 'S', a_kh);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_pd", 'S', a_pd);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_tt", 'S', a_tt);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_gt", 'U', a_gt);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_ng_dong", 'S', a_ng_dong);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_cot", 'S', a_cot);
            dbora.P_THEM_PAR(ref b_lenhsl, "a_cot_loai", 'S', a_cot_loai);

            dbora.P_THEM_PAR(ref b_lenhsl, "cs1", 'R');
            dbora.P_THEM_PAR(ref b_lenhsl, "cs2", 'R');
            dbora.P_THEM_PAR(ref b_lenhsl, "cs3", 'R');
            string b_gtri = dsgtri_dong(b_dt_kq);

            string b_c = "," + chuyen.OBJ_C(b_nhom) + ",:a_ng_mo,:a_kh,:a_ten,:a_pd,:a_tt,:a_gt,:a_ng_dong,:a_loai,:a_cot,:a_cot_loai,:cs1,:cs2,:cs3";
            b_lenhsl.CommandText = "Begin " + b_se.dbo + ".PNS_TI_BC_DONG(" + b_se.tso + b_c + "); end;";

            try
            {
                DataSet b_ds = dbora.Fds_TRA(b_lenhsl);
                return b_ds;
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return null;
            }
            finally { b_lenhsl.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable dsdieukien_dong(ref DataTable b_dt_dk, string dvi)
    {
        string gtri_tu;
        for (int i = 0; i < b_dt_dk.Rows.Count; i++)
        {
            DataRow b_dr = b_dt_dk.Rows[i];
            if (chuyen.OBJ_S(b_dr["dk"]) == "Like")
            {
                gtri_tu = "%" + b_dr["gtri_tu"].ToString() + "%";
                bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", gtri_tu, i);
            }
        }
        int b_dem = b_dt_dk.Rows.Count;
        if (b_dem > 0) { bang.P_THEM_HANG(ref b_dt_dk, new object[] { "AND", "NS_CB", "ma_dvi", "Mã đơn vị", "=", dvi, "" }); }
        else { bang.P_THEM_HANG(ref b_dt_dk, new object[] { "", "NS_CB", "ma_dvi", "Mã đơn vị", "=", dvi, "" }); }
        return b_dt_dk;
    }

    public static string dsgtri_dong(DataTable b_dt_kq)
    {
        string gtri = " ";
        for (int i = 0; i < b_dt_kq.Rows.Count; i++)
        {
            DataRow b_dr = b_dt_kq.Rows[i];
            gtri = gtri + chuyen.OBJ_S(b_dr["ma"]) + ",";
        }
        return gtri.Substring(0, gtri.Length - 1);
    }
    #endregion BÁO CÁO ĐỘNG

    public static DataTable Fdt_TI_TV_LOG_LKE()
    { // Dan
        return dbora.Fdt_LKE("pns_tv_log_lke");
    }

    public static DataSet Fds_TI_BC_DONG_THEM_DK(DataTable b_dt_tk)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["NG_MO"]),chuyen.OBJ_S(b_dr["NHOM"]), chuyen.OBJ_S(b_dr["KH"]), chuyen.OBJ_S(b_dr["TEN"]),
            chuyen.OBJ_S(b_dr["PD"]), chuyen.OBJ_S(b_dr["TT"]), chuyen.OBJ_C(b_dr["GT"]), chuyen.OBJ_S(b_dr["NG_DONG"]) }, 1, "PTI_BC_DONG_THEM_DK");
    }
}




