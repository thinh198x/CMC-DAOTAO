using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ti_thongke_kq : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_thongke_kq_P_KD();", true);
                
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}