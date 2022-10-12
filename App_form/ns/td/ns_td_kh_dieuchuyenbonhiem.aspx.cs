using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_kh_dieuchuyenbonhiem : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_kh_dieuchuyenbonhiem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_kh_dieuchuyenbonhiem_P_KD('');", true);
                //NAM.Text = DateTime.Now.Year.ToString();
                //NAM.Focus(); 
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        //Đơn vị tìm kiếm
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt.Copy());

        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_DONVI", b_dt.Copy());
        //se.P_TG_LUU(this.Title, "DT_BAN", null);
        //se.P_TG_LUU(this.Title, "DT_PHONG", null);
        //DataTable b_dt_temp = ht_madvi.Fdt_MA_DVI_CD();
        //bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "" }, 0);
        //se.P_TG_LUU(this.Title, "DT_DONVI_TK", b_dt.Copy());
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_KH_DCBN_EXPORT();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngaycan_ns");

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_KH_DCBN, TEN_BANG.NS_TD_KH_DCBN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_kh_nam" +
                ".xlsx", b_dt, null, "Chuc_danh_kiem_nhiem");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void XuatFileMau_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_congty = ht_madvi.Fdt_MA_DVI_XEM();
            DataTable b_dt_banphong = ns_td.Fdt_MA_PHONG_EXP();
            DataTable b_dt_phongbphan = ns_td.Fdt_MA_PHONG_EXP();
            DataTable b_dt_chucdanh = ns_td.Fdt_MA_CDANH_EXP();
            DataTable b_dt_capbac = ns_td.Fdt_MA_LVCDANH_EXP();

            b_dt_congty.TableName = "DATA1";
            b_dt_banphong.TableName = "DATA2";
            b_dt_phongbphan.TableName = "DATA3";
            b_dt_chucdanh.TableName = "DATA4";
            b_dt_capbac.TableName = "DATA5";

            b_ds.Tables.Add(b_dt_congty);
            b_ds.Tables.Add(b_dt_banphong);
            b_ds.Tables.Add(b_dt_phongbphan);
            b_ds.Tables.Add(b_dt_chucdanh);
            b_ds.Tables.Add(b_dt_capbac);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TD_KH_DCBN, TEN_BANG.NS_TD_KH_DCBN);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_kh_nam.xls", b_ds, null, "Ke_hoach_nam" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}