var ns_dt_ma_cchi_lkeCho = 0, ns_dt_ma_cchi_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ghichuId, b_lvchaId, b_lvchaTk, b_hthuc_thiTk,
    b_lvconId, b_dvi_capId, b_nsd, b_vungtkId, b_hthuc_thiId, b_trangthaiId;
function ns_dt_ma_cchi_P_KD() {
    ns_dt_ma_cchi_lkeCho = setInterval('ns_dt_ma_cchi_P_LKE_CHO()', 200);
}
function ns_dt_ma_cchi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "LVCHA": b_maId = b_lvchaId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "MA") {
            $get(b_gocId).value = b_ma.value.validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_cchi_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_cchi_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
        else if (b_maTen == "LVCHA") {
            var b_lvcha = form_Fs_TEN_GTRI(b_vungId, 'lvcha');
            $get(b_lvconId).value = "";
            sns_dt.Fs_NS_DT_MA_LVCON_DR(window.name, b_lvcha, ns_dt_ma_cchi_P_LVCON_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_cchi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var a_tk = form_Faa_TEXT_ROW(b_vungtkId);
            sns_dt.Fs_NS_DT_MA_CCHI_MA(a_tk, b_ma, b_TrangKt, a_cot, ns_dt_ma_cchi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_cchi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "LX");
        $get(b_hthuc_thiId).value = "";
    }
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_cchi_P_CHUYEN_HANG(); }
}
function ns_dt_ma_cchi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        return false;
    } else form_P_DatGchu(b_ghichuId, b_kq);
}
function ns_dt_ma_cchi_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    $get(b_hthuc_thiId).value = "";
    list_P_DAT(b_trangthaiId, 'A');
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ma_cchi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 1) b_hang = -1;
            var a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_tk = form_Faa_TEXT_ROW(b_vungtkId);
            sns_dt.Fs_NS_DT_MA_CCHI_NH(a_tk, b_TrangKt, a_dt_ct, a_cot, ns_dt_ma_cchi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_cchi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_cchi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_ma_cchi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_tk = form_Faa_TEXT_ROW(b_vungtkId);
        sns_dt.Fs_NS_DT_MA_CCHI_XOA(a_tk, b_ma, a_tso, a_cot, ns_dt_ma_cchi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_cchi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            ns_dt_ma_cchi_P_MOI();
            form_P_LOI("Xóa thành công!"); return false;
        }
        else {
            GridX_datA(b_grlkeId, b_hang); ns_dt_ma_cchi_P_CHUYEN_HANG();
            form_P_LOI("Xóa thành công!"); return false;
        }
    }
    return false;
}
function ns_dt_ma_cchi_GR_lke_RowChange() {
    if (ns_dt_ma_cchi_choAct != 0) clearTimeout(ns_dt_ma_cchi_choAct);
    ns_dt_ma_cchi_choAct = setTimeout("ns_dt_ma_cchi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_cchi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") ns_dt_ma_cchi_P_MOI();
    else sns_dt.Fs_NS_DT_MA_CCHI_CT(window.name, b_ma, ns_dt_ma_cchi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_ma_cchi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_ma_cchi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk');
        b_lvchaTk = form_Fs_TEN_ID(b_vungtkId, 'LVCHA_TK');
        b_hthuc_thiTk = form_Fs_TEN_ID(b_vungtkId, 'hthuc_thi_tk');
        b_hthuc_thiId = form_Fs_TEN_ID(b_vungId, 'hthuc_thi');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_lvchaId = form_Fs_TEN_ID(b_vungId, 'LVCHA');
        b_lvconId = form_Fs_TEN_ID(b_vungId, 'LVCON');
        b_dvi_capId = form_Fs_TEN_ID(b_vungId, 'DVI_CAP');
        b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
        b_ghichuId = form_Fs_VTEN_ID('', 'ghichu');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        ns_dt_ma_cchi_P_KTRA('LVCHA');
        clearTimeout(ns_dt_ma_cchi_lkeCho); ns_dt_ma_cchi_P_LKE();
    }
}
function ns_dt_ma_cchi_P_LKE() {
    try {
        var b_lvcha = lke_Fs_TRA(b_lvchaTk), b_hthuc_thi = list_Fs_IdTRA(b_hthuc_thiTk);
        if (b_hthuc_thi != "" && b_lvcha == "") {
            form_P_LOI("loi:Phải chọn Lĩnh vực cha:loi");
            return false;
        }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_tk = form_Faa_TEXT_ROW(b_vungtkId);
        sns_dt.Fs_NS_DT_MA_CCHI_LKE(a_tk, a_tso, a_cot, ns_dt_ma_cchi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_cchi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_cchi_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_check = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tinhtrang"));
    form_P_TRA_CHON('MA,TEN');
    return false;
}
function ns_dt_ma_cchi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_cchi_P_LVCON_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}