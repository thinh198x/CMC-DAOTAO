var ht_ds_user_online_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, ht_ds_user_online_choAct,
        b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_checkMessage = "";
function ht_ds_user_online_P_KD() {
    ht_ds_user_online_lkeCho = setInterval('ht_ds_user_online_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
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
function ht_ds_user_online_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ht_ds_user_online_lkeCho != 0) clearTimeout(ht_ds_user_online_lkeCho);
        ht_ds_user_online_lkeCho, ht_ds_user_online_choAct = 0,
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ht_ds_user_online_P_LKE('K');
    }
}
function ht_ds_user_online_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sht_ma.Fs_HT_DS_USER_ONLINE_LKE(a_cot, a_tso, ht_ds_user_online_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ht_ds_user_online_P_LKE_KQ(b_kq) {
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
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}