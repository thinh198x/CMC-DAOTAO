var ns_dt_phukhao_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_phukhao_P_KD() {
    ns_dt_phukhao_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_phukhao_lkeCho = setInterval('ns_dt_phukhao_P_LKE_CHO()', 200);

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
function ns_dt_phukhao_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_phukhao_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_phukhao_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}

var ns_dt_phukhao_choAct = 0;
function ns_dt_phukhao_GR_lke_RowChange() {
    if (ns_dt_phukhao_choAct != 0) clearTimeout(ns_dt_phukhao_choAct);
    ns_dt_phukhao_choAct = setTimeout("ns_dt_phukhao_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_phukhao_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_phukhao_lkeCho != 0) clearTimeout(ns_dt_phukhao_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_phukhao_P_LKE('K');
    }
}

function ns_dt_phukhao_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ns_dt_phukhao_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_phukhao_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_PHUCKHAO_LKE(a_tso, a_cot, ns_dt_phukhao_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_phukhao_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function form_dong() {
    location.reload(false);
}