using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tl_khenthuong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ns/sns_ns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/ns/nv/tl_khenthuong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_kthuong_P_KD();", true);
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            //string a_phong = phong_tk.SelectedValue;
            //string a_ten = ten_tk.Text.ToString();
            //string a_kyluong = kyluong_tk.SelectedValue;

            //DataTable b_dt = tl_ch.Fdt_GIULUONG_LKE_ALL(a_phong, a_ten, a_kyluong, 1, 10000);
            //bang.P_SO_CNG(ref b_dt, "NGAY_THANHTOAN");
            //b_dt.TableName = "DATA";
            //Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_khenthuong.xlsx", b_dt, null, "Danh sách giữ lương");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
