
var ns_dt_dsdangky_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_gchuId;
function ns_dt_dsdangky_P_KD() {
    ns_dt_dsdangky_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_gioihanId = form_Fs_TEN_ID(b_vungId, 'gioihan');
    b_dangkyId = form_Fs_TEN_ID(b_vungId, 'dangky');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_slideId = b_grlkeId + '_slide';
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA") >= 0) {
            $get(b_gocId).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_dt_dsdangky_P_DSACH();
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_dt_dsdangky_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "MA": b_maId = b_gocId; break;
    }
    var b_ma = $get(b_maId);
    if (b_ma == null || C_NVL(b_ma.value) == "") return;
    if (b_maTen == "MA") {
        skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_dt_dsdangky_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
        ns_dt_dsdangky_P_DSACH();
    }
}
function ns_dt_dsdangky_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}

function ns_dt_dsdangky_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_dt_dsdangky_lkeCho); ns_dt_dsdangky_P_LKE(); }
}

function ns_dt_dsdangky_P_DSACH() {
    try {
        var b_ma = $get(b_gocId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_dto.Fs_NS_DT_DANGKYKH_DSACH(b_ma, a_cot, ns_dt_dsdangky_P_DSACH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dsdangky_P_DSACH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    if (a_kq[0] == "") GridX_datTrang(b_grlkeId);
    else GridX_datBang(b_grlkeId, a_kq[0]);
}
function ns_dt_dsdangky_P_PHEDUYET() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        else {
            var b_ma = $get(b_gocId).value, b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
            sns_dto.Fs_NS_DT_DANGKYKH_DUYET(b_ma, b_dt_ct, ns_dt_dsdangky_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_dsdangky_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        alert("Phê duyệt thành công!");
        ns_dt_dsdangky_P_DSACH();
    }
    return false;
}
function ns_dt_dsdangky_P_HUYPHEDUYET() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_ma = $get(b_gocId).value;
            sns_dto.Fs_NS_DT_DANGKYKH_HUYDUYET(b_ma, ns_dt_dsdangky_P_HUYPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}

function ns_dt_dsdangky_P_HUYPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_dt_dsdangky_P_DSACH();
        alert("Hủy phê duyệt thành công!");
    }
    return false;
}

function ns_dt_dsdangky_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return false;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    form_P_MO("ns_dt_dsdangky.aspx", null, ["KQ", [b_ma]]);
    return false;
}
function form_dong() {
    location.reload(false);
}