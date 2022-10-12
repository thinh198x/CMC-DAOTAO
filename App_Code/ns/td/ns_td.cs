using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;

public class ns_td
{
    #region KẾ HOẠCH TUYỂN DỤNG NĂM
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_TD_KH_NAM_LKE(string b_nam_tk, string b_donvi_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_tu, b_den }, "NR", "PNS_TD_KH_NAM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_NS_TD_KH_NAM_MA(string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_trangkt }, "NNR", "PNS_TD_KH_NAM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TD_KH_NAM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_TD_KH_NAM_CT");
    }
    public static object[] Fdt_NS_TD_KH_NAM_BY_PHONG(string b_nam, string b_donvi)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_donvi }, "R", "PNS_TD_KH_NAM_BY_PHONG");
    }
    /// <summary>Nhập nội dung thông tin</summary>PNS_TD_KH_NAM_LKE
    public static void P_NS_TD_KH_NAM_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_nam = chuyen.OBJ_C(b_dr["nam"]);
            string b_donvi = chuyen.OBJ_C(b_dr["donvi"]);
            string b_phongban_ct = chuyen.OBJ_C(b_dr["phongban_ct"]);

            object[] a_ma_kh = bang.Fobj_COL_MANG(b_dt_ct, "ma_kh");
            object[] a_ban = bang.Fobj_COL_MANG(b_dt_ct, "ban");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
            object[] a_sl_cantuyen = bang.Fobj_COL_MANG(b_dt_ct, "sl_cantuyen");
            object[] a_ngaycan_ns = bang.Fobj_COL_MANG(b_dt_ct, "ngaycan_ns");
            object[] a_ns_t1 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t1");
            object[] a_ns_t2 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t2");
            object[] a_ns_t3 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t3");
            object[] a_ns_t4 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t4");
            object[] a_ns_t5 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t5");
            object[] a_ns_t6 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t6");
            object[] a_ns_t7 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t7");
            object[] a_ns_t8 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t8");
            object[] a_ns_t9 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t9");
            object[] a_ns_t10 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t10");
            object[] a_ns_t11 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t11");
            object[] a_ns_t12 = bang.Fobj_COL_MANG(b_dt_ct, "ns_t12");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_kh", 'S', a_ma_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban", 'S', a_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'S', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_cantuyen", 'S', a_sl_cantuyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycan_ns", 'S', a_ngaycan_ns);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t1", 'S', a_ns_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t2", 'S', a_ns_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t3", 'S', a_ns_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t4", 'S', a_ns_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t5", 'S', a_ns_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t6", 'S', a_ns_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t7", 'S', a_ns_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t8", 'S', a_ns_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t9", 'S', a_ns_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t10", 'S', a_ns_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t11", 'S', a_ns_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_t12", 'S', a_ns_t12);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + b_nam + "," + b_donvi + "," + b_phongban_ct + ",:a_ma_kh,:a_ban,:a_phong,:a_cdanh,:a_capbac,:a_sl_cantuyen,:a_ngaycan_ns," +
                         ":a_ns_t1,:a_ns_t2,:a_ns_t3,:a_ns_t4,:a_ns_t5,:a_ns_t6,:a_ns_t7,:a_ns_t8,:a_ns_t9,:a_ns_t10,:a_ns_t11,:a_ns_t12,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_NAM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_TD_KH_NAM_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_TD_KH_NAM_EXPORT");
    }
    public static string Fs_NS_TD_KH_NAM_IMP(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            int b_i = 0;
            foreach (DataRow drow in b_dt.Rows)
            {
                if (drow["MA_KH"].Equals(""))
                {
                    string b_ma_ts = ht_dungchung.Fdt_AutoGenCode("KHN", "NS_TD_KH_NAM", "MA_KH");
                    int b_item = int.Parse(b_ma_ts.Substring(3, 3));
                    drow["MA_KH"] = "KHN" + string.Format("{0:000}", b_item + b_i);
                    b_i = b_i + 1;
                }
            }

            bang.P_CNG_SO(ref b_dt, "NGAYCAN_NS");
            bang.P_CSO_SO(ref b_dt, "NAM,SL_CANTUYEN");


            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_donvi = bang.Fobj_COL_MANG(b_dt, "donvi");
            object[] a_ma_kh = bang.Fobj_COL_MANG(b_dt, "ma_kh");
            object[] a_ban = bang.Fobj_COL_MANG(b_dt, "ban");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt, "capbac");
            object[] a_sl_cantuyen = bang.Fobj_COL_MANG(b_dt, "sl_cantuyen");
            object[] a_ngaycan_ns = bang.Fobj_COL_MANG(b_dt, "ngaycan_ns");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");

            //dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));

            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'S', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_kh ", 'S', a_ma_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban ", 'S', a_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'S', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_cantuyen", 'N', a_sl_cantuyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycan_ns", 'N', a_ngaycan_ns);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_nam,:a_donvi,:a_ma_kh,:a_ban,:a_phong,:a_cdanh,:a_capbac,:a_sl_cantuyen,:a_ngaycan_ns,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_NAM_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_TD_KH_NAM, TEN_BANG.NS_TD_KH_NAM);
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TD_KH_NAM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_TD_KH_NAM_XOA");
    }
    public static DataTable Fdt_NS_TD_LAY_DINHBIEN(string b_phong, string b_cdanh, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_cdanh, b_nam }, "PNS_TD_KH_LAY_DINHBIEN");
    }
    public static DataTable Fdt_MA_PHONG_EXP()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_EXP");
    }
    public static DataTable Fdt_MA_CDANH_EXP()
    {
        return dbora.Fdt_LKE("PHT_MA_CDANH_EXP");
    }
    public static DataTable Fdt_MA_LVCDANH_EXP()
    {
        return dbora.Fdt_LKE("PHDNS_MA_LVCDANH_EXP");
    }
    #endregion KẾ HOẠCH TUYỂN DỤNG NĂM

    #region KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM
    public static object[] Faobj_NS_TD_KH_DCHUYEN_BNHIEM_LKE(string b_nam_tk, string b_donvi_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_tu, b_den }, "NR", "PNS_TD_KH_DCHUYEN_BNHIEM_LKE");
    }
    public static object[] Faobj_NS_TD_KH_DCHUYEN_BNHIEM_MA(string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_trangkt }, "NNR", "PNS_TD_KH_DCHUYEN_BNHIEM_MA");
    }
    public static DataTable Fdt_NS_TD_KH_DCHUYEN_BNHIEM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_TD_KH_DCHUYEN_BNHIEM_CT");
    }
    public static void P_NS_TD_KH_DCHUYEN_BNHIEM_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_nam = chuyen.OBJ_C(b_dr["nam"]);
            string b_donvi = chuyen.OBJ_C(b_dr["donvi"]);
            string b_phongban_ct = chuyen.OBJ_C(b_dr["phongban_ct"]);

            object[] a_ma_kh = bang.Fobj_COL_MANG(b_dt_ct, "ma_kh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_giam_t1 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t1");
            object[] a_giam_t2 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t2");
            object[] a_giam_t3 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t3");
            object[] a_giam_t4 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t4");
            object[] a_giam_t5 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t5");
            object[] a_giam_t6 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t6");
            object[] a_giam_t7 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t7");
            object[] a_giam_t8 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t8");
            object[] a_giam_t9 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t9");
            object[] a_giam_t10 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t10");
            object[] a_giam_t11 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t11");
            object[] a_giam_t12 = bang.Fobj_COL_MANG(b_dt_ct, "giam_t12");


            object[] a_tang_t1 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t1");
            object[] a_tang_t2 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t2");
            object[] a_tang_t3 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t3");
            object[] a_tang_t4 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t4");
            object[] a_tang_t5 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t5");
            object[] a_tang_t6 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t6");
            object[] a_tang_t7 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t7");
            object[] a_tang_t8 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t8");
            object[] a_tang_t9 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t9");
            object[] a_tang_t10 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t10");
            object[] a_tang_t11 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t11");
            object[] a_tang_t12 = bang.Fobj_COL_MANG(b_dt_ct, "tang_t12");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_kh", 'S', a_ma_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t1", 'S', a_giam_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t2", 'S', a_giam_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t3", 'S', a_giam_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t4", 'S', a_giam_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t5", 'S', a_giam_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t6", 'S', a_giam_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t7", 'S', a_giam_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t8", 'S', a_giam_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t9", 'S', a_giam_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t10", 'S', a_giam_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t11", 'S', a_giam_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_giam_t12", 'S', a_giam_t12);

            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t1", 'S', a_tang_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t2", 'S', a_tang_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t3", 'S', a_tang_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t4", 'S', a_tang_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t5", 'S', a_tang_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t6", 'S', a_tang_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t7", 'S', a_tang_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t8", 'S', a_tang_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t9", 'S', a_tang_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t10", 'S', a_tang_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t11", 'S', a_tang_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_tang_t12", 'S', a_tang_t12);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + b_nam + "," + b_donvi + "," + b_phongban_ct + ",:a_ma_kh,:a_cdanh," +
                         ":a_giam_t1,:a_giam_t2,:a_giam_t3,:a_giam_t4,:a_giam_t5,:a_giam_t6,:a_giam_t7,:a_giam_t8,:a_giam_t9,:a_giam_t10,:a_giam_t11,:a_giam_t12," +
                         ":a_tang_t1,:a_tang_t2,:a_tang_t3,:a_tang_t4,:a_tang_t5,:a_tang_t6,:a_tang_t7,:a_tang_t8,:a_tang_t9,:a_tang_t10,:a_tang_t11,:a_tang_t12," +
                         ":a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_DCHUYEN_BNHIEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_TD_KH_DCHUYEN_BNHIEM_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_TD_KH_DCHUYEN_BNHIEM_EXP");
    }
    public static void P_NS_TD_KH_DCHUYEN_BNHIEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_TD_KH_DCHUYEN_BNHIEM_XOA");
    }
    #endregion KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM

    #region THÔNG TIN PHÒNG BAN - ỨNG VIÊN
    public static object[] Faobj_NS_TD_INFO_DEV_LKE(string b_phong_tk, string b_cdanh_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong_tk, b_cdanh_tk, b_tu, b_den }, "NR", "PNS_NS_TD_INFO_DEV_LKE");
    }

    public static object[] Faobj_NS_TD_INFO_DEV_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_NS_TD_INFO_DEV_MA");
    }

    public static DataSet Fdt_NS_TD_INFO_DEV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_NS_TD_INFO_DEV_CT");
    }

    public static object[] Fdt_NS_TD_INFO_DEV_BY_PHONG(string b_phong_tk, string b_cdanh_tk)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_phong_tk), b_cdanh_tk }, "R", "PNS_TD_INFO_DEV_BY_PHONG");
    }

    public static void P_NS_TD_INFO_DEV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        {
            se.se_nsd b_se = new se.se_nsd();
            OracleConnection b_cnn = dbora.Fcn_KNOI();
            try
            {
                OracleCommand b_lenh = new OracleCommand();
                b_lenh.Connection = b_cnn;
                DataRow b_dr = b_dt.Rows[0];

                string b_phong = chuyen.OBJ_C(b_dr["phong"]);
                string b_cdanh = chuyen.OBJ_C(b_dr["cdanh"]);
                string b_ngay_hl = chuyen.OBJ_S(b_dr["ngay_hl"]);
                string b_luong = chuyen.OBJ_S(b_dr["luong"]);

                object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong_ct");
                object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh_ct");
                object[] a_ngay_hl = bang.Fobj_COL_MANG(b_dt_ct, "ngay_hl_ct");
                object[] a_luong = bang.Fobj_COL_MANG(b_dt_ct, "luong_ct");
                object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu_ct");

                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
                dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
                dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
                dbora.P_THEM_PAR(ref b_lenh, "a_luong", 'N', a_luong);
                dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

                string b_c = ",:so_id," + b_phong + "," + b_cdanh + "," + b_luong + "," + b_ngay_hl + ",:a_phong,:a_cdanh,:a_ngay_hl,:a_luong,:a_ghichu";

                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_INFO_DEV_NH(" + b_se.tso + b_c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                    b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
                }
                finally { b_lenh.Parameters.Clear(); }
            }
            finally { b_cnn.Close(); }
        }
    }

    public static void P_NS_TD_INFO_DEV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_TD_INFO_DEV_XOA");
    }

    public static DataTable Fdt_NS_TD_INFO_DEV_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_NS_TD_INFO_DEV_EXPORT");
    }

    #endregion THÔNG TIN PHÒNG BAN - ỨNG VIÊN

    #region KẾ HOẠCH TUYỂN DỤNG ĐIỀU CHUYỂN BỔ NHIỆM
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_TD_KH_DCBN_LKE(string b_nam_tk, string b_donvi_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_tu, b_den }, "NR", "PNS_TD_KH_DCBN_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_NS_TD_KH_DCBN_MA(string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CSO_SO(b_nam_tk), b_donvi_tk, b_trangkt }, "NNR", ""); //PNS_TD_KH_DCBN_MA
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TD_KH_DCBN_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, ""); // PNS_TD_KH_DCBN_CT
    }
    public static object[] Fdt_NS_TD_KH_DCBN_BY_PHONG(string b_nam, string b_donvi)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_donvi }, "R", ""); //PNS_TD_KH_DCBN_BY_PHONG
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TD_KH_DCBN_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            string b_nam = chuyen.OBJ_C(b_dr["nam"]);
            string b_donvi = chuyen.OBJ_C(b_dr["donvi"]);

            object[] a_ma_kh = bang.Fobj_COL_MANG(b_dt_ct, "ma_kh");
            object[] a_ban = bang.Fobj_COL_MANG(b_dt_ct, "ban");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
            object[] a_sl_cantuyen = bang.Fobj_COL_MANG(b_dt_ct, "sl_cantuyen");
            object[] a_ngaycan_ns = bang.Fobj_COL_MANG(b_dt_ct, "ngaycan_ns");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_kh", 'S', a_ma_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban", 'S', a_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'S', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_cantuyen", 'N', a_sl_cantuyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycan_ns", 'N', a_ngaycan_ns);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:so_id," + b_nam + "," + b_donvi + ",:a_ma_kh,:a_ban,:a_phong,:a_cdanh,:a_capbac,:a_sl_cantuyen,:a_ngaycan_ns,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_DCBN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_TD_KH_DCBN_EXPORT()
    {
        return dbora.Fdt_LKE(""); // PNS_TD_KH_DCBN_EXPORT
    }
    public static string Fs_NS_TD_KH_DCBN_IMP(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            int b_i = 0;
            foreach (DataRow drow in b_dt.Rows)
            {
                if (drow["MA_KH"].Equals(""))
                {
                    string b_ma_ts = ht_dungchung.Fdt_AutoGenCode("KHN", "", "MA_KH"); // NS_TD_KH_DCBN
                    int b_item = int.Parse(b_ma_ts.Substring(3, 3));
                    drow["MA_KH"] = "KHN" + string.Format("{0:000}", b_item + b_i);
                    b_i = b_i + 1;
                }
            }

            bang.P_CNG_SO(ref b_dt, "NGAYCAN_NS");
            bang.P_CSO_SO(ref b_dt, "NAM,SL_CANTUYEN");


            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_donvi = bang.Fobj_COL_MANG(b_dt, "donvi");
            object[] a_ma_kh = bang.Fobj_COL_MANG(b_dt, "ma_kh");
            object[] a_ban = bang.Fobj_COL_MANG(b_dt, "ban");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_capbac = bang.Fobj_COL_MANG(b_dt, "capbac");
            object[] a_sl_cantuyen = bang.Fobj_COL_MANG(b_dt, "sl_cantuyen");
            object[] a_ngaycan_ns = bang.Fobj_COL_MANG(b_dt, "ngaycan_ns");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");

            //dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));

            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'S', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_kh ", 'S', a_ma_kh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban ", 'S', a_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'S', a_capbac);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_cantuyen", 'N', a_sl_cantuyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycan_ns", 'N', a_ngaycan_ns);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_nam,:a_donvi,:a_ma_kh,:a_ban,:a_phong,:a_cdanh,:a_capbac,:a_sl_cantuyen,:a_ngaycan_ns,:a_ghichu";

            // b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_DCBN_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_TD_KH_DCBN, TEN_BANG.NS_TD_KH_DCBN);
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void P_NS_TD_KH_DCBN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, ""); // PNS_TD_KH_DCBN_XOA
    }
    //public static DataTable Fdt_NS_TD_LAY_DINHBIEN(string b_phong, string b_cdanh, string b_nam)
    //{
    //    return dbora.Fdt_LKE_S(new object[] { b_phong, b_cdanh, b_nam }, "PNS_TD_KH_LAY_DINHBIEN");
    //}
    //public static DataTable Fdt_MA_PHONG_EXP()
    //{
    //    return dbora.Fdt_LKE("PHT_MA_PHONG_EXP");
    //}
    //public static DataTable Fdt_MA_CDANH_EXP()
    //{
    //    return dbora.Fdt_LKE("PHT_MA_CDANH_EXP");
    //}
    //public static DataTable Fdt_MA_LVCDANH_EXP()
    //{
    //    return dbora.Fdt_LKE("PHDNS_MA_LVCDANH_EXP");
    //}
    #endregion KẾ HOẠCH TUYỂN DỤNG ĐIỀU CHUYỂN BỔ NHIỆM

    #region LÃNH ĐẠO ĐỀ XUẤT TUYỂN DỤNG
    public static DataTable Fdt_TD_KH_NAM_BYSORT(string b_nam, string b_donvi, string b_ban, string b_phong, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_donvi, b_ban, b_phong, b_cdanh }, "PNS_TD_KH_NAM_BYSORT");
    }
    public static DataTable Fdt_TD_KH_NAM_BY_ID(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_TD_KH_NAM_BY_ID");
    }
    public static DataTable Fdt_HDNS_DBIEN_BY_CDANH(string b_nam, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_cdanh }, "PNS_HDNS_DBIEN_BY_CDANH");
    }
    public static DataTable Fdt_HDNS_DBIEN_BY_PHONGBAN(string b_nam, string b_donvi, string b_ban, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_donvi, b_ban, b_phong }, "PNS_HDNS_DBIEN_BY_PHONGBAN");
    }
    public static object[] Faobj_NS_TD_DEXUAT_CN_LKE(string b_nam, string b_phong, string b_trangthaipd, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_phong, b_trangthaipd, b_tu, b_den }, "NR", "PNS_TD_DEXUAT_CN_LKE");
    }
    public static object[] Faobj_NS_TD_DEXUAT_CN_MA(string b_nam, string b_phong, string b_trangthaipd, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_phong, b_trangthaipd, b_so_id, b_trangkt }, "NNR", "PNS_TD_DEXUAT_CN_MA");
    }
    public static DataSet Fds_NS_TD_DEXUAT_CN_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_DEXUAT_CN_CT");
    }
    public static void P_NS_TD_DEXUAT_CN_GUI(ref string b_so_id, DataTable b_dt, DataTable b_dt_hd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_hd, "sott");

            object[] a_lhd = bang.Fobj_COL_MANG(b_dt_hd, "lhd");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_hd, "soluong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_lhd", 'S', a_lhd);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_dexuat"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," +
                   chuyen.OBJ_C(b_dr["ban"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["soluong_td"]) + "," +
                   chuyen.OBJ_C(b_dr["vitri_key"]) + "," + chuyen.OBJ_C(b_dr["cotheo_kh_nam"]) + "," + chuyen.OBJ_C(b_dr["kehoach_nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_can_ns"]) + "," +
                   chuyen.OBJ_S(b_dr["db_duocduyet"]) + "," + chuyen.OBJ_S(b_dr["sl_hientai"]) + "," + chuyen.OBJ_C(b_dr["lydo_tuyendung"]) + "," + chuyen.OBJ_S(b_dr["mucluong_tu"]) + "," +
                   chuyen.OBJ_S(b_dr["mucluong_den"]) + "," + chuyen.OBJ_C(b_dr["mota_cv"]) + "," + chuyen.OBJ_C(b_dr["chuyennganh_dt"]) + "," + chuyen.OBJ_C(b_dr["kinhnghiem"]) + "," +
                   chuyen.OBJ_C(b_dr["kinhnghiem_khac"]) + "," + chuyen.OBJ_C(b_dr["yeucau_kn"]) + "," + chuyen.OBJ_C(b_dr["nguoichiu_tn"]) + "," + chuyen.OBJ_C(b_dr["daduocduyet"])
                    + ",:a_sott,:a_lhd,:a_soluong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DEXUAT_CN_GUI(" + b_se.tso + b_c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_DEXUAT_CN_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_hd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_hd, "sott");

            object[] a_lhd = bang.Fobj_COL_MANG(b_dt_hd, "lhd");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_hd, "soluong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_lhd", 'S', a_lhd);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_dexuat"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," +
                   chuyen.OBJ_C(b_dr["ban"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["soluong_td"]) + "," +
                   chuyen.OBJ_C(b_dr["vitri_key"]) + "," + chuyen.OBJ_C(b_dr["cotheo_kh_nam"]) + "," + chuyen.OBJ_C(b_dr["kehoach_nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_can_ns"]) + "," +
                   chuyen.OBJ_S(b_dr["db_duocduyet"]) + "," + chuyen.OBJ_S(b_dr["sl_hientai"]) + "," + chuyen.OBJ_C(b_dr["lydo_tuyendung"]) + "," + chuyen.OBJ_S(b_dr["mucluong_tu"]) + "," +
                   chuyen.OBJ_S(b_dr["mucluong_den"]) + "," + chuyen.OBJ_C(b_dr["mota_cv"]) + "," + chuyen.OBJ_C(b_dr["chuyennganh_dt"]) + "," + chuyen.OBJ_C(b_dr["kinhnghiem"]) + "," +
                   chuyen.OBJ_C(b_dr["kinhnghiem_khac"]) + "," + chuyen.OBJ_C(b_dr["yeucau_kn"]) + "," + chuyen.OBJ_C(b_dr["nguoichiu_tn"]) + "," + chuyen.OBJ_C(b_dr["daduocduyet"])
                    + ",:a_sott,:a_lhd,:a_soluong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DEXUAT_CN_NH(" + b_se.tso + b_c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_DEXUAT_CN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TD_DEXUAT_CN_XOA");
    }
    public static DataTable Fdt_NS_TD_DEXUAT_CN_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TD_DEXUAT_CN_EXCEL");
    }
    #endregion LÃNH ĐẠO ĐỀ XUẤT TUYỂN DỤNG

    #region CBNS NHẬP ĐỀ XUẤT TUYỂN DỤNG
    public static object[] Faobj_NS_TD_DEXUAT_LKE(string b_nam, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_phong, b_tu, b_den }, "NR", "PNS_TD_DEXUAT_LKE");
    }
    public static object[] Faobj_NS_TD_DEXUAT_MA(string b_nam, string b_phong, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_phong, b_so_id, b_trangkt }, "NNR", "PNS_TD_DEXUAT_MA");
    }
    public static DataSet Fds_NS_TD_DEXUAT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_DEXUAT_CT");
    }
    public static void P_NS_TD_DEXUAT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_hd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_sott = bang.Fobj_COL_MANG(b_dt_hd, "sott");
            object[] a_lhd = bang.Fobj_COL_MANG(b_dt_hd, "lhd");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_hd, "soluong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_lhd", 'S', a_lhd);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_dexuat"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," +
                   chuyen.OBJ_C(b_dr["ban"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["phongban_ct"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_S(b_dr["soluong_td"]) + "," +
                   chuyen.OBJ_C(b_dr["vitri_key"]) + "," + chuyen.OBJ_C(b_dr["cotheo_kh_nam"]) + "," + chuyen.OBJ_C(b_dr["kehoach_nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_can_ns"]) + "," +
                   chuyen.OBJ_S(b_dr["db_duocduyet"]) + "," + chuyen.OBJ_S(b_dr["sl_hientai"]) + "," + chuyen.OBJ_C(b_dr["lydo_tuyendung"]) + "," + chuyen.OBJ_C(b_dr["loai_nv"]) + "," +
                   chuyen.OBJ_C(b_dr["trinhdo"]) + "," + chuyen.OBJ_S(b_dr["mucluong_tu"]) + "," +
                   chuyen.OBJ_S(b_dr["mucluong_den"]) + "," + chuyen.OBJ_C(b_dr["mota_cv"]) + "," + chuyen.OBJ_C(b_dr["chuyennganh_dt"]) + "," + chuyen.OBJ_C(b_dr["kinhnghiem"]) + "," +
                   chuyen.OBJ_C(b_dr["kinhnghiem_khac"]) + "," + chuyen.OBJ_C(b_dr["yeucau_kn"]) + "," + chuyen.OBJ_C(b_dr["nguoichiu_tn"]) + "," + chuyen.OBJ_C(b_dr["daduocduyet"])
                   + "," + chuyen.OBJ_C(b_dr["trangthai_pd"]) + ",:a_sott,:a_lhd,:a_soluong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DEXUAT_NH(" + b_se.tso + b_c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_DEXUAT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id) }, "PNS_TD_DEXUAT_XOA");
    }
    public static DataSet Fds_NS_TD_LKE_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 4, "PNS_TD_CV_CDANH_LKE_CT");
    }
    public static DataTable Fdt_NS_TD_DEXUAT_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TD_DEXUAT_EXCEL");
    }
    #endregion

    #region PHÊ DUYỆT ĐỀ XUẤT TUYỂN DỤNG
    public static DataTable Fdt_NS_TD_DEXUAT_PD_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_so_id) }, "PNS_TD_DEXUAT_PD_CT");
    }
    public static object[] Fdt_NS_TD_DEXUAT_PD_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_TD_DEXUAT_PD_LKE");
    }
    public static DataTable Fdt_NS_TD_DEXUAT_PD_PHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien_ld = bang.Fobj_COL_MANG(b_dt_ct, "ykien_ld");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien_ld", 'U', a_ykien_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = "," + chuyen.OBJ_C(b_dr["loai"]) + ",:a_phong,:a_so_id,:a_ma,:a_ykien_ld,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DEXUAT_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void Fdt_NS_TD_DEXUAT_PD_KOPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien_ld = bang.Fobj_COL_MANG(b_dt_ct, "ykien_ld");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien_ld);

            string b_c = ",:phong,:a_so_id,:a_ma,:a_ykien_ld";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DEXUAT_PD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion PHÊ DUYỆT ĐỀ XUẤT TUYỂN DỤNG

    #region KẾ HOẠCH TUYỂN DỤNG CHI TIẾT
    public static object[] Faobj_NS_TD_KHCT_LKE(string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma_yc, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_I(b_nam), chuyen.OBJ_I(b_thang), b_phong, b_cdanh, b_ma_yc, b_tu, b_den }, "NR", "PNS_TD_KHCT_LKE");
    }
    public static object[] Faobj_NS_TD_KHCT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TD_KHCT_MA");
    }
    public static DataSet Fds_NS_TD_KHCT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 3, "PNS_TD_KHCT_CT");
    }
    public static DataTable Fdt_NS_TD_KHCT_LAN(string b_nam, string b_phong, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_I(b_nam), b_phong, b_cdanh }, "PNS_TD_KHCT_LAN");
    }
    public static DataTable Fdt_NS_TD_KHCT_VONGTHI(string b_cdanh)
    {
        return dbora.Fdt_LKE_S(b_cdanh, "PNS_TD_KHCT_VONGTHI");
    }
    public static void P_NS_TD_KHCT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_mt, DataTable b_dt_pa)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_mt, "sott");
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_mt, "tieuchi");
            object[] a_yeucau_uv = bang.Fobj_COL_MANG(b_dt_mt, "yeucau_uv");
            object[] a_md_qt = bang.Fobj_COL_MANG(b_dt_mt, "md_qt");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'U', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_yeucau_uv", 'U', a_yeucau_uv);
            dbora.P_THEM_PAR(ref b_lenh, "a_md_qt", 'U', a_md_qt);

            object[] a_sott_pa = bang.Fobj_COL_MANG(b_dt_pa, "sott");
            object[] a_ma_pa = bang.Fobj_COL_MANG(b_dt_pa, "ma_pa");
            object[] a_ten_pa = bang.Fobj_COL_MANG(b_dt_pa, "ten_pa");
            dbora.P_THEM_PAR(ref b_lenh, "a_sott_pa", 'N', a_sott_pa);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pa", 'S', a_ma_pa);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_pa", 'U', a_ten_pa);
            // thêm con trỏ vào biến
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["MA"]) + "," + chuyen.OBJ_I(b_dr["nam"]) + "," + chuyen.OBJ_I(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["phong_yc"]) + "," + chuyen.OBJ_C(b_dr["CO_GAP"]) + "," + chuyen.OBJ_C(b_dr["CDANH"]) + "," + chuyen.OBJ_C(b_dr["so_ngay_dx"]) + ","
                + chuyen.OBJ_C(b_dr["co_kehoach_nam"]) + "," + chuyen.OBJ_C(b_dr["theo_kehoach"]) + "," + chuyen.OBJ_C(b_dr["ngay_gui_yc"]) + "," + chuyen.OBJ_N(b_dr["sl_cantuyen"]) + "," + chuyen.OBJ_N(b_dr["SL_DEXUAT_TD"]) + ","
                + chuyen.OBJ_C(b_dr["du_an"]) + "," + chuyen.OBJ_C(b_dr["loai_td"]) + "," + chuyen.OBJ_N(b_dr["luong_tu"]) + "," + chuyen.OBJ_N(b_dr["luong_den"]) + "," + chuyen.OBJ_C(b_dr["cv_toithieu"]) + "," + chuyen.OBJ_C(b_dr["diadiem_lv"]) + ","
                + chuyen.OBJ_C(b_dr["yc_khac"]) + "," + chuyen.OBJ_C(b_dr["tuoi_tu"]) + "," + chuyen.OBJ_C(b_dr["tuoi_den"]) + "," + chuyen.OBJ_C(b_dr["chieu_cao"]) + "," + chuyen.OBJ_C(b_dr["can_nang"]) + "," + chuyen.OBJ_C(b_dr["gioi_tinh"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) + ","
                + chuyen.OBJ_N(b_dr["trangthai_pd"]) + "," + chuyen.OBJ_C(b_dr["trangthai_yc_pd"]) + ","
                + chuyen.OBJ_N(b_dr["cphi_td"]) + "," + chuyen.OBJ_C(b_dr["ngay_dl_dk"]) + ","
                + chuyen.OBJ_C(b_dr["cthuc_td"]) + "," + chuyen.OBJ_C(b_dr["lydo_td"]) + ","
                + chuyen.OBJ_C(b_dr["vong1"]) + "," + chuyen.OBJ_C(b_dr["tdiem1"]) + "," + chuyen.OBJ_C(b_dr["diem_dat1"]) + "," + chuyen.OBJ_C(b_dr["canbo_pv1"]) + "," + chuyen.OBJ_C(b_dr["cdanh_cb1"]) + ","
                + chuyen.OBJ_C(b_dr["vong2"]) + "," + chuyen.OBJ_C(b_dr["tdiem2"]) + "," + chuyen.OBJ_C(b_dr["diem_dat2"]) + "," + chuyen.OBJ_C(b_dr["canbo_pv2"]) + "," + chuyen.OBJ_C(b_dr["cdanh_cb2"]) + ","
                + chuyen.OBJ_C(b_dr["vong3"]) + "," + chuyen.OBJ_C(b_dr["tdiem3"]) + "," + chuyen.OBJ_C(b_dr["diem_dat3"]) + "," + chuyen.OBJ_C(b_dr["canbo_pv3"]) + "," + chuyen.OBJ_C(b_dr["cdanh_cb3"])
                + ",:a_sott,:a_tieuchi,:a_yeucau_uv,:a_md_qt,:a_sott_pa,:a_ma_pa,:a_ten_pa";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KHCT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_KHCT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TD_KHCT_XOA");
    }
    public static void P_NS_TD_KHCT_PD(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "PNS_TD_KHCT_PD");
    }
    public static DataTable Fdt_NS_TD_KHCT_EXCEL(string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_I(b_nam), chuyen.OBJ_I(b_thang), b_phong, b_cdanh, b_ma }, "PNS_TD_KHCT_EXCEL");
    }
    #endregion KẾ HOẠCH TUYỂN DỤNG CHI TIẾT

    #region KHO ỨNG VIÊN
    public static object[] Faobj_NS_TD_UV_LKE(string so_the, string ten, string cdanh_ut, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { so_the, "N'" + ten, cdanh_ut, b_trangthai, b_tu, b_den }, "NR", "PNS_TD_UV_LKE");
    }
    public static object[] Faobj_NS_TD_UV_MA(string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_trangkt }, "NNR", "PNS_TD_UV_MA");
    }
    public static DataSet Fds_NS_TD_UV_CT(string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_so_the }, 7, "PNS_TD_UV_CT");
    }
    public static string Fs_TD_UV_NH(DataTable b_dt, DataTable b_dt_td, DataTable b_dt_nn, DataTable b_dt_cc, DataTable b_dt_ct, DataTable b_dt_nt, DataTable b_dt_ttk)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["SO_THE"].ToString(), "NS_TD_UV_CV", "SO_THE");
            if (b_kiemtra == false)
            {
                b_dr["SO_THE"] = ht_dungchung.Fdt_AutoGenCode("UV", "NS_TD_UV_CV", "SO_THE");
            }
            object[] a_tentruong = bang.Fobj_COL_MANG(b_dt_td, "tentruong");
            object[] a_chuyennganh = bang.Fobj_COL_MANG(b_dt_td, "chuyennganh");
            object[] a_tunam = bang.Fobj_COL_MANG(b_dt_td, "tunam");
            object[] a_dennam = bang.Fobj_COL_MANG(b_dt_td, "dennam");
            object[] a_trinhdo = bang.Fobj_COL_MANG(b_dt_td, "trinhdo");
            object[] a_hinhthuc_dt = bang.Fobj_COL_MANG(b_dt_td, "hinhthuc_dt");
            object[] a_loai_totnghiep = bang.Fobj_COL_MANG(b_dt_td, "loai_totnghiep");

            object[] a_ten_ngoaingu = bang.Fobj_COL_MANG(b_dt_nn, "ten_ngoaingu");
            object[] a_chungchi_nn = bang.Fobj_COL_MANG(b_dt_nn, "chungchi_nn");
            object[] a_namcap = bang.Fobj_COL_MANG(b_dt_nn, "namcap");
            object[] a_noicap = bang.Fobj_COL_MANG(b_dt_nn, "noicap");
            object[] a_diem_nn = bang.Fobj_COL_MANG(b_dt_nn, "diem_nn");
            object[] a_xeploai_nn = bang.Fobj_COL_MANG(b_dt_nn, "xeploai_nn");

            object[] a_tenchungchi = bang.Fobj_COL_MANG(b_dt_cc, "tenchungchi");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_cc, "noidung");
            object[] a_sohieu = bang.Fobj_COL_MANG(b_dt_cc, "sohieu");
            object[] a_coso_daotao = bang.Fobj_COL_MANG(b_dt_cc, "coso_daotao");
            object[] a_tungay = bang.Fobj_COL_MANG(b_dt_cc, "tungay");
            object[] a_denngay = bang.Fobj_COL_MANG(b_dt_cc, "denngay");
            object[] a_ngay_hl = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hl");
            object[] a_ngay_hhl = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hhl");

            object[] a_tencty = bang.Fobj_COL_MANG(b_dt_ct, "tencty");
            object[] a_chucdanh = bang.Fobj_COL_MANG(b_dt_ct, "chucdanh");
            object[] a_nhiemvu = bang.Fobj_COL_MANG(b_dt_ct, "nhiemvu");
            object[] a_tuthang = bang.Fobj_COL_MANG(b_dt_ct, "tuthang");
            object[] a_denthang = bang.Fobj_COL_MANG(b_dt_ct, "denthang");
            object[] a_lydo_nghiviec = bang.Fobj_COL_MANG(b_dt_ct, "lydo_nghiviec");

            object[] a_hoten = bang.Fobj_COL_MANG(b_dt_nt, "hoten");
            object[] a_quanhe = bang.Fobj_COL_MANG(b_dt_nt, "quanhe");
            object[] a_ngaysinh = bang.Fobj_COL_MANG(b_dt_nt, "ngaysinh");
            object[] a_nghenghiep = bang.Fobj_COL_MANG(b_dt_nt, "nghenghiep");
            object[] a_noi_ct = bang.Fobj_COL_MANG(b_dt_nt, "noi_ct");

            object[] a_hoten_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "hoten");
            object[] a_congty_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "congty");
            object[] a_cdanh_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "chucdanh");
            object[] a_quanhe_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "quanhe");
            object[] a_sodt_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "sodt");
            object[] a_email_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "email");

            dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));

            dbora.P_THEM_PAR(ref b_lenh, "a_tentruong", 'U', a_tentruong);
            dbora.P_THEM_PAR(ref b_lenh, "a_chuyennganh", 'S', a_chuyennganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tunam", 'N', a_tunam);
            dbora.P_THEM_PAR(ref b_lenh, "a_dennam", 'N', a_dennam);
            dbora.P_THEM_PAR(ref b_lenh, "a_trinhdo", 'U', a_trinhdo);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc_dt", 'S', a_hinhthuc_dt);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_totnghiep", 'U', a_loai_totnghiep);

            dbora.P_THEM_PAR(ref b_lenh, "a_ten_ngoaingu", 'U', a_ten_ngoaingu);
            dbora.P_THEM_PAR(ref b_lenh, "a_chungchi_nn", 'U', a_chungchi_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_namcap", 'N', a_namcap);
            dbora.P_THEM_PAR(ref b_lenh, "a_noicap", 'U', a_noicap);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_nn", 'S', a_diem_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_nn", 'U', a_xeploai_nn);

            dbora.P_THEM_PAR(ref b_lenh, "a_tenchungchi", 'U', a_tenchungchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_sohieu", 'S', a_sohieu);
            dbora.P_THEM_PAR(ref b_lenh, "a_coso_daotao", 'U', a_coso_daotao);
            dbora.P_THEM_PAR(ref b_lenh, "a_tungay", 'N', a_tungay);
            dbora.P_THEM_PAR(ref b_lenh, "a_denngay", 'N', a_denngay);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hhl", 'N', a_ngay_hhl);

            dbora.P_THEM_PAR(ref b_lenh, "a_tencty", 'U', a_tencty);
            dbora.P_THEM_PAR(ref b_lenh, "a_chucdanh", 'U', a_chucdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhiemvu", 'U', a_nhiemvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang", 'N', a_tuthang);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang", 'N', a_denthang);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_nghiviec", 'U', a_lydo_nghiviec);

            dbora.P_THEM_PAR(ref b_lenh, "a_hoten", 'U', a_hoten);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhe", 'S', a_quanhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh", 'N', a_ngaysinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghenghiep", 'U', a_nghenghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_ct", 'U', a_noi_ct);

            dbora.P_THEM_PAR(ref b_lenh, "a_hoten_ttk", 'U', a_hoten_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_congty_ttk", 'U', a_congty_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_ttk", 'U', a_cdanh_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhe_ttk", 'U', a_quanhe_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodt_ttk", 'S', a_sodt_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_email_ttk", 'S', a_email_ttk);

            string b_c = ",:so_the" + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["cdanh_ut"]) + "," + chuyen.OBJ_C(b_dr["nganhnghe_ht"]) + "," +
                chuyen.OBJ_C(b_dr["capbac_ht"]) + "," + chuyen.OBJ_C("") + "," + chuyen.OBJ_C(b_dr["noilamviec_mm"]) + "," + chuyen.OBJ_S(b_dr["mucluong_mm"]) + "," + chuyen.OBJ_C(b_dr["gioitinh"]) + "," + chuyen.OBJ_S(b_dr["ngaysinh"]) + "," + chuyen.OBJ_C(b_dr["noisinh"]) + "," +
                chuyen.OBJ_C(b_dr["tt_noisinh"]) + "," + chuyen.OBJ_C(b_dr["qh_noisinh"]) + "," + chuyen.OBJ_C(b_dr["xp_noisinh"]) + "," + chuyen.OBJ_C(b_dr["so_cmt"]) + "," +
                chuyen.OBJ_S(b_dr["ngaycap_cmt"]) + "," + chuyen.OBJ_C(b_dr["noicap_cmt"]) + "," + chuyen.OBJ_C(b_dr["so_hochieu"]) + "," +
                chuyen.OBJ_S(b_dr["ngaycap_hochieu"]) + "," + chuyen.OBJ_C(b_dr["noicap_hochieu"]) + "," + chuyen.OBJ_C(b_dr["tamtru"]) + "," + chuyen.OBJ_C(b_dr["tt_tamtru"]) + "," +
                chuyen.OBJ_C(b_dr["qh_tamtru"]) + "," + chuyen.OBJ_C(b_dr["xp_tamtru"]) + "," + chuyen.OBJ_C(b_dr["thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_thuongtru"]) + "," +
                chuyen.OBJ_C(b_dr["qh_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["xp_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_honnhan"]) + "," + chuyen.OBJ_C(b_dr["sodt_nr"]) + "," +
                chuyen.OBJ_C(b_dr["sodt_dd"]) + "," + chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["chieucao"]) + "," + chuyen.OBJ_C(b_dr["cannang"]) + "," + chuyen.OBJ_C(b_dr["dantoc"]) + "," +
                chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["trangthai_uv_theoyc"]) + "," + chuyen.OBJ_C(b_dr["nguoithan_lvttd_co"]) + "," + chuyen.OBJ_C(b_dr["nguoithan_lvttd_ko"]) + "," +
                chuyen.OBJ_C(b_dr["nguoithan_lvttd_thongtin"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_co"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_ko"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_lvttd_vitri"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_bophan"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_tbp"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_lvttd_cty"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_tglv"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_lydo_nv"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_ut_co"]) + "," + chuyen.OBJ_C(b_dr["banthan_ut_ko"]) + "," + chuyen.OBJ_C(b_dr["banthan_ut_thongtin"]) + "," + chuyen.OBJ_C(b_dr["lienhe_hoten"]) + "," +
                chuyen.OBJ_C(b_dr["lienhe_mqh"]) + "," + chuyen.OBJ_C(b_dr["lienhe_sdt"]) + "," + chuyen.OBJ_C(b_dr["lienhe_diachi"]) + "," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," +
                chuyen.OBJ_C(b_dr["kh_phattrien_sn"]) + "," + chuyen.OBJ_C(b_dr["cac_thanhtich"]);

            b_c = b_c + ",:a_tentruong,:a_chuyennganh,:a_tunam,:a_dennam,:a_trinhdo,:a_hinhthuc_dt,:a_loai_totnghiep";
            b_c = b_c + ",:a_ten_ngoaingu,:a_chungchi_nn,:a_namcap,:a_noicap,:a_diem_nn,:a_xeploai_nn";
            b_c = b_c + ",:a_tenchungchi,:a_noidung,:a_sohieu,:a_coso_daotao,:a_tungay,:a_denngay,:a_ngay_hl,:a_ngay_hhl";
            b_c = b_c + ",:a_tencty,:a_chucdanh,:a_nhiemvu,:a_tuthang,:a_denthang,:a_lydo_nghiviec";
            b_c = b_c + ",:a_hoten,:a_quanhe,:a_ngaysinh,:a_nghenghiep,:a_noi_ct";
            b_c = b_c + ",:a_hoten_ttk,:a_congty_ttk,:a_cdanh_ttk,:a_quanhe_ttk,:a_sodt_ttk,:a_email_ttk";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_UV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["so_the"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string Fs_TD_UV_IMP(DataTable b_dt, DataTable b_dt_td, DataTable b_dt_cc, DataTable b_dt_ct, DataTable b_dt_nt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            // mặc định trạng thái nhân viên là "CXL"
            bang.P_THEM_COL(ref b_dt, "TRANGTHAI", "CXL");
            bang.P_THEM_COL(ref b_dt, "MA_YEUCAU", "");
            if (b_dt_td.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_td, new object[] { "", "", "", "", "", "", "0" }); }
            if (b_dt_cc.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_cc, new object[] { "", "", "", "", "", "", "", "0" }); }
            if (b_dt_ct.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "", "", "", "0" }); }
            if (b_dt_nt.Rows.Count <= 0) { bang.P_THEM_HANG(ref b_dt_nt, new object[] { "", "", "", "", "", "", "", "0" }); }


            bang.P_CNG_SO(ref b_dt, "ngaysinh,ngaycap_cmt");
            bang.P_CSO_SO(ref b_dt, "mucluong_mm");

            bang.P_CSO_SO(ref b_dt_td, "tunam_td,dennam_td");

            bang.P_CNG_SO(ref b_dt_cc, "tungay_cc,denngay_cc,ngay_hl_cc,ngay_hhl_cc");

            bang.P_CTH_SO(ref b_dt_ct, "tuthang_ct,denthang_ct");

            bang.P_CNG_SO(ref b_dt_nt, "ngaysinh_tn");

            object[] a_key_tt = bang.Fobj_COL_MANG(b_dt, "key");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_mucluong_mm = bang.Fobj_COL_MANG(b_dt, "mucluong_mm");
            object[] a_gioitinh = bang.Fobj_COL_MANG(b_dt, "gioitinh");
            object[] a_ngaysinh = bang.Fobj_COL_MANG(b_dt, "ngaysinh");
            object[] a_noisinh = bang.Fobj_COL_MANG(b_dt, "noisinh");
            object[] a_tt_noisinh = bang.Fobj_COL_MANG(b_dt, "tt_noisinh");
            object[] a_qh_noisinh = bang.Fobj_COL_MANG(b_dt, "qh_noisinh");
            object[] a_xp_noisinh = bang.Fobj_COL_MANG(b_dt, "xp_noisinh");
            object[] a_so_cmt = bang.Fobj_COL_MANG(b_dt, "so_cmt");
            object[] a_ngaycap_cmt = bang.Fobj_COL_MANG(b_dt, "ngaycap_cmt");
            object[] a_noicap_cmt = bang.Fobj_COL_MANG(b_dt, "noicap_cmt");
            object[] a_tamtru = bang.Fobj_COL_MANG(b_dt, "tamtru");
            object[] a_tt_tamtru = bang.Fobj_COL_MANG(b_dt, "tt_tamtru");
            object[] a_qh_tamtru = bang.Fobj_COL_MANG(b_dt, "qh_tamtru");
            object[] a_xp_tamtru = bang.Fobj_COL_MANG(b_dt, "xp_tamtru");
            object[] a_thuongtru = bang.Fobj_COL_MANG(b_dt, "thuongtru");
            object[] a_tt_thuongtru = bang.Fobj_COL_MANG(b_dt, "tt_thuongtru");
            object[] a_qh_thuongtru = bang.Fobj_COL_MANG(b_dt, "qh_thuongtru");
            object[] a_xp_thuongtru = bang.Fobj_COL_MANG(b_dt, "xp_thuongtru");
            object[] a_tt_honnhan = bang.Fobj_COL_MANG(b_dt, "tt_honnhan");
            object[] a_sodt_nr = bang.Fobj_COL_MANG(b_dt, "sodt_nr");
            object[] a_sodt_dd = bang.Fobj_COL_MANG(b_dt, "sodt_dd");
            object[] a_email = bang.Fobj_COL_MANG(b_dt, "email");
            object[] a_chieucao = bang.Fobj_COL_MANG(b_dt, "chieucao");
            object[] a_cannang = bang.Fobj_COL_MANG(b_dt, "cannang");
            object[] a_dantoc = bang.Fobj_COL_MANG(b_dt, "dantoc");
            object[] a_tongiao = bang.Fobj_COL_MANG(b_dt, "tongiao");
            object[] a_nguoithan_lvttd_co = bang.Fobj_COL_MANG(b_dt, "nguoithan_lvttd_co");
            object[] a_nguoithan_lvttd_ko = bang.Fobj_COL_MANG(b_dt, "nguoithan_lvttd_ko");
            object[] a_nguoithan_lvttd_thongtin = bang.Fobj_COL_MANG(b_dt, "nguoithan_lvttd_thongtin");
            object[] a_banthan_lvttd_co = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_co");
            object[] a_banthan_lvttd_ko = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_ko");
            object[] a_banthan_lvttd_vitri = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_vitri");
            object[] a_banthan_lvttd_bophan = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_bophan");
            object[] a_banthan_lvttd_tbp = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_tbp");
            object[] a_banthan_lvttd_cty = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_cty");
            object[] a_banthan_lvttd_tglv = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_tglv");
            object[] a_banthan_lvttd_lydo_nv = bang.Fobj_COL_MANG(b_dt, "banthan_lvttd_lydo_nv");
            object[] a_banthan_ut_co = bang.Fobj_COL_MANG(b_dt, "banthan_ut_co");
            object[] a_banthan_ut_ko = bang.Fobj_COL_MANG(b_dt, "banthan_ut_ko");
            object[] a_banthan_ut_thongtin = bang.Fobj_COL_MANG(b_dt, "banthan_ut_thongtin");
            object[] a_lienhe_hoten = bang.Fobj_COL_MANG(b_dt, "lienhe_hoten");
            object[] a_lienhe_mqh = bang.Fobj_COL_MANG(b_dt, "lienhe_mqh");
            object[] a_lienhe_sdt = bang.Fobj_COL_MANG(b_dt, "lienhe_sdt");
            object[] a_lienhe_diachi = bang.Fobj_COL_MANG(b_dt, "lienhe_diachi");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt, "trangthai");
            object[] a_ma_yeucau = bang.Fobj_COL_MANG(b_dt, "ma_yeucau");

            object[] a_key_td = bang.Fobj_COL_MANG(b_dt_td, "key");
            object[] a_tentruong_td = bang.Fobj_COL_MANG(b_dt_td, "tentruong_td");
            object[] a_chuyennganh_td = bang.Fobj_COL_MANG(b_dt_td, "chuyennganh_td");
            object[] a_tunam_td = bang.Fobj_COL_MANG(b_dt_td, "tunam_td");
            object[] a_dennam_td = bang.Fobj_COL_MANG(b_dt_td, "dennam_td");
            object[] a_trinhdo_td = bang.Fobj_COL_MANG(b_dt_td, "trinhdo_td");
            object[] a_hinhthuc_dt_td = bang.Fobj_COL_MANG(b_dt_td, "hinhthuc_dt_td");
            object[] a_loai_totnghiep_td = bang.Fobj_COL_MANG(b_dt_td, "loai_totnghiep_td");

            object[] a_key_cc = bang.Fobj_COL_MANG(b_dt_ct, "key");
            object[] a_tenchungchi_cc = bang.Fobj_COL_MANG(b_dt_cc, "tenchungchi_cc");
            object[] a_noidung_cc = bang.Fobj_COL_MANG(b_dt_cc, "noidung_cc");
            object[] a_sohieu_cc = bang.Fobj_COL_MANG(b_dt_cc, "sohieu_cc");
            object[] a_coso_daotao_cc = bang.Fobj_COL_MANG(b_dt_cc, "coso_daotao_cc");
            object[] a_tungay_cc = bang.Fobj_COL_MANG(b_dt_cc, "tungay_cc");
            object[] a_denngay_cc = bang.Fobj_COL_MANG(b_dt_cc, "denngay_cc");
            object[] a_ngay_hl_cc = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hl_cc");
            object[] a_ngay_hhl_cc = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hhl_cc");

            object[] a_key_ct = bang.Fobj_COL_MANG(b_dt_ct, "key");
            object[] a_tencty_ct = bang.Fobj_COL_MANG(b_dt_ct, "tencty_ct");
            object[] a_tuthang_ct = bang.Fobj_COL_MANG(b_dt_ct, "tuthang_ct");
            object[] a_denthang_ct = bang.Fobj_COL_MANG(b_dt_ct, "denthang_ct");
            object[] a_chucdanh_ct = bang.Fobj_COL_MANG(b_dt_ct, "chucdanh_ct");
            object[] a_lydo_nghiviec_ct = bang.Fobj_COL_MANG(b_dt_ct, "lydo_nghiviec_ct");

            object[] a_key_tn = bang.Fobj_COL_MANG(b_dt_nt, "key");
            object[] a_hoten_tn = bang.Fobj_COL_MANG(b_dt_nt, "hoten_tn");
            object[] a_quanhe_tn = bang.Fobj_COL_MANG(b_dt_nt, "quanhe_tn");
            object[] a_ngaysinh_tn = bang.Fobj_COL_MANG(b_dt_nt, "ngaysinh_tn");
            object[] a_nghenghiep_tn = bang.Fobj_COL_MANG(b_dt_nt, "nghenghiep_tn");
            object[] a_noi_ct_tn = bang.Fobj_COL_MANG(b_dt_nt, "noi_ct_tn");


            //dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));

            dbora.P_THEM_PAR(ref b_lenh, "a_key_tt", 'N', a_key_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucluong_mm ", 'N', a_mucluong_mm);
            dbora.P_THEM_PAR(ref b_lenh, "a_gioitinh", 'S', a_gioitinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh", 'N', a_ngaysinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_noisinh", 'U', a_noisinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_noisinh", 'S', a_tt_noisinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_noisinh", 'S', a_qh_noisinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_noisinh", 'S', a_xp_noisinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_cmt", 'S', a_so_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaycap_cmt", 'N', a_ngaycap_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_noicap_cmt", 'U', a_noicap_cmt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tamtru", 'U', a_tamtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_tamtru", 'S', a_tt_tamtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_tamtru", 'S', a_qh_tamtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_tamtru", 'S', a_xp_tamtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_thuongtru", 'U', a_thuongtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_thuongtru", 'S', a_tt_thuongtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_qh_thuongtru", 'S', a_qh_thuongtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_xp_thuongtru", 'S', a_xp_thuongtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt_honnhan", 'S', a_tt_honnhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodt_nr", 'S', a_sodt_nr);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodt_dd", 'S', a_sodt_dd);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_chieucao", 'S', a_chieucao);
            dbora.P_THEM_PAR(ref b_lenh, "a_cannang", 'S', a_cannang);
            dbora.P_THEM_PAR(ref b_lenh, "a_dantoc", 'S', a_dantoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongiao", 'S', a_tongiao);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoithan_lvttd_co", 'S', a_nguoithan_lvttd_co);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoithan_lvttd_ko", 'S', a_nguoithan_lvttd_ko);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoithan_lvttd_thongtin", 'U', a_nguoithan_lvttd_thongtin);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_co", 'S', a_banthan_lvttd_co);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_ko", 'S', a_banthan_lvttd_ko);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_vitri", 'U', a_banthan_lvttd_vitri);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_bophan", 'U', a_banthan_lvttd_bophan);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_tbp", 'U', a_banthan_lvttd_tbp);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_cty", 'U', a_banthan_lvttd_cty);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_tglv", 'U', a_banthan_lvttd_tglv);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_lvttd_lydo_nv", 'U', a_banthan_lvttd_lydo_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_ut_co", 'S', a_banthan_ut_co);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_ut_ko", 'S', a_banthan_ut_ko);
            dbora.P_THEM_PAR(ref b_lenh, "a_banthan_ut_thongtin", 'U', a_banthan_ut_thongtin);
            dbora.P_THEM_PAR(ref b_lenh, "a_lienhe_hoten", 'U', a_lienhe_hoten);
            dbora.P_THEM_PAR(ref b_lenh, "a_lienhe_mqh", 'U', a_lienhe_mqh);
            dbora.P_THEM_PAR(ref b_lenh, "a_lienhe_sdt", 'S', a_lienhe_sdt);
            dbora.P_THEM_PAR(ref b_lenh, "a_lienhe_diachi", 'U', a_lienhe_diachi);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_yeucau", 'S', a_ma_yeucau);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_td", 'N', a_key_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_tentruong_td", 'U', a_tentruong_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_chuyennganh_td", 'S', a_chuyennganh_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_tunam_td", 'N', a_tunam_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_dennam_td", 'N', a_dennam_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_trinhdo_td", 'S', a_trinhdo_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc_dt_td", 'S', a_hinhthuc_dt_td);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_totnghiep_td", 'U', a_loai_totnghiep_td);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_cc", 'N', a_key_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tenchungchi_cc", 'U', a_tenchungchi_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung_cc", 'U', a_noidung_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_sohieu_cc", 'S', a_sohieu_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_coso_daotao_cc", 'U', a_coso_daotao_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tungay_cc", 'N', a_tungay_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_denngay_cc", 'N', a_denngay_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl_cc", 'N', a_ngay_hl_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hhl_cc", 'N', a_ngay_hhl_cc);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_ct", 'N', a_key_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_tencty_ct", 'U', a_tencty_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang_ct", 'N', a_tuthang_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang_ct", 'N', a_denthang_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_chucdanh_ct", 'U', a_chucdanh_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_nghiviec_ct", 'U', a_lydo_nghiviec_ct);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_tn", 'N', a_key_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_hoten_tn", 'U', a_hoten_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhe_tn", 'S', a_quanhe_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh_tn", 'N', a_ngaysinh_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghenghiep_tn", 'U', a_nghenghiep_tn);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_ct_tn", 'U', a_noi_ct_tn);

            string b_c = ",:a_key_tt,:a_ten,:a_mucluong_mm,:a_gioitinh,:a_ngaysinh,:a_noisinh,:a_tt_noisinh,:a_qh_noisinh,:a_xp_noisinh,:a_so_cmt,:a_ngaycap_cmt,:a_noicap_cmt,:a_tamtru,:a_tt_tamtru,:a_qh_tamtru,:a_xp_tamtru,:a_thuongtru,:a_tt_thuongtru,:a_qh_thuongtru,:a_xp_thuongtru,:a_tt_honnhan,:a_sodt_nr,:a_sodt_dd,:a_email,:a_chieucao,:a_cannang,:a_dantoc,:a_tongiao,:a_nguoithan_lvttd_co,:a_nguoithan_lvttd_ko,:a_nguoithan_lvttd_thongtin,:a_banthan_lvttd_co,:a_banthan_lvttd_ko,:a_banthan_lvttd_vitri,:a_banthan_lvttd_bophan,:a_banthan_lvttd_tbp,:a_banthan_lvttd_cty,:a_banthan_lvttd_tglv,:a_banthan_lvttd_lydo_nv,:a_banthan_ut_co,:a_banthan_ut_ko,:a_banthan_ut_thongtin,:a_lienhe_hoten,:a_lienhe_mqh,:a_lienhe_sdt,:a_lienhe_diachi,:a_trangthai,:a_ma_yeucau";
            b_c = b_c + ",:a_key_td,:a_tentruong_td,:a_chuyennganh_td,:a_tunam_td,:a_dennam_td,:a_trinhdo_td,:a_hinhthuc_dt_td,:a_loai_totnghiep_td";
            b_c = b_c + ",:a_key_cc,:a_tenchungchi_cc,:a_noidung_cc,:a_sohieu_cc,:a_coso_daotao_cc,:a_tungay_cc,:a_denngay_cc,:a_ngay_hl_cc,:a_ngay_hhl_cc";
            b_c = b_c + ",:a_key_ct,:a_tencty_ct,:a_tuthang_ct,:a_denthang_ct,:a_chucdanh_ct,:a_lydo_nghiviec_ct";
            b_c = b_c + ",:a_key_tn,:a_hoten_tn,:a_quanhe_tn,:a_ngaysinh_tn,:a_nghenghiep_tn,:a_noi_ct_tn";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_UV_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_UV_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_TD_UV_XOA");
    }
    public static DataTable Fdt_NS_TD_UV_EXCEL()
    {
        return dbora.Fdt_LKE("Fdt_NS_TD_UV_EXCEL");
    }
    #endregion

    #region GÁN ỨNG VIÊN VÀO YÊU CẦU TUYỂN DỤNG
    public static DataTable Fdt_NS_TD_DEXUAT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_TD_DEXUAT_DR");
    }
    public static DataTable Fdt_NS_TD_DEXUAT_LKE_BY_NAM(string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam) }, "PNS_TD_DEXUAT_BY_NAM");
    }
    public static DataTable Fdt_NS_TD_DEXUAT_TT(string b_nam, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_ma }, "PNS_TD_DEXUAT_TT");
    }
    public static object[] Faobj_NS_TD_GAN_UV_LKE(string b_ma_dx, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_dx, b_trangthai, b_tu, b_den }, "NR", "PNS_TD_GAN_UV_LKE");
    }
    public static object[] Faobj_NS_TD_GAN_UV_MA(string b_so_the, string b_ma_dx, string b_trangthai, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_ma_dx, b_trangthai, b_trangkt }, "NNR", "PNS_TD_GAN_UV_MA");
    }
    public static DataSet Fds_NS_TD_GAN_UV_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 7, "PNS_TD_GAN_UV_CT");
    }
    public static string PNS_TD_GAN_UV_NH(DataTable b_dt, DataTable b_dt_td, DataTable b_dt_nn, DataTable b_dt_cc, DataTable b_dt_ct, DataTable b_dt_nt, DataTable b_dt_ttk)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            bool b_kiemtra = ht_dungchung.Fdt_kiemtra_tontai(b_dr["SO_THE"].ToString(), "NS_TD_UV_CV", "SO_THE");
            if (b_kiemtra == false)
            {
                b_dr["SO_THE"] = ht_dungchung.Fdt_AutoGenCode("UV", "NS_TD_UV_CV", "SO_THE");
            }
            object[] a_tentruong = bang.Fobj_COL_MANG(b_dt_td, "tentruong");
            object[] a_chuyennganh = bang.Fobj_COL_MANG(b_dt_td, "chuyennganh");
            object[] a_tunam = bang.Fobj_COL_MANG(b_dt_td, "tunam");
            object[] a_dennam = bang.Fobj_COL_MANG(b_dt_td, "dennam");
            object[] a_trinhdo = bang.Fobj_COL_MANG(b_dt_td, "trinhdo");
            object[] a_hinhthuc_dt = bang.Fobj_COL_MANG(b_dt_td, "hinhthuc_dt");
            object[] a_loai_totnghiep = bang.Fobj_COL_MANG(b_dt_td, "loai_totnghiep");

            object[] a_ten_ngoaingu = bang.Fobj_COL_MANG(b_dt_nn, "ten_ngoaingu");
            object[] a_chungchi_nn = bang.Fobj_COL_MANG(b_dt_nn, "chungchi_nn");
            object[] a_namcap = bang.Fobj_COL_MANG(b_dt_nn, "namcap");
            object[] a_noicap = bang.Fobj_COL_MANG(b_dt_nn, "noicap");
            object[] a_diem_nn = bang.Fobj_COL_MANG(b_dt_nn, "diem_nn");
            object[] a_xeploai_nn = bang.Fobj_COL_MANG(b_dt_nn, "xeploai_nn");

            object[] a_tenchungchi = bang.Fobj_COL_MANG(b_dt_cc, "tenchungchi");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_cc, "noidung");
            object[] a_sohieu = bang.Fobj_COL_MANG(b_dt_cc, "sohieu");
            object[] a_coso_daotao = bang.Fobj_COL_MANG(b_dt_cc, "coso_daotao");
            object[] a_tungay = bang.Fobj_COL_MANG(b_dt_cc, "tungay");
            object[] a_denngay = bang.Fobj_COL_MANG(b_dt_cc, "denngay");
            object[] a_ngay_hl = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hl");
            object[] a_ngay_hhl = bang.Fobj_COL_MANG(b_dt_cc, "ngay_hhl");

            object[] a_tencty = bang.Fobj_COL_MANG(b_dt_ct, "tencty");
            object[] a_chucdanh = bang.Fobj_COL_MANG(b_dt_ct, "chucdanh");
            object[] a_nhiemvu = bang.Fobj_COL_MANG(b_dt_ct, "nhiemvu");
            object[] a_tuthang = bang.Fobj_COL_MANG(b_dt_ct, "tuthang");
            object[] a_denthang = bang.Fobj_COL_MANG(b_dt_ct, "denthang");
            object[] a_lydo_nghiviec = bang.Fobj_COL_MANG(b_dt_ct, "lydo_nghiviec");

            object[] a_hoten = bang.Fobj_COL_MANG(b_dt_nt, "hoten");
            object[] a_quanhe = bang.Fobj_COL_MANG(b_dt_nt, "quanhe");
            object[] a_ngaysinh = bang.Fobj_COL_MANG(b_dt_nt, "ngaysinh");
            object[] a_nghenghiep = bang.Fobj_COL_MANG(b_dt_nt, "nghenghiep");
            object[] a_noi_ct = bang.Fobj_COL_MANG(b_dt_nt, "noi_ct");

            object[] a_hoten_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "hoten");
            object[] a_congty_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "congty");
            object[] a_cdanh_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "chucdanh");
            object[] a_quanhe_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "quanhe");
            object[] a_sodt_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "sodt");
            object[] a_email_ttk = bang.Fobj_COL_MANG(b_dt_ttk, "email");

            dbora.P_THEM_PAR(ref b_lenh, "so_the", 'S', 'O', chuyen.OBJ_S(b_dr["so_the"]));

            dbora.P_THEM_PAR(ref b_lenh, "a_tentruong", 'U', a_tentruong);
            dbora.P_THEM_PAR(ref b_lenh, "a_chuyennganh", 'S', a_chuyennganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tunam", 'N', a_tunam);
            dbora.P_THEM_PAR(ref b_lenh, "a_dennam", 'N', a_dennam);
            dbora.P_THEM_PAR(ref b_lenh, "a_trinhdo", 'U', a_trinhdo);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc_dt", 'S', a_hinhthuc_dt);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_totnghiep", 'U', a_loai_totnghiep);

            dbora.P_THEM_PAR(ref b_lenh, "a_ten_ngoaingu", 'U', a_ten_ngoaingu);
            dbora.P_THEM_PAR(ref b_lenh, "a_chungchi_nn", 'U', a_chungchi_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_namcap", 'N', a_namcap);
            dbora.P_THEM_PAR(ref b_lenh, "a_noicap", 'U', a_noicap);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_nn", 'S', a_diem_nn);
            dbora.P_THEM_PAR(ref b_lenh, "a_xeploai_nn", 'U', a_xeploai_nn);

            dbora.P_THEM_PAR(ref b_lenh, "a_tenchungchi", 'U', a_tenchungchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_sohieu", 'S', a_sohieu);
            dbora.P_THEM_PAR(ref b_lenh, "a_coso_daotao", 'U', a_coso_daotao);
            dbora.P_THEM_PAR(ref b_lenh, "a_tungay", 'N', a_tungay);
            dbora.P_THEM_PAR(ref b_lenh, "a_denngay", 'N', a_denngay);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hhl", 'N', a_ngay_hhl);

            dbora.P_THEM_PAR(ref b_lenh, "a_tencty", 'U', a_tencty);
            dbora.P_THEM_PAR(ref b_lenh, "a_chucdanh", 'U', a_chucdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhiemvu", 'U', a_nhiemvu);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang", 'N', a_tuthang);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang", 'N', a_denthang);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_nghiviec", 'U', a_lydo_nghiviec);

            dbora.P_THEM_PAR(ref b_lenh, "a_hoten", 'U', a_hoten);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhe", 'S', a_quanhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaysinh", 'N', a_ngaysinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghenghiep", 'U', a_nghenghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_ct", 'U', a_noi_ct);

            dbora.P_THEM_PAR(ref b_lenh, "a_hoten_ttk", 'U', a_hoten_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_congty_ttk", 'U', a_congty_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_ttk", 'U', a_cdanh_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_quanhe_ttk", 'U', a_quanhe_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodt_ttk", 'S', a_sodt_ttk);
            dbora.P_THEM_PAR(ref b_lenh, "a_email_ttk", 'S', a_email_ttk);



            string b_c = ",:so_the" + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C("") + "," + chuyen.OBJ_C(b_dr["nganhnghe_ht"]) + "," +
                chuyen.OBJ_C(b_dr["capbac_ht"]) + "," + chuyen.OBJ_C(b_dr["nganhnghe_qt"]) + "," + chuyen.OBJ_C(b_dr["noilamviec_mm"]) + "," + chuyen.OBJ_S(b_dr["mucluong_mm"]) + "," + chuyen.OBJ_C(b_dr["gioitinh"]) + "," + chuyen.OBJ_S(b_dr["ngaysinh"]) + "," + chuyen.OBJ_C(b_dr["noisinh"]) + "," +
                chuyen.OBJ_C(b_dr["tt_noisinh"]) + "," + chuyen.OBJ_C(b_dr["qh_noisinh"]) + "," + chuyen.OBJ_C(b_dr["xp_noisinh"]) + "," + chuyen.OBJ_C(b_dr["so_cmt"]) + "," +
                chuyen.OBJ_S(b_dr["ngaycap_cmt"]) + "," + chuyen.OBJ_C(b_dr["noicap_cmt"]) + "," + chuyen.OBJ_C(b_dr["so_hochieu"]) + "," +
                chuyen.OBJ_S(b_dr["ngaycap_hochieu"]) + "," + chuyen.OBJ_C(b_dr["noicap_hochieu"]) + "," + chuyen.OBJ_C(b_dr["tamtru"]) + "," + chuyen.OBJ_C(b_dr["tt_tamtru"]) + "," +
                chuyen.OBJ_C(b_dr["qh_tamtru"]) + "," + chuyen.OBJ_C(b_dr["xp_tamtru"]) + "," + chuyen.OBJ_C(b_dr["thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_thuongtru"]) + "," +
                chuyen.OBJ_C(b_dr["qh_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["xp_thuongtru"]) + "," + chuyen.OBJ_C(b_dr["tt_honnhan"]) + "," + chuyen.OBJ_C(b_dr["sodt_nr"]) + "," +
                chuyen.OBJ_C(b_dr["sodt_dd"]) + "," + chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["chieucao"]) + "," + chuyen.OBJ_C(b_dr["cannang"]) + "," + chuyen.OBJ_C(b_dr["dantoc"]) + "," +
                chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["trangthai_uv_theoyc"]) + "," + chuyen.OBJ_C(b_dr["nguoithan_lvttd_co"]) + "," + chuyen.OBJ_C(b_dr["nguoithan_lvttd_ko"]) + "," +
                chuyen.OBJ_C(b_dr["nguoithan_lvttd_thongtin"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_co"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_ko"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_lvttd_vitri"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_bophan"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_tbp"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_lvttd_cty"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_tglv"]) + "," + chuyen.OBJ_C(b_dr["banthan_lvttd_lydo_nv"]) + "," +
                chuyen.OBJ_C(b_dr["banthan_ut_co"]) + "," + chuyen.OBJ_C(b_dr["banthan_ut_ko"]) + "," + chuyen.OBJ_C(b_dr["banthan_ut_thongtin"]) + "," + chuyen.OBJ_C(b_dr["lienhe_hoten"]) + "," +
                chuyen.OBJ_C(b_dr["lienhe_mqh"]) + "," + chuyen.OBJ_C(b_dr["lienhe_sdt"]) + "," + chuyen.OBJ_C(b_dr["lienhe_diachi"]) + "," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," +
                chuyen.OBJ_C(b_dr["kh_phattrien_sn"]) + "," + chuyen.OBJ_C(b_dr["cac_thanhtich"]);

            b_c = b_c + ",:a_tentruong,:a_chuyennganh,:a_tunam,:a_dennam,:a_trinhdo,:a_hinhthuc_dt,:a_loai_totnghiep";
            b_c = b_c + ",:a_ten_ngoaingu,:a_chungchi_nn,:a_namcap,:a_noicap,:a_diem_nn,:a_xeploai_nn";
            b_c = b_c + ",:a_tenchungchi,:a_noidung,:a_sohieu,:a_coso_daotao,:a_tungay,:a_denngay,:a_ngay_hl,:a_ngay_hhl";
            b_c = b_c + ",:a_tencty,:a_chucdanh,:a_nhiemvu,:a_tuthang,:a_denthang,:a_lydo_nghiviec";
            b_c = b_c + ",:a_hoten,:a_quanhe,:a_ngaysinh,:a_nghenghiep,:a_noi_ct";
            b_c = b_c + ",:a_hoten_ttk,:a_congty_ttk,:a_cdanh_ttk,:a_quanhe_ttk,:a_sodt_ttk,:a_email_ttk";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_UV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["so_the"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string PNS_TD_CHON_KHOUV_NH(string b_ma_dx, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_sothe = bang.Fobj_COL_MANG(b_dt, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe", 'S', a_sothe);
            string b_c = "," + chuyen.OBJ_C(b_ma_dx) + ",:a_sothe";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_CHON_KHOUV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_GAN_UV_XOA(string b_ma_yc, string b_so_the)
    {
        dbora.P_GOIHAM(new string[] { b_ma_yc, b_so_the }, "PNS_TD_GAN_UV_XOA");
    }
    public static DataTable Fdt_NS_TD_GAN_UV_EXCEL()
    {
        return dbora.Fdt_LKE("Fdt_NS_TD_UV_YEUCAU_EXCEL");
    }
    #endregion

    #region PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG
    public static object[] Fdt_NS_TD_PD_CDANH_TD_LKE(string b_nam, string b_ma_dx, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma_dx, b_tu, b_den }, "NR", "PNS_TD_PD_CDANH_TD_LKE");
    }
    public static object[] Fdt_NS_TD_PD_CDANH_TD_MA(string b_nam, string b_nam_tk, string b_ma_dx_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_nam_tk), b_ma_dx_tk, b_trangkt }, "NNR", "PNS_TD_PD_CDANH_TD_MA");
    }
    public static DataTable Fdt_NS_TD_PD_CDANH_TD_CT(string b_nam, string b_thang, string b_ma_dx)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_ma_dx }, "NS_TD_PD_CDANH_TD_CT");
    }
    public static void P_NS_TD_PD_CDANH_TD_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngaygui = bang.Fobj_COL_MANG(b_dt_ct, "ngaygui");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "trangthai");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaygui", 'N', a_ngaygui);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);

            string b_c = "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma_dx"]) + ",:a_so_id,:a_so_the,:ngaygui,:a_trangthai";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".NS_TD_PD_CDANH_TD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_NS_TD_PD_CDANH_TD_DS(string b_madexuat)
    {
        return dbora.Fdt_LKE_S(new object[] { b_madexuat }, "NS_TD_PD_CDANH_TD_DS");
    }
    public static DataTable Fdt_PNS_TD_PD_CDANH_TD_EXP()
    {
        return dbora.Fdt_LKE("PNS_TD_PD_CDANH_TD_EXP");
    }
    #endregion PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG

    #region XẾP LỊCH PHỎNG VẤN THI TUYỂN
    public static DataTable Fdt_NS_TD_PHONGVAN_CT(string b_ma_dx, string b_ngay_xeplich, string b_vongthi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dx, chuyen.CNG_SO(b_ngay_xeplich), b_vongthi }, "NS_TD_PHONGVAN_CT");
    }
    public static object[] Fdt_NS_TD_PHONGVAN_LKE(string b_nam, string b_ma_dx, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma_dx, b_tu, b_den }, "NR", "NS_TD_PHONGVAN_LKE");
    }
    public static object[] Fdt_NS_TD_PHONGVAN_MA(string b_nam, string b_nam_tk, string b_ma_dx_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_nam_tk), b_ma_dx_tk, b_trangkt }, "NNR", "PNS_TD_PHONGVAN_MA");
    }
    public static DataTable Fdt_NS_TD_PHONGVAN_LKE_DS(string b_madexuat, string b_vthi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_madexuat, b_vthi }, "NS_TD_PHONGVAN_LKE_DS");
    }
    public static void P_NS_TD_PHONGVAN_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        bang.P_CNG_SO(ref b_dt, "NGAY_XEPLICH");
        bang.P_CNG_SO(ref b_dt_ct, "ngaythi_pv");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_vongthi_pv = bang.Fobj_COL_MANG(b_dt_ct, "vongthi_pv");
            object[] a_ngaythi_pv = bang.Fobj_COL_MANG(b_dt_ct, "ngaythi_pv");
            object[] a_giothi_pv_bd = bang.Fobj_COL_MANG(b_dt_ct, "giothi_pv_bd");
            object[] a_giothi_pv_kt = bang.Fobj_COL_MANG(b_dt_ct, "giothi_pv_kt");
            object[] a_nguoi_pv = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_pv");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "trangthai");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_vongthi_pv", 'U', a_vongthi_pv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythi_pv", 'N', a_ngaythi_pv);
            dbora.P_THEM_PAR(ref b_lenh, "a_giothi_pv_bd", 'U', a_giothi_pv_bd);
            dbora.P_THEM_PAR(ref b_lenh, "a_giothi_pv_kt", 'U', a_giothi_pv_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_pv", 'U', a_nguoi_pv);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma_dx"]) + "," + chuyen.OBJ_S(b_dr["ngay_xeplich"]) + "," + chuyen.OBJ_C(b_dr["vong_thi"]) + ",:a_so_id,:a_so_the,:a_vongthi_pv,:a_ngaythi_pv,:a_giothi_pv_bd,:a_giothi_pv_kt,:a_nguoi_pv,:a_trangthai";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".NS_TD_PHONGVAN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_TD_PHONGVAN_XOA(string b_ma_dx, string b_vongthi, string b_ngay_xeplich)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dx, b_vongthi, chuyen.OBJ_N(chuyen.CNG_CSO(b_ngay_xeplich)) }, "NS_TD_PHONGVAN_XOA");
    }
    public static DataTable Fdt_NS_TD_PHONGVAN_EXP()
    {
        return dbora.Fdt_LKE("PNS_TD_PHONGVAN_EXP");
    }
    public static void Fdt_NS_TD_PHONGVAN_SENDMAIL(string b_vongthi, string b_dexuat, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            // thêm con trỏ vào biến
            //dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = "," + chuyen.OBJ_C(b_vongthi) + "," + chuyen.OBJ_C(b_dexuat) + ",:a_so_id,:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_TD_PHONGVAN_SENDMAIL(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion XẾP LỊCH PHỎNG VẤN THI TUYỂN

    #region KẾT QUẢ THI TUYỂN DỤNG
    public static DataSet Fds_NS_TD_KQ_DS(string b_ma_yeucau)
    {
        return dbora.Fds_LKE(b_ma_yeucau, 2, "PNS_TD_KQ_DS");
    }
    public static object[] Faobj_NS_TD_KQ_LKE(string b_nam, string b_yeucau, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_yeucau, b_tu, b_den }, "NR", "PNS_TD_KQ_LKE");
    }
    public static void P_NS_TD_KQ_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_monthi1 = bang.Fobj_COL_MANG(b_dt_ct, "monthi1");
            object[] a_ngaythi1 = bang.Fobj_COL_MANG(b_dt_ct, "ngaythi1");
            object[] a_nguoi_pv1 = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_pv1");
            object[] a_diemdat1 = bang.Fobj_COL_MANG(b_dt_ct, "diemdat1");
            object[] a_ketqua1 = bang.Fobj_COL_MANG(b_dt_ct, "ketqua1");
            object[] a_monthi2 = bang.Fobj_COL_MANG(b_dt_ct, "monthi2");
            object[] a_ngaythi2 = bang.Fobj_COL_MANG(b_dt_ct, "ngaythi2");
            object[] a_nguoi_pv2 = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_pv2");
            object[] a_diemdat2 = bang.Fobj_COL_MANG(b_dt_ct, "diemdat2");
            object[] a_ketqua2 = bang.Fobj_COL_MANG(b_dt_ct, "ketqua2");
            object[] a_monthi3 = bang.Fobj_COL_MANG(b_dt_ct, "monthi3");
            object[] a_ngaythi3 = bang.Fobj_COL_MANG(b_dt_ct, "ngaythi3");
            object[] a_nguoi_pv3 = bang.Fobj_COL_MANG(b_dt_ct, "nguoi_pv3");
            object[] a_diemdat3 = bang.Fobj_COL_MANG(b_dt_ct, "diemdat3");
            object[] a_ketqua3 = bang.Fobj_COL_MANG(b_dt_ct, "ketqua3");
            object[] a_ketqua_chung = bang.Fobj_COL_MANG(b_dt_ct, "ketqua_chung");
            object[] a_gd_nhansu_pd = bang.Fobj_COL_MANG(b_dt_ct, "gd_nhansu_pd");
            object[] a_tgd_pd = bang.Fobj_COL_MANG(b_dt_ct, "tgd_pd");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_monthi1", 'U', a_monthi1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythi1", 'N', a_ngaythi1);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_pv1", 'U', a_nguoi_pv1);
            dbora.P_THEM_PAR(ref b_lenh, "a_diemdat1", 'N', a_diemdat1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua1", 'U', a_ketqua1);
            dbora.P_THEM_PAR(ref b_lenh, "a_monthi2", 'U', a_monthi2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythi2", 'N', a_ngaythi2);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_pv2", 'U', a_nguoi_pv2);
            dbora.P_THEM_PAR(ref b_lenh, "a_diemdat2", 'N', a_diemdat2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua2", 'U', a_ketqua2);
            dbora.P_THEM_PAR(ref b_lenh, "a_monthi3", 'U', a_monthi3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythi3", 'N', a_ngaythi3);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_pv3", 'U', a_nguoi_pv3);
            dbora.P_THEM_PAR(ref b_lenh, "a_diemdat3", 'N', a_diemdat3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua3", 'U', a_ketqua3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua_chung", 'U', a_ketqua_chung);
            dbora.P_THEM_PAR(ref b_lenh, "a_gd_nhansu_pd", 'U', a_gd_nhansu_pd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tgd_pd", 'U', a_tgd_pd);

            string b_c = ",:a_so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," + chuyen.OBJ_C(b_dr["ten_cdanh"]) + "," + chuyen.OBJ_C(b_dr["phongban_ct"]) + ",";
            b_c = b_c + ":a_so_the,:a_monthi1,:a_ngaythi1,:a_nguoi_pv1,:a_diemdat1,:a_ketqua1,:a_monthi2,:a_ngaythi2,:a_nguoi_pv2,:a_diemdat2,:a_ketqua2,:a_monthi3,:a_ngaythi3,:a_nguoi_pv3,:a_diemdat3,:a_ketqua3,:a_ketqua_chung,:a_gd_nhansu_pd,:a_tgd_pd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KQ_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_TD_KQ_PD(string b_so_id, string b_trangthai, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_gd_nhansu_pd = bang.Fobj_COL_MANG(b_dt_ct, "gd_nhansu_pd");
            object[] a_tgd_pd = bang.Fobj_COL_MANG(b_dt_ct, "tgd_pd");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_gd_nhansu_pd", 'U', a_gd_nhansu_pd);
            dbora.P_THEM_PAR(ref b_lenh, "a_tgd_pd", 'U', a_tgd_pd);

            string b_c = ",:a_so_id," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," + chuyen.OBJ_C(b_trangthai) + ",";
            b_c = b_c + ":a_so_the,:a_gd_nhansu_pd,:a_tgd_pd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KQ_PD(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataSet Fds_NS_TD_KQ_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_KQ_CT");
    }
    public static void PNS_TD_KQ_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_TD_KQ_XOA");
    }
    public static DataTable Fdt_NS_TD_EXP()
    {
        return dbora.Fdt_LKE("PNS_TD_KQ_EXP");
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_TD_KETQUA_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TD_KETQUA_EXPORT");
    }
    #endregion KẾT QUẢ THI TUYỂN DỤNG

    #region KẾT QUẢ PHỎNG VẤN
    public static object[] Faobj_NS_TD_KQ_PV_LKE(string b_nam, string b_yeucau, string b_cdanh, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_yeucau, b_cdanh, b_tu, b_den }, "NR", "PNS_TD_KQ_PV_LKE");
    }
    public static object[] Faobj_NS_TD_KQ_PV_MA(string b_so_the, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_trangkt }, "NNR", "PNS_TD_KQ_PV_MA");
    }
    public static DataSet Fds_NS_TD_KQ_PV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_KQ_PV_CT");
    }
    public static void P_NS_TD_KQ_PV_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_tieuchi = bang.Fobj_COL_MANG(b_dt_ct, "tieuchi");
            object[] a_ghinhan_dactrung = bang.Fobj_COL_MANG(b_dt_ct, "ghinhan_dactrung");
            object[] a_tytrong = bang.Fobj_COL_MANG(b_dt_ct, "tytrong");
            object[] a_diem_dg = bang.Fobj_COL_MANG(b_dt_ct, "diem_dg");
            object[] a_tongdiem = bang.Fobj_COL_MANG(b_dt_ct, "tongdiem");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tieuchi", 'U', a_tieuchi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghinhan_dactrung", 'U', a_ghinhan_dactrung);
            dbora.P_THEM_PAR(ref b_lenh, "a_tytrong", 'N', a_tytrong);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_dg", 'N', a_diem_dg);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongdiem", 'N', a_tongdiem);

            string b_c = ",:a_so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["ma_yc"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phong"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["SO_THE"]) + "," + chuyen.OBJ_C(b_dr["NHANXET_CHUNG"]) + "," + chuyen.OBJ_C(b_dr["DONG_Y"]) + "," + chuyen.OBJ_C(b_dr["XEMXET"]) + "," + chuyen.OBJ_C(b_dr["KHONG_DONGY"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["LHD_BANDAU"]) + "," + chuyen.OBJ_C(b_dr["LYDO"]) + "," + chuyen.OBJ_S(b_dr["MUCLUONG_CT"]) + "," + chuyen.OBJ_S(b_dr["MUCLUONG_TV"]) + "," + chuyen.OBJ_C(b_dr["TG_THUVIEC"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["NGAYDL_DK"]) + "," + chuyen.OBJ_C("");
            b_c = b_c + ",:a_stt,:a_tieuchi,:a_ghinhan_dactrung,:a_tytrong,:a_diem_dg,:a_tongdiem";


            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KQ_PV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_TD_KQ_PV_UP(string b_so_id, string b_trangthai)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_trangthai }, "pns_td_kq_pv_up");
    }
    public static void P_NS_TD_KQ_PV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TD_KQ_PV_XOA");
    }
    public static DataSet Fds_NS_TD_KQ_PV_IN(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_KQ_PV_IN");
        //return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TD_KQ_PV_IN");
    }
    #endregion KẾT QUẢ PHỎNG VẤN

    #region[Chuyển ứng viên thành nhân viên]

    #endregion

    //#region CẬP NHẬT ỨNG VIÊN TRÚNG TUYỂN

    //public static object[] Faobj_NS_TD_CAPNHAT_UV_LKE(string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma_yc, double b_tu, double b_den)
    //{
    //    return dbora.Faobj_LKE(new object[] { chuyen.OBJ_I(b_nam), b_thang, b_phong, b_cdanh, b_ma_yc, b_tu, b_den }, "NR", "PNS_TD_CAPNHAT_UV_LKE");
    //}
    //public static object[] Faobj_NS_TD_CAPNHAT_UV_MA(string b_so_the, string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma, double b_trangkt)
    //{
    //    return dbora.Faobj_LKE(new object[] { chuyen.OBJ_I(b_nam), chuyen.OBJ_I(b_thang), b_phong, b_cdanh, b_ma, b_so_the, b_trangkt }, "NNR", "PNS_TD_CAPNHAT_UV_MA");
    //}
    //public static DataTable Fdt_NS_TD_CAPNHAT_UV_CT(string b_nam, string b_ma, string b_so_the)
    //{
    //    return dbora.Fdt_LKE_S(new object[] { b_nam, b_ma, b_so_the }, "PNS_TD_CAPNHAT_UV_CT");
    //}
    //public static void P_NS_TD_CAPNHAT_UV_NH(string b_ma, DataTable b_dt)
    //{
    //    se.se_nsd b_se = new se.se_nsd();
    //    OracleConnection b_cnn = dbora.Fcn_KNOI();
    //    try
    //    {
    //        OracleCommand b_lenh = new OracleCommand();
    //        b_lenh.Connection = b_cnn;
    //        DataRow b_dr = b_dt.Rows[0];
    //        string b_c = "," + chuyen.OBJ_C(b_ma) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["diadiem_lv"]) + "," + chuyen.OBJ_C(b_dr["thoigian_lv"]) + "," + chuyen.OBJ_N(b_dr["ngay_bd"]) + "," + chuyen.OBJ_C(b_dr["thoigian_tv"]) + ","
    //            + chuyen.OBJ_C(b_dr["cdanh_ql"]) + "," + chuyen.OBJ_C(b_dr["ten_ql"]) + "," + chuyen.OBJ_C(b_dr["trangthai_tm"]) + "," + chuyen.OBJ_N(b_dr["tluong"]) + "," + chuyen.OBJ_C(b_dr["bluong"]) + "," + chuyen.OBJ_C(b_dr["nluong"]) + ","
    //            + chuyen.OBJ_N(b_dr["luong"]) + "," + chuyen.OBJ_N(b_dr["luong_tv"]) + "," + chuyen.OBJ_C(b_dr["dvi_tinh"]);
    //        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_CAPNHAT_UV_NH(" + b_se.tso + b_c + "); end;";
    //        try
    //        {
    //            b_lenh.ExecuteNonQuery();
    //        }
    //        finally { b_lenh.Parameters.Clear(); }
    //    }
    //    finally { b_cnn.Close(); }
    //}
    //public static DataTable Fdt_NS_TD_CAPNHAT_UV_TEN_QL(string b_phong, string b_cdanh)
    //{
    //    return dbora.Fdt_LKE_S(new object[] { b_phong, b_cdanh }, "PNS_TD_CAPNHAT_UV_TEN_QL");
    //}
    //public static void P_NS_TD_CAPNHAT_UV_XOA(string b_so_the)
    //{
    //    dbora.P_GOIHAM(chuyen.OBJ_N(b_so_the), "PNS_TD_CAPNHAT_UV_XOA");
    //}
    //#endregion CẬP NHẬT ỨNG VIÊN TRÚNG TUYỂN

    #region DANH SÁCH ỨNG VIÊN TRÚNG TUYỂN
    public static object[] Faobj_NS_TD_UNGVIEN_DONGY_LKE(string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma_yc, b_cdanh, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_TD_UNGVIEN_DONGY_LKE");
    }
    public static DataTable Fdt_NS_TD_UNGVIEN_DONGY_EXCEL(string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_I(b_nam), b_ma_yc, b_cdanh, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay) }, "PNS_TD_UNGVIEN_DONGY_EXCEL");
    }
    #endregion

    #region CHUYỂN ỨNG VIÊN SANG HỒ SƠ NHÂN VIÊN
    public static object[] Faobj_NS_TD_UNGVIEN_NV_LKE(string b_ma_yc, string b_nam, string b_cdanh, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_yc, b_nam, b_cdanh, b_tu, b_den }, "NR", "PNS_TD_UNGVIEN_NV_LKE");
    }
    public static void P_NS_TD_UNGVIEN_NV_CHUYEN(string b_ma, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_so_the }, "PNS_TD_UNGVIEN_NV_CHUYEN");
    }
    #endregion

    #region PHÊ DUYỆT ỨNG VIÊN THÀNH NHÂN VIÊN
    public static object[] Faobj_NS_TD_UNGVIEN_NV_PD_LKE(string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay, string b_trangthai_pd, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma_yc, b_cdanh, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_trangthai_pd, b_tu, b_den }, "NR", "PNS_TD_UNGVIEN_NV_PD_LKE");
    }
    public static void P_NS_TD_UNGVIEN_NV_PD_PHEDUYET(string b_ma, string b_so_the, string b_ma_nv)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_so_the, b_ma_nv }, "PNS_TD_UNGVIEN_NV_PHEDUYET");
    }
    #endregion

    #region QUẢN LÝ CHI PHÍ TUYỂN DỤNG
    public static object[] Faobj_NS_TD_PHI_TD_LKE(string b_nam, string b_ma_yc, string b_cdanh, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma_yc, b_cdanh, b_phong, b_tu_n, b_den_n }, "NR", "PNS_TD_PHI_TD_LKE");
    }
    public static object[] Faobj_NS_TD_PHI_TD_MA(string b_ma_yc, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_yc, b_trangkt }, "NNR", "PNS_TD_PHI_TD_MA");
    }
    public static void P_TD_PHI_TD_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nam"], b_dr["ma_yc"], b_dr["cdanh"], b_dr["phong"], b_dr["sl_tuyendung"], b_dr["ten_hangmuc"], b_dr["tien_cphi"], b_dr["ghichu"] }, "PNS_TD_PHI_TD_NH");
    }
    public static void P_TD_PHI_TD_XOA(string b_ma_yc)
    {
        dbora.P_GOIHAM(b_ma_yc, "PNS_TD_PHI_TD_XOA");
    }
    #endregion QUẢN LÝ CHI PHÍ TUYỂN DỤNG

    #region HỒ SƠ ỨNG VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TD_HSUV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_TD_HSUV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_tl_tlap_bh_MA(string b_cmt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_cmt, b_trangkt }, "NNR", "PNS_TD_HSUV_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TD_HSUV_CT(string b_cmt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_cmt }, "PNS_TD_HSUV_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TD_HSUV_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["nam"],b_dr["dot"], b_dr["nhom_cdanh"], b_dr["ma_cdanh"], b_dr["cmt"], b_dr["ten"], b_dr["gtinh"], b_dr["nsinh"], b_dr["trinh_do"],
                b_dr["kinh_nghiem"], b_dr["ky_nang"], b_dr["note"] }, "PNS_TD_HSUV_NH");
        }
    }
    public static void PNS_TD_HSUV_XOA(string b_cmt)
    {
        dbora.P_GOIHAM(new object[] { b_cmt }, "PNS_TD_HSUV_XOA");
    }
    #endregion HỒ SƠ ỨNG VIÊN

    #region KẾ HOẠCH TUYỂN DỤNG
    public static object[] Fdt_NS_TD_KH_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_TD_KH_LKE");
    }
    public static object[] Fdt_NS_TD_KH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_TD_KH_MA");
    }
    public static DataSet Fdt_NS_TD_KH_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_KH_CT");
    }
    public static DataTable Fdt_NS_TD_MAKH_TRA(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "pns_td_kh_makh_tra");
    }
    public static DataSet Fdt_NS_TD_LAY_TUYENDUNG(string b_ma)
    {
        return dbora.Fds_LKE(new object[] { b_ma }, 3, "pns_td_kh_lay_tuyendung");
    }
    public static DataTable Fdt_NS_TD_LAY_TUYENDUNG(string b_ma, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma, b_so_id }, "pns_td_kh_lay_tuyendung2");
    }
    public static void PNS_TD_KH_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_ct, "sott");
            object[] a_nhom_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "nhom_cdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_ct, "soluong");
            object[] a_noi_lv = bang.Fobj_COL_MANG(b_dt_ct, "noi_lv");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cdanh", 'S', a_nhom_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "  ", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_lv", 'U', a_noi_lv);


            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_S(b_dr["ngay"])
                + "," + chuyen.OBJ_S(b_dr["ngaydk"]) + "," + chuyen.OBJ_C(b_dr["kinhphi"])
                + ",:a_sott,:a_nhom_cdanh,:a_cdanh,:a_phong,:a_soluong,:a_noi_lv";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_KH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_TD_KH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TD_KH_XOA");
    }
    #endregion KẾ HOẠCH TUYỂN DỤNG

    #region LỊCH PHỎNG VẤN
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TD_LICHPV_CT(string b_phong, string b_nam, string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_nam, chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_LICHPV_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static DataTable Fdt_NS_TD_LICHPV_LKE(string b_phong, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_nam }, "PNS_TD_LICHPV_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_TD_LICHPV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            DataTable a_dt_ct = b_dt_ct;
            bang.P_CNG_SO(ref a_dt_ct, new string[] { "nsinh", "ngaypv" });

            object[] a_ma_hs = bang.Fobj_COL_MANG(a_dt_ct, "ma_hs");
            object[] a_ten = bang.Fobj_COL_MANG(a_dt_ct, "ten");
            object[] a_nsinh = bang.Fobj_COL_MANG(a_dt_ct, "nsinh");
            object[] a_trinhdo = bang.Fobj_COL_MANG(a_dt_ct, "trinhdo");
            object[] a_kinhnghiem = bang.Fobj_COL_MANG(a_dt_ct, "kinhnghiem");
            object[] a_ngaypv = bang.Fobj_COL_MANG(a_dt_ct, "ngaypv");
            object[] a_giopv = bang.Fobj_COL_MANG(a_dt_ct, "giopv");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_hs", 'S', a_ma_hs);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_nsinh", 'N', a_nsinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_trinhdo", 'U', a_trinhdo);
            dbora.P_THEM_PAR(ref b_lenh, "a_kinhnghiem", 'U', a_kinhnghiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaypv", 'N', a_ngaypv);
            dbora.P_THEM_PAR(ref b_lenh, "a_giopv", 'U', a_giopv);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["nam"]) + ","
                + chuyen.OBJ_S(b_dr["dot"]) + "," + chuyen.OBJ_C(b_dr["nhom_cdanh"]) + "," + chuyen.OBJ_C(b_dr["ma_cdanh"])
                + ",:a_ma_hs" + ",:a_ten" + ",:a_nsinh" + ",:a_trinhdo" + ",:a_kinhnghiem" + ",:a_ngaypv" + ",:a_giopv";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_LICHPV_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TD_LICHPV_XOA(string b_phong, string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_so_id }, "PNS_TD_LICHPV_XOA");
    }
    public static DataTable Fdt_NS_TD_LICHPV_LKE_UV(string b_nhom_cdanh, string b_ma_cdanh)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_nhom_cdanh, b_ma_cdanh }, "PNS_TD_LICHPV_UV");
        bang.P_THEM_COL(ref b_dt, new string[] { "ngaypv", "giopv" }, new string[] { "", "" });
        return b_dt;
    }
    #endregion LỊCH PHỎNG VẤN

    #region ĐỢT TUYỂN DỤNG

    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static object[] Fdt_NS_TD_DOT_LKE(string b_ma, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_tu, b_den }, "NR", "PNS_TD_DOT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TD_DOT_MA(string b_nam, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma, b_trangkt }, "NNR", "PNS_TD_DOT_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>

    public static DataSet Fdt_NS_TD_DOT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TD_DOT_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_TD_DOT_NH(string b_so_id, DataTable b_dt, DataTable b_dt_yc, DataTable b_dt_vg)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_sott = bang.Fobj_COL_MANG(b_dt_yc, "sott");
            object[] a_ma_dxuat = bang.Fobj_COL_MANG(b_dt_yc, "ma_dxuat");
            object[] a_nhom_cdanh = bang.Fobj_COL_MANG(b_dt_yc, "nhom_cdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_yc, "cdanh");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_yc, "soluong");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt_yc, "loai");
            object[] a_noi_lv = bang.Fobj_COL_MANG(b_dt_yc, "noi_lv");
            object[] a_vong1 = bang.Fobj_COL_MANG(b_dt_vg, "vong1");
            object[] a_diem1 = bang.Fobj_COL_MANG(b_dt_vg, "diem1");
            object[] a_hso1 = bang.Fobj_COL_MANG(b_dt_vg, "hso1");
            object[] a_vong2 = bang.Fobj_COL_MANG(b_dt_vg, "vong2");
            object[] a_diem2 = bang.Fobj_COL_MANG(b_dt_vg, "diem2");
            object[] a_hso2 = bang.Fobj_COL_MANG(b_dt_vg, "hso2");
            object[] a_vong3 = bang.Fobj_COL_MANG(b_dt_vg, "vong3");
            object[] a_diem3 = bang.Fobj_COL_MANG(b_dt_vg, "diem3");
            object[] a_hso3 = bang.Fobj_COL_MANG(b_dt_vg, "hso3");
            object[] a_vong4 = bang.Fobj_COL_MANG(b_dt_vg, "vong4");
            object[] a_diem4 = bang.Fobj_COL_MANG(b_dt_vg, "diem4");
            object[] a_hso4 = bang.Fobj_COL_MANG(b_dt_vg, "hso4");
            object[] a_vong5 = bang.Fobj_COL_MANG(b_dt_vg, "vong5");
            object[] a_diem5 = bang.Fobj_COL_MANG(b_dt_vg, "diem5");
            object[] a_hso5 = bang.Fobj_COL_MANG(b_dt_vg, "hso5");
            object[] a_vong6 = bang.Fobj_COL_MANG(b_dt_vg, "vong6");
            object[] a_diem6 = bang.Fobj_COL_MANG(b_dt_vg, "diem6");
            object[] a_hso6 = bang.Fobj_COL_MANG(b_dt_vg, "hso6");
            object[] a_vong7 = bang.Fobj_COL_MANG(b_dt_vg, "vong7");
            object[] a_diem7 = bang.Fobj_COL_MANG(b_dt_vg, "diem7");
            object[] a_hso7 = bang.Fobj_COL_MANG(b_dt_vg, "hso7");
            object[] a_vong8 = bang.Fobj_COL_MANG(b_dt_vg, "vong8");
            object[] a_diem8 = bang.Fobj_COL_MANG(b_dt_vg, "diem8");
            object[] a_hso8 = bang.Fobj_COL_MANG(b_dt_vg, "hso8");
            object[] a_vong9 = bang.Fobj_COL_MANG(b_dt_vg, "vong9");
            object[] a_diem9 = bang.Fobj_COL_MANG(b_dt_vg, "diem9");
            object[] a_hso9 = bang.Fobj_COL_MANG(b_dt_vg, "hso9");
            object[] a_vong10 = bang.Fobj_COL_MANG(b_dt_vg, "vong10");
            object[] a_diem10 = bang.Fobj_COL_MANG(b_dt_vg, "diem10");
            object[] a_hso10 = bang.Fobj_COL_MANG(b_dt_vg, "hso10");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_dxuat", 'S', a_ma_dxuat);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhom_cdanh", 'S', a_nhom_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_lv", 'U', a_noi_lv);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong1", 'S', a_vong1);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem1", 'N', a_diem1);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso1", 'N', a_hso1);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong2", 'S', a_vong2);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem2", 'N', a_diem2);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso2", 'N', a_hso2);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong3", 'S', a_vong3);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem3", 'N', a_diem3);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso3", 'N', a_hso3);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong4", 'S', a_vong4);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem4", 'N', a_diem4);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso4", 'N', a_hso4);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong5", 'S', a_vong5);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem5", 'N', a_diem5);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso5", 'N', a_hso5);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong6", 'S', a_vong6);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem6", 'N', a_diem6);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso6", 'N', a_hso6);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong7", 'S', a_vong7);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem7", 'N', a_diem7);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso7", 'N', a_hso7);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong8", 'S', a_vong8);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem8", 'N', a_diem8);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso8", 'N', a_hso8);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong9", 'S', a_vong9);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem9", 'N', a_diem9);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso9", 'N', a_hso9);
            dbora.P_THEM_PAR(ref b_lenh, "a_vong10", 'S', a_vong10);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem10", 'N', a_diem10);
            dbora.P_THEM_PAR(ref b_lenh, "a_hso10", 'N', a_hso10);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["tendot"]) + "," +
                chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_S(b_dr["diem"]) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_c = b_c + ",:a_sott,:a_ma_dxuat,:a_nhom_cdanh,:a_cdanh,:a_soluong,:a_loai,:a_noi_lv";
            b_c = b_c + ",:a_vong1,:a_diem1,:a_hso1,:a_vong2,:a_diem2,:a_hso2,:a_vong3,:a_diem3,:a_hso3,:a_vong4,:a_diem4,:a_hso4,:a_vong5,:a_diem5,:a_hso5";
            b_c = b_c + ",:a_vong6,:a_diem6,:a_hso6,:a_vong7,:a_diem7,:a_hso7,:a_vong8,:a_diem8,:a_hso8,:a_vong9,:a_diem9,:a_hso9,:a_vong10,:a_diem10,:a_hso10";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DOT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void PNS_TD_DOT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TD_DOT_XOA");
    }

    public static DataTable PNS_TD_DOT_HOI_CDANH(string b_nhom_cdanh, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nhom_cdanh, b_cdanh }, "PNS_TD_DOT_HOI_CDANH");
    }

    public static DataTable PNS_TD_DOT_HOI_DXUAT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TD_DOT_HOI_DXUAT");
    }
    #endregion ĐỢT TUYỂN DỤNG

    #region CV ONLINE
    public static void Fdt_NS_TD_CV_ONLINE_NH(DataTable b_cdanh, DataTable b_dt, DataTable b_dt_dt, DataTable b_dt_tt, DataTable b_dt_gd, DataTable b_dt_dt_ct, DataTable b_dt_tt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            DataRow b_dr_dt = b_dt_dt.Rows[0];
            DataRow b_dr_tt = b_dt_tt.Rows[0];
            DataRow b_dr_cdanh = b_cdanh.Rows[0];

            // gia đình
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_gd, "ten");
            object[] a_qhe = bang.Fobj_COL_MANG(b_dt_gd, "qhe");
            object[] a_gtinh = bang.Fobj_COL_MANG(b_dt_gd, "gtinh");
            object[] a_nsinh = bang.Fobj_COL_MANG(b_dt_gd, "nsinh");
            object[] a_nghenghiep = bang.Fobj_COL_MANG(b_dt_gd, "nghenghiep");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt_gd, "gchu");

            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_qhe", 'U', a_qhe);
            dbora.P_THEM_PAR(ref b_lenh, "a_gtinh", 'U', a_gtinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nsinh", 'U', a_nsinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghenghiep", 'U', a_nghenghiep);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);

            //// đào tạo
            object[] b_tentruong = bang.Fobj_COL_MANG(b_dt_dt_ct, "tentruong");
            object[] b_nganh = bang.Fobj_COL_MANG(b_dt_dt_ct, "nganh");
            object[] b_thoigian = bang.Fobj_COL_MANG(b_dt_dt_ct, "thoigian");
            object[] b_hinhthuc = bang.Fobj_COL_MANG(b_dt_dt_ct, "hinhthuc");
            object[] b_vanbang = bang.Fobj_COL_MANG(b_dt_dt_ct, "vanbang");

            dbora.P_THEM_PAR(ref b_lenh, "b_tentruong", 'U', b_tentruong);
            dbora.P_THEM_PAR(ref b_lenh, "b_nganh", 'U', b_nganh);
            dbora.P_THEM_PAR(ref b_lenh, "b_thoigian", 'U', b_thoigian);
            dbora.P_THEM_PAR(ref b_lenh, "b_hinhthuc", 'U', b_hinhthuc);
            dbora.P_THEM_PAR(ref b_lenh, "b_vanbang", 'U', b_vanbang);
            //// hoạt động công tác

            object[] c_tuthang = bang.Fobj_COL_MANG(b_dt_tt_ct, "tuthang");
            object[] c_toithang = bang.Fobj_COL_MANG(b_dt_tt_ct, "toithang");
            object[] c_congty = bang.Fobj_COL_MANG(b_dt_tt_ct, "congty");
            object[] c_congviec = bang.Fobj_COL_MANG(b_dt_tt_ct, "congviec");
            object[] c_lydonghi = bang.Fobj_COL_MANG(b_dt_tt_ct, "lydonghi");

            dbora.P_THEM_PAR(ref b_lenh, "c_tuthang", 'U', c_tuthang);
            dbora.P_THEM_PAR(ref b_lenh, "c_toithang", 'U', c_toithang);
            dbora.P_THEM_PAR(ref b_lenh, "c_congty", 'U', c_congty);
            dbora.P_THEM_PAR(ref b_lenh, "c_congviec", 'U', c_congviec);
            dbora.P_THEM_PAR(ref b_lenh, "c_lydonghi", 'U', c_lydonghi);


            string a = b_se.tso;
            string b_ma_dvi = b_se.ma_dvi.ToString();
            string b_c = chuyen.OBJ_C(b_ma_dvi) + "," + chuyen.OBJ_C(b_dr_cdanh["cdanh"]) + "," + chuyen.OBJ_C(b_dr_cdanh["dot"]) + "," + chuyen.OBJ_C(b_dr["cmt"]) + "," + chuyen.OBJ_C(b_dr["ten"])
                 + "," + chuyen.OBJ_C(b_dr["gtinh"]) + "," + chuyen.OBJ_C(b_dr["honnhan"]) + "," + chuyen.OBJ_S(b_dr["nsinh"]) + "," + chuyen.OBJ_C(b_dr["noisinh"]) + "," + chuyen.OBJ_C(b_dr["quequan"])
                 + "," + chuyen.OBJ_C(b_dr["quoctich"]) + "," + chuyen.OBJ_C(b_dr["dantoc"]) + "," + chuyen.OBJ_C(b_dr["tongiao"]) + "," + chuyen.OBJ_C(b_dr["dtlienhe"])
                 + "," + chuyen.OBJ_C(b_dr["email"]) + "," + chuyen.OBJ_C(b_dr["dcthuongtru"]) + "," + chuyen.OBJ_C(b_dr["noiohiennay"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr_dt["gdphothong"]) + "," + chuyen.OBJ_C(b_dr_dt["hocham"]) + "," + chuyen.OBJ_C(b_dr_dt["ngoaingu"])
                + "," + chuyen.OBJ_C(b_dr_dt["tinhoc"]) + "," + chuyen.OBJ_C(b_dr_dt["kynang"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr_tt["luongmuon"]) + "," + chuyen.OBJ_C(b_dr_tt["cvmuon"]) + "," + chuyen.OBJ_C(b_dr_tt["diemyeu"])
                + "," + chuyen.OBJ_C(b_dr_tt["diemmanh"]) + "," + chuyen.OBJ_C(b_dr_tt["nguonthamtra"]) + "," + " '' " + "," + chuyen.OBJ_C(b_dr["is_blacklist"]);
            b_c = b_c + ",:a_ten,:a_qhe,:a_gtinh,:a_nsinh,:a_nghenghiep,:a_gchu";
            b_c = b_c + ",:b_tentruong,:b_nganh,:b_thoigian,:b_hinhthuc,:b_vanbang";
            b_c = b_c + ",:c_tuthang,:c_toithang,:c_congty,:c_congviec,:c_lydonghi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_td_dv_online_nh(" + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_TD_DS_UVIEN_LKE(string b_cdanh)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_cdanh), "pns_td_cv_cdanh_lke");
    }

    public static DataSet Fdt_NS_TD_CV_ONLINE_CT(string b_cdanh, string b_cmt)
    {
        return dbora.Fds_LKE(new object[] { b_cdanh, b_cmt }, 4, "PNS_TD_CV_ONLINE_CT");
    }


    public static void P_NS_TD_DS_UVIEN_NH(string b_so_id, DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_so_id, b_dr["vong"], b_dr["ngay_thi"], b_dr["nguoipv"], b_dr["diem"], b_dr["nhanxet"], b_dr["dexuat"] }, "pns_td_ds_uvien_nh");
        }
    }

    public static DataTable P_NS_TD_DS_UVIEN_LKE(string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "pns_td_ds_uvien_lke");
    }

    public static DataTable P_NS_TD_DS_UVIEN_CT(string b_so_id, string b_vong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id, b_vong }, "pns_td_ds_uvien_ct");
    }

    public static DataTable P_NS_TD_DS_UVIEN_XOA(string b_so_id, string b_vong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id, b_vong }, "pns_td_ds_uvien_xoa");
    }

    public static void P_NS_TD_DS_UVIEN_TUYENDUNG(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'U', a_so_id);

            string b_c = ",:a_so_id";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_DS_UVIEN_TUYENDUNG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion CV ONLINE

    #region BLACKLIST
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_BLACKLIST_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_BLACKLIST_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_BLACKLIST_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["socmt"], b_dr["ho_ten"], b_dr["ngay_sinh"], b_dr["gioi_tinh"], b_dr["que_quan"] }, "PNS_BLACKLIST_NH");
    }

    public static object[] Fdt_BLACKLIST_MA(string b_socmt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_socmt, b_trangkt }, "NNR", "PNS_BLACKLIST_MA");
    }
    ///<summary> Xóa </summary>
    public static void P_BLACKLIST_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_BLACKLIST_XOA");
    }
    #endregion BLACKLIST

    #region KHO ỨNG VIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_KHO_UVIEN_LKE(string b_ma_cmt, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_cmt, b_tu_n, b_den_n }, "NR", "PNS_KHO_UVIEN_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_KHO_UVIEN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["cmt"], b_dr["ho_ten"], b_dr["gioi_tinh"], b_dr["ngay_sinh"], b_dr["noi_sinh"], b_dr["gchu"] }, "PNS_KHO_UVIEN_NH");
    }

    public static object[] Fdt_KHO_UVIEN_TIM(string b_ncdanh, string b_cdanh, string b_cmt, string b_gt, double b_trangkt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ncdanh, b_cdanh, b_cmt, b_gt, b_tu, b_den }, "NR", "PNS_KHO_UVIEN_TIM");
    }
    public static object[] Fdt_KHO_UVIEN_MA(string b_socmt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_socmt, b_trangkt }, "NNR", "PNS_KHO_UVIEN_MA");
    }
    ///<summary> Xóa </summary>
    public static void P_KHO_UVIEN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_KHO_UVIEN_XOA");
    }
    #endregion BLACKLIST

    #region TỔNG HỢP KẾ HOẠCH TUYỂN DỤNG
    //public static object[] Fdt_HDNS_TH_KH_TUYENDUNG_LKE(string b_phong, double b_tu, double b_den, string b_kyluong)
    //{
    //    return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den, chuyen.OBJ_N(b_kyluong) }, "NR", "PNS_HDNS_TH_KH_TUYENDUNG_LKE");
    //}

    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_LKE(string b_phong, double b_tu, double b_den, string b_kyluong)
    {
        //return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den, chuyen.OBJ_N(b_kyluong) }, "NR", "PNS_HDNS_TH_KH_TUYENDUNG_LKE");
        se.se_nsd b_se = new se.se_nsd();
        DataTable table = new DataTable();
        table.Columns.Add("STT", typeof(int));
        table.Columns.Add("NAM", typeof(string));
        table.Columns.Add("phong", typeof(string));
        table.Columns.Add("Cdanh", typeof(string));
        table.Columns.Add("thang1", typeof(int));
        table.Columns.Add("thang2", typeof(int));
        table.Columns.Add("thang3", typeof(int));
        table.Columns.Add("thang4", typeof(int));
        table.Columns.Add("thang5", typeof(int));
        table.Columns.Add("thang6", typeof(int));
        table.Columns.Add("thang7", typeof(int));
        table.Columns.Add("thang8", typeof(int));
        table.Columns.Add("thang9", typeof(int));
        table.Columns.Add("thang10", typeof(int));
        table.Columns.Add("thang11", typeof(int));
        table.Columns.Add("thang12", typeof(int));
        table.Columns.Add("tong_sl_tuyen", typeof(string));
        table.Columns.Add("sl_datuyen", typeof(string));
        table.Columns.Add("ghichu", typeof(string));
        table.Columns.Add("nsd", typeof(string));
        table.Columns.Add("so_id", typeof(string));
        table.Rows.Add(1, "2016", "Trung tâm giải pháp phần mềm doanh nghiệp", "Trưởng phòng", 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 2, 8, 6, "Đã tuyển", b_se.nsd, 10000);
        table.Rows.Add(2, "2017", "Trung tâm giải pháp phần mềm doanh nghiệp", "Phó phòng", 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 2, 7, 5, "Đã tuyển", b_se.nsd, 10000);
        table.Rows.Add(3, "2017", "Trung tâm giải pháp phần mềm doanh nghiệp", "Lập trình viên", 2, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 2, 9, 8, "Đã tuyển", b_se.nsd, 10000);
        table.Rows.Add(4, "2017", "Trung tâm giải pháp phần mềm doanh nghiệp", "Tester", 5, 0, 13, 12, 0, 20, 0, 16, 1, 0, 3, 22, 80, 68, "Đã tuyển", b_se.nsd, 10000);
        return table;
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_HDNS_TH_KH_TUYENDUNG_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_HDNS_TH_KH_TUYENDUNG_MA");
    }
    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_CT(string b_phong, string b_nam_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.OBJ_N(b_nam_id) }, "PNS_HDNS_TH_KH_TUYENDUNG_CT");
    }

    public static void P_HDNS_TH_KH_TUYENDUNG_NH(DataTable b_dt, DataTable b_dt_ct)
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

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_TH_KH_TUYENDUNG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_HDNS_TH_KH_TUYENDUNG_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_HDNS_TH_KH_TUYENDUNG_XOA");
    }
    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_LKE_CB(string b_phong, string b_thang)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_HDNS_TH_KH_TUYENDUNG_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "lv_thucte", "TN_TINHTHUE", "chenhca", "TNHAP_CHIUTHUE", "doanhthu", "luong_doanhthu", "tong_luong", "phep", "capbac", "hso_nn", "hspc_nn", "luong_nn", "capbac_cv", "hso_cv", "luong_cv", "luong_tg", "luong_sp", "luong_khoan", "luong_bh", "anca", "pcap", "tnhapchiuthue", "tnhap_kchiuthue", "bhxh", "bhyt", "bhtn", "pcd", "ct_bhxh", "ct_bhyt", "ct_bhtn", "ct_pcd", "ktru_chiuthue", "ktru_kchiuthue", "phuthuoc", "truthue", "tam_ung", "thuc_linh", "LV_THUCTE_OKIFOOD", "NGHI_CL", "NGHI_KCL", "HSPC_NN_TIEN", "CONG_CC4", "TIENCONG4", "CONG_CC5", "TIENCONG5", "CONG_CC6", "TIENCONG6", "CONG_CC7", "TIENCONG7", "CONG_CC8", "TIENCONG8", "CONG_CC9", "TIENCONG9", "XANGXE", "DIENTHOAI", "LUONG_LT", "TONG_PC", "TONG_LUONG_PC", "PHAITRA_NLD" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }

    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_LKE_CB_XUANTHANH(string b_phong, string b_thang)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_HDNS_TH_KH_TUYENDUNG_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "lv_thucte", "TN_TINHTHUE", "chenhca", "TNHAP_CHIUTHUE", "phep", "capbac", "hso_nn", "tong_luong", "hspc_nn", "luong_nn", "capbac_cv", "hso_cv", "luong_cv", "doanhthu", "luong_doanhthu", "anca", "pcap", "PHAITRA_NLD", "bhxh", "bhyt", "bhtn", "pcd", "ct_bhxh", "ct_bhyt", "ct_bhtn", "ct_pcd", "ktru_chiuthue", "ktru_kchiuthue", "phuthuoc", "truthue", "tam_ung", "thuc_linh", "LV_THUCTE_OKIFOOD", "NGHI_CL", "NGHI_KCL", "HSPC_NN_TIEN", "CONG_CC4", "TIENCONG4", "CONG_CC5", "TIENCONG5", "CONG_CC6", "TIENCONG6", "CONG_CC7", "TIENCONG7", "CONG_CC8", "TIENCONG8", "CONG_CC9", "TIENCONG9", "XANGXE", "DIENTHOAI", "LUONG_LT", "TONG_PC", "TONG_LUONG_PC", "PHAITRA_NLD" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" });
        return b_dt;
    }

    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_TINH(string b_phong, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.OBJ_N(b_nam) }, "PHDNS_TONGHOP_KEHOACH");
    }
    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_TINH_XUANTHANH(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_XT");

    }

    public static DataTable Fdt_HDNS_TH_KH_TUYENDUNG_TINH_OKI(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_OKI");

    }
    #endregion TỔNG HỢP KẾ HOẠCH TUYỂN DỤNG

    #region DANH SÁCH NÂNG LƯƠNG
    public static object[] Fs_HDNS_DINHBIEN_NS_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PHDNS_DINHBIEN_NS_LKE");
    }
    public static void Fs_HDNS_DINHBIEN_NS_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (!string.IsNullOrEmpty(b_dr["so_the"].ToString()))
                {
                    dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["cvu"], b_dr["hspc"], b_dr["ncd"], b_dr["cdanh"], b_dr["bac"], b_dr["hso"], chuyen.OBJ_N(b_dr["luong"]), b_dr["ngay_lap"], b_dr["ghichu"] }, "PHDNS_DINHBIEN_NS_NH");
                }
            }
        }
    }
    ///<summary> Xóa </summary>
    public static void Fs_HDNS_DINHBIEN_NS_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PHDNS_DINHBIEN_NS_XOA");
    }
    public static DataTable Fs_HDNS_DINHBIEN_NS_CT(string b_ngay_lap)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_lap) }, "PHDNS_DINHBIEN_NS_CT");
    }
    #endregion DANH SÁCH NÂNG LƯƠNG

    #region ĐỊNH BIÊN NHÂN SỰ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_HDNS_DBIEN_LKE(DataTable b_dt_tk, string b_cty, double b_tu_n, double b_den_n)
    {
        var dr = b_dt_tk.Rows[0];
        string b_nam_tk = dr["nam_tk"].ToString(), b_dvi_tk = b_cty;
        return dbora.Faobj_LKE(new object[] { b_nam_tk, b_dvi_tk, b_tu_n, b_den_n }, "NR", "PNS_HDNS_DBIEN_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable Fdt_NS_HDNS_DBIEN_NH(DataTable b_dt, DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_db, "CDANH");
            object[] a_ns_hientai = bang.Fobj_COL_MANG(b_dt_db, "NS_HIENTAI");


            object[] a_dinhbien_t1 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t1");
            object[] a_dinhbien_t2 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t2");
            object[] a_dinhbien_t3 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t3");
            object[] a_dinhbien_t4 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t4");
            object[] a_dinhbien_t5 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t5");
            object[] a_dinhbien_t6 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t6");
            object[] a_dinhbien_t7 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t7");
            object[] a_dinhbien_t8 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t8");
            object[] a_dinhbien_t9 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t9");
            object[] a_dinhbien_t10 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t10");
            object[] a_dinhbien_t11 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t11");
            object[] a_dinhbien_t12 = bang.Fobj_COL_MANG(b_dt_db, "dinhbien_t12");

            object[] a_phatsinh_t1 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t1");
            object[] a_phatsinh_t2 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t2");
            object[] a_phatsinh_t3 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t3");
            object[] a_phatsinh_t4 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t4");
            object[] a_phatsinh_t5 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t5");
            object[] a_phatsinh_t6 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t6");
            object[] a_phatsinh_t7 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t7");
            object[] a_phatsinh_t8 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t8");
            object[] a_phatsinh_t9 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t9");
            object[] a_phatsinh_t10 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t10");
            object[] a_phatsinh_t11 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t11");
            object[] a_phatsinh_t12 = bang.Fobj_COL_MANG(b_dt_db, "phatsinh_t12");

            object[] a_tong_t1 = bang.Fobj_COL_MANG(b_dt_db, "tong_t1");
            object[] a_tong_t2 = bang.Fobj_COL_MANG(b_dt_db, "tong_t2");
            object[] a_tong_t3 = bang.Fobj_COL_MANG(b_dt_db, "tong_t3");
            object[] a_tong_t4 = bang.Fobj_COL_MANG(b_dt_db, "tong_t4");
            object[] a_tong_t5 = bang.Fobj_COL_MANG(b_dt_db, "tong_t5");
            object[] a_tong_t6 = bang.Fobj_COL_MANG(b_dt_db, "tong_t6");
            object[] a_tong_t7 = bang.Fobj_COL_MANG(b_dt_db, "tong_t7");
            object[] a_tong_t8 = bang.Fobj_COL_MANG(b_dt_db, "tong_t8");
            object[] a_tong_t9 = bang.Fobj_COL_MANG(b_dt_db, "tong_t9");
            object[] a_tong_t10 = bang.Fobj_COL_MANG(b_dt_db, "tong_t10");
            object[] a_tong_t11 = bang.Fobj_COL_MANG(b_dt_db, "tong_t11");
            object[] a_tong_t12 = bang.Fobj_COL_MANG(b_dt_db, "tong_t12");




            //thêm parameter
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_hientai", 'U', a_ns_hientai);

            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t1", 'N', a_dinhbien_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t2", 'N', a_dinhbien_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t3", 'N', a_dinhbien_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t4", 'N', a_dinhbien_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t5", 'N', a_dinhbien_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t6", 'N', a_dinhbien_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t7", 'N', a_dinhbien_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t8", 'N', a_dinhbien_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t9", 'N', a_dinhbien_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t10", 'N', a_dinhbien_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t11", 'N', a_dinhbien_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_dinhbien_t12", 'N', a_dinhbien_t12);

            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t1", 'N', a_phatsinh_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t2", 'N', a_phatsinh_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t3", 'N', a_phatsinh_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t4", 'N', a_phatsinh_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t5", 'N', a_phatsinh_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t6", 'N', a_phatsinh_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t7", 'N', a_phatsinh_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t8", 'N', a_phatsinh_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t9", 'N', a_phatsinh_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t10", 'N', a_phatsinh_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t11", 'N', a_phatsinh_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_phatsinh_t12", 'N', a_phatsinh_t12);

            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t1", 'N', a_tong_t1);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t2", 'N', a_tong_t2);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t3", 'N', a_tong_t3);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t4", 'N', a_tong_t4);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t5", 'N', a_tong_t5);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t6", 'N', a_tong_t6);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t7", 'N', a_tong_t7);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t8", 'N', a_tong_t8);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t9", 'N', a_tong_t9);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t10", 'N', a_tong_t10);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t11", 'N', a_tong_t11);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_t12", 'N', a_tong_t12);


            // thêm con trỏ vào biến
            //dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["donvi"]) + "," + chuyen.OBJ_C(b_dr["ban"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["phongban_ct"]);
            b_c = b_c + ",:a_cdanh,:a_ns_hientai,:a_dinhbien_t1,:a_dinhbien_t2,:a_dinhbien_t3,:a_dinhbien_t4,:a_dinhbien_t5,:a_dinhbien_t6,:a_dinhbien_t7,:a_dinhbien_t8,:a_dinhbien_t9,:a_dinhbien_t10,:a_dinhbien_t11,:a_dinhbien_t12";
            b_c = b_c + ",:a_phatsinh_t1,:a_phatsinh_t2,:a_phatsinh_t3,:a_phatsinh_t4,:a_phatsinh_t5,:a_phatsinh_t6,:a_phatsinh_t7,:a_phatsinh_t8,:a_phatsinh_t9,:a_phatsinh_t10,:a_phatsinh_t11,:a_phatsinh_t12";
            b_c = b_c + ",:a_tong_t1,:a_tong_t2,:a_tong_t3,:a_tong_t4,:a_tong_t5,:a_tong_t6,:a_tong_t7,:a_tong_t8,:a_tong_t9,:a_tong_t10,:a_tong_t11,:a_tong_t12";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_DBIEN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_HDNS_DBIEN_CT(string b_nam, string b_donvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_donvi }, "PNS_HDNS_DBIEN_CT");
    }

    public static DataTable Fdt_NS_HDNS_DBIEN_EXP(string b_nam, string b_donvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_donvi }, "PNS_HDNS_DBIEN_EXP");
    }

    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_DBIEN_XOA(string b_nam, string b_donvi)
    {
        dbora.P_GOIHAM(new object[] { b_nam, b_donvi }, "PNS_HDNS_DBIEN_XOA");
    }

    public static void Fdt_NS_TD_DINHBIEN_IMP_NH(DataTable dtData)
    {
        bang.P_CSO_SO(ref dtData, "nam,ns_hientai,sl_dinhbien,sl_dbien_ps,tong_dbien,sl_truyen_d,sl_ctruyen,sl_truyen_cl,sl_nghiviec");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = dtData.Rows[0];

            object[] a_nam = bang.Fobj_COL_MANG(dtData, "NAM");
            object[] a_donvi = bang.Fobj_COL_MANG(dtData, "DONVI");
            object[] a_ban = bang.Fobj_COL_MANG(dtData, "BAN");
            object[] a_phong = bang.Fobj_COL_MANG(dtData, "PHONG");
            object[] a_cdanh = bang.Fobj_COL_MANG(dtData, "CDANH");
            object[] a_ns_hientai = bang.Fobj_COL_MANG(dtData, "NS_HIENTAI");
            object[] a_sl_dbien = bang.Fobj_COL_MANG(dtData, "SL_DINHBIEN");
            object[] a_sl_dbien_ps = bang.Fobj_COL_MANG(dtData, "SL_DBIEN_PS");
            object[] a_tong_dbien = bang.Fobj_COL_MANG(dtData, "TONG_DBIEN");
            object[] a_sl_truyen_d = bang.Fobj_COL_MANG(dtData, "SL_TRUYEN_D");
            object[] a_sl_ctruyen = bang.Fobj_COL_MANG(dtData, "SL_CTRUYEN");
            object[] a_sl_truyen_cl = bang.Fobj_COL_MANG(dtData, "SL_TRUYEN_CL");
            object[] a_sl_nghiviec = bang.Fobj_COL_MANG(dtData, "SL_NGHIVIEC");
            object[] a_ghichu = bang.Fobj_COL_MANG(dtData, "GHICHU");
            //thêm parameter
            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'S', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ban", 'S', a_ban);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ns_hientai", 'N', a_ns_hientai);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_dbien", 'N', a_sl_dbien);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_dbien_ps", 'N', a_sl_dbien_ps);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_dbien", 'N', a_tong_dbien);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_truyen_d", 'N', a_sl_truyen_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_ctruyen", 'N', a_sl_ctruyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_truyen_cl", 'N', a_sl_truyen_cl);
            dbora.P_THEM_PAR(ref b_lenh, "a_sl_nghiviec", 'N', a_sl_nghiviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = ",:a_nam,:a_donvi,:a_ban,:a_phong,:a_cdanh,:a_ns_hientai,:a_sl_dbien,:a_sl_dbien_ps,:a_tong_dbien,:a_sl_truyend,:a_sl_ctruyen,:a_sl_truyen_cl,:a_sl_nghiviec,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDNS_DBIEN_IMP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_HDNS_DBIEN, TEN_BANG.NS_HDNS_DBIEN);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion ĐỊNH BIÊN NHÂN SỰ

    #region LỊCH SỬ ĐIỀU CHỈNH ĐỊNH BIÊN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Faobj_NS_HDNS_LSDBIEN_LKE(string b_nam, string b_donvi, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_donvi, b_tu_n, b_den_n }, "NR", "PNS_HDNS_LSDBIEN_LKE");
    }
    public static DataTable Fdt_NS_HDNS_LSDBIEN_CT(string b_nam, string b_lansua)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_lansua }, "PNS_HDNS_LSDBIEN_CT");
    }
    #endregion LỊCH SỬ ĐIỀU CHỈNH ĐỊNH BIÊN

    #region PHÂN TÍCH NGUỒN LỰC
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_HDNS_PT_NGUONLUC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHDNS_PT_NGUONLUC_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_HDNS_PT_NGUONLUC_MA(string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_thang, b_trangkt }, "NNR", "PHDNS_PT_NGUONLUC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable P_Fs_HDNS_PT_NGUONLUC_NH(double b_thang, DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_phong = bang.Fobj_COL_MANG(b_dt_db, "PHONG");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_db, "CDANH");
            object[] a_ns_hientai = bang.Fobj_COL_MANG(b_dt_db, "NS_HIENTAI");
            object[] a_ns_thangtien = bang.Fobj_COL_MANG(b_dt_db, "NS_THANGTIEN");
            object[] a_cdanh_thangtien = bang.Fobj_COL_MANG(b_dt_db, "CDANH_THANGTIEN");
            object[] a_ns_dukien_ts = bang.Fobj_COL_MANG(b_dt_db, "NS_DUKIEN_TS");
            object[] a_ns_dukien_nv = bang.Fobj_COL_MANG(b_dt_db, "NS_DUKIEN_NV");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_db, "GHICHU");

            dbora.P_THEM_PAR(ref b_lenh, "b_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "b_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_ns_hientai", 'N', a_ns_hientai);
            dbora.P_THEM_PAR(ref b_lenh, "b_ns_thangtien", 'N', a_ns_thangtien);
            dbora.P_THEM_PAR(ref b_lenh, "b_cdanh_thangtien", 'N', a_cdanh_thangtien);
            dbora.P_THEM_PAR(ref b_lenh, "b_ns_dukien_ts", 'N', a_ns_dukien_ts);
            dbora.P_THEM_PAR(ref b_lenh, "b_ns_dukien_nv", 'N', a_ns_dukien_nv);
            dbora.P_THEM_PAR(ref b_lenh, "b_ghichu", 'U', a_ghichu);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_thang) + ",:b_phong,:b_cdanh,:b_ns_hientai,:b_ns_thangtien,:b_cdanh_thangtien,:b_ns_dukien_ts,:b_ns_dukien_nv,:b_ghichu,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHDNS_PT_NGUONLUC_NH(" + b_se.tso + b_c + "); end;";
            try
            {

                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_HDNS_PT_NGUONLUC_CT(string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang) }, "PHDNS_PT_NGUONLUC_CT");
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_HDNS_PT_NGUONLUC_XOA(string b_thang)
    {
        dbora.P_GOIHAM(chuyen.CTH_SO(b_thang), "PHDNS_PT_NGUONLUC_XOA");
    }
    #endregion PHÂN TÍCH NGUỒN LỰC

    #region KẾ HOẠCH TUYỂN DỤNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_HDNS_KH_TUYENDUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHDNS_KH_TUYENDUNG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_HDNS_KH_TUYENDUNG_MA(string b_ma, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_nam, b_trangkt }, "NNR", "PHDNS_KH_TUYENDUNG_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable P_Fs_HDNS_KH_TUYENDUNG_NH(DataTable b_dt, DataTable b_dt_db)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_db, "PHONG");
            object[] a_ten_ncdanh = bang.Fobj_COL_MANG(b_dt_db, "TEN_NCDANH");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt_db, "TEN_CDANH");
            object[] a_ncdanh = bang.Fobj_COL_MANG(b_dt_db, "NCDANH");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_db, "CDANH");
            object[] a_bcdanh = bang.Fobj_COL_MANG(b_dt_db, "BCDANH");
            object[] a_heso = bang.Fobj_COL_MANG(b_dt_db, "HESO");
            object[] a_khoach_ngay = bang.Fobj_COL_MANG(b_dt_db, "KHOACH_NGAY");
            object[] a_soluong_cantuyen = bang.Fobj_COL_MANG(b_dt_db, "SOLUONG_CANTUYEN");
            object[] a_ngay_dl = bang.Fobj_COL_MANG(b_dt_db, "NGAY_DL");
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt_db, "LYDO");
            object[] a_bophan_yc = bang.Fobj_COL_MANG(b_dt_db, "BOPHAN_YC");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_db, "GHICHU");

            dbora.P_THEM_PAR(ref b_lenh, "b_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "b_ten_ncdanh", 'U', a_ten_ncdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_ten_cdanh", 'U', a_ten_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_ncdanh", 'U', a_ncdanh);

            dbora.P_THEM_PAR(ref b_lenh, "b_cdanh", 'U', a_cdanh);

            dbora.P_THEM_PAR(ref b_lenh, "b_bcdanh", 'U', a_bcdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_heso", 'N', a_heso);
            dbora.P_THEM_PAR(ref b_lenh, "b_khoach_ngay", 'N', a_khoach_ngay);
            dbora.P_THEM_PAR(ref b_lenh, "b_soluong_cantuyen", 'N', a_soluong_cantuyen);
            dbora.P_THEM_PAR(ref b_lenh, "b_ngay_dl", 'N', a_ngay_dl);
            dbora.P_THEM_PAR(ref b_lenh, "b_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "b_bophan_yc", 'U', a_bophan_yc);
            dbora.P_THEM_PAR(ref b_lenh, "b_ghichu", 'U', a_ghichu);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_N(dr["nam"]) + "," + chuyen.OBJ_C(dr["thang"]) + "," + chuyen.OBJ_C(dr["MA"]) + "," + chuyen.OBJ_C(dr["TEN"]) + ",:b_phong,:b_ten_ncdanh,:b_ten_cdanh,:b_ncdanh,:b_cdanh,:b_bcdanh,:b_heso,:b_khoach_ngay,:b_soluong_cantuyen,:b_ngay_dl,:b_lydo,:b_bophan_yc,:b_ghichu,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHDNS_KH_TUYENDUNG_NH(" + b_se.tso + b_c + "); end;";
            try
            {

                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_HDNS_DINHBIEN_DONVI(string b_donvi, string b_nam, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_donvi }, "PHDNS_DINHBIEN_DONVI");
    }
    public static DataTable Fdt_HDNS_KH_TUYENDUNG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PHDNS_KH_TUYENDUNG_CT");
    }

    ///<summary> Xóa </summary>
    public static void P_Fs_HDNS_KH_TUYENDUNG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHDNS_KH_TUYENDUNG_XOA");
    }
    #endregion  KẾ HOẠCH TUYỂN DỤNG

    #region CẬP NHẬT ỨNG VIÊN TRÚNG TUYỂN

    public static DataTable Fdt_NS_TD_CAPNHAT_UV_LKE_DS(string b_yeucau)
    {
        return dbora.Fdt_LKE_S(new object[] { b_yeucau }, "PS_TD_CAPNHAT_UV_LKE_DS");
    }
    public static string P_NS_TD_CAPNHAT_UV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phongban_ct"]) + "," +
                chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["thoigian_tv"]) + "," +
                chuyen.OBJ_C(b_dr["diadiem_lv"]) + "," + chuyen.OBJ_C(b_dr["thoigian_lv"]) + "," + chuyen.OBJ_C(b_dr["cdanh_ql"]) + "," + chuyen.OBJ_C(b_dr["ten_ql"]) + "," +
                chuyen.OBJ_C(b_dr["ma_ql"]) + "," + chuyen.OBJ_S(b_dr["luong_cb"]) + "," + chuyen.OBJ_S(b_dr["thuong_cv"]) + "," + chuyen.OBJ_S(b_dr["thunhap"]) + "," + chuyen.OBJ_S(b_dr["phantram_tv"]) + "," +
                chuyen.OBJ_C(b_dr["trangthai"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_S(b_dr["ngay_offer"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_CAPNHAT_UV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_TD_CAPNHAT_UV_MA(string b_so_id, string b_nam, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CSO_SO(b_nam), b_ma, b_trangkt }, "NNR", "PNS_TD_CAPNHAT_UV_MA");
    }
    public static object[] Faobj_NS_TD_CAPNHAT_UV_LKE(string b_nam, string b_ma, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma, b_tu, b_den }, "NR", "PNS_TD_CAPNHAT_UV_LKE");
    }
    public static DataTable Fdt_NS_TD_CAPNHAT_UV_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_TD_CAPNHAT_UV_CT");
    }
    public static void P_NS_TD_CAPNHAT_UV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TD_CAPNHAT_UV_XOA");
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_TD_CAPNHAT_UV_EXCEL()
    {
        return dbora.Fdt_LKE("PNS_TD_CAPNHAT_UV_EXPORT");
    }
    #endregion

    #region CHUYỂN ỨNG VIÊN THÀNH NHÂN VIÊN
    public static DataTable Fdt_NS_TD_CHUYEN_UV_NV_CT(string b_nam, string yeucau_td)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), yeucau_td }, "NS_TD_CHUYEN_UV_NV_CT");
    }

    public static DataTable Fdt_NS_TD_THUTUC_CT(string ma_dx)
    {
        return dbora.Fdt_LKE_S(new object[] { ma_dx }, "NS_TD_THUTUC_CT");
    }

    public static DataTable Fs_NS_TD_THUTUC_LKE()
    {
        return dbora.Fdt_LKE("PNS_TV_LKE_THUTUC_TN");
    }

    public static DataTable Fdt_NS_TD_CHUYEN_UV_NV_LKE_ALL()
    {
        return dbora.Fdt_LKE("NS_TD_CHUYEN_UV_NV_LKE_ALL");
    }
    public static object[] Fdt_NS_TD_CHUYEN_UV_NV_LKE(string b_nam, string b_ma, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma, b_tu, b_den }, "NR", "NS_TD_CHUYEN_UV_NV_LKE");
    }
    public static DataTable Fdt_NS_TD_CHUYEN_UV_NV_LKE_DS(string b_nam, string b_yeucau)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_yeucau }, "NS_TD_CHUYEN_UV_NV_LKE_DS");
    }

    public static void P_NS_TD_CHUYEN_UV_NV_NH(DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_tt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngay_dl_tt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_dl_tt");
            object[] a_ma_nv = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_trangthai = bang.Fobj_COL_MANG(b_dt_ct, "trangthai");

            object[] a_ma_thutuc = bang.Fobj_COL_MANG(b_dt_tt, "ma");
            object[] a_is_check = bang.Fobj_COL_MANG(b_dt_tt, "chon");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_dl_tt", 'N', a_ngay_dl_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nv", 'S', a_ma_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai", 'S', a_trangthai);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_thutuc", 'S', a_ma_thutuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_is_check", 'S', a_is_check);

            string b_c = "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," + chuyen.OBJ_C(b_dr["ten_cdanh"]) + "," + chuyen.OBJ_C(b_dr["ten_phong"])
                + ",:a_so_the,:a_ngay_dl_tt,:a_ma_nv,:a_trangthai,:a_ma_thutuc,:a_is_check";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".NS_TD_CHUYEN_UV_NV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void PNS_TD_CHUYEN_UV_KHO_NH(DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_tt)
    {
        bang.P_CNG_SO(ref b_dt_ct, "ngay_dl_tt");

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngay_dl_tt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_dl_tt");
            object[] a_ma_nv = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");

            object[] a_ma_thutuc = bang.Fobj_COL_MANG(b_dt_tt, "ma");
            object[] a_is_check = bang.Fobj_COL_MANG(b_dt_tt, "chon");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_dl_tt", 'N', a_ngay_dl_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nv", 'S', a_ma_nv);

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_thutuc", 'S', a_ma_thutuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_is_check", 'S', a_is_check);

            string b_c = "," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["mayeucau_td"]) + "," + chuyen.OBJ_C(b_dr["ten_cdanh"]) + "," + chuyen.OBJ_C(b_dr["ten_phong"])
                + ",:a_so_the,:a_ngay_dl_tt,:a_ma_nv,:a_ma_thutuc,:a_is_check";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".NS_TD_CHUYEN_UV_KHO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void PNS_TD_CHUYEN_UV_NV_XOA(string b_nam, string yeucau_td)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_nam), yeucau_td }, "NS_TD_CHUYEN_UV_NV_XOA");
    }
    #endregion

    #region "THỐNG KÊ DASHBOAD"
    public static DataSet Fdt_NS_THONGBAO_THONGKE_CT(string b_ma)
    {
        return dbora.Fds_LKE(2, "PNS_THONGBAO_THONGKE_NHANSU");
    }
    public static DataTable Fdt_NS_THONGBAO_BDNS_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_ma), "PNS_THONGBAO_THONGKE_BDNS");
    }
    public static DataTable Fdt_NS_THONGBAO_TALENT_CT(string b_ncdanh, string b_ky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ncdanh, b_ky }, "PNS_THONGBAO_TALENT_CT");
    }
    #endregion

    #region QUẢN LÝ PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG
    public static object[] Fdt_NS_TD_PD_CDANH_TD_QL_LKE(string b_nam, string b_ma_dx, string b_tinhtrang, string b_so_the_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_ma_dx, b_tinhtrang, b_so_the_tk, b_tu, b_den }, "NR", "PNS_TD_PD_CDANH_TD_QL_LKE");
    }
    public static DataSet Fdt_NS_TD_PD_CDANH_TD_QL_EXCEL(string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_so_the }, 7, "Fdt_NS_TD_PD_CDANH_TD_QL_EXCEL");
    }

    public static DataTable Fdt_NS_TD_PD_CDANH_TD_QL_PHEDUYET(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_PD_CDANH_TD_QL_PDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_TD_PD_CDANH_TD_QL_KOPHEDUYET(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TD_PD_CDANH_TD_QL_KPD(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion

}