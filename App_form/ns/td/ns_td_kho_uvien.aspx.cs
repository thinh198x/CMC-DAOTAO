using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_kho_uvien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_kho_uvien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_kho_uvien_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                CMT.Focus();
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = hts_dungchung.Fdt_CHUNG_LKE("GT");
        gioi_tinh.DataSource = b_dt; gioi_tinh.DataBind();
        dGT.DataSource = b_dt; dGT.DataBind();
    }
   
}
