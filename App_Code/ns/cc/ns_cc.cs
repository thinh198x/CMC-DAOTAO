using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_cc
{
    #region BẢNG CHẤM CÔNG MÁY
    public static object[] Fdt_NS_CC_TH_MAY_LKE(string b_phong, double b_tu, double b_den, string b_kyluong, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_tu, b_den, b_so_the }, "NR", "PNS_CC_TH_MAY_LKE");
    }
    public static DataSet Fdt_NS_CC_TH_MAY_EXCEL(string b_phong, string b_kyluong, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the }, 1, "PNS_CC_TH_MAY_EXCEL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_TH_MAY_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_CC_TH_MAY_MA");
    }
    public static DataTable Fdt_NS_CC_TH_MAY_CT(string b_phong, string b_kyluong_id, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_tu, b_den }, "PNS_CC_TH_MAY_CT");
    }

    public static void P_NS_CC_TH_MAY_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_phong_cp = bang.Fobj_COL_MANG(b_dt_ct, "phong_cp");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_luong_tg = bang.Fobj_COL_MANG(b_dt_ct, "luong_tg");
            object[] a_luong_sp = bang.Fobj_COL_MANG(b_dt_ct, "luong_sp");
            object[] a_luong_khoan = bang.Fobj_COL_MANG(b_dt_ct, "luong_khoan");
            object[] a_luong_bh = bang.Fobj_COL_MANG(b_dt_ct, "luong_bh");
            object[] a_anca = bang.Fobj_COL_MANG(b_dt_ct, "anca");
            object[] a_pcap = bang.Fobj_COL_MANG(b_dt_ct, "pcap");
            object[] a_tnhap_chiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhap_chiuthue");
            object[] a_tnhap_kchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhap_kchiuthue");
            object[] a_bhxh = bang.Fobj_COL_MANG(b_dt_ct, "bhxh");
            object[] a_bhyt = bang.Fobj_COL_MANG(b_dt_ct, "bhyt");
            object[] a_bhtn = bang.Fobj_COL_MANG(b_dt_ct, "bhtn");
            object[] a_pcd = bang.Fobj_COL_MANG(b_dt_ct, "pcd");
            object[] a_ct_bhxh = bang.Fobj_COL_MANG(b_dt_ct, "ct_bhxh");
            object[] a_ct_bhyt = bang.Fobj_COL_MANG(b_dt_ct, "ct_bhyt");
            object[] a_ct_bhtn = bang.Fobj_COL_MANG(b_dt_ct, "ct_bhtn");
            object[] a_ct_pcd = bang.Fobj_COL_MANG(b_dt_ct, "ct_pcd");
            object[] a_ktru_chiuthue = bang.Fobj_COL_MANG(b_dt_ct, "ktru_chiuthue");
            object[] a_ktru_kchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "ktru_kchiuthue");
            object[] a_truthue = bang.Fobj_COL_MANG(b_dt_ct, "truthue");
            object[] a_tam_ung = bang.Fobj_COL_MANG(b_dt_ct, "tam_ung");
            object[] a_thuc_linh = bang.Fobj_COL_MANG(b_dt_ct, "thuc_linh");

            object[] a_lv_thucte = bang.Fobj_COL_MANG(b_dt_ct, "lv_thucte");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
            object[] a_hso_nn = bang.Fobj_COL_MANG(b_dt_ct, "hso_nn");
            object[] a_hspc_nn = bang.Fobj_COL_MANG(b_dt_ct, "hspc_nn");
            object[] a_luong_nn = bang.Fobj_COL_MANG(b_dt_ct, "luong_nn");
            object[] a_capbac_cv = bang.Fobj_COL_MANG(b_dt_ct, "capbac_cv");
            object[] a_hso_cv = bang.Fobj_COL_MANG(b_dt_ct, "hso_cv");
            object[] a_luong_cv = bang.Fobj_COL_MANG(b_dt_ct, "luong_cv");
            object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt_ct, "phuthuoc");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong_cp", 'S', a_phong_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_tg", 'N', a_luong_tg);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_sp", 'N', a_luong_sp);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_khoan", 'N', a_luong_khoan);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_bh", 'N', a_luong_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_anca", 'N', a_anca);
            dbora.P_THEM_PAR(ref b_lenh, "a_pcap", 'N', a_pcap);
            dbora.P_THEM_PAR(ref b_lenh, "a_tnhap_chiuthue", 'N', a_tnhap_chiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_tnhap_kchiuthue", 'N', a_tnhap_kchiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'N', a_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhyt", 'N', a_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhtn", 'N', a_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_pcd", 'N', a_pcd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ct_bhxh", 'N', a_ct_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ct_bhyt", 'N', a_ct_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ct_bhtn", 'N', a_ct_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ct_pcd", 'N', a_ct_pcd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktru_chiuthue", 'N', a_ktru_chiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktru_kchiuthue", 'N', a_ktru_kchiuthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_truthue", 'N', a_truthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_tam_ung", 'N', a_tam_ung);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuc_linh", 'N', a_thuc_linh);

            dbora.P_THEM_PAR(ref b_lenh, "a_lv_thucte", 'N', a_lv_thucte);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'S', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso_nn", 'N', a_hso_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_hspc_nn", 'N', a_hspc_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_nn", 'N', a_luong_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac_cv", 'S', a_capbac_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso_cv", 'N', a_hso_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_cv", 'N', a_luong_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'N', a_phuthuoc);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thang"])
                + ",:a_phong_cp,:a_so_the,:a_ten,:a_luong_tg,:a_luong_sp,:a_luong_khoan,:a_luong_bh,:a_anca,:a_pcap,:a_tnhap_chiuthue,:a_tnhap_kchiuthue"
                + ",:a_bhxh,:a_bhyt,:a_bhtn,:a_pcd,:a_ct_bhxh,:a_ct_bhyt,:a_ct_bhtn,:a_ct_pcd,:a_ktru_chiuthue,:a_ktru_kchiuthue,:a_truthue,:a_tam_ung,:a_thuc_linh"
            + ",:a_lv_thucte,:a_capbac,:a_hso_nn,:a_hspc_nn,:a_luong_nn,:a_capbac_cv,:a_hso_cv,:a_luong_cv,:a_phuthuoc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_TH_MAY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_CC_TH_MAY_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_CC_TH_MAY_XOA");
    }
    public static DataTable Fdt_NS_CC_TH_MAY_LKE_CB(string b_phong, string b_thang, double b_tu_n, double b_den_n)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.OBJ_N(b_thang), b_tu_n, b_den_n }, "PNS_CC_TH_MAY_LKE_CB");
        return b_dt;
    }

    public static DataTable Fdt_NS_CC_TH_MAY_LKE_CB_XUANTHANH(string b_phong, string b_thang)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_CC_TH_MAY_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "lv_thucte", "TN_TINHTHUE", "chenhca", "TNHAP_CHIUTHUE", "phep", "capbac", "hso_nn", "tong_luong", "hspc_nn", "luong_nn", "capbac_cv", "hso_cv", "luong_cv", "doanhthu", "luong_doanhthu", "anca", "pcap", "PHAITRA_NLD", "bhxh", "bhyt", "bhtn", "pcd", "ct_bhxh", "ct_bhyt", "ct_bhtn", "ct_pcd", "ktru_chiuthue", "ktru_kchiuthue", "phuthuoc", "truthue", "tam_ung", "thuc_linh", "LV_THUCTE_OKIFOOD", "NGHI_CL", "NGHI_KCL", "HSPC_NN_TIEN", "CONG_CC4", "TIENCONG4", "CONG_CC5", "TIENCONG5", "CONG_CC6", "TIENCONG6", "CONG_CC7", "TIENCONG7", "CONG_CC8", "TIENCONG8", "CONG_CC9", "TIENCONG9", "XANGXE", "DIENTHOAI", "LUONG_LT", "TONG_PC", "TONG_LUONG_PC", "PHAITRA_NLD" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }
    ///<summary> Tính Lương Tháng </summary>
    ///
    public static object[] Fdt_NS_CC_TH_MAY_TINH(string b_phong, string b_kyluong, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, b_tu, b_den }, "NR", "pns_cc_th_may_tinh");

    }
    public static DataTable Fdt_NS_CC_TH_MAY_TINH_XUANTHANH(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_XT");

    }

    public static DataTable Fdt_NS_CC_TH_MAY_TINH_OKI(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_OKI");

    }
    #endregion BẢNG CHẤM CÔNG MÁY

    #region TỔNG HỢP CÔNG
    public static DataTable Fdt_NS_CC_TH_LKE_COT()
    {
        return dbora.Fdt_LKE("PNS_CC_TH_LKE_COT");
    }

    public static object[] Fdt_NS_CC_TH_LKE(string b_phong, double b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_LKE");
    }


    public static object[] Fdt_NS_CC_TH_TINH(string b_phong, double b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_TINH");

    }
    #endregion

    #region THIẾT LẬP CÔNG THỨC CÔNG
    public static DataTable Fdt_NS_CC_CT_CONG_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_CT_CONG_CT");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CC_CT_CONG_LKE(string b_ma_dvi, string b_dtuong, double b_loai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n }, "NR", "PNS_CC_CT_CONG_LKE");
    }
    public static object[] Fdt_NS_CC_CT_CONG_LKE_DV(string b_ma_dvi, string b_dtuong, double b_loai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n }, "NR", "PNS_CC_CT_CONG_LKE_DV");
    }

    ///<summary>liet ke sau kiem tra </summary> 
    public static object[] Fdt_Fs_TL_CC_CONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_TL_CC_CONG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CC_CT_CONG_NH(double b_so_id, DataTable b_dt_ct)
    {
        if (b_dt_ct.Rows.Count > 0)
        {
            DataRow dr = b_dt_ct.Rows[0];
            dbora.P_GOIHAM(new object[] { b_so_id, dr["trang_thai"], dr["hien_thi"], dr["sott_nhom"], dr["sott_hien_thi"], dr["congthuc"] }, "PNS_CC_CT_CONG_NH");
        }
    }
    public static void P_NS_CC_CT_CONG_KT(double b_loai, string b_cotct, string b_ct)
    {
        dbora.P_GOIHAM(new object[] { b_loai, b_cotct, b_ct }, "PNS_CC_CT_CONG_KT");
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_TL_CC_CONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_TL_CC_CONG_XOA");
    }
    #endregion THIẾT LẬP CÔNG THỨC CÔNG

    #region THIẾT LẬP PHÉP THEO CHỨC DANH

    public static object[] Fobj_NS_CC_CD_PHEP_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_CD_PHEP_LKE");
    }

    public static object[] Fobj_NS_CC_CD_PHEP_MA(string b_so_id,double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] {b_so_id, b_trangkt }, "NNR", "PNS_CC_CD_PHEP_MA");
    }
    public static DataSet Fds_NS_CC_CD_PHEP_CT(string b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { chuyen.CSO_SO(b_so_id) }, 2, "PNS_CC_CD_PHEP_CT");
        return b_ds;
    }

    public static void P_NS_CC_CD_PHEP_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        DataRow b_dr = b_dt.Rows[0];
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ma_cdanh");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ten_cdanh");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_S(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["phep"]) + "," + chuyen.OBJ_S(b_dr["ngay_bd"]) + "," + chuyen.OBJ_S(b_dr["ngay_kt"])
                        + "," + chuyen.OBJ_C(b_dr["nngoai"]) + "," + chuyen.OBJ_S(b_dr["phep_nn"]);
            b_c = b_c + ",:a_cdanh,:a_ten_cdanh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CD_PHEP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_CC_CD_PHEP_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_CC_CD_PHEP_XOA");
    }
    #endregion THIẾT LẬP PHÉP THEO CHỨC DANH
}