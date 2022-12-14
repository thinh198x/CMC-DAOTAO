var ns_bhxh_qt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_so_theId, b_tgnam_f, b_tgthang_f;
function ns_bhxh_qt_P_KD() {
    ns_bhxh_qt_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_loaibhId = form_Fs_TEN_ID(b_vungId, 'loaibh');
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_tenId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_sobhxhId = form_Fs_TEN_ID(b_vungId, 'sobhxh');
    b_ngayId = form_Fs_TEN_ID(b_vungId, 'ngay');
    b_thangdId = form_Fs_TEN_ID(b_vungId, 'thangd');
    b_thangcId = form_Fs_TEN_ID(b_vungId, 'thangc');
    b_namId = form_Fs_TEN_ID(b_vungId, 'nam');
    b_thangId = form_Fs_TEN_ID(b_vungId, 'thang');
    b_tinhId = form_Fs_TEN_ID(b_vungId, 'tinh');
    b_tgnamId = form_Fs_TEN_ID(b_vungId, 'tgnam');
    b_tgthangId = form_Fs_TEN_ID(b_vungId, 'tgthang');
    b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_bhxh_qt_lkeCho = setInterval('ns_bhxh_qt_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("KQ") >= 0) {
            $get(b_so_theId).value = a_tso[0];
            $get(b_tenId).value = a_tso[1];
            $get(b_sobhxhId).value = a_tso[2];
            $get(b_thangdId).focus();
            ns_bhxh_qt_P_LKE();
            ns_bhxh_qt_P_CB_HOI();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhxh_qt_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "SO_THE": b_maId = b_so_theId; break;
            case "THANGD": b_maId = b_thangdId; break;
            case "THANGC": b_maId = b_thangdId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "SO_THE") {
            $get(b_gocId).setAttribute("disabled", "disabled");
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) {
                sns_tt.Fs_NS_CB_HOI(b_ma.value, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_qt_P_CHUYEN_HANG(); }
        }
        if (b_maTen == "THANGD") {
            ns_tinh_namthang();
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "thangd", b_ma.value);
            if (b_hang < 1) {
                ns_bhxh_qt_P_MA_KTRA();
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_qt_P_CHUYEN_HANG(); }
        }
        if (b_maTen == "THANGC") {
            ns_tinh_namthang();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhxh_qt_P_CB_HOI() {
    try {
        var b_so_the = $get(b_so_theId).value;
        var b_loaibh = $get(b_loaibhId).value;
        var a_cot_tt = GridX_Fas_tenCot(b_grctId);
        sns_cd.Fs_NS_BHXH_QT_CB_HOI(b_loaibh, b_so_the, a_cot_tt, ns_bhxh_qt_P_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_bhxh_qt_P_CB_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    b_tgnam_f = $get(b_tgnamId).value, b_tgthang_f = $get(b_tgthangId).value;
    return false;
}

function Fs_NS_CB_HOI_KQ(b_kq) {
    var a_kq = b_kq.split('#');
    var b_phong = $get(b_phongId).value;
    if (b_phong != a_kq[1] && a_kq[1] != '') {
        $get(b_phongId).value = a_kq[1];
        ns_bhxh_qt_P_MA_KTRA();
        $get(b_tenId).value = a_kq[2];
        ns_bhxh_qt_P_CB_HOI();
    }
    else {
        GridX_thoiA(b_grlkeId); ns_bhxh_qt_P_MA_KTRA();
    }
}

function ns_bhxh_qt_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_loaibh = $get(b_loaibhId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_thangd = $get(b_thangdId).value;
            sns_cd.Fs_NS_BHXH_QT_MA(b_loaibh, b_so_the, b_thangd, b_TrangKt, a_cot, ns_bhxh_qt_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_qt_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_qt_P_CHUYEN_HANG(); }
    return false;
}

function ns_bhxh_qt_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_bhxh_qt_choAct = 0;
function ns_bhxh_qt_GR_lke_RowChange() {
    if (ns_bhxh_qt_choAct != 0) clearTimeout(ns_bhxh_qt_choAct);
    ns_bhxh_qt_choAct = setTimeout("ns_bhxh_qt_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_bhxh_qt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_bhxh_qt_lkeCho); ns_bhxh_qt_P_LKE(); }
}

function ns_bhxh_qt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId),
                a_cot_tt = GridX_Fdt_cotGtri(b_grctId),
                b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_cd.Fs_NS_BHXH_QT_NH(b_TrangKt, a_dt_ct, a_cot_tt, a_cot_lke, ns_bhxh_qt_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_bhxh_qt_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        b_tgnam_f = $get(b_tgnamId).value, b_tgthang_f = $get(b_tgthangId).value;
        $get(b_so_theId).focus();
    }
    return false;
}
function ns_bhxh_qt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_tgnamId).value = $get(b_tgthangId).value = $get(b_namId).value = $get(b_thangId).value = "0";
    $get(b_so_theId).focus();
    return false;
}
function ns_bhxh_qt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value;
    var b_loaibh = $get(b_loaibhId).value;
    var b_thangd = $get(b_thangdId).value;
    if (b_so_the == "") ns_bhxh_qt_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cd.Fs_NS_BHXH_QT_XOA(b_loaibh,b_so_the, b_thangd, a_tso, a_cot, ns_bhxh_qt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_bhxh_qt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_bhxh_qt_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_bhxh_qt_P_CHUYEN_HANG(); }
    }
}
function ns_bhxh_qt_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = $get(b_so_theId).value;
    var b_loaibh = $get(b_loaibhId).value;
    var a_cot_tt = GridX_Fas_tenCot(b_grctId);
    var b_thangd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "thangd"));
    if (b_thangd == "") form_P_MOI(b_vungId, "XGL");
    else sns_cd.Fs_NS_BHXH_QT_CT(b_loaibh,b_so_the, b_thangd, a_cot_tt, ns_bhxh_qt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}

function ns_bhxh_qt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    return false;
}
function ns_bhxh_qt_P_LKE_DR() {
    ns_bhxh_qt_P_LKE();
    ns_bhxh_qt_P_CB_HOI();
    return;
}
    

function ns_bhxh_qt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_so_the = $get(b_so_theId).value, b_loaibh = $get(b_loaibhId).value;
        sns_cd.Fs_NS_BHXH_QT_LKE(b_loaibh,b_so_the, a_tso, a_cot, ns_bhxh_qt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_bhxh_qt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_tinh_namthang() {
    var b_tinh = $get(b_tinhId).value;
    if (b_tinh == "C") {
        var b_thangd = $get(b_thangdId).value, b_thangc = $get(b_thangcId).value;
        var b_tgnam = b_tgnam_f, b_tgthang = b_tgthang_f;
        if (b_thangd != '' && b_thangc != '') {
            var b_thang_d = b_thangd.substring(0, 2), b_nam_d = b_thangd.substring(3, 7);
            var b_tong_thangd = CSO_SO(b_nam_d) * 12 + CSO_SO(b_thang_d);
            var b_thang_c = b_thangc.substring(0, 2), b_nam_c = b_thangc.substring(3, 7);
            var b_tong_thangc = CSO_SO(b_nam_c) * 12 + CSO_SO(b_thang_c);
            var b_thang = b_tong_thangc - b_tong_thangd + 1;
            var b_nam_toi = (b_thang - b_thang % 12) / 12;
            var b_thang_toi = b_thang % 12;
            $get(b_namId).value = b_nam_toi; $get(b_thangId).value = b_thang_toi;
            var b_tgnamd = parseFloat(b_tgnam) + parseFloat(b_nam_toi) + ((parseFloat(b_tgthang) + parseFloat(b_thang_toi)) - (parseFloat(b_tgthang) + parseFloat(b_thang_toi)) % 12) / 12,
                b_tgthangd = (parseFloat(b_tgthang) + parseFloat(b_thang_toi)) % 12;
            $get(b_tgnamId).value = b_tgnamd; $get(b_tgthangId).value = b_tgthangd;
            return;
        }
    }
    else {
        $get(b_namId).value = $get(b_thangId).value = "0";
        $get(b_tgnamId).value = b_tgnam_f; $get(b_tgthangId).value = b_tgthang_f;
        return;
    }
}
