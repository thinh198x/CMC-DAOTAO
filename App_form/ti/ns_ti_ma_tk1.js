var b_ps, b_nv, b_gridId, b_grsanId, ns_ti_ma_tk_lkeCho;
function ns_ti_ma_tk_KD() {
    ns_ti_ma_tk_lkeCho; b_gridId = form_Fs_VUNG_ID('GR_dk'); b_grsanId = form_Fs_VUNG_ID('GR_san');
    ns_ti_ma_tk_lkeCho = setInterval('ns_ti_ma_tk_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (C_NVL(b_dtuong) == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            var a_s = a_tso[0].split(',');
            if (a_s.length > 2) {
                b_ps = a_s[0]; b_nv = a_s[1]; form_Fctr_VTEN_DTUONG('', 'ten_form').innerHTML = "Thông tin thống kê " + a_s[2];
                ns_ti_ma_tk_P_LKE();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ti_ma_tk_GR_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event);
    if (C_NVL(b_ctr.value) != "") GridX_ThemHang(b_gridId);
    return false;
}
function ns_ti_ma_tk_LKE_CHO() {
    if ($get(b_gridId) != null) { clearTimeout(ns_ti_ma_tk_lkeCho); ns_ti_ma_tk_P_LKE(); }
}

function ns_ti_ma_tk_P_SAN() {
    try {
        var a_dt = GridX_Fdt_cotGtriL(b_gridId, "MA", "MA");
        sti_ch.Fs_TI_MA_TK_SAN('TK', 'TK', a_dt, ns_ti_ma_tk_P_SAN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ti_ma_tk_P_SAN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") alert("Đã chọn hết");
    else {
        GridX_datBang(b_grsanId, b_kq);
        form_Fctr_TENVUNG('UPa_san').style.display = "";
    }
}
function ns_ti_ma_tk_P_CHON() {
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
function ns_ti_ma_tk_DONG() {
    form_Fctr_TENVUNG('UPa_san').style.display = "none";
    return false;
}
function ns_ti_ma_tk_P_NH() {
    try {
        var b_dt = GridX_Fdt_cotGtri(b_gridId);
        sti_ch.Fs_TI_MA_TK_NH('TK', 'TK', b_dt, ns_ti_ma_tk_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ti_ma_tk_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DONG(window.name, null);
}
function ns_ti_ma_tk_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        sti_ch.Fs_TI_MA_TK_XOA('TK', 'TK', ns_ti_ma_tk_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ti_ma_tk_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else GridX_moi(b_gridId);
}
function ns_ti_ma_tk_len() {
    GridX_chuyenHang(b_gridId, -1);
    return false;
}
function ns_ti_ma_tk_xuong() {
    GridX_chuyenHang(b_gridId, 1);
    return false;
}
function ns_ti_ma_tk_chen() {
    GridX_chenHang(b_gridId);
    return false;
}
function ns_ti_ma_tk_cat() {
    GridX_boChon(b_gridId);
    return false;
}
function ns_ti_ma_tk_P_LKE() {
    var a_cot = GridX_Fas_tenCot(b_gridId);
    sti_ch.Fs_TI_MA_TK_LKE('TK', 'TK', a_cot, ns_ti_ma_tk_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_ti_ma_tk_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        GridX_dat_hangkt(b_gridId, a_kq[2]);
        GridX_datBang(b_gridId, a_kq[1]);
    }
}

function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '22');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 23);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
}

function form_dong() {
    location.reload(false);
}