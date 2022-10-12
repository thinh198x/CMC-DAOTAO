using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
using System.Globalization;

public partial class f_hdns_doituong_cc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/hdns_doituong_cc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "HDNS_DOITUONG_CC_P_KD();", true);
            string date = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(-1).ToString("dd/MM/yyyy");
            ngay_hl.Text = date;
            DataTable b_dt = ns_ma.Fdt_NS_MA_CDANH_LKE_DR("TATCA");
            bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
            form.P_DROP_BANG(cdanh, b_dt); 
        } 
    }
}
