var ns_dt_ma_kynang_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_nkynangId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_ma_kynang_P_KD() {
    ns_dt_ma_kynang_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_nkynangId = form_Fs_TEN_ID(b_vungId, 'NKYNANG');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_ma_kynang_lkeCho = setInterval('ns_dt_ma_kynang_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NKYNANG") >= 0) {
            $get(b_nkynangId).value = b_kq;
            ns_dt_ma_kynang_P_LKE(); form_P_MOI(b_vungId, "GX");
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_ma_kynang_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "NKYNANG": b_maId = b_nkynangId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_kynang_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_kynang_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
        if (b_maTen == "NKYNANG") {
            ns_dt_ma_kynang_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kynang_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nkynang = lke_Fs_TRA($get(b_nkynangId));
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dto.Fs_NS_DT_MA_KYNANG_MA(b_nkynang, b_ma, b_TrangKt, a_cot, ns_dt_ma_kynang_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kynang_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_kynang_P_CHUYEN_HANG(); }
}

function ns_dt_ma_kynang_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
    $get(b_gocId).focus();
}


var ns_dt_ma_kynang_choAct = 0;
function ns_dt_ma_kynang_GR_lke_RowChange() {
    if (ns_dt_ma_kynang_choAct != 0) clearTimeout(ns_dt_ma_kynang_choAct);
    ns_dt_ma_kynang_choAct = setTimeout("ns_dt_ma_kynang_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_dt_ma_kynang_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_dto.Fs_NS_DT_MA_KYNANG_NH(b_TrangKt, a_dt_ct, a_cot, ns_dt_ma_kynang_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_ma_kynang_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Ghi thành công:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_dt_ma_kynang_P_MOI() {
    $get(b_nkynangId).value = "";
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ns_dt_ma_kynang_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_ma_kynang_P_MOI();
    else {
        var b_nkynang = lke_Fs_TRA($get(b_nkynangId));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_MA_KYNANG_XOA(b_nkynang, b_ma, a_tso, a_cot, ns_dt_ma_kynang_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_kynang_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_kynang_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_kynang_P_CHUYEN_HANG(); }
    }
}

function ns_dt_ma_kynang_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_nkynang = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nkynang")), b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        if (b_ma == "") form_P_MOI(b_vungId, "XGL");
        else sns_dto.Fs_NS_DT_MA_KYNANG_CT(form_Fs_nsd(), b_nkynang, b_ma, a_cot, ns_dt_ma_kynang_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_kynang_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}

function ns_dt_ma_kynang_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_ma_kynang_lkeCho != 0) clearTimeout(ns_dt_ma_kynang_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_ma_kynang_P_LKE('K');
    }
}
function ns_dt_ma_kynang_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_nkynang = lke_Fs_TRA($get(b_nkynangId)), a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dto.Fs_NS_DT_MA_KYNANG_LKE(b_nkynang, a_tso, a_cot, ns_dt_ma_kynang_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_ma_kynang_P_LKE_KQ(b_kq) {
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