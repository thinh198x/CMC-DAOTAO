using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ns_dt_ma_ctdt_ht : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_ctdt_ht" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_ctdt_ht_P_KD();", true);
                NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }

    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        { 
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_CTDT_HT_LKE_ALL();
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_MA_CTDT_HT, TEN_BANG.NS_DT_MA_CTDT_HT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ma_ctdt_ht.xlsx", b_dt, null, "Danh_muc_chi_tieu_dao_tao_hoc_tap");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}