using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
public class ns_ts_dg
{
    #region Đánh giá
    public static void P_NS_TS_DG_NH(string b_id_cv, ref string b_so_id, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.CSO_SO(b_so_id));
            string c = "," + chuyen.CSO_SO(b_id_cv) + ",:b_so_id" + "," + chuyen.OBJ_C(b_dr["kqua_dg"])
                + "," + chuyen.OBJ_C(b_dr["danh_gia"]) + "," + chuyen.OBJ_C(b_dr["nd_dg"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_dg_nh(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TS_DG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_ts_dg_xoa");
    }
    public static DataTable Fdt_NS_TS_DG_CT(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "pns_ts_dg_ct");
    }
    public static DataTable Fdt_NS_TS_HOI_TONGIO(string b_so_id,DataTable b_dt)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id, b_dt.Rows[0]["ID_CT"].ToString(), b_dt.Rows[0]["TONG_GIO"].ToString() }, "PNS_TS_HOI_TONGIO");
    }
    public static DataTable Fdt_NS_TS_HOI_TONGIO2(string b_so_id,string id_ct)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id,id_ct, 0 }, "PNS_TS_HOI_TONGIO2");
    }
    public static object[] Faobj_NS_TS_DG_ID(string b_id_cv, string b_so_id, DataTable b_dt, double b_TrangKt)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_so_id, b_id_cv, b_TrangKt }, "NNR", "pns_ts_dg_lke_id");
    }
    public static object[] Fdt_NS_TS_DG_LKE(string b_id_cv, DataTable b_dt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_id_cv, b_tu, b_den }, "NR", "pns_ts_dg_lke");
    }
    #endregion
}