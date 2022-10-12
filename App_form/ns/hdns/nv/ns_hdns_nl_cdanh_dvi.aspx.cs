using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hdns_nl_cdanh_dvi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/hdns/sns_hdns.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/hdns/nv/ns_hdns_nl_cdanh_dvi" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hdns_nl_cdanh_dvi_P_KD();", true);
                PHONG.Focus();
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt_phong = ns_tt.Fdt_MA_PHONG_LKE();
        se.P_TG_LUU(this.Title, "NL_CD_DVI_PHONG", b_dt_phong);

        DataTable b_dt = ns_hdns.Fdt_NS_HDNS_MA_NNN_DROP_MA();
        se.P_TG_LUU(this.Title, "NL_CD_DVI_NNNGHIEP", b_dt);
        //se.P_TG_LUU(this.Title, "DT_CD", null);
    }

    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_hdns.Fdt_NS_HDNS_GAN_NLCD_DVI_EXCEL();
            DataTable b_dt = b_ds.Tables[0], b_dt_ct = b_ds.Tables[1];
            DataTable b_dt_th = b_dt.Clone();
            bang.P_THEM_COL(ref b_dt_th, new string[] { "ten_nhom_nl", "ten_nl", "muc_nl", "mota" });
            int b_sott = 0;
            foreach (DataRow b_dr in b_dt.Rows)
            {
                DataRow[] a_dr = b_dt_ct.Select("so_id_nlcd_dvi = " + b_dr["so_id"]);                
                for (int i = 0; i < a_dr.Length; i++)
                {
                    DataRow b_new_dr = b_dt_th.NewRow();
                    if (i == 0)
                    {
                        b_new_dr["ten_phong"] = b_dr["ten_phong"];
                        b_new_dr["ten_nnnghiep"] = b_dr["ten_nnnghiep"];
                        b_new_dr["ten_cdanh"] = b_dr["ten_cdanh"];
                        b_new_dr["ngay_hl"] = b_dr["ngay_hl"];
                    }
                    b_new_dr["ten_nhom_nl"] = a_dr[i]["ten_nhom_nl"];
                    b_new_dr["ten_nl"] = a_dr[i]["ten_nl"];
                    b_new_dr["muc_nl"] = a_dr[i]["muc_nl"];
                    b_new_dr["mota"] = a_dr[i]["mota"];
                    b_new_dr["sott"] = ++b_sott;
                    b_dt_th.Rows.Add(b_new_dr);
                }                               
            }
            b_dt_th.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns/hdns/ns_hdns_nl_cdanh_dvi.xlsx", b_dt_th, null, "Gan_nang_luc_chuc_danh_cho_dvi");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}