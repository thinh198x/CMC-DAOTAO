using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_dt_cmd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/tl_dt_cmd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_dt_cmd_P_KD('');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = tl_ma.Fdt_NS_DT_CMD_EXCEL();
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NG_HLUC,NG_HET_HLUC");
            bang.P_SO_CNG(ref b_dt_ct, "NG_HLUC,NG_HET_HLUC");
            b_dt.TableName = "DATA"; b_dt_ct.TableName = "DATA_DV";
            DataSet b_ds_ep = new DataSet();
            b_ds_ep.Tables.Add(b_dt.Copy());
            b_ds_ep.Tables.Add(b_dt_ct.Copy());

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_DT_CMD, TEN_BANG.TL_DT_CMD);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdns_tl_cmd.xlsx", b_ds_ep, null, "Thiet_lap_ca_mac_dinh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}