function kh_dich_P_NH() {
    try {
        var b_tmuc = C_NVL(form_Fs_TEN_GTRI('', 'TMUC')), b_loai = C_NVL(form_Fs_TEN_GTRI('', 'loai'));
        if (b_loai == "F") skhac.Fs_DICH_FORM(form_Fs_nsd(),b_tmuc, kh_dich_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else skhac.Fs_DICH_SQL(form_Fs_nsd(),b_tmuc, kh_dich_P_SQL_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function kh_dich_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq!="") {
        var a_kq = Fas_ChMang(b_kq, '#'), b_tmf = form_Fs_TM('f'), b_f;
        for (var i = 0; i < a_kq.length; i++) {
            b_ten = form_Fs_TEN(a_kq[i]);
            if (b_ten != window.name) {
                b_f = b_tmf + a_kq[i];
                setTimeout("form_P_MO('" + b_f + "')", i * 3000);
                setTimeout("form_P_DONG('" + b_ten + "')", (i+1) * 3000);
            }
        }
    }
}
function kh_dich_P_SQL_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_LOI_DICH("Đã xong");
}
