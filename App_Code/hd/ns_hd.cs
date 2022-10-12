using System.Data;
using Cthuvien;

/// <summary>
/// Summary description for ns_hd
/// </summary>
public class ns_hd
{
    public static DataTable Fdt_NS_HD_XEM()
    {
        return dbora.Fdt_LKE("PNS_HOACHDINH_XEM");
    }
    ///<summary>Liệt kê theo don vi</summary>
    public static DataTable Fdt_NS_HD_DVI(string b_dvi)
    {
        return dbora.Fdt_LKE_S(b_dvi, "PNS_HOACHDINH_DVI");
    }
    ///<summary>Liệt kê</summary>
    public static DataTable Fdt_NS_HD_LKE()
    {
        return dbora.Fdt_LKE("PNS_HOACHDINH_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_NS_HD_NH(string a_qly, string a_ma,string a_ten)
    {
        object[] a_obj = new object[] { a_ma, a_ten, a_qly, "CD" };
        dbora.P_GOIHAM(a_obj, "PNS_HOACHDINH_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_NS_HD_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HOACHDINH_XOA");
    }
}