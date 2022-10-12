using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_mansd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bc/sbc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_mansd" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_mansd_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                se.se_nsd b_se = new se.se_nsd();
                klk.Text = b_se.md; klk.lke = b_se.md + ",T"; klk.ToolTip = "Liệt kê theo Modul: " + b_se.md + ", T-Tất cả";
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1040,890";
                dvi.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private void P_NHAN_DROP()
    {
        // lấy đơn vị
        DataTable b_dt = bc.Fdt_LOAI_SL_XEM("C", "K");
        se.P_TG_LUU(this.Title, "DT_LOAI", b_dt);
        // lấy các modul
        b_dt = ht_mansd.Fdt_MODULE();
        se.P_TG_LUU(this.Title, "DT_PHANHE", b_dt);

        b_dt = ht_madvi.Fdt_MA_DVI_NB();
        se.P_TG_LUU(this.Title, "DT_DVI", b_dt);
    }
}
