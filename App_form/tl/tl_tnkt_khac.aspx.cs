﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_tnkt_khac : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/tl_tnkt_khac" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_tnkt_khac_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "700,420";
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
