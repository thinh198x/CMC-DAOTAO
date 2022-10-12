using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tl_bluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/tl/ns_tl_bluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_tl_bluong_P_KD();", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KY", null);
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(akyluong.Value)) form.P_LOI(this, "Vui lòng chọn kỳ lương");
            DataSet b_ds = tl_ch.Fdt_NS_TL_BLUONG_EXCEL(aphong.Value, akyluong.Value, so_the_tk.Text);
            DataTable b_dt = new DataTable(); DataTable b_dt_tk = new DataTable();
            DataTable b_dt_title = new DataTable();
            b_dt = b_ds.Tables[0]; b_dt_tk = b_ds.Tables[1]; b_dt_title = b_ds.Tables[2];
            b_dt.TableName = "DATA";
            b_dt_tk.TableName = "DATA_TK";
            b_dt_title.TableName = "DATA_TITLE";
            bang.P_SO_CNG(ref b_dt, "NGAY_VAO,NGAYD,NGAYC,NGAY_NGHI");
            bang.P_SO_CNG(ref b_dt_tk, "NGAYD,NGAYC");
            bang.P_SO_CNG(ref b_dt_title, "TU_NGAY,DEN_NGAY");
            DataSet b_ds_in = new DataSet();
            b_ds_in.Tables.Add(b_dt.Copy());
            b_ds_in.Tables.Add(b_dt_tk.Copy());
            b_ds_in.Tables.Add(b_dt_title.Copy());
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_bluong_th.xlsx", b_ds_in, null, "bang_luong_tong_hop");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}