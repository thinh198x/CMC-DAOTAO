using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_ct_tct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_ct_tct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_ct_tct_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1010,600";
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO(SO_THE.Text);
        b_dt_nv.TableName = "DATA";
       // b_macc_nghi = macc_nghi.SelectedValue;
        //b_dt_macc_nghi = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_SC(b_macc_nghi);
        //b_dt_macc_nghi.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        //b_ds.Tables.Add(b_dt_macc_nghi);
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_ls_ct_tct_ktao.xls", b_ds, null, "Ls_quatrinhcongtac_trongcongty");        
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_CT_TCT_EXPORT(SO_THE.Text);
            bang.P_SO_CNG(ref b_dt, "ngay_qd"); bang.P_SO_CNG(ref b_dt, "ngayd");bang.P_SO_CNG(ref b_dt, "ngayc");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_ct_tct_export.xlsx", b_dt, null, "Ls_quatrinhcongtac_trongcongty");          
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
