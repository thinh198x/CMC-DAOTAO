using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_gt_cc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_gt_cc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd(); string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_gt_cc_P_KD('" + b_so_the + "');", true);
            P_NHAN_DROP();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = tl_ma.Fdt_CC_MA_CC_DR2("N");
        se.P_TG_LUU(this.Title, "DT_KIEUNGHI", b_dt);
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "ma", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_nam.Copy());
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_dt_loaidky;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        b_dt_nv.TableName = "DATA";
        b_dt_loaidky = bang.Fdt_TAO_BANG(new string[] { "ma", "tenloai" }, "SS");
        bang.P_THEM_HANG(ref b_dt_loaidky, new object[] { "DM", "Đăng ký đi muộn" });
        bang.P_THEM_HANG(ref b_dt_loaidky, new object[] { "VS", "Đăng ký về sớm" });
        b_dt_loaidky.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt_loaidky);
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_gt_cc_ktao.xls", b_ds, null, "ns_gt_cc_ktao");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = null;// tl_cc.P_ns_gt_cc_EXPORT();
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt, "loai_dky", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt, "loai_dky", "VS", "Đăng ký về sớm");
            b_dt.TableName = "DATA"; 
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_gt_cc_export.xlsx", b_dt, null, "dangky_dimuon_vesom");

        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

