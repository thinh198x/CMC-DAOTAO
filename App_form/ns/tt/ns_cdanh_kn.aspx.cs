using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cdanh_kn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_cdanh_kn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cdanh_kn_P_KD();", true);
                SO_THE.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Phòng ban tìm kiếm
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PH", b_dt.Copy());

        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_CTY", b_dt.Copy());

        se.P_TG_LUU(this.Title, "DT_PHONG", null);
        se.P_TG_LUU(this.Title, "DT_BOPHAN", null);
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_CDANH_KN();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_het_hl"); 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CDANH_KN, TEN_BANG.NS_CDANH_KN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cdanh_kn.xlsx", b_dt, null, "Chuc_danh_kiem_nhiem");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}