using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_phep_bu : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_phep.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cc/ns_cc_phep_bu" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_phep_bu_P_KD('');", true);
                P_NHAN_DROP(); 
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Phong
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KYLUONG", null);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = tl_phep.Fdt_NS_CC_NGHIPHEP_LKE(aphong.Value, chuyen.OBJ_N(akyluong.Value),so_the.Text.Trim(),0,int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_vao");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_phep_bu.xlsx", b_dt, null, "Tong_hop_phep_nam");
        }
        catch (Exception) { form.P_LOI(this, "loi:Không tồn tại biểu mẫu:loi"); }
    }
}