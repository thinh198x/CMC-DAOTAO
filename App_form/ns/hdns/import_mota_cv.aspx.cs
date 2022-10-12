using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;
using System.Collections.Generic;

public partial class f_import_mota_cv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_mota_cv.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/import_mota_cv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_mota_cv_P_KD();", true);
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
                if (b_so_id == "0") throw new Exception("loi:Chọn File:loi");
                else
                {
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_mota_cv.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/hdns/import_mota_cv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_mota_cv_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_mota_cv_P_LKE();", true);
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
                DataTable dtDataSave;
                try
                {
                    if (File.Exists(b_ten)) File.Delete(b_ten);
                    chon_file.PostedFile.SaveAs(b_ten);
                    //DataTable b_dt = khac.Fdt_Excel(b_ten);
                    workbook = new Workbook(b_ten);
                    worksheet = workbook.Worksheets[0];
                    switch (ten_form.Value)
                    {
                        case "hdns_mota_cv":
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

                            string b_kiemtra = KiemTraImportMoTaCV(dtDataSave);
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
                            break;
                        default:
                            break;
                    }
                }
                catch { throw new Exception("loi:Lỗi lưu File vào thư mục:loi"); }
                // insert vào database
                //string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                if (string.IsNullOrEmpty(ten_file.Text))
                {
                    ten_file.Text = ten_kq.Value;
                }
                //ns_mota_cv.P_HDNS_MOTA_CV_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/import_mota_cv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_mota_cv_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_mota_cv_P_LKE();", true);
                form.P_LOI(this, "loi:Import thành công:loi");
                return;
            }
        }
        catch (Exception ex) { form.P_LOI(this, Thongbao_dch.FileSaiDinhDang); }
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
