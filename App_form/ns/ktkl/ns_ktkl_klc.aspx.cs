using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ktkl_klc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ktkl/sns_ktkl.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ktkl/ns_ktkl_klc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ktkl_klc_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);

                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1350,805";
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    { 
        //DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
        //if (b_tusinh != null && b_tusinh.Rows.Count > 0)
        //{
        //    if (b_tusinh.Rows[0]["QUYETDINH"].Equals("TS"))
        //    {
        //        soqd.ReadOnly = true;
        //        soqd.Enabled = false;
        //    }
        //    else
        //        soqd.Focus();
        //}
    }
}
