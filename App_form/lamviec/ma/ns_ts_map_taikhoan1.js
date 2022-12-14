var b_cho = 0, b_choAct = 0, b_vungId, b_grlkeId, b_nhomId, b_gocId, b_doi, b_macnId;
function ns_ts_map_taikhoan_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_macnId = form_Fs_TEN_ID(b_vungId, 'MA_CN');
    b_cho = setInterval('ns_ts_map_taikhoan_P_LKE_CHO()', 200);
}
function ns_ts_map_taikhoan_P_KTRA(b_maTen) {
    b_maTen = b_maTen.toUpperCase();
    if (b_maTen == "MA") {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma);
        if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
        else { GridX_datA(b_grlkeId, b_hang); ns_ts_map_taikhoan_P_CHUYEN_HANG(); }
        form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
    }
}
function ns_ts_map_taikhoan_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
}
function ns_ts_map_taikhoan_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            sns_ts.Fs_NS_TS_MAP_TAIKHOAN_NH(form_Fs_nsd(),a_dt, ns_ts_map_taikhoan_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
        }else if (b_doi == 1) {
            $get(b_macnId).value = b_so_the;
        }
        clearTimeout(b_cho_control);
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_doi = 1;
        if (b_dtuong.indexOf("MA_CN") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200); 
        } else if (b_dtuong.indexOf("MA") >= 0) {
            b_doi = 0;
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "')", 200); 
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ts_map_taikhoan_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        a_dt[1] = kytu_locUnicode(a_dt[1]);
        GridX_datGtriT(b_grlkeId, "ma", a_dt);
        $get(b_gocId).focus();
    }
}
function ns_ts_map_taikhoan_P_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ns_ts_map_taikhoan_P_MOI();
        else sns_ts.Fs_NS_TS_MAP_TAIKHOAN_XOA(form_Fs_nsd(),b_ma, ns_ts_map_taikhoan_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ts_map_taikhoan_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        GridX_datA(b_grlkeId, b_hang); ns_ts_map_taikhoan_P_CHUYEN_HANG();
    }
}
function ns_ts_map_taikhoan_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_ts_map_taikhoan_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ts_map_taikhoan_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    else form_P_GridX_TEXT(b_vungId, b_grlkeId);
}
function ns_ts_map_taikhoan_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_cho); ns_ts_map_taikhoan_P_LKE(); }
}
function ns_ts_map_taikhoan_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_ts.Fs_NS_TS_MAP_TAIKHOAN_LKE(form_Fs_nsd(),a_cot, ns_ts_map_taikhoan_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ts_map_taikhoan_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else GridX_datBang(b_grlkeId, b_kq);
}
