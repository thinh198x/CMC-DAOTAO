using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_ngv_nbdg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/dg_ngv_nbdg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_ngv_nbdg_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        b_dt = new DataTable();
        b_dt = dg.Fdt_MA_DVI_NBDG();
        se.P_TG_LUU(this.Title, "DT_DONVI", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_DONVI_TK", b_dt.Copy());

        //lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_DG_DM_MA_KDG_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_dt);

        //drop tìm kiếm trạng thái
        DataTable b_dt1 = new DataTable();
        b_dt1.Columns.Add("MA", typeof(string));
        b_dt1.Columns.Add("TEN", typeof(string));
        bang.P_THEM_HANG(ref b_dt1, new object[] { "CG", "Chưa gửi" }, 0);
        bang.P_THEM_HANG(ref b_dt1, new object[] { "DG", "Đã gửi" }, 1);
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI_TK", b_dt1);
    }
}