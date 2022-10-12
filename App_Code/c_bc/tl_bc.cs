using System;
using System.Data;
using System.Web;
using Oracle.DataAccess.Client;
using Cthuvien;

public class tl_bc
{
    /// <summary>Chuẩn chạy báo cáo</summary>
    public static DataSet Fds_CHAYBC(string b_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_kq = new DataSet();
        switch (b_ma.ToLower())
        {
            case "r_ns_tl_tam_ung":
                b_kq = Fds_NS_TL_TAM_UNG(b_tso, b_ma, b_ddan, b_tenrp);
                break;
            case "r_ns_tl_nhang":
                b_kq = Fds_NS_TL_NHANG(b_tso, b_ma, b_ddan, b_tenrp);
                break;
        }
        return b_kq;
    }

    public static DataSet Fds_NS_TL_TAM_UNG(string b_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataSet b_ds_kq = dbora.Fds_LKE(chuyen.CSO_SO(b_tso), 2, "BNS_TL_TU");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        
        // Ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        // Tham so cua bao cao
        DataRow b_dr_1 = b_dt_0.Rows[0];
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_ct, b_se.ten_dvi, b_dr_1["b_thang"], b_dr_1["b_phong"], b_se.nsd });
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }

    public static DataSet Fds_NS_TL_NHANG(string b_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        string[] a_tso = b_tso.Split(new Char[] { '#' });
        b_dt = dbora.Fdt_LKE_S(new object[] { a_tso[0], chuyen.CTH_SO(a_tso[1]) }, "BNS_TL_BL");

        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        // Tham so cua bao cao

        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        string b_phong = a_tso[2], b_nhang = "Techcombank", b_sl_chuyen_chu, b_tong_tien_chu, b_sotk = "12345";
        int b_sl_chuyen = 0, b_tong_tien = 0;
        for (int i = 0; i < b_dt.Rows.Count; i++)
            if (Int32.Parse(b_dt.Rows[i]["tien"].ToString()) != 0)
            {
                b_sl_chuyen++;
                b_tong_tien += Int32.Parse(b_dt.Rows[i]["tien"].ToString());
            }
        b_sl_chuyen_chu = c_docso.sochu(b_sl_chuyen, "V");
        b_tong_tien_chu = c_docso.sochu(b_tong_tien, "V");
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_dvi, b_phong, b_nhang, b_sl_chuyen, b_sl_chuyen_chu, b_tong_tien, b_tong_tien_chu, b_sotk, b_se.nsd });
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }

    #region TỰ KHAI BÁO CÁO TIỀN LƯƠNG
    /// <summary>Liệt kê chi tiết theo ma nv</summary>
    public static DataTable Fdt_TL_TKBC_CT_LKE(string b_ma_bc, string b_ma)
	{
        return dbora.Fdt_LKE_S(new object[] { b_ma_bc, b_ma }, "PTL_TKBC_CT_LKE");
    }
    /// <summary>Nhập theo nghiệp vụ</summary>
    public static void P_TL_TKBC_CH_NH(string b_ma, DataTable b_dt_tso, DataTable b_dt, DataTable b_dt_ct)
    {
        if (b_dt.Rows.Count == 0) throw new Exception("loi:Không có số liệu cột!:loi");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt_tso.Rows[0];
            if (b_dt_ct.Rows.Count == 0)
                bang.P_THEM_HANG(ref b_dt_ct, new string[] { "thangt", "loai", "truy", "bt" }, new object[] { 0, "CH", "K", 1 });

            // Chung
            object[] a_tt = bang.Fobj_COL_MANG(b_dt, "tt");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_ma_ct = bang.Fobj_COL_MANG(b_dt, "ma_ct");
            // Chi tiet
            object[] a_thangt = bang.Fobj_COL_MANG(b_dt_ct, "thangt");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt_ct, "loai");
            object[] a_truy = bang.Fobj_COL_MANG(b_dt_ct, "truy");
            object[] a_bt = bang.Fobj_COL_MANG(b_dt_ct, "bt");

            // Them para chung
            dbora.P_THEM_PAR(ref b_lenh, "tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "ma_ct", 'S', a_ma_ct);
            // Them para chung
            dbora.P_THEM_PAR(ref b_lenh, "thangt", 'S', a_thangt);
            dbora.P_THEM_PAR(ref b_lenh, "loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "truy", 'S', a_truy);
            dbora.P_THEM_PAR(ref b_lenh, "bt", 'N', a_bt);

            string b_c = "," + chuyen.OBJ_C(b_dr["ma_bc"]) + "," + chuyen.OBJ_C(b_dr["ht"]) + "," + chuyen.OBJ_S(b_dr["nam"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["thangd"]) + "," + chuyen.OBJ_C(b_dr["thangc"]) + "," + chuyen.OBJ_C(b_dr["ten_bc"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_ma) + ",:tt,:ma,:ten,:ma_ct,:thangt,:loai,:truy,:bt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PTL_TKBC_CH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion TỰ KHAI BÁO CÁO TIỀN LƯƠNG

    #region LẤY SỐ LIỆU
    // Liet ke theo nhom. hoac chi tiet ma
    public static DataTable Fdt_LKE(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PTL_TKBC_CH_LKE");
    }
    #endregion
}