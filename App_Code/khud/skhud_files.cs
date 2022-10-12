using System;
using System.Data;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class skhud_files : System.Web.Services.WebService {

    #region FILES
    [WebMethod(true)]
    public string Fs_FILES_LKE(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = khud_files.Fdt_FILES_LKE(b_so_id);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_FILES_CT(string b_so_id, string b_tt)
    {
        try
        {
            DataTable b_dt = khud_files.Fdt_FILES_CT(b_so_id, b_tt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_FILES_NH(string b_tt, string b_so_id, string b_tenf, string b_url)
    {
        try
        {
            khud_files.P_FILES_NH(ref b_tt, b_so_id, b_tenf, b_url);
            return b_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_FILES_XOA(string b_so_id, string b_tt)
    {
        try { khud_files.P_FILES_XOA(b_so_id, b_tt); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion FILES

    #region FILES KHUD UPLOAD
    [WebMethod(true)]
    public string Fs_NS_KHUD_FILES_UP_LKE(string b_ma, string[] a_cot)
    {
        try
        {
            DataTable b_dt = khud_files.Fdt_NS_KHUD_FILES_UP_LKE(b_ma);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHUD_FILES_UP_CT(string b_ma, string b_tt)
    {
        try
        {
            DataTable b_dt = khud_files.Fdt_NS_KHUD_FILES_UP_CT(b_ma, b_tt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHUD_FILES_UP_NH(string b_tt, string b_ma, string b_tenbc, string b_tenf, string b_url)
    {
        try
        {
            khud_files.P_NS_KHUD_FILES_UP_NH(ref b_tt, b_ma, b_tenbc, b_tenf, b_url);
            return b_tt;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_KHUD_FILES_UP_XOA(string b_ma, string b_tt)
    {
        try { khud_files.P_NS_KHUD_FILES_UP_XOA(b_ma, b_tt); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion FILES KHUD UPLOAD
    
}
