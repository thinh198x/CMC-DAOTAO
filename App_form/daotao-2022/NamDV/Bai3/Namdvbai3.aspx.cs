using Cthuvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class f_ns_hdns_nam_bai3 : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/daotao-2022/NamDV/Bai3/Namdvbai3" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            P_NHAN_DROP();
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "P_KD();", true);
            MA.Text = ht_dungchung.Fdt_AutoGenCode("PB", "DAOTAO_BAI3", "MA");
            TEN.Focus();
        }
    }

    private void P_NHAN_DROP()
    {
        //Tinh thanh
        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NAM_BT3_DROP();
        se.P_TG_LUU(this.Title, "DT_TT", b_dt);
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_NAM_BT3_DR();
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_MA_VTCDANH, TEN_BANG.NS_HDNS_MA_VTCDANH);
            Excel_dungchung.ExportTemplate("Templates/DaoTao/daotao_bai3.xlsx", b_dt, null, "NAM_Bai3");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}