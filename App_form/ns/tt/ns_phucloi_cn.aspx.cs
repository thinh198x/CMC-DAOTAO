using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_phucloi_cn : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_phucloi_cn" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s); 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_phucloi_cn_P_KD('');", true);
                SO_THE.Focus();
                P_Phong_DR();
                P_PHUCLOI_DR();
                //loadYear(); 
                //loadMonth();               
                //nam.SelectedIndex = 0;
                //kyluong.SelectedIndex = 0;
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_Phong_DR()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NS_PHUCLOI_CN_DVI", b_dt);
    }
    private void P_PHUCLOI_DR()
    {
        DataTable b_dt = ns_ma.Fdt_NS_MA_PHUCLOI_DR();
        se.P_TG_LUU("ns_phucloi_cn", "NS_PHUCLOI_CN_PL", b_dt);
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_tt.Fdt_NS_PHUCLOI_CN_LKE_ALL(ma_phong.Value, so_the_tk.Text.Trim(), hoten_tk.Text.Trim());
            bang.P_SO_CNG(ref b_dt, "ngay_tt");
            bang.P_SO_CSO(ref b_dt, "sotien");
            bang.P_COPY_COL(ref b_dt, "luong_chiuthue", "is_tinhluong");
            bang.P_COPY_COL(ref b_dt, "luong_khongchiuthue", "is_tinhluong");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "0", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "2", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_chiuthue", "1", "X");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "0", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "1", "");
            bang.P_THAY_GTRI(ref b_dt, "luong_khongchiuthue", "2", "X");           

            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_phucloi_cn.xlsx", b_dt, null, "PhucLoiCaNhan");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    /*
    private void loadYear()
    {
        DataTable b_dt3 = hts_dungchung.Fdt_MA_KYLUONG_NAM();
        nam.DataSource = b_dt3;
        nam.DataBind();
        nam.SelectedValue = DateTime.Now.Year.ToString();
    }
    private void loadMonth()
    {
        var ithang = "";
        var ngay_bd = "";
        var ngay_kt = "";
        var iNam = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(nam.SelectedValue))
        {
            iNam = chuyen.OBJ_I(nam.SelectedValue);
        }

        DataTable b_dt2 = hts_dungchung.Fdt_MA_KYLUONG(iNam);
        bang.P_SO_CNG(ref b_dt2, "ngay_bd,ngay_kt");
        kyluong.DataSource = b_dt2;

        kyluong.DataBind();
        if (b_dt2.Rows.Count > 0)
        {
            kyluong.DataSource = b_dt2;
        }
        if (b_dt2.Select("SHOW = 1").Length > 0)
        {
            ithang = b_dt2.Select("SHOW = 1")[0]["SO_ID"].ToString();
            ngay_bd = b_dt2.Select("SHOW = 1")[0]["NGAY_BD"].ToString();
            ngay_kt = b_dt2.Select("SHOW = 1")[0]["NGAY_KT"].ToString();
        }
        if (!string.IsNullOrEmpty(ithang))
        {
            kyluong.SelectedValue = ithang;
        }
    }
    */
}
