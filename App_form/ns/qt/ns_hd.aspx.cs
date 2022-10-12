using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hd : fmau
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
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_hd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hd_P_KD('" + khac.Fs_TMUCF(b_s) + "," + se.Fs_LOGIN() + "');", true);
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
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_LHD_TK", b_dt);
        // Thang lương
        b_dt = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0); se.P_TG_LUU(this.Title, "DT_MA_TL", b_dt);

        // lay danh sach phong
        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG_TK", b_dt);

        // lây ra tổng số hợp đồng chờ phê duyệt theo yêu cầu của vietlott
        DataTable b_dt_tong_hd_cpd = ns_qt.Fdt_NS_TONG_HD_CPD();
        tong_hd_cpd.Text = b_dt_tong_hd_cpd.Rows[0]["tong_hd"].ToString();

        DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
        if (b_tusinh != null && b_tusinh.Rows.Count > 0)
        {
            if (b_tusinh.Rows[0]["HOPDONG"].Equals("TS"))
            {
                SO_HD.ReadOnly = true;
                SO_HD.Enabled = false;
            }
        }
    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            if (so_id.Value != "0")
            {
                DataTable b_dt = ns_qt.Fdt_NS_HD_IN(so_id.Value);
                b_dt.TableName = "DATA";
                bang.P_THAY_GTRI(ref b_dt, "XUNGHO", "NAM", "Ông");
                bang.P_THAY_GTRI(ref b_dt, "XUNGHO", "NU", "Bà");

                bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,nsinh,ngay_ky");
                bang.P_SO_CSO(ref b_dt, "TIEN_LCB,TIEN,LUONGHT");
                DataSet b_ds_ep = new DataSet(); b_ds_ep.Tables.Add(b_dt.Copy());
                string path = Server.MapPath("~");
                string b_lhd = alhd.Value;
                string b_tenlhd = LHD.Text;
                DataTable b_dt_mau = ns_ma.Fdt_NS_BIEUMAU_HD(alhd.Value, NGAYD.Text);
                DataSet b_ds = new DataSet();
                b_ds.Tables.Add(b_dt);
                b_ds.Tables[0].TableName = "DATA";
                // ghi log
                hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.IN_WORD, TEN_FORM.NS_HD, TEN_BANG.NS_HD);

                if (b_dt_mau.Rows.Count > 0)
                {
                    string pathhd = Server.MapPath("~");
                    string b_ten = b_dt_mau.Rows[0]["TEN"].ToString();
                    Word_dungchung.ExportWord(pathhd + @"Templates\Bieu_mau_dong\" + b_lhd + @"\" + b_ten, "Hop_dong.docx", b_ds, "B", Response);

                }
                else
                {
                    path = Server.MapPath("~") + @"Templates\ExportMau\ns\tt\HD-Empty.doc";
                    Word_dungchung.ExportWord(path, "Hop_dong.doc", b_ds_ep, "B", Response);
                }
            }
            else
            {
                form.P_LOI(this, "loi:Chọn 1 bản ghi để in:loi");
            }
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File mẫu không tồn tại:loi"); }
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_qt.Fdt_NS_HD_LKE_ALL(alhd_tk.Value, ngayd_tk.Text, ngayc_tk.Text, atrangthai_tk.Value, so_the_tk.Text, ten_tk.Text, aphong_tk.Value, nghi_viec_tk.Text);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_THAY_GTRI(ref b_dt, "ttr", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ttr", "CPD", "Chưa phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_ky");
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ad,ngay_kt"); bang.P_SO_CSO(ref b_dt_ct, "sotien");
            b_dt_ct.TableName = "DATA_PC";

            DataSet b_ds_ex = new DataSet();
            b_ds_ex.Tables.Add(b_dt.Copy());
            b_ds_ex.Tables.Add(b_dt_ct.Copy());
             
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_HD, TEN_BANG.NS_HD);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_hd.xlsx", b_ds_ex, null, "Quan_ly_hop_dong");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    public string chuyen_So_Chu(double total)
    {
        try
        {
            string rs = "";
            total = Math.Round(total, 0);
            string[] ch = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] rch = { "lẻ", "mốt", "", "", "", "lăm" };
            string[] u = { "", "mươi", "trăm", "ngàn", "", "", "triệu", "", "", "tỷ", "", "", "ngàn", "", "", "triệu" };
            string nstr = total.ToString();
            int[] n = new int[nstr.Length];
            int len = n.Length;
            for (int i = 0; i < len; i++)
            {
                n[len - 1 - i] = Convert.ToInt32(nstr.Substring(i, 1));
            }
            for (int i = len - 1; i >= 0; i--)
            {
                if (i % 3 == 2)// số 0 ở hàng trăm
                {
                    if (n[i] == 0 && n[i - 1] == 0 && n[i - 2] == 0) continue;//nếu cả 3 số là 0 thì bỏ qua không đọc
                }
                else if (i % 3 == 1) // số ở hàng chục
                {
                    if (n[i] == 0)
                    {
                        if (n[i - 1] == 0) { continue; }// nếu hàng chục và hàng đơn vị đều là 0 thì bỏ qua.
                        else
                        {
                            rs += " " + rch[n[i]]; continue;// hàng chục là 0 thì bỏ qua, đọc số hàng đơn vị
                        }
                    }
                    if (n[i] == 1)//nếu số hàng chục là 1 thì đọc là mười
                    {
                        rs += " mười"; continue;
                    }
                }
                else if (i != len - 1)// số ở hàng đơn vị (không phải là số đầu tiên)
                {
                    if (n[i] == 0)// số hàng đơn vị là 0 thì chỉ đọc đơn vị
                    {
                        if (i + 2 <= len - 1 && n[i + 2] == 0 && n[i + 1] == 0) continue;
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                        continue;
                    }
                    if (n[i] == 1)// nếu là 1 thì tùy vào số hàng chục mà đọc: 0,1: một / còn lại: mốt
                    {
                        rs += " " + ((n[i + 1] == 1 || n[i + 1] == 0) ? ch[n[i]] : rch[n[i]]);
                        rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);
                        continue;
                    }
                    if (n[i] == 5) // cách đọc số 5
                    {
                        if (n[i + 1] != 0) //nếu số hàng chục khác 0 thì đọc số 5 là lăm
                        {
                            rs += " " + rch[n[i]];// đọc số 
                            rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
                            continue;
                        }
                    }
                }
                rs += (rs == "" ? " " : ", ") + ch[n[i]];// đọc số
                rs += " " + (i % 3 == 0 ? u[i] : u[i % 3]);// đọc đơn vị
            }
            if (rs[rs.Length - 1] != ' ')
                rs += " đồng.";
            else
                rs += "đồng.";
            if (rs.Length > 2)
            {
                string rs1 = rs.Substring(0, 2);
                rs1 = rs1.ToUpper();
                rs = rs.Substring(2);
                rs = rs1 + rs;
            }
            return rs.Trim().Replace("lẻ,", "lẻ").Replace("mươi,", "mươi").Replace("trăm,", "trăm").Replace("mười,", "mười");
        }
        catch
        {
            return "Số bạn nhập vào quá lớn";
        }
    }
    protected void export_excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = new DataSet();
            DataTable b_dt_lhd = ns_ma.Fdt_NS_MA_LHD_DR();
            DataTable b_dt_ngky = hts_dungchung.Fdt_NG_KY();
            DataTable b_dt_bangluong = ns_hdns.Fdt_HD_MA_HTTLUONG_DR();
            DataTable b_dt_ngachluong = ns_ma.Fdt_NS_MA_TL_NL("0");
            DataTable b_dt_bacluong = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL("0", "0");

            b_dt_lhd.TableName = "DATA1";
            b_dt_ngky.TableName = "DATA2";
            b_dt_bangluong.TableName = "DATA3";
            b_dt_ngachluong.TableName = "DATA4";
            b_dt_bacluong.TableName = "DATA5";
            b_ds.Tables.Add(b_dt_lhd);
            b_ds.Tables.Add(b_dt_ngky);
            b_ds.Tables.Add(b_dt_bangluong);
            b_ds.Tables.Add(b_dt_ngachluong);
            b_ds.Tables.Add(b_dt_bacluong);

            Excel_dungchung.ExportTemplate("Templates/importmau/ns_hd_xong.xls", b_ds, null, "ns_hd_excel" + DateTime.Now.Second);

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File import không tồn tại:loi"); }
    }
}