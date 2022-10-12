using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_tc_cnv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/dg/ns_dg_tc_cnv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_tc_cnv_P_KD();", true);
            P_NAM_DROP();
            P_KY_DG_DROP();
            P_PLNV_DROP();
            //P_NHOM_TIEUCHI_DROP();
           // TEN.Focus();
        }
    }

    private void P_NAM_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "TC_DG_CNV_KY_NAM", b_dt);
    }

    private void P_KY_DG_DROP()
    {
        DataTable b_dt = dg.Fdt_NS_DG_MA_KDG_LKE_ALL();
        se.P_TG_LUU(this.Title, "TC_DG_CNV_KY_KDG", b_dt);
    }

    private void P_PLNV_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_HDNS_MA_PLNV_LKE_ALL("A");
        se.P_TG_LUU(this.Title, "TC_DG_CNV_KY_PLNV", b_dt);
    }

    private void P_NHOM_TIEUCHI_DROP()
    {
        DataTable b_dt = dg.Fdt_NS_DG_MA_NHOM_TCHI_LKE_ALL();
        se.P_TG_LUU(this.Title, "TC_DG_CNV_KY_NHOMTC", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = dg.Fdt_NS_DG_TC_CNV_LKE_ALL();
            bang.P_SO_CNG(ref b_dt, "NGAY_ADUNG");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dg_tc_cnv.xlsx", b_dt, null, "Tiêu chí đánh giá cấp nhân viên");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}