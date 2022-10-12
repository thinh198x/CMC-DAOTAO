using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ho_gdinh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_ho_gdinh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ho_gdinh_P_KD();", true);
                P_TINHTHANH_DROP(); 
                CHUHO.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_TINHTHANH_DROP()
    {
        DataTable b_dt_tt = ns_ma.Fdt_NS_MA_TT_DR();
        se.P_TG_LUU(this.Title, "NS_HO_GDINH_TT", b_dt_tt);

        DataTable b_dt_gt = hts_dungchung.Fdt_CHUNG_LKE("GT");
        se.P_TG_LUU(this.Title, "NS_HO_GDINH_GT", b_dt_gt);

        DataTable b_dt = ns_ma.Fdt_NS_MA_LQH_DR();
        se.P_TG_LUU(this.Title, "NS_HO_GDINH_QHE", b_dt);
    }
}