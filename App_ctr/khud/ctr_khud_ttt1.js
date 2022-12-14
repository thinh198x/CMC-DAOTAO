var b_khud_ttt_taoCho, b_khud_ttt_nv, b_khud_ttt_ps, b_khud_ttt_gridId, b_khud_ttt_gchuId;
function khud_ttt_KD(b_ps, b_nv, b_gcId, b_grId) {
    b_khud_ttt_ps = b_ps; b_khud_ttt_nv = b_nv; b_khud_ttt_gchuId = b_gcId; b_khud_ttt_gridId = b_grId;
    b_khud_ttt_taoCho = setInterval('khud_ttt_TAO_CHO()', 500);
}
function khud_ttt_P_KET_QUA(b_dtuong, a_tso) {
    var b_hang = GridX_Fi_timHangA(b_khud_ttt_gridId);
    if (b_hang > 0) {
        GridX_datGtri(b_khud_ttt_gridId,b_hang, ['nd'], [a_tso[0]], 'K'); GridX_datA(b_khud_ttt_gridId, b_hang, 'nd');
    }
}
function khud_ttt_GR_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event);
        var b_value = C_NVL(b_ctr.value), b_ktra = C_NVL(b_ctr.getAttribute('ktra'));
        if (b_value != '') {
            if (C_NVL(b_ctr.getAttribute('kieu_date')) != '') {
                var b_loi = Fs_NGAY_LOI(b_value, 'C');
                if (b_loi != '') form_P_LOI_DICH(b_loi);
            }
            else if (b_ktra != '') {
                var b_ten=GridX_Fas_layGtriA(b_khud_ttt_gridId, 'ten');
                skhac.Fs_MA_LOI(form_Fs_nsd(),b_ten, b_value, b_ktra, khud_ttt_LOI, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_ttt_LOI(b_kq) {
    var b_loi='K';
    if (Fb_LOI_KTRA(b_kq)) { b_loi = 'C'; form_P_LOI(b_kq); }
    else if (b_kq != '') $get(b_khud_ttt_gchuId).innerHTML = b_kq;
    GridX_datGtriA(b_khud_ttt_gridId, ['loi'], [b_loi], 'K');
}
function khud_ttt_P_DONG() {
    $get(b_khud_ttt_gchuId).innerHTML = '.';
}
function khud_ttt_P_MOI() {
    GridX_datTrang(b_khud_ttt_gridId, null, null, 'ND'); GridX_thoiA(b_khud_ttt_gridId); khud_ttt_MAU();
}
function khud_ttt_Fdt_LAY_NH() {
    try {
        var a_dt = GridX_Fdt_cotGtriH(b_khud_ttt_gridId), b_nd, b_loai, b_loi = '';
        if (a_dt[1] != null) {
            for (var i = 0; i < a_dt[1].length; i++) {
                b_nd = C_NVL(a_dt[1][i][1]); b_loai = C_NVL(a_dt[1][i][3]);
                if (C_NVL(a_dt[1][i][4]) == 'C' && C_NVL(a_dt[1][i][1]) == '') b_loi = 'Phải nhập:';
                else if (b_loai == 'N' && b_nd != '') {
                    b_loi = Fs_NGAY_LOI(b_nd, 'C');
                    if (b_loi != '') b_loi += ' :';
                }
                else if (C_NVL(a_dt[1][i][5]) == 'C') b_loi = 'Nhập sai:';
                if (b_loi != '') { form_P_LOI('loi:' + b_loi + C_NVL(a_dt[1][i][0]) + ':loi'); break; }
                if (b_loai == 'S') a_dt[1][i][1] = CSO_SO(b_nd, 6).toString();
            }
            a_dt = GridX_Fdt_cotGtriL(b_khud_ttt_gridId, 'MA,nd', 'MA,nd,loai');
            if (a_dt[1] != null) {
                for (var i = 0; i < a_dt[1].length; i++) {
                    if (C_NVL(a_dt[1][i][2]) == 'S') a_dt[1][i][1] = CSO_SO(a_dt[1][i][1], 6).toString();
                }
            }
        }
        return a_dt;
    }
    catch (ex) { return [null, null]; }
}

function khud_ttt_TAO_CHO() {
    if (document.readyState === 'complete') {
        clearInterval(b_khud_ttt_taoCho); khud_ttt_TAO();
    }
}
function khud_ttt_TAO() {
    try { skhud.Fs_TTT_TAO(form_Fs_nsd(),b_khud_ttt_ps, b_khud_ttt_nv,'', khud_ttt_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
    catch (ex) { form_P_LOI(ex.message); }
}
function khud_ttt_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq != '') {
        var a_kq = ((b_kq instanceof Array)) ? b_kq : Fas_ChMang(b_kq, '#');
        b_kq = a_kq[0]; a_kq.splice(0, 1);
        //GridX_dtuCot(b_khud_ttt_gridId, 'ND', a_kq);
        GridX_datBang(b_khud_ttt_gridId, b_kq);// khud_ttt_MAU();
    }
}
function khud_ttt_MAU() {
    var a_dt = GridX_Fdt_layGtri(b_khud_ttt_gridId, 'loai');
    for ( var i = 0; i < a_dt.length; i++) {
        if (C_NVL(a_dt[i]) == 'G') GridX_MauCell(b_khud_ttt_gridId, i + 1, 'ten', '#EFEAD3', 'blue')
    }
}
function khud_ttt_P_LKE(b_kq) {
    khud_ttt_P_MOI();
    if (b_kq != '') GridX_thayGtri(b_khud_ttt_gridId, 'MA', 'ND', 'MA,ND', b_kq);
}
function khud_ttt_P_DAT_A() {
    GridX_datA(b_khud_ttt_gridId, 1, 'nd');
}
