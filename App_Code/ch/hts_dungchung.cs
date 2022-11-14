using System;
using System.Data;
using System.Web;
using Cthuvien;
using System.Web.Services;
using System.Collections.Generic;
using System.Web.Script.Serialization;

#region HÀM DÙNG CHUNG
[System.Web.Script.Services.ScriptService]
public class hts_dungchung : System.Web.Services.WebService
{
    // Hàm ghi log cả hệ thống
    [WebMethod(true)]
    public static void PHT_LOG_NH(string b_phanhe, string b_nhom_cnang, string b_thao_tac, string b_chucnang, string b_bang_dl)
    {
        try
        {
            ht_dungchung.PHT_LOG(b_phanhe, b_nhom_cnang, b_thao_tac, b_chucnang, b_bang_dl);
        }
        catch (Exception)
        {
            throw;
        }
    }

    // Lấy năm theo kỳ công

    [WebMethod(true)]
    public void Fs_NS_KYLUONG_LKE_BYNAM(string b_login, string b_form, string b_ktra, double b_nam)
    {
        if (b_login != null) se.P_LOGIN(b_login);
        DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(b_nam);
        DataTable b_dt_ky = b_dt.Copy();
        bang.P_DOI_TENCOL(ref b_dt_ky, "SO_ID", "MA");
        se.P_TG_LUU(b_form, b_ktra, b_dt_ky.Copy());
    }
    [WebMethod(true)]
    public static DataTable Fdt_MA_KYLUONG_NAM_XEM()
    {
        return ht_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
    }

    [WebMethod(true)]
    public static DataTable Fdt_MA_KYLUONG_BY_NAM()
    {
        return ht_dungchung.Fdt_MA_KYLUONG_BY_NAM();
    }

    [WebMethod(true)]
    public string Fdt_MA_KYLUONG_BY_NAM_THANG(string b_nam, string b_thang)
    {
        var b_dt = ht_dungchung.Fdt_MA_KYLUONG_BY_NAM_THANG(b_nam, b_thang);
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }

    public static string DataTableToJSON2(DataTable table)
    {
        var list = new List<Dictionary<string, object>>();

        foreach (DataRow row in table.Rows)
        {
            var dict = new Dictionary<string, object>();

            foreach (DataColumn col in table.Columns)
            {
                if (col.ColumnName == "NAME")
                {
                    dict[col.ColumnName] = (Convert.ToString(row[col])) + " nhân sự)";
                }
                else
                {
                    dict[col.ColumnName] = row[col];
                }
            }
            list.Add(dict);
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();

        return serializer.Serialize(list);
    }
    [WebMethod(true)]
    public string Fs_NS_KT_NAM(string b_form, string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_KYLUONG", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KT_NAM_TK(string b_form, string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_KYLUONG_TK", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public void Fs_NS_KT_SO_THE_THE_PHONG(string b_form, string b_so_the_dk, string b_phong, string b_ktra)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_SO_THE_THEP_PHONG(b_so_the_dk, b_phong);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, b_ktra, b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.ToString()); }
    }

    /// <summary>
    /// Lấy năm, kỳ lương mặc định
    /// </summary>
    /// <param name="b_login"></param>
    /// <param name="b_form"></param>
    /// <param name="b_ktra_nam"></param>
    /// <param name="b_ktra_thang"></param>
    /// <returns></returns>
    [WebMethod(true)]
    public string Fs_NS_CC_KY(string b_login, string b_form, string b_ktra_nam, string b_ktra_thang)
    {
        string b_ten_truong = "KYLUONG_ID";
        se.P_LOGIN(b_login);
        DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG_NAM();
        DataTable b_dtt = null;
        int iNam = 0;
        string ngay_bd = "", ngay_kt = "", ithang = "", iTenThang = "", b_kq = "phong,nam,kyluong,NGAYD,NGAYKT,cong_chuan;";
        if (b_form == "tl_giuluong" || b_form == "ns_tl_vipham" || b_form == "ns_cc_thongtin_nghi" || b_form == "ns_cc_gt") b_kq = "phong,nam_tk,kyluong_tk,NGAYD,NGAYKT,cong_chuan;";
        b_kq = b_kq + "TATCA{Tất cả|";
        //se.P_TG_LUU(b_form, b_ktra_nam, b_dt.Copy());
        if (b_dt.Select("SHOW = 1").Length > 0)
        {
            iNam = DateTime.Now.Year;
            b_kq = b_kq + iNam + "{" + iNam;
            b_dtt = hts_dungchung.Fdt_MA_KYLUONG(iNam);
            if (b_dtt.Select("SHOW = 1").Length > 0)
            {
                ithang = b_dtt.Select("SHOW = 1")[0]["SO_ID"].ToString();
                iTenThang = b_dtt.Select("SHOW = 1")[0]["TEN"].ToString();
                b_kq = b_kq + "|" + ithang + "{" + iTenThang;
                ngay_bd = b_dtt.Select("SHOW = 1")[0]["NGAY_BD"].ToString();
                ngay_kt = b_dtt.Select("SHOW = 1")[0]["NGAY_KT"].ToString();
                b_kq = b_kq + "|" + chuyen.SO_CNG(chuyen.OBJ_I(ngay_bd)) + "|" + chuyen.SO_CNG(chuyen.OBJ_I(ngay_kt)).ToString() + "|0";
            }
            else
            {
                b_kq = b_kq + "|{|||0";
            }
            se.P_TG_LUU(b_form, b_ktra_thang, b_dtt.Copy());
        }
        else
        {
            return "";
        }
        return b_kq;
    }
    // Lấy năm theo kỳ công
    [WebMethod(true)]
    public static DataTable Fdt_MA_KYLUONG_NAM()
    {
        return ht_dungchung.Fdt_MA_KYLUONG_NAM();
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm
    [WebMethod(true)]
    public void P_MA_KDT_NAM(string b_form, string b_nam, string b_noidung)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, b_noidung);
            if (b_dt.Rows.Count > 0) se.P_TG_LUU(b_form, "DT_KDT", b_dt.Copy());
            else se.P_TG_LUU(b_form, "DT_KDT", null);
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và nội dung
    [WebMethod(true)]
    public void Fs_NS_MA_KDT_DT_NAM(string b_form, string b_bien, string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, "");
            se.P_TG_LUU(b_form, b_bien, b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và tháng ở form nhu cầu
    [WebMethod(true)]
    public void P_MA_KDT_NHUCAU(string b_form, string b_nam, string b_thang)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KDT_NHUCAU(b_nam, b_thang);
            se.P_TG_LUU(b_form, "DT_NHUCAU", b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và tháng ở form kế hoạch đào tạo năm
    [WebMethod(true)]
    public void Fs_NS_MA_KDT_KH_NAM(string b_form, string b_bien, string b_nam, string b_thang)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KDT_KH_NAM(b_nam, b_thang);
            se.P_TG_LUU(b_form, b_bien, b_dt.Copy());
        }
        catch (Exception ex) { form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_DT_KDT_NAM(string b_form, string b_nam)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_KDT_NAM(b_nam, "");
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_KDT", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_PHONG_CDANH(string b_form, string b_phong)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_CDANH", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_PHONG_CDANH_KN(string b_login, string b_congty, string b_phong, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            se.se_nsd b_se = new se.se_nsd();
            if (b_congty == "") b_congty = b_se.ma_dvi;
            object[] a_obj = ht_dungchung.Fdt_MA_CDANH_BY_PHONG_DR_GR(b_congty, b_phong, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_CDANH_BY_CTY(string b_login, string b_congty, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ht_dungchung.Fdt_NS_MA_CDANH_BY_CTY(b_congty, a_tso[0], a_tso[1]);
            DataTable b_dt = (DataTable)a_obj[1];
            return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_KYLUONG_CHUNG_LKE(string b_login, string b_form, string b_nam)
    {
        try
        {
            if (b_login != null) se.P_LOGIN(b_login);
            DataTable b_dt = ht_dungchung.Fdt_MA_KYLUONG(chuyen.OBJ_N(b_nam));
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_KY", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public static DataTable Fhdns_NAM()
    {
        return ht_dungchung.Fhdns_NAM();
    }
    [WebMethod(true)]
    public static DataTable Fdt_MA_KYLUONG(int b_nam)
    {
        return ht_dungchung.Fdt_MA_KYLUONG(b_nam);
    }
    [WebMethod(true)]
    public static DataTable Fdt_MA_PHONG_LKE()
    {
        return ht_dungchung.Fdt_MA_PHONG_LKE();
    }
    [WebMethod(true)]
    public string Fdt_MA_PHONG_LKE_GR(string[] a_cot_gr)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_LKE();
            bang.P_DOI_TENCOL(ref b_dt, new string[] { "MA", "TEN" }, new string[] { "MA_PHONG", "TEN_PHONG" });
            bang.P_THEM_COL(ref b_dt, new string[] { "SO_TIEN" }, new string[] { "0" });
            string b_dt_s = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_gr);
            return b_dt.Rows.Count + "#" + b_dt_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public void Fdt_MA_PHONG_LKE_BY_MADVI(string b_dvi, string b_form, string b_ktra)
    {
        DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_LKE_BY_MADVI(b_dvi);
        se.P_TG_LUU(b_form, b_ktra, b_dt.Copy());
    }
    [WebMethod(true)]
    public string Fdt_MA_PHONG_CHITIET(string b_form, string b_ktra, string b_dvi, string b_phongban)
    {
        string b_chuoi_cctc = "", b_khoi = "", b_ten_khoi = "", b_quanly_tt = "", b_ten_quanly_tt = "";
        DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_CHITIET(b_dvi, b_phongban);
        if (b_dt.Rows.Count > 0)
        {
            b_chuoi_cctc = b_dt.Rows[0]["PHONGBAN_CT"].ToString();
            b_khoi = b_dt.Rows[0]["KHOI"].ToString();
            b_ten_khoi = b_dt.Rows[0]["TEN_KHOI"].ToString();
            b_quanly_tt = b_dt.Rows[0]["PHONG_QL"].ToString();
            b_ten_quanly_tt = b_dt.Rows[0]["TEN_QUANLY_TT"].ToString();
        }
        return b_chuoi_cctc + "#" + b_khoi + "#" + b_ten_khoi + "#" + b_quanly_tt + "#" + b_ten_quanly_tt;
    }
    [WebMethod(true)]
    public string Fdt_CHUOI_CCTC(string b_phongban)
    {
        string b_chuoi_cctc = "";
        se.se_nsd b_se = new se.se_nsd();
        DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_CHITIET(b_se.ma_dvi, b_phongban);
        if (b_dt.Rows.Count > 0)
        {
            b_chuoi_cctc = b_dt.Rows[0]["PHONGBAN_CT"].ToString();
        }
        return b_chuoi_cctc;
    }
    [WebMethod(true)]
    public string Fdt_MA_PBO_CHITIET(string b_form, string b_ktra, string b_dvi, string b_phongban)
    {
        string b_chuoi_cctc = "", b_khoi = "", b_ten_khoi = "";
        DataTable b_dt = ht_dungchung.Fdt_MA_PBO_CHITIET(b_dvi, b_phongban);
        if (b_dt.Rows.Count > 0)
        {
            b_khoi = b_dt.Rows[0]["MA_PBO"].ToString();
            b_ten_khoi = b_dt.Rows[0]["PHAN_BO"].ToString();
        }
        return b_chuoi_cctc + "#" + b_khoi + "#" + b_ten_khoi;
    }
    [WebMethod(true)]
    public static DataTable Fdt_MA_PHONG_LKE_ALL()
    {
        return ht_dungchung.Fdt_MA_PHONG_LKE_ALL();
    }
    [WebMethod(true)]
    public static DataTable Fdt_MA_CVU_LKE()
    {
        return ht_dungchung.Fdt_MA_CVU_LKE();
    }
    [WebMethod(true)]
    public static DataTable Fdt_CHUNG_LKE(string b_loai)
    {
        return ht_dungchung.Fdt_CHUNG_LKE(b_loai);
    }
    [WebMethod(true)]
    public static DataTable Fdt_DT_CHUNG_LKE(string b_loai)
    {
        return ht_dungchung.Fdt_DT_CHUNG_LKE(b_loai);
    }
    [WebMethod(true)]
    public static DataTable Fdt_DT_LOAI_THI()
    {
        return ht_dungchung.Fdt_DT_LOAI_THI();
    }
    // Lấy các cấp ở bên dưới theo id
    [WebMethod(true)]
    public string Fs_PHONG_LEVEL_DR(int b_level, string b_dvi, string b_ten, string b_form)
    {
        DataTable b_dt = ht_dungchung.Fdt_PHONG_LEVEL_DR(b_dvi, b_level);
        se.P_TG_LUU(b_form, b_ten, b_dt.Copy());
        return bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_PHONG_LEVEL_DR_KN(string b_login, int b_level, string b_dvi, double[] a_tso)
    {
        se.P_LOGIN(b_login);
        object[] a_obj = ht_dungchung.Fdt_PHONG_LEVEL_DR_GR(b_dvi, b_level, a_tso[0], a_tso[1]);
        DataTable b_dt = (DataTable)a_obj[1];
        return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_dt, "MA,TEN");
    }
    [WebMethod(true)]
    public string Fs_NHOM_CD(string b_cdanh, string b_ten, string b_form)
    {
        DataSet b_ds = ht_dungchung.Fdt_NHOM_CD_DR(b_cdanh);
        DataTable b_dt = b_ds.Tables[0];
        DataTable b_dt_hso = b_ds.Tables[1];
        se.P_TG_LUU(b_form, b_ten, b_dt_hso.Copy());
        string b_ten_cdanh = "";
        if (b_dt.Rows.Count > 0)
        {
            b_ten_cdanh = b_dt.Rows[0]["TEN_NCDANH"].ToString();
        }
        return b_ten_cdanh;
    }
    [WebMethod(true)]
    public static DataTable Fdt_CAP_DAOTAO_LKE()
    {
        return ht_dungchung.Fdt_CAP_DAOTAO_LKE();
    }
    [WebMethod(true)]
    public static DataTable Fdt_HE_DAOTAO_LKE()
    {
        return ht_dungchung.Fdt_HE_DAOTAO_LKE();
    }
    [WebMethod(true)]
    public static DataTable Fdt_HOCHAM_DR()
    {
        return ht_dungchung.Fdt_HOCHAM_DR();
    }
    [WebMethod(true)]
    public static DataTable Fdt_HOCVI_DR()
    {
        return ht_dungchung.Fdt_HOCVI_DR();
    }
    [WebMethod(true)]
    public static DataTable Fdt_QUOCTICH_DR()
    {
        return ht_dungchung.Fdt_QUOCTICH_DR();
    }
    [WebMethod(true)]
    public static DataTable Fdt_NHOM_DR()
    {
        return ht_dungchung.Fdt_NHOM_DR();
    }
    [WebMethod(true)]
    public static DataTable Fdt_NOICAP_CMT()
    {
        return ht_dungchung.Fdt_NOICAP_CMT();
    }
    [WebMethod(true)]
    public static DataTable Fdt_NGANHANG()
    {
        return ht_dungchung.Fdt_NGANHANG();
    }
    [WebMethod(true)]
    public static DataTable Fdt_CHUYENNGANH_DAOTAO_LKE()
    {
        return ht_dungchung.Fdt_CHUYENNGANH_DAOTAO_LKE();
    }
    // LẤY DỮ LIỆU QUẬN HUYỆN THEO TỈNH THÀNH
    [WebMethod(true)]
    public static DataTable Fdt_NS_MA_QH_DR(string ma_tt)
    {
        return ht_dungchung.Fdt_NS_MA_QH_DR(ma_tt);
    }
    // LAY DU LIEU XA PHUONG THEO QUÂN HUYỆN
    public static DataTable Fdt_NS_MA_XP_DR(string ma_qh)
    {
        return ht_dungchung.Fdt_NS_MA_XP_DR(ma_qh);
    }
    // LẤY DỮ LIỆU DÂN TỘC
    public static DataTable Fdt_NS_MA_DT_DR()
    {
        return ht_dungchung.Fdt_NS_MA_DT_DR();
    }
    public static DataTable Fdt_NS_MA_LOAIDT_DR()
    {
        return ht_dungchung.Fdt_MA_LOAIDT_DR();
    }
    // LẤY DỮ LIỆU TÔN GIÁO
    public static DataTable Fdt_NS_MA_TG_DR()
    {
        return ht_dungchung.Fdt_NS_MA_TG_DR();
    }
    // LẤY DỮ LIỆU NGƯỜI KÝ
    public static DataTable Fdt_NG_KY()
    {
        return ht_dungchung.Fdt_NG_KY();
    }
    // IMPORT HƠP ĐỒNG
    public static DataTable Fdt_NHOM_CDANH_CV()
    {
        return ht_dungchung.Fdt_NHOM_CDANH_CV();
    }
    public static DataTable Fdt_CDANH_CV()
    {
        return ht_dungchung.Fdt_CDANH_CV();
    }
    public static DataTable Fdt_BAC_CDANH_CV()
    {
        return ht_dungchung.Fdt_BAC_CDANH_CV();
    }
    // import khen thưởng kỷ luật
    public static DataTable Fdt_MA_HINHTHUC_DR()
    {
        return ht_dungchung.Fdt_MA_HINHTHUC_DR();
    }
    public static DataTable Fdt_MA_CAP_KTKL_DR()
    {
        return ht_dungchung.Fdt_MA_CAP_KTKL_DR();
    }
    public static DataTable PNS_MA_NOI_KTKL_DR()
    {
        return ht_dungchung.PNS_MA_NOI_KTKL_DR();
    }
    public static DataTable Fdt_MA_HINHTHUC_KL()
    {
        return ht_dungchung.Fdt_MA_HINHTHUC_KL();
    }
    [WebMethod(true)]
    public static DataTable Fdt_HT_MA_TUSINH_MA()
    {
        return ht_dungchung.Fdt_HT_MA_TUSINH_MA();
    }
    [WebMethod(true)]
    public static DataTable Fdt_DT_DOT_KHAOSAT()
    {
        return ht_dungchung.Fdt_DT_DOT_KHAOSAT();
    }
    [WebMethod(true)]
    public static DataTable Fdt_NS_TONG_NHANSU(double b_nam, string b_phong, string b_cdanh)
    {
        return ht_dungchung.Fdt_NS_TONG_NHANSU(b_nam, b_phong, b_cdanh);
    }
    [WebMethod(true)]
    public string Fs_AutoGenCode(string b_kytudau, string b_tenbang, string b_tencot)
    {
        return ht_dungchung.Fdt_AutoGenCode(b_kytudau, b_tenbang, b_tencot);
    }
    [WebMethod(true)]
    public bool Fs_KIEMTRA_TONTAI(string b_ma, string b_tenbang, string b_tencot)
    {
        return ht_dungchung.Fdt_kiemtra_tontai(b_ma, b_tenbang, b_tencot);
    }
    [WebMethod(true)]
    public string Fs_NS_CB_TTCB(string b_sothe)
    {
        DataTable b_dt = ht_dungchung.Fdt_NS_CB_TTCB(b_sothe);
        bang.P_SO_CSO(ref b_dt, "luong_cb,thunhapthang,thuong_ketqua");
        string svalue = "";
        if (!bang.Fb_TRANG(b_dt))
            svalue = b_dt.Rows[0]["so_the"] + "#" + b_dt.Rows[0]["ten"].ToString() + "#" + b_dt.Rows[0]["phong"].ToString()
                + "#" + b_dt.Rows[0]["nhom_cd"].ToString() + "#" + b_dt.Rows[0]["cdanh"].ToString() + "#" + b_dt.Rows[0]["bac_cdanh"].ToString()
                + "#" + b_dt.Rows[0]["hscd"].ToString() + "#" + b_dt.Rows[0]["ten_phong"].ToString() + "#" + b_dt.Rows[0]["ten_cdanh"].ToString()
                + "#" + b_dt.Rows[0]["ten_tl"].ToString() + "#" + b_dt.Rows[0]["ten_nl"].ToString() + "#" + b_dt.Rows[0]["ten_bl"].ToString()
                + "#" + b_dt.Rows[0]["luong_cb"].ToString() + "#" + b_dt.Rows[0]["thunhapthang"].ToString() + "#" + b_dt.Rows[0]["thuong_ketqua"].ToString();
        return svalue;
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO(string b_sothe)
    {
        double b_trocap_tv = 0;
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO(b_sothe);
        if (b_dt.Rows.Count > 0)
        {
            var b_ngayvao = b_dt.Rows[0]["NGAY_VAO"].ToString();
            double b_thunhapthang = int.Parse(b_dt.Rows[0]["thunhapthang"].ToString());
            DateTime b_ngayvao_date = new DateTime(int.Parse(b_ngayvao.Substring(0, 4)), int.Parse(b_ngayvao.Substring(4, 2)), int.Parse(b_ngayvao.Substring(6, 2)));

            // nếu ngày vào trước năm 2009 thì mới được tính trợ cấp thôi việc
            if (b_ngayvao_date.Year < 2009)
            {
                DateTime b_ngaytru = new DateTime(2008, 12, 31);
                double b_thang = b_ngaytru.Month - b_ngayvao_date.Month + 1;
                double b_nam = b_ngaytru.Year - b_ngayvao_date.Year;
                if (b_thang > 6) b_nam = b_nam + 1;
                else b_nam = b_nam + 0.5;
                b_trocap_tv = Math.Round(b_nam * b_thunhapthang / 2, 2);
            }
        }
        bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_hl,ngay_het_hl,nsinh");

        bang.P_THEM_COL(ref b_dt, "tctv", b_trocap_tv);
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO_TEN(string b_sothe)
    {
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO_TEN(b_sothe);
        bang.P_SO_CNG(ref b_dt, "ngay_vao,ngay_hl,ngay_het_hl,nsinh");
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO_HD(string b_sothe, string b_listcotcu = "so_the,ho_ten,ten_cdanh,ten_phong,email,email_cty,ngay_vao,ngay_ct,nsinh",
        string b_listcotmoi = "so_the,ho_ten,ten_cdanh,ten_phong,email,email_cty,ngay_vao,ngay_ct,nsinh")
    {
        string[] a_cotcu = b_listcotcu.Split(','), a_cotmoi = b_listcotmoi.Split(',');
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO(b_sothe);
        for (int i = 0; i < a_cotcu.Length; i++)
        {
            if (b_dt.Columns.Contains(a_cotcu[i]))
            {
                b_dt.Columns[a_cotcu[i]].ColumnName = a_cotmoi[i];
            }
        }
        //bang.P_SO_CNG(ref b_dt, "ngay_ct,nsinh");
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0, b_listcotmoi);
    }

    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO_CDANH(string b_cdanh)
    {
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO_CDANH(b_cdanh);
        return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO_LUOI(string b_sothe)
    {
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_CANBO(b_sothe);
        string svalue = "";
        if (!bang.Fb_TRANG(b_dt))
            svalue = b_dt.Rows[0]["so_id"] + // 0
                "#" + b_dt.Rows[0]["so_the"] + //1
                "#" + b_dt.Rows[0]["ho_ten"].ToString() + //2
                "#" + b_dt.Rows[0]["ten_cdanh"].ToString() + //3
                "#" + (b_dt.Rows[0]["ten_phong"] != DBNull.Value ? b_dt.Rows[0]["ten_phong"].ToString() : b_dt.Rows[0]["ma_phong"].ToString()) + //4
                "#" + b_dt.Rows[0]["ma_phong"].ToString() + //5
                "#" + b_dt.Rows[0]["ten_phong"].ToString() + //6;
                "#" + b_dt.Rows[0]["so_dt"].ToString() + //7;
                "#" + b_dt.Rows[0]["email"].ToString() + //8;
                "#" + b_dt.Rows[0]["email_qly"].ToString() +//9
                "#" + b_dt.Rows[0]["ten_donvi"].ToString() +//10;
                "#" + b_dt.Rows[0]["cdanh"].ToString();

        return svalue;
    }
    [WebMethod(true)]
    public string Fs_THONGTIN_CANBO_QD_KHOANG(string b_sothe, string b_ky, string b_phong, object[] a_dt_luoi, string[] a_cot)
    {
        var b_dt = ht_dungchung.Fdt_NS_THONGTIN_QD_KHOANG(b_sothe, b_ky, b_phong);
        if (b_dt.Rows.Count <= 0)
        {
            return "loi:Nhân viên " + b_sothe + " chưa có quyết định:loi";
        }
        string[] a_cot_tl;
        object[] a_gtri_tl;
        DataTable b_dt_tl;
        a_cot_tl = chuyen.Fas_OBJ_STR((object[])a_dt_luoi[0]); a_gtri_tl = (object[])a_dt_luoi[1];
        b_dt_tl = bang.Fdt_TAO_THEM(a_cot_tl, a_gtri_tl);
        bang.P_BO_HANG(ref b_dt_tl, "so_the", "");
        if (a_dt_luoi[0].ToString() != "")
        {
            foreach (DataRow irow in b_dt.Rows)
            {
                DataRow[] rows = b_dt_tl.Select("so_the ='" + irow[1].ToString() + "'");
                DataRow[] r_qd = b_dt_tl.Select("so_qd ='" + irow[8].ToString() + "'");
                if (r_qd.Length <= 0)
                    b_dt_tl.ImportRow(irow);
            }
        }
        bang.P_XEP(ref b_dt_tl, "so_the");
        return chuyen.OBJ_S(b_dt_tl.Rows.Count) + "#" + bang.Fs_BANG_CH(b_dt_tl, a_cot);
    }

    #region NghiepDo

    [WebMethod(true)]
    public string Fs_NS_MA_QG(string b_form, string b_phong)
    {
        try
        {
            DataTable b_dt = ht_dungchung.Fdt_MA_QG(b_phong);
            if (b_dt.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            se.P_TG_LUU(b_form, "DT_QG", b_dt.Copy());
            bang.P_THEM_TRANG(ref b_dt, 1, 0);
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

}
#endregion "HÀM DÙNG CHUNG"

#region THÔNG BÁO DÙNG CHUNG
public class Thongbao_dch
{
    public static string vuilongnhap = "loi:Vui lòng nhập các trường trên lưới:loi";
    public static string vuilong = "loi:Vui lòng chọn bản ghi:loi";
    public static string vuilong_dvi = "loi:Vui lòng chọn đơn vị:loi";
    public static string vuilong_chonnhanvien = "loi:Vui lòng chọn nhân viên:loi";
    public static string vuilong_chonungvien = "loi:Vui lòng chọn ứng viên:loi";
    public static string KY_LUONG_DADONG = "loi:Kỳ lương đã khóa:loi";
    public static string chuaco_ungvien = "loi:Chưa có ứng viên cần xác nhận:loi";
    public static string So_the_tontai = "loi:Mã nhân viên đã tồn tại:loi";
    public static string So_the_chuanhap = "loi:Chưa nhập mã nhân viên sau khi tiếp nhận:loi";
    public static string DaPheduyet = "loi:Dữ liệu ở trạng thái phê duyệt:loi";
    public static string Pheduyet_thanhcong = "loi:Phê duyệt thành công:loi";
    public static string Pheduyet_thatbai = "loi:Phê duyệt thất bại:loi";
    public static string KoPheduyet_thanhcong = "loi:Không phê duyệt thành công:loi";
    public static string koPheduyet_thatbai = "loi:Không phê duyệt thất bại:loi";
    public static string HuyPheduyet_thanhcong = "loi:Hủy phê duyệt thành công:loi";
    public static string HuyPheduyet_thatbai = "loi:Hủy phê duyệt thất bại:loi";

    public static string Saicuphap = "loi:Sai cú pháp:loi";
    public static string ThaoTac_thatbai = "loi:Thao tác thất bại:loi";
    public static string CapnhatThanhcong = "loi:Cập nhật thành công:loi";
    public static string GhiThanhCong = "loi:Ghi thành công:loi";
    public static string ChonCongThuc = "loi:Vui lòng chọn công thức:loi";
    public static string BanGhi_DaPheDuyet = "loi:Bản ghi đã được phê duyệt:loi";
    public static string KhoaHoc_KetThuc = "loi:Khóa học đã kết thúc:loi";
    public static string KhoaHoc_daPD_DK = "loi:Khóa học đã được phê duyệt và cho đăng ký:loi";
    public static string KhoaHoc_daPD_KT = "loi:Khóa học đã kết thúc hoặc đã được phê duyệt:loi";
    public static string KhoaHoc_dachodk = "loi:Khóa học đã đã cho đăng ký:loi";
    public static string KhoaHoc_ChuaPD = "loi:Khóa học chưa được phê duyệt:loi";
    public static string Khong_huy_dangky = "loi:không thể hủy đăng ký đang học hoặc đã kết thúc:loi";

    public static string KY_CONG_DONG = "loi:Kỳ công đã được khóa:loi";
    public static string KY_LUONG_DONG = "loi:Kỳ lương đã được khóa:loi";

    public static string KY_CONG_MO = "loi:Kỳ công đã được mở:loi";
    public static string KY_LUONG_MO = "loi:Kỳ lương đã được mở:loi";
    public static string MAY_CHAM_CONG_KHONG_TAN_TAI = "loi:Chưa có máy chấm công:loi";
    public static string KY_LUONG_DONG_VV = "loi:Kỳ lương đã được khóa vĩnh viễn:loi";
    public static string KY_CONG_KHOA = "loi:Kỳ công đã khóa:loi";
    public static string KY_LUONG_KHOA = "loi:Kỳ lương đã khóa:loi";

    // Thông báo Thiết lập ngày nghỉ lễ
    public static string ngaynghi = "loi:Giá trị " + '"' + "Từ ngày" + '"' + " không được lớn hơn giá trị " + '"' + "Đến ngày" + '"' + ":loi";
    public static string Tungay = "loi:Sai giá trị " + '"' + "Từ ngày" + '"' + ":loi";
    public static string Denngay = "loi:Sai giá trị " + '"' + "Đến ngày" + '"' + ":loi";

    public static string Vuilong_dong_kycong = "loi:Vui lòng đóng kỳ công trước khi tính lương:loi";

    public static string ChuaChonFileImport = "loi:Chưa chọn file import:loi";
    public static string ChuaChonBanGhiLuoi = "loi:Chưa chọn bản ghi trên lưới:loi";
    public static string FileSaiDinhDang = "loi:File import không đúng định dạng:loi";
    public static string LoiquatrinhImport = "loi:Có lỗi phát sinh trong quá trình import:loi";
    public static string Importthanhcong = "loi:Import dữ liệu thành công:loi";
    public static string Thaotac_thanhcong = "loi:Thao tác thực hiện thành công:loi";
    // thông báo cho mã tự sinh
    public static string chuanhap_tiento = "loi:Chưa nhập tiền tố:loi";
    public static string chuanhap_dodaist = "loi:Chưa nhập độ dài mã cán bộ:loi";
    public static string chuanhap_dodaihd = "loi:Chưa nhập độ dài hợp đồng:loi";
    public static string chuanhap_dodaiqd = "loi:Chưa nhập độ dài quyết định:loi";
    public static string chuanhap_giora_vao_giuaca = "loi:Chưa nhập giờ ra/Giờ vào giữa ca:loi";
    public static string TonTaiKyCongLuong = "loi:Đã tồn tại kỳ công lương trong khoảng thời gian bạn chọn:loi";
    // thông báo phần tuyển dụng
    public static string Vuilong_NhapDayDu = "loi:Vui lòng nhập đầy đủ thông tin vị trí:loi";
    public static string thaydoi_pheduyet = "loi:Bản ghi đã được phê duyệt, bạn không thể thay đổi:loi";
    public static string nhapdulieu_luoi = "loi:Vui lòng nhập thông tin trên lưới hoặc những trường bắt buộc:loi";
    public static string ktNgaydexuat = "loi:Ngày đề xuất không được lớn hơn ngày cần:loi";
    public static string ktNgaylap_khoach = "loi:Ngày lập kế hoạch không được lớn hơn ngày dự kiến đi làm:loi";
    public static string ChonDuLieu_pd = "loi:Vui lòng chọn dữ liệu phê duyệt:loi";
    public static string ChonDuLieu_kpd = "loi:Vui lòng chọn dữ liệu không phê duyệt:loi";
    public static string ns_td_kq_kqc = "loi:Chưa nhập kết quả chung:loi";
    public static string ChonDuLieu_xacnhan = "loi:Vui lòng chọn bản ghi trên lưới:loi";
    public static string khongco_dulieu_luoi = "loi:Không có dữ liệu trên lưới:loi";


    public static string sanpham_congviec = "loi:Chưa nhập sản phẩm công việc:loi";
    public static string sanpham_ChatLuong = "loi:Chưa nhập Chất lượng sản phẩm:loi";
    public static string sanpham_ChatLuong_max = "loi:Chất lượng sản phẩm không được lớn hơn 100:loi";
    public static string sanpham_Tyle_max = "loi:Tỷ lệ không được lớn hơn 100:loi";
    public static string sanpham_SoLuong = "loi:Chưa nhập Số lượng sản phẩm:loi";
    public static string sanpham_canbo = "loi:Chưa nhập danh sách cán bộ:loi";
    public static string PhuCap_heso = "loi:Chưa nhập hệ số phụ cấp:loi";
    public static string dongia_LonHonGiaTriDen = "loi:Giá trị từ không được lớn hơn giá trị đến:loi";
    public static string dongia_LonHon_O = "loi:Đơn giá phải lớn hơn 0:loi";

    public static string ThuNhap_NhoHon_Bang = "loi:Thu nhập đến không được nhỏ hơn hoặc bằng thu nhập từ:loi";
    // thông báo form cán bộ
    public static string chuanhap_sothe = "loi:Chưa nhập mã cán bộ:loi";

    // thông báo form nghỉ việc
    public static string ngaytra_ngaycap = "loi:Ngày cấp không được lớn hơn ngày trả:loi";
    // ket thuc
    // TIMESHEET 
    public static string tonggioLonHonTongGio_LSX = "loi:Tổng giờ giao lớn hơn tổng giờ lệnh sản xuất:loi";

    //thông báo phần đào tạo
    public static string cptu_cpden = "loi:Mức chi phí đến phải lớn hơn mức chi phí từ:loi";
    public static string khoang_cp = "loi:Các mức chi phí phải khác nhau (Không được giao nhau):loi";

    public static string nhapdulieu_cdanh = "loi:Vui lòng nhập đầy đủ thông tin trên lưới Chức danh:loi";
    public static string nhapdulieu_level_cdanh = "loi:Vui lòng nhập đầy đủ thông tin trên lưới Level chức danh:loi";
    public static string nhapdulieu_loaihd = "loi:Vui lòng nhập đầy đủ thông tin trên lưới Loại hợp đồng:loi";
}
#endregion THÔNG BÁO DÙNG CHUNG

#region BIẾN GHI LOG HỆ THỐNG
public class PHANHE // Đặt theo file ctmenu
{
    public static string HDNS = "Tổ chức nhân sự";
    public static string TD = "Tuyển dụng";
    public static string NS = "Hồ sơ";
    public static string CD = "Bảo hiểm";
    public static string CC = "Chấm công";
    public static string TL = "Tính lương";
    public static string DG360 = "Đánh giá 360";
    public static string DG = "Đánh giá";
    public static string DT = "Đào tạo";
    public static string DTO = "Đào tạo online";
    public static string HT = "Quản trị";
    public static string CN = "Cá nhân";
    public static string PD = "Quản lý";
    public static string BC = "Báo cáo";
}

public class NHOM_CHUCNANG
{
    public static string NGHIEP_VU = "Nghiệp vụ";
    public static string DANH_MUC = "Danh mục";
    public static string THIET_LAP = "Thiết lập";
    public static string BAO_CAO = "Xuất báo cáo";
}
public class THAOTAC
{
    public static string NHAP = "Nhập";
    public static string XOA = "Xóa";
    public static string IMPORT = "Import dữ liệu";
    public static string TAI_MAU_IN = "Tải mẫu in";
    public static string EXPORT_MAU = "Export file mẫu";
    public static string EXPORT_EXCEL = "Xuất excle";
    public static string EXPORT_BAOCAO = "Xuất báo cáo";
    public static string IN_WORD = "In file word";
    public static string GUI_PHEDUYET = "Gửi phê duyệt";
    public static string PHEDUYET = "Phê duyệt";
    public static string KO_PHEDUYET = "Không phê duyệt";
    public static string MO_CHOPD = "Mở chờ phê duyệt";
    public static string TONGHOP = "Tổng hợp";
    public static string DONG_CC = "Đóng bảng công";
    public static string MO_CC = "Mở bảng công";
    public static string DONG_BL = "Đóng bảng lương";
    public static string MO_BL = "Mở bảng bảng lương";
    public static string DONG_VV_BL = "Khóa vĩnh viễn bảng lương";
    public static string XACNHAN = "Xác nhận";
    public static string LAY_DS = "Lấy danh sách nhân viên chưa đánh giá";
    public static string DANGKY = "Đăng ký";
    public static string HUY_DANGKY = "Hủy đăng ký";
}
public class TEN_FORM
{
    // tổ chức nhân sự
    public static string HT_MADVI = "Hệ thống mã đơn vị";
    public static string HT_MAPH = "Thiết lập cơ cấu tổ chức";
    public static string NS_HDNS_DBIEN = "Định biên nhân sự";
    public static string NS_HDNS_MA_NNN = "Nhóm chức danh";
    public static string NS_HDNS_MA_VTCDANH = "Chức danh";
    public static string NS_HDNS_CDANH_LONGBAI2 = "Chức danh LongBai2";
    public static string HDNS_MA_LVCDANH = "Cấp bậc";
    public static string NS_HDNS_GAN_CDANHDVI = "Gán vị trí chức danh cho đơn vị";
    public static string NS_MA_KHUNGLUONG = "Danh mục khung lương";
    public static string HD_MA_HTTLUONG = "Danh mục bảng lương";
    public static string NS_MA_NHOMLUONG = "Danh mục ngạch lương";
    public static string NS_HDNS_MA_BACLUONG = "Danh mục bậc lương";
    public static string HDNS_MOTA_CV = "Danh mục mô tả công việc";
    // Nghiệp vụ phần tuyển dụng
    public static string NS_TD_KH_NAM = "Kế hoạch tuyển dụng năm";
    public static string NS_TD_KH_DCHUYEN_BNHIEM = "Kế hoạch điều chuyển bổ nhiệm";
    public static string NS_TD_INFO_DEV = "Thông tin Phòng ban - Ứng viên";
    public static string NS_TD_KH_DCBN = "Kế hoạch điều chuyển bổ nhiệm";
    public static string NS_TD_DEXUAT = "Đề xuất tuyển dụng";
    public static string NS_TD_UV_CV = "Kho ứng viên";
    public static string NS_TD_UV_YEUCAUTD = "Khai báo ứng viên vào yêu cầu tuyển dụng";
    public static string NS_TD_PD_CDANH_TD = "Phê duyệt chức danh tuyển dụng";
    public static string NS_TD_PHONGVAN = "Xếp lịch thi tuyển/Phỏng vấn";
    public static string NS_TD_KQ = "Cập nhật kết quả các vòng thi";
    public static string NS_TD_CAPNHAT_UV = "Cập nhật thông tin ứng viên trúng tuyển";
    public static string NS_TD_CHUYEN_UV_NV = "Chuyển ứng viên sang hồ sơ nhân viên";
    public static string NS_TD_PD_CDANH_TD_QL = "Phê duyệt chức danh tuyển dụng";
    // danh mục hồ sơ
    public static string NS_MA_HTDT = "Hình thức đào tạo";
    public static string NS_MA_CAPDT = "Trình độ đào tạo";
    public static string NS_MA_QDINH = "Danh mục quyết định";
    public static string NS_MA_LHD = "Danh mục loại hợp đồng";
    public static string NS_HDNS_MA_HTKHAC = "Các khoản hỗ trợ khác";
    public static string NS_MA_PHUCLOI = "Phúc lợi";
    public static string NS_MA_HTKT = "Hình thức khen thưởng";
    public static string NS_MA_HTKL = "Hình thức kỷ luật";
    public static string NS_MA_CNNH = "Chi nhánh ngân hàng";
    public static string NS_MA_NHA = "Ngân hàng";
    public static string NS_MA_THS = "Túi hồ sơ";
    public static string NS_MA_TRUONGHOC = "Tên trường";
    public static string NS_MA_CNGANH_DT = "Chuyên ngành đào tạo";
    public static string NS_MA_NUOC = "Danh mục quốc gia";
    public static string NS_MA_QTRR = "Danh mục quản trị rủi ro";
    public static string NS_MA_UBCK = "Danh mục ủy ban chứng khoán";
    public static string NS_MA_CCHN = "Danh mục chứng chỉ hành nghề";
    public static string NS_MA_CCC = "Danh mục chứng chỉ con";
    public static string NS_MA_TT = "Tỉnh/Thành phố";
    public static string NS_MA_QH = "Quân/Huyện";
    public static string NS_MA_XP = "Xã/Phường";
    public static string NS_MA_PBO = "Phân bổ";
    public static string NS_HS_MA_CHUNG_NHOM = "Nhóm danh mục dùng chung";
    public static string NS_HS_MA_CHUNG = "Danh mục dùng chung";
    public static string NS_MA_FIELD = "Các trường thông tin";
    public static string NS_TK_MA_CHITIEU = "Chỉ tiêu";
    public static string NS_MA_KQ_HIENTHI = "Kết quả hiển thị";
    public static string NS_HDNS_PBAN_LONGBAI3 = "Danh mục phòng ban";
    public static string NS_HDNS_PBAN_NTDUC = "Danh mục phòng ban";

    // thiết lập hồ sơ
    public static string NS_TL_HTRO_ANTRUA_VUNG = "Thiết lập hỗ trợ ăn trưa theo vùng";
    public static string NS_TL_HTRO_ANTRUA_PHONG = "Thiết lập hỗ trợ ăn trưa theo vùng";
    public static string NS_TL_PC_VUNG = "Thiết lập phụ cấp theo vùng";
    public static string NS_TL_PC = "Thiết lập phụ cấp";
    public static string NS_MA_EMAIL_SN = "Thiết lập gửi email chúc mừng sinh nhật";
    public static string NS_TL_CCHN = "Thiết lập điều kiện thi chứng chỉ hành nghề";

    // nghiệp vụ hồ sơ
    public static string NS_CB = "Hồ sơ nhân viên";
    public static string NS_CB_QLY_PD = "Phê duyệt thông tin CBNV";
    public static string NS_CDANH_KN = "Chức danh kiêm nhiệm";
    public static string NS_HDCT = "Quản lý quyết định";
    public static string NS_CP = "Quản lý điều chuyển";
    public static string NS_HD = "Quản lý hợp đồng";
    public static string NS_HD_PL = "Quản lý phụ lục";
    public static string NS_LD_DA = "Quản lý lao động dự án";
    public static string NS_TV = "Quản lý nghỉ việc";
    public static string NS_DS_DEN = "Danh sách đen";
    public static string NS_KTKL_QLKT = "Quản lý khen thưởng";
    public static string NS_KTKL_QLKL = "Quản lý kỷ luật";
    public static string NS_PHUCLOI_CN = "Phúc lợi cá nhân";
    public static string NS_PHUCLOI_TUDONG = "Phúc lợi tự động";
    public static string NS_PCAP = "Các khoản hỗ trợ khác";
    public static string TI_BC_DONG = "Báo cáo động";
    public static string NS_DG_HDLD = "Đánh giá hợp đồng lao động";
    // Quá trình trong hồ sơ nhân viên
    public static string NS_QHE = "Quan hệ nhân thân";
    public static string NS_DTHV = "Bằng cấp chuyên môn";
    public static string NS_DT_NGHAN = "Chứng chỉ đào tạo";
    public static string NS_THS = "Túi hồ sơ";
    public static string NS_HO_GDINH = "Thông tin hộ gia đình";
    public static string NS_LSCT = "Quá trình công tác trước khi vào công ty";
    public static string NS_LS_QTCT = "Quá trình công tác trong công ty";
    public static string NS_LS_LUONG = "Quá trình lương trong công ty";
    public static string NS_LS_HD_LD = "Quá trình ký hợp đồng lao động";
    public static string NS_LS_KT = "Quá trình khen thưởng";
    public static string NS_LS_KL = "Quá trình kỷ luật";
    public static string NS_LS_QT_DT = "Quá trình đào tạo trong công ty";
    public static string NS_LS_DG = "Kết quả đánh giá";
    // Danh mục bảo hiểm
    public static string NS_MA_BV = "Nơi khám chữa bệnh";
    public static string NS_MA_TILE_BH = "Quy định % đóng bảo hiểm";
    public static string NS_MA_KHAC_NHOM = "Nhóm biến động bảo hiểm";
    public static string NS_MA_KHAC = "Loại biến động bảo hiểm";
    public static string NS_MA_NHOM_CHEDO = "Nhóm chế độ bảo hiểm";
    public static string NS_MA_LYDOBHXH = "Chế độ bảo hiểm";
    public static string NS_MA_BIENDONGBHXH = "Phương án sử dụng biến động bảo hiểm";
    public static string NS_MA_PHUONGANCHEDOBH = "Phương án chế độ bảo hiểm";
    // Nghiệp vụ bảo hiểm 
    public static string NS_KHAIBAO_DM = "Khai báo đóng mới bảo hiểm";
    public static string NS_TT_BH = "Quản lý thông tin bảo hiểm";
    public static string NS_BIENDONG_BH = "Biến động bảo hiểm";
    public static string NS_BHXH_CHEDO = "Chế độ BHXH";
    public static string NS_DS_KDDK_BH = "Danh sách không đủ điều kiện đóng bảo hiểm";
    // danh mục chấm công
    public static string NS_CC_MA_CCDB = "Chấm công đặc biệt";
    public static string NS_CC_MA_TSPB = "Thông số phép năm";
    public static string TL_TLAP_LAMCA = "Ca làm việc";
    public static string NS_HDNS_MA_NGAYNGHI = "Ngày nghỉ lễ";
    public static string TL_MA_KYLUONG = "Kỳ công lương";
    public static string CC_MA_TL_CC = "Ký hiệu chấm công";
    public static string CC_MA_GHCP = "Gia hạn cắt phép";
    public static string NS_CC_MA_FORMTEST = "FORMTEST";
    public static string TL_MA_CONGVIEC = "Công việc";
    public static string TL_MA_SPHAM = "Sản phẩm";
    public static string TL_MA_CHATLUONG = "Chất lượng";
    public static string TL_MA_DONGIA = "Đơn giá";

    // thiết lập chấm công
    public static string NS_CC_MA_CCDV = "Thiết lập chấm công theo đơn vị";
    public static string NS_CC_CT_CONG = "Công thức công";
    public static string TL_DT_CMD = "Thiết lập ca mặc định";
    public static string CC_MA_CC = "Kiểu công";
    public static string TL_TLAP_LAMTHEM = "Hệ số làm thêm";
    // nghiệp vụ chấm công
    public static string TL_PHANCA = "Xếp ca làm việc";
    public static string NS_CC_THONGTIN_NGHI = "Quản lý đăng ký nghỉ";
    public static string NS_CC_GT = "Giải trình chấm công";
    public static string CC_DKY_DMVS = "Quản lý đi muộn về sớm";
    public static string CC_DULIEU_VAORA = "Quản lý dữ liệu vào ra";
    public static string NS_CC_PHEP_NAM = "Tổng hợp nghỉ phép";
    public static string NS_CC_NGHIBU = "Tổng hợp nghỉ bù";
    public static string NS_CC_DKY_LTHEM = "Đăng ký làm thềm giờ";
    public static string NS_CC_KB_LTHEM = "Khai báo làm thêm giờ";
    public static string NS_CC_TONGHOP_LTHEM = "Tổng hợp làm thêm giờ";
    public static string NS_CC_TH_MAY = "Tổng hợp dữ liệu công máy";
    public static string CC_CN_CT = "Xử lý dữ liệu chấm công";
    public static string NS_CC_TH = "Bảng tổng hợp công";
    public static string NS_CC_TH_TTS = "Bảng tổng hợp công thực tập sinh";
    public static string NS_CC_TH_KHOAN_SP = "Bảng công Khoán - Sản phẩm";
    public static string CC_SP_TT = "Chấm công sản phẩm tập thể";
    public static string CC_SP_CN = "Chám công sản phẩm cá nhân";
    public static string NS_CC_DKLV_NGOAI_CTY_CN = "Đăng ký làm việc ngoài công ty";
    public static string NS_CC_DKLV_NGOAI_CTY = "Đăng ký làm việc ngoài công ty";
    public static string NS_CC_DKLV_NGOAI_CTY_PD = "Phê duyệt đăng ký làm việc ngoài công ty";
    public static string NS_CC_DKC_CONNHO = "Đăng ký ca làm việc con nhỏ dưới 1 tuổi";
    public static string NS_CC_DKC_CONNHO_PD = "Phê duyệt đăng ký làm việc con nhỏ dưới 1 tuổi";
    //public static string CC_SP_CN = "Chám công sản phẩm cá nhân";

    // Danh mục tính lương
    public static string NS_TL_MA_ML = "Thông tin bảng lương";
    public static string NS_TL_PHIEULUONG = "Thiết lập phiếu lương";
    public static string TL_TLAP_THUE = "Thuế thu nhập cá nhân";
    // Thiết lập tính lương
    public static string NS_TL_MA_CTLUONG = "Công thức lương";
    public static string TL_TLAP_GTRU_BANTHAN = "Giảm trừ bản thân";
    public static string TL_TLAP_DONGIA_TTS = "Thiết lập đơn giá thực tập sinh";
    public static string TL_TLAP_THIEU_PHIEULENH = "Thiết lập điều kiện thiếu phiếu lệnh";
    public static string TL_TLAP_TYLE_HOAHONG = "Thiết lập tỷ lệ hoa hồng";
    public static string NS_TL_DTUONG_BLUONG = "Thiết lập đối tượng bảng lương";

    public static string TL_TLAP_GTRU = "Giảm trừ gia cảnh";
    // Nghiệp vụ tính lương
    public static string TL_LUONG_IMP = "Các khoản phát sinh";
    public static string TL_EMS_IMP = "Import dữ liệu EMS";
    public static string NS_TL_VIPHAM = "Xử lý vi phạm";
    public static string NS_TL_BLUONG = "Xử lý lương tháng(Tính lương)";
    public static string NS_TL_BLUONG_BB = "Bảng lương cộng tác viên khối BB";
    public static string NS_TL_BLUONG_BS = "Bảng lương cộng tác viên khối BS";
    public static string NS_TL_BLUONG_TTS = "Bảng lương thực tập sinh";
    public static string TL_GIULUONG = "Khai báo giữ lương";
    public static string NS_TL_QTTHUE = "Ủy quyền quyết toán thuế TNCN";
    public static string NS_DSACH_GIAYTO_BBUOC = "Danh sách giấy tờ bắt buộc";
    public static string NS_TL_KHOAN_PHAITHU = "Các khoản phải thu - phải trả";
    // Danh mục đánh giá 360
    public static string DG_DM_KDG = "Kỳ đánh giá 360";
    public static string DG_DM_NHOM_CAUHOI = "Nhóm câu hỏi đánh giá 360";
    public static string DG_DM_DTDG = "Thiết lập đối tượng được đánh giá 360";
    public static string DG_DM_TLAP_DTUONG_DGIA = "Thiết lập đối tượng đánh giá 360";
    public static string DG_DM_MDG = "Thiết lập mẫu đánh giá 360";
    // Nghiệp vụ đánh giá 360
    public static string DG_NGV_KHDG = "Khách hàng đánh giá 360";
    public static string DG_NGV_TONGHOP_DGNB = "Tổng hợp kết quả đánh giá nội bộ 360";
    public static string DG_NGV_TONGHOP_DGKH = "Tổng hợp kết quả đánh giá khách hàng 360";
    // Danh mục đánh giá
    public static string NS_DG_MA_KDG = "Kỳ đánh giá";
    public static string DG_DM_NHOM_TIEUCHI = "Nhóm tiêu chí đánh giá";
    public static string DG_DM_TIEUCHI = "Tiêu chí đánh giá";
    public static string NS_DG_MA_CHUNG = "Danh mục dùng chung đánh giá";
    // Thiết lập đánh giá
    public static string NS_DG_TLNL_CDANH = "Thiết lập năng lực đánh giá theo nhóm chức danh";
    public static string DG_DM_TCDG_CD = "Thiết lập tiêu chí đánh giá theo chức danh";
    public static string TL_QD_XL_DG = "Thiết lập quy định xếp loại đánh giá";
    public static string DG_DM_TLDGNV = "Thiết lập tỷ lệ xếp loại đánh giá nhân viên theo xếp loại bộ phận";
    // Nghiệp vụ đánh giá
    public static string KQ_DG_CTY = "Kết quả đánh giá của công ty";
    public static string DG_KQ_DGIA_THANG = "Kết quả đánh giá sử dụng tính lương";
    public static string DG_NGV_KQUA_DG_KPI = "Kết quả đánh giá KPIs";
    // Danh mục đào tạo
    public static string NS_DT_MA_NND = "Danh mục nhóm nội dung";
    public static string NS_DT_MA_NND_DV = "Danh mục nhóm nội dung đơn vị";
    public static string NS_DT_MA_KDTAO = "Khóa đào tạo";
    public static string NS_DT_MA_CTDT_HT = "Danh mục chỉ tiêu đào tạo và học tập";
    public static string NS_DT_MA_DTAC = "Danh mục đối tác đào tạo";
    public static string NS_DT_MA_GV_NOI = "Danh mục giảng viên đào tạo nội bộ";
    public static string NS_DT_MA_CKET = "Danh mục cam kết đào tạo";
    public static string NS_DT_MA_CHUNG_NHOM = "Nhóm danh mục dùng chung đào tạo";
    public static string NS_DT_MA_CHUNG = "Danh mục dùng chung đào tạo";
    // Nghiệp vụ đào tạo
    public static string NS_DT_NCAU = "Nhu cầu đào tạo";
    public static string NS_DT_KHDT_NAM = "Kế hoạch đào tạo năm";
    public static string NS_DT_KH_CT = "Kế hoạch đào tạo chi tiết";
    public static string NS_DT_HVIEN_TGIAN = "Danh sách học viên tham gia khóa ĐT";
    public static string NS_DT_TRIENKHAI = "Triển khai đào tạo";
    public static string NS_DT_HINHTHUC = "Thời gian đào tạo theo hình thức OJT";
    public static string NS_DT_TGIAN_GDAY = "Tổng hợp thời gian giảng dạy của giảng viên";
    public static string NS_DT_TGIAN_GDAY_HVIEN = "Tổng hợp thời gian giảng dạy của học viên";
    public static string NS_DT_DANHGIA_CL_KDT = "Đánh giá chất lượng đào tạo";
    // Danh mục đào tạo online
    public static string NS_DT_GVIEN = "Danh sách giảng viên";
    public static string NS_DT_MA_LVDAOTAO = "Lĩnh vực đào tạo";
    public static string NS_DT_MA_NGUONKP = "Nguồn kinh phí";
    public static string NS_DT_MA_NKYNANG = "Nhóm kỹ năng đào tạo";
    public static string NS_DT_MA_KYNANG = "Kỹ năng đào tạo";
    public static string NS_MA_HEDT = "Hệ đào tạo";
    public static string NS_MA_LDT = "Loại đào tạo";
    // Thiết lập đào tạo online 
    public static string NS_DT_NHUCAU_DT = "Thiết lập mã đào tạo";
    // Nghiệp vụ đào tạo online 
    public static string NS_DT_KHOITAO_KS = "Khởi tạo khảo sát";
    public static string NS_DT_TONGHOP_PHIEU_KS = "Tổng hợp phiếu khảo sát";
    public static string NS_DT_DXUAT = "Đề xuất kế hoạch đào tạo";
    public static string NS_DT_KDT = "Khóa đào tạo";
    public static string NS_DT_THUVIEN_DTHI = "Thư viện câu hỏi đề thi";
    public static string NS_DT_KHOITAO_DTHI = "Khởi tạo đề thi";
    public static string NS_DT_TOCHUC_THI = "Tổ chức đề thi";
    public static string NS_DT_TINHDIEM_THI = "Tính điểm thi";
    public static string NS_DT_DANHGIA_KQ = "Đánh giá kết quả đào tạo";
    public static string NS_DT_PHUKHAO = "Học viên phúc khảo";
    public static string NS_DT_PHIEU_KS = "Phiếu khảo sát";
    // Quản trị Hệ thống nội bộ
    public static string HT_MANHOM = "Nhóm quyền";
    public static string HT_MANSD = "Tài khoản";
    public static string HT_LOG = "Quản lý thao tác";
    // Quản trị Thiết lập hệ thống
    public static string NS_CAIDAT_QLY = "Phân quyền cơ cấu tổ chức";
    public static string NS_DT_CAIDAT_PD = "Phê duyệt";
    public static string NS_TLAP_EMAIL = "Email thông báo";
    public static string NS_TLAP_TTLH_BLUONG = "Thông tin liên hệ bảng lương";
    public static string NS_TBAO_MENU_TLAP = "Gợi nhắc";
    public static string HT_MA_TUSINH = "Cấu hình mã tự sinh";
    // Cá nhân
    public static string NS_CB_TT = "Thông tin cán bộ nhân viên";
    public static string NS_HD_DG_TT = "Đánh giá HĐLĐ";
    public static string NS_QT_XIN_NGHIPHEP = "Đăng ký nghỉ";
    public static string NS_QT_LVIEC_NGOAICTY = "Đăng ký làm việc ngoài công ty";
    public static string NS_QT_DK_NCN = "Đăng ký ca nuôi con nhỏ";
    public static string NS_QT_NGHIVIEC = "Khai báo nghỉ việc";
    public static string NS_DT_DANGKYKH = "Đăng ký khóa học";
    public static string NS_DT_DEXUAT = "Đề xuất đào tạo";
    public static string NS_DT_DANHGIA_KDT = "Đánh giá khóa đào tạo";
    public static string NS_CC_CN_DKY_LTHEM = "Đăng ký làm thêm giờ";
    public static string CC_CN_DKY_DMVS = "Đăng ký đi muộn về sớm";
    public static string NS_GT_CC = "Giải trình chấm công";
    public static string NS_CC_QUETTHE = "Dữ liệu quẹt thẻ";
    public static string DG_NGV_CTCV_HT = "CBNV nhập chỉ tiêu công việc hàng tháng";
    public static string TL_BLUONG_CN = "Phiếu lương";
    public static string DG_CV_THANG = "Đánh giá kết quả thực hiện công việc hàng tháng";
    public static string CBNV_CT_KPI = "CNBV nhập chỉ tiêu giao KPIs";
    public static string DGIA_KPI_NV = "Đánh giá KPIs";
    public static string DG_NGV_NBDG = "Nội bộ đánh giá";
    // Quản lý
    public static string NS_CB_QL = "Thông tin CBNV thuộc quyền quản lý";
    public static string NS_QT_DEBAT = "Danh sách nâng lương/Đề bạt";
    public static string NS_TD_DEXUAT_CN = "Đề xuất tuyển dụng";
    public static string NS_TD_KQ_PV_CN = "Quản lý kết quả phỏng vấn";
    public static string NS_QT_DEBATPD = "Phê duyệt nâng lương/Đề bạt";
    public static string NS_QT_NGHIPHEP_PD = "Phê duyệt nghỉ phép";
    public static string NS_QT_NGHIPHEP_LD_PD = "Phê duyệt nghỉ phép lãnh đạo";
    public static string CC_DKY_DMVSPD = "Phê duyệt đăng ký đi muộn về sớm";
    public static string NS_DT_DEXUAT_LD = "Đề xuất đào tạo";
    public static string NS_DT_DEXUAT_PD = "Phê duyệt đề xuất đào tạo";
    public static string NS_GT_CC_PD = "Phê duyệt giải trình chấm công";
    public static string NS_QT_NGHIVIEC_PD = "Phê duyệt nghỉ việc";
    public static string NS_DT_DSDAOTAO = "Phê duyệt danh sách khóa học";
    public static string NS_DT_TAOKH = "Khởi tạo khóa học";
    public static string NS_DT_DSDANGKY = "Phê duyệt danh sách đăng ký khóa học";
    public static string NS_CC_DKY_LTHEM_PD = "Phê duyệt đăng ký làm thêm giờ";
    public static string NS_TD_DXUAT_PD = "Phê duyệt đề xuất tuyển dụng";
    public static string NS_DG_PD_GIAO_KPI = "Phê duyệt giao KPI cho cán bộ";
    public static string NS_CPPD = "Phê duyệt chuyển phòng";
    public static string CBQL_CTCV_HT = "Quản lý xem xét chỉ tiêu công việc hàng tháng";
    public static string QL_DG_CV_HT = "Quản lý đánh giá công việc hàng tháng của nhân viên ";
    public static string NS_DG_QLXX_CT_KPI = "Quản lý xem xét chỉ tiêu giao KPIs";
    public static string NS_CB_DGIA_KPI_NV = "Cán bộ đánh giá KPIs";

}
public class TEN_BANG
{
    // tổ chức nhân sự
    public static string HT_MADVI = "HT_MA_DVI";
    public static string HT_MAPH = "HT_MA_PHONG";
    public static string NS_HDNS_DBIEN = "NS_HDNS_DBIEN";
    public static string NS_HDNS_MA_NNN = "NS_HDNS_MA_NNN";
    public static string NS_HDNS_MA_VTCDANH = "NS_MA_CDANH";
    public static string NS_MA_CDANH_LONGBAI2 = "NS_MA_CDANH_LONGBAI2";
    public static string HDNS_MA_LVCDANH = "HDNS_MA_LVCDANH";
    public static string NS_HDNS_GAN_CDANHDVI = "NS_HDNS_GAN_CDANHDVI";
    public static string NS_MA_KHUNGLUONG = "NS_MA_KHUNGLUONG";
    public static string HD_MA_HTTLUONG = "HD_MA_HTTLUONG";
    public static string NS_MA_NHOMLUONG = "NS_MA_NHOMLUONG";
    public static string NS_HDNS_MA_BACLUONG = "NS_HDNS_MA_BACLUONG";
    public static string HDNS_MOTA_CV = "NS_HDNS_MA_MOTA_CV";
    public static string NS_MA_PBAN_LONGBAI3 = "NS_HDNS_PBAN_LONGBAI3";
    public static string NS_MA_PBAN_NTDUC = "NS_HDNS_PBAN_NTDUC";
    public static string NS_MA_PBAN_NTDUC4 = "NS_HDNS_PBAN_NTDUC4";

    // Nghiệp vụ phần tuyển dụng
    public static string NS_TD_KH_NAM = "NS_TD_KH_NAM";
    public static string NS_TD_KH_DCHUYEN_BNHIEM = "NS_TD_KH_DCHUYEN_BNHIEM";
    public static string NS_TD_INFO_DEV = "NS_TD_INFO_DEV";
    public static string NS_TD_KH_DCBN = "NS_TD_KH_DCBN";
    public static string NS_TD_DEXUAT = "NS_TD_DEXUAT";
    public static string NS_TD_UV_CV = "NS_TD_UV_CV";
    public static string NS_TD_UV_YEUCAUTD = "NS_TD_UV_YEUCAUTD";
    public static string NS_TD_PD_CDANH_TD = "NS_TD_PD_CDANH_TD";
    public static string NS_TD_PHONGVAN = "NS_TD_PHONGVAN";
    public static string NS_TD_KQ = "NS_TD_KQ";
    public static string NS_TD_CAPNHAT_UV = "NS_TD_CAPNHAT_UV";
    public static string NS_TD_CHUYEN_UV_NV = "NS_TD_CHUYEN_UV_NV";
    // danh mục hồ sơ
    public static string NS_MA_HTDT = "NS_MA_HTDT";
    public static string NS_MA_CAPDT = "NS_MA_CAPDT";
    public static string NS_MA_QDINH = "NS_MA_QDINH";
    public static string NS_MA_LHD = "NS_MA_LHD";
    public static string NS_HDNS_MA_HTKHAC = "NS_HDNS_MA_HTKHAC";
    public static string NS_MA_PHUCLOI = "NS_MA_PHUCLOI";
    public static string NS_MA_HTKT = "NS_MA_HTKT";
    public static string NS_MA_HTKL = "NS_MA_HTKL";
    public static string NS_MA_CNNH = "NS_MA_CNNH";
    public static string NS_MA_NHA = "NS_MA_NHA";
    public static string NS_MA_THS = "NS_MA_THS";
    public static string NS_MA_TRUONGHOC = "NS_MA_TRUONGHOC";
    public static string NS_MA_CNGANH_DT = "NS_MA_CNGANH_DT";
    public static string NS_MA_NUOC = "NS_MA_NUOC";
    public static string NS_MA_QTRR = "NS_MA_QTRR";
    public static string NS_MA_UBCK = "NS_MA_UBCK";
    public static string NS_MA_CCHN = "NS_MA_CCHN";
    public static string NS_MA_CCC = "NS_MA_CCC";
    public static string NS_MA_TT = "NS_MA_TT";
    public static string NS_MA_QH = "NS_MA_QH";
    public static string NS_MA_XP = "NS_MA_XP";
    public static string NS_MA_PBO = "NS_MA_PBO";
    public static string NS_HS_MA_CHUNG_NHOM = "NS_HS_MA_CHUNG_NHOM";
    public static string NS_HS_MA_CHUNG = "NS_HS_MA_CHUNG";
    public static string NS_MA_FIELD = "NS_MA_FIELD";
    public static string NS_TK_MA_CHITIEU = "NS_TK_MA_CHITIEU";
    public static string NS_MA_KQ_HIENTHI = "NS_MA_KQ_HIENTHI";
    //Thiết lập hồ sơ
    public static string NS_TL_HTRO_ANTRUA_VUNG = "NS_TL_HTRO_ANTRUA_VUNG";
    public static string NS_TL_HTRO_ANTRUA_PHONG = "NS_TL_HTRO_ANTRUA_PHONG";
    public static string NS_TL_PC_VUNG = "NS_TL_PC_VUNG";
    public static string NS_TL_PC = "NS_TL_PC";
    public static string NS_MA_EMAIL_SN = "NS_MA_EMAIL_SN";
    public static string NS_TL_CCHN = "NS_TL_CCHN";

    // nghiệp vụ hồ sơ
    public static string NS_CB = "NS_CB";
    public static string NS_CB_QLY_PD = "NS_CB_QLY_PD";
    public static string NS_CDANH_KN = "NS_CDANH_KN";
    public static string NS_HDCT = "NS_HDCT";
    public static string NS_CP = "NS_CP";
    public static string NS_HD = "NS_HD";
    public static string NS_HD_PL = "NS_HD";
    public static string NS_LD_DA = "NS_LD_DA";
    public static string NS_TV = "NS_TV";
    public static string NS_DS_DEN = "NS_DS_DEN";
    public static string NS_KTKL_QLKT = "NS_KTKL_QLKT";
    public static string NS_KTKL_QLKL = "NS_KTKL_QLKL";
    public static string NS_PHUCLOI_CN = "NS_PHUCLOI_CN";
    public static string NS_PHUCLOI_TUDONG = "NS_PHUCLOI_TUDONG";
    public static string NS_PCAP = "NS_PCAP";
    public static string TI_BC_DONG = "TI_BC_DONG";
    public static string NS_DG_HDLD = "NS_DG_HDLD";
    // Quá trình trong hồ sơ nhân viên
    public static string NS_QHE = "NS_QHE";
    public static string NS_DTHV = "NS_DTHV";
    public static string NS_DT_NGHAN = "NS_DT_NGHAN";
    public static string NS_THS = "NS_THS";
    public static string NS_HO_GDINH = "NS_HO_GDINH";
    public static string NS_LSCT = "NS_LSCT";
    public static string NS_LS_QTCT = "NS_LS_QTCT";
    public static string NS_LS_LUONG = "NS_LS_LUONG";
    public static string NS_LS_HD_LD = "NS_LS_HD_LD";
    public static string NS_LS_KT = "NS_LS_KT";
    public static string NS_LS_KL = "NS_LS_KL";
    public static string NS_LS_QT_DT = "NS_LS_QT_DT";
    public static string NS_LS_DG = "NS_LS_DG";
    // Danh mục bảo hiểm
    public static string NS_MA_BV = "NS_MA_BV";
    public static string NS_MA_TILE_BH = "NS_MA_TILE_BH";
    public static string NS_MA_KHAC_NHOM = "NS_MA_KHAC_NHOM";
    public static string NS_MA_KHAC = "NS_MA_KHAC";
    public static string NS_MA_NHOM_CHEDO = "NS_MA_NHOM_CHEDO";
    public static string NS_MA_LYDOBHXH = "NS_MA_LYDOBHXH";
    public static string NS_MA_BIENDONGBHXH = "NS_MA_BIENDONGBHXH";
    public static string NS_MA_PHUONGANCHEDOBH = "NS_MA_PHUONGANCHEDOBH";
    // Nghiệp vụ bảo hiểm 
    public static string NS_KHAIBAO_DM = "NS_KHAIBAO_DM";
    public static string NS_TT_BH = "NS_TT_BH";
    public static string NS_BIENDONG_BH = "NS_BIENDONG_BH";
    public static string NS_BHXH_CHEDO = "NS_BHXH_CHEDO";
    public static string NS_DS_KDDK_BH = "NS_DS_KDDK_BH";
    // danh mục chấm công
    public static string NS_CC_MA_CCDB = "NS_CC_MA_CCDB";
    public static string NS_CC_MA_TSPB = "NS_CC_MA_TSPB";
    public static string TL_TLAP_LAMCA = "TL_TLAP_LAMCA";
    public static string NS_HDNS_MA_NGAYNGHI = "NS_HDNS_MA_NGAYNGHI";
    public static string TL_MA_KYLUONG = "TL_MA_KYLUONG";
    public static string CC_MA_TL_CC = "CC_MA_TL_CC";
    public static string CC_MA_GHCP = "CC_MA_GHCP";
    public static string NS_CC_MA_FORMTEST = "NS_CC_MA_FORMTEST";
    public static string TL_MA_CONGVIEC = "TL_MA_CONGVIEC";
    public static string TL_MA_SPHAM = "TL_MA_SPHAM";
    public static string TL_MA_CHATLUONG = "TL_MA_CHATLUONG";
    public static string TL_MA_DONGIA = "NS_TL_MA_DONGIA";
    public static string NS_CC_DKLV_NGOAI_CTY = "NS_CC_DKLV_NGOAI_CTY";
    public static string NS_CC_DKC_CONNHO = "NS_CC_DKC_CONNHO";
    public static string NS_CC_DKC_CONNHO_PD = "NS_CC_DKC_CONNHO";
    public static string NS_TD_PD_CDANH_TD_QL = "NS_TD_PD_CDANH_TD_QL";
    // thiết lập chấm công
    public static string NS_CC_MA_CCDV = "NS_CC_MA_CCDV";
    public static string NS_CC_CT_CONG = "NS_CC_CT_CONG";
    public static string TL_DT_CMD = "TL_DT_CMD";
    public static string CC_MA_CC = "CC_MA_CC";
    public static string TL_TLAP_LAMTHEM = "NS_CC_HSO_LTHEM";
    // nghiệp vụ chấm công
    public static string TL_PHANCA = "TL_PHANCA";
    public static string NS_CC_THONGTIN_NGHI = "NS_CC_THONGTIN_NGHI";
    public static string NS_CC_GT = "NS_CC_GT";
    public static string CC_DKY_DMVS = "CC_DKY_DMVS";
    public static string CC_DULIEU_VAORA = "CC_DULIEU_VAORA";
    public static string NS_CC_PHEP_NAM = "NS_CC_PHEP_NAM";
    public static string NS_CC_NGHIBU = "NS_CC_NGHIBU";
    public static string NS_CC_DKY_LTHEM = "NS_CC_DKY_LTHEM";
    public static string NS_CC_KB_LTHEM = "NS_CC_KB_LTHEM";
    public static string NS_CC_TONGHOP_LTHEM = "NS_CC_TONGHOP_LTHEM";
    public static string NS_CC_TH_MAY = "NS_CC_TH_MAY";
    public static string CC_CN_CT = "CC_CN_CT";
    public static string NS_CC_TH = "NS_CC_TH";
    public static string NS_CC_TH_TTS = "NS_CC_TH_TTS";
    public static string NS_CC_TH_KHOAN_SP = "NS_CC_TH_KHOAN_SP";
    public static string CC_SP_TT = "CC_SP_TT";
    public static string CC_SP_CN = "CC_SP_CN";
    // Danh mục tính lương
    public static string NS_TL_MA_ML = "NS_TL_MA_ML";
    public static string NS_TL_PHIEULUONG = "NS_TL_PHIEULUONG";
    public static string TL_TLAP_THUE = "TL_TLAP_THUE";
    // Thiết lập tính lương
    public static string NS_TL_MA_CTLUONG = "NS_TL_MA_CTLUONG";
    public static string TL_TLAP_GTRU_BANTHAN = "TL_TLAP_GTRU_BANTHAN";
    public static string TL_TLAP_DONGIA_TTS = "TL_TLAP_DONGIA_TTS";
    public static string TL_TLAP_THIEU_PHIEULENH = "TL_TLAP_THIEU_PHIEULENH";
    public static string TL_TLAP_TYLE_HOAHONG = "TL_TLAP_TYLE_HOAHONG";
    public static string NS_TL_DTUONG_BLUONG = "NS_TL_DTUONG_BLUONG";

    public static string TL_TLAP_GTRU = "TL_TLAP_GTRU";
    // Nghiệp vụ tính lương
    public static string TL_LUONG_IMP = "TL_LUONG_IMP";
    public static string TL_EMS_IMP = "TL_EMS_IMP";
    public static string NS_TL_VIPHAM = "NS_TL_VIPHAM";
    public static string NS_TL_BLUONG = "NS_TL_BLUONG";
    public static string NS_TL_BLUONG_BB = "NS_TL_BLUONG_BB";
    public static string NS_TL_BLUONG_BS = "NS_TL_BLUONG_BS";
    public static string NS_TL_BLUONG_TTS = "NS_TL_BLUONG_TTS";
    public static string TL_GIULUONG = "TL_GIULUONG";
    public static string NS_TL_QTTHUE = "NS_TL_QTTHUE";
    public static string NS_DSACH_GIAYTO_BBUOC = "NS_DSACH_GIAYTO_BBUOC";
    public static string NS_TL_KHOAN_PHAITHU = "NS_TL_KHOAN_PHAITHU";
    // Danh mục đánh giá 360
    public static string DG_DM_KDG = "DG_DM_KDG";
    public static string DG_DM_NHOM_CAUHOI = "DG_DM_NHOM_CAUHOI";
    public static string DG_DM_DTDG = "DG_DM_DTDG";
    public static string DG_DM_TLAP_DTUONG_DGIA = "DG_DM_TLAP_DTUONG_DGIA";
    public static string DG_DM_MDG = "DG_DM_MDG";
    // Nghiệp vụ đánh giá 360
    public static string DG_NGV_KHDG = "DG_NGV_KHDG";
    public static string DG_NGV_TONGHOP_DGNB = "DG_NGV_TONGHOP_DGNB";
    public static string DG_NGV_TONGHOP_DGKH = "DG_NGV_TONGHOP_DGKH";
    // Danh mục đánh giá
    public static string NS_DG_MA_KDG = "NS_DG_MA_KDG";
    public static string DG_DM_NHOM_TIEUCHI = "DG_DM_NHOM_TIEUCHI";
    public static string DG_DM_TIEUCHI = "DG_DM_TIEUCHI";
    public static string NS_DG_MA_CHUNG = "NS_DG_MA_CHUNG";
    // Thiết lập đánh giá
    public static string NS_DG_TLNL_CDANH = "NS_DG_TLNL_CDANH";
    public static string DG_DM_TCDG_CD = "DG_DM_TCDG_CD";
    public static string TL_QD_XL_DG = "TL_QD_XL_DG";
    public static string DG_DM_TLDGNV = "DG_DM_TLDGNV";
    // Nghiệp vụ đánh giá
    public static string KQ_DG_CTY = "KQ_DG_CTY";
    public static string DG_KQ_DGIA_THANG = "DG_KQ_DGIA_THANG";
    public static string DG_NGV_KQUA_DG_KPI = "DG_NGV_KQUA_DG_KPI";
    // Danh mục đào tạo
    public static string NS_DT_MA_NND = "NS_DT_MA_NND";
    public static string NS_DT_MA_NND_DV = "NS_DT_MA_NND_DV";
    public static string NS_DT_MA_KDTAO = "NS_DT_MA_KDTAO";
    public static string NS_DT_MA_CTDT_HT = "NS_DT_MA_CTDT_HT";
    public static string NS_DT_MA_DTAC = "NS_DT_MA_DTAC";
    public static string NS_DT_MA_GV_NOI = "NS_DT_MA_GV_NOI";
    public static string NS_DT_MA_CKET = "NS_DT_MA_CKET";
    public static string NS_DT_MA_CHUNG_NHOM = "NS_DT_MA_CHUNG_NHOM";
    public static string NS_DT_MA_CHUNG = "NS_DT_MA_CHUNG";
    // Nghiệp vụ đào tạo
    public static string NS_DT_NCAU = "NS_DT_NCAU";
    public static string NS_DT_KHDT_NAM = "NS_DT_KHDT_NAM";
    public static string NS_DT_KH_CT = "NS_DT_KH_CT";
    public static string NS_DT_HVIEN_TGIAN = "NS_DT_HVIEN_TGIAN";
    public static string NS_DT_TRIENKHAI = "NS_DT_TRIENKHAI";
    public static string NS_DT_HINHTHUC = "NS_DT_HINHTHUC";
    public static string NS_DT_TGIAN_GDAY = "NS_DT_TGIAN_GDAY";
    public static string NS_DT_TGIAN_GDAY_HVIEN = "NS_DT_TGIAN_GDAY_HVIEN";
    public static string NS_DT_DANHGIA_CL_KDT = "NS_DT_DANHGIA_CL_KDT";
    // Danh mục đào tạo online
    public static string NS_DT_GVIEN = "NS_DT_GVIEN";
    public static string NS_DT_MA_LVDAOTAO = "NS_DT_MA_LVDAOTAO";
    public static string NS_DT_MA_NGUONKP = "NS_DT_MA_NGUONKP";
    public static string NS_DT_MA_NKYNANG = "NS_DT_MA_NKYNANG";
    public static string NS_DT_MA_KYNANG = "NS_DT_MA_KYNANG";
    public static string NS_MA_HEDT = "NS_MA_HEDT";
    public static string NS_MA_LDT = "NS_MA_LDT";
    // Thiết lập đào tạo online 
    public static string NS_DT_NHUCAU_DT = "NS_DT_NHUCAU_DT";
    // Nghiệp vụ đào tạo online 
    public static string NS_DT_KHOITAO_KS = "NS_DT_KHOITAO_KS";
    public static string NS_DT_TONGHOP_PHIEU_KS = "NS_DT_TONGHOP_PHIEU_KS";
    public static string NS_DT_DXUAT = "NS_DT_DXUAT";
    public static string NS_DT_KDT = "NS_DT_KDT";
    public static string NS_DT_THUVIEN_DTHI = "NS_DT_THUVIEN_DTHI";
    public static string NS_DT_KHOITAO_DTHI = "NS_DT_KHOITAO_DTHI";
    public static string NS_DT_TOCHUC_THI = "NS_DT_TOCHUC_THI";
    public static string NS_DT_TINHDIEM_THI = "NS_DT_TINHDIEM_THI";
    public static string NS_DT_DANHGIA_KQ = "NS_DT_DANHGIA_KQ";
    public static string NS_DT_PHUKHAO = "NS_DT_PHUKHAO";
    public static string NS_DT_PHIEU_KS = "NS_DT_PHIEU_KS";
    // Quản trị Hệ thống nội bộ
    public static string HT_MANHOM = "HT_MANHOM";
    public static string HT_MANSD = "HT_MANSD";
    public static string HT_LOG = "HT_LOG";
    // Quản trị Thiết lập hệ thống
    public static string NS_CAIDAT_QLY = "NS_CAIDAT_QLY";
    public static string NS_DT_CAIDAT_PD = "NS_DT_CAIDAT_PD";
    public static string NS_TLAP_EMAIL = "NS_TLAP_EMAIL";
    public static string NS_TLAP_TTLH_BLUONG = "NS_TLAP_TTLH_BLUONG";
    public static string NS_TBAO_MENU_TLAP = "NS_TBAO_MENU_TLAP";
    public static string HT_MA_TUSINH = "HT_MA_TUSINH";
    // Cá nhân
    public static string NS_CB_TT = "NS_CB_TT";
    public static string NS_HD_DG_TT = "NS_HD_DG_TT";
    public static string NS_QT_XIN_NGHIPHEP = "NS_QT_XIN_NGHIPHEP";
    public static string NS_QT_LVIEC_NGOAICTY = "NS_QT_LVIEC_NGOAICTY";
    public static string NS_QT_DKY_NCN = "NS_QT_DKY_NCN";
    public static string NS_QT_NGHIVIEC = "NS_QT_NGHIVIEC";
    public static string NS_DT_DANGKYKH = "NS_DT_DANGKYKH";
    public static string NS_DT_DEXUAT = "NS_DT_DEXUAT";
    public static string NS_DT_DANHGIA_KDT = "NS_DT_DANHGIA_KDT";
    public static string NS_CC_CN_DKY_LTHEM = "NS_CC_CN_DKY_LTHEM";
    public static string CC_CN_DKY_DMVS = "CC_CN_DKY_DMVS";
    public static string NS_GT_CC = "NS_GT_CC";
    public static string NS_CC_QUETTHE = "NS_CC_QUETTHE";
    public static string TL_BLUONG_CN = "TL_BLUONG_CN";
    public static string DG_NGV_CTCV_HT = "DG_NGV_CTCV_HT";
    public static string DG_CV_THANG = "DG_CV_THANG";
    public static string CBNV_CT_KPI = "CBNV_CT_KPI";
    public static string DGIA_KPI_NV = "DGIA_KPI_NV";
    public static string DG_NGV_NBDG = "DG_NGV_NBDG";
    // Quản lý
    public static string NS_CB_QL = "NS_CB_QL";
    public static string NS_QT_DEBAT = "NS_QT_DEBAT";
    public static string NS_TD_DEXUAT_CN = "NS_TD_DEXUAT_CN";
    public static string NS_TD_KQ_PV_CN = "NS_TD_KQ_PV_CN";
    public static string NS_QT_DEBATPD = "NS_QT_DEBATPD";
    public static string NS_QT_NGHIPHEP_PD = "NS_QT_NGHIPHEP_PD";
    public static string NS_QT_NGHIPHEP_LD_PD = "NS_QT_NGHIPHEP_LD_PD";
    public static string CC_DKY_DMVSPD = "CC_DKY_DMVSPD";
    public static string NS_DT_DEXUAT_LD = "NS_DT_DEXUAT_LD";
    public static string NS_DT_DEXUAT_PD = "NS_DT_DEXUAT_PD";
    public static string NS_GT_CC_PD = "NS_GT_CC_PD";
    public static string NS_QT_NGHIVIEC_PD = "NS_QT_NGHIVIEC_PD";
    public static string NS_DT_DSDAOTAO = "NS_DT_DSDAOTAO";
    public static string NS_DT_TAOKH = "NS_DT_TAOKH";
    public static string NS_DT_DSDANGKY = "NS_DT_DSDANGKY";
    public static string NS_CC_DKY_LTHEM_PD = "NS_CC_DKY_LTHEM_PD";
    public static string NS_TD_DXUAT_PD = "NS_TD_DXUAT_PD";
    public static string NS_DG_PD_GIAO_KPI = "NS_DG_PD_GIAO_KPI";
    public static string NS_CPPD = "NS_CPPD";
    public static string CBQL_CTCV_HT = "CBQL_CTCV_HT";
    public static string QL_DG_CV_HT = "QL_DG_CV_HT";
    public static string NS_DG_QLXX_CT_KPI = "NS_DG_QLXX_CT_KPI";
    public static string NS_CB_DGIA_KPI_NV = "NS_CB_DGIA_KPI_NV";
}
#endregion

