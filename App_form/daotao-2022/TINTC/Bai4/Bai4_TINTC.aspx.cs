using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tin_bai4 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/daotao-2022/TINTC/Bai4/Bai4_TINTC" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "P_KD();", true);
                ma.Text = ht_dungchung.Fdt_AutoGenCode("CCC", "DAOTAO_BAI4", "MA");
                ma.Focus();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    

}
