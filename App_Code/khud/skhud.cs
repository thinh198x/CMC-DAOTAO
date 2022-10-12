using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Drawing;
using System.Net;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class skhud : WebService
{
    [WebMethod(true)]
    public string Fs_MA_DVI(string b_login)
    {
        try
        {
            se.P_LOGIN(b_login);
            return (new se.se_nsd()).ma_dvi;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    #region QUYEN
    ///<summary> Xử lý quyền </summary>
    [WebMethod(true)]
    public string Fs_KTRA_QU(string b_login, string b_form, string b_file)
    {
        try
        {
            se.P_LOGIN(b_login);
            khac.Fb_KTRA_QU(b_form, b_file, "GXDPIMAE"); 
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MENUB(string b_login, string b_form, string b_loai, string b_ma, string b_vuId)
    {
        try
        {
            se.P_LOGIN(b_login, false);
            //string b_kq = khac.Fs_MENUB(b_form, b_ma);
            string b_kq = ht_dungchung.Fs_HT_MENUB(b_form, b_ma);
            return b_loai + "#" + b_vuId + "#" + b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MENUC(string b_login, string b_form, string b_ma, string b_tmuc)
    {
        try
        {
            se.P_LOGIN(b_login, false);
            return khac.Fs_TAO_MENUC(b_form, b_ma, b_tmuc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MENUP(string b_login, string b_form, string b_ma, double b_x, double b_y, double b_rong, int b_cao, string b_tmuc)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_fcss = Server.MapPath("~/s_font.css");
            if (b_fcss == "") throw new Exception("loi:Không tìm được File s_font.css:loi");
            return khac.Fs_TAO_MENUP(b_form, b_ma, b_x, b_y, b_rong, b_cao, b_tmuc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MENUP2(string b_login, string b_form, string b_ma, string b_f, double b_x, double b_y, double b_rong, int b_cao, string b_tmuc)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_fcss = Server.MapPath("~/s_font.css");
            if (b_fcss == "") throw new Exception("loi:Không tìm được File s_font.css:loi");
            return b_f + "#" + khac.Fs_TAO_MENUP(b_form, b_ma, b_x, b_y, b_rong, b_cao, b_tmuc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MENUkdo(string b_login, string b_md, string[] a_id, string[] a_kdo)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = "", b_s;
            for (int i = 0; i < a_id.Length; i++)
            {
                b_s = khud.Fs_MENUkdo(b_md, a_kdo[i]);
                kytu.P_CONG(ref b_kq, a_id[i] + '|' + b_s, "#");
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region NSD RIENG
    [WebMethod(true)]
    public string Fs_NSD_TSO_NH(string b_login, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = bang.Fdt_TAO_THEM(a_dt), b_dt_m = bang.Fdt_TAO_BANG("ma,tso", "SS");
            string b_mobi = kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[0]["mobi"]));
            for (int i = 0; i < b_dt.Columns.Count; i++)
            {
                bang.P_THEM_HANG(ref b_dt_m, new object[] { b_dt.Columns[i].ColumnName, b_dt.Rows[0][i] });
            }
            khud.P_NSD_TSO_NH(b_dt_m);
            se.se_nsd b_se = new se.se_nsd();
            string b_nuoc_m = chuyen.OBJ_S(b_dt.Rows[0]["nuoc"]);
            if (b_se.nuoc != b_nuoc_m) khac.P_QU_DICH(b_nuoc_m, b_se.nuoc);
            b_se.nuoc = b_nuoc_m;
            b_se.modal = chuyen.OBJ_S(b_dt.Rows[0]["modal"]);
            b_se.mobi = b_mobi; b_se.phut = chuyen.OBJ_S(b_dt.Rows[0]["phut"]);
            b_se.list_dai = chuyen.OBJ_S(b_dt.Rows[0]["list_dai"]);
            b_se.list_kt = chuyen.OBJ_S(b_dt.Rows[0]["list_kt"]);
            b_login = se.Fs_LOGIN();
            HttpContext.Current.Application[se.Fs_LOGIN_NSD(b_login)] = b_se;
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NSD_TSO_SMS(string b_mobi, object[] a_dt)
    {
        try
        {
            string b_s = khac.Fs_GUIS(b_mobi, "Password", "xac thuc qua Mobil " + b_mobi, "");
            if (b_s != "" && b_s != "loi:Spam SMS:loi") return form.Fs_LOC_LOI(b_s);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NSD_DU_LKE(string b_login, string b_nv)
    {
        try
        {
            se.P_LOGIN(b_login, false);
            DataTable b_dt = khud.Fdt_NSD_DU_LKE(b_nv);
            return khac.Fs_TAO_DU(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NSD_DU_NH(string b_login, string b_form, string b_nv, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "QUYEN");
            if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:Mất kết nối. Đăng nhập lại:loi");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            if (b_hang < 0) throw new Exception("loi:Nghiệp vụ đã xóa:loi");
            string b_ten = "N'" + kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[b_hang]["ten"])), b_dan = "", b_ma_ct = " ";
            while (b_ma_ct != "" && b_ma_ct != "0")
            {
                b_ma_ct = kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[b_hang]["ma_ct"]));
                b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma_ct);
                if (b_ma_ct == "" || b_ma_ct == "0" || b_hang < 0) break;
                b_dan = kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[b_hang]["ten"])) + " > " + b_dan;
            }
            if (kytu.C_NVL(b_dan) != "") b_dan = "N'" + b_dan;
            khud.P_NSD_DU_NH(b_nv, b_ma, b_ten, b_dan);
            return Fs_NSD_DU_LKE(b_login, b_nv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NSD_DU_XOA(string b_login, string b_nv, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            khud.P_NSD_DU_XOA(b_nv, b_ma);
            return Fs_NSD_DU_LKE(b_login, b_nv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region TTT
    private DataTable Fdt_TTT_SAN(string b_ps, string b_nv)
    {
        try
        {
            string b_file = Server.MapPath("~/App_form/khud/file") + "\\ttt_" + b_ps + "_" + b_nv + ".xls";
            DataTable b_dt = khac.Fdt_Excel(b_file); bang.P_DON(ref b_dt);
            return b_dt;
        }
        catch { return null; }
    }
    [WebMethod(true)]
    public string Fs_TTT_SAN(string b_login, string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = Fdt_TTT_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt))
            {
                DataTable b_dt_s = null;
                if (a_dt[1] != null) { b_dt_s = bang.Fdt_TAO_THEM(a_dt); bang.P_DON(ref b_dt_s); }
                if (!bang.Fb_TRANG(b_dt_s)) bang.P_BO_HANG(ref b_dt, "ma", b_dt_s, "ma");
            }
            return bang.Fs_BANG_CH(b_dt, "ma,ten,loai");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_TAO(string b_login, string b_ps, string b_nv, string b_kdvi = "")
    {
        try
        {
            se.P_LOGIN(b_login);
            return khud.Fs_TTT_TAO(b_ps, b_nv, b_kdvi);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_LKE(string b_login, string b_ps, string b_nv, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = Fdt_TTT_SAN(b_ps, b_nv);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "K" : "C";
            b_dt = khud.Fdt_TTT_LKE(b_ps, b_nv);
            return b_kq + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_NH(string b_login, string b_ps, string b_nv, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = null;
            if (a_dt[1] != null) { b_dt = bang.Fdt_TAO_THEM(a_dt); bang.P_DON(ref b_dt); }
            if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:Nhập chi tiết:loi");
            bang.P_CH_KHONG(ref b_dt);
            bang.P_THEM_COL(ref b_dt, new string[] { "ktra", "f_tkhao", "f_sht_tkhao", "lke", "tra" }, "SSSSS");
            DataTable b_dt_s = Fdt_TTT_SAN(b_ps, b_nv);
            if (!bang.Fb_TRANG(b_dt_s))
            {
                string b_ma; int b_hang;
                foreach (DataRow b_dr in b_dt_s.Rows)
                {
                    b_ma = chuyen.OBJ_S(b_dr["ma"]);
                    b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
                    if (b_hang >= 0) bang.P_DAT_GTRI(ref b_dt, new string[] { "loai", "ktra", "f_tkhao", "f_sht_tkhao", "lke", "tra" },
                        new object[] { chuyen.OBJ_S(b_dr["loai"]), chuyen.OBJ_S(b_dr["ktra"]),
                        chuyen.OBJ_S(b_dr["f_tkhao"]), chuyen.OBJ_S(b_dr["f_sht_tkhao"]),chuyen.OBJ_S(b_dr["lke"]),chuyen.OBJ_S(b_dr["tra"]) }, b_hang);
                }
            }
            khud.P_TTT_NH(b_ps, b_nv, b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TTT_XOA(string b_login, string b_ps, string b_nv)
    {
        try { se.P_LOGIN(b_login); khud.P_TTT_XOA(b_ps, b_nv); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }

    [WebMethod(true)]
    public string Fs_TTT_NV(string b_login, string b_ps, string b_nv)
    {
        try
        {
            se.P_LOGIN(b_login);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region TRDOI
    [WebMethod(true)]
    public string Fs_MO_TRDOI_VIEC(string b_nsd, string b_nv, string b_viec)
    {
        try
        {
            string[] a_nsd = b_nsd.Split('#');
            se.P_LOGIN(a_nsd[0], a_nsd[1], a_nsd[2]);
            string b_s = b_viec.Substring(6), b_ma_dvi = "";
            b_viec = "20" + b_viec.Substring(0, 6) + b_s.PadLeft(6, '0');
            b_ma_dvi = khud.Fs_TRDOI_VIEC(a_nsd[0], b_nv.ToUpper(), chuyen.CSO_SO(b_viec));
            return b_ma_dvi + "#" + b_viec;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MO_TRDOI_CUOI(string b_nsd, string b_viec)
    {
        try
        {
            string[] a_nsd = b_nsd.Split('#'), a_viec = b_viec.Split('#');
            se.P_LOGIN(a_nsd[0], a_nsd[1], a_nsd[2]);
            DataTable b_dt = khud.Fdt_TRDOI_LKE(a_viec[0], chuyen.CSO_SO(a_viec[1]), 0);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "0" : chuyen.OBJ_S(b_dt.Rows[b_dt.Rows.Count - 1]["bt"]);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MO_TRDOI_LKE(string b_nsd, string b_viec, double b_cuoi)
    {
        try
        {
            string[] a_nsd = b_nsd.Split('#'), a_viec = b_viec.Split('#');
            se.P_LOGIN(a_nsd[0], a_nsd[1], a_nsd[2]);
            DataTable b_dt = khud.Fdt_TRDOI_LKE(a_viec[0], chuyen.CSO_SO(a_viec[1]), b_cuoi);
            string b_kq = (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(b_dt.Rows[b_dt.Rows.Count - 1]["bt"]) + "#" + bang.Fs_BANG_CH(b_dt, "nd");
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MO_TRDOI_NH(string b_nsd, string b_viec, string b_nd)
    {
        try
        {
            string[] a_nsd = b_nsd.Split('#'), a_viec = b_viec.Split('#');
            se.P_LOGIN(a_nsd[0], a_nsd[1], a_nsd[2]);
            khud.P_TRDOI_NH(a_viec[0], chuyen.CSO_SO(a_viec[1]), "N'" + b_nd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MO_TRDOI_FI(string b_nsd, string b_viec, string b_fi, string b_tdo, string b_nd)
    {
        try
        {
            string[] a_nsd = b_nsd.Split('#'), a_viec = b_viec.Split('#');
            se.P_LOGIN(a_nsd[0], a_nsd[1], a_nsd[2]);
            string b_goc = khac.Fs_tmFile();
            if (b_goc == "") throw new Exception("loi:Chưa khai báo thư mục lưu File:loi");
            string b_f = a_viec[1];
            string b_t = "/" + b_f.Substring(0, 4) + "/" + b_f.Substring(4, 2) + "/" + b_f.Substring(6, 2);
            string b_tf = b_goc + b_t + "/" + b_f, b_mr = ".png", b_ftim;
            int b_i = 0;
            khac.P_taoTmuc(b_t); b_ftim = b_tf + "_0" + b_mr;
            while (File.Exists(b_ftim)) { b_i++; b_ftim = b_tf + "_" + kytu.C_NVL(b_i.ToString()) + b_mr; }
            b_tf = b_ftim;
            System.Drawing.Image b_image = khac.Fim_strIm(b_fi);
            b_image.Save(b_tf);
            string[] a_s = b_tdo.Split('#');
            double b_x = chuyen.CSO_SO(a_s[0]), b_y = chuyen.CSO_SO(a_s[1]);
            khud.P_FI_NH_TDO(a_viec[0], chuyen.CSO_SO(a_viec[1]), b_nd, b_tf.Substring(b_goc.Length), "", b_x, b_y, 0);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TRDOI_LKE(string b_login, string b_ma_dvi, double b_so_id, double b_cuoi)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = khud.Fdt_TRDOI_LKE(b_ma_dvi, b_so_id, b_cuoi);
            string b_kq = "", b_c = "", b_nsd = (new se.se_nsd()).nsd, b_nsd_n;
            if (!bang.Fb_TRANG(b_dt))
            {
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    b_nsd_n = kytu.C_NVL(chuyen.OBJ_S(b_dr["gchu"]));
                    b_nsd_n = (b_nsd_n != "") ? "GD" : kytu.C_NVL(chuyen.OBJ_S(b_dr["nsd"]));
                    b_kq += b_c + " " + "<i class=\"css_Mnd\">" + b_nsd_n + " (" + chuyen.OBJ_S(b_dr["ngay"]) + ") " + "</i>" + chuyen.OBJ_S(b_dr["nd"]);
                    b_c = "<br>";
                }
                b_kq = chuyen.OBJ_S(b_dt.Rows[b_dt.Rows.Count - 1]["bt"]) + "#" + b_kq;
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_TRDOI_NH(string b_login, string b_ma_dvi, double b_so_id, string b_nd)
    {
        try
        {
            se.P_LOGIN(b_login);
            khud.P_TRDOI_NH(b_ma_dvi, b_so_id, "N'" + b_nd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_GOP_NH(string b_login, string b_goc, string b_nd)
    {
        try { se.P_LOGIN(b_login); khud.P_GOP_NH(b_goc, "N'" + b_nd); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region FILE
    private string Fs_FI_TEN(string b_fG)
    {
        int b_i = b_fG.LastIndexOf('/') + 1;
        string b_nd = b_fG.Substring(b_i);
        b_i = b_nd.LastIndexOf('.');
        if (b_i >= 0) b_nd = b_nd.Substring(0, b_i);
        return b_nd;
    }
    private string Fs_FI_TMF(string b_ten, int b_vtri)
    {
        try
        {
            string b_tm = khud.Fs_TM();
            string[] a_f = Directory.GetFiles(b_tm, "*.*");
            if (a_f.Length <= b_vtri) return "";
            string b_nd = Fs_FI_TEN(a_f[b_vtri]);
            return (b_nd != b_ten) ? "" : a_f[b_vtri];
        }
        catch (Exception ex) { return ""; }
    }
    [WebMethod(true)]
    public string Fs_FI_CHU(string b_login, double b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = "", b_tm; int b_kt = 0, b_h = 0, b_r = 201;
            if (b_so_id == 0)
            {
                b_tm = khud.Fs_TM();
                if (b_tm == "") return "";
                string[] a_f = Directory.GetFiles(b_tm, "*.*");
                b_kt = a_f.Length;
                if (b_kt == 0) return "";
                for (int i = 0; i < b_kt; i++)
                {
                    b_tm = Fs_FI_TEN(a_f[i]); b_tm.Replace(",", "");
                    if (b_h > 0 && b_tm.Length > b_r) break;
                    else
                    {
                        b_h++; kytu.P_THEM(ref b_kq, b_tm); b_r -= b_tm.Length;
                    }
                }
            }
            else
            {
                DataTable b_dt = khud.Fdt_FI_LKE("", b_so_id, 0);
                if (bang.Fb_TRANG(b_dt)) return "";
                b_kt = b_dt.Rows.Count;
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    b_tm = chuyen.OBJ_S(b_dr["ten"]); b_tm.Replace(",", "");
                    if (b_h > 0 && b_tm.Length > b_r) break;
                    else { b_h++; kytu.P_THEM(ref b_kq, b_tm); b_r -= b_tm.Length; }
                }
            }
            b_kq += "#(" + b_h.ToString() + "/" + b_kt.ToString() + ")";
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_XEM(string b_login, double b_so_id, string b_nd, int b_vtri)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_so_id != 0)
            {
                b_vtri++;
                DataTable b_dt = khud.Fdt_FI_CT("", b_so_id, b_vtri);
                if (bang.Fb_TRANG(b_dt)) return "";
                if (chuyen.OBJ_S(b_dt.Rows[0]["ten"]) != b_nd) return "";
                b_nd = chuyen.OBJ_S(b_dt.Rows[0]["goc"]);
                b_vtri = (chuyen.OBJ_N(b_dt.Rows[0]["y"]) == 1) ? -1 : -2;
            }
            return Fs_FI_TRA(b_login, b_nd, b_vtri);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_TRA(string b_login, string b_goc, int b_vtri)
    {
        try
        {
            se.P_LOGIN(b_login);
            int b_i;
            if (b_vtri < 0)
            {
                string b_tm = khud.Fs_TM();
                khud.P_FI_DON();
                b_goc = khac.Fs_tmFile() + "\\" + b_goc;
                b_i = b_goc.LastIndexOf('.');
                string b_mr = (b_i > 0) ? b_goc.Substring(b_i).ToLower() : "";
                string b_ten = DateTime.Now.ToString("ddhhmmss") + b_mr;
                File.Copy(b_goc, b_tm + b_ten, true);
                b_goc = "../../file_nhap/" + b_ten;
            }
            else
            {
                b_goc = Fs_FI_TMF(b_goc, b_vtri);
                if (b_goc != "")
                {
                    b_i = b_goc.IndexOf("file_nhap/");
                    b_goc = "../../" + b_goc.Substring(b_i);
                }
            }
            return b_goc;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_TRAs(string b_login, string b_goc)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_tm = khud.Fs_TM();
            int b_i = b_goc.LastIndexOf('/');
            string b_g = khac.Fs_tmFile() + "\\" + b_goc.Substring(0, b_i + 1) + "S" + b_goc.Substring(b_i + 1), b_kq = "K";
            if (File.Exists(b_g)) { b_kq = "C"; b_goc = b_g; }
            else b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            b_i = b_goc.LastIndexOf('.');
            string b_mr = (b_i > 0) ? b_goc.Substring(b_i).ToLower() : "";
            string b_ten = DateTime.Now.ToString("ddhhmmss") + b_mr;
            khud.P_FI_DON(); File.Copy(b_goc, b_tm + b_ten, true);
            b_kq = b_kq + "#../../file_nhap/" + b_ten;
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_TRAf(string b_login, string b_tm, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            b_tm += "\\";
            string b_tmL = @b_tm, b_tmG = khac.Fs_tmFile() + "\\", b_tmO = khud.Fs_TM();
            DataTable b_dt = bang.Fdt_TAO_THEM(a_dt);
            bang.P_DON(ref b_dt, "chon,goc");
            if (bang.Fb_TRANG(b_dt)) return "loi:Chọn File:loi";
            string b_ten, b_goc, b_ten_m, b_mr;
            int b_i = b_dt.Rows.Count, b_j = 0;
            string[] a_goc = new string[b_i], a_ten = new string[b_i];
            foreach (DataRow b_dr in b_dt.Rows)
            {
                b_goc = chuyen.OBJ_S(b_dr["goc"]); b_ten = chuyen.OBJ_S(b_dr["ten"]);
                b_i = b_ten.LastIndexOf("(");
                if (b_i > 0) b_ten = b_ten.Substring(0, b_i);
                b_ten_m = "";
                while (b_ten != b_ten_m)
                {
                    b_ten_m = b_ten;
                    b_ten = b_ten_m.Replace("/", "").Replace("#", "").Replace(" ", "_");
                }
                b_i = b_goc.LastIndexOf(".");
                b_mr = (b_i > 0) ? b_goc.Substring(b_i).ToLower() : "";
                b_ten = DateTime.Now.ToString("ddhhmmss") + b_mr;
                a_goc[b_j] = b_goc; a_ten[b_j] = b_ten; b_j++;
            }
            if (!Directory.Exists(b_tmO)) Directory.CreateDirectory(b_tmO);
            Uri b_uri; WebClient client = new WebClient();
            for (int i = 0; i < a_goc.Length; i++)
            {
                b_goc = b_tmG + a_goc[i]; b_ten = b_tmO + a_ten[i]; b_ten_m = b_tmL + a_ten[i];
                File.Copy(b_goc, b_ten, true);
                b_uri = new Uri(b_ten);
                client.DownloadFile(b_uri, b_ten_m);
            }
            khud.P_FI_DON();
            return "loi:Đã xong:loi";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_LKE(string b_login, string b_ma_dvi, double b_so_id, double b_cuoi, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = khud.Fdt_FI_LKE(b_ma_dvi, b_so_id, b_cuoi);
            bang.P_THEM_COL(ref b_dt, "mdo", "I"); bang.P_THEM_COL(ref b_dt, "chon", "");
            if (!bang.Fb_TRANG(b_dt))
            {
                string b_s; int b_i;
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    b_s = chuyen.OBJ_S(b_dr["ten"]);
                    b_i = b_s.IndexOf("#");
                    if (b_i > 0 && b_s.Length > b_i + 1)
                    {
                        b_dr["mdo"] = b_s.Substring(b_i + 1, 1);
                        b_s = b_s.Substring(0, b_i);
                    }
                    b_dr["ten"] = b_s + " (" + chuyen.OBJ_S(b_dr["ngayS"]) + ")";
                }
                bang.P_NG_CNG(ref b_dt, "ngay_nh");
                DataTable b_dtC = bang.Fdt_TAO_THEM(a_dt);
                bang.P_DON(ref b_dtC, "chon");
                if (!bang.Fb_TRANG(b_dt)) bang.P_THAY_GTRI(ref b_dt, b_dtC, "goc", "chon");
            }
            string[] a_cot = "ten,chon,goc,tdo,mdo,ngay_nh,vtri".Split(',');
            return (bang.Fb_TRANG(b_dt)) ? "" : chuyen.OBJ_S(b_dt.Rows[b_dt.Rows.Count - 1]["bt"]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_LKE0(string b_login)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_s = "ten,chon,GOC,tdo,mdo,ngay_nh,vtri,anh";
            DataTable b_dt = bang.Fdt_TAO_BANG(b_s, "SSSSSSSS");
            string b_tm = khud.Fs_TM();
            if (b_tm == "") return "";
            string[] a_f = Directory.GetFiles(b_tm, "*.*");
            if (a_f.Length == 0) return "";
            int b_i;
            for (int i = 0; i < a_f.Length; i++)
            {
                bang.P_THEM_TRANG(ref b_dt, 1);
                b_i = a_f[i].LastIndexOf('.');
                b_dt.Rows[i]["goc"] = (b_i > 0) ? a_f[i].Substring(b_i) : "";
                b_dt.Rows[i]["ten"] = Fs_FI_TEN(a_f[i]);
                b_dt.Rows[i]["vtri"] = i.ToString();
            }
            b_dt.AcceptChanges();
            return bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_XOA0(string b_login, string b_ten, int b_vtri)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_f = Fs_FI_TMF(b_ten, b_vtri);
            if (b_f != "" && File.Exists(b_f)) File.Delete(b_f);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_XOA(string b_login, string b_ma_dvi, double b_so_id, string b_goc)
    {
        try
        {
            se.P_LOGIN(b_login);
            khud.P_FI_XOA(b_ma_dvi, b_so_id, b_goc);
            b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            if (File.Exists(b_goc)) File.Delete(b_goc);
            int b_i = b_goc.LastIndexOf('/');
            b_goc = khac.Fs_tmFile() + "\\" + b_goc.Substring(0, b_i + 1) + "S" + b_goc.Substring(b_i + 1);
            if (File.Exists(b_goc)) File.Delete(b_goc);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_SUA0(string b_login, string b_ten, int b_vtri, string b_tenM)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_f = Fs_FI_TMF(b_ten, b_vtri);
            if (b_f != "" && File.Exists(b_f))
            {
                int b_i1 = b_f.LastIndexOf('/'), b_i2 = b_f.LastIndexOf('.');
                if (b_i1 > 0) b_tenM = b_f.Substring(0, b_i1 + 1) + b_tenM;
                if (b_i2 > 0) b_tenM += b_f.Substring(b_i2);
                File.Move(b_f, b_tenM);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_SUA(string b_login, string b_ma_dvi, double b_so_id, string b_goc, string b_nd)
    {
        try
        {
            se.P_LOGIN(b_login);
            khud.P_FI_SUA(b_ma_dvi, b_so_id, b_goc, "N'" + b_nd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_VTRI(string b_login, string b_ma_dvi, double b_so_id, string b_goc, string b_vtri)
    {
        try
        {
            se.P_LOGIN(b_login);
            khud.P_FI_VTRI(b_ma_dvi, b_so_id, b_goc, b_vtri);
            int b_i = b_goc.LastIndexOf('/');
            string b_g = khac.Fs_tmFile() + "\\" + b_goc.Substring(0, b_i + 1) + "S" + b_goc.Substring(b_i + 1);
            if (File.Exists(b_g)) File.Delete(b_g);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_CH(string b_login, string b_form, string b_ma_dvi, double b_so_id, string b_chuoi, string b_dk)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_goc = khac.Fs_tmFile();
            if (b_goc == "") return "loi:Chưa khai báo thư mục lưu File:loi";
            string b_fi = kytu.C_NVL(chuyen.OBJ_S(se.Fobj_BIEN_TRA(b_form, "FILES"))) + b_chuoi;
            if (b_dk.Length > 1)
            {
                string[] a_s = b_dk.Split('|');
                string b_nd = "N'" + a_s[0], b_mr = a_s[1], b_kieuF = a_s[2], b_tdo = a_s[3], b_t = b_so_id.ToString(), b_ftim = "";
                b_t = "/" + b_t.Substring(0, 4) + "/" + b_t.Substring(4, 2) + "/" + b_t.Substring(6, 2);
                string b_tf = b_goc + b_t + "/" + b_so_id.ToString();
                int b_i = 0;
                khac.P_taoTmuc(b_t);
                if (a_s[4] == "K")
                {
                    b_ftim = b_tf + "_0." + b_mr;
                    while (File.Exists(b_ftim)) { b_i++; b_ftim = b_tf + "_" + kytu.C_NVL(b_i.ToString()) + "." + b_mr; }
                    if (b_tdo.IndexOf("#") < 0)
                        khud.P_FI_NH(b_ma_dvi, b_so_id, b_nd, b_ftim.Substring(b_goc.Length), b_kieuF);
                    else
                    {
                        a_s = b_tdo.Split('#');
                        khud.P_FI_NH_TDO(b_ma_dvi, b_so_id, b_nd, b_ftim.Substring(b_goc.Length), b_kieuF, chuyen.CSO_SO(a_s[0]), chuyen.CSO_SO(a_s[1]), 0);
                    }
                }
                else
                {
                    b_i = a_s[0].LastIndexOf('/');
                    b_ftim = b_goc + "\\" + a_s[0].Substring(0, b_i + 1) + "S" + a_s[0].Substring(b_i + 1);
                }
                khac.P_FileB(b_ftim, b_fi);
                se.P_BIEN_XOA(b_form, "FILES");
            }
            else if (b_fi != "") se.P_BIEN_LUU(b_form, "FILES", b_fi);
            else se.P_BIEN_XOA(b_form, "FILES");
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_CH0(string b_login, string b_form, string b_chuoi, string b_dk)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_fi = kytu.C_NVL(chuyen.OBJ_S(se.Fobj_BIEN_TRA(b_form, "FILES"))) + b_chuoi;
            if (b_dk.Length > 1)
            {
                string b_tm = khud.Fs_TM();
                string[] a_s = b_dk.Split('|'), a_c;
                a_c = a_s[3].Split(',');
                string b_ten = b_tm + "\\" + a_s[0] + a_c[1] + "." + a_s[1];
                khac.P_FileB(b_ten, b_fi); se.P_BIEN_XOA(b_form, "FILES");
            }
            else if (b_fi != "") se.P_BIEN_LUU(b_form, "FILES", b_fi);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_DOC(string b_login, string b_fi, string b_loai)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_tm = khud.Fs_TM();
            string b_ten = b_tm + "\\" + DateTime.Now.ToString("ddhhmmss") + "." + b_loai;
            if (File.Exists(b_ten)) File.Delete(b_ten);
            khac.P_FileB(b_ten, b_fi, "M");
            DataTable b_dt = null;
            if (b_loai != "csv") b_dt = khac.Fdt_Excel(b_ten);
            else
            {
                string b_cot = khac.Fs_FileR(b_ten, 1);
                if (b_cot == null) throw new Exception("loi:Lỗi đọc File:loi");
                char b_cach = '|';
                if (b_cot.IndexOf(b_cach) < 0) b_cach = ',';
                string[] a_cot = b_cot.Split(b_cach);
                string b_s = "".PadLeft(a_cot.Length, 'S');
                b_dt = bang.Fdt_TAO_BANG(b_cot, b_s);
                b_s = khac.Fs_FileR(b_ten, ref b_dt, 2, b_cach);
                if (b_s == null) throw new Exception("loi:Lỗi đọc File:loi");
            }
            try { File.Delete(b_ten); }
            catch { }
            if (!bang.Fb_TRANG(b_dt)) se.P_KQ_LUU("file", "file", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_DON()
    {
        try { khud.P_FI_DON(); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region NVU RIENG
    [WebMethod(true)]
    public string Fs_NV_TSO_NH(string b_login, string b_md, string b_nv, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = bang.Fdt_TAO_THEM(a_dt), b_dt_m = bang.Fdt_TAO_BANG("ma,tso", "SS");
            for (int i = 0; i < b_dt.Columns.Count; i++)
                bang.P_THEM_HANG(ref b_dt_m, new object[] { b_dt.Columns[i].ColumnName, b_dt.Rows[0][i] });
            khud.P_NV_TSO_NH(b_md, b_nv, b_dt_m);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NV_DU_LKE(string b_login, string b_md, string b_nv)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = khud.Fdt_NV_TSO_LKE(b_md, b_nv);
            return khac.Fs_TAO_DU(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region CAY
    [WebMethod(true)]
    public string Fs_CAY(string b_login, string b_id, string b_cap, string b_ma, string b_ham)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = khud.Fdt_CAY(b_ma, b_ham);
            double b_i = chuyen.CSO_SO(b_cap) + 1;
            return b_id + "#" + b_i.ToString() + "#" + bang.Fs_BANG_CH(b_dt, "ma,ten,loai");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion
}