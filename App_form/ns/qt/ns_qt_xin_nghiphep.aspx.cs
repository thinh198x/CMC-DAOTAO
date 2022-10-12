using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_qt_xin_nghiphep : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                se.se_nsd b_se = new se.se_nsd(); string b_ma_dvi = b_se.ma_dvi;
                string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_qt_xin_nghiphep" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qt_xin_nghiphep_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "", b_phong = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0)
        {
            b_so_the = b_dt.Rows[0]["so_the"].ToString();
            b_phong = b_dt.Rows[0]["phong"].ToString();
            // lay danh sach nhan vien thay the theo phong ban
            DataTable b_dt_dsnvtt = ht_dungchung.Fdt_SO_THE_THEP_PHONG(b_so_the, b_phong);
            bang.P_THEM_HANG(ref b_dt_dsnvtt, new object[] { "", "" }, 0);
            se.P_TG_LUU("ns_qt_xin_nghiphep", "DT_SOTHE_THAYTHE", b_dt_dsnvtt.Copy());
        }

        return b_so_the;
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = tl_ma.Fdt_CC_MA_CC_DR2("N");
        se.P_TG_LUU(this.Title, "DT_KIEUNGHI", b_dt);
    }
}
