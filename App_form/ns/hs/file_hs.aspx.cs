using System;
using System.Data;
using System.Web.UI;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_file_hs : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hs/file_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_KD();", true);
                ngay.Text = chuyen.NG_CNG(DateTime.Now);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void InitService()
    {
        ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
        string b_s = this.ResolveUrl("~/App_form/ns/hs/file_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
        ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_KD();", true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_LKE();", true);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            var form_goc = ten_form.Value;
            se.se_nsd b_se2 = new se.se_nsd();
            string b_ma_dvi = b_se2.ma_dvi;
            string b_so_id = so_id.Value;
            string b_kiemtra = "";
            DataSet b_ds = new DataSet();
            //DataTable dtDataSave, dt_ktr;
            //Workbook workbook;
            //Worksheet worksheet;
            string b_file = kytu.C_NVL(CHON_FILE.PostedFile.FileName), b_s = "", b_ten = b_file, b_tm;
            //string b_so_id = so_id.Value;
            string b_ngay = DateTime.Now.ToString();
            se.se_nsd b_se = new se.se_nsd();
            b_tm = Server.MapPath("~/file_import/") + b_se.ma_dvi + "/" + ten_form.Value;
            if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
            se.se_nsd b_nsd = new se.se_nsd();
            int b_i = CHON_FILE.PostedFile.FileName.LastIndexOf(".");

            b_so_id = chuyen.OBJ_S(dbora.Fobj_LKE('N', "PHT_HOI_ID_MOI"));
            b_ten = b_tm + "\\" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            if (File.Exists(b_ten)) File.Delete(b_ten);
            CHON_FILE.PostedFile.SaveAs(b_ten);
            //b_ten = kytu.C_NVL(CHON_FILE.PostedFile.FileName);

            if (b_ten == "")
            {
                if (b_so_id == "") throw new Exception("loi:Chọn File:loi");
                else
                {
                    ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                    b_s = this.ResolveUrl("~/App_form/ns/hs/file_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_KD();", true);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_LKE();", true);
                    form.P_LOI(this, "loi:Có lỗi xảy ra!:loi");
                }
                b_kiemtra = "Có lỗi xảy ra!";
                return;
            }
            string b_duongdan = b_se.ma_dvi + "/" + ten_form.Value + "/" + nv.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            url.Value = b_duongdan; ten.Text = nv.Value + ten_kq.Value + "_" + chuyen.CNG_CSO(ngay.Text) + "_" + b_so_id + b_file.Substring(b_i, b_file.Length - b_i);
            ten_files.Value = ten.Text;
            ns_ma.P_NS_FILE_LUU_NH(b_so_id, ten_form.Value, nv.Value, ten_kq.Value, ngay.Text, TEN_FILE.Text, url.Value, ten_files.Value);

            if (b_kiemtra == "") { form.P_LOI(this, "Nhập file thành công!"); }
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            b_s = this.ResolveUrl("~/App_form/ns/hs/file_hs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_KD();", true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "file_hs_P_LKE();", true);
            return;
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}