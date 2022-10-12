using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ctt_dxdt_ql_pd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ctt/ngv/ns_ctt_dxdt_ql_pd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);

               

                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ctt_dxdt_ql_pd_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";
                                                                
                this.P_TrangThaiPheDuyet_DROP();
               
                //NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }      

    private void P_TrangThaiPheDuyet_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Không phê duyệt" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_PD", b_dt);
    }
}