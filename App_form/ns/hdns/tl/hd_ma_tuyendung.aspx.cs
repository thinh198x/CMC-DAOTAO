using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
using System.Globalization;

public partial class f_hd_ma_tuyendung : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/hd_ma_tuyendung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hd_ma_tuyendung_P_KD();", true);
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANH_TK_LKE("", "A","");
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_DOI_TENCOL(ref b_dt, new string[] {"MA","SO_ID" }, new string[] {"MA_C","MA" });
            se.P_TG_LUU(this.Title, "DT_CDANH", b_dt);
        } 
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_chucdanh;
        object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANH_TK_LKE("","A","");
        b_dt_chucdanh = (DataTable)a_object[1];
        bang.P_DOI_TENCOL(ref b_dt_chucdanh, new string[] { "MA", "SO_ID" }, new string[] { "MA_C", "MA" });
        b_dt_chucdanh.TableName = "DATA1"; b_ds.Tables.Add(b_dt_chucdanh);
        Excel_dungchung.ExportTemplate("Templates/importhdns/hd_ma_tuyendung_ktao.xls", b_ds, null, "hd_ma_tuyendung_kt");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_HD_MA_TUYENDUNG_LKE_ALL();
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_tuyendung.xlsx", b_dt, null, "so_vong_tuyendung");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
