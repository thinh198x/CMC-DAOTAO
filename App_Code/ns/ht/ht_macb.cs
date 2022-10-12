using System.Data;
using Oracle.DataAccess.Client;
using Cthuvien;
using System.Web.UI.HtmlControls;
using System.Web;
using System;
using System.Net;

public class ht_macb
{
    #region HT_MA_CB
    /// <summary> Liệt kê </summary>
    public static object[] Faobj_MA_CB_LKE(string b_ten, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ten, b_tu, b_den }, "NR", "PHT_MA_CB_LKE");
    }
    /// <summary> Tim ma </summary>
    public static object[] Faobj_MA_CB_MA(string b_phong, string b_ma, double b_TrangKt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_ma, b_TrangKt }, "NNR", "PHT_MA_CB_MA");
    }
    public static DataTable Fdt_MA_CB_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PHT_MA_CB_CT");
    }
    /// <summary> Nhập </summary>
    public static void P_MA_CB_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        object[] a_obj = new object[] { b_dr["ma"], b_dr["ten"], b_dr["so_cmt"], b_dr["phong"], b_dr["cv"] };
        dbora.P_GOIHAM(a_obj, "PHT_MA_CB_NH");
    }
    ///<summary>Xóa</summary>
    public static void P_MA_CB_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PHT_MA_CB_XOA");
    }
    ///<summary>Nhập từ File</summary>
    public static void P_FILE(DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);

            string c = ",:phong,:ma,:ten";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHT_MA_CB_FILE(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static bool Fb_KTRA_QU(string b_form, string b_file)
    {
        DataTable b_dt = ((DataTable)HttpContext.Current.Application[b_file]).Copy();
        string[] a_s;
        int b_hang = b_dt.Rows.Count - 1;
        for (int i = b_hang; i > -1; i--)
        {
            a_s = chuyen.OBJ_S(b_dt.Rows[i]["qu"]).Split(',');
            if (a_s.Length == 2)
            {
                if (!se.Fb_NSD_QU(a_s[0], a_s[1], "GXDPIMAE")) b_dt.Rows.RemoveAt(i);
            }
            else if (a_s.Length == 3)
            {
                if (!se.Fb_NSD_QU(a_s[0], a_s[1], a_s[2])) b_dt.Rows.RemoveAt(i);
            }
        }
        string b_ma; bool b_xoa = true; DataRow b_dr;
        while (b_xoa)
        {
            b_xoa = false; b_hang = b_dt.Rows.Count - 1;
            for (int i = b_hang; i > -1; i--)
            {
                b_dr = b_dt.Rows[i];
                if (chuyen.OBJ_S(b_dr["ftkhao"]) == "")
                {
                    b_ma = chuyen.OBJ_S(b_dr["ma"]);
                    if (chuyen.OBJ_S(b_dr["qu"]) != "" && bang.Fi_TIM_ROW(b_dt, "ma_ct", b_ma) < 0) { b_dt.Rows.RemoveAt(i); b_xoa = true; }
                }
            }
        }
        b_dt.AcceptChanges();
        string b_nuoc = khac.Fs_NUOC(), b_s;
        if (b_nuoc != "VIE")
        {
            DataTable b_dt_dich = (DataTable)HttpContext.Current.Application["dich"];
            if (!bang.Fb_TRANG(b_dt_dich))
            {
                foreach (DataRow b_drm in b_dt.Rows)
                {
                    b_s = chuyen.OBJ_S(b_drm["ten"]);
                    b_drm["ten"] = khac.Fs_DICH_TIM(b_s, b_nuoc);
                }
                b_dt.AcceptChanges();
            }
        }
        se.P_TG_LUU(b_form, "QUYEN", b_dt);
        return true;
    }
    #endregion

    #region Ghi log hệ thống
    public static object[] Faobj_HT_LOG_LKE(string b_phanhe, string b_nhom_chucnang, string b_taikhoan, string b_manhinh_thaotac,
                                            string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { "N'" + b_phanhe, "N'" + b_nhom_chucnang, b_taikhoan, "N'" + b_manhinh_thaotac, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PHT_LOG_LKE");
    }
    public static DataTable Fdt_HT_LOG_LKE_ALL(string b_phanhe, string b_nhom_chucnang, string b_taikhoan, string b_manhinh_thaotac,
                                           string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { "N'" + b_phanhe, "N'" + b_nhom_chucnang, b_taikhoan, "N'" + b_manhinh_thaotac, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay) }, "PHT_LOG_LKE_ALL");
    }
    #endregion

    #region Lưu lịch sử đăng nhập
    public static void PHT_LICHSU_DANGNHAP_NH()
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_ma_tk = b_se.nsd, b_ngay_dn = DateTime.Today.ToString("dd/MM/yyyy"), b_gio_dn = DateTime.Now.ToString("HH:mm:ss");
        string b_ngay_thoat = "01/01/3000", b_gio_thoat = "";


        string b_diachi_ip = "", hostname = "";
        IPHostEntry ip = new IPHostEntry();
        hostname = System.Net.Dns.GetHostName();
        IPAddress[] ipAddress = Dns.GetHostAddresses(Dns.GetHostName());
        foreach (IPAddress listip in ipAddress)
        {
            if (listip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                b_diachi_ip = listip.ToString();
            }
        }
        dbora.P_GOIHAM(new object[] { b_ma_tk, chuyen.CNG_SO(b_ngay_dn), b_gio_dn, chuyen.CNG_SO(b_ngay_thoat), b_gio_thoat, hostname, b_diachi_ip }, "PHT_LICHSU_DANGNHAP_NH");
    }
    public static object[] Faobj_HT_LICHSU_DANGNHAP_LKE(string b_taikhoan, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_taikhoan, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PHT_LICHSU_DANGNHAP_LKE");
    }
    public static DataTable Fdt_HT_LICHSU_DANGNHAP_LKE_ALL(string b_taikhoan, string b_tungay, string b_denngay)
    {
        return dbora.Fdt_LKE_S(new object[] { b_taikhoan, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay) }, "PHT_LICHSU_DANGNHAP_LKE_ALL");
    }
    #endregion

    #region Danh sách người dùng online
    public static object[] Faobj_HT_DS_USER_ONLINE_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PHT_DS_USER_ONLINE_LKE");
    }
    public static void PHT_DS_USER_ONLINE_NH(string b_trangthai)
    {
        try
        {
            se.se_nsd b_se = new se.se_nsd();
            string b_ma = b_se.nsd;

            string b_diachi_ip = "", hostname = "";
            IPHostEntry ip = new IPHostEntry();
            hostname = System.Net.Dns.GetHostName();
            IPAddress[] ipAddress = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress listip in ipAddress)
            {
                if (listip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    b_diachi_ip = listip.ToString();
                }
            }
            dbora.P_GOIHAM(new object[] { b_trangthai, b_ma, hostname, b_diachi_ip }, "PHT_DS_USER_ONLINE_NH");
        }
        catch (Exception)
        {
        }

    }
    #endregion
}
