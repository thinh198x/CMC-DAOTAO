var b_ps, b_nv, b_gridId, b_grsanId;
function khud_ttt_KD() {
    b_gridId = form_Fs_VUNG_ID('GR_dk');b_grsanId = form_Fs_VUNG_ID('GR_san');
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            var a_s = a_tso[0].split(',');
            if (a_s.length > 2) {
                b_ps = a_s[0]; b_nv = a_s[1]; form_Fctr_VTEN_DTUONG('', 'ten_form').innerHTML = "Thông tin thống kê " + a_s[2];
                khud_ttt_P_LKE();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function khud_ttt_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function khud_ttt_P_SAN() {
    try {
        var a_dt = GridX_Fdt_cotGtriL(b_gridId, "MA", "MA");
        skhud.Fs_TTT_SAN(b_ps, b_nv, a_dt, khud_ttt_P_SAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function khud_ttt_P_SAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") alert("Đã chọn hết");
    else {
        GridX_datBang(b_grsanId, b_kq);
        form_Fctr_TENVUNG('UPa_san').style.display = "";
    }
}
function khud_ttt_P_CHON() {
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
function khud_ttt_DONG() {
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}
function khud_ttt_P_NH() {
    try {
        var b_dt = GridX_Fdt_cotGtri(b_gridId);
        skhud.Fs_TTT_NH(b_ps, b_nv, b_dt, khud_ttt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function khud_ttt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DONG(window.name, null);
}
function khud_ttt_P_XOA() {
    try {
        skhud.Fs_TTT_XOA(b_ps, b_nv, khud_ttt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function khud_ttt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else GridX_moi(b_gridId);
}
function khud_ttt_len() {
    GridX_chuyenHang(b_gridId, -1);
    return false;
}
function khud_ttt_xuong() {
    GridX_chuyenHang(b_gridId, 1);
    return false;
}
function khud_ttt_chen() {
    GridX_chenHang(b_gridId);
    return false;
}
function khud_ttt_cat() {
    GridX_boChon(b_gridId);
    return false;
}
function khud_ttt_P_LKE() {
    var a_cot = GridX_Fas_tenCot(b_gridId);
    skhud.Fs_TTT_LKE(b_ps, b_nv, a_cot, khud_ttt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function khud_ttt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq[0] == "K") form_Fctr_VTEN_DTUONG('', 'td_hien_san').style.display = "none";
        GridX_datBang(b_gridId, a_kq[1]);
    }
}
