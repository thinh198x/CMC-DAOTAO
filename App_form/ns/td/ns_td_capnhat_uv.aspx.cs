using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_td_capnhat_uv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_capnhat_uv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_capnhat_uv_P_KD();", true);
                P_NHAN_DROP();
                //NAM.Text = DateTime.Now.Year.ToString();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        // PHÒNG
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        // TIỀN TỆ
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TIENTE");
        se.P_TG_LUU(this.Title, "DT_TIENTE", b_dt);
        // TÌNH TRẠNG TUYỂN MỚI
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_TM");
        se.P_TG_LUU(this.Title, "DT_TM", b_dt);
        //  TÌNH TRẠNG ỨNG VIÊN
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("TT_UV");
        se.P_TG_LUU(this.Title, "DT_UV", b_dt);

        se.P_TG_LUU(this.Title, "DT_MAYEUCAU_TD", null);
        se.P_TG_LUU(this.Title, "DT_SO_THE", null);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_td.Fdt_NS_TD_CAPNHAT_UV_EXCEL();
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, "luong_cb,thunhap");
            bang.P_SO_CNG(ref b_dt, "ngayd");

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.TD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TD_CAPNHAT_UV, TEN_BANG.NS_TD_CAPNHAT_UV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_capnhat_uv.xlsx", b_dt, null, "Danh_sach_thong_tin_ung_vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}