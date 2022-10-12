using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_phi_td : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_phi_td" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_phi_td_P_KD('" + XuatExcel.UniqueID + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            var b_phong = phong_tk.Attributes["traAn"].ToString();
            object[] a_object = ns_td.Faobj_NS_TD_PHI_TD_LKE(nam_tk.Text, ma_yc_tk.Text, cdanh_tk.Text,phongtk.Value, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_object[1];
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_phi_td.xlsx", b_dt, null, "Chi_phi_tuyen_dung");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        // PHÒNG BAN
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE(); se.P_TG_LUU(this.Title, "DT_PHONG", b_dt.Copy());
    }
}
