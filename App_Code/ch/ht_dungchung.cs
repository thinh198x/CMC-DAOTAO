using System;
using System.Data;
using System.Web;
using Cthuvien;
using Oracle.DataAccess.Client;
using System.Net;
using System.Net.NetworkInformation;
/// <summary>
/// Summary description for ht_dungchung
/// </summary>
/// 
public class ht_dungchung
{
    public static string b_ver = "2.1.2.15";

    #region Chức năng ghi log hệ thống
    public static void PHT_LOG(string b_phanhe, string b_nhom_chucnang, string b_thaotac, string b_chucnang, string b_bang_thaotac)
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_ma_tk = b_se.nsd, b_ngay_thaotac = DateTime.Today.ToString("dd/MM/yyyy"), b_gio_thaotac = DateTime.Now.ToString("HH:mm:ss");

        string b_diachi_ip = "", hostname = "";
        IPHostEntry ip = new IPHostEntry();
        hostname = System.Net.Dns.GetHostName();
        IPAddress[] ipAddress = Dns.GetHostAddresses(Dns.GetHostName());
        foreach (IPAddress listip in ipAddress)
        {
            if (listip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                b_diachi_ip = listip.ToString();
            }
        }
        dbora.P_GOIHAM(new object[] { b_ma_tk, "N'" + b_phanhe, "N'" + b_nhom_chucnang, "N'" + b_chucnang, "N'" + b_thaotac, chuyen.CNG_SO(b_ngay_thaotac), b_gio_thaotac, b_bang_thaotac, hostname, b_diachi_ip }, "PHT_LOG_NH");
    }
    #endregion

    // Lấy năm theo kỳ công
    public static DataTable Fdt_MA_KYLUONG_NAM_XEM()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_KYLUONG_NAM_XEM");
    }
    public static DataTable Fdt_DS_NHANVIEN_LV(string b_phong, double b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong }, "PNS_DS_NHANVIEN");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO_QD(string b_phong, double b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong }, "PNS_THONGTIN_CANBO_QD");
    }
    public static DataTable Fdt_NS_THONGTIN_QD_KHOANG(string b_so_the, string b_ky, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the, b_ky, b_phong }, "PNS_THONGTIN_QD_KHOANG");
    }
    public static DataTable Fdt_NS_NS_CB_THEO_NGAY(string b_phong, string b_ngay_qd)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, chuyen.CNG_SO(b_ngay_qd) }, "PNS_THONGTIN_CANBO_QD");
    }
    public static DataTable Fdt_MA_CALV_DR2()
    {
        return dbora.Fdt_LKE("PNS_MA_CALV_DR2");
    }
    public static DataTable Fdt_DS_NHANVIEN_NV_TT(string b_phong, double b_kyluong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_phong, b_kyluong }, "PNS_DS_NHANVIEN_NV_TT");
    }
    public static DataTable Fdt_MA_KYLUONG_NAM()
    {
        return dbora.Fdt_LKE("PNS_TL_MA_KYLUONG_NAM");
    }
    public static DataTable Fdt_MA_KYLUONG_BY_NAM()
    {
        return dbora.Fdt_LKE_S("", "PNS_TL_MA_KYLUONG_BY_NAM");
    }
    public static DataTable Fdt_MA_KYLUONG_BY_NAM_THANG(string b_nam, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.OBJ_N(b_nam), chuyen.OBJ_N(b_thang) }, "PNS_TL_MA_KYLUONG_BY_NAM_THANG");
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và nội dung
    public static DataTable Fdt_MA_KDT_NAM(string b_nam, string b_noidung)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), b_noidung }, "pns_dt_ma_kdt");
    }
    public static DataTable Fdt_NS_CB_DS()
    {
        return dbora.Fdt_LKE("PNS_CB_LKE_DS");
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và tháng ở form nhu cầu
    public static DataTable Fdt_MA_KDT_NHUCAU(string b_nam, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang) }, "PNS_DT_MA_KDT_NHUCAU");
    }
    // Lấy các khóa đào tạo ở trạng thái Áp dụng theo năm và tháng ở form kế hoạch đào tạo năm
    public static DataTable Fdt_MA_KDT_KH_NAM(string b_nam, string b_thang)
    {
        return dbora.Fdt_LKE_S(new object[] { chuyen.CSO_SO(b_nam), chuyen.CSO_SO(b_thang) }, "PNS_DT_MA_KDT_NAM");
    }
    public static string IsTime(string svalue, string b_loi_sai)
    {
        string value = null;
        try
        {
            value = svalue.Trim();
            var hour = value.Split(':')[0];
            var minute = value.Split(':')[1];
            if (KiemTra.EmptyValue(hour))
            {
                return b_loi_sai;
            }
            if (KiemTra.EmptyValue(minute))
            {
                return b_loi_sai;
            }
            if (int.Parse(hour) > 23 || int.Parse(hour) < 0)
            {
                return b_loi_sai;
            }
            if (int.Parse(minute) >= 60 || int.Parse(minute) < 0)
            {
                return b_loi_sai;
            }
            if (KiemTra.IsNumber2(hour))
            {
                return b_loi_sai;
            }
            if (KiemTra.IsNumber2(minute))
            {
                return b_loi_sai;
            }
            return "";
        }
        catch (Exception ex)
        {
            return b_loi_sai;
        }
    }
    public static DataTable Fhdns_NAM()
    {
        return dbora.Fdt_LKE("PHDNS_NAM");
    }
    public static DataTable Fdt_MA_KYLUONG(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PHT_MA_KYLUONG_BYNAM");
    }
    public static DataTable Fdt_SO_THE_THEP_PHONG(string b_so_the_dk, string b_phong)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_the_dk, b_phong }, "PHT_SO_THE_THEO_PHONG");
    }
    public static DataTable Fdt_MA_PHONG_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE2");
    }
    public static DataTable Fdt_MA_PHONG_LKE_BY_MADVI(string b_donvi)
    {
        return dbora.Fdt_LKE_S(b_donvi, "PHT_MA_PHONG_LKE2_BY_MADVI");
    }
    public static DataTable Fdt_MA_PHONG_CHITIET(string b_donvi, string b_phongban)
    {
        return dbora.Fdt_LKE_S(new object[] { b_donvi, b_phongban }, "PHT_MA_PHONG_CHITIET");
    }
    public static DataTable Fdt_MA_PBO_CHITIET(string b_donvi, string b_phongban)
    {
        return dbora.Fdt_LKE_S(new object[] { b_donvi, b_phongban }, "PHT_MA_PBO_CHITIET");
    }

    public static DataTable Fdt_MA_PHONG_LKE_ALL()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_LKE_ALL");
    }
    public static DataTable Fdt_MA_CVU_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_CVU_LKE");
    }
    public static DataTable Fdt_CHUNG_LKE(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PHT_CHUNG_LKE");
    }
    public static DataTable Fdt_CHUNG_LKE_ORDER(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PHT_CHUNG_LKE_ORDER");
    }
    public static DataTable Fdt_DT_CHUNG_LKE(string b_loai)
    {
        return dbora.Fdt_LKE_S(b_loai, "PNS_DT_MA_CHUNG_DR");
    }
    public static DataTable Fdt_DT_LOAI_THI()
    {
        return dbora.Fdt_LKE("PNS_LOAI_THI");
    }
    public static void P_NS_CC_TONGHOP_MO(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id) }, "PNS_KYCONG_MO");
    }
    public static void P_NS_CC_TONGHOP_DONG(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id) }, "PNS_KYCONG_DONG");
    }
    // Lấy trạng thái kỳ công
    public static string P_NS_CC_TRANGTHAI_KYCONG(string b_phong, string b_kyluong_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "TRANG_THAI", 'N', 'O', 0);
            string b_c = "," + chuyen.OBJ_C(b_phong) + "," + b_kyluong_id + ",:TRANG_THAI";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TRANGTHAI_KYCONG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["TRANG_THAI"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    // Lấy trạng thái kỳ lương
    public static string P_NS_CC_TRANGTHAI_KYLUONG(string b_phong, string b_kyluong_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "TRANG_THAI", 'N', 'O', 0);
            string b_c = "," + chuyen.OBJ_C(b_phong) + "," + b_kyluong_id + ",:TRANG_THAI";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TRANGTHAI_KYLUONG(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["TRANG_THAI"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    public static void P_NS_TL_BLUONG_MO(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id) }, "PNS_KYLUONG_MO");
    }
    // Lấy trạng thái kỳ lương
    public static string P_NS_CC_TRANGTHAI_KYLUONG_VV(string b_phong, string b_kyluong_id)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "TRANG_THAI", 'N', 'O', 0);
            string b_c = "," + chuyen.OBJ_C(b_phong) + "," + b_kyluong_id + ",:TRANG_THAI";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_TRANGTHAI_KYLUONG_VV(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["TRANG_THAI"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    public static void P_NS_CC_TONGHOP_DONG_VV(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id) }, "PNS_KYLUONG_DONG_VV");
    }
    public static void P_NS_TL_BLUONG_DONG(string b_phong, string b_kyluong_id)
    {
        dbora.P_GOIHAM(new object[] { b_phong, chuyen.OBJ_N(b_kyluong_id) }, "PNS_KYLUONG_DONG");
    }
    // Lấy kỳ lương theo ngày
    public static string FTL_LAY_KYLUONG_THEO_NGAY(double b_ngay)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "KYLUONG_ID", 'N', 'O', 0);
            string b_c = "," + b_ngay + ",:KYLUONG_ID";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PTL_KYLUONG_BY_NGAY(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                return chuyen.OBJ_S(b_lenh.Parameters["KYLUONG_ID"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    // lấy quận huyện THEO THÀNH PHỐ
    public static DataTable Fdt_NS_MA_QH_DR(string ma_tt)
    {
        return dbora.Fdt_LKE_S(ma_tt, "PNS_MA_QH_DR");
    }
    // LẤY xã phường THEO quận huyện
    public static DataTable Fdt_NS_MA_XP_DR(string ma_qh)
    {
        return dbora.Fdt_LKE_S(ma_qh, "PNS_MA_XP_DR");
    }
    // LẤY DỮ LIỆU DÂN TỘC
    public static DataTable Fdt_NS_MA_DT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_DT_DR");
    }
    // LẤY DỮ LIỆU TÔN GIÁO
    public static DataTable Fdt_NS_MA_TG_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_TG_DR");
    }
    public static DataTable Fdt_CAP_DAOTAO_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_CAPDT_DR");
    }
    public static DataTable Fdt_HE_DAOTAO_LKE()
    {
        return dbora.Fdt_LKE("PNS_MA_HEDT_DR");
    }
    public static DataTable Fdt_HOCHAM_DR()
    {
        return dbora.Fdt_LKE("PNS_HOCHAM_DR");
    }
    public static DataTable Fdt_HOCVI_DR()
    {
        return dbora.Fdt_LKE("PNS_HOCVI_DR");
    }
    public static DataTable Fdt_QUOCTICH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_NUOC_DR");
    }
    public static DataTable Fdt_NHOM_DR()
    {
        return dbora.Fdt_LKE("PNS_NHOM_DR");
    }
    public static DataTable Fdt_NOICAP_CMT()
    {
        return dbora.Fdt_LKE("PNS_NOICAP_CMT");
    }
    public static DataTable Fdt_NGANHANG()
    {
        return dbora.Fdt_LKE("PNS_NGANHANG");
    }
    public static DataTable Fdt_CHUYENNGANH_DAOTAO_LKE()
    {
        return dbora.Fdt_LKE("PNS_CHUYENNGANH_DAOTAO_DR");
    }
    public static DataTable Fdt_TUDONG_MA(string b_cot, string b_bang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_cot, b_bang }, "PHT_TUDONG_MA");
    }
    public static DataTable Fdt_NG_KY()
    {
        return dbora.Fdt_LKE("PHT_NG_KY");
    }
    // IMPORT HỢP ĐỒNG
    public static DataTable Fdt_NHOM_CDANH_CV()
    {
        return dbora.Fdt_LKE("PHT_NHOM_CDANH_CV");
    }
    public static DataTable Fdt_CDANH_CV()
    {
        return dbora.Fdt_LKE("PHT_CDANH_CV");
    }
    public static DataTable Fdt_MA_CDANH_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CDANH_DR");
    }
    public static DataTable Fdt_CDANH_CV(string b_ncdanh)
    {
        return dbora.Fdt_LKE_S(b_ncdanh, "PNS_TD_CV_CDANH_BY_NCDANH");
    }
    public static DataTable Fdt_SO_THE_TONTAI(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CB_SO_THE_TONTAI");
    }
    public static DataTable Fdt_BAC_CDANH_CV()
    {
        return dbora.Fdt_LKE("PHT_BAC_CDANH_CV");
    }

    // IMPORT KHEN THƯỞNG KỶ LUẬT
    public static DataTable Fdt_MA_HINHTHUC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_HINHTHUC_DR");
    }
    public static DataTable Fdt_MA_LOAIDT_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_LOAIDT_DR");
    }
    public static DataTable Fdt_MA_CAP_KTKL_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CAP_KTKL_DR");
    }
    public static DataTable Fdt_MA_CALV_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_CALV_DR");
    }
    public static DataTable Fdt_ID_CC_DR()
    {
        return dbora.Fdt_LKE("PNS_ID_CC_DR");
    }
    public static DataTable PNS_MA_NOI_KTKL_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_NOI_KTKL_DR");
    }
    public static DataTable Fdt_MA_HINHTHUC_KL()
    {
        return dbora.Fdt_LKE("PNS_MA_HINHTHUC_KL_DR");
    }
    public static DataTable Fdt_HT_MA_TUSINH_MA()
    {
        return dbora.Fdt_LKE("PNS_HT_MA_TUSINH_MA");
    }
    public static DataTable Fdt_DT_DOT_KHAOSAT()
    {
        return dbora.Fdt_LKE("PNS_DT_DOT_KHAOSAT");
    }
    public static DataTable PNS_CC_MA_CC_DR()
    {
        return dbora.Fdt_LKE_S(new object[] { "1" }, "PNS_CC_MA_CC_DR");
    }
    public static DataTable Fdt_MA_CDANH_BY_PHONG(string b_phong)
    {
        return dbora.Fdt_LKE_S(b_phong, "PNS_MA_CDANH_BY_PHONG");
    }
    public static string Fdt_AutoGenCode(string b_kytudau, string b_tenbang, string b_tencot)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_kytudau, b_tenbang, b_tencot }, "PNS_AUTOGENCODE");
            if (b_dt.Rows.Count > 0)
            {
                string str = b_dt.Rows[0]["MA"].ToString();
                string number_str = str.Substring(str.IndexOf(b_kytudau) + b_kytudau.Length);
                if (number_str.Equals("000"))
                {
                    return b_kytudau + "001";
                }
                int number = int.Parse(number_str);
                number = number + 1;
                string ma = string.Format("{0:000}", number);
                return b_kytudau + ma;
            }
            else
            {
                return b_kytudau + "001";
            }
        }
        catch
        {
            return "";
        }
    }

    public static bool Fdt_kiemtra_tontai(string b_ma, string b_tenbang, string b_tencot)
    {
        try
        {
            DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ma, b_tenbang, b_tencot }, "PNS_KIEMTRA_TONTAI");
            if (chuyen.CSO_SO(b_dt.Rows[0]["MA"].ToString()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
    public static DataTable PNS_MA_KHAC_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_KHAC_DR");
    }

    #region CÁN BỘ
    public static DataTable Fdt_NS_CB_MAX_MA(string b_tiento, string b_dodai, string b_dinhdang)
    {
        return dbora.Fdt_LKE_S(new object[] { b_tiento, b_dodai, b_dinhdang }, "PNS_NS_CB_MAX_MA");
    }
    public static DataTable Fdt_NS_TONG_NHANSU(double b_nam, string b_phong, string b_cdanh)
    {
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_phong, b_cdanh }, "PNS_NS_CB_TONGNS");
    }
    public static DataTable Fdt_NS_TONG_NHANSU_PHONG(DataTable b_dt_tk)
    {
        var dr = b_dt_tk.Rows[0];
        string b_nam = dr["nam"].ToString(), b_donvi = dr["DONVI"].ToString();
        return dbora.Fdt_LKE_S(new object[] { b_nam, b_donvi }, "pns_ns_cb_tongns_phong");
    }
    public static DataTable Fdt_NS_CB_HOI(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_NS_CB_HOI");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_THONGTIN_CANBO");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO_TEN(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_THONGTIN_CANBO_TEN");
    }
    public static DataTable Fdt_NS_THONGTIN_CANBO_CDANH(string b_cdanh)
    {
        return dbora.Fdt_LKE_S(b_cdanh, "PNS_THONGTIN_CANBO_CD");
    }
    public static DataTable Fdt_HD_MA_LOAI_NV_DR()
    {
        return dbora.Fdt_LKE("PHD_MA_LOAI_NV_DR");
    }
    // Lấy ra các phòng theo level
    public static DataTable Fdt_PHONG_LEVEL_DR(string b_dvi, int b_level)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dvi, b_level }, "pns_phong_theo_level");
    }
    public static DataTable Fdt_NS_CB_TTCB(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_NS_CB_TTCB");
    }
    public static DataSet Fdt_NHOM_CD_DR(string b_cdanh)
    {
        return dbora.Fds_LKE(b_cdanh, 2, "pns_nhom_cd");
    }
    #endregion CÁN BỘ
    #region HỢP ĐỒNG
    public static DataTable Fdt_NS_HD_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_HD_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_HD_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SO_HD_HOI");
    }
    #endregion  HỢP ĐỒNG
    #region QUYẾT ĐỊNH/TỜ TRÌNH
    public static DataTable Fdt_NS_SO_QD_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_SOQD_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_SOQD_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SOQD_HOI");
    }
    #endregion QUYẾT ĐỊNH
    #region QUYẾT ĐỊNH THÔI VIỆC
    public static DataTable Fdt_NS_SO_QD_TV_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_SOQD_TV_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_SOQD_TV_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SOQD_TV_HOI");
    }
    #endregion QUYẾT ĐỊNH THÔI VIỆC
    #region QUYẾT ĐỊNH CHUYỂN PHÒNG
    public static DataTable Fdt_NS_SO_QD_CP_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_SOQD_CP_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_SOQD_CP_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SOQD_CP_HOI");
    }
    #endregion QUYẾT ĐỊNH  CHUYỂN PHÒNG
    #region QUYẾT ĐỊNH KY LUẬT
    public static DataTable Fdt_NS_SO_QD_KYLUAT_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_SOQD_KYLUAT_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_SOQD_KYLUAT_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SOQD_KYLUAT_HOI");
    }
    #endregion QUYẾT ĐỊNH KY LUAT
    #region QUYẾT ĐỊNH KHEN THUONG
    public static DataTable Fdt_NS_SO_QD_KHENTHUONG_MAX_MA(string b_dodai, string b_nam)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dodai, b_nam }, "PNS_NS_SOQD_KHENTHUONG_MAX_MA");
    }
    public static DataTable Fdt_NS_SO_SOQD_KHENTHUONG_HOI(string b_so_hd)
    {
        return dbora.Fdt_LKE_S(b_so_hd, "PNS_NS_SOQD_KHENTHUONG_HOI");
    }
    #endregion QUYẾT ĐỊNH  KHEN THUONG

    #region LOAD DỮ LIỆU LÊN CONTROL PHÒNG BAN, BỘ PHẬN, CHỨC DANH TRÊN LƯỚI NHẬP
    public static object[] Fdt_PHONG_LEVEL_DR_GR(string b_dvi, int b_level, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_dvi, b_level, b_tu, b_den }, "NR", "pns_phong_theo_level_drgr");
    }
    public static object[] Fdt_MA_CDANH_BY_PHONG_DR_GR(string b_congty, string b_phong, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_congty, b_phong, b_tu, b_den }, "NR", "pns_ma_cdanh_by_phong_drgr");
    }
    public static object[] Fdt_MA_CAPBAC_BY_CDANH_DR_GR(string b_congty, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_congty, b_tu, b_den }, "NR", "pns_nhom_cd_drgr");
    }
    // lấy chức danh theo công ty truyền vào đẩy lên combobox
    public static object[] Fdt_NS_MA_CDANH_BY_CTY(string b_congty, double b_tu, double b_den)
    {
        return dbora.Faobj_LKE(new object[] { b_congty, b_tu, b_den }, "NR", "PNS_MA_CDANH_BY_CTY");
    }
    #endregion

    // Kiểm tra mã danh mục đã được sử dụng
    public static double FTL_HOI_MA_TONTAI(string b_tenBang, string b_ten_cot, string b_giatri, ref string b_thongbao)
    {
        try
        {
            DataTable obj = dbora.Fdt_LKE_S(new object[] { b_tenBang, b_ten_cot, chuyen.OBJ_S(b_giatri) }, "FTL_HOI_MA_TONTAI");
            return chuyen.OBJ_N(obj.Rows[0]["TONTAI"].ToString());
        }
        catch (Exception ex)
        {
            return 0;
        }
    }

    // Phúc lợi
    public static DataTable PNS_MA_PHUCLOI_DR()
    {
        return dbora.Fdt_LKE("PNS_MA_PHUCLOI_DR");
    }
    #region Menu
    public static string Fs_HT_MENUB(string b_form, string b_ma)
    {
        string b_kq = "";
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_form, b_ma }, "PHT_MENUB");
        if (b_dt.Rows.Count > 0 && b_dt != null)
        {
            b_kq = b_dt.Rows[0]["menu"].ToString();
        }
        return b_kq;
    }
    #endregion Menu
    #region CÁC BẢNG CẦN KIỂM TRA TON TAI DU LIEU
    public const string NS_HD = "NS_HD";
    public const string HT_MA_PHONG = "HT_MA_PHONG";
    public const string NS_CB = "NS_CB";
    public const string NS_MA_QH = "NS_MA_QH";
    public const string NS_DT_GVIEN_CT = "NS_DT_GVIEN_CT";
    public const string NS_DT_KH = "NS_DT_KH";
    public const string NS_DT_KDT = "NS_DT_KDT";
    public const string NS_DT_MA_KYNANG = "NS_DT_MA_KYNANG";
    public const string NS_DT_DXUAT = "NS_DT_DXUAT";
    public const string NS_HDCT = "NS_HDCT";
    public const string NS_MA_TT = "NS_MA_TT";
    public const string NS_MA_VTRI = "NS_MA_VTRI";
    public const string NS_THS_CT = "NS_THS_CT";
    public const string NS_HDCT_PC = "NS_HDCT_PC";
    public const string NS_TTB = "NS_TTB";
    public const string NS_DT_QT_HOCTAP = "NS_DT_QT_HOCTAP";
    public const string NS_HDNS_MA_BL = "NS_HDNS_MA_BL";
    public const string NS_MA_CHUNG = "NS_MA_CHUNG";
    public const string NS_PHUCLOI_CN = "NS_PHUCLOI_CN";
    public const string NS_PHUCLOI_TUDONG = "NS_PHUCLOI_TUDONG";
    public const string NS_CC_TH = "NS_CC_TH";
    public const string NS_CC_PHANCA = "NS_CC_PHANCA";
    public const string NS_CC_TH_MAY = "NS_CC_TH_MAY";
    public const string NS_CC_THONGTIN_NGHI = "NS_CC_THONGTIN_NGHI";
    public const string TL_MA_CMD = "TL_MA_CMD";
    public const string NS_TT_BH = "NS_TT_BH";
    public const string NS_MA_KHAC = "NS_MA_KHAC";
    public const string NS_QUYEN_DH_CDANH = "NS_QUYEN_DH_CDANH";
    public const string NS_MA_LYDOBHXH = "NS_MA_LYDOBHXH";
    public const string NS_TD_KHCT = "NS_TD_KHCT";
    public const string NS_MA_CDANH = "NS_MA_CDANH";
    public const string NS_HDNS_MA_NNN = "NS_HDNS_MA_NNN";
    public const string NS_DT_MA_NND_DV = "NS_DT_MA_NND_DV";
    public const string NS_HDNS_GAN_CDANHDVI_CT = "NS_HDNS_GAN_CDANHDVI_CT";
    public const string NS_DT_MA_KDT = "NS_DT_MA_KDT";
    public const string NS_DT_KH_CT = "NS_DT_KH_CT";
    public const string NS_DT_KHOITAO_DTHI_CT = "NS_DT_KHOITAO_DTHI_CT";
    public const string NS_DS_CCHN = "NS_DS_CCHN";
    #endregion

    #region CÁC CỘT CẦN KIỂM TRA TON TAI DU LIEU
    public const string HTHUC = "HINHTHUC";
    public const string LHD = "LHD";
    public const string CAUHOI = "SO_ID_CH";
    public const string MA_DVI = "MA_DVI";
    public const string PHONG = "PHONG";
    public const string QTRR = "QTRR";
    public const string TT_HIENTAI = "TT_HIENTAI";
    public const string MA_TT = "MA_TT";
    public const string LVDAOTAO = "LVDAOTAO";
    public const string CAP_DT = "CAP_DT"; // KHÓA ĐÀO TẠO
    public const string NS_DT_KH_CAPDT = "CAP_DT"; // KẾ HOẠCH ĐÀO TẠO
    public const string NHOM_DT = "NHOM_DT";
    public const string UBCK = "UBCK";
    public const string HINHTHUC = "HINHTHUC";
    public const string KINHPHI = "KINHPHI";
    public const string NKYNANG = "NKYNANG";
    public const string GVIEN = "GVIEN";
    public const string MA_QG = "MA_QG";
    public const string CDANH = "CDANH";
    public const string MA_CDANH = "MA_CD";
    public const string MA = "MA";
    public const string MA_PC = "MA_PC";
    public const string MA_TB = "MA_TB";
    public const string MA_CNDT = "MA_CNDT";
    public const string NHA = "NHA";
    public const string CHINHANH_NH = "CHINHANH_NH";
    public const string LOAITIEN = "LOAITIEN";
    public const string VITRI = "VITRI";
    public const string NHOM_MA = "NHOM_MA";
    public const string LOAI_PL = "LOAI_PL";
    public const string MA_PHUCLOI = "MA_PHUCLOI";
    public const string MA_TL = "MA_TL";
    public const string MA_NL = "MA_NL";
    public const string MA_BL = "MA_BL";
    public const string KY = "KY";
    public const string KYLUONG_ID = "KYLUONG_ID";
    public const string MACC_NGHI = "MACC_NGHI";
    public const string MA_CA = "MA_CA";
    public const string NOIKHAM_CHUABENH = "NOIKHAM_CHUABENH";
    public const string LOAI_MA = "LOAI_MA";
    public const string MA_QUYEN_DH = "MA_QUYEN_DH";
    public const string MA_NHOM = "MA_NHOM";
    public const string DOT_TD = "DOT_TD";
    public const string MA_CDANH_XOA = "MA_CDANH";
    public const string NND = "NND";
    public const string NND_DV = "NND_DV";
    public const string DOITAC = "DOITAC";
    public const string KHOA_DT = "MA_KDT";
    #endregion


    #region NghiepDo
    public static DataTable Fdt_MA_QG(string b_phong)
    {
        return dbora.Fdt_LKE_S(b_phong, "PNS_MA_CDANH_BY_PHONG");
    }
    #endregion
}
