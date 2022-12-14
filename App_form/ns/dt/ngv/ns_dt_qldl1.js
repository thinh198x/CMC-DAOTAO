var ns_dt_qldl_lkeCho = 0, ns_dt_qldl_choAct = 0, b_vungId, b_grlkeId, b_gchuId, b_slideId, b_vungHi, b_vungTk, b_ma_khTk, b_ten_khTk,
    b_so_idHi, b_ten_khId, b_ma_khId, b_ten_hsId;
function ns_dt_qldl_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi'), b_vungTk = form_Fs_VUNG_ID('UPa_tk');
    b_ma_khTk = form_Fs_TEN_ID(b_vungTk, 'ma_kh_tk');
    b_ten_khTk = form_Fs_TEN_ID(b_vungTk, 'ten_kh_tk');
    b_ten_khId = form_Fs_TEN_ID(b_vungId, 'TEN_KH');
    b_ma_khId = form_Fs_TEN_ID(b_vungId, 'ma_kh');
    b_ten_hsId = form_Fs_TEN_ID(b_vungId, 'ten_hs');
    b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_nsd = form_Fs_nsd();
    b_slideId = b_grlkeId + '_slide';
    ns_dt_qldl_lkeCho = setInterval('ns_dt_qldl_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_dt_ma_lvcon_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_KH_TK") >= 0) {
            $get(b_ma_khTk).value = b_kq;
            $get(b_ten_khTk).value = a_tso[1];
        }
        else if (b_dtuong.indexOf("TEN_KH") >= 0) {
            $get(b_ma_khId).value = b_kq;
            $get(b_ten_khId).value = a_tso[1];
            form_P_MOI(b_vungId, "LX");
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ten_hsId).focus();
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_qldl_GR_lke_RowChange() {
    if (ns_dt_qldl_choAct != 0) clearTimeout(ns_dt_qldl_choAct);
    ns_dt_qldl_choAct = setTimeout("ns_dt_qldl_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_qldl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_qldl_lkeCho); ns_dt_qldl_P_LKE(); }
}
function ns_dt_qldl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_ten_khId).focus();
    return false;
}
function ns_dt_qldl_P_LKE() {
    try {
        var b_ma_kh = $get(b_ma_khTk).value;
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_QLDL_LKE(b_ma_kh, a_tso, a_cot, ns_dt_qldl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_qldl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_qldl_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var b_so_id = $get(b_so_idHi).value;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_dt.Fs_NS_DT_QLDL_NH(b_so_id, a_dt_ct, b_TrangKt, a_cot_lke, ns_dt_qldl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_qldl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_ten_khId).focus();
    }
    return false;
}
function ns_dt_qldl_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") ns_dt_qldl_P_MOI();
    else {
        $get(b_so_idHi).value = b_so_id;
        sns_dt.Fs_NS_DT_QLDL_CT(b_so_id, ns_dt_qldl_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_qldl_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq); form_P_CH_TEXT(b_vungHi, b_kq);
}
function ns_dt_qldl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_dt_qldl_P_MOI();
    else {
        var b_ma_kh = $get(b_ma_khTk).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_QLDL_XOA(b_ma_kh, b_so_id, a_tso, a_cot, ns_dt_qldl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_qldl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_qldl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_qldl_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_dt_qldl_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap2', '');
}
function form_dong() {
    location.reload(false);
}
