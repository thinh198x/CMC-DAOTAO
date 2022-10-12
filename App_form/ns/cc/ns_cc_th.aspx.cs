using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;
using System.Globalization;

public partial class f_ns_cc_th : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/hts_dungchung.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ch/sed_vb_khac.asmx"));
                string b_s1 = this.ResolveUrl("~/App_form/chung/ed_vb_khac" + khac.Fs_runMode() + ".js");
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s1);
                string b_s = this.ResolveUrl("~/App_form/ns/cc/ns_cc_th" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_th_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(akyluong.Value)) form.P_LOI(this, "Vui lòng chọn kỳ lương");

            DataSet b_ds = tl_cc.Fds_NS_CC_TH_EXCEL(aphong.Value, akyluong.Value, so_the.Text);
            DataTable b_dt_th = new DataTable();
            DataTable b_dt_title = new DataTable();
            b_dt_th = b_ds.Tables[0]; b_dt_title = b_ds.Tables[1];
            b_dt_th.TableName = "DATA_TH"; b_dt_title.TableName = "DATA_TITLE";
            bang.P_SO_CNG(ref b_dt_th, "ngay_vao,ngayd,ngayc");
            bang.P_SO_CNG(ref b_dt_title, "tu_ngay,den_ngay");
            DataSet b_ds_pr = new DataSet();
            b_ds_pr.Tables.Add(b_dt_th.Copy());
            b_ds_pr.Tables.Add(b_dt_title.Copy());

            Excel_dungchung.ExportTemplate("Templates/ExportMau/Bang_cong_thang.xlsx", b_ds_pr, null, "Bang_cong_tong_hop");
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    protected void nhap1_Click(object sender, EventArgs e)
    {
        try
        {
            //if (string.IsNullOrEmpty(361))
            //{
            //    form.P_LOI(this, "Vui lòng chọn kỳ lương");
            //}
            DataSet b_ds = null;// tl_cc.Fdt_NS_CC_TONGHOP_BC("BSS", 361);
            DataTable b_dt = b_ds.Tables[1];
            DataTable b_header = b_ds.Tables[0];
            bang.P_SO_CNG(ref b_header, "ngay_d,ngay_c");
            string sPathTemplate = "/Templates/ExportMau/Bang_cong_thang_bc.xlsx";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            Aspose.Cells.Style style1 = new Aspose.Cells.Style();
            style1 = cells2["i2"].GetStyle();
            cells2["i2"].SetStyle(cells2["j2"].GetStyle());
            var istartRow = 4;
            var istartColumn = 5;
            DateTimeFormatInfo ddif = new DateTimeFormatInfo();
            ddif.ShortDatePattern = "dd/MM/yyyy";
            var ngay_bd = int.Parse(b_header.Rows[0]["ngay_bd"].ToString());
            var ngay_kt = int.Parse(b_header.Rows[0]["ngay_kt"].ToString());
            var ngayd = Convert.ToDateTime(b_header.Rows[0]["ngay_d"].ToString(), ddif);
            var ngayc = Convert.ToDateTime(b_header.Rows[0]["ngay_c"].ToString(), ddif);
            var tungay = ngayd;
            var denngay = ngayc;
            int ngayStart = ngay_bd;
            for (int i = ngay_bd; i <= ngay_kt; i++)
            {
                cells2.InsertColumns(istartColumn, 1, true);
                cells2[istartRow - 1, istartColumn].PutValue(ngayStart.ToString());

                istartColumn = istartColumn + 1;
                ngayStart = ngayStart + 1;
            }
            istartRow = 4; istartColumn = 5;
            for (int i = ngay_bd; i <= ngay_kt; i++)
            {
                switch (ngayd.DayOfWeek)
                {
                    case DayOfWeek.Friday:
                        cells2[istartRow, istartColumn].PutValue("T6"); break;
                    case DayOfWeek.Monday:
                        cells2[istartRow, istartColumn].PutValue("T2"); break;
                    case DayOfWeek.Saturday:
                        cells2[istartRow, istartColumn].PutValue("T7");
                        cells2[istartRow - 1, istartColumn].SetStyle(style1);
                        cells2[istartRow, istartColumn].SetStyle(style1);
                        cells2[istartRow + 1, istartColumn].SetStyle(style1); break;
                    case DayOfWeek.Sunday:
                        cells2[istartRow, istartColumn].PutValue("CN");
                        cells2[istartRow - 1, istartColumn].SetStyle(style1);
                        cells2[istartRow, istartColumn].SetStyle(style1);
                        cells2[istartRow + 1, istartColumn].SetStyle(style1); break;
                    case DayOfWeek.Thursday:
                        cells2[istartRow, istartColumn].PutValue("T5"); break;
                    case DayOfWeek.Tuesday:
                        cells2[istartRow, istartColumn].PutValue("T4"); break;
                    case DayOfWeek.Wednesday:
                        cells2[istartRow, istartColumn].PutValue("T3"); break;
                    default:
                        break;
                }
                istartColumn = istartColumn + 1;
                ngayd = ngayd.AddDays(1);
            }
            cells2.DeleteColumns(4, 1, true);
            cells2.DeleteColumns(istartColumn - 1, 1, true);
            cells2["A2"].PutValue("Từ ngày " + tungay.ToShortDateString() + " đến " + ngayc.ToShortDateString());
            cells2["A1"].PutValue("BẢNG CHẤM CÔNG THÁNG " + b_header.Rows[0]["thang_bc"].ToString());
            istartRow = 6;
            for (int j = 0; j < b_dt.Rows.Count; j++)
            {
                cells2.InsertRows(istartRow, 1);
                for (int i = 0; i < b_dt.Columns.Count - 4; i++)
                {
                    cells2[istartRow - 1, i].PutValue(b_dt.Rows[j][i].ToString());
                }
                istartRow = istartRow + 1;
            }
            istartRow = 5;
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                cells2[istartRow, b_dt.Columns.Count - 2].Formula = string.Format(" = {0} + {1} + {2}+ {3}", cells2[istartRow, b_dt.Columns.Count - 8].Name, cells2[istartRow, b_dt.Columns.Count - 7].Name, cells2[istartRow, b_dt.Columns.Count - 5].Name, cells2[istartRow, b_dt.Columns.Count - 4].Name);
                cells2[istartRow, b_dt.Columns.Count - 1].PutValue(b_dt.Rows[i]["c42"].ToString());
                cells2[istartRow, b_dt.Columns.Count].PutValue(b_dt.Rows[i]["c43"].ToString());
                cells2[istartRow, b_dt.Columns.Count + 1].PutValue(b_dt.Rows[i]["c44"].ToString());
                istartRow = istartRow + 1;
            }
            cells2["E3"].PutValue(b_header.Rows[0]["cong_chuan"].ToString());
            wBook.CalculateFormula();
            wBook.Save(HttpContext.Current.Response, "bang_cong_thang_bc1.xlsx", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Xlsx));
        }
        catch (Exception) { form.P_LOI(this, "loi:Không tồn tại biểu mẫu:loi"); }
    }
    private void P_NHAN_DROP()
    {
        DataTable b_phong = ns_tt.Fdt_MA_PHONG_LKE();
        bang.P_THEM_HANG(ref b_phong, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        se.P_TG_LUU(this.Title, "DT_PHONG", b_phong.Copy());
        DataTable b_nam = hts_dungchung.Fdt_MA_KYLUONG_NAM_XEM();
        int b_hang = bang.Fi_TIM_ROW(b_nam, "MA", DateTime.Now.Year.ToString());
        se.P_TG_LUU(this.Title, "DT_NAM", b_nam.Copy());
        se.P_TG_LUU(this.Title, "DT_KY", null);
    }
}