var tl_tlap_ngaynghi_lkeCho, b_vungId, b_grlkeId, b_tm, tl_tlap_ngaynghi_ds_lkeCho, b_grctId, b_ngay_tiepnhanId, b_tinhtrangId;
function tl_tlap_ngaynghi_P_KD(b_tm) {
    tl_tlap_ngaynghi_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_ngay_thietlapId = form_Fs_TEN_ID(b_vungId, 'NGAY_THIETLAP');
    tl_tlap_ngaynghi_lkeCho = setInterval('tl_tlap_ngaynghi_P_LKE_CHO()', 200);
}


function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MA_CC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            var gtri_cu = GridX_Fas_layGtri(b_grctId, b_hang, "ma_cc");
            if (b_hang > -1) { GridX_datGtri(b_grctId, b_hang, "ma_cc", b_kq); $get(b_gchuId).innerHTML = a_tso[1]; }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function tl_tlap_ngaynghi_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "CDANH": b_maId = b_gocId; break;
    }
    if (b_maTen == "CDANH") { tl_tlap_ngaynghi_P_LKE(); }
}

function tl_tlap_ngaynghi_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(tl_tlap_ngaynghi_lkeCho); tl_tlap_ngaynghi_P_LKE(); }
}
function tl_tlap_ngaynghi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        stl_ma.Fs_NS_TL_TLAP_NGHI_NAM_LKE(a_cot, tl_tlap_ngaynghi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_tlap_ngaynghi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}

function tl_tlap_ngaynghi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    $get(b_ngay_thietlapId).focus();
    return false;
}


function tl_tlap_ngaynghi_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        stl_ma.Fs_NS_TL_TLAP_NGHI_NAM_NH(a_dt, b_dt_ct, a_cot_lke, tl_tlap_ngaynghi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function tl_tlap_ngaynghi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grlkeId, b_kq);
        var b_ngay_thietlap = $get(b_ngay_thietlapId).value;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay_thietlap", b_ngay_thietlap);
        form_P_LOI("Nhập thành công");
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        else return false;
    }
    return false;
}

var tl_tlap_ngaynghi_choAct = 0;
function tl_tlap_ngaynghi_GR_lke_RowChange() {
    if (tl_tlap_ngaynghi_choAct != 0) clearTimeout(tl_tlap_ngaynghi_choAct);
    tl_tlap_ngaynghi_choAct = setTimeout("tl_tlap_ngaynghi_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_tlap_ngaynghi_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_ngay_thietlap = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_thietlap"));
    $get(b_ngay_thietlapId).value = b_ngay_thietlap;
    stl_ma.Fs_NS_TL_TLAP_NGHI_NAM_CT(b_ngay_thietlap, a_cot_ct, tl_tlap_ngaynghi_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function tl_tlap_ngaynghi_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}

function tl_tlap_ngaynghi_P_XOA() {
    try {
        var r = confirm("Bạn có chắc chắn xóa không?");
        if (r == false) {
            return false;
        }
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        else {
            var b_ngay_thietlap = $get(b_ngay_thietlapId).value;
            var a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_NS_TL_TLAP_NGHI_NAM_XOA(b_ngay_thietlap,a_cot, tl_tlap_ngaynghi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function tl_tlap_ngaynghi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        GridX_datBang(b_grlkeId, a_kq[0]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_tlap_ngaynghi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_tlap_ngaynghi_P_CHUYEN_HANG(); }
    }
}
function form_dong() {
    location.reload(false);
}