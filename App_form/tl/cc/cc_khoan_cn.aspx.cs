using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_cc_khoan_cn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_khoan_cn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_khoan_cn_P_KD();", true);
                SO_THE.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}