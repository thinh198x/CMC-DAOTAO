using Cthuvien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class f_ns_cc_ma_ccnv : fmau
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
                string b_s = this.ResolveUrl("~/App_form/tl/ma/ns_cc_ma_ccnv" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_ma_ccnv_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.ToString()); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy());

        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            var b_sothe = "";
            var b_ky = akyluong.Value;
            var b_phong = aphong.Value;
            var b_dt_kyluong = ht_dungchung.Fdt_MA_KYLUONG(0);
            b_dt_kyluong.TableName = "DATA2";
            bang.P_SO_CNG(ref b_dt_kyluong, "NGAY_BD,NGAY_KT");
            b_ds.Tables.Add(b_dt_kyluong.Copy());

            var b_dt_canbo = ht_dungchung.Fdt_NS_THONGTIN_QD_KHOANG(b_sothe, b_ky, b_phong);
            b_dt_canbo.TableName = "DATA3";
            b_ds.Tables.Add(b_dt_canbo.Copy());
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_cc_ma_ccnv_mau.xls", b_ds, null, "Thiet_lap_cong_chuan_nhanvien" + DateTime.Now.Second);
        }
        catch (Exception) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}