using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_ma_ctluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tl/sns_tl.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/tl/ns_tl_ma_ctluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_ma_ctluong_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Ma dvi
        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM_QUYEN();
        se.P_TG_LUU(this.Title, "DT_DVI", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_DT", null);
    }

}