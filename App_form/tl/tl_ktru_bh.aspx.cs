using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_ktru_bh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                P_NHAN_DROP(); LKE();
                THANG.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void LKE()
    {
        //DataTable b_dt = tl_ch.Fdt_TL_KTRU_BH_LKE(PHONG.SelectedValue);
        //grid.P_NHAN_BANG(b_dt, GR_lke);
        //b_dt = tl_ch.Fdt_TL_KTRU_BH_LKE_CB(PHONG.SelectedValue);
        //grid.P_NHAN_BANG(b_dt, GR_ct);
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
}