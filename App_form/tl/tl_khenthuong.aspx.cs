using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_tl_khenthuong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/tl_khenthuong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_khenthuong_P_KD();", true);
            //SO_THE.Focus();
            //P_NHAN_DROP();
        }
    }
    private void P_NHAN_DROP()
    {
        // phòng ban
        //DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        //form.P_DROP_BANG(phong_tk, b_dt);

        //// năm
        //b_dt = hts_dungchung.Fdt_MA_KYLUONG_NAM();
        //nam_tk.DataSource = b_dt;
        //nam_tk.DataBind();
        //nam_tk.SelectedValue = DateTime.Now.Year.ToString();

        //// kỳ lương tìm kiếm
        //var iNamtk = DateTime.Now.Year;
        //if (!string.IsNullOrEmpty(nam_tk.SelectedValue))
        //{
        //    iNamtk = chuyen.OBJ_I(nam_tk.SelectedValue);
        //}
        //b_dt = hts_dungchung.Fdt_MA_KYLUONG(iNamtk);
        //bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
        //form.P_DROP_BANG(kyluong_tk, b_dt);

        //// ky lương
        //var iNam = DateTime.Now.Year;
        //b_dt = hts_dungchung.Fdt_MA_KYLUONG(iNam);
        //bang.P_SO_CNG(ref b_dt, "ngay_bd,ngay_kt");
        //form.P_DROP_BANG(KYLUONGID, b_dt);

    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            //string a_phong = phong_tk.SelectedValue;
            //string a_ten = ten_tk.Text.ToString();
            //string a_kyluong = kyluong_tk.SelectedValue;

            //DataTable b_dt = tl_ch.Fdt_GIULUONG_LKE_ALL(a_phong, a_ten, a_kyluong, 1, 10000);
            //bang.P_SO_CNG(ref b_dt, "NGAY_THANHTOAN");
            //b_dt.TableName = "DATA";
            //Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_khenthuong.xlsx", b_dt, null, "Danh sách giữ lương");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
