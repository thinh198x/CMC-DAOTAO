using System;
using System.IO;
using Cthuvien;

public partial class f_khud_layf : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            se.se_nsd b_se = new se.se_nsd();
            string b_tm = Server.MapPath("~/Outputs/file_nhap"), b_ten = "F_" + b_se.ma_dvi + "_" + b_se.nsd;
            string[] a_f = Directory.GetFiles(b_tm, b_ten + ".*");
            foreach (string b_s in a_f) File.Delete(b_s);

            string[] a_tso = chuyen.OBJ_S(Request.QueryString["tso"]).Split('}');
            string b_goc = a_tso[0];
            //b_cu = a_tso[1];
            b_goc = b_goc.Replace('|', '/'); b_goc = b_goc.Replace('!', '.');
            string b_cu = b_ten;
            //string b_goc = "/2018/04/21/20180421000001_1.xlsx";
            int b_i = b_goc.LastIndexOf(".");
            if (b_i > 0) b_cu += b_goc.Substring(b_i);
            b_goc = khac.Fs_tmFile() + "\\" + b_goc; b_ten = b_tm + "/" + b_ten;
            File.Copy(b_goc, b_ten, true);
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + b_cu);
            Response.TransmitFile(b_ten);
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}