var ns_bhxh_thaydoi_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId;
function ns_bhxh_thaydoi_P_KD() {
    ns_bhxh_thaydoi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'ngay');
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_bhxh_thaydoi_lkeCho = setInterval('ns_bhxh_thaydoi_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_thaydoi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "SO_THE": b_maId = b_so_theId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "PHONG") {
            ns_bhxh_thaydoi_P_MOI();
            ns_bhxh_thaydoi_P_LKE();
        }
        else if (b_maTen == "SO_THE") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) {
                sns_tt.Fs_NS_CB_HOI(b_ma.value, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_thaydoi_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function Fs_NS_CB_HOI_KQ(b_kq) {
    var a_kq = b_kq.split('#');
    var b_phong = $get(b_phongId).value;
    if (b_phong != a_kq[1] && a_kq[1] != '') {
        $get(b_phongId).value = a_kq[1];
        ns_bhxh_thaydoi_P_MA_KTRA();
        $get(b_tenId).value = a_kq[2];
    }
    else {
        GridX_thoiA(b_grlkeId); ns_bhxh_thaydoi_P_MA_KTRA();
    }
}

function ns_bhxh_thaydoi_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_phong = $get(b_phongId).value;
            sns_cd.Fs_ns_bhxh_thaydoi_MA(b_phong, b_so_the, b_TrangKt, a_cot, ns_bhxh_thaydoi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_thaydoi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_thaydoi_P_CHUYEN_HANG(); }
    return false;
}

function ns_bhxh_thaydoi_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_bhxh_thaydoi_choAct = 0;
function ns_bhxh_thaydoi_GR_lke_RowChange() {
    if (ns_bhxh_thaydoi_choAct != 0) clearTimeout(ns_bhxh_thaydoi_choAct);
    ns_bhxh_thaydoi_choAct = setTimeout("ns_bhxh_thaydoi_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_bhxh_thaydoi_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_bhxh_thaydoi_lkeCho); ns_bhxh_thaydoi_P_LKE(); }
}

function ns_bhxh_thaydoi_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_cd.Fs_ns_bhxh_thaydoi_NH(b_TrangKt, a_dt_ct, a_cot_lke, ns_bhxh_thaydoi_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_bhxh_thaydoi_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_theId).focus();
    }
    return false;
}
function ns_bhxh_thaydoi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_theId).focus();
    return false;
}
function ns_bhxh_thaydoi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the");
    if (b_so_the == "") ns_bhxh_thaydoi_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_phong = $get(b_phongId).value;
        sns_cd.Fs_ns_bhxh_thaydoi_XOA(b_so_the, b_phong, a_tso, a_cot, ns_bhxh_thaydoi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_bhxh_thaydoi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_bhxh_thaydoi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_thaydoi_P_CHUYEN_HANG(); }
    }
}
function ns_bhxh_thaydoi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    if (b_so_the == "") form_P_MOI(b_vungId, "XGL");
    else sns_cd.Fs_ns_bhxh_thaydoi_CT(b_so_the, ns_bhxh_thaydoi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_bhxh_thaydoi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_bhxh_thaydoi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_phongId).value;
        sns_cd.Fs_ns_bhxh_thaydoi_LKE(b_phong, a_tso, a_cot, ns_bhxh_thaydoi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_thaydoi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}