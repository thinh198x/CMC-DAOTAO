using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class App_form_ns_hdns_dm_cdanh_lvhoan_bai3 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
        string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/lvhoan_bt3" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
        P_NHAN_DROP();
        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_lvhoan_bai3_P_KD();", true);
        MA.Text = ht_dungchung.Fdt_AutoGenCode("PB", "LVHOAN_BAI3", "MA");
        TEN.Focus();
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_LVHOAN_BAI3_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_NL", b_dt);       
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_LVHOAN_BAI3_EXPORT(ngay_tu.Text, ngay_den.Text);
            bang.P_SO_CNG(ref b_dt, "NGAY_TL");
            bang.P_SO_CNG(ref b_dt, "NGAY_GT");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/lvhoan_bai3.xlsx", b_dt, null, "Phòng ban");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}