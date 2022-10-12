using System;
using System.Web.UI;
using System.Data;
using Cthuvien;

public partial class f_menuM : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bool b_log = false;
            try
            {
                b_log = khac.Fb_HOI_QU(this.Title);
                if (!b_log)
                {
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                    string b_s = this.ResolveUrl("~/menuM" + khac.Fs_runMode() + ".js"), b_tm = Fs_tm("D");
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "menu_KD('" + Fs_tm("K") + "');", true);
                    se.se_nsd b_se = new se.se_nsd(); tm.Value = b_tm;
                    nsd.Text = b_se.ten;
                    DataTable b_dt = ht_madvi.Fdt_DVI_QLY();
                    bang.P_DON(ref b_dt, "ten");
                    form.P_DROP_BANG(qly_dvi, b_dt);
                    b_log = khac.Fb_KTRA_QU(this.Title, "ctmenu", "GXDPIMAE");
                    qly_dvi.SelectedValue = b_se.ma_dvi;
                    //Show_SN_HHHD_DHHD();
                }
                else b_log = false;
            }
            catch (Exception ex) { b_log = false; }
            if (!b_log) Response.Redirect("~/login.aspx", false);
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private string Fs_tm(string b_dk)
    {
        string b_f = "~/menuM.aspx";
        string b_tm = (b_dk == "D") ? Server.MapPath(b_f) : this.ResolveUrl(b_f);
        return b_tm.Substring(0, b_tm.Length + 1 - b_f.Length);
    }
    private void Show_SN_HHHD_DHHD()
    {
        DataSet dtb_sn = ns_tt.Fdt_MENU_TBAO_CT("", 10);
        int b_dem_sn = dtb_sn.Tables[1].Rows.Count;
        Lb_sn.Text = "Số nhân viên sắp đến sinh nhật: " + b_dem_sn;
        int b_dem_hhhd = dtb_sn.Tables[0].Rows.Count;
        Lb_hd.Text = "Số nhân viên sắp đến hạn hợp đồng:  " + b_dem_hhhd;
        int b_dem_hc = dtb_sn.Tables[2].Rows.Count;
        Lb_hc.Text = "Số nhân viên hết hạn hộ chiếu:  " + b_dem_hc;
        int b_dem_cmt = dtb_sn.Tables[3].Rows.Count;
        Lb_cmt.Text = "Số nhân viên hết chứng minh thư:  " + b_dem_cmt;
        int b_dem_qd = dtb_sn.Tables[4].Rows.Count;
        Lb_qd.Text = "Số nhân viên sắp hết hạn quyết định:  " + b_dem_qd;
        int b_dem_vs = dtb_sn.Tables[5].Rows.Count;
        lb_vs.Text = "Số nhân viên sắp hết hạn visa:  " + b_dem_vs;
        int b_dem_tuyendung = dtb_sn.Tables[6].Rows.Count;
        ls_td.Text = "Bạn đang có yêu cầu TD:  " + b_dem_tuyendung;
    }
}