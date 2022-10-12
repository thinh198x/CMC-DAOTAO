using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_cc_ma_tl_cc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/cc_ma_tl_cc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_ma_tl_cc_P_KD();", true);
                MA.Focus();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_CC_MA_TL_CC_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "LOAI", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt, "LOAI", "N", "Nghỉ");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.CC_MA_TL_CC, TEN_BANG.CC_MA_TL_CC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_ma_tl_cc.xlsx", b_dt, null, "Danh_muc_khcc");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}