var b_tmf, b_vungId, b_vung_tkId, b_grlkeId, b_grtreeId, b_ltieudeId, b_ten_bcId, b_gchuId, b_lrepId, b_loaiId, b_chon_inId, b_thangId, b_tr_daotaoId, b_vungHi,
    b_ma_tkId, b_ma_cbId, b_td_donviId, b_td_phongId, b_tr_namId, b_tr_kyluongId, b_tr_kyluong_cId, b_ky_dgId, b_tr_canboId, b_ky_dtuongId, b_namanId, b_VitriId, b_nv_ngay_dgId, b_trThangId,
    b_tr_namkpiId, b_tr_ky_dgkpiId, b_slideIdct, b_loai_slId;
function ns_ngbc_P_KD(b_tm, b_chon_in) {
    b_tmf = b_tm; b_chon_inId = b_chon_in;
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_vung_tkId = form_Fs_VUNG_ID('UPa_tk'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_grtreeId = form_Fs_VUNG_ID('GR_tree'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_lrepId = form_Fs_VTEN_ID('', 'lrep'); b_slideIdct = $get(b_grlkeId).getAttribute('slideId');
    b_ltieudeId = form_Fs_VTEN_ID('', 'ltieude'); b_ten_bcId = form_Fs_TEN_ID(b_vungId, 'ten_bc');
    b_td_donviId = form_Fs_VUNG_ID('trdonvi'), b_td_phongId = form_Fs_VUNG_ID('trPhong'), b_tr_namId = form_Fs_VUNG_ID('trNam'), b_tr_kyluongId = form_Fs_VUNG_ID('trKyluong'), b_namId = form_Fs_VUNG_ID('trNam1'), b_VitriId = form_Fs_VUNG_ID('trVitri')
    b_tr_ky_dgId = form_Fs_VUNG_ID('trKyDG'), b_tr_namkpiId = form_Fs_VUNG_ID('trNam_kpi'), b_tr_ky_dgkpiId = form_Fs_VUNG_ID('trKyDG_KPI'), b_nvienId = form_Fs_VUNG_ID('trNhanVien'),
    b_tr_dtuongId = form_Fs_VUNG_ID('trDtuong'), b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'), b_tr_kyluong_cId = form_Fs_VUNG_ID('trKyluong_c'),
    b_tr_canboId = form_Fs_VUNG_ID('trCanBo'), b_ky_dtuongId = form_Fs_TEN_ID(b_vungId, 'dtuong'), b_tr_daotaoId = form_Fs_VUNG_ID('trdt');
    b_nv_tungay_dgId = form_Fs_VUNG_ID('trNGHIVIEC_TUNGAY'), b_nv_denngay_dgId = form_Fs_VUNG_ID('trNGHIVIEC_DENNGAY'), b_thangId = form_Fs_VUNG_ID('trTHANG');
    b_namanId = form_Fs_TEN_ID(b_vungHi, 'naman'); b_nv_ngay_dgId = form_Fs_VUNG_ID('trNGHIVIEC_NGAY'); b_nv_tuthang_dgId = form_Fs_VUNG_ID('trNGHIVIEC_TUTHANG'); b_nv_denthang_dgId = form_Fs_VUNG_ID('trNGHIVIEC_DENTHANG');
    b_loai_slId = form_Fs_TEN_ID(b_vung_tkId, 'loai_sl'), b_trThangId = form_Fs_VUNG_ID('trThang_tk'), b_ma_cbId = form_Fs_TEN_ID(b_vungId, 'ma_cb');
    lke_P_DAT($get(b_loai_slId), 'TATCA' + '{' + 'Tất cả');
    ns_ngbc_P_KTRA('LOAI_SL');
    ns_ngbc_P_LOADTREE('LOAI_SL');
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_CB") >= 0) { $get(b_ma_cbId).value = b_kq; $get(b_ma_cbId).focus(); }
        else if (b_dtuong.indexOf("MA_TK") >= 0) { $get(b_ma_cbId).value = b_kq; $get(b_ma_cbId).focus(); }
    }
    catch (err) { form_P_LOI(err); }
}
// KTRA
function ns_ngbc_P_KTRA(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "TEN_BC") {
            var b_ten_bc = $get(b_ten_bcId);
            if (b_ten_bc.selectedIndex > -1) {
                $get(b_lrepId).innerHTML = "Report: " + b_ten_bc.value;
                ns_ngbc_P_DatGchu(b_ten_bc[b_ten_bc.selectedIndex].innerHTML);
            }
        }
        else if (b_maTen == "LOAI_SL") {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_loai_sl = lke_Fs_TRA($get(b_loai_slId)), a_tso = slide_Faobj_TUDEN(b_slideIdct);
            //đường dẫn mở lên file báo cáo     "~/App_from/bc/ns/", "ns_ngbc"
            sbc.Fs_GRID_BC("~/App_form/bc/ns/", "ns_ngbc", b_loai_sl, a_cot, a_tso, ns_ngbc_P_GRID_BC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {

            //skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ngbc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// KTRA
function ns_ngbc_P_LOADTREE(b_maTen) {
    try {
        b_maTen = b_maTen.toUpperCase();
        if (b_maTen == "LOAI_SL") {
            var a_cot = GridX_Fas_tenCot(b_grtreeId), b_loai_sl = lke_Fs_TRA($get(b_loai_slId));
            //đường dẫn mở lên file báo cáo     "~/App_from/bc/ns/", "ns_ngbc"
            sbc.Fs_LOAD_TREE(a_cot, ns_ngbc_P_GRID_TREE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {

            //skhac.Fs_MA_LOI(form_Fs_nsd(),b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ngbc_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ngbc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_DatGchu(b_gchuId, b_kq);
}
function ns_ngbc_P_GRID_BC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#'); slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_ngbc_P_GRID_TREE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grtreeId, b_kq);
}
function ns_ngbc_GR_lke_RowChange() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ma_bc = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_bc"), ""),
            b_rep = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "rep"), ""),
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten"), ""),
            b_ddan = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ddan"), "");
        // form_Fctr_VTEN_DTUONG('', 'nhap').disabled = (b_ma_bc == "") ? true : false;
        //$get(b_ltieudeId).innerHTML = (b_ten == "") ? "Báo cáo nhân sự" : b_ten.replace("--", "");
        //ns_ngbc_HIEN_AN(b_ma_bc);
        //$get(b_loaiId).focus();
        
        ns_ngbc_HIEN_AN_Grid(b_ma_bc);
        form_Fctr_TEN_DTUONG('', 'ten_menu').value = b_ma_bc;
        form_Fctr_TEN_DTUONG('', 'ddan').value = b_ddan;
        form_Fctr_TEN_DTUONG('', 'ten_rp').value = b_rep;
        //sbc.Fs_MO_MAU_BC(b_ddan, b_rep, b_ten, ns_ngbc_TEN_BC_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_ngbc_P_MOI();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ngbc_GR_tree_RowChange() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ma_dv = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), "")
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ngbc_TEN_BC_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    drop_P_LKE(b_ten_bcId, b_kq);
    var b_ten_bc = $get(b_ten_bcId);
    if (b_ten_bc.selectedIndex > -1) {
        $get(b_gchuId).innerHTML = b_ten_bc[b_ten_bc.selectedIndex].innerHTML;
        $get(b_lrepId).innerHTML = b_ten_bc.value;
    }
}
///An hiển các control trên Sửa ở đây

function ns_ngbc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_ngbc_HIEN_AN_Grid(b_ma_bc) {
    try {
        $get(b_VitriId).style.display = 'none';
        $get(b_td_donviId).style.display = 'none';
        $get(b_td_phongId).style.display = 'none';
        $get(b_tr_namId).style.display = 'none';
        $get(b_namId).style.display = 'none';
        $get(b_tr_kyluongId).style.display = 'none';
        $get(b_tr_ky_dgId).style.display = 'none';
        $get(b_tr_namkpiId).style.display = 'none';
        $get(b_tr_ky_dgkpiId).style.display = 'none';
        $get(b_nvienId).style.display = 'none';
        $get(b_tr_canboId).style.display = 'none';
        $get(b_tr_dtuongId).style.display = 'none';
        $get(b_nv_tungay_dgId).style.display = 'none';
        $get(b_nv_denngay_dgId).style.display = 'none';
        $get(b_thangId).style.display = 'none';
        $get(b_tr_daotaoId).style.display = 'none';
        $get(b_nv_ngay_dgId).style.display = 'none';
        $get(b_nv_tuthang_dgId).style.display = 'none';
        $get(b_nv_denthang_dgId).style.display = 'none';
        $get(b_trThangId).style.display = 'none';
        $get(b_tr_kyluong_cId).style.display = 'none';
        switch (b_ma_bc) {
            case "r_nv_nhantien_ck":
                $get(b_td_phongId).style.display = '';
                $get(b_tr_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_nv_nhantien_tm":
                $get(b_td_phongId).style.display = '';
                $get(b_tr_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
                //thuong
            case "r_bc_th_kq_dg_360":
                $get(b_namId).style.display = '';
                $get(b_tr_ky_dgId).style.display = '';
                break;
            case "r_kqua_dg_360_cnhan":
                $get(b_namId).style.display = '';
                $get(b_tr_ky_dgId).style.display = '';
                $get(b_nvienId).style.display = '';
                break;
            case "r_bc_th_kq_dg_360_dtuong":
                $get(b_namId).style.display = '';
                $get(b_tr_ky_dgId).style.display = '';
                $get(b_tr_dtuongId).style.display = '';
                $get(b_tr_canboId).style.display = '';
                break;
            case "r_bc_fte":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_bc_chamcong":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_bc_th_dbien":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                break;
            case "r_bc_vtri_td":
                $get(b_namId).style.display = '';
                $get(b_td_phongId).style.display = '';
                break;
            case "r_bc_uv":
                $get(b_namId).style.display = '';
                $get(b_td_phongId).style.display = '';
                $get(b_VitriId).style.display = '';
                break;
            case "r_bc_th_td":
                $get(b_td_donviId).style.display = '';
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
                //end
            case "r_dg_bc_kqua_dg": // linhnv
                $get(b_td_phongId).style.display = '';
                $get(b_tr_namkpiId).style.display = '';
                $get(b_tr_ky_dgkpiId).style.display = '';
                break;
            case "r_nghiviec_danhsach":
                $get(b_td_phongId).style.display = '';
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            case "r_bc_ns_biendong_ns":
                $get(b_td_donviId).style.display = '';
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            case "r_hethan_hd_danhsach":
                $get(b_td_phongId).style.display = '';
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            case "r_nguoi_pt_danhsach":
                $get(b_td_phongId).style.display = '';
                $get(b_nv_ngay_dgId).style.display = '';
                break;
            case "r_bc_quyet_toan_thue_nam_hdld":
                $get(b_td_phongId).style.display = '';
                $get(b_tr_namId).style.display = '';
                $get(b_nv_tuthang_dgId).style.display = '';
                $get(b_nv_denthang_dgId).style.display = '';
                break;
            case "r_bc_quyet_toan_thue_nam_ko_hdld":
                $get(b_td_phongId).style.display = '';
                $get(b_tr_namId).style.display = '';
                $get(b_nv_tuthang_dgId).style.display = '';
                $get(b_nv_denthang_dgId).style.display = '';
                break;
            case "r_bc_dieu_chinh_luong":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_bc_dieu_chinh_cdanh":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_bc_co_cau_lao_dong":
                $get(b_td_phongId).style.display = '';
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            case "r_bc_bang_luong_sosanh":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_tl_bangluong_thang":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
                
            case "r_bc_phan_bo_luong":
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
            case "r_dsach_dong_bh":
                $get(b_td_phongId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                //$get(b_thangId).style.display = '';
                break;
                // Đào tạo 
            case "r_dt_khdt_nam":
                $get(b_tr_namId).style.display = '';
                //$get(b_td_phongId).style.display = '';
                break;
            case "r_dt_master_ld":
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            case "r_dt_th_cluong_dt":
                $get(b_tr_namId).style.display = '';
                $get(b_tr_daotaoId).style.display = '';
                break;
            case "r_dt_kpi_dt":
                $get(b_namId).style.display = '';
                break;
            case "r_bc_thangquy":
                $get(b_td_phongId).style.display = 'none';
                $get(b_tr_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                $get(b_tr_kyluong_cId).style.display = '';
                break;
            case "r_dt_dg_cldt":
                $get(b_nv_tungay_dgId).style.display = '';
                $get(b_nv_denngay_dgId).style.display = '';
                break;
            default:
                $get(b_td_phongId).style.display = '';
                $get(b_namId).style.display = '';
                $get(b_tr_kyluongId).style.display = '';
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_ngbc_HIEN_AN(b_ma_bc) {
    try {
        form_P_MOI('', "X");
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_tkdu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nhom').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_qui').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'tien_dc').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_lc').disabled = true;
        form_Fctr_TEN_DTUONG(b_vungId, 'luu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'in_malc').disabled = true;

        switch (b_ma_bc) {
            case "tt_squi_tm": //Sổ qũi tiền mặt
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                sbc.Fs_SE_DVI(ns_ngbc_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "tt_soct_nh_ngte":
            case "tt_soct_nh_nte": //Sổ chi tiết ngân hàng nội tệ
                if (b_ma_bc == "tt_soct_nh_ngte") {
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "112";
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "USD";
                }
                else if (b_ma_bc == "tt_soct_nh_nte") {
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "112";
                    form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                }
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tkdu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nhom').disabled = false;
                break;
            case "tt_bc_sdu_ct_nh": //Báo cáo số dư chi tiết tại ngân hàng
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nh').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'nh_tk').disabled = false;
                break;
            case "tt_bc_tc_nte": //Thu chi ngoại tệ
                break;
            case "tt_bcqui": //Báo cáo số dư theo mã quỹ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_qui').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'tien_dc').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_nt').value = "VND";
                break;
            case "tt_lke_ct_lc_tt": //Liệt kê chức từ lưu chuyển tiền tệ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_lc').disabled = false;
                sbc.Fs_SE_DVI(ns_ngbc_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
            case "tt_bcao_lc_tt": //Báo cáo lưu chuyển tiền tệ
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'luu').disabled = form_Fctr_TEN_DTUONG(b_vungId, 'in_malc').disabled = false;
                form_Fctr_TEN_DTUONG(b_vungId, 'ma_tk').value = "11";
                sbc.Fs_SE_DVI(ns_ngbc_P_DVI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
//sửa đây
function ns_ngbc_P_XEM() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_ma_bc = form_Fctr_TEN_DTUONG('', 'ten_menu').value,
            b_ddan = form_Fctr_TEN_DTUONG('', 'ddan').value,
            b_kieu_in = ns_ngbc_P_CHON_IN(), a_dt_ct = form_Faa_TEXT_ROW(b_vungId),
            b_ten_rp = form_Fctr_TEN_DTUONG('', 'ten_rp').value,
            b_ma_cb = form_Fctr_TEN_DTUONG('', 'ma_cb').value;

        var b_hang = GridX_Fi_timHangA(b_grtreeId);
        if ((b_hang < 1 && b_ma_bc == "r_ns_bc_ds_excel") || (b_hang < 1 && b_ma_cb == "" & b_ma_bc == "r_ns_bc_ctcc_excel")) return false;
        var b_ma_donvi = C_NVL(GridX_Fas_layGtri(b_grtreeId, b_hang, "ma"));
        var b_ma_da = form_Fctr_TEN_DTUONG('', 'duan').value;

        var b_ten_bc = lke_Fs_TRA($get(b_ten_bcId));
        if (b_ten_bc != "") {
            b_ten_rp = b_ten_bc;
        }
        //if (b_ten_rp == "") { form_P_LOI('Chưa chọn đúng báo cáo'); return false; }
        //modul bhxh "ns_ngbc", "TT", 
        sbc.Fs_BKT_LUU_TSO("ns_ngbc", "TT", b_ma_bc, b_ddan, b_ten_rp, b_ma_donvi, b_ma_da, b_kieu_in, a_dt_ct, ns_ngbc_P_XEM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
//Sửa đây
function ns_ngbc_P_XEM_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_kieu_in = ns_ngbc_P_CHON_IN();
    var b_excel = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "excel"), "");
    if (b_excel == "C" && b_kieu_in == "X") { form_P_MO(b_tmf + '/App_form/bc/ExcelView.aspx?md=TT', null, null, "C"); return false; }
    else { form_P_MO(b_tmf + '/App_form/bc/xem_bc.aspx?md=TT', null, null, "C"); return false; }
}
function ns_ngbc_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam1');
        var ktra = "DT_KY_DG";
        sbc.Fs_DANHSACH_KYLUONG_LKE(b_nam, ns_ngbc_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, ktra, ns_ngbc_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ngbc_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
    }
}
function ns_ngbc_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
// Năm đánh giá KPI
function ns_ngbc_P_NAM_KPI() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam_kpi');
        var ktra = "DT_KY_DG_KPI";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, dg_ngv_kqua_dg_kpi_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dg_ngv_kqua_dg_kpi_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
    }
}
function ns_ngbc_P_CHON_IN() {
    var b_chon_in = document.getElementById(b_chon_inId);
    var b_chon = b_chon_in.getElementsByTagName('input');
    for (var x = 0; x < b_chon.length; x++)
    { if (b_chon[x].checked) return b_chon[x].value; }

}
function ns_ngbc_P_DVI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_Fctr_TEN_DTUONG(b_vungId, 'ma_dvi').value = b_kq;
}
function ns_ngbc_P_KY_DG() {
    try {
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        var ktra = "DT_HOTEN";
        stl_ch.Fdt_BC_DG360_TTCB(window.name, b_ky_dg, ktra, ns_ngbc_P_KY_DG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { }
}
function ns_ngbc_P_DTUONG() {
    try {
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        var b_dtuong = lke_Fs_TRA($get(b_ky_dtuongId));
        var ktra = "DT_CANBO";
        stl_ch.Fdt_BC_DG360_TTCB_DTUONG(window.name, b_ky_dg, b_dtuong, ktra, ns_ngbc_P_KY_DG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } catch (err) { }
}
function ns_ngbc_P_KY_DG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
    }
}
//
function ns_ngbc_P_NAM_DT() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        var ktra = "DT_KHOA";
        sns_dt.Fdt_NS_DT_DANHGIA_CL_KDT_DR(window.name, b_nam, ktra, ns_ngbc_P_KHOA_DT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ngbc_P_KHOA_DT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
    }
}

function form_dong() {
    location.reload(false);
}