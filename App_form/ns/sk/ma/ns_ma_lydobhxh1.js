var ns_ma_lydobhxh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_tt, b_loai;
var ns_ma_lydobhxh_choAct = 0;
function ns_ma_lydobhxh_P_KD() {
    ns_ma_lydobhxh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_loai = form_Fs_TEN_ID(b_vungId, 'MA_NHOM')
    b_slideId = b_grlkeId + '_slide';
    ns_ma_lydobhxh_lkeCho = setInterval('ns_ma_lydobhxh_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_tt = 1;
            ns_ma_lydobhxh_P_NHOM(b_kq);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lydobhxh_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_lydobhxh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_lydobhxh_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lydobhxh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        var a_loaima = form_Fctr_TEN_DTUONG('', 'ma_nhom').value;
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_LYDOBHXH_MA(a_loaima, b_ma, b_TrangKt, a_cot, ns_ma_lydobhxh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lydobhxh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_lydobhxh_P_CHUYEN_HANG(); }
}
function ns_ma_lydobhxh_GR_lke_RowChange() {

    if (ns_ma_lydobhxh_choAct != 0) clearTimeout(ns_ma_lydobhxh_choAct);
    ns_ma_lydobhxh_choAct = setTimeout("ns_ma_lydobhxh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_lydobhxh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_LYDOBHXH_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_lydobhxh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_lydobhxh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
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
function ns_ma_lydobhxh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
    list_P_DAT(b_drop, 'A');
    $get(b_gocId).focus();
    return false;
}
function ns_ma_lydobhxh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    var a_loaima = form_Fctr_TEN_DTUONG('', 'ma_nhom').value;
    if (b_ma == "") ns_ma_lydobhxh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_LYDOBHXH_XOA(a_loaima, b_ma, a_tso, a_cot, ns_ma_lydobhxh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_lydobhxh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_lydobhxh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_lydobhxh_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_ma_lydobhxh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma")),
             b_manhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_nhom")), b_tennhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_nhom"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL");
        else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            lke_P_DAT($get(b_loai), b_manhom + '{' + b_tennhom);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lydobhxh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_lydobhxh_P_MOI();
        if (ns_ma_lydobhxh_lkeCho != 0) clearTimeout(ns_ma_lydobhxh_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_ma_lydobhxh_P_LKE('K');
    }
}
function ns_ma_lydobhxh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_loaima = form_Fctr_TEN_DTUONG('', 'ma_nhom').value;   
        sns_ma_ch.Fs_NS_MA_LYDOBHXH_LKE(a_loaima, a_tso, a_cot, ns_ma_lydobhxh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_lydobhxh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_lydobhxh(b_maloai) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var a_loaima = form_Fctr_TEN_DTUONG('', 'ma_nhom').value;
        sns_ma_ch.Fs_NS_MA_LYDOBHXH_LKE(a_loaima, a_tso, a_cot, ns_ma_lydobhxh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
//function ns_ma_lydobhxh_P_LKE_KQ(b_kq) {
//    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
//    var a_kq = Fas_ChMang(b_kq, '#');
//    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
//    GridX_datBang(b_grlkeId, a_kq[1]);
//}
function ns_ma_lydobhxh_P_NHOM(b_ma_nhom) {
    try {
        if (b_ma_nhom != "") {
            sns_ma_ch.Fs_NS_MA_KHAC_CHON(form_Fs_nsd(), b_ma_nhom, ns_ma_khac_P_NHOM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_lydobhxh_P_NHOM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    ns_ma_khac_lkeCho = setInterval('ns_ma_khac_P_LKE_CHO()', 200);
}
function form_dong() {
    location.reload(false);
}