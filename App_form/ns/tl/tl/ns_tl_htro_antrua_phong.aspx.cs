using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_htro_antrua_phong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tl/sns_tl.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tl/tl/ns_tl_htro_antrua_phong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_htro_antrua_phong_P_KD('');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = new DataTable(); //tl_ma.Fdt_NS_DT_CMD_EXCEL();
            bang.P_SO_CNG(ref b_dt, "NG_HLUC,NG_HET_HLUC");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_DT_CMD, TEN_BANG.TL_DT_CMD);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_tl_cmd.xlsx", b_dt, null, "Thiet_lap_ca_mac_dinh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}