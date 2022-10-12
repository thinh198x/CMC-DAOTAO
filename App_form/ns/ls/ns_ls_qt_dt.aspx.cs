using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_qt_dt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_qt_dt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_qt_dt_P_KD();", true);
                
                //DataTable b_dt = Fdt_TTKH(); 
                //form.P_LIST_BANG(tt, b_dt);
                //b_dt = Fdt_KQ(); 
                //form.P_LIST_BANG(kq, b_dt);
                //SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_LS_QT_DT_LKE_ALL(so_the_an.Value);
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");           
            bang.P_THAY_GTRI(ref b_dt, "dvi_tc", "DTNB", "Đào tạo nội bộ");
            bang.P_THAY_GTRI(ref b_dt, "kq", "D", "Đạt"); 
            bang.P_THAY_GTRI(ref b_dt, "kq", "K", "Không đạt");
            bang.P_THAY_GTRI(ref b_dt, "tt", "H", "Hoàn thành");
            bang.P_THAY_GTRI(ref b_dt, "tt", "T", "Đang thi");
            bang.P_THAY_GTRI(ref b_dt, "tt", "D", "Đã thi");
            bang.P_THAY_GTRI(ref b_dt, "tt", "C", "Chưa hoàn thành"); 
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "", "Chưa phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "1", "Phê duyệt");
            //bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "0", "Chưa phê duyệt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_LS_QT_DT, TEN_BANG.NS_LS_QT_DT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_qt_dt.xlsx", b_dt, null, "QuaTrinhDaoTao");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void excel_mau_Click(object sender, EventArgs e)
    {
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_LS_QT_DT, TEN_BANG.NS_LS_QT_DT);
        Excel_dungchung.ExportTemplate("Templates/importhsns/ns_ls_qt_dt.xls", "ns_ls_qt_dt");
    }

    //public static DataTable Fdt_TTKH()
    //{
    //    DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "H", "Hoàn thành" });
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Đang thi" });
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "D", "Đã thi" });       
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "C", "Chưa hoàn thành" });
    //    return b_dt;
    //}
    //public static DataTable Fdt_KQ()
    //{
    //    DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "D", "Đạt" });       
    //    bang.P_THEM_HANG(ref b_dt, new object[] { "K", "Không đạt" });
    //    return b_dt;
    //}
    //private void P_NHAN_DROP()
    //{
    //    DataTable b_dt = ns_ma.Fdt_NS_MA_XLOAI_DR();
    //    xeploai.DataSource = b_dt; xeploai.DataBind();
    //}
}
