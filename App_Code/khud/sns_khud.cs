using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Drawing;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_khud : WebService {
    #region TTT
    private DataTable Fdt_TTT_SAN(string b_ps, string b_nv)
    {
        try
        {
            string b_tmuc = Server.MapPath("~/App_form/kt" + b_ps + "/kt" + b_ps + "_file");
            string b_file = b_tmuc + "\\" + b_ps + "ttt_" + b_nv + ".xls";
            DataTable b_dt = khac.Fdt_Excel(b_file); bang.P_DON(ref b_dt);
            return b_dt;
        }
        catch { return null; }
    }
    [WebMethod(true)]
    public string Fs_TTT_SAN(string b_login, string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = Fdt_TTT_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt))
            {
                DataTable b_dt_s = null;
                string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
                if (a_gtri != null) { b_dt_s = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_DON(ref b_dt_s); }
                if (!bang.Fb_TRANG(b_dt_s)) bang.P_BO_HANG(ref b_dt, "ma", b_dt_s, "ma");
            }
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten", "loai" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_TAO(string b_login, string b_ps, string b_nv)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_khud.Fdt_TTT_LKE(b_ps, b_nv);
            if (bang.Fb_TRANG(b_dt)) return "";
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["bb"]) == "C") b_dr["ten"] = chuyen.OBJ_S(b_dr["ten"]) + "(*)";
            }
            bang.P_THEM_COL(ref b_dt, new string[] { "nd", "loi" }, "SS");
            return khac.Fs_TTT_TAO(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_LKE(string b_login, string b_ps, string b_nv, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = Fdt_TTT_SAN(b_ps, b_nv);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "K" : "C";
            b_dt = ns_khud.Fdt_TTT_LKE(b_ps, b_nv);
            return b_kq + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_NH(string b_login, string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = null;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            if (a_gtri != null) { b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "rong"); bang.P_DON(ref b_dt); }
            if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:Nhập chi tiết:loi");
            bang.P_CH_KHONG(ref b_dt);
            bang.P_THEM_COL(ref b_dt, new string[] { "ktra", "f_tkhao", "f_sht_tkhao" }, "SSS");
            string b_tmuc = Server.MapPath("~/App_form/kt" + b_ps + "/kt" + b_ps + "_file");
            string b_file = b_tmuc + "\\ttt_" + b_nv + ".xls";
            DataTable b_dt_s = Fdt_TTT_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt_s))
            {
                string b_ma; int b_hang;
                foreach (DataRow b_dr in b_dt_s.Rows)
                {
                    b_ma = chuyen.OBJ_S(b_dr["ma"]);
                    b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
                    if (b_hang >= 0) bang.P_DAT_GTRI(ref b_dt, new string[] { "loai", "ktra", "f_tkhao", "f_sht_tkhao" },
                            new object[] { chuyen.OBJ_S(b_dr["loai"]), chuyen.OBJ_S(b_dr["ktra"]),
                            chuyen.OBJ_S(b_dr["f_tkhao"]), chuyen.OBJ_S(b_dr["f_sht_tkhao"]) }, b_hang);
                }
            }
            ns_khud.P_TTT_NH(b_ps, b_nv, b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_XOA(string b_login, string b_ps, string b_nv)
    {
        try { se.P_LOGIN(b_login); ns_khud.P_TTT_XOA(b_ps, b_nv); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion
    
}
