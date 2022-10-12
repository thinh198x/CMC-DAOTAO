using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Cthuvien;

public class c_khac
{ 
    public static string BKT_LOAI_BC(string b_ngayd, string b_ngayc, string b_loai)
    {
        DateTime b_tdt = chuyen.CNG_NG(b_ngayd), b_ddt = chuyen.CNG_NG(b_ngayc);
        switch (b_loai)
        { 
            case "NGAY": 
                if(b_ngayd == b_ngayc) return "Ngày " + b_ngayd;
                else return "Từ ngày " + b_ngayd + " đến ngày " + b_ngayc;
            case "THANG": return "Tháng " + b_tdt.ToString("MM") + " năm " + b_tdt.ToString("yyyy");
            case "QUY":
                if (b_tdt.Year == b_ddt.Year)
                    return "Qúy " + chuyen.OBJ_I(b_ddt.Month / 3).ToString() + " năm" + b_ddt.ToString("yyyy");
                else return "";
        }
        return "";
    }
    // Mở mẫu báo cáo
    public static DataTable Fdt_MO_MAU_BC(string b_ddan, string b_ten_rp)
    {
        //string b_url = HttpContext.Current.Server.MapPath(b_ddan + b_ten_rp + ".xml");
        string b_url = HttpContext.Current.Server.MapPath(b_ddan + b_ten_rp);
        if (File.Exists(b_url) == false || b_ddan.IndexOf("xml_mau")>0) return null;
        DataSet ds = new DataSet();
        try { ds.ReadXml(b_url); }
        catch (Exception ex) { throw new Exception(ex.Message); }
        DataTable b_dt = ds.Tables["row"].Copy();
        return b_dt;
    }
    public static DataTable MO_SL(Page b_f, string b_md, string b_tenref)
    { 
        string b_url = HttpContext.Current.Server.MapPath(b_md + b_tenref + ".xml");
        if (File.Exists(b_url) == false) return null;
        DataSet ds = new DataSet();
        try { ds.ReadXml(b_url); }
        catch (Exception ex) { throw new Exception(ex.Message); }
        DataTable b_dt = ds.Tables["row"].Copy();
        return b_dt;
    }
    public static string HOI_ND_TTT(string b_nv, string b_so_id)
    {
        string b_hnd = "";
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "bcten", 'S');
            string b_c = chuyen.OBJ_C(b_se.ma_dvi) + "," + chuyen.OBJ_C(b_nv) + "," + b_so_id + ",:bcten";
            b_lenh.CommandText = "Begin " + b_se.dbo +".PBC_TTT_LAY_ND(" + b_c + "); end;";
            try {
                b_lenh.ExecuteNonQuery();
                b_hnd = chuyen.OBJ_S(b_lenh.Parameters["bcten"].Value);   
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
        return b_hnd;
    }
    public static string HOI_TEN_DVI(string b_ma)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { "TEN", b_ma }, 'S', "PHT_MA_DVI_TEN"));
    }
    public static DataTable P_XOAY_COT(DataTable b_dt)
    {
        DataTable b_kq = new DataTable();
        for (int i = 0; i < b_dt.Rows.Count; i++)
            bang.P_THEM_COL(ref b_kq, chuyen.OBJ_S(b_dt.Rows[i]["ma"]), typeof(double));
        b_kq.Rows.Add(b_kq.NewRow()); b_kq.AcceptChanges();
        int b_i = -1;
        for (int i = 0; i < b_kq.Columns.Count; i++)
        {
            b_i = bang.Fi_TIM_ROW(b_dt, "ma", b_kq.Columns[i].ColumnName);
            if (b_i >= 0) b_kq.Rows[0][b_kq.Columns[i].ColumnName] = b_dt.Rows[b_i]["n1"];
        }
        return b_kq;
    }

    
}
