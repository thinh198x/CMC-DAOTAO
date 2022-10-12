using System;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ti_ma_tk : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ti/ns_ti_ma_tk1.js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ti_ma_tk_KD();", true);
            if (se.Fs_DUYET() != "IE") kthuoc.Value = "1250,650";
        }
    }       
}
