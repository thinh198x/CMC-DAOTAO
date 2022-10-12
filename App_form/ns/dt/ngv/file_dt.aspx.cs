using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;
using System.Collections.Generic;

public partial class f_file_dt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/file_dt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_dt_P_KD();", true);
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
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/file_dt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_dt_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_dt_P_LKE();", true);
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
                DataTable dtDataSave,dt_ktr;

                try
                {
                    if (File.Exists(b_ten)) File.Delete(b_ten);
                    chon_file.PostedFile.SaveAs(b_ten);
                    workbook = new Workbook(b_ten);
                    worksheet = workbook.Worksheets[0];
                    string s_ten = ten_form.Value;
                    if (string.IsNullOrEmpty(s_ten)) { 
                        form.P_LOI(this, Thongbao_dch.ChuaChonFileImport);
                    }

                    switch (ten_form.Value)
                    {
                        case "ns_dt_ts":
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
                                string b_kiemtra = KiemTraImport_TuyenSinh(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    bang.P_CNG_SO(ref dtDataSave, "NGAYDK");
                                    double b_so_id_kh = chuyen.CSO_SO(this.thamso1_cc.Value);
                                    ns_dt.P_NS_DT_TS_THEM_NH(b_so_id_kh, dtDataSave);
                                }
                                else
                                    form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        case "ns_dt_tk_diem":
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
                                string b_kiemtra = KiemTraImport_Diem(dt_ktr);
                                if (b_kiemtra == "")
                                {
                                    double b_so_id_tk = chuyen.CSO_SO(this.thamso1_cc.Value);
                                    double b_so_id_kh = chuyen.CSO_SO(this.thamso2_cc.Value);
                                    ns_dt.Fn_NS_DT_TK_DIEM_IMPORT(b_so_id_kh, b_so_id_tk, dtDataSave);
                                }
                                else
                                    form.P_LOI(this, b_kiemtra);
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch { 
                    throw new Exception("loi:Lỗi lưu File vào thư mục:loi");
                }
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
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/file_dt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_dt_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_dt_P_LKE();", true);
                form.P_LOI(this, "loi:Import thành công:loi");               
            }
        }
        catch (Exception ex) { form.P_LOI(this, Thongbao_dch.FileSaiDinhDang); }
    }



    public string KiemTraImport_TuyenSinh(DataTable table)
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
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            
            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;
               
                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);
               
                sError = "Chưa nhập ngày đăng ký";
                ImportKiemTra.EmptyValue("NGAYDK", ref row, ref rowError, ref isError, sError);
                                     
                if (isError)
                {
                    dtError.Rows.Add(rowError);
                }
                
                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_dt_ts_ngoai_loi.xls", dtError, null, "Import_ns_dt_ts_ngoai_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }

    public string KiemTraImport_Diem(DataTable table)
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
            DataError.TableName = "DATA";
            dtError.TableName = "DATA";
            int b_so_mon = int.Parse(this.thamso3_cc.Value);
            string b_diem_col, b_ngay_thi_col;

            DataTable b_dt_kq = ns_ma.Fdt_PNS_MA_CHUNG_DR("KQDTNB");

            foreach (DataRow rows in table.Rows)
            {
                DataRow row = rows;
                rowError = dtError.NewRow();
                isError = false;

                sError = "Chưa nhập mã nhân viên";
                ImportKiemTra.EmptyValue("SO_THE", ref row, ref rowError, ref isError, sError);

                for (int i = 0; i < b_so_mon; i++)
                {
                    b_diem_col = "diem_" + i;
                    b_ngay_thi_col = "ngay_thi_" + i;
                    if (!row[b_diem_col].Equals(""))
                    {
                        sError = "Điểm nhập không đúng định dạng";
                        ImportKiemTra.IsValid_Number(b_diem_col, ref row, ref rowError, ref isError, sError);

                        if (!row[b_ngay_thi_col].Equals(""))
                        {
                            sError = "Ngày thi không đúng định dạng";
                            ImportKiemTra.IsValidDate(b_ngay_thi_col, ref row, ref rowError, ref isError, sError);
                        }
                    }
                }
                if (!row["kq"].Equals(""))
                {
                    if (bang.Fi_TIM_ROW(b_dt_kq, "ma", row["kq"]) < 0)
                    {
                        rowError["kq"] += "Mã kết quả không tồn tại";
                        isError = true;
                    }
                }
                if (!row["cp_htro"].Equals(""))
                {
                    sError = "Chi phí hỗ trợ không đúng định dạng";
                    ImportKiemTra.IsValid_Number("cp_htro", ref row, ref rowError, ref isError, sError);
                }
                
                if (isError)
                {
                    dtError.Rows.Add(rowError);
                }

                isError = false;
                DataError.ImportRow(row);
            }
            if (dtError.Rows.Count > 0)
            {
                Excel_dungchung.ExportTemplate("Templates/importloi/ns_dt_tk_diem_loi.xls", dtError, null, "Import_ns_dt_tk_diem_loi" + DateTime.Now.ToString("ddMMyyyy"));
                return "loi:Có lỗi xảy ra:loi";
            }
            else
            {
                for (int i = 0; i < b_so_mon; i++)
                {
                    bang.P_CNG_SO(ref table, "ngay_thi_" + i);
                }
            }
            return "";
        }
        catch (Exception ex) { throw ex; }
    }
}