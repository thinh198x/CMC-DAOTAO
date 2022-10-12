using System;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for c_docso
/// </summary>
public class c_docso
{
    public static string sochu(double so, string viet_anh)
    {
        string strResult = "";
        string[] t = { " MOT", " HAI", " BA", " BON", " NAM", " SAU", " BAY", " TAM", " CHIN", " KHONG" };
        string[] T1 = { " ", " NGAN", " TRIEU", " TI", " NGAN" };
        string[] t_v = { " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín", " không" };
        string[] t1_v = { " ", " ngàn", " triệu", " tỉ", " ngàn" };
        double[] lo = new double[10];
        double so1, so2 = 0;
        long solop, tram, chuc, dvi = 0;
        string chu = "", mstrs = "";

        so1 =  Math.Abs(so);
        solop = 1;
        while (so1 > 0)
        {
            so2 = so1;
            so1 = (long)so1 / 1000;
            lo[solop] = so2 - so1 * 1000;
            solop = solop + 1;
        }
        long i = solop - 1;
        long j = i;

        while (i > 0)
        {
            so1 = lo[i];
            if (so1 > 0)
            {
                tram = (long)so1 / 100;
                chuc = (long)(so1 - tram * 100) / 10;
                dvi = (long)(so1 % 10);
                mstrs = tram.ToString();
                tram = numberVal(mstrs);
                mstrs = chuc.ToString();
                chuc = numberVal(mstrs);
                mstrs = dvi.ToString();
                dvi = numberVal(mstrs);
                if (tram > 0)
                {
                    if (viet_anh.Equals("A"))
                    {
                        chu = chu + t[tram - 1] + " TRAM";
                    }
                    else
                    {
                        chu = chu + t_v[tram - 1] + " trăm";
                    }
                }
                else
                {
                    if (i < j)
                    {
                        tram = 10;
                        if (viet_anh.Equals("A"))
                        {
                            chu = chu + t[tram - 1] + " TRAM";
                        }
                        else
                        {
                            chu = chu + t_v[tram - 1] + " trăm";
                        }
                        tram = 0;
                    }
                }
                if (chuc > 1)
                {
                    if (viet_anh.Equals("A"))
                    {
                        chu = chu + t[chuc - 1] + " MUOI";
                    }
                    else
                    {
                        chu = chu + t_v[chuc - 1] + " mươi";
                    }
                }
                else if (chuc == 1)
                {
                    if (viet_anh.Equals("A"))
                    {
                        chu = chu + " MUOI";
                    }
                    else
                    {
                        chu = chu + " mười";
                    }
                }
                else if (chuc == 0)
                {
                    if (tram > 0 && dvi != 0)
                    {
                        if (viet_anh.Equals("A"))
                        {
                            chu = chu + " LINH";
                        }
                        else
                        {
                            chu = chu + " linh";
                        }
                    }
                }

                if (dvi != 0 && dvi != 5)
                {
                    if (viet_anh.Equals("A"))
                    {
                        chu = chu + t[dvi - 1];
                    }
                    else
                    {
                        chu = chu + t_v[dvi - 1];
                    }
                }
                else if (dvi == 5)
                {
                    if (chuc != 0)
                    {
                        if (viet_anh.Equals("A"))
                        {
                            chu = chu + " LAM";
                        }
                        else
                        {
                            chu = chu + " lăm";
                        }
                    }
                    else
                    {
                        if (viet_anh.Equals("A"))
                        {
                            chu = chu + " NAM";
                        }
                        else
                        {
                            chu = chu + " năm";
                        }
                    }
                }
                if (viet_anh.Equals("A"))
                {
                    chu = chu + T1[i - 1];
                }
                else
                {
                    chu = chu + t1_v[i - 1];
                }
            }
            i = i - 1;
        }
        if (so < 0)
        {
            if (viet_anh.Equals("A"))
            {
                chu = "AM" + chu;
            }
            else
            {
                chu = "âm" + chu;
            }
        }

        string c = chu.Trim();
        if (c.Length > 0)
        {
            string cH = c.Substring(0, 1).ToUpper();
            string cExt = c.Substring(1, c.Length - 1);
            strResult = cH + cExt;
        }
        return strResult;
    }

    public static string doichu(string ma_nt, string so, string don_vi)
    {
        string strTemp = "";
        double b_so = 0;
        double b_sole = 0;
        string b_kqua_temp = "";
        if (ma_nt.Equals("") || so.Equals(""))
        {
            strTemp = "";
        }
        else
        {
            if (ma_nt.Equals("VND"))
            {
                if (Convert.ToDouble(so) != 0)
                {
                    strTemp = sochu(Math.Round(Convert.ToDouble(so), 0), "V") + " đồng";
                }
            }
            else
            {
                string c = so.Trim();
                int i = c.IndexOf(".");
                int j = c.Length;
                if (i == -1)
                {
                    b_so = numberVal(c);
                    b_sole = 0;
                }
                else
                {
                    b_so = i > 0 ? Convert.ToDouble(c.Substring(0,i)) : 0;
                    b_sole = (j > i + 1) ? Convert.ToDouble(c.Substring(i + 1)) : 0;
                    b_kqua_temp = sochu(b_so, "U");
                }
                if (b_sole == 0)
                {
                    strTemp = sochu(b_so, "U") + " " + ma_nt;
                }else if (Convert.ToDouble(c.Substring(i + 1,1)) == 0)
                {
                    strTemp = b_kqua_temp.Length > 0 ? b_kqua_temp + " " + ma_nt + " " + sochu(b_sole, "U") + " " + don_vi : sochu(b_sole, "U") + " " + don_vi;
                }else if (b_sole > 0 && b_sole < 10)
                {
                    strTemp = b_kqua_temp.Length > 0 ? b_kqua_temp + " " + ma_nt + " " + sochu(b_sole, "U") + " mươi " + don_vi : sochu(b_sole, "U") + " mươi " + don_vi;
                }else
                {
                    strTemp = b_kqua_temp.Length > 0 ? b_kqua_temp + " " + ma_nt + " " + sochu(b_sole, "U") + " " + don_vi : strTemp = sochu(b_sole, "U") + " " + don_vi;
                }
            }
        }
        return strTemp;
    }
    public static long numberVal(string value)
    {
        string returnVal = string.Empty;
        MatchCollection collection = Regex.Matches(value, "\\d+");
        foreach (Match match in collection)
        {
            returnVal += match.ToString();
        }
        return Convert.ToInt64(returnVal);
    }
    
}
