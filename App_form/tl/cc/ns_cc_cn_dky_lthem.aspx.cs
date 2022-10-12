using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_cn_dky_lthem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_cn_dky_lthem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd(); string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_cn_dky_lthem_P_KD('" + b_so_the + "');", true);
            P_NHAN_DROP();
        }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    private void P_NHAN_DROP()
    {
        DataTable b_hso = ns_ma.Fdt_NS_CC_HSO_LTHEM_DR();
        se.P_TG_LUU(this.Title, "DT_HSO", b_hso.Copy());
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KY", null);

        b_nam.ToString();
    } 
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_dt;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        b_dt_nv.TableName = "DATA";
        b_dt = ns_ma.Fdt_NS_CC_HSO_LTHEM_DR();
        b_dt.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt);
        Excel_dungchung.ExportTemplate("Templates/importmau/cc_dky_lamthem_ktao.xls", b_ds, null, "cc_dky_lamthem_ktao");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = null;// tl_cc.Fdt_ns_cc__dky_lthem_EXPORT();
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_bd" });
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "HINHTHUC", "T", "Ngày thường");
            bang.P_THAY_GTRI(ref b_dt, "HINHTHUC", "H", "Ngày lễ");
            bang.P_THAY_GTRI(ref b_dt, "HINHTHUC", "C", "Cuối tuần");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_cn_dky_lthem.xlsx", b_dt, null, "khaibao_lamthem");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
