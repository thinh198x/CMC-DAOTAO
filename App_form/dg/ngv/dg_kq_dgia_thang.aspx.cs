using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_dg_kq_dgia_thang : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/dg_kq_dgia_thang" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                //b_s = this.ResolveUrl("~/App_form/ns/qt/ns_ds_den" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                //ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_kq_dgia_thang_P_KD();", true);
                P_Phong_LKE();
                DataTable b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_Phong_LKE()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_DS_DEN_DVI", b_dt);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            //DataSet b_ds = ns_qt.Fds_Fs_NS_DS_DEN_EXCEL(so_the.Text, hoten.Text, ma_phong.Value);
            //DataTable b_dt = b_ds.Tables[0];
            //b_dt.TableName = "DATA";
            //bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_nop,ngaynghi");
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "", "Chưa phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "1", "Phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "0", "Chưa phê duyệt");
            //Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_kq_dgia_thang.xlsx", b_ds, null, "DanhSachDen");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void excel_mau_Click(object sender, EventArgs e)
    {
        DataTable b_nam_kydg = new DataTable();
        bang.P_THEM_COL(ref b_nam_kydg, new string[] { "nam", "ky_dg", "ten_ky_dg" });
        bang.P_THEM_HANG(ref b_nam_kydg, new string[] { "nam", "ky_dg", "ten_ky_dg" }, new string[] { NAM.Text, an_kydg.Value, KY_DG.Text });
        b_nam_kydg.TableName = "DATA1";
        DataTable b_nam1 = b_nam_kydg.Copy();
        b_nam1.TableName = "DATA";
        DataSet ds = new DataSet();
        ds.Tables.Add(b_nam1);
        ds.Tables.Add(b_nam_kydg);
        hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
        Excel_dungchung.ExportTemplate("Templates/importmau/dg_kq_dgia_thang.xlsx", ds, null, "dg_kq_dgia_thang");
    }
    protected void excel_ds_Click(object sender, EventArgs e)
    {
        DataTable b_nam_kydg = new DataTable();
        bang.P_THEM_COL(ref b_nam_kydg, new string[] { "nam", "ky_dg", "ten_ky_dg" });
        bang.P_THEM_HANG(ref b_nam_kydg, new string[] { "nam", "ky_dg", "ten_ky_dg" }, new string[] { NAM.Text, an_kydg.Value, KY_DG.Text });
        b_nam_kydg.TableName = "DATA1";
        DataTable b_ds_nv = dg.Fds_Fs_DG_KQ_DGIA_THANG_DS_CDG(NAM.Text, an_kydg.Value, an_phong.Value);
        b_ds_nv.TableName = "DATA2";
        bang.P_SO_CNG(ref b_ds_nv, "NGAYD");
        DataSet ds = new DataSet();
        ds.Tables.Add(b_ds_nv);
        ds.Tables.Add(b_nam_kydg);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.LAY_DS, TEN_FORM.DG_KQ_DGIA_THANG, TEN_BANG.DG_KQ_DGIA_THANG);
        Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_kq_dgia_thang_ds_cdg.xlsx", ds, null, "dg_kq_dgia_thang");
    }
}
