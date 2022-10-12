using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;


public class khud_files
{
    #region TẠO THÔNG TIN LƯU THÊM MENU (ldmenu,nvmenu)
    public static void THAM_SO_MENU()
    {
        try
        {
            DataTable b_dt_ldmenu = khac.Fdt_Excel(HttpContext.Current.Server.MapPath("~/bin/ldmenu.xls"));
            if (!bang.Fb_TRANG(b_dt_ldmenu))
            {
                b_dt_ldmenu.TableName = "ldmenu"; bang.P_DON(ref b_dt_ldmenu, "ma");
                bang.P_BO_HANG(ref b_dt_ldmenu, "che", "C"); bang.P_OBJ_CH(ref b_dt_ldmenu, "tso");
                HttpContext.Current.Application["ldmenu"] = b_dt_ldmenu;
            }
            DataTable b_dt_nvmenu = khac.Fdt_Excel(HttpContext.Current.Server.MapPath("~/bin/nvmenu.xls"));
            if (!bang.Fb_TRANG(b_dt_nvmenu))
            {
                b_dt_nvmenu.TableName = "nvmenu"; bang.P_DON(ref b_dt_nvmenu, "ma");
                bang.P_BO_HANG(ref b_dt_nvmenu, "che", "C"); bang.P_OBJ_CH(ref b_dt_nvmenu, "tso");
                HttpContext.Current.Application["nvmenu"] = b_dt_nvmenu;
            }
        }
        catch { throw new Exception("loi:Lỗi khởi tạo tham số kết nối:loi"); }
    }
    #endregion TẠO THÔNG TIN LƯU THÊM MENU (ldmenu,nvmenu)

    #region FILES
    /// <summary>Thực hiện Liệt kê ban đầu</summary>
    public static DataTable Fdt_FILES_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.CSO_SO(b_so_id), "PKHUD_QL_FILES_LKE");
    }
    /// <summary>Thực hiện Liệt kê ban đầu</summary>
    public static DataTable Fdt_FILES_CT(string b_so_id, string b_tt)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_so_id), chuyen.CSO_SO(b_tt) }, "PKHUD_QL_FILES_CT");
    }
    /// <summary>Thực hiện nhập dữ liệu về files</summary>
    public static void P_FILES_NH(ref string b_tt, string b_so_id, string b_tenf, string b_url)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            dbora.P_THEM_PAR(ref b_lenh, "tt", 'N', 'O', chuyen.CSO_SO(b_tt));
            string b_c = "," + chuyen.OBJ_S(chuyen.OBJ_N(b_so_id)) + "," + chuyen.OBJ_C(b_tenf) + "," + chuyen.OBJ_C(b_url) + ",:tt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PKHUD_QL_FILES_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_tt = chuyen.OBJ_S(b_lenh.Parameters["tt"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Thực hiện xoa dữ liệu về files</summary>
    public static void P_FILES_XOA(string b_so_id, string b_tt)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id), chuyen.CSO_SO(b_tt) }, "PKHUD_QL_FILES_XOA");
    }
    #endregion FILES

    #region FILES KHUD UPLOAD
    /// <summary>Thực hiện Liệt kê ban đầu</summary>
    public static DataTable Fdt_NS_KHUD_FILES_UP_LKE(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_KHUD_FILES_UP_LKE");
    }
    /// <summary>Thực hiện Liệt kê ban đầu</summary>
    public static DataTable Fdt_NS_KHUD_FILES_UP_CT(string b_ma, string b_tt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, chuyen.CSO_SO(b_tt) }, "PNS_KHUD_FILES_UP_CT");
    }
    /// <summary>Thực hiện nhập dữ liệu về files</summary>
    public static void P_NS_KHUD_FILES_UP_NH(ref string b_tt, string b_ma, string b_tenbc, string b_tenf, string b_url)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            dbora.P_THEM_PAR(ref b_lenh, "tt", 'N', 'O', chuyen.CSO_SO(b_tt));
            string b_c = "," + chuyen.OBJ_C(b_ma) + "," + chuyen.OBJ_C(b_tenbc) + "," + chuyen.OBJ_C(b_tenf) + "," + chuyen.OBJ_C(b_url) + ",:tt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_UP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_tt = chuyen.OBJ_S(b_lenh.Parameters["tt"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Thực hiện xoa dữ liệu về files</summary>
    public static void P_NS_KHUD_FILES_UP_XOA(string b_ma, string b_tt)
    {
        dbora.P_GOIHAM(new object[] { b_ma, chuyen.CSO_SO(b_tt) }, "PNS_KHUD_FILES_UP_XOA");
    }
    #endregion FILES KHUD UPLOAD

    #region IMPORT THÔNG TIN NHÂN SỰ
    public static string KHUD_FILES_NS(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngay_sinh,ngay_cmt_mst,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngay_bd_hopdong,ngaythamgia,ngay_cap_hchieu,ngay_cap_mst");

            bang.P_THEM_COL(ref b_dt, "tt", "0");
            bang.P_THEM_COL(ref b_dt, "tenhoa", "0");
            for (int j = 0; j < b_dt.Rows.Count; j++)
            {
                b_dt.Rows[j]["tt"] = j + 1;
                b_dt.Rows[j]["tenhoa"] = c_kieu_chu.P_BODAU(b_dt.Rows[j]["ten_cb"].ToString().ToUpper());
            }

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ten_cb = bang.Fobj_COL_MANG(b_dt, "ten_cb");
            object[] a_ten_hoa = bang.Fobj_COL_MANG(b_dt, "tenhoa");
            object[] a_gioitinh_ma = bang.Fobj_COL_MANG(b_dt, "gioitinh_ma");
            object[] a_ngay_sinh = bang.Fobj_COL_MANG(b_dt, "ngay_sinh");
            object[] a_dtnr = bang.Fobj_COL_MANG(b_dt, "dtnr");
            object[] a_dtdd = bang.Fobj_COL_MANG(b_dt, "dtdd");
            object[] a_email = bang.Fobj_COL_MANG(b_dt, "email");
            object[] a_tt_honnhan_ma = bang.Fobj_COL_MANG(b_dt, "tt_honnhan_ma");
            object[] a_so_cmt_mst = bang.Fobj_COL_MANG(b_dt, "so_cmt_mst");
            object[] a_ngay_cmt_mst = bang.Fobj_COL_MANG(b_dt, "ngay_cmt_mst");
            object[] a_nc_cmt_mst_ten = bang.Fobj_COL_MANG(b_dt, "nc_cmt_mst_ten");
            object[] a_so_cmt = bang.Fobj_COL_MANG(b_dt, "so_cmt");
            object[] a_ngay_cmt = bang.Fobj_COL_MANG(b_dt, "ngay_cmt");
            object[] a_nc_cmt_ten = bang.Fobj_COL_MANG(b_dt, "nc_cmt_ten");
            object[] a_nn_ma = bang.Fobj_COL_MANG(b_dt, "nn_ma");
            object[] a_dantoc_ma = bang.Fobj_COL_MANG(b_dt, "dantoc_ma");
            object[] a_tongiao_ma = bang.Fobj_COL_MANG(b_dt, "tongiao_ma");
            object[] a_noi_sinh = bang.Fobj_COL_MANG(b_dt, "noi_sinh");
            object[] a_tt_noisinh_ma = bang.Fobj_COL_MANG(b_dt, "tt_noisinh_ma");
            object[] a_qh_noisinh_ma = bang.Fobj_COL_MANG(b_dt, "qh_noisinh_ma");
            object[] a_xp_noisinh_ma = bang.Fobj_COL_MANG(b_dt, "xp_noisinh_ma");
            object[] a_dchi_thuongtru = bang.Fobj_COL_MANG(b_dt, "dchi_thuongtru");
            object[] a_tt_thuongtru_ma = bang.Fobj_COL_MANG(b_dt, "tt_thuongtru_ma");
            object[] a_qh_thuongtru_ma = bang.Fobj_COL_MANG(b_dt, "qh_thuongtru_ma");
            object[] a_xp_thuongtru_ma = bang.Fobj_COL_MANG(b_dt, "xp_thuongtru_ma");
            object[] a_dchi_tamtru = bang.Fobj_COL_MANG(b_dt, "dchi_tamtru");
            object[] a_tt_tamtru_ma = bang.Fobj_COL_MANG(b_dt, "tt_tamtru_ma");
            object[] a_qh_tamtru_ma = bang.Fobj_COL_MANG(b_dt, "qh_tamtru_ma");
            object[] a_xp_tamtru_ma = bang.Fobj_COL_MANG(b_dt, "xp_tamtru_ma");
            object[] a_khican_ll = bang.Fobj_COL_MANG(b_dt, "khican_ll");
            object[] a_ma_donvi = bang.Fobj_COL_MANG(b_dt, "ma_donvi");
            object[] a_ma_ban = bang.Fobj_COL_MANG(b_dt, "ma_ban");
            object[] a_ma_phong_ban = bang.Fobj_COL_MANG(b_dt, "ma_phong_ban");
            object[] a_la_cty_chinh = bang.Fobj_COL_MANG(b_dt, "la_cty_chinh");
            object[] a_nhom_cd_ma = bang.Fobj_COL_MANG(b_dt, "nhom_cd_ma");
            object[] a_cdanh_ma = bang.Fobj_COL_MANG(b_dt, "cdanh_ma");
            object[] a_bac_cdanh_ma = bang.Fobj_COL_MANG(b_dt, "bac_cdanh_ma");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngay_tv = bang.Fobj_COL_MANG(b_dt, "ngay_tv");
            object[] a_ngay_ct = bang.Fobj_COL_MANG(b_dt, "ngay_ct");
            object[] a_ngay_bd_hopdong = bang.Fobj_COL_MANG(b_dt, "ngay_bd_hopdong");
            object[] a_ma_nsd = bang.Fobj_COL_MANG(b_dt, "ma_nsd");
            object[] a_quanly_tt = bang.Fobj_COL_MANG(b_dt, "quanly_tt");
            object[] a_email_cty = bang.Fobj_COL_MANG(b_dt, "email_cty");
            object[] a_ma_cc = bang.Fobj_COL_MANG(b_dt, "ma_cc");
            object[] a_ma_pbo = bang.Fobj_COL_MANG(b_dt, "ma_pbo");
            object[] a_dt_cutru_ma = bang.Fobj_COL_MANG(b_dt, "dt_cutru_ma");
            object[] a_so_bhxh = bang.Fobj_COL_MANG(b_dt, "so_bhxh");
            object[] a_ngaythamgia = bang.Fobj_COL_MANG(b_dt, "ngaythamgia");
            object[] a_so_hchieu = bang.Fobj_COL_MANG(b_dt, "so_hchieu");
            object[] a_ngay_cap_hchieu = bang.Fobj_COL_MANG(b_dt, "ngay_cap_hchieu");
            object[] a_noicap_visa = bang.Fobj_COL_MANG(b_dt, "noicap_visa");
            object[] a_mast = bang.Fobj_COL_MANG(b_dt, "mast");
            object[] a_ht_tinhluong_ma = bang.Fobj_COL_MANG(b_dt, "ht_tinhluong_ma");
            object[] a_ngay_cap_mst = bang.Fobj_COL_MANG(b_dt, "ngay_cap_mst");
            object[] a_cqthue = bang.Fobj_COL_MANG(b_dt, "cqthue");
            object[] a_chieucao = bang.Fobj_COL_MANG(b_dt, "chieucao");
            object[] a_cannang = bang.Fobj_COL_MANG(b_dt, "cannang");
            object[] a_nhommau = bang.Fobj_COL_MANG(b_dt, "nhommau");
            object[] a_sotk = bang.Fobj_COL_MANG(b_dt, "sotk");
            object[] a_nha_ma = bang.Fobj_COL_MANG(b_dt, "nha_ma");
            object[] a_cnhanh_nha_ma = bang.Fobj_COL_MANG(b_dt, "cnhanh_nha_ma");

            object[] a_tt = bang.Fobj_COL_MANG(b_dt, "tt");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cb", 'U', a_ten_cb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_hoa", 'U', a_ten_hoa);
            dbora.P_THEM_PAR(ref b_lenh, "a_gioitinh_ma", 'S', a_gioitinh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_sinh", 'N', a_ngay_sinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_dtnr", 'S', a_dtnr);
            dbora.P_THEM_PAR(ref b_lenh, "a_dtdd", 'S', a_dtdd);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_honnhan_ma", 'S', a_tt_honnhan_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_cmt_mst", 'S', a_so_cmt_mst);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cmt_mst", 'N', a_ngay_cmt_mst);
            dbora.P_THEM_PAR(ref b_lenh, "a_nc_cmt_mst_ten", 'U', a_nc_cmt_mst_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_cmt", 'S', a_so_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cmt", 'N', a_ngay_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nc_cmt_ten", 'U', a_nc_cmt_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_nn_ma", 'S', a_nn_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_dantoc_ma", 'S', a_dantoc_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongiao_ma", 'S', a_tongiao_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_sinh", 'U', a_noi_sinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_noisinh_ma", 'S', a_tt_noisinh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_noisinh_ma", 'S', a_qh_noisinh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_noisinh_ma", 'S', a_xp_noisinh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_dchi_thuongtru", 'U', a_dchi_thuongtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_thuongtru_ma", 'S', a_tt_thuongtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_thuongtru_ma", 'S', a_qh_thuongtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_thuongtru_ma", 'S', a_xp_thuongtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_dchi_tamtru", 'U', a_dchi_tamtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_tamtru_ma", 'S', a_tt_tamtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_tamtru_ma", 'S', a_qh_tamtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_tamtru_ma", 'S', a_xp_tamtru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_khican_ll", 'U', a_khican_ll);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_donvi", 'S', a_ma_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ban", 'S', a_ma_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_phong_ban", 'S', a_ma_phong_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_la_cty_chinh", 'S', a_la_cty_chinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cd_ma", 'S', a_nhom_cd_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_ma", 'S', a_cdanh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_bac_cdanh_ma", 'S', a_bac_cdanh_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_tv", 'N', a_ngay_tv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ct", 'N', a_ngay_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bd_hopdong", 'N', a_ngay_bd_hopdong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nsd", 'S', a_ma_nsd);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanly_tt", 'U', a_quanly_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_email_cty", 'S', a_email_cty);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cc", 'S', a_ma_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pbo", 'S', a_ma_pbo);
            dbora.P_THEM_PAR(ref b_lenh, "a_dt_cutru_ma", 'S', a_dt_cutru_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_bhxh", 'S', a_so_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythamgia", 'N', a_ngaythamgia);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_hchieu", 'S', a_so_hchieu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cap_hchieu", 'N', a_ngay_cap_hchieu);
            dbora.P_THEM_PAR(ref b_lenh, "a_noicap_visa", 'U', a_noicap_visa);
            dbora.P_THEM_PAR(ref b_lenh, "a_mast", 'S', a_mast);
            dbora.P_THEM_PAR(ref b_lenh, "a_ht_tinhluong_ma", 'S', a_ht_tinhluong_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cap_mst", 'N', a_ngay_cap_mst);
            dbora.P_THEM_PAR(ref b_lenh, "a_cqthue", 'U', a_cqthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_chieucao", 'S', a_chieucao);
            dbora.P_THEM_PAR(ref b_lenh, "a_cannang", 'S', a_cannang);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhommau", 'S', a_nhommau);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotk", 'S', a_sotk);
            dbora.P_THEM_PAR(ref b_lenh, "a_nha_ma", 'S', a_nha_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_cnhanh_nha_ma", 'S', a_cnhanh_nha_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);

            string b_c = ",:a_so_the,:a_ten_cb,:a_ten_hoa,:a_gioitinh_ma,:a_ngay_sinh,:a_dtnr,:a_dtdd,:a_email,:a_tt_honnhan_ma,:a_so_cmt_mst,:a_ngay_cmt_mst";
            b_c = b_c + ",:a_nc_cmt_mst_ten,:a_so_cmt,:a_ngay_cmt,:a_nc_cmt_ten,:a_nn_ma,:a_dantoc_ma,:a_tongiao_ma,:a_noi_sinh,:a_tt_noisinh_ma";
            b_c = b_c + ",:a_qh_noisinh_ma,:a_xp_noisinh_ma,:a_dchi_thuongtru,:a_tt_thuongtru_ma,:a_qh_thuongtru_ma,:a_xp_thuongtru_ma,:a_dchi_tamtru";
            b_c = b_c + ",:a_tt_tamtru_ma,:a_qh_tamtru_ma,:a_xp_tamtru_ma,:a_khican_ll,:a_ma_donvi,:a_ma_ban,:a_ma_phong_ban,:a_la_cty_chinh,:a_nhom_cd_ma";
            b_c = b_c + ",:a_cdanh_ma,:a_bac_cdanh_ma,:a_ngayd,:a_ngay_tv,:a_ngay_ct,:a_ngay_bd_hopdong,:a_ma_nsd,:a_quanly_tt,:a_email_cty,:a_ma_cc";
            b_c = b_c + ",:a_ma_pbo,:a_dt_cutru_ma,:a_so_bhxh,:a_ngaythamgia,:a_so_hchieu,:a_ngay_cap_hchieu,:a_noicap_visa,:a_mast,:a_ht_tinhluong_ma";
            b_c = b_c + ",:a_ngay_cap_mst,:a_cqthue,:a_chieucao,:a_cannang,:a_nhommau,:a_sotk,:a_nha_ma,:a_cnhanh_nha_ma,:a_tt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_NS(" + b_se.tso + b_c + "); end;";

            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT THÔNG TIN NHÂN SỰ

    #region IMPORT THÔNG TIN PHÒNG BAN
    public static string KHUD_FILES_PHONG(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CH_BLANK(ref b_dt, "ma_ct");

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ma_ct");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ct", 'S', a_ma_ct);

            string b_c = ",:a_ma,:a_ten,:a_ma_ct";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_PHONG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT THÔNG TIN PHÒNG BAN

    #region IMPORT HOẠT ĐỘNG CÔNG TÁC
    public static string KHUD_FILES_HDCT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc,ngay_qd,ngay_bn_landau,ngay_bn_gannhat");
            bang.P_CSO_SO(ref b_dt, "luongcb,tong_luong,thuong,pt_hluong");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_hinhthuc_ma = bang.Fobj_COL_MANG(b_dt, "hinhthuc_ma");
            object[] a_soqd = bang.Fobj_COL_MANG(b_dt, "soqd");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_ma_tl = bang.Fobj_COL_MANG(b_dt, "ma_tl");
            object[] a_ma_nl = bang.Fobj_COL_MANG(b_dt, "ma_nl");
            object[] a_ma_bl = bang.Fobj_COL_MANG(b_dt, "ma_bl");
            object[] a_luongcb = bang.Fobj_COL_MANG(b_dt, "luongcb");
            object[] a_tong_luong = bang.Fobj_COL_MANG(b_dt, "tong_luong");
            object[] a_thuong = bang.Fobj_COL_MANG(b_dt, "thuong");
            object[] a_pt_hluong = bang.Fobj_COL_MANG(b_dt, "pt_hluong");
            object[] a_ma_nguoiky = bang.Fobj_COL_MANG(b_dt, "ma_nguoiky");
            object[] a_ten_cdanh_nguoiky = bang.Fobj_COL_MANG(b_dt, "ten_cdanh_nguoiky");
            object[] a_ngay_qd = bang.Fobj_COL_MANG(b_dt, "ngay_qd");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");
            object[] a_ngay_bn_landau = bang.Fobj_COL_MANG(b_dt, "ngay_bn_landau");
            object[] a_ngay_bn_gannhat = bang.Fobj_COL_MANG(b_dt, "ngay_bn_gannhat");
            object[] a_phong_m = bang.Fobj_COL_MANG(b_dt, "phong_m");
            object[] a_cdanh_m = bang.Fobj_COL_MANG(b_dt, "cdanh_m");
            object[] a_dvi_ctac = bang.Fobj_COL_MANG(b_dt, "dvi_ctac");
            object[] a_diadiem_ctac = bang.Fobj_COL_MANG(b_dt, "diadiem_ctac");
            object[] a_lydo_ctac = bang.Fobj_COL_MANG(b_dt, "lydo_ctac");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc_ma", 'S', a_hinhthuc_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_soqd", 'S', a_soqd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tl", 'S', a_ma_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nl", 'S', a_ma_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_bl", 'S', a_ma_bl);
            dbora.P_THEM_PAR(ref b_lenh, "a_luongcb", 'N', a_luongcb);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_luong", 'N', a_tong_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong", 'N', a_thuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_pt_hluong", 'N', a_pt_hluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nguoiky", 'S', a_ma_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh_nguoiky", 'U', a_ten_cdanh_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_qd", 'N', a_ngay_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bn_landau", 'N', a_ngay_bn_landau);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bn_gannhat", 'N', a_ngay_bn_gannhat);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong_m", 'S', a_phong_m);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_m", 'S', a_cdanh_m);
            dbora.P_THEM_PAR(ref b_lenh, "a_dvi_ctac", 'U', a_dvi_ctac);
            dbora.P_THEM_PAR(ref b_lenh, "a_diadiem_ctac", 'U', a_diadiem_ctac);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ctac", 'U', a_lydo_ctac);


            string b_c = ",:a_so_the,:a_hinhthuc_ma,:a_soqd,:a_ngayd,:a_ngayc,:a_ma_tl,:a_ma_nl,:a_ma_bl,:a_luongcb,:a_tong_luong,:a_thuong,:a_pt_hluong,:a_ma_nguoiky";
            b_c += ",:a_ten_cdanh_nguoiky,:a_ngay_qd,:a_ghichu,:a_ngay_bn_landau,:a_ngay_bn_gannhat,:a_phong_m,:a_cdanh_m,:a_dvi_ctac,:a_diadiem_ctac,:a_lydo_ctac";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_HDCT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion IMPORT HOẠT ĐỘNG CÔNG TÁC

    #region IMPORT THÔNG TIN BẢO HIỂM XÃ HỘI
    public static string KHUD_FILES_BHXH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt, "ngay_bhxh,ndongbhxh,ndongbhtn,ngayd,ngayc,ngay_trabhxh,ngay_trabhyt");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_bhxh = bang.Fobj_COL_MANG(b_dt, "bhxh");
            object[] a_bhyt = bang.Fobj_COL_MANG(b_dt, "bhyt");
            object[] a_bhtn = bang.Fobj_COL_MANG(b_dt, "bhtn");
            object[] a_dcapso = bang.Fobj_COL_MANG(b_dt, "dcapso");
            object[] a_sobhxh = bang.Fobj_COL_MANG(b_dt, "sobhxh");
            object[] a_ngay_bhxh = bang.Fobj_COL_MANG(b_dt, "ngay_bhxh");
            object[] a_noicap = bang.Fobj_COL_MANG(b_dt, "noicap");
            object[] a_ndongbhxh = bang.Fobj_COL_MANG(b_dt, "ndongbhxh");
            object[] a_ndongbhtn = bang.Fobj_COL_MANG(b_dt, "ndongbhtn");
            object[] a_sobhyt = bang.Fobj_COL_MANG(b_dt, "sobhyt");
            object[] a_dk_kcb = bang.Fobj_COL_MANG(b_dt, "dk_kcb");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_trabhxh = bang.Fobj_COL_MANG(b_dt, "trabhxh");
            object[] a_ngay_trabhxh = bang.Fobj_COL_MANG(b_dt, "ngay_trabhxh");
            object[] a_trabhyt = bang.Fobj_COL_MANG(b_dt, "trabhyt");
            object[] a_ngay_trabhyt = bang.Fobj_COL_MANG(b_dt, "ngay_trabhyt");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'S', a_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhyt", 'S', a_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhtn", 'S', a_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_dcapso", 'S', a_dcapso);
            dbora.P_THEM_PAR(ref b_lenh, "a_sobhxh", 'S', a_sobhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bhxh", 'N', a_ngay_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_noicap", 'U', a_noicap);
            dbora.P_THEM_PAR(ref b_lenh, "a_ndongbhxh", 'N', a_ndongbhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ndongbhtn", 'N', a_ndongbhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_sobhyt", 'S', a_sobhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_dk_kcb", 'S', a_dk_kcb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_trabhxh", 'S', a_trabhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_trabhxh", 'N', a_ngay_trabhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_trabhyt", 'S', a_trabhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_trabhyt", 'N', a_ngay_trabhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_so_the,:a_ten,:a_bhxh,:a_bhyt,:a_bhtn,:a_dcapso,:a_sobhxh,:a_ngay_bhxh,:a_noicap,:a_ndongbhxh,:a_ndongbhtn";
            b_c = b_c + ",:a_sobhyt,:a_dk_kcb,:a_ngayd,:a_ngayc,:a_trabhxh,:a_ngay_trabhxh,:a_trabhyt,:a_ngay_trabhyt,:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_BHXH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion IMPORT THÔNG TIN BẢO HIỂM XÃ HỘI

    #region IMPORT CHỨC DANH CÔNG VIỆC
    // nhóm chức danh
    public static string KHUD_FILES_MA_NCDANH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_NCDANH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // chức danh

    public static string KHUD_FILES_MA_CDANH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ncdanh_ma");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt, "mota");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ct", 'S', a_ma_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);

            string b_c = ",:a_ma,:a_ten,:a_ma_ct,:a_mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_CDANH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT CHỨC DANH CÔNG VIỆC

    #region IMPORT MÃ BỆNH VIỆN
    public static string KHUD_FILES_MA_BV(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_dchi = bang.Fobj_COL_MANG(b_dt, "dchi");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt, "gchu");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_dchi", 'U', a_dchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            string b_c = ",:a_ma,:a_ten,:a_dchi,:a_gchu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_BV(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT MÃ BỆNH VIỆN

    #region IMPORT HỢP ĐỒNG
    public static string KHUD_FILES_MA_LHD(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_LHD(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string KHUD_FILES_HD(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc,ngay_tl");
            bang.P_CSO_SO(ref b_dt, "luongcb,tong_luong,thuong,pt_hluong");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_lhd_ma = bang.Fobj_COL_MANG(b_dt, "lhd_ma");
            object[] a_so_hd = bang.Fobj_COL_MANG(b_dt, "so_hd");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_tg_lv = bang.Fobj_COL_MANG(b_dt, "tg_lv");
            object[] a_ma_nguoiky = bang.Fobj_COL_MANG(b_dt, "ma_nguoiky");
            object[] a_cdanh_nguoiky = bang.Fobj_COL_MANG(b_dt, "cdanh_nguoiky");
            object[] a_ngay_ky = bang.Fobj_COL_MANG(b_dt, "ngay_ky");
            object[] a_ngay_tl = bang.Fobj_COL_MANG(b_dt, "ngay_tl");
            object[] a_cv_plam = bang.Fobj_COL_MANG(b_dt, "cv_plam");
            object[] a_hddau = bang.Fobj_COL_MANG(b_dt, "hddau");
            object[] a_ma_tl = bang.Fobj_COL_MANG(b_dt, "ma_tl");
            object[] a_ma_nl = bang.Fobj_COL_MANG(b_dt, "ma_nl");
            object[] a_ma_bl = bang.Fobj_COL_MANG(b_dt, "ma_bl");
            object[] a_luongcb = bang.Fobj_COL_MANG(b_dt, "luongcb");
            object[] a_tong_luong = bang.Fobj_COL_MANG(b_dt, "tong_luong");
            object[] a_thuong = bang.Fobj_COL_MANG(b_dt, "thuong");
            object[] a_pt_hluong = bang.Fobj_COL_MANG(b_dt, "pt_hluong");



            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lhd_ma", 'S', a_lhd_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_hd", 'S', a_so_hd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tg_lv", 'U', a_tg_lv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nguoiky", 'S', a_ma_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_nguoiky", 'U', a_cdanh_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ky", 'N', a_ngay_ky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_tl", 'N', a_ngay_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_cv_plam", 'U', a_cv_plam);
            dbora.P_THEM_PAR(ref b_lenh, "a_hddau", 'S', a_hddau);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tl", 'S', a_ma_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nl", 'S', a_ma_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_bl", 'S', a_ma_bl);
            dbora.P_THEM_PAR(ref b_lenh, "a_luongcb", 'N', a_luongcb);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_luong", 'N', a_tong_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuong", 'N', a_thuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_pt_hluong", 'N', a_pt_hluong);


            string b_c = ",:a_so_the,:a_lhd_ma,:a_so_hd,:a_ngayd,:a_ngayc,:a_tg_lv,:a_ma_nguoiky,:a_cdanh_nguoiky,:a_ngay_ky,:a_ngay_tl,:a_cv_plam";
            b_c = b_c + ",:a_hddau,:a_ma_tl,:a_ma_nl,:a_ma_bl,:a_luongcb,:a_tong_luong,:a_thuong,:a_pt_hluong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_HD(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string KHUD_FILES_TTT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            //bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc");
            //object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_cannang = bang.Fobj_COL_MANG(b_dt, "cannang");
            object[] a_chieucao = bang.Fobj_COL_MANG(b_dt, "chieucao");
            object[] a_congviec = bang.Fobj_COL_MANG(b_dt, "congviec");
            object[] a_dantoc = bang.Fobj_COL_MANG(b_dt, "dantoc");
            object[] a_dtcs = bang.Fobj_COL_MANG(b_dt, "dtcs");
            object[] a_hocham = bang.Fobj_COL_MANG(b_dt, "hocham");
            object[] a_honnhan = bang.Fobj_COL_MANG(b_dt, "honnhan");
            object[] a_msthue = bang.Fobj_COL_MANG(b_dt, "msthue");
            object[] a_ngaydang = bang.Fobj_COL_MANG(b_dt, "ngaydang");
            object[] a_ngaydangct = bang.Fobj_COL_MANG(b_dt, "ngaydangct");
            object[] a_nghenghiep = bang.Fobj_COL_MANG(b_dt, "nghenghiep");
            object[] a_nhommau = bang.Fobj_COL_MANG(b_dt, "nhommau");
            object[] a_noisinh = bang.Fobj_COL_MANG(b_dt, "noisinh");
            object[] a_tdcm = bang.Fobj_COL_MANG(b_dt, "tdcm");
            object[] a_tdhv = bang.Fobj_COL_MANG(b_dt, "tdhv");
            object[] a_tinhthanh = bang.Fobj_COL_MANG(b_dt, "tinhthanh");
            object[] a_tongiao = bang.Fobj_COL_MANG(b_dt, "tongiao");
            object[] a_ttsk = bang.Fobj_COL_MANG(b_dt, "ttsk");

            //dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_cannang", 'U', a_cannang);
            dbora.P_THEM_PAR(ref b_lenh, "a_chieucao", 'U', a_chieucao);
            dbora.P_THEM_PAR(ref b_lenh, "a_congviec", 'U', a_congviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_dantoc", 'U', a_dantoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_dtcs", 'U', a_dtcs);
            dbora.P_THEM_PAR(ref b_lenh, "a_hocham", 'U', a_hocham);
            dbora.P_THEM_PAR(ref b_lenh, "a_honnhan", 'U', a_honnhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_msthue", 'U', a_msthue);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaydang", 'U', a_ngaydang);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaydangct", 'U', a_ngaydangct);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghenghiep", 'U', a_nghenghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhommau", 'U', a_nhommau);
            dbora.P_THEM_PAR(ref b_lenh, "a_noisinh", 'U', a_noisinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tdcm", 'U', a_tdcm);
            dbora.P_THEM_PAR(ref b_lenh, "a_tdhv", 'U', a_tdhv);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhthanh", 'U', a_tinhthanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongiao", 'U', a_tongiao);
            dbora.P_THEM_PAR(ref b_lenh, "a_ttsk", 'U', a_ttsk);

            string b_c = ",:a_so_the,:a_cannang,:a_chieucao,:a_congviec,:a_dantoc,:a_dtcs,:a_hocham,:a_honnhan,:a_msthue,:a_ngaydang,:a_ngaydangct";
            b_c = b_c + ",:a_nghenghiep,:a_nhommau,:a_noisinh,:a_tdcm,:a_tdhv,:a_tinhthanh,:a_tongiao,:a_ttsk";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_TTT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); };
    }


    public static string KHUD_FILES_HD_UPDATE_LUONG(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_THAY_GTRI(ref b_dt, "tien", null, "0");
            bang.P_THAY_GTRI(ref b_dt, "tienbh", null, "0");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt, "tien");
            object[] a_tienbh = bang.Fobj_COL_MANG(b_dt, "tienbh");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien", 'N', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "a_tienbh", 'N', a_tienbh);

            string b_c = ",:a_so_the,:a_tien,:a_tienbh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_HD_UPDATE_LUONG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT HỢP ĐỒNG

    #region IMPORT TRANG THIẾT BỊ
    public static string KHUD_FILES_TTB(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngaycap");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ngaycap = bang.Fobj_COL_MANG(b_dt, "ngaycap");
            object[] a_tentb = bang.Fobj_COL_MANG(b_dt, "tentb");
            object[] a_kichthuoc = bang.Fobj_COL_MANG(b_dt, "kichthuoc");
            object[] a_sluong = bang.Fobj_COL_MANG(b_dt, "sluong");
            object[] a_ht = bang.Fobj_COL_MANG(b_dt, "ht");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt, "tien");
            object[] a_note = bang.Fobj_COL_MANG(b_dt, "note");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycap", 'N', a_ngaycap);
            dbora.P_THEM_PAR(ref b_lenh, "a_tentb", 'U', a_tentb);
            dbora.P_THEM_PAR(ref b_lenh, "a_kichthuoc", 'U', a_kichthuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_sluong", 'N', a_sluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ht", 'S', a_ht);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien", 'N', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);


            string b_c = ",:a_so_id,:a_so_the,:a_ngaycap,:a_tentb,:a_kichthuoc,:a_sluong,:a_ht,:a_tien,:a_note";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_TTB(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion : TRANG THIẾT BỊ

    #region IMPORT KHEN THƯỞNG - KỶ LUẬT
    public static string KHUD_FILES_KT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);

            bang.P_CNG_SO(ref b_dt, "ngayqd");
            bang.P_CSO_SO(ref b_dt, "mucthuong");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt, "lydo");
            object[] a_mucthuong = bang.Fobj_COL_MANG(b_dt, "mucthuong");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");
            object[] a_soqd = bang.Fobj_COL_MANG(b_dt, "soqd");
            object[] a_ngayqd = bang.Fobj_COL_MANG(b_dt, "ngayqd");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt, "hinhthuc_ma");
            object[] a_cap_ktkl = bang.Fobj_COL_MANG(b_dt, "cap_ktkl_ma");
            object[] a_noi_ktkl = bang.Fobj_COL_MANG(b_dt, "noi_ktkl_ma");
            object[] a_nguoiky = bang.Fobj_COL_MANG(b_dt, "nguoiky");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_soqd", 'S', a_soqd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayqd", 'N', a_ngayqd);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc", 'S', a_hinhthuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucthuong", 'N', a_mucthuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "a_cap_ktkl", 'S', a_cap_ktkl);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_ktkl", 'S', a_noi_ktkl);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoiky", 'U', a_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_so_the,:a_soqd,:a_ngayqd,:a_hinhthuc,:a_mucthuong,:a_lydo,:a_cap_ktkl,:a_noi_ktkl,:a_nguoiky,:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_KT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string KHUD_FILES_KL(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);

            bang.P_CNG_SO(ref b_dt, "ngayqd,ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt, "mucphat");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_soqd = bang.Fobj_COL_MANG(b_dt, "soqd");
            object[] a_ngayqd = bang.Fobj_COL_MANG(b_dt, "ngayqd");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt, "hinhthuc_ma");
            object[] a_mucphat = bang.Fobj_COL_MANG(b_dt, "mucphat");
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt, "lydo");
            object[] a_cap_ktkl = bang.Fobj_COL_MANG(b_dt, "cap_ktkl_ma");
            object[] a_noi_ktkl = bang.Fobj_COL_MANG(b_dt, "noi_ktkl_ma");
            object[] a_nguoiky = bang.Fobj_COL_MANG(b_dt, "nguoiky");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_soqd", 'S', a_soqd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayqd", 'N', a_ngayqd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc", 'S', a_hinhthuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucphat", 'N', a_mucphat);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "a_cap_ktkl", 'S', a_cap_ktkl);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_ktkl", 'S', a_noi_ktkl);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoiky", 'U', a_nguoiky);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_so_the,:a_soqd,:a_ngayqd,:a_ngayd,:a_ngayc,:a_hinhthuc,:a_mucphat,:a_lydo,:a_cap_ktkl,:a_noi_ktkl,:a_nguoiky,:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_KL(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT KHEN THƯỞNG - KỶ LUẬT

    #region IMPORT QUÁ TRÌNH ĐÀO TẠO
    // cấp đào tạo
    public static string KHUD_FILES_MA_CAPDT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_CAPDT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // Ngành (nhóm chuyên ngành)
    public static string KHUD_FILES_MA_NCNGANH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_NCNGANH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // mã chuyên ngành

    public static string KHUD_FILES_MA_CNGANH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_nhom = bang.Fobj_COL_MANG(b_dt, "nhom");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_nhom", 'S', a_nhom);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_nhom,:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_CNGANH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // mã xếp loại
    public static string KHUD_FILES_MA_XLOAI(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_XLOAI(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string KHUD_FILES_MA_NHA(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_dchi = bang.Fobj_COL_MANG(b_dt, "dchi");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_dchi", 'U', a_dchi);

            string b_c = ",:a_ma,:a_ten,:a_dchi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_NHA(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // quá trình đào tọa
    public static string KHUD_FILES_DTHV(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {

            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CTH_SO(ref b_dt, "thangd,thangc"); bang.P_CNG_SO(ref b_dt, "ngaycap");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_capdt = bang.Fobj_COL_MANG(b_dt, "capdt");
            object[] a_nhom_cnganh = bang.Fobj_COL_MANG(b_dt, "nhom_cnganh");
            object[] a_cnganh = bang.Fobj_COL_MANG(b_dt, "cnganh");
            object[] a_ten_cnganh = bang.Fobj_COL_MANG(b_dt, "ten_cnganh");
            object[] a_noidt = bang.Fobj_COL_MANG(b_dt, "noidt");
            object[] a_thangd = bang.Fobj_COL_MANG(b_dt, "thangd");
            object[] a_thangc = bang.Fobj_COL_MANG(b_dt, "thangc");
            object[] a_xeploai = bang.Fobj_COL_MANG(b_dt, "xeploai");
            object[] a_tinhtrang = bang.Fobj_COL_MANG(b_dt, "tinhtrang");
            object[] a_ngaycap = bang.Fobj_COL_MANG(b_dt, "ngaycap");
            object[] a_note = bang.Fobj_COL_MANG(b_dt, "note");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_capdt", 'S', a_capdt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cnganh", 'S', a_nhom_cnganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cnganh", 'S', a_cnganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cnganh", 'U', a_ten_cnganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidt", 'U', a_noidt);
            dbora.P_THEM_PAR(ref b_lenh, "a_thangd", 'N', a_thangd);
            dbora.P_THEM_PAR(ref b_lenh, "a_thangc", 'N', a_thangc);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai", 'S', a_xeploai);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang", 'S', a_tinhtrang);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycap", 'N', a_ngaycap);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:a_so_id,:a_so_the,:a_capdt,:a_nhom_cnganh,:a_cnganh,:a_ten_cnganh,:a_noidt,:a_thangd,:a_thangc,:a_xeploai,:a_tinhtrang,:a_ngaycap,:a_note";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_DTHV(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT QUÁ TRÌNH ĐÀO TẠO

    #region IMPORT CHỈ TIÊU TÌM KIẾM
    public static string KHUD_FILES_TK_MA_NHTK(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_TK_MA_NHTK(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static string KHUD_FILES_TK_MA_CHITIEU(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CH_BLANK(ref b_dt, "ma_ct");

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ma_ct");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt, "tt");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ct", 'S', a_ma_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);

            string b_c = ",:a_ma,:a_ten,:a_ma_ct,:a_tt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_CHITIEU(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static string KHUD_FILES_TK_MA_KQTK(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CH_BLANK(ref b_dt, "ma_ct");

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ma_ct");
            object[] a_tt = bang.Fobj_COL_MANG(b_dt, "tt");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ct", 'S', a_ma_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);

            string b_c = ",:a_ma,:a_ten,:a_ma_ct,:a_tt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_KQTK(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion IMPORT CHỈ TIÊU TÌM KIẾM

    #region IMPORT MÃ DÂN TỘC
    public static string KHUD_FILES_MA_DT(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_DT(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region IMPORT MÃ DÂN TỘC
    public static string KHUD_FILES_MA_TG(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);

            string b_c = ",:a_ma,:a_ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_MA_TG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region IMPORT THU NHẬP PHỤ CẤP
    public static string KHUD_FILES_TN_PCAP(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "ma_goc", ""); bang.P_BO_HANG(ref b_dt, "ma_goc", null);

            bang.P_CNG_SO(ref b_dt, "ngay,ngay_qd,ngayd");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_ma_goc = bang.Fobj_COL_MANG(b_dt, "ma_goc");
            object[] a_ngay = bang.Fobj_COL_MANG(b_dt, "ngay");
            object[] a_ngay_qd = bang.Fobj_COL_MANG(b_dt, "ngay_qd");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_mapc = bang.Fobj_COL_MANG(b_dt, "mapc");
            object[] a_tenpc = bang.Fobj_COL_MANG(b_dt, "tenpc");
            object[] a_giatri = bang.Fobj_COL_MANG(b_dt, "giatri");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt, "hinhthuc");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_goc", 'S', a_ma_goc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay", 'N', a_ngay);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_qd", 'N', a_ngay_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_mapc", 'S', a_mapc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tenpc", 'U', a_tenpc);
            dbora.P_THEM_PAR(ref b_lenh, "a_giatri", 'N', a_giatri);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc", 'S', a_hinhthuc);

            string b_c = ",:a_so_id,:a_ma_goc,:a_ngay,:a_ngay_qd,:a_ngayd,:a_mapc,:a_tenpc,:a_giatri,:a_hinhthuc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_PCAP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region IMPORT THÔNG TIN THÊM
    //public static string KHUD_FILES_TTT(DataTable b_dt)
    //{
    //    se.se_nsd b_se = new se.se_nsd();
    //    OracleConnection b_cnn = dbora.Fcn_KNOI();
    //    try
    //    {
    //        OracleCommand b_lenh = new OracleCommand();
    //        b_lenh.Connection = b_cnn;

    //        object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
    //        object[] a_n1 = bang.Fobj_COL_MANG(b_dt, "n1");
    //        object[] a_n2 = bang.Fobj_COL_MANG(b_dt, "n2");
    //        object[] a_n3 = bang.Fobj_COL_MANG(b_dt, "n3");
    //        object[] a_n4 = bang.Fobj_COL_MANG(b_dt, "n4");
    //        object[] a_n5 = bang.Fobj_COL_MANG(b_dt, "n5");
    //        object[] a_n6 = bang.Fobj_COL_MANG(b_dt, "n6");
    //        object[] a_n7 = bang.Fobj_COL_MANG(b_dt, "n7");
    //        object[] a_n8 = bang.Fobj_COL_MANG(b_dt, "n8");

    //        dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'U', a_n1);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'U', a_n2);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'U', a_n3);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'U', a_n4);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'U', a_n5);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'U', a_n8);

    //        string b_c = ",:a_so_the,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8";
    //        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_TTT(" + b_se.tso + b_c + "); end;";
    //        try
    //        {
    //            b_lenh.ExecuteNonQuery();
    //            return "Nhập dữ liệu thành công!";
    //        }
    //        finally { b_lenh.Parameters.Clear(); }
    //    }
    //    finally { b_cnn.Close(); }
    //}

    #endregion : IMPORT THÔNG TIN THÊM

    #region IMPORT QUAN HỆ THÂN NHÂN
    public static string KHUD_FILES_QH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngay_giamtru");
            bang.P_CSO_SO(ref b_dt, "tuoi");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_gdinh = bang.Fobj_COL_MANG(b_dt, "gdinh_ma");
            object[] a_lqhe = bang.Fobj_COL_MANG(b_dt, "lqhe_ma");
            object[] a_sothe_tnhan = bang.Fobj_COL_MANG(b_dt, "sothe_tnhan");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_gt = bang.Fobj_COL_MANG(b_dt, "gt_ma");
            object[] a_tuoi = bang.Fobj_COL_MANG(b_dt, "tuoi");
            object[] a_n_ngh = bang.Fobj_COL_MANG(b_dt, "n_ngh");
            object[] a_ngay_gtru = bang.Fobj_COL_MANG(b_dt, "ngay_giamtru");
            object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt, "phuthuoc");
            object[] a_note = bang.Fobj_COL_MANG(b_dt, "note");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_gdinh", 'S', a_gdinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_lqhe", 'S', a_lqhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_tnhan", 'S', a_sothe_tnhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_gt", 'S', a_gt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuoi", 'N', a_tuoi);
            dbora.P_THEM_PAR(ref b_lenh, "a_n_ngh", 'U', a_n_ngh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_gtru", 'N', a_ngay_gtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'S', a_phuthuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:a_so_the,:a_gdinh,:a_lqhe,:a_sothe_tnhan,:a_ten,:a_gt,:a_tuoi,:a_n_ngh,:a_ngay_gtru,:a_phuthuoc,:a_note";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_QH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT QUAN HỆ THÂN NHÂN

    #region IMPORT CHUYỂN PHÒNG
    public static string KHUD_FILES_CP(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null);
            bang.P_CNG_SO(ref b_dt, "ngay_qd,ngayd,ngaybd,ngaykt");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_so_qd = bang.Fobj_COL_MANG(b_dt, "so_qd");
            object[] a_ngay_qd = bang.Fobj_COL_MANG(b_dt, "ngay_qd");
            object[] a_ngaybd = bang.Fobj_COL_MANG(b_dt, "ngaybd");
            object[] a_ngaykt = bang.Fobj_COL_MANG(b_dt, "ngaykt");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_cvu = bang.Fobj_COL_MANG(b_dt, "cvu");
            object[] a_hspc = bang.Fobj_COL_MANG(b_dt, "hspc");
            object[] a_lng = bang.Fobj_COL_MANG(b_dt, "lng");
            object[] a_ngach = bang.Fobj_COL_MANG(b_dt, "ngach");
            object[] a_bac = bang.Fobj_COL_MANG(b_dt, "bac");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt, "hso");
            object[] a_ncd = bang.Fobj_COL_MANG(b_dt, "ncd");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_bcd = bang.Fobj_COL_MANG(b_dt, "bcd");
            object[] a_hscd = bang.Fobj_COL_MANG(b_dt, "hscd");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt, "tien");
            object[] a_tienbh = bang.Fobj_COL_MANG(b_dt, "tienbh");
            object[] a_phongc = bang.Fobj_COL_MANG(b_dt, "phongc");
            object[] a_cvuc = bang.Fobj_COL_MANG(b_dt, "cvuc");
            object[] a_hspcc = bang.Fobj_COL_MANG(b_dt, "hspcc");
            object[] a_lngc = bang.Fobj_COL_MANG(b_dt, "lngc");
            object[] a_ngachc = bang.Fobj_COL_MANG(b_dt, "ngachc");
            object[] a_bacc = bang.Fobj_COL_MANG(b_dt, "bacc");
            object[] a_hsoc = bang.Fobj_COL_MANG(b_dt, "hsoc");
            object[] a_ncdc = bang.Fobj_COL_MANG(b_dt, "ncdc");
            object[] a_cdanhc = bang.Fobj_COL_MANG(b_dt, "cdanhc");
            object[] a_bcdc = bang.Fobj_COL_MANG(b_dt, "bcdc");
            object[] a_hscdc = bang.Fobj_COL_MANG(b_dt, "hscdc");
            object[] a_tienc = bang.Fobj_COL_MANG(b_dt, "tienc");
            object[] a_tienbhc = bang.Fobj_COL_MANG(b_dt, "tienbhc");
            object[] a_note = bang.Fobj_COL_MANG(b_dt, "note");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_qd", 'S', a_so_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_qd", 'N', a_ngay_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaybd", 'N', a_ngaybd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaykt", 'N', a_ngaykt);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cvu", 'S', a_cvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_hspc", 'N', a_hspc);
            dbora.P_THEM_PAR(ref b_lenh, "a_lng", 'S', a_lng);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngach", 'S', a_ngach);
            dbora.P_THEM_PAR(ref b_lenh, "a_bac", 'S', a_bac);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso", 'N', a_hso);
            dbora.P_THEM_PAR(ref b_lenh, "a_ncd", 'S', a_ncd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bcd", 'S', a_bcd);
            dbora.P_THEM_PAR(ref b_lenh, "a_hscd", 'N', a_hscd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien", 'N', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "a_tienbh", 'N', a_tienbh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phongc", 'S', a_phongc);
            dbora.P_THEM_PAR(ref b_lenh, "a_cvuc", 'S', a_cvuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hspcc", 'N', a_hspcc);
            dbora.P_THEM_PAR(ref b_lenh, "a_lngc", 'S', a_lngc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngachc", 'S', a_ngachc);
            dbora.P_THEM_PAR(ref b_lenh, "a_bacc", 'S', a_bacc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hsoc", 'N', a_hsoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ncdc", 'S', a_ncdc);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanhc", 'S', a_cdanhc);
            dbora.P_THEM_PAR(ref b_lenh, "a_bcdc", 'S', a_bcdc);
            dbora.P_THEM_PAR(ref b_lenh, "a_hscdc", 'N', a_hscdc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tienc", 'N', a_tienc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tienbhc", 'N', a_tienbhc);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:a_so_id,:a_so_the,:a_ngayd,:a_so_qd,:a_ngay_qd,:a_ngaybd,:a_ngaykt,:a_phong,:a_cvu,:a_hspc,:a_lng,:a_ngach,:a_bac,:a_hso,:a_ncd,:a_cdanh,:a_bcd,:a_hscd,:a_tien,:a_tienbh";
            b_c = b_c + ",:a_phongc,:a_cvuc,:a_hspcc,:a_lngc,:a_ngachc,:a_bacc,:a_hsoc,:a_ncdc,:a_cdanhc,:a_bcdc,:a_hscdc,:a_tienc,:a_tienbhc,:a_note";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_CP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT CHUYỂN PHÒNG

    #region IMPORT THÔNG TIN NGHỈ
    public static string KHUD_FILES_TT_NGHI(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_BO_HANG(ref b_dt, "ngayd", ""); bang.P_BO_HANG(ref b_dt, "ngayd", null); bang.P_BO_HANG(ref b_dt, "ngayd", " ");
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_sothe_thaythe = bang.Fobj_COL_MANG(b_dt, "sothe_thaythe");
            object[] a_macc_nghi = bang.Fobj_COL_MANG(b_dt, "macc_nghi");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_ngaynghi = bang.Fobj_COL_MANG(b_dt, "ngaynghi");
            object[] a_truphepnam = bang.Fobj_COL_MANG(b_dt, "truphepnam");
            object[] a_truphep = bang.Fobj_COL_MANG(b_dt, "truphep");
            object[] a_namtru = bang.Fobj_COL_MANG(b_dt, "namtru");
            object[] a_nghibu = bang.Fobj_COL_MANG(b_dt, "nghibu");
            object[] a_ngaybu = bang.Fobj_COL_MANG(b_dt, "ngaybu");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt, "noidung");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_thaythe", 'S', a_sothe_thaythe);
            dbora.P_THEM_PAR(ref b_lenh, "a_macc_nghi", 'S', a_macc_nghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaynghi", 'N', a_ngaynghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_truphepnam", 'S', a_truphepnam);
            dbora.P_THEM_PAR(ref b_lenh, "a_truphep", 'N', a_truphep);
            dbora.P_THEM_PAR(ref b_lenh, "a_namtru", 'S', a_namtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghibu", 'S', a_nghibu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaybu", 'N', a_ngaybu);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);

            string b_c = ",:a_so_the,:a_sothe_thaythe,:a_macc_nghi,:a_ngayd,:a_ngayc,:a_ngaynghi,:a_truphepnam,:a_truphep,:a_namtru,:a_nghibu,:a_ngaybu,:a_noidung";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_THONGTIN_NGHI(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT THÔNG TIN NGHỈ

    #region IMPORT THÔI VIỆC
    public static string KHUD_FILES_TV(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt, "ngaytt,ngay_qd,ngaynghi,ngaynop");

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_ngaynop = bang.Fobj_COL_MANG(b_dt, "ngaynop");
            object[] a_ngaynghi = bang.Fobj_COL_MANG(b_dt, "ngaynghi");
            object[] a_tinhtrang = bang.Fobj_COL_MANG(b_dt, "tinhtrang");
            object[] a_so_qd = bang.Fobj_COL_MANG(b_dt, "so_qd");
            object[] a_ngay_qd = bang.Fobj_COL_MANG(b_dt, "ngay_qd");
            object[] a_ht = bang.Fobj_COL_MANG(b_dt, "ht");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngaytt");
            object[] a_nguoiduyet = bang.Fobj_COL_MANG(b_dt, "nguoiduyet");
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt, "lydo");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaynop", 'N', a_ngaynop);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaynghi", 'N', a_ngaynghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang", 'S', a_tinhtrang);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_qd", 'S', a_so_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_qd", 'N', a_ngay_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ht", 'S', a_ht);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoiduyet", 'U', a_nguoiduyet);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);

            string b_c = ",:a_so_id,:a_so_the,:a_ten,:a_phong,:a_ngaynop,:a_ngaynghi,:a_tinhtrang,:a_so_qd,:a_ngay_qd,:a_ht,:a_ngayd,:a_nguoiduyet,:a_lydo";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KHUD_FILES_TV(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "Nhập dữ liệu thành công!";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion IMPORT THÔI VIỆC
}