var b_ps, b_nv, b_gridId, b_grsanId;
function ns_khud_ttt_KD() {
    b_gridId = form_Fs_VUNG_ID('GR_dk'); b_grsanId = form_Fs_VUNG_ID('GR_san');
    b_ps = 'NS'; b_nv = 'TT';
    ns_khud_ttt_lkeCho = setInterval('ns_khud_ttt_P_LKE_CHO()', 200);

}
function ns_khud_ttt_P_LKE_CHO() {
    if ($get(b_gridId) != null) { clearTimeout(ns_khud_ttt_lkeCho); ns_khud_ttt_P_LKE(); }
}

function P_KET_QUA(b_dtuong, a_tso) {
    if (b_dtuong.toUpperCase() == "THAMSO") {
        var a_s = a_tso[0].split(',');
        if (a_s.length > 2) {
            b_ps = a_s[0]; b_nv = a_s[1]; form_Fctr_VTEN_DTUONG('', 'ten_form').innerHTML = "Thông tin thống kê " + a_s[2];
            ns_khud_ttt_P_LKE();
        }
    }
}
function khud_ttt_P_DONG() {
    $get(b_khud_ttt_gchuId).value = ".";
    var b_dt_ct = GridX_Fdt_cotGtri(b_grsanId);

}
function ns_khud_ttt_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function ns_khud_ttt_P_SAN() {
    try {
        var a_dt = GridX_Fdt_cotGtriL(b_gridId, "MA", "MA");
        sns_khud.Fs_TTT_SAN(form_Fs_nsd(), b_ps, b_nv, a_dt, ns_khud_ttt_P_SAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_khud_ttt_P_SAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") form_P_LOI_DICH("Đã chọn hết");
    else {
        GridX_datBang(b_grsanId, b_kq);
        form_Fctr_TENVUNG('UPa_san').style.display = "";
    }
}
function ns_khud_ttt_P_CHON() {
    var a_cot = ["ma", "ten", "loai"];
    var a_dt = GridX_Fdt_cotGtriC(b_grsanId, a_cot);
    if (a_dt.length > 0) {
        var b_hangSo = GridX_Fi_hangSo(b_gridId), b_hang;
        a_cot[3] = "bb";
        for (var i = 0; i < a_dt.length; i++) {
            b_hang = GridX_Fi_timHangT(b_gridId); a_dt[i][3] = "K";
            if (b_hang < 1) { b_hangSo++; b_hang = b_hangSo; GridX_chenHang(b_gridId, 0, 1); }
            GridX_datGtri(b_gridId, b_hang, a_cot, a_dt[i]);
        }
        if (!GridX_Fb_hangTrang(b_gridId, b_hangSo, "ma")) GridX_chenHang(b_gridId, 0, 1);
    }
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}
function ns_khud_ttt_DONG() {
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}
function ns_khud_ttt_P_NH() {
    try {
        var b_dt = GridX_Fdt_cotGtri(b_gridId);
        sns_khud.Fs_TTT_NH(form_Fs_nsd(), b_ps, b_nv, b_dt, ns_khud_ttt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        form_P_DAY(window.name, "ns_cb", "TTTHEM", ["123"]);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_khud_ttt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DONG(window.name, null);
}
function ns_khud_ttt_P_XOA() {
    try {
        sns_khud.Fs_TTT_XOA(form_Fs_nsd(), b_ps, b_nv, ns_khud_ttt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_khud_ttt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else GridX_moi(b_gridId);
}
function ns_khud_ttt_len() {
    GridX_chuyenHang(b_gridId, -1);
    return false;
}
function ns_khud_ttt_xuong() {
    GridX_chuyenHang(b_gridId, 1);
    return false;
}
function ns_khud_ttt_chen() {
    GridX_chenHang(b_gridId);
    return false;
}
function ns_khud_ttt_cat() {
    GridX_boChon(b_gridId);
    return false;
}
function ns_khud_ttt_P_LKE() {
    var a_cot = GridX_Fas_tenCot(b_gridId);
    sns_khud.Fs_TTT_LKE(form_Fs_nsd(), b_ps, b_nv, a_cot, ns_khud_ttt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_khud_ttt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq[0] == "K") form_Fctr_TENVUNG('td_hien_san').style.display = "none";
        GridX_datBang(b_gridId, a_kq[1]);
        return false;
    }
}
