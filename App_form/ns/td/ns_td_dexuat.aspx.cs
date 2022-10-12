using System;
using System.Data;
using System.Web.UI;
using Cthuvien;
public partial class f_ns_td_dexuat : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_dexuat" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_dexuat_P_KD('');", true);
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
            DataTable b_dt = ns_td.Fdt_NS_TD_DEXUAT_EXCEL();
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
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_DEXUAT, TEN_BANG.NS_TD_DEXUAT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_dexuat.xlsx", b_dt, null, "Kehoachtuyendungnam");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void nhap2_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt_p = ht_dungchung.Fdt_MA_PHONG_LKE();
            DataTable b_dt_cd = ht_dungchung.Fdt_MA_CDANH_DR();
            b_dt_p.TableName = "DATA1";
            b_dt_cd.TableName = "DATA2";
            DataSet b_ds = new DataSet();
            b_ds.Tables.Add(b_dt_p);
            b_ds.Tables.Add(b_dt_cd);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TD_DEXUAT, TEN_BANG.NS_TD_DEXUAT);
            Excel_dungchung.ExportTemplate("Templates/importmau/File_mau_kehoach_nam.xls", b_ds, null, "File_mau_kehoach_nam");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP(string b_ma_dvi)
    {
        //Ma dvi
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        //bang.P_THEM_HANG(ref b_dt, new object[] { b_ma_dvi, "----------------------Tất cả----------------------", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);

        //b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        //se.P_TG_LUU(this.Title, "DT_DONVI", b_dt); 
        //se.P_TG_LUU(this.Title, "DT_BAN", null); 

        // mã nhân viên
        b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO");
        bang.P_DOI_TENCOL(ref b_dt, "SO_THE", "MA");
        bang.P_DOI_TENCOL(ref b_dt, "MA_TEN", "TEN");
        se.P_TG_LUU(this.Title, "DT_NGUOICHIU_TN", b_dt);

        // loại  hợp đồng
        b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        se.P_TG_LUU(this.Title, "DT_LHD", b_dt);

        // kinh nghiệm 
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TD_DEXUAT");
        se.P_TG_LUU(this.Title, "DT_KINHNGHIEM", b_dt);

    }
}
