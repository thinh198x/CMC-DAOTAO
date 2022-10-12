using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cp : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_cp" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cp_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {

        //Phong
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
        se.P_TG_LUU(this.Title, "DT_PHONG", null);
        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_CTY", b_dt.Copy());
        //Hinh thuc
        b_dt = ns_ma.Fdt_NS_MA_QDINH_DR("3B");
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_HINHTHUC", b_dt);
        // Thang lương
        b_dt = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);

        DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
        //if (b_tusinh != null && b_tusinh.Rows.Count > 0)
        //{
        //    if (b_tusinh.Rows[0]["QUYETDINH"].Equals("TS"))
        //    {
        //        SO_QD.ReadOnly = false;
        //        SO_QD.Enabled = false;
        //    }
        //}
    }
    protected void xuat_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dtHinhThuc = ns_ma.Fdt_NS_MA_HTCTAC_DR();
            DataTable b_dtTrangThaiNV = ns_ma.Fdt_NS_MA_HTCTAC_DR();
            DataTable b_dtBoPhan = ns_tt.Fdt_MA_PHONG_LKE();
            DataTable b_dtCDanh = ns_mota_cv.Fdt_MOTA_CV_EXPORT_CD();
            DataTable b_dtNgachNN = ns_hdns.Fdt_HD_MA_NNNGHE_LKE_ALL();
            DataTable b_dtBacNN = ns_hdns.Fdt_HD_MA_BNNGHE_LKE_ALL("");
            DataTable b_dtNgheNghiep = ns_ma.Fdt_HD_MA_NNGHE_LKE_MATEN();
            DataTable b_dtChuyenMon = ns_ma.Fdt_HD_MA_CMON_LKE_ALL("");
            DataTable b_dtThangLuong = ns_ma.Fdt_NS_MA_TBL_LKE_ALL();
            DataTable b_dtNgachLuong = ns_ma.Fdt_NS_MA_NL_LKE_ALL();
            DataTable b_dtBacLuong = ns_ma.Fdt_NS_MA_BL_LKE_ALL_NL("");

            b_dtHinhThuc.TableName = "HINHTHUC";
            b_dtTrangThaiNV.TableName = "TRANGTHAINV";
            b_dtBoPhan.TableName = "BOPHAN";
            b_dtCDanh.TableName = "CDANH";
            b_dtNgachNN.TableName = "NGACHNN";
            b_dtBacNN.TableName = "BACNN";
            b_dtNgheNghiep.TableName = "NGHENGHIEP";
            b_dtChuyenMon.TableName = "CHUYENMON";
            b_dtThangLuong.TableName = "THANGLUONG";
            b_dtNgachLuong.TableName = "NGACHLUONG";
            b_dtBacLuong.TableName = "BACLUONG";
            DataSet b_ds = new DataSet();
            b_ds.Tables.Add(b_dtHinhThuc);
            b_ds.Tables.Add(b_dtTrangThaiNV);
            b_ds.Tables.Add(b_dtBoPhan);
            b_ds.Tables.Add(b_dtCDanh);
            b_ds.Tables.Add(b_dtNgachNN);
            b_ds.Tables.Add(b_dtBacNN);
            b_ds.Tables.Add(b_dtNgheNghiep);
            b_ds.Tables.Add(b_dtChuyenMon);
            b_ds.Tables.Add(b_dtThangLuong);
            b_ds.Tables.Add(b_dtNgachLuong);
            b_ds.Tables.Add(b_dtBacLuong);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_cp_IMPORT.xlsx", b_ds, null, "ns_cp_IMPORT");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void xuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            var b_dt = (DataTable)ns_qt.Faobj_NS_CP_LKE(so_the_luu.Value, ten_luu.Value, phong_luu.Value, chuyen.CNG_SO(ngayd_tk.Text),chuyen.CNG_SO(ngayc_tk.Text),tt_tk_luu.Value, 1, Int32.MaxValue)[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_ky");
            bang.P_SO_CSO(ref b_dt, "luong_cb,thunhap_thang,thuong_thang");
            b_dt.TableName = "DATA";
            if (b_dt.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cp.xls", b_dt, null, "ns_cp");
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = null;//ns_qt.Fdt_ns_cp_IN(so_id.Value);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            b_dt.TableName = "DATA";
            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
            string path = Server.MapPath("~");
            //2. Export biểu mẫu mẫu động
            //DataTable b_dt_mau = ns_ma.Fdt_NS_BIEUMAU_HD(b_lqd, NGAYD.Text);
            //if (b_dt_mau.Rows.Count > 0)
            //{
            //    string path = Server.MapPath("~");
            //    Word_dungchung.ExportWord(path + @"Templates\Bieu_mau_dong_quyetdinh\" + b_lqd + @"\" + b_dt_mau.Rows[0]["TEN"].ToString(), "bieu_mau_quyetdinh", b_ds, "B", Response);
            //}
            //else form.P_LOI(this, "Không tồn tại biểu mẫu");

            if (alqdinh.Value == "QD001") // Quyết định bổ nhiệm
            {
                path = path + @"Templates\ExportMau\ns\qt\ns_cp_QD0001.doc";
            }
            else if (alqdinh.Value == "QD002") // Quyết định điều động
            {
                path = path + @"Templates\ExportMau\ns\qt\ns_cp_QD0002.doc";
            }
            else if (alqdinh.Value == "QD003") // Quyết định miễn nhiệm
            {
                path = path + @"Templates\ExportMau\ns\qt\ns_cp_QD0003.doc";
            }
            else if (alqdinh.Value == "QD004") // Quyết định điều chuyển
            {
                path = path + @"Templates\ExportMau\ns\qt\ns_cp_QD0004.doc";
            }
            else if (alqdinh.Value == "QD005") // Quyết định điều chỉnh lương
            {
                path = path + @"Templates\ExportMau\ns\qt\ns_cp_QD0005.doc";
            }
            Word_dungchung.ExportMailMerge(path, "Quyet dinh.doc", b_ds_ep, Response);


        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
