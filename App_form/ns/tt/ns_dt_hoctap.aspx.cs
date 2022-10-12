using System;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_hoctap : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_dt_hoctap" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_hoctap_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1100,580";
                P_NHAN_DROP(); 
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        //ma_htdt.DataSource = ns_ma.Fdt_NS_MA_HTDT_DR_A();
        //ma_htdt.DataBind();

        //ma_cndt.DataSource = ns_ma.Fdt_NS_MA_CNGANH_DT_DR_A();
        //ma_cndt.DataBind();

        var b_dt = ns_ma.Fdt_PNS_MA_CHUNG_DR_A("KQDT");
        se.P_TG_LUU(this.Title, "DT_KQDT", b_dt);
    }
}