using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_bluong_cn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/tl_bluong_cn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd();
                string b_nsd = b_se.nsd;
                string b_so_the = P_SOTHE(b_nsd);
                //ho_ten.Text = b_se.ten;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_bluong_cn_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        DataTable b_ky = ht_dungchung.Fdt_MA_KYLUONG(DateTime.Now.Year);
        se.P_TG_LUU(this.Title, "DT_KY", b_ky.Copy());
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }

}