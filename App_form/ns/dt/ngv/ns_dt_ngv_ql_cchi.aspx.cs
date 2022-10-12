using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_ngv_ql_cchi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/nv/ns_dt_ngv_ql_cchi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ngv_ql_cchi_P_KD();", true);
                if (se.Fs_DUYET() != "IE") kthuoc.Value = "1230,600";
                //PHONG.Focus(); NGAYD.Text = chuyen.NG_CNG(DateTime.Now);
                //MA.Focus();
                P_NAM_DROP();
                P_THANG_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            //DataTable b_dt = ns_dt.Fdt_ns_dt_ngv_ql_cchi_LKE_ALL();
            //b_dt.TableName = "DATA";
            //Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dt_ngv_ql_cchi.xlsx", b_dt, null, "Kế hoạch đào tạo năm");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    private void P_NAM_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt);
    }
    private void P_THANG_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);
    }
}
