using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_cn_dkc_connho : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_cn_dkc_connho" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                se.se_nsd b_se = new se.se_nsd(); string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_cn_dkc_connho_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();

            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    private void P_NHAN_DROP()
    {
        DataTable b_ca_lv = tl_ma.Fdt_NS_TL_TLAP_LAMCA_DR();
        se.P_TG_LUU(this.Title, "DT_CALV", b_ca_lv.Copy());
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_dt_macc_nghi;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO");
        bang.P_DOI_TENCOL(ref b_dt_nv, "MA", "PHONG");
        b_dt_nv.TableName = "DATA";
        //b_dt_macc_nghi = ns_qt.Fdt_ns_cc_cn_dkc_connho_SC(null);
        b_dt_macc_nghi = tl_ma.Fdt_CC_MA_CC_DR2("N");
        b_dt_macc_nghi.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt_macc_nghi);
        // ghi log
        //hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.ns_cc_cn_dkc_connho, TEN_BANG.ns_cc_cn_dkc_connho);
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_cc_cn_dkc_connho.xls", b_ds, null, "quan_ly_dang_ky_nghi");
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_qt.Fdt_NS_CC_CN_DKC_CONNHO_LKE(so_the_tk.Text, ten_tk.Text, NGAYD_TK.Text, NGAYC_TK.Text, 1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            // ghi log
            //hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.ns_cc_cn_dkc_connho, TEN_BANG.ns_cc_cn_dkc_connho);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_cn_dkc_connho_export.xlsx", b_dt, null, "dang_ky_ca_connho");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}