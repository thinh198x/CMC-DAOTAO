using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_qtthue : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            { 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ns_tl_qtthue" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_qtthue_P_KD('');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TL_QTTHUE, TEN_BANG.NS_TL_QTTHUE);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_tl_qtthue.xls", new DataTable(), null, "uy_quyen_quyet_toan_thue");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void nhap_Click_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ch.Fdt_NS_TL_QTTHUE_EXPORT(NAM.Text);
            b_dt.TableName = "DATA";
            var unused = Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_qtthue.xlsx", b_dt, null, "Xuat_Excel_uy_quyen_quyet_toan_thue");

        }
        catch (Exception)
        {
            form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }
}