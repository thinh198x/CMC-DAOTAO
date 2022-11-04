using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_hdns
{

    #region MÃ NGHỀ NGHIỆP
    public static object[] Fdt_NS_HDNS_MA_NN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_NN_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NN_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NN_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NN_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_NN_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_NN_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NN_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_NN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NN_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_NN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NN_EXCEL");
    }
    public static void P_NS_HDNS_MA_NN_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_HDNS_MA_NN_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_NN_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NN_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_NN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_NN_XOA");
    }
    #endregion MÃ NGHỀ NGHIỆP

    #region MÃ CHUYÊN MÔN
    public static object[] Fdt_NS_HDNS_MA_CM_MA(string b_ma, string b_ma_nn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_ma_nn, b_trangkt }, "NNR", "PNS_HDNS_MA_CM_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CM_DROP_MA(string b_mann)
    {
        return dbora.Fdt_LKE_S(b_mann, "PNS_HDNS_MA_CM_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CM_DROP()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CM_DROP");
    }
    public static DataTable Fdt_NS_HDNS_MA_CM_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_MA_CM_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_CM_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CM_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_CM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_CM_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_CM_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CM_EXCEL");
    }
    public static void P_NS_HDNS_MA_CM_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_dr["so_id"]), b_dr["ma_nn"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_HDNS_MA_CM_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_CM_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { 0, b_dr["ma_nn"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_CM_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_CM_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_CM_XOA");
    }
    #endregion MÃ CHUYÊN MÔN

    #region MÃ NGẠCH NGHỀ NGHIỆP
    public static object[] Fdt_NS_HDNS_MA_NNN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_NNN_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NNN_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_DROP_MA_TT(string b_tt)
    {
        return dbora.Fdt_LKE_S(b_tt, "PNS_HDNS_MA_NNN_DROP_MA_TT");
    }
    public static DataTable Fdt_NS_HDNS_NNN_VTCD_DROP_MA(string b_mannn)
    {
        return dbora.Fdt_LKE_S(b_mannn, "PNS_HDNS_NNN_VTCD_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_NNN_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NNN_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_NNN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NNN_LKE");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NNN_EXCEL");
    }
    public static void P_NS_HDNS_MA_NNN_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_HDNS_MA_NNN_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_NNN_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NNN_NH");
        }
    }
    public static void P_NS_HDNS_MA_NNN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_NNN_XOA");
    }
    #endregion MÃ NGẠCH NGHỀ NGHIỆP

    #region MÃ BẬC NGHỀ NGHIỆP
    public static object[] Fdt_NS_HDNS_MA_CBNN_MA(string b_ma, string b_ma_nnn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_ma_nnn, b_trangkt }, "NNR", "PNS_HDNS_MA_CBNN_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CBNN_DROP_MA(string b_mannn)
    {
        return dbora.Fdt_LKE_S(b_mannn, "PNS_HDNS_MA_CBNN_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CBNN_DROP_MA_TT(string b_mannn, string b_tt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_mannn, b_tt }, "PNS_HDNS_MA_CBNN_DROP_MA_TT");
    }
    public static DataTable Fdt_NS_HDNS_MA_CBNN_DROP()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CBNN_DROP");
    }
    public static DataTable Fdt_NS_HDNS_MA_CBNN_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_MA_CBNN_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_CBNN_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CBNN_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_CBNN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_CBNN_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_CBNN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CBNN_EXCEL");
    }
    public static void P_NS_HDNS_MA_CBNN_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_dr["so_id"]), b_dr["ma_nnn"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_HDNS_MA_CBNN_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_CBNN_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { 0, b_dr["ma_nnn"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_CBNN_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_CBNN_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_CBNN_XOA");
    }
    #endregion MÃ BẬC NGHỀ NGHIỆP

    #region DANH MỤC VỊ TRÍ CHỨC DANH
    public static object[] Fdt_NS_HDNS_MA_VTCD_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_VTCD_MA");
    }

    public static DataTable Fdt_NS_HDNS_MA_VTCD_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_MA_VTCD_CT");
    }
    public static object[] Fdt_NS_HDNS_MA_VTCD_LKE(string b_nnn, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn, b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_VTCD_LKE");
    }
    public static object[] Fdt_NS_HDNS_MA_VTCD_LKE_NNN(double b_tu_n, double b_den_n, string b_nnn)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_nnn }, "NR", "PNS_HDNS_MA_VTCD_LKE_NNN");
    }

    public static object[] Fdt_NS_HDNS_CDANH_TK_LKE(string b_ma_nnn, string b_tt, string b_tentk)
    {
        return dbora.Faobj_LKE(new string[] { b_ma_nnn, b_tt, "N'" + b_tentk }, "NR", "PNS_HDNS_CDANH_TK_LKE");
    }

    public static object[] Fdt_NS_HDNS_CDANH_TK_EXCEL(string b_ma_nnn, string b_tt)
    {
        return dbora.Faobj_LKE(new string[] { b_ma_nnn, b_tt }, "NR", "PNS_HDNS_CDANH_TK_EXCEL");
    }

    public static object[] Fdt_NS_HDNS_CDANHDVI_TK_LKE(string b_phong, string b_ngay_hl)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl) }, "NR", "PNS_HDNS_CDANHDVI_TK_LKE");
    }

    public static DataTable Fdt_NS_HDNS_CDANH_DROP_LKE()
    {
        return dbora.Fdt_LKE("PNS_HDNS_CDANH_DROP_LKE");
    }
    public static DataTable Fdt_NS_HDNS_CDANH_DROP()
    {
        return dbora.Fdt_LKE("PNS_HDNS_CDANH_DROP");
    }
    public static string Fdt_NS_HDNS_MA_VTCD_MACMON(double b_so_id)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_so_id }, 'S', "PNS_HDNS_MA_VTCD_MACMON"));
    }
    public static string Fdt_NS_HDNS_MA_VTCD_MACBNN(double b_so_id)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_so_id }, 'S', "PNS_HDNS_MA_VTCD_MACBNN"));
    }
    public static DataTable Fdt_NS_HDNS_MA_CDANH_PHONG(string b_phong)
    {
        return dbora.Fdt_LKE_S(b_phong, "PNS_HDNS_MA_CDANH_PHONG");
    }
    public static void P_NS_HDNS_MA_VTCD_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0]; double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
            dbora.P_GOIHAM(new object[] { b_so_id, chuyen.OBJ_N(b_dr["ma_cm"]), chuyen.OBJ_N(b_dr["so_id_cbnn"]), b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_HDNS_MA_VTCD_NH");
        }
    }
    public static void P_NS_HDNS_MA_VTCD_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma_nnghe"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_VTCD_FILE_NH");
        }
    }
    public static void P_NS_HDNS_MA_VTCD_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_VTCD_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_VTCD_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_VTCD_EXPORT");
    }
    public static void P_NS_HDNS_MA_VTCD_DUYET(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["so_id"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_VTCD_DUYET");
        }
    }
    #endregion  DANH MỤC VỊ TRÍ CHỨC DANH

    #region NHNAM_BAI2
    public static object[] Fdt_NS_HDNS_NHNAM_BAI2_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_NHNAM_BAI2_MA");
    }
    public static DataTable Fdt_NS_HDNS_NHNAM_BAI2_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_NHNAM_BAI2_CT");
    }
    public static object[] Fdt_NS_HDNS_NHNAM_BAI2_LKE(string b_nnn, string ma_cd, string ten_cd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn, ma_cd, "N'" + ten_cd, b_tu_n, b_den_n }, "NR", "PNS_HDNS_NHNAM_BAI2_LKE");
    }
    public static void P_NS_HDNS_NHNAM_BAI2_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_HDNS_NHNAM_BAI2_NH");
        }
    }
    public static void P_NS_HDNS_NHNAM_BAI2_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_NHNAM_BAI2_XOA");
    }
    public static DataTable Fdt_NS_HDNS_NHNAM_BAI2_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_HDNS_NHNAM_BAI2_EXPORT");
    }
    public static DataTable Fdt_NS_HDNS_NHNAM_BAI2_LKE_ALL(string b_nnn, string ma_cd, string ten_cd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nnn, ma_cd, ten_cd }, "PNS_HDNS_NHNAM_BAI2_LKE_ALL" );
    }
    #endregion  NHNAM_BAI2

    #region NTDUC_BAI2
    public static object[] Fdt_NS_HDNS_NTDUC_BAI2_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_NTDUC_BAI2_MA");
    }
    public static DataTable Fdt_NS_HDNS_NTDUC_BAI2_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_NTDUC_BAI2_CT");
    }
    public static object[] Fdt_NS_HDNS_NTDUC_BAI2_LKE(   double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] {   "N'" +  b_tu_n, b_den_n }, "NR", "PNS_HDNS_NTDUC_BAI2_LKE");
    }
    public static void P_NS_HDNS_NTDUC_BAI2_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_HDNS_NTDUC_BAI2_NH");
        }
    }
    public static void P_NS_HDNS_NTDUC_BAI2_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_NTDUC_BAI2_XOA");
    }
    public static DataTable Fdt_NS_HDNS_NTDUC_BAI2_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_NTDUC_BAI2_EXPORT");
    }
   
    #endregion

    #region NHNAM_BAI3
    public static object[] Fdt_NS_HDNS_NHNAM_BAI3_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_NHNAM_BAI3_MA");
    }
    public static DataSet Fdt_NS_HDNS_NHNAM_BAI3_CT(string b_ma)
    {
        //return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_NHNAM_BAI3_CT");
        return dbora.Fds_LKE(b_ma, 2, "PNS_HDNS_NHNAM_BAI3_CT");
    }
    public static object[] Fdt_NS_HDNS_NHNAM_BAI3_LKE(string b_ngay_tu, string b_ngay_den, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den), b_tu_n, b_den_n }, "NR", "PNS_NHNAM_BAI3_LKE");
    }
    public static void P_NS_HDNS_NHNAM_BAI3_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"], b_dr["ng_qly"], b_dr["ma_tt"], b_dr["dia_chi"], b_dr["ghi_chu"] }, "PNS_HDNS_NHNAM_BAI3_NH");
        }
    }
    public static DataTable Fdt_NS_HDNS_NHNAM_BAI3_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_NHNAM_BAI3_DROP_MA");
    }
    public static void P_NS_HDNS_NHNAM_BAI3_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_NHNAM_BAI3_XOA");
    }
    public static DataTable Fdt_NS_HDNS_NHNAM_BAI3_EXPORT(string ngay_tu, string ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(ngay_tu), chuyen.CNG_SO(ngay_den) }, "PNS_HDNS_NHNAM_BAI3_EXPORT");
    }
    #endregion NHNAM_BAI3


    #region DANH MỤC VỊ TRÍ CHỨC DANH LVHOAN
    public static object[] Fdt_LVHOAN_BAI2_LKE(string b_nnn, string ma_cd, string ten_cd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn, ma_cd,"N'"+ten_cd, b_tu_n, b_den_n }, "NR", "PNS_LVHOAN_BAI2_LKE");
    }
    public static void P_LVHOAN_BAI2_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_LVHOAN_BAI2_NH");
        }
    }
    public static object[] Fdt_LVHOAN_BAI2_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_LVHOAN_BAI2_MA");
    }
    public static void P_LVHOAN_BAI2_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_LVHOAN_BAI2_XOA");
    }
    public static DataTable Fdt_LVHOAN_BAI2_EXPORT(string ma_cd, string ten_cd)
    {
        return dbora.Fdt_LKE_S(new object[] {ma_cd, ten_cd}, "PNS_LVHOAN_BAI2_EXPORT");
    }
    #endregion DANH MỤC VỊ TRÍ CHỨC DANH LVHOAN


    #region phòng ban lvhoan
    public static object[] Fdt_LVHOAN_BAI3_LKE(string b_ngay_tu, string b_ngay_den, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den), b_tu_n, b_den_n }, "NR", "PNS_LVHOAN_BAI3_LKE");
    }
    public static object[] Fdt_LVHOAN_BAI3_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_LVHOAN_BAI3_MA");
    }
    public static void P_LVHOAN_BAI3_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"], b_dr["ng_qly"], b_dr["ma_tt"], b_dr["dia_chi"], b_dr["ghichu"] }, "PNS_LVHOAN_BAI3_NH");
        }
    }
    public static DataTable Fdt_LVHOAN_BAI3_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_LVHOAN_BAI3_DROP_MA");
    }
    public static DataSet Fdt_LVHOAN_BAI3_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_LVHOAN_BAI3_CT");
    }
    public static DataTable Fdt_LVHOAN_BAI3_EXPORT(string b_ngay_tu, string b_ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den)}, "PNS_LVHOAN_BAI3_EXPORT");
    }
    public static void P_LVHOAN_BAI3_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_LVHOAN_BAI3_XOA");
    }
    #endregion

    #region Thiết lập đối tượng chấm công
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_HD_MA_DOITUONG_CC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_DOITUONG_CC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HD_MA_DOITUONG_CC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PHD_MA_DOITUONG_CC_MA");
    }

    /// <summary> Nhập </summary>
    public static void P_HD_MA_DOITUONG_CC_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { chuyen.OBJ_N(b_dr_ct["ma"]), chuyen.OBJ_S(b_dr_ct["cdanh"]),
            chuyen.OBJ_S(b_dr_ct["mien_td"]),chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_hl_td"])),
            chuyen.OBJ_S(b_dr_ct["mien_dmvs"]),chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_hl_dmvs"])),
            chuyen.OBJ_S(b_dr_ct["mien_onsite"]), chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_hl_onsite"])),
            chuyen.OBJ_S(b_dr_ct["mien_giochuan"]),chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_hl"])),
        };
        dbora.P_GOIHAM(a_obj, "PHD_MA_DOITUONG_CC_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_HD_MA_DOITUONG_CC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHD_MA_DOITUONG_CC_XOA");
    }
    #endregion MÃ CHỨC VỤ

    #region DANH MỤC VỊ TRÍ CHỨC DANH NHDO
    public static object[] Fdt_NS_HDNS_MA_VTCD_MA_NHDO(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DONH_BAI2_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_VTCD_CT_NHDO(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DONH_BAI2_CT");
    }
    public static object[] Fdt_NS_HDNS_MA_VTCD_LKE_NHDO(string b_nnn, string ma_cd, string ten_cd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn,ma_cd,"N'"+ten_cd, b_tu_n, b_den_n }, "NR", "PNS_DONH_BAI2_LKE");
    }
    public static object[] Fdt_NS_HDNS_MA_VTCD_LKE_NNN_NHDO(double b_tu_n, double b_den_n, string b_nnn)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_nnn }, "NR", "PNS_HDNS_MA_VTCD_LKE_NNN");
    }

    public static object[] Fdt_NS_HDNS_CDANH_TK_LKE_NHDO(string b_ma_nnn, string b_tt, string b_tentk)
    {
        return dbora.Faobj_LKE(new string[] { b_ma_nnn, b_tt, "N'" + b_tentk }, "NR", "PNS_HDNS_CDANH_TK_LKE");
    }

    public static object[] Fdt_NS_HDNS_CDANH_TK_EXCEL_NHDO(string b_ma_nnn, string b_tt)
    {
        return dbora.Faobj_LKE(new string[] { b_ma_nnn, b_tt }, "NR", "PNS_HDNS_CDANH_TK_EXCEL");
    }

    public static object[] Fdt_NS_HDNS_CDANHDVI_TK_LKE_NHDO(string b_phong, string b_ngay_hl)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl) }, "NR", "PNS_HDNS_CDANHDVI_TK_LKE");
    }

    public static DataTable Fdt_NS_HDNS_CDANH_DROP_LKE_NHDO()
    {
        return dbora.Fdt_LKE("PNS_HDNS_CDANH_DROP_LKE");
    }
    public static DataTable Fdt_NS_HDNS_CDANH_DROP_NHDO()
    {
        return dbora.Fdt_LKE("PNS_HDNS_CDANH_DROP");
    }
    public static string Fdt_NS_HDNS_MA_VTCD_MACMON_NHDO(double b_so_id)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_so_id }, 'S', "PNS_HDNS_MA_VTCD_MACMON"));
    }
    public static string Fdt_NS_HDNS_MA_VTCD_MACBNN_NHDO(double b_so_id)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_so_id }, 'S', "PNS_HDNS_MA_VTCD_MACBNN"));
    }
    public static DataTable Fdt_NS_HDNS_MA_CDANH_PHONG_NHDO(string b_phong)
    {
        return dbora.Fdt_LKE_S(b_phong, "PNS_HDNS_MA_CDANH_PHONG");
    }
    public static void P_NS_HDNS_MA_VTCD_NH_NHDO(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] {b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_DONH_BAI2_NH");
        }
    }
    public static void P_NS_HDNS_MA_VTCD_FILE_NH_NHDO(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma_nnghe"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_VTCD_FILE_NH");
        }
    }
    public static void P_NS_HDNS_MA_VTCD_XOA_NHDO(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DONH_BAI2_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_VTCD_EXPORT_NHDO(string b_nnn, string ma_cd, string ten_cd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nnn, ma_cd, ten_cd }, "PNS_DONH_BAI2_EXPORT");
    }
    public static void P_NS_HDNS_MA_VTCD_DUYET_NHDO(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["so_id"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_VTCD_DUYET");
        }
    }
    #endregion  DANH MỤC VỊ TRÍ CHỨC DANH NHDO

    #region BAI3_NHDO
    public static object[] Fdt_NS_HDNS_MA_VTCD_LKE_NHDO_BAI3(string b_ngay_tu, string b_ngay_den, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] {chuyen.CNG_SO(b_ngay_tu),chuyen.CNG_SO(b_ngay_den),b_tu_n,b_den_n}, "NR", "PNS_NHDO_BAI3_LKE");
    }
    public static object[] Fdt_NS_HDNS_MA_VTCD_MA_NHDO_BAI3(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NHDO_BAI3_MA");
    }
    public static DataSet Fdt_NS_HDNS_MA_VTCD_CT_NHDO_BAI3(string b_ma)
    {
        return dbora.Fds_LKE(b_ma,2, "PNS_NHDO_BAI3_CT");
    }
    public static object[] Fdt_NS_HDNS_MA_NHDO_BAI3(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NHDO_BAI3_MA");
    }


    public static DataTable Fdt_NS_HDNS_NHDO_BAI3_EXCEL()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_HDNS_GAN_CDANHDVI_EXCEL");
        bang.P_CSO_CNG(ref b_dt, "NGAY_HL");
        bang.P_THEM_COL(ref b_dt, "ten_tt", "");
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
            else b_dr["ten_tt"] = "Áp dụng";
        }
        return b_dt;
    }
    public static void P_NS_HDNS_NHDO_BAI3_NH(DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count > 0)
        {
            DataRow b_dr = b_dt_ct.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"], b_dr["ng_qly"], b_dr["ma_tt"], b_dr["dia_chi"], b_dr["ghi_chu"] }, "PNS_NHDO_BAI3_NH");
        }
    }
    public static void Fs_NS_HDNS_NHDO_BAI3_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"] + "'", b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_GAN_CDANHDVI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_NHDO_BT3_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_NHDO_BAI3_XOA");
    }

    public static DataTable Fdt_NS_HDNS_NHDO_BT3_DROP()
    {
        return dbora.Fdt_LKE("PNS_NHDO_BAI3_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_NHDO_BAI3_EXPORT(string ngay_tu, string ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(ngay_tu), chuyen.CNG_SO(ngay_den) }, "PNS_HDNS_NHDO_BAI3_EXPORT");
    }
    #endregion BAI3_NHDO

    //#region Thiết lập đối tượng nghề nghiêp
    ///// <summary>Liệt kê toàn bộ số liệu</summary>
    //public static object[] Fdt_HD_MA_NNNGHE_LKE(double b_tu_n, double b_den_n)
    //{
    //    return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_NNNGHE_LKE");
    //}
    /////<summary>liet ke sau kiem tra </summary>

    //public static object[] Fdt_HD_MA_NNNGHE_MA(string b_ma, double b_trangkt)
    //{
    //    return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PHD_MA_NNNGHE_MA");
    //}

    ///// <summary> Nhập </summary>
    //public static void P_HD_MA_NNNGHE_NH(DataTable b_dt_ct)
    //{
    //    DataRow b_dr_ct = b_dt_ct.Rows[0];
    //    object[] a_obj = new object[] { chuyen.OBJ_S(b_dr_ct["ma"]), chuyen.OBJ_S(b_dr_ct["cdanh"]), chuyen.OBJ_S(b_dr_ct["mien_td"]),chuyen.CNG_SO(chuyen.OBJ_S(b_dr_ct["ngay_hl"])), chuyen.OBJ_S(b_dr_ct["mien_dmvs"]), 
    //        chuyen.OBJ_S(b_dr_ct["mien_onsite"]), chuyen.OBJ_S(b_dr_ct["mien_giochuan"]) };
    //    dbora.P_GOIHAM(a_obj, "PHD_MA_NNNGHE_NH");
    //}
    /////<summary>Xóa</summary>
    //public static void P_HD_MA_NNNGHE_XOA(string b_ma)
    //{
    //    dbora.P_GOIHAM(b_ma, "PHD_MA_NNNGHE_XOA");
    //}
    //#endregion

    #region Thiết lập danh mục quỹ lương
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    ///    
    public static DataTable Fdt_HD_MA_QUYLUONG_LKEALL()
    {
        return dbora.Fdt_LKE("PHD_MA_QUYLUONG_LKEALL");
    }
    public static object[] Fdt_HD_MA_QUYLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_QUYLUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HD_MA_QUYLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PHD_MA_QUYLUONG_MA");

    }

    /// <summary> Nhập </summary>
    public static void P_HD_MA_QUYLUONG_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { chuyen.OBJ_N(b_dr_ct["so_id"]),
            chuyen.OBJ_S(b_dr_ct["nam_db"]),chuyen.OBJ_S(b_dr_ct["dvi"]),chuyen.OBJ_S(b_dr_ct["ma_cdanh"]),chuyen.OBJ_N(b_dr_ct["ns_ht"]),
            chuyen.OBJ_N(b_dr_ct["db_tb"]),chuyen.OBJ_N(b_dr_ct["db_ncong"]),chuyen.OBJ_N(b_dr_ct["db_ncong_td"]),
            chuyen.OBJ_N(b_dr_ct["tong_db_ncong"]),chuyen.OBJ_N(b_dr_ct["db_them_ncong"]),chuyen.OBJ_N(b_dr_ct["db_gio_td"]),
            chuyen.OBJ_N(b_dr_ct["db_tgio_tong"]),chuyen.OBJ_N(b_dr_ct["thuong_dnam"]),chuyen.OBJ_N(b_dr_ct["thuong_td"]),
            chuyen.OBJ_N(b_dr_ct["thuong_tong"]),chuyen.OBJ_N(b_dr_ct["db_ploi_td"]),chuyen.OBJ_N(b_dr_ct["quy_BHXH"]),
            chuyen.OBJ_N(b_dr_ct["quy_BHXH_TD"]),chuyen.OBJ_N(b_dr_ct["tong_BHXH"]),chuyen.OBJ_N(b_dr_ct["cd_td"]),
            chuyen.OBJ_N(b_dr_ct["quyl_tong"]),chuyen.OBJ_N(b_dr_ct["db_pc"]),chuyen.OBJ_N(b_dr_ct["db_pc_td"]),
            chuyen.OBJ_N(b_dr_ct["db_pc_td_tong"]),chuyen.OBJ_N(b_dr_ct["db_pl"]),chuyen.OBJ_N(b_dr_ct["db_pl_tong"]),
            chuyen.OBJ_N(b_dr_ct["quy_cd"]),chuyen.OBJ_N(b_dr_ct["quy_cd_tong"]),chuyen.OBJ_S(b_dr_ct["ghichu"]),
             };
        dbora.P_GOIHAM(a_obj, "PHD_MA_QUYLUONG_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_HD_MA_QUYLUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHD_MA_QUYLUONG_XOA");
    }
    #endregion MÃ CHỨC VỤ

    #region MÃ NGẠCH NGHỀ NGHIỆP
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HD_MA_NNNGHE_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHD_MA_NNNGHE_XEM");
    }

    public static object[] Fdt_HD_MA_NNNGHE_LKE(string b_day, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_day, b_tu_n, b_den_n }, "NR", "HD_MA_NNNGHE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static DataTable Fdt_HD_MA_NNGHIEP_MATEN()
    {
        return dbora.Fdt_LKE("PHD_MA_NNGHIEP_MA_TENNN");
    }
    public static object[] Fdt_HD_MA_NNNGHE_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "HD_MA_NNNGHE_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_HD_MA_NNNGHE_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "HD_MA_NNNGHE_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_HD_MA_NNNGHE_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "HD_MA_NNNGHE_XOA");
    }
    #endregion MÃ NGẠCH NGHỀ NGHIỆP

    #region CẤP BẬC NGHỀ NGHIỆP
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HD_MA_BNNGHE_LKE_ALL(string b_nnnghe)
    {
        return dbora.Fdt_LKE_S(b_nnnghe, "PHD_MA_BNNGHE_XEM");
    }
    public static DataTable Fdt_HD_MA_BNNGHE_MATEN()
    {
        return dbora.Fdt_LKE("PHD_MA_CAPBAC_MA_TENCB");
    }
    public static object[] Fdt_HD_MA_BNNGHE_LKE(string b_mannghe, string b_day, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_day, b_tu_n, b_den_n }, "NR", "PHD_MA_BNNGHE_LKE");
    }
    public static object[] Fdt_HD_MA_BNNGHE_MA_NNGIEP_LKE(string b_mannghe, string b_ma_nngiep, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_ma_nngiep, b_tu_n, b_den_n }, "NR", "PHD_MA_BNNGHE_MA_NNGIEP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    //public static object[] Fdt_HD_MA_BNNGHE_MA(string b_mannghe, string b_ma, double b_trangkt)
    //{
    //    return dbora.Faobj_LKE(new object[] { b_mannghe, b_ma, b_trangkt }, "NNR", "PHD_MA_BNNGHE_MA");
    //}
    public static object[] Fdt_HD_MA_BNNGHE_MA(string b_mannghe, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_trangkt }, "NNR", "PHD_MA_BNNGHE_MA");
    }
    public static object[] Fdt_HD_MA_BNNGHE_MA_CAP_BAC(string b_mannghe, string b_manngiep, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_manngiep, b_trangkt }, "NNR", "PHD_MA_BNNGHE_MA_CAP_BAC");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_HD_MA_BNNGHE_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma_nnnghe"], b_dr["ma_nngiep"], b_dr["cap_bac"], b_dr["tt"], b_dr["ghichu"] }, "PHD_MA_BNNGHE_NH");
        }
    }
    public static void P_HD_MA_BNNGHE_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma_nnnghe"], b_dr["ma_nngiep"], "N'" + b_dr["cap_bac"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PHD_MA_BNNGHE_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_HD_MA_BNNGHE_XOA(string b_mannghe, string b_manngiep, string b_capbac)
    {
        dbora.P_GOIHAM(new object[] { b_mannghe, b_manngiep, b_capbac }, "PHD_MA_BNNGHE_XOA");
    }
    #endregion CẤP BẬC NGHỀ NGHIỆP

    #region VỊ TRÍ MÃ CHỨC DANH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_CDANH_LKE_ALL(string b_ma_nnghe, string b_ma_cmon, string b_ma_nnnghe, string b_cap_bac)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_cap_bac }, "PNS_MA_CDANH_XEM");
    }

    public static DataTable Fdt_NS_MA_CAPBAC_XEM(string b_manl)
    {
        return dbora.Fdt_LKE_S(b_manl, "PNS_MA_CAPBAC_XEM");
    }

    public static DataTable Fdt_NS_MA_CMON_XEM(string b_mann)
    {
        return dbora.Fdt_LKE_S(b_mann, "PNS_MA_CMON_XEM");
    }
    public static DataTable Fs_NS_MA_CDANH_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_CDANH_LKE_ALL");
    }
    public static object[] Fs_NS_MA_CDANH_LKE(string b_ma_nnghe, string b_ma_cmon, string b_ma_nnnghe, string b_cap_bac, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_cap_bac, b_tu_n, b_den_n }, "NR", "PNS_MA_CDANH_LKE");
    }

    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CDANH_MA(string b_ma_nnghe, string b_ma_cmon, string b_ma_nnnghe, string b_cap_bac, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_cap_bac, b_ma, b_trangkt }, "NNR", "PNS_MA_CDANH_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static object[] P_NS_MA_CDANH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            return dbora.Faobj_LKE(new object[] { b_dr["ma_nnghe"], b_dr["ma_cmon"], b_dr["ma_nnnghe"], b_dr["ma_capbac"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], "" }, "N", "PNS_MA_CDANH_NH");
        }
        return null;
    }

    public static DataSet Fds_NS_MA_CDANH_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "PNS_MA_CDANH_CT");
    }
    public static void Fs_NS_MA_CDANH_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma_nnghe"], b_dr["ma_cmon"], b_dr["ma_nnnghe"], b_dr["ma_capbac"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"], "" };
            dbora.P_GOIHAM(a_obj, "PNS_MA_CDANH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_CDANH_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_MA_CDANH_XOA");
    }
    #endregion VỊ TRÍ MÃ CHỨC DANH

    #region VỊ TRÍ CHỨC DANH ĐƠN VỊ
    public static void P_NS_MA_CDANH_DUYET(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_ma_cdanh_duyet");
    }
    public static object[] Fdt_HD_CDANH_DVI_LKE(string b_donvi)
    {
        return dbora.Faobj_LKE(b_donvi, "R", "PHD_CDANH_DVI_LKE");
    }
    public static DataTable Fdt_CDANH_DVI_LKE_TEN()
    {
        return dbora.Fdt_LKE("PCDANH_DVI_LKE_TEN");
    }
    public static void P_Fs_HD_CDANH_DVI_NH(DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_donvi = bang.Fobj_COL_MANG(b_dt_db, "DONVI");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_db, "CDANH");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_db, "MA");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_db, "TEN");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_db, "TT");

            dbora.P_THEM_PAR(ref b_lenh, "b_donvi", 'S', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "b_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "b_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "b_tt", 'S', a_tt);

            string b_c = ",:b_donvi,:b_cdanh,:b_ma,:b_ten,:b_tt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHD_CDANH_DVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                //DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                //return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_HD_CDANH_DVI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHD_CDANH_DVI_XOA");
    }
    #endregion VỊ TRÍ CHỨC DANH ĐƠN VỊ

    #region HỆ THỐNG THANG LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HD_MA_HTTLUONG_DR()
    {
        return dbora.Fdt_LKE("PHD_MA_HTTLUONG_DR");
    }
    public static DataTable Fdt_HD_MA_HTTLUONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHD_MA_HTTLUONG_LKE_ALL");
    }
    public static object[] Fdt_HD_MA_HTTLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_HTTLUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HD_MA_HTTLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PHD_MA_HTTLUONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_HD_MA_HTTLUONG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["MA"], b_dr["TEN"], chuyen.OBJ_S(b_dr["ng_hluc"]), b_dr["ghichu"] }, "PHD_MA_HTTLUONG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_HD_MA_HTTLUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHD_MA_HTTLUONG_XOA");
    } 
    #endregion HỆ THỐNG THANG LƯƠNG

    #region DANH MỤC LEVEL CHỨC DANH

    public static DataTable Fdt_HDNS_MA_LVCDANH_DR()
    {
        return dbora.Fdt_LKE("PHDNS_MA_LVCDANH_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HDNS_MA_LVCDANH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHDNS_MA_LVCDANH_LKE_ALL");
    }

    public static object[] Fdt_HDNS_MA_LVCDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHDNS_MA_LVCDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HDNS_MA_LVCDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PHDNS_MA_LVCDANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_HDNS_MA_LVCDANH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["note"] }, "PHDNS_MA_LVCDANH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_HDNS_MA_LVCDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHDNS_MA_LVCDANH_XOA");
    }
    #endregion

    #region PHÂN LOẠI NHÂN VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HD_MA_LOAI_NV_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHD_MA_LOAI_NV_LKE_ALL");
    }
    public static object[] Fs_HD_MA_LOAI_NV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_LOAI_NV_LKE");
    }
    public static void P_HD_MA_LOAI_NV_NH(ref string b_so_id, DataTable b_dt_cdanh, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            DataRow b_dr = b_dt_ct.Rows[0];
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "so_id_cd");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cdanh", 'S', a_ma_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');
            string c = "," + chuyen.OBJ_N(b_so_id)
               + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["cap"]) + "," + chuyen.OBJ_C(b_dr["tt"])
                + "," + chuyen.OBJ_C(b_dr["ghichu"]) + ",:a_ma_cdanh,:b_so_id_out";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHD_MA_LOAI_NV_NH(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id_out"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_HD_MA_LOAI_NV_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_so_id), b_trangkt }, "NNR", "phd_ma_loai_nv_ma");
    }
    public static DataTable Fdt_HD_MA_LOAI_NV_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "PHD_MA_LOAI_NV_CT");
    }
    public static void P_HD_MA_LOAI_NV_XOA(string b_soid)
    {
        dbora.P_GOIHAM(new object[] { b_soid }, "PHD_MA_LOAI_NV_XOA");
    }
    #endregion

    #region[Tuyển dụng]
    public static DataTable Fdt_HD_MA_TUYENDUNG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHD_MA_TUYENDUNG_LKE_ALL");
    }
    public static DataTable Fdt_HD_MA_TUYENDUNG_LKE_DR(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(b_ncdanh, "PHD_MA_TUYENDUNG_LKE_DR");
    }
    public static string Fdt_HD_MA_TUYENDUNG_HOI(string b_cdanh, string b_ncdanh)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_cdanh, b_ncdanh }, "PHD_MA_TUYENDUNG_HOI");
        if (b_dt.Rows.Count == 0) return "loi:Chưa đăng ký mã chức danh:loi";
        else return b_dt.Rows[0][0].ToString() + "#" + b_dt.Rows[0][1];
    }

    public static object[] Fdt_HD_MA_TUYENDUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHD_MA_TUYENDUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HD_MA_TUYENDUNG_MA(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PHD_MA_TUYENDUNG_MA");
    }

    // Liet ke chi tiet
    public static DataTable Fdt_HD_MA_TUYENDUNG_CT(string b_ncdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_ncdanh), chuyen.OBJ_N(b_ma) }, "PHD_MA_TUYENDUNG_CT");
    }
    // Nhap so lieu
    public static object Fobj_HD_MA_TUYENDUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Fobj_LKE(new object[] { chuyen.OBJ_N(b_dr["SO_ID"]), b_dr["MA_CDANH"],chuyen.OBJ_S( b_dr["MON_I"]),b_dr["MON_I_DMAX"], b_dr["MON_I_DIEM"],
            chuyen.OBJ_S(b_dr["MON_II"]),b_dr["MON_II_DMAX"],b_dr["MON_II_DIEM"],
            chuyen.OBJ_S(b_dr["MON_III"]), b_dr["MON_III_DMAX"], b_dr["MON_III_DIEM"],b_dr["GHICHU"] }, 'N', "PHD_MA_TUYENDUNG_NH");

    }
    // Xoa so lieu
    public static void P_HD_MA_TUYENDUNG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PHD_MA_TUYENDUNG_XOA");
    }
    public static void P_HD_MA_TUYENDUNG_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { 0, b_dr["MA_CDANH"],chuyen.OBJ_S( b_dr["MON_I"]), chuyen.OBJ_N(b_dr["MON_I_DMAX"]), chuyen.OBJ_N(b_dr["MON_I_DIEM"]),
            chuyen.OBJ_S(b_dr["MON_II"]),chuyen.OBJ_N(b_dr["MON_II_DMAX"]),chuyen.OBJ_N( b_dr["MON_II_DIEM"]),
            chuyen.OBJ_S(b_dr["MON_III"]), chuyen.OBJ_N(b_dr["MON_III_DMAX"]), chuyen.OBJ_N(b_dr["MON_III_DIEM"]),b_dr["GHICHU"] };
            dbora.Fobj_LKE(a_obj, 'N', "PHD_MA_TUYENDUNG_NH");
        }
    }
    #endregion

    #region[GÁN NĂNG LỰC CHO VỊ TRÍ CHỨC DANH]
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_LKE_NL(string b_nhom_nl, string b_nang_luc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom_nl, b_nang_luc }, "PNS_LKE_NL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_LKE_NL_CDANH(string b_nhom, string b_nhom_nl, string b_nang_luc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom, b_nhom_nl, b_nang_luc }, "PNS_LKE_NL_CDANH");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable P_NL_NH(string b_nhom, string b_nhom_nl, string b_nangluc, DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_db, "muc_nl");
            dbora.P_THEM_PAR(ref b_lenh, "b_muc_nl", 'U', a_muc_nl);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_nhom) + "," + chuyen.OBJ_C(b_nhom_nl) + "," + chuyen.OBJ_C(b_nangluc) + ",:muc_nl,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NL_CD_XOA(string b_nhom, string b_nhom_nl, string b_nangluc)
    {
        dbora.P_GOIHAM(new object[] { b_nhom, b_nhom_nl, b_nangluc }, "PHD_NL_CD_XOA");
    }
    #endregion

    #region DANH MỤC CÁC KHOẢN HỖ TRỢ KHÁC (PHỤ CẤP)
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_MA_HTKHAC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_HTKHAC_LKE_ALL");
    }

    public static object[] Fdt_NS_HDNS_MA_HTKHAC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_HTKHAC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HDNS_MA_HTKHAC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_HTKHAC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_HTKHAC_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_HDNS_MA_HTKHAC", "MA");
            if (b_kiemtra == false)
            {
                b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("HTK", "NS_HDNS_MA_HTKHAC", "MA");
            }
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_N(b_dr["sotien"]), b_dr["hinhthuc"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_HDNS_MA_HTKHAC_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_HTKHAC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_HTKHAC_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_HTKHAC_P_IN()
    {
        //DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE("PNS_HDNS_MA_HTKHAC_IN");
    }

    public static DataTable Fdt_NS_HDNS_MA_HTKHAC_DROP()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_HTKHAC_DROP");
    }
    #endregion DANH MỤC CÁC KHOẢN HỖ TRỢ KHÁC (PHỤ CẤP)

    #region DANH MỤC THAM SỐ HỆ THỐNG LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_MA_TS_HTL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_TS_HTL_LKE_ALL");
    }
    public static object[] Fdt_NS_HDNS_MA_TS_HTL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_TS_HTL_LKE");
    }
    ///<summary>Liệt kê sau kiểm tra</summary>
    public static object[] Fdt_NS_HDNS_MA_TS_HTL_MA(string b_ma, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_MA_TS_HTL_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_HDNS_MA_TS_HTL_CT(string b_ma, string b_ngay_hl)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, chuyen.CNG_SO(b_ngay_hl) }, "PNS_HDNS_MA_TS_HTL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_TS_HTL_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_N(b_dr["sotien"]), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay_hl"])), b_dr["mota"] }, "PNS_HDNS_MA_TS_HTL_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_TS_HTL_XOA(string b_ma, string b_ngay_hl)
    {
        dbora.P_GOIHAM(new object[] { b_ma, chuyen.CNG_SO(b_ngay_hl) }, "PNS_HDNS_MA_TS_HTL_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_TS_HTL_P_IN()
    {
        //DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE("PNS_HDNS_MA_TS_HTL_IN");
    }
    #endregion DANH MỤC THAM SỐ HỆ THỐNG LƯƠNG

    #region DANH MỤC NGÀY NGHỈ LỄ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_MA_NGAYNGHI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NGAYNGHI_LKE_ALL");
    }
    public static object[] Fdt_NS_HDNS_MA_NGAYNGHI_LKE(string b_trangthai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_trangthai, b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NGAYNGHI_LKE");
    }
    ///<summary>Liệt kê sau kiểm tra</summary>
    public static object[] Fdt_NS_HDNS_MA_NGAYNGHI_MA(string b_ma, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_so_id, b_trangkt }, "NNR", "PNS_HDNS_MA_NGAYNGHI_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_HDNS_MA_NGAYNGHI_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_MA_NGAYNGHI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_NGAYNGHI_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]);
            b_c = b_c + "," + chuyen.OBJ_N(b_dr["tungay"]) + "," + chuyen.OBJ_N(b_dr["denngay"]) + "," + chuyen.OBJ_N(b_dr["so_ngay"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["mota"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_NGAYNGHI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_C(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_NGAYNGHI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_NGAYNGHI_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NGAYNGHI_P_IN()
    {
        //DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE("PNS_HDNS_MA_NGAYNGHI_IN");
    }
    #endregion DANH MỤC NGÀY NGHỈ LỄ

    #region MỨC NĂNG LỰC ĐƠN VỊ
    public static object[] Fdt_NS_HDNS_NLCDANH_DVI_LKE(string b_donvi)
    {
        return dbora.Faobj_LKE(b_donvi, "R", "PNS_HDNS_NLCDANH_DVI_LKE");
    }
    public static void P_Fs_NS_HDNS_NLCDANH_DVI_NH(DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_dvi = bang.Fobj_COL_MANG(b_dt_db, "dvi");
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_db, "so_id");
            object[] a_so_id_dg = bang.Fobj_COL_MANG(b_dt_db, "so_id_dg");
            object[] a_ma_phong = bang.Fobj_COL_MANG(b_dt_db, "ma_phong");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_db, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "b_dvi", 'S', a_dvi);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_dg", 'N', a_so_id_dg);
            dbora.P_THEM_PAR(ref b_lenh, "b_ma_phong", 'S', a_ma_phong);
            dbora.P_THEM_PAR(ref b_lenh, "b_ghichu", 'U', a_ghichu);
            string b_c = ",:b_dvi,:b_so_id,:b_so_id_dg,:b_ma_phong,:b_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_NLCDANH_DVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_HDNS_NLCDANH_DVI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_NLCDANH_DVI_XOA");
    }
    #endregion

    #region DANH MỤC NĂNG LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_HDNS_MA_NL_LKE(string b_day, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_HDNS_MA_NL_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_HDNS_MA_NL_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NL_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NL_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NL_CT_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NL_CT_MA");
    }
    public static void P_NS_HDNS_MA_NL_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_ma_nhom = chuyen.OBJ_C(b_dr["MA_NHOM"]);
            string b_ma = chuyen.OBJ_C(b_dr["MA"]);
            string b_ten = chuyen.OBJ_C(b_dr["TEN"]);
            string b_tt = chuyen.OBJ_C(b_dr["TT"]);
            string b_dinhnghia = chuyen.OBJ_C(b_dr["ghichu"]);

            bang.P_CSO_SO(ref b_dt_ct, "so_id_nl,so_id_ct");

            object[] a_so_id_nl = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl");
            object[] a_so_id_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_ct");
            object[] a_ten_muc_nl = bang.Fobj_COL_MANG(b_dt_ct, "ten_muc_nl");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_bieuhien = bang.Fobj_COL_MANG(b_dt_ct, "bieuhien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl", 'N', a_so_id_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ct", 'N', a_so_id_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_muc_nl", 'U', a_ten_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_bieuhien", 'U', a_bieuhien);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');

            string b_c = "," + chuyen.OBJ_N(b_so_id) + "," + b_ma_nhom + "," + b_ma + "," + b_ten + "," + b_tt + "," + b_dinhnghia + ",:a_so_id_nl,:a_so_id_ct,:a_ten_muc_nl,:a_mota,:a_bieuhien,:b_so_id_out";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_NL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id_out"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fdt_NS_HDNS_MA_NL_IMP_NH(DataTable b_dt_ct, DataTable b_dt_nl)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_key_ct = bang.Fobj_COL_MANG(b_dt_ct, "KEY");
            object[] a_ma_nh = bang.Fobj_COL_MANG(b_dt_ct, "MA_NHOM");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "MA");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "TEN");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "TT");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "GHICHU");

            object[] a_key_nl = bang.Fobj_COL_MANG(b_dt_nl, "KEY");
            object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_nl, "MUC_NL");
            object[] a_mo_ta = bang.Fobj_COL_MANG(b_dt_nl, "MOTA");
            object[] a_bieu_hien = bang.Fobj_COL_MANG(b_dt_nl, "BIEUHIEN");

            dbora.P_THEM_PAR(ref b_lenh, "a_key_ct", 'N', a_key_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nh", 'S', a_ma_nh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'S', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_nl", 'N', a_key_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl", 'U', a_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_mo_ta", 'U', a_mo_ta);
            dbora.P_THEM_PAR(ref b_lenh, "a_bieu_hien", 'U', a_bieu_hien);

            string b_c = ",:a_key_ct,:a_ma_nh,:a_ma,:a_ten,:a_tt,:a_ghichu,:a_key_nl,:a_muc_nl,:a_mo_ta,:a_bieu_hien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_NL_FILE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Liet ke chi tiet
    public static DataSet Fds_NS_HDNS_MA_NL_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_MA_NL_CT");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MA_NL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_MA_NL_XOA");
    }
    public static DataTable Fdt_NS_HDNS_NHOM_NL_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_NHOM_NL_XEM");
    }
    public static DataTable Fdt_NS_HDNS_MA_NL_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NL_EXCEL");
    }
    public static void Fs_NS_HDNS_MA_NL_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { 0, b_dr["ma_nhom"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"], b_dr["muc_nl"], "N'" + b_dr["mota"], "N'" + b_dr["bieuhien"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NL_NH");
        }
    }

    //public static void P_NS_HDNS_MA_VTCD_FILE_NH(DataTable b_dt_ct)
    //{
    //    object[] a_obj;
    //    foreach (DataRow b_dr in b_dt_ct.Rows)
    //    {
    //        a_obj = new object[] { b_dr["ma_nnghe"], b_dr["ma_cmon"], b_dr["ma_nnnghe"], b_dr["ma_capbac"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
    //        dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_VTCD_FILE_NH");
    //    }
    //}
    #endregion

    #region GAN CHUC DANH CHO DON VI
    public static object[] Fdt_NS_HDNS_GAN_CDANHDVI_MA(string b_phong, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_GAN_CDANHDVI_MA");
    }
    public static DataSet Fds_NS_HDNS_GAN_CDANHDVI_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_GAN_CDANHDVI_CT");
    } 
    public static object[] Fdt_NS_HDNS_GAN_CDANHDVI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_GAN_CDANHDVI_LKE");
    }

    public static DataTable Fdt_NS_HDNS_GAN_CDANHDVI_EXCEL()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_HDNS_GAN_CDANHDVI_EXCEL");
        bang.P_CSO_CNG(ref b_dt, "NGAY_HL");
        bang.P_THEM_COL(ref b_dt, "ten_tt", "");
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
            else b_dr["ten_tt"] = "Áp dụng";
        }
        return b_dt;
    } 
    public static void P_NS_HDNS_GAN_CDANHDVI_NH(DataTable b_dt, DataTable b_dt_cd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            string b_phong = chuyen.OBJ_C(b_dt.Rows[0]["PHONG"]);
            string b_ngay_hl = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL"]);
            object[] a_so_id_cd = bang.Fobj_COL_MANG(b_dt_cd, "SO_ID_CD");
            object[] a_ma_cd = bang.Fobj_COL_MANG(b_dt_cd, "MA_CD");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd", 'S', a_ma_cd);
            string b_c = "," + b_phong + "," + chuyen.CNG_SO(b_ngay_hl) + ",:a_so_id_cd,:a_ma_cd";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_GAN_CDANHDVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fs_NS_HDNS_GAN_CDANHDVI_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_GAN_CDANHDVI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_GAN_CDANHDVI_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_GAN_CDANHDVI_XOA");
    }
    #endregion GAN CHUC DANH CHO DON VI

    #region[BIẾN ĐỘNG BẢO HIỂM]

    public static object[] Fdt_NS_HDNS_MA_BD_BH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_BD_BH_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_BD_BH_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BD_BH_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_BD_BH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_BD_BH_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_BD_BH_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BD_BH_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_BD_BH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_BD_BH_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_BD_BH_EXCEL()
    {

        return dbora.Fdt_LKE("PNS_HDNS_MA_BD_BH_EXCEL");
    }
    public static void P_NS_HDNS_MA_BD_BH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ma_nhom_bd"], b_dr["tt"], b_dr["mota"] }, "PNS_HDNS_MA_BD_BH_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_BD_BH_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_BD_BH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_BD_BH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_BD_BH_XOA");
    }
    #endregion

    #region [DANH MỤC NHÓM BIẾN ĐỘNG BẢO HIỂM]
    public static DataTable Fdt_NS_HDNS_MA_NHOM_BD_BH_DROP_TT(string b_tt)
    {
        return dbora.Fdt_LKE_S(b_tt, "PNS_HDNS_MA_NHOM_BH_BD_DR");
    }
    public static object[] Fdt_NS_HDNS_MA_NHOM_BH_BD_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_NHOM_BH_BD_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_BH_BD_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_BH_BD_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_BH_BD_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_NHOM_BH_BD_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_BH_BD_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_BH_BD_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_NHOM_BH_BD_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NHOM_BH_BD_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_NHOM_BH_BD_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_BH_BD_EXCEL");
    }
    public static void P_NS_HDNS_MA_NHOM_BH_BD_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "PNS_HDNS_MA_NHOM_BH_BD_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_NHOM_BH_BD_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NHOM_BH_BD_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_NHOM_BH_BD_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_NHOM_BH_BD_XOA");
    }
    #endregion

    #region[CHẾ ĐỘ BẢO HIỂM]

    public static object[] Fdt_NS_HDNS_MA_CDO_BH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_CDO_BH_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CDO_BH_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CDO_BH_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_CDO_BH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_CDO_BH_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_CDO_BH_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CDO_BH_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_CDO_BH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_CDO_BH_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_CDO_BH_EXCEL()
    {

        return dbora.Fdt_LKE("PNS_HDNS_MA_CDO_BH_EXCEL");
    }
    public static void P_NS_HDNS_MA_CDO_BH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ma_nhom_cd"], b_dr["tong_ngay"], b_dr["muc_huong"], b_dr["tt"] }, "PNS_HDNS_MA_CDO_BH_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_CDO_BH_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_CDO_BH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_CDO_BH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_CDO_BH_XOA");
    }
    #endregion

    #region [NHÓM CHẾ ĐỘ BẢO HIỂM]
    public static object[] Fdt_NS_HDNS_MA_NHOM_CDO_BH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_NHOM_CDO_BH_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_CDO_BH_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_CDO_BH_DROP");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_CDO_BH_DROP_TT(string b_tt)
    {
        return dbora.Fdt_LKE_S(b_tt, "PNS_HDNS_MA_NHOM_CDO_BH_DR");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_CDO_BH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_NHOM_CDO_BH_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_NHOM_CDO_BH_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_CDO_BH_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_NHOM_CDO_BH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NHOM_CDO_BH_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_NHOM_CDO_BH_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NHOM_CDO_BH_EXCEL");
    }
    public static void P_NS_HDNS_MA_NHOM_CDO_BH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "PNS_HDNS_MA_NHOM_CDO_BH_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_NHOM_CDO_BH_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NHOM_CDO_BH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_NHOM_CDO_BH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_NHOM_CDO_BH_XOA");
    }
    #endregion

    #region [DANH MỤC TÊN LOẠI BẢO HIỂM TỰ NGUYỆN]
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_MA_BH_TN_LKE_DR()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BH_TN_LKE_DR");
    }
    public static DataTable Fdt_NS_HDNS_MA_BH_TN_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BH_TN_LKE_ALL");
    }
    public static object[] Fdt_NS_HDNS_MA_BH_TN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_BH_TN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HDNS_MA_BH_TN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_BH_TN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_BH_TN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["mota"] }, "PNS_HDNS_MA_BH_TN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MA_BH_TN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_BH_TN_XOA");
    }

    #endregion

    #region [DANH MỤC CHI PHÍ GÓI BẢO HIỂM TỰ NGUYỆN]
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_HDNS_GOI_BH_TN_LKE_DR(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "NS_HDNS_GOI_BH_TN_LKE_DR");
    }
    public static DataTable Fdt_NS_MA_CHIPHI_BH_TN_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BH_TN_LKE_ALL");
    }
    public static object[] Fdt_NS_MA_CHIPHI_BH_TN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CHIPHI_BH_TN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CHIPHI_BH_TN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CHIPHI_BH_TN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CHIPHI_BH_TN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["loai_bh"], b_dr["ma"], b_dr["ten"], b_dr["ngayd"], b_dr["ngayc"], b_dr["phibh_nam"], b_dr["mota"] }, "PNS_MA_CHIPHI_BH_TN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_CHIPHI_BH_TN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CHIPHI_BH_TN_XOA");
    }
    public static DataTable Fdt_NS_MA_CHIPHI_BH_TN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_MA_CHIPHI_BH_TN_EXCEL");
    }

    #endregion

    #region THIẾT LẬP ĐIỀU KIỆN HƯỞNG BẢO HIỂM TỰ NGUYỆN
    public static DataTable Fdt_NS_HDNS_GOI_BH_DR_MA(string b_loai_bh)
    {
        return dbora.Fdt_LKE_S(b_loai_bh, "PNS_HDNS_GOI_BH_DR_MA");
    }

    public static DataTable Fdt_NS_HDNS_TL_DK_BH_TN_XEM()
    {
        return dbora.Fdt_LKE("NS_HDNS_TL_DK_BH_TN_XEM");
    }
    public static DataSet Fdt_NS_HDNS_TL_DK_BH_TN_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 4, "PNS_HDNS_TL_DK_BH_TN_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_HDNS_TL_DK_BH_TN_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_HDNS_TL_DK_BH_TN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_HDNS_TL_DK_BH_TN_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_HDNS_TL_DK_BH_TN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_HDNS_TL_DK_BH_TN_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_cdanh, DataTable b_dt_level, DataTable b_dt_lhd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "ma_cd");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "ten");

            object[] a_ma_level_cdanh = bang.Fobj_COL_MANG(b_dt_level, "ma_level_cdanh");
            object[] a_ten_level_cdanh = bang.Fobj_COL_MANG(b_dt_level, "ten_level_cdanh");

            object[] a_ma_lhd = bang.Fobj_COL_MANG(b_dt_lhd, "ma_lhd");
            object[] a_ten_lhd = bang.Fobj_COL_MANG(b_dt_lhd, "ten_lhd");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cdanh", 'S', a_ma_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_level_cdanh", 'S', a_ma_level_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_level_cdanh", 'U', a_ten_level_cdanh);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_lhd", 'S', a_ma_lhd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_lhd", 'U', a_ten_lhd);

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');

            string b_c = "," + chuyen.OBJ_N(b_so_id) + "," + chuyen.OBJ_C(b_dr["loai_bh"]) + "," + chuyen.OBJ_C(b_dr["goi_bh"]) + ","
                + chuyen.OBJ_N(b_dr["thamnien"]) + "," + chuyen.OBJ_C(b_dr["nnnghiep"]) + "," + chuyen.OBJ_N(b_dr["ngayd"]) + ","
                + chuyen.OBJ_N(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_C(b_dr["ma_dvi"])
                + ",:a_ma_cdanh,:a_ten_cdanh,:a_ma_level_cdanh,:a_ten_level_cdanh,:a_ma_lhd,:a_ten_lhd,:b_so_id_out";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_TL_DK_BH_TN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id_out"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_HDNS_TL_DK_BH_TN_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_TL_DK_BH_TN_XOA");
    }
    public static DataTable Fdt_NS_HDNS_TL_DK_BH_TN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_TL_DK_BH_TN_EXCEL");
    }
    #endregion THIẾT LẬP ĐIỀU KIỆN HƯỞNG CMC CARE

    #region [NƠI KHÁM CHỮA BỆNH]
    public static object[] Fdt_NS_HDNS_MA_NOI_KHAMBENH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_NOI_KHAMBENH_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NOI_KHAMBENH_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NOI_KHAMBENH_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_NOI_KHAMBENH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_HDNS_MA_NOI_KHAMBENH_CT");
    }
    public static DataTable Fdt_NS_HDNS_MA_NOI_KHAMBENH_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NOI_KHAMBENH_XEM");
    }
    public static object[] Fdt_NS_HDNS_MA_NOI_KHAMBENH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_NOI_KHAMBENH_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_NOI_KHAMBENH_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NOI_KHAMBENH_EXCEL");
    }
    public static void P_NS_HDNS_MA_NOI_KHAMBENH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["diachi"], b_dr["tpho"], b_dr["qhuyen"], b_dr["tt"] }, "PNS_HDNS_MA_NOI_KHAMBENH_NH");
        }
    }
    public static void Fs_NS_HDNS_MA_NOI_KHAMBENH_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_MA_NOI_KHAMBENH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_MA_NOI_KHAMBENH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_NOI_KHAMBENH_XOA");
    }
    #endregion

    #region THUẾ THU NHẬP CÁ NHÂN
    public static object[] Fdt_NS_HDNS_MA_TTNCN_MA(string b_dtg_ctru, double b_ngay_d, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_dtg_ctru, b_ngay_d, b_trangkt }, "NNR", "PNS_HDNS_MA_TTNCN_MA");
    }
    public static DataTable Fdt_NS_HDNS_MA_TTNCN_CT(string b_dtg_ctru, double b_ngay_d)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dtg_ctru, b_ngay_d }, "PNS_HDNS_MA_TTNCN_CT");
    }
    public static object[] Fdt_NS_HDNS_MA_TTNCN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_TTNCN_LKE");
    }

    public static DataTable Fdt_NS_HDNS_MA_TTNCN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_TTNCN_EXCEL");
    }
    public static void P_NS_HDNS_MA_TTNCN_NH(string b_dtg_ctru, double b_ngay_d, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_tien_tu = bang.Fobj_COL_MANG(b_dt, "tien_tu");
            object[] a_tien_den = bang.Fobj_COL_MANG(b_dt, "tien_den");
            object[] a_ty_le = bang.Fobj_COL_MANG(b_dt, "ty_le");

            dbora.P_THEM_PAR(ref b_lenh, "a_tien_tu", 'N', a_tien_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien_den", 'N', a_tien_den);
            dbora.P_THEM_PAR(ref b_lenh, "a_ty_le", 'N', a_ty_le);

            string b_c = "," + chuyen.OBJ_C(b_dtg_ctru) + "," + b_ngay_d + ",:a_tien_tu,:tien_den,:ty_le";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_TTNCN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_HDNS_MA_TTNCN_XOA(string b_dtg_ctru, double b_ngay_d)
    {
        dbora.P_GOIHAM(new object[] { b_dtg_ctru, b_ngay_d }, "PNS_HDNS_MA_TTNCN_XOA");
    }
    #endregion THUẾ THU NHẬP CÁ NHÂN

    #region [GÁN VỊ TRÍ MTCV SỬ DỤNG CHO MỖI ĐƠN VỊ]
    public static object[] Fdt_NS_HDNS_GAN_MTCVDVI_MA(string b_phong, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_GAN_MTCVDVI_MA");
    }
    public static DataSet Fds_NS_HDNS_GAN_MTCVDVI_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_GAN_MTCVDVI_CT");
    }

    public static DataSet Fdt_NS_HDNS_GAN_MTCV_MAU()
    {
        DataSet b_ds = dbora.Fds_LKE(3, "PNS_HDNS_GAN_MTCV_MAU");
        return b_ds;
    }

    public static DataTable Fdt_NS_HDNS_GAN_MTCVDVI_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_GAN_MTCVDVI_XEM");
    }
    public static object[] Fdt_NS_HDNS_GAN_MTCVDVI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_GAN_MTCVDVI_LKE");
    }


    public static DataSet Fdt_NS_HDNS_GAN_MTCV_IN(double b_so_id, double b_so_id_mtcv)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id, b_so_id_mtcv }, 2, "PNS_HDNS_GAN_MTCV_IN");
        DataTable b_dt = b_ds.Tables[0];
        bang.P_SO_CNG(ref b_dt, "NGAY_BH,NGAY_SD");
        return b_ds;
    }

    public static DataTable Fdt_NS_HDNS_GAN_MTCV_EXCEL()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_HDNS_GAN_MTCV_EXCEL");
        bang.P_SO_CNG(ref b_dt, "NGAY_HL");
        return b_dt;
    }
    public static void P_NS_HDNS_GAN_MTCVDVI_NH(DataTable b_dt, DataTable b_dt_cd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            double b_so_id = chuyen.OBJ_N(b_dt.Rows[0]["SO_ID"]);
            string b_phong = chuyen.OBJ_C(b_dt.Rows[0]["PHONG"]);
            string b_ngay_hl = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL"]);
            object[] a_so_id_mtcv = bang.Fobj_COL_MANG(b_dt_cd, "SO_ID_MTCV");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_mtcv", 'N', a_so_id_mtcv);
            string b_c = "," + b_so_id + "," + b_phong + "," + chuyen.CNG_SO(b_ngay_hl) + ",:a_so_id_mtcv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_GAN_MTCVDVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_HDNS_GAN_MTCVDVI_IMPORT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt, "NGAY_HL");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "PHONG");
            object[] a_ngay_hl = bang.Fobj_COL_MANG(b_dt, "NGAY_HL");
            object[] a_so_id_mtcv = bang.Fobj_COL_MANG(b_dt, "SO_ID_MTCV");
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_mtcv", 'N', a_so_id_mtcv);
            string b_c = ",:a_phong,:a_ngay_hl,:a_so_id_mtcv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_GAN_MTCVDVI_IMPORT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_QHE_IMPORT(DataTable b_dt, string b_so_the)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt, new string[] { "ngaysinh", "ngayd", "ngayc", "ngay_cmt" });
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_lqhe = bang.Fobj_COL_MANG(b_dt, "lqhe");
            object[] a_ngaysinh = bang.Fobj_COL_MANG(b_dt, "ngaysinh");
            object[] a_n_ngh = bang.Fobj_COL_MANG(b_dt, "n_ngh");
            object[] a_dchi = bang.Fobj_COL_MANG(b_dt, "dchi");
            object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt, "phuthuoc");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_note = bang.Fobj_COL_MANG(b_dt, "note");
            object[] a_so_cmt = bang.Fobj_COL_MANG(b_dt, "so_cmt");
            object[] a_ngay_cmt = bang.Fobj_COL_MANG(b_dt, "ngay_cmt");
            object[] a_so = bang.Fobj_COL_MANG(b_dt, "so");
            object[] a_quyenso = bang.Fobj_COL_MANG(b_dt, "quyenso");
            object[] a_nn = bang.Fobj_COL_MANG(b_dt, "nn");
            object[] a_tinhthanh = bang.Fobj_COL_MANG(b_dt, "tinhthanh");
            object[] a_quanhuyen = bang.Fobj_COL_MANG(b_dt, "quanhuyen");
            object[] a_phuongxa = bang.Fobj_COL_MANG(b_dt, "phuongxa");
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_lqhe", 'S', a_lqhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh", 'N', a_ngaysinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_n_ngh", 'U', a_n_ngh);
            dbora.P_THEM_PAR(ref b_lenh, "a_dchi", 'U', a_dchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'S', a_phuthuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_cmt", 'S', a_so_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cmt", 'N', a_ngay_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so", 'S', a_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_quyenso", 'S', a_quyenso);
            dbora.P_THEM_PAR(ref b_lenh, "a_nn", 'S', a_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhthanh", 'S', a_tinhthanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhuyen", 'S', a_quanhuyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuongxa", 'S', a_phuongxa);
            string b_c = "," + chuyen.OBJ_C(b_so_the) + ",:a_ten,:a_lqhe,:a_ngaysinh,:a_n_ngh,:a_dchi,:a_phuthuoc,:a_ngayd,:a_ngayc,:a_note";
            b_c += ",:a_so_cmt,:a_ngay_cmt,:a_so,:a_quyenso,:a_nn,:a_tinhthanh,:a_quanhuyen,:a_phuongxa";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QH_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fs_NS_HDNS_GAN_MTCVDVI_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_GAN_MTCVDVI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_GAN_MTCVDVI_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_GAN_MTCVDVI_XOA");
    }
    #endregion

    #region [ĐỐI TƯỢNG CHẤM CÔNG]
    public static void P_NS_CC_DTCC_NH(DataTable b_dt, DataTable b_dt_mtd, DataTable b_dt_dmvs, DataTable b_dt_onsite, DataTable b_dt_kg)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            double b_so_id = chuyen.OBJ_N(b_dt.Rows[0]["SO_ID"]);
            string b_phong = chuyen.OBJ_C(b_dt.Rows[0]["PHONG"]);
            string b_mtd = chuyen.OBJ_C(b_dt.Rows[0]["MTD"]);
            string b_dmvs = chuyen.OBJ_C(b_dt.Rows[0]["DMVS"]);
            string b_onsite = chuyen.OBJ_C(b_dt.Rows[0]["ONSITE"]);
            string b_kg = chuyen.OBJ_C(b_dt.Rows[0]["KG"]);

            string b_ngay_hl_mtd = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL_MTD"]);
            string b_ngay_hl_dmvs = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL_DMVS"]);
            string b_ngay_hl_onsite = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL_ONSITE"]);
            string b_ngay_hl_kg = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL_KG"]);


            object[] a_ma_cd_mtd = bang.Fobj_COL_MANG(b_dt_mtd, "MA_CD");
            object[] a_ma_cd_dmvs = bang.Fobj_COL_MANG(b_dt_dmvs, "MA_CD");
            object[] a_ma_cd_onsite = bang.Fobj_COL_MANG(b_dt_onsite, "MA_CD");
            object[] a_ma_cd_kg = bang.Fobj_COL_MANG(b_dt_kg, "MA_CD");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd_mtd", 'S', a_ma_cd_mtd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd_dmvs", 'S', a_ma_cd_dmvs);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd_onsite", 'S', a_ma_cd_onsite);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd_kg", 'S', a_ma_cd_kg);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', 'O', b_so_id);

            string b_c = "," + b_phong + "," + b_mtd + "," + b_dmvs + "," + b_onsite + "," + b_kg + ","
                + chuyen.CNG_SO(b_ngay_hl_mtd) + "," + chuyen.CNG_SO(b_ngay_hl_dmvs) + "," + chuyen.CNG_SO(b_ngay_hl_onsite) + "," + chuyen.CNG_SO(b_ngay_hl_kg) + ",:a_ma_cd_mtd,:a_ma_cd_dmvs,:a_ma_cd_onsite,:a_ma_cd_kg,:a_so_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DTCC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static object[] Fobj_NS_CC_DTCC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_DTCC_LKE");
    }

    public static DataSet Fds_NS_CC_DTCC_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 5, "PNS_CC_DTCC_CT");
    }

    public static object[] Fdt_NS_CC_DTCC_MA(string b_phong, string b_mtd, string b_dmvs, string b_onsite, string b_kg, string b_ngay_hl_mtd,
        string b_ngay_hl_dmvs, string b_ngay_hl_onsite, string b_ngay_hl_kg, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong,b_mtd,b_dmvs,b_onsite,b_kg,
                chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl_mtd)),chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl_dmvs)),chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl_onsite)),chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl_kg)),b_trangkt }, "NNR", "PNS_CC_DTCC_MA");
    }

    public static void P_NS_CC_DTCC_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_CC_DTCC_XOA");
    }
    #endregion

    #region [GÁN NĂNG LỰC CHO CHỨC DANH]
    public static DataTable Fdt_NS_HDNS_GAN_NL_CDANH_EXCEL()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_HDNS_GAN_NL_CDANH_EXCEL");
        bang.P_SO_CNG(ref b_dt, "NGAY_HL");
        return b_dt;
    }
    public static DataTable Fdt_NS_HDNS_NNN_CDANH_DROP_MA(string b_mannn)
    {
        return dbora.Fdt_LKE_S(b_mannn, "PNS_HDNS_NNN_VTCD_DROP_MA");
    }
    public static DataTable Fdt_NS_HDNS_CDANH_LKE_DR(string b_nnnghiep)
    {
        return dbora.Fdt_LKE_S(b_nnnghiep, "PNS_HDNS_CDANH_LKE_DR");
    }
    public static object[] Fdt_NS_HDNS_GAN_NL_CDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_GAN_NL_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_HDNS_GAN_NL_CDANH_MA(string b_so_id, string b_nnnghiepId, string b_cdanhId, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_nnnghiepId, b_cdanhId, chuyen.CNG_CSO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_GAN_NL_CDANH_MA");
    }
    public static DataSet Fds_NS_HDNS_GAN_NL_CDANH_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_GAN_NL_CDANH_CT");
    }
    public static void PNS_HDNS_GAN_NL_CDANH_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_nnnghiep = chuyen.OBJ_C(b_dr["NNNGHIEP"]);
            string b_cdanh = chuyen.OBJ_C(b_dr["CDANH"]);
            //string b_ngay_hl = chuyen.CNG_CSO(b_dr["NGAY_HL"]);

            bang.P_CSO_SO(ref b_dt_ct, "so_id_ct,so_id_nl,so_id_nl_ct");

            object[] a_so_id_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_ct");
            object[] a_so_id_nl = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl");
            object[] a_so_id_nl_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl_ct");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ct", 'N', a_so_id_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl", 'N', a_so_id_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl_ct", 'N', a_so_id_nl_ct);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');

            string b_c = "," + chuyen.OBJ_N(b_so_id) + "," + b_nnnghiep + "," + b_cdanh + "," + chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["NGAY_HL"])) + ",:a_so_id_ct,:a_so_id_nl,:a_so_id_nl_ct,:b_so_id_out";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_GAN_NL_CDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id_out"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_GAN_NL_CDANH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_GAN_NL_CDANH_XOA");
    }
    #endregion

    #region BH TỰ NGUYỆN CÔNG TY
    public static object[] Fdt_NS_HDNS_BH_TN_CTY_MA(string b_phong, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_BH_TN_CTY_MA");
    }
    public static DataSet Fds_NS_HDNS_BH_TN_CTY_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_BH_TN_CTY_CT");
    }
    public static DataTable Fdt_NS_HDNS_BH_TN_CTY_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_BH_TN_CTY_XEM");
    }
    public static object[] Fdt_NS_HDNS_BH_TN_CTY_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_BH_TN_CTY_LKE");
    }

    public static DataTable Fdt_NS_HDNS_BH_TN_CTY_EXCEL()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_HDNS_BH_TN_CTY_EXCEL");
        bang.P_CSO_CNG(ref b_dt, "NGAY_HL");
        bang.P_THEM_COL(ref b_dt, "ten_tt", "");
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
            else b_dr["ten_tt"] = "Áp dụng";
        }
        return b_dt;
    }
    public static void P_NS_HDNS_BH_TN_CTY_NH(DataTable b_dt, DataTable b_dt_cd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            string b_phong = chuyen.OBJ_C(b_dt.Rows[0]["PHONG"]);
            string b_ngay_hl = chuyen.OBJ_S(b_dt.Rows[0]["NGAY_HL"]);
            object[] a_so_id_cd = bang.Fobj_COL_MANG(b_dt_cd, "SO_ID_CD");
            object[] a_ma_cd = bang.Fobj_COL_MANG(b_dt_cd, "MA_CD");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd", 'S', a_ma_cd);
            string b_c = "," + b_phong + "," + chuyen.CNG_SO(b_ngay_hl) + ",:a_so_id_cd,:a_ma_cd";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_BH_TN_CTY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fs_NS_HDNS_BH_TN_CTY_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_BH_TN_CTY_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_BH_TN_CTY_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_BH_TN_CTY_XOA");
    }
    #endregion BH TỰ NGUYỆN CÔNG TY

    #region GÁN NĂNG LỰC CHỨC DANH CHO ĐƠN VỊ

    public static DataSet Fdt_NS_HDNS_GAN_NLCD_DVI_EXCEL()
    {
        DataSet b_ds = dbora.Fds_LKE(2, "PNS_HDNS_GAN_NLCD_DVI_EXCEL");
        DataTable b_dt = b_ds.Tables[0];
        bang.P_SO_CNG(ref b_dt, "NGAY_HL");
        return b_ds;
    }

    public static object[] Fdt_NS_HDNS_GAN_NLCD_DVI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_GAN_NLCD_DVI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_HDNS_GAN_NLCD_DVI_MA(double b_so_id, string b_phong, string b_nnnghiep, string b_cdanh, string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_phong, b_nnnghiep, b_cdanh, chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_HDNS_GAN_NLCD_DVI_MA");
    }
    public static DataSet Fds_NS_HDNS_GAN_NLCD_DVI_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDNS_GAN_NLCD_DVI_CT");
    }

    public static DataTable Fds_NS_HDNS_GAN_NLCD_DVI_CHA(string b_nnnghiep, string b_cdanh, double b_ngay_hl)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nnnghiep, b_cdanh, b_ngay_hl }, "PNS_HDNS_GAN_NLCD_DVI_CHA");
    }

    public static void PNS_HDNS_GAN_NLCD_DVI_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_phong = chuyen.OBJ_C(b_dr["PHONG"]);
            string b_nnnghiep = chuyen.OBJ_C(b_dr["NNNGHIEP"]);
            string b_cdanh = chuyen.OBJ_C(b_dr["CDANH"]);
            double b_ngay_hl = chuyen.CNG_SO(b_dr["NGAY_HL"].ToString());

            bang.P_CSO_SO(ref b_dt_ct, "so_id,so_id_nl,so_id_nl_ct");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_id_nl = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl");
            object[] a_so_id_nl_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl_ct");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl", 'N', a_so_id_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl_ct", 'N', a_so_id_nl_ct);
            string b_c = ",:b_so_id," + b_phong + "," + b_nnnghiep + "," + b_cdanh + "," + b_ngay_hl + ",:a_so_id,:a_so_id_nl,:a_so_id_nl_ct";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_GAN_NLCD_DVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_GAN_NLCD_DVI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDNS_GAN_NLCD_DVI_XOA");
    }

    #endregion GÁN NĂNG LỰC CHỨC DANH CHO ĐƠN VỊ

    #region KẾ HOẠCH QUỸ LƯƠNG

    public static DataTable Fdt_NS_HDNS_KHNS_QLG_EXCEL(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_HDNS_KHNS_QLG_EXCEL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fobj_NS_HDNS_KHNS_QLG_LKE(double b_nam, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_tu_n, b_den_n }, "NR", "PNS_HDNS_KHNS_QLG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fobj_NS_HDNS_KHNS_QLG_MA(double b_nam, string b_phong, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_phong, b_trangkt }, "NNR", "PNS_HDNS_KHNS_QLG_MA");
    }
    public static DataSet Fds_NS_HDNS_KHNS_QLG_CT(double b_so_id, string b_phong, double b_ngay_d, double b_ngay_c)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id, b_phong, b_ngay_d, b_ngay_c }, 2, "PNS_HDNS_KHNS_QLG_CT");
        return b_ds;
    }
    public static DataTable Fds_NS_HDNS_KHNS_QLG_NEW(string b_phong, double b_ngay_d, double b_ngay_c)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, b_ngay_d, b_ngay_c }, "PNS_HDNS_KHNS_QLG_NEW");
        return b_dt;
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_KHNS_QLG_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id"),
                    a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the"),
                    a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten"),
                    a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh"),
                    a_loai_nv = bang.Fobj_COL_MANG(b_dt_ct, "loai_nv"),
                    a_tinhtrang = bang.Fobj_COL_MANG(b_dt_ct, "tinhtrang"),
                    a_thu_nhap = bang.Fobj_COL_MANG(b_dt_ct, "thu_nhap"),
                    a_luong_cb = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb"),
                    a_thuong = bang.Fobj_COL_MANG(b_dt_ct, "thuong"),
                    a_thu_nhap_kh = bang.Fobj_COL_MANG(b_dt_ct, "thu_nhap_kh"),
                    a_luong_cb_kh = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb_kh"),
                    a_thuong_kh = bang.Fobj_COL_MANG(b_dt_ct, "thuong_kh"),
                    a_ngay_d_nam = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d_nam"),
                    a_ngay_td = bang.Fobj_COL_MANG(b_dt_ct, "ngay_td"),
                    a_ngay_c_nam = bang.Fobj_COL_MANG(b_dt_ct, "ngay_c_nam"),
                    a_thang_lv_dk = bang.Fobj_COL_MANG(b_dt_ct, "thang_lv_dk"),
                    a_thang_tn = bang.Fobj_COL_MANG(b_dt_ct, "thang_tn"),
                    a_thang_tn_td = bang.Fobj_COL_MANG(b_dt_ct, "thang_tn_td"),
                    a_tyle_lc = bang.Fobj_COL_MANG(b_dt_ct, "tyle_lc"),
                    a_tyle_tnx = bang.Fobj_COL_MANG(b_dt_ct, "tyle_tnx"),
                    a_tyle_dl = bang.Fobj_COL_MANG(b_dt_ct, "tyle_dl"),
                    a_tyle_pt = bang.Fobj_COL_MANG(b_dt_ct, "tyle_pt"),
                    a_phucap1 = bang.Fobj_COL_MANG(b_dt_ct, "phucap1"),
                    a_phucap2 = bang.Fobj_COL_MANG(b_dt_ct, "phucap2"),
                    a_phucap3 = bang.Fobj_COL_MANG(b_dt_ct, "phucap3"),
                    a_kh_bh = bang.Fobj_COL_MANG(b_dt_ct, "kh_bh"),
                    a_phi_cd = bang.Fobj_COL_MANG(b_dt_ct, "phi_cd"),
                    a_tongquy_tnt = bang.Fobj_COL_MANG(b_dt_ct, "tongquy_tnt"),
                    a_tong_pc = bang.Fobj_COL_MANG(b_dt_ct, "tong_pc"),
                    a_tong_thuong_nx = bang.Fobj_COL_MANG(b_dt_ct, "tong_thuong_nx"),
                    a_tong_chi_pl = bang.Fobj_COL_MANG(b_dt_ct, "tong_chi_pl"),
                    a_tong_tn_dk = bang.Fobj_COL_MANG(b_dt_ct, "tong_tn_dk");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_nv", 'S', a_loai_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang", 'S', a_tinhtrang);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap", 'N', a_thu_nhap);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong", 'N', a_thuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap_kh", 'N', a_thu_nhap_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb_kh", 'N', a_luong_cb_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong_kh", 'N', a_thuong_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d_nam", 'N', a_ngay_d_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_td", 'N', a_ngay_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_c_nam", 'N', a_ngay_c_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_lv_dk", 'N', a_thang_lv_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn", 'N', a_thang_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn_td", 'N', a_thang_tn_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_lc", 'N', a_tyle_lc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_tnx", 'N', a_tyle_tnx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_dl", 'N', a_tyle_dl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_pt", 'N', a_tyle_pt);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap1", 'N', a_phucap1);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap2", 'N', a_phucap2);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap3", 'N', a_phucap3);
            dbora.P_THEM_PAR(ref b_lenh, "a_kh_bh", 'N', a_kh_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phi_cd", 'N', a_phi_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongquy_tnt", 'N', a_tongquy_tnt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_pc", 'N', a_tong_pc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_thuong_nx", 'N', a_tong_thuong_nx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_chi_pl", 'N', a_tong_chi_pl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_tn_dk", 'N', a_tong_tn_dk);

            string b_c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_N(b_dr["thang_d"]) + "," + chuyen.OBJ_N(b_dr["thang_c"]) + "," + chuyen.OBJ_N(b_dr["tong_cdanh"]) + "," + chuyen.OBJ_N(b_dr["tong_tn_dkien"])
                + ",:a_so_id,:a_so_the,:a_ten,:a_cdanh,:a_loai_nv,:a_tinhtrang,:a_thu_nhap,:a_luong_cb,:a_thuong,:a_thu_nhap_kh,:a_luong_cb_kh"
                + ",:a_thuong_kh,:a_ngay_d_nam,:a_ngay_td,:a_ngay_c_nam,:a_thang_lv_dk,:a_thang_tn,:a_thang_tn_td,:a_tyle_lc,:a_tyle_tnx"
                + ",:a_tyle_dl,:a_tyle_pt,:a_phucap1,:a_phucap2,:a_phucap3,:a_kh_bh,:a_phi_cd,:a_tongquy_tnt,:a_tong_pc,:a_tong_thuong_nx,:a_tong_chi_pl,:a_tong_tn_dk";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_KHNS_QLG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }

    private class NamPhong
    {
        public double nam;
        public string phong;
        public int tongChucDanh;
        public double tongThuNhapDuKien;
        public NamPhong(double b_nam, string b_phong)
        {
            nam = b_nam;
            phong = b_phong;
            tongChucDanh = 0;
            tongThuNhapDuKien = 0;
        }
    }
    public static void P_NS_HDNS_KHNS_QLG_FILE_NH(DataTable b_dt)
    {
        bang.P_THEM_COL(ref b_dt, "tong_cdanh", typeof(double));
        bang.P_THEM_COL(ref b_dt, "tong_tn_dkien", typeof(double));
        int[] a_nam_cha = bang.Fi_COL_MANG(b_dt, "NAM");
        string[] a_phong_cha = bang.Fs_COL_MANG(b_dt, "PHONG");
        List<NamPhong> lstPhong = new List<NamPhong>();
        for (int i = 0; i < a_nam_cha.Length; i++)
        {
            NamPhong b_NamPhong = lstPhong.Find(x => x.nam == a_nam_cha[i] && x.phong == a_phong_cha[i]);
            if (b_NamPhong == null)
            {
                lstPhong.Add(new NamPhong(a_nam_cha[i], a_phong_cha[i]));
            }
        }
        foreach (NamPhong b_NamPhong in lstPhong)
        {
            DataTable b_dt_con = bang.Fdt_TAO_BANG(b_dt, new string[] { "nam", "phong" }, new object[] { b_NamPhong.nam, b_NamPhong.phong });
            b_NamPhong.tongThuNhapDuKien = bang.Fn_TIM_TONG(b_dt_con, "tong_tn_dk");
            string[] a_cdanh_phong = bang.Fs_COL_MANG(b_dt_con, "cdanh");
            ArrayList a_cdanh_count = new ArrayList();
            for (int i = 0; i < a_cdanh_phong.Length; i++)
            {
                if (a_cdanh_count.IndexOf(a_cdanh_phong[i]) < 0)
                {
                    a_cdanh_count.Add(a_cdanh_phong[i]);
                    b_NamPhong.tongChucDanh++;
                }
            }

            DataRow[] b_drs = b_dt.Select("nam = " + b_NamPhong.nam + " and phong = '" + b_NamPhong.phong + "'");
            foreach (DataRow b_dr in b_drs)
            {
                b_dr["tong_cdanh"] = b_NamPhong.tongChucDanh;
                b_dr["tong_tn_dkien"] = b_NamPhong.tongThuNhapDuKien;
            }
        }

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_thang_d = bang.Fobj_COL_MANG(b_dt, "thang_d");
            object[] a_thang_c = bang.Fobj_COL_MANG(b_dt, "thang_c");
            object[] a_tong_cdanh = bang.Fobj_COL_MANG(b_dt, "tong_cdanh");
            object[] a_tong_tn_dkien = bang.Fobj_COL_MANG(b_dt, "tong_tn_dkien");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_loai_nv = bang.Fobj_COL_MANG(b_dt, "loai_nv");
            object[] a_thu_nhap = bang.Fobj_COL_MANG(b_dt, "thu_nhap");
            object[] a_luong_cb = bang.Fobj_COL_MANG(b_dt, "luong_cb");
            object[] a_thuong = bang.Fobj_COL_MANG(b_dt, "thuong");
            object[] a_thu_nhap_kh = bang.Fobj_COL_MANG(b_dt, "thu_nhap_kh");
            object[] a_luong_cb_kh = bang.Fobj_COL_MANG(b_dt, "luong_cb_kh");
            object[] a_thuong_kh = bang.Fobj_COL_MANG(b_dt, "thuong_kh");
            object[] a_ngay_d_nam = bang.Fobj_COL_MANG(b_dt, "ngay_d_nam");
            object[] a_ngay_td = bang.Fobj_COL_MANG(b_dt, "ngay_td");
            object[] a_ngay_c_nam = bang.Fobj_COL_MANG(b_dt, "ngay_c_nam");
            object[] a_thang_lv_dk = bang.Fobj_COL_MANG(b_dt, "thang_lv_dk");
            object[] a_thang_tn = bang.Fobj_COL_MANG(b_dt, "thang_tn");
            object[] a_thang_tn_td = bang.Fobj_COL_MANG(b_dt, "thang_tn_td");
            object[] a_tyle_lc = bang.Fobj_COL_MANG(b_dt, "tyle_lc");
            object[] a_tyle_tnx = bang.Fobj_COL_MANG(b_dt, "tyle_tnx");
            object[] a_tyle_dl = bang.Fobj_COL_MANG(b_dt, "tyle_dl");
            object[] a_tyle_pt = bang.Fobj_COL_MANG(b_dt, "tyle_pt");
            object[] a_phucap1 = bang.Fobj_COL_MANG(b_dt, "phucap1");
            object[] a_phucap2 = bang.Fobj_COL_MANG(b_dt, "phucap2");
            object[] a_phucap3 = bang.Fobj_COL_MANG(b_dt, "phucap3");
            object[] a_kh_bh = bang.Fobj_COL_MANG(b_dt, "kh_bh");
            object[] a_phi_cd = bang.Fobj_COL_MANG(b_dt, "phi_cd");
            object[] a_tongquy_tnt = bang.Fobj_COL_MANG(b_dt, "tongquy_tnt");
            object[] a_tong_pc = bang.Fobj_COL_MANG(b_dt, "tong_pc");
            object[] a_tong_thuong_nx = bang.Fobj_COL_MANG(b_dt, "tong_thuong_nx");
            object[] a_tong_chi_pl = bang.Fobj_COL_MANG(b_dt, "tong_chi_pl");
            object[] a_tong_tn_dk = bang.Fobj_COL_MANG(b_dt, "tong_tn_dk");

            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_d", 'N', a_thang_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_c", 'N', a_thang_c);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_cdanh", 'N', a_tong_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_tn_dkien", 'N', a_tong_tn_dkien);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_nv", 'S', a_loai_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap", 'N', a_thu_nhap);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong", 'N', a_thuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap_kh", 'N', a_thu_nhap_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb_kh", 'N', a_luong_cb_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong_kh", 'N', a_thuong_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d_nam", 'N', a_ngay_d_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_td", 'N', a_ngay_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_c_nam", 'N', a_ngay_c_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_lv_dk", 'N', a_thang_lv_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn", 'N', a_thang_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn_td", 'N', a_thang_tn_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_lc", 'N', a_tyle_lc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_tnx", 'N', a_tyle_tnx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_dl", 'N', a_tyle_dl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_pt", 'N', a_tyle_pt);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap1", 'N', a_phucap1);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap2", 'N', a_phucap2);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap3", 'N', a_phucap3);
            dbora.P_THEM_PAR(ref b_lenh, "a_kh_bh", 'N', a_kh_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phi_cd", 'N', a_phi_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongquy_tnt", 'N', a_tongquy_tnt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_pc", 'N', a_tong_pc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_thuong_nx", 'N', a_tong_thuong_nx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_chi_pl", 'N', a_tong_chi_pl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_tn_dk", 'N', a_tong_tn_dk);

            string b_c = ",:a_nam,:a_phong,:a_thang_d,:a_thang_c,:a_tong_cdanh,:a_tong_tn_dkien"
                + ",:a_cdanh,:a_loai_nv,:a_thu_nhap,:a_luong_cb,:a_thuong,:a_thu_nhap_kh,:a_luong_cb_kh"
                + ",:a_thuong_kh,:a_ngay_d_nam,:a_ngay_td,:a_ngay_c_nam,:a_thang_lv_dk,:a_thang_tn,:a_thang_tn_td,:a_tyle_lc,:a_tyle_tnx"
                + ",:a_tyle_dl,:a_tyle_pt,:a_phucap1,:a_phucap2,:a_phucap3,:a_kh_bh,:a_phi_cd,:a_tongquy_tnt,:a_tong_pc,:a_tong_thuong_nx,:a_tong_chi_pl,:a_tong_tn_dk";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_KHNS_QLG_IMPORT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fds_NS_HDNS_KHNS_QLG_LS_CT(double b_nam, string b_phong)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_nam, b_phong }, 2, "PNS_HDNS_KHNS_QLG_LS_CT");
        return b_ds;
    }

    #endregion KẾ HOẠCH QUỸ LƯƠNG

    #region ĐỊNH BIÊN NHÂN SỰ
    public static DataTable Fdt_NS_HDNS_DBNS_EXCEL(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_HDNS_DBNS_EXCEL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fobj_NS_HDNS_DINHBIEN_NS_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_DINHBIEN_NS_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fobj_NS_HDNS_DINHBIEN_NS_MA(double b_nam, string b_phong, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_phong, b_trangkt }, "NNR", "PNS_HDNS_DINHBIEN_NS_MA");
    }
    public static DataSet Fds_NS_HDNS_DINHBIEN_NS_CT(double b_so_id, string b_phong, double b_ngay_d, double b_ngay_c)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id, b_phong, b_ngay_d, b_ngay_c }, 2, "PNS_HDNS_DINHBIEN_NS_CT");
        return b_ds;
    }
    public static DataTable Fds_NS_HDNS_DBNS_NEW(string b_phong, double b_ngay_d, double b_ngay_c)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, b_ngay_d, b_ngay_c }, "PNS_HDNS_DBNS_NEW");
        return b_dt;
    }
    public static void P_NS_HDNS_DINHBIEN_NS_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_nam = chuyen.OBJ_C(b_dr["NAM"]);
            string b_phong = chuyen.OBJ_C(b_dr["PHONG"]);

            bang.P_CSO_SO(ref b_dt_ct, "so_id_nl,so_id_ct");

            object[] a_so_id_nl = bang.Fobj_COL_MANG(b_dt_ct, "so_id_nl");
            object[] a_so_id_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_ct");
            object[] a_ten_muc_nl = bang.Fobj_COL_MANG(b_dt_ct, "ten_muc_nl");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            object[] a_bieuhien = bang.Fobj_COL_MANG(b_dt_ct, "bieuhien");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_nl", 'N', a_so_id_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ct", 'N', a_so_id_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_muc_nl", 'U', a_ten_muc_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);
            dbora.P_THEM_PAR(ref b_lenh, "a_bieuhien", 'U', a_bieuhien);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');

            string b_c = "," + chuyen.OBJ_N(b_so_id) + "," + chuyen.OBJ_N(b_nam) + "," + b_phong + ",:a_so_id_nl,:a_so_id_ct,:a_ten_muc_nl,:a_mota,:a_bieuhien,:b_so_id_out";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_NL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id_out"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_DINHBIEN_NS_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id"),
                    a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the"),
                    a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten"),
                    a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh"),
                    a_loai_nv = bang.Fobj_COL_MANG(b_dt_ct, "loai_nv"),
                    a_tinhtrang = bang.Fobj_COL_MANG(b_dt_ct, "tinhtrang"),
                    a_thu_nhap = bang.Fobj_COL_MANG(b_dt_ct, "thu_nhap"),
                    a_luong_cb = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb"),
                    a_thuong = bang.Fobj_COL_MANG(b_dt_ct, "thuong"),
                    a_thu_nhap_kh = bang.Fobj_COL_MANG(b_dt_ct, "thu_nhap_kh"),
                    a_luong_cb_kh = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb_kh"),
                    a_thuong_kh = bang.Fobj_COL_MANG(b_dt_ct, "thuong_kh"),
                    a_ngay_d_nam = bang.Fobj_COL_MANG(b_dt_ct, "ngay_d_nam"),
                    a_ngay_td = bang.Fobj_COL_MANG(b_dt_ct, "ngay_td"),
                    a_ngay_c_nam = bang.Fobj_COL_MANG(b_dt_ct, "ngay_c_nam"),
                    a_thang_lv_dk = bang.Fobj_COL_MANG(b_dt_ct, "thang_lv_dk"),
                    a_thang_tn = bang.Fobj_COL_MANG(b_dt_ct, "thang_tn"),
                    a_thang_tn_td = bang.Fobj_COL_MANG(b_dt_ct, "thang_tn_td"),
                    a_tyle_lc = bang.Fobj_COL_MANG(b_dt_ct, "tyle_lc"),
                    a_tyle_tnx = bang.Fobj_COL_MANG(b_dt_ct, "tyle_tnx"),
                    a_tyle_dl = bang.Fobj_COL_MANG(b_dt_ct, "tyle_dl"),
                    a_tyle_pt = bang.Fobj_COL_MANG(b_dt_ct, "tyle_pt"),
                    a_phucap1 = bang.Fobj_COL_MANG(b_dt_ct, "phucap1"),
                    a_phucap2 = bang.Fobj_COL_MANG(b_dt_ct, "phucap2"),
                    a_phucap3 = bang.Fobj_COL_MANG(b_dt_ct, "phucap3"),
                    a_kh_bh = bang.Fobj_COL_MANG(b_dt_ct, "kh_bh"),
                    a_phi_cd = bang.Fobj_COL_MANG(b_dt_ct, "phi_cd"),
                    a_tongquy_tnt = bang.Fobj_COL_MANG(b_dt_ct, "tongquy_tnt"),
                    a_tong_pc = bang.Fobj_COL_MANG(b_dt_ct, "tong_pc"),
                    a_tong_thuong_nx = bang.Fobj_COL_MANG(b_dt_ct, "tong_thuong_nx"),
                    a_tong_chi_pl = bang.Fobj_COL_MANG(b_dt_ct, "tong_chi_pl"),
                    a_tong_tn_dk = bang.Fobj_COL_MANG(b_dt_ct, "tong_tn_dk");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_nv", 'S', a_loai_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang", 'S', a_tinhtrang);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap", 'N', a_thu_nhap);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong", 'N', a_thuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thu_nhap_kh", 'N', a_thu_nhap_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb_kh", 'N', a_luong_cb_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong_kh", 'N', a_thuong_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d_nam", 'N', a_ngay_d_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_td", 'N', a_ngay_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_c_nam", 'N', a_ngay_c_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_lv_dk", 'N', a_thang_lv_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn", 'N', a_thang_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang_tn_td", 'N', a_thang_tn_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_lc", 'N', a_tyle_lc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_tnx", 'N', a_tyle_tnx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_dl", 'N', a_tyle_dl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle_pt", 'N', a_tyle_pt);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap1", 'N', a_phucap1);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap2", 'N', a_phucap2);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap3", 'N', a_phucap3);
            dbora.P_THEM_PAR(ref b_lenh, "a_kh_bh", 'N', a_kh_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phi_cd", 'N', a_phi_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongquy_tnt", 'N', a_tongquy_tnt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_pc", 'N', a_tong_pc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_thuong_nx", 'N', a_tong_thuong_nx);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_chi_pl", 'N', a_tong_chi_pl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_tn_dk", 'N', a_tong_tn_dk);

            string b_c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_N(b_dr["thang_d"]) + "," + chuyen.OBJ_N(b_dr["thang_c"]) + "," + chuyen.OBJ_N(b_dr["tong_cdanh"]) + "," + chuyen.OBJ_N(b_dr["tong_tn_dkien"])
                + ",:a_so_id,:a_so_the,:a_ten,:a_cdanh,:a_loai_nv,:a_tinhtrang,:a_thu_nhap,:a_luong_cb,:a_thuong,:a_thu_nhap_kh,:a_luong_cb_kh"
                + ",:a_thuong_kh,:a_ngay_d_nam,:a_ngay_td,:a_ngay_c_nam,:a_thang_lv_dk,:a_thang_tn,:a_thang_tn_td,:a_tyle_lc,:a_tyle_tnx"
                + ",:a_tyle_dl,:a_tyle_pt,:a_phucap1,:a_phucap2,:a_phucap3,:a_kh_bh,:a_phi_cd,:a_tongquy_tnt,:a_tong_pc,:a_tong_thuong_nx,:a_tong_chi_pl,:a_tong_tn_dk";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_DINHBIEN_NS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }

    #endregion ĐỊNH BIÊN NHÂN SỰ


    #region QUANG BAI 2
    public static object[] Fdt_NS_HDNS_QUANG_BAI2_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_QUANG_BAI2_MA");
    }

    public static DataTable Fdt_NS_HDNS_QUANG_BAI2_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_QUANG_BAI2_CT");
    }

    public static object[] Fdt_NS_HDNS_QUANG_BAI2_LKE(string b_nnn,string ma_cd,string ten_cd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn,ma_cd, ten_cd, b_tu_n, b_den_n }, "NR", "PNS_QUANG_BAI2_LKE");
    }

    public static void P_NS_HDNS_QUANG_BAI2_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] {b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_QUANG_BAI2_NH");
        }
    }

    public static void P_NS_HDNS_QUANG_BAI2_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_QUANG_BAI2_XOA");
    }

    public static DataTable Fdt_NS_HDNS_QUANG_BAI2_EXPORT(string b_nnn, string ma_cd,string ten_cd)
    {
        return dbora.Fdt_LKE_S(new object[] {b_nnn,ma_cd,ten_cd},"PNS_QUANG_BAI2_EXPORT");
    }

    #endregion



    #region QUANG BAI 3
    public static object[] Fdt_NS_HDNS_QUANG_BT3_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_QUANG_BAI3_MA");
    }
    public static DataSet Fds_NS_HDNS_QUANG_BT3_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_QUANG_BAI3_CT");
    }
    public static object[] Fdt_NS_HDNS_QUANG_BT3_LKE(string b_ngay_tu, string b_ngay_den, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den), b_tu_n, b_den_n }, "NR", "PNS_QUANG_BAI3_LKE");
    }

    public static DataTable Fdt_NS_HDNS_QUANG_BT3_EXPORT(string b_ngay_tu, string b_ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den) }, "PNS_QUANG_BAI3_EXPORT");
    }
    public static void P_NS_HDNS_QUANG_BT3_NH(DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count > 0)
        {
            DataRow b_dr = b_dt_ct.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"],b_dr["ng_qly"] , b_dr["ma_tt"], b_dr["dia_chi"] , b_dr["ghi_chu"] }, "PNS_QUANG_BAI3_NH");
        }
    }
    public static void Fs_NS_HDNS_QUANG_BT3_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"] +"'", b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_GAN_CDANHDVI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_QUANG_BT3_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_QUANG_BAI3_XOA");
    }

    public static DataTable Fdt_NS_HDNS_QUANG_BT3_DROP()
    {
        return dbora.Fdt_LKE("PNS_QUANG_BAI3_DROP");
    }
    #endregion

















    #region Danh mục chức danh LongBai2

    /// <summary>
    /// GetAll and search
    /// </summary>
    /// <param name="b_nnn"></param>
    /// <param name="b_ma_cd"></param>
    /// <param name="b_ten_cd"></param>
    /// <param name="b_tu_n"></param>
    /// <param name="b_den_n"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_HDNS_MA_VTCDLONGBAI2_LKE(string b_nnn, string b_ma_cd, string b_ten_cd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nnn, b_ma_cd, "N'"+b_ten_cd,  b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_VTCDLONGBAI2_LKE");
    }
 
    /// <summary>
    /// Trỏ vào mã khi nhập
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_NS_HDNS_MA_NNNLONGBAI2_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NNNLONG2_DROP_MA");
    }

    /// <summary>
    /// Post, Put
    /// </summary>
    /// <param name="b_dt"></param>
    public static void P_NS_HDNS_MA_VTCDLONGBAI2_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0]; 
            dbora.P_GOIHAM(new object[] {  b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"], b_dr["ma_nnn"] }, "PNS_HDNS_MA_VTCDLONGBAI2_NH");
        }
    }

    /// <summary>
    /// Page site Page index
    /// </summary>
    /// <param name="b_ma"></param>
    /// <param name="b_trangkt"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_HDNS_MA_VTCDLONGBAI2_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_VTCDLONGBAI2_MA");
    }

    /// <summary>
    /// Detail
    /// </summary>
    /// <param name="b_ma"></param>
    /// <returns></returns>
    public static DataSet Fdt_NS_HDNS_MA_VTCDLONGBAI2_CT(string b_ma)
    { 
        return dbora.Fds_LKE(b_ma, 2, "PNS_HDNS_MA_VTCDLONGBAI2_CT");
    }

    /// <summary>
    /// Export Excle
    /// </summary>
    /// <param name="b_nnn"></param>
    /// <param name="b_macd"></param>
    /// <param name="b_tencd"></param>
    /// <returns></returns>
    public static DataTable Fdt_NS_HDNS_MA_VTCDLONG_EXPORT1(string b_nnn, string b_macd, string b_tencd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nnn, b_macd, b_tencd }, "PNS_HDNS_MA_VTCDLONG2_EX");
    }

    /// <summary>
    /// Delele
    /// </summary>
    /// <param name="b_ma"></param>
    public static void P_NS_HDNS_MA_VTCDLONGBAI2_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_VTCDLONGBAI2_XOA");
    }
    #endregion



    #region Danh mục phòng ban Longbai3

    /// <summary>
    /// Get all and search
    /// </summary>
    /// <param name="b_ngayd"></param>
    /// <param name="b_ngayc"></param>
    /// <param name="b_tu_n"></param>
    /// <param name="b_den_n"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_PB_LONGBAI3_LKE( string b_ngayd, string b_ngayc,double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] {  chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_BDLONG_BAI3_LKE");
    }

    /// <summary>
    /// Get list Tinh Thanh
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_NS_PB_LONGBAI3_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_BDLONG_BAI3_DROP_MA");/* pns_bdlong_bai3_drop_ma*/
    }

    /// <summary>
    /// Detail
    /// </summary>
    /// <param name="b_ma"></param>
    /// <returns></returns>
    public static DataSet Fdt_NS_PB_LONGBAI3_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_BDLONG_BAI3_CT");
    }

    /// <summary>
    /// Trỏ vào mã khi nhập
    /// </summary>
    /// <param name="b_ma"></param>
    /// <param name="b_trangkt"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_PB_LONGBAI3_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_BDLONG_BAI3_MA");
    }

    /// <summary>
    /// Post, Put
    /// </summary>
    /// <param name="b_dt"></param>
    public static void P_NS_PB_LONGBAI3_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"], b_dr["ng_qly"], b_dr["ma_tt"], b_dr["dia_chi"], b_dr["ghichu"] }, "PNS_BDLONG_BAI3_NH");
        }
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="b_ma"></param>
    public static void P_NS_PB_LONGBAI3_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_BDLONG_BAI3_XOA");
    }

    /// <summary>
    /// Export Excel
    /// </summary>
    /// <param name="b_ngay_tu"></param>
    /// <param name="b_ngay_den"></param>
    /// <returns></returns>
    public static DataTable Fdt_NS_PB_LONGBAI3_EXPORT(string b_ngay_tu, string b_ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den) }, "PNS_BDLONG_BAI3_EXPORT");
    }
    #endregion
    #region  ntducbai3

    /// <summary>
    /// Get all and search
    /// </summary>
    /// <param name="b_ngayd"></param>
    /// <param name="b_ngayc"></param>
    /// <param name="b_tu_n"></param>
    /// <param name="b_den_n"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_PB_NTDUC_LKE(string b_ngayd, string b_ngayc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_NTDUC_BAI3_LKE");
    }

    /// <summary>
    /// Get list Tinh Thanh
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_NS_PB_NTDUC_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_NTDUC_BAI3_DROP_MA"); 
    }

    /// <summary>
    /// Detail
    /// </summary>
    /// <param name="b_ma"></param>
    /// <returns></returns>
    public static DataSet Fdt_NS_PB_NTDUC_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_NTDUC_BAI3_CT");
    }

    /// <summary>
    /// Trỏ vào mã khi nhập
    /// </summary>
    /// <param name="b_ma"></param>
    /// <param name="b_trangkt"></param>
    /// <returns></returns>
    public static object[] Fdt_NS_PB_NTDUC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NTDUC_BAI3_MA");
    }

    /// <summary>
    /// Post, Put
    /// </summary>
    /// <param name="b_dt"></param>
    public static void P_NS_PB_NTDUC_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ten_ta"], b_dr["ten_vt"], b_dr["ngay_tl"], b_dr["ngay_gt"], b_dr["ng_qly"], b_dr["ma_tt"], b_dr["dia_chi"], b_dr["ghi_chu"] }, "PNS_NTDUC_BAI3_NH");
        }
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="b_ma"></param>
    public static void P_NS_PB_NTDUC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_NTDUC_BAI3_XOA");
    }

    /// <summary>
    /// Export Excel
    /// </summary>
    /// <param name="b_ngay_tu"></param>
    /// <param name="b_ngay_den"></param>
    /// <returns></returns>
    public static DataTable Fdt_NS_PB_NTDUC_EXPORT(string b_ngay_tu, string b_ngay_den)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_tu), chuyen.CNG_SO(b_ngay_den) }, "PNS_NTDUC_BAI3_EXPORT");
    }
    #endregion
    #region duc4
    public static object[] Fdt_NTDUC_4_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n}, "NR", "PNS_NTDUC_BAI4_LKE");
    }
    public static DataSet Fdt_NTDUC_4_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_NTDUC_BAI4_CT");
    }

    public static void NTDUC_BAI4_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"],b_dr["ten"] ,b_dr["ngay_tl"],b_dr["ngay_ad"],b_dr["ma_cd"],b_dr["ghi_chu"]    }, "PNS_NTDUC_BAI4_NH");
        }
    }
    public static DataTable Fdt_NTDUC_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_NTDUC_BAI4_DROP_MA");
    }
    public static object[] Fdt_NTDUC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NTDUC_BAI4_MA");
    }
    public static void NTDUC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_NTDUC_BAI4_XOA");
    }
    public static DataTable Fdt_NTDUC_EXPORT( )
    {
        return dbora.Fdt_LKE_S(new object[] { }, "PNS_NTDUC_BAI4_DROP_MA");
    }
    #endregion


}