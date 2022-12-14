var b_choAct = 0, b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_ttrang;
function ns_hdns_ma_bh_tn_P_KD() {
    b_lkeCho = setInterval('ns_hdns_ma_bh_tn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return false;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            ns_hdns_ma_bh_tn_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bh_tn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA":
                $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
                var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", $get(b_gocId).value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_bh_tn_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bh_tn_P_CHUYEN_HANG(); }
                b_ten.focus();
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bh_tn_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_BH_TN_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_hdns_ma_bh_tn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bh_tn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bh_tn_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_bh_tn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    list_P_DAT(b_ttrang, 'A');
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_hdns_ma_bh_tn_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_MA_BH_TN_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_hdns_ma_bh_tn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_bh_tn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
function ns_hdns_ma_bh_tn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa!:loi'); return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_hdns_ma_bh_tn_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_BH_TN_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_hdns_ma_bh_tn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_bh_tn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_bh_tn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bh_tn_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
function ns_hdns_ma_bh_tn_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_ma_bh_tn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_bh_tn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            list_P_DAT(b_ttrang, 'A');
        }
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bh_tn_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_Ten = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_ttrang = form_Fctr_TEN_DTUONG(b_vungId, 'TT'), b_slideId = $get(b_grlkeId).getAttribute('slideId');
        slide_P_MOI(b_slideId);
        ns_hdns_ma_bh_tn_P_LKE();
    }
}
function ns_hdns_ma_bh_tn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_BH_TN_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_ma_bh_tn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bh_tn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_ma_bh_tn_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}