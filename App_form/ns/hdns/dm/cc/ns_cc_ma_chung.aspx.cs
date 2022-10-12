using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_ma_chung : fmau
{
    private string m_ma_nhom = "", m_ten_nhom = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cc/ns_cc_ma_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                P_MA_CHUNG_NHOM_DROP();
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_ma_chung_P_KD('" + m_ma_nhom + "','" + m_ten_nhom + "');", true);
                NHOM_MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_MA_CHUNG_NHOM_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_CC_MA_CHUNG_NHOM_DR();
        if (b_dt.Rows.Count > 0)
        {
            m_ma_nhom = b_dt.Rows[0]["Ma"].ToString();
            m_ten_nhom = b_dt.Rows[0]["Ten"].ToString();
        } 
        se.P_TG_LUU(this.Title, "DT_CC_MA_CHUNG_NHOM", b_dt);
    }
}