        using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_hdns_dinhbien_ns : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ht/sht_ma.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/nv/hdns_dinhbien_ns" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "hdns_dinhbien_ns_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1300,680";
                P_NHAN_DROP(); nam.Focus();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] {"ma","ten" },"SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "", "Tất cả" }, 0);
        bang.P_THEM_HANG(ref b_dt, new object[] {chuyen.OBJ_S(chuyen.OBJ_I(DateTime.Now.ToString("yyyy"))-1), chuyen.OBJ_S(chuyen.OBJ_I(DateTime.Now.ToString("yyyy")) - 1) });
        bang.P_THEM_HANG(ref b_dt, new object[] { DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("yyyy") });
        bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_S(chuyen.OBJ_I(DateTime.Now.ToString("yyyy")) + 1), chuyen.OBJ_S(chuyen.OBJ_I(DateTime.Now.ToString("yyyy")) +1) });
        form.P_LIST_BANG(nam, b_dt);
        // form.P_DROP_BANG(nam, b_dt);       
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_phong, b_dt_chucdanh,b_dt_ns_ht;       

        b_dt_phong = ht_maph.Fdt_MA_PH_XEM();
        b_dt_phong.TableName = "DATA1"; b_ds.Tables.Add(b_dt_phong);

        b_dt_chucdanh = ns_hdns.Fdt_CDANH_DVI_LKE_TEN();
        b_dt_chucdanh.TableName = "DATA2"; b_ds.Tables.Add(b_dt_chucdanh);

        b_dt_ns_ht = hts_dungchung.Fdt_NS_TONG_NHANSU(chuyen.NG_SO(DateTime.Now), "BSS", "");

        Excel_dungchung.ExportTemplate("Templates/importhdns/hdns_dinhbien_ns_ktao.xls", b_ds, null, "hdns_dinhbien_ns_kt");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            string b_dvi = donvi.Text;
            DataTable b_dt = null;
                //ns_td.Fdt_HDNS_DINHBIEN_EXPORT(b_dvi);           
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/hdns_dinhbien_ns.xlsx", b_dt, null, "dinhbien_ns");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
