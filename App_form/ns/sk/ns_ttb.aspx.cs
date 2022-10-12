using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ttb : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/sk/sns_sk.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/sk/ns_ttb" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ttb_P_KD('');", true);
                SO_THE.Focus();
                P_Phong_DR();
                P_NhomTs_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_Phong_DR()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_TTB_DVI", b_dt);
    }
    private void P_NhomTs_DR()
    {
        DataTable b_dt = hts_dungchung.Fdt_CHUNG_LKE("NHOM_TS");
        se.P_TG_LUU(this.Title, "NS_TTB_NHOM_TS", b_dt);
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_sk.PNS_TTB_EXPORT(SO_THE.Text);
            bang.P_SO_CNG(ref b_dt, "ngaycap"); bang.P_SO_CNG(ref b_dt, "ngaythu");
            bang.P_SO_CSO(ref b_dt, "tien");bang.P_SO_CSO(ref b_dt, "sluong");
            bang.P_THAY_GTRI(ref b_dt, "ht", "C", "Sử dụng chung");
            bang.P_THAY_GTRI(ref b_dt, "ht", "R", "Sử dụng riêng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "C", "Chờ cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "D", "Đã cấp");
            bang.P_THAY_GTRI(ref b_dt, "tt", "C", "Đã thu hồi");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_qlts_capphat_export.xlsx", b_dt, null, "Quanly_taisan_capphat");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
