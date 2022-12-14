     var ns_tc_dang_lkeCho, b_vungId, b_grlkeId, b_grctId, b_so_theId, b_mt, b_gchuId;
function ns_tc_dang_P_KD() {
    ns_tc_dang_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
    b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_slideId = b_grlkeId + '_slide';
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_tc_dang_lkeCho = setInterval('ns_tc_dang_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            var b_phong = $get(b_phongId).value;
            if (b_phong != a_tso[2]) {
                alert("Cán bộ không thuộc phòng đã chọn");
            }
            else {
                $get(b_gocId).value = b_kq;
                $get(b_gchuId).innerHTML = a_tso[1];
                $get(b_gocId).focus();
                ns_tc_dang_P_CHUYEN_HANG();

            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tc_dang_P_KTRA(b_maTen) {
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
            ns_tc_dang_P_MOI();
            ns_tc_dang_P_LKE();
        }
        else if (b_maTen == "SO_THE") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "so_the", b_ma.value);
            if (b_hang < 1) {
                sns_tt.Fs_NS_CB_HOI(b_ma.value, Fs_NS_CB_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_tc_dang_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function Fs_NS_CB_HOI_KQ(b_kq) {
    var a_kq = b_kq.split('#');
    var b_phong = $get(b_phongId).value;
    if (b_phong != a_kq[1] && a_kq[1] != '') {
        $get(b_phongId).value = a_kq[1];
        ns_tc_dang_P_MA_KTRA();
        $get(b_gchuId).innerHTML = a_kq[2];
    }
    else {
        GridX_thoiA(b_grlkeId);
        $get(b_gchuId).innerHTML = a_kq[2];
        ns_tc_dang_P_MA_KTRA();
    }
}

function ns_tc_dang_P_MA_KTRA() {
    try {
        var b_so_the = C_NVL($get(b_so_theId).value);
        if (b_so_the != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_phong = $get(b_phongId).value;
            sns_tt.Fs_NS_TC_DANG_MA(b_phong, b_so_the, b_TrangKt, a_cot, ns_tc_dang_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tc_dang_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tc_dang_P_CHUYEN_HANG(); }
}

function ns_tc_dang_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

var ns_tc_dang_choAct = 0;
function ns_tc_dang_GR_lke_RowChange() {
    if (ns_tc_dang_choAct != 0) clearTimeout(ns_tc_dang_choAct);
    ns_tc_dang_choAct = setTimeout("ns_tc_dang_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_tc_dang_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_tc_dang_lkeCho); ns_tc_dang_P_LKE(); }
}
function ns_tc_dang_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_so_theId).focus();
    return false;
}
function ns_tc_dang_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_phong = $get(b_phongId).value;
        sns_tt.Fs_NS_TC_DANG_LKE(b_phong, a_tso, a_cot, ns_tc_dang_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tc_dang_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tc_dang_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_so_id = $get(b_so_idId).value, b_dt = form_Faa_TEXT_ROW(b_vungId),
                a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sns_tt.Fs_NS_TC_DANG_NH(b_so_id, b_TrangKt, b_dt, a_cot_ct, a_cot_lke, ns_tc_dang_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tc_dang_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
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
function ns_tc_dang_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == null || b_so_id == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_tt.Fs_NS_TC_DANG_CT(b_so_id, a_cot_ct, ns_tc_dang_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_tc_dang_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
function ns_tc_dang_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") ns_tc_dang_P_MOI();
    else {
        var b_so_the = $get(b_so_theId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_TC_DANG_XOA(b_so_id, b_so_the, a_tso, a_cot, ns_tc_dang_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tc_dang_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tc_dang_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tc_dang_P_CHUYEN_HANG(); }
    }
}
function ns_tc_dang_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_tc_dang_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_tc_dang_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_tc_dang_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}