using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_tai_quetthe : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_tai_quetthe" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd();
                string b_nsd = b_se.nsd;
                string b_so_the = P_SOTHE(b_nsd);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_tai_quetthe_P_KD('" + b_so_the + "');", true);
                P_NHAP();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }

    private void P_NHAP()
    { 
        DataTable b_dt = ns_tt.Fdt_MAYCHAMCONG();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TC", "Tất cả" }, 0);
        form.P_DROP_BANG(MAY_CC, b_dt);
        MAY_CC.SelectedIndex = 0;
        NGAYD.Text = DateTime.Now.ToString("dd/MM/yyyy");
        NGAYC.Text = DateTime.Now.ToString("dd/MM/yyyy");

    } 
}