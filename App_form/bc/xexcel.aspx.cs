using System;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Cthuvien;

public partial class f_xexcel : fmau
{
    DataSet b_kq;
    DataTable dt = new DataTable();
    string b_kieu_in = "";
    protected void Page_Init(object sender, EventArgs e)
    {
        thumuc.Value = Fs_thumuc();
        try
        {
            string b_md = kytu.C_NVL(Request.QueryString["md"]).ToUpper();
            // Lay so lieu tu tham so
            b_kq = se.Fds_KQ_TRA("TK_KQ", "EXCEL");
            DataTable b_dt = b_kq.Tables["B"], b_dt_ct = b_kq.Tables["TSO"];
            b_kieu_in = chuyen.OBJ_S(b_dt_ct.Rows[0]["kieu_in"]);
            string b_ddan, b_ten_rp;
            if (b_kieu_in.IndexOf("E") >= 0)
            {
                // Kiet xuat dac biet
                string b_ma_bc = chuyen.OBJ_S(b_dt_ct.Rows[0]["ma_bc"]);
                if (b_ma_bc == "ns_ts_ql.xml")
                {
                    b_kq = new DataSet();
                    object[] objects = ns_ts_gv.Fdt_NS_TS_QL_LKE_EXCEL(b_dt_ct, 1, 1000);
                    dt = (DataTable)objects[1];
                    dt.TableName = "B";
                    b_kq.Tables.Add(dt.Copy());
                }
                else if (b_ma_bc == "ns_ts_dutru.xml")
                {
                    b_kq = new DataSet();
                    object[] objects = ns_ts_gv.Fdt_NS_TS_PHONG_KHOI_LKE(b_dt_ct, 1, 1000);
                    dt = (DataTable)objects[2];
                    dt.TableName = "B";
                    b_kq.Tables.Add(dt.Copy());
                }
                else if (b_ma_bc == "ns_ts_dutruPhong.xml")
                {
                    b_kq = new DataSet();
                    object[] objects = ns_ts_gv.Fdt_NS_TS_PHONG_KHOI2_LKE(b_dt_ct, 1, 1000);
                    dt = (DataTable)objects[2];
                    dt.TableName = "B";
                    b_kq.Tables.Add(dt.Copy());
                }
                b_ddan = chuyen.OBJ_S(b_dt_ct.Rows[0]["ddan"]);
                b_ten_rp = chuyen.OBJ_S(b_dt_ct.Rows[0]["ten_rp"]);
                if (P_XUAT_KH(b_md, b_ma_bc, b_kieu_in, b_ddan, b_ten_rp)) return;
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private bool P_XUAT_KH(string b_md, string b_ma_bc, string b_kieu_in, string b_ddan, string b_ten_rp)
    {
        
            string b_sout = "~/Outputs/";
            if (b_kieu_in == "E")
            {
                string b_ten = b_ten_rp.Substring(0, b_ten_rp.Length - 4);
                ht_bc.P_XUAT_EXCEL(b_ddan, ref b_sout, b_ten, b_kq);
                Response.Redirect(b_sout);
                return true;
            } 
        return false;
    }
    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
}
