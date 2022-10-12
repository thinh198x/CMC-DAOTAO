using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_ns_cc_tonghop : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/cc/stl_cc.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/cc/ns_cc_tonghop" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cc_tonghop_P_KD('" + khac.Fs_TMUCF(b_s) + "');", true);
                P_NHAN_DROP();
                loadYear(); loadMonth();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(KYLUONG.SelectedValue))
            {
                form.P_LOI(this, "Vui lòng chọn kỳ lương");
            }
            DataSet b_ds = tl_cc.Fdt_NS_CC_TONGHOP_CT(PHONG.SelectedValue, double.Parse(KYLUONG.SelectedValue));
            DataTable b_dt = b_ds.Tables[1];            
            b_dt.TableName = "DATA";
            DataTable b_cot = tl_cc.Fdt_NS_CC_TONGHOP_LKE_COT();
            string sPathTemplate = "/Templates/ExportMau/Bang_cong_thang.xlsx";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            var istartColumn = 4;
            var istartRow = 4;
            // insert cột
            if (b_cot != null && b_cot.Rows.Count > 0)
            {
                for (int i = b_cot.Rows.Count-1; i >=0; i--)
                {
                    cells2.InsertColumns(istartColumn, 1, true);
                    cells2[istartRow - 1, istartColumn].PutValue(b_cot.Rows[i]["ten"].ToString());
                    istartColumn = istartColumn + 1;
                }
            }
            cells2.DeleteColumns(istartColumn, 1, true);
            istartColumn = 0;
            istartRow = 5;
            DataTable b_data = b_ds.Tables[1];
            if (b_ds != null && b_ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < b_data.Rows.Count; i++)
			    {
			        cells2.InsertRows(istartRow, 1, true);

                    for (int j = 0; j < b_cot.Rows.Count + 6; j++)
                    {
                        cells2[istartRow - 1, istartColumn].PutValue(b_data.Rows[i][j].ToString());                        
                        istartColumn = istartColumn + 1;
                    }
                    cells2[istartRow - 1, b_cot.Rows.Count+4].PutValue(b_data.Rows[i]["TONG_CONG1"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 5].PutValue(b_data.Rows[i]["TONG_CONG2"].ToString()); 
                    istartRow = istartRow + 1;
                    istartColumn = 0;
                        
			    }
                   
            }             
            wBook.CalculateFormula();
            wBook.Save(HttpContext.Current.Response, "BangCongTongHop.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }

    private void P_NHAN_DROP()
    {
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        PHONG.DataSource = b_dt; PHONG.DataBind();
    }
    private void loadYear()
    {
        DataTable b_dt3 = hts_dungchung.Fdt_MA_KYLUONG_NAM();
        NAM.DataSource = b_dt3;
        NAM.DataBind();
        NAM.SelectedValue = DateTime.Now.Year.ToString();
    }
    private void loadMonth()
    {
        var ithang = "";
        var ngay_bd = "";
        var ngay_kt = "";
        var iNam = DateTime.Now.Year;
        if (!string.IsNullOrEmpty(NAM.SelectedValue))
        {
            iNam = chuyen.OBJ_I(NAM.SelectedValue);
        }

        DataTable b_dt2 = hts_dungchung.Fdt_MA_KYLUONG(iNam);
        bang.P_SO_CNG(ref b_dt2, "ngay_bd,ngay_kt");
        KYLUONG.DataSource = b_dt2;

        KYLUONG.DataBind();
        if (b_dt2.Rows.Count > 0)
        {
            KYLUONG.DataSource = b_dt2;
        }
        if (b_dt2.Select("SHOW = 1").Length > 0)
        {
            ithang = b_dt2.Select("SHOW = 1")[0]["SO_ID"].ToString();
            ngay_bd = b_dt2.Select("SHOW = 1")[0]["NGAY_BD"].ToString();
            ngay_kt = b_dt2.Select("SHOW = 1")[0]["NGAY_KT"].ToString();
        }
        if (!string.IsNullOrEmpty(ithang))
        {
            KYLUONG.SelectedValue = ithang;
        }
    }
}