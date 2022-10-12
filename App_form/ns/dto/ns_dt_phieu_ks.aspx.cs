using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_phieu_ks : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_phieu_ks" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd); SO_THE.Text = b_nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_phieu_ks_P_KD('" + b_so_the + "');", true);
                SO_THE.Focus();
                P_NHAP_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAP_DROP()
    {
      DataTable b_dt = hts_dungchung.Fdt_DT_DOT_KHAOSAT();
      se.P_TG_LUU(this.Title, "DT_DOTKS", b_dt);

        //Nhu cầu đào tạo
      DataTable b_dt_c = dg.Fdt_NHUCAU_DT_DR();
      se.P_TG_LUU(this.Title, "DT_NCDT", b_dt_c.Copy());
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = ""; DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
}