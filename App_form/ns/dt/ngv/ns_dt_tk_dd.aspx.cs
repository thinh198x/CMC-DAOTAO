using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_tk_dd : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_tk_dd" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tk_dd_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";

                this.TaoLuoiDiemDanh();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void TaoLuoiDiemDanh()
    {        
        double b_so_id_tk = 0;
        if (Request.QueryString["so_id_tk"] != null)
            double.TryParse(Request.QueryString["so_id_tk"], out b_so_id_tk);
        DataTable dtNgayDiemDanh = ns_dt.Fdt_NS_DT_TK_TKB_LKE_ALL(b_so_id_tk);
        int b_index = 0;
        string b_cot = "so_the,ten,phong,dtdd,email";
        foreach (DataRow dr in dtNgayDiemDanh.Rows)
        {
            TemplateField customField = new TemplateField();
            customField.ShowHeader = true;
            customField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, dr["ngay"] + " " + dr["chude"], "", "", "", "", "");
            customField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "", dr["so_id"].ToString(), "Cthuvien.kieu", "css_Gma_r", "X", "ns_dt_tk_dd_GR_Update(event);", "P,A,An", "P");
            customField.HeaderStyle.Width = Unit.Pixel(100);
            customField.ItemStyle.CssClass = "css_ma_c";
            GR_lke.Columns.Insert(b_index + 6, customField);

            b_cot += "," + dr["so_id"];
            b_index++;
        }
        b_cot += ",tl,kq,ghichu";
        GR_lke.cot = b_cot;
    }
}