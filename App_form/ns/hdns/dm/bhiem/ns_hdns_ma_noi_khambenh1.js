var ns_hdns_ma_noi_khambenh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_tenId, b_excelId, b_timId, ns_hdns_ma_noi_khambenh_choAct = 0;;
function ns_hdns_ma_noi_khambenh_P_KD() {

    ns_hdns_ma_noi_khambenh_lkeCho = setInterval('ns_hdns_ma_noi_khambenh_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_ma_noi_khambenh_P_LKE();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_noi_khambenh_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_noi_khambenh_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_noi_khambenh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_NOI_KHAMBENH_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_hdns_ma_noi_khambenh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_noi_khambenh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_noi_khambenh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    list_P_DAT(b_tt, 'A');
    return false;
}
function ns_hdns_ma_noi_khambenh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if ($get(b_gocId).value == "" || $get(b_gocId).value == null) { $get(b_gocId).focus(); }
    else if ($get(b_tenId).value == "" || $get(b_tenId).value == null) { $get(b_tenId).focus(); }
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_MA_NOI_KHAMBENH_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_hdns_ma_noi_khambenh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_noi_khambenh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
        $get(b_tenId).focus();
    }
    return false;
}
function ns_hdns_ma_noi_khambenh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    //var message = confirm("Bạn có chắc chắn xóa không?");
    //if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") ns_hdns_ma_noi_khambenh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_NOI_KHAMBENH_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, ns_hdns_ma_noi_khambenh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_noi_khambenh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_noi_khambenh_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG();
            form_P_LOI("loi:Xóa thành công!:loi");
        }
    }
}
function ns_hdns_ma_noi_khambenh_GR_lke_RowChange() {
    if (ns_hdns_ma_noi_khambenh_choAct != 0) clearTimeout(ns_hdns_ma_noi_khambenh_choAct);
    ns_hdns_ma_noi_khambenh_choAct = setTimeout("ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            list_P_DAT(b_tt, 'A');
        } else sns_hdns.Fs_NS_HDNS_MA_NOI_KHAMBENH_CT(form_Fs_nsd(), b_ma, ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_noi_khambenh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_hdns_ma_noi_khambenh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_hdns_ma_noi_khambenh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_tt = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_hdns_ma_noi_khambenh_lkeCho); GridX_taoScroll(b_grlkeId); ns_hdns_ma_noi_khambenh_P_LKE();
    }
}
function ns_hdns_ma_noi_khambenh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_NOI_KHAMBENH_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_ma_noi_khambenh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_noi_khambenh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_noi_khambenh_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_ma_noi_khambenh_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_hdns_ma_noi_khambenh_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_NN_IMP", "MA_NN_IMP", "Import nghề nghiệp"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}
function P_LKE_QUANHUYEN() {
    form_P_MOI(b_vungId, "L");
    var tt_id = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'tpho'));
    sns_ma_ch.Fs_DM_QUANHUYEN(tt_id, window.name, P_LKE_QUANHUYEN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function P_LKE_QUANHUYEN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}