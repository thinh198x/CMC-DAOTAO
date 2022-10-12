using System;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Cthuvien;
//using Cbaocao;

public partial class f_xembc : fmau
{
    DataSet b_kq;
    string b_kieu_in = "";
    CrystalDecisions.CrystalReports.Engine.ReportDocument repo;
    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            b_kieu_in = Request.QueryString["kieu_in"];
            b_kq = (DataSet)HttpContext.Current.Session["kq_ds"];
            if (b_kieu_in == "E") {ExcelHelper.ToExcel(b_kq, Server.MapPath("~/Outputs/excel_sl.xls"), Page.Response); return;}
            DataTable b_dt_ten = b_kq.Tables["TENBC"].Copy(), b_dt_tso = b_kq.Tables["TSO"].Copy(), b_dt_dl = b_kq.Tables[0].Copy();

            DataTable b_dt_tso_sub = new DataTable("TSO_SUB");
            if (b_kq.Tables.Contains("TSO_SUB")) 
            {
                b_dt_tso_sub = b_kq.Tables["TSO_SUB"].Copy();
                b_kq.Tables.Remove("TSO_SUB"); b_kq.AcceptChanges();
            }

            string b_rpt = chuyen.OBJ_S(b_dt_ten.Rows[0]["ten"]);
            repo = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            string rp = Server.MapPath(chuyen.OBJ_S(b_dt_ten.Rows[0]["ddan"]) + b_rpt + ".rpt");
            this.Title = this.Title + " - tên file report: " + rp;
            if (File.Exists(rp) == false) throw new Exception("loi:Không có file " + b_rpt + ":loi");
            repo.Load(rp);
            repo.ReportOptions.EnableSaveDataWithReport = false;
            if (bang.Fb_TRANG(b_dt_dl) == false)
            {
                /// Xử lý trường hợp có nhiều Table vào Datasource
                /// Tên bảng phải trùng tên với tên bảng trong Rp
                if (b_dt_ten.Rows.Count==1 && b_kq.Tables.Count>3) repo.SetDataSource(b_kq);
                else repo.SetDataSource(b_dt_dl);
                try
                {
                    bang.P_BO_HANG(ref b_dt_ten, "ten", b_rpt);
                    if (b_dt_ten.Rows.Count > 0)
                    {
                        for (int i = 0; i < b_dt_ten.Rows.Count; i++)
                        {
                            DataTable b_dt_sub = (DataTable)b_kq.Tables[i + 1].Copy();
                            repo.OpenSubreport(chuyen.OBJ_S(b_dt_ten.Rows[i]["ten"])).SetDataSource(b_dt_sub);
                        }
                    }
                }
                catch { }
            }
            else
            {
                throw new Exception("Không có số liệu");
            }
            // Hung them de xu ly bang tham so va parameter cua RP khong co cung so luong
            int b_slg_para = repo.ParameterFields.Count;
            int b_tong_hang = b_dt_tso.Rows.Count;
            for (int i = 0; i < b_slg_para; i++)
            {
                if (repo.ParameterFields[i].ReportName == "")
                {
                    if (i < b_tong_hang)
                    {
                        if (repo.ParameterFields[i].ParameterValueType.ToString() == "DateParameter")
                            repo.SetParameterValue(i, chuyen.CNG_NG(b_dt_tso.Rows[i][0].ToString()));
                        else
                            repo.SetParameterValue(i, chuyen.OBJ_S(b_dt_tso.Rows[i][0]));
                    }
                    else repo.SetParameterValue(i, ""); 
                }
            }
            if (b_dt_tso_sub.Rows.Count > 0)
            {
                for (int i = 0; i < b_dt_tso_sub.Rows.Count; i++)
                {
                    repo.SetParameterValue(chuyen.OBJ_S(b_dt_tso_sub.Rows[i]["ten"]), chuyen.OBJ_S(b_dt_tso_sub.Rows[i]["giatri"]), 
                        chuyen.OBJ_S(b_dt_tso_sub.Rows[i]["ten_sub"]));
                }
            }

            switch (b_kieu_in)
            {
                case "I": // File PDF
                    ht_bc.P_XUAT_PDF(this, repo, "~/Outputs/"); break;
                case "W": // File Word
                    ht_bc.P_XUAT_RP_WORD(this, repo, "~/Outputs/"); break;
                default: // Crystal report
                    this.CRV.ReportSource = repo; this.CRV.ShowFirstPage(); CRV.Focus(); break;
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    protected void CRV_Unload(object sender, EventArgs e)
    {
        if (repo != null) { repo.Close(); repo.Dispose(); CRV.Dispose(); }
        GC.Collect();
    }
    protected void Page_Unload(object sender, EventArgs e)
    {
        try
        {
            repo.Close();
            repo.Dispose();
        }
        catch { }
    }
}
