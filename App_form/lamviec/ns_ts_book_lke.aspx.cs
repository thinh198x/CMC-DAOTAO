using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ts_book_lke : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/sns_ts.asmx"));
                string b_s = this.ResolveUrl("~/App_form/lamviec/ns_ts_book_lke" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/lamviec/ns_ts_dg.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ts_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                tu_ngay_tk.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
				den_ngay_tk.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable b_dt = ns_ts.Fdt_MA_DU_AN();
                bang.P_THEM_HANG(ref b_dt, new object[] { "NH", "Ngắn hạn" }, 0);
                form.P_DROP_BANG(ma_du_an, b_dt);
                b_dt = ns_ts.Fdt_MA_NV_QL();
                form.P_DROP_BANG(ng_nhan, b_dt);
                bang.P_THEM_HANG(ref b_dt, new object[] { "TC", "Tất cả" }, 0);
                form.P_DROP_BANG(uu_tien, ns_ts.Fdt_TS_DO_UU_TIEN_LKE());
                form.P_DROP_BANG(nhom_viec, ns_ts.Fdt_TS_MA_LOAI_CV_LKE());
                form.P_DROP_BANG(skill, ns_ts.Fdt_NS_TS_SKILL_LKE());
				b_dt = ns_ts_gv.Fdt_MA_TT();
                bang.P_THEM_HANG(ref b_dt, new object[] { "EN", "Tất cả" }, 0);
                form.P_DROP_BANG(vi_tri, ns_ts.Fdt_TS_VI_TRI_LKE());
                DataTable b_dt_se = new DataTable(); b_dt_se.Columns.Add("id", typeof(string)); b_dt_se.Columns.Add("path", typeof(string));
                bang.P_THEM_HANG(ref b_dt_se, new object[] { "0", "" }, 0); se.P_KQ_LUU("file", "file", b_dt_se);
                if (se.Fs_DUYET() == "INTERNETEXPLORER") kthuoc.Value = "1390,780";
                else kthuoc.Value = "1350,770";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    public static DataTable Fdt_kq()
    {
        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));
        bang.P_THEM_HANG(ref b_dt, new object[] { "HT", "Hoàn thành" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] { "HB", "Hủy bỏ" }, 1);
        bang.P_THEM_HANG(ref b_dt, new object[] { "DD", "Dở dang" }, 2);
        return b_dt;
    }
    public static DataTable Fdt_dg()
    {
        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));
        bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Tốt" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] { "K", "Khá" }, 1);
        bang.P_THEM_HANG(ref b_dt, new object[] { "B", "Trung bình" }, 2);
        bang.P_THEM_HANG(ref b_dt, new object[] { "Y", "Yếu" }, 3);
        return b_dt;
    }
    public static DataTable Fdt_loai_tk()
    {
        DataTable b_dt = new DataTable();
        b_dt.Columns.Add("MA", typeof(string));
        b_dt.Columns.Add("TEN", typeof(string));
        bang.P_THEM_HANG(ref b_dt, new object[] { "TC", "Tât cả" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] { "G", "Giao" }, 1);
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Nhận" }, 2);
        return b_dt;
    }

}
