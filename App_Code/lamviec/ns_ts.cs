using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
public class ns_ts
{
    #region Ma du an
    /// <summary> Liệt kê </summary>
    public static object[] Fdt_NS_TS_DUAN_LKE(double b_tu, double b_den)
    {        
        return dbora.Faobj_LKE(new object[] { b_tu, b_den }, "NR", "pns_ts_duan_lke");
    }
    /// <summary> Nhập </summary>
    public static void P_NS_TS_DUAN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_S(b_dr["ma"]), chuyen.OBJ_C(b_dr["ten"]) }, "pns_ts_duan_nh");
    }
    /// <summary> Xóa </summary>
    public static void P_NS_TS_DUAN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "pns_ts_duan_xoa");
    }
    ///<summary>Liệt kê đơn vị và cấp dưới</summary>
    public static DataTable Fdt_MA_DU_AN()
    {
        return dbora.Fdt_LKE("pns_ts_duan_dvi_lke");
    }
    public static DataTable Fdt_MA_NV_QL()
    {
        return dbora.Fdt_LKE("pns_ts_nv_ql");
    }
    public static DataTable Fdt_MA_PHONG_TS_LKE()
    {
        return dbora.Fdt_LKE("PHT_MA_PHONG_TS_LKE");
    }
	#endregion

    #region map tai khoan
    /// <summary> Liệt kê </summary>
    public static DataTable Fdt_NS_TS_MAP_TAIKHOAN_LKE()
    {
        return dbora.Fdt_LKE("pNS_TS_MAP_TAIKHOAN_lke");
    }
    /// <summary> Nhập </summary>
    public static void P_NS_TS_MAP_TAIKHOAN_NH(DataTable b_dt)
    {
        DataRow b_dr = b_dt.Rows[0];
        dbora.P_GOIHAM(new object[] { chuyen.OBJ_S(b_dr["ma"]), chuyen.OBJ_S(b_dr["ma_cn"])}, "PNS_TS_MAP_TAIKHOAN_nh");
    }
    /// <summary> Xóa </summary>
    public static void P_NS_TS_MAP_TAIKHOAN_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "pNS_TS_MAP_TAIKHOAN_xoa");
    }
    ///<summary>Liệt kê đơn vị và cấp dưới</summary>
    public static DataTable Fdt_NS_TAIKHOAN()
    {
        return dbora.Fdt_LKE("pNS_TS_MAP_TAIKHOAN_dvi_lke");
    }
    public static DataTable Fdt_MA_NV_QL2()
    {
        return dbora.Fdt_LKE("pns_ts_nv_ql");
    }
    #endregion

	#region MÃ LOẠI CÔng việc
	public static DataTable Fdt_TS_MA_LOAI_CV_LKE()
	{
		return dbora.Fdt_LKE("pts_ma_loai_cv_dr_lke");
	}
	/// <summary>Liệt kê toàn bộ số liệu</summary>
	public static object[] Fdt_TS_MA_LOAI_CV_LKE(double b_tu_n, double b_den_n)
	{
		return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTS_MA_LOAI_CV_LKE");
	}
	///<summary>liet ke sau kiem tra </summary>

	public static object[] Fdt_TS_MA_LOAI_CV_MA(string b_ma, double b_trangkt)
	{
		return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTS_MA_LOAI_CV_MA");
	}
	/// <summary>Liệt kê chi tiet</summary>
	public static DataTable Fdt_TS_MA_LOAI_CV_CT(string b_ma)
	{
		return dbora.Fdt_LKE_S(b_ma, "PTS_MA_LOAI_CV_CT");
	}
	/// <summary>Nhập nội dung thông tin</summary>
	public static void P_TS_MA_LOAI_CV_NH(DataTable b_dt)
	{
		if (b_dt.Rows.Count > 0)
		{
			DataRow b_dr = b_dt.Rows[0];
			dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTS_MA_LOAI_CV_NH");
		}
	}
	/// <summary>Xóa thôn tin</summary>
	public static void P_TS_MA_LOAI_CV_XOA(string b_ma)
	{
		dbora.P_GOIHAM(b_ma, "PTS_MA_LOAI_CV_XOA");
	}
	#endregion MÃ LOẠI NGẠCH
	#region Ưu Tiên
	public static DataTable Fdt_TS_DO_UU_TIEN_LKE()
	{
		return dbora.Fdt_LKE("pts_do_uu_tien_dr_lke");
	}
	/// <summary>Liệt kê toàn bộ số liệu</summary>
	public static object[] Fdt_TS_DO_UU_TIEN_LKE(double b_tu_n, double b_den_n)
	{
		return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTS_DO_UU_TIEN_LKE");
	}
	///<summary>liet ke sau kiem tra </summary>

	public static object[] Fdt_TS_DO_UU_TIEN_MA(string b_ma, double b_trangkt)
	{
		return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTS_DO_UU_TIEN_MA");
	}
	/// <summary>Liệt kê chi tiet</summary>
	public static DataTable Fdt_TS_DO_UU_TIEN_CT(string b_ma)
	{
		return dbora.Fdt_LKE_S(b_ma, "PTS_DO_UU_TIEN_CT");
	}
	/// <summary>Nhập nội dung thông tin</summary>
	public static void P_TS_DO_UU_TIEN_NH(DataTable b_dt)
	{
		if (b_dt.Rows.Count > 0)
		{
			DataRow b_dr = b_dt.Rows[0];
			dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTS_DO_UU_TIEN_NH");
		}
	}
	/// <summary>Xóa thôn tin</summary>
	public static void P_TS_DO_UU_TIEN_XOA(string b_ma)
	{
		dbora.P_GOIHAM(b_ma, "PTS_DO_UU_TIEN_XOA");
	}
    #endregion MÃ LOẠI NGẠCH
    #region Ưu Tiên
    public static DataTable Fdt_TS_VI_TRI_LKE()
    {
        return dbora.Fdt_LKE("pts_VI_TRI_dr_lke");
    }
    /// <summary>Liệt kê toàn bộ số liệu</summary>
    public static object[] Fdt_TS_VI_TRI_LKE(double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTS_VI_TRI_LKE");
    }
    ///<summary>liet ke sau kiem tra </summary>

    public static object[] Fdt_TS_VI_TRI_MA(string b_ma, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTS_VI_TRI_MA");
    }
    /// <summary>Liệt kê chi tiet</summary>
    public static DataTable Fdt_TS_VI_TRI_CT(string b_ma)
    {
        return dbora.Fdt_LKE_S(b_ma, "PTS_VI_TRI_CT");
    }
    /// <summary>Nhập nội dung thông tin</summary>
    public static void P_TS_VI_TRI_NH(DataTable b_dt)
    {
        if (b_dt.Rows.Count > 0)
        {
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTS_VI_TRI_NH");
        }
    }
    /// <summary>Xóa thôn tin</summary>
    public static void P_TS_VI_TRI_XOA(string b_ma)
    {
        dbora.P_GOIHAM(b_ma, "PTS_VI_TRI_XOA");
    }
    #endregion MÃ LOẠI NGẠCH
    #region MÃ Skill
    public static DataTable Fdt_NS_TS_SKILL_LKE()
	{
        return dbora.Fdt_LKE("pns_ma_kynang_dr");
	}
	/// <summary>Liệt kê toàn bộ số liệu</summary>
	public static object[] Fdt_TS_SKILL_LKE(double b_tu_n, double b_den_n)
	{
		return dbora.Faobj_LKE(new object[] { b_tu_n, b_den_n }, "NR", "PTS_SKILL_LKE");
	}
	///<summary>liet ke sau kiem tra </summary>

	public static object[] Fdt_TS_SKILL_MA(string b_ma, double b_trangkt)
	{
		return dbora.Faobj_LKE(new object[] { b_ma, b_trangkt }, "NNR", "PTS_SKILL_MA");
	}
	/// <summary>Liệt kê chi tiet</summary>
	public static DataTable Fdt_TS_SKILL_CT(string b_ma)
	{
		return dbora.Fdt_LKE_S(b_ma, "PTS_SKILL_CT");
	}
	/// <summary>Nhập nội dung thông tin</summary>
	public static void P_TS_SKILL_NH(DataTable b_dt)
	{
		if (b_dt.Rows.Count > 0)
		{
			DataRow b_dr = b_dt.Rows[0];
			dbora.P_GOIHAM(new object[] { b_dr["ma"], b_dr["ten"] }, "PTS_SKILL_NH");
		}
	}
	/// <summary>Xóa thôn tin</summary>
	public static void P_TS_SKILL_XOA(string b_ma)
	{
		dbora.P_GOIHAM(b_ma, "PTS_SKILL_XOA");
	}
	#endregion MÃ LOẠI NGẠCH
	#region nhap time sheet
	public static void P_NS_TS_NH(string b_id_cv, ref string b_so_id, DataTable b_dt)
    { // Dan
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();
        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];
            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', chuyen.CSO_SO(b_so_id));
            string c = "," + chuyen.CSO_SO(b_id_cv) + ",:b_so_id" + "," + chuyen.OBJ_N(b_dr["ngay"])
                + "," + chuyen.OBJ_N(b_dr["tu_gio"]) + "," + chuyen.OBJ_N(b_dr["tu_phut"]) + "," + chuyen.OBJ_N(b_dr["den_gio"]) + "," + chuyen.OBJ_N(b_dr["den_phut"]) + "," + chuyen.OBJ_N(b_dr["phan_tram"]) + "," + chuyen.OBJ_C(b_dr["ghi_chu"]);
            b_lenh.CommandText = "Begin " + b_se.dbo + ".pns_ts_nh(" + b_se.tso + c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                b_so_id = chuyen.OBJ_S(b_lenh.Parameters["b_so_id"].Value);
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }
    public static object[] Fdt_NS_TS_LKE(string b_id_cv, DataTable b_dt, double b_tu, double b_den)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_id_cv, chuyen.OBJ_N(b_dr["tu_ngay_ts"]), chuyen.OBJ_N(b_dr["den_ngay_ts"]), b_tu, b_den }, "NR", "pns_ts_lke");
    }

    public static DataTable Fdt_NS_TS_LKE_HT(string b_id_cv)
    {
        return dbora.Fdt_LKE_S(new object[] { b_id_cv }, "pns_ts_lke_ht");
    }
    public static DataTable Fdt_NS_TS_CT(string b_so_id)
    { // Dan
        return dbora.Fdt_LKE_S(new object[] { b_so_id }, "pns_ts_ct");
    }
    public static void P_NS_TS_XOA(string b_so_id)
    {
        dbora.P_GOIHAM(b_so_id, " pns_ts_xoa");
    }
    public static object[] Faobj_NS_TS_ID(string b_id_cv, string b_so_id, DataTable b_dt, double b_TrangKt)
    {
        DataRow b_dr = b_dt.Rows[0];
        return dbora.Faobj_LKE(new object[] { b_so_id, b_id_cv, chuyen.OBJ_N(b_dr["tu_ngay_ts"]), chuyen.OBJ_N(b_dr["den_ngay_ts"]), b_TrangKt }, "NNR", "pns_ts_lke_id");
    }
   
    #endregion
}