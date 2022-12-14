var ns_td_phi_td_lkeCho, b_vungId, b_vungtkId, ns_td_phi_td_choAct, b_XuatExcelId, b_grlkeId, b_phongtkId, b_slideId, b_gocId, b_cdanhId,
    b_phongId, b_sl_cantuyenId, b_nam_tkId, b_ma_yctkId, b_cdanh_tkId, b_phong_tkId, b_gchuId;
function ns_td_phi_td_P_KD(XuatExcelId) {
    b_XuatExcelId = XuatExcelId, ns_td_phi_td_choAct = 0,
    ns_td_phi_td_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA_YC'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phong'), form_Fs_TEN_ID(b_vungId, 'sl_tuyendung'),
    b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_ma_yctkId = form_Fs_TEN_ID(b_vungtkId, 'ma_yc_tk'), b_cdanh_tkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'),
    b_phong_tkId = form_Fs_TEN_ID(b_vungtkId, 'phong_tk'), b_phongtkId = form_Fs_VTEN_ID('UPa_hi', 'phongtk');
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_td_phi_td_lkeCho = setInterval('ns_td_phi_td_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_YC_TK") >= 0) {
            $get(b_ma_yctkId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
        } else if (b_dtuong.indexOf("CDANH_TK") >= 0) {
            $get(b_cdanh_tkId).value = a_tso[0];
            $get(b_cdanh_tkId).focus();
        } else if (b_dtuong.indexOf("MA_YC") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_phongId).value = a_tso[1];
            $get(b_cdanhId).value = a_tso[2];
            $get(b_sl_cantuyenId).value = a_tso[3];
            ns_td_kq_P_LKE_DS();
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Kiểm tra
function ns_td_phi_td_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "socmt", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_phi_td_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_phi_td_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_phi_td_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_td.Fs_NS_TD_PHI_TD_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_td_phi_td_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_phi_td_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_phi_td_P_CHUYEN_HANG(); }
}
// Nhập
function ns_td_phi_td_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_td_phi_td_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_td.Fs_NS_TD_PHI_TD_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_td_phi_td_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }

}
function ns_td_phi_td_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
// Xóa 
function ns_td_phi_td_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_yc");
    try {
        if (b_ma == "") ns_td_phi_td_P_MOI();
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_nam = $get(b_nam_tkId).value, b_ma_yc = $get(b_ma_yctkId).value, b_cdanh = $get(b_cdanh_tkId).value, b_phong = lke_Fs_TRA(b_phong_tkId);
            sns_td.Fs_NS_TD_PHI_TD_XOA(form_Fs_nsd(), b_ma, b_nam, b_ma_yc, b_cdanh, b_phong, a_tso, a_cot, ns_td_phi_td_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }

}
function ns_td_phi_td_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_phi_td_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_phi_td_P_CHUYEN_HANG(); }
    }
}
// Chuyển hàng
function ns_td_phi_td_GR_lke_RowChange() {
    if (ns_td_phi_td_choAct != 0) clearTimeout(ns_td_phi_td_choAct);
    ns_td_phi_td_choAct = setTimeout("ns_td_phi_td_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_phi_td_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_yc"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
// Liệt kê
function ns_td_phi_td_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_phi_td_lkeCho); ns_td_phi_td_P_LKE(); }
}
function ns_td_phi_td_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_ma_yc = $get(b_ma_yctkId).value, b_cdanh = $get(b_cdanh_tkId).value, b_phong = lke_Fs_TRA(b_phong_tkId);
        sns_td.Fs_NS_TD_PHI_TD_LKE(form_Fs_nsd(), b_nam, b_ma_yc, b_cdanh, b_phong, a_tso, a_cot, ns_td_phi_td_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_phi_td_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// Xuất file mẫu
function ns_td_phi_td_P_IN() {
    var b_phong = lke_Fs_TRA($get(b_phong_tkId));
    $get(b_phongtkId).value = b_phong;
    __doPostBack(b_XuatExcelId, '');
}
function form_dong() {
    location.reload(false);
}