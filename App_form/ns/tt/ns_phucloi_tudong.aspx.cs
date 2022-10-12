using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_phucloi_tudong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_phucloi_tudong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s); 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_phucloi_tudong_P_KD();", true);
                P_Phong_DR();
                //loadYear(); P_NHAN_DROP(); loadMonth();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_Phong_DR()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_PHUCLOI_TUDONG_DVI", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(this.NGAY_D.Text) || string.IsNullOrEmpty(this.NGAY_C.Text))
                throw new Exception("NGAY_D");
            DataTable b_dt_pl = ns_tt.PNS_PHUCLOI_TU_DONG_EXCEL(this.ma_phong.Value, this.so_the_tk.Text.Trim(), this.hoten_tk.Text.Trim(), chuyen.CNG_SO(this.NGAY_D.Text), chuyen.CNG_SO(this.NGAY_C.Text));
            bang.P_SO_CNG(ref b_dt_pl, "ng_apdung");
            b_dt_pl.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_PHUCLOI_TUDONG, TEN_BANG.NS_PHUCLOI_TUDONG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_phucloi_tudong.xlsx", b_dt_pl, null, "ns_phucloi_tudong");
        }
        catch (Exception ex)
        {
            if (ex.Message == "NGAY_D")
                form.P_LOI(this, "loi:Bạn cần nhập ngày bắt đầu và ngày kết thúc:loi");
            else
                form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }
}