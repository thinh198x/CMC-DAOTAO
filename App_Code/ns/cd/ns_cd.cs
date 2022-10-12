using System;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using Cthuvien;

public class ns_cd
{
    #region BẢO HIỂM Y TẾ
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_BHYT_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_BHYT_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_BHYT_CT(string b_so_the, string b_thangd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_BHYT_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_BHYT_NH(DataTable b_dt)
    {

        DataRow b_dr = b_dt.Rows[0];

        string b_thangd = chuyen.OBJ_S(b_dr["thangd"]);
        string b_thangc = chuyen.OBJ_S(b_dr["thangc"]);

        ns_tt.P_KTRA_KIEU_THANG(b_thangd); ns_tt.P_KTRA_KIEU_THANG(b_thangc);
        ns_tt.P_KTRA_GTRI_THANG(b_thangd); ns_tt.P_KTRA_GTRI_THANG(b_thangc);

        dbora.P_GOIHAM(new object[] { b_dr["so_the"],b_dr["dvi"],chuyen.CTH_CSO(b_thangd), chuyen.CTH_CSO(b_thangc),b_dr["cvu"],chuyen.OBJ_N(b_dr["hspc"]),b_dr["cdanh"],b_dr["bac"],
            chuyen.OBJ_N(b_dr["hso"]), chuyen.OBJ_N(b_dr["luong"]),b_dr["sso"],b_dr["nnop"],b_dr["note"] }, "PNS_BHYT_NH");
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_BHYT_XOA(string b_so_the, string b_thangd)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_BHYT_XOA");
    }
    #endregion BẢO HIỂM Y TẾ

    #region BẢO HIỂM XÃ HỘI

    /// <summary>Liet ke (chuyen hang cho can bo) cho can bo</summary>
    public static DataTable Fdt_NS_BHXH_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_BHXH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_BHXH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];

        dbora.P_GOIHAM(new object[] {b_dr["so_the"],b_dr["ten"],b_dr["bhxh"],b_dr["bhyt"],b_dr["bhtn"],b_dr["dcapso"],
                b_dr["sobhxh"],chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ngay_bhxh"])),b_dr["noicap"],chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ndongbhxh"])),chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ndongbhtn"])),b_dr["sobhyt"],b_dr["dk_kcb"],chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ngayd"])),
                chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ngayc"])),b_dr["trabhxh"],chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ngay_trabhxh"])),b_dr["trabhyt"],chuyen.CNG_SO( chuyen.OBJ_S(b_dr["ngay_trabhyt"])),b_dr["ghichu"]}, "PNS_BHXH_NH");
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_BHXH_XOA(string b_so_the)
    {
        dbora.P_GOIHAM(b_so_the, "PNS_BHXH_XOA");
    }
    #endregion BẢO HIỂM: XÃ HỘI

    #region BẢO HIỂM THẤT NGHIỆP
    ///<summary> lay so so bao hiem xa hoi</summary>
    public static DataTable Fdt_NS_BHTN_HOI(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_BHTN_HOI");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_BHTN_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_BHTN_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_BHTN_CT(string b_so_the, string b_thangd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_BHTN_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_BHTN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];

        string b_thangd = chuyen.OBJ_S(b_dr["thangd"]);
        string b_thangc = chuyen.OBJ_S(b_dr["thangc"]);

        ns_tt.P_KTRA_KIEU_THANG(b_thangd); ns_tt.P_KTRA_KIEU_THANG(b_thangc);
        ns_tt.P_KTRA_GTRI_THANG(b_thangd); ns_tt.P_KTRA_GTRI_THANG(b_thangc);

        dbora.P_GOIHAM(new object[] { b_dr["so_the"],b_dr["noilv"],b_dr["sso"],b_dr["dvi"],chuyen.CTH_CSO(b_thangd), chuyen.CTH_CSO(b_thangc),b_dr["cvu"],chuyen.OBJ_N(b_dr["hspc"]),b_dr["cdanh"],b_dr["bac"],
            chuyen.OBJ_N(b_dr["hso"]), chuyen.OBJ_N(b_dr["luong"]),b_dr["nnop"],b_dr["note"] }, "PNS_BHTN_NH");
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_BHTN_XOA(string b_so_the, string b_thangd)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_BHTN_XOA");
    }
    #endregion BẢO HIỂM THẤT NGHIỆP

    #region KINH PHÍ CÔNG ĐOÀN
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KPCD_LKE(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_KPCD_LKE");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_KPCD_CT(string b_so_id, string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_so_id), b_so_the }, "PNS_KPCD_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_KPCD_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["sothe_cd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_N(b_dr["hso"]) + "," + chuyen.OBJ_C(b_dr["nnop"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KPCD_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_KPCD_XOA(string b_so_the, string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, chuyen.OBJ_N(b_so_id) }, "PNS_KPCD_XOA");
    }
    #endregion KINH PHÍ CÔNG ĐOÀN

    #region CHẾ ĐỘ BẢO HIỂM
    public static DataTable PNS_BHXH_CHEDO_CB(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "pns_bhxh_chedo_cb");
    }
    public static DataTable PNS_BHXH_CHEDO_EXCEL(string b_so_the, string b_hoten)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, "N'" + b_hoten }, "PNS_BHXH_CHEDO_EXCEL");
    }

    public static object[] Fdt_NS_BHXH_CHEDO_LKE(string b_so_the, string b_hoten, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, b_tu_n, b_den_n }, "NR", "pns_bhxh_chedo_lke");
    }

    public static DataTable PNS_BHXH_CHEDO_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_BHXH_CHEDO_CT");
    }
    public static void P_NS_BHXH_CHEDO_NH(string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," +
                        chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["phong"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc_nhan"]) + "," + chuyen.OBJ_C(b_dr["so_tk"]) + "," +
                        chuyen.OBJ_C(b_dr["ten_chu_tk"]) + "," + chuyen.OBJ_C(b_dr["ma_ngan_hang"]) + "," + chuyen.OBJ_C(b_dr["ten_ngan_hang"]) + "," +
                        // che do om dau
                        chuyen.OBJ_C(b_dr["hinhthuc_kekhai_cd"]) + "," + chuyen.OBJ_C(b_dr["dieukien_lv_cd"]) + "," +
                        chuyen.OBJ_C(b_dr["ngaynghi_hangtuan_cd"]) + "," + chuyen.OBJ_C(b_dr["tuyen_bv_cd"]) + "," + chuyen.OBJ_C(b_dr["so_seri_cd"]) + "," +
                        chuyen.OBJ_S(b_dr["tungay_cd"]) + "," + chuyen.OBJ_S(b_dr["denngay_cd"]) + "," + chuyen.OBJ_S(b_dr["tong_so_ngay_cd"]) + "," +
                        chuyen.OBJ_S(b_dr["ngay_denghi_huong_cd"]) + "," + chuyen.OBJ_S(b_dr["ngay_sinhcon_cd"]) + "," + chuyen.OBJ_C(b_dr["sothe_bhyt_con_cd"]) + "," +
                        chuyen.OBJ_S(b_dr["so_con_biom_cd"]) + "," + chuyen.OBJ_C(b_dr["ma_benh_daingay_cd"]) + "," + chuyen.OBJ_C(b_dr["ten_benh_cd"]) + "," +
                        chuyen.OBJ_C(b_dr["nghi_duong_thai_cd"]) + "," + chuyen.OBJ_S(b_dr["ngay_gquyet_truoc_cd"]) + "," + chuyen.OBJ_C(b_dr["dot_giaiquyet_cd"]) + "," +
                        chuyen.OBJ_S(b_dr["thang_nam_gquyet_cd"]) + "," + chuyen.OBJ_C(b_dr["dot_bsung_cd"]) + "," + chuyen.OBJ_S(b_dr["thang_nam_bsung_cd"]) + "," +
                        chuyen.OBJ_C(b_dr["phuong_an_cd"]) + "," + chuyen.OBJ_C(b_dr["ghichu_cd"]) + "," +
                        // thai san
                        chuyen.OBJ_C(b_dr["hinhthuc_kekhai_ts"]) + "," + chuyen.OBJ_C(b_dr["th_huong_thaisan_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["ngay_nghi_ht_ts"]) + "," + chuyen.OBJ_S(b_dr["ngay_dilam_lai_ts"]) + "," + chuyen.OBJ_C(b_dr["so_seri_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["tungay_ts"]) + "," + chuyen.OBJ_S(b_dr["denngay_ts"]) + "," + chuyen.OBJ_S(b_dr["tong_so_ngay_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["ngay_denghi_huong_ts"]) + "," + chuyen.OBJ_C(b_dr["dieukien_khamthai_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["dieukien_sinhcon_ts"]) + "," + chuyen.OBJ_C(b_dr["ma_bhxh_con_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["sothe_bhyt_con_ts"]) + "," + chuyen.OBJ_S(b_dr["tuoithai_ts"]) + "," + chuyen.OBJ_S(b_dr["ngay_sinh_con_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["ngay_con_chet_ts"]) + "," + chuyen.OBJ_S(b_dr["socon_ts"]) + "," + chuyen.OBJ_S(b_dr["socon_thai_chet_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["ngaynhan_connuoi_ts"]) + "," + chuyen.OBJ_S(b_dr["ngaynhan_con_mth_ts"]) + "," + chuyen.OBJ_C(b_dr["ma_bhxh_cuame_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["sothe_bhyt_me_ts"]) + "," + chuyen.OBJ_C(b_dr["so_cmnd_me_ts"]) + "," + chuyen.OBJ_C(b_dr["nghi_duong_thai_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["mangthai_ho_ts"]) + "," + chuyen.OBJ_C(b_dr["pthuat_thai_duoi32t_ts"]) + "," + chuyen.OBJ_S(b_dr["ngay_me_chet_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["ngay_ketluat_ts"]) + "," + chuyen.OBJ_S(b_dr["phi_giamdinh_ts"]) + "," + chuyen.OBJ_C(b_dr["soso_bhxh_nguoinuoi_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["cha_nghi_chamcon_ts"]) + "," + chuyen.OBJ_S(b_dr["ngay_gquyet_truoc_ts"]) + "," + chuyen.OBJ_C(b_dr["dot_giaiquyet_ts"]) + "," +
                        chuyen.OBJ_S(b_dr["thang_nam_gquyet_ts"]) + "," + chuyen.OBJ_C(b_dr["dot_bsung_ts"]) + "," + chuyen.OBJ_S(b_dr["thang_nam_bsung_ts"]) + "," +
                        chuyen.OBJ_C(b_dr["lydo_denghi_dchinh_ts"]) + "," + chuyen.OBJ_C(b_dr["phuong_an_ts"]) + "," + chuyen.OBJ_C(b_dr["ghichu_ts"]) + "," +
                        // phuc hoi suc khoe
                        chuyen.OBJ_C(b_dr["hinhthuc_kekhai_phsk"]) + "," + chuyen.OBJ_S(b_dr["ngay_dilam_lai_phsk"]) + "," +
                        chuyen.OBJ_C(b_dr["so_seri_phsk"]) + "," + chuyen.OBJ_S(b_dr["tungay_phsk"]) + "," + chuyen.OBJ_S(b_dr["denngay_phsk"]) + "," +
                        chuyen.OBJ_S(b_dr["tong_so_ngay_phsk"]) + "," + chuyen.OBJ_S(b_dr["ngay_denghi_huong_phsk"]) + "," + chuyen.OBJ_S(b_dr["tyle_suygiam_phsk"]) + "," +
                        chuyen.OBJ_S(b_dr["ngay_giamdinh_phsk"]) + "," + chuyen.OBJ_S(b_dr["ngay_gquyet_truoc_phsk"]) + "," + chuyen.OBJ_C(b_dr["dot_giaiquyet_phsk"]) + "," +
                        chuyen.OBJ_S(b_dr["thang_nam_gquyet_phsk"]) + "," + chuyen.OBJ_C(b_dr["dot_bsung_phsk"]) + "," + chuyen.OBJ_S(b_dr["thang_nam_bsung_phsk"]) + "," +
                        chuyen.OBJ_C(b_dr["phuong_an_phsk"]) + "," + chuyen.OBJ_C(b_dr["lydo_denghi_dchinh_phsk"]) + "," + chuyen.OBJ_C(b_dr["ghichu_phsk"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_BHXH_CHEDO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_BHXH_CHEDO_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_BHXH_CHEDO_XOA");
    }
    #endregion CHẾ ĐỘ BẢO HIỂM

    #region KHAI BÁO ĐÓNG MỚI
    public static object[] FS_NS_KHAIBAO_DM_LKE(string b_phong, string b_thang_hd, string b_hoten, string b_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CTH_SO(b_thang_hd), "N'" + b_hoten, chuyen.OBJ_N(b_tinhtrang), b_tu, b_den }, "NR", "PNS_KHAIBAO_DM_LKE");
    }
    public static void Fs_NS_KHAIBAO_DM_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (b_dr["chon"].Equals("X"))
                {
                    dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["lhd"], b_dr["thang_bd"], b_dr["is_bhxh"], b_dr["is_bhyt"], b_dr["is_bhtn"] }, "PNS_KHAIBAO_DM_NH");
                }
            }
        }
    }
    ///<summary> Xóa </summary>
    public static void Fs_NS_KHAIBAO_DM_XOA(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (b_dr["chon"].Equals("X"))
                {
                    dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["lhd"] }, "PNS_KHAIBAO_DM_XOA");
                }
            }
        }
    }
    /// <summary>Kiểm tra dữ liệu ngày chi tiet</summary>
    public static bool Fdt_NS_KHAIBAO_CHECK_DATA(DataTable b_dt, ref string so_the)
    {
        DataTable dt;
        bang.P_BO_HANG(ref b_dt, "CHON", "");
        if (b_dt.Rows.Count > 0)
        {
            foreach (DataRow b_dr in b_dt.Rows)
            {
                dt = dbora.Fdt_LKE_S(new object[] { b_dr["so_the"], b_dr["thang_bd"] }, "PNS_NS_KHAIBAO_CHECK_DATA");
                so_the = b_dr["so_the"].ToString();
                if (chuyen.OBJ_I(dt.Rows[0]["COUNT_"]) <= 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    #endregion KHAI BÁO ĐÓNG MỚI

    #region BIẾN ĐỘNG BẢO HIỂM
    public static DataTable Fdt_NS_BIENDONG_BH_LKE_ALL()
    {
        return dbora.Fdt_LKE("pns_biendong_bh_lke_all");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_BIENDONG_BH_LKE(string b_so_the, string b_hoten, string b_phong, string b_thangd, string b_thangc, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, "N'" + b_hoten, b_phong, chuyen.CTH_SO(b_thangd), chuyen.CTH_SO(b_thangc), b_tu_n, b_den_n }, "NR", "PNS_BIENDONG_BH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_BIENDONG_BH_MA(string b_so_id, string b_sothe, string b_hoten, string b_phong, string b_thangd, string b_thangc, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_sothe, "N'" + b_hoten, b_phong, chuyen.CTH_SO(b_thangd), chuyen.CTH_SO(b_thangc), b_trangkt }, "NNR", "PNS_BIENDONG_BH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_BIENDONG_BH_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = ",:so_id" + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["loai_bd"]) + "," + chuyen.OBJ_C(b_dr["phuong_an"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["is_bhxh"]) + "," + chuyen.OBJ_C(b_dr["is_bhyt"]) + "," + chuyen.OBJ_C(b_dr["is_bhtn"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["thang_bd"]) + "," + chuyen.OBJ_S(b_dr["luong_c"]) + "," + chuyen.OBJ_S(b_dr["luong_m"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngaytra_bhxh"]) + "," + chuyen.OBJ_S(b_dr["ngaytra_bhyt"]) + "," + chuyen.OBJ_C(b_dr["gchu"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_truythu_d"]) + "," + chuyen.OBJ_S(b_dr["ngay_truythu_c"]) + "," + chuyen.OBJ_S(b_dr["tt_bhxh"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tt_bhyt"]) + "," + chuyen.OBJ_S(b_dr["tt_bhtn"]) + "," + chuyen.OBJ_S(b_dr["ngay_thoaithu_d"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ngay_thoaithu_c"]) + "," + chuyen.OBJ_S(b_dr["tht_bhxh"]) + "," + chuyen.OBJ_S(b_dr["tht_bhyt"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tht_bhtn"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_BIENDONG_BH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }


    }
    /// <summary>Tính thu nhập truy thu vs thoái thu</summary>
    public static DataTable P_NS_BIENDONG_BH_TRUYTHU(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE_S(new object[] { b_dr["so_the"], b_dr["is_bhxh"], b_dr["is_bhyt"], b_dr["is_bhtn"], chuyen.OBJ_N(b_dr["luong_c"]),
            chuyen.OBJ_N(b_dr["luong_m"]), b_dr["ngay_truythu_d"].ToString(), b_dr["ngay_truythu_c"] }, "PNS_BIENDONG_BH_TRUYTHU");
    }
    /// <summary>Tính thu nhập truy thu vs thoái thu</summary>
    public static DataTable P_NS_BIENDONG_BH_THOAITHU(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE_S(new object[] { b_dr["so_the"], b_dr["is_bhxh"], b_dr["is_bhyt"], b_dr["is_bhtn"], chuyen.OBJ_N(b_dr["luong_c"]),
            chuyen.OBJ_N(b_dr["luong_m"]), b_dr["ngay_thoaithu_d"].ToString(), b_dr["ngay_thoaithu_c"] }, "PNS_BIENDONG_BH_THOAITHU");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_BIENDONG_BH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_BIENDONG_BH_XOA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_BIENDONG_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_NS_BIENDONG_BH_CT");
    }

    public static DataTable Fdt_MA_TILE_DONG_BH()
    {
        return dbora.Fdt_LKE("PHT_MA_TILE_DONG_BH");
    }
    #endregion

    #region THÔNG TIN BẢO HIỂM
    public static DataTable Fdt_NS_TT_BH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_TT_BH_LKE_ALL");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TT_BH_LKE(string b_phong, string b_so_the, string b_ten, string b_nghiviec, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_so_the, "N'" + b_ten, b_nghiviec, b_tu_n, b_den_n }, "NR", "PNS_TT_BH_LKE");
    }

    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_TT_BH_MA(string b_so_id, string b_phong, string b_sothe, string b_ten, string b_nghiviec, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_phong, b_sothe, "N'" + b_ten, b_nghiviec, b_trangkt }, "NNR", "PNS_TT_BH_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TT_BH_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            string b_c = "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["maso_bhxh"]) + "," + chuyen.OBJ_C(b_dr["luong_bh"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tg_dongbh_truoc"]) + "," + chuyen.OBJ_S(b_dr["tuthang_bhxh"]) + "," + chuyen.OBJ_S(b_dr["denthang_bhxh"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["soso_bhxh"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang_so"]) + "," + chuyen.OBJ_S(b_dr["ngay_cap"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["maso_hogiadinh"]) + "," + chuyen.OBJ_C(b_dr["vung_sinhsong"]) + "," + chuyen.OBJ_C(b_dr["vung_luongtoithieu"]) + "," + chuyen.OBJ_C(b_dr["noilamviec"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["tuthang_bhyt"]) + "," + chuyen.OBJ_S(b_dr["denthang_bhyt"]) + "," + chuyen.OBJ_C(b_dr["sothe_yte"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tinhtrang_the"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["noikham_chuabenh"]) + "," + chuyen.OBJ_C(b_dr["ngay_bangiaothe"]) + ",:so_id";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TT_BH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void Fdt_TT_BH_IMP_NH(DataTable dtData)
    {
        bang.P_CSO_SO(ref dtData, "LUONG_BH,TG_DONGBH_TRUOC");
        bang.P_CNG_SO(ref dtData, "NGAY_CAP,NGAY_NOP,NGAY_HL,NGAY_HHL,NGAY_BANGIAOTHE");
        bang.P_CTH_SO(ref dtData, "TUTHANG_BHXH,DENTHANG_BHXH,TUTHANG_BHYT,DENTHANG_BHYT,TUTHANG_BHTN,DENTHANG_BHTN");
        bang.P_THEM_COL(ref dtData, "is_bhxh", "X");
        bang.P_THEM_COL(ref dtData, "is_bhyt", "X");
        bang.P_THEM_COL(ref dtData, "is_bhtn", "X");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = dtData.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(dtData, "so_the");
            object[] a_is_bhxh = bang.Fobj_COL_MANG(dtData, "is_bhxh");
            object[] a_luong_bh = bang.Fobj_COL_MANG(dtData, "luong_bh");
            object[] a_tg_dongbh_truoc = bang.Fobj_COL_MANG(dtData, "tg_dongbh_truoc");
            object[] a_tuthang_bhxh = bang.Fobj_COL_MANG(dtData, "tuthang_bhxh");
            object[] a_denthang_bhxh = bang.Fobj_COL_MANG(dtData, "denthang_bhxh");
            object[] a_soso = bang.Fobj_COL_MANG(dtData, "soso");
            object[] a_tinhtrang_so = bang.Fobj_COL_MANG(dtData, "tinhtrang_so");
            object[] a_ngay_cap = bang.Fobj_COL_MANG(dtData, "ngay_cap");
            object[] a_ngay_nop = bang.Fobj_COL_MANG(dtData, "ngay_nop");
            object[] a_ghichu = bang.Fobj_COL_MANG(dtData, "ghichu");
            object[] a_is_bhyt = bang.Fobj_COL_MANG(dtData, "is_bhyt");
            object[] a_tuthang_bhyt = bang.Fobj_COL_MANG(dtData, "tuthang_bhyt");
            object[] a_denthang_bhyt = bang.Fobj_COL_MANG(dtData, "denthang_bhyt");
            object[] a_sothe_yte = bang.Fobj_COL_MANG(dtData, "sothe_yte");
            object[] a_tinhtrang_the = bang.Fobj_COL_MANG(dtData, "tinhtrang_the");
            object[] a_ngay_hl = bang.Fobj_COL_MANG(dtData, "ngay_hl");
            object[] a_ngay_hhl = bang.Fobj_COL_MANG(dtData, "ngay_hhl");
            object[] a_noikham_chuabenh = bang.Fobj_COL_MANG(dtData, "noikham_chuabenh");
            object[] a_ngay_bangiaothe = bang.Fobj_COL_MANG(dtData, "ngay_bangiaothe");
            object[] a_is_bhtn = bang.Fobj_COL_MANG(dtData, "is_bhtn");
            object[] a_tuthang_bhtn = bang.Fobj_COL_MANG(dtData, "tuthang_bhtn");
            object[] a_denthang_bhtn = bang.Fobj_COL_MANG(dtData, "denthang_bhtn");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_is_bhxh", 'S', a_is_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_luong_bh", 'N', a_luong_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tg_dongbh_truoc", 'N', a_tg_dongbh_truoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang_bhxh", 'N', a_tuthang_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang_bhxh", 'N', a_denthang_bhxh);
            dbora.P_THEM_PAR(ref b_lenh, "a_soso", 'S', a_soso);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang_so", 'U', a_tinhtrang_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cap", 'N', a_ngay_cap);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_nop", 'N', a_ngay_nop);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
            dbora.P_THEM_PAR(ref b_lenh, "a_is_bhyt", 'S', a_is_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang_bhyt", 'N', a_tuthang_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang_bhyt", 'N', a_denthang_bhyt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sothe_yte", 'S', a_sothe_yte);
            dbora.P_THEM_PAR(ref b_lenh, "a_tinhtrang_the", 'U', a_tinhtrang_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hl", 'N', a_ngay_hl);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_hhl", 'N', a_ngay_hhl);
            dbora.P_THEM_PAR(ref b_lenh, "a_noikham_chuabenh", 'S', a_noikham_chuabenh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bangiaothe", 'N', a_ngay_bangiaothe);
            dbora.P_THEM_PAR(ref b_lenh, "a_is_bhtn", 'S', a_is_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_tuthang_bhtn", 'N', a_tuthang_bhtn);
            dbora.P_THEM_PAR(ref b_lenh, "a_denthang_bhtn", 'N', a_denthang_bhtn);

            string b_c = ",:a_so_the,:a_is_bhxh,:a_luong_bh,:a_tg_dongbh_truoc,:a_tuthang_bhxh,:a_denthang_bhxh,:a_soso,:a_tinhtrang_so,:a_ngay_cap,:a_ngay_nop,:a_ghichu,:a_is_bhyt";
            b_c = b_c + ",:a_tuthang_bhyt,:a_denthang_bhyt,:a_sothe_yte,:a_tinhtrang_the,:a_ngay_hl,:a_ngay_hhl,:a_noikham_chuabenh,:a_ngay_bangiaothe,:a_is_bhtn,:a_tuthang_bhtn,:a_denthang_bhtn";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TT_BH_IMP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    ///<summary> Xóa </summary>
    public static void P_NS_TT_BH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_TT_BH_XOA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_TT_BH_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_TT_BH_CT");
    }
    #endregion

    #region QUẢN LÝ BẢO HIỂM NGƯỜI THÂN
    public static DataSet Fdt_NS_BH_NGUOITHAN_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "pns_bh_nguoithan_ct");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_BH_NGUOITHAN_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "pns_bh_nguoithan_lke");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_BH_NGUOITHAN_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_hoten = bang.Fobj_COL_MANG(b_dt_ct, "hoten");
            object[] a_loai_qh = bang.Fobj_COL_MANG(b_dt_ct, "loai_qh");
            object[] a_namsinh = bang.Fobj_COL_MANG(b_dt_ct, "namsinh");
            object[] a_baohiem = bang.Fobj_COL_MANG(b_dt_ct, "baohiem");
            object[] a_goi_bh = bang.Fobj_COL_MANG(b_dt_ct, "goi_bh");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ngayc = bang.Fobj_COL_MANG(b_dt_ct, "ngayc");
            object[] a_chiphi = bang.Fobj_COL_MANG(b_dt_ct, "chiphi");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_hoten", 'U', a_hoten);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_qh", 'S', a_loai_qh);
            dbora.P_THEM_PAR(ref b_lenh, "a_namsinh", 'N', a_namsinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_baohiem", 'U', a_baohiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_goi_bh", 'U', a_goi_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'N', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayc", 'N', a_ngayc);
            dbora.P_THEM_PAR(ref b_lenh, "a_chiphi", 'N', a_chiphi);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_S(b_dr["ngay_xacnhan"])
                 + ",:a_hoten" + ",:a_loai_qh" + ",:a_namsinh" + ",:a_baohiem" + ",:a_goi_bh" + ",:a_ngayd" + ",:a_ngayc" + ",:a_chiphi";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_bh_nguoithan_nh(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_BH_NGUOITHAN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "pns_bh_nguoithan_xoa");
    }
    #endregion THAM GIA HUẤN LUYỆN BHLĐ

    #region BẢO HIỂM XÃ HỘI QUÁ TRÌNH

    public static object[] Fdt_NS_BHXH_QT_LKE(string b_loaibh, string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_loaibh, b_so_the, b_tu, b_den }, "NR", "PNS_BHXH_QT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_BHXH_QT_MA(string b_loaibh, string b_so_the, string b_thangd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_loaibh, b_so_the, chuyen.CTH_SO(b_thangd), b_trangkt }, "NNR", "PNS_BHXH_QT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>

    public static DataSet Fdt_NS_BHXH_QT_CT(string b_loaibh, string b_so_the, string b_thangd)
    {
        return dbora.Fds_LKE(new object[] { b_loaibh, b_so_the, chuyen.CTH_SO(b_thangd) }, 2, "PNS_BHXH_QT_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_BHXH_QT_NH(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_loai = bang.Fobj_COL_MANG(b_dt_ct, "ma_loai");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt_ct, "loai");
            object[] a_muc = bang.Fobj_COL_MANG(b_dt_ct, "muc");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_loai", 'S', a_ma_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'U', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc", 'N', a_muc);

            string b_c = "," + chuyen.OBJ_C(b_dr["loaibh"]) + "," + chuyen.OBJ_C(b_dr["tinh"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_C(b_dr["sobhxh"]) + "," + chuyen.OBJ_S(chuyen.CTH_SO(chuyen.OBJ_S(b_dr["thangd"]))) + ","
                + chuyen.OBJ_S(chuyen.CTH_SO(chuyen.OBJ_S(b_dr["thangc"]))) + "," + chuyen.OBJ_C(b_dr["nd"]) + ","
                + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_S(b_dr["tgnam"]) + "," + chuyen.OBJ_S(b_dr["tgthang"])
                + "," + chuyen.OBJ_S(b_dr["hso"]) + "," + chuyen.OBJ_S(b_dr["hspc"]) + "," + chuyen.OBJ_S(b_dr["tienluong"]) + "," + chuyen.OBJ_C(b_dr["tlbh"])
                + "," + chuyen.OBJ_S(chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay"]))) + "," + chuyen.OBJ_S(b_dr["tiendong"]) + "," + chuyen.OBJ_C(b_dr["note"])
                + ",:a_ma_loai" + ",:a_loai" + ",:a_muc";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_BHXH_QT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_BHXH_QT_XOA(string b_loaibh, string b_so_the, string b_thangd)
    {
        dbora.P_GOIHAM(new object[] { b_loaibh, b_so_the, chuyen.CTH_CSO(b_thangd) }, "PNS_BHXH_QT_XOA");
    }

    public static DataTable Fdt_NS_BHXH_HOI_CT(string b_loaibh, string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loaibh, b_so_the }, "pns_bhxh_qt_hoi");
    }

    #endregion BẢO HIỂM XÃ HỘI QUÁ TRÌNH

    #region MÃ PHỤ CẤP BH
    /// <summary>Liệt kê drop</summary>
    public static DataTable Fdt_NS_MA_BHXHPC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_BHXHPC_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_MA_BHXHPC_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_MA_BHXHPC_LKE");
    }

    public static DataTable Fdt_NS_MA_BHXHPC_LKE_PC()
    {
        return dbora.Fdt_LKE("PNS_MA_BHXHPC_LKE_PC");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_MA_BHXHPC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_MA_BHXHPC_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_MA_BHXHPC_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], chuyen.OBJ_I(b_dr["cap"]) }, "PNS_MA_BHXHPC_NH");
    }
    ///<summary> Xóa </summary>
    ///
    public static void P_NS_MA_BHXHPC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_MA_BHXHPC_XOA");
    }
    #endregion MÃ PHỤ CẤP BH

    #region CHẾ ĐỘ ĐI MUỘN VỀ SỚM
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_CD_DSVM_LKE(string b_so_the, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tu, b_den }, "NR", "pns_cd_dsvm_lke");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_CD_DSVM_MA(string b_so_the, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_so_id, b_trangkt }, "NNR", "pns_cd_dsvm_ma");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_CD_DSVM_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "pns_cd_dsvm_ct");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string PNS_CD_DSVM_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(chuyen.OBJ_S(b_dr["ngayd"])) + "," + chuyen.OBJ_C(chuyen.OBJ_S(b_dr["ngayc"]));
            b_c = b_c + "," + chuyen.OBJ_C(chuyen.OBJ_S(b_dr["dimuon"])) + "," + chuyen.OBJ_C(chuyen.OBJ_S(b_dr["vesom"])) + "," + chuyen.OBJ_C(b_dr["note"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_cd_dsvm_nh(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_CD_DSVM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "pns_cd_dsvm_xoa");
    }
    #endregion CHẾ ĐỘ ĐI MUỘN VỀ SỚM

    #region DANH SÁCH ĐỦ ĐIỀU KIỆN THAM GIA CMC CARE
    public static object[] FS_NS_DS_THAMGIA_CMCCARE_LKE(string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "pns_ds_thamgia_cmccare_lke");
    }
    public static void Fs_NS_DS_THAMGIA_CMCCARE_NH(DataTable dtData)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_the = bang.Fobj_COL_MANG(dtData, "so_the");
            object[] a_goi_bh = bang.Fobj_COL_MANG(dtData, "goi_bh");
            object[] a_ngaythamgia_bh = bang.Fobj_COL_MANG(dtData, "ngaythamgia_bh");
            object[] a_songay_thamgia = bang.Fobj_COL_MANG(dtData, "songay_thamgia");
            object[] a_phibh_nam = bang.Fobj_COL_MANG(dtData, "phibh_nam");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_goi_bh", 'S', a_goi_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaythamgia_bh", 'N', a_ngaythamgia_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_songay_thamgia", 'N', a_songay_thamgia);
            dbora.P_THEM_PAR(ref b_lenh, "a_phibh_nam", 'N', a_phibh_nam);


            string b_c = ",:a_so_the,:a_goi_bh,:a_ngaythamgia_bh,:a_songay_thamgia,:a_phibh_nam";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_thongtinbh_cmccare_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region QUẢN LÝ THÔNG TIN BẢO HIỂM CMC CARE
    public static DataTable Fdt_NS_TT_BH_CMCCARE_LKE_ALL()
    {
        return dbora.Fdt_LKE("pns_tt_bh_cmccare_lke_all");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_TT_BH_CMCCARE_LKE(string b_so_the, string b_ten, string b_goibh, string b_ngay_hl, string b_ngay_hhl, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_ten, b_goibh, chuyen.CNG_SO(b_ngay_hl), chuyen.CNG_SO(b_ngay_hhl), b_tu_n, b_den_n }, "NR", "pns_tt_bh_cmccare_lke");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_TT_BH_CMCCARE_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["goi_bh"], b_dr["mucphi"], b_dr["ngay_thamgia"], b_dr["songay_thamgia"] }, "pns_tt_bh_cmccare_nh");
    }
    public static object[] Fdt_NS_TT_BH_CMCCARE_MA(string b_sothe, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, b_trangkt }, "NNR", "pns_tt_bh_cmccare_ma");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_TT_BH_CMCCARE_XOA(string b_so_the, string b_goi_bh)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_goi_bh }, "pns_tt_bh_cmccare_xoa");
    }
    #endregion QUẢN LÝ THÔNG TIN BẢO HIỂM CMC CARE

    #region QUẢN LÝ ĐIỀU CHỈNH, GIẢM BẢO HIỂM CMC CARE
    public static DataTable Fdt_NS_THONGTIN_BH_CU(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "pns_thongtin_bh_cu");
    }

    public static DataTable Fdt_NS_QL_BH_CMCCARE_LKE_ALL()
    {
        return dbora.Fdt_LKE("pns_ql_bh_cmccare_lke_all");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_QL_BH_CMCCARE_LKE(string b_so_the, string b_ten, string b_donvi, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_ten, b_donvi, b_tu_n, b_den_n }, "NR", "pns_ql_bh_cmccare_lke");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_QL_BH_CMCCARE_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["goi_bh_ht"], b_dr["mucphi_ht"], b_dr["goi_bh_dc"], b_dr["mucphi_dc"], b_dr["ngay_hl"], b_dr["ngaygiam_bh"], b_dr["ghichu"] }, "pns_ql_bh_cmccare_nh");
    }
    public static object[] Fdt_NS_QL_BH_CMCCARE_MA(string b_sothe, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, b_trangkt }, "NNR", "pns_ql_bh_cmccare_ma");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_QL_BH_CMCCARE_XOA(string b_so_the, string b_goi_bh_ht, string b_goi_bh_dc, string b_ngay_hl)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_goi_bh_ht, b_goi_bh_dc, chuyen.CNG_SO(b_ngay_hl) }, "pns_ql_bh_cmccare_xoa");
    }
    #endregion QUẢN LÝ ĐIỀU CHỈNH, GIẢM BẢO HIỂM CMC CARE

    #region QUẢN LÝ BẢO HIỂM AETNA
    public static DataTable Fdt_NS_BH_AETNA_LKE_ALL()
    {
        return dbora.Fdt_LKE("pns_bh_aetna_lke_all");
    }

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_BH_AETNA_LKE(string b_so_the, string b_ten, string b_goibh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_ten, b_goibh, b_tu_n, b_den_n }, "NR", "pns_bh_aetna_lke");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_BH_AETNA_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["goi_bh"], b_dr["mucphi"], b_dr["ngay_thamgia"], b_dr["ngay_hl"], b_dr["ghichu"] }, "pns_bh_aetna_nh");
    }
    public static object[] Fdt_BH_AETNA_MA(string b_sothe, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, b_trangkt }, "NNR", "pns_bh_aetna_ma");
    }
    ///<summary> Xóa </summary>
    public static void P_BH_AETNA_XOA(string b_so_the, string b_goi_bh)
    {
        dbora.P_GOIHAM(new object[] { b_so_the, b_goi_bh }, "pns_bh_aetna_xoa");
    }
    #endregion QUẢN LÝ BẢO HIỂM AETNA

    #region DANH SÁCH KHÔNG ĐỦ ĐIỀU KIỆN ĐÓNG BẢO HIỂM
 
    public static object[] FS_NS_DS_KDBHXH_LKE(string b_sothe, string b_hoten, string b_nam, string b_kyluong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_sothe, "N'" + b_hoten, b_nam, b_kyluong, b_tu, b_den }, "NR", "PNS_DS_KDBHXH_LKE");
    }

    public static void FS_NS_DS_KDBHXH_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_sothe = bang.Fobj_COL_MANG(b_dt, "so_the");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt, "phong");
            object[] a_nldd = bang.Fobj_COL_MANG(b_dt, "is_nldd");
            object[] a_maky = bang.Fobj_COL_MANG(b_dt, "ma_ky");

            dbora.P_THEM_PAR(ref b_lenh, "a_sothe", 'S', a_sothe);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_nldd", 'S', a_nldd);
            dbora.P_THEM_PAR(ref b_lenh, "a_maky", 'S', a_maky);

            string b_c = ",:a_sothe,:a_cdanh,:a_phong,:a_nldd,:a_maky";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DS_KDBHXH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex) { throw ex; }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion
}
