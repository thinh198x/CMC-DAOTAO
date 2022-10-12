using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_dky_lamthempd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/tl_dky_lamthempd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_dky_lamthempd_P_KD('');", true);
                thang.Text = chuyen.NG_CTH(DateTime.Now);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1350,600";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
