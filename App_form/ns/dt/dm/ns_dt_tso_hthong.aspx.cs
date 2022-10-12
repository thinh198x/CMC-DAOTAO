﻿using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_tso_hthong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_tso_hthong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tso_hthong_P_KD();", true);
            MA.Focus();
        }
    }

    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_TSO_HTHONG_LKE_ALL();
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_tso_hthong.xlsx", b_dt, null, "Danh_muc_tham_so_he_thong");

        }
        catch (Exception ex) { 
            form.P_LOI(this, "loi:File export không tồn tại:loi"); 
        }
    }
}