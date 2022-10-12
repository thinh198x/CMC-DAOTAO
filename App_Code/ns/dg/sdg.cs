using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sdg : System.Web.Services.WebService
{

    #region ĐÁNH GIÁ CÔNG NHÂN

    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_LKE(string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_NS_DG_CONGNHAN_LKE(b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_MA(string b_phong, string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_NS_DG_CONGNHAN_MA(b_phong, b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_CT(string b_phong, string b_ngay, string[] a_cot)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_CONGNHAN_CT(b_phong, b_ngay);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            dg.P_NS_DG_CONGNHAN_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_NS_DG_CONGNHAN_MA(b_phong, b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_XOA(string b_phong, string b_ngay, double[] a_tso, string[] a_cot)
    {
        try
        { dg.P_NS_DG_CONGNHAN_XOA(b_phong, b_ngay); return Fs_NS_DG_CONGNHAN_LKE(b_phong, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CONGNHAN_LKE_CB(string b_phong, string b_ngay, string[] a_cot)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_CONGNHAN_LKE_CB(b_phong, b_ngay);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐÁNH GIÁ CÔNG NHÂN

    #region DANH MỤC NHÓM NĂNG LỰC
    [WebMethod(true)]
    public string Fs_DGNL_DM_N_NL_LKE(string b_login, string b_luuday, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DGNL_DM_N_NL_LKE(b_luuday, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_N_NL_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_DGNL_DM_N_NL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_N_NL_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DGNL_DM_N_NL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DGNL_DM_N_NL_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_N_NL_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        { if (b_login != "") se.P_LOGIN(b_login); dg.P_DGNL_DM_N_NL_XOA(b_ma); return Fs_DGNL_DM_N_NL_LKE(b_login, "", a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NHÓM NĂNG LỰC

    #region DANH MỤC NĂNG LỰC - Cũ
    [WebMethod(true)]
    public string Fs_DGNL_DM_NL_LKE_DK(string b_nhom_nl)
    {
        try
        {
            //DataTable b_dt = ns_qt.Fdt_HDCT_MA(b_so_the);
            //string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            //return b_kq;
            DataTable b_dt = dg.Fdt_DGNL_DM_NL_LKE_DK(b_nhom_nl);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_NL_LKE(string b_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DGNL_DM_NL_LKE(b_nhom, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ng_bdau,ng_kthuc");
            bang.P_COPY_COL(ref b_dt_tk, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_NL_MA(string b_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DGNL_DM_NL_MA(b_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_SO_CNG(ref b_dt, "ng_bdau,ng_kthuc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_NL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_THEM_COL(ref b_dt_ct, new string[] { "ng_bdau", "ng_kthuc" }, new int[] { chuyen.CNG_SO(DateTime.Now.ToString("yyyyMMdd")), chuyen.CNG_SO(DateTime.Now.ToString("yyyyMMdd")) });
            dg.P_DGNL_DM_NL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ma_nhom = mang.Fs_TEN_GTRI("ma_nhom", a_cot, a_gtri);
            return Fs_DGNL_DM_NL_MA(b_ma_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_NL_XOA(string b_ma_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            dg.P_DGNL_DM_NL_XOA(b_ma);
            return Fs_DGNL_DM_NL_LKE(b_ma_nhom, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NĂNG LỰC

    #region DANH MỤC NĂNG LỰC

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_NS_HDNS_MA_NL_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_MA(string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_NS_HDNS_MA_NL_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_ct;
            if (a_gtri_ct == null) b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); }
            bang.P_BO_HANG(ref b_dt_ct, "ten_muc_nl", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["ten_muc_nl"].ToString().Equals("") || b_dt_ct.Rows[i]["mota"].ToString().Equals("") || b_dt_ct.Rows[i]["bieuhien"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            dg.P_NS_HDNS_MA_NL_NH(b_dt, b_dt_ct);
            string b_so_id = mang.Fs_TEN_GTRI("so_id", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NL_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataSet b_ds = dg.Fds_NS_HDNS_MA_NL_CT(b_so_id);
            DataTable b_dt1 = b_ds.Tables[0];
            DataTable b_dt_ct1 = b_ds.Tables[1];
            string b_dt = bang.Fb_TRANG(b_dt1) ? "" : bang.Fs_HANG_GOP(b_dt1, 0);
            string b_dt_ct = bang.Fb_TRANG(b_dt_ct1) ? "" : bang.Fs_BANG_CH(b_dt_ct1, a_cot);
            return b_dt + "#" + b_dt_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            dg.P_DGNL_DM_NL_XOA(b_so_id);
            return Fs_NS_HDNS_MA_NL_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region XÂY DỰNG TỪ ĐIỂN NĂNG LỰC
    [WebMethod(true)]
    public string Fs_DGNL_DM_XD_TD_NL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DGNL_DM_XD_TD_NL_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_XD_TD_NL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DGNL_DM_XD_TD_NL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "NHOM_NL", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_XD_TD_NL_NH(double b_trangKT, string b_so_id, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DGNL_DM_XD_TD_NL_NH(b_so_id, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("NHOM_NL", a_cot, a_gtri);
            return Fs_DGNL_DM_XD_TD_NL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_XD_TD_NL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_DGNL_DM_XD_TD_NL_XOA(b_ma); return Fs_DGNL_DM_XD_TD_NL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion XÂY DỰNG TỪ ĐIỂN NĂNG LỰC

    #region DANH MỤC ĐỢT ĐÁNH GIÁ NĂNG LỰC
    [WebMethod(true)]
    public string Fs_DGNL_DM_DDG_NL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DGNL_DM_DDG_NL_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_DDG_NL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DGNL_DM_DDG_NL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_DM_DDG_NL_NAM(string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DGNL_DM_DDG_NL_NAM(b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_DDG_NL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DGNL_DM_DDG_NL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DGNL_DM_DDG_NL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_DM_DDG_NL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_DGNL_DM_DDG_NL_XOA(b_ma); return Fs_DGNL_DM_DDG_NL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC ĐỢT ĐÁNH GIÁ NĂNG LỰC

    #region THIẾT LẬP NĂNG LỰC CHO CHỨC DANH
    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_CDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DGNL_TL_NL_CHO_CDANH_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_CDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DGNL_TL_NL_CHO_CDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "cdanh", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_CDANH_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_BO_HANG(ref b_dt_ct, "NHOM_NL_TEN", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                b_dt_ct.Rows[i]["sott"] = i + 1;
                if (b_dt_ct.Rows[i]["NHOM_NL_TEN"].ToString().Equals("") || b_dt_ct.Rows[i]["NANGLUC_TEN"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            dg.P_DGNL_TL_NL_CHO_CDANH_NH(b_so_id, b_dt, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            return Fs_DGNL_TL_NL_CHO_CDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_CDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_DGNL_TL_NL_CHO_CDANH_XOA(b_ma); return Fs_DGNL_TL_NL_CHO_CDANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_CDANH_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = dg.Fdt_DGNL_TL_NL_CHO_CDANH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP NĂNG LỰC CHO CHỨC DANH

    #region THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_NVIEN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = dg.Fdt_Fs_DGNL_TL_NL_CHO_NVIEN_LKE(b_tu_n, b_den_n); ;
            //DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_NVIEN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DGNL_TL_NL_CHO_NVIEN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_NVIEN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_Fs_DGNL_TL_NL_CHO_NVIEN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DGNL_TL_NL_CHO_NVIEN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_NL_CHO_NVIEN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_Fs_DGNL_TL_NL_CHO_NVIEN_XOA(b_ma); return Fs_DGNL_TL_NL_CHO_NVIEN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region  THIẾT LẬP KHÓA HỌC THEO TIÊU CHUẨN NĂNG LỰC
    [WebMethod(true)]
    public string Fs_DGNL_TL_KH_THEO_TC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_Fs_DGNL_TL_KH_THEO_TC_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_TL_KH_THEO_TC_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DGNL_TL_KH_THEO_TC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_KH_THEO_TC_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_Fs_DGNL_TL_KH_THEO_TC_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DGNL_TL_KH_THEO_TC_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_TL_KH_THEO_TC_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_Fs_DGNL_TL_KH_THEO_TC_XOA(b_ma); return Fs_DGNL_TL_KH_THEO_TC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP KHÓA HỌC THEO TIÊU CHUẨN NĂNG LỰC

    #region ĐÁNH GIÁ NĂNG LỰC CHO CÁN BỘ NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_DGNL_NGV_NL_NV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_Fs_DGNL_NGV_NL_NV_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGNL_NGV_NL_NV_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DGNL_NGV_NL_NV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_NGV_NL_NV_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["SO_THE"].ToString().Equals("") || b_dt_ct.Rows[i]["NHOM_NL_TEN"].ToString().Equals("") || b_dt_ct.Rows[i]["NANGLUC_TEN"].ToString().Equals("") || b_dt_ct.Rows[i]["MUC_NL"].ToString().Equals("") || b_dt_ct.Rows[i]["MUC_NL_CN"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            bang.P_CSO_SO(ref b_dt_ct, "tt");
            dg.P_Fs_DGNL_NGV_NL_NV_NH(b_so_id, b_dt, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("so_id", a_cot, a_gtri);
            return Fs_DGNL_NGV_NL_NV_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_NGV_NL_NV_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = dg.Fdt_DGNL_NGV_NL_NV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGNL_NGV_NL_NV_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { dg.P_Fs_DGNL_NGV_NL_NV_XOA(b_so_id); return Fs_DGNL_NGV_NL_NV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐÁNH GIÁ NĂNG LỰC CHO CÁN BỘ NHÂN VIÊN
    // DÁNH GIÁ
    #region DANH MỤC KỲ ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_DM_KDG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_DM_KDG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NG_HLUC");
            bang.P_SO_CNG(ref b_dt, "NG_HET_HLUC");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_D");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_C");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_kdg", "DT_MA_KDG_PBO", "pbo_kdg");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_kdg", "DT_MA_KDG_ADUNG", "adung_kdg");
            return a_object[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_KDG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_DG_DM_KDG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NG_HLUC");
            bang.P_SO_CNG(ref b_dt, "NG_HET_HLUC");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_D");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_C");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_kdg", "DT_MA_KDG_PBO", "pbo_kdg");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_kdg", "DT_MA_KDG_ADUNG", "adung_kdg");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_KDG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ng_hluc");
            bang.P_CNG_SO(ref b_dt_ct, "ng_het_hluc");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dg_d");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dg_c");
            dg.P_DG_DM_KDG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_KDG, TEN_BANG.DG_DM_KDG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DG_DM_KDG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_KDG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_DG_DM_KDG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_KDG, TEN_BANG.DG_DM_KDG);
            return Fs_DG_DM_KDG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NĂNG LỰC

    #region DANH MỤC NHÓM CÂU HỎI
    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_CAUHOI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_DM_NHOM_CAUHOI_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TRANGTHAI", "TRANGTHAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "N", "Ngừng áp dụng");
            return a_object[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_CAUHOI_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_DG_DM_NHOM_CAUHOI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TRANGTHAI", "TRANGTHAI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_CAUHOI_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DG_DM_NHOM_CAUHOI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_NHOM_CAUHOI, TEN_BANG.DG_DM_NHOM_CAUHOI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DG_DM_NHOM_CAUHOI_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_CAUHOI_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_DG_DM_NHOM_CAUHOI_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_NHOM_CAUHOI, TEN_BANG.DG_DM_NHOM_CAUHOI);
            return Fs_DG_DM_NHOM_CAUHOI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NĂNG LỰC

    #region THIẾT LẬP ĐỐI TƯỢNG
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DM_DTDG_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_ad");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_DTDG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_ad");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_DTDG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            //bang.P_TIM_THEM(ref b_dt_ct, "dg_dm_dtdg", "DT_NHOM_CDANH", "nhom_cdanh");
            //foreach (DataRow b_row in b_dt_ct.Rows)
            //{
            //    string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
            //    b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
            //}

            string b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
            se.P_TG_LUU("dg_dm_dtdg", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "dg_dm_dtdg", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ad");
            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ma_cd", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["ma_cd"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            bang.P_CSO_SO(ref b_dt_ct, "thamnien");
            dg.PDG_DM_DTDG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_DTDG, TEN_BANG.DG_DM_DTDG);
            return Fs_DG_DM_DTDG_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_DM_DTDG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_DTDG, TEN_BANG.DG_DM_DTDG);
            return Fs_DG_DM_DTDG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_DTDG_CT_LKE(string b_login, string b_kdg, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_DTDG_CT_LKE(b_kdg);
            DataTable b_dt_tk = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    // lấy nhóm chức danh theo kỳ đánh giá được thiết lập ở đối tượng được đánh giá 
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_DTDG_NCDANH(string b_form, string b_ky_dg, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_NS_MA_DTDG_NCDANH(b_ky_dg);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_CDANH_TLAP_DTDG_DR(string b_login, string b_nam, string b_ky_dg, string b_nhom_cdanh, string b_form, string b_ten_ktra)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_CDANH_TLAP_DTDG_DR(b_nam, b_ky_dg, b_nhom_cdanh);
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //[WebMethod(true)]
    //public string Fs_CDANH(string b_login, string b_nhom_cdanh, double[] a_tso, string b_form, string b_ten_ktra)
    //{
    //    try
    //    {
    //        se.P_LOGIN(b_login);
    //        double b_tu = 1;
    //        double b_den = 9999;
    //        if (b_form != "dg_dm_tlap_dtuong_dgia")
    //        {
    //            b_tu = a_tso[0];
    //            b_den = a_tso[1];
    //        }
    //        object[] a_obj = dg.Fdt_CDANH_DR(b_nhom_cdanh, b_tu, b_den);
    //        DataTable b_dt = (DataTable)a_obj[1];
    //        bang.P_THEM_TRANG(ref b_dt, 1, 0);
    //        //se.P_TG_LUU("dg_dm_tcdg_cd", "DT_CD", b_dt);Thành
    //        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
    //        return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    // Lấy năm trong kỳ đánh giá 
    [WebMethod(true)]
    public static DataTable Fdt_DG_DM_MA_KDG_NAM()
    {
        return dg.Fdt_DG_DM_MA_KDG_NAM();
    }
    //lấy kỳ đánh giá theo năm - phân hệ đánh giá 360
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_KDG_NHL(string b_form, string b_nam, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        //Thành
        //se.P_TG_LUU("dg_dm_dtdg", "DT_KY_DG", b_dt);
        //se.P_TG_LUU("dg_dm_tcdg_cd", "DT_KY_DG", b_dt);
        //se.P_TG_LUU("dg_dm_mdg", "DT_KY_DG", b_dt);
        //end
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    //lấy kỳ đánh giá theo năm - phân hệ đánh giá
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_KDG_DG_NHL(string b_form, string b_nam, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    //lấy đợt đánh giá theo kỳ đánh giá - phân hệ đánh giá
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_DDG_DG_NHL(string b_form, string b_kydg, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_DM_DTDG_DDG_DG_NHL(b_kydg);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        //Thành
        //se.P_TG_LUU("dg_dm_dtdg", "DT_KY_DG", b_dt);
        //se.P_TG_LUU("dg_dm_tcdg_cd", "DT_KY_DG", b_dt);
        //se.P_TG_LUU("dg_dm_mdg", "DT_KY_DG", b_dt);
        //end
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    #endregion THIẾT LẬP ĐỐI TƯỢNG

    #region THIẾT LẬP MẪU ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_DM_MDG_LKE(string b_login, string b_nam, string b_ky_dg, string b_dtuong_dg, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DM_MDG_LKE(b_nam, b_ky_dg, b_dtuong_dg, b_cdanh, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_ad");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_MDG_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_MDG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_ad");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_MDG_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_MDG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");

            string b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
            se.P_TG_LUU("DG_DM_MDG", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_MDG", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            b_dt_dr = dg.Fdt_NHOM_CDANH_DR();
            se.P_TG_LUU("DG_DM_MDG", "DT_NHOM_CDANH", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_MDG", "DT_NHOM_CDANH", "nhom_cdanh");
            string b_dt_dr_kq2 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_nhom_cdanh = b_dt.Rows[0]["nhom_cdanh"].ToString();
            b_dt_dr = dg.Fdt_CDANH_DROP(b_nhom_cdanh);
            bang.P_THEM_TRANG(ref b_dt_dr, 1, 0);
            se.P_TG_LUU("DG_DM_MDG", "DT_CDANH", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_MDG", "DT_CDANH", "cdanh");
            string b_dt_dr_kq3 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            b_dt_dr = dg.Fdt_DG_DM_MA_DTUONG_DG();
            se.P_TG_LUU("DG_DM_MDG", "DT_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_MDG", "DT_DG", "doituong_dg");
            string b_dt_dr_kq4 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            b_dt_dr = dg.Fdt_DG_DM_MA_NHOM_CAUHOI();
            se.P_TG_LUU("DG_DM_MDG", "DT_NHOM_CAUHOI", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_MDG", "DT_NHOM_CAUHOI", "nhom_cauhoi");
            string b_dt_dr_kq5 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq + "#" + b_dt_dr_kq2 + "#" + b_dt_dr_kq3 + "#" + b_dt_dr_kq4 + "#" + b_dt_dr_kq5;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_MDG_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            //string[] a_cot_cdanh = chuyen.Fas_OBJ_STR((object[])a_dt_cdanh[0]); object[] a_gtri_cdanh = (object[])a_dt_cdanh[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ad");
            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            //DataTable b_dt_cdanh = bang.Fdt_TAO_THEM(a_cot_cdanh, a_gtri_cdanh);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            //if (b_dt_cdanh == null || b_dt_cdanh.Rows.Count <= 0)
            //{
            //    return Thongbao_dch.nhapdulieu_luoi;
            //}
            ////remove duplicate row table cdanh
            //DataView view = new DataView(b_dt_cdanh);
            //b_dt_cdanh = view.ToTable(true, "cdanh");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["stt"].ToString().Equals("") || b_dt_ct.Rows[i]["ma_cauhoi"].ToString().Equals("") || b_dt_ct.Rows[i]["nd_cauhoi"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PDG_DM_MDG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_MDG, TEN_BANG.DG_DM_MDG);
            return Fs_DG_DM_MDG_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_MDG_XOA(string b_login, string b_so_id, string b_nam, string b_ky_dg, string b_dtuong_dg, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_DM_MDG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_MDG, TEN_BANG.DG_DM_MDG);
            return Fs_DG_DM_MDG_LKE(b_login, b_nam, b_ky_dg, b_dtuong_dg, b_cdanh, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP MẪU ĐÁNH GIÁ

    #region TỔNG HỢP KẾT QUẢ THỰC HIỆN ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_DS_THUCHIEN_DGIA_LKE(string b_login, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DS_THUCHIEN_DGIA_LKE(b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DS_THUCHIEN_DGIA_TH(string b_login, string b_kydg, string b_ngay_th, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DS_THUCHIEN_DGIA_TH(b_kydg, b_ngay_th, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_th");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DS_THUCHIEN_DGIA_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DS_THUCHIEN_DGIA_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DS_THUCHIEN_DGIA_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DS_THUCHIEN_DGIA_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_th");

            string b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
            se.P_TG_LUU("dg_ds_thuchien_dgia", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "dg_ds_thuchien_dgia", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DS_THUCHIEN_DGIA_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngayd");
            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_th");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
           
            dg.PDG_DS_THUCHIEN_DGIA_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_DTDG, TEN_BANG.DG_DM_DTDG);
            return Fs_DG_DS_THUCHIEN_DGIA_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ NỘI BỘ
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGNB_LKE(string b_login, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DM_TONGHOP_DGNB_LKE(b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_vao");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGNB_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            string b_result = "0";
            object[] a_object = dg.Fdt_DG_NGV_TONGHOP_DGNB_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            if (b_dt.Rows.Count > 0)
            {
                b_result = "1";
            }
            return b_result;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGNB_CT(string b_login, string b_so_id, string b_ky_dg, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_TONGHOP_DGNB_CT(b_so_id, b_ky_dg);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_ct.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGNB_NH(string b_login, string b_nam, string b_kydanhgia, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NGV_TONGHOP_DGNB_NH(b_nam, b_kydanhgia);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.DG_NGV_TONGHOP_DGNB, TEN_BANG.DG_NGV_TONGHOP_DGNB);
            return Fs_DG_NGV_TONGHOP_DGNB_MA(b_kydanhgia, a_tso[1], a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //lấy kỳ đánh giá theo năm 
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_KDG(string b_nam)
    {
        DataTable b_dt = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU("dg_ngv_tonghop_dgnb", "DT_KY_DG", b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    #endregion TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ NỘI BỘ

    #region TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ KHÁCH HÀNG
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGKH_LKE(string b_login, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_NGV_TONGHOP_DGKH_LKE(b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_vao");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGKH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            string b_result = "0";
            object[] a_object = dg.Fdt_DG_NGV_TONGHOP_DGKH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            if (b_dt.Rows.Count > 0)
            {
                b_result = "1";
            }
            return b_result;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGKH_CT(string b_login, string b_sothe, string b_ky_dg, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_TONGHOP_DGKH_CT(b_sothe, b_ky_dg);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                              b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_TONGHOP_DGKH_NH(string b_login, string b_nam, string b_kydanhgia, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NGV_TONGHOP_DGKH_NH(b_nam, b_kydanhgia);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.DG_NGV_TONGHOP_DGKH, TEN_BANG.DG_NGV_TONGHOP_DGKH);
            return Fs_DG_NGV_TONGHOP_DGKH_MA(b_kydanhgia, a_tso[1], a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //lấy kỳ đánh giá theo năm 
    [WebMethod(true)]
    public string Fdt_NS_DG_MA_KDG_DGKH(string b_nam)
    {
        DataTable b_dt = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU("dg_ngv_tonghop_dgkh", "DT_KY_DG", b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    #endregion TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ KHÁCH HÀNG

    #region DANH MỤC KỲ ĐÁNH GIÁ - PHÂN HỆ ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_NS_DG_MA_KDG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_NS_DG_MA_KDG_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NG_HLUC");
            bang.P_SO_CNG(ref b_dt, "NG_HET_HLUC");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_D");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_C");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_PBO", "kdg_theo");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_PBO", "pbo_kdg");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_ADUNG", "adung_kdg");
            return a_object[0] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_MA_KDG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_NS_DG_MA_KDG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NG_HLUC");
            bang.P_SO_CNG(ref b_dt, "NG_HET_HLUC");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_D");
            bang.P_SO_CNG(ref b_dt, "NGAY_DG_C");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_PBO", "kdg_theo");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_PBO", "pbo_kdg");
            bang.P_TIM_THEM(ref b_dt, "NS_DG_MA_KDG", "DT_MA_KDG_ADUNG", "adung_kdg");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_KDG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ng_hluc");
            bang.P_CNG_SO(ref b_dt_ct, "ng_het_hluc");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dg_d");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dg_c");
            dg.P_NS_DG_MA_KDG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DG_MA_KDG, TEN_BANG.NS_DG_MA_KDG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DG_MA_KDG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_MA_KDG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_NS_DG_MA_KDG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_DG_MA_KDG, TEN_BANG.NS_DG_MA_KDG);
            return Fs_NS_DG_MA_KDG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC KỲ ĐÁNH GIÁ - PHÂN HỆ ĐÁNH GIÁ

    #region DANH MỤC NHÓM TIÊU CHÍ

    [WebMethod(true)]
    public string Fs_NS_DG_MA_NHOM_TCHI_LKE_ALL(string b_login, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
            DataRow b_dr = b_dt.NewRow();
            b_dr["ma"] = "";
            b_dr["ten"] = "";
            b_dt.Rows.InsertAt(b_dr, 0);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_TIEUCHI_LKE(string b_login, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_DM_NHOM_TIEUCHI_LKE(b_tt, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_TIEUCHI_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_DG_DM_NHOM_TIEUCHI_MA(b_ma, b_trangkt);
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
    public string Fs_DG_DM_NHOM_TIEUCHI_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DG_DM_NHOM_TIEUCHI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_NHOM_TIEUCHI, TEN_BANG.DG_DM_NHOM_TIEUCHI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DG_DM_NHOM_TIEUCHI_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_NHOM_TIEUCHI_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_DG_DM_NHOM_TIEUCHI_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_NHOM_TIEUCHI, TEN_BANG.DG_DM_NHOM_TIEUCHI);
            return Fs_DG_DM_NHOM_TIEUCHI_LKE(b_login, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NHÓM TIÊU CHÍ

    #region DANH MỤC TIÊU CHÍ

    [WebMethod(true)]
    public string Fs_NS_DG_MA_TCHI_LKE_ALL(string b_login, string b_ma_nhom, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_NS_DG_MA_TCHI_LKE_ALL(b_ma_nhom);
            DataRow b_dr = b_dt.NewRow();
            b_dr["ma"] = "";
            b_dr["ten"] = "";
            b_dt.Rows.InsertAt(b_dr, 0);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_TIEUCHI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_DM_TIEUCHI_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tieuchi", "DT_DG_NHOM_TCHI", "MA_NHOM");
            //bang.P_SO_CNG(ref b_dt, "ng_bdau,ng_kthuc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TIEUCHI_LKE_NHOM(string b_login, string b_ma_nhom, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fobj_DG_DM_TIEUCHI_LKE_NHOM(b_tu_n, b_den_n, b_ma_nhom, b_tt);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tieuchi", "DT_DG_NHOM_TCHI", "MA_NHOM");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TIEUCHI_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_DG_DM_TIEUCHI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma" }, new string[] { b_ma });

            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tieuchi", "DT_DG_NHOM_TCHI", "MA_NHOM");
            //bang.P_SO_CNG(ref b_dt, "ng_bdau,ng_kthuc");

            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_TIEUCHI_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            //bang.P_CNG_SO(ref b_dt_ct, "ng_bdau,ng_kthuc");
            string b_ma = dg.P_DG_DM_TIEUCHI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_TIEUCHI, TEN_BANG.DG_DM_TIEUCHI);
            string b_ma_nhom = chuyen.OBJ_S(mang.Fs_TEN_GTRI("MA_NHOM", a_cot, a_gtri));
            return Fs_DG_DM_TIEUCHI_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TIEUCHI_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_DG_DM_TIEUCHI_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_TIEUCHI, TEN_BANG.DG_DM_TIEUCHI);
            return Fs_DG_DM_TIEUCHI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC NĂNG LỰC

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ THEO CHỨC DANH
    [WebMethod(true)] //Lấy tiêu chí theo nhóm tiêu chí
    public string Fs_TIEUCHI(string b_login, string b_ma_nhom_tc, double[] a_tso, string b_form, string b_ten_ktra)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_NS_DG_MA_TCHI_LKE_ALL_NHOMTC1(b_ma_nhom_tc, a_tso[0], a_tso[1]);
            //object[] a_object = dg.Fdt_NS_DG_MA_TCHI_LKE_ALL_NHOMTC(b_ma_nhom_tc);
            DataTable b_dt2 = (DataTable)a_object[1];
            bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ng_bdau", "ng_kthuc", "ngay_nh", "nsd", "idvung", "sott", "ma_nhom", "ma_nhom_ten" });
            return (bang.Fb_TRANG(b_dt2)) ? "" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt2, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)] //Lấy mô tả theo  tiêu chí
    public string Fs_MOTA(string b_login, string b_ma_tc, string b_nhom_tc)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_NS_DG_MA_TCHI_LKE_ALL_NHOMTC(b_nhom_tc);
            DataTable b_dt2 = (DataTable)a_object[1];
            string mota = "";
            if (b_dt2.Rows.Count > 0)
            {
                int row = bang.Fi_TIM_ROW(b_dt2, "ma", (object)b_ma_tc);
                mota = b_dt2.Rows[row]["gchu"].ToString();
            }
            return (bang.Fb_TRANG(b_dt2)) ? "" : mota;
        }
        catch (Exception ex) { return ""; }
    }

    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DM_TCDG_CD_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_ad");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_TCDG_CD_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_ad");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_TCDG_CD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");

            //string b_nam = b_dt.Rows[0]["nam"].ToString();
            //DataTable b_dt_dr = dg.Fdt_DG_DM_TCDG_CD_KDG_NHL(b_nam);

            //Lay gia tri hien thi cua drop nhom tieu chi
            DataTable b_dt2 = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
            bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ngay_nh", "nsd", "idvung", "sott" });
            se.P_TG_LUU("DG_DM_TCDG_CD", "DT_NTC", b_dt2);
            bang.P_TIM_THEM(ref b_dt_ct, "DG_DM_TCDG_CD", "DT_NTC", "NHOM_TC");

            //Lay gia tri hien thi cua drop tieu chi
            foreach (DataRow b_row in b_dt_ct.Rows)
            {
                string b_tieuchi = chuyen.OBJ_S(b_row["tieuchi"]); string b_ten_tieuchi = chuyen.OBJ_S(b_row["ten_tieuchi"]);
                b_row["tieuchi"] = b_tieuchi + "{" + b_ten_tieuchi;
            }
            bang.P_BO_COT(ref b_dt_ct, new string[] { "ten_tieuchi" });

            // Lay chuc danh theo nhom chuc danh
            object[] a_obj = dg.Fdt_CDANH_DR(b_dt.Rows[0]["NCD"].ToString(), 1, 9999);
            DataTable b_dt111 = (DataTable)a_obj[1];
            se.P_TG_LUU("dg_dm_tcdg_cd", "DT_CD", b_dt111);

            //Lay gia tri kydg theo nam
            DataTable b_dt12 = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_dt.Rows[0]["nam"].ToString());
            bang.P_THEM_TRANG(ref b_dt12, 1, 0);
            se.P_TG_LUU("dg_dm_tcdg_cd", "DT_KY_DG", b_dt12);

            bang.P_TIM_THEM(ref b_dt, "dg_dm_tcdg_cd", "DT_KY_DG", "KY_DG");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tcdg_cd", "DT_NAM", "NAM");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tcdg_cd", "DT_NCD", "NCD");
            bang.P_TIM_THEM(ref b_dt, "dg_dm_tcdg_cd", "DT_CD", "CD");


            string b_dt1 = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct1 = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt1 + "#" + b_dt_ct1;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_NH(string b_login, string b_so_id/*,string b_soid_ct*/, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ad");
            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            //bang.P_BO_HANG(ref b_dt_ct, "nhom_tc", "");
            //Loai bo hang trang
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["nhom_tc"].ToString().Equals("") && b_dt_ct.Rows[i]["trongso_ntc"].ToString().Equals("")
                    && b_dt_ct.Rows[i]["tieuchi"].ToString().Equals("") && b_dt_ct.Rows[i]["mota"].ToString().Equals("")
                    && b_dt_ct.Rows[i]["trongso_tc"].ToString().Equals("") && b_dt_ct.Rows[i]["donvitinh"].ToString().Equals("")
                    && b_dt_ct.Rows[i]["khongdat"].ToString().Equals("") && b_dt_ct.Rows[i]["cancaitien"].ToString().Equals("")
                    && b_dt_ct.Rows[i]["dat"].ToString().Equals("") && b_dt_ct.Rows[i]["tot"].ToString().Equals("")
                    && b_dt_ct.Rows[i]["xuatsac"].ToString().Equals("") && b_dt_ct.Rows[i]["titrong"].ToString().Equals(""))
                {
                    b_dt_ct.Rows[i].Delete();
                }
            }
            b_dt_ct.AcceptChanges();
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["nhom_tc"].ToString().Equals("") || b_dt_ct.Rows[i]["trongso_ntc"].ToString().Equals("") || b_dt_ct.Rows[i]["tieuchi"].ToString().Equals("") || b_dt_ct.Rows[i]["trongso_tc"].ToString().Equals("") || b_dt_ct.Rows[i]["donvitinh"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            dg.PDG_DM_TCDG_CD_NH(ref b_so_id,/*ref b_soid_ct,*/ b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.DG_DM_TCDG_CD, TEN_BANG.DG_DM_TCDG_CD);
            return Fs_DG_DM_TCDG_CD_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_DM_TCDG_CD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.DG_DM_TCDG_CD, TEN_BANG.DG_DM_TCDG_CD);
            return Fs_DG_DM_TCDG_CD_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TCDG_CD_CT_LKE(string b_login, string b_kdg, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_TCDG_CD_CT_LKE(b_kdg);
            DataTable b_dt_tk = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //[WebMethod(true)]
    //public string Fs_CDANH(string b_login, string b_nhom_cdanh, double[] a_tso)
    //{
    //    try
    //    {
    //        se.P_LOGIN(b_login);
    //        object[] a_obj = dg.Fdt_CDANH_DR(b_nhom_cdanh, a_tso[0], a_tso[1]);
    //        DataTable b_dt = (DataTable)a_obj[1];
    //        se.P_TG_LUU("dg_dm_tcdg_cd", "DT_CD", b_dt);
    //        return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    //// Lấy năm trong kỳ đánh giá 
    //[WebMethod(true)]
    //public static DataTable Fdt_DG_DM_MA_KDG_NAM()
    //{
    //    return dg.Fdt_DG_DM_MA_KDG_NAM();
    //}
    ////lấy kỳ đánh giá theo năm
    //[WebMethod(true)]
    //public string Fdt_NS_DG_MA_KDG_NHL(string b_nam)
    //{
    //    DataTable b_dt = dg.Fdt_DG_DM_TCDG_CD_KDG_NHL(b_nam);
    //    bang.P_THEM_TRANG(ref b_dt, 1, 0);
    //    se.P_TG_LUU("DG_DM_TCDG_CD", "DT_KY_DG", b_dt);
    //    se.P_TG_LUU("dg_dm_tcdg_cd", "DT_KY_DG", b_dt);
    //    return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //}

    #endregion THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ THEO CHỨC DANH

    #region THIẾT LẬP NĂNG LỰC ĐÁNH GIÁ THEO NHÓM CHỨC DANH
    [WebMethod(true)]
    public string Fs_NS_DG_TLNL_CDANH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_NS_DG_TLNL_CDANH_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_ad");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_TLNL_CDANH_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_NS_DG_TLNL_CDANH_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_ad");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_TLNL_CDANH_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_DG_TLNL_CDANH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ad");

            bang.P_TIM_THEM(ref b_dt, "ns_dg_tlnl_cdanh", "DT_KY_DG", "KY_DG");
            bang.P_TIM_THEM(ref b_dt, "ns_dg_tlnl_cdanh", "DT_NAM", "NAM");
            bang.P_TIM_THEM(ref b_dt, "ns_dg_tlnl_cdanh", "DT_NCD", "NCD");

            string b_dt1 = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct1 = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt1 + "#" + b_dt_ct1;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_TLNL_CDANH_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ad");
            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "MOTA", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            dg.PDG_NS_DG_TLNL_CDANH_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.NS_DG_TLNL_CDANH, TEN_BANG.NS_DG_TLNL_CDANH);
            return Fs_NS_DG_TLNL_CDANH_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_TLNL_CDANH_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NS_DG_TLNL_CDANH_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.NS_DG_TLNL_CDANH, TEN_BANG.NS_DG_TLNL_CDANH);
            return Fs_NS_DG_TLNL_CDANH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP NĂNG LỰC ĐÁNH GIÁ THEO NHÓM CHỨC DANH

    #region THIẾT LẬP QUY ĐỊNH XẾP LOẠI ĐÁNH GIÁ

    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_TL_QD_XL_DG_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayhieuluc");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_TL_QD_XL_DG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngayhieuluc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_TL_QD_XL_DG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            string b_dt1 = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);// hang gop  de tra ten cot va gia tri tai 1 hang cua 1 table
            return b_dt1;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_NH(string b_login, string b_so_id/*,string b_soid_ct*/, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngayhieuluc");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            //bang.P_BO_HANG(ref b_dt_ct, "xeploai", "");
            //Loai bo hang trang
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["xeploai"].ToString().Equals("") && b_dt_ct.Rows[i]["diemdanhgia_tu"].ToString().Equals("") && b_dt_ct.Rows[i]["diemdanhgia_den"].ToString().Equals("") && b_dt_ct.Rows[i]["heso"].ToString().Equals("") && b_dt_ct.Rows[i]["mota"].ToString().Equals(""))
                {
                    b_dt_ct.Rows[i].Delete();
                }
            }
            b_dt_ct.AcceptChanges();
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["xeploai"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            dg.PTL_QD_XL_DG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.TL_QD_XL_DG, TEN_BANG.TL_QD_XL_DG);
            return Fs_TL_QD_XL_DG_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PTL_QD_XL_DG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.TL_QD_XL_DG, TEN_BANG.TL_QD_XL_DG);
            return Fs_TL_QD_XL_DG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TL_QD_XL_DG_CT_LKE(string b_login, string b_kdg, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_TL_QD_XL_DG_CT_LKE(b_kdg);
            DataTable b_dt_tk = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CDANH(string b_login, string b_nhom_cdanh, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = dg.Fdt_CDANH_DR(b_nhom_cdanh, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            se.P_TG_LUU("TL_QD_XL_DG", "DT_CD", b_dt);
            return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //// Lấy năm trong kỳ đánh giá 
    //[WebMethod(true)]
    //public static DataTable Fdt_DG_DM_MA_KDG_NAM()
    //{
    //    return dg.Fdt_DG_DM_MA_KDG_NAM();
    //}
    ////lấy kỳ đánh giá theo năm
    //[WebMethod(true)]
    //public string Fdt_NS_DG_MA_KDG_NHL(string b_nam)
    //{
    //    DataTable b_dt = dg.Fdt_TL_QD_XL_DG_KDG_NHL(b_nam);
    //    bang.P_THEM_TRANG(ref b_dt, 1, 0);
    //    se.P_TG_LUU("TL_QD_XL_DG", "DT_KY_DG", b_dt);
    //    se.P_TG_LUU("TL_QD_XL_DG", "DT_KY_DG", b_dt);
    //    return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //}

    #endregion THIẾT LẬP QUY ĐỊNH XẾP LOẠI ĐÁNH GIÁ

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ CHO CHỨC DANH
    [WebMethod(true)]
    public string Fs_DG_TL_NHOM_CDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_TL_NHOM_CDANH_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_TL_NHOM_CDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_DG_TL_NHOM_CDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "cdanh", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_TL_NHOM_CDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_DG_TL_NHOM_CDANH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            return Fs_DG_TL_NHOM_CDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_TL_NHOM_CDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_DG_TL_NHOM_CDANH_XOA(b_ma); return Fs_DG_TL_NHOM_CDANH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO CHỨC DANH

    #region THIẾT LẬP TIÊU CHÍ ĐÁNH GIÁ CHO CBNV
    [WebMethod(true)]
    public string Fs_DG_TL_CB_NVIEN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = dg.Fdt_Fs_DG_TL_CB_NVIEN_LKE(b_tu_n, b_den_n); ;
            //DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_TL_CB_NVIEN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DG_TL_CB_NVIEN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_TL_CB_NVIEN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_Fs_DG_TL_CB_NVIEN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DG_TL_CB_NVIEN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_TL_CB_NVIEN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { dg.P_Fs_DG_TL_CB_NVIEN_XOA(b_ma); return Fs_DG_TL_CB_NVIEN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region THIẾT LẬP TỶ LỆ XẾP LOẠI ĐÁNH GIÁ NHÂN VIÊN THEO XẾP LOẠI BỘ PHẬN
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_LKE(string b_login, string b_cty, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_DM_TLDGNV_LKE(b_cty, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay_hl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_TLDGNV_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay_hl");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_TLDGNV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");

            bang.P_TIM_THEM(ref b_dt, "dg_dm_tldgnv", "DT_CTY", "cty");
            bang.P_TIM_THEM(ref b_dt_ct, "dg_dm_tldgnv", "DT_XL_DG", "xeploai_bp");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_hl");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "xeploai_bp", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["xeploai_bp"].ToString().Equals("") || b_dt_ct.Rows[i]["xeploai_xuatsac"].ToString().Equals("") || b_dt_ct.Rows[i]["xeploai_tot"].ToString().Equals("") || b_dt_ct.Rows[i]["xeploai_dat"].ToString().Equals("") || b_dt_ct.Rows[i]["xeploai_caithien"].ToString().Equals("") || b_dt_ct.Rows[i]["xeploai_kdat"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            dg.PDG_DM_TLDGNV_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.NHAP, TEN_FORM.DG_DM_TLDGNV, TEN_BANG.DG_DM_TLDGNV);
            return Fs_DG_DM_TLDGNV_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_XOA(string b_login, string b_so_id, string b_cty, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_DM_TLDGNV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.XOA, TEN_FORM.DG_DM_TLDGNV, TEN_BANG.DG_DM_TLDGNV);
            return Fs_DG_DM_TLDGNV_LKE(b_login, b_cty, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLDGNV_CT_LKE(string b_login, string b_kdg, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_DM_TLDGNV_CT_LKE(b_kdg);
            DataTable b_dt_tk = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP TỶ LỆ XẾP LOẠI ĐÁNH GIÁ NHÂN VIÊN THEO XẾP LOẠI BỘ PHẬN

    #region NHẬP CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG
    [WebMethod(true)]
    public static DataTable Fdt_NS_DG_MA_KDG_DR()
    {
        return dg.Fdt_NS_DG_MA_KDG_DR();
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_LKE(string b_login, string b_trangthai, string b_kydg_gtri, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_NGV_CTCV_HT_LKE(b_trangthai, b_kydg_gtri, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_MA(string b_login, string b_so_id, string b_trangthai, string b_kydg_gtri, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_NGV_CTCV_HT_MA(b_so_id, b_trangthai, b_kydg_gtri, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_CTCV_HT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_d");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ht");
            string b_nam = b_dt.Rows[0]["nam"].ToString();

            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("dg_ngv_ctcv_ht", "DT_KY_DG", b_dt_dr.Copy());
            bang.P_TIM_THEM(ref b_dt, "dg_ngv_ctcv_ht", "DT_KY_DG", "ky_dg");
            //Son: Tim them cho drop trang thai
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "CG{Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "0{Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "1{Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "2{Không phê duyệt");
            //
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_NH(string b_login, string b_so_id, string b_trangthai, string b_kydg_gtri, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt_ct, "ngay_d");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ht");
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PDG_NGV_CTCV_HT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_NGV_CTCV_HT, TEN_BANG.DG_NGV_CTCV_HT);
            return Fs_DG_NGV_CTCV_HT_MA(b_login, b_so_id, b_trangthai, b_kydg_gtri, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PDG_NGV_CTCV_HT_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.DG_NGV_CTCV_HT, TEN_BANG.DG_NGV_CTCV_HT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_CTCV_HT_XOA(string b_login, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NGV_CTCV_HT_XOA(b_so_id);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.DG_NGV_CTCV_HT, TEN_BANG.DG_NGV_CTCV_HT);
            return Fs_DG_NGV_CTCV_HT_LKE(b_login, b_trangthai, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO111(string b_ma_nv)
    {
        var b_dt = dg.Fdt_NS_THONGTIN_CANBO111(b_ma_nv);
        bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_hl,ngay_het_hl,nsinh");
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    #endregion NHẬP CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG

    #region NỘI BỘ ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_LKE(string b_login, string b_nam, string b_ky_dg, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_NGV_NBDG_LKE(b_nam, b_ky_dg, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "DG", "Đã gửi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_NGV_NBDG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "DG", "Đã gửi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_NBDG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            string b_donvi = b_dt.Rows[0]["donvi"].ToString();
            string b_nam = b_dt.Rows[0]["nam"].ToString();
            string b_ky_dg = b_dt.Rows[0]["ky_dg"].ToString();
            string b_canh = b_dt.Rows[0]["cdanh"].ToString();

            // combobox họ tên
            DataTable b_dt_dr = dg.Fdt_DG_NGV_TTCB(b_donvi, b_ky_dg, b_canh);
            se.P_TG_LUU("DG_NGV_NBDG", "DT_HOTEN", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_NGV_NBDG", "DT_HOTEN", "hoten");
            string b_dt_dr_kq2 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");
            // combobox chức danh
            b_dt_dr = dg.Fdt_DG_NGV_CDANH(b_donvi, b_ky_dg);
            se.P_TG_LUU("DG_NGV_NBDG", "DT_CDANH", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_NGV_NBDG", "DT_CDANH", "cdanh");
            string b_dt_dr_kq1 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");
            // combobox kỳ đánh giá
            b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
            se.P_TG_LUU("DG_NGV_NBDG", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_NGV_NBDG", "DT_KY_DG", "ky_dg");

            bang.P_TIM_THEM(ref b_dt, "DG_NGV_NBDG", "DT_DONVI", "donvi");

            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq + "#" + b_dt_dr_kq1 + "#" + b_dt_dr_kq2;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_CNG_SO(ref b_dt, "ngay_d");
            bang.P_CNG_SO(ref b_dt, "ngay_c");
            bang.P_CSO_SO(ref b_dt, "tong_diem5");
            bang.P_CSO_SO(ref b_dt, "tong_diem4");
            bang.P_CSO_SO(ref b_dt, "tong_diem3");
            bang.P_CSO_SO(ref b_dt, "tong_diem2");
            bang.P_CSO_SO(ref b_dt, "tong_diem1");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PDG_NGV_NBDG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_NGV_NBDG, TEN_BANG.DG_NGV_NBDG);
            return Fs_DG_NGV_NBDG_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PDG_NGV_NBDG_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.DG_NGV_NBDG, TEN_BANG.DG_NGV_NBDG);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_NBDG_XOA(string b_login, string b_so_id, string b_nam, string b_ky_dg, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NGV_NBDG_XOA(b_so_id);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.DG_NGV_NBDG, TEN_BANG.DG_NGV_NBDG);
            return Fs_DG_NGV_NBDG_LKE(b_login, b_nam, b_ky_dg, b_trangthai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //lấy bộ câu hỏi theo kỳ đánh giá
    [WebMethod(true)]
    public string Fs_DG_NGV_DS_LKE(string b_login, string b_donvi, string b_ky_dg, string cdanh, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_DS_CAUHOI_NBDG_LKE(b_donvi, b_ky_dg, cdanh);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            bang.P_THEM_COL(ref b_dt_ct, "stt,diem5,diem4,diem3,diem2,diem1", "NNNNNN");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //lấy điểm theo nhân viên đã đánh giá
    [WebMethod(true)]
    public string Fs_DG_NGV_DS_DIEM_LKE(string b_login, string b_donvi, string b_manv, string b_ky_dg, string cdanh, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Fds_DG_NGV_DS_DIEM_LKE(b_donvi, b_manv, b_ky_dg, cdanh);
            DataTable b_dt_ct = (DataTable)a_object[0];
            bang.P_THEM_COL(ref b_dt_ct, "stt", "");
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //lấy chức danh theo kỳ đánh giá
    [WebMethod(true)]
    public string Fdt_DG_NGV_CDANH(string b_form, string b_cty, string b_ky_dg, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_NGV_CHUCDANH(b_cty, b_ky_dg);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    //lấy thông tin cán bộ theo chức danh
    [WebMethod(true)]
    public string Fdt_DG_NGV_TTCB(string b_form, string b_donvi, string b_ky_dg, string b_cdanh, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_NGV_TTCB(b_donvi, b_ky_dg, b_cdanh);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt.Copy());
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }

    [WebMethod(true)]
    public string Fdt_DG_DM_KDG_NBDG(string b_form, string b_cty, string b_nam, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_DM_KDG_NBDG(b_cty, b_nam);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    #endregion NỘI BỘ ĐÁNH GIÁ

    #region KHÁCH HÀNG ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_LKE(string b_login, string b_nam, string b_ky_dg, string b_hoten, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DG_NGV_KHDG_LKE(b_nam, b_ky_dg, b_hoten, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DG_NGV_KHDG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_KHDG_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");

            string b_hoten = b_dt.Rows[0]["so_the"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_NGV_KHDG_CDANH(b_hoten);
            se.P_TG_LUU("DG_NGV_KHDG", "DT_CDANH", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_NGV_KHDG", "DT_CDANH", "cdanh");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            //string b_ky_dg = b_dt.Rows[0]["ky_dg"].ToString();
            //b_dt_dr = dg.Fdt_DG_NGV_KHDG_TTCB(b_ky_dg);
            //se.P_TG_LUU("DG_NGV_KHDG", "DT_HOTEN", b_dt_dr);
            //bang.P_TIM_THEM(ref b_dt, "DG_NGV_KHDG", "DT_HOTEN", "hoten");
            //string b_dt_dr_kq2 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_nam = b_dt.Rows[0]["nam"].ToString();
            b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
            se.P_TG_LUU("DG_NGV_KHDG", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_NGV_KHDG", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq1 = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq + "#" + b_dt_dr_kq1 + "#";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_CNG_SO(ref b_dt, "ngay_d");
            bang.P_CNG_SO(ref b_dt, "ngay_c");
            bang.P_CSO_SO(ref b_dt, "tong_diem5");
            bang.P_CSO_SO(ref b_dt, "tong_diem4");
            bang.P_CSO_SO(ref b_dt, "tong_diem3");
            bang.P_CSO_SO(ref b_dt, "tong_diem2");
            bang.P_CSO_SO(ref b_dt, "tong_diem1");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PDG_NGV_KHDG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_NGV_KHDG, TEN_BANG.DG_NGV_KHDG);
            return Fs_DG_NGV_KHDG_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PDG_NGV_KHDG_GUI(b_so_id); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_XOA(string b_login, string b_so_id, string b_nam, string b_ky_dg, string b_hoten, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDG_NGV_KHDG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.DG_NGV_KHDG, TEN_BANG.DG_NGV_KHDG);
            return Fs_DG_NGV_KHDG_LKE(b_login, b_nam, b_ky_dg, b_hoten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    ////lấy bộ câu hỏi theo kỳ đánh giá
    [WebMethod(true)]
    public string Fs_DG_NGV_DS_CAUHOI_LKE(string b_login, string b_ky_dg, string b_cdanh, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_NGV_DS_CAUHOI_KHDG_LKE(b_ky_dg, b_cdanh);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_SO_CNG(ref b_dt, "ngay_c");
            bang.P_THEM_COL(ref b_dt_ct, "stt,diem5,diem4,diem3,diem2,diem1", "NNNNNN");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    ////lấy điểm theo nhân viên đã đánh giá
    [WebMethod(true)]
    public string Fs_DG_NGV_KHDG_DIEM_LKE(string b_login, string b_manv, string b_makh, string b_ky_dg, string b_cdanh, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Fds_DG_NGV_KHDG_DIEM_LKE(b_manv, b_makh, b_ky_dg, b_cdanh);
            DataTable b_dt_ct = (DataTable)a_object[0];
            bang.P_THEM_COL(ref b_dt_ct, "stt", "");
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    ////lấy chức danh theo kỳ đánh giá
    [WebMethod(true)]
    public string Fdt_DG_NGV_KHDG_TTCB(string b_form, string b_ky_dg, string b_ten_ktra)
    {
        DataTable b_dt = dg.Fdt_DG_NGV_KHDG_TTCB(b_ky_dg);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    //Lấy chức danh theo nhân viên
    [WebMethod(true)]
    public string Fdt_DG_NGV_KHDG_CDANH(string b_ma_nv)
    {
        DataTable b_dt = dg.Fdt_DG_NGV_KHDG_CDANH(b_ma_nv);
        return b_dt.Rows[0]["MA"].ToString() + "#" + b_dt.Rows[0]["TEN"].ToString();
    }
    ////lấy thông tin cán bộ theo chức danh
    //[WebMethod(true)]
    //public string Fdt_DG_NGV_TTCB(string b_form, string b_cdanh, string b_ten_ktra)
    //{
    //    DataTable b_dt = dg.Fdt_DG_NGV_TTCB(b_cdanh);
    //    bang.P_THEM_TRANG(ref b_dt, 1, 0);
    //    se.P_TG_LUU(b_form, b_ten_ktra, b_dt);
    //    return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    //}
    #endregion KHÁCH HÀNG ĐÁNH GIÁ

    #region QUẢN LÝ XEM XÉT CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_LKE(string b_login, string b_trangthai, double b_nam, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_CBQL_CTCV_HT_LKE(b_trangthai, b_nam, b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_CBQL_CTCV_HT_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_CBQL_CTCV_HT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_d");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ht");
            string b_nam = b_dt.Rows[0]["nam"].ToString();

            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("DG_DM_CTCV_HT", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_CTCV_HT", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt_ct, "ngay_d");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ht");
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PDG_NGV_CTCV_HT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XACNHAN, TEN_FORM.CBQL_CTCV_HT, TEN_BANG.CBQL_CTCV_HT);
            //dg.PCBQL_CTCV_HT_NH(ref b_so_id, b_dt, b_dt_ct);
            //return Fs_CBQL_CTCV_HT_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_GUI(string b_login, string b_so_id, string b_trangthai)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PCBQL_CTCV_HT_GUI(b_so_id, b_trangthai);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.CBQL_CTCV_HT, TEN_BANG.CBQL_CTCV_HT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBQL_CTCV_HT_XOA(string b_login, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PCBQL_CTCV_HT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CBQL_CTCV_HT, TEN_BANG.CBQL_CTCV_HT);
            return Fs_CBQL_CTCV_HT_LKE(b_login, b_trangthai, 0, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ XEM XÉT CHỈ TIÊU CÔNG VIỆC HÀNG THÁNG

    #region KẾT QUẢ ĐÁNH GIÁ CỦA CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_KQ_DG_CTY_DR_GRID(string b_login, string b_loai_dg, double[] a_tso)
    {
        se.P_LOGIN(b_login);
        object[] a_obj = dg.Fdt_NS_TL_XL_DG(b_loai_dg, a_tso[0], a_tso[1]);
        DataTable b_dt = (DataTable)a_obj[1];
        return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_LKE(string b_login, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_KQ_DG_CTY_LKE(b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; //bang.P_SO_CNG(ref b_dt_tk, "nam");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_LKE_GRCT(string b_login, string b_kydg, double[] a_tso, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_KQ_DG_CTY_LKE_GRCT(b_kydg, "", b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];

            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_KQ_DG_CTY_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; //bang.P_SO_CNG(ref b_dt, "ngay_ad");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_CT1(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_KQ_DG_CTY_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_d");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ht");
            string b_nam = b_dt.Rows[0]["nam"].ToString();

            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("DG_DM_CTCV_HT", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_CTCV_HT", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_CT(string b_login, string b_so_id, double[] a_tso, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_KQ_DG_CTY_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];

            //---------------------------------------luoi chi tiet + drop xeploai_danhgia + drop_ky_dg(idvung).
            object[] a_object = dg.Faobj_KQ_DG_CTY_LKE_GRCT(b_dt.Rows[0]["ky_dg"].ToString(), b_so_id, a_tso[0], a_tso[1]);
            DataTable b_dt_ct = (DataTable)a_object[1];

            //Lay gia tri kydg theo nam
            DataTable b_dt12 = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_dt.Rows[0]["nam"].ToString());
            bang.P_THEM_TRANG(ref b_dt12, 1, 0);
            se.P_TG_LUU("kq_dg_cty", "DT_KY_DG", b_dt12);
            bang.P_TIM_THEM(ref b_dt, "kq_dg_cty", "DT_KY_DG", "KY_DG");

            string b_dt1 = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct1 = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt1 + "#" + b_dt_ct1 + "#" + chuyen.OBJ_S(a_object[0]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            b_dt_ct.AcceptChanges();
            bang.P_BO_HANG(ref b_dt_ct, "congty", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            int k = 0;
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["xeploai_danhgia"].ToString().Equals("") && b_dt_ct.Rows[i]["congty"].ToString() != "")
                {
                    k = k + 1;
                }
            }
            if (k == b_dt_ct.Rows.Count) return Thongbao_dch.nhapdulieu_luoi;
            b_dt_ct.AcceptChanges();
            dg.PKQ_DG_CTY_NH(ref b_so_id,/*ref b_soid_ct,*/ b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.KQ_DG_CTY, TEN_BANG.KQ_DG_CTY);
            return Fs_KQ_DG_CTY_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_GUI(string b_login, string b_so_id, string b_trangthai)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PKQ_DG_CTY_GUI(b_so_id, b_trangthai); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KQ_DG_CTY_XOA(string b_login, string b_so_id, string b_nam, string b_ky_dg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PKQ_DG_CTY_XOA(b_so_id, b_nam, b_ky_dg);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.KQ_DG_CTY, TEN_BANG.KQ_DG_CTY);
            return Fs_KQ_DG_CTY_LKE(b_login, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾT QUẢ ĐÁNH GIÁ CỦA CÔNG TY

    #region QUẢN LÝ ĐÁNH GIÁ CÔNG VIỆC HÀNG THÁNG CỦA NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_LKE(string b_login, string b_trangthai, double b_nam, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_QL_DG_CV_HT_LKE(b_trangthai, b_nam, b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_QL_DG_CV_HT_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_QL_DG_CV_HT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_d");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ht");
            string b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("DG_DM_CTCV_HT", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "DG_DM_CTCV_HT", "DT_KY_DG", "ky_dg");

            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt_ct, "ngay_d");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ht");
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            dg.PQL_DG_CV_HT_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.QL_DG_CV_HT, TEN_BANG.QL_DG_CV_HT);
            //return Fs_QL_DG_CV_HT_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_XACNHAN(string b_login, string b_so_id, string b_xacnhan)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PQL_DG_CV_HT_XACNHAN(b_so_id, b_xacnhan);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XACNHAN, TEN_FORM.QL_DG_CV_HT, TEN_BANG.QL_DG_CV_HT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_XOA(string b_login, string b_so_id, string b_nam, string b_kydg, string b_manv, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PQL_DG_CV_HT_XOA(b_so_id, b_nam, b_kydg, b_manv);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.QL_DG_CV_HT, TEN_BANG.QL_DG_CV_HT);
            return Fs_QL_DG_CV_HT_LKE(b_login, b_trangthai, 0, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_QL_DG_CV_HT_LAY_HESO_XEPLOAI(string b_login, string b_kq)
    {
        try
        {
            DataTable dtb_heso_xeploai = se.Fdt_TG_TRA("ql_dg_cv_ht", "DT_HS_XL");
            if (bang.Fb_TRANG(dtb_heso_xeploai) == true) return "#";
            string heso = "";
            string xeploai = "";
            foreach (DataRow r in dtb_heso_xeploai.Rows)
            {
                if (r["diemdanhgia_tu"].ToString() != "" && r["diemdanhgia_den"].ToString() != "")
                {
                    if (chuyen.CSO_SO(r["diemdanhgia_tu"].ToString()) <= chuyen.CSO_SO(b_kq) && chuyen.CSO_SO(b_kq) <= chuyen.CSO_SO(r["diemdanhgia_den"].ToString()))
                    {
                        heso = r["heso"].ToString();
                        xeploai = r["xeploai"].ToString();
                    }
                }
            }
            return heso + "#" + xeploai;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ ĐÁNH GIÁ CÔNG VIỆC HÀNG THÁNG CỦA NHÂN VIÊN

    #region CBNV NHẬP CHỈ TIÊU GIAO KPIS
    [WebMethod(true)]
    public string Fs_NS_DG_CBNV_KPI_CT_BY_MA(string b_login, string b_nam, string b_ky_dg, string b_ma_nsd, string b_ky_dg_tk, string b_trangthai_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            //double b_nam_ch=chuyen.CSO_SO(b_nam);
            DataTable b_dt = dg.Fdt_NS_DG_CBNV_KPI_CT_BY_MA(b_trangthai_tk, b_ky_dg, b_ma_nsd);
            if (b_dt.Rows.Count > 0)
            {
                string b_so_id = b_dt.Rows[0]["so_id"].ToString();
                return Fs_CBNV_CT_KPI_MA(b_login, b_so_id, b_ky_dg_tk, b_trangthai_tk, b_ma_nsd, b_trangkt, a_cot);
            }
            else
            {
                return "";
            }
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CBNV_KPI_BY_TLAP(string b_login, string b_nam, string b_kydg, string b_ma_nsd, string[] a_cot, string[] a_cot_nl)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet ds = dg.Faobj_NS_DG_CBNV_KPI_BY_TLAP(b_nam, b_kydg, b_ma_nsd);
            DataTable b_dt_ht = ds.Tables[0]; DataTable b_dt_nl = ds.Tables[1];
            return bang.Fs_BANG_CH(b_dt_ht, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_nl, a_cot_nl);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_LKE(string b_login, string b_ma_nsd, string b_trangthai, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_CBNV_CT_KPI_LKE(b_ma_nsd, b_trangthai, b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_MA(string b_login, string b_so_id, string b_ky_dg, string b_trangthai, string b_ma_nsd, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_CBNV_CT_KPI_MA(b_so_id, b_ky_dg, b_trangthai, b_ma_nsd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            ////Lay gia tri hien thi cua drop nhom tieu chi
            //DataTable b_dt2 = dg.Fdt_NS_DG_MA_TCHI_LKE_TATCA();
            //bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ng_bdau", "ng_kthuc", "ngay_nh", "nsd", "idvung", "sott", "ma", "ten" });
            //bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom", "ma");
            //bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom_ten", "ten");
            //se.P_TG_LUU("DG_DM_TCDG_CD", "DT_NTC", b_dt2);
            //bang.P_TIM_THEM(ref b_dt, "DG_DM_TCDG_CD", "DT_NTC", "NHOM_TC");

            ////Lay gia tri hien thi cua drop tieu chi
            //foreach (DataRow b_row in b_dt.Rows)
            //{
            //    string b_tieuchi = chuyen.OBJ_S(b_row["tieuchi"]); string b_ten_tieuchi = chuyen.OBJ_S(b_row["ten_tieuchi"]);
            //    b_row["tieuchi"] = b_tieuchi + "{" + b_ten_tieuchi;
            //}
            //bang.P_BO_COT(ref b_dt, new string[] { "ten_tieuchi" });


            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_CT(string b_login, string b_so_id, string b_ma_nsd, double b_nam1, string b_kydg, string[] a_cot_ct, string[] a_cot_ct1)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_CBNV_CT_KPI_CT(b_so_id, b_ma_nsd, b_nam1, b_kydg);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1]; DataTable b_dt_ct2 = b_ds.Tables[2];
            bang.P_THEM_COL(ref b_dt_ct, "STT"); bang.P_THEM_COL(ref b_dt_ct2, "STT");
            foreach (DataRow r in b_dt_ct.Rows)
            {
                r["STT"] = chuyen.CSO_SO(r["STT"].ToString()) + 1;
            }
            foreach (DataRow r in b_dt_ct2.Rows)
            {
                r["STT"] = chuyen.CSO_SO(r["STT"].ToString()) + 1;
            }
            string b_nam = "";
            if (b_dt.Rows.Count > 0) b_nam = b_dt.Rows[0]["nam"].ToString();

            //Lay gia tri hien thi cua drop nhom tieu chi
            DataTable b_dt2 = dg.Fdt_NS_DG_MA_TCHI_LKE_TATCA();
            bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ng_bdau", "ng_kthuc", "ngay_nh", "nsd", "idvung", "sott", "ma", "ten" });
            bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom", "ma");
            bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom_ten", "ten");
            se.P_TG_LUU("DG_DM_TCDG_CD", "DT_NTC", b_dt2);
            bang.P_TIM_THEM(ref b_dt_ct, "DG_DM_TCDG_CD", "DT_NTC", "NHOM_TC");

            ////Lay gia tri hien thi cua drop tieu chi
            //foreach (DataRow b_row in b_dt_ct.Rows)
            //{
            //    string b_tieuchi = chuyen.OBJ_S(b_row["tieuchi"]); string b_ten_tieuchi = chuyen.OBJ_S(b_row["ten_tieuchi"]);
            //    b_row["tieuchi"] = b_tieuchi + "{" + b_ten_tieuchi;
            //}
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("cbnv_ct_kpi", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "cbnv_ct_kpi", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            string b_dt_ct_s2 = bang.Fb_TRANG(b_dt_ct2) ? "" : bang.Fs_BANG_CH(b_dt_ct2, a_cot_ct1);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq + "#" + b_dt_ct_s2;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_NH(string b_login, string b_so_id, string b_ky_dg, string b_trangthai, string b_ma_nsd, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke, object[] a_dt_ct1)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_ct1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct1[0]); object[] a_gtri_ct1 = (object[])a_dt_ct1[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); DataTable b_dt_ct1 = bang.Fdt_TAO_THEM(a_cot_ct1, a_gtri_ct1);
            bang.P_BO_HANG(ref b_dt_ct, "stt", ""); bang.P_BO_HANG(ref b_dt_ct1, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            if (b_dt_ct1 == null || b_dt_ct1.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            bang.P_CSO_SO(ref b_dt_ct1, "stt");
            dg.PCBNV_CT_KPI_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_ct1);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.CBNV_CT_KPI, TEN_BANG.CBNV_CT_KPI);
            return Fs_CBNV_CT_KPI_MA(b_login, b_so_id, b_ky_dg, b_trangthai, b_ma_nsd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_GUI(string b_login, string b_so_id/*, string b_trangthai*/)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PCBNV_CT_KPI_GUI(b_so_id/*, b_trangthai*/);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.CBNV_CT_KPI, TEN_BANG.CBNV_CT_KPI);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CBNV_CT_KPI_XOA(string b_login, string b_so_id, string b_ma_nsd, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            dg.PCBNV_CT_KPI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.CBNV_CT_KPI, TEN_BANG.CBNV_CT_KPI); return Fs_CBNV_CT_KPI_LKE(b_login, b_ma_nsd, b_trangthai, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CBNV NHẬP CHỈ TIÊU GIAO KPIS

    #region QUẢN LÝ XEM XÉT CHỈ TIÊU GIAO KPIS
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_LKE(string b_login, string b_trangthai, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_NS_DG_QLXX_CT_KPI_LKE(b_trangthai, b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_NS_DG_QLXX_CT_KPI_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_CT(string b_login, string b_so_id, string b_ma_nsd, double b_nam1, string b_kydg, string[] a_cot_ct, string[] a_cot_ct1)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_DG_QLXX_CT_KPI_CT(b_so_id, b_ma_nsd, b_nam1, b_kydg);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1]; DataTable b_dt_ct2 = b_ds.Tables[2];
            bang.P_THEM_COL(ref b_dt_ct, "STT"); bang.P_THEM_COL(ref b_dt_ct2, "STT");
            foreach (DataRow r in b_dt_ct.Rows)
            {
                r["STT"] = chuyen.CSO_SO(r["STT"].ToString()) + 1;
            }
            foreach (DataRow r in b_dt_ct2.Rows)
            {
                r["STT"] = chuyen.CSO_SO(r["STT"].ToString()) + 1;
            }
            //bang.P_SO_CNG(ref b_dt_ct, "ngay_d");
            //bang.P_SO_CNG(ref b_dt_ct, "ngay_ht");
            string b_nam = b_dt.Rows[0]["nam"].ToString();

            //
            //Lay gia tri hien thi cua drop nhom tieu chi
            DataTable b_dt2 = dg.Fdt_NS_DG_MA_TCHI_LKE_TATCA();
            bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ng_bdau", "ng_kthuc", "ngay_nh", "nsd", "idvung", "sott", "ma", "ten" });
            bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom", "ma");
            bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom_ten", "ten");
            se.P_TG_LUU("DG_DM_TCDG_CD", "DT_NTC", b_dt2);
            bang.P_TIM_THEM(ref b_dt_ct, "DG_DM_TCDG_CD", "DT_NTC", "NHOM_TC");

            ////Lay gia tri hien thi cua drop tieu chi
            //foreach (DataRow b_row in b_dt_ct.Rows)
            //{
            //    string b_tieuchi = chuyen.OBJ_S(b_row["tieuchi"]); string b_ten_tieuchi = chuyen.OBJ_S(b_row["ten_tieuchi"]);
            //    b_row["tieuchi"] = b_tieuchi + "{" + b_ten_tieuchi;
            //}
            //bang.P_BO_COT(ref b_dt_ct, new string[] { "ten_tieuchi" });
            ////

            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("NS_DG_QLXX_CT_KPI", "DT_KY_DG", b_dt_dr);
            bang.P_TIM_THEM(ref b_dt, "NS_DG_QLXX_CT_KPI", "DT_KY_DG", "ky_dg");
            string b_dt_dr_kq = bang.Fb_TRANG(b_dt_dr) ? "" : bang.Fs_BANG_CH(b_dt_dr, "MA,TEN");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            string b_dt_ct_s2 = bang.Fb_TRANG(b_dt_ct2) ? "" : bang.Fs_BANG_CH(b_dt_ct2, a_cot_ct1);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_dr_kq + "#" + b_dt_ct_s2;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, double[] a_tso,
        string[] a_cot_lke, object[] a_dt_ct1)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_ct1 = chuyen.Fas_OBJ_STR((object[])a_dt_ct1[0]); object[] a_gtri_ct1 = (object[])a_dt_ct1[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CSO_SO(ref b_dt, "nam");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); DataTable b_dt_ct1 = bang.Fdt_TAO_THEM(a_cot_ct1, a_gtri_ct1);
            bang.P_BO_HANG(ref b_dt_ct, "stt", ""); bang.P_BO_HANG(ref b_dt_ct1, "stt", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            if (b_dt_ct1 == null || b_dt_ct1.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CSO_SO(ref b_dt_ct, "stt");
            bang.P_CSO_SO(ref b_dt_ct1, "stt");
            dg.PCBNV_CT_KPI_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_ct1);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DG_QLXX_CT_KPI, TEN_BANG.NS_DG_QLXX_CT_KPI);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_GUI(string b_login, string b_so_id, string b_trangthai)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PNS_DG_QLXX_CT_KPI_GUI(b_so_id, b_trangthai);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_DG_QLXX_CT_KPI, TEN_BANG.NS_DG_QLXX_CT_KPI);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_QLXX_CT_KPI_XOA(string b_login, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PNS_DG_QLXX_CT_KPI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DG_QLXX_CT_KPI, TEN_BANG.NS_DG_QLXX_CT_KPI);
            return Fs_NS_DG_QLXX_CT_KPI_LKE(b_login, b_trangthai, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ XEM XÉT CHỈ TIÊU GIAO KPIS

    #region ĐÁNH GIÁ BỘ PHẬN
    [WebMethod(true)]
    public string Fs_DG_NGV_BOPHAN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_Fs_DG_NGV_BOPHAN_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_NGV_BOPHAN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DG_NGV_BOPHAN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ky_dgia", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_NGV_BOPHAN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_Fs_DG_NGV_BOPHAN_NH(b_dt_ct);
            string b_ky_dgia = mang.Fs_TEN_GTRI("ky_dgia", a_cot, a_gtri);
            return Fs_DG_NGV_BOPHAN_MA(b_ky_dgia, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DG_NGV_BOPHAN_XOA(string b_ma, string b_bophan, double[] a_tso, string[] a_cot)
    {
        try { dg.P_Fs_DG_NGV_BOPHAN_XOA(b_ma, b_bophan); return Fs_DG_NGV_BOPHAN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP NĂNG LỰC CHO NHÂN VIÊN

    #region GIAO KPI
    [WebMethod(true)]
    public string Fs_NS_DG_GIAO_KPI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            DataTable b_dt = dg.Fdt_NS_DG_GIAO_KPI_LKE(b_tu_n, b_den_n);
            //DataTable b_dt = (DataTable)a_object[1];
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_DG_GIAO_KPI_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataTable b_ds = dg.Fdt_NS_DG_GIAO_KPI_CT(b_so_id);
            //string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
            //       b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return "#" + bang.Fs_BANG_CH(b_ds, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region GIAO KPI CHO CBNV
    [WebMethod(true)]
    public string Fs_NS_DG_GIAO_KPI_CHO_CB_LKE(string[] a_cot)
    {
        try
        {
            double b_tu_n = 1, b_den_n = 10000;
            DataTable b_dt = dg.Fdt_NS_DG_GIAO_KPI_LKE(b_tu_n, b_den_n);
            return "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_DG_GIAO_KPI_CHO_CB_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataTable b_ds = dg.Fs_NS_DG_GIAO_KPI_CHO_CB_CT(b_so_id);
            return "#" + bang.Fs_BANG_CH(b_ds, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region TIÊU CHÍ ĐÁNH GIÁ CẤP NHÂN VIÊN THEO KỲ ĐG

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CNV_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_NS_DG_TC_CNV_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_adung");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_TC_CNV_MA(string b_login, double b_nam, string b_ma_kdg, string b_ma_plnv, string b_ma_capnv, double b_ngay_adung, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_NS_DG_TC_CNV_MA(b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ngay_adung, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "nam", "ma_kdg", "plnv_capnv", "ngay_adung" }, new object[] { b_nam, b_ma_kdg, b_ma_plnv + b_ma_capnv, b_ngay_adung });
            bang.P_SO_CNG(ref b_dt, "ngay_adung");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CNV_CT(string b_login, double b_so_id, string[] a_cot_lke_tc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_DG_TC_CNV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tc = b_ds.Tables[1];
            DataTable b_dt_dmtc = b_ds.Tables[2];

            string b_plnv = "";
            if (b_dt.Rows.Count > 0) b_plnv = b_dt.Rows[0]["MA_PLNV"].ToString();
            DataTable b_dt_cnv;
            if (b_plnv != "")
                b_dt_cnv = ns_ma.Fdt_NS_HDNS_MA_CAPNV_LKE_DR(b_plnv, "A");
            else
                b_dt_cnv = bang.Fdt_TAO_BANG("ma,ten", "SS");
            DataRow b_dr_cnv = b_dt_cnv.NewRow();
            b_dr_cnv["ma"] = ""; b_dr_cnv["ten"] = "";
            b_dt_cnv.Rows.InsertAt(b_dr_cnv, 0);
            se.P_TG_LUU("ns_dg_tc_cnv", "TC_DG_CNV_KY_CNV", b_dt_cnv);

            bang.P_SO_CNG(ref b_dt, "NGAY_ADUNG");
            string b_ma_tc_nhom = "";
            DataTable b_dt_tc_nhom = b_dt_dmtc.Clone();
            ArrayList a_ma_nhom = new ArrayList();
            string b_index_ma_nhom = "";
            string[] a_cot_lke_dmtc = new string[] { "ma", "ten" };
            int b_index;
            foreach (DataRow b_dr_nhom in b_dt_tc.Rows)
            {
                b_index = a_ma_nhom.IndexOf(b_dr_nhom["ma_nhom_tc"]);
                if (b_index < 0)
                {
                    a_ma_nhom.Add(b_dr_nhom["ma_nhom_tc"]);
                    b_index_ma_nhom += (a_ma_nhom.Count - 1).ToString() + ",";
                    bang.P_BO_HANG(ref b_dt_tc_nhom, 0, b_dt_tc_nhom.Rows.Count - 1);
                    //bang.P_THEM_HANG(ref b_dt_tc_nhom, b_dt_dmtc, "ma_nhom", b_dr_nhom["ma_nhom_tc"].ToString(), "=");
                    DataRow[] a_dr_tc = b_dt_dmtc.Select("ma_nhom = '" + b_dr_nhom["ma_nhom_tc"].ToString() + "'");
                    foreach (DataRow b_dr in a_dr_tc)
                        b_dt_tc_nhom.ImportRow(b_dr);
                    DataRow b_dr0 = b_dt_tc_nhom.NewRow();
                    b_dr0["ma"] = "";
                    b_dr0["ten"] = "";
                    b_dt_tc_nhom.Rows.InsertAt(b_dr0, 0);
                    b_ma_tc_nhom += bang.Fs_BANG_CH(b_dt_tc_nhom, a_cot_lke_dmtc) + (char)1;
                }
                else
                {
                    b_index_ma_nhom += b_index + ",";
                }
            }
            if (b_index_ma_nhom != "")
            {
                b_index_ma_nhom = b_index_ma_nhom.Substring(0, b_index_ma_nhom.Length - 1);
                b_ma_tc_nhom = b_ma_tc_nhom.Substring(0, b_ma_tc_nhom.Length - 1);
            }

            bang.P_TIM_THEM(ref b_dt, "ns_dg_tc_cnv", "TC_DG_CNV_KY_KDG", "MA_KDG");
            bang.P_TIM_THEM(ref b_dt, "ns_dg_tc_cnv", "TC_DG_CNV_KY_PLNV", "MA_PLNV");
            bang.P_TIM_THEM(ref b_dt, "ns_dg_tc_cnv", "TC_DG_CNV_KY_CNV", "MA_CAPNV");

            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_tc) ? "" : bang.Fs_BANG_CH(b_dt_tc, a_cot_lke_tc)))
                + "#" + b_dt_tc.Rows.Count // số dòng tiêu chí
                + "#" + b_index_ma_nhom // chỉ số nhóm tiêu chí trong mảng b_ma_tc_nhom
                + "#" + b_ma_tc_nhom; // mảng tiêu chí theo nhóm
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CNV_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_ct_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_adung");
            // thông tin tiêu chí
            string[] a_cot_ct_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cd[0]);
            object[] a_gtri_ct_cd = (object[])a_dt_ct_cd[1];
            DataTable b_dt_ct_cd;
            if (a_gtri_ct_cd == null)
                b_dt_ct_cd = bang.Fdt_TAO_BANG(a_cot_ct_cd, "SS");
            else
                b_dt_ct_cd = bang.Fdt_TAO_THEM(a_cot_ct_cd, a_gtri_ct_cd);
            bang.P_BO_HANG(ref b_dt_ct_cd, new string[] { "ma_nhom_tc", "ma_tc" }, new object[] { "", "" });
            if (b_dt_ct_cd.Rows.Count == 0)
                return "loi:Bạn chưa nhập tiêu chí:loi";
            string b_loi = "";
            double b_trong_so, b_tong_tso_mot_nhom, b_tong_tso_nhom = 0;
            ArrayList a_nhom_tc = new ArrayList(), a_tso_nhom_tc = new ArrayList();
            int b_index;
            foreach (DataRow b_dr in b_dt_ct_cd.Rows)
            {
                if (String.IsNullOrEmpty(b_dr["ma_tc"].ToString()))
                    b_loi = "Nhập thiếu tiêu chí, ";
                if (String.IsNullOrEmpty(b_dr["ma_nhom_tc"].ToString()))
                    b_loi += "Nhập thiếu nhóm tiêu chí, ";
                if (String.IsNullOrEmpty(b_dr["tso_nhom"].ToString()))
                    b_loi += "Nhập thiếu trọng số nhóm tiêu chí, ";
                else
                {
                    b_trong_so = chuyen.CSO_SO(b_dr["tso_nhom"].ToString());
                    if (b_trong_so == 0 || b_trong_so > 100)
                        b_loi += "Trọng số nhóm tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100, ";
                }
                if (String.IsNullOrEmpty(b_dr["tso_tc"].ToString()))
                    b_loi += "Nhập thiếu trọng số tiêu chí, ";
                else
                {
                    b_trong_so = chuyen.CSO_SO(b_dr["tso_tc"].ToString());
                    if (b_trong_so == 0 || b_trong_so > 100)
                        b_loi += "Trọng số tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100, ";
                }
                if (b_dt_ct_cd.Select("ma_tc = '" + b_dr["ma_tc"] + "'").Length > 1)
                    b_loi += "Trùng tiêu chí, ";

                b_index = a_nhom_tc.IndexOf(b_dr["ma_nhom_tc"]);
                if (b_index < 0)
                {
                    b_tong_tso_mot_nhom = 0;
                    a_nhom_tc.Add(b_dr["ma_nhom_tc"]);
                    DataRow[] a_dr_tc = b_dt_ct_cd.Select("ma_nhom_tc = '" + b_dr["ma_nhom_tc"] + "'");
                    foreach (DataRow b_dr1 in a_dr_tc)
                    {
                        b_tong_tso_mot_nhom += chuyen.OBJ_N(b_dr1["tso_tc"]);
                    }
                    if (b_tong_tso_mot_nhom != 100)
                        b_loi += "Tổng trọng số các tiêu chí trong một nhóm tiêu chí phải bằng 100, ";
                    b_tong_tso_nhom += chuyen.OBJ_N(b_dr["tso_nhom"]);
                    a_tso_nhom_tc.Add(b_dr["tso_nhom"]);
                }
                else
                {
                    if (!a_tso_nhom_tc[b_index].Equals(b_dr["tso_nhom"]))
                        b_loi += "Trọng số nhóm tiêu chí của các tiêu chí cùng nhóm phải bằng nhau, ";
                }

                if (b_loi != "")
                    return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

                if (b_dr["dmuc_l1"].ToString() == "")
                    b_dr["dmuc_l1"] = -1;
                if (b_dr["dmuc_l2"].ToString() == "")
                    b_dr["dmuc_l2"] = -1;
            }
            if (b_tong_tso_nhom != 100)
                b_loi += "Tổng trọng số nhóm tiêu chí phải bằng 100, ";
            if (b_loi != "")
                return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

            bang.P_CSO_SO(ref b_dt_ct_cd, new string[] { "so_id", "tso_nhom", "tso_tc", "dmuc_l1", "dmuc_l2" });
            if (b_dt_ct_cd.Rows.Count == 0)
            {
                DataRow b_dr = b_dt_ct_cd.NewRow();
                b_dr["so_id"] = -1;
                b_dt_ct_cd.Rows.Add(b_dr);
            }
            dg.P_NS_DG_TC_CNV_NH(b_dt_ct, b_dt_ct_cd);
            double b_nam = chuyen.CSO_SO(mang.Fs_TEN_GTRI("nam", a_cot, a_gtri));
            string b_ma_kdg = mang.Fs_TEN_GTRI("ma_kdg", a_cot, a_gtri), b_ma_plnv = mang.Fs_TEN_GTRI("ma_plnv", a_cot, a_gtri), b_ma_capnv = mang.Fs_TEN_GTRI("ma_capnv", a_cot, a_gtri);
            double b_ngay_adung = chuyen.CNG_SO(mang.Fs_TEN_GTRI("ngay_adung", a_cot, a_gtri));
            return Fs_NS_DG_TC_CNV_MA(b_login, b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ngay_adung, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CNV_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            dg.P_NS_DG_TC_CNV_XOA(b_so_id);
            return Fs_NS_DG_TC_CNV_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion TIÊU CHÍ ĐÁNH GIÁ CẤP NHÂN VIÊN THEO KỲ ĐG

    #region GÁN TIÊU CHÍ ĐÁNH GIÁ CHO CBNV

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CBNV_TIMNV(string b_login, string b_phong, string b_cbnv, string b_ky_dg, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_NS_DG_TC_CBNV_TIMNV(b_phong, b_cbnv);
            bang.P_THEM_COL(ref b_dt, "ky_dg", b_ky_dg);
            bang.P_THEM_COL(ref b_dt, "chon", typeof(string));
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_THEM_COL(ref b_dt, "MA_PLNV", typeof(string));
            bang.P_THEM_COL(ref b_dt, "MA_CAPNV", typeof(string));
            string[] a_plnv;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                a_plnv = b_dr["plnv"].ToString().Split("#".ToCharArray());
                if (a_plnv.Length == 2)
                {
                    b_dr["MA_PLNV"] = a_plnv[0];
                    b_dr["MA_CAPNV"] = a_plnv[1];
                }
            }
            return b_dt.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CBNV_CT(string b_login, double b_nam, string b_ma_kdg, string b_so_the, string b_ma_plnv, string b_ma_capnv, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = dg.Fdt_NS_DG_TC_CBNV_CT(b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv);
            DataTable b_dt = (DataTable)a_object[1];
            return a_object[0] + "#" + b_dt.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_TC_CBNV_NH(string b_login, double b_nam, string b_ma_kdg, string b_so_the, string b_ma_plnv, string b_ma_capnv, object[] a_dt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, new string[] { "ma_nhom_tc", "ma_tc" }, new object[] { "", "" });
            if (b_dt.Rows.Count == 0)
                return "loi:Bạn chưa nhập tiêu chí:loi";
            string b_loi = "";
            double b_trong_so, b_tong_tso_mot_nhom, b_tong_tso_nhom = 0;
            ArrayList a_nhom_tc = new ArrayList(), a_tso_nhom_tc = new ArrayList();
            int b_index;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (String.IsNullOrEmpty(b_dr["ma_tc"].ToString()))
                    b_loi = "Nhập thiếu tiêu chí, ";
                if (String.IsNullOrEmpty(b_dr["ma_nhom_tc"].ToString()))
                    b_loi += "Nhập thiếu nhóm tiêu chí, ";
                if (String.IsNullOrEmpty(b_dr["tso_nhom"].ToString()))
                    b_loi += "Nhập thiếu trọng số nhóm tiêu chí, ";
                else
                {
                    b_trong_so = chuyen.CSO_SO(b_dr["tso_nhom"].ToString());
                    if (b_trong_so == 0 || b_trong_so > 100)
                        b_loi += "Trọng số nhóm tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100, ";
                }
                if (String.IsNullOrEmpty(b_dr["tso_tc"].ToString()))
                    b_loi += "Nhập thiếu trọng số tiêu chí, ";
                else
                {
                    b_trong_so = chuyen.CSO_SO(b_dr["tso_tc"].ToString());
                    if (b_trong_so == 0 || b_trong_so > 100)
                        b_loi += "Trọng số tiêu chí phải lớn hơn 0 và nhỏ hơn hoặc bằng 100, ";
                }
                if (b_dt.Select("ma_tc = '" + b_dr["ma_tc"] + "'").Length > 1)
                    b_loi = "Trùng tiêu chí, ";
                b_index = a_nhom_tc.IndexOf(b_dr["ma_nhom_tc"]);
                if (b_index < 0)
                {
                    b_tong_tso_mot_nhom = 0;
                    a_nhom_tc.Add(b_dr["ma_nhom_tc"]);
                    DataRow[] a_dr_tc = b_dt.Select("ma_nhom_tc = '" + b_dr["ma_nhom_tc"] + "'");
                    foreach (DataRow b_dr1 in a_dr_tc)
                    {
                        b_tong_tso_mot_nhom += chuyen.OBJ_N(b_dr1["tso_tc"]);
                    }
                    if (b_tong_tso_mot_nhom != 100)
                        b_loi += "Tổng trọng số các tiêu chí trong một nhóm tiêu chí phải bằng 100, ";
                    b_tong_tso_nhom += chuyen.OBJ_N(b_dr["tso_nhom"]);
                    a_tso_nhom_tc.Add(b_dr["tso_nhom"]);
                }
                else
                {
                    if (!a_tso_nhom_tc[b_index].Equals(b_dr["tso_nhom"]))
                        b_loi += "Trọng số nhóm tiêu chí của các tiêu chí cùng nhóm phải bằng nhau, ";
                }
                if (b_loi != "")
                    return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

                if (b_dr["dmuc_l1"].ToString() == "")
                    b_dr["dmuc_l1"] = -1;
                if (b_dr["dmuc_l2"].ToString() == "")
                    b_dr["dmuc_l2"] = -1;
            }
            if (b_tong_tso_nhom != 100)
                b_loi += "Tổng trọng số nhóm tiêu chí phải bằng 100, ";
            if (b_loi != "")
                return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

            bang.P_CSO_SO(ref b_dt, new string[] { "so_id", "tso_nhom", "tso_tc", "dmuc_l1", "dmuc_l2" });
            if (b_dt.Rows.Count == 0)
            {
                return "loi:Bạn chưa nhập tiêu chí:loi";
                //DataRow b_dr = b_dt.NewRow();
                //b_dr["so_id"] = -1;
                //b_dt.Rows.Add(b_dr);
            }
            dg.P_NS_DG_TC_CBNV_NH(b_nam, b_ma_kdg, b_so_the, b_dt);
            return Fs_NS_DG_TC_CBNV_CT(b_login, b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion GÁN TIÊU CHÍ ĐÁNH GIÁ CHO CBNV

    #region THIẾT LẬP CÔNG THỨC ĐÁNH GIÁ

    [WebMethod(true)]
    public string Fs_NS_DG_CT_FIELDNAME(string b_login)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = new string[] { "chon", "ten", "field_name" };
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, new object[] {
                new string[] { "", "Nhóm tiêu chí", "NVL(MA_NHOM_TC,0)" },
                new string[] { "", "Trọng số nhóm tiêu chí", "NVL(TSO_NHOM,0)" },
                new string[] { "", "Tiêu chí", "NVL(MA_TC,0)" },
                new string[] { "", "Trọng số tiêu chí", "NVL(TSO_TC,0)" },
                new string[] { "", "Định mức L1", "NVL(DMUC_L1,0)" },
                new string[] { "", "Định mức L2", "NVL(DMUC_L2,0)" }
            });
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_CT_CONGTHUC(string b_login)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = new string[] { "ma", "ten" };
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, new object[] {
                new string[] { "CTDGKQTC", "Công thức tính kết quả tiêu chí" },
                new string[] { "CTDGKQNTC", "Công thức tính kết quả nhóm tiêu chí" },
                new string[] { "CTDGKQXL", "Công thức tính xếp loại đánh giá" }
            });
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_CT_CT(string b_login, double b_nam, string b_ma_kdg, string b_ma_plnv, string b_ma_capnv, string b_ma_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_NS_DG_CT_CT(b_nam, b_ma_kdg, b_ma_plnv, b_ma_capnv, b_ma_ct);
            if (b_dt.Rows.Count > 0)
                return b_dt.Rows[0]["SO_ID"] + "#" + b_dt.Rows[0]["CONGTHUC"];
            else
                return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_CT_NH(string b_login, double b_so_id, string b_ma_ct, string b_congthuc, string b_field1, object[] a_dt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            dg.P_NS_DG_CT_NH(ref b_so_id, b_ma_ct, b_congthuc, b_field1, b_dt);
            return b_so_id.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_CT_KT(string b_login, string b_congthuc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = dg.Fdt_NS_DG_CT_KT(b_congthuc);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THIẾT LẬP CÔNG THỨC ĐÁNH GIÁ

    #region [THIẾT LẬP ĐỐI TƯỢNG ĐÁNH GIÁ]
    [WebMethod(true)]
    public string Fs_DG_DM_TLAP_DTUONG_DGIA_CT(string b_login, string b_so_id, string[] a_cot_qlct, string[] a_cot_qlcd, string[] a_cot_qlnc,
                                               string[] a_cot_cdanh_nc, string[] a_cot_cdanh_ct, string[] a_cot_cdanh_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_DM_TLAP_DTUONG_DGIA_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_qlct = b_ds.Tables[5];
            DataTable b_dt_qlcd = b_ds.Tables[6]; DataTable b_dt_qlnc = b_ds.Tables[4];
            DataTable b_dt_cdanh_nc = b_ds.Tables[3]; DataTable b_dt_cdanh_ct = b_ds.Tables[1];
            DataTable b_dt_cdanh_cd = b_ds.Tables[2];
            if (b_dt.Rows.Count > 0)
            {
                var b_nam = b_dt.Rows[0]["NAM"].ToString();
                var b_ky_dg = b_dt.Rows[0]["KY_DG"].ToString();
                var b_nhom_cdanh = b_dt.Rows[0]["NHOM_CDANH"].ToString();
                // load ky danh gia
                DataTable b_dt_lke = dg.Fdt_DG_DM_DTDG_KDG_NHL(b_nam);
                bang.P_THEM_TRANG(ref b_dt_lke, 1, 0);
                se.P_TG_LUU("dg_dm_tlap_dtuong_dgia", "DT_KY_DG", b_dt_lke);
                bang.P_TIM_THEM(ref b_dt, "dg_dm_tlap_dtuong_dgia", "DT_KY_DG", "ky_dg");
                // load nhóm chức danh
                //b_dt_lke = dg.Fdt_NS_MA_DTDG_NCDANH(b_ky_dg);
                //se.P_TG_LUU("dg_dm_tlap_dtuong_dgia", "DT_NHOM_CDANH", b_dt_lke);
                bang.P_TIM_THEM(ref b_dt, "dg_dm_tlap_dtuong_dgia", "DT_NHOM_CDANH", "nhom_cdanh");
                // load chức danh  
                //b_dt_lke = dg.Fdt_CDANH_TLAP_DTDG_DR(b_nam, b_ky_dg, b_nhom_cdanh);
                //bang.P_THEM_TRANG(ref b_dt_lke, 1, 0);
                //se.P_TG_LUU("dg_dm_tlap_dtuong_dgia", "DT_CDANH", b_dt_lke);
                bang.P_TIM_THEM(ref b_dt, "dg_dm_tlap_dtuong_dgia", "DT_CDANH", "cdanh");
            }

            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_qlct_kq = (bang.Fb_TRANG(b_dt_qlct)) ? "" : bang.Fs_BANG_CH(b_dt_qlct, a_cot_qlct);
            string b_dt_qlcd_kq = (bang.Fb_TRANG(b_dt_qlcd)) ? "" : bang.Fs_BANG_CH(b_dt_qlcd, a_cot_qlcd);
            string b_dt_qlnc_kq = (bang.Fb_TRANG(b_dt_qlnc)) ? "" : bang.Fs_BANG_CH(b_dt_qlnc, a_cot_qlnc);
            string b_dt_cdanh_nc_kq = (bang.Fb_TRANG(b_dt_cdanh_nc)) ? "" : bang.Fs_BANG_CH(b_dt_cdanh_nc, a_cot_cdanh_nc);
            string b_dt_cdanh_ct_kq = (bang.Fb_TRANG(b_dt_cdanh_ct)) ? "" : bang.Fs_BANG_CH(b_dt_cdanh_ct, a_cot_cdanh_ct);
            string b_dt_cdanh_cd_kq = (bang.Fb_TRANG(b_dt_cdanh_cd)) ? "" : bang.Fs_BANG_CH(b_dt_cdanh_cd, a_cot_cdanh_cd);
            return b_dt_kq + "#" + b_dt_cdanh_ct_kq + "#" + b_dt_cdanh_cd_kq + "#" + b_dt_cdanh_nc_kq + "#" + b_dt_qlct_kq + "#" + b_dt_qlcd_kq + "#" + b_dt_qlnc_kq;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLAP_DTUONG_DGIA_LKE(string b_login, string b_ncdanh, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = dg.Faobj_DG_DM_TLAP_DTUONG_DGIA_LKE(b_tu_n, b_den_n, b_ncdanh, b_cdanh);
            DataTable b_dt = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLAP_DTUONG_DGIA_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = dg.Faobj_DG_DM_TLAP_DTUONG_DGIA_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLAP_DTUONG_DGIA_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct_ct, object[] a_dt_ct_cd, object[] a_dt_ct_nc,
                                              object[] a_dt_ct_cdanh_nc, object[] a_dt_ct_cdanh_ct, object[] a_dt_ct_cdanh_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_ct_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct_ct[0]); object[] a_gtri_ct_ct = (object[])a_dt_ct_ct[1];
            string[] a_ct_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cd[0]); object[] a_gtri_ct_cd = (object[])a_dt_ct_cd[1];
            string[] a_ct_nc = chuyen.Fas_OBJ_STR((object[])a_dt_ct_nc[0]); object[] a_gtri_ct_nc = (object[])a_dt_ct_nc[1];
            string[] a_ct_cdanh_nc = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cdanh_nc[0]); object[] a_gtri_ct_cdanh_nc = (object[])a_dt_ct_cdanh_nc[1];
            string[] a_ct_cdanh_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cdanh_ct[0]); object[] a_gtri_ct_cdanh_ct = (object[])a_dt_ct_cdanh_ct[1];
            string[] a_ct_cdanh_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct_cdanh_cd[0]); object[] a_gtri_ct_cdanh_cd = (object[])a_dt_ct_cdanh_cd[1];

            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct_ct = bang.Fdt_TAO_THEM(a_ct_ct, a_gtri_ct_ct);
            DataTable b_dt_ct_cd = bang.Fdt_TAO_THEM(a_ct_cd, a_gtri_ct_cd);
            DataTable b_dt_ct_nc = bang.Fdt_TAO_THEM(a_ct_nc, a_gtri_ct_nc);
            DataTable b_dt_ct_cdanh_nc = bang.Fdt_TAO_THEM(a_ct_cdanh_nc, a_gtri_ct_cdanh_nc);
            DataTable b_dt_ct_cdanh_ct = bang.Fdt_TAO_THEM(a_ct_cdanh_ct, a_gtri_ct_cdanh_ct);
            DataTable b_dt_ct_cdanh_cd = bang.Fdt_TAO_THEM(a_ct_cdanh_cd, a_gtri_ct_cdanh_cd);
            bang.P_DON(ref b_dt);
            dg.P_DG_DM_TLAP_DTUONG_DGIA_NH(ref b_so_id, b_dt, b_dt_ct_ct, b_dt_ct_cd, b_dt_ct_nc, b_dt_ct_cdanh_nc, b_dt_ct_cdanh_ct, b_dt_ct_cdanh_cd);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.DG_DM_TLAP_DTUONG_DGIA, TEN_BANG.DG_DM_TLAP_DTUONG_DGIA);
            return Fs_DG_DM_TLAP_DTUONG_DGIA_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_DM_TLAP_DTUONG_DGIA_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); dg.P_DG_DM_TLAP_DTUONG_DGIA_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.DG_DM_TLAP_DTUONG_DGIA, TEN_BANG.DG_DM_TLAP_DTUONG_DGIA);
            return Fs_DG_DM_TLAP_DTUONG_DGIA_LKE(b_login, "", "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TRA_CHON(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null) return form.Fs_LOC_LOI("loi:Chưa chọn bản ghi:loi");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            //bang.P_BO_HANG(ref b_dt_ct, "chon","");
            se.P_TG_LUU("dg_dm_tlap_dtuong_dgia", "DT_CDANH", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_LAY_TRACHON(string b_login, string[] a_cot, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            //se.P_TG_XOA("dg_dm_tlap_dtuong_dgia", "DT_CDANH");
            DataTable b_dt = se.Fdt_TG_TRA("dg_dm_tlap_dtuong_dgia", "DT_CDANH");
            string[] a_cot_tl;
            object[] a_gtri_tl;
            if (a_dt_luoi[0] != "")
            {
                a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
                DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
                bang.P_BO_HANG(ref b_dt_tl, "ma", "");
                foreach (DataRow irow in b_dt_tl.Rows)
                {
                    DataRow[] rows = b_dt.Select("ma ='" + irow[0].ToString() + "'");
                    int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", irow[0].ToString());
                    if (rows.Length <= 0)
                        b_dt.ImportRow(irow);
                    else
                        bang.P_DAT_GTRI(ref b_dt, "chon", "X", b_hang);
                }
            }
            bang.P_XEP(ref b_dt, "ma");
            bang.P_BO_HANG(ref b_dt, "chon", "");
            //se.P_TG_XOA("dg_dm_tlap_dtuong_dgia", "DT_CDANH");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion+

    #region KẾT QUẢ ĐÁNH GIÁ TÍNH LƯƠNG
    [WebMethod(true)]
    public string Fs_DG_KQ_DGIA_THANG_LKE(string b_login, string b_nam, string b_ky_dg, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_Fs_DG_KQ_DGIA_THANG_LKE(b_nam, b_ky_dg, b_phong, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_KQ_DGIA_THANG_NH(string b_login, string b_nam, string b_ky_dg, string b_phong, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            dg.P_Fs_DG_KQ_DGIA_THANG_NH(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_DG_KQ_DGIA_THANG_LKE(b_login, b_nam, b_ky_dg, b_phong, a_tso, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_KQ_DGIA_THANG_TONGHOP(string b_login, string b_nam, string b_ky_dg, string b_phong, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try
        {
            dg.P_Fs_DG_KQ_DGIA_THANG_TONGHOP(b_nam, b_ky_dg, b_phong);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.TONGHOP, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
            return Fs_DG_KQ_DGIA_THANG_LKE(b_login, b_nam, b_ky_dg, b_phong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_KQ_DGIA_THANG_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = dg.Fdt_Fs_DG_KQ_DGIA_THANG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_KQ_DGIA_THANG_XACNHAN(string b_login, object[] a_dt, object[] a_dt_ct, string b_dk)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            // xu ly dòng trùng.
            DataView view = new DataView(b_dt_ct);
            DataTable distinctValues = view.ToTable(true, "so_the");
            if (distinctValues.Rows.Count != b_dt_ct.Rows.Count) return "loi:Nhân viên chỉ được đánh giá 1 lần trong kỳ đánh giá :loi";
            // Gan gtri xac nhan
            bang.P_THAY_GTRI(ref b_dt_ct, "chon", "X", "xacnhan", "X");
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            dg.P_Fs_DG_KQ_DGIA_THANG_XACNHAN(b_dt, b_dt_ct, b_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XACNHAN, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            //return Fs_DG_KQ_DGIA_THANG_MA(b_ma, b_trangKT, a_cot_lke);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region ĐÁNH GIÁ CÔNG VIỆC THÁNG
    [WebMethod(true)]
    public string Fs_NS_DG_CV_THANG_CT(string b_login, string b_so_id, string b_nam1, string b_kydg, string b_ma_nsd, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_DG_CV_THANG_CT(b_so_id, b_nam1, b_kydg, b_ma_nsd);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_d,ngay_dk");
            //Son: load drop trangthai
            string b_nam = b_dt.Rows[0]["nam"].ToString();
            DataTable b_dt_dr = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("dg_cv_thang", "DT_KY_DG", b_dt_dr.Copy());
            bang.P_TIM_THEM(ref b_dt, "dg_cv_thang", "DT_KY_DG", "ky_dg");
            //Son: Tim them cho drop trang thai
            se.P_TG_LUU("dg_cv_thang", "DT_TRANGTHAI", b_dt);
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "CG{Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "0{Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "1{Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "2{Không phê duyệt");
            //
            string b_dt_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_cot = (bang.Fb_TRANG(b_dt_ct)) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot);
            return b_dt_kq + "#" + b_dt_cot;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CV_THANG_LKE(string b_login, string b_nam, string b_trangthai, string b_ma_nsd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = dg.Faobj_NS_DG_CV_THANG_LKE(b_nam, b_trangthai, b_ma_nsd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CV_THANG_MA(string b_login, string b_so_id, string b_nam, string b_trangthai, string b_ma_nsd, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = dg.Faobj_NS_DG_CV_THANG_MA(b_so_id, b_nam, b_trangthai, b_ma_nsd, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_CV_THANG_NH(string b_login, string b_so_id, string b_nam, string b_trangthai, string b_ma_nsd, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            if (a_gtri_ct == null) a_gtri_ct = new object[a_cot_pc.Length];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "ndung_cv", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_d,ngay_dk");
            bang.P_DON(ref b_dt_ct, "stt");
            dg.P_NS_DG_CV_THANG_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_CV_THANG, TEN_BANG.DG_CV_THANG);
            return Fs_NS_DG_CV_THANG_MA(b_login, b_so_id, b_nam, b_trangthai, b_ma_nsd, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_CV_THANG_XOA(string b_login, string b_so_id, string b_ma_nsd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); dg.P_NS_DG_CV_THANG_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.DG_CV_THANG, TEN_BANG.DG_CV_THANG);
            return Fs_NS_DG_CV_THANG_LKE(b_login, "", "", b_ma_nsd, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_CV_THANG_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PDG_CV_THANG_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.DG_CV_THANG, TEN_BANG.DG_CV_THANG);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_CV_THANG_CT_LKE(string b_login, string b_nam, string b_kydg, string[] a_cot_ct, string[] a_cot_nl_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DG_CV_THANG_CT_LKE(b_nam, b_kydg);
            DataTable b_dt_ct = b_ds.Tables[0];
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct)
                   ;
            return b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DG_CV_HT_LAY_HESO_XEPLOAI(string b_login, string b_kq)
    {
        try
        {
            DataTable dtb_heso_xeploai = se.Fdt_TG_TRA("dg_cv_thang", "DT_HS_XL");
            if (bang.Fb_TRANG(dtb_heso_xeploai) == true) return "#";
            string heso = "";
            string xeploai = "";
            foreach (DataRow r in dtb_heso_xeploai.Rows)
            {
                if (r["diemdanhgia_tu"].ToString() != "" && r["diemdanhgia_den"].ToString() != "")
                {
                    if (chuyen.CSO_SO(r["diemdanhgia_tu"].ToString()) <= chuyen.CSO_SO(b_kq) && chuyen.CSO_SO(b_kq) <= chuyen.CSO_SO(r["diemdanhgia_den"].ToString()))
                    {
                        heso = r["heso"].ToString();
                        xeploai = r["xeploai"].ToString();
                    }
                }
            }
            return heso + "#" + xeploai;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Đánh giá KPIS
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_LKE(string b_login, string b_nam, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_DGIA_KPI_NV_LKE(b_nam, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_DGIA_KPI_NV_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_CT(string b_login, string b_so_id, string[] a_cot_ct, string[] a_cot_nl_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DGIA_KPI_NV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1]; DataTable b_dt_nl_ct = b_ds.Tables[2];
            string b_nam = "", b_ky_dg = "";
            if (b_dt.Rows.Count > 0)
            {
                b_nam = b_dt.Rows[0]["nam"].ToString();
                b_ky_dg = b_dt.Rows[0]["ky_dg"].ToString();
            }
            bang.P_TIM_THEM(ref b_dt, "dgia_kpi_nv", "DT_NAM", "nam");
            // load ky dánh giá theo năm
            DataTable b_dt_lke = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL(b_nam);
            se.P_TG_LUU("dgia_kpi_nv", "DT_KY_DG", b_dt_lke);
            bang.P_TIM_THEM(ref b_dt, "dgia_kpi_nv", "DT_KY_DG", "ky_dg");
            // load đợt đánh giá theo kỳ
            DataTable b_dt_ky = dg.Fdt_DG_DM_DTDG_DDG_DG_NHL(b_ky_dg);
            se.P_TG_LUU("dgia_kpi_nv", "DT_DOT_DG", b_dt_ky);
            bang.P_TIM_THEM(ref b_dt, "dgia_kpi_nv", "DT_DOT_DG", "dot_dg");

            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "CG{Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "0{Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "1{Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "2{Không phê duyệt");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                   b_dt_nl_ct_s = bang.Fb_TRANG(b_dt_nl_ct) ? "" : bang.Fs_BANG_CH(b_dt_nl_ct, a_cot_nl_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_nl_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, object[] a_dt_nl_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_nl_ct = chuyen.Fas_OBJ_STR((object[])a_dt_nl_ct[0]); object[] a_gtri_nl_ct = (object[])a_dt_nl_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            DataTable b_dt_nl_ct = bang.Fdt_TAO_THEM(a_cot_nl_ct, a_gtri_nl_ct);
            bang.P_DON(ref b_dt, "nam"); bang.P_DON(ref b_dt_ct, "tieuchi"); bang.P_DON(ref b_dt_nl_ct, "mota");
            dg.PDGIA_KPI_NV_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_nl_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DGIA_KPI_NV, TEN_BANG.DGIA_KPI_NV);
            return Fs_DGIA_KPI_NV_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_GUI(string b_login, string b_so_id, string b_trangthai)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PDGIA_KPI_NV_GUI(b_so_id, b_trangthai);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.DGIA_KPI_NV, TEN_BANG.DGIA_KPI_NV);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_XOA(string b_login, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PDGIA_KPI_NV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.DGIA_KPI_NV, TEN_BANG.DGIA_KPI_NV);
            return Fs_DGIA_KPI_NV_LKE(b_login, b_trangthai, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_DGIA_KPI_NV_QLXX_CT_KPI_LKE(string b_login, string b_nam, string b_kydg, string[] a_cot_ct, string[] a_cot_nl_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_DGIA_KPI_NV_QLXX_CT_KPI_LKE(b_nam, b_kydg);
            DataTable b_dt_ct = b_ds.Tables[0]; DataTable b_dt_nl_ct = b_ds.Tables[1];
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                    b_dt_nl_ct_s = bang.Fb_TRANG(b_dt_nl_ct) ? "" : bang.Fs_BANG_CH(b_dt_nl_ct, a_cot_nl_ct);
            return b_dt_ct_s + "#" + b_dt_nl_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CBNV NHẬP CHỈ TIÊU GIAO KPIS

    #region CB Đánh giá KPIS
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_LKE(string b_login, string b_nam, string b_trangthai, string b_kydg, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Faobj_NS_CB_DGIA_KPI_NV_LKE(b_nam, b_trangthai, b_kydg, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = dg.Faobj_NS_CB_DGIA_KPI_NV_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "0", "Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "1", "Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_CT(string b_login, string b_so_id, string[] a_cot_ct, string[] a_cot_nl_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_CB_DGIA_KPI_NV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1]; DataTable b_dt_nl_ct = b_ds.Tables[2];

            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "CG{Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "0{Chờ xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "1{Đã xem xét");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "2{Không phê duyệt");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                   b_dt_nl_ct_s = bang.Fb_TRANG(b_dt_nl_ct) ? "" : bang.Fs_BANG_CH(b_dt_nl_ct, a_cot_nl_ct);
            return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_nl_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, object[] a_dt_nl_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_nl_ct = chuyen.Fas_OBJ_STR((object[])a_dt_nl_ct[0]); object[] a_gtri_nl_ct = (object[])a_dt_nl_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            DataTable b_dt_nl_ct = bang.Fdt_TAO_THEM(a_cot_nl_ct, a_gtri_nl_ct);
            //bang.P_BO_HANG(ref b_dt_ct, "stt", "");
            //if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            //{
            //    return Thongbao_dch.nhapdulieu_luoi;
            //}
            bang.P_DON(ref b_dt, "nam"); bang.P_DON(ref b_dt_ct, "so_id"); bang.P_DON(ref b_dt_nl_ct, "so_id");
            dg.PNS_CB_DGIA_KPI_NV_NH(ref b_so_id, b_dt, b_dt_ct, b_dt_nl_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CB_DGIA_KPI_NV, TEN_BANG.NS_CB_DGIA_KPI_NV);
            return Fs_NS_CB_DGIA_KPI_NV_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_GUI(string b_login, string b_so_id, string b_trangthai)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); dg.PNS_CB_DGIA_KPI_NV_GUI(b_so_id, b_trangthai);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_CB_DGIA_KPI_NV, TEN_BANG.NS_CB_DGIA_KPI_NV);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_XOA(string b_login, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); dg.PNS_CB_DGIA_KPI_NV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CB_DGIA_KPI_NV, TEN_BANG.NS_CB_DGIA_KPI_NV);
            return Fs_NS_CB_DGIA_KPI_NV_LKE(b_login, "", b_trangthai, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_DGIA_KPI_NV_CT_LKE(string b_login, string b_nam, string b_kydg, string[] a_cot_ct, string[] a_cot_nl_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = dg.Fds_NS_CB_DGIA_KPI_NV_CT_LKE(b_nam, b_kydg);
            DataTable b_dt_ct = b_ds.Tables[0]; DataTable b_dt_nl_ct = b_ds.Tables[1];
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                    b_dt_nl_ct_s = bang.Fb_TRANG(b_dt_nl_ct) ? "" : bang.Fs_BANG_CH(b_dt_nl_ct, a_cot_nl_ct);
            return b_dt_ct_s + "#" + b_dt_nl_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CB_DGIA_KPI_LAY_HESO_XEPLOAI(string b_login, string b_kq)
    {
        try
        {
            DataTable dtb_heso_xeploai = se.Fdt_TG_TRA("ns_cb_dgia_kpi_nv", "DT_HS_XL");
            if (bang.Fb_TRANG(dtb_heso_xeploai) == true) return "#";
            string heso = "";
            string xeploai = "";
            foreach (DataRow r in dtb_heso_xeploai.Rows)
            {
                if (r["diemdanhgia_tu"].ToString() != "" && r["diemdanhgia_den"].ToString() != "")
                {
                    if (chuyen.CSO_SO(r["diemdanhgia_tu"].ToString()) <= chuyen.CSO_SO(b_kq) && chuyen.CSO_SO(b_kq) <= chuyen.CSO_SO(r["diemdanhgia_den"].ToString()))
                    {
                        heso = r["heso"].ToString();
                        xeploai = r["xeploai"].ToString();
                    }
                }
            }
            return heso + "#" + xeploai;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region KẾT QUẢ ĐÁNH GIÁ
    [WebMethod(true)]
    public string Fs_DG_NGV_KQUA_DG_KPI_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nam, string b_ky_dg, string b_phong)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = dg.Fdt_DG_NGV_KQUA_DG_KPI_LKE(1, 9999, b_nam, b_ky_dg, b_phong);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_xac_nhan", "xac_nhan");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_xac_nhan", "0", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_xac_nhan", "1", "Đã xác nhận");

            bang.P_THAY_GTRI(ref b_dt_tk, "ten_xac_nhan_ns", "0", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_xac_nhan_ns", "1", "Đã xác nhận");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_XACNHAN_KPI_NV_NH(string b_login, string b_thaotac, string b_nam, string b_ky_dg, string b_phong, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "CHON", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.ChonDuLieu_xacnhan;
            }
            if (b_thaotac == "XN") // kiểm tra nếu bấm nút xác nhận thì update trạng thái cột nhân sự xác nhận bằng 1
            {
                foreach (DataRow b_dr in b_dt_ct.Rows)
                {
                    b_dr["TRANGTHAI"] = "1";
                }
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XACNHAN, TEN_FORM.DG_NGV_KQUA_DG_KPI, TEN_BANG.DG_NGV_KQUA_DG_KPI);

            }
            else
            {
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.DG_NGV_KQUA_DG_KPI, TEN_BANG.DG_NGV_KQUA_DG_KPI);
            }

            dg.PNS_XACNHAN_KPI_NV_NH(b_dt, b_dt_ct);
            return Fs_DG_NGV_KQUA_DG_KPI_LKE(b_login, a_tso, a_cot_lke, b_nam, b_ky_dg, b_phong);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion
}
