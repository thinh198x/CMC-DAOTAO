using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ds_kddk_bh : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/cd/sns_cd.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/ns/cd/ns_ds_kddk_bh" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NS_DS_KDDK_BH_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_kyluong = aky.Value.ToString();
            object[] a_object = ns_cd.FS_NS_DS_KDBHXH_LKE(so_the_tk.Text,ten.Text,nam_tk.Text, b_kyluong, 1,10000);
            DataTable b_dt = (DataTable)a_object[1];
            b_dt.TableName = "DATA";
            bang.P_SO_CSO(ref b_dt, "luongbh");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "C", "Đã xác nhận");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "K", "Chưa xác nhận");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DS_KDDK_BH, TEN_BANG.NS_DS_KDDK_BH);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ds_kddk_bh.xlsx", b_dt, null, "Danh_muc_khong_dong_bao_hiem");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}