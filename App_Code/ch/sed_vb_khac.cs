using System;
using System.Data;
using System.Web.Services;
using System.IO;
using System.IO.Compression;
using Cthuvien;


[System.Web.Script.Services.ScriptService]
public class sed_vb_khac : WebService
{
    #region KHAC
    [WebMethod(true)]
    public string Fs_CCTC(string b_login, string b_id, string b_loai, string b_cap, string b_dvi, string b_ma, string b_vtro)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ed_vb_khac.Fdt_CCTC(b_loai, b_dvi, b_ma, b_vtro);
            double b_i = chuyen.CSO_SO(b_cap) + 1;
            return b_id + "#" + b_i.ToString() + "#" + bang.Fs_BANG_CH(b_dt, "ma,ten,tc,loai,dvi,ma_nh");
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_KIEU(string b_login, double b_so_id, double b_namP)
    {
        try
        {
            se.P_LOGIN(b_login);
            return ed_vb_khac.Fs_KIEU(b_so_id, b_namP);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_TAO(string b_login, string b_form, double b_so_id, double b_namP,
        string b_kieu, object[] a_gtri, string[] a_cot, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_vtro, a_bcao, a_ma, a_s;
            DataTable b_dt = bang.Fdt_TAO_BANG("bt,vtroT,nhomT,ten,ttr,bcao,chon,VTRO,ma_nh,nhom,ma_dt", "SSSSSSSSSSS");
            string b_vtroT, b_nhomT, b_ten = "", b_bcao, b_vtro, b_ma_nh = "", b_nhom = "", b_ma_dt = "";
            int b_bt = 0, b_h;
            for (int i = 0; i < a_gtri.Length; i++)
            {
                a_vtro = chuyen.Fas_OBJ_STR((object[])a_gtri[i]);
                a_ma = a_vtro[1].Split(','); a_bcao = a_vtro[2].Split(',');
                b_vtro = a_vtro[0]; b_vtroT = ed_vb_khac.Fs_TEN_VTRO(b_vtro, b_kieu);
                for (int j = 0; j < a_ma.Length; j++)
                {
                    b_nhomT = ""; b_ten = "";
                    if (a_ma[j].IndexOf(":") < 0)
                    {
                        b_ma_nh = kytu.C_NVL(a_ma[j]);
                        if (b_ma_nh != "") ed_vb_khac.P_TEN_MA_NH(b_ma_nh, out b_nhom, out b_ma_dt, out b_ten);
                        else b_nhom = ""; b_ma_dt = "";
                    }
                    else
                    {
                        a_s = a_ma[j].Split(':');
                        b_ma_nh = ""; b_nhom = kytu.C_NVL(a_s[0]); b_ma_dt = kytu.C_NVL(a_s[1]);
                        if (b_nhom != "" && b_ma_dt != "") b_ten = ed_vb_khac.Fs_TEN_MA_VTRO(b_nhom, b_ma_dt);
                    }
                    if (b_ma_nh != "" || (b_nhom != "" && b_ma_dt != ""))
                    {
                        b_nhomT = ed_vb_khac.Fs_TEN_NHOM(b_nhom); b_bcao = "";
                        for (int k = 0; k < a_bcao.Length; k++)
                        {
                            if (a_bcao[k] == a_ma[j]) b_bcao = "K";
                        }
                        b_bt++;
                        bang.P_THEM_HANG(ref b_dt,
                            new object[] { b_bt.ToString(), b_vtroT, b_nhomT, b_ten, "", b_bcao, "", b_vtro, b_ma_nh, b_nhom, b_ma_dt });
                    }
                }
            }
            if (bang.Fb_TRANG(b_dt)) se.P_TG_XOA(b_form, "DT_CHUYENXL");
            else
            {
                if (b_so_id != 0)
                {
                    DataTable b_dtT = ed_vb_khac.Fdt_TTR_VTRO(b_so_id, b_namP);
                    foreach (DataRow b_drT in b_dtT.Rows)
                    {
                        b_ma_nh = kytu.C_NVL(chuyen.OBJ_S(b_drT["ma_nh"]));
                        b_h = (b_ma_nh != "") ? bang.Fi_TIM_ROW(b_dt, "ma_nh", b_ma_nh) : -1;
                        if (b_h < 0)
                        {
                            b_nhom = chuyen.OBJ_S(b_drT["nhom"]); b_ma_dt = chuyen.OBJ_S(b_drT["ma_dt"]);
                            b_h = bang.Fi_TIM_ROW(b_dt, new string[] { "nhom", "ma_dt" }, new object[] { b_nhom, b_ma_dt });
                        }
                        if (b_h >= 0) b_dt.Rows[b_h]["ttr"] = "Đã chuyển";
                    }
                }
                se.P_TG_LUU(b_form, "DT_CHUYENXL", b_dt);
            }
            return khac.Fs_SLIDE_LKE(b_form, "DT_CHUYENXL", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_LKE(string b_form, string[] a_cot, object[] a_tso)
    {
        try { return khac.Fs_SLIDE_LKE(b_form, "DT_CHUYENXL", a_cot, a_tso); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_UP(string b_form, object[] a_tso)
    {
        try
        {
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_CHUYENXL");
            if (!bang.Fb_TRANG(b_dt))
            {
                int b_hang = bang.Fi_TIM_ROW(b_dt, "bt", a_tso[0]);
                if (b_hang >= 0)
                {
                    b_dt.Rows[b_hang]["bcao"] = a_tso[1]; b_dt.Rows[b_hang]["chon"] = a_tso[2];
                    se.P_TG_LUU(b_form, "DT_CHUYENXL", b_dt);
                }
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private string Fs_TEN_NHOM(string b_nhom)
    {
        string[] a_ten = "Cá nhân,Bộ phận,Đơn vị,Cấp trên".Split(','), a_nhom = "C,B,D,T".Split(',');
        int b_vtri = khac.Fi_VTRI_MANG(a_nhom, b_nhom);
        return (b_vtri < 0) ? "" : a_ten[b_vtri];
    }
    private void P_TTU(ref DataTable b_dt)
    {
        int b_hang = 0;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_hang++; b_dr["bt"] = b_hang;
        }
    }
    [WebMethod(true)]
    public string Fs_VTRO_THEM(string b_form, string b_kieu, string b_vtro, string[][] a_dt, string[] a_cot, object[] a_tso)
    {
        try
        {
            string b_vtroT, b_nhomT, b_nhom, b_ma_dt;
            int b_hang;
            string[] a_ten;
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_CHUYENXL");
            if (b_dt == null)
            {
                a_ten = "bt,vtroT,nhomT,ten,ttr,bcao,chon,VTRO,ma_nh,nhom,ma_dt".Split(',');
                b_dt = bang.Fdt_TAO_BANG(a_ten, "NSSSSSSSSSS");
            }
            a_ten = "vtroT,nhomT,ten,ttr,VTRO,ma_nh,nhom,ma_dt,chon".Split(',');
            for (int i = 0; i < a_dt.Length; i++)
            {
                b_nhom = (b_vtro == "K") ? "T" : a_dt[i][0];
                b_ma_dt = a_dt[i][2];
                b_hang = (bang.Fb_TRANG(b_dt)) ? -1 : bang.Fi_TIM_ROW(b_dt, new string[] { "nhom", "ma_dt" }, new object[] { b_nhom, b_ma_dt });
                if (b_hang < 0)
                {
                    b_hang = (b_vtro == "C" || ("NB,TT,DI".IndexOf(b_kieu) >= 0 && "YK".IndexOf(b_vtro) >= 0)) ? bang.Fi_TIM_ROW(b_dt, "vtro", b_vtro) : -1;
                    if (b_hang < 0)
                    {
                        b_vtroT = ed_vb_khac.Fs_TEN_VTRO(b_vtro, b_kieu); b_nhomT = Fs_TEN_NHOM(b_nhom);
                        bang.P_THEM_HANG(ref b_dt, a_ten, new object[] { b_vtroT, b_nhomT, a_dt[i][4], "", b_vtro, a_dt[i][3], b_nhom, b_ma_dt, "" });
                    }
                }
            }
            P_TTU(ref b_dt);
            se.P_TG_LUU(b_form, "DT_CHUYENXL", b_dt);
            return khac.Fs_SLIDE_LKE(b_form, "DT_CHUYENXL", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_CAT(string b_form, string b_dk, string[] a_cot, object[] a_tso)
    {
        try
        {
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_CHUYENXL");
            if (!bang.Fb_TRANG(b_dt))
            {
                string b_s = "";
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    if (chuyen.OBJ_S(b_dr["ttr"]) != "") b_s = "";
                    else if (b_dk == "K")
                    {
                        b_s = (chuyen.OBJ_S(b_dr["chon"]) == "") ? "x" : "";
                        b_dr["chon"] = b_s;
                    }
                }
                bang.P_BO_HANG(ref b_dt, "chon", "x");
            }
            if (bang.Fb_TRANG(b_dt)) se.P_TG_XOA(b_form, "DT_CHUYENXL");
            else { P_TTU(ref b_dt); se.P_TG_LUU(b_form, "DT_CHUYENXL", b_dt); }
            return khac.Fs_SLIDE_LKE(b_form, "DT_CHUYENXL", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_LEN(string b_form, int b_bt, int b_dk, string[] a_cot, object[] a_tso)
    {
        try
        {
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_CHUYENXL");
            int b_hang = bang.Fi_TIM_ROW(b_dt, "bt", (object)b_bt);
            int b_hangM = b_hang + b_dk;
            if (b_hangM >= 0 && b_hangM < b_dt.Rows.Count)
            {
                b_dt.Rows[b_hang]["bt"] = b_bt + b_dk;
                b_dt.Rows[b_hangM]["bt"] = b_bt;
                bang.P_XEP(ref b_dt, "bt");
                se.P_TG_LUU(b_form, "DT_CHUYENXL", b_dt);
            }
            b_bt += b_dk;
            return khac.Fs_SLIDE_LKE(b_form, "DT_CHUYENXL", a_cot, a_tso) + "#" + b_bt.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_VTRO_TRA(string b_form, string b_dk, string b_vtro)
    {
        try
        {
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_CHUYENXL");
            if (bang.Fb_TRANG(b_dt)) return b_dk;
            string[] a_cot = ",_ten,_ttr,_bcao".Split(','), a_vtro = b_vtro.Split(',');
            string b_kq = "", b_ma_nh, b_ma_dt, b_tenN, b_tenD, b_bcao, b_s;
            b_vtro = "";
            for (int i = 0; i < a_vtro.Length; i++)
            {
                b_ma_nh = ""; b_ma_dt = ""; b_tenN = ""; b_tenD = ""; b_bcao = "";
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    if (a_vtro[i] == chuyen.OBJ_S(b_dr["vtro"]))
                    {
                        b_s = kytu.C_NVL(chuyen.OBJ_S(b_dr["ma_nh"]));
                        if (b_s != "" || a_vtro[i] == "D")
                        {
                            if (b_s == "") b_s = chuyen.OBJ_S(b_dr["nhom"]) + ':' + chuyen.OBJ_S(b_dr["ma_dt"]);
                            kytu.P_THEM(ref b_ma_nh, b_s);
                            kytu.P_THEM(ref b_tenN, chuyen.OBJ_S(b_dr["ten"]));
                        }
                        else
                        {
                            b_s = chuyen.OBJ_S(b_dr["nhom"]) + ':' + chuyen.OBJ_S(b_dr["ma_dt"]);
                            kytu.P_THEM(ref b_ma_dt, b_s);
                            kytu.P_THEM(ref b_tenD, chuyen.OBJ_S(b_dr["ten"]));
                        }
                        if (chuyen.OBJ_S(b_dr["bcao"]) == "C") kytu.P_THEM(ref b_bcao, b_s);
                    }
                }
                if (b_ma_nh != "" || b_ma_dt != "")
                {
                    kytu.P_CONG(ref b_vtro, a_vtro[i]);
                    if (b_ma_dt != "") { kytu.P_THEM(ref b_ma_nh, b_ma_dt); kytu.P_THEM(ref b_tenN, b_tenD); }
                    b_tenN = ed_vb_khac.Fs_CTEN_VTRO(b_tenN);
                    kytu.P_THEM(ref b_kq, b_ma_nh + ";" + b_tenN + ";" + b_bcao, "|");
                }
            }
            return b_dk + "#" + b_vtro + "#" + b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_CTEN_VTRO(string b_login, string b_vtro, string b_ma)
    {
        try
        {
            se.P_LOGIN(b_login);
            b_ma = b_ma.Replace(";", ",");
            //b_ma = vb_de.Fs_CTEN_VTRO(b_ma);
            return b_vtro + "#" + ed_vb_khac.Fs_CTEN_VTRO(b_ma);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_tsoForm(string b_form, string b_lso, string b_vtro)
    {
        //FORM,TEN,LOAI,LSO
        DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FORM");
        if (bang.Fb_TRANG(b_dt)) return "";
        bang.P_THEM_COL(ref b_dt, "ttr", "C");
        string[] a_s, a_lso, a_vtro; string b_s, b_ttr;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_s = chuyen.OBJ_S(b_dr["LSO"]); b_ttr = "C";
            a_lso = b_s.Split(';');
            for (int i = 0; i < a_lso.Length; i++)
            {
                a_s = a_lso[i].Split(':');
                b_s = kytu.C_NVL(a_s[0]);
                if (b_s == "" || b_s == b_lso)
                {
                    a_vtro = a_s[1].Split(',');
                    for (int j = 0; j < a_vtro.Length; j++)
                    {
                        b_s = kytu.C_NVL(a_vtro[j]);
                        if (b_s == "" || b_s == b_vtro) { b_ttr = "K"; break; }
                    }
                    if (b_ttr == "K") break;
                }
            }
            b_dr["ttr"] = b_ttr;
        }
        return bang.Fs_BANG_CH(b_dt, "TEN,LOAI,ttr");
    }
    #endregion

    #region FILE
    private string Fs_FI_TEN(string b_fG)
    {
        int b_i = b_fG.LastIndexOf('/') + 1;
        string b_nd = b_fG.Substring(b_i);
        b_i = b_nd.LastIndexOf('.');
        if (b_i > 0) b_nd = b_nd.Substring(0, b_i);
        return b_nd;
    }
    private string Fs_FI_TMF(int b_bt)
    {
        try
        {
            string b_tm = ed_vb_khac.Fs_TM(), b_kq = "";
            string[] a_f = Directory.GetFiles(b_tm, "*.*");
            if (a_f.Length > b_bt) { Array.Sort(a_f); b_kq = a_f[b_bt]; }
            return b_kq;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    [WebMethod(true)]
    public string Fs_FI_CHU(string b_login, double b_so_id, int b_namP, string b_nv)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = "", b_tm;
            int b_kt = 0, b_h = 0, b_r = 201, b_i;
            if (b_so_id == 0)
            {
                b_tm = ed_vb_khac.Fs_TM();
                string[] a_f = Directory.GetFiles(b_tm, "*.*");
                b_kt = a_f.Length;
                if (b_kt == 0) return "";
                Array.Sort(a_f);
                for (int i = 0; i < b_kt; i++)
                {
                    b_tm = Fs_FI_TEN(a_f[i]); b_tm.Replace(",", "");
                    b_tm = b_tm.Substring(6);
                    if (b_h > 0 && b_tm.Length > b_r) break;
                    else
                    {
                        b_h++; b_tm += "{" + i.ToString();
                        kytu.P_THEM(ref b_kq, b_tm); b_r -= b_tm.Length;
                    }
                }
            }
            else
            {
                DataTable b_dt = ed_vb_khac.Fdt_FI_LKE("M", b_so_id, 0, b_namP, b_nv);
                if (bang.Fb_TRANG(b_dt)) return "";
                b_kt = b_dt.Rows.Count;
                foreach (DataRow b_dr in b_dt.Rows)
                {
                    b_tm = chuyen.OBJ_S(b_dr["ten"]); b_tm.Replace(",", "");
                    if (b_h > 0 && b_tm.Length > b_r) break;
                    else
                    {
                        b_h++;
                        b_tm += "{" + chuyen.OBJ_S(b_dr["so_id"]) + "|" + chuyen.OBJ_S(b_dr["bt"])
                            + "|" + chuyen.OBJ_S(b_dr["namP"]) + "|" + chuyen.OBJ_S(b_dr["ma_dvi"]);
                        kytu.P_THEM(ref b_kq, b_tm); b_r -= b_tm.Length;
                    }
                }
            }
            b_kq += "#(" + b_h.ToString() + "/" + b_kt.ToString() + ")";
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_LKE(string b_login, string b_form, string b_dk,
        double b_so_id, int b_cuoi, int b_namP, string b_nv, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_cuoi == 0) se.P_TG_XOA(b_form, "DT_FILE");
            if (chuyen.OBJ_I(a_tso[0]) == 1)
            {
                DataTable b_dt = ed_vb_khac.Fdt_FI_LKE(b_dk, b_so_id, b_cuoi, b_namP, b_nv);
                if (!bang.Fb_TRANG(b_dt))
                {
                    string b_s, b_ma_dvi = (new se.se_nsd()).ma_dvi; int b_i;
                    b_cuoi = chuyen.OBJ_I(b_dt.Rows[0]["bt"]);
                    bang.P_THEM_COL(ref b_dt, new string[] { "mr", "tkhao", "chon" }, new string[] { "", "", "" });
                    foreach (DataRow b_dr in b_dt.Rows)
                    {
                        if (chuyen.OBJ_S(b_dr["ma_dvi"]) != b_ma_dvi || chuyen.OBJ_N(b_dr["so_id"]) != b_so_id) b_dr["tkhao"] = "Có";
                        b_s = chuyen.OBJ_S(b_dr["goc"]);
                        b_i = b_s.LastIndexOf('.') + 1;
                        b_s = (b_i > 0) ? b_s.Substring(b_i) : "";
                        b_dr["mr"] = b_s.ToLower();
                        b_dr["ten"] = chuyen.OBJ_S(b_dr["ten"]) + " (" + chuyen.OBJ_S(b_dr["ngayS"]) + ")";
                    }
                    DataTable b_dtC = se.Fdt_TG_TRA(b_form, "DT_FILE");
                    if (!bang.Fb_TRANG(b_dtC)) bang.P_THEM_HANG(ref b_dt, b_dtC);
                    se.P_TG_LUU(b_form, "DT_FILE", b_dt);
                }
            }
            string[] a_cot = "ten,mr,nsdT,tkhao,chon,cse,mhoa,ma_dvi,so_id,bt,namP".Split(',');
            return khac.Fs_SLIDE_LKE(b_form, "DT_FILE", a_cot, a_tso) + "#" + b_cuoi.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private void P_FI_LKE0(string b_form)
    {
        string b_s = "ten,mr,nsdT,tkhao,chon,cse,mhoa,ma_dvi,so_id,bt,namP";
        string[] a_cot = b_s.Split(',');
        DataTable b_dt = bang.Fdt_TAO_BANG(b_s, "SSSSSSSSSSS");
        string b_tm = ed_vb_khac.Fs_TM();
        string[] a_f = Directory.GetFiles(b_tm, "*.*");
        if (a_f.Length == 0) se.P_TG_XOA(b_form, "DT_FILE");
        else
        {
            int b_i;
            Array.Sort(a_f);
            for (int i = 0; i < a_f.Length; i++)
            {
                bang.P_THEM_TRANG(ref b_dt, 1);
                b_i = a_f[i].LastIndexOf('.') + 1;
                b_s = (b_i > 0) ? a_f[i].Substring(b_i) : "";
                b_dt.Rows[i]["mr"] = b_s;
                b_s = Fs_FI_TEN(a_f[i]);
                b_dt.Rows[i]["ten"] = b_s.Substring(6);
                b_dt.Rows[i]["cse"] = b_s.Substring(4, 1);
                b_dt.Rows[i]["mhoa"] = b_s.Substring(5, 1);
                b_dt.Rows[i]["bt"] = i.ToString();
            }
            se.P_TG_LUU(b_form, "DT_FILE", b_dt);
        }
    }
    [WebMethod(true)]
    public string Fs_FI_LKE0(string b_login, string b_form, object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_s = "ten,mr,nsdT,tkhao,chon,cse,mhoa,ma_dvi,so_id,bt,namP";
            string[] a_cot = b_s.Split(',');
            if (chuyen.OBJ_I(a_tso[0]) == 1) P_FI_LKE0(b_form);
            return khac.Fs_SLIDE_LKE(b_form, "DT_FILE", a_cot, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private string Fs_FI_XEM(string[] a_tso)
    {
        try
        {
            double b_so_id = chuyen.CSO_SO(a_tso[0]);
            if (b_so_id == 0) return "";
            DataTable b_dt = ed_vb_khac.Fdt_FI_CT(a_tso[3], b_so_id, chuyen.CSO_SO(a_tso[1]), chuyen.CSO_SO(a_tso[2]));
            if (bang.Fb_TRANG(b_dt)) return "";
            string b_goc = chuyen.OBJ_S(b_dt.Rows[0]["goc"]), b_mhoa = chuyen.OBJ_S(b_dt.Rows[0]["mhoa"]),
                b_ten = chuyen.OBJ_S(b_dt.Rows[0]["ten"]), b_tm = ed_vb_khac.Fs_TM("O");
            ed_vb_khac.P_FI_DON("O");
            b_goc = khac.Fs_tmFile() + "\\" + b_goc;
            int b_i = b_goc.LastIndexOf('.');
            string b_mr = (b_i > 0) ? b_goc.Substring(b_i) : "";
            b_ten = b_tm + b_ten + b_mr;
            File.Copy(b_goc, b_ten, true);
            if (b_mhoa == "1") khac.P_FILEdcr(b_ten);
            if (b_ten != "")
            {
                b_i = b_ten.IndexOf("Outputs");
                if (b_i > 0) b_ten = "/" + b_ten.Substring(b_i);
            }
            return b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    private string Fs_FI_XEM0(string b_btC)
    {
        int b_bt = (int)chuyen.CSO_SO(b_btC);
        string b_goc = Fs_FI_TMF(b_bt);
        if (b_goc != "")
        {
            b_bt = b_goc.IndexOf("file_nhap");
            b_goc = "/" + b_goc.Substring(b_bt);
        }
        return b_goc;
    }
    [WebMethod(true)]
    public string Fs_FI_XEM(string b_login, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = (a_tso.Length == 1) ? Fs_FI_XEM0(a_tso[0]) : Fs_FI_XEM(a_tso);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    /// <summary>
    /// Download nhiều File
    /// </summary>
    [WebMethod(true)]
    private string Fs_FI_LAY(DataTable b_dt)
    {
        int b_i;
        string b_ten, b_goc, b_tenM, b_mr, b_tmG = khac.Fs_tmFile() + "\\",
            b_tmO = ed_vb_khac.Fs_TM(), b_tm = ed_vb_khac.Fs_TM("O");
        ed_vb_khac.P_FI_DON(); ed_vb_khac.P_FI_DON("O");
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_goc = chuyen.OBJ_S(b_dr["goc"]); b_ten = chuyen.OBJ_S(b_dr["ten"]);
            b_i = b_ten.LastIndexOf("(");
            if (b_i > 0) b_ten = b_ten.Substring(0, b_i);
            b_tenM = "";
            while (b_ten != b_tenM)
            {
                b_tenM = b_ten;
                b_ten = b_tenM.Replace("/", "").Replace("#", "").Replace(" ", "_");
            }
            b_i = b_goc.LastIndexOf(".");
            b_mr = (b_i > 0) ? b_goc.Substring(b_i).ToLower() : "";
            b_ten += b_mr;
            b_goc = b_tmG + b_goc; b_ten = b_tmO + b_ten;
            File.Copy(b_goc, b_ten, true);
            if (chuyen.OBJ_S(b_dr["mhoa"]) == "1") khac.P_FILEdcr(b_ten);
        }
        b_ten = b_tm + "file.zip";
        //ZipFile.CreateFromDirectory(@b_tmO, @b_ten);
        ed_vb_khac.P_FI_DON();
        return b_ten;
    }
    [WebMethod(true)]
    public string Fs_FI_LAY(string b_login, string b_form, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_DON(ref b_dt, "chon");
            if (!bang.Fb_TRANG(b_dt)) return Fs_FI_LAY(b_dt);
            double b_so_id = chuyen.CSO_SO(a_tso[0]), b_bt = chuyen.CSO_SO(a_tso[1]), b_namP = chuyen.CSO_SO(a_tso[2]);
            if (b_so_id == 0) return "loi:Chưa chọn File:loi";
            b_dt = ed_vb_khac.Fdt_FI_CT(a_tso[3], b_so_id, b_bt, b_namP);
            if (bang.Fb_TRANG(b_dt)) return "loi:File đã xóa:loi";
            string b_goc = chuyen.OBJ_S(b_dt.Rows[0]["goc"]) + "}" +
                chuyen.OBJ_S(b_dt.Rows[0]["mhoa"]) + "}" + chuyen.OBJ_S(b_dt.Rows[0]["ten"]);
            return b_goc;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    /// <summary>
    /// Download nhiều File
    /// </summary>
    [WebMethod(true)]
    public string Fs_FI_LAYn(string b_login, string b_form)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_DON(ref b_dt, "chon");
            if (bang.Fb_TRANG(b_dt)) return "loi:Chọn File:loi";
            int b_i;
            string b_ten, b_goc, b_tenM, b_mr, b_tmG = khac.Fs_tmFile() + "\\",
                b_tmO = ed_vb_khac.Fs_TM(), b_tm = ed_vb_khac.Fs_TM("O");
            ed_vb_khac.P_FI_DON(); ed_vb_khac.P_FI_DON("O");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                b_goc = chuyen.OBJ_S(b_dr["goc"]); b_ten = chuyen.OBJ_S(b_dr["ten"]);
                b_i = b_ten.LastIndexOf("(");
                if (b_i > 0) b_ten = b_ten.Substring(0, b_i);
                b_tenM = "";
                while (b_ten != b_tenM)
                {
                    b_tenM = b_ten;
                    b_ten = b_tenM.Replace("/", "").Replace("#", "").Replace(" ", "_");
                }
                b_i = b_goc.LastIndexOf(".");
                b_mr = (b_i > 0) ? b_goc.Substring(b_i).ToLower() : "";
                b_ten += b_mr;
                b_goc = b_tmG + b_goc; b_ten = b_tmO + b_ten;
                File.Copy(b_goc, b_ten, true);
                if (chuyen.OBJ_S(b_dr["mhoa"]) == "1") khac.P_FILEdcr(b_ten);
            }
            b_ten = b_tm + "file.zip";
            //ZipFile.CreateFromDirectory(@b_tmO, @b_ten);
            ed_vb_khac.P_FI_DON();
            return b_ten;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_XOA(string b_login, string b_form, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            ed_vb_khac.P_FI_XOA(chuyen.CSO_SO(a_tso[0]), chuyen.CSO_SO(a_tso[1]));
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_BO_HANG(ref b_dt, new string[] { "so_id", "bt" }, new object[] { a_tso[0], a_tso[1] });
            se.P_TG_LUU(b_form, "DT_FILE", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_XOA0(string b_login, string b_form, int b_bt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_f = Fs_FI_TMF(b_bt);
            if (b_f != "" && File.Exists(b_f)) File.Delete(b_f);
            P_FI_LKE0(b_form);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_SUA(string b_login, string b_form, string b_ten, int b_cse, string b_mhoa, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_ma_dvi = (new se.se_nsd()).ma_dvi;
            double b_so_id = chuyen.CSO_SO(a_tso[0]), b_bt = chuyen.CSO_SO(a_tso[1]), b_namP = chuyen.CSO_SO(a_tso[2]);
            DataTable b_dt = ed_vb_khac.Fdt_FI_CT(b_ma_dvi, b_so_id, b_bt, b_namP);
            if (bang.Fb_TRANG(b_dt)) return "";
            ed_vb_khac.P_FI_SUA(b_so_id, b_bt, "N'" + b_ten, b_cse, b_mhoa);
            string b_goc = chuyen.OBJ_S(b_dt.Rows[0]["goc"]), b_mhoaG = chuyen.OBJ_S(b_dt.Rows[0]["mhoa"]);
            if (b_mhoa != b_mhoaG)
            {
                b_goc = khac.Fs_tmFile() + "\\" + b_goc;
                if (b_mhoa == "0") khac.P_FILEdcr(b_goc); else khac.P_FILEcry(b_goc);
            }
            b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_THAY_GTRI(ref b_dt, new string[] { "ten", "cse", "mhoa" }, new object[] { b_ten, b_cse, b_mhoa },
                new string[] { "ma_dvi", "so_id", "bt" }, new object[] { b_ma_dvi, a_tso[0], a_tso[1] });
            se.P_TG_LUU(b_form, "DT_FILE", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_SUA0(string b_login, string b_form, int b_bt, string b_ten, int b_cse, string b_mhoa)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_f = Fs_FI_TMF(b_bt);
            if (b_f != "" && File.Exists(b_f))
            {
                DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
                bang.P_THAY_GTRI(ref b_dt, "ten", b_ten, "bt", b_bt);
                se.P_TG_LUU(b_form, "DT_FILE", b_dt);
                b_ten = b_f.Substring(0, 4) + b_cse.ToString() + b_mhoa + b_ten;
                File.Move(b_f, b_ten);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_TEN(string b_login, string b_form, string b_ten, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_ma_dvi = (new se.se_nsd()).ma_dvi;
            double b_so_id = chuyen.CSO_SO(a_tso[0]), b_bt = chuyen.CSO_SO(a_tso[1]), b_namP = chuyen.CSO_SO(a_tso[2]);
            DataTable b_dt = ed_vb_khac.Fdt_FI_CT(b_ma_dvi, b_so_id, b_bt, b_namP);
            if (bang.Fb_TRANG(b_dt)) return "";
            int b_cse = chuyen.OBJ_I(b_dt.Rows[0]["cse"]);
            string b_mhoa = chuyen.OBJ_S(b_dt.Rows[0]["mhoa"]);
            ed_vb_khac.P_FI_SUA(b_so_id, b_bt, "N'" + b_ten, b_cse, b_mhoa);
            b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_THAY_GTRI(ref b_dt, "ten", b_ten, new string[] { "ma_dvi", "so_id", "bt" }, new object[] { b_ma_dvi, a_tso[0], a_tso[1] });
            se.P_TG_LUU(b_form, "DT_FILE", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_TEN0(string b_login, string b_form, int b_bt, string b_ten)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_f = Fs_FI_TMF(b_bt);
            if (b_f != "" && File.Exists(b_f))
            {
                DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
                bang.P_THAY_GTRI(ref b_dt, "ten", b_ten, "bt", b_bt);
                se.P_TG_LUU(b_form, "DT_FILE", b_dt);
                int b_i = b_f.LastIndexOf('/') + 7, b_j = b_f.LastIndexOf('.');
                b_ten = b_f.Substring(0, b_i) + b_ten;
                if (b_j > 0) b_ten += b_f.Substring(b_j);
                File.Move(b_f, b_ten);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_CHON(string b_login, string b_form, string b_chon, string[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = se.Fdt_TG_TRA(b_form, "DT_FILE");
            bang.P_THAY_GTRI(ref b_dt, "chon", b_chon, new string[] { "ma_dvi", "so_id", "bt" }, new object[] { a_tso[4], a_tso[0], a_tso[1] });
            se.P_TG_LUU(b_form, "DT_FILE", b_dt);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FI_CH(string b_login, string b_form, double b_so_id, string b_chuoi, string b_dk)
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
                string b_nd = "N'" + a_s[0], b_mr = a_s[1], b_kieuF = a_s[2], b_mhoa = a_s[3], b_t = b_so_id.ToString(), b_ftim = "";
                b_t = "/" + (new se.se_nsd()).ma_dvi + "/" + b_t.Substring(0, 4) + "/" + b_t.Substring(4, 2) + "/" + b_t.Substring(6, 2);
                string b_tf = b_goc + b_t + "/" + b_so_id.ToString();
                int b_i = 0; double b_cse = 1;
                khac.P_taoTmuc(b_t);
                if (a_s[4] == "K")
                {
                    b_ftim = b_tf + "_0." + b_mr;
                    while (File.Exists(b_ftim)) { b_i++; b_ftim = b_tf + "_" + kytu.C_NVL(b_i.ToString()) + "." + b_mr; }
                    if (b_mhoa.IndexOf(",") > 0)
                    {
                        a_s = b_mhoa.Split(',');
                        b_cse = chuyen.CSO_SO(a_s[0]); b_mhoa = a_s[1];
                    }
                    else b_mhoa = "1";
                    ed_vb_khac.P_FI_NH(b_so_id, b_nd, b_ftim.Substring(b_goc.Length), b_kieuF, b_cse, b_mhoa);
                }
                else
                {
                    b_i = a_s[0].LastIndexOf('/');
                    b_ftim = b_goc + "\\" + a_s[0].Substring(0, b_i + 1) + "S" + a_s[0].Substring(b_i + 1);
                }
                khac.P_FileB(b_ftim, b_fi);
                //if (ed_vb_fnet.Fb_CHINH()) ed_vb_fnet.Fs_LUU(b_so_id, b_ftim);
                se.P_BIEN_XOA(b_form, "FILES");
                if (b_mhoa == "1") khac.P_FILEcry(b_ftim);
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
                int b_kt = 9000;
                string b_tm = ed_vb_khac.Fs_TM(), b_s;
                string[] a_s = Directory.GetFiles(b_tm, "*.*");
                if (a_s.Length > 0)
                {
                    Array.Sort(a_s);
                    int b_i = a_s[0].LastIndexOf('/') + 1;
                    b_s = a_s[0].Substring(b_i, 4);
                    b_kt = (int)chuyen.CSO_SO(b_s) - 1;
                }
                a_s = b_dk.Split('|');
                b_s = b_kt.ToString() + a_s[3].Replace(",", "");
                b_s = b_tm + "\\" + b_s + a_s[0] + "." + a_s[1];
                khac.P_FileB(b_s, b_fi); se.P_BIEN_XOA(b_form, "FILES");
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
            string b_tm = ed_vb_khac.Fs_TM();
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
    #endregion
}