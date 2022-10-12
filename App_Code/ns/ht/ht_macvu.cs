using System.Data;
using Cthuvien;

public class ht_macvu
{
    ///<summary>Liệt kê</summary>
    public static DataTable Fdt_MA_CVU_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_CVU_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_MA_CVU_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { b_dr_ct["ma"], b_dr_ct["ten"], chuyen.OBJ_S(b_dr_ct["ma_ct"], " ") };
        dbora.P_GOIHAM(a_obj, "PHT_MA_CVU_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_MA_CVU_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHT_MA_CVU_XOA");
    }
}
