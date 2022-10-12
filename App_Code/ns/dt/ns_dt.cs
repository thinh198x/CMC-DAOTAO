using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_dt
{
    #region KẾ HOẠCH ĐÀO TẠO
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_KH_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_nam), b_tu, b_den }, "NR", "PNS_DT_KH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_KH_MA(string b_nam, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_ma, b_trangkt }, "NNR", "PNS_DT_KH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_KH_CT(string b_nam, string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_ma }, "PNS_DT_KH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_KH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["nam"], b_dr["ma"], chuyen.OBJ_S(b_dr["ngayd"]), b_dr["nhom_dt"], b_dr["cap_dt"],
                b_dr["doituong"], b_dr["soluong"], b_dr["hinhthuc"], b_dr["thoigian"], b_dr["diadiem"], b_dr["kinhphi"], b_dr["trongnuoc"], b_dr["note"] }, "PNS_DT_KH_NH");
        }
    }
    public static void PNS_DT_KH_XOA(string b_nam, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_nam, b_ma }, "PNS_DT_KH_XOA");
    }
    #endregion KẾ HOẠCH ĐÀO TẠO
     
    #region KHOÁ BỒI DƯỠNG
    public static DataSet Fdt_NS_DT_KBD_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_DT_KBD_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static DataTable Fdt_NS_DT_KBD_LKE(string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam }, "PNS_DT_KBD_LKE");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static string P_NS_DT_KBD_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_kq = bang.Fobj_COL_MANG(b_dt_ct, "kq");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_kq", 'U', a_kq);

            string b_c = "," + chuyen.OBJ_S(b_dr["nam"]) + ",:so_id," + chuyen.OBJ_C(b_dr["ten"]) + ","
                + chuyen.OBJ_C(b_dr["noidt"]) + "," + chuyen.OBJ_C(b_dr["quocgia"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + ","
                + chuyen.OBJ_S(b_dr["ngayc"]) + "," + chuyen.OBJ_C(b_dr["noidung"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + ","
                + chuyen.OBJ_C(b_dr["kinhphi"]) + "," + chuyen.OBJ_S(b_dr["giatri"]) + "," + chuyen.OBJ_C(b_dr["note"]) + ","
                + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," + chuyen.OBJ_C(b_dr["ma_nte"])
                + ",:a_tt" + ",:a_so_the" + ",:a_ten" + ",:a_phong" + ",:a_kq";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KBD_NH(" + b_se.tso + b_c + "); end;";
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
    public static void PNS_DT_KBD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_I(b_so_id), "PNS_DT_KBD_XOA");
    }
    #endregion KHOÁ BỒI DƯỠNG
       
    #region DANH SÁCH ĐÀO TẠO
    public static object[] Fdt_NS_DT_DANHSACH_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_DT_DANHSACH_LKE");
    }

    public static DataTable Fdt_NS_DT_DANHSACH_PHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_lan = bang.Fobj_COL_MANG(b_dt_ct, "lan");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_lan", 'N', a_lan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_dr["loai"]) + ",:a_phong,:a_ma,:a_lan,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANHSACH_PHEDUYET(" + b_se.tso + b_c + "); end;";
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

    public static void Fdt_NS_DT_DANHSACH_KOPHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_lan = bang.Fobj_COL_MANG(b_dt_ct, "lan");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_lan", 'N', a_lan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = "," + chuyen.OBJ_C(b_dr["loai"]) + ",:a_phong,:a_ma,:a_lan,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANHSACH_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }


    public static void Fdt_NS_DT_DANHSACH_CHOPHEDUYET(DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_ma = bang.Fobj_COL_MANG(b_dt_ct, "ma");
            object[] a_lan = bang.Fobj_COL_MANG(b_dt_ct, "lan");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_lan", 'N', a_lan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            string b_c = "," + chuyen.OBJ_C(b_dr["loai"]) + ",:a_phong,:a_ma,:a_lan,:a_ykien";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANHSACH_CHOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion DANH SÁCH ĐÀO TẠO
     
    #region KẾT QUẢ ĐÀO TẠO
    public static DataSet Fdt_NS_DT_KETQUADT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_so_id) }, 2, "PNS_DT_KETQUADT_CT");
    }
    /// <summary>Liệt kê toan bo</summary>
    public static object[] Fdt_NS_DT_KETQUADT_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_KETQUADT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_KETQUADT_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_KETQUADT_MA");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_KETQUADT_NH(string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_tt = bang.Fobj_COL_MANG(b_dt_ct, "tt");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_ketqua = bang.Fobj_COL_MANG(b_dt_ct, "ketqua");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'N', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua", 'U', a_ketqua);

            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_S(b_dr["ngay_qd"]) + "," + chuyen.OBJ_C(b_dr["nhanxet"])
                + ",:a_tt" + ",:a_so_the" + ",:a_ten" + ",:a_phong" + ",:a_ketqua";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KETQUADT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_DT_KETQUADT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_KETQUADT_XOA");
    }

    public static DataTable PNS_DT_KETQUADT_LKECB(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_KETQUADT_LKECB");
    }
    #endregion KẾT QUẢ ĐÀO TẠO

    #region KHỞI TẠO KHÓA ĐÀO TẠO
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_TAOKH_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_TAOKH_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_TAOKH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_TAOKH_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_TAOKH_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_TAOKH_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>

    public static void P_NS_DT_TAOKH_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"],chuyen.OBJ_S(b_dr["ngaytrinh"]),b_dr["so_qd"],chuyen.OBJ_S(b_dr["ngay_qd"]), b_dr["ten"], chuyen.OBJ_S(b_dr["tyle"]),
                b_dr["nhomcn"], b_dr["chuyennganh"],b_dr["muctieu"],b_dr["noidung"], b_dr["noidt"],chuyen.OBJ_S(b_dr["soluong"]),chuyen.OBJ_S(b_dr["ngayd"]),chuyen.OBJ_S(b_dr["ngayc"]),
                b_dr["cap_dt"], b_dr["hinhthuc"], b_dr["note"],b_dr["tinhtrang"] }, "PNS_DT_TAOKH_NH");
        }
    }
    public static void PNS_DT_TAOKH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_DT_TAOKH_XOA");
    }
    //dong dang ky khoa hoc

    public static void Fdt_NS_DT_TAOKH_DONG(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_TAOKH_DONG");
    }
    #endregion KHỞI TẠO KHÓA ĐÀO TẠO

    #region CÀI ĐẶT PHÊ DUYỆT
    public static DataTable Fdt_NS_DT_CAIDAT_PD_CT(string b_loai, string b_dvi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loai, b_dvi }, "PNS_DT_CAIDAT_PD_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_CAIDAT_PD_NH(DataTable b_dt,string b_LoaiPd, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_lan = bang.Fobj_COL_MANG(b_dt_ct, "lan");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "phong");
            object[] a_email = bang.Fobj_COL_MANG(b_dt_ct, "email");
            object[] a_so_ngay = bang.Fobj_COL_MANG(b_dt_ct, "so_ngay");
            object[] a_loai_pd = bang.Fobj_COL_MANG(b_dt_ct, "loai_pd");
            dbora.P_THEM_PAR(ref b_lenh, "a_lan", 'S', a_lan);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_ngay", 'N', a_so_ngay);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_pd", 'S', a_loai_pd);
            string b_c = "," + chuyen.OBJ_C(b_LoaiPd) + "," + chuyen.OBJ_C(b_dr["dvi"]) + ",:a_lan" + ",:a_so_the" + ",:a_ten" + ",:a_phong" + ",:a_email" + ",:a_so_ngay" + ",:a_loai_pd";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_CAIDAT_PD_NH(" + b_se.tso + b_c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thông tin</summary>
    public static void PNS_DT_CAIDAT_PD_XOA(string b_so_the, string b_loai)
    {
        dbora.P_GOIHAM(b_so_the, b_loai, "PNS_DT_CAIDAT_PD_XOA");
    }
    #endregion CÀI ĐẶT PHÊ DUYỆT

    #region DANH SÁCH ĐÀO TẠO CHUẨN THEO CHỨC DANH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_Fs_DT_NGV_CHUAN_THEO_CDANH_LKE(double b_tu_n, double b_den_n, double b_nam, string b_bophan, string b_cdanh)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_nam, b_bophan, b_cdanh }, "NR", "PNS_DT_THEO_CDANH_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_Fs_DT_NGV_CHUAN_THEO_CDANH_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PFs_DT_NGV_CHUAN_THEO_CDANH_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_Fs_DT_NGV_CHUAN_THEO_CDANH_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PFs_DT_NGV_CHUAN_THEO_CDANH_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_Fs_DT_NGV_CHUAN_THEO_CDANH_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PFs_DT_NGV_CHUAN_THEO_CDANH_XOA");
    }
    #endregion DANH MỤC NĂNG LỰC

    #region KẾ HOẠCH ĐÀO TẠO NĂM
    /// <summary>Liệt kê toàn bộ</summary>
    public static object[] Fdt_NS_DT_KHDT_NAM_LKE(DataTable b_dt_tk, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["namtk"]), chuyen.OBJ_N(b_dr["thangtk"]), b_tu, b_den }, "NR", "PNS_DT_KHDT_NAM_LKE");
    }
    /// <summary>Liệt kê ra file Excel</summary>
    public static object[] Fdt_NS_DT_KHDT_NAM_EXCEL(string b_nam, string b_thang)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang) }, "R", "PNS_DT_KHDT_NAM_EXCEL");
    }
    // Lấy năm đã lên kế hoạch đào tạo
    public static DataTable Fdt_NS_DT_KHDT_NAM_NAM()
    {
        return dbora.Fdt_LKE("PNS_DT_KHDT_NAM_NAM");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_KHDT_NAM_MA(DataTable b_dt_tk, string b_so_id, double b_trangkt)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["namtk"]), chuyen.OBJ_N(b_dr["thangtk"]), chuyen.CSO_SO(b_so_id), b_trangkt }, "NNR", "PNS_DT_KHDT_NAM_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataSet Fdt_NS_DT_KHDT_NAM_CT(string b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_DT_KHDT_NAM_CT");
        return b_ds;
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_KHDT_NAM_NH(ref string b_so_id, DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            se.se_nsd b_se = new se.se_nsd();
            OracleConnection b_cnn = dbora.Fcn_KNOI();
            try
            {
                OracleCommand b_lenh = new OracleCommand();
                b_lenh.Connection = b_cnn;
                DataRow b_dr = b_dt.Rows[0];
                dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["is_yeucau"]) + "," + chuyen.OBJ_C(b_dr["nhom_nd"])
                    + "," + chuyen.OBJ_C(b_dr["kdt"]) + "," + chuyen.OBJ_C(b_dr["nhucau"]) + "," + chuyen.OBJ_C(b_dr["hthuc"]) + "," + chuyen.OBJ_C(b_dr["tonglop"])
                    + "," + chuyen.OBJ_C(b_dr["ddiem"]) + "," + chuyen.OBJ_C(b_dr["dtuong"]) + "," + chuyen.OBJ_N(b_dr["thang"])
                    + "," + chuyen.OBJ_C(b_dr["thoiluong"]) + "," + chuyen.OBJ_N(b_dr["so_hv"]) + "," + chuyen.OBJ_C(b_dr["so_hv_lop"])
                    + "," + chuyen.OBJ_C(b_dr["cphi"]) + "," + chuyen.OBJ_C(b_dr["cphi_lop"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KHDT_NAM_NH(" + b_se.tso + c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                    b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
                }
                finally { b_lenh.Parameters.Clear(); }
            }
            finally { b_cnn.Close(); }
        }
    }
    public static void PNS_DT_KHDT_NAM_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_DT_KHDT_NAM_XOA");
    }
    /// <summary>Trả dữ liệu</summary>
    public static object[] Fdt_NS_DT_KHDT_NAM_KDT_NHUCAU(string b_kdt, string b_nam, string b_thang)
    {
        return dbora.Faobj_LKE(new object[] { b_kdt, chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang) }, "R", "PNS_DT_KHDT_NAM_KDT_NHUCAU");
    }
    public static object[] Fdt_NS_DT_KHDT_NAM_KDT(string b_ma_kdt)
    {
        return dbora.Faobj_LKE(b_ma_kdt, "R", "PNS_DT_KHDT_NAM_KTRA");
    }
    #endregion KẾ HOẠCH ĐÀO TẠO NĂM

    #region DANH MỤC CHỨNG CHỈ ĐÀO TẠO
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_MA_CCDTAO_LKE(string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_tu, b_den }, "NR", "PNS_DT_DXUAT_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_MA_CCDTAO_MA(string b_phong, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, b_ma, b_trangkt }, "NNR", "PNS_DT_DXUAT_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_MA_CCDTAO_CT(string b_phong, string b_ma, string b_lan)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_ma, chuyen.OBJ_I(b_lan) }, "PNS_DT_DXUAT_CT");
    }

    /// <summary>Nhập nội dung thông tin</summary>
    public static DataTable P_NS_DT_MA_CCDTAO_NH(DataTable b_dt)
    {
        DataTable b_kq = null;
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            b_kq = dbora.Fdt_LKE_S(new object[] {b_dr["phong"],b_dr["kynang"],b_dr["lan"], b_dr["ma"],chuyen.OBJ_S(b_dr["ngayd"]),
                b_dr["ten"], b_dr["muctieu"], b_dr["noidung"], b_dr["thoiluong"],chuyen.OBJ_S(b_dr["thoigian"]), b_dr["gvien"], b_dr["dvtochuc"],
                b_dr["diadiem"],b_dr["chiphi"],b_dr["soluong"],"",b_dr["tinhtrang"] }, "PNS_DT_DXUAT_NH");
        }
        return b_kq;
    }

    public static void PNS_DT_MA_CCDTAO_XOA(string b_phong, string b_ma, string b_lan)
    {
        dbora.P_GOIHAM(new object[] { b_phong, b_ma, b_lan }, "PNS_DT_DXUAT_XOA");
    }
    #endregion DANH MỤC CHỨNG CHỈ ĐÀO TẠO

    #region DANH MỤC LĨNH VỰC CHA
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_MA_LVCHA_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_LVCHA_LKE_ALL");
    }
    public static object[] Fdt_NS_DT_MA_LVCHA_LKE(string b_luuday, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_tu_n, b_den_n }, "NR", "PNS_DT_MA_LVCHA_LKE");
    }
    public static object[] Fdt_NS_DT_MA_LVCHA_LKE_A()
    {
        return dbora.Faobj_LKE("NR", "PNS_DT_MA_LVCHA_LKE_A");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_LVCHA_MA(string b_luuday, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_ma, b_trangkt }, "NNR", "PNS_DT_MA_LVCHA_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_DT_MA_LVCHA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_LVCHA_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_LVCHA_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["mota"] }, "PNS_DT_MA_LVCHA_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_LVCHA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_LVCHA_XOA");
    }
    public static DataTable Fdt_NS_DT_MA_LVCHA_P_IN()
    {
        //DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE("PNS_DT_MA_LVCHA_IN");
    }
    #endregion DANH MỤC LĨNH VỰC CHA

    #region DANH MỤC LĨNH VỰC CON
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable FDT_NS_DT_MA_LVCON_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_LVCON_LKE_ALL");
    }
    public static object[] FDT_NS_DT_MA_LVCON_LKE(string b_ma_cha, string b_luuday, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_cha, b_luuday, b_tu_n, b_den_n }, "NR", "PNS_DT_MA_LVCON_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] FDT_NS_DT_MA_LVCON_MA(string b_luuday, string b_ma_cha, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_luuday, b_ma_cha, b_ma, b_trangkt }, "NNR", "PNS_DT_MA_LVCON_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_DT_MA_LVCON_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_LVCON_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_LVCON_NH(ref double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            string b_c = "," + chuyen.OBJ_C(dr["MA_CHA"]) + "," + chuyen.OBJ_C(dr["MA"]) + "," + chuyen.OBJ_C(dr["TEN"]);
            b_c = b_c + "," + chuyen.OBJ_C(dr["trangthai"]) + "," + chuyen.OBJ_C(dr["gchu"]);
            b_c = b_c + ",:b_so_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_LVCON_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }

        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_LVCON_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_DT_MA_LVCON_XOA");
    }
    public static DataTable Fdt_NS_DT_MA_LVCHA_LKE_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_LVCHA_LKE_DR");
    }
    #endregion DANH MỤC LĨNH VỰC CON

    #region DANH MỤC KHÓA ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_KDTAO_LKE(DataTable b_dt_tk, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_dr["nam_tk"]), b_dr["kdt_tk"], b_tu, b_den }, "NR", "PNS_DT_MA_KDTAO_LKE");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_KDTAO_LKE_ALL");
    }
    public static object[] Fdt_NS_DT_MA_KDTAO_LKE_GRCT(string b_nhom_nluc, string b_nluc)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom_nluc, b_nluc }, "R", "pns_dt_ma_kdtao_lke_grct");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_PBNS_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_KDTAO_PBNS_DR");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_KDTAO_MA(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DT_MA_KDTAO_MA");
    }
    // Chi tiet so lieu
    public static DataSet Fdt_NS_DT_MA_KDTAO_CT(double b_so_id)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_so_id }, 3, "PNS_DT_MA_KDTAO_CT");
        return b_ds;
    }
    public static void P_NS_DT_MA_KDTAO_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_cd, DataTable b_dt_dv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            object[] a_cd, a_dvi;
            if (b_dt_cd.Rows.Count > 0)
            {
                a_cd = bang.Fobj_COL_MANG(b_dt_cd, "ma");
            }
            else
            {
                a_cd = new object[] { "" };
            }
            if (b_dt_dv.Rows.Count > 0)
            {
                a_dvi = bang.Fobj_COL_MANG(b_dt_dv, "ma");
            }
            else
            {
                a_dvi = new object[] { "" };
            }
            //object[] a_ncd = bang.Fobj_COL_MANG(b_dt_ncd, "ma");
            //object[] a_cd = bang.Fobj_COL_MANG(b_dt_cd, "ma");
            //object[] a_dvi = bang.Fobj_COL_MANG(b_dt_dv, "ma");
            //dbora.P_THEM_PAR(ref b_lenh, "a_ncd", 'S', a_ncd);
            dbora.P_THEM_PAR(ref b_lenh, "a_cd", 'S', a_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_dvi", 'S', a_dvi);
            string b_c = ",:b_so_id," + chuyen.OBJ_N(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["ma"]) + "," + chuyen.OBJ_C(b_dr["ten"])
                + "," + chuyen.OBJ_C(b_dr["NND"]) + "," + chuyen.OBJ_C(b_dr["NND_DV"]) + "," + chuyen.OBJ_C(b_dr["HTHUC"])
                + "," + chuyen.OBJ_C(b_dr["tluong"]) + "," + chuyen.OBJ_C(b_dr["ndung"]) + "," + chuyen.OBJ_C(b_dr["trangthai"])
                + "," + chuyen.OBJ_C(b_dr["mota"]) + "," + chuyen.OBJ_C(b_dr["mucdich"]) + "," + chuyen.OBJ_C(b_dr["ncd"]) + ",:a_cd,:a_dvi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_KDTAO_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //Xoa
    public static void PNS_DT_MA_KDTAO_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DT_MA_KDTAO_XOA");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_KDTAO_DR");
    }
    public static DataTable Fdt_NS_DT_MA_LOP_HOC_DR(string b_nam, string b_khoa_dt)
    {
        return dbora.Fdt_LKE_S(new object[] {chuyen.CSO_SO(b_nam), b_khoa_dt }, "PNS_DT_MA_LOP_HOC_DR");
    }
    public static DataTable Fdt_NS_DT_MA_LOP_HOC_CT(string b_lop_dt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_lop_dt }, "PNS_DT_MA_LOP_HOC_CT");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_NAM_DR(string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam }, "PNS_DT_MA_KDTAO_NAM_DR");
    }
    public static DataTable Fdt_NS_HDNS_MA_PLNV_DR()
    {
        return dbora.Fdt_LKE("PNS_HDNS_MA_PLNV_DR");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_NAM()
    {
        return dbora.Fdt_LKE("pns_dt_ma_kdt");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_DR(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_DT_MA_KDT_DR");
    }
    public static DataTable Fdt_NS_DT_MA_KDTAO_EXCEL(double b_nam, string b_kdt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_kdt }, "PNS_DT_MA_KDTAO_EXCEL");
    }
    #endregion DANH MỤC KHÓA ĐÀO TẠO

    #region CHỨNG CHỈ ĐÀO TẠO
    public static object[] Fdt_NS_DT_MA_CCHI_LKE(DataTable b_dt_tk, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_dr["LVCHA_TK"], b_dr["hthuc_thi_tk"], b_tu, b_den }, "NR", "PNS_DT_MA_CCHI_LKE");
    }
    /// <summary>Liet kê excel</summary>
    public static DataTable Fdt_NS_DT_MA_CCHI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CCHI_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_MA_CCHI_MA(DataTable b_dt_tk, string b_ma, double b_trangkt)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_dr["LVCHA_TK"], b_dr["hthuc_thi_tk"], b_ma, b_trangkt }, "NNR", "PNS_DT_MA_CCHI_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_DT_MA_CCHI_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_CCHI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CCHI_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["lvcha"], b_dr["lvcon"], b_dr["dvi_cap"], b_dr["dvi_tc"],
                b_dr["chiphi"], b_dr["link_cc"], b_dr["thoihan"], b_dr["dkien"], b_dr["lich_thi"], b_dr["hthuc_thi"], b_dr["dtuong"],
                b_dr["trangthai"], b_dr["mota"] }, "PNS_DT_MA_CCHI_NH");
        }
    }
    public static void PNS_DT_MA_CCHI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_CCHI_XOA");
    }
    public static DataTable Fdt_NS_DT_MA_CCHI_LVCHA_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CCHI_LVCHA");
    }
    public static DataTable Fdt_NS_DT_MA_LVCON_DR(string b_lvcha)
    {
        return dbora.Fdt_LKE_S(b_lvcha, "PNS_DT_MA_LVCON_DR");
    }
    #endregion CHỨNG CHỈ ĐÀO TẠO

    #region DANH MỤC ĐỐI TÁC ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_DTAC_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_MA_DTAC_LKE");
    }
    public static DataTable Fdt_NS_DT_MA_DTAC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_DTAC_LKE_ALL");
    }
    public static DataTable Fdt_NS_DT_MA_DTAC_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_DTAC_DR");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_DTAC_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_DTAC_MA");
    }
    // Chi tiet so lieu
    public static DataSet Fdt_NS_DT_MA_DTAC_CT(string b_ma)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { b_ma }, 3, "PNS_DT_MA_DTAC_CT");
        return b_ds;
    }
    // Nhap so lieu
    public static void P_NS_DT_MA_DTAC_NH(DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_lvcha)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_hten = bang.Fobj_COL_MANG(b_dt_ct, "HTEN");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "CDANH");
            object[] a_sdt = bang.Fobj_COL_MANG(b_dt_ct, "SDT");
            object[] a_email = bang.Fobj_COL_MANG(b_dt_ct, "EMAIL");

            dbora.P_THEM_PAR(ref b_lenh, "a_hten", 'U', a_hten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_sdt", 'S', a_sdt);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            //
            object[] a_ma_gv = bang.Fobj_COL_MANG(b_dt_lvcha, "MA_GV");
            object[] a_hoten = bang.Fobj_COL_MANG(b_dt_lvcha, "HOTEN");
            object[] a_nsinh = bang.Fobj_COL_MANG(b_dt_lvcha, "NSINH");
            object[] a_lvuc = bang.Fobj_COL_MANG(b_dt_lvcha, "LVUC");
            object[] a_knghiem = bang.Fobj_COL_MANG(b_dt_lvcha, "KNGHIEM");
            object[] a_mota = bang.Fobj_COL_MANG(b_dt_lvcha, "MOTA");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_gv", 'S', a_ma_gv);
            dbora.P_THEM_PAR(ref b_lenh, "a_hoten", 'U', a_hoten);
            dbora.P_THEM_PAR(ref b_lenh, "a_nsinh", 'N', a_nsinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_lvuc", 'U', a_lvuc);
            dbora.P_THEM_PAR(ref b_lenh, "a_knghiem", 'U', a_knghiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_mota", 'U', a_mota);

            string b_c = "," + chuyen.OBJ_C(dr["MA"]) + "," + chuyen.OBJ_C(dr["TEN"]) + "," + chuyen.OBJ_C(dr["dthoai"]);
            b_c = b_c + "," + chuyen.OBJ_C(dr["website"]) + "," + chuyen.OBJ_C(dr["fax"]) + "," + chuyen.OBJ_C(dr["msthue"]);
            b_c = b_c + "," + chuyen.OBJ_C(dr["so_gp"]) + "," + chuyen.OBJ_C(dr["dchi"]);
            b_c = b_c + "," + chuyen.OBJ_C(dr["mota"]) + "," + chuyen.OBJ_C(dr["lv_dtao"]);
            b_c = b_c + ",:a_hten,:a_cdanh,:a_sdt,:a_email,:a_ma_gv,:a_hoten,:a_nsinh,:lvuc,:a_knghiem,:a_mota";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_DTAC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //Xoa
    public static void PNS_DT_MA_DTAC_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_DTAC_XOA");
    }
    /// <summary>Trả dữ liệu</summary>
    public static object[] Fdt_NS_DT_MA_DTAC_LVDT(string b_dtac)
    {
        return dbora.Faobj_LKE(new object[] { b_dtac }, "R", "PNS_DT_MA_DTAC_LVDT");
    }
    #endregion DANH MỤC ĐỐI TÁC ĐÀO TẠO

    #region DANH MỤC GIÁO VIÊN ĐÀO TẠO BÊN NGOÀI
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_MA_GV_NGOAI_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_MA_GV_NGOAI_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_MA_GV_NGOAI_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_GV_NGOAI_EXCEL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_MA_GV_NGOAI_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_so_id), b_trangkt }, "NNR", "PNS_DT_MA_GV_NGOAI_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static object[] Fdt_NS_DT_MA_GV_NGOAI_CT(string b_so_id)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_so_id) }, "RR", "PNS_DT_MA_GV_NGOAI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_GV_NGOAI_NH(ref string b_so_id, DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            se.se_nsd b_se = new se.se_nsd();
            OracleConnection b_cnn = dbora.Fcn_KNOI();
            try
            {
                OracleCommand b_lenh = new OracleCommand();
                b_lenh.Connection = b_cnn;
                DataRow b_dr = b_dt.Rows[0];
                dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
                string c = ",:b_so_id," + chuyen.OBJ_C(b_dr["dtac"]);
                c += "," + chuyen.OBJ_C(b_dr["gvien"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["dvi_ctac"]);
                c += "," + chuyen.OBJ_N(b_dr["ngsinh"]) + "," + chuyen.OBJ_C(b_dr["sdt"]) + "," + chuyen.OBJ_C(b_dr["email"]);
                c += "," + chuyen.OBJ_C(b_dr["knghiem"]) + "," + chuyen.OBJ_C(b_dr["lvuc"]) + "," + chuyen.OBJ_C(b_dr["dgia"]);
                c += "," + chuyen.OBJ_C(b_dr["mota"]);
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_GV_NGOAI_NH(" + b_se.tso + c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                    b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
                }
                finally { b_lenh.Parameters.Clear(); }
            }
            finally { b_cnn.Close(); }
        }
    }
    public static void PNS_DT_MA_GV_NGOAI_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { chuyen.CSO_SO(b_so_id) }, "PNS_DT_MA_GV_NGOAI_XOA");
    }
    // Lấy danh sách các đối tác đào tạo
    public static DataTable Fdt_PNS_DT_DTAC_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_DTAC_DR");
    }
    #endregion DANH MỤC GIÁO VIÊN ĐÀO TẠO BÊN NGOÀI

    #region DANH MỤC GIÁO VIÊN ĐÀO TẠO NỘI BỘ
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_MA_GV_NOI_LKE(double b_tu, double b_den)
    {
        //DataRow b_dr = b_dt_tk.Rows[0];
        object[] a_obj = new object[] { b_tu, b_den };
        return dbora.Faobj_LKE(a_obj, "NR", "PNS_DT_MA_GV_NOI_LKE");
    }
    public static object[] Fdt_NS_DT_MA_GV_NOI_LKE_TK(string b_tt, string b_cap_gv, string b_loai_gv, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tt, b_cap_gv, b_loai_gv, b_tu, b_den }, "NR", "pns_dt_ma_gv_noi_lke_tk");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_GV_NOI_LKE_ALL(string b_tt, string b_cap_gv, string b_loai_gv)
    {
        return dbora.Faobj_LKE(new object[] { b_tt, b_cap_gv, b_loai_gv }, "R", "PNS_DT_MA_GV_NOI_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_MA_GV_NOI_MA(DataTable b_dt_tk, string b_ma, double b_trangkt)
    {
        DataRow b_dr = b_dt_tk.Rows[0];
        object[] a_obj = new object[] { b_dr["tt_tk"], b_dr["cap_gvien_tk"], b_dr["loai_gvien_tk"], b_ma, b_trangkt };
        return dbora.Faobj_LKE(a_obj, "NNR", "PNS_DT_MA_GV_NOI_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_NS_DT_MA_GV_NOI_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_DT_MA_GV_NOI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_GV_NOI_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["so_the"], b_dr["kdtao"], b_dr["knghiem"], b_dr["mota"], b_dr["email"] }, "PNS_DT_MA_GV_NOI_NH");
        }
    }
    public static void PNS_DT_MA_GV_NOI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma }, "PNS_DT_MA_GV_NOI_XOA");
    }
    #endregion DANH MỤC GIÁO VIÊN ĐÀO TẠO NỘI BỘ

    #region DANH MỤC CAM KẾT ĐÀO TẠO
    /// <summary>Liet ke toàn bộ</summary>
    public static object[] Fdt_NS_DT_MA_CKET_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_MA_CKET_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_MA_CKET_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CKET_LKE_ALL");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_MA_CKET_MA(string b_soid, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_soid, b_trangkt }, "NNR", "PNS_DT_MA_CKET_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static object[] Fdt_NS_DT_MA_CKET_CT(double b_soid)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.OBJ_N(b_soid) }, "R", "PNS_DT_MA_CKET_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CKET_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["cp_tu"]) + "," + chuyen.OBJ_S(b_dr["cp_den"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["thgian_cket"]) + "," + chuyen.OBJ_S(b_dr["ng_hluc"]);
            b_c = b_c + "," + chuyen.OBJ_S(b_dr["ng_hhluc"]) + "," + chuyen.OBJ_C(b_dr["mota"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_CKET_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
        finally { b_cnn.Close(); }
    }
    public static void PNS_DT_MA_CKET_XOA(double b_soid)
    {
        dbora.P_GOIHAM(new object[] { b_soid }, "PNS_DT_MA_CKET_XOA");
    }
    #endregion DANH MỤC CAM KẾT ĐÀO TẠO

    #region DANH MỤC ĐÀO TẠO CHUẨN THEO CHỨC DANH
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_DTC_CDANH_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_MA_DTC_CDANH_LKE");
    }
    public static DataTable Fdt_NS_DT_MA_DTC_CDANH_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_DTC_CDANH_LKE_ALL");
    }
    public static object[] Fdt_NS_DT_MA_DTC_CDANH_LKE_GRCT(string b_nhom_nluc, string b_nluc)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom_nluc, b_nluc }, "R", "pns_dt_ma_kdtao_lke_grct");
    }

    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_DTC_CDANH_MA(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DT_MA_DTC_CDANH_MA");
    }

    // Chi tiet so lieu
    public static DataSet Fdt_NS_DT_MA_DTC_CDANH_CT(string b_ma)
    {
        DataSet b_ds = dbora.Fds_LKE(new object[] { chuyen.CSO_SO(b_ma) }, 3, "PNS_DT_MA_DTC_CDANH_CT");
        return b_ds;
    }
    public static void P_NS_DT_MA_DTC_CDANH_NH(ref double b_so_id, DataTable b_dt, DataTable b_dt_ct, DataTable b_dt_cd)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow dr = b_dt.Rows[0];
            object[] a_nluc = bang.Fobj_COL_MANG(b_dt_ct, "nluc");
            object[] a_muc_nluc = bang.Fobj_COL_MANG(b_dt_ct, "muc_nluc");
            object[] a_ma_cd = bang.Fobj_COL_MANG(b_dt_cd, "ma_cd");
            dbora.P_THEM_PAR(ref b_lenh, "a_nluc", 'N', a_nluc);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_nluc", 'N', a_muc_nluc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd", 'S', a_ma_cd);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            string b_c = "," + chuyen.OBJ_C(dr["KDT"]) + "," + chuyen.OBJ_C(dr["trangthai"]);
            b_c = b_c + "," + chuyen.OBJ_C(dr["mota"]) + ",:a_nluc,:a_muc_nluc,:a_ma_cd,:b_so_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_DTC_CDANH_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
            }
            catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
        finally { b_cnn.Close(); }
    }
    //Xoa
    public static void PNS_DT_MA_DTC_CDANH_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_DT_MA_DTC_CDANH_XOA");
    }
    #endregion DANH MỤC ĐÀO TẠO CHUẨN THEO CHỨC DANH

    #region NHÓM DANH MỤC DÙNG CHUNG ĐÀO TẠO
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_CHUNG_NHOM_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_CHUNG_NHOM_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_CHUNG_NHOM_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_CHUNG_NHOM_MA");
    }
    public static DataTable Fdt_NS_DT_MA_CHUNG_NHOM_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_CHUNG_NHOM_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CHUNG_NHOM_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["trangthai"], b_dr["mota"] }, "PNS_DT_MA_CHUNG_NHOM_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DT_MA_CHUNG_NHOM_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_CHUNG_NHOM_XOA");
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG ĐÀO TẠO

    #region DANH MỤC DÙNG CHUNG ĐÀO TẠO
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_NS_DT_MA_CHUNG_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CHUNG_NHOM_DR");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_DT_MA_CHUNG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_CHUNG_LKE");
    }
    /// <summary>Liệt kê dr</summary>
    public static DataTable Fdt_PNS_DT_MA_CHUNG_DR(string b_nhom_ma)
    {
        return dbora.Fdt_LKE_S(b_nhom_ma, "PNS_DT_MA_CHUNG_DR");
    }
    public static DataTable Fdt_PNS_DT_MA_CHUNG_DR_A(string b_nhom_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_nhom_ma, "PNS_DT_MA_CHUNG_DR");
        DataRow b_dr = b_dt.NewRow();
        b_dr["Ten"] = "---";
        b_dt.Rows.InsertAt(b_dr, 0);
        return b_dt;
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_CHUNG_MA(string b_ma, string b_loai_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_loai_ma, b_trangkt }, "NNR", "PNS_DT_MA_CHUNG_MA");
    }
    public static object[] Fdt_NS_DT_MA_CHUNG_CT(string b_nhom_ma, string b_ma)
    {
        return dbora.Faobj_LKE(new object[] { b_nhom_ma, b_ma }, "R", "PNS_DT_MA_CHUNG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CHUNG_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["nhom_ma"], b_dr["ma"], b_dr["ten"], b_dr["thamso1"], b_dr["thamso2"], b_dr["trangthai"], b_dr["mota"] }, "PNS_DT_MA_CHUNG_NH");
    }
    ///<summary> Xóa </summary>
    public static void P_NS_DT_MA_CHUNG_XOA(string b_ma, string b_loai_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma, b_loai_ma }, "PNS_DT_MA_CHUNG_XOA");
    }
    #endregion DANH MỤC DÙNG CHUNG ĐÀO TẠO

    #region DANH MỤC THAM SỐ HỆ THỐNG
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_MA_TSO_HTHONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_TSO_HTHONG_LKE_ALL");
    }
    public static object[] Fdt_NS_DT_MA_TSO_HTHONG_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_TSO_HTHONG_LKE");
    }

    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_MA_TSO_HTHONG_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_TSO_HTHONG_MA");
    }
    /// <summary>Liệt kê chi tiết</summary>
    public static DataTable Fdt_NS_DT_MA_TSO_HTHONG_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_TSO_HTHONG_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_TSO_HTHONG_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["mota"] }, "PNS_DT_MA_TSO_HTHONG_NH");
        }
    }
    /// <summary>Xóa thông tin</summary>
    public static void P_NS_DT_MA_TSO_HTHONG_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_TSO_HTHONG_XOA");
    }

    #endregion DANH MỤC THAM SỐ HỆ THỐNG

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CHA
    public static DataTable Fdt_NS_DT_MA_CP_CHA_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CP_CHA_LKE_ALL");
    }

    public static object[] Fdt_NS_DT_MA_CP_CHA_LKE(string b_tt, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt, b_tu_n, b_den_n }, "NR", "PNS_DT_MA_CP_CHA_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_CP_CHA_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_CP_CHA_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CP_CHA_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["mota"] }, "PNS_DT_MA_CP_CHA_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_CP_CHA_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_CP_CHA_XOA");
    }
    public static DataTable Fdt_NS_DT_MA_CP_CHA_P_IN()
    {
        //DataRow b_dr = b_dt.Rows[0];
        return dbora.Fdt_LKE("PNS_DT_MA_CP_CHA_IN");
    }
    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CHA

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CON
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_MA_CP_CON_LKE_ALL(string b_ma_cha)
    {
        return dbora.Fdt_LKE_S(b_ma_cha, "PNS_DT_MA_CP_CON_xem");
    }

    public static object[] Fdt_NS_DT_MA_CP_CON_LKE(string b_ma_cha, string b_tt, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_cha, b_tt, b_tu_n, b_den_n }, "NR", "PNS_DT_MA_CP_CON_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_CP_CON_MA(string b_ma_cha, string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_cha, b_ma, b_trangkt }, "NNR", "PNS_DT_MA_CP_CON_ma");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CP_CON_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma_cha"], b_dr["ma"], b_dr["ten"], b_dr["gchu"], b_dr["tt"] }, "PNS_DT_MA_CP_CON_nh");
        }
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_CP_CON_XOA(string b_ma_cha, string b_ma)
    {
        dbora.P_GOIHAM(new object[] { b_ma_cha, b_ma }, "PNS_DT_MA_CP_CON_xoa");
    }
    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CON

    #region ĐÁNH GIÁ KHÓA ĐÀO TẠO


    /// <summary>Liệt kê số liệu</summary>
    public static object[] Fdt_NS_DT_NGV_DG_KDT_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_DG_KDT_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_NGV_DG_KDT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_DG_KDT_LKE_ALL");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_NGV_DG_KDT_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DT_DG_KDT_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_NS_DT_NGV_DG_KDT_CT(string b_so_id)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_DT_DG_KDT_CT");
        return b_dt;
    }
    // Nhap so lieu
    public static void P_NS_DT_NGV_DG_KDT_NH(ref string b_so_id, DataTable b_dt)
    {

        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');
            string b_c = "," + chuyen.OBJ_C(b_so_id) + "," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["thang"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ten"]) + "," + chuyen.OBJ_C(b_dr["lop"]) + "," + chuyen.OBJ_C(b_dr["diemthich"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["gop_y"]) + "," + chuyen.OBJ_C(b_dr["nd_dg"]) + "," + chuyen.OBJ_C(b_dr["nd_nx"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["gv_dg"]) + "," + chuyen.OBJ_C(b_dr["gv_nx"]) + "," + chuyen.OBJ_C(b_dr["tc_dg"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["tc_nx"]) + ",:b_so_id_out";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DG_KDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_soid_out"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //Xoa
    public static void PNS_DT_NGV_DG_KDT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DT_DG_KDT_XOA");
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    /// <summary>Liệt kê toàn bộ số liệu</summary>
    /// 
    public static object[] Fdt_NS_DT_KH_CT_LKE(double b_tu_n, double b_den_n, string b_nam, string b_thang, string b_tt_lop)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_tt_lop }, "NR", "PNS_DT_KH_CT_lke");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_KH_CT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_KH_CT_LKE_ALL");
    }
    /// <summary>Liệt kê danh sách theo trạng thái phê duyệt</summary>
    public static object[] Fdt_NS_DT_KH_CT_PD_LKE(double b_tu_n, double b_den_n, double b_nam, double b_thang, double b_tt_pd)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n, b_nam, b_thang, b_tt_pd }, "NR", "PNS_DT_KH_CT_PD_LKE");
    }
    public static object[] Fdt_NS_DT_KH_CT_LKE_MA(string b_nam, string b_thang, string b_hinhthuc, string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_hinhthuc, b_so_id, b_trangkt }, "NNR", "pns_dt_kh_ct_ma");
    }
    public static DataSet Fds_NS_DT_KH_CT_CT(double b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 3, "pns_dt_kh_ct_ct");
    }
    public static DataTable Fds_ns_dt_kh_ct_cphi_CT(double b_so_id_kh)
    {
        return dbora.Fdt_LKE_S(b_so_id_kh, "pns_dt_kh_ct_cphi_ct");
    }
    public static void Fs_NS_DT_KH_CT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct_cp, DataTable b_dt_ct_gv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);

            // chi phi dao tao
            object[] a_ma_cp = bang.Fobj_COL_MANG(b_dt_ct_cp, "ma_cp");
            object[] a_loai_cp = bang.Fobj_COL_MANG(b_dt_ct_cp, "loai_cp");
            object[] a_stien = bang.Fobj_COL_MANG(b_dt_ct_cp, "stien");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cp", 'U', a_ma_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_cp", 'U', a_loai_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_stien", 'N', a_stien);

            // thong tin giang vien
            object[] a_loai_gv = bang.Fobj_COL_MANG(b_dt_ct_gv, "loai_gv");
            object[] a_ma_gv = bang.Fobj_COL_MANG(b_dt_ct_gv, "ma_gv");
            object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt_ct_gv, "ten_gv");
            object[] a_knghiem = bang.Fobj_COL_MANG(b_dt_ct_gv, "knghiem");

            dbora.P_THEM_PAR(ref b_lenh, "a_loai_gv", 'U', a_loai_gv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_gv", 'S', a_ma_gv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_knghiem", 'U', a_knghiem);
            //
            string b_c = ",:b_so_id,"
                + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["kh_nam"]) + "," + chuyen.OBJ_C(b_dr["nhom_nd"]) + ","
                + chuyen.OBJ_C(b_dr["ma_kdt"]) + "," + chuyen.OBJ_C(b_dr["ma_kdt_nhucau"]) + "," + chuyen.OBJ_C(b_dr["ma_lop"]) + ","
                + chuyen.OBJ_C(b_dr["ten_lop"]) + ","
                + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_S(b_dr["ngay_d"]) + "," + chuyen.OBJ_S(b_dr["ngay_c"]) + ","
                + chuyen.OBJ_C(b_dr["thluong"]) + "," + chuyen.OBJ_C(b_dr["ddiem"]) + "," + chuyen.OBJ_S(b_dr["sl_hvien"]) + ","
                + chuyen.OBJ_C(b_dr["doitac"]) + "," + chuyen.OBJ_S(b_dr["tong_cp"]) + "," + chuyen.OBJ_S(b_dr["cp_hvien"]) + ","
                + ":a_ma_cp,:a_loai_cp,:a_stien,:a_loai_gv,:a_ma_gv,:a_ho_ten,:a_knghiem";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_dt_kh_ct_nh(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = b_lenh.Parameters["b_so_id"].Value.ToString();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_ns_dt_kh_ct_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "pns_dt_kh_ct_xoa");
    }
    public static DataTable Fds_ns_dt_kh_ct_kdt(double b_nam, double b_thang, string b_ma, double b_kh_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_ma, b_kh_nam }, "pns_dt_kh_ct_kdt");
    }
    public static DataTable Fds_ns_dt_kh_ct_kdt_lke(double b_nam, double b_thang, double b_kh_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_kh_nam }, "pns_dt_kh_ct_kdt_lke");
    }
    public static object[] Fdt_NS_DT_KH_CT_LKE_GVIEN(string b_ma_doitac)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_doitac }, "R", "PNS_DT_KH_CT_LKE_GVIEN");
    }

    public static object[] Fdt_NS_KH_NAM_CT(string b_nam, string b_thang, string b_kdt)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_kdt }, "R", "PNS_KH_NAM_CT");
    }

    #endregion KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region QUẢN LÝ DỮ LIỆU ĐÀO TẠO
    public static object[] PNS_DT_NGV_QLDL_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_NGV_QLDL_LKE");
    }
    ///<summary> kiem tra khi chuyen hang </summary>
    public static object[] Fdt_NS_DT_NGV_QLDL_MA(string b_soqd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_soqd, b_trangkt }, "NNR", "PNS_DT_NGV_QLDL_MA");
    }

    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable PNS_DT_NGV_QLDL_CT(string b_soqd)
    {
        return dbora.Fdt_LKE_S(b_soqd, "PNS_DT_NGV_QLDL_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void PNS_DT_NGV_QLDL_NH(DataTable b_dt, DataTable b_dt_ct)
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
            object[] a_lydo = bang.Fobj_COL_MANG(b_dt_ct, "lydo");
            object[] a_mucthuong = bang.Fobj_COL_MANG(b_dt_ct, "mucthuong");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'S', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_lydo", 'U', a_lydo);
            dbora.P_THEM_PAR(ref b_lenh, "a_mucthuong", 'N', a_mucthuong);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);

            string b_c = "," + chuyen.OBJ_C(b_dr["soqd"]) + "," + chuyen.OBJ_S(b_dr["ngayqd"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + ","
                + chuyen.OBJ_C(b_dr["cap_ktkl"]) + "," + chuyen.OBJ_C(b_dr["noi_ktkl"]) + "," + chuyen.OBJ_C(b_dr["nguoiky"]);
            b_c = b_c + ",:a_so_the,:a_ten,:a_phong,:a_lydo,:a_mucthuong,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_NGV_QLDL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void PNS_DT_NGV_QLDL_XOA(string b_soqd, string b_ngayqd)
    {
        dbora.P_GOIHAM(new object[] { b_soqd, chuyen.CNG_SO(b_ngayqd) }, "PNS_DT_NGV_QLDL_XOA");
    }
    #endregion QUẢN LÝ DỮ LIỆU ĐÀO TẠO

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO
    public static DataTable Fdt_NS_DT_MA_CP_LKE()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CP_LKE_ALL");
    }

    public static object[] Fdt_NS_DT_MA_CP_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_CP_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_CP_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_CP_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_CP_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["ma_ct"], b_dr["mota"] }, "PNS_DT_MA_CP_NH");
        }
    }
    public static DataTable Fdt_NS_DT_MA_CP_MA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_CP_MA_CT");
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_CP_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_CP_XOA");
    }

    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO

    #region DANH MỤC MÔN HỌC ĐÀO TẠO
    public static DataTable Fdt_NS_DT_MA_MON_LKE()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_MON_LKE_ALL");
    }

    public static object[] Fdt_NS_DT_MA_MON_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_MON_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_MON_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_MON_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_MON_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tt"], b_dr["mota"] }, "PNS_DT_MA_MON_NH");
        }
    }
    public static DataTable Fdt_NS_DT_MA_MON_MA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_MON_MA_CT");
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_MON_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_MON_XOA");
    }

    #endregion DANH MỤC MÔN HỌC ĐÀO TẠO

    #region DANH SÁCH MÔN THI THUỘC KHÓA ĐÀO TẠO

    public static DataTable Fdt_NS_DT_KH_CT_MON_LKE(double b_so_id_kh)
    {
        return dbora.Fdt_LKE_S(b_so_id_kh, "PNS_DT_KH_CT_MON_LKE_ALL");
    }

    public static void P_NS_DT_KH_CT_MON_XOA(double b_so_id_kh)
    {
        dbora.P_GOIHAM(b_so_id_kh, "PNS_DT_KH_CT_MON_XOA");
    }

    public static string P_NS_DT_KH_CT_MON_NH(double b_so_id_kh, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_mon, a_tr_so, a_ngay_thi;
            if (b_dt.Rows.Count > 0)
            {
                a_ma_mon = bang.Fobj_COL_MANG(b_dt, "ma");
                a_tr_so = bang.Fobj_COL_MANG(b_dt, "tr_so");
                a_ngay_thi = bang.Fobj_COL_MANG(b_dt, "ngay_thi");
            }
            else
            {
                a_ma_mon = new object[] { "" };
                a_tr_so = new object[] { -1 };
                a_ngay_thi = new object[] { -1 };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_mon", 'S', a_ma_mon);
            dbora.P_THEM_PAR(ref b_lenh, "a_tr_so", 'N', a_tr_so);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_thi", 'N', a_ngay_thi);

            string b_c = "," + b_so_id_kh + ",:a_ma_mon,:a_tr_so,:a_ngay_thi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KH_CT_MON_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return form.Fs_LOC_LOI(ex.Message );
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion DANH SÁCH MÔN THI THUỘC KHÓA ĐÀO TẠO

    #region QUẢN LÝ DỮ LIỆU ĐÀO TẠO
    /// <summary>Liệt kê số liệu</summary>
    public static object[] Fdt_NS_DT_QLDL_LKE(string b_ma_kh, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_kh, b_tu, b_den }, "NR", "PNS_DT_QLDL_LKE");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static DataTable Fdt_NS_DT_QLDL_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_QLDL_LKE_ALL");
    }
    ///<summary>liet ke sau kiem tra </summary>
    public static object[] Fdt_NS_DT_QLDL_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DT_QLDL_MA");
    }
    // Chi tiet so lieu
    public static DataTable Fdt_NS_DT_QLDL_CT(string b_so_id)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_DT_QLDL_CT");
        return b_dt;
    }
    // Nhap so lieu
    public static void P_NS_DT_QLDL_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_out", 'N');
            string b_c = "," + chuyen.OBJ_N(b_so_id) + "," + chuyen.OBJ_C(b_dr["ma_kh"]) + "," + chuyen.OBJ_C(b_dr["ten_hs"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["ma_bm"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + "," + chuyen.OBJ_C(b_dr["thoihan"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["md_qtrong"]) + "," + chuyen.OBJ_C(b_dr["ghichu"]) + ",:b_so_id_out";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_QLDL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_soid_out"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    //Xoa
    public static void PNS_DT_QLDL_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PNS_DT_QLDL_XOA");
    }
    #endregion QUẢN LÝ DỮ LIỆU ĐÀO TẠO

    #region THỜI KHÓA BIỂU KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    public static DataTable Fdt_NS_DT_KH_CT_TKB_NGAY_LKE(double b_so_id_kh)
    {
        return dbora.Fdt_LKE_S(b_so_id_kh, "PNS_DT_KH_CT_TKB_NGAY_LKE");
    }

    public static object[] Fdt_NS_DT_KH_CT_TKB_LKE(double b_so_id_kh, double b_ngay, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_kh, b_ngay, b_tu_n, b_den_n }, "NR", "PNS_DT_KH_CT_TKB_LKE");
    }

    public static object[] Fdt_NS_DT_KH_CT_TKB_MA(double b_so_id_kh, double b_ngay, string b_gio_d, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_kh, b_ngay, b_gio_d, b_trangkt }, "NNR", "PNS_DT_KH_CT_TKB_MA");
    }

    public static void P_NS_DT_KH_CT_TKB_XOA(double b_so_id_kh, double b_ngay, double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id_kh, b_ngay, b_so_id }, "PNS_DT_KH_CT_TKB_XOA");
    }

    public static double P_NS_DT_KH_CT_TKB_NH(double b_so_id, double b_so_id_kh, DataTable b_dt, out bool b_taoNgayMoi)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        b_taoNgayMoi = false;
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "b_taoNgayMoi", 'N', 'O', b_taoNgayMoi);
            string b_c = ",:b_so_id,"
                + b_so_id_kh + ","
                + chuyen.OBJ_N(b_dr["ngay"]) + ","
                + chuyen.OBJ_C(b_dr["chude"]) + ","
                + chuyen.OBJ_C(b_dr["ndung"]) + ","
                + chuyen.OBJ_N(b_dr["thluong"]) + ","
                + (b_dr["loai_gv"].ToString() == "NB" ? 1 : 0) + ","
                + chuyen.OBJ_N(b_dr["so_id_gv"]) + ","
                + chuyen.OBJ_C(b_dr["ma_lhgd"]) + ","
                + chuyen.OBJ_C(b_dr["gio_d"]) + ","
                + chuyen.OBJ_C(b_dr["gio_c"]) + ","
                + chuyen.OBJ_C(b_dr["ddiem"]) + ","
                + chuyen.OBJ_C(b_dr["note"]) + ",:b_taoNgayMoi";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_KH_CT_TKB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                    b_taoNgayMoi = chuyen.OBJ_N(b_lenh.Parameters["b_taoNgayMoi"].Value) == 0;
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_DT_KH_CT_TKB_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_DT_KH_CT_TKB_CT");
    }

    public static void P_NS_DT_KH_CT_TKB_DOI(double b_so_id_kh, double b_ngay_cu, double b_ngay_moi)
    {
        dbora.P_GOIHAM(new object[] { b_so_id_kh, b_ngay_cu, b_ngay_moi }, "PNS_DT_KH_CT_TKB_DOI");
    }

    #endregion THỜI KHÓA BIỂU KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region TRIỂN KHAI LỚP ĐÀO TẠO

    /// <summary>
    /// Thông tin chi tiết
    /// </summary>
    /// <param name="b_so_id_gd">id giám định</param>
    /// <returns></returns>
    public static DataSet Fds_NS_DT_TK_CT(double b_so_id_kh)
    {
        return dbora.Fds_LKE(new object[] { b_so_id_kh }, 2, "PNS_DT_TK_CT");
    }

    public static double Fn_NS_DT_TK_NH(double b_so_id, double b_so_id_kh, DataTable b_dt, DataTable b_dt_ct_cp)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_ma_cp, a_dvi, a_dgia, a_sluong, a_thue, a_cp_tt, a_ghichu;

            // chi phi dao tao
            if (b_dt_ct_cp.Rows.Count > 0)
            {
                a_ma_cp = bang.Fobj_COL_MANG(b_dt_ct_cp, "ma_cp");
                a_dvi = bang.Fobj_COL_MANG(b_dt_ct_cp, "dvi");
                a_dgia = bang.Fobj_COL_MANG(b_dt_ct_cp, "dgia");
                a_sluong = bang.Fobj_COL_MANG(b_dt_ct_cp, "sluong");
                a_thue = bang.Fobj_COL_MANG(b_dt_ct_cp, "thue");
                a_cp_tt = bang.Fobj_COL_MANG(b_dt_ct_cp, "cp_tt");
                a_ghichu = bang.Fobj_COL_MANG(b_dt_ct_cp, "ghichu");
            }
            else
            {
                a_ma_cp = new object[] { "" };
                a_dvi = new object[] { "" };
                a_dgia = new object[] { -1 };
                a_sluong = new object[] { -1 };
                a_thue = new object[] { -1 };
                a_cp_tt = new object[] { -1 };
                a_ghichu = new object[] { "" };
            }

            string b_lop = b_dr["lop"].ToString();
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cp", 'S', a_ma_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_dvi", 'S', a_dvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_dgia", 'N', a_dgia);
            dbora.P_THEM_PAR(ref b_lenh, "a_sluong", 'N', a_sluong);
            dbora.P_THEM_PAR(ref b_lenh, "a_thue", 'N', a_thue);
            dbora.P_THEM_PAR(ref b_lenh, "a_cp_tt", 'N', a_cp_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'S', a_ghichu);


            string b_c = ",:b_so_id," + b_so_id_kh + ","
                + chuyen.OBJ_N(b_dr["ngay_d"]) + ","
                + chuyen.OBJ_N(b_dr["ngay_c"]) + ","
                + ":a_ma_cp,:a_dvi,:a_dgia,:a_sluong,:a_thue,:a_cp_tt,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TK_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_DT_TK_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_DT_TK_XOA");
    }

    public static DataTable Fdt_NS_DT_TK_LKE_KDT(double b_nam, double b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang }, "PNS_DT_TK_LKE_KDT");
    }

    public static DataTable Fdt_NS_DT_TK_LKE_LOP(double b_nam, double b_thang, string b_ma_kdt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_ma_kdt }, "PNS_DT_TK_LKE_LOP");
    }

    public static DataTable Fdt_NS_DT_TK_LOP_CT(double b_so_id_kh)
    {
        return dbora.Fdt_LKE_S(b_so_id_kh, "PNS_DT_TK_LOP_CT");
    }

    public static object[] Fobj_NS_DT_TK_CP(double b_so_id_kh, double b_so_id_tk)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_kh, b_so_id_tk }, "NN", "PNS_DT_TK_CP");
    }

    #endregion TRIỂN KHAI LỚP ĐÀO TẠO

    #region THỜI KHÓA BIỂU TRIỂN KHAI LỚP ĐÀO TẠO

    public static DataTable Fdt_NS_DT_TK_TKB_NGAY_LKE(double b_so_id_tk)
    {
        return dbora.Fdt_LKE_S(b_so_id_tk, "PNS_DT_TK_TKB_NGAY_LKE");
    }

    public static object[] Fdt_NS_DT_TK_TKB_LKE(double b_so_id_tk, double b_ngay, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_tk, b_ngay, b_tu_n, b_den_n }, "NR", "PNS_DT_TK_TKB_LKE");
    }

    public static object[] Fdt_NS_DT_TK_TKB_MA(double b_so_id_tk, double b_ngay, string b_gio_d, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_tk, b_ngay, b_gio_d, b_trangkt }, "NNR", "PNS_DT_TK_TKB_MA");
    }

    public static void P_NS_DT_TK_TKB_XOA(double b_so_id_tk, double b_ngay, double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id_tk, b_ngay, b_so_id }, "PNS_DT_TK_TKB_XOA");
    }

    public static double P_NS_DT_TK_TKB_NH(double b_so_id, double b_so_id_tk, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);

            string b_c = ",:b_so_id,"
                + b_so_id_tk + ","
                + chuyen.OBJ_N(b_dr["ngay"]) + ","
                + chuyen.OBJ_C(b_dr["chude"]) + ","
                + chuyen.OBJ_C(b_dr["ndung"]) + ","
                + chuyen.OBJ_N(b_dr["thluong"]) + ","
                + (b_dr["loai_gv"].ToString() == "NB" ? 1 : 0) + ","
                + chuyen.OBJ_N(b_dr["so_id_gv"]) + ","
                + chuyen.OBJ_C(b_dr["lgv"]) + ","
                + chuyen.OBJ_C(b_dr["gio_d"]) + ","
                + chuyen.OBJ_C(b_dr["gio_c"]) + ","
                + chuyen.OBJ_C(b_dr["ddiem"]) + ","
                + chuyen.OBJ_C(b_dr["note"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TK_TKB_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_DT_TK_TKB_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_DT_TK_TKB_CT");
    }

    public static void P_NS_DT_TK_TKB_NGAY_COPY_KH(double b_so_id_tk)
    {
        dbora.P_GOIHAM(new object[] { b_so_id_tk }, "PNS_DT_TK_TKB_NGAY_COPY_KH");
    }

    public static void P_NS_DT_TK_TKB_DOI(double b_so_id_tk, double b_ngay_cu, double b_ngay_moi)
    {
        dbora.P_GOIHAM(new object[] { b_so_id_tk, b_ngay_cu, b_ngay_moi }, "PNS_DT_TK_TKB_DOI");
    }

    public static DataTable Fdt_NS_DT_TK_TKB_LKE_ALL(double b_so_id_tk)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(b_so_id_tk, "PNS_DT_TK_TKB_LKE_ALL");
        bang.P_SO_CNG(ref b_dt, "ngay");
        return b_dt;
    }

    #endregion THỜI KHÓA BIỂU TRIỂN KHAI LỚP ĐÀO TẠO

    #region ĐIỂM DANH LỚP ĐÀO TẠO

    public static object[] Fobj_NS_DT_TK_DD_LKE(double b_so_id_tk, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_tk, b_tu_n, b_den_n }, "NRRRR", "PNS_DT_TK_DD_LKE");
    }

    public static void Fn_NS_DT_TK_DD_NH(double b_so_id_tk, object[] a_so_id_tkb, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the, a_tt, a_tl, a_kq, a_ghichu;

            // chi phi dao tao
            if (b_dt.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
                a_tt = bang.Fobj_COL_MANG(b_dt, "tt");
                a_tl = bang.Fobj_COL_MANG(b_dt, "tl");
                a_kq = bang.Fobj_COL_MANG(b_dt, "kq");
                a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");
            }
            else
            {
                a_so_the = new object[] { "" };
                a_tt = new object[] { "" };
                a_tl = new object[] { -1 };
                a_kq = new object[] { "" };
                a_ghichu = new object[] { "" };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_tkb", 'N', a_so_id_tkb);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_tt", 'S', a_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl", 'N', a_tl);
            dbora.P_THEM_PAR(ref b_lenh, "a_kq", 'S', a_kq);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'S', a_ghichu);

            string b_c = "," + b_so_id_tk + ","
                + ":a_so_id_tkb,:a_so_the,:a_tt,:a_tl,:a_kq,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TK_DD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_DT_TK_DD_XOA(double b_so_id_tk)
    {
        dbora.P_GOIHAM(b_so_id_tk, "PNS_DT_TK_DD_XOA");
    }

    #endregion ĐIỂM DANH LỚP ĐÀO TẠO

    #region CẬP NHẬT KẾT QUẢ ĐÀO TẠO HỌC VIÊN

    public static int Fn_NS_DT_TK_MON_MAX()
    {
        object[] obj = dbora.Faobj_LKE("N", "PNS_DT_TK_MON_MAX");
        return Convert.ToInt32(obj[0].ToString());
    }

    public static object[] Fobj_NS_DT_TK_DIEM_LKE(double b_so_id_kh, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_kh, b_tu_n, b_den_n }, "NNRRRR", "PNS_DT_TK_DIEM_LKE");
    }

    public static void Fn_NS_DT_TK_DIEM_NH(double b_so_id_tk, object[] a_ma_mon, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the, a_diem_n, a_ngay_thi_n, a_dtb, a_kq, a_cp_htro, a_cp_tt;

            // điểm chi tiết + kết quả chung
            if (b_dt.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
                a_diem_n = bang.Fobj_COL_MANG(b_dt, "diem");
                a_ngay_thi_n = bang.Fobj_COL_MANG(b_dt, "ngay_thi");

                a_dtb = bang.Fobj_COL_MANG(b_dt, "dtb");
                a_kq = bang.Fobj_COL_MANG(b_dt, "kq");
                a_cp_htro = bang.Fobj_COL_MANG(b_dt, "cp_htro");
                a_cp_tt = bang.Fobj_COL_MANG(b_dt, "cp_tt");
            }
            else
            {
                a_so_the = new object[] { "" };
                a_diem_n = new object[] { "" };
                a_ngay_thi_n = new object[] { -1 };

                a_dtb = new object[] { 0 };
                a_kq = new object[] { "" };
                a_cp_htro = new object[] { 0 };
                a_cp_tt = new object[] { 0 };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_mon", 'S', a_ma_mon);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_n", 'S', a_diem_n);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_thi_n", 'S', a_ngay_thi_n);
            dbora.P_THEM_PAR(ref b_lenh, "a_dtb", 'N', a_dtb);
            dbora.P_THEM_PAR(ref b_lenh, "a_kq", 'S', a_kq);
            dbora.P_THEM_PAR(ref b_lenh, "a_cp_htro", 'N', a_cp_htro);
            dbora.P_THEM_PAR(ref b_lenh, "a_cp_tt", 'N', a_cp_tt);

            string b_c = "," + b_so_id_tk + ","
                + ":a_ma_mon,:a_so_the,:a_diem_n,:a_ngay_thi_n,:a_dtb,:a_kq,:a_cp_htro,:a_cp_tt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TK_DIEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_DT_TK_DIEM_XOA(double b_so_id_tk)
    {
        dbora.P_GOIHAM(b_so_id_tk, "PNS_DT_TK_DIEM_XOA");
    }

    public static void Fn_NS_DT_TK_DIEM_IMPORT(double b_so_id_kh, double b_so_id_tk, DataTable b_dt_diem)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            DataTable b_dt_mon = Fdt_NS_DT_KH_CT_MON_LKE(b_so_id_kh);
            string[] a_ma_mon = bang.Fs_COL_MANG(b_dt_mon, "ma");

            object[] a_chiPhi = Fobj_NS_DT_TK_CP(b_so_id_kh, b_so_id_tk);
            double b_tongChiPhi = Convert.ToDouble(a_chiPhi[0].ToString());
            int b_tongHV = Convert.ToInt32(a_chiPhi[1].ToString());

            bang.P_THEM_COL(ref b_dt_diem, "diem", typeof(string)); // các điểm cho vào 1 cột
            bang.P_THEM_COL(ref b_dt_diem, "ngay_thi", typeof(string)); // các ngày thi cho vào 1 cột
            bang.P_THEM_COL(ref b_dt_diem, "dtb", typeof(double)); // cột điểm trung bình
            bang.P_THEM_COL(ref b_dt_diem, "cp_tt", typeof(double)); // cột chi phí thực tế

            string b_diem, b_ngay_thi;
            string b_cot_ngay, b_cot_diem;
            double b_trong_so, b_tongDiem, b_tongTrongSo, b_chiPhiFull1HV = b_tongChiPhi / b_tongHV, b_chiPhi1HV;
            foreach (DataRow dr in b_dt_diem.Rows)
            {
                b_diem = ""; b_ngay_thi = "";
                b_tongDiem = 0; b_tongTrongSo = 0;

                for (int i = 0; i < b_dt_mon.Rows.Count; i++)
                {
                    b_cot_ngay = "ngay_thi_" + i;
                    b_cot_diem = "diem_" + i;

                    if (dr[b_cot_diem].ToString() != "")
                    {
                        b_trong_so = chuyen.CSO_SO(b_dt_mon.Rows[i]["tr_so"].ToString());
                        b_tongDiem += chuyen.CSO_SO(dr[b_cot_diem].ToString()) * b_trong_so;
                        b_tongTrongSo += b_trong_so;
                    }

                    b_diem += (dr[b_cot_diem].ToString() != "" ? dr[b_cot_diem].ToString() : "#") + ",";
                    b_ngay_thi += (dr[b_cot_ngay].ToString() != "" ? chuyen.CNG_CSO(dr[b_cot_ngay].ToString()) : chuyen.CNG_CSO(b_dt_mon.Rows[i]["ngay_thi"].ToString())) + ",";
                }
                if (b_diem != "")
                {
                    b_diem = b_diem.Substring(0, b_diem.Length - 1);
                    b_ngay_thi = b_ngay_thi.Substring(0, b_ngay_thi.Length - 1);
                }
                dr["diem"] = b_diem;
                dr["ngay_thi"] = b_ngay_thi;
                if (b_tongTrongSo > 0)
                    dr["dtb"] = Math.Round(b_tongDiem / b_tongTrongSo, 1);
                else
                    dr["dtb"] = 0;
                if (!dr["cp_htro"].Equals(""))
                {
                    b_chiPhi1HV = b_chiPhiFull1HV * Convert.ToDouble(dr["cp_htro"]) / 100;
                    dr["cp_tt"] = b_chiPhi1HV;
                }
                else
                    dr["cp_tt"] = 0;
            }

            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_so_the, a_diem_n, a_ngay_thi_n, a_dtb, a_kq, a_cp_htro, a_cp_tt;

            // điểm chi tiết + kết quả chung
            if (b_dt_diem.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt_diem, "so_the");
                a_diem_n = bang.Fobj_COL_MANG(b_dt_diem, "diem");
                a_ngay_thi_n = bang.Fobj_COL_MANG(b_dt_diem, "ngay_thi");

                a_dtb = bang.Fobj_COL_MANG(b_dt_diem, "dtb");
                a_kq = bang.Fobj_COL_MANG(b_dt_diem, "kq");
                a_cp_htro = bang.Fobj_COL_MANG(b_dt_diem, "cp_htro");
                a_cp_tt = bang.Fobj_COL_MANG(b_dt_diem, "cp_tt");
            }
            else
            {
                a_so_the = new object[] { "" };
                a_diem_n = new object[] { "" };
                a_ngay_thi_n = new object[] { -1 };

                a_dtb = new object[] { 0 };
                a_kq = new object[] { "" };
                a_cp_htro = new object[] { 0 };
                a_cp_tt = new object[] { 0 };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_mon", 'S', a_ma_mon);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_diem_n", 'S', a_diem_n);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_thi_n", 'S', a_ngay_thi_n);
            dbora.P_THEM_PAR(ref b_lenh, "a_dtb", 'N', a_dtb);
            dbora.P_THEM_PAR(ref b_lenh, "a_kq", 'S', a_kq);
            dbora.P_THEM_PAR(ref b_lenh, "a_cp_htro", 'N', a_cp_htro);
            dbora.P_THEM_PAR(ref b_lenh, "a_cp_tt", 'N', a_cp_tt);

            string b_c = "," + b_so_id_tk + ","
                + ":a_ma_mon,:a_so_the,:a_diem_n,:a_ngay_thi_n,:a_dtb,:a_kq,:a_cp_htro,:a_cp_tt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TK_DIEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion CẬP NHẬT KẾT QUẢ ĐÀO TẠO HỌC VIÊN

    #region TUYỂN SINH HỌC VIÊN

    public static DataTable Fdt_NS_DT_KH_CT_LKE_DR(double b_nam, double b_thang, double b_tt_pd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_thang, b_tt_pd }, "PNS_DT_KH_CT_LKE_DR");
    }

    public static DataTable Fdt_NS_DT_KH_CT_LOP_LKE_DR(string b_ma_kdt, double b_nam, double b_thang, double b_tt_pd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_kdt, b_nam, b_thang, b_tt_pd }, "PNS_DT_KH_CT_LOP_LKE_DR");
    }

    public static DataSet Fds_NS_DT_TS_LKE(double b_so_id_kh)
    {
        return dbora.Fds_LKE(b_so_id_kh, 2, "PNS_DT_TS_LKE");
    }

    public static DataTable Fds_NS_DT_TS_HV_LKE(double b_so_id_kh)
    {
        return dbora.Fdt_LKE_S(b_so_id_kh, "PNS_DT_TS_HV_LKE");
    }

    public static object[] Fobj_NS_DT_TS_TONGHOP(double b_so_id_kh, string b_ma_kdt, double b_nam, double b_thang, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id_kh, b_ma_kdt, b_nam, b_thang, b_tu_n, b_den_n }, "NR", "PNS_DT_TS_TONGHOP");
    }

    public static string P_NS_DT_TS_NH(double b_so_id_kh, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id_dx, a_loai_ts, a_so_the, a_ngaydk, a_tchi1, a_tchi2, a_tchi3, a_kluan, a_ghichu;
            if (b_dt.Rows.Count > 0)
            {
                a_so_id_dx = bang.Fobj_COL_MANG(b_dt, "so_id_dx");
                a_loai_ts = bang.Fobj_COL_MANG(b_dt, "loai_ts");
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
                a_ngaydk = bang.Fobj_COL_MANG(b_dt, "ngaydk");
                a_tchi1 = bang.Fobj_COL_MANG(b_dt, "tchi1");
                a_tchi2 = bang.Fobj_COL_MANG(b_dt, "tchi2");
                a_tchi3 = bang.Fobj_COL_MANG(b_dt, "tchi3");
                a_kluan = bang.Fobj_COL_MANG(b_dt, "kluan");
                a_ghichu = bang.Fobj_COL_MANG(b_dt, "ghichu");
            }
            else
            {
                a_so_id_dx = new object[] { -1 };
                a_loai_ts = new object[] { -1 };
                a_so_the = new object[] { "" };
                a_ngaydk = new object[] { -1 };
                a_tchi1 = new object[] { "" };
                a_tchi2 = new object[] { "" };
                a_tchi3 = new object[] { "" };
                a_kluan = new object[] { "" };
                a_ghichu = new object[] { "" };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_dx", 'N', a_so_id_dx);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_ts", 'N', a_loai_ts);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngaydk", 'N', a_ngaydk);
            dbora.P_THEM_PAR(ref b_lenh, "a_tchi1", 'S', a_tchi1);
            dbora.P_THEM_PAR(ref b_lenh, "a_tchi2", 'S', a_tchi2);
            dbora.P_THEM_PAR(ref b_lenh, "a_tchi3", 'S', a_tchi3);
            dbora.P_THEM_PAR(ref b_lenh, "a_kluan", 'S', a_kluan);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'S', a_ghichu);

            string b_c = "," + b_so_id_kh + ",:a_so_id_dx,:a_loai_ts,:a_so_the,:a_ngaydk,:a_tchi1,:a_tchi2,:a_tchi3,:a_kluan,:a_ghichu";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TS_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return form.Fs_LOC_LOI(ex.Message );
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_DT_TS_NV_DVI_LKE(double b_so_id_kh, string b_ma_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id_kh, b_ma_phong }, "PNS_DT_TS_NV_DVI_LKE");
    }

    public static DataTable Fdt_NS_DT_TS_THEM_LKE(double b_so_id_kh, DateTime b_ngay_ht)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id_kh, b_ngay_ht }, "PNS_DT_TS_THEM_LKE");
    }


    public static string P_NS_DT_TS_THEM_NH(double b_so_id_kh, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the;
            if (b_dt.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            }
            else
            {
                a_so_the = new object[] { "#" };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            string b_c = "," + b_so_id_kh + ",:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TS_THEM_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return form.Fs_LOC_LOI(ex.Message );
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string P_NS_DT_TS_XOA(double b_so_id_kh, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the;
            if (b_dt.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            }
            else
            {
                a_so_the = new object[] { "#" };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            string b_c = "," + b_so_id_kh + ",:a_so_the";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TS_XOA(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                return form.Fs_LOC_LOI(ex.Message );
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion TUYỂN SINH HỌC VIÊN

    #region DANH MỤC NHÓM NỘI DUNG
    public static DataTable Fdt_NS_DT_MA_NND_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_NND_LKE_ALL");
    }

    public static object[] Fdt_NS_DT_MA_NND_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_NND_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_NND_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_NND_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_NND_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"], b_dr["tthai"], b_dr["mota"] }, "PNS_DT_MA_NND_NH");
    }
    public static DataTable Fdt_NS_DT_MA_NND_MA_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_NND_MA_CT");
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_NND_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_NND_XOA");
    }

    /// <summary> drop </summary>
    public static DataTable Fdt_NS_DT_MA_NND_DR()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_NND_DR");
    }

    #endregion

    #region DANH MỤC NHÓM NỘI DUNG ĐƠN VỊ
    public static DataTable Fdt_NS_DT_MA_NND_DV_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_NND_DV_LKE_ALL");
    }

    public static object[] Fdt_NS_DT_MA_NND_DV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PNS_DT_MA_NND_DV_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_NS_DT_MA_NND_DV_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PNS_DT_MA_NND_DV_MA");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_NS_DT_MA_NND_DV_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["nnd"], b_dr["ten"], b_dr["tthai"], b_dr["mota"] }, "PNS_DT_MA_NND_DV_NH");
    }
    public static DataTable Fdt_NS_DT_MA_NND_DV_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PNS_DT_MA_NND_DV_CT");
    }

    /// <summary>Xóa thôn tin</summary>
    public static void P_NS_DT_MA_NND_DV_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PNS_DT_MA_NND_DV_XOA");
    }

    public static DataTable Fdt_NS_DT_MA_NND_DV_DR(string b_nnd)
    {
        return dbora.Fdt_LKE_S(b_nnd, "PNS_DT_MA_NND_DV_DR");
    }

    #endregion

    #region CHỈ TIÊU ĐÀO TẠO VÀ HỌC TẬP
    public static string P_NS_DT_MA_CTDT_HT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_ncdanh = bang.Fobj_COL_MANG(b_dt_ct, "ncdanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "cdanh");
            object[] a_tl_tg_tt = bang.Fobj_COL_MANG(b_dt_ct, "tl_tg_tt");
            object[] a_tl_tg_tt_ojt = bang.Fobj_COL_MANG(b_dt_ct, "tl_tg_tt_ojt");
            object[] a_tl_gd_tt = bang.Fobj_COL_MANG(b_dt_ct, "tl_gd_tt");
            object[] a_tl_gd_tt_ojt = bang.Fobj_COL_MANG(b_dt_ct, "tl_gd_tt_ojt");

            dbora.P_THEM_PAR(ref b_lenh, "a_ncdanh", 'S', a_ncdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'S', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_tg_tt", 'N', a_tl_tg_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_tg_tt_ojt", 'N', a_tl_tg_tt_ojt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_gd_tt", 'N', a_tl_gd_tt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tl_gd_tt_ojt", 'N', a_tl_gd_tt_ojt);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["ngay_hl"]);
            b_c = b_c + ",:a_ncdanh,:a_cdanh,:a_tl_tg_tt,:a_tl_tg_tt_ojt,:a_tl_gd_tt,:a_tl_gd_tt_ojt";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_MA_CTDT_HT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_MA_CTDT_HT_MA(string b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PNS_DT_MA_CTDT_HT_MA");
    }
    public static object[] Faobj_NS_DT_MA_CTDT_HT_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_DT_MA_CTDT_HT_LKE");
    }
    public static DataTable Fdt_NS_DT_MA_CTDT_HT_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_MA_CTDT_HT_LKE_ALL");
    }

    public static DataSet Fds_NS_DT_MA_CTDT_HT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_DT_MA_CTDT_HT_CT");
    }
    public static void P_NS_DT_MA_CTDT_HT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_MA_CTDT_HT_XOA");
    }

    #endregion CHỈ TIÊU ĐÀO TẠO VÀ HỌC TẬP

    #region THỜI GIAN ĐÀO TẠO THEO HÌNH THỨC OJT
    public static DataTable Fdt_NS_DT_HINHTHUC_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_HINHTHUC_LKE_ALL");
    }

    public static string P_NS_DT_HINHTHUC_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_ma_hv = bang.Fobj_COL_MANG(b_dt_ct, "ma_hv");
            object[] a_ten_hv = bang.Fobj_COL_MANG(b_dt_ct, "ten_hv");
            object[] a_donvi = bang.Fobj_COL_MANG(b_dt_ct, "donvi");
            object[] a_thoi_gian_hoc = bang.Fobj_COL_MANG(b_dt_ct, "thoi_gian_hoc");
            object[] a_ket_qua = bang.Fobj_COL_MANG(b_dt_ct, "ket_qua");

            dbora.P_THEM_PAR(ref b_lenh, "a_ma_hv", 'S', a_ma_hv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_hv", 'U', a_ten_hv);
            dbora.P_THEM_PAR(ref b_lenh, "a_donvi", 'U', a_donvi);
            dbora.P_THEM_PAR(ref b_lenh, "a_thoi_gian_hoc", 'S', a_thoi_gian_hoc);
            dbora.P_THEM_PAR(ref b_lenh, "a_ket_qua", 'S', a_ket_qua);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["ten_phong"]) + "," + chuyen.OBJ_S(b_dr["ngay_gd"]) + "," + chuyen.OBJ_C(b_dr["thoi_gian_gd"]) +
                "," + chuyen.OBJ_C(b_dr["tu_gio"]) + "," + chuyen.OBJ_C(b_dr["den_gio"]) + "," + chuyen.OBJ_C(b_dr["noidung"]);
            b_c = b_c + ",:a_ma_hv,:a_ten_hv,:a_donvi,:a_thoi_gian_hoc,:a_ket_qua";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_HINHTHUC_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_HINHTHUC_MA(string b_so_id, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_nam, b_trangkt }, "NNR", "PNS_DT_HINHTHUC_MA");
    }
    public static object[] Faobj_NS_DT_HINHTHUC_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), b_tu, b_den }, "NR", "PNS_DT_HINHTHUC_LKE");
    }
    public static DataSet Fds_NS_DT_HINHTHUC_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_DT_HINHTHUC_CT");
    }
    public static void P_NS_DT_HINHTHUC_XOA(string b_so_id, string b_ma_hv)
    {
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_N(b_so_id), b_ma_hv }, "PNS_DT_HINHTHUC_XOA");
    }
    #endregion THỜI GIAN ĐÀO TẠO THEO HÌNH THỨC OJT

    #region TRIỂN KHAI ĐÀO TẠO
    public static object[] Faobj_NS_DT_TRIENKHAI_LKE(double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "PNS_NS_DT_TRIENKHAI_LKE");
    }
    public static void P_NS_DT_TRIENKHAI_NH(DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            string b_c = ",:a_so_id";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TRIENKHAI_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion TRIỂN KHAI ĐÀO TẠO

    #region  Tổng hợp thời gian giảng dạy của giảng viên
    //
    public static DataSet Fdt_NS_DT_TGIAN_GDAY_LKE_ALL(string nam)
    {
        return dbora.Fds_LKE(new object[] { chuyen.OBJ_N(nam) }, 1, "pns_ns_dt_tgian_gday_lke_all");
    }
    //

    public static object[] Faobj_NS_DT_TGIAN_GDAY_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_tu, b_den }, "NR", "PNS_NS_DT_TGIAN_GDAY_LKE");
    }
    //
    public static void Fs_NS_DT_TGIAN_GDAY_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            // thong tin  nhân vien
            object[] a_ma_gv = bang.Fobj_COL_MANG(b_dt, "ma_gv");
            object[] a_ten_gv = bang.Fobj_COL_MANG(b_dt, "ten_gv");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt, "ten_cdanh");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt, "ten_phong");
            object[] a_sogio_gianday_iclas = bang.Fobj_COL_MANG(b_dt, "sogio_gianday_iclas");
            object[] a_sogio_gianday_ojt = bang.Fobj_COL_MANG(b_dt, "sogio_gianday_ojt");
            object[] a_sogio_gianday = bang.Fobj_COL_MANG(b_dt, "sogio_gianday");
            object[] a_sogio_tt_iclas = bang.Fobj_COL_MANG(b_dt, "sogio_tt_iclas");
            object[] a_sogio_tt_ojt = bang.Fobj_COL_MANG(b_dt, "sogio_tt_ojt");
            object[] a_sogio_tt = bang.Fobj_COL_MANG(b_dt, "sogio_tt");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', b_so_id); 
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_gv", 'S', a_ma_gv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_gv", 'U', a_ten_gv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_gianday_iclas", 'N', a_sogio_gianday_iclas);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_gianday_ojt", 'N', a_sogio_gianday_ojt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_gianday", 'N', a_sogio_gianday);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tt_iclas", 'N', a_sogio_tt_iclas);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tt_ojt", 'N', a_sogio_tt_ojt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tt", 'N', a_sogio_tt);
            //
            string b_c = ",:so_id,:a_ma_gv,:a_ten_gv,:a_ten_cdanh,:a_ten_phong,:a_sogio_gianday_iclas,:a_sogio_gianday_ojt,:a_sogio_gianday"
            + ",:a_sogio_tt_iclas,:a_sogio_tt_ojt,:a_sogio_tt";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TGIAN_GDAY_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion Tổng hợp thời gian giảng dạy của giảng viên

    #region  Tổng hợp thời gian học tập của học viên
    //
    public static DataSet Fdt_NS_DT_TGIAN_GDAY_HVIEN_LKE_ALL(string phong, string nam)
    {
        return dbora.Fds_LKE(new object[] { phong, chuyen.OBJ_N(nam) }, 1, "pns_dt_tgian_gday_hv_lke_all");
    }
    //
    public static object[] Faobj_NS_DT_TGIAN_GDAY_HVIEN_LKE(string b_phong, string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, chuyen.CSO_SO(b_nam), b_tu, b_den }, "NR", "PNS_NS_DT_TGIAN_GDAY_HVIEN_LKE");
    }
    public static void Fs_NS_DT_TGIAN_GDAY_HV_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            // thong tin  nhân vien
            object[] a_ma_hv = bang.Fobj_COL_MANG(b_dt, "ma_hv");
            object[] a_ten_hv = bang.Fobj_COL_MANG(b_dt, "ten_hv");
            object[] a_ten_cdanh = bang.Fobj_COL_MANG(b_dt, "ten_cdanh");
            object[] a_ten_phong = bang.Fobj_COL_MANG(b_dt, "ten_phong");
            object[] a_sogio_tgia_iclas = bang.Fobj_COL_MANG(b_dt, "sogio_tgia_iclas");
            object[] a_sogio_tgia_ojt = bang.Fobj_COL_MANG(b_dt, "sogio_tgia_ojt");
            object[] a_sogio_tgia = bang.Fobj_COL_MANG(b_dt, "sogio_tgia");
            object[] a_sogio_dt_thucte = bang.Fobj_COL_MANG(b_dt, "sogio_dt_thucte");
            object[] a_sogio_dt_thucte_iclas = bang.Fobj_COL_MANG(b_dt, "sogio_dt_thucte_iclas");
            object[] a_sogio_dt_thucte_ojt = bang.Fobj_COL_MANG(b_dt, "sogio_dt_thucte_ojt");
            object[] a_tyle = bang.Fobj_COL_MANG(b_dt, "tyle");
            object[] a_tong_cp = bang.Fobj_COL_MANG(b_dt, "tong_cp");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', b_so_id); 
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_hv", 'S', a_ma_hv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_hv", 'U', a_ten_hv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_cdanh", 'U', a_ten_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_phong", 'U', a_ten_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tgia_iclas", 'N', a_sogio_tgia_iclas);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tgia_ojt", 'N', a_sogio_tgia_ojt);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_tgia", 'N', a_sogio_tgia);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_dt_thucte", 'N', a_sogio_dt_thucte);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_dt_thucte_iclas", 'N', a_sogio_dt_thucte_iclas);
            dbora.P_THEM_PAR(ref b_lenh, "a_sogio_dt_thucte_ojt", 'N', a_sogio_dt_thucte_ojt);
            dbora.P_THEM_PAR(ref b_lenh, "a_tyle", 'N', a_tyle);
            dbora.P_THEM_PAR(ref b_lenh, "a_tong_cp", 'N', a_tong_cp);
            //
            string b_c = ",:so_id,:a_ma_hv,:a_ten_hv,:a_ten_cdanh,:a_ten_phong,:a_sogio_tgia_iclas,:a_sogio_tgia_ojt,:a_sogio_tgia"
            + ",:a_sogio_dt_thucte,:a_sogio_dt_thucte_iclas,:a_sogio_dt_thucte_ojt,:a_tyle,:a_tong_cp";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TGIAN_GDAY_HV_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    #endregion Tổng hợp thời gian học tập của học viên

    #region DANH SÁCH HỌC VIÊN THAM GIA KHÓA ĐÀO TẠO

    public static string P_NS_DT_HVIEN_TGIAN_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt_ct, "ten");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ten_cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "ten_phong");
            object[] a_so_dt = bang.Fobj_COL_MANG(b_dt_ct, "so_dt");
            object[] a_email = bang.Fobj_COL_MANG(b_dt_ct, "email");
            object[] a_email_ql = bang.Fobj_COL_MANG(b_dt_ct, "email_ql");
            object[] a_loai_hv = bang.Fobj_COL_MANG(b_dt_ct, "loai_hv");
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_dt", 'S', a_so_dt);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_email_ql", 'S', a_email_ql);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_hv", 'S', a_loai_hv);
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["khoa_dt"]) + "," + chuyen.OBJ_C(b_dr["lop_dt"]) + "," + chuyen.OBJ_C(b_dr["nhom_nd"]) + "," + chuyen.OBJ_C(b_dr["tluong"]) + "," + chuyen.OBJ_S(b_dr["ngayd"]) + "," + chuyen.OBJ_S(b_dr["ngayc"]);
            b_c = b_c + ",:a_stt,:a_so_the,:a_ten,:a_cdanh,:a_phong,:a_so_dt,:a_email,:a_email_ql,:a_loai_hv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_HVIEN_TGIAN_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static void P_NS_DT_HVIEN_TGIAN_IMP(ref double b_so_id, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            bang.P_CSO_SO(ref b_dt_ct, "stt,so_dt,loai_hv");

            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ten_hv = bang.Fobj_COL_MANG(b_dt_ct, "ten_hv");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct, "ten_cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct, "ten_phong");
            object[] a_so_dt = bang.Fobj_COL_MANG(b_dt_ct, "so_dt");
            object[] a_email = bang.Fobj_COL_MANG(b_dt_ct, "email");
            object[] a_email_qly = bang.Fobj_COL_MANG(b_dt_ct, "email_qly");
            object[] a_loai_hv = bang.Fobj_COL_MANG(b_dt_ct, "loai_hv");
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten_hv", 'U', a_ten_hv);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_dt", 'S', a_so_dt);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_email_qly", 'S', a_email_qly);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_hv", 'N', a_loai_hv);
            string b_c = ",:so_id,:a_stt,:a_so_the,:a_ten_hv,:a_cdanh,:a_phong,:a_so_dt,:a_email,:a_email_qly,:a_loai_hv";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_HVIEN_TGIAN_IMP(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IMPORT, TEN_FORM.NS_DT_HVIEN_TGIAN, TEN_BANG.NS_DT_HVIEN_TGIAN);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_HVIEN_TGIAN_MA(string b_so_id, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_nam, b_thang, b_khoa_dt, b_lop_dt, b_trangkt }, "NNR", "PNS_DT_HVIEN_TGIAN_MA");
    }
    public static object[] Faobj_NS_DT_HVIEN_TGIAN_LKE(string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_thang, b_khoa_dt, b_lop_dt, b_tu, b_den }, "NR", "PNS_DT_HVIEN_TGIAN_LKE");
    }
    //public static object[] Faobj_NS_DT_HVIEN_TGIAN_LKE_ALL(string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt)
    //{
    //    return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_khoa_dt, b_lop_dt }, "NR", "PNS_DT_HVIEN_TGIAN_LKE_ALL");
    //}
    public static DataTable Faobj_NS_DT_HVIEN_TGIAN_LKE_ALL(string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_khoa_dt, b_lop_dt }, "PNS_DT_HVIEN_TGIAN_LKE_ALL");
    }
    public static object[] Faobj_NS_DT_HVIEN_TGIAN_TH(string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, string b_so_id, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_khoa_dt, b_lop_dt, chuyen.OBJ_N(b_so_id), b_tu, b_den }, "NR", "PNS_DT_HVIEN_TGIAN_TH");
    }

    public static object[] Fds_NS_DT_HVIEN_TGIAN_CT(string b_so_id, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_tu, b_den }, "NRR", "PNS_DT_HVIEN_TGIAN_CT");
    }

    public static void P_NS_DT_HVIEN_TGIAN_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_HVIEN_TGIAN_XOA");
    }

    #endregion DANH SÁCH HỌC VIÊN THAM GIA KHÓA ĐÀO TẠO

    #region  NHU CẦU ĐÀO TẠO
    public static object[] Faobj_NS_DT_NCAU_LKE(string b_nam, string b_thang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang), b_tu, b_den }, "NR", "PNS_NS_DT_NCAU_LKE");
    }
    public static DataTable Fdt_NS_DT_NCAU_LKE_ALL()
    {
        return dbora.Fdt_LKE("PNS_DT_NCAU_LKE_ALL");
    }
    #endregion NHU CẦU ĐÀO TẠO

    #region ĐỀ XUẤT ĐÀO TẠO

    public static string P_NS_DT_DEXUAT_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["khoa_dt"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_S(b_dr["tluong_dt"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["muc_tieu"]) + "," + chuyen.OBJ_C(b_dr["dia_diem"]) + "," + chuyen.OBJ_C(b_dr["mo_ta"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DEXUAT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_DEXUAT_MA(string b_so_id, string b_trang_thai, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trang_thai, b_trangkt }, "NNR", "PNS_DT_DEXUAT_MA");
    }
    public static object[] Faobj_NS_DT_DEXUAT_LKE(string b_trang_thai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trang_thai, b_tu, b_den }, "NR", "PNS_DT_DEXUAT_LKE");
    }
    public static DataTable Fdt_NS_DT_DEXUAT_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_DT_DEXUAT_CT");
    }
    public static void P_NS_DT_DEXUAT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_DEXUAT_XOA");
    }
    public static void P_NS_DT_DEXUAT_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_NS_DT_DEXUAT_GUI");
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region ĐỀ XUẤT ĐÀO TẠO LÃNH ĐẠO

    public static string P_NS_DT_DEXUAT_LD_NH(ref string b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            string b_c = ",:so_id," + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["khoa_dt"]) + "," + chuyen.OBJ_S(b_dr["thang"]) + "," + chuyen.OBJ_S(b_dr["tluong_dt"]) + "," + chuyen.OBJ_S(b_dr["sl_hocvien"]) + "," + chuyen.OBJ_S(b_dr["chiphi_dk"]) + "," + chuyen.OBJ_C(b_dr["lydo"]) + "," + chuyen.OBJ_C(b_dr["muc_tieu"]) + "," + chuyen.OBJ_C(b_dr["dia_diem"]) + "," + chuyen.OBJ_C(b_dr["mo_ta"]);
            b_c = b_c + "";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DEXUAT_LD_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_DEXUAT_LD_MA(string b_so_id, string b_trang_thai, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trang_thai, b_trangkt }, "NNR", "PNS_DT_DEXUAT_LD_MA");
    }
    public static object[] Faobj_NS_DT_DEXUAT_LD_LKE(string b_trang_thai, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_trang_thai, b_tu, b_den }, "NR", "PNS_DT_DEXUAT_LD_LKE");
    }
    public static DataTable Fdt_NS_DT_DEXUAT_LD_CT(string b_so_id)
    {
        return dbora.Fdt_LKE_S(chuyen.OBJ_N(b_so_id), "PNS_DT_DEXUAT_LD_CT");
    }
    public static void P_NS_DT_DEXUAT_LD_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_DEXUAT_LD_XOA");
    }
    public static void P_NS_DT_DEXUAT_LD_GUI(string b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_NS_DT_DEXUAT_LD_GUI");
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO
    public static object[] Fdt_NS_DT_DEXUAT_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_phong, a_tinhtrang, chuyen.CNG_SO(b_tungay), chuyen.CNG_SO(b_denngay), b_tu, b_den }, "NR", "PNS_NS_DT_DEXUAT_PD_LKE");
    }
    public static DataTable Fdt_NS_DT_DEXUAT_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
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
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_NS_DT_DEXUAT_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
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
    public static DataTable Fdt_NS_DT_DEXUAT_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, DataTable b_dt, DataTable b_dt_ct)
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
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_NS_DT_DEXUAT_PD_KPD(" + b_se.tso + b_c + "); end;";
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
    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO

    #region ĐÁNH GIÁ KHÓA ĐÀO TẠO

    public static string P_NS_DT_DANHGIA_KDT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_sott = bang.Fobj_COL_MANG(b_dt_ct, "sott");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_ct, "noidung");
            object[] a_rtot = bang.Fobj_COL_MANG(b_dt_ct, "rtot");
            object[] a_tot = bang.Fobj_COL_MANG(b_dt_ct, "tot");
            object[] a_kha = bang.Fobj_COL_MANG(b_dt_ct, "kha");
            object[] a_trungbinh = bang.Fobj_COL_MANG(b_dt_ct, "trungbinh");
            object[] a_kem = bang.Fobj_COL_MANG(b_dt_ct, "kem");
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'S', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'S', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_rtot", 'S', a_rtot);
            dbora.P_THEM_PAR(ref b_lenh, "a_tot", 'S', a_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_kha", 'S', a_kha);
            dbora.P_THEM_PAR(ref b_lenh, "a_trungbinh", 'S', a_trungbinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_kem", 'S', a_kem);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["KHOA_HOC"]) + "," + chuyen.OBJ_C(b_dr["ma_lop"]) + "," + chuyen.OBJ_C(b_dr["doi_tac"]) + "," + chuyen.OBJ_S(b_dr["ngay_hoc"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["giang_vien"]) + "," + chuyen.OBJ_C(b_dr["hailong"]) + "," + chuyen.OBJ_C(b_dr["khailong"]) + "," + chuyen.OBJ_C(b_dr["kyvong"]) + "," + chuyen.OBJ_C(b_dr["dat_duoc"]);
            b_c = b_c + ",:a_sott,:a_stt,:a_noidung,:a_rtot,:a_tot,:a_kha,:a_trungbinh,:a_kem";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANHGIA_KDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_DANHGIA_KDT_MA(string b_so_id, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, chuyen.CSO_SO(b_nam), b_trangkt }, "NNR", "PNS_DT_DANHGIA_KDT_MA");
    }
    public static object[] Faobj_NS_DT_DANHGIA_KDT_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_tu, b_den }, "NRR", "PNS_DT_DANHGIA_KDT_LKE");
    }
    public static DataSet Fds_NS_DT_DANHGIA_KDT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_DT_DANHGIA_KDT_CT");
    }
    public static object[] Faobj_NS_DT_TGIAN_HOC_P_CT(string b_nam, string b_so_the)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_so_the }, "R", "PNS_DT_TGIAN_HOC_P_CT");
    }
    public static void P_NS_DT_DANHGIA_KDT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_DANHGIA_KDT_XOA");
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region ĐÁNH GIÁ CHẤT LƯỢNG KHÓA ĐÀO TẠO

    public static string P_NS_DT_DANHGIA_CL_KDT_NH(ref string b_so_id, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            object[] a_sott = bang.Fobj_COL_MANG(b_dt_ct, "sott");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_ct, "stt");
            object[] a_noidung = bang.Fobj_COL_MANG(b_dt_ct, "noidung");
            object[] a_rtot = bang.Fobj_COL_MANG(b_dt_ct, "rtot");
            object[] a_tot = bang.Fobj_COL_MANG(b_dt_ct, "tot");
            object[] a_kha = bang.Fobj_COL_MANG(b_dt_ct, "kha");
            object[] a_trungbinh = bang.Fobj_COL_MANG(b_dt_ct, "trungbinh");
            object[] a_kem = bang.Fobj_COL_MANG(b_dt_ct, "kem");
            dbora.P_THEM_PAR(ref b_lenh, "a_sott", 'N', a_sott);
            dbora.P_THEM_PAR(ref b_lenh, "a_stt", 'S', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_noidung", 'U', a_noidung);
            dbora.P_THEM_PAR(ref b_lenh, "a_rtot", 'N', a_rtot);
            dbora.P_THEM_PAR(ref b_lenh, "a_tot", 'N', a_tot);
            dbora.P_THEM_PAR(ref b_lenh, "a_kha", 'N', a_kha);
            dbora.P_THEM_PAR(ref b_lenh, "a_trungbinh", 'N', a_trungbinh);
            dbora.P_THEM_PAR(ref b_lenh, "a_kem", 'N', a_kem);
            string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["KHOA_HOC"]) + "," + chuyen.OBJ_C(b_dr["lop_dt"]) + "," + chuyen.OBJ_C(b_dr["doi_tac"]) + "," + chuyen.OBJ_S(b_dr["ngay_hoc"]);
            b_c = b_c + "," + chuyen.OBJ_C(b_dr["giang_vien"]) + "," + chuyen.OBJ_C(b_dr["hailong"]) + "," + chuyen.OBJ_C(b_dr["khailong"]) + "," + chuyen.OBJ_C(b_dr["kyvong"]) + "," + chuyen.OBJ_C(b_dr["dat_duoc"]);
            b_c = b_c + ",:a_sott,:a_stt,:a_noidung,:a_rtot,:a_tot,:a_kha,:a_trungbinh,:a_kem";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_DANHGIA_CL_KDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Faobj_NS_DT_DANHGIA_CL_KDT_MA(string b_so_id, string b_nam, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_nam, b_trangkt }, "NNR", "PNS_DT_DANHGIA_CL_KDT_MA");
    }
    public static DataTable Fdt_NS_DT_DANHGIA_CL_KDT_DR(string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam }, "PNS_DT_DANHGIA_CL_KDT_DR");
    }
    public static object[] Faobj_NS_DT_DANHGIA_CL_KDT_LKE(string b_nam, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_nam, b_tu, b_den }, "NRR", "PNS_DT_DANHGIA_CL_KDT_LKE");
    }
    public static DataSet Fds_NS_DT_DANHGIA_CL_KDT_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 2, "PNS_DT_DANHGIA_CL_KDT_CT");
    }
    public static void P_NS_DT_DANHGIA_CL_KDT_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.OBJ_N(b_so_id), "PNS_DT_DANHGIA_CL_KDT_XOA");
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region TRIỂN KHAI KDT
    public static object[] Faobj_NS_DT_TRIENKHAI_KDT_CT(string b_so_id, string b_khoa_dt, string b_lop_dt, string b_trangthai)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_khoa_dt, b_lop_dt, b_trangthai }, "RRR", "PNS_DT_TRIENKHAI_KDT_CT");
    }
    public static void Fs_NS_DT_TRIENKHAI_KDT_NH(ref string b_so_id, string b_tong_cp, string b_cp_hv, DataTable b_dt, DataTable b_dt_ct_cp, DataTable b_dt_ct_gv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            // chi phi dao tao
            object[] a_loai_cp = bang.Fobj_COL_MANG(b_dt_ct_cp, "loai_cp");
            object[] a_stien = bang.Fobj_COL_MANG(b_dt_ct_cp, "stien");
            // thong tin  nhân vien
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct_gv, "so_the");
            object[] a_ho_ten = bang.Fobj_COL_MANG(b_dt_ct_gv, "hoten");
            object[] a_ddanh = bang.Fobj_COL_MANG(b_dt_ct_gv, "ddanh");
            object[] a_cdanh = bang.Fobj_COL_MANG(b_dt_ct_gv, "cdanh");
            object[] a_phong = bang.Fobj_COL_MANG(b_dt_ct_gv, "phong");
            object[] a_sodt = bang.Fobj_COL_MANG(b_dt_ct_gv, "sodt");
            object[] a_email = bang.Fobj_COL_MANG(b_dt_ct_gv, "email");
            object[] a_ghichu = bang.Fobj_COL_MANG(b_dt_ct_gv, "ghichu");

            dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));
            //dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai_cp", 'U', a_loai_cp);
            dbora.P_THEM_PAR(ref b_lenh, "a_stien", 'N', a_stien);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ho_ten", 'U', a_ho_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_ddanh", 'S', a_ddanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_cdanh", 'U', a_cdanh);
            dbora.P_THEM_PAR(ref b_lenh, "a_phong", 'U', a_phong);
            dbora.P_THEM_PAR(ref b_lenh, "a_sodt", 'S', a_sodt);
            dbora.P_THEM_PAR(ref b_lenh, "a_email", 'S', a_email);
            dbora.P_THEM_PAR(ref b_lenh, "a_ghichu", 'U', a_ghichu);
            //
            string b_c = ",:so_id,"
            + chuyen.OBJ_S(b_dr["nam"]) + "," + chuyen.OBJ_C(b_dr["thang"]) + "," + chuyen.OBJ_C(b_dr["ma_kdt"]) + ","
            + chuyen.OBJ_C(b_dr["nhom_nd"]) + "," + chuyen.OBJ_C(b_dr["ma_lop"]) + "," + chuyen.OBJ_C(b_dr["ten_lop"]) + "," + chuyen.OBJ_C(b_dr["hinhthuc"]) + ","
            + chuyen.OBJ_S(b_dr["ngay_d"]) + "," + chuyen.OBJ_S(b_dr["ngay_c"]) + "," + chuyen.OBJ_S(b_dr["thluong"]) + ","
            + chuyen.OBJ_C(b_dr["ddiem"]) + "," + chuyen.OBJ_S(b_dr["sl_hvien"]) + "," + chuyen.OBJ_C(b_dr["doitac"]) + "," + chuyen.OBJ_C(b_dr["gv_dt"]) + ","
            + chuyen.CSO_SO(b_tong_cp) + "," + chuyen.CSO_SO(b_cp_hv) + ","
            + ":a_loai_cp,:a_stien,:a_so_the,:a_ho_ten,:a_ddanh,:a_cdanh,:a_phong,:a_sdt,:a_email,:a_ghichu";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_DT_TRIENKHAI_KDT_NH(" + b_se.tso + b_c + "); end;";
            b_lenh.ExecuteNonQuery();
            b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
        }
        finally { b_cnn.Close(); }
    }

    #endregion TRIỂN KHAI KDT

    #region ĐÀO TẠO_MASTER_LD
    public static DataTable Fdt_HT_MA_DVI_DR()
    {
        return dbora.Fdt_LKE("pns_ht_ma_dvi_quyen_dr");
    }
    #endregion
}