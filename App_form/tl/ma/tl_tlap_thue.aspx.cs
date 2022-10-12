using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_tlap_thue : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/tl_tlap_thue" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_tlap_thue_P_KD();", true);
                NGAY.Focus(); 
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = tl_ma.Fdt_TL_TLAP_THUE_EXCEL(1, 1000);
            DataTable b_dt = (DataTable)a_object[1]; 
            bang.P_SO_CNG(ref b_dt, "ngay");
            bang.P_COPY_COL(ref b_dt, "TEN_DT_CUTRU", "DT_CUTRU");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "CT", "Đối tượng cư trú");
            bang.P_THAY_GTRI(ref b_dt, "TEN_DT_CUTRU", "KCT", "Đối tượng không cư trú");
            bang.P_SO_CSO(ref b_dt, "THUNHAPTU,THUNHAPDEN");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_TLAP_THUE, TEN_BANG.TL_TLAP_THUE);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_tlap_thue.xlsx", b_dt, null, "DM_Thue_TNCN");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}