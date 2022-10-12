using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_dt : System.Web.Services.WebService
{
    #region KẾ HOẠCH ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_KH_LKE(string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_LKE(b_nam, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_MA(string b_nam, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_KH_MA(b_nam, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT(string b_nam, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT(b_nam, b_ma);
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_DM_KDT", "MA_KDT");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_NH(string b_ma, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_KH_NH(b_dt_ct);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_DT_KH_MA(b_nam, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_XOA(string b_nam, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH, ht_dungchung.NHOM_DT, b_ma, ref b_thongbao);
            if (b_tontai > 0)
            {
                return "loi:Mã nhóm đào tạo " + b_ma + " đã được sử dụng:loi";
            }
            ns_dt.PNS_DT_KH_XOA(b_nam, b_ma);
            return Fs_NS_DT_KH_LKE(b_nam, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KẾ HOẠCH ĐÀO TẠO

    #region KHOÁ BỒI DƯỠNG
    [WebMethod(true)]
    public string Fs_NS_DT_KBD_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_dt.Fdt_NS_DT_KBD_CT(b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KBD_LKE(string b_nam, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_KBD_LKE(b_nam);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KBD_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            return ns_dt.P_NS_DT_KBD_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KBD_XOA(string b_so_id)
    {
        try
        {
            ns_dt.PNS_DT_KBD_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    #endregion KHOÁ ĐÀO TẠO

    #region DANH SÁCH ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_DANHSACH_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_DANHSACH_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd"); bang.P_SO_CSO(ref b_dt_tk, "soluong,chiphi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANHSACH_PHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "lan");
            DataTable b_kq = ns_dt.Fdt_NS_DT_DANHSACH_PHEDUYET(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_DG_PD_GIAO_KPI, TEN_BANG.NS_DG_PD_GIAO_KPI);
            string b_guimail = "";
            if (b_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đề xuất đào tạo cần phê duyệt";
                string b_body = "Bạn có đề xuất đào tạo cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return b_guimail;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANHSACH_KOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }

            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            bang.P_CSO_SO(ref b_dt_ct, "lan");
            ns_dt.Fdt_NS_DT_DANHSACH_KOPHEDUYET(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_DG_PD_GIAO_KPI, TEN_BANG.NS_DG_PD_GIAO_KPI);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_DANHSACH_CHOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }

            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            bang.P_CSO_SO(ref b_dt_ct, "lan");
            ns_dt.Fdt_NS_DT_DANHSACH_CHOPHEDUYET(b_dt, b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion DANH SÁCH ĐÀO TẠO
     
    #region KẾT QUẢ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_dt.Fdt_NS_DT_KETQUADT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngay_qd");
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_KETQUADT_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_KETQUADT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_qd");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_THEM_COL(ref b_dt_ct, "tt");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                b_dt_ct.Rows[i]["tt"] = i + 1;
            }
            ns_dt.P_NS_DT_KETQUADT_NH(b_so_id, b_dt, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_KETQUADT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { ns_dt.PNS_DT_KETQUADT_XOA(b_so_id); return Fs_NS_DT_KETQUADT_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KETQUADT_LKECB(string b_ma, string[] a_cot)
    {
        DataTable b_dt = ns_dt.PNS_DT_KETQUADT_LKECB(b_ma);
        bang.P_THEM_COL(ref b_dt, "ketqua", "");
        return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
    }
    #endregion KẾT QUẢ ĐÀO TẠO

    #region KHỞI TẠO KHÓA HỌC
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_TAOKH_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngaytrinh");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đang cho đăng ký");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Đủ học viên/Đóng ĐK");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "3", "Đang học");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "4", "Đã kết thúc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_TAOKH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngaytrinh");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "1", "Đang cho đăng ký");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "2", "Đủ học viên/Đóng ĐK");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "3", "Đang tổ chức");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "4", "Đã kết thúc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_TAOKH_CT(b_ma);
            bang.P_SO_CNG(ref b_dt, new string[] { "ngaytrinh", "ngay_qd", "ngayd", "ngayc" });
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_NH(string b_ma, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "1");
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngaytrinh", "ngay_qd", "ngayd", "ngayc" });
            ns_dt.P_NS_DT_TAOKH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TAOKH, TEN_BANG.NS_DT_TAOKH);
            return Fs_NS_DT_TAOKH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_TAOKH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_TAOKH, TEN_BANG.NS_DT_TAOKH);
            return Fs_NS_DT_TAOKH_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TAOKH_DONG(string b_ma)
    {
        try
        {
            ns_dt.Fdt_NS_DT_TAOKH_DONG(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KHỞI TẠO KHÓA HỌC

    #region CÀI ĐẶT PHÊ DUYỆT ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_CAIDAT_PD_CT(string b_loai, string b_dvi, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_CAIDAT_PD_CT(b_loai, b_dvi);
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CAIDAT_PD_NH(object[] a_dt, string b_loaiPd, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); //bang.P_THEM_COL(ref b_dt_ct, "lan");
            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            bang.P_CSO_SO(ref b_dt_ct, "so_ngay");
            int j = b_dt_ct.Rows.Count;
            if (j > 0)
            {
                for (int i = 0; i < b_dt_ct.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lan"].ToString()))
                    {
                        return "loi:Chưa chọn cấp phê duyệt:loi";
                    }
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["loai_pd"].ToString()))
                    {
                        return "loi:Chưa chọn loai phê duyệt:loi";
                    }
                }
                ns_dt.P_NS_DT_CAIDAT_PD_NH(b_dt, b_loaiPd, b_dt_ct);
                return "";
            }
            else return "loi:Phải nhập người phê duyệt, nếu để trống lưới thì mặc định là không cần phê duyệt:loi";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CAIDAT_PD_XOA(string b_so_the, string b_loai)
    {
        try
        {
            ns_dt.PNS_DT_CAIDAT_PD_XOA(b_so_the, b_loai);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_CAIDAT_PD, TEN_BANG.NS_DT_CAIDAT_PD);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion CÀI ĐẶT PHÊ DUYỆT ĐÀO TẠO

    #region DANH SÁCH ĐÀO TẠO CHUẨN THEO CHỨC DANH
    [WebMethod(true)]
    public string Fs_DT_NGV_CHUAN_THEO_CDANH_LKE(double b_nam, string b_bophan, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_Fs_DT_NGV_CHUAN_THEO_CDANH_LKE(b_tu_n, b_den_n, b_nam, b_bophan, b_cdanh);
            DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_DT_NGV_CHUAN_THEO_CDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_Fs_DT_NGV_CHUAN_THEO_CDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_DT_NGV_CHUAN_THEO_CDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_Fs_DT_NGV_CHUAN_THEO_CDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DT_NGV_CHUAN_THEO_CDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_DT_NGV_CHUAN_THEO_CDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_dt.P_Fs_DT_NGV_CHUAN_THEO_CDANH_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐÁNH GIÁ NĂNG LỰC CHO CÁN BỘ NHÂN VIÊN

    #region KẾ HOẠCH ĐÀO TẠO NĂM
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_LKE(object[] a_dt_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_dt.Fdt_NS_DT_KHDT_NAM_LKE(b_dt_tk, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "cphi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_MA(object[] a_dt_tk, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_dt.Fdt_NS_DT_KHDT_NAM_MA(b_dt_tk, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_CT(string b_form, string b_so_id)
    {
        try
        {
            var b_ds = ns_dt.Fdt_NS_DT_KHDT_NAM_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_kdt = b_ds.Tables[1].Copy();
            string b_kh_nam = b_dt.Rows[0]["is_yeucau"].ToString();
            if (b_kh_nam == "X")
            {
                string b_nam = b_dt.Rows[0]["nam"].ToString(), b_thang = b_dt.Rows[0]["thang"].ToString();
                DataTable b_lke = ht_dungchung.Fdt_MA_KDT_NHUCAU(b_nam, b_thang);
                se.P_TG_LUU(b_form, "DT_NHUCAU", b_lke.Copy());
            }
            else
            {
                string b_nam = b_dt.Rows[0]["nam"].ToString(), b_noidung = b_dt.Rows[0]["nhom_nd"].ToString();
                DataTable b_lke = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, b_noidung);
                se.P_TG_LUU(b_form, "DT_KDT", b_lke.Copy());
            }
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_THANG", "THANG");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_KDT", "KDT");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NHUCAU", "NHUCAU");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NND", "NHOM_ND");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_kdt, "ma,ten");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_NH(string b_login, string b_so_id, object[] a_dt_tk, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_KHDT_NAM_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_KHDT_NAM, TEN_BANG.NS_DT_KHDT_NAM);
            return Fs_NS_DT_KHDT_NAM_MA(a_dt_tk, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_XOA(object[] a_dt_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_KHDT_NAM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_KHDT_NAM, TEN_BANG.NS_DT_KHDT_NAM);
            return Fs_NS_DT_KHDT_NAM_LKE(a_dt_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_KDT_NHUCAU(string b_kdt, string b_nam, string b_thang)
    {
        try
        {
            string b_sl_hocvien = "", b_ma_lop = "", b_nhom_nd = "", b_hthuc = "", b_tluong = "";
            object[] a_object = ns_dt.Fdt_NS_DT_KHDT_NAM_KDT_NHUCAU(b_kdt, b_nam, b_thang);
            DataTable b_dt = (DataTable)a_object[0];
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_sl_hocvien = b_dt.Rows[0]["sl_hocvien"].ToString();
                b_ma_lop = ht_dungchung.Fdt_AutoGenCode(b_kdt, "NS_DT_KH_CT", "MA_LOP");
                b_nhom_nd = b_dt.Rows[0]["nnd"].ToString() + "{" + b_dt.Rows[0]["ten_nnd"].ToString();
                b_hthuc = b_dt.Rows[0]["hthuc"].ToString();
                b_tluong = b_dt.Rows[0]["tluong"].ToString();
            }
            return b_sl_hocvien + "#" + b_ma_lop + "#" + b_nhom_nd + "#" + b_hthuc + "#" + b_tluong;


        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHDT_NAM_KDT(string b_ma_kdt)
    {
        try
        {
            string b_hinhthuc = "", b_tluong = "", b_ma_lop = "";
            object[] a_object = ns_dt.Fdt_NS_DT_KHDT_NAM_KDT(b_ma_kdt);
            DataTable b_dt = (DataTable)a_object[0];
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_hinhthuc = b_dt.Rows[0]["hthuc"].ToString();
                b_tluong = b_dt.Rows[0]["tluong"].ToString();
                b_ma_lop = ht_dungchung.Fdt_AutoGenCode(b_ma_kdt, "NS_DT_KH_CT", "MA_LOP");
            }
            return b_hinhthuc + "#" + b_tluong + "#" + b_ma_lop;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KẾ HOẠCH ĐÀO TẠO NĂM

    #region DANH MỤC CHỨNG CHỈ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCDTAO_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CCDTAO_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "nguoi_pd", "phê duyệt lần 0", "");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCDTAO_MA(string b_phong, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CCDTAO_MA(b_phong, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "nguoi_pd", "phê duyệt lần 0", "");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCDTAO_CT(string b_phong, string b_ma, string b_lan)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CCDTAO_CT(b_phong, b_ma, b_lan);
            bang.P_SO_CNG(ref b_dt, "ngayd,thoigian");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCDTAO_NH(double b_tinhtrang, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_tinhtrang > 0)
            {
                return Thongbao_dch.thaydoi_pheduyet;
            }
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,thoigian");
            DataTable b_dt_kq = ns_dt.P_NS_DT_MA_CCDTAO_NH(b_dt_ct);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đề xuất đào tạo cần phê duyệt";
                string b_body = "Bạn có đề xuất đào tạo cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri),
                   b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_nh_kq = Fs_NS_DT_MA_CCDTAO_MA(b_phong, b_ma, b_trangKT, a_cot_lke);
            return b_guimail + "#" + b_nh_kq;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCDTAO_XOA(string b_phong, string b_ma, string b_lan, double[] a_tso, string[] a_cot)
    {
        try
        { ns_dt.PNS_DT_MA_CCDTAO_XOA(b_phong, b_ma, b_lan); return Fs_NS_DT_MA_CCDTAO_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC CHỨNG CHỈ ĐÀO TẠO

    #region DANH MỤC LĨNH VỰC CHA
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_LKE(string b_luuday, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_LVCHA_LKE(b_luuday, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_LKE_A(string b_login, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_LVCHA_LKE_A();
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_MA(string b_luuday, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_LVCHA_MA(b_luuday, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_LVCHA_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_NH(string b_luuday, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_LVCHA_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_LVCHA_MA(b_luuday, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_XOA(string b_trangthai, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_dt.P_NS_DT_MA_LVCHA_XOA(b_ma); return Fs_NS_DT_MA_LVCHA_LKE(b_trangthai, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_TRA(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null)
            {
                return form.Fs_LOC_LOI("loi:Chưa chọn lĩnh vực đào tạo:loi");
            }
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            se.P_TG_LUU("DT_LVCHA", "DT_LVCHA", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCHA_LAY(string b_login, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA("DT_LVCHA", "DT_LVCHA");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC LĨNH VỰC CHA

    #region DANH MỤC LĨNH VỰC CON
    [WebMethod(true)]
    public string FS_NS_DT_MA_LVCON_LKE(string b_ma_cha, string b_luuday, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.FDT_NS_DT_MA_LVCON_LKE(b_ma_cha, b_luuday, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string FS_NS_DT_MA_LVCON_MA(string b_luuday, string b_ma_cha, string b_ma, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.FDT_NS_DT_MA_LVCON_MA(b_luuday, b_ma_cha, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCON_CT(string b_form, string b_ma)
    {
        try
        {

            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_LVCON_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_CHA", "MA_CHA");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string FS_NS_DT_MA_LVCON_NH(string b_login, string b_ma_cha, string b_luuday, double b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_LVCON_NH(ref b_so_id, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return FS_NS_DT_MA_LVCON_MA(b_luuday, b_ma_cha, b_ma, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string FS_NS_DT_MA_LVCON_XOA(string b_luuday, string b_ma_cha, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_MA_LVCON_XOA(b_so_id);
            return FS_NS_DT_MA_LVCON_LKE(b_ma_cha, b_luuday, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC LĨNH VỰC CON

    #region DANH MỤC KHÓA ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_LKE(object[] a_dt_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            bang.P_CSO_SO(ref b_dt_tk, "nam_tk");
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_KDTAO_LKE(b_dt_tk, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_LKE_GRCT(string b_nhom_nluc, string b_nluc, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_KDTAO_LKE_GRCT(b_nhom_nluc, b_nluc);
            DataTable b_dt = (DataTable)a_object[0];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_MA(double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_KDTAO_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_CT(string b_form, double b_so_id, string b_nnd, string[] a_cot_cd, string[] a_cot_dvi)
    {
        try
        {
            var b_ds = ns_dt.Fdt_NS_DT_MA_KDTAO_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy();
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NND", "NND");

            var b_dt_dv = ns_dt.Fdt_NS_DT_MA_NND_DV_DR(b_nnd);
            se.P_TG_LUU(b_form, "DT_NND_DV", b_dt_dv.Copy());
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NND_DV", "NND_DV");

            //var b_dt_ncd = b_ds.Tables[1].Copy(); 
            var b_dt_cd = b_ds.Tables[1].Copy();
            var b_dt_dvi = b_ds.Tables[2].Copy();
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_cd, a_cot_cd) + "#" + bang.Fs_BANG_CH(b_dt_dvi, a_cot_dvi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_NH(string b_login, double b_so_id, object[] a_dt, double b_trangKT, object[] a_dt_cd, object[] a_dt_dvi, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]);
            object[] a_gtri1 = (object[])a_dt_cd[1];
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            string[] a_cot3 = chuyen.Fas_OBJ_STR((object[])a_dt_dvi[0]);
            object[] a_gtri3 = (object[])a_dt_dvi[1];
            DataTable b_dt_dvi = bang.Fdt_TAO_THEM(a_cot3, a_gtri3);
            bang.P_BO_HANG(ref b_dt_cd, "ma", "");
            bang.P_BO_HANG(ref b_dt_dvi, "ma", "");
            ns_dt.P_NS_DT_MA_KDTAO_NH(ref b_so_id, b_dt, b_dt_cd, b_dt_dvi);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_KDTAO, TEN_BANG.NS_DT_MA_KDTAO);
            return Fs_NS_DT_MA_KDTAO_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDTAO_XOA(object[] a_dt_tk, double b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH_CT, ht_dungchung.KHOA_DT, b_ma, ref b_thongbao);
            if (b_tontai > 0)
            {
                return "loi:Mã nhóm đào tạo " + b_ma + " đã được sử dụng:loi";
            }
            ns_dt.PNS_DT_MA_KDTAO_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_KDTAO, TEN_BANG.NS_DT_MA_KDTAO);
            return Fs_NS_DT_MA_KDTAO_LKE(a_dt_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC KHÓA ĐÀO TẠO

    #region CHỨNG CHỈ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCHI_LKE(object[] a_dt_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CCHI_LKE(b_dt_tk, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCHI_MA(object[] a_dt_tk, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CCHI_MA(b_dt_tk, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCHI_CT(string b_form, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CCHI_CT(b_ma);
            string[] obj = bang.Fs_COL_MANG(b_dt, "lvcha");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LVCHA", "LVCHA");
            DataTable b_dt_lvcon = ns_dt.Fdt_NS_DT_MA_LVCON_DR(obj[0]);
            se.P_TG_LUU(b_form, "DT_LVCON", b_dt_lvcon.Copy());
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LVCON", "LVCON");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCHI_NH(object[] a_dt_tk, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CCHI_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_CCHI_MA(a_dt_tk, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CCHI_XOA(object[] a_dt_tk, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        { ns_dt.PNS_DT_MA_CCHI_XOA(b_ma); return Fs_NS_DT_MA_CCHI_LKE(a_dt_tk, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_LVCON_DR(string b_form, string b_lvcha)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_LVCON_DR(b_lvcha);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_LVCON", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion CHỨNG CHỈ ĐÀO TẠO

    #region DANH MỤC ĐỐI TÁC ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTAC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_DTAC_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTAC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_DTAC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTAC_CT(string b_ma, string[] a_cot_ct, string[] a_cot_lvcha)
    {
        try
        {
            var b_ds = ns_dt.Fdt_NS_DT_MA_DTAC_CT(b_ma);
            var b_dt = b_ds.Tables[0].Copy();
            var b_dt_ct = b_ds.Tables[1].Copy();
            var b_dt_lvcha = b_ds.Tables[2].Copy();
            bang.P_SO_CNG(ref b_dt_lvcha, "nsinh");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct) + "#" + bang.Fs_BANG_CH(b_dt_lvcha, a_cot_lvcha);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTAC_NH(string b_ma, object[] a_dt, double b_trangKT, object[] a_dt_ct, object[] a_dt_lvcha, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_lvcha[0]);
            object[] a_gtri1 = (object[])a_dt_lvcha[1];
            DataTable b_dt_lvcha = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            bang.P_CNG_SO(ref b_dt_lvcha, "nsinh");
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            if (b_dt_lvcha.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_dt.P_NS_DT_MA_DTAC_NH(b_dt, b_dt_ct, b_dt_lvcha);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_DTAC, TEN_BANG.NS_DT_MA_DTAC);
            return Fs_NS_DT_MA_DTAC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTAC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH_CT, ht_dungchung.DOITAC, b_ma, ref thongbao);
            if (b_tontai > 0) return "loi:Mã " + b_ma + " đã được sử dụng:loi";
            ns_dt.PNS_DT_MA_DTAC_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_DTAC, TEN_BANG.NS_DT_MA_DTAC);
            return Fs_NS_DT_MA_DTAC_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DTAC_LVDT(string b_dtac, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_DTAC_LVDT(b_dtac);
            DataTable b_dt = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC ĐỐI TÁC ĐÀO TẠO

    #region DANH MỤC GIÁO VIÊN ĐÀO TẠO BÊN NGOÀI
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NGOAI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NGOAI_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            b_dt_tk.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NGOAI_MA(string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NGOAI_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + chuyen.CSO_SO(b_so_id);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NGOAI_CT(string b_form, string b_so_id, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NGOAI_CT(b_so_id);
            DataTable b_dt = (DataTable)a_object[0];
            DataTable b_dt_cd = (DataTable)a_object[1];
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_DTAC", "DTAC");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_cd, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NGOAI_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_GV_NGOAI_NH(ref b_so_id, b_dt_ct);
            return Fs_NS_DT_MA_GV_NGOAI_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NGOAI_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_MA_GV_NGOAI_XOA(b_so_id);
            return Fs_NS_DT_MA_GV_NGOAI_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC GIÁO VIÊN ĐÀO TẠO BÊN NGOÀI

    #region DANH MỤC GIÁO VIÊN ĐÀO TẠO NỘI BỘ
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            //string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            //DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NOI_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            //bang.P_THAY_GTRI(ref b_dt, "ttr", "0", "Làm việc");
            //bang.P_THAY_GTRI(ref b_dt, "ttr", "1", "Nghỉ việc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_LKE_TK(string b_tt, string b_cap_gv, string b_loai_gv, double[] a_tso, string[] a_cot)
    {

        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NOI_LKE_TK(b_tt, b_cap_gv, b_loai_gv, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }

    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_MA(object[] a_dt_tk, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NOI_MA(b_dt_tk, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            //bang.P_THAY_GTRI(ref b_dt, "ttr", "0", "Làm việc");
            //bang.P_THAY_GTRI(ref b_dt, "ttr", "1", "Nghỉ việc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_CT(string b_form, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_GV_NOI_CT(b_ma);
            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_CHA", "lv_cha");
            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_KDT", "kdtao");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_NH(object[] a_dt_tk, string b_ma, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_GV_NOI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_GV_NOI, TEN_BANG.NS_DT_MA_GV_NOI);
            return Fs_NS_DT_MA_GV_NOI_MA(a_dt_tk, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_GV_NOI_XOA(object[] a_dt_tk, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_MA_GV_NOI_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_GV_NOI, TEN_BANG.NS_DT_MA_GV_NOI);
            return Fs_NS_DT_MA_GV_NOI_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC GIÁO VIÊN ĐÀO TẠO NỘI BỘ

    #region DANH MỤC CAM KẾT ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CKET_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CKET_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_hhluc");
            bang.P_SO_CSO(ref b_dt, "cp_tu,thgian_cket,cp_den");
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                if (b_dt.Rows[i]["cp_tu"].ToString() == "")
                {
                    b_dt.Rows[i]["cp_tu"] = 0;
                }
                if (b_dt.Rows[i]["thgian_cket"].ToString() == "")
                {
                    b_dt.Rows[i]["thgian_cket"] = 0;
                }
            }
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CKET_MA(string b_soid, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CKET_MA(b_soid, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_hhluc");
            bang.P_SO_CSO(ref b_dt, "cp_tu,thgian_cket,cp_den");
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                if (b_dt.Rows[i]["cp_tu"].ToString() == "")
                {
                    b_dt.Rows[i]["cp_tu"] = 0;
                }
                if (b_dt.Rows[i]["thgian_cket"].ToString() == "")
                {
                    b_dt.Rows[i]["thgian_cket"] = 0;
                }
            }
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_soid);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_soid.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CKET_CT(string b_form, double b_soid, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CKET_CT(b_soid);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_SO_CSO(ref b_dt, "cp_tu,cp_den");
            bang.P_SO_CNG(ref b_dt, "ng_hluc,ng_hhluc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CKET_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ng_hluc,ng_hhluc");
            bang.P_CSO_SO(ref b_dt, "cp_tu,cp_den,thgian_cket");
            bang.P_CSO_SO(ref b_dt, "cp_tu,cp_den,thgian_cket");
            ns_dt.P_NS_DT_MA_CKET_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CKET, TEN_BANG.NS_DT_MA_CKET);
            return Fs_NS_DT_MA_CKET_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CKET_XOA(double b_soid, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_MA_CKET_XOA(b_soid);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CKET, TEN_BANG.NS_DT_MA_CKET);
            return Fs_NS_DT_MA_CKET_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion DANH MỤC CAM KẾT ĐÀO TẠO

    #region DANH MỤC ĐÀO TẠO CHUẨN THEO CHỨC DANH

    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTC_CDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_DTC_CDANH_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTC_CDANH_MA(double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_DTC_CDANH_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTC_CDANH_CT(string b_form, string b_ma, string[] a_cot_ct, string[] a_cot_cdanh)
    {
        try
        {
            var b_ds = ns_dt.Fdt_NS_DT_MA_DTC_CDANH_CT(b_ma);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy(); var b_dt_cd = b_ds.Tables[2].Copy();
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_KDT", "KDT");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct) + "#" + bang.Fs_BANG_CH(b_dt_cd, a_cot_cdanh);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTC_CDANH_NH(string b_login, double b_so_id, object[] a_dt, double b_trangKT, object[] a_dt_ct, object[] a_dt_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "nluc");
            bang.P_CSO_SO(ref b_dt_ct, "muc_nluc");
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]);
            object[] a_gtri1 = (object[])a_dt_cd[1];
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            bang.P_DON_DK(ref b_dt_cd, new string[] { "ma_cd" });
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            if (b_dt_cd == null || b_dt_cd.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_cd.Rows.Count; i++)
            {
                if (b_dt_cd.Rows[i]["ma_cd"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            ns_dt.P_NS_DT_MA_DTC_CDANH_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_cd);
            return Fs_NS_DT_MA_DTC_CDANH_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_DTC_CDANH_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { ns_dt.PNS_DT_MA_DTC_CDANH_XOA(b_so_id); return Fs_NS_DT_MA_DTC_CDANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC ĐÀO TẠO CHUẨN THEO CHỨC DANH

    #region NHÓM DANH MỤC DÙNG CHUNG ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CHUNG_NHOM_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_NHOM_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CHUNG_NHOM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_NHOM_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CHUNG_NHOM_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_NHOM_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CHUNG_NHOM_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CHUNG_NHOM, TEN_BANG.NS_DT_MA_CHUNG_NHOM);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_CHUNG_NHOM_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_NHOM_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_MA_CHUNG_NHOM_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_CHUNG_NHOM, TEN_BANG.NS_DT_MA_CHUNG_NHOM);
            return Fs_NS_DT_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG ĐÀO TẠO

    #region DANH MỤC DÙNG CHUNG ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "NS_DT_MA_CHUNG", "DT_HS_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_LKE(string b_login, string b_form, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_NHOM_MA", "NHOM_MA");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_MA(string b_login, string b_form, string b_ma, string b_loai_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CHUNG_MA(b_ma, b_loai_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_NHOM_MA", "NHOM_MA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_CT(string b_form, string b_nhom_ma, string b_ma)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CHUNG_CT(b_nhom_ma, b_ma);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NHOM_MA", "NHOM_MA");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_NH(string b_login, string b_form, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CHUNG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CHUNG, TEN_BANG.NS_DT_MA_CHUNG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_loai_ma = chuyen.OBJ_S(mang.Fs_TEN_GTRI("nhom_ma", a_cot, a_gtri));
            return Fs_NS_DT_MA_CHUNG_MA(b_login, b_form, b_ma, b_loai_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_XOA(string b_login, string b_from, string b_ma, string b_loai_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_MA_CHUNG_XOA(b_ma, b_loai_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CHUNG, TEN_BANG.NS_DT_MA_CHUNG);
            return Fs_NS_DT_MA_CHUNG_LKE(b_login, b_from, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_PNS_DT_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion DANH MỤC DÙNG CHUNG ĐÀO TẠO

    #region DANH MỤC THAM SỐ HỆ THỐNG
    [WebMethod(true)]
    public string Fs_NS_DT_MA_TSO_HTHONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_TSO_HTHONG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_TSO_HTHONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_TSO_HTHONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_TSO_HTHONG_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_TSO_HTHONG_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_TSO_HTHONG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_TSO_HTHONG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_TSO_HTHONG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_HTHONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_MA_TSO_HTHONG_XOA(b_ma);
            return Fs_NS_DT_MA_TSO_HTHONG_LKE(a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    #endregion DANH MỤC THAM SỐ HỆ THỐNG

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CHA
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CHA_LKE(string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_CHA_LKE(b_tt, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CHA_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_CHA_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CHA_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CP_CHA_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_CP_CHA_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CHA_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_trangthai = "";
        try { ns_dt.P_NS_DT_MA_CP_CHA_XOA(b_ma); return Fs_NS_DT_MA_CP_CHA_LKE(b_trangthai, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CHA

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CON

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CON_LKE(string b_ma_cha, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_CON_LKE(b_ma_cha, b_tt, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["trangthai"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CON_MA(string b_ma_cha, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_CON_MA(b_ma_cha, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["trangthai"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CON_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CP_CON_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ma_cha = mang.Fs_TEN_GTRI("ma_cha", a_cot, a_gtri);
            return Fs_NS_DT_MA_CP_CON_MA(b_ma_cha, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_CON_XOA(string b_ma_cha, string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_trangthai = "";
        try { ns_dt.P_NS_DT_MA_CP_CON_XOA(b_ma_cha, b_ma); return Fs_NS_DT_MA_CP_CON_LKE(b_ma_cha, b_trangthai, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO CON

    #region ĐÁNH GIÁ KHÓA ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_DG_KDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_NGV_DG_KDT_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_DG_KDT_MA(string b_so_id, double b_trangKt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_NGV_DG_KDT_MA(b_so_id, b_trangKt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_DG_KDT_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_NGV_DG_KDT_CT(b_so_id);
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_DG_KDT_NH(string b_so_id, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_NGV_DG_KDT_NH(ref b_so_id, b_dt_ct);
            return Fs_NS_DT_NGV_DG_KDT_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_DG_KDT_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { ns_dt.PNS_DT_NGV_DG_KDT_XOA(b_so_id); return Fs_NS_DT_NGV_DG_KDT_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDT_DR(string b_form, double b_nam)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR(b_nam);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            se.P_TG_LUU(b_form, "DT_KDTTK", b_dt.Copy());

            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nam, string b_thang, string b_tt_lop)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_LKE(b_tu_n, b_den_n, b_nam, b_thang, b_tt_lop);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "12", "Tháng 12");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_Fdt_NS_DT_KH_CT_PD_LKE(string b_login, double[] a_tso, string[] a_cot, double b_nam, double b_thang, double b_tt_pd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]);
            double b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_PD_LKE(b_tu_n, b_den_n, b_nam, b_thang, b_tt_pd);
            DataTable b_dt = (DataTable)a_object[1];

            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            bang.P_SO_CSO(ref b_dt, "cphi_dk");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    private void P_FormatData_ns_dt_kh_ct(DataTable b_dt)
    {
        bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });

        bang.P_SO_CH(ref b_dt, "KH_NAM");
        bang.P_SO_CH(ref b_dt, "TT_PD");
        bang.P_SO_CH(ref b_dt, "TT_LOP");

        bang.P_THAY_GTRI(ref b_dt, "KH_NAM", "1", "C");
        bang.P_THAY_GTRI(ref b_dt, "KH_NAM", "0", "K");

        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "0", "Chưa gửi phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "1", "Chờ phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "2", "Được phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "3", "Không phê duyệt");

        bang.P_THAY_GTRI(ref b_dt, "TT_LOP", "1", "BT");
        bang.P_THAY_GTRI(ref b_dt, "TT_LOP", "0", "HUY");
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_MA(string b_login, string b_nam, string b_thang, string b_hinhthuc, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_LKE_MA(b_nam, b_thang, b_hinhthuc, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "THANG", "12", "Tháng 12");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            // hang + trang + so dong + data
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_CT(double b_so_id, string[] a_cot_lke_cp, string[] a_cot_lke_gv)
    {
        try
        {
            DataSet b_ds = ns_dt.Fds_NS_DT_KH_CT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];

            string b_kh_nam = b_dt.Rows[0]["kh_nam"].ToString();
            if (b_kh_nam == "X")
            {
                string b_nam = b_dt.Rows[0]["nam"].ToString(), b_thang = b_dt.Rows[0]["thang"].ToString();
                DataTable b_lke = ht_dungchung.Fdt_MA_KDT_KH_NAM(b_nam, b_thang);
                se.P_TG_LUU("ns_dt_kh_ct", "DT_NHUCAU", b_lke.Copy());
            }
            else
            {
                string b_nam = b_dt.Rows[0]["nam"].ToString(), b_noidung = b_dt.Rows[0]["nhom_nd"].ToString();
                DataTable b_lke = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, b_noidung);
                se.P_TG_LUU("ns_dt_kh_ct", "DT_KDT", b_lke.Copy());
            }

            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_KDT", "MA_KDT");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_NHUCAU", "MA_KDT_NHUCAU");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_DTAC", "doitac");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_THANG", "thang");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct", "DT_NND", "nhom_nd");
            DataTable b_dt_cp = b_ds.Tables[1];
            bang.P_SO_CSO(ref b_dt_cp, "stien");
            bang.P_SO_CSO(ref b_dt, "tong_cp,cp_hvien");
            DataTable b_dt_gv = b_ds.Tables[2];
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_cp) ? "" : bang.Fs_BANG_CH(b_dt_cp, a_cot_lke_cp)))
                + "#" + ((bang.Fb_TRANG(b_dt_gv) ? "" : bang.Fs_BANG_CH(b_dt_gv, a_cot_lke_gv)));

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    private void P_TinhChiPhiDaoTao(DataTable b_dt_cp)
    {
        // tính toán chi phí
        bang.P_THEM_COL(ref b_dt_cp, new string[] { "tong", "tong_hm", "NN" });
        double b_dgia, b_sluong, b_thue, b_tong;
        foreach (DataRow dr in b_dt_cp.Rows)
        {
            b_dgia = -1;
            if (dr["dgia"] != DBNull.Value && dr["sluong"] != DBNull.Value)
            {
                b_dgia = chuyen.OBJ_N(dr["dgia"]);
                b_sluong = chuyen.OBJ_N(dr["sluong"]);

                b_tong = b_dgia * b_sluong;
                dr["tong"] = b_tong;

                if (dr["thue"] != DBNull.Value)
                {
                    b_thue = chuyen.OBJ_N(dr["thue"]) / 100;
                    dr["tong_hm"] = b_tong + b_tong * b_thue;
                }
            }
        }

        bang.P_SO_CSO(ref b_dt_cp, new string[] { "dgia", "sluong", "thue", "tong", "tong_hm" });
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_NH(string b_login, string b_so_id, string b_nam, string b_thang, string b_hinhthuc, object[] a_dt, object[] a_dt_ct_cp, object[] a_dt_ct_gv, string[] a_cot_lke_cp, double b_trangkt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin KHDT CT
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CNG_SO(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            bang.P_CSO_SO(ref b_dt, "tong_cp,cp_hvien,thluong");
            // thông tin danh sách chi phi
            string[] a_cot_ct_cp = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cp[0]);
            object[] a_gtri_ct_cp = (object[])a_dt_ct_cp[1];
            DataTable b_dt_ct_cp;
            if (a_gtri_ct_cp == null)
                b_dt_ct_cp = bang.Fdt_TAO_BANG(a_cot_ct_cp, "SS");
            else
                b_dt_ct_cp = bang.Fdt_TAO_THEM(a_cot_ct_cp, a_gtri_ct_cp);
            //bang.P_BO_HANG(ref b_dt_ct_cp, "loai_cp", ""); 
            bang.P_CSO_SO(ref b_dt_ct_cp, "stien");
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct_gv[0]);
            object[] a_gtri1 = (object[])a_dt_ct_gv[1];
            DataTable b_dt_ct_gv = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            //bang.P_BO_HANG(ref b_dt_ct_gv, "loai_gv", "");
            ns_dt.Fs_NS_DT_KH_CT_NH(ref b_so_id, b_dt, b_dt_ct_cp, b_dt_ct_gv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_KH_CT, TEN_BANG.NS_DT_KH_CT);
            return Fs_NS_DT_KH_CT_MA(b_login, b_nam, b_thang, b_hinhthuc, b_so_id, b_trangkt, a_cot_lke);

            // return b_result[0] + "#" + b_result[1] + "#" + khdt_ct + "#" + ((bang.Fb_TRANG(b_dt_cp) ? "" : bang.Fs_BANG_CH(b_dt_cp, a_cot_lke_cp)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot, string b_nam, string b_thang, string b_hinhthuc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_ns_dt_kh_ct_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_KH_CT, TEN_BANG.NS_DT_KH_CT);
            string a = this.Fs_NS_DT_KH_CT_LKE(b_login, a_tso, a_cot, b_nam, b_thang, b_hinhthuc);
            return a;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_ns_dt_kh_ct_kdt(string b_login, double b_nam, double b_thang, string b_ma, double b_kh_nam)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fds_ns_dt_kh_ct_kdt(b_nam, b_thang, b_ma, b_kh_nam);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_ns_dt_kh_ct_kdt_lke(string b_login, string b_nam, double b_thang, double b_kh_nam, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fds_ns_dt_kh_ct_kdt_lke(chuyen.CSO_SO(b_nam), b_thang, b_kh_nam);
            se.P_TG_LUU(b_formName, "DT_DM_KDT", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_LKE_GVIEN(string b_ma_dtac, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_LKE_GVIEN(b_ma_dtac);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_THAY_GTRI(ref b_dt, "LOAI_GV", "1", "Đối tác");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_KH_NAM_CT(string b_nam, string b_thang, string b_kdt)
    {
        try
        {
            string b_hinhthuc = "", b_diadiem = "", b_so_hv = "", b_tluong = "", b_ma_lop = "", b_nhom_nd = "";
            object[] a_object = ns_dt.Fdt_NS_KH_NAM_CT(b_nam, b_thang, b_kdt);
            DataTable b_dt = (DataTable)a_object[0];
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_hinhthuc = b_dt.Rows[0]["hthuc"].ToString();
                b_diadiem = b_dt.Rows[0]["ddiem"].ToString();
                b_so_hv = b_dt.Rows[0]["so_hv"].ToString();
                b_tluong = b_dt.Rows[0]["thoiluong"].ToString();
                b_ma_lop = ht_dungchung.Fdt_AutoGenCode(b_kdt, "NS_DT_KH_CT", "MA_LOP");
                b_nhom_nd = b_dt.Rows[0]["nhom_nd"].ToString() + "{" + b_dt.Rows[0]["ten_nd"].ToString();
            }
            return b_hinhthuc + "#" + b_diadiem + "#" + b_so_hv + "#" + b_tluong + "#" + b_ma_lop + "#" + b_nhom_nd;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region QUẢN LÝ DỮ LIỆU ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_NGV_QLDL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.PNS_DT_NGV_QLDL_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayqd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGV_QLDL_MA(string b_soqd, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_NGV_QLDL_MA(b_soqd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayqd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "soqd", b_soqd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NGV_QLDL_CT(string b_soqd, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_dt.PNS_DT_NGV_QLDL_CT(b_soqd);
            bang.P_SO_CNG(ref b_dt, "ngayqd"); bang.P_SO_CSO(ref b_dt, "mucthuong");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq + "#" + b_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NGV_QLDL_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayqd");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            ns_dt.PNS_DT_NGV_QLDL_NH(b_dt, b_dt_ct);
            string b_soqd = mang.Fs_TEN_GTRI("soqd", a_cot, a_gtri);
            return Fs_NS_DT_NGV_QLDL_MA(b_soqd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NGV_QLDL_XOA(string b_soqd, string b_ngayqd, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_NGV_QLDL_XOA(b_soqd, b_ngayqd); return Fs_NS_DT_NGV_QLDL_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion QUẢN LÝ DỮ LIỆU ĐÀO TẠO

    #region DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];

            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_CP_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");

            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_MA_CP_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_CP_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CP_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_MA_CP_XOA(b_ma);
            return Fs_NS_DT_MA_CP_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_THONGTIN_MA_CP_LUOI(string b_ma)
    {
        var b_dt = ns_dt.Fdt_NS_DT_MA_CP_MA_CT(b_ma);
        string svalue = "";
        if (!bang.Fb_TRANG(b_dt))
            svalue = b_dt.Rows[0]["ma"] + "#" + b_dt.Rows[0]["ten"];

        return svalue;
    }

    #endregion DANH MỤC HẠNG MỤC CHI PHÍ ĐÀO TẠO

    #region DANH MỤC MÔN HỌC ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_MA_MON_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_MON_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_MON_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_MON_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "tt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_MON_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            ns_dt.P_NS_DT_MA_MON_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_MON_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_MON_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_MA_MON_XOA(b_ma);
            return Fs_NS_DT_MA_MON_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_MON_CT_LUOI(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_MON_MA_CT(b_ma); ;
            string svalue = "";
            if (!bang.Fb_TRANG(b_dt))
                svalue = b_dt.Rows[0]["ma"].ToString() + (char)1 + b_dt.Rows[0]["ten"].ToString() + (char)1 + b_dt.Rows[0]["mota"].ToString();

            return svalue;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion DANH MỤC MÔN HỌC ĐÀO TẠO

    #region DANH SÁCH MÔN THI THUỘC KHÓA ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_MON_LKE(string b_login, double b_so_id_kh, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_MON_LKE(b_so_id_kh);
            bang.P_SO_CNG(ref b_dt, "ngay_thi");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_MON_NH(string b_login, double b_so_id_kh, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "ma", "");
            bang.P_THAY_GTRI(ref b_dt, "tr_so", "", "1");
            bang.P_CSO_SO(ref b_dt, "tr_so");
            bang.P_CNG_SO(ref b_dt, "ngay_thi");

            string b_loi = ns_dt.P_NS_DT_KH_CT_MON_NH(b_so_id_kh, b_dt);
            if (b_loi == "")
                return Fs_NS_DT_KH_CT_MON_LKE(b_login, b_so_id_kh, a_cot_lke);
            else
                return form.Fs_LOC_LOI(b_loi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_MON_XOA(string b_login, double b_so_id_kh)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_KH_CT_MON_XOA(b_so_id_kh);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    #endregion DANH SÁCH MÔN THI THUỘC KHÓA ĐÀO TẠO

    #region QUẢN LÝ DỮ LIỆU ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_QLDL_LKE(string b_ma_kh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_QLDL_LKE(b_ma_kh, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QLDL_MA(string b_so_id, double b_trangKt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_QLDL_MA(b_so_id, b_trangKt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QLDL_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_QLDL_CT(b_so_id);
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QLDL_NH(string b_so_id, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dt.P_NS_DT_QLDL_NH(ref b_so_id, b_dt_ct);
            return Fs_NS_DT_QLDL_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QLDL_XOA(string b_ma_kh, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.PNS_DT_QLDL_XOA(b_so_id); return Fs_NS_DT_QLDL_LKE(b_ma_kh, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion QUẢN LÝ DỮ LIỆU ĐÀO TẠO

    #region THỜI KHÓA BIỂU KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    /// <summary>
    /// danh sách ngày học
    /// </summary>
    /// <param name="b_so_id_kh"></param>
    /// <returns></returns>
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_NGAY_LKE(string b_login, double b_so_id_kh)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_TKB_NGAY_LKE(b_so_id_kh);
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_COPY_COL(ref b_dt, "ma", "ngay");
            bang.P_COPY_COL(ref b_dt, "ten", "ngay");
            se.P_TG_LUU("ns_dt_kh_ct_tkb", "DT_KH_TKB", b_dt);
            string[] a_cot = new string[] { "ma", "ten" };
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    /// <summary>
    /// danh sách nội dung TKB một ngày
    /// </summary>
    /// <param name="b_so_id_kh"></param>
    /// <param name="b_ngay"></param>
    /// <param name="a_tso"></param>
    /// <param name="a_cot"></param>
    /// <returns></returns>
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_LKE(string b_login, double b_so_id_kh, double b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_TKB_LKE(b_so_id_kh, b_ngay, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_MA(string b_login, double b_so_id_kh, double b_ngay, string b_gio_d, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_KH_CT_TKB_MA(b_so_id_kh, b_ngay, b_gio_d, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            int b_hang = bang.Fi_TIM_ROW(b_dt, "gio_d", b_gio_d);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_NH(string b_login, double b_so_id, double b_so_id_kh, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay");
            bool b_taoNgayMoi;
            ns_dt.P_NS_DT_KH_CT_TKB_NH(b_so_id, b_so_id_kh, b_dt_ct, out b_taoNgayMoi);
            //DateTime b_ngay = mang.Fd_TEN_GTRI("ngay", a_cot, a_gtri);
            double b_ngay = double.Parse(b_dt_ct.Rows[0]["ngay"].ToString());
            string b_gio_d = mang.Fs_TEN_GTRI("gio_d", a_cot, a_gtri);
            string b_ngayDaoTao = "";
            if (b_taoNgayMoi)
            {
                b_ngayDaoTao = this.Fs_NS_DT_KH_CT_TKB_NGAY_LKE(b_login, b_so_id_kh);
            }
            return Fs_NS_DT_KH_CT_TKB_MA(b_login, b_so_id_kh, b_ngay, b_gio_d, b_trangKT, a_cot_lke) + "#" + b_ngayDaoTao + "#" + (b_taoNgayMoi ? "1" : "0");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_XOA(string b_login, double b_so_id_kh, double b_ngay, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_KH_CT_TKB_XOA(b_so_id_kh, b_ngay, b_so_id);
            return Fs_NS_DT_KH_CT_TKB_LKE(b_login, b_so_id_kh, b_ngay, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_TKB_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CH(ref b_dt, "LOAI_GV");
            bang.P_THAY_GTRI(ref b_dt, "LOAI_GV", "1", "NB");
            bang.P_THAY_GTRI(ref b_dt, "LOAI_GV", "0", "NG");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_kh_ct_tkb", "DT_MA_LHGD", "MA_LHGD");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_TKB_DOI(string b_login, double b_so_id_kh, double b_ngay_cu, double b_ngay_moi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_KH_CT_TKB_DOI(b_so_id_kh, b_ngay_cu, b_ngay_moi);
            return this.Fs_NS_DT_KH_CT_TKB_NGAY_LKE(b_login, b_so_id_kh);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion THỜI KHÓA BIỂU KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region TRIỂN KHAI LỚP ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_TK_CT(string b_login, double b_so_id_kh, string[] a_cot_lke_cp)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_dt.Fds_NS_DT_TK_CT(b_so_id_kh);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_cp = b_ds.Tables[1];
            double b_so_id = 0;
            if (b_dt.Rows.Count > 0 && b_dt.Rows[0]["so_id_tk"] != DBNull.Value)
            {
                b_so_id = Convert.ToDouble(b_dt.Rows[0]["so_id_tk"]);
                if (b_dt.Rows[0]["ngay_d_tt"] != DBNull.Value)
                    b_dt.Rows[0]["ngay_d"] = b_dt.Rows[0]["ngay_d_tt"];
                if (b_dt.Rows[0]["ngay_c_tt"] != DBNull.Value)
                    b_dt.Rows[0]["ngay_c"] = b_dt.Rows[0]["ngay_c_tt"];
            }
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            this.P_TinhChiPhiDaoTao(b_dt_cp);
            bang.P_SO_CSO(ref b_dt_cp, "cp_tt");

            return b_so_id + "#" + ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_cp) ? "" : bang.Fs_BANG_CH(b_dt_cp, a_cot_lke_cp)));

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_TK_NH(string b_login, double b_so_id, double b_so_id_kh, object[] a_dt, object[] a_dt_ct_cp, string[] a_cot_lke_cp)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin tk
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CNG_SO(ref b_dt, new string[] { "ngay_d", "ngay_c" });

            // thông tin danh sách chi phi
            string[] a_cot_ct_cp = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cp[0]);
            object[] a_gtri_ct_cp = (object[])a_dt_ct_cp[1];
            DataTable b_dt_ct_cp;
            if (a_gtri_ct_cp == null)
                b_dt_ct_cp = bang.Fdt_TAO_BANG(a_cot_ct_cp, "SS");
            else
                b_dt_ct_cp = bang.Fdt_TAO_THEM(a_cot_ct_cp, a_gtri_ct_cp);
            bang.P_BO_HANG(ref b_dt_ct_cp, "ma_cp", "");

            bang.P_THAY_GTRI(ref b_dt_ct_cp, "sluong", "", "1");
            bang.P_CSO_SO(ref b_dt_ct_cp, "dgia");
            bang.P_CSO_SO(ref b_dt_ct_cp, "sluong");
            bang.P_CSO_SO(ref b_dt_ct_cp, "thue");
            bang.P_CSO_SO(ref b_dt_ct_cp, "cp_tt");

            b_so_id = ns_dt.Fn_NS_DT_TK_NH(b_so_id, b_so_id_kh, b_dt, b_dt_ct_cp);
            return b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_TK_XOA(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_TK_LKE_KDT(string b_login, double b_nam, double b_thang, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TK_LKE_KDT(b_nam, b_thang);
            se.P_TG_LUU(b_formName, "DT_KDT", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_LKE_LOP(string b_login, double b_nam, double b_thang, string b_ma_kdt, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TK_LKE_LOP(b_nam, b_thang, b_ma_kdt);
            se.P_TG_LUU(b_formName, "DT_LOPDT", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_LOP_CT(string b_login, double b_so_id_kh)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TK_LOP_CT(b_so_id_kh);
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion TRIỂN KHAI LỚP ĐÀO TẠO

    #region THỜI KHÓA BIỂU TRIỂN KHAI LỚP ĐÀO TẠO

    /// <summary>
    /// danh sách ngày học
    /// </summary>
    /// <param name="b_so_id_kh"></param>
    /// <returns></returns>
    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_NGAY_LKE(string b_login, double b_so_id_tk)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TK_TKB_NGAY_LKE(b_so_id_tk);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    /// <summary>
    /// danh sách nội dung TKB một ngày
    /// </summary>
    /// <param name="b_so_id_kh"></param>
    /// <param name="b_ngay"></param>
    /// <param name="a_tso"></param>
    /// <param name="a_cot"></param>
    /// <returns></returns>
    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_LKE(string b_login, double b_so_id_tk, double b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_TK_TKB_LKE(b_so_id_tk, b_ngay, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_MA(string b_login, double b_so_id_tk, double b_ngay, string b_gio_d, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_TK_TKB_MA(b_so_id_tk, b_ngay, b_gio_d, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            int b_hang = bang.Fi_TIM_ROW(b_dt, "gio_d", b_gio_d);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_NH(string b_login, double b_so_id, double b_so_id_tk, double b_trangKT, bool b_taoNgayMoi, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay");

            ns_dt.P_NS_DT_TK_TKB_NH(b_so_id, b_so_id_tk, b_dt_ct);
            //DateTime b_ngay = mang.Fd_TEN_GTRI("ngay", a_cot, a_gtri);
            double b_ngay = double.Parse(b_dt_ct.Rows[0]["ngay"].ToString());
            string b_gio_d = mang.Fs_TEN_GTRI("gio_d", a_cot, a_gtri);
            string b_ngayDaoTao = "";
            if (b_taoNgayMoi)
            {
                b_ngayDaoTao = this.Fs_NS_DT_TK_TKB_NGAY_LKE(b_login, b_so_id_tk);
            }
            return Fs_NS_DT_TK_TKB_MA(b_login, b_so_id_tk, b_ngay, b_gio_d, b_trangKT, a_cot_lke) + "#" + b_ngayDaoTao;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_XOA(string b_login, double b_so_id_tk, double b_ngay, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_TKB_XOA(b_so_id_tk, b_ngay, b_so_id);
            return Fs_NS_DT_TK_TKB_LKE(b_login, b_so_id_tk, b_ngay, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TK_TKB_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_SO_CH(ref b_dt, "LOAI_GV");
            bang.P_THAY_GTRI(ref b_dt, "LOAI_GV", "1", "NB");
            bang.P_THAY_GTRI(ref b_dt, "LOAI_GV", "0", "NG");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_tk_tkb", "DT_MA_LGV", "LGV");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_NGAY_COPY_KH(string b_login, double b_so_id_tk)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_TKB_NGAY_COPY_KH(b_so_id_tk);
            return this.Fs_NS_DT_TK_TKB_NGAY_LKE(b_login, b_so_id_tk);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_TKB_DOI(string b_login, double b_so_id_tk, double b_ngay_cu, double b_ngay_moi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_TKB_DOI(b_so_id_tk, b_ngay_cu, b_ngay_moi);
            return this.Fs_NS_DT_TK_TKB_NGAY_LKE(b_login, b_so_id_tk);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion THỜI KHÓA BIỂU TRIỂN KHAI LỚP ĐÀO TẠO

    #region ĐIỂM DANH LỚP ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DD_LKE(string b_login, double b_so_id_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fobj_NS_DT_TK_DD_LKE(b_so_id_tk, b_tu_n, b_den_n);
            DataTable b_dt_hv = (DataTable)a_object[1];
            DataTable b_dt_tkb = (DataTable)a_object[2];
            DataTable b_dt_dd = (DataTable)a_object[3];
            DataTable b_dt_kq = (DataTable)a_object[4];
            string b_cot_dd;
            foreach (DataRow drTkb in b_dt_tkb.Rows)
            {
                b_cot_dd = drTkb["so_id"].ToString();
                bang.P_THEM_COL(ref b_dt_hv, b_cot_dd, typeof(string));
            }
            bang.P_THEM_COL(ref b_dt_hv, "tl", typeof(double));
            bang.P_THEM_COL(ref b_dt_hv, "kq", typeof(string));
            bang.P_THEM_COL(ref b_dt_hv, "ghichu", typeof(string));
            string b_so_id_tkb;
            string a_so_id_tkb = bang.Fs_COT_CH(b_dt_tkb, "so_id", ",");

            foreach (DataRow drHV in b_dt_hv.Rows)
            {
                foreach (DataRow drTkb in b_dt_tkb.Rows)
                {
                    b_so_id_tkb = drTkb["so_id"].ToString();
                    DataRow[] drs = b_dt_dd.Select("so_id_tkb = " + b_so_id_tkb + " and so_the = '" + drHV["so_the"] + "'");
                    if (drs.Length > 0)
                    {
                        drHV[b_so_id_tkb] = drs[0]["tt"];
                    }
                }
                DataRow[] drsKQ = b_dt_kq.Select("so_the = '" + drHV["so_the"] + "'");
                if (drsKQ.Length > 0)
                {
                    drHV["tl"] = drsKQ[0]["tl"];
                    drHV["kq"] = drsKQ[0]["kq"];
                    drHV["ghichu"] = drsKQ[0]["ghichu"];
                }
            }

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_hv, a_cot) + "#" + a_so_id_tkb;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DD_NH(string b_login, double b_so_id_tk, string[] b_so_id_tkb, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin danh sách điểm danh
            string[] a_cot_dd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_dd = (object[])a_dt_ct[1];
            DataTable b_dt_dd;
            if (a_gtri_dd == null)
                b_dt_dd = bang.Fdt_TAO_BANG(a_cot_dd, "SS");
            else
                b_dt_dd = bang.Fdt_TAO_THEM(a_cot_dd, a_gtri_dd);
            bang.P_BO_HANG(ref b_dt_dd, "so_the", "");

            bang.P_CSO_SO(ref b_dt_dd, "tl");

            bang.P_THEM_COL(ref b_dt_dd, "tt", typeof(string));

            string b_tt;
            foreach (DataRow dr in b_dt_dd.Rows)
            {
                b_tt = "";
                for (int i = 0; i < b_so_id_tkb.Length; i++)
                {
                    b_tt += (dr[b_so_id_tkb[i]].ToString() != "" ? dr[b_so_id_tkb[i]].ToString() : "#") + ",";
                }
                if (b_tt != "")
                    b_tt = b_tt.Substring(0, b_tt.Length - 1);
                dr["tt"] = b_tt;
            }
            object[] a_so_id_tkb = new object[b_so_id_tkb.Length];
            for (var i = 0; i < a_so_id_tkb.Length; i++)
                a_so_id_tkb[i] = double.Parse(b_so_id_tkb[i]);

            ns_dt.Fn_NS_DT_TK_DD_NH(b_so_id_tk, a_so_id_tkb, b_dt_dd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DD_XOA(string b_login, double b_so_id_tk)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_DD_XOA(b_so_id_tk);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐIỂM DANH LỚP ĐÀO TẠO

    #region CẬP NHẬT KẾT QUẢ ĐÀO TẠO HỌC VIÊN

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DIEM_LKE(string b_login, double b_so_id_kh, int b_so_mon_max, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fobj_NS_DT_TK_DIEM_LKE(b_so_id_kh, b_tu_n, b_den_n);
            DataTable b_dt_hv = (DataTable)a_object[2];
            DataTable b_dt_mon = (DataTable)a_object[3];
            DataTable b_dt_diem = (DataTable)a_object[4];
            DataTable b_dt_kq = (DataTable)a_object[5];
            string b_cot_ngay, b_cot_diem, b_cot_tr_so, b_ma_mon;
            for (int i = 0; i < b_so_mon_max; i++)
            {
                //b_ds_mon += b_dt_mon.Rows[i]["ma_mon"].ToString() + (char)1;
                b_cot_ngay = "ngay_thi_" + i;
                b_cot_diem = "diem_" + i;
                b_cot_tr_so = "tr_so_" + i;

                bang.P_THEM_COL(ref b_dt_hv, b_cot_ngay, typeof(string));
                bang.P_THEM_COL(ref b_dt_hv, b_cot_diem, typeof(double));
                bang.P_THEM_COL(ref b_dt_hv, b_cot_tr_so, typeof(double));
            }
            string b_ds_maMon = bang.Fs_COT_CH(b_dt_mon, "ma_mon", ((char)1).ToString());
            string b_ds_tenMon = bang.Fs_COT_CH(b_dt_mon, "ten", ((char)1).ToString());
            //if (b_ds_mon != "") b_ds_mon = b_ds_mon.Substring(0, b_ds_mon.Length - 1);

            bang.P_THEM_COL(ref b_dt_hv, "dtb", typeof(string));
            bang.P_THEM_COL(ref b_dt_hv, "kq", typeof(string));
            bang.P_THEM_COL(ref b_dt_hv, "cp_htro", typeof(double));
            bang.P_SO_CNG(ref b_dt_mon, "ngay_thi");
            bang.P_SO_CNG(ref b_dt_diem, "ngay_thi");

            foreach (DataRow drHV in b_dt_hv.Rows)
            {
                for (int i = 0; i < b_dt_mon.Rows.Count; i++)
                {
                    b_cot_ngay = "ngay_thi_" + i;
                    b_cot_diem = "diem_" + i;
                    b_cot_tr_so = "tr_so_" + i;

                    b_ma_mon = b_dt_mon.Rows[i]["ma_mon"].ToString();
                    DataRow[] drs = b_dt_diem.Select("ma_mon = '" + b_ma_mon + "' and so_the = '" + drHV["so_the"] + "'");
                    if (drs.Length > 0)
                    {
                        drHV[b_cot_diem] = drs[0]["diem"];
                        drHV[b_cot_ngay] = drs[0]["ngay_thi"];
                    }
                    else
                    {
                        drHV[b_cot_ngay] = b_dt_mon.Rows[i]["ngay_thi"];
                    }
                    drHV[b_cot_tr_so] = b_dt_mon.Rows[i]["tr_so"];
                }
                DataRow[] drsKQ = b_dt_kq.Select("so_the = '" + drHV["so_the"] + "'");
                if (drsKQ.Length > 0)
                {
                    drHV["dtb"] = drsKQ[0]["dtb"];
                    drHV["kq"] = drsKQ[0]["kq"];
                    drHV["cp_htro"] = drsKQ[0]["cp_htro"];
                }
            }

            // số dòng + so_id_tk + dữ liệu điểm + danh sách mã môn học
            return chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_hv, a_cot) + "#" + b_ds_maMon + "#" + b_ds_tenMon;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DIEM_NH(string b_login, double b_so_id_kh, double b_so_id_tk, string[] a_ma_mon, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin chi phí
            object[] a_chiPhi = ns_dt.Fobj_NS_DT_TK_CP(b_so_id_kh, b_so_id_tk);
            double b_tongChiPhi = Convert.ToDouble(a_chiPhi[0].ToString());
            int b_tongHV = Convert.ToInt32(a_chiPhi[1].ToString());

            // thông tin danh sách điểm
            string[] a_cot_diem = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_diem = (object[])a_dt_ct[1];
            DataTable b_dt_diem;
            if (a_gtri_diem == null)
                b_dt_diem = bang.Fdt_TAO_BANG(a_cot_diem, "SS");
            else
                b_dt_diem = bang.Fdt_TAO_THEM(a_cot_diem, a_gtri_diem);
            bang.P_BO_HANG(ref b_dt_diem, "so_the", "");

            bang.P_CSO_SO(ref b_dt_diem, "dtb");
            bang.P_CSO_SO(ref b_dt_diem, "cp_htro");

            bang.P_THEM_COL(ref b_dt_diem, "diem", typeof(string));
            bang.P_THEM_COL(ref b_dt_diem, "ngay_thi", typeof(string));
            bang.P_THEM_COL(ref b_dt_diem, "cp_tt", typeof(double)); // cột chi phí thực tế

            string b_diem, b_ngay_thi;
            string b_cot_ngay, b_cot_diem;
            double b_trong_so, b_tongDiem, b_tongTrongSo, b_chiPhiFull1HV = b_tongChiPhi / b_tongHV, b_chiPhi1HV;
            foreach (DataRow dr in b_dt_diem.Rows)
            {
                b_diem = "";
                b_ngay_thi = "";
                b_tongDiem = 0; b_tongTrongSo = 0;
                for (int i = 0; i < a_ma_mon.Length; i++)
                {
                    b_cot_ngay = "ngay_thi_" + i;
                    b_cot_diem = "diem_" + i;

                    if (dr[b_cot_diem].ToString() != "")
                    {
                        b_trong_so = chuyen.CSO_SO(dr["tr_so_" + i].ToString());
                        b_tongDiem += chuyen.CSO_SO(dr[b_cot_diem].ToString()) * b_trong_so;
                        b_tongTrongSo += b_trong_so;
                    }

                    b_diem += (dr[b_cot_diem].ToString() != "" ? dr[b_cot_diem].ToString() : "#") + ",";
                    b_ngay_thi += chuyen.CNG_CSO(dr[b_cot_ngay].ToString()) + ","; //(dr[b_cot_ngay].ToString() != "" ? chuyen.CNG_CSO(dr[b_cot_ngay].ToString()) : "#") + ",";
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
                b_chiPhi1HV = b_chiPhiFull1HV * Convert.ToDouble(dr["cp_htro"]) / 100;
                dr["cp_tt"] = b_chiPhi1HV;
            }

            ns_dt.Fn_NS_DT_TK_DIEM_NH(b_so_id_tk, a_ma_mon, b_dt_diem);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TK_DIEM_XOA(string b_login, double b_so_id_tk)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_dt.P_NS_DT_TK_DIEM_XOA(b_so_id_tk);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion CẬP NHẬT KẾT QUẢ ĐÀO TẠO HỌC VIÊN

    #region TUYỂN SINH HỌC VIÊN

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_LKE_DR(string b_login, double b_nam, double b_thang, double b_tt_pd, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_LKE_DR(b_nam, b_thang, b_tt_pd);
            se.P_TG_LUU(b_formName, "DT_KDT", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_LOP_LKE_DR(string b_login, string b_ma_kdt, double b_nam, double b_thang, double b_tt_pd, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_KH_CT_LOP_LKE_DR(b_ma_kdt, b_nam, b_thang, b_tt_pd);
            se.P_TG_LUU(b_formName, "DT_KDT_LOP", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_LKE(string b_login, double b_so_id_kh, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_dt.Fds_NS_DT_TS_LKE(b_so_id_kh);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_hv = b_ds.Tables[1];

            this.P_NS_DT_TS_FORMAT(b_dt_hv);

            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0))) + "#" + b_dt_hv.Rows.Count
                + "#" + ((bang.Fb_TRANG(b_dt_hv) ? "" : bang.Fs_BANG_CH(b_dt_hv, a_cot_lke)));

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_HV_LKE(string b_login, double b_so_id_kh, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fds_NS_DT_TS_HV_LKE(b_so_id_kh);
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_lke))) + "#" + b_dt.Rows.Count;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_TONGHOP(string b_login, double b_so_id_kh, string b_ma_kdt, double b_nam, double b_thang, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fobj_NS_DT_TS_TONGHOP(b_so_id_kh, b_ma_kdt, b_nam, b_thang, b_tu_n, b_den_n);
            DataTable b_dt_hv = (DataTable)a_object[1];
            this.P_NS_DT_TS_FORMAT(b_dt_hv);
            // số dòng + danh sách tuyển sinh
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_hv, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private void P_NS_DT_TS_FORMAT(DataTable b_dt_hv)
    {
        bang.P_THEM_COL(ref b_dt_hv, "chon", "");
        bang.P_SO_CNG(ref b_dt_hv, "ngaydk");

        bang.P_COPY_COL(ref b_dt_hv, "ten_loai_ts", "loai_ts");
        bang.P_SO_CSO(ref b_dt_hv, "ten_loai_ts");
        bang.P_THAY_GTRI(ref b_dt_hv, "ten_loai_ts", "1", "Tự đề xuất");
        bang.P_THAY_GTRI(ref b_dt_hv, "ten_loai_ts", "2", "QL đề xuất");
        bang.P_THAY_GTRI(ref b_dt_hv, "ten_loai_ts", "3", "Thêm ngoài");
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_NH(string b_login, double b_so_id_kh, object[] a_dt, string b_ma_kdt, double b_nam, double b_thang, double[] a_tso, string[] a_cot_lke, string b_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "so_the", "");
            bang.P_CSO_SO(ref b_dt, "so_id_dx");
            bang.P_CNG_SO(ref b_dt, "ngaydk");

            string b_loi = ns_dt.P_NS_DT_TS_NH(b_so_id_kh, b_dt);
            if (b_loi == "")
            {
                if (b_nv == "TONGHOP")
                    return Fs_NS_DT_TS_TONGHOP(b_login, b_so_id_kh, b_ma_kdt, b_nam, b_thang, a_tso, a_cot_lke);
                else
                    return Fs_NS_DT_TS_LKE(b_login, b_so_id_kh, a_cot_lke);
            }
            else
                return form.Fs_LOC_LOI(b_loi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_XOA(string b_login, double b_so_id_kh, object[] a_dt, string b_ma_kdt, double b_nam, double b_thang, double[] a_tso, string[] a_cot_lke, string b_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt;
            if (a_gtri == null)
                b_dt = bang.Fdt_TAO_BANG(a_cot, "SS");
            else
                b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            string b_loi = ns_dt.P_NS_DT_TS_XOA(b_so_id_kh, b_dt);
            if (b_loi == "")
            {
                if (b_nv == "TONGHOP")
                    return Fs_NS_DT_TS_TONGHOP(b_login, b_so_id_kh, b_ma_kdt, b_nam, b_thang, a_tso, a_cot_lke);
                else
                    return Fs_NS_DT_TS_LKE(b_login, b_so_id_kh, a_cot_lke);
            }
            else
                return form.Fs_LOC_LOI(b_loi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_NV_DVI_LKE(string b_login, double b_so_id_kh, string b_ma_phong, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TS_NV_DVI_LKE(b_so_id_kh, b_ma_phong);
            bang.P_THEM_COL(ref b_dt, "chon", "");
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_lke))) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_THEM_LKE(string b_login, double b_so_id_kh, DateTime b_ngay_ht, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_TS_THEM_LKE(b_so_id_kh, b_ngay_ht);
            bang.P_THEM_COL(ref b_dt, "chon", "");
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_lke))) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_THEM_NH(string b_login, double b_so_id_kh, object[] a_dt, string b_ma_phong, DateTime b_ngay_ht, string[] a_cot_lke_nv, string[] a_cot_lke_ts)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt;
            if (a_gtri == null)
                b_dt = bang.Fdt_TAO_BANG(a_cot, "SS");
            else
                b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            string b_loi = ns_dt.P_NS_DT_TS_THEM_NH(b_so_id_kh, b_dt);
            if (b_loi == "")
            {
                // danh sách nhân viên thuộc phòng
                string b_nv = this.Fs_NS_DT_TS_NV_DVI_LKE(b_login, b_so_id_kh, b_ma_phong, a_cot_lke_nv);
                // danh sách vừa thêm
                string b_ts = this.Fs_NS_DT_TS_THEM_LKE(b_login, b_so_id_kh, b_ngay_ht, a_cot_lke_ts);
                return b_nv + "#" + b_ts;
            }
            else
                return form.Fs_LOC_LOI(b_loi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TS_THEM_XOA(string b_login, double b_so_id_kh, object[] a_dt, string b_ma_phong, DateTime b_ngay_ht, string[] a_cot_lke_nv, string[] a_cot_lke_ts)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt;
            if (a_gtri == null)
                b_dt = bang.Fdt_TAO_BANG(a_cot, "SS");
            else
                b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            string b_loi = ns_dt.P_NS_DT_TS_XOA(b_so_id_kh, b_dt);
            if (b_loi == "")
            {
                // danh sách nhân viên thuộc phòng
                string b_nv = this.Fs_NS_DT_TS_NV_DVI_LKE(b_login, b_so_id_kh, b_ma_phong, a_cot_lke_nv);
                // danh sách vừa thêm
                string b_ts = this.Fs_NS_DT_TS_THEM_LKE(b_login, b_so_id_kh, b_ngay_ht, a_cot_lke_ts);
                return b_nv + "#" + b_ts;
            }
            else
                return form.Fs_LOC_LOI(b_loi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }



    #endregion TUYỂN SINH HỌC VIÊN

    #region NHÓM NỘI DUNG
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_NND_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_NND_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            ns_dt.P_NS_DT_MA_NND_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_NND, TEN_BANG.NS_DT_MA_NND);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_NND_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_MA_NND_DV, ht_dungchung.NND, b_ma, ref thongbao);
            if (b_tontai > 0) return "loi:Mã " + b_ma + " đã được sử dụng:loi";
            double b_tontai1 = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_MA_KDT, ht_dungchung.NND, b_ma, ref thongbao);
            if (b_tontai1 > 0) return "loi:Mã " + b_ma + " đã được sử dụng:loi";
            ns_dt.P_NS_DT_MA_NND_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_NND, TEN_BANG.NS_DT_MA_NND);
            return Fs_NS_DT_MA_NND_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region NHÓM NỘI DUNG ĐƠN VỊ
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_NND_DV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_dt.Fdt_NS_DT_MA_NND_DV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_CHA", "MA_CHA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            ns_dt.P_NS_DT_MA_NND_DV_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_NND_DV, TEN_BANG.NS_DT_MA_NND_DV);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_NND_DV_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_CT(string b_login, string b_form, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DV_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_NND", "NND");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_MA_NNN, ht_dungchung.MA, b_ma, ref thongbao);
            if (b_tontai > 0) return "loi:Mã " + b_ma + " đã được sử dụng:loi";
            double b_tontai1 = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_MA_KDT, ht_dungchung.NND_DV, b_ma, ref thongbao);
            if (b_tontai1 > 0) return "loi:Mã " + b_ma + " đã được sử dụng:loi";
            ns_dt.P_NS_DT_MA_NND_DV_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_NND_DV, TEN_BANG.NS_DT_MA_NND_DV);
            return Fs_NS_DT_MA_NND_DV_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NND_DV_DR(string b_form, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DV_DR(b_ma);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_NND_DV", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region CHỈ TIÊU ĐÀO TẠO VÀ HỌC TẬP

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CTDT_HT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_hl");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "ncdanh", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilongnhap; }
            bang.P_CSO_SO(ref b_dt_ct, "tl_tg_tt,tl_gd_tt,tl_tg_tt_ojt,tl_gd_tt_ojt");
            b_so_id = ns_dt.P_NS_DT_MA_CTDT_HT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_CTDT_HT, TEN_BANG.NS_DT_MA_CTDT_HT);
            return Fs_NS_DT_MA_CTDT_HT_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CTDT_HT_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_MA_CTDT_HT_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CTDT_HT_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_MA_CTDT_HT_LKE(b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_hl");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CTDT_HT_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataSet b_ds = ns_dt.Fds_NS_DT_MA_CTDT_HT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt_ct, "tl_tg_tt,tl_gd_tt,tl_tg_tt_ojt,tl_gd_tt_ojt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_CTDT_HT_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_MA_CTDT_HT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_CTDT_HT, TEN_BANG.NS_DT_MA_CTDT_HT);
            return Fs_NS_DT_MA_CTDT_HT_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion CHỈ TIÊU ĐÀO TẠO VÀ HỌC TẬP

    #region 3.3.6	THỜI GIAN ĐÀO TẠO THEO HÌNH THỨC OJT

    [WebMethod(true)]
    public string Fs_NS_DT_HINHTHUC_NH(string b_login, string b_so_id, string b_nam, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_CNG_SO(ref b_dt, "ngay_gd");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "MA_HV", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            b_so_id = ns_dt.P_NS_DT_HINHTHUC_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_HINHTHUC, TEN_BANG.NS_DT_HINHTHUC);
            return Fs_NS_DT_HINHTHUC_MA(b_login, b_so_id, b_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HINHTHUC_MA(string b_login, string b_so_id, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_HINHTHUC_MA(b_so_id, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_gd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HINHTHUC_LKE(string b_login, string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_HINHTHUC_LKE(b_nam, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_gd");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_HINHTHUC_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataSet b_ds = ns_dt.Fds_NS_DT_HINHTHUC_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_gd");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_dt_hinhthuc", "DT_KETQUA", "ket_qua");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HINHTHUC_XOA(string b_login, string b_so_id, string b_nam, string ma_hv, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_HINHTHUC_XOA(b_so_id, ma_hv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_HINHTHUC, TEN_BANG.NS_DT_HINHTHUC);
            return Fs_NS_DT_HINHTHUC_LKE(b_login, b_nam, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion 3.3.6	THỜI GIAN ĐÀO TẠO THEO HÌNH THỨC OJT

    #region TRIỂN KHAI ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_TRIENKHAI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_TRIENKHAI_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "tgian_bd,tgian_kt");
            bang.P_COPY_COL(ref b_dt_tk, "trangthai", "ten_trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chưa triển khai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã triển khai");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt_tk, "thang", "12", "Tháng 12");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TRIENKHAI_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            ns_dt.P_NS_DT_TRIENKHAI_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion TRIỂN KHAI ĐÀO TẠO

    #region  Tổng hợp thời gian giảng dạy của giảng viên
    [WebMethod(true)]
    public string Fs_NS_DT_TGIAN_GDAY_LKE(string b_login, string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_TGIAN_GDAY_LKE(b_nam, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; //bang.P_SO_CSO(ref b_dt_tk, "tong_cp");
            string b_so_id = "0";
            bang.P_CSO_SO(ref b_dt_tk, "sogio_gianday_iclas,sogio_gianday_ojt,sogio_gianday,sogio_tt_iclas,sogio_tt_ojt,sogio_tt");
            ns_dt.Fs_NS_DT_TGIAN_GDAY_NH(ref b_so_id, b_dt_tk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_DT_TGIAN_GDAY, TEN_BANG.NS_DT_TGIAN_GDAY);
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion  Tổng hợp thời gian giảng dạy của giảng viên

    #region  Tổng hợp thời gian giảng dạy của học viên
    [WebMethod(true)]
    public string Fs_NS_DT_TGIAN_GDAY_HVIEN_LKE(string b_login, string b_phong, string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_TGIAN_GDAY_HVIEN_LKE(b_phong, b_nam, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CSO(ref b_dt_tk, "tong_cp");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion  Tổng hợp thời gian giảng dạy của học viên

    #region DANH SÁCH HỌC VIÊN THAM GIA KHÓA ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_NH(string b_login, string b_so_id, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam,thang");
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");

            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "SO_THE", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            bang.P_CSO_SO(ref b_dt_ct, "stt");

            b_so_id = ns_dt.P_NS_DT_HVIEN_TGIAN_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_HVIEN_TGIAN, TEN_BANG.NS_DT_HVIEN_TGIAN);
            return Fs_NS_DT_HVIEN_TGIAN_MA(b_login, b_so_id, b_nam, b_thang, b_khoa_dt, b_lop_dt, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_MA(string b_login, string b_so_id, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_HVIEN_TGIAN_MA(b_so_id, b_nam, b_thang, b_khoa_dt, b_lop_dt, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_LKE(string b_login, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_HVIEN_TGIAN_LKE(b_nam, b_thang, b_khoa_dt, b_lop_dt, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_TH(string b_login, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_HVIEN_TGIAN_TH(b_nam, b_thang, b_khoa_dt, b_lop_dt, b_so_id, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_CT(string b_login, string b_so_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Fds_NS_DT_HVIEN_TGIAN_CT(b_so_id, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            DataTable b_dt_ct = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_hvien_tgian", "DT_KDT", "KHOA_DT");
            return chuyen.OBJ_S(a_obj[0]) + "#" + (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_HVIEN_TGIAN_XOA(string b_login, string b_so_id, string b_nam, string b_thang, string b_khoa_dt, string b_lop_dt, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_HVIEN_TGIAN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_HVIEN_TGIAN, TEN_BANG.NS_DT_HVIEN_TGIAN);
            return Fs_NS_DT_HVIEN_TGIAN_LKE(b_login, b_nam, b_thang, b_khoa_dt, b_lop_dt, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_LOPHOC(string b_login, string b_form, string b_bien, string b_nam, string b_khoa_dt)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_LOP_HOC_DR(b_nam, b_khoa_dt);
            DataTable b_dt_ky = b_dt.Copy();
            se.P_TG_LUU(b_form, b_bien, b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_LOPHOC_CT(string b_login, string b_lop_dt)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_LOP_HOC_CT(b_lop_dt);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHOA_DT_NAM(string b_login, string b_form, string b_bien, string b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_NAM_DR(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            se.P_TG_LUU(b_form, b_bien, b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH SÁCH HỌC VIÊN THAM GIA KHÓA ĐÀO TẠO

    #region  NHU CẦU ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_NCAU_LKE(string b_login, string b_nam, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_NCAU_LKE(b_nam, b_phong, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1]; bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion  NHU CẦU ĐÀO TẠO

    #region ĐỀ XUẤT ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_NH(string b_login, string b_so_id, string b_trang_thai, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            b_so_id = ns_dt.P_NS_DT_DEXUAT_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return Fs_NS_DT_DEXUAT_MA(b_login, b_so_id, b_trang_thai, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_MA(string b_login, string b_so_id, string b_trang_thai, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_DEXUAT_MA(b_so_id, b_trang_thai, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LKE(string b_login, string b_trang_thai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_DEXUAT_LKE(b_trang_thai, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_dt.Fdt_NS_DT_DEXUAT_CT(b_so_id);
            var b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_nam = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, "");
            se.P_TG_LUU("ns_dt_dexuat", "DT_KDT", b_dt_nam.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_dt_dexuat", "DT_KDT", "KHOA_DT");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_XOA(string b_login, string b_so_id, string b_trang_thai, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_DEXUAT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return Fs_NS_DT_DEXUAT_LKE(b_login, b_trang_thai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); ns_dt.P_NS_DT_DEXUAT_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region ĐỀ XUẤT ĐÀO TẠO CHO LÃNH ĐẠO

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_NH(string b_login, string b_so_id, string b_trang_thai, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt, "chiphi_dk,sl_hocvien,tluong_dt");
            b_so_id = ns_dt.P_NS_DT_DEXUAT_LD_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return Fs_NS_DT_DEXUAT_LD_MA(b_login, b_so_id, b_trang_thai, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_MA(string b_login, string b_so_id, string b_trang_thai, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_DEXUAT_LD_MA(b_so_id, b_trang_thai, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_LKE(string b_login, string b_trang_thai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_DEXUAT_LD_LKE(b_trang_thai, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_dt.Fdt_NS_DT_DEXUAT_LD_CT(b_so_id);
            var b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_nam = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, "");
            se.P_TG_LUU("NS_DT_DEXUAT_LD", "DT_KDT", b_dt_nam.Copy());
            bang.P_TIM_THEM(ref b_dt, "NS_DT_DEXUAT_LD", "DT_KDT", "KHOA_DT");
            bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_XOA(string b_login, string b_so_id, string b_trang_thai, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dt.P_NS_DT_DEXUAT_LD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return Fs_NS_DT_DEXUAT_LD_LKE(b_login, b_trang_thai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_LD_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); ns_dt.P_NS_DT_DEXUAT_LD_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_DT_DEXUAT, TEN_BANG.NS_DT_DEXUAT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_DEXUAT_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt, "chon", "");
            bang.P_THAY_GTRI(ref b_dt, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "thang", "12", "Tháng 12");
            bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message );
            else return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = ns_dt.Fdt_NS_DT_DEXUAT_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_DT_DEXUAT_PD, TEN_BANG.NS_DT_DEXUAT_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message );
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            //for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            //{
            //    if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
            //    {
            //        return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
            //    }
            //}
            DataTable b_kq = ns_dt.Fdt_NS_DT_DEXUAT_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_DT_DEXUAT_PD, TEN_BANG.NS_DT_DEXUAT_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message );
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO

    #region ĐÁNH GIÁ KHÓA ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KDT_NH(string b_login, string b_so_id, string b_nam, string b_ngayc, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DateTime date = chuyen.CNG_NG(b_ngayc);
            DateTime today = DateTime.Today;
            TimeSpan ngay = today.Subtract(date);
            int ngay2 = (int)ngay.TotalDays;
            if (ngay2 > 14)
            {
                return "loi: Khóa học đã kết thúc sau 14 ngày. Không được phép chỉnh sửa:loi";
            }
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_hoc");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "sott", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            bang.P_CSO_SO(ref b_dt_ct, "STT");
            b_so_id = ns_dt.P_NS_DT_DANHGIA_KDT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DANHGIA_KDT, TEN_BANG.NS_DT_DANHGIA_KDT);
            return Fs_NS_DT_DANHGIA_KDT_MA(b_login, b_so_id, b_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KDT_MA(string b_login, string b_so_id, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_DANHGIA_KDT_MA(b_so_id, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "thang", "12", "Tháng 12");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KDT_LKE(string b_login, string b_nam, double[] a_tso, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_DANHGIA_KDT_LKE(b_nam, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            DataTable b_dt_ct = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "thang", "12", "Tháng 12");

            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KDT_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_dt.Fds_NS_DT_DANHGIA_KDT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hoc");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_danhgia_kdt", "DT_KDT", "KHOA_HOC");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TGIAN_HOC_P_CT(string b_login, string b_nam, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_TGIAN_HOC_P_CT(b_nam, b_so_the);
            DataTable b_dt = (DataTable)a_obj[0];
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KDT_XOA(string b_login, string b_so_id, string b_nam, double[] a_tso, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            ns_dt.P_NS_DT_DANHGIA_KDT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_DANHGIA_KDT, TEN_BANG.NS_DT_DANHGIA_KDT);
            return Fs_NS_DT_DANHGIA_KDT_LKE(b_login, b_nam, a_tso, a_cot, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region ĐÁNH GIÁ CHẤT LƯỢNG KHÓA ĐÀO TẠO
    [WebMethod(true)]
    public string Fdt_NS_DT_DANHGIA_CL_KDT_DR(string b_form, string b_nam, string b_ten_ktra)
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_DANHGIA_CL_KDT_DR(b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_CL_KDT_NH(string b_login, string b_so_id, string b_nam, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_hoc");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "STT", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            bang.P_CSO_SO(ref b_dt_ct, "sott,STT,rtot,tot,kha,trungbinh,kem");
            b_so_id = ns_dt.P_NS_DT_DANHGIA_CL_KDT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DANHGIA_CL_KDT, TEN_BANG.NS_DT_DANHGIA_CL_KDT);
            return Fs_NS_DT_DANHGIA_CL_KDT_MA(b_login, b_so_id, b_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_CL_KDT_MA(string b_login, string b_so_id, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_DANHGIA_CL_KDT_MA(b_so_id, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hoc");
            bang.P_THAY_GTRI(ref b_dt, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "thang", "12", "Tháng 12");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_CL_KDT_LKE(string b_login, string b_nam, double[] a_tso, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_dt.Faobj_NS_DT_DANHGIA_CL_KDT_LKE(b_nam, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            DataTable b_dt_ct = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "thang", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "thang", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "thang", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "thang", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "thang", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "thang", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "thang", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "thang", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "thang", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "thang", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "thang", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "thang", "12", "Tháng 12");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_CL_KDT_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_dt.Fds_NS_DT_DANHGIA_CL_KDT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hoc");
            //var b_nam = b_dt.Rows[0]["nam"].ToString(); var b_khoa_dt = b_dt.Rows[0]["KHOA_HOC"].ToString();
            //DataTable b_dt_kh = ns_dt.Fdt_NS_DT_MA_LOP_HOC_DR(b_nam, b_khoa_dt);
            //se.P_TG_LUU("NS_DT_DANHGIA_CL_KDT", "LOP_DT", b_dt_kh.Copy());
            bang.P_TIM_THEM(ref b_dt, "NS_DT_DANHGIA_CL_KDT", "DT_KDT", "KHOA_HOC");
            // bang.P_TIM_THEM(ref b_dt, "NS_DT_DANHGIA_CL_KDT", "DT_LDT", "LOP_DT");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_CL_KDT_XOA(string b_login, string b_so_id, string b_nam, double[] a_tso, string[] a_cot, string[] a_cot_ct)
    {
        try
        { ns_dt.P_NS_DT_DANHGIA_CL_KDT_XOA(b_so_id); return Fs_NS_DT_DANHGIA_CL_KDT_LKE(b_login, b_nam, a_tso, a_cot, a_cot_ct); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐÁNH GIÁ KHÓA ĐÀO TẠO

    #region TRIỂN KHAI KDT
    [WebMethod(true)]
    public string Fs_NS_DT_TRIENKHAI_KDT_CT(string b_login, string b_so_id, string b_kdt, string b_lop, string b_trangthai, string[] a_cot, string[] a_cot_cp)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_dt.Faobj_NS_DT_TRIENKHAI_KDT_CT(b_so_id, b_kdt, b_lop, b_trangthai);
            DataTable b_dt = (DataTable)a_obj[0];
            DataTable b_dt_ct = (DataTable)a_obj[1];
            DataTable b_dt_cp = (DataTable)a_obj[2];
            bang.P_TIM_THEM(ref b_dt, "ns_dt_trienkhai_kdt", "DT_DM_KDT", "MA_KDT");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_trienkhai_kdt", "DT_DTAC", "DOITAC");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_trienkhai_kdt", "DT_THANG", "THANG");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "HT", "Hội thảo");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "IL", "Inclass");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "OJT", "On Job Training");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "TS", "Talk show");
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            bang.P_SO_CSO(ref b_dt_cp, "STIEN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_cp, a_cot_cp);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TRIENKHA_KDT_NH(string b_login, string b_so_id, string b_tong_cp, string b_cp_hv, object[] a_dt, object[] a_dt_ct_cp, object[] a_dt_ct_gv, double b_trangkt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin KHDT CT
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "Hội thảo", "HT");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "Inclass", "IL");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "On Job Training", "OJT");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "Talk show", "TS");
            bang.P_CNG_SO(ref b_dt, new string[] { "ngay_d", "ngay_c" });

            // thông tin danh sách chi phi
            string[] a_cot_ct_cp = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cp[0]);
            object[] a_gtri_ct_cp = (object[])a_dt_ct_cp[1];
            DataTable b_dt_ct_cp;

            if (a_gtri_ct_cp == null) b_dt_ct_cp = bang.Fdt_TAO_BANG(a_cot_ct_cp, "SS");
            else b_dt_ct_cp = bang.Fdt_TAO_THEM(a_cot_ct_cp, a_gtri_ct_cp);

            //bang.P_BO_HANG(ref b_dt_ct_cp, "loai_cp", ""); 
            bang.P_CSO_SO(ref b_dt_ct_cp, "stien");
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct_gv[0]);
            object[] a_gtri1 = (object[])a_dt_ct_gv[1];
            DataTable b_dt_ct_gv = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            //bang.P_BO_HANG(ref b_dt_ct_gv, "loai_gv", "");
            //bang.P_CSO_SO(ref b_dt_ct_gv, "sodt");
            ns_dt.Fs_NS_DT_TRIENKHAI_KDT_NH(ref b_so_id, b_tong_cp, b_cp_hv, b_dt, b_dt_ct_cp, b_dt_ct_gv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TRIENKHAI, TEN_BANG.NS_DT_TRIENKHAI);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TRIENKHA_KDT_TINH(object[] a_dt_ct_gv)
    {
        try
        {
            string[] a_cot1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct_gv[0]);
            object[] a_gtri1 = (object[])a_dt_ct_gv[1];
            DataTable b_dt_ct_gv = bang.Fdt_TAO_THEM(a_cot1, a_gtri1);
            bang.P_BO_HANG(ref b_dt_ct_gv, "ddanh", "CP");
            bang.P_BO_HANG(ref b_dt_ct_gv, "ddanh", "");
            int dem = b_dt_ct_gv.Rows.Count;
            return dem.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion TRIỂN KHAI KDT
}