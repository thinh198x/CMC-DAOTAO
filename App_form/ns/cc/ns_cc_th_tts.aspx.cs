using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cc_th_tts : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/cc/ns_cc_th_tts" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_th_tts_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy());

        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = tl_cc.Fdt_NS_CC_TH_TTS_LKE(an_nam.Value, an_kyluong_id.Value, an_so_the.Value, an_phong.Value, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            b_dt.TableName = "DATA";
            // ghi log 
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CC_TH_TTS, TEN_BANG.NS_CC_TH_TTS);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_th_tts.xlsx", b_dt, null, "Bang_cong_thuc_tap_sinh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
