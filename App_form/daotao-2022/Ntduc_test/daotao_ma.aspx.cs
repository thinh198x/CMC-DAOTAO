using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_daotao_ma : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/daotao-2022/Ntduc_test/daotao_ma" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "daotao_ma_P_KD();", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("CCC", "daotao_ma", "MA");
                ma.Focus();
                DataTable b_dt = new DataTable();
                b_dt = ns_ma.Fdt_NS_MA_CCHN_DR();
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_CCHN", b_dt);
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {

           
            DataTable b_dt = ns_hdns.Fdt_NTDUC_EXPORT();
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_ad");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_PBAN_NTDUC, TEN_BANG.NS_MA_PBAN_NTDUC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_nuoc.xlsx", b_dt, null, "Danh_muc");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }


}
