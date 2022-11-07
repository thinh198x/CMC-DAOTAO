using System;
using System.Data;
using System.Web;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_ctt : System.Web.Services.WebService
{

    #region PHÊ DUYỆT KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_ALL(string b_login, double b_so_id_kh, string[] a_cot_lke_cp, string[] a_cot_lke_tkb, string[] a_cot_lke_mon)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataSet b_ds = ns_ctt.Fds_NS_DT_KH_CT_ALL(b_so_id_kh);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_cp = b_ds.Tables[1];
            DataTable b_dt_tkb = b_ds.Tables[2];
            DataTable b_dt_mon = b_ds.Tables[3];

            this.P_FormatData_KHDT(b_dt);
            this.P_TinhChiPhiDaoTao(b_dt_cp);

            bang.P_THEM_COL(ref b_dt_tkb, "gio", typeof(string));
            foreach (DataRow dr in b_dt_tkb.Rows)
                dr["gio"] = dr["gio_d"] + "-" + dr["gio_c"];

            return b_dt_cp.Rows.Count + "#" + b_dt_tkb.Rows.Count + "#" + b_dt_mon.Rows.Count 
                + "#" + ((bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)))
                + "#" + ((bang.Fb_TRANG(b_dt_cp) ? "" : bang.Fs_BANG_CH(b_dt_cp, a_cot_lke_cp)))
                + "#" + ((bang.Fb_TRANG(b_dt_tkb) ? "" : bang.Fs_BANG_CH(b_dt_tkb, a_cot_lke_tkb)))
                + "#" + ((bang.Fb_TRANG(b_dt_mon) ? "" : bang.Fs_BANG_CH(b_dt_mon, a_cot_lke_mon)));

        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private void P_FormatData_KHDT(DataTable b_dt)
    {
        bang.P_SO_CNG(ref b_dt, new string[] { "ngay_d", "ngay_c" });

        bang.P_SO_CH(ref b_dt, "KH_NAM");
        bang.P_SO_CH(ref b_dt, "TT_PD");
        bang.P_SO_CH(ref b_dt, "TT_LOP");

        bang.P_THAY_GTRI(ref b_dt, "KH_NAM", "1", "C");
        bang.P_THAY_GTRI(ref b_dt, "KH_NAM", "0", "K");

        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "1", "Chờ phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "2", "Được phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "TT_PD", "3", "Không phê duyệt");

        bang.P_THAY_GTRI(ref b_dt, "TT_LOP", "1", "BT");
        bang.P_THAY_GTRI(ref b_dt, "TT_LOP", "0", "HUY");
    }

    private void P_TinhChiPhiDaoTao(DataTable b_dt_cp)
    {
        // tính toán chi phí
        bang.P_THEM_COL(ref b_dt_cp, new string[] { "tong", "tong_hm", "NN" });
        double b_dgia, b_sluong, b_thue, b_tong;
        foreach (DataRow dr in b_dt_cp.Rows)
        {
            b_dgia = -1;
            if (dr["dgia"] != DBNull.Value && dr["sluong"] != DBNull.Value)
            {
                b_dgia = chuyen.OBJ_N(dr["dgia"]);
                b_sluong = chuyen.OBJ_N(dr["sluong"]);

                b_tong = b_dgia * b_sluong;
                dr["tong"] = b_tong;

                if (dr["thue"] != DBNull.Value)
                {
                    b_thue = chuyen.OBJ_N(dr["thue"]) / 100;
                    dr["tong_hm"] = b_tong + b_tong * b_thue;
                }
            }
        }

        bang.P_SO_CSO(ref b_dt_cp, new string[] { "dgia", "sluong", "thue", "tong", "tong_hm" });
    }

    [WebMethod(true)]
    public string Fs_NS_DT_KH_CT_NH_PD(string b_login, double b_so_id_kh, int b_tt_pd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_DT_KH_CT_NH_PD(b_so_id_kh, b_tt_pd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion PHÊ DUYỆT KẾ HOẠCH ĐÀO TẠO CHI TIẾT

    #region ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN
    
    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_LKE(string b_login, string b_so_the, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_LKE(b_so_the, b_tt_pd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.Format_DXDT(b_dt);
            
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
<<<<<<< HEAD
=======
            
>>>>>>> f3d2b32beddd5a3e2cac54262998a00f31adcf26
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_MA(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_MA(b_so_id, b_so_the, b_tt_pd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            this.Format_DXDT(b_dt);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private void Format_DXDT(DataTable b_dt)
    {
        foreach (DataRow dr in b_dt.Rows)
        {
            if (dr["kdt_ht"].ToString() == "0")
                dr["ten"] = dr["kdt"];
        }

        bang.P_SO_CH(ref b_dt, "KDT_HT");
        bang.P_THAY_GTRI(ref b_dt, "KDT_HT", "0", "K");
        bang.P_THAY_GTRI(ref b_dt, "KDT_HT", "1", "C");

        bang.P_SO_CH(ref b_dt, "tt_pd");
        bang.P_THAY_GTRI(ref b_dt, "tt_pd", "0", "Chưa gửi phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "tt_pd", "1", "Chờ phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "tt_pd", "2", "Được phê duyệt");
        bang.P_THAY_GTRI(ref b_dt, "tt_pd", "3", "Không phê duyệt");                
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_NH(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            b_so_id = ns_ctt.P_NS_CTT_DXDT_NH(b_so_id, b_so_the, b_dt_ct);

            return Fs_NS_CTT_DXDT_MA(b_login, b_so_id, b_so_the, b_tt_pd, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_XOA(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_XOA(b_so_id);
            return Fs_NS_CTT_DXDT_LKE(b_login, b_so_the, b_tt_pd, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXDT_CT(b_so_id);
            string b_tt_pd = "";
            if (b_dt.Rows.Count > 0) b_tt_pd = b_dt.Rows[0]["TT_PD"].ToString();

            this.Format_DXDT(b_dt);
            
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_tt_pd;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_DT_MA_KDT_LKE_NAM(string b_login, double b_nam, string b_formName)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataTable b_dt = ns_ctt.Fdt_NS_DT_MA_KDT_LKE_NAM(b_nam);
            se.P_TG_LUU(b_formName, "DT_DMKDT", b_dt);
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_GUI_PD(string b_login, double b_so_id, int b_tt_pd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_GUI_PD(b_so_id, b_tt_pd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_PD_LKE(string b_login, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_PD_LKE(b_tt_pd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            bang.P_THEM_COL(ref b_dt, "NAM_THANG", typeof(string));
            foreach (DataRow dr in b_dt.Rows)
            {
                if (dr["kdt_ht"].ToString() == "1")
                    dr["kdt"] = dr["ten"];
                dr["NAM_THANG"] = dr["Nam"] + "-" + dr["Thang"];
            }
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_NH_PD(string b_login, double b_so_id, int b_tt_pd, string b_lydo)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_NH_PD(b_so_id, b_tt_pd, b_lydo);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA NHÂN VIÊN

    #region ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_LKE(string b_login, string b_so_the, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_QL_LKE(b_so_the, b_tt_pd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.Format_DXDT(b_dt);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_MA(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_QL_MA(b_so_id, b_so_the, b_tt_pd, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            this.Format_DXDT(b_dt);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
       

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_NH(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            b_so_id = ns_ctt.P_NS_CTT_DXDT_QL_NH(b_so_id, b_so_the, b_dt_ct);

            return Fs_NS_CTT_DXDT_QL_MA(b_login, b_so_id, b_so_the, b_tt_pd, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_NH1(double b_so_id, string b_so_the, double b_tt_pd, double b_trangKT, object[] a_dt_ct, object[] a_so_id_xoa, object[] a_dt_dx, string[] a_cot_lke)//, string[] a_cot_lke_dx)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);

            b_so_id = ns_ctt.P_NS_CTT_DXDT_QL_NH1(b_so_id, b_so_the, b_dt_ct, a_so_id_xoa);

            return Fs_NS_CTT_DXDT_QL_MA("", b_so_id, b_so_the, b_tt_pd, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_XOA(string b_login, double b_so_id, string b_so_the, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_QL_XOA(b_so_id);
            return Fs_NS_CTT_DXDT_QL_LKE(b_login, b_so_the, b_tt_pd, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_CT(string b_login, double b_so_id, string b_so_the, string[] a_cot_lke_dx, string[] a_cot_lke_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataSet b_ds = ns_ctt.Fdt_NS_CTT_DXDT_QL_CT(b_so_id, b_so_the);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_dx = b_ds.Tables[1];
            DataTable b_dt_nv = b_ds.Tables[2];

            string b_tt_pd = "";
            if (b_dt.Rows.Count > 0) b_tt_pd = b_dt.Rows[0]["TT_PD"].ToString();
            bang.P_THEM_COL(ref b_dt_dx, "chon", "");
            bang.P_THEM_COL(ref b_dt_nv, "chon", "");
            this.Format_DXDT(b_dt);

            return (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)) + "#" + b_tt_pd + "#" + b_dt_dx.Rows.Count + "#" + b_dt_nv.Rows.Count
                 + "#" + ((bang.Fb_TRANG(b_dt_dx) ? "" : bang.Fs_BANG_CH(b_dt_dx, a_cot_lke_dx)))
                  + "#" + ((bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_lke_nv)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }     

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_GUI_PD(string b_login, double b_so_id, int b_tt_pd)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_QL_GUI_PD(b_so_id, b_tt_pd);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_NVDQ_LKE(string b_login, string b_so_the, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXDT_QL_NVDQ(b_so_the);
            bang.P_THEM_COL(ref b_dt, "chon", "");
            return b_dt.Rows.Count + "#" + (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_BANG_CH(b_dt, a_cot));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_NH_DX(string b_login, double b_so_id_dx, string b_so_the, object[] a_dt, string[] a_cot_lke_dx, string[] a_cot_lke_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            string[] a_cot_dx = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri_dx = (object[])a_dt[1];
            DataTable b_dt;
            if (a_gtri_dx == null)
                b_dt = bang.Fdt_TAO_BANG(a_cot_dx, "SS");
            else
                b_dt = bang.Fdt_TAO_THEM(a_cot_dx, a_gtri_dx);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            ns_ctt.P_NS_CTT_DXDT_QL_NH_DX(b_so_id_dx, b_dt);
           
            // lấy lại danh sách chưa đề xuất + đã đề xuất
            return this.Fs_NS_CTT_DXDT_QL_NV_LKE(b_login, b_so_id_dx, b_so_the, a_cot_lke_dx, a_cot_lke_nv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_XOA_DX(string b_login, double b_so_id_dx, string b_so_the, object[] a_dt, string[] a_cot_lke_dx, string[] a_cot_lke_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            string[] a_cot_dx = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri_dx = (object[])a_dt[1];
            DataTable b_dt;
            if (a_gtri_dx == null)
                b_dt = bang.Fdt_TAO_BANG(a_cot_dx, "SN");
            else
                b_dt = bang.Fdt_TAO_THEM(a_cot_dx, a_gtri_dx);
            bang.P_BO_HANG(ref b_dt, "chon", "");

            ns_ctt.P_NS_CTT_DXDT_QL_XOA_DX(b_dt);

            // lấy lại danh sách chưa đề xuất + đã đề xuất
            return this.Fs_NS_CTT_DXDT_QL_NV_LKE(b_login, b_so_id_dx, b_so_the, a_cot_lke_dx, a_cot_lke_nv);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }


    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_NV_LKE(string b_login, double b_so_id_dx, string b_so_the, string[] a_cot_lke_dx, string[] a_cot_lke_nv)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataSet b_ds = ns_ctt.Fdt_NS_CTT_DXDT_QL_NV(b_so_id_dx, b_so_the);
            DataTable b_dt_dx = b_ds.Tables[0], b_dt_nv = b_ds.Tables[1];
            bang.P_THEM_COL(ref b_dt_dx, "chon", "");
            bang.P_THEM_COL(ref b_dt_nv, "chon", "");
            // dong dx + dong nv + data dx + data nv
            return b_ds.Tables[0].Rows.Count + "#" + b_ds.Tables[1].Rows.Count
                + "#" + (bang.Fb_TRANG(b_dt_dx) ? "" : bang.Fs_BANG_CH(b_dt_dx, a_cot_lke_dx))
                + "#" + (bang.Fb_TRANG(b_dt_nv) ? "" : bang.Fs_BANG_CH(b_dt_nv, a_cot_lke_nv));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    #region PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_PD_LKE(string b_login, double b_tt_pd, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXDT_QL_PD_LKE(b_tt_pd, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            
            foreach (DataRow dr in b_dt.Rows)
            {
                if (dr["kdt_ht"].ToString() == "1")
                    dr["kdt"] = dr["ten"];
            }
            bang.P_SO_CSO(ref b_dt, "cp_dk");

            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_QL_PD_CT(string b_login, double b_so_id, string[] a_cot_lke_dx)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            DataSet b_ds = ns_ctt.Fdt_NS_CTT_DXDT_QL_PD_CT(b_so_id);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_dx = b_ds.Tables[1];
            
            //this.Format_DXDT(b_dt);
            bang.P_SO_CH(ref b_dt, "KDT_HT");
            bang.P_THAY_GTRI(ref b_dt, "KDT_HT", "0", "K");
            bang.P_THAY_GTRI(ref b_dt, "KDT_HT", "1", "C");

            bang.P_SO_CH(ref b_dt, "tt_pd");
            bang.P_THAY_GTRI(ref b_dt, "tt_pd", "1", "Chờ phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tt_pd", "2", "Được phê duyệt");
            bang.P_THAY_GTRI(ref b_dt, "tt_pd", "3", "Không phê duyệt");    

            return (bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0)) + "#" + b_dt_dx.Rows.Count
                 + "#" + ((bang.Fb_TRANG(b_dt_dx) ? "" : bang.Fs_BANG_CH(b_dt_dx, a_cot_lke_dx)));
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXDT_PQ_NH_PD(string b_login, double b_so_id, int b_tt_pd, string b_lydo)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login); 
            ns_ctt.P_NS_CTT_DXDT_PQ_NH_PD(b_so_id, b_tt_pd, b_lydo);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion PHÊ DUYỆT ĐỀ XUẤT ĐÀO TẠO CỦA CÁN BỘ QUẢN LÝ

    #region ĐỀ XUẤT XÁC NHẬN CÔNG TÁC

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_LKE(string b_login, string b_so_the, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXXN_CT_LKE(b_so_the, b_tt_xn, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.P_NS_CTT_DXXN_CT_FormatData(b_dt);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private void P_NS_CTT_DXXN_CT_FormatData(DataTable b_dt)
    {
        bang.P_SO_CSO(ref b_dt, "tt_xn");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "", "Chưa gửi");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "0", "Chưa gửi");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "1", "Chờ xác nhận");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "2", "Được xác nhận");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "3", "Từ chối");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "4", "Yêu cầu sửa lại");

        if (b_dt.Columns.Contains("NGAY_CMT"))
            bang.P_SO_CNG(ref b_dt, "NGAY_CMT");
        if (b_dt.Columns.Contains("NGAY_VAO"))
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO");
        if (b_dt.Columns.Contains("NGAY_TRA_KQ"))
            bang.P_SO_CNG(ref b_dt, "NGAY_TRA_KQ");
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_MA(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXXN_CT_MA(b_so_id, b_so_the, b_tt_xn, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            this.P_NS_CTT_DXXN_CT_FormatData(b_dt);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXXN_CT_CT(b_so_id);
            string b_tt_xn = "";
            if (b_dt.Rows.Count > 0) b_tt_xn = b_dt.Rows[0]["TT_XN"].ToString();
            this.P_NS_CTT_DXXN_CT_FormatData(b_dt);           

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_tt_xn;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_NH(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "NGAY_CMT", "NGAY_VAO" });
            b_so_id = ns_ctt.P_NS_CTT_DXXN_CT_NH(b_so_id, b_dt_ct);

            return Fs_NS_CTT_DXXN_CT_MA(b_login, b_so_id, b_so_the, b_tt_xn, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_XOA(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_CTT_DXXN_CT_XOA(b_so_id);
            return Fs_NS_CTT_DXXN_CT_LKE(b_login, b_so_the, b_tt_xn, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_NH_XN(string b_login, double b_so_id, int b_tt_xn)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_CTT_DXXN_CT_NH_XN(b_so_id, b_tt_xn);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_CT_TTCB(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXXN_CT_TTCB(b_so_the);
            
            bang.P_SO_CNG(ref b_dt, new string[] { "NGAY_CMT", "NGAY_VAO"});

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐỀ XUẤT XÁC NHẬN CÔNG TÁC

    #region ĐỀ XUẤT XÁC NHẬN MỨC LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_LKE(string b_login, string b_so_the, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXXN_LG_LKE(b_so_the, b_tt_xn, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.P_NS_CTT_DXXN_LG_FormatData(b_dt);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    private void P_NS_CTT_DXXN_LG_FormatData(DataTable b_dt)
    {
        bang.P_SO_CSO(ref b_dt, "tt_xn");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "", "Chưa gửi");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "0", "Chưa gửi");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "1", "Chờ xác nhận");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "2", "Được xác nhận");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "3", "Từ chối");
        bang.P_THAY_GTRI(ref b_dt, "tt_xn", "4", "Yêu cầu sửa lại");

        if (b_dt.Columns.Contains("NGAY_CMT"))
            bang.P_SO_CNG(ref b_dt, "NGAY_CMT");
        if (b_dt.Columns.Contains("NGAYD_HD"))
            bang.P_SO_CNG(ref b_dt, "NGAYD_HD");
        if (b_dt.Columns.Contains("NGAYC_HD"))
            bang.P_SO_CNG(ref b_dt, "NGAYC_HD");
        if (b_dt.Columns.Contains("NGAY_VAO"))
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO");
        if (b_dt.Columns.Contains("NGAY_TRA_KQ"))
            bang.P_SO_CNG(ref b_dt, "NGAY_TRA_KQ");
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_MA(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double b_trangkt, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            object[] a_object = ns_ctt.Fdt_NS_CTT_DXXN_LG_MA(b_so_id, b_so_the, b_tt_xn, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            this.P_NS_CTT_DXXN_LG_FormatData(b_dt);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_CT(string b_login, double b_so_id)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXXN_LG_CT(b_so_id);
            string b_tt_xn = "";
            if (b_dt.Rows.Count > 0) b_tt_xn = b_dt.Rows[0]["TT_XN"].ToString();
            this.P_NS_CTT_DXXN_LG_FormatData(b_dt);
            bang.P_TIM_THEM(ref b_dt, "ns_ctt_dxxn_lg", "DT_LOAI_HD", "lhd");
            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0) + "#" + b_tt_xn;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_NH(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CNG_SO(ref b_dt_ct, new string[] { "NGAY_CMT", "NGAYD_HD", "NGAYC_HD", "NGAY_VAO" });
            b_so_id = ns_ctt.P_NS_CTT_DXXN_LG_NH(b_so_id, b_dt_ct);

            return Fs_NS_CTT_DXXN_LG_MA(b_login, b_so_id, b_so_the, b_tt_xn, b_trangKT, a_cot_lke) + "#" + b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_XOA(string b_login, double b_so_id, string b_so_the, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_CTT_DXXN_LG_XOA(b_so_id);
            return Fs_NS_CTT_DXXN_LG_LKE(b_login, b_so_the, b_tt_xn, a_tso, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_NH_XN(string b_login, double b_so_id, int b_tt_xn)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_CTT_DXXN_LG_NH_XN(b_so_id, b_tt_xn);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_CTT_DXXN_LG_TTCB(string b_login, string b_so_the)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXXN_LG_TTCB(b_so_the);

            bang.P_SO_CNG(ref b_dt, new string[] { "NGAY_CMT", "NGAY_VAO" });

            return bang.Fb_TRANG(b_dt) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion ĐỀ XUẤT XÁC NHẬN MỨC LƯƠNG

    #region XÁC NHÂN THÔNG TIN NHÂN SỰ, THÔNG TIN LƯƠNG

    [WebMethod(true)]
    public string Fs_NS_XN_CT_LKE(string b_login, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_XN_CT_LKE(b_tt_xn, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.P_NS_CTT_DXXN_CT_FormatData(b_dt);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_XN_CT_NH(string b_login, double b_so_id, double b_tt_xn, string b_lydo_tuchoi, double b_ngay_tra_kq)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_XN_CT_NH(b_so_id, b_tt_xn, b_lydo_tuchoi, b_ngay_tra_kq);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_XN_LG_LKE(string b_login, double b_tt_xn, double[] a_tso, string[] a_cot)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ctt.Fdt_NS_XN_LG_LKE(b_tt_xn, b_tu_n, b_den_n);
            DataTable b_dt = (DataTable)a_object[1];
            this.P_NS_CTT_DXXN_LG_FormatData(b_dt);
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_XN_LG_NH(string b_login, double b_so_id, double b_tt_xn, string b_lydo_tuchoi, double b_ngay_tra_kq)
    {
        try
        {
            if (b_login != "") se.P_LOGIN(b_login);
            ns_ctt.P_NS_XN_LG_NH(b_so_id, b_tt_xn, b_lydo_tuchoi, b_ngay_tra_kq);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    #endregion XÁC NHÂN THÔNG TIN NHÂN SỰ, THÔNG TIN LƯƠNG
}
