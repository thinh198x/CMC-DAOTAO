using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sbc : System.Web.Services.WebService {


    [WebMethod(true)]
    public string Fs_NHAN_MAU(string b_mau, string[] a_cot)
    {
        try
        {
            DataTable b_dt = khud_file.Fdt_Excel(System.Web.HttpContext.Current.Server.MapPath(b_mau));
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_BKT_LUU_TSO(string b_form, string b_md, string b_ma_bc, string b_ddan, string b_ten_rp,string b_ma_donvi,string b_ma_duan, string b_kieu_in, object[] a_dt_ct)
    {
        try
        {
            string[] a_ten = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_ten, a_gtri);
            bang.P_THEM_COL(ref b_dt_ct, new string[] { "md", "ma_bc", "ddan", "ten_rp","ma_donvi","ma_duan", "kieu_in"},
                    new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_ma_donvi,b_ma_duan, b_kieu_in });
            HttpContext.Current.Session[b_md.ToUpper() + "_SS"] = b_dt_ct;
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_MA_DVI_CD(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_CD(); bang.P_DOI_TENCOL(ref b_dt, "dvi", "ma");
            bang.P_THEM_COL(ref b_dt, "chon", "K");
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_MO_MAU_BC(string b_ddan, string b_ten_rp, string b_ten)
    {
        try
        {
            DataTable b_dt = c_khac.Fdt_MO_MAU_BC(b_ddan, b_ten_rp);
            if (b_dt.Rows.Count == 0)
            {
                bang.P_THEM_HANG(ref b_dt, new object[] { b_ten_rp, b_ten });
            }
            return bang.Fs_BANG_CH(b_dt, new string[] { "file", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_GRID_BC(string b_ddan, string b_ten, string b_loai_sl, string[] a_cot, double[] a_tso)
    {
        try
        {
            object[] a_obj = bc.Fdt_GRID_BC(b_ddan, b_ten, b_loai_sl, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_LOAD_TREE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = bc.Fdt_NS_DONVI_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_SE_DVI()
    {
        return (new se.se_nsd()).ma_dvi;
    }
    [WebMethod(true)]
    public string Fs_SE_CAP_DVI()
    {
        se.se_nsd b_se = new se.se_nsd();
        return b_se.cap + "#" + b_se.ma_dvi;
    }
    [WebMethod(true)]
    public string Fs_DANHSACH_KYLUONG_LKE(string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.CSO_SO(b_nam));
            se.P_TG_LUU("ns_ngbc", "DT_KYLUONG", b_dt.Copy());
            se.P_TG_LUU("ns_ngbc", "DT_KYLUONG1", b_dt.Copy());
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #region BÁO CÁO NHÂN SỰ
    [WebMethod(true)]
    public string Fs_NHAN_LUOI(string[] a_cot)
    {
        DataTable b_dt = khud_file.Fdt_Excel(System.Web.HttpContext.Current.Server.MapPath("~/Templates/ns/ns_bc.xls"));
        return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
    }
    #endregion
    
}
