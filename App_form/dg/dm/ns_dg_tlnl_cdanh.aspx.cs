using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_tlnl_cdanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/ns_dg_tlnl_cdanh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_tlnl_cdanh_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Đơn vị tìm kiếm
        DataTable b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NCD", b_dt.Copy());

        //lấy năm
        DataTable b_dt1 = sdg.Fdt_DG_DM_MA_KDG_NAM();

        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = dg.Faobj_NS_DG_TLNL_CDANH_LKE(0, 0);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay_ad"); ;
            b_dt.TableName = "DATA";
            //bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            //bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DG_TLNL_CDANH, TEN_BANG.NS_DG_TLNL_CDANH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dg_tlnl_cdanh.xlsx", b_dt, null, "Danh_sach tieu chi danh gia theo chuc danh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}