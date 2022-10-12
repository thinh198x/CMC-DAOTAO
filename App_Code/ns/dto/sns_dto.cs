using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_dto : System.Web.Services.WebService
{
    #region MÃ LOẠI ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_MA_LDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_MA_LDT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LDT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_MA_LDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LDT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_MA_LDT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_LDT, TEN_BANG.NS_MA_LDT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LDT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LDT_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_thongbao = "";
        double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH, ht_dungchung.NHOM_DT, b_ma, ref b_thongbao);
        if (b_tontai > 0)
        {
            return "loi:Loại đào tạo có mã " + b_ma + " đã được sử dụng:loi";
        }
        try
        {
            ns_dto.P_NS_MA_LDT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_LDT, TEN_BANG.NS_MA_LDT);
            return Fs_NS_MA_LDT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion MĂ LOẠI ĐÀO TẠO

    #region MÃ HỆ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_MA_HEDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_MA_HEDT_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HEDT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_MA_HEDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HEDT_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_MA_HEDT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_HEDT, TEN_BANG.NS_MA_HEDT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_HEDT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_HEDT_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {

        try
        {
            ns_dto.P_NS_MA_HEDT_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_HEDT, TEN_BANG.NS_MA_HEDT);
            return Fs_NS_MA_HEDT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion MĂ HỆ ĐÀO TẠO

    #region MÃ NHÓM KỸ NĂNG ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NKYNANG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_MA_NKYNANG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NKYNANG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_MA_NKYNANG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NKYNANG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_DT_MA_NKYNANG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_NKYNANG, TEN_BANG.NS_DT_MA_NKYNANG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_NKYNANG_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NKYNANG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_thongbao = "";
        double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_MA_KYNANG, ht_dungchung.NKYNANG, b_ma, ref b_thongbao);
        if (b_tontai > 0)
        {
            return "loi:Mã nhóm kỹ năng " + b_ma + " đã được sử dụng:loi";
        }
        try
        {
            ns_dto.P_NS_DT_MA_NKYNANG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_NKYNANG, TEN_BANG.NS_DT_MA_NKYNANG);
            return Fs_NS_DT_MA_NKYNANG_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NHÓM KỸ NĂNG

    #region  MÃ KỸ NĂNG CẦN ĐƯỢC ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KYNANG_LKE(string b_nkynang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_MA_KYNANG_LKE(b_nkynang, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KYNANG_MA(string b_nkynang, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_MA_KYNANG_MA(b_nkynang, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KYNANG_CT(string b_login, string b_nhom_kn, string b_ma, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_dto.Fds_NS_DT_MA_KYNANG_CT(b_nhom_kn, b_ma);
            bang.P_TIM_THEM(ref b_dt, "ns_dt_ma_kynang", "DT_NKYNANG", "NKYNANG");
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_KYNANG_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_DT_MA_KYNANG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_KYNANG, TEN_BANG.NS_DT_MA_KYNANG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nkynang = mang.Fs_TEN_GTRI("nkynang", a_cot, a_gtri);
            return Fs_NS_DT_MA_KYNANG_MA(b_nkynang, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_KYNANG_XOA(string b_nkynang, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_DT_MA_KYNANG_XOA(b_nkynang, b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_KYNANG, TEN_BANG.NS_DT_MA_KYNANG);
            return Fs_NS_DT_MA_KYNANG_LKE("", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ KỸ NĂNG CẦN ĐÀO TẠO

    #region MÃ NGUỒN KINH PHÍ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NGUONKP_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_MA_NGUONKP_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_MA_NGUONKP_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_MA_NGUONKP_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NGUONKP_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_DT_MA_NGUONKP_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_NGUONKP, TEN_BANG.NS_DT_MA_NGUONKP);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_MA_NGUONKP_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_NGUONKP_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        string b_thongbao = "";
        double b_tontai_kh = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KH, ht_dungchung.KINHPHI, b_ma, ref b_thongbao);
        double b_tontai_kdt = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KDT, ht_dungchung.KINHPHI, b_ma, ref b_thongbao);
        if (b_tontai_kh > 0 || b_tontai_kdt > 0)
        {
            return "loi:Mã nguồn kinh phí " + b_ma + " đã được sử dụng:loi";
        }
        try
        {
            ns_dto.P_NS_DT_MA_NGUONKP_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_NGUONKP, TEN_BANG.NS_DT_MA_NGUONKP);
            return Fs_NS_DT_MA_NGUONKP_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NGUỒN KINH PHÍ ĐÀO TẠO

    #region MÃ LĨNH VỰC ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_MA_LVDAOTAO_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_MA_LVDAOTAO_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_LVDAOTAO_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_MA_LVDAOTAO_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LVDAOTAO_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_MA_LVDAOTAO_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_MA_LVDAOTAO, TEN_BANG.NS_DT_MA_LVDAOTAO);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_LVDAOTAO_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_LVDAOTAO_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_GVIEN_CT, ht_dungchung.LVDAOTAO, b_ma, ref b_thongbao);
            if (b_tontai > 0)
            {
                return "loi:Mã lĩnh vực đào tạo" + b_ma + " đã được sử dụng:loi";
            }
            ns_dto.P_NS_MA_LVDAOTAO_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_LVDAOTAO, TEN_BANG.NS_DT_MA_LVDAOTAO);
            return Fs_NS_MA_LVDAOTAO_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ LĨNH VỰC ĐÀO TẠO

    #region GIẢNG VIÊN ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_LKE(string b_lvdaotao, string b_lke, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_GVIEN_LKE(b_lvdaotao, b_lke, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_MA(string b_so_id, string b_lvdaotao, string lke, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_GVIEN_MA(b_so_id, b_lvdaotao, lke, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_GVIEN_CT(b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "wlvdaotao", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["noidung"].ToString().Equals("") || b_dt_ct.Rows[i]["danhgia"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            string so_id = ns_dto.P_NS_DT_GVIEN_NH(b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DT_GVIEN, TEN_BANG.NS_DT_GVIEN);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            string b_lvdaotao = mang.Fs_TEN_GTRI("lvdaotao", a_cot, a_gtri);
            string b_lke = mang.Fs_TEN_GTRI("lke", a_cot, a_gtri);
            return Fs_NS_DT_GVIEN_MA(so_id, b_lvdaotao, b_lke, b_so_the, b_trangKT, a_cot_lke) + "#" + so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_XOA(string b_lvdaotao, string b_so_id, string b_lke, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.PNS_DT_GVIEN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_GVIEN, TEN_BANG.NS_DT_GVIEN);
            return Fs_NS_DT_GVIEN_LKE(b_lvdaotao, b_lke, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_GVIEN_TT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_GVIEN_TT(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion GIẢNG VIÊN ĐÀO TẠO

    #region THIẾT LẬP MÃ ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_NHUCAU_DT_LKE(string b_loaidt, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_NHUCAU_DT_LKE(b_loaidt, b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "HN", "Đào tạo hội nhập"); bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "NB", "Đào tạo nội bộ"); bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "BN", "Đào tạo bên ngoài");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NHUCAU_DT_MA(string b_loaidt, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_NHUCAU_DT_MA(b_loaidt, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "HN", "Đào tạo hội nhập"); bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "NB", "Đào tạo nội bộ"); bang.P_THAY_GTRI(ref b_dt, "LOAIDT", "BN", "Đào tạo bên ngoài");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NHUCAU_DT_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_NHUCAU_DT_CT(b_so_id);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NHUCAU_DT_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); bang.P_BO_HANG(ref b_dt_sp, "ten_hinhthuc", "");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_dto.P_NS_DT_NHUCAU_DT_NH(b_so_id, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_DT_NHUCAU_DT, TEN_BANG.NS_DT_NHUCAU_DT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_loaidt = mang.Fs_TEN_GTRI("loaidt", a_cot, a_gtri);
            return Fs_NS_DT_NHUCAU_DT_MA(b_loaidt, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_NHUCAU_DT_XOA(string b_so_id, string b_loaidt, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_DT_NHUCAU_DT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_DT_NHUCAU_DT, TEN_BANG.NS_DT_NHUCAU_DT);
            return Fs_NS_DT_NHUCAU_DT_LKE(b_loaidt, b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region KHỞI TẠO ĐỢT KHẢO SÁT

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_KS_LKE(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_KHOITAO_KS_LKE(b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_KS_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_KHOITAO_KS_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_KS_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_KHOITAO_KS_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_KS_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); bang.P_DON(ref b_dt_sp, "ma_nhucau");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt, "tu_ngay,den_ngay");
            ns_dto.P_NS_DT_KHOITAO_KS_NH(b_so_id, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_KHOITAO_KS, TEN_BANG.NS_DT_KHOITAO_KS);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri),
                b_ngayd = mang.Fs_TEN_GTRI("tu_ngay", a_cot, a_gtri), b_ngayc = mang.Fs_TEN_GTRI("den_ngay", a_cot, a_gtri);
            return Fs_NS_DT_KHOITAO_KS_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_KS_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_DT_KHOITAO_KS_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_KHOITAO_KS, TEN_BANG.NS_DT_KHOITAO_KS);
            return Fs_NS_DT_KHOITAO_KS_LKE(b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region TỔNG HỢP PHIẾU KHẢO SÁT

    [WebMethod(true)]
    public string Fs_NS_DT_TONGHOP_PHIEU_KS_LKE(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_TONGHOP_PHIEU_KS_LKE(b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TONGHOP_PHIEU_KS_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_TONGHOP_PHIEU_KS_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TONGHOP_PHIEU_KS_CT(string b_dot, string[] a_cot, string[] a_cot_nv)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_TONGHOP_PHIEU_KS_CT(b_dot);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            bang.P_SO_CNG(ref b_dt_ct, "thoi_diem_tg");
            string b_dt_ct_cot = (bang.Fb_TRANG(b_dt_ct)) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_nv);
            return b_dt_cot + "#" + b_dt_ct_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TONGHOP_PHIEU_KS_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); bang.P_DON(ref b_dt_sp, "ma_nhucau");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt, "tu_ngay,den_ngay");
            ns_dto.P_NS_DT_TONGHOP_PHIEU_KS_NH(b_so_id, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TONGHOP_PHIEU_KS, TEN_BANG.NS_DT_TONGHOP_PHIEU_KS);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri),
                b_ngayd = mang.Fs_TEN_GTRI("tu_ngay", a_cot, a_gtri), b_ngayc = mang.Fs_TEN_GTRI("den_ngay", a_cot, a_gtri);
            return Fs_NS_DT_TONGHOP_PHIEU_KS_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_TONGHOP_PHIEU_KS_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_DT_TONGHOP_PHIEU_KS_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_TONGHOP_PHIEU_KS, TEN_BANG.NS_DT_TONGHOP_PHIEU_KS);
            return Fs_NS_DT_TONGHOP_PHIEU_KS_LKE(b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region ĐỀ XUẤT ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_DXUAT_LKE(string b_loaidt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_DXUAT_LKE(b_loaidt, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "nguoi_pd", "phê duyệt lần 0", "");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DXUAT_MA(string b_loaidt, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_DXUAT_MA(b_loaidt, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "nguoi_pd", "phê duyệt lần 0", "");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DXUAT_CT(string b_phong, string b_ma, string b_lan)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_DXUAT_CT(b_phong, b_ma, b_lan);
            bang.P_SO_CNG(ref b_dt, "ngayd,thoigian");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DXUAT_NH(double b_tinhtrang, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
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
            DataTable b_dt_kq = ns_dto.P_NS_DT_DXUAT_NH(b_dt_ct);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DXUAT, TEN_BANG.NS_DT_DXUAT);
            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đề xuất đào tạo cần phê duyệt";
                string b_body = "Bạn có đề xuất đào tạo cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri),
                   b_loaidt = mang.Fs_TEN_GTRI("loaidt", a_cot, a_gtri);
            string b_nh_kq = Fs_NS_DT_DXUAT_MA(b_loaidt, b_ma, b_trangKT, a_cot_lke);
            return b_guimail + "#" + b_nh_kq;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DXUAT_XOA(string b_phong, string b_ma, string b_lan, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.PNS_DT_DXUAT_XOA(b_phong, b_ma, b_lan);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_DXUAT, TEN_BANG.NS_DT_DXUAT);
            return Fs_NS_DT_DXUAT_LKE("", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐỀ XUẤT ĐÀO TẠO

    #region KHOÁ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_KDT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, new string[] { "ngaytrinh,ngayd,ngayc" });
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct),
                   b_dt_ct_cdanh = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[2], a_cot_ct),
                   b_dt_ct_nhucau = bang.Fb_TRANG(b_ds.Tables[3]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[3], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_ct_cdanh + "#" + b_dt_ct_nhucau;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_CT2(string b_ma, string b_ma_dt, string b_loaidt, string[] a_cot_nv, string[] a_cot_cdanh, string[] a_cot_nhucau)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_KDT_CT2(b_ma, b_ma_dt, b_loaidt);
            DataTable b_dt_nv = b_ds.Tables[0], b_dt_cdanh = b_ds.Tables[1], b_dt_nhucau = b_ds.Tables[2];
            string b_cot_nv = bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_nv),
                   b_cot_cdanh = bang.Fb_TRANG(b_dt_cdanh) ? "" : bang.Fs_BANG_CH(b_dt_cdanh, a_cot_cdanh),
                   b_cot_nhucau = bang.Fb_TRANG(b_dt_nhucau) ? "" : bang.Fs_BANG_CH(b_dt_nhucau, a_cot_nhucau);
            return b_cot_nv + "#" + b_cot_cdanh + "#" + b_cot_nhucau;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_CDANH(string b_ma, string b_ma_dt, string b_loaidt, string[] a_cot_nv, string[] a_cot_cdanh, string[] a_cot_nhucau)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_KDT_CDANH(b_ma, b_ma_dt, b_loaidt);
            DataTable b_dt_cdanh = b_ds.Tables[0];
            DataTable b_dt_ncau = b_ds.Tables[1];
            string b_cot_nv = bang.Fb_TRANG(b_dt_cdanh) ? "" : bang.Fs_BANG_CH(b_dt_cdanh, a_cot_cdanh);
            string b_cot_ncau = bang.Fb_TRANG(b_dt_ncau) ? "" : bang.Fs_BANG_CH(b_dt_ncau, a_cot_nhucau);
            return b_cot_nv + "#" + b_cot_ncau;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_KDT_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã cho đăng ký");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "3", "Khóa đăng ký");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chờ phê duyệt");
            bang.P_SO_CNG(ref b_dt_tk, "ngaytrinh");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_KDT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "1", "Đã cho đăng ký");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "2", "Không phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "3", "Khóa đăng ký");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "0", "Chờ phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngaytrinh");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_CHO_DK(string b_ma, double b_tinhtrang)
    {
        try
        {
            if (b_tinhtrang == 3)
            {
                return Thongbao_dch.KhoaHoc_KetThuc;
            }
            else if (b_tinhtrang == 2)
            {
                return Thongbao_dch.KhoaHoc_dachodk;
            }
            ns_dto.Fdt_NS_DT_KDT_CHO_DK(b_ma);
            return "";
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_KHOA_DK(string b_ma, double b_tinhtrang)
    {
        try
        {
            if (b_tinhtrang == 2)
            {
                return Thongbao_dch.KhoaHoc_KetThuc;
            }
            else if (b_tinhtrang == 0)
            {
                return Thongbao_dch.KhoaHoc_ChuaPD;
            }
            ns_dto.Fdt_NS_DT_KDT_KHOA_DK(b_ma);
            return "";
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_TRINH_PD(string b_ma, double b_tinhtrang)
    {
        try
        {
            if (b_tinhtrang == 2 || b_tinhtrang == 1 || b_tinhtrang == 3)
            {
                return Thongbao_dch.KhoaHoc_daPD_DK;
            }
            ns_dto.Fdt_NS_DT_KDT_TRINH_PD(b_ma);
            return "";
        }
        catch (Exception) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, object[] a_dt_ct_cdanh, object[] a_dt_ct_nc, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt, "ngaytrinh,ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt, "tyle,giatri");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            string[] a_cot_ct_cdanh = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cdanh[0]); object[] a_gtri_ct_cdanh = (object[])a_dt_ct_cdanh[1];
            DataTable b_dt_ct_cdanh = bang.Fdt_TAO_THEM(a_cot_ct_cdanh, a_gtri_ct_cdanh);
            string[] a_cot_ct_nhucau = chuyen.Fas_OBJ_STR((object[])a_dt_ct_nc[0]); object[] a_gtri_ct_nhucau = (object[])a_dt_ct_nc[1];
            DataTable b_dt_ct_nhucau = bang.Fdt_TAO_THEM(a_cot_ct_nhucau, a_gtri_ct_nhucau);

            if (!b_dt.Rows[0]["tinhtrang"].Equals("0")) { return Thongbao_dch.KhoaHoc_daPD_KT; }
            bang.P_THEM_COL(ref b_dt_ct, "tt", "0");
            for (int j = 0; j < b_dt_ct.Rows.Count; j++)
            {
                b_dt_ct.Rows[j]["tt"] = j + 1;
            }
            bang.P_THEM_COL(ref b_dt_ct_cdanh, "tt", "0");
            for (int j = 0; j < b_dt_ct_cdanh.Rows.Count; j++)
            {
                b_dt_ct_cdanh.Rows[j]["tt"] = j + 1;
            }
            bang.P_THEM_COL(ref b_dt_ct_nhucau, "tt", "0");
            for (int j = 0; j < b_dt_ct_nhucau.Rows.Count; j++)
            {
                b_dt_ct_nhucau.Rows[j]["tt"] = j + 1;
            }
            bang.P_CSO_SO(ref b_dt, "giatri");
            //bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            //bang.P_BO_HANG(ref b_dt_ct_cdanh, "so_the", "");
            //bang.P_BO_HANG(ref b_dt_ct_nhucau, "so_the", "");
            ns_dto.P_NS_DT_KDT_NH(b_so_id, b_dt, b_dt_ct, b_dt_ct_cdanh, b_dt_ct_nhucau);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_KDT, TEN_BANG.NS_DT_KDT);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_KDT_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.PNS_DT_KDT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_KDT, TEN_BANG.NS_DT_KDT);
            return Fs_NS_DT_KDT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KHOÁ ĐÀO TẠO

    #region THƯ VIỆN CÂU HỎI ĐỀ THI

    [WebMethod(true)]
    public string Fs_NS_DT_THUVIEN_DTHI_LKE(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_THUVIEN_DTHI_LKE(b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUVIEN_DTHI_MA(string b_ma, string b_mach, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_THUVIEN_DTHI_MA(b_ma, b_mach, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_mach);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_THUVIEN_DTHI_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUVIEN_DTHI_CT(b_so_id);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_THUVIEN_DTHI_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            double b_loai = Convert.ToInt32(b_dt.Rows[0]["LOAI"].ToString());
            DataTable b_dt1 = b_dt_sp.Copy();
            bang.P_BO_HANG(ref b_dt1, "traloi", "");
            if (b_loai == 1)
            {
                if (b_dt1 == null || b_dt1.Rows.Count <= 0)
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            for (int i = 0; i < b_dt_sp.Rows.Count; i++)
            {
                b_dt_sp.Rows[i]["stt"] = i + 1;
            }
            DataRow b_dr = b_dt.Rows[0];
            string b_ma_nhucau = chuyen.OBJ_S(b_dr["MA_NHUCAU"]);
            string b_ma_check = chuyen.OBJ_S(b_dr["MA"]);
            string b_loai_check = chuyen.OBJ_S(b_dr["LOAI"]);

            DataTable b_obj_check = ns_dto.Fdt_NS_DT_THUVIEN_DTHI_CHECK(b_so_id,b_ma_nhucau, b_ma_check, b_loai_check);
            foreach (DataRow b_dr_c in b_obj_check.Rows)
            {
                if (b_dr_c[0] != null)
                {
                    DataRow b_dr_check = b_obj_check.Rows[0];
                    if (b_ma_check == chuyen.OBJ_S(b_dr_check["MA"]))
                    {
                        return "loi:Mã câu hỏi đã tồn tại trong nhóm nhu cầu.Vui lòng nhập mã khác:loi";
                    }
                }
            }
                
                ns_dto.P_NS_DT_THUVIEN_DTHI_NH(b_so_id, b_dt, b_dt_sp);
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_THUVIEN_DTHI, TEN_BANG.NS_DT_THUVIEN_DTHI);
                string b_ma = mang.Fs_TEN_GTRI("ma_nhucau", a_cot, a_gtri);
                string b_mach = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
                return Fs_NS_DT_THUVIEN_DTHI_MA(b_ma, b_mach, b_trangKT, a_cot_lke);      
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_THUVIEN_DTHI_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string b_thongbao = "";
            double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_DT_KHOITAO_DTHI_CT, ht_dungchung.CAUHOI, b_so_id, ref b_thongbao);
            if (b_tontai > 0)
            {
                return "loi:Câu hỏi đã được sử dụng. Không được xóa:loi";
            }
            ns_dto.P_NS_DT_THUVIEN_DTHI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_THUVIEN_DTHI, TEN_BANG.NS_DT_THUVIEN_DTHI);
            return Fs_NS_DT_THUVIEN_DTHI_LKE(b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion THƯ VIỆN CÂU HỎI ĐỀ THI

    #region KHỞI TẠO ĐỀ THI
    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_DTHI_LKE(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_KHOITAO_DTHI_LKE(b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_DTHI_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_KHOITAO_DTHI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_DTHI_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_KHOITAO_DTHI_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_DTHI_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            bang.P_THAY_GTRI(ref b_dt_sp, "loaithi", "Trắc nghiệm", "01");
            bang.P_THAY_GTRI(ref b_dt_sp, "loaithi", "Tự luận", "02");
            DataTable b_dt1 = b_dt_sp.Copy();
            bang.P_BO_HANG(ref b_dt1, "CAUHOI", "");
            
            if (b_dt1 == null || b_dt1.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_sp.Rows.Count; i++)
            {
                b_dt_sp.Rows[i]["stt"] = i + 1;
            }
            for (int i = 0; i < b_dt1.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt1.Rows[i]["loaithi"].ToString()))
                {
                    return "loi:Chưa chọn loại thi:loi";
                }
                if (string.IsNullOrEmpty(b_dt1.Rows[i]["diem"].ToString()))
                {
                    return "loi:Chưa nhập điểm thi:loi";
                }
            }
            bang.P_CNG_SO(ref b_dt, "ngayd"); bang.P_BO_HANG(ref b_dt_sp, "CAUHOI", "");
            ns_dto.P_NS_DT_KHOITAO_DTHI_NH(b_so_id, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_KHOITAO_DTHI, TEN_BANG.NS_DT_KHOITAO_DTHI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_KHOITAO_DTHI_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KHOITAO_DTHI_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {

            ns_dto.P_NS_DT_KHOITAO_DTHI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_KHOITAO_DTHI, TEN_BANG.NS_DT_KHOITAO_DTHI);
            return Fs_NS_DT_KHOITAO_DTHI_LKE(b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KHỞI TẠO ĐỀ THI

    #region TỔ CHỨC THI
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_LKE(string b_ma, string b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_TOCHUC_THI_LKE(b_ma, b_loai, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngaythi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_MA(string b_ma, string b_loai, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_TOCHUC_THI_MA(b_ma, b_loai, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngaythi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_TOCHUC_THI_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngaythi");
            DataTable b_dt_tt = ns_ma.Fdt_NS_MA_CB_DR();
            se.P_TG_LUU("ns_dt_tochuc_thi", "DT_CB", b_dt_tt.Copy());

            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_NV(string b_ma_kh, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_TOCHUC_THI_NV(b_ma_kh);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq + "#" + b_dt_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            bang.P_BO_HANG(ref b_dt_sp, "so_the", "");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_BO_HANG(ref b_dt_sp, "so_the", "");
            bang.P_CNG_SO(ref b_dt, "ngaythi");
            ns_dto.P_NS_DT_TOCHUC_THI_NH(b_so_id, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TOCHUC_THI, TEN_BANG.NS_DT_TOCHUC_THI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri), b_loai = mang.Fs_TEN_GTRI("loai_kh", a_cot, a_gtri); ;
            return Fs_NS_DT_TOCHUC_THI_MA(b_ma, b_loai, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TOCHUC_THI_XOA(string b_so_id, string b_ma, string b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_DT_TOCHUC_THI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_TOCHUC_THI, TEN_BANG.NS_DT_TOCHUC_THI);
            return Fs_NS_DT_TOCHUC_THI_LKE(b_ma, b_loai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion TỔ CHỨC THI

    #region TÍNH ĐIỂM THI
    [WebMethod(true)]
    public string Fs_NS_DT_TINHDIEM_THI_LKE(string b_ma_kt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_TINHDIEM_THI_LKE(b_ma_kt, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CHAMDIEM_TL_MA(string b_ma, string b_ma_dt, string b_causo, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_CHAMDIEM_TL_MA(b_ma, b_ma_dt, b_causo, b_so_the, b_trangkt);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CHAMDIEM_TL_CT(string b_ma, string b_causo, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_CHAMDIEM_TL_CT(b_ma, b_causo);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_CHAMDIEM_TL_NH(string b_ma, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_dto.P_NS_DT_CHAMDIEM_TL_NH(b_ma, b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TINHDIEM_THI, TEN_BANG.NS_DT_TINHDIEM_THI);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_TINHDIEM_NH(string b_ma_kt, string b_ngay_cham, double b_trangKT, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.khongco_dulieu_luoi;
            }
            ns_dto.P_Fs_DT_TINHDIEM_NH(b_ma_kt, b_ngay_cham, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_TINHDIEM_THI, TEN_BANG.NS_DT_TINHDIEM_THI);
            return Fs_NS_DT_TINHDIEM_THI_LKE(b_ma_kt, a_tso, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region ĐÁNH GIÁ - KẾT QUẢ ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KQ_LKE(string b_ma, double[] a_tso, string[] a_cot, string[] a_cot_nd)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_DANHGIA_KQ_LKE(b_ma, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_dg");
            DataTable b_dt_nd = bang.Fdt_TAO_BANG(new string[] { "noidung", "diem_dg" }, new string[] { "S", "S" });
            bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Nội dung đào tạo", "" });
            bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Giáo viên", "" });
            bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Công tác tổ chức", "" });

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_nd, a_cot_nd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KQ_MA(string b_ma, string b_so_id, double b_trangkt, string[] a_cot, string[] a_cot_ct, string[] a_cot_nd)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_DANHGIA_KQ_MA(b_ma, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            DataTable b_dt_ct = (DataTable)a_object[3];
            DataTable b_dt_nd = (DataTable)a_object[4];
            if (b_dt_nd.Rows.Count <= 0)
            {
                b_dt_nd = bang.Fdt_TAO_BANG(new string[] { "noidung", "diem_dg" }, new string[] { "U", "S" });
                bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Nội dung đào tạo", "" });
                bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Giáo viên", "" });
                bang.P_THEM_HANG(ref b_dt_nd, new object[] { "Công tác tổ chức", "" });
            }
            bang.P_SO_CNG(ref b_dt, "ngay_dg");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma_dt", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_nd, a_cot_nd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KQ_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, object[] a_dt_nd, string[] a_cot_lke, string[] a_cot_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            string[] a_cot_nd = chuyen.Fas_OBJ_STR((object[])a_dt_nd[0]); object[] a_gtri_nd = (object[])a_dt_nd[1];
            DataTable b_dt_nd = bang.Fdt_TAO_THEM(a_cot_nd, a_gtri_nd);

            bang.P_BO_HANG(ref b_dt_sp, "so_the", "");
            bang.P_CNG_SO(ref b_dt, "ngay_dg");
            ns_dto.P_NS_DT_DANHGIA_KQ_NH(b_so_id, b_dt, b_dt_sp, b_dt_nd);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DANHGIA_KQ, TEN_BANG.NS_DT_DANHGIA_KQ);
            string b_ma = mang.Fs_TEN_GTRI("ma_dt", a_cot, a_gtri);
            return Fs_NS_DT_DANHGIA_KQ_MA(b_ma, b_so_id, b_trangKT, a_cot_lke, a_cot_ct, a_cot_nd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANHGIA_KQ_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot, string[] a_cot_nd)
    {
        try
        {
            ns_dto.P_NS_DT_DANHGIA_KQ_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DTO, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_DANHGIA_KQ, TEN_BANG.NS_DT_DANHGIA_KQ);
            return Fs_NS_DT_DANHGIA_KQ_LKE(b_ma, a_tso, a_cot, a_cot_nd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐÁNH GIÁ - KẾT QUẢ ĐÀO TẠO

    #region DANH SÁCH PHÚC KHẢO
    [WebMethod(true)]
    public string Fs_NS_DT_PHUCKHAO_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_PHUCKHAO_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH SÁCH PHÚC KHẢO

    #region DANH SÁCH ĐỂ ĐĂNG KÝ KHÓA HỌC
    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_DANGKYKH_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, new string[] { "ngaytrinh", "ngayd", "ngayc" });
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    // dang ky khoa hoc
    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_NH(string b_ma, double b_tinhtrang)
    {
        try
        {
            if (b_tinhtrang == 4 || b_tinhtrang == 3)
            {
                return Thongbao_dch.KhoaHoc_KetThuc;
            }
            ns_dto.Fdt_NS_DT_DANGKYKH_NH(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.DANGKY, TEN_FORM.NS_DT_DANGKYKH, TEN_BANG.NS_DT_DANGKYKH);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_XOA(string b_ma, double b_tinhtrang)
    {
        try
        {
            if (b_tinhtrang > 2)
            {
                return Thongbao_dch.Khong_huy_dangky;
            }
            ns_dto.Fdt_NS_DT_DANGKYKH_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.HUY_DANGKY, TEN_FORM.NS_DT_DANGKYKH, TEN_BANG.NS_DT_DANGKYKH);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_DSACH(string b_ma, string[] a_cot)
    {
        DataSet b_ds = ns_dto.Fdt_NS_DT_DANGKYKH_DSACH(b_ma);
        DataTable b_dt_tk = b_ds.Tables[0]; DataTable b_dt = b_ds.Tables[1];
        bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "");
        bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "C");
        bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "K");
        return chuyen.OBJ_S(bang.Fs_BANG_CH(b_dt_tk, a_cot) + "#" + bang.Fs_HANG_GOP(b_dt, 0));
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_DUYET(string b_ma, object[] a_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_BO_HANG(ref b_dt, "so_the", "");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "", "0");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "C", "1");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "K", "2");
            ns_dto.Fdt_NS_DT_DANGKYKH_DUYET(b_ma, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_DT_DSDANGKY, TEN_BANG.NS_DT_DSDANGKY);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_HUYDUYET(string b_ma)
    {
        try
        {
            ns_dto.Fdt_NS_DT_DANGKYKH_HUYDUYET(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_DT_DSDANGKY, TEN_BANG.NS_DT_DSDANGKY);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    // tổ chức khóa học
    [WebMethod(true)]
    public string Fs_NS_DT_DANGKYKH_TOCHUC(string b_ma)
    {
        try
        {
            ns_dto.Fdt_NS_DT_DANGKYKH_TOCHUC(b_ma);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH SÁCH ĐỂ ĐĂNG KÝ KHÓA HỌC

    #region PHIẾU KHẢO SÁT
    [WebMethod(true)]
    public string Fs_NS_DT_PHIEU_KS_LKE(string b_ma, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_NS_DT_PHIEU_KS_LKE(b_ma, b_tt, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_PHIEU_KS_MA(string b_ma, string b_lke, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_NS_DT_PHIEU_KS_MA(b_ma, b_lke, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_PHIEU_KS_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_NS_DT_PHIEU_KS_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt2 = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt2, "NGAY_GUI");
            bang.P_SO_CNG(ref b_dt, "NTHOI_DIEM_TG");
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            string ngaygui = "";
            if (b_dt2.Rows.Count > 0)
            {
                ngaygui = b_dt2.Rows[0]["NGAY_GUI"].ToString();
            }
            return b_dt_kq + "#" + b_dt_cot + "#" + ngaygui ;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_PHIEU_KS_NH(string b_so_id, string b_dot, string b_lke, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp); //bang.P_DON(ref b_dt_sp, "ma_nhucau");
            if (b_dt_sp == null || b_dt_sp.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_BO_COT(ref b_dt_sp,"ma_nhucau");
            bang.P_CNG_SO(ref b_dt_sp, "nthoi_diem_tg");
            bang.P_CNG_SO(ref b_dt, "ngay_gui");
            //for (int i = 0; i < b_dt_sp.Rows.Count; i++)
            //{
            //    if (b_dt_sp.Rows[i]["hinhthuc"].ToString() == "")
            //    {
            //        return form.Fs_LOC_LOI("Nhập hình thức đào tạo.");
            //    }
            //    if (b_dt_sp.Rows[i]["nthoi_diem_tg"].ToString() == "" || b_dt_sp.Rows[i]["nthoi_diem_tg"].ToString() == "30000101")
            //    {
            //        return form.Fs_LOC_LOI("Nhập thời điểm có thể tham gia.");
            //    }
            //}
            ns_dto.P_NS_NS_DT_PHIEU_KS_NH(b_so_id, b_dot, b_dt, b_dt_sp);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_PHIEU_KS, TEN_BANG.NS_DT_PHIEU_KS);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DT_PHIEU_KS_LKE(b_dot, b_lke, a_tso, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_PHIEU_KS_XOA(string b_so_id, string b_ma, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_dto.P_NS_NS_DT_PHIEU_KS_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_PHIEU_KS, TEN_BANG.NS_DT_PHIEU_KS);
            return Fs_NS_DT_PHIEU_KS_LKE(b_ma, b_tt, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion KHỞI TẠO ĐỢT KHẢO SÁT

    #region THỰC HIỆN THI
    [WebMethod(true)]
    public string Fs_NS_DT_DANHSACH_BAITHI_LKE(string b_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_DANHSACH_BAITHI_LKE(b_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngaythi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_MA(string b_ma, string b_causo, double b_trangkt, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUCHIEN_BT_MA(b_ma, b_causo, b_trangkt);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_KETQUA(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUCHIEN_BT_KETQUA(b_ma);
            string b_dt_kq = "";
            if (b_dt.Rows.Count > 0) { b_dt_kq = b_dt.Rows[0]["HOANTHANH"].ToString() + "#" + b_dt.Rows[0]["DIEM"].ToString(); }
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_PHUCKHAO(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUCHIEN_BT_PHUCKHAO(b_ma);
            string b_dt_kq = "";
            if (b_dt.Rows.Count > 0) { b_dt_kq = b_dt.Rows[0]["NOIDUNG_PHUCKHAO"].ToString(); }
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_CT(string b_so_the, string b_ma_dt, string b_ma, string b_causo, string b_tt_lam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_THUCHIEN_BT_CT(b_ma, b_causo, b_tt_lam, b_so_the, b_ma_dt);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_tuluan = b_ds.Tables[1];
            string b_traloi = "", b_traloigoc = "", b_traloimoi = "";
            int b_cat = 0;
            if (b_dt.Rows.Count > 0)
            {
                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    b_traloigoc = b_traloi = b_dt.Rows[i]["traloi"].ToString();
                    while (b_traloi.Length > 90)
                    {
                        b_cat = b_traloi.IndexOf(" ", 90);
                        if (b_cat > 0)
                        {
                            b_traloimoi = b_traloimoi + b_traloi.Substring(0, b_cat) + "<br>";
                            b_traloi = b_traloi.Substring(b_cat, b_traloi.Length - b_cat);
                        }
                    }
                    b_traloimoi = b_traloimoi + b_traloi;
                    bang.P_THAY_GTRI(ref b_dt, "traloi", b_traloigoc, b_traloimoi);
                    b_traloi = b_traloimoi = ""; b_cat = 0;
                }
            }
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            string b_tl_tl = "";
            if (b_tuluan.Rows.Count > 0)
            {
                b_tl_tl = b_tuluan.Rows[0]["noidung"].ToString();
            }
            return b_dt_kq + "#" + b_tl_tl;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_NH(string b_ma, string b_noidung_tl, string b_loai_cauhoi, string b_so_id, string b_guiId, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            ns_dto.P_NS_DT_THUCHIEN_BT_NH(b_ma, b_noidung_tl, b_loai_cauhoi, b_so_id, b_guiId, b_dt, b_dt_sp);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_PHUCKHAO(string b_ma, string b_noidung)
    {
        try
        {
            ns_dto.P_NS_DT_THUCHIEN_BT_PHUCKHAO(b_ma, b_noidung);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region THỰC HIỆN THI
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_LKE(string b_ma_kt,string b_ma_ch,string b_causo,string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_THUCHIEN_BT_LKE(b_ma_kt,b_ma_ch, b_causo, b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_XEMLAI_MA(string b_ma, string b_causo, double b_trangkt, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUCHIEN_BT_XEMLAI_MA(b_ma, b_causo, b_trangkt);
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_XEMLAI_KETQUA(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_dto.Fdt_NS_DT_THUCHIEN_BT_XEMLAI_KETQUA(b_ma);
            string b_dt_kq = "";
            if (b_dt.Rows.Count > 0) { b_dt_kq = b_dt.Rows[0]["HOANTHANH"].ToString() + "#" + b_dt.Rows[0]["DIEM"].ToString(); }
            return b_dt_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_XEMLAI_CT(string b_so_the, string b_ma_dt, string b_ma, string b_causo, string b_tt_lam, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_dto.Fdt_NS_DT_THUCHIEN_BT_XEMLAI_CT(b_ma, b_causo, b_tt_lam, b_so_the, b_ma_dt);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_tuluan = b_ds.Tables[1];
            string b_traloi = "", b_traloigoc = "", b_traloimoi = "";
            int b_cat = 0;
            int b_count = 0;
            if (b_dt.Rows.Count > 0)
            {
                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    b_traloigoc = b_traloi = b_dt.Rows[i]["traloi"].ToString();

                    while (b_traloi.Length > 90 && b_count < b_traloi.Length && b_cat >= 0)
                    {
                        b_cat = b_traloi.IndexOf(" ", 90);
                        if (b_cat > 0)
                        {
                            b_traloimoi = b_traloimoi + b_traloi.Substring(0, b_cat) + "<br>";
                            b_traloi = b_traloi.Substring(b_cat, b_traloi.Length - b_cat);
                            b_count += 90;
                        }
                    }
                    b_traloimoi = b_traloimoi + b_traloi;
                    bang.P_THAY_GTRI(ref b_dt, "traloi", b_traloigoc, b_traloimoi);
                    b_traloi = b_traloimoi = ""; b_cat = 0;
                }
            }
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            string b_tl_tl = "";
            if (b_tuluan.Rows.Count > 0)
            {
                b_tl_tl = b_tuluan.Rows[0]["noidung"].ToString();
            }
            return b_dt_kq + "#" + b_tl_tl;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_XEMLAI_NH(string b_ma, string b_noidung_tl, string b_loai_cauhoi, string b_so_id, string b_guiId, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_sp = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_sp = (object[])a_dt_ct[1];
            if (a_gtri_sp == null) a_gtri_sp = new object[a_cot_sp.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_sp = bang.Fdt_TAO_THEM(a_cot_sp, a_gtri_sp);
            ns_dto.P_NS_DT_THUCHIEN_BT_XEMLAI_NH(b_ma, b_noidung_tl, b_loai_cauhoi, b_so_id, b_guiId, b_dt, b_dt_sp);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_THUCHIEN_BT_XEMLAI_PHUCKHAO(string b_ma, string b_noidung)
    {
        try
        {
            ns_dto.P_NS_DT_THUCHIEN_BT_XEMLAI_PHUCKHAO(b_ma, b_noidung);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region DANH SÁCH KHÓA ĐÀO TẠO
    [WebMethod(true)]
    public string Fs_NS_DT_DSDAOTAO_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dto.Fdt_NS_DT_DSDAOTAO_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, new string[] { "ngaytrinh", "ngayd", "ngayc" });
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public void Fs_NS_DT_DSDAOTAO_PHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            ns_dto.Fdt_NS_DT_DSDAOTAO_PHEDUYET(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_DT_DSDAOTAO, TEN_BANG.NS_DT_DSDAOTAO);
        }
        catch (Exception ex) { }
    }

    [WebMethod(true)]
    public void Fs_NS_DT_DSDAOTAO_HUYPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            ns_dto.Fdt_NS_DT_DSDAOTAO_HUYPHEDUYET(b_dt_ct);
        }
        catch (Exception ex) { }
    }

    [WebMethod(true)]
    public void Fs_NS_DT_DSDAOTAO_KOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            ns_dto.Fdt_NS_DT_DSDAOTAO_KOPHEDUYET(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_DT_DSDAOTAO, TEN_BANG.NS_DT_DSDAOTAO);
        }
        catch (Exception ex) { }
    }
    #endregion DANH SÁCH ĐÀO TẠO
}