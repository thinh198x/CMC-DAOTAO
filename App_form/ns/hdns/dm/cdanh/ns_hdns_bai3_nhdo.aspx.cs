using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Cthuvien;

public partial class App_form_ns_hdns_dm_cdanh_ns_hdns_bai3_nhdo : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_bai3_nhdo" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_bt3_nhdo_P_KD();", true);
            ma.Text = ht_dungchung.Fdt_AutoGenCode("PB", "NHDO_BAI3", "MA");
            ten.Focus();
        }
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt, b_dt_nnghe, b_dt_cmon, b_dt_nghenghiep, b_dt_capbac;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" }); b_dt.TableName = "DATA";
        b_dt_nnghe = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); b_dt_nnghe.TableName = "DATA1";
        b_dt_cmon = ns_hdns.Fdt_NS_HDNS_MA_CM_DROP(); b_dt_cmon.TableName = "DATA2";
        b_dt_nghenghiep = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA(); b_dt_nghenghiep.TableName = "DATA3";
        b_dt_capbac = ns_hdns.Fdt_NS_HDNS_MA_CBNN_DROP(); b_dt_capbac.TableName = "DATA4";
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dt_nnghe);
        b_ds.Tables.Add(b_dt_cmon);
        b_ds.Tables.Add(b_dt_nghenghiep);
        b_ds.Tables.Add(b_dt_capbac);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
        Excel_dungchung.ExportTemplate("Templates/importhdns/hd_ma_cdanh_ktao.xls", b_ds, null, "hd_ma_cdanh_ktao");
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NHDO_BT3_DROP();
        se.P_TG_LUU(this.Title, "DT_TT", b_dt);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NHDO_BAI3_EXPORT(ngay_tu.Text, ngay_den.Text);
            bang.P_SO_CNG(ref b_dt, "NGAY_TL");
            bang.P_SO_CNG(ref b_dt, "NGAY_GT");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/nhdo_bai3.xlsx", b_dt, null, "Danh_muc_phong_ban");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}