using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_hd_cdanh_dvi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/hd_cdanh_dvi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hd_cdanh_dvi_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1250,670";
                P_TT_DROP();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
   private void P_TT_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] {"ma","ten" },"SS");
        bang.P_THEM_HANG(ref b_dt, new object[] {"A","Áp dụng"});
        bang.P_THEM_HANG(ref b_dt, new object[] {"N", "Ngừng áp dụng" });       
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_TT", b_dt);
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt, b_dt_phong,b_dt_chucdanh;
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "tt" }, "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "A", "Áp dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Ngừng áp dụng" });        
        b_dt.TableName = "DATA"; b_ds.Tables.Add(b_dt);

        b_dt_phong =ht_maph.Fdt_MA_PH_XEM();
        b_dt_phong.TableName = "DATA1";b_ds.Tables.Add(b_dt_phong);

        b_dt_chucdanh = ns_hdns.Fs_NS_MA_CDANH_LKE();
        b_dt_chucdanh.TableName = "DATA2";b_ds.Tables.Add(b_dt_chucdanh);
        Excel_dungchung.ExportTemplate("Templates/importhdns/hd_cdanh_dvi_ktao.xls", b_ds, null, "hd_cdanh_dvi_kt");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    kthuoc.Value;
        //    DataTable b_dt = ns_ma.Fdt_HD_MA_CMON_LKE_ALL(MA_NNGHE.Text);
        //    bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
        //    bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
        //    b_dt.TableName = "DATA";
        //    Excel_dungchung.ExportTemplate("Templates/ExportMau/hd_ma_cmon.xlsx", b_dt, null, "Danh_muc_chuyen_mon");

        //}
        //catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
