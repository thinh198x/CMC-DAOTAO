using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class App_form_ns_ma_ns_ma_tinhthanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/ns_ma_tinhthanh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_tinhthanh_P_KD();", true);
            ma.Text = ht_dungchung.Fdt_AutoGenCode("TT", "NS_MA_TINHTHANH", "MA");
            ma.Focus();
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_TINHTHANH_DR();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "TC", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TC", "N", "Ngừng áp dụng");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_tinhthanh.xlsx", b_dt, null, "Danh sách tỉnh thành");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}