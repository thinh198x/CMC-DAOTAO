using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_cc_dky_dmvs : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_dky_dmvs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd();string b_nsd = b_se.nsd;string b_so_the = P_SOTHE(b_nsd);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_dky_dmvs_P_KD('" + b_so_the + "');", true);            
            NGAY_DKY.Text = chuyen.NG_CNG(DateTime.Now); 
        }
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
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO"); 
        b_dt_nv.TableName = "DATA";
        b_dt_loaidky = bang.Fdt_TAO_BANG(new string[] { "ma", "tenloai" }, "SS");
        bang.P_THEM_HANG(ref b_dt_loaidky, new object[] { "DM", "Đăng ký đi muộn" });
        bang.P_THEM_HANG(ref b_dt_loaidky, new object[] { "VS", "Đăng ký về sớm" });
        b_dt_loaidky.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt_loaidky);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.CC_DKY_DMVS, TEN_BANG.CC_DKY_DMVS);    
        Excel_dungchung.ExportTemplate("Templates/importmau/cc_dky_dmvs_ktao.xls", b_ds, null, "cc_dky_dmvs_ktao");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_cc.P_CC_DKY_DMVS_EXPORT();
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt, "loai_dky", "DM", "Đăng ký đi muộn");
            bang.P_THAY_GTRI(ref b_dt, "loai_dky", "VS", "Đăng ký về sớm");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "NS", "Nhân sự");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.CC_DKY_DMVS, TEN_BANG.CC_DKY_DMVS);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_dky_dmvs_export.xlsx", b_dt, null, "dangky_dimuon_vesom");

        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

