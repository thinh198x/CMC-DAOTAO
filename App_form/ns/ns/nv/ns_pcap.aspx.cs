using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_pcap : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/sk/sns_sk.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ns/nv/ns_pcap" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_pcap_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_HTKHAC_DROP();
                se.P_TG_LUU(this.Title, "DT_MA_PHUCAP", b_dt);
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.PNS_PCAP_EXPORT(SO_THE.Text);
            bang.P_SO_CNG(ref b_dt, "ngayd"); bang.P_SO_CNG(ref b_dt, "ngayc"); bang.P_SO_CSO(ref b_dt, "tien");
            bang.P_THAY_GTRI(ref b_dt, "loaihuong", "TT", "Theo tháng");
            bang.P_THAY_GTRI(ref b_dt, "loaihuong", "TC", "Theo công thực tế");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_PCAP, TEN_BANG.NS_PCAP);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_pcap_export.xlsx", b_dt, null, "Quanly_cackhoan_hotro");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_ls.Fdt_NS_PCAP_IN(so_id.Value);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc"); bang.P_SO_CSO(ref b_dt, "TIEN");
            b_dt.TableName = "DATA";
            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
            string path = Server.MapPath("~");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_PCAP, TEN_BANG.NS_PCAP);
            Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\ns\qt\NS_PCAP.doc", "Quyet dinh chi tra phu cap.doc", b_ds_ep, Response);


        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
