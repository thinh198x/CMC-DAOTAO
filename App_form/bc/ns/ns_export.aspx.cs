using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_export : fmau
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bc/sbc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/bc/ns/ns_export.js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = "ns_export_P_KD('" + Fs_thumuc() + "');"; 
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
                //loai.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
}
