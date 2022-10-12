using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_qt_nghiviec_pd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));                
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_qt_nghiviec_pd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qt_nghiviec_pd_P_KD();", true);
                NGAY_PD.Text = chuyen.NG_CNG(DateTime.Now); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
    public string b_so_the = "", b_ten = "";
    private void P_SOTHE(string b_nsd)
    {
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) { b_so_the = b_dt.Rows[0]["so_the"].ToString(); b_ten = b_dt.Rows[0]["ten"].ToString(); }
    }

}
