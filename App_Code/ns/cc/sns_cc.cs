using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_cc : System.Web.Services.WebService
{

    #region BẢNG CHẤM CÔNG MÁY
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_LKE(string b_phong, string b_kyluong, string b_so_the, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cc.Fdt_NS_CC_TH_MAY_LKE(b_phong, b_tu, b_den, b_kyluong, b_so_the);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_CT(string b_phong, string b_kyluong_id, string b_so_the, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = ns_cc.Fdt_NS_CC_TH_MAY_CT(b_phong, b_kyluong_id, b_so_the, b_tu, b_den);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cc.Fdt_NS_CC_TH_MAY_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }




    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            ns_cc.P_NS_CC_TH_MAY_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_NS_CC_TH_MAY_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { ns_cc.P_NS_CC_TH_MAY_XOA(b_phong, b_thang); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            //double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = ns_cc.Fdt_NS_CC_TH_MAY_LKE_CB(b_phong, b_thang, 1, 30);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_MAY_TINH(string b_phong, string b_kyluong, string b_so_the, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            object[] a_object = ns_cc.Fdt_NS_CC_TH_MAY_TINH(b_phong, b_kyluong, b_so_the, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion "BẢNG CHẤM CÔNG MÁY"

    #region TỔNG HỢP CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_TH_LKE_COT()
    {
        try
        {
            DataTable b_dt = ns_cc.Fdt_NS_CC_TH_LKE_COT();
            string a = "SO_THE_CB|Mã nhân viên;TEN|Tên nhân viên;PHONG|Phòng ban;" + bang.Fs_BANG_CH(b_dt);
            return a;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_KYLUONG_LKE(int b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_th", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "so_id,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_TH_LKE(string b_phong, double b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);

            object[] a_dt = ns_cc.Fdt_NS_CC_TH_LKE(b_phong, b_kyluong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_dt[1];
            //bang.P_SO_CNG(ref b_dt, "NGAYD,NGAYC");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);

            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong.ToString());


            return b_kq + "#" + a_dt[0] + "#" + tt;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }


    [WebMethod(true)]
    public string Fs_NS_CC_TH_TINH(string b_phong, string b_kyluong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_dt = ns_cc.Fdt_NS_CC_TH_TINH(b_phong, chuyen.OBJ_N(b_kyluong), b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_dt[1];

            var tt = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG(b_phong, b_kyluong);
            if (tt == "1")
            {
                return Thongbao_dch.KY_CONG_KHOA;
            }
            bang.P_SO_CNG(ref b_dt, "NGAYD,NGAYC");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : a_dt[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }

    #endregion

    #region THIẾT LẬP CÔNG THỨC CÔNG

    [WebMethod(true)]
    public void P_NS_CC_CT_CONG_DOITUONG_XEM(string b_login, string b_form, string b_ma_dvi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_tl.Fdt_NS_TL_MA_NL_XEM(b_ma_dvi);
            se.P_TG_LUU(b_form, "DT_DT", b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_CC_CT_CONG_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_cc.Fdt_NS_CC_CT_CONG_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CT_CONG_LKE(string b_login, string b_ma_dvi, string b_dtuong, double b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cc.Fdt_NS_CC_CT_CONG_LKE(b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return a_object[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CT_CONG_LKE_DV(string b_login, string b_ma_dvi, string b_dtuong, double b_loai, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cc.Fdt_NS_CC_CT_CONG_LKE_DV(b_ma_dvi, b_dtuong, b_loai, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return a_object[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TL_CC_CONG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_cc.Fdt_Fs_TL_CC_CONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CT_CONG_NH(double b_so_id, object[] a_dt_ct)
    {
        try
        {
            if (b_so_id <= 0)
            {
                return Thongbao_dch.ChonCongThuc;
            }
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_cc.P_NS_CC_CT_CONG_NH(b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_CC_CT_CONG, TEN_BANG.NS_CC_CT_CONG);
            return Thongbao_dch.CapnhatThanhcong;
        }
        catch (Exception ex) { return Thongbao_dch.ThaoTac_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CT_CONG_KT(string b_login, double b_loai, string b_cotct, string b_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_cc.P_NS_CC_CT_CONG_KT(b_loai, b_cotct, b_ct);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.Saicuphap; }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CONG_CT(string b_ct, object[] a_dt_ct)
    {
        try
        {
            var kq = "";
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["chon"].Equals("X"))
                {
                    if (kq == "")
                    {
                        kq = "NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                    else
                    {
                        kq = kq + " + NVL(" + b_dt_ct.Rows[i]["macl"].ToString() + ",0)";
                    }
                }
            }
            return "#" + kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TL_CC_CONG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_cc.P_Fs_TL_CC_CONG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_CC_CT_CONG, TEN_BANG.NS_CC_CT_CONG);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion THIẾT LẬP CÔNG THỨC CÔNG

    #region NGHỈ PHÉP THEO CHỨC DANH

    [WebMethod(true)]
    public string Fs_NS_CC_CD_PHEP_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_cc.Fobj_NS_CC_CD_PHEP_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            //bang.P_TIM_THEM(ref b_dt, "ns_cc_cd_phep", "NS_CC_CD_PHEP_NNN", "MA_NNN");
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CD_PHEP_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_cc.Fobj_NS_CC_CD_PHEP_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CD_PHEP_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_cc.Fds_NS_CC_CD_PHEP_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
              b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CD_PHEP_NH(string b_login, double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_bd,ngay_kt"); bang.P_CSO_SO(ref b_dt, "phep,phep_nn");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ma_cdanh", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_BO_HANG(ref b_dt_ct, "ma_cdanh", "");
            ns_cc.P_NS_CC_CD_PHEP_NH(ref b_so_id, b_dt, b_dt_ct);
            return Fs_NS_CC_CD_PHEP_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
            //return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CD_PHEP_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_cc.P_NS_CC_CD_PHEP_XOA(b_so_id);
            return Fs_NS_CC_CD_PHEP_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion NGHỈ PHÉP THEO CHỨC DANH

    #region XEM THÔNG TIN BẢNG CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_TT_BANG_CONG_LKE_COT(string b_login)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = tl_cc.Fdt_NS_CC_TH_LKE_COT();
            string a_cot = "SOTT|STT;SO_THE_CB|Mã nhân viên;TEN|Tên nhân viên;PHONG|Phòng ban;CDANH|Chức danh;" + bang.Fs_BANG_CH(b_dt);
            return a_cot;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    //public string Fs_NS_CC_TT_BANG_LUONG_KYLUONG_LKE(string b_login, int b_nam)
    //{
    //    try
    //    {
    //        if (b_login != null) se.P_LOGIN(b_login);
    //        DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
    //        DataTable b_dt_ky = b_dt.Copy();
    //        bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
    //        se.P_TG_LUU("ns_cc_tt_bang_cong", "DT_KY", b_dt_ky.Copy());
    //        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    public string Fs_NS_CC_TT_BANG_LUONG_KYLUONG_LKE(string b_login, double b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
            DataTable b_dt_ky = b_dt.Copy();
            bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
            se.P_TG_LUU("ns_cc_tt_bang_cong", "DT_KY", b_dt_ky.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion XEM THÔNG TIN BẢNG CÔNG
}