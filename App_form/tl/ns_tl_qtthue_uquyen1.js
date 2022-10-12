var ns_tl_qtthue_uquyen_lkeCho, ns_tl_qtthue_uquyen_choAct = 0, b_so_idId, b_ma_nsd, b_vungId, b_vungId2, b_grlkeId, b_namId, b_slideId;

function ns_tl_qtthue_uquyen_P_KD(b_nsd) {
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_ma_nsd = b_nsd;
    ns_tl_qtthue_uquyen_lkeCho = setInterval('ns_tl_qtthue_uquyen_P_LKE_CHO()', 200);
}

function ns_tl_qtthue_uquyen_P_MOI() {
    $get(b_so_idId).value = 0;
    form_P_MOI(b_vungId2, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    return false;
}
function ns_tl_qtthue_uquyen_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "nam", b_ma);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tl_qtthue_uquyen_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_tl_qtthue_uquyen_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_qtthue_uquyen_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_namId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ch.Fs_NS_TL_QTTHUE_UQUYEN_MA(form_Fs_nsd(), b_ma, b_ma_nsd, b_TrangKt, a_cot, ns_tl_qtthue_uquyen_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_qtthue_uquyen_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId2, "XLK");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_qtthue_uquyen_P_CHUYEN_HANG(); }
}
function ns_tl_qtthue_uquyen_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        stl_ch.Fs_NS_TL_QTTHUE_UQUYEN_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_tl_qtthue_uquyen_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_tl_qtthue_uquyen_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}

function ns_tl_qtthue_uquyen_GR_lke_RowChange() {
    if (ns_tl_qtthue_uquyen_choAct != 0) clearTimeout(ns_tl_qtthue_uquyen_choAct);
    ns_tl_qtthue_uquyen_choAct = setTimeout("ns_tl_qtthue_uquyen_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_qtthue_uquyen_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId2, "GXLK"); }
    else stl_ch.Fs_NS_TL_QTTHUE_UQUYEN_CT(form_Fs_nsd(), b_so_id, b_ma_nsd, ns_tl_qtthue_uquyen_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_tl_qtthue_uquyen_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}

//Liệt kê
function ns_tl_qtthue_uquyen_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_qtthue_uquyen_lkeCho != 0) clearTimeout(ns_tl_qtthue_uquyen_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
            b_vungId2 = form_Fs_VUNG_ID('UPa_ct2'),
            b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_tl_qtthue_uquyen_P_CB();
        ns_tl_qtthue_uquyen_P_LKE('K');
    }
}
function ns_tl_qtthue_uquyen_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ch.Fs_NS_TL_QTTHUE_UQUYEN_LKE(form_Fs_nsd(), b_ma_nsd, a_tso, a_cot, ns_tl_qtthue_uquyen_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_tl_qtthue_uquyen_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_tl_qtthue_uquyen_P_CB() {
    try {
        var b_so_the = b_ma_nsd;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_tl_qtthue_uquyen_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_qtthue_uquyen_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function form_dong() {
    location.reload(false);
}