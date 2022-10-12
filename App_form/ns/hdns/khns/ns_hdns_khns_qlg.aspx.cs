using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;


public partial class f_ns_hdns_khns_qlg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/khns/ns_hdns_khns_qlg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_khns_qlg_P_KD();", true);
            P_NHAN_DROP();
        }
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "KHNS_QLG_NAM", b_dt);

        DataTable b_dt_phong = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "KHNS_QLG_PHONG", b_dt_phong);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            double b_nam = chuyen.CSO_SO(this.nam_lke.Text);
            if (b_nam == 0) { form.P_LOI(this, "loi:Chưa chọn năm:loi"); return; }

            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_KHNS_QLG_EXCEL(b_nam);
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "DC", "Đã có");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "TM", "Tuyển mới");
            bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d_nam", "ngay_td", "ngay_c_nam" });

            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_khns_qlg.xlsx", b_dt, null, "KeHoachQuyLuong");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void excel_mau_Click(object sender, EventArgs e)
    {
        try
        {
            Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_khns_qlg.xls", "ns_hdns_khns_qlg");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}