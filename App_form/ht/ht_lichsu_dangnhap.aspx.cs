using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_lichsu_dangnhap : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_lichsu_dangnhap" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ht_lichsu_dangnhap_P_KD();", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_ma_tk = ama_tk.Value, b_tungay = atungay.Value, b_denngay = adenngay.Value;

            DataTable b_dt = ht_macb.Fdt_HT_LICHSU_DANGNHAP_LKE_ALL(b_ma_tk, b_tungay, b_denngay);

            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_dn,ngay_thoat");
            Excel_dungchung.ExportTemplate("Templates/ht_lichsu_dangnhap.xlsx", b_dt, null, "log_ht");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}