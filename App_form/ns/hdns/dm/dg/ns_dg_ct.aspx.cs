using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_ct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/dg/ns_dg_ct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_ct_P_KD();", true);
            P_NAM_DROP();
            P_KY_DG_DROP();
            P_PLNV_DROP();            
        }
    }

    private void P_NAM_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "TC_DG_CT_NAM", b_dt);
    }

    private void P_KY_DG_DROP()
    {
        DataTable b_dt = dg.Fdt_NS_DG_MA_KDG_LKE_ALL();
        se.P_TG_LUU(this.Title, "TC_DG_CT_KY_KDG", b_dt);
    }

    private void P_PLNV_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_PLNV_LKE_ALL("A");
        se.P_TG_LUU(this.Title, "TC_DG_CT_PLNV", b_dt);
    }
}