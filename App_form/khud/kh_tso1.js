var b_lkeCho, b_vungId, b_nuocId, b_tsoForm;
function kh_tso_KD(tsoForm) {
    b_tsoForm = tsoForm;
    b_lkeCho = setInterval('kh_tso_CHO()', 300);
}
function kh_tso_CHO() {
    if (document.readyState === 'complete') {
        clearInterval(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_nuocId = form_Fs_TEN_ID(b_vungId, 'nuoc');
        if (b_tsoForm != '') form_P_CH_TEXT(b_vungId, b_tsoForm);
        kh_tso_NUOC();
        //form_F_GOC().P_MENUBf(window.name, 'T');
    }
}
function kh_tso_NUOC() {
    var b_nuoc = $get(b_nuocId);
    var b_ma = list_Fs_TRA(b_nuoc);
    b_nuoc.style.background = "#FFF url('../../images/flag/" + b_ma + ".png') right no-repeat";
    return false;
}
function kh_tso_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != '') form_P_LOI_DICH(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            skhud.Fs_NSD_TSO_NH(form_Fs_nsd(), a_dt, kh_tso_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function kh_tso_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_f = form_F_GOC();
        b_f.modal = form_Fs_TEN_GTRI(b_vungId, 'modal');
        b_mobi = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'mobi')); b_nuoc = form_Fs_TEN_GTRI(b_vungId, 'nuoc');
        b_nuoc_c = b_f.nuoc;
        if (b_nuoc_c != b_nuoc) { b_f.nuoc = b_nuoc; b_f.form_CDICH(window.name, b_nuoc, b_nuoc_c); }
        if (b_mobi != '') skhud.Fs_NSD_TSO_SMS(b_mobi, P_LOI_KQ, P_LOI_CSDL, P_LOI_TGIAN); 
        form_P_LOI("loi:Nhập dữ liệu thành công:loi"); return false; 
    }
}
function kh_tso_P_DONG() {
    var b_goc = form_F_GOC();
    if (b_goc.b_form_popUp == 'K') b_goc.menu_CHO(); else form_P_DONG(window.name);
    return false;
}
