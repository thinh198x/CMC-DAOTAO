using System;
using System.Data;
using System.Data.Common;
using System.IO;
using Cthuvien;

public class khud_file
{
    /// <summary>Mở file Excel</summary>
    public static DataTable Fdt_Excel(string b_ten)
    {
        DataTable b_dt_kq = null;
        try
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                if (b_ten.ToUpper().Contains(".DBF"))
                    connection.ConnectionString = "Provider=vfpoledb.1;Data Source=" + b_ten + ";";
                else if (b_ten.ToUpper().Contains(".XLSX"))
                    connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + b_ten + ";Extended Properties='Excel 12.0;'";
                else
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + b_ten + ";Extended Properties='Excel 8.0;'";
                using (DbCommand command = connection.CreateCommand())
                {
                    try
                    {
                        connection.Open();
                        DataTable b_dt = connection.GetSchema(System.Data.OleDb.OleDbMetaDataCollectionNames.Tables);
                        command.CommandText = "SELECT * FROM [" + chuyen.OBJ_S(b_dt.Rows[0]["table_name"]) + "]";
                        DbDataReader dr_vi = command.ExecuteReader();
                        b_dt = new DataTable(); b_dt.Load(dr_vi);
                        b_dt_kq = b_dt.Copy(); bang.P_DON(ref b_dt_kq);
                    }
                    catch { throw new Exception("loi:Lỗi mở File Excel:loi"); }
                    finally { connection.Close(); }
                }
            }
            return b_dt_kq;
        }
        catch { throw new Exception("loi:Lỗi mở File Excel:loi"); }
    }
    /// <summary>Mở file Excel</summary>
    public static DataTable Fdt_Excel(string b_ten, string b_sheet)
    {
        DataTable b_dt_kq = null;
        try
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            using (DbConnection connection = factory.CreateConnection())
            {
                if (b_ten.ToUpper().Contains(".XLSX"))
                    connection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + b_ten + ";Extended Properties='Excel 12.0;'";
                else
                    connection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + b_ten + ";Extended Properties='Excel 8.0;'";
                using (DbCommand command = connection.CreateCommand())
                {
                    try
                    {
                        connection.Open();
                        DataTable b_dt = connection.GetSchema(System.Data.OleDb.OleDbMetaDataCollectionNames.Tables);
                        command.CommandText = "SELECT * FROM [" + b_sheet + "$]";
                        DbDataReader dr_vi = command.ExecuteReader();
                        b_dt = new DataTable(); b_dt.Load(dr_vi);
                        b_dt_kq = b_dt.Copy(); bang.P_DON(ref b_dt_kq);
                    }
                    catch { throw new Exception("loi:Lỗi mở File Excel:loi"); }
                    finally { connection.Close(); }
                }
            }
        }
        catch { throw new Exception("loi:Lỗi mở File Excel:loi"); }
        return b_dt_kq;
    }
    /// <summary>Phân tích file CSS</summary>
    public static string[] Fas_CSS(string b_file, string b_css)
    {
        try
        {
            if (!File.Exists(b_file)) return null;
            System.IO.TextReader tr = new StreamReader(b_file);
            string b_s = tr.ReadToEnd().Replace(" ", ""), b_css_r; int b_i;
            tr.Close();
            while (b_s != "")
            {
                b_i = b_s.IndexOf(b_css);
                if (b_i < 0) return null;
                b_s = b_s.Substring(b_i);
                b_i = b_s.IndexOf("{");
                if (b_i < 0) return null;
                b_css_r = kytu.C_NVL(b_s.Substring(0, b_i));
                b_s = b_s.Substring(b_i + 1);
                b_i = b_s.IndexOf("}");
                if (b_i < 0) return null;
                if (b_css == b_css_r)
                {
                    if (b_i == 0) return null;
                    b_s = b_s.Substring(0, b_i);
                    return b_s.Split(';');
                }
                else b_s = b_s.Substring(b_i + 1);
            }
            tr.Close();
        }
        catch { }
        return null;
    }
    public static void P_FONT(string[] a_css,out string b_font,out float b_size)
    {
        b_font = ""; b_size = 0;
        try
        {
            string b_s; int b_i;
            for (int i = 0; i < a_css.Length; i++)
            {
                b_i=a_css[i].IndexOf("font-family:");
                if (b_i >= 0)
                {
                    b_i = a_css[i].IndexOf(":");
                    b_font = kytu.C_NVL(a_css[i].Substring(b_i + 1));
                }
                b_i = a_css[i].IndexOf("font-size:");
                if (b_i >= 0)
                {
                    b_i = a_css[i].IndexOf(":");
                    b_s = a_css[i].Substring(b_i + 1);
                    b_i = b_s.IndexOf("px");
                    if (b_i > 0)
                    {
                        b_s = b_s.Substring(0, b_i);
                        b_size = (float)(chuyen.CSO_SO(b_s)/1.3);
                    }
                    else b_size = (float)chuyen.CSO_SO(b_s);
                }
            }
            b_s = "";
        }
        catch { }
    }
}