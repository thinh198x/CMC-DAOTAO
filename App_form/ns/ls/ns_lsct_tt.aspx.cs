﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_lsct_tt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_lsct_tt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_lsct_tt_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.Fdt_NS_LSCT_TT_EXCEL(this.so_the_an.Value);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt, "mucluong");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_lsct.xlsx", b_dt, null, "Qua_trinh_cong_tac_truoc_cty");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
