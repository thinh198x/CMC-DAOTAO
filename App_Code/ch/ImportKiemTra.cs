using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;
using Microsoft.VisualBasic;
/// <summary>
/// Summary description for ImportKiemTra
/// </summary>
public class ImportKiemTra
{
    /// <summary>
    /// Kiểm tra email đúng định dạng
    /// </summary>
    /// <param name="colName">Cột </param>
    /// <param name="row">row</param>
    /// <param name="rowError">row lỗi</param>
    /// <param name="isError"> trang thái lỗi(true,false)</param>
    /// <param name="sError"> nội dung lỗi</param>
    public static void IsValidEmail(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (!KiemTra.IsValidEmail(value))
            {
                rowError[colName] += sError;
                isError = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Kiểm tra có phải là số, độ dài
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    /// <param name="isNegative"></param>
    public static void IsValid_Number(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError, bool isNegative = false)
    {
        string value = null;

        try
        {
            value = row[colName].ToString().Trim().Replace(",", "");
            row[colName] = value;
            if (!Information.IsNumeric(value))
            {
                rowError[colName] += sError;
                isError = true;
            }
            else
            {
                if (value.Length > 30)
                {
                    rowError[colName] += "Độ dài số không được vượt quá 30 ký tự";
                    isError = true;
                }
                else if (isNegative && decimal.Parse(value) < 0)
                {
                    rowError[colName] += "Không được phép nhập số âm";
                    isError = true;

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Kiểm tra có phải là năm(yyyy)
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    /// <param name="isNegative"></param>
    public static void IsValidYear(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError, bool isNegative = false)
    {
        string value = null;

        try
        {
            value = row[colName].ToString().Trim().Replace(",", "");
            row[colName] = value;
            if (!Information.IsNumeric(value))
            {
                rowError[colName] += sError;
                isError = true;
            }
            else
            {
                if (value.Length > 4)
                {
                    rowError[colName] += "Độ dài số không được vượt quá 4 ký tự";
                    isError = true;
                }
                else if (isNegative && decimal.Parse(value) < 0)
                {
                    rowError[colName] += "Không được phép nhập số âm";
                    isError = true;

                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public static bool IsValid_Number(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError, bool isNegative, int length)
    {
        string value = null;
        bool b_valid = true;
        try
        {
            value = row[colName].ToString().Trim().Replace(",", "");
            row[colName] = value;
            if (!Information.IsNumeric(value))
            {
                rowError[colName] += sError;
                isError = true;
                b_valid = false;
            }
            else
            {
                if (value.Length > length)
                {
                    rowError[colName] += "Độ dài số không được vượt quá " + length + " ký tự";
                    isError = true;
                    b_valid = false;
                }
                else if (isNegative && decimal.Parse(value) < 0)
                {
                    rowError[colName] += "Không được phép nhập số âm";
                    isError = true;
                    b_valid = false;
                }
            }
        }
        catch (Exception ex)
        {
            b_valid = false;
            throw ex;
        }
        return b_valid;
    }

    public static void CheckNumber(string colName, ref DataRow row, object defaultValue = null)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;

            //Add Reference Microsoft.VisualBasic là được
            if (!Information.IsNumeric(value))
            {
                if (defaultValue == null)
                {
                    row[colName] = DBNull.Value;
                }
                else
                {
                    row[colName] = defaultValue;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Kiểm tra có đúng định dạng ngày tháng năm
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static void IsValidDate(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }

            if (!KiemTra.ValidateDate(value, ref sError))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            row[colName] = KiemTra.FormatDate(value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void IsValidMonth(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }

            if (!KiemTra.ValidateMonth(value, ref sError))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            value = "01/01/2017";
            row[colName] = KiemTra.FormatDate(value);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool IsValidDateDDMMYYYY(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
                return false;
            }

            if (!KiemTra.ValidateDate(value, ref sError))
            {
                rowError[colName] += sError;
                isError = true;
                return false;
            }
            row[colName] = value;
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Kiểm tra có đúng định dạng ngày tháng năm
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static bool IsValidDateTime(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
                return false;
            }

            if (!KiemTra.ValidateDateTime(value, ref sError))
            {
                rowError[colName] += sError;
                isError = true;
                return false;
            }
            row[colName] = KiemTra.FormatDateTime(value);
            return true;
        }
        catch (Exception ex)
        {
            throw ex;
            return true;
        }
    }
    /// <summary>
    /// Kiểm tra đúng định dang URL
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static void KiemtraURL(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (!KiemTra.mf_KiemtraURL(value))
            {
                rowError[colName] += sError;
                isError = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void RemoteRow(ref DataTable table, int fromRow)
    {
        try
        {
            for (int i = 1; i <= fromRow; i++)
            {
                table.Rows.RemoveAt(0);
            }

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static void RenameColumn(ref DataTable table, DataRow Row)
    {
        try
        {
            for (int i = 0; i < table.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(Row[i].ToString()))
                {
                    table.Columns[i].ColumnName = Row[i].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Kiểm tra độ dài của chuỗi
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    /// <param name="ileng"></param>
    public static void IsValidLength(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError, int ileng)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (value.Length > ileng)
            {
                rowError[colName] += string.Format(sError, ileng);
                isError = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
    /// <summary>
    /// Kiểm tra có phải trống
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static void EmptyValue(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Kiểm tra có đúng định dạng thời gian HH:mm
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static void IsValidTime(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            value = row[colName].ToString().Trim();
            row[colName] = value;
            if (KiemTra.EmptyValue(value))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            int hour = int.Parse(value.Split(':')[0]);
            int minute = int.Parse(value.Split(':')[1]);
            if (KiemTra.EmptyValue(hour.ToString()))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            if (KiemTra.EmptyValue(minute.ToString()))
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            if (hour > 23 | hour < 0)
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            if (minute > 60 | minute < 0)
            {
                rowError[colName] += sError;
                isError = true;
                return;
            }
            if (KiemTra.IsNumber2(hour.ToString()))
            {
                rowError[colName] += sError;
                isError = true;
            }
            if (KiemTra.IsNumber2(minute.ToString()))
            {
                rowError[colName] += sError;
                isError = true;
            }
        }
        catch (Exception ex)
        {
            rowError[colName] += sError;
            isError = true;
        }
    }
    /// <summary>
    /// Kiểm tra không nhập + sai định dạng số
    /// </summary>
    /// <param name="colText">tên cột cần kiểm tra</param>
    /// <param name="colNumber">tên cột cần kiểm tra</param>
    /// <param name="row">bản ghi cần kiểm tra</param>
    /// <param name="rowError">bản ghi ghi nhận lỗi</param>
    /// <param name="isError">biến xác định có lỗi hay không?</param>
    /// <param name="sError">Mô tả cột. VD: Số tiền</param>
    public static void IsValidList(string colText, string colNumber, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            EmptyValue(colText, ref row, ref rowError, ref isError, sError);
            if (!string.IsNullOrEmpty(rowError[colText].ToString()))
            {
                rowError[colText] += sError + " chưa nhập";
                return;
            }

            value = row[colNumber].ToString().Trim().Replace(",", "");
            row[colNumber] = value;
            if (!Information.IsNumeric(value))
            {
                rowError[colText] += sError + " sai định dạng";
                isError = true;
            }
            else
            {
                if (value.Length > 30)
                {
                    rowError[colNumber] += sError + " độ dài số không được vượt quá 30 ký tự";
                    isError = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void IsValidListMa(string colText, string colNumber, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        string value = null;
        try
        {
            EmptyValue(colText, ref row, ref rowError, ref isError, sError);
            if (!string.IsNullOrEmpty(rowError[colText].ToString()))
            {
                rowError[colText] += sError + " chưa nhập";
                return;
            }

            value = row[colNumber].ToString().Trim().Replace(",", "");
            row[colNumber] = value;
            if (string.IsNullOrEmpty(value))
            {
                rowError[colText] += sError + " sai định dạng";
                isError = true;
            }
            else
            {
                if (value.Length > 30)
                {
                    rowError[colNumber] += sError + " độ dài số không được vượt quá 30 ký tự";
                    isError = true;
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Kiểm tra row có phải là trống
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public static bool TrimRow(ref DataRow row)
    {
        string value = null;
        string colName = null;
        bool isRow = false;
        try
        {
            DataTable dtData = row.Table;
            foreach (DataColumn col in dtData.Columns)
            {
                colName = col.ColumnName;
                value = row[colName].ToString().Trim();
                row[colName] = value;
                if (value != "#N/A" & !string.IsNullOrEmpty(value))
                {
                    isRow = true;
                }
            }
            return isRow;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    /// <summary>
    /// Công lỗi
    /// </summary>
    /// <param name="colName"></param>
    /// <param name="row"></param>
    /// <param name="rowError"></param>
    /// <param name="isError"></param>
    /// <param name="sError"></param>
    public static void AddError(string colName, ref DataRow row, ref DataRow rowError, ref bool isError, string sError)
    {
        try
        {
            rowError[colName] += sError;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

}
public static class KiemTra
{
    public static bool CheckateDDMMYYYY(string value, bool allowNull)
    {
        string sError = "";
        try
        {

            if (KiemTra.EmptyValue(value) && !allowNull)
            {
                return false;
            }

            if (!KiemTra.ValidateDate(value, ref sError))
            {
                return false;
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public static string FormatDate(string str)
    {
        dynamic day = str.Split('/')[0];
        dynamic month = str.Split('/')[1];
        dynamic year = str.Split('/')[2];
        return Strings.Format(new System.DateTime(int.Parse(year), int.Parse(month), int.Parse(day)), "dd/MMM/yyyy");
    }
    public static string FormatDateTime(string str)
    {
        dynamic day = str.Split('/')[0];
        dynamic month = str.Split('/')[1];
        dynamic year = str.Split('/')[2];
        dynamic hour = str.Split(':')[3];
        dynamic minute = str.Split(':')[4];
        return Strings.Format(new System.DateTime(year, month, day, hour, minute, 0, 0), "dd/MMM/yyyy");
    }
    public static bool EmptyValue(string s)
    {
        return (s.Trim() == null || s.Trim().Length == 0);
    }
    public static bool IsValidEmail(string strIn)
    {
        if (!EmptyValue(strIn))
        {
            return Regex.IsMatch(strIn, "^([\\w-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([\\w-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
        }
        else
        {
            return true;
        }
    }
    public static bool IsNumber2(string s)
    {
        if (!EmptyValue(s))
        {
            char[] chars = s.ToCharArray();
            foreach (char c in chars)
            {
                if (Regex.IsMatch(c.ToString(), "^[0-9]*$"))
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool ValidateDate(string str, ref string _error)
    {
        if (str.Split('/').Length != 3)
        {
            _error = "Sai định dạng dd/MM/yyyy";
            return false;
        }
        var day = str.Split('/')[0];
        var month = str.Split('/')[1];
        var year = str.Split('/')[2];
        if (day.Length > 2 || month.Length > 2 || year.Length > 4)
        {
            _error = "Sai định dạng dd/MM/yyyy";
            return false;
        }
        if (int.Parse(year) < 1900 | int.Parse(year) > 2999)
        {
            _error = "Năm không được nhỏ hơn 1900 và lớn hơn 2999";
            return false;
        }
        if (int.Parse(month) < 1 | int.Parse(month) > 12)
        {
            _error = "Tháng không được nhỏ hơn 1 và lớn hơn 12";
            return false;
        }
        if (int.Parse(day) < 1 | int.Parse(day) > System.DateTime.DaysInMonth(int.Parse(year), int.Parse(month)))
        {
            _error = "Ngày không được nhỏ hơn 1 và lớn hơn số ngày trong tháng";
            return false;
        }
        return true;
    }
    public static bool ValidateMonth(string str, ref string _error)
    {
        if (str.Split('/').Length != 2)
        {
            _error = "Sai định dạng MM/yyyy";
            return false;
        }
        var month = str.Split('/')[0];
        var year = str.Split('/')[1];
        if (month.Length > 2 || year.Length > 4)
        {
            _error = "Sai định dạng MM/yyyy";
            return false;
        }
        if (int.Parse(year) < 1900 | int.Parse(year) > 2999)
        {
            _error = "Năm không được nhỏ hơn 1900 và lớn hơn 2999";
            return false;
        }
        if (int.Parse(month) < 1 | int.Parse(month) > 12)
        {
            _error = "Tháng không được nhỏ hơn 1 và lớn hơn 12";
            return false;
        }
        return true;
    }
    public static bool ValidateDateTime(string str, ref string _error)
    {
        if (str.Split('/').Length != 3)
        {
            _error = "Sai định dạng dd/MM/yyyy";
            return false;
        }
        dynamic day = str.Split('/')[0];
        dynamic month = str.Split('/')[1];
        dynamic year = str.Split('/')[2];
        dynamic hour = str.Split(':')[3];
        dynamic minute = str.Split(':')[4];
        if (!Information.IsNumeric(day) | !Information.IsNumeric(month) | !Information.IsNumeric(year))
        {
            _error = "Sai định dạng dd/MM/yyyy";
            return false;
        }
        if (year < 1900 | year > 2999)
        {
            _error = "Năm không được nhỏ hơn 1900 và lớn hơn 2999";
            return false;
        }
        if (month < 1 | month > 12)
        {
            _error = "Tháng không được nhỏ hơn 1 và lớn hơn 12";
            return false;
        }
        if (day < 1 | day > System.DateTime.DaysInMonth(year, month))
        {
            _error = "Ngày không được nhỏ hơn 1 và lớn hơn số ngày trong tháng";
            return false;
        }
        return true;
    }
    public static bool mf_Kiemtrakytudacbiet(string _sKytu, string sv_ExceptionCharacter = "")
    {
        try
        {
            if (_sKytu.IndexOf("@", 0) >= 0 | _sKytu.IndexOf("#", 0) >= 0 | _sKytu.IndexOf("$", 0) >= 0 | _sKytu.IndexOf("%", 0) >= 0 | _sKytu.IndexOf("!", 0) >= 0 | _sKytu.IndexOf("^", 0) >= 0 | _sKytu.IndexOf("&", 0) >= 0 | _sKytu.IndexOf("*", 0) >= 0 | _sKytu.IndexOf("(", 0) >= 0 | _sKytu.IndexOf(")", 0) >= 0 | _sKytu.IndexOf("+", 0) >= 0 | _sKytu.IndexOf("=", 0) >= 0 | _sKytu.IndexOf("<", 0) >= 0 | _sKytu.IndexOf(">", 0) >= 0)
            {
                if (mf_ObjectIsNull(sv_ExceptionCharacter) == false)
                {
                    string sv_listKytudacbiet = "!,@,#,$,%,^,&,*,(,),=,+,{,},[,],|,\\,',/,?,>,<";
                    string[] _sv_sValues = sv_listKytudacbiet.Split(',');
                    sv_listKytudacbiet = "";
                    for (int kk = 0; kk <= _sv_sValues.Length - 1; kk++)
                    {
                        if (sv_ExceptionCharacter.IndexOf(mf_ObjectToString(_sv_sValues[kk]), 0) < 0)
                        {
                            sv_listKytudacbiet += mf_ObjectToString(_sv_sValues[kk]) + ",";
                        }
                    }
                    sv_listKytudacbiet = sv_listKytudacbiet.Trim(',');
                    _sv_sValues = sv_listKytudacbiet.Split(',');
                    for (int ii = 0; ii <= _sv_sValues.Length - 1; ii++)
                    {
                        if (_sKytu.IndexOf(mf_ObjectToString(_sv_sValues[ii]), 0) >= 0)
                        {
                            return true; // TODO: might not be correct. Was : Exit For
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return true;
    }
    public static string mf_ObjectToString(object obj)
    {
        try
        {
            if (obj == null)
                return "";
            return obj.ToString().Trim();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static bool mf_ObjectIsNull(object obj)
    {
        try
        {
            if (obj == null)
            {
                return true;
            }
            else if (mf_blength(obj) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static bool mf_blength(object obj)
    {
        try
        {
            bool flag = false;
            if (obj == null)
                return false;
            if (obj is DataTable)
            {
                if (((DataTable)obj).Rows.Count > 0)
                {
                    flag = true;
                }
            }
            else if (obj is DataRow[])
            {
                if (((DataRow[])obj).Length > 0)
                {
                    flag = true;
                }
            }
            else if (obj is DataSet)
            {
                if ((DataSet)obj != null)
                {
                    if (((DataSet)obj).Tables[0].Rows.Count > 0)
                    {
                        flag = true;
                    }
                }
            }
            else if (obj is DataRow)
            {
                if ((DataRow)obj != null)
                {
                    flag = true;
                }
            }
            else
            {
                if ((mf_ObjectToString(obj).Length > 0))
                {
                    flag = true;
                }
            }
            return flag;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static bool mf_KiemtraURL(string sv_Email)
    {
        try
        {
            if (mf_blength(sv_Email) == false)
            {
                return true;
            }
            if (mf_Kiemtrakytudacbiet(sv_Email, "-,@,.,_"))
            {
                return false;
            }

            int sl = 0;

            sl = 0;
            for (int i = 0; i <= sv_Email.Length - 1; i++)
            {
                if (sv_Email.Substring(i, 1) == ".")
                {
                    sl += 1;
                }
            }

            if (sl > 2)
            {
                return false;
            }

            return true;

        }
        catch (Exception ex)
        {
        }
        return true;
    }
}
