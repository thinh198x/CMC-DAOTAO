using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cthuvien;

public partial class f_ns_cb_qly : fmau
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            { 
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/tt/sns_tt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/ns/qt/sns_qt.asmx"));
                ScriptManager.GetCurrent(this).Services.Add(new ServiceReference("~/Service/khud/skhud.asmx"));
                string b_s = this.ResolveUrl("~/App_form/ns/tt/ns_cb_qly" + khac.Fs_runMode() + ".js?v=" + ht_dungchung.b_ver);               
                se.se_nsd b_se = new se.se_nsd();
                string b_ma_dvi = b_se.ma_dvi;
                ScriptManager.RegisterClientScriptInclude(this.Page, this.GetType(), Guid.NewGuid().ToString(), b_s);
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "ns_cb_P_KD('" + khac.Fs_TMUCF(b_s) + "','" + iurl.ClientID + "','" + b_ma_dvi + "');", true);                
                P_NHAN_DROP(); so_the.Focus();
            }
        }
        catch (Exception ex) { form.P_LOI(this, ex.Message); } 
    }
    private void P_NHAN_DROP()
    {
        DataRow drRow;
        DataTable b_dt = ns_tt.Fdt_MA_PHONG_LKE();
        form.P_DROP_BANG(PHONG, b_dt);
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả", "", "", "" }, 0);
        form.P_DROP_BANG(phong_tk, b_dt);

        // NGOẠI NGỮ
        b_dt = new DataTable();
        b_dt = ns_ma.Fdt_NS_MA_NUOC_DR();
        drRow = b_dt.NewRow();
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        NN.DataSource = b_dt; NN.DataBind();
        NN.SelectedValue = "QG001";
        // HÌNH THỨC TRẢ TIỀN
        b_dt = new DataTable();
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("NHAN");
        drRow = b_dt.NewRow();
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        form.P_DROP_BANG(nhan, b_dt);

        // GIỚI TÍNH
        b_dt = new DataTable();
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("GT");
        drRow = b_dt.NewRow();
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        form.P_DROP_BANG(GTINH, b_dt);
        GTINH.SelectedIndex = 1;

        // NƠI CẤP CHỨNG MINH THỨ
        //b_dt = new DataTable();
        //b_dt = ns_ma.Fdt_NS_MA_TT_DR();
        //drRow = b_dt.NewRow();
        //drRow["MA"] = "0";
        //drRow["TEN"] = "";
        //b_dt.Rows.InsertAt(drRow, 0);
        //nc_cmt.DataSource = b_dt; nc_cmt.DataBind();

        // DÂN TỘC
        //b_dt = new DataTable();
        //b_dt = ht_dungchung.Fdt_NS_MA_DT_DR();
        //drRow = b_dt.NewRow();
        //drRow["MA"] = "0";
        //drRow["TEN"] = "";
        //b_dt.Rows.InsertAt(drRow, 0);
        //dantoc.DataSource = b_dt; dantoc.DataBind();

        // TÔN GIÁO
        //b_dt = new DataTable();
        //b_dt = ht_dungchung.Fdt_NS_MA_TG_DR();
        //drRow = b_dt.NewRow();
        //drRow["MA"] = "0";
        //drRow["TEN"] = "";
        //b_dt.Rows.InsertAt(drRow, 0);
        //tongiao.DataSource = b_dt; tongiao.DataBind();

        // TÌNH TRẠNG HÔN NHÂN
        b_dt = new DataTable();
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("HN");
        drRow = b_dt.NewRow(); 
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        form.P_DROP_BANG(tt_honnhan, b_dt);  

        // ĐỐI TƯỢNG CƯ TRÚ
        b_dt = new DataTable();
        b_dt = hts_dungchung.Fdt_CHUNG_LKE("DT_CUTRU");
        form.P_DROP_BANG(dt_cutru, b_dt);

        // LOẠI NHÂN VIÊN
        b_dt = new DataTable();
        b_dt = ht_dungchung.Fdt_HD_MA_LOAI_NV_DR();
        drRow = b_dt.NewRow();
        drRow["MA"] = "0";
        drRow["TEN"] = "";
        b_dt.Rows.InsertAt(drRow, 0);
        //loai_cb.DataSource = b_dt; loai_cb.DataBind();
    }
}
