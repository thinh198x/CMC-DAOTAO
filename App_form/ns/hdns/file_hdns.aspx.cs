using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;
using System.Collections.Generic;

public partial class f_file_hdns : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/file_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hdns_P_KD();", true);
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

            string b_file = kytu.C_NVL(chon_file.PostedFile.FileName), b_tm, b_ten;
            string b_so_id = so_id.Value;
            string b_ngay = DateTime.Now.ToString();


            if (b_file == "")
            {
                if (b_so_id == "0") form.P_LOI(this, Thongbao_dch.ChuaChonFileImport);
                else
                {
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/hdns/file_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hdns_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hdns_P_LKE();", true);
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
                DataTable dtDataSave, dt_ktr;
                try
                {
                    if (File.Exists(b_ten)) File.Delete(b_ten);
                    chon_file.PostedFile.SaveAs(b_ten);
                    workbook = new Workbook(b_ten);
                    worksheet = workbook.Worksheets[0];
                    string s_ten = ten_form.Value;
                    if (string.IsNullOrEmpty(s_ten)) { form.P_LOI(this, Thongbao_dch.ChuaChonFileImport); }

                    switch (ten_form.Value)
                    {
                        case "ht_maph":
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
                                string b_kiemtra = KiemTraImport_PH(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_CNG_SO(ref dtDataSave, "NGAY_TL,NGAY_GT");
                                    ht_maph.P_MA_PH_IMP(dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_hdns_ma_nn":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "NN" || !dtDataSave.Columns.Contains("MA")
                                    || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                                {
                                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
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
                                    string b_kiemtra = KiemTraImport_NN(dt_ktr);
                                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_NN_FILE_NH(dtDataSave);
                                    else form.P_LOI(this, b_kiemtra);
                                }
                            }
                            break;
                        case "ns_hdns_ma_cm":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "CM" || !dtDataSave.Columns.Contains("MA_NN") || !dtDataSave.Columns.Contains("MA")
                                   || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                                {
                                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
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
                                    string b_kiemtra = KiemTraImport_CM(dt_ktr);
                                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_CM_FILE_NH(dtDataSave);
                                    else form.P_LOI(this, b_kiemtra);
                                }
                                break;
                            }

                        case "ns_hdns_ma_nnn":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "NNN" || !dtDataSave.Columns.Contains("MA")
                                    || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                                {
                                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
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
                                    string b_kiemtra = KiemTraImport_NNN(dt_ktr);
                                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_NNN_FILE_NH(dtDataSave);
                                    else form.P_LOI(this, b_kiemtra);
                                }
                                break;
                            }

                        case "ns_hdns_ma_cbnn":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                                dtDataSave = b_ds.Tables[0].Clone();
                                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "CBNN" || !dtDataSave.Columns.Contains("MA_NNN") || !dtDataSave.Columns.Contains("MA")
                                   || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                                {
                                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
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
                                    string b_kiemtra = KiemTraImport_CBNN(dt_ktr);
                                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_CBNN_FILE_NH(dtDataSave);
                                    else form.P_LOI(this, b_kiemtra);
                                }
                                break;
                            }
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
                        case "ns_hdns_gan_cdanhdvi":
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

                                // KiemTraDuLieuVaoRa(dtDataSave);                                
                                ns_hdns.P_Fs_HD_CDANH_DVI_NH(dtDataSave);
                            }
                            break;
                        case "hdns_dinhbien_ns":
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
                                string b_kiemtra = KiemTraImport_DINHBIEN_NS(dt_ktr);
                                if (b_kiemtra == "") { }
                                //ns_td.P_Fs_HDNS_DINHBIEN_NS_NH("", dtDataSave);
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
                        case "cc_dky_lamthem":
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
                                string b_kiemtra = KiemTraImport_LamThem(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_THEM_COL(ref dtDataSave, "nghibu", "K");
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_dky");
                                    bang.P_CSO_SO(ref dtDataSave, "so_gio");
                                    tl_cc.PCC_DKY_LAMTHEM_FILE_NH(dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "cc_khaibao_lamthem":
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
                                string b_kiemtra = KiemTraImport_KhaiBao_LamThem(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_THEM_COL(ref dtDataSave, "nghibu", "K");
                                    bang.P_CNG_SO(ref dtDataSave, "ngay_dky");
                                    bang.P_CSO_SO(ref dtDataSave, new string[] { "so_gio", "so_gio_nb", "so_gio_tt" });
                                    tl_cc.PCC_KHAIBAO_LAMTHEM_FILE_NH(dtDataSave);
                                }
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "hd_ma_tuyendung":
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
                                //string b_kiemtra = KiemTraImport_BNNGHE(dtDataSave);
                                string b_kiemtra = string.Empty;
                                if (b_kiemtra == "") ns_hdns.P_HD_MA_TUYENDUNG_FILE_NH(dtDataSave);
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "tl_phanca":
                            {
                                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(5, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
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
                                bang.P_CNG_SO(ref dtDataSave, "ngayd");
                                //if (b_kiemtra == "") tl_cc.PCC_PHANCA_FILE_NH(dtDataSave);
                                // else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_ls_ct_tct":
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
                                string b_kiemtra = KiemTraImport_LSCT_TCT(dt_ktr);
                                bang.P_CNG_SO(ref dtDataSave, "ngay_qd");
                                bang.P_CNG_SO(ref dtDataSave, "ngayd");
                                bang.P_CNG_SO(ref dtDataSave, "ngayc");
                                //bang.P_CNG_SO(ref dtDataSave, new string[] {"ngay_qd","ngayd","ngayc" });

                                //bang.P_NG_CNG(ref dtDataSave, "ngay_qd,ngayd,ngayc");
                                bang.P_CSO_SO(ref dtDataSave, new string[] { "tien_lcb", "tien_tdgt", "tien_tns", "phantram_luong", "tongluong" });
                                if (b_kiemtra == "") ns_ls.PNS_LS_CT_TCT_FILE_NH(dtDataSave);
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_ma_cnganh_dt":
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
                                string b_kiemtra = KiemTraImport_CHNGANH_DTAO(dt_ktr);
                                if (b_kiemtra == "") ns_ma.P_NS_MA_CNGANH_DT_FILE_NH(dtDataSave);
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "dg_dm_tieuchi":
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
                                string b_kiemtra = KiemTraImport_TIEUCHI_DG(dt_ktr);
                                if (b_kiemtra == "") dg.P_DG_DM_TIEUCHI_FILE_NH(dtDataSave);
                                else form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch { throw new Exception("loi:Lỗi lưu File vào thư mục:loi"); }
                // insert vào database
                string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                if (string.IsNullOrEmpty(ten_file.Text.Trim()))
                {
                    ten_file.Text = ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                }
                string b_kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                if (b_kq != "")
                {
                    form.P_LOI(this, "loi:Import lỗi:loi");
                    return;
                }
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/file_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hdns_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hdns_P_LKE();", true);
                form.P_LOI(this, "loi:Import thành công:loi");
                return;
            }
        }
        catch (Exception ex) { form.P_LOI(this, Thongbao_dch.FileSaiDinhDang); }
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

    public string KiemTraImport_PH(DataTable table)
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
                sError = "Chưa nhập mã phòng";
                ImportKiemTra.EmptyValue("MA_TS", ref row, ref rowError, ref isError, sError);

                sError = "Tên phòng không được để trống";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Tên viết tắt không được để trống";
                ImportKiemTra.EmptyValue("TEN_VT", ref row, ref rowError, ref isError, sError);

                sError = "Ngày thành lập không được để trống";
                ImportKiemTra.EmptyValue("NGAY_TL", ref row, ref rowError, ref isError, sError);
                if (!row["NGAY_TL"].Equals(""))
                {
                    sError = "Ngày thành lập không đúng định dạng";
                    ImportKiemTra.IsValidDateDDMMYYYY("NGAY_TL", ref row, ref rowError, ref isError, sError);
                }

                if (!row["NGAY_GT"].Equals(""))
                {
                    sError = "Ngày giải thể không đúng định dạng";
                    ImportKiemTra.IsValidDateDDMMYYYY("NGAY_GT", ref row, ref rowError, ref isError, sError);
                }

                sError = "Mã cấp trên không được để trống";
                ImportKiemTra.EmptyValue("MA_CT", ref row, ref rowError, ref isError, sError);

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
                Excel_dungchung.ExportTemplate("Templates/importloi/ht_ma_ph_loi.xls", dtError, null, "Import_ma_ph_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string KiemTraImport_NN(DataTable table)
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
                sError = "Chưa nhập mã ngành nghề";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);
                if (rows["MA"].ToString() != "")
                {
                    sError = "Độ dài mã ngành nghề vượt quá 10 ký tự";
                    ImportKiemTra.IsValidLength("MA", ref row, ref rowError, ref isError, sError, 10);
                }

                sError = "Tên không được để trống";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Trạng thái không được để trống";
                ImportKiemTra.EmptyValue("TT", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_TT"].Equals(""))
                {
                    sError = "Trạng thái";
                    ImportKiemTra.IsValidListMa("TEN_TT", "TT", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_ma_nn_loi.xls", dtError, null, "Import_ma_nnghe_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_CM(DataTable table)
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

                sError = "Chưa nhập mã chuyên môn";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chuyên môn";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã ngành nghề";
                ImportKiemTra.EmptyValue("MA_NN", ref row, ref rowError, ref isError, sError);

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
                //dtError.TableName = "DATA";
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_ma_cm_loi.xls", dtError, null, "Import_chuyenmon_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string KiemTraImport_NNN(DataTable table)
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
                sError = "Chưa nhập mã ngạch nghề nghiệp";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);
                if (rows["MA"].ToString() != "")
                {
                    sError = "Độ dài mã ngạch nghề nghiệp vượt quá 10 ký tự";
                    ImportKiemTra.IsValidLength("MA", ref row, ref rowError, ref isError, sError, 10);
                }

                sError = "Tên không được để trống";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Trạng thái không được để trống";
                ImportKiemTra.EmptyValue("TT", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_TT"].Equals(""))
                {
                    sError = "Trạng thái";
                    ImportKiemTra.IsValidListMa("TEN_TT", "TT", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_ma_nnn_loi.xls", dtError, null, "Import_ma_nnghe_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string KiemTraImport_CBNN(DataTable table)
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
                sError = "Chưa nhập mã cấp bậc";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên cấp bậc";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã ngạch ngành nghề";
                ImportKiemTra.EmptyValue("MA_NNN", ref row, ref rowError, ref isError, sError);

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
                //dtError.TableName = "DATA";
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_ma_cbnn_loi.xls", dtError, null, "Import_bacnganhnghe_loi" + DateTime.Now.ToString("ddMMyyyy"));
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

                sError = "Chưa nhập mã chuyên môn";
                ImportKiemTra.EmptyValue("MA_CMON", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chuyên môn";
                ImportKiemTra.EmptyValue("TEN_CMON", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã ngạch ngành nghề";
                ImportKiemTra.EmptyValue("MA_NNNGHE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã cấp bậc";
                ImportKiemTra.EmptyValue("MA_CAPBAC", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã ngành nghề";
                ImportKiemTra.EmptyValue("MA_NNGHE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên ngành nghề";
                ImportKiemTra.EmptyValue("TEN_NNN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chuyên môn";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

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
    public string KiemTraImport_DINHBIEN_NS(DataTable table)
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
                sError = "Chưa nhập năm định biên";
                ImportKiemTra.EmptyValue("NAM", ref row, ref rowError, ref isError, sError);

                if (!row["NS_HIENTAI"].Equals(""))
                {
                    sError = "Nhân sự hiện tại nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("NS_HIENTAI", ref row, ref rowError, ref isError, sError);
                }

                if (!row["db_t1"].Equals(""))
                {
                    sError = "Định biên tháng 1 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t1", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t2"].Equals(""))
                {
                    sError = "Định biên tháng 2 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t2", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t3"].Equals(""))
                {
                    sError = "Định biên tháng 3 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t3", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t4"].Equals(""))
                {
                    sError = "Định biên tháng 4 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t4", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t5"].Equals(""))
                {
                    sError = "Định biên tháng 5 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t5", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t6"].Equals(""))
                {
                    sError = "Định biên tháng 6 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t6", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t7"].Equals(""))
                {
                    sError = "Định biên tháng 7 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t7", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t8"].Equals(""))
                {
                    sError = "Định biên tháng 8 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t8", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t9"].Equals(""))
                {
                    sError = "Định biên tháng 9 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t9", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t10"].Equals(""))
                {
                    sError = "Định biên tháng 10 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t10", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t11"].Equals(""))
                {
                    sError = "Định biên tháng 11 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t11", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_t12"].Equals(""))
                {
                    sError = "Định biên tháng 12 nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_t12", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_tb"].Equals(""))
                {
                    sError = "Định biên trung bình nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_tb", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_cn"].Equals(""))
                {
                    sError = "Định biên cuối năm nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_cn", ref row, ref rowError, ref isError, sError);
                }
                if (!row["db_caon"].Equals(""))
                {
                    sError = "Định biên cao nhất nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("db_caon", ref row, ref rowError, ref isError, sError);
                }
                sError = "Nhập năm định biên chưa đúng định dạng";
                ImportKiemTra.IsValid_Number("NAM", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên đơn vị";
                ImportKiemTra.EmptyValue("TEN_DONVI", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập phòng";
                ImportKiemTra.EmptyValue("PHONG", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chức danh";
                ImportKiemTra.EmptyValue("TEN_CDANH", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã chức danh";
                ImportKiemTra.EmptyValue("NCDANH", ref row, ref rowError, ref isError, sError);


                if (!row["TEN_DONVI"].Equals(""))
                {
                    sError = "Tên đơn vị không đúng";
                    ImportKiemTra.IsValidListMa("TEN_DONVI", "PHONG", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_CDANH"].Equals(""))
                {
                    sError = "Tên chức danh không đúng";
                    ImportKiemTra.IsValidListMa("TEN_CDANH", "NCDANH", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/hdns_dinhbien_ns_loi.xls", dtError, null, "Import_dinhbien_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
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
                    sError = "Tên không khớp với mã cán bộ nhập không đúng";
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
    public string KiemTraImport_LamThem(DataTable table)
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
                    sError = "Tên không khớp với mã cán bộ nhập không đúng";
                    ImportKiemTra.IsValidListMa("SO_THE", "HO_TEN", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_LOAI_DKY"].Equals(""))
                {
                    sError = "Loại đăng ký không đúng";
                    ImportKiemTra.IsValidListMa("TEN_LOAI_DKY", "HSO", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập hệ số của nhân viên";
                ImportKiemTra.EmptyValue("HSO", ref row, ref rowError, ref isError, sError);
                if (!row["GIO_BD"].Equals(""))
                {
                    sError = "Từ giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_BD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["GIO_KT"].Equals(""))
                {
                    sError = "Đến giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_KT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["HSO"].Equals(""))
                {
                    sError = "Hệ số nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("HSO", ref row, ref rowError, ref isError, sError);
                }
                if (!row["SO_GIO"].Equals(""))
                {
                    sError = "Số giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SO_GIO", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/cc_dky_lamthem_loi.xls", dtError, null, "Import_Lamthem_loi" + DateTime.Now.ToString("ddMMyyyy"));
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
                isError = false;
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
                    sError = "Tên không khớp với mã cán bộ nhập không đúng";
                    ImportKiemTra.IsValidListMa("SO_THE", "HO_TEN", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập hệ số của nhân viên";
                ImportKiemTra.EmptyValue("HSO", ref row, ref rowError, ref isError, sError);
                if (!row["TEN_LOAI_DKY"].Equals(""))
                {
                    sError = "Loại đăng ký không đúng";
                    ImportKiemTra.IsValidListMa("TEN_LOAI_DKY", "HSO", ref row, ref rowError, ref isError, sError);
                }
                if (!row["GIO_BD"].Equals(""))
                {
                    sError = "Từ giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_BD", ref row, ref rowError, ref isError, sError);
                }
                if (!row["GIO_KT"].Equals(""))
                {
                    sError = "Đến giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValidTime("GIO_KT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["SO_GIO"].Equals(""))
                {
                    sError = "Số giờ nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SO_GIO", ref row, ref rowError, ref isError, sError);
                }
                if (!row["SO_GIO_NB"].Equals(""))
                {
                    sError = "Số giờ nghỉ bù không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SO_GIO_NB", ref row, ref rowError, ref isError, sError);
                }
                if (!row["SO_GIO_TT"].Equals(""))
                {
                    sError = "Số giờ thanh toán nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("SO_GIO_TT", ref row, ref rowError, ref isError, sError);
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
            var iRow = 6;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            dtError.Columns.Add("STT");
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập ngày đầu";
                ImportKiemTra.EmptyValue("NGAYD", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã phòng";
                ImportKiemTra.EmptyValue("PHONG", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày làm";
                ImportKiemTra.EmptyValue("NGAYLAM", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên của nhân viên";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập kỳ lương";
                ImportKiemTra.EmptyValue("KYLUONG_ID", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập số ngày thứ 7 trong tháng";
                ImportKiemTra.EmptyValue("T7", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập số ngày chủ nhật trong tháng";
                ImportKiemTra.EmptyValue("CN", ref row, ref rowError, ref isError, sError);

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
                Excel_dungchung.ExportTemplate("Templates/importloi/tl_phanca_loi.xls", dtError, null, "Import_thietlapphanca_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
    public string KiemTraImport_LSCT_TCT(DataTable table)
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
                sError = "Chưa nhập ngày quyết định";
                ImportKiemTra.EmptyValue("NGAY_QD", ref row, ref rowError, ref isError, sError);

                if (!row["NGAY_QD"].Equals(""))
                {
                    sError = "Ngày vào nhập quyết định không đúng định dạng";
                    ImportKiemTra.IsValidDate("NGAY_QD", ref row, ref rowError, ref isError, sError);
                }
                sError = "Chưa nhập ngày hiệu lực";
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
                sError = "Chưa nhập quyết định";
                ImportKiemTra.EmptyValue("SO_QD", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã cán bộ";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                if (!row["TIEN_LCB"].Equals(""))
                {
                    sError = "Lương cơ bản nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TIEN_LCB", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TIEN_TDGT"].Equals(""))
                {
                    sError = "Thưởng đánh giá thắng nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TIEN_TDGT", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TIEN_TNS"].Equals(""))
                {
                    sError = "Tiền thưởng năng suất nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TIEN_TNS", ref row, ref rowError, ref isError, sError);
                }
                if (!row["PHANTRAM_LUONG"].Equals(""))
                {
                    sError = "% hưởng lương nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("PHANTRAM_LUONG", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TONGLUONG"].Equals(""))
                {
                    sError = "Tổng lương nhập không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TONGLUONG", ref row, ref rowError, ref isError, sError);
                }
                if (!row["HO_TEN"].Equals(""))
                {
                    sError = "Tên không đúng";
                    ImportKiemTra.IsValidListMa("HO_TEN", "SO_THE", ref row, ref rowError, ref isError, sError);
                }
                if (!row["CDANH"].Equals(""))
                {
                    sError = "Tên chức danh không đúng";
                    ImportKiemTra.IsValidListMa("CDANH", "SO_THE", ref row, ref rowError, ref isError, sError);
                }
                if (!row["PHONG"].Equals(""))
                {
                    sError = "Mã đơn vị không đúng";
                    ImportKiemTra.IsValidListMa("PHONG", "SO_THE", ref row, ref rowError, ref isError, sError);
                }
                if (!row["TEN_PHONG"].Equals(""))
                {
                    sError = "Tên đơn vị không đúng";
                    ImportKiemTra.IsValidListMa("TEN_PHONG", "SO_THE", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_ls_ct_tct_loi.xls", dtError, null, "Import_ls_quatrincongtactrongcongty_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }

    public string KiemTraImport_CHNGANH_DTAO(DataTable table)
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
                sError = "Chưa nhập mã chuyên ngành";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập tên chuyên ngành";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập trạng thái";
                ImportKiemTra.EmptyValue("TRANGTHAI", ref row, ref rowError, ref isError, sError);

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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_ma_cnganh_dt_loi.xls", dtError, null, "Import_ns_ma_cnganh_dt_loi" + DateTime.Now.ToString("ddMMyyyy"));
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
                Excel_dungchung.ExportTemplate("Templates/importloi/dg_dm_tieuchi_loi.xls", dtError, null, "Import_dg_dm_tieuchi_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
