using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dthv_tt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_dthv_tt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dthv_tt_P_KD('');", true);
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_CAPDT_DR();
        se.P_TG_LUU(this.Title, "DT_TRINHDO", b_dt);

        DataTable b_dt_htdt = ns_ma.Fdt_NS_MA_HTDT_DR_A();
        se.P_TG_LUU(this.Title, "ns_dthv_tt_HTDT", b_dt_htdt);

        DataTable b_dt_cnganh = ns_ma.Fdt_NS_MA_CNGANH_DT_DR_A();
        se.P_TG_LUU(this.Title, "ns_dthv_tt_CNGANH", b_dt_cnganh);

        DataTable b_dt_truong = ns_ma.Fdt_NS_MA_TRUONGHOC_DR();
        se.P_TG_LUU(this.Title, "DT_TRUONG", b_dt_truong);

        //hinhthuc.DataSource = b_dt; hinhthuc.DataBind();
        //b_dt = ns_ma.Fdt_NS_MA_HEDT_DR();
        //hedt.DataSource = b_dt; hedt.DataBind();
        //b_dt = ns_ma.Fdt_NS_MA_XLOAI_DR();
        //xeploai.DataSource = b_dt; xeploai.DataBind();
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_DTHV_TT_LKE_ALL(this.so_the_an.Value);
            bang.P_THAY_GTRI(ref b_dt, "XEPLOAI", "M", " ");
            bang.P_THAY_GTRI(ref b_dt, "XEPLOAI", "G", "Giỏi");
            bang.P_THAY_GTRI(ref b_dt, "XEPLOAI", "K", "Khá");
            bang.P_THAY_GTRI(ref b_dt, "XEPLOAI", "TB", "Trung bình");
            bang.P_SO_CTH(ref b_dt, "thangd,thangc");
            bang.P_SO_CNG(ref b_dt, "ngaycap");
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dthv.xlsx", b_dt, null, "Danh muc cap nhan vien");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
