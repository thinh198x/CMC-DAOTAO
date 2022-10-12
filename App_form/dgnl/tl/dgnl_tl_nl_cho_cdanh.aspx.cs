﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dgnl_tl_nl_cho_cdanh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dgnl/tl/dgnl_tl_nl_cho_cdanh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dgnl_tl_nl_cho_cdanh_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1227,700";  
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}