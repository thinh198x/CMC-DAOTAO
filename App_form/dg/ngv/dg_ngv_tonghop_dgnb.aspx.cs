using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_dg_ngv_tonghop_dgnb : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                string b_s = this.ResolveUrl("~/App_form/dg/ngv/dg_ngv_tonghop_dgnb" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "dg_ngv_tonghop_dgnb_P_KD();", true);
                NAM.Focus(); P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {  
        //lấy năm 
        DataTable b_dt1 = sdg.Fdt_DG_DM_MA_KDG_NAM(); 
        bang.P_THEM_TRANG(ref b_dt1, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt1);
    }
    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string b_nam = NAM.Text;
            DataSet b_ds = dg.Fdt_DG_NGV_TONGHOP_DGNB_LKE_ALL(b_nam);
            DataTable b_dt = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            bang.P_SO_CNG(ref b_dt, "ngay_vao");
            bang.P_CSO_SO(ref b_dt, "diem");
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DG360, NHOM_CHUCNANG.NGHIEP_VU, THAOTAC.EXPORT_EXCEL, TEN_FORM.DG_NGV_TONGHOP_DGNB, TEN_BANG.DG_NGV_TONGHOP_DGNB); 
            Excel_dungchung.ExportTemplate("Templates/ExportMau/dg_ngv_tonghop_dgnb.xlsx", b_dt, null, "Tong_hop_ket_qua_danh_gia_noi_bo");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}