var b_goc = "";
function P_KET_QUA(b_dtuong, a_tso) {
    b_goc = C_NVL(b_dtuong);
}
function kh_gop_P_NH() {
    try {
        var b_nd = form_Fs_VTEN_GTRI('', 'ND');
        if (b_nd == "") form_P_LOI_DICH("Xin nhập nội dung");
        else skhud.Fs_GOP_NH(form_Fs_nsd(),b_goc, b_nd, kh_gop_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function kh_gop_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { form_Fctr_VTEN_DTUONG('', 'ND').value = ""; form_P_LOI_DICH("Xin cảm ơn đã góp ý kiến."); }
}
