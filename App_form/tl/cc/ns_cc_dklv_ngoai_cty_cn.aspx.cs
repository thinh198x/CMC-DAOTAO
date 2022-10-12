using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_dklv_ngoai_cty_cn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                se.se_nsd b_se = new se.se_nsd(); string b_ma_dvi = b_se.ma_dvi;
                string b_nsd = b_se.nsd; string b_so_the = P_SOTHE(b_nsd);
                string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_dklv_ngoai_cty_cn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_dklv_ngoai_cty_cn_P_KD('" + b_so_the + "');", true);

                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    private void P_NHAN_DROP()
    {
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        //se.P_TG_LUU(this.Title, "DT_KY", null);
    }

    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_CN_LKE(aNam_tk.Value, akyluong_tk.Value, att_tk.Value, aSothe.Value, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_obj[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_dk");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "2", "Không phê duyệt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_CN, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_cc_dklv_ngoai_cty_cn.xlsx", b_dt, null, "Dangky_lamviec_ngoai_cty");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}