using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dsach_thieu_plenh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ns_dsach_thieu_plenh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd(); string b_so_the = b_se.nsd;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dsach_thieu_plenh_P_KD('" + b_so_the + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {

        DataTable b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy()); 
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_dt.Copy());

    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_dsach_thieu_plenh.xls", b_ds, null, "danh_sach_thieu_phieu_lenh");
    }
}