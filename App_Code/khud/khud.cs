using System;
using System.Web;
using System.Data;
using Oracle.DataAccess.Client;
using System.IO;
using Cthuvien;

public class khud
{
    #region KHAC
    //static string bakKey = "BAK_TCVN_";
    public static char[] tcvnchars = {'â', 'ì', 'õ', 'ó', 'ú', 'ã', 'á', 'ò', 'ê', 'ô', 'í', 'µ', '¸', '¶', '·', '¹', 
        '¨', '»', '¾', '¼', '½', 'Æ','©', 'Ç', 'Ê', 'È', 'É', 'Ë', '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ', 'ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö', 
        '×', 'Ý', 'Ø', 'Ü', 'Þ', 'ß', 'ä', '«', 'å', 'è', 'æ', 'ç', 'é', '¬', 'ë', 'î', 'ï', 'ñ', '­', 'ø', 'ö', '÷', 'ù', 
        'ý', 'û', 'ü', 'þ', '¡', '¢', '§', '£', '¤', '¥', '¦'};
    public static char[] unichars = {'õ', 'ỡ', 'ừ', 'ú', 'ỳ', 'ó', 'ỏ', 'ũ', 'ờ', 'ụ', 'ớ', 'à', 'á', 'ả', 'ã', 'ạ', 
        'ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ', 'â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ', 'đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ', 'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ', 
        'ì', 'í', 'ỉ', 'ĩ', 'ị', 'ò', 'ọ', 'ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ', 'ơ', 'ở', 'ợ', 'ù', 'ủ', 'ư', 'ứ', 'ử', 'ữ', 'ự', 
        'ý', 'ỷ', 'ỹ', 'ỵ', 'Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'};

    public static char[] unicodeConvertTable = new char[256];
    public static string Fs_Convert(string b_source, string b_dk = "X")
    {
        for (int i = 0; i < 256; i++) unicodeConvertTable[i] = (char)i;
        if (b_dk == "X")
        {
            for (int i = 0; i < tcvnchars.Length; i++) unicodeConvertTable[tcvnchars[i]] = unichars[i];
        }
        else
        {
            for (int i = 0; i < unichars.Length; i++) unicodeConvertTable[unichars[i]] = tcvnchars[i];
        }
        char[] b_result = b_source.ToCharArray();
        for (int i = 0; i < b_result.Length; i++)
        {
            if (b_result[i] < (char)256) b_result[i] = unicodeConvertTable[b_result[i]];
        }
        return new string(b_result);
    }
    public static void P_CONV_FONT(ref DataTable b_dt)
    {
        string b_kieu;
        for (int i = 0; i < b_dt.Columns.Count; i++)
        {
            b_kieu = b_dt.Columns[i].DataType.Name;
            if (b_kieu == "String")
                foreach (DataRow b_dr_2 in b_dt.Rows)
                    if (chuyen.OBJ_S(b_dr_2[i]).Length > 1) b_dr_2[i] = Fs_Convert(chuyen.OBJ_S(b_dr_2[i]));
                    else if (chuyen.OBJ_S(b_dr_2[i]) == "") b_dr_2[i] = " ";
        }
        b_dt.AcceptChanges();
    }
    // Convert Unicode sang TCVN
    public static string unicodeStr2 = "áàảãạăắằẳẵặâấầẩẫậđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵáàảãạắằẳẵặấầẩẫậéèẻẽẹếềểễệíìỉĩịóòỏõọốồổỗộớờởỡợúùủũụứừửữựýỳỷỹỵÀÁẠẢÃĂẮẰẲẶÂẬẦẤẨĐÊẾỆỀỄỂIỊÍÌĨỈÒÓỌỎÕÔỘỖỒỐỔƠỢỞỚỜỠÙÚỦỤƯỪỨỰỮỬỴÝỲỸỶ";
    public static string tcvnStr2 = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉË®ÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ¸µ¶·¹¾»¼½ÆÊÇÈÉËÐÌÎÏÑÕÒÓÔÖÝ×ØÜÞãßáâäèåæçéíêëìîóïñòôøõö÷ùýúûüþµ¸¹¶·¡¾»¼Æ¢ËÇÊÈ§£ÕÖÒÔÓIÞÝ×ÜØßãäáâ¤éçåèæ¥îëíêìïóñô¦õøù÷öþýúüû";
    public static char[] tcvnchars2 = tcvnStr2.ToCharArray();

    public static string Fs_Convert_TCVN(string SourceStr)
    {
        string result = "";
        char[] SourceArr = SourceStr.ToCharArray();
        foreach (var item in SourceArr)
        {
            int i = unicodeStr2.IndexOf(item);
            if (i >= 0)
                result += tcvnchars2[i];
            else
                result += item;
        }
        return result;
    }
    public static void P_CONV_FONT_TCVN(ref DataTable b_dt)
    {
        string b_kieu;
        for (int i = 0; i < b_dt.Columns.Count; i++)
        {
            b_kieu = b_dt.Columns[i].DataType.Name;
            if (b_kieu == "String")
                foreach (DataRow b_dr_2 in b_dt.Rows)
                    if (chuyen.OBJ_S(b_dr_2[i]).Length > 1) b_dr_2[i] = Fs_Convert_TCVN(chuyen.OBJ_S(b_dr_2[i]));
                    else if (chuyen.OBJ_S(b_dr_2[i]) == "") b_dr_2[i] = " ";
        }
        b_dt.AcceptChanges();
    }
    #endregion KHAC

    #region TTT
    /// <summary> Hỏi có thống kê </summary>
    public static bool Fb_TTT_HOI(string b_ps, string b_nv, string b_kdvi = "")
    { // Dan
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_KH_TTT_LKE" + b_kdvi);
        return !bang.Fb_TRANG(b_dt);
    }
    public static void P_FI_NH(string b_ma_dvi, string b_so_id, string b_ten, string b_goc)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_ten, b_goc }, "PKH_FILE_NH_FILEMAU");
    }
    /// <summary> Liệt kê </summary>
    public static DataTable Fdt_TTT_LKE(string b_ps, string b_nv, string b_kdvi = "")
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_ps, b_nv }, "PNS_KH_TTT_LKE" + b_kdvi);
    }
    /// <summary> Nhập </summary>
    public static void P_TTT_NH(string b_ps, string b_nv, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_ten = bang.Fobj_COL_MANG(b_dt, "ten");
            object[] a_loai = bang.Fobj_COL_MANG(b_dt, "loai");
            object[] a_bb = bang.Fobj_COL_MANG(b_dt, "bb");
            object[] a_ktra = bang.Fobj_COL_MANG(b_dt, "ktra");
            object[] a_f_tkhao = bang.Fobj_COL_MANG(b_dt, "f_tkhao");
            object[] a_f_sht_tkhao = bang.Fobj_COL_MANG(b_dt, "f_sht_tkhao");
            object[] a_lke = bang.Fobj_COL_MANG(b_dt, "lke");
            object[] a_tra = bang.Fobj_COL_MANG(b_dt, "tra");
            dbora.P_THEM_PAR(ref b_lenh, "a_ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "a_ten", 'U', a_ten);
            dbora.P_THEM_PAR(ref b_lenh, "a_loai", 'S', a_loai);
            dbora.P_THEM_PAR(ref b_lenh, "a_bb", 'S', a_bb);
            dbora.P_THEM_PAR(ref b_lenh, "a_ktra", 'S', a_ktra);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_tkhao", 'S', a_f_tkhao);
            dbora.P_THEM_PAR(ref b_lenh, "a_f_sht_tkhao", 'S', a_f_sht_tkhao);
            dbora.P_THEM_PAR(ref b_lenh, "a_lke", 'U', a_lke);
            dbora.P_THEM_PAR(ref b_lenh, "a_tra", 'U', a_tra);

            string c = ",'" + b_ps + "','" + b_nv + "',:a_ma,:a_ten,:a_loai,:a_bb,:a_ktra,:a_f_tkhao,:a_f_sht_tkhao,:a_lke,:a_tra";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KH_TTT_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary> Xóa </summary>
    public static void P_TTT_XOA(string b_ps, string b_nv)
    { // Dan
        dbora.P_GOIHAM(new object[] { b_ps, b_nv }, "PNS_KH_TTT_XOA");
    }
    public static string Fs_TTT(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return "";
        if (bang.Fi_TIM_COL(b_dt, "nd") < 0) bang.P_THEM_COL(ref b_dt, "nd", "");
        return bang.Fs_BANG_CH(b_dt, new string[] { "ten", "nd", "ma", "loai", "bb", "ktra", "f_tkhao", "f_sht_tkhao", "lke", "tra" });
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static DataTable Fdt_TTT()
    { // Dan
        return bang.Fdt_TAO_BANG("so_id_dt,loai,ma,nd", "NSSS");
    }
    /// <summary> Trả bảng nhập thông tin thêm </summary>
    public static DataTable Fdt_TTT(object[] a_dt)
    {
        DataTable b_dt = null;
        if (a_dt[1] != null) { b_dt = bang.Fdt_TAO_THEM(a_dt); bang.P_DON(ref b_dt, new string[] { "ma", "nd" }); }
        else
        {
            b_dt = Fdt_TTT();
            if (a_dt[0] != null)
            {
                string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
                if (mang.Fi_hang(a_cot, "so_id_dt") < 0) bang.P_BO_COT(ref b_dt, "so_id_dt");
            }
        }
        return b_dt;
    }
    /// <summary> Trả bảng nhập thông tin thêm </summary>
    public static string Fs_TTT_CH(DataTable b_dt)
    {
        return bang.Fs_BANG_CH(b_dt, "ma,nd");
    }
    /// <summary> Tạo tham số nhập thông tin thống kê </summary>
    public static void P_TTT_TS(ref OracleCommand b_lenh, DataTable b_dt, out string b_ts)
    {
        if (b_dt.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt, 1);
        if (bang.Fi_TIM_COL(b_dt, "so_id_dt") < 0) bang.P_THEM_COL(ref b_dt, "so_id_dt", 0);
        object[] ttt_so_id_dt = bang.Fobj_COL_MANG(b_dt, "so_id_dt");
        object[] ttt_ma = bang.Fobj_COL_MANG(b_dt, "ma");
        object[] ttt_nd = bang.Fobj_COL_MANG(b_dt, "nd");
        dbora.P_THEM_PAR(ref b_lenh, "ttt_so_id_dt", 'N', ttt_so_id_dt);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_ma", 'S', ttt_ma);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_nd", 'U', ttt_nd);
        b_ts = ",:ttt_so_id_dt,:ttt_ma,:ttt_nd";
    }
    /// <summary> Tạo tham số nhập thông tin thống kê khong lay doi tuong </summary>
    public static void P_TTT_TSn(ref OracleCommand b_lenh, DataTable b_dt, out string b_ts)
    {
        if (b_dt.Rows.Count == 0) bang.P_THEM_TRANG(ref b_dt, 1);
        object[] ttt_ma = bang.Fobj_COL_MANG(b_dt, "ma");
        object[] ttt_nd = bang.Fobj_COL_MANG(b_dt, "nd");
        dbora.P_THEM_PAR(ref b_lenh, "ttt_ma", 'S', ttt_ma);
        dbora.P_THEM_PAR(ref b_lenh, "ttt_nd", 'U', ttt_nd);
        b_ts = ",:ttt_ma,:ttt_nd";
    }
    public static void P_TTT_CDOI(ref DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["loai"]) == "S") b_dr["nd"] = chuyen.CH_CSO(chuyen.OBJ_S(b_dr["nd"]), 6);
        }
        b_dt.AcceptChanges();
    }
    public static void P_TTT_CDOI(string b_ps, string b_nv, ref DataTable b_dt, string b_kdvi = "")
    {
        if (bang.Fb_TRANG(b_dt)) return;
        DataTable b_dt_g = Fdt_TTT_LKE(b_ps, b_nv, b_kdvi);
        int b_hang; string b_ma;
        foreach (DataRow b_dr in b_dt_g.Rows)
        {
            if (chuyen.OBJ_S(b_dr["loai"]) == "S")
            {
                b_ma = chuyen.OBJ_S(b_dr["ma"]);
                b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
                if (b_hang >= 0) b_dt.Rows[b_hang]["nd"] = chuyen.CH_CSO(chuyen.OBJ_S(b_dt.Rows[b_hang]["nd"]), 6);
            }
        }
        b_dt.AcceptChanges();
    }
    /// <summary> Ghep thông tin thêm </summary>
    public static void P_TTT_GHEP(ref DataTable b_dt, DataTable b_ttt)
    {
        foreach (DataRow b_dr in b_ttt.Rows)
        {
            bang.P_THEM_COL(ref b_dt, chuyen.OBJ_S(b_dr["ma"]), chuyen.OBJ_S(b_dr["nd"]));
        }
    }
    /// <summary>Tach thông tin thêm </summary>
    public static DataTable Fdt_TTT_TACH(DataTable b_dt, string b_cot)
    {
        DataTable b_ttt = bang.Fdt_TAO_BANG("ma,nd", "SS");
        string[] a_cot = b_cot.Split(','); DataRow b_dr = b_dt.Rows[0];
        string b_s;
        for (int i = 0; i < a_cot.Length; i++)
        {
            b_s = kytu.C_NVL(chuyen.OBJ_S(b_dr[a_cot[i]]));
            if (b_s != "") {
                if (b_s.IndexOf("N'") == 0) b_s = b_s.Substring(2);
                bang.P_THEM_HANG(ref b_ttt, new object[] { a_cot[i], b_s }); 
            }
        }
        return b_ttt;
    }
    /// <summary> Kiểm tra trường phải nhập </summary>
    public static void P_KTRA_BB(DataTable b_dt)
    {
        if (bang.Fb_TRANG(b_dt)) return;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            if (chuyen.OBJ_S(b_dr["bb"]) == "C" && chuyen.OBJ_S(b_dr["nd"]) == "")
                throw new Exception("loi:Phải nhập " + chuyen.OBJ_S(b_dr["ten"]) + ":loi");
        }
    }
    public static void P_KTRA_BB(string b_ma_dvi, string b_ps, string b_so_id, string b_so_id_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            dbora.P_THEM_PAR(ref b_lenh, "loi", 'S');
            string c = "'" + b_ma_dvi + "','" + b_ps + "'," + b_so_id + "," + b_so_id_dt + ",:loi";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_KH_TTT_CT_KTRA(" + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                string b_kq = chuyen.OBJ_S(b_lenh.Parameters["loi"].Value);
                if (b_kq != "") throw new Exception("loi:Chưa nhập đầy đủ thông tin thống kê " + b_kq + ".:loi");
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static string Fs_TTT_TAO(string b_ps, string b_nv, string b_kdvi = "")
    {
        try
        {
            DataTable b_dt = Fdt_TTT_LKE(b_ps, b_nv, b_kdvi);
            if (bang.Fb_TRANG(b_dt)) return "";
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["bb"]) == "C") b_dr["ten"] = chuyen.OBJ_S(b_dr["ten"]) + "(*)";
            }
            //bang.P_THEM_COL(ref b_dt, new string[] { "nd", "loi", "mmm" }, "SSS");
            return khac.Fs_TTT_TAO(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region NSD RIENG
    public static string Fs_NSD_TSO(string b_nv)
    {
        string b_md = (new se.se_nsd()).md, b_kq = "";
        DataTable b_dt = dbora.Fdt_LKE_S(b_md, "PKH_NSD_TSO_LKE");
        int b_hang;
        if (!bang.Fb_TRANG(b_dt))
        {
            b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_nv);
            if (b_hang >= 0) b_kq = kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[b_hang]["tso"]));
        }
        return b_kq;
    }
    public static DataTable Fdt_NSD_TSO_LKE()
    {
        string b_md = (new se.se_nsd()).md;
        DataTable b_dt = dbora.Fdt_LKE_S(b_md, "PKH_NSD_TSO_LKE");
        if (bang.Fb_TRANG(b_dt)) return b_dt;
        DataTable b_dt_m = new DataTable();
        bang.P_THEM_TRANG(ref b_dt_m, 1);
        foreach (DataRow b_dr in b_dt.Rows)
        {
            bang.P_THEM_COL(ref b_dt_m, chuyen.OBJ_S(b_dr["ma"]), chuyen.OBJ_S(b_dr["tso"]));
        }
        return b_dt_m;
    }
    public static void P_NSD_TSO_NH(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            if (bang.Fb_TRANG(b_dt)) bang.P_THEM_TRANG(ref b_dt, 1);
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_tso = bang.Fobj_COL_MANG(b_dt, "tso");
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "tso", 'S', a_tso);
            string c = ",'" + b_se.md + "',:a_ma,:a_tso";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PKH_NSD_TSO_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    /// <summary> Tao NSD dung rieng </summary>
    public static DataTable Fdt_NSD_DU_LKE(string b_nv)
    {
        se.se_nsd b_se = new se.se_nsd();
        return dbora.Fdt_LKE_S(new object[] { b_se.md, b_nv }, "PKH_NSD_DU_LKE");
    }
    public static void P_NSD_DU_NH(string b_nv, string b_ma, string b_ten, string b_dan)
    {
        se.se_nsd b_se = new se.se_nsd();
        dbora.P_GOIHAM(new object[] { b_se.md, b_nv, b_ma, b_ten, b_dan }, "PKH_NSD_DU_NH");
    }
    public static void P_NSD_DU_XOA(string b_nv, string b_ma)
    {
        se.se_nsd b_se = new se.se_nsd();
        dbora.P_GOIHAM(new object[] { b_se.md, b_nv, b_ma }, "PKH_NSD_DU_XOA");
    }
    #endregion

    #region TRAO_DOI
    public static object[] Faobj_TRDOI_VIEC(string b_md, string b_nv, double b_viec)
    {
        return dbora.Faobj_LKE(new object[] { b_nv, b_viec }, "SN", "PNS_BT_GD_VIEC");
    }
    public static string Fs_TRDOI_VIEC(string b_md, string b_nv, double b_viec)
    {
        string b_ham = "";
        if (b_md == "BH") b_ham = "PNS_ID_NV_VIEC";
        return chuyen.OBJ_S(dbora.Fobj_LKE(new object[] { b_nv, b_viec }, 'S', b_ham));
    }
    ///<summary>Bảng liệt kê</summary>
    public static DataTable Fdt_TRDOI_LKE(string b_ma_dvi, double b_so_id, double b_cuoi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dvi, b_so_id, b_cuoi }, "PKH_TRDOI_LKE");
    }
    /// <summary> Nhập </summary>
    public static void P_TRDOI_NH(string b_ma_dvi, double b_so_id, string b_nd)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_nd }, "PKH_TRDOI_NH");
    }
    /// <summary> Nhập </summary>
    public static void P_GOP_NH(string b_goc, string b_nd)
    {
        dbora.P_GOIHAM(new object[] { b_goc, b_nd }, "PKH_GOP_NH");
    }
    public static object Fobj_GOP_NHF(string b_goc, string b_nd)
    {
        return dbora.Fobj_GOIHAM(new object[] { b_goc, b_nd }, "PKH_GOP_NHF");
    }
    #endregion TRAO_DOI

    #region FILE
    ///<summary>Bảng liệt kê</summary>
    public static DataTable Fdt_FI_CT(string b_ma_dvi, double b_so_id, double b_bt)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dvi, b_so_id, b_bt }, "PKH_FILE_CT");
    }
    ///<summary>Bảng liệt kê</summary>
    public static DataTable Fdt_FI_LKE(string b_ma_dvi, double b_so_id, double b_cuoi)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma_dvi, b_so_id, b_cuoi }, "PKH_FILE_LKE");
    }
    public static void P_FI_NH(string b_ma_dvi, double b_so_id, string b_ten, string b_goc, string b_kieuF)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_ten, b_goc, b_kieuF }, "PKH_FILE_NH");
    }
    public static void P_FI_NH_TDO(string b_ma_dvi, double b_so_id, string b_ten, string b_goc, string b_kieuF, double b_x, double b_y, double b_r)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_ten, b_goc, b_kieuF, b_x, b_y, b_r }, "PKH_FILE_NH");
    }
    public static void P_FI_XOA(string b_ma_dvi, double b_so_id, string b_goc)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_goc }, "PKH_FILE_XOA");
    }
    public static void P_FI_SUA(string b_ma_dvi, double b_so_id, string b_goc, string b_nd)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_goc, b_nd }, "PKH_FILE_SUA");
    }
    public static void P_FI_VTRI(string b_ma_dvi, double b_so_id, string b_goc, string b_vtri)
    {
        dbora.P_GOIHAM(new object[] { b_ma_dvi, b_so_id, b_goc, b_vtri }, "PKH_FILE_VTRI");
    }
    public static void P_FI_XOA(string b_t, string b_f)
    {
        try
        {
            string b_goc = khac.Fs_tmFile();
            if (b_goc != "")
            {
                string b_ten = b_goc + b_t + "/" + b_f;
                if (File.Exists(b_ten)) File.Delete(b_ten);
            }
        }
        catch { }
    }
    public static void P_FI_XOA(double b_so_id)
    {
        string b_goc = khac.Fs_tmFile();
        if (b_goc != "")
        {
            string b_f = b_so_id.ToString();
            string b_t = b_goc + "/" + b_f.Substring(0, 4) + "/" + b_f.Substring(4, 2) + "/" + b_f.Substring(6, 2);
            if (Directory.Exists(b_t))
            {
                b_f = "*" + b_f + "*.*";
                string[] a_f = Directory.GetFiles(b_t, "*" + b_f + "*.*");
                foreach (string b_s in a_f) File.Delete(b_s);
            }
        }
    }
    public static string Fs_FI_LUU(double b_so_id)
    {
        try
        {
            string b_tm = Fs_TM(), b_goc = khac.Fs_tmFile();
            if (b_goc == "") return "loi:Chưa khai báo thư mục lưu File:loi";
            string[] a_f = Directory.GetFiles(b_tm, "*.*");
            if (a_f.Length == 0) return "";
            string b_nd, b_mr, b_kieuF, b_t = b_so_id.ToString(), b_fL;
            b_t = "/" + b_t.Substring(0, 4) + "/" + b_t.Substring(4, 2) + "/" + b_t.Substring(6, 2);
            string b_tf = b_goc + b_t + "/" + b_so_id.ToString();
            int b_i;
            khac.P_taoTmuc(b_t);
            se.se_nsd b_se = new se.se_nsd();
            foreach (string b_fG in a_f)
            {
                b_i = b_fG.LastIndexOf('/') + 1;
                b_nd = b_fG.Substring(b_i);
                b_i = b_nd.LastIndexOf('.');
                if (b_i < 0) b_mr = ""; else { b_mr = b_nd.Substring(b_i); b_nd = b_nd.Substring(0, b_i); }
                b_i = 0; b_fL = b_tf + "_0" + b_mr;
                while (File.Exists(b_fL)) { b_i++; b_fL = b_tf + "_" + kytu.C_NVL(b_i.ToString()) + b_mr; }
                File.Copy(b_fG, b_fL, true);
                b_kieuF = (".png,.gif,.bmp,.jpg,.jpeg".IndexOf(b_mr) < 0) ? "K" : "C";
                b_nd = "N'" + b_nd; 
                khud.P_FI_NH(b_se.ma_dvi, b_so_id, b_nd, b_fL.Substring(b_goc.Length), b_kieuF);
                File.Delete(b_fG);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    public static void P_FI_DON()
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_tm = Fs_TM();
        string[] a_f = Directory.GetFiles(b_tm, "*.*");
        foreach (string b_s in a_f) File.Delete(b_s);
    }
    public static string Fs_TM()
    {
        se.se_nsd b_se = new se.se_nsd();
        string b_tm = HttpContext.Current.Server.MapPath("~/file_nhap");
        if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
        b_tm += "/" + b_se.ma_dvi + "_" + b_se.nsd;
        if (!Directory.Exists(b_tm)) Directory.CreateDirectory(b_tm);
        return b_tm + "/";
    }
    #endregion

    #region LOC
    public static void P_LOC_SO(ref DataTable b_dt)
    {
        string b_loai, b_tu, b_den;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_loai = chuyen.OBJ_S(b_dr["loai"]);
            if (b_loai == "S")
            {
                b_tu = chuyen.OBJ_S(b_dr["tu_nd"]); b_den = chuyen.OBJ_S(b_dr["den_nd"]);
                b_dr["tu_nd"] = (b_tu != "0") ? chuyen.CH_CSO(b_tu, 4) : "";
                b_dr["den_nd"] = (b_den != "0") ? chuyen.CH_CSO(b_den, 4) : "";
            }
        }
        b_dt.AcceptChanges();
    }
    public static void P_LOC_CH(ref DataTable b_dt)
    {
        string b_loai, b_s;
        foreach (DataRow b_dr in b_dt.Rows)
        {
            b_loai = chuyen.OBJ_S(b_dr["loai"]);
            if (b_loai == "S")
            {
                b_s = chuyen.OBJ_S(b_dr["tu_nd"]);
                b_dr["tu_nd"] = (b_s != "") ? chuyen.CSO_CH(b_s) : "0";
                b_s = chuyen.OBJ_S(b_dr["den_nd"]);
                b_dr["den_nd"] = (b_s != "") ? chuyen.CSO_CH(b_s) : "0";
            }
        }
        b_dt.AcceptChanges();
    }
    public static void P_LOC_MOI(string b_form, string b_file)
    {
        se.P_TG_XOA(b_form);
        DataTable b_dt = khac.Fdt_Excel(b_file);
        bang.P_DON(ref b_dt, "ma"); bang.P_CH_HOA(ref b_dt, "ma");
        if (bang.Fb_TRANG(b_dt)) throw new Exception("loi:Chưa tạo File tham số lọc:loi");
        bang.P_THEM_COL(ref b_dt, new string[] { "tu_nd", "tu_dk", "den_nd", "den_dk" }, "SSSS");
        se.P_TG_LUU(b_form, "DT_LOC", b_dt);
    }
    #endregion

    #region NV RIENG
    ///<summary> Tra tham so </summary>
    public static string Fs_NV_TSO(string b_md, string b_nv, string b_ma)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_md, b_nv }, "PKH_NV_TSO_LKE");
        string b_kq = "", b_t; int b_hang;
        if (!bang.Fb_TRANG(b_dt))
        {
            string[] a_ma = b_ma.Split(',');
            foreach (string b_s in a_ma)
            {
                b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_s);
                b_t = (b_hang < 0) ? "" : kytu.C_NVL(chuyen.OBJ_S(b_dt.Rows[b_hang]["tso"]));
                kytu.P_THEM(ref b_kq, b_t, "#");
            }
        }
        return b_kq;
    }
    public static DataTable Fdt_NV_TSO_LKE(string b_md, string b_nv)
    {
        DataTable b_dt = dbora.Fdt_LKE_S(new object[] { b_md, b_nv }, "PKH_NV_TSO_LKE");
        if (bang.Fb_TRANG(b_dt)) return b_dt;
        DataTable b_dt_m = new DataTable();
        bang.P_THEM_TRANG(ref b_dt_m, 1);
        foreach (DataRow b_dr in b_dt.Rows)
            bang.P_THEM_COL(ref b_dt_m, chuyen.OBJ_S(b_dr["ma"]), chuyen.OBJ_S(b_dr["tso"]));
        return b_dt_m;
    }
    public static void P_NV_TSO_NH(string b_md, string b_nv, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            if (bang.Fb_TRANG(b_dt)) bang.P_THEM_TRANG(ref b_dt, 1);
            object[] a_ma = bang.Fobj_COL_MANG(b_dt, "ma");
            object[] a_tso = bang.Fobj_COL_MANG(b_dt, "tso");
            dbora.P_THEM_PAR(ref b_lenh, "ma", 'S', a_ma);
            dbora.P_THEM_PAR(ref b_lenh, "tso", 'S', a_tso);
            string c = ",'" + b_md + "','" + b_nv + "',:a_ma,:a_tso";
            b_lenh.CommandText = "Begin " + b_se.dbo + ".PKH_NV_TSO_NH(" + b_se.tso + c + "); end;";
            try { b_lenh.ExecuteNonQuery(); }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    #endregion

    #region MENU
    public static string Fs_MENUkdo(string b_md, string b_kdo)
    {
        return chuyen.OBJ_S(dbora.Fobj_LKE(b_kdo, 'S', "P" + b_md + "_MENUkdo"));
    }
    #endregion

    #region CAY
    public static DataTable Fdt_CAY(string b_ma,string b_ham)
    {
        return dbora.Fdt_LKE_S(new object[] { b_ma,b_ham }, "PKH_CAY");
    }
    #endregion
}