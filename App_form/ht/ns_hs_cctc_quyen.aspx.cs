using System;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ns_hs_cctc_quyen : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ns_hs_cctc_quyen"+khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hs_cctc_quyen_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }

    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hs_cctc_quyen_mau.xls", b_dt, null, "ns_hs_cctc_quyen_mau");
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
            Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hs_cctc_quyen_mau.xls", b_dt, null, "ns_hs_cctc_quyen_mau");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
