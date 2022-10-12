using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Cthuvien;

public class khud_ttt
{
    /// <summary> Liệt kê </summary>
    public static DataTable Fdt_LKE(string b_ps,string b_nv)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PBH_KH_TTT_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_NH(string b_ps, string b_nv, DataTable b_dt)
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
            object[] a_bb = bang.Fobj_COL_MANG(b_dt, "bb");
            object[] a_ktra = bang.Fobj_COL_MANG(b_dt, "ktra");
            object[] a_f_tkhao = bang.Fobj_COL_MANG(b_dt, "f_tkhao");
            object[] a_f_sht_tkhao = bang.Fobj_COL_MANG(b_dt, "f_sht_tkhao");


            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_bb", 'S', a_bb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktra", 'S', a_ktra);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_tkhao", 'S', a_f_tkhao);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_sht_tkhao", 'S', a_f_sht_tkhao);

            string c = ",'" + b_ps + "','" + b_nv + "',:a_ma,:a_ten,:a_loai,:a_bb,:ktra,:f_tkhao,:f_sht_tkhao";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PBH_KH_TTT_NH(" + b_se.tso + c + "); end;";
            try {b_lenh.ExecuteNonQuery();}
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary> Xóa </summary>
    public static void P_XOA(string b_ps, string b_nv)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_ps, b_nv }, "PBH_KH_TTT_XOA");
    }
    /// <summary> Trả bảng khởi tạo Grid thông tin thêm </summary>
    public static string Fs_TTT_TAO(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return "";
        if (bang.Fi_TIM_COL(b_dt, "nd") < 0) bang.P_THEM_COL(ref b_dt, "nd", "");
        return bang.Fs_BANG_CH(b_dt, new string[] { "ten", "nd","ma","loai","bb","ktra","f_tkhao","f_sht_tkhao"});
    }
    /// <summary> Trả bảng nhập thông tin thêm </summary>
    public static string Fs_TTT_CH(DataTable b_dt)
    {
        return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "nd" });
    }
    /// <summary> Tạo bảng nhập thông tin thêm </summary>
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
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static void P_TS(ref OracleCommand b_lenh, DataTable b_dt, out string b_ts)
    {
        if (b_dt.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt, 1);
        else
        {
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["loai"]) == "S") b_dr["nd"] = chuyen.CSO_CH(chuyen.OBJ_S(b_dr["nd"]));
            }
            b_dt.AcceptChanges();
        }
        if (bang.Fi_TIM_COL(b_dt, "so_id_dt") >= 0)
        {
            object[] ttt_so_id_dt = bang.Fobj_COL_MANG(b_dt, "so_id_dt");
            dbora.P_THEM_PAR(ref b_lenh, "ttt_so_id_dt", 'N', ttt_so_id_dt);
            b_ts = ",:ttt_so_id_dt";
        }
        else b_ts="";
        object[] ttt_ma = bang.Fobj_COL_MANG(b_dt, "ma");
        object[] ttt_nd = bang.Fobj_COL_MANG(b_dt, "nd");
        dbora.P_THEM_PAR(ref b_lenh, "ttt_ma", 'S', ttt_ma);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_nd", 'U', ttt_nd);
        b_ts += ",:ttt_ma,:ttt_nd";
    }
    /// <summary> Kiểm tra trường phải nhập </summary>
    public static void P_KTRA_BB(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["bb"]) == "C" && chuyen.OBJ_S(b_dr["nd"]) == "")
                throw new Exception("loi:Phải nhập "+chuyen.OBJ_S(b_dr["ten"])+":loi");
        }
    }
    public static void P_KTRA_BB(string b_ma_dvi, string b_ps, string b_so_id, string b_so_id_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "loi", 'S');
            string c = "'" + b_ma_dvi + "','" + b_ps + "'," + b_so_id + "," + b_so_id_dt + ",:loi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PBH_KH_TTT_CT_KTRA(" + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                string b_kq = chuyen.OBJ_S(b_lenh.Parameters["loi"].Value);
                if (b_kq != "") throw new Exception("loi:Chưa nhập đầy đủ thông tin thống kê.:loi");
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
}
