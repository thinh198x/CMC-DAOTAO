var b_lkeCho, b_vungId, b_vunghiId, b_grlkeId, b_slideId, b_excelId, b_timId, b_choAct = 0, b_cho_control = 0, b_doi = 0, b_chon_allId;
function ns_hdns_cdanh_tk_P_KD() {
    b_lkeCho = setInterval('ns_hdns_cdanh_tk_P_LKE_CHO()', 200);
}
function P_cho() {
    try {
        if (b_doi == 0) {
            clearTimeout(b_cho_control);
            ns_hdns_cdanh_tk_P_LKE();
            b_doi = 1;
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                b_cho_control = setInterval("P_cho()", 200);
            }
        } else if (b_dtuong.indexOf('THAMSO') >= 0) {
            $get(b_ma_nnnId).value = a_tso[0];
            b_cho_control = setInterval("P_cho()", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_cdanh_tk_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_cdanh_tk_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_cdanh_tk_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_cdanh_tk_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_NN_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_hdns_cdanh_tk_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_cdanh_tk_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_cdanh_tk_P_CHUYEN_HANG(); }
}
function ns_hdns_cdanh_tk_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_hdns_cdanh_tk_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_cdanh_tk_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_cdanh_tk_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else sns_hdns.Fs_NS_HDNS_MA_NN_CT(form_Fs_nsd(), b_ma, ns_hdns_cdanh_tk_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_cdanh_tk_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_hdns_cdanh_tk_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vunghiId = form_Fs_VUNG_ID('UPa_hi'),
        b_chon_allId = form_Fs_VTEN_ID('UPa_hi', 'acheckall'),
        b_ma_nnnId = form_Fs_TEN_ID(b_vunghiId, 'nnn'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        GridX_taoScroll(b_grlkeId);
        ns_hdns_cdanh_tk_P_LKE();
    }
}
function ns_hdns_cdanh_tk_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_ma_nnn = $get(b_ma_nnnId).value, b_tt = form_Fs_TEN_GTRI(b_vungId, 'TT'),
            b_tentk = form_Fs_TEN_GTRI(b_vungId, 'ten_tk');
        sns_hdns.Fs_NS_HDNS_CDANH_TK_LKE(form_Fs_nsd(), b_ma_nnn, b_tt, b_tentk, a_cot, ns_hdns_cdanh_tk_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_cdanh_tk_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_datBang(b_grlkeId, a_kq[1]); slide_P_SOTRANG(b_slideId);
        GridX_datA(b_grlkeId, 1);
        if (a_kq[1] == '') form_P_LOI('loi:Không tìm thấy thông tin bạn đang tìm kiếm:loi');
    }
}
function ns_hdns_cdanh_tk_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_cdanh_tk_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_cdanh_tk_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_NN_IMP", "MA_NN_IMP", "Import nghề nghiệp"]], null);
    form_P_LOI('');
    return false;
}
function form_P_TRA_LIST() {
    var a_cot = GridX_Fdt_cotGtriH(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_CDANH_TK_TRA(form_Fs_nsd(), a_cot, form_P_TRA_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function form_P_TRA_LIST_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_TRA_CHON('');
    }
}
function CheckAll(oCheckbox) {
    if (oCheckbox.checked == true) {
        $get(b_chon_allId).value = 'TATCA';
        for (i = 1; i < GridX_Fi_hangSo(b_grlkeId) ; i++) {
            var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "ma_cd"));
            if (b_so_the != "") GridX_datGtri(b_grlkeId, i, ["chon"], ['X'], 'K');
        }
    } else {
        for (i = 1; i < GridX_Fi_hangSo(b_grlkeId) ; i++) {
            GridX_datGtri(b_grlkeId, i, ["chon"], [''], 'K');
        }
    }
}
function form_dong() {
    location.reload(false);
}