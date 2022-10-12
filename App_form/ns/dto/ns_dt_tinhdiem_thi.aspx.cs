using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_tinhdiem_thi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_tinhdiem_thi" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tinhdiem_thi_P_KD();", true);                
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = ns_dto.Fdt_NS_DT_TINHDIEM_THI_LKE(KYTHI.Text, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_object[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngaythi");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ketqua_kythi.xlsx", b_dt, null, "Ketquakythi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
