using System;
using System.Data;
using System.Web.Services;
using Cthuvien;

[System.Web.Script.Services.ScriptService]
public class sns_ts : WebService
{
    #region Ma Dự án
    [WebMethod(true)]
    public string Fs_NS_TS_DUAN_LKE(string b_login, string[] a_cot,double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            object[] a_obj = ns_ts.Fdt_NS_TS_DUAN_LKE((double)a_tso[0],(double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_DUAN_NH(string b_login, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = bang.Fdt_TAO_THEM(a_dt);
            ns_ts.P_NS_TS_DUAN_NH(b_dt); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_DUAN_XOA(string b_login, string b_ma)
    {
        try { se.P_LOGIN(b_login); ns_ts.P_NS_TS_DUAN_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region MAP TÀI KHOẢN
    [WebMethod(true)]
    public string Fs_NS_TS_MAP_TAIKHOAN_LKE(string b_login, string[] a_cot)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts.Fdt_NS_TS_MAP_TAIKHOAN_LKE();
            return bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_MAP_TAIKHOAN_NH(string b_login, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = bang.Fdt_TAO_THEM(a_dt);
            ns_ts.P_NS_TS_MAP_TAIKHOAN_NH(b_dt); return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_MAP_TAIKHOAN_XOA(string b_login, string b_ma)
    {
        try { se.P_LOGIN(b_login); ns_ts.P_NS_TS_MAP_TAIKHOAN_XOA(b_ma); return ""; }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message); }
    }
    #endregion

    #region Giao việc + Đánh giá
    [WebMethod(true)]
    public string Fs_NS_TS_TT_NH(string b_login,string b_dk, string b_so_id, string b_trang_thai)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ts_gv.P_NS_TS_TT_NH(b_so_id, b_trang_thai);

            DataTable b_dt = ns_ts_gv.P_NS_TS_TT_CV(b_so_id);
            string b_danhan = "";
            if (b_dt != null && b_dt.Rows.Count > 0) {
                b_danhan = "\n Mã vụ việc: " + b_dt.Rows[0]["MA_DU_AN"].ToString();
                b_danhan = b_danhan + "\n Tên công việc: " + b_dt.Rows[0]["CV"].ToString();
            }
            DataTable b_mail = ns_ts_gv.P_NS_TS_GV_EMAIL(b_so_id);
            string b_dieukien = "";
            if (b_dk == "CDG")
            {
                b_dieukien = "đã kết thúc.";
            }else
                b_dieukien = "đã được nhận.";
            if (b_mail.Rows.Count > 0)
            {
                se.se_nsd b_se = new se.se_nsd();
                string b_toAddress = chuyen.OBJ_S(b_mail.Rows[0]["email_giao"]);
                string b_subject = "[HỆ THỐNG QUẢN LÝ CÔNG VIỆC] Thông Báo";
                string b_body = "Công việc bạn giao cho " + b_se.ten + b_dieukien + b_danhan + "\nVui lòng đăng nhập vào chương trình http://ts.cerp.vn để xem lại! \n";
                SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    } 
    [WebMethod(true)]
    public string Fs_NS_TS_GV_NH(string b_login, string b_so_id, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            bang.P_CSO_SO(ref b_dt, "TONG_GIO_LSX");

            DataTable b_dt2 = ns_ts_dg.Fdt_NS_TS_HOI_TONGIO(b_so_id, b_dt);

            if (b_dt2 != null && b_dt2.Rows.Count > 0 && int.Parse(b_dt2.Rows[0]["TONGGIO"].ToString()) > 0)
            {
                return Thongbao_dch.tonggioLonHonTongGio_LSX;
            }
            string b_ten_nd = "\n Tên công việc: " + b_dt.Rows[0]["nd"].ToString().Replace("N'", "");
            string b_ma_vv = "\n Mã Vụ việc: " + b_dt.Rows[0]["MA_DU_AN"].ToString();

            ns_ts_gv.P_NS_TS_GV_NH(ref b_so_id, b_dt);
            DataTable b_mail = ns_ts_gv.P_NS_TS_GV_EMAIL(b_so_id);
            if (b_mail.Rows.Count > 0)
            {
                string b_toAddress = chuyen.OBJ_S(b_mail.Rows[0]["email_nhan"]);
                string b_subject = "[HỆ THỐNG QUẢN LÝ CÔNG VIỆC] Thông Báo";                                
                string b_body = "Bạn có công việc cần nhận: " + b_ma_vv + b_ten_nd + "\nVui lòng đăng nhập v/ppkào chương trình http://ts.cerp.vn để nhận! \n";
                SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            return b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
     [WebMethod(true)]
    public static DataTable P_NS_TS_GV_KT()
    {
        try
        { 
            return null;
        }
        catch (Exception ex) { return null; }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_LKE(string b_login, string b_so_id, string p_path, string b_loai, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            DataTable b_dt_se = new DataTable();
            se.P_LOGIN(b_login);
            try
            {
                b_dt_se = se.Fdt_KQ_TRA("file", "file");
                if (b_dt_se == null)
                {
                    b_dt_se = new DataTable(); b_dt_se.Columns.Add("id", typeof(string)); b_dt_se.Columns.Add("path", typeof(string));
                }
                if (b_loai.Trim() == "+") bang.P_THEM_HANG(ref b_dt_se, new object[] { b_so_id, p_path }, 0);
                if (b_loai.Trim() == "-")
                {
                    for (int i = b_dt_se.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = b_dt_se.Rows[i];
                        if (dr["id"].ToString() == b_so_id && dr.RowState != DataRowState.Deleted) dr.Delete();
                        if (dr.RowState != DataRowState.Deleted && dr["path"].ToString().Contains(b_so_id)) dr.Delete();
                    }
                }
                se.P_KQ_LUU("file", "file", b_dt_se);
            }
            catch { }
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_dong = "";
            DataTable b_kq = ns_ts_gv.Fdt_NS_TS_GV_LKE(b_dt, b_dt_se, a_tso[0], a_tso[1], ref b_dong);
            return chuyen.OBJ_S(b_dong) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_CT(string b_login, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts_gv.Fdt_NS_TS_GV_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_XOA(string b_login, string b_so_id, string b_path, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            string b_loai = "-";
            se.P_LOGIN(b_login);
            ns_ts_gv.P_NS_TS_GV_XOA(b_so_id);
            return Fs_NS_TS_GV_LKE(b_login, b_so_id, b_path, b_loai, a_dt, a_cot_gt, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_DG_NH(string b_login, string b_id_cv, string b_so_id, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);


            //DataTable b_dt2 = ns_ts_dg.Fdt_NS_TS_HOI_TONGIO2(b_so_id,b_id_cv);

            //if (b_dt2 != null && b_dt2.Rows.Count > 0 && int.Parse(b_dt2.Rows[0]["TONGGIO"].ToString()) > 0)
            //{
            //    return Thongbao_dch.tonggioLonHonTongGio_LSX;
            //}


            ns_ts_dg.P_NS_TS_DG_NH(b_id_cv, ref b_so_id, b_dt);
            return b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_DG_ID(string b_login, string b_so_id, string b_id_cv, object[] a_dt, double b_TrangKt, string[] a_cot_gt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            object[] a_obj = ns_ts_dg.Faobj_NS_TS_DG_ID(b_id_cv, b_so_id, b_dt_tk, b_TrangKt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_DG_LKE(string b_login, string b_id_cv, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts_dg.Fdt_NS_TS_DG_LKE(b_id_cv, b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_DG_CT(string b_login, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts_dg.Fdt_NS_TS_DG_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_DG_XOA(string b_login, string b_so_id, string b_id_cv, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ts_dg.P_NS_TS_DG_XOA(b_so_id);
            return Fs_NS_TS_DG_LKE(b_login, b_id_cv, a_dt, a_cot_gt, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_TC(string b_login, string b_so_id, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_dt2 = ns_ts_gv.P_NS_TS_TT_CV(b_so_id);
            string b_danhan = "";
            if (b_dt2 != null && b_dt2.Rows.Count > 0) {
                b_danhan = "\n Mã vụ việc: " + b_dt2.Rows[0]["MA_DU_AN"].ToString();
                b_danhan = b_danhan + "\n Tên công việc: " + b_dt2.Rows[0]["CV"].ToString();
            }
            ns_ts_gv.P_NS_TS_GV_TC(b_so_id, b_dt);

            DataTable b_mail = ns_ts_gv.P_NS_TS_GV_EMAIL(b_so_id);
            if (b_mail.Rows.Count > 0)
            {
                se.se_nsd b_se = new se.se_nsd();
                string b_toAddress = chuyen.OBJ_S(b_mail.Rows[0]["email_giao"]);
                string b_subject = "[HỆ THỐNG QUẢN LÝ CÔNG VIỆC] Thông Báo";
                string b_body = "Công việc bạn giao bị từ chối bởi " + b_se.ten + "!." + b_danhan + " \nVui lòng đăng nhập vào chương trình http://ts.cerp.vn để xem lại! \n";
                SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            }
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_BACK(string b_login, string b_so_id, string b_path, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            string b_loai = "-";
            se.P_LOGIN(b_login);
            ns_ts_gv.P_NS_TS_GV_BACK(b_so_id);
            return Fs_NS_TS_GV_LKE(b_login, b_so_id, b_path, b_loai, a_dt, a_cot_gt, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_GV_DC(string b_login, string b_so_id_tu, string b_so_id_den, string b_path, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            string b_loai = "-";
            se.P_LOGIN(b_login);
            ns_ts_gv.P_NS_TS_GV_DC(b_so_id_tu, b_so_id_den);
            return Fs_NS_TS_GV_LKE(b_login, b_so_id_tu, b_path, b_loai, a_dt, a_cot_gt, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_GV_LKE_ID(string b_login, string b_so_id, object[] a_dt, double b_TrangKt, string[] a_cot_gt)
    {
        try
        {
            DataTable b_dt_se = new DataTable();
            b_dt_se = se.Fdt_KQ_TRA("file", "file");
            if (b_dt_se == null)
            {
                b_dt_se = new DataTable();
                b_dt_se.Columns.Add("id", typeof(string));
                b_dt_se.Columns.Add("path", typeof(string));
                bang.P_THEM_HANG(ref b_dt_se, new object[] { 0, "" }, 0);
            }
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string b_dong = "", b_trang = "";
            DataTable b_dt = ns_ts_gv.Faobj_NS_TS_GV_LKE_ID(b_so_id, b_dt_tk, b_dt_se, b_TrangKt, ref b_trang, ref b_dong);
            int b_hang = bang.Fi_TIM_ROW(b_dt, "id", b_so_id) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(b_trang) + "#" + chuyen.OBJ_S(b_dong) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion
    #region Nhập timesheet
    [WebMethod(true)]
    public string Fs_NS_TS_NH(string b_id_cv, string b_so_id, object[] a_dt)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts.P_NS_TS_NH(b_id_cv, ref b_so_id, b_dt);
            return b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_LKE(string b_login, string b_id_cv, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts.Fdt_NS_TS_LKE(b_id_cv, b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_LKE_HT(string b_login, string b_id_cv)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_kq = ns_ts.Fdt_NS_TS_LKE_HT(b_id_cv);
            if (b_kq.Rows.Count > 0)
            {
                return b_kq.Rows[0]["kq"].ToString();
            }
            else return "0";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }



    [WebMethod(true)]
    public string Fs_NS_TS_CT(string b_login, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts.Fdt_NS_TS_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_XOA(string b_login, string b_so_id, string b_id_cv, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ts.P_NS_TS_XOA(b_so_id);
            return Fs_NS_TS_LKE(b_login, b_id_cv, a_dt, a_cot_gt, a_tso);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_ID(string b_login, string b_so_id, string b_id_cv, object[] a_dt, double b_TrangKt, string[] a_cot_gt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt_tk = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            object[] a_obj = ns_ts.Faobj_NS_TS_ID(b_id_cv, b_so_id, b_dt_tk, b_TrangKt);
            DataTable b_dt = (DataTable)a_obj[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "so_id", b_so_id) + 1;
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_obj[0]) + "#" + chuyen.OBJ_S(a_obj[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion
    [WebMethod(true)]
    public string Fs_NS_TS_QL_LKE(string b_login, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts_gv.Fdt_NS_TS_QL_LKE(b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #region "MANDAY DỰ TRỮ"
    [WebMethod(true)]
    public string Fs_NS_TS_PHONG_KHOI_LKE(string b_login, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts_gv.Fdt_NS_TS_PHONG_KHOI_LKE(b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[2];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt) + "#" + chuyen.OBJ_S(a_obj[1]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_NS_TS_PHONG_KHOI2_LKE(string b_login, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts_gv.Fdt_NS_TS_PHONG_KHOI2_LKE(b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[2];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt) + "#" + chuyen.OBJ_S(a_obj[1]);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion
    #region MÃ LOẠI NGẠCH

    [WebMethod(true)]
    public string Fs_TS_MA_LOAI_CV_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ts.Fdt_TS_MA_LOAI_CV_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TS_MA_LOAI_CV_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ts.Fdt_TS_MA_LOAI_CV_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_MA_LOAI_CV_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts.P_TS_MA_LOAI_CV_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TS_MA_LOAI_CV_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_MA_LOAI_CV_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ts.P_TS_MA_LOAI_CV_XOA(b_ma); return Fs_TS_MA_LOAI_CV_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH
    #region MÃ LOẠI NGẠCH

    [WebMethod(true)]
    public string Fs_TS_DO_UU_TIEN_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ts.Fdt_TS_DO_UU_TIEN_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TS_DO_UU_TIEN_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ts.Fdt_TS_DO_UU_TIEN_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_DO_UU_TIEN_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts.P_TS_DO_UU_TIEN_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TS_DO_UU_TIEN_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_DO_UU_TIEN_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ts.P_TS_DO_UU_TIEN_XOA(b_ma); return Fs_TS_DO_UU_TIEN_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH
    #region MÃ LOẠI NGẠCH

    [WebMethod(true)]
    public string Fs_TS_VI_TRI_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ts.Fdt_TS_VI_TRI_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TS_VI_TRI_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ts.Fdt_TS_VI_TRI_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_VI_TRI_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts.P_TS_VI_TRI_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TS_VI_TRI_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_VI_TRI_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ts.P_TS_VI_TRI_XOA(b_ma); return Fs_TS_VI_TRI_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH
    #region MÃ LOẠI NGẠCH

    [WebMethod(true)]
    public string Fs_TS_SKILL_LKE(double[] a_tso, string[] a_cot)
    {
        try
        {
            double b_tu_n = chuyen.OBJ_N(a_tso[0]), b_den_n = chuyen.OBJ_N(a_tso[1]);
            object[] a_object = ns_ts.Fdt_TS_SKILL_LKE(b_tu_n, b_den_n); ;
            DataTable b_dt = (DataTable)a_object[1];
            return chuyen.OBJ_S(a_object[0]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    [WebMethod(true)]
    public string Fs_TS_SKILL_MA(string b_ma, double b_trangkt, string[] a_cot)
    {
        try
        {
            object[] a_object = ns_ts.Fdt_TS_SKILL_MA(b_ma, b_trangkt);
            DataTable b_dt = (DataTable)a_object[2];
            int b_hang = bang.Fi_TIM_ROW(b_dt, "ma", b_ma);
            return b_hang.ToString() + "#" + chuyen.OBJ_S(a_object[0]) + "#" + chuyen.OBJ_S(a_object[1]) + "#" + bang.Fs_BANG_CH(b_dt, a_cot);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_SKILL_NH(double b_trangKT, object[] a_dt_ct, string[] a_cot_lke)
    {
        try
        {
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]);
            object[] a_gtri = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts.P_TS_SKILL_NH(b_dt_ct);
            string b_ma = mang.Fs_TEN_GTRI("ma", a_cot, a_gtri);
            return Fs_TS_SKILL_MA(b_ma, b_trangKT, a_cot_lke);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_TS_SKILL_XOA(string b_ma, double[] a_tso, string[] a_cot)
    {
        try { ns_ts.P_TS_SKILL_XOA(b_ma); return Fs_TS_SKILL_LKE(a_tso, a_cot); }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
    #endregion MĂ LOẠI NGẠCH


    [WebMethod(true)]
    public string Fs_NS_TS_KHOACH_LKE(string b_login, object[] a_dt, string[] a_cot_gt, double[] a_tso)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            var a_obj = ns_ts_gv.Fdt_NS_TS_KHOACH_LKE(b_dt, (double)a_tso[0], (double)a_tso[1]);
            DataTable b_kq = (DataTable)a_obj[1];
            return chuyen.OBJ_S(a_obj[0]) + "#" + bang.Fs_BANG_CH(b_kq, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_TIMKIEM_LKE(string b_login, object[] a_dt, string[] a_cot_gt, object[] a_dt_ct)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ma", "");
            if (b_dt_ct.Rows.Count == 0) bang.P_THEM_HANG(ref b_dt_ct, new object[] { "-1", "", "", "" });
            DataTable b_kq = ns_ts_gv.Fdt_NS_TS_TIMKIEM_LKE(b_dt, b_dt_ct);
            bang.P_SO_CNG(ref b_kq, "ngay_dk_ht");
            return bang.Fs_BANG_CH(b_kq, a_cot_gt) + "#" + b_kq.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_BOOKNS_LKE(string b_login, object[] a_dt, string[] a_cot_gt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]);
            object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            DataTable b_kq = ns_ts_gv.Fdt_NS_TS_BOOKNS_LKE(b_dt);
            bang.P_SO_CNG(ref b_kq, "ngay_dk_ht");
            bang.P_THAY_GTRI(ref b_kq, "tt_giao", "CXN", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_kq, "tt_giao", "XN", "Xác nhận");
            bang.P_THAY_GTRI(ref b_kq, "tt_giao", "TC", "Hủy bỏ");

            bang.P_THAY_GTRI(ref b_kq, "tt_nhan", "CXN", "Chưa xác nhận");
            bang.P_THAY_GTRI(ref b_kq, "tt_nhan", "XN", "Xác nhận");
            bang.P_THAY_GTRI(ref b_kq, "tt_nhan", "TC", "Từ chối");
            return bang.Fs_BANG_CH(b_kq, a_cot_gt) + "#" + b_kq.Rows.Count.ToString();
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_BOOK_NH(string b_so_id_cv, object[] a_dt_ct)
    {
        try
        {
            string[] a_cot_ct = chuyen.Fas_OBJ_STR((object[])a_dt_ct[0]); object[] a_gtri_ct = (object[])a_dt_ct[1];
            DataTable b_dt_ct = bang.Fdt_TAO_THEM(a_cot_ct, a_gtri_ct); bang.P_BO_HANG(ref b_dt_ct, "ng_nhan", "");
            ns_ts_gv.P_NS_TS_BOOK_NH(b_so_id_cv, b_dt_ct);
            return "";
        }
        catch (Exception ex)
        {
            return form.Fs_LOC_LOI(ex.Message );
        }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_BOOK_CT(string b_login, string b_so_id, string[] a_cot_gt)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts_gv.Fdt_NS_TS_BOOK_CT(b_so_id);
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_BANG_CH(b_dt, a_cot_gt);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }



    [WebMethod(true)]
    public string Fs_NS_TS_BOOKNS_NH(string b_login, string b_so_id, object[] a_dt)
    {
        try
        {
            se.P_LOGIN(b_login);
            string[] a_cot = chuyen.Fas_OBJ_STR((object[])a_dt[0]); object[] a_gtri = (object[])a_dt[1];
            DataTable b_dt = bang.Fdt_TAO_THEM(a_cot, a_gtri);
            ns_ts_gv.P_NS_TS_BOOKNS_NH(ref b_so_id, b_dt);
            //DataTable b_mail = ns_ts_gv.P_NS_TS_GV_EMAIL(b_so_id);
            //if (b_mail.Rows.Count > 0)
            //{
            //    string b_toAddress = chuyen.OBJ_S(b_mail.Rows[0]["email_nhan"]);
            //    string b_subject = "[HỆ THỐNG QUẢN LÝ CÔNG VIỆC] Thông Báo";
            //    string b_body = "Bạn có công việc cần nhận. \nVui lòng đăng nhập vào chương trình http://ts.cerp.vn để nhận! \n";
            //    SmtpMail.SendMail(b_toAddress, b_subject, b_body);
            //}
            return b_so_id;
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_BOOKNS_CT(string b_login, string b_so_id)
    {
        try
        {
            se.P_LOGIN(b_login);
            DataTable b_dt = ns_ts_gv.Fdt_NS_TS_BOOKNS_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, "tu_ngay,toi_ngay");
            return (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }

    [WebMethod(true)]
    public string Fs_NS_TS_BOOKNS_XACNHAN(string b_login, string b_so_id, string b_xacnhan)
    {
        try
        {
            se.P_LOGIN(b_login);
            ns_ts_gv.Fdt_NS_TS_BOOKNS_XACNHAN(b_so_id, b_xacnhan);
            return "";
        }
        catch (Exception ex) { return form.Fs_LOC_LOI(ex.Message ); }
    }
}
