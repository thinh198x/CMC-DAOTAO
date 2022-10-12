using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ns_dt_ma_nnd_dv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_nnd_dv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_nnd_dv_P_KD();", true);
                MA.Focus();
                P_NHAP_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }

    private void P_NHAP_DR()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NND", b_dt);
    }

    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_NND_DV_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "tthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tthai", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_MA_NND_DV, TEN_BANG.NS_DT_MA_NND_DV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ma_nnd_dv.xlsx", b_dt, null, "Danh_muc_nhom_noi_dung_don_vi");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}