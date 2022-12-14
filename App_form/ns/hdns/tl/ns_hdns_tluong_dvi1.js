var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_grctId, b_slideId, b_slidectId, b_vungHi, b_ma_tlId, b_ma_nlId, b_ngay_hlId, form_chay;
function ns_hdns_tluong_dvi_P_KD() {
    b_lkeCho = setInterval('ns_hdns_tluong_dvi_P_LKE_CHO()', 200);
}
function ns_hdns_tluong_dvi_P_KTRA(b_maTen) {
    try {
        var b_ma_Id = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_TL": b_ma_Id = b_ma_tlId; break;
            case "MA_NL": b_ma_Id = b_ma_nlId; break;
        }
        var b_ma = $get(b_ma_Id);
        if (b_maTen == "MA_TL") {
            var b_ma_tl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
            sns_ma_ch.Fs_NS_HDNS_MA_TL_NL(window.name, b_ma_tl, P_LOI_CSDL, P_LOI_TGIAN);
            sns_ma_ch.Fs_NS_MA_TL_NGAY_HL(b_ma_tl, ns_hdns_tluong_dvi_P_KTRA_HL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_NL") {
            ns_hdns_tluong_dvi_P_MA_KTRA();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tluong_dvi_P_KTRA_HL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_ngay_hlId).value = b_kq;
}
function ns_hdns_tluong_dvi_P_MA_KTRA() {
    try {
        var b_phong = form_Fs_TEN_GTRI(b_vungId, 'CTY'), b_ngay_hl = form_Fs_TEN_GTRI(b_vungId, 'NGAY_HL'), b_ma_tl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL'), b_ma_nl = form_Fs_TEN_GTRI(b_vungId, 'MA_NL');
        if (b_phong != '' && b_ngay_hl != '' && b_ma_tl != '' && b_ma_nl != '') {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_HDNS_TLUONG_DVI_MA(form_Fs_nsd(), b_phong, b_ngay_hl, b_ma_tl, b_ma_nl, b_TrangKt, a_cot, ns_hdns_tluong_dvi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tluong_dvi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { form_P_MOI(b_vungId, "X"); ns_hdns_tluong_dvi_P_BACLUONG(); }
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_tluong_dvi_P_CHUYEN_HANG(); }
}
function ns_hdns_tluong_dvi_P_BACLUONG() {
    var b_ma_tl = lke_Fs_TRA(b_ma_tlId), b_ma_nl = lke_Fs_TRA(b_ma_nlId);
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    sns_ma_ch.Fs_NS_HDNS_MA_BACLUONG_LKE_CT(form_Fs_nsd(), window.name, b_ma_tl, b_ma_nl, a_cot_ct, ns_hdns_tluong_dvi_P_BACLUONG_LKE_CT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_hdns_tluong_dvi_P_BACLUONG_LKE_CT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else GridX_datBang(b_grctId, b_kq);
}
function ns_hdns_tluong_dvi_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    return false;
}
function ns_hdns_tluong_dvi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_ma_ch.Fs_NS_HDNS_TLUONG_DVI_NH(form_Fs_nsd(), a_dt, a_cot_ct, b_TrangKt, a_cot_lke, ns_hdns_tluong_dvi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_hdns_tluong_dvi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_tluong_dvi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_tluong_dvi_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_hdns_tluong_dvi_P_MOI(); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            var b_ma_tl = form_Fs_TEN_GTRI(b_vungId, 'MA_TL');
            sns_ma_ch.Fs_NS_HDNS_TLUONG_DVI_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_hdns_tluong_dvi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_hdns_tluong_dvi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_tluong_dvi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_tluong_dvi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_tluong_dvi_GR_lke_RowChange() {
    if (b_lkeCho != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_tluong_dvi_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_tluong_dvi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "" || b_so_id == 0) {
            form_P_MOI(b_vungId, "GLX");
            GridX_datTrang(b_grctId);
        }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_ma_ch.Fs_NS_HDNS_TLUONG_DVI_CT(form_Fs_nsd(), window.name, b_so_id, a_cot_ct, ns_hdns_tluong_dvi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tluong_dvi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
}
function ns_hdns_tluong_dvi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'), b_slidectId = $get(b_grctId).getAttribute('slideId'), slide_P_MOI(b_slideId), slide_P_MOI(b_slidectId);
        b_ma_tlId = form_Fs_TEN_ID(b_vungId, 'MA_TL'), b_ma_nlId = form_Fs_TEN_ID(b_vungId, 'MA_NL'), b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        ns_hdns_tluong_dvi_P_LKE();
    }
}
function ns_hdns_tluong_dvi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_HDNS_TLUONG_DVI_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_tluong_dvi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_tluong_dvi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_tluong_dvi_HangLen(mode) {
    var b_grctId;
    if (mode == 1) b_grctId = b_grctId;
    else return false;
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_hdns_tluong_dvi_HangXuong(mode) {
    var b_grctId;
    if (mode == 1) b_grctId = b_grctId;
    else return false;
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_hdns_tluong_dvi_CatDong(mode) {
    var b_grctId;
    if (mode == 1) b_grctId = b_grctId;
    else return false;
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_hdns_tluong_dvi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_hdns_tluong_dviTL_NL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    ns_hdns_tluong_dvi_P_LKE();

}
function ns_hdns_tluong_dvi_NL_NNN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else list_P_LKE(form_Fs_TEN_ID(b_vungId, 'MA_NNNGHE'), b_kq);
    ns_hdns_tluong_dvi_P_LKE();
    return false;
}
function ns_hdns_tluong_dvi_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_tluong_dvi_P_TLUONG() {
    try {
        var b_tl = CSO_SO($get(b_tluongId).value, 2), b_lcb = CSO_SO($get(b_lcbId).value, 2);
        var b_tdg = SO_CSO(b_tl - b_lcb);
        $get(b_tdgId).value = b_tdg;
    }
    catch (err) { form_P_LOI(err); }
}
function ktra_tien(b_tongluong, b_luong_cb) {
    if (b_luong_cb == 0 || b_luong_cb == null) { return ""; }
    else if (b_luong_cb > b_tongluong) { return "loi:Lương cơ bản không được lớn hơn Tổng lương:loi"; }
    return "";
}
function ns_hdns_tluong_dvi_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function ns_hdns_tluong_dvi_GR_Update(b_event) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        var b_tongluong = CSO_SO(GridX_Fas_layGtriA(b_grctId, "tongluong"));
        var b_luong_cb = CSO_SO(GridX_Fas_layGtriA(b_grctId, "luong_cb"));
        if (b_luong_cb == 0) {
            GridX_datGtri(b_grctId, b_hang, ["thuong_dg"], "", 'K');
            return false;
        } else {
            var ktra = ktra_tien(b_tongluong, b_luong_cb);
            if (Fb_LOI_KTRA(ktra)) { form_P_LOI(ktra); return false; }
            var b_thuong_dg = b_tongluong - b_luong_cb;
            GridX_datGtri(b_grctId, b_hang, ["thuong_dg"], SO_CSO(b_thuong_dg), 'K');
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}