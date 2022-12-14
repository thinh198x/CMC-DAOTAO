var ns_dt_ma_dtac_lkeCho = 0, ns_dt_ma_dtac_choAct = 0, b_vungId, b_grlkeId, b_grctId, b_grlvchaId, b_gocId, b_gchuId, b_slideId,
    b_slidectId, b_dthoaiId, b_cc_khocId, b_cc_cchiId, b_blacklistId, b_slidelvchaId;
function ns_dt_ma_dtac_P_KD() {
    ns_dt_ma_dtac_lkeCho = setInterval('ns_dt_ma_dtac_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_LVCHA") >= 0) {
            ns_dt_ma_dtac_P_TRA_LVCHA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtac_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return false;
        else if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_dtac_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_dtac_P_CHUYEN_HANG(); }
           // b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtac_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NS_DT_MA_DTAC_MA(b_ma, b_TrangKt, a_cot, ns_dt_ma_dtac_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtac_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang2(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_dtac_P_CHUYEN_HANG(); }
}
function ns_dt_ma_dtac_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    GridX_datTrang(b_grlvchaId);
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ma_dtac_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var a_cot_lvcha = GridX_Fdt_cotGtri(b_grlvchaId);
            var b_ma = $get(b_gocId).value;
            sns_dt.Fs_NS_DT_MA_DTAC_NH(b_ma, a_dt, b_TrangKt, a_cot_ct, a_cot_lvcha, a_cot_lke, ns_dt_ma_dtac_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_dtac_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang2(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_dtac_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_dt_ma_dtac_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_DTAC_XOA(b_ma, a_tso, a_cot, ns_dt_ma_dtac_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_dtac_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        var b_loi;
        if (b_kq.indexOf("doi tac") >= 0) {
            b_loi = "loi:Bản ghi đã được sử dụng ở chức năng khác, không được xóa!:loi";
        }
        form_P_LOI(b_kq);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang2(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_dtac_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_dtac_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_dt_ma_dtac_GR_lke_RowChange() {
    if (ns_dt_ma_dtac_choAct != 0) clearTimeout(ns_dt_ma_dtac_choAct);
    ns_dt_ma_dtac_choAct = setTimeout("ns_dt_ma_dtac_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_dtac_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") ns_dt_ma_dtac_P_MOI();
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var a_cot_lvcha = GridX_Fas_tenCot(b_grlvchaId);
        sns_dt.Fs_NS_DT_MA_DTAC_CT(b_ma, a_cot_ct, a_cot_lvcha, ns_dt_ma_dtac_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_ma_dtac_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang2(b_grctId, a_kq[1]);
    GridX_datBang2(b_grlvchaId, a_kq[2]);
   // slide_P_SOTRANG(b_slidelvchaId);
    slide_P_SOTRANG(b_slidectId);
}
function ns_dt_ma_dtac_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtt = form_Fs_VUNG_ID('UPa_tt');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_grlvchaId = form_Fs_VUNG_ID('Grid_gv');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_dthoaiId = form_Fs_TEN_ID(b_vungId, 'dthoai');
        //b_cc_khocId = form_Fs_TEN_ID(b_vungId, 'cc_khoc');
        //b_cc_cchiId = form_Fs_TEN_ID(b_vungId, 'cc_cchi');
        //b_blacklistId = form_Fs_TEN_ID(b_vungId, 'blacklist');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        //b_slidelvchaId = $get(b_grlvchaId).getAttribute('slideId'); slide_P_MOI(b_slidelvchaId);
        b_slidectId = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slidectId);
        clearTimeout(ns_dt_ma_dtac_lkeCho); ns_dt_ma_dtac_P_LKE();
    }
}
function ns_dt_ma_dtac_P_LKE() {
    try {
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_DTAC_LKE(a_tso, a_cot, ns_dt_ma_dtac_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtac_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang2(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_dtac_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_dtac_HangLen(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    if (mode == 2) b_grct = b_grlvchaId;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_dt_ma_dtac_HangXuong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    if (mode == 2) b_grct = b_grlvchaId;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_dt_ma_dtac_CatDong(mode) {
    var b_grct;
    if (mode == 1) {
        b_grct = b_grctId;
    }
    else if (mode == 2) {
        b_grct = b_grlvchaId;
    }
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function ns_dt_ma_dtac_ChenDong(b_dk) {
    var b_ktrahten = C_NVL(GridX_Fas_layGtriA(b_grctId, 'hten'));
    if (b_ktrahten == '') form_P_LOI("loi:Chọn dòng dữ liệu cần chèn thêm một hàng trước nó trên bảng Thông tin người liên hệ:loi");
    else {
        GridX_chenHang(b_grctId);
    }
    return false;
}
function ns_dt_ma_dtac_P_TRA_LVCHA() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlvchaId);
        sns_dt.Fs_NS_DT_MA_LVCHA_LAY(form_Fs_nsd(), a_cot, ns_dt_ma_dtac_P_TRA_LVCHA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtac_P_TRA_LVCHA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang2(b_grlvchaId, a_kq[1]);
    slide_P_SOTRANG(b_slidelvchaId);
}