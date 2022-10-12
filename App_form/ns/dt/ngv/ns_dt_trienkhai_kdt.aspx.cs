using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;


public partial class f_ns_dt_trienkhai_kdt : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_trienkhai_kdt" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_trienkhai_kdt_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";

                this.P_MA_DTAC_DROP();
                this.P_NAM_DROP();
                this.P_THANG_DROP();
                this.P_MA_KDT_DROP();
                //NAM.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
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

    private void P_MA_KDT_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_KDTAO_DR();
        se.P_TG_LUU(this.Title, "DT_DM_KDT", b_dt);
    }
    private void P_MA_DTAC_DROP()
    {
        DataTable b_dt = ns_dt.Fdt_NS_DT_MA_DTAC_DR();
        se.P_TG_LUU(this.Title, "DT_DTAC", b_dt);
    }
    private void P_TrangThaiLop_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chưa diễn ra" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Đang diễn ra" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Đã kết thúc" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 0, "Hủy" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_LOP", b_dt);
    }

    private void P_TrangThaiPheDuyet_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được phê duyệt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Không phê duyệt" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_PD", b_dt);
    }
}