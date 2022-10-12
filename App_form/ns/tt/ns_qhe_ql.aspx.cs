using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_qhe_ql : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hs/sns_hs.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_qhe_ql" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_qhe_ql_P_KD('');", true);
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_LQH_DR();
        se.P_TG_LUU(this.Title, "DT_LQHE", b_dt);

        //Quoc tich
        //b_dt = ns_ma.Fdt_NS_MA_NUOC_DR();
        ////bang.P_THEM_TRANG(ref b_dt, 0);
        //se.P_TG_LUU(this.Title, "DT_QT", b_dt.Copy());
        //Tinh thanh pho
        //b_dt = ns_ma.Fdt_NS_MA_TT_DR();
        ////bang.P_THEM_TRANG(ref b_dt, 0);
        //se.P_TG_LUU(this.Title, "DT_TTP", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_NSQH", null);
        se.P_TG_LUU(this.Title, "DT_NSXP", null);
        se.P_TG_LUU(this.Title, "DT_THQH", null);
        se.P_TG_LUU(this.Title, "DT_THXP", null);
        se.P_TG_LUU(this.Title, "DT_TTQH", null);
        se.P_TG_LUU(this.Title, "DT_TTXP", null);
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    string b_ma_cb = SO_THE.Text;
        //    if (string.IsNullOrEmpty(b_ma_cb))
        //    {
        //        form.P_LOI(this, "loi:Phải chọn mã cán bộ cần xuất:loi");
        //    }
        //    else
        //    {
        //        object[] a_object = ns_tt.Fdt_NS_QHE_LKE(b_ma_cb, 1, 10000000);
        //        DataTable b_dt = (DataTable)a_object[1];
        //        bang.P_SO_CNG(ref b_dt, new string[] { "ngaysinh", "ngayd", "ngayc" });
        //        bang.P_THAY_GTRI(ref b_dt,"phuthuoc","K","Không");
        //        bang.P_THAY_GTRI(ref b_dt, "phuthuoc", "C", "Có");
        //        b_dt.TableName = "DATA";
        //        Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hs/ns_qhe_ql.xlsx", b_dt, null, "Quan_he_nhan_than");
        //    }
        //}
        //catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        Excel_dungchung.ExportTemplate("Templates/importhsns/ns_qhe_ql.xls","ns_qhe_ql");
    }
}
