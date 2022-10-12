﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_cchn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/ns_ma_cchn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_cchn_P_KD();", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("CCHN", "NS_MA_CCHN", "MA");
                ma.Focus();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CCHN_EXPORT();
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "TC", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TC", "N", "Ngừng áp dụng");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_PHUCLOI, TEN_BANG.NS_MA_PHUCLOI);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_cchn.xlsx", b_dt, null, "Danh mục chứng chỉ hành nghề");
        }
        catch (Exception)
        {
            form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }

}
