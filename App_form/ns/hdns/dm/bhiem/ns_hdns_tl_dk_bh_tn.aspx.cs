using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hdns_tl_dk_bh_tn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/bhiem/ns_hdns_tl_dk_bh_tn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_tl_dk_bh_tn_P_KD('');", true);
                P_NHAN_DROP(); LOAI_BH.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_BH_TN_LKE_DR();
        se.P_TG_LUU(this.Title, "DT_LBH", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_GBH", null);
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_NNN", b_dt.Copy());
        b_dt = ns_ma.Fdt_NS_HT_MA_DVI_DR();
        se.P_TG_LUU(this.Title, "DT_CTY", b_dt.Copy());
        se.se_nsd nsd = new se.se_nsd();
        madvi.Value = nsd.ma_dvi.ToString() + '{' + nsd.ten_dvi.ToString();
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_TL_DK_BH_TN_EXCEL();
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_tl_dk_bh_tn.xlsx", b_dt, null, "Thiet_lap_dk_bh_tn");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}