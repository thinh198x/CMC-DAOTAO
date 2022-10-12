using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using Cthuvien;
using System.Collections.Generic;

public partial class f_cc_cn_ct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_cn_ct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_cn_ct_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);                
                P_NHAN_DROP(); loadYear();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/App_form/tl/cc/cc_cn_ct.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
    private void loadYear()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_nam.Copy());
        //se.P_TG_LUU(this.Title, "DT_KY", null);
    } 
    private void P_NHAN_DROP()
    {
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "Tất cả", "Tất cả", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_phong.Copy());     
    } 
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        string b_loai, b_thang, b_ngayd, b_phong, b_t7, b_cn;
        b_loai = "1"; b_thang = akyluong.Value; b_ngayd = NGAYD.Text; b_phong = aphong.Value;
        b_ds = tl_cc.Fdt_TEM_NGAY_LKE(b_loai, b_thang, b_ngayd, b_phong);
        DataTable b_dt1 = b_ds.Tables[0]; b_t7 = b_dt1.Rows[0]["T7"].ToString(); b_cn = b_dt1.Rows[0]["CN"].ToString();
        string b_ngaydau = b_dt1.Rows[0]["ngayd"].ToString();
        DataTable b_dt2 = b_ds.Tables[1]; b_dt2.TableName = "DATA";
        object[] a_obj = tl_cc.Faobj_CC_CN_CT_CT(aphong.Value,so_the_tk.Text, double.Parse(akyluong.Value), 1, int.MaxValue);
        DataTable b_dt3 = (DataTable)a_obj[1];
        bang.P_XEP(ref b_dt3, "SO_THE");
        bang.P_THEM_COL(ref b_dt3, "kyluong", b_thang); bang.P_THEM_COL(ref b_dt3, "phong", b_phong); bang.P_THEM_COL(ref b_dt3, "ngayd", b_ngaydau);
        bang.P_DAT_GTRI(ref b_dt3, "T7", b_t7); bang.P_DAT_GTRI(ref b_dt3, "cn", b_cn); bang.P_DAT_GTRI(ref b_dt3, "ngaylam", chuyen.OBJ_I(b_dt1.Rows[0]["ngaylam"]));
        DataTable b_dt = b_dt3.Copy();
        bang.P_BO_HANG(ref b_dt, "SO_THE", "");
        bang.P_SO_CNG(ref b_dt, "tungay,denngay");
        b_dt3.TableName = "DATA1"; b_ds.Tables.Add(b_dt3);
        DataTable b_dt4 = tl_ma.Fdt_CC_MA_CC_DR2("N"); b_dt4.TableName = "DATA2"; b_dt.TableName = "DATA5"; b_ds.Tables.Add(b_dt4); b_ds.Tables.Add(b_dt);

        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.CC_CN_CT, TEN_BANG.CC_CN_CT); 
        Excel_dungchung.ExportTemplate("Templates/importmau/cc_cn_ct_ktao.xls", b_ds, null, "cc_cn_ct_ktao.xls");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            string b_loai, b_thang, b_ngayd;
            b_loai = "1"; b_thang = KYLUONG.Text; b_ngayd = NGAYD.Text;
            b_ds = tl_cc.Fdt_TEM_NGAY_LKE(b_loai, akyluong.Value, b_ngayd, aphong.Value);
            DataTable b_dt2 = b_ds.Tables[1]; b_dt2.TableName = "DATA"; 
            object[] a_obj = tl_cc.Faobj_CC_CN_CT_CT(aphong.Value,so_the_tk.Text, double.Parse(akyluong.Value), 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_XEP(ref b_dt, "SO_THE");
            bang.P_SO_CNG(ref b_dt, "ngayd,tungay,denngay");
            b_dt.TableName = "DATA1";
            b_ds.Tables.Add(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.CC_CN_CT, TEN_BANG.CC_CN_CT); 
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_cn_ct_export.xlsx", b_ds, null, "cc_cn_ct_export");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}