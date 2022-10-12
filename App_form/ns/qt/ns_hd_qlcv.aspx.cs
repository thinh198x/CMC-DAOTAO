using System;
using System.Data;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_hd_qlcv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/qt/ns_hd_qlcv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_hd_qlcv_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP(); SO_THE.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    private void P_NHAN_DROP()
    {
        //day danh sach loai hop dong
        DataTable b_dt = ns_ma.Fdt_NS_MA_LHD_DR();
        LHD.DataSource = b_dt; LHD.DataBind();
        // lay danh sach phong
        b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
        DataTable b_tusinh = ht_dungchung.Fdt_HT_MA_TUSINH_MA();
        if (b_tusinh != null && b_tusinh.Rows.Count > 0)
        {
            if (b_tusinh.Rows[0]["HOPDONG"].Equals("TS"))
            {
                SO_HD.ReadOnly = true;
                SO_HD.Enabled = false;
            } 
        }

    }
    protected void msword_Click(object sender, EventArgs e)
    {
        try
        {
            string b_so_id = so_id.Value;
            if (b_so_id == "" || b_so_id == "0") { form.P_LOI(this, "loi:Chọn hợp đồng muốn in hoặc ấn nhập trước khi in:loi"); return; }
            else { CHAY_BC("W"); return; }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }

    private void CHAY_BC(string b_kieu_in)
    {
        try
        {
            
            DataTable b_dt_tso = new DataTable();
            form.P_TEXT_ROW(this, ref b_dt_tso);
            bang.P_THEM_COL(ref b_dt_tso, "so_id", so_id.Value);
            DataSet b_ds = new DataSet();
            b_ds = ns_bc.Fds_NS_HD_IN(b_dt_tso);
            //b_ds = ktbc_bctc.Fds_BC_TMTC(b_dt_tso);
            P_EXPORT_WORD(b_ds);
            return;
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private void P_EXPORT_WORD(DataSet b_ds)
    {
        string b_out = "~/Outputs/";
        DataTable b_dt = b_ds.Tables["TSO"];
        string b_ma_dvi = b_dt.Rows[0]["ma_dvi"].ToString();
        if (b_ma_dvi == "2_PAN"){
            string b_hopdong = b_ds.Tables["B"].Rows[0]["hopdong"].ToString();
            string b_cdanh = b_ds.Tables["B"].Rows[0]["cdanh"].ToString();
            if (b_cdanh == "Công nhân")
            {
                if (b_hopdong == "Hơp̣ đồng thử việc") ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-NHCN", b_ds);
                if (b_hopdong == "Không xác định thời hạn") ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-KTHCN", b_ds);
                else ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-DHCN", b_ds);

            }
            else
            {
                if (b_hopdong == "Hơp̣ đồng thử việc") ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-TVGSVP", b_ds);
                if (b_hopdong == "Không xác định thời hạn") ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-KTHGS", b_ds);
                else ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong-DHGSVP", b_ds);
            }
            
        }
        else if (b_ma_dvi == "80_DEMO")
        {
            string b_hopdong = b_ds.Tables["B"].Rows[0]["hopdong"].ToString();
            if (b_hopdong == "Thử việc") ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "okifood-TV", b_ds);
                else ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "okifood-DH", b_ds);
        }
        else if (b_ma_dvi == "BHXH")
        {
            ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "panhopdong", b_ds);

        }
        else ht_bc.P_XUAT_WORD("~/App_rpt/ns/", ref b_out, "cmchopdong", b_ds);
        
        Response.Redirect(b_out);
    }
    private void P_EXPORT_WORD_ROW(DataSet b_ds)
    {
        string b_out = "~/Outputs/";
        DataTable b_dt = b_ds.Tables["B"];
        ht_bc.P_XUAT_WORD_ROW("~/App_rpt/ns/", ref b_out, "cmchopdong", b_ds);
        Response.Redirect(b_out);
    }
}
