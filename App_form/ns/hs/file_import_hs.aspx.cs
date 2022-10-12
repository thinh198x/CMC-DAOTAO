using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_import_hs : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
                ngay.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void InitService()
    {
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
        string b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_LKE();", true);
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
                    b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_LKE();", true);
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
                b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_LKE();", true);
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
                    // else form.P_LOI(this, b_kiemtra);
                    //form.P_LOI(this, "Nhập file thành công!");
                }
            }
            else if (form_goc.ToLower().Equals("ns_ls_qt_dt"))
            {
                b_ds.Tables.Add(worksheet.Cells.ExportDataTableAsString(4, 0, worksheet.Cells.MaxRow + 1, worksheet.Cells.MaxColumn + 1, true));
                dtDataSave = b_ds.Tables[0].Clone();
                string[] a_col = new string[] { "so_the", "ten_kdt", "lop", "nd", "ngay_d", "ngay_c", "ldt", "tt", "dvi_tc", "dd_tc", "diem", "kq", "tien", "ghichu" };
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
            else if (form_goc.ToLower().Equals("hdns_mota_cv"))
            {
                if (workbook.Worksheets.Count < 2 || workbook.Worksheets[1].Name != "MTCV")
                {
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_LKE();", true);
                    form.P_LOI(this, "loi:File mẫu không đúng định dạng:loi");
                    b_kiemtra = "File mẫu không đúng định dạng!";
                    return;
                }
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
                dtDataNV.Columns.Add("NHIEMVU_CV");
                dtDataNV.Columns.Add("THAM_QUYEN");
                dtDataNV.Columns.Add("KET_QUA");
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
                    for (int i = 0; i < dtDataQHCV.Columns.Count; i++)
                    {
                        drQHCV[dtDataQHCV.Columns[i].ColumnName] = dtDataSave.Rows[0][dtDataQHCV.Columns[i].ColumnName];
                    }
                    dtDataQHCV.Rows.Add(drQHCV);
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
                        for (int j = 0; j < dtDataQHCV.Columns.Count; j++)
                        {
                            drQHCV[dtDataQHCV.Columns[j].ColumnName] = dtDataSave.Rows[i][dtDataQHCV.Columns[j].ColumnName];

                        }
                        dtDataQHCV.Rows.Add(drQHCV);
                    }
                }

                b_kiemtra = KiemTraImportMoTaCV(dtDataSave);
                if (b_kiemtra == "")
                {
                    bang.P_BO_HANG(ref dtDataSave, "MA_CD", "");
                    bang.P_BO_HANG(ref dtDataNV, "STT", "");
                    bang.P_BO_HANG(ref dtDataQHCV, new string[] { "NHOM_NL", "NANG_LUC", "MUC_NL", "MO_TA" }, new string[] { "", "", "", "" });
                    bang.P_CNG_SO(ref dtDataSave, "ngay_bh"); bang.P_CNG_SO(ref dtDataSave, "ngay_sd");
                    ns_mota_cv.Fdt_MOTA_CV_IMP_NH(dtDataSave, dtDataNV);
                }
                else
                {
                    form.P_LOI(this, b_kiemtra);
                }
            }
            if (b_kiemtra == "") { form.P_LOI(this, "Nhập file thành công!"); }
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            b_s = this.ResolveUrl("~/App_form/ns/hs/file_import_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_KD();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_hs_P_LKE();", true);
            return;
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }

    [Obsolete]
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

    [Obsolete]
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
                    if (!b_valid1 && !b_valid2 && chuyen.CNG_SO(rows["NGAY_C"].ToString()) > chuyen.CNG_SO(rows["NGAY_D"].ToString()))
                    {
                        sError = "Ngày kết thúc không được lớn hơn ngày bắt đầu";
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
                    ImportKiemTra.EmptyValue("MA_CD", ref row, ref rowError, ref isError, sError);
                }
                if (rows["STT"].ToString() != "" || rows["NHIEMVU_CV"].ToString() != "" || rows["THAM_QUYEN"].ToString() != "" || rows["KET_QUA"].ToString() != "")
                {
                    sError = "STT không được để trống";
                    ImportKiemTra.EmptyValue("STT", ref row, ref rowError, ref isError, sError);

                    sError = "Nhiệm vụ công việc không được để trống";
                    ImportKiemTra.EmptyValue("NHIEMVU_CV", ref row, ref rowError, ref isError, sError);

                    sError = "Thẩm quyền công việc không được để trống";
                    ImportKiemTra.EmptyValue("THAM_QUYEN", ref row, ref rowError, ref isError, sError);
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
}