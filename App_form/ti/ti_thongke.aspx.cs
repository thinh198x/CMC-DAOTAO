using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ti_thongke : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_thongke_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "600,530";
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}