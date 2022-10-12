using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_taisan : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/sk/ma/ns_ma_taisan" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_taisan_P_KD();", true);
            ma.Text = ht_dungchung.Fdt_AutoGenCode("TS", "NS_MA_TAISAN_CAPPHAT", "MA");
            ma.Focus();
            P_NHAN_DROP();
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_TAISAN_EXCEL();
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_SO_CSO(ref b_dt, "sotien");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_ma_taisan.xlsx", b_dt, null, "Danh_muc_tai_san");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        // load nhóm 
        DataTable b_dt = new DataTable();
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("NHOM_TS");
        form.P_LKE_DAT(NHOM, b_dt);
        se.P_TG_LUU(this.Title, "NHOM_TS", b_dt);
    }
}
