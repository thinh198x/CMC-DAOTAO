using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class nam_bai4 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/daotao-2022/NamDV/Bai4/namdvbai4" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "P_KD();", true);
              
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
            DataTable b_dt = ns_hdns.Fdt_NAM_BT4_DROP();
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/DaoTao/daotao_ma.xlsx", b_dt, null, "NAM_Bai4");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }


}
