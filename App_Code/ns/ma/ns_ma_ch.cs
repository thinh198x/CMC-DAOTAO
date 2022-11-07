using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_ma
{
    #region HỆ SỐ LÀM THÊM
    public static DataTable Fdt_NS_CC_HSO_LTHEM_DR()
    {
        return dbora.Fdt_LKE("PNS_CC_HSO_LTHEM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_CC_HSO_LTHEM_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_CC_HSO_LTHEM_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CC_HSO_LTHEM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_HSO_LTHEM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_CC_HSO_LTHEM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_HSO_LTHEM_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_CC_HSO_LTHEM_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_CC_HSO_LTHEM_NH");
    }
    public static void P_NS_CC_HSO_LTHEM_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["trangthai"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_CC_HSO_LTHEM_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_CC_HSO_LTHEM_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_HSO_LTHEM_XOA");
    }
    #endregion HỆ SỐ LÀM THÊM

    #region THIẾT LẬP THÔNG BÁO MENU
    public static void P_NS_TBAO_MENU_TLAP_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["co_hhhd"], b_dr["tbao_hethopdong"], b_dr["co_sn"], b_dr["sinhnhat"], b_dr["co_hc"], b_dr["ho_chieu"], b_dr["co_qd"], b_dr["quyetdinh"], b_dr["co_nop_hs"], b_dr["nop_hs"] }, "PNS_TBAO_MENU_TLAP_NH");
    }
    public static DataTable P_NS_TBAO_MENU_TLAP_CT()
    {
        return dbora.Fdt_LKE("PNS_TBAO_MENU_TLAP_CT");
    }
    #endregion THIẾT LẬP THÔNG BÁO MENU

    #region MÃ CHỈ TIÊU ATVS LAO ĐỘNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_CTATVS_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_CTATVS_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CTATVS_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tc"] }, "PNS_MA_CTATVS_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_CTATVS_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CTATVS_XOA");
    }
    #endregion

    #region MÃ CHUNG
    /// <summary>Liệt kê toàn bộ</summary>
    public static DataTable Fdt_NS_MA_CH_LKE(string b_ten)
    {
        return dbora.Fdt_LKE(b_ten);
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_CH_CT(string b_ten, string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, b_ten);
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CH_NH(DataTable b_dt, string b_ham)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, b_ham);
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_CH_XOA(string b_ma, string b_ham)
    {
        dbora.P_GOIHAM(b_ma, b_ham);
    }
    #endregion MÃ CHUNG

    #region MÃ DÂN TỘC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_DT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_DT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_DT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_DT_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_DT_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_DT_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_DT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_DT_XOA");
    }
    #endregion MÃ DÂN TỘC

    #region MÃ LOẠI QUAN HỆ
    public static DataTable Fdt_NS_MA_LQH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_LQH_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_LQH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LQH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_LQH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LQH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LQH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LQH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LQH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LQH_XOA");
    }
    #endregion MÃ LOẠI QUAN HỆ

    #region MÃ KỶ LUẬT
    /// <summary>Liệt kê toàn bộ</summary>
    public static DataTable Fdt_NS_MA_KL_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_KL_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_KL_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_KL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_KL_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_KL_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_KL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_KL_XOA");
    }
    #endregion MÃ KỶ LUẬT

    #region MÃ HÌNH THỨC ĐÀO TẠO
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_HTDT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTDT_DR");
    }
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_HTDT_DR_A()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_MA_HTDT_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HTDT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HTDT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HTDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HTDT_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HTDT_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HTDT_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HTDT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HTDT_XOA");
    }
    #endregion MÃ HÌNH THỨC ĐÀO TẠO

    #region MÃ HÌNH THỨC KHEN THƯỞNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static DataTable Fdt_NS_MA_HTKT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_HTKT_LKE_ALL");
    }
    public static object[] Fdt_NS_MA_HTKT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HTKT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HTKT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HTKT_MA");
    }
    // Nhap so lieu
    public static void P_NS_MA_HTKT_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra;
        if (chuyen.OBJ_S(b_dr["ma"]) == "") b_kiemtra = false;
        else b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_HTKT", "MA");
        if (!b_kiemtra)
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("KT", "NS_MA_HTKT", "MA");

        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.CSO_SO(b_dr["tien"].ToString()), chuyen.CNG_CSO(b_dr["ngay_hl"].ToString()), b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_HTKT_NH");
        b_ma = b_dr["ma"].ToString();
    }
    public static void P_NS_MA_HTKT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HTKT_XOA");
    }
    public static DataTable Fdt_NS_MA_HTKT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTKT_DR");
    }
    #endregion

    #region MÃ LOẠI HỢP ĐỒNG
    ///<summary>liệt kê drop</summary>
    ///

    public static DataTable Fdt_MA_LHD_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_LHD_LKE_ALL");
    }
    public static DataTable Fdt_NS_MA_LHD_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_LHD_DR");
    }
    public static DataTable Fdt_NS_SO_HD_DR()
    {
        return dbora.Fdt_LKE("PNS_SO_HD_DR");
    }

    public static DataTable Fdt_NS_MA_CVU_DR()
    {
        return dbora.Fdt_LKE("pns_ma_cvu_dr");
    }
    public static DataTable Fdt_NS_MA_NCDANH_DR()
    {
        return dbora.Fdt_LKE("pns_ma_ncdanh_dr");
    }

    public static DataTable Fdt_NS_MA_CDANH_LKE_DR(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(b_ncdanh, "pns_ma_cdanh_lke_dr");
    }

    public static DataTable Fdt_NS_MA_CDANH_LIST(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(b_ncdanh, "pns_ma_cdanh_list");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_LHD_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LHD_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_LHD_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LHD_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_LHD_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_LHD_CT");
    }
 
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LHD_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_LHD", "MA");
            if (b_kiemtra == false)
            {
                b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("LHD", "NS_MA_LHD", "MA");
            }
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"],b_dr["ten_in"], b_dr["thoihan"],b_dr["ma_sinh_shd"],b_dr["khoi"], b_dr["is_bhxh"], b_dr["is_bhyt"], b_dr["is_bhtn"], b_dr["tt"], b_dr["is_thue_lt"], b_dr["is_thue_pt"],
            b_dr["thue_pt"],b_dr["ghichu"] }, "PNS_MA_LHD_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LHD_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LHD_XOA");
    }

    public static DataTable Fdt_NS_MA_LHD_SOTHANG(string ma_lhd)
    {
        return dbora.Fdt_LKE_S(ma_lhd, "PNS_MA_LHD_SOTHANG");
    }
    public static DataTable Fdt_NS_DEM_HD(string b_so_the, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_so_id }, "PNS_DEM_HD");
    }

    #endregion MÃ LOẠI HỢP ĐỒNG

    #region THIẾT LẬP NỘI DUNG GỬI EMAIL SINH NHẬT
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_EMAIL_SN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_EMAIL_SN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary> 
    public static object[] Fdt_NS_MA_EMAIL_SN_MA(string b_ma_pn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_pn, b_trangkt }, "NNR", "PNS_MA_EMAIL_SN_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_EMAIL_SN_CT(string b_ma_pn)
    {
        return dbora.Fdt_LKE_S(b_ma_pn, "PNS_MA_EMAIL_SN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_EMAIL_SN_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma_pn"], b_dr["tieude"], b_dr["noidung"] }, "PNS_MA_EMAIL_SN_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_EMAIL_SN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_EMAIL_SN_XOA");
    }

    #endregion MÃ LOẠI HỢP ĐỒNG

    #region MÃ LOẠI NGẠCH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_LNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_LNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LNG_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_LNG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_LNG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LNG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LNG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LNG_XOA");
    }
    #endregion MÃ LOẠI NGẠCH

    #region MÃ THANG LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_TBL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_TBL_LKE_ALL");
    }

    public static object[] Fdt_NS_MA_TBL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_TBL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_TBL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_TBL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TBL_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["note"] }, "PNS_MA_TBL_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_TBL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TBL_XOA");
    }
    #endregion MÃ THANG LƯƠNG

    #region THANG LƯƠNG ĐƠN VỊ


    public static object[] Fdt_NS_HDNS_TLUONG_DVI_MA(string b_phong, string b_ngay_hl, string b_ma_tl, string b_ma_nl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_SO(b_ngay_hl), b_ma_tl, b_ma_nl, b_trangkt }, "NNR", "PNS_HDNS_TLUONG_DVI_MA");
    }

    public static object[] Fdt_NS_HDNS_TLUONG_DVI_SO_ID(double b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_TLUONG_DVI_SO_ID");
    }
    public static DataTable Fdt_NS_HDNS_TLUONG_DVI_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_TLUONG_DVI_DROP_MA");
    }
    //public static DataTable Fdt_NS_HDNS_TLUONG_DVI_CT(string b_ma)
    //{
    //    return dbora.Fdt_LKE_S(b_ma,, "PNS_HDNS_TLUONG_DVI_CT");
    //}
    public static DataSet Fdt_NS_HDNS_TLUONG_DVI_CT(string b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_HDNS_TLUONG_DVI_CT");
        return b_ds;
    }
    public static DataTable Fdt_NS_HDNS_TLUONG_DVI_XEM()
    {
        return dbora.Fdt_LKE("PNS_HDNS_TLUONG_DVI_XEM");
    }
    public static object[] Fdt_NS_HDNS_TLUONG_DVI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_TLUONG_DVI_LKE");
    }

    public static DataTable Fdt_NS_HDNS_TLUONG_DVI_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_TLUONG_DVI_EXCEL");
    }
    public static void P_NS_HDNS_TLUONG_DVI_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            b_so_id = chuyen.OBJ_N(dr["so_id"]);
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_id_bl = bang.Fobj_COL_MANG(b_dt_ct, "so_id_bl");
            object[] a_tongluong = bang.Fobj_COL_MANG(b_dt_ct, "tongluong");
            object[] a_luong_cb = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb");
            object[] a_thuong_dg = bang.Fobj_COL_MANG(b_dt_ct, "thuong_dg");
            object[] a_trang_thai = bang.Fobj_COL_MANG(b_dt_ct, "trang_thai");
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_bl", 'N', a_so_id_bl);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongluong", 'N', a_tongluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong_dg", 'N', a_thuong_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_trang_thai", 'S', a_trang_thai);
            string b_c = "," + chuyen.OBJ_C(dr["CTY"]) + "," + chuyen.OBJ_C(dr["MA_TL"]) + "," + chuyen.OBJ_C(dr["MA_NL"]) + "," + chuyen.OBJ_C(dr["NGAY_HL"]);
            b_c = b_c + ",:b_so_id,:a_so_id,:a_so_id_bl,:a_tongluong,:a_luong_cb,:a_thuong_dg,:a_trang_thai";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_TLUONG_DVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }
    public static void Fs_NS_HDNS_TLUONG_DVI_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_HDNS_TLUONG_DVI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_HDNS_TLUONG_DVI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_TLUONG_DVI_XOA");
    }
    #endregion MÃ NGHỀ NGHIỆP

    #region MÃ NHÓM LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_NL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_NL_LKE_ALL");
    }

    public static DataTable Fdt_NS_MA_NL_LKE_Export(string b_ma_tl)
    {
        return dbora.Fdt_LKE("PNS_MA_NL_LKE_ALL");
    }
    public static DataTable Fdt_NS_MA_NL_LKE_ALL_TL(string b_ma_tl)
    {
        return dbora.Fdt_LKE_S(b_ma_tl, "PNS_MA_NL_LKE_ALL_TL");
    }

    public static object[] Fdt_NS_MA_NL_LKE(string b_ma_tl, string b_day, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_tl, b_day, b_tu_n, b_den_n }, "NR", "PNS_MA_NL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NL_MA(string b_matl, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_matl, b_ma, b_trangkt }, "NNR", "PNS_MA_NL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NL_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma_tl"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["note"] }, "PNS_MA_NL_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_NL_XOA(string b_ma, string b_ma_tl)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_ma_tl }, "PNS_MA_NL_XOA");
    }

    //liệt kê ngạch lương theo mã thang lương CAPITALHOUSE
    public static DataTable Fdt_NS_MA_TL_NL(string b_ma_tl)
    {
        return dbora.Fdt_LKE_S(b_ma_tl, "PNS_MA_MA_TL_NL");
    }
    //liệt kê ngạch lương theo mã thang lương CORP
    public static DataTable Fdt_NS_HDNS_MA_TL_NL(string b_ma_bl)
    {
        return dbora.Fdt_LKE_S(b_ma_bl, "PNS_HDNS_MA_TL_NL");
    }
    #endregion MÃ NHÓM LƯƠNG

    #region MÃ BẬC LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary> 

    public static DataTable Fdt_NS_HT_MA_DVI_DR()
    {
        return dbora.Fdt_LKE("PNS_HT_MA_DVI_DR");
    }
    public static DataTable Fdt_NS_MA_BL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_BL_LKE_ALL");
    }
    /// <summary>Liệt kê số liệu</summary>
    public static object[] Fdt_NS_HDNS_MA_BACLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_BL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_BACLUONG_MA(string b_ma_tl, string b_ma_nl, string b_ma_nnnghiep, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_tl, b_ma_nl, b_ma_nnnghiep, b_trangkt }, "NNRN", "PNS_HDNS_MA_BL_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataSet Fds_NS_HDNS_MA_BACLUONG_CT(string b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id }, 3, "PNS_HDNS_MA_BL_CT");
        return b_ds;
    }
    public static DataSet Fds_NS_HDNS_MA_BL_CTY_CT(string b_ma_tl, string b_ma_nl)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_ma_tl, b_ma_nl }, 1, "PNS_HDNS_MA_BL_CTY_CT");
        return b_ds;
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_BACLUONG_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_bacluong = bang.Fobj_COL_MANG(b_dt_ct, "bacluong");
            object[] a_tongluong = bang.Fobj_COL_MANG(b_dt_ct, "tongluong");
            object[] a_luong_cb = bang.Fobj_COL_MANG(b_dt_ct, "luong_cb");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "trangthai");
            object[] a_so_id_ct = bang.Fobj_COL_MANG(b_dt_ct, "so_id_ct");
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_bacluong", 'U', a_bacluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongluong", 'N', a_tongluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_ct", 'N', a_so_id_ct);
            string b_c = "," + chuyen.OBJ_C(dr["MA_TL"]) + "," + chuyen.OBJ_C(dr["MA_NL"]) + "," + chuyen.OBJ_C(dr["ma_nnnghiep"]);
            b_c = b_c + ",:b_so_id,:a_bacluong,:a_tongluong,:a_luong_cb,:a_trangthai,:a_so_id_ct";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_BL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_HDNS_MA_BACLUONG_IMP_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_key = bang.Fobj_COL_MANG(b_dt, "KEY");
            object[] a_ma_tl = bang.Fobj_COL_MANG(b_dt, "MA_TL");
            object[] a_ma_nl = bang.Fobj_COL_MANG(b_dt, "MA_NL");
            object[] a_ma_nnnghiep = bang.Fobj_COL_MANG(b_dt, "MA_NNNGHIEP");

            object[] a_key_ct = bang.Fobj_COL_MANG(b_dt_ct, "KEY");
            object[] a_bacluong = bang.Fobj_COL_MANG(b_dt_ct, "BACLUONG");
            object[] a_tongluong = bang.Fobj_COL_MANG(b_dt_ct, "TONGLUONG");
            object[] a_luong_cb = bang.Fobj_COL_MANG(b_dt_ct, "LUONG_CB");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "TRANGTHAI");

            dbora.P_THEM_PAR(ref b_lenh, "a_key", 'N', a_key);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tl", 'S', a_ma_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nl", 'S', a_ma_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nnnghiep", 'S', a_ma_nnnghiep);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_ct", 'N', a_key_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_bacluong", 'U', a_bacluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongluong", 'N', a_tongluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cb", 'N', a_luong_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);

            string b_c = ",:a_key,:a_ma_tl,:a_ma_nl,:a_ma_nnnghiep,:a_key_ct,:a_bacluong,:a_tongluong,:a_luong_cb,:a_trangthai";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_BL_IMP_NH(" + b_se.tso + b_c + "); end;";
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
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_HDNS_MA_BACLUONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_HDNS_MA_BL_XOA");
    }
    public static DataTable Fdt_NS_MA_BACLUONG_LKE_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_BL_EXCEL");
    }
    public static DataTable Fdt_NS_HDNS_MA_HTTLUONG_DR()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_HTTLUONG_DR");
    }
    public static DataTable Fdt_NS_HDNS_MA_NNN_DR()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_NNN_DR");
    }
    public static DataTable Fdt_NS_MA_NHOMLUONG_DR_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_NHOMLUONG_DR_ALL");
    }
    public static DataTable Fdt_NS_MA_BL_LKE_ALL_NL(string b_ma_nl)
    {
        return dbora.Fdt_LKE_S(b_ma_nl, "PNS_MA_BL_LKE_ALL_NL");
    }
    public static DataTable Fdt_NS_MA_TL_NGAY_HL(string b_ma_bl)
    {
        return dbora.Fdt_LKE_S(b_ma_bl, "PNS_MA_TL_NGAY_HL");
    }
    public static DataTable Fdt_NS_MA_BL_LUONG_CT(string b_ma_bl)
    {
        return dbora.Fdt_LKE_S(b_ma_bl, "PNS_MA_BL_LUONG_CT");
    }
    // liệt kê bậc lương theo thang lương và ngạch lương
    public static DataTable Fdt_NS_HDNS_MA_BL_BYTLNL(string b_ma_tl, string b_ma_nl)
    {
        return dbora.Fdt_LKE_S(new string[] { b_ma_tl, b_ma_nl }, "PNS_HDNS_MA_BL_BYTLNL");
    }
    public static DataTable Fdt_NS_HDNS_MA_BL_BYID(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDNS_MA_BL_BYID");
    }
    #endregion MÃ BẬC LƯƠNG

    #region MÃ TÔN GIÁO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_TG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_TG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_TG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_TG_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_TG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_TG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_TG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_TG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TG_XOA");
    }
    #endregion MÃ TÔN GIÁO

    #region CHI NHÁNH NGÂN HÀNG
    public static DataTable Fdt_NS_MA_CNNH_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_MA_CNNH_EXCEL");
    }
    public static object[] Fdt_NS_MA_CNNH_LKE(string b_luuday, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_tu_n, b_den_n }, "NR", "PNS_MA_CNNH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_CNNH_MA(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_MA_CNNH_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_MA_CNNH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.CSO_SO(b_so_id), "PNS_MA_CNNH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CNNH_NH(ref double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            string b_c = "," + chuyen.OBJ_C(b_dr["MA_NH"]) + "," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_C(b_dr["TEN"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["TRANGTHAI"]) + "," + chuyen.OBJ_C(b_dr["mota"]) + ",:b_so_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_CNNH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    ///<summary> Xóa </summary>
    public static void P_NS_MA_CNNH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_MA_CNNH_XOA");
    }
    #endregion CHI NHÁNH NGÂN HÀNG

    #region MÃ NGÂN HÀNG
    public static DataTable Fdt_NS_MA_NHA_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_MA_NHA_EXCEL");
    }
    public static object[] Fdt_NS_MA_NHA_LKE(string b_luuday, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_tu_n, b_den_n }, "NR", "PNS_MA_NHA_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_NHA_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NHA_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_MA_NHA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_NHA_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NHA_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_NHA_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_NHA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NHA_XOA");
    }
    public static DataTable Fdt_NS_MA_NHA_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_NHA_DR");
    }
    #endregion MÃ NGÂN HÀNG

    #region TRƯỜNG HỌC
    public static DataTable Fdt_NS_MA_TRUONGHOC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_TRUONGHOC_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_TRUONGHOC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_TRUONGHOC_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_TRUONGHOC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_TRUONGHOC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_TRUONGHOC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_TRUONGHOC_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_TRUONGHOC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_MA_TRUONGHOC_NH");
    }
    public static void P_NS_MA_TRUONGHOC_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["trangthai"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "PNS_MA_TRUONGHOC_NH");
        }
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.IMPORT, TEN_FORM.NS_MA_TRUONGHOC, TEN_BANG.NS_MA_TRUONGHOC);
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_TRUONGHOC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TRUONGHOC_XOA");
    }
    #endregion MÃ NƯỚC

    #region THIẾT LẬP PHIẾU LƯƠNG
    public static DataTable Fdt_NS_TL_PHIEULUONG_DR()
    {
        return dbora.Fdt_LKE("PNS_TL_PHIEULUONG_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_TL_PHIEULUONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_TL_PHIEULUONG_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TL_PHIEULUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TL_PHIEULUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_TL_PHIEULUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_PHIEULUONG_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_TL_PHIEULUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["stt"], b_dr["sott"], b_dr["ma"], b_dr["ten"], b_dr["cong_thuc"], b_dr["trangthai"], b_dr["kieu_dl"] }, "PNS_TL_PHIEULUONG_NH");
    }
    public static void P_NS_TL_PHIEULUONG_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["stt"], b_dr["sott"], b_dr["ma"], "N'" + b_dr["ten"], b_dr["cong_thuc"], b_dr["trangthai"] };
            dbora.P_GOIHAM(a_obj, "PNS_TL_PHIEULUONG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_TL_PHIEULUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_ma), "PNS_TL_PHIEULUONG_XOA");
    }
    #endregion MÃ NƯỚC

    #region CHUYÊN NGÀNH ĐÀO TẠO
    public static DataTable Fdt_NS_MA_CNDT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CNDT_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CNGANH_DT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CNGANH_DT_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_CNGANH_DT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CNGANH_DT_DR");
    }
    public static DataTable Fdt_NS_MA_CNGANH_DT_DR_A()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_MA_CNGANH_DT_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_CNGANH_DT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CNGANH_DT_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_CNGANH_DT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_MA_CNGANH_DT_NH");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_CNGANH_DT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CNGANH_DT_XOA");
    }

    public static void P_NS_MA_CNGANH_DT_FILE_NH(DataTable b_dt_ct)
    {
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            dbora.P_GOIHAM(new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["trangthai"], "N'" + b_dr["ghichu"] }, "PNS_MA_CNGANH_DT_NH");
        }
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.IMPORT, TEN_FORM.NS_MA_CNGANH_DT, TEN_BANG.NS_MA_CNGANH_DT);
    }

    #endregion MÃ NƯỚC

    #region MÃ NGOẠI NGỮ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NN_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_NN_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_NN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NN_XOA");
    }
    #endregion MÃ NGOẠI NGỮ

    #region MÃ NGẠCH LƯƠNG
    public static DataTable Fdt_NS_MA_NGH_HOI(string b_lng, string b_ngach)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lng, b_ngach }, "PNS_MA_NGH_HOI");

    }
    public static object[] Fdt_NS_MA_NGH_LKE(string b_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_tu_n, b_den_n }, "NR", "PNS_MA_NGH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NGH_MA(string b_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_ma, b_trangkt }, "NNR", "PNS_MA_NGH_MA");
    }
    // Liet ke chi tiet
    public static DataTable Fdt_NS_MA_NGH_CT(string b_lng, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lng, b_ma }, "PNS_MA_NGH_CT");
    }
    // Nhap so lieu
    public static void P_NS_MA_NGH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["lng"], b_dr["ma"], b_dr["ten"] }, "PNS_MA_NGH_NH");
    }
    // Xoa so lieu
    public static void P_NS_MA_NGH_XOA(string b_lng, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_lng, b_ma }, "PNS_MA_NGH_XOA");
    }
    #endregion MÃ NGẠCH

    #region MÃ BẬC
    // liet ke toan bo
    public static DataTable Fdt_NS_MA_BAC_LKE(string b_lng, string b_nganh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lng, b_nganh }, "PNS_MA_BAC_LKE");
    }
    // liet ke chi tiet
    public static DataTable Fdt_NS_MA_BAC_CT(string b_lng, string b_nganh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lng, b_nganh, b_ma }, "PNS_MA_BAC_CT");
    }
    // Nhap so lieu
    public static void P_NS_MA_BAC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["lng"], b_dr["ngach"], b_dr["ma"], b_dr["ten"],
            chuyen.OBJ_N(b_dr["hso"]), chuyen.OBJ_N(b_dr["hspc"])  }, "PNS_MA_BAC_NH");
    }
    // Xoa so lieu
    public static void P_NS_MA_BAC_XOA(string b_lng, string b_nganh, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_lng, b_nganh, b_ma }, "PNS_MA_BAC_XOA");
    }
    #endregion MÃ BẬC

    #region MÃ NGẠCH BẬC
    // Hoi gia tri khi kiem tra
    public static DataTable Fdt_NS_MA_NGBAC_HOI(string b_lng, string b_ngach, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lng, b_ngach, b_ma }, "PNS_MA_NGBAC_HOI");
    }

    // liet ke toan bo
    public static object[] Fdt_NS_MA_NGBAC_LKE(string b_lng, string b_ngach, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_lng, b_ngach, b_tu_n, b_den_n }, "NR", "PNS_MA_NGBAC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NGBAC_MA(string b_lng, string b_ngach, string b_ngayd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_lng, b_ngach, chuyen.CNG_SO(b_ngayd), b_trangkt }, "NNRR", "PNS_MA_NGBAC_MA");
    }

    /// <summary>Liet ke chi tiet</summary>
    public static DataSet Fdt_NS_MA_NGBAC_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 2, "PNS_MA_NGBAC_CT");
    }
    // Nhap so lieu

    public static void P_NS_MA_NGBAC_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count == 0) throw new Exception("loi:Không có số liệu!:loi");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_ct, "hso");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["lng"]) + "," + chuyen.OBJ_C(b_dr["ngach"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ",:a_ma,:a_hso";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_NGBAC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_NS_MA_NGBAC_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_MA_NGBAC_XOA");
    }
    #endregion MÃ NGẠCH BẬC

    #region MÃ CHỨC VỤ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CVU_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CVU_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CVU_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CVU_MA");
    }

    /// <summary> Nhập </summary>
    public static void P_NS_MA_CVU_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        object[] a_obj = new object[] { b_dr_ct["ma"], b_dr_ct["ten"], chuyen.OBJ_N(b_dr_ct["hspc"]), chuyen.OBJ_S(b_dr_ct["ma_ct"], " ") };
        dbora.P_GOIHAM(a_obj, "PNS_MA_CVU_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_NS_MA_CVU_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CVU_XOA");
    }
    #endregion MÃ CHỨC VỤ

    #region MÃ NƯỚC
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_NUOC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_NUOC_DR..................00000000000000000000000000....................................................................................................................................................................................................................................................................................................................................................................................................................................................................................");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NUOC_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_NUOC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NUOC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NUOC_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_NUOC_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_NUOC", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("QG", "NS_MA_NUOC", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_NUOC_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_NUOC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NUOC_XOA");
    }
    #endregion MÃ NƯỚC

    #region MÃ TỈNH
    public static DataTable Fdt_LVHOAN_BAI1_DR()
    {
        return dbora.Fdt_LKE("PNS_LVHOAN_BAI1_DR");
    }
    public static object[] Fdt_LVHOAN_BAI1_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_LVHOAN_BAI1_LKE");
    }
    public static object[] Fdt_LVHOAN_BAI1_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_LVHOAN_BAI1_MA");
    }
    public static void P_LVHOAN_BAI1_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "LVHOAN_BAI1", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("T", "LVHOAN_BAI1", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_LVHOAN_BAI1_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_LVHOAN_BAI1_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_LVHOAN_BAI1_XOA");
    }



    #endregion MÃ TỈNH

    #region NTDUC_BAI1
    public static DataTable Fdt_NS_NTDUC_BAI1_DR()
    {
        return dbora.Fdt_LKE("NTDUC_BAI1_DR");
    }

    public static object[] Fdt_NS_NTDUC_BAI1_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "NTDUC_BAI1_LKE");
    }
    public static void P_NS_NTDUC_BAI1_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "DAOTAO_BAI1", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("T", "DAOTAO_BAI1", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "NTDUC_BAI1_NH");
        b_ma = b_dr["ma"].ToString();
    }
    public static object[] Fdt_NS_NTDUC_BAI1_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "NTDUC_BAI1_MA");
    }
    /////delete
    ///
    public static void P_NS_NTDUC_BAI1_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "NTDUC_BAI1_XOA");
    }

    #endregion

    #region NHNAM_BAI1

    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_NHNAM_BAI1_DR()
    {
        return dbora.Fdt_LKE("NHNAM_BAI1_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_NHNAM_BAI1_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "NHNAM_BAI1_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_NHNAM_BAI1_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "NHNAM_BAI1_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_NHNAM_BAI1_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NHNAM_BAI1", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TINH", "NHNAM_BAI1", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "NHNAM_BAI1_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_NHNAM_BAI1_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "NHNAM_BAI1_XOA");
    }
    #endregion

 

    #region MÃ TINH THANH
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_TINHTHANH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_TINHTHANH_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_TINHTHANH_LKE(double b_tu_n, double b_den_n, string b_tt )
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_TINHTHANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_TINHTHANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_TINHTHANH_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_TINHTHANH_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_TINHTHANH", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TT", "NS_MA_TINHTHANH", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_TINHTHANH_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_TINHTHANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TINHTHANH_XOA");
    }
    #endregion MÃ TINH THANH 

#region MÃ PHÂN BỔ
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_PBO_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_PBO_DR");
    }
    ///<summary>Liệt kê bậc chức danh drop</summary>
    public static DataTable Fdt_NS_BCDANH_DR()
    {
        return dbora.Fdt_LKE("PNS_BCDANH_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_PBO_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_PBO_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_PBO_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_PBO_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_PBO_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_PBO_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_PBO_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_PBO_XOA");
    }
    #endregion MÃ PHÂN BỔ

    #region MÃ NHÓM
    public static DataTable Fdt_NS_MA_CB_DR()
    {
        return dbora.Fdt_LKE("pns_ma_cb_dr");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_NH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_NH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NH_XOA");
    }

    public static DataTable Fdt_NS_MA_NH_XEM_QUYEN(string b_ma_dvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dvi }, "PNS_MA_NH_XEM_QUYEN");
    }
    #endregion

    #region MÃ SƠ YẾU LÝ LỊCH
    public static object[] Fdt_NS_MA_SYLL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_SYLL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_SYLL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_SYLL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_SYLL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["kieu"], b_dr["ftkhao"],
            b_dr["ktra"], b_dr["bb"]}, "PNS_MA_SYLL_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_SYLL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_SYLL_XOA");
    }
    #endregion

    #region MÃ TỈNH THÀNH PHỐ
    /// <summary>Liệt kê toàn bộ số liệu</summary>/// 
    public static DataTable Fdt_NS_MA_TT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_TT_DR");
    }
    public static DataTable Fdt_NS_MA_TT_DR(string b_nuoc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nuoc }, "PNS_MA_TT_DR_NUOC");
    }
    public static object[] Fdt_NS_MA_TT_LKE(string b_tim, double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tim, b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_TT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_TT_MA(string b_ma_qg, string b_ma, double b_trangkt, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_qg, b_ma, b_trangkt, b_tt }, "NNR", "PNS_MA_TT_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TT_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_TT", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TT", "NS_MA_TT", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma_qg"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_TT_NH");
        b_ma = b_dr["ma"].ToString();
    }
    ///<summary> Xóa </summary> ///
    public static void P_NS_MA_TT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TT_XOA");
    }
    #endregion

    #region MÃ QUẬN HUYỆN
    public static DataTable Fdt_NS_MA_QH_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_QH_ALL");
    }
    public static DataTable Fdt_NS_MA_QH_DR(string b_tt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_tt }, "PNS_MA_QH_DR_TT");
    }
    public static DataTable Fdt_NS_MA_QH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_QH_DR");
    }
    public static object[] Fdt_NS_MA_QH_LKE(string b_tim, double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tim, b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_QH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_QH_MA(string b_ma_tt, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_tt, b_ma, b_trangkt }, "NNR", "PNS_MA_QH_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_QH_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_QH", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("QH", "NS_MA_QH", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma_tt"], b_dr["MA"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_QH_NH");
        b_ma = b_dr["ma"].ToString();
    }
    ///<summary> Xóa </summary> ///
    public static void P_NS_MA_QH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_QH_XOA");
    }
    #endregion

    #region MÃ XÃ PHƯỜNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>/// 
    public static DataTable Fdt_NS_MA_XP_LKEALL()
    {
        return dbora.Fdt_LKE("PNS_MA_XP_LKEALL");
    }
    public static object[] Fdt_NS_MA_XP_LKE(string b_ma_qg, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_qg, b_tu_n, b_den_n }, "NR", "PNS_MA_XP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_XP_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_XP_MA");
    }

    public static DataTable Fdt_NS_MA_XP_DR(string b_qh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_qh }, "PNS_MA_XP_DR_QH");
    }

    public static DataTable Fdt_NS_MA_CNNH_DR(string b_nh)
    {
        return dbora.Fdt_LKE_S(b_nh, "PNS_MA_CNNH_DR_NH");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_XP_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_XP", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("XP", "NS_MA_XP", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma_qh"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_XP_NH");
        b_ma = b_dr["ma"].ToString();
    }
    ///<summary> Xóa </summary> ///
    public static void P_NS_MA_XP_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_XP_XOA");
    }
    #endregion

    #region MÃ VĂN BẰNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_VB_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_VB_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_VB_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_VB_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_VB_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_VB_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_VB_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_VB_XOA");
    }
    #endregion

    #region MÃ BẰNG CẤP
    public static DataTable Fdt_NS_MA_BC_DR()
    {
        return dbora.Fdt_LKE("pns_ma_bc_dr");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_BC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_BC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_BC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_BC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_BC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_BC_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_BC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_BC_XOA");
    }
    #endregion

    #region MÃ GIÁO DỤC PHỔ THÔNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_GDPT_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_GDPT_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_GDPT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_GDPT_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_GDPT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_GDPT_XOA");
    }
    #endregion

    #region MÃ HỌC HÀM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HH_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_HH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HH_XOA");
    }
    #endregion

    #region MÃ HỌC VỊ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HV_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HV_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HV_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_HV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HV_XOA");
    }
    #endregion

    #region MÃ LÝ LUẬN CHÍNH TRỊ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_LLCT_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_LLCT_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LLCT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LLCT_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_LLCT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LLCT_XOA");
    }
    #endregion

    #region MÃ TRÌNH ĐỘ QUẢN LÝ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_TDQL_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_TDQL_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TDQL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_TDQL_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_TDQL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TDQL_XOA");
    }
    #endregion

    #region MÃ TRÌNH ĐỘ TIN HỌC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_TDTH_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_TDTH_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TDTH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_TDTH_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_TDTH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TDTH_XOA");
    }
    #endregion

    #region MÃ NHÓM CHUYÊN NGÀNH
    public static object[] Fdt_NS_MA_NCNGANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NCNGANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NCNGANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NCNGANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NCNGANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_NCNGANH_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_NCNGANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NCNGANH_XOA");
    }
    #endregion MÃ NHÓM CHUYÊN NGÀNH

    #region MÃ CHUYÊN NGÀNH

    public static object[] Fdt_NS_MA_CNGANH_LKE(string b_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_tu_n, b_den_n }, "NR", "PNS_MA_CNGANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CNGANH_MA(string b_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom, b_ma, b_trangkt }, "NNR", "PNS_MA_CNGANH_MA");
    }
    /// <summary>Liet ke chi tiet</summary>
    public static DataTable Fdt_NS_MA_CNGANH_CT(string b_nhom, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom, b_ma }, "PNS_MA_CNGANH_CT");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_CNGANH_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_CNGANH_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CNGANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom"], b_dr["ma"], b_dr["ten"] }, "PNS_MA_CNGANH_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_CNGANH_XOA(string b_nhom, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nhom, b_ma }, "PNS_MA_CNGANH_XOA");
    }
    #endregion

    #region MÃ XẾP LOẠI
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_MA_XLOAI_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_XLOAI_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_XLOAI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_XLOAI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_XLOAI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_XLOAI_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_XLOAI_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_XLOAI_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_XLOAI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_XLOAI_XOA");
    }
    #endregion

    #region MÃ CẤP ĐÀO TẠO
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_CAPDT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CAPDT_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CAPDT_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CAPDT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CAPDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CAPDT_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CAPDT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_I(b_dr["cap"]) }, "PNS_MA_CAPDT_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_CAPDT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CAPDT_XOA");
    }
    #endregion

    #region MÃ LOẠI KẾ HOẠCH
    /// <summary>Liệt kê toàn bộ</summary>
    public static object[] PNS_MA_LKH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LKH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] P_NS_MA_HEDT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LKH_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LKH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LKH_NH");
        }
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LKH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LKH_XOA");
    }
    #endregion MÃ LOẠI KẾ HOẠCH

    #region MÃ HUY HIỆU ĐẢNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HHDANG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HHDANG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HHDANG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HHDANG_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HHDANG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HHDANG_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HHDANG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HHDANG_XOA");
    }
    #endregion MÃ HUY HIỆU ĐẢNG

    #region MÃ LOẠI KHEN THƯỞNG
    /// <summary>Liệt kê toàn bộ</summary>
    /// 

    public static DataTable Fdt_NS_MA_LKT_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_LKT_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LKT_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LKT_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LKT_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LKT_XOA");
    }
    #endregion MÃ LOẠI KHEN THƯỞNG

    #region MÃ HÌNH THỨC KỶ LUẬT
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static DataTable Fdt_NS_MA_HTKL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_ma_htkl_LKE_ALL");
    }
    public static object[] Fdt_NS_MA_HTKL_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HTKL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HTKL_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HTKL_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HTKL_NH(DataTable b_dt, ref string b_ma)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            bool b_kiemtra;
            if (chuyen.OBJ_S(b_dr["ma"]) == "") b_kiemtra = false;
            else b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_HTKL", "MA");
            if (!b_kiemtra)
                b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("KL", "NS_MA_HTKL", "MA");

            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.CSO_SO(b_dr["tien"].ToString()), chuyen.CNG_CSO(b_dr["ngay_hl"].ToString()), b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_HTKL_NH");
            b_ma = b_dr["ma"].ToString();
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HTKL_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HTKL_XOA");
    }
    /// <summary>
    /// Drop htkl
    /// </summary>
    /// <returns></returns>
    public static DataTable Fdt_NS_MA_HTKL_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTKL_DR");
    }
    #endregion MÃ HÌNH THỨC KỶ LUẬT

    #region MÃ XẾP LOẠI SỨC KHỎE
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_LSK_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_LSK_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_LSK_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_LSK_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LSK_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_LSK_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_LSK_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LSK_XOA");
    }
    #endregion MÃ XẾP LOẠI SỨC KHỎE

    #region MÃ BỆNH VIỆN

    public static DataTable Fdt_NS_MA_BV_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_BV_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_BV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_BV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_BV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_BV_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_BV_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["dchi"], b_dr["tinhthanh"], b_dr["quanhuyen"], b_dr["trangthai"] }, "PNS_MA_BV_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_BV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_BV_XOA");
    }
    #endregion MÃ BỆNH VIỆN

    #region TỶ LỆ ĐÓNG BẢO HIỂM
    public static object[] Faobj_NS_MA_TYLE_BH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_TILE_BH_LKE");
    }
    public static object[] Faobj_NS_MA_TYLE_BH_MA(string b_ngay_hl, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay_hl), b_trangkt }, "NNR", "PNS_MA_TILE_BH_MA");
    }
    public static void P_NS_MA_TYLE_BH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ngay_hl"], b_dr["trangthai"], b_dr["muctran_bhxh"], b_dr["muctran_bhyt"], b_dr["muctran_bhtn"], b_dr["cty_bhxh"],
                                      b_dr["cty_bhyt"],b_dr["cty_bhtn"],b_dr["cty_cdp"],b_dr["cty_dangphi"],b_dr["cty_bhtnnn"],
                                      b_dr["nv_bhxh"],b_dr["nv_bhyt"],b_dr["nv_bhtn"], b_dr["NV_CDP"],b_dr["NV_DANGPHI"],b_dr["NV_BHTNNN"],
                                      b_dr["heso_omdau"],b_dr["heso_thaisan"],b_dr["nghi_tainha"],
                                      b_dr["nghi_taptrung"],b_dr["nghihuu_nam"],b_dr["nghihuu_nu"]}, "PNS_MA_TILE_BH_NH");
    }
    public static void P_NS_MA_TYLE_BH_XOA(string b_ngay_hl)
    {
        dbora.P_GOIHAM(chuyen.CNG_SO(b_ngay_hl), "PNS_MA_TILE_BH_XOA");
    }
    #endregion TỶ LỆ ĐÓNG BẢO HIỂM

    #region NHÓM BIẾN ĐỘNG BẢO HIỂM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_KHAC_NHOM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_KHAC_NHOM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_KHAC_NHOM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_KHAC_NHOM_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_KHAC_NHOM_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trang_thai"], b_dr["gchu"] }, "PNS_MA_KHAC_NHOM_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_KHAC_NHOM_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_KHAC_NHOM_XOA");
    }
    #endregion

    #region PHƯƠNG ÁN SỬ DỤNG BIẾN ĐỘNG BẢO HIỂM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_BIENDONGBHXH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_BIENDONGBHXH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_BIENDONGBHXH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_BIENDONGBHXH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_BIENDONGBHXH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_biendong"], b_dr["ma"], b_dr["ten"], b_dr["trang_thai"], b_dr["mota"] }, "PNS_MA_BIENDONGBHXH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_BIENDONGBHXH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_MA_BIENDONGBHXH_XOA");
    }
    #endregion

    #region PHƯƠNG ÁN CHẾ ĐỘ BẢO HIỂM
    public static DataTable Fdt_NS_MA_PHUONGANCHEDOBH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_PHUONGANCHEDOBH_LKE_ALL");
    }
    public static DataTable Fdt_NS_MA_PHUONGANCHEDOBH_DR(string b_nhom_cd)
    {
        return dbora.Fdt_LKE_S(b_nhom_cd, "PNS_MA_PHUONGANCHEDOBH_DR");
    }
    /// <summary> Chi tiết </summary>

    public static DataTable Fdt_NS_MA_PHUONGANCHEDOBH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_PHUONGANCHEDOBH_CT");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_PHUONGANCHEDOBH_LKE(string b_ma_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nhom, b_tu_n, b_den_n }, "NR", "PNS_MA_PHUONGANCHEDOBH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_PHUONGANCHEDOBH_MA(string b_ma_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nhom, b_ma, b_trangkt }, "NNR", "PNS_MA_PHUONGANCHEDOBH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_PHUONGANCHEDOBH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma_nhom"], b_dr["ma"], b_dr["ten"], b_dr["trang_thai"], b_dr["mota"] }, "PNS_MA_PHUONGANCHEDOBH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_PHUONGANCHEDOBH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_MA_PHUONGANCHEDOBH_XOA");
    }
    #endregion

    #region BIẾN ĐỘNG BẢO HIỂM
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_MA_KHAC_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_KHAC_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_KHAC_LKE(double b_tu_n, double b_den_n, string b_loai)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_loai }, "NR", "PNS_MA_KHAC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_KHAC_MA(string b_ma, string b_loai_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai_ma, b_trangkt }, "NNR", "PNS_MA_KHAC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_KHAC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["loai_ma"], b_dr["trang_thai"], b_dr["gchu"] }, "PNS_MA_KHAC_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_KHAC_XOA(string b_ma, string b_loai_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_loai_ma }, "PNS_MA_KHAC_XOA");
    }
    #endregion

    #region MÃ NHÓM CHẾ ĐỘ

    public static DataTable Fdt_NS_MA_PHUONG_AN_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_PHUONG_AN_DR");
    }


    public static DataTable Fdt_NS_MA_NHOM_CHEDO_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_NHOM_CHEDO_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_NHOM_CHEDO_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NHOM_CHEDO_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_NHOM_CHEDO_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NHOM_CHEDO_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NHOM_CHEDO_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trang_thai"], b_dr["gchu"] }, "PNS_MA_NHOM_CHEDO_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_NHOM_CHEDO_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NHOM_CHEDO_XOA");
    }
    #endregion

    #region CHẾ ĐỘ BHXH
    // lke all
    public static DataTable Fdt_NS_MA_LYDOBHXH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_LYDOBHXH_LKE_ALL");
    }
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_LYDOBHXH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_LYDOBHXH_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_MA_LYDOBHXH_LKE(string b_ma_nhom, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nhom, b_tu_n, b_den_n }, "NR", "PNS_MA_LYDOBHXH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Faobj_NS_MA_LYDOBHXH_MA(string b_ma_nhom, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nhom, b_ma, b_trangkt }, "NNR", "PNS_MA_LYDOBHXH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_LYDOBHXH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma_nhom"], b_dr["ma"], b_dr["ten"], b_dr["luyke"], b_dr["songay_huong"], b_dr["mucHuong"], b_dr["trangthai"] }, "PNS_MA_LYDOBHXH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_LYDOBHXH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_LYDOBHXH_XOA");
    }
    #endregion

    #region CHI PHÍ GÓI BẢO HIỂM CMC CARE
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CHIPHI_CMCCARE_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CHIPHI_CMCCARE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CHIPHI_CMCCARE_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CHIPHI_CMCCARE_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CHIPHI_CMCCARE_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ngayd"], b_dr["ngayc"], b_dr["phibh_nam"], b_dr["mota"] }, "PNS_MA_CHIPHI_CMCCARE_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_CHIPHI_CMCCARE_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CHIPHI_CMCCARE_XOA");
    }
    public static DataTable Fdt_NS_MA_CHIPHI_CMCCARE_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_MA_CHIPHI_CMCCARE_EXCEL");
    }
    #endregion

    #region GÓI BẢO HIỂM AETNA
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_BH_AETNA_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "pns_ma_bh_aetna_lke");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_BH_AETNA_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "pns_ma_bh_aetna_ma");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_BH_AETNA_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["mucphi"], b_dr["trangthai"], b_dr["ghichu"] }, "pns_ma_bh_aetna_nh");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_BH_AETNA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "pns_ma_bh_aetna_xoa");
    }
    public static DataTable Fdt_NS_MA_BH_AETNA_EXCEL()
    {
        return dbora.Fdt_LKE("pns_ma_bh_aetna_excel");
    }
    #endregion

    #region THIẾT LẬP ĐIỀU KIỆN HƯỞNG CMC CARE
    public static DataTable Fdt_NS_TLAP_DK_CMCCARE_XEM()
    {
        return dbora.Fdt_LKE("NS_TLAP_DK_CMCCARE_XEM");
    }
    public static DataSet Fdt_NS_TLAP_DK_CMCCARE_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 5, "PNS_TLAP_DK_CMCCARE_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_TLAP_DK_CMCCARE_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_TLAP_DK_CMCCARE_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_TLAP_DK_CMCCARE_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_nnghiep, DataTable b_dt_cdanh, DataTable b_dt_level, DataTable b_dt_lhd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_nnnghiep = bang.Fobj_COL_MANG(b_dt_nnghiep, "ma_nnnghiep");
            object[] a_ten_nnnghiep = bang.Fobj_COL_MANG(b_dt_nnghiep, "ten_nnnghiep");

            object[] a_ma_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "ma_cd");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt_cdanh, "ten");

            object[] a_ma_level_cdanh = bang.Fobj_COL_MANG(b_dt_level, "ma_level_cdanh");
            object[] a_ten_level_cdanh = bang.Fobj_COL_MANG(b_dt_level, "ten_level_cdanh");

            object[] a_ma_lhd = bang.Fobj_COL_MANG(b_dt_lhd, "ma_lhd");
            object[] a_ten_lhd = bang.Fobj_COL_MANG(b_dt_lhd, "ten_lhd");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nnnghiep", 'S', a_ma_nnnghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_nnnghiep", 'U', a_ten_nnnghiep);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cdanh", 'S', a_ma_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_level_cdanh", 'S', a_ma_level_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_level_cdanh", 'U', a_ten_level_cdanh);


            dbora.P_THEM_PAR(ref b_lenh, "a_ma_lhd", 'S', a_ma_lhd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_lhd", 'U', a_ten_lhd);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["bh_cmc_care"]) + "," + chuyen.OBJ_S(b_dr["thamnien"]) + ","
                + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ghichu"])
                + ",:a_ma_nnnghiep,:a_ten_nnnghiep,:a_ma_cdanh,:a_ten_cdanh,:a_ma_level_cdanh,:a_ten_level_cdanh,:a_ma_lhd,:a_ten_lhd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TLAP_DK_CMCCARE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_TLAP_DK_CMCCARE_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TLAP_DK_CMCCARE_XOA");
    }
    public static DataTable Fdt_NS_TLAP_DK_CMCCARE_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TLAP_DK_CMCCARE_EXCEL");
    }
    #endregion THIẾT LẬP ĐIỀU KIỆN HƯỞNG CMC CARE

    #region MÃ TIỀN TỆ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NTE_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NTE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NTE_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NTE_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NTE_NH(DataTable b_dt)
    {
        bang.P_CSO_SO(ref b_dt, "tygia");
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tygia"] }, "PNS_MA_NTE_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_NTE_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NTE_XOA");
    }
    #endregion MÃ TIỀN TỆ

    #region MÃ HÌNH THỨC THÔI VIỆC
    public static DataTable Fdt_NS_MA_HTTV_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTTV_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_HTTV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HTTV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_HTTV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HTTV_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HTTV_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_HTTV_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HTTV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HTTV_XOA");
    }
    #endregion MÃ HÌNH THỨC THÔI VIỆC

    #region TÚI HỒ SƠ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_THS_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_THS_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_THS_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_THS_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_THS_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_MA_THS_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_THS_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_THS_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_THS_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_THS_EXCEL");
    }
    #endregion

    #region MÃ NHÓM CHỨC DANH CÔNG VIỆC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NCDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NCDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NCDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NCDANH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_NCDANH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_NCDANH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NCDANH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_NCDANH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_NCDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NCDANH_XOA");
    }
    #endregion MÃ NHÓM CHỨC DANH CÔNG VIỆC

    #region MÃ CHỨC DANH CÔNG VIỆC
    public static string Fdt_NS_MA_CDANH_HOI(string b_cdanh, string b_ncdanh)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_cdanh, b_ncdanh }, "PNS_MA_CDANH_HOI");
        if (b_dt.Rows.Count == 0) return "loi:Chưa đăng ký mã chức danh:loi";
        else return b_dt.Rows[0][0].ToString() + "#" + b_dt.Rows[0][1];
    }

    public static object[] Fdt_NS_MA_CDANH_LKE(string b_ncdanh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_tu_n, b_den_n }, "NR", "PNS_MA_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CDANH_MA(string b_ncdanh, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_ma, b_trangkt }, "NNR", "PNS_MA_CDANH_MA");
    }

    // Liet ke chi tiet
    public static DataTable Fdt_NS_MA_CDANH_CT(string b_ncdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ncdanh, b_ma }, "PNS_MA_CDANH_CT");
    }
    // Nhap so lieu
    public static void P_NS_MA_CDANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ncdanh"], b_dr["ma"], b_dr["ten"], b_dr["mota"] }, "PNS_MA_CDANH_NH");
    }
    // Xoa so lieu
    public static void P_NS_MA_CDANH_XOA(string b_ncdanh, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ncdanh, b_ma }, "PNS_MA_CDANH_XOA");
    }

    // liệt kê chức danh theo mã ngạch ngành nghề
    public static DataTable Fdt_NS_HDNS_CDANH_BYNNN(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(new string[] { b_ncdanh }, "pns_hdns_cdanh_bynnn");
    }
    #endregion MÃ CHỨC DANH CÔNG VIỆC

    #region MÃ BẬC CHỨC DANH CÔNG VIỆC
    // Hoi gia tri khi kiem tra
    public static DataRow Fdr_NS_MA_BACCDANH_HOI(string b_ncdanh, string b_cdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ncdanh, b_cdanh, b_ma }, "PNS_MA_BACCDANH_HOI").Rows[0];
    }
    // liet ke toan bo
    public static object[] Fdt_NS_MA_BACCDANH_LKE(string b_ncdanh, string b_cdanh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_cdanh, b_tu_n, b_den_n }, "NR", "PNS_MA_BACCDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_BACCDANH_MA(string b_ncdanh, string b_cdanh, string b_ngayd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_cdanh, chuyen.CNG_SO(b_ngayd), b_trangkt }, "NNRR", "PNS_MA_BACCDANH_MA");
    }
    /// <summary>Liet ke chi tiet</summary>
    public static DataSet Fdt_NS_MA_BACCDANH_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 2, "PNS_MA_BACCDANH_CT");
    }

    // Nhap so lieu
    public static void P_NS_MA_BACCDANH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count == 0) throw new Exception("loi:Không có số liệu!:loi");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_ct, "hso");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ncdanh"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ",:a_ma,:a_hso";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_BACCDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_NS_MA_BACCDANH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_MA_BACCDANH_XOA");
    }

    #endregion MÃ BẬC CHỨC DANH CÔNG VIỆC

    #region MÃ NHÓM CHỨC DANH CÔNG VIỆC CHẤM CÔNG SẢN LƯỢNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CC_NCDANH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_CC_NCDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CC_NCDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CC_NCDANH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_CC_NCDANH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_CC_NCDANH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CC_NCDANH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_CC_NCDANH_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_CC_NCDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CC_NCDANH_XOA");
    }
    #endregion MÃ NHÓM CHỨC DANH CÔNG VIỆC

    #region MÃ CHỨC DANH CÔNG VIỆC CHẤM CÔNG SẢN LƯỢNG
    public static DataTable Fdt_NS_MA_CC_CDANH_LKE_DR(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(b_ncdanh, "pns_ma_cc_cdanh_lke_dr");
    }
    public static string Fdt_NS_MA_CC_CDANH_HOI(string b_cdanh, string b_ncdanh)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_cdanh, b_ncdanh }, "PNS_MA_CC_CDANH_HOI");
        if (b_dt.Rows.Count == 0) return "loi:Chưa đăng ký mã chức danh:loi";
        else return b_dt.Rows[0][0].ToString() + "#" + b_dt.Rows[0][1];
    }

    public static object[] Fdt_NS_MA_CC_CDANH_LKE(string b_ncdanh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_tu_n, b_den_n }, "NR", "PNS_MA_CC_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CC_CDANH_MA(string b_ncdanh, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_ma, b_trangkt }, "NNR", "PNS_MA_CC_CDANH_MA");
    }
    // Liet ke chi tiet
    public static DataTable Fdt_NS_MA_CC_CDANH_CT(string b_ncdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ncdanh, b_ma }, "PNS_MA_CC_CDANH_CT");
    }
    // Nhap so lieu
    public static void P_NS_MA_CC_CDANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ncdanh"], b_dr["ma"], b_dr["ten"], b_dr["mota"] }, "PNS_MA_CC_CDANH_NH");
    }
    // Xoa so lieu
    public static void P_NS_MA_CC_CDANH_XOA(string b_ncdanh, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ncdanh, b_ma }, "PNS_MA_CC_CDANH_XOA");
    }
    #endregion MÃ CHỨC DANH CÔNG VIỆC

    #region MÃ BẬC CHỨC DANH CÔNG VIỆC CHẤM CÔNG SẢN LƯỢNG
    // Hoi gia tri khi kiem tra
    public static DataRow Fdr_NS_MA_CC_BACCDANH_HOI(string b_ncdanh, string b_cdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ncdanh, b_cdanh, b_ma }, "PNS_MA_CC_BACCDANH_HOI").Rows[0];
    }
    // liet ke toan bo
    public static object[] Fdt_NS_MA_CC_BACCDANH_LKE(string b_ncdanh, string b_cdanh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_cdanh, b_tu_n, b_den_n }, "NR", "PNS_MA_CC_BACCDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_CC_BACCDANH_MA(string b_ncdanh, string b_cdanh, string b_ngayd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_cdanh, chuyen.CNG_SO(b_ngayd), b_trangkt }, "NNRR", "PNS_MA_CC_BACCDANH_MA");
    }
    /// <summary>Liet ke chi tiet</summary>
    public static DataSet Fdt_NS_MA_CC_BACCDANH_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 2, "PNS_MA_CC_BACCDANH_CT");
    }

    // Nhap so lieu
    public static void P_NS_MA_CC_BACCDANH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count == 0) throw new Exception("loi:Không có số liệu!:loi");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_ct, "hso");
            object[] a_sl_yc = bang.Fobj_COL_MANG(b_dt_ct, "sl_yc");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_yc", 'N', a_sl_yc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ncdanh"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ",:a_ma,:a_hso,:a_sl_yc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_CC_BACCDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_NS_MA_CC_BACCDANH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_MA_CC_BACCDANH_XOA");
    }

    #endregion MÃ BẬC CHỨC DANH CÔNG VIỆC

    #region MÃ HÌNH THỨC CÔNG TÁC

    ///<sumarry>Liệt kê drop</sumarry>
    public static DataTable Fdt_NS_MA_HTCTAC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HTCTAC_DR");
    }
    public static DataTable Fdt_NS_MA_HTCTAC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_HTCTAC_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static object[] Fdt_NS_MA_HTCTAC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_HTCTAC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_MA_HTCTAC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_HTCTAC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_HTCTAC_NH(DataTable b_dt, ref string b_ma)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_HTCTAC", "MA");
            if (b_kiemtra == false)
            {
                b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("QĐ", "NS_MA_HTCTAC", "MA");
            }
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["tdl"], b_dr["ghichu"] }, "PNS_MA_HTCTAC_NH");
            b_ma = chuyen.OBJ_S(b_dr["ma"]);
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_HTCTAC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_HTCTAC_XOA");
    }
    #endregion MÃ HÌNH THỨC CÔNG TÁC

    #region MÃ TAY NGHỀ
    /// <summary>Liệt kê toàn bộ</summary>
    public static DataTable Fdt_NS_MA_TAYNGHE_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_TAYNGHE_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_MA_TAYNGHE_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_TAYNGHE_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TAYNGHE_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_TAYNGHE_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_TAYNGHE_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TAYNGHE_XOA");
    }
    #endregion MÃ TAY NGHỀ

    #region MÃ BẬC TAY NGHỀ
    // Hoi gia tri khi kiem tra
    public static DataRow Fdr_NS_MA_BACTAYNGHE_HOI(string b_taynghe, string b_ma, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_taynghe, b_ma, chuyen.CNG_CSO(b_ngayd) }, "PNS_MA_BACTAYNGHE_HOI").Rows[0];
    }
    // liet ke toan bo
    public static DataTable Fdt_NS_MA_BACTAYNGHE_LKE(string b_taynghe)
    {
        return dbora.Fdt_LKE_S(new object[] { b_taynghe }, "PNS_MA_BACTAYNGHE_LKE");
    }
    /// <summary>Liet ke chi tiet</summary>
    public static DataTable Fdt_NS_MA_BACTAYNGHE_CT(string b_taynghe, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_taynghe, chuyen.CNG_CSO(b_ngayd) }, "PNS_MA_BACTAYNGHE_CT");
    }
    // Nhap so lieu
    public static void P_NS_MA_BACTAYNGHE_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count == 0) throw new Exception("loi:Không có số liệu!:loi");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt_ct, "hso");

            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "hso", 'N', a_hso);

            string b_c = "," + chuyen.OBJ_C(b_dr["taynghe"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ",:ma,:hso";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_BACTAYNGHE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Xoa so lieu
    public static void P_NS_MA_BACTAYNGHE_XOA(string b_taynghe, string b_ngayd)
    {
        dbora.P_GOIHAM(new object[] { b_taynghe, chuyen.CNG_CSO(b_ngayd) }, "PNS_MA_BACTAYNGHE_XOA");
    }
    #endregion MÃ BẬC CHỨC DANH CÔNG VIỆC

    #region FILE LƯU
    public static object[] Fdt_NS_FILE_LUU_LKE(string b_forms, string b_nv, string b_ten_kq, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_forms, b_nv, b_ten_kq, b_tu_n, b_den_n }, "NR", "PNS_FILE_LUU_LKE");
    }
    public static DataTable Fdt_NS_BIEUMAU_HD(string b_loai, string b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loai, chuyen.CNG_SO(b_ngay) }, "PNS_FILE_LUU_HOPDONG");
    }
    // Nhap so lieu
    public static string P_NS_FILE_LUU_NH(string b_so_id, string b_forms, string b_nv, string b_ten_kq, string b_ngay, string b_ten_file, string b_url, string b_file)
    {
        try
        {
            dbora.P_GOIHAM(new object[] { b_so_id, b_forms, b_nv, b_ten_kq, chuyen.CNG_SO(b_ngay), "N'" + chuyen.OBJ_S(b_ten_file), b_url, b_file }, "PNS_FILE_LUU_NH");
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    public static string P_NS_FILE_LUU_CHUNG_NH(string b_so_id, string b_forms, string b_nv, string b_ten_kq, string b_ngay, string b_ten_file, string b_url, string b_file)
    {
        try
        {
            dbora.P_GOIHAM(new object[] { b_so_id, b_forms, b_nv, b_ten_kq, chuyen.CNG_SO(b_ngay), "N'" + chuyen.OBJ_S(b_ten_file), b_url, b_file }, "pns_file_luu_nh_chung");
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }
    // Xoa so lieu
    public static void P_NS_FILE_LUU_XOA(string b_so_id, string b_forms, string b_nv, string b_ten_kq)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_forms, b_nv, b_ten_kq }, "PNS_FILE_LUU_XOA");
    }
    #endregion  FILE LƯU

    #region MÃ KỸ NĂNG CÁ NHÂN
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_KYNANG_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_KYNANG_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_KYNANG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_KYNANG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_KYNANG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_KYNANG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_KYNANG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PNS_MA_KYNANG_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_KYNANG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_KYNANG_XOA");
    }
    #endregion

    #region THIẾT LẬP EMAIL THÔNG BÁO
    public static void P_NS_TLAP_EMAIL_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["email"], b_dr["matkhau"], b_dr["smtp"], chuyen.OBJ_I(b_dr["port"]), b_dr["ssl"] }, "PNS_TLAP_EMAIL_NH");
    }
    public static DataTable P_NS_TLAP_EMAIL_CT()
    {
        return dbora.Fdt_LKE("PNS_TLAP_EMAIL_CT");
    }
    public static void P_NS_TLAP_EMAIL_XOA()
    {
        dbora.P_GOIHAM("X", "PNS_TLAP_EMAIL_XOA");
    }
    #endregion THIẾT LẬP EMAIL THÔNG BÁO

    #region THIẾT LẬP THÔNG TIN LIÊN HỆ BẢNG LƯƠNG THÔNG BÁO
    public static void P_NS_TLAP_TTLH_BLUONG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["NOIDUNG"] }, "PNS_TLAP_TTLH_BLUONG_NH");
    }
    public static DataTable P_NS_TLAP_TTLH_BLUONG_CT()
    {
        return dbora.Fdt_LKE("PNS_TLAP_TTLH_BLUONG_CT");
    }
    public static void P_NS_TLAP_TTLH_BLUONG_XOA()
    {
        dbora.P_GOIHAM("X", "PNS_TLAP_TTLH_BLUONG_XOA");
    }
    #endregion THIẾT LẬP THÔNG TIN LIÊN HỆ BẢNG LƯƠNG THÔNG BÁO

    #region MÃ TÀI SẢN
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_MA_TAISAN_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_TAISAN_DR");
    }
    public static DataTable Fdt_NS_MA_TAISAN_DR_NHOM(string b_nhom)
    {
        return dbora.Fdt_LKE_S(b_nhom, "PNS_MA_TAISAN_DR_NHOM");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_TAISAN_LKE(double b_tu_n, double b_den_n, string b_day)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_day }, "NR", "PNS_MA_TAISAN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_TAISAN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_TAISAN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_TAISAN_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_TAISAN_CAPPHAT", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TS", "NS_MA_TAISAN_CAPPHAT", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["nhom"], b_dr["sotien"], b_dr["trangthai"], b_dr["ghichu"] }, "PNS_MA_TAISAN_NH");
        b_ma = b_dr["ma"].ToString();
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_TAISAN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_TAISAN_XOA");
    }
    public static DataTable Fdt_NS_HDNS_MA_TAISAN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_TAISAN_EXCEL");
    }

    public static object[] Fdt_NS_MA_TAISAN_TIEN(string b_ma)
    {
        return dbora.Faobj_LKE(b_ma, "N", "PNS_MA_TAISAN_TIEN");
    }
    #endregion

    #region MÃ THỦ TỤC
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_MA_THUTUC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_THUTUC_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_THUTUC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_THUTUC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_THUTUC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_THUTUC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_THUTUC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["loai"] }, "PNS_MA_THUTUC_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_THUTUC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_THUTUC_XOA");
    }
    #endregion

    #region MÃ PHÚC LỢI
    public static DataTable Fdt_NS_MA_PHUCLOI_DR()
    {
        return dbora.Fdt_LKE("PNS_NS_MA_PHUCLOI_DR");
    }
    /// <summary>Liet ke toàn bộ</summary>
    /// 
    public static DataTable Fdt_NS_MA_PHUCLOI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_NS_MA_PHUCLOI_LKE_ALL");
    }
    public static object[] Fdt_NS_MA_PHUCLOI_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_NS_MA_PHUCLOI_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_MA_PHUCLOI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_NS_MA_PHUCLOI_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet PNS_MA_PHUCLOI_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "PNS_NS_MA_PHUCLOI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_MA_PHUCLOI_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_hd, DataTable b_dt_gt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            if (b_dr["thamnien"].ToString() == "") b_dr["thamnien"] = -1;
            if (b_dr["tutuoi"].ToString() == "") b_dr["tutuoi"] = -1;
            if (b_dr["dentuoi"].ToString() == "") b_dr["dentuoi"] = -1;
            // hợp đồng
            object[] a_chon = bang.Fobj_COL_MANG(b_dt_hd, "chon");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_hd, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_hd, "ten");
            dbora.P_THEM_PAR(ref b_lenh, "a_chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            // giới tính
            object[] c_chon = bang.Fobj_COL_MANG(b_dt_gt, "chon");
            object[] c_ma = bang.Fobj_COL_MANG(b_dt_gt, "ma");
            object[] c_ten = bang.Fobj_COL_MANG(b_dt_gt, "ten");
            dbora.P_THEM_PAR(ref b_lenh, "c_chon", 'S', c_chon);
            dbora.P_THEM_PAR(ref b_lenh, "c_ma", 'S', c_ma);
            dbora.P_THEM_PAR(ref b_lenh, "c_ten", 'U', c_ten);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_N(b_dr["sotien"]) + "," + chuyen.OBJ_N(b_dr["thamnien"]) + ","
                + chuyen.OBJ_N(b_dr["tutuoi"]) + "," + chuyen.OBJ_N(b_dr["dentuoi"]) + "," + chuyen.OBJ_C(b_dr["ma_lvcdanh"])
                + "," + chuyen.OBJ_C(b_dr["ma_cdanh"]) + "," + chuyen.OBJ_N(b_dr["ngay_d"]) + "," + chuyen.OBJ_N(b_dr["ngay_c"]) + "," + chuyen.OBJ_C(b_dr["is_tudong"]);
            b_c = b_c + ",:a_chon,:a_ma,:a_ten,:c_chon,:c_ma,:c_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_MA_PHUCLOI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally
        {
            b_cnn.Close();
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_MA_PHUCLOI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_NS_MA_PHUCLOI_XOA");
    }
    public static DataTable Fdt_NS_MA_DAT_LHD()
    {
        return dbora.Fdt_LKE("PNS_NS_MA_DAT_LHD");
    }
    public static DataTable Fdt_NS_LAY_LHD()
    {
        return dbora.Fdt_LKE("PNS_NS_LAY_LHD");
    }
    public static DataTable Fdt_NS_MA_DAT_GT(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_NS_MA_DAT_GT");
    }
    #endregion MÃ PHÚC LỢI

    #region NHÓM DANH MỤC DÙNG CHUNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_NHOM_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_NHOM_CHUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_NHOM_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_NHOM_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_NHOM_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mota"] }, "PNS_MA_NHOM_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_NHOM_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_NHOM_CHUNG_XOA");
    }
    #endregion

    #region DANH MỤC DÙNG CHUNG
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CHUNG_LKE(double b_tu_n, double b_den_n, string b_loai)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_loai }, "NR", "PNS_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_MA_CHUNG_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_MA_CHUNG_DR");
    }
    public static DataTable Fdt_PNS_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_MA_CHUNG_DR");
        DataRow b_dr = b_dt.NewRow();
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CHUNG_MA(string b_ma, string b_loai_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai_ma, b_trangkt }, "NNR", "PNS_MA_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_CHUNG_XOA(string b_ma, string b_loai_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_loai_ma }, "PNS_MA_CHUNG_XOA");
    }
    #endregion

    #region DANH MỤC CÁC TRƯỜNG THÔNG TIN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_FIELD_LKE(string b_loai_tk, string b_ten, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_loai_tk, "N'" + b_ten, b_tu_n, b_den_n }, "NR", "PNS_MA_FIELD_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_MA_FIELD_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_MA_FIELD_DR");
    }
    public static DataTable Fdt_PNS_MA_FIELD_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_MA_FIELD_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_FIELD_MA(string b_ma, string b_loai_tk, string b_ten, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai_tk, b_ten, b_trangkt }, "NNR", "PNS_MA_FIELD_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_FIELD_NH(string b_loai, DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_loai, b_dr["trangthai"] }, "PNS_MA_FIELD_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_MA_FIELD_XOA(string b_ma, string b_loai_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_loai_ma }, "PNS_MA_FIELD_XOA");
    }
    #endregion

    #region MÃ NGHỀ NGHIỆP
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_hd_ma_nnghe_LKE_ALL()
    {
        return dbora.Fdt_LKE("HD_MA_NNGHE_XEM");
    }
    public static DataTable Fdt_HD_MA_NNGHE_LKE_MATEN()
    {
        return dbora.Fdt_LKE("PHD_MA_NNGHE_MA_TENNGHE");
    }
    public static object[] Fdt_hd_ma_nnghe_LKE(double b_tu_n, double b_den_n, string b_day)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_day }, "NR", "HD_MA_NNGHE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_hd_ma_nnghe_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "HD_MA_NNGHE_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_hd_ma_nnghe_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "HD_MA_NNGHE_NH");
        }
    }
    public static void Fs_hd_ma_nnghe_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "HD_MA_NNGHE_NH");
        }
        //se.se_nsd b_se = new se.se_nsd();
        //OracleConnection b_cnn = dbora.Fcn_KNOI();
        //try
        //
        //    OracleCommand b_lenh = new OracleCommand();
        //    b_lenh.Connection = b_cnn;
        //    object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
        //    object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
        //    object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
        //    object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

        //    dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'S', a_ten);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'S', a_tt);
        //    dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'S', a_ghichu);

        //    string b_c = ",:a_ma,:a_ten,:a_tt,:a_ghichu";

        //    b_lenh.CommandText = "Begin " + b_se.dbo + ".PHD_MA_NNGHE_FIKE_NH(" + b_se.tso + b_c + "); end;";
        //    try
        //    {
        //        b_lenh.ExecuteNonQuery();
        //    }
        //    finally { b_lenh.Parameters.Clear(); }
        //}
        //finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_hd_ma_nnghe_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "HD_MA_NNGHE_XOA");
    }
    #endregion MÃ NGHỀ NGHIỆP

    #region MÃ CHUYÊN MÔN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_HD_MA_CMON_LKE_ALL(string b_ma_nnghe)
    {
        return dbora.Fdt_LKE_S(b_ma_nnghe, "HD_MA_CMON_XEM");
    }
    public static DataTable Fdt_HD_MA_CMON_LKE_MATEN()
    {
        return dbora.Fdt_LKE("PHD_MA_CMON_MA_TENNGHE");
    }
    public static DataTable Fdt_HD_MA_CMON_MATEN()
    {
        return dbora.Fdt_LKE("PHD_MA_CMON_MA_TENCMON");
    }
    public static object[] Fdt_HD_MA_CMON_LKE(string b_mannghe, string b_day, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_day, b_tu_n, b_den_n }, "NR", "HD_MA_CMON_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_HD_MA_CMON_MA(string b_mannghe, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_mannghe, b_ma, b_trangkt }, "NNR", "HD_MA_CMON_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_HD_MA_CMON_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["ma_nnghe"], b_dr["tt"], b_dr["ghichu"] }, "HD_MA_CMON_NH");
        }
    }
    public static void Fs_HD_MA_CMON_FILE_NH(DataTable b_dt_ct)
    {
        object[] a_obj;
        foreach (DataRow b_dr in b_dt_ct.Rows)
        {
            a_obj = new object[] { b_dr["ma"], "N'" + b_dr["ten"], b_dr["ma_nnghe"], b_dr["tt"], "N'" + b_dr["ghichu"] };
            dbora.P_GOIHAM(a_obj, "HD_MA_CMON_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_HD_MA_CMON_XOA(string b_mannghe, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_mannghe, b_ma }, "HD_MA_CMON_XOA");
    }
    #endregion MÃ CHUYÊN MÔN

    #region NHÓM DANH MỤC DÙNG CHUNG CHẤM CÔNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CC_MA_NHOM_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_NHOM_CHUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_CC_MA_NHOM_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_NHOM_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CC_MA_NHOM_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mota"] }, "PNS_CC_MA_NHOM_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_CC_MA_NHOM_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_MA_NHOM_CHUNG_XOA");
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG CHẤM CÔNG

    #region DANH MỤC DÙNG CHUNG CHẤM CÔNG
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_CC_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_CC_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CC_MA_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_CC_MA_CHUNG_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_CC_MA_CHUNG_DR");
    }
    public static DataTable Fdt_PNS_CC_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_CC_MA_CHUNG_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_CC_MA_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CC_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_CC_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_CC_MA_CHUNG_XOA(string b_ma, string b_loai_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_loai_ma }, "PNS_CC_MA_CHUNG_XOA");
    }
    #endregion DANH MỤC DÙNG CHUNG CHẤM CÔNG

    #region NHÓM DANH MỤC DÙNG CHUNG ĐÁNH GIÁ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DG_MA_NHOM_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_NHOM_CHUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DG_MA_NHOM_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_NHOM_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DG_MA_NHOM_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mota"] }, "PNS_DG_MA_NHOM_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DG_MA_NHOM_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DG_MA_NHOM_CHUNG_XOA");
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG ĐÁNH GIÁ

    #region DANH MỤC DÙNG CHUNG ĐÁNH GIÁ
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_DG_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_DG_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DG_MA_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DG_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_DG_MA_CHUNG_DR(string b_nhom_ma, string b_trangthai)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom_ma, b_trangthai }, "PNS_DG_MA_CHUNG_DR");
    }
    public static DataTable Fdt_NS_DG_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_DG_MA_CHUNG_NHOM_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DG_MA_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DG_MA_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DG_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_DG_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DG_MA_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_DG_MA_CHUNG_XOA");
    }
    #endregion DANH MỤC DÙNG CHUNG ĐÁNH GIÁ

    #region NHÓM DANH MỤC DÙNG CHUNG TUYEN DUNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TD_MA_NHOM_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TD_MA_NHOM_CHUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_TD_MA_NHOM_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TD_MA_NHOM_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TD_MA_NHOM_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mota"] }, "PNS_TD_MA_NHOM_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_TD_MA_NHOM_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TD_MA_NHOM_CHUNG_XOA");
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG TUYEN DUNG

    #region DANH MỤC DÙNG CHUNG TUYEN DUNG
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_TD_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_TD_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TD_MA_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TD_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_TD_MA_CHUNG_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_TD_MA_CHUNG_DR");
    }
    public static DataTable Fdt_PNS_TD_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_TD_MA_CHUNG_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_TD_MA_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TD_MA_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TD_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_TD_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_TD_MA_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_TD_MA_CHUNG_XOA");
    }
    #endregion DANH MỤC DÙNG CHUNG TUYEN DUNG

    #region NHÓM DANH MỤC DÙNG CHUNG HO SO NHAN SU
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HS_MA_NHOM_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HS_MA_NHOM_CHUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HS_MA_NHOM_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HS_MA_NHOM_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HS_MA_NHOM_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], "N'" + b_dr["mota"] }, "PNS_HS_MA_NHOM_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HS_MA_NHOM_CHUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HS_MA_NHOM_CHUNG_XOA");
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG HO SO NHAN SU

    #region DANH MỤC DÙNG CHUNG HO SO NHAN SU
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_HS_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_HS_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HS_MA_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HS_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_HS_MA_CHUNG_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_HS_MA_CHUNG_DR");
    }
    public static DataTable Fdt_PNS_HS_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_HS_MA_CHUNG_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HS_MA_CHUNG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HS_MA_CHUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HS_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_HS_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HS_MA_CHUNG_XOA(string b_nhom_ma, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nhom_ma, b_ma }, "PNS_HS_MA_CHUNG_XOA");
    }
    #endregion DANH MỤC DÙNG CHUNG HO SO NHAN SU

    #region DANH MỤC PHAN LOAI CAN BO

    public static DataTable Fdt_NS_HDNS_MA_PLNV_LKE_ALL(string b_trangthai)
    {
        return dbora.Fdt_LKE_S(b_trangthai, "PNS_HDNS_MA_PLNV_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HDNS_MA_PLNV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_PLNV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HDNS_MA_PLNV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_HDNS_MA_PLNV_MA");
    }
    public static DataSet Fds_NS_HDNS_MA_PLNV_CT(string b_ma)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_ma }, 2, "PNS_HDNS_MA_PLNV_CT");
        return b_ds;
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_PLNV_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ma_cd");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);

            string b_c = "," + chuyen.OBJ_C(dr["ma"]) + "," + chuyen.OBJ_C(dr["ten"]) + "," + chuyen.OBJ_C(dr["trangthai"]) + "," + chuyen.OBJ_C(dr["mota"]) + ",:a_so_id,:a_cdanh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_PLNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MA_PLNV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_HDNS_MA_PLNV_XOA");
    }
    #endregion DANH MỤC PHAN LOAI CAN BO

    #region DANH MỤC CẤP NHÂN VIÊN

    public static DataTable Fdt_NS_HDNS_MA_CAPNV_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_CAPNV_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HDNS_MA_CAPNV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_HDNS_MA_CAPNV_LKE");
    }
    public static DataTable Fdt_NS_HDNS_MA_CAPNV_LKE_DR(string b_plnv, string b_tt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_plnv, b_tt }, "PNS_HDNS_MA_CAPNV_LKE_DR");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_HDNS_MA_CAPNV_MA(string b_ma_plnv, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_ma_plnv, b_trangkt }, "NNR", "PNS_HDNS_MA_CAPNV_MA");
    }
    public static DataSet Fds_NS_HDNS_MA_CAPNV_CT(string b_ma_plnv, string b_ma)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_ma_plnv, b_ma }, 2, "PNS_HDNS_MA_CAPNV_CT");
        return b_ds;
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDNS_MA_CAPNV_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ma_cd");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);

            string b_c = "," + chuyen.OBJ_C(dr["ma_plnv"]) + "," + chuyen.OBJ_C(dr["ma"]) + "," + chuyen.OBJ_C(dr["ten"]) + "," + chuyen.OBJ_C(dr["tt"]) + "," + chuyen.OBJ_C(dr["mota"]) + ",:a_so_id,:a_cdanh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_MA_CAPNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MA_CAPNV_XOA(string b_ma_plnv, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_ma_plnv }, "PNS_HDNS_MA_CAPNV_XOA");
    }

    #endregion DANH MỤC CẤP NHÂN VIÊN

    #region DANH MỤC THAM SO HE THONG CHẤM CÔNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CC_MA_TSO_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_TSO_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_CC_MA_TSO_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_TSO_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CC_MA_TSO_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["NG_BDAU"], b_dr["NG_KTHUC"], b_dr["mota"] }, "PNS_CC_MA_TSO_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_CC_MA_TSO_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_MA_TSO_XOA");
    }
    #endregion DANH MỤC THAM SO HE THONG CHẤM CÔNG

    #region DANH MỤC QUYẾT ĐỊNH
    ///<sumarry>Liệt kê drop</sumarry>
    public static DataTable Fdt_NS_MA_QDINH_DR(string b_loai_qd)
    {
        return dbora.Fdt_LKE_S(b_loai_qd, "PNS_MA_QDINH_DR");
    }
    public static DataTable Fdt_NS_MA_QDINH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_QDINH_LKE_ALL");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary> /// 
    public static object[] Faobj_NS_MA_QDINH_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_QDINH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Faobj_NS_MA_QDINH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_QDINH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_QDINH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_QDINH", "MA");
            if (b_kiemtra == false) b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("QD", "NS_MA_QDINH", "MA");
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_QDINH_NH");
        }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_MA_QDINH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_QDINH_XOA");
    }
    #endregion DANH MỤC QUYẾT ĐỊNH

    #region MÃ KHUNG LƯƠNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_MA_KHUNGLUONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_MA_KHUNGLUONG_LKE_ALL");
    }

    public static DataTable Fdt_NS_MA_KHUNGLUONG_LKE_Export(string b_ma_tl)
    {
        return dbora.Fdt_LKE("PNS_MA_KHUNGLUONG_LKE_ALL");
    }
    public static object[] Fdt_NS_MA_KHUNGLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NRR", "PNS_MA_KHUNGLUONG_LKE");
    }

    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_KHUNGLUONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_KHUNGLUONG_MA");
    }

    public static DataSet Fdt_NS_MA_KHUNGLUONG_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 2, "PNS_MA_KHUNGLUONG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_KHUNGLUONG_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_chon = bang.Fobj_COL_MANG(b_dt_ct, "chon");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            dbora.P_THEM_PAR(ref b_lenh, "a_chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ma_cap"]) + "," + chuyen.OBJ_C(b_dr["mucmin"])
                + "," + chuyen.OBJ_C(b_dr["mucmax"]) + "," + chuyen.OBJ_C(b_dr["diemgiua"]) + "," + chuyen.OBJ_S(b_dr["ngayd"])
                + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ma_ncd"]) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_c += ",:a_chon,:a_cdanh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_KHUNGLUONG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally
        {
            b_cnn.Close();
        }
    }
    public static void P_NS_MA_KHUNGLUONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_MA_KHUNGLUONG_XOA");
    }
    // hàm check khung lương dùng cho phần hợp đồng và quyết định
    public static object[] Fdt_NS_MA_KHUNGLUONG_CHECK(string b_ngayd, string b_cdanh, string b_tongthunhap)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngayd), b_cdanh, chuyen.CSO_SO(b_tongthunhap) }, "R", "PNS_MA_KHUNGLUONG_CHECK");
    }
    #endregion MÃ KHUNG LƯƠNG

    #region MÃ QUẢN TRỊ RỦI RO
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_QTRR_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_QTRR_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_QTRR_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_QTRR_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_QTRR_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_QTRR_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_QTRR_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_QTRR", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("QTRR", "NS_MA_QTRR", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_QTRR_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_QTRR_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_QTRR_XOA");
    }
    #endregion MÃ QUẢN TRỊ RỦI RO

    #region MÃ ỦY BAN CHỨNG KHOÁN
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_UBCK_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_UBCK_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_UBCK_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_UBCK_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_UBCK_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_UBCK_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_UBCK_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_UBCK", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("UBCK", "NS_MA_UBCK", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_UBCK_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_UBCK_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_UBCK_XOA");
    }
    #endregion

    #region MÃ CHỨNG CHỈ HÀNH NGHỀ
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_CCHN_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CCHN_DR");
    }

 

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CCHN_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_CCHN_LKE");
    }
    /// <summary>Liệt kê chứng chỉ hành nghề</summary>
    public static DataTable Fdt_NS_MA_CCHN_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_MA_CCHN_EXPORT");
    }

    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CCHN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CCHN_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_CCHN_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_CCHN", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("CCHN", "NS_MA_CCHN", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_CCHN_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_MA_CCHN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CCHN_XOA");
    }
    #endregion 

    #region MÃ CHỨNG CHỈ CON
    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_MA_CCC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CCC_DR");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_CCC_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_CCC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_CCC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_CCC_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_MA_CCC_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_CCC", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("CCC", "NS_MA_CCC", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_MA_CCC_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_MA_CCC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_CCC_XOA");
    }
    #endregion

    #region THIẾT LẬP CHỨNG CHỈ ĐIỀU KIỆN
    public static object[] Fdt_NS_TL_CCHN_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_TL_CCHN_LKE");
    }
    public static void P_NS_TL_CCHN_NH(DataTable b_dt, DataTable b_dt_ct)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_ccc = bang.Fobj_COL_MANG(b_dt_ct, "ma_ccc");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ccc", 'S', a_ma_ccc);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma_cchn"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"]) + "," + chuyen.OBJ_C(b_dr["tc"])
                            + "," + chuyen.OBJ_C(b_dr["ghichu"]) + ",:a_ma_ccc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_CCHN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Fdt_NS_TL_CCHN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TL_CCHN_MA");
    }
    public static DataTable Fdt_NS_TL_CCHN_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_TL_CCHN_CT");
    }
    public static void PNS_TL_CCHN_XOA(string b_ma, string b_ngay_hl)
    {
        dbora.P_GOIHAM(new object[] { b_ma, chuyen.CNG_SO(b_ngay_hl) }, "PNS_TL_CCHN_XOA");
    }

    public static DataTable Fdt_NS_TL_CCHN_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_TL_CCHN_EXPORT");
    }
    #endregion
     
    #region MÃ XÃ PHƯỜNG -- NghiepDo

    //liệt kê tỉnh thành theo mã nước
    public static DataTable Fdt_NghiepDo_NS_MA_QG_TT(string b_ma_tl)
    {
        return dbora.Fdt_LKE_S(b_ma_tl, "NGHIEPDO_PNS_MA_MA_QG_TT");
    }

    //liệt kê quận/huyện theo mã tỉnh thành
    public static DataTable Fdt_NghiepDo_NS_MA_TT_QH(string b_ma_tl)
    {
        return dbora.Fdt_LKE_S(b_ma_tl, "NGHIEPDO_PNS_MA_MA_TT_QH");
    }

    //liệt kê quận/huyện theo mã tỉnh thành
    public static DataTable Fdt_NghiepDo_NS_MA_QH_XP(string b_ma_tl)
    {
        return dbora.Fdt_LKE_S(b_ma_tl, "NGHIEPDO_PNS_MA_MA_QH_XP");
    }

    ///<summary>Liệt kê QG drop</summary>
    public static DataTable Fdt_NghiepDo_NS_MA_QG_DR()
    {
        return dbora.Fdt_LKE("NGHIEPDO_PNS_MA_QG_DR");
    }

    public static object[] Fdt_NghiepDo_NS_MA_XP_LKE(string b_ma_qg, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_qg, b_tu_n, b_den_n }, "NR", "NGHIEPDO_PNS_MA_XP_LKE");
    }

    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NghiepDo_NS_MA_XP_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "NGHIEPDO_PNS_MA_XP_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NghiepDo_NS_MA_XP_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "NS_MA_XP", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("XP", "NS_MA_XP", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma_qh"], b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "NGHIEPDO_PNS_MA_XP_NH");
        b_ma = b_dr["ma"].ToString();
    }

    ///<summary> Xóa </summary> ///
    public static void P_NghiepDo_NS_MA_XP_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "NGHIEPDO_PNS_MA_XP_XOA");
    }
    #endregion

    #region ĐÀO TẠO

    public static object[] Fdt_DAOTAO_GRIDX_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_MA_NUOC_LKE");
    }
    #endregion ĐÀO TẠO

    #region Quang_BaiTap1


    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_QUANG_BAI1_LKE(double b_tu_n, double b_den_n, string b_tt)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_tt }, "NR", "PNS_QUANG_BAI1_LKE");
    }

    ///<summary>Liệt kê số liệu drop</summary>
    public static DataTable Fdt_NS_QUANG_BAI1_DR()
    {
        return dbora.Fdt_LKE("PNS_QUANG_BAI1_DR");
    }

    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_QUANG_BAI1_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_QUANG_BAI1_MA");
    }
    /// <summary> Nhap so lieu</summary>
    public static void P_NS_QUANG_BAI1_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "QUANG_BAI1", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("TINH", "QUANG_BAI1", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ghichu"] }, "PNS_QUANG_BAI1_NH");
        b_ma = b_dr["ma"].ToString();
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_QUANG_BAI1_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_QUANG_BAI1_XOA");
    }

    #endregion

    #region TIN_BaiTap1

    public static object[] Fdt_TIN_BAI1_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TIN_BAI1_MA");
    }

    public static object[] Fdt_TIN_BAI1_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TIN_BAI1_LKE");
    }

    public static DataTable Fdt_NS_TIN_BAI1_DR()
    {
        return dbora.Fdt_LKE("PNS_TIN_BAI1_DR");
    }
    public static void P_TIN_BAI1_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "DAOTAO_BAI1", "MA");
        if (b_kiemtra == false)
        {
            b_dr["ma"] = ht_dungchung.Fdt_AutoGenCode("T", "DAOTAO_BAI1", "MA");
        }
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "PNS_TIN_BAI1_NH");
        b_ma = b_dr["ma"].ToString();
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_TIN_BAI1_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_TIN_BAI1_XOA");
    }

    public static DataSet Fds_TIN_BAI1_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 1, "PNS_TIN_BAI1_CT");
    }
    #endregion
    #region TIN_BaiTap4

    public static object[] Fdt_TIN_BAI4_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TIN_BAI4_LKE");
    }

    public static void P_TIN_BAI4_NH(DataTable b_dt, ref string b_ma)
    {
        DataRow b_dr = b_dt.Rows[0];
        bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["MA"].ToString(), "DAOTAO_BAI4", "MA");
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "PNS_TIN_BAI4_NH");
        b_ma = b_dr["ma"].ToString();
    }

    public static object[] Fdt_TIN_BAI4_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TIN_BAI4_MA");
    }

    public static DataSet Fds_TIN_BAI4_CT(string b_ma)
    {
        return dbora.Fds_LKE(b_ma, 1, "PNS_TIN_BAI4_CT");
    }
    #endregion

}
