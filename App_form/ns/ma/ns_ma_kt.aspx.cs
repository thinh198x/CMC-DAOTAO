using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_kt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/ns_ma_kt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            P_LKE(); MA.Focus();
        }
    }
    ///<summary>Bảng liệt kê</summary>
    private DataTable Fdt_LKE()
    {
        DataTable b_dt = null;
        try
        {
            b_dt = ns_ma.Fdt_NS_MA_CH_LKE("PNS_MA_KT_LKE");            
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
        return b_dt;
    }
    ///<summary>Liệt kê</summary>
    private void P_LKE()
    {
        DataTable b_dt = Fdt_LKE();
        //grid.P_NHAN_BANG(b_dt, GR_lke);
    }
}
