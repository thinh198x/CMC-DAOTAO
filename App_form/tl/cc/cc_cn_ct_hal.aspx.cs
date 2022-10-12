using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_cc_cn_ct_hal : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_cn_ct_hal" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_cc_hal_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                THANG.Text = chuyen.NG_CTH(DateTime.Now);
                P_NHAN_DROP(); 
                THANG.Focus(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
}