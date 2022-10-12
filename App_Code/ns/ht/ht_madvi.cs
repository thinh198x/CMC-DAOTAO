using System.Data;
using Cthuvien;

public class ht_madvi
{
    ///<summary>Liệt kê đơn vị cấp dưới</summary>
    public static DataTable Fdt_MA_DVI_CD()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_CD");
    }
    ///<summary>Liệt kê đơn vị và cấp dưới</summary>
    public static DataTable Fdt_MA_DVI_NB()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_NB");
    }
    public static DataTable Fdt_MA_PH_EXCEL()
    {
        return dbora.Fdt_LKE("PHT_MA_PH_EXCEL");
    }
    ///<summary>Liệt kê đơn vị ngang hang</summary>
    public static DataTable Fdt_MA_DVI_NG()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_NG");
    }
    ///<summary>Liệt kê đơn vị ngang hang va cap duoi</summary>
    public static DataTable Fdt_MA_DVI_ND()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_ND");
    }
    ///<summary>Liệt kê tất cả đơn vị</summary>
    public static DataTable Fdt_MA_DVI_XEM()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_XEM");
    }

    public static string Fs_DVI_QLY(string b_ma)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(b_ma, 'S', "PKH_MA_DVI_QLY"));
    }

    public static DataTable Fdt_MA_DVI_XEM_QUYEN()
    {
        return dbora.Fdt_LKE("PHT_MA_DVI_XEM_QUYEN");
    }
    ///<summary>Liệt kê</summary>
    public static object[] Faobj_MA_DVI_LKE(string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ten, b_tu, b_den }, "NR", "PHT_MA_DVI_LKE");
    }

    public static DataTable Fdt_MA_DVI_LKE3(string b_tim)
    {
        return dbora.Fdt_LKE_S(b_tim, "PHT_MA_DVI_LKE3");
    }

    public static DataTable Fdt_MA_DVI_LKE_CAY(string b_ma, string b_gt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_gt }, "PHT_MA_DVI_LKE_CAY");
    }

    /// <summary> Tim ma </summary>
    public static object[] Faobj_MA_DVI_MA(string b_ma, double b_TrangKt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_TrangKt }, "NNR", "PHT_MA_DVI_MA");
    }
    ///<summary>Chi tiet</summary>
    public static DataTable Fdt_MA_DVI_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PHT_MA_DVI_CT");
    }
    ///<summary>Hỏi tên theo b_nv và b_ma</summary>
    public static string Fs_MA_DVI_TEN(string b_nv, string b_ma)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_nv, b_ma }, 'U', "PHT_MA_DVI_TEN"));
    }
    /// <summary> Nhập </summary>
    public static void P_MA_DVI_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { chuyen.OBJ_S(b_dr_ct["ma"]), chuyen.OBJ_S(b_dr_ct["ten"]),
            chuyen.OBJ_S(b_dr_ct["ten_ta"]),chuyen.OBJ_S(b_dr_ct["ten_vt"]),b_dr_ct["sott"],chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_tl"])),
            chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_gt"])),chuyen.OBJ_S(b_dr_ct["ma_thue"]),chuyen.OBJ_S(b_dr_ct["sdt"]),chuyen.OBJ_S(b_dr_ct["ten_ql"]),chuyen.OBJ_S(b_dr_ct["ten_cdanh_ql"]),
            chuyen.OBJ_S(b_dr_ct["gpkd"]), chuyen.OBJ_S(b_dr_ct["dia_chi"]),chuyen.OBJ_S(b_dr_ct["ghi_chu"]), b_dr_ct["ma_ct"], chuyen.OBJ_N(b_dr_ct["cap"]) , chuyen.OBJ_S(b_dr_ct["logo"]), chuyen.OBJ_N(b_dr_ct["trang_thai"])  };
        dbora.P_GOIHAM(a_obj, "PHT_MA_DVI_NH");
    }

    ///<summary>Xóa</summary>
    public static void P_MA_DVI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHT_MA_DVI_XOA");
    }

    ///<summary>Liệt kê tất cả đơn vị người sử dụng quản lý</summary>
    public static DataTable Fdt_DVI_QLY()
    {
        return dbora.Fdt_LKE("PHT_DVI_QLY");
    }
}
