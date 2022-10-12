using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_qd_xl_dg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/dm/tl_qd_xl_dg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_qd_xl_dg_P_KD();", true);
                //NGAYHIEULUC.Focus();
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Đơn vị tìm kiếm
        DataTable b_dt = dg.Fdt_NHOM_CDANH_DR();
        se.P_TG_LUU(this.Title, "DT_NCD", b_dt.Copy());

        //lấy năm
        //DataRow drRow;
        DataTable b_dt1 = sdg.Fdt_DG_DM_MA_KDG_NAM();
        //drRow = b_dt1.NewRow();
        //drRow["NAM"] = "0";
        //drRow["NAM"] = "";
        //b_dt1.Rows.InsertAt(drRow, 0);
        //form.P_DROP_BANG(NAM, b_dt1);

        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1); 

        // Nhom tieu chi
        DataTable b_dt2 = dg.Fdt_NS_DG_MA_TCHI_LKE_TATCA();
        bang.P_BO_COT(ref b_dt2, new string[] {"ma_dvi","tt","gchu","ng_bdau","ng_kthuc","ngay_nh","nsd","idvung","sott","ma","ten"});
        bang.P_DOI_TENCOL( ref b_dt2,"ma_nhom","ma");
        bang.P_DOI_TENCOL(ref b_dt2, "ma_nhom_ten", "ten");
        se.P_TG_LUU(this.Title, "DT_NTC", b_dt2);

        //Chi tieu
        DataTable dtbChitieu = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" },"SS");
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "0", "" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "1", "Không đạt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "2", "Cần cải tiến" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "3", "Đạt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "4", "Tốt" });
        bang.P_THEM_HANG(ref dtbChitieu, new object[] { "5", "Xuất sắc" });
        se.P_TG_LUU(this.Title, "DT_CHITIEU", dtbChitieu);

        //Xeploai
        //DataTable dtbXeploai = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "SS");
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "0", "" });
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "1", "Không đạt" });
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "2", "Cần cải tiến" });
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "3", "Đạt" });
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "4", "Tốt" });
        //bang.P_THEM_HANG(ref dtbXeploai, new object[] { "5", "Xuất sắc" });
        //se.P_TG_LUU(this.Title, "DT_CHITIEU", dtbXeploai);


    }
    //protected void excel_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable b_dt = ns_td.Fdt_tl_qd_xl_dg_EXPORT();
    //        b_dt.TableName = "DATA";
    //        bang.P_SO_CNG(ref b_dt, "ngaycan_ns");
    //        Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_qd_xl_dg.xlsx", b_dt, null, "Chuc_danh_kiem_nhiem");
    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}


    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_object = dg.Faobj_TL_QD_XL_DG_LKE(0, 0);
            DataTable b_dt = (DataTable)a_object[1]; bang.P_SO_CNG(ref b_dt, "ngay_ad"); ;
            b_dt.TableName = "DATA";
            //bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            //bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG, NHOM_CHUCNANG.THIET_LAP, THAOTAC.EXPORT_EXCEL, TEN_FORM.TL_QD_XL_DG, TEN_BANG.TL_QD_XL_DG);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/tl_qd_xl_dg.xlsx", b_dt, null, "Danh_sach tieu chi danh gia theo chuc danh");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}