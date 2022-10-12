using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_dm_mdg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_mdg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_dm_mdg_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        //lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_DG_DM_MA_KDG_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_dt);

        //lấy nhóm chức danh
        b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM_CDANH", b_dt.Copy());

        //lấy chức danh
        object[] a_obj = dg.Fdt_CDANH_DR(" ", 1, 100);
        b_dt = (DataTable)a_obj[1];
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_CDANH_TK", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CDANH", b_dt.Copy());
        //lấy nhóm câu hỏi
        b_dt = dg.Fdt_DG_DM_MA_NHOM_CAUHOI();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NHOM_CAUHOI", b_dt);

        b_dt = dg.Fdt_DG_DM_MA_DTUONG_DG();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_DG", b_dt);
        se.P_TG_LUU(this.Title, "DT_DG_TK", b_dt);
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        //DataSet b_ds = new DataSet();
        //DataTable b_dt_nv, b_dt;
        //b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        //b_dt_nv.TableName = "DATA";
        //b_dt = ns_ma.Fdt_NS_CC_HSO_LTHEM_DR();
        //b_dt.TableName = "DATA1";
        //b_ds.Tables.Add(b_dt_nv);
        //b_ds.Tables.Add(b_dt);

        DataSet b_ds = new DataSet();
        DataTable b_dt;

        //lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_DG_DM_MA_KDG_NAM();
        b_dt.TableName = "DATA_NAM";
        b_ds.Tables.Add(b_dt);

        //lấy kỳ đánh giá 
        b_dt = dg.Fdt_DG_DM_DTDG_KDG_NHL_IMPORT("");
        b_dt.TableName = "DATA_KY_DG";
        b_ds.Tables.Add(b_dt);

        //lấy nhóm chức danh
        b_dt = dg.Fdt_NHOM_CDANH_DR();
        b_dt.TableName = "DATA_NHOM_CDANH";
        b_ds.Tables.Add(b_dt);

        //lấy chức danh
        b_dt = dg.Fdt_CDANH_IMPORT();
        b_dt.TableName = "DATA_CDANH";
        b_ds.Tables.Add(b_dt);

        //lấy đối tượng đánh giá
        b_dt = dg.Fdt_DG_DM_MA_DTUONG_DG();
        b_dt.TableName = "DATA_DT_DG";
        b_ds.Tables.Add(b_dt);

        //lấy nhóm câu hỏi
        b_dt = dg.Fdt_DG_DM_MA_NHOM_CAUHOI();
        b_dt.TableName = "DATA_NHOM_CAUHOI";
        b_ds.Tables.Add(b_dt);

        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_MAU, TEN_FORM.DG_DM_MDG, TEN_BANG.DG_DM_MDG);
        Excel_dungchung.ExportTemplate("Templates/importmau/dg_dm_mdg.xlsx", b_ds, null, "dg_dm_mdg");
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_DG_DM_MDG_LKE_ALL();
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_DM_MDG, TEN_BANG.DG_DM_MDG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_dm_mdg.xlsx", b_dt, null, "Thiet_lap_mau_danh_gia");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}