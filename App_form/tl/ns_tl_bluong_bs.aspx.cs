using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_tl_bluong_bs : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ns_tl_bluong_bs" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_bluong_bs_P_KD();", true);
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
            object[] a_object = tl_ch.Fdt_NS_TL_BLUONG_BS_LKE(an_nam.Value, an_kyluong_id.Value, an_so_the.Value, an_phong.Value, 1, int.MaxValue);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CSO(ref b_dt, "phi_gd_thucthu,tyle_hoahong,hoahong_hoptac,thangtruoc_chuyensang,truno_bhxh,hoahong_tienvay,hoahong_ir,hoahong_traiphieu,tong_thunhap_truocthue,thanhtoan_thangnay,chuyen_thangsau,thue_tncn,thuc_nhan");
            b_dt.TableName = "DATA_TK";
            // ghi log 
            hts_dungchung.PHT_LOG_NH(PHANHE.TL, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TL_BLUONG_BS, TEN_BANG.NS_TL_BLUONG_BS);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_bluong_bs.xls", b_dt, null, "Bang_luong_khoibs");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
