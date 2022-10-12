using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_khdt_nam : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_khdt_nam" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_khdt_nam_P_KD();", true);
                P_NAMTK_DROP();
                P_MDUT_DROP();
                P_KDT();
                P_NHAP_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_KHDT_NAM_EXCEL(namtk.Text, thangtk.Text);
            DataTable b_dt = (DataTable)a_object[0];
            bang.P_SO_CSO(ref b_dt, "cphi_lop,cphi");
            bang.P_SO_CSO(ref b_dt, "cphi_hvien");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_KHDT_NAM, TEN_BANG.NS_DT_KHDT_NAM);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_khdt_nam.xlsx", b_dt, null, "Ke_hoach_dao_tao_nam");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_MDUT_DROP()
    {
        DataTable b_dt = hts_dungchung.Fdt_CHUNG_LKE("MDUT");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        // form.P_LIST_BANG(mdut, b_dt);
    }
    private void P_KDT()
    {
        se.P_TG_LUU(this.Title, "DT_KDT", null);
    }
    private void P_NAMTK_DROP()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_KHDT_NAM_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
    }
    private void P_NHAP_DR()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NND", b_dt);

        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
        bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_THANG_TK", b_dt);
    }
}
