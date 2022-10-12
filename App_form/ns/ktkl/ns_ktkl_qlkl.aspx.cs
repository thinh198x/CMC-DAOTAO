using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ktkl_qlkl : fmau
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
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ktkl/ns_ktkl_qlkl" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ktkl_qlkl_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
                P_HTKL();
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
         
        // Đối tượng khen thưởng kỷ luật
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DTKTKL");
        bang.P_XEP(ref b_dt, "ma");
        form.P_LIST_BANG(DTUONG, b_dt);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        form.P_LIST_BANG(dtkl_tk, b_dt);
        // Cấp khen thưởng kỷ luật
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("CKTKL");
        bang.P_XEP(ref b_dt, "ma");
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        form.P_LIST_BANG(CAP_KTKL, b_dt);
        //Năm trừ vào lương
        b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy());
    }
    protected void xuat_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nv = nghi_viec_tk.Text == "X" ? "1" : "0";
            DataTable b_dt = ns_ktkl.Fdt_NS_KTKL_QLKL_EXCEL(dtkl_Hi.Value.ToString(), tungay_tk.Text, denngay_tk.Text
                , tthai_Hi.Value.ToString(), phong_Hi.Value.ToString(), so_the_tk.Text, ten_tk.Text, b_nv);
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "TT", "Tập thể");
            bang.P_SO_CNG(ref b_dt, "ngay_hl");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_KTKL_QLKL, TEN_BANG.NS_KTKL_QLKL);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ktkl_qlkl.xlsx", b_dt, null, "Quan_ly_ky_luat");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_HTKL()
    {
        DataTable b_dt;
        b_dt = ns_ma.Fdt_NS_MA_HTKL_DR();
        se.P_TG_LUU(this.Title, "DT_HTKL", b_dt);
    }

    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            if (so_id.Value != "0")
            {
                DataSet b_ds = ns_ktkl.Fdt_NS_KTKL_QLKL_IN(so_id.Value);
                DataSet b_ds_kt = new DataSet();
                var b_dt = b_ds.Tables[0].Copy(); var b_dt_ct = b_ds.Tables[1].Copy();
                b_dt.TableName = "DATA"; b_dt_ct.TableName = "DATA1";
                string path = Server.MapPath("~");
                if (andtkl.Value == "CN") // Quyết định kỷ luật cá nhân
                {
                    path = path + @"Templates\ExportMau\ns\tt\ns_ktkl_qlkl_cn.docx";
                    b_ds_kt.Tables.Add(b_dt.Copy());
                }
                else if (andtkl.Value == "TT") // Quyết định kỷ luật tập thể
                {
                    //xuat_excel_tt(b_dt);
                    path = path + @"Templates\ExportMau\ns\tt\ns_ktkl_qlkl_tt.docx";
                    bang.P_BO_HANG(ref b_dt, 1, b_dt.Rows.Count);
                    b_ds_kt.Tables.Add(b_dt.Copy());
                }
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_KTKL_QLKL, TEN_BANG.NS_KTKL_QLKL);
                Word_dungchung.ExportMailMerge(path, "Quyet_Dinh_Ky_luat", b_ds_kt, Response);
            }
            else
            {
                form.P_LOI(this, "loi:Chọn 1 bản ghi để in:loi");
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File mẫu không tồn tại:loi"); }
    }
    protected void xuat_excel_tt(DataTable b_dt)
    {
        try
        {
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong", "TT", "Tập thể");
            bang.P_SO_CNG(ref b_dt, "ngay_hl"); bang.P_SO_CNG(ref b_dt, "ngay_hhl");
            b_dt.TableName = "DATA";
            DataTable dtb = new DataTable(); DataSet dts = new DataSet();
            bang.P_THEM_COL(ref dtb, new string[] { "soqd", "ngay" }, "SS");

            string soqd = "(Kèm theo Quyết định số: " + b_dt.Rows[0]["soqd"].ToString() + " / QĐ - CHG ngày " + b_dt.Rows[0]["ngay_hl"].ToString() + ")";
            bang.P_THEM_HANG(ref dtb, new object[] { soqd, });
            dtb.TableName = "DATA1";
            dts.Tables.Add(b_dt); dts.Tables.Add(dtb);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/tt/ns_ktkl_qlkl_tt2.xls", dts, null, "Quan_ly_ky_luat_tt"); 
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}