var ns_ma_email_sn_lkeCho, b_vungId, b_grlkeId, ns_ma_email_sn_choAct = 0, b_slideId, b_gocId, b_phan_tramId, b_timId, b_tmf, b_ma_dvi, b_tenId,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_ma_email_sn_P_KD(b_dvi) {
    b_tmf = form_Fs_TM('f'); b_ma_dvi = b_dvi;
    ns_ma_email_sn_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA_PN'), b_noidungId = form_Fs_TEN_ID(b_vungId, 'NOIDUNG'),
    b_slideId = b_grlkeId + '_slide';
    ns_ma_email_sn_lkeCho = setInterval('ns_ma_email_sn_P_LKE_CHO()', 200);
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
function ns_ma_email_sn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_PN": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA_PN") {
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma_pn", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_email_sn_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_email_sn_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_email_sn_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_EMAIL_SN_MA(b_ma, b_TrangKt, a_cot, ns_ma_email_sn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_email_sn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_email_sn_P_CHUYEN_HANG(); }
}
function ns_ma_email_sn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}
function ns_ma_email_sn_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return; true; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_EMAIL_SN_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_email_sn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_email_sn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_ma_email_sn_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_pn");
    if (b_ma == "") ns_ma_email_sn_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_EMAIL_SN_XOA(b_ma, a_tso, a_cot, ns_ma_email_sn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_email_sn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_email_sn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_email_sn_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_ma_email_sn_GR_lke_RowChange() {
    if (ns_ma_email_sn_choAct != 0) clearTimeout(ns_ma_email_sn_choAct);
    ns_ma_email_sn_choAct = setTimeout("ns_ma_email_sn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_email_sn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_pn")), a_cot = GridX_Fas_tenCot(b_grlkeId);
        if (b_ma == "") form_P_MOI(b_vungId, "XGL");
        else sns_ma_ch.Fs_NS_MA_EMAIL_SN_CT(form_Fs_nsd(), window.name, b_ma, a_cot, ns_ma_email_sn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_email_sn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    return false;
}
function ns_ma_email_sn_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_ma_email_sn_lkeCho != 0) clearTimeout(ns_ma_email_sn_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_ma_email_sn_P_LKE('K');
    }
}
function ns_ma_email_sn_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_EMAIL_SN_LKE(a_tso, a_cot, ns_ma_email_sn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_email_sn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function ns_ma_email_sn_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) {
            form_P_LOI('loi:Vui lòng chọn 1 pháp nhân:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
        var b_f = C_NVL($get(b_gocId).value);
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_MA_EMAIL_SN", b_f, "Upload file ảnh chúc mừng sinh nhật"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function form_dong() {
    location.reload(false);
}