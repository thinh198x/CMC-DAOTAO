using System;
using System.Web.UI;
using Cthuvien;

public partial class f_khud_trdoi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
            string b_s = this.ResolveUrl("~/App_form/khud/khud_trdoi" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "khud_trdoi_KD('" + file.ClientID + "','" + phim.ClientID + "','" + tieng.ClientID + "','" + td_nen.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            se.se_nsd b_se = new se.se_nsd();
            if (b_se.md != "BH") td_ghep.Visible = false;
        }
    }       
}
