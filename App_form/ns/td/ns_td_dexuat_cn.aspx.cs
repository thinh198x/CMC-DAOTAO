using System;
using System.Data;
using System.Web.UI;
using Cthuvien;
public partial class f_ns_td_dexuat_cn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_dexuat_cn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_dexuat_cn_P_KD('');", true);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                se.se_nsd b_se = new se.se_nsd();
                MA.Text = ht_dungchung.Fdt_AutoGenCode("DX", "NS_TD_DEXUAT", "MA");
                MA.Focus();
                P_NHAN_DROP(b_se.ma_dvi);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_DEXUAT_CN_EXCEL();
            bang.P_SO_CNG(ref b_dt, "ngay_can_ns,ngay_pd,ngay_dexuat");
            bang.P_SO_CSO(ref b_dt, "mucluong_tu,mucluong_den");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai_pd", "2", "Không phê duyệt");

            bang.P_THAY_GTRI(ref b_dt, "lydo_tuyendung", "TM", "Tuyển mới");
            bang.P_THAY_GTRI(ref b_dt, "lydo_tuyendung", "TTT", "Tuyển thay thế");
            bang.P_THAY_GTRI(ref b_dt, "lydo_tuyendung", "TTV", "Tuyển thời vụ");
            bang.P_THAY_GTRI(ref b_dt, "lydo_tuyendung", "TK", "Tuyển khác");

            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_DEXUAT_CN, TEN_BANG.NS_TD_DEXUAT_CN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_dexuat.xlsx", b_dt, null, "Kehoachtuyendungnam");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    } 
    private void P_NHAN_DROP(string b_ma_dvi)
    {
        //Ma dvi
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //bang.P_THEM_HANG(ref b_dt, new object[] { b_ma_dvi, "----------------------Tất cả----------------------", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt.Copy());

        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_DONVI", b_dt.Copy());

        se.P_TG_LUU(this.Title, "DT_BAN", null);
        se.P_TG_LUU(this.Title, "DT_PHONG", null);
        // mã nhân viên
        b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        bang.P_COPY_COL(ref b_dt, "MA", "SO_THE");
        bang.P_COPY_COL(ref b_dt, "TEN", "MA_TEN");
        se.P_TG_LUU(this.Title, "DT_NGUOICHIU_TN", b_dt.Copy());
        // loại  hợp đồng
        b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        se.P_TG_LUU(this.Title, "DT_LHD", b_dt.Copy());
        // kinh nghiệm 
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TD_DEXUAT");
        se.P_TG_LUU(this.Title, "DT_KINHNGHIEM", b_dt);

    }
}
