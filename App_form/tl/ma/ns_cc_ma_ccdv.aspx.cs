using System;
using System.Web.UI;
using Cthuvien;
using System.Data;

public partial class f_ns_cc_ma_ccdv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/ns_cc_ma_ccdv" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_ma_ccdv_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }
    private void P_NHAN_DROP()
    { 
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KY", null);
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_cc_ma_ccdv_mau.xls", b_dt, null, "ns_cc_ma_ccdv_mau");
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ht_madvi.Fdt_MA_DVI_XEM();
            Excel_dungchung.ExportTemplate("Templates/importhdns/ns_cc_ma_ccdv_mau.xls", b_dt, null, "ns_cc_ma_ccdv_mau");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
