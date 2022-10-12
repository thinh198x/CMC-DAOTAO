using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_cc_tonghop_may : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_tonghop_may" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_tonghop_may_P_KD();", true);
                loadYear(); P_NHAN_DROP(); loadMonth();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
    private void loadYear()
    {
        DataTable b_dt3 = hts_dungchung.Fdt_MA_KYLUONG_NAM();
        NAM.DataSource = b_dt3;
        NAM.DataBind();
        NAM.SelectedValue = DateTime.Now.Year.ToString();
    }
    private void loadMonth()
    {
        var ithang = "";
        var ngay_bd = "";
        var ngay_kt = "";
        var iNam = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(NAM.SelectedValue))
        {
            iNam = chuyen.OBJ_I(NAM.SelectedValue);
        }

        DataTable b_dt2 = hts_dungchung.Fdt_MA_KYLUONG(iNam);
        bang.P_SO_CNG(ref b_dt2, "ngay_bd,ngay_kt");
        KYLUONG.DataSource = b_dt2;

        KYLUONG.DataBind();
        if (b_dt2.Rows.Count > 0)
        {
            KYLUONG.DataSource = b_dt2;
        }
        if (b_dt2.Select("SHOW = 1").Length > 0)
        {
            ithang = b_dt2.Select("SHOW = 1")[0]["SO_ID"].ToString();
            ngay_bd = b_dt2.Select("SHOW = 1")[0]["NGAY_BD"].ToString();
            ngay_kt = b_dt2.Select("SHOW = 1")[0]["NGAY_KT"].ToString();
        }
        if (!string.IsNullOrEmpty(ithang))
        {
            KYLUONG.SelectedValue = ithang; 
        }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = null;// tl_cc.Fdt_CC_TONGHOP_MAY_EXCEL(PHONG.SelectedValue, KYLUONG.SelectedValue, so_the.Text);

            DataTable b_dt = b_ds.Tables[0];

            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_lv");
             
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_tonghop_may.xlsx", b_ds, null, "Dulieu_congmay");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}