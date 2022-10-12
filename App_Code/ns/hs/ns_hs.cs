using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_hs
{
    public static DataTable Fdt_NS_CB_HOI(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CB_HOI");
    }

    public static object[] Fdt_NS_CB_MA(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangkt }, "NNR", "PNS_CB_MA");
    }

    public static object[] Fdt_NS_CB_TT_MA(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangkt }, "NNR", "PNS_CB_TT_MA");
    }
    public static double Fd_NS_CB_KT(DataTable b_dt)
    {
        object[] a_obj;
        bang.P_CSO_SO(ref b_dt, "ma_cc");
        foreach (DataRow b_dr in b_dt.Rows)
        {
            //DLV
            a_obj = new object[] { b_dr["so_the"], b_dr["socmt"], b_dr["socmt9"], b_dr["nsinh"], 1, b_dr["ma_cc"] };
            DataTable b_dt_kt = dbora.Fdt_LKE_S(a_obj, "PNS_CB_KT");
            if (b_dt_kt.Rows.Count > 0) return 1;
            //DSD
            a_obj = new object[] { b_dr["so_the"], b_dr["socmt"], b_dr["socmt9"], b_dr["nsinh"], 2, b_dr["ma_cc"] };
            b_dt_kt = dbora.Fdt_LKE_S(a_obj, "PNS_CB_KT");
            if (b_dt_kt.Rows.Count > 0) return 2;
            //NV
            a_obj = new object[] { b_dr["so_the"], b_dr["socmt"], b_dr["socmt9"], b_dr["nsinh"], 3, b_dr["ma_cc"] };
            b_dt_kt = dbora.Fdt_LKE_S(a_obj, "PNS_CB_KT");
            if (b_dt_kt.Rows.Count > 0) return 3;
        }
        return 0;
    }
    public static DataTable Fdt_NS_DVI_ANH()
    {
        return dbora.Fdt_LKE("PHT_DVI_ANH");
    }
    /// <summary>Thuc hien nhap cho can bo</summary>
    public static string P_NS_CB_NH(DataTable b_dt, DataTable b_dt_ttt, DataTable b_dt_nl)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        OracleCommand b_lenh = b_cnn.CreateCommand();
        DataRow b_dr = b_dt.Rows[0];
        string b_tt = chuyen.OBJ_S(b_dr["tt"]);
        if (b_tt == "") { b_tt = "0"; }
        //string b_ts_ttt;
        //ns_khud.P_TTT_TS(ref b_lenh, b_dt_ttt, out b_ts_ttt);

        if (b_dt_ttt.Rows.Count == 0)
            bang.P_THEM_TRANG(ref b_dt_ttt, 1);
        if (bang.Fi_TIM_COL(b_dt_ttt, "so_id_dt") < 0)
            bang.P_THEM_COL(ref b_dt_ttt, "so_id_dt", 0);

        dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));
        // THÔNG TIN KHÁC
        object[] a_so_id_dt = bang.Fobj_COL_MANG(b_dt_ttt, "so_id_dt");
        object[] a_ma = bang.Fobj_COL_MANG(b_dt_ttt, "ma");
        object[] a_nd = bang.Fobj_COL_MANG(b_dt_ttt, "nd");

        dbora.P_THEM_PAR(ref b_lenh, "a_so_id_dt", 'N', a_so_id_dt);
        dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
        dbora.P_THEM_PAR(ref b_lenh, "a_nd", 'U', a_nd);

        // THÔNG TIN ĐÁNH GIÁ NĂNG LỰC
        //object[] a_nhom_nl = bang.Fobj_COL_MANG(b_dt_nl, "nhom_nl");
        //object[] a_nangluc = bang.Fobj_COL_MANG(b_dt_nl, "nangluc");
        //object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_nl, "muc_nl");
        object[] a_muc_nl_id = bang.Fobj_COL_MANG(b_dt_nl, "muc_nl_id");
        //object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_nl, "ghichu");


        //dbora.P_THEM_PAR(ref b_lenh, "a_nhom_nl", 'S', a_nhom_nl);
        //dbora.P_THEM_PAR(ref b_lenh, "a_nangluc", 'S', a_nangluc);
        //dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl", 'S', a_muc_nl);
        //dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
        dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl_id", 'N', a_muc_nl_id);

        string c = "," + ":so_the," +
           chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ten_hoa"]) + "," + chuyen.OBJ_C(b_dr["gtinh"]) + "," + 
           chuyen.OBJ_S(b_dr["nsinh"]) + "," + chuyen.OBJ_C(b_dr["dtnr"]) + "," + chuyen.OBJ_C(b_dr["dtdd"]) + "," + 
           chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["tt_honnhan"]) + "," + chuyen.OBJ_C(b_dr["socmt9"]) + "," + 
           chuyen.OBJ_S(b_dr["ngay_cmt9"]) + "," + chuyen.OBJ_C(b_dr["nc_cmt9"]) + "," + chuyen.OBJ_C(b_dr["socmt"]) + "," +
           chuyen.OBJ_S(b_dr["ngay_cmt"]) + "," + chuyen.OBJ_C(b_dr["nc_cmt"]) + "," + chuyen.OBJ_C(b_dr["nn"]) + "," + 
           chuyen.OBJ_C(b_dr["dantoc"]) + "," + chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["noi_sinh"]) + "," + 
           chuyen.OBJ_C(b_dr["tt_noisinh"]) + "," + chuyen.OBJ_C(b_dr["qh_noisinh"]) + "," + chuyen.OBJ_C(b_dr["xp_noisinh"]) + "," + 
           chuyen.OBJ_C(b_dr["dchi_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["qh_thuongtru"]) + "," + 
           chuyen.OBJ_C(b_dr["xp_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["dchi_tamtru"]) + "," + chuyen.OBJ_C(b_dr["tt_tamtru"]) + "," + 
           chuyen.OBJ_C(b_dr["qh_tamtru"]) + "," + chuyen.OBJ_C(b_dr["xp_tamtru"]) + "," + chuyen.OBJ_C(b_dr["hoten_ll"]) + "," + 
           chuyen.OBJ_C(b_dr["quanhe_ll"]) + "," + chuyen.OBJ_C(b_dr["sdt_ll"]) + "," +  chuyen.OBJ_C(b_dr["khican_ll"]) + "," +  
           chuyen.OBJ_C(b_dr["email_cty"]) + "," + chuyen.OBJ_S(b_dr["ma_cc"]) + "," + chuyen.OBJ_C(b_dr["kiemnhiem"]) + "," + 
           chuyen.OBJ_C(b_dr["quanly_tt"]) + "," + chuyen.OBJ_C(b_dr["quequan"]) + "," + chuyen.OBJ_C(b_dr["tt_quequan"]) + "," +
           chuyen.OBJ_C(b_dr["qh_quequan"]) + "," + chuyen.OBJ_C(b_dr["xp_quequan"]) + "," + chuyen.OBJ_C(b_dr["dt_cutru"]) + "," + 
           chuyen.OBJ_C(b_dr["ht_tinhluong"]) + "," +  chuyen.OBJ_C(b_dr["so_bhxh"]) + "," + chuyen.OBJ_C(b_dr["so_bhyt"]) + "," + 
           chuyen.OBJ_C(b_dr["mast"]) + "," + 
           chuyen.OBJ_C(b_dr["so_hchieu"]) + "," + chuyen.OBJ_S(b_dr["ngaycap_hchieu"]) + "," + chuyen.OBJ_C(b_dr["thoihan_hchieu"]) + "," + 
           chuyen.OBJ_C(b_dr["so_visa"]) + "," + chuyen.OBJ_S(b_dr["ngaycap_visa"]) + "," + chuyen.OBJ_C(b_dr["noicap_visa"]) + "," + 
           chuyen.OBJ_S(b_dr["ngayhethan_visa"]) + "," + chuyen.OBJ_S(b_dr["ngaythamgia"]) + "," + chuyen.OBJ_C(b_dr["sotk"]) + "," + 
           chuyen.OBJ_C(b_dr["nha"]) + "," + chuyen.OBJ_C(b_dr["cnhanh_nha"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," + 
           chuyen.OBJ_S(b_dr["ngaycap_mst"]) + "," + chuyen.OBJ_C(b_dr["cqthue"]) + "," + chuyen.OBJ_C(b_dr["chieucao"]) + "," + 
           chuyen.OBJ_C(b_dr["cannang"]) + "," + chuyen.OBJ_C(b_dr["nhommau"]) + "," + chuyen.OBJ_C(b_dr["hopdong_id"]) + "," + 
           chuyen.OBJ_S(b_dr["is_3b"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_C(b_dr["ban"]) + "," + 
           chuyen.OBJ_C(b_dr["phong_ban"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["ncdanh"]) + "," + 
           chuyen.OBJ_C(b_dr["bac_cdanh"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngay_tv"]) + "," + 
           chuyen.OBJ_S(b_dr["ngay_ct"]) + "," + chuyen.OBJ_S(b_dr["ngay_bd_hopdong"]) + "," + chuyen.OBJ_C(b_dr["ma_nsd"]) + "," + 
           chuyen.OBJ_C(b_dr["la_cty_chinh"]) + "," + chuyen.OBJ_C(b_dr["ma_pbo"]) + "," + chuyen.OBJ_C(b_dr["CO_LANHDAO"]) + "," + 
           chuyen.OBJ_C(b_dr["khoi"]) + "," + chuyen.OBJ_C(b_dr["dtnv"]) + "," + chuyen.OBJ_C(b_dr["address"]) + "," + 
           chuyen.OBJ_C(b_dr["branch"]) + "," + chuyen.OBJ_C(b_dr["qtrr"]) + "," + chuyen.OBJ_C(b_dr["ubck"]) + "," + 
           chuyen.OBJ_C(b_dr["vung"]) + "," + chuyen.OBJ_C(b_dr["cd"])
         
           + ",:a_so_id_dt,:a_ma,:a_nd,:a_muc_nl_id";
        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_NH(" + b_se.tso + c + "); end;";
        try
        {
            b_lenh.ExecuteNonQuery();
            return chuyen.OBJ_S(b_lenh.Parameters["so_the"].Value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b_cnn.Close();
            b_cnn.Dispose();
        }
    }
    public static string P_NS_CB_TT_NH(DataTable b_dt, DataTable b_dt_ttt, DataTable b_dt_nl)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        OracleCommand b_lenh = b_cnn.CreateCommand();
        DataRow b_dr = b_dt.Rows[0];
        string b_tt = chuyen.OBJ_S(b_dr["tt"]);
        if (b_tt == "") { b_tt = "0"; }
        //string b_ts_ttt;
        //ns_khud.P_TTT_TS(ref b_lenh, b_dt_ttt, out b_ts_ttt);

        if (b_dt_ttt.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt_ttt, 1);
        if (bang.Fi_TIM_COL(b_dt_ttt, "so_id_dt") < 0) bang.P_THEM_COL(ref b_dt_ttt, "so_id_dt", 0);

        dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));
        // THÔNG TIN KHÁC
        object[] a_so_id_dt = bang.Fobj_COL_MANG(b_dt_ttt, "so_id_dt");
        object[] a_ma = bang.Fobj_COL_MANG(b_dt_ttt, "ma");
        object[] a_nd = bang.Fobj_COL_MANG(b_dt_ttt, "nd");

        dbora.P_THEM_PAR(ref b_lenh, "a_so_id_dt", 'N', a_so_id_dt);
        dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
        dbora.P_THEM_PAR(ref b_lenh, "a_nd", 'U', a_nd);

        // THÔNG TIN ĐÁNH GIÁ NĂNG LỰC
        //object[] a_nhom_nl = bang.Fobj_COL_MANG(b_dt_nl, "nhom_nl");
        //object[] a_nangluc = bang.Fobj_COL_MANG(b_dt_nl, "nangluc");
        //object[] a_muc_nl = bang.Fobj_COL_MANG(b_dt_nl, "muc_nl");
        object[] a_muc_nl_id = bang.Fobj_COL_MANG(b_dt_nl, "muc_nl_id");
        //object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_nl, "ghichu");


        //dbora.P_THEM_PAR(ref b_lenh, "a_nhom_nl", 'S', a_nhom_nl);
        //dbora.P_THEM_PAR(ref b_lenh, "a_nangluc", 'S', a_nangluc);
        //dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl", 'S', a_muc_nl);
        //dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
        dbora.P_THEM_PAR(ref b_lenh, "a_muc_nl_id", 'N', a_muc_nl_id);

        string c = "," + ":so_the," +
           chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["ten_hoa"]) + "," + chuyen.OBJ_C(b_dr["gtinh"]) + "," +
           chuyen.OBJ_S(b_dr["nsinh"]) + "," + chuyen.OBJ_C(b_dr["dtnr"]) + "," + chuyen.OBJ_C(b_dr["dtdd"]) + "," +
           chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["tt_honnhan"]) + "," + chuyen.OBJ_C(b_dr["socmt9"]) + "," +
           chuyen.OBJ_S(b_dr["ngay_cmt9"]) + "," + chuyen.OBJ_C(b_dr["nc_cmt9"]) + "," + chuyen.OBJ_C(b_dr["socmt"]) + "," +
           chuyen.OBJ_S(b_dr["ngay_cmt"]) + "," + chuyen.OBJ_C(b_dr["nc_cmt"]) + "," + chuyen.OBJ_C(b_dr["nn"]) + "," +
           chuyen.OBJ_C(b_dr["dantoc"]) + "," + chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["noi_sinh"]) + "," +
           chuyen.OBJ_C(b_dr["tt_noisinh"]) + "," + chuyen.OBJ_C(b_dr["qh_noisinh"]) + "," + chuyen.OBJ_C(b_dr["xp_noisinh"]) + "," +
           chuyen.OBJ_C(b_dr["dchi_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["qh_thuongtru"]) + "," +
           chuyen.OBJ_C(b_dr["xp_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["dchi_tamtru"]) + "," + chuyen.OBJ_C(b_dr["tt_tamtru"]) + "," +
           chuyen.OBJ_C(b_dr["qh_tamtru"]) + "," + chuyen.OBJ_C(b_dr["xp_tamtru"]) + "," + chuyen.OBJ_C(b_dr["hoten_ll"]) + "," +
           chuyen.OBJ_C(b_dr["quanhe_ll"]) + "," + chuyen.OBJ_C(b_dr["sdt_ll"]) + "," + chuyen.OBJ_C(b_dr["khican_ll"]) + "," +
           chuyen.OBJ_C(b_dr["email_cty"]) + "," + chuyen.OBJ_S(b_dr["ma_cc"]) + "," + chuyen.OBJ_C(b_dr["kiemnhiem"]) + "," +
           chuyen.OBJ_C(b_dr["quanly_tt"]) + "," + chuyen.OBJ_C(b_dr["quequan"]) + "," + chuyen.OBJ_C(b_dr["tt_quequan"]) + "," +
           chuyen.OBJ_C(b_dr["qh_quequan"]) + "," + chuyen.OBJ_C(b_dr["xp_quequan"]) + "," + chuyen.OBJ_C(b_dr["dt_cutru"]) + "," +
           chuyen.OBJ_C(b_dr["ht_tinhluong"]) + "," + chuyen.OBJ_C(b_dr["so_bhxh"]) + "," + chuyen.OBJ_C(b_dr["so_bhyt"]) + "," +
           chuyen.OBJ_C(b_dr["mast"]) + "," +
           chuyen.OBJ_C(b_dr["so_hchieu"]) + "," + chuyen.OBJ_S(b_dr["ngaycap_hchieu"]) + "," + chuyen.OBJ_C(b_dr["thoihan_hchieu"]) + "," +
           chuyen.OBJ_C(b_dr["so_visa"]) + "," + chuyen.OBJ_S(b_dr["ngaycap_visa"]) + "," + chuyen.OBJ_C(b_dr["noicap_visa"]) + "," +
           chuyen.OBJ_S(b_dr["ngayhethan_visa"]) + "," + chuyen.OBJ_S(b_dr["ngaythamgia"]) + "," + chuyen.OBJ_C(b_dr["sotk"]) + "," +
           chuyen.OBJ_C(b_dr["nha"]) + "," + chuyen.OBJ_C(b_dr["cnhanh_nha"]) + "," + chuyen.OBJ_C(b_dr["tt"]) + "," +
           chuyen.OBJ_S(b_dr["ngaycap_mst"]) + "," + chuyen.OBJ_C(b_dr["cqthue"]) + "," + chuyen.OBJ_C(b_dr["chieucao"]) + "," +
           chuyen.OBJ_C(b_dr["cannang"]) + "," + chuyen.OBJ_C(b_dr["nhommau"]) + "," + chuyen.OBJ_C(b_dr["hopdong_id"]) + "," +
           chuyen.OBJ_S(b_dr["is_3b"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_C(b_dr["ban"]) + "," +
           chuyen.OBJ_C(b_dr["phong_ban"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["ncdanh"]) + "," +
           chuyen.OBJ_C(b_dr["bac_cdanh"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngay_tv"]) + "," +
           chuyen.OBJ_S(b_dr["ngay_ct"]) + "," + chuyen.OBJ_S(b_dr["ngay_bd_hopdong"]) + "," + chuyen.OBJ_C(b_dr["ma_nsd"]) + "," +
           chuyen.OBJ_C(b_dr["la_cty_chinh"]) + "," + chuyen.OBJ_C(b_dr["ma_pbo"]) + "," + chuyen.OBJ_C(b_dr["CO_LANHDAO"]) + "," +
           chuyen.OBJ_C(b_dr["khoi"]) + "," + chuyen.OBJ_C(b_dr["dtnv"]) + "," + chuyen.OBJ_C(b_dr["address"]) + "," +
           chuyen.OBJ_C(b_dr["branch"]) + "," + chuyen.OBJ_C(b_dr["qtrr"]) + "," + chuyen.OBJ_C(b_dr["ubck"]) + "," +
           chuyen.OBJ_C(b_dr["vung"]) + "," + chuyen.OBJ_C(b_dr["cd"])

           + ",:a_so_id_dt,:a_ma,:a_nd,:a_muc_nl_id";
        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_TT_NH(" + b_se.tso + c + "); end;";
        try
        {
            b_lenh.ExecuteNonQuery();
            return chuyen.OBJ_S(b_lenh.Parameters["so_the"].Value);
        }
        catch (Exception ex) { throw new Exception(ex.Message); }
        finally { b_cnn.Close(); b_cnn.Dispose(); }
    }
    public static void P_NS_CB_QL_PD_DUYET_NH(DataTable b_dt1, DataTable b_dt2, DataTable b_dt3, DataTable b_dt4, DataTable b_dt5)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            if (b_dt1.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt1, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt2.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt2, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt3.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt3, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt4.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt4, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt5.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt5, new object[] { "", "", "", "", "", "", "", "", "" }); }

            object[] a_so_the_cb = bang.Fobj_COL_MANG(b_dt1, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_cb", 'S', a_so_the_cb);

            object[] a_so_the_qt = bang.Fobj_COL_MANG(b_dt2, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_qt", 'S', a_so_the_qt);

            object[] a_so_the_bc = bang.Fobj_COL_MANG(b_dt3, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_bc", 'S', a_so_the_bc);

            object[] a_so_the_cc = bang.Fobj_COL_MANG(b_dt4, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_cc", 'S', a_so_the_cc);

            object[] a_so_the_nt = bang.Fobj_COL_MANG(b_dt5, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_nt", 'S', a_so_the_nt);

            string b_c = ",:a_so_the_cb,:a_so_the_qt,:a_so_the_bc,:a_so_the_cc,:a_so_the_nt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_QL_PD_DUYET_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_CB_QL_PD_KO_DUYET_NH(DataTable b_dt1, DataTable b_dt2, DataTable b_dt3, DataTable b_dt4, DataTable b_dt5)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            if (b_dt1.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt1, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt2.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt2, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt3.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt3, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt4.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt4, new object[] { "", "", "", "", "", "", "", "", "", "", "", "" }); }
            if (b_dt5.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt5, new object[] { "", "", "", "", "", "", "", "", "" }); }

            object[] a_so_the_cb = bang.Fobj_COL_MANG(b_dt1, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_cb", 'S', a_so_the_cb);

            object[] a_so_the_qt = bang.Fobj_COL_MANG(b_dt2, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_qt", 'S', a_so_the_qt);

            object[] a_so_the_bc = bang.Fobj_COL_MANG(b_dt3, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_bc", 'S', a_so_the_bc);

            object[] a_so_the_cc = bang.Fobj_COL_MANG(b_dt4, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_cc", 'S', a_so_the_cc);

            object[] a_so_the_nt = bang.Fobj_COL_MANG(b_dt5, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_nt", 'S', a_so_the_nt);

            string b_c = ",:a_so_the_cb,:a_so_the_qt,:a_so_the_bc,:a_so_the_cc,:a_so_the_nt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CB_QL_PD_KO_DUYET_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xoa can bo</summary>
    public static void P_NS_CB_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_CB_XOA");
    }
    public static void P_NS_CB_TT_GUI(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_CB_TT_GUI");
    }
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_CB_LKE(string b_phong, string b_lke, string b_so_the, string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_lke, b_so_the, "N'" + b_ten, b_tu, b_den }, "NR", "PNS_CB_LKE1");
    }

    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static DataSet Fdt_NS_CB_CT(string b_so_the, string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_so_id }, 3, "PNS_CB_CT");
    }
    public static DataSet Fdt_NS_CB_TT_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 3, "PNS_CB_TT_CT");
    }
    public static object[] Fdt_NS_CB_QL_PD_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "PNS_CB_QL_PD_LKE");
    }
    public static object[] Fdt_NS_CB_QL_PD_SYLL_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cb_ql_pd_syll_lke");
    }
    public static object[] Fdt_NS_CB_QL_PD_LSCT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cb_ql_pd_lsct_lke");
    }
    public static object[] Fdt_NS_CB_QL_PD_BCCM_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cb_ql_pd_bccm_lke");
    }
    public static object[] Fdt_NS_CB_QL_PD_NGHAN_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cb_ql_pd_nghan_lke");
    }
    public static object[] Fdt_NS_CB_QL_PD_QHNT_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cb_ql_pd_qhnt_lke");
    }
    public static DataTable Fdt_NS_CB_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_CB_EXCEL");
    }
    public static object[] Faobj_NS_CB_LKE_ALL(string b_phong, string b_trangthai, string b_so_the, string b_ten)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_trangthai, b_so_the, b_ten }, "R", "PNS_CB_EXCEL");
    }
    public static DataSet Faobj_NS_CB_LY_LICH_TRICH_NGANG(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.CSO_SO(b_so_id) }, 8, "BC_NS_LY_LICH_TRICHNGANG");
    }
}