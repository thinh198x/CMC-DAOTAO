using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tt_bh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
            string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
            string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_tt_bh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tt_bh_P_KD();", true);
            SO_THE.Focus();
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_ma.Fdt_NS_MA_BV_LKE_ALL();
            b_dt_bv.TableName = "DATA1";
            b_ds.Tables.Add(b_dt_bv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_tt_bh.xls", b_ds, null, "TT_BH" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
    protected void export_excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_cd.Fdt_NS_TT_BH_LKE_ALL();
            bang.P_SO_CTH(ref b_dt_bv, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_SO_CNG(ref b_dt_bv, "ngay_cap,ngay_hl,ngay_bangiaothe");
            bang.P_SO_CSO(ref b_dt_bv, "luong_bh,tg_dongbh_truoc");

            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhxh", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhxh", "01/3000", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhyt", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhyt", "01/3000", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhtn", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhtn", "01/3000", "");

            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhxh", "/", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhxh", "/", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhyt", "/", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhyt", "/", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhtn", "/", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhtn", "/", "");

            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "DC", "Đã cấp");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "CC", "Chưa cấp");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "LDG", "Lao động giữ");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_the", "DSC", "Đang sử dụng");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_the", "k", "Khác");

            b_dt_bv.TableName = "DATA";
            b_ds.Tables.Add(b_dt_bv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tt_bh.xlsx", b_ds, null, "TT_BH" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_cd.Fdt_NS_TT_BH_LKE_ALL();
            bang.P_SO_CTH(ref b_dt_bv, "tuthang_bhxh,denthang_bhxh,tuthang_bhyt,denthang_bhyt");
            bang.P_SO_CNG(ref b_dt_bv, "ngay_cap,ngay_hl,ngay_bangiaothe");
            bang.P_SO_CSO(ref b_dt_bv, "luong_bh,tg_dongbh_truoc");

            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhxh", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhxh", "01/3000", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhyt", "01/3000", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhyt", "01/3000", "");
           

            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhxh", "/", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhxh", "/", "");
            bang.P_THAY_GTRI(ref b_dt_bv, "tuthang_bhyt", "/", ""); bang.P_THAY_GTRI(ref b_dt_bv, "denthang_bhyt", "/", "");
           

            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "DC", "Đã cấp");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "CC", "Chưa cấp");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_so", "LDG", "Lao động giữ");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_the", "DSC", "Đang sử dụng");
            bang.P_THAY_GTRI(ref b_dt_bv, "tinhtrang_the", "k", "Khác");

            b_dt_bv.TableName = "DATA";
            b_ds.Tables.Add(b_dt_bv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TT_BH, TEN_BANG.NS_TT_BH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tt_bh.xlsx", b_ds, null, "thong_tin_bao_hiem" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }

}
