using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_import_hdns : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
                ngay.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void InitService()
    {
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
        string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_LKE();", true);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            var form_goc = ten_form.Value;
            se.se_nsd b_se2 = new se.se_nsd();
            string b_ma_dvi = b_se2.ma_dvi;
            string b_so_id = so_id.Value;
            string b_kiemtra = "";
            DataSet b_ds = new DataSet();
            DataTable dtDataSave, dt_ktr;
            Workbook workbook;
            Worksheet worksheet;
            string b_file = kytu.C_NVL(CHON_FILE.PostedFile.FileName), b_s = "", b_ten = b_file, b_tm;
            //string b_so_id = so_id.Value;
            string b_ngay = DateTime.Now.ToString();
            se.se_nsd b_se = new se.se_nsd();
            b_tm = Server.MapPath("~/file_import/") + b_se.ma_dvi + "/" + ten_form.Value;
            if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
            se.se_nsd b_nsd = new se.se_nsd();
            int b_i = CHON_FILE.PostedFile.FileName.LastIndexOf(".");

            b_so_id = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
            b_ten = b_tm + "\\" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            if (File.Exists(b_ten)) File.Delete(b_ten);
            CHON_FILE.PostedFile.SaveAs(b_ten);
            //b_ten = kytu.C_NVL(CHON_FILE.PostedFile.FileName);

            if (b_ten == "")
            {
                if (b_so_id == "") throw new Exception("loi:Chọn File:loi");
                else
                {
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_LKE();", true);
                    form.P_LOI(this, "loi:Có lỗi xảy ra!:loi");
                }
                b_kiemtra = "Có lỗi xảy ra!";
                return;
            }
            string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            ten_files.Value = ten.Text;
            ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);
            string b_ext = CHON_FILE.PostedFile.FileName.Substring(CHON_FILE.PostedFile.FileName.LastIndexOf('.') + 1).ToLower();
            if (b_ext != "xls" && b_ext != "xlsx")
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_LKE();", true);
                form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                b_kiemtra = "File mẫu không đúng định dạng!";
                return;
            }
            workbook = new Workbook(b_ten);
            worksheet = workbook.Worksheets[0];
            string s_ten = ten_form.Value;
            if (string.IsNullOrEmpty(s_ten)) { form.P_LOI(this, Thongbao_dch.ChuaChonFileImport); }

            if (form_goc.ToLower().Equals("ht_maph"))
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
                b_kiemtra = KiemTraImport_PH(dt_ktr);
                if (b_kiemtra == "")
                {
                    bang.P_CNG_SO(ref dtDataSave, "NGAY_TL,NGAY_GT");
                    ht_maph.P_MA_PH_IMP(dtDataSave);
                }
                else form.P_LOI(this, b_kiemtra);
                //form.P_LOI(this, "Nhập file thành công!");
            }
            else if (form_goc.ToLower().Equals("ns_hdns_ma_nn"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "NN" || !dtDataSave.Columns.Contains("MA")
                    || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                {
                    b_kiemtra = "File mẫu không đúng định dạng!";
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
                    b_kiemtra = KiemTraImport_NN(dt_ktr);
                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_NN_FILE_NH(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            else if (form_goc.ToLower().Equals("ns_hdns_ma_cm"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                if (workbook.Worksheets.Count != 4 || workbook.Worksheets[2].Name != "CM" || !dtDataSave.Columns.Contains("MA_NN") || !dtDataSave.Columns.Contains("MA")
                   || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                {
                    b_kiemtra = "File mẫu không đúng định dạng!";
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
                    b_kiemtra = KiemTraImport_CM(dt_ktr);
                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_CM_FILE_NH(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            else if (form_goc.ToLower().Equals("ns_hdns_ma_nnn"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "NNN" || !dtDataSave.Columns.Contains("MA")
                    || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                {
                    b_kiemtra = "File mẫu không đúng định dạng!";
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
                    b_kiemtra = KiemTraImport_NNN(dt_ktr);
                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_NNN_FILE_NH(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            else if (form_goc.ToLower().Equals("ns_hdns_ma_cbnn"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                if (workbook.Worksheets.Count != 4 || workbook.Worksheets[2].Name != "CBNN" || !dtDataSave.Columns.Contains("MA_NNN") || !dtDataSave.Columns.Contains("MA")
                   || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                {
                    b_kiemtra = "File mẫu không đúng định dạng!";
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
                    b_kiemtra = KiemTraImport_CBNN(dt_ktr);
                    if (b_kiemtra == "") ns_hdns.Fs_NS_HDNS_MA_CBNN_FILE_NH(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            
            else if (form_goc.ToLower().Equals("ns_ma_cnganh_dt"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "MA", "TEN", "TRANGTHAI", "GHICHU" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }

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
                b_kiemtra = KiemTraImport_CHNGANH_DTAO(dt_ktr);
                if (b_kiemtra == "") ns_ma.P_NS_MA_CNGANH_DT_FILE_NH(dtDataSave);
                else form.P_LOI(this, b_kiemtra);
                //form.P_LOI(this, "Nhập file thành công!");
            }
            else if (form_goc.ToLower().Equals("dg_dm_tieuchi"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "MA_NHOM", "MA", "TEN", "TT", "GCHU" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }

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
                b_kiemtra = KiemTraImport_TIEUCHI_DG(dt_ktr);
                if (b_kiemtra == "") dg.P_DG_DM_TIEUCHI_FILE_NH(dtDataSave);
                else form.P_LOI(this, b_kiemtra);
            }
            else if (form_goc.ToLower().Equals("dg_kq_dgia_thang"))
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
                b_kiemtra = "";
                if (dt_ktr.Rows.Count == 0)
                {
                    b_kiemtra = "loi:Không tồn tại bản ghi:loi";
                }
                else
                {
                    b_kiemtra = KiemTraImport_dg_cv_thang(dt_ktr);
                }
                if (b_kiemtra == "") //ns_hdns.P_NS_HDNS_MA_VTCD_FILE_NH(dtDataSave);
                {
                    DataTable b_nam_kydg = new DataTable();
                    bang.P_THEM_COL(ref b_nam_kydg, new string[] { "nam", "ky_dg" });
                    bang.P_THEM_HANG(ref b_nam_kydg, dt_ktr, new string[] { "nam", "ky_dg" });
                    dg.P_Fs_DG_KQ_DGIA_THANG_NH_EXCEL(b_nam_kydg, dtDataSave);
                }
                else form.P_LOI(this, b_kiemtra);
            }
            else if (form_goc.ToLower().Equals("ns_hdns_khns_qlg"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "NAM", "PHONG", "TEN_PHONG", "THANG_D", "THANG_C", "CDANH", "TEN_CDANH", "LOAI_NV", "TEN_LOAI_NV", "THU_NHAP", "LUONG_CB", "THUONG", "THU_NHAP_KH", "LUONG_CB_KH", "THUONG_KH", "NGAY_D_NAM", "NGAY_TD", "NGAY_C_NAM", "THANG_LV_DK", "THANG_TN", "THANG_TN_TD", "TYLE_LC", "TYLE_TNX", "TYLE_DL", "TYLE_PT", "PHUCAP1", "PHUCAP2", "PHUCAP3", "TYLE_BH", "KH_BH", "TYLE_CDP", "PHI_CD", "TONGQUY_TNT", "TONG_PC", "TONG_THUONG_NX", "TONG_CHI_PL", "TONG_TN_DK" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }

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
                b_kiemtra = KiemTraImport_KeHoachQuyLuong(dt_ktr);
                if (b_kiemtra == "")
                {
                    bang.P_CTH_SO(ref dtDataSave, "thang_d,thang_c");
                    bang.P_CNG_SO(ref dtDataSave, "ngay_d_nam,ngay_td,ngay_c_nam");
                    bang.P_CSO_SO(ref dtDataSave, new string[] { "NAM", "THU_NHAP", "LUONG_CB", "THUONG", "THU_NHAP_KH", "LUONG_CB_KH", "THUONG_KH", "THANG_LV_DK", "THANG_TN", "THANG_TN_TD", "TYLE_LC", "TYLE_TNX", "TYLE_DL", "TYLE_PT", "PHUCAP1", "PHUCAP2", "PHUCAP3", "TYLE_BH", "KH_BH", "TYLE_CDP", "PHI_CD", "TONGQUY_TNT", "TONG_PC", "TONG_THUONG_NX", "TONG_CHI_PL", "TONG_TN_DK" });
                    bang.P_XEP(ref dtDataSave, "nam,phong");//new string[] { "nam", "phong" });
                    ns_hdns.P_NS_HDNS_KHNS_QLG_FILE_NH(dtDataSave);
                }
                else form.P_LOI(this, b_kiemtra);
            }

            else if (form_goc.ToLower().Equals("ns_hdns_ma_nl"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                //if (workbook.Worksheets.Count != 3 || workbook.Worksheets[2].Name != "NN" || !dtDataSave.Columns.Contains("MA")
                //    || !dtDataSave.Columns.Contains("TEN") || !dtDataSave.Columns.Contains("TT") || !dtDataSave.Columns.Contains("GHICHU"))
                //{
                //    b_kiemtra = "File mẫu không đúng định dạng!";
                //    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                //}
                //else
                //{
                string[] a_col = new string[] { "TEN_NHOM", "MA_NHOM", "MA", "TEN", "TEN_TT", "TT", "GHICHU", "MUC_NL", "MOTA", "BIEUHIEN" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }
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
                    dt_ktr = dtDataSave.Copy();
                    DataTable b_dt_nl;
                    dtDataSave.Columns.Add("KEY");
                    b_dt_nl = new DataTable();
                    b_dt_nl.Columns.Add("KEY");
                    b_dt_nl.Columns.Add("muc_nl");
                    b_dt_nl.Columns.Add("mota");
                    b_dt_nl.Columns.Add("bieuhien");
                    int b_pkey = 1;
                    if (dtDataSave.Rows.Count > 0)
                    {
                        dtDataSave.Rows[0]["KEY"] = b_pkey;
                        DataRow dr = b_dt_nl.NewRow();
                        for (int i = 0; i < b_dt_nl.Columns.Count; i++)
                        {
                            dr[b_dt_nl.Columns[i].ColumnName] = dtDataSave.Rows[0][b_dt_nl.Columns[i].ColumnName];
                        }
                        b_dt_nl.Rows.Add(dr);

                        for (int i = 1; i < dtDataSave.Rows.Count; i++)
                        {
                            dr = b_dt_nl.NewRow();
                            if (dtDataSave.Rows[i]["MA_NHOM"].ToString() == "")
                            {
                                dtDataSave.Rows[i]["KEY"] = dtDataSave.Rows[i - 1]["KEY"];
                            }
                            else
                            {
                                b_pkey++;
                                dtDataSave.Rows[i]["KEY"] = b_pkey;
                            }

                            for (int j = 0; j < b_dt_nl.Columns.Count; j++)
                            {
                                dr[b_dt_nl.Columns[j].ColumnName] = dtDataSave.Rows[i][b_dt_nl.Columns[j].ColumnName];
                            }
                            b_dt_nl.Rows.Add(dr);
                        }
                    }
                    bang.P_BO_COT(ref dtDataSave, "muc_nl,mota,bieuhien"); bang.P_DON_DK(ref dtDataSave, "MA_NHOM");
                    string b_kytudau = "NL";
                    string s_ma = ht_dungchung.Fdt_AutoGenCode(b_kytudau, "NS_HDNS_MA_NL", "MA");
                    //string str = b_dt.Rows[0]["MA"].ToString();
                    string number_str = s_ma.Substring(s_ma.IndexOf(b_kytudau) + b_kytudau.Length);
                    int number = int.Parse(number_str);
                    string ma = string.Format("{0:000}", number);
                    foreach (DataRow b_dr in dtDataSave.Rows)
                    {
                        b_dr["MA"] = b_kytudau + ma;
                        number = number + 1;
                        ma = string.Format("{0:000}", number);
                    }
                    dtDataSave.AcceptChanges();
                    if (dtDataSave.Rows.Count == 0 && b_dt_nl.Rows.Count == 0)
                    {
                        InitService();
                        form.P_LOI(this, "loi:File import chưa có dữ liệu:loi");
                        return;
                    }
                    ns_hdns.Fdt_NS_HDNS_MA_NL_IMP_NH(dtDataSave, b_dt_nl);
                }
            }
            else if (form_goc.ToLower().Equals("ns_hdns_ma_bacluong"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "MA_TL", "MA_NL", "MA_NNNGHIEP", "BACLUONG", "TONGLUONG", "LUONG_CB", "TRANGTHAI" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }
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
                    dt_ktr = dtDataSave.Copy();
                    DataTable b_dt_nl;
                    dtDataSave.Columns.Add("KEY");
                    b_dt_nl = new DataTable();
                    b_dt_nl.Columns.Add("KEY");
                    b_dt_nl.Columns.Add("bacluong");
                    b_dt_nl.Columns.Add("tongluong");
                    b_dt_nl.Columns.Add("luong_cb");
                    b_dt_nl.Columns.Add("trangthai");
                    int b_pkey = 1;
                    if (dtDataSave.Rows.Count > 0)
                    {
                        dtDataSave.Rows[0]["KEY"] = b_pkey;
                        DataRow dr = b_dt_nl.NewRow();
                        for (int i = 0; i < b_dt_nl.Columns.Count; i++)
                        {
                            dr[b_dt_nl.Columns[i].ColumnName] = dtDataSave.Rows[0][b_dt_nl.Columns[i].ColumnName];
                        }
                        b_dt_nl.Rows.Add(dr);

                        for (int i = 1; i < dtDataSave.Rows.Count; i++)
                        {
                            dr = b_dt_nl.NewRow();
                            if (dtDataSave.Rows[i]["MA_TL"].ToString() == "")
                            {
                                dtDataSave.Rows[i]["KEY"] = dtDataSave.Rows[i - 1]["KEY"];
                            }
                            else
                            {
                                b_pkey++;
                                dtDataSave.Rows[i]["KEY"] = b_pkey;
                            }

                            for (int j = 0; j < b_dt_nl.Columns.Count; j++)
                            {
                                dr[b_dt_nl.Columns[j].ColumnName] = dtDataSave.Rows[i][b_dt_nl.Columns[j].ColumnName];
                            }
                            b_dt_nl.Rows.Add(dr);
                        }
                    }
                    bang.P_BO_COT(ref dtDataSave, "bacluong,tongluong,luong_cb,trangthai"); bang.P_DON_DK(ref dtDataSave, "MA_TL");
                    if (dtDataSave.Rows.Count == 0 && b_dt_nl.Rows.Count == 0)
                    {
                        InitService();
                        form.P_LOI(this, "loi:File import chưa có dữ liệu:loi");
                        return;
                    }
                    ns_ma.P_NS_HDNS_MA_BACLUONG_IMP_NH(dtDataSave, b_dt_nl);
                }
            }
            else if (form_goc.ToLower().Equals("ns_ls_qt_dt"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "so_the", "ten_kdt", "lop", "nd", "ngay_d", "ngay_c", "tt", "dvi_tc", "dd_tc", "diem", "kq", "tien", "ghichu" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }
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
                b_kiemtra = KiemTraImport_QTDT(dt_ktr);
                if (b_kiemtra == "")
                {
                    bang.P_CSO_SO(ref dtDataSave, "diem,tien");
                    bang.P_CNG_SO(ref dtDataSave, new string[] { "ngay_d", "ngay_c" });
                    bang.P_THEM_COL(ref dtDataSave, "ldt");
                    for (int i = 0; i < dtDataSave.Rows.Count; i++)
                    {     
                        
                        string Ngaydl = "Ngày hiệu lực";
                      var b_check =  skhac.CheckDateInGrid(chuyen.CSO_CNG(dtDataSave.Rows[i]["ngay_d"].ToString()), ref Ngaydl);

                        if (b_check == false){
                             form.P_LOI(this, "loi:Sai ngày hiệu lực:loi");
                             return;
                        }
                        
                        //if (chuyen.CSO_SO(dtDataSave.Rows[i]["khoach_ngay"].ToString()) > chuyen.CSO_SO(dtDataSave.Rows[i]["ngay_dl"].ToString()))
                        //{
                        //    return Thongbao_dch.ktNgaylap_khoach;
                        //}
                    }
                    ns_ls.PNS_LS_QT_DT_NG_NH_FILE(dtDataSave);
                }
                else form.P_LOI(this, b_kiemtra);
                //form.P_LOI(this, "Nhập file thành công!");
            }
            else if (form_goc.ToLower().Equals("ns_ma_truonghoc"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "MA", "TEN", "TRANGTHAI", "GHICHU" };
                for (int i = 0; i < a_col.Length; i++)
                {
                    if (!dtDataSave.Columns.Contains(a_col[i]))
                    {
                        form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                        return;
                    }
                }
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

                    dt_ktr = dtDataSave.Copy();
                    b_kiemtra = KiemTraImport_TRUONGHOC(dt_ktr);
                    if (b_kiemtra == "") ns_ma.P_NS_MA_TRUONGHOC_FILE_NH(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                }
            }
            
            else if (form_goc.ToLower().Equals("hd_ma_tuyendung"))
            {
                if (workbook.Worksheets.Count < 2 || workbook.Worksheets[1].Name != "VTD")
                {
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_LKE();", true);
                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                    b_kiemtra = "File mẫu không đúng định dạng!";
                    return;
                }
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
                b_kiemtra = KiemTraImport_VONGTD(dtDataSave);
                if (b_kiemtra == "") ns_hdns.P_HD_MA_TUYENDUNG_FILE_NH(dtDataSave);
                else form.P_LOI(this, b_kiemtra);
            }
            else if (form_goc.ToLower().Equals("ns_hdns_gan_mtcv"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                if (workbook.Worksheets.Count != 6 || workbook.Worksheets[1].Name != "GAN_MTCV")
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
                    b_kiemtra = KiemTraImport_GAN_MTCV(dt_ktr);
                    if (b_kiemtra == "") ns_hdns.P_NS_HDNS_GAN_MTCVDVI_IMPORT(dtDataSave);
                    else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
        finally
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_hdns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_KD();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hdns_P_LKE();", true);
        }
    }
    public string KiemTraExcel(DataTable table)
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
            DataTable b_dt_macc = stl_cc.PNS_MA_CC_DR();

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
    public string KiemTraExcel_NS_HDCT(DataTable table)
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
            DataTable b_dtCDanh = ns_mota_cv.Fdt_MOTA_CV_EXPORT_CD();
            DataTable b_dtPhongBan = ns_tt.Fdt_MA_PHONG_LKE();



            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã loại quyết định";
                ImportKiemTra.EmptyValue("HINHTHUC", ref row, ref rowError, ref isError, sError);

                object[] b_kt = ns_ma.Fdt_NS_MA_HTCTAC_MA(rows["HINHTHUC"].ToString(), 1);
                if (b_kt.Length == 0)
                {
                    sError = "Mã loại quyết định không tồn tại";
                    rowError["HINHTHUC"] = sError;
                    isError = true;
                }

                sError = "Chưa nhập trạng thái nhân viên";
                ImportKiemTra.EmptyValue("TRANGTHAI_NV", ref row, ref rowError, ref isError, sError);
                b_kt = ns_ma.Fdt_NS_MA_HTCTAC_MA(rows["TRANGTHAI_NV"].ToString(), 1);
                if (b_kt.Length == 0)
                {
                    sError = "Mã trạng thái nhân viên không tồn tại";
                    rowError["TRANGTHAI_NV"] = sError;
                    isError = true;
                }

                sError = "Chưa nhập bộ phận";
                ImportKiemTra.EmptyValue("PHONGM", ref row, ref rowError, ref isError, sError);

                if (b_dtPhongBan.Select("MA='" + rows["PHONGM"].ToString() + "'").Length == 0)
                {
                    sError = "Mã bộ phận không tồn tại";
                    rowError["PHONGM"] = sError;
                    isError = true;
                }


                sError = "Chưa nhập chức danh";
                ImportKiemTra.EmptyValue("CDANH", ref row, ref rowError, ref isError, sError);

                if (b_dtCDanh.Select("MA='" + rows["CDANH"].ToString() + "'").Length == 0)
                {
                    sError = "Mã chức danh không tồn tại";
                    rowError["CDANH"] = sError;
                    isError = true;
                }

                if (rows["LYDO_NKL"].ToString() != "")
                {

                }

                if (rows["CDANH_MIENNHIEM"].ToString() != "" && b_dtCDanh.Select("MA='" + rows["CDANH_MIENNHIEM"].ToString() + "'").Length == 0)
                {
                    sError = "Mã chức danh miễn nhiệm không tồn tại";
                    rowError["CDANH_MIENNHIEM"] = sError;
                    isError = true;
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
                return "loi:Không có dữ liệu Import:loi";
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_ma_cnganh_dt_loi.xls", dtError, null, "Import_ns_ma_cndt_loi" + DateTime.Now.ToString("ddMMyyyy"));
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

    public string KiemTraImport_QTDT(DataTable table)
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
                sError = "Chưa nhập Mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                if (rows["SO_THE"].ToString().Trim() != "")
                {
                    try
                    {
                        khac.Fs_MA_LOI("Mã nhân viên", rows["SO_THE"].ToString().Trim(), "ns_cb,so_the,ten");
                    }
                    catch
                    {
                        sError = "Mã nhân viên không tồn tại";
                        rowError["SO_THE"] += sError;
                        isError = true;
                    }
                }
                sError = "Chưa nhập Tên khóa đào tạo";
                ImportKiemTra.EmptyValue("TEN_KDT", ref row, ref rowError, ref isError, sError);
                if (rows["TEN_KDT"].ToString() != "")
                {
                    sError = "Độ dài Tên khóa đào tạo vượt quá 100 ký tự";
                    ImportKiemTra.IsValidLength("TEN_KDT", ref row, ref rowError, ref isError, sError, 100);
                }
                if (rows["LOP"].ToString() != "")
                {
                    sError = "Độ dài Lớp vượt quá 255 ký tự";
                    ImportKiemTra.IsValidLength("LOP", ref row, ref rowError, ref isError, sError, 255);
                }
                if (rows["ND"].ToString() != "")
                {
                    sError = "Độ dài Nội dung đào tạo vượt quá 1000 ký tự";
                    ImportKiemTra.IsValidLength("ND", ref row, ref rowError, ref isError, sError, 1000);
                }
                if (rows["DVI_TC"].ToString() != "")
                {
                    sError = "Độ dài Đơn vị tổ chức vượt quá 100 ký tự";
                    ImportKiemTra.IsValidLength("DVI_TC", ref row, ref rowError, ref isError, sError, 100);
                }
                if (rows["DD_TC"].ToString() != "")
                {
                    sError = "Độ dài Địa điểm tổ chức vượt quá 255 ký tự";
                    ImportKiemTra.IsValidLength("DD_TC", ref row, ref rowError, ref isError, sError, 255);
                }
                if (rows["GHICHU"].ToString() != "")
                {
                    sError = "Độ dài Mô tả vượt quá 1000 ký tự";
                    ImportKiemTra.IsValidLength("GHICHU", ref row, ref rowError, ref isError, sError, 1000);
                }
                sError = "Chưa nhập Ngày bắt đầu";
                ImportKiemTra.EmptyValue("NGAY_D", ref row, ref rowError, ref isError, sError);
                if (rows["NGAY_D"].ToString() != "" && rows["NGAY_C"].ToString() != "")
                {
                    sError = "Ngày bắt đầu không đúng định dạng";
                    bool b_valid1 = ImportKiemTra.IsValidDateDDMMYYYY("NGAY_D", ref row, ref rowError, ref isError, sError);
                    sError = "Ngày kết thúc không đúng định dạng";
                    bool b_valid2 = ImportKiemTra.IsValidDateDDMMYYYY("NGAY_C", ref row, ref rowError, ref isError, sError);
                    if (b_valid1 && b_valid2 && chuyen.CNG_SO(rows["NGAY_C"].ToString()) < chuyen.CNG_SO(rows["NGAY_D"].ToString()))
                    {
                        sError = "Ngày kết thúc không được nhỏ hơn ngày bắt đầu";
                        rowError["NGAY_C"] += sError;
                        isError = true;
                    }
                }
                if (rows["TT"].ToString() != "")
                {
                    string b_tt = rows["TT"].ToString().Trim();
                    if (b_tt != "H" && b_tt != "D" && b_tt != "T" && b_tt != "C")
                    {
                        sError = "Trạng thái không nằm trong giá trị quy định (H,D,T,C)";
                        rowError["TT"] += sError;
                        isError = true;
                    }
                }
                if (rows["KQ"].ToString() != "")
                {
                    string b_kq = rows["KQ"].ToString().Trim();
                    if (b_kq != "D" && b_kq != "K")
                    {
                        sError = "Kết quả thi không nằm trong giá trị quy định (D,K)";
                        rowError["KQ"] += sError;
                        isError = true;
                    }
                }
                if (rows["DIEM"].ToString() != "")
                {
                    sError = "Điểm không đúng định dạng";
                    ImportKiemTra.IsValid_Number("DIEM", ref row, ref rowError, ref isError, sError, false);
                }
                if (rows["TIEN"].ToString() != "")
                {
                    sError = "Chi phí không đúng định dạng";
                    ImportKiemTra.IsValid_Number("TIEN", ref row, ref rowError, ref isError, sError, false);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/NS_LS_QT_DT_loi.xls", dtError, null, "Import_NS_LS_QT_DT_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
    public string KiemTraImport_TRUONGHOC(DataTable table)
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
                sError = "Chưa nhập mã trường";
                ImportKiemTra.EmptyValue("MA", ref row, ref rowError, ref isError, sError);
                if (rows["MA"].ToString() != "")
                {
                    sError = "Độ dài mã trường vượt quá 20 ký tự";
                    ImportKiemTra.IsValidLength("MA", ref row, ref rowError, ref isError, sError, 20);
                }

                sError = "Tên không được để trống";
                ImportKiemTra.EmptyValue("TEN", ref row, ref rowError, ref isError, sError);
                if (rows["TEN"].ToString() != "")
                {
                    sError = "Độ dài tên trường vượt quá 100 ký tự";
                    ImportKiemTra.IsValidLength("TEN", ref row, ref rowError, ref isError, sError, 100);
                }
                sError = "Trạng thái không được để trống";
                ImportKiemTra.EmptyValue("TRANGTHAI", ref row, ref rowError, ref isError, sError);

                if (!row["TEN_TT"].Equals(""))
                {
                    sError = "Trạng thái";
                    ImportKiemTra.IsValidListMa("TEN_TT", "TRANGTHAI", ref row, ref rowError, ref isError, sError);
                }
                if (rows["GHICHU"].ToString() != "")
                {
                    sError = "Độ dài ghi chú vượt quá 1000 ký tự";
                    ImportKiemTra.IsValidLength("GHICHU", ref row, ref rowError, ref isError, sError, 1000);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_ma_truonghoc_loi.xls", dtError, null, "Import_ma_truong_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
     
    public string KiemTraImport_VONGTD(DataTable table)
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
                ImportKiemTra.EmptyValue("MA_CDANH", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập vòng 1";
                ImportKiemTra.EmptyValue("MON_I", ref row, ref rowError, ref isError, sError);

                if (chuyen.OBJ_N(rows["MON_I_DMAX"]) < chuyen.OBJ_N(rows["MON_I_DIEM"]))
                {
                    isError = true;
                    sError = "Điểm đạt vòng 1 không được phép > thang điểm vòng 1";
                    ImportKiemTra.AddError("MON_I_DIEM", ref row, ref rowError, ref isError, sError);
                }

                if (chuyen.OBJ_N(rows["MON_II_DMAX"]) < chuyen.OBJ_N(rows["MON_II_DIEM"]))
                {
                    isError = true;
                    sError = "Điểm đạt vòng 2 không được phép > thang điểm vòng 2";
                    ImportKiemTra.AddError("MON_II_DIEM", ref row, ref rowError, ref isError, sError);
                }

                if (chuyen.OBJ_N(rows["MON_III_DMAX"]) < chuyen.OBJ_N(rows["MON_III_DIEM"]))
                {
                    isError = true;
                    sError = "Điểm đạt vòng 3 không được phép > thang điểm vòng 3";
                    ImportKiemTra.AddError("MON_III_DIEM", ref row, ref rowError, ref isError, sError);
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
                Excel_dungchung.ExportTemplate("Templates/importloi/hd_ma_tuyendung_ktao_loi.xls", dtError, null, "hd_ma_tuyendung_ktao_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public string KiemTraImport_GAN_MTCV(DataTable table)
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
                ImportKiemTra.EmptyValue("PHONG", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập ngày áp dụng";
                ImportKiemTra.EmptyValue("NGAY_HL", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã ngạch ngành nghề";
                ImportKiemTra.EmptyValue("MA_NNN", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã chức danh";
                ImportKiemTra.EmptyValue("MA_CD", ref row, ref rowError, ref isError, sError);

                sError = "Chưa nhập mã mô tả công việc";
                ImportKiemTra.EmptyValue("SO_ID_MTCV", ref row, ref rowError, ref isError, sError);

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
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_gan_mtcv_loi.xls", dtError, null, "Import_gan_mtcv_loi" + DateTime.Now.ToString("ddMMyyyy"));
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
    
    
    public string KiemTraImport_KeHoachQuyLuong(DataTable table)
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
                sError = "Chưa nhập Năm";
                ImportKiemTra.EmptyValue("NAM", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Mã đơn vị";
                ImportKiemTra.EmptyValue("PHONG", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Từ tháng";
                ImportKiemTra.EmptyValue("THANG_D", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Đến tháng";
                ImportKiemTra.EmptyValue("THANG_C", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Mã chức danh";
                ImportKiemTra.EmptyValue("CDANH", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Mã loại nhân viên";
                ImportKiemTra.EmptyValue("LOAI_NV", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Thu nhập tháng (Thu nhập theo tháng hiện tại)";
                ImportKiemTra.EmptyValue("THU_NHAP", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Lương cơ bản (Thu nhập theo tháng hiện tại)";
                ImportKiemTra.EmptyValue("LUONG_CB", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Thu nhập tháng (Thu nhập tháng kế hoạch)";
                ImportKiemTra.EmptyValue("THU_NHAP_KH", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Lương cơ bản (Thu nhập tháng kế hoạch)";
                ImportKiemTra.EmptyValue("LUONG_CB_KH", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Thời gian bắt đầu làm việc trong năm";
                ImportKiemTra.EmptyValue("NGAY_D_NAM", ref row, ref rowError, ref isError, sError);
                sError = "Chưa nhập Thời giam kết thúc làm việc trong năm";
                ImportKiemTra.EmptyValue("NGAY_C_NAM", ref row, ref rowError, ref isError, sError);

                if (rows["PHONG"].ToString().Trim() != "")
                {
                    try
                    {
                        khac.Fs_MA_LOI("Mã đơn vị", rows["PHONG"].ToString().Trim(), "ht_ma_phong,ma,ten");
                    }
                    catch
                    {
                        sError = "Mã đơn vị không tồn tại";
                        rowError["PHONG"] += sError;
                        isError = true;
                    }
                }
                if (rows["CDANH"].ToString().Trim() != "")
                {
                    try
                    {
                        khac.Fs_MA_LOI("Mã chức danh", rows["CDANH"].ToString().Trim(), "ns_ma_cdanh,ma,ten");
                    }
                    catch
                    {
                        sError = "Mã chức danh không tồn tại";
                        rowError["CDANH"] += sError;
                        isError = true;
                    }
                }
                if (rows["NGAY_D_NAM"].ToString() != "" && rows["NGAY_C_NAM"].ToString() != "")
                {
                    sError = "Thời gian bắt đầu làm việc trong năm không đúng định dạng";
                    bool b_valid1 = ImportKiemTra.IsValidDateDDMMYYYY("NGAY_D_NAM", ref row, ref rowError, ref isError, sError);
                    sError = "Thời giam kết thúc làm việc trong năm không đúng định dạng";
                    bool b_valid2 = ImportKiemTra.IsValidDateDDMMYYYY("NGAY_C_NAM", ref row, ref rowError, ref isError, sError);
                    bool b_valid3 = b_valid1 && b_valid2;
                    if (b_valid1 && b_valid2 && chuyen.CNG_SO(rows["NGAY_C_NAM"].ToString()) < chuyen.CNG_SO(rows["NGAY_D_NAM"].ToString()))
                    {
                        sError = "Ngày kết thúc không được nhỏ hơn ngày bắt đầu";
                        rowError["NGAY_C_NAM"] += sError;
                        b_valid3 = false;
                        isError = true;
                    }

                    if (b_valid3 && rows["NGAY_TD"].ToString() != "")
                    {
                        sError = "Thời gian thay đổi thu nhập tháng không đúng định dạng";
                        ImportKiemTra.IsValidDateDDMMYYYY("NGAY_TD", ref row, ref rowError, ref isError, sError);
                    }
                }
                bool b_valid_THU_NHAP = false;
                if (rows["THU_NHAP"].ToString() != "")
                {
                    sError = "Thu nhập tháng không đúng định dạng";
                    b_valid_THU_NHAP = ImportKiemTra.IsValid_Number("THU_NHAP", ref row, ref rowError, ref isError, sError, false, 20);
                }

                if (rows["LUONG_CB"].ToString() != "")
                {
                    sError = "Lương cơ bản không đúng định dạng";
                    bool b_valid_LUONG_CB = ImportKiemTra.IsValid_Number("LUONG_CB", ref row, ref rowError, ref isError, sError, false, 20);
                    if (b_valid_LUONG_CB && b_valid_THU_NHAP)
                    {
                        if (chuyen.CSO_SO(rows["LUONG_CB"].ToString()) > chuyen.CSO_SO(rows["THU_NHAP"].ToString()))
                        {
                            sError = "Lương cơ bản không được lớn hơn Thu nhập tháng";
                            rowError["LUONG_CB"] += sError;
                            isError = true;
                        }
                    }
                }

                b_valid_THU_NHAP = false;
                if (rows["THU_NHAP_KH"].ToString() != "")
                {
                    sError = "Thu nhập tháng không đúng định dạng";
                    b_valid_THU_NHAP = ImportKiemTra.IsValid_Number("THU_NHAP_KH", ref row, ref rowError, ref isError, sError, false, 20);
                }

                if (rows["LUONG_CB_KH"].ToString() != "")
                {
                    sError = "Lương cơ bản không đúng định dạng";
                    bool b_valid_LUONG_CB = ImportKiemTra.IsValid_Number("LUONG_CB_KH", ref row, ref rowError, ref isError, sError, false, 20);
                    if (b_valid_LUONG_CB && b_valid_THU_NHAP)
                    {
                        if (chuyen.CSO_SO(rows["LUONG_CB_KH"].ToString()) > chuyen.CSO_SO(rows["THU_NHAP_KH"].ToString()))
                        {
                            sError = "Lương cơ bản không được lớn hơn Thu nhập tháng";
                            rowError["LUONG_CB_KH"] += sError;
                            isError = true;
                        }
                    }
                }

                sError = "Tỷ lệ lương cứng không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_LC", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tỷ lệ thưởng năng suất không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_TNX", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tỷ lệ độc lập không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_DL", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tỷ lệ phụ thuộc không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_PT", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Kế hoạch phụ cấp 1 không đúng định dạng";
                ImportKiemTra.IsValid_Number("PHUCAP1", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Phụ cấp 2 không đúng định dạng";
                ImportKiemTra.IsValid_Number("PHUCAP2", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Phụ cấp 3 không đúng định dạng";
                ImportKiemTra.IsValid_Number("PHUCAP3", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tỷ lệ % BHXH, BHYT, BHTN không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_BH", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tỷ lệ % CĐ phí không đúng định dạng";
                ImportKiemTra.IsValid_Number("TYLE_CDP", ref row, ref rowError, ref isError, sError, false, 20);

                sError = "Tổng chi phúc lợi không đúng định dạng";
                ImportKiemTra.IsValid_Number("TONG_CHI_PL", ref row, ref rowError, ref isError, sError, false, 20);

                if (isError)
                {
                    rowError["STT"] = iRow;
                    dtError.Rows.Add(rowError);
                }
                else
                {
                    // tính thưởng đánh giá tháng hiện tại
                    row["THUONG"] = chuyen.OBJ_N(row["THU_NHAP"]) - chuyen.OBJ_N(row["LUONG_CB"]);
                    // tính thưởng đánh giá tháng kế hoạch
                    if (row["THU_NHAP_KH"].ToString() != "" && row["LUONG_CB_KH"].ToString() != "")
                        row["THUONG_KH"] = chuyen.OBJ_N(row["THU_NHAP_KH"]) - chuyen.OBJ_N(row["LUONG_CB_KH"]);
                    // tính số tháng làm việc dự kiến
                    row["THANG_LV_DK"] = this.Days360(row["NGAY_D_NAM"].ToString(), row["NGAY_C_NAM"].ToString()) / 30;
                    // Số tháng thu nhập hiện tại
                    if (row["NGAY_TD"].ToString() != "")
                        row["THANG_TN"] = this.Days360(row["NGAY_D_NAM"].ToString(), row["NGAY_TD"].ToString()) / 30;
                    // Số tháng thu nhập thay đổi
                    if (row["THANG_LV_DK"].ToString() != "" && row["THANG_TN"].ToString() != "")
                        row["THANG_TN_TD"] = chuyen.OBJ_N(row["THANG_LV_DK"]) - chuyen.OBJ_N(row["THANG_TN"]);
                    // Kế hoạch BHXH\BHYT\BHTN
                    if (row["TYLE_BH"].ToString() != "" && row["THANG_TN"].ToString() != "" && row["LUONG_CB_KH"].ToString() != "" && row["THANG_TN_TD"].ToString() != "")
                        row["KH_BH"] = (chuyen.OBJ_N(row["LUONG_CB"]) * chuyen.OBJ_N(row["THANG_TN"]) + chuyen.OBJ_N(row["LUONG_CB_KH"]) * chuyen.OBJ_N(row["THANG_TN_TD"])) * chuyen.OBJ_N(row["TYLE_BH"]) / 100;
                    // Kinh phí công đoàn
                    if (row["TYLE_CDP"].ToString() != "" && row["THANG_TN"].ToString() != "" && row["LUONG_CB_KH"].ToString() != "" && row["THANG_TN_TD"].ToString() != "")
                        row["PHI_CD"] = (chuyen.OBJ_N(row["LUONG_CB"]) * chuyen.OBJ_N(row["THANG_TN"]) + chuyen.OBJ_N(row["LUONG_CB_KH"]) * chuyen.OBJ_N(row["THANG_TN_TD"])) * chuyen.OBJ_N(row["TYLE_CDP"]) / 100;
                    // Tổng quỹ thu nhập tháng
                    row["TONGQUY_TNT"] = (chuyen.OBJ_N(row["THU_NHAP"]) * chuyen.OBJ_N(row["THANG_TN"]) + chuyen.OBJ_N(row["THU_NHAP_KH"]) * chuyen.OBJ_N(row["THANG_TN_TD"])) * chuyen.OBJ_N(row["TYLE_CDP"]);
                    // Tổng phụ cấp
                    row["TONG_PC"] = chuyen.OBJ_N(row["THANG_LV_DK"]) * (chuyen.OBJ_N(row["PHUCAP1"]) + chuyen.OBJ_N(row["PHUCAP2"]) + chuyen.OBJ_N(row["PHUCAP3"]));
                    // Tổng quỹ thưởng năng suất
                    row["TONG_THUONG_NX"] = chuyen.OBJ_N(row["TONGQUY_TNT"]) * (chuyen.OBJ_N(row["TYLE_TNX"]) / chuyen.OBJ_N(row["TYLE_LC"]));
                    // Tổng thu nhập dự kiến
                    row["TONG_TN_DK"] = chuyen.OBJ_N(row["KH_BH"]) + +chuyen.OBJ_N(row["PHI_CD"]) + chuyen.OBJ_N(row["TONGQUY_TNT"]) + chuyen.OBJ_N(row["TONG_PC"]) + +chuyen.OBJ_N(row["TONG_THUONG_NX"]) + chuyen.OBJ_N(row["TONG_CHI_PL"]);
                }
                iRow = iRow + 1;
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                //dtError.TableName = "DATA";
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_hdns_khns_qlg_loi.xls", dtError, null, "Import_ns_hdns_khns_qlg_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    private double Days360(string sd, string fd)
    {
        DateTime d1 = chuyen.CNG_NG(sd);
        DateTime d2 = chuyen.CNG_NG(fd);
        var d1_1 = d1;
        var d2_1 = d2;
        var d1_y = d1.Year;
        var d2_y = d2.Year;
        var dy = 0;
        var d1_m = d1.Month;
        var d2_m = d2.Month;
        var dm = 0;
        var d1_d = d1.Day;
        var d2_d = d2.Day;
        var dd = 0;

        if (d1_d == 31) d1_d = 30;
        if (d2_d == 31)
        {
            if (d1_d < 30)
            {
                if (d2_m == 11)
                {
                    d2_y = d2_y + 1;
                    d2_m = 0;
                    d2_d = 1;
                }
                else
                {
                    d2_m = d2_m + 1;
                    d2_d = 1;
                }
            }
            else
            {
                d2_d = 30;
            }
        }

        dy = d2_y - d1_y;
        dm = d2_m - d1_m;
        dd = d2_d - d1_d;
        return (dy * 360 + dm * 30 + dd);
    }
}