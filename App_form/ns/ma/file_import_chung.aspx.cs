using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_import_chung : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                ngay.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            var form_goc = ten_form.Value;
            se.se_nsd b_se2 = new se.se_nsd();
            string b_ma_dvi = b_se2.ma_dvi;
            string b_so_id2 = so_id.Value;
            string extension = Path.GetExtension(chon_file.PostedFile.FileName);
            if (extension == ".exe")
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_LKE();", true);
                form.P_LOI(this, "Nhập file không đúng định dạng!");
                return;
            }
            if (form_goc.ToLower().Equals("ns_ma_lhd"))
            {
                string b_ten = kytu.C_NVL(chon_file.PostedFile.FileName);

                if (b_ten == "")
                {
                    if (b_so_id2 == "") throw new Exception("loi:Chọn File:loi");
                    else
                    {
                        ns_ma.P_NS_FILE_LUU_CHUNG_NH(b_so_id2, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);
                        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                        string b_s = this.ResolveUrl("~/App_form/ns/ma/file_Import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_LKE();", true);
                        form.P_LOI(this, "Nhập file thành công!");
                    }
                    return;
                }
                else
                {
                    if (b_so_id2 == "0" || b_so_id2 == "") b_so_id2 = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
                    string b_t = kytu.C_NVL(tmuc.Value), b_f = kytu.C_NVL(tra_luu.Value) + "_" + chuyen.CNG_CSO(ngay.Text) + b_so_id2, b_loai = kytu.C_NVL(loai.Value);
                    string b_goc = khac.Fs_tmFile();
                    if (b_goc == "") throw new Exception("loi:Chưa khai báo thư mục lưu File:loi");
                    int b_i, b_j;
                    b_i = b_ten.LastIndexOf('/'); b_j = b_ten.LastIndexOf('\\');
                    if (b_i < b_j) b_i = b_j;
                    string b_fg = b_ten.Substring(b_i + 1);
                    if (b_f == "") b_f = b_fg;
                    string b_tf = "", b_mr = "";
                    string b_path = "";

                    if (b_loai == "MA")
                    {
                        b_tf = Server.MapPath("~/Templates/Bieu_mau_dong") + "/" + b_t;

                        if (!Directory.Exists(b_tf)) Directory.CreateDirectory(b_tf);
                        b_tf = b_tf + "/" + b_f;
                        b_path = b_t + b_f; ;
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
                            b_path += b_mr;
                        }
                        else
                        {
                            if (b_tf.IndexOf('.') < 0)
                            {
                                string[] a_f = Directory.GetFiles(b_goc + b_t, b_f + ".*");
                                foreach (string b_s in a_f) File.Delete(b_s);
                                b_i = b_ten.LastIndexOf('.');
                                if (b_i > 0)
                                {
                                    b_tf += b_ten.Substring(b_i);
                                    b_path += b_ten.Substring(b_i);
                                }
                            }
                            else if (File.Exists(b_tf)) File.Delete(b_tf);
                        }
                        chon_file.PostedFile.SaveAs(b_tf);
                        string kq = "";
                        string file_name = b_f + b_ten.Substring(b_i);
                        url.Value = b_path;
                        url.Value = ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text);
                        if (b_loai == "ID")
                        {
                            string b_nd = "N'" + kytu.C_NVL(nd.Value);
                            if (b_nd == "") b_nd = b_ten;

                            kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id2, ten_form.Value, tra_luu.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, file_name);
                        }
                        else
                        {
                            string b_nd = "N'" + kytu.C_NVL(nd.Value);
                            if (b_nd == "") b_nd = b_ten;
                            khud.P_FI_NH(b_ma_dvi, b_so_id2, b_nd, b_tf.Substring(Server.MapPath("~/Templates").Length));

                            kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id2, ten_form.Value, tra_luu.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, "/" + tra_luu.Value + "/" + file_name, file_name);
                        }
                        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                        string b_s2 = this.ResolveUrl("~/App_form/ns/ma/file_Import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s2);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_LKE();", true);
                        tenForm.Text = ten_mh.Value;
                        if (kq != "")
                        {
                            form.P_LOI(this, kq.ToString());
                        }
                        else
                        {
                            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.TAI_MAU_IN, TEN_FORM.NS_MA_LHD, TEN_BANG.NS_MA_LHD);
                            form.P_LOI(this, "loi:Nhập file thành công:loi");
                        }
                    }
                    catch (Exception ex) { throw new Exception("loi:Lỗi lưu File:loi"); }
                }
            }
            else if (form_goc.ToLower().Equals("ns_ma_qdinh"))
            {
                string b_ten = kytu.C_NVL(chon_file.PostedFile.FileName);

                if (b_ten == "")
                {
                    if (b_so_id2 == "") throw new Exception("loi:Chọn File:loi");
                    else
                    {
                        ns_ma.P_NS_FILE_LUU_NH(b_so_id2, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);
                        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                        string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_LKE();", true);
                        form.P_LOI(this, "Nhập file thành công!");
                    }
                    return;
                }
                else
                {
                    if (b_so_id2 == "0" || b_so_id2 == "") b_so_id2 = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
                    string b_t = kytu.C_NVL(tmuc.Value), b_f = kytu.C_NVL(tra_luu.Value) + "_" + chuyen.CNG_CSO(ngay.Text) + b_so_id2, b_loai = kytu.C_NVL(loai.Value);
                    string b_goc = khac.Fs_tmFile();
                    if (b_goc == "") throw new Exception("loi:Chưa khai báo thư mục lưu File:loi");
                    int b_i, b_j;
                    b_i = b_ten.LastIndexOf('/'); b_j = b_ten.LastIndexOf('\\');
                    if (b_i < b_j) b_i = b_j;
                    string b_fg = b_ten.Substring(b_i + 1);
                    if (b_f == "") b_f = b_fg;
                    string b_tf = "", b_mr = "";
                    string b_path = "";

                    if (b_loai == "MA")
                    {
                        b_tf = Server.MapPath("~/Templates/Bieu_mau_dong_quyet_dinh") + "/" + b_t;

                        if (!Directory.Exists(b_tf)) Directory.CreateDirectory(b_tf);
                        b_tf = b_tf + "/" + b_f;
                        b_path = b_t + b_f; ;
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
                            b_path += b_mr;
                        }
                        else
                        {
                            if (b_tf.IndexOf('.') < 0)
                            {
                                string[] a_f = Directory.GetFiles(b_goc + b_t, b_f + ".*");
                                foreach (string b_s in a_f) File.Delete(b_s);
                                b_i = b_ten.LastIndexOf('.');
                                if (b_i > 0)
                                {
                                    b_tf += b_ten.Substring(b_i);
                                    b_path += b_ten.Substring(b_i);
                                }
                            }
                            else if (File.Exists(b_tf)) File.Delete(b_tf);
                        }
                        chon_file.PostedFile.SaveAs(b_tf);
                        string kq = "";
                        url.Value = b_path;
                        string file_name = b_f + b_ten.Substring(b_i);
                        url.Value = ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text);
                        if (b_loai == "ID")
                        {
                            string b_nd = "N'" + kytu.C_NVL(nd.Value);
                            if (b_nd == "") b_nd = b_ten;
                            kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id2, ten_form.Value, tra_luu.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, file_name);
                        }
                        else
                        {
                            string b_nd = "N'" + kytu.C_NVL(nd.Value);
                            if (b_nd == "") b_nd = b_ten;
                            kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id2, ten_form.Value, tra_luu.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, "/" + tra_luu.Value + "/" + file_name, file_name);
                        }
                        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                        string b_ss = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_ss);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                        tenForm.Text = ten_mh.Value;
                        if (kq != "")
                        {
                            form.P_LOI(this, kq.ToString());
                        }
                        else
                        {
                            form.P_LOI(this, "loi:Nhập file thành công:loi");
                        }
                    }
                    catch (Exception) { throw new Exception("loi:Lỗi lưu File:loi"); }
                }
            }
            else
            {
                string b_file = kytu.C_NVL(chon_file.PostedFile.FileName), b_tm, b_ten;
                string b_so_id = so_id.Value;
                string b_ngay = DateTime.Now.ToString();
                url.Value = ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text);
                if (b_file == "")
                {
                    if (b_so_id == "0") throw new Exception("loi:Chọn File:loi");
                    else
                    {
                        ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten.Text);
                        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                        string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_LKE();", true);
                        form.P_LOI(this, "Nhập file thành công!");
                    }
                }
                else
                {
                    se.se_nsd b_se = new se.se_nsd();
                    b_tm = Server.MapPath("~/file_import/") + b_se.ma_dvi + "/" + ten_form.Value;
                    if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
                    se.se_nsd b_nsd = new se.se_nsd();
                    int b_i = chon_file.PostedFile.FileName.LastIndexOf(".");

                    if (b_so_id == "0" || b_so_id == "") b_so_id = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
                    b_ten = b_tm + "\\" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                    try
                    {
                        if (File.Exists(b_ten)) File.Delete(b_ten);
                        chon_file.PostedFile.SaveAs(b_ten);
                    }
                    catch (Exception) { throw new Exception("loi:Lỗi lưu File vào thư mục:loi"); }
                    string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                    url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
                    url.Value = b_ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i); ;
                    if (string.IsNullOrEmpty(TEN_FILE.Text))
                    {
                        TEN_FILE.Text = ten_kq.Value;
                    }
                    string kq = ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten.Text);

                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    string b_s = this.ResolveUrl("~/App_form/ns/ma/file_import_chung" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_chung_P_KD();", true);
                    tenForm.Text = ten_mh.Value;
                    if (kq != "")
                    {
                        form.P_LOI(this, kq.ToString());
                    }
                    else
                    {
                        form.P_LOI(this, "loi:Nhập file thành công:loi");
                    }
                }
                return;
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}