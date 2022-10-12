using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tv : fmau
{
    public string b_so_the = "", b_ten = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_tv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tv_P_KD();", true);
                ngay_ky.Text = chuyen.NG_CNG(DateTime.Now);
                P_Phong_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_Phong_DR()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_TV_DVI", b_dt);
        b_dt = ns_ma.Fdt_PNS_HS_MA_CHUNG_DR("LDNV");
        //bang.P_THEM_TRANG(ref b_dt, 0);
        se.P_TG_LUU(this.Title, "DT_LD_NV", b_dt.Copy());

        b_dt = ht_dungchung.Fdt_MA_KYLUONG_NAM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy());
    }

    private void P_SOTHE(string b_nsd)
    {
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) { b_so_the = b_dt.Rows[0]["so_the"].ToString(); b_ten = b_dt.Rows[0]["ten"].ToString(); }
    }

    [Obsolete]
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_TV_LKE_ALL(ngayd_tk.Text, ngayc_tk.Text);
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_tt");

            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "0", "Chưa phê duyệt");
            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_TV, TEN_BANG.NS_TV);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tv.xlsx", b_ds_ep, null, "Nghi_viec");

        }
        catch (Exception ex)
        {
            form.P_LOI(this, "loi:File export không tồn tại:loi");
        }
    }
    protected void nhap2_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_TV_IN(so_id_in.Value);
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            //bang.P_CSO_SO(ref b_dt, "trocap_thoiviec,tien_bh_daotao,tien_thuong,truythu_tamung,truythu_nghiphep,khoan_khac");
            DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
            string path = Server.MapPath("~");

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_TV, TEN_BANG.NS_TV);
            Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\ns\qt\NS_TV_IN.doc", "Quyet dinh.doc", b_ds_ep, Response);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void nhap3_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = null;// ns_qt.Fdt_NS_TV_EXCEL(SO_THE.Text, "2");
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_bt_tailieu = b_ds.Tables[1];
            DataTable b_dt_thietbi = b_ds.Tables[2];
            DataTable b_dt_taisan = b_ds.Tables[3];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_bd_hd,ngay_kt_hd,ngay_nop,ngay_xin,ngay_pd,ngay_tt,ngay_ky");
            bang.P_CSO_SO(ref b_dt, "trocap_thoiviec,tien_bh_daotao,tien_thuong,truythu_tamung,truythu_nghiphep,khoan_khac");
            b_bt_tailieu.TableName = "DATA_TL";

            bang.P_SO_CNG(ref b_bt_tailieu, "ngay_bg");
            b_dt_thietbi.TableName = "DATA_TB";
            bang.P_CSO_SO(ref b_dt_thietbi, "soluong,sotien");
            bang.P_SO_CNG(ref b_dt_thietbi, "ngay_cap");

            b_dt_taisan.TableName = "DATA_TS";
            bang.P_SO_CNG(ref b_dt_taisan, "ngay_cap");
            bang.P_CSO_SO(ref b_dt_taisan, "soluong");

            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TINHTRANG", "0", "Chưa phê duyệt");

            bang.P_THAY_GTRI(ref b_dt_thietbi, "TINHTRANG_TB", "1", "Đã bàn giao");
            bang.P_THAY_GTRI(ref b_dt_thietbi, "TINHTRANG_TB", "0", "Chưa bàn giao");

            bang.P_THAY_GTRI(ref b_dt_taisan, "TINHTRANG_TS", "1", "Đã bàn giao");
            bang.P_THAY_GTRI(ref b_dt_taisan, "TINHTRANG_TS", "0", "Chưa bàn giao");
            string path = Server.MapPath("~");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_TV, TEN_BANG.NS_TV);
            Word_dungchung.ExportWord(path + @"Templates\ExportMau\InBienBanThanLy.doc", "Bienbanthanhly", b_ds, "B", Response);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}