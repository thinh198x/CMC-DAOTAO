using System;
using System.Web.UI;
using System.Data;
using Cthuvien;

public partial class f_kh_tso : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                string b_s = this.ResolveUrl("~/App_form/khud/kh_tso"+khac.Fs_runMode()+".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                DataTable b_dt = khud.Fdt_NSD_TSO_LKE();
                b_s = (bang.Fb_TRANG(b_dt)) ? "" : bang.Fs_HANG_GOP(b_dt, 0);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "kh_tso_KD('" + b_s + "');", true);               
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); } 
    }
    private DataTable Fdt_NUOC()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "VIE", "Tiếng Việt" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "ENG", "English" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "KOR", "한국어"});
        bang.P_THEM_HANG(ref b_dt, new object[] { "JAN", "日本人" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "FRE", "Français" });
        b_dt.AcceptChanges();
        return b_dt;
    }
    private DataTable Fdt_MH()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "", "Tạo popup" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Tạo cửa sổ mới" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "C", "Tương tác một màn hình" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "K", "Tương tác nhiều màn hình" });
        b_dt.AcceptChanges();
        return b_dt;
    }
}