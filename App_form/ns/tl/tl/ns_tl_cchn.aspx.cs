using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tl_cchn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tl/tl/ns_tl_cchn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_cchn_P_KD();", true);
                
                DataTable b_dt = new DataTable();
                b_dt = ns_ma.Fdt_NS_MA_CCHN_DR();
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_CCHN", b_dt);
                NGAY_HL.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    [Obsolete]
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_TL_CCHN_EXPORT();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "TC", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TC", "N", "Ngừng áp dụng");
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            var unused = Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_cchn.xlsx", b_dt, null, "Thiet lap dieu kien thi chung chi hanh nghe");

        }
        catch (Exception)
        {
            form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }

}
