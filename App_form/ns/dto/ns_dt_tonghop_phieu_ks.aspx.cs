﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_tonghop_phieu_ks : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_tonghop_phieu_ks" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tonghop_phieu_ks_P_KD();", true);
                MA.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}