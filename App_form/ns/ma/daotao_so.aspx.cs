﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_daotao_so : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/daotao_so" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "daotao_so_P_KD();", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("CCC", "daotao_so", "MA");
                ma.Focus();
                DataTable b_dt = new DataTable();
                b_dt = ns_ma.Fdt_NS_MA_CCHN_DR();
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_CCHN", b_dt);
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    

}
