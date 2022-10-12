using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Cthuvien;

public partial class f_tl_bluong : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try 
        { 
            if (!IsPostBack) 
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/tl/stl_ch.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ti/sti_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/tl/tl_bluong" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "tl_bluong_P_KD();", true);
                loadYear(); P_NHAN_DROP(); loadMonth();
            } 
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
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
    protected void nhap_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(KYLUONG.SelectedValue))
            {
                form.P_LOI(this, "Vui lòng chọn kỳ lương");
            }
            DataTable b_dtDetails = null;// tl_ch.Fdt_TL_BLUONG_EXCEL(PHONG.SelectedValue, KYLUONG.SelectedValue);           
            bang.P_SO_CSO(ref b_dtDetails, "LUONG_1,LUONG_2,LUONG_3,LUONG_4,LUONG_5,LUONG_6,LUONG_7,LUONG_8,LUONG_9,LUONG_10,LUONG_11,LUONG_12,LUONG_13,LUONG_14,LUONG_15,LUONG_16,LUONG_17,LUONG_18,LUONG_19,LUONG_20,LUONG_21,LUONG_22,LUONG_23,LUONG_24,LUONG_25,LUONG_26,LUONG_27,LUONG_28,LUONG_29,LUONG_30,LUONG_31,LUONG_32,LUONG_33,LUONG_34,LUONG_35,LUONG_36,LUONG_37,LUONG_38,LUONG_39,LUONG_40,LUONG_41,LUONG_42,LUONG_43,LUONG_44,LUONG_45,LUONG_46,LUONG_47,LUONG_48,LUONG_49,LUONG_50,LUONG_51,LUONG_52,LUONG_53,LUONG_54,LUONG_55,LUONG_56,LUONG_57,LUONG_58,LUONG_59,LUONG_60,TRU_CDP_CTY,TRU_BHTN_CTY,TRU_BHXH_BHYT_CTY,LUONG_SANPHAM,LUONG_KHOAN,TONG_THUNHAP,TRU_BHXH_BHYT,TRU_BHTN,TRU_CDP,GIAMTRU_BANTHAN,SOTIEN_GIACANH,TONG_THUNHAP_TINHTHUE,THUE_TNCN,THUNHAP_THUCNHAN");

            DataTable b_dt = null;// tl_ch.Fdt_TL_BLUONG_COT();
            
            b_dt.TableName = "DATA";
            DataTable b_cot = null;// tl_ch.Fdt_TL_BLUONG_COT();
            string sPathTemplate = "/Templates/ExportMau/ns_tl_bluong.xlsx";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            var istartColumn = 5;
            var istartRow = 4;
            // insert cột
            if (b_cot != null && b_cot.Rows.Count > 0)
            {
                for (int i = b_cot.Rows.Count - 1; i >= 0; i--)
                {
                    cells2.InsertColumns(istartColumn, 1, true);
                    cells2[istartRow - 1, istartColumn].PutValue(b_cot.Rows[i]["ten"].ToString());
                    istartColumn = istartColumn + 1;
                }
            }
            cells2.DeleteColumns(4, 1, true);
            cells2.DeleteColumns(istartColumn-1, 1, true);
            istartColumn = 0;
            istartRow = 6;
            DataTable b_data = b_dtDetails;
            if (b_dtDetails != null && b_dtDetails.Rows.Count > 0)
            {
                for (int i = 0; i < b_data.Rows.Count; i++)
                {
                   
                    cells2.InsertRows(istartRow, 1, true); 
                    for (int j = 0; j < b_cot.Rows.Count + 3; j++)
                    { 
                        cells2[istartRow - 1, istartColumn].PutValue(b_data.Rows[i][j].ToString());
                        istartColumn = istartColumn + 1;
                    }
                    cells2[istartRow - 1, b_cot.Rows.Count + 4].PutValue(b_data.Rows[i]["LUONG_KHOAN"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 5].PutValue(b_data.Rows[i]["LUONG_SANPHAM"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 6].PutValue(b_data.Rows[i]["TONG_THUNHAP"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 7].PutValue(b_data.Rows[i]["TRU_BHXH_BHYT_CTY"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 8].PutValue(b_data.Rows[i]["TRU_BHTN_CTY"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 9].PutValue(b_data.Rows[i]["TRU_CDP_CTY"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 10].PutValue(b_data.Rows[i]["TRU_BHXH_BHYT"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 11].PutValue(b_data.Rows[i]["TRU_BHTN"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 12].PutValue(b_data.Rows[i]["TRU_CDP"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 13].PutValue(b_data.Rows[i]["GIAMTRU_BANTHAN"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 14].PutValue(b_data.Rows[i]["SOTIEN_GIACANH"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 15].PutValue(b_data.Rows[i]["TONG_THUNHAP_TINHTHUE"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 16].PutValue(b_data.Rows[i]["THUE_TNCN"].ToString());
                    cells2[istartRow - 1, b_cot.Rows.Count + 17].PutValue(b_data.Rows[i]["THUNHAP_THUCNHAN"].ToString());
                    istartRow = istartRow + 1;
                    istartColumn = 0;

                }

            }
            wBook.CalculateFormula();
            wBook.Save(HttpContext.Current.Response, "BangCongTongHop.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    //protected void nhap_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        DataTable b_dt = tl_ch.Fdt_TL_BLUONG_CT(PHONG.SelectedValue, KYLUONG.SelectedValue);
    //        bang.P_SO_CSO(ref b_dt, "LUONG_CB,TROCAP_KD,PHUCAP,TONG_LUONG,TONGCONG_LV,CONG_LETET,CONG_CHEDO,CONG_DAOTAO,CONG_CT,TONGCONG_HL,TONGCONG_NGHI_HL,OT_TINHTHUE,OT_MIENTHUE,TONG_LUONG_THEONGAY,LUONG_NGOAIGIO,TONG_PHUCAP,KHOAN_THUONG,TONG_PHUCLOI,TRUYTHU_TRUYLINH,TONG_THUNHAP,TRU_BHXH_BHYT,TRU_BHTN,TRU_CDP,GIAMTRU_BANTHAN,SOTIEN_GIACANH,TONG_THUNHAP_TINHTHUE,THUE_TNCN,THUNHAP_THUCNHAN");
    //        b_dt.TableName = "DATA";
    //        Excel_dungchung.ExportTemplate("Templates/ExportMau/ns_tl_bluong.xls", b_dt, null, "ns_tl_bluong");

    //    }
    //    catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    //}

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