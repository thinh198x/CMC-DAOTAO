using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
[System.Web.Script.Services.ScriptService]
public class sns_ma_ch : System.Web.Services.WebService
{
    #region THIẾT LẬP THÔNG BÁO MENU

    [WebMethod(true)]
    public string Fs_NS_TBAO_MENU_TLAP_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TBAO_MENU_TLAP_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TBAO_MENU_TLAP, TEN_BANG.NS_TBAO_MENU_TLAP);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TBAO_MENU_TLAP_CT()
    {
        try
        {
            DataTable b_dt = ns_ma.P_NS_TBAO_MENU_TLAP_CT();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP THÔNG BÁO MENU

    #region MÃ NHÓMns
    [WebMethod(true)]
    public string Fs_NS_MA_NH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NHA, TEN_BANG.NS_MA_NHA);
            return Fs_NS_MA_NH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_NH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NHA, TEN_BANG.NS_MA_NHA);
            return Fs_NS_MA_NH_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ HỌC HÀM
    [WebMethod(true)]
    public string Fs_NS_MA_HH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_HH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_HH_XOA(b_ma); return Fs_NS_MA_HH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ HỌC VỊ
    [WebMethod(true)]
    public string Fs_NS_MA_HV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HV_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HV_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_HV_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HV_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HV_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_HV_XOA(b_ma); return Fs_NS_MA_HV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ NHÓM CHUYÊN NGÀNH
    [WebMethod(true)]
    public string Fs_NS_MA_NCNGANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NCNGANH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NCNGANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NCNGANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NCNGANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NCNGANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NCNGANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NCNGANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NCNGANH_XOA(b_ma); return Fs_NS_MA_NCNGANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ CHUYÊN NGÀNH
    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_LKE(string b_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CNGANH_LKE(b_nhom, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_MA(string b_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CNGANH_MA(b_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CNGANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nhom = mang.Fs_TEN_GTRI("nhom", a_cot, a_gtri);
            return Fs_NS_MA_CNGANH_MA(b_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_XOA(string b_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CNGANH_XOA(b_nhom, b_ma); return Fs_NS_MA_CNGANH_LKE(b_nhom, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ CHỨC DANH CÔNG VIỆC
    [WebMethod(true)]
    public void Fs_NS_MA_CDANH_DRLKE(string b_ncdanh, string b_tenform, string b_ktra)
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_CDANH_LKE_DR(b_ncdanh);
        se.P_TG_LUU(b_tenform, b_ktra, b_dt.Copy());
    }
    #endregion

    #region MÃ CHỈ TIÊU ATVS LAO ĐỘNG
    [WebMethod(true)]
    public string Fs_NS_MA_CTATVS_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CTATVS_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CTATVS_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CTATVS_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CTATVS_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_CTATVS_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ CHUNG
    /// <summary>Liệt kê toàn bộ</summary>
    [WebMethod(true)]
    public string Fs_NS_MA_CH_LKE(string b_ten, string[] a_cot, string b_ham)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ten }, b_ham);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CH_CT(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ma }, "PNS_MA_DT_CT");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CH_NH(object[] b_dt, string b_ham)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CH_NH(b_dt_ct, b_ham);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CH_XOA(string b_ma, string b_ham)
    {
        try
        {
            ns_ma.P_NS_MA_CH_XOA(b_ma, b_ham);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHUNG

    #region MÃ KỶ LUẬT

    [WebMethod(true)]
    public string Fs_NS_MA_KL_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_KL_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KL_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_KL_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KL_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_KL_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KL_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_KL_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }

    #endregion MĂ KỶ LUẬT

    #region MÃ HÌNH THỨC ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_MA_HTDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HTDT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTDT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HTDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTDT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_HTDT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_HTDT, TEN_BANG.NS_MA_HTDT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HTDT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTDT_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {

        string b_thongbao = "";
        double b_tontai_kdt = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KDT, ht_dungchung.HINHTHUC, b_ma, ref b_thongbao);
        double b_tontai_kh = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH, ht_dungchung.HINHTHUC, b_ma, ref b_thongbao);
        if (b_tontai_kdt > 0 || b_tontai_kh > 0)
        {
            return "loi:Hình thức đào tạo mã " + b_ma + " đã được sử dụng:loi";
        }
        try
        {
            ns_ma.P_NS_MA_HTDT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_HTDT, TEN_BANG.NS_MA_HTDT);
            return Fs_NS_MA_HTDT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MĂ HÌNH THỨC ĐÀO TẠO

    #region MÃ LOẠI HỢP ĐỒNG

    [WebMethod(true)]
    public string Fs_NS_MA_LHD_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_ma.Faobj_NS_MA_LHD_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LHD_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_ma.Faobj_NS_MA_LHD_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LHD_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            double b_thoihan = 0;
            if (!double.TryParse(b_dt_ct.Rows[0]["THOIHAN"].ToString(), out b_thoihan))
                return form.Fs_LOC_LOI("loi:Tháng phải nhập số:loi");
            ns_ma.P_NS_MA_LHD_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_LHD, TEN_BANG.NS_MA_LHD);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LHD_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LHD_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HD, ht_dungchung.LHD, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_ma.P_NS_MA_LHD_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_LHD, TEN_BANG.NS_MA_LHD);
            return Fs_NS_MA_LHD_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LHD_SOTHANG(string b_ngayd, string b_ma, string b_so_the, string b_so_id)
    {
        try
        {
            string b_so_hd = "";
            double b_tontai = 0, b_i = 0;
            double b_st;
            DataTable b_dt = ns_ma.Fdt_NS_MA_LHD_SOTHANG(b_ma);
            if (b_dt == null || b_dt.Rows.Count <= 0) b_st = 0;
            else if (string.IsNullOrEmpty(b_dt.Rows[0]["THOIHAN"].ToString())) b_st = 0;
            else b_st = double.Parse(b_dt.Rows[0]["THOIHAN"].ToString());
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            if (string.IsNullOrEmpty(b_ngayd)) return b_st + "#" + "";
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            // đếm hợp đồng của nhân viên 
            DataTable b_dem = ns_ma.Fdt_NS_DEM_HD(b_so_the, b_so_id);
            b_i = int.Parse(b_dem.Rows[0]["dem"].ToString());


            if (b_tusinh == null) b_so_hd = "";
            else
            {
                if (b_tusinh.Rows[0]["HOPDONG"].Equals("NT")) b_so_hd = "";
                else
                {
                    string b_dinhdang = b_dt.Rows[0]["MA_SINH_SHD"].ToString();
                    do
                    {
                        string b_sott = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_i, "00"));
                        b_so_hd = b_so_the + "-" + b_sott + "/" + b_dinhdang;
                        b_i = b_i + 1;
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_HD_HOI(b_so_hd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (string.IsNullOrEmpty(b_so_hd)) b_so_hd = b_so_the + "-01/" + "KXD_LHD";
            return b_st.ToString() + "#" + b_so_hd;
        }
        catch (Exception) { return "0" + "#" + ""; }
    }
    #endregion MĂ LOẠI HỢP ĐỒNG

    #region THIẾT LẬP NỘI DUNG GỬI EMAIL SINH NHẬT

    [WebMethod(true)]
    public string Fs_NS_MA_EMAIL_SN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_EMAIL_SN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_EMAIL_SN_MA(string b_ma_pn, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_EMAIL_SN_MA(b_ma_pn, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma_pn", b_ma_pn);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_EMAIL_SN_CT(string b_login, string b_form, string b_ma, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_EMAIL_SN_CT(b_ma);

            DataTable b_dt_dvi = ht_madvi.Fdt_DVI_QLY();
            se.P_TG_LUU(b_form, "DT_MA_PN", b_dt_dvi.Copy());
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_PN", "MA_PN");

            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_EMAIL_SN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_EMAIL_SN_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_MA_EMAIL_SN, TEN_BANG.NS_MA_EMAIL_SN);
            string b_ma = mang.Fs_TEN_GTRI("ma_pn", a_cot, a_gtri);
            return Fs_NS_MA_EMAIL_SN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_EMAIL_SN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_EMAIL_SN_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_MA_EMAIL_SN, TEN_BANG.NS_MA_EMAIL_SN);
            return Fs_NS_MA_EMAIL_SN_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MĂ LOẠI HỢP ĐỒNG

    #region MÃ LOẠI NGẠCH

    [WebMethod(true)]
    public string Fs_NS_MA_LNG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_LNG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LNG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_LNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LNG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LNG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LNG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_LNG_XOA(b_ma); return Fs_NS_MA_LNG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MĂ LOẠI NGẠCH

    #region MÃ THANG LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_MA_TBL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TBL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TBL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_TBL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TBL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TBL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_TBL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TBL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_TBL_XOA(b_ma); return Fs_NS_MA_TBL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MĂ LOẠI NGẠCH

    #region THANG LƯƠNG ĐƠN VỊ
    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_SO_ID(string b_login, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HDNS_TLUONG_DVI_SO_ID(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_MA(string b_login, string b_phong, string b_ngay_hl, string b_ma_tl, string b_ma_nl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HDNS_TLUONG_DVI_MA(b_phong, b_ngay_hl, b_ma_tl, b_ma_nl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "cty", "ngay_hl", "ma_tl", "ma_nl" }, new object[] { b_phong, b_ngay_hl, b_ma_tl, b_ma_nl });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_CT(string b_login, string b_form, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            var b_ds = ns_ma.Fdt_NS_HDNS_TLUONG_DVI_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
            Fs_NS_HDNS_MA_TL_NL(b_form, b_dt.Rows[0]["ma_tl1"].ToString());
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_DVI", "CTY");
            bang.P_SO_CSO(ref b_dt_ct, new string[] { "tongluong", "luong_cb", "thuong_dg" });
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HDNS_TLUONG_DVI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_NH(string b_login, object[] a_dt, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            double b_so_id = 0;
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            bang.P_DON(ref b_dt); bang.P_DON_DK(ref b_dt_ct, "so_id_bl");
            if (bang.Fb_TRANG(b_dt_ct)) { return form.Fs_LOC_LOI("loi:Vui lòng kiểm tra lại thông tin thiết lập bậc lương:loi"); }
            bang.P_CSO_SO(ref b_dt_ct, new string[] { "so_id", "tongluong", "luong_cb", "thuong_dg" });
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["luong_cb"]) != 0 && chuyen.OBJ_N(b_dt_ct.Rows[i]["thuong_dg"]) != 0)
                {
                    if (chuyen.OBJ_N(b_dt_ct.Rows[i]["tongluong"]) != chuyen.OBJ_N(b_dt_ct.Rows[i]["luong_cb"]) + chuyen.OBJ_N(b_dt_ct.Rows[i]["thuong_dg"]))
                    {
                        return form.Fs_LOC_LOI("loi:Tổng lương không bằng tổng Lương cơ bản và Thưởng đánh giá tháng:loi");
                    }
                }
            }
            ns_ma.P_NS_HDNS_TLUONG_DVI_NH(ref b_so_id, b_dt, b_dt_ct);
            return Fs_NS_HDNS_TLUONG_DVI_SO_ID(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_TLUONG_DVI_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HDNS_TLUONG_DVI_XOA(b_ma); return Fs_NS_HDNS_TLUONG_DVI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ NHOM LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_MA_NL_LKE(string b_login, string b_ma_tl, string b_day, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NL_LKE(b_ma_tl, b_day, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "tthai", "tt");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_nhomluong", "DT_MA_TL", "MA_TL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NL_MA(string b_login, string b_matl, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_NL_MA(b_matl, b_ma, b_trangkt); ;
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma", "ma_tl" }, new string[] { b_ma, b_matl });
            bang.P_COPY_COL(ref b_dt, "tthai", "tt");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_nhomluong", "DT_MA_TL", "MA_TL");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NL_NH(string b_login, double b_trangKT, string b_matl, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NL_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NL_MA(b_login, b_matl, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NL_XOA(string b_login, string b_ma, string b_ma_tl, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_NL_XOA(b_ma, b_ma_tl);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG);
            string b_day = "";
            return Fs_NS_MA_NL_LKE(b_login, "", b_day, a_tso, a_cot);

        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    //liệt kê ngạch lương theo mã thang lương CAPITALHOUSE
    [WebMethod(true)]
    public string Fs_NS_MA_TL_NL(string b_form, string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TL_NL(b_ma_tl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_MA_NL", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //liệt kê ngạch lương theo mã thang lương CORP
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TL_NL(string b_form, string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_TL_NL(b_ma_tl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_MA_NL", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NHOM LƯƠNG

    #region MÃ BẬC LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HDNS_MA_BACLUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_MA(string b_ma_tl, string b_ma_nl, string b_ma_nnnghiep, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_BACLUONG_MA(b_ma_tl, b_ma_nl, b_ma_nnnghiep, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            double b_so_id = chuyen.OBJ_N(a_object[3]);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + chuyen.OBJ_S(b_so_id);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_CT(string b_login, string b_form, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            var b_ds = ns_ma.Fds_NS_HDNS_MA_BACLUONG_CT(b_so_id);
            var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
            var b_dt_nl = b_ds.Tables[2].Copy();
            bang.P_SO_CSO(ref b_dt_ct, new string[] { "tongluong", "luong_cb", "thuong_dg" });
            se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NNNGHE", "MA_NNNGHIEP");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_LKE_CT(string b_login, string b_form, string b_ma_tl, string b_ma_nl, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            var b_ds = ns_ma.Fds_NS_HDNS_MA_BL_CTY_CT(b_ma_tl, b_ma_nl);
            var b_dt = b_ds.Tables[0].Copy();
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_SO_CSO(ref b_dt, new string[] { "tongluong", "luong_cb", "thuong_dg" });
            return bang.Fs_BANG_CH(b_dt, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_NH(string b_login, double b_so_id, object[] a_dt, object[] a_dt_ct, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON_DK(ref b_dt_ct, "bacluong,tongluong");
            bang.P_CSO_SO(ref b_dt_ct, new string[] { "tongluong", "luong_cb", "so_id_ct" });
            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);
            if (bang.Fb_TRANG(b_dt_ct)) return Thongbao_dch.nhapdulieu_luoi;
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["bacluong"].ToString().Equals("") || b_dt_ct.Rows[i]["tongluong"].ToString().Equals("0"))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
                if (chuyen.CSO_SO(b_dt_ct.Rows[i]["luong_cb"].ToString()) > chuyen.CSO_SO(b_dt_ct.Rows[i]["tongluong"].ToString()))
                    return "loi:Lương cơ bản không được lớn hơn tổng lương:loi";
            }

            ns_ma.P_NS_HDNS_MA_BACLUONG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG);
            string b_ma_tl = "", b_ma_nl = "", b_ma_nnnghiep = "";
            if (b_dt.Rows.Count > 0)
            {
                b_ma_tl = chuyen.OBJ_S(b_dt.Rows[0]["MA_TL"]);
                b_ma_nl = chuyen.OBJ_S(b_dt.Rows[0]["MA_NL"]);
                b_ma_nnnghiep = chuyen.OBJ_S(b_dt.Rows[0]["MA_NNNGHIEP"]);
            }
            return Fs_NS_HDNS_MA_BACLUONG_MA(b_ma_tl, b_ma_nl, b_ma_nnnghiep, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BACLUONG_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HDNS_MA_BACLUONG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG);
            return Fs_NS_HDNS_MA_BACLUONG_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TL_NGAY_HL(string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TL_NGAY_HL(b_ma_tl);
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            return bang.Fs_BANG_CH(b_dt, "ngay_hl");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //liệt kê ngạch lương theo mã thang lương
    [WebMethod(true)]
    public string Fs_NS_MA_NL_NNN(string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TL_NL(b_ma_tl);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //liệt kê bậc lương theo thang lương và ngạch lương
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BL_BYTLNL(string b_form, string b_ma_tl, string b_ma_nl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_ma_tl, b_ma_nl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { 0, "" }, 0);
            se.P_TG_LUU(b_form, "DT_MA_BL", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BL_BYID(string b_login, string b_form, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_luong_cb = "";
            DataTable b_ds = ns_ma.Fdt_NS_HDNS_MA_BL_BYID(b_so_id);
            if (b_ds.Rows.Count > 0 && b_ds != null)
            {
                b_luong_cb = b_ds.Rows[0]["luong_cb"].ToString();
            }
            return b_luong_cb;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ BẬC LƯƠNG

    #region MÃ TÔN GIÁO
    [WebMethod(true)]
    public string Fs_NS_MA_TG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_TG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_TG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_TG_XOA(b_ma); return Fs_NS_MA_TG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MĂ TÔN GIÁO

    #region MÃ BẬC
    [WebMethod(true)]
    public string Fs_NS_MA_BAC_LKE(string b_lng, string b_nganh, string[] a_cot)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_lng, b_nganh }, "PNS_MA_BAC_LKE");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BAC_CT(string b_lng, string b_nganh, string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_lng, b_nganh, b_ma }, "PNS_MA_BAC_CT");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BAC_NH(object[] a_dt_ct)
    {

        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_BAC_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BAC_XOA(string b_lng, string b_nganh, string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_BAC_XOA(b_lng, b_nganh, b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ BẬC

    #region MÃ NGẠCH LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_MA_NGH_HOI(string b_lng, string b_ngach)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_NGH_HOI(b_lng, b_ngach);
            if (b_dt.Rows.Count == 0) return "";
            else return b_dt.Rows[0][0].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NGH_LKE(string b_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NGH_LKE(b_nhom, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NGH_MA(string b_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NGH_MA(b_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NGH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nhom = mang.Fs_TEN_GTRI("lng", a_cot, a_gtri);
            return Fs_NS_MA_NGH_MA(b_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGH_XOA(string b_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NGH_XOA(b_nhom, b_ma); return Fs_NS_MA_NGH_LKE(b_nhom, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ CHỨC VỤ
    [WebMethod(true)]
    public string Fs_NS_MA_CVU_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CVU_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CVU_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CVU_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CVU_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CVU_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CVU_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CVU_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CVU_XOA(b_ma); return Fs_NS_MA_CVU_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHỨC VỤ

    #region MÃ NƯỚC
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_NUOC_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NUOC_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NUOC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NUOC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NUOC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_NUOC_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_MA_NUOC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NUOC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_NUOC_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_MA_NUOC_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NƯỚC

    #region tỉnh thành
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI1_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_LVHOAN_BAI1_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    public string Fs_LVHOAN_BAI1_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_LVHOAN_BAI1_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_LVHOAN_BAI1_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_LVHOAN_BAI1_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_LVHOAN_BAI1_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI1_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_LVHOAN_BAI1_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_LVHOAN_BAI1_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion tỉnh thành


    #region NHNAM_BAI1

    [WebMethod(true)]
    public string Fs_NS_NHNAM_BAI1_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_NHNAM_BAI1_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_NHNAM_BAI1_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_NHNAM_BAI1_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NHNAM_BAI1_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_NHNAM_BAI1_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_NHNAM_BAI1_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_NHNAM_BAI1_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_NHNAM_BAI1_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_NHNAM_BAI1_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ TINHTHANH
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_TINHTHANH_LKE(double[] a_tso, string[] a_cot, string b_tt )
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TINHTHANH_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TINHTHANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_TINHTHANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TINHTHANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_TINHTHANH_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_MA_TINHTHANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TINHTHANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_TINHTHANH_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_MA_TINHTHANH_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion TINHTHANH

    #region MÃ PHÂN BỔ
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_PBO_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_PBO_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_PBO_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_PBO_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PBO_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_PBO_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_PBO, TEN_BANG.NS_MA_PBO);
            return Fs_NS_MA_PBO_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PBO_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_PBO_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_PBO, TEN_BANG.NS_MA_PBO);
            return Fs_NS_MA_PBO_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ PHÂN BỔ

    #region CHI NHÁNH NGÂN HÀNG
    [WebMethod(true)]
    public string Fs_NS_MA_CNNH_LKE(string b_luuday, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CNNH_LKE(b_luuday, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CNNH_MA(double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CNNH_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CNNH_CT(string b_form, string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CNNH_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NH", "MA_NH");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CNNH_NH(string b_login, double b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CNNH_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_CNNH, TEN_BANG.NS_MA_CNNH);
            return Fs_NS_MA_CNNH_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CNNH_XOA(string b_luuday, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_CNNH_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_CNNH, TEN_BANG.NS_MA_CNNH);
            return Fs_NS_MA_CNNH_LKE(b_luuday, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHI NHÁNH NGÂN HÀNG

    #region MÃ NGÂN HÀNG
    [WebMethod(true)]
    public string Fs_NS_MA_NHA_LKE(string b_luuday, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NHA_LKE(b_luuday, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHA_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NHA_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHA_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_NHA_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHA_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NHA_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NHA_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NHA_XOA(string b_luuday, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_NHA_XOA(b_ma);
            return Fs_NS_MA_NHA_LKE(b_luuday, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NGÂN HÀNG

    #region TRƯỜNG HỌC
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_TRUONGHOC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TRUONGHOC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TRUONGHOC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_TRUONGHOC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TRUONGHOC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TRUONGHOC_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_TRUONGHOC, TEN_BANG.NS_MA_TRUONGHOC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri); ;
            return Fs_NS_MA_TRUONGHOC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TRUONGHOC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_TRUONGHOC_XOA(b_ma);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_TRUONGHOC, TEN_BANG.NS_MA_TRUONGHOC);
            return Fs_NS_MA_TRUONGHOC_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NƯỚC

    #region THIẾT LẬP PHIẾU LƯƠNG
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_TL_PHIEULUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_TL_PHIEULUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_PHIEULUONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_TL_PHIEULUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_PHIEULUONG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TL_PHIEULUONG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_TL_PHIEULUONG, TEN_BANG.NS_TL_PHIEULUONG);
            string b_ma = mang.Fs_TEN_GTRI("stt", a_cot, a_gtri); ;
            return Fs_NS_TL_PHIEULUONG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_PHIEULUONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_TL_PHIEULUONG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_TL_PHIEULUONG, TEN_BANG.NS_TL_PHIEULUONG);
            return Fs_NS_TL_PHIEULUONG_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NƯỚC

    #region CHUYÊN NGÀNH ĐÀO TẠO
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_DT_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CNGANH_DT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_DT_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_CNGANH_DT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_DT_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CNGANH_DT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_CNGANH_DT, TEN_BANG.NS_MA_CNGANH_DT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri); ;
            return Fs_NS_MA_CNGANH_DT_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CNGANH_DT_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_CNGANH_DT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_CNGANH_DT, TEN_BANG.NS_MA_CNGANH_DT);
            return Fs_NS_MA_CNGANH_DT_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NƯỚC

    #region MÃ NGOẠI NGỮ
    [WebMethod(true)]
    public string Fs_NS_MA_NN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NN_XOA(b_ma); return Fs_NS_MA_NN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NGOẠI NGỮ

    #region MÃ NGẠCH BẬC LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_HOI(string b_lng, string b_ngach, string b_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_NGBAC_HOI(b_lng, b_ngach, b_ma);
            DataRow b_dr = b_dt.Rows[0];
            return b_dr.IsNull("hso") ? "" : b_dr["hso"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_LKE(string b_lng, string b_ngach, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NGBAC_LKE(b_lng, b_ngach, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_MA(string b_lng, string b_ngach, string b_ngayd, double b_trangkt, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NGBAC_MA(b_lng, b_ngach, b_ngayd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2], b_dt_ct = (DataTable)a_object[3];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngayd", b_ngayd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1])
                + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_ma.Fdt_NS_MA_NGBAC_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk; bang.P_CNG_SO(ref b_dt_ct, "ngayd");
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ma", "");
            ns_ma.P_NS_MA_NGBAC_NH(b_so_id, b_dt_ct, b_dt_dk);
            string b_ngayd = mang.Fs_TEN_GTRI("ngayd", a_cot, a_gtri);
            string b_lng = mang.Fs_TEN_GTRI("lng", a_cot, a_gtri);
            string b_ngach = mang.Fs_TEN_GTRI("ngach", a_cot, a_gtri);
            return Fs_NS_MA_NGBAC_MA(b_lng, b_ngach, b_ngayd, b_trangKT, a_cot_lke, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NGBAC_XOA(string b_lng, string b_ngach, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NGBAC_XOA(b_so_id); return Fs_NS_MA_NGBAC_LKE(b_lng, b_ngach, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MĂ NGẠCH BẬC LƯƠNG

    #region MÃ SƠ YẾU LÝ LỊCH
    [WebMethod(true)]
    public string Fs_NS_MA_SYLL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_SYLL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_SYLL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_SYLL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_SYLL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_SYLL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_SYLL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_SYLL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_SYLL_XOA(b_ma); return Fs_NS_MA_SYLL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ TỈNH THÀNH PHỐ
    //[WebMethod(true)]
    //public string Fs_NS_MA_TT_DR(string b_tim)
    //{
    //    try
    //    {
    //        object[] a_object = ns_ma.Fdt_NS_MA_TT_DR(b_tim);
    //        DataTable b_dt = (DataTable)a_object[0];
    //        return bang.Fs_BANG_GOP(b_dt);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    [WebMethod(true)]
    public string Fs_NS_MA_TT_LKE(string b_tim, double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TT_LKE(b_tim, b_tu_n, b_den_n, b_tt);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TT_MA(string b_ma_qg, string b_ma, double b_trangkt, string[] a_cot, string b_tt)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_TT_MA(b_ma_qg, b_ma, b_trangkt, b_tt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            string b_ma_qg = mang.Fs_TEN_GTRI("ma_qg", a_cot, a_gtri);
            ns_ma.P_NS_MA_TT_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_TT, TEN_BANG.NS_MA_TT);
            return Fs_NS_MA_TT_MA("", b_ma, b_trangKT, a_cot_lke, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TT_XOA(string b_tim, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_TT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_TT, TEN_BANG.NS_MA_TT);
            return Fs_NS_MA_TT_LKE(b_tim, a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ QUẬN HUYỆN
    [WebMethod(true)]
    public string Fs_NS_MA_QH_LKE(string b_tim, double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_QH_LKE(b_tim, b_tu_n, b_den_n, b_tt);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DM_QUANHUYEN(string b_tpho, string b_form)
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_QH_DR(b_tpho);
        se.P_TG_LUU(b_form, "DT_QHUYEN", b_dt);
        return bang.Fs_BANG_CH(b_dt) == "" ? "" : bang.Fs_BANG_CH(b_dt);
    }
    [WebMethod(true)]
    public string Fs_NS_MA_QH_MA(string b_ma_tt, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_QH_MA(b_ma_tt, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            string b_ma_tt = mang.Fs_TEN_GTRI("ma_tt", a_cot, a_gtri);
            ns_ma.P_NS_MA_QH_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_QH, TEN_BANG.NS_MA_QH);
            return Fs_NS_MA_QH_MA(b_ma_tt, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QH_XOA(string b_tim, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_QH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_QH, TEN_BANG.NS_MA_QH);
            return Fs_NS_MA_QH_LKE("", a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ XÃ PHƯỜNG
    [WebMethod(true)]
    public string Fs_NS_MA_QH_LKE_DR(string ma_tt)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_NS_MA_QH_DR(ma_tt);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XP_DR(string b_qh, string b_form, string b_tableName)
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_XP_DR(b_qh);
        se.P_TG_LUU(b_form, b_tableName, b_dt);
        return bang.Fs_BANG_CH(b_dt) == "" ? "" : bang.Fs_BANG_CH(b_dt);
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XP_LKE(string b_ma_qg, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_XP_LKE(b_ma_qg, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_XP_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_XP_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XP_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_XP_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_XP, TEN_BANG.NS_MA_XP);
            string b_ma_tt = mang.Fs_TEN_GTRI("ma_tt", a_cot, a_gtri);
            string b_ma_qh = mang.Fs_TEN_GTRI("ma_xp", a_cot, a_gtri);
            return Fs_NS_MA_XP_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XP_XOA(string b_tim, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_XP_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_XP, TEN_BANG.NS_MA_XP);
            return Fs_NS_MA_XP_LKE("", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ VĂN BẰNG
    [WebMethod(true)]
    public string Fs_NS_MA_VB_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_VB_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_VB_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_VB_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_VB_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_VB_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_VB_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_VB_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_VB_XOA(b_ma); return Fs_NS_MA_VB_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ BẰNG CẤP
    [WebMethod(true)]
    public string Fs_NS_MA_BC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_BC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_BC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_BC_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_BC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_BC_XOA(b_ma); return Fs_NS_MA_BC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ DÂN TỘC
    [WebMethod(true)]
    public string Fs_NS_MA_DT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_DT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_DT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_DT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_DT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_DT_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_DT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_DT_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_DT_XOA(b_ma); return Fs_NS_MA_DT_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ LOẠI QUAN HỆ
    [WebMethod(true)]
    public string Fs_NS_MA_LQH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_LQH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LQH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_LQH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LQH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LQH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LQH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LQH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_LQH_XOA(b_ma); return Fs_NS_MA_LQH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion

    #region MÃ HÌNH THỨC KHEN THƯỞNG
    [WebMethod(true)]
    public string Fs_NS_MA_HTKT_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HTKT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTKT_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_HTKT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTKT_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_HTKT_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_HTKT, TEN_BANG.NS_MA_HTKT);
            return Fs_NS_MA_HTKT_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTKT_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_HTKT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_HTKT, TEN_BANG.NS_MA_HTKT);
            return Fs_NS_MA_HTKT_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ GIÁO DỤC PHỔ THÔNG
    [WebMethod(true)]
    public string Fs_NS_MA_GDPT_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_GDPT_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_GDPT_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_GDPT_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ LÝ LUẬN CHÍNH TRỊ
    [WebMethod(true)]
    public string Fs_NS_MA_LLCT_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LLCT_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LLCT_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_LLCT_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ TRÌNH ĐỘ QUẢN LÝ
    [WebMethod(true)]
    public string Fs_NS_MA_TDQL_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TDQL_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TDQL_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_TDQL_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ TRÌNH ĐỘ TIN HỌC
    [WebMethod(true)]
    public string Fs_NS_MA_TDTH_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TDTH_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TDTH_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_TDTH_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion

    #region MÃ XẾP LOẠI
    [WebMethod(true)]
    public string Fs_NS_MA_XLOAI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_XLOAI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_XLOAI_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_XLOAI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XLOAI_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_XLOAI_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_XLOAI_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_XLOAI_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_XLOAI_XOA(b_ma); return Fs_NS_MA_XLOAI_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ CẤP ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_MA_CAPDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CAPDT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CAPDT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CAPDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CAPDT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CAPDT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_CAPDT, TEN_BANG.NS_MA_CAPDT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CAPDT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CAPDT_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_thongbao = "";
        double b_tontai_kdt = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KDT, ht_dungchung.CAP_DT, b_ma, ref b_thongbao);
        double b_tontai_kh = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH, ht_dungchung.NS_DT_KH_CAPDT, b_ma, ref b_thongbao);
        if (b_tontai_kdt > 0 || b_tontai_kh > 0)
        {
            return "loi:Cấp đào tạo mã " + b_ma + " đã được sử dụng:loi";
        }
        try
        {
            ns_ma.P_NS_MA_CAPDT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_CAPDT, TEN_BANG.NS_MA_CAPDT);
            return Fs_NS_MA_CAPDT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ LOẠI KẾ HOẠCH

    [WebMethod(true)]
    public string Fs_NS_MA_LKH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.PNS_MA_LKH_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LKH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.P_NS_MA_HEDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LKH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LKH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LKH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LKH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_LKH_XOA(b_ma); return Fs_NS_MA_LKH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ HUY HIỆU ĐẢNG
    [WebMethod(true)]
    public string Fs_NS_MA_HHDANG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HHDANG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HHDANG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HHDANG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HHDANG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_HHDANG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HHDANG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HHDANG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_HHDANG_XOA(b_ma); return Fs_NS_MA_HHDANG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ HUY HIỆU ĐẢNG

    #region MÃ LOẠI KHEN THƯỞNG
    [WebMethod(true)]
    public string Fs_NS_MA_LKT_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LKT_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LKT_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_LKT_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }
    #endregion MÃ LOẠI KHEN THƯỞNG

    #region MÃ HÌNH THỨC KỶ LUẬT
    [WebMethod(true)]
    public string Fs_NS_MA_HTKL_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HTKL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTKL_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_HTKL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTKL_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_HTKL_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_HTKL, TEN_BANG.NS_MA_HTKL);
            return Fs_NS_MA_HTKL_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTKL_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_HTKL_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_HTKL, TEN_BANG.NS_MA_HTKL);
            return Fs_NS_MA_HTKL_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ HÌNH THỨC KỶ LUẬT

    #region MÃ XẾP LOẠI SỨC KHỎE
    [WebMethod(true)]
    public string Fs_NS_MA_LSK_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_LSK_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LSK_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_LSK_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LSK_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LSK_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LSK_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LSK_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_LSK_XOA(b_ma); return Fs_NS_MA_LSK_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ XẾP LOẠI SỨC KHỎE

    #region MÃ BỆNH VIỆN
    [WebMethod(true)]
    public string Fs_MA_BV_QH_XEM(string b_matt, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_QH_DR(b_matt);
            se.P_TG_LUU("ns_ma_bv", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_BV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BV_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_BV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BV_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_BV_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_BV, TEN_BANG.NS_MA_BV);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_BV_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BV_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_TT_BH, ht_dungchung.NOIKHAM_CHUABENH, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_ma.P_NS_MA_BV_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_BV, TEN_BANG.NS_MA_BV);
            return Fs_NS_MA_BV_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region TỶ LỆ PHẦN TRĂM ĐÓNG BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_MA_TYLE_BH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_TYLE_BH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "muctran_bhxh,muctran_bhyt,muctran_bhtn,cty_bhxh,cty_bhyt,cty_bhtn,nv_bhxh,nv_bhyt,nv_bhtn,heso_omdau,heso_thaisan,nghi_tainha,nghi_taptrung,nghihuu_nam,nghihuu_nu");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TYLE_BH_MA(string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_TYLE_BH_MA(b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "muctran_bhxh,muctran_bhyt,muctran_bhtn,cty_bhxh,cty_bhyt,cty_bhtn,nv_bhxh,nv_bhyt,nv_bhtn,heso_omdau,heso_thaisan,nghi_tainha,nghi_taptrung,nghihuu_nam,nghihuu_nu");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay_hl", b_ngay_hl);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TYLE_BH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_hl");
            bang.P_CSO_SO(ref b_dt_ct, "muctran_bhxh,muctran_bhyt,muctran_bhtn,cty_bhxh,cty_bhyt,cty_bhtn,nv_bhxh,nv_bhyt,nv_bhtn,heso_omdau,heso_thaisan,nghi_tainha,nghi_taptrung,nghihuu_nam,nghihuu_nu");

            ns_ma.P_NS_MA_TYLE_BH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_TILE_BH, TEN_BANG.NS_MA_TILE_BH);
            string b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_MA_TYLE_BH_MA(b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TYLE_BH_XOA(string b_ngay_hl, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_TYLE_BH_XOA(b_ngay_hl);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_TILE_BH, TEN_BANG.NS_MA_TILE_BH);
            return Fs_NS_MA_TYLE_BH_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion

    #region MÃ TIỀN TỆ
    [WebMethod(true)]
    public string Fs_NS_MA_NTE_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NTE_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "tygia");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NTE_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NTE_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "tygia");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NTE_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NTE_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NTE_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NTE_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NTE_XOA(b_ma); return Fs_NS_MA_NTE_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ TIỀN TỆ

    #region MÃ HÌNH THỨC THÔI VIỆC
    [WebMethod(true)]
    public string Fs_NS_MA_HTTV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HTTV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTTV_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HTTV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTTV_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_HTTV_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HTTV_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTTV_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_HTTV_XOA(b_ma); return Fs_NS_MA_HTTV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ HÌNH THỨC THÔI VIỆC

    #region MÃ TÚI HỒ SƠ
    [WebMethod(true)]
    public string Fs_NS_MA_THS_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_THS_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_THS_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_THS_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_THS_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_THS_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_THS, TEN_BANG.NS_MA_THS);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_THS_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_THS_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try
        {
            ns_ma.P_NS_MA_THS_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_THS, TEN_BANG.NS_MA_THS);
            return Fs_NS_MA_THS_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region MÃ NHÓM CHỨC DANH CÔNG VIỆC
    [WebMethod(true)]
    public string Fs_NS_MA_NCDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NCDANH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NCDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_NCDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NCDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NCDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NCDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NCDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_NCDANH_XOA(b_ma); return Fs_NS_MA_NCDANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ NHÓM CHỨC DANH CÔNG VIỆC

    #region  MÃ CHỨC DANH CÔNG VIỆC
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_LKE_DR(string b_ncdanh)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CDANH_LKE_DR(b_ncdanh);
            bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
            return bang.Fs_BANG_CH(b_dt, "ma,ten");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_HOI(string b_cdanh, string b_ncdanh)
    {
        try
        {
            return ns_ma.Fdt_NS_MA_CDANH_HOI(b_cdanh, b_ncdanh);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_LKE(string b_ncdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CDANH_LKE(b_ncdanh, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_MA(string b_ncdanh, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CDANH_MA(b_ncdanh, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ncdanh = mang.Fs_TEN_GTRI("ncdanh", a_cot, a_gtri);
            return Fs_NS_MA_CDANH_MA(b_ncdanh, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_XOA(string b_ncdanh, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CDANH_XOA(b_ncdanh, b_ma); return Fs_NS_MA_CDANH_LKE(b_ncdanh, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHỨC DANH CÔNG VIỆC

    #region MÃ BẬC CHỨC DANH
    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_HOI(string b_ncdanh, string b_cdanh, string b_ma)
    {
        try
        {
            DataRow b_dr = ns_ma.Fdr_NS_MA_BACCDANH_HOI(b_ncdanh, b_cdanh, b_ma);
            return b_dr.IsNull("hso") ? "" : b_dr["hso"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_LKE(string b_ncdanh, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_BACCDANH_LKE(b_ncdanh, b_cdanh, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_MA(string b_ncdanh, string b_cdanh, string b_ngayd, double b_trangkt, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_BACCDANH_MA(b_ncdanh, b_cdanh, b_ngayd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2], b_dt_ct = (DataTable)a_object[3];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngayd", b_ngayd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1])
                + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_ma.Fdt_NS_MA_BACCDANH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk; bang.P_CNG_SO(ref b_dt_ct, "ngayd");
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ma", "");
            ns_ma.P_NS_MA_BACCDANH_NH(b_so_id, b_dt_ct, b_dt_dk);
            string b_ngayd = mang.Fs_TEN_GTRI("ngayd", a_cot, a_gtri);
            string b_ncdanh = mang.Fs_TEN_GTRI("ncdanh", a_cot, a_gtri);
            string b_cdanh = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            return Fs_NS_MA_BACCDANH_MA(b_ncdanh, b_cdanh, b_ngayd, b_trangKT, a_cot_lke, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BACCDANH_XOA(string b_ncdanh, string b_cdanh, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_BACCDANH_XOA(b_so_id); return Fs_NS_MA_BACCDANH_LKE(b_ncdanh, b_cdanh, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    //liệt kê chức danh thao mã ngạch ngành nghề
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CD_BYNNN(string b_form, string b_ncdanh)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_CDANH_BYNNN(b_ncdanh);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { 0, "" }, 0);
            se.P_TG_LUU(b_form, "DT_CDANH", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ BẬC CHỨC DANH

    #region MÃ NHÓM CHỨC DANH CHẤM CÔNG SẢN LƯỢNG
    [WebMethod(true)]
    public string Fs_NS_MA_CC_NCDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CC_NCDANH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CC_NCDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CC_NCDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_NCDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CC_NCDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CC_NCDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_NCDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CC_NCDANH_XOA(b_ma); return Fs_NS_MA_CC_NCDANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ NHÓM CHỨC DANH CÔNG VIỆC

    #region  MÃ CHỨC DANH CÔNG VIỆC CHẤM CÔNG SẢN LƯỢNG
    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_LKE_DR(string b_ncdanh)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CC_CDANH_LKE_DR(b_ncdanh);
            bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
            return bang.Fs_BANG_CH(b_dt, "ma,ten");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_HOI(string b_cdanh, string b_ncdanh)
    {
        try
        {
            return ns_ma.Fdt_NS_MA_CC_CDANH_HOI(b_cdanh, b_ncdanh);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_LKE(string b_ncdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CC_CDANH_LKE(b_ncdanh, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_MA(string b_ncdanh, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CC_CDANH_MA(b_ncdanh, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CC_CDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ncdanh = mang.Fs_TEN_GTRI("ncdanh", a_cot, a_gtri);
            return Fs_NS_MA_CC_CDANH_MA(b_ncdanh, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_CDANH_XOA(string b_ncdanh, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CC_CDANH_XOA(b_ncdanh, b_ma); return Fs_NS_MA_CC_CDANH_LKE(b_ncdanh, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHỨC DANH CÔNG VIỆC

    #region MÃ BẬC CHỨC DANH CHẤM CÔNG SẢN LƯỢNG
    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_HOI(string b_ncdanh, string b_cdanh, string b_ma)
    {
        try
        {
            DataRow b_dr = ns_ma.Fdr_NS_MA_CC_BACCDANH_HOI(b_ncdanh, b_cdanh, b_ma);
            return b_dr.IsNull("hso") ? "" : b_dr["hso"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_LKE(string b_ncdanh, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CC_BACCDANH_LKE(b_ncdanh, b_cdanh, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_MA(string b_ncdanh, string b_cdanh, string b_ngayd, double b_trangkt, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CC_BACCDANH_MA(b_ncdanh, b_cdanh, b_ngayd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2], b_dt_ct = (DataTable)a_object[3];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngayd", b_ngayd);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1])
                + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_ma.Fdt_NS_MA_CC_BACCDANH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk; bang.P_CNG_SO(ref b_dt_ct, "ngayd");
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ma", "");
            bang.P_CSO_SO(ref b_dt_dk, "hso,sl_yc");
            ns_ma.P_NS_MA_CC_BACCDANH_NH(b_so_id, b_dt_ct, b_dt_dk);
            string b_ngayd = mang.Fs_TEN_GTRI("ngayd", a_cot, a_gtri);
            string b_ncdanh = mang.Fs_TEN_GTRI("ncdanh", a_cot, a_gtri);
            string b_cdanh = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            return Fs_NS_MA_CC_BACCDANH_MA(b_ncdanh, b_cdanh, b_ngayd, b_trangKT, a_cot_lke, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CC_BACCDANH_XOA(string b_ncdanh, string b_cdanh, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_CC_BACCDANH_XOA(b_so_id); return Fs_NS_MA_CC_BACCDANH_LKE(b_ncdanh, b_cdanh, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ BẬC CHỨC DANH

    #region MÃ HÌNH THỨC CÔNG TÁC
    [WebMethod(true)]
    public string Fs_NS_MA_HTCTAC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_HTCTAC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTCTAC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_HTCTAC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTCTAC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_HTCTAC_NH(b_dt_ct, ref b_ma);
            return Fs_NS_MA_HTCTAC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HTCTAC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_HTCTAC_XOA(b_ma); return Fs_NS_MA_HTCTAC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion MÃ HÌNH THỨC CÔNG TÁC

    #region MÃ TAY NGHỀ

    [WebMethod(true)]
    public string Fs_NS_MA_TAYNGHE_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TAYNGHE_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TAYNGHE_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TAYNGHE_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TAYNGHE_NH(object[] b_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])b_dt[0]);
            object[] a_gtri = (object[])b_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_TAYNGHE_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TAYNGHE_XOA(string b_ma)
    {
        try
        {
            ns_ma.P_NS_MA_TAYNGHE_XOA(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }

    #endregion MÃ TAY NGHỀ

    #region MÃ BẬC TAY NGHỀ
    [WebMethod(true)]
    public string Fs_NS_MA_BACTAYNGHE_HOI(string b_taynghe, string b_ma, string b_ngayd)
    {
        try
        {
            DataRow b_dr = ns_ma.Fdr_NS_MA_BACTAYNGHE_HOI(b_taynghe, b_ma, b_ngayd);
            return b_dr.IsNull("hso") ? "" : b_dr["hso"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BACTAYNGHE_LKE(string b_taynghe, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_BACTAYNGHE_LKE(b_taynghe);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BACTAYNGHE_CT(string b_dat, string b_taynghe, string b_ngayd, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_BACTAYNGHE_CT(b_taynghe, b_ngayd);
            return b_dat + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BACTAYNGHE_NH(object[] a_dt_ct, object[] a_dt_dk)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt_dk[0]); object[] a_gtri_dk = (object[])a_dt_dk[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct), b_dt_dk;
            if (a_gtri_dk == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_dk, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk); bang.P_DON(ref b_dt_dk); }
            ns_ma.P_NS_MA_BACTAYNGHE_NH(b_dt_ct, b_dt_dk); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BACTAYNGHE_XOA(string b_taynghe, string b_ngayd)
    {
        try
        {
            ns_ma.P_NS_MA_BACTAYNGHE_XOA(b_taynghe, b_ngayd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }

    }

    #endregion MÃ BẬC TAY NGHỀ

    #region  FILE LƯU
    [WebMethod(true)]
    public string Fs_FILE_LUU_LKE(string b_forms, string b_nv, string b_ten_kq, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_FILE_LUU_LKE(b_forms, b_nv, b_ten_kq, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_FILE_LUU_XOA(string b_so_id, string b_forms, string b_nv, string b_ten_kq, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_FILE_LUU_XOA(b_so_id, b_forms, b_nv, b_ten_kq); return Fs_FILE_LUU_LKE(b_forms, b_nv, b_ten_kq, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ KỸ NĂNG CẦN ĐÀO TẠO

    #region MÃ KỸ NĂNG CÁ NHÂN
    [WebMethod(true)]
    public string Fs_NS_MA_KYNANG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_KYNANG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KYNANG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_KYNANG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KYNANG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_KYNANG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_KYNANG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KYNANG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_KYNANG_XOA(b_ma); return Fs_NS_MA_KYNANG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THIẾT LẬP EMAIL THÔNG BÁO

    [WebMethod(true)]
    public string Fs_NS_TLAP_EMAIL_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TLAP_EMAIL_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TLAP_EMAIL, TEN_BANG.NS_TLAP_EMAIL);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TLAP_EMAIL_CT()
    {
        try
        {
            DataTable b_dt = ns_ma.P_NS_TLAP_EMAIL_CT();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TLAP_EMAIL_XOA()
    {
        try
        {
            ns_ma.P_NS_TLAP_EMAIL_XOA();
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TLAP_EMAIL, TEN_BANG.NS_TLAP_EMAIL);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TLAP_EMAIL_TEST(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataRow b_dr = b_dt_ct.Rows[0];
            string email = chuyen.OBJ_S(b_dr["email"]);
            string matkhau = chuyen.OBJ_S(b_dr["matkhau"]);
            string smtp = chuyen.OBJ_S(b_dr["smtp"]);
            string ssl = chuyen.OBJ_S(b_dr["ssl"]);
            int port = chuyen.OBJ_I(b_dr["port"]);
            string subject = "Hrm.cerp.vn kiểm tra tính khả thi email";
            string body = "Hrm.cerp.vn kiểm tra tính khả thi email \nEmail khả thi!";
            SmtpMail.SendMailTest(email, matkhau, smtp, ssl, port, email, subject, body);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion: THIẾT LẬP EMAIL THÔNG BÁO

    #region THIẾT LẬP THÔNG TIN LIÊN HỆ BẢNG LƯƠNG THÔNG BÁO

    [WebMethod(true)]
    public string Fs_NS_TLAP_TTLH_BLUONG_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TLAP_TTLH_BLUONG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TLAP_TTLH_BLUONG, TEN_BANG.NS_TLAP_TTLH_BLUONG);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TLAP_TTLH_BLUONG_CT()
    {
        try
        {
            DataTable b_dt = ns_ma.P_NS_TLAP_TTLH_BLUONG_CT();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TLAP_TTLH_BLUONG_XOA()
    {
        try
        {
            ns_ma.P_NS_TLAP_TTLH_BLUONG_XOA();
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TLAP_TTLH_BLUONG, TEN_BANG.NS_TLAP_TTLH_BLUONG);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion: THIẾT LẬP THÔNG TIN LIÊN HỆ BẢNG LƯƠNG THÔNG BÁO

    #region MÃ TÀI SẢN

    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_DR_NHOM(string b_login, string b_nhom, string b_formName, string b_tableName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_TAISAN_DR_NHOM(b_nhom);
            se.P_TG_LUU(b_formName, b_tableName, b_dt);
            string[] a_cot = new string[] { "ma", "ten" };
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_LKE(string b_login, double[] a_tso, string[] a_cot, string b_day)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_TAISAN_LKE(b_tu_n, b_den_n, b_day); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "TEN_TRANGTHAI", "TRANGTHAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_TAISAN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "TEN_TRANGTHAI", "TRANGTHAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "sotien");
            string b_ma = "";
            ns_ma.P_NS_MA_TAISAN_NH(b_dt_ct, ref b_ma);
            return Fs_NS_MA_TAISAN_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_TAISAN_XOA(b_ma);
            return Fs_NS_MA_TAISAN_LKE(b_login, a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_TAISAN_TIEN(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_ma.Fdt_NS_MA_TAISAN_TIEN(b_ma);
            return chuyen.SO_CSO(chuyen.OBJ_N(a_obj[0]), 3);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ THỦ TỤC
    [WebMethod(true)]
    public string Fs_NS_MA_THUTUC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_THUTUC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_THUTUC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_THUTUC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_THUTUC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_THUTUC_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_THUTUC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_THUTUC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_NS_MA_THUTUC_XOA(b_ma); return Fs_NS_MA_THUTUC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region BIẾN ĐỘNG BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("LOAI_MA");
            DataRow dr = b_dt.NewRow();
            dr["LOAI_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "ns_ma_khac", "DT_NS_MA_KHAC", "LOAI_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_LKE(double[] a_tso, string[] a_cot, string a_loaima)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_KHAC_LKE(b_tu_n, b_den_n, a_loaima);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_MA(string b_ma, string b_loai_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_KHAC_MA(b_ma, b_loai_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_KHAC_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_KHAC, TEN_BANG.NS_MA_KHAC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            //double b_loai_ma = chuyen.OBJ_N(mang.Fs_TEN_GTRI("loai_ma", a_cot, a_gtri));
            string b_loai_ma = mang.Fs_TEN_GTRI("loai_ma", a_cot, a_gtri);
            return Fs_NS_MA_KHAC_MA(b_ma, b_loai_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_XOA(string b_ma, string b_loai_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_KHAC_XOA(b_ma, b_loai_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_KHAC, TEN_BANG.NS_MA_KHAC);
            return Fs_NS_MA_KHAC_LKE(a_tso, a_cot, b_loai_ma);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region PHƯƠNG ÁN SỬ DỤNG BIẾN ĐỘNG BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_MA_BIENDONGBHXH_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("LOAI_MA");
            DataRow dr = b_dt.NewRow();
            dr["LOAI_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "ns_ma_biendongbhxh", "DT_NS_MA_BIENDONGBHXH", "LOAI_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BIENDONGBHXH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_BIENDONGBHXH_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "T", "Tăng");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "G", "Giảm");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "DC", "Điều chỉnh");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BIENDONGBHXH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_BIENDONGBHXH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "T", "Tăng");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "G", "Giảm");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "DC", "Điều chỉnh");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BIENDONGBHXH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_BIENDONGBHXH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_BIENDONGBHXH, TEN_BANG.NS_MA_BIENDONGBHXH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            //double b_loai_ma = chuyen.OBJ_N(mang.Fs_TEN_GTRI("loai_ma", a_cot, a_gtri));
            return Fs_NS_MA_BIENDONGBHXH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BIENDONGBHXH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_BIENDONGBHXH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_BIENDONGBHXH, TEN_BANG.NS_MA_BIENDONGBHXH);
            return Fs_NS_MA_BIENDONGBHXH_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region PHƯƠNG ÁN CHẾ ĐỘ BẢO HIỂM

    [WebMethod(true)]
    public string Fs_NS_MA_PHUONGANCHEDOBH_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_PHUONGANCHEDOBH_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, "ns_ma_phuonganchedobh", "DT_NHOM_CD", "MA_NHOM");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]

    public string Fs_NS_MA_PHUONGANCHEDOBH_LKE(string b_ma_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_PHUONGANCHEDOBH_LKE(b_ma_nhom, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_PHUONGANCHEDOBH_MA(string b_ma_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_PHUONGANCHEDOBH_MA(b_ma_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trang_thai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PHUONGANCHEDOBH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_PHUONGANCHEDOBH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_PHUONGANCHEDOBH, TEN_BANG.NS_MA_PHUONGANCHEDOBH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            //double b_loai_ma = chuyen.OBJ_N(mang.Fs_TEN_GTRI("loai_ma", a_cot, a_gtri));
            string b_ma_nhom = mang.Fs_TEN_GTRI("ma_nhom", a_cot, a_gtri);
            return Fs_NS_MA_PHUONGANCHEDOBH_MA(b_ma_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PHUONGANCHEDOBH_XOA(string b_ma_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_PHUONGANCHEDOBH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_PHUONGANCHEDOBH, TEN_BANG.NS_MA_PHUONGANCHEDOBH);
            return Fs_NS_MA_PHUONGANCHEDOBH_LKE(b_ma_nhom, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region NHÓM BIẾN ĐỘNG BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_NHOM_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_KHAC_NHOM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_NHOM_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_KHAC_NHOM_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_NHOM_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_KHAC_NHOM_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_KHAC_NHOM, TEN_BANG.NS_MA_KHAC_NHOM);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_KHAC_NHOM_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHAC_NHOM_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_TT_BH, ht_dungchung.NOIKHAM_CHUABENH, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_ma.P_NS_MA_KHAC_NHOM_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_KHAC_NHOM, TEN_BANG.NS_MA_KHAC_NHOM);
            return Fs_NS_MA_KHAC_NHOM_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region NHÓM CHẾ ĐỘ BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHEDO_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_NHOM_CHEDO_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHEDO_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_NHOM_CHEDO_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TRANG_THAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHEDO_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NHOM_CHEDO_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NHOM_CHEDO, TEN_BANG.NS_MA_NHOM_CHEDO);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NHOM_CHEDO_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHEDO_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_MA_LYDOBHXH, ht_dungchung.MA_NHOM, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_ma.P_NS_MA_NHOM_CHEDO_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NHOM_CHEDO, TEN_BANG.NS_MA_NHOM_CHEDO);
            return Fs_NS_MA_NHOM_CHEDO_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CHẾ ĐỘ BHXH
    [WebMethod(true)]
    public string Fs_NS_MA_LYDOBHXH_LKE(string b_ma_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Faobj_NS_MA_LYDOBHXH_LKE(b_ma_nhom, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LYDOBHXH_MA(string b_ma_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Faobj_NS_MA_LYDOBHXH_MA(b_ma_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LYDOBHXH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_LYDOBHXH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_LYDOBHXH, TEN_BANG.NS_MA_LYDOBHXH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ma_nhom = mang.Fs_TEN_GTRI("ma_nhom", a_cot, a_gtri);
            return Fs_NS_MA_LYDOBHXH_MA(b_ma_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LYDOBHXH_XOA(string b_ma_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_LYDOBHXH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_LYDOBHXH, TEN_BANG.NS_MA_LYDOBHXH);
            return Fs_NS_MA_LYDOBHXH_LKE(b_ma_nhom, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CHI PHÍ GÓI BẢO HIỂM CMC CARE
    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_CMCCARE_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CHIPHI_CMCCARE_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_CMCCARE_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_CHIPHI_CMCCARE_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_CMCCARE_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt_ct, "phibh_nam");
            ns_ma.P_NS_MA_CHIPHI_CMCCARE_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CHIPHI_CMCCARE_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_CMCCARE_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_ma.P_NS_MA_CHIPHI_CMCCARE_XOA(b_ma); return Fs_NS_MA_CHIPHI_CMCCARE_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region GÓI BẢO HIỂM AETNA
    [WebMethod(true)]
    public string Fs_NS_MA_BH_AETNA_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_BH_AETNA_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "mucphi");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_BH_AETNA_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_BH_AETNA_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "mucphi");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BH_AETNA_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "mucphi");
            ns_ma.P_NS_MA_BH_AETNA_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_BH_AETNA_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BH_AETNA_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_ma.P_NS_MA_BH_AETNA_XOA(b_ma); return Fs_NS_MA_BH_AETNA_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THIẾT LẬP ĐIỀU KIỆN HƯỞNG CMC CARE
    [WebMethod(true)]
    public string Fs_NS_TLAP_DK_CMCCARE_CT(string b_login, string b_so_id, string[] a_cot_nnnghiep, string[] a_cot_cdanh, string[] a_cot_level, string[] a_cot_lhd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_ma.Fdt_NS_TLAP_DK_CMCCARE_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_nnnghiep_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_nnnghiep),
                   b_dt_cdanh_s = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[2], a_cot_cdanh),
                   b_dt_level_s = bang.Fb_TRANG(b_ds.Tables[3]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[3], a_cot_level),
                   b_dt_lhd_s = bang.Fb_TRANG(b_ds.Tables[4]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[4], a_cot_lhd);
            return b_dt_s + "#" + b_dt_nnnghiep_s + "#" + b_dt_cdanh_s + "#" + b_dt_level_s + "#" + b_dt_lhd_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TLAP_DK_CMCCARE_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_TLAP_DK_CMCCARE_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TLAP_DK_CMCCARE_NH(string b_login, string b_so_id, object[] a_dt, object[] a_dt_nnnghiep, object[] a_dt_cdanh, object[] a_dt_level, object[] a_dt_lhd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]), a_cot_nnnghiep = chuyen.Fas_OBJ_STR((object[])a_dt_nnnghiep[0]),
                     a_cot_cdanh = chuyen.Fas_OBJ_STR((object[])a_dt_cdanh[0]), a_cot_level = chuyen.Fas_OBJ_STR((object[])a_dt_level[0]),
                     a_cot_lhd = chuyen.Fas_OBJ_STR((object[])a_dt_lhd[0]);
            object[] a_gtri = (object[])a_dt[1], a_gtri_nnnghiep = (object[])a_dt_nnnghiep[1],
                     a_gtri_cdanh = (object[])a_dt_cdanh[1], a_gtri_level = (object[])a_dt_level[1],
                     a_gtri_lhd = (object[])a_dt_lhd[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_nnnghiep = bang.Fdt_TAO_THEM(a_cot_nnnghiep, a_gtri_nnnghiep),
                      b_dt_cdanh = bang.Fdt_TAO_THEM(a_cot_cdanh, a_gtri_cdanh), b_dt_level = bang.Fdt_TAO_THEM(a_cot_level, a_gtri_level),
                      b_dt_lhd = bang.Fdt_TAO_THEM(a_cot_lhd, a_gtri_lhd);
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt, "thamnien");
            return ns_ma.P_NS_TLAP_DK_CMCCARE_NH(ref b_so_id, b_dt, b_dt_nnnghiep, b_dt_cdanh, b_dt_level, b_dt_lhd);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TLAP_DK_CMCCARE_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.PNS_TLAP_DK_CMCCARE_XOA(b_so_id); return Fs_NS_TLAP_DK_CMCCARE_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP ĐIỀU KIỆN HƯỞNG CMC CARE

    #region MÃ PHÚC LỢI
    [WebMethod(true)]
    public string Fs_NS_MA_PHUCLOI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_PHUCLOI_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            //bang.P_THAY_GTRI(ref b_dt_tk, "is_tudong", "Tự động", "X");
            //bang.P_THAY_GTRI(ref b_dt_tk, "is_tudong", "NU", "");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_PHUCLOI_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_PHUCLOI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PHUCLOI_CT(string b_login, string b_so_id, string[] a_cot_tt, string[] a_cot_gt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_ma.PNS_MA_PHUCLOI_CT(b_so_id);
            string b_kq_hd, b_kq_gt;
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_phucloi", "DT_MA_LVCDANH", "MA_LVCDANH");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_phucloi", "DT_MA_CDANH", "MA_CDANH");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_hd = b_ds.Tables[1];
            if (b_hd.Rows.Count == 0)
            {
                b_hd = ns_ma.Fdt_NS_MA_DAT_LHD();
                bang.P_THEM_COL(ref b_hd, "chon", "");
            }
            b_kq_hd = bang.Fb_TRANG(b_hd) ? "" : bang.Fs_BANG_CH(b_hd, a_cot_tt);
            DataTable b_gt = b_ds.Tables[2];
            if (b_gt.Rows.Count == 0)
            {
                b_gt = ns_ma.Fdt_NS_MA_DAT_GT("GT");
                bang.P_THEM_COL(ref b_gt, "chon", "");
            }
            b_kq_gt = bang.Fb_TRANG(b_gt) ? "" : bang.Fs_BANG_CH(b_gt, a_cot_gt);
            return b_kq + "#" + b_kq_hd + "#" + b_kq_gt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_PHUCLOI_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, object[] a_dt_hd, object[] a_dt_gt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = ht_dungchung.Fdt_AutoGenCode("PL", "NS_MA_PHUCLOI", "MA");
            if (b_dt_ct.Rows[0]["ma"].ToString() == "" || b_dt_ct.Rows[0]["ma"].ToString() == null || (b_so_id == "0" && b_dt_ct.Rows[0]["ma"].ToString() != b_ma))
                bang.P_DAT_GTRI(ref b_dt_ct, "ma", b_ma, 0);
            else
                b_ma = b_dt_ct.Rows[0]["ma"].ToString();
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngay_d", "ngay_c" });
            string[] a_cot_hd = chuyen.Fas_OBJ_STR((object[])a_dt_hd[0]); object[] a_gtri_hd = (object[])a_dt_hd[1];
            DataTable b_dt_hd = bang.Fdt_TAO_THEM(a_cot_hd, a_gtri_hd); bang.P_BO_HANG(ref b_dt_hd, "ma", "");
            if (b_dt_hd.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_hd, new object[] { "", "-1", "" });

            string[] a_cot_gt = chuyen.Fas_OBJ_STR((object[])a_dt_gt[0]); object[] a_gtri_gt = (object[])a_dt_gt[1];
            DataTable b_dt_gt = bang.Fdt_TAO_THEM(a_cot_gt, a_gtri_gt); bang.P_BO_HANG(ref b_dt_gt, "ma", "");
            if (b_dt_gt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_gt, new object[] { "", "-1", "" });

            ns_ma.PNS_MA_PHUCLOI_NH(ref b_so_id, b_dt_ct, b_dt_hd, b_dt_gt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_PHUCLOI, TEN_BANG.NS_MA_PHUCLOI);
            return Fs_NS_MA_PHUCLOI_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_PHUCLOI_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.PNS_MA_PHUCLOI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_PHUCLOI, TEN_BANG.NS_MA_PHUCLOI);
            return Fs_NS_MA_PHUCLOI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_DAT_LHD(string[] a_cot_tt)
    {
        try
        {
            DataTable b_dt_tt = ns_ma.Fdt_NS_MA_DAT_LHD();
            bang.P_THEM_COL(ref b_dt_tt, "chon", "");
            return bang.Fs_BANG_CH(b_dt_tt, a_cot_tt) + "#" + b_dt_tt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_DAT_GT(string[] a_cot_tt)
    {
        try
        {
            DataTable b_dt_tt = ns_ma.Fdt_NS_MA_DAT_GT("GT");
            bang.P_THEM_COL(ref b_dt_tt, "chon", "");
            return bang.Fs_BANG_CH(b_dt_tt, a_cot_tt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ PHÚC LỢI

    #region NHÓM DANH MỤC DÙNG CHUNG.
    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_NHOM_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_NHOM_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_NHOM_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_NHOM_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_NHOM_CHUNG_XOA(b_ma);
            return Fs_NS_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region DANH MỤC DÙNG CHUNG
    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "ns_ma_chung", "DT_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot, string a_loaima)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CHUNG_LKE(b_tu_n, b_den_n, a_loaima);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_chung", "DT_MA_CHUNG_NHOM", "NHOM_MA");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_MA(string b_login, string b_ma, string b_loai_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_CHUNG_MA(b_ma, b_loai_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_chung", "DT_MA_CHUNG_NHOM", "NHOM_MA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_loai_ma = chuyen.OBJ_S(mang.Fs_TEN_GTRI("nhom_ma", a_cot, a_gtri));
            return Fs_NS_MA_CHUNG_MA(b_login, b_ma, b_loai_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_XOA(string b_login, string b_ma, string b_loai_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_CHUNG_XOA(b_ma, b_loai_ma);
            return Fs_NS_MA_CHUNG_LKE(b_login, a_tso, a_cot, b_loai_ma);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_PNS_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region DANH MỤC CÁC TRƯỜNG THÔNG TIN
    [WebMethod(true)]
    public string Fs_NS_MA_FIELD_LKE(string b_loai_tk, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_FIELD_LKE(b_loai_tk, b_ten, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_FIELD_MA(string b_ma, string b_loai_tk, string b_ten, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_FIELD_MA(b_ma, b_loai_tk, b_ten, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_FIELD_NH(string b_loai_tk, string b_ten, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_FIELD_NH(b_loai_tk, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_FIELD, TEN_BANG.NS_MA_FIELD);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_FIELD_MA(b_ma, b_loai_tk, b_ten, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_FIELD_XOA(string b_ma, string b_loai_tk, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_FIELD_XOA(b_ma, b_loai_tk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_FIELD, TEN_BANG.NS_MA_FIELD);
            return Fs_NS_MA_FIELD_LKE(b_loai_tk, b_ten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MÃ NGHỀ NGHIỆP
    [WebMethod(true)]
    public string Fs_hd_ma_nnghe_LKE(double[] a_tso, string[] a_cot, string b_day)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_hd_ma_nnghe_LKE(b_tu_n, b_den_n, b_day); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_nnghe_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_hd_ma_nnghe_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_nnghe_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_hd_ma_nnghe_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_hd_ma_nnghe_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_nnghe_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_hd_ma_nnghe_XOA(b_ma); string b_day = ""; return Fs_hd_ma_nnghe_LKE(a_tso, a_cot, b_day); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ NGHỀ NGHIỆP

    #region MÃ CHUYÊN MÔN

    [WebMethod(true)]
    public string Fs_hd_ma_cmon_LKE(string b_mannghe, string b_day, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_HD_MA_CMON_LKE(b_mannghe, b_day, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];

            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_cmon_MA(string b_mannghe, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_HD_MA_CMON_MA(b_mannghe, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_cmon_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_HD_MA_CMON_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_mannghe = mang.Fs_TEN_GTRI("ma_nnghe", a_cot, a_gtri);
            return Fs_hd_ma_cmon_MA(b_mannghe, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_hd_ma_cmon_XOA(string b_mannghe, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ma.P_HD_MA_CMON_XOA(b_mannghe, b_ma); return Fs_hd_ma_cmon_LKE(b_mannghe, "", a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ CHUYÊN MÔN

    #region NHÓM DANH MỤC DÙNG CHUNG CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_NHOM_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_MA_NHOM_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_NHOM_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_NHOM_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_CC_MA_NHOM_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_CC_MA_NHOM_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_NHOM_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_CC_MA_NHOM_CHUNG_XOA(b_ma);
            return Fs_NS_CC_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG CHẤM CÔNG

    #region DANH MỤC DÙNG CHUNG CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "NS_CC_MA_CHUNG", "DT_CC_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "NS_CC_MA_CHUNG", "DT_CC_MA_CHUNG_NHOM", "NHOM_MA");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "NS_CC_MA_CHUNG", "DT_CC_MA_CHUNG_NHOM", "NHOM_MA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_CC_MA_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_CC_MA_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_XOA(string b_login, string b_ma, string b_loai_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_CC_MA_CHUNG_XOA(b_ma, b_loai_ma);
            return Fs_NS_CC_MA_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_PNS_CC_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion DANH MỤC DÙNG CHUNG CHẤM CÔNG

    #region NHÓM DANH MỤC DÙNG CHUNG ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_DG_MA_NHOM_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_DG_MA_NHOM_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_DG_MA_NHOM_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DG_MA_NHOM_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_DG_MA_NHOM_CHUNG_XOA(b_ma);
            return Fs_NS_DG_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG ĐÁNH GIÁ

    #region DANH MỤC DÙNG CHUNG ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "PNS_DG_MA_CHUNG", "DT_DG_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_DG_MA_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "PNS_DG_MA_CHUNG", "DT_DG_MA_CHUNG_NHOM", "NHOM_MA");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_MA_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_DG_MA_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "PNS_DG_MA_CHUNG", "DT_DG_MA_CHUNG_NHOM", "NHOM_MA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_DG_MA_CHUNG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DG_MA_CHUNG, TEN_BANG.NS_DG_MA_CHUNG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DG_MA_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_DG_MA_CHUNG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DG_MA_CHUNG, TEN_BANG.NS_DG_MA_CHUNG);
            return Fs_NS_DG_MA_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_PNS_DG_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_DG_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC DÙNG CHUNG ĐÁNH GIÁ

    #region NHÓM DANH MỤC DÙNG CHUNG TUYEN DUNG
    [WebMethod(true)]
    public string Fs_NS_TD_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_TD_MA_NHOM_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_MA_NHOM_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_TD_MA_NHOM_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_NHOM_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TD_MA_NHOM_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TD_MA_NHOM_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_NHOM_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_TD_MA_NHOM_CHUNG_XOA(b_ma);
            return Fs_NS_TD_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG TUYEN DUNG

    #region DANH MỤC DÙNG CHUNG TUYEN DUNG
    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "NS_TD_MA_CHUNG", "DT_TD_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_TD_MA_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            //bang.P_TIM_THEM(ref b_dt, "NS_TD_MA_CHUNG", "DT_TD_MA_CHUNG_NHOM", "NHOM_MA");
            bang.P_COPY_COL(ref b_dt, "ten_nhom", "nhom_ma");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTYC", "Trạng thái Yêu cầu TD");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTPD", "Trạng thái phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTTM", "Trạng thái thư mời");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "LCP", "Loại chi phí tuyển dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTUV", "Trạng thái ứng viên");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_TD_MA_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            //bang.P_TIM_THEM(ref b_dt, "NS_TD_MA_CHUNG", "DT_TD_MA_CHUNG_NHOM", "NHOM_MA");
            bang.P_COPY_COL(ref b_dt, "ten_nhom", "nhom_ma");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTYC", "Trạng thái Yêu cầu TD");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTPD", "Trạng thái phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTTM", "Trạng thái thư mời");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "LCP", "Loại chi phí tuyển dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom", "TTUV", "Trạng thái ứng viên");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_TD_MA_CHUNG_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_loai_ma = chuyen.OBJ_S(mang.Fs_TEN_GTRI("nhom_ma", a_cot, a_gtri));
            return Fs_NS_TD_MA_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_TD_MA_CHUNG_XOA(b_ma);
            return Fs_NS_TD_MA_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_PNS_TD_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion DANH MỤC DÙNG CHUNG TUYEN DUNG

    #region NHÓM DANH MỤC DÙNG CHUNG HO SO NHAN SU
    [WebMethod(true)]
    public string Fs_NS_HS_MA_NHOM_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HS_MA_NHOM_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HS_MA_NHOM_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HS_MA_NHOM_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_NHOM_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_HS_MA_NHOM_CHUNG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_HS_MA_CHUNG_NHOM, TEN_BANG.NS_HS_MA_CHUNG_NHOM);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HS_MA_NHOM_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_NHOM_CHUNG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HS_MA_NHOM_CHUNG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_HS_MA_CHUNG_NHOM, TEN_BANG.NS_HS_MA_CHUNG_NHOM);
            return Fs_NS_HS_MA_NHOM_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NHÓM DANH MỤC DÙNG CHUNG HO SO NHAN SU

    #region DANH MỤC DÙNG CHUNG HO SO NHAN SU
    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_CHON(string b_login, string b_ma_nhom)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("NHOM_MA");
            DataRow dr = b_dt.NewRow();
            dr["NHOM_MA"] = b_ma_nhom;
            b_dt.Rows.Add(dr);
            bang.P_TIM_THEM(ref b_dt, "NS_HS_MA_CHUNG", "DT_HS_MA_CHUNG_NHOM", "NHOM_MA");
            return bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HS_MA_CHUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "NS_HS_MA_CHUNG", "DT_HS_MA_CHUNG_NHOM", "NHOM_MA");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HS_MA_CHUNG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "NS_HS_MA_CHUNG", "DT_HS_MA_CHUNG_NHOM", "NHOM_MA");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_HS_MA_CHUNG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_HS_MA_CHUNG, TEN_BANG.NS_HS_MA_CHUNG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_loai_ma = chuyen.OBJ_S(mang.Fs_TEN_GTRI("nhom_ma", a_cot, a_gtri));
            return Fs_NS_HS_MA_CHUNG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_XOA(string b_login, string b_nhom_ma, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HS_MA_CHUNG_XOA(b_nhom_ma, b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_HS_MA_CHUNG, TEN_BANG.NS_HS_MA_CHUNG);
            return Fs_NS_HS_MA_CHUNG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HS_MA_CHUNG_LKE_DR(string b_nhom_ma)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_PNS_HS_MA_CHUNG_DR_A(b_nhom_ma);
            string b_ma = "," + bang.Fs_COT_CH(b_dt, "MA", ",");
            string b_ten = bang.Fs_COT_CH(b_dt, "TEN", ",");
            return b_ma + "#" + b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion DANH MỤC DÙNG CHUNG HO SO NHAN SU

    #region DANH MỤC PHAN LOAI CAN BO
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_PLNV_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HDNS_MA_PLNV_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_PLNV_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HDNS_MA_PLNV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_PLNV_CT(string b_login, string b_ma, string[] a_cot_lke_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_ma.Fds_NS_HDNS_MA_PLNV_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_cd = b_ds.Tables[1];
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_cd) ? "" : bang.Fs_BANG_CH(b_dt_cd, a_cot_lke_cd)))
                + "#" + b_dt_cd.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_PLNV_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_ct_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            // thông tin chức danh
            string[] a_cot_ct_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cd[0]);
            object[] a_gtri_ct_cd = (object[])a_dt_ct_cd[1];
            DataTable b_dt_ct_cd;
            if (a_gtri_ct_cd == null)
                b_dt_ct_cd = bang.Fdt_TAO_BANG(a_cot_ct_cd, "SS");
            else
                b_dt_ct_cd = bang.Fdt_TAO_THEM(a_cot_ct_cd, a_gtri_ct_cd);
            bang.P_BO_HANG(ref b_dt_ct_cd, "ma_cd", "");
            bang.P_CSO_SO(ref b_dt_ct_cd, "so_id");
            if (b_dt_ct_cd.Rows.Count == 0)
            {
                return "loi:Bạn chưa nhập chức danh:loi";
            }
            ns_ma.P_NS_HDNS_MA_PLNV_NH(b_dt_ct, b_dt_ct_cd);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_PLNV_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_PLNV_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HDNS_MA_PLNV_XOA(b_ma);
            return Fs_NS_HDNS_MA_PLNV_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC PHAN LOAI CAN BO

    #region DANH MỤC CẤP CÁN BỘ

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_LKE_ALL(string b_login, string b_form_name, string b_table_name)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_CAPNV_LKE_ALL();
            se.P_TG_LUU(b_form_name, b_table_name, b_dt);
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_LKE_ALL2(string b_login, string b_form_name, string b_table_name)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_CAPNV_LKE_ALL();
            DataRow b_dr = b_dt.NewRow();
            b_dr["ma"] = ""; b_dr["ten"] = "";
            b_dt.Rows.InsertAt(b_dr, 0);
            se.P_TG_LUU(b_form_name, b_table_name, b_dt);
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_LKE_DR(string b_login, string b_form_name, string b_table_name, string b_plnv, string b_tt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            if (b_plnv != "")
                b_dt = ns_ma.Fdt_NS_HDNS_MA_CAPNV_LKE_DR(b_plnv, b_tt);
            else
                b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
            DataRow b_dr = b_dt.NewRow();
            b_dr["ma"] = ""; b_dr["ten"] = "";
            b_dt.Rows.InsertAt(b_dr, 0);
            se.P_TG_LUU(b_form_name, b_table_name, b_dt);
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_HDNS_MA_CAPNV_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_COPY_COL(ref b_dt, "MAPLNV", "MA_PLNV");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_capnv", "DT_HD_MA_PLNV", "MA_PLNV");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_MA(string b_login, string b_ma_plnv, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_HDNS_MA_CAPNV_MA(b_ma_plnv, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma_plnv", "ma" }, new object[] { b_ma_plnv, b_ma });
            bang.P_COPY_COL(ref b_dt, "MAPLNV", "MA_PLNV");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_capnv", "DT_HD_MA_PLNV", "MA_PLNV");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_CT(string b_login, string b_ma_plnv, string b_ma, string[] a_cot_lke_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_ma.Fds_NS_HDNS_MA_CAPNV_CT(b_ma_plnv, b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_cd = b_ds.Tables[1];
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_capnv", "DT_HD_MA_PLNV", "MA_PLNV");
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_cd) ? "" : bang.Fs_BANG_CH(b_dt_cd, a_cot_lke_cd)))
                + "#" + b_dt_cd.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_ct_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            // thông tin chức danh
            string[] a_cot_ct_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cd[0]);
            object[] a_gtri_ct_cd = (object[])a_dt_ct_cd[1];
            DataTable b_dt_ct_cd;
            if (a_gtri_ct_cd == null)
                b_dt_ct_cd = bang.Fdt_TAO_BANG(a_cot_ct_cd, "SS");
            else
                b_dt_ct_cd = bang.Fdt_TAO_THEM(a_cot_ct_cd, a_gtri_ct_cd);
            bang.P_BO_HANG(ref b_dt_ct_cd, "ma_cd", "");
            bang.P_CSO_SO(ref b_dt_ct_cd, "so_id");
            if (b_dt_ct_cd.Rows.Count == 0)
            {
                return "loi:Bạn chưa nhập chức danh:loi";
            }
            ns_ma.P_NS_HDNS_MA_CAPNV_NH(b_dt_ct, b_dt_ct_cd);
            string b_ma_plnv = mang.Fs_TEN_GTRI("ma_plnv", a_cot, a_gtri), b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_CAPNV_MA(b_login, b_ma_plnv, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CAPNV_XOA(string b_login, string b_ma_plnv, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_HDNS_MA_CAPNV_XOA(b_ma_plnv, b_ma);
            return Fs_NS_HDNS_MA_CAPNV_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC CẤP CÁN BỘ

    #region DANH MỤC THAM SO HE THONG CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSO_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_TSO_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, new string[] { "NG_BDAU", "NG_KTHUC" });
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSO_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_CC_MA_TSO_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, new string[] { "NG_BDAU", "NG_KTHUC" });
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSO_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "NG_BDAU", "NG_KTHUC" });
            ns_ma.P_NS_CC_MA_TSO_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_CC_MA_TSO_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_MA_TSO_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_CC_MA_TSO_XOA(b_ma);
            return Fs_NS_CC_MA_TSO_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC THAM SO HE THONG CHẤM CÔNG

    #region DANH MỤC QUYẾT ĐỊNH
    [WebMethod(true)]
    public string Fs_NS_MA_QDINH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_ma.Faobj_NS_MA_QDINH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_QDINH_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_ma.Faobj_NS_MA_QDINH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_QDINH_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ma.P_NS_MA_QDINH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_QDINH, TEN_BANG.NS_MA_QDINH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_QDINH_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QDINH_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDCT, ht_dungchung.HTHUC, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_ma.P_NS_MA_QDINH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_QDINH, TEN_BANG.NS_MA_QDINH);
            return Fs_NS_MA_QDINH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC QUYẾT ĐỊNH

    #region MÃ KHUNG LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_KHUNGLUONG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];

            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc"); bang.P_SO_CSO(ref b_dt, "mucmin,mucmax,diemgiua");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_KHUNGLUONG_MA(b_ma, b_trangkt); ;
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma" }, new string[] { b_ma });
            bang.P_TIM_THEM(ref b_dt, "ns_ma_khungluong", "DT_MA_NCD", "MA_NCD");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_khungluong", "DT_MA_CAP", "MA_CAP");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc"); bang.P_SO_CSO(ref b_dt, "mucmin,mucmax,diemgiua");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_CT(string b_login, string b_ma, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_ma.Fdt_NS_MA_KHUNGLUONG_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];

            bang.P_TIM_THEM(ref b_dt, "ns_ma_khungluong", "DT_MA_NCD", "MA_NCD");
            bang.P_TIM_THEM(ref b_dt, "ns_ma_khungluong", "DT_MA_CAP", "MA_CAP");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc"); bang.P_SO_CSO(ref b_dt, "mucmin,mucmax,diemgiua");

            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_kq + "#" + b_dt_ct_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_NH(string b_login, double b_trangKT, object[] a_dt, string[] a_cot_lke, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct.Rows.Count < 1)
                return Thongbao_dch.nhapdulieu_luoi;
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt, "mucmin,mucmax,diemgiua");
            ns_ma.P_NS_MA_KHUNGLUONG_NH(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_MA_KHUNGLUONG, TEN_BANG.NS_MA_KHUNGLUONG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_KHUNGLUONG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ma.P_NS_MA_KHUNGLUONG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_MA_KHUNGLUONG, TEN_BANG.NS_MA_KHUNGLUONG);
            return Fs_NS_MA_KHUNGLUONG_LKE(b_login, a_tso, a_cot);

        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH(string b_form, string b_ma_ncd, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CDANH_LIST(b_ma_ncd);
            bang.P_THEM_COL(ref b_dt, "chon", "");
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KHUNGLUONG_CHECK(string b_login, string b_ngayd, string b_cdanh, string b_tongthunhap)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ma.Fdt_NS_MA_KHUNGLUONG_CHECK(b_ngayd, b_cdanh, b_tongthunhap);
            DataTable b_dt = (DataTable)a_object[0];
            string b_count = b_dt.Rows[0]["tong"].ToString();
            return b_count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MÃ KHUNG LƯƠNG

    #region MÃ QUẢN TRỊ RỦI RO
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_QTRR_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_QTRR_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_QTRR_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_QTRR_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QTRR_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_QTRR_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_QTRR, TEN_BANG.NS_MA_QTRR);
            return Fs_NS_MA_QTRR_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QTRR_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CB, ht_dungchung.QTRR, b_ma, ref b_thongbao);
            if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            else
            {
                b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DS_CCHN, ht_dungchung.QTRR, b_ma, ref b_thongbao);
                if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            }

            ns_ma.P_NS_MA_QTRR_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_QTRR, TEN_BANG.NS_MA_QTRR);
            return Fs_NS_MA_QTRR_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion  MÃ QUẢN TRỊ RỦI RO

    #region MÃ ỦY BAN CHỨNG KHOÁN
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_UBCK_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_UBCK_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_UBCK_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_UBCK_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_UBCK_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_UBCK_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_UBCK, TEN_BANG.NS_MA_UBCK);
            return Fs_NS_MA_UBCK_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_UBCK_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CB, ht_dungchung.UBCK, b_ma, ref b_thongbao);
            if (b_tontai > 0)
            {
                return "loi:Mã ủy ban chứng khoán " + b_ma + " đã được sử dụng:loi";
            }
            ns_ma.P_NS_MA_UBCK_XOA(b_ma);
            return Fs_NS_MA_UBCK_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion  MÃ ỦY BAN CHỨNG KHOÁN

    #region MÃ CHỨNG CHỈ HÀNH NGHỀ
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_CCHN_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CCHN_LKE(b_tu_n, b_den_n, b_tt);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CCHN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CCHN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CCHN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_CCHN_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_CCHN, TEN_BANG.NS_MA_CCHN);
            return Fs_NS_MA_CCHN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CCHN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_CCHN_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_CCHN, TEN_BANG.NS_MA_CCHN);
            return Fs_NS_MA_CCHN_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion  MÃ CHỨNG CHỈ HÀNH NGHỀ

    #region MÃ CHỨNG CHỈ CON
    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_CCC_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_MA_CCC_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CCC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_MA_CCC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CCC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_MA_CCC_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_CCC, TEN_BANG.NS_MA_CCC);
            return Fs_NS_MA_CCC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CCC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_MA_CCC_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_CCC, TEN_BANG.NS_MA_CCC);
            return Fs_NS_MA_CCC_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion  MÃ CHỨNG CHỈ CON

    #region Thiết lập chứng chỉ điều kiện
    [WebMethod(true)]
    public string Fs_NS_TL_CCHN_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_TL_CCHN_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_COPY_COL(ref b_dt, "TEN_TC", "TC");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TL_CCHN_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ma_ccc", "");
            bang.P_CNG_SO(ref b_dt, "ngay_hl");
            ns_ma.P_NS_TL_CCHN_NH(b_dt, b_dt_ct);
            string b_ma = b_dt.Rows[0]["MA_CCHN"].ToString();
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_TL_CCHN, TEN_BANG.NS_TL_CCHN);
            return Fs_NS_TL_CCHN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_CCHN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_TL_CCHN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_COPY_COL(ref b_dt, "TEN_TC", "TC");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma_cchn", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_CCHN_CT(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_TL_CCHN_CT(b_ma);
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_TIM_THEM(ref b_dt, "ns_tl_cchn", "DT_CCHN", "ma_cchn");
            bang.P_COPY_COL(ref b_dt, "TEN_TC", "TC");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TC", "A", "Áp dụng");
            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TL_CCHN_XOA(string b_ma, string b_ngay_hl, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.PNS_TL_CCHN_XOA(b_ma, b_ngay_hl);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_TL_CCHN, TEN_BANG.NS_TL_CCHN);
            return Fs_NS_TL_CCHN_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region MÃ XÃ PHƯỜNG -- NghiepDo

    //liệt kê tỉnh thành theo mã nước
    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_QG_TT(string b_form, string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NghiepDo_NS_MA_QG_TT(b_ma_tl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_MATT", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    //liệt kê quận/huyện theo mã tỉnh thành
    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_TT_QH(string b_form, string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NghiepDo_NS_MA_TT_QH(b_ma_tl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_MAQH", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    //liệt kê xã/phường  theo mã quận/huyện
    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_QH_XP(string b_form, string b_ma_tl)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NghiepDo_NS_MA_QH_XP(b_ma_tl);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_MAQH", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_XP_LKE(string b_ma_qg, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NghiepDo_NS_MA_XP_LKE(b_ma_qg, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");

            bang.P_TIM_THEM(ref b_dt, "nghiepdo_ns_ma_xp", "DT_MAQG", "MA_QG");
            bang.P_BANG_GHEP(ref b_dt, "MA_TT,MA_TT_TEN", "{");
            bang.P_BANG_GHEP(ref b_dt, "MA_QH,MA_QH_TEN", "{");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_XP_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NghiepDo_NS_MA_XP_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_XP_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NghiepDo_NS_MA_XP_NH(b_dt_ct, ref b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_XP, TEN_BANG.NS_MA_XP);
            string b_ma_tt = mang.Fs_TEN_GTRI("ma_tt", a_cot, a_gtri);
            string b_ma_qh = mang.Fs_TEN_GTRI("ma_xp", a_cot, a_gtri);
            return Fs_NghiepDo_NS_MA_XP_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NghiepDo_NS_MA_XP_XOA(string b_tim, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NghiepDo_NS_MA_XP_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_XP, TEN_BANG.NS_MA_XP);
            return Fs_NghiepDo_NS_MA_XP_LKE("", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region  ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_DATAO_GRIDX_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_DAOTAO_GRIDX_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion ĐÀO TẠO


    #region Quang_BaiTap1

    /// <summary> liệt kê </summary>
    [WebMethod(true)]
    public string Fs_NS_QUANG_BAI1_LKE(double[] a_tso, string[] a_cot, string b_tt)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ma.Fdt_NS_QUANG_BAI1_LKE(b_tu_n, b_den_n, b_tt); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QUANG_BAI1_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ma.Fdt_NS_QUANG_BAI1_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QUANG_BAI1_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_ma = "";
            ns_ma.P_NS_QUANG_BAI1_NH(b_dt_ct, ref b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_QUANG_BAI1_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QUANG_BAI1_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_ma.P_NS_QUANG_BAI1_XOA(b_ma);
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_NUOC, TEN_BANG.NS_MA_NUOC);
            return Fs_NS_QUANG_BAI1_LKE(a_tso, a_cot, "");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion
}
