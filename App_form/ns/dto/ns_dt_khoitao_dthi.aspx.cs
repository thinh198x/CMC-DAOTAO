using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_dt_khoitao_dthi : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dto/sns_dto.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dto/ns_dt_khoitao_dthi" + khac.Fs_runMode() + ".js?x=" + DateTime.Now.ToString("yyyyMMddHHmmss"));
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_khoitao_dthi_P_KD();", true);
                MA.Focus();
                P_KETQUA();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_KETQUA()
    {
        DataTable b_dt;
        b_dt = hts_dungchung.Fdt_DT_LOAI_THI();
        se.P_TG_LUU(this.Title, "DT_LOAITHI", b_dt);
    }
}