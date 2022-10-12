using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_khud_Excel_Import : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/khud/khud_Excel_Import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "khud_Excel_import_KD();", true);

            if (se.Fs_DUYET() != "IE") kthuoc.Value = "500,240";
            //se.P_KQ_XOA("file", "file"); 
        }
        //ScriptManager scriptManager = ScriptManager.GetCurrent(this.Page);
        //scriptManager.RegisterPostBackControl(this.Nhap2);
        //scriptManager.RegisterPostBackControl(this.nhap);
    }
    protected void nhap2_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nv = nv.SelectedValue;
            DataSet b_ds = new DataSet();
            switch (b_nv)
            {
                case "ns_cb_excel":
                    {
                        // lay du lieu phong
                        DataTable b_dt_quoctich = hts_dungchung.Fdt_QUOCTICH_DR();
                        DataTable b_dt_gt = hts_dungchung.Fdt_CHUNG_LKE("GT");
                        DataTable b_dt_nhom = hts_dungchung.Fdt_NHOM_DR();
                        DataTable b_dt_phong = hts_dungchung.Fdt_MA_PHONG_LKE_ALL();
                        DataTable b_dt_noicap = hts_dungchung.Fdt_NOICAP_CMT();
                        DataTable b_dt_nhan = hts_dungchung.Fdt_CHUNG_LKE("NHAN");
                        DataTable b_dt_nganhang = hts_dungchung.Fdt_NGANHANG();
                        DataTable b_dt_nhomcd = hts_dungchung.Fdt_NHOM_CDANH_CV();
                        DataTable b_dt_cdanh = hts_dungchung.Fdt_CDANH_CV();
                        DataTable b_dt_baccd = hts_dungchung.Fdt_BAC_CDANH_CV();
                        DataTable b_dt_dantoc = hts_dungchung.Fdt_NS_MA_DT_DR();
                        DataTable b_dt_tongiao = hts_dungchung.Fdt_NS_MA_TG_DR();
                        DataTable b_dt_honnhan = hts_dungchung.Fdt_CHUNG_LKE("HN");
                        DataTable b_dt_tinhthanh = ns_ma.Fdt_NS_MA_TT_DR();
                        DataTable b_dt_quanhuyen = hts_dungchung.Fdt_NS_MA_QH_DR("0");
                        DataTable b_dt_xaphuong = hts_dungchung.Fdt_NS_MA_XP_DR("0");

                        b_dt_quoctich.TableName = "DATA1";
                        b_dt_gt.TableName = "DATA2";
                        b_dt_nhom.TableName = "DATA3";
                        b_dt_phong.TableName = "DATA4";
                        b_dt_noicap.TableName = "DATA5";
                        b_dt_nhan.TableName = "DATA6";
                        b_dt_nganhang.TableName = "DATA7";
                        b_dt_nhomcd.TableName = "DATA8";
                        b_dt_cdanh.TableName = "DATA9";
                        b_dt_baccd.TableName = "DATA10";
                        b_dt_dantoc.TableName = "DATA11";
                        b_dt_tongiao.TableName = "DATA12";
                        b_dt_honnhan.TableName = "DATA13";
                        b_dt_tinhthanh.TableName = "DATA14";
                        b_dt_quanhuyen.TableName = "DATA15";
                        b_dt_xaphuong.TableName = "DATA16";
                        b_ds.Tables.Add(b_dt_quoctich);
                        b_ds.Tables.Add(b_dt_gt);
                        b_ds.Tables.Add(b_dt_nhom);
                        b_ds.Tables.Add(b_dt_phong);
                        b_ds.Tables.Add(b_dt_noicap);
                        b_ds.Tables.Add(b_dt_nhan);
                        b_ds.Tables.Add(b_dt_nganhang);
                        b_ds.Tables.Add(b_dt_nhomcd);
                        b_ds.Tables.Add(b_dt_cdanh);
                        b_ds.Tables.Add(b_dt_baccd);
                        b_ds.Tables.Add(b_dt_dantoc);
                        b_ds.Tables.Add(b_dt_tongiao);
                        b_ds.Tables.Add(b_dt_honnhan);
                        b_ds.Tables.Add(b_dt_tinhthanh);
                        b_ds.Tables.Add(b_dt_quanhuyen);
                        b_ds.Tables.Add(b_dt_xaphuong);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_cb_excel.xls", b_ds, null, "ns_cb_excel");
                    }
                    break;
                case "NS_PHONG":
                    {
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_phong.xls", new DataTable(), null, "ns_phong");
                    }
                    break;
                case "NS_HD":
                    {
                        DataTable b_dt_loaihd = ns_ma.Fdt_NS_MA_LHD_DR();
                        DataTable b_dt_donvict = ns_tt.Fdt_MA_PHONG_LKE();
                        DataTable b_dt_chucvu = hts_dungchung.Fdt_MA_CVU_LKE();
                        DataTable b_dt_nhomcdcv = hts_dungchung.Fdt_NHOM_CDANH_CV();
                        DataTable b_dt_chucdanhcv = hts_dungchung.Fdt_CDANH_CV();
                        DataTable b_dt_baccdcv = hts_dungchung.Fdt_BAC_CDANH_CV();
                        //DataTable b_dt_traluong = hts_dungchung.Fdt_NGANHANG();
                        //DataTable b_dt_loailuong = hts_dungchung.Fdt_NGANHANG();

                        b_dt_loaihd.TableName = "DATA1";
                        b_dt_donvict.TableName = "DATA2";
                        b_dt_chucvu.TableName = "DATA3";
                        b_dt_nhomcdcv.TableName = "DATA4";
                        b_dt_chucdanhcv.TableName = "DATA5";
                        b_dt_baccdcv.TableName = "DATA6";
                        //b_dt_traluong.TableName = "DATA7";
                        //b_dt_loailuong.TableName = "DATA8";

                        b_ds.Tables.Add(b_dt_loaihd);
                        b_ds.Tables.Add(b_dt_donvict);
                        b_ds.Tables.Add(b_dt_chucvu);
                        b_ds.Tables.Add(b_dt_nhomcdcv);
                        b_ds.Tables.Add(b_dt_chucdanhcv);
                        b_ds.Tables.Add(b_dt_baccdcv);
                        //b_ds.Tables.Add(b_dt_traluong);
                        //b_ds.Tables.Add(b_dt_loailuong);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_hd_xong.xls", b_ds, null, "ns_hd_xong" + DateTime.Now.Second);
                    }
                    break;
                case "NS_QH":
                    {
                        DataTable b_dt_quanhe = ns_ma.Fdt_NS_MA_LQH_DR();
                        DataTable b_dt_gioitinh = hts_dungchung.Fdt_CHUNG_LKE("GT");

                        b_dt_quanhe.TableName = "DATA1";
                        b_dt_gioitinh.TableName = "DATA2";

                        b_ds.Tables.Add(b_dt_quanhe);
                        b_ds.Tables.Add(b_dt_gioitinh);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_qh.xls", b_ds, null, "ns_qh" + DateTime.Now.Second);
                    }
                    break;
                case "NS_MA_NCDANH":
                    {
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_ma_ncdanh.xls", b_ds, null, "ns_ma_ncdanh" + DateTime.Now.Second);
                    }
                    break;
                case "NS_MA_CDANH":
                    {
                        DataTable b_dt_nhom_cd = ns_ma.Fdt_NS_MA_NCDANH_DR();
                        b_dt_nhom_cd.TableName = "DATA1";
                        b_ds.Tables.Add(b_dt_nhom_cd);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_ma_cdanh.xls", b_ds, null, "ns_ma_cdanh" + DateTime.Now.Second);
                    }
                    break;
                case "NS_KTKL_KT":
                    {
                        DataTable b_dt_hinhthuc = hts_dungchung.Fdt_MA_HINHTHUC_DR();
                        DataTable b_dt_cap_kt = hts_dungchung.Fdt_MA_CAP_KTKL_DR();
                        DataTable b_dt_noi_kt = hts_dungchung.PNS_MA_NOI_KTKL_DR();

                        b_dt_hinhthuc.TableName = "DATA1";
                        b_dt_cap_kt.TableName = "DATA2";
                        b_dt_noi_kt.TableName = "DATA3";

                        b_ds.Tables.Add(b_dt_hinhthuc);
                        b_ds.Tables.Add(b_dt_cap_kt);
                        b_ds.Tables.Add(b_dt_noi_kt);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_kt.xls", b_ds, null, "ns_kt" + DateTime.Now.Second);
                    }
                    break;
                case "NS_KTKL_KL":
                    {
                        DataTable b_dt_hinhthuc = hts_dungchung.Fdt_MA_HINHTHUC_KL();
                        DataTable b_dt_cap_kt = hts_dungchung.Fdt_MA_CAP_KTKL_DR();
                        DataTable b_dt_noi_kt = hts_dungchung.PNS_MA_NOI_KTKL_DR();

                        b_dt_hinhthuc.TableName = "DATA1";
                        b_dt_cap_kt.TableName = "DATA2";
                        b_dt_noi_kt.TableName = "DATA3";

                        b_ds.Tables.Add(b_dt_hinhthuc);
                        b_ds.Tables.Add(b_dt_cap_kt);
                        b_ds.Tables.Add(b_dt_noi_kt);
                        Excel_dungchung.ExportTemplate("Templates/importmau/ns_kl.xls", b_ds, null, "ns_kl" + DateTime.Now.Second);
                    }
                    break;
                default:
                    break;
            }

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            // ------------------- Đoạn này giữ nguyên-------------------------//
            ten.Text = ""; string b_kq = "";
            string b_loai = "";
            string b_excel = kytu.C_NVL(chon_file.PostedFile.FileName), b_tm, b_ten;
            string b_ktraten = chon_file.FileName;
            if (b_excel == "") throw new Exception("loi:Chọn File:loi");
            ten.Text = b_excel; b_excel = b_excel.ToUpper();
            b_tm = Server.MapPath("~/file_nhap");
            if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
            if (b_excel.Contains(".DBF")) b_loai = ".dbf";
            else if (b_excel.Contains(".XLSX")) b_loai = ".xlsx";
            else if (b_excel.Contains(".XLS")) b_loai = ".xls";
            else throw new Exception("loi:Chỉ mở File Excel, Dbf:loi");

            se.se_nsd b_nsd = new se.se_nsd();
            b_tm = Server.MapPath("~/file_nhap/") + b_nsd.ma_dvi + "\\" + nv.SelectedValue + "\\";
            if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
            string b_so_id = "";
            int b_i = chon_file.PostedFile.FileName.LastIndexOf(".");
            if (b_so_id == "0" || b_so_id == "") b_so_id = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
            b_ten = b_tm + nv.SelectedValue + b_so_id + b_excel.Substring(b_i, b_excel.Length - b_i);
            try
            {
                if (File.Exists(b_ten)) File.Delete(b_ten);
                chon_file.PostedFile.SaveAs(b_ten);
            }
            catch { throw new Exception("loi:Lỗi lưu File vào thư mục nháp:loi"); }
            DataTable b_dt = null;

            string b_nv = nv.SelectedValue;
            DataSet b_ds = new DataSet();
            Workbook workbook;
            Worksheet worksheet;
            DataTable dtDataSave;
            DataTable dtDataCheck;
            workbook = new Workbook(b_ten);
            worksheet = workbook.Worksheets[0];

            // mặc định tất cả các row được đọc từ dòng số 4
            b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
            dtDataSave = b_ds.Tables[0].Clone();
            dtDataCheck = b_ds.Tables[0].Clone();
            // ------------------- Đoàn này giữ nguyên-------------------------//

            switch (b_nv)
            {
                case "NS_PHONG":
                    {
                        if (workbook.Worksheets[1].Name != "NS_PHONG")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                        }
                        if (KiemTraExcel_phong(dtDataSave) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_PHONG(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else
                        {
                            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                            string b_s = this.ResolveUrl("~/App_form/khud/khud_Excel_Import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "khud_Excel_import_KD();", false);
                            form.P_LOI(this, "loi:Import thành công:loi");
                            return;
                        }
                    }
                    break;
                case "ns_cb_excel":
                    {
                        if (workbook.Worksheets[1].Name != "ns_cb_excel")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_cb_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_NS(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else
                        {
                            form.P_LOI(this, Thongbao_dch.Importthanhcong);
                            return;
                        }
                    }
                    break;
                case "NS_HD":
                    {
                        if (workbook.Worksheets[1].Name != "NS_HD")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_hd_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_HD(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_QH":
                    {
                        if (workbook.Worksheets[1].Name != "NS_QH")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_qhe_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_QH(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_MA_NCDANH":
                    {
                        if (workbook.Worksheets[1].Name != "NS_MA_NCDANH")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_ma_ncdanh_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_MA_NCDANH(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_MA_CDANH":
                    {
                        if (workbook.Worksheets[1].Name != "NS_MA_CDANH")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_ma_cdanh_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_MA_CDANH(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_KTKL_KT":
                    {
                        if (workbook.Worksheets[1].Name != "NS_KTKL_KT")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_ktkl_kt_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_KT(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_KTKL_KL":
                    {
                        if (workbook.Worksheets[1].Name != "NS_KTKL_KL")
                        {
                            form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
                            return;
                        }
                        foreach (DataRow row in b_ds.Tables[0].Rows)
                        {
                            var rows = row;
                            var isRow = ImportKiemTra.TrimRow(ref rows);
                            if (!isRow)
                            {
                                continue;
                            }
                            dtDataSave.ImportRow(row);
                            dtDataCheck.ImportRow(row);
                        }
                        if (KiemTraExcel_ns_ktkl_kl_excel(dtDataCheck) != "")
                        {
                            form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                            return;
                        };
                        b_kq = khud_files.KHUD_FILES_KL(dtDataSave);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                    }
                    break;
                case "NS_HDCT":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_id", ""); bang.P_BO_HANG(ref b_dt, "so_id", null); bang.P_BO_HANG(ref b_dt, "so_id", " ");
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_tt.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_HDCT(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;

                case "NS_BHXH":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_bhxh.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_BHXH(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;

                case "NS_MA_BV":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_cdanh.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_BV(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_LHD":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_lhd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_LHD(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TTB":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_id", ""); bang.P_BO_HANG(ref b_dt, "so_id", null); bang.P_BO_HANG(ref b_dt, "so_id", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TTB(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_HD_UPDATE_LUONG":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_HD_UPDATE_LUONG(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_CAPDT":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_capdt.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_CAPDT(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_NCNGANH":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_ncnganh.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_NCNGANH(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_XLOAI":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_xloai.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_XLOAI(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_NHA":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_xloai.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_NHA(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_DTHV":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_id", ""); bang.P_BO_HANG(ref b_dt, "so_id", null); bang.P_BO_HANG(ref b_dt, "so_id", " ");
                        //if (b_ktraten != "ns_dthv.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_DTHV(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TK_MA_NHTK":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_tk_ma_nhtk.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TK_MA_NHTK(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TK_MA_CHITIEU":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_tk_ma_chitieu.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TK_MA_CHITIEU(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TK_KQTK":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_tk_qktk.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TK_MA_KQTK(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_DT":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_capdt.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_DT(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_MA_TG":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma", ""); bang.P_BO_HANG(ref b_dt, "ma", null); bang.P_BO_HANG(ref b_dt, "ma", " ");
                        //if (b_ktraten != "ns_ma_capdt.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_MA_TG(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TL_TN_PCAP":
                    {
                        bang.P_BO_HANG(ref b_dt, "ma_goc", ""); bang.P_BO_HANG(ref b_dt, "ma_goc", null); bang.P_BO_HANG(ref b_dt, "ma_goc", " ");
                        //if (b_ktraten != "ns_ma_capdt.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TN_PCAP(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TTT":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TTT(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_CP":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_id", ""); bang.P_BO_HANG(ref b_dt, "so_id", null); bang.P_BO_HANG(ref b_dt, "so_id", " ");
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_CP(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TT_NGHI":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TT_NGHI(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "NS_TV":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TV(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                case "CC_CT_HAL":
                    {
                        bang.P_BO_HANG(ref b_dt, "so_the", ""); bang.P_BO_HANG(ref b_dt, "so_the", null); bang.P_BO_HANG(ref b_dt, "so_the", " ");
                        //if (b_ktraten != "ns_hd.xls") { form.P_LOI(this, "Sai tên file mẫu, vui lòng download file mẫu thêm thông tin và KHÔNG ĐỔI TÊN FILE!"); break; }
                        b_kq = khud_files.KHUD_FILES_TV(b_dt);
                        if (b_kq != "") form.P_LOI(this, b_kq);
                        else form.P_LOI(this, "Import thành công!");
                    }
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex) { form.P_LOI(this, Thongbao_dch.LoiquatrinhImport); }
    }

    protected string KiemTraExcel_phong(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 4;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập mã phòng";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Độ dài mã phòng vượt quá 30 ký tự";
                ImportKiemTra.IsValidLength("MA", ref row, ref rowError, ref isError, sError, 30);

                sError = "Chưa nhập tên phòng";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Độ dài tên phòng vượt quá 255 ký tự";
                ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 255);

                sError = "Mã cha vượt quá 30 ký tự";
                ImportKiemTra.IsValidLength("MA_CT", ref row, ref rowError, ref isError, sError, 255);

                if (isError)
                {
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_phong_loi.xls", dtError, dtError, "ns_phong_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_cb_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Độ dài mã cán bộ vượt quá 30 ký tự";
                ImportKiemTra.IsValidLength("SO_THE", ref row, ref rowError, ref isError, sError, 30);

                sError = "Chưa nhập tên cán bộ";
                ImportKiemTra.EmptyValue("TEN_CB", ref row, ref rowError, ref isError, sError);

                sError = "Độ dài tên cán bộ vượt quá 255 ký tự";
                ImportKiemTra.IsValidLength("TEN_CB", ref row, ref rowError, ref isError, sError, 255);

                sError = "Chưa nhập quốc tịch";
                ImportKiemTra.EmptyValue("NN_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["NN_TEN"].Equals(""))
                {
                    sError = "Quốc tịch";
                    ImportKiemTra.IsValidListMa("NN_TEN", "NN_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_SINH"].Equals(""))
                {
                    sError = "Ngày sinh nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_SINH", ref row, ref rowError, ref isError, sError);
                }

                if (!row["GIOITINH_TEN"].Equals(""))
                {
                    sError = "Giới tính";
                    ImportKiemTra.IsValidListMa("GIOITINH_TEN", "GIOITINH_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NHOM_TEN"].Equals(""))
                {
                    sError = "Nhóm";
                    ImportKiemTra.IsValidListMa("NHOM_TEN", "NHOM_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập ngày vào";
                ImportKiemTra.EmptyValue("NGAYD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Ngày vào nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập mã phòng";
                ImportKiemTra.EmptyValue("TEN_PHONG", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_PHONG"].Equals(""))
                {
                    sError = "Phòng";
                    ImportKiemTra.IsValidListMa("TEN_PHONG", "MA_PHONG", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_BC"].Equals(""))
                {
                    sError = "Ngày biên chế nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_BC", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_CT"].Equals(""))
                {
                    sError = "Ngày chính thức nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CT", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_VN"].Equals(""))
                {
                    sError = "Ngày vào ngành nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_VN", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_CMT"].Equals(""))
                {
                    sError = "Ngày cấp cmt nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CMT", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NC_CMT_TEN"].Equals(""))
                {
                    sError = "Nơi cấp";
                    ImportKiemTra.IsValidListMa("NC_CMT_TEN", "NC_CMT_MA", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NHAN_TEN"].Equals(""))
                {
                    sError = "Cách nhận tiền";
                    ImportKiemTra.IsValidListMa("NHAN_TEN", "NHAN_MA", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NHA_TEN"].Equals(""))
                {
                    sError = "Ngân hàng";
                    ImportKiemTra.IsValidListMa("NHA_TEN", "NHA_MA", ref row, ref rowError, ref isError, sError);
                }


                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_cb_excel_loi.xls", dtError, dtError, "ns_cb_excel_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_hd_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập loại hợp đồng";
                ImportKiemTra.EmptyValue("LHD_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["LHD_TEN"].Equals(""))
                {
                    sError = "Loại hợp đồng";
                    ImportKiemTra.IsValidListMa("LHD_TEN", "LHD_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập số hợp đồng";
                ImportKiemTra.EmptyValue("SO_HD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_KY"].Equals(""))
                {
                    sError = "Ngày ký nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_KY", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập từ ngày";
                ImportKiemTra.EmptyValue("NGAYD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Từ ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAYC"].Equals(""))
                {
                    sError = "Đến ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYC", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập đơn vị công tác";
                ImportKiemTra.EmptyValue("PHONG_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["PHONG_TEN"].Equals(""))
                {
                    sError = "Đơn vị công tác";
                    ImportKiemTra.IsValidListMa("PHONG_TEN", "PHONG_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["CVU_TEN"].Equals(""))
                {
                    sError = "Chức vụ";
                    ImportKiemTra.IsValidListMa("CVU_TEN", "CVU_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NCD_TEN"].Equals(""))
                {
                    sError = "Nhóm chức danh";
                    ImportKiemTra.IsValidListMa("NCD_TEN", "NCD_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["CDANH_TEN"].Equals(""))
                {
                    sError = "Chức danh";
                    ImportKiemTra.IsValidListMa("CDANH_TEN", "CDANH_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["BCD_TEN"].Equals(""))
                {
                    sError = "Bậc chức danh";
                    ImportKiemTra.IsValidListMa("BCD_TEN", "BCD_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập mức lương";
                ImportKiemTra.EmptyValue("TIEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập lương cơ bản";
                ImportKiemTra.EmptyValue("TIENBH", ref row, ref rowError, ref isError, sError);

                if (!row["TRATHEO_TEN"].Equals(""))
                {
                    sError = "Trả lương theo";
                    ImportKiemTra.IsValidListMa("TRATHEO_TEN", "TRATHEO_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["LOAILUONG_TEN"].Equals(""))
                {
                    sError = "Loại lương";
                    ImportKiemTra.IsValidListMa("LOAILUONG_TEN", "LOAILUONG_MA", ref row, ref rowError, ref isError, sError);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_hd_xong_loi.xls", dtError, dtError, "ns_hd_xong_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_qhe_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (!row["GDINH_TEN"].Equals(""))
                {
                    sError = "Gia đình";
                    ImportKiemTra.IsValidListMa("GDINH_TEN", "GDINH_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập loại quan hệ";
                ImportKiemTra.EmptyValue("LQHE_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["LQHE_TEN"].Equals(""))
                {
                    sError = "Loại quan hệ";
                    ImportKiemTra.IsValidListMa("LQHE_TEN", "LQHE_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập họ tên nhân thân";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Năm sinh nhập sai định dạng yyyy";
                ImportKiemTra.IsValidLength("TUOI", ref row, ref rowError, ref isError, sError, 4);

                if (!row["TUOI"].Equals(""))
                {
                    sError = "Năm sinh phải là số";
                    ImportKiemTra.IsValid_Number("TUOI", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_GIAMTRU"].Equals(""))
                {
                    sError = "Ngày giảm trừ nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_GIAMTRU", ref row, ref rowError, ref isError, sError);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_qh_loi.xls", dtError, dtError, "ns_qh_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_ma_ncdanh_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã nhóm chức danh";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                if (!row["MA"].Equals(""))
                {
                    sError = "Mã nhóm chức danh không được nhập quá 10 ký tự";
                    ImportKiemTra.IsValidLength("MA", ref row, ref rowError, ref isError, sError, 10);
                }

                sError = "Chưa nhập tên nhóm chức danh";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                if (!row["TEN"].Equals(""))
                {
                    sError = "Tên nhóm chức danh không được nhập quá 100 ký tự";
                    ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 100);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_ma_ncdanh_loi.xls", dtError, dtError, "ns_ma_ncdanh_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_ma_cdanh_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập nhóm chức danh";
                ImportKiemTra.EmptyValue("NCDANH_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["NCDANH_TEN"].Equals(""))
                {
                    sError = "Nhóm chức danh";
                    ImportKiemTra.IsValidListMa("NCDANH_TEN", "NCDANH_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập mã chức danh";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);


                if (!row["MA"].Equals(""))
                {
                    sError = "Mã chức danh không được nhập quá 30 ký tự";
                    ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 30);
                }

                sError = "Chưa nhập tên chức danh";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                if (!row["TEN"].Equals(""))
                {
                    sError = "Tên nhóm chức danh không được nhập quá 100 ký tự";
                    ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 100);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_ma_cdanh_loi.xls", dtError, dtError, "ns_ma_cdanh_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_ktkl_kt_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mức thưởng";
                ImportKiemTra.EmptyValue("MUCTHUONG", ref row, ref rowError, ref isError, sError);

                if (!row["MUCTHUONG"].Equals(""))
                {
                    sError = "Mức thưởng không phải là số";
                    ImportKiemTra.IsValid_Number("MUCTHUONG", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập số quyết định";
                ImportKiemTra.EmptyValue("SOQD", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày quyết định";
                ImportKiemTra.EmptyValue("NGAYQD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAYQD"].Equals(""))
                {
                    sError = "Ngày quyết định nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYQD", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập hình thức khen thưởng";
                ImportKiemTra.EmptyValue("HINHTHUC_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["HINHTHUC_TEN"].Equals(""))
                {
                    sError = "Hình thức";
                    ImportKiemTra.IsValidListMa("HINHTHUC_TEN", "HINHTHUC_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["CAP_KTKL_TEN"].Equals(""))
                {
                    sError = "Cấp khen thưởng";
                    ImportKiemTra.IsValidListMa("CAP_KTKL_TEN", "CAP_KTKL_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NOI_KTKL_TEN"].Equals(""))
                {
                    sError = "Nơi khen thưởng";
                    ImportKiemTra.IsValidListMa("NOI_KTKL_TEN", "NOI_KTKL_MA", ref row, ref rowError, ref isError, sError);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_kt_loi.xls", dtError, dtError, "ns_kt_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    protected string KiemTraExcel_ns_ktkl_kl_excel(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (bang.Fb_TRANG(table)) throw new Exception("loi:File không có số liệu:loi");
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mức phạt";
                ImportKiemTra.EmptyValue("MUCPHAT", ref row, ref rowError, ref isError, sError);

                if (!row["MUCPHAT"].Equals(""))
                {
                    sError = "Mức phạt không phải là số";
                    ImportKiemTra.IsValid_Number("MUCPHAT", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập số quyết định";
                ImportKiemTra.EmptyValue("SOQD", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày quyết định";
                ImportKiemTra.EmptyValue("NGAYQD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAYQD"].Equals(""))
                {
                    sError = "Ngày quyết định nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYQD", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập hình thức kỷ luật";
                ImportKiemTra.EmptyValue("HINHTHUC_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["HINHTHUC_TEN"].Equals(""))
                {
                    sError = "Hình thức";
                    ImportKiemTra.IsValidListMa("HINHTHUC_TEN", "HINHTHUC_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Kỷ luật từ ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYC"].Equals(""))
                {
                    sError = "Kỷ luật đến ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYC", ref row, ref rowError, ref isError, sError);
                }


                if (!row["CAP_KTKL_TEN"].Equals(""))
                {
                    sError = "Cấp kỷ luật";
                    ImportKiemTra.IsValidListMa("CAP_KTKL_TEN", "CAP_KTKL_MA", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NOI_KTKL_TEN"].Equals(""))
                {
                    sError = "Nơi kỷ luật";
                    ImportKiemTra.IsValidListMa("NOI_KTKL_TEN", "NOI_KTKL_MA", ref row, ref rowError, ref isError, sError);
                }

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_kl_loi.xls", dtError, dtError, "ns_kl_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }
}
