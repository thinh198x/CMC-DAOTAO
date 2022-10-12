using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_tt_nghan : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_dt_tt_nghan" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tt_nghan_P_KD();", true);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable b_dt = ns_ma.Fdt_NS_MA_CCHN_DR();
                se.P_TG_LUU(this.Title, "DT_CCHN", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_CCC_DR();
                se.P_TG_LUU(this.Title, "DT_CCC", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_QTRR_DR();
                se.P_TG_LUU(this.Title, "DT_QTRR", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_UBCK_DR();
                se.P_TG_LUU(this.Title, "DT_UBCK", b_dt.Copy());

                b_dt = ns_ma.Fdt_PNS_HS_MA_CHUNG_DR("VUNG");
                se.P_TG_LUU(this.Title, "DT_VUNG", b_dt.Copy());
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_DT_NGHAN_EXP(so_the_an.Value);
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_tt_nghan.xlsx", b_dt, null, "Chung_chi_dao_tao_" + so_the_an.Value);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
