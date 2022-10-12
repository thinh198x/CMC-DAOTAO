
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;

[System.Web.Script.Services.ScriptService]
public class sns_mota_cv : System.Web.Services.WebService
{
    #region MÔ TẢ CÔNG VIỆC
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_MA(string b_login, string b_ma_nnn, string b_ma_cd, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_mota_cv.Fdt_NS_HDNS_MOTA_CV_MA(b_ma_nnn, b_ma_cd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "NHOM_CD", "CDANH" }, new object[] { b_ma_nnn, b_ma_cd });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_NNN_VTCD_DROP_MA(string b_login, string b_mannn)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NNN_VTCD_DROP_MA(b_mannn);
            se.P_TG_LUU("hdns_mota_cv", "DT_CDANH", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_CT(string b_login, double b_so_id, string[] a_cot_nv)
    {
        try
        {
            string b_ma_nnn = "";
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_mota_cv.Fds_HDNS_MOTA_CV_CT(b_so_id);
            DataTable b_dt_ct = b_ds.Tables[0], b_dt_nv = b_ds.Tables[1];
            if (b_dt_ct.Rows.Count == 0) { b_ma_nnn = ""; } else { b_ma_nnn = b_dt_ct.Rows[0]["NHOM_CD"].ToString(); }
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NNN_VTCD_DROP_MA(b_ma_nnn);
            bang.P_TIM_THEM(ref b_dt_ct, "hdns_mota_cv", "DT_NHOM_CD", "NHOM_CD");
            se.P_TG_LUU("hdns_mota_cv", "DT_CDANH", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_ct, "hdns_mota_cv", "DT_CDANH", "CDANH");
            bang.P_SO_CNG(ref b_dt_ct, "NGAY_BH,NGAY_SD");
            string b_dt_ct_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_HANG_GOP(b_dt_ct, 0);
            string b_dt_nv_s = bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_nv);
            return b_dt_ct_s + "#" + b_dt_nv_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_LKE(string b_login, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_mota_cv.Fdt_NS_HDNS_MOTA_CV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt_tk = (DataTable)a_object[1];
            // bang.P_THEM_COL(ref b_dt_tk, "ten_nal", "");
            return chuyen.OBJ_N(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_NH(string b_login, double b_so_id, object[] a_dt_ct, object[] a_dt_nv, double b_trangKT, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            string[] a_cot_nv = chuyen.Fas_OBJ_STR((object[])a_dt_nv[0]);
            object[] a_gtri_nv = (object[])a_dt_nv[1];
            DataTable b_dt_nv = bang.Fdt_TAO_THEM(a_cot_nv, a_gtri_nv);

            double b_dem = 0;
            for (int i = 0; i < b_dt_nv.Rows.Count; i++)
            {
                if (b_dt_nv.Rows[i]["SOTT"].ToString() != "" || b_dt_nv.Rows[i]["NV_CV"].ToString() != "" ||
                    b_dt_nv.Rows[i]["THAMQUYEN"].ToString() != "" || b_dt_nv.Rows[i]["MUCTIEU_KQ"].ToString() != "")
                {
                    if (b_dt_nv.Rows[i]["SOTT"].ToString() == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập số thứ tự:loi");
                    }
                    else
                    {
                        double b_kt = 0;
                        if (!double.TryParse(b_dt_nv.Rows[i]["SOTT"].ToString(), out b_kt))
                        {
                            return form.Fs_LOC_LOI("loi:Số thứ tự không đúng định dạng:loi");
                        }
                    }

                    if (b_dt_nv.Rows[i]["NV_CV"].ToString() == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập nhiệm vụ công việc:loi");
                    }

                    if (b_dt_nv.Rows[i]["THAMQUYEN"].ToString() == "")
                    {
                        return form.Fs_LOC_LOI("loi:Phải nhập thẩm quyền:loi");
                    }
                    b_dem += 1;
                }
            }

            if (b_dem == 0) return form.Fs_LOC_LOI("loi:Yêu cầu nhập các trường bắt buộc:loi");
            else
            {
                bang.P_DON(ref b_dt_nv);
                bang.P_CSO_SO(ref b_dt_nv, "SOTT");
                ns_mota_cv.P_NS_HDNS_MOTA_CV_NH(ref b_so_id, b_dt_ct, b_dt_nv);
                //Ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.HDNS_MOTA_CV, TEN_BANG.HDNS_MOTA_CV);
                return Fs_NS_HDNS_MOTA_CV_SOID(b_login, b_so_id, b_trangKT, a_cot_lke);
            }
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_XOA(string b_login, double b_so_id, double[] a_tso, string[] a_cot)
    {
        if (b_login != "") se.P_LOGIN(b_login);
        try {
            ns_mota_cv.P_NS_HDNS_MOTA_CV_XOA(b_so_id);
            //Ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.HDNS_MOTA_CV, TEN_BANG.HDNS_MOTA_CV);
            return Fs_NS_HDNS_MOTA_CV_LKE(b_login, a_tso, a_cot); 
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDNS_MOTA_CV_SOID(string b_login, double b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_mota_cv.Fdt_NS_HDNS_MOTA_CV_SOID(b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "SO_ID", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÔ TẢ CÔNG VIỆC
}
