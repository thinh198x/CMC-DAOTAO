var b_lkeCho, b_vungId, b_grlkeId, b_lke_dvCho, b_ttId, b_grctId, b_gocId, b_congthuc, b_ctId, b_mt, b_gchuId, b_nluongId, b_doi = 0, b_slideId, b_slide2Id, ns_tl_ct_luong_choAct = 0, b_cho_control = 0;
function ns_tl_ct_luong_P_KD() {
    b_lkeCho = setInterval('ns_tl_ct_luong_P_LKE_CHO()', 200);
    b_lke_dvCho = setInterval('ns_tl_ct_luong_P_DV_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_tl_ct_luong_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
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
function ns_tl_ct_luong_P_KTRA(b_maTen) {
    try {
        if (b_maTen == "MA_DVI") {
            ns_tl_ct_luong_P_LKE();
            ns_tl_ct_luong_P_DV_LKE();
        }
        else if (b_maTen == "MA_DT") {
            ns_tl_ct_luong_P_LKE();
            ns_tl_ct_luong_P_DV_LKE();
        }
        else if (b_maTen == "LOAI") {
            ns_tl_ct_luong_P_LKE();
            ns_tl_ct_luong_P_DV_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    ns_tl_ct_luong_P_LKE();
}
function ns_tl_ct_luong_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_gchuId).innerHTML = b_kq;
}
function ns_tl_ct_luong_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_tl_ct_luong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var b_so_id = GridX_Fas_layGtri(b_grctId, b_hang, "so_id"), a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            sns_tl.Fs_NS_TL_CT_LUONG_NH(b_so_id, a_dt_ct, ns_tl_ct_luong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_LOI("loi:Ghi thành công!:loi");
    return false;
}
function ns_tl_ct_luong_GR_lke_RowChange() {
    if (ns_tl_ct_luong_choAct != 0) clearTimeout(ns_tl_ct_luong_choAct);
    ns_tl_ct_luong_choAct = setTimeout("ns_tl_ct_luong_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_ct_luong_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang < 1) return;
        var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grctId, b_hang, "SO_ID"), 0);
        if (b_so_id == 0) form_P_MOI(b_vungId, "XL"); else sns_tl.Fs_NS_TL_CT_LUONG_CT(form_Fs_nsd(), b_so_id, ns_tl_ct_luong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_tl_ct_luong_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slide2Id = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slide2Id);
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_ctId = form_Fs_VTEN_ID(b_vungId, 'congthuc');
        ns_tl_ct_luong_P_LKE();
    }
}
function ns_tl_ct_luong_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_tso = slide_Faobj_TUDEN(b_slide2Id), b_ma_dvi = form_Fs_TEN_GTRI(b_vungId, 'MA_DVI_TK'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungId, 'MA_DT_TK'), b_loai = 1;//form_Fs_TEN_GTRI(b_vungId, 'LOAI_TK');
        sns_tl.Fs_NS_TL_CT_LUONG_LKE(form_Fs_nsd(), b_ma_dvi, b_dtuong, b_loai, a_tso, a_cot, ns_tl_ct_luong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slide2Id, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grctId, a_kq[1]);
}
function ns_tl_ct_luong_P_DV_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lke_dvCho); ns_tl_ct_luong_P_DV_LKE();
    }
}
function ns_tl_ct_luong_P_DV_LKE() {
    try { 
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma_dvi = form_Fs_TEN_GTRI(b_vungId, 'MA_DVI_TK'),
            b_dtuong = form_Fs_TEN_GTRI(b_vungId, 'MA_DT_TK'), b_loai = 1;//form_Fs_TEN_GTRI(b_vungId, 'LOAI_TK');
        sns_tl.Fs_NS_TL_CT_LUONG_LKE_DV(form_Fs_nsd(), b_ma_dvi, b_dtuong, b_loai, a_tso, a_cot, ns_tl_ct_luong_P_DV_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_DV_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tl_ct_luong_P_KT() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_ct = $get(b_ctId).value, b_hang = GridX_Fi_timHangA(b_grctId); b_cotct = GridX_Fas_layGtri(b_grctId, b_hang, "ma"), b_loai = 1;//form_Fs_TEN_GTRI(b_vungId, 'LOAI_TK');
            sns_tl.Fs_NS_TL_CT_LUONG_KT(form_Fs_nsd(), b_loai, b_cotct, b_ct, ns_tl_ct_luong_P_KT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_ct_luong_P_KT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_LOI("loi:Hợp lệ:loi");
    return false;
}
function form_dong() { location.reload(false); }