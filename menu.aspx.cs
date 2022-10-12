using System;
using System.Web.UI;
using Cthuvien;

public partial class f_menu : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool b_log = false;
        try
        {
            b_log = khac.Fb_HOI_QU(this.Title);
            if (!b_log)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                string b_s = this.ResolveUrl("~/menu" + khac.Fs_runMode() + ".js"), b_tm = Fs_tm("D");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = "menu_KD('" + Fs_tm("K") + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
                string b_file = b_tm + "/ctmenu";
                b_log = khac.Fb_KTRA_QU(this.Title, b_file, "GXDPIMAE"); tm.Value = b_tm;
            }
            else b_log = false;
        }
        catch { b_log = false; }
        if (!b_log) { se.P_TG_XOA(this.Title); Response.Redirect("~/login.aspx", false); }
        else
        {
            se.se_nsd b_se = new se.se_nsd();
            this.Lb_dvi.Text = b_se.ma_dvi + " - " + b_se.ten_dvi;
            this.Lb_phong.Text = b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong));
            this.Lb_nsd.Text = b_se.nsd + " - " + b_se.ten;
        }
    }
    private string Fs_tm(string b_dk)
    {
        string b_f = "~/menu.aspx";
        string b_tm = (b_dk == "D") ? Server.MapPath(b_f) : this.ResolveUrl(b_f);
        return b_tm.Substring(0, b_tm.Length + 1 - b_f.Length);
    }
}
