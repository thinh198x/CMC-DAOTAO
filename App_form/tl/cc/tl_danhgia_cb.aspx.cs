using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_danhgia_cb : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                P_NHAN_DROP(); LKE(); THANG.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void LKE()
    {
        DataTable b_dt = tl_cc.Fdt_TL_DANHGIA_CB_LKE(PHONG.SelectedValue);
        b_dt = tl_cc.Fdt_TL_DANHGIA_CB_LKE_CB(PHONG.SelectedValue);
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
}