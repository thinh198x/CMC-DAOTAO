using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;
using Cthuvien;

/// <summary>
/// Summary description for ns_bc
/// </summary>
public class ns_bc
{
    #region BÁO CÁO CŨ KHÔNG SỰ DỤNG CHO CAPITALHOUSE
    public static DataSet Fds_NS_TDOI_TT_HDLD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE_S(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])) }, "PNS_HD_BC");
        // ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });
        // tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ma_dvi, b_se.dchi_dvi });

        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_TKE_LDONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, 2, "BNS_TKE_LDONG");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        string b_loai_bc = "";
        DataRow b_dr_1 = b_dt_0.Rows[0];
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_ct, b_se.ten_dvi, b_loai_bc, b_dr_1["b_ld_dk_bc"],
            b_dr_1["b_ld_t_bc"],b_dr_1["b_ld_g_bc"],b_dr_1["b_ld_ck_bc"],b_dr_1["b_ld_t_nb"],b_dr_1["b_ld_g_nb"],b_dr_1["b_ld_gvon"]});
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NSTL_DSDT_BHYT(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, 2, "BNSTL_DSDT_BHYT");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        DataRow b_dr_1 = b_dt_0.Rows[0];
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_dvi, b_se.ma_dvi, b_se.dchi_dvi, b_dr_1["b_dtuong"],
            b_dr_1["b_ngay"],b_dr_1["b_thang"],b_dr_1["dky_1"],b_dr_1["dky_2"],b_dr_1["ps_t_1"],b_dr_1["ps_t_2"],
            b_dr_1["ps_g_1"],b_dr_1["ps_g_2"],b_dr_1["cky_1"],b_dr_1["cky_2"],b_dr_1["the_bhyt"],b_dr_1["the_nt"]});
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NSTL_DSLD_DCHINH_HSO(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, 2, "BNSTL_DSLD_DCHINH_HSO");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        DataRow b_dr_1 = b_dt_0.Rows[0];
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_dvi, b_se.ma_dvi, b_se.dchi_dvi, b_dr_1["b_so_cvan"],
            b_dr_1["b_ngay"],b_dr_1["b_thang"],b_dr_1["b_nam"],b_dr_1["b_the_bhyt"],b_dr_1["b_the_nt"],b_dr_1["b_ngay_d"],b_dr_1["b_ngay_c"]});
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NSTL_DS_CB_NLUONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE_S(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, "BNSTL_DS_CB_NLUONG");

        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_ct, b_se.ten_dvi });
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_DSLD_DNGHI_CAP_BH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE_S(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, "BNS_DSLD_DNGHI_CAP_BH");

        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi });
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_DSLD_DONG_BH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {b_dr["ma_dvi"], chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["phong"] }, 2, "BNS_DSLD_DONG_BH");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".rpt", "") });

        //tham so cua bao cao
        DataRow b_dr_1 = b_dt_0.Rows[0];
        bang.P_THEM_COL(ref b_dt_2, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_2, "ten", new object[] { b_se.ten_dvi, b_se.ma_dvi, b_se.dchi_dvi, b_dr_1["b_sld_bhyt"],
            b_dr_1["b_sld_bhtn"],b_dr_1["b_sld_bhxh"],b_dr_1["b_ql_bhyt"],b_dr_1["b_ql_bhtn"],b_dr_1["b_ql_bhxh"],b_dr_1["b_tien_bhyt"],b_dr_1["b_tien_bhtn"],
            b_dr_1["b_tien_bhxh"],b_dr_1["b_tien_dl_bhyt"],b_dr_1["b_tien_dl_bhtn"],b_dr_1["b_tien_dl_bhxh"],b_dr_1["b_tien_dc_bhyt"],b_dr_1["b_tien_dc_bhtn"],b_dr_1["b_tien_dc_bhxh"],
            b_dr_1["b_mso_cap"],b_dr_1["b_tu_so"],b_dr_1["b_den_so"],b_dr_1["b_so_to_khai"],b_dr_1["b_the_bhyt"],b_dr_1["b_the_bhyt_nt"],b_dr_1["b_hsd_tu"],b_dr_1["b_hsd_den"]});
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    private static System.Byte[] LoadImage(string FilePath)
    {
        FileStream fs = new FileStream(FilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        byte[] Image = new byte[fs.Length];
        fs.Read(Image, 0, Convert.ToInt32(fs.Length));
        fs.Close();
        return Image;
    }
    public static DataSet Fds_NS_BC_SYLL(DataTable b_dt_tso, DataTable b_dt_ten)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(),
            b_dt_2 = new DataTable(), b_dt_cmnv = new DataTable(), b_dt_hdct = new DataTable(),
            b_dt_ddls_a = new DataTable(), b_dt_ddls_b = new DataTable(), b_dt_qhnn_a = new DataTable(),
            b_dt_qhnn_b = new DataTable(), b_dt_qhgd = new DataTable(), b_dt_kte_a = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(b_dr["so_the"], 10, "BNS_SYLL");

        // Ten bao cao 
        b_dt_2 = b_dt_ten.Copy();
        b_dt_2.TableName = "TENBC"; b_dt_2.AcceptChanges();

        // Tham so cua bao cao
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        DataRow b_dr_1 = b_dt_0.Rows[0];
        string b_gtinh = b_dr_1["c2"].ToString().Equals("NAM") ? "Nam" : "Nữ";
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ten" });
        bang.P_THEM_HANG(ref b_dt_1, "ten", new object[] { b_se.ten_ct, b_se.ten_dvi, b_dr["so_the"], b_dr_1["c57"], 
            b_dr_1["c1"], b_gtinh, b_dr_1["c3"], b_dr_1["c4"], b_dr_1["c5"], b_dr_1["c6"], b_dr_1["c7"], 
            b_dr_1["c8"], b_dr_1["c9"], b_dr_1["c10"], b_dr_1["c11"], b_dr_1["c12"], b_dr_1["c13"], b_dr_1["c14"], 
            b_dr_1["c15"], b_dr_1["c16"], b_dr_1["c17"], b_dr_1["c18"], b_dr_1["c19"], b_dr_1["c20"], b_dr_1["c21"], 
            b_dr_1["c22"], b_dr_1["c23"], b_dr_1["c24"], b_dr_1["c25"], b_dr_1["c26"], b_dr_1["c27"], b_dr_1["c28"], 
            b_dr_1["c29"], b_dr_1["c30"], b_dr_1["c31"], b_dr_1["c32"], b_dr_1["c33"], b_dr_1["c34"], b_dr_1["c35"], 
            b_dr_1["c36"], b_dr_1["c37"], b_dr_1["c38"], b_dr_1["c39"], b_dr_1["c40"], b_dr_1["c41"], b_dr_1["c42"], 
            b_dr_1["c43"], b_dr_1["c44"], b_dr_1["c45"], b_dr_1["c46"], b_dr_1["c47"], b_dr_1["c48"], b_dr_1["c49"], 
            b_dr_1["c50"], b_dr_1["c51"], b_dr_1["c52"], b_dr_1["c53"], b_dr_1["c54"], b_dr_1["c55"], b_dr_1["c56"], 
            b_dr_1["c57"]});
        b_dt_1.TableName = "TSO"; b_dt_1.AcceptChanges();

        // Chuyen mon nghiep vu
        b_dt_cmnv = b_ds_kq.Tables[1].Copy();
        b_dt_cmnv.TableName = "r_ns_syll_sub_cmnv"; b_dt_cmnv.AcceptChanges();

        // Hoat dong cong tac
        b_dt_hdct = b_ds_kq.Tables[2].Copy();
        b_dt_hdct.TableName = "r_ns_syll_sub_hdct"; b_dt_hdct.AcceptChanges();

        // Dac diem lich su ban than (a)
        b_dt_ddls_a = b_ds_kq.Tables[3].Copy();
        b_dt_ddls_a.TableName = "r_ns_syll_sub_ddls_a"; b_dt_ddls_a.AcceptChanges();

        // Dac diem lich su ban than (b)
        b_dt_ddls_b = b_ds_kq.Tables[4].Copy();
        b_dt_ddls_b.TableName = "r_ns_syll_sub_ddls_b"; b_dt_ddls_b.AcceptChanges();

        // Quan he voi nuoc ngoai (a)
        b_dt_qhnn_a = b_ds_kq.Tables[5].Copy();
        b_dt_qhnn_a.TableName = "r_ns_syll_sub_qhnn_a"; b_dt_qhnn_a.AcceptChanges();

        // Quan he voi nuoc ngoai (b)
        b_dt_qhnn_b = b_ds_kq.Tables[6].Copy();
        b_dt_qhnn_b.TableName = "r_ns_syll_sub_qhnn_b"; b_dt_qhnn_b.AcceptChanges();

        // Quan he gia dinh
        b_dt_qhgd = b_ds_kq.Tables[7].Copy();
        b_dt_qhgd.TableName = "r_ns_syll_sub_qhgd"; b_dt_qhgd.AcceptChanges();

        // Qua trinh luong cua ban than
        b_dt_kte_a = b_ds_kq.Tables[8].Copy();
        b_dt_kte_a.TableName = "r_ns_syll_sub_kte_a"; b_dt_kte_a.AcceptChanges();

        b_dt = b_ds_kq.Tables[9].Copy();
        string b_iurl = System.Web.HttpContext.Current.Server.MapPath(b_dt.Rows[0][0].ToString());
        if (!File.Exists(b_iurl))
            b_iurl = System.Web.HttpContext.Current.Server.MapPath("~/images/no_image.png");
        b_dt.Columns.Remove("iurl");
        b_dt.Columns.Add("anh", typeof(System.Byte[]));
        DataRow b_dr_2 = b_dt.NewRow();
        b_dr_2["anh"] = LoadImage(b_iurl);
        bang.P_BO_HANG(ref b_dt, 0);
        b_dt.Rows.Add(b_dr_2);
        b_dt.AcceptChanges();

        b_ds.Tables.Add(b_dt.Copy()); b_ds.Tables.Add(b_dt_cmnv.Copy()); b_ds.Tables.Add(b_dt_hdct.Copy());
        b_ds.Tables.Add(b_dt_ddls_a.Copy()); b_ds.Tables.Add(b_dt_ddls_b.Copy()); b_ds.Tables.Add(b_dt_qhnn_a.Copy());
        b_ds.Tables.Add(b_dt_qhnn_b.Copy()); b_ds.Tables.Add(b_dt_qhgd.Copy()); b_ds.Tables.Add(b_dt_kte_a.Copy());
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        DataTable b_dt_nvm = new DataTable(), b_dt_thaydoihd = new DataTable(), b_dt_phucap = new DataTable(),
            b_dt_truylinh = new DataTable(), b_dt_truythu = new DataTable(), b_dt_trocap = new DataTable(), b_dt_thoiviec = new DataTable(),
            b_dt_dilamlai = new DataTable(), b_dt_thaydoiluong = new DataTable(), b_dt_dongbh = new DataTable(), b_dt_kodongbh = new DataTable(),
            b_dt_nghikoluong = new DataTable(), b_dt_bonhiem = new DataTable(), b_dt_khenthuong = new DataTable(), b_dt_kyluat = new DataTable(),
            b_dt_thuyenchuyen = new DataTable(), b_dt_thaisan = new DataTable(), b_dt_congtac = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0]; int b_ngayd = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])); int b_ngayc = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"]));
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_ngayd, b_ngayc }, 18, "PNS_BC_TDNS");

        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();

        // thong tin nhan vien moi
        b_dt_nvm = b_ds_kq.Tables[0].Copy();
        b_dt_nvm.TableName = "NVM"; b_dt_nvm.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_nvm, "nsinh");
        // thay doi thời hạn hop dong lao dong
        b_dt_thaydoihd = b_ds_kq.Tables[1].Copy();
        b_dt_thaydoihd.TableName = "THD"; b_dt_thaydoihd.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_thaydoihd, "thoihancu,thoihanmoi");
        // phu cap
        b_dt_phucap = b_ds_kq.Tables[2].Copy();
        b_dt_phucap.TableName = "PC"; b_dt_phucap.AcceptChanges();
        //truy lĩnh lương
        b_dt_truylinh = b_ds_kq.Tables[3].Copy();
        b_dt_truylinh.TableName = "TLINH"; b_dt_truylinh.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_truylinh, "thoigian");
        //truy thu lương
        b_dt_truythu = b_ds_kq.Tables[4].Copy();
        b_dt_truythu.TableName = "TTHU"; b_dt_truythu.AcceptChanges();
        //trợ cấp thôi việc
        b_dt_trocap = b_ds_kq.Tables[5].Copy();
        b_dt_trocap.TableName = "TCAPTV"; b_dt_trocap.AcceptChanges();
        // thông tin thôi việc
        b_dt_thoiviec = b_ds_kq.Tables[6].Copy();
        b_dt_thoiviec.TableName = "TV"; b_dt_thoiviec.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_thoiviec, "ngay");
        // nghỉ đi làm lại
        b_dt_dilamlai = b_ds_kq.Tables[7].Copy();
        b_dt_dilamlai.TableName = "DLL"; b_dt_dilamlai.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_dilamlai, "ngay");
        //thay đổi lương, hơp đồng lao động
        b_dt_thaydoiluong = b_ds_kq.Tables[8].Copy();
        b_dt_thaydoiluong.TableName = "TDL"; b_dt_thaydoiluong.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_thaydoiluong, "ngayd");
        // trích đống bảo hiểm
        b_dt_dongbh = b_ds_kq.Tables[9].Copy();
        b_dt_dongbh.TableName = "DBH"; b_dt_dongbh.AcceptChanges();
        //không đóng bảo hiểm
        b_dt_kodongbh = b_ds_kq.Tables[10].Copy();
        b_dt_kodongbh.TableName = "KBH"; b_dt_kodongbh.AcceptChanges();
        // nghỉ không lương
        b_dt_nghikoluong = b_ds_kq.Tables[11].Copy();
        b_dt_nghikoluong.TableName = "NKL"; b_dt_nghikoluong.AcceptChanges();
        // bổ nhiệm
        b_dt_bonhiem = b_ds_kq.Tables[12].Copy();
        b_dt_bonhiem.TableName = "BN"; b_dt_bonhiem.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_bonhiem, "ngay");
        //khen thưởng
        b_dt_khenthuong = b_ds_kq.Tables[13].Copy();
        b_dt_khenthuong.TableName = "KT"; b_dt_khenthuong.AcceptChanges();
        //kỷ luật
        b_dt_kyluat = b_ds_kq.Tables[14].Copy();
        b_dt_kyluat.TableName = "KL"; b_dt_kyluat.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_kyluat, "nsinh");
        // thuyên chuyển cán bộ
        b_dt_thuyenchuyen = b_ds_kq.Tables[15].Copy();
        b_dt_thuyenchuyen.TableName = "TC"; b_dt_thuyenchuyen.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_thuyenchuyen, "ngay");
        // nghỉ chế độ thai sản
        b_dt_thaisan = b_ds_kq.Tables[16].Copy();
        b_dt_thaisan.TableName = "TS"; b_dt_thaisan.AcceptChanges(); bang.P_CSO_CNG(ref b_dt_thaisan, "ngay");
        //công tác
        b_dt_congtac = b_ds_kq.Tables[17].Copy();
        b_dt_congtac.TableName = "CT"; b_dt_congtac.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_nvm.Copy()); b_ds.Tables.Add(b_dt_thaydoihd.Copy()); b_ds.Tables.Add(b_dt_phucap.Copy());
        b_ds.Tables.Add(b_dt_truylinh.Copy()); b_ds.Tables.Add(b_dt_truythu.Copy()); b_ds.Tables.Add(b_dt_trocap.Copy());
        b_ds.Tables.Add(b_dt_thoiviec.Copy()); b_ds.Tables.Add(b_dt_dilamlai.Copy()); b_ds.Tables.Add(b_dt_thaydoiluong.Copy());
        b_ds.Tables.Add(b_dt_dongbh.Copy()); b_ds.Tables.Add(b_dt_kodongbh.Copy()); b_ds.Tables.Add(b_dt_nghikoluong.Copy());
        b_ds.Tables.Add(b_dt_bonhiem.Copy()); b_ds.Tables.Add(b_dt_khenthuong.Copy()); b_ds.Tables.Add(b_dt_kyluat.Copy());
        b_ds.Tables.Add(b_dt_thuyenchuyen.Copy()); b_ds.Tables.Add(b_dt_thaisan.Copy()); b_ds.Tables.Add(b_dt_congtac.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_CC_NGVU(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataTable b_dt_kq = dbora.Fdt_LKE("PNS_BC_CCNGHIEPVU");
        double b_tong = bang.Fn_TIM_TONG(b_dt_kq, "SOLUONG");
        DataTable b_dt_tong = bang.Fdt_TAO_BANG("TONG", "S");
        bang.P_THEM_HANG(ref b_dt_tong, new object[] { b_tong });
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);

        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_dt_tong.TableName = "B1"; b_dt_tong.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy()); b_ds.Tables.Add(b_dt_tong.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_CC_TRINHDO(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataTable b_dt_kq = dbora.Fdt_LKE("PNS_BC_CCTRINHDO");
        double b_tong = bang.Fn_TIM_TONG(b_dt_kq, "SOLUONG");
        DataTable b_dt_tong = bang.Fdt_TAO_BANG("TONG", "S");
        bang.P_THEM_HANG(ref b_dt_tong, new object[] { b_tong });
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_dt_tong.TableName = "B1"; b_dt_tong.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy()); b_ds.Tables.Add(b_dt_tong.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_NSVAO(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0]; int b_ngayd = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])); int b_ngayc = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"]));
        DataTable b_dt_kq = dbora.Fdt_LKE_S(new object[] { b_ngayd, b_ngayc }, "PNS_BC_NSVAO");

        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_NSRA(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0]; int b_ngayd = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])); int b_ngayc = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"]));
        //DataSet b_dt_kq = dbora.Fds_LKE(new object[] { b_ngayd, b_ngayc }, 18, "PNS_BC_TDNS");
        DataTable b_dt_kq = dbora.Fdt_LKE_S(new object[] { b_ngayd, b_ngayc }, "PNS_BC_NSRA");

        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_THUYENCHUYEN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0]; int b_ngayd = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])); int b_ngayc = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"]));
        DataTable b_dt_kq = dbora.Fdt_LKE_S(new object[] { b_ngayd, b_ngayc }, "PNS_CP_BC");
        bang.P_CSO_CNG(ref b_dt_kq, "ngayd");


        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_EXCEL_DANHSACHNV(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0]; int b_ngayd = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])); int b_ngayc = chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"]));

        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_ngayd, b_ngayc }, 2, "PNS_CB_BC");
        DataTable b_dt_kq = b_ds_kq.Tables[0]; DataTable b_dt_ktra = b_ds_kq.Tables[1];
        bang.P_CSO_CNG(ref b_dt_kq, "nsinh");
        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NAM", "T");
        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NU", "G");
        bang.P_THEM_COL(ref b_dt_kq, "SOTT");
        string b_ma_phong; string b_tenphong; string b_ma_phong_ct;
        int k;
        for (int i = 0; i < b_dt_ktra.Rows.Count; i++)
        {
            b_ma_phong = chuyen.OBJ_S(b_dt_ktra.Rows[i]["ma"]);
            b_tenphong = chuyen.OBJ_S(b_dt_ktra.Rows[i]["ten"]);
            k = bang.Fi_TIM_ROW(b_dt_kq, "phong", b_ma_phong);
            if (k >= 0)
            {
                b_ma_phong_ct = chuyen.OBJ_S(b_dt_kq.Rows[k]["ma_ct"]);
                if (b_ma_phong_ct != "" && b_ma_phong_ct != null && b_ma_phong_ct != " ") bang.P_THEM_HANG(ref b_dt_kq, "hoten", "    " + b_tenphong + "(" + b_ma_phong + ")", k);
                else bang.P_THEM_HANG(ref b_dt_kq, "hoten", b_tenphong + "(" + b_ma_phong + ")", k);
            }
        }

        for (int j = 0; j < b_dt_ktra.Rows.Count; j++)
        {
            b_ma_phong_ct = chuyen.OBJ_S(b_dt_ktra.Rows[j]["ma"]);
            b_tenphong = chuyen.OBJ_S(b_dt_ktra.Rows[j]["ten"]);
            k = bang.Fi_TIM_ROW(b_dt_kq, "ma_ct", b_ma_phong_ct);
            if (k >= 0)
            {
                bang.P_THEM_HANG(ref b_dt_kq, "hoten", b_tenphong + "(" + b_ma_phong_ct + ")", k - 1);
            }
        }

        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataTable Fdt_TSO(ref DataTable b_dt, DataTable b_dt_tso)
    {
        string b_loai = chuyen.OBJ_S(b_dt_tso.Rows[0]["loai"]);
        string b_ngayd = chuyen.OBJ_S(b_dt_tso.Rows[0]["ngayd"]);
        string b_ngayc = chuyen.OBJ_S(b_dt_tso.Rows[0]["ngayc"]);
        bang.P_THEM_COL(ref b_dt, "KIEUBC", "S");
        if (b_loai == "TN") { bang.P_DAT_GTRI(ref b_dt, "KIEUBC", "Báo cáo số liệu từ ngày " + b_ngayd + " tới ngày " + b_ngayc, 0); }
        if (b_loai == "T")
        {
            string b_thang = b_ngayc.Substring(3, 7);
            bang.P_DAT_GTRI(ref b_dt, "KIEUBC", "Báo cáo tháng " + b_thang, 0);
        }
        if (b_loai == "Q")
        {
            string b_thang = b_ngayc.Substring(3, 2); string b_nam = b_ngayc.Substring(6, 4); string b_quy = "";
            if (b_thang == "01" || b_thang == "02" || b_thang == "03") b_quy = "I";
            if (b_thang == "04" || b_thang == "05" || b_thang == "06") b_quy = "II";
            if (b_thang == "07" || b_thang == "08" || b_thang == "09") b_quy = "III";
            if (b_thang == "10" || b_thang == "11" || b_thang == "12") b_quy = "IV";
            bang.P_DAT_GTRI(ref b_dt, "KIEUBC", "Báo cáo số liệu quý: " + b_quy + " năm: " + b_nam, 0);
        }
        if (b_loai == "N")
        {
            string b_nam = b_ngayc.Substring(6, 4);
            bang.P_DAT_GTRI(ref b_dt, "KIEUBC", "Báo cáo số liệu năm " + b_nam, 0);
        }
        return b_dt;
    }
    public static DataSet Fds_NS_HD_IN(DataTable b_dt_tso)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
        DataTable b_dt_kq = dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_HD_IN");
        DataRow b_dr_kq = b_dt_kq.Rows[0];
        bang.P_THEM_COL(ref b_dt_kq, "NSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAYKY", chuyen.OBJ_S(b_dr_kq["ngay_ky"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGKY", chuyen.OBJ_S(b_dr_kq["ngay_ky"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMKY", chuyen.OBJ_S(b_dr_kq["ngay_ky"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAYKYHD", chuyen.CSO_CNG(chuyen.OBJ_S(b_dr_kq["ngay_ky"])));

        bang.P_THEM_COL(ref b_dt_kq, "NGAYTUHD", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGTUHD", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMTUHD", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAYDENHD", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGDENHD", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMDENHD", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(0, 4));
        bang.P_SO_CSO(ref b_dt_kq, "luongvnd");
        bang.P_SO_CSO(ref b_dt_kq, "luongbhvnd");
        bang.P_SO_CSO(ref b_dt_kq, "luongusd");
        bang.P_SO_CSO(ref b_dt_kq, "luongbhusd");
        bang.P_SO_CSO(ref b_dt_kq, "luonggrossusd");
        bang.P_SO_CSO(ref b_dt_kq, "luonggrossvnd");
        bang.P_SO_CSO(ref b_dt_kq, "tygia");

        bang.P_THEM_COL(ref b_dt_kq, "LUONGCHU", "");
        bang.P_CSO_CNG(ref b_dt_kq, "ngayd,ncap,ngayc,ngaysinh");

        string b_luong = b_dr_kq["luong"].ToString();
        string b_luong_chu = doctien.replace_special_word(doctien.join_unit(b_luong).Trim());
        b_luong = b_luong + " VNĐ/Tháng (" + b_luong_chu + ").";
        string b_luongtong = b_dr_kq["luongtong"].ToString();
        string b_luongtong_chu = doctien.replace_special_word(doctien.join_unit(b_luongtong).Trim());
        bang.P_SO_CSO(ref b_dt_kq, "luongtong");
        b_luongtong = b_dr_kq["luongtong"].ToString();
        b_luongtong = b_luongtong + " VNĐ/Tháng (" + b_luongtong_chu + ").";
        bang.P_BO_COT(ref b_dt_kq, "luong");
        bang.P_THEM_COL(ref b_dt_kq, "LUONG", b_luong);
        bang.P_BO_COT(ref b_dt_kq, "luongtong");
        bang.P_THEM_COL(ref b_dt_kq, "LUONGTONG", b_luongtong);
        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NAM", "Nam");
        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NU", "Nữ");

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });

        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();

        b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_QD_IN(DataTable b_dt_tso)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();

        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        double b_so_id = chuyen.OBJ_N(b_dr["so_id"]);
        DataTable b_dt_kq = dbora.Fdt_LKE_S(new object[] { b_so_id }, "PNS_QD_IN");
        DataRow b_dr_kq = b_dt_kq.Rows[0];
        bang.P_THEM_COL(ref b_dt_kq, "NSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMSINH", chuyen.OBJ_S(b_dr_kq["ngaysinh"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAYKY_QD", chuyen.OBJ_S(b_dr_kq["ngay_ky_qd"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANGKY_QD", chuyen.OBJ_S(b_dr_kq["ngay_ky_qd"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAMKY_QD", chuyen.OBJ_S(b_dr_kq["ngay_ky_qd"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAYKY", chuyen.CSO_CNG(chuyen.OBJ_S(b_dr_kq["ngay_ky_qd"])));

        bang.P_THEM_COL(ref b_dt_kq, "NGAYd_HL", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANG_HL", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAM_HL", chuyen.OBJ_S(b_dr_kq["ngayd"]).Substring(0, 4));
        bang.P_THEM_COL(ref b_dt_kq, "NGAY_HET_HL", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(6, 2));
        bang.P_THEM_COL(ref b_dt_kq, "THANG_HET_HL", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(4, 2));
        bang.P_THEM_COL(ref b_dt_kq, "NAM_HET_HL", chuyen.OBJ_S(b_dr_kq["ngayc"]).Substring(0, 4));

        bang.P_SO_CSO(ref b_dt_kq, "TIEN");
        bang.P_SO_CSO(ref b_dt_kq, "TIENBH");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_LCB");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_TDGT");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_TNS");
        bang.P_SO_CSO(ref b_dt_kq, "phantram_luong");

        bang.P_SO_CSO(ref b_dt_kq, "TIENC");
        bang.P_SO_CSO(ref b_dt_kq, "TIENBHC");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_LCBC");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_TDGTC");
        bang.P_SO_CSO(ref b_dt_kq, "TIEN_TNSC");
        bang.P_SO_CSO(ref b_dt_kq, "phantram_luongc");

        bang.P_SO_CNG(ref b_dt_kq, "ngayd,ngayc,ngaysinh,ngay_cmt,ngay_ky_qd");

        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NAM", "Nam");
        bang.P_THAY_GTRI(ref b_dt_kq, "gtinh", "NU", "Nữ");

        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG" }, new object[] { b_se.ma_dvi, b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)) });

        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        b_dt_kq.TableName = "B"; b_dt_kq.AcceptChanges();

        b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_kq.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static void Fds_NS_KYNIEM_THAMNIEN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_ds = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"])) }, 2, "pns_bc_kyniem_thamnien");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];
        string b_ngayd;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_ngayd = b_dt_0.Rows[i]["ngayd"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "thang", b_ngayd);
            bang.P_BO_COT(ref b_dt_1, "thang");
            bang.P_SO_CNG(ref b_dt_1, "ngayd");
            // Thêm giá trị vào bảng tên
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Kỷ niệm ngày: " + b_ngayd.Substring(2, 2) + "/" + b_ngayd.Substring(0, 2) + "/" + DateTime.Now.ToString("yyyy") });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_DANHSACH_THEO_NCDANH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_ds = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayd"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngayc"])) }, 2, "pns_danhsach_cdanh");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];

        // bỏ những người có chức danh là ""
        bang.P_BO_HANG(ref b_dt, "ncdanh", ""); bang.P_BO_HANG(ref b_dt, "ncdanh", null); bang.P_BO_HANG(ref b_dt, "ncdanh", " ");
        bang.P_BO_HANG(ref b_dt_0, "ncdanh", ""); bang.P_BO_HANG(ref b_dt_0, "ncdanh", null); bang.P_BO_HANG(ref b_dt_0, "ncdanh", " ");
        string b_ncdanh;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_ncdanh = b_dt_0.Rows[i]["ncdanh"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "ncdanh", b_ncdanh);
            bang.P_BO_COT(ref b_dt_1, "ncdanh");
            bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NAM", "Nam"); bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NU", "Nữ");
            bang.P_SO_CNG(ref b_dt_1, "ngayd");
            // Thêm giá trị vào bảng tên
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Chức danh: " + b_dt_0.Rows[i]["tencdanh"].ToString() + "( Số lượng: " + b_dt_0.Rows[i]["soluong"].ToString() + " )" });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_DANHSACH_THEO_TRINHDO(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_ds = dbora.Fds_LKE(2, "pns_danhsach_capdt");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];
        string b_capdt;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_capdt = b_dt_0.Rows[i]["capdt"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "capdt", b_capdt);
            bang.P_BO_COT(ref b_dt_1, "capdt");
            bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NAM", "Nam"); bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NU", "Nữ");
            // Thêm giá trị vào bảng tên
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Trình độ: " + b_dt_0.Rows[i]["ten"].ToString() + "( Số lượng: " + b_dt_0.Rows[i]["soluong"].ToString() + " )" });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_NGHIPHEP_TONGHOP(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_ds = dbora.Fds_LKE(new object[] { 2014 }, 2, "pns_tl_nghiphep_tonghop");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];
        string b_phong;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_phong = b_dt_0.Rows[i]["phong"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "phong", b_phong);
            bang.P_BO_COT(ref b_dt_1, "phong");
            //bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NAM", "Nam"); bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NU", "Nữ");
            // Thêm giá trị vào bảng tên
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Phòng/ Ban: " + b_dt_0.Rows[i]["ten"].ToString() + "( Số lượng: " + b_dt_0.Rows[i]["soluong"].ToString() + " )" });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_TL_LUONGCHUNG_BANGLUONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        string b_thang = chuyen.CNG_CSO(b_dr["ngayd"].ToString());
        b_thang = b_thang.Substring(0, 6);
        b_ds = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_thang) }, 2, "PNS_TL_LUONGCHUNG_BANGLUONG");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];
        string b_phong;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_phong = b_dt_0.Rows[i]["phong"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "phong", b_phong);
            bang.P_BO_COT(ref b_dt_1, "phong");
            //bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NAM", "Nam"); bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NU", "Nữ");
            // Thêm giá trị vào bảng tên
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Phòng/ Ban: " + b_dt_0.Rows[i]["ten"].ToString() + "( Số lượng: " + b_dt_0.Rows[i]["soluong"].ToString() + " )" });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_BC_TONGHOP_BH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        string b_nam = chuyen.CNG_CSO(b_dr["ngayd"].ToString());
        b_nam = b_nam.Substring(0, 4);
        b_ds = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_nam) }, 2, "pns_bc_tonghop_bh");
        b_dt = b_ds.Tables[0]; b_dt_0 = b_ds.Tables[1];
        string b_thang;
        for (int i = 0; i < b_dt_0.Rows.Count; i++)
        {
            b_thang = b_dt_0.Rows[i]["thang"].ToString();
            b_dt_1 = bang.Fdt_TAO_BANG(b_dt, "thang", b_thang);
            bang.P_BO_COT(ref b_dt_1, "thang");
            //bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NAM", "Nam"); bang.P_THAY_GTRI(ref b_dt_1, "gioitinh", "NU", "Nữ");
            // Thêm giá trị vào bảng tên
            bang.P_SO_CSO(ref b_dt_1, "luong_bh,bhxh,bhyt,bhtn,ct_bhxh,ct_bhyt,ct_bhtn,tongdong");
            bang.P_THEM_HANG(ref b_tenbang, new object[] { "Tháng: " + chuyen.CSO_CTH(b_thang) });
            b_dt_1.TableName = "Table" + i.ToString(); b_dt_1.AcceptChanges();
            b_ds_kq.Tables.Add(b_dt_1.Copy()); b_ds_kq.AcceptChanges();
        }
        Excelreport.DataSet_ExcelWorkbook_FormatsFormulas(b_ds_kq, b_tenbang, b_ddan + b_tenrp, b_tenrp, "Format", 4, 0);
    }
    public static void Fds_NS_EXPORT_CB(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_cb"); bang.P_THAY_GTRI(ref b_dt, new string[] { "nsinh", "ngay_cmt", "ngayd" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[]{"so_the" , "phong","ten","ten_hoa","nn","sotk","nha_dchi","nhan",
        "nsinh","gtinh","dchi","hkhau","nhom","dtdd","dtnr","email","socmt","ngay_cmt","nc_cmt","mast","ngayd","nha","khican_ll","ttr"},
        new string[]{"Mã CB" , "Mã phòng","Tên","Tên hoa","Quốc tịch","Số tài khoản","Địa chỉ NN","Nhận tiền qua ngân hàng?",
        "Ngày sinh","Giới tính","Địa chỉ","Hộ khẩu","Mã nhóm","dtdd","dtnr","email","Số CMT","Ngày cấp CMT","Nơi cấp CMT","Mã số thuế","Ngày vào","Ngân hàng","Khi cần ll","Tình trạng"});
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_hd"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngay_ky", "ngayd", "ngayc" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[]{"so_the","ten","lhd","so_hd","ngay_ky","ngayd","ngayc","phong",
        "cv_plam","cvu","hspc","lng","ngach","bac","hso","ncd","cdanh","bcd","hscd",
        "tien","tienbh","ma_nte","hthl","tg_lv","dc_ld","ptdl","phucap","nangluong","nghingoi","bhyt_xh","daotao","thuong","bhld","boithuong","thoathuan",
        "note","tratheo","ngaynghi"},
        new string[]{"Mã CB","Tên","Loại hợp đồng","Số hợp đồng","Ngày ký","Từ ngày","Tới ngày","Phòng",
        "Công việc","Chức vụ","Hệ số pc","Loại ngạch","Ngạch","Bậc ngạch","hệ số ngạch","Nhóm chức danh","Chức danh","Bậc chức danh","Hệ số chức danh",
        "Tiền lương","Lương đóng bảo hiểm","Mã ngoại tệ","Hình thức hưởng lương","Thời gian làm việc","Dụng cụ lao động","Phương tiện đi lại","Phụ cấp khác","Hạn nâng lương","Chế độ nghỉ ngơi",
        "Chế độ bảo hiểm","Chế độ đào tạo","Chế độ thưởng","Bảo hộ lao động","Bồi thường","Thỏa thuận khác","Ghi chú","Trả lương theo","Ngày nghỉ phép"});
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_QHE(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_qhe");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "so_the", "ten", "gdinh", "lqhe", "tennguoiqh", "gt", "tuoi", "n_ngh", "note", "sothe_tnhan", "phuthuoc" },
        new string[] { "Mã CB", "Tên", "Gia đình", "Loại quan hệ", "Họ tên", "Giới tính", "Tuổi", "Nghề nghiệp", "Ghi chú", "Mã cb (nếu trong cùng đơn vị)", "Là người phụ thuộc" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_DTHV(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_dthv"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngaycap", "thangd", "thangc" }, new string[] { "01/01/3000", "01/3000", "01/3000" }, new string[] { "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "so_the","ten","capdt","vb","sohieu","ngaycap","hinhthuc","hedt","nhom_cnganh","cnganh",
            "ten_cnganh","noidt","thangd","thangc","xeploai","tinhtrang","note"},
        new string[] { "Mã CB", "Tên","Cấp đào tạo","Văn bằng","Số hiệu văn bằng","Ngày cấp","Hình thức","Hệ đào tạo","Nhóm chuyên ngành","Chuyên ngành",
            "Tên chuyên ngành","Nơi đào tạo","Từ tháng","Đến tháng","Xếp loại","Tình trạng","Ghi chú" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_NGHAN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_nghan"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngaycap", "ngayd", "ngayc" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "so_the", "ten", "ten_cchi", "noidung", "sohieu", "ngaycap", "nhom_cnganh", "cnganh", "noidt", "ngayd", "ngayc", "thoihan", "xeploai", "note" },
        new string[] { "Mã CB", "Tên", "Tên chứng chỉ", "Nội dung", "Số hiệu", "Ngày cấp", "Nhóm chuyên ngành", "Chuyên ngành", "Nơi đào tạo", "Từ ngày", "Đến ngày", "Thời hạn bằng", "Xếp loại", "Ghi chú" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_HDCT(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_hdct"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngay_qd", "ngayd", "ngayc" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "so_the","ten","hinhthuc","so_qd","ngay_qd","ngayd","ngayc",
            "lng","ngach","bac","hso","cvu","hspc","ncd","cdanh","bcd","hscd","tien","tienbh","cv_chinh","dvi_ctac","note","phongm","phongc","cvuc",
            "hspcc","lngc","ngachc","bacc","hsoc","ncdc","cdanhc","bcdc","hscdc","tienc","tienbhc" },
        new string[] { "Mã CB", "Tên","Hình thức","Số QĐ","Ngày QĐ","Từ ngày","Tới ngày",
            "Loại ngạch","Ngạch","Bậc","Hệ số","Chức vụ","Hệ số phụ cấp","Nhóm chức danh","Chức danh","Bậc chức danh","Hệ số chức danh","Tiền","Tiền bảo hiểm","Công việc chính",
            "Đợn vị công tác","Ghi chú","Phòng mới","Phòng cũ","Chúc vụ cũ","Hệ số phụ cấp cũ","Loại ngạch cũ","Ngạch cũ","Bậc ngạch cũ",
            "Hệ sỗ ngạch cũ","Nhóm chức danh cũ","Chức danh cũ","Bậc chức danh cũ","Hệ số chức danh cũ","Tiền cũ","Tiền đóng bảo hiểm cũ" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_BHXH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_bhxh"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngay_bhxh", "ndongbhxh", "ndongbhtn", "ngayd", "ngayc", "ngay_trabhxh", "ngay_trabhyt" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000", "01/01/3000", "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "", "", "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "so_the","ten","bhxh","bhyt","bhtn","dcapso","sobhxh","ngay_bhxh","noicap","ndongbhxh","ndongbhtn",
        "sobhyt","dk_kcb","ngayd","ngayc","trabhxh","ngay_trabhxh","trabhyt","ngay_trabhyt","ghichu" },
        new string[] { "Mã CB", "Tên", "Có tham gia BHXH?","Có tham gia BHYT","Có tham gia BHTN","Đã cấp sổ?","Số BHXH","Ngày cấp BHXH","Nơi cấp","Ngày bắt đầu đóng BHXH",
            "Ngày bắt đầu đóng BHTN","Số BHYT","Nơi đăng ký KCB","Từ ngày","Tới ngày","Đã trả sổ BHXH?","Ngày trả sổ BHXH","Đã trả sổ BHYT?","Ngày trả thẻ BHYT?","Ghi chú" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_HDFUL(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_hdful");
        bang.P_DOI_TENCOL(ref b_dt, new string[]{"MA_DVI","SO_THE","SO_ID","PHONG","TENPHONG","TT","TEN","TEN_HOA","NN","SOTK","NHA_DCHI","NHAN","NSINH","GTINH","DCHI","HKHAU","NHOM","TENNHOM",
        "DTDD","DTNR","EMAIL","SOCMT","NGAY_CMT","NC_CMT","TEN_NC_CMT","MAST","NGAYD","NSD","NHA","KHICAN_LL","TTR","MA_GT","TEN_GT","SOBHXH","NGAY_BHXH",
        "NOICAP","NDONGBHXH","NDONGBHTN","SOBHYT","DK_KCB","TEN_DK_KCB","NGAYD_BHXH","NGAYC_BHXH","TRABHXH","NGAY_TRABHXH","TRABHYT","NGAY_TRABHYT",
        "GHICHU_BHXH","LHD","TEN_LHD","SO_HD","NGAY_KY","NGAYD_HD","NGAYC_HD","CV_PLAM","CVU","TEN_CVU","HSPC","LNG","TEN_LNG","NGACH","TEN_NGACH",
        "BAC","HSO","NCD","TEN_NCD","CDANH","TEN_CDANH","BCD","HSCD","TIEN","TIENBH","MA_NTE","HTHL","TG_LV","DC_LD","PTDL","PHUCAP","NANGLUONG",
        "NGHINGOI","BHYT_XH","DAOTAO","THUONG","BHLD","BOITHUONG","THOATHUAN","NOTE_HD","TRATHEO","NGAYNGHI","SOLUONG_HD"},
        new string[]{"Mã đơn vị","mã cán bộ","số id","mã phòng","tên phòng","số thứ tự","tên","tên viết hoa","quốc tịch","số tài khoản",
            "địa chỉ ngân hàng","Nhận tiền qua ngân hàng?","ngày sinh","giới tính","địa chỉ hiện tại","hộ khẩu thường trú","nhóm","tên nhóm",
            "dtdd","dđiện thoại nhà riêng","email","số cmt","ngày cấp cmt","mã nơi cấp cmt","tên nơi cấp cmt","mã số thuế","ngày vào đơn vị",
            "nsd","ngân hàng","khi cần liên hệ với ai","hoạt khộng hay không?","mã người giới thiệu","tên người giới thiệu","số sổ BHXH",
            "ngày cấp BHXH","nơi cấp BHXH","ngày bắt đầu đóng BHXH","ngày bắt đầu đóng BHTN","số BHYT","mã nơi đăng ký kcb","tên nơi đăng ký kcb",
            "từ ngày","tới ngày","đã trả bhxh?","ngày trả bhxh","đã trả bhyt?","ngày trả bhyt","ghi chú bhxh","Mã loại hợp đồng","tên loại hợp đồng",
            "số hợp đồng","ngày ký","Từ ngày ","tới ngày","công việc phải làm ","Mã chức vụ","tên chức vụ","hệ số phụ cấp","loại ngạch",
            "tên loại ngạch","ngạch","tên ngạch","bậc ngạch","hệ số","nhóm chức danh","tên nhóm chức danh","chức danh","tên chức danh",
            "bậc chức danh","hệ số chức danh","Tiền lương","Tiền lương đóng bảo hiểm","mã ngoại tệ","hình thức hưởng lương","thời gian làm việc",
            "dc_ld","ptdl","phụ cấp","nâng lương","nghỉ ngơi","bhyt_xh","dđào tạo","thưởng","bảo hộ","bồi thường","thỏa thuận khác",
            "ghi trú hợp đồng","trả theo","số ngày nghỉ","số lượng hợp đồng đã ký"});
        //bang.P_THAY_GTRI(ref b_dt, new string[] { "ngay_ky", "ngayd", "ngayc" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "" });
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static void Fds_NS_EXPORT_TV(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet(); DataSet b_ds_kq = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_tenbang = bang.Fdt_TAO_BANG("tenbang", "U");
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        b_dt = dbora.Fdt_LKE("pns_export_tv"); bang.P_THAY_GTRI(ref b_dt, new string[] { "ngaynop", "ngaynghi", "ngay_qd", "ngaytt" }, new string[] { "01/01/3000", "01/01/3000", "01/01/3000", "01/01/3000" }, new string[] { "", "", "", "" });
        bang.P_DOI_TENCOL(ref b_dt, new string[]{"so_the" , "ten","phong","ngaynop","ngaynghi","tinhtrang","so_qd","ngay_qd",
            "ht","ngaytt","nguoiduyet","lydo"},
        new string[]{"Mã CB","Tên","Phòng","Ngày nộp","Ngày nghỉ dự kiến","Tình trạng","Số quyết định",
        "Ngày quyết định","Hình thức","Ngày nghỉ thực tế","Người duyệt","Lý do"});
        Excelreport.DataTabletoExcelWorkbook(b_dt, "Format");
    }
    public static DataSet Fds_BHXH_C66A_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "pns_bc_bhxh_c66a");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy(); DataRow b_dr_0 = b_dt_0.Rows[0];
        bang.P_SO_CSO(ref b_dt_0, "tongtien");
        //bang.P_THEM_COL(ref b_dt_0, new string[] { "SHTK", "TSLD" });
        //bang.P_THEM_HANG(ref b_dt_0, new string[] { "SHTK", "TSLD" }, new object[] { "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]) });
        b_dt_0.TableName = "DLIEU"; b_dt_0.AcceptChanges();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });
        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" }, new object[] { "Mã đơn vị: " + b_se.ma_dvi, "Tên cơ quan (đơn vị):" + b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)), "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]), chuyen.OBJ_S(b_dr_0["nguoilap"]), chuyen.OBJ_S(b_dr_0["ktt"]), chuyen.OBJ_S(b_dr_0["g_doc"]), chuyen.OBJ_N(b_dr_0["tongtien"]) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        bang.P_SO_CSO(ref b_dt, "luongbhxh,tienhuong");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "luongbhxh", "tienhuong" }, new string[] { "LUONGBHXH", "TIENHUONG" });
        int i;
        DataTable b_dt_onn = bang.Fdt_TAO_BANG(b_dt, "lydo", "ONN");
        bang.P_THEM_COL(ref b_dt_onn, "STT");
        for (i = 0; i < b_dt_onn.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_onn, "STT", i + 1, i); }
        b_dt_onn.TableName = "ONN"; b_dt_onn.AcceptChanges();
        DataTable b_dt_odn = bang.Fdt_TAO_BANG(b_dt, "lydo", "ODN");
        bang.P_THEM_COL(ref b_dt_odn, "STT");
        for (i = 0; i < b_dt_odn.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_odn, "STT", i + 1, i); }
        b_dt_odn.TableName = "ODN"; b_dt_odn.AcceptChanges();
        DataTable b_dt_co = bang.Fdt_TAO_BANG(b_dt, "lydo", "CO");
        bang.P_THEM_COL(ref b_dt_co, "STT");
        for (i = 0; i < b_dt_co.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_co, "STT", i + 1, i); }
        b_dt_co.TableName = "CO"; b_dt_co.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_onn.Copy()); b_ds.Tables.Add(b_dt_odn.Copy()); b_ds.Tables.Add(b_dt_co.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_BHXH_C67A_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "pns_bc_bhxh_c67a");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy(); DataRow b_dr_0 = b_dt_0.Rows[0];
        bang.P_SO_CSO(ref b_dt_0, "tongtien");
        //bang.P_THEM_COL(ref b_dt_0, new string[] { "SHTK", "TSLD" });
        //bang.P_THEM_HANG(ref b_dt_0, new string[] { "SHTK", "TSLD" }, new object[] { "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]) });
        b_dt_0.TableName = "DLIEU"; b_dt_0.AcceptChanges();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });
        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" }, new object[] { "Mã đơn vị: " + b_se.ma_dvi, "Tên cơ quan (đơn vị):" + b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)), "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]), chuyen.OBJ_S(b_dr_0["nguoilap"]), chuyen.OBJ_S(b_dr_0["ktt"]), chuyen.OBJ_S(b_dr_0["g_doc"]), chuyen.OBJ_N(b_dr_0["tongtien"]) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        bang.P_SO_CSO(ref b_dt, "luongbhxh,tienhuong");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "luongbhxh", "tienhuong" }, new string[] { "LUONGBHXH", "TIENHUONG" });
        int i;
        // thay đổi từ đây
        DataTable b_dt_kt = bang.Fdt_TAO_BANG(b_dt, "lydo", "KT");
        bang.P_THEM_COL(ref b_dt_kt, "STT");
        for (i = 0; i < b_dt_kt.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_kt, "STT", i + 1, i); }
        b_dt_kt.TableName = "KT"; b_dt_kt.AcceptChanges();
        DataTable b_dt_st = bang.Fdt_TAO_BANG(b_dt, "lydo", "ST");
        bang.P_THEM_COL(ref b_dt_st, "STT");
        for (i = 0; i < b_dt_st.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_st, "STT", i + 1, i); }
        b_dt_st.TableName = "ST"; b_dt_st.AcceptChanges();
        DataTable b_dt_sc = bang.Fdt_TAO_BANG(b_dt, "lydo", "SC");
        bang.P_THEM_COL(ref b_dt_sc, "STT");
        for (i = 0; i < b_dt_sc.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_sc, "STT", i + 1, i); }
        b_dt_sc.TableName = "SC"; b_dt_sc.AcceptChanges();
        DataTable b_dt_khh = bang.Fdt_TAO_BANG(b_dt, "lydo", "KHH");
        bang.P_THEM_COL(ref b_dt_khh, "STT");
        for (i = 0; i < b_dt_khh.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_khh, "STT", i + 1, i); }
        b_dt_khh.TableName = "KHH"; b_dt_khh.AcceptChanges();
        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_kt.Copy()); b_ds.Tables.Add(b_dt_st.Copy()); b_ds.Tables.Add(b_dt_sc.Copy()); b_ds.Tables.Add(b_dt_khh.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_BHXH_C68A_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "pns_bc_bhxh_c68a");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy(); DataRow b_dr_0 = b_dt_0.Rows[0];
        bang.P_SO_CSO(ref b_dt_0, "tongtien");
        //bang.P_THEM_COL(ref b_dt_0, new string[] { "SHTK", "TSLD" });
        //bang.P_THEM_HANG(ref b_dt_0, new string[] { "SHTK", "TSLD" }, new object[] { "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]) });
        b_dt_0.TableName = "DLIEU"; b_dt_0.AcceptChanges();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });
        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" }, new object[] { "Mã đơn vị: " + b_se.ma_dvi, "Tên cơ quan (đơn vị):" + b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)), "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]), chuyen.OBJ_S(b_dr_0["nguoilap"]), chuyen.OBJ_S(b_dr_0["ktt"]), chuyen.OBJ_S(b_dr_0["g_doc"]), chuyen.OBJ_N(b_dr_0["tongtien"]) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        bang.P_SO_CSO(ref b_dt, "luongbhxh,tienhuong");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "luongbhxh", "tienhuong" }, new string[] { "LUONGBHXH", "TIENHUONG" });
        int i;
        // thay đổi từ đây
        DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS");
        bang.P_THEM_COL(ref b_dt_ds, "STT");
        for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        b_dt_ds.TableName = "DS"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_ds.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_BHXH_C69A_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "pns_bc_bhxh_c69a");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy(); DataRow b_dr_0 = b_dt_0.Rows[0];
        bang.P_SO_CSO(ref b_dt_0, "tongtien");
        //bang.P_THEM_COL(ref b_dt_0, new string[] { "SHTK", "TSLD" });
        //bang.P_THEM_HANG(ref b_dt_0, new string[] { "SHTK", "TSLD" }, new object[] { "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]) });
        b_dt_0.TableName = "DLIEU"; b_dt_0.AcceptChanges();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });
        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" }, new object[] { "Mã đơn vị: " + b_se.ma_dvi, "Tên cơ quan (đơn vị):" + b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)), "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]), chuyen.OBJ_S(b_dr_0["nguoilap"]), chuyen.OBJ_S(b_dr_0["ktt"]), chuyen.OBJ_S(b_dr_0["g_doc"]), chuyen.OBJ_N(b_dr_0["tongtien"]) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        bang.P_SO_CSO(ref b_dt, "luongbhxh,tienhuong");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "luongbhxh", "tienhuong" }, new string[] { "LUONGBHXH", "TIENHUONG" });
        int i;
        // thay đổi từ đây
        DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS1");
        bang.P_THEM_COL(ref b_dt_ds, "STT");
        for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        b_dt_ds.TableName = "DS1"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_ds.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_BHXH_C70A_HD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])), 
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "pns_bc_bhxh_c70a");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy(); DataRow b_dr_0 = b_dt_0.Rows[0];
        bang.P_SO_CSO(ref b_dt_0, "tongtien");
        //bang.P_THEM_COL(ref b_dt_0, new string[] { "SHTK", "TSLD" });
        //bang.P_THEM_HANG(ref b_dt_0, new string[] { "SHTK", "TSLD" }, new object[] { "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]) });
        b_dt_0.TableName = "DLIEU"; b_dt_0.AcceptChanges();
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });
        //tham so cua bao cao
        bang.P_THEM_COL(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" });
        bang.P_THEM_HANG(ref b_dt_2, new string[] { "MA_DVI", "TEN_DVI", "DCHI_DVI", "NSD", "PHONG", "SHTK", "TSLD", "NGUOILAP", "KTT", "GDOC", "TONGTIEN" }, new object[] { "Mã đơn vị: " + b_se.ma_dvi, "Tên cơ quan (đơn vị):" + b_se.ten_dvi, b_se.dchi_dvi, b_se.ten, b_se.phong + " - " + chuyen.OBJ_S(lenh.Fobj_TEN("ht_ma_phong", "ten", "ma=", b_se.phong)), "Số hiệu tài khoản: " + chuyen.OBJ_S(b_dr_0["ma_tk"]) + "   mở tại: " + chuyen.OBJ_S(b_dr_0["nhang"]), "Tổng số lao động: " + chuyen.OBJ_S(b_dr_0["tongns"]) + "     Trong đó nữ: " + chuyen.OBJ_S(b_dr_0["tongnu"]), chuyen.OBJ_S(b_dr_0["nguoilap"]), chuyen.OBJ_S(b_dr_0["ktt"]), chuyen.OBJ_S(b_dr_0["g_doc"]), chuyen.OBJ_N(b_dr_0["tongtien"]) });
        Fdt_TSO(ref b_dt_2, b_dt_tso);
        b_dt_1.TableName = "TENBC"; b_dt_1.AcceptChanges();
        b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        bang.P_SO_CSO(ref b_dt, "luongbhxh,tienhuong");
        bang.P_DOI_TENCOL(ref b_dt, new string[] { "luongbhxh", "tienhuong" }, new string[] { "LUONGBHXH", "TIENHUONG" });
        int i;
        // thay đổi từ đây
        DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        bang.P_THEM_COL(ref b_dt_ds, "STT");
        for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy()); b_ds.Tables.Add(b_dt_2.Copy()); b_ds.Tables.Add(b_dt_ds.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_DS_NV(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["ma_donvi"] }, 1, "PNS_BC_NS_DS_NV");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        bang.P_THAY_GTRI(ref b_dt_0, "gtinh", "NAM", "Nam");
        bang.P_THAY_GTRI(ref b_dt_0, "gtinh", "NU", "Nữ");
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });


        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_QTDA(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])),
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"])), b_dr["ma_duan"]}, 2, "PNS_BC_QTDA");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });


        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TTDA(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt = new DataTable(), b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayd"])),
            chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["ngayc"]))}, 2, "PNS_BC_TTDA");

        b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_CTCC(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.OBJ_S(b_dr["ma_donvi"]),
            chuyen.OBJ_S(b_dr["ma_cb"]),chuyen.OBJ_S(b_dr["duan"])}, 1, "PNS_BC_CTCC");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_CTBP(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.OBJ_S(b_dr["ma_donvi"]),
            chuyen.OBJ_S(b_dr["ma_cb"]),chuyen.OBJ_S(b_dr["duan"])}, 1, "PNS_BC_CTBP");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_CTKHOI(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.OBJ_S(b_dr["ma_donvi"]),
            chuyen.OBJ_S(b_dr["ma_cb"]),chuyen.OBJ_S(b_dr["duan"])}, 1, "PNS_BC_CTKHOI");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TSCC(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] {chuyen.CNG_SO(b_dr["ngayd"].ToString()),chuyen.CNG_SO(b_dr["ngayc"].ToString()),
            chuyen.OBJ_S(b_dr["ma_cb"])}, 1, "PNS_BC_CN_TIMESHEET");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TSBP(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), chuyen.OBJ_S(b_dr["ma_donvi"]) }, 1, "PNS_BC_BP_TIMESHEET");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        // b_dt_2 = b_ds_kq.Tables[1].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt_2.TableName = "T";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TSKHOI(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()) }, 1, "PNS_BC_KHOI_TIMESHEET");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TINHLUONG_SL(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), chuyen.OBJ_S(b_dr["ma_donvi"]) }, 1, "PNS_BC_BP_TINHLUONG");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        // b_dt_2 = b_ds_kq.Tables[1].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt_2.TableName = "T";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_SANLUONG_DUAN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), b_dr["duan"].ToString() }, 1, "PNS_BC_SL_DUAN");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        // b_dt_2 = b_ds_kq.Tables[1].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt_2.TableName = "T";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_SANLUONG_DUAN_2(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable(), b_dt_3 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), b_dr["duan"].ToString() }, 3, "PNS_BC_SL_DUAN_3");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        b_dt_2 = b_ds_kq.Tables[1].Copy();
        b_dt_3 = b_ds_kq.Tables[2].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        b_dt_2.TableName = "T";
        b_dt_3.TableName = "S";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        b_ds.Tables.Add(b_dt_3.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_SANLUONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), chuyen.OBJ_S(b_dr["ma_donvi"]), chuyen.OBJ_S(b_dr["ma_cb"]) }, 1, "PNS_BC_SL_CANHAN_PHONG_KHOI");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        // b_dt_2 = b_ds_kq.Tables[1].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt_2.TableName = "T";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    public static DataSet Fds_NS_BC_SANLUONG_2(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataSet b_ds = new DataSet();
        DataTable b_dt_0 = new DataTable(), b_dt_1 = new DataTable(), b_dt_2 = new DataTable();
        se.se_nsd b_se = new se.se_nsd();
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["ngayd"].ToString()), chuyen.CNG_SO(b_dr["ngayc"].ToString()), chuyen.OBJ_S(b_dr["ma_donvi"]), chuyen.OBJ_S(b_dr["ma_cb"]) }, 1, "PNS_BC_SL_CANHAN_PHONG_KHOI2");

        //b_dt = b_ds_kq.Tables[1].Copy();
        b_dt_0 = b_ds_kq.Tables[0].Copy();
        // b_dt_2 = b_ds_kq.Tables[1].Copy();
        //DataRow b_dr_0 = b_dt_0.Rows[0];
        b_dt_0.TableName = "B";
        //b_dt_2.TableName = "T";
        //b_dt.TableName = "TSO";
        //ten bao cao
        bang.P_THEM_COL(ref b_dt_1, new string[] { "ma", "ddan", "ten" });
        bang.P_THEM_HANG(ref b_dt_1, new object[] { b_ma, b_ddan, b_tenrp.ToLower().Replace(".xml", "") });

        ////tham so cua bao cao
        //bang.P_THEM_COL(ref b_dt_2, new string[] { "TUDEN"});
        //bang.P_THEM_HANG(ref b_dt_2, new string[] { "TUDEN" }, new object[] { b_se.ma_dvi, "Tên cơ quan (đơn vị):" });

        b_dt_1.TableName = "TENBC";
        //b_dt_2.TableName = "TSO"; b_dt_2.AcceptChanges();
        //int i;
        // thay đổi từ đây
        //DataTable b_dt_ds = bang.Fdt_TAO_BANG(b_dt, "lydo", "DS2");
        //bang.P_THEM_COL(ref b_dt_ds, "STT");
        //for (i = 0; i < b_dt_ds.Rows.Count; i++) { bang.P_DAT_GTRI(ref b_dt_ds, "STT", i + 1, i); }
        //b_dt_ds.TableName = "DS2"; b_dt_ds.AcceptChanges();

        b_ds.Tables.Add(b_dt_1.Copy());
        //b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_0.Copy());
        //b_ds.Tables.Add(b_dt.Copy());
        b_ds.AcceptChanges();
        return b_ds;
    }
    #endregion

    #region BÁO CÁO LƯƠNG CAPITALHOUSE
    public static DataSet Fds_NS_BC_BLUONG_CK(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "BC_NS_BC_BLUONG_CK");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_BLUONG_TM(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "BC_NS_BC_BLUONG_TM");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO - ĐÁNH GIÁ CAPITALHOUSE
    public static DataSet Fds_NS_DG_BC_KQUA_DG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["nam_kpi"].ToString()), chuyen.OBJ_S(b_dr["ky_dg_kpi"].ToString()), chuyen.OBJ_S(b_dr["phong"].ToString()) }, 3, "BC_NS_DG_BC_KQUA_DG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable(); DataTable b_dt_2 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_2 = b_ds_kq.Tables[2];
        b_dt_1.TableName = "TONGHOP";
        b_dt_2.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO TỔNG HỢP KẾT QUẢ ĐÁNH GIÁ 360
    public static DataSet Fds_NS_BC_TONGHOP_KQUA_DG_360(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["ky_dg"].ToString()) }, 2, "BC_NS_BC_TONGHOP_KQUA_DG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_KQ_DG_360_CNHAN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["nam1"].ToString()), chuyen.OBJ_S(b_dr["ky_dg"].ToString()), chuyen.OBJ_S(b_dr["hoten"].ToString()) }, 2, "BC_NS_KQ_DG_360_CNHAN");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_DON_DK(ref b_dt, new string[] { "stt", "nd_cauhoi" });
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt_1, "ngay_vao");
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TONGHOP_KQUA_DG_360_DTUONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["nam1"].ToString()), chuyen.OBJ_S(b_dr["ky_dg"].ToString()), chuyen.OBJ_S(b_dr["canbo"].ToString()), chuyen.OBJ_S(b_dr["dtuong"].ToString()) }, 2, "BC_TONGHOP_KQUA_DG_360_DTUONG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_DON_DK(ref b_dt, new string[] { "stt", "nd_cauhoi" });
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt_1, "ngay_vao");
        bang.P_THAY_GTRI(ref b_dt_1, "dtuong", "NB", "Nội bộ");
        bang.P_THAY_GTRI(ref b_dt_1, "dtuong", "KH", "Khách hàng");
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region Hồ sơ nhân sự
    public static DataSet Fds_NS_NGHIVIEC_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["denngay"])) }, 2, "BC_NS_NGHIVIEC_DANHSACH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        bang.P_THAY_GTRI(ref b_dt, "gtinh", "NAM", "Nam");
        bang.P_THAY_GTRI(ref b_dt, "gtinh", "NU", "Nữ");
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "CT", "Đối tượng cư trú");
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "KCT", "Đối tượng không cư trú");
        bang.P_THAY_GTRI(ref b_dt, "xeploai", "M", " ");
        bang.P_THAY_GTRI(ref b_dt, "xeploai", "G", "Giỏi");
        bang.P_THAY_GTRI(ref b_dt, "xeploai", "K", "Khá");
        bang.P_THAY_GTRI(ref b_dt, "xeploai", "TB", "Trung bình");
        bang.P_SO_CNG(ref b_dt, "tungay,denngay,ngay_vao,nsinh,ngay_ct,ngay_nghiviec");
        bang.P_SO_CNG(ref b_dt_1, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_HETHAN_HD_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["denngay"])) }, 2, " BC_NS_HETHAN_HD_DANHSACH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        bang.P_THAY_GTRI(ref b_dt, "gtinh", "NAM", "Nam");
        bang.P_THAY_GTRI(ref b_dt, "gtinh", "NU", "Nữ");
        bang.P_SO_CNG(ref b_dt, "tungay,denngay,ngayd,ngayc");
        bang.P_SO_CNG(ref b_dt_1, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_QUYET_TOAN_THUE_NAM_HDLD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CTH_SO(chuyen.OBJ_S(b_dr["tuthang"])), chuyen.CTH_SO(chuyen.OBJ_S(b_dr["denthang"])), chuyen.OBJ_N(b_dr["nam"].ToString()) }, 2, " BC_NS_QUYET_TOAN_THUE_NAM_HDLD");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        bang.P_SO_CTH(ref b_dt_1, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_QUYET_TOAN_THUE_NAM_KO_HDLD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        //int tuthang = int.Parse(chuyen.OBJ_S(b_dr["nam1"])) * 10000 + 100 + 01;
        //int denthang = int.Parse(chuyen.OBJ_S(b_dr["nam1"])) * 10000 + 12 * 100 + 30;
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CTH_SO(chuyen.OBJ_S(b_dr["tuthang"])), chuyen.CTH_SO(chuyen.OBJ_S(b_dr["denthang"])), chuyen.OBJ_N(b_dr["nam"].ToString()) }, 2, " BC_NS_QT_THUE_NAM_KO_HDLD");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        bang.P_SO_CTH(ref b_dt_1, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_NGUOI_PT_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["ngay"])) }, 2, " BC_NS_NGUOI_PT_DANHSACH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";

        bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc");
        bang.P_SO_CNG(ref b_dt_1, "ngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_CO_CAU_LAODONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["denngay"])) }, 4, "  BC_NS_CO_CAU_LAO_DONG");
        b_ds_kq.Tables[0].TableName = "DATA";
        b_ds_kq.Tables[1].TableName = "DATA2";
        b_ds_kq.Tables[2].TableName = "DATA3";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1], b_dt_2 = b_ds_kq.Tables[2], b_dt_3 = b_ds_kq.Tables[3];
        //b_dt = b_ds_kq.Tables[0];
        //b_dt_1 = b_ds_kq.Tables[1];
        b_dt_3.TableName = "TENBC";
        bang.P_SO_CNG(ref b_dt_3, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_3.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_PHAN_BO_LUONG_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "  BC_NS_PHAN_BO_LUONG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_DIEUCHINH_THUNHAP_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, " BC_NS_DIEU_CHINH_LUONG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "CT", "Đối tượng cư trú");
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "KCT", "Đối tượng không cư trú");
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        //bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_DIEUCHINH_CDANH_DANHSACH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, " BC_NS_DIEU_CHINH_CDANH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_1 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "CT", "Đối tượng cư trú");
        bang.P_THAY_GTRI(ref b_dt, "dt_cutru", "KCT", "Đối tượng không cư trú");
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        //bang.P_SO_CNG(ref b_dt, "ngaysinh,ngayd,ngayc");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BANG_LUONG_IN(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, " BC_NS_BANG_LUONG_IN");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = b_ds_kq.Tables[0], b_dt_2 = b_ds_kq.Tables[1];
        b_dt = b_ds_kq.Tables[0];
        b_dt_2 = b_ds_kq.Tables[1];
        b_dt_2.TableName = "TENBC";
        //bang.P_SO_CNG(ref b_dt_1, "ngaysinh,ngayd,ngayc");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BANG_LUONG_SOSANH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 4, " BC_NS_BANG_LUONG_SOSANH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        DataTable b_dt_1 = new DataTable();
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "DATA2";
        DataTable b_dt_2 = new DataTable();
        b_dt_2 = b_ds_kq.Tables[2];
        b_dt_2.TableName = "TENBC";
        DataTable b_dt_3 = new DataTable();
        b_dt_3 = b_ds_kq.Tables[3];
        b_dt_3.TableName = "TENBC2";
        //bang.P_SO_CNG(ref b_dt_1, "ngaysinh,ngayd,ngayc");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        b_ds.Tables.Add(b_dt_3.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BIENDONG_NS(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_SO(chuyen.OBJ_S(b_dr["denngay"])), b_dr["don_vi"].ToString() }, 2, "BC_NS_BIENDONG_NS");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        foreach (DataRow row in b_dt.Rows)
        {
            if (row["TT"].ToString() == "C1")
            {
                row["TONG_DBIEN"] = bang.Fn_TIM_TONG(b_dt, "TONG_DBIEN");
                row["TONG_QS_D"] = bang.Fn_TIM_TONG(b_dt, "TONG_QS_D");
                row["TONG_LD_D"] = bang.Fn_TIM_TONG(b_dt, "TONG_LD_D");
                row["TONG_QL_D"] = bang.Fn_TIM_TONG(b_dt, "TONG_QL_D");
                row["TONG_NV_D"] = bang.Fn_TIM_TONG(b_dt, "TONG_NV_D");
                row["TONG_TANG"] = bang.Fn_TIM_TONG(b_dt, "TONG_TANG");
                row["TONG_TM"] = bang.Fn_TIM_TONG(b_dt, "TONG_TM");
                row["TONG_DC"] = bang.Fn_TIM_TONG(b_dt, "TONG_DC");
                row["TONG_DC_NB"] = bang.Fn_TIM_TONG(b_dt, "TONG_DC_NB");
                row["TONG_NVIEC"] = bang.Fn_TIM_TONG(b_dt, "TONG_NVIEC");
                row["TONG_TV"] = bang.Fn_TIM_TONG(b_dt, "TONG_TV");
                row["LYDO_CN"] = bang.Fn_TIM_TONG(b_dt, "LYDO_CN");
                row["LYDO_CTY"] = bang.Fn_TIM_TONG(b_dt, "LYDO_CTY");
                row["TRONG_TV"] = bang.Fn_TIM_TONG(b_dt, "TRONG_TV");
                row["SAU_TV"] = bang.Fn_TIM_TONG(b_dt, "SAU_TV");
                row["CBLD"] = bang.Fn_TIM_TONG(b_dt, "CBLD");
                row["CBQL"] = bang.Fn_TIM_TONG(b_dt, "CBQL");
                row["CBNV"] = bang.Fn_TIM_TONG(b_dt, "CBNV");
                row["TONG_QS_C"] = bang.Fn_TIM_TONG(b_dt, "TONG_QS_C");
                row["TONG_LD_C"] = bang.Fn_TIM_TONG(b_dt, "TONG_LD_C");
                row["TONG_QL_C"] = bang.Fn_TIM_TONG(b_dt, "TONG_QL_C");
                row["TONG_NV_C"] = bang.Fn_TIM_TONG(b_dt, "TONG_NV_C");
                row["TONG_QSK_D"] = bang.Fn_TIM_TONG(b_dt, "TONG_QSK_D");
                row["TONG_QSK_T"] = bang.Fn_TIM_TONG(b_dt, "TONG_QSK_T");
                row["TONG_QSK_G"] = bang.Fn_TIM_TONG(b_dt, "TONG_QSK_G");
            }
        }
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "BIEN_NG";
        bang.P_SO_CNG(ref b_dt_1, "tungay,denngay");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO - TIỀN LƯƠNG
    public static DataSet Fds_NS_BC_BANG_LUONG_THANG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "BC_NS_BANG_LUONG_THANG");
        //
        //object[] a_obj = tl_ch.Faobj_NS_TL_BLUONG_CT(chuyen.OBJ_S(b_dr["phong"].ToString()), chuyen.OBJ_S(b_dr["ky_dg"].ToString()),null, 1, 10000);
        //DataTable b_dt = (DataTable)a_obj[1];

        //
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable();
        DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt.TableName = "DATA";
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO CÔNG
    public static DataSet Fds_NS_BC_FTE(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["phong"].ToString()), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "BC_NS_BC_FTE");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_CHAM_CONG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        //DataSet b_ds = new DataSet();
        //string b_loai, b_thang, b_ngayd;
        //b_loai = "1"; b_thang = KYLUONG.Text; b_ngayd = NGAYD.Text;
        //b_ds = tl_cc.Fdt_TEM_NGAY_LKE(b_loai, akyluong.Value, b_ngayd, aphong.Value);
        //DataTable b_dt2 = b_ds.Tables[1]; b_dt2.TableName = "DATA";
        //object[] a_obj = tl_cc.Faobj_CC_CN_CT_CT(aphong.Value, double.Parse(akyluong.Value), 1, int.MaxValue);
        //DataTable b_dt = (DataTable)a_obj[1];
        //bang.P_XEP(ref b_dt, "SO_THE");
        //bang.P_SO_CNG(ref b_dt, "ngayd,tungay,denngay");
        //b_dt.TableName = "DATA1";
        //b_ds.Tables.Add(b_dt);

        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        string b_loai, b_ngayd = "";
        b_loai = "1";
        DataSet b_ds_ngay = tl_cc.Fdt_TEM_NGAY_LKE(b_loai, chuyen.OBJ_S(b_dr["kyluong"].ToString()), b_ngayd, chuyen.OBJ_S(b_dr["phong"].ToString()));
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["phong"].ToString()), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 1, "BC_NS_BC_CHAM_CONG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable();
        DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_SO_CNG(ref b_dt, "ngay_vao");
        b_dt_1 = b_ds_ngay.Tables[1];
        b_dt_1.TableName = "DATA1";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO TUYỂN DỤNG
    public static DataSet Fds_NS_BC_TD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["nam1"].ToString()), chuyen.OBJ_S(b_dr["phong"].ToString()) }, 2, "BC_NS_BC_TD");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_VTRI_TD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["nam1"].ToString()), chuyen.OBJ_S(b_dr["phong"].ToString()) }, 2, "BC_NS_BC_VTRI_TD");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_SO_CNG(ref b_dt, "ngay_dx");
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_UV(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["nam1"].ToString()), chuyen.OBJ_S(b_dr["phong"].ToString()), chuyen.OBJ_S(b_dr["vitri"].ToString()) }, 2, "BC_NS_BC_UV");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_SO_CNG(ref b_dt, "ngay_uv");
        bang.P_SO_CNG(ref b_dt, "ngay_pv1");
        bang.P_SO_CNG(ref b_dt, "ngay_pv2");
        bang.P_SO_CNG(ref b_dt, "ngay_pv3");
        bang.P_SO_CNG(ref b_dt, "ngay_lv");
        bang.P_THAY_GTRI(ref b_dt, "ket_qua", "0", "Chờ thi tuyển");
        bang.P_THAY_GTRI(ref b_dt, "ket_qua", "1", "Đạt");
        bang.P_THAY_GTRI(ref b_dt, "ket_qua", "2", "Không đạt");
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_BC_TONGHOP_TUYENDUNG(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["don_vi"].ToString(), chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["denngay"])) }, 2, "BC_NS_BC_TONGHOP_TUYENDUNG");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt_1, "tu_ngay");
        bang.P_SO_CNG(ref b_dt_1, "den_ngay");
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO- BẢO HIỂM
    public static DataSet Fds_NS_BC_DSACH_DONG_BH(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { b_dr["phong"].ToString(), chuyen.OBJ_S(b_dr["kyluong"].ToString()) }, 2, "BC_NS_DSACH_DONG_BH");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        b_dt_1.TableName = "TENBC";
        bang.P_SO_CTH(ref b_dt_1, "thang_kl");
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion

    #region BÁO CÁO ĐÀO TẠO
    public static DataSet Fds_NS_BC_KHDT_NAM(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["nam"].ToString()) }, 1, "BC_KHDT_NAM");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        //b_dt_1 = b_ds_kq.Tables[1];
        //b_dt_1.TableName = "TENBC"; 
        b_ds.Tables.Add(b_dt.Copy());
        //b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }

    public static DataSet Fds_NS_BC_MASTER_LD(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_SO(b_dr["tungay"].ToString()), chuyen.CNG_SO(b_dr["denngay"].ToString()) }, 3, "BC_DT_MASTER_LD");
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable(); DataTable b_dt_2 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        // sheet 1
        bang.P_SO_CNG(ref b_dt, "ngay_d,ngay_c");
        b_dt_1.TableName = "DATA";
        // sheet 2
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt_1, "ngayd,ngay_d,ngay_c");
        b_dt_1.TableName = "TENBC";
        // tham số
        b_dt_2 = b_ds_kq.Tables[2];
        bang.P_SO_CNG(ref b_dt_2, "ngay_d,ngay_c");
        b_dt_2.TableName = "DATA1"; 
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        b_ds.Tables.Add(b_dt_2.Copy());
        return b_ds;
    }

    public static DataSet Fds_NS_BC_TH_CLUONG_DT(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_S(b_dr["khoa_dt"]) }, 2, "BC_TH_CLUONG_DT");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt, "ngay_hoc");
        string sPathTemplate = "/App_rpt/dt/r_dt_th_cluong_dt.xlsx";
        string strRoot = HttpContext.Current.Server.MapPath("~");
        string sFileTmp = System.Web.HttpContext.Current.Server.MapPath("~" + sPathTemplate);
        Aspose.Cells.License l = new Aspose.Cells.License();
        string strLicense = strRoot + "\\Bin\\Aspose.Cells.lic";
        l.SetLicense(strLicense);
        Aspose.Cells.Workbook wBook = new Aspose.Cells.Workbook(sFileTmp);
        Aspose.Cells.Worksheet wSheet2 = wBook.Worksheets[0];
        Aspose.Cells.Cells cells2 = wSheet2.Cells;
        cells2["C4"].PutValue(b_dt.Rows[0]["TEN_KHOA_HOC"].ToString());
        cells2["C6"].PutValue(b_dt.Rows[0]["NGAY_HOC"].ToString());
        cells2["F6"].PutValue(b_dt.Rows[0]["DDIEM"].ToString());
        cells2["C8"].PutValue(b_dt.Rows[0]["DOI_TAC"].ToString());
        cells2["F8"].PutValue(b_dt.Rows[0]["GIANG_VIEN"].ToString());
        cells2["C10"].PutValue(b_dt.Rows[0]["SL_HVIEN"].ToString());
        cells2["A33"].PutValue(b_dt.Rows[0]["HAILONG"].ToString());
        cells2["A35"].PutValue(b_dt.Rows[0]["KHAILONG"].ToString());

        cells2["D16"].PutValue(b_dt_1.Rows[1]["RTOT"].ToString());
        cells2["D17"].PutValue(b_dt_1.Rows[2]["RTOT"].ToString());
        cells2["D18"].PutValue(b_dt_1.Rows[3]["RTOT"].ToString());
        cells2["D19"].PutValue(b_dt_1.Rows[4]["RTOT"].ToString());

        cells2["D21"].PutValue(b_dt_1.Rows[6]["RTOT"].ToString());
        cells2["D22"].PutValue(b_dt_1.Rows[7]["RTOT"].ToString());
        cells2["D23"].PutValue(b_dt_1.Rows[8]["RTOT"].ToString());
        cells2["D24"].PutValue(b_dt_1.Rows[9]["RTOT"].ToString());

        cells2["D26"].PutValue(b_dt_1.Rows[11]["TOT"].ToString());
        cells2["D27"].PutValue(b_dt_1.Rows[12]["TOT"].ToString());

        cells2["D29"].PutValue(b_dt_1.Rows[14]["TOT"].ToString());
        cells2["D30"].PutValue(b_dt_1.Rows[15]["TOT"].ToString());
        // Tốt
        cells2["E16"].PutValue(b_dt_1.Rows[1]["TOT"].ToString());
        cells2["E17"].PutValue(b_dt_1.Rows[2]["TOT"].ToString());
        cells2["E18"].PutValue(b_dt_1.Rows[3]["TOT"].ToString());
        cells2["E19"].PutValue(b_dt_1.Rows[4]["TOT"].ToString());

        cells2["E21"].PutValue(b_dt_1.Rows[6]["TOT"].ToString());
        cells2["E22"].PutValue(b_dt_1.Rows[7]["TOT"].ToString());
        cells2["E23"].PutValue(b_dt_1.Rows[8]["TOT"].ToString());
        cells2["E24"].PutValue(b_dt_1.Rows[9]["TOT"].ToString());

        cells2["E26"].PutValue(b_dt_1.Rows[11]["TOT"].ToString());
        cells2["E27"].PutValue(b_dt_1.Rows[12]["TOT"].ToString());

        cells2["E29"].PutValue(b_dt_1.Rows[14]["TOT"].ToString());
        cells2["E30"].PutValue(b_dt_1.Rows[15]["TOT"].ToString());
        //Khá
        cells2["F16"].PutValue(b_dt_1.Rows[1]["KHA"].ToString());
        cells2["F17"].PutValue(b_dt_1.Rows[2]["KHA"].ToString());
        cells2["F18"].PutValue(b_dt_1.Rows[3]["KHA"].ToString());
        cells2["F19"].PutValue(b_dt_1.Rows[4]["KHA"].ToString());

        cells2["F21"].PutValue(b_dt_1.Rows[6]["KHA"].ToString());
        cells2["F22"].PutValue(b_dt_1.Rows[7]["KHA"].ToString());
        cells2["F23"].PutValue(b_dt_1.Rows[8]["KHA"].ToString());
        cells2["F24"].PutValue(b_dt_1.Rows[9]["KHA"].ToString());

        cells2["F26"].PutValue(b_dt_1.Rows[11]["KHA"].ToString());
        cells2["F27"].PutValue(b_dt_1.Rows[12]["KHA"].ToString());

        cells2["F29"].PutValue(b_dt_1.Rows[14]["KHA"].ToString());
        cells2["F30"].PutValue(b_dt_1.Rows[15]["KHA"].ToString());
        // Trung bình
        cells2["G16"].PutValue(b_dt_1.Rows[1]["TRUNGBINH"].ToString());
        cells2["G17"].PutValue(b_dt_1.Rows[2]["TRUNGBINH"].ToString());
        cells2["G18"].PutValue(b_dt_1.Rows[3]["TRUNGBINH"].ToString());
        cells2["G19"].PutValue(b_dt_1.Rows[4]["TRUNGBINH"].ToString());

        cells2["G21"].PutValue(b_dt_1.Rows[6]["TRUNGBINH"].ToString());
        cells2["G22"].PutValue(b_dt_1.Rows[7]["TRUNGBINH"].ToString());
        cells2["G23"].PutValue(b_dt_1.Rows[8]["TRUNGBINH"].ToString());
        cells2["G24"].PutValue(b_dt_1.Rows[9]["TRUNGBINH"].ToString());

        cells2["G26"].PutValue(b_dt_1.Rows[11]["TRUNGBINH"].ToString());
        cells2["G27"].PutValue(b_dt_1.Rows[12]["TRUNGBINH"].ToString());

        cells2["G29"].PutValue(b_dt_1.Rows[14]["TRUNGBINH"].ToString());
        cells2["G30"].PutValue(b_dt_1.Rows[15]["TRUNGBINH"].ToString());
        // Kém
        cells2["H16"].PutValue(b_dt_1.Rows[1]["KEM"].ToString());
        cells2["H17"].PutValue(b_dt_1.Rows[2]["KEM"].ToString());
        cells2["H18"].PutValue(b_dt_1.Rows[3]["KEM"].ToString());
        cells2["H19"].PutValue(b_dt_1.Rows[4]["KEM"].ToString());

        cells2["H21"].PutValue(b_dt_1.Rows[6]["KEM"].ToString());
        cells2["H22"].PutValue(b_dt_1.Rows[7]["KEM"].ToString());
        cells2["H23"].PutValue(b_dt_1.Rows[8]["KEM"].ToString());
        cells2["H24"].PutValue(b_dt_1.Rows[9]["KEM"].ToString());

        cells2["H26"].PutValue(b_dt_1.Rows[11]["KEM"].ToString());
        cells2["H27"].PutValue(b_dt_1.Rows[12]["KEM"].ToString());

        cells2["H29"].PutValue(b_dt_1.Rows[14]["KEM"].ToString());
        cells2["H30"].PutValue(b_dt_1.Rows[15]["KEM"].ToString());
        //
        cells2["I15"].PutValue(b_dt_1.Rows[0]["DIEM_TB"].ToString());
        cells2["I16"].PutValue(b_dt_1.Rows[1]["DIEM_TB"].ToString());
        cells2["I17"].PutValue(b_dt_1.Rows[2]["DIEM_TB"].ToString());
        cells2["I18"].PutValue(b_dt_1.Rows[3]["DIEM_TB"].ToString());
        cells2["I19"].PutValue(b_dt_1.Rows[4]["DIEM_TB"].ToString());
        cells2["I20"].PutValue(b_dt_1.Rows[5]["DIEM_TB"].ToString());
        cells2["I21"].PutValue(b_dt_1.Rows[6]["DIEM_TB"].ToString());
        cells2["I22"].PutValue(b_dt_1.Rows[7]["DIEM_TB"].ToString());
        cells2["I23"].PutValue(b_dt_1.Rows[8]["DIEM_TB"].ToString());
        cells2["I24"].PutValue(b_dt_1.Rows[9]["DIEM_TB"].ToString());
        cells2["I25"].PutValue(b_dt_1.Rows[10]["DIEM_TB"].ToString());
        cells2["I26"].PutValue(b_dt_1.Rows[11]["DIEM_TB"].ToString());
        cells2["I27"].PutValue(b_dt_1.Rows[12]["DIEM_TB"].ToString());
        cells2["I28"].PutValue(b_dt_1.Rows[13]["DIEM_TB"].ToString());
        cells2["I29"].PutValue(b_dt_1.Rows[14]["DIEM_TB"].ToString());
        cells2["I30"].PutValue(b_dt_1.Rows[15]["DIEM_TB"].ToString());
        cells2["I31"].PutValue(b_dt_1.Rows[16]["DIEM_TB"].ToString());

        b_ds.Tables.Add(b_dt.Copy());
        wBook.CalculateFormula();
        wBook.Save(HttpContext.Current.Response, "baocaotonghop_chatluong_daotao.xls", Aspose.Cells.ContentDisposition.Attachment, new Aspose.Cells.OoxmlSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003));

        //b_dt_1.TableName = "TENBC"; 
        //b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }

    public static DataSet Fds_NS_KPI_DT(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["nam"].ToString()) }, 1, "BC_KPI_DT");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        bang.P_SO_CNG(ref b_dt, "ngayd");
        b_ds.Tables.Add(b_dt.Copy());
        //b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    public static DataSet Fds_NS_QTTHANGQUY_DT(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.OBJ_N(b_dr["kyluong"].ToString()), chuyen.OBJ_N(b_dr["kyluong_c"].ToString()) }, 1, "PNS_BC_QTTHANGQUY");
        return b_ds_kq;
    }
    public static DataSet Fds_NS_BC_DG_CL_DTAO(DataTable b_dt_tso, string b_ma, string b_ddan, string b_tenrp)
    {
        DataRow b_dr = b_dt_tso.Rows[0];
        DataSet b_ds = new DataSet();
        DataSet b_ds_kq = dbora.Fds_LKE(new object[] { chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["tungay"])), chuyen.CNG_CSO(chuyen.OBJ_S(b_dr["denngay"])) }, 2, "BC_NS_BC_DG_CL_DTAO");
        b_ds_kq.Tables[0].TableName = "DATA";
        DataTable b_dt = new DataTable(); DataTable b_dt_1 = new DataTable();
        b_dt = b_ds_kq.Tables[0];
        b_dt_1 = b_ds_kq.Tables[1];
        bang.P_SO_CNG(ref b_dt_1, "tu_ngay");
        bang.P_SO_CNG(ref b_dt_1, "den_ngay");
        b_dt_1.TableName = "TENBC";
        b_ds.Tables.Add(b_dt.Copy());
        b_ds.Tables.Add(b_dt_1.Copy());
        return b_ds;
    }
    #endregion
}
