using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_import_ths : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/file_import_ths" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_import_ths_P_KD();", true);
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
            string b_file = kytu.C_NVL(chon_file.PostedFile.FileName);
           // form.P_DONG(this, new object[] { b_file});
            TEN_FILE.Text=b_file;
            ten_files.Value = b_file;
            se.P_DAY(this, this.ResolveUrl("~/App_form/ns/tt/ns_ths.aspx"), "file_luu", new object[] { b_file });
           // form.P
            //    var b_iurl = $get(b_iurlId).value;
            //form_P_DAY(window.name, "file_luu", "file_luu", b_iurl);
            //return false;
        }
        catch { throw new Exception("loi:Lỗi lưu File vào thư mục:loi"); }                    
        
    }
  
}
