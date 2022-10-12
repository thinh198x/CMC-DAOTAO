using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_ma_noi_khambenh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/bhiem/ns_hdns_ma_noi_khambenh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ma_noi_khambenh_P_KD();", true);
            DataTable b_dt = ns_ma.Fdt_NS_MA_TT_DR("QG001");
            se.P_TG_LUU(this.Title, "DT_TPHO", b_dt);
            se.P_TG_LUU(this.Title, "DT_QHUYEN", null);
            MA.Focus();
        }        
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {

        //b_dt.TableName = "DATA1";
        //Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_ma_noi_khambenh_mau.xls", b_dt, null, "ns_hdns_ma_noi_khambenh_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NOI_KHAMBENH_EXCEL();
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_ma_noi_khambenh.xlsx", b_dt, null, "Danh_muc_noi_khambenh");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
