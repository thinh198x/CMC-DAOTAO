using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_hdns_mota_cv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_mota_cv.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx")); 
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/hdns_mota_cv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hdns_mota_cv_P_KD();", true);
                P_NHAN_DROP();
                ma.Focus();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        //Nganh nghe
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_NHOM_CD", b_dt.Copy());

    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nnn, b_dt_vtcd, b_dt_canbo;
        b_dt_nnn = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA(); b_dt_nnn.TableName = "DATA1"; b_ds.Tables.Add(b_dt_nnn);
        b_dt_vtcd = ns_mota_cv.Fdt_NS_HDNS_VTCD_DROP_LKE(); b_dt_vtcd.TableName = "DATA2"; b_ds.Tables.Add(b_dt_vtcd);
        b_dt_canbo = hts_dungchung.Fdt_NG_KY(); ; b_dt_canbo.TableName = "DATA3"; b_ds.Tables.Add(b_dt_canbo);
        Excel_dungchung.ExportExcel("Templates\\importmau\\MOTA_CV_IMPORT.xlsx", b_ds, null, "hdns_mota_cv_ktao");
    } 
}