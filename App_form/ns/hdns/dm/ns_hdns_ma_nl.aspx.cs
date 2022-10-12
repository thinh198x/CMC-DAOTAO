using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_nl : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/ns_hdns_ma_nl" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_nl_P_KD();", true);
                MA_NHOM.Focus();
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NHOM_NL_XEM();
        se.P_TG_LUU(this.Title, "NHOM_NL", b_dt);
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });b_dt.TableName = "DATA";
        DataTable b_dtNNL = se.Fdt_TG_TRA(this.Title, "NHOM_NL");
        b_dtNNL.TableName = "DATA1";
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dtNNL);        
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_ma_nl_mau.xls", b_ds, null, "ns_hdns_ma_nl_mau_ktao");
    }
    //protected void FileMau_Click(object sender, EventArgs e)
    //{
    //    DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
    //    b_dt.TableName = "DATA";
    //    DataTable b_dtNNL = se.Fdt_TG_TRA(this.Title, "NHOM_NL");
    //    b_dtNNL.TableName = "DATA1";
    //    DataSet b_ds = new DataSet();
    //    b_ds.Tables.Add(b_dt);
    //    b_ds.Tables.Add(b_dtNNL);
    //   // Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_ma_nl_mau.xls", b_ds, null, "ns_hdns_ma_nl_mau");
    //    Excel_dungchung.ExportExcel("Templates\\importhdns\\ns_hdns_ma_nl_mau.xls", b_ds, null, "hdns_mota_cv_ktao");
    //}
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NL_EXCEL();
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_ma_nl.xlsx", b_dt, null, "Danh_muc_nang_luc");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
