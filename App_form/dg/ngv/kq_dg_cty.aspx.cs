using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_kq_dg_cty : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/kq_dg_cty" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "kq_dg_cty_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {

        DataTable b_dt = new DataTable();
        ////lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);

        // Lấy full kỳ đánh giá
        DataTable ky_dg = dg.Fdt_DG_DM_DTDG_KDG_DG();
        se.P_TG_LUU(this.Title, "DT_KY_DG_TK", ky_dg);

    }
    //private string P_SOTHE(string b_nsd)
    //{
    //    string b_so_the = "";
    //    DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
    //    if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
    //    return b_so_the;
    //}
}