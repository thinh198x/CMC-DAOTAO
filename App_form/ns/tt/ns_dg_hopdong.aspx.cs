using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_hopdong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_dg_hopdong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_hopdong_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_hd = ns_ma.Fdt_NS_MA_LHD_DR();
        bang.P_THEM_HANG(ref b_hd, new object[] { "TATCA", "Tất cả" }, 0);
        se.P_TG_LUU(this.Title, "DT_HD", b_hd.Copy());

         b_hd = ns_ma.Fdt_PNS_HS_MA_CHUNG_DR("KQHD");
        se.P_TG_LUU(this.Title, "DT_KQ", b_hd.Copy());
    }

    [Obsolete]
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_dt_macc_nghi;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO");
        bang.P_DOI_TENCOL(ref b_dt_nv, "MA", "PHONG");
        b_dt_nv.TableName = "DATA";
        //b_dt_macc_nghi = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_SC(null);
        b_dt_macc_nghi = tl_ma.Fdt_CC_MA_CC_DR2("N");
        b_dt_macc_nghi.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt_macc_nghi);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_CC_THONGTIN_NGHI, TEN_BANG.NS_CC_THONGTIN_NGHI);
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_dg_hopdong.xls", b_ds, null, "quan_ly_dang_ky_nghi");
    }

    protected void nhap_Click(object sender, EventArgs e)
    {

    }
}