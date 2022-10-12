var ns_dt_ma_ctdt_ht_lkeCho, b_vungId, b_gchuId, b_ncdId, ns_dt_ma_ctdt_ht_choAct = 0, b_grctId, b_grlkeId, b_slideId, b_vungtkId, b_namId, b_so_idId, b_cho_control = 0, b_namId, b_ngay_hlId, b_ncdanh_tk;
function ns_dt_ma_ctdt_ht_P_KD() {
    ns_dt_ma_ctdt_ht_lkeCho = setInterval('ns_dt_ma_ctdt_ht_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_NCDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["ten_ncdanh"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["ncdanh"], [a_tso[0]], 'K');
            $get(b_ncdId).value = a_tso[0];

        } else if (b_dtuong.indexOf("TEN_CDANH") >= 0) {
            b_doi = 0;
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["ten_cdanh"], [a_tso[1]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["cdanh"], [a_tso[0]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_ctdt_ht_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_namId; form_P_MOI("", "XGL"); break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_ctdt_ht_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
function ns_dt_ma_ctdt_ht_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    GridX_datTrang(b_grctId);
    return false;
}
function ns_dt_ma_ctdt_ht_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        sns_dt.Fs_NS_DT_MA_CTDT_HT_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_dt_ma_ctdt_ht_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_ctdt_ht_P_NH_KQ(b_kq) {
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
function ns_dt_ma_ctdt_ht_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_dt_ma_ctdt_ht_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_CTDT_HT_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_dt_ma_ctdt_ht_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_ctdt_ht_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_ctdt_ht_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_ctdt_ht_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuy?n hàng
function ns_dt_ma_ctdt_ht_GR_lke_RowChange() {
    if (ns_dt_ma_ctdt_ht_choAct != 0) clearTimeout(ns_dt_ma_ctdt_ht_choAct);
    ns_dt_ma_ctdt_ht_choAct = setTimeout("ns_dt_ma_ctdt_ht_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_ctdt_ht_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else sns_dt.Fs_NS_DT_MA_CTDT_HT_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ns_dt_ma_ctdt_ht_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_ma_ctdt_ht_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    return false;
}
//Li?t kê
function ns_dt_ma_ctdt_ht_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_ma_ctdt_ht_lkeCho != 0) clearTimeout(ns_dt_ma_ctdt_ht_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_ncdId = form_Fs_TEN_ID(b_vungId, 'hincd'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_ma_ctdt_ht_P_LKE('K');
    }
}
function ns_dt_ma_ctdt_ht_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_CTDT_HT_LKE(form_Fs_nsd(), a_tso, a_cot, ns_dt_ma_ctdt_ht_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_ma_ctdt_ht_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}

function ns_dt_ma_ctdt_ht_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_dt_ma_ctdt_ht_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_dt_ma_ctdt_ht_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_ma_ctdt_ht_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_dt_ma_ctdt_ht_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}