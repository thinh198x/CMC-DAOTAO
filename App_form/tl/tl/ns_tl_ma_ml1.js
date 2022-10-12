var ns_tl_ma_ml_lkeCho, b_vungId, b_vungtkId, ns_tl_ma_ml2_choAct = 0, ns_tl_ma_ml_choAct = 0, b_hang_chon, b_grctId, b_gocId, b_mt, b_gchuId, b_nhomluongId, b_doi = 0, b_cho_control = 0, b_slideId;
function ns_tl_ma_ml_P_KD() {
    ns_tl_ma_ml_lkeCho = setInterval('ns_tl_ma_ml_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_tl_ma_ml_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
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
function ns_tl_ma_ml_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "MA_DVI") {
            form_P_MOI(b_vungId, "XL");
            var b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DVI_TK');
            sns_tl.Fs_NS_TL_MA_ML_XEM(form_Fs_nsd(), window.name, b_ma_dvi, ns_tl_ma_ml_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_DT") ns_tl_ma_ml_P_LKE('K');
        else if (b_maTen == "LOAI") ns_tl_ma_ml_P_LKE('K');
        else if (b_maTen == "LOAI_CT_TK") ns_tl_ma_ml_P_LKE('K');
        else if (b_maTen == "BLUONG_TK") ns_tl_ma_ml_P_LKE('K');
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_ml_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_tl_ma_ml_P_LKE();
}
function ns_tl_ma_ml_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nhomluong = $get(b_nhomluongId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grctId), a_cot = GridX_Fas_tenCot(b_grctId);
            stl_ma.Fs_NS_TL_MA_ML_MA(b_nhomluong, b_ma, b_TrangKt, a_cot, ns_tl_ma_ml_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_ml_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grctId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X"); GridX_datTrang(b_grctId);
        $get(b_gocId).focus(); $get(b_so_idId).value = "0";
    }
    else { GridX_datA(b_grctId, b_hang); ns_tl_ma_ml_P_CHUYEN_HANG(); }
}
function ns_tl_ma_ml_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_tl_ma_ml_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grctId);
    GridX_datTrang(b_grctId);
    $get(b_gocId).focus();
    return false;
}
function ns_tl_ma_ml_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grctId);
    var b_so_id = $get(b_so_Id).value,
        b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DVI_TK'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DT_TK'), b_loai = 1,
            b_loai_ct = form_Fs_TEN_GTRI(b_vungtkId, 'LOAI_CT_TK'),
            b_bluong = form_Fs_TEN_GTRI(b_vungtkId, 'BLUONG_TK'),
            a_tso = slide_Faobj_TUDEN(b_slideId);
    if (b_loai_ct == "") b_loai_ct = -1;
    sns_tl.Fs_NS_TL_MA_ML_NH(form_Fs_nsd(), b_so_id, b_ma_dvi, b_dtuong, 1, b_loai_ct, b_bluong, b_TrangKt, a_dt_ct, a_cot, a_tso, ns_tl_ma_ml_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_ma_ml_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grctId, a_kq[1]);
        form_P_LOI('loi:Nhập thành công:loi');
        GridX_datA(b_grctId, b_hang_chon);
    }
    return false;
}
function ns_tl_ma_ml_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grctId, b_hang, "MA");
    if (b_ma == "") ns_tl_ma_ml_P_MOI();
    else {
        var b_nhomluong = $get(b_nhomluongId).value;
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_loai_ct = form_Fs_TEN_GTRI(b_vungtkId, 'LOAI_CT_TK'), b_bluong = form_Fs_TEN_GTRI(b_vungtkId, 'BLUONG_TK');
        stl_ma.Fs_NS_TL_MA_ML_XOA(b_nhomluong, b_ma, b_loai_ct, b_bluong, a_tso, a_cot, ns_tl_ma_ml_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_ma_ml_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grctId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grctId, b_hang)) ns_tl_ma_ml_P_MOI();
        else { GridX_datA(b_grctId, b_hang); ns_tl_ma_ml_P_CHUYEN_HANG(); }
    }
}
function ns_tl_ma_ml_GR_lke_RowChange() {
    if (ns_tl_ma_ml_choAct != 0) clearTimeout(ns_tl_ma_ml_choAct);
    ns_tl_ma_ml_choAct = setTimeout("ns_tl_ma_ml_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_ma_ml_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        b_hang_chon = b_hang;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "so_id"), 0);
        if (b_so_id == 0) form_P_MOI(b_vungId, "XGL"); else {
            sns_tl.Fs_NS_TL_MA_ML_CT(form_Fs_nsd(), b_so_id, ns_tl_ma_ml_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_so_Id).value = b_so_id;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_ml_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_tl_ma_ml_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'TEN_COT'); b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_so_Id = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        if (ns_tl_ma_ml_lkeCho != 0) clearTimeout(ns_tl_ma_ml_lkeCho);
        b_slideId = $get(b_grctId).getAttribute('slideId');
        ns_tl_ma_ml_P_LKE('K');
    }
}
function ns_tl_ma_ml_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma_dvi = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DVI_TK'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungtkId, 'MA_DT_TK'), b_loai = 1, b_loai_ct = form_Fs_TEN_GTRI(b_vungtkId, 'LOAI_CT_TK'),
            b_bluong = form_Fs_TEN_GTRI(b_vungtkId, 'BLUONG_TK');
        if (b_loai_ct == "") b_loai_ct = -1;
        sns_tl.Fs_NS_TL_MA_ML_LKE(form_Fs_nsd(), b_ma_dvi, b_dtuong, b_loai, b_loai_ct, b_bluong, a_tso, a_cot, ns_tl_ma_ml_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ma_ml_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]);
    } return false;
}
function form_dong() {
    location.reload(false);
}