using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dsach_giayto_bbuoc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/tl/ns_dsach_giayto_bbuoc" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "NS_DSACH_GIAYTO_BBUOC_P_KD();", true);
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
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_kyluong = aky.Value.ToString();
            string b_phong = "TATCA"; 
            object[] a_object = tl_ch.FS_NS_DSACH_GIAYTO_BBUOC_LKE(so_the_tk.Text, ten.Text, b_kyluong, b_phong, 1, 10000);
            DataTable b_dt = (DataTable)a_object[1];
            b_dt.TableName = "DATA"; 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.HDNS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DSACH_GIAYTO_BBUOC, TEN_BANG.NS_DSACH_GIAYTO_BBUOC);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dsach_giayto_bbuoc.xlsx", b_dt, null, "Danh_sach_giay_to_bat_buoc");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}