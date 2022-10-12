using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_phuonganchedobh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/bhiem/ns_ma_phuonganchedobh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/dungchung.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_phuonganchedobh_P_KD();", true);
            P_NHAN_DROP();
            MA.Focus();
        }        
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_NHOM_CHEDO_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM_CD", b_dt);
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_PHUONGANCHEDOBH_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "TRANG_THAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANG_THAI", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_phuonganchedobh.xlsx", b_dt, null, "Danh_muc_phuong_an_che_do_bh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
