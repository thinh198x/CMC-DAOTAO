var b_lienket_mdf, b_lienket_divId, b_lienket_tmf;
function lienket_P_KD(b_md, b_divId, b_tmuc) {
    b_lienket_mdf = b_md; b_lienket_divId = b_divId; b_lienket_tmf = b_tmuc;
}
function lienket_P_NHAN_TSO(b_lk, b_so_id) {
    try {
        $get(b_lienket_divId).innerHTML = "";
        if (b_lk != "") sktkt_ctr.lienket_Fs_DAT_LKET(b_lienket_mdf, b_lk, b_so_id, b_lienket_tmf, lienket_P_NHAN_TSO_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function lienket_P_NHAN_TSO_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else $get(b_lienket_divId).innerHTML = b_kq;
}
function lienket_P_XULY(b_ftkhao, b_so_id_s, b_dong) {
    var b_so_id = CSO_SO(O_NVL(b_so_id_s, "0"), 0);
    if (b_so_id != 0) {
        var a_tso = ["SO_ID", [b_so_id, "HTOAN", "LKET"]];
        if (b_dong == "C") a_tso[2] = window.name;
        form_P_MO(b_ftkhao, null, a_tso);
    }
    return false;
}
