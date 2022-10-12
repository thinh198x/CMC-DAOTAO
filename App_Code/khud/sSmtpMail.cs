using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Cthuvien;
using System.Data;


[System.Web.Script.Services.ScriptService]
public class sSmtpMail : System.Web.Services.WebService {
    [WebMethod(true)]
    public string SendMail(string b_toAddress, string b_subject, string b_body)
    {
        try
        {
            SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string SendMailM(object[] a_dt)
    {
        try
        {
            string b_toAddress,b_subject,b_body;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_toAddress = chuyen.OBJ_S(b_dt.Rows[i]["email"]);
                b_subject = chuyen.OBJ_S(b_dt.Rows[i]["ten"]) + " - " + chuyen.OBJ_S(b_dt.Rows[i]["subject"]);
                b_body = chuyen.OBJ_S(b_dt.Rows[i]["body"]);
                if (b_toAddress != "" && b_subject != "" && b_body != "")
                {
                    SmtpMail.SendMail(b_toAddress, b_subject, b_body);
                }
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string SendMail(object[] a_dt, string b_subject, string b_body)
    {
        try
        {
            string b_toAddress;
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_BO_HANG(ref b_dt, "email", "");

            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                b_toAddress = chuyen.OBJ_S(b_dt.Rows[i]["email"]);                
                SmtpMail.SendMail(b_toAddress, b_subject, b_body);                
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
}
