using System;
using System.Data;
using System.Web.Services;
using Cthuvien;
[System.Web.Script.Services.ScriptService]
public class sht_ma : WebService
{
    #region MA_DVI
    [WebMethod(true)]
    public string Fs_MA_DVI_CD(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_CD();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_NB(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_NB();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_NG(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_NG();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_MA(string b_login, string b_form, string b_ma, string b_gt, int b_trangKT, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_ma_ct = "," + ht_madvi.Fs_DVI_QLY(b_ma), b_dk = "M";
            string[] a_ma_ct = b_ma_ct.Split(','), a_s = { };
            object[] a_obj = { };
            if (b_ma_ct == ",")
            {
                Fs_MA_DVI_LKE(b_login, b_form, b_dk, "", b_gt, a_s, a_obj);
                b_dk = "+";
            }
            else
            {
                for (int i = 0; i < a_ma_ct.Length; i++)
                {
                    Fs_MA_DVI_LKE(b_login, b_form, b_dk, a_ma_ct[i], b_gt, a_s, a_obj);
                    b_dk = "+";
                }
            }
            return khac.Fs_SLIDE_VTRI(b_form, "DT_LKE", "ma", b_ma, b_trangKT, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_LKE(string b_login, string b_form, string b_dk, string b_ma, string b_gt, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt;
            if ("+MT".Contains(b_dk))
            {
                b_dt = ht_madvi.Fdt_MA_DVI_LKE_CAY(b_ma, b_gt);
                if (!bang.Fb_TRANG(b_dt))
                {
                    khac.P_GCAY_DAU(ref b_dt);
                    if (b_dk == "M")
                        se.P_TG_LUU(b_form, "DT_LKE", b_dt);
                    else
                    {
                        DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_LKE");
                        string b_ng = khac.Fs_GCAY_NG(b_ma, "-", b_dtC);
                        if (b_ng != "")
                        {
                            string[] a_ng = b_ng.Split(',');
                            for (int i = 0; i < a_ng.Length; i++)
                            {
                                khac.P_GCAY_THU(a_ng[i], ref b_dtC); khac.P_GCAY_TTR(b_ng, "+", ref b_dtC);
                            }
                        }
                        int b_vtri = bang.Fi_TIM_ROW(b_dtC, "ma", b_ma);
                        khac.P_GCAY_TTR(b_ma, "-", ref b_dtC);
                        bang.P_THEM_HANG(ref b_dtC, b_dt, b_vtri + 1);
                        se.P_TG_LUU(b_form, "DT_LKE", b_dtC);
                    }
                }
                else se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            }
            else if (b_dk == "-")
            {
                b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
                khac.P_GCAY_THU(b_ma, ref b_dt); khac.P_GCAY_TTR(b_ma, "+", ref b_dt);
                se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            }
            string b_kq = (a_cot.Length > 1) ? khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso) : "";
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_CT(string b_login, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_CT(b_ma);
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_tl", "ngay_gt" });
            bang.P_BO_COT(ref b_dt, "ma,ma_ct"); bang.P_DOI_TENCOL(ref b_dt, "ma_goc,ma_ct_goc", "ma,ma_ct");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_NH(string b_login, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ht_madvi.P_MA_DVI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HT_MADVI, TEN_BANG.HT_MADVI);
            return "";
            //DataTable b_dt = ht_madvi.Fdt_MA_DVI_LKE_CAY("");
            //return bang.Fs_BANG_CH(b_dt, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_XOA(string b_login, string b_ma, string b_gt, object[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ht_madvi.P_MA_DVI_XOA(b_ma);
            string b_thongbao = "";

            double b_tontai_kdt = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_CB, ht_dungchung.MA_DVI, b_ma, ref b_thongbao);
            if (b_tontai_kdt > 0)
            {
                return "loi:Đơn vị này đã được sử dụng, không thể xóa:loi";
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HT_MADVI, TEN_BANG.HT_MADVI);
            return Fs_MA_DVI_LKE(b_login, "ht_madvi", "M", "", b_gt, a_cot, a_tso);
        }
        // }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_DVI

    #region MA_PH
    [WebMethod(true)]
    public string Fs_MA_PH_DVI(string b_login, string b_dvi, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); DataTable b_dt = ht_maph.Fdt_MA_PH_DVI(b_dvi);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_MA(string b_login, string b_form, string b_ma, string b_gt, int b_trangKT, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            object[] a_object = ns_tt.Fdt_MA_CCTC_MA(b_ma, b_gt, b_trangKT);

            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_LKE(string b_login, string b_form, string b_dk, string b_ma, string b_gt, string[] a_cot, object[] a_tso)
    {
        DataTable b_dt = new DataTable();
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_tt.Fdt_MA_CCTC_LKE(b_gt, b_tu_n, b_den_n);
            b_dt = (DataTable)a_object[1];
            if ("+MT".Contains(b_dk))
            {
                // b_dt = ht_maph.Fdt_MA_PH_LKE_CAY(b_ma, b_gt);

                //if (!bang.Fb_TRANG(b_dt))
                //{
                //    khac.P_GCAY_DAU(ref b_dt);
                //    if (b_dk == "M")
                //        se.P_TG_LUU(b_form, "DT_LKE", b_dt);
                //    else
                //    {
                //        DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_LKE");
                //        string b_ng = khac.Fs_GCAY_NG(b_ma, "-", b_dtC);
                //        if (b_ng != "")
                //        {
                //            string[] a_ng = b_ng.Split(',');
                //            for (int i = 0; i < a_ng.Length; i++)
                //            {
                //                khac.P_GCAY_THU(a_ng[i], ref b_dtC); khac.P_GCAY_TTR(b_ng, "+", ref b_dtC);
                //            }
                //        }
                //        int b_vtri = bang.Fi_TIM_ROW(b_dtC, "ma", b_ma);
                //        khac.P_GCAY_TTR(b_ma, "-", ref b_dtC);
                //        bang.P_THEM_HANG(ref b_dtC, b_dt, b_vtri + 1);
                //        se.P_TG_LUU(b_form, "DT_LKE", b_dtC);
                //    }
                //}
            }
            else if (b_dk == "-")
            {
                //b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
                //khac.P_GCAY_THU(b_ma, ref b_dt); khac.P_GCAY_TTR(b_ma, "+", ref b_dt);
                //se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            }
            //string b_kq = (a_cot.Length > 1) ? khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso) : "";
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_LKE_QUYEN(string b_login, string b_form, string b_dk, string b_ma, string b_gt, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt;
            if ("+MT".Contains(b_dk))
            {
                b_dt = ht_maph.Fdt_MA_PH_LKE_CAY(b_ma, b_gt);
                if (!bang.Fb_TRANG(b_dt))
                {
                    khac.P_GCAY_DAU(ref b_dt);
                    if (b_dk == "M")
                        se.P_TG_LUU(b_form, "DT_LKE", b_dt);
                    else
                    {
                        DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_LKE");
                        string b_ng = khac.Fs_GCAY_NG(b_ma, "-", b_dtC);
                        if (b_ng != "")
                        {
                            string[] a_ng = b_ng.Split(',');
                            for (int i = 0; i < a_ng.Length; i++)
                            {
                                khac.P_GCAY_THU(a_ng[i], ref b_dtC); khac.P_GCAY_TTR(b_ng, "+", ref b_dtC);
                            }
                        }
                        int b_vtri = bang.Fi_TIM_ROW(b_dtC, "ma", b_ma);
                        khac.P_GCAY_TTR(b_ma, "-", ref b_dtC);
                        bang.P_THEM_HANG(ref b_dtC, b_dt, b_vtri + 1);
                        se.P_TG_LUU(b_form, "DT_LKE", b_dtC);
                    }
                }
            }
            else if (b_dk == "-")
            {
                b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
                khac.P_GCAY_THU(b_ma, ref b_dt); khac.P_GCAY_TTR(b_ma, "+", ref b_dt);
                se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            }
            string b_kq = (a_cot.Length > 1) ? khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso) : "";
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_MA_PH_LKE3(string b_login, string b_tim, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_tim != "") b_tim = "N'%" + b_tim.ToUpper() + "%";
            DataTable b_dt = ht_maph.Fdt_MA_PH_LKE3(b_tim);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_LKE5(string b_login, string b_tim, string b_ma_dvi, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_tim != "") b_tim = "N'%" + b_tim.ToUpper() + "%";
            DataTable b_dt = ht_maph.Fdt_MA_PH_LKE5(b_tim, b_ma_dvi);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_NH(string b_login, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_so_id = ht_maph.P_MA_PH_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HT_MAPH, TEN_BANG.HT_MAPH);
            return b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_GT(string b_login, string b_ma, string b_ngay_gt, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HT_MAPH, TEN_BANG.HT_MAPH);
            return ht_maph.P_MA_PH_GT(b_ma, b_ngay_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_CT(string b_login, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_maph.Fdt_MA_PH_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, "ht_maph", "DT_VUNG", "vung_mien");
            bang.P_TIM_THEM(ref b_dt, "ht_maph", "DT_KHOI", "khoi");
            bang.P_TIM_THEM(ref b_dt, "ht_maph", "DT_MAPB", "ma_pb");
            bang.P_SO_CNG(ref b_dt, "ngay_tl,ngay_gt");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_PH_XOA(string b_login, string b_ma, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HT_MAPH, TEN_BANG.HT_MAPH);
            ht_maph.P_MA_PH_XOA(b_ma);
            return Fs_MA_PH_LKE(b_login, "ht_maph", "M", "", "", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_PH

    #region MA_CVU
    [WebMethod(true)]
    public string Fs_MA_CVU_LKE(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_macvu.Fdt_MA_CVU_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CVU_NH(string b_login, object[] a_dt_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ht_macvu.P_MA_CVU_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CVU_XOA(string b_login, string b_ma)
    {
        try { se.P_LOGIN(b_login); ht_macvu.P_MA_CVU_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_CVU

    #region MA_CB
    [WebMethod(true)]
    public string Fs_MA_CB_LKE(string b_login, string b_tim, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_tim != "") b_tim = "N'%" + b_tim.ToUpper() + "%";
            object[] a_obj = ht_macb.Faobj_MA_CB_LKE(b_tim, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CB_MA(string b_login, string b_phong, string b_ma, double b_TrangKt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_macb.Faobj_MA_CB_MA(b_phong, b_ma, b_TrangKt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CB_CT(string b_login, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_macb.Fdt_MA_CB_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CB_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ht_macb.P_MA_CB_NH(b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_MA_CB_MA(b_login, b_phong, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CB_XOA(string b_login, string b_ma, string b_tim, string[] a_cot, double[] a_tso)
    {
        try { se.P_LOGIN(b_login); ht_macb.P_MA_CB_XOA(b_ma); return Fs_MA_CB_LKE(b_login, b_tim, a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_CB_FILE(string b_login)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            if (b_dt == null) return "";
            bang.P_DON(ref b_dt);
            if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:File trắng:loi");
            ht_macb.P_FILE(b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_CB

    #region MA_NHOM
    [WebMethod(true)]
    public string Fs_MA_NHOM_LKE(string b_login, string b_loai, string b_ma_tk, string b_ten_tk, string b_phanhe, string b_ten_from, string[] a_cot_nv, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt_lke = ht_manhom.Fdt_MA_NHOM_LKE(b_loai, b_ma_tk, b_ten_tk);

            object[] a_obj = ht_mansd.Fdt_MA_NSD_TS(Server.MapPath("~/App_form/ht/ht_mansd.xls"), b_phanhe, b_ten_from, b_tu, b_den);

            DataTable b_dt_nv = ((DataTable)a_obj[1]).Copy();
            bang.P_THEM_COL(ref b_dt_nv, new string[] { "ghi", "xem", "xoa", "pd", "in", "mo_cpd", "active", "export" }, new string[] { "K", "K", "K", "K", "K", "K", "K", "K" });


            bang.P_BO_HANG(ref b_dt_nv, "md", "HT"); bang.P_DICH(ref b_dt_nv, "ten");
            return a_obj[0] + "#" + bang.Fs_BANG_CH(b_dt_nv, a_cot_nv) + "#" + bang.Fs_BANG_CH(b_dt_lke, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NHOM_CT(string b_login, string b_ma, string b_phanhe, string b_ten_form, string[] a_cot_nv, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt_ct, b_dt_tc;
            object[] a_obj = ht_mansd.Fdt_MA_NSD_TS(Server.MapPath("~/App_form/ht/ht_mansd.xls"), b_phanhe, b_ten_form, b_tu, b_den);
            DataTable b_dt_nv = ((DataTable)a_obj[1]).Copy();
            bang.P_THEM_COL(ref b_dt_nv, new string[] { "ghi", "xem", "xoa", "pd", "in", "mo_cpd", "active", "export" }, new string[] { "K", "K", "K", "K", "K", "K", "K", "K" });

            ht_manhom.P_MA_NHOM_CT(b_ma, out b_dt_ct, out b_dt_tc);
            string b_kq = "";
            bang.P_BO_HANG(ref b_dt_nv, "md", "HT");

            string b_tc; int b_hang;
            foreach (DataRow b_dr in b_dt_nv.Rows)
            {
                b_hang = bang.Fi_TIM_ROW(b_dt_tc, "nv", chuyen.OBJ_S(b_dr["nv"])); b_tc = "";
                if (b_hang != -1) b_tc = chuyen.OBJ_S(b_dt_tc.Rows[b_hang]["tc"]);
                if (b_tc != "")
                {
                    b_dr["ghi"] = b_tc.Contains("G") ? "C" : "K";
                    b_dr["xem"] = b_tc.Contains("X") ? "C" : "K";
                    b_dr["xoa"] = b_tc.Contains("D") ? "C" : "K";
                    b_dr["pd"] = b_tc.Contains("P") ? "C" : "K";
                    b_dr["in"] = b_tc.Contains("I") ? "C" : "K";
                    b_dr["mo_cpd"] = b_tc.Contains("M") ? "C" : "K";
                    b_dr["active"] = b_tc.Contains("A") ? "C" : "K";
                    b_dr["export"] = b_tc.Contains("E") ? "C" : "K";
                }
            }

            b_kq = b_dt_ct.Rows.Count + "#" + bang.Fs_HANG_GOP(b_dt_ct, 0) + "#" + bang.Fs_BANG_CH(b_dt_nv, a_cot_nv) + "#" + a_obj[0];
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NHOM_NH(string b_login, string b_ma_tk, string b_ten_tk, object[] a_dt_ct, object[] a_dt_nv, string b_loai, string[] a_cot, double b_trangKT)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_nv = chuyen.Fas_OBJ_STR((object[])a_dt_nv[0]); object[] a_gtri_nv = (object[])a_dt_nv[1];
            string b_tc;
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct), b_dt_nv = bang.Fdt_TAO_THEM(a_cot_nv, a_gtri_nv);
            bang.P_DON(ref b_dt_nv); bang.P_THEM_COL(ref b_dt_nv, "tc", "");
            foreach (DataRow b_dr in b_dt_nv.Rows)
            {
                b_tc = "";
                if (chuyen.OBJ_S(b_dr["ghi"]) == "C") b_tc = "G";
                if (chuyen.OBJ_S(b_dr["xem"]) == "C") b_tc = b_tc + "X";
                if (chuyen.OBJ_S(b_dr["xoa"]) == "C") b_tc = b_tc + "D";
                if (chuyen.OBJ_S(b_dr["pd"]) == "C") b_tc = b_tc + "P";
                if (chuyen.OBJ_S(b_dr["in"]) == "C") b_tc = b_tc + "I";
                if (chuyen.OBJ_S(b_dr["mo_cpd"]) == "C") b_tc = b_tc + "M";
                if (chuyen.OBJ_S(b_dr["active"]) == "C") b_tc = b_tc + "A";
                if (chuyen.OBJ_S(b_dr["export"]) == "C") b_tc = b_tc + "E";
                b_dr["tc"] = b_tc;
            }
            ht_manhom.P_MA_NHOM_NH(b_dt_ct, b_dt_nv, b_loai);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HT_MANHOM, TEN_BANG.HT_MANHOM);
            var b_ma = b_dt_ct.Rows[0]["MA"].ToString();
            return Fs_NS_MA_NHOM_MA(b_ma, b_ma_tk, b_ten_tk, b_trangKT, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_NHOM_MA(string b_ma, string b_ma_tk, string b_ten_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ht_manhom.Fdt_MA_NHOM_MA(b_ma, b_ma_tk, b_ten_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NHOM_XOA(string b_login, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HT_MANHOM, TEN_BANG.HT_MANHOM);
            ht_manhom.P_MA_NHOM_XOA(b_ma); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_NHOM

    #region MA_NSD
    [WebMethod(true)]
    public string Fs_LOGIN(string b_md, string b_nsd, string b_pas, string b_duyet, string b_tm)
    {
        try
        {
            b_pas = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(b_pas.Trim(), "SHA1");
            se.P_LOGIN(b_md, b_nsd, b_pas, b_duyet, b_tm);
            // Lưu lịch sử đăng nhập
            //ht_macb.PHT_LICHSU_DANGNHAP_NH();
            //ht_macb.PHT_DS_USER_ONLINE_NH("1");
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_MA_LOGIN(string b_login, string b_dvi, string b_ma, string b_ma_login, string b_dk)
    {
        try { se.P_LOGIN(b_login); ht_mansd.P_MA_NSD_MA_LOGIN(b_dvi, b_ma, b_ma_login); return (b_dk == "C") ? "loi:Mã login OK:loi" : ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_LKE(string b_login, string b_ma_tk, string b_ten_tk, string b_dvi, string b_klk, string b_dk, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ht_mansd.Faobj_MA_NSD_LKE(b_ma_tk, b_ten_tk, b_dvi, b_klk, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt, "QU", "C", "Đang hoạt động");
            bang.P_THAY_GTRI(ref b_dt, "QU", "K", "Đang hoạt động");
            bang.P_THAY_GTRI(ref b_dt, "QU", "N", "Ngừng hoạt động");
            string b_kq = chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            if (b_dk == "C")
            {
                b_dt = ht_maph.Fdt_MA_PH_DVI(b_dvi);
                se.P_TG_LUU("ht_mansd", "DT_PHONG", b_dt);
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_TAO(string b_login, string b_ma, string b_loai, string b_phanhe, string b_ten_form, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ht_mansd.Fdt_MA_NSD_QUYEN(Server.MapPath("~/App_form/ht/ht_mansd.xls"), b_ma, b_phanhe, b_ten_form, b_tu, b_den);
            DataTable b_dt_nv = (DataTable)a_obj[1], b_dt_nh = ht_manhom.Fdt_MA_NHOM_LKE(b_loai, "", "");
            bang.P_THEM_COL(ref b_dt_nv, new string[] { "ghi", "xem", "xoa", "pd", "in", "mo_cpd", "active", "export" }, new string[] { "K", "K", "K", "K", "K", "K", "K", "K" });
            bang.P_DOI_TENCOL(ref b_dt_nh, "ma", "NHOM"); bang.P_THEM_COL(ref b_dt_nh, "CHON", "");
            bang.P_DICH(ref b_dt_nv, "ten");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_nv, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_nh, "CHON,ten,NHOM");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_MA(string b_login, string b_dvi, string b_klk, string b_ma, string b_dk, double b_TrangKt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_mansd.Faobj_MA_NSD_MA(b_dvi, b_klk, b_ma, b_TrangKt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "QU", "C", "Đang hoạt động");
            bang.P_THAY_GTRI(ref b_dt, "QU", "K", "Đang hoạt động");
            bang.P_THAY_GTRI(ref b_dt, "QU", "N", "Ngừng hoạt động");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dk;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_QLY(string b_login, string b_dvi, string b_ma, string b_md)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ht_mansd.Fdt_MA_NSD_QLY(b_dvi, b_ma, b_md);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_CT(string b_login, string b_dvi, string b_ma, string b_loai_sl, string b_phanhe, string b_ten_form, string[] a_cot_nv, string[] a_cot_bc, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt_ct, b_dt_dvi, b_dt_nhom, b_dt_tc;
            string b_dong = "0";
            object[] a_obj = ht_mansd.Fdt_MA_NSD_QUYEN(Server.MapPath("~/App_form/ht/ht_mansd.xls"), b_ma, b_phanhe, b_ten_form, b_tu, b_den);
            DataTable b_dt_nv = (DataTable)a_obj[1];
            //bang.P_DON(ref b_dt_nv);
            bang.P_THEM_COL(ref b_dt_nv, new string[] { "ghi", "xem", "xoa", "pd", "in", "mo_cpd", "active", "export" }, new string[] { "K", "K", "K", "K", "K", "K", "K", "K" });

            ht_mansd.P_MA_NSD_CT(b_dvi, b_ma, b_phanhe, b_ten_form, out b_dt_ct, out b_dt_tc, out b_dt_nhom, out b_dt_dvi, out b_dong, b_tu, b_den);
            string b_kq = "";
            if (!bang.Fb_TRANG(b_dt_ct))
            {
                string b_tc; int b_hang;
                foreach (DataRow b_dr in b_dt_nv.Rows)
                {
                    b_hang = bang.Fi_TIM_ROW(b_dt_tc, "nv", chuyen.OBJ_S(b_dr["nv"])); b_tc = "";
                    if (b_hang != -1) b_tc = chuyen.OBJ_S(b_dt_tc.Rows[b_hang]["tc"]);
                    if (b_tc != "")
                    {
                        b_dr["ghi"] = b_tc.Contains("G") ? "C" : "K";
                        b_dr["xem"] = b_tc.Contains("X") ? "C" : "K";
                        b_dr["xoa"] = b_tc.Contains("D") ? "C" : "K";
                        b_dr["pd"] = b_tc.Contains("P") ? "C" : "K";
                        b_dr["in"] = b_tc.Contains("I") ? "C" : "K";
                        b_dr["mo_cpd"] = b_tc.Contains("M") ? "C" : "K";
                        b_dr["active"] = b_tc.Contains("A") ? "C" : "K";
                        b_dr["export"] = b_tc.Contains("E") ? "C" : "K";
                    }
                }
            }
            b_kq = b_dt_ct.Rows.Count + "#" + bang.Fs_HANG_GOP(b_dt_ct, 0) + "#" + bang.Fs_BANG_CH(b_dt_nv, a_cot_nv)
                + "#" + bang.Fs_BANG_CH(b_dt_nhom, "CHON,NHOM") + "#" + bang.Fs_BANG_CH(b_dt_dvi, "dvi_chon,ten,DVI")
                + "#" + Fs_MA_NSD_BC(b_login, b_dvi, b_ma, b_loai_sl, a_cot_bc)
                + "#" + b_dong;
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_MA_NSD_BC(string b_login, string b_dvi, string b_ma, string b_loai_sl, string[] a_cot_bc)
    {
        try
        {
            se.P_LOGIN(b_login);
            // lấy các báo cáo đã được phân quyền trước
            DataTable b_dt_bc;
            int b_dong;
            ht_mansd.P_MA_NSD_BC(b_dvi, b_ma, b_loai_sl, 1, Int32.MaxValue, out b_dt_bc, out b_dong);
            // lấy thêm các báo cáo ở file ngbc
            DataTable b_dt_excel = bc.Fdt_GRID_BC_EXCEL("~/App_form/bc/ns/", "ns_ngbc", b_loai_sl);

            bang.P_GOM_BANG(ref b_dt_bc, b_dt_excel, "MA_BC");
            string b_kq = bang.Fs_HANG_GOP(b_dt_bc, 0) + "#" + bang.Fs_BANG_CH(b_dt_bc, a_cot_bc);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_MA_NSD_NH(string b_login, object[] a_dt_ct, object[] a_dt_nv, object[] a_dt_nhom, object[] a_dt_dvi, object[] a_dt_bc)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_nv = chuyen.Fas_OBJ_STR((object[])a_dt_nv[0]); object[] a_gtri_nv = (object[])a_dt_nv[1];
            string[] a_cot_dvi = chuyen.Fas_OBJ_STR((object[])a_dt_dvi[0]); object[] a_gtri_dvi = (object[])a_dt_dvi[1];
            string[] a_cot_nhom = chuyen.Fas_OBJ_STR((object[])a_dt_nhom[0]); object[] a_gtri_nhom = (object[])a_dt_nhom[1];
            string[] a_cot_bc = chuyen.Fas_OBJ_STR((object[])a_dt_bc[0]); object[] a_gtri_bc = (object[])a_dt_bc[1];

            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct), b_dt_nv = bang.Fdt_TAO_THEM(a_cot_nv, a_gtri_nv),
                b_dt_dvi = (a_gtri_dvi == null) ? b_dt_dvi = bang.Fdt_TAO_BANG("dvi", "S") : bang.Fdt_TAO_THEM(a_cot_dvi, a_gtri_dvi),
                b_dt_nhom = (a_gtri_nhom == null) ? b_dt_nhom = bang.Fdt_TAO_BANG("nhom", "S") : bang.Fdt_TAO_THEM(a_cot_nhom, a_gtri_nhom),
                b_dt_bc = (a_gtri_bc == null) ? b_dt_bc = bang.Fdt_TAO_BANG(new string[] { "LOAI", "CHON", "TEN", "MA_BC" }, new string[] { "S", "S", "S", "S" }) : bang.Fdt_TAO_THEM(a_cot_bc, a_gtri_bc);
            bang.P_DON(ref b_dt_dvi); bang.P_DON(ref b_dt_nhom);
            bang.P_CH_BLANK(ref b_dt_ct, "phong"); bang.P_THEM_COL(ref b_dt_nv, "tc", "");
            bang.P_CH_BLANK(ref b_dt_bc, "ma_bc");
            bang.P_BO_HANG(ref b_dt_dvi, "dvi_chon", "");
            bang.P_BO_HANG(ref b_dt_nv, "ten", "");
            string b_tc;
            foreach (DataRow b_dr in b_dt_nv.Rows)
            {
                b_tc = "";
                if (chuyen.OBJ_S(b_dr["ghi"]) == "C") b_tc = "G";
                if (chuyen.OBJ_S(b_dr["xem"]) == "C") b_tc = b_tc + "X";
                if (chuyen.OBJ_S(b_dr["xoa"]) == "C") b_tc = b_tc + "D";
                if (chuyen.OBJ_S(b_dr["pd"]) == "C") b_tc = b_tc + "P";
                if (chuyen.OBJ_S(b_dr["in"]) == "C") b_tc = b_tc + "I";
                if (chuyen.OBJ_S(b_dr["mo_cpd"]) == "C") b_tc = b_tc + "M";
                if (chuyen.OBJ_S(b_dr["active"]) == "C") b_tc = b_tc + "A";
                if (chuyen.OBJ_S(b_dr["export"]) == "C") b_tc = b_tc + "E";
                b_dr["tc"] = b_tc;
            }
            b_dt_nv.AcceptChanges();
            ht_mansd.P_MA_NSD_NH(b_dt_ct, b_dt_nv, b_dt_nhom, b_dt_dvi, b_dt_bc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HT_MANSD, TEN_BANG.HT_MANSD);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_MA_NSD_XOA(string b_login, string b_ma_tk, string b_ten_tk, string b_dvi, string b_ma, string b_klk, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login); ht_mansd.P_MA_NSD_XOA(b_dvi, b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HT_MANSD, TEN_BANG.HT_MANSD);
            return Fs_MA_NSD_LKE(b_login, b_ma_tk, b_ten_tk, b_dvi, b_klk, "K", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_NSD_FILE(string b_login, string b_dvi)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            if (b_dt == null) return "";
            bang.P_DON(ref b_dt);
            if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:File trắng:loi");
            if (bang.Fi_TIM_COL(b_dt, "pas") < 0) bang.P_THEM_COL(ref b_dt, "pas", "123456");
            else bang.P_CH_BLANK(ref b_dt, "pas");
            ht_mansd.P_FILE(b_dvi, b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_NSD

    #region ĐỔI ĐƠN VỊ LOGIN
    [WebMethod(true)]
    public string Fs_LOGIN_DVI(string b_md, string b_duyet, string b_tm, string b_dvi)
    {
        try
        {
            // lấy user được map với đơn vị quản lý
            DataTable b_dt = ht_mansd.Fdt_MA_NSD_MAP_KTRA(b_dvi);
            string b_nsd_dvi = "";
            se.se_nsd b_se = new se.se_nsd();
            string b_nsd = b_se.nsd, b_pas = b_se.pas;
            if (b_dt.Rows.Count > 0) b_nsd_dvi = b_dt.Rows[0]["MA_LOGIN_MAP"].ToString();
            se.P_LOGIN(b_md, b_nsd_dvi, b_pas, b_duyet, b_tm);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion: ĐỔI ĐƠN VỊ LOGIN

    #region Quyền
    [WebMethod(true)]
    public string Fs_NS_CCTC_QUYEN_LKE(string b_login, string b_form, string b_dk, string b_ma, string b_gt, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt;
            if ("+MT".Contains(b_dk))
            {
                b_dt = ht_maph.Fdt_NS_HS_CCTC_CAY(b_ma, b_gt);
                if (!bang.Fb_TRANG(b_dt))
                {
                    khac.P_GCAY_DAU(ref b_dt);
                    if (b_dk == "M")
                        se.P_TG_LUU(b_form, "DT_LKE", b_dt);
                    else
                    {
                        DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_LKE");
                        string b_ng = khac.Fs_GCAY_NG(b_ma, "-", b_dtC);
                        if (b_ng != "")
                        {
                            string[] a_ng = b_ng.Split(',');
                            for (int i = 0; i < a_ng.Length; i++)
                            {
                                khac.P_GCAY_THU(a_ng[i], ref b_dtC); khac.P_GCAY_TTR(b_ng, "+", ref b_dtC);
                            }
                        }
                        int b_vtri = bang.Fi_TIM_ROW(b_dtC, "ma", b_ma);
                        khac.P_GCAY_TTR(b_ma, "-", ref b_dtC);
                        bang.P_THEM_HANG(ref b_dtC, b_dt, b_vtri + 1);
                        se.P_TG_LUU(b_form, "DT_LKE", b_dtC);
                    }
                }
            }
            else if (b_dk == "-")
            {
                b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
                khac.P_GCAY_THU(b_ma, ref b_dt); khac.P_GCAY_TTR(b_ma, "+", ref b_dt);
                se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            }
            string b_kq = (a_cot.Length > 1) ? khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso) : "";
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_MA_CCDV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "nam,kyluong,cong_chuan");
            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong_dvi;
            }
            b_so_id = ht_maph.P_NS_CC_MA_CCDV_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_CC_MA_CCDV, TEN_BANG.NS_CC_MA_CCDV);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CCTC_QUYEN_LKE_CONGCHUAN(string b_login, string b_form, string b_dk, string b_nam, string b_kyluong, string b_ma, string b_gt, string[] a_cot, object[] a_tso)
    {
        try
        {
            DataTable b_dt = new DataTable();
            se.P_LOGIN(b_login);
            b_dt = ht_maph.Fdt_NS_HS_CCTC_CAY_CONGCHUAN(b_nam, b_kyluong, b_ma, b_gt);
            return b_dt.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt, a_cot);

            //se.P_LOGIN(b_login);
            //DataTable b_dt;
            //if ("+MT".Contains(b_dk))
            //{
            //    b_dt = ht_maph.Fdt_NS_HS_CCTC_CAY_CONGCHUAN(b_nam, b_kyluong, b_ma, b_gt);
            //    if (!bang.Fb_TRANG(b_dt))
            //    {
            //        khac.P_GCAY_DAU(ref b_dt);
            //        if (b_dk == "M")
            //            se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            //        else
            //        {
            //            DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_LKE");
            //            string b_ng = khac.Fs_GCAY_NG(b_ma, "-", b_dtC);
            //            if (b_ng != "")
            //            {
            //                string[] a_ng = b_ng.Split(',');
            //                for (int i = 0; i < a_ng.Length; i++)
            //                {
            //                    khac.P_GCAY_THU(a_ng[i], ref b_dtC); khac.P_GCAY_TTR(b_ng, "+", ref b_dtC);
            //                }
            //            }
            //            int b_vtri = bang.Fi_TIM_ROW(b_dtC, "ma", b_ma);
            //            khac.P_GCAY_TTR(b_ma, "-", ref b_dtC);
            //            bang.P_THEM_HANG(ref b_dtC, b_dt, b_vtri + 1);
            //            se.P_TG_LUU(b_form, "DT_LKE", b_dtC);
            //        }
            //    }
            //}
            //else if (b_dk == "-")
            //{
            //    b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
            //    khac.P_GCAY_THU(b_ma, ref b_dt); khac.P_GCAY_TTR(b_ma, "+", ref b_dt);
            //    se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            //}
            //string b_kq = (a_cot.Length > 1) ? khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso) : "";
            //return b_kq;  
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Ghi log hệ thống
    [WebMethod(true)]
    public string Fs_HT_LOG_LKE(string b_login, string b_phanhe, string b_nhom_chucnang, string b_taikhoan, string b_manhinh_thaotac,
                                            string b_tungay, string b_denngay, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_macb.Faobj_HT_LOG_LKE(b_phanhe, b_nhom_chucnang, b_taikhoan, b_manhinh_thaotac, b_tungay, b_denngay, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_thaotac");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Lịch sử đăng nhập
    [WebMethod(true)]
    public string Fs_HT_LICHSU_DANGNHAP_LKE(string b_login, string b_taikhoan, string b_tungay, string b_denngay, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_macb.Faobj_HT_LICHSU_DANGNHAP_LKE(b_taikhoan, b_tungay, b_denngay, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_dn,ngay_thoat");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Danh sách người dùng online

    [WebMethod(true)]
    public string Fs_HT_DS_USER_ONLINE_LKE(string[] a_cot, double[] a_tso)
    {
        try
        {
            object[] a_obj = ht_macb.Faobj_HT_DS_USER_ONLINE_LKE(a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "Đang hoạt động");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "Không hoạt động");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

}