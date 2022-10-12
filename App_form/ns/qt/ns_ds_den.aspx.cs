using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_ds_den : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_ds_den" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s); 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ds_den_P_KD();", true);
                P_Phong_LKE();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_Phong_LKE()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_DS_DEN_DVI", b_dt);

    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_qt.Fds_Fs_NS_DS_DEN_EXCEL(so_the.Text, hoten.Text, ma_phong.Value);
            DataTable b_dt = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_nop,ngaynghi");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "0", "Chưa phê duyệt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DS_DEN, TEN_BANG.NS_DS_DEN);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ds_den.xlsx", b_ds, null, "DanhSachDen");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
