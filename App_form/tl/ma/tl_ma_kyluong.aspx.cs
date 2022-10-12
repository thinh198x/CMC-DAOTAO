using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tl_ma_kyluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) 
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/ma/tl_ma_kyluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_ma_kyluong_P_KD();", true);
           
            P_THANG_DROP();
        }
    }

    private void P_THANG_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ma.Fdt_NS_TL_MA_KYLUONG_LKE_ALL();            
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, new string[] { "NGAY_BD", "NGAY_KT" });
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_MA_KYLUONG, TEN_BANG.TL_MA_KYLUONG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_ma_kyluong.xlsx", b_dt, null, "Danh_muc_ma_kyluong");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
