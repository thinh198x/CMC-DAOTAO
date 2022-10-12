using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dg_tc_cbnv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/dg/sdg.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/hdns/dm/dg/ns_dg_tc_cbnv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dg_tc_cbnv_P_KD();", true);
            P_NAM_DROP();
            P_KY_DG_DROP();
            P_PHONG_BAN_DROP();
         
        }
    }

    private void P_NAM_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "TC_DG_CBNV_NAM", b_dt);
    }

    private void P_KY_DG_DROP()
    {
        DataTable b_dt = dg.Fdt_NS_DG_MA_KDG_LKE_ALL();
        se.P_TG_LUU(this.Title, "TC_DG_CBNV_KY_KDG", b_dt);
    }

    private void P_PHONG_BAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        DataRow b_dr = b_dt.NewRow();
        b_dt.Rows.InsertAt(b_dr, 0);
        se.P_TG_LUU(this.Title, "TC_DG_CBNV_PHONG", b_dt);
    }

    protected void excel_Click(object sender, EventArgs e)
    {
        try
        {
            string[] a_data = this.so_the.Value.Split((char)1);
            string b_so_the = a_data[0], b_ma_plnv = a_data[1], b_ma_capnv = a_data[2], b_ma_kdg = a_data[4];
            double b_nam = chuyen.CSO_SO(a_data[3]);
            object[] a_object = dg.Fdt_NS_DG_TC_CBNV_CT(b_nam, b_ma_kdg, b_so_the, b_ma_plnv, b_ma_capnv);
            DataTable b_dt = (DataTable)a_object[1];           
            b_dt.TableName = "DATA";
            bang.P_THAY_GTRI(ref b_dt, "luyke_kysau", "C", "Có");
            bang.P_THAY_GTRI(ref b_dt, "luyke_kysau", "K", "Không");
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_dg_tc_cbnv.xlsx", b_dt, null, "Tiêu chí đánh giá CBNV");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}