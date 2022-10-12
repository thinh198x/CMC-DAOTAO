using System;
using System.Data;
using System.Web.Services;
using Cthuvien;


[System.Web.Script.Services.ScriptService]
public class sht : WebService
{

    #region ĐỔI MẬT KHẨU
    [WebMethod(true)]
    public string Fs_DOI_PASS_NH(string b_login,object[] a_dt_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ht.P_DOI_PASS_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion ĐỔI MẬT KHẨU
}
