using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_hdns_pt_nguonluc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/hdns_pt_nguonluc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hdns_pt_nguonluc_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1220,560";
                THANG.Focus(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
}