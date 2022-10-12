using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;
public partial class f_ns_ctt_dxxn_lg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/ctt/ngv/ns_ctt_dxxn_lg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);

                se.se_nsd b_se = new se.se_nsd();
                string b_nsd = b_se.nsd;
                string b_so_the = P_SOTHE(b_nsd);

                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ctt_dxxn_lg_P_KD('" + b_so_the + "');", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";

                if (b_so_the != "")
                {
                    this.so_the.Text = b_so_the;
                    this.ten.Text = b_se.ten;
                    this.P_TrangThaiXacNhan_DROP();
                    this.P_LOAI_HD_DROP();
                }
                this.HKHAU.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private string P_SOTHE(string b_nsd)
    {
        string b_so_the = "";
        DataTable b_dt = ns_tt.Fdt_NSD_SOTHE(b_nsd);
        if (b_dt.Rows.Count > 0) b_so_the = b_dt.Rows[0]["so_the"].ToString();
        return b_so_the;
    }

    private void P_TrangThaiXacNhan_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 0, "Chưa gửi" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ xác nhận" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được xác nhận" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Từ chối" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 4, "Yêu cầu sửa lại" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_XN", b_dt);
    }

    private void P_LOAI_HD_DROP()
    {
        //day danh sach loai hop dong
        DataTable b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        se.P_TG_LUU(this.Title, "DT_LOAI_HD", b_dt);
    }
}