using System.Data;
using Oracle.DataAccess.Client;
using Cthuvien;

public class ht_manhom
{
    ///<summary>Liệt kê</summary>
    public static DataTable Fdt_MA_NHOM_LKE(string b_loai, string b_ma_tk, string b_ten_tk)
    {
        se.se_nsd b_se = new se.se_nsd();
        return dbora.Fdt_LKE_S(new object[] { b_se.md, b_loai, b_ma_tk, "N'" + b_ten_tk }, "PHT_MA_NHOM_LKE");
    }
    ///<summary>Chi tiết nhom</summary>
    public static void P_MA_NHOM_CT(string b_ma, out DataTable b_dt_ct, out DataTable b_dt_nv)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_se.md, b_ma }, 2, "PHT_MA_NHOM_CT");
        b_dt_ct = b_ds.Tables[0].Copy(); b_dt_nv = b_ds.Tables[1].Copy();
    }
    ///<summary>Xóa mã nhom</summary>
    public static void P_MA_NHOM_XOA(string b_ma)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        dbora.P_GOIHAM(new object[] { b_se.md, b_ma }, "PHT_MA_NHOM_XOA");
    }
    ///<summary>Nhập mã nhom</summary>
    public static void P_MA_NHOM_NH(DataTable b_dt_ct, DataTable b_dt_nv, string b_loai)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr_ct = b_dt_ct.Rows[0];

            object[] a_nv = bang.Fobj_COL_MANG(b_dt_nv, "nv");
            object[] a_tc = bang.Fobj_COL_MANG(b_dt_nv, "tc");

            dbora.P_THEM_PAR(ref b_lenh, "nv", 'S', a_nv);
            dbora.P_THEM_PAR(ref b_lenh, "tc", 'S', a_tc);

            string c = "," + chuyen.OBJ_C(b_se.md) + "," + chuyen.OBJ_C(b_dr_ct["ma"]) + "," + chuyen.OBJ_C(b_dr_ct["ten"]) + "," + chuyen.OBJ_C(b_loai);
            c = c + ",:nv,:tc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHT_MA_NHOM_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Fdt_MA_NHOM_MA(string b_ma, string b_ma_tk, string b_ten_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_ma_tk, "N'" + b_ten_tk, b_trangkt }, "NNR", "PNS_MA_NHOM_MA");
    }
}
