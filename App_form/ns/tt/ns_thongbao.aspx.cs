using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_thongbao : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/sSmtpMail.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_thongbao" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_thongbao_P_KD('');", true);
                P_NHAN_DROP(); TBAO_MENU();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        //PHONG.DataSource = b_dt; PHONG.DataBind();
    }
    private void TBAO_MENU()
    {
        DataTable b_dt = ns_tt.Fdt_MENU_TBAO();
        string b_sn = chuyen.OBJ_S(b_dt.Rows[0]["soluong"]); string b_hd = chuyen.OBJ_S(b_dt.Rows[1]["soluong"]);
        string b_hh = chuyen.OBJ_S(b_dt.Rows[2]["soluong"]);
        this.Lb_sn.Text = "Sinh nhật trong tháng: " + b_sn;
        this.Lb_hd.Text = "Sắp đến hạn hợp đồng: " + b_hd;
        this.Lb_hh.Text = "Đã hết hạn hợp đồng: " + b_hh;
        this.lb_ut.Text = "Trúng tuyển chưa nhập hợp đồng: 2";
    }
}
