using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_xn_lg : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ctt/sns_ctt.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_xn_lg" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                                
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_xn_lg_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";

                this.P_TrangThaiXacNhan_DROP();                   
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_TrangThaiXacNhan_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Chờ xác nhận" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 2, "Được xác nhận" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 3, "Từ chối" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 4, "Yêu cầu sửa lại" });

        se.P_TG_LUU(this.Title, "DT_TRTHAI_XN", b_dt);
    }

    protected void In_Click(object sender, EventArgs e)
    {
        try
        {            
            double b_so_id = Convert.ToDouble(so_id.Value);
            DataTable b_dt = ns_ctt.Fdt_NS_CTT_DXXN_LG_CT(b_so_id);
            bang.P_SO_CNG(ref b_dt, new string[] { "NGAY_CMT", "NGAYD_HD", "NGAYC_HD", "NGAY_VAO" });
            bang.P_SO_CSO(ref b_dt, new string[] { "LUONG_CHINH", "TN_KHAC" });
            b_dt.TableName = "DATA";
            
            bang.P_THEM_COL(ref b_dt, "NGAY_XN", DateTime.Now.Day);
            bang.P_THEM_COL(ref b_dt, "THANG_XN", DateTime.Now.Month);
            bang.P_THEM_COL(ref b_dt, "NAM_XN", DateTime.Now.Year);

            bang.P_COPY_COL(ref b_dt, "TRUOC_THUE", "THUE");
            bang.P_COPY_COL(ref b_dt, "SAU_THUE", "THUE");
            bang.P_THAY_GTRI(ref b_dt, "TRUOC_THUE", "TRUOC", "x");
            bang.P_THAY_GTRI(ref b_dt, "TRUOC_THUE", "SAU", " ");
            bang.P_THAY_GTRI(ref b_dt, "SAU_THUE", "TRUOC", " ");
            bang.P_THAY_GTRI(ref b_dt, "SAU_THUE", "SAU", "x");
            if (b_dt.Rows.Count > 0)
            {
                if (b_dt.Rows[0]["ten_lhd"] != DBNull.Value)
                    b_dt.Rows[0]["LOAI_HD"] = b_dt.Rows[0]["ten_lhd"];
            }

            string path = Server.MapPath("~");
            Word_dungchung.ExportMailMerge(path + @"Templates\ExportMau\ns\tt\ns_xn_lg.doc", "XacNhanLuong.doc", b_dt, Response);

        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
}