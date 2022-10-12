using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ht_bd_ns : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ht/ht_bd_ns" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_thongbao_P_KD();", true);
                P_NHAN_DROP(); TBAO_MENU();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        var dt = new System.Data.DataTable("data");
        dt.Columns.Add("ma", typeof(string));
        dt.Columns.Add("ten", typeof(string));
        DataRow row;
        for (int i = 1; i < 13; i++)
        {
            row = dt.NewRow();
            if (i < 10)
            {
                row[0] = DateTime.Now.Year.ToString() + "0" + i.ToString();
                row[1] = "Tổng hợp biến động nhân sự tháng 0" + i.ToString() + "/" + DateTime.Now.Year.ToString();
            }
            else
            {
                row[0] = DateTime.Now.Year.ToString() + i.ToString();
                row[1] = "Tổng hợp biến động nhân sự tháng " + i.ToString() + "/" + DateTime.Now.Year.ToString();
            }
            dt.Rows.Add(row);
        }
        loai_bd.DataSource = dt; loai_bd.DataBind();
        loai_bd.SelectedValue = DateTime.Now.Year.ToString() + "0" + DateTime.Now.Month.ToString();
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
       // PHONG.DataSource = b_dt; PHONG.DataBind();
    }
    private void TBAO_MENU()
    {
        DataTable dtb_sn = ns_tt.Fdt_MENU_TBAO_TB("", 10);
        string b_dem_sn = dtb_sn.Rows[0]["count_sn"].ToString();
        Lb_sn.Text = "Danh sách sinh nhật : " + b_dem_sn;
        string b_dem_hd = dtb_sn.Rows[0]["count_hd"].ToString();
        Lb_hd.Text = "Hết hạn hợp đồng : " + b_dem_hd;
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
        string b_dem_tong = dtb_sn.Rows[0]["count_tong_ns"].ToString();
        lb_tong.Text = "Tổng số nhân viên hiện tại:  " + b_dem_tong;
        string b_dem_tuyenmoi = dtb_sn.Rows[0]["count_tuyenmoi"].ToString();
        lb_tm.Text = "Nhân sự tuyển mới trong tháng:  " + b_dem_tuyenmoi;
        string b_dem_hs = dtb_sn.Rows[0]["count_hs"].ToString();
        lb_hs.Text = "Hết hạn nộp hồ sơ:  " + b_dem_hs;
        string b_dem_con = dtb_sn.Rows[0]["count_con"].ToString();
        lb_con.Text = "Danh sách con hết giảm trừ : " + b_dem_con;

        DataSet b_ds_cchn = ns_tt.Fdt_MENU_TBAO_CT_CCHN_EXCEL();
        DataTable b_dt_cchn = b_ds_cchn.Tables[0];
        string b_dem_cchn = b_dt_cchn.Rows.Count.ToString();
        lb_cchn.Text = "Danh sách đủ điều kiện thi CCHN:  " + b_dem_cchn;

        string b_dem_nghiviec = dtb_sn.Rows[0]["count_nghiviec"].ToString();
        lb_nghi.Text = "Nhân sự nghỉ việc trong tháng:  " + b_dem_nghiviec;
        string b_dem_caocap = dtb_sn.Rows[0]["count_caocap"].ToString();
        ld_caocap.Text = "Số lượng nhân sự cao cấp:  " + b_dem_caocap;
        string b_dem_captrung = dtb_sn.Rows[0]["count_captrung"].ToString();
        ld_captrung.Text = "Số lượng nhân sự cấp trung:  " + b_dem_captrung;

        string b_dem_chuyendi = dtb_sn.Rows[0]["count_chuyendi"].ToString();
        lb_chuyendi.Text = "Nhân sự chuyển đi trong tháng:  " + b_dem_chuyendi;
        string b_dem_chuyenden = dtb_sn.Rows[0]["count_chuyenden"].ToString();
        lb_chuyenden.Text = "Nhân sự chuyển đến trong tháng:  " + b_dem_chuyenden;
        string b_dem_tuoi = dtb_sn.Rows[0]["count_tuoi"].ToString();
        lb_bq.Text = "Độ tuổi bình quân:  " + b_dem_tuoi;

    }
}
