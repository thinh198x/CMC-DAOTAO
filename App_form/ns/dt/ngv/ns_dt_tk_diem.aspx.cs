using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_dt_tk_diem : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/dt/sns_dt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/ma/sns_ma_ch.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/dt/ngv/ns_dt_tk_diem" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), this.ResolveUrl("~/App_form/Bugger.js"));
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_dt_tk_diem_P_KD();", true);
                //if (se.Fs_DUYET() != "IE") kthuoc.Value = "1200,820";

                this.P_NAM_DROP();
                this.P_THANG_DROP();
                this.TaoLuoiKetQuaDaoTao();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); }
    }

    private void P_NAM_DROP()
    {        
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        string b_nam = DateTime.Now.ToString("yyyy");
        for (int i = 0; i <= 5; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { chuyen.OBJ_I(b_nam) + i, chuyen.OBJ_S(chuyen.OBJ_I(b_nam) + i) });
        }
        se.P_TG_LUU(this.Title, "DT_NAM", b_dt); 
        //form.P_LIST_BANG(DR_nam, b_dt);
        //form.P_LKE_DAT(DR_nam, b_dt, 0, "ma,ten");
    }

    private void P_THANG_DROP()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG(new string[] { "ma", "ten" }, "NS");
        //bang.P_THEM_HANG(ref b_dt, new object[] { 0, "--chọn tháng--"});
        for (int i = 1; i <= 12; i++)
        {
            bang.P_THEM_HANG(ref b_dt, new object[] { i, "Tháng " + i });
        }
        se.P_TG_LUU(this.Title, "DT_THANG", b_dt);         
        //form.P_LIST_BANG(DR_thang, b_dt);
        //form.P_LKE_DAT(DR_thang, b_dt, 0, "ma,ten");
    }


    private void TaoLuoiKetQuaDaoTao()
    {

        int b_so_mon_max = ns_dt.Fn_NS_DT_TK_MON_MAX();
        this.so_mon_max.Value = b_so_mon_max.ToString();
        int b_index = 0;
        string b_cot = "so_the,ten,phong,dtdd,email";
        for (int i = 0; i < b_so_mon_max; i++)
        {
            // ngày thi
            TemplateField ngayThiField = new TemplateField();
            ngayThiField.ShowHeader = true;
            ngayThiField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, "Ngày thi " + (i+1), "", "", "", "", "");
            ngayThiField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "", "ngay_thi_" + i, "Cthuvien.ngay", "css_Gma_r", "X", "");
            ngayThiField.HeaderStyle.Width = Unit.Pixel(80);
            ngayThiField.ItemStyle.CssClass = "css_ma_c";
            GR_kq.Columns.Insert(b_index + 6, ngayThiField);
            b_index++;
            // điểm
            TemplateField diemField = new TemplateField();
            diemField.ShowHeader = true;
            diemField.HeaderTemplate = new GridViewTemplate(DataControlRowType.Header, "Điểm môn " + (i + 1), "", "", "", "", "");
            diemField.ItemTemplate = new GridViewTemplate(DataControlRowType.DataRow, "", "diem_" + i, "Cthuvien.so", "css_Gma_r", "X", "", "K");
            diemField.HeaderStyle.Width = Unit.Pixel(80);
            diemField.ItemStyle.CssClass = "css_ma_c";
            GR_kq.Columns.Insert(b_index + 6, diemField);
            b_index++;
            // trọng số
            BoundField trongSoField = new BoundField();
            trongSoField.HeaderText = "Trọng số";
            trongSoField.ShowHeader = true;
            trongSoField.DataField = "tr_so_" + i;
            trongSoField.HeaderStyle.Width = Unit.Pixel(60);
            trongSoField.ItemStyle.CssClass = "css_ma_c";
            GR_kq.Columns.Insert(b_index + 6, trongSoField);
            b_index++;
            b_cot += "," + "ngay_thi_" + i + ",diem_" + i + ",tr_so_" + i;           
        }
        b_cot += ",dtb,kq,cp_htro";
        GR_kq.cot = b_cot;
    }

    protected void FileMau_Click(object sender, EventArgs e)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = ns_ma.Fdt_PNS_MA_CHUNG_DR("KQDTNB");
        b_dt.TableName = "KETQUA";
        b_ds.Tables.Add(b_dt);

        DataTable b_dt_mon = bang.Fdt_TAO_BANG("ten,ma", "S,S");
        string[] monThi = this.ten_mon.Value.Split((char)1);
        for (int i = 0; i < monThi.Length; i++)
        {
            bang.P_THEM_HANG(ref b_dt_mon, new object[]{"Ngày thi " + (i+1),"ngay_thi_" + i});
            bang.P_THEM_HANG(ref b_dt_mon, new object[] { monThi[i], "diem_" + i });
        }
        b_dt_mon.TableName = "MONTHI";
        b_ds.Tables.Add(b_dt_mon);

        Excel_dungchung.ExportTemplate("Templates/importdt/ns_dt_tk_diem.xls", b_ds, null, "ns_dt_tk_diem");
    }
}