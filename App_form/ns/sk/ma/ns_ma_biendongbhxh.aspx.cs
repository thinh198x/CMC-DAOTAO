using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_biendongbhxh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/sk/ma/ns_ma_biendongbhxh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_biendongbhxh_P_KD();", true);
            //P_NHAN_DROP();
            MA.Focus();
        }
    }
    
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_ma.Faobj_NS_MA_BIENDONGBHXH_LKE(1, int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "T", "Tăng");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "G", "Giảm");
            bang.P_THAY_GTRI(ref b_dt, "ten_nhom_biendong", "DC", "Điều chỉnh");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "A", "Áp Dụng");
            bang.P_THAY_GTRI(ref b_dt, "ten_trang_thai", "N", "Ngừng Áp Dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_BIENDONGBHXH, TEN_BANG.NS_MA_BIENDONGBHXH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_biendongbhxh.xlsx", b_dt, null, "Danh_muc_biendongbhxh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
