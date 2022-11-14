using Cthuvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ntduc_b3:fmau
{
        #region Main
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/daotao-2022/Ntduc_test/Ntduc_bai3" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                 P_NHAN_DROP();
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                 ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_ntduc_bai3_P_KD();", true);
                 MA.Text = ht_dungchung.Fdt_AutoGenCode("PB", "NS_MA_PBAN_NTDUC", "MA");
                TEN.Focus();
            }

        }
    #endregion

    private void P_NHAN_DROP()
    {
        DataTable b_dt = null;
        b_dt = ns_hdns.Fdt_NS_PB_NTDUC_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_TT", b_dt);
 
    }

    #region Xuất excel động
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            
            string b_ngay_tu = ngay_tu.Text;
            string b_ngay_den = ngay_den.Text;
            DataTable b_dt = ns_hdns.Fdt_NS_PB_NTDUC_EXPORT(b_ngay_tu, b_ngay_den);
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            bang.P_SO_CNG(ref b_dt, "ngay_gt");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDNS_PBAN_NTDUC, TEN_BANG.NS_MA_PBAN_NTDUC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/longbai3.xlsx", b_dt, null, "Danh_muc_phong_ban");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    #endregion
}


