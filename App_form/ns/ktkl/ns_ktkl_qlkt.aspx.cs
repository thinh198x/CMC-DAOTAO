using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ktkl_qlkt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ktkl/sns_ktkl.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ktkl/ns_ktkl_qlkt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s); 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ktkl_qlkt_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
                P_HTKT();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt;
        // Lấy danh sách phòng
        DataTable b_dt_tk = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_TRANG(ref b_dt_tk, 1, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt_tk.Copy());
        // Đối tượng khen thưởng
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DTKTKL");
        bang.P_XEP(ref b_dt, "ma");
        form.P_LIST_BANG(DTUONG, b_dt);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        form.P_LIST_BANG(dtkt_tk, b_dt);
        // Cấp khen thưởng kỷ luật
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("CKTKL");
        bang.P_XEP(ref b_dt, "ma");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        form.P_LIST_BANG(CAP_KTKL, b_dt);
        //Năm cộng vào lương
        b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
    }

    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            if (so_id.Value != "0")
            {
                DataSet b_ds = ns_ktkl.Fdt_NS_KTKL_QLKT_IN(so_id.Value); DataSet b_ds_kt = new DataSet();
                var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
                b_dt.TableName = "DATA"; b_dt_ct.TableName = "DATA1";
                string path = Server.MapPath("~");
                //----------------------------------------------------------------------Son--------------------------------------------//
                if (alhd.Value == "CN") // Quyết định khen thưởng cá nhân
                {
                    path = path + @"Templates\ExportMau\ns\tt\ns_ktkl_qlkt_cn.doc";
                    b_ds_kt.Tables.Add(b_dt.Copy());
                }
                else if (alhd.Value == "TT") // Quyết định khen thưởng tập thể
                {
                    //xuat_excel_tt(b_dt);
                    path = path + @"Templates\ExportMau\ns\tt\ns_ktkl_qlkt_tt.doc";
                    bang.P_BO_HANG(ref b_dt, 1, b_dt.Rows.Count);
                    b_ds_kt.Tables.Add(b_dt.Copy()); 
                }

                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_KTKL_QLKT, TEN_BANG.NS_KTKL_QLKT);
                Word_dungchung.ExportMailMerge(path, "Quyet_Dinh_Khen_Thuong", b_ds_kt, Response);
            }
            else
            {
                form.P_LOI(this, "loi:Chọn 1 bản ghi để in:loi");
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File mẫu không tồn tại:loi"); }
    }
    protected void xuat_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nv = nghi_viec_tk.Text == "X" ? "1" : "0";
            DataTable b_dt = ns_ktkl.Fdt_NS_KTKL_QLKT_EXCEL(dtkt_Hi.Value.ToString(), tungay_tk.Text,
                denngay_tk.Text, tthai_Hi.Value.ToString(), phong_Hi.Value.ToString(), so_the_tk.Text,
                ten_tk.Text, b_nv);

            bang.P_THAY_GTRI(ref b_dt, "dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "TT", "Tập thể");
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_KTKL_QLKT, TEN_BANG.NS_KTKL_QLKT);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ktkl_qlkt.xlsx", b_dt, null, "Quan_ly_khen_thuong");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void xuat_excel_tt(DataTable b_dt)
    {
        try
        {
            //string b_nv = nghi_viec_tk.Text == "X" ? "1" : "0";
            //DataTable b_dt = ns_ktkl.Fdt_NS_KTKL_QLKT_EXCEL(dtkt_Hi.Value.ToString(), tungay_tk.Text,
            //    denngay_tk.Text, tthai_Hi.Value.ToString(), phong_Hi.Value.ToString(), so_the_tk.Text,
            //    ten_tk.Text, b_nv);
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "TT", "Tập thể");
            bang.P_SO_CNG(ref b_dt, "ngay_hl"); bang.P_SO_CNG(ref b_dt, "ngay_hhl");
            b_dt.TableName = "DATA";
            DataTable dtb = new DataTable(); DataSet dts = new DataSet();
            bang.P_THEM_COL(ref dtb, new string[] { "soqd", "ngay" }, "SS");
            //(Kèm theo Quyết định số:          / QĐ - CHG ngày         )
            string soqd = "(Kèm theo Quyết định số: " + b_dt.Rows[0]["soqd"].ToString() + " / QĐ - CHG ngày " + b_dt.Rows[0]["ngay_hl"].ToString() + ")";
            bang.P_THEM_HANG(ref dtb, new object[] {soqd, });
            dtb.TableName = "DATA1";
            dts.Tables.Add(b_dt); dts.Tables.Add(dtb); 
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/tt/ns_ktkl_qlkt_tt2.xls", dts, null, "Quan_ly_khen_thuong_tt");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_HTKT()
    {
        DataTable b_dt;
        b_dt = ns_ma.Fdt_NS_MA_HTKT_DR();
        se.P_TG_LUU(this.Title, "DT_HTKT", b_dt);
    }
}