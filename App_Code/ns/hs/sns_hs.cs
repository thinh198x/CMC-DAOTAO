using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Globalization;
using System.IO;

[System.Web.Script.Services.ScriptService]
public class sns_hs : System.Web.Services.WebService
{
    [WebMethod(true)]
    public string Fs_NS_CB_ANH()
    {
        try
        {
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            if (b_dt == null) return "";
            DataRow b_dr = b_dt.Rows[0];
            string b_kq = chuyen.OBJ_S(b_dr["duongdan"]);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_HOI(string b_so_the)
    {
        try
        {
            string b_phong, b_ten, b_email;
            DataTable b_dt = ns_hs.Fdt_NS_CB_HOI(b_so_the);
            object[] b_phongobj = bang.Fobj_COL_MANG(b_dt, "phong"); if (b_phongobj == null) b_phong = ""; else b_phong = chuyen.OBJ_S(b_phongobj[0]);
            object[] b_tenobj = bang.Fobj_COL_MANG(b_dt, "ten"); if (b_tenobj == null) b_ten = ""; else b_ten = chuyen.OBJ_S(b_tenobj[0]);
            object[] b_emailobj = bang.Fobj_COL_MANG(b_dt, "email"); if (b_emailobj == null) b_email = ""; else b_email = chuyen.OBJ_S(b_emailobj[0]);
            string b_kq = b_so_the + "#" + b_phong + "#" + b_ten + "#" + b_email;
            return b_kq;

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TEN_HOA(string b_ten)
    {
        try
        {
            return c_kieu_chu.P_BODAU(b_ten.ToUpper());
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_QH_XEM(string b_matt, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_QH_DR(b_matt);
            se.P_TG_LUU("ns_cb", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_XP_XEM(string b_maqh, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_XP_DR(b_maqh);
            se.P_TG_LUU("ns_cb", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_CNNH_XEM(string b_manh, string b_tenss)
    {
        try
        {
            DataTable b_dt = ns_ma.Fdt_NS_MA_CNNH_DR(b_manh);
            se.P_TG_LUU("ns_cb", b_tenss, b_dt.Copy());
            return bang.Fs_BANG_CH(b_dt, "MA,TEN");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_MA(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hs.Fdt_NS_CB_MA(b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "0", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "1", "Nghỉ việc");
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_TT_MA(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, string b_so_the, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_hs.Fdt_NS_CB_TT_MA(b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];

            bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "0", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt, "ten_ttr", "1", "Nghỉ việc");
            bang.P_SO_CNG(ref b_dt, "ngayd");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_the", b_so_the);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public double Fd_NS_CB_KT(object[] a_dt_ct)
    {
        string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
        DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_SO_CSO(ref b_dt_ct, "ma_cc");
        bang.P_CNG_SO(ref b_dt_ct, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst");
        return ns_hs.Fd_NS_CB_KT(b_dt_ct);
    }

    [WebMethod(true)]
    public string Fs_NS_CB_NH(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, double b_trangKT, string b_so_the_g, object[] a_dt_ct, object[] a_dt_ttt, object[] a_dt_nl, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "nsinh,ngay_cmt9,ngay_cmt,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngayd,ngay_tv,ngay_ct,ngay_bd_hopdong");
            bang.P_CSO_SO(ref b_dt_ct, "ma_cc,is_3b");
            DataTable b_dt_ttt;
            string[] a_cot_nl = chuyen.Fas_OBJ_STR((object[])a_dt_nl[0]); object[] a_gtri_nl = (object[])a_dt_nl[1];
            DataTable b_dt_nl = bang.Fdt_TAO_THEM(a_cot_nl, a_gtri_nl);
            if (chuyen.OBJ_S(b_so_the_g) != "")
            {
                b_dt_ct.Rows[0]["SO_THE"] = b_so_the_g;
            }

            if (a_dt_ttt[1] == null) b_dt_ttt = ns_khud.Fdt_TTT();
            else
            {
                b_dt_ttt = bang.Fdt_TAO_THEM(a_dt_ttt); bang.P_DON(ref b_dt_ttt, new string[] { "ma", "nd" });
                if (bang.Fi_TIM_COL(b_dt_ttt, "so_id_dt") >= 0) bang.P_CSO_SO(ref b_dt_ttt, "so_id_dt");
            }
            var b_tontai = double.Parse(ht_dungchung.Fdt_NS_CB_HOI(b_dt_ct.Rows[0]["SO_THE"].ToString()).Rows[0]["TONTAI"].ToString());
            if (b_tontai <= 0)
            {
                DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
                if (b_tusinh == null || b_tusinh.Rows.Count <= 0)
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        return Thongbao_dch.chuanhap_sothe;
                    }
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("NT"))
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        return Thongbao_dch.chuanhap_sothe;
                    }
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("TS"))
                {
                    b_dt_ct.Rows[0]["SO_THE"] = Fs_NS_CB_SINHMA(b_tusinh);
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("TS_NT"))
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        b_dt_ct.Rows[0]["SO_THE"] = Fs_NS_CB_SINHMA(b_tusinh);
                    }
                }
            }
            bang.P_CSO_SO(ref b_dt_nl, "muc_nl_id");
            string b_so_the = ns_hs.P_NS_CB_NH(b_dt_ct, b_dt_ttt, b_dt_nl);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CB, TEN_BANG.NS_CB);
            return Fs_NS_CB_MA(b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_TT_NH(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, double b_trangKT, string b_so_the_g, object[] a_dt_ct, object[] a_dt_ttt, object[] a_dt_nl, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "nsinh,ngay_cmt9,ngay_cmt,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngayd,ngay_tv,ngay_ct,ngay_bd_hopdong");
            bang.P_CSO_SO(ref b_dt_ct, "ma_cc,is_3b");
            DataTable b_dt_ttt;
            string[] a_cot_nl = chuyen.Fas_OBJ_STR((object[])a_dt_nl[0]); object[] a_gtri_nl = (object[])a_dt_nl[1];
            DataTable b_dt_nl = bang.Fdt_TAO_THEM(a_cot_nl, a_gtri_nl);
            if (chuyen.OBJ_S(b_so_the_g) != "")
            {
                b_dt_ct.Rows[0]["SO_THE"] = b_so_the_g;
            }

            if (a_dt_ttt[1] == null) b_dt_ttt = ns_khud.Fdt_TTT();
            else
            {
                b_dt_ttt = bang.Fdt_TAO_THEM(a_dt_ttt); bang.P_DON(ref b_dt_ttt, new string[] { "ma", "nd" });
                if (bang.Fi_TIM_COL(b_dt_ttt, "so_id_dt") >= 0) bang.P_CSO_SO(ref b_dt_ttt, "so_id_dt");
            }
            var b_tontai = double.Parse(ht_dungchung.Fdt_NS_CB_HOI(b_dt_ct.Rows[0]["SO_THE"].ToString()).Rows[0]["TONTAI"].ToString());
            if (b_tontai <= 0)
            {
                DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
                if (b_tusinh == null || b_tusinh.Rows.Count <= 0)
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        return Thongbao_dch.chuanhap_sothe;
                    }
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("NT"))
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        return Thongbao_dch.chuanhap_sothe;
                    }
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("TS"))
                {
                    b_dt_ct.Rows[0]["SO_THE"] = Fs_NS_CB_SINHMA(b_tusinh);
                }
                else if (b_tusinh.Rows[0]["SOTHE"].Equals("TS_NT"))
                {
                    if (string.IsNullOrEmpty(b_dt_ct.Rows[0]["SO_THE"].ToString()))
                    {
                        b_dt_ct.Rows[0]["SO_THE"] = Fs_NS_CB_SINHMA(b_tusinh);
                    }
                }
            }
            bang.P_CSO_SO(ref b_dt_nl, "muc_nl_id");
            string b_so_the = ns_hs.P_NS_CB_TT_NH(b_dt_ct, b_dt_ttt, b_dt_nl);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.NHAP, TEN_FORM.NS_CB_TT, TEN_BANG.NS_CB_TT);
            return Fs_NS_CB_TT_MA(b_phong, b_trangthai, b_so_the_tk, b_ten, b_so_the, b_trangKT, a_cot_lke);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    private string Fs_NS_CB_SINHMA(DataTable b_tusinh)
    {
        string b_SoTheCB = "";
        string b_dinhdang = "";
        int b_dodai = 0;
        try
        {


            b_dodai = int.Parse(b_tusinh.Rows[0]["DODAISOTHE"].ToString());

            b_dinhdang = b_tusinh.Rows[0]["TIENTO"].ToString();
            double b_tontai = 0;

            for (int i = 0; i < b_dodai - b_tusinh.Rows[0]["TIENTO"].ToString().Length; i++)
            {
                b_dinhdang = b_dinhdang + "0";
            }

            var b_dt_sothe = ht_dungchung.Fdt_NS_CB_MAX_MA(b_tusinh.Rows[0]["TIENTO"].ToString(), b_tusinh.Rows[0]["DODAISOTHE"].ToString(), b_dinhdang);
            if ((b_dt_sothe != null && b_dt_sothe.Rows.Count > 0) && !b_dt_sothe.Rows[0]["SO_THE"].Equals("0"))
            {
                var b_sothe = double.Parse(b_dt_sothe.Rows[0]["SO_THE"].ToString());

                do
                {
                    b_sothe = b_sothe + 1;
                    b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(b_sothe, b_dinhdang));
                    b_tontai = double.Parse(ht_dungchung.Fdt_NS_CB_HOI(b_SoTheCB).Rows[0]["TONTAI"].ToString());


                } while (b_tontai != 0);
            }
            else
                b_SoTheCB = string.Format("{0}", Microsoft.VisualBasic.Strings.Format(1, b_dinhdang));
        }
        catch (Exception)
        {

            b_SoTheCB = b_dinhdang.Substring(0, b_dodai - 1).ToString() + "1";
        }

        return b_SoTheCB;
    }

    [WebMethod(true)]
    public string Fs_NS_CB_XOA(string b_phong, string b_trangthai, string b_so_the_tk, string b_ten, string b_so_the, double[] a_tso, string[] a_cot)
    {
        try
        {
            ns_hs.P_NS_CB_XOA(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.XOA, TEN_FORM.NS_CB, TEN_BANG.NS_CB);
            return Fs_NS_CB_LKE(b_phong, b_trangthai, b_so_the_tk, b_ten, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_TT_GUI(string b_login, string b_so_the)
    {
        try
        {
            ns_hs.P_NS_CB_TT_GUI(b_so_the);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.CN, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.GUI_PHEDUYET, TEN_FORM.NS_CB_TT, TEN_BANG.NS_CB_TT);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_LKE(string b_phong, string b_trangthai, string b_so_the, string b_ten, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_hs.Fdt_NS_CB_LKE(b_phong, b_trangthai, b_so_the, b_ten.ToUpper(), b_tu, b_den);
            DataTable b_dt_tk = (DataTable)a_object[1];
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_ttr", "0", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt_tk, "ten_ttr", "1", "Nghỉ việc");
            bang.P_SO_CNG(ref b_dt_tk, "ngayd");
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt_tk, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_NS_CB_CT(string b_so_the, string b_so_id)
    {
        try
        {
            DataSet b_ds = ns_hs.Fdt_NS_CB_CT(b_so_the, b_so_id);
            DataTable b_dt_kq = b_ds.Tables[0];
            DataTable b_dt_ttt = b_ds.Tables[1];
            DataTable b_dt_nl = b_ds.Tables[2];
            var b_dvi = b_dt_kq.Rows[0]["DONVI"].ToString();
            var b_phong = b_dt_kq.Rows[0]["phong_ban"].ToString();
            var b_ban = b_dt_kq.Rows[0]["ban"].ToString();
            var b_nha = chuyen.OBJ_S(b_dt_kq.Rows[0]["NHA"]);
            bang.P_SO_CNG(ref b_dt_kq, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngay_bd_hopdong");
            //bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_PH", "PHONG");

            bang.P_BANG_GHEP(ref b_dt_kq, "nn,nn_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "dantoc,dantoc_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tongiao,tongiao_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_noisinh,tt_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_noisinh,qh_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_noisinh,xp_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_quequan,tt_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_quequan,qh_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_quequan,xp_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_thuongtru,tt_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_thuongtru,qh_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_thuongtru,xp_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_tamtru,tt_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_tamtru,qh_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_tamtru,xp_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "cdanh,cdanh_ten", "{");


            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_GT", "GTINH");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_TTHN", "tt_honnhan");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_DTCT", "dt_cutru");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_LNV", "loai_cb");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_HTTL", "ht_tinhluong");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_NH", "nha");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_MA_PBO", "ma_pbo");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "NV", "Nghỉ việc");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_DONVI", "DONVI");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_QUANHE_LL", "QUANHE_LL");


            DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_LKE_BY_MADVI(b_dvi);
            se.P_TG_LUU("ns_cb", "DT_PHONG_BAN", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_PHONG_BAN", "PHONG_BAN");

            b_dt = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            if (b_dt.Rows.Count <= 0)
            {
                bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            }
            se.P_TG_LUU("ns_cb", "DT_CDANH", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_CDANH", "CDANH");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_BCDANH", "bac_cdanh");

            DataTable b_dt_ss = ns_ma.Fdt_NS_MA_CNNH_DR(b_nha);
            se.P_TG_LUU("ns_cb", "DT_CNNH", b_dt_ss.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_CNNH", "cnhanh_nha");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_KHOI", "khoi");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_DTNV", "dtnv");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_ADDRESS", "address");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_BRANCH", "branch");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_QTRR", "qtrr");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_UBCK", "ubck");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb", "DT_VUNG", "vung");

            string b_kq = (bang.Fb_TRANG(b_dt_kq)) ? "" : bang.Fs_HANG_GOP(b_dt_kq, 0);
            DataRow b_dr = b_dt_kq.Rows[0]; string b_iurl = chuyen.OBJ_S(b_dr["iurl"]);
            se.se_nsd b_nsd = new se.se_nsd();
            string b_anh;
            if (b_iurl != "" && b_iurl != null) b_anh = b_nsd.ma_dvi + "/" + b_iurl;
            else b_anh = b_iurl;
            return b_kq + "#" + b_anh + "#" + bang.Fs_BANG_CH(b_dt_ttt, "ma,nd") + "#" + bang.Fs_BANG_CH(b_dt_nl);
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message);
        }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_QL_CT(string b_so_the, string b_so_id)
    {
        try
        {
            DataSet b_ds = ns_hs.Fdt_NS_CB_CT(b_so_the, b_so_id);
            DataTable b_dt_kq = b_ds.Tables[0];
            DataTable b_dt_ttt = b_ds.Tables[1];
            DataTable b_dt_nl = b_ds.Tables[2];
            var b_dvi = b_dt_kq.Rows[0]["DONVI"].ToString();
            var b_phong = b_dt_kq.Rows[0]["phong_ban"].ToString();
            var b_ban = b_dt_kq.Rows[0]["ban"].ToString();
            var b_nha = chuyen.OBJ_S(b_dt_kq.Rows[0]["NHA"]);
            bang.P_SO_CNG(ref b_dt_kq, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngay_bd_hopdong");
            //bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_PH", "PHONG");

            bang.P_BANG_GHEP(ref b_dt_kq, "nn,nn_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "dantoc,dantoc_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tongiao,tongiao_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_noisinh,tt_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_noisinh,qh_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_noisinh,xp_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_quequan,tt_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_quequan,qh_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_quequan,xp_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_thuongtru,tt_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_thuongtru,qh_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_thuongtru,xp_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_tamtru,tt_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_tamtru,qh_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_tamtru,xp_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "cdanh,cdanh_ten", "{");


            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_GT", "GTINH");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_TTHN", "tt_honnhan");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_DTCT", "dt_cutru");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_LNV", "loai_cb");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_HTTL", "ht_tinhluong");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_NH", "nha");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_MA_PBO", "ma_pbo");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "NV", "Nghỉ việc");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_DONVI", "DONVI");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_QUANHE_LL", "QUANHE_LL");


            DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_LKE_BY_MADVI(b_dvi);
            se.P_TG_LUU("ns_cb_ql", "DT_PHONG_BAN", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_PHONG_BAN", "PHONG_BAN");

            b_dt = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            if (b_dt.Rows.Count <= 0)
            {
                bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            }
            se.P_TG_LUU("ns_cb_ql", "DT_CDANH", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_CDANH", "CDANH");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_BCDANH", "bac_cdanh");

            DataTable b_dt_ss = ns_ma.Fdt_NS_MA_CNNH_DR(b_nha);
            se.P_TG_LUU("ns_cb_ql", "DT_CNNH", b_dt_ss.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_CNNH", "cnhanh_nha");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_KHOI", "khoi");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_DTNV", "dtnv");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_ADDRESS", "address");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_BRANCH", "branch");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_QTRR", "qtrr");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_UBCK", "ubck");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_ql", "DT_VUNG", "vung");

            string b_kq = (bang.Fb_TRANG(b_dt_kq)) ? "" : bang.Fs_HANG_GOP(b_dt_kq, 0);
            DataRow b_dr = b_dt_kq.Rows[0]; string b_iurl = chuyen.OBJ_S(b_dr["iurl"]);
            se.se_nsd b_nsd = new se.se_nsd();
            string b_anh;
            if (b_iurl != "" && b_iurl != null) b_anh = b_nsd.ma_dvi + "/" + b_iurl;
            else b_anh = b_iurl;
            return b_kq + "#" + b_anh + "#" + bang.Fs_BANG_CH(b_dt_ttt, "ma,nd") + "#" + bang.Fs_BANG_CH(b_dt_nl);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_ANH_TRA(string b_goc)
    {
        try
        {
            se.se_nsd b_se = new se.se_nsd();
            string b_tm = Server.MapPath("~/Outputs/file_nhap"), b_ten = "F_" + b_se.ma_dvi + "_" + (b_se.nsd).Replace("/", "-");
            string[] a_f = Directory.GetFiles(b_tm, b_ten + ".*");
            foreach (string b_s in a_f) File.Delete(b_s);
            b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            int b_i = b_goc.LastIndexOf('.');
            string b_mr = (b_i > 0) ? b_goc.Substring(b_i) : "";
            File.Copy(b_goc, b_tm + "/" + b_ten + b_mr, true);
            return "../../../Outputs/file_nhap/" + b_ten + b_mr;
        }
        //catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
        catch (Exception ex)
        {
            return "/images/no_image.png";
        }
    }

    [WebMethod(true)]
    public string Fs_FI_ANH_URL()
    {
        try
        {
            DataTable b_dt = se.Fdt_KQ_TRA("file", "file");
            string b_iurl = chuyen.OBJ_S(b_dt.Rows[0]["iurl"]);
            return b_iurl;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_DB_ANH_URL()
    {
        try
        {
            DataTable b_dt = ns_hs.Fdt_NS_DVI_ANH();
            string b_iurl = chuyen.OBJ_S(b_dt.Rows[0]["iurl"]);
            return b_iurl;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_QL_PD_LKE(string b_so_the, double[] a_tso, string[] a_cot, string[] a_cot2, string[] a_cot3, string[] a_cot4, string[] a_cot5)
    {
        try
        {
            double b_tu = chuyen.OBJ_N(a_tso[0]), b_den = chuyen.OBJ_N(a_tso[1]);
            // sơ yếu lý lịch
            Object[] obj = ns_hs.Fdt_NS_CB_QL_PD_SYLL_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_kq = (DataTable)obj[1];
            bang.P_SO_CNG(ref b_dt_kq, "ngay_cmt,ngay_cmt9");
            // quá trình công tác
            Object[] obj_LSCT = ns_hs.Fdt_NS_CB_QL_PD_LSCT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_LSCT = (DataTable)obj_LSCT[1];
            bang.P_SO_CNG(ref b_dt_LSCT, "ngayd,ngayc");
            bang.P_SO_CSO(ref b_dt_LSCT, "mucluong");
            // trình độ bằng cấp
            Object[] obj_BCCM = ns_hs.Fdt_NS_CB_QL_PD_BCCM_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_BCCM = (DataTable)obj_BCCM[1];
            bang.P_SO_CNG(ref b_dt_BCCM, "ngaycap");
            bang.P_SO_CTH(ref b_dt_BCCM, "thangd,thangc");
            // chứng chỉ đào tạo
            Object[] obj_NGHAN = ns_hs.Fdt_NS_CB_QL_PD_NGHAN_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_NGHAN = (DataTable)obj_NGHAN[1];
            bang.P_THAY_GTRI(ref b_dt_NGHAN, "loai_cc", "CCHN", "Chứng chỉ hành nghề");
            bang.P_THAY_GTRI(ref b_dt_NGHAN, "loai_cc", "CCC", "Chứng chỉ con");
            bang.P_THAY_GTRI(ref b_dt_NGHAN, "loai_cc", "CCK", "Chứng chỉ khác");
            bang.P_SO_CNG(ref b_dt_NGHAN, "tu_ngay,den_ngay,ngay_hl,ngay_hhl,ngay_hl_ccc,ngay_hhl_ccc,ngay_cap");
            bang.P_SO_CTH(ref b_dt_NGHAN, "thang_cap");
            bang.P_SO_CSO(ref b_dt_NGHAN, "so_tien");
            // thông tin nhân thân
            Object[] obj_QHNT = ns_hs.Fdt_NS_CB_QL_PD_QHNT_LKE(b_so_the, b_tu, b_den);
            DataTable b_dt_QHNT = (DataTable)obj_QHNT[1];
            bang.P_SO_CNG(ref b_dt_QHNT, "ngaysinh,ngay_cmt,ngayd,ngayc");

            return b_dt_kq.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_kq, a_cot) + "#" +
                   b_dt_LSCT.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_LSCT, a_cot2) + "#" +
                   b_dt_BCCM.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_BCCM, a_cot3) + "#" +
                   b_dt_NGHAN.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_NGHAN, a_cot4) + "#" +
                   b_dt_QHNT.Rows.Count + "#" + bang.Fs_BANG_CH(b_dt_QHNT, a_cot5);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_QL_PD_DUYET(string b_so_the, double[] a_tso, string[] a_cot, string[] a_cot2, string[] a_cot3, string[] a_cot4, string[] a_cot5,
        object[] a_dt_cot1, object[] a_dt_cot2, object[] a_dt_cot3, object[] a_dt_cot4, object[] a_dt_cot5)
    {
        try
        {
            string[] a_dt_c1 = chuyen.Fas_OBJ_STR((object[])a_dt_cot1[0]);
            object[] a_gtri1 = (object[])a_dt_cot1[1];
            DataTable b_dt_cot1 = bang.Fdt_TAO_THEM(a_dt_c1, a_gtri1);

            string[] a_dt_c2 = chuyen.Fas_OBJ_STR((object[])a_dt_cot2[0]);
            object[] a_gtri2 = (object[])a_dt_cot2[1];
            DataTable b_dt_cot2 = bang.Fdt_TAO_THEM(a_dt_c2, a_gtri2);

            string[] a_dt_c3 = chuyen.Fas_OBJ_STR((object[])a_dt_cot3[0]);
            object[] a_gtri3 = (object[])a_dt_cot3[1];
            DataTable b_dt_cot3 = bang.Fdt_TAO_THEM(a_dt_c3, a_gtri3);

            string[] a_dt_c4 = chuyen.Fas_OBJ_STR((object[])a_dt_cot4[0]);
            object[] a_gtri4 = (object[])a_dt_cot4[1];
            DataTable b_dt_cot4 = bang.Fdt_TAO_THEM(a_dt_c4, a_gtri4);

            string[] a_dt_c5 = chuyen.Fas_OBJ_STR((object[])a_dt_cot5[0]);
            object[] a_gtri5 = (object[])a_dt_cot5[1];
            DataTable b_dt_cot5 = bang.Fdt_TAO_THEM(a_dt_c5, a_gtri5);

            bang.P_BO_HANG(ref b_dt_cot1, "chon", ""); bang.P_BO_HANG(ref b_dt_cot2, "chon", "");
            bang.P_BO_HANG(ref b_dt_cot3, "chon", ""); bang.P_BO_HANG(ref b_dt_cot4, "chon", "");
            bang.P_BO_HANG(ref b_dt_cot5, "chon", "");
            if (b_dt_cot1.Rows.Count <= 0 && b_dt_cot2.Rows.Count <= 0 && b_dt_cot3.Rows.Count <= 0 && b_dt_cot4.Rows.Count <= 0 && b_dt_cot5.Rows.Count <= 0)
            {
                return Thongbao_dch.ChonDuLieu_pd;
            }
            ns_hs.P_NS_CB_QL_PD_DUYET_NH(b_dt_cot1, b_dt_cot2, b_dt_cot3, b_dt_cot4, b_dt_cot5);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.PHEDUYET, TEN_FORM.NS_CB_QLY_PD, TEN_BANG.NS_CB_QLY_PD);
            return Fs_NS_CB_QL_PD_LKE(b_so_the, a_tso, a_cot, a_cot2, a_cot3, a_cot4, a_cot5);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_QL_PD_KO_DUYET(string b_so_the, double[] a_tso, string[] a_cot, string[] a_cot2, string[] a_cot3, string[] a_cot4, string[] a_cot5,
        object[] a_dt_cot1, object[] a_dt_cot2, object[] a_dt_cot3, object[] a_dt_cot4, object[] a_dt_cot5)
    {
        try
        {
            string[] a_dt_c1 = chuyen.Fas_OBJ_STR((object[])a_dt_cot1[0]);
            object[] a_gtri1 = (object[])a_dt_cot1[1];
            DataTable b_dt_cot1 = bang.Fdt_TAO_THEM(a_dt_c1, a_gtri1);

            string[] a_dt_c2 = chuyen.Fas_OBJ_STR((object[])a_dt_cot2[0]);
            object[] a_gtri2 = (object[])a_dt_cot2[1];
            DataTable b_dt_cot2 = bang.Fdt_TAO_THEM(a_dt_c2, a_gtri2);

            string[] a_dt_c3 = chuyen.Fas_OBJ_STR((object[])a_dt_cot3[0]);
            object[] a_gtri3 = (object[])a_dt_cot3[1];
            DataTable b_dt_cot3 = bang.Fdt_TAO_THEM(a_dt_c3, a_gtri3);

            string[] a_dt_c4 = chuyen.Fas_OBJ_STR((object[])a_dt_cot4[0]);
            object[] a_gtri4 = (object[])a_dt_cot4[1];
            DataTable b_dt_cot4 = bang.Fdt_TAO_THEM(a_dt_c4, a_gtri4);

            string[] a_dt_c5 = chuyen.Fas_OBJ_STR((object[])a_dt_cot5[0]);
            object[] a_gtri5 = (object[])a_dt_cot5[1];
            DataTable b_dt_cot5 = bang.Fdt_TAO_THEM(a_dt_c5, a_gtri5);

            bang.P_BO_HANG(ref b_dt_cot1, "chon", ""); bang.P_BO_HANG(ref b_dt_cot2, "chon", "");
            bang.P_BO_HANG(ref b_dt_cot3, "chon", ""); bang.P_BO_HANG(ref b_dt_cot4, "chon", "");
            bang.P_BO_HANG(ref b_dt_cot5, "chon", "");
            if (b_dt_cot1.Rows.Count <= 0 && b_dt_cot2.Rows.Count <= 0 && b_dt_cot3.Rows.Count <= 0 && b_dt_cot4.Rows.Count <= 0 && b_dt_cot5.Rows.Count <= 0)
            {
                return Thongbao_dch.ChonDuLieu_pd;
            }
            ns_hs.P_NS_CB_QL_PD_KO_DUYET_NH(b_dt_cot1, b_dt_cot2, b_dt_cot3, b_dt_cot4, b_dt_cot5);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.KO_PHEDUYET, TEN_FORM.NS_CB_QLY_PD, TEN_BANG.NS_CB_QLY_PD);
            return Fs_NS_CB_QL_PD_LKE(b_so_the, a_tso, a_cot, a_cot2, a_cot3, a_cot4, a_cot5);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_CB_TT_CT(string b_so_the)
    {
        try
        {
            DataSet b_ds = ns_hs.Fdt_NS_CB_TT_CT(b_so_the);
            DataTable b_dt_kq = b_ds.Tables[0];
            DataTable b_dt_ttt = b_ds.Tables[1];
            DataTable b_dt_nl = b_ds.Tables[2];
            var b_dvi = b_dt_kq.Rows[0]["DONVI"].ToString();
            var b_phong = b_dt_kq.Rows[0]["phong_ban"].ToString();
            var b_ban = b_dt_kq.Rows[0]["ban"].ToString();
            var b_nha = chuyen.OBJ_S(b_dt_kq.Rows[0]["NHA"]);
            bang.P_SO_CNG(ref b_dt_kq, "nsinh,ngay_cmt9,ngay_cmt,ngayd,ngay_tv,ngay_ct,ngaycap_hchieu,ngaycap_visa,ngayhethan_visa,ngaythamgia,ngaycap_mst,ngay_bd_hopdong");


            bang.P_BANG_GHEP(ref b_dt_kq, "nn,nn_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "dantoc,dantoc_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tongiao,tongiao_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_noisinh,tt_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_noisinh,qh_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_noisinh,xp_noisinh_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_quequan,tt_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_quequan,qh_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_quequan,xp_quequan_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_thuongtru,tt_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_thuongtru,qh_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_thuongtru,xp_thuongtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "tt_tamtru,tt_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "qh_tamtru,qh_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "xp_tamtru,xp_tamtru_ten", "{");
            bang.P_BANG_GHEP(ref b_dt_kq, "cdanh,cdanh_ten", "{");


            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_GT", "GTINH");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_TTHN", "tt_honnhan");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_DTCT", "dt_cutru");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_LNV", "loai_cb");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_HTTL", "ht_tinhluong");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_NH", "nha");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_MA_PBO", "ma_pbo");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "LV", "Làm việc");
            bang.P_THAY_GTRI(ref b_dt_kq, "ten_ttr", "NV", "Nghỉ việc");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_DONVI", "DONVI");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_QUANHE_LL", "QUANHE_LL");


            DataTable b_dt = ht_dungchung.Fdt_MA_PHONG_LKE_BY_MADVI(b_dvi);
            se.P_TG_LUU("ns_cb_tt", "DT_PHONG_BAN", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_PHONG_BAN", "PHONG_BAN");

            b_dt = ht_dungchung.Fdt_MA_CDANH_BY_PHONG(b_phong);
            if (b_dt.Rows.Count <= 0)
            {
                bang.P_THEM_HANG(ref b_dt, new object[] { "", "" }, 0);
            }
            se.P_TG_LUU("ns_cb_tt", "DT_CDANH", b_dt.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_CDANH", "CDANH");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_BCDANH", "bac_cdanh");

            DataTable b_dt_ss = ns_ma.Fdt_NS_MA_CNNH_DR(b_nha);
            se.P_TG_LUU("ns_cb_tt", "DT_CNNH", b_dt_ss.Copy());
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_CNNH", "cnhanh_nha");

            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_KHOI", "khoi");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_DTNV", "dtnv");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_ADDRESS", "address");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_BRANCH", "branch");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_QTRR", "qtrr");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_UBCK", "ubck");
            bang.P_TIM_THEM(ref b_dt_kq, "ns_cb_tt", "DT_VUNG", "vung");

            string b_kq = (bang.Fb_TRANG(b_dt_kq)) ? "" : bang.Fs_HANG_GOP(b_dt_kq, 0);
            DataRow b_dr = b_dt_kq.Rows[0]; string b_iurl = chuyen.OBJ_S(b_dr["iurl"]);
            se.se_nsd b_nsd = new se.se_nsd();
            string b_anh;
            if (b_iurl != "" && b_iurl != null) b_anh = b_iurl;
            else b_anh = b_iurl;
            return b_kq + "#" + b_anh + "#" + bang.Fs_BANG_CH(b_dt_ttt, "ma,nd") + "#" + bang.Fs_BANG_CH(b_dt_nl);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }


}