﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_pcap_ds : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ns_tl_pcap_ds" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_pcap_ds_P_KD();", true);
                THANG.Text = chuyen.NG_CTH(DateTime.Now);
                SO_THE.Focus();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}