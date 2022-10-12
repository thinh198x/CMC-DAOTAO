using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_kq : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_kq" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_kq_P_KD();", true);
                P_NHAN_DROP();
                NAM.Text = DateTime.Now.Year.ToString();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        try
        {
            // PHÒNG BAN
            DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE(); se.P_TG_LUU(this.Title, "DT_PHONG", b_dt.Copy());
            // THÁNG
            b_dt = hts_dungchung.Fdt_CHUNG_LKE("THANG");
            bang.P_CSO_SO(ref b_dt, "MA"); DataView dv = b_dt.DefaultView; dv.Sort = "ma"; DataTable sortedDT = dv.ToTable();
            se.P_TG_LUU(this.Title, "DT_THANG", sortedDT.Copy());
            se.P_TG_LUU(this.Title, "DT_MAYEUCAU_TD", null);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:Loi khong xac dinh:loi"); }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_EXP();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaythi1,ngaythi2,ngaythi3");

            bang.P_THAY_GTRI(ref b_dt, "ketqua1", "1", "Đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua1", "2", "Không đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua2", "1", "Đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua2", "2", "Không đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua3", "1", "Đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua3", "2", "Không đạt");

            bang.P_THAY_GTRI(ref b_dt, "ketqua_chung", "0", "Chờ thi tuyển");
            bang.P_THAY_GTRI(ref b_dt, "ketqua_chung", "1", "Đạt");
            bang.P_THAY_GTRI(ref b_dt, "ketqua_chung", "2", "Không đạt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_KQ, TEN_BANG.NS_TD_KQ);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_kq_excel.xlsx", b_dt, null, "Cap_nhat_ket_qua_thi_tuyen");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
