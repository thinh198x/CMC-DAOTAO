var b_ktvt_tonPhieuId;
function ktvt_tonPhieu_KD(b_grId) {
    b_ktvt_tonPhieuId = b_grId;
}
function ktvt_tonPhieu_TAO(b_dk) {
    try {
        if (b_dk == 'M') GridX_datTrang(b_ktvt_tonPhieuId);
        var b_l_ct = ktvt_ct_Fs_LCT(), a_tso = ktvt_ct_Faobj_TON_PHIEU_TSO(), a_cot = GridX_Fas_tenCot(b_ktvt_tonPhieuId);
        sktvt_ct.Fs_TON_PHIEU(window.name, b_dk, b_l_ct, a_tso, a_cot, ktvt_tonPhieu_TAO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ktvt_tonPhieu_TAO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == "") alert('Hết tồn theo phiếu nhập');
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        if (a_kq.length > 1) {
            var a_ten = Fas_ChMang(a_kq[1], '|');
            var b_cot = "luong_p1,xuat_p1", b_ten = "Tồn(" + a_ten[0] + "),Xuất(" + a_ten[0] + ")";
            if (a_ten.length > 1) { b_cot += ",luong_p2,xuat_p2"; b_ten += ",Tồn(" + a_ten[1] + "),Xuất(" + a_ten[1] + ")"; }
            else GridX_anCot(b_ktvt_tonPhieuId, "luong_p2,xuat_p2", true);
            GridX_titCot(b_ktvt_tonPhieuId, b_cot, b_ten); GridX_anCot(b_ktvt_tonPhieuId, b_cot, false);
        }
        else GridX_anCot(b_ktvt_tonPhieuId, "luong_p1,xuat_p1,luong_p2,xuat_p2", true);
        GridX_datBang(b_ktvt_tonPhieuId, a_kq[0]);
        ktvt_ct_P_TAO_CTR('tonPhieu'); GridX_datA(b_ktvt_tonPhieuId, 1, "XUAT");
    }
}
function ktvt_tonPhieu_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_ktvt_tonPhieuId);
        var b_xuat = CSO_SO(O_NVL(b_ctr.value,"0"),2), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        if (b_cot == "TONPHIEU_XUAT" && b_xuat != "") {
            var b_xuat_p1=0, b_xuat_p2=0, a_s = GridX_Fas_layGtri(b_ktvt_tonPhieuId,b_hang, "luong,luong_p1,luong_p2");
            var b_luong = CSO_SO(a_s[0], 2), b_luong_p1 = CSO_SO(a_s[1], 2), b_luong_p2 = CSO_SO(a_s[2], 2);
            if (b_luong == b_xuat) { b_xuat_p1 = b_luong_p1; b_xuat_p2 = b_luong_p2; }
            else if (b_luong != 0) {
                b_luong = b_xuat / b_luong;
                if (b_luong_p1 != 0) { b_xuat_p1 = ROUNDN(b_luong_p1 * b_luong, 0); }
                if (b_luong_p2 != 0) { b_xuat_p2 = ROUNDN(b_luong_p2 * b_luong, 0); }
            }
            GridX_datGtri(b_ktvt_tonPhieuId, b_hang, ["xuat_p1", "xuat_p2"], [SO_CSO(b_xuat_p1, 0), SO_CSO(b_xuat_p2, 0)], "K");
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ktvt_tonPhieu_DONG() {
    ktvt_ct_P_XOA_CTR('tonPhieu','D');
    return false;
}
function ktvt_tonPhieu_CatDong(b_dk) {
    GridX_boChon(b_ktvt_tonPhieuId,b_dk);
    return false;
}
function ktvt_tonPhieu_NH() {
    try {
        var a_tso = ktvt_ct_Faobj_TON_PHIEU_TSO(), b_l_ct = ktvt_ct_Fs_LCT(), a_dt = GridX_Fdt_cotGtriH(b_ktvt_tonPhieuId);
        sktvt_ct.Fs_TON_PHIEU_NH(window.name, b_l_ct, a_tso, a_dt, ktvt_tonPhieu_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ktvt_tonPhieu_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else ktvt_ct_P_XOA_CTR('tonPhieu');
}
