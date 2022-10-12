﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_danhsach : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ns_dt_danhsach" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_danhsach_P_KD('');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,600";
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
