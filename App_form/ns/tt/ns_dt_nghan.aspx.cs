using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_nghan : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_dt_nghan" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_nghan_P_KD();", true);

                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                DataTable b_dt = ns_ma.Fdt_NS_MA_CCHN_DR();
                se.P_TG_LUU(this.Title, "DT_CCHN", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_CCC_DR();
                se.P_TG_LUU(this.Title, "DT_CCC", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_QTRR_DR();
                se.P_TG_LUU(this.Title, "DT_QTRR", b_dt.Copy());

                b_dt = ns_ma.Fdt_NS_MA_UBCK_DR();
                se.P_TG_LUU(this.Title, "DT_UBCK", b_dt.Copy());

                b_dt = ns_ma.Fdt_PNS_HS_MA_CHUNG_DR("VUNG");
                se.P_TG_LUU(this.Title, "DT_VUNG", b_dt.Copy());
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
    }
    protected void excel_Click_All(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_tt.Fdt_NS_DT_NGHAN_LKE_ALL();
            
            DataTable b_dt_cchn = b_ds.Tables[0];
            DataTable b_dt_ccc = b_ds.Tables[1];
            DataTable b_dt_cck = b_ds.Tables[2];

            bang.P_SO_CNG(ref b_dt_cck, "tu_ngay,den_ngay,ngay_hl,ngay_hhl");

            bang.P_SO_CNG(ref b_dt_cchn, "ngay_cap");
            bang.P_SO_CTH(ref b_dt_cchn, "thang_cap");

            bang.P_SO_CNG(ref b_dt_ccc, "ngay_hl,ngay_hhl"); 

            b_dt_cchn.TableName = "DATA1";
            b_dt_ccc.TableName = "DATA2";
            b_dt_cck.TableName = "DATA3";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_NGHAN, TEN_BANG.NS_DT_NGHAN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_nghan_all.xlsx", b_ds, null, "Chung chi dao tao");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
