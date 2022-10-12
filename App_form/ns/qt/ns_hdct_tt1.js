var ns_hdct_tt_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId,b_nsd;
function ns_hdct_tt_P_KD(b_so_the) {
    ns_hdct_tt_lkeCho, b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_slideId = b_grlkeId + '_slide';
    b_nsd = b_so_the, ns_hdct_tt_lkeCho = setInterval('ns_hdct_tt_P_LKE_CHO()', 200);

}
function ns_hdct_tt_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_hdct_tt_P_LKE(); }
}

function ns_hdct_tt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_hdct_tt_lkeCho); ns_hdct_tt_P_LKE(); }
}
function ns_hdct_tt_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_qt.Fs_NS_HDCT_TT_LKE(b_nsd, a_cot, a_tso, ns_hdct_tt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdct_tt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_hdct_tt_P_PHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        b_ykien = GridX_Fas_layGtri(b_grlkeId, b_hang, "ykien");
    sns_dt.Fs_NS_DT_DANGKYKH_PHEDUYET(b_so_id, b_ykien, ns_hdct_tt_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_hdct_tt_P_PHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_hdct_tt_P_LKE();
}
function ns_hdct_tt_P_KOPHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        b_ykien = GridX_Fas_layGtri(b_grlkeId, b_hang, "ykien");
    sns_dt.Fs_NS_DT_DANGKYKH_KOPHEDUYET(b_so_id, b_ykien, ns_hdct_tt_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_hdct_tt_P_KOPHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_hdct_tt_P_LKE();
}

function ns_hdct_tt_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    form_P_MO("ns_dt_taokh.aspx", null, ["KQ", [b_ma]]);
    return false;
}

function ns_hdct_tt_P_DANGKY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_tinhtrang = $get(b_gocId).value;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    sns_dt.Fs_NS_DT_DANGKYKH_NH(b_ma, b_tinhtrang, ns_hdct_tt_P_DANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdct_tt_P_DANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Đã đăng ký thành công!"); }
    ns_hdct_tt_P_LKE();
    return false;
}
function ns_hdct_tt_P_HUYDANGKY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    var b_tinhtrang = $get(b_gocId).value;
    sns_dt.Fs_NS_DT_DANGKYKH_XOA(b_ma, b_tinhtrang, ns_hdct_tt_P_HUYDANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdct_tt_P_HUYDANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Hủy đăng ký thành công!"); }
    ns_hdct_tt_P_LKE();
    return false;
}
function form_dong() {
    location.reload(false);
}