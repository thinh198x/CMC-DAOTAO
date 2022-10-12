using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_khoan_phaithu : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/sk/sns_sk.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/ma/ns_tl_khoan_phaithu" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_khoan_phaithu_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
                ngaytao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        bang.P_THEM_HANG(ref b_nam, new object[] { "0", " " }, 0);
        se.P_TG_LUU(this.Title, "DT_NAM_TK", b_nam.Copy());
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_ma.PNS_TL_KHOAN_PHAITHU_EXPORT(so_the_tk.Text, ten_tk.Text);
            bang.P_SO_CSO(ref b_dt, "sotien_thu,sotien_tra");
            bang.P_SO_CNG(ref b_dt, "ngaytao");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TL_KHOAN_PHAITHU, TEN_BANG.NS_TL_KHOAN_PHAITHU);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_khoan_phaithu.xlsx", b_dt, null, "Quanly_khoan_hotro_them");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_nam,b_nam1;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("NO");
        b_dt_nv.TableName = "DATA";
        b_nam1 = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        b_nam1.TableName = "DATA2";
        b_nam = hts_dungchung.Fdt_MA_KYLUONG_BY_NAM();
        b_nam.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_nam);
        b_ds.Tables.Add(b_nam1);
        // ghi log
        hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_MAU, TEN_FORM.NS_TL_KHOAN_PHAITHU, TEN_BANG.NS_TL_KHOAN_PHAITHU);
        Excel_dungchung.ExportTemplate("Templates/importmau/ns_tl_khoan_phaithu.xls", b_ds, null, "Quanly_khoan_hotro_them");
    }
}
