var ns_tl_tl_ml_lkeCho, b_vungId, b_vungtkId, b_grctId, b_gocId, b_mt, b_gchuId, b_nhomluongId, b_doi = 0, b_cho_control = 0, b_slideId, ns_tl_tl_ml_choAct = 0, ns_tl_tl_ml2_choAct = 0;
function ns_tl_tl_ml_P_KD() {
    ns_tl_tl_ml_lkeCho = setInterval('ns_tl_tl_ml_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("SO_THE") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_gocId).setAttribute("disabled", "disabled");
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "MA_DVI") {
            //form_P_MOI(b_vungId, "XL");
            ns_tl_tl_ml_P_LKE();
            //var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DVI_TK');
            //sns_tl.P_NS_TL_TL_ML_DOITUONG_XEM(form_Fs_nsd(), window.name, b_ma_dvi, ns_tl_tl_ml_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_DT") {
            ns_tl_tl_ml_P_LKE();
        }
        else if (b_maTen == "LOAI") {
            ns_tl_tl_ml_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_tl_tl_ml_P_LKE();
}
function ns_tl_tl_ml_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nhomluong = $get(b_nhomluongId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grctId), a_cot = GridX_Fas_tenCot(b_grctId);
            stl_ma.Fs_NS_TL_TL_ML_MA(b_nhomluong, b_ma, b_TrangKt, a_cot, ns_tl_tl_ml_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grctId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grctId, b_hang); ns_tl_tl_ml_P_CHUYEN_HANG(); }
}
function ns_tl_tl_ml_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_tl_tl_ml_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    return false;
}
function ns_tl_tl_ml_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grctId);
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "so_id"), 0);
    sns_tl.Fs_NS_TL_TL_ML_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot, ns_tl_tl_ml_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_tl_ml_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grctId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grctId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
function ns_tl_tl_ml_GR_lke_RowChange() {
    if (ns_tl_tl_ml_choAct != 0) clearTimeout(ns_tl_tl_ml_choAct);
    ns_tl_tl_ml_choAct = setTimeout("ns_tl_tl_ml_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_tl_ml_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "so_id"), 0);
        if (b_so_id == 0) form_P_MOI(b_vungId, "XGL"); else sns_tl.Fs_NS_TL_TL_ML_CT(form_Fs_nsd(), b_so_id, ns_tl_tl_ml_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_tl_tl_ml2_GR_lke_RowChange() {
    if (ns_tl_tl_ml2_choAct != 0) clearTimeout(ns_tl_tl_ml_choAct);
    ns_tl_tl_ml2_choAct = setTimeout("ns_tl_tl_ml2_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_tl_ml2_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, "cdanh"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grctId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_tl_tl_ml_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'TEN_COT');
        b_slideId = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        ns_tl_tl_ml_P_LKE();
    }
}
function ns_tl_tl_ml_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DVI_TK'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DT_TK'), b_loai = 1;
        sns_tl.Fs_NS_TL_TL_ML_LKE(form_Fs_nsd(), b_ma_dvi, b_dtuong, b_loai, a_tso, a_cot, ns_tl_tl_ml_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_tl_ml_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function ns_tl_tl_ml_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_tl_tl_ml_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_tl_tl_ml_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_tl_tl_ml_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_tl_tl_ml_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function form_dong() {
    location.reload(false);
}