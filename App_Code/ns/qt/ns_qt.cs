using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_qt
{
    #region PHÊ DUYỆT DANH SÁCH GIẢI TRÌNH CHẤM CÔNG
    public static object[] Fdt_NS_GT_CC_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_GT_CC_PD_LKE");
    }

    public static DataTable Fdt_NS_GT_CC_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
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
            string b_c = "," + chuyen.OBJ_C(b_phong) + "," + chuyen.OBJ_C(b_tinhtrang) + "," + chuyen.CNG_SO(b_tungay) + "," + chuyen.CNG_SO(b_denngay) + ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_GT_CC_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_GT_CC_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
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
            string b_c = "," + chuyen.OBJ_C(b_phong) + "," + chuyen.OBJ_C(b_tinhtrang) + "," + chuyen.CNG_SO(b_tungay) + "," + chuyen.CNG_SO(b_denngay) + ",:a_so_id,:a_so_the,:a_lydo_ld,:cs_1";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_GT_CC_PD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_GT_CC_PD_CT(string b_so_the, string b_ngayxn, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayxn), chuyen.CNG_CSO(b_ngayd) }, "PNS_GT_CC_PD_CT");
    }

    #endregion PHÊ DUYỆT DANH SÁCH GIẢI TRÌNH CHẤM CÔNG

    #region QUẢN LÝ ĐIỀU CHUYỂN GIỮA CÁC CÔNG TY THÀNH VIÊN
    public static DataTable Fdt_MA_CDANH_BY_PHONG_CP(string b_congty, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_congty, b_phong }, "pns_ma_cdanh_by_phong_cp");
    }
    public static string P_NS_CP_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"])
                + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," + chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["luong_cb"])
                + "," + chuyen.OBJ_S(b_dr["thunhap_thang"]) + "," + chuyen.OBJ_S(b_dr["thuong_thang"]) + "," + chuyen.OBJ_C(b_dr["cong_ty"]) + "," + chuyen.OBJ_C(b_dr["phong"])
                + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["so_qd"])
                + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["tt"])
                + "," + chuyen.OBJ_C(b_dr["nguoi_ky"]) + "," + chuyen.OBJ_C(b_dr["cdanh_ky"]) + "," + chuyen.OBJ_S(b_dr["ngay_ky"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_CP_MA(string b_so_id, string b_so_the, string b_ten, string b_phong, double b_ngayd, double b_ngayc, string b_tt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, "N'" + b_ten, b_phong, b_ngayd, b_ngayc, b_tt, b_trangkt }, "NNR", "PNS_CP_MA");
    }
    public static object[] Faobj_NS_CP_LKE(string b_so_the, string b_ten, string b_phong, double b_ngayd, double b_ngayc, string b_tt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_ngayd, b_ngayc, b_tt, b_tu, b_den }, "NR", "PNS_CP_LKE");
    }
    public static DataTable Fdt_NS_CP_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_CP_CT");
    }
    public static void P_NS_CP_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_CP_XOA");
    }
    #endregion QUẢN LÝ ĐIỀU CHUYỂN GIỮA CÁC CÔNG TY THÀNH VIÊN

    #region GIA CẢNH
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_SGC_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_SGC_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_SGC_NH(string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_sgc = bang.Fobj_COL_MANG(b_dt, "sgc");
            object[] a_tbt = bang.Fobj_COL_MANG(b_dt, "tbt");

            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'S', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_sgc", 'N', a_sgc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tbt", 'S', a_tbt);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + ",:a_ngayd,:a_sgc,:a_tbt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_SGC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion GIA CẢNH

    #region PHỤ CẤP
    /// <summary>Liệt kê toan bo</summary>
    public static DataTable Fdt_NS_PCAP_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_PCAP_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_PCAP_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayd) }, "PNS_PCAP_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_PCAP_NH(string b_so_the, string b_ngayd, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_lpcap = bang.Fobj_COL_MANG(b_dt, "lpcap");

            dbora.P_THEM_PAR(ref b_lenh, "a_lpcap", 'S', a_lpcap);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + "," + chuyen.CNG_CSO(b_ngayd) + ",:a_lpcap";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_PCAP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion PHỤ CẤP

    #region HỆ SỐ DOANH THU
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_HSDT_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_HSDT_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HSDT_NH(string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt, "loai");
            object[] a_hsdt = bang.Fobj_COL_MANG(b_dt, "hsdt");

            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'S', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_hsdt", 'N', a_hsdt);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + ",:a_ngayd,:a_loai,:a_hsdt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HSDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion HỆ SỐ DOANH THU

    #region THU BẢO HIỂM
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TBH_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TBH_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TBH_NH(string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_xh = bang.Fobj_COL_MANG(b_dt, "xh");
            object[] a_yt = bang.Fobj_COL_MANG(b_dt, "yt");
            object[] a_tn = bang.Fobj_COL_MANG(b_dt, "tn");

            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'S', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_xh", 'S', a_xh);
            dbora.P_THEM_PAR(ref b_lenh, "a_yt", 'S', a_yt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tn", 'S', a_tn);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + ",:a_ngayd,:a_xh,:a_yt,:a_tn";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TBH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion THU BẢO HIỂM

    #region SỐ NGÀY CƯ TRÚ
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_SCT_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_SCT_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_SCT_NH(string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_sct = bang.Fobj_COL_MANG(b_dt, "sct");

            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'S', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_sct", 'N', a_sct);

            string b_c = "," + chuyen.OBJ_C(b_so_the) + ",:a_ngayd,:a_sct";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_SCT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion SỐ NGÀY CƯ TRÚ

    #region HỢP ĐỒNG
    public static void P_NS_HD_MO_CHOPD(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new string[] { b_so_id, b_so_the }, "PNS_HD_MO_CHOPD");
    }

    ///<summary>lay he so phu cap</summary> 
    public static DataTable Fdt_NS_MA_CVU_HOI(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_CVU_HOI");
    }
    public static DataTable Fdt_NS_THONGTIN_DONGIA(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_THONGTIN_DONGIA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static object[] Fdt_NS_HD_LKE(string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, b_lhd, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_trangthai, b_tu_n, b_den_n }, "NR", "PNS_HD_LKE");
    }
    public static object[] Fdt_NS_HD_TT_LKE(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_tungay, string b_denngay, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu_n, b_den_n }, "NR", "PNS_HD_TT_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary> 
    public static DataSet Fdt_NS_HD_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HD_CT");
    }

    public static DataTable Fdt_NS_CHITIET_HD_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CHITIET_HD_CT");
    }
    public static object[] Faobj_NS_HD_MA(string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N" + chuyen.OBJ_C(b_ten), b_phong, b_nghi_viec, b_lhd, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_trangthai, b_so_id, b_trangkt }, "NNR", "PNS_HD_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HD_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_ct, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_ct, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["so_hd"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngayd"], "null") + "," + chuyen.OBJ_S(b_dr["ngayc"], "null") + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," + chuyen.OBJ_C(b_dr["tg_lv"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_ky"], "null") + "," + chuyen.OBJ_S(b_dr["trang_thai"], "null") + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ten_cdanh_nguoiky"]);
            //b_c = b_c + "," + chuyen.OBJ_C(b_dr["lng"]) + "," + chuyen.OBJ_C(b_dr["ngach"]) + "," + chuyen.OBJ_C(b_dr["bac"]) + "," + chuyen.OBJ_C(b_dr["hso"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," + chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["luongcb"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tien_tdgt"], "0") + "," + chuyen.OBJ_S(b_dr["tienbh"], "0") + "," + chuyen.OBJ_S(b_dr["tien_tns"], "0") + "," + chuyen.OBJ_S(b_dr["luong"], "0") + "," + chuyen.OBJ_S(b_dr["phantram_luong"], "0");
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["hddau"]) + "," + chuyen.OBJ_C(b_dr["tratheo"]) + "," + chuyen.OBJ_C(b_dr["loailuong"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["luonght"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["vitri"]) + "," + chuyen.OBJ_C(b_dr["ttr"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["dongia"]) + "," + chuyen.OBJ_C(b_dr["tyle_hoahong"]) + "," + chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]);
            b_c = b_c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_HD_PD(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_ct, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_ct, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["so_hd"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngayd"], "null") + "," + chuyen.OBJ_S(b_dr["ngayc"], "null") + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," + chuyen.OBJ_C(b_dr["tg_lv"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_ky"], "null") + "," + chuyen.OBJ_S(b_dr["trang_thai"], "null") + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ten_cdanh_nguoiky"]);
            //b_c = b_c + "," + chuyen.OBJ_C(b_dr["lng"]) + "," + chuyen.OBJ_C(b_dr["ngach"]) + "," + chuyen.OBJ_C(b_dr["bac"]) + "," + chuyen.OBJ_C(b_dr["hso"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," + chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["luongcb"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tien_tdgt"], "0") + "," + chuyen.OBJ_S(b_dr["tienbh"], "0") + "," + chuyen.OBJ_S(b_dr["tien_tns"], "0") + "," + chuyen.OBJ_S(b_dr["luong"], "0") + "," + chuyen.OBJ_S(b_dr["phantram_luong"], "0");
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["hddau"]) + "," + chuyen.OBJ_C(b_dr["tratheo"]) + "," + chuyen.OBJ_C(b_dr["loailuong"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["luonght"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["vitri"]) + "," + chuyen.OBJ_C(b_dr["ttr"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["dongia"]) + "," + chuyen.OBJ_C(b_dr["tyle_hoahong"]) + "," + chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]);
            b_c = b_c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HD_PD(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_HD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HD_XOA");
    }
    public static DataTable Fdt_NS_THONGTIN_QD(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "pns_thongtin_qd");
    }
    public static DataTable Fdt_NS_TONG_HD_CPD()
    {
        return dbora.Fdt_LKE("PNS_TONG_HD_CPD");
    }
    public static DataTable Fdt_NS_THONGTIN_QD_BYMA(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "pns_thongtin_qd_byma");
    }
    public static DataTable Fdt_NS_HD_BYDATE(double so_id, string b_so_the, string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { so_id, b_so_the, chuyen.CNG_SO(b_tungay), chuyen.CNG_CSO(b_denngay) }, "PNS_HD_BYDATE");
    }
    public static void P_NS_HD_TL(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id" + "," + b_dt.Rows[0]["ngay_tl"].ToString();

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_HD_TL(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_NS_HD_IN(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HD_IN");
    }
    public static DataSet Fdt_NS_HD_LKE_ALL(string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, b_lhd, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_trangthai }, 2, "PNS_HD_LKE_ALL");
    }

    #endregion HỢP ĐỒNG

    #region PHỤ LỤC HỢP ĐỒNG
    public static object[] Fdt_NS_HD_PL_LKE(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_so_hd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, b_so_hd, b_tu_n, b_den_n }, "NR", "PNS_HD_PL_LKE");
    }
    public static DataSet Fdt_NS_HD_CT_BY_SOHD(string b_so_hd)
    {
        return dbora.Fds_LKE(b_so_hd, 2, "PNS_HD_CT_BY_SOHD");
    }
    public static void P_NS_HD_PL_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_ct, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_ct, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["so_hd"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngayd"], "null") + "," + chuyen.OBJ_S(b_dr["ngayc"], "null") + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," + chuyen.OBJ_C(b_dr["tg_lv"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_ky"], "null") + "," + chuyen.OBJ_S(b_dr["trang_thai"], "null") + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["cdanh_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," + chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["tien_lcb"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tien_tdgt"], "0") + "," + chuyen.OBJ_S(b_dr["tienbh"], "0") + "," + chuyen.OBJ_S(b_dr["tien_tns"], "0") + "," + chuyen.OBJ_S(b_dr["tien"], "0") + "," + chuyen.OBJ_S(b_dr["phantram_luong"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["dongia"], "0") + "," + chuyen.OBJ_S(b_dr["tyle_hoahong"], "0") + "," + chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["hddau"]) + "," + chuyen.OBJ_C(b_dr["tratheo"]) + "," + chuyen.OBJ_C(b_dr["loailuong"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["luonght"]) + "," + chuyen.OBJ_C(b_dr["so_hd_pl"]) + "," + chuyen.OBJ_C(b_dr["ten_hd_pl"]);
            b_c = b_c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HD_PL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_HD_PL_PD(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_ct, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_ct, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_ct, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_ct, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["so_hd"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngayd"], "null") + "," + chuyen.OBJ_S(b_dr["ngayc"], "null") + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," + chuyen.OBJ_C(b_dr["tg_lv"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_ky"], "null") + "," + chuyen.OBJ_S(b_dr["trang_thai"], "null") + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["cdanh_nguoiky"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," + chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["tien_lcb"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tien_tdgt"], "0") + "," + chuyen.OBJ_S(b_dr["tienbh"], "0") + "," + chuyen.OBJ_S(b_dr["tien_tns"], "0") + "," + chuyen.OBJ_S(b_dr["tien"], "0") + "," + chuyen.OBJ_S(b_dr["phantram_luong"], "0");
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["dongia"], "0") + "," + chuyen.OBJ_S(b_dr["tyle_hoahong"], "0") + "," + chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["hddau"]) + "," + chuyen.OBJ_C(b_dr["tratheo"]) + "," + chuyen.OBJ_C(b_dr["loailuong"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["luonght"]) + "," + chuyen.OBJ_C(b_dr["so_hd_pl"]) + "," + chuyen.OBJ_C(b_dr["ten_hd_pl"]);
            b_c = b_c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HD_PL_PD(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_NS_HD_PL_IN(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HD_PL_IN");
    }
    #endregion

    #region HỢP ĐỒNG QUẢN LÝ CÔNG VIỆC
    ///<summary>lay he so phu cap</summary>
    /// 
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_HD_QLCV_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_HD_QLCV_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_HD_QLCV_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HD_QLCV_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HD_QLCV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["so_hd"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_ky"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_C(b_dr["ngayc"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cv_plam"]) + "," + chuyen.OBJ_C(b_dr["cvu"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["hspc"]);
            //b_c = b_c + "," + chuyen.OBJ_C(b_dr["lng"]) + "," + chuyen.OBJ_C(b_dr["ngach"]) + "," + chuyen.OBJ_C(b_dr["bac"]) + "," + chuyen.OBJ_C(b_dr["hso"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ncd"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["bcd"]) + "," + chuyen.OBJ_C(b_dr["hscd"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tien"]) + "," + chuyen.OBJ_C(b_dr["tienbh"]) + "," + chuyen.OBJ_C(b_dr["ma_nte"]) + "," + chuyen.OBJ_C(b_dr["hthl"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tg_lv"]) + "," + chuyen.OBJ_C(b_dr["dc_ld"]) + "," + chuyen.OBJ_C(b_dr["ptdl"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["phucap"]) + "," + chuyen.OBJ_C(b_dr["nangluong"]) + "," + chuyen.OBJ_C(b_dr["nghingoi"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["bhyt_xh"]) + "," + chuyen.OBJ_C(b_dr["daotao"]) + "," + chuyen.OBJ_C(b_dr["thuong"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["bhld"]) + "," + chuyen.OBJ_C(b_dr["boithuong"]) + "," + chuyen.OBJ_C(b_dr["thoathuan"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["note"]) + "," + chuyen.OBJ_C(b_dr["tratheo"]) + "," + chuyen.OBJ_C(b_dr["ngaynghi"]) + "," + chuyen.OBJ_C(b_dr["loailuong"]) + "," + chuyen.OBJ_C(b_dr["sl_yc"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HD_QLCV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_HD_QLCV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HD_QLCV_XOA");
    }
    public static DataTable Fdt_NS_HD_QLCV_BYDATE(double so_id, string b_so_the, string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { so_id, b_so_the, chuyen.CNG_SO(b_tungay), chuyen.CNG_CSO(b_denngay) }, "PNS_HD_QLCV_BYDATE");
    }

    public static void P_NS_HD_QLCV_TL(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id" + "," + b_dt.Rows[0]["ngay_tl"].ToString();

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_MA_HD_TL(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    #endregion HỢP ĐỒNG

    #region QUÁ TRÌNH LÀM VIỆC
    public static DataTable Fdt_NS_MA_HTCTAC_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_MA_HTCTAC_CT");
    }
    ///<summary>Liệt kê thông tin nhân sự</summary>
    public static DataTable Fdt_NS_HDCT_CB(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_HDCT_CB");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static object[] Fdt_NS_HDCT_LKE(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, b_loaiqd, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_trangthai, b_tu_n, b_den_n }, "NR", "PNS_HDCT_LKE");
    }
    public static object[] Fdt_NS_HDCT_TT_LKE(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_tungay, string b_denngay, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_ten, b_phong, b_nghi_viec, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu_n, b_den_n }, "NR", "PNS_HDCT_TT_LKE");
    }
    public static object[] Faobj_NS_HDCT_MA(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N" + chuyen.OBJ_C(b_ten), b_phong, b_nghi_viec, b_loaiqd, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_trangthai, b_so_id, b_trangkt }, "NNR", "PNS_HDCT_MA");
    }
    public static object[] Fdt_NS_HD_TT_LKE(string b_so_the, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu_n, b_den_n }, "NR", "PNS_HD_TT_LKE");
    }

    /// <summary>Xuất Excel</summary>
    public static DataTable Fdt_NS_HDCT_LKE_ALL(string b_so_the, string b_ten, string b_phong, string b_nghi_viec)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_ten, b_phong, b_nghi_viec }, "PNS_HDCT_LKE_ALL");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_HDCT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_HDCT_CT");
    }

    /// <summary>Mở chờ PD</summary>
    public static void P_NS_HDCT_MO_CHOPD(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDCT_MO_CHOPD");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_HDCT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_pc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_pc, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_pc, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_pc, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_pc, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_pc, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_pc, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," +
                chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," +
                chuyen.OBJ_S(b_dr["ngay_bn_landau"]) + "," + chuyen.OBJ_S(b_dr["ngay_bn_gannhat"]) + "," + chuyen.OBJ_C(b_dr["phong_m"]) + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," +
                chuyen.OBJ_C(b_dr["cdanh_miennhiem"]) + "," + chuyen.OBJ_C(b_dr["cdanh_saumiennhiem"]) + "," + chuyen.OBJ_C(b_dr["ma_tl_c"]) + "," +
                chuyen.OBJ_C(b_dr["ma_nl_c"]) + "," + chuyen.OBJ_C(b_dr["ma_bl_c"]) + "," + chuyen.OBJ_S(b_dr["luongcb_c"]) + "," + chuyen.OBJ_S(b_dr["thunhapthang_c"]) + "," +
                chuyen.OBJ_S(b_dr["thuong_ketqua_c"]) + "," + chuyen.OBJ_S(b_dr["pt_huongluong_c"]) + "," + chuyen.OBJ_C(b_dr["dongia_c"]) + "," + chuyen.OBJ_S(b_dr["tyle_hoahong_c"]) + "," +
                chuyen.OBJ_C(b_dr["tyle_hoahong_theophi_c"]) + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," +
                chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["luongcb"]) + "," + chuyen.OBJ_S(b_dr["thunhapthang"]) + "," + chuyen.OBJ_S(b_dr["thuong_ketqua"]) + "," +
                chuyen.OBJ_S(b_dr["pt_huongluong"]) + "," + chuyen.OBJ_C(b_dr["dongia"]) + "," + chuyen.OBJ_S(b_dr["tyle_hoahong"]) + "," +
                chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]) + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]) + "," + chuyen.OBJ_C(b_dr["ten_cdanh_nguoiky"]) + "," + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," +
                chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            c = c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDCT_NH(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Phê duyệt nội dung thông tin</summary>
    public static void P_NS_HDCT_PD(ref string b_so_id, DataTable b_dt, DataTable b_dt_pc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_pc, "ma_pc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_pc, "ten");
            object[] a_sotien = bang.Fobj_COL_MANG(b_dt_pc, "sotien");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_pc, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_pc, "ngay_kt");
            object[] a_co_bh = bang.Fobj_COL_MANG(b_dt_pc, "co_bh");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien", 'N', a_sotien);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_co_bh", 'S', a_co_bh);

            string c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," +
                chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," +
                chuyen.OBJ_S(b_dr["ngay_bn_landau"]) + "," + chuyen.OBJ_S(b_dr["ngay_bn_gannhat"]) + "," + chuyen.OBJ_C(b_dr["phong_m"]) + "," + chuyen.OBJ_C(b_dr["cdanh_m"]) + "," +
                chuyen.OBJ_C(b_dr["cdanh_miennhiem"]) + "," + chuyen.OBJ_C(b_dr["cdanh_saumiennhiem"]) + "," + chuyen.OBJ_C(b_dr["ma_tl_c"]) + "," +
                chuyen.OBJ_C(b_dr["ma_nl_c"]) + "," + chuyen.OBJ_C(b_dr["ma_bl_c"]) + "," + chuyen.OBJ_S(b_dr["luongcb_c"]) + "," + chuyen.OBJ_S(b_dr["thunhapthang_c"]) + "," +
                chuyen.OBJ_S(b_dr["thuong_ketqua_c"]) + "," + chuyen.OBJ_S(b_dr["pt_huongluong_c"]) + "," + chuyen.OBJ_C(b_dr["dongia_c"]) + "," + chuyen.OBJ_S(b_dr["tyle_hoahong_c"]) + "," +
                chuyen.OBJ_C(b_dr["tyle_hoahong_theophi_c"]) + "," + chuyen.OBJ_C(b_dr["ma_tl"]) + "," + chuyen.OBJ_C(b_dr["ma_nl"]) + "," +
                chuyen.OBJ_C(b_dr["ma_bl"]) + "," + chuyen.OBJ_S(b_dr["luongcb"]) + "," + chuyen.OBJ_S(b_dr["thunhapthang"]) + "," + chuyen.OBJ_S(b_dr["thuong_ketqua"]) + "," +
                chuyen.OBJ_S(b_dr["pt_huongluong"]) + "," + chuyen.OBJ_C(b_dr["dongia"]) + "," + chuyen.OBJ_S(b_dr["tyle_hoahong"]) + "," +
                chuyen.OBJ_C(b_dr["tyle_hoahong_theophi"]) + "," + chuyen.OBJ_C(b_dr["ma_nguoiky"]) + "," + chuyen.OBJ_C(b_dr["ten_cdanh_nguoiky"]) + "," + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," +
                chuyen.OBJ_C(b_dr["tt"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
            c = c + ",:a_ma_pc,:a_ten,:a_sotien,:a_ngay_ad,:a_ngay_kt,:a_co_bh";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDCT_PD(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_HDCT_CAT_PC(ref string b_so_id, DataTable b_dt, DataTable b_dt_pc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_ma = bang.Fobj_COL_MANG(b_dt_pc, "ma_pc");
            object[] a_ngay_ad = bang.Fobj_COL_MANG(b_dt_pc, "ngay_ad");
            object[] a_ngay_kt = bang.Fobj_COL_MANG(b_dt_pc, "ngay_kt");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_pc", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ad", 'N', a_ngay_ad);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_kt", 'N', a_ngay_kt);

            string c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]);
            c = c + ",:a_ma_pc,:a_ngay_ad,:a_ngay_kt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_HDCT_CAT_PC(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable Fdt_NS_HDCT_IN(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_HDCT_IN");
    }
    public static void P_NS_HDCT_IMPORT(DataTable b_dt)
    {

        bang.P_CNG_SO(ref b_dt, "ngayd,ngayc,ngay_ky_qd");
        bang.P_CSO_SO(ref b_dt, "tienbh,tien_lcb,tien_tdgt,tien_tns,phantram_luong,trangthai_qd");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "SO_THE");
            object[] a_so_qd = bang.Fobj_COL_MANG(b_dt, "SO_QD");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "NGAYD");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_phongm = bang.Fobj_COL_MANG(b_dt, "PHONGM");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "CDANH");
            object[] a_noilamviec = bang.Fobj_COL_MANG(b_dt, "noilamviec");
            object[] a_cdanh_miennhiem = bang.Fobj_COL_MANG(b_dt, "cdanh_miennhiem");

            object[] a_donvi_dict = bang.Fobj_COL_MANG(b_dt, "donvi_dict");
            object[] a_diadiem_dict = bang.Fobj_COL_MANG(b_dt, "diadiem_dict");
            object[] a_tien = bang.Fobj_COL_MANG(b_dt, "lydo_dict");
            object[] a_tien_lcb = bang.Fobj_COL_MANG(b_dt, "tien_lcb");
            object[] a_tien_tdgt = bang.Fobj_COL_MANG(b_dt, "tien_tdgt");
            object[] a_tienbh = bang.Fobj_COL_MANG(b_dt, "tienbh");
            object[] a_tien_tns = bang.Fobj_COL_MANG(b_dt, "tien_tns");
            object[] a_phantram_luong = bang.Fobj_COL_MANG(b_dt, "phantram_luong");
            object[] a_nguoi_ky_qd = bang.Fobj_COL_MANG(b_dt, "nguoi_ky_qd");
            object[] a_ngay_ky_qd = bang.Fobj_COL_MANG(b_dt, "ngay_ky_qd");
            object[] a_trangthai_nv = bang.Fobj_COL_MANG(b_dt, "TRANGTHAI_NV");
            object[] a_hinhthuc = bang.Fobj_COL_MANG(b_dt, "HINHTHUC");
            object[] a_lydo_nkl = bang.Fobj_COL_MANG(b_dt, "lydo_nkl");
            object[] a_ngach = bang.Fobj_COL_MANG(b_dt, "ngach");
            object[] a_bac = bang.Fobj_COL_MANG(b_dt, "bac");
            object[] a_nganh_nghe = bang.Fobj_COL_MANG(b_dt, "nganh_nghe");
            object[] a_chuyen_mon = bang.Fobj_COL_MANG(b_dt, "chuyen_mon");
            object[] a_ma_tl = bang.Fobj_COL_MANG(b_dt, "ma_tl");
            object[] a_ma_bl = bang.Fobj_COL_MANG(b_dt, "ma_bl");
            object[] a_ma_nl = bang.Fobj_COL_MANG(b_dt, "ma_nl");
            object[] a_trangthai_qd = bang.Fobj_COL_MANG(b_dt, "trangthai_qd");


            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_qd", 'S', a_so_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_phongm", 'S', a_phongm);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_noilamviec", 'U', a_noilamviec);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_miennhiem", 'S', a_cdanh_miennhiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi_dict", 'U', a_donvi_dict);
            dbora.P_THEM_PAR(ref b_lenh, "a_diadiem_dict", 'U', a_diadiem_dict);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_dict", 'U', a_tien);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien_lcb", 'N', a_tien_lcb);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien_tdgt", 'N', a_tien_tdgt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tienbh", 'N', a_tienbh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tien_tns", 'N', a_tien_tns);
            dbora.P_THEM_PAR(ref b_lenh, "a_phantram_luong", 'N', a_phantram_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_ky_qd", 'S', a_nguoi_ky_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_ky_qd", 'N', a_ngay_ky_qd);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai_nv", 'S', a_trangthai_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_hinhthuc", 'S', a_hinhthuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo_nkl", 'S', a_lydo_nkl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngach", 'S', a_ngach);
            dbora.P_THEM_PAR(ref b_lenh, "a_bac", 'S', a_bac);
            dbora.P_THEM_PAR(ref b_lenh, "a_nganh_nghe", 'S', a_nganh_nghe);
            dbora.P_THEM_PAR(ref b_lenh, "a_chuyen_mon", 'S', a_chuyen_mon);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_tl", 'S', a_ma_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_bl", 'S', a_ma_bl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nl", 'S', a_ma_nl);
            dbora.P_THEM_PAR(ref b_lenh, "a_trangthai_qd", 'N', a_trangthai_qd);



            string b_c = ",:a_so_the,:a_so_qd,:a_ngayd,:a_ngayc,:a_phongm,:a_cdanh,:a_noilamviec,:a_cdanh_miennhiem,:a_donvi_dict,:a_diadiem_dict,:a_lydo_dict,:a_tien_lcb,:a_tien_tdgt,:a_tienbh,:a_tien_tns,:a_phantram_luong,:a_nguoi_ky_qd,:a_ngay_ky_qd,:a_trangthai_nv,:a_hinhthuc,:a_lydo_nkl,:a_ngach,:a_bac,:a_nganh_nghe,:a_chuyen_mon,:a_ma_tl,:a_ma_bl,:a_ma_nl,:a_trangthai_qd";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_hdct_import(" + b_se.tso + b_c + "); end;";
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
        catch (Exception ex)
        {
            string e = ex.Message;
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_HDCT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_HDCT_XOA");
    }
    public static DataTable Fdt_NS_HDCT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_HDCT_LKE_ALL");
    }
    public static DataSet Faobj_NS_HDCT_LKE_ALL(string b_so_the, string b_ten, string b_phong, string b_trangthai)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_ten, b_phong, b_trangthai }, 2, "PNS_HDCT_LKE_ALL");
    }
    #endregion QUÁ TRÌNH LÀM VIỆC

    #region THÔI VIỆC
    public static DataTable Fdt_NS_TV_LKE_TAISAN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TV_LKE_TAISAN");
    }

    public static DataTable Fdt_NS_TV_LKE_THUTUC()
    {
        return dbora.Fdt_LKE("PNS_TV_LKE_THUTUC");
    }
    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    ///
    public static object[] Fdt_NS_TV_LKE(string b_tinhtrang_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tinhtrang_tk, b_tu, b_den }, "NR", "PNS_TV_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_TV_MA(string b_so_the, string b_tinhtrang_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tinhtrang_tk, b_trangkt }, "NNR", "PNS_TV_MA");
    }

    public static DataTable Fdt_NS_TV_HOI_CB(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TV_HOI_CB");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataSet Fdt_NS_TV_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 4, "PNS_TV_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_TV_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_tt, DataTable b_dt_ts, DataTable b_dt_cn)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            // thủ tục
            object[] a_chon = bang.Fobj_COL_MANG(b_dt_tt, "chon");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_tt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_tt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "a_chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            // tài sản
            object[] b_chon = bang.Fobj_COL_MANG(b_dt_ts, "chon");
            object[] b_ngaytra = bang.Fobj_COL_MANG(b_dt_ts, "ngaytra");
            object[] b_ma = bang.Fobj_COL_MANG(b_dt_ts, "ma");
            object[] b_ten = bang.Fobj_COL_MANG(b_dt_ts, "ten");
            object[] b_sluong = bang.Fobj_COL_MANG(b_dt_ts, "sluong");
            object[] b_ngaycap = bang.Fobj_COL_MANG(b_dt_ts, "ngaycap");

            dbora.P_THEM_PAR(ref b_lenh, "b_chon", 'S', b_chon);
            dbora.P_THEM_PAR(ref b_lenh, "b_ngaytra", 'N', b_ngaytra);
            dbora.P_THEM_PAR(ref b_lenh, "b_ma", 'S', b_ma);
            dbora.P_THEM_PAR(ref b_lenh, "b_ten", 'U', b_ten);
            dbora.P_THEM_PAR(ref b_lenh, "b_sluong", 'N', b_sluong);
            dbora.P_THEM_PAR(ref b_lenh, "b_ngaycap", 'N', b_ngaycap);

            // công nợ
            object[] c_chon = bang.Fobj_COL_MANG(b_dt_cn, "chon");
            object[] c_ngay = bang.Fobj_COL_MANG(b_dt_cn, "ngay");
            object[] c_ten = bang.Fobj_COL_MANG(b_dt_cn, "ten");
            object[] c_tien = bang.Fobj_COL_MANG(b_dt_cn, "tien");
            object[] c_gchu = bang.Fobj_COL_MANG(b_dt_cn, "gchu");

            dbora.P_THEM_PAR(ref b_lenh, "c_chon", 'S', c_chon);
            dbora.P_THEM_PAR(ref b_lenh, "c_ngay", 'N', c_ngay);
            dbora.P_THEM_PAR(ref b_lenh, "c_ten", 'U', c_ten);
            dbora.P_THEM_PAR(ref b_lenh, "c_tien", 'N', c_tien);
            dbora.P_THEM_PAR(ref b_lenh, "c_gchu", 'U', c_gchu);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["phong"])
                + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngaynop"]) + "," + chuyen.OBJ_S(b_dr["ngaynghi"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang"])
                + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," + chuyen.OBJ_C(b_dr["ht"])
                + "," + chuyen.OBJ_S(b_dr["ngaytt"]) + "," + chuyen.OBJ_C(b_dr["nguoiduyet"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["is_dsd"]);
            b_c = b_c + ",:a_chon,:a_ma,:a_ten,:b_chon,:b_ngaytra,:b_ma,:b_ten,:b_sluong,:b_ngaycap,:c_chon,:c_ngay,:c_ten,:c_tien,:c_gchu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TV_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_TV_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_TV_XOA");
    }
    #endregion THÔI VIỆC

    #region THIẾT LẬP THỜI HẠN NÂNG LƯƠNG

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_QT_TLAP_LENLUONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_QT_TLAP_LENLUONG_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_QT_TLAP_LENLUONG_MA(string b_ngay, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay), b_trangkt }, "NNR", "PNS_QT_TLAP_LENLUONG_MA");
    }
    //chi tiet
    public static DataTable Fdt_NS_QT_TLAP_LENLUONG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_QT_TLAP_LENLUONG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_QT_TLAP_LENLUONG_NH(string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string c = ",:so_id" + "," + chuyen.OBJ_S(b_dr["ngay"]) + "," + chuyen.OBJ_C(b_dr["thoihan"]) + "," + chuyen.OBJ_C(b_dr["loai"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_TLAP_LENLUONG_NH(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void P_NS_QT_TLAP_LENLUONG_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_QT_TLAP_LENLUONG_XOA");
    }
    #endregion THIẾT LẬP THỜI HẠN NÂNG LƯƠNG

    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY
    public static object[] Fdt_NS_CC_DKLV_NGOAI_CTY_LKE(string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_tu, b_den }, "NR", "PNS_CC_DKLV_NGOAI_CTY_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_DKLV_NGOAI_CTY_MA(string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_so_id, b_trangkt }, "NNR", "PNS_CC_DKLV_NGOAI_CTY_MA");
    }

    public static DataTable Fdt_NS_CC_DKLV_NGOAI_CTY_CT(string b_so_the, string b_ngaydk)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngaydk) }, "PNS_CC_DKLV_NGOAI_CTY_CT");
    }
    public static void PNS_CC_DKLV_NGOAI_CTY_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dk"])
               + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_C(b_dr["lydo"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKLV_NGOAI_CTY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static DataTable PNS_CC_DKLV_NGOAI_CTY_EXPORT(string b_sothe_tk, string b_hoten_tk, string b_nam_tk, string b_kyluong_tk, string b_phong_tk)
    {
        return dbora.Fdt_LKE_S(new object[] { b_sothe_tk, b_hoten_tk, b_nam_tk, b_kyluong_tk, b_phong_tk }, "PNS_CC_DKLV_NGOAI_CTY_EXPORT");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_CC_DKLV_NGOAI_CTY_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_CC_DKLV_NGOAI_CTY_XOA");
    }
    #endregion ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY CÁ NHÂN
    public static object[] Fdt_NS_CC_DKLV_NGOAI_CTY_CN_LKE(string b_nam_tk, string b_kyluong, string b_tt_tk, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam_tk, b_kyluong, b_tt_tk, b_so_the, b_tu, b_den }, "NR", "PNS_CC_DKLV_NGOAI_CTY_CN_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_DKLV_NGOAI_CTY_CN_MA(string b_nam_tk, string b_kyluong, string b_tt_tk, string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam_tk, b_kyluong, b_tt_tk, b_so_the, b_so_id, b_trangkt }, "NNR", "PNS_CC_DKLV_NGOAI_CTY_CN_MA");
    }

    public static DataTable Fdt_NS_CC_DKLV_NGOAI_CTY_CN_CT(string b_so_the, string b_ngaydk)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngaydk) }, "PNS_CC_DKLV_NGOAI_CTY_CN_CT");
    }
    public static void PNS_CC_DKLV_NGOAI_CTY_CN_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ngay_dk"])
               + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_C(b_dr["lydo"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKLV_NGOAI_CTY_CN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_CC_DKLV_NGOAI_CTY_CN_XOA(string b_so_id, string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id), b_so_the }, "PNS_CC_DKLV_NGOAI_CTY_CN_XOA");
    }
    public static void PNS_CC_DKLV_NGOAI_CTY_CN_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_DKLV_NGOAI_CTY_CN_GUI");
    }
    #endregion ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY CÁ NHÂN

    #region ĐĂNG KÝ CA CON NHỎ DƯỚI 1 TUỔI
    public static object[] Fdt_NS_CC_DKC_CONNHO_LKE(string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, chuyen.CNG_SO(b_ngayd_tk), chuyen.CNG_SO(b_ngayc_tk), b_tu, b_den }, "NR", "PNS_CC_DKC_CONNHO_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_DKC_CONNHO_MA(string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_phong_tk, b_so_id, b_trangkt }, "NNR", "PNS_CC_DKC_CONNHO_MA");
    }

    public static DataTable Fdt_NS_CC_DKC_CONNHO_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_CC_DKC_CONNHO_CT");
    }

    public static void P_NS_CC_DKC_CONNHO_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ca"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"])
            + "," + chuyen.OBJ_C(b_dr["mota"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKC_CONNHO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }

    }
    public static void PNS_CC_DKC_CONNHO_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_CC_DKC_CONNHO_XOA");
    }

    public static DataTable Fdt_NS_CC_DKC_CONNHO_DS_PHANCA(string b_so_the, string b_ma_ca, string b_ngayd, string b_ngayc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_ma_ca, chuyen.CSO_SO(b_ngayd), chuyen.CSO_SO(b_ngayc) }, "PNS_CC_DKC_CONNHO_DS_PHANCA");
    }

    public static void PNS_CC_DKC_CONNHO_PHANCA(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt, "ho_ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_kyluong_id = bang.Fobj_COL_MANG(b_dt, "kyluong_id");
            object[] a_ngay_d = bang.Fobj_COL_MANG(b_dt, "ngay_d");
            object[] a_ma_ca = bang.Fobj_COL_MANG(b_dt, "ma_ca");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_kyluong_id", 'N', a_kyluong_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_d", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_ca", 'S', a_ma_ca);

            string b_c = ",:a_so_the,:a_ho_ten,:a_phong,:a_cdanh,:a_kyluong_id,:a_ngay_d,:a_ma_ca";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_DKC_CONNHO_PHANCA(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }

    }
    #endregion

    #region CÁ NHÂN ĐĂNG KÝ CA CON NHỎ DƯỚI 1 TUỔI

    public static void P_CC_CN_DKC_CONNHO_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_CN_DKC_CONNHO_GUI");
    }
    public static object[] Fdt_NS_CC_CN_DKC_CONNHO_LKE(string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, chuyen.CNG_SO(b_ngayd_tk), chuyen.CNG_SO(b_ngayc_tk), b_tu, b_den }, "NR", "PNS_CC_CN_DKC_CONNHO_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_CN_DKC_CONNHO_MA(string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_phong_tk, b_so_id, b_trangkt }, "NNR", "PNS_CC_CN_DKC_CONNHO_MA");
    }

    public static DataTable Fdt_NS_CC_CN_DKC_CONNHO_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_CC_CN_DKC_CONNHO_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_CC_CN_DKC_CONNHO_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["ca"]) + "," + chuyen.OBJ_C(b_dr["giod"]) + "," + chuyen.OBJ_C(b_dr["gioc"])
            + "," + chuyen.OBJ_C(b_dr["mota"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_CN_DKC_CONNHO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }

    }
    public static void PNS_CC_CN_DKC_CONNHO_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_CC_CN_DKC_CONNHO_XOA");
    }
    #endregion

    #region ĐĂNG KÝ NGHỈ
    /// <summary>Liệt kê chi tiet</summary>
    /// 
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_QT_XIN_NGHIPHEP_LKE(string b_tungay, string b_denngay, string b_so_the, string b_ten, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_so_the, "N'" + b_ten, b_trangthai, b_tu, b_den }, "NR", "PNS_QT_XIN_NGHIPHEP_LKE");
    }
    public static object[] Fdt_NS_QT_XIN_NGHIPHEP_MA(string b_so_id, string b_so_the, string b_tungay, string b_denngay, string b_trangthai_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_trangthai_tk, b_trangkt }, "NNR", "PNS_QT_XIN_NGHIPHEP_MA");
    }
    public static DataTable Fdt_NS_QT_XIN_NGHIPHEP_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_QT_XIN_NGHIPHEP_CT");
    }
    public static void P_NS_QT_XIN_NGHIPHEP_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_NS_QT_XIN_NGHIPHEP_GUI");
    }
    public static void P_NS_QT_XIN_NGHIPHEP_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_thaythe"]) + "," + chuyen.OBJ_C(b_dr["macc_nghi"]) + "," + chuyen.OBJ_S(b_dr["ngayd"])
               + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_S(b_dr["ngaynghi"]) + "," + chuyen.OBJ_C(b_dr["truphepnam"])
               + "," + chuyen.OBJ_S(b_dr["truphep"]) + "," + chuyen.OBJ_C(b_dr["namtru"]) + "," + chuyen.OBJ_C(b_dr["nghibu"]) + "," + chuyen.OBJ_S(b_dr["ngaybu"]) + "," + chuyen.OBJ_C(b_dr["noidung"])
               + "," + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_S(b_dr["danghi"]) + "," + chuyen.OBJ_S(b_dr["phepcon"]) + "," + chuyen.OBJ_S(b_dr["huydon"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_XIN_NGHIPHEP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_QT_XIN_NGHIPHEP_FILE_NH(DataTable b_dt)
    {

        object[] a_obj;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            a_obj = new object[] { b_dr["so_the"], b_dr["sothe_thaythe"], b_dr["macc_nghi"], b_dr["ngayd"], b_dr["gio_bd"] , b_dr["ngayc"], b_dr["gio_kt"],
                b_dr["ngaynghi"], b_dr["truphepnam"], b_dr["truphep"] , b_dr["namtru"], b_dr["nghibu"], b_dr["ngaybu"], b_dr["noidung"], b_dr["ghichu"] , b_dr["ngayphep"], b_dr["danghi"] };
            dbora.P_GOIHAM(a_obj, "PNS_QT_XIN_NGHIPHEP_NH");
        }
    }
    public static void PNS_QT_XIN_NGHIPHEP_XOA(string b_so_the, string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.CSO_SO(b_so_id) }, "PNS_QT_XIN_NGHIPHEP_XOA");
    }
    public static void PNS_QT_XIN_NGHIPHEP_UP(string b_so_the, string b_ngayd, string b_huydon)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd), b_huydon }, "pNS_QT_XIN_NGHIPHEP_up");
    }
    #endregion ĐĂNG KÝ NGHỈ

    #region KHAI BAO NGHI VIEC
    public static DataSet Fdt_NS_QT_XIN_NGHIVIEC_MA(string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_so_the }, 2, "pns_qt_xin_nghiviec_ma");
    }
    public static string Fs_NS_QT_NGHIVIEC_NH(DataTable b_dt, DataTable b_tailieu)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_tailieu = bang.Fobj_COL_MANG(b_tailieu, "ten_tailieu");
            object[] a_ng_nhan = bang.Fobj_COL_MANG(b_tailieu, "ng_nhan");
            object[] a_ngay_bg = bang.Fobj_COL_MANG(b_tailieu, "ngay_bg");
            object[] a_file_duongdan = bang.Fobj_COL_MANG(b_tailieu, "file_duongdan");

            dbora.P_THEM_PAR(ref b_lenh, "a_ten_tl", 'U', a_tailieu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan", 'U', a_ng_nhan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg", 'N', a_ngay_bg);
            dbora.P_THEM_PAR(ref b_lenh, "a_file_duongdan", 'S', a_file_duongdan);
            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_S(b_dr["ngay_nop"]) + "," + chuyen.OBJ_S(b_dr["ngay_xin"]) + "," + chuyen.OBJ_S(b_dr["ngay_tt"]) + "," + chuyen.OBJ_C(b_dr["lydo1"]) + "," +
                    chuyen.OBJ_C(b_dr["lydo2"]) + "," + chuyen.OBJ_C(b_dr["lydo3"]) + "," + chuyen.OBJ_C(b_dr["lydo4"]) + "," + chuyen.OBJ_C(b_dr["lydo5"]) + "," +
                    chuyen.OBJ_C(b_dr["lydo_khac"]) + "," + chuyen.OBJ_C(b_dr["lydo_chitiet"]) + "," + chuyen.OBJ_C(b_dr["ml_khl"]) + "," + chuyen.OBJ_C(b_dr["ml_hl"]) + "," +
                    chuyen.OBJ_C(b_dr["ml_rhl"]) + "," + chuyen.OBJ_C(b_dr["ql_khl"]) + "," + chuyen.OBJ_C(b_dr["ql_hl"]) + "," + chuyen.OBJ_C(b_dr["ql_rhl"]) + "," + chuyen.OBJ_C(b_dr["mt_khl"]) + "," +
                    chuyen.OBJ_C(b_dr["mt_hl"]) + "," + chuyen.OBJ_C(b_dr["mt_rhl"]) + "," + chuyen.OBJ_C(b_dr["ch_khl"]) + "," + chuyen.OBJ_C(b_dr["ch_hl"]) + "," + chuyen.OBJ_C(b_dr["ch_rhl"]) + "," + chuyen.OBJ_C(b_dr["gopy"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang"]);
            b_c = b_c + ",:a_ten_tl,:a_ng_nhan,:a_ngay_bg,:a_file_duongdan";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_XIN_NGHIVIEC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_QT_XIN_NGHIVIEC_GUI(string b_so_the)
    {
        dbora.P_GOIHAM(new object[] { b_so_the }, "PNS_QT_XIN_NGHIVIEC_GUI");
    }
    #endregion

    #region PHÊ DUYỆT DANH SÁCH NGHỈ PHÉP
    public static object[] Fdt_NS_QT_NGHIPHEP_PD_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        //soThe, maDonVi
        se.se_nsd b_se = new se.se_nsd();
        var ts = b_se.login;
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, "", 30300101, 30300101, b_tu, b_den }, "NR", "PNS_QT_NGHIPHEP_PD_LKE");
    }

    public static DataTable Fdt_NS_QT_NGHIPHEP_PD_PHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_id,:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIPHEP_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIPHEP_PD_KOPHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIPHEP_PD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIPHEP_PD_CT(string b_so_the, string b_ngayxn, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_CSO(b_ngayxn), chuyen.CNG_CSO(b_ngayd) }, "pns_qt_nghiphep_pd_ct");
    }

    #endregion PHÊ DUYỆT DANH SÁCH NGHỈ PHÉP

    #region THÔNG TIN NGHỈ PHÉP
    /// <summary>Liệt kê chi tiet</summary>
    /// 
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_CC_THONGTIN_NGHI_LKE(string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_trangthai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_trangthai, b_tu, b_den }, "NR", "PNS_CC_THONGTIN_NGHI_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CC_THONGTIN_NGHI_MA(string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_trangthai, b_so_id, b_trangkt }, "NNR", "PNS_CC_THONGTIN_NGHI_MA");
    }

    public static DataTable Fdt_NS_CC_THONGTIN_NGHI_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PNS_CC_THONGTIN_NGHI_CT");
    }
    public static DataTable Fdt_NS_CC_THONGTIN_NGHI_SC(string b_kieunghi)
    {
        return dbora.Fdt_LKE_S(b_kieunghi, "PNS_CC_THONGTIN_NGHI_SC");
    }
    // Lấy trạng thái kỳ công
    public static string P_CC_KTRA_KIEUCONG(double b_ngay, string b_so_the, string b_ma_cc)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "TON_TAI", 'N', 'O', 0);
            string b_c = "," + chuyen.OBJ_S(b_ngay) + "," + chuyen.OBJ_C(b_so_the) + "," + chuyen.OBJ_C(b_ma_cc) + ",:TON_TAI";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_KTRA_KIEUCONG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["TON_TAI"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.ToString());
        }
    }

    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_CC_THONGTIN_NGHI_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_thaythe"]) + "," + chuyen.OBJ_C(b_dr["macc_nghi"]) + "," + chuyen.OBJ_S(b_dr["ngayd"])
               + "," + chuyen.OBJ_C(b_dr["gio_bd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["gio_kt"]) + "," + chuyen.OBJ_S(b_dr["ngaynghi"]) + "," + chuyen.OBJ_C(b_dr["truphepnam"])
               + "," + chuyen.OBJ_S(b_dr["truphep"]) + "," + chuyen.OBJ_C(b_dr["namtru"]) + "," + chuyen.OBJ_C(b_dr["nghibu"]) + "," + chuyen.OBJ_S(b_dr["ngaybu"]) + "," + chuyen.OBJ_C(b_dr["noidung"])
               + "," + chuyen.OBJ_C(b_dr["ghichu"]) + "," + chuyen.OBJ_S(b_dr["danghi"]) + "," + chuyen.OBJ_S(b_dr["phepcon"]) + "," + chuyen.OBJ_S(b_dr["huydon"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_THONGTIN_NGHI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }

    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static string P_NS_CC_THONGTIN_NGHI_FILE_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc,ngaynghi,ngaybu");
            bang.P_CSO_SO(ref b_dt, "ngaynghi,truphep,ngaybu,ngayphep,danghi");

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_sothe_thaythe = bang.Fobj_COL_MANG(b_dt, "sothe_thaythe");
            object[] a_macc_nghi = bang.Fobj_COL_MANG(b_dt, "macc_nghi");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt, "ngayd");
            object[] a_gio_bd = bang.Fobj_COL_MANG(b_dt, "gio_bd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt, "ngayc");
            object[] a_gio_kt = bang.Fobj_COL_MANG(b_dt, "gio_kt");
            object[] a_ngaynghi = bang.Fobj_COL_MANG(b_dt, "ngaynghi");
            object[] a_truphepnam = bang.Fobj_COL_MANG(b_dt, "truphepnam");
            object[] a_truphep = bang.Fobj_COL_MANG(b_dt, "truphep");
            object[] a_namtru = bang.Fobj_COL_MANG(b_dt, "namtru");
            object[] a_nghibu = bang.Fobj_COL_MANG(b_dt, "nghibu");
            object[] a_ngaybu = bang.Fobj_COL_MANG(b_dt, "ngaybu");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt, "noidung");
            object[] a_gchu = bang.Fobj_COL_MANG(b_dt, "ghichu");
            object[] a_danghi = bang.Fobj_COL_MANG(b_dt, "danghi");
            object[] a_ngayphep = bang.Fobj_COL_MANG(b_dt, "ngayphep");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_thaythe", 'S', a_sothe_thaythe);
            dbora.P_THEM_PAR(ref b_lenh, "a_macc_nghi", 'S', a_macc_nghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_gio_bd", 'S', a_gio_bd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_gio_kt", 'S', a_gio_kt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaynghi", 'N', a_ngaynghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_truphepnam", 'S', a_truphepnam);
            dbora.P_THEM_PAR(ref b_lenh, "a_truphep", 'N', a_truphep);
            dbora.P_THEM_PAR(ref b_lenh, "a_namtru", 'S', a_namtru);
            dbora.P_THEM_PAR(ref b_lenh, "a_nghibu", 'S', a_nghibu);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaybu", 'N', a_ngaybu);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_gchu", 'U', a_gchu);
            dbora.P_THEM_PAR(ref b_lenh, "a_danghi", 'N', a_danghi);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayphep", 'N', a_ngayphep);

            string b_c = ",:a_so_the,:a_sothe_thaythe,:a_macc_nghi,:a_ngayd,:a_gio_bd,:a_ngayc,:a_gio_kt,:a_ngaynghi,:a_truphepnam,:a_truphep,:a_namtru,:a_nghibu,:a_ngaybu";
            b_c = b_c + ",:a_noidung,:a_gchu,:a_danghi,:a_ngayphep";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CC_THONGTIN_NGHI_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_CC_THONGTIN_NGHI, TEN_BANG.NS_CC_THONGTIN_NGHI);
            }
            catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
            finally { b_lenh.Parameters.Clear(); }
            return "";
        }
        finally { b_cnn.Close(); }

    }

    public static string P_NS_TL_KHOAN_PHAITHU_FILE_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            //bang.P_CNG_SO(ref b_dt, "ngayd,ngayc,ngaynghi,ngaybu");
            bang.P_CSO_SO(ref b_dt, "nam,kyluong_id,sotien_thu,sotien_tra");


            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            // object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt, "ho_ten");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_nam = bang.Fobj_COL_MANG(b_dt, "nam");
            object[] a_kyluong_id = bang.Fobj_COL_MANG(b_dt, "kyluong_id");
            object[] a_sotien_thu = bang.Fobj_COL_MANG(b_dt, "sotien_thu");
            object[] a_sotien_tra = bang.Fobj_COL_MANG(b_dt, "sotien_tra");
            object[] a_noidung_thu = bang.Fobj_COL_MANG(b_dt, "noidung_thu");
            object[] a_noidung_tra = bang.Fobj_COL_MANG(b_dt, "noidung_tra");
            //object[] a_ngaytao = bang.Fobj_COL_MANG(b_dt, "ngaytao");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            // dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nam", 'N', a_nam);
            dbora.P_THEM_PAR(ref b_lenh, "a_kyluong_id", 'N', a_kyluong_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien_thu", 'N', a_sotien_thu);
            dbora.P_THEM_PAR(ref b_lenh, "a_sotien_tra", 'N', a_sotien_tra);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung_thu", 'U', a_noidung_thu);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung_tra", 'U', a_noidung_tra);
            //  dbora.P_THEM_PAR(ref b_lenh, "a_ngaytao", 'S', a_ngaytao);


            string b_c = ",:a_so_the,:a_cdanh,:a_phong,:a_nam,:a_kyluong_id,:a_sotien_thu,:a_sotien_tra,:a_noidung_thu,:a_noidung_tra";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TL_KHOAN_PHAITHU_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_TL_KHOAN_PHAITHU, TEN_BANG.NS_TL_KHOAN_PHAITHU);
            }
            catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
            finally { b_lenh.Parameters.Clear(); }
            return "";
        }
        finally { b_cnn.Close(); }

    }

    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_NS_CC_THONGTIN_NGHI_EXPORT()
    {
        return dbora.Fdt_LKE("pns_cc_thongtin_nghi_export");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_CC_THONGTIN_NGHI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_CC_THONGTIN_NGHI_XOA");
    }
    public static DataTable PNS_CC_THONGTIN_NGHI_MANGHI(string b_ma_nghi, string b_ngayd, string b_ngayc)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_nghi, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc) }, "PNS_CC_THONGTIN_NGHI_MA_NGHI");
    }
    public static DataTable Fdt_NS_QT_XIN_NGHIPHEP_CB(string b_so_the, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_nam }, "pns_tl_nghiphep_tinh_cb");
    }
    public static void PNS_CC_THONGTIN_NGHI_UP(string b_so_id, string b_huydon)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_huydon }, "pns_cc_thongtin_nghi_up");
    }
    public static DataTable PNS_CC_THONGTIN_NGHI_KTRA(string b_so_the, double b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_ngayd }, "pns_cc_thongtin_nghi_ktra");
    }
    #endregion THÔNG TIN NGHỈ PHÉP

    #region PHÊ DUYỆT DANH SÁCH NÂNG LƯƠNG
    public static object[] Fs_NS_QT_DEBATPD_LKE(double tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { tinhtrang, b_tu, b_den }, "NR", "PNS_QT_DEBATPD_LKE");
    }

    public static void Fs_NS_QT_DEBATPD_PHEDUYET(double b_tinhtrang)
    {
        dbora.P_GOIHAM(new object[] { b_tinhtrang }, "PNS_QT_DEBATPD_PHEDUYET");
    }
    #endregion

    #region DANH SÁCH NÂNG LƯƠNG
    public static object[] Fs_NS_QT_DEBAT_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_QT_DEBAT_LKE");
    }
    public static object[] Fdt_NS_QT_DEBAT_MA(string b_ngayd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngayd), b_trangkt }, "NNR", "PNS_NS_QT_DEBAT_MA");
    }
    public static void Fs_NS_QT_DEBAT_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            DataRow dr = b_dt.Rows[0];
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_cvu = bang.Fobj_COL_MANG(b_dt, "cvu");
            object[] a_hspc = bang.Fobj_COL_MANG(b_dt, "hspc");

            object[] a_ncd = bang.Fobj_COL_MANG(b_dt, "ncd");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_bac = bang.Fobj_COL_MANG(b_dt, "bac");
            object[] a_hso = bang.Fobj_COL_MANG(b_dt, "hso");
            object[] a_luong = bang.Fobj_COL_MANG(b_dt, "luong");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "b_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "b_cvu", 'U', a_cvu);
            dbora.P_THEM_PAR(ref b_lenh, "b_ncd", 'U', a_ncd);
            dbora.P_THEM_PAR(ref b_lenh, "b_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "b_bac", 'U', a_bac);
            dbora.P_THEM_PAR(ref b_lenh, "b_hspc", 'N', a_hspc);
            dbora.P_THEM_PAR(ref b_lenh, "b_hso", 'N', a_hso);
            dbora.P_THEM_PAR(ref b_lenh, "b_luong", 'N', a_luong);
            dbora.P_THEM_PAR(ref b_lenh, "b_ghichu", 'U', a_ghichu);
            string b_c = "," + chuyen.OBJ_C(dr["NGAY_LAP"]);
            b_c = b_c + ",:b_so_the,:b_cvu,:b_ncd,:b_cdanh,:b_bac,:b_hspc,:b_hso,:b_luong,:b_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_DEBAT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary> Xóa </summary>
    public static void Fs_NS_QT_DEBAT_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_QT_DEBAT_XOA");
    }
    public static DataTable Fs_NS_QT_DEBAT_CT(string b_ngay_lap)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_ngay_lap) }, "PNS_QT_DEBAT_CT");
    }
    #endregion KHAI BÁO ĐÓNG MỚI

    #region PHÊ DUYỆT ĐIỀU CHUYỂN
    public static object[] Fdt_NS_CPPD_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_CPPD_LKE");
    }

    public static void Fdt_NS_CPPD_PHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_luong = bang.Fobj_COL_MANG(b_dt_ct, "luong");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong", 'N', a_luong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_luong,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CPPD_PHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void Fdt_NS_CPPD_HUYPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CPPD_HUYPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void Fdt_NS_CPPD_KOPHEDUYET(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = ",:a_so_id,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CPPD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion PHÊ DUYỆT ĐIỀU CHUYỂN

    #region DANH SÁCH ĐEN
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_NS_DS_DEN_LKE(double b_tu_n, double b_den_n, string b_so_the, string b_ten, string b_phong)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_so_the, b_ten, b_phong }, "NR", "PNS_NS_DS_DEN_LKE");
    }
    public static DataSet Fds_Fs_NS_DS_DEN_EXCEL(string b_so_the, string b_ten, string b_phong)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_ten, b_phong }, 1, "PNS_NS_DS_DEN_EXCEL");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_NS_DS_DEN_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_NS_DS_DEN_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_NS_DS_DEN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PFs_NS_DS_DEN_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_NS_DS_DEN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_NS_DS_DEN_XOA");
    }
    #endregion DANH SÁCH ĐEN

    #region CHỨC DANH KIÊM NHIỆM
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_CDANH_KN_LKE(string b_phong, string b_so_the, string b_hoten, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, "N'" + b_hoten, b_tu_n, b_den_n }, "NR", "PNS_NS_CDANH_KN_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_CDANH_KN_MA(string b_so_the, string b_phong_tk, string b_so_the_tk, string b_hoten_tk, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_phong_tk, b_so_the_tk, "N'" + b_hoten_tk, b_trangkt }, "NNR", "PNS_NS_CDANH_KN_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_NS_CDANH_KN_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_CDANH_KN_CT");
    }
    // Nhap so lieu
    public static void P_NS_CDANH_KN_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            string b_so_the = chuyen.OBJ_C(b_dr["so_the"]);
            string b_ho_ten = chuyen.OBJ_C(b_dr["ho_ten"]);

            object[] a_cty = bang.Fobj_COL_MANG(b_dt_ct, "cty");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_bophan = bang.Fobj_COL_MANG(b_dt_ct, "bophan");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_ngay_hl = bang.Fobj_COL_MANG(b_dt_ct, "ngay_hl");
            object[] a_ngay_het_hl = bang.Fobj_COL_MANG(b_dt_ct, "ngay_het_hl");
            object[] a_phucap_kn = bang.Fobj_COL_MANG(b_dt_ct, "phucap_kn");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");
            object[] a_so_the_den = bang.Fobj_COL_MANG(b_dt_ct, "so_the_den");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            dbora.P_THEM_PAR(ref b_lenh, "a_cty", 'S', a_cty);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_bophan", 'S', a_bophan);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_het_hl", 'N', a_ngay_het_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_phucap_kn", 'N', a_phucap_kn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the_den", 'U', a_so_the_den);

            string b_c = ",:so_id," + b_so_the + "," + b_ho_ten + ",:a_cty,:a_phong,:a_bophan,:a_cdanh,:a_ngay_hl,:a_ngay_het_hl,:a_phucap_kn,:a_ghichu,:a_so_the_den";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_CDANH_KN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_CDANH_KN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_NS_CDANH_KN_XOA");
    }

    public static DataTable Fdt_NS_CDANH_KN_CTY_DROP()
    {
        return dbora.Fdt_LKE("PNS_CDANH_KN_CTY_DROP");
    }
    public static DataTable Fdt_NS_CDANH_KN_PHONG_DROP(string b_cty)
    {
        return dbora.Fdt_LKE_S(b_cty, "PNS_CDANH_KN_PHONG_DROP");
    }

    public static DataTable Fdt_NS_CDANH_KN()
    {
        return dbora.Fdt_LKE("PNS_CDANH_KN_XUATEXCEL");
    }
    #endregion CHỨC DANH KIÊM NHIỆM

    #region PHÊ DUYỆT DANH SÁCH NGHỈ VIỆC
    public static object[] Fdt_NS_QT_NGHIVIEC_PD_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_QT_NGHIVIEC_PD_LKE");
    }
    public static DataTable P_NS_QT_NGHIVIEC_PD_NH(string b_tinhtrang, DataTable b_dt)
    {
        DataTable b_kq = null;
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            b_kq = dbora.Fdt_LKE_S(new object[] {  chuyen.OBJ_S(b_tinhtrang),b_dr["so_the"], chuyen.OBJ_S(b_dr["ngay_pd"]),chuyen.OBJ_S(b_dr["ql_lydo1"]), chuyen.OBJ_S(b_dr["ql_lydo2"]), chuyen.OBJ_S(b_dr["ql_lydo3"]), chuyen.OBJ_S(b_dr["ql_lydo4"]), chuyen.OBJ_S(b_dr["ql_lydo5"]),
                chuyen.OBJ_S(b_dr["ql_lydo_khac"]), chuyen.OBJ_S(b_dr["ql_lydo_chitiet"]),chuyen.OBJ_S(b_dr["ktd"]),chuyen.OBJ_S(b_dr["lydo_ktd"]),chuyen.OBJ_S(b_dr["giu_lai"]),chuyen.OBJ_S(b_dr["dcl"]),chuyen.OBJ_S(b_dr["mdc"]),chuyen.OBJ_S(b_dr["dexuat"])}, "PNS_QT_NGHIVIEC_PD_NH");
        }
        return b_kq;
    }
    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_PHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_id,:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIVIEC_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_KOPHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIVIEC_PD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "pNS_QT_NGHIVIEC_pd_ct");
    }

    #endregion PHÊ DUYỆT DANH SÁCH NGHỈ PHÉP

    #region QUẢN LÝ NGHỈ VIỆC

    public static void P_NS_THOIVIEC_NH(DataTable b_dt, DataTable b_dt_1, DataTable b_dt_2, DataTable b_dt_3, DataTable b_dt_4, DataTable b_dt_5, DataTable b_dt_6, DataTable b_dt_7)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_danh_muc_1 = bang.Fobj_COL_MANG(b_dt_1, "danh_muc");
            object[] a_ngay_bg_1 = bang.Fobj_COL_MANG(b_dt_1, "ngay_bg");
            object[] a_ng_nhan_1 = bang.Fobj_COL_MANG(b_dt_1, "ng_nhan");
            object[] a_ghichu_1 = bang.Fobj_COL_MANG(b_dt_1, "ghichu");

            object[] a_danh_muc_2 = bang.Fobj_COL_MANG(b_dt_2, "danh_muc");
            object[] a_ngay_bg_2 = bang.Fobj_COL_MANG(b_dt_2, "ngay_bg");
            object[] a_ng_nhan_2 = bang.Fobj_COL_MANG(b_dt_2, "ng_nhan");
            object[] a_ghichu_2 = bang.Fobj_COL_MANG(b_dt_2, "ghichu");

            object[] a_danh_muc_3 = bang.Fobj_COL_MANG(b_dt_3, "danh_muc");
            object[] a_ngay_bg_3 = bang.Fobj_COL_MANG(b_dt_3, "ngay_bg");
            object[] a_ng_nhan_3 = bang.Fobj_COL_MANG(b_dt_3, "ng_nhan");
            object[] a_ghichu_3 = bang.Fobj_COL_MANG(b_dt_3, "ghichu");

            object[] a_danh_muc_4 = bang.Fobj_COL_MANG(b_dt_4, "danh_muc");
            object[] a_ngay_bg_4 = bang.Fobj_COL_MANG(b_dt_4, "ngay_bg");
            object[] a_ng_nhan_4 = bang.Fobj_COL_MANG(b_dt_4, "ng_nhan");
            object[] a_ghichu_4 = bang.Fobj_COL_MANG(b_dt_4, "ghichu");

            object[] a_danh_muc_5 = bang.Fobj_COL_MANG(b_dt_5, "danh_muc");
            object[] a_ngay_bg_5 = bang.Fobj_COL_MANG(b_dt_5, "ngay_bg");
            object[] a_ng_nhan_5 = bang.Fobj_COL_MANG(b_dt_5, "ng_nhan");
            object[] a_ghichu_5 = bang.Fobj_COL_MANG(b_dt_5, "ghichu");

            object[] a_danh_muc_6 = bang.Fobj_COL_MANG(b_dt_6, "danh_muc");
            object[] a_ngay_bg_6 = bang.Fobj_COL_MANG(b_dt_6, "ngay_bg");
            object[] a_ng_nhan_6 = bang.Fobj_COL_MANG(b_dt_6, "ng_nhan");
            object[] a_ghichu_6 = bang.Fobj_COL_MANG(b_dt_6, "ghichu");

            object[] a_danh_muc_7 = bang.Fobj_COL_MANG(b_dt_7, "danh_muc");
            object[] a_ngay_bg_7 = bang.Fobj_COL_MANG(b_dt_7, "ngay_bg");
            object[] a_ng_nhan_7 = bang.Fobj_COL_MANG(b_dt_7, "ng_nhan");
            object[] a_ghichu_7 = bang.Fobj_COL_MANG(b_dt_7, "ghichu");


            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_1", 'U', a_danh_muc_1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_1", 'N', a_ngay_bg_1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_1", 'U', a_ng_nhan_1);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_1", 'U', a_ghichu_1);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_2", 'U', a_danh_muc_2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_2", 'N', a_ngay_bg_2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_2", 'U', a_ng_nhan_2);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_2", 'U', a_ghichu_2);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_3", 'U', a_danh_muc_3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_3", 'N', a_ngay_bg_3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_3", 'U', a_ng_nhan_3);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_3", 'U', a_ghichu_3);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc", 'U', a_danh_muc_4);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg", 'N', a_ngay_bg_4);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan", 'U', a_ng_nhan_4);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu_4);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_5", 'U', a_danh_muc_5);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_5", 'N', a_ngay_bg_5);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_5", 'U', a_ng_nhan_5);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_5", 'U', a_ghichu_5);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_6", 'U', a_danh_muc_6);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_6", 'N', a_ngay_bg_6);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_6", 'U', a_ng_nhan_6);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_6", 'U', a_ghichu_6);

            dbora.P_THEM_PAR(ref b_lenh, "a_danh_muc_7", 'U', a_danh_muc_7);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg_7", 'N', a_ngay_bg_7);
            dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan_7", 'U', a_ng_nhan_7);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_7", 'U', a_ghichu_7);

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"])
                        + "," + chuyen.OBJ_C(b_dr["ho_ten"])
                        + "," + chuyen.OBJ_C(b_dr["cdanh"])
                        + "," + chuyen.OBJ_N(b_dr["phong"])
                        + "," + chuyen.OBJ_N(b_dr["ngay_vao"])
                        + "," + chuyen.OBJ_N(b_dr["ngay_nop"])
                        + "," + chuyen.OBJ_N(b_dr["ngay_tthuan"])
                        + "," + chuyen.OBJ_N(b_dr["ngay_tt"])
                        + "," + chuyen.OBJ_N(b_dr["ngay_pd"])
                        + "," + chuyen.OBJ_C(b_dr["lydo_nv"])
                        + "," + chuyen.OBJ_C(b_dr["lydo_chitiet"])
                        + "," + chuyen.OBJ_C(b_dr["co_den"])
                        + "," + chuyen.OBJ_C(b_dr["lydo_co_den"])
                        + "," + chuyen.OBJ_N(b_dr["tctv"])
                        + "," + chuyen.OBJ_N(b_dr["tien_bh_daotao"])
                        + "," + chuyen.OBJ_N(b_dr["khoan_khac"])
                        + "," + chuyen.OBJ_N(b_dr["bhxh_nld"])
                        + "," + chuyen.OBJ_N(b_dr["bhxh_nsdld"])
                        + "," + chuyen.OBJ_N(b_dr["bh_suckhoe"])
                        + "," + chuyen.OBJ_C(b_dr["nam"])
                        + "," + chuyen.OBJ_C(b_dr["ky_luong"])
                        + "," + chuyen.OBJ_C(b_dr["so_qd"])
                        + "," + chuyen.OBJ_C(b_dr["tinhtrang"])
                        + "," + chuyen.OBJ_C(b_dr["nguoi_ky"])
                        + "," + chuyen.OBJ_C(b_dr["ngay_ky"])
                        + "," + chuyen.OBJ_N(b_dr["htro_khac"]);

            b_c = b_c + ",:a_danh_muc_1,:a_ngay_bg_1,:a_ng_nhan_1,:a_ghichu_1";
            b_c = b_c + ",:a_danh_muc_2,:a_ngay_bg_2,:a_ng_nhan_2,:a_ghichu_2";
            b_c = b_c + ",:a_danh_muc_3,:a_ngay_bg_3,:a_ng_nhan_3,:a_ghichu_3";
            b_c = b_c + ",:a_danh_muc_4,:a_ngay_bg_4,:a_ng_nhan_4,:a_ghichu_4";
            b_c = b_c + ",:a_danh_muc_5,:a_ngay_bg_5,:a_ng_nhan_5,:a_ghichu_5";
            b_c = b_c + ",:a_danh_muc_6,:a_ngay_bg_6,:a_ng_nhan_6,:a_ghichu_6";
            b_c = b_c + ",:a_danh_muc_7,:a_ngay_bg_7,:a_ng_nhan_7,:a_ghichu_7";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b_lenh.Parameters.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b_cnn.Close();
        }
    }
    public static object[] Faobj_NS_THOIVIEC_MA(string b_so_id, string b_tungay, string b_denngay, string b_phong, string b_sothe, string b_ten, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_phong, b_sothe, b_ten, b_trangkt }, "NNR", "PNS_TV_MA");
    }
    public static object[] Faobj_NS_THOIVIEC_LKE(string b_ngay_d, string b_ngay_c, string b_phong, string b_so_the, string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_ngay_d), chuyen.CNG_SO(b_ngay_c), b_phong, b_so_the, "N'" + b_ten, b_tu, b_den }, "NR", "PNS_TV_LKE");
    }
    public static DataSet Fds_NS_THOIVIEC_CT(string b_so_the)
    {
        return dbora.Fds_LKE(b_so_the, 8, "PNS_TV_CT");
    }
    public static void P_NS_THOIVIEC_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(chuyen.OBJ_S(b_so_the), "PNS_TV_XOA");
    }
    public static DataTable Fdt_NS_TV_IN(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_TV_IN");
    }
    public static DataTable Fdt_NS_TV_LKE_ALL(string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay) }, "PNS_TV_LKE_ALL");
    }
    #endregion QUẢN LÝ NGHỈ VIỆC

    #region QUẢN LÝ DỰ ÁN

    public static string P_NS_LD_DA_NH(ref string b_so_id, DataTable b_dt, DataTable a_dt_luoi)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_so_the = bang.Fobj_COL_MANG(a_dt_luoi, "so_the");
            object[] a_cdanh_da = bang.Fobj_COL_MANG(a_dt_luoi, "cdanh_da");
            object[] a_ngay_d = bang.Fobj_COL_MANG(a_dt_luoi, "ngayd");
            object[] a_ngay_c = bang.Fobj_COL_MANG(a_dt_luoi, "ngayc");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh_da", 'U', a_cdanh_da);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngay_d);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngay_c);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ten_da"]) + "," + chuyen.OBJ_S(b_dr["ngay_tl"]);
            b_c = b_c + ",:a_so_the,:a_cdanh_da,:a_ngayd,:a_ngayc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_LD_DA_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static object[] Faobj_NS_LD_DA_MA(string b_so_id, string b_ten_da, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_ten_da, b_trangkt }, "NNR", "PNS_LD_DA_MA");
    }


    public static object[] Faobj_NS_LD_DA_LKE(string b_ten_da, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { "N'" + b_ten_da, b_tu, b_den }, "NR", "PNS_LD_DA_LKE");
    }


    public static DataSet Fds_NS_LD_DA_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_LD_DA_CT");
    }


    public static void P_NS_LD_DA_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_LD_DA_XOA");
    }
    public static DataTable Fdt_NS_LD_DA_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_LD_DA_LKE_ALL");
    }
    #endregion QUẢN LÝ DỰ ÁN

    #region ĐÁNH GIÁ HỢP ĐỒNG LAO ĐỘNG
    /// <summary>Liệt kê chi tiet</summary>
    /// 
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_DG_HDLD_LKE(string b_so_the_tk, string b_ten_tk, string b_phong_tk, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_phong_tk, b_tu, b_den }, "NR", "PNS_DG_HDLD_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DG_HDLD_MA(string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the_tk, "N'" + b_ten_tk, b_phong_tk, b_so_id, b_trangkt }, "NNR", "PNS_DG_HDLD_MA");
    }

    public static DataTable Fdt_NS_DG_HDLD_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "PNS_DG_HDLD_CT");
    }
    public static DataTable Fdt_NS_DG_HDLD_SC(string b_kieunghi)
    {
        return dbora.Fdt_LKE_S(b_kieunghi, "PNS_DG_HDLD_SC");
    }


    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_DG_HDLD_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            OracleCommand sqlcommand = b_cnn.CreateCommand();
            sqlcommand.CommandText = "PNS_DG_HDLD_NH";
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.Add("B_MA_DVI", b_se.ma_dvi);
            sqlcommand.Parameters.Add("B_NSD", b_se.nsd);
            sqlcommand.Parameters.Add("B_PAS", b_se.pas);
            sqlcommand.Parameters.Add("B_SO_ID", b_so_id).Direction = ParameterDirection.InputOutput;
            sqlcommand.Parameters.Add("B_SO_THE", chuyen.OBJ_S(b_dr["so_the"]));
            sqlcommand.Parameters.Add("B_SOID_HD", OracleDbType.Int64, chuyen.OBJ_N(b_dr["so_id"]), ParameterDirection.Input);
            sqlcommand.Parameters.Add("B_LOAI_HD", chuyen.OBJ_S(b_dr["lhd"]));
            sqlcommand.Parameters.Add("B_NGAY_NHAP", OracleDbType.Int64, chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay_nhap"])), ParameterDirection.Input);
            sqlcommand.Parameters.Add("B_KETQUA", OracleDbType.Int64, chuyen.OBJ_N(b_dr["ketqua"]), ParameterDirection.Input);
            sqlcommand.Parameters.Add("B_HD_TIEP", chuyen.OBJ_S(b_dr["hd_tiep"]));
            sqlcommand.Parameters.Add("B_NOIDUNG", OracleDbType.NVarchar2, chuyen.OBJ_S(b_dr["noidung"]), ParameterDirection.Input);

            try
            {
                sqlcommand.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(sqlcommand.Parameters["B_SO_ID"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b_lenh.Parameters.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b_cnn.Close();
        }

    }


    /// <summary>Xóa thông tin</summary>
    public static void PNS_DG_HDLD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_DG_HDLD_XOA");
    }
    public static DataTable Fdt_NS_DG_HDLD_HOPDONG(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "pns_dg_hdld_hopdong");
    }
    #endregion


    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY
    /// <summary>Liệt kê chi tiet</summary>
    /// 
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_CC_DKY_LVIEC_NGOAICTY_LKE(string b_so_the, string b_nam, string b_ky_luong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_nam, b_ky_luong, b_tu, b_den }, "NR", "PCC_DKY_LVIEC_NGOAICTY_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static DataTable Fdt_CC_DKY_LVIEC_NGOAICTY_MA(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PCC_DKY_LVIEC_NGOAICTY_MA");
    }

    public static DataTable Fdt_CC_DKY_LVIEC_NGOAICTY_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PCC_DKY_LVIEC_NGOAICTY_CT");
    }
    public static void P_CC_DKY_LVIEC_NGOAICTY_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_DKY_LVIEC_NGOAICTY_GUI");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_CC_DKY_LVIEC_NGOAICTY_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," +
               chuyen.OBJ_C(b_dr["so_the"]) + "," +
               chuyen.OBJ_N(b_dr["ngay_dky"]) + "," +
               chuyen.OBJ_C(b_dr["giod"]) + "," +
               chuyen.OBJ_C(b_dr["gioc"]) + "," +
               chuyen.OBJ_C(b_dr["noidung"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PCC_DKY_LVIEC_NGOAICTY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b_lenh.Parameters.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b_cnn.Close();
        }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void P_CC_DKY_LVIEC_NGOAICTY_FILE_NH(DataTable b_dt)
    {

        object[] a_obj;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            a_obj = new object[] { b_dr["so_the"], b_dr["sothe_thaythe"], b_dr["macc_nghi"], b_dr["ngayd"], b_dr["gio_bd"] , b_dr["ngayc"], b_dr["gio_kt"],
                b_dr["ngaynghi"], b_dr["truphepnam"], b_dr["truphep"] , b_dr["namtru"], b_dr["nghibu"], b_dr["ngaybu"], b_dr["noidung"], b_dr["ghichu"] , b_dr["ngayphep"], b_dr["danghi"] };
            dbora.P_GOIHAM(a_obj, "PCC_DKY_LVIEC_NGOAICTY_NH");
        }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_CC_DKY_LVIEC_NGOAICTY_EXPORT()
    {
        return dbora.Fdt_LKE("pCC_DKY_LVIEC_NGOAICTY_export");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PCC_DKY_LVIEC_NGOAICTY_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PCC_DKY_LVIEC_NGOAICTY_XOA");
    }

    #endregion
    #region ĐĂNG KÝ CA NUÔI CON NHỎ
    /// <summary>Liệt kê chi tiet</summary>
    /// 
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_CC_DKY_NCN_LKE(string b_so_the, string b_nam, string b_ky_luong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_nam, b_ky_luong, b_tu, b_den }, "NR", "PCC_DKY_NCN_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static DataTable Fdt_CC_DKY_NCN_MA(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PCC_DKY_NCN_MA");
    }

    public static DataTable Fdt_CC_DKY_NCN_CT(string b_so_the, string b_ngayd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CNG_SO(b_ngayd) }, "PCC_DKY_NCN_CT");
    }
    public static void P_CC_DKY_NCN_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CC_DKY_NCN_GUI");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_CC_DKY_NCN_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," +
               chuyen.OBJ_C(b_dr["so_the"]) + "," +
               chuyen.OBJ_N(b_dr["ngay_dky"]) + "," +
               chuyen.OBJ_C(b_dr["giod"]) + "," +
               chuyen.OBJ_C(b_dr["gioc"]) + "," +
               chuyen.OBJ_C(b_dr["noidung"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PCC_DKY_NCN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                b_lenh.Parameters.Clear();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            b_cnn.Close();
        }
    }
    /// <summary>Nhập nội dung thông tin qua file Excel</summary>
    public static void P_CC_DKY_NCN_FILE_NH(DataTable b_dt)
    {

        object[] a_obj;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            a_obj = new object[] { b_dr["so_the"], b_dr["sothe_thaythe"], b_dr["macc_nghi"], b_dr["ngayd"], b_dr["gio_bd"] , b_dr["ngayc"], b_dr["gio_kt"],
                b_dr["ngaynghi"], b_dr["truphepnam"], b_dr["truphep"] , b_dr["namtru"], b_dr["nghibu"], b_dr["ngaybu"], b_dr["noidung"], b_dr["ghichu"] , b_dr["ngayphep"], b_dr["danghi"] };
            dbora.P_GOIHAM(a_obj, "PCC_DKY_NCN_NH");
        }
    }
    /// <summary>Hiển thị nội dung thông tin qua file Excel</summary>
    public static DataTable P_CC_DKY_NCN_EXPORT()
    {
        return dbora.Fdt_LKE("pCC_DKY_NCN_export");
    }
    /// <summary>Xóa thông tin</summary>
    public static void PCC_DKY_NCN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PCC_DKY_NCN_XOA");
    }

    #endregion




}