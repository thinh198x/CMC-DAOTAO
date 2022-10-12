using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ma_nhomluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/tl/ns_ma_nhomluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ma_nhomluong_P_KD();", true);
            P_NHAN_DROP();
            MA_TL.Focus();
        }
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_tl = day2.Text;                       
            DataTable b_dt = ns_ma.Fdt_NS_MA_NL_LKE_ALL_TL(b_tl);
            bang.P_THAY_GTRI(ref b_dt, "tt", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "tt", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_MA_NHOMLUONG, TEN_BANG.NS_MA_NHOMLUONG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ma_nhomluong.xlsx", b_dt, null, "Thiet_lap_ngach_luong");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_hdns.Fdt_HD_MA_HTTLUONG_LKE_ALL();
        bang.P_BO_COT(ref b_dt, new string[] { "MA_DVI", "IDVUNG", "NSD", "TT", "NG_HLUC", "NOTE", "SOTT" });
        se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);
        //bang.P_THEM_HANG(ref b_dt, new object[] { "", "Tất cả" }, 0);
        //form.P_LKE_DAT(MA_TL, b_dt); se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);

        //DataTable b_dt2 = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        //bang.P_THEM_HANG(ref b_dt2, new object[] { "A", "Áp dụng" });
        //bang.P_THEM_HANG(ref b_dt2, new object[] { "N", "Ngừng áp dụng" });
        //form.P_LIST_BANG(tt, b_dt2);

    }
}
