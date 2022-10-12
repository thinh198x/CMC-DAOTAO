using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_ds_thuchien_dgia : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dg_ds_thuchien_dgia" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_ds_thuchien_dgia_P_KD();", true);
                P_NHAN_DROP();
                //NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    //protected void nhap_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        object[] o_abj = dg.Faobj_dg_ds_thuchien_dgia_LKE(1, 1000, Anncdanh.Value, Ancdanh.Value);
    //        DataTable b_dt = (DataTable)o_abj[1];
    //        b_dt.TableName = "DATA";
    //        // ghi log
    //        hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.dg_ds_thuchien_dgia, TEN_BANG.dg_ds_thuchien_dgia);
    //        Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_ds_thuchien_dgia.xlsx", b_dt, null, "Danh_muc_dg_ds_thuchien_dgia");
    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}

    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_CTY_QLCT", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CTY_QLCD", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CTY", b_dt.Copy());

        //lấy nhóm chức danh
        b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM_CDANH", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_NH_CHUCDANH_TK", b_dt.Copy());

        //Lấy chức danh
        object[] a_obj = dg.Fdt_CDANH_DR(" ", 1, 100);
        b_dt = (DataTable)a_obj[1];
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_CDANH_TK", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CDANH", b_dt.Copy());

        b_dt = sdg.Fdt_DG_DM_MA_KDG_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
    }
}
