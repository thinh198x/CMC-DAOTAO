﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_gvien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_gvien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_gvien_P_KD('');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "950,650";
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_dto.Fdt_NS_MA_LVDAOTAO_DR();
        se.P_TG_LUU(this.Title, "DT_LVDAOTAO", b_dt.Copy());
    }
}
