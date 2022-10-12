using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_cm : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_cm" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_cm_P_KD();", true);
            P_NHAN_DROP(); MA.Focus();
        }
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NN_XEM();
        se.P_TG_LUU(this.Title, "DT_NN", b_dt.Copy());
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";
        DataTable b_dtNN = se.Fdt_TG_TRA(this.Title, "DT_NN");
        b_dtNN.TableName = "DATA1";
        DataSet b_ds = new DataSet();
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dtNN);
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_ma_cm_mau.xls", b_ds, null, "ns_hdns_ma_cm_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_CM_EXCEL();
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_ma_cm.xlsx", b_dt, null, "Danh_muc_chuyen_mon");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
