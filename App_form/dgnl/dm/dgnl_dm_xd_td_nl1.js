
var dgnl_dm_xd_td_nl_lkeCho, b_vungId, b_gchuId,b_grlkeId, b_slideId, b_nhom_nl, b_timId, b_nangluc, b_so_id, b_ma_mnl;
function dgnl_dm_xd_td_nl_P_KD() {
    dgnl_dm_xd_td_nl_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_nhom_nl = form_Fs_TEN_ID(b_vungId, 'NHOM_NL'), b_nangluc = form_Fs_TEN_ID(b_vungId, 'NANGLUC'),
    b_slideId = b_grlkeId + '_slide';
    b_so_id = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu1');
    b_ma_mnl = form_Fs_VTEN_ID('UPa_hi', 'ma_mnl');
    dgnl_dm_xd_td_nl_lkeCho = setInterval('dgnl_dm_xd_td_nl_P_LKE_CHO()', 200);

}
var b_cho_control = 0;

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("NHOM_NL") >= 0) {
            $get(b_nhom_nl).value = b_kq;
            var manhom = $get(b_ma_mnl).value;
            if (manhom != "" && manhom != b_kq)
                $get(b_nangluc).value = "";
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nhom_nl).focus();
            $get(b_ma_mnl).value = b_kq;
        } else if (b_dtuong.indexOf("NANGLUC") >= 0) {
            $get(b_nangluc).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            $get(b_nangluc).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_xd_td_nl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "NHOM_NL": b_maId = b_nhom_nl; form_P_MOI(b_vungId, "X"); break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "so_id") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "so_id", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dgnl_dm_xd_td_nl_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_xd_td_nl_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_xd_td_nl_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            //sdg.Fs_DGNL_DM_XD_TD_NL_MA(b_ma, b_TrangKt, a_cot, dgnl_dm_xd_td_nl_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_xd_td_nl_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_xd_td_nl_P_CHUYEN_HANG(); }
}

var dgnl_dm_xd_td_nl_choAct = 0;
function dgnl_dm_xd_td_nl_GR_lke_RowChange() {
    if (dgnl_dm_xd_td_nl_choAct != 0) clearTimeout(dgnl_dm_xd_td_nl_choAct);
    dgnl_dm_xd_td_nl_choAct = setTimeout("dgnl_dm_xd_td_nl_P_CHUYEN_HANG()", 300);
    return false;
}

function dgnl_dm_xd_td_nl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(dgnl_dm_xd_td_nl_lkeCho); dgnl_dm_xd_td_nl_P_LKE(); }
}

function dgnl_dm_xd_td_nl_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id1 = $get(b_so_id).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_DGNL_DM_XD_TD_NL_NH(b_TrangKt,b_so_id1, a_dt_ct, a_cot, dgnl_dm_xd_td_nl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dgnl_dm_xd_td_nl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        //$get(b_gocId).focus();
    }
    return false;
}
function dgnl_dm_xd_td_nl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_so_id).value = "0";
    return false;
}

function dgnl_dm_xd_td_nl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_ma == "") dgnl_dm_xd_td_nl_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_XD_TD_NL_XOA(b_ma, a_tso, a_cot, dgnl_dm_xd_td_nl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dgnl_dm_xd_td_nl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId); 
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dgnl_dm_xd_td_nl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_xd_td_nl_P_CHUYEN_HANG(); }
    }
}

function dgnl_dm_xd_td_nl_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id1 = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        $get(b_so_id).value = b_so_id1;
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nhom= C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nhom_nl"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            $get(b_ma_mnl).value = b_nhom;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_dm_xd_td_nl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_XD_TD_NL_LKE(a_tso, a_cot, dgnl_dm_xd_td_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_dm_xd_td_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}