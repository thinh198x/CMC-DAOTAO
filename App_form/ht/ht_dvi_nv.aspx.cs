using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_dvi_nv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_mansd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_mansd_KD();", true);
                DataTable b_dt = ht_madvi.Fdt_MA_DVI_NB(); form.P_DROP_BANG(dvi, b_dt);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1000,710";
                dvi.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message );}
    }
}
