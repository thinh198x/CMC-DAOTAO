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

public partial class f_tl_phanca : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/skhac.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));                
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx")); 
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                string b_s = this.ResolveUrl("~/App_form/tl/cc/tl_phanca" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_phanca_P_KD();", true);
                thumuc.Value = Fs_thumuc();                 
                P_NHAN_DROP(); loadYear();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/App_form/tl/cc/tl_phanca.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
    private void loadYear()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KYLUONG_TK", null);
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
        string b_loai, b_thang, b_ngayd, b_phong,b_t7,b_cn;
        b_loai = "1";b_thang = akyluong.Value;b_ngayd = NGAYD.Text;b_phong = aphong.Value;
        b_ds =tl_cc.Fdt_TEM_NGAY_LKE(b_loai, b_thang, b_ngayd, b_phong);
        DataTable b_dt1 = b_ds.Tables[0]; b_t7 = b_dt1.Rows[0]["T7"].ToString();b_cn = b_dt1.Rows[0]["CN"].ToString();
        string b_ngaydau= b_dt1.Rows[0]["ngayd"].ToString();
        DataTable b_dt2 = b_ds.Tables[1];b_dt2.TableName = "DATA";
        object[] a_obj = tl_cc.Faobj_CC_PHANCA_CT(b_phong,so_the_tk.Text, b_thang, 1, int.MaxValue);
        DataTable b_dt3 = (DataTable)a_obj[1]; 
        bang.P_THEM_COL(ref b_dt3, "kyluong", b_thang);bang.P_THEM_COL(ref b_dt3, "phong", b_phong); bang.P_THEM_COL(ref b_dt3, "ngayd", b_ngaydau);
        bang.P_DAT_GTRI(ref b_dt3, "T7", b_t7);bang.P_DAT_GTRI(ref b_dt3, "cn", b_cn);
        if (b_dt1.Rows[0]["ngaylam"] != null)
        {
            bang.P_DAT_GTRI(ref b_dt1, "ngaylam", chuyen.OBJ_I( b_dt1.Rows[0]["ngaylam"]));
        } 
        object[] a_obj2 = tl_cc.Faobj_CC_PHANCA_CT(aphong.Value,so_the_tk.Text, akyluong.Value, 1, int.MaxValue);
        DataTable b_dt = (DataTable)a_obj2[1]; 
        b_dt3.TableName = "DATA1";b_ds.Tables.Add(b_dt3);
        bang.P_BO_HANG(ref b_dt, "SO_THE", "");
        bang.P_SO_CNG(ref b_dt, "tungay,denngay");
        DataTable b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        b_dt_nv.TableName = "DATA6";
        DataTable b_dt4 = ht_dungchung.Fdt_MA_CALV_DR(); b_dt4.TableName = "DATA2"; b_dt.TableName = "DATA5"; b_ds.Tables.Add(b_dt4); b_ds.Tables.Add(b_dt);
        b_ds.Tables.Add(b_dt_nv);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.TL_PHANCA, TEN_BANG.TL_PHANCA);
        Excel_dungchung.ExportTemplate("Templates/importmau/tl_phanca_ktao.xls", b_ds, null, "tl_phanca_ktao");
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
            DataTable b_dt = tl_cc.P_TL_PHANCA_EXPORT(chuyen.OBJ_N(akyluong.Value), aphong.Value);
            bang.P_SO_CNG(ref b_dt, "ngayd,tungay,denngay");
            b_dt.TableName = "DATA1";
            b_ds.Tables.Add(b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_PHANCA, TEN_BANG.TL_PHANCA);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_phanca_export.xlsx", b_ds, null, "tl_phanca_export");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}

