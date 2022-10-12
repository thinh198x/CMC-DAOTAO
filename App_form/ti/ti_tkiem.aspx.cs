using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ti_tkiem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_timkiem_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "980,670";
                P_NHAN_DROP();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ti_ch.Fdt_NS_TK_MA_NHTK_DR();
        NHOM.DataSource = b_dt; NHOM.DataBind();
    }    
}