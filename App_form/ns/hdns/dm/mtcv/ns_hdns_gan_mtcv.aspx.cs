using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_hdns_gan_mtcv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/mtcv/ns_hdns_gan_mtcv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_gan_mtcvdvi_P_KD();", true);
            P_NHAN_DROP(); NGAY_HL.Focus();
        }
    }

    private void P_NHAN_DROP()
    {
        //Ma dvi
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PH", b_dt.Copy());
    }
    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = ns_hdns.Fdt_NS_HDNS_GAN_MTCV_MAU();
        b_ds.Tables[0].TableName = "DATA1";
        b_ds.Tables[1].TableName = "DATA2";
        b_ds.Tables[2].TableName = "DATA3";
        Excel_dungchung.ExportTemplate("Templates/importhdns/ns_hdns_gan_mtcv_mau.xls", b_ds, null, "ns_hdns_gan_mtcv_mau");
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_hdns.Fdt_NS_HDNS_GAN_MTCV_EXCEL();
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_gan_mtcv.xlsx", b_dt, null, "Gan_chuc_danh_cho_don_vi");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void In_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_GAN_MTCV_IN(chuyen.OBJ_N(so_id.Text), chuyen.OBJ_N(so_id_mtcv.Text));
            b_ds.Tables[0].TableName = "DATA";
            b_ds.Tables[1].TableName = "DATA2";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/HDNS_MOTA_CV_IN.xlsx", b_ds, null, "Gan_chuc_danh_cho_don_vi_in");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
