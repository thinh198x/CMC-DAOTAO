using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_cc_dky_lamthem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
            string b_s = this.ResolveUrl("~/App_form/tl/cc/cc_dky_lamthem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            se.se_nsd b_se = new se.se_nsd();
            string b_nsd = b_se.nsd;
            string b_so_the = P_SOTHE(b_nsd);
            SO_THE.Text = b_nsd;
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "cc_dky_lamthem_P_KD('');", true);            
            thang.Text = chuyen.NG_CTH(DateTime.Now);
            NGAY_DKY.Text = chuyen.NG_CNG(DateTime.Now);
            P_NHAN_DROP();
        }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_dt = tl_cc.Fdt_CC_MA_HSO_LAMTHEM_DR();
        hso.DataSource = b_dt;
        hso.DataTextField = "ten";
        hso.DataValueField = "ma";
        hso.DataBind();
    }
    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }
    protected void btn_excel_mau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_nv, b_dt;
        b_dt_nv = ht_dungchung.Fdt_NS_THONGTIN_CANBO("");
        b_dt_nv.TableName = "DATA";
        b_dt = tl_cc.Fdt_CC_MA_HSO_LAMTHEM_DR();       
        b_dt.TableName = "DATA1";
        b_ds.Tables.Add(b_dt_nv);
        b_ds.Tables.Add(b_dt);
        Excel_dungchung.ExportTemplate("Templates/importmau/cc_dky_lamthem_ktao.xls", b_ds, null, "cc_dky_lamthem_ktao");
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = tl_cc.P_CC_DKY_LAMTHEM_EXPORT();
            bang.P_SO_CNG(ref b_dt,new string[] { "ngay_bd", "ngay_kt" });
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate("Templates/ExportMau/cc_dky_lamthem_export.xlsx", b_dt, null, "dangky_lamthem");

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}
