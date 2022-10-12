using System;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Cthuvien;
using Aspose.Cells;

public partial class f_xem_bc : fmau
{
    DataSet b_kq;
    string b_kieu_in = ""; string b_ma_bc = "";
    CrystalDecisions.CrystalReports.Engine.ReportDocument repo;
    protected void Page_Init(object sender, EventArgs e)
    {
        thumuc.Value = Fs_thumuc();
        try
        {
            string b_md = kytu.C_NVL(Request.QueryString["md"]).ToUpper();
            DataTable b_dt_ct = (DataTable)HttpContext.Current.Session[b_md + "_SS"];
            // Lay so lieu tu tham so
            try { b_kq = bc.Fds_XEM_BC(b_md, ref b_dt_ct); }
            catch (Exception ex) { throw new Exception(ex.Message); }
            b_kieu_in = chuyen.OBJ_S(b_dt_ct.Rows[0]["kieu_in"]);
            string b_ddan, b_ten_rp;
            if (b_kieu_in.IndexOf("E") >= 0 || b_kieu_in == "W")
            {
                // Kiet xuat dac biet
                b_ma_bc = chuyen.OBJ_S(b_dt_ct.Rows[0]["ma_bc"]);
                b_ddan = chuyen.OBJ_S(b_dt_ct.Rows[0]["ddan"]);
                b_ten_rp = chuyen.OBJ_S(b_dt_ct.Rows[0]["ten_rp"]);

                switch (b_ma_bc)
                {
                    case "r_bc_thangquy":
                        Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_bc_thangquy.xlsx", "BANG_QUYETTOAN_THANGQUY");
                        break;
                }
                if (b_ma_bc == "r_ns_bc_sanluong_duan_ANHDAN_excel")
                {
                    XuatBaoCaoAspose(b_kq, b_dt_ct);
                }
                else if (b_ma_bc == "r_nv_nhantien_ck") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_nv_nhantien_ck.xlsx", "BANG_LUONG_CHUYEN_KHOAN");
                else if (b_ma_bc == "r_nv_nhantien_tm") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_nv_nhantien_tm.xlsx", "BANG_LUONG_TIEN_MAT");
                else if (b_ma_bc == "r_bc_ns_biendong_ns") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/ns/r_bc_ns_biendong_ns.xlsx", "BIEN_DONG_QUAN_SO");
                //thuong
                else if (b_ma_bc == "r_bc_th_kq_dg_360") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_th_kq_dg_360.xlsx", "BAO_CAO_TONG_HOP_KET_QUA_DANH_GIA_360");
                else if (b_ma_bc == "r_kqua_dg_360_cnhan") Baocao_aspose360(b_kq, b_dt_ct, "App_rpt/dg/th/r_kqua_dg_360_cnhan.xlsx", "KET_QUA_DANH_GIA_360_DO_CUA_CA_NHAN");
                else if (b_ma_bc == "r_bc_th_kq_dg_360_dtuong") Baocao_asposeDtuong360(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_th_kq_dg_360_dtuong.xlsx", "KET_QUA_DANH_GIA_360_DO_CUA_CA_NHAN");
                else if (b_ma_bc == "r_bc_fte") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_fte.xlsx", "BAO_CAO_FTE");
                else if (b_ma_bc == "r_bc_chamcong") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_chamcong.xlsx", "BAO_CAO_CHAM_CONG");
                else if (b_ma_bc == "r_bc_th_dbien") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_th_dbien.xlsx", "BAO_CAO_TONG_HOP_DINH_BIEN");
                else if (b_ma_bc == "r_bc_vtri_td") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_vtri_td.xlsx", "BAO_CAO_CAC_VI_TRI_TUYEN_DUNG");
                else if (b_ma_bc == "r_bc_uv") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_uv.xlsx", "BAO_CAO_UNG_VIEN");
                else if (b_ma_bc == "r_bc_th_td") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_th_td.xlsx", "BAO_CAO_TONG_HOP_TUYEN_DUNG");
                else if (b_ma_bc == "r_dt_dg_cldt") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dt/r_dt_dg_cldt.xlsx", "BAO_CAO_DANH_GIA_CHAT_LUONG_DAO_TAO");
                //end
                //-Danh gia- Son
                else if (b_ma_bc == "r_dg_bc_kqua_dg") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/dg/r_dg_bc_kqua_dg.xlsx", "BAO_CAO_KET_QUA_DANH_GIA");
                else if (b_ma_bc == "r_dg_bc_cbnv") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/dg/r_dg_bc_cbnv.xlsx", "BAO_CAO_DANH_GIA_THEO_TUNG_CAN_BO_NV");
                //----Danh gia- Son
                //-Tinh luong - Son

                //Tinh luong 
                else if (b_ma_bc == "r_nghiviec_danhsach") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_nghiviec_danhsach.xlsx", "BAO_CAO_DANHSACH_NGHIVIEC");
                else if (b_ma_bc == "r_bc_quyet_toan_thue_nam_hdld") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_quyet_toan_thue_nam_hdld.xlsx", "BAO_CAO_QUYET_TOAN_THUE_NAM_HDLD");
                else if (b_ma_bc == "r_bc_quyet_toan_thue_nam_ko_hdld") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_quyet_toan_thue_nam_ko_hdld.xlsx", "BAO_CAO_QUYET_TOAN_THUE_NAM_KO_HDLD");
                else if (b_ma_bc == "r_hethan_hd_danhsach") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_hethan_hd_danhsach.xlsx", "BAO_CAO_DANHSACH_HETHAN_HOPDONG");
                else if (b_ma_bc == "r_nguoi_pt_danhsach") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_nguoi_pt_danhsach.xlsx", "BAO_CAO_DANHSACH_NGUOI_PHUTHUOC");
                else if (b_ma_bc == "r_bc_dieu_chinh_luong") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_dieu_chinh_luong.xlsx", "BAO_CAO_DANHSACH_DIEUCHINH_LUONG");
                else if (b_ma_bc == "r_bc_dieu_chinh_cdanh") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_dieu_chinh_cdanh.xlsx", "BAO_CAO_DANHSACH_DIEUCHINH_CHUCDANH");
                else if (b_ma_bc == "r_bc_co_cau_lao_dong") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_co_cau_lao_dong.xlsx", "BAO_CAO_CO_CAU_LAO_DONG");
                else if (b_ma_bc == "r_bc_bang_luong_in") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_bc_bang_luong_in.xlsx", "BAO_CAO_BANG_LUONG_IN");
                else if (b_ma_bc == "r_bc_bang_luong_sosanh") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_bc_bang_luong_sosanh.xlsx", "BAO_CAO_BANG_LUONG_SOSANH");
                else if (b_ma_bc == "r_tl_bangluong_thang") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/tl/bl/r_tl_bangluong_thang.xlsx", "BAO_CAO_BANG_LUONG_THANG");
                else if (b_ma_bc == "r_bc_phan_bo_luong") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dg/th/r_bc_phan_bo_luong.xlsx", "BAO_CAO_DANHSACH_PHAN_BO_LUONG");
                // Bảo hiểm
                else if (b_ma_bc == "r_dsach_dong_bh") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/cd/bh/r_dsach_dong_bh.xlsx", "BANG_THEO_DOI_BAO_HIEM");
                // Đào tạo
                else if (b_ma_bc == "r_dt_khdt_nam") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dt/r_dt_khdt_nam.xlsx", "BAO_CAO_KE_HOACH_DAO_TAO_NAM");
                else if (b_ma_bc == "r_dt_master_ld") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dt/r_dt_master_ld.xlsx", "BAO_CAO_MASTER_LD");
                else if (b_ma_bc == "r_dt_th_cluong_dt") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dt/r_dt_th_cluong_dt.xlsx", "BAO_CAO_TONG_HOP_CLUONG_DT");
                else if (b_ma_bc == "r_dt_kpi_dt") Baocao_aspose(b_kq, b_dt_ct, "App_rpt/dt/r_dt_kpi_dt.xlsx", "BAO_CAO_KPI_DAO_TAO");
                else
                {
                    if (P_XUAT_KH(b_md, b_ma_bc, b_kieu_in, b_ddan, b_ten_rp)) return;
                }
            }
            else
            {
                DataTable b_dt_ten = b_kq.Tables["TENBC"].Copy(), b_dt_tso = b_kq.Tables["TSO"].Copy(), b_dt_dl = b_kq.Tables[0].Copy();
                if (bang.Fb_TRANG(b_dt_dl)) { throw new Exception("loi:Không có số liệu:loi"); }
                b_ddan = chuyen.OBJ_S(b_dt_ten.Rows[0]["ddan"]); b_ten_rp = chuyen.OBJ_S(b_dt_ten.Rows[0]["ten"]);
                // Xuat ra crsytal
                DataTable b_dt_tso_sub = new DataTable("TSO_SUB");
                if (b_kq.Tables.Contains("TSO_SUB"))
                {
                    b_dt_tso_sub = b_kq.Tables["TSO_SUB"].Copy();
                    b_kq.Tables.Remove("TSO_SUB"); b_kq.AcceptChanges();
                }
                // Thong tin day vao crystal
                repo = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                b_ddan = Server.MapPath(b_ddan + b_ten_rp + ".rpt");
                this.Title = this.Title + " - tên file report: " + b_ten_rp;
                if (File.Exists(b_ddan) == false) throw new Exception("loi:Không có file " + b_ten_rp + ":loi");
                repo.Load(b_ddan);
                repo.ReportOptions.EnableSaveDataWithReport = false;
                /// Xử lý trường hợp có nhiều Table vào Datasource
                /// Tên bảng phải trùng tên với tên bảng trong Rp
                if (repo.Subreports.Count == 0 && b_kq.Tables.Count > 3) repo.SetDataSource(b_kq);
                else if (b_dt_ten.Rows.Count == 1 && b_kq.Tables.Count > 3) repo.SetDataSource(b_kq);
                else repo.SetDataSource(b_dt_dl);
                try
                {
                    bang.P_BO_HANG(ref b_dt_ten, "ten", b_ten_rp);
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
                //Hung xu ly them parametter thumuc - dùng để truyền vào các repo có sử dụng hyperlink (để click chuyển sang màn hình nhập chứng từ)
                for (int i = 0; i < repo.ParameterFields.Count; i++)
                {
                    if (repo.ParameterFields[i].Name.ToUpper() == "THUMUC") { repo.SetParameterValue(i, thumuc.Value); }
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
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message ); }
    }
    private void XuatBaoCaoAspose(DataSet b_ds, DataTable b_dt_ct)
    {
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        try
        {
            string b_tungay = b_dt_ct.Rows[0]["NGAYD"].ToString();
            string b_denngay = b_dt_ct.Rows[0]["NGAYC"].ToString();
            string b_nam = b_denngay.Substring(6, 4);
            string sPathTemplate = "/App_rpt/ns/bc_sanluong_duan_2.xls";
            string strRoot = HttpContext.Current.Server.MapPath("~");
            string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
            Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            Aspose.Cells.Style style2 = new Aspose.Cells.Style();
            style = cells2["D2"].GetStyle();
            style2 = cells2["F2"].GetStyle();

            b_dt_0 = b_ds.Tables[2];
            b_dt_1 = b_ds.Tables[1];
            b_dt_2 = b_ds.Tables[3];
            int iStartRow = 5;
            string b_ma_da = "";
            string b_ma_phong = "";
            for (int i = 0; i < b_dt_0.Rows.Count; i++)
            {
                cells2.InsertRows(iStartRow, 1, true);
                cells2[iStartRow - 1, 0].PutValue(b_dt_0.Rows[i]["MA_DU_AN"].ToString());
                cells2[iStartRow - 1, 1].PutValue(b_dt_0.Rows[i]["TEN_DU_AN"].ToString());
                if (!string.IsNullOrEmpty(b_dt_0.Rows[i]["TONG_GIO"].ToString()))
                    cells2[iStartRow - 1, 4].PutValue(chuyen.OBJ_N(b_dt_0.Rows[i]["TONG_GIO"].ToString()));
                cells2[iStartRow - 1, 5].PutValue(chuyen.OBJ_N(b_dt_0.Rows[i]["TONG_GHINHAN"].ToString()));
                cells2[iStartRow - 1, 6].PutValue(chuyen.OBJ_N(b_dt_0.Rows[i]["TONG_GHINHAN_LK"].ToString()));
                cells2[iStartRow - 1, 7].PutValue(chuyen.OBJ_N(b_dt_0.Rows[i]["TONG_GHINHAN_CL"].ToString()));
                b_ma_da = b_dt_0.Rows[i]["MA_DU_AN"].ToString();
                DataRow[] result = b_dt_1.Select("MA_DU_AN ='" + b_ma_da + "'");
                //if (result.Length > 0)
                iStartRow = iStartRow + 1;
                for (int j = 0; j < result.Length; j++)
                {
                    cells2.InsertRows(iStartRow, 1, true);
                    cells2[iStartRow - 1, 2].PutValue(result[j]["TEN_PHONG"].ToString());
                    cells2[iStartRow - 1, 3].PutValue(result[j]["PM"].ToString());
                    cells2[iStartRow - 1, 4].PutValue(chuyen.OBJ_N(result[j]["TONG_GIO"].ToString()));

                    cells2[iStartRow - 1, 5].PutValue(chuyen.OBJ_N(result[j]["TONG_GHINHAN"].ToString()));
                    cells2[iStartRow - 1, 6].PutValue(chuyen.OBJ_N(result[j]["TONG_GHINHAN_LK"].ToString()));
                    cells2[iStartRow - 1, 7].PutValue(chuyen.OBJ_N(result[j]["TONG_GHINHAN_CL"].ToString()));

                    b_ma_phong = result[j]["MA_PHONG"].ToString();
                    DataRow[] result2 = b_dt_2.Select("ma_phong ='" + b_ma_phong + "' AND MA_DU_AN = '" + b_ma_da + "'");
                    iStartRow = iStartRow + 1;
                    for (int k = 0; k < result2.Length; k++)
                    {
                        cells2.InsertRows(iStartRow, 1, true);
                        cells2[iStartRow - 1, 2].PutValue(result2[k]["HO_TEN"].ToString());
                        cells2[iStartRow - 1, 2].SetStyle(style);
                        cells2[iStartRow - 1, 4].PutValue(chuyen.OBJ_N(result2[k]["TONG_GIO"].ToString()));
                        cells2[iStartRow - 1, 5].PutValue(chuyen.OBJ_N(result2[k]["TONG_GHINHAN"].ToString()));
                        cells2[iStartRow - 1, 6].PutValue(chuyen.OBJ_N(result2[k]["TONG_GHINHAN_LK"].ToString()));
                        cells2[iStartRow - 1, 7].PutValue(chuyen.OBJ_N(result2[k]["TONG_GHINHAN_CL"].ToString()));
                        iStartRow = iStartRow + 1;
                    }
                }
            }
            cells2["D2"].SetStyle(style2);
            cells2["A2"].PutValue("Từ ngày " + b_tungay + " đến ngày " + b_denngay + " năm " + b_nam);
            wBook.CalculateFormula();
            wBook.Save(HttpContext.Current.Response, "baocaosanluong_duan.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
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
    private bool P_XUAT_KH(string b_md, string b_ma_bc, string b_kieu_in, string b_ddan, string b_ten_rp)
    {
        string b_sout = "~/Outputs/"; DataRow b_dr = b_kq.Tables[0].Rows[0];
        string b_tenrp = chuyen.OBJ_S(b_dr["ten"]);
        if (b_kieu_in == "E")
        {
            ht_bc.P_XUAT_EXCEL(b_ddan, ref b_sout, b_tenrp, b_kq);
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

    private void Baocao_aspose(DataSet b_ds, DataTable b_dt_ct, string b_filename, string b_tenbc)
    {
        try
        {
            DataTable b_dt = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            Excel_dungchung.ExportTemplate(b_filename, b_ds, null, b_tenbc);
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void Baocao_aspose360(DataSet b_ds, DataTable b_dt_ct, string b_filename, string b_tenbc)
    {
        try
        {
            DataTable b_dt = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            ExportTemplate360(b_filename, b_ds, null, b_tenbc);
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    private void Baocao_asposeDtuong360(DataSet b_ds, DataTable b_dt_ct, string b_filename, string b_tenbc)
    {
        try
        {
            DataTable b_dt = b_ds.Tables[0];
            b_dt.TableName = "DATA";
            ExportTemplateDtuong360(b_filename, b_ds, null, b_tenbc);
        }
        catch (Exception) { form.P_LOI(this, "loi:File export không tồn tại:loi"); }
    }
    public static bool ExportTemplate360(string sReportFileName, DataSet dsData, DataTable dtVariable, string filename)
    {
        // WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            Workbook workbook = new Workbook(filePath);
            Aspose.Cells.Worksheet wSheet2 = workbook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            Aspose.Cells.Style style2 = new Aspose.Cells.Style();
            Aspose.Cells.Style style3 = new Aspose.Cells.Style();
            style2 = cells2["J6"].GetStyle();
            style3 = cells2["J7"].GetStyle();
            cells2["J6"].SetStyle(style3);
            int tongcot = dsData.Tables[0].Columns.Count;
            int tongdong = dsData.Tables[0].Rows.Count;
            DataTable b_data = dsData.Tables[0];
            var istartColumn = 0;
            var istartRow = 15;
            for (int i = 0; i < tongdong; i++)
            {
                cells2.InsertRows(istartRow, 1, true);
                for (int j = 0; j < tongcot; )
                {
                    cells2[istartRow, istartColumn].PutValue(b_data.Rows[i][j].ToString());
                    if (j == 1) istartColumn = 4; else istartColumn = istartColumn + 1;
                    j = j + 1;
                }
                istartColumn = 0;
                istartRow = istartRow + 1;
            }
            if (dsData.Tables[0] != null)
            {
                string dongdau = "A"; string dongcuoi = "I";
                double tong = 0;
                int dem = 3;
                // int j = 0;
                int intRows = dsData.Tables[0].Rows.Count;
                for (int i = 15; i <= intRows - 1 + 15; i++)
                {
                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "II. KHÁCH HÀNG ÐÁNH GIÁ" || dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "III. KẾT QUẢ CHUNG")
                    {
                        dongdau = dongdau + (i + 1).ToString();
                        dongcuoi = dongcuoi + (i + 1).ToString();
                        Aspose.Cells.Range rng1 = workbook.Worksheets[0].Cells.CreateRange(dongdau, dongcuoi);
                        rng1.Merge();
                        dongdau = "A"; dongcuoi = "I";
                        //indam 
                        cells2[i, 0].SetStyle(style2);
                    }

                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "")
                    {
                        //indam
                        style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left;
                        style.Font.IsBold = true;
                        style.Font.Size = 9;
                        cells2[i, 1].SetStyle(style);
                    }

                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "II. KHÁCH HÀNG ÐÁNH GIÁ" || dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "III. KẾT QUẢ CHUNG")
                    {
                        if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "III. KẾT QUẢ CHUNG")
                        {
                            dem = dem + 1;
                            cells2[dem, 20].PutValue(tong);
                            tong = 0;
                        }
                    }
                    else
                    {
                        if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() != "")
                        {
                            tong = tong + double.Parse(dsData.Tables[0].Rows[i - 15]["diem_tb"].ToString());
                        }
                        else
                        {
                            dem = dem + 1;
                            cells2[dem, 20].PutValue(tong);
                            tong = 0;
                        }

                    }
                }
            }
            // Insert Thong tin can bo:
            cells2[5, 2].PutValue(dsData.Tables[1].Rows[0][0].ToString()); // Ten can bo
            cells2[6, 2].PutValue(dsData.Tables[1].Rows[0][1].ToString()); // Ten chuc danh
            cells2[7, 2].PutValue(dsData.Tables[1].Rows[0][2].ToString()); // Ten don vi
            cells2[9, 2].PutValue(dsData.Tables[1].Rows[0][8].ToString()); // Ngay vao
            cells2[10, 2].PutValue(dsData.Tables[1].Rows[0][3].ToString()); // Ngay vao
            cells2[5, 7].PutValue(dsData.Tables[1].Rows[0][4].ToString()); // So luong cbnv moi danh gia
            cells2[6, 7].PutValue(dsData.Tables[1].Rows[0][5].ToString()); // So luong cbnv thuc hien danh gia
            cells2[9, 7].PutValue(dsData.Tables[1].Rows[0][6].ToString()); // So luong khach hang thuc hien danh gia 
            cells2[13, 9].PutValue(dsData.Tables[1].Rows[0][7].ToString()); // diem 
            //.......
            cells2.DeleteRow(14);
            workbook.CalculateFormula();
            workbook.Save(HttpContext.Current.Response, filename + ".xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { throw ex; } return true;
    }
    public static bool ExportTemplateDtuong360(string sReportFileName, DataSet dsData, DataTable dtVariable, string filename)
    {
        // WorkbookDesigner designer = default(WorkbookDesigner);
        try
        {
            string strRoot = HttpContext.Current.Server.MapPath("~");
            Aspose.Cells.License l = new Aspose.Cells.License();
            string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
            l.SetLicense(strLicense);
            string filePath = strRoot + sReportFileName;
            if (!File.Exists(filePath))
            {
                return false;
            }
            Workbook workbook = new Workbook(filePath);
            Aspose.Cells.Worksheet wSheet2 = workbook.Worksheets[0];
            Aspose.Cells.Cells cells2 = wSheet2.Cells;
            Aspose.Cells.Style style = new Aspose.Cells.Style();
            Aspose.Cells.Style style2 = new Aspose.Cells.Style();
            Aspose.Cells.Style style3 = new Aspose.Cells.Style();
            style2 = cells2["J6"].GetStyle();
            style3 = cells2["J7"].GetStyle();
            cells2["J6"].SetStyle(style3);
            int tongcot = dsData.Tables[0].Columns.Count;
            int tongdong = dsData.Tables[0].Rows.Count;
            DataTable b_data = dsData.Tables[0];
            var istartColumn = 0;
            var istartRow = 15;
            for (int i = 0; i < tongdong; i++)
            {
                cells2.InsertRows(istartRow, 1, true);
                for (int j = 0; j < tongcot; )
                {
                    cells2[istartRow, istartColumn].PutValue(b_data.Rows[i][j].ToString());
                    if (j == 1) istartColumn = 4; else istartColumn = istartColumn + 1;
                    j = j + 1;
                }
                istartColumn = 0;
                istartRow = istartRow + 1;
            }
            if (dsData.Tables[0] != null)
            {
                double tong = 0;
                int dem = 3;
                string dongdau = "A"; string dongcuoi = "I";
                int intRows = dsData.Tables[0].Rows.Count;
                for (int i = 15; i <= intRows - 1 + 15; i++)
                {
                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "II. CÂU HỎI MỞ RỘNG")
                    {
                        dongdau = dongdau + (i + 1).ToString();
                        dongcuoi = dongcuoi + (i + 1).ToString();
                        Aspose.Cells.Range rng1 = workbook.Worksheets[0].Cells.CreateRange(dongdau, dongcuoi);
                        rng1.Merge();
                        dongdau = "A"; dongcuoi = "I";
                        //indam
                        style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left;
                        style.Font.IsBold = true;
                        style.Font.Size = 9;
                        cells2[i, 0].SetStyle(style2);
                    }
                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "")
                    {
                        //indam
                        style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Left;
                        style.Font.IsBold = true;
                        style.Font.Size = 9;
                        cells2[i, 1].SetStyle(style);
                    }
                    if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() == "II. CÂU HỎI MỞ RỘNG")
                    {
                        
                            dem = dem + 1;
                            cells2[dem, 20].PutValue(tong);
                            tong = 0; 
                    }
                    else
                    {
                        if (dsData.Tables[0].Rows[i - 15]["STT"].ToString() != "")
                        {
                            tong = tong + double.Parse(dsData.Tables[0].Rows[i - 15]["diem_tb"].ToString());
                        }
                        else
                        {
                            dem = dem + 1;
                            cells2[dem, 20].PutValue(tong);
                            tong = 0;
                        }

                    }
                }
            }
            // Insert Thong tin can bo:
            cells2[5, 2].PutValue(dsData.Tables[1].Rows[0][0].ToString()); // Ten can bo
            cells2[6, 2].PutValue(dsData.Tables[1].Rows[0][1].ToString()); // Ten chuc danh
            cells2[7, 2].PutValue(dsData.Tables[1].Rows[0][2].ToString()); // Ten don vi
            cells2[8, 2].PutValue(dsData.Tables[1].Rows[0][8].ToString()); // Ngay vao 
            cells2[9, 2].PutValue(dsData.Tables[1].Rows[0][3].ToString()); // ten ky danh gia

            cells2[5, 7].PutValue(dsData.Tables[1].Rows[0][4].ToString()); // So luong cbnv moi danh gia
            cells2[6, 7].PutValue(dsData.Tables[1].Rows[0][5].ToString()); // So luong cbnv thuc hien danh gia 
            cells2[13, 9].PutValue(dsData.Tables[1].Rows[0][6].ToString()); // diem 
            //.......
            cells2.DeleteRow(14);
            workbook.CalculateFormula();
            workbook.Save(HttpContext.Current.Response, filename + ".xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));
        }
        catch (Exception ex) { throw ex; } return true;
    }
}
