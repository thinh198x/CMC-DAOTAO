var ns_hdns_lsdbien_lkeCho, b_vungId, b_cho_control = 0, b_namts, b_phong, b_grlkeId, b_grctId, b_loi_id, b_mt, b_thangId, b_doi = 0, b_ncd2Id,
    ns_hdns_lsdbien_choAct = 0;
function ns_hdns_lsdbien_P_KD() {
    ns_hdns_lsdbien_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_namts = a_tso[4];
            b_phong = a_tso[5];
            ns_hdns_lsdbien_lkeCho = setInterval('ns_hdns_lsdbien_P_LKE_CHO()', 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Chuyển hàng
function ns_hdns_lsdbien_GR_lke_RowChange() {
    if (ns_hdns_lsdbien_choAct != 0) clearTimeout(ns_hdns_lsdbien_choAct);
    ns_hdns_lsdbien_choAct = setTimeout("ns_hdns_lsdbien_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_lsdbien_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId); b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    b_phong = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "donvi")); b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1) b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, 1, "nam"));;
    if (b_nam == null || b_phong == "") { form_P_MOI("", "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sns_td.Fs_NS_HDNS_LSDBIEN_CT(b_nam, b_so_id, a_cot_ct, ns_hdns_lsdbien_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_hdns_lsdbien_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
// Liệt kê
function ns_hdns_lsdbien_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_hdns_lsdbien_lkeCho != 0) clearTimeout(ns_hdns_lsdbien_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_hdns_lsdbien_P_LKE('K');
    }
}
function ns_hdns_lsdbien_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_HDNS_LSDBIEN_LKE(form_Fs_nsd(), b_namts, b_phong, a_tso, a_cot, ns_hdns_lsdbien_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_hdns_lsdbien_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function form_dong() {
    location.reload(false);
}