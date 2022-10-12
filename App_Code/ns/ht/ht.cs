using System.Data;
using Cthuvien;

/// <summary>
/// Summary description for ht
/// </summary>
public class ht
{
    public static void P_DOI_PASS_NH(DataTable b_dt_ct)
    {
        DataRow b_dr_ct = b_dt_ct.Rows[0];
        string b_mk_c = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(b_dr_ct["pascu"].ToString().Trim(), "SHA1");
        string b_mk_m = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(b_dr_ct["pasmoi"].ToString().Trim(), "SHA1");
        string b_mk_cf = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(b_dr_ct["cfpas"].ToString().Trim(), "SHA1");
        object[] a_obj = new object[] { b_mk_c, b_mk_m, b_mk_cf };
        dbora.P_GOIHAM(a_obj, "PHT_DOIPASS_NH");
    }
}