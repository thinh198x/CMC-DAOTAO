using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class tl_cc
{
    #region CHẤM CÔNG CÔNG NHẬT CHI TIẾT


    public static DataSet Fdt_TL_PHANCA_LKE(string b_loai, string b_thang, string b_ngaybd, string b_phong)
    {
        string b_ngayd = "";
        string b_ngaykt = "";
        DataTable b_kycong = tl_ma.Fdt_TL_MA_KYLUONG_BY_ID(chuyen.OBJ_N(b_thang));
        bang.P_SO_CNG(ref b_kycong, "ngay_bd");
        bang.P_SO_CNG(ref b_kycong, "ngay_kt");
        if (b_kycong.Rows.Count > 0)
        {
            b_ngayd = b_kycong.Rows[0]["Ngay_bd"].ToString();
            b_ngaykt = b_kycong.Rows[0]["Ngay_kt"].ToString();
        }
        double ngaylam = 0;
        int a = 0, b = 0,
        b_ngay_dau = Int32.Parse(b_ngayd.Substring(0, 2)),
        b_thang_dau = Int32.Parse(b_ngayd.Substring(3, 2)),
        b_nam_dau = Int32.Parse(b_ngayd.Substring(6, 4));

        DateTime b_nd = new DateTime(b_nam_dau, b_thang_dau, b_ngay_dau);
        int b_so_ngay = chuyen.OBJ_I(b_kycong.Rows[0]["so_ngay"].ToString()); // DateTime.DaysInMonth(b_nam_dau, b_thang_dau);
        ngaylam = chuyen.OBJ_N(b_kycong.Rows[0]["cong_chuan"].ToString());
        DataTable b_dt = bang.Fdt_TAO_BANG(
            new string[] { "DAYS", "DD" }, new object[] { "S", "S" });

        for (int i = 0; i < b_so_ngay; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new string[] { "DAYS", "DD" },
                new object[] { b_nd.DayOfWeek.ToString(), b_nd.Day });
            b_nd = b_nd.AddDays(1);
        }

        foreach (DataRow b_dr in b_dt.Rows)
        {
            switch (b_dr["DAYS"].ToString())
            {
                case "Monday":
                    b_dr["DAYS"] = "T.2";
                    break;
                case "Tuesday":
                    b_dr["DAYS"] = "T.3";
                    break;
                case "Wednesday":
                    b_dr["DAYS"] = "T.4";
                    break;
                case "Thursday":
                    b_dr["DAYS"] = "T.5";
                    break;
                case "Friday":
                    b_dr["DAYS"] = "T.6";
                    break;
                case "Saturday":
                    b_dr["DAYS"] = "T.7";
                    a = a + 1;
                    break;
                case "Sunday":
                    b_dr["DAYS"] = "CN";
                    b = b + 1;
                    break;
            }
            if (b_dr["DD"].ToString().Length == 1)
                b_dr["DD"] = "0" + b_dr["DD"];
        }
        DataTable b_dtngay = bang.Fdt_TAO_BANG(
            new string[] {"n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10",
                    "n11", "n12", "n13", "n14", "n15", "n16", "n17", "n18", "n19", "n20",
                    "n21", "n22", "n23", "n24", "n25", "n26", "n27", "n28", "n29", "n30","n31","TT" },
            new object[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S","S","S"});
        //lay thu
        object[] str_days = bang.Fobj_COL_MANG(b_dt, "DAYS");
        // lay ngay
        object[] str_dd = bang.Fobj_COL_MANG(b_dt, "DD");

        //ghep cac gia tri thu,ngay, thang vao bang b_dtngay

        bang.P_THEM_HANG(ref b_dtngay, str_days, 0);
        bang.P_THEM_HANG(ref b_dtngay, str_dd, 1);
        DataTable tem_ngay = bang.Fdt_TAO_BANG("TT", "S");
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Thứ" }, 0);
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Ngày" }, 1);
        //gan gia tri cot TT
        bang.P_DAT_GTRI_N(ref b_dtngay, tem_ngay, 0);
        //cot so ngay T7, CN
        //bang.P_THEM_COL(ref b_dtngay, "T7", a);
        //bang.P_THEM_COL(ref b_dtngay, "CN", b);
        /* lay so ngay lam viec trong thang */
        // lay so ngay lam viec tuan
        DataTable b_dtngaytuan = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang), b_phong }, "PNS_TL_TLAP_THOILUONG_TRA");
        //if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5) ngaylam = b_so_ngay - a - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5.5) ngaylam = b_so_ngay - a / 2 - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 6) ngaylam = b_so_ngay - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 7) ngaylam = b_so_ngay;
        //if (b_dtngaytuan.Rows.Count > 0)
        //{
        //    switch (chuyen.OBJ_S(b_dtngaytuan.Rows[0]["songay"]))
        //    {
        //        case "5": ngaylam = b_so_ngay - a - b;
        //            break;
        //        case "5.50": ngaylam = b_so_ngay - a / 2 - b;
        //            break;
        //        case "6": ngaylam = b_so_ngay - b;
        //            break;
        //        case "6.50": ngaylam = b_so_ngay - b / 2;
        //            break;
        //        case "7": ngaylam = b_so_ngay;
        //            break;
        //    }
        //}
        string b_calv = "";
        DataTable b_ca = null;
        if (b_loai == "2")
        {
            b_ca = tl_ma.Fdt_CC_MA_CC_TOP();
        }
        else
        {
            b_ca = tl_ma.Fdt_CC_MA_CA_TOP();
        }
        if (b_ca == null || b_ca.Rows.Count <= 0)
        {
            b_calv = "";
        }
        else
            b_calv = b_ca.Rows[0]["MA"].ToString();

        DataTable b_dtct = bang.Fdt_TAO_BANG(new string[] { "T7", "CN", "ngaylam", "NGAYD", "NGAYKT", "tu_ngay", "toi_ngay" }, new string[] { "I", "I", "I", "I", "I", "I", "I" });
        bang.P_THEM_HANG(ref b_dtct, new object[] { a, b, ngaylam, b_ngayd, b_ngaykt, b_ngay_dau, b_so_ngay });
        DataTable b_tt = bang.Fdt_TAO_BANG(new string[] { "tu_ngay", "toi_ngay", "MA_MDINH" }, new string[] { "I", "I", "I" });
        bang.P_THEM_HANG(ref b_tt, new object[] { "01", 31, b_calv });

        DataSet b_kq = new DataSet();
        b_kq.Tables.Add(b_dtct); b_kq.Tables.Add(b_dtngay);
        b_kq.Tables.Add(b_tt);
        return b_kq;
    }
    ///<summary>Liệt kê ngày tháng chấm công</summary>
    public static DataSet Fdt_TEM_NGAY_LKE(string b_loai, string b_thang, string b_ngaybd, string b_phong)
    {
        string b_ngayd = "";
        string b_ngaykt = "";
        //DataTable b_kycong = tl_ma.Fdt_TL_MA_KYLUONG_BY_ID(chuyen.OBJ_N(b_thang));
        DataTable b_kycong = tl_ma.Fdt_TL_MA_KYLUONG_BY_DVID(b_phong, chuyen.OBJ_N(b_thang));
        bang.P_SO_CNG(ref b_kycong, "ngay_bd");
        bang.P_SO_CNG(ref b_kycong, "ngay_kt");
        if (b_kycong.Rows.Count > 0)
        {
            b_ngayd = b_kycong.Rows[0]["Ngay_bd"].ToString();
            b_ngaykt = b_kycong.Rows[0]["Ngay_kt"].ToString();
        }
        double ngaylam = 0;
        int a = 0, b = 0,
        b_ngay_dau = Int32.Parse(b_ngayd.Substring(0, 2)),
        b_thang_dau = Int32.Parse(b_ngayd.Substring(3, 2)),
        b_nam_dau = Int32.Parse(b_ngayd.Substring(6, 4)),
        b_ngay_cuoi = Int32.Parse(b_ngaykt.Substring(0, 2));
        DateTime b_nd = new DateTime(b_nam_dau, b_thang_dau, b_ngay_dau);
        int b_so_ngay = chuyen.OBJ_I(b_kycong.Rows[0]["so_ngay"].ToString()); // DateTime.DaysInMonth(b_nam_dau, b_thang_dau);
        ngaylam = chuyen.OBJ_N(b_kycong.Rows[0]["cong_chuan"].ToString());
        DataTable b_dt = bang.Fdt_TAO_BANG(
            new string[] { "DAYS", "DD" }, new object[] { "S", "S" });

        for (int i = 0; i < b_so_ngay; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new string[] { "DAYS", "DD" },
                new object[] { b_nd.DayOfWeek.ToString(), b_nd.Day });
            b_nd = b_nd.AddDays(1);
        }

        foreach (DataRow b_dr in b_dt.Rows)
        {
            switch (b_dr["DAYS"].ToString())
            {
                case "Monday":
                    b_dr["DAYS"] = "T.2";
                    break;
                case "Tuesday":
                    b_dr["DAYS"] = "T.3";
                    break;
                case "Wednesday":
                    b_dr["DAYS"] = "T.4";
                    break;
                case "Thursday":
                    b_dr["DAYS"] = "T.5";
                    break;
                case "Friday":
                    b_dr["DAYS"] = "T.6";
                    break;
                case "Saturday":
                    b_dr["DAYS"] = "T.7";
                    a = a + 1;
                    break;
                case "Sunday":
                    b_dr["DAYS"] = "CN";
                    b = b + 1;
                    break;
            }
            if (b_dr["DD"].ToString().Length == 1)
                b_dr["DD"] = "0" + b_dr["DD"];
        }
        DataTable b_dtngay = bang.Fdt_TAO_BANG(
            new string[] {"n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10",
                    "n11", "n12", "n13", "n14", "n15", "n16", "n17", "n18", "n19", "n20",
                    "n21", "n22", "n23", "n24", "n25", "n26", "n27", "n28", "n29", "n30","n31","TT" },
            new object[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S","S","S"});
        //lay thu
        object[] str_days = bang.Fobj_COL_MANG(b_dt, "DAYS");
        // lay ngay
        object[] str_dd = bang.Fobj_COL_MANG(b_dt, "DD");

        //ghep cac gia tri thu,ngay, thang vao bang b_dtngay

        bang.P_THEM_HANG(ref b_dtngay, str_days, 0);
        bang.P_THEM_HANG(ref b_dtngay, str_dd, 1);
        DataTable tem_ngay = bang.Fdt_TAO_BANG("TT", "S");
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Thứ" }, 0);
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Ngày" }, 1);
        //gan gia tri cot TT
        bang.P_DAT_GTRI_N(ref b_dtngay, tem_ngay, 0);
        //cot so ngay T7, CN
        //bang.P_THEM_COL(ref b_dtngay, "T7", a);
        //bang.P_THEM_COL(ref b_dtngay, "CN", b);
        /* lay so ngay lam viec trong thang */
        // lay so ngay lam viec tuan
        DataTable b_dtngaytuan = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang), b_phong }, "PNS_TL_TLAP_THOILUONG_TRA");
        //if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5) ngaylam = b_so_ngay - a - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5.5) ngaylam = b_so_ngay - a / 2 - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 6) ngaylam = b_so_ngay - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 7) ngaylam = b_so_ngay;
        //if (b_dtngaytuan.Rows.Count > 0)
        //{
        //    switch (chuyen.OBJ_S(b_dtngaytuan.Rows[0]["songay"]))
        //    {
        //        case "5": ngaylam = b_so_ngay - a - b;
        //            break;
        //        case "5.50": ngaylam = b_so_ngay - a / 2 - b;
        //            break;
        //        case "6": ngaylam = b_so_ngay - b;
        //            break;
        //        case "6.50": ngaylam = b_so_ngay - b / 2;
        //            break;
        //        case "7": ngaylam = b_so_ngay;
        //            break;
        //    }
        //}
        string b_calv, b_canghi = "";
        DataTable b_ca = null;
        if (b_loai == "2")
        {
            b_ca = tl_ma.Fdt_CC_MA_CC_TOP();
        }
        else
        {
            b_ca = tl_ma.Fdt_CC_MA_CA_TOP();
        }
        if (b_ca == null || b_ca.Rows.Count <= 0)
        {
            b_calv = "";
            b_canghi = "";
        }
        else
        {
            b_calv = b_ca.Rows[0]["MA"].ToString();
            b_canghi = b_ca.Rows[0]["NGHI_7_CN"].ToString();
        }

        DataTable b_dtct = bang.Fdt_TAO_BANG(new string[] { "T7", "CN", "ngaylam", "NGAYD", "NGAYKT", "tu_ngay", "toi_ngay", "phong", "kyluong" }, new string[] { "I", "I", "I", "I", "I", "I", "I", "S", "I" });
        bang.P_THEM_HANG(ref b_dtct, new object[] { a, b, ngaylam, b_ngayd, b_ngaykt, b_ngay_dau, b_so_ngay, b_phong, b_thang });
        DataTable b_tt = bang.Fdt_TAO_BANG(new string[] { "tu_ngay", "toi_ngay", "MA_MDINH", "CANGHI" }, new string[] { "I", "I", "I", "I" });
        bang.P_THEM_HANG(ref b_tt, new object[] { "01", "31", b_calv, b_canghi });

        DataSet b_kq = new DataSet();
        b_kq.Tables.Add(b_dtct); b_kq.Tables.Add(b_dtngay);
        b_kq.Tables.Add(b_tt);
        return b_kq;
    }
    public static string PCC_PHANCA_FILE_NH(DataTable b_dt_cc, string b_kyluong)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_cc, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_cc, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_cc, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_cc, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_cc, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_cc, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_cc, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_cc, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_cc, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_cc, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_cc, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_cc, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_cc, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_cc, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_cc, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_cc, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_cc, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_cc, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_cc, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_cc, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_cc, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_cc, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_cc, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_cc, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_cc, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_cc, "n25");
            object[] a_n26 = bang.Fobj_COL_MANG(b_dt_cc, "n26");
            object[] a_n27 = bang.Fobj_COL_MANG(b_dt_cc, "n27");
            object[] a_n28 = bang.Fobj_COL_MANG(b_dt_cc, "n28");
            object[] a_n29 = bang.Fobj_COL_MANG(b_dt_cc, "n29");
            object[] a_n30 = bang.Fobj_COL_MANG(b_dt_cc, "n30");
            object[] a_n31 = bang.Fobj_COL_MANG(b_dt_cc, "n31");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'S', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'S', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'S', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'S', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'S', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'S', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'S', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'S', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'S', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'S', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'S', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'S', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'S', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'S', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'S', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'S', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'S', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'S', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'S', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'S', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'S', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'S', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'S', a_n25);
            dbora.P_THEM_PAR(ref b_lenh, "a_n26", 'S', a_n26);
            dbora.P_THEM_PAR(ref b_lenh, "a_n27", 'S', a_n27);
            dbora.P_THEM_PAR(ref b_lenh, "a_n28", 'S', a_n28);
            dbora.P_THEM_PAR(ref b_lenh, "a_n29", 'S', a_n29);
            dbora.P_THEM_PAR(ref b_lenh, "a_n30", 'S', a_n30);
            dbora.P_THEM_PAR(ref b_lenh, "a_n31", 'S', a_n31);

            string b_c = "," + chuyen.OBJ_N(b_kyluong).ToString();
            b_c = b_c + ",:a_so_the,:a_ten,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8,:a_n9,:a_n10,:a_n11,:a_n12,:a_n13,:a_n14,:a_n15,:a_n16,:a_n17";
            b_c = b_c + ",:a_n18,:a_n19,:a_n20,:a_n21,:a_n22,:a_n23,:a_n24,:a_n25,:a_n26,:a_n27,:a_n28,:a_n29,:a_n30,:a_n31";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_PHANCA_FILE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.TL_PHANCA, TEN_BANG.TL_PHANCA);
            }
            catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }
            return "";
        }
        finally { b_cnn.Close(); }
    }
    public static DataSet Fdt_TEM_NGAY_CC_CN_CT_LKE(string b_loai, string b_thang, string b_ngaybd, string b_phong)
    {
        string b_ngayd = "";
        string b_ngaykt = "";
        DataTable b_kycong = tl_ma.Fdt_TL_MA_KYLUONG_BY_DVID(b_phong, chuyen.OBJ_N(b_thang));
        bang.P_SO_CNG(ref b_kycong, "ngay_bd");
        bang.P_SO_CNG(ref b_kycong, "ngay_kt");
        if (b_kycong.Rows.Count > 0)
        {
            b_ngayd = b_kycong.Rows[0]["Ngay_bd"].ToString();
            b_ngaykt = b_kycong.Rows[0]["Ngay_kt"].ToString();
        }
        double ngaylam = 0;
        int a = 0, b = 0,
        b_ngay_dau = Int32.Parse(b_ngayd.Substring(0, 2)),
        b_thang_dau = Int32.Parse(b_ngayd.Substring(3, 2)),
        b_ngay_cuoi = Int32.Parse(b_ngaykt.Substring(0, 2)),
        b_nam_dau = Int32.Parse(b_ngayd.Substring(6, 4));

        DateTime b_nd = new DateTime(b_nam_dau, b_thang_dau, b_ngay_dau);
        int b_so_ngay = chuyen.OBJ_I(b_kycong.Rows[0]["so_ngay"].ToString()); // DateTime.DaysInMonth(b_nam_dau, b_thang_dau);
        ngaylam = chuyen.OBJ_N(b_kycong.Rows[0]["cong_chuan"].ToString());
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "DAYS", "DD" }, new object[] { "S", "S" });

        for (int i = 0; i < b_so_ngay; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new string[] { "DAYS", "DD" },
                new object[] { b_nd.DayOfWeek.ToString(), b_nd.Day });
            b_nd = b_nd.AddDays(1);
        }

        foreach (DataRow b_dr in b_dt.Rows)
        {
            switch (b_dr["DAYS"].ToString())
            {
                case "Monday":
                    b_dr["DAYS"] = "T.2";
                    break;
                case "Tuesday":
                    b_dr["DAYS"] = "T.3";
                    break;
                case "Wednesday":
                    b_dr["DAYS"] = "T.4";
                    break;
                case "Thursday":
                    b_dr["DAYS"] = "T.5";
                    break;
                case "Friday":
                    b_dr["DAYS"] = "T.6";
                    break;
                case "Saturday":
                    b_dr["DAYS"] = "T.7";
                    a = a + 1;
                    break;
                case "Sunday":
                    b_dr["DAYS"] = "CN";
                    b = b + 1;
                    break;
            }
            if (b_dr["DD"].ToString().Length == 1)
                b_dr["DD"] = "0" + b_dr["DD"];
        }
        DataTable b_dtngay = bang.Fdt_TAO_BANG(
            new string[] {"n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10",
                    "n11", "n12", "n13", "n14", "n15", "n16", "n17", "n18", "n19", "n20",
                    "n21", "n22", "n23", "n24", "n25", "n26", "n27", "n28", "n29", "n30","n31","TT" },
            new object[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S","S","S"});
        //lay thu
        object[] str_days = bang.Fobj_COL_MANG(b_dt, "DAYS");
        // lay ngay
        object[] str_dd = bang.Fobj_COL_MANG(b_dt, "DD");

        //ghep cac gia tri thu,ngay, thang vao bang b_dtngay

        bang.P_THEM_HANG(ref b_dtngay, str_days, 0);
        bang.P_THEM_HANG(ref b_dtngay, str_dd, 1);
        DataTable tem_ngay = bang.Fdt_TAO_BANG("TT", "S");
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Thứ" }, 0);
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Ngày" }, 1);
        //gan gia tri cot TT
        bang.P_DAT_GTRI_N(ref b_dtngay, tem_ngay, 0);
        //cot so ngay T7, CN
        //bang.P_THEM_COL(ref b_dtngay, "T7", a);
        //bang.P_THEM_COL(ref b_dtngay, "CN", b);
        /* lay so ngay lam viec trong thang */
        // lay so ngay lam viec tuan
        DataTable b_dtngaytuan = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang), b_phong }, "PNS_TL_TLAP_THOILUONG_TRA");
        //if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5) ngaylam = b_so_ngay - a - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5.5) ngaylam = b_so_ngay - a / 2 - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 6) ngaylam = b_so_ngay - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 7) ngaylam = b_so_ngay;
        //if (b_dtngaytuan.Rows.Count > 0)
        //{
        //    switch (chuyen.OBJ_S(b_dtngaytuan.Rows[0]["songay"]))
        //    {
        //        case "5": ngaylam = b_so_ngay - a - b;
        //            break;
        //        case "5.50": ngaylam = b_so_ngay - a / 2 - b;
        //            break;
        //        case "6": ngaylam = b_so_ngay - b;
        //            break;
        //        case "6.50": ngaylam = b_so_ngay - b / 2;
        //            break;
        //        case "7": ngaylam = b_so_ngay;
        //            break;
        //    }
        //}
        string b_calv, b_canghi = "";
        DataTable b_ca = null;
        if (b_loai == "2")
        {
            b_ca = tl_ma.Fdt_CC_MA_CC_TOP();
        }
        else
        {
            b_ca = tl_ma.Fdt_CC_MA_CA_TOP();
        }
        if (b_ca == null || b_ca.Rows.Count <= 0)
        {
            b_calv = "";
            b_canghi = "";
        }
        else
        {
            b_calv = b_ca.Rows[0]["MA"].ToString();
        }

        DataTable b_dtct = bang.Fdt_TAO_BANG(new string[] { "T7", "CN", "ngaylam", "NGAYD", "NGAYKT", "tu_ngay", "toi_ngay", "phong", "kyluong" }, new string[] { "I", "I", "I", "I", "I", "I", "I", "S", "I" });
        bang.P_THEM_HANG(ref b_dtct, new object[] { a, b, ngaylam, b_ngayd, b_ngaykt, b_ngay_dau, b_so_ngay, b_phong, b_thang });
        DataTable b_tt = bang.Fdt_TAO_BANG(new string[] { "tu_ngay", "toi_ngay", "MA_MDINH" }, new string[] { "I", "I", "I" });
        bang.P_THEM_HANG(ref b_tt, new object[] { "01", 31, b_calv });

        DataSet b_kq = new DataSet();
        b_kq.Tables.Add(b_dtct); b_kq.Tables.Add(b_dtngay);
        b_kq.Tables.Add(b_tt);
        return b_kq;
    }
    public static DataSet Fdt_TEM_NGAY_NAGASE_LKE(string b_thang, string b_ngayd, string b_phong)
    {
        int a = 0, b = 0, ngaylam = 0,
        b_ngay_dau = Int32.Parse(b_ngayd.Substring(0, 2)),
        b_thang_dau = Int32.Parse(b_ngayd.Substring(3, 2)),
        b_nam_dau = Int32.Parse(b_ngayd.Substring(6, 4));

        DateTime b_nd = new DateTime(b_nam_dau, b_thang_dau, b_ngay_dau);
        int b_so_ngay = DateTime.DaysInMonth(b_nam_dau, b_thang_dau);

        DataTable b_dt = bang.Fdt_TAO_BANG(
            new string[] { "DAYS", "DD" }, new object[] { "S", "S" });

        for (int i = 0; i < b_so_ngay; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new string[] { "DAYS", "DD" },
                new object[] { b_nd.DayOfWeek.ToString(), b_nd.Day });
            b_nd = b_nd.AddDays(1);
        }

        foreach (DataRow b_dr in b_dt.Rows)
        {
            switch (b_dr["DAYS"].ToString())
            {
                case "Monday":
                    b_dr["DAYS"] = "T.2";
                    break;
                case "Tuesday":
                    b_dr["DAYS"] = "T.3";
                    break;
                case "Wednesday":
                    b_dr["DAYS"] = "T.4";
                    break;
                case "Thursday":
                    b_dr["DAYS"] = "T.5";
                    break;
                case "Friday":
                    b_dr["DAYS"] = "T.6";
                    break;
                case "Saturday":
                    b_dr["DAYS"] = "T.7";
                    a = a + 1;
                    break;
                case "Sunday":
                    b_dr["DAYS"] = "CN";
                    b = b + 1;
                    break;
            }
            if (b_dr["DD"].ToString().Length == 1)
                b_dr["DD"] = "0" + b_dr["DD"];
        }
        DataTable b_dtngay = bang.Fdt_TAO_BANG(
            new string[] {"n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10",
                    "n11", "n12", "n13", "n14", "n15", "n16", "n17", "n18", "n19", "n20",
                    "n21", "n22", "n23", "n24", "n25", "n26", "n27", "n28", "n29", "n30","n31","TT" },
            new object[] { "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S",
                        "S", "S", "S", "S", "S", "S", "S", "S", "S", "S","S","S"});
        //lay thu
        object[] str_days = bang.Fobj_COL_MANG(b_dt, "DAYS");
        // lay ngay
        object[] str_dd = bang.Fobj_COL_MANG(b_dt, "DD");

        //ghep cac gia tri thu,ngay, thang vao bang b_dtngay

        bang.P_THEM_HANG(ref b_dtngay, str_days, 0);
        bang.P_THEM_HANG(ref b_dtngay, str_dd, 1);
        DataTable tem_ngay = bang.Fdt_TAO_BANG("TT", "S");
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Thứ" }, 0);
        bang.P_THEM_HANG(ref tem_ngay, new object[] { "Ngày" }, 1);
        //gan gia tri cot TT
        bang.P_DAT_GTRI_N(ref b_dtngay, tem_ngay, 0);
        //cot so ngay T7, CN
        //bang.P_THEM_COL(ref b_dtngay, "T7", a);
        //bang.P_THEM_COL(ref b_dtngay, "CN", b);
        /* lay so ngay lam viec trong thang */
        // lay so ngay lam viec tuan
        DataTable b_dtngaytuan = dbora.Fdt_LKE_S(new object[] { chuyen.CTH_SO(b_thang), b_phong }, "PNS_TL_TLAP_THOILUONG_TRA");
        //if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5) ngaylam = b_so_ngay - a - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 5.5) ngaylam = b_so_ngay - a / 2 - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 6) ngaylam = b_so_ngay - b;
        //else if (chuyen.OBJ_N(b_dtngaytuan.Rows[0]["songay"]) == 7) ngaylam = b_so_ngay;
        if (b_dtngaytuan.Rows.Count > 0)
        {
            switch (chuyen.OBJ_S(b_dtngaytuan.Rows[0]["songay"]))
            {
                case "5":
                    ngaylam = b_so_ngay - a - b;
                    break;
                case "5.50":
                    ngaylam = b_so_ngay - a / 2 - b;
                    break;
                case "6":
                    ngaylam = b_so_ngay - b;
                    break;
                case "6.50":
                    ngaylam = b_so_ngay - b / 2;
                    break;
                case "7":
                    ngaylam = b_so_ngay;
                    break;
            }
        }
        DataTable b_dtct = bang.Fdt_TAO_BANG(new string[] { "T7", "CN", "ngaylam" }, new string[] { "I", "I", "I" });
        bang.P_THEM_HANG(ref b_dtct, new object[] { a, b, ngaylam });
        DataSet b_kq = new DataSet();
        b_kq.Tables.Add(b_dtct); b_kq.Tables.Add(b_dtngay);
        return b_kq;
    }

    /// <summary>Liệt kê chi tiết</summary>
    //public static DataTable Fdt_CC_CN_CT_CT(string b_phong, string b_ca, string b_loai, string b_thangcc)
    public static object[] Faobj_CC_CN_CT_CT(string b_phong, string b_sothe, double b_kyluong_id, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_sothe, b_kyluong_id, b_tu_n, b_den_n, }, "NR", "PNS_CC_CN_HANHCHINH_CT");
    }
    ///<summary>lấy giá trị chấm công</summary>
    public static DataTable PCC_CN_CT_GT(string b_ma_cc)
    {
        return dbora.Fdt_LKE_S(b_ma_cc, "PNS_CC_CN_HANHCHINH_GTR");
    }
    ///<summary>lấy giá trị số giờ làm việc trong ngày</summary>

    public static DataTable PCC_CN_CT_SOGIO()
    {
        return dbora.Fdt_LKE("pns_tl_thoiluong");
    }
    public static string PNS_CC_CN_CT_FILE_NH(DataTable b_dt_cc, string b_kyluong)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_cc, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_cc, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_cc, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_cc, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_cc, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_cc, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_cc, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_cc, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_cc, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_cc, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_cc, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_cc, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_cc, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_cc, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_cc, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_cc, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_cc, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_cc, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_cc, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_cc, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_cc, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_cc, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_cc, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_cc, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_cc, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_cc, "n25");
            object[] a_n26 = bang.Fobj_COL_MANG(b_dt_cc, "n26");
            object[] a_n27 = bang.Fobj_COL_MANG(b_dt_cc, "n27");
            object[] a_n28 = bang.Fobj_COL_MANG(b_dt_cc, "n28");
            object[] a_n29 = bang.Fobj_COL_MANG(b_dt_cc, "n29");
            object[] a_n30 = bang.Fobj_COL_MANG(b_dt_cc, "n30");
            object[] a_n31 = bang.Fobj_COL_MANG(b_dt_cc, "n31");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'S', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'S', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'S', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'S', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'S', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'S', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'S', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'S', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'S', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'S', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'S', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'S', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'S', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'S', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'S', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'S', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'S', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'S', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'S', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'S', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'S', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'S', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'S', a_n25);
            dbora.P_THEM_PAR(ref b_lenh, "a_n26", 'S', a_n26);
            dbora.P_THEM_PAR(ref b_lenh, "a_n27", 'S', a_n27);
            dbora.P_THEM_PAR(ref b_lenh, "a_n28", 'S', a_n28);
            dbora.P_THEM_PAR(ref b_lenh, "a_n29", 'S', a_n29);
            dbora.P_THEM_PAR(ref b_lenh, "a_n30", 'S', a_n30);
            dbora.P_THEM_PAR(ref b_lenh, "a_n31", 'S', a_n31);

            string b_c = "," + chuyen.OBJ_N(b_kyluong).ToString();
            b_c = b_c + ",:a_so_the,:a_ten,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8,:a_n9,:a_n10,:a_n11,:a_n12,:a_n13,:a_n14,:a_n15,:a_n16,:a_n17";
            b_c = b_c + ",:a_n18,:a_n19,:a_n20,:a_n21,:a_n22,:a_n23,:a_n24,:a_n25,:a_n26,:a_n27,:a_n28,:a_n29,:a_n30,:a_n31";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_CT_FILE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.CC_CN_CT, TEN_BANG.CC_CN_CT);
            }
            catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
            finally { b_lenh.Parameters.Clear(); }
            return "";
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PCC_CN_CT_NH(DataTable b_dt, DataTable b_dt_cc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_cc, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_cc, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_cc, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_cc, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_cc, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_cc, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_cc, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_cc, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_cc, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_cc, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_cc, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_cc, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_cc, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_cc, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_cc, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_cc, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_cc, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_cc, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_cc, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_cc, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_cc, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_cc, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_cc, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_cc, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_cc, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_cc, "n25");
            object[] a_n26 = bang.Fobj_COL_MANG(b_dt_cc, "n26");
            object[] a_n27 = bang.Fobj_COL_MANG(b_dt_cc, "n27");
            object[] a_n28 = bang.Fobj_COL_MANG(b_dt_cc, "n28");
            object[] a_n29 = bang.Fobj_COL_MANG(b_dt_cc, "n29");
            object[] a_n30 = bang.Fobj_COL_MANG(b_dt_cc, "n30");
            object[] a_n31 = bang.Fobj_COL_MANG(b_dt_cc, "n31");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'S', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'S', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'S', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'S', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'S', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'S', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'S', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'S', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'S', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'S', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'S', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'S', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'S', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'S', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'S', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'S', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'S', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'S', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'S', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'S', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'S', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'S', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'S', a_n25);
            dbora.P_THEM_PAR(ref b_lenh, "a_n26", 'S', a_n26);
            dbora.P_THEM_PAR(ref b_lenh, "a_n27", 'S', a_n27);
            dbora.P_THEM_PAR(ref b_lenh, "a_n28", 'S', a_n28);
            dbora.P_THEM_PAR(ref b_lenh, "a_n29", 'S', a_n29);
            dbora.P_THEM_PAR(ref b_lenh, "a_n30", 'S', a_n30);
            dbora.P_THEM_PAR(ref b_lenh, "a_n31", 'S', a_n31);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_N(b_dr["kyluong"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8,:a_n9,:a_n10,:a_n11,:a_n12,:a_n13,:a_n14,:a_n15,:a_n16,:a_n17";
            b_c = b_c + ",:a_n18,:a_n19,:a_n20,:a_n21,:a_n22,:a_n23,:a_n24,:a_n25,:a_n26,:a_n27,:a_n28,:a_n29,:a_n30,:a_n31";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_HANHCHINH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // nhập dữ liệu công giờ
    public static void PCC_CN_CT_NH_GIO(DataTable b_dt, DataTable b_dt_cc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ma_cc = bang.Fobj_COL_MANG(b_dt_cc, "ma_cc");
            object[] a_tonggio = bang.Fobj_COL_MANG(b_dt_cc, "tonggio");
            object[] a_conggio = bang.Fobj_COL_MANG(b_dt_cc, "conggio");
            object[] a_ancagio = bang.Fobj_COL_MANG(b_dt_cc, "ancagio");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cc", 'S', a_ma_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tonggio", 'N', a_tonggio);
            dbora.P_THEM_PAR(ref b_lenh, "a_conggio", 'N', a_conggio);
            dbora.P_THEM_PAR(ref b_lenh, "a_ancagio", 'N', a_ancagio);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thangcc"]);
            b_c = b_c + ",:a_so_the,:a_ma_cc,:a_tonggio,:a_conggio,:a_ancagio";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_HANHCHINH_GIO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    // nhap du lieu nghi phep
    public static void PCC_CN_CT_NGHIPHEP(string b_phong, string b_thangcc)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_thangcc }, "PNS_TL_NGHIPHEP_NHAP_CC");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PCC_CN_CT_XOA(string b_phong, string b_sothe, string b_thang, string b_ngay)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_sothe, b_thang }, "PNS_CC_CN_HANHCHINH_XOA");
    }
    public static void PCC_CN_CT_GIO_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_CSO(b_thang) }, "PNS_CC_CN_HANHCHINH_GIO_XOA");
    }

    #region HAL
    public static object[] Fdt_CC_CN_CT_HAL_LKE(string b_phong, string b_thang, int b_tu, int b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_tu, b_den }, "NR", "CC_CN_CT_HAL_LKE");
    }

    //public static void Fdt_CC_CN_CT_HAL_NH(string b_phong, string b_thang, int b_tu, int b_den)
    //{
    //    se.se_nsd b_se = new se.se_nsd();
    //    OracleConnection b_cnn = dbora.Fcn_KNOI();
    //    try
    //    {
    //        OracleCommand b_lenh = new OracleCommand();
    //        b_lenh.Connection = b_cnn;
    //        DataRow b_dr = b_dt.Rows[0];
    //        object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
    //        object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
    //        object[] a_lv_thucte = bang.Fobj_COL_MANG(b_dt_ct, "lv_thucte");
    //        object[] a_phep = bang.Fobj_COL_MANG(b_dt_ct, "phep");
    //        object[] a_capbac = bang.Fobj_COL_MANG(b_dt_ct, "capbac");
    //        object[] a_hso_nn = bang.Fobj_COL_MANG(b_dt_ct, "hso_nn");
    //        object[] a_hspc_nn = bang.Fobj_COL_MANG(b_dt_ct, "hspc_nn");
    //        object[] a_luong_nn = bang.Fobj_COL_MANG(b_dt_ct, "luong_nn");
    //        object[] a_capbac_cv = bang.Fobj_COL_MANG(b_dt_ct, "capbac_cv");
    //        object[] a_hso_cv = bang.Fobj_COL_MANG(b_dt_ct, "hso_cv");
    //        object[] a_luong_cv = bang.Fobj_COL_MANG(b_dt_ct, "luong_cv");
    //        object[] a_doanhthu = bang.Fobj_COL_MANG(b_dt_ct, "doanhthu");
    //        object[] a_luong_doanhthu = bang.Fobj_COL_MANG(b_dt_ct, "luong_doanhthu");
    //        object[] a_tong_luong = bang.Fobj_COL_MANG(b_dt_ct, "tong_luong");
    //        object[] a_pcap = bang.Fobj_COL_MANG(b_dt_ct, "pcap");
    //        object[] a_anca = bang.Fobj_COL_MANG(b_dt_ct, "anca");
    //        object[] a_tnhap_chiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhap_chiuthue");
    //        object[] a_chenhca = bang.Fobj_COL_MANG(b_dt_ct, "chenhca");
    //        object[] a_phaitra_nld = bang.Fobj_COL_MANG(b_dt_ct, "phaitra_nld");
    //        object[] a_pcd = bang.Fobj_COL_MANG(b_dt_ct, "pcd");
    //        object[] a_bhxh = bang.Fobj_COL_MANG(b_dt_ct, "bhxh");
    //        object[] a_bhyt = bang.Fobj_COL_MANG(b_dt_ct, "bhyt");
    //        object[] a_bhtn = bang.Fobj_COL_MANG(b_dt_ct, "bhtn");
    //        object[] a_tnhapchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "tnhapchiuthue");
    //        object[] a_phuthuoc = bang.Fobj_COL_MANG(b_dt_ct, "phuthuoc");
    //        object[] a_tn_tinhthue = bang.Fobj_COL_MANG(b_dt_ct, "tn_tinhthue");
    //        object[] a_truthue = bang.Fobj_COL_MANG(b_dt_ct, "truthue");
    //        object[] a_ktru_kchiuthue = bang.Fobj_COL_MANG(b_dt_ct, "ktru_kchiuthue");
    //        object[] a_thuc_linh = bang.Fobj_COL_MANG(b_dt_ct, "thuc_linh");

    //        dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_lv_thucte", 'N', a_lv_thucte);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_phep", 'N', a_phep);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_capbac", 'U', a_capbac);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_hso_nn", 'N', a_hso_nn);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_hspc_nn", 'N', a_hspc_nn);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_luong_nn", 'N', a_luong_nn);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_capbac_cv", 'U', a_capbac_cv);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_hso_cv", 'N', a_hso_cv);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_luong_cv", 'N', a_luong_cv);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_doanhthu", 'N', a_doanhthu);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_luong_doanhthu", 'N', a_luong_doanhthu);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_tong_luong", 'N', a_tong_luong);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_pcap", 'N', a_pcap);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_anca", 'N', a_anca);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_tnhap_chiuthue", 'N', a_tnhap_chiuthue);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_chenhca", 'N', a_chenhca);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_phaitra_nld", 'N', a_phaitra_nld);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_pcd", 'N', a_pcd);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_bhxh", 'N', a_bhxh);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_bhyt", 'N', a_bhyt);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_bhtn", 'N', a_bhtn);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_tnhapchiuthue", 'N', a_tnhapchiuthue);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_phuthuoc", 'N', a_phuthuoc);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_tn_tinhthue", 'N', a_tn_tinhthue);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_truthue", 'N', a_truthue);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_ktru_kchiuthue", 'N', a_ktru_kchiuthue);
    //        dbora.P_THEM_PAR(ref b_lenh, "a_thuc_linh", 'N', a_thuc_linh);

    //        string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thang"])
    //            + ",:a_so_the,:a_ten,:a_lv_thucte,:a_phep,:a_capbac,:a_hso_nn,:a_hspc_nn,:a_luong_nn,:a_capbac_cv,:a_hso_cv"
    //            + ",:a_luong_cv,:a_doanhthu,:a_luong_doanhthu,:a_tong_luong,:a_pcap,:a_anca,:a_tnhap_chiuthue,:a_chenhca,:a_phaitra_nld"
    //        + ",:a_pcd,:a_bhxh,:a_bhyt,:a_bhtn,:a_tnhapchiuthue,:a_phuthuoc,:a_tn_tinhthue,:a_truthue,:a_ktru_kchiuthue,:a_thuc_linh";

    //        b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_BLUONG_XUANTHANH_NH(" + b_se.tso + b_c + "); end;";
    //        try
    //        {
    //            b_lenh.ExecuteNonQuery();
    //        }
    //        finally { b_lenh.Parameters.Clear(); }
    //    }
    //    finally { b_cnn.Close(); }
    //}

    public static object[] Fdt_CC_CN_CT_LKE_CB(string b_phong, string b_sothe)
    {

        return dbora.Faobj_LKE(new object[] { b_phong, b_sothe }, "NR", "PNS_CC_CN_CT_LKE_CB3");
    }

    #endregion

    #endregion CHẤM CÔNG CÔNG NHẬT CHI TIẾT

    #region TỔNG HỢP CÔNG
    public static DataTable Fdt_NS_CC_TH_LKE_COT()
    {
        return dbora.Fdt_LKE("PNS_CC_TH_LKE_COT");
    }
    public static DataTable Fdt_NS_CC_TH_LKE_COT_STYLE()
    {
        return dbora.Fdt_LKE("PNS_CC_TH_LKE_COT_STYLE");
    }
    public static DataSet Fds_NS_CC_TH_EXCEL(string b_phong, string b_kyluong, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the }, 2, "PNS_CC_TH_EXCEL");
    }
    public static object[] Faobj_NS_CC_TH_LKE(string b_phong, double b_kyluong, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_LKE");
    }
    public static object[] Faobj_NS_CC_TH_TINH(string b_phong, double b_kyluong, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_TINH");
    }
    #endregion

    #region BẢNG CÔNG ĐỐI TƯỢNG THỰC TẬP SINH
    public static object[] Fdt_NS_CC_TH_TTS_LKE(string b_nam, string b_kyluong_id, string b_so_the, string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_kyluong_id, b_so_the, b_phong, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_TTS_LKE");
    }
    public static void Fs_NS_CC_TH_TTS_TH(string b_phong, string b_kyluong, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_kyluong, b_so_the }, "PNS_CC_TH_TTS_TINH");
    }
    #endregion BẢNG CÔNG ĐỐI TƯỢNG THỰC TẬP SINH

    #region BẢNG CHẤM CÔNG MÁY
    public static object[] Fdt_NS_CC_TH_MAY_LKE(string b_phong, double b_tu, double b_den, string b_kyluong, string b_so_the, string b_hoten)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_tu, b_den, b_so_the, "N'" + b_hoten }, "NR", "PNS_CC_TH_MAY_LKE");
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
    public static DataTable Fdt_NS_CC_TH_MAY_CT(string b_phong, string b_kyluong_id, string b_so_the, string b_hoten, double b_tu, double b_den)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id), b_so_the, b_hoten, b_tu, b_den }, "PNS_CC_TH_MAY_CT");
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
    public static DataSet Fdt_CC_TH_MAY_EXCEL(string b_phong, string b_kyluong, string b_so_the, string b_hoten)
    {
        return dbora.Fds_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, "N'" + b_hoten }, 1, "PNS_CC_TH_MAY_EXCEL");
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
    public static object[] Fdt_NS_CC_TH_MAY_TINH(string b_phong, string b_kyluong, string b_so_the, string b_hoten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_so_the, "N'" + b_hoten, b_tu, b_den }, "NR", "PNS_CC_TH_MAY_TINH");
    }
    public static DataTable Fdt_NS_CC_TH_MAY_TINH_XUANTHANH(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_XT");
    }
    public static DataTable Fdt_NS_TL_MA_NL_XEM(string b_ma_dvi)
    {
        return dbora.Fdt_LKE_S(b_ma_dvi, "PNS_TL_MA_NL_XEM");
    }
    public static DataTable Fdt_NS_CC_TH_MAY_TINH_OKI(string b_phong, string b_thang)
    {
        int a = chuyen.CTH_SO(b_thang);
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_LUONGCHUNG_TONGHOP_OKI");
    }
    #endregion BẢNG CHẤM CÔNG MÁY

    #region CHẤM CÔNG SẢN PHẨM TẬP THỂ

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_SP_TT_LKE(string b_phong, string b_ngayd, string b_ngayc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_CC_SP_TT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_SP_TT_MA(string b_phong, string b_ngayd, string b_ngayc, string b_ngay, string b_ca, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), chuyen.CNG_CSO(b_ngay), b_ca, b_trangkt }, "NNR", "PNS_CC_SP_TT_MA");
    }

    // Chi tiet so lieu
    public static DataSet Fdt_CC_SP_TT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "PNS_CC_SP_TT_CT");
    }
    // Nhap so lieu
    public static void P_CC_SP_TT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_sp, DataTable b_dt_ds)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_masp = bang.Fobj_COL_MANG(b_dt_sp, "masp");
            object[] a_donvi = bang.Fobj_COL_MANG(b_dt_sp, "donvi");
            object[] a_chatluong = bang.Fobj_COL_MANG(b_dt_sp, "chatluong");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_sp, "soluong");

            object[] c_so_the = bang.Fobj_COL_MANG(b_dt_ds, "so_the");
            object[] c_ten = bang.Fobj_COL_MANG(b_dt_ds, "ten");
            object[] c_cdanh = bang.Fobj_COL_MANG(b_dt_ds, "cdanh");
            object[] c_phong = bang.Fobj_COL_MANG(b_dt_ds, "phong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_masp", 'S', a_masp);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_chatluong", 'N', a_chatluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);

            dbora.P_THEM_PAR(ref b_lenh, "c_so_the", 'S', c_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "c_ten", 'U', c_ten);
            dbora.P_THEM_PAR(ref b_lenh, "c_cdanh", 'U', c_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "c_phong", 'U', c_phong);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["ngay"]) + "," + chuyen.OBJ_C(b_dr["ca"]) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_c = b_c + ",:a_masp,:a_donvi,:a_chatluong,:a_soluong";
            b_c = b_c + ",:c_so_the,:c_ten,:c_cdanh,:c_phong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_SP_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_SP_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_CC_SP_TT_XOA");
    }
    public static DataTable Fdt_CC_SP_TT_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_CC_SP_TT_LKE_CB");

        return b_dt;
    }
    public static DataTable Fdt_CC_SP_TT_TIM_DONGIA(string b_sanpham, string b_chatluong, string b_ngay)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_sanpham, b_chatluong, chuyen.CNG_SO(b_ngay) }, "PNS_CC_SP_TT_TIM_DONGIA");

        return b_dt;
    }
    #endregion CHẤM CÔNG SẢN PHẨM TẬP THỂ

    #region CHẤM CÔNG SẢN PHẨM CÁ NHÂN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_SP_CN_LKE(string b_so_the, string b_ngayd, string b_ngayc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_CC_SP_CN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_SP_CN_MA(string b_so_the, string b_ngayd, string b_ngayc, string b_ngay, string b_ca, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), chuyen.CNG_CSO(b_ngay), b_ca, b_trangkt }, "NNR", "PNS_CC_SP_CN_MA");
    }

    // Chi tiet so lieu
    public static object[] Fdt_CC_SP_CN_CT(string b_so_id)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id }, "RR", "PNS_CC_SP_CN_CT");
    }
    // Nhap so lieu
    public static void P_CC_SP_CN_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_masp = bang.Fobj_COL_MANG(b_dt_ct, "masp");
            object[] a_donvi = bang.Fobj_COL_MANG(b_dt_ct, "donvi");
            object[] a_chatluong = bang.Fobj_COL_MANG(b_dt_ct, "chatluong");
            object[] a_soluong = bang.Fobj_COL_MANG(b_dt_ct, "soluong");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_masp", 'S', a_masp);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_chatluong", 'N', a_chatluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_soluong", 'N', a_soluong);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngay"]) + ","
                + chuyen.OBJ_C(b_dr["ca"]) + "," + chuyen.OBJ_C(b_dr["note"]) + ",:a_masp,:a_donvi,:a_chatluong,:a_soluong";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_SP_CN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_C(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_SP_CN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_CC_SP_CN_XOA");
    }
    #endregion CHẤM CÔNG SẢN PHẨM CÁ NHÂN

    #region CHẤM CÔNG SẢN PHẨM CÁ NHÂN CHUNG
    // Liet ke so lieu
    public static DataTable Fdt_CC_SP_CN_CHUNG_LKE(string b_phong, string b_ngayd, string b_ngayc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc) }, "PNS_CC_SP_CN_CHUNG_LKE");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_CC_SP_CN_CHUNG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_SP_CN_CHUNG_CT");
    }
    // Nhap so lieu
    public static void P_CC_SP_CN_CHUNG_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_congviec = bang.Fobj_COL_MANG(b_dt_ct, "congviec");
            object[] a_vitri = bang.Fobj_COL_MANG(b_dt_ct, "vitri");
            object[] a_heso = bang.Fobj_COL_MANG(b_dt_ct, "heso");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_congviec", 'U', a_congviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_vitri", 'U', a_vitri);
            dbora.P_THEM_PAR(ref b_lenh, "a_heso", 'N', a_heso);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["masp"]) + "," + chuyen.OBJ_C(b_dr["chatluong"])
                + "," + chuyen.OBJ_S(b_dr["ngay"]) + ",:a_so_the,:a_ten,:a_congviec,:a_vitri,:a_heso";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_SP_CN_CHUNG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_SP_CN_CHUNG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_SP_CN_CHUNG_XOA");
    }
    #endregion CHẤM CÔNG SẢN PHẨM CÁ NHÂN CHUNG

    #region CHẤM CÔNG KHOÁN TẬP THỂ
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_KHOAN_TT_LKE(string b_phong, string b_ngayd, string b_ngayc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_CC_KHOAN_TT_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_KHOAN_TT_MA(string b_phong, string b_masp, string b_ngayd, string b_ngayc, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_masp, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), chuyen.CNG_CSO(b_ngay), b_trangkt }, "NNR", "PNS_CC_KHOAN_TT_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_CC_KHOAN_TT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_KHOAN_TT_CT");
    }
    // Nhap so lieu
    public static void P_CC_KHOAN_TT_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_chatluong = bang.Fobj_COL_MANG(b_dt_ct, "chatluong");
            object[] a_ngayhoanthanh = bang.Fobj_COL_MANG(b_dt_ct, "ngayhoanthanh");
            object[] a_tyle = bang.Fobj_COL_MANG(b_dt_ct, "tyle");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_chatluong", 'N', a_chatluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayhoanthanh", 'N', a_ngayhoanthanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle", 'N', a_tyle);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["masp"]) + "," + chuyen.OBJ_C(b_dr["tien"])
                + "," + chuyen.OBJ_S(b_dr["ngay"]) + ",:a_so_the,:a_ten,:a_cdanh,:a_chatluong,:a_ngayhoanthanh,:a_tyle";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KHOAN_TT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_KHOAN_TT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_KHOAN_TT_XOA");
    }
    #endregion CHẤM CÔNG KHOÁN TẬP THỂ

    #region CHẤM CÔNG KHOÁN CÁ NHÂN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_KHOAN_CN_LKE(string b_so_the, string b_ngayd, string b_ngayc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), b_tu_n, b_den_n }, "NR", "PNS_CC_KHOAN_CN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_KHOAN_CN_MA(string b_so_the, string b_masp, string b_ngayd, string b_ngayc, string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_masp, chuyen.CNG_CSO(b_ngayd), chuyen.CNG_CSO(b_ngayc), chuyen.CNG_CSO(b_ngay), b_trangkt }, "NNR", "PNS_CC_KHOAN_CN_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_KHOAN_CN_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_CC_KHOAN_CN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_CC_KHOAN_CN_NH(string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngay"]) + "," + chuyen.OBJ_C(b_dr["masp"])
                + "," + chuyen.OBJ_N(b_dr["tien"]) + "," + chuyen.OBJ_N(b_dr["chatluong"]) + "," + chuyen.OBJ_N(b_dr["ngayhoanthanh"]) + ","
                + chuyen.OBJ_N(b_dr["tyle"]) + "," + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KHOAN_CN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_CC_KHOAN_CN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_KHOAN_CN_XOA");
    }
    #endregion CHẤM CÔNG KHOÁN CÁ NHÂN

    #region TỔNG HỢP CÔNG KHOÁN
    public static DataTable Fdt_NS_CC_TH_KHOAN_SP_LKE_COT()
    {
        return dbora.Fdt_LKE("PNS_CC_TH_KHOAN_SP_LKE_COT");
    }
    public static object[] Faobj_NS_CC_TH_KHOAN_SP_LKE(string b_phong, double b_kyluong, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n }, "NRR", "PNS_CC_TH_KHOAN_SP_LKE");
    }
    public static object[] Faobj_NS_CC_TH_KHOAN_SP_TINH(string b_phong, double b_kyluong, string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n }, "NR", "PNS_CC_TH_KHOAN_SP_TINH");
    }

    #endregion

    #region ĐÁNH GIÁ CÁN BỘ

    public static DataTable Fdt_TL_DANHGIA_CB_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_DANHGIA_CB_CT");
    }
    public static DataTable Fdt_TL_DANHGIA_CB_LKE(string b_phong)
    {
        return dbora.Fdt_LKE_S(b_phong, "PNS_TL_DANHGIA_CB_LKE");
    }
    public static string P_TL_DANHGIA_CB_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_diem = bang.Fobj_COL_MANG(b_dt_ct, "diem");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem", 'N', a_diem);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"]))
                + ",:a_so_the" + ",:a_ten" + ",:a_diem" + ",:a_note";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_DANHGIA_CB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_DANHGIA_CB_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_DANHGIA_CB_XOA");
    }
    public static DataTable Fdt_TL_DANHGIA_CB_LKE_CB(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_DANHGIA_CB_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "diem", "note" }, new string[] { "", "" });
        return b_dt;
    }

    #endregion

    #region ĐÁNH GIÁ Phòng

    public static DataTable Fdt_TL_DANHGIA_DVI_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_DANHGIA_DVI_CT");
    }
    public static DataTable Fdt_TL_DANHGIA_DVI_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_DANHGIA_DVI_LKE");
    }
    public static string P_TL_DANHGIA_DVI_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_phong = bang.Fobj_COL_MANG(b_dt_ct, "ma_phong");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt_ct, "ten_phong");
            object[] a_diem = bang.Fobj_COL_MANG(b_dt_ct, "diem");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_phong", 'S', a_ma_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem", 'N', a_diem);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:so_id," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"]))
                + ",:a_ma_phong" + ",:a_ten_phong" + ",:a_diem" + ",:a_note";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_DANHGIA_DVI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_DANHGIA_DVI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_DANHGIA_DVI_XOA");
    }
    public static DataTable Fdt_TL_DANHGIA_DVI_LKE_PHONG()
    {
        DataTable b_dt = dbora.Fdt_LKE("PNS_TL_DANHGIA_DVI_LKE_PHONG");
        bang.P_THEM_COL(ref b_dt, new string[] { "diem", "note" }, new string[] { "", "" });
        return b_dt;
    }

    #endregion

    #region KHOÁN DOANH THU
    // Liet ke so lieu
    public static DataTable Fdt_TL_KHOANDT_LKE(string b_so_the)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_so_the, "PNS_TL_KHOANDT_LKE");
        return b_dt;
    }
    // Chi tiet so lieu
    public static DataTable Fdt_TL_KHOANDT_CT(string b_so_the, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_so_id }, "PNS_TL_KHOANDT_CT");
    }
    // Nhap so lieu
    public static string P_TL_KHOANDT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_ten_dt = bang.Fobj_COL_MANG(b_dt_ct, "ten_dt");
            object[] a_khoan = bang.Fobj_COL_MANG(b_dt_ct, "khoan");
            object[] a_gtri = bang.Fobj_COL_MANG(b_dt_ct, "gtri");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_dt", 'U', a_ten_dt);
            dbora.P_THEM_PAR(ref b_lenh, "a_khoan", 'N', a_khoan);
            dbora.P_THEM_PAR(ref b_lenh, "a_gtri", 'N', a_gtri);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"]))
                + ",:a_ma,:a_ten_dt,:a_khoan,:a_gtri,:a_note";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_KHOANDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_TL_KHOANDT_XOA(string b_so_the, string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_so_id }, "PNS_TL_KHOANDT_XOA");
    }
    #endregion

    #region NHÓM LÀM VIỆC
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TL_NHOMLV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_TL_NHOMLV_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static DataTable Fdt_NS_TL_NHOMLV_LKE()
    {
        return dbora.Fdt_LKE("PNS_TL_NHOMLV_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_TL_NHOMLV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_note = bang.Fobj_COL_MANG(b_dt_ct, "note");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_note", 'U', a_note);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["tennhom"]) + ","
                + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_I(b_dr["ngay_qd"]) + "," + chuyen.OBJ_I(b_dr["ngayd"])
                + ",:a_so_the" + ",:a_ten" + ",:a_phong" + ",:a_note";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_NHOMLV_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TL_NHOMLV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TL_NHOMLV_XOA");
    }
    #endregion NHOM LÀM VIỆC

    #region PHÂN CA LÀM VIỆC
    /// <summary>Liệt kê chi tiết</summary> 
    public static object[] Faobj_CC_PHANCA_CT(string b_phong, string b_sothe, string b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_sothe, chuyen.OBJ_N(b_kyluong), b_tu_n, b_den_n }, "NR", "PNS_CC_PHANCA_CT");
    }
    public static object[] Faobj_CC_PHANCA_MACDINH_CT(string b_phong, string b_sothe, string b_kyluong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_sothe, b_kyluong, b_tu_n, b_den_n }, "NR", "PNS_CC_PHANCA_MACDINH_CT");
    }

    public static DataTable Fdt_TL_PHANCA_KYCU(string b_phong, string b_kyluong, string b_kyluong_cu)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong, b_kyluong_cu }, "PNS_TL_PHANCA_KYCU");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PCC_PHANCA_NH(DataTable b_dt, DataTable b_dt_cc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_cc, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_cc, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_cc, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_cc, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_cc, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_cc, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_cc, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_cc, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_cc, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_cc, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_cc, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_cc, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_cc, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_cc, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_cc, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_cc, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_cc, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_cc, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_cc, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_cc, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_cc, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_cc, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_cc, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_cc, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_cc, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_cc, "n25");
            object[] a_n26 = bang.Fobj_COL_MANG(b_dt_cc, "n26");
            object[] a_n27 = bang.Fobj_COL_MANG(b_dt_cc, "n27");
            object[] a_n28 = bang.Fobj_COL_MANG(b_dt_cc, "n28");
            object[] a_n29 = bang.Fobj_COL_MANG(b_dt_cc, "n29");
            object[] a_n30 = bang.Fobj_COL_MANG(b_dt_cc, "n30");
            object[] a_n31 = bang.Fobj_COL_MANG(b_dt_cc, "n31");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'S', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'S', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'S', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'S', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'S', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'S', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'S', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'S', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'S', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'S', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'S', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'S', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'S', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'S', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'S', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'S', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'S', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'S', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'S', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'S', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'S', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'S', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'S', a_n25);
            dbora.P_THEM_PAR(ref b_lenh, "a_n26", 'S', a_n26);
            dbora.P_THEM_PAR(ref b_lenh, "a_n27", 'S', a_n27);
            dbora.P_THEM_PAR(ref b_lenh, "a_n28", 'S', a_n28);
            dbora.P_THEM_PAR(ref b_lenh, "a_n29", 'S', a_n29);
            dbora.P_THEM_PAR(ref b_lenh, "a_n30", 'S', a_n30);
            dbora.P_THEM_PAR(ref b_lenh, "a_n31", 'S', a_n31);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ","
                + chuyen.OBJ_C(b_dr["t7"]) + "," + chuyen.OBJ_C(b_dr["cn"]) + "," + chuyen.OBJ_S(b_dr["ngaylam"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8,:a_n9,:a_n10,:a_n11,:a_n12,:a_n13,:a_n14,:a_n15,:a_n16,:a_n17";
            b_c = b_c + ",:a_n18,:a_n19,:a_n20,:a_n21,:a_n22,:a_n23,:a_n24,:a_n25,:a_n26,:a_n27,:a_n28,:a_n29,:a_n30,:a_n31";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_PHANCA_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin</summary>

    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_TL_PHANCA_EXPORT(double b_thang, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_thang, b_phong }, "P_TL_PHANCA_EXPORT");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PCC_PHANCA_XOA(string b_phong, string b_thang, string b_ngay)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_thang, chuyen.CNG_CSO(b_ngay) }, "PNS_CC_PHANCA_XOA");
    }
    public static DataTable Fdt_CC_PHANCA_LKE_CB(string b_phong, string b_sothe, string b_kyluong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_phong, b_sothe, b_kyluong }, "PNS_CC_PHANCA_LKE_CB");
        bang.P_THEM_COL(ref b_dt, new string[] { "n1", "n2", "n3", "n4", "n5", "n6", "n7", "n8", "n9", "n10", "n11", "n12", "n13", "n14",
            "n15", "n16", "n17", "n18", "n19", "n20", "n21", "n22", "n23", "n24", "n25", "n26", "n27", "n28", "n29", "n30", "n31" },
            new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
            "", "", "", "", "", "", "" });
        return b_dt;
    }
    public static DataTable Fdt_CC_LAY_NAM(string b_kyluong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_kyluong }, "PNS_CC_LAY_NAM");
        return b_dt;
    }
    #endregion PHÂN CA LÀM VIỆC

    #region ĐĂNG KÝ LÀM THÊM GIỜ

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_TL_DKY_LAMTHEM_LKE(string b_so_the, string b_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_S(chuyen.CTH_CSO(b_thang)), b_tu, b_den }, "NR", "PNS_TL_DKY_LAMTHEM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TL_DKY_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_TL_DKY_LAMTHEM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_TL_DKY_LAMTHEM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TL_DKY_LAMTHEM_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_TL_DKY_LAMTHEM_NH(ref string b_so_id, DataTable b_dt)
    {


        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_bd"]) + "," + chuyen.OBJ_C(b_dr["ngay_kt"])
                + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["ykien"])
                + "," + chuyen.OBJ_C(b_dr["ot_thoigian"]) + "," + chuyen.OBJ_C(b_dr["nt_thoigian"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["nguoiduyet"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_DKY_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable PNS_THONGTIN_EMAIL(string b_loai, string b_so_id)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loai, b_so_id }, "PNS_THONGTIN_EMAIL");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_TL_DKY_LAMTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_TL_DKY_LAMTHEM_XOA");
    }

    public static DataTable PNS_TL_DKY_LAMTHEM_HUY(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "pns_tl_dky_lamthem_huy");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM GIỜ
    public static object[] Fdt_NS_TL_LAMTHEMPD_LKE(string a_tinhtrang, string a_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, chuyen.CTH_CSO(a_thang), b_tu, b_den }, "NR", "pns_tl_lamthempd_lke");
    }

    public static DataTable Fdt_NS_TL_LAMTHEMPD_PHEDUYET(string b_tinhtrang, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_id,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_LAMTHEMPD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static void Fdt_NS_TL_LAMTHEMPD_KOPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_LAMTHEMPD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM GIỜ

    #region PHÊ DUYỆT ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY
    public static object[] Fdt_NS_CC_DKLV_NGOAI_CTY_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_so_the_tk, b_tu, b_den }, "NR", "PNS_CC_DKLV_NGOAI_CTY_PD_LKE");
    }

    public static DataTable Fdt_NS_CC_DKLV_NGOAI_CTY_PD_PHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKLV_NGOAI_CTY_PD(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_CC_DKLV_NGOAI_CTY_PD_KOPHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKLV_NGOAI_CTY_KOPD(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    #region PHÊ DUYỆT ĐĂNG KÝ CA CON NHỎ DƯỚI 1 TUỔI
    public static object[] Fdt_NS_CC_DKC_CONNHO_PD_LKE(string b_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_so_the_tk, b_tu, b_den }, "NR", "PNS_NS_CC_DKC_CONNHO_PD_LKE");
    }

    public static DataTable Fdt_NS_CC_DKC_CONNHO_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "mota");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKC_CONNHO_PD_PDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_CC_DKC_CONNHO_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKC_CONNHO_PD_KPD(" + b_se.tso + b_c + "); end;";
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

    #region ĐĂNG KÝ ĐI MUỘN VỀ SỚM

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_CC_CN_DKY_DMVS_LKE(string b_so_the, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_trangthai, b_tu, b_den }, "NR", "PNS_CC_CN_DKY_DMVS_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_CC_CN_DKY_DMVS_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_CC_CN_DKY_DMVS_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_CC_CN_DKY_DMVS_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_CN_DKY_DMVS_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_CC_CN_DKY_DMVS_CT2(int b_ngaydky, string b_loaidky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_loaidky }, "PNS_CC_CN_DKY_DMVS_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_CC_CN_DKY_DMVS_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["loai_dky"]) + "," + chuyen.OBJ_N(b_dr["SOPHUT"])
                + "," + chuyen.OBJ_C(b_dr["gchu"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_DKY_DMVS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void P_CC_CN_DKY_DMVS_FILE_NH(DataTable b_dt)
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

                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["loai_dky"]) + "," + chuyen.OBJ_N(b_dr["SOPHUT"])
                    + "," + chuyen.OBJ_C("N'" + b_dr["gchu"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]);

                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_DKY_DMVS_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_CN_DKY_DMVS_GUI(string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_so_the }, "PNS_CC_CN_DKY_DMVS_GUI");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_CC_CN_DKY_DMVS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_CN_DKY_DMVS_XOA");
    }
    /// <summary>Xóa thôn tin</summary>
    public static DataTable Fdt_CC_CN_DKY_DMVS_GUI(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "pns_cc_cn_dky_dmvs_gui");
    }

    #endregion ĐĂNG KÝ ĐI MUỘN VỀ SỚM

    #region PHÊ DUYỆT ĐI MUỘN VỀ SỚM
    public static object[] Fdt_CC_DKY_DMVSPD_LKE(string b_phong, string a_tinhtrang, string b_loai_dky_tk, string b_so_the_tk, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, b_loai_dky_tk, b_so_the_tk, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_CC_DKY_DMVSPD_LKE");
    }

    public static DataTable Fdt_CC_DKY_DMVSPD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_DMVSPD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_CC_DKY_DMVSPD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_DMVSPD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT DANH SÁCH GIẢI TRÌNH CHẤM CÔNG

    #region PHÊ DUYỆT ĐĂNG KÝ NGHỈ
    public static object[] Fdt_NS_QT_NGHIPHEP_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_so_the_tk, b_tu, b_den }, "NR", "PNS_NS_QT_NGHIPHEP_PD_LKE");
    }

    public static DataTable Fdt_NS_QT_NGHIPHEP_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_QT_NGHIPHEP_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIPHEP_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_QT_NGHIPHEP_PD_KOPD(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    #region PHÊ DUYỆT ĐĂNG KÝ NGHỈ
    public static object[] Fdt_NS_QT_NGHIPHEP_LD_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_NS_QT_NGHIPHEP_LD_PD_LKE");
    }
    public static DataTable Fdt_NS_QT_NGHIPHEP_LD_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_QT_NGHIPHEP_LD_PD_PD(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIPHEP_LD_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ns_qt_nghiphep_ld_pd_kopd(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ LÃNH ĐẠO

    #region PHÊ DUYỆT ĐĂNG KÝ LÀM THÊM
    public static object[] Fdt_NS_CC_DKY_LTHEM_PD_LKE(string b_kyluong_id, string a_tinhtrang, string b_tungay, string b_denngay, string b_so_the_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_kyluong_id), a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_so_the_tk, b_tu, b_den }, "NR", "PNS_NS_CC_DKY_LTHEM_PD_LKE");
    }

    public static DataTable Fdt_NS_CC_DKY_LTHEM_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKY_LTHEM_PD_PDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_CC_DKY_LTHEM_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "ma_nv");
            object[] a_lydo_ld = bang.Fobj_COL_MANG(b_dt_ct, "lydo_ld");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_ld", 'U', a_lydo_ld);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');
            string b_c = ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKY_LTHEM_PD_KPD(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT ĐĂNG KÝ NGHỈ

    #region TỔNG HỢP CHẤM CÔNG
    public static object[] Fdt_NS_CC_TONGHOP_LKE(string b_phong)
    {
        return dbora.Faobj_LKE(new object[] { b_phong }, "NR", "pns_cc_cn_tonghop_lke");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_TONGHOP_MA(string b_phong, string b_thang, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "pns_cc_cn_tonghop_ma");
    }
    public static DataSet Fdt_NS_CC_TONGHOP_CT(string b_phong, double b_kyluong)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_kyluong }, 2, "pns_cc_cn_tonghop_ct");
    }
    public static void P_NS_CC_TONGHOP_NH(DataTable b_dt, DataTable b_dt_ma, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            DataRow b_dr_ma = b_dt_ma.Rows[0];

            object[] a_phong_cp = bang.Fobj_COL_MANG(b_dt_ct, "phong_cp");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_ct, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_ct, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_ct, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_ct, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_ct, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_ct, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_ct, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_ct, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_ct, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_ct, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_ct, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_ct, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_ct, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_ct, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_ct, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_ct, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_ct, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_ct, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_ct, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_ct, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_ct, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_ct, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_ct, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_ct, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_ct, "n25");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong_cp", 'S', a_phong_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'S', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'S', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'S', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'S', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'S', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'S', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'S', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'S', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'S', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'S', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'S', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'S', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'S', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'S', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'S', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'S', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'S', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'S', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'S', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'S', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'S', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'S', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'S', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'S', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'S', a_n25);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_S(b_dr["thangcc"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma01"]) + "," + chuyen.OBJ_C(b_dr_ma["ma2"]) + "," + chuyen.OBJ_C(b_dr_ma["ma3"]) + "," + chuyen.OBJ_C(b_dr_ma["ma4"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma5"]) + "," + chuyen.OBJ_C(b_dr_ma["ma6"]) + "," + chuyen.OBJ_C(b_dr_ma["ma7"]) + "," + chuyen.OBJ_C(b_dr_ma["ma8"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma9"]) + "," + chuyen.OBJ_C(b_dr_ma["ma10"]) + "," + chuyen.OBJ_C(b_dr_ma["ma11"]) + "," + chuyen.OBJ_C(b_dr_ma["ma12"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma13"]) + "," + chuyen.OBJ_C(b_dr_ma["ma14"]) + "," + chuyen.OBJ_C(b_dr_ma["ma15"]) + "," + chuyen.OBJ_C(b_dr_ma["ma16"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma17"]) + "," + chuyen.OBJ_C(b_dr_ma["ma18"]) + "," + chuyen.OBJ_C(b_dr_ma["ma19"]) + "," + chuyen.OBJ_C(b_dr_ma["ma20"])
                + "," + chuyen.OBJ_C(b_dr_ma["ma21"]) + "," + chuyen.OBJ_C(b_dr_ma["ma22"]) + "," + chuyen.OBJ_C(b_dr_ma["ma23"]) + "," + chuyen.OBJ_C(b_dr_ma["ma24"]) + "," + chuyen.OBJ_C(b_dr_ma["ma25"])
                + ",:a_phong_cp,:a_so_the,:a_ten,:n1,:n2,:n3,:n4,:n5,:n6,:n7,:n8,:n9,:n10,:n11,:n12,:n13,:n14,:n15,:n16,:n17,:n18,:n19,:n20,:n21,:n22,:n23,:n24,:n25";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cc_cn_tonghop_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void P_NS_CC_TONGHOP_GOPDONG(DataTable b_dt)
    {
        int a_count = b_dt.Rows.Count; string a_so_the; int check;
        if (a_count > 0)
        {
            for (int i = 0; i < a_count; i++)
            {
                a_so_the = b_dt.Rows[i]["so_the"].ToString();
                check = bang.Fi_TIM_LIKE(b_dt, "so_the", a_so_the);
            }
        }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_CC_TONGHOP_XOA(string b_phong, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "pns_cc_cn_tonghop_xoa");
    }
    public static DataSet Fdt_NS_CC_TONGHOP_LKE_CB(string b_phong)
    {
        return dbora.Fds_LKE(b_phong, 2, "pns_cc_cn_tonghop_lke_cb");

    }
    public static DataTable Fdt_NS_CC_TONGHOP_LKE_COT()
    {
        return dbora.Fdt_LKE("pns_cc_cn_tonghop_lke_cot");

    }
    ///<summary> Tính tổng hợp Tháng </summary>
    ///
    public static DataTable Fdt_NS_CC_TONGHOP_TINH(string b_phong, double b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong }, "PNS_CC_CN_TONGHOP");

    }
    #endregion TỔNG HỢP CHẤM CÔNG

    #region TỔNG HỢP LÀM THÊM
    public static object[] Fdt_NS_CC_TONGHOP_LTHEM_TINH(string b_phong, double b_kyluong, string b_so_the, string b_hoten, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, "N'" + b_hoten, b_tu_n, b_den_n }, "NR", "pns_cc_tonghop_lthem_th");
    }
    public static object[] Fdt_NS_CC_LTHEM_TONGHOP_CT(string b_phong, double b_kyluong, string b_so_the, string b_hoten, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_kyluong, b_so_the, "N'" + b_hoten, b_tu_n, b_den_n }, "NR", "pns_cc_tonghop_lthem_ct");
    }
    public static DataSet Fdt_NS_TONGHOP_LAMTHEM(string b_phong, double b_kyluong)
    {
        return dbora.Fds_LKE(new object[] { b_phong, b_kyluong }, 2, "pns_ns_tonghop_lamthem");
    }
    public static DataTable Fdt_NS_LAMTHEM_LKE_COT()
    {
        return dbora.Fdt_LKE("pns_ns_lamthem_lke_cot");

    }
    public static DataTable Fdt_CC_LAMTHEM_COT()
    {
        return dbora.Fdt_LKE("pns_cc_ma_lamthem_cot");
    }
    #endregion

    #region CÔNG CHI TIẾT NAGASE
    public static object[] Fdt_TL_CC_CT_NAGASE_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_CC_CT_NAGASE_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_CC_CT_NAGASE_MA(string b_phong, string b_thang, double b_trangkt)
    {
        int thang = chuyen.CTH_SO(b_thang);
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_CC_CT_NAGASE_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_CC_CT_NAGASE_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_CC_CT_NAGASE_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_CC_CT_NAGASE_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_id_cc = bang.Fobj_COL_MANG(b_dt_ct, "id_cc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_ngay_cc = bang.Fobj_COL_MANG(b_dt_ct, "ngay_cc");
            object[] a_giovao = bang.Fobj_COL_MANG(b_dt_ct, "giovao");
            object[] a_giove = bang.Fobj_COL_MANG(b_dt_ct, "giove");
            object[] a_time_lam = bang.Fobj_COL_MANG(b_dt_ct, "time_lam");
            object[] a_dimuon = bang.Fobj_COL_MANG(b_dt_ct, "dimuon");
            object[] a_vesom = bang.Fobj_COL_MANG(b_dt_ct, "vesom");
            object[] a_noi_lv = bang.Fobj_COL_MANG(b_dt_ct, "noi_lv");
            object[] a_ngay_cc_thu = bang.Fobj_COL_MANG(b_dt_ct, "ngay_cc_thu");
            object[] a_ngay = bang.Fobj_COL_MANG(b_dt_ct, "ngay");
            object[] a_thang = bang.Fobj_COL_MANG(b_dt_ct, "thang");
            object[] a_nam = bang.Fobj_COL_MANG(b_dt_ct, "nam");
            object[] a_ngay_cc_th = bang.Fobj_COL_MANG(b_dt_ct, "ngay_cc_th");
            object[] a_dimuon_gb = bang.Fobj_COL_MANG(b_dt_ct, "dimuon_gb");
            object[] a_vesom_gb = bang.Fobj_COL_MANG(b_dt_ct, "vesom_gb");
            object[] a_thoigian_vesom = bang.Fobj_COL_MANG(b_dt_ct, "thoigian_vesom");
            object[] a_thoigian_dimuon = bang.Fobj_COL_MANG(b_dt_ct, "thoigian_dimuon");
            object[] a_themgio = bang.Fobj_COL_MANG(b_dt_ct, "themgio");
            object[] a_tongtime = bang.Fobj_COL_MANG(b_dt_ct, "tong_time");

            dbora.P_THEM_PAR(ref b_lenh, "a_id_cc", 'U', a_id_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cc", 'U', a_ngay_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_giovao", 'U', a_giovao);
            dbora.P_THEM_PAR(ref b_lenh, "a_giove", 'U', a_giove);
            dbora.P_THEM_PAR(ref b_lenh, "a_time_lam", 'U', a_time_lam);
            dbora.P_THEM_PAR(ref b_lenh, "a_dimuon", 'U', a_dimuon);
            dbora.P_THEM_PAR(ref b_lenh, "a_vesom", 'U', a_vesom);
            dbora.P_THEM_PAR(ref b_lenh, "a_noi_lv", 'U', a_noi_lv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cc_thu", 'U', a_ngay_cc_thu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay", 'U', a_ngay);
            dbora.P_THEM_PAR(ref b_lenh, "a_thang", 'U', a_thang);
            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'U', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cc_th", 'U', a_ngay_cc_th);
            dbora.P_THEM_PAR(ref b_lenh, "a_dimuon_gb", 'U', a_dimuon_gb);
            dbora.P_THEM_PAR(ref b_lenh, "a_vesom_gb", 'U', a_vesom_gb);
            dbora.P_THEM_PAR(ref b_lenh, "a_thoigian_vesom", 'U', a_thoigian_vesom);
            dbora.P_THEM_PAR(ref b_lenh, "a_thoigian_dimuon", 'U', a_thoigian_dimuon);
            dbora.P_THEM_PAR(ref b_lenh, "a_themgio", 'U', a_themgio);
            dbora.P_THEM_PAR(ref b_lenh, "a_tongtime", 'U', a_tongtime);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thangcc"])) +
                ",:a_id_cc,:a_ten,:a_ngay_cc,:a_giovao,:a_giove,:a_time_lam,:a_dimuon,:a_vesom,:a_noi_lv,:a_ngay_cc_thu,:a_ngay,:a_thang,:a_nam,:a_ngay_cc_th,:a_dimuon_gb,:a_vesom_gb,:a_thoigian_vesom,:a_thoigian_dimuon,:a_themgio,:a_tongtime";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_CC_CT_NAGASE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_CC_CT_NAGASE_XOA(string b_thang)
    {
        dbora.P_GOIHAM(chuyen.CTH_CSO(b_thang), "PNS_TL_CC_CT_NAGASE_XOA");
    }
    public static DataTable Fdt_TL_CC_CT_NAGASE_LKE_CB(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_CC_CT_NAGASE_LKE_CB");
    }
    public static DataTable Fdt_TL_CC_CT_NAGASE_TINH_TU(string b_phong)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_phong, "PNS_TL_CC_CT_NAGASE_TINH_TU");
        bang.P_THEM_COL(ref b_dt, new string[] { "ten", "cvu", "cdanh", "cdanhcv", "note" }, new string[] { "", "", "", "", "" });
        return b_dt;
    }
    public static DataTable Fdt_CC_CN_CT_NAGASE_TONGHOP(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "pns_cc_nagase_tonghop");
    }
    #endregion

    #region CÔNG CHI TIẾT HAL
    public static object[] Fdt_TL_CC_CT_HAL_LKE(string b_phong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu_n, b_den_n }, "NR", "PNS_TL_CC_CT_HAL_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TL_CC_CT_HAL_MA(string b_phong, string b_thang, double b_trangkt)
    {
        int thang = chuyen.CTH_SO(b_thang);
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_trangkt }, "NNR", "PNS_TL_CC_CT_HAL_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TL_CC_CT_HAL_CT(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_CC_CT_HAL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TL_CC_CT_HAL_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_id = bang.Fobj_COL_MANG(b_dt_ct, "id");
            object[] a_no = bang.Fobj_COL_MANG(b_dt_ct, "no");
            object[] a_name = bang.Fobj_COL_MANG(b_dt_ct, "name");
            object[] a_time = bang.Fobj_COL_MANG(b_dt_ct, "time");
            object[] a_state = bang.Fobj_COL_MANG(b_dt_ct, "state");
            object[] a_exception = bang.Fobj_COL_MANG(b_dt_ct, "exception");
            object[] a_operation = bang.Fobj_COL_MANG(b_dt_ct, "operation");

            dbora.P_THEM_PAR(ref b_lenh, "a_id", 'U', a_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_no", 'U', a_no);
            dbora.P_THEM_PAR(ref b_lenh, "a_name", 'U', a_name);
            dbora.P_THEM_PAR(ref b_lenh, "a_time", 'U', a_time);
            dbora.P_THEM_PAR(ref b_lenh, "a_state", 'U', a_state);
            dbora.P_THEM_PAR(ref b_lenh, "a_exception", 'U', a_exception);
            dbora.P_THEM_PAR(ref b_lenh, "a_operation", 'U', a_operation);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.CTH_CSO(chuyen.OBJ_S(b_dr["thang"])) +
                ",:a_id,:a_no,:a_name,:a_time,:a_state,:a_exception,:a_operation";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_CC_CT_HAL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_TL_CC_CT_HAL_XOA(string b_thang)
    {
        dbora.P_GOIHAM(chuyen.CTH_CSO(b_thang), "PNS_TL_CC_CT_HAL_XOA");
    }
    public static DataTable Fdt_TL_CC_CT_HAL_LKE_CB(string b_phong, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang) }, "PNS_TL_CC_CT_HAL_LKE_CB");
    }
    #endregion

    #region TỔNG HỢP CHẤM CÔNG CÁ NHÂN HAL

    public static object[] Fdt_NS_CC_TONGHOP_HAL_LKE(string b_phong, string b_thang, double b_tu, double b_den)
    {
        b_thang = chuyen.CTH_CSO(b_thang);
        return dbora.Faobj_LKE(new object[] { b_phong, b_thang, b_tu, b_den }, "NR", "pns_tl_cc_ct_hal_ct_lke");
    }

    public static DataTable Fdt_NS_CC_TONGHOP_HAL_CT(string b_phong, string b_thang, string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CTH_SO(b_thang), b_so_the }, "pns_tl_cc_ct_hal_ct_ct");
    }
    #endregion

    #region CHẤM CÔNG CÔNG NHẬT CHI TIẾT NAGASE
    ///<summary>Liệt kê ngày tháng chấm công</summary>

    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_CC_CN_CT_NAGASE_CT(string b_phong, string b_ca, string b_loai, string b_thangcc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_ca, b_loai, chuyen.CTH_CSO(b_thangcc) }, "pns_cc_cn_nagase_ct");

    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PCC_CN_CT_NAGASE_NH(DataTable b_dt, DataTable b_dt_cc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        bang.P_CSO_SO(ref b_dt_cc, "ngaythuong,nghi_coluong,nghi_koluong,nghikhac,ot_ngaythuong,ot_cuoituan,ot_ngayle,nt_ngaythuong,nt_cuoituan,nt_ngayle");
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_cc, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_cc, "ten");
            object[] a_n1 = bang.Fobj_COL_MANG(b_dt_cc, "n1");
            object[] a_n2 = bang.Fobj_COL_MANG(b_dt_cc, "n2");
            object[] a_n3 = bang.Fobj_COL_MANG(b_dt_cc, "n3");
            object[] a_n4 = bang.Fobj_COL_MANG(b_dt_cc, "n4");
            object[] a_n5 = bang.Fobj_COL_MANG(b_dt_cc, "n5");
            object[] a_n6 = bang.Fobj_COL_MANG(b_dt_cc, "n6");
            object[] a_n7 = bang.Fobj_COL_MANG(b_dt_cc, "n7");
            object[] a_n8 = bang.Fobj_COL_MANG(b_dt_cc, "n8");
            object[] a_n9 = bang.Fobj_COL_MANG(b_dt_cc, "n9");
            object[] a_n10 = bang.Fobj_COL_MANG(b_dt_cc, "n10");
            object[] a_n11 = bang.Fobj_COL_MANG(b_dt_cc, "n11");
            object[] a_n12 = bang.Fobj_COL_MANG(b_dt_cc, "n12");
            object[] a_n13 = bang.Fobj_COL_MANG(b_dt_cc, "n13");
            object[] a_n14 = bang.Fobj_COL_MANG(b_dt_cc, "n14");
            object[] a_n15 = bang.Fobj_COL_MANG(b_dt_cc, "n15");
            object[] a_n16 = bang.Fobj_COL_MANG(b_dt_cc, "n16");
            object[] a_n17 = bang.Fobj_COL_MANG(b_dt_cc, "n17");
            object[] a_n18 = bang.Fobj_COL_MANG(b_dt_cc, "n18");
            object[] a_n19 = bang.Fobj_COL_MANG(b_dt_cc, "n19");
            object[] a_n20 = bang.Fobj_COL_MANG(b_dt_cc, "n20");
            object[] a_n21 = bang.Fobj_COL_MANG(b_dt_cc, "n21");
            object[] a_n22 = bang.Fobj_COL_MANG(b_dt_cc, "n22");
            object[] a_n23 = bang.Fobj_COL_MANG(b_dt_cc, "n23");
            object[] a_n24 = bang.Fobj_COL_MANG(b_dt_cc, "n24");
            object[] a_n25 = bang.Fobj_COL_MANG(b_dt_cc, "n25");
            object[] a_n26 = bang.Fobj_COL_MANG(b_dt_cc, "n26");
            object[] a_n27 = bang.Fobj_COL_MANG(b_dt_cc, "n27");
            object[] a_n28 = bang.Fobj_COL_MANG(b_dt_cc, "n28");
            object[] a_n29 = bang.Fobj_COL_MANG(b_dt_cc, "n29");
            object[] a_n30 = bang.Fobj_COL_MANG(b_dt_cc, "n30");
            object[] a_n31 = bang.Fobj_COL_MANG(b_dt_cc, "n31");
            object[] a_cong = bang.Fobj_COL_MANG(b_dt_cc, "cong");
            object[] a_anca = bang.Fobj_COL_MANG(b_dt_cc, "anca");
            object[] a_ngaythuong = bang.Fobj_COL_MANG(b_dt_cc, "ngaythuong");
            object[] a_nghi_coluong = bang.Fobj_COL_MANG(b_dt_cc, "nghi_coluong");
            object[] a_nghi_koluong = bang.Fobj_COL_MANG(b_dt_cc, "nghi_koluong");
            object[] a_nghikhac = bang.Fobj_COL_MANG(b_dt_cc, "nghikhac");
            object[] a_ot_ngaythuong = bang.Fobj_COL_MANG(b_dt_cc, "ot_ngaythuong");
            object[] a_ot_cuoituan = bang.Fobj_COL_MANG(b_dt_cc, "ot_cuoituan");
            object[] a_ot_ngayle = bang.Fobj_COL_MANG(b_dt_cc, "ot_ngayle");
            object[] a_nt_ngaythuong = bang.Fobj_COL_MANG(b_dt_cc, "nt_ngaythuong");
            object[] a_nt_cuoituan = bang.Fobj_COL_MANG(b_dt_cc, "nt_cuoituan");
            object[] a_nt_ngayle = bang.Fobj_COL_MANG(b_dt_cc, "nt_ngayle");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_n1", 'U', a_n1);
            dbora.P_THEM_PAR(ref b_lenh, "a_n2", 'U', a_n2);
            dbora.P_THEM_PAR(ref b_lenh, "a_n3", 'U', a_n3);
            dbora.P_THEM_PAR(ref b_lenh, "a_n4", 'U', a_n4);
            dbora.P_THEM_PAR(ref b_lenh, "a_n5", 'U', a_n5);
            dbora.P_THEM_PAR(ref b_lenh, "a_n6", 'U', a_n6);
            dbora.P_THEM_PAR(ref b_lenh, "a_n7", 'U', a_n7);
            dbora.P_THEM_PAR(ref b_lenh, "a_n8", 'U', a_n8);
            dbora.P_THEM_PAR(ref b_lenh, "a_n9", 'U', a_n9);
            dbora.P_THEM_PAR(ref b_lenh, "a_n10", 'U', a_n10);
            dbora.P_THEM_PAR(ref b_lenh, "a_n11", 'U', a_n11);
            dbora.P_THEM_PAR(ref b_lenh, "a_n12", 'U', a_n12);
            dbora.P_THEM_PAR(ref b_lenh, "a_n13", 'U', a_n13);
            dbora.P_THEM_PAR(ref b_lenh, "a_n14", 'U', a_n14);
            dbora.P_THEM_PAR(ref b_lenh, "a_n15", 'U', a_n15);
            dbora.P_THEM_PAR(ref b_lenh, "a_n16", 'U', a_n16);
            dbora.P_THEM_PAR(ref b_lenh, "a_n17", 'U', a_n17);
            dbora.P_THEM_PAR(ref b_lenh, "a_n18", 'U', a_n18);
            dbora.P_THEM_PAR(ref b_lenh, "a_n19", 'U', a_n19);
            dbora.P_THEM_PAR(ref b_lenh, "a_n20", 'U', a_n20);
            dbora.P_THEM_PAR(ref b_lenh, "a_n21", 'U', a_n21);
            dbora.P_THEM_PAR(ref b_lenh, "a_n22", 'U', a_n22);
            dbora.P_THEM_PAR(ref b_lenh, "a_n23", 'U', a_n23);
            dbora.P_THEM_PAR(ref b_lenh, "a_n24", 'U', a_n24);
            dbora.P_THEM_PAR(ref b_lenh, "a_n25", 'U', a_n25);
            dbora.P_THEM_PAR(ref b_lenh, "a_n26", 'U', a_n26);
            dbora.P_THEM_PAR(ref b_lenh, "a_n27", 'U', a_n27);
            dbora.P_THEM_PAR(ref b_lenh, "a_n28", 'U', a_n28);
            dbora.P_THEM_PAR(ref b_lenh, "a_n29", 'U', a_n29);
            dbora.P_THEM_PAR(ref b_lenh, "a_n30", 'U', a_n30);
            dbora.P_THEM_PAR(ref b_lenh, "a_n31", 'U', a_n31);
            dbora.P_THEM_PAR(ref b_lenh, "a_cong", 'U', a_cong);
            dbora.P_THEM_PAR(ref b_lenh, "a_anca", 'U', a_anca);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythuong", 'U', a_ngaythuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghi_coluong", 'U', a_nghi_coluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghi_koluong", 'U', a_nghi_koluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghikhac", 'U', a_nghikhac);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_ngaythuong", 'U', a_ot_ngaythuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_cuoituan", 'U', a_ot_cuoituan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ot_ngayle", 'U', a_ot_ngayle);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_ngaythuong", 'U', a_nt_ngaythuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_cuoituan", 'U', a_nt_cuoituan);
            dbora.P_THEM_PAR(ref b_lenh, "a_nt_ngayle", 'U', a_nt_ngayle);

            string b_c = "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["ca"]) + "," + chuyen.OBJ_C(b_dr["loai"]) + ","
                + chuyen.OBJ_S(b_dr["thangcc"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["t7"]) + "," + chuyen.OBJ_C(b_dr["cn"]) + "," + chuyen.OBJ_S(b_dr["ngaylam"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_n1,:a_n2,:a_n3,:a_n4,:a_n5,:a_n6,:a_n7,:a_n8,:a_n9,:a_n10,:a_n11,:a_n12,:a_n13,:a_n14,:a_n15,:a_n16,:a_n17";
            b_c = b_c + ",:a_n18,:a_n19,:a_n20,:a_n21,:a_n22,:a_n23,:a_n24,:a_n25,:a_n26,:a_n27,:a_n28,:a_n29,:a_n30,:a_n31,:a_cong,:a_anca";
            b_c = b_c + ",:a_ngaythuong,:a_nghi_coluong,:a_nghi_koluong,:a_nghikhac,:a_ot_ngaythuong,:a_ot_cuoituan,:a_ot_ngayle,:a_nt_ngaythuong,:a_nt_cuoituan,:a_nt_ngayle";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cc_cn_nagase_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    /// <summary>Xóa thông tin</summary>
    public static void PCC_CN_CT_NAGASE_XOA(string b_phong, string b_ca, string b_loai, string b_thang, string b_ngay)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_ca, b_loai, chuyen.CTH_CSO(b_thang), chuyen.CNG_CSO(b_ngay) }, "pns_cc_cn_nagase_xoa");
    }
    #endregion CHẤM CÔNG CÔNG NHẬT CHI TIẾT

    #region GIẢI TRÌNH CHẤM CÔNG

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_GT_CC_LKE(string b_so_the, string b_kyluong, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_N(b_kyluong), b_trangthai, b_tu, b_den }, "NR", "PNS_NS_GT_CC_LKE");
    }
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_CC_GT_LKE(string b_phong, string b_kyluong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.OBJ_N(b_kyluong), b_tu, b_den }, "NR", "PNS_NS_CC_GT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_NS_GT_CC_MA(string b_so_the, string b_so_id, string b_trangthai, string b_kyluong, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangthai, chuyen.OBJ_N(b_kyluong), b_trangkt }, "NNR", "PNS_NS_GT_CC_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_GT_CC_CT(string b_so_id, string b_ngay_gt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id, chuyen.CNG_SO(b_ngay_gt) }, "PNS_NS_GT_CC_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_GT_CC_CT2(int b_ngaydky, string b_loaidky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_loaidky }, "PNS_NS_GT_CC_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_GT_CC_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_gt"])
                + "," + chuyen.OBJ_C(b_dr["ly_do"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]) + "," + chuyen.OBJ_C(b_dr["macc_nghi"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_GT_CC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void P_NS_GT_CC_FILE_NH(DataTable b_dt)
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

                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["loai_dky"]) + "," + chuyen.OBJ_N(b_dr["SOPHUT"])
                    + "," + chuyen.OBJ_C("N'" + b_dr["gchu"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]);

                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_GT_CC_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_GT_CC_GUI(string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_so_the }, "PNS_NS_GT_CC_GUI");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_GT_CC_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_NS_GT_CC_XOA");
    }
    /// <summary>Xóa thôn tin</summary>
    public static DataTable Fdt_NS_GT_CC_GUI(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "pns_NS_GT_CC_gui");
    }

    #endregion GIẢI TRÌNH CHẤM CÔNG

    #region GIẢI TRINH CHẤM CÔNG
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    ///  /// <summary>Liệt kê mã ths</summary>
    ///  

    public static object[] Fdt_NS_CHAMCONG_GIAITRINH_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cc_giaitrinh_lke");
    }
    public static DataTable Fdt_NS_THS_LKEMA()
    {
        return dbora.Fdt_LKE("PNS_THS_LKEMA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_CHAMCONG_GIAITRINH_CT(string b_so_the, string b_thang)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, chuyen.CTH_CSO(b_thang) }, 2, "pns_cc_giaitrinh_ct");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_CHAMCONG_GIAITRINH_NH(DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_kq)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "Chưa phê duyệt", "0");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "Đã phê duyệt", "1");
            bang.P_THAY_GTRI(ref b_dt_kq, "tinhtrang", "Không phê duyệt", "2");
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CTH_SO(ref b_dt, "thangcc");
            DataRow b_dr = b_dt.Rows[0];
            bang.P_CNG_SO(ref b_dt_ct, "ngay_cc");
            object[] a_ngay_cc = bang.Fobj_COL_MANG(b_dt_ct, "ngay_cc");
            object[] a_giovao = bang.Fobj_COL_MANG(b_dt_ct, "giovao");
            object[] a_giove = bang.Fobj_COL_MANG(b_dt_ct, "giove");
            object[] a_nghi_koluong = bang.Fobj_COL_MANG(b_dt_ct, "nghi_koluong");
            object[] a_giaitrinh = bang.Fobj_COL_MANG(b_dt_ct, "giaitrinh");

            bang.P_CNG_SO(ref b_dt_kq, "ngay_ot");
            object[] c_ngay_ot = bang.Fobj_COL_MANG(b_dt_kq, "ngay_ot");
            object[] c_gio_bd = bang.Fobj_COL_MANG(b_dt_kq, "gio_bd");
            object[] c_gio_kt = bang.Fobj_COL_MANG(b_dt_kq, "gio_kt");
            object[] c_ot_thoigian = bang.Fobj_COL_MANG(b_dt_kq, "ot_thoigian");
            object[] c_nt_thoigian = bang.Fobj_COL_MANG(b_dt_kq, "nt_thoigian");
            object[] c_tinhtrang = bang.Fobj_COL_MANG(b_dt_kq, "tinhtrang");
            object[] c_giaitrinh = bang.Fobj_COL_MANG(b_dt_kq, "giaitrinh");


            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cc", 'U', a_ngay_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_giovao", 'U', a_giovao);
            dbora.P_THEM_PAR(ref b_lenh, "a_giove", 'U', a_giove);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghi_koluong", 'U', a_nghi_koluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_giaitrinh", 'U', a_giaitrinh);
            dbora.P_THEM_PAR(ref b_lenh, "c_ngay_ot", 'U', c_ngay_ot);
            dbora.P_THEM_PAR(ref b_lenh, "c_gio_bd", 'U', c_gio_bd);
            dbora.P_THEM_PAR(ref b_lenh, "c_gio_kt", 'U', c_gio_kt);
            dbora.P_THEM_PAR(ref b_lenh, "c_ot_thoigian", 'U', c_ot_thoigian);
            dbora.P_THEM_PAR(ref b_lenh, "c_nt_thoigian", 'U', c_nt_thoigian);
            dbora.P_THEM_PAR(ref b_lenh, "c_tinhtrang", 'U', c_tinhtrang);
            dbora.P_THEM_PAR(ref b_lenh, "c_giaitrinh", 'U', c_giaitrinh);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["thangcc"]) + "," + chuyen.OBJ_C(b_dr["nguoiduyet"]);
            b_c = b_c + ",:a_ngay_cc,:a_giovao,:a_giove,:a_nghi_koluong,:a_giaitrinh,:c_ngay_ot,:c_gio_bd,:c_gio_kt,:c_ot_thoigian,:c_nt_thoigian,:c_tinhtrang,:c_giaitrinh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cc_giaitrinh_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_CHAMCONG_GIAITRINH_XOA(string b_so_the, string b_thang)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_thang }, "PNS_THS_XOA");
    }
    public static string P_NS_GT_CC_NH2(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_gt"])
                + "," + chuyen.OBJ_C(b_dr["ly_do"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]) + "," + chuyen.OBJ_C(b_dr["macc_nghi"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_GT_CC_NH2(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    // PHÊ DUYỆT

    public static object[] Fdt_NS_CHAMCONG_GIAITRINH_PD_LKE(string b_so_the, string b_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.CTH_CSO(b_thang), b_tu, b_den }, "NR", "pns_cc_giaitrinh_pd_lke");
    }

    public static DataSet Fdt_NS_CHAMCONG_GIAITRINH_PD_CT(string b_so_the, string b_thang)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, chuyen.CTH_CSO(b_thang) }, 2, "pns_cc_giaitrinh_pd_ct");
    }


    public static void P_NS_CHAMCONG_GIAITRINH_PHEDUYET(string b_so_the, string b_thang, string b_tinhtrang, DataTable b_dt_ct, DataTable b_dt_kq)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt_ct, "ngay_cc");
            object[] a_ngay_cc = bang.Fobj_COL_MANG(b_dt_ct, "ngay_cc");
            object[] a_pheduyet = bang.Fobj_COL_MANG(b_dt_ct, "pheduyet");

            bang.P_CNG_SO(ref b_dt_kq, "ngay_ot");
            object[] c_ngay_ot = bang.Fobj_COL_MANG(b_dt_kq, "ngay_ot");
            object[] c_pheduyet = bang.Fobj_COL_MANG(b_dt_kq, "pheduyet");


            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cc", 'U', a_ngay_cc);
            dbora.P_THEM_PAR(ref b_lenh, "a_pheduyet", 'U', a_pheduyet);
            dbora.P_THEM_PAR(ref b_lenh, "c_ngay_ot", 'U', c_ngay_ot);
            dbora.P_THEM_PAR(ref b_lenh, "c_pheduyet", 'U', c_pheduyet);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + "," + chuyen.OBJ_C(chuyen.CTH_CSO(b_thang)) + "," + chuyen.OBJ_C(b_tinhtrang);
            b_c = b_c + ",:a_ngay_cc,:a_pheduyet,:c_ngay_ot,:c_pheduyet";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cc_giaitrinh_pheduyet(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion GIẢI TRINH CHẤM CÔNG

    #region QUẢN LÝ ĐI MUỘN VỀ SỚM

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_CC_DKY_DMVS_LKE(string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_CC_DKY_DMVS_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_CC_DKY_DMVS_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_CC_DKY_DMVS_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_DKY_DMVS_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_DKY_DMVS_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_DKY_DMVS_CT2(int b_ngaydky, string b_loaidky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_loaidky }, "PNS_CC_DKY_DMVS_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PCC_DKY_DMVS_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["loai_dky"]) + "," + chuyen.OBJ_N(b_dr["SOPHUT"])
                + "," + chuyen.OBJ_C(b_dr["gchu"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_DMVS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void PCC_DKY_DMVS_FILE_NH(DataTable b_dt)
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

                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_N(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["loai_dky"]) + "," + chuyen.OBJ_N(b_dr["SOPHUT"])
                    + "," + chuyen.OBJ_C("N'" + b_dr["gchu"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"]);

                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_DMVS_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_CC_DKY_DMVS_EXPORT()
    {
        return dbora.Fdt_LKE("P_CC_DKY_DMVS_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PCC_DKY_DMVS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_DKY_DMVS_XOA");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region QUẢN LÝ LÀM THÊM

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_CC_DKY_LAMTHEM_LKE(string b_so_the, string b_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_S(chuyen.CTH_CSO(b_thang)), b_tu, b_den }, "NR", "PNS_CC_DKY_LAMTHEM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_CC_DKY_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_CC_DKY_LAMTHEM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_DKY_LAMTHEM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_DKY_LAMTHEM_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_DKY_LAMTHEM_CT2(int b_ngaydky, string b_hso)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_hso }, "PNS_CC_DKY_LAMTHEM_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PCC_DKY_LAMTHEM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            var ngay = chuyen.CNG_SO(b_dr["ngay_dky"].ToString());
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_dky"].ToString() + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["so_gio"]) + "," + chuyen.OBJ_C(b_dr["hso"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void PCC_DKY_LAMTHEM_FILE_NH(DataTable b_dt)
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
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C("N'" + b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["so_gio"]) + "," + chuyen.OBJ_C(b_dr["hso"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKY_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_CC_DKY_LAMTHEM_EXPORT()
    {
        return dbora.Fdt_LKE("P_CC_DKY_LAMTHEM_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PCC_DKY_LAMTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_DKY_LAMTHEM_XOA");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region QUẢN LÝ KHAI BÁO LÀM THÊM

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_CC_KHAIBAO_LAMTHEM_LKE(string b_so_the, string b_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, chuyen.OBJ_S(chuyen.CTH_CSO(b_thang)), b_tu, b_den }, "NR", "PNS_CC_KHAIBAO_LAMTHEM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_CC_KHAIBAO_LAMTHEM_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_CC_KHAIBAO_LAMTHEM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_KHAIBAO_LAMTHEM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CC_KHAIBAO_LAMTHEM_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PCC_KHAIBAO_LAMTHEM_CT2(int b_ngaydky, string b_hso)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_hso }, "PNS_CC_KHAIBAO_LAMTHEM_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PCC_KHAIBAO_LAMTHEM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            var ngay = chuyen.CNG_SO(b_dr["ngay_dky"].ToString());
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_dky"].ToString() + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]) + "," + chuyen.OBJ_C(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_C(b_dr["so_gio_nb"]) + "," + chuyen.OBJ_C(b_dr["so_gio"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KHAIBAO_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void PCC_KHAIBAO_LAMTHEM_FILE_NH(DataTable b_dt)
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
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C("N'" + b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]) + "," + chuyen.OBJ_C(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_C(b_dr["so_gio_nb"]) + "," + chuyen.OBJ_C(b_dr["so_gio"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KHAIBAO_LAMTHEM_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    public static void PNS_KB_LTHEM_FILE_NH(DataTable b_dt)
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
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["HINHTHUC"]) + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"])
                + "," + chuyen.OBJ_C(b_dr["so_gio_dem"]) + "," + chuyen.OBJ_C(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_C("N'" + b_dr["noidung"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KB_LTHEM_NH(" + b_se.tso + b_c + "); end;";

                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_CC_KHAIBAO_LAMTHEM_EXPORT()
    {
        return dbora.Fdt_LKE("P_CC_DKY_LAMTHEM_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PCC_KHAIBAO_LAMTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CC_KHAIBAO_LAMTHEM_XOA");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region QUẸT THẺ
    public static object[] Fdt_CC_QUET_THE_LKE(double ngayd, double ngayc, string so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { ngayd, ngayc, so_the, b_tu, b_den }, "NR", "PNS_CC_QUETTHE_LKE");
    }
    public static object[] Faobj_CC_QUET_THE_LKE(string b_phong, double ngayd, double ngayc, string so_the, string b_ho_ten, string b_dimuon, string b_vesom, string b_cangay, double b_trangkt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, ngayd, ngayc, so_the, "N" + chuyen.OBJ_C(b_ho_ten.ToUpper()), b_dimuon, b_vesom, b_cangay, b_tu, b_den }, "NR", "PNS_CC_VANTAY_LKE");
    }
    public static object[] Faobj_CC_QUET_THE_LKE_NSD(string b_phong, double ngayd, double ngayc, string so_the, string b_ho_ten, string b_dimuon, string b_vesom, string b_cangay, double b_trangkt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, ngayd, ngayc, so_the, "N" + chuyen.OBJ_C(b_ho_ten.ToUpper()), b_dimuon, b_vesom, b_cangay, b_tu, b_den }, "NR", "PNS_CC_VANTAY_LKE_NSD");
    }
    public static DataTable Fdt_CC_MAY_CC_MA(string b_may_cc)
    {
        return dbora.Fdt_LKE_S(b_may_cc, "PNS_CC_MAY_CC_MA");
    }

    public static void P_CC_QUET_THE_NH(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_vantay = bang.Fobj_COL_MANG(b_dt_ct, "vantay");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_vantay", 'S', a_vantay);

            string b_c = ",:a_ma,:a_vantay";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_QUET_THE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_CC_QUET_THE_IMP(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_vantay = bang.Fobj_COL_MANG(b_dt_ct, "vantay");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_vantay", 'S', a_vantay);

            string b_c = ",:a_ma,:a_vantay";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_QUET_THE_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();	  // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.CC_DULIEU_VAORA, TEN_BANG.CC_DULIEU_VAORA);

            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_CC_TAI_QUET_THE_NH(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "MA_CC");
            object[] a_vantay = bang.Fobj_COL_MANG(b_dt_ct, "VAN_TAY");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_vantay", 'S', a_vantay);

            string b_c = ",:a_ma,:a_vantay";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_QUET_THE_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion QUẸT THẺ

    #region CHẤM CÔNG KHÁC GIỜ CÔNG TY
    public static object[] Fdt_Fs_CC_KHACGIO_CTY_LKE(double b_tu_n, double b_den_n, string b_phong, string b_so_the, double b_tungay, double b_denngay)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_phong, b_so_the, b_tungay, b_denngay }, "NR", "PNS_CC_KHACGIO_CTY_LKE");
    }
    #endregion CHẤM CÔNG KHÁC GIỜ CÔNG TY

    #region HỆ SỐ LÀM THÊM
    public static DataTable Fdt_CC_MA_HSO_LAMTHEM_DR()
    {
        return dbora.Fdt_LKE("pns_ma_hso_lamthem_dr");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_CC_MA_HSO_LAMTHEM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_CC_MA_HSO_LAMTHEM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_CC_MA_HSO_LAMTHEM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_CC_MA_HSO_LAMTHEM_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_CC_MA_HSO_LAMTHEM_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"] }, "PNS_CC_MA_HSO_LAMTHEM_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_CC_MA_HSO_LAMTHEM_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_CC_MA_HSO_LAMTHEM_XOA");
    }
    #endregion MÃ HÌNH THỨC THÔI VIỆC

    #region QUẢN LÝ KHAI BÁO LÀM THÊM

    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_CC_KB_LTHEM_LKE(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_tu, b_den }, "NR", "PNS_NS_CC_KB_LTHEM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_NS_CC_KB_LTHEM_MA(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_so_id, b_trangkt }, "NNR", "PNS_NS_CC_KB_LTHEM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_CC_KB_LTHEM_CT(string b_so_the, string b_ngay_dky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngay_dky) }, "PNS_NS_CC_KB_LTHEM_CT");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_CC_KB_LTHEM_CT2(int b_ngaydky, string b_hso)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_hso }, "PNS_NS_CC_KB_LTHEM_CT2");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_CC_KB_LTHEM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            var ngay = chuyen.CNG_SO(b_dr["ngay_dky"].ToString());
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_dky"].ToString() + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]) + "," + chuyen.OBJ_N(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_N(b_dr["so_gio_dem"]) + "," + chuyen.OBJ_N(b_dr["sg_ngay_nb"]) + "," + chuyen.OBJ_N(b_dr["sg_dem_nb"]) + "," + chuyen.OBJ_N(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_C(b_dr["HINHTHUC"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_KB_LTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string P_NS_CC_KB_LTHEM_IMP(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            foreach (DataRow drow in b_dt.Rows)
            {
                DataRow b_dr = drow;
                var ngay = b_dr["ngay_dky"].ToString();
                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngay_dky"].ToString()) + "," + chuyen.OBJ_C(b_dr["hso"].ToString())
                    + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_N(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_N(b_dr["so_gio_dem"]) + "," + chuyen.OBJ_N(b_dr["sg_ngay_nb"]) + "," + chuyen.OBJ_N(b_dr["sg_dem_nb"]) + "," + chuyen.OBJ_N(b_dr["so_gio_tt"])
                    + "," + "N" + chuyen.OBJ_C(b_dr["NOIDUNG"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_KB_LTHEM_IMP(" + b_se.tso + b_c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
                finally { b_lenh.Parameters.Clear(); }
            }
            return b_so_id = "";
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_CC_KB_LTHEM_FILE_NH(DataTable b_dt)
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
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_C(b_dr["NGHIBU"])
                + "," + chuyen.OBJ_C("N'" + b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]) + "," + chuyen.OBJ_C(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_C(b_dr["so_gio_nb"]) + "," + chuyen.OBJ_C(b_dr["so_gio"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_KB_LTHEM_NH(" + b_se.tso + b_c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                }
                finally { b_lenh.Parameters.Clear(); }
            }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable Fdt_NS_CC_KB_LTHEM_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_CC_KB_LTHEM_EXPORT");
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_CC_KB_LTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_NS_CC_KB_LTHEM_XOA");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region QUẢN LÝ ĐĂNG KÝ LÀM THÊM  
    public static object[] Faobj_NS_CC_DKY_LTHEM_LKE(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_tu, b_den }, "NR", "PNS_NS_CC_DKY_LTHEM_LKE");
    }
    public static object[] Faobj_NS_CC_DKY_LTHEM_MA(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_so_id, b_trangkt }, "NNR", "PNS_NS_CC_DKY_LTHEM_MA");
    }
    public static DataTable Fdt_NS_CC_DKY_LTHEM_CT(string b_so_the, string b_ngay_dky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngay_dky) }, "PNS_NS_CC_DKY_LTHEM_CT");
    }
    public static string P_NS_CC_DKY_LTHEM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            var ngay = chuyen.CNG_SO(b_dr["ngay_bd"].ToString());
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_bd"].ToString() + "," + chuyen.OBJ_C(b_dr["HINHTHUC"]) + "," + chuyen.OBJ_C(b_dr["lthem_theoluat"])
                        + "," + chuyen.OBJ_C(b_dr["loai_lt"]) + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"]) + "," + chuyen.OBJ_N(b_dr["sogio_nghigiuaca"]) 
                        + "," + chuyen.OBJ_N(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_N(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_N(b_dr["so_gio_dem"])
                        + "," + chuyen.OBJ_N(b_dr["sg_ngay_nb"]) + "," + chuyen.OBJ_N(b_dr["sg_dem_nb"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKY_LTHEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_CC_DKY_LTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_NS_CC_DKY_LTHEM_XOA");
    }
    public static DataTable Fdt_NS_CC_DKY_LTHEM_EXPORT()
    {
        return dbora.Fdt_LKE("PNS_CC_DKY_LTHEM_EXPORT");
    }
    public static string P_NS_CC_DKY_LTHEM_IMP(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            foreach (DataRow drow in b_dt.Rows)
            {
                DataRow b_dr = drow;
                var ngay = chuyen.CNG_SO(b_dr["ngay_dky"].ToString());
                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_dky"].ToString() + "," + chuyen.OBJ_C(b_dr["GIO_BD"]) + "," + chuyen.OBJ_C(b_dr["GIO_KT"])
                    + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]) + "," + chuyen.OBJ_N(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_N(b_dr["so_gio_dem"]) + "," + chuyen.OBJ_N(b_dr["sg_ngay_nb"]) + "," + chuyen.OBJ_N(b_dr["sg_dem_nb"]) + "," + chuyen.OBJ_N(b_dr["so_gio_tt"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_DKY_LTHEM_IMP(" + b_se.tso + b_c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                    //return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
                }
                catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
                finally { b_lenh.Parameters.Clear(); }
            }
            return "";
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_CC_DKY_LTHEM_CT2(int b_ngaydky, string b_hso)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_hso }, "PNS_NS_CC_DKY_LTHEM_CT2");
    }
    public static DataTable Fdt_NS_CC_LAY_NGAYLE(int b_ngaydky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky }, "PNS_CC_LAY_NGAYLE");
    }
    public static DataTable Fdt_NS_CC_LAY_DULIEU_LT(int b_ngaydky, string b_sothe)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_sothe }, "PNS_CC_LAY_DULIEU_LT");
    }
    public static DataTable Fdt_NS_CC_LAY_DULIEUKB_LT(int b_ngaydky, string b_sothe)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_sothe }, "PNS_CC_LAY_DULIEUKB_LT");
    }
    public static DataTable Fdt_NS_CC_LAY_DULIEUDKY_LT(int b_ngaydky, string b_sothe)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ngaydky, b_sothe }, "PNS_CC_LAY_DULIEUDKY_LT");
    }

    #endregion ĐĂNG KÝ LÀM THÊM GIỜ

    #region QUẢN LÝ ĐĂNG KÝ CÁ NHÂN LÀM THÊM
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Faobj_NS_CC_CN_DKY_LTHEM_LKE(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_tu, b_den }, "NR", "PNS_NS_CC_CN_DKY_LTHEM_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Faobj_NS_CC_CN_DKY_LTHEM_MA(string b_so_the, string b_hoten, string b_ngayd, string b_ngayc, string b_phong, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_phong, b_so_id, b_trangkt }, "NNR", "PNS_NS_CC_CN_DKY_LTHEM_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_CC_CN_DKY_LTHEM_CT(string b_so_the, string b_ngay_dky)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngay_dky) }, "PNS_NS_CC_CN_DKY_LTHEM_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_CC_CN_DKY_LTHEM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            var ngay = chuyen.CNG_SO(b_dr["ngay_bd"].ToString());
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + b_dr["ngay_bd"].ToString() + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["lthem_theoluat"])
                        + "," + chuyen.OBJ_C(b_dr["loai_lt"]) + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_N(b_dr["sogio_nghigiuaca"]) 
                        + "," + chuyen.OBJ_N(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_N(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_N(b_dr["so_gio_dem"])
                        + "," + chuyen.OBJ_N(b_dr["sg_ngay_nb"]) + "," + chuyen.OBJ_N(b_dr["sg_dem_nb"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"]);

            //var ngay = chuyen.CNG_SO(b_dr["ngay_dky"].ToString());
            //dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngay_dky"]) + "," + chuyen.OBJ_C(b_dr["gio_bd"])
            //    + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_C(b_dr["nghibu"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hso"])
            //    + "," + chuyen.OBJ_C(b_dr["so_gio_ngay"]) + "," + chuyen.OBJ_C(b_dr["so_gio_dem"]) + "," + chuyen.OBJ_C(b_dr["so_gio_tt"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_CN_DKY_LTHEM_NH(" + b_se.tso + b_c + "); end;";
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
    public static void P_NS_CC_CN_DKY_LTHEM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_NS_CC_CN_DKY_LTHEM_XOA");
    }
    public static void P_CC_CN_DKY_LTHEM_GUI(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_so_the }, "PNS_CC_CN_DKY_LTHEM_GUI");
    }
    #endregion ĐĂNG KÝ CÁ NHÂN LÀM THÊM GIỜ

    #region XEM PHÉP NĂM NHÂN VIÊN
    public static object[] Fdt_NS_QT_PHEP_NAM_LKE(string b_so_the, string b_nam, string b_kyluong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_nam, b_kyluong, b_tu, b_den }, "NR", "PNS_NS_QT_PHEP_NAM_LKE");
    }

    #endregion

    #region CÔNG CHUẨN NHÂN VIÊN 
    public static object[] Fdt_NS_CC_CCNV_LKE(string b_nam, string b_kyluong, string b_dtuong, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), chuyen.OBJ_N(b_kyluong), b_dtuong, b_tu_n, b_den_n }, "NR", "PNS_NS_CC_CCNV_LKE");
    }
    public static DataTable Fdt_NS_CC_CCNV_TUNG_DENNG(string b_kyluong)
    {
        return dbora.Fdt_LKE_S(b_kyluong, "PNS_NS_CC_CCNV_TUNG_DENNG");
    }
    public static string P_NS_CC_CCNV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt_ct, "ngayc");
            object[] a_so_qd = bang.Fobj_COL_MANG(b_dt_ct, "so_qd");
            object[] a_cong_chuan = bang.Fobj_COL_MANG(b_dt_ct, "cong_chuan");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_qd", 'N', a_so_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cong_chuan", 'N', a_cong_chuan);

            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["kyluong"]);
            b_c = b_c + ",:a_so_the,:a_ngayd,:a_ngayc,:a_so_qd,:a_cong_chuan";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CC_CCNV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string P_NS_CC_MA_CCNV_IMP_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CSO_SO(ref b_dt, "nam,kyluong,so_qd,cong_chuan");
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            DataRow b_dr = b_dt.Rows[0];
            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_kyluong = bang.Fobj_COL_MANG(b_dt, "kyluong");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_so_qd = bang.Fobj_COL_MANG(b_dt, "so_qd");
            object[] a_cong_chuan = bang.Fobj_COL_MANG(b_dt, "cong_chuan");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");

            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_kyluong", 'N', a_kyluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_qd", 'N', a_so_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cong_chuan", 'N', a_cong_chuan);

            string b_c = ",:a_nam,:a_kyluong,:a_so_the,:a_ngayd,:a_ngayc,:a_so_qd,:a_cong_chuan";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_MA_CCNV_NH_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex) { return ex.Message; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion 
}