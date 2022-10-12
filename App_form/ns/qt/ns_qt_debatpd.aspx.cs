using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_qt_debatpd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qt_debatpd_P_KD('');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "920,640";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
