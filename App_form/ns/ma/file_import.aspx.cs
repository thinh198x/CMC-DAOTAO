using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;
using System.Collections.Generic;
using System.Web;
using System.Collections;

public partial class f_file_import : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_KD();", true);
                ngay.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            Workbook workbook;
            Worksheet worksheet;
            string b_file, b_tm, b_ten = "";
            try
            {
                b_file = kytu.C_NVL(chon_file.PostedFile.FileName);
            }
            catch (Exception)
            {

                return;
            }
            string b_so_id = so_id.Value;
            string b_ngay = DateTime.Now.ToString();

            if (b_file == "")
            {
                if (b_so_id == "0") { throw new Exception("loi:Bạn chưa chọn file đính kèm:loi"); }
                else
                {
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_LKE();", true);
                    form.P_LOI(this, "Nhập file thành công!");
                }
            }
            else
            {
                se.se_nsd b_se = new se.se_nsd();
                b_tm = Server.MapPath("~/file_luu/") + b_se.ma_dvi + "/" + ten_form.Value;
                if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
                se.se_nsd b_nsd = new se.se_nsd();
                int b_i = chon_file.PostedFile.FileName.LastIndexOf(".");

                if (b_so_id == "0" || b_so_id == "") b_so_id = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
                b_ten = b_tm + "\\" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                DataTable dtDataSave, dtDataCheck, dt_ktr;
                try
                {
                    if (File.Exists(b_ten)) File.Delete(b_ten);
                    chon_file.PostedFile.SaveAs(b_ten);
                    //DataTable b_dt = khac.Fdt_Excel(b_ten);
                    workbook = new Workbook(b_ten);
                    worksheet = workbook.Worksheets[0];
                    switch (ten_form.Value)
                    {
                        case "ns_cb":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                dtDataCheck = b_ds.Tables[0].Clone();
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
                                var b_kq = khud_files.KHUD_FILES_NS(dtDataSave);
                                if (b_kq != "") form.P_LOI(this, b_kq);
                                else
                                {
                                    form.P_LOI(this, Thongbao_dch.Importthanhcong);
                                    return;
                                }
                            }
                            break;
                        case "ns_hd":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                dtDataCheck = b_ds.Tables[0].Clone();
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
                                var b_kq = khud_files.KHUD_FILES_HD(dtDataSave);
                                if (b_kq != "") form.P_LOI(this, b_kq);
                                else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                            }
                            break;
                        case "ns_hdct":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                dtDataCheck = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets[1].Name != "NS_HDCT")
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
                                if (KiemTraExcel_ns_hdct_excel(dtDataCheck) != "")
                                {
                                    form.P_LOI(this, Thongbao_dch.LoiquatrinhImport);
                                    return;
                                };
                                var b_kq = khud_files.KHUD_FILES_HDCT(dtDataSave);
                                if (b_kq != "") form.P_LOI(this, b_kq);
                                else form.P_LOI(this, Thongbao_dch.Importthanhcong);
                            }
                            break;
                        case "dg_kq_dgia_thang":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(7, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_dg_cv_thang(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    DataTable b_nam_kydg = new DataTable();
                                    bang.P_THEM_COL(ref b_nam_kydg, new string[] { "nam", "ky_dg" });
                                    bang.P_THEM_HANG(ref b_nam_kydg, dt_ktr, new string[] { "nam", "ky_dg" });
                                    dg.P_Fs_DG_KQ_DGIA_THANG_NH_EXCEL(b_nam_kydg, dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "cc_dky_dmvs":
                            {

                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_THONGTIN_DMVS(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_dky");
                                    bang.P_CSO_SO(ref dtDataSave, "sophut");
                                    tl_cc.PCC_DKY_DMVS_FILE_NH(dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "cc_dulieu_vaora":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                KiemTraDuLieuVaoRa(dtDataSave);
                                tl_cc.P_CC_QUET_THE_IMP(dtDataSave);
                            }
                            break;
                        case "tl_luong_imp":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(7, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                bang.P_BO_HANG(ref dtDataSave, "so_the", "");
                                string message = KiemTraImportLuongKhac(dtDataSave);
                                if (message == "")
                                {
                                    tl_ch.Fdt_BANGLUONG_IMP_NH(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "tl_phanca":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(7, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {

                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_TlPhaca(dt_ktr);
                                if (b_kiemtra == "")
                                {

                                    string b_loi = tl_cc.PCC_PHANCA_FILE_NH(dtDataSave, thamso1_cc.Value);
                                    if (!string.IsNullOrEmpty(b_loi))
                                    {
                                        form.P_LOI(this, b_loi);
                                    }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_td_kh_nam":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);

                                    }
                                }
                                string message = KiemTraImport_kh_nam(dtDataValidate);
                                if (message == "")
                                {
                                    ns_td.Fs_NS_TD_KH_NAM_IMP(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "ns_td_uv":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(6, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }

                                dtDataSave.Columns.Add("KEY");
                                int b_pkey = 1;
                                for (int i = 0; i < dtDataSave.Rows.Count; i++)
                                {
                                    if (dtDataSave.Rows[i]["TEN"].ToString() == "")
                                    {
                                        dtDataSave.Rows[i]["KEY"] = dtDataSave.Rows[i - 1]["KEY"];
                                    }
                                    else
                                    {
                                        dtDataSave.Rows[i]["KEY"] = b_pkey;
                                        b_pkey++;
                                    }
                                }
                                string message = KiemTraImportKho_UV(dtDataValidate);


                                if (message == "")
                                {
                                    DataTable dt_chung = Xoacot_thua(new string[] { "TEN_TENTRUONG_TD", "TENTRUONG_TD", "TEN_CHUYENNGANH_TD", "CHUYENNGANH_TD", "TUNAM_TD", "DENNAM_TD", "TEN_TRINHDO_TD",
                                                    "TRINHDO_TD", "TEN_HINHTHUC_DT_TD", "HINHTHUC_DT_TD", "LOAI_TOTNGHIEP_TD", "TENCHUNGCHI_CC", "NOIDUNG_CC", "SOHIEU_CC", "COSO_DAOTAO_CC", "TUNGAY_CC", "DENNGAY_CC",
                                                    "NGAY_HL_CC", "NGAY_HHL_CC", "TENCTY_CT", "TUTHANG_CT", "DENTHANG_CT", "CHUCDANH_CT", "LYDO_NGHIVIEC_CT", "HOTEN_TN", "TEN_QUANHE_TN", "QUANHE_TN", "NGAYSINH_TN",
                                                    "NGHENGHIEP_TN", "NOI_CT_TN" }, dtDataSave);

                                    DataTable dt_trinhdo = Xoacot_thua(new string[] { "TEN", "MUCLUONG_MM", "TEN_GIOITINH", "GIOITINH", "NGAYSINH", "NOISINH", "TEN_TT_NOISINH", "TT_NOISINH", "TEN_QH_NOISINH", "QH_NOISINH",
                                                    "TEN_XP_NOISINH", "XP_NOISINH", "SO_CMT", "NGAYCAP_CMT", "NOICAP_CMT", "TAMTRU", "TEN_TT_TAMTRU", "TT_TAMTRU", "TEN_QH_TAMTRU", "QH_TAMTRU", "TEN_XP_TAMTRU", "XP_TAMTRU", "THUONGTRU",
                                                    "TEN_TT_THUONGTRU", "TT_THUONGTRU", "TEN_QH_THUONGTRU", "QH_THUONGTRU", "TEN_XP_THUONGTRU", "XP_THUONGTRU", "TEN_TT_HONNHAN", "TT_HONNHAN", "SODT_NR", "SODT_DD", "EMAIL", "CHIEUCAO",
                                                    "CANNANG", "TEN_DANTOC", "DANTOC", "TEN_TONGIAO", "TONGIAO", "NGUOITHAN_LVTTD_CO", "NGUOITHAN_LVTTD_KO", "NGUOITHAN_LVTTD_THONGTIN", "BANTHAN_LVTTD_CO", "BANTHAN_LVTTD_KO", "BANTHAN_LVTTD_VITRI",
                                                    "BANTHAN_LVTTD_BOPHAN", "BANTHAN_LVTTD_TBP", "BANTHAN_LVTTD_CTY", "BANTHAN_LVTTD_TGLV", "BANTHAN_LVTTD_LYDO_NV", "BANTHAN_UT_CO", "BANTHAN_UT_KO", "BANTHAN_UT_THONGTIN", "LIENHE_HOTEN", "LIENHE_MQH",
                                                    "LIENHE_SDT", "LIENHE_DIACHI", "TENCHUNGCHI_CC", "NOIDUNG_CC", "SOHIEU_CC", "COSO_DAOTAO_CC", "TUNGAY_CC", "DENNGAY_CC", "NGAY_HL_CC", "NGAY_HHL_CC", "TENCTY_CT", "TUTHANG_CT", "DENTHANG_CT",
                                                    "CHUCDANH_CT", "LYDO_NGHIVIEC_CT", "HOTEN_TN", "TEN_QUANHE_TN", "QUANHE_TN", "NGAYSINH_TN", "NGHENGHIEP_TN", "NOI_CT_TN"}, dtDataSave);

                                    DataTable dt_chungchi = Xoacot_thua(new string[] { "TEN", "MUCLUONG_MM", "TEN_GIOITINH", "GIOITINH", "NGAYSINH", "NOISINH", "TEN_TT_NOISINH", "TT_NOISINH", "TEN_QH_NOISINH", "QH_NOISINH",
                                                    "TEN_XP_NOISINH", "XP_NOISINH", "SO_CMT", "NGAYCAP_CMT", "NOICAP_CMT", "TAMTRU", "TEN_TT_TAMTRU", "TT_TAMTRU", "TEN_QH_TAMTRU", "QH_TAMTRU", "TEN_XP_TAMTRU", "XP_TAMTRU",
                                                    "THUONGTRU", "TEN_TT_THUONGTRU", "TT_THUONGTRU", "TEN_QH_THUONGTRU", "QH_THUONGTRU", "TEN_XP_THUONGTRU", "XP_THUONGTRU", "TEN_TT_HONNHAN", "TT_HONNHAN", "SODT_NR", "SODT_DD",
                                                    "EMAIL", "CHIEUCAO", "CANNANG", "TEN_DANTOC", "DANTOC", "TEN_TONGIAO", "TONGIAO", "NGUOITHAN_LVTTD_CO", "NGUOITHAN_LVTTD_KO", "NGUOITHAN_LVTTD_THONGTIN", "BANTHAN_LVTTD_CO",
                                                    "BANTHAN_LVTTD_KO", "BANTHAN_LVTTD_VITRI", "BANTHAN_LVTTD_BOPHAN", "BANTHAN_LVTTD_TBP", "BANTHAN_LVTTD_CTY", "BANTHAN_LVTTD_TGLV", "BANTHAN_LVTTD_LYDO_NV", "BANTHAN_UT_CO",
                                                    "BANTHAN_UT_KO", "BANTHAN_UT_THONGTIN", "LIENHE_HOTEN", "LIENHE_MQH", "LIENHE_SDT", "LIENHE_DIACHI", "TEN_TENTRUONG_TD", "TENTRUONG_TD", "TEN_CHUYENNGANH_TD", "CHUYENNGANH_TD",
                                                    "TUNAM_TD", "DENNAM_TD", "TEN_TRINHDO_TD", "TRINHDO_TD", "TEN_HINHTHUC_DT_TD", "HINHTHUC_DT_TD", "LOAI_TOTNGHIEP_TD", "TENCTY_CT", "TUTHANG_CT", "DENTHANG_CT", "CHUCDANH_CT",
                                                    "LYDO_NGHIVIEC_CT", "HOTEN_TN", "TEN_QUANHE_TN", "QUANHE_TN", "NGAYSINH_TN", "NGHENGHIEP_TN", "NOI_CT_TN"}, dtDataSave);

                                    DataTable dt_congtac = Xoacot_thua(new string[] { "TEN", "MUCLUONG_MM", "TEN_GIOITINH", "GIOITINH", "NGAYSINH", "NOISINH", "TEN_TT_NOISINH", "TT_NOISINH", "TEN_QH_NOISINH", "QH_NOISINH",
                                                    "TEN_XP_NOISINH", "XP_NOISINH", "SO_CMT", "NGAYCAP_CMT", "NOICAP_CMT", "TAMTRU", "TEN_TT_TAMTRU", "TT_TAMTRU", "TEN_QH_TAMTRU", "QH_TAMTRU", "TEN_XP_TAMTRU", "XP_TAMTRU",
                                                    "THUONGTRU", "TEN_TT_THUONGTRU", "TT_THUONGTRU", "TEN_QH_THUONGTRU", "QH_THUONGTRU", "TEN_XP_THUONGTRU", "XP_THUONGTRU", "TEN_TT_HONNHAN", "TT_HONNHAN", "SODT_NR", "SODT_DD",
                                                    "EMAIL", "CHIEUCAO", "CANNANG", "TEN_DANTOC", "DANTOC", "TEN_TONGIAO", "TONGIAO", "NGUOITHAN_LVTTD_CO", "NGUOITHAN_LVTTD_KO", "NGUOITHAN_LVTTD_THONGTIN", "BANTHAN_LVTTD_CO",
                                                    "BANTHAN_LVTTD_KO", "BANTHAN_LVTTD_VITRI", "BANTHAN_LVTTD_BOPHAN", "BANTHAN_LVTTD_TBP", "BANTHAN_LVTTD_CTY", "BANTHAN_LVTTD_TGLV", "BANTHAN_LVTTD_LYDO_NV", "BANTHAN_UT_CO",
                                                    "BANTHAN_UT_KO", "BANTHAN_UT_THONGTIN", "LIENHE_HOTEN", "LIENHE_MQH", "LIENHE_SDT", "LIENHE_DIACHI", "TEN_TENTRUONG_TD", "TENTRUONG_TD", "TEN_CHUYENNGANH_TD", "CHUYENNGANH_TD",
                                                    "TUNAM_TD", "DENNAM_TD", "TEN_TRINHDO_TD", "TRINHDO_TD", "TEN_HINHTHUC_DT_TD", "HINHTHUC_DT_TD", "LOAI_TOTNGHIEP_TD", "TENCHUNGCHI_CC", "NOIDUNG_CC", "SOHIEU_CC", "COSO_DAOTAO_CC",
                                                    "TUNGAY_CC", "DENNGAY_CC", "NGAY_HL_CC", "NGAY_HHL_CC", "HOTEN_TN", "TEN_QUANHE_TN", "QUANHE_TN", "NGAYSINH_TN", "NGHENGHIEP_TN", "NOI_CT_TN"}, dtDataSave);

                                    DataTable dt_nhanthan = Xoacot_thua(new string[] { "TEN", "MUCLUONG_MM", "TEN_GIOITINH", "GIOITINH", "NGAYSINH", "NOISINH", "TEN_TT_NOISINH", "TT_NOISINH", "TEN_QH_NOISINH", "QH_NOISINH",
                                                    "TEN_XP_NOISINH", "XP_NOISINH", "SO_CMT", "NGAYCAP_CMT", "NOICAP_CMT", "TAMTRU", "TEN_TT_TAMTRU", "TT_TAMTRU", "TEN_QH_TAMTRU", "QH_TAMTRU", "TEN_XP_TAMTRU", "XP_TAMTRU",
                                                    "THUONGTRU", "TEN_TT_THUONGTRU", "TT_THUONGTRU", "TEN_QH_THUONGTRU", "QH_THUONGTRU", "TEN_XP_THUONGTRU", "XP_THUONGTRU", "TEN_TT_HONNHAN", "TT_HONNHAN", "SODT_NR", "SODT_DD",
                                                    "EMAIL", "CHIEUCAO", "CANNANG", "TEN_DANTOC", "DANTOC", "TEN_TONGIAO", "TONGIAO", "NGUOITHAN_LVTTD_CO", "NGUOITHAN_LVTTD_KO", "NGUOITHAN_LVTTD_THONGTIN", "BANTHAN_LVTTD_CO",
                                                    "BANTHAN_LVTTD_KO", "BANTHAN_LVTTD_VITRI", "BANTHAN_LVTTD_BOPHAN", "BANTHAN_LVTTD_TBP", "BANTHAN_LVTTD_CTY", "BANTHAN_LVTTD_TGLV", "BANTHAN_LVTTD_LYDO_NV", "BANTHAN_UT_CO",
                                                    "BANTHAN_UT_KO", "BANTHAN_UT_THONGTIN", "LIENHE_HOTEN", "LIENHE_MQH", "LIENHE_SDT", "LIENHE_DIACHI", "TEN_TENTRUONG_TD", "TENTRUONG_TD", "TEN_CHUYENNGANH_TD", "CHUYENNGANH_TD",
                                                    "TUNAM_TD", "DENNAM_TD", "TEN_TRINHDO_TD", "TRINHDO_TD", "TEN_HINHTHUC_DT_TD", "HINHTHUC_DT_TD", "LOAI_TOTNGHIEP_TD", "TENCHUNGCHI_CC", "NOIDUNG_CC", "SOHIEU_CC", "COSO_DAOTAO_CC",
                                                    "TUNGAY_CC", "DENNGAY_CC", "NGAY_HL_CC", "NGAY_HHL_CC","TENCTY_CT", "TUTHANG_CT", "DENTHANG_CT", "CHUCDANH_CT", "LYDO_NGHIVIEC_CT"}, dtDataSave);


                                    bang.P_BO_HANG(ref dt_chung, "TEN", "");
                                    bang.P_BO_HANG(ref dt_trinhdo, "TENTRUONG_TD", "");
                                    bang.P_BO_HANG(ref dt_chungchi, "TENCHUNGCHI_CC", "");
                                    bang.P_BO_HANG(ref dt_congtac, "TUTHANG_CT", "");
                                    bang.P_BO_HANG(ref dt_nhanthan, "HOTEN_TN", "");
                                    ns_td.Fs_TD_UV_IMP(dt_chung, dt_trinhdo, dt_chungchi, dt_congtac, dt_nhanthan);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "ns_tt_bh":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(7, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }
                                string message = KiemTraImportthongtinBH(dtDataValidate);
                                if (message == "")
                                {
                                    ns_cd.Fdt_TT_BH_IMP_NH(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "ns_cc_kb_lthem":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dtDataValidate = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_KhaiBao_LamThem(dtDataValidate);
                                if (dtDataValidate.Rows.Count <= 0 || dtDataValidate == null)
                                {
                                    form.P_LOI(this, "loi:Không có dữ liệu import:loi");
                                }
                                if (b_kiemtra == "")
                                {
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_dky");
                                    bang.P_CSO_SO(ref dtDataSave, new string[] { "so_gio_ngay", "so_gio_dem", "sg_ngay_nb", "sg_dem_nb", "so_gio_tt" });
                                    string so_id1 = "0";
                                    string b_loi = tl_cc.P_NS_CC_KB_LTHEM_IMP(ref so_id1, dtDataSave);
                                    if (b_loi.Contains("loi")) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_tl_qtthue":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dtDataValidate = dtDataSave.Copy();
                                string b_kiemtra = KiemTra_uyquyen_qtthue(dtDataValidate);
                                if (dtDataValidate.Rows.Count <= 0 || dtDataValidate == null)
                                {
                                    form.P_LOI(this, "loi:Không có dữ liệu import:loi");
                                }
                                if (b_kiemtra == "")
                                {
                                    bang.P_CSO_SO(ref dtDataSave, "nam");
                                    string b_loi = tl_ch.P_NS_TL_QTTHUE_IMP_NH(dtDataSave);
                                    //if (b_loi.Contains("loi")) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_cc_ma_ccnv":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(5, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dtDataValidate = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_CCNV(dtDataValidate);
                                if (dtDataValidate.Rows.Count <= 0 || dtDataValidate == null)
                                {
                                    form.P_LOI(this, "loi:Không có dữ liệu import:loi");
                                }
                                if (b_kiemtra == "")
                                {
                                    tl_cc.P_NS_CC_MA_CCNV_IMP_NH(dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;

                        case "ns_cc_dky_lthem":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dtDataValidate = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_Dky_LamThem(dtDataValidate);
                                if (dtDataValidate.Rows.Count <= 0 || dtDataValidate == null)
                                {
                                    form.P_LOI(this, "loi:Không có dữ liệu import:loi");
                                }
                                if (b_kiemtra == "")
                                {
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_dky");
                                    bang.P_CSO_SO(ref dtDataSave, new string[] { "so_gio_ngay", "so_gio_dem", "sg_ngay_nb", "sg_dem_nb", "so_gio_tt" });
                                    string so_id1 = "0";
                                    string b_loi = tl_cc.P_NS_CC_DKY_LTHEM_IMP(ref so_id1, dtDataSave);
                                    if (b_loi.Contains("loi")) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_cc_thongtin_nghi":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_THONGTIN_NGHI(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_THEM_COL(ref dtDataSave, new string[] { "truphepnam", "truphep", "nghibu", "ngaybu", "ghichu", "ngaynghi", "sothe_thaythe" }, new object[] { "X", 0, "X", 0, "", 0, "" });
                                    string b_loi = ns_qt.P_NS_CC_THONGTIN_NGHI_FILE_NH(dtDataSave);
                                    if (!string.IsNullOrEmpty(b_loi)) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_tl_khoan_phaithu":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_KHOAN_PHAITHU(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                   // bang.P_THEM_COL(ref dtDataSave, new string[] { "so_the", "ho_ten", "cdanh", "phong", "nam", "kyluong_id", "sotien_thu", "sotien_tra","noidung_thu","noidung_tra","ngaytao" });
                                    string b_loi = ns_qt.P_NS_TL_KHOAN_PHAITHU_FILE_NH(dtDataSave);
                                    if (!string.IsNullOrEmpty(b_loi)) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "cc_cn_ct":
                            {
                                try
                                {
                                    b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(8, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                    dtDataSave = b_ds.Tables[0].Clone();
                                    foreach (DataTable dt in b_ds.Tables)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            var rows = row;
                                            var isRow = ImportKiemTra.TrimRow(ref rows);
                                            if (!isRow) { continue; }
                                            dtDataSave.ImportRow(row);
                                        }
                                    }
                                    dt_ktr = dtDataSave.Copy();
                                    string b_kiemtra = KiemTraImport_cc_cn_ct(dtDataSave);
                                    if (b_kiemtra == "")
                                    {
                                        string b_loi = tl_cc.PNS_CC_CN_CT_FILE_NH(dtDataSave, thamso1_cc.Value);
                                        if (!string.IsNullOrEmpty(b_loi)) { form.P_LOI(this, b_loi); }
                                    }
                                    else form.P_LOI(this, b_kiemtra);

                                }
                                catch (Exception) { throw; }
                            }
                            break;
                        case "ns_hdns_dbien":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(6, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }
                                string message = KiemTraImportDinhBien(dtDataValidate);
                                if (message == "")
                                {
                                    ns_td.Fdt_NS_TD_DINHBIEN_IMP_NH(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "ns_dt_hvien_tgian":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(6, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }
                                string message = KiemTraImportHocvien(dtDataValidate);
                                if (message == "")
                                {
                                    var b_so_id_hv = chuyen.CSO_SO(thamso1_cc.Value);
                                    ns_dt.P_NS_DT_HVIEN_TGIAN_IMP(ref b_so_id_hv, dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "ns_hdns_ma_vtcdanh":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dt_ktr = dtDataSave.Copy();
                                string b_kiemtra = "";
                                if (dt_ktr.Rows.Count == 0)
                                {
                                    b_kiemtra = "loi:Không tồn tại bản ghi:loi";
                                }
                                else
                                {
                                    b_kiemtra = KiemTraImport_Cdanh(dt_ktr);
                                }
                                if (b_kiemtra == "") ns_hdns.P_NS_HDNS_MA_VTCD_FILE_NH(dtDataSave);
                                else form.P_LOI(this, b_kiemtra);
                            }

                            break;
                        case "dg_dm_tieuchi":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }
                                string message = KiemTraImport_TIEUCHI_DG(dtDataValidate);
                                if (message == "")
                                {
                                    dg.P_DG_DM_TIEUCHI_FILE_NH(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "dg_dm_mdg":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                        dtDataValidate.ImportRow(row);
                                    }
                                }
                                string message = KiemTraImport_dg_dm_mdg(dtDataValidate);
                                if (message == "")
                                {
                                    dg.PDG_DM_MDG_IMPORT(dtDataSave);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                            }
                            break;
                        case "hdns_mota_cv":
                            {
                                DataTable dtDataNV, dtDataQHCV;
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }
                                dtDataSave.Columns.Add("KEY");
                                dtDataNV = new DataTable();
                                dtDataNV.Columns.Add("KEY");
                                dtDataNV.Columns.Add("STT");
                                dtDataNV.Columns.Add("NV_CV");
                                dtDataNV.Columns.Add("THAMQUYEN");
                                dtDataNV.Columns.Add("MUCTIEU_KQ");
                                dtDataQHCV = new DataTable();
                                dtDataQHCV.Columns.Add("KEY");
                                dtDataQHCV.Columns.Add("NHOM_NL");
                                dtDataQHCV.Columns.Add("NANG_LUC");
                                dtDataQHCV.Columns.Add("MUC_NL");
                                dtDataQHCV.Columns.Add("MO_TA");
                                int b_pkey = 1;
                                if (dtDataSave.Rows.Count > 0)
                                {
                                    dtDataSave.Rows[0]["KEY"] = b_pkey;
                                    DataRow drNV = dtDataNV.NewRow();
                                    DataRow drQHCV = dtDataQHCV.NewRow();
                                    for (int i = 0; i < dtDataNV.Columns.Count; i++)
                                    {
                                        drNV[dtDataNV.Columns[i].ColumnName] = dtDataSave.Rows[0][dtDataNV.Columns[i].ColumnName];
                                    }
                                    dtDataNV.Rows.Add(drNV);
                                    for (int i = 1; i < dtDataSave.Rows.Count; i++)
                                    {
                                        drNV = dtDataNV.NewRow();
                                        drQHCV = dtDataQHCV.NewRow();
                                        if (dtDataSave.Rows[i]["MA_CD"].ToString() == "")
                                        {
                                            dtDataSave.Rows[i]["KEY"] = dtDataSave.Rows[i - 1]["KEY"];
                                        }
                                        else
                                        {
                                            b_pkey++;
                                            dtDataSave.Rows[i]["KEY"] = b_pkey;
                                        }

                                        for (int j = 0; j < dtDataNV.Columns.Count; j++)
                                        {
                                            drNV[dtDataNV.Columns[j].ColumnName] = dtDataSave.Rows[i][dtDataNV.Columns[j].ColumnName];

                                        }
                                        dtDataNV.Rows.Add(drNV);
                                    }
                                }

                                string message = KiemTraImportMoTaCV(dtDataSave);
                                if (message == "")
                                {
                                    bang.P_BO_HANG(ref dtDataSave, "CDANH", "");
                                    bang.P_BO_HANG(ref dtDataNV, "STT", "");
                                    bang.P_BO_HANG(ref dtDataQHCV, new string[] { "NHOM_NL", "NANG_LUC", "MUC_NL", "MO_TA" }, new string[] { "", "", "", "" });
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_bh"); bang.P_CNG_SO(ref dtDataSave, "ngay_sd");
                                    ns_mota_cv.Fdt_MOTA_CV_IMP_NH(dtDataSave, dtDataNV);
                                }
                                else
                                {
                                    form.P_LOI(this, message);
                                }
                                break;
                            }

                        case "ns_qhe":
                            {
                                string b_so_the = string.Empty;
                                string b_kiemtra = "";
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(6, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                b_so_the = worksheet.Cells[2, 1].StringValue;
                                dtDataSave = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets.Count < 0 || workbook.Worksheets[0].Name.ToUpper() != "NS_QHE" || string.IsNullOrEmpty(b_so_the))
                                {
                                    b_kiemtra = "loi:File mẫu không đúng định dạng!:loi";
                                    form.P_LOI(this, b_kiemtra);
                                }
                                else
                                {
                                    foreach (DataTable dt in b_ds.Tables)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            var rows = row;
                                            var isRow = ImportKiemTra.TrimRow(ref rows);
                                            if (!isRow)
                                            {
                                                continue;
                                            }
                                            dtDataSave.ImportRow(row);
                                        }
                                    }
                                    dt_ktr = dtDataSave.Copy();
                                    b_kiemtra = KiemTraImport_QHE(dt_ktr);
                                    if (b_kiemtra == "") ns_hdns.P_NS_QHE_IMPORT(dtDataSave, b_so_the);
                                    else form.P_LOI(this, b_kiemtra);
                                }
                            }
                            break;
                        case "ns_dsach_thieu_plenh":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                DataTable dtDataValidate = b_ds.Tables[0].Clone();
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                }

                                bang.P_BO_HANG(ref dtDataSave, "SO_THE", "");
                                dtDataValidate = dtDataSave.Copy();
                                string b_kiemtra = KiemTraImport_dsach_thieu_plenh(dtDataValidate);
                                if (dtDataValidate.Rows.Count <= 0 || dtDataValidate == null)
                                {
                                    form.P_LOI(this, "loi:Không có dữ liệu import:loi");
                                }
                                if (b_kiemtra == "")
                                {
                                    bang.P_CSO_SO(ref dtDataSave, new string[] { "SO_PLENH_THIEU" });
                                    string b_loi = tl_ch.PNS_DSACH_THIEU_PLENH_IMP(thamso1_cc.Value, thamso2_cc.Value, dtDataSave);
                                    if (b_loi.Contains("loi")) { form.P_LOI(this, b_loi); }
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "tl_ems_imp":
                            { 
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(6, 1, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone(); 
                                foreach (DataTable dt in b_ds.Tables)
                                {
                                    foreach (DataRow row in dt.Rows)
                                    {
                                        var rows = row;
                                        var isRow = ImportKiemTra.TrimRow(ref rows);
                                        if (!isRow)
                                        {
                                            continue;
                                        }
                                        dtDataSave.ImportRow(row);
                                    }
                                } 
                                bang.P_BO_HANG(ref dtDataSave, "SO_THE", "");
                                DataTable dtDataValidate = dtDataSave.Copy();
                                tl_ch.PNS_TL_EMS_IMP(thamso1_cc.Value, thamso2_cc.Value, dtDataSave);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                // insert vào database
                //string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                if (string.IsNullOrEmpty(ten_file.Text))
                {
                    ten_file.Text = ten_kq.Value;
                }
                ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_LKE();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "form_dong();", true);
                form.P_LOI(this, "loi:Import thành công:loi");

            }
        }
        catch (Exception)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_KD();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_P_LKE();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "form_dong();", true);
            tenForm.Text = ten_mh.Value;
            string b_file = kytu.C_NVL(chon_file.PostedFile.FileName);
            if (b_file == "")
            {
                form.P_LOI(this, Thongbao_dch.ChuaChonFileImport);
            }
            else
            {
                form.P_LOI(this, Thongbao_dch.FileSaiDinhDang);
            }

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

                sError = "Chưa nhập giới tính";
                ImportKiemTra.EmptyValue("GIOITINH_TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày sinh";
                ImportKiemTra.EmptyValue("NGAY_SINH", ref row, ref rowError, ref isError, sError);


                sError = "Chưa nhập Số CMT mới nhất";
                ImportKiemTra.EmptyValue("SO_CMT", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập Ngày cấp CMT mới nhất";
                ImportKiemTra.EmptyValue("NGAY_CMT", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập Nơi cấp CMT mới nhất";
                ImportKiemTra.EmptyValue("NC_CMT_TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập quốc tịch";
                ImportKiemTra.EmptyValue("NN_TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập Công ty";
                ImportKiemTra.EmptyValue("TEN_DONVI", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập chức danh";
                ImportKiemTra.EmptyValue("CDANH_TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập Ban/Phòng";
                ImportKiemTra.EmptyValue("TEN_BAN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập Phòng/Bộ phận";
                ImportKiemTra.EmptyValue("TEN_PHONG_BAN", ref row, ref rowError, ref isError, sError);

                if (!row["GIOITINH_TEN"].Equals(""))
                {
                    sError = "Giới tính";
                    ImportKiemTra.IsValidListMa("GIOITINH_TEN", "GIOITINH_MA", ref row, ref rowError, ref isError, sError);
                }

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
                if (!row["NGAY_CMT_MST"].Equals(""))
                {
                    sError = "Ngày cấp CMT theo MST không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CMT_MST", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_CMT"].Equals(""))
                {
                    sError = "Ngày cấp CMT không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CMT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Ngày vào tập đoàn không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_TV"].Equals(""))
                {
                    sError = "Ngày vào công ty không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_TV", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_CT"].Equals(""))
                {
                    sError = "Ngày vào chính thức không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYTHAMGIA"].Equals(""))
                {
                    sError = "Ngày tham gia CD không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYTHAMGIA", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_CAP_HCHIEU"].Equals(""))
                {
                    sError = "Ngày cấp hộ chiếu không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CAP_HCHIEU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_CAP_MST"].Equals(""))
                {
                    sError = "Ngày cấp mã số thuế không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CAP_MST", ref row, ref rowError, ref isError, sError);
                }

                if (!row["TEN_DONVI"].Equals(""))
                {
                    sError = "Công ty";
                    ImportKiemTra.IsValidListMa("TEN_DONVI", "MA_DONVI", ref row, ref rowError, ref isError, sError);
                }

                if (!row["TEN_PHONG_BAN"].Equals(""))
                {
                    sError = "Phòng/Bộ phận";
                    ImportKiemTra.IsValidListMa("TEN_PHONG_BAN", "MA_PHONG_BAN", ref row, ref rowError, ref isError, sError);
                }

                if (!row["TEN_BAN"].Equals(""))
                {
                    sError = "Ban/Phòng";
                    ImportKiemTra.IsValidListMa("TEN_BAN", "MA_BAN", ref row, ref rowError, ref isError, sError);
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

                sError = "Chưa nhập ngày ký";
                ImportKiemTra.EmptyValue("NGAY_KY", ref row, ref rowError, ref isError, sError);
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

                if (row["HDDAU"].Equals("X"))
                {
                    sError = "Chưa nhập Lương cơ bản";
                    ImportKiemTra.EmptyValue("LUONGCB", ref row, ref rowError, ref isError, sError);

                    sError = "Chưa nhập Tổng thu nhập";
                    ImportKiemTra.EmptyValue("TONG_LUONG", ref row, ref rowError, ref isError, sError);
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

    protected string KiemTraExcel_ns_hdct_excel(DataTable table)
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

                sError = "Chưa nhập loại quyết định";
                ImportKiemTra.EmptyValue("HINHTHUC_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["HINHTHUC_TEN"].Equals(""))
                {
                    sError = "Loại quyết định";
                    ImportKiemTra.IsValidListMa("HINHTHUC_TEN", "HINHTHUC_MA", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập số quyết định";
                ImportKiemTra.EmptyValue("SOQD", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập Lương cơ bản";
                //ImportKiemTra.EmptyValue("LUONGCB", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập Tổng thu nhập";
                //ImportKiemTra.EmptyValue("TONG_LUONG", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày quyết định";
                ImportKiemTra.EmptyValue("NGAY_QD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_QD"].Equals(""))
                {
                    sError = "Ngày quyết định nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_QD", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập Ngày hiệu lực";
                ImportKiemTra.EmptyValue("NGAYD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Ngày hiệu lực nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAYC"].Equals(""))
                {
                    sError = "Ngày hết hiệu lực nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYC", ref row, ref rowError, ref isError, sError);
                }

                if (row["HINHTHUC_MA"].Equals("QD001"))
                {
                    sError = "Chưa nhập Ngày bổ nhiệm lần đầu";
                    ImportKiemTra.EmptyValue("NGAY_BN_LANDAU", ref row, ref rowError, ref isError, sError);

                    if (!row["NGAY_BN_LANDAU"].Equals(""))
                    {
                        sError = "Ngày bổ nhiệm lần đầu nhập không đúng định dạng";
                        ImportKiemTra.IsValidDate("NGAY_BN_LANDAU", ref row, ref rowError, ref isError, sError);
                    }

                    sError = "Chưa nhập Ngày bổ nhiệm gần nhất";
                    ImportKiemTra.EmptyValue("NGAY_BN_GANNHAT", ref row, ref rowError, ref isError, sError);

                    if (!row["NGAY_BN_GANNHAT"].Equals(""))
                    {
                        sError = "Ngày bổ nhiệm gần nhất nhập không đúng định dạng";
                        ImportKiemTra.IsValidDate("NGAY_BN_GANNHAT", ref row, ref rowError, ref isError, sError);
                    }

                    sError = "Chưa nhập Phòng mới";
                    ImportKiemTra.EmptyValue("PHONG_M_TEN", ref row, ref rowError, ref isError, sError);

                    if (!row["PHONG_M_TEN"].Equals(""))
                    {
                        sError = "Phòng mới";
                        ImportKiemTra.IsValidListMa("PHONG_M_TEN", "PHONG_M", ref row, ref rowError, ref isError, sError);
                    }

                    sError = "Chưa nhập Chức danh mới";
                    ImportKiemTra.EmptyValue("CDANH_M_TEN", ref row, ref rowError, ref isError, sError);

                    if (!row["CDANH_M_TEN"].Equals(""))
                    {
                        sError = "Chức danh mới";
                        ImportKiemTra.IsValidListMa("CDANH_M_TEN", "CDANH_M", ref row, ref rowError, ref isError, sError);
                    }
                }

                if (row["HINHTHUC_MA"].Equals("QD004"))
                {

                    sError = "Chưa nhập Phòng mới";
                    ImportKiemTra.EmptyValue("PHONG_M_TEN", ref row, ref rowError, ref isError, sError);

                    if (!row["PHONG_M_TEN"].Equals(""))
                    {
                        sError = "Phòng mới";
                        ImportKiemTra.IsValidListMa("PHONG_M_TEN", "PHONG_M", ref row, ref rowError, ref isError, sError);
                    }

                    sError = "Chưa nhập Chức danh mới";
                    ImportKiemTra.EmptyValue("CDANH_M_TEN", ref row, ref rowError, ref isError, sError);

                    if (!row["CDANH_M_TEN"].Equals(""))
                    {
                        sError = "Chức danh mới";
                        ImportKiemTra.IsValidListMa("CDANH_M_TEN", "CDANH_M", ref row, ref rowError, ref isError, sError);
                    }
                }
                if (row["HINHTHUC_MA"].Equals("QD006"))
                {
                    sError = "Chưa nhập Đơn vị công tác";
                    ImportKiemTra.EmptyValue("DVI_CTAC", ref row, ref rowError, ref isError, sError);
                    sError = "Chưa nhập Địa điểm công tác";
                    ImportKiemTra.EmptyValue("DIADIEM_CTAC", ref row, ref rowError, ref isError, sError);
                    sError = "Chưa nhập Lý do công tác";
                    ImportKiemTra.EmptyValue("LYDO_CTAC", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_hdct_imp_loi.xls", dtError, dtError, "ns_hdct_imp_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception)
        {

            throw;
        }
    }

    public string KiemTraImportMoTaCV(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 5;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                if (iRow == 5)
                {
                    sError = "Mã vị trí chức danh không được để trống";
                    ImportKiemTra.EmptyValue("CDANH", ref row, ref rowError, ref isError, sError);
                }
                if (rows["STT"].ToString() != "" || rows["NV_CV"].ToString() != "" || rows["THAMQUYEN"].ToString() != "" || rows["MUCTIEU_KQ"].ToString() != "")
                {
                    sError = "STT không được để trống";
                    ImportKiemTra.EmptyValue("STT", ref row, ref rowError, ref isError, sError);

                    sError = "Nhiệm vụ công việc không được để trống";
                    ImportKiemTra.EmptyValue("NV_CV", ref row, ref rowError, ref isError, sError);

                    sError = "Thẩm quyền công việc không được để trống";
                    ImportKiemTra.EmptyValue("THAMQUYEN", ref row, ref rowError, ref isError, sError);
                }

                if (rows["STT"].ToString() != "")
                {
                    sError = "STT không đúng định dạng";
                    ImportKiemTra.IsValid_Number("STT", ref row, ref rowError, ref isError, sError);
                }

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
                return "Loi:Lỗi dữ liệu trong file import:Loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_cc_cn_ct(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0) { form.P_LOI(this, "loi:Không có dữ liệu Import:loi"); }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 10;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            DateTime b_dayd = chuyen.CNG_NG(table.Rows[0]["Column37"].ToString());
            DateTime b_ngay_backup = b_dayd;
            DateTime b_dayc = chuyen.CNG_NG(table.Rows[0]["Column38"].ToString());
            var b_day = (b_dayc - b_dayd).TotalDays + 1;
            DataTable b_dt_macc = ht_dungchung.Fdt_NS_THONGTIN_CANBO_QD(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));

            DataTable b_nv = ht_dungchung.Fdt_DS_NHANVIEN_LV(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));
            bang.P_SO_CNG(ref b_nv, "ngay_vao");
            for (int i = 0; i < b_nv.Rows.Count; i++)
            {
                DataRow[] row = table.Select("so_the = '" + b_nv.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    for (int k = 0; k < chuyen.OBJ_N(b_nv.Rows[i]["ngayd"].ToString()); k++)
                    {
                        if (!string.IsNullOrEmpty(row[0][k + 4].ToString()))
                        {
                            return "loi:Không thể mã công nhỏ hơn ngày vào(" + b_nv.Rows[i]["ngay_vao"].ToString() + ") của nhân viên " + b_nv.Rows[i]["so_the"] + ":loi";
                        }
                    }
                }
            }
            DataTable b_nghiviec = ht_dungchung.Fdt_DS_NHANVIEN_NV_TT(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));
            bang.P_SO_CNG(ref b_nghiviec, "ngay_nghi_tt");
            for (int i = 0; i < b_nghiviec.Rows.Count; i++)
            {
                DataRow[] row = table.Select("so_the = '" + b_nghiviec.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    int k = chuyen.OBJ_I(b_nghiviec.Rows[i]["ngay_nghi"].ToString());
                    b_dayd = b_ngay_backup;
                    for (int j = 1; j < b_day; j++)
                    {
                        if (chuyen.OBJ_I((b_dayd.Month.ToString() + (b_dayd.Day < 10 ? "0" + b_dayd.Day.ToString() : b_dayd.Day.ToString()))) >= k)
                        {
                            if (!string.IsNullOrEmpty(row[0][j + 4].ToString()))
                            {
                                return "loi:Không thể xếp ca làm việc lớn hơn ngày nghỉ việc (" + b_nghiviec.Rows[i]["ngay_nghi_tt"].ToString() + ") của nhân viên " + b_nghiviec.Rows[i]["so_the"] + ":loi";
                            }
                        }
                        b_dayd = b_dayd.AddDays(1);
                    }
                }
            }
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (isError)
                {
                    rowError["STT"] = iRow;
                    rowError["so_the"] = sError;
                    dtError.Rows.Add(rowError);
                }
                sError = "Mã nhân viên " + row["so_the"].ToString() + " không tồn tại";
                DataRow[] result = b_dt_macc.Select("SO_THE = '" + row["so_the"] + "'");
                if (result.Length <= 0)
                {
                    rowError["STT"] = iRow;
                    isError = true;
                    rowError["so_the"] = sError;
                }
                iRow = iRow + 1; isError = false; DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/cc_cn_ct_loi.xls", dtError, null, "Import_xuly_chamcong_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }

    public string KiemTraImport_KhaiBao_LamThem(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                var b_ngayky = row["NGAY_DKY"].ToString();
                isError = false;
                sError = "Chưa nhập ngày đăng ký";
                ImportKiemTra.EmptyValue("NGAY_DKY", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_DKY"].Equals(""))
                {
                    sError = "Ngày đăng ký nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_DKY", ref row, ref rowError, ref isError, sError);
                }



                //sError = "Hệ số nhập không đúng";
                //if (!row["NGAY_DKY"].Equals("") && !row["HSO"].Equals(""))
                //{
                //    var b_hso = "";
                //    DataTable b_dt_nk = tl_cc.Fdt_NS_CC_LAY_NGAYLE(chuyen.CNG_SO(b_ngayky));
                //    DateTime ngaykd = DateTime.ParseExact(b_ngayky, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //    if (chuyen.OBJ_I(b_dt_nk.Rows[0]["tontai"].ToString()) > 0) b_hso = "H";
                //    else if ((ngaykd.DayOfWeek == DayOfWeek.Saturday) || (ngaykd.DayOfWeek == DayOfWeek.Sunday)) b_hso = "C";
                //    else b_hso = "T";
                //    if (b_hso != row["HSO"].ToString())
                //    {
                //        isError = true;
                //        rowError["HSO"] = sError;
                //    }
                //}

                sError = "Chưa nhập hệ số";
                ImportKiemTra.EmptyValue("HSO", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                if (!row["SO_THE"].Equals(""))
                {
                    sError = "Mã nhân viên không không đúng";
                    ImportKiemTra.IsValidListMa("SO_THE", "HO_TEN", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập từ giờ";
                ImportKiemTra.EmptyValue("GIO_BD", ref row, ref rowError, ref isError, sError);

                if (!row["GIO_BD"].Equals(""))
                {
                    sError = "Từ giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_BD", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập đến giờ";
                ImportKiemTra.EmptyValue("GIO_KT", ref row, ref rowError, ref isError, sError);

                if (!row["GIO_KT"].Equals(""))
                {
                    sError = "Đến giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_KT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_tt"].Equals(""))
                {
                    sError = "Số giờ làm thêm thanh toán không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_tt", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_ngay"].Equals(""))
                {
                    sError = "Số giờ làm thêm ngày không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_ngay", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_dem"].Equals(""))
                {
                    sError = "Số giờ làm thêm đêm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_dem", ref row, ref rowError, ref isError, sError);
                }
                if (!row["sg_ngay_nb"].Equals(""))
                {
                    sError = "Số giờ làm thêm ngày chuyển nghỉ bù không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sg_ngay_nb", ref row, ref rowError, ref isError, sError);
                }
                if (!row["sg_dem_nb"].Equals(""))
                {
                    sError = "Số giờ làm thêm đêm chuyển nghỉ bù không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sg_dem_nb", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/cc_khaibao_lamthem_loi.xls", dtError, null, "Import_Khaibao_lamthem_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImport_Dky_LamThem(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                var b_ngayky = row["NGAY_DKY"].ToString();
                isError = false;
                sError = "Chưa nhập ngày đăng ký";
                ImportKiemTra.EmptyValue("NGAY_DKY", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_DKY"].Equals(""))
                {
                    sError = "Ngày đăng ký nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_DKY", ref row, ref rowError, ref isError, sError);
                }

                //sError = "Chưa nhập hệ số";
                //ImportKiemTra.EmptyValue("HSO", ref row, ref rowError, ref isError, sError);

                //sError = "Hệ số nhập không đúng";
                //if (!row["NGAY_DKY"].Equals("") && !row["HSO"].Equals(""))
                //{
                //    var b_hso = "";
                //    DataTable b_dt_nk = tl_cc.Fdt_NS_CC_LAY_NGAYLE(chuyen.CNG_SO(b_ngayky));
                //    DateTime ngaykd = DateTime.ParseExact(b_ngayky, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                //    if (chuyen.OBJ_I(b_dt_nk.Rows[0]["tontai"].ToString()) > 0) b_hso = "H";
                //    else if ((ngaykd.DayOfWeek == DayOfWeek.Saturday) || (ngaykd.DayOfWeek == DayOfWeek.Sunday)) b_hso = "C";
                //    else b_hso = "T";
                //    if (b_hso != row["HSO"].ToString())
                //    {
                //        isError = true;
                //        rowError["HSO"] = sError;
                //    }
                //}

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                if (!row["SO_THE"].Equals(""))
                {
                    sError = "Mã nhân viên không không đúng";
                    ImportKiemTra.IsValidListMa("SO_THE", "HO_TEN", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập giờ bắt đầu";
                ImportKiemTra.EmptyValue("GIO_BD", ref row, ref rowError, ref isError, sError);
                if (!row["GIO_BD"].Equals(""))
                {
                    sError = "Từ giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_BD", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập giờ kết thúc";
                ImportKiemTra.EmptyValue("GIO_KT", ref row, ref rowError, ref isError, sError);
                if (!row["GIO_KT"].Equals(""))
                {
                    sError = "Đến giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_KT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_tt"].Equals(""))
                {
                    sError = "Số giờ làm thêm thanh toán không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_tt", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_ngay"].Equals(""))
                {
                    sError = "Số giờ làm thêm ngày không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_ngay", ref row, ref rowError, ref isError, sError);
                }
                if (!row["so_gio_dem"].Equals(""))
                {
                    sError = "Số giờ làm thêm đêm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("so_gio_dem", ref row, ref rowError, ref isError, sError);
                }
                if (!row["sg_ngay_nb"].Equals(""))
                {
                    sError = "Số giờ làm thêm ngày chuyển nghỉ bù không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sg_ngay_nb", ref row, ref rowError, ref isError, sError);
                }
                if (!row["sg_dem_nb"].Equals(""))
                {
                    sError = "Số giờ làm thêm đêm chuyển nghỉ bù không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sg_dem_nb", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/cc_khaibao_lamthem_loi.xls", dtError, null, "Import_Khaibao_lamthem_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImport_THONGTIN_NGHI(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            bang.P_COPY_COL(ref table, "ngayd_check", "NGAYD");
            bang.P_COPY_COL(ref table, "ngayc_check", "NGAYC");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                //sError = "Chưa nhập năm tính phép";
                //ImportKiemTra.EmptyValue("NAMTRU", ref row, ref rowError, ref isError, sError);
                //if (!row["NAMTRU"].Equals(""))
                //{
                //    sError = "Năm nhập không đúng định dạng";
                //    ImportKiemTra.IsValid_Number("NAMTRU", ref row, ref rowError, ref isError, sError);
                //}
                sError = "Chưa nhập kiểu nghỉ";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập kiểu nghỉ";
                ImportKiemTra.EmptyValue("MACC_NGHI", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập nghỉ từ ngày";
                ImportKiemTra.EmptyValue("NGAYD", ref row, ref rowError, ref isError, sError);
                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Nghỉ từ ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chưa nhập nghỉ đến ngày thúc nghỉ";
                ImportKiemTra.EmptyValue("NGAYC", ref row, ref rowError, ref isError, sError);
                if (!row["NGAYC"].Equals(""))
                {
                    sError = "Nghỉ đến ngày nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYC", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAYD"].Equals("") && !row["NGAYC"].Equals(""))
                {
                    string mes = "";
                    if (skhac.CheckDate(chuyen.CNG_SO(row["ngayd_check"].ToString()).ToString(), chuyen.CNG_SO(row["ngayc_check"].ToString()).ToString(), ref mes) == false)
                    {
                        rowError["ngayd"] = "Từ ngày không được lớn hơn đến ngày";
                        isError = true;
                    }
                }

                if (!row["MA"].Equals(""))
                {
                    sError = "Kiểu nghỉ nhập không đúng";
                    ImportKiemTra.IsValidListMa("MA", "MACC_NGHI", ref row, ref rowError, ref isError, sError);
                }
                //if (!row["GIOD"].Equals(""))
                //{
                //    sError = "Từ giờ nhập không đúng định dạng";
                //    ImportKiemTra.IsValidTime("GIOD", ref row, ref rowError, ref isError, sError);
                //}
                //if (!row["GIOC"].Equals(""))
                //{
                //    sError = "Đến giờ nhập không đúng định dạng";
                //    ImportKiemTra.IsValidTime("GIOC", ref row, ref rowError, ref isError, sError);
                //}
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_cc_thongtin_nghi_loi.xls", dtError, null, "Import_thongtinnghi_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }

    public string KiemTraImport_KHOAN_PHAITHU(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            //bang.P_COPY_COL(ref table, "ngayd_check", "NGAYD");
            //bang.P_COPY_COL(ref table, "ngayc_check", "NGAYC");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                //sError = "Chưa nhập kiểu nghỉ";
                //ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên nhân viên";
                ImportKiemTra.EmptyValue("HO_TEN", ref row, ref rowError, ref isError, sError);

                if (!row["NAM"].Equals(""))
                {
                    sError = "Năm nhập không đúng định dạng";
                    ImportKiemTra.IsValidYear("NAM", ref row, ref rowError, ref isError, sError);
                }

                if (!row["sotien_thu"].Equals(""))
                {
                    sError = "Tiền thu nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sotien_thu", ref row, ref rowError, ref isError, sError);
                }

                if (!row["sotien_tra"].Equals(""))
                {
                    sError = "Tiền trả nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("sotien_tra", ref row, ref rowError, ref isError, sError);
                }

                //if (!row["NGAYD"].Equals("") && !row["NGAYC"].Equals(""))
                //{
                //    string mes = "";
                //    if (skhac.CheckDate(chuyen.CNG_SO(row["ngayd_check"].ToString()).ToString(), chuyen.CNG_SO(row["ngayc_check"].ToString()).ToString(), ref mes) == false)
                //    {
                //        rowError["ngayd"] = "Từ ngày không được lớn hơn đến ngày";
                //        isError = true;
                //    }
                //}

                //if (!row["MA"].Equals(""))
                //{
                //    sError = "Kiểu nghỉ nhập không đúng";
                //    ImportKiemTra.IsValidListMa("MA", "MACC_NGHI", ref row, ref rowError, ref isError, sError);
                //}

                //if (!row["GIOD"].Equals(""))
                //{
                //    sError = "Từ giờ nhập không đúng định dạng";
                //    ImportKiemTra.IsValidTime("GIOD", ref row, ref rowError, ref isError, sError);
                //}
                //if (!row["GIOC"].Equals(""))
                //{
                //    sError = "Đến giờ nhập không đúng định dạng";
                //    ImportKiemTra.IsValidTime("GIOC", ref row, ref rowError, ref isError, sError);
                //}
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_tl_khoan_phaithu_loi.xls", dtError, null, "Import_khoanphaithu_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraDuLieuVaoRa(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 4;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            DataTable b_dt_macc = ht_dungchung.Fdt_ID_CC_DR();

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập mã chấm công";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Mã chấm công không đúng định dạng";
                ImportKiemTra.IsValid_Number("MA", ref row, ref rowError, ref isError, sError);

                sError = "Mã chấm công " + row["MA"].ToString() + " không tồn tại";

                DataRow[] result = b_dt_macc.Select("MA_CC = '" + row["MA"] + "'");
                if (result.Length <= 0)
                {
                    isError = true;
                    rowError["MA"] = sError;
                }

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
                Excel_dungchung.ExportTemplate("Templates/importmau/Import_Vaora_loi.xls", dtError, dtError, "Import_Vaora_loi" + DateTime.Now.ToString("ddMMyyyy"));
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTra_uyquyen_qtthue(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Mã nhân viên không được để trống";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                sError = "Năm không được để trống";
                ImportKiemTra.EmptyValue("nam", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/tl_phanca_loi.xls", dtError, null, "Import_thietlapphanca_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImportLuongKhac(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Mã nhân viên không được để trống";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

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
                return "Lỗi dữ liệu trong file import";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_TlPhaca(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 9;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            DataTable b_dt_macc = ht_dungchung.Fdt_NS_THONGTIN_CANBO_QD(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));

            DataTable b_nv = ht_dungchung.Fdt_DS_NHANVIEN_LV(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));
            bang.P_SO_CNG(ref b_nv, "ngay_vao");
            for (int i = 0; i < b_nv.Rows.Count; i++)
            {
                DataRow[] row = table.Select("so_the = '" + b_nv.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    for (int k = 0; k < chuyen.OBJ_N(b_nv.Rows[i]["ngayd"].ToString()); k++)
                    {
                        if (!string.IsNullOrEmpty(row[0][k + 4].ToString()))
                        {
                            return "loi:Không thể xếp ca làm việc nhỏ hơn ngày vào(" + b_nv.Rows[i]["ngay_vao"].ToString() + ") của nhân viên " + b_nv.Rows[i]["so_the"] + ":loi";
                        }
                    }
                }
            }
            DataTable b_nghiviec = ht_dungchung.Fdt_DS_NHANVIEN_NV_TT(thamso2_cc.Value, chuyen.OBJ_N(thamso1_cc.Value));
            bang.P_SO_CNG(ref b_nghiviec, "ngay_nghi_tt");
            for (int i = 0; i < b_nghiviec.Rows.Count; i++)
            {
                DataRow[] row = table.Select("so_the = '" + b_nghiviec.Rows[i]["so_the"] + "'");
                if (row.Length > 0)
                {
                    for (int k = chuyen.OBJ_I(b_nghiviec.Rows[i]["ngayd"].ToString()); k <= 27; k++)
                    {
                        if (!string.IsNullOrEmpty(row[0][k + 4].ToString()))
                        {
                            return "loi:Không thể xếp ca làm việc lớn hơn ngày nghỉ việc (" + b_nghiviec.Rows[i]["ngay_nghi_tt"].ToString() + ") của nhân viên " + b_nghiviec.Rows[i]["so_the"] + ":loi";
                        }
                    }
                }
            }

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                sError = "Mã nhân viên " + row["so_the"].ToString() + " không tồn tại";
                DataRow[] result = b_dt_macc.Select("SO_THE = '" + row["so_the"] + "'");
                if (result.Length <= 0)
                {
                    isError = true;
                    rowError["so_the"] = sError;
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importloi/tl_phanca_loi.xls", dtError, null, "Import_thietlapphanca_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImport_kh_nam(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Năm không được để trống";
                ImportKiemTra.EmptyValue("nam", ref row, ref rowError, ref isError, sError);
                if (!row["NAM"].Equals(""))
                {
                    sError = "Năm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("nam", ref row, ref rowError, ref isError, sError);
                }

                sError = "Công ty không được để trống";
                ImportKiemTra.EmptyValue("TEN_DONVI", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_DONVI"].Equals(""))
                {
                    sError = "Công ty";
                    ImportKiemTra.IsValidListMa("TEN_DONVI", "DONVI", ref row, ref rowError, ref isError, sError);
                }

                sError = "Phòng/Ban không được để trống";
                ImportKiemTra.EmptyValue("TEN_BAN", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_BAN"].Equals(""))
                {
                    sError = "Phòng/Ban";
                    ImportKiemTra.IsValidListMa("TEN_BAN", "BAN", ref row, ref rowError, ref isError, sError);
                }

                sError = "Phòng/Bộ phận không được để trống";
                ImportKiemTra.EmptyValue("TEN_PHONG", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_PHONG"].Equals(""))
                {
                    sError = "Phòng/Bộ phận";
                    ImportKiemTra.IsValidListMa("TEN_PHONG", "PHONG", ref row, ref rowError, ref isError, sError);
                }

                sError = "Chức danh không được để trống";
                ImportKiemTra.EmptyValue("TEN_CDANH", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_CDANH"].Equals(""))
                {
                    sError = "Chức danh";
                    ImportKiemTra.IsValidListMa("TEN_CDANH", "CDANH", ref row, ref rowError, ref isError, sError);
                }

                sError = "Cấp bậc";
                ImportKiemTra.EmptyValue("TEN_CAPBAC", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_CAPBAC"].Equals(""))
                {
                    sError = "Cấp bậc";
                    ImportKiemTra.IsValidListMa("TEN_CAPBAC", "CAPBAC", ref row, ref rowError, ref isError, sError);
                }

                sError = "Số lượng cần tuyển không được để trống";
                ImportKiemTra.EmptyValue("SL_CANTUYEN", ref row, ref rowError, ref isError, sError);
                if (!row["SL_CANTUYEN"].Equals(""))
                {
                    sError = "Số lượng cần tuyển không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SL_CANTUYEN", ref row, ref rowError, ref isError, sError);
                }

                if (!string.IsNullOrEmpty(row["NGAYCAN_NS"].ToString()))
                {
                    sError = "Ngày cần nhân sự";
                    ImportKiemTra.IsValidDate("NGAYCAN_NS", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_kh_nam_loi.xls", dtError, dtError, "ns_td_kh_nam_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_THONGTIN_DMVS(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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

                sError = "Từ giờ không được để trống";
                ImportKiemTra.EmptyValue("GIOD", ref row, ref rowError, ref isError, sError);

                sError = "Đến giờ không được để trống";
                ImportKiemTra.EmptyValue("GIOC", ref row, ref rowError, ref isError, sError);

                sError = "Số phút không được để trống";
                ImportKiemTra.EmptyValue("SOPHUT", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày đăng ký";
                ImportKiemTra.EmptyValue("NGAY_DKY", ref row, ref rowError, ref isError, sError);
                if (!row["NGAY_DKY"].Equals(""))
                {
                    sError = "Ngày đăng ký nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_DKY", ref row, ref rowError, ref isError, sError);
                }


                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                if (!row["SO_THE"].Equals(""))
                {
                    sError = "Tên nhân viên không đúng";
                    ImportKiemTra.IsValidListMa("SO_THE", "HO_TEN", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập kiểu đăng ký";
                ImportKiemTra.EmptyValue("LOAI_DKY", ref row, ref rowError, ref isError, sError);
                if (!row["LOAI_DKY"].Equals(""))
                {
                    sError = "Loại đăng ký nhập không đúng";
                    ImportKiemTra.IsValidListMa("LOAI_DKY", "TEN_LOAI_DKY", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/cc_dky_dmvs_loi.xls", dtError, null, "Import_DMVS_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImportthongtinBH(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 9;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Mã nhân viên không được để trống";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (!row["LUONG_BH"].Equals(""))
                {
                    sError = "Lương bảo hiểm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("LUONG_BH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TG_DONGBH_TRUOC"].Equals(""))
                {
                    sError = "Thời gian đóng bảo hiểm trước khi vào công ty không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TG_DONGBH_TRUOC", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TUTHANG_BHXH"].Equals(""))
                {
                    sError = "Từ tháng BHXH không đúng định dạng";
                    ImportKiemTra.IsValidMonth("TUTHANG_BHXH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENTHANG_BHXH"].Equals(""))
                {
                    sError = "Đến tháng BHXH không đúng định dạng";
                    ImportKiemTra.IsValidMonth("DENTHANG_BHXH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TINHTRANG_SO"].Equals(""))
                {
                    sError = "Tình trạng sổ BHXH";
                    ImportKiemTra.IsValidListMa("TEN_TINHTRANG_SO", "TINHTRANG_SO", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_CAP"].Equals(""))
                {
                    sError = "Ngày cấp không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CAP", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_NOP"].Equals(""))
                {
                    sError = "Ngày nộp không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_NOP", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TUTHANG_BHYT"].Equals(""))
                {
                    sError = "Từ tháng BHYT không đúng định dạng";
                    ImportKiemTra.IsValidMonth("TUTHANG_BHYT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENTHANG_BHYT"].Equals(""))
                {
                    sError = "Đến tháng BHYT không đúng định dạng";
                    ImportKiemTra.IsValidMonth("DENTHANG_BHYT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TINHTRANG_THE"].Equals(""))
                {
                    sError = "Tình trạng thẻ BHYT";
                    ImportKiemTra.IsValidListMa("TEN_TINHTRANG_THE", "TINHTRANG_THE", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_HL"].Equals(""))
                {
                    sError = "Ngày hiệu lực không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_HL", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_HHL"].Equals(""))
                {
                    sError = "Ngày hết hiệu lực không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_HHL", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_NOIKHAM"].Equals(""))
                {
                    sError = "Nơi khám chữa bệnh";
                    ImportKiemTra.IsValidListMa("TEN_NOIKHAM", "NOIKHAM_CHUABENH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_BANGIAOTHE"].Equals(""))
                {
                    sError = "Ngày bàn giao thẻ không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_BANGIAOTHE", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TUTHANG_BHTN"].Equals(""))
                {
                    sError = "Từ tháng BHTN không đúng định dạng";
                    ImportKiemTra.IsValidMonth("TUTHANG_BHTN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENTHANG_BHTN"].Equals(""))
                {
                    sError = "Đến tháng BHTN không đúng định dạng";
                    ImportKiemTra.IsValidMonth("DENTHANG_BHTN", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_tt_bh_loi.xls", dtError, dtError, "ns_tt_bh_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImportKho_UV(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 8;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                // ------------------------------------ Thông tin chung ---------------------------------------
                if (!row["MUCLUONG_MM"].Equals("") || !row["TEN_GIOITINH"].Equals("") || !row["NGAYSINH"].Equals(""))
                {
                    sError = "Họ và tên ứng viên không được để trống";
                    ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN"].Equals(""))
                {
                    sError = "Lương mong muốn không được để trống";
                    ImportKiemTra.EmptyValue("MUCLUONG_MM", ref row, ref rowError, ref isError, sError);

                    sError = "Giới tính không được để trống";
                    ImportKiemTra.EmptyValue("TEN_GIOITINH", ref row, ref rowError, ref isError, sError);

                    sError = "Ngày sinh không được để trống";
                    ImportKiemTra.EmptyValue("NGAYSINH", ref row, ref rowError, ref isError, sError);

                    sError = "CMND không được để trống";
                    ImportKiemTra.EmptyValue("SO_CMT", ref row, ref rowError, ref isError, sError);

                    sError = "Email không được để trống";
                    ImportKiemTra.EmptyValue("EMAIL", ref row, ref rowError, ref isError, sError);
                }

                if (!row["MUCLUONG_MM"].Equals(""))
                {
                    sError = "Lương mong muốn không đúng định dạng";
                    ImportKiemTra.IsValid_Number("MUCLUONG_MM", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_GIOITINH"].Equals(""))
                {
                    sError = "Giới tính";
                    ImportKiemTra.IsValidListMa("TEN_GIOITINH", "GIOITINH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYSINH"].Equals(""))
                {
                    sError = "Ngày sinh nhập không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYSINH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TT_NOISINH"].Equals(""))
                {
                    sError = "Tỉnh/Thành phố nơi sinh";
                    ImportKiemTra.IsValidListMa("TEN_TT_NOISINH", "TT_NOISINH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_QH_NOISINH"].Equals(""))
                {
                    sError = "Quận/Huyện nơi sinh";
                    ImportKiemTra.IsValidListMa("TEN_QH_NOISINH", "QH_NOISINH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_XP_NOISINH"].Equals(""))
                {
                    sError = "Xã/Phường nơi sinh";
                    ImportKiemTra.IsValidListMa("TEN_XP_NOISINH", "XP_NOISINH", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYCAP_CMT"].Equals(""))
                {
                    sError = "Ngày cấp CMT";
                    ImportKiemTra.IsValidDate("NGAYCAP_CMT", ref row, ref rowError, ref isError, sError);
                }

                if (!row["TEN_TT_TAMTRU"].Equals(""))
                {
                    sError = "Tỉnh/Thành phố tạm trú";
                    ImportKiemTra.IsValidListMa("TEN_TT_TAMTRU", "TT_TAMTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_QH_TAMTRU"].Equals(""))
                {
                    sError = "Quận/Huyện tạm trú";
                    ImportKiemTra.IsValidListMa("TEN_QH_TAMTRU", "QH_TAMTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_XP_TAMTRU"].Equals(""))
                {
                    sError = "Xã/Phường tạm trú";
                    ImportKiemTra.IsValidListMa("TEN_XP_TAMTRU", "XP_TAMTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TT_THUONGTRU"].Equals(""))
                {
                    sError = "Tỉnh/Thành phố thường trú";
                    ImportKiemTra.IsValidListMa("TEN_TT_THUONGTRU", "TT_THUONGTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_QH_THUONGTRU"].Equals(""))
                {
                    sError = "Quận/Huyện thường trú";
                    ImportKiemTra.IsValidListMa("TEN_QH_THUONGTRU", "QH_THUONGTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_XP_THUONGTRU"].Equals(""))
                {
                    sError = "Xã/Phường thường trú";
                    ImportKiemTra.IsValidListMa("TEN_XP_THUONGTRU", "XP_THUONGTRU", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TT_HONNHAN"].Equals(""))
                {
                    sError = "Tình trạng hôn nhân";
                    ImportKiemTra.IsValidListMa("TEN_TT_HONNHAN", "TT_HONNHAN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["EMAIL"].Equals(""))
                {
                    sError = "Email sai định dạng";
                    ImportKiemTra.IsValidEmail("EMAIL", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_DANTOC"].Equals(""))
                {
                    sError = "Dân tộc";
                    ImportKiemTra.IsValidListMa("TEN_DANTOC", "DANTOC", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TONGIAO"].Equals(""))
                {
                    sError = "Tôn giáo";
                    ImportKiemTra.IsValidListMa("TEN_TONGIAO", "TONGIAO", ref row, ref rowError, ref isError, sError);
                }
                //----------------------------------------------Trình độ học vấn -----------------------------------------------------------
                if (!row["TEN_TENTRUONG_TD"].Equals(""))
                {
                    sError = "Trường";
                    ImportKiemTra.IsValidListMa("TEN_TENTRUONG_TD", "TENTRUONG_TD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_CHUYENNGANH_TD"].Equals(""))
                {
                    sError = "Chuyên ngành";
                    ImportKiemTra.IsValidListMa("TEN_CHUYENNGANH_TD", "CHUYENNGANH_TD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TUNAM_TD"].Equals(""))
                {
                    sError = "Từ năm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TUNAM_TD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENNAM_TD"].Equals(""))
                {
                    sError = "Đến năm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("DENNAM_TD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_TRINHDO_TD"].Equals(""))
                {
                    sError = "Trình độ ";
                    ImportKiemTra.IsValidListMa("TEN_TRINHDO_TD", "TRINHDO_TD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_HINHTHUC_DT_TD"].Equals(""))
                {
                    sError = "Hình thức đào tạo";
                    ImportKiemTra.IsValidListMa("TEN_HINHTHUC_DT_TD", "HINHTHUC_DT_TD", ref row, ref rowError, ref isError, sError);
                }
                //----------------------------------------------Chứng chỉ--------- -----------------------------------------------------------
                if (!row["TUNGAY_CC"].Equals(""))
                {
                    sError = "Từ ngày";
                    ImportKiemTra.IsValidDate("TUNGAY_CC", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENNGAY_CC"].Equals(""))
                {
                    sError = "Đến ngày";
                    ImportKiemTra.IsValidDate("DENNGAY_CC", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_HL_CC"].Equals(""))
                {
                    sError = "Ngày hiệu lực";
                    ImportKiemTra.IsValidDate("NGAY_HL_CC", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAY_HHL_CC"].Equals(""))
                {
                    sError = "Ngày hết hiệu lực";
                    ImportKiemTra.IsValidDate("NGAY_HHL_CC", ref row, ref rowError, ref isError, sError);
                }
                //----------------------------------------------Quá trình công tác -----------------------------------------------------------
                if (!row["TUTHANG_CT"].Equals(""))
                {
                    sError = "Từ tháng";
                    ImportKiemTra.IsValidMonth("TUTHANG_CT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["DENTHANG_CT"].Equals(""))
                {
                    sError = "Đến tháng";
                    ImportKiemTra.IsValidMonth("DENTHANG_CT", ref row, ref rowError, ref isError, sError);
                }
                // ------------------------------------------- Quan hệ nhân thân --------------------------------------------------------
                if (!row["TEN_QUANHE_TN"].Equals(""))
                {
                    sError = "Quan hệ";
                    ImportKiemTra.IsValidListMa("TEN_QUANHE_TN", "QUANHE_TN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYSINH_TN"].Equals(""))
                {
                    sError = "Ngày sinh";
                    ImportKiemTra.IsValidDate("NGAYSINH_TN", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_uv_imp_loi.xls", dtError, dtError, "ns_ma_kho_uv_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImportKetQua_UV(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 8;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã yêu cầu tuyển dụng";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập năm yêu cầu";
                ImportKiemTra.EmptyValue("NAM", ref row, ref rowError, ref isError, sError);
                if (!row["NAM"].Equals(""))
                {
                    sError = "Năm yêu cầu";
                    ImportKiemTra.IsValid_Number("NAM", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập tháng yêu cầu";
                ImportKiemTra.EmptyValue("THANG", ref row, ref rowError, ref isError, sError);
                if (!row["THANG"].Equals(""))
                {
                    sError = "Tháng yêu cầu";
                    ImportKiemTra.IsValid_Number("THANG", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYTHI1"].Equals(""))
                {
                    sError = "Ngày thi môn 1";
                    ImportKiemTra.IsValidDate("NGAYTHI1", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYTHI2"].Equals(""))
                {
                    sError = "Ngày thi môn 2";
                    ImportKiemTra.IsValidDate("NGAYTHI2", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYTHI3"].Equals(""))
                {
                    sError = "Ngày thi môn 3";
                    ImportKiemTra.IsValidDate("NGAYTHI3", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập kết quả chung";
                ImportKiemTra.EmptyValue("TEN_KETQUA_CHUNG", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_KETQUA_CHUNG"].Equals(""))
                {
                    sError = "Kết quả chung";
                    ImportKiemTra.IsValidList("TEN_KETQUA_CHUNG", "KETQUA_CHUNG", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_kq_loi.xlsx", dtError, dtError, "ns_td_kq_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public DataTable Xoacot_thua(string[] columnName, DataTable dt_data)
    {
        try
        {
            DataTable dt = dt_data.Copy();
            foreach (string col in columnName)
            {
                dt.Columns.Remove(col);
            }
            return dt;
        }
        catch (Exception)
        {
            throw;
        }


    }
    public DataTable RemoveDuplicateRows(DataTable dTable, string colName)
    {
        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
        //And add duplicate item value in arraylist.
        foreach (DataRow drow in dTable.Rows)
        {
            if (hTable.Contains(drow[colName]))
                duplicateList.Add(drow);
            else
                hTable.Add(drow[colName], string.Empty);
        }

        //Removing a list of duplicate items from datatable.
        foreach (DataRow dRow in duplicateList)
            dTable.Rows.Remove(dRow);

        //Datatable which contains unique records will be return as output.
        return dTable;
    }
    public string KiemTraImportDinhBien(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 8;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Năm không được để trống";
                ImportKiemTra.EmptyValue("NAM", ref row, ref rowError, ref isError, sError);
                sError = "Đơn vị không được để trống";
                ImportKiemTra.EmptyValue("TEN_DVI", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_DVI"].Equals(""))
                {
                    sError = "Đơn vị";
                    ImportKiemTra.IsValidListMa("TEN_DVI", "DONVI", ref row, ref rowError, ref isError, sError);
                }
                sError = "Phòng ban không được để trống";
                ImportKiemTra.EmptyValue("TEN_PHONG", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_PHONG"].Equals(""))
                {
                    sError = "Phòng ban";
                    ImportKiemTra.IsValidListMa("TEN_PHONG", "PHONG", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chức danh không được để trống";
                ImportKiemTra.EmptyValue("CDANH", ref row, ref rowError, ref isError, sError);
                if (!row["CDANH"].Equals(""))
                {
                    sError = "Chức danh";
                    ImportKiemTra.IsValidListMa("CDANH", "CDANH", ref row, ref rowError, ref isError, sError);
                }

                //sError = "Nhân sự hiện tại không được để trống";
                //ImportKiemTra.EmptyValue("NS_HIENTAI", ref row, ref rowError, ref isError, sError);
                //if (!row["NS_HIENTAI"].Equals(""))
                //{
                //    sError = "Nhân sự hiện tại";
                //    ImportKiemTra.IsValid_Number("NS_HIENTAI", ref row, ref rowError, ref isError, sError);
                //}
                if (!row["SL_DINHBIEN"].Equals(""))
                {
                    sError = "Số lượng định biên";
                    ImportKiemTra.IsValid_Number("SL_DINHBIEN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["SL_DBIEN_PS"].Equals(""))
                {
                    sError = "Số lượng định biên phát sinh";
                    ImportKiemTra.IsValid_Number("SL_DBIEN_PS", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TONG_DBIEN"].Equals(""))
                {
                    sError = "Tổng định biên";
                    ImportKiemTra.IsValid_Number("TONG_DBIEN", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_td_dinhbien_loi.xls", dtError, dtError, "ns_td_dinhbien_loi" + DateTime.Now.ToString("ddMMyyyy"));
                HttpContext.Current.Session.Add("NS_TD_DINHBIEN_SS", "2");
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_TIEUCHI_DG(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Chưa nhập mã nhóm tiêu chí";
                ImportKiemTra.EmptyValue("MA_NHOM", ref row, ref rowError, ref isError, sError);

                sError = "Tên tiêu chí không được để trống";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                // sError = "Mã tiêu chí không được để trống";
                // ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Nhóm tiêu chí không được để trống";
                ImportKiemTra.EmptyValue("MA_NHOM_TC", ref row, ref rowError, ref isError, sError);

                sError = "Trạng thái không được để trống";
                ImportKiemTra.EmptyValue("TEN_TT", ref row, ref rowError, ref isError, sError);
                if (rows["MA"].ToString() != "")
                {
                    sError = "Độ dài tên tiêu chí vượt quá 100 ký tự";
                    ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 100);
                }

                sError = "Trạng thái không được để trống";
                ImportKiemTra.EmptyValue("TT", ref row, ref rowError, ref isError, sError);

                //if (!row["TEN_TT"].Equals(""))
                //{
                //    sError = "Trạng thái";
                //    ImportKiemTra.IsValidListMa("TEN_TT", "TT", ref row, ref rowError, ref isError, sError);
                //}
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
                //dtError.TableName = "DATA";
                Excel_dungchung.ExportTemplate("Templates/importloi/dg_dm_tieuchi_loi.xls", dtError, null, "Import_dg_dm_tc_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_dg_cv_thang(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 9;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            DataTable b_nv = ht_dungchung.Fdt_NS_CB_DS();
            //dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập số thẻ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (!row["SO_THE"].Equals(""))
                {
                    sError = "Mã nhân viên " + row["so_the"].ToString() + " không tồn tại";
                    DataRow[] result = b_nv.Select("SO_THE = '" + row["so_the"] + "'");
                    if (result.Length <= 0)
                    {
                        isError = true;
                        rowError["so_the"] = sError;
                    }
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
                Excel_dungchung.ExportTemplate("Templates/importloi/dg_kq_dgia_thang_loi.xlsx", dtError, null, "Import_dg_kq_dgia_thang_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImportHocvien(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 8;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("SOTT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "STT không được để trống";
                ImportKiemTra.EmptyValue("STT", ref row, ref rowError, ref isError, sError);
                sError = "Số thẻ không được để trống";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_HV"].Equals(""))
                {
                    sError = "Tên học viên";
                    ImportKiemTra.IsValidListMa("TEN_HV", "SO_THE", ref row, ref rowError, ref isError, sError);
                }
                // sError = "Tên học viên không được để trống";
                // ImportKiemTra.EmptyValue("TEN_HV", ref row, ref rowError, ref isError, sError);

                //sError = "Loại học viên không được để trống";
                //if (!row["LOAI_HV"].Equals(""))
                //{
                //    sError = "Loại học viên";
                //    ImportKiemTra.EmptyValue("TEN_PHONG", ref row, ref rowError, ref isError, sError);
                //}



                if (isError)
                {
                    rowError["SOTT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_dt_hvien_tgian_loi.xls", dtError, dtError, "ns_dt_hvien_tgian_loi" + DateTime.Now.ToString("ddMMyyyy"));
                //HttpContext.Current.Session.Add("NS_TD_DINHBIEN_SS", "2");
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string KiemTraImport_Cdanh(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Chưa nhập mã chức danh";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chức danh";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập mã chuyên môn";
                //ImportKiemTra.EmptyValue("MA_CMON", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập tên chuyên môn";
                //ImportKiemTra.EmptyValue("TEN_CMON", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập mã ngạch ngành nghề";
                //ImportKiemTra.EmptyValue("MA_NNNGHE", ref row, ref rowError, ref isError, sError);

                //sError = "Chưa nhập mã cấp bậc";
                //ImportKiemTra.EmptyValue("MA_CAPBAC", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã nhóm chức danh";
                ImportKiemTra.EmptyValue("MA_NNGHE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên nhóm chức danh";
                ImportKiemTra.EmptyValue("TEN_NNN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập trạng thái";
                ImportKiemTra.EmptyValue("TT", ref row, ref rowError, ref isError, sError);

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
                Excel_dungchung.ExportTemplate("Templates/importloi/hd_ma_cdanh_loi.xls", dtError, null, "Import_vitri_cdanh_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_dg_dm_mdg(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Chưa nhập năm";
                ImportKiemTra.EmptyValue("NAM", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập kỳ đánh giá";
                ImportKiemTra.EmptyValue("KY_DG", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập nhóm chức danh";
                ImportKiemTra.EmptyValue("NHOM_CDANH", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập chức danh";
                ImportKiemTra.EmptyValue("CDANH", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập đối tượng đánh giá";
                ImportKiemTra.EmptyValue("DOITUONG_DG", ref row, ref rowError, ref isError, sError);
                if (!row["NGAY_AD"].Equals(""))
                {
                    sError = "Ngày áp dụng không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_AD", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập nhóm câu hỏi";
                ImportKiemTra.EmptyValue("NHOM_CAUHOI", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập mã câu hỏi";
                ImportKiemTra.EmptyValue("MA_CAUHOI", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập nội dung câu hỏi";
                ImportKiemTra.EmptyValue("ND_CAUHOI", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/dg_dm_mdg_loi.xlsx", dtError, null, "Import_dg_dm_mdg_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImport_QHE(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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
                sError = "Chưa Nhập Họ tên thân nhân";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa Nhập mã mối quan hệ";
                ImportKiemTra.EmptyValue("LQHE", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_CMT"].Equals(""))
                {
                    sError = "Ngày cấp không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_CMT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYD"].Equals(""))
                {
                    sError = "Ngày bắt đầu giảm trừ không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["NGAYC"].Equals(""))
                {
                    sError = "Ngày kết thúc giảm trừ không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAYC", ref row, ref rowError, ref isError, sError);
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
                //dtError.TableName = "DATA";
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_qhe_loi.xls", dtError, null, "Import_qhe_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_CCNV(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
            DataRow rowError;
            bool isError = false;
            var sError = string.Empty;
            var dtError = table.Clone();
            DataError = table.Clone();
            var iRow = 7;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Công chuân không được để trống";
                ImportKiemTra.EmptyValue("CONG_CHUAN", ref row, ref rowError, ref isError, sError);

                if (!row["CONG_CHUAN"].Equals(""))
                {
                    sError = "Công chuẩn phải lớn hơn không";
                    ImportKiemTra.IsValid_Number("CONG_CHUAN", ref row, ref rowError, ref isError, sError, true);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_cc_ma_ccnv_loi.xls", dtError, dtError, "ns_cc_ma_ccnv_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_dsach_thieu_plenh(DataTable table)
    {
        var b_dt = new DataTable("ERROR");
        var DataError = new DataTable();
        try
        {
            if (table.Rows.Count <= 0)
            {
                form.P_LOI(this, "loi:Không có dữ liệu Import:loi");
            }
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

                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                if (!row["SO_PLENH_THIEU"].Equals(""))
                {
                    sError = "Số phiếu lệnh thiếu không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SO_PLENH_THIEU", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importmau/ns_dsach_thieu_plenh_loi.xls", dtError, null, "Import_danh_sach_thieu_phieu_lenh" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
}
