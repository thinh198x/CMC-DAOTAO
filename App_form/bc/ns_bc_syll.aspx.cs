using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using Cthuvien;

public partial class f_ns_bc_syll : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack) SO_THE.Focus();

        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); form.P_DONG(this); }
    }
    protected void SO_THE_TextChanged(object sender, EventArgs e)
    {
        try 
        { 
            khac.P_MA_LOI(SO_THE, true);
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); SO_THE.Focus(); }
    }
    protected void xem_Click(object sender, EventArgs e)
    {
        try
        {
            DataTable b_dt = new DataTable(); 
            form.P_TEXT_ROW(this, ref b_dt);

            DataTable b_dt_ten = new DataTable();
            bang.P_THEM_COL(ref b_dt_ten, new string[] { "ma", "ddan", "ten" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_cmnv" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_hdct" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_ddls_a" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_ddls_b" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_qhnn_a" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_qhnn_b" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_qhgd" });
            bang.P_THEM_HANG(ref b_dt_ten, new object[] { "", "~/App_rpt/ns/", "r_ns_syll_sub_kte_a" });

            DataSet b_ds = ns_bc.Fds_NS_BC_SYLL(b_dt, b_dt_ten);
            string b_ftkhao = "~/App_form/bc/xembc.aspx?kieu_in=" + kytu.C_NVL(kieu_in.SelectedValue);
            ht_bc.P_MO(this, b_ftkhao, "", 1000, 700, b_ds);
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    
}
