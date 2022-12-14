using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tt_bh_cmccare : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_tt_bh_cmccare" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tt_bh_cmccare_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_cd.Fdt_NS_TT_BH_CMCCARE_LKE_ALL();
            b_dt_bv.TableName = "DATA";

            bang.P_SO_CSO(ref b_dt_bv, "mucphi");
            bang.P_SO_CNG(ref b_dt_bv, "nsinh,ngay_thamgia");

            b_ds.Tables.Add(b_dt_bv);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tt_bh_cmccare.xlsx", b_ds, null, "ns_tt_bh_cmccare" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }

}
