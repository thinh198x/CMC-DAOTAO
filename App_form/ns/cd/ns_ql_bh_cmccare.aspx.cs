using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ql_bh_cmccare : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_ql_bh_cmccare" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ql_bh_cmccare_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_cd.Fdt_NS_QL_BH_CMCCARE_LKE_ALL();
            b_dt_bv.TableName = "DATA";

            bang.P_SO_CSO(ref b_dt_bv, "mucphi_ht,mucphi_dc");
            bang.P_SO_CNG(ref b_dt_bv, "nsinh,ngay_hl,ngaygiam_bh");

            b_ds.Tables.Add(b_dt_bv);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ql_bh_cmccare.xlsx", b_ds, null, "ns_ql_bh_cmccare" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        form.P_DROP_BANG(phong_tk, b_dt);
    }
}
