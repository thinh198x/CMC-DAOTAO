using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_cc_ma_cc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/cc_ma_cc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_ma_cc_P_KD();", true);
                MA.Focus();
                P_DROPNHAP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void P_DROPNHAP()
    {
        DataTable b_dt = ht_dungchung.PNS_CC_MA_CC_DR();
        se.P_TG_LUU(this.Title, "DT_CC", b_dt);
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_CC_MA_CC_EXCEL();
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.CC_MA_CC, TEN_BANG.CC_MA_CC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/cc_ma_cc.xlsx", b_dt, null, "Thiet_lap_ma_cham_cong");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
