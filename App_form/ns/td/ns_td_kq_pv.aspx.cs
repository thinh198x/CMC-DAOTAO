using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_td_kq_pv : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/td/sns_td.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/td/ns_td_kq_pv" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_td_kq_pv_P_KD('" + inword.UniqueID + "');", true);
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void inword_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet b_ds = ns_td.Fds_NS_TD_KQ_PV_IN(so_id.Value);
            DataTable b_dt = b_ds.Tables[0];
            DataTable b_dt_ct = b_ds.Tables[1];
            bang.P_SO_CNG(ref b_dt, "NGAYDL_DK,NGAYSINH");
            bang.P_SO_CSO(ref b_dt, "MUCLUONG_TV,MUCLUONG_CT");
            DataSet b_ds_in = new DataSet();
            b_dt.TableName = "DATA";
            b_dt_ct.TableName = "DATA_CT";
            b_ds_in.Tables.Add(b_dt.Copy());
            b_ds_in.Tables.Add(b_dt_ct.Copy());

            string path = Server.MapPath("~");
            Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\phieu_td.doc", "Phieu_tuyen_dung.doc", b_ds_in, Response);
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File mẫu không tồn tại:loi"); }
    }
}
