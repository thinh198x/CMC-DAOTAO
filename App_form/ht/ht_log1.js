var ht_log_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, ht_log_choAct, b_phanheId, b_nhom_chucnangId, b_ma_tkId, b_chucnangId, b_tungayId, b_denngayId,
    b_aphanheId, b_anhom_cnId, b_ataikhoanId, b_achucnangId, b_atungayId, b_adenngayId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_checkMessage = "";
function ht_log_P_KD() {
    ht_log_lkeCho = setInterval('ht_log_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// Liệt kê
function ht_log_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ht_log_lkeCho != 0) clearTimeout(ht_log_lkeCho);
        ht_log_lkeCho, ht_log_choAct = 0,
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_phanheId = form_Fs_TEN_ID(b_vungtkId, 'phanhe_tk'), b_nhom_chucnangId = form_Fs_TEN_ID(b_vungtkId, 'nhom_chucnang_tk'),
        b_ma_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_tk_tk'), b_chucnangId = form_Fs_TEN_ID(b_vungtkId, 'chucnang_tk'),
        b_tungayId = form_Fs_TEN_ID(b_vungtkId, 'tungay_tk'), b_denngayId = form_Fs_TEN_ID(b_vungtkId, 'denngay_tk'),
        b_aphanheId = form_Fs_VTEN_ID('UPa_hi', 'aphanhe'), b_anhom_cnId = form_Fs_VTEN_ID('UPa_hi', 'anhom_cn'), b_ama_tkId = form_Fs_VTEN_ID('UPa_hi', 'ama_tk'),
        b_achucnangId = form_Fs_VTEN_ID('UPa_hi', 'achucnang'), b_atungayId = form_Fs_VTEN_ID('UPa_hi', 'atungay'), b_adenngayId = form_Fs_VTEN_ID('UPa_hi', 'adenngay'),
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ht_log_P_LKE('K');
    }
}
function ht_log_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_phanhe = $get(b_phanheId).value, b_nhom_chucnang = $get(b_nhom_chucnangId).value,
            b_ma_tk = $get(b_ma_tkId).value, b_chucnang = $get(b_chucnangId).value,
            b_tungay = $get(b_tungayId).value, b_denngay = $get(b_denngayId).value;
        sht_ma.Fs_HT_LOG_LKE(form_Fs_nsd(), b_phanhe, b_nhom_chucnang, b_ma_tk, b_chucnang, b_tungay, b_denngay, a_cot, a_tso, ht_log_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_log_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Xuất excel
function checkEmpty() {
    $get(b_aphanheId).value = $get(b_phanheId).value;
    $get(b_anhom_cnId).value = $get(b_nhom_chucnangId).value;
    $get(b_ama_tkId).value = $get(b_ma_tkId).value;
    $get(b_achucnangId).value = $get(b_achucnangId).value;
    $get(b_atungayId).value = $get(b_atungayId).value;
    $get(b_adenngayId).value = $get(b_adenngayId).value;

    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}