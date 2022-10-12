var ns_tl_qtthue_xttin_lkeCho, ns_tl_qtthue_xttin_choAct = 0, b_ma_nsd, b_vungId, b_namId, b_nam, b_grctId

function ns_tl_qtthue_xttin_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ns_tl_qtthue_xttin_lkeCho = setInterval('ns_tl_qtthue_xttin_P_LKE_CHO()', 200);
}

function ns_tl_qtthue_xttin_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            b_nam = b_ma.value;
            ns_tl_qtthue_xttin_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }

}

function ns_tl_qtthue_xttin_P_CHUYEN_HANG() {
    stl_ch.Fs_NS_TL_QTTHUE_XTTIN_CT(form_Fs_nsd(), b_nam, b_ma_nsd, ns_tl_qtthue_xttin_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_tl_qtthue_xttin_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}

//Liệt kê
function ns_tl_qtthue_xttin_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_qtthue_xttin_lkeCho != 0) clearTimeout(ns_tl_qtthue_xttin_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam');
        ns_tl_qtthue_xttin_P_CB();
    }
}

function ns_tl_qtthue_xttin_P_CB() {
    try {
        var b_so_the = b_ma_nsd;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_tl_qtthue_xttin_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_qtthue_xttin_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function form_dong() {
    location.reload(false);
}