using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hdct : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/ma/stl_ma.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_hdct" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdct_P_KD('" + khac.Fs_TMUCF(b_s) + "," + se.Fs_LOGIN() + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Phong
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);
        //Hinh thuc
        b_dt = ns_ma.Fdt_NS_MA_QDINH_DR("QD");
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_HINHTHUC", b_dt);
        se.P_TG_LUU(this.Title, "DT_HINHTHUC_TK", b_dt.Copy());
        // Thang lương
        b_dt = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);

        DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
        if (b_tusinh != null && b_tusinh.Rows.Count > 0)
        {
            if (b_tusinh.Rows[0]["QUYETDINH"].Equals("TS"))
            {
                SO_QD.ReadOnly = true;
                SO_QD.Enabled = false;
            }
        }
    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            if (so_id.Value != "0")
            {
                DataTable b_dt = ns_qt.Fdt_NS_HDCT_IN(so_id.Value);
                bang.P_THAY_GTRI(ref b_dt, "XUNGHO", "NAM", "Ông");
                bang.P_THAY_GTRI(ref b_dt, "XUNGHO", "NU", "Bà");
                bang.P_SO_CNG(ref b_dt, "NGAYD,NGAYC");
                bang.P_SO_CSO(ref b_dt, "THUNHAPTHANG,LUONGCB,THUONG_KETQUA,LUONGCB_C,THUNHAPTHANG_C,THUONG_KETQUA_C");
                b_dt.TableName = "DATA";
                DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
                string path = Server.MapPath("~");
                string b_lhd = alqdinh.Value;
                DataTable b_dt_mau = ns_ma.Fdt_NS_BIEUMAU_HD(alqdinh.Value, NGAYD.Text);
                DataSet b_ds = new DataSet();
                b_ds.Tables.Add(b_dt);
                b_ds.Tables[0].TableName = "DATA";
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
                if (b_dt_mau.Rows.Count > 0)
                {
                    string pathhd = Server.MapPath("~");
                    Word_dungchung.ExportWord(pathhd + @"Templates\Bieu_mau_dong_quyet_dinh\" + b_lhd + @"\" + b_dt_mau.Rows[0]["TEN"].ToString(), "Quyet_dinh.docx", b_ds, "B", Response);
                }
                else
                {
                    form.P_LOI(this, "loi:Chưa có biểu mẫu cho loại quyết định này:loi");
                }
            }
            else
            {
                form.P_LOI(this, "loi:Chọn 1 bản ghi để in:loi");
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.ToString()); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            //object[] a_obj = ns_qt.Faobj_NS_HDCT_LKE_ALL("","","","");
            DataSet b_ds = ns_qt.Faobj_NS_HDCT_LKE_ALL(so_the_tk.Text, ten_tk.Text, phong_tk.Text, nghi_viec_tk.Text);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_THAY_GTRI(ref b_dt, "tt", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tt", "CPD", "Chưa phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayc,ngayd,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luongcb,thunhapthang,thuong_ketqua,pt_huongluong,dongia");
            b_dt.TableName = "DATA";
            b_dt_ct.TableName = "DATA_PC";
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ad,ngay_kt");
            bang.P_SO_CSO(ref b_dt_ct, "sotien");

            DataSet b_ds_ex = new DataSet();
            b_ds_ex.Tables.Add(b_dt.Copy());
            b_ds_ex.Tables.Add(b_dt_ct.Copy());

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hdct.xlsx", b_ds_ex, null, "Quan_ly_quyet_dinh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    protected void export_excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_hinhthuc = ns_ma.Fdt_NS_MA_QDINH_DR("QD");
            DataTable b_dt_ngky = hts_dungchung.Fdt_NG_KY();
            DataTable b_dt_bangluong = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
            DataTable b_dt_ngachluong = ns_ma.Fdt_NS_MA_TL_NL("0");
            DataTable b_dt_bacluong = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL("0", "0");
            DataTable b_dt_phong = ns_tt.Fdt_MA_PHONG_LKE();
            DataTable b_dt_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG("0");

            b_dt_hinhthuc.TableName = "DATA1";
            b_dt_ngky.TableName = "DATA2";
            b_dt_bangluong.TableName = "DATA3";
            b_dt_ngachluong.TableName = "DATA4";
            b_dt_bacluong.TableName = "DATA5";
            b_dt_phong.TableName = "DATA6";
            b_dt_cdanh.TableName = "DATA7";

            b_ds.Tables.Add(b_dt_hinhthuc);
            b_ds.Tables.Add(b_dt_ngky);
            b_ds.Tables.Add(b_dt_bangluong);
            b_ds.Tables.Add(b_dt_ngachluong);
            b_ds.Tables.Add(b_dt_bacluong);
            b_ds.Tables.Add(b_dt_phong);
            b_ds.Tables.Add(b_dt_cdanh);
            Excel_dungchung.ExportTemplate("Templates/importmau/ns_hdct_imp.xls", b_ds, null, "ns_hdct_imp" + DateTime.Now.Second);

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}
