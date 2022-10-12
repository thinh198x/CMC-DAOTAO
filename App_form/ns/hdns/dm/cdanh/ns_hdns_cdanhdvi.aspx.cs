using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_cdanhdvi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanhdvi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_cdanhdvi_P_KD();", true);
        }        
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_cdanhdvi_mau.xls", b_dt, null, "ns_hdns_cdanhdvi_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            //DataTable b_dt = ns_hdns.Fdt_NS_HDNS_CDANHDVI_TK_LKE(phong.Value);
            //b_dt.TableName = "DATA";
            //Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_cdanhdvi.xlsx", b_dt, null, "Chuc_danh_cua_don_vi");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
