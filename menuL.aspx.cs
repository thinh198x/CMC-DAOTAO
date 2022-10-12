using System;
using System.Web.UI;
using Cthuvien;
using System.Data;
using System.Web;

public partial class f_menuL : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            bool b_log = false;
            try
            {
                b_log = khac.Fb_HOI_QU(this.Title);
                if (!b_log)
                {
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                    ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                    string b_s = this.ResolveUrl("~/menuL" + khac.Fs_runMode() + ".js"), b_tm = Fs_tm("D");
                    ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                    se.se_nsd b_se = new se.se_nsd();
                    b_s = "menu_KD('" + b_tm + "');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
                    tm.Value = b_tm; nsd.InnerText = b_se.ten + "/" + b_se.ma_goc;
                    DataTable b_dt = ht_madvi.Fdt_DVI_QLY();
                    bang.P_DON(ref b_dt, "ten");
                    form.P_DROP_BANG(qly_dvi, b_dt);

                    // linhnv thêm để mở nhiều tab 04/03/2021
                    DataTable b_dt_ttmh = khud.Fdt_NSD_TSO_LKE();
                    if (b_dt_ttmh.Rows.Count > 0) ttmh.Value = b_dt_ttmh.Rows[0]["modal"].ToString();
                    else ttmh.Value = "K";

                    qly_dvi.SelectedValue = b_se.ma_dvi;
                    b_log = khac.Fb_KTRA_QU(this.Title, "ctmenu", "GXDPIMAE");
                    b_log = true;
                }
                else b_log = false;
            }
            catch { b_log = false; }
            if (!b_log) Response.Redirect("~/login.aspx", false); 
            //TBAO_MENU();
        }
        catch (Exception ex) { form.P_LOI(this, ex.ToString()); }
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        string b_f = "~/App_form/ht/ht_bd_ns.aspx";
        this.ResolveUrl(b_f);
    }
    private string Fs_tm(string b_dk)
    {
        string b_f = "~/menu.aspx";
        string b_tm = (b_dk != "D") ? Server.MapPath(b_f) : this.ResolveUrl(b_f);
        return b_tm.Substring(0, b_tm.Length + 1 - b_f.Length);
    }

    private void TBAO_MENU()
    {
        int b_dem_thongbao = 0;
        DataTable dtb_sn = ns_tt.Fdt_MENU_TBAO_TB("", 10);
        string b_dem_sn = dtb_sn.Rows[0]["count_sn"].ToString();
        if (b_dem_sn != "0")
        {
            Lb_sn.Text = "Danh sách sinh nhật trong tháng : " + b_dem_sn;
            b_dem_thongbao = b_dem_thongbao + 1;
        }

        string b_dem_hd = dtb_sn.Rows[0]["count_hd"].ToString();
        if (b_dem_hd != "0")
        {
            Lb_hd.Text = "Danh sách sắp đến hạn hợp đồng : " + b_dem_hd;
            b_dem_thongbao = b_dem_thongbao + 1;
        }
        string b_dem_hs = dtb_sn.Rows[0]["count_hs"].ToString();
        if (b_dem_hs != "0")
        {
            lb_hs.Text = "Danh sách hết hạn nộp hồ sơ:  " + b_dem_hs;
            b_dem_thongbao = b_dem_thongbao + 1;
        }
        DataSet b_ds_cchn = ns_tt.Fdt_MENU_TBAO_CT_CCHN_EXCEL();
        DataTable b_dt_cchn = b_ds_cchn.Tables[0];
        string b_dem_cchn = b_dt_cchn.Rows.Count.ToString();
        if (b_dem_cchn != "0")
        {
            lb_cchn.Text = "Danh sách đủ điều kiện thi CCHN:  " + b_dem_cchn;
            b_dem_thongbao = b_dem_thongbao + 1;
        }
        string b_dem_con = dtb_sn.Rows[0]["count_con"].ToString();
        if (b_dem_con != "0")
        {
            lb_con.Text = "Danh sách con hết giảm trừ : " + b_dem_con;
            b_dem_thongbao = b_dem_thongbao + 1;
        }
        dem_thongbao.InnerText = b_dem_thongbao.ToString();

        string b_dem_hc = dtb_sn.Rows[0]["count_hc"].ToString();
        Lb_hc.Text = "Số nhân viên hết hạn hộ chiếu:  " + b_dem_hc;
        string b_dem_cmt = dtb_sn.Rows[0]["count_cmt"].ToString();
        Lb_cmt.Text = "Số nhân viên hết chứng minh thư:  " + b_dem_cmt;
        string b_dem_qd = dtb_sn.Rows[0]["count_qd"].ToString();
        Lb_qd.Text = "Nhân viên sắp hết hạn quyết định :  " + b_dem_qd;
        string b_dem_visa = dtb_sn.Rows[0]["count_visa"].ToString();
        lb_vs.Text = "Số nhân viên sắp hết hạn visa:  " + b_dem_visa;
        string b_dem_td = dtb_sn.Rows[0]["count_td"].ToString();
        lb_td.Text = "Bạn đang có yêu cầu TD:  " + b_dem_td;


        //string b_dem_tong = dtb_sn.Rows[0]["count_tong_ns"].ToString();
        //lb_tong.Text = "Tổng số nhân viên hiện tại:  " + b_dem_tong;
        //string b_dem_tuyenmoi = dtb_sn.Rows[0]["count_tuyenmoi"].ToString();
        //lb_tm.Text = "Nhân sự tuyển mới trong tháng:  " + b_dem_tuyenmoi;

        //string b_dem_nghiviec = dtb_sn.Rows[0]["count_nghiviec"].ToString();
        //lb_nghi.Text = "Nhân sự nghỉ việc trong tháng:  " + b_dem_nghiviec;
        //string b_dem_caocap = dtb_sn.Rows[0]["count_caocap"].ToString();
        //ld_caocap.Text = "Số lượng nhân sự cao cấp:  " + b_dem_caocap;
        //string b_dem_captrung = dtb_sn.Rows[0]["count_captrung"].ToString();
        //ld_captrung.Text = "Số lượng nhân sự cấp trung:  " + b_dem_captrung;

        //string b_dem_chuyendi = dtb_sn.Rows[0]["count_chuyendi"].ToString();
        //lb_chuyendi.Text = "Nhân sự chuyển đi trong tháng:  " + b_dem_chuyendi;
        //string b_dem_chuyenden = dtb_sn.Rows[0]["count_chuyenden"].ToString();
        //lb_chuyenden.Text = "Nhân sự chuyển đến trong tháng:  " + b_dem_chuyenden;
        //string b_dem_tuoi = dtb_sn.Rows[0]["count_tuoi"].ToString();
        //lb_bq.Text = "Độ tuổi bình quân:  " + b_dem_tuoi;

    }
}
