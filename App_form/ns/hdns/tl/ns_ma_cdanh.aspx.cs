using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_cdanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/ns_ma_cdanh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_cdanh_P_KD();", true);
            MA_NNGHE.Focus(); 
        } 
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt, b_dt_nnghe,b_dt_cmon,b_dt_nghenghiep,b_dt_capbac;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });b_dt.TableName = "DATA";
        b_dt_nnghe = ns_ma.Fdt_HD_MA_NNGHE_LKE_MATEN(); b_dt_nnghe.TableName = "DATA1";
        b_dt_cmon = ns_ma.Fdt_HD_MA_CMON_MATEN(); b_dt_cmon.TableName = "DATA2";
        b_dt_nghenghiep = ns_hdns.Fdt_HD_MA_NNGHIEP_MATEN();b_dt_nghenghiep.TableName = "DATA3";
        b_dt_capbac = ns_hdns.Fdt_HD_MA_BNNGHE_MATEN(); b_dt_capbac.TableName = "DATA4";
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dt_nnghe); 
        b_ds.Tables.Add(b_dt_cmon);
        b_ds.Tables.Add(b_dt_nghenghiep);
        b_ds.Tables.Add(b_dt_capbac);
        Excel_dungchung.ExportTemplate("Templates/importhdns/hd_ma_cdanh_ktao.xls", b_ds, null, "hd_ma_cdanh_ktao");
    }

    private void P_NHAN_DROP()
    {
        //Nganh nghe
        DataTable b_dt = ns_ma.Fdt_HD_MA_NNGHE_LKE_MATEN();
        se.P_TG_LUU(this.Title, "DT_NN", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CM", null);
        //Ngach luong
        b_dt = ns_ma.Fdt_NS_MA_NL_LKE_ALL();
        se.P_TG_LUU(this.Title, "DT_NL", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CB", null);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_MA_CDANH_LKE_ALL(MA_NNGHE.Text, MA_CMON.Text, MA_NNNGHE.Text, MA_CAPBAC.Text);
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_cdanh.xlsx", b_dt, null, "Danh_muc_chuyen_mon");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
