
       var ns_cppd_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId;
function ns_cppd_P_KD() {
    ns_cppd_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    ns_cppd_lkeCho = setInterval('ns_cppd_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("ten_phong") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang < 0) GridX_datGtri(b_grlkeId, 0, ["ten_phong"], [a_tso[1]], 'K'), GridX_datGtri(b_grlkeId, 0, ["phong"], [a_tso[0]], 'K');
            else
                GridX_datGtri(b_grlkeId, b_hang, ["ten_phong"], [a_tso[1]], 'K'), GridX_datGtri(b_grlkeId, 0, ["phong"], [a_tso[0]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cppd_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_cppd_P_LKE(); }
}

function ns_cppd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_cppd_lkeCho); ns_cppd_P_LKE(); }
}
function ns_cppd_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value;
        sns_qt.Fs_NS_CPPD_LKE(a_tinhtrang, a_tso, a_cot, ns_cppd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cppd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_cppd_P_PHEDUYET() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_qt.Fs_NS_CPPD_PHEDUYET(b_dt_ct, ns_cppd_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cppd_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datTrang(b_grlkeId);
    ns_cppd_P_LKE();
    return false;
}

function ns_cppd_P_HUYPHEDUYET() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_qt.Fs_NS_CPPD_HUYPHEDUYET(b_dt_ct, ns_cppd_P_HUYPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cppd_P_HUYPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datTrang(b_grlkeId);
    ns_cppd_P_LKE();
    return false;
}

function ns_cppd_P_KOPHEDUYET() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    sns_qt.Fs_NS_CPPD_KOPHEDUYET(b_dt_ct, ns_cppd_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cppd_P_KOPHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datTrang(b_grlkeId);
    ns_cppd_P_LKE();
    return false;
}

function ns_cppd_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    form_P_MO("ns_dt_kdt.aspx", null, ["KQ", [b_ma]]);
    return false;
}
function ns_cppd_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "so_id"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
        }
    }
    return false;
}
function form_dong() {
    location.reload(false);
}