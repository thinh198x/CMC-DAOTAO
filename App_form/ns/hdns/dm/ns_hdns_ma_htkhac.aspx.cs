using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_htkhac : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/ns_hdns_ma_htkhac" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_htkhac_P_KD();", true);
            MA.Focus();
            P_NHAN_DROP();
            MA.Text = ht_dungchung.Fdt_AutoGenCode("HTK", "ns_hdns_ma_htkhac", "MA");
        }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_HTKHAC_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "TT", "Theo tháng");
            bang.P_THAY_GTRI(ref b_dt, "hinhthuc", "TCTT", "Theo công thực tế");
            bang.P_SO_CSO(ref b_dt, "SOTIEN");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_HTKHAC, TEN_BANG.NS_HDNS_MA_HTKHAC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_ma_htkhac.xlsx", b_dt, null, "Danh_muc_cac_khoan_ho_tro_khac");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt;
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("HTH");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        form.P_LIST_BANG(HINHTHUC, b_dt);
    }
}