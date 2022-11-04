using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;

[System.Web.Script.Services.ScriptService]
public class sns_hdns : System.Web.Services.WebService
{

    #region MÃ NGÀNH NGHỀ
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NN_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NN_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NN_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NN_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_NN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NN_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NN_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_NN_XOA(b_ma); return Fs_NS_HDNS_MA_NN_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NGÀNH NGHỀ

    #region MÃ CHUYÊN MÔN
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_MA(string b_login, string b_ma_nn, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CM_MA(b_ma, b_ma_nn, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_DROP_MA(string b_login, string b_mann)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt = ns_hdns.Fdt_NS_HDNS_MA_CM_DROP_MA(b_mann);
            // if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" });
            se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_CM", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CM_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_cm", "DT_NN", "MA_NN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CM_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_CM_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri), b_ma_nn = mang.Fs_TEN_GTRI("ma_nn", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_CM_MA(b_login, b_ma_nn, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CM_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_HDNS_MA_CM_XOA(b_so_id); return Fs_NS_HDNS_MA_CM_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ CHUYÊN MÔN

    #region MÃ NGẠCH NGHỀ NGHIỆP
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NNN_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NNN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NNN_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NNN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NNN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NNN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_NNN_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_NNN, TEN_BANG.NS_HDNS_MA_NNN);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NNN_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NNN_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            string thongbao = "";
            //double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_MA_NNN, ht_dungchung.MA, b_ma, ref thongbao);
            //if (b_tontai > 0) return "loi:Bản ghi đã sử dụng ở chức năng khác, không được xóa:loi";
            ns_hdns.P_NS_HDNS_MA_NNN_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_NNN, TEN_BANG.NS_HDNS_MA_NNN);
            return Fs_NS_HDNS_MA_NNN_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NGẠCH NGHỀ NGHIỆP

    #region MÃ BẬC NGHỀ NGHIỆP
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_MA(string b_login, string b_ma_nnn, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CBNN_MA(b_ma, b_ma_nnn, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma" }, new string[] { b_ma });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_DROP(string b_login, string b_mann)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt = ns_hdns.Fdt_NS_HDNS_MA_CBNN_DROP_MA(b_mann);
            se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_CB", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_DROP_MA(string b_login, string b_mann, string b_formName, string b_table_name)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CBNN_DROP_MA(b_mann);
            se.P_TG_LUU(b_formName, b_table_name, b_dt);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_DROP_MA_TT(string b_login, string b_mann, string b_tt, string b_formName, string b_table_name)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CBNN_DROP_MA_TT(b_mann, b_tt);
            se.P_TG_LUU(b_formName, b_table_name, b_dt);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CBNN_CT(b_so_id);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_cbnn", "DT_NNN", "MA_NNN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CBNN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_CBNN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri), b_ma_nnn = mang.Fs_TEN_GTRI("ma_nnn", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_CBNN_MA(b_login, b_ma_nnn, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CBNN_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_HDNS_MA_CBNN_XOA(b_so_id); return Fs_NS_HDNS_MA_CBNN_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ BẬC NGHỀ NGHIỆP

    #region DANH MỤC VỊ TRÍ CHỨC DANH
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "pheduyet", ""); bang.P_THEM_COL(ref b_dt, "CHON", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
                if (chuyen.OBJ_S(b_dr["pduyet"]) == "X") b_dr["pheduyet"] = "Đã phê duyệt";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_SINHMA(string b_login, string b_mannghe, string b_ma_cmon, string b_ma_nngiep, string b_capbac)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            //double b_so_id = chuyen.OBJ_N(b_ma_cmon);
            //string b_macmon, b_cbac;
            //b_macmon = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MACMON(b_so_id);
            //b_so_id = chuyen.OBJ_N(b_capbac);
            string b_tusinh = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MACBNN(0);
            string b_kq = "CD." + b_tusinh;
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_DROP(string b_login)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_CDANH_DROP();
            se.P_TG_LUU("hdns_mota_cv", "DT_CB", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hdns.Fdt_NS_HDNS_MA_VTCD_CT(b_so_id);
            foreach (DataRow b_dr in b_dt.Rows)
            {
                b_dr["cbnn"] = b_dr["so_id_cbnn"];
                b_dr["ma_cm"] = b_dr["so_id_cm"];
            }
            b_dt.AcceptChanges();
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_vtcdanh", "DT_NL", "MA_NNN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nnn)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            //if (b_nnn != "") a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NNN(b_tu_n, b_den_n,b_nnn);
            //else
            a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE(b_nnn, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "pheduyet", ""); bang.P_THEM_COL(ref b_dt, "CHON", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
                if (chuyen.OBJ_S(b_dr["pduyet"]) == "X") b_dr["pheduyet"] = "Đã phê duyệt";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANH_TK_LKE(string b_login, string b_ma_nnn, string b_tt, string b_tentk, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANH_TK_LKE(b_ma_nnn, b_tt, b_tentk);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            bang.P_THEM_COL(ref b_dt, "TEN_TT", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["TEN_TT"] = "Áp dụng";
            }
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANH_TK_TRA(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null) return form.Fs_LOC_LOI("loi:Chưa chọn chức danh:loi");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            se.P_TG_LUU("DT_CD", "DT_CD", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANHDVI_TK_LKE(string b_login, string b_phong, string b_ngay_hl, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANHDVI_TK_LKE(b_phong, b_ngay_hl);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANHDVI_TK_TRA(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null) return form.Fs_LOC_LOI("loi:Chưa chọn chức danh:loi");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            se.P_TG_LUU("DT_CD", "DT_CD", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_LAY(string b_login, string[] a_cot, string b_phong, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA("DT_CD", "DT_CD");
            string[] a_cot_tl;
            object[] a_gtri_tl;
            if (a_dt_luoi[0] != "")
            {
                a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
                DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
                bang.P_BO_HANG(ref b_dt_tl, "ma_cd", "");
                foreach (DataRow irow in b_dt_tl.Rows)
                {
                    DataRow[] rows = b_dt.Select("ma_cd ='" + irow[0].ToString() + "'");
                    if (rows.Length <= 0)
                        b_dt.ImportRow(irow);
                }
            }
            bang.P_XEP(ref b_dt, "ma_cd");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_GAN_CDANHDVI_LAY(string b_login, string[] a_cot, string b_phong, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA("DT_CD", "DT_CD");
            string[] a_cot_tl;
            object[] a_gtri_tl;
            if (a_dt_luoi[0] != "")
            {
                a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
                DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
                bang.P_BO_HANG(ref b_dt_tl, "ma_cd", "");
                foreach (DataRow irow in b_dt_tl.Rows)
                {
                    DataRow[] rows = b_dt.Select("ma_cd ='" + irow[0].ToString() + "'");
                    if (rows.Length <= 0)
                        b_dt.ImportRow(irow);
                }
            }
            bang.P_XEP(ref b_dt, "ma_cd");
            bang.P_THEM_COL(ref b_dt,"capbac","");
            bang.P_THEM_COL(ref b_dt, "thamnien", "");
            bang.P_THEM_COL(ref b_dt, "ghichu", "");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_VTCD_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_VTCD_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_XOA(string b_login, double b_so_id, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_MA_VTCD_XOA(b_so_id); return Fs_NS_HDNS_MA_VTCD_LKE(b_login, a_tso, a_cot, ""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_DUYET(string b_login, object[] a_dt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_DON(ref b_dt_ct);
            ns_hdns.P_NS_HDNS_MA_VTCD_DUYET(b_dt_ct);
            return "X";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC VỊ TRÍ CHỨC DANH

    #region NHNAM_BAI2
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI2_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI2_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";

                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI2_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI2_CT(b_so_id);
            b_dt.AcceptChanges();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI2_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nnn, string ma_cd, string ten_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            //if (b_nnn != "") a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NNN(b_tu_n, b_den_n,b_nnn);
            //else
            a_object = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI2_LKE(b_nnn, ma_cd, ten_cd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";

                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI2_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_NHNAM_BAI2_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_NHNAM_BAI2_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI2_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_NHNAM_BAI2_XOA(b_ma); return Fs_NS_HDNS_NHNAM_BAI2_LKE(b_login, a_tso, a_cot, "", "", ""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion NHNAM_BAI2

    #region NHNAM_BAI3
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI3_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI3_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI3_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            //DataTable b_dt;
            //b_dt = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI3_CT(b_ma);
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI3_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];

            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            se.P_TG_LUU("ns_hdns_nhnam_bai3", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_nhnam_bai3", "DT_TT", "MA_TT");
            b_dt.AcceptChanges();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI3_LKE(string b_login, string b_ngay_tu, string b_ngay_den, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI3_LKE(b_ngay_tu, b_ngay_den, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI3_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tl");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            ns_hdns.P_NS_HDNS_NHNAM_BAI3_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_NHNAM_BAI3_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHNAM_BAI3_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_NHNAM_BAI3_XOA(b_ma); return Fs_NS_HDNS_NHNAM_BAI3_LKE(b_login, "", "", a_cot, a_tso); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion NHNAM_BAI3

    #region DANH MỤC VỊ TRÍ CHỨC DANH LVHOAN
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI2_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nnn, string ma_cd, string ten_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            //if (b_nnn != "") a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NNN(b_tu_n, b_den_n,b_nnn);
            //else
            a_object = ns_hdns.Fdt_LVHOAN_BAI2_LKE(b_nnn, ma_cd, ten_cd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";

                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_LVHOAN_BAI2_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_LVHOAN_BAI2_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_LVHOAN_BAI2_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_LVHOAN_BAI2_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_LVHOAN_BAI2_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";

                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI2_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_LVHOAN_BAI2_XOA(b_ma); return Fs_LVHOAN_BAI2_LKE(b_login, a_tso, a_cot, "", "", ""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region phong ban lvhoan
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI3_LKE(string b_login, string b_ngay_tu, string b_ngay_den, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_LVHOAN_BAI3_LKE(b_ngay_tu, b_ngay_den, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI3_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_LVHOAN_BAI3_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];

            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            se.P_TG_LUU("lvhoan_bai3", "DT_NL", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "lvhoan_bai3", "DT_NL", "MA_TT");
            b_dt.AcceptChanges();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_LVHOAN_BAI3_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tl");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            ns_hdns.P_LVHOAN_BAI3_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_LVHOAN_BAI3_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI3_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_LVHOAN_BAI3_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_LVHOAN_BAI3_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { 
                    ns_hdns.P_LVHOAN_BAI3_XOA(b_ma);
                    return Fs_LVHOAN_BAI3_LKE(b_login, "", "", a_cot, a_tso);
                }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region[THIẾT LẬP ĐỐI TƯỢNG CHẤM CÔNG]
    [WebMethod(true)]
    public string Fs_HDNS_DOITUONG_CC_LKE(string b_login, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_HD_MA_DOITUONG_CC_LKE(a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_SO_CNG(ref b_dt, "ngay_hl_td");
            bang.P_SO_CNG(ref b_dt, "ngay_hl_dmvs");
            bang.P_SO_CNG(ref b_dt, "ngay_hl_onsite");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_DOITUONG_CC_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_HD_MA_DOITUONG_CC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_DOITUONG_CC_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {

            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            //bang.P_THEM_COL(ref b_dt_ct, new string[] { "ma" }, new string[] { Guid.NewGuid().ToString() });
            if (b_dt_ct.Rows[0]["ma"].ToString().Trim() == "0" || b_dt_ct.Rows[0]["ma"].ToString().Trim() == "")
            {
                bang.P_DAT_GTRI(ref b_dt_ct, "ma", DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
            ns_hdns.P_HD_MA_DOITUONG_CC_NH(b_dt_ct);
            string b_ma = b_dt_ct.Rows[0]["ma"].ToString();
            return Fs_HDNS_DOITUONG_CC_MA(b_login, b_ma, b_trangKT, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region DANH MỤC VỊ TRÍ CHỨC DANH DONH
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_MA_NHDO(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MA_NHDO(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_SINHMA_NHDO(string b_login, string b_mannghe, string b_ma_cmon, string b_ma_nngiep, string b_capbac)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_tusinh = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MACBNN(0);
            string b_kq = "CD." + b_tusinh;
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_DROP_NHDO(string b_login)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_CDANH_DROP();
            se.P_TG_LUU("hdns_mota_cv", "DT_CB", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_CT_NHDO(string b_login,string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hdns.Fdt_NS_HDNS_MA_VTCD_CT_NHDO(b_ma);
            b_dt.AcceptChanges();
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_vtcdanh", "DT_NL", "MA_NNN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_LKE_NHDO(string b_login, double[] a_tso, string[] a_cot, string b_nnn, string ma_cd, string ten_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            //if (b_nnn != "") a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NNN(b_tu_n, b_den_n,b_nnn);
            //else
            a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NHDO(b_nnn, ma_cd, ten_cd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            bang.P_THEM_COL(ref b_dt, "ten_ncd", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
                if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "BDH") b_dr["ten_ncd"] = "Ban Điều Hành";
                else if (chuyen.OBJ_S(b_dr["ma_nnn"]) == "QL") b_dr["ten_ncd"] = "Quản Lý";
                else b_dr["ten_ncd"] = "Nhân Viên";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANH_TK_LKE_NHDO(string b_login, string b_ma_nnn, string b_tt, string b_tentk, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANH_TK_LKE(b_ma_nnn, b_tt, b_tentk);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            bang.P_THEM_COL(ref b_dt, "TEN_TT", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["TEN_TT"] = "Áp dụng";
            }
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANH_TK_TRA_NHDO(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null) return form.Fs_LOC_LOI("loi:Chưa chọn chức danh:loi");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            se.P_TG_LUU("DT_CD", "DT_CD", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANHDVI_TK_LKE_NHDO(string b_login, string b_phong, string b_ngay_hl, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANHDVI_TK_LKE(b_phong, b_ngay_hl);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "CHON", "");
            b_dt.AcceptChanges();

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_CDANHDVI_TK_TRA_NHDO(string b_login, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            if (a_gtri == null) return form.Fs_LOC_LOI("loi:Chưa chọn chức danh:loi");
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            se.P_TG_LUU("DT_CD", "DT_CD", b_dt_ct);
            return chuyen.OBJ_S(b_dt_ct.Rows.Count);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_LAY_NHDO(string b_login, string[] a_cot, string b_phong, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA("DT_CD", "DT_CD");
            string[] a_cot_tl;
            object[] a_gtri_tl;
            if (a_dt_luoi[0] != "")
            {
                a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
                DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
                bang.P_BO_HANG(ref b_dt_tl, "ma_cd", "");
                foreach (DataRow irow in b_dt_tl.Rows)
                {
                    DataRow[] rows = b_dt.Select("ma_cd ='" + irow[0].ToString() + "'");
                    if (rows.Length <= 0)
                        b_dt.ImportRow(irow);
                }
            }
            bang.P_XEP(ref b_dt, "ma_cd");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_GAN_CDANHDVI_LAY_NHDO(string b_login, string[] a_cot, string b_phong, object[] a_dt_luoi)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA("DT_CD", "DT_CD");
            string[] a_cot_tl;
            object[] a_gtri_tl;
            if (a_dt_luoi[0] != "")
            {
                a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
                DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
                bang.P_BO_HANG(ref b_dt_tl, "ma_cd", "");
                foreach (DataRow irow in b_dt_tl.Rows)
                {
                    DataRow[] rows = b_dt.Select("ma_cd ='" + irow[0].ToString() + "'");
                    if (rows.Length <= 0)
                        b_dt.ImportRow(irow);
                }
            }
            bang.P_XEP(ref b_dt, "ma_cd");
            bang.P_THEM_COL(ref b_dt, "capbac", "");
            bang.P_THEM_COL(ref b_dt, "thamnien", "");
            bang.P_THEM_COL(ref b_dt, "ghichu", "");
            return chuyen.OBJ_S(b_dt.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_NH_NHDO(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_VTCD_NH_NHDO(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_VTCD_MA_NHDO(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_XOA_NHDO(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_MA_VTCD_XOA_NHDO(b_ma); return Fs_NS_HDNS_MA_VTCD_LKE_NHDO(b_login, a_tso, a_cot, "","",""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCD_DUYET_NHDO(string b_login, object[] a_dt)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_DON(ref b_dt_ct);
            ns_hdns.P_NS_HDNS_MA_VTCD_DUYET(b_dt_ct);
            return "X";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH MỤC VỊ TRÍ CHỨC DANH DONH

    #region NHDO BAI 3
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHDO_BAI3_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MA_NHDO_BAI3(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHDO_BAI3_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_MA_VTCD_CT_NHDO_BAI3(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            se.P_TG_LUU("ns_hdns_bai3_nhdo", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_bai3_nhdo", "DT_TT", "ma_tt");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_NHDO_BAI3_LKE(string b_login, double[] a_tso, string[] a_cot, string b_ngay_tu, string b_ngay_den)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NHDO_BAI3(b_ngay_tu, b_ngay_den, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_HDNS_NHDO_BT3_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tl");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            ns_hdns.P_NS_HDNS_NHDO_BAI3_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_NHDO_BAI3_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NHDO_BT3_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_NHDO_BT3_XOA(b_ma); return Fs_NS_HDNS_NHDO_BAI3_LKE(b_login, a_tso, a_cot, "", ""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    #endregion NHDO BAI 3



    #region MÃ NGẠCH NGHỀ NGHIỆP
    [WebMethod(true)]
    public string Fs_HD_MA_NNNGHE_LKE(string b_day, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HD_MA_NNNGHE_LKE(b_day, b_tu_n, b_den_n);
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
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_NNNGHE_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HD_MA_NNNGHE_MA(b_ma, b_trangkt);
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
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_NNNGHE_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_HD_MA_NNNGHE_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_HD_MA_NNNGHE_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_NNNGHE_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_hdns.P_HD_MA_NNNGHE_XOA(b_ma); string b_day = ""; return Fs_HD_MA_NNNGHE_LKE(b_day, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NGẠCH NGHỀ NGHIỆP

    #region CẤP BẬC NGHỀ NGHIỆP

    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_LKE(string b_mannghe, string b_day, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HD_MA_BNNGHE_LKE(b_mannghe, b_day, b_tu_n, b_den_n); ;
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
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_MA_NNGIEP_LKE(string b_ma_nnghe, string b_ma_nngiep, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HD_MA_BNNGHE_MA_NNGIEP_LKE(b_ma_nnghe, b_ma_nngiep, b_tu_n, b_den_n); ;
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
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_MA(string b_mannghe, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HD_MA_BNNGHE_MA(b_mannghe, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "tthai", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["tthai"] = "Ngừng áp dụng";
                else b_dr["tthai"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            //int b_hang = bang.Fi_TIM_ROW(b_dt,new string[] { "ma_nnnghe","ma_nngiep" }, new object[] { b_mannghe });
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma_nnnghe" }, new object[] { b_mannghe });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_MA_CAP_BAC(string b_mannghe, string b_ma_nngiep, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HD_MA_BNNGHE_MA_CAP_BAC(b_mannghe, b_ma_nngiep, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma_nnnghe", "ma_nngiep", "cap_bac" }, new object[] { b_mannghe, b_ma_nngiep });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_HD_MA_BNNGHE_NH(b_dt_ct);
            //string b_ma = mang.Fs_TEN_GTRI("ma_nngiep", a_cot, a_gtri);
            string b_mannghe = mang.Fs_TEN_GTRI("ma_nnnghe", a_cot, a_gtri);
            //return Fs_HD_MA_BNNGHE_MA(b_mannghe, b_ma, b_trangKT, a_cot_lke);
            return Fs_HD_MA_BNNGHE_MA(b_mannghe, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_XOA(string b_mannghe, string b_manngiep, string b_cap_bac, double[] a_tso, string[] a_cot)
    {
        try { ns_hdns.P_HD_MA_BNNGHE_XOA(b_mannghe, b_manngiep, b_cap_bac); return Fs_HD_MA_BNNGHE_LKE(b_mannghe, "", a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_BNNGHE_LKE_ALL(string b_login, string b_nnnghe, string b_formName, string b_table_name)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_HD_MA_BNNGHE_LKE_ALL(b_nnnghe);
            bang.P_COPY_COL(ref b_dt, "MA", "MA_NNGIEP");
            bang.P_COPY_COL(ref b_dt, "TEN", "CAP_BAC");
            se.P_TG_LUU(b_formName, b_table_name, b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion CẤP BẬC NGHỀ NGHIỆP

    #region VỊ TRÍ MÃ CHỨC DANH

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_DUYET(double b_so_id)
    {
        try
        {
            ns_hdns.P_NS_MA_CDANH_DUYET(b_so_id);
            return "X";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CMON_XEM(string b_mann)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_MA_CMON_XEM(b_mann);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_CM", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CAPBAC_XEM(string b_manl)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_MA_CAPBAC_XEM(b_manl);
            se.P_TG_LUU("ns_ma_cdanh", "DT_CB", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string FS_NS_MA_CDANH_LKE_ALL(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fs_NS_MA_CDANH_LKE();
            bang.P_THEM_COL(ref b_dt, "chon", "");
            bang.P_THEM_COL(ref b_dt, "so_id", "0");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_LKE(string b_ma_nnghe, string b_ma_cmon, string b_ma_nnnghe, string b_cap_bac, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fs_NS_MA_CDANH_LKE(b_ma_nnghe, b_ma_cmon, b_ma_nnnghe, b_cap_bac, b_tu_n, b_den_n); ;
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
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_MA(string b_ma_nnnghe, string b_ma_cmon, string b_ma_nngiep, string b_ma_capbac, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_NS_MA_CDANH_MA(b_ma_nnnghe, b_ma_cmon, b_ma_nngiep, b_ma_capbac, b_ma, b_trangkt);
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
            //return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            double b_so_id_out = chuyen.OBJ_N(ns_hdns.P_NS_MA_CDANH_NH(b_dt_ct)[0]);
            string b_ma_nnnghe = mang.Fs_TEN_GTRI("ma_nnghe", a_cot, a_gtri), b_ma_cmon = mang.Fs_TEN_GTRI("ma_cmon", a_cot, a_gtri), b_ma_nngiep = mang.Fs_TEN_GTRI("ma_nnnghe", a_cot, a_gtri);
            string b_ma_capbac = mang.Fs_TEN_GTRI("ma_capbac", a_cot, a_gtri), b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CDANH_MA(b_ma_nnnghe, b_ma_cmon, b_ma_nngiep, b_ma_capbac, "", b_trangKT, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_CT(double b_so_id)
    {
        try
        {
            DataSet b_ds = ns_hdns.Fds_NS_MA_CDANH_CT(b_so_id);
            DataTable b_dt_ct = b_ds.Tables[0], b_dt_cm = b_ds.Tables[1], b_dt_cb = b_ds.Tables[2];
            se.P_TG_LUU("ns_ma_cdanh", "DT_CM", b_dt_cm);
            se.P_TG_LUU("ns_ma_cdanh", "DT_CB", b_dt_cb);
            bang.P_TIM_THEM(ref b_dt_ct, "ns_ma_cdanh", "DT_NN", "MA_NNGHE");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_ma_cdanh", "DT_NL", "MA_NNNGHE");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_ma_cdanh", "DT_CM", "MA_CMON");
            bang.P_TIM_THEM(ref b_dt_ct, "ns_ma_cdanh", "DT_CB", "MA_CAPBAC");
            return (bang.Fb_TRANG(b_dt_ct)) ? "" : bang.Fs_HANG_GOP(b_dt_ct, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_XOA(double b_so_id, string b_ma_nnnghe, string b_ma_cmon, string b_ma_nngiep, string b_ma_capbac, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_hdns.P_NS_MA_CDANH_XOA(b_so_id);
            return Fs_NS_MA_CDANH_LKE("", "", "", "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion VỊ TRÍ MÃ CHỨC DANH

    #region VỊ TRÍ MÃ CHỨC DANH ĐƠN VỊ
    [WebMethod(true)]
    public string Fs_HD_CDANH_DVI_LKE(string b_madonvi)
    {
        try
        {

            object[] a_object = ns_hdns.Fdt_HD_CDANH_DVI_LKE(b_madonvi);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_CDANH_DVI_XUATEXCEL(string b_madonvi)
    {
        try
        {

            object[] a_object = ns_hdns.Fdt_HD_CDANH_DVI_LKE(b_madonvi);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_cdanh_dvi.xlsx", b_dt, null, "Gan_chuc_danh_don_vi");
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_CDANH_DVI_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON_DK(ref b_dt_ct, "donvi");
            bang.P_THAY_GTRI(ref b_dt_ct, "tt", "Ngừng áp dụng", "N");
            bang.P_THAY_GTRI(ref b_dt_ct, "tt", "Áp dụng", "A");
            if (b_dt_ct.Rows.Count == 0)
            {
                return form.Fs_LOC_LOI("loi:Không được để trống dữ liệu:loi");
            }
            ns_hdns.P_Fs_HD_CDANH_DVI_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_CDANH_DVI_XOA(string b_donvi, string b_ma)
    {
        try
        {
            ns_hdns.P_HD_CDANH_DVI_XOA(b_ma);
            return Fs_HD_CDANH_DVI_LKE(b_donvi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion VỊ TRÍ MÃ CHỨC DANH  ĐƠN VỊ

    #region HỆ THỐNG THANG LƯƠNG
    [WebMethod(true)]
    public string Fs_HD_MA_HTTLUONG_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HD_MA_HTTLUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ng_hluc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_HTTLUONG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_HD_MA_HTTLUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ng_hluc_t", "ng_hluc");
            bang.P_SO_CNG(ref b_dt, "ng_hluc_t,ng_hluc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_HTTLUONG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ng_hluc");
            ns_hdns.P_HD_MA_HTTLUONG_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HD_MA_HTTLUONG, TEN_BANG.HD_MA_HTTLUONG);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_HD_MA_HTTLUONG_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_HTTLUONG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_HD_MA_HTTLUONG_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HD_MA_HTTLUONG, TEN_BANG.HD_MA_HTTLUONG);
            return Fs_HD_MA_HTTLUONG_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion HỆ THỐNG THANG LƯƠNG

    #region[DANH MỤC LEVEL CHỨC DANH]
    [WebMethod(true)]
    public string Fs_HDNS_MA_LVCDANH_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HDNS_MA_LVCDANH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_MA_LVCDANH_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HDNS_MA_LVCDANH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HDNS_MA_LVCDANH_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_HDNS_MA_LVCDANH_NH(b_dt_ct);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.HDNS_MA_LVCDANH, TEN_BANG.HDNS_MA_LVCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_HDNS_MA_LVCDANH_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HDNS_MA_LVCDANH_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_hdns.P_HDNS_MA_LVCDANH_XOA(b_ma);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.HDNS_MA_LVCDANH, TEN_BANG.HDNS_MA_LVCDANH);
            return Fs_HDNS_MA_LVCDANH_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region PHÂN LOẠI NHÂN VIÊN
    [WebMethod(true)]
    public string FS_HD_MA_LOAI_NV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fs_HD_MA_LOAI_NV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string FS_HD_MA_LOAI_NV_MA(string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HD_MA_LOAI_NV_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            //return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string FS_HD_MA_LOAI_NV_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke, double[] a_tso)
    {
        try
        {
            string[] a_cot_cd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_cd = (object[])a_dt_ct[1];
            DataTable b_dt_cdanh = bang.Fdt_TAO_THEM(a_cot_cd, a_gtri_cd);
            bang.P_CSO_SO(ref b_dt_cdanh, "so_id_cd");
            bang.P_BO_HANG(ref b_dt_cdanh, "chon", "");
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            if (b_dt_cdanh == null || b_dt_cdanh.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            for (int i = 0; i < b_dt_cdanh.Rows.Count; i++)
            {
                if (b_dt_cdanh.Rows[i]["chon"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }

            ns_hdns.P_HD_MA_LOAI_NV_NH(ref b_so_id, b_dt_cdanh, b_dt);
            //return FS_HD_MA_LOAI_NV_LKE(a_tso, a_cot_lke);
            return FS_HD_MA_LOAI_NV_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string FS_HD_MA_LOAI_NV_CT(double b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_HD_MA_LOAI_NV_CT(b_so_id);
            DataTable b_dt_cdanh = ns_hdns.Fs_NS_MA_CDANH_LKE();
            bang.P_THEM_COL(ref b_dt_cdanh, "chon", "");
            var b_so_idlk = bang.Fobj_COL_MANG(b_dt, "so_id");
            bang.P_THEM_COL(ref b_dt_cdanh, "so_id", b_so_idlk[0]);
            var b_cdanh = bang.Fobj_COL_MANG(b_dt, "cdanh");

            foreach (var item in b_cdanh)
            {
                bang.P_THAY_GTRI(ref b_dt_cdanh, "CHON", "x", "MA", item);
            }
            //foreach (var item in b_so_id)
            //{
            //    bang.P_THAY_GTRI(ref b_dt_cdanh, "SO_ID", item, "SO_ID", 0);
            //}

            return bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_cdanh, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string FS_HD_MA_LOAI_NV_XOA(string b_soid, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_hdns.P_HD_MA_LOAI_NV_XOA(b_soid);
            return FS_HD_MA_LOAI_NV_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region[THIẾT LẬP Quỹ Lương]
    [WebMethod(true)]
    public string Fs_HD_MA_QUYLUONG_LKE(string b_login, string[] a_cot, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_HD_MA_QUYLUONG_LKE(a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            //bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_QUYLUONG_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_HD_MA_QUYLUONG_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_QUYLUONG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            //bang.P_THEM_COL(ref b_dt_ct, new string[] { "ma" }, new string[] { Guid.NewGuid().ToString() });
            if (b_dt_ct.Rows[0]["so_id"].ToString().Trim() == "0" || b_dt_ct.Rows[0]["so_id"].ToString().Trim() == "")
            {
                bang.P_DAT_GTRI(ref b_dt_ct, "so_id", DateTime.Now.ToString("yyyyMMddhhmmss"));
            }
            ns_hdns.P_HD_MA_QUYLUONG_NH(b_dt_ct);
            string b_ma = b_dt_ct.Rows[0]["so_id"].ToString();
            return Fs_HD_MA_QUYLUONG_MA(b_login, b_ma, b_trangKT, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_HD_MA_QUYLUONG_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_hdns.P_HD_MA_QUYLUONG_XOA(b_ma); return Fs_HD_MA_QUYLUONG_LKE(b_login, a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region[Tuyển dụng]
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_LKE_DR(string b_ncdanh)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_HD_MA_TUYENDUNG_LKE_DR(b_ncdanh);
            bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
            return bang.Fs_BANG_CH(b_dt, "ma,ten");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_HOI(string b_cdanh, string b_ncdanh)
    {
        try
        {
            return ns_hdns.Fdt_HD_MA_TUYENDUNG_HOI(b_cdanh, b_ncdanh);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_HD_MA_TUYENDUNG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_MA(double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_HD_MA_TUYENDUNG_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_CT(string b_login, string b_ncdanh, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_HD_MA_TUYENDUNG_CT(b_ncdanh, b_ma);
            bang.P_DOI_TENCOL(ref b_dt, new string[] { "MA_CDANH" }, new string[] { "MA" });
            bang.P_THEM_COL(ref b_dt, "MA_CDANH", "");
            bang.P_GAN_COT(ref b_dt, "MA_CDANH", "MA");
            bang.P_TIM_THEM(ref b_dt, "hd_ma_tuyendung", "DT_CDANH", "MA_CDANH");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_I_DIEM"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_I_DIEM"] = DBNull.Value;
                }

                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_I_DMAX"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_I_DMAX"] = DBNull.Value;
                }


                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_II_DIEM"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_II_DIEM"] = DBNull.Value;
                }

                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_II_DMAX"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_II_DMAX"] = DBNull.Value;
                }

                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_III_DIEM"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_III_DIEM"] = DBNull.Value;
                }

                if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_III_DMAX"]) == 0)
                {
                    b_dt_ct.Rows[i]["MON_III_DMAX"] = DBNull.Value;
                }

                if (chuyen.OBJ_S(b_dt_ct.Rows[i]["MON_I_DIEM"]) != "")
                {
                    if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_I_DIEM"]) > chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_I_DMAX"]))
                    {
                        return form.Fs_LOC_LOI("loi:Đạt điểm vòng 1 không được lớn hơn thang điểm vòng 1:loi");
                    }
                }

                if (chuyen.OBJ_S(b_dt_ct.Rows[i]["MON_II_DIEM"]) != "")
                {
                    if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_II_DIEM"]) > chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_II_DMAX"]))
                    {
                        return form.Fs_LOC_LOI("loi:Đạt điểm vòng 2 không được lớn hơn thang điểm vòng 2:loi");
                    }
                }

                if (chuyen.OBJ_S(b_dt_ct.Rows[i]["MON_III_DIEM"]) != "")
                {
                    if (chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_III_DIEM"]) > chuyen.OBJ_N(b_dt_ct.Rows[i]["MON_III_DMAX"]))
                    {
                        return form.Fs_LOC_LOI("loi:Đạt điểm vòng 3 không được lớn hơn thang điểm vòng 3:loi");
                    }
                }
            }

            double b_so_id = chuyen.OBJ_N(ns_hdns.Fobj_HD_MA_TUYENDUNG_NH(b_dt_ct));
            return Fs_HD_MA_TUYENDUNG_MA(b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_HD_MA_TUYENDUNG_XOA(double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_hdns.P_HD_MA_TUYENDUNG_XOA(b_so_id); return Fs_HD_MA_TUYENDUNG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region[GÁN NĂNG LỰC CHO VỊ TRÍ CHỨC DANH]
    [WebMethod(true)]
    public string Fs_LKE_NL(string b_nhom_nl, string b_ma_nl)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_LKE_NL(b_nhom_nl, b_ma_nl);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_LKE_NL_CDANH(string b_nhom, string b_nhom_nl, string b_ma_nl, object[] a_dt_ct)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_LKE_NL_CDANH(b_nhom, b_nhom_nl, b_ma_nl);
            //if (b_dt.Rows.Count > 0)
            //{
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON(ref b_dt_ct, "nhom_nl");
            //string b_nhomnl, b_nang_luc, b_muc_nl;
            bang.P_BO_HANG(ref b_dt_ct, new string[] { "ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc" }, b_dt,
                new string[] { "ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc" });


            string s_b_dt_ct = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, new string[] { "ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc" });
            string s_b_dt = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, new string[] { "ten_nhom_nl", "ten_nang_luc", "muc_nl", "mota_theomuc", "nhom_nl", "nang_luc" });
            return s_b_dt_ct + "#" + s_b_dt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_LKE_NL_NH(string b_nhom, string b_nhom_nl, string b_nang_luc, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_DON(ref b_dt_ct, "nhom_nl");
            //bang.P_DON_DK(ref b_dt_ct, "phong");

            //bang.P_CSO_SO(ref b_dt_ct, "ns_hientai,db_t1,db_t2,db_t3,db_t4,db_t5,db_t6,db_t7,db_t8,db_t9,db_t10,db_t11,db_t12,db_tb,db_cn,db_caon,landoi");


            //if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            //{
            //    return Thongbao_dch.nhapdulieu_luoi;
            //}
            if (b_dt_ct.Rows.Count == 0)
            {
                //return "loi:Không có dữ liệu:loi";
                ns_hdns.P_NL_CD_XOA(b_nhom, b_nhom_nl, b_nang_luc);
            }
            else ns_hdns.P_NL_NH(b_nhom, b_nhom_nl, b_nang_luc, b_dt_ct);
            return "Nhập thành công";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region DANH MỤC CÁC KHOẢN HỖ TRỢ KHÁC (PHỤ CẤP)
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_HTKHAC_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_HTKHAC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_COPY_COL(ref b_dt, "TEN_HT", "hinhthuc");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HT", "TT", "Theo tháng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HT", "TCTT", "Theo công thực tế");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_HTKHAC_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_HTKHAC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "trangthai");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_COPY_COL(ref b_dt, "TEN_HT", "hinhthuc");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HT", "TT", "Theo tháng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_HT", "TCTT", "Theo công thực tế");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_HTKHAC_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_HTKHAC_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_HTKHAC, TEN_BANG.NS_HDNS_MA_HTKHAC);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_HTKHAC_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_HTKHAC_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_HTKHAC_XOA(b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_HTKHAC, TEN_BANG.NS_HDNS_MA_HTKHAC);
            return Fs_NS_HDNS_MA_HTKHAC_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC CÁC KHOẢN HỖ TRỢ KHÁC (PHỤ CẤP)

    #region DANH MỤC THAM SỐ HỆ THỐNG LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TS_HTL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_TS_HTL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "SOTIEN"); bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TS_HTL_MA(string b_ma, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_TS_HTL_MA(b_ma, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CSO(ref b_dt, "SOTIEN"); bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ma", "ngay_hl" }, new string[] { b_ma, b_ngay_hl });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TS_HTL_CT(string b_ma, string b_ngay_hl)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_TS_HTL_CT(b_ma, b_ngay_hl);
            bang.P_SO_CSO(ref b_dt, "SOTIEN"); bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TS_HTL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_TS_HTL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_TS_HTL_MA(b_ma, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TS_HTL_XOA(string b_ma, string b_ngay_hl, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_hdns.P_NS_HDNS_MA_TS_HTL_XOA(b_ma, b_ngay_hl); return Fs_NS_HDNS_MA_TS_HTL_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC THAM SỐ HỆ THỐNG LƯƠNG

    #region DANH MỤC NGÀY NGHỈ LỄ
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NGAYNGHI_LKE(string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NGAYNGHI_LKE(b_trangthai, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "A", "Áp dụng");
            bang.P_SO_CNG(ref b_dt, "TUNGAY");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NGAYNGHI_MA(string b_ma, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NGAYNGHI_MA(b_ma, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "A", "Áp dụng");
            bang.P_SO_CNG(ref b_dt, "TUNGAY");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NGAYNGHI_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NGAYNGHI_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "TUNGAY,DENNGAY");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NGAYNGHI_NH(string b_login, double b_trangKT, object[] a_dt_ct, string b_so_id, string b_trangthai, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "so_ngay");
            bang.P_CNG_SO(ref b_dt_ct, "tungay,denngay");
            ns_hdns.P_NS_HDNS_MA_NGAYNGHI_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_NGAYNGHI, TEN_BANG.NS_HDNS_MA_NGAYNGHI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nam = mang.Fs_TEN_GTRI("nam", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NGAYNGHI_MA(b_ma, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NGAYNGHI_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        string b_trangthai = "";
        try
        {
            ns_hdns.P_NS_HDNS_MA_NGAYNGHI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_NGAYNGHI, TEN_BANG.NS_HDNS_MA_NGAYNGHI);
            return Fs_NS_HDNS_MA_NGAYNGHI_LKE(b_trangthai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion DANH MỤC NGÀY NGHỈ LỄ

    #region [MỨC NĂNG LỰC ĐƠN VỊ]
    [WebMethod(true)]
    public string Fs_NS_HDNS_NLCDANH_DVI_LKE(string b_madonvi)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_NS_HDNS_NLCDANH_DVI_LKE(b_madonvi);
            DataTable b_dt = (DataTable)a_object[0];
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NLCDANH_DVI_XUATEXCEL(string b_madonvi)
    {
        try
        {

            object[] a_object = ns_hdns.Fdt_NS_HDNS_NLCDANH_DVI_LKE(b_madonvi);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/NS_HDNS_NLCDANH_DVI.xlsx", b_dt, null, "Gan_chuc_danh_don_vi");
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NLCDANH_DVI_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            bang.P_DON_DK(ref b_dt_ct, "ma_phong");
            if (b_dt_ct.Rows.Count == 0)
            {
                return form.Fs_LOC_LOI("loi:Không được để trống dữ liệu:loi");
            }
            ns_hdns.P_Fs_NS_HDNS_NLCDANH_DVI_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NLCDANH_DVI_XOA(string b_donvi, string b_ma)
    {
        try
        {
            ns_hdns.P_NS_HDNS_NLCDANH_DVI_XOA(b_ma);
            return Fs_NS_HDNS_NLCDANH_DVI_LKE(b_donvi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion

    #region DANH MỤC NĂNG LỰC

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_LKE(string b_login, string b_day, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Faobj_NS_HDNS_MA_NL_LKE(b_day, b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NL_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_ct;
            if (a_gtri_ct == null) b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS"); else { b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); }
            bang.P_BO_HANG(ref b_dt_ct, "ten_muc_nl", "");
            if (bang.Fb_TRANG(b_dt_ct)) return Thongbao_dch.nhapdulieu_luoi;
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["ten_muc_nl"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            ns_hdns.P_NS_HDNS_MA_NL_NH(ref b_so_id, b_dt, b_dt_ct);
            return Fs_NS_HDNS_MA_NL_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_MA_NL_CT(b_so_id);
            DataTable b_dt1 = b_ds.Tables[0];
            DataTable b_dt_ct1 = b_ds.Tables[1];
            string b_dt = bang.Fb_TRANG(b_dt1) ? "" : bang.Fs_HANG_GOP(b_dt1, 0);
            string b_dt_ct = bang.Fb_TRANG(b_dt_ct1) ? "" : bang.Fs_BANG_CH(b_dt_ct1, a_cot);
            return b_dt + "#" + b_dt_ct;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NL_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_NL_XOA(b_so_id);
            return Fs_NS_HDNS_MA_NL_LKE(b_login, "", a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region GAN CHUC DANH CHO DON VI
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_MA(string b_login, string b_phong, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_CDANHDVI_MA(b_phong, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "phong", "ngay_hl" }, new string[] { b_phong, chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl)) });
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_CT(string b_login, double b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_GAN_CDANHDVI_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_gan_cdanhdvi", "DT_PH", "PHONG");
            bang.P_THEM_COL(ref b_dt_ct, "ten_tt", "");
            foreach (DataRow b_dr in b_dt_ct.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_CDANHDVI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_cd = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]);
            object[] a_gtri_cd = (object[])a_dt_cd[1];
            if (a_gtri_cd == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot_cd, a_gtri_cd);
            if (b_dt_cd.Rows.Count == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            ns_hdns.P_NS_HDNS_GAN_CDANHDVI_NH(b_dt_ct, b_dt_cd);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_GAN_CDANHDVI, TEN_BANG.NS_HDNS_GAN_CDANHDVI);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_HDNS_GAN_CDANHDVI_MA(b_login, b_phong, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_CDANHDVI_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_GAN_CDANHDVI, TEN_BANG.NS_HDNS_GAN_CDANHDVI);
            ns_hdns.P_NS_HDNS_GAN_CDANHDVI_XOA(b_so_id); return Fs_NS_HDNS_GAN_CDANHDVI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion GAN CHUC DANH CHO DON VI

    #region[BIẾN ĐỘNG BẢO HIỂM]
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BD_BH_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_BD_BH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BD_BH_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_BD_BH_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_bd_bh", "DT_NHOM_BD", "MA_NHOM_BD");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BD_BH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_BD_BH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BD_BH_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_BD_BH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_BD_BH_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BD_BH_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_BD_BH_XOA(b_ma); return Fs_NS_HDNS_MA_BD_BH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region[DANH MỤC NHÓM BIẾN ĐỘNG BẢO HIỂM]
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_BH_BD_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NHOM_BH_BD_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_BH_BD_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NHOM_BH_BD_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_BH_BD_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NHOM_BH_BD_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_BH_BD_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_NHOM_BH_BD_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NHOM_BH_BD_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_BH_BD_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_NHOM_BH_BD_XOA(b_ma); return Fs_NS_HDNS_MA_NHOM_BH_BD_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region[CHẾ ĐỘ BẢO HIỂM]
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CDO_BH_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CDO_BH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CDO_BH_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CDO_BH_CT(b_ma);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_cdo_bh", "DT_NHOM_CD", "MA_NHOM_CD");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CDO_BH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_CDO_BH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CDO_BH_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_CDO_BH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_CDO_BH_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_CDO_BH_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_CDO_BH_XOA(b_ma); return Fs_NS_HDNS_MA_CDO_BH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region [NHÓM CHẾ ĐỘ BẢO HIỂM]
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_CDO_BH_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NHOM_CDO_BH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_CDO_BH_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NHOM_CDO_BH_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_CDO_BH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NHOM_CDO_BH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_CDO_BH_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_NHOM_CDO_BH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NHOM_CDO_BH_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NHOM_CDO_BH_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_NHOM_CDO_BH_XOA(b_ma); return Fs_NS_HDNS_MA_NHOM_CDO_BH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region [DANH MỤC TÊN LOẠI BẢO HIỂM TỰ NGUYỆN]

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BH_TN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_BH_TN_LKE(b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt_tk, "TEN_TT", "N", "Ngừng áp dụng");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BH_TN_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_BH_TN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "N", "Ngừng áp dụng");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BH_TN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_BH_TN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_BH_TN_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_BH_TN_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_HDNS_MA_BH_TN_XOA(b_ma); return Fs_NS_HDNS_MA_BH_TN_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region DANH MỤC CHI PHÍ GÓI BẢO HIỂM TỰ NGUYỆN
    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_BH_TN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_MA_CHIPHI_BH_TN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_BH_TN_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_MA_CHIPHI_BH_TN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "phibh_nam");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_BH_TN_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt_ct, "phibh_nam");
            ns_hdns.P_NS_MA_CHIPHI_BH_TN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_MA_CHIPHI_BH_TN_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_CHIPHI_BH_TN_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_MA_CHIPHI_BH_TN_XOA(b_ma); return Fs_NS_MA_CHIPHI_BH_TN_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region THIẾT LẬP ĐIỀU KIỆN HƯỞNG BẢO HIỂM TỰ NGUYỆN

    [WebMethod(true)]
    public string Fs_NS_HDNS_GOI_BH_TN_DR_MA(string b_login, string b_loai_bh)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt = ns_hdns.Fdt_NS_HDNS_GOI_BH_DR_MA(b_loai_bh);
            se.P_TG_LUU("ns_hdns_tl_dk_bh_tn", "DT_GBH", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_TL_DK_BH_TN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_TL_DK_BH_TN_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_TL_DK_BH_TN_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.PNS_HDNS_TL_DK_BH_TN_XOA(b_so_id); return Fs_NS_HDNS_TL_DK_BH_TN_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_TL_DK_BH_TN_CT(string b_login, string b_so_id, string[] a_cot_cdanh, string[] a_cot_level, string[] a_cot_lhd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_TL_DK_BH_TN_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            if (b_dt.Rows.Count > 0)
            {
                Fs_NS_HDNS_GOI_BH_TN_DR_MA(b_login, chuyen.OBJ_S(b_dt.Rows[0]["LOAI_BH"]));
            }
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_tl_dk_bh_tn", "DT_LBH", "LOAI_BH");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_tl_dk_bh_tn", "DT_GBH", "GOI_BH");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_tl_dk_bh_tn", "DT_NNN", "NNNGHIEP");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_tl_dk_bh_tn", "DT_CTY", "MA_DVI");
            //bang.P_COPY_COL(ref b_dt, "MA_NNNGHIEP", "NNNGHIEP");

            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
                   b_dt_cdanh_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_cdanh),
                   b_dt_level_s = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[2], a_cot_level),
                   b_dt_lhd_s = bang.Fb_TRANG(b_ds.Tables[3]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[3], a_cot_lhd);
            return b_dt_s + "#" + b_dt_cdanh_s + "#" + b_dt_level_s + "#" + b_dt_lhd_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_TL_DK_BH_TN_MA(string b_login, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_TL_DK_BH_TN_MA(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_TL_DK_BH_TN_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_cdanh, object[] a_dt_level, object[] a_dt_lhd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]), a_cot_cdanh = chuyen.Fas_OBJ_STR((object[])a_dt_cdanh[0]),
                     a_cot_level = chuyen.Fas_OBJ_STR((object[])a_dt_level[0]), a_cot_lhd = chuyen.Fas_OBJ_STR((object[])a_dt_lhd[0]);
            object[] a_gtri = (object[])a_dt[1], a_gtri_cdanh = (object[])a_dt_cdanh[1],
                     a_gtri_level = (object[])a_dt_level[1], a_gtri_lhd = (object[])a_dt_lhd[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_cdanh = bang.Fdt_TAO_THEM(a_cot_cdanh, a_gtri_cdanh),
                b_dt_level = bang.Fdt_TAO_THEM(a_cot_level, a_gtri_level), b_dt_lhd = bang.Fdt_TAO_THEM(a_cot_lhd, a_gtri_lhd);

            if (a_cot_cdanh == null) b_dt_cdanh = bang.Fdt_TAO_BANG(a_cot_cdanh, "SS");
            else { b_dt_cdanh = bang.Fdt_TAO_THEM(a_cot_cdanh, a_gtri_cdanh); }
            if (a_cot_level == null) b_dt_level = bang.Fdt_TAO_BANG(a_cot_level, "SS");
            else { b_dt_level = bang.Fdt_TAO_THEM(a_cot_level, a_gtri_level); }
            if (a_cot_lhd == null) b_dt_lhd = bang.Fdt_TAO_BANG(a_cot_lhd, "SS");
            else { b_dt_lhd = bang.Fdt_TAO_THEM(a_cot_lhd, a_gtri_lhd); }
            bang.P_BO_HANG(ref b_dt_cdanh, "ma_cd", "");
            bang.P_BO_HANG(ref b_dt_level, "ma_level_cdanh", "");
            bang.P_BO_HANG(ref b_dt_lhd, "ma_lhd", "");
            if (bang.Fb_TRANG(b_dt_cdanh)) { bang.P_THEM_TRANG(ref b_dt_cdanh, 1); }
            if (bang.Fb_TRANG(b_dt_level)) { bang.P_THEM_TRANG(ref b_dt_level, 1); }
            if (bang.Fb_TRANG(b_dt_lhd)) { bang.P_THEM_TRANG(ref b_dt_lhd, 1); }
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc");
            bang.P_CSO_SO(ref b_dt, "thamnien");
            ns_hdns.P_NS_HDNS_TL_DK_BH_TN_NH(ref b_so_id, b_dt, b_dt_cdanh, b_dt_level, b_dt_lhd);
            return Fs_NS_HDNS_TL_DK_BH_TN_MA(b_login, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    #endregion

    #region [NƠI KHÁM CHỮA BỆNH]
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NOI_KHAMBENH_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NOI_KHAMBENH_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NOI_KHAMBENH_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_tp = "";
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NOI_KHAMBENH_CT(b_ma);
            if (b_dt.Rows.Count == 0) { b_tp = "--"; } else { b_tp = chuyen.OBJ_S(b_dt.Rows[0]["TPHO"]); }
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_noi_khambenh", "DT_TPHO", "TPHO");
            DataTable b_dt_qh = ns_ma.Fdt_NS_MA_QH_DR(b_tp);
            se.P_TG_LUU("ns_hdns_ma_noi_khambenh", "DT_QHUYEN", b_dt_qh);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_noi_khambenh", "DT_QHUYEN", "QHUYEN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NOI_KHAMBENH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_NOI_KHAMBENH_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NOI_KHAMBENH_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_NOI_KHAMBENH_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_NOI_KHAMBENH_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_NOI_KHAMBENH_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_NOI_KHAMBENH_XOA(b_ma); return Fs_NS_HDNS_MA_NOI_KHAMBENH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region THUẾ THU NHẬP CÁ NHÂN
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TTNCN_MA(string b_login, string b_dtg_ctru, double b_ngay_d, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_TTNCN_MA(b_dtg_ctru, b_ngay_d, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "doituong_cutru", "ngay_d" }, new object[] { b_dtg_ctru, b_ngay_d });
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_ttncn", "DT_CUTRU", "DOITUONG_CUTRU");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TTNCN_CT(string b_login, string b_dtg_ctru, double b_ngay_d, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_TTNCN_CT(b_dtg_ctru, b_ngay_d);
            //bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_ttncn", "DT_CUTRU", "doituong_cutru");
            bang.P_SO_CSO(ref b_dt, new string[] { "tien_tu", "tien_den", "ty_le" });
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TTNCN_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_TTNCN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_d");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_ma_ttncn", "DT_CUTRU", "DOITUONG_CUTRU");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TTNCN_NH(string b_login, string b_dtg_ctru, double b_ngay_d, double b_trangKT, object[] a_dt, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, new string[] { "tien_tu", "tien_den", "ty_le" }, new object[] { "", "", "" });
            if (b_dt.Rows.Count == 0)
                return "loi:Bạn chưa nhập thông tin Thu nhập từ, Thu nhập đến và Thuế suất:loi";
            bang.P_CSO_SO(ref b_dt, new string[] { "tien_tu", "tien_den", "ty_le" });
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_N(b_dr["tien_tu"]) > chuyen.OBJ_N(b_dr["tien_den"]))
                {
                    return "loi:Thu nhập từ không được lớn hơn Thu nhập đến:loi";
                }
                if (chuyen.OBJ_N(b_dr["ty_le"]) > 100)
                {
                    return "loi:Thuế suất không được lớn hơn 100:loi";
                }
            }
            DataRow[] a_dr;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                a_dr = b_dt.Select("tien_tu <= " + b_dr["tien_den"] + " and tien_den >= " + b_dr["tien_tu"]);
                if (a_dr.Length > 1 || (a_dr.Length == 1 && !a_dr[0].Equals(b_dr)))
                {
                    foreach (DataRow b_dr_a in a_dr)
                    {
                        if (!b_dr_a.Equals(b_dr))
                            return "loi:Trùng khoảng thu nhập ở dòng " + (b_dt.Rows.IndexOf(b_dr) + 1) + " và dòng " + (b_dt.Rows.IndexOf(b_dr_a) + 1) + ":loi";
                    }
                }
            }
            ns_hdns.P_NS_HDNS_MA_TTNCN_NH(b_dtg_ctru, b_ngay_d, b_dt);
            return Fs_NS_HDNS_MA_TTNCN_MA(b_login, b_dtg_ctru, b_ngay_d, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_TTNCN_XOA(string b_login, string b_dtg_ctru, double b_ngay_d, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_MA_TTNCN_XOA(b_dtg_ctru, b_ngay_d);
            return Fs_NS_HDNS_MA_TTNCN_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion THUẾ THU NHẬP CÁ NHÂN

    #region [Gán vị trí MTCV sử dụng cho mỗi đơn vị]
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_MTCVDVI_MA(string b_login, string b_phong, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_MTCVDVI_MA(b_phong, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "phong", "ngay_hl" }, new string[] { b_phong, b_ngay_hl });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_MTCVDVI_CT(string b_login, double b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_GAN_MTCVDVI_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_gan_mtcv", "DT_PH", "PHONG");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_MTCVDVI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_MTCVDVI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_MTCVDVI_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_cd = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]);
            object[] a_gtri_cd = (object[])a_dt_cd[1];
            if (a_gtri_cd == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot_cd, a_gtri_cd);
            if (b_dt_cd.Rows.Count == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            ns_hdns.P_NS_HDNS_GAN_MTCVDVI_NH(b_dt_ct, b_dt_cd);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_HDNS_GAN_MTCVDVI_MA(b_login, b_phong, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_MTCVDVI_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_HDNS_GAN_MTCVDVI_XOA(b_so_id); return Fs_NS_HDNS_GAN_MTCVDVI_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion GAN CHUC DANH CHO DON VI

    #region ĐỐI TƯỢNG CHẤM CÔNG
    [WebMethod(true)]
    public string Fs_NS_CC_DTCC_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_mtd, object[] a_dt_dmvs, object[] a_dt_onsite, object[] a_dt_kg)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_mtd = chuyen.Fas_OBJ_STR((object[])a_dt_mtd[0]);
            object[] a_gtri_mtd = (object[])a_dt_mtd[1];
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["mtd"]) != "X" && chuyen.OBJ_S(b_dt_ct.Rows[0]["dmvs"]) != "X" &&
                chuyen.OBJ_S(b_dt_ct.Rows[0]["onsite"]) != "X" && chuyen.OBJ_S(b_dt_ct.Rows[0]["kg"]) != "X")
            {
                return form.Fs_LOC_LOI("loi:Chưa chọn hình thức:loi");
            }
            //MTD
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["mtd"]) == "X" && chuyen.CNG_SO(chuyen.OBJ_S(b_dt_ct.Rows[0]["ngay_hl_mtd"])) == 30000101)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập ngày hiệu lực:loi");
            }
            else if (chuyen.OBJ_S(b_dt_ct.Rows[0]["mtd"]) == "X" && a_gtri_mtd == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_mtd = bang.Fdt_TAO_THEM(a_cot_mtd, a_gtri_mtd);
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["mtd"]) == "X" && b_dt_mtd.Select("MA_CD <> ''").Length == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }

            //DMVS
            string[] a_cot_dmvs = chuyen.Fas_OBJ_STR((object[])a_dt_dmvs[0]);
            object[] a_gtri_dmvs = (object[])a_dt_dmvs[1];
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["dmvs"]) == "X" && chuyen.CNG_SO(chuyen.OBJ_S(b_dt_ct.Rows[0]["ngay_hl_dmvs"])) == 30000101)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập ngày hiệu lực:loi");
            }
            else if (chuyen.OBJ_S(b_dt_ct.Rows[0]["dmvs"]) == "X" && a_gtri_dmvs == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_dmvs = bang.Fdt_TAO_THEM(a_cot_dmvs, a_gtri_dmvs);
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["dmvs"]) == "X" && b_dt_dmvs.Select("MA_CD <> ''").Length == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            //ONSITE
            string[] a_cot_onsite = chuyen.Fas_OBJ_STR((object[])a_dt_onsite[0]);
            object[] a_gtri_onsite = (object[])a_dt_onsite[1];
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["onsite"]) == "X" && chuyen.CNG_SO(chuyen.OBJ_S(b_dt_ct.Rows[0]["ngay_hl_onsite"])) == 30000101)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập ngày hiệu lực:loi");
            }
            else if (chuyen.OBJ_S(b_dt_ct.Rows[0]["onsite"]) == "X" && a_gtri_onsite == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_onsite = bang.Fdt_TAO_THEM(a_cot_onsite, a_gtri_onsite);
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["onsite"]) == "X" && b_dt_onsite.Select("MA_CD <> ''").Length == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }

            //KG
            string[] a_cot_kg = chuyen.Fas_OBJ_STR((object[])a_dt_kg[0]);
            object[] a_gtri_kg = (object[])a_dt_kg[1];
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["kg"]) == "X" && chuyen.CNG_SO(chuyen.OBJ_S(b_dt_ct.Rows[0]["ngay_hl_kg"])) == 30000101)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập ngày hiệu lực:loi");
            }
            else if (chuyen.OBJ_S(b_dt_ct.Rows[0]["kg"]) == "X" && a_gtri_kg == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_kg = bang.Fdt_TAO_THEM(a_cot_kg, a_gtri_kg);
            if (chuyen.OBJ_S(b_dt_ct.Rows[0]["kg"]) == "X" && b_dt_kg.Select("MA_CD <> ''").Length == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_kt = bang.Fdt_TAO_BANG("MA_CD", "S");
            for (int i = 0; i < b_dt_mtd.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_ct.Rows[0]["mtd"]) == "X" && chuyen.OBJ_S(b_dt_mtd.Rows[i]["MA_CD"]) != "")
                {
                    DataRow b_dr = b_dt_kt.NewRow();
                    b_dr["MA_CD"] = b_dt_mtd.Rows[i]["MA_CD"];
                    b_dt_kt.Rows.Add(b_dr);
                }
            }
            for (int i = 0; i < b_dt_dmvs.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_ct.Rows[0]["dmvs"]) == "X" && chuyen.OBJ_S(b_dt_dmvs.Rows[i]["MA_CD"]) != "")
                {
                    if (b_dt_kt.Select("MA_CD='" + chuyen.OBJ_S(b_dt_dmvs.Rows[i]["MA_CD"] + "'")).Length > 0)
                    {
                        return form.Fs_LOC_LOI("loi:Mỗi chức danh chỉ được gán cho 1 đối tượng:loi");
                    }
                    DataRow b_dr = b_dt_kt.NewRow();
                    b_dr["MA_CD"] = b_dt_dmvs.Rows[i]["MA_CD"];
                    b_dt_kt.Rows.Add(b_dr);
                }
            }

            for (int i = 0; i < b_dt_onsite.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_ct.Rows[0]["onsite"]) == "X" && chuyen.OBJ_S(b_dt_onsite.Rows[i]["MA_CD"]) != "")
                {
                    if (b_dt_kt.Select("MA_CD='" + chuyen.OBJ_S(b_dt_onsite.Rows[i]["MA_CD"] + "'")).Length > 0)
                    {
                        return form.Fs_LOC_LOI("loi:Mỗi chức danh chỉ được gán cho 1 đối tượng:loi");
                    }
                    DataRow b_dr = b_dt_kt.NewRow();
                    b_dr["MA_CD"] = b_dt_onsite.Rows[i]["MA_CD"];
                    b_dt_kt.Rows.Add(b_dr);
                }
            }

            for (int i = 0; i < b_dt_kg.Rows.Count; i++)
            {
                if (chuyen.OBJ_S(b_dt_ct.Rows[0]["kg"]) == "X" && chuyen.OBJ_S(b_dt_kg.Rows[i]["MA_CD"]) != "")
                {
                    if (b_dt_kt.Select("MA_CD='" + chuyen.OBJ_S(b_dt_kg.Rows[i]["MA_CD"] + "'")).Length > 0)
                    {
                        return form.Fs_LOC_LOI("loi:Mỗi chức danh chỉ được gán cho 1 đối tượng:loi");
                    }
                    DataRow b_dr = b_dt_kt.NewRow();
                    b_dr["MA_CD"] = b_dt_kg.Rows[i]["MA_CD"];
                    b_dt_kt.Rows.Add(b_dr);
                }
            }
            ns_hdns.P_NS_CC_DTCC_NH(b_dt_ct, b_dt_mtd, b_dt_dmvs, b_dt_onsite, b_dt_kg);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri),
                b_mtd = mang.Fs_TEN_GTRI("mtd", a_cot, a_gtri), b_ngay_hl_mtd = mang.Fs_TEN_GTRI("ngay_hl_mtd", a_cot, a_gtri),
                b_dmvs = mang.Fs_TEN_GTRI("dmvs", a_cot, a_gtri), b_ngay_hl_dmvs = mang.Fs_TEN_GTRI("ngay_hl_dmvs", a_cot, a_gtri),
                b_onsite = mang.Fs_TEN_GTRI("onsite", a_cot, a_gtri), b_ngay_hl_onsite = mang.Fs_TEN_GTRI("ngay_hl_onsite", a_cot, a_gtri),
                b_kg = mang.Fs_TEN_GTRI("kg", a_cot, a_gtri), b_ngay_hl_kg = mang.Fs_TEN_GTRI("ngay_hl_kg", a_cot, a_gtri);
            if (chuyen.OBJ_S(b_mtd) == "") b_ngay_hl_mtd = "";
            if (chuyen.OBJ_S(b_dmvs) == "") b_ngay_hl_dmvs = "";
            if (chuyen.OBJ_S(b_onsite) == "") b_ngay_hl_onsite = "";
            if (chuyen.OBJ_S(b_kg) == "") b_ngay_hl_kg = "";
            return Fs_NS_CC_DTCC_MA(b_login, b_phong, b_mtd, b_dmvs, b_onsite, b_kg, b_ngay_hl_mtd, b_ngay_hl_dmvs, b_ngay_hl_onsite, b_ngay_hl_kg, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DTCC_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fobj_NS_CC_DTCC_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL_MTD,NGAY_HL_DMVS,NGAY_HL_ONSITE,NGAY_HL_KG");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DTCC_CT(string b_login, double b_so_id, string[] a_cot_mtd, string[] a_cot_dmvs, string[] a_cot_onsite, string[] a_cot_kg)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_CC_DTCC_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0], b_dt_mtd = b_ds.Tables[1], b_dt_dmvs = b_ds.Tables[2], b_dt_onsite = b_ds.Tables[3], b_dt_kg = b_ds.Tables[4];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL_MTD,NGAY_HL_DMVS,NGAY_HL_ONSITE,NGAY_HL_KG");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_dtcc", "DT_PH", "PHONG");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_mtd_s = bang.Fb_TRANG(b_dt_mtd) ? "" : bang.Fs_BANG_CH(b_dt_mtd, a_cot_mtd);
            string b_dt_dmvs_s = bang.Fb_TRANG(b_dt_dmvs) ? "" : bang.Fs_BANG_CH(b_dt_dmvs, a_cot_dmvs);
            string b_dt_onsite_s = bang.Fb_TRANG(b_dt_onsite) ? "" : bang.Fs_BANG_CH(b_dt_onsite, a_cot_onsite);
            string b_dt_kg_s = bang.Fb_TRANG(b_dt_kg) ? "" : bang.Fs_BANG_CH(b_dt_kg, a_cot_kg);
            return b_dt_s + "#" + b_dt_mtd_s + "#" + b_dt_dmvs_s + "#" + b_dt_onsite_s + "#" + b_dt_kg_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DTCC_MA(string b_login, string b_phong, string b_mtd, string b_dmvs, string b_onsite, string b_kg, string b_ngay_hl_mtd,
        string b_ngay_hl_dmvs, string b_ngay_hl_onsite, string b_ngay_hl_kg, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_CC_DTCC_MA(b_phong, b_mtd, b_dmvs, b_onsite, b_kg, b_ngay_hl_mtd, b_ngay_hl_dmvs, b_ngay_hl_onsite, b_ngay_hl_kg, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL_MTD,NGAY_HL_DMVS,NGAY_HL_ONSITE,NGAY_HL_KG");
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "phong", "ngay_hl_mtd", "ngay_hl_dmvs", "ngay_hl_onsite", "ngay_hl_kg" }, new object[] { b_phong,
                b_ngay_hl_mtd,b_ngay_hl_dmvs,b_ngay_hl_onsite,b_ngay_hl_kg });

            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DTCC_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_CC_DTCC_XOA(b_so_id); return Fs_NS_CC_DTCC_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion ĐỐI TƯỢNG CHẤM CÔNG

    #region [GÁN NĂNG LỰC CHO CHỨC DANH]

    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NL_CDANH_MA(string b_login, string b_so_id, string b_nnnghiepId, string b_cdanhId, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_NL_CDANH_MA(b_so_id, b_nnnghiepId, b_cdanhId, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang;
            if (chuyen.OBJ_N(b_so_id) > 0)
                b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            else
                b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NNNGHIEP", "CDANH", "NGAY_HL" }, new object[] { b_nnnghiepId, b_cdanhId, b_ngay_hl });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NL_CDANH_CT(string b_login, double b_so_id, string[] a_cot_ct)//dung
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_GAN_NL_CDANH_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NL_CDANH_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_NL_CDANH_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NL_CDANH_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_ct;
            if (a_gtri_ct == null) b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); }
            bang.P_BO_HANG(ref b_dt_ct, "nhom_nl", "");

            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }

            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (b_dt_ct.Rows[i]["nhom_nl"].ToString().Equals("") || b_dt_ct.Rows[i]["ten_nl"].ToString().Equals("") || b_dt_ct.Rows[i]["muc_nl"].ToString().Equals(""))
                {
                    return Thongbao_dch.nhapdulieu_luoi;
                }
            }
            ns_hdns.PNS_HDNS_GAN_NL_CDANH_NH(ref b_so_id, b_dt, b_dt_ct);
            var b_nnnghiepId = b_dt.Rows[0]["nnnghiep"].ToString();
            var b_cdanhId = b_dt.Rows[0]["cdanh"].ToString();
            var b_ngay_hl = b_dt.Rows[0]["ngay_hl"].ToString();
            return Fs_NS_HDNS_GAN_NL_CDANH_MA(b_login, b_so_id, b_nnnghiepId, b_cdanhId, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NL_CDANH_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_GAN_NL_CDANH_XOA(b_so_id);
            return Fs_NS_HDNS_GAN_NL_CDANH_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region  BH TỰ NGUYỆN CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_HDNS_BH_TN_CTY_MA(string b_login, string b_phong, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_BH_TN_CTY_MA(b_phong, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "phong", "ngay_hl" }, new string[] { b_phong, chuyen.OBJ_S(chuyen.CNG_SO(b_ngay_hl)) });
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_BH_TN_CTY_CT(string b_login, double b_so_id, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_BH_TN_CTY_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_gan_cdanhdvi", "DT_PH", "PHONG");
            bang.P_THEM_COL(ref b_dt_ct, "ten_tt", "");
            foreach (DataRow b_dr in b_dt_ct.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_BH_TN_CTY_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_BH_TN_CTY_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_BH_TN_CTY_NH(string b_login, double b_trangKT, object[] a_dt_ct, object[] a_dt_cd, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_cd = chuyen.Fas_OBJ_STR((object[])a_dt_cd[0]);
            object[] a_gtri_cd = (object[])a_dt_cd[1];
            if (a_gtri_cd == null)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            DataTable b_dt_cd = bang.Fdt_TAO_THEM(a_cot_cd, a_gtri_cd);
            if (b_dt_cd.Rows.Count == 0)
            {
                return form.Fs_LOC_LOI("loi:Vui lòng nhập chức danh:loi");
            }
            ns_hdns.P_NS_HDNS_BH_TN_CTY_NH(b_dt_ct, b_dt_cd);
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri), b_ngay_hl = mang.Fs_TEN_GTRI("ngay_hl", a_cot, a_gtri);
            return Fs_NS_HDNS_BH_TN_CTY_MA(b_login, b_phong, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_BH_TN_CTY_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        try { if (b_login != "") se.P_LOGIN(b_login); ns_hdns.P_NS_HDNS_BH_TN_CTY_XOA(b_so_id); return Fs_NS_HDNS_BH_TN_CTY_LKE(b_login, a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion BH TỰ NGUYỆN CÔNG TY

    #region GÁN NĂNG LỰC CHỨC DANH CHO ĐƠN VỊ

    [WebMethod(true)]
    public string Fs_NS_HDNS_NNN_CDANH_DROP_MA(string b_login, string b_nnnghiepId, string b_formName, string b_tableName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NNN_CDANH_DROP_MA(b_nnnghiepId);
            se.P_TG_LUU(b_formName, b_tableName, b_dt);
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_NLCD_DVI_LKE(b_tu, b_den);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_MA(string b_login, double b_so_id, string b_phong, string b_nnnghiepId, string b_cdanhId, string b_ngay_hl, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_GAN_NLCD_DVI_MA(b_so_id, b_phong, b_nnnghiepId, b_cdanhId, b_ngay_hl, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            int b_hang;
            if (b_so_id > 0)
                b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            else
                b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "PHONG", "NNNGHIEP", "CDANH", "NGAY_HL" }, new object[] { b_phong, b_nnnghiepId, b_cdanhId, b_ngay_hl });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_CT(string b_login, double b_so_id, string b_nnnghiep, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_GAN_NLCD_DVI_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_nl_cdanh_dvi", "NL_CD_DVI_PHONG", "PHONG");
            string b_nnnghiep_ct = b_dt.Rows[0]["NNNGHIEP"].ToString();
            if (b_nnnghiep != b_nnnghiep_ct)
            {
                DataTable b_dt_cd = ns_hdns.Fdt_NS_HDNS_NNN_CDANH_DROP_MA(b_nnnghiep_ct);
                se.P_TG_LUU("ns_hdns_nl_cdanh_dvi", "NL_CD_DVI_CDANH", b_dt_cd);
            }
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_nl_cdanh_dvi", "NL_CD_DVI_NNNGHIEP", "NNNGHIEP");
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_nl_cdanh_dvi", "NL_CD_DVI_CDANH", "CDANH");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
            return b_dt_s + "#" + b_dt_ct_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_CHA(string b_login, string b_nnnghiep, string b_cdanh, double b_ngay_hl, string[] a_cot_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fds_NS_HDNS_GAN_NLCD_DVI_CHA(b_nnnghiep, b_cdanh, b_ngay_hl);
            return bang.Fs_BANG_CH(b_dt, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_NH(string b_login, double b_so_id, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_ct;
            if (a_gtri_ct == null) b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); }
            bang.P_BO_HANG(ref b_dt_ct, "so_id_nl_ct", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            ns_hdns.PNS_HDNS_GAN_NLCD_DVI_NH(ref b_so_id, b_dt, b_dt_ct);
            string b_phong = b_dt.Rows[0]["phong"].ToString(), b_nnnghiepId = b_dt.Rows[0]["nnnghiep"].ToString(),
                b_cdanhId = b_dt.Rows[0]["cdanh"].ToString(), b_ngay_hl = b_dt.Rows[0]["ngay_hl"].ToString();
            return Fs_NS_HDNS_GAN_NLCD_DVI_MA(b_login, b_so_id, b_phong, b_nnnghiepId, b_cdanhId, b_ngay_hl, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_GAN_NLCD_DVI_XOA(string b_login, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_hdns.P_NS_HDNS_GAN_NLCD_DVI_XOA(b_so_id);
            return Fs_NS_HDNS_GAN_NLCD_DVI_LKE(b_login, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion GÁN NĂNG LỰC CHỨC DANH CHO ĐƠN VỊ

    #region KẾ HOẠCH QUỸ LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_LKE(string b_login, double b_nam, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fobj_NS_HDNS_KHNS_QLG_LKE(b_nam, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_khns_qlg", "KHNS_QLG_PHONG", "PHONG");
            bang.P_SO_CTH(ref b_dt, "thang_d,thang_c");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_MA(string b_login, double b_nam, string b_phong, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fobj_NS_HDNS_KHNS_QLG_MA(b_nam, b_phong, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "nam", "phong" }, new object[] { b_nam, b_phong });
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_khns_qlg", "KHNS_QLG_PHONG", "PHONG");
            bang.P_SO_CTH(ref b_dt, "thang_d,thang_c");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_CT(string b_login, double b_so_id, string b_phong, double b_ngay_d, double b_ngay_c, string[] a_cot_lke_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_KHNS_QLG_CT(b_so_id, b_phong, b_ngay_d, b_ngay_c);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tc = b_ds.Tables[1];

            bang.P_SO_CSO(ref b_dt_tc, new string[] { "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_SO_CNG(ref b_dt_tc, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_tc) ? "" : bang.Fs_BANG_CH(b_dt_tc, a_cot_lke_ct)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_NEW(string b_login, string b_phong, double b_ngay_d, double b_ngay_c, string[] a_cot_lke_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fds_NS_HDNS_KHNS_QLG_NEW(b_phong, b_ngay_d, b_ngay_c);

            bang.P_SO_CSO(ref b_dt, new string[] { "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_lke_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_NH(string b_login, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_THEM_COL(ref b_dt, "tong_cdanh", typeof(double));
            bang.P_THEM_COL(ref b_dt, "tong_tn_dkien", typeof(double));

            // thông tin quỹ  lương
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct;
            if (a_cot_ct == null)
                b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else
                b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, new string[] { "cdanh" }, new object[] { "" });
            if (b_dt_ct.Rows.Count == 0)
                return "loi:Bạn chưa nhập quỹ lương:loi";

            string b_loi = "";
            double b_tong_cdanh = 0, b_tong_tn_dkien = 0;
            ArrayList a_cdanh = new ArrayList();
            int b_index;
            foreach (DataRow b_dr in b_dt_ct.Rows)
            {
                if (String.IsNullOrEmpty(b_dr["cdanh"].ToString()))
                    b_loi = "Nhập thiếu Chức danh, ";
                if (String.IsNullOrEmpty(b_dr["loai_nv"].ToString()))
                    b_loi += "Nhập thiếu Loại nhân viên, ";
                if (String.IsNullOrEmpty(b_dr["tinhtrang"].ToString()))
                    b_loi += "Nhập thiếu Tình trạng, ";
                if (String.IsNullOrEmpty(b_dr["thu_nhap"].ToString()))
                    b_loi += "Nhập thiếu Thu nhập tháng hiện tại, ";
                if (String.IsNullOrEmpty(b_dr["luong_cb"].ToString()))
                    b_loi += "Nhập thiếu Lương cơ bản hiện tại, ";
                if (String.IsNullOrEmpty(b_dr["thu_nhap_kh"].ToString()))
                    b_loi += "Nhập thiếu Thu nhập tháng kế hoạch, ";
                if (String.IsNullOrEmpty(b_dr["luong_cb_kh"].ToString()))
                    b_loi += "Nhập thiếu Lương cơ bản kế hoạch, ";
                if (String.IsNullOrEmpty(b_dr["ngay_d_nam"].ToString()))
                    b_loi += "Nhập thiếu Thời gian bắt đầu làm việc trong năm, ";
                if (String.IsNullOrEmpty(b_dr["ngay_c_nam"].ToString()))
                    b_loi += "Nhập thiếu Thời gian kết thúc làm việc trong năm, ";

                if (b_loi != "")
                    return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

                b_index = a_cdanh.IndexOf(b_dr["cdanh"]);
                if (b_index < 0)
                {
                    b_tong_cdanh++;
                    a_cdanh.Add(b_dr["cdanh"]);
                }
                b_tong_tn_dkien += chuyen.OBJ_N(b_dr["tong_tn_dk"]);
            }
            b_dt.Rows[0]["tong_cdanh"] = b_tong_cdanh;
            b_dt.Rows[0]["tong_tn_dkien"] = b_tong_tn_dkien;

            bang.P_CTH_SO(ref b_dt, "thang_d"); bang.P_CTH_SO(ref b_dt, "thang_c");
            bang.P_CSO_SO(ref b_dt_ct, new string[] { "so_id", "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "thang_lv_dk", "thang_tn", "thang_tn_td", "tyle_lc", "tyle_tnx", "tyle_dl", "tyle_pt", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });
            if (b_dt_ct.Rows.Count == 0)
            {
                DataRow b_dr = b_dt_ct.NewRow();
                b_dr["so_id"] = -1;
                b_dt_ct.Rows.Add(b_dr);
            }
            ns_hdns.P_NS_HDNS_KHNS_QLG_NH(b_dt, b_dt_ct);
            double b_nam = chuyen.CSO_SO(mang.Fs_TEN_GTRI("nam", a_cot, a_gtri));
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_NS_HDNS_KHNS_QLG_MA(b_login, b_nam, b_phong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_KHNS_QLG_LS_CT(string b_login, double b_nam, string b_phong, string[] a_cot_lke_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_KHNS_QLG_LS_CT(b_nam, b_phong);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tc = b_ds.Tables[1];

            bang.P_TIM_THEM(ref b_dt, "ns_hdns_khns_qlg_ls", "KHNS_QLG_PHONG_LS", "PHONG");
            bang.P_SO_CTH(ref b_dt, "THANG_D,THANG_C");
            bang.P_SO_CSO(ref b_dt_tc, new string[] { "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_SO_CNG(ref b_dt_tc, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_tc) ? "" : bang.Fs_BANG_CH(b_dt_tc, a_cot_lke_ct)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KẾ HOẠCH QUỸ LƯƠNG

    #region ĐỊNH BIÊN NHÂN SỰ

    [WebMethod(true)]
    public string Fs_NS_HDNS_DINHBIEN_NS_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fobj_NS_HDNS_DINHBIEN_NS_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_DINHBIEN_NS_MA(string b_login, double b_nam, string b_phong, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fobj_NS_HDNS_DINHBIEN_NS_MA(b_nam, b_phong, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "nam", "phong" }, new object[] { b_nam, b_phong });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DINHBIEN_NS_CT(string b_login, double b_so_id, string b_phong, double b_ngay_d, double b_ngay_c, string[] a_cot_lke_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_DINHBIEN_NS_CT(b_so_id, b_phong, b_ngay_d, b_ngay_c);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tc = b_ds.Tables[1];

            bang.P_SO_CSO(ref b_dt_tc, new string[] { "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_SO_CNG(ref b_dt_tc, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            return ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_tc) ? "" : bang.Fs_BANG_CH(b_dt_tc, a_cot_lke_ct)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DBNS_NEW(string b_login, string b_phong, double b_ngay_d, double b_ngay_c, string[] a_cot_lke_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fds_NS_HDNS_DBNS_NEW(b_phong, b_ngay_d, b_ngay_c);

            bang.P_SO_CSO(ref b_dt, new string[] { "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_lke_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_DINHBIEN_NS_NH(string b_login, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt, "nam");
            bang.P_THEM_COL(ref b_dt, "tong_cdanh", typeof(double));
            bang.P_THEM_COL(ref b_dt, "tong_tn_dkien", typeof(double));

            // thông tin quỹ  lương
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct;
            if (a_cot_ct == null)
                b_dt_ct = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else
                b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_HANG(ref b_dt_ct, new string[] { "cdanh" }, new object[] { "" });
            if (b_dt_ct.Rows.Count == 0)
                return "loi:Bạn chưa nhập quỹ lương:loi";

            string b_loi = "";
            double b_tong_cdanh = 0, b_tong_tn_dkien = 0;
            ArrayList a_cdanh = new ArrayList();
            int b_index;
            foreach (DataRow b_dr in b_dt_ct.Rows)
            {
                if (String.IsNullOrEmpty(b_dr["cdanh"].ToString()))
                    b_loi = "Nhập thiếu Chức danh, ";
                if (String.IsNullOrEmpty(b_dr["loai_nv"].ToString()))
                    b_loi += "Nhập thiếu Loại nhân viên, ";
                if (String.IsNullOrEmpty(b_dr["tinhtrang"].ToString()))
                    b_loi += "Nhập thiếu Tình trạng, ";
                if (String.IsNullOrEmpty(b_dr["thu_nhap"].ToString()))
                    b_loi += "Nhập thiếu Thu nhập tháng hiện tại, ";
                if (String.IsNullOrEmpty(b_dr["luong_cb"].ToString()))
                    b_loi += "Nhập thiếu Lương cơ bản hiện tại, ";
                if (String.IsNullOrEmpty(b_dr["thu_nhap_kh"].ToString()))
                    b_loi += "Nhập thiếu Thu nhập tháng kế hoạch, ";
                if (String.IsNullOrEmpty(b_dr["luong_cb_kh"].ToString()))
                    b_loi += "Nhập thiếu Lương cơ bản kế hoạch, ";
                if (String.IsNullOrEmpty(b_dr["ngay_d_nam"].ToString()))
                    b_loi += "Nhập thiếu Thời gian bắt đầu làm việc trong năm, ";
                if (String.IsNullOrEmpty(b_dr["ngay_c_nam"].ToString()))
                    b_loi += "Nhập thiếu Thời gian kết thúc làm việc trong năm, ";

                if (b_loi != "")
                    return "loi:" + b_loi.Substring(0, b_loi.Length - 2) + ":loi";

                b_index = a_cdanh.IndexOf(b_dr["cdanh"]);
                if (b_index < 0)
                {
                    b_tong_cdanh++;
                    a_cdanh.Add(b_dr["cdanh"]);
                }
                b_tong_tn_dkien += chuyen.OBJ_N(b_dr["tong_tn_dk"]);
            }
            b_dt.Rows[0]["tong_cdanh"] = b_tong_cdanh;
            b_dt.Rows[0]["tong_tn_dkien"] = b_tong_tn_dkien;

            bang.P_CTH_SO(ref b_dt, "thang_d"); bang.P_CTH_SO(ref b_dt, "thang_c");
            bang.P_CSO_SO(ref b_dt_ct, new string[] { "so_id", "thu_nhap", "luong_cb", "thuong", "thu_nhap_kh", "luong_cb_kh", "thuong_kh", "thang_lv_dk", "thang_tn", "thang_tn_td", "tyle_lc", "tyle_tnx", "tyle_dl", "tyle_pt", "phucap1", "phucap2", "phucap3", "kh_bh", "phi_cd", "tongquy_tnt", "tong_pc", "tong_thuong_nx", "tong_chi_pl", "tong_tn_dk" });
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });
            if (b_dt_ct.Rows.Count == 0)
            {
                DataRow b_dr = b_dt_ct.NewRow();
                b_dr["so_id"] = -1;
                b_dt_ct.Rows.Add(b_dr);
            }
            ns_hdns.P_NS_HDNS_DINHBIEN_NS_NH(b_dt, b_dt_ct);
            double b_nam = chuyen.CSO_SO(mang.Fs_TEN_GTRI("nam", a_cot, a_gtri));
            string b_phong = mang.Fs_TEN_GTRI("phong", a_cot, a_gtri);
            return Fs_NS_HDNS_DINHBIEN_NS_MA(b_login, b_nam, b_phong, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion KẾ HOẠCH QUỸ LƯƠNG


    #region QUANG BAI 2
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_QUANG_BAI2_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt","A","Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_ncd", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "NV", "Nhân Viên");
            
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_SINHMA(string b_login, string b_mannghe, string b_ma_cmon, string b_ma_nngiep, string b_capbac)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_tusinh = ns_hdns.Fdt_NS_HDNS_MA_VTCD_MACBNN(0);
            string b_kq = "CD." + b_tusinh;
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hdns.Fdt_NS_HDNS_QUANG_BAI2_CT(b_ma);
            b_dt.AcceptChanges();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nnn, string ma_cd, string ten_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            a_object = ns_hdns.Fdt_NS_HDNS_QUANG_BAI2_LKE(b_nnn,ma_cd,ten_cd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "N", "Ngừng áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_ncd", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "NV", "Nhân Viên");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_QUANG_BAI2_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_QUANG_BAI2_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BAI2_XOA(string b_login,string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_QUANG_BAI2_XOA(b_ma); return Fs_NS_HDNS_QUANG_BAI2_LKE(b_login, a_tso, a_cot, "","",""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion


    #region QUANG BAI 3
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BT3_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_QUANG_BT3_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BT3_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fds_NS_HDNS_QUANG_BT3_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");

            se.P_TG_LUU("ns_hdns_bt3_quang", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_bt3_quang", "DT_TT", "ma_tt");
            
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BT3_LKE(string b_login, double[] a_tso, string[] a_cot, string b_ngay_tu, string b_ngay_den)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_QUANG_BT3_LKE(b_ngay_tu, b_ngay_den, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BT3_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_tl");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_gt");
            ns_hdns.P_NS_HDNS_QUANG_BT3_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_QUANG_BT3_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_QUANG_BT3_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_QUANG_BT3_XOA(b_ma); return Fs_NS_HDNS_QUANG_BT3_LKE(b_login, a_tso, a_cot, "",""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    #endregion





    #region Danh mục chức danh Longbai2


    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCDLONGBAI2_LKE(string b_login, double[] a_tso, string[] a_cot, string b_nnn, string b_ma_cd, string b_ten_cd )
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            //if (b_nnn != "") a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCD_LKE_NNN(b_tu_n, b_den_n, b_nnn);
            //else
                a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCDLONGBAI2_LKE(b_nnn, b_ma_cd, b_ten_cd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";
            }
            b_dt.AcceptChanges();
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public string Fs_NS_HDNS_MA_VTCDLONGBAI2_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_MA_VTCDLONGBAI2_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THEM_COL(ref b_dt, "ten_tt", "");

            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["tt"]) == "N") b_dr["ten_tt"] = "Ngừng áp dụng";
                else b_dr["ten_tt"] = "Áp dụng";

            }
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCDLONGBAI2_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_MA_VTCDLONGBAI2_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_MA_VTCDLONGBAI2_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }



    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCDLONGBAI2_CT(string b_login, string b_ma)
    {
    

        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            //DataTable b_dt;
            //b_dt = ns_hdns.Fdt_NS_HDNS_MA_VTCDLONGBAI2_CT(b_ma);
            //b_dt.AcceptChanges();
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_MA_VTCDLONGBAI2_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];
            se.P_TG_LUU("ns_hdns_cdanh_longbai2", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_cdanh_longbai2", "DT_TT", "MA_NNN");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDNS_MA_VTCDLONGBAI2_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct, string b_nnn, string b_ma_cd, string b_ten_cd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_MA_VTCDLONGBAI2_XOA(b_ma); return Fs_NS_HDNS_MA_VTCDLONGBAI2_LKE(b_login, a_tso, a_cot, b_nnn, b_ma_cd, b_ten_cd); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion


    #region Danh mục phòng ban Longbai3
    [WebMethod(true)]
    public string Fs_NS_PB_LONGBAI3_LKE(string b_login, string b_ngay_tu, string b_ngay_den, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_NS_PB_LONGBAI3_LKE(b_ngay_tu, b_ngay_den, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            //bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            //return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_PB_LONGBAI3_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_NS_PB_LONGBAI3_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            se.P_TG_LUU("ns_hdns_pban_ntduc", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_pban_ntduc", "DT_TT", "MA_TT");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    public string Fs_NS_PB_LONGBAI3_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_PB_LONGBAI3_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PB_LONGBAI3_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
       
            bang.P_CNG_SO(ref b_dt, "ngay_tl");
            bang.P_CNG_SO(ref b_dt, "ngay_gt");
            ns_hdns.P_NS_PB_LONGBAI3_NH(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_PB_LONGBAI3_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_PB_LONGBAI3_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct, string b_ngay_tu, string b_ngay_den)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_PB_LONGBAI3_XOA(b_ma); return Fs_NS_PB_LONGBAI3_LKE(b_login, b_ngay_tu, b_ngay_den, a_cot, a_tso  ); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_PBAN_NTDUC, TEN_BANG.NS_MA_PBAN_LONGBAI3);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion

    #region NTDUC_BAI2
    [WebMethod(true)]
    public string Fs_NS_HDNS_NTDUC_BAI2_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_NTDUC_BAI2_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "1", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "2", "Ngừng áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_ncd", "manhom");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "NV", "Nhân Viên");

            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            //DataTable b_dt1 = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); se.P_TG_LUU("ns_hdns_ma_vtcdanh", "DT_NN", b_dt1.Copy());
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NTDUC_BAI2_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hdns.Fdt_NS_HDNS_NTDUC_BAI2_CT(b_so_id);
            b_dt.AcceptChanges();
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NTDUC_BAI2_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            a_object = ns_hdns.Fdt_NS_HDNS_NTDUC_BAI2_LKE( b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "1", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "2", "Ngừng áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_ncd", "manhom");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "NV", "Nhân Viên");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NTDUC_BAI2_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_hdns.P_NS_HDNS_NTDUC_BAI2_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_HDNS_NTDUC_BAI2_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NTDUC_BAI2_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_HDNS_NTDUC_BAI2_XOA(b_ma); return Fs_NS_HDNS_NTDUC_BAI2_LKE(b_login, a_tso, a_cot, "", "", ""); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    private string Fs_NS_HDNS_NTDUC_BAI2_LKE(string b_login, double[] a_tso, string[] a_cot, string v1, string v2, string v3)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object;
            a_object = ns_hdns.Fdt_NS_HDNS_NTDUC_BAI2_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt, "ten_tt", "tthai");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "1", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "2", "Ngừng áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_ncd", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_ncd", "NV", "Nhân Viên");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion
    #region ntducbai3
    [WebMethod(true)]
    public string Fs_NS_PB_NTDUC_LKE(string b_login, string b_ngay_tu, string b_ngay_den, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_hdns.Fdt_NS_PB_NTDUC_LKE(b_ngay_tu, b_ngay_den, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            //bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            //return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_PB_NTDUC_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_NS_PB_NTDUC_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tt = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            se.P_TG_LUU("ns_hdns_pban_ntduc", "DT_TT", b_dt_tt);
            bang.P_TIM_THEM(ref b_dt, "ns_hdns_pban_ntduc", "DT_TT", "MA_TT");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    public string Fs_NS_PB_NTDUC_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NS_PB_NTDUC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
           
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_PB_NTDUC_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CNG_SO(ref b_dt, "ngay_tl");
            bang.P_CNG_SO(ref b_dt, "ngay_gt");
            ns_hdns.P_NS_PB_NTDUC_NH(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_PB_NTDUC_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_PB_NTDUC_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct, string b_ngay_tu, string b_ngay_den)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.P_NS_PB_NTDUC_XOA(b_ma); return Fs_NS_PB_NTDUC_LKE(b_login, b_ngay_tu, b_ngay_den, a_cot, a_tso); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_PBAN_NTDUC, TEN_BANG.NS_MA_PBAN_LONGBAI3);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion
    #region duc 4
    [WebMethod(true)]
    public string Fs_NTDUC_B4_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hdns.Fdt_NTDUC_4_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NTDUC_B4_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_hdns.Fdt_NTDUC_4_CT(b_ma);
            DataTable b_dt = b_ds.Tables[0];
           
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            
 
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public string Fs_NTDUC_B4_MA(string b_login, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_hdns.Fdt_NTDUC_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            b_dt.AcceptChanges();
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);

            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string NTDUC_BAI4_NH(string b_login, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            bang.P_CNG_SO(ref b_dt, "ngay_tl");
            bang.P_CNG_SO(ref b_dt, "ngay_ad");
            ns_hdns.NTDUC_BAI4_NH(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NTDUC_B4_MA(b_login, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string NTDUC_B4_XOA(string b_login, string b_ma, double[] a_tso, string[] a_cot, object[] a_dt_ct)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            bang.P_BO_COT(ref b_dt_ct, "CHON");
            string b_thongbao = "";
            string b_ma_trung = "";
            foreach (DataRow dr in b_dt_ct.Rows)
            {
                double b_tontai = ht_dungchung.FTL_HOI_MA_TONTAI(ht_dungchung.NS_HDNS_GAN_CDANHDVI_CT, ht_dungchung.MA_CDANH_XOA, dr["ma"].ToString(), ref b_thongbao);
                if (b_tontai <= 0)
                { ns_hdns.NTDUC_XOA(b_ma); return Fs_NTDUC_B4_LKE(b_login,a_tso,a_cot); }
                else { b_ma_trung += dr["ma"].ToString() + ", "; }
            }
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDNS_PBAN_NTDUC, TEN_BANG.NS_MA_PBAN_LONGBAI3);
            if (b_ma_trung == "") return "loi:Xóa thành công:loi";
            else return "loi:Xóa thành công,tồn tại mã " + b_ma_trung + " đã được sử dụng không thể xóa:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
}
    #endregion
