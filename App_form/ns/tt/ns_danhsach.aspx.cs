using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_danhsach : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {

                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bc/sbc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_danhsach" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_danhsach_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1330,850";
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }

    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE4();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        form.P_DROP_BANG(phong_tk, b_dt);
        // loại hợp đồng
        b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        form.P_DROP_BANG(lhd, b_dt);
        // chức vụ
        b_dt = ns_ma.Fdt_NS_MA_CVU_DR();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        form.P_DROP_BANG(cvu, b_dt);
        // nhóm chức danh
        b_dt = ns_ma.Fdt_NS_MA_NCDANH_DR();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        form.P_DROP_BANG(ncdanh, b_dt);
        // chức danh
        string b_ncdanh = ncdanh.SelectedValue;
        b_dt = ns_ma.Fdt_NS_MA_CDANH_LKE_DR(b_ncdanh);
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" }, 0);
        form.P_DROP_BANG(cdanh, b_dt);
    }
}
