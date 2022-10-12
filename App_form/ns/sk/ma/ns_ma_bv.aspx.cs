using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_bv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/sk/ma/ns_ma_bv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_bv_P_KD();", true);
                MA.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_TT_DR();
        se.P_TG_LUU(this.Title, "DT_TTP", b_dt.Copy());
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_BV_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "N", "Ngừng áp dụng");
            b_dt.TableName = "DATA";
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_BV, TEN_BANG.NS_MA_BV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_bv.xlsx", b_dt, null, "Noi_dang_ky_kham_chua_benh");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
