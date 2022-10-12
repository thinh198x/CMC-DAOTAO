﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_luong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_luong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_luong_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);

                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_LUONG_EXPORT(ASOTHE.Value.Trim());
            bang.P_SO_CNG(ref b_dt, "ngay_qd"); bang.P_SO_CSO(ref b_dt, "luongcb,THUONG_KETQUA,thunhapthang");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_LS_LUONG, TEN_BANG.NS_LS_LUONG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_luong_export.xlsx", b_dt, null, "Qua_trinh_luong_trong_congty");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
