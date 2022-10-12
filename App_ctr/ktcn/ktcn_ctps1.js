var b_ctps_GridId, b_ctps_slideId;
function ktcn_ctps_P_KD(b_gridId) {
    b_ctps_GridId = b_gridId; b_ctps_slideId = b_gridId + '_slide';
}
function ktcn_ctps_Update(b_event) {
    var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_ctps_GridId), b_tg = 1;
    var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').substr(5).toUpperCase();
    if (C_NVL(b_value) != "") {
        if (!GridX_Fb_anCot(b_ctps_GridId, "tien_qd")) {
            var b_ton = CSO_SO(O_NVL(GridX_Fas_layGtri(b_ctps_GridId, b_hang, "ton"), "0"), 0),
                b_ton_qd = CSO_SO(O_NVL(GridX_Fas_layGtri(b_ctps_GridId, b_hang, "ton_qd"), "0"), 0);
            if (b_ton != 0) b_tg = b_ton_qd / b_ton;
        }
        switch (b_cot) {
            case "TIEN":
                var b_tien = CSO_SO(b_value, 2);
                var b_tien_qd = (b_tg == 1) ? b_tien : ROUNDN(b_tien * b_tg, 0);
                GridX_datGtri(b_ctps_GridId, b_hang, "tien_qd", b_tien_qd.toString(),'K');
                break;
            case "PHI":
                var b_phi = CSO_SO(b_value, 2);
                var b_phi_qd = (b_tg == 1) ? b_phi : ROUNDN(b_phi * b_tg, 0);
                GridX_datGtri(b_ctps_GridId, b_hang, "phi_qd", b_phi_qd.toString(),'K');
                break;
        }
    }
    return false;
}
function ktcn_ctps_P_TAO() {
    try {
        var a_tso = ktcn_ct_Faobj_TAO_TSO();
        if (a_tso == null) alert("Chưa nhập đủ tham số thanh toán");
        else sktcn_ct.Fs_TAO_CTPS(window.name, a_tso, ktcn_ctps_P_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ktcn_ctps_P_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") alert("Đã thanh toán hết");
    else {
        var b_log = (b_kq == "VND");
        GridX_anCot(b_ctps_GridId, "tien_qd,ton_qd,phi_qd", b_log);
        ktcn_ctps_LKE('M'); ktcn_ct_P_TAO_CTR("ps");
    }
}
function ktcn_ctps_xl(b_dk) {
    try {
        if (b_dk == 'D') ktcn_ctps_xl_KQ('D');
        else {
            if ("CGT".indexOf(b_dk) >= 0) slide_P_MOI(b_ctps_slideId, 1, 1);
            var a_dt = GridX_Fdt_layGtri(b_ctps_GridId, ['TIEN', 'TIEN_QD', 'phi', 'phi_qd', 'SO_ID_PS', 'bt_ps', 'ccc']),
                a_tso = (b_dk == 'T') ? ktcn_ct_Faobj_TAO_TSO() : null;
            sktcn_ct.Fs_XL_CTPS(window.name, b_dk, a_dt, a_tso, ktcn_ctps_xl_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ktcn_ctps_xl_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if ("DN".indexOf(b_kq)>=0) { GridX_moi(b_ctps_GridId); slide_P_MOI(b_ctps_slideId, 1, 1); ktcn_ct_P_XOA_CTR('ps'); }
    else ktcn_ctps_LKE(b_kq);
}
function ktcn_ctps_LKE(b_dk) {
    try {
        if (C_NVL(b_dk) == 'M') slide_P_MOI(b_ctps_slideId, 1, 1);
        var a_cot = GridX_Fas_tenCot(b_ctps_GridId), a_tso = slide_Faobj_TUDEN(b_ctps_slideId);
        sktcn_ct.Fs_LKE_CTPS(window.name, a_cot, a_tso, ktcn_ctps_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ktcn_ctps_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_ctps_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_ctps_GridId, a_kq[1]);
    }
}
