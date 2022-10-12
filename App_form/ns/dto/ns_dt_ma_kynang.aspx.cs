using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_ma_kynang : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
            string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_ma_kynang" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
            ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_ma_kynang_P_KD();", true);
            P_NHAN_DROP();
            NKYNANG.Focus();
        }
    }
    private void P_NHAN_DROP()
    {
        //Nhóm kỹ năng
        DataTable b_dt = ns_dto.Fdt_NS_DT_MA_NKYNANG_LKE_ALL();
        se.P_TG_LUU(this.Title, "DT_NKYNANG", b_dt.Copy());
    }
}
