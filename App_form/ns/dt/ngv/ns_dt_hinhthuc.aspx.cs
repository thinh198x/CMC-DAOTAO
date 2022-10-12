using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_hinhthuc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_hinhthuc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_hinhthuc_P_KD();", true);
                P_KETQUA();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_KETQUA()
    {
        DataTable b_dt;
        b_dt = hts_dungchung.Fdt_DT_CHUNG_LKE("KQDT");
        se.P_TG_LUU(this.Title,"DT_KETQUA", b_dt);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_HINHTHUC, TEN_BANG.NS_DT_HINHTHUC);
            object[] a_obj = ns_dt.Faobj_NS_DT_HINHTHUC_LKE(nam_tk.Text,1,1000);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_gd");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_HINHTHUC, TEN_BANG.NS_DT_HINHTHUC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_hinhthuc.xlsx", b_dt, null, "Thoi_gian_dao_tao_theo_hinh_thuc_OJT");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}