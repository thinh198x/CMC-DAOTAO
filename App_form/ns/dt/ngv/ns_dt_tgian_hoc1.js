var ns_dt_tgian_hoc_lkeCho, b_vungId, b_grlkeId, b_ngaydId, b_ngaycId, b_vungTkId, ns_dt_tgian_hoc_choAct = 0, b_slideId, b_gocId, b_sothe_tnId,
    b_tenId, b_tuoiId, b_so_idId, b_gchuId, b_moiId, b_nsd, b_ten, b_ngaydkyId, b_loaidkyId, b_giodId, b_giocId, b_sophutId;
function ns_dt_tgian_hoc_P_KD(nsd) {
    b_nsd = nsd;
    ns_dt_tgian_hoc_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'NAM'),
    b_sothe_tnId = form_Fs_TEN_ID(b_vungId, 'so_the'),
    b_gchuId = form_Fs_VTEN_ID('', 'gchu2');
    b_so_idId = form_Fs_VTEN_ID('', 'so_id');
    ns_dt_tgian_hoc_lkeCho = setInterval('ns_dt_tgian_hoc_P_LKE_CHO()', 200);
}
function ns_dt_tgian_hoc_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            ns_dt_tgian_hoc_P_CT();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tgian_hoc_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_tgian_hoc_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_tgian_hoc_lkeCho != 0) clearTimeout(ns_dt_tgian_hoc_lkeCho);
        ns_dt_tgian_hoc_P_CB();
    }
}
function ns_dt_tgian_hoc_P_CB() {
    try {
        var b_so_the = b_nsd;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_dt_tgian_hoc_P_CB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tgian_hoc_P_CB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") { form_P_LOI("loi:Nhân viên chưa được làm quyết đinh.:loi"); $get(b_gocId).value = ""; return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ns_dt_tgian_hoc_P_CT() {
    try {
        var b_nam = $get(b_gocId).value;
        sns_dt.Fs_NS_DT_TGIAN_HOC_P_CT(form_Fs_nsd(), b_nam, b_nsd, ns_dt_tgian_hoc_P_CB_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_tgian_hoc_P_CB_kq(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == "") return false;
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function form_dong() {
    location.reload(false);
}