using System;
using System.Data;
using System.Web;

/// <summary>
/// Summary description for c_kieu_chu
/// </summary>
public class c_kieu_chu
{
    public static string P_BODAU(string b_str)
    {
        //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
        for (int i = 1; i < VietnameseSigns.Length; i++)
        {
            for (int j = 0; j < VietnameseSigns[i].Length; j++)
                b_str = b_str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
        }
        return b_str;
    }
    private static readonly string[] VietnameseSigns = new string[]
    {

        "aAeEoOuUiIdDyY",

        "áàạảãâấầậẩẫăắằặẳẵ",

        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

        "éèẹẻẽêếềệểễ",

        "ÉÈẸẺẼÊẾỀỆỂỄ",

        "óòọỏõôốồộổỗơớờợởỡ",

        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

        "úùụủũưứừựửữ",

        "ÚÙỤỦŨƯỨỪỰỬỮ",

        "íìịỉĩ",

        "ÍÌỊỈĨ",

        "đ",

        "Đ",

        "ýỳỵỷỹ",

        "ÝỲỴỶỸ"
    };
    
}
