using System;
using System.Web;
using System.Data;
using System.Web.Services;
using Cthuvien;
using System.IO;

[System.Web.Script.Services.ScriptService]
public class skhac : System.Web.Services.WebService
{
    [WebMethod(true)]
    public string Fs_LOGIN(string b_login) 
    {
        try
        {
            se.P_LOGIN(b_login);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_MA_LOI(string b_login, string b_ten, string b_ma, string b_ktra)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = (b_ktra == "") ? "" : khac.Fs_MA_LOI(b_ten, b_ma, b_ktra);
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_HOI_SERI(string b_login, string b_so_ct)
    {
        try { se.P_LOGIN(b_login); return kytu.Fs_HOI_SERI(b_so_ct); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string SE_Fs_DT_TG_TRA(string b_login, string b_form, string b_bang, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login); DataTable b_dt = se.Fdt_TG_TRA(b_form, b_bang);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string SE_Fs_DT_TG_TRA_N(string b_login, string b_form, string[] a_bang, object[] aa_cot)
    {
        try
        {
            se.P_LOGIN(b_login); string b_kq = "", b_moi; string[] a_cot;
            for (int i = 0; i < a_bang.Length; i++)
            {
                a_cot = (string[])aa_cot[i];
                b_moi = SE_Fs_DT_TG_TRA(b_login, b_form, a_bang[i], a_cot);
                if (b_kq == "") b_kq = b_moi;
                else b_kq = b_kq + "#" + b_moi;
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string SE_Fs_DT_TG_TRA_D(string b_login, string b_form, string b_bang, string[] a_cot, string b_doi)
    {
        try
        {
            se.P_LOGIN(b_login); DataTable b_dt = se.Fdt_TG_TRA(b_form, b_bang);
            bang.P_SO_CSO(ref b_dt, b_doi);
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string SE_Fs_TG_XOA(string b_login, string b_form, string b_bang = "")
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_bang == "") se.P_TG_XOA(b_form);
            else
            {
                string[] a_bang = b_bang.Split(',');
                se.P_TG_XOA(b_form, a_bang);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string SE_Fs_TG_GIU(string b_login, string b_form, string b_bang)
    {
        try
        {
            se.P_LOGIN(b_login); string[] a_bang = b_bang.Split(',');
            se.P_TG_GIU(b_form, a_bang); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DICH(string b_login, string b_id, string b_tim, string b_nuoc_m, string b_nuoc_c, string b_dk)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_kq = "", b_s, b_p;
            string[] a_id = b_id.Split('|'), a_tim = b_tim.Split('|'), a_p;
            for (int i = 0; i < a_id.Length; i++)
            {
                a_p = a_tim[i].Split('}'); b_s = "";
                for (int j = 0; j < a_p.Length; j++)
                {
                    b_p = khac.Fs_DICH_TIM(a_p[j], b_nuoc_m, b_nuoc_c);
                    if (j == 0) b_s = b_p; else b_s += "}" + b_p;
                }
                if (i == 0) b_kq = b_s; else b_kq += "|" + b_s;
            }
            if (b_dk != "BT") b_s = "";
            else b_s = "#" + khac.Fs_DICH_TIM("Đang xử lý!", b_nuoc_m, b_nuoc_c) + "#" + khac.Fs_DICH_TIM("Có xóa không?", b_nuoc_m, b_nuoc_c);
            return b_id + "#" + b_kq + "#" + b_dk + b_s;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public void P_LAY_TM(ref string[] a_tm, string b_tmuc)
    {
        string[] a_m = Directory.GetDirectories(b_tmuc); int b_kt = a_tm.Length;
        foreach (string b_m in a_m)
        {
            if (Directory.GetDirectories(b_m).Length > 0) P_LAY_TM(ref a_tm, b_m);
            else
            {
                b_kt++;
                Array.Resize<string>(ref a_tm, b_kt);
                a_tm[b_kt - 1] = b_m;
            }
        }
    }
    [WebMethod(true)]
    public string Fs_DICH_FORM(string b_login, string b_tmuc)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_tmuc == "") throw new Exception("loi:Nhập thư mục:loi");
            string b_kq = "", b_s; se.se_nsd b_se = new se.se_nsd();
            b_tmuc = Server.MapPath("~/App_form") + "/" + b_tmuc;
            string[] a_tm = { b_tmuc }, a_f; int j;
            P_LAY_TM(ref a_tm, b_tmuc);
            foreach (string b_tm in a_tm)
            {
                a_f = Directory.GetFiles(b_tm, "*.aspx");
                foreach (string b_f in a_f)
                {
                    j = b_f.IndexOf("App_form");
                    if (j >= 0)
                    {
                        b_s = b_f.Substring(j + 8);
                        b_s = b_s.Replace("\\", "/");
                        kytu.P_CONG(ref b_kq, b_s, "#");
                    }
                }
            }
            if (b_kq != "")
            {
                b_se.dich = "L";
                HttpContext.Current.Application[se.Fs_LOGIN_NSD(b_se.login)] = b_se;
            }
            return b_kq;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_DICH_SQL(string b_login, string b_tmuc)
    {
        try
        {
            se.P_LOGIN(b_login);
            if (b_tmuc != "") b_tmuc = "/" + b_tmuc;
            b_tmuc = Server.MapPath("~/sql") + b_tmuc;
            string b_s, b_l;
            string[] a_tm = { b_tmuc }, a_f, a_s; int b_kt;
            se.se_nsd b_se = new se.se_nsd();
            b_se.dich = "L";
            HttpContext.Current.Application[se.Fs_LOGIN_NSD(b_se.login)] = b_se;
            P_LAY_TM(ref a_tm, b_tmuc);
            foreach (string b_tm in a_tm)
            {
                a_f = Directory.GetFiles(b_tm, "*.sql");
                foreach (string b_f in a_f)
                {
                    using (var b_sr = new StreamReader(b_f))
                    {
                        b_s = "";
                        do
                        {
                            b_l = b_sr.ReadLine();
                            b_s += kytu.C_NVL(b_l);
                            if (b_s != "")
                            {
                                a_s = b_s.Split(';'); b_kt = a_s.Length - 1;
                                for (int i = 0; i < b_kt; i++) P_DICH_XLY(a_s[i]);
                                b_s = kytu.C_NVL(a_s[b_kt]);
                            }
                        }
                        while (b_l != null);
                        if (b_s != "") P_DICH_XLY(b_s);
                        b_sr.Close();
                    }
                }
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public void P_DICH_XLY(string b_s)
    {
        int b_d = b_s.IndexOf("'loi:"), b_c = b_s.IndexOf(":loi'");
        if (b_d >= 0 && b_c > 0)
        {
            b_d += 5; b_c -= b_d;
            string b_t = b_s.Substring(b_d, b_c);
            b_t.Replace(":", ""); b_t.Replace("  ", " ");
            string[] a_s = b_t.Split('#');
            foreach (string b_g in a_s)
            {
                if (b_g.IndexOf("||") < 0)
                {
                    b_t = khac.Fs_DICH_CDAU(b_g);
                    khac.Fs_DICH_TIM(b_t, "eng");
                }
            }
        }
    }
    [WebMethod(true)]
    public string Fs_LOI_DICH(string b_login, string b_loi)
    {
        try
        {
            se.P_LOGIN(b_login);
            string b_nuoc = khac.Fs_NUOC();
            return khac.Fs_DICH_TIM(b_loi, b_nuoc);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_FORM_LIST(string b_login,string b_kieu, string b_ktra, string b_gtri, int b_hangKt,object[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            return khac.Fs_FORM_LIST(b_kieu,b_ktra, b_gtri, b_hangKt,a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
}