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
/// Summary description for bc
/// </summary>
public class bc
{
    public static DataTable Fdt_LOAI()
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "TN", "Báo cáo số liệu từ ngày ..... đến ngày...." });
        bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Báo cáo số liệu tháng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "Q", "Báo cáo số liệu quý" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "N", "Báo cáo số liệu năm" });
        return b_dt;
    }
    public static DataSet Fds_XEM_BC(string b_md, ref DataTable b_dt_tso)
    {
        string b_ma_bc = chuyen.OBJ_S(b_dt_tso.Rows[0]["ma_bc"]).ToLower(),
               b_ddan = chuyen.OBJ_S(b_dt_tso.Rows[0]["ddan"]),
               b_ten_rp = chuyen.OBJ_S(b_dt_tso.Rows[0]["ten_rp"]);
        if (b_md == "TT") return Fds_BC_KT(b_ma_bc, b_ddan, b_ten_rp, ref b_dt_tso);
        return null;
    }
    public static DataSet Fds_BC_KT(string b_ma_bc, string b_ddan, string b_ten_rp, ref DataTable b_dt_tso)
    {
        DataSet b_ds = new DataSet();
        switch (b_ma_bc)
        {
            case "r_ns_tdoi_tt_hdld":
                b_ds = ns_bc.Fds_NS_TDOI_TT_HDLD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_tke_ldong":
                b_ds = ns_bc.Fds_NS_TKE_LDONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nstl_dsdt_bhyt":
                b_ds = ns_bc.Fds_NSTL_DSDT_BHYT(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nstl_dsld_dchinh_hso":
                b_ds = ns_bc.Fds_NSTL_DSLD_DCHINH_HSO(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nstl_ds_cb_nluong":
                b_ds = ns_bc.Fds_NSTL_DS_CB_NLUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_dsld_dnghi_cap_bh":
                b_ds = ns_bc.Fds_NS_DSLD_DNGHI_CAP_BH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_dsld_dong_bh":
                b_ds = ns_bc.Fds_NS_DSLD_DONG_BH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_excel":
                b_ds = ns_bc.Fds_NS_BC_EXCEL(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_cc_nghiepvu":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_CC_NGVU(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_cc_trinhdo":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_CC_TRINHDO(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_nsvao":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_NSVAO(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_nsra":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_NSRA(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_thuyenchuyen":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_THUYENCHUYEN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dsach_nv":
                b_ds = ns_bc.Fds_NS_BC_EXCEL_DANHSACHNV(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_kyniemngaylv":
                ns_bc.Fds_NS_KYNIEM_THAMNIEN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_danhsach_theo_ncdanh":
                ns_bc.Fds_NS_DANHSACH_THEO_NCDANH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_danhsach_theo_capdt":
                ns_bc.Fds_NS_DANHSACH_THEO_TRINHDO(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nghiphep_tonghop":
                ns_bc.Fds_NS_NGHIPHEP_TONGHOP(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bangluong":
                ns_bc.Fds_NS_TL_LUONGCHUNG_BANGLUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_tonghop_baohiem":
                ns_bc.Fds_NS_BC_TONGHOP_BH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_cb":
                ns_bc.Fds_NS_EXPORT_CB(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_qh":
                ns_bc.Fds_NS_EXPORT_QHE(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_dthv":
                ns_bc.Fds_NS_EXPORT_DTHV(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_nghan":
                ns_bc.Fds_NS_EXPORT_NGHAN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_hdct":
                ns_bc.Fds_NS_EXPORT_HDCT(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_bhxh":
                ns_bc.Fds_NS_EXPORT_BHXH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_hd":
                ns_bc.Fds_NS_EXPORT_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_hdful":
                ns_bc.Fds_NS_EXPORT_HDFUL(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_export_tv":
                ns_bc.Fds_NS_EXPORT_TV(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c66a_hd":
                b_ds = ns_bc.Fds_BHXH_C66A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c67a_hd":
                b_ds = ns_bc.Fds_BHXH_C67A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c68a_hd":
                b_ds = ns_bc.Fds_BHXH_C68A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c69a_hd":
                b_ds = ns_bc.Fds_BHXH_C69A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c70a_hd":
                b_ds = ns_bc.Fds_BHXH_C70A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "bhxh_c67a_178":
                b_ds = ns_bc.Fds_BHXH_C67A_HD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_ds_excel":
                b_ds = ns_bc.Fds_NS_DS_NV(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_qtda_excel":
                b_ds = ns_bc.Fds_NS_BC_QTDA(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_ttda_excel":
                b_ds = ns_bc.Fds_NS_BC_TTDA(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_ctcc_excel":
                b_ds = ns_bc.Fds_NS_BC_CTCC(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_ctbp_excel":
                b_ds = ns_bc.Fds_NS_BC_CTBP(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_ctkhoi_excel":
                b_ds = ns_bc.Fds_NS_BC_CTKHOI(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_tscc_excel":
                b_ds = ns_bc.Fds_NS_BC_TSCC(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_tsbp_excel":
                b_ds = ns_bc.Fds_NS_BC_TSBP(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_tskhoi_excel":
                b_ds = ns_bc.Fds_NS_BC_TSKHOI(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_tinhluong_excel":
                b_ds = ns_bc.Fds_NS_BC_TINHLUONG_SL(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_cn_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_bp_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_khoi_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_duan_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG_DUAN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_duan_anhdan_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG_DUAN_2(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_ns_bc_sanluong_cn2_excel":
                b_ds = ns_bc.Fds_NS_BC_SANLUONG_2(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            // Báo cáo capitalhouse linhnv
            case "r_nv_nhantien_ck":
                b_ds = ns_bc.Fds_NS_BC_BLUONG_CK(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nv_nhantien_tm":
                b_ds = ns_bc.Fds_NS_BC_BLUONG_TM(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dg_bc_kqua_dg":
                b_ds = ns_bc.Fds_NS_DG_BC_KQUA_DG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_ns_biendong_ns":
                b_ds = ns_bc.Fds_NS_BIENDONG_NS(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            //thuong
            case "r_bc_th_kq_dg_360":
                b_ds = ns_bc.Fds_NS_BC_TONGHOP_KQUA_DG_360(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_kqua_dg_360_cnhan":
                b_ds = ns_bc.Fds_NS_KQ_DG_360_CNHAN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_th_kq_dg_360_dtuong":
                b_ds = ns_bc.Fds_NS_BC_TONGHOP_KQUA_DG_360_DTUONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_fte":
                b_ds = ns_bc.Fds_NS_BC_FTE(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_chamcong":
                b_ds = ns_bc.Fds_NS_BC_CHAM_CONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_th_dbien":
                b_ds = ns_bc.Fds_NS_BC_TD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_vtri_td":
                b_ds = ns_bc.Fds_NS_BC_VTRI_TD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_uv":
                b_ds = ns_bc.Fds_NS_BC_UV(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_th_td":
                b_ds = ns_bc.Fds_NS_BC_TONGHOP_TUYENDUNG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dt_dg_cldt":
                b_ds = ns_bc.Fds_NS_BC_DG_CL_DTAO(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            //end
            case "r_nghiviec_danhsach":
                b_ds = ns_bc.Fds_NS_NGHIVIEC_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_hethan_hd_danhsach":
                b_ds = ns_bc.Fds_NS_HETHAN_HD_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_nguoi_pt_danhsach":
                b_ds = ns_bc.Fds_NS_NGUOI_PT_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_quyet_toan_thue_nam_hdld":
                b_ds = ns_bc.Fds_NS_QUYET_TOAN_THUE_NAM_HDLD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_quyet_toan_thue_nam_ko_hdld":
                b_ds = ns_bc.Fds_NS_QUYET_TOAN_THUE_NAM_KO_HDLD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_co_cau_lao_dong":
                b_ds = ns_bc.Fds_NS_CO_CAU_LAODONG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_dieu_chinh_luong":
                b_ds = ns_bc.Fds_NS_DIEUCHINH_THUNHAP_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_dieu_chinh_cdanh":
                b_ds = ns_bc.Fds_NS_DIEUCHINH_CDANH_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_bang_luong_in":
                b_ds = ns_bc.Fds_NS_BANG_LUONG_IN(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_bang_luong_sosanh":
                b_ds = ns_bc.Fds_NS_BANG_LUONG_SOSANH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_phan_bo_luong":
                b_ds = ns_bc.Fds_NS_PHAN_BO_LUONG_DANHSACH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            //Son
            case "r_tl_bangluong_thang":
                b_ds = ns_bc.Fds_NS_BC_BANG_LUONG_THANG(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            // Bảo hiểm
            case "r_dsach_dong_bh":
                b_ds = ns_bc.Fds_NS_BC_DSACH_DONG_BH(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            // Đào tạo
            case "r_dt_khdt_nam":
                b_ds = ns_bc.Fds_NS_BC_KHDT_NAM(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dt_master_ld":
                b_ds = ns_bc.Fds_NS_BC_MASTER_LD(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dt_th_cluong_dt":
                b_ds = ns_bc.Fds_NS_BC_TH_CLUONG_DT(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_dt_kpi_dt":
                b_ds = ns_bc.Fds_NS_KPI_DT(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
            case "r_bc_thangquy":
                b_ds = ns_bc.Fds_NS_QTTHANGQUY_DT(b_dt_tso, b_ma_bc, b_ddan, b_ten_rp); break;
        }
        return b_ds;
    }
    public static DataTable Fdt_LOAI_SL_XEM(string b_dvi, string b_db)
    {
        DataTable b_dt = bang.Fdt_TAO_BANG("ma,ten", "SS");
        bang.P_THEM_HANG(ref b_dt, new object[] { "TATCA", "Tất cả" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TD", "Tuyển dụng" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "HSNS", "Hồ sơ nhân sự" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "CD", "Bảo hiểm" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "CC", "Chấm công" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "TL", "Tiền lương" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DT", "Đào tạo" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DTO", "Đào tạo online" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DG", "Đánh giá" });
        bang.P_THEM_HANG(ref b_dt, new object[] { "DG360", "Đánh giá 360 độ" });

        //bang.P_THEM_HANG(ref b_dt, new object[] { "D", "Thông tin" });
        //bang.P_THEM_HANG(ref b_dt, new object[] { "T", "Thuế" });
        //bang.P_THEM_HANG(ref b_dt, new object[] { "HD", "Hợp đồng" });
        //bang.P_THEM_HANG(ref b_dt, new object[] { "KT", "Khen thưởng - Kỷ luật" });
        //bang.P_THEM_HANG(ref b_dt, new object[] { "TV", "Thôi việc" });
        return b_dt;
    }
    // lấy lưới báo cáo từ bảng phân quyền
    public static object[] Fdt_GRID_BC(string b_ddan, string b_ten, string b_loai_sl, double b_tu_n, double b_den_n)
    {
        se.se_nsd b_se = new se.se_nsd();
        //DataTable b_dt = khac.Fdt_Excel(HttpContext.Current.Server.MapPath(b_ddan + b_ten + ".xls"), "Sheet1");
        DataTable b_dt = new DataTable();
        int b_dong;
        ht_mansd.P_MA_NSD_BC(b_se.ma_dvi, b_se.nsd, b_loai_sl, b_tu_n, b_den_n, out b_dt, out b_dong);
        if (b_loai_sl == "TATCA")
        {
            for (int i = b_dt.Rows.Count - 1; i >= 0; i--)
            {
                if (chuyen.OBJ_S(b_dt.Rows[i]["che"]) == "C") b_dt.Rows.RemoveAt(i);
            } b_dt.AcceptChanges();
        }
        else
        {
            for (int i = b_dt.Rows.Count - 1; i >= 0; i--)
            {
                if (chuyen.OBJ_S(b_dt.Rows[i]["loai"]) != b_loai_sl || chuyen.OBJ_S(b_dt.Rows[i]["che"]) == "C")
                {
                    b_dt.Rows.RemoveAt(i);
                }
            } b_dt.AcceptChanges();
        }


        return new object[]{ b_dong, b_dt};
    }
    // Lấy danh sách báo cáo từ file excel để phân quyền
    public static DataTable Fdt_GRID_BC_EXCEL(string b_ddan, string b_ten, string b_loai_sl)
    {
        se.se_nsd b_se = new se.se_nsd();
        DataTable b_dt = khac.Fdt_Excel(HttpContext.Current.Server.MapPath(b_ddan + b_ten + ".xls"), "Sheet1");
        if (b_loai_sl == "TATCA")
        {
            for (int i = b_dt.Rows.Count - 1; i >= 0; i--)
            {
                if (chuyen.OBJ_S(b_dt.Rows[i]["che"]) == "C") b_dt.Rows.RemoveAt(i);
            } b_dt.AcceptChanges();
        }
        else
        {
            for (int i = b_dt.Rows.Count - 1; i >= 0; i--)
            {
                if (chuyen.OBJ_S(b_dt.Rows[i]["loai"]) != b_loai_sl || chuyen.OBJ_S(b_dt.Rows[i]["che"]) == "C")
                {
                    b_dt.Rows.RemoveAt(i);
                }
            } b_dt.AcceptChanges();
        }


        return b_dt;
    }
    public static DataTable Fdt_NS_DONVI_LKE()
    {
        return dbora.Fdt_LKE("PNS_DONVI_LKE");
    }
}