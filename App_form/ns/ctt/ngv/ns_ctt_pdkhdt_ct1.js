var ns_ctt_pdkhdt_ct_lkeCho, ns_ctt_pdkhdt_ct_gchuCho, b_vungId, b_grlke_cpId, b_grlke_tkbId, b_grlke_monId, b_gchuId, b_so_id_kh = 0, b_nsd;

function ns_ctt_pdkhdt_ct_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grlke_cpId = form_Fs_VUNG_ID('GR_cpdt'),
    b_grlke_tkbId = form_Fs_VUNG_ID('GR_tkb'),
    b_grlke_monId = form_Fs_VUNG_ID('GR_mon');
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_nsd = form_Fs_nsd();
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_so_id_kh = a_tso[1];           
            ns_ctt_pdkhdt_ct_lkeCho = setInterval('ns_ctt_pdkhdt_ct_P_LKE_CHO()', 200);
        }        
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_ctt_pdkhdt_ct_P_LKE_CHO() {
    if ($get(b_grlke_cpId) != null) {
        clearTimeout(ns_ctt_pdkhdt_ct_lkeCho);
        ns_ctt_pdkhdt_ct_P_LKE();
    }
}

// use
function ns_ctt_pdkhdt_ct_P_LKE() {
    try {        
        var a_cot_cp = GridX_Fas_tenCot(b_grlke_cpId), a_cot_tkb = GridX_Fas_tenCot(b_grlke_tkbId), a_cot_mon = GridX_Fas_tenCot(b_grlke_monId);
        sns_ctt.Fs_NS_DT_KH_CT_ALL(b_nsd, b_so_id_kh, a_cot_cp, a_cot_tkb, a_cot_mon, ns_ctt_pdkhdt_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
// use
function ns_ctt_pdkhdt_ct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');

    var b_dong_cp = CSO_SO(a_kq[0]), b_dong_tkb = CSO_SO(a_kq[1]), b_dong_mon = CSO_SO(a_kq[2]);
    GridX_P_hangKt(b_grlke_cpId, b_dong_cp > 0 ? b_dong_cp : 2);
    GridX_P_hangKt(b_grlke_tkbId, b_dong_tkb > 0 ? b_dong_tkb : 2);
    GridX_P_hangKt(b_grlke_monId, b_dong_mon > 0 ? b_dong_mon : 2);

    form_P_CH_TEXT(b_vungId, a_kq[3]);
    GridX_datBang(b_grlke_cpId, a_kq[4]);
    GridX_datBang(b_grlke_tkbId, a_kq[5]);
    GridX_datBang(b_grlke_monId, a_kq[6]);
}
function ns_ctt_pdkhdt_ct_P_NH(b_tt_pd) {
    try {        
        sns_ctt.Fs_NS_DT_KH_CT_NH_PD(b_nsd, b_so_id_kh, b_tt_pd, ns_ctt_pdkhdt_ct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_pdkhdt_ct_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ctt_pdkhdt_ct_P_DatGchu(true, "Cập nhật thành công!");
    }
    return false;
}
function ns_ctt_pdkhdt_ct_P_DatGchu(show, b_kq) {
    if (Fb_LOI_KTRA(b_kq))
        form_P_LOI(b_kq);
    else {
        form_P_DatGchu(b_gchuId, b_kq);
        if (show) ns_ctt_pdkhdt_ct_gchuCho = setInterval('ns_ctt_pdkhdt_ct_P_DatGchu(false,".")', 2000);
        else clearTimeout(ns_ctt_pdkhdt_ct_gchuCho);
    }
}