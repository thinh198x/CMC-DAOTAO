using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;
public partial class f_ns_dt_ncau : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_ncau" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ncau_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_dt.Faobj_NS_DT_NCAU_LKE(nam_tk.Text, athang_tk.Value, 1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, "chiphi_dk");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "1", "Tháng 01");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "2", "Tháng 02");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "3", "Tháng 03");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "4", "Tháng 04");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "5", "Tháng 05");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "6", "Tháng 06");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "7", "Tháng 07");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "8", "Tháng 08");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "9", "Tháng 09");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "10", "Tháng 10");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "11", "Tháng 11");
            bang.P_THAY_GTRI(ref b_dt, "TEN_THANG", "12", "Tháng 12"); 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_NCAU, TEN_BANG.NS_DT_NCAU);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ncau.xlsx", b_dt, null, "Nhu_cau_dao_tao");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt;
        b_dt = ns_dt.Fdt_NS_DT_KHDT_NAM_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAMTK", b_dt);

        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
    }
}