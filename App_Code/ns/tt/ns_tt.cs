using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_tt
{
    #region THÔNG BÁO TRÊN TRANG MENU
    public static DataTable Fdt_MENU_TBAO()
    {
        return dbora.Fdt_LKE("PNS_TBAO_MENU");
    }

    public static DataTable Fdt_BC_NHAP_REALTIME()
    {
        return dbora.Fdt_LKE("pns_bc_nhap_realtime");
    }

    public static DataTable Fdt_BC_DVI_REALTIME()
    {
        return dbora.Fdt_LKE("pns_bc_dvi_realtime");
    }

    public static DataSet Fdt_BC_7NGAY()
    {
        return dbora.Fds_LKE(2, "pns_bc_7ngay");
    }

    public static DataSet Fdt_MENU_TBAO_CT(string b_loai, int b_ngay)
    {
        return dbora.Fds_LKE(new object[] { b_loai, b_ngay }, 8, "PNS_TBAO_MENU_CT");
    }
    public static object[] Fdt_MENU_TBAO_CT2(string b_loai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_loai, b_tu, b_den }, "NR", "PNS_TBAO_MENU_CT2");
    }
    public static object[] Fdt_MENU_TBAO_CT_CCHN(string b_ma, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu, b_den }, "NR", "PNS_TBAO_MENU_CT_CCHN");
    }
    public static object[] Fdt_MENU_TBAO_CT_CON(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "pns_tbao_menu_ct_con");
    }
    public static DataSet Fdt_MENU_TBAO_CT_CCHN_EXCEL()
    {
        return dbora.Fds_LKE(1, "PNS_TBAO_MENU_CT_CCHN_EXCEL");
    }
    public static DataSet Fdt_MENU_TBAO_CT_CON_EXCEL()
    {
        return dbora.Fds_LKE(1, "PNS_TBAO_MENU_CT_CON_EXCEL");
    }
    public static DataTable Fdt_MENU_TBAO_TB(string b_loai, int b_ngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loai, b_ngay }, "PNS_TBAO_MENU_TB");
    }
    #endregion THÔNG BÁO TRÊN TRANG MENU

    #region CÁC HÀM CHUNG
    public static string Fs_HOI_SO_ID(string b_so_the)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(b_so_the, 'S', "PNS_HOI_SO_ID"));
    }
    ///<summary>Chuyển tháng kiểu số sang kiểu chữ</summary>
    public static void P_SO_CTH(ref DataTable b_dt, string b_cot)
    {
        string b_cot_moi = b_cot + "_sss";
        bang.P_DOI_TENCOL(ref b_dt, b_cot, b_cot_moi);
        bang.P_THEM_COL(ref b_dt, b_cot, "");
        foreach (DataRow b_dr in b_dt.Rows)
            b_dr[b_cot] = chuyen.SO_CTH((int)chuyen.OBJ_N(b_dr[b_cot_moi]));
        bang.P_BO_COT(ref b_dt, b_cot_moi); b_dt.AcceptChanges();
    }
    public static void P_KTRA_KIEU_THANG(string b_thang)
    {
        string b_loi_kieu = "loi:Sai kiểu tháng:loi";
        if (chuyen.CTH_SO(b_thang) == 300001)
            throw new Exception(b_loi_kieu);
    }
    public static void P_KTRA_GTRI_THANG(string b_thang)
    {
        string b_loi_gtri = "loi:Nhập tháng trong khoảng từ 1-12:loi";
        if ((Int32.Parse(b_thang.Substring(0, 2)) < 1) || (Int32.Parse(b_thang.Substring(0, 2)) > 12))
            throw new Exception(b_loi_gtri);
    }
    #endregion

    #region Chon CBNV
    public static object[] Fdt_NS_CB_CHON_LKE(string b_phong, string b_lke, string b_so_the, string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_lke, b_so_the, "N'" + b_ten, b_tu, b_den }, "NR", "PNS_CB_CHON_LKE");
    }
    public static DataSet Fdt_NS_CB_CHON_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 2, "PNS_CB_CHON_CT");
    }
    #endregion

    #region THÔNG TIN GỐC CỦA CÁN BỘ
    // lấy số thẻ khi có mã người dùng
    public static DataTable Fdt_NSD_SOTHE(string b_nsd)
    {
        return dbora.Fdt_LKE_S(b_nsd, "pns_nsd_sothe");
    }
    public static DataTable Fdt_MAYCHAMCONG()
    {
        return dbora.Fdt_LKE("pcc_maychamcong");
    }

    public static string Fdt_NS_CB_KTRA(string b_so_the, string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_so_the, b_phong }, "PNS_CB_KTRA");
        return b_dt.Rows[0][0].ToString();
    }
    public static DataTable Fdt_MA_PHONG_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE2");
    }
    public static object[] Fdt_MA_CCTC_LKE(string b_gt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_gt, b_tu, b_den }, "NR", "PHT_MA_CCTC_LKE2");
    }
    public static object[] Fdt_MA_CCTC_MA(string b_ma, string b_gt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_gt, b_trangkt }, "NNR", "PHT_MA_CCTC_MA");
    }
    public static DataTable Fdt_MA_PHONG_LKE4()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE4");
    }

    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_CB_LKE(string b_phong, string b_lke, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_lke, b_tu, b_den }, "NR", "PNS_CB_LKE");
    }


    public static object[] Fdt_NS_CB_QLY_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_CB_QLY_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>



    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static DataTable Fdt_NS_CB_TIM(string b_ten_hoa)
    {
        string b_dk = "ten_hoa like %" + kytu.C_NVL(b_ten_hoa) + "%";
        return dbora.Fdt_LKE_S(b_dk, "PNS_CB_TIM");
    }
    /// <summary>Thuc hien nhap cho can bo</summary>
    public static void P_NS_CB_NH2(string b_so_id, string b_ps, string b_nv, DataTable b_dt, DataTable b_dt_ttt, string b_lke)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        OracleCommand b_lenh = b_cnn.CreateCommand();
        DataRow b_dr = b_dt.Rows[0];

        string b_tt = chuyen.OBJ_S(b_dr["tt"]);
        if (b_tt == "") { b_tt = "0"; }
        dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
        dbora.P_THEM_PAR(ref b_lenh, "lke", 'S', 'O', chuyen.OBJ_S(b_lke));
        dbora.P_THEM_PAR(ref b_lenh, "b_ps", 'S', 'O', chuyen.OBJ_S(b_ps));
        dbora.P_THEM_PAR(ref b_lenh, "b_nv", 'S', 'O', chuyen.OBJ_S(b_nv));

        string c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["nn"]);
        c = c + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ten_hoa"]) + "," + chuyen.OBJ_S(b_dr["nsinh"]);
        c = c + "," + chuyen.OBJ_C(b_dr["gtinh"]) + "," + chuyen.OBJ_C(b_dr["dchi"]) + "," + chuyen.OBJ_C(b_dr["hkhau"]);
        c = c + "," + chuyen.OBJ_C(b_dr["dtnr"]) + "," + chuyen.OBJ_C(b_dr["dtdd"]) + "," + chuyen.OBJ_C(b_dr["sotk"]);
        c = c + "," + chuyen.OBJ_C(b_dr["nha_dchi"]) + "," + chuyen.OBJ_C(b_dr["nhan"]);
        c = c + "," + b_tt + "," + chuyen.OBJ_C(b_dr["nhom"]) + "," + chuyen.OBJ_C(b_dr["mast"]);
        c = c + "," + chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["socmt"]) + "," + chuyen.OBJ_S(b_dr["ngay_cmt"]);
        c = c + "," + chuyen.OBJ_C(b_dr["nc_cmt"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]);
        c = c + "," + chuyen.OBJ_C(b_dr["nhom_cd"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["bac_cdanh"]);
        c = c + "," + chuyen.OBJ_C(b_dr["dantoc"]) + "," + chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["tt_honnhan"]) + "," + chuyen.OBJ_C(b_dr["quanly_tt"]);
        c = c + "," + chuyen.OBJ_C(b_dr["nha"]) + "," + chuyen.OBJ_C(b_dr["khican_ll"]);
        //+",:b_ps,:b_nv,:a_so_id,:a_ma,:a_nd";

        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_NH(" + b_se.tso + c + "); end;";
        try
        {
            b_lenh.ExecuteNonQuery();
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        finally { b_cnn.Close(); b_cnn.Dispose(); }
    }



    public static object[] Fdt_NS_CB_TIMKIEM(DataTable b_dt, string b_lke, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_S(b_dr["phong_tk"]), chuyen.OBJ_S(b_dr["so_the_tk"]), chuyen.OBJ_C(b_dr["ten_tk"]), b_lke, b_tu, b_den }, "NR", "PNS_CB_TIMKIEM");
    }
    ///// <summary>Thuc hien chuyen hang doi so the</summary>
    //public static DataTable Fdt_NS_CST_CT(string b_so_the_c)
    //{
    //    return dbora.Fdt_LKE_S(b_so_the_c, "PNS_CST_CT");
    //}
    ///// <summary>Thuc hien do so the</summary>
    //public static void P_NS_CST_NH(string b_so_id, DataTable b_dt)
    //{
    //    DataRow b_dr = b_dt.Rows[0];
    //    dbora.P_GOIHAM(new object[] { b_so_id, b_dr["so_the_c"], b_dr["so_the"], b_dr["ngayd"] }, "PNS_CST_NH");
    //}
    ///// <summary>Thuc hien xoa doi so the</summary>
    //public static void P_NS_CST_XOA(string b_so_id)
    //{

    //}
    #endregion

    #region QUAN HỆ NHÂN THÂN
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_QHE_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_QH_LKE");
    }
    public static DataTable Fdt_NS_QHE_EXP(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "PNS_QH_EXP");
    }
    public static object[] Fdt_NS_QHE_TT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_QH_TT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_QHE_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_QH_MA");
    }
    public static object[] Fdt_NS_QHE_TT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_QH_TT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_QHE_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_QH_CT");
    }
    public static DataTable PNS_QHE_TT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_QH_TT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_QHE_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["lqhe"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ngaysinh"]) + "," + chuyen.OBJ_C(b_dr["n_ngh"]) + "," + chuyen.OBJ_C(b_dr["dchi"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["phuthuoc"]) + "," + chuyen.OBJ_C(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so"]) + "," + chuyen.OBJ_C(b_dr["quyenso"]) + "," + chuyen.OBJ_C(b_dr["so_cmt"]) + "," + chuyen.OBJ_C(b_dr["ngay_cmt"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["nn"]) + "," + chuyen.OBJ_C(b_dr["tinhthanh"]) + "," + chuyen.OBJ_C(b_dr["quanhuyen"]) + "," + chuyen.OBJ_C(b_dr["phuongxa"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["maso_thue"]) + "," + chuyen.OBJ_C(b_dr["noi_ctac"]) + "," + chuyen.OBJ_C(b_dr["sdt"]) + "," + chuyen.OBJ_C(b_dr["diachi_thuongchu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string PNS_QHE_TT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["lqhe"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ngaysinh"]) + "," + chuyen.OBJ_C(b_dr["n_ngh"]) + "," + chuyen.OBJ_C(b_dr["dchi"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["phuthuoc"]) + "," + chuyen.OBJ_C(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so"]) + "," + chuyen.OBJ_C(b_dr["quyenso"]) + "," + chuyen.OBJ_C(b_dr["so_cmt"]) + "," + chuyen.OBJ_C(b_dr["ngay_cmt"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["nn"]) + "," + chuyen.OBJ_C(b_dr["tinhthanh"]) + "," + chuyen.OBJ_C(b_dr["quanhuyen"]) + "," + chuyen.OBJ_C(b_dr["phuongxa"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["maso_thue"]) + "," + chuyen.OBJ_C(b_dr["noi_ctac"]) + "," + chuyen.OBJ_C(b_dr["sdt"]) + "," + chuyen.OBJ_C(b_dr["diachi_thuongchu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QH_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thôn tin</summary>
    public static void PNS_QHE_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_QH_XOA");
    }
    public static void PNS_QHE_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "pns_qh_tt_xoa");
    }
    public static void PNS_QHE_TT_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "pns_qh_tt_gui");
    }
    public static object[] PNS_QHE_CHECK_NHANTHAN(string b_so_id, string b_tenNhanthan, string b_ngaysinh)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_so_id), "N'" + b_tenNhanthan + "'", chuyen.OBJ_N(b_ngaysinh)}, "N", "PNS_QH_CHECK_NHANTHAN");
    }
    #endregion QUAN HỆ NHÂN THÂN

    #region QUÁ TRÌNH HOẠT ĐỘNG VÀ CÔNG TÁC
    /// <summary>Liệt kê</summary>
    public static DataTable PNS_CT_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_HDCT_LKE");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable PNS_CT_CT(string b_so_the, string b_thang)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CTH_CSO(b_thang) }, "PNS_HDCT_CT");
        return b_dt;
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_CT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];

        string b_thangd = chuyen.OBJ_S(b_dr["thangd"]);
        string b_thangc = chuyen.OBJ_S(b_dr["thangc"]);

        P_KTRA_KIEU_THANG(b_thangd); P_KTRA_KIEU_THANG(b_thangc);
        P_KTRA_GTRI_THANG(b_thangd); P_KTRA_GTRI_THANG(b_thangc);

        object[] a_obj = new object[] { b_dr["so_the"], chuyen.CTH_CSO(b_thangd), chuyen.CTH_CSO(b_thangc), b_dr["lgi"], b_dr["cvu"], b_dr["dvi"] };
        dbora.P_GOIHAM(a_obj, "PNS_HDCT_NH");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_CT_XOA(string b_so_the, string b_thangd)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_HDCT_XOA");
    }
    #endregion QUÁ TRÌNH HOẠT ĐỘNG VÀ CÔNG TÁC

    #region ĐÀO TẠO CHUYÊN MÔN NGHIỆP VỤ
    /// <summary>Liệt kê</summary>
    public static DataTable PNS_CMNV_LKE(string b_so_the)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_so_the, "PNS_CMNV_LKE");
        return b_dt;
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_CMNV_CT(string b_so_id)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_CMNV_CT");
        return b_dt;
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_CMNV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_thangd = chuyen.OBJ_S(b_dr["thangd"]);
            string b_thangc = chuyen.OBJ_S(b_dr["thangc"]);

            P_KTRA_KIEU_THANG(b_thangd); P_KTRA_KIEU_THANG(b_thangc);
            P_KTRA_GTRI_THANG(b_thangd); P_KTRA_GTRI_THANG(b_thangc);

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ht"]) + "," + chuyen.OBJ_C(b_dr["vb"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["truong"]) + "," + chuyen.OBJ_C(b_dr["cnganh"]);
            b_c = b_c + "," + chuyen.CTH_CSO(b_thangd) + "," + chuyen.CTH_CSO(b_thangc);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CMNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_CMNV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CMNV_XOA");
    }
    #endregion ĐÀO TẠO CHUYÊN MÔN NGHIỆP VỤ

    #region TÚI HỒ SƠ
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    ///  /// <summary>Liệt kê mã ths</summary>
    public static DataTable Fdt_NS_THS_LKEMA()
    {
        return dbora.Fdt_LKE("PNS_THS_LKEMA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_THS_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 3, "PNS_THS_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_THS_NH(DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_lke)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_chon = bang.Fobj_COL_MANG(b_dt_ct, "chon");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_batbuoc = bang.Fobj_COL_MANG(b_dt_ct, "batbuoc");
            object[] a_ngay_p = bang.Fobj_COL_MANG(b_dt_ct, "ngay_p");
            object[] a_ngay_n = bang.Fobj_COL_MANG(b_dt_ct, "ngay_n");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt_ct, "loai");
            object[] a_duong_dan = bang.Fobj_COL_MANG(b_dt_ct, "duong_dan");

            object[] a_hthanh = bang.Fobj_COL_MANG(b_dt_lke, "hthanh");
            object[] a_loai_bc = bang.Fobj_COL_MANG(b_dt_lke, "loai_bc");
            object[] a_ngay_pn = bang.Fobj_COL_MANG(b_dt_lke, "ngay_pn");
            object[] a_ngayn = bang.Fobj_COL_MANG(b_dt_lke, "ngayn");
            dbora.P_THEM_PAR(ref b_lenh, "a_chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_batbuoc", 'S', a_batbuoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_p", 'N', a_ngay_p);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_n", 'N', a_ngay_n);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_duong_dan", 'U', a_duong_dan);
            //
            dbora.P_THEM_PAR(ref b_lenh, "a_hthanh", 'S', a_hthanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_bc", 'U', a_loai_bc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_pn", 'N', a_ngay_pn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayn", 'N', a_ngay_n);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["noi_luu"]) + "," + chuyen.OBJ_C(b_dr["mota"]);
            b_c = b_c + ",:a_chon,:a_ma,:a_batbuoc,:a_ngay_p,:a_ngay_n,:a_loai,:a_duong_dan,:a_hthanh,:a_loai_bc,:a_ngay_pn,:a_ngayn";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_THS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_THS_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_THS_XOA");
    }
    #endregion TÚI HỒ SƠ

    #region ĐỔI SỐ THẺ
    public static DataTable PNS_CST_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CST_LKE");
    }
    public static void P_NS_CST_NH(string b_so_id, DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_so_id, b_dr["so_the_c"], b_dr["so_the"], b_dr["ngayd"] }, "PNS_CST_NH");
    }
    public static void PNS_CST_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CST_XOA");
    }
    #endregion ĐỔI SỐ THẺ

    #region SƠ YẾU LÝ LỊCH
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_SYLL_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_SYLL_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_SYLL_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_SYLL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_SYLL_NH(string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_gt = bang.Fobj_COL_MANG(b_dt, "gt");
            object[] a_nd = bang.Fobj_COL_MANG(b_dt, "nd");

            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "gt", 'S', a_gt);
            dbora.P_THEM_PAR(ref b_lenh, "nd", 'U', a_nd);

            string b_c = "," + chuyen.OBJ_C(b_so_id) + ",:ma,:gt,:nd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_SYLL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_SYLL_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_SYLL_XOA");
    }
    #endregion SƠ YẾU LÝ LỊCH

    #region TRÌNH ĐỘ HỌC VẤN CAO NHẤT
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TDHV_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TDHV_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TDHV_CT(string b_so_the, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.OBJ_N(b_so_id) }, "PNS_TDHV_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TDHV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["gdpt"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["hh"]) + "," + chuyen.OBJ_C(b_dr["hv"]) + "," + chuyen.OBJ_C(b_dr["llct"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tdql"]) + "," + chuyen.OBJ_C(b_dr["tdth"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TDHV_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TDHV_XOA(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_TDHV_XOA");
    }
    #endregion TRÌNH ĐỘ HỌC VẤN CAO NHẤT

    #region QUÁ TRÌNH ĐÀO TẠO CHUYÊN MÔN
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DTHV_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_DTHV_LKE");
    }
    public static object[] Fdt_NS_DTHV_TT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_DTHV_TT_LKE");
    }
    public static DataTable Fdt_NS_DTHV_LKE_ALL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_DTHV_LKE_ALL");
    }
    public static DataTable Fdt_NS_DTHV_TT_LKE_ALL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_DTHV_TT_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DTHV_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_DTHV_MA");
    }
    public static object[] Fdt_NS_DTHV_TT_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_DTHV_TT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_DTHV_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_DTHV_CT");
    }
    public static DataTable PNS_DTHV_TT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_DTHV_TT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_DTHV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["thangd"]) + "," + chuyen.OBJ_N(b_dr["thangc"]) + "," + chuyen.OBJ_N(b_dr["nam_tn"])
                + "," + chuyen.OBJ_C(b_dr["ten_truong"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["cnganh"]) + "," + chuyen.OBJ_C(b_dr["xeploai"])
                + "," + chuyen.OBJ_C(b_dr["sohieu"]) + "," + chuyen.OBJ_N(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["capdt"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DTHV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string PNS_DTHV_TT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["thangd"]) + "," + chuyen.OBJ_N(b_dr["thangc"]) + "," + chuyen.OBJ_N(b_dr["nam_tn"])
                + "," + chuyen.OBJ_C(b_dr["ten_truong"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["cnganh"]) + "," + chuyen.OBJ_C(b_dr["xeploai"])
                + "," + chuyen.OBJ_C(b_dr["sohieu"]) + "," + chuyen.OBJ_N(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["capdt"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DTHV_TT_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_DTHV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DTHV_XOA");
    }
    public static void PNS_DTHV_TT_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_dthv_tt_gui");
    }
    public static void PNS_DTHV_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DTHV_TT_XOA");
    }
    #endregion QUÁ TRÌNH ĐÀO TẠO CHUYÊN MÔN

    #region QUÁ TRÌNH ĐÀO TẠO NGẮN HẠN
    /// <summary>Liet ke toàn bộ</summary>
    public static DataTable Fdt_NS_DT_NGHAN_EXP(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_DT_NGHAN_EXP");
    }
    public static object[] Fdt_NS_DT_NGHAN_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_DT_NGHAN_LKE");
    }
    public static object[] Fdt_NS_DT_NGHAN_TT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_DT_NGHAN_TT_LKE");
    }
    public static DataSet Fdt_NS_DT_NGHAN_LKE_ALL()
    {
        return dbora.Fds_LKE(3, "PNS_DT_NGHAN_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_NGHAN_MA(string b_so_the, double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_N(b_so_id), b_trangkt }, "NNR", "PNS_DT_NGHAN_MA");
    }
    public static object[] Fdt_NS_DT_NGHAN_TT_MA(string b_so_the, double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_N(b_so_id), b_trangkt }, "NNR", "PNS_DT_NGHAN_TT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_DT_NGHAN_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 3, "PNS_DT_NGHAN_CT");
    }
    public static DataTable Fdt_NS_DS_CCHN_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_S(b_so_id), "PNS_DS_CCHN_LKE");
    }
    public static DataTable Fdt_NS_DS_CCC_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_S(b_so_id), "PNS_DS_CCC_LKE");
    }
    public static DataSet Fdt_NS_DT_NGHAN_TT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 3, "PNS_DT_NGHAN_TT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_NGHAN_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_cchn, DataTable b_dt_ccc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];


            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] ma_cchn = bang.Fobj_COL_MANG(b_dt_cchn, "ma_cchn");
            object[] so_cchn = bang.Fobj_COL_MANG(b_dt_cchn, "so_cchn");
            object[] ngay_cap = bang.Fobj_COL_MANG(b_dt_cchn, "ngay_cap");
            object[] thang_cap = bang.Fobj_COL_MANG(b_dt_cchn, "thang_cap");
            object[] vung = bang.Fobj_COL_MANG(b_dt_cchn, "vung");
            object[] ubck = bang.Fobj_COL_MANG(b_dt_cchn, "ubck");
            object[] qtrr = bang.Fobj_COL_MANG(b_dt_cchn, "qtrr");

            dbora.P_THEM_PAR(ref b_lenh, "ma_cchn", 'S', ma_cchn);
            dbora.P_THEM_PAR(ref b_lenh, "so_cchn", 'S', so_cchn);
            dbora.P_THEM_PAR(ref b_lenh, "ngay_cap", 'N', ngay_cap);
            dbora.P_THEM_PAR(ref b_lenh, "thang_cap", 'N', thang_cap);
            dbora.P_THEM_PAR(ref b_lenh, "vung", 'S', vung);
            dbora.P_THEM_PAR(ref b_lenh, "ubck", 'S', ubck);
            dbora.P_THEM_PAR(ref b_lenh, "qtrr", 'S', qtrr);

            object[] ma_ccc = bang.Fobj_COL_MANG(b_dt_ccc, "ma_ccc");
            object[] ccc_ngay_hl = bang.Fobj_COL_MANG(b_dt_ccc, "ccc_ngay_hl");
            object[] ccc_ngayhet_hl = bang.Fobj_COL_MANG(b_dt_ccc, "ccc_ngayhet_hl");
            object[] cam_ket = bang.Fobj_COL_MANG(b_dt_ccc, "cam_ket");
            object[] tien_camket = bang.Fobj_COL_MANG(b_dt_ccc, "tien_camket");
            object[] thang_camket = bang.Fobj_COL_MANG(b_dt_ccc, "thang_camket");
            object[] mota = bang.Fobj_COL_MANG(b_dt_ccc, "mota");

            dbora.P_THEM_PAR(ref b_lenh, "ma_ccc", 'S', ma_ccc);
            dbora.P_THEM_PAR(ref b_lenh, "ccc_ngay_hl", 'N', ccc_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "ccc_ngayhet_hl", 'N', ccc_ngayhet_hl);
            dbora.P_THEM_PAR(ref b_lenh, "cam_ket", 'S', cam_ket);
            dbora.P_THEM_PAR(ref b_lenh, "tien_camket", 'N', tien_camket);
            dbora.P_THEM_PAR(ref b_lenh, "thang_camket", 'N', thang_camket);
            dbora.P_THEM_PAR(ref b_lenh, "mota", 'U', mota);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["loai_cc"]) + "," + chuyen.OBJ_C(b_dr["ten_cchi"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["sohieu"])
                        + "," + chuyen.OBJ_C(b_dr["cs_dtao"]) + "," + chuyen.OBJ_S(b_dr["tu_ngay"]) + "," + chuyen.OBJ_S(b_dr["den_ngay"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"])
                        + "," + chuyen.OBJ_S(b_dr["ngay_hhl"]);
            b_c = b_c + ",:so_id,:ma_cchn,:so_cchn,:ngay_cap,:thang_cap,:vung,:ubck,:qtrr,:ma_ccc,:ccc_ngay_hl,:ccc_ngayhet_hl,:cam_ket,:tien_camket,:thang_camket,:mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_NGHAN_NH(" + b_se.tso + b_c + "); end;";
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

    public static void P_NS_DT_NGHAN_TT_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_cchn, DataTable b_dt_ccc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            object[] ma_cchn = bang.Fobj_COL_MANG(b_dt_cchn, "ma_cchn");
            object[] so_cchn = bang.Fobj_COL_MANG(b_dt_cchn, "so_cchn");
            object[] ngay_cap = bang.Fobj_COL_MANG(b_dt_cchn, "ngay_cap");
            object[] thang_cap = bang.Fobj_COL_MANG(b_dt_cchn, "thang_cap");
            object[] vung = bang.Fobj_COL_MANG(b_dt_cchn, "vung");
            object[] ubck = bang.Fobj_COL_MANG(b_dt_cchn, "ubck");
            object[] qtrr = bang.Fobj_COL_MANG(b_dt_cchn, "qtrr");

            dbora.P_THEM_PAR(ref b_lenh, "ma_cchn", 'S', ma_cchn);
            dbora.P_THEM_PAR(ref b_lenh, "so_cchn", 'S', so_cchn);
            dbora.P_THEM_PAR(ref b_lenh, "ngay_cap", 'N', ngay_cap);
            dbora.P_THEM_PAR(ref b_lenh, "thang_cap", 'N', thang_cap);
            dbora.P_THEM_PAR(ref b_lenh, "vung", 'S', vung);
            dbora.P_THEM_PAR(ref b_lenh, "ubck", 'S', ubck);
            dbora.P_THEM_PAR(ref b_lenh, "qtrr", 'S', qtrr);

            object[] ma_ccc = bang.Fobj_COL_MANG(b_dt_ccc, "ma_ccc");
            object[] ccc_ngay_hl = bang.Fobj_COL_MANG(b_dt_ccc, "ccc_ngay_hl");
            object[] ccc_ngayhet_hl = bang.Fobj_COL_MANG(b_dt_ccc, "ccc_ngayhet_hl");
            object[] cam_ket = bang.Fobj_COL_MANG(b_dt_ccc, "cam_ket");
            object[] tien_camket = bang.Fobj_COL_MANG(b_dt_ccc, "tien_camket");
            object[] thang_camket = bang.Fobj_COL_MANG(b_dt_ccc, "thang_camket");
            object[] mota = bang.Fobj_COL_MANG(b_dt_ccc, "mota");

            dbora.P_THEM_PAR(ref b_lenh, "ma_ccc", 'S', ma_ccc);
            dbora.P_THEM_PAR(ref b_lenh, "ccc_ngay_hl", 'N', ccc_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "ccc_ngayhet_hl", 'N', ccc_ngayhet_hl);
            dbora.P_THEM_PAR(ref b_lenh, "cam_ket", 'S', cam_ket);
            dbora.P_THEM_PAR(ref b_lenh, "tien_camket", 'N', tien_camket);
            dbora.P_THEM_PAR(ref b_lenh, "thang_camket", 'N', thang_camket);
            dbora.P_THEM_PAR(ref b_lenh, "mota", 'U', mota);
             
            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["loai_cc"]) + "," + chuyen.OBJ_C(b_dr["ten_cchi"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["sohieu"])
                        + "," + chuyen.OBJ_C(b_dr["cs_dtao"]) + "," + chuyen.OBJ_S(b_dr["tu_ngay"]) + "," + chuyen.OBJ_S(b_dr["den_ngay"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"])
                        + "," + chuyen.OBJ_S(b_dr["ngay_hhl"]);
            b_c = b_c + ",:so_id,:ma_cchn,:so_cchn,:ngay_cap,:thang_cap,:vung,:ubck,:qtrr,:ma_ccc,:ccc_ngay_hl,:ccc_ngayhet_hl,:cam_ket,:tien_camket,:thang_camket,:mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_NGHAN_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_NGHAN_FILE_NH(DataTable b_dt)
    {
        string b_so_id = "";
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten_cchi"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["sohieu"]) + ","
                + chuyen.OBJ_C(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["ngayhethl"]) + "," + chuyen.OBJ_C(b_dr["noidt"]) + ","
                + chuyen.OBJ_C(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ngayc"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_NGHAN_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_DT_NGHAN_XOA(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_DT_NGHAN_XOA");
    }
    public static void P_NS_DT_NGHAN_TT_GUI(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_DT_NGHAN_TT_GUI");
    }
    public static void P_NS_DT_NGHAN_TT_XOA(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_DT_NGHAN_TT_XOA");
    }
    #endregion QUÁ TRÌNH ĐÀO TẠO NGẮN HẠN

    #region QUÁ TRÌNH PHONG HỌC HÀM
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_PHH_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_PHH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_PHH_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_PHH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_PHH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_PHH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_PHH_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["linhv"]) + "," + chuyen.OBJ_C(b_dr["nhom_cnganh"]) + "," + chuyen.OBJ_C(b_dr["cnganh"]) + ","
                 + chuyen.OBJ_C(b_dr["hocham"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["hoidong"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_PHH_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_PHH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_PHH_XOA");
    }
    #endregion QUÁ TRÌNH PHONG HỌC HÀM

    #region CÔNG ĐOÀN
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_TC_CD_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_Cd_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_CD_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_CD_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TC_CD_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_TC_CD_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TC_CD_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            DataTable a_dt_ct = b_dt_ct;
            bang.P_CNG_SO(ref a_dt_ct, new string[] { "ngayd", "ngayc" });

            object[] a_tt = bang.Fobj_COL_MANG(a_dt_ct, "tt");
            object[] a_cvu = bang.Fobj_COL_MANG(a_dt_ct, "cvu");
            object[] a_donvi = bang.Fobj_COL_MANG(a_dt_ct, "donvi");
            object[] a_ngayd = bang.Fobj_COL_MANG(a_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(a_dt_ct, "ngayc");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_cvu", 'U', a_cvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_cd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["noicap"]) + "," + chuyen.OBJ_S(b_dr["ngayvao"]) + ","
                + chuyen.OBJ_C(b_dr["noivao"]) + ",:a_tt" + ",:a_cvu" + ",:a_donvi" + ",:a_ngayd" + ",:a_ngayc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_CD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TC_CD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TC_CD_XOA");
    }
    #endregion CÔNG ĐOÀN

    #region ĐẢNG VIÊN

    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_TC_DANG_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_DANG_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_DANG_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_DANG_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TC_DANG_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_TC_DANG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TC_DANG_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            DataTable a_dt_ct = b_dt_ct;

            object[] a_tt = bang.Fobj_COL_MANG(a_dt_ct, "tt");
            object[] a_cvu = bang.Fobj_COL_MANG(a_dt_ct, "cvu");
            object[] a_donvi = bang.Fobj_COL_MANG(a_dt_ct, "donvi");
            object[] a_ngayd = bang.Fobj_COL_MANG(a_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(a_dt_ct, "ngayc");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_cvu", 'U', a_cvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["so_lld"]) + ","
                + chuyen.OBJ_C(b_dr["sothe_dang"]) + "," + chuyen.OBJ_S(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["noicap"]) + ","
                + chuyen.OBJ_S(b_dr["ngayvao"]) + "," + chuyen.OBJ_C(b_dr["noivao"]) + "," + chuyen.OBJ_S(b_dr["ngayct"]) + "," + chuyen.OBJ_C(b_dr["noict"]) + ","
                + chuyen.OBJ_C(b_dr["nguoi1"]) + "," + chuyen.OBJ_C(b_dr["cvu1"]) + "," + chuyen.OBJ_C(b_dr["nguoi2"]) + "," + chuyen.OBJ_C(b_dr["cvu2"]) + "," + chuyen.OBJ_C(b_dr["lan"])
                + ",:a_tt" + ",:a_cvu" + ",:a_donvi" + ",:a_ngayd" + ",:a_ngayc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_DANG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TC_DANG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TC_DANG_XOA");
    }
    #endregion ĐẢNG VIÊN

    #region ĐOÀN VIÊN
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_TC_DV_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_DV_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_DV_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_DV_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TC_DV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 2, "PNS_TC_DV_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TC_DV_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            DataTable a_dt_ct = b_dt_ct;

            object[] a_tt = bang.Fobj_COL_MANG(a_dt_ct, "tt");
            object[] a_cvu = bang.Fobj_COL_MANG(a_dt_ct, "cvu");
            object[] a_donvi = bang.Fobj_COL_MANG(a_dt_ct, "donvi");
            object[] a_ngayd = bang.Fobj_COL_MANG(a_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(a_dt_ct, "ngayc");
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_cvu", 'U', a_cvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_dv"]) + ","
                + chuyen.OBJ_S(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["noicap"]) + "," + chuyen.OBJ_S(b_dr["ngayvao"]) + ","
                + chuyen.OBJ_C(b_dr["noivao"]) + ",:a_tt" + ",:a_cvu" + ",:a_donvi" + ",:a_ngayd" + ",:a_ngayc";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_DV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TC_DV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TC_DV_XOA");
    }
    #endregion ĐOÀN VIÊN

    #region HỘI CỰU CHIẾN BINH
    /// <summary>Liệt kê toan bo</summary>
    public static object[] PNS_TC_CCB_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_CCB_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_CCB_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_CCB_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TC_CCB_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TC_CCB_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_TC_CCB_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_cb"]) + ","
                + chuyen.OBJ_S(b_dr["ngaycap"]) + "," + chuyen.OBJ_S(b_dr["ngayvao"]) + "," + chuyen.OBJ_C(b_dr["noivao"]) + "," + chuyen.OBJ_C(b_dr["cvu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_CCB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_TC_CCB_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TC_CCB_XOA");
    }
    #endregion HỘI CỰU CHIẾN BINH

    #region THAM GIA QUÂN ĐỘI
    /// <summary>Liệt kê toan bo</summary>
    public static object[] PNS_TC_QD_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_QD_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_QD_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_QD_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TC_QD_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TC_QD_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_TC_QD_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngaynhap"]) + ","
                + chuyen.OBJ_S(b_dr["ngayxuat"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["quanchung"]) + ","
                + chuyen.OBJ_C(b_dr["binhchung"]) + "," + chuyen.OBJ_C(b_dr["quanham"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_C(b_dr["chucvu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_QD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_TC_QD_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TC_QD_XOA");
    }
    #endregion THAM GIA QUÂN ĐỘI

    #region CÁC TỔ CHỨC KHÁC
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] PNS_TC_KH_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_TC_KH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_KH_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_TC_KH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TC_KH_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TC_KH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TC_KH_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["tentc"]) + ","
                + chuyen.OBJ_C(b_dr["sothe_tc"]) + "," + chuyen.OBJ_S(b_dr["ngaycap"]) + "," + chuyen.OBJ_S(b_dr["ngayvao"]) + ","
                + chuyen.OBJ_C(b_dr["noicap"]) + "," + chuyen.OBJ_C(b_dr["noivao"]) + "," + chuyen.OBJ_C(b_dr["chucvu"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_KH_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TC_KH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TC_KH_XOA");
    }
    #endregion CÁC TỔ CHỨC KHÁC

    #region HUY HIỆU ĐẢNG
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] PNS_TC_HHDANG_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_TC_HHDANG_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_HHDANG_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_TC_HHDANG_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TC_HHDANG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TC_HHDANG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TC_HHDANG_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["hhd"]) + ","
                + chuyen.OBJ_S(chuyen.OBJ_I(b_dr["nam"])) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_HHDANG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_TC_HHDANG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TC_HHDANG_XOA");
    }
    #endregion HUY HIỆU ĐẢNG

    #region KỶ LUẬT ĐẢNG
    /// <summary>Liệt kê chi tiet</summary>
    public static object[] PNS_TC_KLDANG_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_TC_KLDANG_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_KLDANG_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_TC_KLDANG_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TC_KLDANG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TC_KLDANG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TC_KLDANG_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + ","
                + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["nguyennhan"]) + ","
                + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_S(b_dr["ngayqd"]) + ","
                + chuyen.OBJ_C(b_dr["capqd"]) + "," + chuyen.OBJ_C(b_dr["coquan"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]) + ","
                + chuyen.OBJ_C(b_dr["cvu"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["tt"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_KLDANG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_TC_KLDANG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TC_KLDANG_XOA");
    }
    #endregion KỶ LUẬT ĐẢNG

    #region HOÀN CẢNH KINH TẾ GIA ĐÌNH
    public static object[] Fdt_NS_GD_HC_LKE(string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu_n, b_den_n }, "NR", "PNS_GD_HC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_GD_HC_MA(string b_so_the, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.CNG_CSO(b_ngay), b_trangkt }, "NNR", "PNS_GD_HC_MA");
    }
    // Chi tiet so lieu
    public static DataSet Fdt_NS_GD_HC_CT(string b_so_id)
    {
        return dbora.Fds_LKE(chuyen.OBJ_N(b_so_id), 2, "PNS_GD_HC_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_GD_HC_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_gtri = bang.Fobj_COL_MANG(b_dt_ct, "gtri");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_gtri", 'U', a_gtri);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ","
                + chuyen.OBJ_C(b_dr["thunhap_chinh"]) + "," + chuyen.OBJ_C(b_dr["thunhap_khac"]) + ","
                + chuyen.OBJ_S(b_dr["binhquan"]) + "," + chuyen.OBJ_C(b_dr["lnha_cap"]) + ","
                + chuyen.OBJ_S(b_dr["snha_cap"]) + "," + chuyen.OBJ_C(b_dr["lnha_mua"]) + ","
                + chuyen.OBJ_S(b_dr["snha_mua"]) + "," + chuyen.OBJ_S(b_dr["sdat_cap"]) + ","
                + chuyen.OBJ_S(b_dr["sdat_mua"]) + "," + chuyen.OBJ_S(b_dr["sdat_tt"]) + ","
                + chuyen.OBJ_S(b_dr["ld_thue"]) + "," + chuyen.OBJ_C(b_dr["hd_kinhte"])
                + ",:a_tt" + ",:a_ten" + ",:a_gtri";


            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_GD_HC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_GD_HC_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_GD_HC_XOA");
    }
    #endregion HOÀN CẢNH KINH TẾ GIA ĐÌNH

    #region KẾT NẠP ĐẢNG LẦN II
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_TC_DANGL2_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_TC_DANGL2_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TC_DANGL2_MA(string b_phong, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_trangkt }, "NNR", "PNS_TC_DANGL2_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TC_DANGL2_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TC_DANGL2_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TC_DANGL2_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayvao"]) + ","
                + chuyen.OBJ_C(b_dr["noivao"]) + "," + chuyen.OBJ_S(b_dr["ngayct"]) + "," + chuyen.OBJ_C(b_dr["noict"]) + ","
                + chuyen.OBJ_S(b_dr["ngayph"]) + "," + chuyen.OBJ_C(b_dr["noiph"]) + "," + chuyen.OBJ_C(b_dr["nguoi1"]) + ","
                + chuyen.OBJ_C(b_dr["cvu1"]) + "," + chuyen.OBJ_C(b_dr["nguoi2"]) + "," + chuyen.OBJ_C(b_dr["cvu2"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TC_DANGL2_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_TC_DANGL2_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TC_DANGL2_XOA");
    }
    #endregion KẾT NẠP ĐẢNG LẦN II

    #region KỸ NĂNG CÁ NHÂN

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_KYNANG_CN_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_KYNANG_CN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_KYNANG_CN_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_kinhnghiem = bang.Fobj_COL_MANG(b_dt_ct, "kinhnghiem");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_ct, "noidung");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_kinhnghiem", 'U', a_kinhnghiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ghichu"])
                + ",:a_ma,:a_ten,:a_kinhnghiem,:a_noidung";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KYNANG_CN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void P_NS_KYNANG_CN_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_KYNANG_CN_XOA");
    }
    #endregion KỸ NĂNG CÁ NHÂN

    #region FILE ẢNH
    ///<summary>Bảng liệt kê</summary>
    public static DataTable Fdt_FI_ANH_LKE(string b_ma_dvi, string b_so_id, double b_cuoi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dvi, b_so_id, b_cuoi }, "PNS_FILE_ANH_LKE");
    }
    public static void P_FI_ANH_NH(string b_ma_dvi, string b_so_id, string b_ten, string b_goc)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_ten, b_goc }, "PNS_FILE_ANH_NH");
    }
    public static void P_FI_LOGO_NH(string b_ma, string b_ten, string b_goc)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_ten, b_goc }, "PHT_MA_DVI_ANH_NH");
    }
    public static void P_FI_ANH_XOA(string b_ma_dvi, string b_so_id, string b_goc)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_goc }, "PNS_FILE_ANH_XOA");
    }
    public static void P_FI_ANH_SUA(string b_ma_dvi, string b_so_id, string b_goc, string b_nd)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_goc, b_nd }, "PNS_FILE_ANH_SUA");
    }
    // lay url
    public static DataTable Fdt_FI_ANH_URL(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "PNS_FILE_ANH_URL");
    }
    #endregion FILE ẢNH

    #region CÀI ĐẶT QUẢN LÝ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CAIDAT_QLY_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CAIDAT_QLY_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_CAIDAT_QLY_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CAIDAT_QLY_MA");
    }

    // Chi tiet so lieu
    public static DataTable Fdt_NS_CAIDAT_QLY_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_CAIDAT_QLY_CT");
    }

    // Nhap so lieu
    public static void P_NS_CAIDAT_QLY_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ",:a_phong,:a_cdanh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CAIDAT_QLY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_CAIDAT_QLY_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CAIDAT_QLY_XOA");
    }
    #endregion CÀI ĐẶT QUẢN LÝ

    #region QUẢN LÝ PHÚC LỢI CÁ NHÂN
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_PHUCLOI_CN_LKE(string b_phong, string b_so_the, string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_ten, b_tu, b_den }, "NR", "PNS_PHUCLOI_CN_LKE");
    }
    public static DataTable Fdt_NS_PHUCLOI_CN_LKE_ALL(string b_phong, string b_so_the, string b_ten)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_so_the, b_ten }, "PNS_PHUCLOI_CN_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_PHUCLOI_CN_MA(string b_phong, string b_so_the, string b_ten, double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_ten, b_so_id, b_trangkt }, "NNR", "PNS_PHUCLOI_CN_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_PHUCLOI_CN_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_PHUCLOI_CN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static double PNS_PHUCLOI_CN_NH(double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_tinhluong = "0", b_kyluong = "";
            if (b_dr["luong_chiuthue"].ToString() == "X") b_tinhluong = "1";
            if (b_dr["luong_khongchiuthue"].ToString() == "X") b_tinhluong = "2";
            if (b_tinhluong != "0") b_kyluong = b_dr["kyluong"].ToString();

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["LOAI_PL"]) + "," + chuyen.OBJ_N(b_dr["SOTIEN"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_tinhluong) + "," + "N" + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_N(b_kyluong);
            b_c = b_c + "," + chuyen.OBJ_N(b_dr["ngay_tt"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_PHUCLOI_CN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_N(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_PHUCLOI_CN_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_PHUCLOI_CN_XOA");
    }
    #endregion QUAN HỆ NHÂN THÂN

    #region QUẢN LÝ PHÚC LỢI TỰ ĐỘNG
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_PHUCLOI_TUDONG_LKE(string b_phong, string b_kyluong_id, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_tu, b_den }, "NR", "PNS_PHUCLOI_TUDONG_LKE");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_PHUCLOI_TUDONG_CT(string b_phong, string b_kyluong_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong_id }, "PNS_PHUCLOI_TUDONG_TINH");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void PNS_PHUCLOI_TUDONG_TINH(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_kyluong_id }, "PNS_PHUCLOI_TUDONG_TINH");
    }


    /// <summary>Xóa thôn tin</summary>
    public static void PNS_PHUCLOI_TUDONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_PHUCLOI_TUDONG_XOA");
    }

    public static object[] Fdt_NS_PHUCLOI_TU_DONG_LKE(string b_phong, string b_so_the, string b_hoTen, double b_ngayD, double b_ngayC, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, b_hoTen, b_ngayD, b_ngayC, b_tu, b_den }, "NR", "PNS_PHUCLOI_TU_DONG_LKE");
    }
    public static void PNS_PHUCLOI_TU_DONG_TINH(string b_phong, string b_so_the, string b_hoTen, double b_ngayD, double b_ngayC)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_so_the, b_hoTen, b_ngayD, b_ngayC }, "PNS_PHUCLOI_TU_DONG_TINH");
    }
    public static DataTable PNS_PHUCLOI_TU_DONG_EXCEL(string b_phong, string b_so_the, string b_hoTen, double b_ngayD, double b_ngayC)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_so_the, b_hoTen, b_ngayD, b_ngayC }, "PNS_PHUCLOI_TU_DONG_EXCEL");
    }
    #endregion QUẢN LÝ PHÚC LỢI TỰ ĐỘNG



    public static DataTable Fdt_LOC_PHEDUYET()
    {
        return dbora.Fdt_LKE("pns_loc_pheduyet");
    }
    public static DataTable Fdt_GIAITRINH_GAN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "pns_cc_giaitrinh_gan");
    }
    public static DataTable Fdt_XIN_NGHIPHEP_GAN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "pns_qt_xin_nghiphep_gan");
    }
    public static DataTable Fdt_XIN_NGHIPHEP_CC_GAN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "pns_qt_xin_nghiphep_cc_gan");
    }
    public static DataTable Fdt_DKY_LAMTHEM_GAN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "pns_tl_dky_lamthem");
    }
    public static DataTable P_NS_KYNANG_CN_TIM(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_dk = bang.Fobj_COL_MANG(b_dt_ct, "dk");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_tu = bang.Fobj_COL_MANG(b_dt_ct, "tu");
            object[] a_den = bang.Fobj_COL_MANG(b_dt_ct, "den");

            dbora.P_THEM_PAR(ref b_lenh, "a_dk", 'U', a_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'U', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_tu", 'U', a_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_den", 'U', a_den);


            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_dk,:a_ma,:a_tu,:a_den,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KYNANG_CN_TIM(" + b_se.tso + b_c + "); end;";
            try
            {
                // b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable P_NS_DANHSACH_TIM(string b_lke, DataTable b_dt_cn, DataTable b_dt_ct, DataTable b_dt_cc)
    {
        bang.P_CNG_SO(ref b_dt_cn, "ngayvaod,ngayvaoc,ngaysinhd,ngaysinhc");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            DataRow b_dr = b_dt_cn.Rows[0];
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_dk = bang.Fobj_COL_MANG(b_dt_ct, "dk");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_tu = bang.Fobj_COL_MANG(b_dt_ct, "tu");
            object[] a_den = bang.Fobj_COL_MANG(b_dt_ct, "den");

            object[] c_dk = bang.Fobj_COL_MANG(b_dt_cc, "dk");
            object[] c_cc = bang.Fobj_COL_MANG(b_dt_cc, "cc");

            dbora.P_THEM_PAR(ref b_lenh, "a_dk", 'U', a_dk);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'U', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_tu", 'U', a_tu);
            dbora.P_THEM_PAR(ref b_lenh, "a_den", 'U', a_den);

            dbora.P_THEM_PAR(ref b_lenh, "c_dk", 'U', c_dk);
            dbora.P_THEM_PAR(ref b_lenh, "c_cc", 'U', c_cc);


            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_tk_cn = "," + chuyen.OBJ_C(b_dr["phong_tk"]) + "," + chuyen.OBJ_C(b_dr["so_the_tk"]) + "," + chuyen.OBJ_C(b_dr["ten_tk"]) + "," + chuyen.OBJ_C(b_lke)
                + "," + chuyen.OBJ_S(b_dr["ngayvaod"]) + "," + chuyen.OBJ_S(b_dr["ngayvaoc"]) + "," + chuyen.OBJ_S(b_dr["ngaysinhd"]) + "," + chuyen.OBJ_S(b_dr["ngaysinhc"])
                + "," + chuyen.OBJ_C(b_dr["gioitinh"]) + "," + chuyen.OBJ_C(b_dr["dchi"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["cvu"])
                 + "," + chuyen.OBJ_C(b_dr["ncdanh"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]);

            string b_c = ",:a_dk,:a_ma,:a_tu,:a_den,:c_dk,:c_cc,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_danhsach_tim(" + b_se.tso + b_tk_cn + b_c + "); end;";
            try
            {
                // b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #region QUÁ TRÌNH HỌC TẬP
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_QT_HOCTAP_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_DT_QT_HOCTAP_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_QT_HOCTAP_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_DT_QT_HOCTAP_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_QT_HOCTAP_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_DT_QT_HOCTAP_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_DT_QT_HOCTAP_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:b_so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["thangd"]) + "," + chuyen.OBJ_C(b_dr["thangc"]) + "," + chuyen.OBJ_C(b_dr["nam_tn"]) + ","
                + chuyen.OBJ_C(b_dr["truong"]) + "," + chuyen.OBJ_C(b_dr["ma_htdt"]) + "," + chuyen.OBJ_C(b_dr["ma_cndt"]) + "," + chuyen.OBJ_C(b_dr["ma_ketqua_dt"]) + ","
                + chuyen.OBJ_C(b_dr["so_hieu_bang"]) + "," + chuyen.OBJ_C(b_dr["ngay_hieu_luc"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_QT_HOCTAP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_DT_QT_HOCTAP_XOA(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_DT_QT_HOCTAP_XOA");
    }
    #endregion QUÁ TRÌNH ĐÀO TẠO NGẮN HẠN

    #region CHỈNH SỬA THÔNG TIN
    public static void P_NS_CB_TT_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { chuyen.OBJ_S(b_dr["so_the"]), chuyen.OBJ_S(b_dr["SOCMT"]), chuyen.OBJ_S(b_dr["dtdd"])
            , chuyen.OBJ_S(b_dr["dchi"]) , chuyen.OBJ_S(b_dr["tt_hientai"] ), chuyen.OBJ_S(b_dr["qh_hientai"]), chuyen.OBJ_S(b_dr["xp_hientai"])
            , chuyen.OBJ_S(b_dr["hkhau"]), chuyen.OBJ_S(b_dr["tt_thuongtru"]), chuyen.OBJ_S(b_dr["qh_thuongtru"]), chuyen.OBJ_S(b_dr["xp_thuongtru"]), chuyen.OBJ_S(b_dr["tt_honnhan"])};
        dbora.P_GOIHAM(a_obj, "pns_cb_tt_nh");
    }

    public static string P_NS_DT_NG_TT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten_cchi"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["sohieu"]) + ","
               + chuyen.OBJ_C(b_dr["ngaycap"]) + "," + chuyen.OBJ_C(b_dr["ngayhethl"]) + "," + chuyen.OBJ_C(b_dr["noidt"]) + ","
               + chuyen.OBJ_C(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ngayc"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_NGHAN_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion

    #region ĐÁNH GIÁ HĐLĐ
    public static object[] Fdt_NS_HD_DG_TT_LKE(string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the }, "NRRR", "pns_hd_dg_tt_lke");
    }

    public static void P_NS_HD_DG_TT_NH(double b_so_id, string b_so_the, DataTable b_dt_ct, DataTable b_dt_nv, DataTable b_dt_qhcv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;


            object[] a_stt_nv = bang.Fobj_COL_MANG(b_dt_nv, "SOTT");
            object[] a_cong_viec = bang.Fobj_COL_MANG(b_dt_nv, "CONG_VIEC");
            object[] a_mo_ta = bang.Fobj_COL_MANG(b_dt_nv, "MO_TA");
            object[] a_nguoi_hd = bang.Fobj_COL_MANG(b_dt_nv, "NGUOI_HD");
            object[] a_nguoi_ph = bang.Fobj_COL_MANG(b_dt_nv, "NGUOI_PH");
            object[] a_ketqua_nv = bang.Fobj_COL_MANG(b_dt_nv, "ket_qua");


            object[] a_stt_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "sott");
            object[] a_noi_dung_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "noi_dung");
            object[] a_yeu_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "yeu");
            object[] a_kem_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "kem");
            object[] a_trung_binh_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "trung_binh");
            object[] a_kha_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "kha");
            object[] a_xuat_sac_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "xuat_sac");
            object[] a_ghi_chu_nd = bang.Fobj_COL_MANG(b_dt_qhcv, "ghi_chu");



            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_stt_nv", 'N', a_stt_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_cong_viec_nv", 'U', a_cong_viec);
            dbora.P_THEM_PAR(ref b_lenh, "a_mo_ta_nv", 'U', a_mo_ta);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_hd_nv", 'U', a_nguoi_hd);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_ph_nv", 'U', a_nguoi_ph);
            dbora.P_THEM_PAR(ref b_lenh, "a_ket_qua_nv", 'U', a_ketqua_nv);

            dbora.P_THEM_PAR(ref b_lenh, "a_stt_nd", 'S', a_stt_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_dung_nd", 'U', a_noi_dung_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_yeu_nd", 'S', a_yeu_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_kem_nd", 'S', a_kem_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_trung_binh_nd", 'S', a_trung_binh_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_kha_nd", 'S', a_kha_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_xuat_sac_nd", 'S', a_xuat_sac_nd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghi_chu_nd", 'U', a_ghi_chu_nd);

            DataRow b_dr = b_dt_ct.Rows[0];

            string b_c = "," + chuyen.OBJ_C(b_so_the) + "," + chuyen.OBJ_C(b_dr["thuanloi_khokhan"]) + "," +
                chuyen.OBJ_C(b_dr["yk_congviec"]) + "," + chuyen.OBJ_C(b_dr["yk_chinhsach"]) + "," +
                chuyen.OBJ_C(b_dr["yk_daotao"]) + "," + chuyen.OBJ_C(b_dr["yk_khac"]) + ",:b_so_id,:a_stt_nv,:a_cong_viec_nv,:a_mo_ta_nv,:a_nguoi_hd_nv,:a_nguoi_ph,:a_ket_qua_nv,:a_stt_nd,:a_noi_dung_nd,:a_yeu_nd,:a_kem_nd,:a_trung_binh_nd,:a_kha_nd,:a_xuat_sac_nd,:a_ghi_chu_nd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_hd_dg_tt_nh(" + b_se.tso + b_c + "); end;";
            try
            {

                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void P_NS_HD_DG_TT_GUI(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_hd_dg_tt_gui");
    }
    #endregion

    #region CỔNG THÔNG TIN NHÂN SỰ - ĐỐI TƯỢNG CÁN BỘ QUẢN LÝ

    /// <summary>Liet ke toàn bộ cán bộ thuộc quyền quản lý</summary>
    public static object[] Fdt_NS_CB_CD_LKE(string b_so_the, double b_ttr, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_ttr, b_tu, b_den }, "NR", "PNS_CB_CD_LKE");
    }

    /// <summary>Liệt kê chi tiet một cán bộ</summary>
    public static DataSet Fds_NS_CB_CD_CT(string b_so_id, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, 10, "PNS_CB_CD_CT");
    }

    #endregion CỔNG THÔNG TIN NHÂN SỰ - ĐỐI TƯỢNG CÁN BỘ QUẢN LÝ

    #region QUẢN LÝ PHÚC LỢI
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_PHUCLOI_NV_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_PHUCLOI_NV_LKE");
    }
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_PHUCLOI_NV_TIEN(string b_loaipl)
    {
        return dbora.Faobj_LKE(new object[] { b_loaipl }, "NR", "PNS_PHUCLOI_NV_TIEN");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_PHUCLOI_NV_MA(string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_trangkt }, "NNR", "PNS_PHUCLOI_NV_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_PHUCLOI_NV_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_PHUCLOI_NV_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_PHUCLOI_NV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["mapl"]) + "," + chuyen.OBJ_N(b_dr["SOTIEN"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tinhluong"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_N(b_dr["kyluong"]);
            b_c = b_c + "," + chuyen.OBJ_N(b_dr["ngay_tt"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_PHUCLOI_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_PHUCLOI_NV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_PHUCLOI_NV_XOA");
    }
    #endregion

    #region[ĐÁNH GIÁ HỢP ĐỘNG LAO ĐỘNG]
    public static object[] Fdt_NS_TT_CBQL_DGIA_HDLD_LKE(string b_tthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tthai, b_tu, b_den }, "NR", "PNS_TT_CBQL_DGIA_HDLD_LKE");
    }
    public static DataTable Fdt_NS_TT_CBQL_DGIA_HDLD_HOI(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TT_CBQL_DGIA_HDLD_HOI");
    }

    public static void Fdt_NS_TT_CBQL_DGIA_HDLD_NH(string b_ma_cb, DataTable b_dt, DataTable b_dt_dg, DataTable b_dt_lke)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            //1:1 năm,2:2 năm,3:3 năm,4:Không thời hạn
            bang.P_THEM_COL(ref b_dt, "than_hd", "");
            bang.P_THAY_GTRI(ref b_dt, "than_hd", "1", "than1", "X");
            bang.P_THAY_GTRI(ref b_dt, "than_hd", "2", "than2", "X");
            bang.P_THAY_GTRI(ref b_dt, "than_hd", "3", "than3", "X");
            bang.P_THAY_GTRI(ref b_dt, "than_hd", "4", "than4", "X");
            // 0:yêu,1:kém,2:tb,3:kha,4:xuất sắc
            bang.P_THEM_COL(ref b_dt_dg, "loai_dg", "");
            bang.P_THAY_GTRI(ref b_dt_dg, "loai_dg", "0", "yeu", "X");
            bang.P_THAY_GTRI(ref b_dt_dg, "loai_dg", "1", "kem", "X");
            bang.P_THAY_GTRI(ref b_dt_dg, "loai_dg", "2", "tb", "X");
            bang.P_THAY_GTRI(ref b_dt_dg, "loai_dg", "3", "kha", "X");
            bang.P_THAY_GTRI(ref b_dt_dg, "loai_dg", "4", "xuatsac", "X");
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_nd_dgia = bang.Fobj_COL_MANG(b_dt_dg, "nd_dgia");
            object[] a_ghichu_dgia = bang.Fobj_COL_MANG(b_dt_dg, "mota");
            object[] a_loai_dg = bang.Fobj_COL_MANG(b_dt_dg, "loai_dg");

            object[] a_khiacanh = bang.Fobj_COL_MANG(b_dt_lke, "khiacanh");
            object[] a_chitieu = bang.Fobj_COL_MANG(b_dt_lke, "chitieu");
            object[] a_ghichu_dx = bang.Fobj_COL_MANG(b_dt_lke, "mota");
            object[] a_trongso = bang.Fobj_COL_MANG(b_dt_lke, "trongso");
            object[] a_dinhmuc1 = bang.Fobj_COL_MANG(b_dt_lke, "dinhmucl1");
            object[] a_dinhmuc2 = bang.Fobj_COL_MANG(b_dt_lke, "dinhmucl2");

            dbora.P_THEM_PAR(ref b_lenh, "nd_dgia", 'U', a_nd_dgia);
            dbora.P_THEM_PAR(ref b_lenh, "ghichu_dgia", 'U', a_ghichu_dgia);
            dbora.P_THEM_PAR(ref b_lenh, "loai_dg", 'N', a_loai_dg);

            dbora.P_THEM_PAR(ref b_lenh, "khiacanh", 'U', a_khiacanh);
            dbora.P_THEM_PAR(ref b_lenh, "chitieu", 'U', a_chitieu);
            dbora.P_THEM_PAR(ref b_lenh, "mota", 'U', a_ghichu_dx);
            dbora.P_THEM_PAR(ref b_lenh, "trongso", 'N', a_trongso);
            dbora.P_THEM_PAR(ref b_lenh, "dinhmucl1", 'N', a_dinhmuc1);
            dbora.P_THEM_PAR(ref b_lenh, "dinhmucl2", 'N', a_dinhmuc2);
            string b_c = "," + b_ma_cb.ToString() + "," + chuyen.OBJ_C(b_dr["dgia_chung"]) + "," + chuyen.OBJ_N(b_dr["than_hd"]) + "," + chuyen.OBJ_C(b_dr["dxuat"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + ","
                + chuyen.OBJ_C(b_dr["muctieu"]) + "," + chuyen.OBJ_C(b_dr["dgia_kq"])
                + ",:a_nd_dgia" + ",:a_ghichu_dgia" + ",:a_loai_dg" + ",:a_khiacanh" + ",:a_chitieu" + ",:a_ghichu_dx" + ",:a_trongso" + ",:a_dinhmuc1" + ",:a_dinhmuc2";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TT_CBQL_DGIA_HDLD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion

    #region THÔNG TIN HỘ GIA ĐÌNH

    public static DataSet Fds_NS_HO_GDINH_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 2, "PNS_HO_GDINH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void Fs_NS_HO_GDINH_NH(DataTable b_dt, DataTable b_dt_qhe)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ten = bang.Fobj_COL_MANG(b_dt_qhe, "ten");
            object[] a_bhxh = bang.Fobj_COL_MANG(b_dt_qhe, "bhxh");
            object[] a_ngaysinh = bang.Fobj_COL_MANG(b_dt_qhe, "ngaysinh");
            object[] a_gtinh = bang.Fobj_COL_MANG(b_dt_qhe, "gtinh");
            object[] a_ncap_gks = bang.Fobj_COL_MANG(b_dt_qhe, "ncap_gks");
            object[] a_qhe = bang.Fobj_COL_MANG(b_dt_qhe, "qhe");
            object[] a_cmt = bang.Fobj_COL_MANG(b_dt_qhe, "cmt");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_qhe, "mota");

            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'U', a_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh", 'N', a_ngaysinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_gtinh", 'S', a_gtinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ncap_gks", 'U', a_ncap_gks);
            dbora.P_THEM_PAR(ref b_lenh, "a_qhe", 'S', a_qhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_cmt", 'U', a_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["chuho"]) + "," + chuyen.OBJ_C(b_dr["phone"]) + "," + chuyen.OBJ_C(b_dr["so_hk"]) + ","
                + chuyen.OBJ_C(b_dr["ma_ho_gd"]) + "," + chuyen.OBJ_C(b_dr["diachi"]) + "," + chuyen.OBJ_C(b_dr["tinhthanh"]) + "," + chuyen.OBJ_C(b_dr["quanhuyen"]) + "," + chuyen.OBJ_C(b_dr["xaphuong"]) + ","
                + ":a_ten,:a_bhxh,:a_ngaysinh,:a_gtinh,:a_ncap_gks,:a_qhe,:a_cmt,:a_mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HO_GDINH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void PNS_HO_GDINH_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_HO_GDINH_XOA");
    }

    #endregion THÔNG TIN HỘ GIA ĐÌNH
}