using System;
using System.Data;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_file_anh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_form/ns/tt/file_anh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "file_anh_KD('" + chon_file.ClientID + "','" + mo.UniqueID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (se.Fs_DUYET() != "FIREFOX") chon_file.Width = Unit.Pixel(400);
        }
    }
    protected void mo_ServerClick(object sender, EventArgs e)
    {
        try
        {

            int fileSize = chon_file.PostedFile.ContentLength;
            DataTable b_dt = bang.Fdt_TAO_BANG("iurl", "S");
            if (fileSize <= 1200000)
            {

                string b_ten = kytu.C_NVL(chon_file.PostedFile.FileName);
                if (b_ten == "") throw new Exception("loi:Chọn File:loi");
                string checkImg = b_ten.Substring(b_ten.Length - 4);
                if (checkImg.ToUpper().Equals(".JPG") || checkImg.ToUpper().Equals(".PNG") || checkImg.ToUpper().Equals(".GIF") || checkImg.ToUpper().Equals("JPEG"))
                {
                    se.se_nsd b_se = new se.se_nsd();
                    string b_ma = kytu.C_NVL(ten.Value); b_ma = b_ma.Replace("/", "-");

                    //string b_t1 = kytu.C_NVL(tmuc.Value), b_t = "/" + kytu.C_NVL(b_se.ma_dvi) + "/" + b_ma + "/", b_f = b_ma, b_loai = kytu.C_NVL(loai.Value);
                    string b_t1 = kytu.C_NVL(tmuc.Value), b_t = "/" + kytu.C_NVL(b_se.ma_dvi) + "/ANH/", b_f = b_ma, b_loai = kytu.C_NVL(loai.Value);
                    string b_goc = khac.Fs_tmFile();
                    // tao them ma donvi
                    //se.se_nsd b_se = new se.se_nsd();
                    //b_goc = b_goc + "\\\\" + b_se.ma_dvi;
                    if (b_goc == "") throw new Exception("loi:Chưa khai báo thư mục lưu File:loi");
                    int b_i, b_j;
                    b_i = b_ten.LastIndexOf('/');
                    b_j = b_ten.LastIndexOf('\\');
                    if (b_i < b_j) b_i = b_j;
                    string b_fg = b_ten.Substring(b_i + 1);
                    if (b_f == "") b_f = b_fg;
                    string b_tf = b_goc + b_t + "/" + b_f;
                    string b_mr = "";
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
                            ns_tt.P_FI_ANH_NH(b_ma_dvi, kytu.C_NVL(ten.Value), b_nd, b_tf.Substring(b_goc.Length));
                            bang.P_THEM_HANG(ref b_dt, new object[] { b_tf.Substring(b_goc.Length) });
                            se.P_KQ_LUU("file", "file", b_dt);
                        }else if (b_loai == "LOGO")
                        {
                            string b_ma_dvi = kytu.C_NVL(ma_dvi.Value), b_nd = "N'" + kytu.C_NVL(nd.Value);
                            if (b_nd == "") b_nd = b_ten;
                            ns_tt.P_FI_LOGO_NH(kytu.C_NVL(ten.Value), b_nd, b_tf.Substring(b_goc.Length));
                            bang.P_THEM_HANG(ref b_dt, new object[] { b_tf.Substring(b_goc.Length) });
                            se.P_KQ_LUU("file", "file", b_dt);
                        }
                        string b_ss = this.ResolveUrl("~/App_form/ns/tt/file_anh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_ss);
                        b_ss = "file_anh_KD('" + chon_file.ClientID + "','" + mo.UniqueID + "');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_ss, true);                        
                    }
                    catch { throw new Exception("loi:Lỗi lưu File:loi"); }
                }
                else
                { 
                    form.P_LOI(this, "loi:File import không phải là ảnh.:loi");
                    return;
                }
            }
            else
            {
                bang.P_THEM_HANG(ref b_dt, new object[] { "File nhập phải nhỏ hơn 1 MB!" });
                se.P_KQ_LUU("file", "file", b_dt);
            }
            //{
            //    string b_loi = "loi";
            //    form.P_DONG(this, new object[] { b_loi });
            //}
            // Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "<script language='javascript'>alert('File phải nhỏ hơn 1 MB!')</script>", true);     
            //else form.P_LOI(this, "File phải nhỏ hơn 1 MB!");
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
