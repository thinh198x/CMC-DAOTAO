using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_kh_ct_tkb : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_kh_ct_tkb" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_kh_ct_tkb_P_KD();", true);
                this.P_LHGD_DROP();
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_LHGD_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_PNS_MA_CHUNG_DR("LGV");
        se.P_TG_LUU(this.Title, "DT_MA_LHGD", b_dt);
    }
}