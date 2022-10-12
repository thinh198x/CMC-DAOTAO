using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_cdanh_tk : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/cdanh/ns_hdns_cdanh_tk" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_cdanh_tk_P_KD();", true);
            if (Request.QueryString["nnn"] != null)
            {
                nnn.Value = chuyen.OBJ_S(Request.QueryString["nnn"]);
            }
        }        
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_cdanh_tk_mau.xls", b_dt, null, "ns_hdns_cdanh_tk_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = ns_hdns.Fdt_NS_HDNS_CDANH_TK_EXCEL(nnn.Value, "PD");
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_cdanh_tk.xlsx", b_dt, null, "Chuc_danh_cua_cong_ty");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
