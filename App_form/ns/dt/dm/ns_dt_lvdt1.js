var ns_dt_lvdt_lkeCho = 0, b_vungId, b_vunghiId, b_grlkeId, b_slideId, b_excelId, b_timId, ns_dt_lvdt_choAct = 0;;
function ns_dt_lvdt_P_KD() {
    ns_dt_lvdt_lkeCho = setInterval('ns_dt_lvdt_P_LKE_CHO()', 200);
}
function ns_dt_lvdt_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_dt_lvdt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vunghiId = form_Fs_VUNG_ID('UPa_hi');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_dt_lvdt_lkeCho); GridX_taoScroll(b_grlkeId); ns_dt_lvdt_P_LKE();
    }
}
function ns_dt_lvdt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_dt.Fs_NS_DT_MA_LVCHA_LKE_A(form_Fs_nsd(), a_cot, ns_dt_lvdt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_lvdt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq[1] == '') form_P_LOI('loi:Không tìm thấy thông tin bạn đang tìm kiếm:loi');
        GridX_datBang(b_grlkeId, a_kq[1]); slide_P_SOTRANG(b_slideId);
    }
}
function form_P_TRA_LIST() {
    var a_cot = GridX_Fdt_cotGtriH(b_grlkeId);
    sns_dt.Fs_NS_DT_MA_LVCHA_TRA(form_Fs_nsd(), a_cot, form_P_TRA_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function form_P_TRA_LIST_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else {
        form_P_TRA_CHON('');
    }
    return false;
}
function form_dong() {
    location.reload(false);
}