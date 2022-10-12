using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_cbnv_ct_kpi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/cbnv_ct_kpi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;  
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cbnv_ct_kpi_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
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

        ////lấy năm trong kỳ đánh giá
        b_dt = sdg.Fdt_NS_DG_MA_KDG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);


        DataTable b_dt1 = dg.Fdt_DG_DM_DTDG_KDG_DG_NHL("");
        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_KY_DG1", b_dt1);

        // Nhom tieu chi
        DataTable b_dt2 = dg.Fdt_NS_DG_MA_TCHI_LKE_TATCA();
        bang.P_BO_COT(ref b_dt2, new string[] { "ma_dvi", "tt", "gchu", "ng_bdau", "ng_kthuc", "ngay_nh", "nsd", "idvung", "sott", "ma", "ten" });
        bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom", "ma");
        bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom_ten", "ten");
        se.P_TG_LUU(this.Title, "DT_NTC", b_dt2);
    }
    //private string P_SOTHE(string b_nsd)
    //{
    //    string b_so_the = "";
    //    DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
    //    if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
    //    return b_so_the;
    //}
}