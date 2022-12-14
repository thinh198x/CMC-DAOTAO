var ns_dt_dangkykh_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_dt_dangkykh_P_KD() {
    ns_dt_dangkykh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'tinhtrang');
    b_slideId = b_grlkeId + '_slide';
    ns_dt_dangkykh_lkeCho = setInterval('ns_dt_dangkykh_P_LKE_CHO()', 200);

}
function ns_dt_dangkykh_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_dt_dangkykh_P_LKE(); }
}

function ns_dt_dangkykh_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_dt_dangkykh_lkeCho != 0) clearTimeout(ns_dt_dangkykh_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_dangkykh_P_LKE('K');
    }
}
function ns_dt_dangkykh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            a_tinhtrang = $get(b_gocId).value;
        sns_dto.Fs_NS_DT_DANGKYKH_LKE(a_tinhtrang, a_tso, a_cot, ns_dt_dangkykh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_dt_dangkykh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}

function ns_dt_dangkykh_P_PHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        b_ykien = GridX_Fas_layGtri(b_grlkeId, b_hang, "ykien");
    sns_dto.Fs_NS_DT_DANGKYKH_DUYET(b_so_id, b_ykien, ns_dt_dangkykh_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_dangkykh_P_PHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_dt_dangkykh_P_LKE();
}
function ns_dt_dangkykh_P_KOPHEDUYET() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id")),
        b_ykien = GridX_Fas_layGtri(b_grlkeId, b_hang, "ykien");
    sns_dto.Fs_NS_DT_DANGKYKH_HUYDUYET(b_so_id, b_ykien, ns_dt_dangkykh_P_KOPHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_dangkykh_P_KOPHEDUYET_KQ(b_kq) {
    GridX_datTrang(b_grlkeId);
    ns_dt_dangkykh_P_LKE();
}

function ns_dt_dangkykh_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn chưa chọn khóa học:loi"); return false; }
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") {
        form_P_LOI("loi:Bạn chưa chọn khóa học:loi"); return false;
    }
    form_P_MO("~/App_form/ns/dto/ns_dt_kdt_xem.aspx", null, ["KQ", [b_ma]]);
    return false;
}

function ns_dt_dangkykh_P_DANGKY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_tinhtrang = $get(b_gocId).value;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    sns_dto.Fs_NS_DT_DANGKYKH_NH(b_ma, b_tinhtrang, ns_dt_dangkykh_P_DANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_dangkykh_P_DANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Đã đăng ký thành công!"); }
    ns_dt_dangkykh_P_LKE();
    return false;
}
function ns_dt_dangkykh_P_HUYDANGKY() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    var b_tinhtrang = $get(b_gocId).value;
    sns_dto.Fs_NS_DT_DANGKYKH_XOA(b_ma, b_tinhtrang, ns_dt_dangkykh_P_HUYDANGKY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_dangkykh_P_HUYDANGKY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { alert("Hủy đăng ký thành công!"); }
    ns_dt_dangkykh_P_LKE();
    return false;
}
function form_dong() {
    location.reload(false);
}