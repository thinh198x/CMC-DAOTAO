using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_ht : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                LKE(); 
                THANG.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void LKE()
    {
        DataTable b_dt = tl_ch.Fdt_TL_HT_LKE();
    }
}