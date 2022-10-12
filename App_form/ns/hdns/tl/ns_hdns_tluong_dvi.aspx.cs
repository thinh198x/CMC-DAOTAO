using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_tluong_dvi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/ns_hdns_tluong_dvi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_tluong_dvi_P_KD();", true);
            DataTable b_dt = ns_ma.Fdt_NS_HT_MA_DVI_DR();
            se.P_TG_LUU(this.Title, "DT_MA_DVI", b_dt);
            P_TL();
            se.P_TG_XOA("DT_MA_NL");
            MA_TL.Focus();            
        }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_HDNS_TLUONG_DVI_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "NGAY_HL");
            bang.P_THAY_GTRI(ref b_dt, "TRANG_THAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANG_THAI", "N", "Ngừng áp dụng");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_tluong_dvi.xlsx", b_dt, null, "Gan_thang_luong_cho_don_vi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_TL()
    {
        DataTable b_dt;
        b_dt = ns_ma.Fdt_NS_HDNS_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_tl, b_dt_nl, b_dt_nnnghiep;
        b_dt_tl = ns_ma.Fdt_NS_HDNS_MA_HTTLUONG_DR();
        b_dt_nl = ns_ma.Fdt_NS_MA_NHOMLUONG_DR_ALL();
        b_dt_nnnghiep = ns_ma.Fdt_NS_HDNS_MA_NNN_DR();
        b_dt_tl.TableName = "DATA1"; b_dt_nl.TableName = "DATA2"; b_dt_nnnghiep.TableName = "DATA3";
        b_ds.Tables.Add(b_dt_tl);
        b_ds.Tables.Add(b_dt_nl);
        b_ds.Tables.Add(b_dt_nnnghiep);
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_tluong_dvi.xls", b_ds, null, "ns_hdns_tluong_dvi");
    }
}