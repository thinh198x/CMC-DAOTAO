using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;
public partial class f_ns_cb : fmau
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
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_cb" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cb_P_KD('" + khac.Fs_TMUCF(b_s) + "','" + iurl.ClientID + "','" + b_ma_dvi + "');", true);
                P_NHAN_DROP(b_se.ma_dvi); so_the.Focus();
            }
        }
        catch (Exception ex)
        {
            form.P_LOI(this, ex.Message);
        }
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
    protected void nhap2_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds_kq = ns_hs.Faobj_NS_CB_LY_LICH_TRICH_NGANG(so_id.Value);
            DataTable b_dt1 = b_ds_kq.Tables[0];
            DataTable b_dt2 = b_ds_kq.Tables[1];
            DataTable b_dt3 = b_ds_kq.Tables[2];
            DataTable b_dt4 = b_ds_kq.Tables[3];
            DataTable b_dt5 = b_ds_kq.Tables[4];
            DataTable b_dt6 = b_ds_kq.Tables[5];
            DataTable b_dt7 = b_ds_kq.Tables[6];
            DataTable b_dt8 = b_ds_kq.Tables[7];
            b_dt1.TableName = "TTCN";
            b_dt2.TableName = "TRINHDO";
            bang.P_THAY_GTRI(ref b_dt1, "GIOI_TINH", "NU", "Nữ");
            bang.P_THAY_GTRI(ref b_dt1, "GIOI_TINH", "NAM", "Nam");

            bang.P_THAY_GTRI(ref b_dt2, "capdt", "DH", "Đại học");
            bang.P_THAY_GTRI(ref b_dt2, "capdt", "CD", "Cao đẳng");
            bang.P_THAY_GTRI(ref b_dt2, "capdt", "THS", "Thạc sỹ");
            bang.P_THAY_GTRI(ref b_dt2, "capdt", "TS", "Tiến sỹ");
            bang.P_THAY_GTRI(ref b_dt2, "capdt", "TC", "Trung cấp");

            bang.P_THAY_GTRI(ref b_dt2, "BANGCAP", "BC", "Bằng cấp");
            bang.P_THAY_GTRI(ref b_dt2, "BANGCAP", "CC", "Chứng chỉ");
            b_dt3.TableName = "KINHNGHIEM";
            b_dt4.TableName = "QH";
            b_dt5.TableName = "QTCT";
            b_dt6.TableName = "QTKT";
            b_dt7.TableName = "QTKL";
            b_dt8.TableName = "QTDT";
            bang.P_SO_CNG(ref b_dt1, "NAM_SINH,NGAY_CAP_CMT");
            bang.P_SO_CNG(ref b_dt4, "NGAYSINH");
            bang.P_SO_CTH(ref b_dt5, "TUTHANG,DENTHANG");
            bang.P_SO_CNG(ref b_dt6, "THOIGIAN");
            bang.P_SO_CNG(ref b_dt7, "THOIGIAN");

            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt1.Copy());
            b_ds_ep.Tables.Add(b_dt2.Copy());
            b_ds_ep.Tables.Add(b_dt3.Copy());
            b_ds_ep.Tables.Add(b_dt4.Copy());
            b_ds_ep.Tables.Add(b_dt5.Copy());
            b_ds_ep.Tables.Add(b_dt6.Copy());
            b_ds_ep.Tables.Add(b_dt7.Copy());
            b_ds_ep.Tables.Add(b_dt8.Copy());
            string path = Server.MapPath("~");

            string b_goc = "", b_ten = "", b_mr = "";
            se.se_nsd b_se = new se.se_nsd();
            string b_tm = Server.MapPath("~/Outputs/file_nhap");
            byte[] bArr = null;
            if (!string.IsNullOrEmpty(b_dt1.Rows[0]["IURL"].ToString()))
            {
                b_ten = "F_" + b_se.ma_dvi + "_" + (b_se.nsd).Replace("/", "-");
                b_goc = khac.Fs_tmFile() + "\\" + b_dt1.Rows[0]["IURL"].ToString();
                int b_i = b_goc.LastIndexOf('.');
                b_mr = (b_i > 0) ? b_goc.Substring(b_i) : "";
            }
            if (b_mr != "")
            {
                string b_file = b_tm + "\\" + b_ten + b_mr;
                if (File.Exists(b_file))
                {
                    System.Drawing.Image rasterImage = System.Drawing.Image.FromFile(b_tm + "\\" + b_ten + b_mr);
                    bArr = ImageToByteArray(rasterImage);
                }
            }
            else
            {
                bArr = null;
            }


            // ghi logns_cb
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_CB, TEN_BANG.NS_CB);
            //Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\ns\qt\SO_YEU_LY_LICH.doc", "LY_LICH_TRICH_NGANG.docx", b_ds_ep, Response); 
            Word_dungchung.ExportMailMergeImages(path + @"Templates\ExportMau\ns\qt\SO_YEU_LY_LICH.doc", "LY_LICH_TRICH_NGANG.docx", bArr, b_ds_ep, Response);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_hs.Faobj_NS_CB_LKE_ALL(aPhong.Value, aTrangthai.Value, so_the_tk.Text, ten_tk.Text);
            DataTable b_dt = (DataTable)a_obj[0];
            bang.P_SO_CNG(ref b_dt, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngay_bd_hopdong,ngaythamgia,ngaycap_hchieu,ngaycap_mst");
            bang.P_THAY_GTRI(ref b_dt, "ttr", "0", "Đang làm việc");
            bang.P_THAY_GTRI(ref b_dt, "ttr", "1", "Nghỉ việc");

            bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "CT", "Đối tượng cư trú");
            bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "KCT", "Đối tượng không cư trú");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CB, TEN_BANG.NS_CB);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hs/ns_cb.xlsx", b_dt, null, "Ho_so_nhan_vien");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void export_excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_gt = hts_dungchung.Fdt_CHUNG_LKE("GT");
            DataTable b_dt_quoctich = hts_dungchung.Fdt_QUOCTICH_DR();
            DataTable b_dt_dantoc = hts_dungchung.Fdt_NS_MA_DT_DR();
            DataTable b_dt_tongiao = hts_dungchung.Fdt_NS_MA_TG_DR();
            DataTable b_dt_tinhthanh = ns_ma.Fdt_NS_MA_TT_DR();
            DataTable b_dt_quanhuyen = hts_dungchung.Fdt_NS_MA_QH_DR("0");
            DataTable b_dt_xaphuong = hts_dungchung.Fdt_NS_MA_XP_DR("0");
            DataTable b_dt_donvi = ht_madvi.Fdt_MA_DVI_XEM();
            DataTable b_dt_ban = ht_dungchung.Fdt_PHONG_LEVEL_DR("0", 2);
            DataTable b_dt_phong = ht_dungchung.Fdt_PHONG_LEVEL_DR("0", 3);
            DataTable b_dt_nhom = ns_ma.Fdt_NS_MA_PBO_DR(); ;
            DataTable b_dt_nganhang = hts_dungchung.Fdt_NGANHANG();
            DataTable b_dt_nhomcd = hts_dungchung.Fdt_NHOM_CDANH_CV();
            DataTable b_dt_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG("0");
            DataTable b_dt_baccd = hts_dungchung.Fdt_BAC_CDANH_CV();
            DataTable b_dt_honnhan = hts_dungchung.Fdt_CHUNG_LKE("HN");
            DataTable b_dt_chinhanh = ns_ma.Fdt_NS_MA_CNNH_DR("0");

            b_dt_gt.TableName = "DATA1";
            b_dt_quoctich.TableName = "DATA2";
            b_dt_dantoc.TableName = "DATA3";
            b_dt_tongiao.TableName = "DATA4";
            b_dt_tinhthanh.TableName = "DATA5";
            b_dt_quanhuyen.TableName = "DATA6";
            b_dt_xaphuong.TableName = "DATA7";
            b_dt_donvi.TableName = "DATA8";
            b_dt_ban.TableName = "DATA9";
            b_dt_phong.TableName = "DATA10";
            b_dt_nhom.TableName = "DATA11";
            b_dt_nganhang.TableName = "DATA12";
            b_dt_nhomcd.TableName = "DATA13";
            b_dt_cdanh.TableName = "DATA14";
            b_dt_baccd.TableName = "DATA15";
            b_dt_honnhan.TableName = "DATA16";
            b_dt_chinhanh.TableName = "DATA17";
            b_ds.Tables.Add(b_dt_gt);
            b_ds.Tables.Add(b_dt_quoctich);
            b_ds.Tables.Add(b_dt_dantoc);
            b_ds.Tables.Add(b_dt_tongiao);
            b_ds.Tables.Add(b_dt_tinhthanh);
            b_ds.Tables.Add(b_dt_quanhuyen);
            b_ds.Tables.Add(b_dt_xaphuong);
            b_ds.Tables.Add(b_dt_donvi);
            b_ds.Tables.Add(b_dt_ban);
            b_ds.Tables.Add(b_dt_phong);
            b_ds.Tables.Add(b_dt_nhom);
            b_ds.Tables.Add(b_dt_nganhang);
            b_ds.Tables.Add(b_dt_nhomcd);
            b_ds.Tables.Add(b_dt_cdanh);
            b_ds.Tables.Add(b_dt_baccd);
            b_ds.Tables.Add(b_dt_honnhan);
            b_ds.Tables.Add(b_dt_chinhanh);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_cb_excel.xls", b_ds, null, "ns_cb_excel" + DateTime.Now.Second);

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }

    public byte[] ImageToByteArray(System.Drawing.Image imageIn)
    {
        using (var ms = new MemoryStream())
        {
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }
    }
}
