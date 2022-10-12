using Cthuvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class f_ns_td_info_dev : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_info_dev" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_info_dev_P_KD('');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        //Đơn vị tìm kiếm
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_PHONG_CT", b_dt.Copy());

        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        se.P_TG_LUU(this.Title, "DT_CONGTY", b_dt.Copy());
        //se.P_TG_LUU(this.Title, "DT_PHONG_CT", null);

        b_dt = hts_dungchung.Fdt_CHUNG_LKE("KHOI");
        se.P_TG_LUU(this.Title, "DT_BOPHAN_CT", b_dt.Copy());
        // se.P_TG_LUU(this.Title, "DT_PHONG", null);
        // se.P_TG_LUU(this.Title, "DT_CDANH", null);
        // se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt.Copy());
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_INFO_DEV_EXPORT();
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_hl");

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_INFO_DEV, TEN_BANG.NS_TD_INFO_DEV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_info_dev.xlsx", b_dt, null, "Thong tin phong ban - ung vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}