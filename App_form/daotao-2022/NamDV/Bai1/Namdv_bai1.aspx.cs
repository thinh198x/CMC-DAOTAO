using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_daotao_NamDV_bai1 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/daotao-2022/NamDV/Bai1/NamDV_bai1" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "P_KD();", true);
            ma.Text = ht_dungchung.Fdt_AutoGenCode("T", "DAOTAO_BAI1", "MA");
            ma.Focus();
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_NAM_BAI1_DR();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "TT", 1, "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TT", 2, "Ngừng áp dụng");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_nuoc.xlsx", b_dt, null, "Danh sách tỉnh");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
   
}
