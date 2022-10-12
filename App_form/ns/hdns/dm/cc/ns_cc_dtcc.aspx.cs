using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
using System.Globalization;

public partial class f_ns_cc_dtcc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cc/ns_cc_dtcc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_dtcc_P_KD();", true);
            string date = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(-1).ToString("dd/MM/yyyy");
            P_NHAN_DROP();
        } 
    }

    private void P_NHAN_DROP()
    {
        //Ma dvi
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PH", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CD", null);
        
    }
}
