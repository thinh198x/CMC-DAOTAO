using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;
using System.Collections.Generic;

public partial class f_import_ns_cc_phep_dieuchinh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_phep.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/import_ns_cc_phep_dieuchinh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_ns_cc_phep_dieuchinh_P_KD();", true);
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
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_phep.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/tl/cc/import_ns_cc_phep_dieuchinh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_ns_cc_phep_dieuchinh_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_ns_cc_phep_dieuchinh_P_LKE();", true);
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
                        case "ns_cc_phep_dieuchinh":
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
                            
                            string b_kiemtra = KiemTraImportMoTaCV(dtDataSave);
                            if (b_kiemtra == "")
                            {
                                bang.P_BO_HANG(ref dtDataSave, "SO_THE", "");
                                string b_loi = "";
                                if (!tl_phep.Fdt_NS_CC_PHEP_DIEUCHINH_IMP_NH(dtDataSave, ref b_loi))
                                {
                                    form.P_LOI(this, b_loi);
                                }
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
                ns_mota_cv.P_HDNS_MOTA_CV_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, ten_file.Text, url.Value, ten.Text);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/import_ns_cc_phep_dieuchinh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_ns_cc_phep_dieuchinh_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "import_ns_cc_phep_dieuchinh_P_LKE();", true);
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
                return "Loi:Lỗi dữ liệu trong file import:Loi";
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
            var iRow = 4;
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
                if (iRow == 4)
                {
                    sError = "Mã nhân viên";
                    ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
                }
                if (rows["THANG_KTTN"].ToString() !="" || rows["NGAYD_KTTN"].ToString() != "" )
                {
                    if (rows["THANG_KTTN"].ToString() == "")
                    {
                        sError = "Số tháng không được tính thâm niên không được để trống";
                        ImportKiemTra.EmptyValue("THANG_KTTN", ref row, ref rowError, ref isError, sError);
                    }
                    else
                    {
                        sError = "Số tháng không được tính thâm niên không đúng định dạng";
                        ImportKiemTra.IsValid_Number("THANG_KTTN", ref row, ref rowError, ref isError, sError);
                    }


                    if (rows["NGAYD_KTTN"].ToString() == "")
                    {
                        sError = "Tháng không được tính thâm niên không được để trống";
                        ImportKiemTra.EmptyValue("NGAYD_KTTN", ref row, ref rowError, ref isError, sError);
                    }
                    else
                    {
                        sError = "Tháng không tính thâm niên không đúng định dạng";
                        ImportKiemTra.IsValidDateDDMMYYYY("NGAYD_KTTN", ref row, ref rowError, ref isError, sError);
                    }
                }


                if (rows["PHEP_DIEUCHINH"].ToString() != "" || rows["THANG_DIEUCHINH"].ToString() != "")
                {
                    if (rows["PHEP_DIEUCHINH"].ToString() == "")
                    {
                        sError = "Số tháng điều chỉnh không được để trống";
                        ImportKiemTra.EmptyValue("PHEP_DIEUCHINH", ref row, ref rowError, ref isError, sError);
                    }
                    else
                    {
                        sError = "Số phép điều chỉnh không đúng định dạng";
                        ImportKiemTra.IsValid_Number("PHEP_DIEUCHINH", ref row, ref rowError, ref isError, sError);
                    }


                    if (rows["THANG_DIEUCHINH"].ToString() == "")
                    {
                        sError = "Tháng điều chỉnh không được để trống";
                        ImportKiemTra.EmptyValue("THANG_DIEUCHINH", ref row, ref rowError, ref isError, sError);
                    }
                    else
                    {
                        sError = "Số phép điều chỉnh không đúng định dạng";
                        ImportKiemTra.IsValidDateDDMMYYYY("THANG_DIEUCHINH", ref row, ref rowError, ref isError, sError);
                    }
                }

                if (rows["THANG_GIAHAN"].ToString() != "")
                {
                    sError = "Tháng gia hạn không đúng định dạng";
                    ImportKiemTra.IsValidDateDDMMYYYY("THANG_GIAHAN", ref row, ref rowError, ref isError, sError);
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
