using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ctt_dxdt_ql : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ctt/ngv/ns_ctt_dxdt_ql" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);

                se.se_nsd b_se = new se.se_nsd();
                string b_nsd = b_se.nsd;
                string b_so_the = P_SOTHE(b_nsd);

                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ctt_dxdt_ql_P_KD('" + b_so_the + "');", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";
                
                if (b_so_the != "")
                {
                    DataTable b_dt_cb = ht_dungchung.Fdt_NS_THONGTIN_CANBO(b_so_the);
                    if (b_dt_cb.Rows.Count > 0)
                    {
                        this.dvi.Text = b_dt_cb.Rows[0]["ten_phong"].ToString();
                    }
                    this.P_NAM_DROP();
                    this.P_THANG_DROP();
                    this.P_TrangThaiPheDuyet_DROP();
                }      
                //NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
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
    

    private void P_TrangThaiPheDuyet_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 0, "Chưa gửi phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Không phê duyệt" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_PD", b_dt);
    }
}