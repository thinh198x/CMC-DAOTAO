using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tk_ma_thongkect : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
            DataTable b_dt = ti_ch.Fdt_NS_TK_MA_THONGKECT_LKE();
            MA.Focus(); 
        } 
    }
}

