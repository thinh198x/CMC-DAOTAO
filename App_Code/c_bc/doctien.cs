using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for doctien
/// </summary>
public class doctien
{
    public static string join_unit(string n)
    {
        int sokytu = n.Length;
        int sodonvi = (sokytu % 3 > 0) ? (sokytu / 3 + 1) : (sokytu / 3);
        n = n.PadLeft(sodonvi * 3, '0');
        sokytu = n.Length;
        string chuoi = "";
        int i = 1;
        while (i <= sodonvi)
        {
            if (i == sodonvi) chuoi = join_number((int.Parse(n.Substring(sokytu - (i * 3), 3))).ToString()) + unit(i) + chuoi;
            else chuoi = join_number(n.Substring(sokytu - (i * 3), 3)) + unit(i) + chuoi;
            i += 1;
        }
        return chuoi;
    }

    public static string unit(int n)
    {
        string chuoi = "";
        if (n == 1) chuoi = " đồng ";
        else if (n == 2) chuoi = " nghìn ";
        else if (n == 3) chuoi = " triệu ";
        else if (n == 4) chuoi = " tỷ ";
        else if (n == 5) chuoi = " nghìn tỷ ";
        else if (n == 6) chuoi = " triệu tỷ ";
        else if (n == 7) chuoi = " tỷ tỷ ";
        return chuoi;
    }

    public static string convert_number(string n)
    {
        string chuoi = "";
        if (n == "0") chuoi = "không";
        else if (n == "1") chuoi = "một";
        else if (n == "2") chuoi = "hai";
        else if (n == "3") chuoi = "ba";
        else if (n == "4") chuoi = "bốn";
        else if (n == "5") chuoi = "năm";
        else if (n == "6") chuoi = "sáu";
        else if (n == "7") chuoi = "bảy";
        else if (n == "8") chuoi = "tám";
        else if (n == "9") chuoi = "chín";
        return chuoi;
    }

    public static string join_number(string n)
    {
        string chuoi = "";
        int i = 1, j = n.Length;
        while (i <= j)
        {
            if (i == 1) chuoi = convert_number(n.Substring(j - i, 1)) + chuoi;
            else if (i == 2) chuoi = convert_number(n.Substring(j - i, 1)) + " mươi " + chuoi;
            else if (i == 3) chuoi = convert_number(n.Substring(j - i, 1)) + " trăm " + chuoi;
            i += 1;
        }
        return chuoi;
    }

    public static string replace_special_word(string chuoi)
    {
        chuoi = chuoi.Replace("không mươi không ", "");
        chuoi = chuoi.Replace("không mươi", "lẻ");
        chuoi = chuoi.Replace("i không", "i");
        chuoi = chuoi.Replace("i năm", "i lăm");
        chuoi = chuoi.Replace("một mươi", "mười");
        chuoi = chuoi.Replace("mươi một", "mươi mốt");
        // viết hoa chữ cái đầu
        if (chuoi.Length > 0)
            chuoi = chuoi.Substring(0, 1).ToUpper() + chuoi.Substring(1).ToLower();
        return chuoi;
    }

    public static bool isnumeric(string chuoi)
    {
        foreach (char c in chuoi) if (!char.IsDigit(c)) return false;
        return true;
    }

}