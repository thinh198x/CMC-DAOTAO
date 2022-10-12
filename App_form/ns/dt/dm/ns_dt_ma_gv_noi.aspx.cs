using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_ma_gv_noi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_gv_noi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_gv_noi_P_KD('');", true);
                P_DROP();
                P_MA_CHA();
                //P_KDT();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_DROP()
    {
        DataTable b_dt;
        b_dt = hts_dungchung.Fdt_DT_CHUNG_LKE("CGV");
        b_dt = hts_dungchung.Fdt_DT_CHUNG_LKE("LGV");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        //form.P_LIST_BANG(cap_gvien, b_dt);
        form.P_LIST_BANG(cap_gvien_tk, b_dt);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        //form.P_LIST_BANG(loai_gvien, b_dt);
        form.P_LIST_BANG(loai_gvien_tk, b_dt);
    }
    private void P_MA_CHA()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_MA_LVCHA_LKE_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_MA_CHA", b_dt);
    }
    private void P_KDT()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        se.P_TG_LUU(this.Title, "DT_KDT", b_dt);
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = ns_dt.Fdt_NS_DT_MA_GV_NOI_LKE_ALL(tt_an.Text, cgv_an.Text, lgv_an.Text);
            DataTable b_dt = (DataTable)a_object[0];
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_DT_MA_GV_NOI, TEN_BANG.NS_DT_MA_GV_NOI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ma_gv_noi.xlsx", b_dt, null, "Giang_vien_dao_tao_noi_bo");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
