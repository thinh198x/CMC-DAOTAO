    var ht_doipass_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
function ht_doipass_P_KD() {
    ht_doipass_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_pascuId = form_Fs_TEN_ID(b_vungId, 'pascu');
    b_pasmoiId = form_Fs_TEN_ID(b_vungId, 'pasmoi');
    b_cfpasId = form_Fs_TEN_ID(b_vungId, 'cfpas');
}

function ht_doipass_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    sht.Fs_DOI_PASS_NH(form_Fs_nsd(),a_dt_ct, ht_doipass_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ht_doipass_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { 
        form_P_LOI("loi:Đổi mật khẩu thành công! Vui lòng đăng nhập lại.:loi");
        menu_P_LOGIN();
    }
    return false;
}

function menu_P_LOGIN() {
    location.reload(false);
}
function form_dong() {
    location.reload(false);
}
