using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hdns_dbien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/ns_hdns_dbien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_dbien_P_KD();", true);

                DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
                se.P_TG_LUU(this.Title, "DT_DONVI", b_dt.Copy());
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }



    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = new DataTable();
            b_dt = ns_td.Fdt_NS_HDNS_DBIEN_EXP(an_Nam.Value, an_phong.Value);
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_DBIEN, TEN_BANG.NS_HDNS_DBIEN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_dbien.xlsx", b_dt, null, "Quan_ly_dinh_bien_nhan_su");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_dvi = ht_madvi.Fdt_MA_DVI_XEM();
            DataTable b_dt_ban = ht_dungchung.Fdt_PHONG_LEVEL_DR("", 2);
            DataTable b_dt_phong = ht_dungchung.Fdt_PHONG_LEVEL_DR("", 3);
            DataTable b_dt_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG("0");
            b_dt_dvi.TableName = "DVI";
            b_dt_ban.TableName = "BAN";
            b_dt_phong.TableName = "PHONG";
            b_dt_cdanh.TableName = "CDANH";
            b_ds.Tables.Add(b_dt_phong);
            b_ds.Tables.Add(b_dt_dvi);
            b_ds.Tables.Add(b_dt_ban);
            b_ds.Tables.Add(b_dt_cdanh);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_DBIEN, TEN_BANG.NS_HDNS_DBIEN);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_dinhbien.xls", b_ds, null, "NS_TD_DINHBIEN" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}