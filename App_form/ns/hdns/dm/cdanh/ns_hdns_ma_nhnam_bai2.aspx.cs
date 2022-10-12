using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_nhnam_bai2 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_ma_nhnam_bai2" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_nhnam_bai2_P_KD();", true);
            MA.Text = ht_dungchung.Fdt_AutoGenCode("CD", "NHNAM_BAI2", "MA");
            TEN.Focus(); 
        } 
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt, b_dt_nnghe,b_dt_cmon,b_dt_nghenghiep,b_dt_capbac;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });b_dt.TableName = "DATA";
        b_dt_nnghe = ns_hdns.Fdt_NS_HDNS_MA_NN_DROP_MA(); b_dt_nnghe.TableName = "DATA1";
        b_dt_cmon = ns_hdns.Fdt_NS_HDNS_MA_CM_DROP(); b_dt_cmon.TableName = "DATA2";
        b_dt_nghenghiep = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();b_dt_nghenghiep.TableName = "DATA3";
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
        DataTable b_dt = null;
        DataTable b_ncd = null;
        DataTable b_filterncd = null;
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
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        form.P_LIST_BANG(tt, b_dt);
        //Nhóm chức danh
        b_ncd = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref b_ncd, new object[] { "BDH", "Ban Điều Hành" });
        bang.P_THEM_HANG(ref b_ncd, new object[] { "QL", "Quản Lý" });
        bang.P_THEM_HANG(ref b_ncd, new object[] { "NV", "Nhân Viên" });
        form.P_LIST_BANG(MA_NNN, b_ncd);
        //Lọc nhóm chức danh
        b_filterncd = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        bang.P_THEM_HANG(ref b_filterncd, new object[] { "", "Tất cả" });
        bang.P_THEM_HANG(ref b_filterncd, new object[] { "BDH", "Ban Điều Hành" });
        bang.P_THEM_HANG(ref b_filterncd, new object[] { "QL", "Quản Lý" });
        bang.P_THEM_HANG(ref b_filterncd, new object[] { "NV", "Nhân Viên" });
        form.P_LIST_BANG(filter_ma_nnn, b_filterncd);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NHNAM_BAI2_LKE_ALL(c_ma_nnn.Value, macd.Text, tencd.Text);
            
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");

            bang.P_COPY_COL(ref b_dt, "ten_nnn", "ma_nnn");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "BDH", "Ban Điều Hành");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "QL", "Quản Lý");
            bang.P_THAY_GTRI(ref b_dt, "ten_nnn", "NV", "Nhân Viên");
            b_dt.TableName = "DATA";

            DataSet b_ds_ex = new DataSet();
            b_ds_ex.Tables.Add(b_dt.Copy());

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_cdanh.xlsx", b_dt, null, "Danh_muc_vtcd");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
