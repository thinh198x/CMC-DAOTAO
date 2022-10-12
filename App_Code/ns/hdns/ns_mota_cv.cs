using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;

public class ns_mota_cv
{
    #region MÔ TẢ CÔNG VIỆC
    public static DataTable Fdt_NS_HDNS_VTCD_DROP_LKE()
    {
        return dbora.Fdt_LKE("PNS_HDNS_VTCD_DROP_LKE");
    }
    public static DataTable Fdt_NS_HDNS_VTCD_DROP_MA()
    {
        return dbora.Fdt_LKE("PNS_HDNS_VTCD_DROP_MA");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_NS_HDNS_MOTA_CV_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PHDNS_MOTA_CV_LKE");
    } 
    public static void P_NS_HDNS_MOTA_CV_NH(ref double b_so_id, DataTable b_dt_ct, DataTable b_dt_nv)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            string b_ma_nnn = chuyen.OBJ_C(b_dt_ct.Rows[0]["NHOM_CD"]);
            string b_ma_cd = chuyen.OBJ_C(b_dt_ct.Rows[0]["CDANH"]);
            string b_muc_dich = chuyen.OBJ_C(b_dt_ct.Rows[0]["MUCDICH"]);
            string b_bao_cao_cho = chuyen.OBJ_C(b_dt_ct.Rows[0]["BAOCAO"]);
            string b_quan_he_trong = chuyen.OBJ_C(b_dt_ct.Rows[0]["QH_BENTRONG"]);
            string b_quan_he_ngoai = chuyen.OBJ_C(b_dt_ct.Rows[0]["QH_BENNGOAI"]);
            string b_ma_so_cv = chuyen.OBJ_C(b_dt_ct.Rows[0]["MA"]);
            string b_ngay_bh = chuyen.OBJ_S(b_dt_ct.Rows[0]["NGAY_BH"]);
            string b_ngay_sd = chuyen.OBJ_S(b_dt_ct.Rows[0]["NGAY_SD"]);
            string b_nguoi_st = chuyen.OBJ_C(b_dt_ct.Rows[0]["MA_NGUOI_ST"]);
            string b_nguoi_pd = chuyen.OBJ_C(b_dt_ct.Rows[0]["MA_NGUOI_PD"]);
            string b_ky_nang = chuyen.OBJ_C(b_dt_ct.Rows[0]["KYNANG"]);
            string b_kinh_nghiem = chuyen.OBJ_C(b_dt_ct.Rows[0]["KINHNGHIEM"]);
            string b_chuyen_nganh = chuyen.OBJ_C(b_dt_ct.Rows[0]["CHUYENNGANH"]);
            string b_bangcap = chuyen.OBJ_C(b_dt_ct.Rows[0]["BANGCAP"]);
            string b_yc_khac = chuyen.OBJ_C(b_dt_ct.Rows[0]["YC_KHAC"]);

            object[] a_stt_nv = bang.Fobj_COL_MANG(b_dt_nv, "SOTT");
            object[] a_nhiemvu_cv_nv = bang.Fobj_COL_MANG(b_dt_nv, "NV_CV");
            object[] a_thamquyen_nv = bang.Fobj_COL_MANG(b_dt_nv, "THAMQUYEN");
            object[] a_ketqua_nv = bang.Fobj_COL_MANG(b_dt_nv, "MUCTIEU_KQ");

            dbora.P_THEM_PAR(ref b_lenh, "a_stt_nv", 'N', a_stt_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhiemvu_cv_nv", 'U', a_nhiemvu_cv_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_thamquyen_nv", 'U', a_thamquyen_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ketqua_nv", 'U', a_ketqua_nv);
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id_t", 'N');

            string b_c = "," + b_so_id + "," + b_ma_nnn + "," + b_ma_cd + "," + b_muc_dich + "," + b_bao_cao_cho + "," + b_quan_he_trong + "," + b_quan_he_ngoai +
            "," + b_ma_so_cv + "," + chuyen.CNG_SO(b_ngay_bh) + "," + chuyen.CNG_SO(b_ngay_sd) + "," + b_nguoi_st + "," + b_nguoi_pd + "," + b_ky_nang +
            "," + b_kinh_nghiem + "," + b_chuyen_nganh + "," + b_bangcap + "," + b_yc_khac +
            ",:a_stt_nv,:a_nhiemvu_cv_nv,:a_thamquyen_nv,:a_ketqua_nv,:b_so_id_t";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHDNS_MOTA_CV_NH(" + b_se.tso + b_c + "); end;";
            try
            {

                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id_t"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fds_HDNS_MOTA_CV_CT(double b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PHDNS_MOTA_CV_CT");
    }

    ///<summary> Xóa </summary>
    public static void P_NS_HDNS_MOTA_CV_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, "PHDNS_MOTA_CV_XOA");
    }

    public static object[] Fdt_NS_HDNS_MOTA_CV_SOID(double b_so_id, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_trangkt }, "NNR", "PHDNS_MOTA_CV_SOID");
    }

    public static object[] Fdt_NS_HDNS_MOTA_CV_MA(string b_ma_nnn, string b_ma_cd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma_nnn, b_ma_cd, b_trangkt }, "NNR", "PHDNS_MOTA_CV_MA");
    }

    public static DataTable Fdt_MOTA_CV_EXPORT_CD()
    {
        return dbora.Fdt_LKE("PHDNS_MOTA_CV_EXPORT_CD");
    }

    public static void Fdt_MOTA_CV_IMP_NH(DataTable b_dt_ct, DataTable b_dt_nv)
    {

        bang.P_CSO_SO(ref b_dt_nv, "STT");
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;

            object[] a_key_ct = bang.Fobj_COL_MANG(b_dt_ct, "KEY");
            object[] a_ma_nnn = bang.Fobj_COL_MANG(b_dt_ct, "NHOM_CD");
            object[] a_ma_cd = bang.Fobj_COL_MANG(b_dt_ct, "CDANH");
            object[] a_muc_dich = bang.Fobj_COL_MANG(b_dt_ct, "MUCDICH");
            object[] a_bao_cao_cho = bang.Fobj_COL_MANG(b_dt_ct, "BAOCAO");
            object[] a_quan_he_trong = bang.Fobj_COL_MANG(b_dt_ct, "QH_BENTRONG");
            object[] a_quan_he_ngoai = bang.Fobj_COL_MANG(b_dt_ct, "QH_BENNGOAI");
            object[] a_ma_so_cv = bang.Fobj_COL_MANG(b_dt_ct, "MA");
            object[] a_ngay_bh = bang.Fobj_COL_MANG(b_dt_ct, "NGAY_BH");
            object[] a_ngay_sd = bang.Fobj_COL_MANG(b_dt_ct, "NGAY_SD");
            object[] a_nguoi_st = bang.Fobj_COL_MANG(b_dt_ct, "MA_NGUOI_ST");
            object[] a_nguoi_pd = bang.Fobj_COL_MANG(b_dt_ct, "MA_NGUOI_PD");
            object[] a_kynang = bang.Fobj_COL_MANG(b_dt_ct, "KYNANG");
            object[] a_kinhnghiem = bang.Fobj_COL_MANG(b_dt_ct, "KINHNGHIEM");
            object[] a_chuyennganh = bang.Fobj_COL_MANG(b_dt_ct, "CHUYENNGANH");
            object[] a_bangcap = bang.Fobj_COL_MANG(b_dt_ct, "BANGCAP");
            object[] a_yc_khac = bang.Fobj_COL_MANG(b_dt_ct, "YC_KHAC");

            object[] a_key_nv = bang.Fobj_COL_MANG(b_dt_nv, "KEY");
            object[] a_stt = bang.Fobj_COL_MANG(b_dt_nv, "STT");
            object[] a_nhiemvu_cv = bang.Fobj_COL_MANG(b_dt_nv, "NV_CV");
            object[] a_tham_quyen = bang.Fobj_COL_MANG(b_dt_nv, "THAMQUYEN");
            object[] a_ket_qua = bang.Fobj_COL_MANG(b_dt_nv, "MUCTIEU_KQ");

            dbora.P_THEM_PAR(ref b_lenh, "a_key_ct", 'N', a_key_ct);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_nnn", 'U', a_ma_nnn);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_cd", 'U', a_ma_cd);
            dbora.P_THEM_PAR(ref b_lenh, "a_muc_dich", 'U', a_muc_dich);
            dbora.P_THEM_PAR(ref b_lenh, "a_bao_cao_cho", 'U', a_bao_cao_cho);
            dbora.P_THEM_PAR(ref b_lenh, "a_quan_he_trong", 'U', a_quan_he_trong);
            dbora.P_THEM_PAR(ref b_lenh, "a_quan_he_ngoai", 'U', a_quan_he_ngoai);
            dbora.P_THEM_PAR(ref b_lenh, "a_ma_so_cv", 'U', a_ma_so_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_bh", 'N', a_ngay_bh);
            dbora.P_THEM_PAR(ref b_lenh, "a_ngay_sd", 'N', a_ngay_sd);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_st", 'U', a_nguoi_st);
            dbora.P_THEM_PAR(ref b_lenh, "a_nguoi_pd", 'U', a_nguoi_pd);
            dbora.P_THEM_PAR(ref b_lenh, "a_kynang", 'U', a_kynang);
            dbora.P_THEM_PAR(ref b_lenh, "a_kinhnghiem", 'U', a_kinhnghiem);
            dbora.P_THEM_PAR(ref b_lenh, "a_chuyennganh", 'U', a_chuyennganh);
            dbora.P_THEM_PAR(ref b_lenh, "a_bangcap", 'U', a_bangcap);
            dbora.P_THEM_PAR(ref b_lenh, "a_yc_khac", 'U', a_yc_khac);

            dbora.P_THEM_PAR(ref b_lenh, "a_key_nv", 'N', a_key_nv);
            dbora.P_THEM_PAR(ref b_lenh, "a_sott_nv", 'N', a_stt);
            dbora.P_THEM_PAR(ref b_lenh, "a_nhiemvu_cv_nv", 'U', a_nhiemvu_cv);
            dbora.P_THEM_PAR(ref b_lenh, "a_tham_quyen_nv", 'U', a_tham_quyen);
            dbora.P_THEM_PAR(ref b_lenh, "a_ket_qua_nv", 'U', a_ket_qua);

            string b_c = ",:a_key_ct,:a_ma_nnn,:a_ma_cd,:a_muc_dich,:a_bao_cao_cho,:a_quan_he_trong,:a_quan_he_ngoai,:a_ma_so_cv,:a_ngay_bh,:a_ngay_sd";
            b_c += ",:a_nguoi_st,:a_nguoi_pd,:a_kynang,:a_kinhnghiem,:a_chuyennganh,:a_bangcap,:a_yc_khac,:a_key_nv,:a_sott_nv,:a_nhiemvu_cv_nv,:a_tham_quyen_nv";
            b_c += ",:a_ket_qua_nv";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PHDNS_MOTA_CV_IMP_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static string P_HDNS_MOTA_CV_FILE_LUU_NH(string b_so_id, string b_forms, string b_nv, string b_ten_kq, string b_ngay, string b_ten_file, string b_url, string b_file)
    {
        try
        {

            dbora.P_GOIHAM(new object[] { b_so_id, b_forms, b_nv, b_ten_kq, chuyen.CNG_SO(b_ngay), "N'" + chuyen.OBJ_S(b_ten_file), b_url, b_file }, "PNS_FILE_LUU_NH");
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }


    }
    #endregion MÔ TẢ CÔNG VIỆC
}