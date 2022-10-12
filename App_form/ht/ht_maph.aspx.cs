using System;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ht_maph : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ht/ht_maph" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_maph_KD('" + khac.Fs_TMUCF(b_s) + "','" + b_ma_dvi + "','" + iurl.ClientID + "');", true);
                //P_NHAN_DROP();
                TEN.Focus();
                DataTable b_dt = new DataTable();
                b_dt = hts_dungchung.Fdt_CHUNG_LKE("VUNG");
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_VUNG", b_dt);

                b_dt = hts_dungchung.Fdt_CHUNG_LKE("KHOI");
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_KHOI", b_dt);

                b_dt = ns_ma.Fdt_NS_MA_PBO_DR();
                bang.P_THEM_TRANG(ref b_dt, 1, 0);
                se.P_TG_LUU(this.Title, "DT_MAPB", b_dt);
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }

    //protected void FileMau_Click(object sender, EventArgs e)
    //{
    //    DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
    //    b_dt.TableName = "DATA";
    //    Excel_dungchung.ExportTemplate("Templates/importhdns/ht_maph_mau.xls", b_dt, null, "ht_maph_mau");
    //}
    [Obsolete]
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ht_madvi.Fdt_MA_PH_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_tl,ngay_gt");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ht_maph.xlsx", b_dt, null, "ht_maph");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    //protected void XuatExcel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
    //        Excel_dungchung.ExportTemplate("Templates/importhdns/ht_maph_mau.xls", b_dt, null, "ht_maph_mau");

    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}
}
