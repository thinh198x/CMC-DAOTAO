using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_gt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx")); 
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
            string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
            string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_cc_gt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd(); string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_gt_P_KD('" + b_so_the + "');", true);
            P_NHAN_DROP();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = tl_ma.Fdt_CC_MA_CC_DR2("N");
        se.P_TG_LUU(this.Title, "DT_KIEUNGHI", b_dt);
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());

        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KYLUONG", null);
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
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_cc_gt_ktao.xls", b_ds, null, "ns_cc_gt_ktao");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {

            object[] a_obj = tl_cc.Faobj_NS_CC_GT_LKE(aphong.Value, akyluong.Value, 1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CC_GT, TEN_BANG.NS_CC_GT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_gt_export.xlsx", b_dt, null, "giaitrinh_chamcong");

        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

