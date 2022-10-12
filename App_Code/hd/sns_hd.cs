using System;
using System.Data;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_hd : System.Web.Services.WebService {

    #region MA_PH
    [WebMethod(true)]
    public string Fs_NS_HD_DVI(string b_login, string b_dvi, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); DataTable b_dt = ht_maph.Fdt_MA_PH_DVI(b_dvi);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_LKE(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt;
            b_dt = ns_hd.Fdt_NS_HD_LKE();
            bang.P_THEM_COL(ref b_dt,"iurl");
            int i = b_dt.Rows.Count;
            if (i <= 0)
            {
                b_dt = ht_maph.Fdt_MA_PH_LKE();
                bang.P_THEM_COL(ref b_dt, new string[] { "iurl", "loai" });
            }
            return i.ToString() + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_NH(string b_login, string a_qly,string a_ma,string a_ten)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_hd.P_NS_HD_NH(a_qly, a_ma, a_ten);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_XOA(string b_login, string b_ma)
    {
        try { se.P_LOGIN(b_login); ns_hd.P_NS_HD_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion MA_PH    
}