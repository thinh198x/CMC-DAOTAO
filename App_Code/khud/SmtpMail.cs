using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Data;
using Cthuvien;

/// <summary>
/// Summary description for SmtpMail
/// </summary>
public class SmtpMail
{
	public SmtpMail()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static string SendMail(string toAddress, string subject, string body)
    {
        // smtpGmail: smtp.gmail.com (port: 25,465,587)
        // smtpYahoo: smtp.mail.yahoo.com (port: nếu dùng ssl thì port 465,nếu không thì dùng port 587)
        // domain thông thường thì port: 25
        try
        {
            string fromAddress, fromPassword, b_host, b_ssl;
            int b_port;
            DataTable b_dt = dbora.Fdt_LKE("PNS_TLAP_EMAIL_CT");
            if (b_dt.Rows.Count <= 0)
            {
                fromAddress = "no-reply@hrm.cerp.vn";
                fromPassword = "Maiyeuem88";
                b_host = "smtp.gmail.com";
                b_port = 587;
                b_ssl = "C";
            }
            else
            {
                DataRow b_dr = b_dt.Rows[0];
                fromAddress = chuyen.OBJ_S(b_dr["email"]);
                fromPassword = chuyen.OBJ_S(b_dr["matkhau"]);
                b_host = chuyen.OBJ_S(b_dr["smtp"]);
                b_port = chuyen.OBJ_I(b_dr["port"]);
                b_ssl = chuyen.OBJ_S(b_dr["ssl"]);
            }
            //var smtp = new System.Net.Mail.SmtpClient();
            //{
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
            //    smtp.Timeout = 20000;
            //}

            // gan gia tri cho smtp

            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = b_host;
                smtp.Port = b_port;
                if (b_ssl == "C") smtp.EnableSsl = true;
                else smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                //smtp.Timeout = 5000;
            }

            // Thực hiện gửi mail
            smtp.Send(fromAddress, toAddress, subject, body);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    public static string SendMailTest(string fromAddress,string fromPassword,string b_host, string b_ssl,int b_port,string toAddress, string subject, string body)
    {
        try
        {
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = b_host;
                smtp.Port = b_port;
                if (b_ssl == "C") smtp.EnableSsl = true;
                else smtp.EnableSsl = false;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                //smtp.UseDefaultCredentials = true;
                //smtp.Timeout = 5000;
            }
            // Thực hiện gửi mail
            smtp.Send(fromAddress, toAddress, subject, body);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
}