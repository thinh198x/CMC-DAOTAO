using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_luu : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_luu" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);                
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = "khud_luuf_KD('" + chon_file.ClientID + "','" + mo.UniqueID + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
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
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten.Text);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/ma/file_luu" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_luu_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_luu_P_LKE();", true);
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
                                KiemTraExcel(dtDataSave);
                                stl_cc.Fs_CC_QUET_THE_NH(dtDataSave);
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
                if (string.IsNullOrEmpty(TEN_FILE.Text))
                {
                    TEN_FILE.Text = ten_kq.Value;
                }
                string kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten.Text);

                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_luu" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_luu_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_luu_P_LKE();", true);
                if (kq != "")
                {
                    form.P_LOI(this, kq.ToString());
                }
                else
                {
                    form.P_LOI(this, "loi:Import thành công:loi");
                }
                return;
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    protected void mo_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string b_ten = kytu.C_NVL(chon_file.PostedFile.FileName);
            if (b_ten == "") throw new Exception("loi:Chọn File:loi");
            string b_t = kytu.C_NVL(tmuc.Value), b_f = kytu.C_NVL(ten_form.Value), b_loai = kytu.C_NVL(loai.Value);
            string b_goc = khac.Fs_tmFile();
            if (b_goc == "") throw new Exception("loi:Chưa khai báo thư mục lưu File:loi");
            int b_i, b_j;
            b_i = b_ten.LastIndexOf('/'); b_j = b_ten.LastIndexOf('\\');
            if (b_i < b_j) b_i = b_j;
            string b_fg = b_ten.Substring(b_i + 1);
            if (b_f == "") b_f = b_fg;
            string b_tf = "", b_mr = "";
            if (b_loai == "MA")
            {
                b_tf = Server.MapPath("~/Templates") + "/" + b_t;
                if (!Directory.Exists(b_tf)) Directory.CreateDirectory(b_tf);
                b_tf = b_tf + "/" + b_f;
            }
            else { b_tf = b_goc + b_t + "/" + b_f; }
            if (b_t != "") khac.P_taoTmuc(b_t);
            try
            {
                if (b_loai == "ID")
                {
                    b_i = b_ten.LastIndexOf('.');
                    if (b_i > 0) b_mr = b_ten.Substring(b_i);
                    b_i = 0;
                    while (File.Exists(b_tf + b_mr))
                    {
                        b_i++; b_tf += "_" + kytu.C_NVL(b_i.ToString());
                    }
                    b_tf += b_mr;
                }
                else
                {
                    if (b_tf.IndexOf('.') < 0)
                    {
                        string[] a_f = Directory.GetFiles(b_goc + b_t, b_f + ".*");
                        foreach (string b_s in a_f) File.Delete(b_s);
                        b_i = b_ten.LastIndexOf('.');
                        if (b_i > 0) b_tf += b_ten.Substring(b_i);
                    }
                    else if (File.Exists(b_tf)) File.Delete(b_tf);
                }
                chon_file.PostedFile.SaveAs(b_tf);
                if (b_loai == "ID")
                {
                    string b_ma_dvi = kytu.C_NVL(ma_dvi.Value), b_nd = "N'" + kytu.C_NVL(nd.Value);
                    if (b_nd == "") b_nd = b_ten;
                    //khud.P_FI_NH(b_ma_dvi, b_f, b_nd, b_tf.Substring(b_goc.Length));
                }
                else
                {
                    string b_ma_dvi = kytu.C_NVL(ma_dvi.Value), b_nd = "N'" + kytu.C_NVL(nd.Value);
                    if (b_nd == "") b_nd = b_ten;
                    //khud.P_FI_NH(b_ma_dvi, b_f, b_nd, b_tf.Substring(Server.MapPath("~/Templates").Length));
                }
            }
            catch(Exception ex) { throw new Exception("loi:Lỗi lưu File:loi"); }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
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
}
