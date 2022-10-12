using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ktkl_kt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ktkl/sns_ktkl.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ktkl/ns_ktkl_kt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ktkl_kt_P_KD('"+khac.Fs_TMUCF(b_s)+"');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "900,650";
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ktkl.PNS_KTKL_KT_EXPORT(SO_THE.Text);
            bang.P_SO_CNG(ref b_dt, "ngayqd"); 
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ktkl_kt_export.xlsx", b_dt, null, "Khen_thuong");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}