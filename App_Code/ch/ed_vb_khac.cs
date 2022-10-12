using System.Web;
using System.Data;
using Cthuvien;
using System.IO;
using System;

public class ed_vb_khac
{
    #region khac
    public static string Fs_KIEU(double b_so_id, double b_namP)
    {
        object b_obj = dbora.Fobj_LKE(new object[] { b_so_id, b_namP }, 'S', "PeD_vb_KIEU");
        return chuyen.OBJ_S(b_obj);
    }
    public static string Fs_TEN_VTRO(string b_vtro, string b_kieu = "")
    {
        string[] a_vtro = "D,Y,C,P,T,G,K".Split(','),
            a_ten = "Trình xem xét,Trình duyệt,Chủ trì,Phối hợp,Thông báo,Góp ý,Cấp trên ký".Split(',');
        int b_vtri = khac.Fi_VTRI_MANG(a_vtro, b_vtro);
        if (b_kieu == "DI") a_ten[4] = "Nơi nhận";
        return (b_vtri < 0) ? "" : a_ten[b_vtri];
    }
    public static string Fs_CTEN_VTRO(string b_ten, int b_l = 65)
    {
        string[] a_ten = b_ten.Split(',');
        int b_h = a_ten.Length;
        b_ten = "";
        for (int i = 0; i < a_ten.Length; i++)
        {
            if (a_ten[i].Length < b_l) { kytu.P_THEM(ref b_ten, a_ten[i]); b_l -= a_ten[i].Length; }
            else { b_h = i; break; }
        }
        if (b_h != a_ten.Length) b_ten += " (" + b_h.ToString() + "/" + a_ten.Length.ToString() + ")";
        return b_ten;
    }
    public static string Fs_TEN_NHOM(string b_nhom)
    {
        string[] a_nhom = "C,B,D,T".Split(','),
            a_ten = "Cá nhân,Bộ phận,Đơn vị,Cấp trên".Split(',');
        int b_vtri = khac.Fi_VTRI_MANG(a_nhom, b_nhom);
        return (b_vtri < 0) ? "" : a_ten[b_vtri];
    }
    public static DataTable Fdt_TTR_VTRO(double b_so_id, double b_namP)
    {
        return dbora.Fdt_LKE_S(new object[] { b_so_id, b_namP }, "PeD_VB_TTR_VTRO");
    }
    public static string Fs_YKI(DataTable b_dt)
    {
        string b_kq = "", b_c = "";
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_kq += b_c + " " + "<i class=\"css_Mnd\">" + kytu.C_NVL(chuyen.OBJ_S(b_dr["nsd"]))
                + " (" + chuyen.OBJ_S(b_dr["ngay"]) + ") " + "</i>" + chuyen.OBJ_S(b_dr["yki"]);
            b_c = "<br>";
        }
        return b_kq;
    }
    public static DataTable Fdt_CCTC(string b_loai, string b_dvi, string b_ma, string b_vtro)
    {
        return dbora.Fdt_LKE_S(new object[] { b_loai, b_dvi, b_ma, b_vtro }, "PNS_CCTC");
    }
    public static void P_TEN_MA_NH(string b_ma_nh, out string b_nhom, out string b_ma_dt, out string b_ten)
    {
        object[] a_obj = dbora.Faobj_LKE(b_ma_nh, "SSU", "PED_VB_TEN_MA_NH");
        b_nhom = chuyen.OBJ_S(a_obj[0]); b_ma_dt = chuyen.OBJ_S(a_obj[1]); b_ten = chuyen.OBJ_S(a_obj[2]);
    }
    public static string Fs_TEN_MA_VTRO(string b_nhom, string b_ma_dt)
    {
        object b_obj = dbora.Fobj_LKE(new object[] { b_nhom, b_ma_dt }, 'U', "PED_VB_TEN_VTRO");
        return chuyen.OBJ_S(b_obj);
    }

    public static string Fs_TSO_FORM(string b_form)
    {
        string b_fi = kytu.C_NVL(HttpContext.Current.Server.MapPath("~/bin/tsoForm.xls")), b_kq = "K";
        if (b_fi == "") se.P_TG_XOA(b_form, "DT_FORM");
        {
            DataTable b_dt = khac.Fdt_Excel(b_fi);
            bang.P_DON(ref b_dt);
            bang.P_GIU_HANG(ref b_dt, "FORM", b_form);
            if (bang.Fb_TRANG(b_dt)) se.P_TG_XOA(b_form, "DT_FORM");
            else { se.P_TG_LUU(b_form, "DT_FORM", b_dt); b_kq = "C"; }
        }
        return b_kq;
    }
    public static DataTable Fdt_TSO_FORM(string b_kieu, string b_nv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_kieu, b_nv }, "PeD_KH_TSO_NV");
    }
    #endregion

    #region File
    public static string Fs_TM(string b_dk = "N")
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_tm = (b_dk == "N") ? "~/file_nhap" : "~/Outputs";
        b_tm = HttpContext.Current.Server.MapPath(b_tm);
        if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
        b_tm += "/" + b_se.ma_dvi + "_" + b_se.nsd;
        if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
        return b_tm + "/";
    }
    public static void P_FI_DON(string b_dk = "N")
    {
        string b_tm = Fs_TM(b_dk);
        string[] a_f = Directory.GetFiles(b_tm, "*.*");
        foreach (string b_s in a_f) File.Delete(b_s);
    }
    public static string Fs_FILEs()
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_tm = HttpContext.Current.Server.MapPath("~/file_nhap/" + b_se.ma_dvi + "_" + b_se.nsd);
        if (!Directory.Exists(b_tm)) return " ";
        b_tm += "/";
        string[] a_f = Directory.GetFiles(b_tm, "*.*");
        if (a_f.Length == 0) return " ";
        int b_i = 0; string b_mr = ".txt,.pdf,.xls,.doc";
        for (int i = 0; i < a_f.Length; i++)
        {
            b_tm = Path.GetExtension(a_f[i]);
            if (b_mr.IndexOf(b_tm) >= 0) b_i++;
        }
        b_tm = a_f.Length.ToString();
        if (b_i > 0) b_tm = b_i.ToString() + "/" + b_tm;
        return b_tm;
    }
    public static DataTable Fdt_FI_LKE(string b_dk, double b_so_id, int b_bt, int b_namP, string b_nv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dk, b_so_id, b_bt, b_namP, b_nv }, "PeD_FI_LKE");
    }
    ///<summary>Bảng liệt kê</summary>
    public static DataTable Fdt_FI_CT(string b_dvi, double b_so_id, double b_bt, double b_namP)
    {
        return dbora.Fdt_LKE_S(new object[] { b_dvi, b_so_id, b_bt, b_namP }, "PeD_FI_CT");
    }
    public static void P_FI_NH(double b_so_id, string b_ten, string b_goc, string b_kieuF, double b_cse, string b_mhoa)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_ten, b_goc, b_kieuF, b_cse, b_mhoa }, "PeD_FI_NH");
    }
    public static void P_FI_XOA(double b_so_id, double b_bt)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_bt }, "PeD_FI_XOA");
    }
    public static void P_FI_SUA(double b_so_id, double b_bt, string b_nd, int b_cse, string b_mhoa)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_bt, b_nd, b_cse, b_mhoa }, "PeD_FI_SUA");
    }
    public static void P_FI_XOA(string b_t, string b_f)
    {
        try
        {
            string b_goc = khac.Fs_tmFile();
            if (b_goc != "")
            {
                string b_ten = b_goc + b_t + "/" + b_f;
                if (File.Exists(b_ten)) File.Delete(b_ten);
            }
        }
        catch { }
    }
    public static void P_FI_XOA(double b_so_id)
    {
        string b_goc = khac.Fs_tmFile();
        if (b_goc != "")
        {
            string b_f = b_so_id.ToString();
            string b_t = b_goc + "/" + (new se.se_nsd()).ma_dvi + "/" + b_f.Substring(0, 4) + "/" + b_f.Substring(4, 2) + "/" + b_f.Substring(6, 2);
            if (Directory.Exists(b_t))
            {
                b_f += "*.*";
                string[] a_f = Directory.GetFiles(b_t, b_f);
                foreach (string b_s in a_f) File.Delete(b_s);
            }
        }
    }
    public static string Fs_FI_LUU(double b_so_id)
    {
        try
        {
            string b_tm = Fs_TM(), b_goc = khac.Fs_tmFile();
            if (b_goc == "") return "loi:Chưa khai báo thư mục lưu File:loi";
            string[] a_f = Directory.GetFiles(b_tm, "*.*");
            if (a_f.Length == 0) return "";
            string b_nd, b_mr, b_kieuF, b_t = b_so_id.ToString(), b_fL;
            b_t = "/" + (new se.se_nsd()).ma_dvi + "/" + b_t.Substring(0, 4) + "/" + b_t.Substring(4, 2) + "/" + b_t.Substring(6, 2);
            string b_tf = b_goc + b_t + "/" + b_so_id.ToString(), b_mhoa;
            int b_i; double b_cse;
            khac.P_taoTmuc(b_t);
            foreach (string b_fG in a_f)
            {
                b_i = b_fG.LastIndexOf('/') + 1;
                b_nd = b_fG.Substring(b_i);
                b_i = b_nd.LastIndexOf('.');
                if (b_i < 0) b_mr = ""; else { b_mr = b_nd.Substring(b_i); b_nd = b_nd.Substring(0, b_i); }
                b_cse = chuyen.CSO_SO(b_nd.Substring(4, 1)); b_mhoa = b_nd.Substring(5, 1); b_nd = b_nd.Substring(6);
                b_i = 0; b_fL = b_tf + "_0" + b_mr;
                while (File.Exists(b_fL)) { b_i++; b_fL = b_tf + "_" + kytu.C_NVL(b_i.ToString()) + b_mr; }
                if (b_mhoa == "1") khac.P_FILEcry(b_fG);
                b_kieuF = (".png,.gif,.bmp,.jpg,.jpeg".IndexOf(b_mr) < 0) ? "K" : "C";
                b_nd = "N'" + b_nd;
                File.Copy(b_fG, b_fL, true);
                P_FI_NH(b_so_id, b_nd, b_fL.Substring(b_goc.Length), b_kieuF, b_cse, b_mhoa);
                // tqthang : kiem tra & luu file tren he thong FineNet
                //bool b_fn = ed_vb_fnet.Fb_CHINH();
                //if (b_fn) { ed_vb_fnet.Fs_LUU(b_so_id, b_fL); }
                File.Delete(b_fG);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion
}