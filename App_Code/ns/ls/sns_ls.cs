
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;

[System.Web.Script.Services.ScriptService]
public class sns_ls : System.Web.Services.WebService
{
    #region LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRONG CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_LS_CT_TCT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_CT_TCT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_hl,ngay_qd");
            bang.P_SO_CSO(ref b_dt_tk, "luongcb,tongluong,phucap,thuongthang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_CT_TCT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_LS_CT_TCT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_qd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_CT_TCT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_CT_TCT_CT(b_so_id);
            //bang.P_SO_CNG(ref b_dt, "ngay_qd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_LS_CT_TCT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); //bang.P_CNG_SO(ref b_dt_ct, "ngay_qd"); bang.P_CNG_SO(ref b_dt_ct, "ngayd"); bang.P_CNG_SO(ref b_dt_ct, "ngayc");
            b_so_id = ns_ls.PNS_LS_CT_TCT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_LS_CT_TCT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_LS_CT_TCT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ls.PNS_LS_CT_TCT_XOA(b_so_id); return Fs_NS_LS_CT_TCT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TRA_TENPHONG(string b_so_the)
    {
        try
        {
            string b_tg = ns_ls.Fn_TRA_TENPHONG(b_so_the);
            return chuyen.OBJ_S(b_tg);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRONG CÔNG TY

    #region LỊCH SỬ QUÁ TRÌNH LƯƠNG TRONG CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_LS_LUONG_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_LUONG_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd"); bang.P_SO_CSO(ref b_dt, "luongcb,thuong_kq,pt_huongluong,phucap,thunhapthang");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_LUONG_PCAP(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_LUONG_PCAP(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_ad,ngay_kt");
            bang.P_SO_CSO(ref b_dt, "sotien");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRƯỚC KHI VÀO CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_LSCT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LSCT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "mucluong");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LSCT_TT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "K", "Không phê duyệt");
            bang.P_SO_CSO(ref b_dt_tk, "mucluong");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_LSCT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "mucluong");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_LSCT_TT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "G", "Đã gửi");
            bang.P_SO_CSO(ref b_dt, "mucluong");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_LSCT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LSCT_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LSCT_TT_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            b_so_id = ns_ls.PNS_LSCT_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_LSCT, TEN_BANG.NS_LSCT);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_LSCT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); //bang.P_CNG_SO(ref b_dt_ct, "ngay_qd"); bang.P_CNG_SO(ref b_dt_ct, "ngayd"); bang.P_CNG_SO(ref b_dt_ct, "ngayc");
            b_so_id = ns_ls.PNS_LSCT_TT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_LSCT_TT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_LSCT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ls.PNS_LSCT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_LSCT, TEN_BANG.NS_LSCT);
            return Fs_NS_LSCT_LKE(b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_GUI(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ls.PNS_LSCT_TT_GUI(b_so_id); return Fs_NS_LSCT_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LSCT_TT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_ls.PNS_LSCT_TT_XOA(b_so_id); return Fs_NS_LSCT_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion LỊCH SỬ QUÁ TRÌNH CÔNG TÁC TRƯỚC KHI VÀO CÔNG TY

    #region QUẢN LÝ CÁC KHOẢN HỖ TRỢ
    [WebMethod(true)]
    public string Fs_NS_PCAP_LKE(string b_so_the, string b_loai_huong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_PCAP_LKE(b_so_the, b_loai_huong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "tien");
            bang.P_THEM_COL(ref b_dt_tk, "lh", "");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            bang.P_SO_CNG(ref b_dt_tk, "ngayc");
            foreach (DataRow b_dr in b_dt_tk.Rows)
            {
                if (chuyen.OBJ_S(b_dr["loaihuong"]) == "TT") b_dr["lh"] = "Theo tháng";
                else b_dr["lh"] = "Theo công thực tế";
            }
            b_dt_tk.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_PCAP_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_THEM_COL(ref b_dt, "lh", "");
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_SO_CNG(ref b_dt, "ngayc");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["loaihuong"]) == "TT") b_dr["lh"] = "Theo tháng";
                else b_dr["lh"] = "Theo công thực tế";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_PCAP_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "ns_pcap", "DT_MA_PHUCAP", "MA_PHUCAP");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            //bang.P_SO_CNG(ref b_dt, "ngay_qd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); //bang.P_CNG_SO(ref b_dt_ct, "ngay_qd");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd"); bang.P_CNG_SO(ref b_dt_ct, "ngayc");
            b_so_id = ns_ls.PNS_PCAP_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_PCAP, TEN_BANG.NS_PCAP);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_PCAP_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_XOA(string b_so_id, string b_so_the, string b_loai_huong, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ls.PNS_PCAP_XOA(b_so_id); // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_PCAP, TEN_BANG.NS_PCAP);
            return Fs_NS_PCAP_LKE(b_so_the, b_loai_huong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PCAP_TRA(string b_so_the)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_NS_PCAP_TRA(b_so_the);
            DataTable b_dt = (DataTable)a_object[0];
            DataRow b_dr = b_dt.Rows[0];
            return chuyen.OBJ_S(b_dr["ten_dvi"]) + "#" + chuyen.OBJ_S(b_dr["ten_cdanh"]) + "#" + chuyen.OBJ_S(b_dr["ho_ten"]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ CÁC KHOẢN HỖ TRỢ

    #region LỊCH SỬ QUÁ TRÌNH HỢP ĐỒNG LAO ĐỘNG
    [WebMethod(true)]
    public string Fs_NS_LS_HD_LD_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_HD_LD_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_ky");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd"); bang.P_SO_CNG(ref b_dt_tk, "ngayc");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_HD_PL", "TN", "Phụ lục điều chỉnh thu nhập");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_HD_PL", "TG", "Phụ lục điều chỉnh thời gian");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_HD_PL", "K", "Phụ lục điều chỉnh khác");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion LỊCH SỬ QUÁ TRÌNH HỢP ĐỒNG LAO ĐỘNG

    #region LỊCH SỬ QUÁ TRÌNH ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_LS_QT_DT_LKE(string b_login, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_QT_DT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_THAY_GTRI(ref b_dt, "dvi_tc", "DTNB", "Đào tạo nội bộ");

            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "H", "Hoàn thành");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "T", "Đang thi,");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "D", "Đã thi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "C", "Chưa hoàn thành");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_QT_DT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ls.Fdt_LS_QT_DT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_THAY_GTRI(ref b_dt, "dvi_tc", "DTNB", "Đào tạo nội bộ");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_QT_DT_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ls.PNS_LS_QT_DT_CT(b_so_id);
            //bang.P_SO_CNG(ref b_dt, "ngay_qd");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_QT_DT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1]; DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "diem,tien");
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngay_d", "ngay_c" });
            b_so_id = ns_ls.PNS_LS_QT_DT_NG_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_LS_QT_DT, TEN_BANG.NS_LS_QT_DT);
            //return Fs_NS_LS_QT_DT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_LS_QT_DT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_LS_QT_DT_XOA(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ls.PNS_LS_QT_DT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_LS_QT_DT, TEN_BANG.NS_LS_QT_DT);
            return Fs_NS_LS_QT_DT_LKE(b_login, b_so_the, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion LỊCH SỬ QUÁ TRÌNH ĐÀO TẠO

    #region QUÁ TRÌNH KHEN THƯỞNG
    [WebMethod(true)]
    public string Fs_NS_LS_KT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            int b_date = chuyen.CNG_SO(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_KT_LKE(b_so_the, b_date, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "sotien");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region QUÁ TRÌNH ĐÀO TẠO TRONG CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_LS_DT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_DT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_THAY_GTRI(ref b_dt, "hthuc", "IL", "Inclass");
            bang.P_THAY_GTRI(ref b_dt, "hthuc", "HT", "Hội thảo");
            bang.P_THAY_GTRI(ref b_dt, "hthuc", "OJT", "On Job Training");
            bang.P_THAY_GTRI(ref b_dt, "hthuc", "TS", "Talkshow");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region QUÁ TRÌNH KỶ LUẬT
    [WebMethod(true)]
    public string Fs_NS_LS_KL_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            int b_date = chuyen.CNG_SO(DateTime.Now.Date.ToString("dd/MM/yyyy"));
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_KL_LKE(b_so_the, b_date, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_vp,ngayd");
            bang.P_SO_CSO(ref b_dt, "tienphat");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region KẾT QUẢ ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_NS_LS_DG_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ls.PNS_LS_DG_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion
}
