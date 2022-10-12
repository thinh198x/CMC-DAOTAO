using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;
using System.Globalization;

public partial class f_ns_ma_phucloi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/ns_ma_phucloi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_phucloi_P_KD('');", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("PL", "NS_MA_PHUCLOI", "MA");
                //string date = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                //NGAY_D.Text = date;
                //ngay_c.Text = DateTime.ParseExact(DateTime.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddMonths(1).ToString("dd/MM/yyyy");
                ma.Focus();
                P_NNGHE_DROP();                
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NNGHE_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_HDNS_MA_LVCDANH_DR();
        se.P_TG_LUU(this.Title, "DT_MA_LVCDANH", b_dt.Copy());

        b_dt = ns_hdns.Fdt_NS_HDNS_CDANH_DROP();
        se.P_TG_LUU(this.Title, "DT_MA_CDANH", b_dt.Copy());
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_PHUCLOI_LKE_ALL();
            bang.P_SO_CNG(ref b_dt, "NGAY_D");
            bang.P_SO_CNG(ref b_dt, "NGAY_C");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_PHUCLOI, TEN_BANG.NS_MA_PHUCLOI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_phucloi.xlsx", b_dt, null, "Danh_muc_phucloi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
