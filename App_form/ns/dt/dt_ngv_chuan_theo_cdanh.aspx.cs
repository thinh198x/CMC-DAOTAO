using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dt_ngv_chuan_theo_cdanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dt_ngv_chuan_theo_cdanh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dt_ngv_chuan_theo_cdanh_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "925,750";
                P_NHAN_DROP();
                loadYear();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        form.P_DROP_BANG(dvi, b_dt);
        dvi.DataSource = b_dt; dvi.DataBind();
        DataTable b_dt2 = hts_dungchung.Fdt_MA_CVU_LKE();
        bang.P_THEM_HANG(ref b_dt2, new object[] { "TATCA", "", "Tất cả", 0, "", "", 0 }, 0);
        form.P_DROP_BANG(cdanh, b_dt2);
        cdanh.DataSource = b_dt2;
        cdanh.DataBind();
    }
    private void loadYear()
    {
        DataTable b_dt3 = ht_dungchung.Fhdns_NAM();
        drnam.DataSource = b_dt3;
        drnam.DataBind();
        drnam.SelectedValue = DateTime.Now.Year.ToString();
    }
}
