using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_hdns_pl_nhanvien : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ma/hdns_pl_nhanvien" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hdns_pl_nhanvien_P_KD();", true);
            //MA.Focus();
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    DataTable b_dt = ns_ma.Fdt_hdns_pl_nhanvien_LKE_ALL();
        //    b_dt.TableName = "DATA";
        //    Excel_dungchung.ExportTemplate("Templates/ExportMau/hdns_pl_nhanvien.xlsx", b_dt, null, "Dữ liệu thang lương");

        //}
        //catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
