using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_hvien_tgian : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_hvien_tgian" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_hvien_tgian_P_KD();", true);
                P_NHAP_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAP_DR()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_KHDT_NAM_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAMTK", b_dt);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
        b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_KDT", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_KHOA_DT_TK", b_dt.Copy());        
    //    b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
    //    bang.P_THEM_TRANG(ref b_dt, 1, 0);
    //    se.P_TG_LUU(this.Title, "DT_NND", b_dt.Copy());

    //    se.P_TG_LUU(this.Title, "DT_NND_DV", null);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_hv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO");
            b_dt_hv.TableName = "HOCVIEN";
            b_ds.Tables.Add(b_dt_hv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_DT_HVIEN_TGIAN, TEN_BANG.NS_DT_HVIEN_TGIAN);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_dt_hvien_tgian.xls", b_ds, null, "NS_DT_HVIEN_TGIAN" + DateTime.Now.Second);
        }
        catch (Exception) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Faobj_NS_DT_HVIEN_TGIAN_LKE_ALL(nam_tk.Text, thang_an.Value, kdt_an.Value, lop_dt_an.Value);
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_HVIEN_TGIAN, TEN_BANG.NS_DT_HVIEN_TGIAN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ds_hv.xlsx", b_dt, null, "Danh_sach_hoc_vien_tham_gia_khoa_dao_tao");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}