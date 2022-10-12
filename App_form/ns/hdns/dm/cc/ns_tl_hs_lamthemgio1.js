var b_choAct = 0, b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_ttrang;
function ns_tl_hs_lamthemgio_P_KD() {
    b_lkeCho = setInterval('ns_tl_hs_lamthemgio_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return false;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            ns_tl_hs_lamthemgio_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_hs_lamthemgio_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA":
                $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
                var b_heso = form_Fctr_TEN_DTUONG(b_vungId, 'HESO');
                b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", $get(b_gocId).value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tl_hs_lamthemgio_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); ns_tl_hs_lamthemgio_P_CHUYEN_HANG(); }
                b_heso.focus();
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_hs_lamthemgio_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_cc.Fs_NS_TL_HS_LAMTHEMGIO_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_tl_hs_lamthemgio_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_hs_lamthemgio_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_hs_lamthemgio_P_CHUYEN_HANG(); }
}
function ns_tl_hs_lamthemgio_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    list_P_DAT(b_ttrang, 'A');
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_tl_hs_lamthemgio_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    if ($get(b_heso).value == '') { form_P_LOI("loi:Phải nhập Hệ số thêm giờ:loi"); $get(b_heso).focus(); return false; }
    sns_cc.Fs_NS_TL_HS_LAMTHEMGIO_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_tl_hs_lamthemgio_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_hs_lamthemgio_P_NH_KQ(b_kq) {
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
function ns_tl_hs_lamthemgio_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa!:loi'); return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_tl_hs_lamthemgio_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_TL_HS_LAMTHEMGIO_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_tl_hs_lamthemgio_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_hs_lamthemgio_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_hs_lamthemgio_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_hs_lamthemgio_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
function ns_tl_hs_lamthemgio_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_tl_hs_lamthemgio_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_hs_lamthemgio_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") { form_P_MOI(b_vungId, "XGL"); list_P_DAT(b_ttrang, 'A'); } else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_hs_lamthemgio_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_heso = form_Fs_TEN_ID(b_vungId, 'heso');
        b_ttrang = form_Fctr_TEN_DTUONG(b_vungId, 'TT'), b_slideId = $get(b_grlkeId).getAttribute('slideId');
        slide_P_MOI(b_slideId);
        ns_tl_hs_lamthemgio_P_LKE();
    }
}
function ns_tl_hs_lamthemgio_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_TL_HS_LAMTHEMGIO_LKE(form_Fs_nsd(), a_tso, a_cot, ns_tl_hs_lamthemgio_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_hs_lamthemgio_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}