using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tl_dky_lamthem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/cc/tl_dky_lamthem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd();
            string b_nsd = b_se.nsd;
            string b_so_the = P_SOTHE(b_nsd);
            string b_phong = P_PHONG(b_nsd);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_dky_lamthem_P_KD('" + b_so_the + "','" + b_phong + "');", true);
            if (se.Fs_DUYET() != "IE") kthuoc.Value = "1010,640";
            thang.Text = chuyen.NG_CTH(DateTime.Now);
            NGAY_BD.Text = chuyen.NG_CNG(DateTime.Now);
            SO_THE.Focus(); P_NHAN_DROP(b_nsd);
        }
    }
    private void P_NHAN_DROP(string b_nsd)
    {
        DataTable b_dt = ns_tt.Fdt_LOC_PHEDUYET();
        form.P_DROP_BANG(nguoiduyet, b_dt);
        b_dt = ns_tt.Fdt_DKY_LAMTHEM_GAN(b_nsd);
        if (b_dt.Rows.Count > 0)
        {
            string b_nguoiduyet = b_dt.Rows[0]["nguoiduyet"].ToString();
            if (b_nguoiduyet != null && b_nguoiduyet == "") nguoiduyet.SelectedValue = b_nguoiduyet;
        }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    private string P_PHONG(string b_nsd)
    {
        string b_phong = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_phong = b_dt.Rows[0]["phong"].ToString();
        return b_phong;
    }
}
