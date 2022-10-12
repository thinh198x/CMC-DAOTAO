using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using Cthuvien;

public partial class f_cc_cn_ct_nagase : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_cn_ct_nagase" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(),"cc_cn_ct_nagase_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1400,720";
                P_NHAN_DROP();thumuc.Value = Fs_thumuc();
                THANGCC.Text = chuyen.NG_CTH(DateTime.Now);NGAYD.Focus();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/App_form/tl/cc/cc_cn_ct_nagase.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
}