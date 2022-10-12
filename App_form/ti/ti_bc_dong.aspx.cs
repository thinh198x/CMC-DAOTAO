using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ti_bc_dong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ti/ti_bc_dong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_timkiem_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "980,670";
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ti_ch.Fdt_NS_TK_MA_NHTK_DR();
        se.P_TG_LUU(this.Title, "DT_NHOM", b_dt.Copy());
        DataTable b_dtS = ti_ch.Fdt_NS_MA_KQ_HIENTHI_CT(anNhom.Value);
        se.P_TG_LUU(this.Title, "DT_BCDT", b_dtS.Copy());
    }


    protected void xuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = se.Fds_KQ_TRA("TK", "TK");
            if (b_ds != null)
            {
                se.se_nsd b_nsd = new se.se_nsd();
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.TI_BC_DONG, TEN_BANG.TI_BC_DONG);
                Excel_dungchung.ExportTemplate("Templates/ExportMau/BC_DONG.xls", "BC_DONG", b_ds, new string[] { "0,2", "1" });
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}