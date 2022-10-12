using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_khct : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_khct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_khct_P_KD('"+ Xuatexcel.UniqueID +"');", true);
                se.se_nsd b_se = new se.se_nsd(); string b_ma_dvi = b_se.ma_dvi; PHONG.Text = b_ma_dvi;
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    { 
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt.Copy());
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("THANG");
        bang.P_CSO_SO(ref b_dt, "MA");DataView dv = b_dt.DefaultView; dv.Sort = "ma";DataTable sortedDT = dv.ToTable();
        se.P_TG_LUU(this.Title, "DT_THANG", sortedDT.Copy());
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("GT");se.P_TG_LUU(this.Title, "DT_GIOI_TINH", b_dt);
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("CTHUC_TD"); se.P_TG_LUU(this.Title, "DT_CTHUC_TD", b_dt);        
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TTHAI_YC_TD");
        bang.P_CSO_SO(ref b_dt, "ma");dv = b_dt.DefaultView; dv.Sort = "ma";sortedDT = dv.ToTable();
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI_YC_PD", sortedDT.Copy());
        b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "MA", "TEN" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "0", "Chờ phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "1", "Đã duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "2", "Không phê duyệt" });
        se.P_TG_LUU(this.Title, "DT_TRANGTHAI_PD", b_dt.Copy());
        b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "MA", "TEN" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TM", "Tuyển mới" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TTT", "Tuyển thay thế" });
        se.P_TG_LUU(this.Title, "DT_LOAITD", b_dt.Copy());
    }
    protected void Xuatexcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_KHCT_EXCEL(nam_tk.Text,Thangtk.Value, phongtk.Value, cdanh_tk.Text, MA_YC_TK.Text);
            bang.P_SO_CNG(ref b_dt, "ngay_gui_yc,ngay_dl_dk");
            bang.P_SO_CSO(ref b_dt, "LUONG_TU,LUONG_DEN");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "2", "Không phê duyệt"); 
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_khct.xlsx", b_dt, null, "ns_td_khct" + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Minute.ToString());
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}