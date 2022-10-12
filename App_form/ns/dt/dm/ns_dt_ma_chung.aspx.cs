using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_ma_chung : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                P_MA_CHUNG_NHOM_DROP();
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_chung_P_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_MA_CHUNG_NHOM_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CHUNG_NHOM_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM_MA", b_dt);
    }
}