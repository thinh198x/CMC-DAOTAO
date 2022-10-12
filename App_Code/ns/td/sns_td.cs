using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;

[System.Web.Script.Services.ScriptService]
public class sns_td : System.Web.Services.WebService
{
    #region KẾ HOẠCH TUYỂN DỤNG NĂM
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_LKE(string b_login, string b_nam_tk, string donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_NAM_LKE(b_nam_tk, donvi_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_MA(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_NAM_MA(b_so_id, b_nam_tk, b_donvi_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_KH_NAM_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngaycan_ns"); bang.P_SO_CSO(ref b_dt, "sl_cantuyen");
            bang.P_TIM_THEM(ref b_dt, "ns_td_kh_nam", "DT_DONVI", "DONVI");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_ban = chuyen.OBJ_S(b_row["BAN"]), b_ten_ban = chuyen.OBJ_S(b_row["TEN_BAN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                string b_capbac = chuyen.OBJ_S(b_row["CAPBAC"]), b_ten_capbac = chuyen.OBJ_S(b_row["TEN_CAPBAC"]);
                b_row["BAN"] = b_ban + "{" + b_ten_ban;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
                b_row["CAPBAC"] = b_capbac + "{" + b_ten_capbac;
            }
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_BY_PHONG(string b_login, string b_nam, string b_donvi, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_so_id = "";
            object[] a_obj = ns_td.Fdt_NS_TD_KH_NAM_BY_PHONG(b_nam, b_donvi);
            DataTable b_dt = (DataTable)a_obj[0];
            if (b_dt.Rows.Count > 0) b_so_id = chuyen.OBJ_S(b_dt.Rows[0]["so_id"]);

            bang.P_SO_CNG(ref b_dt, "ngaycan_ns"); bang.P_SO_CSO(ref b_dt, "sl_cantuyen");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_ban = chuyen.OBJ_S(b_row["BAN"]), b_ten_ban = chuyen.OBJ_S(b_row["TEN_BAN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                string b_capbac = chuyen.OBJ_S(b_row["CAPBAC"]), b_ten_capbac = chuyen.OBJ_S(b_row["TEN_CAPBAC"]);
                b_row["BAN"] = b_ban + "{" + b_ten_ban;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
                b_row["CAPBAC"] = b_capbac + "{" + b_ten_capbac;
            }
            return b_so_id + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_NH(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "cdanh", "");
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            int b_i = 0;
            foreach (DataRow drow in b_dt_dk.Rows)
            {
                if (drow["MA_KH"].Equals(""))
                {
                    string b_ma_ts = ht_dungchung.Fdt_AutoGenCode("KHN", "NS_TD_KH_NAM", "MA_KH");
                    int b_item = int.Parse(b_ma_ts.Substring(3, 3));
                    drow["MA_KH"] = "KHN" + string.Format("{0:000}", b_item + b_i);
                    b_i = b_i + 1;
                }
            }

            bang.P_CNG_SO(ref b_dt_dk, "ngaycan_ns"); 
            bang.P_CSO_SO(ref b_dt_dk, "sl_cantuyen,ns_t1,ns_t2,ns_t3,ns_t4,ns_t5,ns_t6,ns_t7,ns_t8,ns_t9,ns_t10,ns_t11,ns_t12");
            ns_td.P_NS_TD_KH_NAM_NH(ref b_so_id, b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KH_NAM, TEN_BANG.NS_TD_KH_NAM);
            return Fs_NS_TD_KH_NAM_MA(b_login, b_so_id, b_nam_tk, b_donvi_tk, b_trangKT, a_cot_lke);
        }

        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_NAM_XOA(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_KH_NAM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_KH_NAM, TEN_BANG.NS_TD_KH_NAM);
            return Fs_NS_TD_KH_NAM_LKE(b_login, b_nam_tk, b_donvi_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NHOM_CD_KH_NAM(string b_login, string b_congty, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_dungchung.Fdt_MA_CAPBAC_BY_CDANH_DR_GR(b_congty, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return (bang.Fb_TRANG(b_dt)) ? "" : b_dt.Rows.Count.ToString() + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    // trả giá trị số lượng cần tuyển
    [WebMethod(true)]
    public string Fs_NS_TD_LAY_DINHBIEN(string b_phong, string b_chucdanh, string b_nam)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_LAY_DINHBIEN(b_phong, b_chucdanh, b_nam);
            //DataTable b_dt_ht = hts_dungchung.Fdt_NS_TONG_NHANSU(chuyen.CSO_SO(b_nam), b_phong, b_chucdanh);
            double b_ns_ht = 0, b_tong_db = 0;
            //if (b_dt_ht.Rows.Count > 0) b_ns_ht = chuyen.CSO_SO(b_dt_ht.Rows[0]["tong"].ToString());
            if (b_dt.Rows.Count > 0)
            {
                b_tong_db = chuyen.CSO_SO(b_dt.Rows[0]["tong_dbien"].ToString());
                b_ns_ht = chuyen.CSO_SO(b_dt.Rows[0]["ns_hientai"].ToString());
            }
            var b_kq = b_tong_db - b_ns_ht;
            return b_kq.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion KÊ HOẠCH TUYỂN DỤNG NĂM

    #region KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCHUYEN_BNHIEM_LKE(string b_login, string b_nam_tk, string donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_DCHUYEN_BNHIEM_LKE(b_nam_tk, donvi_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCHUYEN_BNHIEM_MA(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_DCHUYEN_BNHIEM_MA(b_so_id, b_nam_tk, b_donvi_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCHUYEN_BNHIEM_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_KH_DCHUYEN_BNHIEM_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "NS_TD_KH_DCHUYEN_BNHIEM", "DT_DONVI", "DONVI");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
            }
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCHUYEN_BNHIEM_NH(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "cdanh", "");
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            int b_i = 0;
            foreach (DataRow drow in b_dt_dk.Rows)
            {
                if (drow["MA_KH"].Equals(""))
                {
                    string b_ma_ts = ht_dungchung.Fdt_AutoGenCode("KHN", "NS_TD_KH_DCHUYEN_BNHIEM", "MA_KH");
                    int b_item = int.Parse(b_ma_ts.Substring(3, 3));
                    drow["MA_KH"] = "KHN" + string.Format("{0:000}", b_item + b_i);
                    b_i = b_i + 1;
                }
            }

            ns_td.P_NS_TD_KH_DCHUYEN_BNHIEM_NH(ref b_so_id, b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KH_DCHUYEN_BNHIEM, TEN_BANG.NS_TD_KH_DCHUYEN_BNHIEM);
            return Fs_NS_TD_KH_DCHUYEN_BNHIEM_MA(b_login, b_so_id, b_nam_tk, b_donvi_tk, b_trangKT, a_cot_lke);
        }

        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCHUYEN_BNHIEM_XOA(string b_login, string b_so_id, string b_nam_tk, string b_donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_KH_DCHUYEN_BNHIEM_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_KH_DCHUYEN_BNHIEM, TEN_BANG.NS_TD_KH_DCHUYEN_BNHIEM);
            return Fs_NS_TD_KH_DCHUYEN_BNHIEM_LKE(b_login, b_nam_tk, b_donvi_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM

    #region THÔNG TIN PHÒNG BAN - ỨNG VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_INFO_DEV_NH(string b_login, string b_so_id, string b_phong_tk, string b_cdanh_tk, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null)
                b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else
            {
                b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
                //bang.P_DON(ref b_dt_dk); 
            }
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt_ct, "ngay_hl");
            bang.P_BO_HANG(ref b_dt_dk, "cong_ty_ct", "");
            bang.P_CNG_SO(ref b_dt_dk, "ngay_hl_ct");
            bang.P_CSO_SO(ref b_dt_dk, "luong_ct");
            ns_td.P_NS_TD_INFO_DEV_NH(ref b_so_id, b_dt_ct, b_dt_dk);
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_INFO_DEV, TEN_BANG.NS_TD_INFO_DEV);
            return Fs_NS_TD_INFO_DEV_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }

        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_INFO_DEV_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_INFO_DEV_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "luong");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + a_obj[0] + "#" + a_obj[1] + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_INFO_DEV_XOA(string b_login, string b_so_id, string b_phong_tk, string b_cdanh_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_INFO_DEV_XOA(b_so_id);
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_INFO_DEV, TEN_BANG.NS_TD_INFO_DEV);
            return Fs_NS_TD_INFO_DEV_LKE(b_login, b_phong_tk, b_cdanh_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_INFO_DEV_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fdt_NS_TD_INFO_DEV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            bang.P_SO_CSO(ref b_dt, "luong");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_hl_ct");
            bang.P_SO_CSO(ref b_dt_ct, "luong_ct");
            bang.P_TIM_THEM(ref b_dt, "ns_td_info_dev", "DT_PHONG", "PHONG");
            bang.P_TIM_THEM(ref b_dt, "ns_td_info_dev", "DT_CDANH", "CDANH");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_td_info_dev", "DT_CONGTY", "CONG_TY_CT");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_td_info_dev", "DT_PHONG_CT", "PHONG_CT");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_td_info_dev", "DT_CDANH_CT", "CDANH_CT");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_INFO_DEV_LKE(string b_login, string b_phong_tk, string b_cdanh_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_INFO_DEV_LKE(b_phong_tk, b_cdanh_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_hl");
            bang.P_SO_CSO(ref b_dt_tk, "luong");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]

    public string Fs_NS_TD_INFO_DEV_BY_PHONG(string b_login, string b_phong_ct, string b_cdanh_ct, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_so_id = "";
            object[] a_obj = ns_td.Fdt_NS_TD_INFO_DEV_BY_PHONG(b_phong_ct, b_cdanh_ct);
            DataTable b_dt = (DataTable)a_obj[0];
            if (b_dt.Rows.Count > 0) b_so_id = chuyen.OBJ_S(b_dt.Rows[0]["so_id"]);

            bang.P_SO_CNG(ref b_dt, "ngaycan_ns"); bang.P_SO_CSO(ref b_dt, "sl_cantuyen");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_ban = chuyen.OBJ_S(b_row["BAN"]), b_ten_ban = chuyen.OBJ_S(b_row["TEN_BAN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                string b_capbac = chuyen.OBJ_S(b_row["CAPBAC"]), b_ten_capbac = chuyen.OBJ_S(b_row["TEN_CAPBAC"]);
                b_row["BAN"] = b_ban + "{" + b_ten_ban;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
                b_row["CAPBAC"] = b_capbac + "{" + b_ten_capbac;
            }
            return b_so_id + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NHOM_CD_INFO_DEV(string b_login, string b_congty, double[] a_tso)
    {
        try
        {
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion THÔNG TIN PHÒNG BAN - ỨNG VIÊN

    #region KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_LKE(string b_login, string b_nam_tk, string donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_DCBN_LKE(b_nam_tk, donvi_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_MA(string b_login, string b_so_id, string b_DCBN_tk, string b_donvi_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_KH_DCBN_MA(b_so_id, b_DCBN_tk, b_donvi_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_KH_DCBN_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngaycan_ns"); bang.P_SO_CSO(ref b_dt, "sl_cantuyen");
            bang.P_TIM_THEM(ref b_dt, "ns_td_kh_DCBN", "DT_DONVI", "DONVI");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_ban = chuyen.OBJ_S(b_row["BAN"]), b_ten_ban = chuyen.OBJ_S(b_row["TEN_BAN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                string b_capbac = chuyen.OBJ_S(b_row["CAPBAC"]), b_ten_capbac = chuyen.OBJ_S(b_row["TEN_CAPBAC"]);
                b_row["BAN"] = b_ban + "{" + b_ten_ban;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
                b_row["CAPBAC"] = b_capbac + "{" + b_ten_capbac;
            }
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_BY_PHONG(string b_login, string b_DCBN, string b_donvi, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_so_id = "";
            object[] a_obj = ns_td.Fdt_NS_TD_KH_DCBN_BY_PHONG(b_DCBN, b_donvi);
            DataTable b_dt = (DataTable)a_obj[0];
            if (b_dt.Rows.Count > 0) b_so_id = chuyen.OBJ_S(b_dt.Rows[0]["so_id"]);

            bang.P_SO_CNG(ref b_dt, "ngaycan_ns"); bang.P_SO_CSO(ref b_dt, "sl_cantuyen");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_ban = chuyen.OBJ_S(b_row["BAN"]), b_ten_ban = chuyen.OBJ_S(b_row["TEN_BAN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH"]);
                string b_capbac = chuyen.OBJ_S(b_row["CAPBAC"]), b_ten_capbac = chuyen.OBJ_S(b_row["TEN_CAPBAC"]);
                b_row["BAN"] = b_ban + "{" + b_ten_ban;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
                b_row["CAPBAC"] = b_capbac + "{" + b_ten_capbac;
            }
            return b_so_id + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_NH(string b_login, string b_so_id, string b_DCBN_tk, string b_donvi_tk, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "ban", "");
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            int b_i = 0;
            foreach (DataRow drow in b_dt_dk.Rows)
            {
                if (drow["MA_KH"].Equals(""))
                {
                    string b_ma_ts = ht_dungchung.Fdt_AutoGenCode("KHN", "NS_TD_KH_DCBN", "MA_KH");
                    int b_item = int.Parse(b_ma_ts.Substring(3, 3));
                    drow["MA_KH"] = "KHN" + string.Format("{0:000}", b_item + b_i);
                    b_i = b_i + 1;
                }
            }

            bang.P_CNG_SO(ref b_dt_dk, "ngaycan_ns"); bang.P_CSO_SO(ref b_dt_dk, "sl_cantuyen");
            ns_td.P_NS_TD_KH_DCBN_NH(ref b_so_id, b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KH_DCBN, TEN_BANG.NS_TD_KH_DCBN);
            return Fs_NS_TD_KH_DCBN_MA(b_login, b_so_id, b_DCBN_tk, b_donvi_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_DCBN_XOA(string b_login, string b_so_id, string b_DCBN_tk, string b_donvi_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_KH_DCBN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_KH_DCBN, TEN_BANG.NS_TD_KH_DCBN);
            return Fs_NS_TD_KH_DCBN_LKE(b_login, b_DCBN_tk, b_donvi_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NHOM_CD_KH_DCBN(string b_login, string b_congty, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_dungchung.Fdt_MA_CAPBAC_BY_CDANH_DR_GR(b_congty, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return (bang.Fb_TRANG(b_dt)) ? "" : b_dt.Rows.Count.ToString() + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    // trả giá trị số lượng cần tuyển
    //[WebMethod(true)]
    //public string Fs_NS_TD_LAY_DINHBIEN(string b_phong, string b_chucdanh, string b_DCBN)
    //{
    //    try
    //    {
    //        DataTable b_dt = ns_td.Fdt_NS_TD_LAY_DINHBIEN(b_phong, b_chucdanh, b_DCBN);
    //        //DataTable b_dt_ht = hts_dungchung.Fdt_NS_TONG_NHANSU(chuyen.CSO_SO(b_DCBN), b_phong, b_chucdanh);
    //        double b_ns_ht = 0, b_tong_db = 0;
    //        //if (b_dt_ht.Rows.Count > 0) b_ns_ht = chuyen.CSO_SO(b_dt_ht.Rows[0]["tong"].ToString());
    //        if (b_dt.Rows.Count > 0)
    //        {
    //            b_tong_db = chuyen.CSO_SO(b_dt.Rows[0]["tong_dbien"].ToString());
    //            b_ns_ht = chuyen.CSO_SO(b_dt.Rows[0]["ns_hientai"].ToString());
    //        }
    //        var b_kq = b_tong_db - b_ns_ht;
    //        return b_kq.ToString();
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    //}

    #endregion KẾ HOẠCH ĐIỀU CHUYỂN BỔ NHIỆM

    #region LÃNH ĐẠO ĐỀ XUẤT TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_TD_KH_NAM_BYSORT(string b_login, string b_nam, string b_donvi, string b_ban, string b_phong, string b_cdanh, string b_form, string b_ten)
    {
        se.P_LOGIN(b_login);
        DataTable b_dt = ns_td.Fdt_TD_KH_NAM_BYSORT(b_nam, b_donvi, b_ban, b_phong, b_cdanh);
        se.P_TG_LUU(b_form, b_ten, b_dt.Copy());
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_TD_KH_NAM_BY_ID(string b_login, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_sl_cantuyen = "";
            DataTable b_dt = ns_td.Fdt_TD_KH_NAM_BY_ID(b_so_id);
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_sl_cantuyen = b_dt.Rows[0]["sl_cantuyen"].ToString();

            }
            return b_sl_cantuyen;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_DBIEN_BY_CDANH(string b_login, string b_nam, string b_cdanh)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_ns_hientai = "";
            DataTable b_dt = ns_td.Fdt_HDNS_DBIEN_BY_CDANH(b_nam, b_cdanh);
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_ns_hientai = b_dt.Rows[0]["ns_hientai"].ToString();

            }
            return b_ns_hientai;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_DBIEN_BY_PHONGBAN(string b_login, string b_nam, string b_donvi, string b_ban, string b_phong)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_tong_dbien = "";
            DataTable b_dt = ns_td.Fdt_HDNS_DBIEN_BY_PHONGBAN(b_nam, b_donvi, b_ban, b_phong);
            if (b_dt.Rows.Count > 0 && b_dt != null)
            {
                b_tong_dbien = b_dt.Rows[0]["tong_dbien"].ToString();

            }
            return b_tong_dbien;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_LKE(string b_login, string b_nam, string b_phong, string b_trangthai_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_DEXUAT_CN_LKE(b_nam, b_phong, b_trangthai_pd, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_can_ns");
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai_pd", "trangthai_pd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "-1", " ");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "2", "Không phê duyệt");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot); ;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_MA(string b_login, string b_nam, string b_phong, string b_trangthai_pd, string b_so_id, double b_trangkt, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_DEXUAT_CN_MA(b_nam, b_phong, b_trangthai_pd, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_can_ns");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai_pd", "trangthai_pd");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "-1", " ");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_CT(string b_login, string b_so_id, string[] a_cot, string[] a_cot_hd)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_DEXUAT_CN_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CSO(ref b_dt, "mucluong_tu,mucluong_den"); bang.P_SO_CNG(ref b_dt, new string[] { "ngay_dexuat,ngay_can_ns,ngay_pd" });
            bang.P_SO_CSO(ref b_dt, "trangthai_pd");
            var b_nam = b_dt.Rows[0]["NAM"].ToString();
            var b_dvi = b_dt.Rows[0]["DONVI"].ToString();
            var b_ban = b_dt.Rows[0]["BAN"].ToString();
            var b_phong = b_dt.Rows[0]["PHONG"].ToString();
            var b_cdanh = b_dt.Rows[0]["CDANH"].ToString();

            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_DONVI", "DONVI");

            DataTable b_dt_load = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_dvi, 2);
            se.P_TG_LUU("ns_td_dexuat_cn", "DT_BAN", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_BAN", "BAN");

            b_dt_load = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_ban, 3);
            se.P_TG_LUU("ns_td_dexuat_cn", "DT_PHONG", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_PHONG", "PHONG");

            b_dt_load = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            se.P_TG_LUU("ns_td_dexuat_cn", "DT_CDANH", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_CDANH", "CDANH");

            b_dt_load = ns_td.Fdt_TD_KH_NAM_BYSORT(b_nam, b_dvi, b_ban, b_phong, b_cdanh);
            se.P_TG_LUU("ns_td_dexuat_cn", "DT_KEHOACH_NAM", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_KEHOACH_NAM", "KEHOACH_NAM");


            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_NGUOICHIU_TN", "NGUOICHIU_TN");
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat_cn", "DT_KINHNGHIEM", "KINHNGHIEM");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_td_dexuat_cn", "DT_LHD", "LHD");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_hd);
            return b_dt_s + "#" + b_dt_tt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_GUI(string b_login, string b_so_id, string b_nam, string b_phong, string b_trangthai_pd, double b_trangKT, object[] a_dt_ct, object[] a_dt_hd, string[] a_cot_lke, string[] a_cot_hd)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dexuat,ngay_can_ns,ngay_pd");
            bang.P_CSO_SO(ref b_dt_ct, "nam,soluong_td,db_duocduyet,sl_hientai,mucluong_tu,mucluong_den");
            if (b_so_id == "") b_so_id = "0";
            string[] a_cot_mt = chuyen.Fas_OBJ_STR((object[])a_dt_hd[0]); object[] a_gtri_mt = (object[])a_dt_hd[1];
            DataTable b_dt_mt = bang.Fdt_TAO_THEM(a_cot_mt, a_gtri_mt);
            bang.P_BO_HANG(ref b_dt_mt, "sott", "");
            if (b_dt_mt == null || b_dt_mt.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_td.P_NS_TD_DEXUAT_CN_GUI(ref b_so_id, b_dt_ct, b_dt_mt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_TD_DEXUAT_CN, TEN_BANG.NS_TD_DEXUAT_CN);
            return Fs_NS_TD_DEXUAT_CN_MA(b_login, b_nam, b_phong, b_trangthai_pd, b_so_id, b_trangKT, a_cot_lke, a_cot_hd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_NH(string b_login, string b_so_id, string b_nam, string b_phong, string b_trangthai_pd, double b_trangKT, object[] a_dt_ct, object[] a_dt_hd, string[] a_cot_lke, string[] a_cot_hd)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dexuat,ngay_can_ns,ngay_pd");
            bang.P_CSO_SO(ref b_dt_ct, "nam,soluong_td,db_duocduyet,sl_hientai,mucluong_tu,mucluong_den");
            if (b_so_id == "") b_so_id = "0";
            string[] a_cot_mt = chuyen.Fas_OBJ_STR((object[])a_dt_hd[0]); object[] a_gtri_mt = (object[])a_dt_hd[1];
            DataTable b_dt_mt = bang.Fdt_TAO_THEM(a_cot_mt, a_gtri_mt);
            bang.P_BO_HANG(ref b_dt_mt, "sott", "");
            if (b_dt_mt == null || b_dt_mt.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_td.P_NS_TD_DEXUAT_CN_NH(ref b_so_id, b_dt_ct, b_dt_mt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_DEXUAT_CN, TEN_BANG.NS_TD_DEXUAT_CN);
            return Fs_NS_TD_DEXUAT_CN_MA(b_login, b_nam, b_phong, b_trangthai_pd, b_so_id, b_trangKT, a_cot_lke, a_cot_hd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CN_XOA(string b_login, string b_so_id, string b_nam, string b_phong, string b_trangthaipd, double[] a_tso, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_DEXUAT_CN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_DEXUAT_CN, TEN_BANG.NS_TD_DEXUAT_CN);
            return Fs_NS_TD_DEXUAT_CN_LKE(b_login, b_nam, b_phong, b_trangthaipd, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion LÃNH ĐẠO ĐỀ XUẤT TUYỂN DỤNG

    #region CBNS NHẬP ĐỀ XUẤT TUYỂN DỤNG

    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_LKE(string b_login, string b_nam, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_DEXUAT_LKE(b_nam, b_phong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_can_ns");
            bang.P_COPY_COL(ref b_dt_tk, "ten_trangthai_pd", "trangthai_pd");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_trangthai_pd", "2", "Không phê duyệt");
            return bang.Fb_TRANG(b_dt_tk) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot); ;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_MA(string b_login, string b_nam, string b_phong, string b_so_id, double b_trangkt, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_DEXUAT_MA(b_nam, b_phong, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_can_ns");
            bang.P_COPY_COL(ref b_dt, "ten_trangthai_pd", "trangthai_pd");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai_pd", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_CT(string b_login, string b_so_id, string[] a_cot, string[] a_cot_hd)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_DEXUAT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CSO(ref b_dt, "mucluong_tu,mucluong_den"); bang.P_SO_CNG(ref b_dt, new string[] { "ngay_dexuat,ngay_can_ns,ngay_pd" });
            bang.P_SO_CSO(ref b_dt, "trangthai_pd");
            var b_nam = b_dt.Rows[0]["NAM"].ToString();
            var b_dvi = b_dt.Rows[0]["DONVI"].ToString();
            var b_ban = b_dt.Rows[0]["BAN"].ToString();
            var b_phong = b_dt.Rows[0]["PHONG"].ToString();
            var b_cdanh = b_dt.Rows[0]["CDANH"].ToString();

            //bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_DONVI", "DONVI");

            //DataTable b_dt_load = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_dvi, 2);
            //se.P_TG_LUU("ns_td_dexuat", "DT_BAN", b_dt_load.Copy());
            //bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_BAN", "BAN");

            //b_dt_load = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_ban, 3);
            //se.P_TG_LUU("ns_td_dexuat", "DT_PHONG", b_dt_load.Copy());

            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_PHONG", "PHONG");

            DataTable b_dt_load = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            se.P_TG_LUU("ns_td_dexuat", "DT_CDANH", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_CDANH", "CDANH");

            b_dt_load = ns_td.Fdt_TD_KH_NAM_BYSORT(b_nam, b_dvi, b_ban, b_phong, b_cdanh);
            se.P_TG_LUU("ns_td_dexuat", "DT_KEHOACH_NAM", b_dt_load.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_KEHOACH_NAM", "KEHOACH_NAM");


            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_NGUOICHIU_TN", "NGUOICHIU_TN");
            bang.P_TIM_THEM(ref b_dt, "ns_td_dexuat", "DT_KINHNGHIEM", "KINHNGHIEM");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_td_dexuat", "DT_LHD", "LHD");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_hd);
            return b_dt_s + "#" + b_dt_tt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_NH(string b_login, string b_so_id, string b_nam, string b_phong, double b_trangKT, object[] a_dt_ct, object[] a_dt_hd, string[] a_cot_lke, string[] a_cot_hd)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dexuat,ngay_can_ns,ngay_pd");
            bang.P_CSO_SO(ref b_dt_ct, "nam,soluong_td,db_duocduyet,sl_hientai,mucluong_tu,mucluong_den");
            if (b_so_id == "") b_so_id = "0";
            string[] a_cot_mt = chuyen.Fas_OBJ_STR((object[])a_dt_hd[0]); object[] a_gtri_mt = (object[])a_dt_hd[1];
            DataTable b_dt_mt = bang.Fdt_TAO_THEM(a_cot_mt, a_gtri_mt);
            //bang.P_BO_HANG(ref b_dt_mt, "sott", "");
            //if (b_dt_mt == null || b_dt_mt.Rows.Count <= 0)
            //{
            //    return Thongbao_dch.nhapdulieu_luoi;
            //}
            bang.P_CSO_SO(ref b_dt_mt, "sott,soluong");
            ns_td.P_NS_TD_DEXUAT_NH(ref b_so_id, b_dt_ct, b_dt_mt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_DEXUAT, TEN_BANG.NS_TD_DEXUAT);
            return Fs_NS_TD_DEXUAT_MA(b_login, b_nam, b_phong, b_so_id, b_trangKT, a_cot_lke, a_cot_hd);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_XOA(string b_login, string b_so_id, string b_nam, string b_phong, double[] a_tso, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_DEXUAT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_DEXUAT, TEN_BANG.NS_TD_DEXUAT);
            return Fs_NS_TD_DEXUAT_LKE(b_login, b_nam, b_phong, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region PHÊ DUYỆT ĐỀ XUẤT TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_PD_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_td.Fdt_NS_TD_DEXUAT_PD_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "ngay_dexuat");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_PD_PHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "CHON", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DXTD" });
            DataTable b_dt_kq = ns_td.Fdt_NS_TD_DEXUAT_PD_PHEDUYET(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_TD_DXUAT_PD, TEN_BANG.NS_TD_DXUAT_PD);

            string b_guimail = "";
            if (b_dt_kq.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_dt_kq.Rows[0]["email"]);
                string b_subject = chuyen.OBJ_S(b_dt_kq.Rows[0]["ten"]) + " - Có đề xuất tuyển dụng cần phê duyệt";
                string b_body = "Bạn có đề xuất tuyển dụng cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://hrm.cerp.vn để phê duyệt! \n";
                b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            }
            return "";
        }
        catch (Exception) { return Thongbao_dch.Pheduyet_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_PD_KOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "CHON", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            ns_td.Fdt_NS_TD_DEXUAT_PD_KOPHEDUYET(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_TD_DXUAT_PD, TEN_BANG.NS_TD_DXUAT_PD);
            return "";
        }
        catch (Exception) { return Thongbao_dch.koPheduyet_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_PD_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_DEXUAT_PD_CT(b_so_id);
            bang.P_SO_CSO(ref b_dt, "db_duocduyet,soluong_td");
            bang.P_SO_CNG(ref b_dt, "ngay_dexuat");
            string b_phong = "", b_chucdanh = "", b_duoctuyen = "", b_ngay_dx = "", b_soluong_tuyen = "";
            string b_kq = "";
            if (b_dt.Rows.Count > 0)
            {

                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    b_phong = b_dt.Rows[i]["phong_ten"].ToString();
                    b_chucdanh = b_dt.Rows[i]["cdanh_ten"].ToString();
                    b_duoctuyen = b_dt.Rows[i]["db_duocduyet"].ToString();
                    b_ngay_dx = b_dt.Rows[i]["ngay_dexuat"].ToString();
                    b_soluong_tuyen = b_dt.Rows[i]["soluong_td"].ToString();
                    b_kq = "\n\b(*) Phòng: " + b_phong + "\n\b  - Chức danh: " + b_chucdanh + "\n\b  - Số lượng tuyển dụng: " + b_duoctuyen + "\n\b  - Ngày đề xuất: " + b_ngay_dx + "\n\b  - Định biên được duyệt: " + b_soluong_tuyen;
                }
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion PHÊ DUYỆT ĐỀ XUẤT TUYỂN DỤNG

    #region KẾ HOẠCH TUYỂN DỤNG CHI TIẾT
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_LKE(string b_login, string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma_yc, double[] a_tso, string[] a_cot, string[] a_cot_ct, string[] a_cot_pa)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KHCT_LKE(b_nam, b_thang, b_phong, b_cdanh, b_ma_yc, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai_pd", "0", "Chưa phê duyệt"); bang.P_THAY_GTRI(ref b_dt_tk, "trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai_pd", "2", "Không phê duyệt");
            DataTable b_dt = new DataTable();
            bang.P_THEM_COL(ref b_dt, new string[] { "SOTT", "tieuchi", "yeucau_uv", "md_qt" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Kiến thức/Trình độ đào tạo/Trường đào tạo", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Ngoại ngữ", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "3", "Kỹ năng", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "4", "Thái độ/tố chất", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "5", "Kinh nghiệm", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "6", "Mức lương chính thức dự", "", "" });
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot, string[] a_cot_mt, string[] a_cot_pa)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_so_id = "0";
            object[] a_obj = ns_td.Faobj_NS_TD_KHCT_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma" }, new object[] { b_ma });
            if (b_hang > 0) b_so_id = b_dt.Rows[b_hang]["so_id"].ToString();
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_VONGTHI(string b_login, string b_cdanh)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_KHCT_VONGTHI(b_cdanh);
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_dt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_LAN(string b_login, string b_nam, string b_phong, string b_cdanh)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_ma_yc = "";
            DataTable b_ds = ns_td.Fdt_NS_TD_KHCT_LAN(b_nam, b_phong, b_cdanh);
            if (b_ds.Rows.Count > 0 && b_ds != null) b_ma_yc = b_ds.Rows[0]["ma_yc"].ToString();
            return b_ma_yc;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_CT(string b_login, string b_so_id, string[] a_cot, string[] a_cot_mt, string[] a_cot_pa)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_KHCT_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, new string[] { "ngay_dl_dk,ngay_gui_yc" });
            bang.P_SO_CSO(ref b_dt, "luong_tu,luong_den,cphi_td");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_THANG", "THANG");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_LOAITD", "LOAI_TD");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_CTHUC_TD", "CTHUC_TD");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_GIOI_TINH", "GIOI_TINH");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_TRANGTHAI_PD", "TRANGTHAI_PD");
            bang.P_TIM_THEM(ref b_dt, "ns_td_khct", "DT_TRANGTHAI_YC_PD", "TRANGTHAI_YC_PD");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_dt_ct = b_ds.Tables[1];
            DataTable b_dt_pa = b_ds.Tables[2];
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_mt);
            string b_dt_pa_s = bang.Fb_TRANG(b_dt_pa) ? "" : bang.Fs_BANG_CH(b_dt_pa, a_cot_pa);
            return b_dt_s + "#" + b_dt_tt_s + "#" + b_dt_pa_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, object[] a_dt_mt, string[] a_cot_mt, object[] a_dt_pa, string[] a_cot_pa, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            if (b_so_id == "") b_so_id = "0";
            string[] b_cot_mt = chuyen.Fas_OBJ_STR((object[])a_dt_mt[0]); object[] b_gtri_mt = (object[])a_dt_mt[1];
            DataTable b_dt_mt = bang.Fdt_TAO_THEM(b_cot_mt, b_gtri_mt);
            string[] b_cot_pa = chuyen.Fas_OBJ_STR((object[])a_dt_pa[0]); object[] b_gtri_pa = (object[])a_dt_pa[1];
            DataTable b_dt_pa = bang.Fdt_TAO_THEM(b_cot_pa, b_gtri_pa);
            if (b_dt_pa.Rows.Count > 0)
                for (int i = 0; i < b_dt_pa.Rows.Count; i++) b_dt_pa.Rows[i]["sott"] = i;
            bang.P_BO_HANG(ref b_dt_mt, "sott", "");
            bang.P_CSO_SO(ref b_dt_ct, "tuoi_tu,tuoi_den,so_ngay_dx,luong_tu,luong_den");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_gui_yc,ngay_dl_dk");
            bang.P_CSO_SO(ref b_dt_ct, "cphi_td,tdiem1,tdiem2,tdiem3,diem_dat1,diem_dat2,diem_dat3");
            ns_td.P_NS_TD_KHCT_NH(ref b_so_id, b_dt_ct, b_dt_mt, b_dt_pa);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            string b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            string b_phong = mang.Fs_TEN_GTRI("phong_yc", a_cot, a_gtri);
            string b_cdanh = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TD_KHCT_MA(b_login, b_ma, b_trangKT, a_cot_lke, a_cot_mt, a_cot_pa);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_XOA(string b_login, string b_so_id, string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma_yc, double[] a_tso, string[] a_cot, string[] a_cot_mt, string[] a_cot_pa)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_KHCT_XOA(b_so_id);
            return Fs_NS_TD_KHCT_LKE(b_login, b_nam, b_thang, b_phong, b_cdanh, b_ma_yc, a_tso, a_cot, a_cot_mt, a_cot_pa);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHCT_PD(string b_login, string b_so_id, string b_trangthai, string b_nam, string b_thang, string b_phong, string b_cdanh, string b_ma_yc, double[] a_tso, string[] a_cot_lke, string[] a_cot_ct, string[] a_cot_pa)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_KHCT_PD(b_so_id, b_trangthai);
            return Fs_NS_TD_KHCT_LKE(b_login, b_nam, b_thang, b_phong, b_cdanh, b_ma_yc, a_tso, a_cot_lke, a_cot_ct, a_cot_pa);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾ HOẠCH TUYỂN DỤNG CHI TIẾT

    #region KHO ỨNG VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_UV_LKE(string b_login, string b_form, string b_dk, string so_the, string ten, string cdanh_ut, string b_trangthai, object[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_dk == "M")
            {
                double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
                object[] a_obj = ns_td.Faobj_NS_TD_UV_LKE(so_the, ten, cdanh_ut, b_trangthai, b_tu, b_den);
                DataTable b_dt_tk = (DataTable)a_obj[1];
                bang.P_THEM_COL(ref b_dt_tk, "chon", " ");
                se.P_TG_LUU(b_form, "DT_LKE", b_dt_tk);
            }
            return khac.Fs_SLIDE_LKE(b_form, "DT_LKE", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UV_CHON(string b_login, string b_form, string b_so_id, string b_chon)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_LKE");
            bang.P_THAY_GTRI(ref b_dt, "chon", b_chon, "so_id", b_so_id);
            se.P_TG_LUU(b_form, "DT_LKE", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UV_MA(string b_login, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_UV_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UV_CT(string b_login, string b_so_the, string[] a_cot_td, string[] a_cot_tdnn, string[] a_cot_cc, string[] a_cot_ct, string[] a_cot_nt, string[] a_cot_ttk)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_UV_CT(b_so_the);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_td = b_ds.Tables[1]; DataTable b_dt_cc = b_ds.Tables[2]; DataTable b_dt_ct = b_ds.Tables[3]; DataTable b_dt_nt = b_ds.Tables[4];
            DataTable b_dt_tdnn = b_ds.Tables[5]; DataTable b_dt_ttk = b_ds.Tables[6];

            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_UV", "trangthai");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_TT_HONNHAN", "tt_honnhan");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_DT", "dantoc");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_TG", "tongiao");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_GIOI_TINH", "gioitinh");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv", "DT_CDANH_UT", "cdanh_ut");
            bang.P_BANG_GHEP(ref b_dt, "tt_noisinh,tt_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_noisinh,qh_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_noisinh,xp_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "tt_thuongtru,tt_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_thuongtru,qh_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_thuongtru,xp_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "tt_tamtru,tt_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_tamtru,qh_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_tamtru,xp_tamtru_ten", "{");

            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            bang.P_SO_CNG(ref b_dt_cc, "tungay,denngay,ngay_hl,ngay_hhl");
            bang.P_SO_CTH(ref b_dt_ct, "tuthang,denthang");
            bang.P_SO_CNG(ref b_dt_nt, "ngaysinh");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                  b_dt_td_s = bang.Fb_TRANG(b_dt_td) ? "" : bang.Fs_BANG_CH(b_dt_td, a_cot_td),
                  b_dt_tdnn_s = bang.Fb_TRANG(b_dt_tdnn) ? "" : bang.Fs_BANG_CH(b_dt_tdnn, a_cot_tdnn),
                  b_dt_cc_s = bang.Fb_TRANG(b_dt_cc) ? "" : bang.Fs_BANG_CH(b_dt_cc, a_cot_cc),
                  b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                  b_dt_nt_s = bang.Fb_TRANG(b_dt_nt) ? "" : bang.Fs_BANG_CH(b_dt_nt, a_cot_nt),
                  b_dt_ttk_s = bang.Fb_TRANG(b_dt_ttk) ? "" : bang.Fs_BANG_CH(b_dt_ttk, a_cot_ttk);
            return b_kq + "#" + b_dt_td_s + "#" + b_dt_cc_s + "#" + b_dt_ct_s + "#" + b_dt_nt_s + "#" + b_dt_tdnn_s + "#" + b_dt_ttk_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UV_NH(string b_login, double b_trangKT, object[] a_dt, object[] a_dt_td, object[] a_dt_tdnn, object[] a_dt_cc, object[] a_dt_ct, object[] a_dt_nt, object[] a_dt_ttk, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            // thông tin chung
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            if (b_dt.Rows[0]["trangthai"].ToString() == "") // nếu khai báo mới lần đầu thì để trạng thái ứng viên là chưa xếp lịch
            {
                b_dt.Rows[0]["trangthai"] = "CXL";
            }
            bang.P_CNG_SO(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            bang.P_CSO_SO(ref b_dt, "mucluong_mm");
            // thông tin trình độ
            string[] a_cot_td = chuyen.Fas_OBJ_STR((object[])a_dt_td[0]); object[] a_gtri_td = (object[])a_dt_td[1];
            DataTable b_dt_td = bang.Fdt_TAO_THEM(a_cot_td, a_gtri_td);
            bang.P_CSO_SO(ref b_dt_td, "tunam,dennam");
            // thông tin trình độ ngoại ngữ
            string[] a_cot_tdnn = chuyen.Fas_OBJ_STR((object[])a_dt_tdnn[0]); object[] a_gtri_tdnn = (object[])a_dt_tdnn[1];
            DataTable b_dt_tdnn = bang.Fdt_TAO_THEM(a_cot_tdnn, a_gtri_tdnn);
            bang.P_CSO_SO(ref b_dt_tdnn, "namcap");
            // thông tin chứng chỉ
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc);
            bang.P_CNG_SO(ref b_dt_cc, "tungay,denngay,ngay_hl,ngay_hhl");
            // thông tin công tác
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_CTH_SO(ref b_dt_ct, "tuthang,denthang");
            // thông tin nhân thân
            string[] a_cot_nt = chuyen.Fas_OBJ_STR((object[])a_dt_nt[0]); object[] a_gtri_nt = (object[])a_dt_nt[1];
            DataTable b_dt_nt = bang.Fdt_TAO_THEM(a_cot_nt, a_gtri_nt);
            bang.P_CNG_SO(ref b_dt_nt, "ngaysinh");
            // thông tin khác
            string[] a_cot_ttk = chuyen.Fas_OBJ_STR((object[])a_dt_ttk[0]); object[] a_gtri_ttk = (object[])a_dt_ttk[1];
            DataTable b_dt_ttk = bang.Fdt_TAO_THEM(a_cot_ttk, a_gtri_ttk);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (double.Parse(b_dt_ct.Rows[i]["tuthang"].ToString()) > double.Parse(b_dt_ct.Rows[i]["denthang"].ToString()))
                {
                    return "loi:Từ tháng không được lớn hơn đến tháng:loi";
                }
            }
            string b_so_the = ns_td.Fs_TD_UV_NH(b_dt, b_dt_td, b_dt_tdnn, b_dt_cc, b_dt_ct, b_dt_nt, b_dt_ttk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_UV_CV, TEN_BANG.NS_TD_UV_CV);
            return Fs_NS_TD_UV_MA(b_login, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UV_XOA(string b_login, string b_form, string b_so_the, string b_sothe_tk, string b_ten, string b_cdanh_ut, string b_trangthai, object[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_UV_XOA(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_UV_CV, TEN_BANG.NS_TD_UV_CV);
            return Fs_NS_TD_UV_LKE(b_login, b_form, "M", b_sothe_tk, b_ten, b_cdanh_ut, b_trangthai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region GÁN ỨNG VIÊN VÀO MÃ TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_DEXUAT_LKE_BY_NAM(string b_login, string b_form, string b_ten_ktra, string b_nam)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_nam);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, b_ten_ktra, b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TD_DEXUAT_BYMA(string b_login, string b_nam, string b_mayeucau)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_ten_cdanh = "", b_ten_phong = "", b_ten_phong_ct = "";
            DataTable b_ds = ns_td.Fdt_NS_TD_DEXUAT_TT(b_nam, b_mayeucau);
            if (b_ds.Rows.Count > 0 && b_ds != null)
            {
                b_ten_cdanh = b_ds.Rows[0]["ten_cdanh"].ToString();
                b_ten_phong = b_ds.Rows[0]["ten_phong"].ToString();
                b_ten_phong_ct = b_ds.Rows[0]["phongban_ct"].ToString();
            }
            return b_ten_cdanh + "#" + b_ten_phong + "#" + b_ten_phong_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_GAN_UV_LKE(string b_login, string b_ma_dx, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_GAN_UV_LKE(b_ma_dx, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_GAN_UV_MA(string b_login, string b_so_the, string b_ma_dx, string b_trangthai, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_GAN_UV_MA(b_so_the, b_ma_dx, b_trangthai, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_GAN_UV_CT(string b_login, string b_so_the, string[] a_cot_td, string[] a_cot_tdnn, string[] a_cot_cc, string[] a_cot_ct, string[] a_cot_nt, string[] a_cot_ttk)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_GAN_UV_CT(b_so_the);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_td = b_ds.Tables[1]; DataTable b_dt_cc = b_ds.Tables[2]; DataTable b_dt_ct = b_ds.Tables[3]; DataTable b_dt_nt = b_ds.Tables[4];
            DataTable b_dt_tdnn = b_ds.Tables[5]; DataTable b_dt_ttk = b_ds.Tables[6];

            string b_nam = b_dt.Rows[0]["NAM"].ToString();
            if (b_nam != "")
            {
                DataTable b_dt_yeucau = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_nam);
                if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
                se.P_TG_LUU("ns_td_uv_yeucauTD", "DT_MAYEUCAU_TD", b_dt_yeucau.Copy());
            }

            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_MAYEUCAU_TD", "MAYEUCAU_TD");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_UV", "trangthai_uv_theoyc");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_TT_HONNHAN", "tt_honnhan");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_DT", "dantoc");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_TG", "tongiao");
            bang.P_TIM_THEM(ref b_dt, "ns_td_uv_yeucauTD", "DT_GIOI_TINH", "gioitinh");
            bang.P_BANG_GHEP(ref b_dt, "tt_noisinh,tt_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_noisinh,qh_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_noisinh,xp_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "tt_thuongtru,tt_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_thuongtru,qh_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_thuongtru,xp_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "tt_tamtru,tt_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "qh_tamtru,qh_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt, "xp_tamtru,xp_tamtru_ten", "{");

            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            bang.P_SO_CNG(ref b_dt_cc, "tungay,denngay,ngay_hl,ngay_hhl");
            bang.P_SO_CTH(ref b_dt_ct, "tuthang,denthang");
            bang.P_SO_CNG(ref b_dt_nt, "ngaysinh");



            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                 b_dt_td_s = bang.Fb_TRANG(b_dt_td) ? "" : bang.Fs_BANG_CH(b_dt_td, a_cot_td),
                 b_dt_tdnn_s = bang.Fb_TRANG(b_dt_tdnn) ? "" : bang.Fs_BANG_CH(b_dt_tdnn, a_cot_tdnn),
                 b_dt_cc_s = bang.Fb_TRANG(b_dt_cc) ? "" : bang.Fs_BANG_CH(b_dt_cc, a_cot_cc),
                 b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct),
                 b_dt_nt_s = bang.Fb_TRANG(b_dt_nt) ? "" : bang.Fs_BANG_CH(b_dt_nt, a_cot_nt),
                 b_dt_ttk_s = bang.Fb_TRANG(b_dt_ttk) ? "" : bang.Fs_BANG_CH(b_dt_ttk, a_cot_ttk);
            return b_kq + "#" + b_dt_td_s + "#" + b_dt_cc_s + "#" + b_dt_ct_s + "#" + b_dt_nt_s + "#" + b_dt_tdnn_s + "#" + b_dt_ttk_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_GAN_UV_NH(string b_login, string b_ma_dx, string b_trangthai, double b_trangKT, object[] a_dt, object[] a_dt_td, object[] a_dt_tdnn, object[] a_dt_cc, object[] a_dt_ct, object[] a_dt_nt, object[] a_dt_ttk, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            // thông tin chung
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            if (b_dt.Rows[0]["trangthai"].ToString() == "") // Khai báo từ form gán ứng viên vào yêu cầu thì cập nhật trạng thái thành đã xếp lịch
            {
                b_dt.Rows[0]["trangthai"] = "DXL";
            }
            bang.P_CNG_SO(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu");
            bang.P_CSO_SO(ref b_dt, "mucluong_mm");
            // thông tin trình độ
            string[] a_cot_td = chuyen.Fas_OBJ_STR((object[])a_dt_td[0]); object[] a_gtri_td = (object[])a_dt_td[1];
            DataTable b_dt_td = bang.Fdt_TAO_THEM(a_cot_td, a_gtri_td);
            bang.P_CSO_SO(ref b_dt_td, "tunam,dennam");
            // thông tin trình độ ngoại ngữ
            string[] a_cot_tdnn = chuyen.Fas_OBJ_STR((object[])a_dt_tdnn[0]); object[] a_gtri_tdnn = (object[])a_dt_tdnn[1];
            DataTable b_dt_tdnn = bang.Fdt_TAO_THEM(a_cot_tdnn, a_gtri_tdnn);
            bang.P_CSO_SO(ref b_dt_tdnn, "namcap");
            // thông tin chứng chỉ
            string[] a_cot_cc = chuyen.Fas_OBJ_STR((object[])a_dt_cc[0]); object[] a_gtri_cc = (object[])a_dt_cc[1];
            DataTable b_dt_cc = bang.Fdt_TAO_THEM(a_cot_cc, a_gtri_cc);
            bang.P_CNG_SO(ref b_dt_cc, "tungay,denngay,ngay_hl,ngay_hhl");
            // thông tin công tác
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_CTH_SO(ref b_dt_ct, "tuthang,denthang");
            // thông tin nhân thân
            string[] a_cot_nt = chuyen.Fas_OBJ_STR((object[])a_dt_nt[0]); object[] a_gtri_nt = (object[])a_dt_nt[1];
            DataTable b_dt_nt = bang.Fdt_TAO_THEM(a_cot_nt, a_gtri_nt);
            bang.P_CNG_SO(ref b_dt_nt, "ngaysinh");
            // thông tin khác
            string[] a_cot_ttk = chuyen.Fas_OBJ_STR((object[])a_dt_ttk[0]); object[] a_gtri_ttk = (object[])a_dt_ttk[1];
            DataTable b_dt_ttk = bang.Fdt_TAO_THEM(a_cot_ttk, a_gtri_ttk);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (double.Parse(b_dt_ct.Rows[i]["tuthang"].ToString()) > double.Parse(b_dt_ct.Rows[i]["denthang"].ToString()))
                {
                    return "loi:Từ tháng không được lớn hơn đến tháng:loi";
                }
            }
            string b_so_the = ns_td.PNS_TD_GAN_UV_NH(b_dt, b_dt_td, b_dt_tdnn, b_dt_cc, b_dt_ct, b_dt_nt, b_dt_ttk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_UV_YEUCAUTD, TEN_BANG.NS_TD_UV_YEUCAUTD);
            return Fs_NS_TD_GAN_UV_MA(b_login, b_so_the, b_ma_dx, b_trangthai, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_GAN_UV_XOA(string b_login, string b_ma_yc, string b_so_the, string b_ma_dx_tk, string b_trangthai_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_TD_GAN_UV_XOA(b_ma_yc, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_UV_YEUCAUTD, TEN_BANG.NS_TD_UV_YEUCAUTD);
            return Fs_NS_TD_GAN_UV_LKE(b_login, b_ma_dx_tk, b_trangthai_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHON_KHO_NH(string b_login, string b_ma_yc, string b_ma_dx_tk, string b_trangthai_tk, object[] a_dt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_kq = bang.Fs_HANG_GOP(b_dt, 0);
            string b_so_the = ns_td.PNS_TD_CHON_KHOUV_NH(b_ma_yc, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_UV_YEUCAUTD, TEN_BANG.NS_TD_UV_YEUCAUTD);
            return b_kq; //Fs_NS_TD_GAN_UV_LKE(b_login, b_ma_dx_tk, b_trangthai_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_CT(string b_nam, string b_thang, string b_ma_dx, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_PD_CDANH_TD_CT(b_nam, b_thang, b_ma_dx);
            if (b_dt.Rows.Count > 0)
            {
                DataTable b_dt_lke = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_dt.Rows[0]["NAM"].ToString());
                se.P_TG_LUU("NS_TD_PD_CDANH_TD", "DT_MAYEUCAU_TD", b_dt_lke.Copy());
                bang.P_TIM_THEM(ref b_dt, "NS_TD_PD_CDANH_TD", "DT_MAYEUCAU_TD", "MA_DX");
            }
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "KPD", "Không phê duyệt");

            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaygui");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_kq_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq + "#" + b_kq_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_LKE(string b_nam, string b_ma_dx, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_NS_TD_PD_CDANH_TD_LKE(b_nam, b_ma_dx, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_MA(string b_nam, string b_nam_tk, string b_ma_dx_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_td.Fdt_NS_TD_PD_CDANH_TD_MA(b_nam, b_nam_tk, b_ma_dx_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_LKE_DS(string b_dexuat, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_PD_CDANH_TD_DS(b_dexuat);
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaygui");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TRANGTHAI", "KPD", "Không phê duyệt");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_NH(string b_nam_tk, string b_ma_dx_tk, double b_trangkt, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            bang.P_CNG_SO(ref b_dt_ct, "ngaygui");
            ns_td.P_NS_TD_PD_CDANH_TD_NH(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_PD_CDANH_TD, TEN_BANG.NS_TD_PD_CDANH_TD);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_TD_PD_CDANH_TD_MA(b_nam, b_nam_tk, b_ma_dx_tk, b_trangkt, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG

    #region XẾP LỊCH PHỎNG VẤN THI TUYỂN
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_CT(string b_ma_dx, string b_ngay_xeplich, string b_vongthi, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_PHONGVAN_CT(b_ma_dx, b_ngay_xeplich, b_vongthi);
            if (b_dt.Rows.Count > 0)
            {
                DataTable b_dt_lke = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_dt.Rows[0]["NAM"].ToString());
                se.P_TG_LUU("ns_td_phongvan", "DT_MAYEUCAU_TD", b_dt_lke.Copy());
                bang.P_TIM_THEM(ref b_dt, "ns_td_phongvan", "DT_MAYEUCAU_TD", "MA_DX");

                DataTable b_dt_vthi = new DataTable();
                b_dt_vthi.Columns.Add("MA", typeof(string));
                b_dt_vthi.Columns.Add("TEN", typeof(string));
                bang.P_THEM_TRANG(ref b_dt_vthi, 1, 0);
                bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "1", "Vòng 1" }, 1);
                bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "2", "Vòng 2" }, 2);
                bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "3", "Vòng 3" }, 3);
                se.P_TG_LUU("ns_td_phongvan", "DT_VONG_THI", b_dt_vthi.Copy());
                bang.P_TIM_THEM(ref b_dt, "ns_td_phongvan", "DT_VONG_THI", "VONG_THI");
            }

            bang.P_SO_CNG(ref b_dt, "ngay_xeplich,ngaythi_pv");
            //bang.P_TIM_THEM(ref b_dt, "ns_td_phongvan", "DT_NGUOI_PV", "NGUOI_PV");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_kq_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq + "#" + b_kq_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_LKE(string b_nam, string b_ma_dx, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_NS_TD_PHONGVAN_LKE(b_nam, b_ma_dx, b_tu, b_den);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_XEPLICH");
            bang.P_COPY_COL(ref b_dt, "TEN_VONG_THI", "VONG_THI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "1", "Vòng 1");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "2", "Vòng 2");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "3", "Vòng 3");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_MA(string b_nam, string b_nam_tk, string b_ma_dx_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_td.Fdt_NS_TD_PHONGVAN_MA(b_nam, b_nam_tk, b_ma_dx_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_xeplich");
            bang.P_COPY_COL(ref b_dt, "TEN_VONG_THI", "VONG_THI");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "1", "Vòng 1");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "2", "Vòng 2");
            bang.P_THAY_GTRI(ref b_dt, "TEN_VONG_THI", "3", "Vòng 3");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "nam", b_nam);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_LKE_DS(string b_dexuat, string b_vthi, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_PHONGVAN_LKE_DS(b_dexuat, b_vthi);
            bang.P_SO_CNG(ref b_dt, "ngaythi_pv");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_NH(string b_nam_tk, string b_ma_dx_tk, double b_trangkt, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_td.P_NS_TD_PHONGVAN_NH(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_PHONGVAN, TEN_BANG.NS_TD_PHONGVAN);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_TD_PHONGVAN_MA(b_nam, b_nam_tk, b_ma_dx_tk, b_trangkt, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_XOA(string b_ma_dx, string b_vongthi, string b_ngay_xeplich, string b_nam_tk, string b_ma_dx_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_td.PNS_TD_PHONGVAN_XOA(b_ma_dx, b_vongthi, b_ngay_xeplich);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_PHONGVAN, TEN_BANG.NS_TD_PHONGVAN);
            return Fs_NS_TD_PHONGVAN_LKE(b_nam_tk, b_ma_dx_tk, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHONGVAN_SENDMAIL(string b_vongthi, string b_dexuat, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_COT(ref b_dt_ct, "chon");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            ns_td.Fdt_NS_TD_PHONGVAN_SENDMAIL(b_vongthi, b_dexuat, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
            //if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message );
            //else return Thongbao_dch.Pheduyet_thatbai;
        }
    }

    #endregion XẾP LỊCH PHỎNG VẤN THI TUYỂN

    #region KẾT QUẢ THI TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_DS(string b_login, string b_ma_yc, string[] a_cot_ct)
    {
        try
        {
            string b_so_id = "";
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_KQ_DS(b_ma_yc);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            if (b_dt_ct.Rows.Count > 0)
            {
                b_so_id = b_dt_ct.Rows[0]["so_id"].ToString();
            }

            bang.P_SO_CNG(ref b_dt_ct, "ngaysinh,ngaythi1,ngaythi2,ngaythi3");
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                 b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_kq + "#" + b_dt_ct_s + "#" + b_so_id;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_LKE(string b_login, string b_nam, string b_yeucau, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KQ_LKE(b_nam, b_yeucau, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_NH(string b_login, string b_so_id, string b_nam, string b_yeucau, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Fs_NS_TD_KQ_LKE(b_login, b_nam, b_yeucau, a_tso, a_cot_lke);
            }
            //for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            //{
            //    if (b_dt_ct.Rows[i]["KETQUA_CHUNG"].ToString().Equals(""))
            //    {
            //        return Thongbao_dch.ns_td_kq_kqc;
            //    }
            //}
            bang.P_CNG_SO(ref b_dt_ct, "ngaythi1,ngaythi2,ngaythi3");
            bang.P_CSO_SO(ref b_dt_ct, "diemdat1,diemdat2,diemdat3");
            ns_td.P_NS_TD_KQ_NH(b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KQ, TEN_BANG.NS_TD_KQ);
            return Fs_NS_TD_KQ_LKE(b_login, b_nam, b_yeucau, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PD(string b_login, string b_so_id, string b_trangthai, string b_nam, string b_yeucau, object[] a_dt, object[] a_dt_ct, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Fs_NS_TD_KQ_LKE(b_login, b_nam, b_yeucau, a_tso, a_cot_lke);
            }
            //for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            //{
            //    if (b_dt_ct.Rows[i]["KETQUA_CHUNG"].ToString().Equals(""))
            //    {
            //        return Thongbao_dch.ns_td_kq_kqc;
            //    }
            //}
            bang.P_CNG_SO(ref b_dt_ct, "ngaythi1,ngaythi2,ngaythi3");
            bang.P_CSO_SO(ref b_dt_ct, "diemdat1,diemdat2,diemdat3");
            ns_td.P_NS_TD_KQ_PD(b_so_id, b_trangthai, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KQ, TEN_BANG.NS_TD_KQ);
            return Fs_NS_TD_KQ_LKE(b_login, b_nam, b_yeucau, a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_CT(string b_login, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_KQ_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            if (b_dt.Rows.Count > 0)
            {
                DataTable b_dt_lke = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_dt.Rows[0]["NAM"].ToString());
                se.P_TG_LUU("ns_td_kq", "DT_MAYEUCAU_TD", b_dt_lke.Copy());
                bang.P_TIM_THEM(ref b_dt, "ns_td_kq", "DT_MAYEUCAU_TD", "MAYEUCAU_TD");
            }
            bang.P_SO_CNG(ref b_dt_ct, "ngaysinh,ngaythi1,ngaythi2,ngaythi3");
            bang.P_SO_CSO(ref b_dt_ct, "diemdat1,diemdat2,diemdat3");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                  b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_XOA(string b_login, string b_so_id, string b_nam_tk, string b_yeucau_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.PNS_TD_KQ_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_KQ, TEN_BANG.NS_TD_KQ);
            return Fs_NS_TD_KQ_LKE(b_login, b_nam_tk, b_yeucau_tk, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_IMPORT(string b_login)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            //1 - Thành công; 2 - Sai file mẫu; 3 - Tắt form;
            string b_kq = (string)HttpContext.Current.Session["NS_TD_KQ_SS"];
            if (b_kq == null) b_kq = "";
            string[] a_kq = b_kq.Split('|');
            switch (a_kq[0])
            {
                case "1":
                case "2":
                case "3":
                    HttpContext.Current.Session.Remove("NS_TD_KQ_SS"); break;
                default:
                    break;
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_IMPORT_OUT(string b_login, string b_kq)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); HttpContext.Current.Session.Add("NS_TD_KQ_SS", b_kq); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾT QUẢ THI TUYỂN DỤNG

    #region KẾT QUẢ PHỎNG VẤN ỨNG VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_LKE(string b_login, string b_nam, string b_yeucau, string cdanh, double[] a_tso, string[] a_cot, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_KQ_PV_LKE(b_nam, b_yeucau, cdanh, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngaysinh");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "1", "Trúng tuyển");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "2", "Không trúng tuyển");
            DataTable b_dt = new DataTable();
            bang.P_THEM_COL(ref b_dt, new string[] { "stt", "tieuchi", "ghinhan_dactrung", "tytrong", "diem_dg", "tongdiem" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Kiến thức chuyên môn", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Ngoại ngữ", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "3", "Kỹ năng", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "4", "Thái độ", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "5", "Kinh nghiệm", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "6", "Mức độ phù hợp với công ty", "", "", "", "" });
            bang.P_THEM_HANG(ref b_dt, new object[] { "7", "Tổng", "", "", "", "" });
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_MA(string b_login, string b_so_the, double b_trangkt, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_so_id = "0";
            object[] a_obj = ns_td.Faobj_NS_TD_KQ_PV_MA(b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt, "ngaysinh");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "Trúng tuyển");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "Không trúng tuyển");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_the" }, new object[] { b_so_the });
            if (b_hang > 0) b_so_id = b_dt.Rows[b_hang]["so_id"].ToString();
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_CT(string b_login, string b_so_id, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataSet b_ds = ns_td.Fds_NS_TD_KQ_PV_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, new string[] { "ngaydl_dk" });
            bang.P_SO_CSO(ref b_dt, "mucluong_ct,mucluong_tv");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_dt_ct = b_ds.Tables[1];
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_mt);
            return b_dt_s + "#" + b_dt_tt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, object[] a_dt_mt, double[] a_tso, string[] a_cot_lke, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "mucluong_ct,mucluong_tv");
            bang.P_CNG_SO(ref b_dt_ct, "ngaydl_dk");
            if (b_so_id == "") b_so_id = "0";
            string[] a_cot_mt = chuyen.Fas_OBJ_STR((object[])a_dt_mt[0]); object[] a_gtri_mt = (object[])a_dt_mt[1];
            DataTable b_dt_mt = bang.Fdt_TAO_THEM(a_cot_mt, a_gtri_mt);
            bang.P_CSO_SO(ref b_dt_mt, "stt,tytrong,diem_dg,tongdiem");
            bang.P_BO_HANG(ref b_dt_mt, "TIEUCHI", "");
            ns_td.P_NS_TD_KQ_PV_NH(b_so_id, b_dt_ct, b_dt_mt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_KQ_PV_CN, TEN_BANG.NS_TD_KQ_PV_CN);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            string b_cdanh = mang.Fs_TEN_GTRI("cdanh", a_cot, a_gtri);
            string b_ma_yc = mang.Fs_TEN_GTRI("ma_yc", a_cot, a_gtri);
            return Fs_NS_TD_KQ_PV_LKE(b_login, b_nam, b_ma_yc, b_nam, a_tso, a_cot_lke, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_UP(string b_login, string b_nam, string b_yeucau, string b_cdanh, string b_so_id, string b_trangthai, double[] a_tso, string[] a_cot_lke, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_KQ_PV_UP(b_so_id, b_trangthai);
            return Fs_NS_TD_KQ_PV_LKE(b_login, b_nam, b_yeucau, b_cdanh, a_tso, a_cot_lke, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_KQ_PV_XOA(string b_login, string b_so_id, string b_nam, string b_yeucau, string b_cdanh, double[] a_tso, string[] a_cot, string[] a_cot_mt)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_td.P_NS_TD_KQ_PV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_KQ_PV_CN, TEN_BANG.NS_TD_KQ_PV_CN);
            return Fs_NS_TD_KQ_PV_LKE(b_login, b_nam, b_yeucau, b_cdanh, a_tso, a_cot, a_cot_mt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾT QUẢ PHỎNG VẤN ỨNG VIÊN

    #region CẬP NHẬT ỨNG VIÊN TRÚNG TUYỂN
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_LKE_DS(string b_login, string b_form, string b_ten_ktra, string b_ma_yeucau)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_TD_CAPNHAT_UV_LKE_DS(b_ma_yeucau);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, b_ten_ktra, b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_NH(string b_login, string b_so_id, string b_nam, string b_ma, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "luong_cb,thuong_cv,thunhap,phantram_tv");
            bang.P_CNG_SO(ref b_dt, "ngayd");
            bang.P_CNG_SO(ref b_dt, "ngay_offer");
            b_so_id = ns_td.P_NS_TD_CAPNHAT_UV_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_CAPNHAT_UV, TEN_BANG.NS_TD_CAPNHAT_UV);
            return Fs_NS_TD_CAPNHAT_UV_MA(b_login, b_so_id, b_nam, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_MA(string b_login, string b_so_id, string b_nam, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_CAPNHAT_UV_MA(b_so_id, b_nam, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_COPY_COL(ref b_dt, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "DG", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "DL", "Đồng ý đi làm");
            bang.P_THAY_GTRI(ref b_dt, "ten_trangthai", "TC", "Từ chối");
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_SO_CNG(ref b_dt, "ngay_offer");
            bang.P_SO_CSO(ref b_dt, "luong_cb,thuong_cv,thunhap");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_LKE(string b_login, string b_nam, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_CAPNHAT_UV_LKE(b_nam, b_ma, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt_ct, "ten_trangthai", "trangthai");
            bang.P_THAY_GTRI(ref b_dt_ct, "ten_trangthai", "DG", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt_ct, "ten_trangthai", "DL", "Đồng ý đi làm");
            bang.P_THAY_GTRI(ref b_dt_ct, "ten_trangthai", "TC", "Từ chối");
            return bang.Fb_TRANG(b_dt_ct) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_td.Fdt_NS_TD_CAPNHAT_UV_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_SO_CNG(ref b_dt, "ngay_offer");
            bang.P_SO_CSO(ref b_dt, "luong_cb,thuong_cv,thunhap");
            if (b_dt.Rows.Count > 0)
            {
                // lấy danh sách yêu cầu tuyển dụng theo năm
                DataTable b_dt_lke = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_dt.Rows[0]["NAM"].ToString());
                se.P_TG_LUU("ns_td_capnhat_uv", "DT_MAYEUCAU_TD", b_dt_lke.Copy());
                // lấy danh sách nhân viên theo yêu cầu tuyển dụng
                DataTable b_dt_dsuv = ns_td.Fdt_NS_TD_CAPNHAT_UV_LKE_DS(b_dt.Rows[0]["MA"].ToString());
                se.P_TG_LUU("ns_td_capnhat_uv", "DT_SO_THE", b_dt_dsuv.Copy());

            }
            bang.P_TIM_THEM(ref b_dt, "ns_td_capnhat_uv", "DT_MAYEUCAU_TD", "MA");
            bang.P_TIM_THEM(ref b_dt, "ns_td_capnhat_uv", "DT_SO_THE", "SO_THE");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CAPNHAT_UV_XOA(string b_login, string b_so_id, string b_nam, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_td.P_NS_TD_CAPNHAT_UV_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_CAPNHAT_UV, TEN_BANG.NS_TD_CAPNHAT_UV);
            return Fs_NS_TD_CAPNHAT_UV_LKE(b_login, b_nam, b_ma, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion  CẬP NHẬT ỨNG VIÊN TRÚNG TUYỂN

    #region CHUYÊN ỨNG VIÊN THÀNH NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_NV_CT(string b_nam, string b_yeucau_td, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_CHUYEN_UV_NV_CT(b_nam, b_yeucau_td);

            DataTable b_dt_lke = ns_td.Fdt_NS_TD_DEXUAT_LKE_BY_NAM(b_nam);
            se.P_TG_LUU("ns_td_chuyen_uv_nv", "DT_MAYEUCAU_TD", b_dt_lke.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_td_chuyen_uv_nv", "DT_MAYEUCAU_TD", "MAYEUCAU_TD");

            bang.P_SO_CNG(ref b_dt, "ngay_dl_tt");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct),
                   b_dt_ct = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq + "#" + b_dt_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_THUTUC_CT(string b_ma_dx, string[] a_cot_ct)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_THUTUC_CT(b_ma_dx);
            bang.P_THEM_COL(ref b_dt, "so_id", "0");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string FS_NS_TD_THUTUC_LKE_ALL(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fs_NS_TD_THUTUC_LKE();
            bang.P_THEM_COL(ref b_dt, "chon", "");
            bang.P_THEM_COL(ref b_dt, "so_id", "0");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_NV_LKE(string b_nam, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_td.Fdt_NS_TD_CHUYEN_UV_NV_LKE(b_nam, b_ma, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            //bang.P_SO_CNG(ref b_dt, "ngay_xacnhan");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_NV_LKE_DS(string b_nam, string b_yeucau, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_CHUYEN_UV_NV_LKE_DS(b_nam, b_yeucau);
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            if (b_tusinh.Rows[0]["SOTHE"].Equals("TS_NT") || b_tusinh.Rows[0]["SOTHE"].Equals("TS"))
            {
                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(b_dt.Rows[i]["MA_NV"].ToString()))
                    {
                        b_dt.Rows[i]["MA_NV"] = Fs_SinhMaCanBo(b_tusinh, i);
                    }
                }
            }

            bang.P_SO_CNG(ref b_dt, "ngay_dl_tt");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private string Fs_SinhMaCanBo(DataTable b_tusinh, int b_i)
    {
        string b_SoTheCB = "";
        string b_dinhdang = "";
        int b_dodai = 0;
        try
        {
            b_dodai = int.Parse(b_tusinh.Rows[0]["DODAISOTHE"].ToString());

            b_dinhdang = b_tusinh.Rows[0]["TIENTO"].ToString();
            double b_tontai = 0;

            for (int i = 0; i < b_dodai - b_tusinh.Rows[0]["TIENTO"].ToString().Length; i++)
            {
                b_dinhdang = b_dinhdang + "0";
            }

            var b_dt_sothe = ht_dungchung.Fdt_NS_CB_MAX_MA(b_tusinh.Rows[0]["TIENTO"].ToString(), b_tusinh.Rows[0]["DODAISOTHE"].ToString(), b_dinhdang);
            if ((b_dt_sothe != null && b_dt_sothe.Rows.Count > 0) && !b_dt_sothe.Rows[0]["SO_THE"].Equals("0"))
            {
                var b_sothe = double.Parse(b_dt_sothe.Rows[0]["SO_THE"].ToString());

                do
                {
                    b_sothe = b_sothe + 1 + b_i;
                    b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_sothe, b_dinhdang));
                    b_tontai = double.Parse(ht_dungchung.Fdt_NS_CB_HOI(b_SoTheCB).Rows[0]["TONTAI"].ToString());


                } while (b_tontai != 0);
            }
            else
                b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(1, b_dinhdang));
        }
        catch (Exception)
        {

            b_SoTheCB = b_dinhdang.Substring(0, b_dodai - 1).ToString() + "1";
        }
        return b_SoTheCB;
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_NV_NH(object[] a_dt, object[] a_dt_ct, object[] a_dt_tt, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_tt = chuyen.Fas_OBJ_STR((object[])a_dt_tt[0]);
            object[] a_gtri_tt = (object[])a_dt_tt[1];

            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            DataTable b_dt_tt = bang.Fdt_TAO_THEM(a_cot_tt, a_gtri_tt);

            bang.P_BO_HANG(ref b_dt_ct, "so_the", ""); bang.P_CNG_SO(ref b_dt_ct, "ngay_dl_tt");
            bang.P_BO_HANG(ref b_dt_tt, "MA", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.chuaco_ungvien;
            }
            ns_td.P_NS_TD_CHUYEN_UV_NV_NH(b_dt, b_dt_ct, b_dt_tt);
            return Fs_NS_TD_CHUYEN_UV_NV_LKE("", "", a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_KHO_NH(object[] a_dt, object[] a_dt_ct, object[] a_dt_tt, double[] a_tso, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            string[] a_cot_tt = chuyen.Fas_OBJ_STR((object[])a_dt_tt[0]);
            object[] a_gtri_tt = (object[])a_dt_tt[1];

            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            DataTable b_dt_tt = bang.Fdt_TAO_THEM(a_cot_tt, a_gtri_tt);

            bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            bang.P_BO_HANG(ref b_dt_tt, "MA", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.chuaco_ungvien;
            }
            ns_td.PNS_TD_CHUYEN_UV_KHO_NH(b_dt, b_dt_ct, b_dt_tt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TD_CHUYEN_UV_NV, TEN_BANG.NS_TD_CHUYEN_UV_NV);
            return Fs_NS_TD_CHUYEN_UV_NV_LKE("", "", a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_CHUYEN_UV_NV_XOA(string b_nam, string b_yeucau_td, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_td.PNS_TD_CHUYEN_UV_NV_XOA(b_nam, b_yeucau_td);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TD_CHUYEN_UV_NV, TEN_BANG.NS_TD_CHUYEN_UV_NV);
            return Fs_NS_TD_CHUYEN_UV_NV_LKE("", "", a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region DANH SÁCH ỨNG VIÊN PRE - EMPLOYEE
    [WebMethod(true)]
    public string Fs_NS_TD_UNGVIEN_DONGY_LKE(string b_login, string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_UNGVIEN_DONGY_LKE(b_nam, b_ma_yc, b_cdanh, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH SÁCH ỨNG VIÊN PRE - EMPLOYEE

    #region CHUYỂN SANH SÁCH ỨNG VIÊN SANG NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_UNGVIEN_NV_LKE(string b_login, string b_ma_yc, string b_nam, string b_cdanh, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_UNGVIEN_NV_LKE(b_ma_yc, b_nam, b_cdanh, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai_pd", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai_pd", "1", "Phê duyệt");
            bang.P_SO_CNG(ref b_dt_tk, "ngaycap_cmt,ngaysinh");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UNGVIEN_NV_CHUYEN(string b_login, string b_ma, string b_so_the)
    {
        try
        { se.P_LOGIN(b_login); ns_td.P_NS_TD_UNGVIEN_NV_CHUYEN(b_ma, b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHUYỂN SANH SÁCH ỨNG VIÊN SANG NHÂN VIÊN

    #region PHÊ DUYỆT ỨNG VIÊN THÀNH NHÂN VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_UNGVIEN_NV_PD_LKE(string b_login, string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay, string b_trangthai_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_UNGVIEN_NV_PD_LKE(b_nam, b_ma_yc, b_cdanh, b_tungay, b_denngay, b_trangthai_pd, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_bd");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_UNGVIEN_NV_PD_PHEDUYET(string b_login, string b_ma, string b_so_the, string b_nam, string b_ma_yc, string b_cdanh, string b_tungay, string b_denngay, string b_trangthai_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_ma_nv = Fs_SinhMaCanBo(b_tusinh);
            ns_td.P_NS_TD_UNGVIEN_NV_PD_PHEDUYET(b_ma, b_so_the, b_ma_nv);
            return Fs_NS_TD_UNGVIEN_NV_PD_LKE(b_login, b_nam, b_ma_yc, b_cdanh, b_tungay, b_denngay, b_trangthai_pd, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private string Fs_SinhMaCanBo(DataTable b_tusinh)
    {
        string b_SoTheCB = "";
        string b_dinhdang = "";
        int b_dodai = 0;
        try
        {
            b_dodai = int.Parse(b_tusinh.Rows[0]["DODAISOTHE"].ToString());
            b_dinhdang = b_tusinh.Rows[0]["TIENTO"].ToString();
            double b_tontai = 0;
            for (int i = 0; i < b_dodai - b_tusinh.Rows[0]["TIENTO"].ToString().Length; i++)
            {
                b_dinhdang = b_dinhdang + "0";
            }

            var b_dt_sothe = ht_dungchung.Fdt_NS_CB_MAX_MA(b_tusinh.Rows[0]["TIENTO"].ToString(), b_tusinh.Rows[0]["DODAISOTHE"].ToString(), b_dinhdang);
            if ((b_dt_sothe != null && b_dt_sothe.Rows.Count > 0) && !b_dt_sothe.Rows[0]["SO_THE"].Equals("0"))
            {
                var b_sothe = double.Parse(b_dt_sothe.Rows[0]["SO_THE"].ToString());
                do
                {
                    b_sothe = b_sothe + 1;
                    b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_sothe, b_dinhdang));
                    b_tontai = double.Parse(ht_dungchung.Fdt_NS_CB_HOI(b_SoTheCB).Rows[0]["TONTAI"].ToString());
                } while (b_tontai != 0);
            }
            else
                b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(1, b_dinhdang));
        }
        catch (Exception) { b_SoTheCB = b_dinhdang.Substring(0, b_dodai - 1).ToString() + "1"; }
        return b_SoTheCB;
    }
    #endregion PHÊ DUYỆT ỨNG VIÊN THÀNH NHÂN VIÊN

    #region QUẢN LÝ CHI PHÍ TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_PHI_TD_LKE(string b_login, string b_nam, string b_ma_yc, string b_cdanh, string b_phong, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Faobj_NS_TD_PHI_TD_LKE(b_nam, b_ma_yc, b_cdanh, b_phong, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CSO(ref b_dt_tk, "sl_tuyendung,tien_cphi");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHI_TD_MA(string b_login, string b_ma_yc, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_td.Faobj_NS_TD_PHI_TD_MA(b_ma_yc, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CSO(ref b_dt, "sl_tuyendung,tien_cphi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma_yc", b_ma_yc);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHI_TD_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "nam,sl_tuyendung,tien_cphi");
            ns_td.P_TD_PHI_TD_NH(b_dt_ct);
            string b_ma_yc = mang.Fs_TEN_GTRI("MA_YC", a_cot, a_gtri);
            return Fs_NS_TD_PHI_TD_MA(b_login, b_ma_yc, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PHI_TD_XOA(string b_login, string b_ma, string b_nam_tk, string b_ma_tk, string b_cdanhtk, string b_phongtk, double[] a_tso, string[] a_cot)
    {
        try { se.P_LOGIN(b_login); ns_td.P_TD_PHI_TD_XOA(b_ma); return Fs_NS_TD_PHI_TD_LKE(b_login, b_nam_tk, b_ma_tk, b_cdanhtk, b_phongtk, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ CHI PHÍ TUYỂN DỤNG

    #region KẾ HOẠCH TUYỂN DỤNG

    [WebMethod(true)]
    public string Fs_NS_TD_KH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_NS_TD_KH_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngay");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_KH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            string b_so_id = "0";
            object[] a_obj = ns_td.Fdt_NS_TD_KH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            if (b_hang > 0) b_so_id = b_dt.Rows[b_hang]["so_id"].ToString();
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_KH_CT(string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_td.Fdt_NS_TD_KH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, "ngay,ngaydk"); bang.P_SO_CSO(ref b_dt, "kinhphi");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    // trả giá trị 
    [WebMethod(true)]
    public string Fs_NS_TD_MAKH_TRA(string b_ma, string[] a_cot_tt, string[] a_cot_yc)
    {
        try
        {
            string b_kq = "";
            DataTable b_dt = ns_td.Fdt_NS_TD_MAKH_TRA(b_ma);
            if (b_dt.Rows.Count > 0)
            {
                bang.P_THEM_COL(ref b_dt, new string[] { "loai", "ngaycan", "luong_dkien", "lydo", "bangcap", "chuyenmon", "ngoaingu", "uutien", "yckhac" }, new string[] { "", "", "", "", "", "", "", "", "" });
                b_kq = bang.Fs_BANG_CH(b_dt, a_cot_tt) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_yc);
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    // trả giá trị 
    [WebMethod(true)]
    public string Fs_NS_TD_LAY_TUYENDUNG(string b_ma, string[] a_cot_tt, string[] a_cot_yc)
    {
        try
        {
            DataSet b_ds = ns_td.Fdt_NS_TD_LAY_TUYENDUNG(b_ma);
            return bang.Fs_BANG_CH(b_ds.Tables[0], "SL_DUOCTUYEN") + "#" + bang.Fs_BANG_CH(b_ds.Tables[0], "LAN") + "#" + bang.Fs_BANG_CH(b_ds.Tables[0], "SL_CANTUYEN") + "#" + bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_tt) + "#" + bang.Fs_BANG_CH(b_ds.Tables[2], a_cot_yc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_KH_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay,ngaydk");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            for (int j = 0; j < b_dt_ct.Rows.Count; j++) b_dt_ct.Rows[j]["sott"] = j + 1;
            bang.P_BO_HANG(ref b_dt_ct, "cdanh", "");
            if (b_dt_ct.Rows.Count == 0) return "loi:Phải nhập đủ chi tiết:loi";
            bang.P_CSO_SO(ref b_dt_ct, "heso");
            ns_td.PNS_TD_KH_NH(b_so_id, b_dt, b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TD_KH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KH_XOA(string b_so_id, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        { ns_td.PNS_TD_KH_XOA(b_so_id); return Fs_NS_TD_KH_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion KẾ HOẠCH TUYỂN DỤNG

    #region HỒ SƠ ỨNG VIÊN
    [WebMethod(true)]
    public string Fs_NS_TD_HSUV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_NS_TD_HSUV_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_HSUV_MA(string b_cmt, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_tl_tlap_bh_MA(b_cmt, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "cmt", b_cmt);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_HSUV_CT(string b_cmt)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_HSUV_CT(b_cmt);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_HSUV_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_td.P_NS_TD_HSUV_NH(b_dt_ct);
            string b_cmt = mang.Fs_TEN_GTRI("cmt", a_cot, a_gtri);
            return Fs_NS_TD_HSUV_MA(b_cmt, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_HSUV_XOA(string b_cmt, double[] a_tso, string[] a_cot)
    {
        try { ns_td.PNS_TD_HSUV_XOA(b_cmt); return Fs_NS_TD_HSUV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion HỒ SƠ ỨNG VIÊN

    #region LỊCH PHỎNG VẤN
    [WebMethod(true)]
    public string Fs_NS_TD_LICHPV_CT(string b_phong, string b_nam, string b_so_id, string b_dk, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_td.Fdt_NS_TD_LICHPV_CT(b_phong, b_nam, b_so_id);
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_ds.Tables[0], 0),
                   b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
            return b_dt_s + b_dk + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_LICHPV_LKE(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_LICHPV_LKE(b_phong, b_nam);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_LICHPV_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            return ns_td.P_NS_TD_LICHPV_NH(ref b_so_id, b_dt, b_dt_ct);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_LICHPV_XOA(string b_phong, string b_so_id)
    {
        try
        {
            ns_td.PNS_TD_LICHPV_XOA(b_phong, b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_LICHPV_LKE_UV(string b_nhom_cdanh, string b_ma_cdanh, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_LICHPV_LKE_UV(b_nhom_cdanh, b_ma_cdanh);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion LỊCH PHỎNG VẤN

    #region ĐỢT TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_NS_TD_DOT_LKE(string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_NS_TD_DOT_LKE(b_nam, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DOT_MA(string b_nam, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_NS_TD_DOT_MA(b_nam, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2]; bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma" }, new object[] { b_ma });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DOT_CT(string b_so_id, string[] a_cot_yc, string[] a_cot_vg)
    {
        try
        {
            DataSet b_ds = ns_td.Fds_NS_TD_DEXUAT_CN_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, new string[] { "ngayd,ngayc" });
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            DataTable b_dt_ct = b_ds.Tables[1];
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_yc),
                   b_dt_yc_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_vg);
            return b_dt_s + "#" + b_dt_tt_s + "#" + b_dt_yc_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DOT_NH(double b_trangKT, string b_so_id, object[] a_dt, object[] a_dt_yc, object[] a_dt_vg, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            string[] a_cot_yc = chuyen.Fas_OBJ_STR((object[])a_dt_yc[0]); object[] a_gtri_yc = (object[])a_dt_yc[1];
            string[] a_cot_vg = chuyen.Fas_OBJ_STR((object[])a_dt_vg[0]); object[] a_gtri_vg = (object[])a_dt_vg[1];
            DataTable b_dt_yc = bang.Fdt_TAO_THEM(a_cot_yc, a_gtri_yc), b_dt_vg = bang.Fdt_TAO_THEM(a_cot_vg, a_gtri_vg);
            bang.P_BO_HANG(ref b_dt_yc, "sott", ""); bang.P_BO_HANG(ref b_dt_vg, "sott", "");
            ns_td.PNS_TD_DOT_NH(b_so_id, b_dt, b_dt_yc, b_dt_vg);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_TD_DOT_MA(b_nam, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DOT_XOA(string b_so_id, string b_nam, double[] a_tso, string[] a_cot)
    {
        try
        { ns_td.PNS_TD_DOT_XOA(b_so_id); return Fs_NS_TD_DOT_LKE(b_nam, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DOT_HOI_CDANH(string b_nhom_cdanh, string b_cdanh)
    {
        try
        {
            DataTable b_dt = ns_td.PNS_TD_DOT_HOI_CDANH(b_nhom_cdanh, b_cdanh);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DOT_HOI_DXUAT(string b_so_id, string b_ma_dxuat, int b_sott, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.PNS_TD_DOT_HOI_DXUAT(b_so_id);
            bang.P_THEM_COL(ref b_dt, "ma_dxuat", b_ma_dxuat);
            bang.P_THEM_COL(ref b_dt, "sott");

            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_sott = ++b_sott;
                bang.P_DAT_GTRI(ref b_dt, "sott", b_sott, i);
            }
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐỢT TUYỂN DỤNG

    #region CV ONLINE

    [WebMethod(true)]
    public string Fs_NS_TD_CV_ONLINE_NH(object[] a_cdanh, object[] a_dt, object[] a_dt_dt, object[] a_dt_tt, object[] a_dt_gd, object[] a_dt_dt_ct, object[] a_dt_tt_ct)
    {
        try
        {
            string[] a_cot_cdanh = chuyen.Fas_OBJ_STR((object[])a_cdanh[0]); object[] a_gtri_cdanh = (object[])a_cdanh[1];
            DataTable b_cdanh = bang.Fdt_TAO_THEM(a_cot_cdanh, a_gtri_cdanh);

            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "nsinh");

            string[] a_cot_dt_dt = chuyen.Fas_OBJ_STR((object[])a_dt_dt[0]); object[] a_gtri_dt_dt = (object[])a_dt_dt[1];
            DataTable b_dt_dt = bang.Fdt_TAO_THEM(a_cot_dt_dt, a_gtri_dt_dt);

            string[] a_cot_dt_tt = chuyen.Fas_OBJ_STR((object[])a_dt_tt[0]); object[] a_gtri_dt_tt = (object[])a_dt_tt[1];
            DataTable b_dt_tt = bang.Fdt_TAO_THEM(a_cot_dt_tt, a_gtri_dt_tt);

            string[] a_cot_gd = chuyen.Fas_OBJ_STR((object[])a_dt_gd[0]); object[] a_gtri_gd = (object[])a_dt_gd[1];
            DataTable b_dt_gd = bang.Fdt_TAO_THEM(a_cot_gd, a_gtri_gd);
            bang.P_BO_HANG(ref b_dt_gd, "ten", "");
            if (b_dt_gd.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_gd, new object[] { "-1", "", "", "", "", "" });

            string[] a_cot_dt_ct = chuyen.Fas_OBJ_STR((object[])a_dt_dt_ct[0]); object[] a_gtri_dt_ct = (object[])a_dt_dt_ct[1];
            DataTable b_dt_dt_ct = bang.Fdt_TAO_THEM(a_cot_dt_ct, a_gtri_dt_ct);
            bang.P_CTH_SO(ref b_dt_dt_ct, "tuthang,toithang");
            bang.P_BO_HANG(ref b_dt_dt_ct, "congty", "");
            if (b_dt_dt_ct.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_dt_ct, new object[] { "-1", "", "", "300001", "300001" });

            string[] a_cot_tt_ct = chuyen.Fas_OBJ_STR((object[])a_dt_tt_ct[0]); object[] a_gtri_tt_ct = (object[])a_dt_tt_ct[1];
            DataTable b_dt_tt_ct = bang.Fdt_TAO_THEM(a_cot_tt_ct, a_gtri_tt_ct);
            bang.P_BO_HANG(ref b_dt_tt_ct, "tentruong", "");
            if (b_dt_tt_ct.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_tt_ct, new object[] { "-1", "", "", "", "" });

            ns_td.Fdt_NS_TD_CV_ONLINE_NH(b_cdanh, b_dt, b_dt_dt, b_dt_tt, b_dt_gd, b_dt_tt_ct, b_dt_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DS_UVIEN_LKE(string b_cdanh, string[] a_cot)
    {
        try
        {
            DataTable b_dt_tk = ns_td.Fdt_NS_TD_DS_UVIEN_LKE(b_cdanh);
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa thi/phỏng vấn");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đang thi/phỏng vấn");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Đã offer");
            bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            //bang.P_SO_CSO(ref b_dt_tk, "tongdiem");
            //bang.P_SO_CSO(ref b_dt_tk, "lan");
            //bang.P_SO_CNG(ref b_dt_tk, "nsinh"); bang.P_SO_CSO(ref b_dt_tk, "luongmuon");
            return bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_CV_ONLINE_CT(string b_cdanh, string b_cmt, string[] a_cot_gd, string[] a_cot_hdct, string[] a_cot_td)
    {
        try
        {
            DataSet b_ds = ns_td.Fdt_NS_TD_CV_ONLINE_CT(b_cdanh, b_cmt);
            DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "nsinh");
            DataTable b_dt_gd = b_ds.Tables[1];
            DataTable b_dt_hdct = b_ds.Tables[2]; bang.P_SO_CTH(ref b_dt_hdct, "tuthang,toithang");
            DataTable b_dt_td = b_ds.Tables[3];
            string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_gd_s = bang.Fb_TRANG(b_dt_gd) ? "" : bang.Fs_BANG_CH(b_dt_gd, a_cot_gd);
            string b_dt_hdct_s = bang.Fb_TRANG(b_dt_hdct) ? "" : bang.Fs_BANG_CH(b_dt_hdct, a_cot_hdct);
            string b_dt_td_s = bang.Fb_TRANG(b_dt_td) ? "" : bang.Fs_BANG_CH(b_dt_td, a_cot_td);
            return b_dt_s + "#" + b_dt_gd_s + "#" + b_dt_hdct_s + "#" + b_dt_td_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_LKE_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            string b_tt = "", b_dt = "", b_hdct = "";
            DataSet b_ds = ns_td.Fds_NS_TD_LKE_CT(b_so_id);
            DataTable b_dt_lke = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt_lke, new string[] { "ngay_thi" });
            DataTable b_dt_tt = b_ds.Tables[1]; bang.P_SO_CNG(ref b_dt_tt, new string[] { "nsinh" });
            if (b_dt_tt.Rows.Count > 0)
            {
                b_tt = "\n\b(*) Thông tin:";
                for (int i = 0; i < b_dt_tt.Rows.Count; i++)
                {
                    b_tt = b_tt + "\n\b  - Họ tên: " + b_dt_tt.Rows[i]["ten"].ToString() + "     - Ngày sinh: " + b_dt_tt.Rows[i]["nsinh"].ToString() + "     - Giới tính:" + b_dt_tt.Rows[i]["gtinh"].ToString();
                    b_tt = b_tt + "\n\b  - Quê quán: " + b_dt_tt.Rows[i]["quequan"].ToString() + "     - Địa chỉ: " + b_dt_tt.Rows[i]["noiohiennay"].ToString();
                    b_tt = b_tt + "\n\b  - Công việc mong muốn: " + b_dt_tt.Rows[i]["cvmuon"].ToString();
                    ////// Son fix.
                    CultureInfo cul = CultureInfo.GetCultureInfo("vi-VN");   // try with "en-US"
                    string luong = Int64.Parse(b_dt_tt.Rows[i]["luongmuon"].ToString()).ToString("#,###", cul.NumberFormat);
                    if (luong == "") b_tt = b_tt + "\n\b  - Lương mong muốn:"; else b_tt = b_tt + "\n\b  - Lương mong muốn: " + luong + " đ";
                    //b_tt = b_tt + "\n\b  - Lương mong muốn: " + b_dt_tt.Rows[i]["luongmuon"].ToString();
                    //////
                    b_tt = b_tt + "\n\b  - Điểm mạnh: " + b_dt_tt.Rows[i]["diemmanh"].ToString();
                    b_tt = b_tt + "\n\b  - Điểm yếu: " + b_dt_tt.Rows[i]["diemyeu"].ToString();
                }
            }
            DataTable b_dt_dt = b_ds.Tables[2];
            if (b_dt_dt.Rows.Count > 0)
            {
                b_dt = "\n\b(*) Thông tin đào tạo:";
                for (int i = 0; i < b_dt_tt.Rows.Count; i++)
                {
                    b_dt = b_dt + "\n\b  - Tên trường: " + b_dt_dt.Rows[i]["tentruong"].ToString() + "     - Ngành: " + b_dt_dt.Rows[i]["nganh"].ToString() + "     - Bằng cấp:" + b_dt_dt.Rows[i]["vanbang"].ToString();
                }
            }
            DataTable b_dt_hdct = b_ds.Tables[3]; bang.P_SO_CTH(ref b_dt_hdct, "tuthang,toithang");
            if (b_dt_hdct.Rows.Count > 0)
            {
                b_hdct = "\n\b(*) Thông tin làm việc:";
                for (int i = 0; i < b_dt_hdct.Rows.Count; i++)
                {
                    b_hdct = b_hdct + "\n\b  - Công ty: " + b_dt_hdct.Rows[i]["congty"].ToString() + "     - Thời gian: " + b_dt_hdct.Rows[i]["tuthang"].ToString() + "-" + b_dt_hdct.Rows[i]["toithang"].ToString() + "     - Công việc:" + b_dt_hdct.Rows[i]["congviec"].ToString() + "     - Lý do nghỉ:" + b_dt_hdct.Rows[i]["lydonghi"].ToString();
                }
            }

            return b_tt + b_dt + b_hdct + "#" + bang.Fs_BANG_CH(b_dt_lke, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_TD_DS_UVIEN_NH(string b_so_id, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_thi");
            ns_td.P_NS_TD_DS_UVIEN_NH(b_so_id, b_dt);
            DataTable b_kq = ns_td.P_NS_TD_DS_UVIEN_LKE(b_so_id);
            bang.P_SO_CNG(ref b_kq, "ngay_thi");
            return bang.Fs_BANG_CH(b_kq, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_DS_UVIEN_NH_LKE_CT(string b_so_id, string b_vong)
    {
        try
        {
            DataTable b_dt = ns_td.P_NS_TD_DS_UVIEN_CT(b_so_id, b_vong);
            bang.P_SO_CNG(ref b_dt, "ngay_thi");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CDANH_CV(string b_ncdanh)
    {
        DataTable b_dt = ht_dungchung.Fdt_CDANH_CV(b_ncdanh);
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_NS_TD_DS_UVIEN_NH_LKE_XOA(string b_so_id, string b_vong, string[] a_cot_lke)
    {
        try
        {

            ns_td.P_NS_TD_DS_UVIEN_XOA(b_so_id, b_vong);
            DataTable b_kq = ns_td.P_NS_TD_DS_UVIEN_LKE(b_so_id);
            bang.P_SO_CNG(ref b_kq, "ngay_thi");
            return bang.Fs_BANG_CH(b_kq, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_TD_DS_TUYENDUNG(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong_chonungvien;
            }
            ns_td.P_NS_TD_DS_UVIEN_TUYENDUNG(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion CV ONLINE

    #region BLACKLIST
    [WebMethod(true)]
    public string Fs_BLACKLIST_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_Fs_BLACKLIST_LKE(b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_sinh");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_BLACKLIST_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_sinh");
            ns_td.P_BLACKLIST_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("socmt", a_cot, a_gtri);
            return Fs_BLACKLIST_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_BLACKLIST_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_BLACKLIST_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_sinh");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "socmt", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_BLACKLIST_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_td.P_BLACKLIST_XOA(b_ma); return Fs_BLACKLIST_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion BLACKLIST

    #region KHO ỨNG VIÊN (KHONG DUNG CHO CORRP)
    [WebMethod(true)]
    public string Fs_NS_TD_KHO_UVIEN_LKE(string b_ma_cmt, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_Fs_KHO_UVIEN_LKE(b_ma_cmt, b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_sinh");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_KHO_UVIEN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_sinh");
            ns_td.P_KHO_UVIEN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("cmt", a_cot, a_gtri);
            return Fs_NS_TD_KHO_UVIEN_MA(b_ma, 1, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHO_UVIEN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_KHO_UVIEN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_sinh");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "cmt", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHO_UVIEN_TIM(string b_ncdanh, string b_cdanh, string b_cmt, string b_gt, double b_trangkt, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_KHO_UVIEN_TIM(b_ncdanh, b_cdanh, b_cmt, b_gt, b_trangkt, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_sinh");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_KHO_UVIEN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_td.P_KHO_UVIEN_XOA(b_ma); return Fs_NS_TD_KHO_UVIEN_TIM("", "", "", "", 13, a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region TỔNG HỢP KẾ HOẠCH TUYỂN DỤNG

    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_LKE(string b_phong, string b_kyluong, string[] a_cot)
    {
        try
        {
            //object[] a_obj = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_LKE(b_phong, 1, 10000, b_kyluong);
            //DataTable b_dt_tk = (DataTable)a_obj[1]; bang.P_SO_CTH(ref b_dt_tk, "thang");
            DataTable b_dt_tk = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_LKE(b_phong, 1, 10000, b_kyluong);
            return chuyen.OBJ_S(b_dt_tk) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_CT(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_CT(b_phong, b_nam);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;

            // bang.P_SO_CSO(ref b_dt, "LUONG_CB,TROCAP_KD,PHUCAP,TONG_LUONG,TONGCONG_LV,CONG_LETET,CONG_CHEDO,CONG_DAOTAO,CONG_CT,TONGCONG_HL,TONGCONG_NGHI_HL,OT_TINHTHUE,OT_MIENTHUE,TONG_LUONG_THEONGAY,LUONG_NGOAIGIO,TONG_PHUCAP,KHOAN_THUONG,TONG_PHUCLOI,TRUYTHU_TRUYLINH,TONG_THUNHAP,TRU_BHXH_BHYT,TRU_BHTN,TRU_CDP,GIAMTRU_BANTHAN,SOTIEN_GIACANH,TONG_THUNHAP_TINHTHUE,THUE_TNCN,THUNHAP_THUCNHAN");
            // return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_MA(string b_phong, string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_MA(b_phong, b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2]; bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }




    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_NH(double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CTH_SO(ref b_dt, "thang");
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "so_the", "");
            ns_td.P_HDNS_TH_KH_TUYENDUNG_NH(b_dt, b_dt_ct);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_thang = mang.Fs_TEN_GTRI("thang", a_cot, a_gtri);
            return Fs_HDNS_TH_KH_TUYENDUNG_MA(b_phong, b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_XOA(string b_phong, string b_thang, double[] a_tso, string[] a_cot)
    {
        try
        { ns_td.P_HDNS_TH_KH_TUYENDUNG_XOA(b_phong, b_thang); return Fs_HDNS_TH_KH_TUYENDUNG_LKE(b_phong, "", a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_LKE_CB(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_LKE_CB(b_phong, b_thang);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_TINH(string b_phong, string b_nam, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_TINH(b_phong, b_nam);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_TINH_XUANTHANH(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_TINH_XUANTHANH(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "doanhthu,luong_doanhthu,luong_tg,luong_sp,luong_nn,luong_cv,luong_khoan,luong_bh,pcap,tnhap_chiuthue,tnhap_kchiuthue,ktru_chiuthue,ktru_kchiuthue,bhxh,bhyt,bhtn,anca,pcd,ct_bhxh,ct_bhyt,ct_bhtn,ct_pcd,truthue,tongchiuthue,phuthuoc,tam_ung,thuc_linh,TN_TINHTHUE,TNHAPCHIUTHUE,PHAITRA_NLD,CHENHCA,TONG_LUONG");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_TH_KH_TUYENDUNG_TINH_OKI(string b_phong, string b_thang, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_HDNS_TH_KH_TUYENDUNG_TINH_OKI(b_phong, b_thang);
            bang.P_SO_CSO(ref b_dt, "luong_tg,luong_sp,luong_nn,luong_cv,luong_khoan,luong_bh,pcap,tnhap_chiuthue,tnhap_kchiuthue,ktru_chiuthue,ktru_kchiuthue,bhxh,bhyt,bhtn,anca,pcd,ct_bhxh,ct_bhyt,ct_bhtn,ct_pcd,truthue,tongchiuthue,phuthuoc,tam_ung,thuc_linh");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    #endregion

    #region ĐỊNH BIÊN NHÂN SỰ
    [WebMethod(true)]
    public string Fs_NS_HDNS_DBIEN_LKE(string b_login, object[] a_dt_tk, string b_cty, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            object[] a_obj = ns_td.Faobj_NS_HDNS_DBIEN_LKE(b_dt_tk, b_cty, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DBIEN_NH(string b_login, object[] a_dt, object[] a_dt_ct, string b_cty, string[] a_cot_lke, double[] a_tso, object[] a_dt_tk)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_CSO_SO(ref b_dt_ct, "ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12");
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_DON(ref b_dt_ct, "ten_cdanh");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_td.Fdt_NS_HDNS_DBIEN_NH(b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_DBIEN, TEN_BANG.NS_HDNS_DBIEN);
            return Fs_NS_HDNS_DBIEN_LKE(b_login, a_dt_tk, b_cty, a_tso, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_TONGNHANSU(double b_nam, string b_phong, string b_cdanh)
    {
        try
        {
            DataTable b_dt = hts_dungchung.Fdt_NS_TONG_NHANSU(b_nam, b_phong, b_cdanh);
            if (b_dt == null || b_dt.Rows.Count <= 0)
                return "0";
            return b_dt.Rows[0]["tong"].ToString() + "#" + b_dt.Rows[0]["NGHIVIEC"].ToString() + "#" + b_dt.Rows[0]["ns_datuyen"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_TONGNHANSU_PHONG(object[] a_dt_tk, string[] a_cot)
    {
        try
        {
            string[] a_cot_tk = chuyen.Fas_OBJ_STR((object[])a_dt_tk[0]); object[] a_gtri_tk = (object[])a_dt_tk[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot_tk, a_gtri_tk);
            DataTable b_dt = ht_dungchung.Fdt_NS_TONG_NHANSU_PHONG(b_dt_tk);
            bang.P_SO_CSO(ref b_dt, "ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12");

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DBIEN_CT(string b_login, string b_nam, string b_donvi, string[] a_cot_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_td.Fdt_NS_HDNS_DBIEN_CT(b_nam, b_donvi);
            bang.P_SO_CSO(ref b_dt, "ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12");

            bang.P_TIM_THEM(ref b_dt, "ns_hdns_dbien", "DT_DONVI", "DONVI");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_tt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_ct);
            return b_dt_s + "#" + b_dt_tt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DBIEN_XOA(string b_login, string b_nam, string b_donvi, double[] a_tso, string[] a_cot, object[] a_dt_tk, string b_cty)
    {
        try
        {
            se.P_LOGIN(b_login); ns_td.P_NS_HDNS_DBIEN_XOA(b_nam, b_donvi);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_DBIEN, TEN_BANG.NS_HDNS_DBIEN);
            return Fs_NS_HDNS_DBIEN_LKE(b_login, a_dt_tk, b_cty, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐỊNH BIÊN NHÂN SỰ

    #region LỊCH SỬ ĐIỀU CHỈNH ĐỊNH BIÊN
    [WebMethod(true)]
    public string Fs_NS_HDNS_LSDBIEN_LKE(string b_login, string b_nam, string b_donvi, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_td.Faobj_NS_HDNS_LSDBIEN_LKE(b_nam, b_donvi, b_tu_n, b_den_n); ;
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_LSDBIEN_CT(string b_nam, string b_lansua, string[] a_cot_ct)
    {
        try
        {
            DataTable b_ds = ns_td.Fdt_NS_HDNS_LSDBIEN_CT(b_nam, b_lansua);
            DataTable b_dt = b_ds;
            bang.P_SO_CSO(ref b_dt, "ns_hientai,dinhbien_t1,dinhbien_t2,dinhbien_t3,dinhbien_t4,dinhbien_t5,dinhbien_t6,dinhbien_t7,dinhbien_t8,dinhbien_t9,dinhbien_t10,dinhbien_t11,dinhbien_t12,phatsinh_t1,phatsinh_t2,phatsinh_t3,phatsinh_t4,phatsinh_t5,phatsinh_t6,phatsinh_t7,phatsinh_t8,phatsinh_t9,phatsinh_t10,phatsinh_t11,phatsinh_t12,tong_t1,tong_t2,tong_t3,tong_t4,tong_t5,tong_t6,tong_t7,tong_t8,tong_t9,tong_t10,tong_t11,tong_t12");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_tt_s = bang.Fb_TRANG(b_ds) ? "" : bang.Fs_BANG_CH(b_ds, a_cot_ct);
            return b_dt_s + "#" + b_dt_tt_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion LỊCH SỬ ĐIỀU CHỈNH ĐỊNH BIÊN

    #region PHÂN TÍCH NGUỒN LỰC
    [WebMethod(true)]
    public string Fs_HDNS_PT_NGUONLUC_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_Fs_HDNS_PT_NGUONLUC_LKE(b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CTH(ref b_dt_tk, "thang");
            return "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_PT_NGUONLUC_MA(string b_thang, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_Fs_HDNS_PT_NGUONLUC_MA(b_thang, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "thang", b_thang);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_PT_NGUONLUC_NH(string b_thang, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            double thang = chuyen.CTH_SO(b_thang);
            bang.P_CSO_SO(ref b_dt_ct, "ns_hientai,NS_THANGTIEN,CDANH_THANGTIEN,NS_DUKIEN_TS,NS_DUKIEN_NV");
            bang.P_BO_HANG(ref b_dt_ct, "phong", "");
            if (b_dt_ct == null && b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_td.P_Fs_HDNS_PT_NGUONLUC_NH(thang, b_dt_ct);
            return Fs_HDNS_PT_NGUONLUC_MA(b_thang, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_PT_NGUONLUC_CT(string b_thang, string[] a_cot_ct)
    {
        try
        {
            DataTable b_ds = ns_td.Fdt_HDNS_PT_NGUONLUC_CT(b_thang);
            bang.P_SO_CTH(ref b_ds, "thang");
            DataTable b_dt = b_ds;
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

            string b_dt_tt_s = bang.Fb_TRANG(b_ds) ? "" : bang.Fs_BANG_CH(b_ds, a_cot_ct);
            return b_dt_s + "#" + b_dt_tt_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_PT_NGUONLUC_XOA(string b_thang, double[] a_tso, string[] a_cot)
    {
        try { ns_td.P_Fs_HDNS_PT_NGUONLUC_XOA(b_thang); return Fs_HDNS_PT_NGUONLUC_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion PHÂN TÍCH NGUỒN LỰC

    #region KẾ HOẠCH TUYỂN DỤNG
    [WebMethod(true)]
    public string Fs_HDNS_KH_TUYENDUNG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_td.Fdt_Fs_HDNS_KH_TUYENDUNG_LKE(b_tu_n, b_den_n);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CTH(ref b_dt_tk, "thang");
            return "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_KH_TUYENDUNG_MA(string b_ma, string b_nam, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_td.Fdt_Fs_HDNS_KH_TUYENDUNG_MA(b_ma, b_nam, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CTH(ref b_dt, "thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_KH_TUYENDUNG_NH(string a_ma, string a_nam, object[] a_dt, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            string[] a_cot2 = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri2 = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot2, a_gtri2);


            bang.P_CSO_SO(ref b_dt_ct, "heso,SOLUONG_CANTUYEN");
            bang.P_CTH_SO(ref b_dt, "thang");
            bang.P_CNG_SO(ref b_dt_ct, "khoach_ngay,ngay_dl");
            bang.P_BO_HANG(ref b_dt_ct, "phong", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {

                if (b_dt_ct.Rows[i]["PHONG"].ToString().Equals("") /* || b_dt_ct.Rows[i]["NCDANH"].ToString().Equals("") */ || b_dt_ct.Rows[i]["cdanh"].ToString().Equals("") || b_dt_ct.Rows[i]["bcdanh"].ToString().Equals("") || b_dt_ct.Rows[i]["khoach_ngay"].ToString().Equals("") || b_dt_ct.Rows[i]["ngay_dl"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
                string Ngaylapkh = "Ngày lập kế hoạch";
                string Ngaydl = "Ngày dự kiến đi làm";
                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_ct.Rows[i]["khoach_ngay"].ToString()), ref Ngaylapkh) == false)
                {
                    return Ngaylapkh;
                }
                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_ct.Rows[i]["ngay_dl"].ToString()), ref Ngaydl) == false)
                {
                    return Ngaydl;
                }
                if (chuyen.CSO_SO(b_dt_ct.Rows[i]["khoach_ngay"].ToString()) > chuyen.CSO_SO(b_dt_ct.Rows[i]["ngay_dl"].ToString()))
                {
                    return Thongbao_dch.ktNgaylap_khoach;
                }
            }
            ns_td.P_Fs_HDNS_KH_TUYENDUNG_NH(b_dt, b_dt_ct);
            return Fs_HDNS_KH_TUYENDUNG_MA(a_ma, a_nam, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_KH_TUYENDUNG_CT(string b_ma, string[] a_cot_ct)
    {
        try
        {
            DataTable b_ds = ns_td.Fdt_HDNS_KH_TUYENDUNG_CT(b_ma);
            DataTable b_dt = b_ds;
            bang.P_SO_CTH(ref b_dt, "thang");
            bang.P_SO_CNG(ref b_dt, "khoach_ngay,ngay_dl");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);

            string b_dt_tt_s = bang.Fb_TRANG(b_ds) ? "" : bang.Fs_BANG_CH(b_ds, a_cot_ct);
            return b_dt_s + "#" + b_dt_tt_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_KH_TUYENDUNG_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_td.P_Fs_HDNS_KH_TUYENDUNG_XOA(b_ma); return Fs_HDNS_KH_TUYENDUNG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KẾ HOẠCH TUYỂN DỤNG

    #region "THÔNG KÊ DASHBOAD"
    [WebMethod(true)]
    public string Fs_NS_THONGBAO_THONGKE_CT(string b_ma)
    {
        try
        {
            DataSet b_ds = ns_td.Fdt_NS_THONGBAO_THONGKE_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt1 = b_ds.Tables[1];
            string b_values = hts_dungchung.DataTableToJSON2(b_dt).Replace("NAME", "name").Replace("Y", "y");
            // b_values = "{\"status\":1,\"data\":" + b_values + "}";
            return b_values + "#" + b_dt1.Rows[0]["tong_ns"].ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_THONGBAO_BDSNS_CT(string b_ma)
    {
        try
        {
            string b_donvi = "", b_tong = "", b_nghiviec = "", b_nghiviec_tv = "", b_tangmoi = "";
            int b_tong_ns = 0, b_tong_tang_moi = 0, b_tong_nghiviec = 0, b_tong_nv_tv = 0;
            DataTable b_dt = ns_td.Fdt_NS_THONGBAO_BDNS_CT(b_ma);
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_donvi = b_donvi + b_dt.Rows[i]["ma_dvi"].ToString() + ",";
                b_tong = b_tong + (Convert.ToInt32(b_dt.Rows[i]["tong"]) + (i * 20)).ToString() + ",";
                b_nghiviec = b_nghiviec + b_dt.Rows[i]["nghiviec"].ToString() + ",";
                b_tangmoi = b_tangmoi + (Convert.ToInt32(b_dt.Rows[i]["tangmoi"]) + (i * 50)).ToString() + ",";
                b_nghiviec_tv = b_nghiviec_tv + b_dt.Rows[i]["nghiviec_tv"].ToString() + ",";
                b_tong_ns = b_tong_ns + int.Parse(b_dt.Rows[i]["tong"].ToString());
                b_tong_tang_moi = b_tong_tang_moi + int.Parse(b_dt.Rows[i]["tangmoi"].ToString());
                b_tong_nghiviec = b_tong_nghiviec + int.Parse(b_dt.Rows[i]["nghiviec"].ToString());
                b_tong_nv_tv = b_tong_nv_tv + int.Parse(b_dt.Rows[i]["nghiviec_tv"].ToString());
            }
            b_donvi = b_donvi.TrimEnd(',');
            b_tong = b_tong.TrimEnd(',');
            b_nghiviec = b_nghiviec.TrimEnd(',');
            b_tangmoi = b_tangmoi.TrimEnd(',');
            b_nghiviec_tv = b_nghiviec_tv.TrimEnd(',');

            // b_values = "{\"status\":1,\"data\":" + b_values + "}";
            return b_donvi + "#" + b_tong + "#" + b_nghiviec + "#" + b_tangmoi + "#" + b_nghiviec_tv + "#" + b_tong_ns + "#" + b_tong_tang_moi + "#" + b_tong_nghiviec + "#" + b_tong_nv_tv;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    //[WebMethod(true)]
    //public string Fs_NS_THONGBAO_TALENT_CT(string b_ncdanh, string b_ky)
    //{
    //    try
    //    {
    //        string b_donvi = "", b_tong = "";
    //        DataTable b_dt = ns_td.Fdt_NS_THONGBAO_TALENT_CT(b_ncdanh, b_ky);
    //        for (int i = 0; i < b_dt.Rows.Count; i++)
    //        {
    //            b_donvi = b_donvi + b_dt.Rows[i]["ma_dvi"].ToString() + ",";
    //            b_tong = b_tong + b_dt.Rows[i]["count"].ToString() + ",";
    //        }
    //        b_donvi = b_donvi.TrimEnd(',');
    //        b_tong = b_tong.TrimEnd(',');

    //        return b_donvi + "#" + b_tong;
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    #endregion

    #region  QUẢN LÝ PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG

    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_QL_LKE(string b_nam, string b_ma_dx, string b_tinhtrang, string b_so_the_tk, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_td.Fdt_NS_TD_PD_CDANH_TD_QL_LKE(b_nam, b_ma_dx, b_tinhtrang, b_so_the_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngaysinh,ngaygui");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return form.Fs_LOC_LOI(ex.ToString());
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_QL_PHEDUYET(object[] a_dt)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri_ct = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt, "chon", "");

            if (b_dt == null || b_dt.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_kq = ns_td.Fdt_NS_TD_PD_CDANH_TD_QL_PHEDUYET(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_TD_PD_CDANH_TD_QL, TEN_BANG.NS_TD_PD_CDANH_TD_QL);

            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.ToString());
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TD_PD_CDANH_TD_QL_KOPHEDUYET(object[] a_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            if (b_dt == null || b_dt.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_kq = ns_td.Fdt_NS_TD_PD_CDANH_TD_QL_KOPHEDUYET(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_TD_PD_CDANH_TD_QL, TEN_BANG.NS_TD_PD_CDANH_TD_QL);

            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi"))
                return form.Fs_LOC_LOI(ex.ToString());
            else
                return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion QUẢN LÝ PHÊ DUYỆT CHỨC DANH TUYỂN DỤNG

}