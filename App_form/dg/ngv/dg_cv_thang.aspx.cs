using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_cv_thang : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/dg_cv_thang" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = this.ResolveUrl("~/App_form/dg/dm/dg_dm_mdg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_cv_thang_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
                NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_CHUYEN_UV_NV_LKE_ALL();
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_cv_thang.xlsx", b_dt, null, "Danh_muc_dg_cv_thang");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));

        bang.P_THEM_HANG(ref b_dt, new object[] { "CG", "Chưa gửi" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] { "0", "Chờ xem xét" }, 1);
        bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Đã xem xét" }, 2);
        bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Không phê duyệt" }, 3);
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI_TK", b_dt);
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI", b_dt);

        b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_dt);

        //Xeploai
        DataTable dtb_heso_xeploai = dg.PQL_DG_CV_HT_LAY_HESO_XEPLOAI("0");
        se.P_TG_LUU(this.Title, "DT_HS_XL", dtb_heso_xeploai);
    }
}
