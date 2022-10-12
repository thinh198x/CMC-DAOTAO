using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_qt_debat : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));                               
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_qt_debat" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qt_debat_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1420,750";
                NGAY_LAP.Focus();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
}