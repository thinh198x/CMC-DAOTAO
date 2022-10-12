var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_Ten, b_ttrang, b_luudayId='';
function dgnl_dm_n_nl_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_Ten = form_Fs_TEN_ID(b_vungId, 'TEN');
    b_ttrang = form_Fs_TEN_ID(b_vungId, 'TT'), b_slideId = b_grlkeId + '_slide';
    b_lkeCho = setInterval('dgnl_dm_n_nl_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                dgnl_dm_n_nl_P_LKE();
            }
        }
        else {
            b_dtuong = b_dtuong.toUpperCase();
            var b_kq = a_tso[0];
            b_doi = 0;
            if (b_dtuong.indexOf("THAMSO") >= 0) {
                b_luudayId = b_kq;
                dgnl_dm_n_nl_P_LKE();//hd_ma_nnnghe_P_LKE();
            }

            if (b_dtuong.toUpperCase().endsWith("MA_CD") > 0) {
                $get(b_ma_cdId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
                b_hang = GridX_Fi_timHangD(b_grlkeId, "MA_CD", $get(b_ma_cdId).value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); }
                else { GridX_datA(b_grlkeId, b_hang); hdns_mota_cv_P_CHUYEN_HANG(); }

            }
            else if (b_dtuong.toUpperCase().endsWith("BAO_CAO_CHO") > 0) {
                $get(b_bao_cao_choId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("QUAN_HE_TRONG") > 0) {
                $get(b_quan_he_trong_Id).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.indexOf("NHOM_NL") >= 0) {
                b_doi = 1;
                var b_hang = GridX_Fi_timHangA(b_grqhcvId);
                if (b_hang < 0) return;
                $get(b_gchuId).innerHTML = a_tso[1];
                GridX_datGtri(b_grqhcvId, b_hang, ["nhom_nl"], [a_tso[0]], 'K');
                // $get(b_nang_lucId).focus();
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_n_nl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dgnl_dm_n_nl_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_n_nl_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_n_nl_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DGNL_DM_N_NL_MA(b_ma, b_TrangKt, a_cot, dgnl_dm_n_nl_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_n_nl_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_n_nl_P_CHUYEN_HANG(); }
}
function dgnl_dm_n_nl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_ttrang).value = "A";
    GridX_thoiA(b_grlkeId);
    $get(b_Ten).focus();
    return false;
}
function dgnl_dm_n_nl_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_DGNL_DM_N_NL_NH(b_TrangKt, a_dt_ct, a_cot, dgnl_dm_n_nl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dgnl_dm_n_nl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function dgnl_dm_n_nl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") dgnl_dm_n_nl_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_N_NL_XOA(b_ma, a_tso, a_cot, dgnl_dm_n_nl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dgnl_dm_n_nl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dgnl_dm_n_nl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_n_nl_P_CHUYEN_HANG(); }
    }
}
function dgnl_dm_n_nl_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("dgnl_dm_n_nl_P_CHUYEN_HANG()", 300);
    return false;
}
function dgnl_dm_n_nl_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_so_id1 = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
        if (b_so_id == null || b_so_id == "") {
            form_P_MOI(b_vungId, "GLX");
            GridX_datTrang(b_grctId);
        }
        else {
            var a_cot_ct = GridX_Fas_tenCot(b_grctId);
            sns_ktkl.Fs_NS_KTKL_QLKT_CT(b_so_id, a_cot_ct, ns_ktkl_qlkt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_n_nl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); dgnl_dm_n_nl_P_LKE(); }
}
function dgnl_dm_n_nl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_N_NL_LKE(a_tso, a_cot, dgnl_dm_n_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_n_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    GridX_datA(b_grlkeId, 1);
    dgnl_dm_n_nl_P_CHUYEN_HANG();
}
function form_dong() {
    location.reload(false);
}