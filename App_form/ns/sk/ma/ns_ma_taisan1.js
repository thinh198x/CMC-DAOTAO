var b_choAct = 0, b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_luudayId = '', b_ttrang, b_nhomId;
function ns_ma_taisan_P_KD() {
    b_lkeCho = setInterval('ns_ma_taisan_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') { ns_ma_taisan_P_LKE(); }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_luudayId = b_kq;
            ns_ma_taisan_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_taisan_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) { case "MA": b_maId = b_gocId; break; }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_ma_taisan_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_ma_taisan_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_taisan_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_MA_TAISAN_MA(b_ma, b_TrangKt, a_cot, ns_ma_taisan_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_taisan_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_ma_taisan_P_CHUYEN_HANG(); }
}
function ns_ma_taisan_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    list_P_DAT(b_ttrang, 'A');
    GridX_thoiA(b_grlkeId);
    ns_ma_taisan_P_AUTOGENCODE();
    $get(b_gocId).focus();
    return false;
}
function ns_ma_taisan_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_TAISAN_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_ma_taisan_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_taisan_P_NH_KQ(b_kq) {
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
function ns_ma_taisan_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa!:loi'); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_ma_taisan_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_TAISAN_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_ma_taisan_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_taisan_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_ma_taisan_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_ma_taisan_P_CHUYEN_HANG(); }
        form_P_LOI('loi:Xóa thành công!:loi');
    }
}
function ns_ma_taisan_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_ma_taisan_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_taisan_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XL");
            list_P_DAT(b_ttrang, 'A');
            ns_ma_taisan_P_AUTOGENCODE();
        }
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
        var b_ma_nhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "NHOM"));
        var b_ten_nhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "TEN_NHOM"));
        lke_P_DAT($get(b_nhomId), b_ma_nhom + '{' + b_ten_nhom);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_taisan_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_ttrang = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI'), b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOM'), b_slideId = $get(b_grlkeId).getAttribute('slideId');
        slide_P_MOI(b_slideId);
        ns_ma_taisan_P_LKE();
    }
}
function ns_ma_taisan_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_day = b_luudayId;
        sns_ma_ch.Fs_NS_MA_TAISAN_LKE(form_Fs_nsd(), a_tso, a_cot, b_day, ns_ma_taisan_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_taisan_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_taisan_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { $get(b_gocId).value = b_kq; }
}
function form_dong() {
    location.reload(false);
}
function ns_ma_taisan_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_ma_taisan_P_AUTOGENCODE() {
    var b_kytudau = "TS", b_tenbang = "NS_MA_TAISAN_CAPPHAT", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_taisan_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
// START: Trả giá trị chọn trên lưới //       
// Tra gia tri chon cho form goi
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
// END: Trả giá trị chọn trên lưới //   