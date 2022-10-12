﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_kdt_xem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_kdt_xem" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_kdt_xem_P_KD('');", true);
                MA.Focus(); ngaytrinh.Text = chuyen.NG_CNG(DateTime.Now);

            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}
