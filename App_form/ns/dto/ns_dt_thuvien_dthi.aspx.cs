using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_thuvien_dthi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_thuvien_dthi" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_thuvien_dthi_P_KD();", true);
                MA_NHUCAU.Focus(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    } 
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        { 
            // Lấy danh sách mã đào tạo
            object[] a_obj = ns_dto.Fdt_NS_DT_NHUCAU_DT_EXCEL(0, int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA1";
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_dt_thuvien_dthi.xls", b_dt, null, "Thuvien_dethi");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}