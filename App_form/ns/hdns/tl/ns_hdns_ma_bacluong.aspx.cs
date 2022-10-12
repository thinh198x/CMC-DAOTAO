using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_bacluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/ns_hdns_ma_bacluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_bacluong_P_KD();", true);
            P_TL();
            P_NNNGHIEP();
            MA_TL.Focus();            
        }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_BACLUONG_LKE_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG); 
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_ma_bacluong.xlsx", b_dt, null, "Danh_muc_bac_luong");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_TL()
    {
        DataTable b_dt;
        b_dt = ns_ma.Fdt_NS_HDNS_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);
    }
    private void P_NNNGHIEP()
    {
        DataTable b_dt;
        b_dt = ns_ma.Fdt_NS_HDNS_MA_NNN_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_MA_NNNGHE", b_dt);
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_tl, b_dt_nl, b_dt_nnnghiep;
        b_dt_tl = ns_ma.Fdt_NS_HDNS_MA_HTTLUONG_DR();
        b_dt_nl = ns_ma.Fdt_NS_MA_NHOMLUONG_DR_ALL();
        b_dt_nnnghiep = ns_ma.Fdt_NS_HDNS_MA_NNN_DR();
        b_dt_tl.TableName = "DATA1"; b_dt_nl.TableName = "DATA2"; b_dt_nnnghiep.TableName = "DATA3";
        b_ds.Tables.Add(b_dt_tl);
        b_ds.Tables.Add(b_dt_nl);
        b_ds.Tables.Add(b_dt_nnnghiep);
        DataTable b_dt;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" }); b_dt.TableName = "DATA4"; b_ds.Tables.Add(b_dt); 
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG); 
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_ma_bacluong.xls", b_ds, null, "ns_hdns_ma_bacluong");
    }
}