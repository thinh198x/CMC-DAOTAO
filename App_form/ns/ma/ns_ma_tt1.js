var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_ten_form, b_choAct = 0, b_ma_qg_tim = '', b_tt = '';
function ns_ma_tt_P_KD() {
    b_lkeCho = setInterval('ns_ma_tt_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_QG") >= 0) {
            $get(b_ma_qg).value = b_kq;
            //b_ma_qg_tim = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_ma_qg).focus();
            ns_ma_tt_P_LKE();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_ma_qg).value = b_kq;
            b_ma_qg_tim = b_kq;
            b_tt = 'A';
            ns_ma_tt_P_LKE(); form_P_MOI(b_vungId, "GX");
            $get(b_ma_qg).focus();
            b_lkeCho = setInterval('ns_ma_tt_P_MA_KTRAID()', 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tt_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_tt_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_tt_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tt_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        var b_maqg = C_NVL($get(b_ma_qg).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_TT_MA(b_maqg, b_ma, b_TrangKt, a_cot, b_tt, ns_ma_tt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_tt_P_CHUYEN_HANG(); }
}
function ns_ma_tt_P_MOI() {
    GridX_thoiA(b_grlkeId);
    form_P_MOI(b_vungId, "KXL");
    var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
    list_P_DAT(b_drop, 'A');
    var b_kytudau = "TT", b_tenbang = "NS_MA_TT", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_tt_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function ns_ma_tt_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_TT_NH(b_TrangKt, a_dt_ct, a_cot, ns_ma_tt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_tt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        //if (b_hang >= 0) form_P_LOI("loi:Sửa thành công:loi");
        //else
        form_P_LOI("loi:Ghi thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function ns_ma_tt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { ns_ma_tt_P_MOI(); form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); }
    else {
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var b_tim = C_NVL($get(b_timId).value), a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_TT_XOA(b_tim, b_ma, a_tso, a_cot, ns_ma_tt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_tt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_tt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_tt_P_CHUYEN_HANG(); }
    }
}
function ns_ma_tt_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_ma_tt_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_tt_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "KXGL");
            var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
            list_P_DAT(b_drop, 'A');
            var b_kytudau = "TT", b_tenbang = "NS_MA_TT", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_tt_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tt_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_ma_qg = form_Fs_TEN_ID(b_vungId, 'MA_QG'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'), b_slideId = $get(b_grlkeId).getAttribute('slideId'), slide_P_MOI(b_slideId);
        b_timId = form_Fs_VTEN_ID('', 'tim_ten'); ns_ma_tt_P_LKE();
    }
}
function ns_ma_tt_P_LKE() {
    try {
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_TT_LKE(b_ma_qg_tim, a_tso, a_cot, b_tt, ns_ma_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_tt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0 && C_NVL($get(b_gocId).value) != '') {
        var b_ma = $get(b_gocId).value, b_ten = $get(b_tenId).value;
        form_P_DAY(window.name, b_ten_form, "NC_CMT", [b_ma, b_ten]);
        form_P_TRA_CHON('MA,TEN');
    }
    else
        alert('Bạn chưa chọn phòng ban');
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_ma_tt_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_ma_tt_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function ns_ma_tt_P_MA_KTRAID() {
    try {
        var b_ma_qgid = form_Fctr_TEN_DTUONG(b_vungId, 'MA_QG');

        if (b_ma_qgid != "") {
            Attribute_P_DAT(b_ma_qgid, 'f_tkhao', '');
            clearTimeout(b_lkeCho);
        }
    }
    catch (err) { form_P_LOI(err); }
}