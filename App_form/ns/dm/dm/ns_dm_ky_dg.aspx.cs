using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dm_ky_dg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            { 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dm/sns_dm.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dm/dm/ns_dm_ky_dg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dm_ky_dg_P_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
    //protected void excel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable b_dt = ns_td.Fdt_dm_ky_dg_EXCEL();
    //        b_dt.TableName = "DATA";
    //        bang.P_SO_CSO(ref b_dt, "luong_cb,thunhap");
    //        bang.P_SO_CNG(ref b_dt, "ngayd");
    //        Excel_dungchung.ExportTemplate("Templates/ExportMau/dm_ky_dg.xlsx", b_dt, null, "Danh_sach_thong_tin_ung_vien");
    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dm.Fdt_NS_DM_KY_DG_EXCEL();
            b_dt.TableName = "DATA"; 
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dm_ky_dg.xlsx", b_dt, null, "Danh_muc_ky_danh_gia");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}