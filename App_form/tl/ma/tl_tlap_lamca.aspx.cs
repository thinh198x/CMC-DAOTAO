using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tl_tlap_lamca : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/ma/tl_tlap_lamca" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_tlap_lamca_P_KD();", true);
            P_MA_CONG_DROP();
            MA.Focus();
        }
    }

    private void P_MA_CONG_DROP()
    {
        DataTable b_dt = tl_ma.Fdt_CC_MA_CC_DR("");
        se.P_TG_LUU(this.Title, "DT_MA_CONG", b_dt);
    }


    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_TL_TLAP_LAMCA_LKE_ALL();
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, new string[] { "NGHI_7_CN" });
            bang.P_THAY_GTRI(ref b_dt, "NGHI_7_CN", "1", "Nghỉ thứ 7 + chủ nhật");
            bang.P_THAY_GTRI(ref b_dt, "NGHI_7_CN", "2", "Nghỉ chủ nhật");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "A", "Áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "TRANGTHAI", "N", "Ngừng áp dụng");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_TLAP_LAMCA, TEN_BANG.TL_TLAP_LAMCA);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_tlap_lamca.xlsx", b_dt, null, "Danh_muc_tlap_lamca");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
