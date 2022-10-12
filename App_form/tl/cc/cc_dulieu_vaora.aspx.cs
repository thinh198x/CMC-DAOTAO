using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_cc_dulieu_vaora : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx")); 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_dulieu_vaora" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_dulieu_vaora_P_KD();", true);
                P_NHAN_DROP();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Phong
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt); se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        { 
            object[] a_obj = tl_cc.Faobj_CC_QUET_THE_LKE(aphong.Value, chuyen.CNG_SO(NGAYD.Text), chuyen.CNG_SO(NGAYC.Text), SO_THE.Text, ho_ten.Text, di_muon.Text, ve_som.Text, nghi_cn.Text, 1, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1]; 
            bang.P_SO_CNG(ref b_dt, "ngay");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.CC_DULIEU_VAORA, TEN_BANG.CC_DULIEU_VAORA);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_dulieu_vaora.xlsx", b_dt, null, "cc_dulieu_vaora");
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}