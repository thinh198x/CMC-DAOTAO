﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_bluong_okifood : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/tl_bluong_okifood" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_bluong_P_KD();", true);
                THANG.Text = chuyen.NG_CTH(DateTime.Now);
                P_NHAN_DROP(); THANG.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
}