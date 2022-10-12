using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;
public partial class f_ns_dt_ma_kdtao : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/dm/ns_dt_ma_kdtao" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_kdtao_P_KD();", true);
                NAM.Focus(); P_NHAP_DR();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAP_DR()
    {
        //DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_NAM();
        //bang.P_THEM_TRANG(ref b_dt, 1, 0);
        //se.P_TG_LUU(this.Title, "DT_NAMTK", b_dt.Copy());

        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_KDTTK", b_dt.Copy());

        b_dt = ns_dt.Fdt_NS_DT_MA_NND_DR();
        bang.P_THEM_TRANG(ref b_dt, 1, 0);
        se.P_TG_LUU(this.Title, "DT_NND", b_dt.Copy());

        se.P_TG_LUU(this.Title, "DT_NND_DV", null);

        //son
        b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();
        se.P_TG_LUU(this.Title, "DT_NCD", b_dt);
    }
    
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_EXCEL(chuyen.OBJ_N(nam_tk.Text), kdt_an.Value);
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "N", "Ngừng áp dụng");
            bang.P_THAY_GTRI(ref b_dt, "trangthai", "A", "Áp dụng");
            b_dt.TableName = "DATA";
            // ghi log
            hts_dungchung.PHT_LOG_NH(PHANHE.DT, NHOM_CHUCNANG.DANH_MUC, THAOTAC.EXPORT_EXCEL, TEN_FORM.NS_DT_MA_KDTAO, TEN_BANG.NS_DT_MA_KDTAO);
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ma_kdtao.xlsx", b_dt, null, "Danh_muc_khoa_dao_tao");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}