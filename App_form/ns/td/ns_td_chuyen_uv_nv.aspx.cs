using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_chuyen_uv_nv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_chuyen_uv_nv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_uv_yeucauTD" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_chuyen_uv_nv_P_KD();", true);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_chuyen_uv_nv_P_KD2('');", true);
                NAM.Focus();
                //NAM.Text = DateTime.Now.Year.ToString();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_CHUYEN_UV_NV_LKE_ALL();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "NGAY_DL_TT");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_CHUYEN_UV_NV, TEN_BANG.NS_TD_CHUYEN_UV_NV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_chuyen_uv_nv.xlsx", b_dt, null, "Danh_muc_ns_td_chuyen_uv_nv");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
