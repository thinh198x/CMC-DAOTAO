using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_ma_ccdb : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/ma/ns_cc_ma_ccdb" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_ma_ccdb_P_KD();", true);           
            P_THANG_DROP();
        }
    }

    private void P_THANG_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_HDNS_MA_LVCDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NCB", b_dt.Copy());
        b_dt = ns_hdns.Fdt_NS_HDNS_CDANH_DROP();
        se.P_TG_LUU(this.Title, "DT_CDANH", b_dt.Copy());
    } 
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = tl_ma.Faobj_NS_CC_MA_CCDB_LKE(1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, new string[] { "NGAY_HL" });
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CC_MA_CCDB, TEN_BANG.NS_CC_MA_CCDB);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_ma_ccdb.xlsx", b_dt, null, "ns_cc_ma_ccdb");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
