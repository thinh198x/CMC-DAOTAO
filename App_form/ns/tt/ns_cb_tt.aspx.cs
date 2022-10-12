using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
public partial class f_ns_cb_tt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hs/sns_hs.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_cb_tt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cb_tt_P_KD('" + khac.Fs_TMUCF(b_s) + "','" + iurl.ClientID + "','" + b_ma_dvi + "','" + b_so_the + "');", true);
                P_NHAN_DROP(b_se.ma_dvi); so_the.Focus();
            }
        }

        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    private void P_NHAN_DROP(string b_ma_dvi)
    {
        //Ma dvi
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PH", b_dt.Copy());
        //Gioi tinh
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("GT");
        //bang.P_THEM_TRANG(ref b_dt, 0);
        se.P_TG_LUU(this.Title, "DT_GT", b_dt.Copy());
        //Tinh trang hon nhan
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("HN");
        se.P_TG_LUU(this.Title, "DT_TTHN", b_dt.Copy());

        //Loai nhan vien
        b_dt = ht_dungchung.Fdt_HD_MA_LOAI_NV_DR();
        se.P_TG_LUU(this.Title, "DT_LNV", b_dt.Copy());
        //HT tinh luong
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, new string[] { "S", "S" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "01", "Không" });
        bang.P_THEM_HANG(ref b_dt, new string[] { "02", "Có" });
        se.P_TG_LUU(this.Title, "DT_HTTL", b_dt.Copy());
        //Ngan hang
        b_dt = ns_ma.Fdt_NS_MA_NHA_DR();

        se.P_TG_LUU(this.Title, "DT_NH", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_CNNH", null);


        //Loai nhan vien
        // b_dt = ht_dungchung.Fdt_PHONG_LEVEL_DR(null,1);

        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_DONVI", b_dt.Copy());

        se.P_TG_LUU(this.Title, "DT_BAN", null);
        se.P_TG_LUU(this.Title, "DT_PHONG", null);

        // Mã phân bổ
        b_dt = ns_ma.Fdt_NS_MA_PBO_DR();
        se.P_TG_LUU(this.Title, "DT_MA_PBO", b_dt.Copy());

        b_dt = ns_ma.Fdt_NS_BCDANH_DR();
        se.P_TG_LUU(this.Title, "DT_BCDANH", b_dt.Copy());

        b_dt = ns_ma.Fdt_NS_MA_QTRR_DR();
        se.P_TG_LUU(this.Title, "DT_QTRR", b_dt.Copy());

        b_dt = ns_ma.Fdt_NS_MA_UBCK_DR();
        se.P_TG_LUU(this.Title, "DT_UBCK", b_dt.Copy());

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("VUNG");
        se.P_TG_LUU(this.Title, "DT_VUNG", b_dt.Copy());

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("KHOI");
        se.P_TG_LUU(this.Title, "DT_KHOI", b_dt.Copy());

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DTNV");
        se.P_TG_LUU(this.Title, "DT_DTNV", b_dt.Copy());

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("ADDRESS");
        se.P_TG_LUU(this.Title, "DT_ADDRESS", b_dt.Copy());

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("BRANCH");
        se.P_TG_LUU(this.Title, "DT_BRANCH", b_dt.Copy());

        b_dt = ns_ma.Fdt_NS_MA_LQH_DR();
        se.P_TG_LUU(this.Title, "DT_QUANHE_LL", b_dt);
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hs.Fdt_NS_CB_EXCEL();
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hs/ns_cb_tt.xlsx", b_dt, null, "Ho_so_nhan_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
