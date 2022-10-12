using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sti_ch : System.Web.Services.WebService
{

    #region MÃ NHÓM CHỈ TIÊU
    [WebMethod(true)]
    public string Fs_NS_TK_MA_NHTK_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ti_ch.Fdt_NS_TK_MA_NHTK_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_NHTK_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ti_ch.Fdt_NS_TK_MA_NHTK_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_NHTK_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ti_ch.P_NS_TK_MA_NHTK_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TK_MA_NHTK_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_NHTK_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ti_ch.P_NS_TK_MA_NHTK_XOA(b_ma); return Fs_NS_TK_MA_NHTK_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ NHÓM CHỈ TIÊU

    #region MÃ CHỈ TIÊU TÌM KIẾM
    string[] a_s;
    private string[] Fas_ChMang(string b_s, string b_c)
    {
        try
        {
            if (b_s == null) return null;
            int h = 0;
            int b_i;
            int n = 0; string b_s_kt = b_s;
            while (b_s_kt != null)
            {
                b_i = b_s_kt.IndexOf(b_c);
                if (b_i < 0) { b_s_kt = null; n++; }
                else { b_s_kt = b_s_kt.Substring(b_i + 1); n++; }
            }
            a_s = new string[n];
            while (b_s != null)
            {
                b_i = b_s.IndexOf(b_c);
                if (h <= n - 1)
                {
                    if (b_i < 0) { a_s[h] = b_s; b_s = null; h++; }
                    else { a_s[h] = b_s.Substring(0, b_i); b_s = b_s.Substring(b_i + 1); h++; }
                }
                else b_s = null;
            }
            return a_s;
        }
        catch (Exception ex) { return null; }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_LKE_CT(string b_nhom, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_TK_LKE_CT(b_nhom);
            bang.P_THEM_COL(ref b_dt, "tt", "");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            return b_kq + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_CHITIEU_LKE(string b_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ti_ch.Fdt_NS_TK_MA_CHITIEU_LKE(b_nhom, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_CHITIEU_MA(string b_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ti_ch.Fdt_NS_TK_MA_CHITIEU_MA(b_nhom, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_CHITIEU_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ti_ch.P_NS_TK_MA_CHITIEU_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_TK_MA_CHITIEU, TEN_BANG.NS_TK_MA_CHITIEU);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nhom = mang.Fs_TEN_GTRI("nhom", a_cot, a_gtri);
            return Fs_NS_TK_MA_CHITIEU_MA(b_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_CHITIEU_XOA(string b_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ti_ch.P_NS_TK_MA_CHITIEU_XOA(b_nhom, b_ma);// ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_TK_MA_CHITIEU, TEN_BANG.NS_TK_MA_CHITIEU);
            return Fs_NS_TK_MA_CHITIEU_LKE(b_nhom, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ CHỈ TIÊU TÌM KIẾM

    #region MÃ KẾT QUẢ HIỂN THỊ
    [WebMethod(true)]
    public string Fs_NS_MA_KQ_HIENTHI_CT(string b_nhom, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_MA_KQ_HIENTHI_CT(b_nhom);
            bang.P_THEM_COL(ref b_dt, "chon", "");
            string b_kq = bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            se.P_TG_LUU("ti_bc_dong", "DT_BCDT", b_dt.Copy());
            return b_kq + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KQ_HIENTHI_LKE(string b_nhom, double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ti_ch.Fdt_NS_MA_KQ_HIENTHI_LKE(b_nhom, b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_MA_KQ_HIENTHI_MA(string b_loai, string b_nhom, string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ti_ch.Fdt_NS_MA_KQ_HIENTHI_MA(b_loai, b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KQ_HIENTHI_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ti_ch.P_NS_MA_KQ_HIENTHI_NH(b_dt_ct);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.NHAP, TEN_FORM.NS_MA_KQ_HIENTHI, TEN_BANG.NS_MA_KQ_HIENTHI);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            string b_nhom = mang.Fs_TEN_GTRI("nhom", a_cot, a_gtri);
            string b_loai = mang.Fs_TEN_GTRI("loai", a_cot, a_gtri);
            return Fs_NS_MA_KQ_HIENTHI_MA(b_loai, b_nhom, b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_MA_KQ_HIENTHI_XOA(string b_loai, string b_nhom, string b_ma, double[] a_tso, string[] a_cot)
    {
        try
        {
            ti_ch.P_NS_MA_KQ_HIENTHI_XOA(b_loai, b_nhom, b_ma);
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.NS, NHOM_CHUCNANG.DANH_MUC, THAOTAC.XOA, TEN_FORM.NS_MA_KQ_HIENTHI, TEN_BANG.NS_MA_KQ_HIENTHI);
            return Fs_NS_MA_KQ_HIENTHI_LKE(b_loai, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ KẾT QUẢ HIỂN THỊ

    #region TÌM KIẾM
    public static void P_KTRA_KIEU_THANG(string b_thang)
    {
        string b_loi_kieu = "loi:Sai kiểu tháng:loi";
        if (chuyen.CTH_SO(b_thang) == 300001)
            throw new Exception(b_loi_kieu);
    }

    [WebMethod(true)]
    public string Fs_NS_TIMKIEM(object[] a_dt_dk, object[] a_dt_kq, string[] a_cot)
    {
        try
        {
            string b_loai, b_ten;
            string b_gtri_tu, b_gtri_toi;
            string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt_dk[0]); object[] a_gtri_dk = (object[])a_dt_dk[1];
            DataTable b_dt_dk = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
            bang.P_BO_HANG(ref b_dt_dk, "nhom", "");
            //b_dt_dk = ti_ch.dk_replace(b_dt_dk);
            string[] a_cot_kq = chuyen.Fas_OBJ_STR((object[])a_dt_kq[0]); object[] a_gtri_kq = (object[])a_dt_kq[1];
            DataTable b_dt_kq = bang.Fdt_TAO_THEM(a_cot_kq, a_gtri_kq); bang.P_BO_HANG(ref b_dt_kq, "chon", "");

            for (int k = 0; k <= b_dt_dk.Rows.Count - 1; k++)
            {
                b_loai = chuyen.OBJ_S(b_dt_dk.Rows[k]["loai"]); b_gtri_tu = chuyen.OBJ_S(b_dt_dk.Rows[k]["gtri_tu"]);
                b_gtri_toi = chuyen.OBJ_S(b_dt_dk.Rows[k]["gtri_toi"]); b_ten = chuyen.OBJ_S(b_dt_dk.Rows[k]["ten"]);
                if (b_loai == "N")
                {
                    if (b_gtri_tu != "")
                    {
                        if (chuyen.CNG_SO(b_gtri_tu) == 30000101) return form.Fs_LOC_LOI("loi:Lỗi định dạng giá trị từ " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", chuyen.CNG_SO(b_gtri_tu), k);
                    }

                    if (b_gtri_toi != "")
                    {
                        if (b_gtri_tu == "") return form.Fs_LOC_LOI("loi:Phải nhập giá trị từ của " + b_ten + "trước !:loi");
                        else if (chuyen.CNG_SO(b_gtri_toi) == 30000101) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị tới' " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_toi", chuyen.CNG_SO(b_gtri_toi), k);
                    }

                }
                if (b_loai == "T")
                {
                    if (b_gtri_tu != "")
                    {
                        if (chuyen.CTH_SO(b_gtri_tu) == 300001) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị từ' của " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", chuyen.CTH_SO(b_gtri_tu), k);
                    }
                    if (b_gtri_toi != "")
                    {
                        if (b_gtri_tu == "") return form.Fs_LOC_LOI("loi:Phải nhập 'Giá trị từ' của " + b_ten + "trước !:loi");
                        else if (chuyen.CTH_SO(b_gtri_toi) == 300001) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị tới' của " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_toi", chuyen.CTH_SO(b_gtri_toi), k);
                    }

                }
            }
            bang.P_BO_COT(ref b_dt_dk, new string[] { "f1", "loai", "ktra", "f_tkhao" });
            DataTable b_dt = ti_ch.Fdt_NS_TIMKIEM(b_dt_dk, b_dt_kq);
            int i = bang.Fi_TIM_COL(b_dt, "nsinh"); if (i > 0) { bang.P_SO_CNG(ref b_dt, "nsinh"); }
            i = bang.Fi_TIM_COL(b_dt, "ngayd"); if (i > 0) { bang.P_SO_CNG(ref b_dt, "ngayd"); }
            i = bang.Fi_TIM_COL(b_dt, "thangd"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "thangd"); }
            i = bang.Fi_TIM_COL(b_dt, "thangc"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "thangc"); }
            i = bang.Fi_TIM_COL(b_dt, "ngayc"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "ngayc"); }
            bang.P_THEM_COL(ref b_dt, new string[] { "sott" });
            for (int j = 1; j <= b_dt.Rows.Count; j++) { bang.P_DAT_GTRI(ref b_dt, "sott", j, j - 1); }
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TIMKIEM2(object[] a_dt_dk, object[] a_dt_kq, string[] a_cot)
    {
        try
        {
            string b_loai, b_ten;
            string b_gtri_tu, b_gtri_toi;
            string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt_dk[0]); object[] a_gtri_dk = (object[])a_dt_dk[1];
            DataTable b_dt_dk = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
            bang.P_BO_HANG(ref b_dt_dk, "nhom", "");
            //b_dt_dk = ti_ch.dk_replace(b_dt_dk);
            string[] a_cot_kq = chuyen.Fas_OBJ_STR((object[])a_dt_kq[0]); object[] a_gtri_kq = (object[])a_dt_kq[1];
            DataTable b_dt_kq = bang.Fdt_TAO_THEM(a_cot_kq, a_gtri_kq); bang.P_BO_HANG(ref b_dt_kq, "chon", "");

            for (int k = 0; k <= b_dt_dk.Rows.Count - 1; k++)
            {
                b_loai = chuyen.OBJ_S(b_dt_dk.Rows[k]["loai"]); b_gtri_tu = chuyen.OBJ_S(b_dt_dk.Rows[k]["gtri_tu"]);
                b_gtri_toi = chuyen.OBJ_S(b_dt_dk.Rows[k]["gtri_toi"]); b_ten = chuyen.OBJ_S(b_dt_dk.Rows[k]["ten"]);
                if (b_loai == "N")
                {
                    if (b_gtri_tu != "")
                    {
                        if (chuyen.CNG_SO(b_gtri_tu) == 30000101) return form.Fs_LOC_LOI("loi:Lỗi định dạng giá trị từ " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", chuyen.CNG_SO(b_gtri_tu), k);
                    }

                    if (b_gtri_toi != "")
                    {
                        if (b_gtri_tu == "") return form.Fs_LOC_LOI("loi:Phải nhập giá trị từ của " + b_ten + "trước !:loi");
                        else if (chuyen.CNG_SO(b_gtri_toi) == 30000101) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị tới' " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_toi", chuyen.CNG_SO(b_gtri_toi), k);
                    }

                }
                if (b_loai == "T")
                {
                    if (b_gtri_tu != "")
                    {
                        if (chuyen.CTH_SO(b_gtri_tu) == 300001) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị từ' của " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_tu", chuyen.CTH_SO(b_gtri_tu), k);
                    }
                    if (b_gtri_toi != "")
                    {
                        if (b_gtri_tu == "") return form.Fs_LOC_LOI("loi:Phải nhập 'Giá trị từ' của " + b_ten + "trước !:loi");
                        else if (chuyen.CTH_SO(b_gtri_toi) == 300001) return form.Fs_LOC_LOI("loi:Lỗi định dạng 'Giá trị tới' của " + b_ten + "!:loi");
                        else bang.P_DAT_GTRI(ref b_dt_dk, "gtri_toi", chuyen.CTH_SO(b_gtri_toi), k);
                    }

                }
            }
            bang.P_BO_COT(ref b_dt_dk, new string[] { "f1", "loai", "ktra", "f_tkhao" });
            DataTable b_dt = ti_ch.Fdt_NS_TIMKIEM(b_dt_dk, b_dt_kq);
            int i = bang.Fi_TIM_COL(b_dt, "nsinh"); if (i > 0) { bang.P_SO_CNG(ref b_dt, "nsinh"); }
            i = bang.Fi_TIM_COL(b_dt, "ngayd"); if (i > 0) { bang.P_SO_CNG(ref b_dt, "ngayd"); }
            i = bang.Fi_TIM_COL(b_dt, "thangd"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "thangd"); }
            i = bang.Fi_TIM_COL(b_dt, "thangc"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "thangc"); }
            i = bang.Fi_TIM_COL(b_dt, "ngayc"); if (i > 0) { bang.P_SO_CTH(ref b_dt, "ngayc"); }
            bang.P_THEM_COL(ref b_dt, new string[] { "sott" });
            for (int j = 1; j <= b_dt.Rows.Count; j++) { bang.P_DAT_GTRI(ref b_dt, "sott", j, j - 1); }
            bang.P_DOI_TENCOL(ref b_dt, new string[] { "SO_THE", "TEN", "PHONG", "MA_DVI", "PHONG2", "MA_DVI1", "PHONG1" }, new string[] { "Mã cán bộ", "tên", "phòng", "mã đơn vị", "phòng 1", "mã đơn vị1", "phòng 2" });
            //Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
            //return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
            se.P_KQ_LUU("TK", "TK", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_EXCEL(string b_form, string b_md, string b_ma_bc, string b_ddan, string b_ten_rp, string b_kieu_in, object[] a_dt_ct, object[] a_dt)
    {
        string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri_dk = (object[])a_dt[1];
        DataTable b_dt = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
        bang.P_BO_HANG(ref b_dt, "sott", "");
        //if (a_dt_ct != null)
        //{
        //    string[] a_ten = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
        //    b_dt_ct = bang.Fdt_TAO_THEM(a_ten, a_gtri);
        //    bang.P_THEM_COL(ref b_dt_ct, new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" },
        //            new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        //}
        //else
        //{
        //    b_dt_ct = bang.Fdt_TAO_THEM(new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" }, new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        //}
        //DataSet b_ds = new DataSet(); b_dt.TableName = "B"; b_dt_ct.TableName = "TSO";
        //b_ds.Tables.Add(b_dt.Copy()); b_ds.AcceptChanges();
        //b_ds.Tables.Add(b_dt_ct.Copy()); b_ds.AcceptChanges();
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
        //se.P_KQ_LUU("TK_KQ", "EXCEL", b_ds);
        return "";
    }

    [WebMethod(true)]
    public string Fs_EXCEL_BC(string b_form, string b_md, string b_ma_bc, string b_ddan, string b_ten_rp, string b_kieu_in, object[] a_dt_ct, object[] a_dt)
    {
        string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri_dk = (object[])a_dt[1];

        DataSet b_ds_qk = ns_tt.Fdt_BC_7NGAY();

        DataTable b_dt = b_ds_qk.Tables[1];
        DataTable b_dt_ct;
        if (a_dt_ct != null)
        {
            string[] a_ten = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            b_dt_ct = bang.Fdt_TAO_THEM(a_ten, a_gtri);
            bang.P_THEM_COL(ref b_dt_ct, new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" },
                    new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        }
        else
        {
            b_dt_ct = bang.Fdt_TAO_THEM(new string[] { "md", "ma_bc", "ddan", "ten_rp", "kieu_in" }, new object[] { b_md, b_ma_bc, b_ddan, b_ten_rp, b_kieu_in });
        }
        DataSet b_ds = new DataSet(); b_dt.TableName = "B"; b_dt_ct.TableName = "TSO";
        b_ds.Tables.Add(b_dt.Copy()); b_ds.AcceptChanges();
        b_ds.Tables.Add(b_dt_ct.Copy()); b_ds.AcceptChanges();
        // Excelreport.DataTabletoExcelWorkbook(b_kq, "Format");
        se.P_KQ_LUU("TK_KQ", "EXCEL", b_ds);
        return "";
    }

    #endregion TÌM KIẾM

    #region FILES
    [WebMethod(true)]
    public string Fs_FILES_LKE(string b_so_id, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_FILES_LKE(b_so_id);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_FILES_XOA(string b_so_id, string b_tt)
    {
        try { ti_ch.P_FILES_XOA(b_so_id, b_tt); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion FILES

    #region MÃ THỐNG KÊ
    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKE_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ti_ch.Fdt_NS_TK_MA_THONGKE_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKE_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ti_ch.Fdt_NS_TK_MA_THONGKE_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKE_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ti_ch.P_NS_TK_MA_THONGKE_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_NS_TK_MA_THONGKE_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKE_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ti_ch.P_NS_TK_MA_THONGKE_XOA(b_ma); return Fs_NS_TK_MA_THONGKE_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MÃ THỐNG KÊ

    #region MÃ THỐNG KÊ CHI TIẾT

    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKECT_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_TK_MA_THONGKECT_LKE();
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKECT_CT(string b_ma)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_TK_MA_THONGKECT_CT(b_ma);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKECT_NH(object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ti_ch.P_NS_TK_MA_THONGKECT_NH(b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    [WebMethod(true)]
    public string Fs_NS_TK_MA_THONGKECT_XOA(string b_ma)
    {
        try
        {
            ti_ch.P_NS_TK_MA_THONGKECT_XOA(b_ma);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }
    #endregion MÃ THỐNG KÊ CHI TIẾT

    #region THỐNG KÊ
    // liet ke phong ban
    [WebMethod(true)]
    public string Fs_NS_THONGKE_LKE_PHONG(string b_nhom, string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_THONGKE_LKE_PHONG(b_nhom);
            bang.P_THEM_COL(ref b_dt, "tt", "");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion THỐNG KÊ

    #region MÃ TÌM KIẾM
    [WebMethod(true)]
    public string Fs_TI_MA_TK_LKE(string b_ps, string b_nv, string[] a_cot)
    {
        try
        {
            DataTable b_dt = Fdt_TI_MA_TK_SAN(b_ps, b_nv);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "K" : "C";
            b_dt = ti_ch.Fdt_TI_MA_TK_LKE(b_ps, b_nv);
            return b_kq + "#" + bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private DataTable Fdt_TI_MA_TK_SAN(string b_ps, string b_nv)
    {
        try
        {
            //string b_tmuc = Server.MapPath("~/App_form/" + b_ps + "/" + b_nv + "/" + b_nv + "_file");
            //string b_file = b_tmuc + "\\" + b_ps + "ttt_" + b_nv + ".xls";
            //DataTable b_dt = khac.Fdt_Excel(b_file); bang.P_DON(ref b_dt);
            //return b_dt;
            DataTable b_dt = new DataTable();
            return b_dt;
        }
        catch { return null; }
    }

    [WebMethod(true)]
    public string Fs_TI_MA_TK_SAN(string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            DataTable b_dt = Fdt_TI_MA_TK_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt))
            {
                DataTable b_dt_s = null;
                string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
                if (a_gtri != null) { b_dt_s = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_DON(ref b_dt_s); }
                if (!bang.Fb_TRANG(b_dt_s)) bang.P_BO_HANG(ref b_dt, "ma", b_dt_s, "ma");
            }
            return bang.Fs_BANG_CH(b_dt, new string[] { "ma", "ten", "loai" });
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TI_MA_TK_NH(string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            DataTable b_dt = null;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            if (a_gtri != null) { b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CSO_SO(ref b_dt, "rong"); bang.P_DON(ref b_dt); }
            if (bang.Fb_TRANG(b_dt)) return "loi:Nhập chi tiết:loi";
            bang.P_CH_KHONG(ref b_dt);
            bang.P_THEM_COL(ref b_dt, new string[] { "f_sht_tkhao" }, "SSS");
            //string b_tmuc = Server.MapPath("~/App_form/kt" + b_ps + "/kt" + b_ps + "_file");
            //string b_file = b_tmuc + "\\ttt_" + b_nv + ".xls";
            DataTable b_dt_s = Fdt_TI_MA_TK_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt_s))
            {
                string b_ma; int b_hang;
                foreach (DataRow b_dr in b_dt_s.Rows)
                {
                    b_ma = chuyen.OBJ_S(b_dr["ma"]);
                    b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
                    if (b_hang >= 0) bang.P_DAT_GTRI(ref b_dt, new string[] { "loai", "ktra", "f_tkhao", "f_sht_tkhao" },
                            new object[] { chuyen.OBJ_S(b_dr["loai"]), chuyen.OBJ_S(b_dr["ktra"]),
                            chuyen.OBJ_S(b_dr["f_tkhao"]), chuyen.OBJ_S(b_dr["f_sht_tkhao"]) }, b_hang);
                }
            }
            ti_ch.P_TI_MA_TK_NH(b_ps, b_nv, b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TI_MA_TK_XOA(string b_ps, string b_nv)
    {
        try { ti_ch.P_TI_MA_TK_XOA(b_ps, b_nv); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TI_MA_TK_TAO(string b_ps, string b_nv)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_TI_MA_TK_LKE(b_ps, b_nv);
            if (bang.Fb_TRANG(b_dt)) return "";
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["bb"]) == "C") b_dr["ten"] = chuyen.OBJ_S(b_dr["ten"]) + "(*)";
            }
            bang.P_THEM_COL(ref b_dt, new string[] { "nd", "loi" }, "SS");
            return khac.Fs_TTT_TAO(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion

    #region CẬP NHẬP THÔNG TIN
    [WebMethod(true)]
    public string Fs_NS_TI_THAYDOI_CT(string b_so_the)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_NS_TI_THAYDOI_CT(b_so_the);
            if (b_dt.Rows.Count <= 0) return "loi:Không có dữ liệu!:loi";
            bang.P_SO_CNG(ref b_dt, "nsinh");
            DataRow b_dr = b_dt.Rows[0];
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
            return b_dr["status"] + "$" + b_kq + "$" + b_dr["htks_mau"] + "#" + b_dr["gtinh_mau"] + "#" + b_dr["tenkhac_mau"] + "#" + b_dr["nsinh_mau"] + "#" + b_dr["noisinh_mau"]
                + "#" + b_dr["qquan_mau"] + "#" + b_dr["cmt_mau"] + "#" + b_dr["noio_mau"] + "#" + b_dr["dtoc_mau"] + "#" + b_dr["tongiao_mau"] + "#" + b_dr["skhoe_mau"]
                + "#" + b_dr["cao_mau"] + "#" + b_dr["can_mau"] + "#" + b_dr["nhommau_mau"];
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TI_THAYDOI_NH(string b_so_the, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri); bang.P_CNG_SO(ref b_dt_ct, "nsinh");
            ti_ch.P_NS_TI_THAYDOI_NH(b_so_the, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TI_THAYDOI_XOA(string b_so_the)
    {
        try
        { ti_ch.P_NS_TI_THAYDOI_XOA(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TI_THAYDOI_PD(string b_so_the)
    {
        try
        { ti_ch.P_NS_TI_THAYDOI_PD(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TI_THAYDOI_KPD(string b_so_the)
    {
        try
        { ti_ch.P_NS_TI_THAYDOI_KPD(b_so_the); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion CẬP NHẬP THÔNG TIN

    #region THỐNG KÊ SỐ LIỆU

    [WebMethod(true)]
    public string Fs_TI_THONGKE_TIM(object[] a_dt, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ma", "");
            bang.P_THAY_GTRI(ref b_dt, "loai_thamnien", "Dự án", "0");
            bang.P_THAY_GTRI(ref b_dt, "loai_thamnien", "Năm", "1");
            bang.P_THAY_GTRI(ref b_dt, "loai_thamnien", "Tháng", "2");

            bang.P_THAY_GTRI(ref b_dt, "loai_tncdanh", "Dự án", "0");
            bang.P_THAY_GTRI(ref b_dt, "loai_tncdanh", "Năm", "1");
            bang.P_THAY_GTRI(ref b_dt, "loai_tncdanh", "Tháng", "2");

            bang.P_THAY_GTRI(ref b_dt, "loai_chualenluong", "Dự án", "0");
            bang.P_THAY_GTRI(ref b_dt, "loai_chualenluong", "Năm", "1");
            bang.P_THAY_GTRI(ref b_dt, "loai_chualenluong", "Tháng", "2");

            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "" });
            DataTable b_dt_kq = ti_ch.P_TI_THONGKE_TIM(b_dt, b_dt_ct);
            DataRow b_dr = b_dt_kq.Rows[0];
            return chuyen.OBJ_S(b_dr["thamnien_ct"]) + "#" + chuyen.OBJ_S(b_dr["thamnien_cd"]) + "#" + chuyen.OBJ_S(b_dr["trinhdo"])
                + "#" + chuyen.OBJ_S(b_dr["mucluong"]) + "#" + chuyen.OBJ_S(b_dr["kynang"]) + "#" + chuyen.OBJ_S(b_dr["chualenluong"]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion THỐNG KÊ SỐ LIỆU

    #region EXECL TIEN LUONG
    [WebMethod(true)]
    public string Fs_EXCEL_TIENLUONG(string b_fileName, string exten, object[] a_dt_grid)
    {
        string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt_grid[0]); object[] a_gtri_dk = (object[])a_dt_grid[1];
        DataTable b_dt = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
        b_dt.TableName = "DATA";
        Excel_dungchung.ExportTemplate("Templates/ExportMau/" + b_fileName + exten, b_dt, b_dt, b_fileName);
        return "";
    }

    #endregion

    [WebMethod(true)]
    public string Fs_NS_BC_DONG(string b_nhom, object[] a_dt_dk, object[] a_dt_kq, string[] a_cot)
    {
        try
        {
            string b_loai, b_ten;
            string b_gtri_tu, b_gtri_toi, b_cot_ngay = "", b_cot_so = "";
            string[] a_cot_dk = chuyen.Fas_OBJ_STR((object[])a_dt_dk[0]); object[] a_gtri_dk = (object[])a_dt_dk[1];
            DataTable b_dt_dk = bang.Fdt_TAO_THEM(a_cot_dk, a_gtri_dk);
            bang.P_BO_HANG(ref b_dt_dk, "ten_ten", "");
            string[] a_cot_kq = chuyen.Fas_OBJ_STR((object[])a_dt_kq[0]); object[] a_gtri_kq = (object[])a_dt_kq[1];
            DataTable b_dt_kq = bang.Fdt_TAO_THEM(a_cot_kq, a_gtri_kq); bang.P_BO_HANG(ref b_dt_kq, "chon", "");
            foreach (DataRow drow in b_dt_kq.Rows)
            {
                if (drow["loai"].Equals("N"))
                {
                    b_cot_ngay = b_cot_ngay + drow["MA"].ToString() + ",";
                }
                if (drow["loai"].Equals("S"))
                {
                    b_cot_so = b_cot_so + drow["MA"].ToString() + ",";
                }
            }
            DataSet b_ds = ti_ch.Fdt_NS_BC_DONG(b_nhom, b_dt_dk, b_dt_kq);
            DataTable b_dt = b_ds.Tables[0]; DataTable b_dt1 = b_ds.Tables[1]; DataTable b_dt2 = b_ds.Tables[2];

            if (b_cot_ngay.Length > 0) { b_cot_ngay = b_cot_ngay.Substring(0, b_cot_ngay.Length - 1); bang.P_SO_CNG(ref b_dt1, b_cot_ngay); }
            if (b_cot_so.Length > 0) { b_cot_so = b_cot_so.Substring(0, b_cot_so.Length - 1); bang.P_SO_CSO(ref b_dt1, b_cot_so); }
            b_dt1.Columns.Remove("cot_null"); b_dt1.Columns.Add("sott");
            for (int j = 0; j < b_dt1.Rows.Count; j++)
            {
                b_dt1.Rows[j]["sott"] = j + 1;
            }
            DataSet b_ds_kq = new DataSet();
            b_ds_kq.Tables.Add(b_dt.Copy()); b_ds_kq.Tables.Add(b_dt1.Copy()); b_ds_kq.Tables.Add(b_dt2.Copy());
            se.P_KQ_LUU("TK", "TK", b_ds_kq);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TI_BC_DONG_THEM_DK(object[] a_dt_dk)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_dk[0]);
            object[] a_gtri = (object[])a_dt_dk[1];
            DataTable b_dt_dk = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            DataSet b_ds = ti_ch.Fds_TI_BC_DONG_THEM_DK(b_dt_dk);
            DataTable b_dt_kq = b_ds.Tables[0];
            bang.P_THAY_GTRI(ref b_dt_kq, "kh_ten", "AND", "Và");
            bang.P_THAY_GTRI(ref b_dt_kq, "kh_ten", "OR", "Hoặc");

            bang.P_THAY_GTRI(ref b_dt_kq, "pd_ten", "CO", "Có");
            bang.P_THAY_GTRI(ref b_dt_kq, "pd_ten", "NOT", "Không");

            bang.P_THAY_GTRI(ref b_dt_kq, "tt_ten", "=", "Bằng");
            bang.P_THAY_GTRI(ref b_dt_kq, "tt_ten", "LIKE", "Chứa");
            bang.P_THAY_GTRI(ref b_dt_kq, "tt_ten", "LH", "Lơn hơn");
            bang.P_THAY_GTRI(ref b_dt_kq, "tt_ten", "NH", "Nhỏ hơn");
            bang.P_THAY_GTRI(ref b_dt_kq, "tt_ten", "IS NULL", "Rỗng");

            string b_kq = (bang.Fb_TRANG(b_dt_kq)) ? "" : bang.Fs_BANG_GOP(b_dt_kq);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    // log thôi việc
    [WebMethod(true)]
    public string Fs_TI_TV_LOG_LKE(string[] a_cot)
    {
        try
        {
            DataTable b_dt = ti_ch.Fdt_TI_TV_LOG_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot) + "#" + b_dt.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


}
