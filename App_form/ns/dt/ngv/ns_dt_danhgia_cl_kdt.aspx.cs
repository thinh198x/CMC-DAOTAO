using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_danhgia_cl_kdt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_danhgia_cl_kdt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_danhgia_cl_kdt_P_KD();", true);
                P_KDT(); P_NHAP_DR(); P_NAMTK_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
    private void P_KDT()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        se.P_TG_LUU(this.Title, "DT_KDT", b_dt);
    }
    private void P_NHAP_DR()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NND", b_dt);
    }
    private void P_NAMTK_DROP()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_KHDT_NAM_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
    }
}