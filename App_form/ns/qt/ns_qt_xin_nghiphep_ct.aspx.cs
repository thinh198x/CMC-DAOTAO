using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_qt_xin_nghiphep_ct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                se.se_nsd b_se = new se.se_nsd();
                string b_nsd = b_se.nsd;
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_qt_xin_nghiphep_ct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qt_xin_nghiphep_ct_P_KD('"  + b_nsd + "');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1150,600";
                P_NHAN_DROP(); sothe_thaythe.Focus(); ngayxn.Text = ngayd.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        form.P_DROP_BANG(PHONG, b_dt);
        b_dt = tl_ma.Fdt_CC_MA_CC_DR("N");
        form.P_DROP_BANG(macc_nghi, b_dt);
    }
}
