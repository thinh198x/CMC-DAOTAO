using System;
using System.Web.UI;
using Cthuvien;

public partial class f_login : fmau
{
    private void Page_Load(object sender, EventArgs e)
    {
        try
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
            ht_macb.PHT_DS_USER_ONLINE_NH("0");
            Session.Clear();
            tm.Value = Fs_tm(); MA_NSD.Focus();
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private string Fs_tm()
    {
        string b_f = "~/login.aspx";
        string b_tm = Server.MapPath(b_f);
        return b_tm.Substring(0, b_tm.Length + 1 - b_f.Length);
    }
}
