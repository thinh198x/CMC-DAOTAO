
var dg_tl_cb_nvien_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_so_theId, b_TENId, b_gchuId;
function dg_tl_cb_nvien_P_KD() {
    dg_tl_cb_nvien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MANL'), b_nhomId = form_Fs_TEN_ID(b_vungId, 'NHOMNL'), b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_TENId = form_Fs_TEN_ID(b_vungId, 'HO_TEN');
    b_slideId = b_grlkeId + '_slide';
    dg_tl_cb_nvien_lkeCho = setInterval('dg_tl_cb_nvien_P_LKE_CHO()', 200);

}
var b_cho_control = 0;
function P_cho(b_ma_nhom, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_nhomId).value = b_ma_nhom;
            $get(b_gchuId).value = b_ten;
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
        if (b_dtuong.indexOf("NHOMNL") >= 0 || b_dtuong.indexOf("THAMSO") >= 0) { 
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
        else if (b_dtuong.indexOf("NHOMNL") >= 0) {
            $get(b_plId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        }
        else if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_so_theId).value = b_kq;
            $get(b_TENId).value = a_tso[1];
            $get(b_gchuId).value = a_tso[1];
        } else if (b_dtuong.indexOf("MANL") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).value = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_tl_cb_nvien_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dg_tl_cb_nvien_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dg_tl_cb_nvien_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_tl_cb_nvien_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DG_TL_CB_NVIEN_MA(b_ma, b_TrangKt, a_cot, dg_tl_cb_nvien_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_tl_cb_nvien_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dg_tl_cb_nvien_P_CHUYEN_HANG(); }
}

var dg_tl_cb_nvien_choAct = 0;
function dg_tl_cb_nvien_GR_lke_RowChange() {
    if (dg_tl_cb_nvien_choAct != 0) clearTimeout(dg_tl_cb_nvien_choAct);
    dg_tl_cb_nvien_choAct = setTimeout("dg_tl_cb_nvien_P_CHUYEN_HANG()", 300);
    return false;
}

function dg_tl_cb_nvien_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(dg_tl_cb_nvien_lkeCho); dg_tl_cb_nvien_P_LKE(); }
}

function dg_tl_cb_nvien_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    //sdg.Fs_DG_TL_CB_NVIEN_NH(b_TrangKt, a_dt_ct, a_cot, dg_tl_cb_nvien_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dg_tl_cb_nvien_P_NH_KQ(b_kq) {
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
function dg_tl_cb_nvien_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function dg_tl_cb_nvien_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") dg_tl_cb_nvien_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        return false;
        //sdg.Fs_DG_TL_CB_NVIEN_XOA(b_ma, a_tso, a_cot, dg_tl_cb_nvien_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_tl_cb_nvien_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_tl_cb_nvien_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_tl_cb_nvien_P_CHUYEN_HANG(); }
    }
}

function dg_tl_cb_nvien_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function dg_tl_cb_nvien_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_TL_CB_NVIEN_LKE(a_tso, a_cot, dg_tl_cb_nvien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function dg_tl_cb_nvien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}