var ns_tl_ma_nl_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_nnId, b_tenId, b_excelId, b_timId, ns_tl_ma_nl_choAct = 0;
function ns_tl_ma_nl_P_KD() {
    ns_tl_ma_nl_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_ma_nnId = form_Fs_TEN_ID(b_vungId, 'MA_NN'); b_slideId = b_grlkeId + '_slide'; ns_tl_ma_nl_lkeCho = setInterval('ns_tl_ma_nl_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_tl_ma_nl_P_LKE();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_nl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NN": b_maId = b_ma_nnId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ma_nn = form_Fs_TEN_GTRI(b_vungId, 'MA_NN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, ["ma_nn", "ma"], [b_ma_nn, b_ma.value]);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_tl_ma_nl_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_tl_ma_nl_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
        else if (b_maTen == "MA_NN") {
            ns_tl_ma_nl_P_CT_MOI("XL");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_nl_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value), b_ma_nn = form_Fs_TEN_GTRI(b_vungId, 'MA_NN');
        if (b_ma_nn != "" && b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tl.Fs_NS_TL_MA_NL_MA(b_ma_nn, b_ma, b_TrangKt, a_cot, ns_tl_ma_nl_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_nl_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_ma_nl_P_CHUYEN_HANG(); }
}
function ns_tl_ma_nl_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    return false;
}
function ns_tl_ma_nl_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
    return false;
}
function ns_tl_ma_nl_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if ($get(b_gocId).value == "" || $get(b_gocId).value == null) { $get(b_gocId).focus(); }
    else if ($get(b_tenId).value == "" || $get(b_tenId).value == null) { $get(b_tenId).focus(); }
    if (b_loi != "") { form_P_LOI(b_loi); return false;}
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_tl.Fs_NS_TL_MA_NL_NH(b_TrangKt, a_dt_ct, a_cot, ns_tl_ma_nl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_ma_nl_P_NH_KQ(b_kq) {
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
function ns_tl_ma_nl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),0);
    if (b_so_id == "") ns_tl_ma_nl_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_MA_NL_XOA(b_so_id, a_tso, a_cot, ns_tl_ma_nl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_ma_nl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_ma_nl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_ma_nl_P_CHUYEN_HANG(); }
    }
}
function ns_tl_ma_nl_GR_lke_RowChange() {
    if (ns_tl_ma_nl_choAct != 0) clearTimeout(ns_tl_ma_nl_choAct);
    ns_tl_ma_nl_choAct = setTimeout("ns_tl_ma_nl_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_ma_nl_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
        if (b_so_id == 0) form_P_MOI(b_vungId, "XGL"); else sns_tl.Fs_NS_TL_MA_NL_CT(b_so_id, ns_tl_ma_nl_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_nl_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_tl_ma_nl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tl_ma_nl_lkeCho); GridX_taoScroll(b_grlkeId); ns_tl_ma_nl_P_LKE(); }
}
function ns_tl_ma_nl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_MA_NL_LKE(a_tso, a_cot, ns_tl_ma_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tl_ma_nl_P_EXCEL() {
    __doPostBack('ctl00$ContentPlaceHolder1$XuatExcel', '');//Xuất Excel
}
function ns_tl_ma_nl_P_MAU() {
    __doPostBack('ctl00$ContentPlaceHolder1$FileMau', '');//Xuất file Excel mẫu
}
function ns_tl_ma_nl_FILE_IMPORT() {//import từ file Excel
    var b_tenf = '/App_form/ns/hdns/file_hdns.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MA_NNGHE_IMP", "MA_NNGHE_IMP", "Import nghề nghiệp"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}