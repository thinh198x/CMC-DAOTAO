﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_hd_ma_bnnghe : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/hd_ma_bnnghe" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hd_ma_bnnghe_P_KD();", true);
            MA_NNNGHE.Focus();
        }
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt, b_dt_nnghe;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });
        b_dt_nnghe = ns_hdns.Fdt_HD_MA_NNGHIEP_MATEN();
        b_dt.TableName = "DATA"; b_dt_nnghe.TableName = "DATA1";
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dt_nnghe);
        Excel_dungchung.ExportTemplate("Templates/importhdns/hd_ma_bacnn_ktao.xls", b_ds, null, "hd_ma_capbac_kt");
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_HD_MA_BNNGHE_LKE_ALL(MA_NNNGHE.Text);
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_bnnghe.xlsx", b_dt, null, "Cấp bậc nghề nghiệp");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
