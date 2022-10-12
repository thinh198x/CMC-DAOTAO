﻿using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_phongvan : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_phongvan" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_phongvan_P_KD();", true);
                MA_DX.Focus(); P_NHAN_DROP();
                // form.P_DROP_BANG(VONG_THI, Fdt_vthi()); 
                NGAY_XEPLICH.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        // mã nhân viên
        DataTable b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        bang.P_COPY_COL(ref b_dt, "MA", "SO_THE");
        bang.P_COPY_COL(ref b_dt, "TEN", "MA_TEN");
        se.P_TG_LUU(this.Title, "DT_NGUOI_PV", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_MAYEUCAU_TD", null);

        DataTable b_dt_vthi = new DataTable();
        b_dt_vthi.Columns.Add("MA", typeof(string));
        b_dt_vthi.Columns.Add("TEN", typeof(string));
        bang.P_THEM_TRANG(ref b_dt_vthi, 1, 0);
        bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "1", "Vòng 1" }, 1);
        bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "2", "Vòng 2" }, 2);
        bang.P_THEM_HANG(ref b_dt_vthi, new object[] { "3", "Vòng 3" }, 3);
        se.P_TG_LUU(this.Title, "DT_VONG_THI", b_dt_vthi.Copy());

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_PHONGVAN_EXP();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_xeplich,ngaythi_pv");
            bang.P_THAY_GTRI(ref b_dt, "VONG_THI", "1", "Vòng 1");
            bang.P_THAY_GTRI(ref b_dt, "VONG_THI", "2", "Vòng 2");
            bang.P_THAY_GTRI(ref b_dt, "VONG_THI", "3", "Vòng 3");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "1", "Đã gửi");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "2", "Đồng ý");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "3", "Không đồng ý");

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_PHONGVAN, TEN_BANG.NS_TD_PHONGVAN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_phongvan.xlsx", b_dt, null, "Xep_lich_thi_tuyen_phong_van");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
