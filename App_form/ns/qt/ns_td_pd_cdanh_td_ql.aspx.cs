using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_pd_cdanh_td_ql : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_td_pd_cdanh_td_ql" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_pd_cdanh_td_ql_P_KD('');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //Phong
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_dt);
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
    }
    protected void Xuat_Excel(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds_data = ns_td.Fdt_NS_TD_PD_CDANH_TD_QL_EXCEL(an_sothe.Value);
            DataTable b_dt = b_ds_data.Tables[0]; b_dt.TableName = "DATA"; bang.P_SO_CNG(ref b_dt, "ngaysinh,ngaycap_cmt,ngaycap_hochieu"); bang.P_SO_CSO(ref b_dt, "mucluong_mm");
            DataTable b_dt_trinhdo = b_ds_data.Tables[1]; b_dt_trinhdo.TableName = "TRINHDO";
            DataTable b_dt_nn = b_ds_data.Tables[2]; b_dt_nn.TableName = "NGOAINGU";
            DataTable b_dt_cc = b_ds_data.Tables[3]; b_dt_cc.TableName = "CHUNGCHI";
            DataTable b_dt_qtct = b_ds_data.Tables[4]; b_dt_qtct.TableName = "QUATRINH";bang.P_SO_CTH(ref b_dt_qtct, "TUTHANG,DENTHANG");
            DataTable b_dt_qhnt = b_ds_data.Tables[5]; b_dt_qhnt.TableName = "NHANTHAN";
            DataTable b_dt_ttk = b_ds_data.Tables[6]; b_dt_ttk.TableName = "THAMKHAO";

            DataSet b_ds_ex = new DataSet();
            b_ds_ex.Tables.Add(b_dt.Copy());
            b_ds_ex.Tables.Add(b_dt_trinhdo.Copy());
            b_ds_ex.Tables.Add(b_dt_nn.Copy());
            b_ds_ex.Tables.Add(b_dt_cc.Copy());
            b_ds_ex.Tables.Add(b_dt_qtct.Copy());
            b_ds_ex.Tables.Add(b_dt_qhnt.Copy());
            b_ds_ex.Tables.Add(b_dt_ttk.Copy());

            Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_td_pd_cdanh_td_ql.xlsx", b_ds_ex, null, "CV");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}