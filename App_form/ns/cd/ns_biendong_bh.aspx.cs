using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_biendong_bh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
            string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
            string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_biendong_bh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_biendong_bh_P_KD();", true);
            P_NHAN_DROP(); SO_THE.Focus();
            Response.ExpiresAbsolute = DateTime.Now.AddDays(-1d);
            Response.Expires = -1500;
            Response.CacheControl = "no-cache";
        }
    }
    private void P_NHAN_DROP()
    {
        DataRow drRow;
        DataTable b_dt = new DataTable();
        b_dt = ht_dungchung.PNS_MA_KHAC_DR();
        drRow = b_dt.NewRow();
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        se.P_TG_LUU(this.Title, "DT_LOAI_BD", b_dt);

        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //DataTable b_dt_m = new DataTable();
        //b_dt_m = bang.Fdt_TAO_BANG("MA,TEN", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);

        b_dt = ns_ma.Fdt_NS_MA_PHUONG_AN_DR();
        se.P_TG_LUU(this.Title, "DT_PHUONG_AN", b_dt);
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_bv = ns_cd.Fdt_NS_BIENDONG_BH_LKE_ALL();
            b_dt_bv.TableName = "DATA";
            bang.P_SO_CTH(ref b_dt_bv, "thang_bd");
            bang.P_SO_CSO(ref b_dt_bv, "luong_c,luong_m,tt_bhxh,tt_bhyt,tt_bhtn,tht_bhxh,tht_bhyt,tht_bhtn");
            bang.P_SO_CNG(ref b_dt_bv, "ngaytra_bhxh,ngaytra_bhyt,ngay_truythu_d,ngay_truythu_c,ngay_thoaithu_d,ngay_thoaithu_c");

            b_ds.Tables.Add(b_dt_bv);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_BIENDONG_BH, TEN_BANG.NS_BIENDONG_BH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_biendong_bh.xlsx", b_ds, null, "BIENDONG_BH" + DateTime.Now.Second);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}