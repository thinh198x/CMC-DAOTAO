using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_qtrr : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/ns_ma_qtrr" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_qtrr_P_KD();", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("QTRR", "NS_MA_QTRR", "MA");
                ma.Focus();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    [Obsolete]
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_QTRR_DR();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "TC", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TC", "N", "Ngừng áp dụng");
            var unused = Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_qtrr.xlsx", b_dt, null, "Danh sách quản trị rủi ro");
        }
        catch (Exception)
        {
            form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }

}
