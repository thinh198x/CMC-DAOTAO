using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_ds_uvien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx")); 
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_ds_uvien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_ds_uvien_P_KD('');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1490,910";
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {

        DataTable b_ncdanh = dbora.Fdt_LKE("PNS_TD_CV_NCDANH");
        form.P_DROP_BANG(ncdanh, b_ncdanh);
        ncdanh.SelectedIndex = 0;
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { ncdanh.SelectedValue }, "pns_td_cv_cdanh_BY_NCDANH");
        form.P_DROP_BANG(cdanh, b_dt);
        cdanh.SelectedIndex = 0;
    }
}
