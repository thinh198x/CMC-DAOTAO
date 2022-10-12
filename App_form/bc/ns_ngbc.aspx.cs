using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.IO;
using Cthuvien;

public partial class f_ns_ngbc : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/bc/sbc.asmx"));
            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_ngbc_P_KD('');", true);
            string b_s = "ns_ngbc_P_KD('" + Fs_thumuc() + "','" + chon_in.ClientID + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_s, true);
            ngayd.Text = "01/01/" + DateTime.Now.ToString("yyyy");
            ngayc.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ma_dvi.Text = (new se.se_nsd()).ma_dvi;
            P_NHAN_DROP(); ngayd.Focus();
        }
    }
    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
    protected void SO_THE_TextChanged(object sender, EventArgs e)
    {
        try { khac.P_MA_LOI(so_the, true); mau.Focus(); }
        catch (Exception ex) { form.P_LOI(this, ex.Message); so_the.Focus(); }
    }
    //protected void GR_lke_ActiveRowChange(object sender, Infragistics.WebUI.UltraWebGrid.RowEventArgs e)
    //{
    //    hf_ma.Value = chuyen.OBJ_S(gridX.Fobj_TIM_GTRI(GR_lke, "ma"));
    //    ten.Text = chuyen.OBJ_S(grid.Fobj_TIM_GTRI(GR_lke, "ten"));
    //    ddan.Value = chuyen.OBJ_S(grid.Fobj_TIM_GTRI(GR_lke, "ddan"));
    //    tenrp.Value = chuyen.OBJ_S(grid.Fobj_TIM_GTRI(GR_lke, "tenrp"));
    //    P_NHAN_MAU(); ngayd.Focus();

    //}
    private void P_NHAN_DROP()
    {
        DataTable b_dt = new DataTable();
        bang.P_THEM_COL(ref b_dt, new string[] { "ma", "ten" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "NGAY", "Báo cáo ngày" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "THANG", "Báo cáo tháng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "QUY", "Báo cáo quý" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "NAM", "Báo cáo năm" });
        loai.DataSource = b_dt; loai.DataBind();
    }
    private void P_NHAN_MAU()
    {
        string b_url = Server.MapPath(ddan.Value + hf_ma.Value + ".xml");
        if (!File.Exists(b_url)) return;
        DataSet ds = new DataSet(); ds.ReadXml(b_url);
        DataTable b_dt = ds.Tables["row"].Copy();
        mau.DataSource = b_dt; mau.DataBind();
    }
    protected void xem_Click(object sender, EventArgs e)
    {
        try
        {
            //if (kytu.C_NVL(ddan.Value) == "" || kytu.C_NVL(tenrp.Value) == "")
            //    throw new Exception("loi:Chưa chọn báo cáo cần xem:loi");
            //if (mau.Items.Count > 0) tenrp.Value = kytu.C_NVL(mau.SelectedValue);
            //DataTable b_dt = new DataTable(); form.P_TEXT_ROW(this, ref b_dt);
            //DataSet b_ds = ns_bc.Fds_CHAYBC(b_dt, hf_ma.Value, ddan.Value, tenrp.Value);
            ////string b_ftkhao = "~/App_form/bc/xembc.aspx?kieu_in=" + kytu.C_NVL(kieu_in.SelectedValue);
            ////if (tenrp.Value.IndexOf(".xml") > 0) b_ftkhao = "~/App_form/bc/xemvb.aspx?kieu_in=" + kytu.C_NVL(kieu_in.SelectedValue);
            //string b_file = "~/App_rpt/ns/"; string b_out = "~/Templates/ns/";
            //ht_bc.P_XUAT_EXCEL(b_file, ref b_out, "bc_ns_1", b_ds);
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
}
