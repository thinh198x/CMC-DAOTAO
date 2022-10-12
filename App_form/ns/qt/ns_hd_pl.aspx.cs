using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hd_pl : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_hd_pl" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hd_pl_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //day danh sach loai hop dong
        DataTable b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        se.P_TG_LUU(this.Title, "DT_LHD", b_dt);

        // Thang lương
        b_dt = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);

        //day danh sách số hợp đồng
        b_dt = ns_ma.Fdt_NS_SO_HD_DR();
        se.P_TG_LUU(this.Title, "DT_SO_HD", b_dt);

        // lay danh sach phong
        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HD_PL_IN(so_id.Value);

            bang.P_SO_CNG(ref b_dt, "nsinh,ngayd,ngayc,ngay_cmt"); bang.P_SO_CSO(ref b_dt, "tien,tien_lcb");
            b_dt.TableName = "DATA";
            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
            string path = Server.MapPath("~"); 
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_HD_PL, TEN_BANG.NS_HD_PL);
            Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\ns\tt\ns_hd_pl.doc", "Phu luc hop dong.doc", b_ds_ep, Response);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File mẫu không tồn tại:loi"); }
    }
}