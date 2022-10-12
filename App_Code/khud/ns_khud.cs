using System;
using System.Data;
using Oracle.DataAccess.Client;
using Cthuvien;
using System.IO;

/// <summary>
/// Summary description for ns_khud
/// </summary>
public class ns_khud
{
    #region TTT
    /// <summary> Hỏi có thống kê </summary>
    public static bool Fb_TTT_HOI(string b_ps, string b_nv)
    { // Dan
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_KH_TTT_LKE");
        return !bang.Fb_TRANG(b_dt);
    }
    /// <summary> Liệt kê </summary>
    public static DataTable Fdt_TTT_LKE(string b_ps, string b_nv)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_KH_TTT_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_TTT_NH(string b_ps, string b_nv, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt, "loai");
            object[] a_rong = bang.Fobj_COL_MANG(b_dt, "rong");
            object[] a_bb = bang.Fobj_COL_MANG(b_dt, "bb");
            object[] a_ktra = bang.Fobj_COL_MANG(b_dt, "ktra");
            object[] a_f_tkhao = bang.Fobj_COL_MANG(b_dt, "f_tkhao");
            object[] a_f_sht_tkhao = bang.Fobj_COL_MANG(b_dt, "f_sht_tkhao");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_rong", 'N', a_rong);
            dbora.P_THEM_PAR(ref b_lenh, "a_bb", 'S', a_bb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktra", 'S', a_ktra);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_tkhao", 'S', a_f_tkhao);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_sht_tkhao", 'S', a_f_sht_tkhao);

            string c = ",'" + b_ps + "','" + b_nv + "',:a_ma,:a_ten,:a_loai,:a_rong,:a_bb,:a_ktra,:a_f_tkhao,:a_f_sht_tkhao";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KH_TTT_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary> Xóa </summary>
    public static void P_TTT_XOA(string b_ps, string b_nv)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_ps, b_nv }, "PNS_KH_TTT_XOA");
    }
    public static string Fs_TTT(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return "";
        if (bang.Fi_TIM_COL(b_dt, "nd") < 0) bang.P_THEM_COL(ref b_dt, "nd", "");
        return bang.Fs_BANG_CH(b_dt, new string[] { "ten", "nd", "ma", "loai", "bb", "ktra", "f_tkhao", "f_sht_tkhao" });
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static DataTable Fdt_TTT()
    { // Dan
        DataTable b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "so_id_dt", "loai", "ma", "nd" }, "NSSS");
        b_dt.AcceptChanges();
        return b_dt;
    }
    /// <summary> Trả bảng nhập thông tin thêm </summary>
    public static DataTable Fdt_TTT(object[] a_dt)
    {
        string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
        DataTable b_dt = null;
        if (a_gtri != null) { b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_DON(ref b_dt, new string[] { "ma", "nd" }); }
        else
        {
            b_dt = Fdt_TTT();
            if (mang.Fi_hang(a_cot, "so_id_dt") < 0) bang.P_BO_COT(ref b_dt, "so_id_dt");
        }
        return b_dt;
    }
    /// <summary> Trả bảng nhập thông tin thêm </summary>
    public static string Fs_TTT_CH(DataTable b_dt)
    {
        return bang.Fs_BANG_CH(b_dt, "ma,nd");
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static void P_TTT_TS(ref OracleCommand b_lenh, DataTable b_dt, out string b_ts)
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
    public static void P_TTT_CDOI(string b_ps, string b_nv, ref DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        DataTable b_dt_g = dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_KH_TTT_LKE");
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
    /// <summary> Kiểm tra trường phải nhập </summary>
    public static void P_KTRA_BB(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["bb"]) == "C" && chuyen.OBJ_S(b_dr["nd"]) == "")
                throw new Exception("loi:Phải nhập " + chuyen.OBJ_S(b_dr["ten"]) + ":loi");
        }
    }
    #endregion
}