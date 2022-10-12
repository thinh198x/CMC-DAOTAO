using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_ls_tt_dg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ls/sns_ls.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ls/ns_ls_tt_dg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ls_tt_dg_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }    
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            object[] a_obj = ns_ls.PNS_LS_DG_LKE(this.so_the_an.Value.Trim(), 1, 1000);
            DataTable b_dt = (DataTable)a_obj[1];
            bang.P_SO_CNG(ref b_dt, "ngay_vp");
            bang.P_SO_CNG(ref b_dt, "ngayd");
            bang.P_CSO_SO(ref b_dt, "tienphat");
            bang.P_THEM_COL(ref b_dt, "ten_cap_kl", "");
            foreach (DataRow b_dr in b_dt.Rows)
            {
                if (chuyen.OBJ_S(b_dr["cap_kl"]) == "0") b_dr["ten_cap_kl"] = "Cấp công ty";
                else b_dr["cap_kl"] = "Cấp phòng ban";
            }
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_ls_tt_dg_export.xlsx", b_dt, null, "Ket_qua_danh_gia");          
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
