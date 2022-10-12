using System;
using System.Data;
using Cthuvien;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for ns_ctt
/// </summary>
public class ns_ctt
{
    #region PHÊ DUYỆT KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    /// <summary>
    /// thông tin chi tiết kế hoạch đào tạo: khđt + chi phí + tkb + môn thi
    /// </summary>
    /// <param name="b_so_id_kh"></param>
    /// <returns></returns>
    public static DataSet Fds_NS_DT_KH_CT_ALL(double b_so_id_kh)
    {
        return dbora.Fds_LKE(b_so_id_kh, 4, "PNS_DT_KH_CT_ALL");
    }

    /// <summary>
    /// cập nhật trạng thái phê duyệt
    /// </summary>
    /// <param name="b_so_id_tk"></param>
    public static void P_NS_DT_KH_CT_NH_PD(double b_so_id_kh, int b_tt_pd)
    {
        dbora.P_GOIHAM(new object[]{ b_so_id_kh, b_tt_pd}, "PNS_DT_KH_CT_NH_PD");
    }

    #endregion PHÊ DUYỆT KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    public static object[] Fdt_NS_CTT_DXDT_LKE(string b_so_the, double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXDT_LKE");
    }

    public static object[] Fdt_NS_CTT_DXDT_MA(double b_so_id, string b_so_the, double b_tt_pd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, b_tt_pd, b_trangkt }, "NNR", "PNS_CTT_DXDT_MA");
    }

    public static double P_NS_CTT_DXDT_NH(double b_so_id, string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            bool b_kdt_ht = b_dr["kdt_ht"].ToString() == "C";
            if (b_kdt_ht) b_dr["kdt"] = DBNull.Value;
            else b_dr["ma_kdt"] = DBNull.Value;

            string b_c = ",:b_so_id,"
                + chuyen.OBJ_C(b_so_the) + ","
                + chuyen.OBJ_N(b_dr["nam"]) + ","
                + chuyen.OBJ_N(b_dr["thang"]) + ","
                + (b_kdt_ht ? 1 : 0) + ","
                + chuyen.OBJ_C(b_dr["ma_kdt"]) + ","
                + chuyen.OBJ_C(b_dr["kdt"]) + ","
                + chuyen.OBJ_N(b_dr["thluong"]) + ","
                + chuyen.OBJ_C(b_dr["muctieu"]) + ","
                + chuyen.OBJ_C(b_dr["ddiem"]) + ","
                + chuyen.OBJ_C(b_dr["mota"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXDT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_CTT_DXDT_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CTT_DXDT_XOA");
    }

    
    public static DataTable Fdt_NS_CTT_DXDT_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CTT_DXDT_CT");
    }

    public static DataTable Fdt_NS_DT_MA_KDT_LKE_NAM(double b_nam)
    {
        return dbora.Fdt_LKE_S(b_nam, "PNS_DT_MA_KDT_LKE_NAM");
    }

    public static void P_NS_CTT_DXDT_GUI_PD(double b_so_id, int b_tt_pd)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_pd }, "PNS_CTT_DXDT_GUI_PD");
    }

    #endregion ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    #region CÁN BỘ QUẢN LÝ PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    public static object[] Fdt_NS_CTT_DXDT_PD_LKE(double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXDT_PD_LKE");
    }

    public static void P_NS_CTT_DXDT_NH_PD(double b_so_id, int b_tt_pd, string b_lydo)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_pd, b_lydo }, "PNS_CTT_DXDT_NH_PD");
    }


    #endregion CÁN BỘ QUẢN LÝ PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN
    
    #region ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    public static object[] Fdt_NS_CTT_DXDT_QL_LKE(string b_so_the, double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXDT_QL_LKE");
    }

    public static object[] Fdt_NS_CTT_DXDT_QL_MA(double b_so_id, string b_so_the, double b_tt_pd, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, b_tt_pd, b_trangkt }, "NNR", "PNS_CTT_DXDT_QL_MA");
    }

    public static void P_NS_CTT_DXDT_QL_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CTT_DXDT_QL_XOA");
    }

    public static double P_NS_CTT_DXDT_QL_NH(double b_so_id, string b_so_the, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            bool b_kdt_ht = b_dr["kdt_ht"].ToString() == "C";
            if (b_kdt_ht) b_dr["kdt"] = DBNull.Value;
            else b_dr["ma_kdt"] = DBNull.Value;

            string b_c = ",:b_so_id,"
                + chuyen.OBJ_C(b_so_the) + ","
                + chuyen.OBJ_N(b_dr["nam"]) + ","
                + chuyen.OBJ_N(b_dr["thang"]) + ","
                + (b_kdt_ht ? 1 : 0) + ","
                + chuyen.OBJ_C(b_dr["ma_kdt"]) + ","
                + chuyen.OBJ_C(b_dr["kdt"]) + ","
                + chuyen.OBJ_N(b_dr["thluong"]) + ","
                + chuyen.OBJ_C(b_dr["muctieu"]) + ","
                + chuyen.OBJ_C(b_dr["ddiem"]) + ","
                + chuyen.OBJ_N(b_dr["sl_hvien"]) + ","
                + chuyen.OBJ_N(b_dr["cp_dk"]) + ","
                + chuyen.OBJ_C(b_dr["mota"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXDT_QL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static double P_NS_CTT_DXDT_QL_NH1(double b_so_id, string b_so_the, DataTable b_dt, object[] a_so_id_xoa)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id, a_so_the;
            if (b_dt.Rows.Count > 0)
            {
                a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");                
            }
            else
            {
                a_so_id = new object[] { -1 }; 
                a_so_the = new object[] { "" };               
            }

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id_xoa", 'N', a_so_id_xoa);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);
            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            bool b_kdt_ht = b_dr["kdt_ht"].ToString() == "C";
            if (b_kdt_ht) b_dr["kdt"] = DBNull.Value;
            else b_dr["ma_kdt"] = DBNull.Value;

            string b_c = ",:b_so_id,"
                + chuyen.OBJ_C(b_so_the) + ","
                + chuyen.OBJ_N(b_dr["nam"]) + ","
                + chuyen.OBJ_N(b_dr["thang"]) + ","
                + (b_kdt_ht ? 1 : 0) + ","
                + chuyen.OBJ_C(b_dr["ma_kdt"]) + ","
                + chuyen.OBJ_C(b_dr["kdt"]) + ","
                + chuyen.OBJ_N(b_dr["thluong"]) + ","
                + chuyen.OBJ_C(b_dr["muctieu"]) + ","
                + chuyen.OBJ_C(b_dr["ddiem"]) + ","
                + chuyen.OBJ_N(b_dr["sl_hvien"]) + ","
                + chuyen.OBJ_N(b_dr["cp_dk"]) + ","
                + chuyen.OBJ_C(b_dr["mota"]) + ","
                + ":a_so_id_xoa,:a_so_id,:a_so_the";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXDT_QL_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fdt_NS_CTT_DXDT_QL_CT(double b_so_id, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_so_id, b_so_the }, 3, "PNS_CTT_DXDT_QL_CT");
    }

    
    public static void P_NS_CTT_DXDT_QL_GUI_PD(double b_so_id, int b_tt_pd)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_pd }, "PNS_CTT_DXDT_QL_GUI_PD");
    }

    public static DataTable Fdt_NS_CTT_DXDT_QL_NVDQ(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CTT_DXDT_QL_NVDQ");
    }

    public static void P_NS_CTT_DXDT_QL_NH_DX(double b_so_id_dx, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_the;
            if (b_dt.Rows.Count > 0)
            {
                a_so_the = bang.Fobj_COL_MANG(b_dt, "so_the");
            }
            else
            {
                a_so_the = new object[] { "#" };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_the", 'S', a_so_the);

            string b_c = "," + b_so_id_dx + ",:a_so_the";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXDT_QL_NH_DX(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();                
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }            
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_CTT_DXDT_QL_XOA_DX(DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            object[] a_so_id;
            if (b_dt.Rows.Count > 0)
            {
                a_so_id = bang.Fobj_COL_MANG(b_dt, "so_id");
            }
            else
            {
                a_so_id = new object[] { -1 };
            }

            dbora.P_THEM_PAR(ref b_lenh, "a_so_id", 'N', a_so_id);

            string b_c = ",:a_so_id";

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXDT_QL_XOA_DX(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = ex.Message;
            }
            finally { b_lenh.Parameters.Clear(); }
        }
        finally { b_cnn.Close(); }
    }

    public static DataSet Fdt_NS_CTT_DXDT_QL_NV(double b_so_id_dx, string b_so_the)
    {
        return dbora.Fds_LKE(new object[] { b_so_id_dx, b_so_the }, 2, "PNS_CTT_DXDT_QL_NV");
    }

    #endregion ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    public static object[] Fdt_NS_CTT_DXDT_QL_PD_LKE(double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXDT_QL_PD_LKE");
    }

    public static DataSet Fdt_NS_CTT_DXDT_QL_PD_CT(double b_so_id)
    {
        return dbora.Fds_LKE(new object[] { b_so_id }, 2, "PNS_CTT_DXDT_QL_PD_CT");
    }

    public static void P_NS_CTT_DXDT_PQ_NH_PD(double b_so_id, int b_tt_pd, string b_lydo)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_pd, b_lydo }, "PNS_CTT_DXDT_PQ_NH_PD");
    }

    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    #region ĐỀ XUẤT XÁC NHẬN CÔNG TÁC

    public static object[] Fdt_NS_CTT_DXXN_CT_LKE(string b_so_the, double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXXN_CT_LKE");
    }

    public static object[] Fdt_NS_CTT_DXXN_CT_MA(double b_so_id, string b_so_the, double b_tt_xn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, b_tt_xn, b_trangkt }, "NNR", "PNS_CTT_DXXN_CT_MA");
    }


    public static DataTable Fdt_NS_CTT_DXXN_CT_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CTT_DXXN_CT_CT");
    }

    public static double P_NS_CTT_DXXN_CT_NH(double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);
            
            string b_c = ",:b_so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["hkhau"]) + "," + chuyen.OBJ_C(b_dr["dchi"]) + "," + chuyen.OBJ_C(b_dr["socmt"]) 
                + "," + chuyen.OBJ_N(b_dr["ngay_cmt"]) + "," + chuyen.OBJ_C(b_dr["nc_cmt"]) + "," + chuyen.OBJ_C(b_dr["dtnr"]) + "," + chuyen.OBJ_C(b_dr["dtdd"]) 
                + "," + chuyen.OBJ_C(b_dr["cquan"]) + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["dchi_cq"]) + "," + chuyen.OBJ_C(b_dr["dtcq"]) 
                + "," + chuyen.OBJ_N(b_dr["ngay_vao"]) + "," + chuyen.OBJ_C(b_dr["lydo_xn"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXXN_CT_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_CTT_DXXN_CT_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CTT_DXXN_CT_XOA");
    }

    public static void P_NS_CTT_DXXN_CT_NH_XN(double b_so_id, double b_tt_xn)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_xn }, "PNS_CTT_DXXN_CT_NH_XN");
    }

    /// <summary>
    /// lấy thông tin cán bộ để điền giá trị ban đầu vào form xác nhận
    /// </summary>
    /// <param name="b_so_the">số thẻ nhân viên</param>
    /// <returns></returns>
    public static DataTable Fdt_NS_CTT_DXXN_CT_TTCB(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CTT_DXXN_CT_TTCB");
    }


    #endregion ĐỀ XUẤT XÁC NHẬN CÔNG TÁC

    #region ĐỀ XUẤT XÁC NHẬN MỨC LƯƠNG

    public static object[] Fdt_NS_CTT_DXXN_LG_LKE(string b_so_the, double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_so_the, b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_CTT_DXXN_LG_LKE");
    }

    public static object[] Fdt_NS_CTT_DXXN_LG_MA(double b_so_id, string b_so_the, double b_tt_xn, double b_trangkt)
    {
        return dbora.Faobj_LKE(new object[] { b_so_id, b_so_the, b_tt_xn, b_trangkt }, "NNR", "PNS_CTT_DXXN_LG_MA");
    }


    public static DataTable Fdt_NS_CTT_DXXN_LG_CT(double b_so_id)
    {
        return dbora.Fdt_LKE_S(b_so_id, "PNS_CTT_DXXN_LG_CT");
    }

    public static double P_NS_CTT_DXXN_LG_NH(double b_so_id, DataTable b_dt)
    {
        se.se_nsd b_se = new se.se_nsd();
        OracleConnection b_cnn = dbora.Fcn_KNOI();

        try
        {
            OracleCommand b_lenh = new OracleCommand();
            b_lenh.Connection = b_cnn;
            DataRow b_dr = b_dt.Rows[0];

            dbora.P_THEM_PAR(ref b_lenh, "b_so_id", 'N', 'O', b_so_id);

            string b_c = ",:b_so_id," + chuyen.OBJ_C(b_dr["so_the"]) + "," + chuyen.OBJ_C(b_dr["hkhau"]) + "," + chuyen.OBJ_C(b_dr["socmt"]) + "," + chuyen.OBJ_N(b_dr["ngay_cmt"]) 
                + "," + chuyen.OBJ_C(b_dr["nc_cmt"]) + "," + chuyen.OBJ_C(b_dr["cquan"]) + "," + chuyen.OBJ_C(b_dr["dchi_cq"]) + "," + chuyen.OBJ_C(b_dr["dtcq"]) + "," + chuyen.OBJ_C(b_dr["phong"])
                + "," + chuyen.OBJ_C(b_dr["cdanh"]) + "," + chuyen.OBJ_C(b_dr["lhd"]) + "," + chuyen.OBJ_C(b_dr["loai_hd"]) + "," + chuyen.OBJ_N(b_dr["ngayd_hd"]) + "," + chuyen.OBJ_N(b_dr["ngayc_hd"]) + "," + chuyen.OBJ_N(b_dr["ngay_vao"]) 
                + "," + chuyen.OBJ_N(b_dr["luong_chinh"]) + "," + chuyen.OBJ_C(b_dr["thue"]) + "," + chuyen.OBJ_N(b_dr["tn_khac"]) + "," + chuyen.OBJ_C(b_dr["dgiai_tnk"]) + "," + chuyen.OBJ_C(b_dr["lydo_xn"]);

            b_lenh.CommandText = "Begin " + b_se.dbo + ".PNS_CTT_DXXN_LG_NH(" + b_se.tso + b_c + "); end;";
            try
            {
                b_lenh.ExecuteNonQuery();
                if (b_so_id == 0)
                {
                    b_so_id = chuyen.OBJ_N(b_lenh.Parameters["b_so_id"].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally { b_lenh.Parameters.Clear(); }
            return b_so_id;
        }
        finally { b_cnn.Close(); }
    }

    public static void P_NS_CTT_DXXN_LG_XOA(double b_so_id)
    {
        dbora.P_GOIHAM(new object[] { b_so_id }, "PNS_CTT_DXXN_LG_XOA");
    }

    public static void P_NS_CTT_DXXN_LG_NH_XN(double b_so_id, double b_tt_xn)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_xn }, "PNS_CTT_DXXN_LG_NH_XN");
    }

    /// <summary>
    /// lấy thông tin cán bộ để điền giá trị ban đầu vào form xác nhận
    /// </summary>
    /// <param name="b_so_the">số thẻ nhân viên</param>
    /// <returns></returns>
    public static DataTable Fdt_NS_CTT_DXXN_LG_TTCB(string b_so_the)
    {
        return dbora.Fdt_LKE_S(b_so_the, "PNS_CTT_DXXN_LG_TTCB");
    }

    #endregion ĐỀ XUẤT XÁC NHẬN MỨC LƯƠNG

    #region XÁC NHÂN THÔNG TIN NHÂN SỰ, THÔNG TIN LƯƠNG

    public static object[] Fdt_NS_XN_CT_LKE(double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_XN_CT_LKE");
    }

    public static void P_NS_XN_CT_NH(double b_so_id, double b_tt_xn, string b_lydo_tuchoi, double b_ngay_tra_kq)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_xn, b_lydo_tuchoi, b_ngay_tra_kq }, "PNS_XN_CT_NH");
    }

    public static object[] Fdt_NS_XN_LG_LKE(double b_tt_pd, double b_tu_n, double b_den_n)
    {
        return dbora.Faobj_LKE(new object[] { b_tt_pd, b_tu_n, b_den_n }, "NR", "PNS_XN_LG_LKE");
    }

    public static void P_NS_XN_LG_NH(double b_so_id, double b_tt_xn, string b_lydo_tuchoi, double b_ngay_tra_kq)
    {
        dbora.P_GOIHAM(new object[] { b_so_id, b_tt_xn, b_lydo_tuchoi, b_ngay_tra_kq }, "PNS_XN_LG_NH");
    }

    #endregion XÁC NHÂN THÔNG TIN NHÂN SỰ, THÔNG TIN LƯƠNG
}