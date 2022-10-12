using System;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_khud_luuf : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string b_s = this.ResolveUrl("~/App_form/khud/khud_luuf" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            b_s = "khud_luuf_KD('" + chon_file.ClientID + "','" + mo.UniqueID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            if (se.Fs_DUYET() != "FIREFOX") chon_file.Width = Unit.Pixel(400);
        }
    }
    protected void mo_ServerClick(object sender, EventArgs e)
    {
        try
        {
            string b_ten = kytu.C_NVL(chon_file.PostedFile.FileName);
            if (b_ten == "") throw new Exception("loi:Chọn File:loi");
            string b_t = kytu.C_NVL(tmuc.Value), b_f = kytu.C_NVL(ten.Value), b_loai = kytu.C_NVL(loai.Value);
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
                    if (b_ma_dvi == "")
                    {
                        se.se_nsd b_se = new se.se_nsd();
                        b_ma_dvi = b_se.ma_dvi;
                    }
                    if (b_nd == "") b_nd = b_ten;
                    khud.P_FI_NH(b_ma_dvi, b_f, b_nd, b_tf.Substring(b_goc.Length));
                }
                else
                {
                    string b_ma_dvi = kytu.C_NVL(ma_dvi.Value), b_nd = "N'" + kytu.C_NVL(nd.Value);
                    if (b_nd == "") b_nd = b_ten;
                    khud.P_FI_NH(b_ma_dvi, b_f, b_nd, b_tf.Substring(Server.MapPath("~/Templates").Length));
                }
                
                string b_s1 = this.ResolveUrl("~/App_form/khud/khud_luuf" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                b_s1 = "khud_luuf_KD('" + chon_file.ClientID + "','" + mo.UniqueID + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s1, true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "form_dong();", true);
                form.P_LOI(this, "loi:Lưu File thành công:loi");
            }
            catch { throw new Exception("loi:Lỗi lưu File:loi"); }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    
}
