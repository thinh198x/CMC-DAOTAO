using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_qhe : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hs/sns_hs.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_qhe" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qhe_P_KD('');", true);
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_LQH_DR();
        se.P_TG_LUU(this.Title, "DT_LQHE", b_dt);

        //Quoc tich
        //b_dt = ns_ma.Fdt_NS_MA_NUOC_DR();
        ////bang.P_THEM_TRANG(ref b_dt, 0);
        //se.P_TG_LUU(this.Title, "DT_QT", b_dt.Copy());
        //Tinh thanh pho
        //b_dt = ns_ma.Fdt_NS_MA_TT_DR();
        ////bang.P_THEM_TRANG(ref b_dt, 0);
        //se.P_TG_LUU(this.Title, "DT_TTP", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_NSQH", null);
        se.P_TG_LUU(this.Title, "DT_NSXP", null);
        se.P_TG_LUU(this.Title, "DT_THQH", null);
        se.P_TG_LUU(this.Title, "DT_THXP", null);
        se.P_TG_LUU(this.Title, "DT_TTQH", null);
        se.P_TG_LUU(this.Title, "DT_TTXP", null);
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_so_the = SO_THE.Text;
            if (string.IsNullOrEmpty(b_so_the))
            {
                form.P_LOI(this, "loi:Phải chọn mã cán bộ cần xuất:loi");
            }
            else
            {
                DataTable b_dt = ns_tt.Fdt_NS_QHE_EXP(b_so_the); 
                bang.P_SO_CNG(ref b_dt, "ngaysinh");
                bang.P_SO_CNG(ref b_dt, "ngay_cmt");
                bang.P_SO_CNG(ref b_dt, "ngayd");
                bang.P_SO_CNG(ref b_dt, "ngayc");
                bang.P_THAY_GTRI(ref b_dt, "phuthuoc", "K", "Không");
                bang.P_THAY_GTRI(ref b_dt, "phuthuoc", "C", "Có");
                b_dt.TableName = "DATA";
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_QHE, TEN_BANG.NS_QHE);
                Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hs/ns_qhe.xlsx", b_dt, null, "Quan_he_nhan_than");
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        // thông tin nhân viên
        var b_dt = bang.Fdt_TAO_BANG(new string[] { "SO_THE", "HO_TEN" }, new object[] { SO_THE.Text, aho_ten.Value });
        b_dt.Rows.Add(new object[] { SO_THE.Text, aho_ten.Value });
        b_dt.TableName = "DATA";
        // các thông tin khác
        DataTable b_dt_lqh = ns_ma.Fdt_NS_MA_LQH_DR();
        DataTable b_dt_quoctich = hts_dungchung.Fdt_QUOCTICH_DR();
        DataTable b_dt_tinhthanh = ns_ma.Fdt_NS_MA_TT_DR();
        DataTable b_dt_quanhuyen = hts_dungchung.Fdt_NS_MA_QH_DR("0");
        DataTable b_dt_xaphuong = hts_dungchung.Fdt_NS_MA_XP_DR("0");
        // đặt tên datatable
        b_dt_quoctich.TableName = "DATA1";
        b_dt_lqh.TableName = "DATA10";
        b_dt_tinhthanh.TableName = "DATA14";
        b_dt_quanhuyen.TableName = "DATA15";
        b_dt_xaphuong.TableName = "DATA16";
        // add vào dataset
        DataSet b_ds = new DataSet();
        b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dt_lqh);
        b_ds.Tables.Add(b_dt_quoctich);
        b_ds.Tables.Add(b_dt_tinhthanh);
        b_ds.Tables.Add(b_dt_quanhuyen);
        b_ds.Tables.Add(b_dt_xaphuong);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_QHE, TEN_BANG.NS_QHE);
        // xuất file
        Excel_dungchung.ExportTemplate("Templates/importhsns/ns_qhe.xls", b_ds, null, "ns_qhe");
    }

 
}
