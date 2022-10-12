using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_tgian_gday_hvien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_tgian_gday_hvien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tgian_gday_hvien_P_KD();", true);
            P_NHAN_DROP(); NAM_TK.Text = DateTime.Now.Year.ToString();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_dt.Faobj_NS_DT_TGIAN_GDAY_HVIEN_LKE(phongan.Value, naman.Value, 1, 100000);
            DataTable b_dt = (DataTable)a_obj[1]; b_dt.TableName = "DATA";
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_TGIAN_GDAY_HVIEN, TEN_BANG.NS_DT_TGIAN_GDAY_HVIEN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_tgian_gday_hvien.xlsx", b_dt, null, "Thoi_gian_hoc_tap_cua_hoc_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

