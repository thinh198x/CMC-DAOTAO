using System;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ht_manhom : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_manhom" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_manhom_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private void P_NHAN_DROP()
    {
        // lấy đơn vị
        DataTable b_dt = ht_mansd.Fdt_MODULE();
        se.P_TG_LUU(this.Title, "DT_PHANHE", b_dt);
    }
}
