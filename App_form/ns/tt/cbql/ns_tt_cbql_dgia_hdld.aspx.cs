using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_tt_cbql_dgia_hdld : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                string b_ham = "ns_tt_cbql_dgia_hdld_P_KD('" + Fs_thumuc() + "');";
                string b_s = this.ResolveUrl("~/App_form/ns/tt/cbql/ns_tt_cbql_dgia_hdld" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), b_ham, true);
                P_TrangThaiPheDuyet_DROP();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private string Fs_thumuc()
    {
        string b_form = "~/menu.aspx";
        string b_tm = this.ResolveUrl(b_form);
        return b_tm.Substring(0, b_tm.Length + 1 - b_form.Length);
    }
    protected void XuatExcel_Click(object sender, EventArgs e)
    {
        try
        {
            //DataSet b_ds = new DataSet();
            //DataTable b_dt = new DataTable();
            //string b_loai = NV_SN.Text;
            //if (b_loai != "")
            //{
            //    b_ds = ns_tt.Fdt_MENU_TBAO_CT(b_loai, 10);
            //    b_dt = b_ds.Tables[0];
            //    bang.P_SO_CNG(ref b_dt, "nsinh,ngayhh,ngayd");
            //    b_dt.Columns["SOTT"].SetOrdinal(0);
            //    b_dt.Columns["NSINH"].SetOrdinal(3);
            //    b_dt.Columns["PHONG"].SetOrdinal(4);
            //    b_dt.Columns["ngayd"].SetOrdinal(5);
            //    b_dt.Columns["LHD"].SetOrdinal(6);
            //    b_dt.Columns["ngayhh"].SetOrdinal(7);
            //    string sPathTemplate = "/Templates/ExportMau/ns_tt_cbql_dgia_hdld.xlsx";
            //    string strRoot = HttpContext.Current.Server.MapPath("~");
            //    string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            //    Aspose.Cells.License l = new Aspose.Cells.License();
            //    string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            //    l.SetLicense(strLicense);
            //    Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            //    Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            //    Aspose.Cells.Cells cells2 = wSheet2.Cells;
            //    Aspose.Cells.Style style = new Aspose.Cells.Style();
            //    var istartColumn = 0;
            //    var istartRow = 6;
            //    DataTable b_data = b_dt;
            //    if (b_dt != null && b_dt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i < b_data.Rows.Count; i++)
            //        {
            //            cells2.InsertRows(istartRow, 1, true);

            //            for (int j = 0; j < b_dt.Columns.Count; j++)
            //            {
            //                cells2[istartRow - 1, istartColumn].PutValue(b_data.Rows[i][j].ToString());
            //                istartColumn = istartColumn + 1;
            //            }
            //            istartRow = istartRow + 1;
            //            istartColumn = 0;
            //        }
            //    }
            //    wBook.CalculateFormula();
            //    wBook.Save(HttpContext.Current.Response, "BangThongBaoHetHan.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
            //}
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void P_TrangThaiPheDuyet_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");

        bang.P_THEM_HANG(ref b_dt, new object[] { 0, "Chưa đánh giá" });
        bang.P_THEM_HANG(ref b_dt, new object[] { 1, "Đã đánh giá" });
        se.P_TG_LUU(this.Title, "DT_TRTHAI_PD", b_dt);
    }
}
