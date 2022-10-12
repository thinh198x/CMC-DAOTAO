using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_ungvien_dongy : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_ungvien_dongy" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_ungvien_dongy_P_KD('" + XuatExcel.UniqueID + "');", true);                
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    { 
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE(); 
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "PHONG_TK", b_dt);
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TIENTE");
        se.P_TG_LUU(this.Title, "DVI_TINH", b_dt);
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_TM");
        se.P_TG_LUU(this.Title, "TT_TM", b_dt);
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_UV");
        se.P_TG_LUU(this.Title, "TT_UV", b_dt);
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_UNGVIEN_DONGY_EXCEL(nam_tk.Text,ma_yc_tk.Text,cdanh_tk.Text,ngayd_tk.Text,ngayc_tk.Text);
            bang.P_SO_CNG(ref b_dt, "ngay_bd");  
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_ungvien_dongy.xlsx", b_dt, null, "ns_td_ungvien_dongy" + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Minute.ToString());
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}