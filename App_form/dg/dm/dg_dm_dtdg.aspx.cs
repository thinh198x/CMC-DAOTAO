using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_dm_dtdg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_dtdg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_dtdg_P_KD();", true);
                NAM.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //lấy nhóm chức danh
        DataTable b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM_CDANH", b_dt.Copy());
        //lây cấp bậc
        DataTable b_dt2 = dg.Fdt_CAPBAC_DR();
        se.P_TG_LUU(this.Title, "DT_CAPBAC", b_dt2.Copy());
        //lấy năm
        //DataRow drRow;
        DataTable b_dt1 = sdg.Fdt_DG_DM_MA_KDG_NAM();
        //drRow = b_dt1.NewRow();
        //drRow["NAM"] = "0";
        //drRow["NAM"] = "";
        //b_dt1.Rows.InsertAt(drRow, 0);
        //form.P_DROP_BANG(NAM, b_dt1);

        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1);
    }
    //protected void excel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable b_dt = ns_td.Fdt_dg_dm_dtdg_EXPORT();
    //        b_dt.TableName = "DATA";
    //        bang.P_SO_CNG(ref b_dt, "ngaycan_ns");
    //        Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_dtdg.xlsx", b_dt, null, "Chuc_danh_kiem_nhiem");
    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}
}