using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class App_form_ns_ma_tin_bai2 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/daotao-2022/TINTC/Bai2/Bai2_TinTC" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "P_KD();", true);
            MA.Text = ht_dungchung.Fdt_AutoGenCode("CD", "DAOTAO_BAI2", "MA");
            TEN.Focus();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = null;
        DataTable b_ncd = null;
        //Nganh nghe
        //DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA();
        //se.P_TG_LUU(this.Title, "DT_NN", b_dt);
        se.P_TG_LUU(this.Title, "DT_CM", null);
        //Ngach luong
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_NL", b_dt);
        se.P_TG_LUU(this.Title, "DT_CB", null);
        //trang thai
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Ngừng áp dụng" });
        form.P_LIST_BANG(tt, b_dt);
        //Nhóm chức danh
        b_ncd = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref b_ncd, new object[] { "BDH", "Ban Điều Hành" });
        bang.P_THEM_HANG(ref b_ncd, new object[] { "QL", "Quản Lý" });
        bang.P_THEM_HANG(ref b_ncd, new object[] { "NV", "Nhân Viên" });
        form.P_LIST_BANG(ma_nnn, b_ncd);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_TIN_BAI2_EXPORT(c_ma_nnn.Value, macd.Text, tencd.Text);
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_nnn", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "NV", "Nhân Viên");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_cdanh.xlsx", b_dt, null, "Danh_muc_vtcd");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}