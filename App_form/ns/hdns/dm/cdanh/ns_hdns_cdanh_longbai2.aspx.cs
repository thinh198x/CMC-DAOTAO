using Cthuvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_form_ns_hdns_dm_cdanh_ns_hdns_cdanh_longbai2 : fmau
{
    #region Main
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_longbai2" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_cdanhlongbai2_P_KD();", true);
            MA.Text = ht_dungchung.Fdt_AutoGenCode("CB", "NS_MA_CDANH_LONGBAI2", "MA");
            TEN.Focus();
        }
    }
    #endregion

    #region Check danh sách nhóm chức danh, đổi trạng thái
    private void P_NHAN_DROP()
    {
        DataTable b_dt = null;
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNNLONGBAI2_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_TT", b_dt);
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        form.P_LIST_BANG(tt, b_dt);
    }
    #endregion

    #region Xuất excel động
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nnn = ma_nnx.Value;
            string b_tencd = tencd.Text;
            string b_macd = macd.Text;
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_VTCDLONG_EXPORT1(b_nnn, b_macd, b_tencd);
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            bang.P_COPY_COL(ref b_dt, "ten_nnn", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "BTGÐ", "Ban Tổng Giám Đốc");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "BGÐ", "Ban Giám Đốc");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "QLCC", "Quản lý cấp cao");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "QLCT", "Quản lý cấp trung");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "TN", "Trưởng nhóm");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_CDANH_LONGBAI2, TEN_BANG.NS_MA_CDANH_LONGBAI2);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_cdanh.xlsx", b_dt, null, "Danh_muc_vtcd");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
#endregion