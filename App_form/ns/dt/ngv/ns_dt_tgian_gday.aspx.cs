using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_tgian_gday : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_tgian_gday" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tgian_gday_P_KD();", true);
            NAM_TK.Text = DateTime.Now.Year.ToString();
        }
    }

    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_dt.Faobj_NS_DT_TGIAN_GDAY_LKE(NAM_TK.Text, 1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_TGIAN_GDAY, TEN_BANG.NS_DT_TGIAN_GDAY);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_tgian_gday.xlsx", b_dt, null, "Thoi_gian_giang_day_cua_giang_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

