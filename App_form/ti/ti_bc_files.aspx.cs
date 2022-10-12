using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using Cthuvien;

public partial class f_ti_bc_files : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_bc_files_P_KD();", true);
                AsyncFileUpload1.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
    {
        try
        {
            //kiem tra tinh hop le
            string b_tenf = AsyncFileUpload1.FileName;
            if (b_tenf == "") throw new Exception("loi:Chọn files lỗi:loi");
            string b_exten = kytu.C_NVL(Path.GetExtension(AsyncFileUpload1.PostedFile.FileName));
            if (loai.Text.IndexOf(b_exten) < 0) throw new Exception("loi:Files đưa lên không hợp lệ:loi");
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_ServerClick(object sender, EventArgs e)
    {
        try
        {
            se.se_nsd b_se = new se.se_nsd(); string b_so_id =so_id.Value,b_ma = ma.Value, b_dir = "~/Templates/ns/", b_tenbc = tenbc.Text;
            if(!File.Exists(Server.MapPath(b_dir))) Directory.CreateDirectory(Server.MapPath(b_dir));
            string b_tenf="";
            if (rdo_files.SelectedValue == "T")
            {
                b_tenf = AsyncFileUpload1.FileName;
                if (b_tenf == "") throw new Exception("loi:Chọn files lỗi:loi");
                string b_exten = kytu.C_NVL(Path.GetExtension(AsyncFileUpload1.PostedFile.FileName));
                if (loai.Text.IndexOf(b_exten) >= 0)
                {
                    if (File.Exists(Server.MapPath(b_dir + "/" + b_tenf))) File.Delete(Server.MapPath(b_dir + "/" + b_tenf));
                  //  xem_file.Text = b_tenf; xem_file.f_tkhao = b_dir + b_tenf;
                    xem_file.Text = b_tenf; xem_file.NavigateUrl = ResolveUrl(b_dir + "/" + b_tenf);
                    AsyncFileUpload1.SaveAs(Server.MapPath(b_dir + "/" + b_tenf));
                }
                else throw new Exception("loi:Files đưa lên không hợp lệ:loi");
            }
            ti_ch.P_FILES_NH(b_so_id, b_ma, "N'" + b_tenbc, "N'" + b_tenf, ResolveUrl(b_dir));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ti_bc_files_P_LKE();", true);
            moi.Focus();
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
}