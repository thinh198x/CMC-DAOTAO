using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using Oracle.DataAccess.Client;

[System.Web.Script.Services.ScriptService]
public class sns_qt : System.Web.Services.WebService
{
    #region PHÊ DUYỆT GIẢI TRÌNH CHẤM CÔNG

    [WebMethod(true)]
    public string Fs_NS_GT_CC_PD_CT(string b_so_the, string b_ngayxn, string b_ngayd)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_GT_CC_PD_CT(b_so_the, b_ngayxn, b_ngayd);
            bang.P_SO_CNG(ref b_dt, "ngayxn,ngayd,ngayc");

            string b_hoten = "", b_ten_cdanh = "", b_phong = "", b_ly_do = "", b_tungay = "", b_toingay = "", b_ngaynghi = "", b_danghi = "", b_nghicon = "", b_noidung = "";
            string b_kq = "";
            if (b_dt.Rows.Count > 0)
            {

                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    b_hoten = b_dt.Rows[i]["ten"].ToString();
                    b_ten_cdanh = b_dt.Rows[i]["ten_cdanh"].ToString();
                    b_phong = b_dt.Rows[i]["phong"].ToString();
                    b_ly_do = b_dt.Rows[i]["ly_do"].ToString();
                    b_tungay = b_dt.Rows[i]["ngayd"].ToString();
                    b_toingay = b_dt.Rows[i]["ngayc"].ToString();
                    b_ngaynghi = b_dt.Rows[i]["ngaynghi"].ToString();
                    b_danghi = b_dt.Rows[i]["danghi"].ToString();
                    b_nghicon = b_dt.Rows[i]["nghicon"].ToString();
                    b_noidung = b_dt.Rows[i]["noidung"].ToString();

                    b_kq = "\n\b(*) Name: " + b_hoten + "\n\b  - Position: " + b_ten_cdanh + "\n\b  - Department: " + b_phong;
                    b_kq = b_kq + "\n\b  - Reason: " + b_ly_do + "\n\b  - From date: " + b_tungay + " - To date: " + b_toingay;
                    b_kq = b_kq + "\n\b  - Total days of leave: " + b_ngaynghi;
                    b_kq = b_kq + "\n\b  - AL taken days: " + b_danghi + " - Balance AL days: " + b_nghicon;
                    b_kq = b_kq + "\n\b  - Content: " + b_noidung;
                }
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_GT_CC_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_GT_CC_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "NGAY_GT");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_GT_CC_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = ns_qt.Fdt_NS_GT_CC_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_GT_CC_PD, TEN_BANG.NS_GT_CC_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_GT_CC_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "GTCC" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = ns_qt.Fdt_NS_GT_CC_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_GT_CC_PD, TEN_BANG.NS_GT_CC_PD);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    #endregion PHÊ DUYỆT NGHỈ PHÉP

    #region QUẢN LÝ ĐIỀU CHUYỂN GIỮA CÁC CÔNG TY THÀNH VIÊN
    [WebMethod(true)]
    public string Fs_MA_CDANH_BY_PHONG_CP(string b_form, string b_congty, string b_phong)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_MA_CDANH_BY_PHONG_CP(b_congty, b_phong);
            if (b_dt.Rows.Count == 0) se.P_TG_LUU(b_form, "DT_CDANH", null);
            else se.P_TG_LUU(b_form, "DT_CDANH", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_NH(string b_login, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_ngayd, string b_ngayc, string b_tt, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "luong_cb,thunhap_thang");
            bang.P_CNG_SO(ref b_dt, "ngayd,ngayc,ngay_ky");
            b_so_id = ns_qt.P_NS_CP_NH(ref b_so_id, b_dt);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CP, TEN_BANG.NS_CP);
            return Fs_NS_CP_MA(b_login, b_so_id, b_so_the, b_ten, b_phong, b_ngayd, b_ngayc, b_tt, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_MA(string b_login, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_ngayd, string b_ngayc, string b_tt, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Faobj_NS_CP_MA(b_so_id, b_so_the, b_ten, b_phong, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_tt, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_ky");
            bang.P_SO_CSO(ref b_dt, "luong_cb,thunhap_thang");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "PKD", "Không phê duyệt");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_LKE(string b_login, string b_so_the, string b_ten, string b_phong, string b_ngayd, string b_ngayc, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_qt.Faobj_NS_CP_LKE(b_so_the, b_ten, b_phong, chuyen.CNG_SO(b_ngayd), chuyen.CNG_SO(b_ngayc), b_tt, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngayd");
            bang.P_COPY_COL(ref b_dt_ct, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt_ct, "TEN_TT", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_ct, "TEN_TT", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_ct, "TEN_TT", "PKD", "Không phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_CT(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); DataTable b_dt = ns_qt.Fdt_NS_CP_CT(b_so_id);
            var b_dvi = b_dt.Rows[0]["CONG_TY"].ToString();
            var b_phong = b_dt.Rows[0]["phong"].ToString();
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_ky");
            bang.P_SO_CSO(ref b_dt, "luong_cb,thunhap_thang");
            bang.P_TIM_THEM(ref b_dt, "ns_cp", "DT_CTY", "CONG_TY");

            DataTable b_dt_phong = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_dvi, 2);
            se.P_TG_LUU("ns_cp", "DT_PHONG", b_dt_phong.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_cp", "DT_PHONG", "PHONG");
            //bang.P_BANG_GHEP(ref b_dt, "cdanh,ten_cdanh", "{");

            DataTable b_dt_cdanh = ns_qt.Fdt_MA_CDANH_BY_PHONG_CP(b_dvi, b_phong);
            se.P_TG_LUU("ns_cp", "DT_CDANH", b_dt_cdanh.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_cp", "DT_CDANH", "CDANH");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_XOA(string b_login, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_ngayd, string b_ngayc, string b_tt, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_qt.P_NS_CP_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CP, TEN_BANG.NS_CP);
            return Fs_NS_CP_LKE(b_login, b_so_the, b_ten, b_phong, b_ngayd, b_ngayc, b_tt, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #endregion QUẢN LÝ ĐIỀU CHUYỂN GIỮA CÁC CÔNG TY THÀNH VIÊN

    #region GIA CẢNH
    [WebMethod(true)]
    public string Fs_NS_SGC_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_SGC_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_SGC_NH(string b_so_the, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_NS_SGC_NH(b_so_the, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion GIA CẢNH

    #region PHỤ CẤP
    [WebMethod(true)]
    public string Fs_NS_PCAP_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_PCAP_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_CT(string b_so_the, string b_ngayd, string b_dk, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_PCAP_CT(b_so_the, b_ngayd);
            return bang.Fb_TRANG(b_dt) ? "" : b_dk + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_PCAP_NH(string b_so_the, string b_ngayd, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_NS_PCAP_NH(b_so_the, b_ngayd, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion PHỤ CẤP

    #region HỆ SỐ DOANH THU
    [WebMethod(true)]
    public string Fs_NS_HSDT_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HSDT_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HSDT_NH(string b_so_the, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_NS_HSDT_NH(b_so_the, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion HỆ SỐ DOANH THU

    #region THU BẢO HIỂM
    [WebMethod(true)]
    public string Fs_NS_TBH_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_TBH_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TBH_NH(string b_so_the, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_NS_TBH_NH(b_so_the, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion THU BẢO HIỂM

    #region SỐ NGÀY CƯ TRÚ
    [WebMethod(true)]
    public string Fs_NS_SCT_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_SCT_LKE(b_so_the);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_SCT_NH(string b_so_the, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_NS_SCT_NH(b_so_the, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion SỐ NGÀY CƯ TRÚ

    #region HỢP ĐỒNG
    [WebMethod(true)]
    public string Fs_NS_HD_MO_CHOPD(string b_login, string b_so_id, string b_so_the, string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_nghi_viec_tk, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_qt.P_NS_HD_MO_CHOPD(b_so_id, b_so_the);
            return Fs_NS_HD_LKE(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the_tk, b_ten_tk, b_phong_tk, b_nghi_viec_tk, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    /// <summary>
    /// lay he so phu cap
    /// </summary>
    [WebMethod(true)]
    public string Fs_NS_MA_CVU_HOI(string b_ma)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_MA_CVU_HOI(b_ma);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_THONGTIN_DONGIA(string b_so_the, string b_ngayd)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_THONGTIN_DONGIA(b_so_the, b_ngayd);
            if (b_dt.Rows.Count > 0)
            {
                bang.P_SO_CSO(ref b_dt, "DONGIA");
                return b_dt.Rows[0]["DONGIA"].ToString();
            }
            else
                return "0";

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HD_LKE(string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string[] a_cot, double[] a_tso)
    {
        try
        {
            object[] a_obj = ns_qt.Fdt_NS_HD_LKE(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_phong, b_nghi_viec, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "ten_ttr", "ttr"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "CPD", "Chờ phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "PD", "Phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "KPD", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_TT_LKE(string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_tungay, string b_denngay, string[] a_cot, double[] a_tso)
    {
        try
        {
            object[] a_obj = ns_qt.Fdt_NS_HD_TT_LKE(b_so_the, b_ten, b_phong, b_nghi_viec, b_tungay, b_denngay, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_CT(string b_form, string b_login, string b_so_id, string[] a_cot_pc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fdt_NS_HD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0], b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngay_ky,ngayd,ngayc,ngay_tl");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ad,ngay_kt"); bang.P_SO_CSO(ref b_dt_ct, "sotien");
            // lấy ngạch lương theo thang lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "")
            {
                DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
                if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            }
            // lấy bậc lương theo ngạch lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
            {
                DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
                if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_BL", b_dt_bl.Copy());
            }
            // lấy tỷ lệ hoa hồng theo ngày bắt đầu
            if (b_dt.Rows[0]["ngayd"].ToString() != "")
            {
                DataTable b_dt_tl_hh = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_dt.Rows[0]["ngayd"].ToString());
                if (b_dt_tl_hh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl_hh, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_CHIPHI", b_dt_tl_hh.Copy());
            }

            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LHD", "LHD");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_BL", "MA_BL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CDANH", "CDANH_M");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CHIPHI", "TYLE_HOAHONG_THEOPHI");
            return bang.Fb_TRANG(b_dt) ? "" : "" + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_dt_ct.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_pc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CHITIET_HD_CT(string b_form, string b_login, string b_so_the)
    {
        try
        {

            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CHITIET_HD_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngayd");
            if (b_dt.Rows.Count <= 0) return "";
            // lấy ngạch lương theo thang lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "")
            {
                DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
                if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            }
            // lấy bậc lương theo ngạch lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
            {
                DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
                if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_BL", b_dt_bl.Copy());
            } 
            // lấy tỷ lệ hoa hồng theo ngày bắt đầu
            if (b_dt.Rows[0]["ngayd"].ToString() != "")
            {
                DataTable b_dt_tl_hh = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_dt.Rows[0]["ngayd"].ToString());
                if (b_dt_tl_hh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl_hh, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_CHIPHI", b_dt_tl_hh.Copy());
            }

            //bang.P_TIM_THEM(ref b_dt, b_form, "DT_LHD", "LHD");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_BL", "MA_BL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CHIPHI", "TYLE_HOAHONG_THEOPHI");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HD_MA(string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_obj = ns_qt.Faobj_NS_HD_MA(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            bang.P_COPY_COL(ref b_dt, "ten_ttr", "ttr"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "CPD", "Chờ phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "PD", "Phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "KPD", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_NH(string b_so_id, object[] a_dt, object[] a_dt_ct, string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten,
                                string b_phong, string b_nghi_viec, double b_trang, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc");

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_BO_HANG(ref b_dt_ct, "ma_pc", "");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["ngay_ad"].ToString())) return "loi:Chưa nhập ngày áp dụng :loi";
                else
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_ct.Rows[i]["ngay_ad"].ToString(), ref _error))
                        {
                            return "loi:Ngày áp dụng " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày áp dụng không đúng định dạng:loi"; }
                }
                if (!string.IsNullOrEmpty(b_dt_ct.Rows[i]["ngay_kt"].ToString()))
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_ct.Rows[i]["ngay_kt"].ToString(), ref _error))
                        {
                            return "loi:Ngày kết thúc " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày kết thúc không đúng định dạng:loi"; }
                }
            }
            if (b_dt_ct.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "0", "0", "X" });
            bang.P_CSO_SO(ref b_dt_ct, "sotien");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ad,ngay_kt");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (double.Parse(b_dt_ct.Rows[i]["ngay_ad"].ToString()) > double.Parse(b_dt_ct.Rows[i]["ngay_kt"].ToString()))
                {
                    return "loi:Ngày áp dụng không được lớn hơn ngày kết thúc của phụ cấp " + b_dt_ct.Rows[i]["ten"].ToString() + ":loi";
                }
            }
            // doi voi nut nhap thi luon de ban ghi la cho phe duyet
            bang.P_DAT_GTRI(ref b_dt, "TTR", "CPD");
            ns_qt.P_NS_HD_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HD, TEN_BANG.NS_HD);
            return Fs_NS_HD_MA(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_id, b_trang, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_HD_PD(string b_so_id, object[] a_dt, object[] a_dt_ct, string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten,
                                string b_phong, string b_nghi_viec, double b_trang, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc");

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_BO_HANG(ref b_dt_ct, "ma_pc", "");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["ngay_ad"].ToString())) return "loi:Chưa nhập ngày áp dụng :loi";
                else
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_ct.Rows[i]["ngay_ad"].ToString(), ref _error))
                        {
                            return "loi:Ngày áp dụng " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày áp dụng không đúng định dạng:loi"; }
                }
                if (!string.IsNullOrEmpty(b_dt_ct.Rows[i]["ngay_kt"].ToString()))
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_ct.Rows[i]["ngay_kt"].ToString(), ref _error))
                        {
                            return "loi:Ngày kết thúc " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày kết thúc không đúng định dạng:loi"; }
                }
            }
            if (b_dt_ct.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "", "", "", "0", "0", "X" });
            bang.P_CSO_SO(ref b_dt_ct, "sotien");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_ad,ngay_kt");
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (double.Parse(b_dt_ct.Rows[i]["ngay_ad"].ToString()) > double.Parse(b_dt_ct.Rows[i]["ngay_kt"].ToString()))
                {
                    return "loi:Ngày áp dụng không được lớn hơn ngày kết thúc của phụ cấp " + b_dt_ct.Rows[i]["ten"].ToString() + ":loi";
                }
            }
            // nut phe duyet thi update ban ghi thanh phe duyet
            bang.P_DAT_GTRI(ref b_dt, "TTR", "PD");
            ns_qt.P_NS_HD_PD(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_HD, TEN_BANG.NS_HD);
            return Fs_NS_HD_MA(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_id, b_trang, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }


    [WebMethod(true)]
    public string Fs_NS_HD_XOA(string b_so_id, string b_lhd, string b_ngayd, string b_ngayc, string b_trangthai, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string[] a_cot, double[] a_tso)
    {
        try
        {
            ns_qt.P_NS_HD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HD, TEN_BANG.NS_HD);
            return Fs_NS_HD_LKE(b_lhd, b_ngayd, b_ngayc, b_trangthai, b_so_the, b_ten, b_phong, b_nghi_viec, a_cot, a_tso);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_QD(string b_so_id)
    {
        var b_dt = ns_qt.Fdt_NS_THONGTIN_QD(b_so_id);
        // lấy ngạch lương theo thang lương
        if (b_dt.Rows[0]["ma_tl"].ToString() != "")
        {
            DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
            if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
            se.P_TG_LUU("ns_hd", "DT_MA_NL", b_dt_nl.Copy());
        }
        // lấy bậc lương theo ngạch lương
        if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
        {
            DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
            if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
            se.P_TG_LUU("ns_hd", "DT_MA_BL", b_dt_bl.Copy());
        }
        bang.P_TIM_THEM(ref b_dt, "ns_hd", "DT_MA_TL", "MA_TL");
        bang.P_TIM_THEM(ref b_dt, "ns_hd", "DT_MA_NL", "MA_NL");
        bang.P_TIM_THEM(ref b_dt, "ns_hd", "DT_MA_BL", "MA_BL");

        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_QD_BYMA(string b_ma)
    {
        var b_dt = ns_qt.Fdt_NS_THONGTIN_QD_BYMA(b_ma);
        // lấy ngạch lương theo thang lương
        if (b_dt.Rows[0]["ma_tl"].ToString() != "")
        {
            DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
            if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
            se.P_TG_LUU("ns_hd", "DT_MA_NL", b_dt_nl.Copy());
        }
        // lấy bậc lương theo ngạch lương
        if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
        {
            DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
            if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
            se.P_TG_LUU("ns_hd", "DT_MA_BL", b_dt_bl.Copy());
        }
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public double Fs_NS_HD_BYDATE(double so_id, string b_so_the, string b_ngayd, string b_ngayc)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HD_BYDATE(so_id, b_so_the, b_ngayd, b_ngayc);
            double kq = double.Parse(b_dt.Rows[0]["TOTAL"].ToString());
            return kq;
        }
        catch (Exception ex) { return 0; }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_TL(string b_so_id, string b_ngay_tl)
    {
        try
        {
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("ngay_tl");
            DataRow row = b_dt.NewRow();
            row["ngay_tl"] = b_ngay_tl;
            b_dt.Rows.Add(row);
            bang.P_CNG_SO(ref b_dt, "ngay_tl");
            ns_qt.P_NS_HD_TL(ref b_so_id, b_dt); return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region PHỤ LỤC HỢP ĐỒNG
    [WebMethod(true)]
    public string Fs_NS_HD_PL_LKE(string b_form, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_so_hd, string[] a_cot, double[] a_tso)
    {
        try
        {
            object[] a_obj = ns_qt.Fdt_NS_HD_PL_LKE(b_so_the, b_ten, b_phong, b_nghi_viec, b_so_hd, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LHD", "lhd");
            bang.P_COPY_COL(ref b_dt, "ten_ttr", "ttr"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "CPD", "Chờ phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "PD", "Phê duyệt"); bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "KPD", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_CT_BY_SOHD(string b_form, string b_so_hd, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_qt.Fdt_NS_HD_CT_BY_SOHD(b_so_hd);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt_ct = b_ds.Tables[1];

            // lấy ngạch lương theo thang lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "")
            {
                DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
                if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            }
            // lấy bậc lương theo ngạch lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
            {
                DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
                if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_BL", b_dt_bl.Copy());
            } 
            // lấy tỷ lệ hoa hồng theo ngày bắt đầu
            if (b_dt.Rows[0]["ngayd"].ToString() != "")
            {
                DataTable b_dt_tl_hh = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_dt.Rows[0]["ngayd"].ToString());
                if (b_dt_tl_hh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl_hh, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_CHIPHI", b_dt_tl_hh.Copy());
            }
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LHD", "lhd");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_BL", "MA_BL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CDANH", "CDANH_M");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CHIPHI", "TYLE_HOAHONG_THEOPHI");
            bang.P_SO_CNG(ref b_dt, "ngay_ky,ngayd,ngayc");
            bang.P_SO_CNG(ref b_dt_ct, "ngay_ad,ngay_kt"); bang.P_SO_CSO(ref b_dt_ct, "sotien");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_dt_ct.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_PL_NH(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc");

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_CNG_SO(ref b_dt_ct, "ngay_ad,ngay_kt"); bang.P_CSO_SO(ref b_dt_ct, "sotien");
            ns_qt.P_NS_HD_PL_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HD_PL, TEN_BANG.NS_HD_PL);
            return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_PL_PD(string b_so_id, object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt, "ngay_ky,ngayd,ngayc");

            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);

            bang.P_CNG_SO(ref b_dt_ct, "ngay_ad,ngay_kt"); bang.P_CSO_SO(ref b_dt_ct, "sotien");
            ns_qt.P_NS_HD_PL_PD(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HD_PL, TEN_BANG.NS_HD_PL);
            return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_QL_CT(string b_form, string b_so_id, string[] a_cot_ct)
    {
        try
        {
            DataSet b_ds = ns_qt.Fdt_NS_HD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0], b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CSO(ref b_dt_ct, "sotien"); bang.P_SO_CNG(ref b_dt_ct, "ngay_ad,ngay_kt");
            // lấy ngạch lương theo thang lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "")
            {
                DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
                if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            }
            // lấy bậc lương theo ngạch lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
            {
                DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
                if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_BL", b_dt_bl.Copy());
            }
            // lấy tỷ lệ hoa hồng theo ngày bắt đầu
            if (b_dt.Rows[0]["ngayd"].ToString() != "")
            {
                DataTable b_dt_tl_hh = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_dt.Rows[0]["ngayd"].ToString());
                if (b_dt_tl_hh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl_hh, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_CHIPHI", b_dt_tl_hh.Copy());
            }
            bang.P_SO_CNG(ref b_dt, "ngay_ky,ngayd,ngayc,ngay_tl");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_LHD", "lhd");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_BL", "MA_BL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CDANH", "CDANH_M");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CHIPHI", "TYLE_HOAHONG_THEOPHI");
            return bang.Fb_TRANG(b_dt) ? "" : "" + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_dt_ct.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_PL_XOA(string b_form, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_so_hd, string[] a_cot, double[] a_tso)
    {
        try
        {
            ns_qt.P_NS_HD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HD_PL, TEN_BANG.NS_HD_PL);
            return Fs_NS_HD_PL_LKE(b_form, b_so_the, b_ten, b_phong, b_nghi_viec, b_so_hd, a_cot, a_tso);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region HỢP ĐỒNG QUẢN LÝ CÔNG VIỆC
    /// <summary>
    /// lay he so phu cap
    /// </summary> 
    [WebMethod(true)]
    public string Fs_NS_HD_QLCV_LKE(string b_so_the, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HD_QLCV_LKE(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_tl");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_QLCV_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HD_QLCV_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay_ky,ngayd,ngayc");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_QLCV_NH(string b_so_id, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay_ky,ngayd,ngayc");
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            ns_qt.P_NS_HD_QLCV_NH(ref b_so_id, b_dt_ct); return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_HD_QLCV_XOA(string b_so_id)
    {
        try
        {
            ns_qt.P_NS_HD_QLCV_XOA(b_so_id);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public double Fs_NS_HD_QLCV_BYDATE(double so_id, string b_so_the, string b_ngayd, string b_ngayc)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_HD_QLCV_BYDATE(so_id, b_so_the, b_ngayd, b_ngayc);
            double kq = double.Parse(b_dt.Rows[0]["TOTAL"].ToString());
            return kq;
        }
        catch (Exception ex) { return 0; }
    }

    [WebMethod(true)]
    public string Fs_NS_HD_QLCV_TL(string b_so_id, string b_ngay_tl)
    {
        try
        {
            DataTable b_dt = new DataTable();
            b_dt.Columns.Add("ngay_tl");
            DataRow row = b_dt.NewRow();
            row["ngay_tl"] = b_ngay_tl;
            b_dt.Rows.Add(row);
            bang.P_CNG_SO(ref b_dt, "ngay_tl");
            ns_qt.P_NS_HD_QLCV_TL(ref b_so_id, b_dt); return b_so_id;
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region QUÁ TRÌNH LÀM VIỆC
    [WebMethod(true)]
    public string Fs_NS_HDCT_CB(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_kq = "";
            DataTable b_dt = ns_qt.Fdt_NS_HDCT_CB(b_so_the, b_ngayd);

            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,dongia_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong,dongia");
            if (b_dt.Rows.Count > 0)
            {
                b_kq = b_dt.Rows[0]["ma_tl"].ToString() + "#" + b_dt.Rows[0]["ma_nl"].ToString() + "#" + b_dt.Rows[0]["ma_bl"].ToString() + "#" + b_dt.Rows[0]["luongcb"].ToString()
                       + "#" + b_dt.Rows[0]["thunhapthang"].ToString() + "#" + b_dt.Rows[0]["thuong_ketqua"].ToString() + "#" + b_dt.Rows[0]["pt_huongluong"].ToString()
                       + "#" + b_dt.Rows[0]["ten_tl"].ToString() + "#" + b_dt.Rows[0]["ten_nl"].ToString() + "#" + b_dt.Rows[0]["ten_bl"].ToString() + "#" + b_dt.Rows[0]["ngayd"].ToString()
                       + "#" + b_dt.Rows[0]["dongia"].ToString() + "#" + b_dt.Rows[0]["tyle_hoahong"].ToString() + "#" + b_dt.Rows[0]["tyle_hoahong_theophi"].ToString();
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_HTCTAC_CT(string b_login, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_MA_HTCTAC_CT(b_ma);
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_LKE(string b_login, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Fdt_NS_HDCT_LKE(b_so_the, b_ten, b_phong, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "KPD", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_TT_LKE(string b_login, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_tungay, string b_denngay, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Fdt_NS_HDCT_TT_LKE(b_so_the, b_ten, b_phong, b_nghi_viec, b_tungay, b_denngay, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luong,luongcb,luonght");
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_CT(string b_form, string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fdt_NS_HDCT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_pc = (DataTable)b_ds.Tables[1];

            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,dongia_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong,dongia");
            bang.P_SO_CSO(ref b_dt_pc, "sotien"); bang.P_SO_CNG(ref b_dt_pc, "ngay_ad,ngay_kt");

            // lấy chức danh theo phòng ban
            if (b_dt.Rows[0]["phong"].ToString() != "")
            {
                DataTable b_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_dt.Rows[0]["phong"].ToString());
                if (b_cdanh.Rows.Count == 0) bang.P_THEM_HANG(ref b_cdanh, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_CDANH", b_cdanh.Copy());
            }
            // lấy ngạch lương theo thang lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "")
            {
                DataTable b_dt_nl = ns_ma.Fdt_NS_MA_TL_NL(b_dt.Rows[0]["ma_tl"].ToString());
                if (b_dt_nl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_nl, new object[] { "", "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_NL", b_dt_nl.Copy());
            }
            // lấy bậc lương theo ngạch lương
            if (b_dt.Rows[0]["ma_tl"].ToString() != "" && b_dt.Rows[0]["ma_nl"].ToString() != "")
            {
                DataTable b_dt_bl = ns_ma.Fdt_NS_HDNS_MA_BL_BYTLNL(b_dt.Rows[0]["ma_tl"].ToString(), b_dt.Rows[0]["ma_nl"].ToString());
                if (b_dt_bl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_bl, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_MA_BL", b_dt_bl.Copy());
            }
            // lấy tỷ lệ hoa hồng theo ngày bắt đầu
            if (b_dt.Rows[0]["ngayd"].ToString() != "")
            {
                DataTable b_dt_tl_hh = tl_ma.Fdt_NS_TL_TLAP_TYLE_HOAHONG_DR(b_dt.Rows[0]["ngayd"].ToString());
                if (b_dt_tl_hh.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl_hh, new object[] { 0, "" }, 0);
                se.P_TG_LUU(b_form, "DT_CHIPHI", b_dt_tl_hh.Copy());
            }

            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CDANH", "CDANH_M");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_PHONG", "PHONG_M");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_HINHTHUC", "HINHTHUC");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_TL", "MA_TL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_NL", "MA_NL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_MA_BL", "MA_BL");
            bang.P_TIM_THEM(ref b_dt, b_form, "DT_CHIPHI", "TYLE_HOAHONG_THEOPHI");


            return bang.Fb_TRANG(b_dt) ? "" : "" + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_pc, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_TT_CT(string b_form, string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fdt_NS_HDCT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_dt.Rows[0]["phong"].ToString());
            if (b_cdanh.Rows.Count == 0) bang.P_THEM_HANG(ref b_cdanh, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_CDANH", b_cdanh.Copy());

            bang.P_TIM_THEM(ref b_dt, "ns_hdct_tt", "DT_CDANH", "CDANH");

            DataTable b_dt_pc = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luong,luongcb,luonght");
            bang.P_SO_CSO(ref b_dt_pc, "sotien"); bang.P_SO_CNG(ref b_dt_pc, "ngay_ad,ngay_kt");
            bang.P_TIM_THEM(ref b_dt, "ns_hdct_tt", "DT_PHONG", "PHONG");
            bang.P_TIM_THEM(ref b_dt, "ns_hdct_tt", "DT_HINHTHUC", "HINHTHUC");
            return bang.Fb_TRANG(b_dt) ? "" : "" + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_pc, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_QL_CT(string b_form, string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fdt_NS_HDCT_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_cdanh = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_dt.Rows[0]["phong"].ToString());
            if (b_cdanh.Rows.Count == 0) bang.P_THEM_HANG(ref b_cdanh, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_CDANH", b_cdanh.Copy());
            bang.P_TIM_THEM(ref b_dt, "ns_hdct_ql", "DT_CDANH", "CDANH");

            DataTable b_dt_pc = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_qd");
            bang.P_SO_CSO(ref b_dt, "luong,luongcb,luonght");
            bang.P_SO_CSO(ref b_dt_pc, "sotien"); bang.P_SO_CNG(ref b_dt_pc, "ngay_ad,ngay_kt");
            bang.P_TIM_THEM(ref b_dt, "ns_hdct_ql", "DT_PHONG", "PHONG");
            bang.P_TIM_THEM(ref b_dt, "ns_hdct_ql", "DT_HINHTHUC", "HINHTHUC");
            return bang.Fb_TRANG(b_dt) ? "" : "" + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + bang.Fs_BANG_CH(b_dt_pc, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_MO_CHOPD(string b_login, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_qt.P_NS_HDCT_MO_CHOPD(b_so_id);
            return Fs_NS_HDCT_LKE(b_login, b_so_the, b_ten, b_phong, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_MA(string b_login, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Faobj_NS_HDCT_MA(b_so_the, b_ten, b_phong, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_COPY_COL(ref b_dt, "TEN_TT", "TT");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "CPD", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "PD", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TEN_TT", "KPD", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_NH(string b_login, string b_so_the, string b_ten, string b_phong, string b_nv, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string b_so_id, double b_trang, object[] a_dt_ct, object[] a_dt_pc, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_pc[0]); object[] a_gtri_pc = (object[])a_dt_pc[1];
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc); bang.P_BO_HANG(ref b_dt_pc, "ma_pc", "");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_ad"].ToString())) return "loi:Chưa nhập ngày áp dụng :loi";
                else
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_ad"].ToString(), ref _error))
                        {
                            return "loi:Ngày áp dụng " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày áp dụng không đúng định dạng:loi"; }
                }
                if (!string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_kt"].ToString(), ref _error))
                        {
                            return "loi:Ngày kết thúc " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày kết thúc không đúng định dạng:loi"; }
                }
            }
            if (b_dt_pc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_pc, new object[] { "", "", "", "0", "0", "X" });
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_CSO_SO(ref b_dt_ct, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong");
            bang.P_CSO_SO(ref b_dt_pc, "sotien");
            bang.P_CNG_SO(ref b_dt_pc, "ngay_ad,ngay_kt");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (double.Parse(b_dt_pc.Rows[i]["ngay_ad"].ToString()) > double.Parse(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    return "loi:Ngày áp dụng không được lớn hơn ngày kết thúc của phụ cấp " + b_dt_pc.Rows[i]["ten"].ToString() + ":loi";
                }
            }
            // doi voi nut nhap thi luon de ban ghi la cho phe duyet
            bang.P_DAT_GTRI(ref b_dt_ct, "TT", "CPD");
            ns_qt.P_NS_HDCT_NH(ref b_so_id, b_dt_ct, b_dt_pc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
            return Fs_NS_HDCT_MA(b_login, b_so_the, b_ten, b_phong, b_nv, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_trang, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_PD(string b_login, string b_so_the, string b_ten, string b_phong, string b_nv, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string b_so_id, double b_trang, object[] a_dt_ct, object[] a_dt_pc, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_pc[0]); object[] a_gtri_pc = (object[])a_dt_pc[1];
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc); bang.P_BO_HANG(ref b_dt_pc, "ma_pc", "");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_ad"].ToString())) return "loi:Chưa nhập ngày áp dụng :loi";
                else
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_ad"].ToString(), ref _error))
                        {
                            return "loi:Ngày áp dụng " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày áp dụng không đúng định dạng:loi"; }
                }
                if (!string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_kt"].ToString(), ref _error))
                        {
                            return "loi:Ngày kết thúc " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày kết thúc không đúng định dạng:loi"; }
                }
            }
            if (b_dt_pc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_pc, new object[] { "", "", "", "0", "0", "X" });
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_CSO_SO(ref b_dt_ct, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong");
            bang.P_CSO_SO(ref b_dt_pc, "sotien");
            bang.P_CNG_SO(ref b_dt_pc, "ngay_ad,ngay_kt");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (double.Parse(b_dt_pc.Rows[i]["ngay_ad"].ToString()) > double.Parse(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    return "loi:Ngày áp dụng không được lớn hơn ngày kết thúc của phụ cấp " + b_dt_pc.Rows[i]["ten"].ToString() + ":loi";
                }
            }
            // nut phe duyet thi update ban ghi thanh phe duyet
            bang.P_DAT_GTRI(ref b_dt_ct, "TT", "PD");
            ns_qt.P_NS_HDCT_PD(ref b_so_id, b_dt_ct, b_dt_pc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
            return Fs_NS_HDCT_MA(b_login, b_so_the, b_ten, b_phong, b_nv, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_trang, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_CAT_PC(string b_login, string b_so_the, string b_ten, string b_phong, string b_nv, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string b_so_id, double b_trang, object[] a_dt_ct, object[] a_dt_pc, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_pc = chuyen.Fas_OBJ_STR((object[])a_dt_pc[0]); object[] a_gtri_pc = (object[])a_dt_pc[1];
            DataTable b_dt_pc = bang.Fdt_TAO_THEM(a_cot_pc, a_gtri_pc); bang.P_BO_HANG(ref b_dt_pc, "ma_pc", "");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_ad"].ToString())) return "loi:Chưa nhập ngày áp dụng :loi";
                else
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_ad"].ToString(), ref _error))
                        {
                            return "loi:Ngày áp dụng " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày áp dụng không đúng định dạng:loi"; }
                }
                if (!string.IsNullOrEmpty(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    try
                    {
                        string _error = "";
                        if (!KiemTra.ValidateDate(b_dt_pc.Rows[i]["ngay_kt"].ToString(), ref _error))
                        {
                            return "loi:Ngày kết thúc " + _error + ":loi";
                        }
                    }
                    catch { return "loi:Ngày kết thúc không đúng định dạng:loi"; }
                }
            }
            if (b_dt_pc.Rows.Count <= 0) bang.P_THEM_HANG(ref b_dt_pc, new object[] { "", "", "", "0", "0", "X" });
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc,ngay_bn_landau,ngay_bn_gannhat,ngay_qd");
            bang.P_CSO_SO(ref b_dt_ct, "luongcb_c,thunhapthang_c,thuong_ketqua_c,pt_huongluong_c,luongcb,thunhapthang,thuong_ketqua,pt_huongluong");

            bang.P_CNG_SO(ref b_dt_pc, "ngay_ad,ngay_kt");
            for (int i = 0; i < b_dt_pc.Rows.Count; i++)
            {
                if (double.Parse(b_dt_pc.Rows[i]["ngay_ad"].ToString()) > double.Parse(b_dt_pc.Rows[i]["ngay_kt"].ToString()))
                {
                    return "loi:Ngày áp dụng không được lớn hơn ngày kết thúc của phụ cấp " + b_dt_pc.Rows[i]["ten"].ToString() + ":loi";
                }
            }
            ns_qt.P_NS_HDCT_CAT_PC(ref b_so_id, b_dt_ct, b_dt_pc);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
            return Fs_NS_HDCT_MA(b_login, b_so_the, b_ten, b_phong, b_nv, b_loaiqd, b_tungay, b_denngay, b_trangthai, b_so_id, b_trang, a_cot_lke);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_BNNGHE_LKE_NNN(string b_login, string b_mannn)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_hdns.Fdt_HD_MA_BNNGHE_LKE_ALL(b_mannn);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma_nngiep", "cap_bac" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDCT_CHUYEN_MON_LKE_NN(string b_login, string b_mann)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_HD_MA_CMON_LKE_ALL(b_mann);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDCT_MA_NL_LKE_TL(string b_login, string b_ma_tl)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_NL_LKE_ALL_TL(b_ma_tl);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDCT_MA_BL_LKE_NL(string b_login, string b_ma_nl)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_BL_LKE_ALL_NL(b_ma_nl);
            return bang.Fs_BANG_CH(b_dt, new string[] { "so_id", "bacluong" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_BL_LUONG_CT(string b_login, string b_ma_bl)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ma.Fdt_NS_MA_BL_LUONG_CT(b_ma_bl);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0, "tien,tien_lcb,tienbh,tien_tdg");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_HDCT_XOA(string b_login, string b_so_id, string b_so_the, string b_ten, string b_phong, string b_nghi_viec, string b_loaiqd, string b_tungay, string b_denngay, string b_trangthai, string[] a_cot, double[] a_tso)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); ns_qt.P_NS_HDCT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_HDCT, TEN_BANG.NS_HDCT);
            return Fs_NS_HDCT_LKE(b_login, b_so_the, b_ten, b_phong, b_nghi_viec, b_loaiqd, b_tungay, b_denngay, b_trangthai, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_HDCT_SO_QD(string b_login, string b_ngayd, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (string.IsNullOrEmpty(b_ngayd))
            {
                return "";
            }
            string b_so_qd = "";
            double b_tontai = 0;
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            if (b_tusinh == null)
                b_so_qd = "";
            else
            {
                if (b_tusinh.Rows[0]["QUYETDINH"].Equals("NT")) b_so_qd = "";
                else
                {
                    string b_dinhdang = "";
                    var b_so = double.Parse(ht_dungchung.Fdt_NS_SO_QD_MAX_MA(b_tusinh.Rows[0]["DODAIQD"].ToString(), b_nam).Rows[0]["SO_QD"].ToString());
                    for (int i = 0; i < chuyen.OBJ_N(b_tusinh.Rows[0]["DODAIQD"].ToString()); i++)
                    {
                        b_dinhdang = b_dinhdang + "0";
                    }
                    do
                    {
                        b_so = b_so + 1;
                        b_so_qd = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_so, b_dinhdang));
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_SOQD_HOI(b_so_qd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (!string.IsNullOrEmpty(b_so_qd))
            {
                b_so_qd = b_so_qd + "/" + b_nam + "/" + b_ma;
            }
            return b_so_qd;
        }
        catch (Exception ex) { return "0" + "#" + ""; }
    }
    [WebMethod(true)]
    public string Fs_NS_TV_SO_QD(string b_login, string b_ngayd, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (string.IsNullOrEmpty(b_ngayd)) return "";
            string b_so_qd = "";
            double b_tontai = 0;
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            if (b_tusinh == null) b_so_qd = "";
            else
            {
                if (b_tusinh.Rows[0]["QUYETDINH"].Equals("NT")) b_so_qd = "";
                else
                {
                    string b_dinhdang = "";
                    var b_so = double.Parse(ht_dungchung.Fdt_NS_SO_QD_TV_MAX_MA(b_tusinh.Rows[0]["DODAIQD"].ToString(), b_nam).Rows[0]["SO_QD"].ToString());
                    for (int i = 0; i < chuyen.OBJ_N(b_tusinh.Rows[0]["DODAIQD"].ToString()); i++)
                    {
                        b_dinhdang = b_dinhdang + "0";
                    }
                    do
                    {
                        b_so = b_so + 1;
                        b_so_qd = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_so, b_dinhdang));
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_SOQD_TV_HOI(b_so_qd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (!string.IsNullOrEmpty(b_so_qd))
            {
                b_so_qd = b_so_qd + "/" + b_nam + "/" + b_ma;
            }
            return b_so_qd;
        }
        catch (Exception ex) { return "0" + "#" + ""; }
    }
    [WebMethod(true)]
    public string Fs_NS_CP_SO_QD(string b_login, string b_ngayd, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (string.IsNullOrEmpty(b_ngayd)) return "";
            string b_so_qd = "";
            double b_tontai = 0;
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            if (b_tusinh == null)
                b_so_qd = "";
            else
            {
                if (b_tusinh.Rows[0]["QUYETDINH"].Equals("NT")) b_so_qd = "";
                else
                {
                    string b_dinhdang = "";
                    var b_so = double.Parse(ht_dungchung.Fdt_NS_SO_QD_CP_MAX_MA(b_tusinh.Rows[0]["DODAIQD"].ToString(), b_nam).Rows[0]["SO_QD"].ToString());
                    for (int i = 0; i < chuyen.OBJ_N(b_tusinh.Rows[0]["DODAIQD"].ToString()); i++)
                    {
                        b_dinhdang = b_dinhdang + "0";
                    }
                    do
                    {
                        b_so = b_so + 1;
                        b_so_qd = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_so, b_dinhdang));
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_SOQD_CP_HOI(b_so_qd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (!string.IsNullOrEmpty(b_so_qd)) b_so_qd = b_so_qd + "/" + b_nam + "/" + b_ma;
            return b_so_qd;
        }
        catch (Exception) { return "0" + "#" + ""; }
    }
    [WebMethod(true)]
    public string Fs_NS_KHENTHUONG_SO_QD(string b_login, string b_ngayd, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (string.IsNullOrEmpty(b_ngayd)) return "";
            string b_so_qd = "";
            double b_tontai = 0;
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            if (b_tusinh == null) b_so_qd = "";
            else
            {
                if (b_tusinh.Rows[0]["QUYETDINH"].Equals("NT")) b_so_qd = "";
                else
                {
                    string b_dinhdang = "";
                    var b_so = double.Parse(ht_dungchung.Fdt_NS_SO_QD_KHENTHUONG_MAX_MA(b_tusinh.Rows[0]["DODAIQD"].ToString(), b_nam).Rows[0]["SO_QD"].ToString());
                    for (int i = 0; i < chuyen.OBJ_N(b_tusinh.Rows[0]["DODAIQD"].ToString()); i++)
                    {
                        b_dinhdang = b_dinhdang + "0";
                    }
                    do
                    {
                        b_so = b_so + 1;
                        b_so_qd = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_so, b_dinhdang));
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_SOQD_KHENTHUONG_HOI(b_so_qd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (!string.IsNullOrEmpty(b_so_qd)) b_so_qd = b_so_qd + "/" + b_nam + "/" + b_ma;
            return b_so_qd;
        }
        catch (Exception ex) { return "0" + "#" + ""; }
    }
    [WebMethod(true)]
    public string Fs_NS_KYLUAT_SO_QD(string b_login, string b_ngayd, string b_ma)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            if (string.IsNullOrEmpty(b_ngayd)) return "";
            string b_so_qd = "";
            double b_tontai = 0;
            DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
            string b_nam = chuyen.CNG_SO(b_ngayd).ToString();
            b_nam = b_nam.ToString().Substring(0, 4);
            if (b_tusinh == null) b_so_qd = "";
            else
            {
                if (b_tusinh.Rows[0]["QUYETDINH"].Equals("NT")) b_so_qd = "";
                else
                {
                    string b_dinhdang = "";
                    var b_so = double.Parse(ht_dungchung.Fdt_NS_SO_QD_KYLUAT_MAX_MA(b_tusinh.Rows[0]["DODAIQD"].ToString(), b_nam).Rows[0]["SO_QD"].ToString());
                    for (int i = 0; i < chuyen.OBJ_N(b_tusinh.Rows[0]["DODAIQD"].ToString()); i++)
                    {
                        b_dinhdang = b_dinhdang + "0";
                    }
                    do
                    {
                        b_so = b_so + 1;
                        b_so_qd = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_so, b_dinhdang));
                        b_tontai = double.Parse(ht_dungchung.Fdt_NS_SO_SOQD_KYLUAT_HOI(b_so_qd).Rows[0]["TONTAI"].ToString());

                    } while (b_tontai != 0);
                }
            }
            if (!string.IsNullOrEmpty(b_so_qd)) b_so_qd = b_so_qd + "/" + b_nam + "/" + b_ma;
            return b_so_qd;
        }
        catch (Exception ex) { return "0" + "#" + ""; }
    }
    #endregion QUÁ TRÌNH LÀM VIỆC

    #region CHỨC DANH KIÊM NHIỆM
    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_LKE(string b_phong, string b_so_the, string b_hoten, string[] a_cot, double[] a_tso)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CDANH_KN_LKE(b_phong, b_so_the, b_hoten, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return bang.Fb_TRANG(b_dt) ? "#" : chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_MA(string b_so_the, string b_phong_tk, string b_sothe_tk, string b_hoten_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_qt.Fdt_NS_CDANH_KN_MA(b_so_the, b_phong_tk, b_sothe_tk, b_hoten_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_CT(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_CDANH_KN_CT(b_so_id);
            bang.P_SO_CSO(ref b_dt, "phucap_kn"); bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_het_hl");
            bang.P_TIM_THEM(ref b_dt, "ns_cdanh_kn", "DT_CTY", "cty");
            foreach (DataRow b_row in b_dt.Rows)
            {
                string b_cty = chuyen.OBJ_S(b_row["CTY"]), b_ten_cty = chuyen.OBJ_S(b_row["TEN_CTY_KN"]);
                string b_phong = chuyen.OBJ_S(b_row["PHONG"]), b_ten_phong = chuyen.OBJ_S(b_row["TEN_PHONG_KN"]);
                string b_bophan = chuyen.OBJ_S(b_row["BOPHAN"]), b_ten_bophan = chuyen.OBJ_S(b_row["TEN_BOPHAN_KN"]);
                string b_cdanh = chuyen.OBJ_S(b_row["CDANH"]), b_ten_cdanh = chuyen.OBJ_S(b_row["TEN_CDANH_KN"]);
                b_row["CTY"] = b_cty + "{" + b_ten_cty;
                b_row["PHONG"] = b_phong + "{" + b_ten_phong;
                b_row["BOPHAN"] = b_bophan + "{" + b_ten_bophan;
                b_row["CDANH"] = b_cdanh + "{" + b_ten_cdanh;
            }

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_NH(string b_so_id, string b_phong_tk, string b_sothe_tk, string b_hoten_tk, double b_trangKT, object[] a_dt, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri), b_dt_dk;
            if (a_gtri_ct == null) b_dt_dk = bang.Fdt_TAO_BANG(a_cot_ct, "SS");
            else { b_dt_dk = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_DON(ref b_dt_dk); }
            bang.P_BO_HANG(ref b_dt_dk, "cty", "");
            if (b_dt_dk == null || b_dt_dk.Rows.Count <= 0)
            {
                return Thongbao_dch.nhapdulieu_luoi;
            }
            //for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            //{
            //    if (b_dt_dk.Rows[i]["MA_PC"].ToString().Equals("") || b_dt_dk.Rows[i]["TEN_PC"].ToString().Equals("") || b_dt_dk.Rows[i]["GIATRI"].ToString().Equals(""))
            //    {
            //        return Thongbao_dch.nhapdulieu_luoi;
            //    }
            //}
            bang.P_CNG_SO(ref b_dt_dk, "ngay_hl,ngay_het_hl"); bang.P_CSO_SO(ref b_dt_dk, "phucap_kn");
            for (int i = 0; i < b_dt_dk.Rows.Count; i++)
            {
                var b_ngayhl = b_dt_dk.Rows[i]["ngay_hl"].ToString();
                var b_ngayhhl = b_dt_dk.Rows[i]["ngay_het_hl"].ToString();
                // validate ngay hieu luc,ngay het hieu luc tren luoi
                string Ngayhl = "Ngày hiệu lực";
                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_dk.Rows[i]["ngay_hl"].ToString()), ref Ngayhl) == false)
                {
                    return Ngayhl;
                }
                string Ngayhhl = "Ngày hết hiệu lực";
                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_dk.Rows[i]["ngay_het_hl"].ToString()), ref Ngayhhl) == false)
                {
                    return Ngayhhl;
                }
                if (skhac.CheckDate(b_ngayhl, b_ngayhhl, ref Ngayhl) == false)
                {
                    return Ngayhl;
                }
            }

            ns_qt.P_NS_CDANH_KN_NH(b_so_id, b_dt_ct, b_dt_dk);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CDANH_KN, TEN_BANG.NS_CDANH_KN);
            string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
            return Fs_NS_CDANH_KN_MA(b_so_the, b_phong_tk, b_sothe_tk, b_hoten_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_XOA(string b_so_id, string b_phong, string b_sothe, string b_hoten, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_qt.P_NS_CDANH_KN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CDANH_KN, TEN_BANG.NS_CDANH_KN);
            return Fs_NS_CDANH_KN_LKE(b_phong, b_sothe, b_hoten, a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CDANH_KN_PHONG_DROP(string b_login, string b_cty)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = new DataTable();
            b_dt = ns_qt.Fdt_NS_CDANH_KN_PHONG_DROP(b_cty);
            // if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" });
            se.P_TG_LUU("ns_cdanh_kn", "DT_PHONG", b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion CHỨC DANH KIÊM NHIỆM

    //#region THÔI VIỆC
    //[WebMethod(true)]
    //public string Fs_NS_TV_HOI_CB(string b_so_the)
    //{
    //    try
    //    {
    //        DataTable b_dt = ns_qt.Fdt_NS_TV_HOI_CB(b_so_the);
    //        bang.P_SO_CNG(ref b_dt, "ngayd");
    //        return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_LKE(string b_tinhtrang_tk, double[] a_tso, string[] a_cot)
    //{
    //    try
    //    {
    //        double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
    //        object[] a_object = ns_qt.Fdt_NS_TV_LKE(b_tinhtrang_tk, b_tu_n, b_den_n);
    //        DataTable b_dt = (DataTable)a_object[1];
    //        return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}
    //[WebMethod(true)]
    //public string Fs_NS_TV_MA(string b_so_the, string b_tinhtrang_tk, double b_trangkt, string[] a_cot)
    //{
    //    try
    //    {
    //        object[] a_object = ns_qt.Fdt_NS_TV_MA(b_so_the, b_tinhtrang_tk, b_trangkt);
    //        DataTable b_dt = (DataTable)a_object[2];
    //        int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
    //        return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_NH(string b_so_id,string b_tinhtrang_tk, double b_trangKT, object[] a_dt, object[] a_dt_tt, object[] a_dt_ts, object[] a_dt_cn, string[] a_cot_lke)
    //{
    //    try
    //    {
    //        string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
    //        DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_qd,ngaynop,ngaynghi,ngaytt,ngayd");
    //        string[] a_cot_tt = chuyen.Fas_OBJ_STR((object[])a_dt_tt[0]); object[] a_gtri_tt = (object[])a_dt_tt[1];

    //        DataTable b_dt_tt = bang.Fdt_TAO_THEM(a_cot_tt, a_gtri_tt); bang.P_BO_HANG(ref b_dt_tt, "ma", "");
    //        if (b_dt_tt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tt, new object[] { "", "-1", "" });
    //        string[] a_cot_ts = chuyen.Fas_OBJ_STR((object[])a_dt_ts[0]); object[] a_gtri_ts = (object[])a_dt_ts[1];

    //        DataTable b_dt_ts = bang.Fdt_TAO_THEM(a_cot_ts, a_gtri_ts); bang.P_BO_HANG(ref b_dt_ts, "ten", ""); bang.P_CNG_SO(ref b_dt_ts, "ngaytra,ngaycap"); bang.P_CSO_SO(ref b_dt_ts, "sluong");
    //        if (b_dt_ts.Rows.Count == 0)
    //        {
    //            bang.P_THEM_HANG(ref b_dt_ts, new object[] { "", "", "-1", "30000101", "30000101", "0" });
    //        }
    //        else
    //        {
    //            double b_ngaytra = 0, b_ngaycap = 0;
    //            for (int i = 0; i < b_dt_ts.Rows.Count; i++)
    //            {
    //                string Ngaytra = "Ngày trả";
    //                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_ts.Rows[i]["ngaytra"].ToString()), ref Ngaytra) == false)
    //                {
    //                    return Ngaytra;
    //                }
    //                string Ngaycap = "Ngày cấp";
    //                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_ts.Rows[i]["ngaycap"].ToString()), ref Ngaycap) == false)
    //                {
    //                    return Ngaycap;
    //                }
    //                b_ngaytra = chuyen.CSO_SO(b_dt_ts.Rows[i]["ngaytra"].ToString());
    //                b_ngaycap = chuyen.CSO_SO(b_dt_ts.Rows[i]["ngaycap"].ToString());

    //                if (b_ngaycap > b_ngaytra)
    //                {
    //                    return Thongbao_dch.ngaytra_ngaycap;
    //                }
    //            }
    //        }
    //        string[] a_cot_cn = chuyen.Fas_OBJ_STR((object[])a_dt_cn[0]); object[] a_gtri_cn = (object[])a_dt_cn[1];

    //        DataTable b_dt_cn = bang.Fdt_TAO_THEM(a_cot_cn, a_gtri_cn); bang.P_BO_HANG(ref b_dt_cn, "ten", ""); bang.P_CNG_SO(ref b_dt_cn, "ngay"); bang.P_CSO_SO(ref b_dt_cn, "tien");
    //        if (b_dt_cn.Rows.Count == 0) { bang.P_THEM_HANG(ref b_dt_cn, new object[] { "", "-1", "", "30000101", "0" }); }
    //        else
    //        {
    //            for (int i = 0; i < b_dt_cn.Rows.Count; i++)
    //            {
    //                string Ngayht = "Ngày hoàn tất";
    //                if (skhac.CheckDateInGrid(chuyen.CSO_CNG(b_dt_cn.Rows[i]["ngay"].ToString()), ref Ngayht) == false)
    //                {
    //                    return Ngayht;
    //                }
    //            }
    //        }
    //        b_so_id = ns_qt.P_NS_TV_NH(ref b_so_id, b_dt, b_dt_tt, b_dt_ts, b_dt_cn);
    //        string b_so_the = mang.Fs_TEN_GTRI("so_the", a_cot, a_gtri);
    //        return Fs_NS_TV_MA(b_so_the, b_tinhtrang_tk, b_trangKT, a_cot_lke);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_XOA(string b_so_id, string b_tinhtrang_tk, double[] a_tso, string[] a_cot)
    //{
    //    try { ns_qt.PNS_TV_XOA(b_so_id); return Fs_NS_TV_LKE(b_tinhtrang_tk, a_tso, a_cot); }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_DAT_THUTUC(string[] a_cot_tt)
    //{
    //    try
    //    {
    //        DataTable b_dt_tt = ns_qt.Fdt_NS_TV_LKE_THUTUC();
    //        bang.P_THEM_COL(ref b_dt_tt, "chon", "");
    //        return bang.Fs_BANG_CH(b_dt_tt, a_cot_tt);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_DAT_TAISAN(string b_so_the, string[] a_cot_ts)
    //{
    //    try
    //    {
    //        DataTable b_dt_ts = ns_qt.Fdt_NS_TV_LKE_TAISAN(b_so_the);
    //        bang.P_THEM_COL(ref b_dt_ts, new string[] { "chon", "ngaytra" }, new object[] { "", "30000101" });
    //        bang.P_SO_CNG(ref b_dt_ts, "ngaytra,ngaycap");
    //        return bang.Fs_BANG_CH(b_dt_ts, a_cot_ts);
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //[WebMethod(true)]
    //public string Fs_NS_TV_CT(string b_so_id, string b_so_the, string[] a_cot_tt, string[] a_cot_ts, string[] a_cot_cn)
    //{
    //    try
    //    {
    //        DataSet b_ds = ns_qt.Fdt_NS_TV_CT(b_so_id);
    //        string b_kq_tt, b_kq_ts, b_kq_cn;
    //        DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngay_qd,ngaynghi,ngaynop,ngaytt,ngayd");
    //        string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    //        DataTable b_dt_tt = b_ds.Tables[1];
    //        if (b_dt_tt.Rows.Count == 0)
    //        {
    //            b_dt_tt = ns_qt.Fdt_NS_TV_LKE_THUTUC();
    //            bang.P_THEM_COL(ref b_dt_tt, "chon", "");
    //        }
    //        b_kq_tt = bang.Fb_TRANG(b_dt_tt) ? "" : bang.Fs_BANG_CH(b_dt_tt, a_cot_tt);
    //        // lấy lại số liệu tài sản
    //        DataTable b_dt_ts = b_ds.Tables[2];
    //        if (b_dt_ts.Rows.Count == 0)
    //        {
    //            b_dt_ts = ns_qt.Fdt_NS_TV_LKE_TAISAN(b_so_the);
    //            bang.P_THEM_COL(ref b_dt_ts, new string[] { "chon", "ngaytra" }, new object[] { "", "30000101" });
    //        }
    //        bang.P_SO_CNG(ref b_dt_ts, "ngaytra,ngaycap"); bang.P_SO_CSO(ref b_dt_ts, "sluong");
    //        b_kq_ts = bang.Fb_TRANG(b_dt_ts) ? "" : bang.Fs_BANG_CH(b_dt_ts, a_cot_ts);
    //        DataTable b_dt_cn = b_ds.Tables[3]; bang.P_SO_CNG(ref b_dt_cn, "ngay"); bang.P_SO_CSO(ref b_dt_cn, "tien");
    //        b_kq_cn = bang.Fb_TRANG(b_dt_cn) ? "" : bang.Fs_BANG_CH(b_dt_cn, a_cot_cn);
    //        return b_kq + "#" + b_kq_tt + "#" + b_kq_ts + "#" + b_kq_cn;
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}


    //public string Fs_NS_THS_CT(string b_so_the, string[] a_cot_ct, string[] a_cot_lke)
    //{
    //    try
    //    {
    //        DataSet b_ds = ns_tt.Fdt_NS_THS_CT(b_so_the);
    //        DataTable b_dt = b_ds.Tables[0]; bang.P_SO_CNG(ref b_dt, "ngayd");
    //        string b_dt_s = bang.Fb_TRANG(b_ds.Tables[0]) ? "" : bang.Fs_HANG_GOP(b_dt, 0),
    //               b_dt_lke_s = bang.Fb_TRANG(b_ds.Tables[2]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[2], a_cot_lke),
    //               b_dt_ct_s;
    //        if (b_ds.Tables[1].Rows.Count == 0)
    //        {
    //            DataTable b_dt_ct = ns_tt.Fdt_NS_THS_LKEMA();
    //            bang.P_THEM_COL(ref b_dt_ct, "chon", "");
    //            b_dt_ct_s = bang.Fs_BANG_CH(b_dt_ct, a_cot_ct);
    //        }
    //        else b_dt_ct_s = bang.Fb_TRANG(b_ds.Tables[1]) ? "" : bang.Fs_BANG_CH(b_ds.Tables[1], a_cot_ct);
    //        return b_dt_s + "#" + b_dt_ct_s + "#" + b_dt_lke_s;
    //    }
    //    catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    //}

    //#endregion THÔI VIỆC

    #region THIẾT LẬP THỜi HẠN NÂNG LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_QT_TLAP_LENLUONG_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_QT_TLAP_LENLUONG_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_TLAP_LENLUONG_MA(string b_ngay, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_qt.Fdt_NS_QT_TLAP_LENLUONG_MA(b_ngay, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2]; bang.P_SO_CNG(ref b_dt, "ngay");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ngay", b_ngay);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_TLAP_LENLUONG_CT(string b_so_id)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_QT_TLAP_LENLUONG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_QT_TLAP_LENLUONG_NH(string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "ngay");
            ns_qt.P_NS_QT_TLAP_LENLUONG_NH(b_so_id, b_dt_ct);
            string b_ngay = mang.Fs_TEN_GTRI("ngay", a_cot, a_gtri);
            return Fs_NS_QT_TLAP_LENLUONG_MA(b_ngay, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_TLAP_LENLUONG_XOA(string b_so_id, double[] a_tso, string[] a_cot)
    {
        try { ns_qt.P_NS_QT_TLAP_LENLUONG_XOA(b_so_id); return Fs_NS_QT_TLAP_LENLUONG_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion THIẾT LẬP THỜi HẠN NÂNG LƯƠNG

    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_LKE(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_LKE(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_dk");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_MA(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_MA(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_dk");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "NS", "Nhân sự");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_CT(b_so_the, b_ngayd);
            bang.P_SO_CNG(ref b_dt, "ngay_dk");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_NH(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dk");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngay_dk"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.PNS_CC_DKLV_NGOAI_CTY_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_DKLV_NGOAI_CTY, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return Fs_NS_CC_DKLV_NGOAI_CTY_MA(b_login, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_XOA(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_CC_DKLV_NGOAI_CTY_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_DKLV_NGOAI_CTY, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return Fs_NS_CC_DKLV_NGOAI_CTY_LKE(b_login, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    #endregion ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY CÁ NHÂN
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_LKE(string b_login, string b_nam_tk, string b_kyluong_tk, string b_tt_tk, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_CN_LKE(b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_the, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_dk");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_tt", "2", "Không phê duyệt");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_MA(string b_login, string b_nam_tk, string b_kyluong_tk, string b_tt_tk, string b_so_the, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_CN_MA(b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_the, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngay_dk");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "0", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "1", "Phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tt", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_DKLV_NGOAI_CTY_CN_CT(b_so_the, b_ngayd);
            bang.P_SO_CNG(ref b_dt, "ngay_dk");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_NH(string b_login, string b_nam_tk, string b_kyluong_tk, string b_tt_tk, string b_so_the, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dk");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngay_dk"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.PNS_CC_DKLV_NGOAI_CTY_CN_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_CN, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return Fs_NS_CC_DKLV_NGOAI_CTY_CN_MA(b_login, b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_the, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_XOA(string b_login, string b_nam_tk, string b_kyluong_tk, string b_tt_tk, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_CC_DKLV_NGOAI_CTY_CN_XOA(b_so_id, b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_CN, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return Fs_NS_CC_DKLV_NGOAI_CTY_CN_LKE(b_login, b_nam_tk, b_kyluong_tk, b_tt_tk, b_so_the, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKLV_NGOAI_CTY_CN_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            ns_qt.PNS_CC_DKLV_NGOAI_CTY_CN_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_CC_DKLV_NGOAI_CTY_CN, TEN_BANG.NS_CC_DKLV_NGOAI_CTY);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY CÁ NHÂN

    #region ĐĂNG KÝ CA NUÔI CON NHỎ DƯỚI 1 TUỔI
    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_LKE(string b_login, string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CC_DKC_CONNHO_LKE(b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt_tk, "dtuong_nh", "NS", "Nhân sự");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_MA(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_CC_DKC_CONNHO_MA(b_so_the_tk, b_ten_tk, b_phong_tk, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "dtuong_nh", "NS", "Nhân sự");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_DKC_CONNHO_CT(b_so_the, b_ngayd);
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_dkc_connho", "DT_CALV", "CA");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_NH(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngayd"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.P_NS_CC_DKC_CONNHO_NH(ref b_so_id, b_dt_ct);

            // lấy danh sách ngày theo khoản thời gian đăng ký từ ngày đến ngày.
            DataTable b_dt_ds = new DataTable();
            b_dt_ds = ns_qt.Fdt_NS_CC_DKC_CONNHO_DS_PHANCA(b_dt_ct.Rows[0]["so_the"].ToString(), b_dt_ct.Rows[0]["ca"].ToString(), b_dt_ct.Rows[0]["ngayd"].ToString(), b_dt_ct.Rows[0]["ngayc"].ToString());

            // đẩy dữ liệu vào phân xếp ca làm việc
            ns_qt.PNS_CC_DKC_CONNHO_PHANCA(b_dt_ds);

            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_DKC_CONNHO, TEN_BANG.NS_CC_DKC_CONNHO);
            return Fs_NS_CC_DKC_CONNHO_MA(b_login, b_so_the_tk, b_ten_tk, b_phong_tk, b_trangthai, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_DKC_CONNHO_XOA(string b_login, string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_CC_DKC_CONNHO_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_DKC_CONNHO, TEN_BANG.NS_CC_DKC_CONNHO);
            return Fs_NS_CC_DKC_CONNHO_LKE(b_login, b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion

    #region CÁ NHÂN ĐĂNG KÝ CA NUÔI CON NHỎ DƯỚI 1 TUỔI
    [WebMethod(true)]
    public string Fs_CC_CN_DKC_CONNHO_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); ns_qt.P_CC_CN_DKC_CONNHO_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_CC_DKC_CONNHO, TEN_BANG.NS_CC_DKC_CONNHO);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKC_CONNHO_LKE(string b_login, string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CC_CN_DKC_CONNHO_LKE(b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "trangthai", "2", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKC_CONNHO_MA(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_CC_CN_DKC_CONNHO_MA(b_so_the_tk, b_ten_tk, b_phong_tk, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "2", "Không phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKC_CONNHO_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_CN_DKC_CONNHO_CT(b_so_the, b_ngayd);
            bang.P_TIM_THEM(ref b_dt, "ns_cc_cn_dkc_connho", "DT_CALV", "CA");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKC_CONNHO_NH(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngayd"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.P_NS_CC_CN_DKC_CONNHO_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_DKC_CONNHO, TEN_BANG.NS_CC_DKC_CONNHO);
            return Fs_NS_CC_CN_DKC_CONNHO_MA(b_login, b_so_the_tk, b_ten_tk, b_phong_tk, b_trangthai, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_CN_DKC_CONNHO_XOA(string b_login, string b_so_the_tk, string b_ten_tk, string b_ngayd_tk, string b_ngayc_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_CC_CN_DKC_CONNHO_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_DKC_CONNHO, TEN_BANG.NS_CC_DKC_CONNHO);
            return Fs_NS_CC_CN_DKC_CONNHO_LKE(b_login, b_so_the_tk, b_ten_tk, b_ngayd_tk, b_ngayc_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion

    #region ĐĂNG KÝ NGHỈ

    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_LKE(string b_login, string b_tungay, string b_denngay, string b_so_the, string b_ten, string b_trangthai, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_QT_XIN_NGHIPHEP_LKE(b_tungay, b_denngay, b_so_the, b_ten, b_trangthai, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "tinhtrang", "2", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_MA(string b_login, string b_so_id, string b_so_the, string b_tungay, string b_denngay, string b_trangthai_tk, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_QT_XIN_NGHIPHEP_MA(b_so_id, b_so_the, b_tungay, b_denngay, b_trangthai_tk, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "CG", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "1", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tinhtrang", "2", "Không phê duyệt");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_QT_XIN_NGHIPHEP_CT(b_so_the, b_ngayd);
            bang.P_TIM_THEM(ref b_dt, "NS_QT_XIN_NGHIPHEP", "DT_KIEUNGHI", "macc_nghi");
            bang.P_TIM_THEM(ref b_dt, "NS_QT_XIN_NGHIPHEP", "DT_SOTHE_THAYTHE", "SOTHE_THAYTHE");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            ns_qt.P_NS_QT_XIN_NGHIPHEP_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_QT_XIN_NGHIPHEP, TEN_BANG.NS_QT_XIN_NGHIPHEP);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_NH(string b_login, string b_so_id, string b_so_the, string b_tungay, string b_denngay, string b_trangthai_tk, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngayd"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.P_NS_QT_XIN_NGHIPHEP_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_XIN_NGHIPHEP, TEN_BANG.NS_QT_XIN_NGHIPHEP);
            return Fs_NS_QT_XIN_NGHIPHEP_MA(b_login, b_so_id, b_so_the, b_tungay, b_denngay, b_trangthai_tk, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_XOA(string b_login, string b_tungay, string b_denngay, string b_so_the_tk, string b_ten_tk, string b_trangthai_tk, string b_so_the, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_QT_XIN_NGHIPHEP_XOA(b_so_the, b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_QT_XIN_NGHIPHEP, TEN_BANG.NS_QT_XIN_NGHIPHEP);
            return Fs_NS_QT_XIN_NGHIPHEP_LKE(b_login, b_tungay, b_denngay, b_so_the, b_ten_tk, b_trangthai_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_LOAI(string b_login, string b_ma_nghi, string b_ngayd, string b_ngayc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string b_kt = "";
            DataTable b_dt = ns_qt.PNS_CC_THONGTIN_NGHI_MANGHI(b_ma_nghi, b_ngayd, b_ngayc);
            if (b_dt == null || b_dt.Rows.Count <= 0) return "0";
            else
            {
                b_kt = b_dt.Rows[0]["KT"].ToString();
                string b_kieungay = "", b_songay = "";

                if (b_kt == "CN" && b_dt.Rows[0]["CONG"].ToString() == "0") b_kieungay = "1";
                else if (b_kt == "CN" && b_dt.Rows[0]["CONG"].ToString() == "1") b_kieungay = "1";
                else if (b_kt == "NN" && b_dt.Rows[0]["CONG"].ToString() == "1") b_kieungay = "0.5";
                else if (b_kt == "NN" && b_dt.Rows[0]["CONG"].ToString() == "2") b_kieungay = "0.5";
                else b_kieungay = "1";
                b_songay = b_dt.Rows[0]["SO_NGAY"].ToString();

                return b_kieungay + "#" + b_songay;
            }
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_XIN_NGHIPHEP_UP(string b_login, string b_sothe, string b_ngayd, string b_huydon, string b_tungay_tk, string b_denngay_tk, string b_sothe_tk, string b_ten_tk, string b_trangthai_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_qt.PNS_QT_XIN_NGHIPHEP_UP(b_sothe, b_ngayd, b_huydon);
            return Fs_NS_QT_XIN_NGHIPHEP_LKE(b_login, b_tungay_tk, b_denngay_tk, b_sothe_tk, b_ten_tk, b_trangthai_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion ĐĂNG KÝ NGHỈ

    #region PHÊ DUYỆT NGHỈ PHÉP

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_CT(string b_so_the, string b_ngayxn, string b_ngayd)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_QT_NGHIPHEP_PD_CT(b_so_the, b_ngayxn, b_ngayd);
            bang.P_SO_CNG(ref b_dt, "ngayxn,ngayd,ngayc");

            string b_hoten = "", b_ten_cdanh = "", b_phong = "", b_ly_do = "", b_tungay = "", b_toingay = "", b_ngaynghi = "", b_danghi = "", b_nghicon = "", b_noidung = "";
            string b_kq = "";
            if (b_dt.Rows.Count > 0)
            {

                for (int i = 0; i < b_dt.Rows.Count; i++)
                {
                    b_hoten = b_dt.Rows[i]["ten"].ToString();
                    b_ten_cdanh = b_dt.Rows[i]["ten_cdanh"].ToString();
                    b_phong = b_dt.Rows[i]["phong"].ToString();
                    b_ly_do = b_dt.Rows[i]["ly_do"].ToString();
                    b_tungay = b_dt.Rows[i]["ngayd"].ToString();
                    b_toingay = b_dt.Rows[i]["ngayc"].ToString();
                    b_ngaynghi = b_dt.Rows[i]["ngaynghi"].ToString();
                    b_danghi = b_dt.Rows[i]["danghi"].ToString();
                    b_nghicon = b_dt.Rows[i]["nghicon"].ToString();
                    b_noidung = b_dt.Rows[i]["noidung"].ToString();

                    b_kq = "\n\b(*) Name: " + b_hoten + "\n\b  - Position: " + b_ten_cdanh + "\n\b  - Department: " + b_phong;
                    b_kq = b_kq + "\n\b  - Reason: " + b_ly_do + "\n\b  - From date: " + b_tungay + " - To date: " + b_toingay;
                    b_kq = b_kq + "\n\b  - Total days of leave: " + b_ngaynghi;
                    b_kq = b_kq + "\n\b  - AL taken days: " + b_danghi + " - Balance AL days: " + b_nghicon;
                    b_kq = b_kq + "\n\b  - Content: " + b_noidung;
                }
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_QT_NGHIPHEP_PD_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc,ngayxn");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_PHEDUYET(string b_tinhtrang, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DXN" });
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayxn");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_kq = ns_qt.Fdt_NS_QT_NGHIPHEP_PD_PHEDUYET(b_tinhtrang, b_dt, b_dt_ct);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.Pheduyet_thatbai; }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_NGHIPHEP_PD_KOPHEDUYET(string b_tinhtrang, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DXN" });
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayxn");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            DataTable b_kq = ns_qt.Fdt_NS_QT_NGHIPHEP_PD_KOPHEDUYET(b_tinhtrang, b_dt, b_dt_ct);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.koPheduyet_thatbai; }
    }
    #endregion PHÊ DUYỆT NGHỈ PHÉP

    #region THÔNG TIN NGHỈ

    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_LKE(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_LKE(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, "1", b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_COPY_COL(ref b_dt_tk, "ten_huydon", "huydon");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_huydon", "0", "Đang có hiệu lực");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_huydon", "1", "Đã hủy đơn đăng ký");

            bang.P_COPY_COL(ref b_dt_tk, "ten_dtuong_nh", "dtuong_nh");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_dtuong_nh", "NS", "Nhân sự");

            bang.P_SO_CNG(ref b_dt_tk, "ngayd,ngayc");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_MA(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_MA(b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_trangthai, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_COPY_COL(ref b_dt, "ten_huydon", "huydon");
            bang.P_THAY_GTRI(ref b_dt, "ten_huydon", "0", "Đang có hiệu lực");
            bang.P_THAY_GTRI(ref b_dt, "ten_huydon", "1", "Đã hủy đơn đăng ký");

            bang.P_COPY_COL(ref b_dt, "ten_dtuong_nh", "dtuong_nh");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong_nh", "CN", "Cá nhân");
            bang.P_THAY_GTRI(ref b_dt, "ten_dtuong_nh", "NS", "Nhân sự");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_CT(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_CT(b_so_the, b_ngayd);
            if (b_dt.Rows.Count > 0)
            {
                var b_phong = b_dt.Rows[0]["phong"].ToString();
                DataTable b_dt_dsnv = ht_dungchung.Fdt_SO_THE_THEP_PHONG(b_so_the, b_phong);
                bang.P_THEM_HANG(ref b_dt_dsnv, new object[] { "", "" }, 0);
                se.P_TG_LUU("ns_cc_thongtin_nghi", "DT_SOTHE_THAYTHE", b_dt_dsnv.Copy());
            }

            bang.P_TIM_THEM(ref b_dt, "ns_cc_thongtin_nghi", "DT_KIEUNGHI", "macc_nghi");
            bang.P_TIM_THEM(ref b_dt, "ns_cc_thongtin_nghi", "DT_SOTHE_THAYTHE", "sothe_thaythe");
            bang.P_COPY_COL(ref b_dt, "ten_huydon", "huydon");
            bang.P_THAY_GTRI(ref b_dt, "ten_huydon", "0", "Đang có hiệu lực");
            bang.P_THAY_GTRI(ref b_dt, "ten_huydon", "1", "Đã hủy đơn đăng ký");
            bang.P_SO_CNG(ref b_dt, "ngayd,ngayc");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_NH(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_trangthai, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "tinhtrang", "0");
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");
            var kyluong_id = ht_dungchung.FTL_LAY_KYLUONG_THEO_NGAY(double.Parse(b_dt_ct.Rows[0]["ngayd"].ToString()));
            var b_ttrang = ht_dungchung.P_NS_CC_TRANGTHAI_KYCONG("", kyluong_id);
            if (b_ttrang == "1") return Thongbao_dch.KY_CONG_KHOA;
            ns_qt.P_NS_CC_THONGTIN_NGHI_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CC_THONGTIN_NGHI, TEN_BANG.NS_CC_THONGTIN_NGHI);
            return Fs_NS_CC_THONGTIN_NGHI_MA(b_login, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, b_trangthai, b_so_id, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }

    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_XOA(string b_login, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_CC_THONGTIN_NGHI_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CC_THONGTIN_NGHI, TEN_BANG.NS_CC_THONGTIN_NGHI);
            return Fs_NS_CC_THONGTIN_NGHI_LKE(b_login, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_KTRA(string b_login, string b_so_the, string b_ngayd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.PNS_CC_THONGTIN_NGHI_KTRA(b_so_the, chuyen.CNG_SO(b_ngayd));
            if (b_dt.Rows.Count > 0)
            {
                return b_dt.Rows[0]["tontai"].ToString();
            }
            return "0";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_LOAI(string b_login, string b_ma_nghi, string b_ngayd, string b_ngayc)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.PNS_CC_THONGTIN_NGHI_MANGHI(b_ma_nghi, b_ngayd, b_ngayc);
            if (b_dt == null || b_dt.Rows.Count <= 0) return "0";
            else
            {
                var b_kt = b_dt.Rows[0]["KT"].ToString();
                string b_kieungay = "", b_songay = "";

                if (b_kt == "CN" && b_dt.Rows[0]["CONG"].ToString() == "0") b_kieungay = "1";
                else if (b_kt == "CN" && b_dt.Rows[0]["CONG"].ToString() == "1") b_kieungay = "1";
                else if (b_kt == "NN" && b_dt.Rows[0]["CONG"].ToString() == "1") b_kieungay = "0.5";
                else if (b_kt == "NN" && b_dt.Rows[0]["CONG"].ToString() == "2") b_kieungay = "0.5";
                else b_kieungay = "1";
                b_songay = b_dt.Rows[0]["SO_NGAY"].ToString();

                return b_kieungay + "#" + b_songay;
            }
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_NGAYPHEP(string b_login, string b_so_the, string b_nam)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_QT_XIN_NGHIPHEP_CB(b_so_the, b_nam);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_UP(string b_login, string b_so_id, string b_so_the_tk, string b_ten_tk, string b_nam_tk, string b_kyluong, string b_phong_tk, string b_huydon, double[] a_tso, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_qt.PNS_CC_THONGTIN_NGHI_UP(b_so_id, b_huydon);
            return Fs_NS_CC_THONGTIN_NGHI_LKE(b_login, b_so_the_tk, b_ten_tk, b_nam_tk, b_kyluong, b_phong_tk, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    [WebMethod(true)]
    public string Fs_NS_CC_THONGTIN_NGHI_SC(string b_login, string b_kieunghi)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_CC_THONGTIN_NGHI_SC(b_kieunghi);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.ToString()); }
    }
    #endregion THÔNG TIN NGHỈ

    #region PHÊ DUYỆT NGHỈ VIỆC

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_PD_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ns_qt.Fdt_NS_QT_NGHIVIEC_PD_CT(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_nop,ngay_xin,ngay_tt,ngay_pd");
            return b_dt.Rows.Count + "#" + bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_PD_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_QT_NGHIVIEC_PD_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_PD_NH(string b_tinhtrang, string b_so_the, string[] a_cot_lke, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_pd");
            bang.P_CSO_SO(ref b_dt_ct, "mdc");

            DataTable b_dt_kq = ns_qt.P_NS_QT_NGHIVIEC_PD_NH(b_tinhtrang, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_NGHIVIEC_PD, TEN_BANG.NS_QT_NGHIVIEC_PD);
            return Fs_NS_QT_NGHIVIEC_PD_CT(b_so_the);
        }
        catch (Exception ex)
        {
            return Thongbao_dch.ThaoTac_thatbai;
        }
    }
    #endregion PHÊ DUYỆT NGHỈ PHÉP

    #region KHAI BAO NGHI VIEC
    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_MA(string b_so_the, string[] a_cot)
    {
        try
        {
            DataSet b_ds = ns_qt.Fdt_NS_QT_XIN_NGHIVIEC_MA(b_so_the);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_tl = b_ds.Tables[1];
            var b_hang = b_dt.Rows.Count;
            bang.P_SO_CNG(ref b_dt, "ngay_nop,ngay_xin,ngay_tt");
            bang.P_SO_CNG(ref b_dt_tl, "ngay_bg");
            string b_dt_tailieu = bang.Fb_TRANG(b_dt_tl) ? "" : bang.Fs_BANG_CH(b_dt_tl, a_cot);
            return b_hang + "#" + bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_dt_tailieu;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_NH(string b_so_the, string[] a_cot_lke, object[] a_dt_ct, object[] a_dt_tl)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_tl[0]); object[] a_gtri_tl = (object[])a_dt_tl[1];

            DataTable b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
            if (b_dt_tl.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_tl, new object[] { "", "", "1", "" });

            bang.P_CNG_SO(ref b_dt_ct, "ngay_nop,ngay_xin,ngay_tt");
            bang.P_CNG_SO(ref b_dt_tl, "ngay_bg");
            ns_qt.Fs_NS_QT_NGHIVIEC_NH(b_dt_ct, b_dt_tl);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_NGHIVIEC, TEN_BANG.NS_QT_NGHIVIEC);
            return Fs_NS_QT_NGHIVIEC_MA(b_so_the, a_cot_lke);
        }
        catch (Exception ex)
        {
            return Thongbao_dch.ThaoTac_thatbai;
        }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_NGHIVIEC_GUI(string b_so_the)
    {
        try
        {
            ns_qt.P_NS_QT_XIN_NGHIVIEC_GUI(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_QT_NGHIVIEC, TEN_BANG.NS_QT_NGHIVIEC);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region QUẢN LÝ NGHỈ VIỆC

    [WebMethod(true)]
    public string Fs_NS_THOIVIEC_NH(string b_login,
                                    string b_so_the,
                                    double b_trangKT,
                                    object[] a_dt_ct,
                                    object[] a_dt_1,
                                    object[] a_dt_2,
                                    object[] a_dt_3,
                                    object[] a_dt_4,
                                    object[] a_dt_5,
                                    object[] a_dt_6,
                                    object[] a_dt_7,
                                    string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt, "tctv,tien_bh_daotao,khoan_khac,bhxh_nld,bhxh_nsdld,bh_suckhoe,htro_khac");
            bang.P_CNG_SO(ref b_dt, "ngay_vao,ngay_nop,ngay_tthuan,ngay_tt,ngay_pd,ngay_ky");

            string[] a_cot_1 = chuyen.Fas_OBJ_STR((object[])a_dt_1[0]);
            object[] a_gtri_1 = (object[])a_dt_1[1];
            DataTable b_dt_1 = bang.Fdt_TAO_THEM(a_cot_1, a_gtri_1);
            bang.P_CNG_SO(ref b_dt_1, "ngay_bg");

            string[] a_cot_2 = chuyen.Fas_OBJ_STR((object[])a_dt_2[0]);
            object[] a_gtri_2 = (object[])a_dt_2[1];
            DataTable b_dt_2 = bang.Fdt_TAO_THEM(a_cot_2, a_gtri_2);
            bang.P_CNG_SO(ref b_dt_2, "ngay_bg");

            string[] a_cot_3 = chuyen.Fas_OBJ_STR((object[])a_dt_3[0]);
            object[] a_gtri_3 = (object[])a_dt_3[1];
            DataTable b_dt_3 = bang.Fdt_TAO_THEM(a_cot_3, a_gtri_3);
            bang.P_CNG_SO(ref b_dt_3, "ngay_bg");

            string[] a_cot_4 = chuyen.Fas_OBJ_STR((object[])a_dt_4[0]);
            object[] a_gtri_4 = (object[])a_dt_4[1];
            DataTable b_dt_4 = bang.Fdt_TAO_THEM(a_cot_4, a_gtri_4);
            bang.P_CNG_SO(ref b_dt_4, "ngay_bg");

            string[] a_cot_5 = chuyen.Fas_OBJ_STR((object[])a_dt_5[0]);
            object[] a_gtri_5 = (object[])a_dt_5[1];
            DataTable b_dt_5 = bang.Fdt_TAO_THEM(a_cot_5, a_gtri_5);
            bang.P_CNG_SO(ref b_dt_5, "ngay_bg");

            string[] a_cot_6 = chuyen.Fas_OBJ_STR((object[])a_dt_6[0]);
            object[] a_gtri_6 = (object[])a_dt_6[1];
            DataTable b_dt_6 = bang.Fdt_TAO_THEM(a_cot_6, a_gtri_6);
            bang.P_CNG_SO(ref b_dt_6, "ngay_bg");

            string[] a_cot_7 = chuyen.Fas_OBJ_STR((object[])a_dt_7[0]);
            object[] a_gtri_7 = (object[])a_dt_7[1];
            DataTable b_dt_7 = bang.Fdt_TAO_THEM(a_cot_7, a_gtri_7);
            bang.P_CNG_SO(ref b_dt_7, "ngay_bg");

            ns_qt.P_NS_THOIVIEC_NH(b_dt, b_dt_1, b_dt_2, b_dt_3, b_dt_4, b_dt_5, b_dt_6, b_dt_7);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_TV, TEN_BANG.NS_TV);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_THOIVIEC_MA(string b_login, string b_so_id, string b_tungay, string b_denngay, string b_phong, string b_so_the, string b_ten, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Faobj_NS_THOIVIEC_MA(b_so_id, b_tungay, b_denngay, b_phong, b_so_the, b_ten, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_nop,ngay_tthuan,ngay_tt,ngay_pd,ngay_ky");
            bang.P_SO_CSO(ref b_dt, "tien_phep,tien_bh_daotao,truythu_tamung,ht_nghiviec,khoan_khac");

            bang.P_THAY_GTRI(ref b_dt, "ten_tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "ten_tinhtrang", "1", "Phê duyệt");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_THOIVIEC_LKE(string b_login, string b_ngay_d, string b_ngay_c, string b_phong, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_qt.Faobj_NS_THOIVIEC_LKE(b_ngay_d, b_ngay_c, b_phong, b_so_the, b_ten, b_tu, b_den);
            DataTable b_dt_ct = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngay_tt");
            bang.P_THAY_GTRI(ref b_dt_ct, "ten_tinhtrang", "0", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_ct, "ten_tinhtrang", "1", "Phê duyệt");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_ct, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_THOIVIEC_CT(string b_login, string b_so_the, string[] a_cot_hc, string[] a_cot_tb, string[] a_cot_ts, string[] a_cot_hs)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fds_NS_THOIVIEC_CT(b_so_the);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_1 = (DataTable)b_ds.Tables[1];
            DataTable b_dt_2 = (DataTable)b_ds.Tables[2];
            DataTable b_dt_3 = (DataTable)b_ds.Tables[3];
            DataTable b_dt_4 = (DataTable)b_ds.Tables[4];
            DataTable b_dt_5 = (DataTable)b_ds.Tables[5];
            DataTable b_dt_6 = (DataTable)b_ds.Tables[6];
            DataTable b_dt_7 = (DataTable)b_ds.Tables[7];
            bang.P_SO_CNG(ref b_dt, "ngay_nop,ngay_tthuan,ngay_tt,ngay_pd,ngay_ky");
            bang.P_SO_CSO(ref b_dt, "tien_phep,tien_bh_daotao,truythu_tamung,ht_nghiviec,khoan_khac,htro_khac");

            var b_nam = b_dt.Rows[0]["nam"];
            if (b_dt.Rows[0]["nam"].ToString() != "")
            {
                DataTable b_dt_kyluong = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
                if (b_dt_kyluong.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_kyluong, new object[] { "", "" }, 0);
                se.P_TG_LUU("ns_tv", "DT_KY", b_dt_kyluong.Copy());
            }

            bang.P_TIM_THEM(ref b_dt, "ns_tv", "DT_LD_NV", "lydo_nv");
            bang.P_TIM_THEM(ref b_dt, "ns_tv", "DT_NAM", "nam");
            bang.P_TIM_THEM(ref b_dt, "ns_tv", "DT_KY", "ky_luong");

            bang.P_SO_CNG(ref b_dt_1, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_2, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_3, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_4, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_5, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_6, "ngay_bg");
            bang.P_SO_CNG(ref b_dt_7, "ngay_bg");

            return (bang.Fb_TRANG(b_dt)) ? "" :
                bang.Fs_HANG_GOP(b_dt, 0) + "#" +
                bang.Fs_BANG_CH(b_dt_1, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_2, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_3, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_4, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_5, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_6, a_cot_hc) + "#" +
                bang.Fs_BANG_CH(b_dt_7, a_cot_hc);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_THOIVIEC_XOA(string b_login,
                                     string b_so_the,
                                     string b_ngay_d,
                                     string b_ngay_c,
                                     string b_phong,
                                     string b_so_the_tk,
                                     string b_ten,
                                     double[] a_tso,
                                     string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.P_NS_THOIVIEC_XOA(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_TV, TEN_BANG.NS_TV);
            return Fs_NS_THOIVIEC_LKE(b_login, b_ngay_d, b_ngay_c, b_phong, b_so_the_tk, b_ten, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion QUẢN LÝ NGHỈ VIỆC

    #region PHÊ DUYỆT DANH SÁCH NÂNG LƯƠNG
    [WebMethod(true)]
    public string Fs_NS_QT_DEBATPD_LKE(double tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fs_NS_QT_DEBATPD_LKE(tinhtrang, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_lap");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_QT_DEBATPD_PHEDUYET(double b_tinhtrang, double tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_tinhtrang == 1 && tinhtrang == 1)
            {
                return "loi:Dữ liệu ở trạng thái phê duyệt:loi";
            }
            ns_qt.Fs_NS_QT_DEBATPD_PHEDUYET(tinhtrang);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion

    #region DANH SÁCH NÂNG LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_QT_DEBAT_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fs_NS_QT_DEBAT_LKE(b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            DataTable b_dt_lke = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt, "ngay_lap");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + bang.Fs_BANG_CH(b_dt_lke, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_DEBAT_MA(string b_ngay_lap, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_qt.Fdt_NS_QT_DEBAT_MA(b_ngay_lap, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            bang.P_SO_CNG(ref b_dt, "NGAY_LAP");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "ngay_lap" }, new object[] { b_ngay_lap });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_DEBAT_NH(double b_trangKT, double[] a_tso, object[] a_dt_ct, string[] a_cot_lke, object[] a_dt_grid)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] a_gtri = (object[])a_dt_grid[1];
            string thang_bd = chuyen.Fas_OBJ_STR((object[])a_dt_ct[1])[0];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_THEM_COL(ref b_dt_ct, "ngay_lap", thang_bd);

            bang.P_CNG_SO(ref b_dt_ct, "ngay_lap");
            bang.P_CSO_SO(ref b_dt_ct, "luong,hspc,hso");
            ns_qt.Fs_NS_QT_DEBAT_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_DEBAT, TEN_BANG.NS_QT_DEBAT);
            return Fs_NS_QT_DEBAT_LKE(a_tso, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_DEBAT_XOA(double[] a_tso, string[] a_cot, double b_so_id)
    {
        try
        {
            ns_qt.Fs_NS_QT_DEBAT_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_QT_DEBAT, TEN_BANG.NS_QT_DEBAT);
            return Fs_NS_QT_DEBAT_LKE(a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_QT_DEBAT_CT(string b_ngay_lap, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ns_qt.Fs_NS_QT_DEBAT_CT(b_ngay_lap);
            bang.P_SO_CNG(ref b_dt, "ngay_lap");
            bang.P_SO_CSO(ref b_dt, "luong");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion KHAI BÁO ĐÓNG MỚI

    #region PHÊ DUYỆT ĐIỀU CHUYỂN
    [WebMethod(true)]
    public string Fs_NS_CPPD_LKE(string a_tinhtrang, double[] a_tso, string[] a_cot)
    {
        try
        {

            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_CPPD_LKE(a_tinhtrang, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];

            bang.P_THEM_COL(ref b_dt_tk, "chon", "");
            bang.P_SO_CNG(ref b_dt_tk, new string[] { "ngayd" });
            bang.P_CSO_SO(ref b_dt_tk, "luong");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CPPD_PHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            if (b_dt_ct.Rows.Count <= 0 || b_dt_ct == null)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "luong");
            ns_qt.Fdt_NS_CPPD_PHEDUYET(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_CPPD, TEN_BANG.NS_CPPD);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.Pheduyet_thatbai; }

    }

    [WebMethod(true)]
    public string Fs_NS_CPPD_HUYPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            if (b_dt_ct.Rows.Count <= 0 || b_dt_ct == null)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            ns_qt.Fdt_NS_CPPD_HUYPHEDUYET(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.PD, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_CPPD, TEN_BANG.NS_CPPD);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.HuyPheduyet_thatbai; }
    }

    [WebMethod(true)]
    public string Fs_NS_CPPD_KOPHEDUYET(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct);
            if (b_dt_ct.Rows.Count <= 0 || b_dt_ct == null)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            bang.P_CSO_SO(ref b_dt_ct, "luong");
            ns_qt.Fdt_NS_CPPD_KOPHEDUYET(b_dt_ct);
            return "";
        }
        catch (Exception ex) { return Thongbao_dch.koPheduyet_thatbai; }
    }
    #endregion PHÊ DUYỆT ĐIỀU CHUYỂN

    #region DANH SÁCH ĐEN
    [WebMethod(true)]
    public string Fs_NS_DS_DEN_LKE(string b_login, double[] a_tso, string[] a_cot, string b_so_the, string b_ten, string b_phong)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_Fs_NS_DS_DEN_LKE(b_tu_n, b_den_n, b_so_the, b_ten, b_phong);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_vao,ngay_nop,ngaynghi");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DS_DEN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_qt.Fdt_Fs_NS_DS_DEN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DS_DEN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_qt.P_Fs_NS_DS_DEN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_DS_DEN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DS_DEN_XOA(string b_ma, double[] a_tso, string[] a_cot, string a_phong, string a_so_the, string b_tu_ngay, string b_den_ngay, string b_lydo)
    {
        try { ns_qt.P_Fs_NS_DS_DEN_XOA(b_ma); return Fs_NS_DS_DEN_LKE("", a_tso, a_cot, a_so_the, "", a_phong); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion DANH SÁCH ĐEN

    #region PHÊ DUYỆT DANH SÁCH NGHỈ VIỆC
    public static object[] Fdt_NS_QT_NGHIVIEC_PD_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_QT_NGHIVIEC_PD_LKE");
    }
    public static DataTable P_NS_QT_NGHIVIEC_PD_NH(string b_tinhtrang, DataTable b_dt)
    {
        DataTable b_kq = null;
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            b_kq = dbora.Fdt_LKE_S(new object[] {  chuyen.OBJ_S(b_tinhtrang),b_dr["so_the"], chuyen.OBJ_S(b_dr["ngay_pd"]),chuyen.OBJ_S(b_dr["ql_lydo1"]), chuyen.OBJ_S(b_dr["ql_lydo2"]), chuyen.OBJ_S(b_dr["ql_lydo3"]), chuyen.OBJ_S(b_dr["ql_lydo4"]), chuyen.OBJ_S(b_dr["ql_lydo5"]),
                chuyen.OBJ_S(b_dr["ql_lydo_khac"]), chuyen.OBJ_S(b_dr["ql_lydo_chitiet"]),chuyen.OBJ_S(b_dr["ktd"]),chuyen.OBJ_S(b_dr["lydo_ktd"]),chuyen.OBJ_S(b_dr["giu_lai"]),chuyen.OBJ_S(b_dr["dcl"]),chuyen.OBJ_S(b_dr["mdc"]),chuyen.OBJ_S(b_dr["dexuat"])}, "PNS_QT_NGHIVIEC_PD_NH");
        }
        return b_kq;
    }
    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_PHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_id,:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIVIEC_PD_PHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_KOPHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_QT_NGHIVIEC_PD_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_QT_NGHIVIEC_PD_CT(string b_so_the)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the }, "pNS_QT_NGHIVIEC_pd_ct");
    }

    #endregion PHÊ DUYỆT DANH SÁCH NGHỈ PHÉP

    #region  NGHỈ VIỆC -CORP
    public static object[] Fdt_NS_THOIVIEC_LKE(string a_tinhtrang, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { a_tinhtrang, b_tu, b_den }, "NR", "PNS_TV_LKE");
    }
    public static string P_NS_THOIVIEC_NH(string b_so_id, DataTable b_dt, DataTable b_tailieu, DataTable b_thietbi, DataTable b_taisan)
    {
        if (b_dt.Rows.Count > 0)
        {
            se.se_nsd b_se = new se.se_nsd();
            OracleConnection b_cnn = dbora.Fcn_KNOI();
            try
            {
                OracleCommand b_lenh = new OracleCommand();
                b_lenh.Connection = b_cnn;
                DataRow b_dr = b_dt.Rows[0];
                dbora.P_THEM_PAR(ref b_lenh, "so_id", 'N', 'O', chuyen.OBJ_N(b_so_id));

                object[] a_tailieu = bang.Fobj_COL_MANG(b_tailieu, "ten_tailieu");
                object[] a_ng_nhan = bang.Fobj_COL_MANG(b_tailieu, "ng_nhan");
                object[] a_ngay_bg = bang.Fobj_COL_MANG(b_tailieu, "ngay_bg");
                object[] a_file_duongdan = bang.Fobj_COL_MANG(b_tailieu, "file_duongdan");

                dbora.P_THEM_PAR(ref b_lenh, "a_ten_tl", 'U', a_tailieu);
                dbora.P_THEM_PAR(ref b_lenh, "a_ng_nhan", 'U', a_ng_nhan);
                dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bg", 'N', a_ngay_bg);
                dbora.P_THEM_PAR(ref b_lenh, "a_file_duongdan", 'S', a_file_duongdan);

                object[] a_ma = bang.Fobj_COL_MANG(b_thietbi, "ma");
                object[] a_ten_tb = bang.Fobj_COL_MANG(b_thietbi, "ten_tb");
                object[] a_soluong = bang.Fobj_COL_MANG(b_thietbi, "soluong");
                object[] a_sotien = bang.Fobj_COL_MANG(b_thietbi, "sotien");
                object[] a_ngay_cap = bang.Fobj_COL_MANG(b_thietbi, "ngay_cap");
                object[] a_tinhtrang_tb = bang.Fobj_COL_MANG(b_thietbi, "tinhtrang_tb");
                object[] a_ghichu = bang.Fobj_COL_MANG(b_thietbi, "ghichu");

                dbora.P_THEM_PAR(ref b_lenh, "a_ma_tb", 'S', a_ma);
                dbora.P_THEM_PAR(ref b_lenh, "a_ten_tb", 'U', a_ten_tb);
                dbora.P_THEM_PAR(ref b_lenh, "a_sl_tb", 'N', a_soluong);
                dbora.P_THEM_PAR(ref b_lenh, "a_st_tb", 'N', a_sotien);
                dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cap_tb", 'N', a_ngay_cap);
                dbora.P_THEM_PAR(ref b_lenh, "a_tt_tb", 'S', a_tinhtrang_tb);
                dbora.P_THEM_PAR(ref b_lenh, "a_ghichu_tb", 'U', a_ghichu);

                object[] a_ma_ts = bang.Fobj_COL_MANG(b_taisan, "ma");
                object[] a_ten_taisan = bang.Fobj_COL_MANG(b_taisan, "ten_taisan");
                object[] a_soluong_ts = bang.Fobj_COL_MANG(b_taisan, "soluong");
                object[] a_ngay_cap_ts = bang.Fobj_COL_MANG(b_taisan, "ngay_cap");
                object[] a_tinhtrang_ts = bang.Fobj_COL_MANG(b_taisan, "tinhtrang_ts");

                dbora.P_THEM_PAR(ref b_lenh, "a_ma_ts", 'S', a_ma_ts);
                dbora.P_THEM_PAR(ref b_lenh, "a_ten_ts", 'U', a_ten_taisan);
                dbora.P_THEM_PAR(ref b_lenh, "a_sl_ts", 'N', a_soluong_ts);
                dbora.P_THEM_PAR(ref b_lenh, "a_ngay_cap_ts", 'N', a_ngay_cap_ts);
                dbora.P_THEM_PAR(ref b_lenh, "a_tt_ts", 'S', a_tinhtrang_ts);

                string b_c = ",:so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["ho_ten"]) + "," + chuyen.OBJ_S(b_dr["ngay_nop"]) + "," + chuyen.OBJ_S(b_dr["ngay_xin"]) + "," + chuyen.OBJ_S(b_dr["ngay_tt"]) + "," + chuyen.OBJ_C(b_dr["lydo1"]) + "," +
                                chuyen.OBJ_C(b_dr["lydo2"]) + "," + chuyen.OBJ_C(b_dr["lydo3"]) + "," + chuyen.OBJ_C(b_dr["lydo4"]) + "," + chuyen.OBJ_C(b_dr["lydo5"]) + "," +
                                chuyen.OBJ_C(b_dr["lydo_khac"]) + "," + chuyen.OBJ_C(b_dr["lydo_chitiet"]) + "," + chuyen.OBJ_C(b_dr["ml_khl"]) + "," + chuyen.OBJ_C(b_dr["ml_hl"]) + "," +
                                chuyen.OBJ_C(b_dr["ml_rhl"]) + "," + chuyen.OBJ_C(b_dr["ql_khl"]) + "," + chuyen.OBJ_C(b_dr["ql_hl"]) + "," + chuyen.OBJ_C(b_dr["ql_rhl"]) + "," + chuyen.OBJ_C(b_dr["mt_khl"]) + "," +
                                chuyen.OBJ_C(b_dr["mt_hl"]) + "," + chuyen.OBJ_C(b_dr["mt_rhl"]) + "," + chuyen.OBJ_C(b_dr["ch_khl"]) + "," + chuyen.OBJ_C(b_dr["ch_hl"]) + "," + chuyen.OBJ_C(b_dr["ch_rhl"]) + "," +
                                chuyen.OBJ_C(b_dr["gopy"]) + "," + chuyen.OBJ_C(b_dr["tinhtrang"]) + "," + chuyen.OBJ_S(b_dr["ngay_pd"]) + "," + chuyen.OBJ_C(b_dr["ql_lydo1"]) + "," + chuyen.OBJ_C(b_dr["ql_lydo2"]) + "," +
                                chuyen.OBJ_C(b_dr["ql_lydo3"]) + "," + chuyen.OBJ_C(b_dr["ql_lydo4"]) + "," + chuyen.OBJ_C(b_dr["ql_lydo5"]) + "," + chuyen.OBJ_C(b_dr["ql_lydo_khac"]) + "," +
                                chuyen.OBJ_C(b_dr["ql_lydo_chitiet"]) + "," + chuyen.OBJ_C(b_dr["ktd"]) + "," + chuyen.OBJ_C(b_dr["lydo_ktd"]) + "," + chuyen.OBJ_C(b_dr["giu_lai"]) + "," + chuyen.OBJ_C(b_dr["dcl"]) + "," +
                                chuyen.OBJ_S(b_dr["mdc"]) + "," + chuyen.OBJ_C(b_dr["dexuat"]) + "," + chuyen.OBJ_S(b_dr["trocap_thoiviec"]) + "," + chuyen.OBJ_C(b_dr["tien_bh_daotao"]) + "," + chuyen.OBJ_C(b_dr["tien_thuong"]) + "," +
                                chuyen.OBJ_C(b_dr["truythu_tamung"]) + "," + chuyen.OBJ_C(b_dr["truythu_nghiphep"]) + "," + chuyen.OBJ_C(b_dr["khoan_khac"]) + "," + chuyen.OBJ_C(b_dr["so_qd"]) + "," + chuyen.OBJ_C(b_dr["nguoi_ky"]) + "," +
                                chuyen.OBJ_C(b_dr["tinhtrang"]) + "," + chuyen.OBJ_C(b_dr["cdanh_ky"]) + "," + chuyen.OBJ_S(b_dr["ngay_ky"]);
                b_c = b_c + ",:a_ten_tl,:a_ng_nhan,:a_ngay_bg,:a_file_duongdan,:a_ma_tb,:a_ten_tb,:a_sl_tb,:a_st_tb,:a_ngay_cap_tb,:a_tt_tb,:a_ghichu_tb,:a_ma_ts,:a_ten_ts,:a_sl_ts,:a_ngay_cap_ts,:a_tt_ts";
                b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TV_NH(" + b_se.tso + b_c + "); end;";
                try
                {
                    b_lenh.ExecuteNonQuery();
                    return b_so_id = chuyen.OBJ_S(b_lenh.Parameters["so_id"].Value);
                }
                finally { b_lenh.Parameters.Clear(); }
            }
            finally { b_cnn.Close(); }
        }
        return "";
    }
    public static DataTable Fdt_NS_THOIVIEC_PHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_id = bang.Fobj_COL_MANG(b_dt_ct, "so_id");
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'S', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_id,:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TV_PHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataTable Fdt_NS_THOIVIEC_KOPHEDUYET(string b_tinhtrang, DataTable b_dt, DataTable b_dt_ct)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            object[] a_so_the = bang.Fobj_COL_MANG(b_dt_ct, "so_the");
            object[] a_ngayxn = bang.Fobj_COL_MANG(b_dt_ct, "ngayxn");
            object[] a_ngayd = bang.Fobj_COL_MANG(b_dt_ct, "ngayd");
            object[] a_ykien = bang.Fobj_COL_MANG(b_dt_ct, "ykien");

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'U', a_so_the);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayxn", 'U', a_ngayxn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngayd", 'U', a_ngayd);
            dbora.P_THEM_PAR(ref b_lenh, "a_ykien", 'U', a_ykien);

            // thêm con trỏ vào biến
            dbora.P_THEM_PAR(ref b_lenh, "cs_1", 'R');

            string b_c = "," + chuyen.OBJ_C(b_tinhtrang) + ",:a_so_the,:a_ngayxn,:a_ngayd,:a_ykien,:cs_1";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TV_KOPHEDUYET(" + b_se.tso + b_c + "); end;";
            try
            {
                //b_lenh.ExecuteNonQuery();
                DataTable b_dt_kq = dbora.Fdt_TRA(b_lenh);
                return b_dt_kq;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fdt_NS_THOIVIEC_CT(string b_so_id)
    {
        return dbora.Fds_LKE(b_so_id, 4, "PNS_TV_CT");
    }
    public static DataSet Fdt_NS_XUAT_EXCEL(string b_so_the, string b_trangthai)
    {
        return dbora.Fds_LKE(new object[] { b_so_the, b_trangthai }, 4, "PNS_TV_XUATEXCEL");
    }
    public static void PNS_THOIVIEC_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(chuyen.CSO_SO(b_so_id), "PNS_THOIVIEC_XOA");
    }
    #endregion PHÊ DUYỆT DANH SÁCH NGHỈ PHÉP

    #region QUẢN LÝ LAO ĐỘNG THEO DỰ ÁN

    [WebMethod(true)]
    public string Fs_NS_LD_DA_NH(string b_login, string b_so_id, string b_ten_da, double b_trangKT, object[] a_dt_ct, object[] a_dt_luoi, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt, "ngay_tl");

            string[] a_cot_luoi = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); object[] a_gtri_luoi = (object[])a_dt_luoi[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_luoi, a_gtri_luoi);
            bang.P_BO_HANG(ref b_dt_ct, "SO_THE", "");
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0) { return Thongbao_dch.vuilong; }
            bang.P_CNG_SO(ref b_dt_ct, "ngayd,ngayc");

            b_so_id = ns_qt.P_NS_LD_DA_NH(ref b_so_id, b_dt, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_LD_DA, TEN_BANG.NS_LD_DA);
            return Fs_NS_LD_DA_MA(b_login, b_so_id, b_ten_da, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_LD_DA_MA(string b_login, string b_so_id, string b_ten_da, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_obj = ns_qt.Faobj_NS_LD_DA_MA(b_so_id, b_ten_da, b_trangkt);
            DataTable b_dt = (DataTable)a_obj[2];
            bang.P_SO_CNG(ref b_dt, "ngay_tl");

            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_LD_DA_LKE(string b_login, string b_ten_da, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_obj = ns_qt.Faobj_NS_LD_DA_LKE(b_ten_da, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_tl");
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


    [WebMethod(true)]
    public string Fs_NS_LD_DA_CT(string b_login, string b_so_id, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataSet b_ds = ns_qt.Fds_NS_LD_DA_CT(b_so_id);
            DataTable b_dt = (DataTable)b_ds.Tables[0];
            DataTable b_dt_ct = (DataTable)b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt_ct, "ngayd,ngayc");
            bang.P_SO_CNG(ref b_dt, "ngay_tl");
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            string b_dt_tt_s = bang.Fb_TRANG(b_dt_ct) ? "" : bang.Fs_BANG_CH(b_dt_ct, a_cot);
            return b_dt_s + "#" + b_dt_tt_s;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_LD_DA_XOA(string b_login, string b_so_id, string b_ten_da, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_qt.P_NS_LD_DA_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_LD_DA, TEN_BANG.NS_LD_DA);
            return Fs_NS_LD_DA_LKE(b_login, b_ten_da, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion QUẢN LÝ LAO ĐỘNG THEO DỰ ÁN

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_LKE(string b_phong, string a_tinhtrang, string b_tungay, string b_denngay, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_dt.Fdt_NS_DT_DEXUAT_PD_LKE(b_phong, a_tinhtrang, b_tungay, b_denngay, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1]; bang.P_THEM_COL(ref b_dt_tk, "chon", "");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_PHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            bang.P_CSO_SO(ref b_dt_ct, "so_id");
            DataTable b_kq = ns_dt.Fdt_NS_DT_DEXUAT_PD_PHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            string b_guimail = "", b_subject = "", b_body = "";
            //if (b_kq.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[0]["email"]);
            //    string b_subject = chuyen.OBJ_S(b_kq.Rows[0]["ten"]) + " - Có đơn nghỉ phép cần phê duyệt";
            //    string b_body = "Bạn có đơn nghỉ phép cần được phê duyệt. \nVui lòng đăng nhập vào chương trình http://nagase.cerp.vn để phê duyệt! \n";
            //    b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
            //}
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.Pheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_PD_KOPHEDUYET(string b_phong, string b_tinhtrang, string b_tungay, string b_denngay, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "chon", "");
            DataTable b_dt = bang.Fdt_TAO_BANG("loai", "S"); bang.P_THEM_HANG(ref b_dt, new object[] { "DX" });
            if (b_dt_ct == null || b_dt_ct.Rows.Count <= 0)
            {
                return Thongbao_dch.vuilong;
            }
            for (int i = 0; i < b_dt_ct.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(b_dt_ct.Rows[i]["lydo_ld"].ToString()))
                {
                    return "loi:Bạn phải nhập lý do không phê duyệt của nhân viên " + b_dt_ct.Rows[i]["ho_ten"].ToString() + ":loi";
                }
            }
            DataTable b_kq = ns_dt.Fdt_NS_DT_DEXUAT_PD_KOPHEDUYET(b_phong, b_tinhtrang, b_tungay, b_denngay, b_dt, b_dt_ct);
            string b_guimail = "", b_subject = "", b_body = "";
            if (b_kq.Rows.Count > 0)
            {
                for (int i = 0; i < b_kq.Rows.Count; i++)
                {
                    string b_toAddress = chuyen.OBJ_S(b_kq.Rows[i]["email"]);
                    if (b_tinhtrang == "1")
                    {
                        b_subject = "Your Application has been approved.";
                        b_body = "Your Application has been approved.\n";
                    }
                    else
                    {
                        b_subject = "Your application has been rejected.";
                        b_body = "Your application has been rejected.\n";
                    }
                    //SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                    //b_guimail = b_toAddress + ";" + b_subject + ";" + b_body;
                }
            }
            return "";
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("loi")) return form.Fs_LOC_LOI(ex.Message);
            else return Thongbao_dch.koPheduyet_thatbai;
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_DEXUAT_GUI(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login); ns_dt.P_NS_DT_DEXUAT_GUI(b_so_the); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO

    #region ĐÁNH GIÁ HỢP ĐỒNG LAO ĐỘNG

    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_LKE(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_NS_DG_HDLD_LKE(b_so_the_tk, b_ten_tk, b_phong_tk, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];

            bang.P_SO_CNG(ref b_dt_tk, "ngay_hl,ngay_hhl");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_MA(string b_login,
                                   string b_so_the_tk,
                                   string b_ten_tk,
                                   string b_phong_tk,
                                   string b_so_id,
                                   double b_trangkt,
                                   string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_qt.Fdt_NS_DG_HDLD_MA(b_so_the_tk, b_ten_tk, b_phong_tk, b_so_id, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_hhl");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_CT(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_DG_HDLD_CT(b_so_the);
            bang.P_TIM_THEM(ref b_dt, "ns_dg_hopdong", "DT_KQ", "ketqua");
            bang.P_TIM_THEM(ref b_dt, "ns_dg_hopdong", "DT_HD", "hd_tiep");
            bang.P_SO_CNG(ref b_dt, "ngay_nhap,ngay_hl,ngay_hhl");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_hl,ngay_hhl");
            ns_qt.P_NS_DG_HDLD_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_DG_HDLD, TEN_BANG.NS_DG_HDLD);
            return Fs_NS_DG_HDLD_MA(b_login, "", "", "", b_so_id, b_trangKT, a_cot_lke);
        }

        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_XOA(string b_login, string b_so_the_tk, string b_ten_tk, string b_phong_tk, string b_so_id, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_qt.PNS_DG_HDLD_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CC, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_DG_HDLD, TEN_BANG.NS_DG_HDLD);
            return Fs_NS_DG_HDLD_LKE(b_login, b_so_the_tk, b_ten_tk, b_phong_tk, a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }


    [WebMethod(true)]
    public string Fs_NS_DG_HDLD_HOPDONG(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_NS_DG_HDLD_HOPDONG(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_hl,ngay_hhl");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    #endregion

    #region ĐĂNG KÝ LÀM VIỆC NGOÀI CÔNG TY

    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_LKE(string b_login, string b_so_the, string b_nam, string b_ky_luong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_CC_DKY_LVIEC_NGOAICTY_LKE(b_so_the, b_nam, b_ky_luong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "1", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "2", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "3", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_MA(string b_login, string b_so_id, string b_so_the, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_CC_DKY_LVIEC_NGOAICTY_MA(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            bang.P_THAY_GTRI(ref b_dt, "TT", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "TT", "1", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TT", "2", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TT", "3", "Không phê duyệt");
            return b_hang.ToString() + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_CT(string b_login, string b_so_the, string b_ngay_dky)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_CC_DKY_LVIEC_NGOAICTY_CT(b_so_the, b_ngay_dky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null)
                se.P_LOGIN(b_login);
            ns_qt.P_CC_DKY_LVIEC_NGOAICTY_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_QT_LVIEC_NGOAICTY, TEN_BANG.NS_QT_LVIEC_NGOAICTY);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];

            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            ns_qt.P_CC_DKY_LVIEC_NGOAICTY_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_LVIEC_NGOAICTY, TEN_BANG.NS_QT_LVIEC_NGOAICTY);
            DataRow b_dr = b_dt_ct.Rows[0];
            return Fs_CC_DKY_LVIEC_NGOAICTY_MA(b_login, b_so_id, b_dr["so_the"].ToString(), a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_LVIEC_NGOAICTY_XOA(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            ns_qt.PCC_DKY_LVIEC_NGOAICTY_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_QT_LVIEC_NGOAICTY, TEN_BANG.NS_QT_LVIEC_NGOAICTY);
            return Fs_CC_DKY_LVIEC_NGOAICTY_LKE(b_login, b_so_the, "", "", a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion

    #region ĐĂNG KÝ CA NUÔI CON NHỎ

    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_LKE(string b_login, string b_so_the, string b_nam, string b_ky_luong, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu = chuyen.OBJ_N(a_tso[0]);
            double b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_qt.Fdt_CC_DKY_NCN_LKE(b_so_the, b_nam, b_ky_luong, b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_SO_CNG(ref b_dt_tk, "ngay_dky");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "1", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "2", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt_tk, "TT", "3", "Không phê duyệt");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_MA(string b_login, string b_so_id, string b_so_the, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_CC_DKY_NCN_MA(b_so_the);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");
            int b_hang = bang.Fi_TIM_ROW(b_dt, new string[] { "so_id" }, new object[] { b_so_id });
            bang.P_THAY_GTRI(ref b_dt, "TT", "0", "Chưa gửi");
            bang.P_THAY_GTRI(ref b_dt, "TT", "1", "Chưa phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TT", "2", "Đã phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "TT", "3", "Không phê duyệt");
            return b_hang.ToString() + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_CT(string b_login, string b_so_the, string b_ngay_dky)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            DataTable b_dt = ns_qt.Fdt_CC_DKY_NCN_CT(b_so_the, b_ngay_dky);
            bang.P_SO_CNG(ref b_dt, "ngay_dky");

            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_GUI(string b_login, string b_so_id)
    {
        try
        {
            if (b_login != null)
                se.P_LOGIN(b_login);
            ns_qt.P_CC_DKY_NCN_GUI(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_QT_DK_NCN, TEN_BANG.NS_QT_DKY_NCN);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_NH(string b_login, string b_so_id, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];

            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, "ngay_dky");
            ns_qt.P_CC_DKY_NCN_NH(ref b_so_id, b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_QT_DK_NCN, TEN_BANG.NS_QT_DKY_NCN);
            DataRow b_dr = b_dt_ct.Rows[0];
            return Fs_CC_DKY_NCN_MA(b_login, b_so_id, b_dr["so_the"].ToString(), a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_CC_DKY_NCN_XOA(string b_login, string b_so_id, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "")
                se.P_LOGIN(b_login);
            ns_qt.PCC_DKY_NCN_XOA(b_so_id);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_QT_DK_NCN, TEN_BANG.NS_QT_DKY_NCN);
            return Fs_CC_DKY_NCN_LKE(b_login, b_so_the, "", "", a_tso, a_cot);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    #endregion
}
