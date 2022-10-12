using System;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using Cthuvien;

public class ht_mansd
{
    #region MÃ NSD
    ///<summary>Trả bảng nghiệp vụ NSD</summary>
    public static object[] Fdt_MA_NSD_TS(string b_ten, string b_phanhe, string b_ten_form, double b_tu, double b_den)
    {
        // đọc dữ liệu từ bảng trong databse
        object[] a_obj = dbora.Faobj_LKE(new object[] { "", b_phanhe, "N'" + b_ten_form, b_tu, b_den }, "NR", "pht_ds_chucnang_lke");
        return a_obj;
    }
    public static object[] Fdt_MA_NSD_QUYEN(string b_ten, string b_ma, string b_phanhe, string b_ten_form, double b_tu, double b_den)
    {

        // đọc dữ liệu từ bảng trong databse
        object[] a_obj = dbora.Faobj_LKE(new object[] { b_ma, b_phanhe, "N'" + b_ten_form, b_tu, b_den }, "NR", "PHT_DS_CHUCNANG_LKE");
        return a_obj;
    }
    public static void P_MA_NSD_MA_LOGIN(string b_dvi, string b_ma, string b_ma_login)
    {
        dbora.P_GOIHAM(new object[] { b_dvi, b_ma, b_ma_login }, "PHT_MA_NSD_MA_LOGIN");
    }
    ///<summary>Liệt kê NSD</summary>
    public static object[] Faobj_MA_NSD_LKE(string b_ma_tk, string b_ten_tk, string b_dvi, string b_klk, double b_tu, double b_den)
    {
        string b_md = "";
        if (b_klk != "T") { se.se_nsd b_se = new se.se_nsd(); b_md = b_se.md; }
        return dbora.Faobj_LKE(new object[] { b_ma_tk, "N'" + b_ten_tk, b_dvi, b_md, b_tu, b_den }, "NR", "PHT_MA_NSD_LKE");
    }
    /// <summary> Tim ma </summary>
    public static object[] Faobj_MA_NSD_MA(string b_dvi, string b_klk, string b_ma, double b_TrangKt)
    {
        string b_md = "";
        if (b_klk != "T") { se.se_nsd b_se = new se.se_nsd(); b_md = b_se.md; }
        return dbora.Faobj_LKE(new object[] { b_dvi, b_md, b_ma, b_TrangKt }, "NNR", "PHT_MA_NSD_MA");
    }
    /// <summary> Tim ma </summary>
    public static DataTable Fdt_MA_NSD_QLY(string b_dvi, string b_ma, string b_md)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dvi, b_ma, b_md }, "PHT_MA_NSD_QLY");
    }
    ///<summary>Chi tiết NSD</summary>
    public static void P_MA_NSD_CT(string b_dvi, string b_ma, string b_phanhe, string b_tenform, out DataTable b_dt_ct, out DataTable b_dt_nv, out DataTable b_dt_nhom, out DataTable b_dt_dvi, out string b_dong, double b_tu, double b_den)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_dvi, b_ma, b_phanhe, "N'" + b_tenform, b_se.md, b_tu, b_den }, 6, "PHT_MA_NSD_CT");
        b_dt_ct = b_ds.Tables[0].Copy(); b_dt_nv = b_ds.Tables[1].Copy(); b_dt_dvi = b_ds.Tables[2].Copy();
        b_dt_nhom = b_ds.Tables[3].Copy();
        b_dong = b_ds.Tables[4].Rows[0]["dong"].ToString();
    }
    public static void P_MA_NSD_BC(string b_dvi, string b_ma, string b_loai_sl, double b_tu_n, double b_den_n, out DataTable b_dt_bc, out int b_dong)
    {
        object[] a_kq = dbora.Faobj_LKE(new object[] { b_dvi, b_ma, b_loai_sl, b_tu_n, b_den_n }, "NR", "PHT_MA_NSD_BC");
        b_dt_bc = ((DataTable)a_kq[1]).Copy();
        b_dong = Convert.ToInt32(a_kq[0]);
    }

    ///<summary>Xóa mã NSD</summary>
    public static void P_MA_NSD_XOA(string b_dvi, string b_ma)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_dvi, b_ma }, "PHT_MA_NSD_XOA");
    }
    ///<summary>Nhập mã NSD</summary>
    public static void P_MA_NSD_NH(DataTable b_dt_ct, DataTable b_dt_nv, DataTable b_dt_nhom, DataTable b_dt_dvi, DataTable b_dt_bc)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        DataTable b_dt_nv1 = bang.Fdt_TAO_BANG(b_dt_nv, "NV", "TS");
        if (b_dt_bc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_bc, new object[] { "", "", "", "" });
        bang.P_BO_HANG(ref b_dt_nv1, "TC", "");
        if (b_dt_nv1.Rows.Count > 0)
        {
            string b_ghi = b_dt_nv1.Rows[0]["ghi"].ToString(),
                b_xem = b_dt_nv1.Rows[0]["xem"].ToString(),
                b_xoa = b_dt_nv1.Rows[0]["xoa"].ToString(),
                b_pd = b_dt_nv1.Rows[0]["pd"].ToString(),
                b_in = b_dt_nv1.Rows[0]["in"].ToString(),
                b_mo_cpd = b_dt_nv1.Rows[0]["mo_cpd"].ToString(),
                b_active = b_dt_nv1.Rows[0]["active"].ToString(),
                b_export = b_dt_nv1.Rows[0]["export"].ToString(),
                b_tc = b_dt_nv1.Rows[0]["tc"].ToString();
            bang.P_THEM_HANG(ref b_dt_nv, new string[] { b_ghi, b_xem, b_xoa, b_pd, b_in, b_mo_cpd, b_active, b_export, "B", b_tc });
            bang.P_THEM_HANG(ref b_dt_nv, new string[] { b_ghi, b_xem, b_xoa, b_pd, b_in, b_mo_cpd, b_active, b_export, "P", b_tc });
            bang.P_THEM_HANG(ref b_dt_nv, new string[] { b_ghi, b_xem, b_xoa, b_pd, b_in, b_mo_cpd, b_active, b_export, "G", b_tc });
        }
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr_ct = b_dt_ct.Rows[0];
            string b_mk = "";
            if (b_dr_ct["pas"].ToString().Trim() != b_dr_ct["pas_goc"].ToString().Trim()) // đổi pass
                b_mk = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(b_dr_ct["pas"].ToString().Trim(), "SHA1");
            else b_mk = b_dr_ct["pas"].ToString().Trim();



            object[] a_md = bang.Fobj_COL_MANG(b_dt_nv, "md");
            object[] a_nv = bang.Fobj_COL_MANG(b_dt_nv, "nv");
            object[] a_tc = bang.Fobj_COL_MANG(b_dt_nv, "tc");
            object[] a_loai_sl = bang.Fobj_COL_MANG(b_dt_bc, "loai");
            object[] a_chon = bang.Fobj_COL_MANG(b_dt_bc, "chon");
            object[] a_ma_bc = bang.Fobj_COL_MANG(b_dt_bc, "ma_bc");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_bc, "ten");

            dbora.P_THEM_PAR(ref b_lenh, "md", 'S', a_md);
            dbora.P_THEM_PAR(ref b_lenh, "nv", 'S', a_nv);
            dbora.P_THEM_PAR(ref b_lenh, "tc", 'S', a_tc);
            dbora.P_THEM_PAR(ref b_lenh, "loai_sl", 'S', a_loai_sl);
            dbora.P_THEM_PAR(ref b_lenh, "chon", 'S', a_chon);
            dbora.P_THEM_PAR(ref b_lenh, "ma_bc", 'S', a_ma_bc);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);

            if (b_dt_dvi.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt_dvi, 1);
            object[] a_dvi = bang.Fobj_COL_MANG(b_dt_dvi, "dvi");
            dbora.P_THEM_PAR(ref b_lenh, "dvi", 'S', a_dvi);

            if (b_dt_nhom.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt_nhom, 1);
            object[] a_nhom = bang.Fobj_COL_MANG(b_dt_nhom, "nhom");
            dbora.P_THEM_PAR(ref b_lenh, "nhom", 'S', a_nhom);

            string c = "," + chuyen.OBJ_C(b_dr_ct["dvi"]) + "," + chuyen.OBJ_C(b_dr_ct["ma_login"]) + "," + chuyen.OBJ_C(b_dr_ct["ma"]) + "," + chuyen.OBJ_C(b_se.md);
            c = c + "," + chuyen.OBJ_C(b_dr_ct["ten"]) + "," + chuyen.OBJ_C(b_mk) + "," + chuyen.OBJ_C(b_dr_ct["phong"]) + "," + chuyen.OBJ_C(b_dr_ct["full"]);
            c = c + ",:md,:nv,:tc,:loai_sl,:chon,:ma_bc,:ten,:dvi,:nhom";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHT_MA_NSD_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    ///<summary>Kiểm tra người NSD và người nhập</summary>
    public static bool Fb_QSUA(string b_nsd)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        return (b_nsd == "" || b_nsd == b_se.nsd);
    }
    ///<summary>Kiểm tra người NSD và người nhập</summary>
    public static void P_QSUA(string b_nsd)
    { // Dan
        if (!ht_mansd.Fb_QSUA(kytu.C_NVL(b_nsd))) throw new Exception("loi:Không sửa, xóa chứng từ người khác:loi");
    }
    public static void P_HTMANSD_FORM(string b_md, string b_nv, string b_kt)
    {
        if (!se.Fb_NSD_QU(b_md, b_nv, b_kt)) throw new Exception("loi:Không có quyền xem số liệu:loi");
    }
    /// <summary>Xin so ID </summary>
    public static double Fn_SO_ID()
    { // Dan
        return chuyen.OBJ_N(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
    }
    ///<summary>Nhập từ File</summary>
    public static void P_FILE(string b_dvi, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ma_login = bang.Fobj_COL_MANG(b_dt, "ma_login");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_pas = bang.Fobj_COL_MANG(b_dt, "pas");
            object[] a_nhom = bang.Fobj_COL_MANG(b_dt, "nhom");

            dbora.P_THEM_PAR(ref b_lenh, "phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "ma_login", 'S', a_ma_login);
            dbora.P_THEM_PAR(ref b_lenh, "ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "pas", 'S', a_pas);
            dbora.P_THEM_PAR(ref b_lenh, "nhom", 'S', a_nhom);

            string c = ",'" + b_dvi + "','" + b_se.md + "',:phong,:ma,:ma_login,:ten,:pas,:nhom";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHT_MA_NSD_FILE(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    ///<summary>Yên: Kiểm tra có user Map đơn vị quản lý không</summary>
    public static DataTable Fdt_MA_NSD_MAP_KTRA(string b_dvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dvi }, "pht_ma_nsd_map_ktra");
    }
    #endregion

    #region Phân quyền
    public static DataTable Fdt_MODULE()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "HDNS", "Tổ chức nhân sự" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TD", "Tuyển dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "NS", "Hồ sơ nhân sự" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "CD", "Bảo hiểm" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "CC", "Chấm công" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TL", "Tiền lương" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DG360", "Đánh giá 360 độ" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DG", "Đánh giá" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DT", "Đào tạo" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DTO", "Đào tạo online" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "HT", "Quản trị" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "CN", "Cá nhân" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "PD", "Quản lý phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "BC", "Báo cáo" });
        return b_dt;
    }

    #endregion
}
