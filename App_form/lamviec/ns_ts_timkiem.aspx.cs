using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ts_timkiem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/sns_ts.asmx"));
                string b_s = this.ResolveUrl("~/App_form/lamviec/ns_ts_timkiem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ts_timkiem_KD();", true);
                //DataTable b_dt = ns_ts.Fdt_MA_DU_AN();
                //form.P_DROP_BANG(DU_AN, b_dt);
                DataTable b_dt = ns_ts.Fdt_MA_NV_QL();
                form.P_DROP_BANG(ng_nhan, b_dt);
                bang.P_THEM_HANG(ref b_dt, new object[] { "TC", "Tất cả" }, 0);
                form.P_DROP_BANG(NG_NHAN_TK, b_dt);
                form.P_DROP_BANG(uu_tien, ns_ts.Fdt_TS_DO_UU_TIEN_LKE());
                form.P_DROP_BANG(nhom_viec, ns_ts.Fdt_TS_MA_LOAI_CV_LKE());
                form.P_DROP_BANG(skill, ns_ts.Fdt_NS_TS_SKILL_LKE());
                form.P_DROP_BANG(vi_tri, ns_ts.Fdt_TS_VI_TRI_LKE());
                b_dt = ns_ts.Fdt_MA_DU_AN();
                bang.P_THEM_HANG(ref b_dt, new object[] { "NH", "Ngắn hạn" }, 0);
                form.P_DROP_BANG(ma_du_an, b_dt);
                ngayd.Text = DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy");
                ngayc.Text = DateTime.Now.ToString("dd/MM/yyyy");
               
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
