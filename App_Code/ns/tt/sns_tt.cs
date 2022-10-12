using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.IO;
using Cthuvien;
[System.Web.Script.Services.ScriptService]
public class sns_tt : System.Web.Services.WebService
{
    #region THÔNG BÁO TRÊN TRANG MENU
    [WebMethod(true)]
    public string Fs_MENU_TBAO_CT(string b_login, string b_loai, string[] a_cot, string[] a_cot_td, string[] a_cot_hs, double[] a_tso, double[] a_tso_td, double[] a_tso_hs)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            double b_tu, b_den;
            if (b_loai == "TD")
            {
                b_tu = chuyen.OBJ_N(a_tso_td[0]);
                b_den = chuyen.OBJ_N(a_tso_td[1]);
            }
            else if (b_loai == "HS")
            {
                b_tu = chuyen.OBJ_N(a_tso_hs[0]);
                b_den = chuyen.OBJ_N(a_tso_hs[1]);
            }
            else
            {
                b_tu = chuyen.OBJ_N(a_tso[0]);
                b_den = chuyen.OBJ_N(a_tso[1]);
            }
            object[] a_obj = ns_tt.Fdt_MENU_TBAO_CT2(b_loai, b_tu, b_den);

            DataTable b_dt = (DataTable)a_obj[1];
            if (b_loai == "TD") { bang.P_SO_CNG(ref b_dt, "ngay_yc"); return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_td); }
            else if (b_loai == "HS") { bang.P_SO_CNG(ref b_dt, "nsinh,ngayd,ngay_p"); return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_hs); }
            else { bang.P_SO_CNG(ref b_dt, "nsinh,ngayhh,ngayd,ngayhh_qd"); return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot); }

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_MENU_TBAO_CT_CCHN(string b_login, string b_ma, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);

            object[] a_obj = ns_tt.Fdt_MENU_TBAO_CT_CCHN(b_ma, b_tu, b_den);

            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "nsinh,ngayd");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_MENU_TBAO_CT_CON(string b_login, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);

            object[] a_obj = ns_tt.Fdt_MENU_TBAO_CT_CON(b_tu, b_den);

            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc"); return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_BC_NHAP_REALTIME(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_BC_NHAP_REALTIME();
            bang.P_SO_CNG(ref b_dt, "ngay_bd");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region THÔNG TIN GỐC CỦA CÁN BỘ


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
    public string Fs_NS_CB_KTRA(string b_so_the, string b_phong)
    {
        try
        {
            return ns_tt.Fdt_NS_CB_KTRA(b_so_the, b_phong);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_LKE(string b_phong, string b_lke, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_CB_LKE(b_phong, b_lke, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_QLY_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_CB_QLY_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_CB_TIM(string b_ten_hoa)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_CB_TIM(b_ten_hoa);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_QH_LKE(string ma_tt)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_NS_MA_QH_DR(ma_tt);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_XP_LKE(string ma_qh)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_NS_MA_XP_DR(ma_qh);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region QUAN HỆ NHÂN THÂN
    [WebMethod(true)]
    public string Fs_NS_QHE_QH_XEM(string b_matt, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_QH_DR(b_matt);
            se.P_TG_LUU("ns_qhe", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_XP_XEM(string b_maqh, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_XP_DR(b_maqh);
            se.P_TG_LUU("ns_qhe", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_QHE_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_QHE_TT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "K", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt_tk, "ngaysinh,ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_QHE_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_QHE_TT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "K", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_QHE_CT(b_so_id);

            bang.P_TIM_THEM(ref b_dt, "ns_qhe", "DT_LQHE", "LQHE");

            bang.P_BANG_GHEP(ref b_dt, "nn,ten_nn", "{");
            bang.P_BANG_GHEP(ref b_dt, "tinhthanh,ten_tinhthanh", "{");
            bang.P_BANG_GHEP(ref b_dt, "quanhuyen,ten_quanhuyen", "{");
            bang.P_BANG_GHEP(ref b_dt, "phuongxa,ten_phuongxa", "{");
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc,ngay_cmt");

            //bang.P_SO_CNG(ref b_dt, "ngaysinh");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_QL_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_QHE_CT(b_so_id);
            // lấy quận huyện theo tỉnh thành
            if (b_dt.Rows[0]["tinhthanh"].ToString() != "")
            {
                DataTable b_dt_qh = ns_ma.Fdt_NS_MA_QH_DR(b_dt.Rows[0]["tinhthanh"].ToString());
                if (b_dt_qh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_qh, new object[] { "", "" }, 0);
                se.P_TG_LUU("ns_qhe_ql", "DT_THQH", b_dt_qh.Copy());
            }
            // lấy xã phường theo quận huyện
            if (b_dt.Rows[0]["quanhuyen"].ToString() != "")
            {
                DataTable b_dt_xp = ns_ma.Fdt_NS_MA_XP_DR(b_dt.Rows[0]["quanhuyen"].ToString());
                if (b_dt_xp.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_xp, new object[] { 0, "" }, 0);
                se.P_TG_LUU("ns_qhe_ql", "DT_THXP", b_dt_xp.Copy());
            }
            bang.P_TIM_THEM(ref b_dt, "ns_qhe_ql", "DT_LQHE", "LQHE");
            bang.P_TIM_THEM(ref b_dt, "ns_qhe_ql", "DT_QT", "NN");
            bang.P_TIM_THEM(ref b_dt, "ns_qhe_ql", "DT_TTP", "TINHTHANH");
            bang.P_TIM_THEM(ref b_dt, "ns_qhe_ql", "DT_THQH", "QUANHUYEN");
            bang.P_TIM_THEM(ref b_dt, "ns_qhe_ql", "DT_THXP", "PHUONGXA");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_QHE_TT_CT(b_so_id);

            bang.P_TIM_THEM(ref b_dt, "ns_qhe_tt", "DT_LQHE", "LQHE");

            bang.P_BANG_GHEP(ref b_dt, "nn,ten_nn", "{");
            bang.P_BANG_GHEP(ref b_dt, "tinhthanh,ten_tinhthanh", "{");
            bang.P_BANG_GHEP(ref b_dt, "quanhuyen,ten_quanhuyen", "{");
            bang.P_BANG_GHEP(ref b_dt, "phuongxa,ten_phuongxa", "{");
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc,ngay_cmt");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngaysinh,ngayd,ngayc,ngay_cmt");
            b_so_id = ns_tt.PNS_QHE_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QHE, TEN_BANG.NS_QHE);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_QHE_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngaysinh,ngayd,ngayc,ngay_cmt");
            b_so_id = ns_tt.PNS_QHE_TT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_QHE_TT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tt.PNS_QHE_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_QHE, TEN_BANG.NS_QHE);
            return Fs_NS_QHE_LKE(b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_QHE_TT_XOA(b_so_id); return Fs_NS_QHE_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_TT_GUI(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_QHE_TT_GUI(b_so_id); return Fs_NS_QHE_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_EXCEL(string b_so_the)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_QHE_LKE(b_so_the, 1, Int32.MaxValue);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngaysinh");
            return form.Fs_LOC_LOI("Nhập thành công");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QHE_CHECK_NHANTHAN(string b_so_id, string b_tenNhanthan, string b_ngaysinh)
    {
        try
        {
            object[] a_object = ns_tt.PNS_QHE_CHECK_NHANTHAN(b_so_id, b_tenNhanthan, chuyen.CNG_CSO(b_ngaysinh));
            return chuyen.OBJ_S(a_object[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUAN HỆ NHÂN THÂN

    #region QUÁ TRÌNH HOẠT ĐỘNG VÀ CÔNG TÁC

    [WebMethod(true)]
    public string Fs_NS_CT_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_CT_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CT_CT(string b_so_the, string b_thangd)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_CT_CT(b_so_the, b_thangd);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CT_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tt.PNS_CT_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CT_XOA(string b_so_the, string b_thangd)
    {
        try
        {
            ns_tt.PNS_CT_XOA(b_so_the, b_thangd);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion QUÁ TRÌNH HOẠT ĐỘNG VÀ CÔNG TÁC

    #region ĐÀO TẠO CHUYÊN MÔN NGHIỆP VỤ

    [WebMethod(true)]
    public string Fs_NS_CMNV_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_CMNV_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CMNV_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_CMNV_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CMNV_NH(string b_so_id, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            return ns_tt.PNS_CMNV_NH(ref b_so_id, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CMNV_XOA(string b_so_id)
    {
        try
        {
            ns_tt.PNS_CMNV_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion ĐÀO TẠO CHUYÊN MÔN NGHIỆP VỤ

    #region TÚI HỒ SƠ
    [WebMethod(true)]
    public string Fs_NS_THS_CT(string b_so_the, string[] a_cot_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_THS_CT(b_so_the);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            DataTable b_dt_s = b_ds.Tables[2];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_p");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_n");
            bang.P_SO_CNG(ref b_dt_s, "ngay_pn,ngayn");
            return ((bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0)) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct) + "#" + bang.Fs_BANG_CH(b_dt_s, a_cot_lke) + "#" + b_dt_ct.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_THS_NH(object[] a_dt, object[] a_dt_ct, object[] a_dt_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_lke = chuyen.Fas_OBJ_STR((object[])a_dt_lke[0]); object[] a_gtri_lke = (object[])a_dt_lke[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            //bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            //bang.P_DON_DK(ref b_dt_ct, "chon");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_p");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_n");
            DataTable b_dt_lke = bang.Fdt_TAO_THEM(a_cot_lke, a_gtri_lke);
            bang.P_DON_DK(ref b_dt_lke, "hthanh");
            bang.P_CNG_SO(ref b_dt_lke, "ngay_pn");
            bang.P_CNG_SO(ref b_dt_lke, "ngayn");
            bang.P_BO_HANG(ref b_dt_lke, "loai_bc", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "-1", "-1", "-1", "-1", "-1", "-1" });
            if (b_dt_lke.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_lke, new object[] { "-1", "-1", "-1", "-1" });

            //bang.P_THAY_GTRI(ref b_dt_ct, "loai", "Bản cứng", "C");
            //bang.P_THAY_GTRI(ref b_dt_ct, "loai", "Bản mềm", "M");
            //if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" });
            ns_tt.P_NS_THS_NH(b_dt, b_dt_ct, b_dt_lke);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_THS, TEN_BANG.NS_THS);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_THS_XOA(string b_so_the)
    {
        try { ns_tt.P_NS_THS_XOA(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion TÚI HỒ SƠ

    #region ĐỔI SỐ THẺ
    [WebMethod(true)]
    public string Fs_HOI_SO_ID(string b_so_the)
    {
        try
        {
            return ns_tt.Fs_HOI_SO_ID(b_so_the);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CST_LKE(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_CST_LKE(b_so_id);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CST_NH(string b_so_id, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tt.P_NS_CST_NH(b_so_id, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CST_XOA(string b_so_id)
    {
        try
        {
            ns_tt.PNS_CST_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion ĐỔI SỐ THẺ

    #region SƠ YẾU LÝ LỊCH

    [WebMethod(true)]
    public string Fs_NS_SYLL_LKE(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_SYLL_LKE(b_so_id);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_SYLL_NH(string b_so_the, object[] a_dt)
    {
        try
        {
            if (b_so_the == "") return " ";
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_BO_HANG(ref b_dt, "MA", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                //if (chuyen.OBJ_S(b_dr["nd"]) != "")
                //    b_dr["nd"] = "N'" + chuyen.OBJ_S(b_dr["nd"]);
            }
            b_dt.AcceptChanges();
            string b_so_id = ns_tt.Fs_HOI_SO_ID(b_so_the);
            ns_tt.PNS_SYLL_NH(b_so_id, b_dt); return b_so_id;
            throw new Exception("loi:Nhập thành công!:loi");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    #endregion SƠ YẾU LÝ LỊCH

    #region TRÌNH ĐỘ HỌC VẤN CAO NHẤT

    [WebMethod(true)]
    public string Fs_NS_TDHV_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TDHV_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TDHV_CT(string b_so_the, string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TDHV_CT(b_so_the, b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TDHV_NH(string b_so_id, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            return ns_tt.PNS_TDHV_NH(ref b_so_id, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TDHV_XOA(string b_so_id, string b_so_the)
    {
        try
        {
            ns_tt.PNS_TDHV_XOA(b_so_id, b_so_the);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion TRÌNH ĐỘ HỌC VẤN CAO NHẤT

    #region QUÁ TRÌNH ĐÀO TẠO CHUYÊN MÔN
    [WebMethod(true)]
    public string Fs_NS_DTHV_LKE(string b_login, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_DTHV_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_LKE(string b_login, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_DTHV_TT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "K", "Không phê duyệt");
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            bang.P_THAY_GTRI(ref b_dt, "thangd", "/", "");
            bang.P_THAY_GTRI(ref b_dt, "thangc", "/", "");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRUONG", "TEN_TRUONG"); 
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_MA(string b_login, string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_tt.Fdt_NS_DTHV_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_HTDT", "hinhthuc");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_CNGANH", "cnganh");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRUONG", "TEN_TRUONG");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRINHDO", "capdt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_MA(string b_login, string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_tt.Fdt_NS_DTHV_TT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "K", "Không phê duyệt");
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_HTDT", "hinhthuc");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_CNGANH", "cnganh");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRUONG", "TEN_TRUONG");
            //bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRINHDO", "capdt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tt.PNS_DTHV_CT(b_so_id);
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            bang.P_THAY_GTRI(ref b_dt, "thangd", "/", "");
            bang.P_THAY_GTRI(ref b_dt, "thangc", "/", "");
            bang.P_SO_CNG(ref b_dt, "ngaycap");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_HTDT", "hinhthuc");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv", "NS_DTHV_CNGANH", "cnganh");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv", "DT_TRINHDO", "capdt");
            bang.P_BANG_GHEP(ref b_dt, "ten_truong,ten", "{");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tt.PNS_DTHV_TT_CT(b_so_id);
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            bang.P_SO_CNG(ref b_dt, "ngaycap");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv_tt", "NS_DTHV_tt_HTDT", "hinhthuc");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv_tt", "ns_dthv_tt_CNGANH", "cnganh");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv_tt", "DT_TRUONG", "TEN_TRUONG");
            bang.P_TIM_THEM(ref b_dt, "ns_dthv_tt", "DT_TRINHDO", "capdt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngaycap");
            bang.P_CTH_SO(ref b_dt_ct, "thangd,thangc");
            bang.P_CSO_SO(ref b_dt_ct, "nam_tn");
            b_so_id = ns_tt.PNS_DTHV_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DTHV, TEN_BANG.NS_DTHV);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_DTHV_MA(b_login, b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngaycap");
            bang.P_CTH_SO(ref b_dt_ct, "thangd,thangc");
            bang.P_CSO_SO(ref b_dt_ct, "nam_tn");
            b_so_id = ns_tt.PNS_DTHV_TT_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_DTHV_TT_MA(b_login, b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_XOA(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tt.PNS_DTHV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DTHV, TEN_BANG.NS_DTHV);
            return Fs_NS_DTHV_LKE(b_login, b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_GUI(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tt.PNS_DTHV_TT_GUI(b_so_id); return Fs_NS_DTHV_TT_LKE(b_login, b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DTHV_TT_XOA(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tt.PNS_DTHV_TT_XOA(b_so_id);
            return Fs_NS_DTHV_TT_LKE(b_login, b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUÁ TRÌNH ĐÀO TẠO CHUYÊN MÔN

    #region QUÁ TRÌNH ĐÀO TẠO NGẮN HẠN
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_DT_NGHAN_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCHN", "Chứng chỉ hành nghề");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCC", "Chứng chỉ con");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCK", "Chứng chỉ khác");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_DT_NGHAN_TT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];

            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCHN", "Chứng chỉ hành nghề");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCC", "Chứng chỉ con");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_loai_cc", "CCK", "Chứng chỉ khác");

            bang.P_COPY_COL(ref b_dt_tk, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tthai", "K", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_MA(string b_so_the, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_DT_NGHAN_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCHN", "Chứng chỉ hành nghề");
            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCC", "Chứng chỉ con");
            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCK", "Chứng chỉ khác");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_MA(string b_so_the, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_DT_NGHAN_TT_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCHN", "Chứng chỉ hành nghề");
            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCC", "Chứng chỉ con");
            bang.P_THAY_GTRI(ref b_dt, "ten_loai_cc", "CCK", "Chứng chỉ khác");

            bang.P_COPY_COL(ref b_dt, "ten_tthai", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "G", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tthai", "K", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_CT(string b_so_id, string[] a_cot_cchn, string[] a_cot_ccc)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_DT_NGHAN_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_cchn = b_ds.Tables[1]; DataTable b_dt_ccc = b_ds.Tables[2];

            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");
            bang.P_SO_CNG(ref b_dt_cchn, "NGAY_CAP"); bang.P_SO_CTH(ref b_dt_cchn, "THANG_CAP");
            bang.P_SO_CNG(ref b_dt_ccc, "CCC_NGAY_HL,CCC_NGAYHET_HL"); bang.P_SO_CSO(ref b_dt_ccc, "tien_camket");

            foreach (DataRow b_row in b_dt_cchn.Rows)
            {
                string b_vung = chuyen.OBJ_S(b_row["vung"]), b_ten_vung = chuyen.OBJ_S(b_row["ten_vung"]);
                string b_ubck = chuyen.OBJ_S(b_row["ubck"]), b_ten_ubck = chuyen.OBJ_S(b_row["ten_ubck"]);
                string b_qtrr = chuyen.OBJ_S(b_row["qtrr"]), b_ten_qtrr = chuyen.OBJ_S(b_row["ten_qtrr"]);

                b_row["VUNG"] = b_vung + "{" + b_ten_vung;
                b_row["UBCK"] = b_ubck + "{" + b_ten_ubck;
                b_row["QTRR"] = b_qtrr + "{" + b_ten_qtrr;
            } 
            bang.P_TIM_THEM(ref b_dt_cchn, "ns_dt_nghan", "DT_CCHN", "ma_cchn"); 
            bang.P_TIM_THEM(ref b_dt_ccc, "ns_dt_nghan", "DT_CCC", "ma_ccc");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_cchn, a_cot_cchn) + "#" + bang.Fs_BANG_CH(b_dt_ccc, a_cot_ccc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_CT(string b_so_id, string[] a_cot_cchn, string[] a_cot_ccc)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_DT_NGHAN_TT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_cchn = b_ds.Tables[1]; DataTable b_dt_ccc = b_ds.Tables[2];

            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");
            bang.P_SO_CNG(ref b_dt_cchn, "NGAY_CAP"); bang.P_SO_CTH(ref b_dt_cchn, "THANG_CAP");
            bang.P_SO_CNG(ref b_dt_ccc, "CCC_NGAY_HL,CCC_NGAYHET_HL"); bang.P_SO_CSO(ref b_dt_ccc, "tien_camket");

            bang.P_TIM_THEM(ref b_dt_cchn, "ns_dt_tt_nghan", "DT_CCHN", "ma_cchn");
            bang.P_TIM_THEM(ref b_dt_cchn, "ns_dt_tt_nghan", "DT_VUNG", "vung");
            bang.P_TIM_THEM(ref b_dt_cchn, "ns_dt_tt_nghan", "DT_UBCK", "ubck");
            bang.P_TIM_THEM(ref b_dt_cchn, "ns_dt_tt_nghan", "DT_QTRR", "qtrr");
            bang.P_TIM_THEM(ref b_dt_ccc, "ns_dt_tt_nghan", "DT_CCC", "ma_ccc");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_cchn, a_cot_cchn) + "#" + bang.Fs_BANG_CH(b_dt_ccc, a_cot_ccc);


        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_NH(double b_so_id, double b_trangKT, object[] a_dt_ct, object[] a_dt_cchn, object[] a_dt_ccc, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");

            string[] a_cot_cchn = chuyen.Fas_OBJ_STR((object[])a_dt_cchn[0]);
            object[] a_gtri_cchn = (object[])a_dt_cchn[1];
            DataTable b_dt_ct_cchn = bang.Fdt_TAO_THEM(a_cot_cchn, a_gtri_cchn);
            bang.P_CNG_SO(ref b_dt_ct_cchn, "ngay_cap");
            bang.P_CTH_SO(ref b_dt_ct_cchn, "thang_cap");

            string[] a_cot_ccc = chuyen.Fas_OBJ_STR((object[])a_dt_ccc[0]);
            object[] a_gtri_ccc = (object[])a_dt_ccc[1];
            DataTable b_dt_ct_ccc = bang.Fdt_TAO_THEM(a_cot_ccc, a_gtri_ccc);
            bang.P_CNG_SO(ref b_dt_ct_ccc, "ccc_ngay_hl,ccc_ngayhet_hl");
            bang.P_CSO_SO(ref b_dt_ct_ccc, "tien_camket,thang_camket");

            ns_tt.P_NS_DT_NGHAN_NH(ref b_so_id, b_dt_ct, b_dt_ct_cchn, b_dt_ct_ccc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DT_NGHAN, TEN_BANG.NS_DT_NGHAN);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_DT_NGHAN_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_NH(double b_so_id, double b_trangKT, object[] a_dt_ct, object[] a_dt_cchn, object[] a_dt_ccc, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");

            string[] a_cot_cchn = chuyen.Fas_OBJ_STR((object[])a_dt_cchn[0]);
            object[] a_gtri_cchn = (object[])a_dt_cchn[1];
            DataTable b_dt_ct_cchn = bang.Fdt_TAO_THEM(a_cot_cchn, a_gtri_cchn);
            bang.P_CNG_SO(ref b_dt_ct_cchn, "ngay_cap");
            bang.P_CTH_SO(ref b_dt_ct_cchn, "thang_cap");

            string[] a_cot_ccc = chuyen.Fas_OBJ_STR((object[])a_dt_ccc[0]);
            object[] a_gtri_ccc = (object[])a_dt_ccc[1];
            DataTable b_dt_ct_ccc = bang.Fdt_TAO_THEM(a_cot_ccc, a_gtri_ccc);
            bang.P_CNG_SO(ref b_dt_ct_ccc, "ccc_ngay_hl,ccc_ngayhet_hl");
            bang.P_CSO_SO(ref b_dt_ct_ccc, "tien_camket,thang_camket");

            ns_tt.P_NS_DT_NGHAN_TT_NH(ref b_so_id, b_dt_ct, b_dt_ct_cchn, b_dt_ct_ccc);

            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_DT_NGHAN_TT_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tt.P_NS_DT_NGHAN_XOA(b_so_id, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DT_NGHAN, TEN_BANG.NS_DT_NGHAN);
            return Fs_NS_DT_NGHAN_LKE(b_so_the, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_GUI(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.P_NS_DT_NGHAN_TT_GUI(b_so_id, b_so_the); return Fs_NS_DT_NGHAN_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_NGHAN_TT_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.P_NS_DT_NGHAN_TT_XOA(b_so_id, b_so_the); return Fs_NS_DT_NGHAN_TT_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion QUÁ TRÌNH ĐÀO TẠO NGẮN HẠN

    #region QUÁ TRÌNH PHONG HỌC HÀM

    [WebMethod(true)]
    public string Fs_NS_PHH_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_PHH_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHH_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_PHH_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHH_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_PHH_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHH_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            b_so_id = ns_tt.PNS_PHH_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_PHH_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_PHH_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_PHH_XOA(b_so_id); return Fs_NS_PHH_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion QUÁ TRÌNH PHONG HỌC HÀM

    #region CÔNG ĐOÀN
    [WebMethod(true)]
    public string Fs_NS_TC_CD_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_TC_CD_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_CD_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_CD_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_CD_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_TC_CD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngayd,ngayvao");
            DataTable b_dt_ct = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_CD_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayd,ngayvao");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_ct, "tt");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" }); ; bang.P_BO_HANG(ref b_dt_ct, "tt", "");
            ns_tt.P_NS_TC_CD_NH(b_so_id, b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_CD_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_CD_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try { ns_tt.P_NS_TC_CD_XOA(b_so_id); return Fs_NS_TC_CD_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CÔNG ĐOÀN

    #region ĐẢNG VIÊN

    [WebMethod(true)]
    public string Fs_NS_TC_DANG_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_TC_DANG_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_DANG_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_DANG_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DANG_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_TC_DANG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngaycap,ngayvao,ngayct");
            DataTable b_dt_ct = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DANG_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngaycap,ngayvao,ngayct");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_ct, "tt"); bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" }); ; bang.P_BO_HANG(ref b_dt_ct, "tt", "");
            ns_tt.P_NS_TC_DANG_NH(b_so_id, b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_DANG_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DANG_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try { ns_tt.P_NS_TC_DANG_XOA(b_so_id); return Fs_NS_TC_DANG_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion ĐẢNG VIÊN

    #region ĐOÀN VIÊN

    [WebMethod(true)]
    public string Fs_NS_TC_DV_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_TC_DV_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_DV_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_DV_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DV_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_TC_DV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngaycap,ngayvao");
            DataTable b_dt_ct = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DV_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngaycap,ngayvao");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_ct, "tt"); bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "" }); ; bang.P_BO_HANG(ref b_dt_ct, "tt", "");
            ns_tt.P_NS_TC_DV_NH(b_so_id, b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_DV_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DV_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try { ns_tt.P_NS_TC_DV_XOA(b_so_id); return Fs_NS_TC_DV_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐOÀN VIÊN

    #region HỘI CỰU CHIẾN BINH
    [WebMethod(true)]
    public string Fs_NS_TC_CCB_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.PNS_TC_CCB_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_CCB_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_CCB_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_CCB_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TC_CCB_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngaycap,ngayvao");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_CCB_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngaycap,ngayvao");
            ns_tt.PNS_TC_CCB_NH(b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_CCB_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_CCB_XOA(string b_so_the, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_CCB_XOA(b_so_the); return Fs_NS_TC_CCB_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion HỘI CỰU CHIẾN BINH

    #region THAM GIA QUÂN ĐỘI
    [WebMethod(true)]
    public string Fs_NS_TC_QD_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.PNS_TC_QD_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_QD_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_QD_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_QD_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TC_QD_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngaynhap,ngayxuat");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_QD_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngaynhap,ngayxuat");
            ns_tt.PNS_TC_QD_NH(b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_QD_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_QD_XOA(string b_so_the, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_QD_XOA(b_so_the); return Fs_NS_TC_QD_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THAM GIA QUÂN ĐỘI

    #region CÁC TỔ CHỨC KHÁC
    [WebMethod(true)]
    public string Fs_NS_TC_KH_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.PNS_TC_KH_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_KH_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_KH_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_KH_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TC_KH_CT(b_so_id); bang.P_SO_CNG(ref b_dt, "ngaycap,ngayvao");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_KH_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngaycap,ngayvao");
            b_so_id = ns_tt.PNS_TC_KH_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_KH_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_KH_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_KH_XOA(b_so_id); return Fs_NS_TC_KH_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CÁC TỔ CHỨC KHÁC

    #region HUY HIỆU ĐẢNG
    [WebMethod(true)]
    public string Fs_NS_TC_HHDANG_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.PNS_TC_HHDANG_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_HHDANG_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_HHDANG_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_HHDANG_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TC_HHDANG_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_HHDANG_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            b_so_id = ns_tt.PNS_TC_HHDANG_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_HHDANG_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_HHDANG_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_HHDANG_XOA(b_so_id); return Fs_NS_TC_HHDANG_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion HUY HIỆU ĐẢNG

    #region KỶ LUẬT ĐẢNG
    [WebMethod(true)]
    public string Fs_NS_TC_KLDANG_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.PNS_TC_KLDANG_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_KLDANG_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_KLDANG_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_KLDANG_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_TC_KLDANG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayqd,ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_KLDANG_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngayqd,ngayd,ngayc");
            b_so_id = ns_tt.PNS_TC_KLDANG_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_KLDANG_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_KLDANG_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_KLDANG_XOA(b_so_id); return Fs_NS_TC_KLDANG_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion KỶ LUẬT ĐẢNG

    #region HOÀN CẢNH KINH TẾ GIA ĐÌNH
    [WebMethod(true)]
    public string Fs_NS_GD_HC_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_GD_HC_LKE(b_so_the, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_GD_HC_MA(string b_so_the, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_GD_HC_MA(b_so_the, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngayd", b_ngay);
            bang.P_SO_CNG(ref b_dt, "ngayd");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GD_HC_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_GD_HC_CT(b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GD_HC_NH(string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_ct.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ten", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                b_dt_ct.Rows[i]["tt"] = i + 1;
                if (b_dt_ct.Rows[i]["ten"].ToString().Equals("") || b_dt_ct.Rows[i]["gtri"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            ns_tt.P_NS_GD_HC_NH(b_so_id, b_dt, b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngayd", a_cot, a_gtri), b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_GD_HC_MA(b_so_the, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GD_HC_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try { ns_tt.P_NS_GD_HC_XOA(b_so_id); return Fs_NS_GD_HC_LKE(b_so_the, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion HOÀN CẢNH KINH TẾ GIA ĐÌNH

    #region KẾT NẠP ĐẢNG LẦN II
    [WebMethod(true)]
    public string Fs_NS_TC_DANGL2_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_TC_DANGL2_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngayvao,ngayct,ngayph");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DANGL2_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_TC_DANGL2_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_DANGL2_MA(string b_phong, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_TC_DANGL2_MA(b_phong, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TC_DANGL2_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngayvao,ngayct,ngayph");
            ns_tt.P_NS_TC_DANGL2_NH(b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_TC_DANGL2_MA(b_phong, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TC_DANGL2_XOA(string b_so_the, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_TC_DANGL2_XOA(b_so_the); return Fs_NS_TC_DANGL2_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾT NẠP ĐẢNG LẦN II

    #region KỸ NĂNG CÁ NHÂN
    [WebMethod(true)]
    public string Fs_NS_KYNANG_CN_CT(string b_so_the, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_KYNANG_CN_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngayd");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
             b_dt_ct_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_KYNANG_CN_NH(object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayd");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ma", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "", "" });
            ns_tt.P_NS_KYNANG_CN_NH(b_dt, b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KYNANG_CN_XOA(string b_so_the)
    {
        try { ns_tt.P_NS_KYNANG_CN_XOA(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KỸ NĂNG CÁ NHÂN

    #region FILE ẢNH


    [WebMethod(true)]
    public string Fs_FI_LOGO_TRA(string b_goc)
    {
        try
        {
            se.se_nsd b_se = new se.se_nsd();
            string b_tm = Server.MapPath("~/Outputs/file_nhap"), b_ten = "F_" + b_se.ma_dvi + "_" + (b_se.nsd).Replace("/", "-");
            string[] a_f = Directory.GetFiles(b_tm, b_ten + ".*");
            foreach (string b_s in a_f) File.Delete(b_s);
            b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            int b_i = b_goc.LastIndexOf('.');
            string b_mr = (b_i > 0) ? b_goc.Substring(b_i) : "";
            File.Copy(b_goc, b_tm + "/" + b_ten + b_mr, true);
            return "../../../Outputs/file_nhap/" + b_ten + b_mr;
        }
        //catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
        catch (Exception ex) { return "/images/no_image.png"; }
    }



    [WebMethod(true)]
    public string Fs_FI_ANH_LKE(string b_ma_dvi, string b_so_id, double b_cuoi)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_FI_ANH_LKE(b_ma_dvi, b_so_id, b_cuoi);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(b_dt.Rows[b_dt.Rows.Count - 1]["bt"]) + "#" + bang.Fs_BANG_CH(b_dt, "ten,goc");
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_ANH_XOA(string b_ma_dvi, string b_so_id, string b_goc)
    {
        try
        {
            ns_tt.P_FI_ANH_XOA(b_ma_dvi, b_so_id, b_goc);
            b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            if (File.Exists(b_goc)) File.Delete(b_goc);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_FI_ANH_SUA(string b_ma_dvi, string b_so_id, string b_goc, string b_nd)
    {
        try
        {
            ns_tt.P_FI_ANH_SUA(b_ma_dvi, b_so_id, b_goc, "N'" + b_nd);
            return b_goc;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    #endregion

    #region CÀI ĐẶT QUẢN LÝ
    [WebMethod(true)]
    public string Fs_NS_CAIDAT_QLY_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_CAIDAT_QLY_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CAIDAT_QLY_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_CAIDAT_QLY_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CAIDAT_QLY_CT(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_CAIDAT_QLY_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CAIDAT_QLY_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "phong", "");
            ns_tt.P_NS_CAIDAT_QLY_NH(b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CAIDAT_QLY, TEN_BANG.NS_CAIDAT_QLY);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_CAIDAT_QLY_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CAIDAT_QLY_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tt.P_NS_CAIDAT_QLY_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CAIDAT_QLY, TEN_BANG.NS_CAIDAT_QLY);
            return Fs_NS_CAIDAT_QLY_LKE(a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CÀI ĐẶT QUẢN LÝ

    #region QUẢN LÝ PHÚC LỢI CÁ NHÂN
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_CN_LKE(string b_login, string b_phong, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_CN_LKE(b_phong, b_so_the, b_ten, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_tt");
            bang.P_SO_CSO(ref b_dt_tk, "sotien");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_CN_MA(string b_login, string b_phong, string b_so_the, string b_ten, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_CN_MA(b_phong, b_so_the, b_ten, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            bang.P_SO_CSO(ref b_dt, "sotien");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_CN_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tt.PNS_PHUCLOI_CN_CT(b_so_id);
            if (b_dt.Rows.Count > 0)
            {
                if (b_dt.Rows[0]["is_tinhluong"].ToString() != "0")
                {
                    int b_nam = chuyen.OBJ_I(b_dt.Rows[0]["nam"]);
                    DataTable b_dt_ky = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
                    bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
                    se.P_TG_LUU("ns_phucloi_cn", "DT_KYLUONG", b_dt_ky);
                }
            }
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_TIM_THEM(ref b_dt, "ns_phucloi_cn", "NS_PHUCLOI_CN_PL", "LOAI_PL");
            bang.P_TIM_THEM(ref b_dt, "ns_phucloi_cn", "DT_KYLUONG", "kyluong");
            bang.P_COPY_COL(ref b_dt, "luong_chiuthue", "is_tinhluong");
            bang.P_COPY_COL(ref b_dt, "luong_khongchiuthue", "is_tinhluong");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "0", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "2", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "1", "X");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "0", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "1", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "2", "X");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_CN_NH(string b_login, string b_phong, string b_so_the, string b_ten, double b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tt");
            b_so_id = ns_tt.PNS_PHUCLOI_CN_NH(b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_PHUCLOI_CN, TEN_BANG.NS_PHUCLOI_CN);
            return Fs_NS_PHUCLOI_CN_MA(b_login, b_phong, b_so_the, b_ten, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_CN_XOA(string b_login, string b_phong, string b_so_the, string b_ten, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tt.PNS_PHUCLOI_CN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_PHUCLOI_CN, TEN_BANG.NS_PHUCLOI_CN);
            return Fs_NS_PHUCLOI_CN_LKE(b_login, b_phong, b_so_the, b_ten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion QUAN HỆ NHÂN THÂN

    #region QUẢN LÝ PHÚC LỢI TỰ ĐỘNG
    [WebMethod(true)]
    public string Fdt_NS_PHUCLOI_TUDONG_LKE(string b_phong, string b_kyluong_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_TUDONG_LKE(b_phong, b_kyluong_id, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "SOTIEN");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_TUDONG_CT(string b_phong, string b_kyluong_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_PHUCLOI_TUDONG_CT(b_phong, b_kyluong_id);
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_TUDONG_TINH(string b_phong, string b_kyluong_id, string[] a_cot, double[] a_tso)
    {
        try
        {
            ns_tt.PNS_PHUCLOI_TUDONG_TINH(b_phong, b_kyluong_id);
            return Fdt_NS_PHUCLOI_TUDONG_LKE(b_phong, b_kyluong_id, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_TUDONG_XOA(string b_so_id, string b_phong, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_PHUCLOI_TUDONG_XOA(b_so_id); return Fdt_NS_PHUCLOI_TUDONG_LKE(b_phong, b_kyluong, a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_TU_DONG_LKE(string b_login, string b_phong, string b_so_the, string b_hoTen, string b_ngayD, string b_ngayC, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_TU_DONG_LKE(b_phong, b_so_the, b_hoTen, chuyen.CNG_SO(b_ngayD), chuyen.CNG_SO(b_ngayC), b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "SOTIEN");
            bang.P_SO_CNG(ref b_dt_tk, "ng_apdung");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_TU_DONG_TINH(string b_login, string b_phong, string b_so_the, string b_hoTen, string b_ngayD, string b_ngayC, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tt.PNS_PHUCLOI_TU_DONG_TINH(b_phong, b_so_the, b_hoTen, chuyen.CNG_SO(b_ngayD), chuyen.CNG_SO(b_ngayC));
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.NS_PHUCLOI_TUDONG, TEN_BANG.NS_PHUCLOI_TUDONG);
            return Fs_NS_PHUCLOI_TU_DONG_LKE(b_login, b_phong, b_so_the, b_hoTen, b_ngayD, b_ngayC, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUAN HỆ NHÂN THÂN

    #region TÌM KIẾM DANH SÁCH

    [WebMethod(true)]
    public string Fs_NS_KYNANG_CN_TIM(string[] a_cot_kq, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ma", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "", "" });
            DataTable b_kq = ns_tt.P_NS_KYNANG_CN_TIM(b_dt_ct);
            //bang.P_THEM_COL(ref b_kq, "sott");
            string b_dt_ct_s = bang.Fb_TRANG(b_kq) ? "" : bang.Fs_BANG_CH(b_kq, a_cot_kq);
            return b_dt_ct_s + "#" + b_kq.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_DANHSACH_TIM(string b_lke, object[] a_dt_cn, string[] a_cot_kq, object[] a_dt_ct, object[] a_dt_cc)
    {
        try
        {
            string[] a_cot_cn = chuyen.Fas_OBJ_STR((object[])a_dt_cn[0]); object[] a_gtri_cn = (object[])a_dt_cn[1];
            DataTable b_dt_cn = bang.Fdt_TAO_THEM(a_cot_cn, a_gtri_cn);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ma", "");
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc); bang.P_BO_HANG(ref b_dt_cc, "cc", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "", "" });
            if (b_dt_cc.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_cc, new object[] { "-1", "" });
            DataTable b_kq = ns_tt.P_NS_DANHSACH_TIM(b_lke, b_dt_cn, b_dt_ct, b_dt_cc);
            //bang.P_THEM_COL(ref b_kq, "sott");
            string b_dt_ct_s = bang.Fb_TRANG(b_kq) ? "" : bang.Fs_BANG_CH(b_kq, a_cot_kq);
            return b_dt_ct_s + "#" + b_kq.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_EXCEL(string b_form, string b_md, string b_ma_bc, string b_ddan, string b_ten_rp, string b_kieu_in, object[] a_dt_ct, object[] a_dt)
    {
        string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri_dk = (object[])a_dt[1];
        DataTable b_dt, b_dt_ct;
        if (HttpContext.Current.Session["b_ds_kq_in"] == null)
        {
            b_dt = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
        }
        else
        {
            b_dt = (DataTable)HttpContext.Current.Session["b_ds_kq_in"];
        }
        bang.P_BO_HANG(ref b_dt, "sott", "");
        if (a_dt_ct != null)
        {
            string[] a_ten = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            b_dt_ct = bang.Fdt_TAO_THEM(a_ten, a_gtri);
            bang.P_THEM_COL(ref b_dt_ct, new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" },
                    new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        }
        else
        {
            b_dt_ct = bang.Fdt_TAO_THEM(new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" }, new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        }
        //bang.P_DOI_TENCOL(ref b_dt, "sott,so_the,ten,ten_phong,cdanh,dtdd,email", "SOTT,SO_THE,TEN,TEN_PHONG,CDANH,DTDD,EMAIL");
        DataSet b_ds = new DataSet(); b_dt.TableName = "B"; b_dt_ct.TableName = "TSO";
        //b_ds.Tables.Add(b_dt.Copy()); b_ds.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.AcceptChanges();
        b_ds.Tables.Add(b_dt_ct.Copy()); b_ds.AcceptChanges();
        se.P_KQ_LUU("TK_KQ", "EXCEL", b_ds);
        return "";
    }
    #endregion

    #region QUÁ TRÌNH HỌC TẬP
    [WebMethod(true)]
    public string Fs_NS_DT_QT_HOCTAP_LKE(string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_DT_QT_HOCTAP_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CTH(ref b_dt_tk, "thangd,thangc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QT_HOCTAP_MA(string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_DT_QT_HOCTAP_MA(b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_QT_HOCTAP_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_DT_QT_HOCTAP_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_hieu_luc");
            bang.P_SO_CTH(ref b_dt, "thangd");
            bang.P_SO_CTH(ref b_dt, "thangc");
            bang.P_TIM_THEM(ref b_dt, "ns_dt_hoctap", "DT_KQDT", "ma_ketqua_dt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QT_HOCTAP_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_hieu_luc");
            bang.P_CSO_SO(ref b_dt_ct, "nam_tn");
            bang.P_CTH_SO(ref b_dt_ct, "THANGD");
            bang.P_CTH_SO(ref b_dt_ct, "thangc");
            b_so_id = ns_tt.P_NS_DT_QT_HOCTAP_NH(ref b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_DT_QT_HOCTAP_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_QT_HOCTAP_XOA(string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_tt.P_NS_DT_QT_HOCTAP_XOA(b_so_id, b_so_the);
            return Fs_NS_DT_QT_HOCTAP_LKE(b_so_the, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion QUÁ TRÌNH HỌC TẬP

    #region ĐÁNH GIÁ HĐLĐ
    [WebMethod(true)]
    public string Fs_NS_HD_DG_TT_LKE(string b_so_the, string[] a_cot_nv, string[] a_cot_qhcv)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_HD_DG_TT_LKE(b_so_the);
            DataTable b_dt_ct = (DataTable)a_object[1], b_dt_nv = (DataTable)a_object[2], b_dt_qhcv = (DataTable)a_object[3];
            bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            return bang.Fb_TRANG(b_dt_ct) ? "" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_HANG_GOP(b_dt_ct, 0) + "#" + bang.Fs_BANG_CH(b_dt_nv, a_cot_nv) + "#" + bang.Fs_BANG_CH(b_dt_qhcv, a_cot_qhcv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_HD_DG_TT_NH(double b_so_id_hd, string b_so_the, object[] a_dt_ct, object[] a_dt_nv, object[] a_dt_qhcv)
    {
        try
        {
            double b_out;
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);


            string[] a_cot_nv = chuyen.Fas_OBJ_STR((object[])a_dt_nv[0]);
            object[] a_gtri_nv = (object[])a_dt_nv[1];
            DataTable b_dt_nv = bang.Fdt_TAO_THEM(a_cot_nv, a_gtri_nv);
            for (int i = 0; i < b_dt_nv.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_nv.Rows[i]["SOTT"]) != "" || chuyen.OBJ_S(b_dt_nv.Rows[i]["CONG_VIEC"]) != "" ||
                    chuyen.OBJ_S(b_dt_nv.Rows[i]["MO_TA"]) != "" || chuyen.OBJ_S(b_dt_nv.Rows[i]["NGUOI_HD"]) != "" ||
                    chuyen.OBJ_S(b_dt_nv.Rows[i]["NGUOI_PH"]) != "" || chuyen.OBJ_S(b_dt_nv.Rows[i]["ket_qua"]) != "")
                {
                    if (chuyen.OBJ_S(b_dt_nv.Rows[i]["SOTT"]) == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập số thứ tự:loi");
                    }
                    else if (!double.TryParse(chuyen.OBJ_S(b_dt_nv.Rows[i]["SOTT"]), out b_out))
                    {
                        return form.Fs_LOC_LOI("loi:Số thứ tự không đúng định dạng:loi");
                    }

                    if (chuyen.OBJ_S(b_dt_nv.Rows[i]["CONG_VIEC"]) == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập Công việc:loi");
                    }

                    if (chuyen.OBJ_S(b_dt_nv.Rows[i]["MO_TA"]) == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập Mô tả phương thức thực hiện:loi");
                    }

                    if (chuyen.OBJ_S(b_dt_nv.Rows[i]["NGUOI_HD"]) == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập Người hướng dẫn:loi");
                    }

                    if (chuyen.OBJ_S(b_dt_nv.Rows[i]["NGUOI_PH"]) == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập Người phối hợp thực hiện:loi");
                    }
                }
            }
            string[] a_cot_qhcv = chuyen.Fas_OBJ_STR((object[])a_dt_qhcv[0]);
            object[] a_gtri_qhcv = (object[])a_dt_qhcv[1];
            DataTable b_dt_qhcv = bang.Fdt_TAO_THEM(a_cot_qhcv, a_gtri_qhcv);
            for (int i = 0; i < b_dt_qhcv.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_qhcv.Rows[i]["SOTT"]) != "" && !double.TryParse(chuyen.OBJ_S(b_dt_qhcv.Rows[i]["SOTT"]), out b_out))
                {
                    return form.Fs_LOC_LOI("loi:Số thứ tự không đúng định dạng:loi");
                }
            }


            bang.P_CSO_SO(ref b_dt_nv, "SOTT");
            bang.P_BO_HANG(ref b_dt_nv, new string[] { "SOTT", "CONG_VIEC", "MO_TA", "NGUOI_HD", "NGUOI_PH", "ket_qua" }, new string[] { "", "", "", "", "", "" });
            bang.P_BO_HANG(ref b_dt_qhcv, new string[] { "sott", "noi_dung", "yeu", "kem", "trung_binh", "kha", "xuat_sac", "ghi_chu" }, new string[] { "", "", "", "", "", "", "", "" });
            if (b_dt_nv.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nv, new object[] { "-1", "" });
            if (b_dt_qhcv.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_qhcv, new object[] { "-1", "" });
            ns_tt.P_NS_HD_DG_TT_NH(b_so_id_hd, b_so_the, b_dt_ct, b_dt_nv, b_dt_qhcv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HD_DG_TT, TEN_BANG.NS_HD_DG_TT);
            return "1";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_HD_DG_TT_GUI(double b_so_id_hd)
    {
        try
        {
            ns_tt.P_NS_HD_DG_TT_GUI(b_so_id_hd);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_HD_DG_TT, TEN_BANG.NS_HD_DG_TT);
            return "1";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐÁNH GIÁ HĐLĐ

    #region CỔNG THÔNG TIN NHÂN SỰ - ĐỐI TƯỢNG CÁN BỘ QUẢN LÝ

    [WebMethod(true)]
    public string Fs_NS_CB_CD_LKE(string b_login, string b_so_the, double b_ttr, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_CB_CD_LKE(b_so_the, b_ttr, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_CD_CT(string b_login, string b_so_id, string b_so_the, string[] a_cot_ct2, string[] a_cot_ct3, string[] a_cot_ct4, string[] a_cot_ct5,
        string[] a_cot_ct6, string[] a_cot_ct7, string[] a_cot_ct8, string[] a_cot_ct9, string[] a_cot_ct10)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            DataSet b_ds = ns_tt.Fds_NS_CB_CD_CT(b_so_id, b_so_the);
            DataTable b_dt1 = b_ds.Tables[0]; // syll
            DataTable b_dt2 = b_ds.Tables[1]; // nang luc

            DataTable b_dt3 = b_ds.Tables[2]; // qua trinh cong tac truoc day
            DataTable b_dt4 = b_ds.Tables[3]; // qua trinh cong tac tai cong ty
            DataTable b_dt5 = b_ds.Tables[4]; // qua trinh dao tao
            DataTable b_dt6 = b_ds.Tables[5]; // qua trinh hoc tap
            DataTable b_dt7 = b_ds.Tables[6]; // qua trinh hop dong lao dong
            DataTable b_dt8 = b_ds.Tables[7]; // qua trinh khen thuong
            DataTable b_dt9 = b_ds.Tables[8]; // qua trinh ky luat
            DataTable b_dt10 = b_ds.Tables[9]; // ket qua danh gia

            bang.P_SO_CNG(ref b_dt1, new string[] { "nsinh" });

            bang.P_SO_CNG(ref b_dt3, new string[] { "ngayd", "ngayc" });
            bang.P_SO_CNG(ref b_dt4, new string[] { "ngay_qd", "ngayd", "ngayc" });

            bang.P_SO_CTH(ref b_dt6, "thangd"); bang.P_SO_CTH(ref b_dt3, "thangc");
            bang.P_SO_CNG(ref b_dt6, new string[] { "ngay_hieu_luc" });

            bang.P_SO_CNG(ref b_dt7, new string[] { "ngay_ky", "ngayd", "ngayc" });
            bang.P_SO_CNG(ref b_dt8, new string[] { "ngayqd" });
            bang.P_SO_CNG(ref b_dt9, new string[] { "ngayqd", "ngayd", "ngayc" });

            return (bang.Fb_TRANG(b_dt1) ? "" : bang.Fs_HANG_GOP(b_dt1, 0))
                + "#" + (bang.Fb_TRANG(b_dt2) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct2))
                + "#" + (bang.Fb_TRANG(b_dt3) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct3))
                + "#" + (bang.Fb_TRANG(b_dt4) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct4))
                + "#" + (bang.Fb_TRANG(b_dt5) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct5))
                + "#" + (bang.Fb_TRANG(b_dt6) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct6))
                + "#" + (bang.Fb_TRANG(b_dt7) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct7))
                + "#" + (bang.Fb_TRANG(b_dt8) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct8))
                + "#" + (bang.Fb_TRANG(b_dt9) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct9))
                + "#" + (bang.Fb_TRANG(b_dt10) ? "" : bang.Fs_BANG_CH(b_dt2, a_cot_ct10));

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CỔNG THÔNG TIN NHÂN SỰ - ĐỐI TƯỢNG CÁN BỘ QUẢN LÝ

    #region QUẢN LÝ PHÚC LỢI
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_NV_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt_tk, "SOTIEN");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_TIEN(string b_loaipl)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_NV_TIEN(b_loaipl);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            return chuyen.OBJ_S(a_object[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_MA(string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_tt.Fdt_NS_PHUCLOI_NV_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "SO_THE", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_tt.PNS_PHUCLOI_CN_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_tt");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_NH(double b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tt");
            b_so_id = ns_tt.PNS_PHUCLOI_CN_NH(b_so_id, b_dt_ct);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_PHUCLOI_NV_MA(b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_PHUCLOI_NV_XOA(double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { ns_tt.PNS_PHUCLOI_CN_XOA(b_so_id); return Fs_NS_PHUCLOI_NV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region[ĐÁNH GIÁ HỢP ĐỒNG LAO ĐỘNG]

    [WebMethod(true)]
    public string Fs_NS_TT_CBQL_DGIA_HDLD_LKE(string b_login, string b_tthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_tt.Fdt_NS_TT_CBQL_DGIA_HDLD_LKE(b_tthai, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_NS_HD_DG_TT_CBQL_LKE(string b_login, string[] a_cot)
    {
        try
        {
            DataTable b_dt = bang.Fdt_TAO_BANG(a_cot, "SSSSSS");
            bang.P_THEM_HANG(ref b_dt, new object[] { "Tài chính", "", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "Khách hàng", "", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "Sản xuất dịch vụ", "", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "Năng lực nội tại", "", "", "", "", "" });
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_TT_CBQL_DGIA_HDLD_HOI(string b_so_the)
    {
        try
        {
            string b_phong, b_ten, b_cdanh, b_ten_lhd, b_ngayd, b_ngayc;
            DataTable b_dt = ns_tt.Fdt_NS_TT_CBQL_DGIA_HDLD_HOI(b_so_the);
            object[] b_tenobj = bang.Fobj_COL_MANG(b_dt, "ten"); if (b_tenobj == null) b_ten = ""; else b_ten = chuyen.OBJ_S(b_tenobj[0]);
            object[] b_cdanhobj = bang.Fobj_COL_MANG(b_dt, "cdanh"); if (b_cdanhobj == null) b_cdanh = ""; else b_cdanh = chuyen.OBJ_S(b_cdanhobj[0]);
            object[] b_phongobj = bang.Fobj_COL_MANG(b_dt, "phong"); if (b_phongobj == null) b_phong = ""; else b_phong = chuyen.OBJ_S(b_phongobj[0]);
            object[] b_ten_lhdobj = bang.Fobj_COL_MANG(b_dt, "ten_lhd"); if (b_ten_lhdobj == null) b_ten_lhd = ""; else b_ten_lhd = chuyen.OBJ_S(b_ten_lhdobj[0]);
            object[] b_ngayddobj = bang.Fobj_COL_MANG(b_dt, "ngayd_hd"); if (b_ngayddobj == null) b_ngayd = ""; else b_ngayd = chuyen.OBJ_S(b_ngayddobj[0]);
            object[] b_ngaycobj = bang.Fobj_COL_MANG(b_dt, "ngayc_hd"); if (b_ngaycobj == null) b_ngayc = ""; else b_ngayc = chuyen.OBJ_S(b_ngaycobj[0]);
            string b_kq = b_so_the + "#" + b_ten + "#" + b_cdanh + "#" + b_phong + "#" + b_ten_lhd + "#" + chuyen.CSO_CNG(b_ngayd) + "#" + chuyen.CSO_CNG(b_ngayc);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HD_DG_TT_CBQL_NH(string b_login, string b_ma_cb, object[] a_dt, object[] a_dt_dg, object[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_dg[0]);
            object[] a_gtri = (object[])a_dt_dg[1];
            DataTable b_dt_dg = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON(ref b_dt_dg, "bt");
            a_cot = chuyen.Fas_OBJ_STR((object[])a_cot_lke[0]);
            a_gtri = (object[])a_cot_lke[1];
            DataTable b_dt_lke = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON(ref b_dt_lke, "khiacanh");
            a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_tt.Fdt_NS_TT_CBQL_DGIA_HDLD_NH(b_ma_cb, b_dt, b_dt_dg, b_dt_lke);

            //bang.P_CNG_SO(ref b_dt_ct, "ngay_hieu_luc");
            //bang.P_CSO_SO(ref b_dt_ct, "nam_tn");
            //bang.P_CTH_SO(ref b_dt_ct, "THANGD");
            //bang.P_CTH_SO(ref b_dt_ct, "thangc");
            //b_so_id = ns_tt.P_NS_DT_QT_HOCTAP_NH(ref b_so_id, b_dt_ct);
            //string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            //return Fs_NS_DT_QT_HOCTAP_MA(b_so_the, b_so_id, b_trangKT, a_cot_lke);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }


    #endregion

    #region THÔNG TIN HỘ GIA ĐÌNH

    [WebMethod(true)]
    public string Fs_NS_HO_GDINH_CT(string b_login, string b_so_the, string[] a_cot_lke_qhe)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_tt.Fds_NS_HO_GDINH_CT(b_so_the);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_qhe = b_ds.Tables[1];

            bang.P_BANG_GHEP(ref b_dt, "tinhthanh,tinhthanh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "quanhuyen,quanhuyen_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xaphuong,xaphuong_ten", "{");

            //bang.P_TIM_THEM(ref b_dt, "ns_ho_gdinh", "NS_HO_GDINH_TT", "tinhthanh");
            //bang.P_TIM_THEM(ref b_dt, "ns_ho_gdinh", "DT_QHUYEN", "quanhuyen");
            //bang.P_TIM_THEM(ref b_dt, "ns_ho_gdinh", "NS_HO_GDINH_XP", "xaphuong");

            bang.P_TIM_THEM(ref b_dt_qhe, "ns_ho_gdinh", "NS_HO_GDINH_GT", "gtinh");
            bang.P_TIM_THEM(ref b_dt_qhe, "ns_ho_gdinh", "NS_HO_GDINH_QHE", "qhe");
            bang.P_SO_CNG(ref b_dt_qhe, "ngaysinh");
            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_qhe) ? "" : bang.Fs_BANG_CH(b_dt_qhe, a_cot_lke_qhe)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HO_GDINH_NH(string b_login, object[] a_dt, object[] a_dt_qhe)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            // thông tin hộ gđ
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            // thông tin quan hệ
            string[] a_cot_qhe = chuyen.Fas_OBJ_STR((object[])a_dt_qhe[0]);
            object[] a_gtri_qhe = (object[])a_dt_qhe[1];
            DataTable b_dt_qhe;
            if (a_gtri_qhe == null)
                b_dt_qhe = bang.Fdt_TAO_BANG(a_cot_qhe, "SS");
            else
                b_dt_qhe = bang.Fdt_TAO_THEM(a_cot_qhe, a_gtri_qhe);
            bang.P_BO_HANG(ref b_dt_qhe, new string[] { "ten", "bhxh", "ngaysinh", "gtinh", "ncap_gks", "qhe", "cmt", "mota" }, new object[] { "", "", "", "", "", "", "", "" });

            if (b_dt_qhe.Rows.Count == 0) return "loi:Phải nhập dữ liệu trên lưới:loi";

            foreach (DataRow b_dr in b_dt_qhe.Rows)
            {
                if (b_dr["ten"].ToString().Trim() == "")
                    return "loi:Chưa nhập họ tên:loi";
                //else if (b_dr["bhxh"].ToString().Trim() == "")
                //    return "loi:Chưa nhập mã số bhxh:loi";
                else if (b_dr["ngaysinh"].ToString().Trim() == "")
                    return "loi:Chưa nhập ngày sinh:loi";
                else if (b_dr["gtinh"].ToString().Trim() == "")
                    return "loi:Chưa nhập giới tính:loi";
                else if (b_dr["ncap_gks"].ToString().Trim() == "")
                    return "loi:Chưa nhập nơi cấp giấy khai sinh:loi";
                else if (b_dr["qhe"].ToString().Trim() == "")
                    return "loi:Chưa nhập mối quan hệ với chủ hộ:loi";
                else if (b_dr["cmt"].ToString().Trim() == "")
                    return "loi:Chưa nhập số CMT/Thẻ căn cước/Hộ chiếu:loi";
                //else if (b_dr["mota"].ToString().Trim() == "")
                //    return "loi:Chưa nhập mô tả:loi";
                if (b_dr["bhxh"].ToString().Length != 10)
                    return "loi:Số BHXH nhập chưa đúng định dạng:loi";
            }
            bang.P_CNG_SO(ref b_dt_qhe, "ngaysinh");

            ns_tt.Fs_NS_HO_GDINH_NH(b_dt, b_dt_qhe);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HO_GDINH, TEN_BANG.NS_HO_GDINH);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HO_GDINH_XOA(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_tt.PNS_HO_GDINH_XOA(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HO_GDINH, TEN_BANG.NS_HO_GDINH);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THÔNG TIN HỘ GIA ĐÌNH

    #region Chon CBNV
    [WebMethod(true)]
    public string Fs_NS_CB_CHON_LKE(string b_phong, string b_trangthai, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_NS_CB_CHON_LKE(b_phong, b_trangthai, b_so_the, b_ten.ToUpper(), b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_ttr", "0", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_ttr", "1", "Nghỉ việc");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_CHON_CT(string b_so_the)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_CB_CHON_CT(b_so_the);
            DataTable b_dt_kq = b_ds.Tables[0];
            DataTable b_dt_ttt = b_ds.Tables[1];
            var b_dvi = b_dt_kq.Rows[0]["DONVI"].ToString();
            var b_phong = b_dt_kq.Rows[0]["phong_ban"].ToString();
            var b_ban = b_dt_kq.Rows[0]["ban"].ToString();
            bang.P_SO_CNG(ref b_dt_kq, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngay_bd_hopdong");

            string b_kq = (bang.Fb_TRANG(b_dt_kq)) ? "" : bang.Fs_HANG_GOP(b_dt_kq, 0);
            DataRow b_dr = b_dt_kq.Rows[0]; string b_iurl = chuyen.OBJ_S(b_dr["iurl"]);
            se.se_nsd b_nsd = new se.se_nsd();
            string b_anh;
            if (b_iurl != "" && b_iurl != null) b_anh = b_nsd.ma_dvi + "/" + b_iurl;
            else b_anh = b_iurl;
            return b_kq + "#" + b_anh + "#" + bang.Fs_BANG_CH(b_dt_ttt, "ma,nd");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion


}