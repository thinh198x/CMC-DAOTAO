using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ns_ctt
/// </summary>
public class ns_dm
{
    #region DANH MỤC KỲ ĐÁNH GIÁ
    public static object[] Fdt_NS_DM_KY_DG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DM_KY_DG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DM_KY_DG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DM_KY_DG_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DM_KY_DG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DM_KY_DG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DM_KY_DG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ngay_d"], b_dr["ngay_c"], b_dr["thoigian_d"], b_dr["thoigian_c"], b_dr["mo_ta"] }, "PNS_DM_KY_DG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DM_KY_DG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DM_KY_DG_XOA");
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_DM_KY_DG_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_DM_KY_DG_EXPORT");
    }
    #endregion DANH MỤC KỲ ĐÁNH GIÁ

    #region DANH MỤC NHÓM CÂU HỎI
    public static object[] Fdt_NS_DM_NHOM_CAUHOI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DM_NHOM_CAUHOI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DM_NHOM_CAUHOI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DM_NHOM_CAUHOI_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DM_NHOM_CAUHOI_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DM_NHOM_CAUHOI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DM_NHOM_CAUHOI_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ngay_d"], b_dr["ngay_c"], b_dr["thoigian_d"], b_dr["thoigian_c"], b_dr["mo_ta"] }, "PNS_DM_NHOM_CAUHOI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DM_NHOM_CAUHOI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DM_NHOM_CAUHOI_XOA");
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_DM_NHOM_CAUHOI_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_DM_NHOM_CAUHOI_EXPORT");
    }
    #endregion DANH MỤC NHÓM CÂU HỎI
}