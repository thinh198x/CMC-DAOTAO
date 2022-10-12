using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;
using System.Globalization;

public partial class f_ns_ngbc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bc/sbc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/bc/ns/ns_ngbc.js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                b_s = "ns_ngbc_P_KD('" + Fs_thumuc() + "','" + chon_in.ClientID + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);

                loadYear(); P_NHAN_DROP(); loadMonth();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
    private void P_NHAN_DROP()
    {
        // loại báo cáo
        DataTable b_dt = bc.Fdt_LOAI_SL_XEM("C", "K");
        se.P_TG_LUU(this.Title, "DT_LOAI_SL", b_dt);

        // lấy đơn vị
        b_dt = ht_madvi.Fdt_MA_DVI_XEM();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_DON_VI", b_dt);

        // Lấy phòng ban
        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);

        //lấy đối tượng đánh giá 360 độ
        b_dt = dg.Fdt_DG_DM_MA_DTUONG_DG();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_DTUONG", b_dt);

        // Lấy năm theo kỳ công lương
        b_dt = ht_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM1", b_dt.Copy());
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt.Copy());

        //lấy năm theo kỳ đánh giá kpi
        b_dt = sdg.Fdt_DG_DM_MA_KDG_NAM();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM_KPI", b_dt);

        //Lấy vị trí tuyển dụng
        b_dt = dg.Fdt_VITRI_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_VITRI", b_dt);

        // lấy khóa đào tạo
        b_dt = ns_dt.Fdt_NS_DT_DANHGIA_CL_KDT_DR(nam.Text);
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_KHOA", b_dt);

        // Phòng ban đơn vị
        //b_dt = ns_dt.Fdt_HT_MA_DVI_DR();
        //bang.P_THEM_TRANG(ref b_dt, 1, 0);
        //se.P_TG_LUU(this.Title, "DT_DVI", b_dt);
        // Tháng 
        b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
    }
    private void loadMonth()
    {
        string ithang = "";
        int iNam = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(nam.Text)) iNam = chuyen.OBJ_I(nam.Text);
        DataTable b_dt2 = hts_dungchung.Fdt_MA_KYLUONG(iNam); bang.P_SO_CNG(ref b_dt2, "ngay_bd,ngay_kt");
        se.P_TG_LUU(this.Title, "DT_KYLUONG", b_dt2.Copy());
        se.P_TG_LUU(this.Title, "DT_KYLUONG1", b_dt2.Copy());
        //if (b_dt2.Rows.Count > 0) { kyluong.DataSource = b_dt2; kyluong_c.DataSource = b_dt2; }
        //if (b_dt2.Select("SHOW = 1").Length > 0) ithang = b_dt2.Select("SHOW = 1")[0]["ma"].ToString();
        //if (!string.IsNullOrEmpty(ithang)) { kyluong.SelectedValue = ithang; kyluong_c.SelectedValue = ithang; }
    }
    private void loadYear()
    {
        DataTable b_dt3 = hts_dungchung.Fdt_MA_KYLUONG_NAM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt3.Copy());
        //nam.DataSource = b_dt3; nam.DataBind(); nam.SelectedValue = DateTime.Now.Year.ToString();
    }
}
