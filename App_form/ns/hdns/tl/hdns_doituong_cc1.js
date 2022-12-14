var HDNS_DOITUONG_CC_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ncdanhId;
function HDNS_DOITUONG_CC_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
    b_mien_giochuanId = form_Fs_TEN_ID(b_vungId, 'mien_giochuan');
    b_mien_tdId = form_Fs_TEN_ID(b_vungId, 'mien_td');
    b_mien_dmvsId = form_Fs_TEN_ID(b_vungId, 'mien_dmvs');
    b_mien_onsiteId = form_Fs_TEN_ID(b_vungId, 'mien_onsite');
    b_cdanh = form_Fs_TEN_ID(b_vungId, 'cdanh');
    b_slideId = b_grlkeId + '_slide';
    HDNS_DOITUONG_CC_lkeCho = setInterval('HDNS_DOITUONG_CC_P_LKE_CHO()', 200);
    Checkanhienngayhieuluc();
}

var HDNS_DOITUONG_CC_choAct = 0;
function hdns_doituong_cc_GR_lke_RowChange() {
    if (HDNS_DOITUONG_CC_choAct != 0) clearTimeout(HDNS_DOITUONG_CC_choAct);
    HDNS_DOITUONG_CC_choAct = setTimeout("HDNS_DOITUONG_CC_P_CHUYEN_HANG()", 300);
    return false;
}

function HDNS_DOITUONG_CC_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(HDNS_DOITUONG_CC_lkeCho); HDNS_DOITUONG_CC_P_LKE(); }
}
function HDNS_DOITUONG_CC_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    if (C_NVL(form_Fs_TEN_GTRI(b_vungId, 'cdanh')) == 'TATCA') { form_P_LOI("loi:Vui lòng chọn cấp bậc vị trí:loi"); return false; }
    else {
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_hdns.Fs_HDNS_DOITUONG_CC_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, HDNS_DOITUONG_CC_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function HDNS_DOITUONG_CC_P_NH_KQ(b_kq) {
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
function HDNS_DOITUONG_CC_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    var b_mien_giochuan = form_Fctr_TEN_DTUONG(b_vungId, 'mien_giochuan'),
    b_mien_tdId = form_Fctr_TEN_DTUONG(b_vungId, 'mien_td'),
    b_mien_dmvsId = form_Fctr_TEN_DTUONG(b_vungId, 'mien_dmvs'),
    b_mien_onsiteId = form_Fctr_TEN_DTUONG(b_vungId, 'mien_onsite'),
    b_dr_cdanh = form_Fctr_TEN_DTUONG(b_vungId, 'cdanh');
    b_mien_giochuan.value = 'K';
    b_mien_tdId.value = 'K';
    b_mien_dmvsId.value = 'K';
    b_mien_onsiteId.value = 'K';
    b_dr_cdanh.value = 'TATCA';
    GridX_thoiA(b_grlkeId);
    return false;
}

function HDNS_DOITUONG_CC_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
        Checkanhienngayhieuluc();
    }
    catch (err) { form_P_LOI(err); }
}

function HDNS_DOITUONG_CC_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_HDNS_DOITUONG_CC_LKE(form_Fs_nsd(), a_cot, a_tso, HDNS_DOITUONG_CC_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function HDNS_DOITUONG_CC_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}
function anhienngayhieuluc(b_ngay) {
    var b_ngay = b_ngay.toUpperCase();
    switch (b_ngay) {
        case 'NGAY_HL_DMVS':
            var ngay_hl_msom = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_dmvs');
            if ($get(b_mien_dmvsId).value == 'C')
                ngay_hl_msom.disabled = false;
            else {
                ngay_hl_msom.disabled = true;
                ngay_hl_msom.value = "";
            }
            break;
        case 'NGAY_HL_TD':
            var ngay_hl_mientdoi = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_td');
            if ($get(b_mien_tdId).value == 'C')
                ngay_hl_mientdoi.disabled = false;
            else {
                ngay_hl_mientdoi.disabled = true;
                ngay_hl_mientdoi.value = "";
            }
            break;
        case 'NGAY_HL_ONSITE':
            var ngay_hl_onsite = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_onsite');
            if ($get(b_mien_onsiteId).value == 'C')
                ngay_hl_onsite.disabled = false;
            else {
                ngay_hl_onsite.disabled = true;
                ngay_hl_onsite.value = "";
            }
            break;
        default:
            var b_ngay_hl = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl');
            if ($get(b_mien_giochuanId).value == 'C')
                b_ngay_hl.disabled = false;
            else {
                b_ngay_hl.disabled = true;
                b_ngay_hl.value = "";
            }
    }
}
function Checkanhienngayhieuluc() {

    var ngay_hl_msom = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_dmvs');
    if ($get(b_mien_dmvsId).value == 'C')
        ngay_hl_msom.disabled = false;
    else {
        ngay_hl_msom.disabled = true;
        ngay_hl_msom.value = "";
    }

    var ngay_hl_mientdoi = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_td');
    if ($get(b_mien_tdId).value == 'C')
        ngay_hl_mientdoi.disabled = false;
    else {
        ngay_hl_mientdoi.disabled = true;
        ngay_hl_mientdoi.value = "";
    }

    var ngay_hl_onsite = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl_onsite');
    if ($get(b_mien_onsiteId).value == 'C')
        ngay_hl_onsite.disabled = false;
    else {
        ngay_hl_onsite.disabled = true;
        ngay_hl_onsite.value = "";
    }

    var b_ngay_hl = form_Fctr_TEN_DTUONG(b_vungId, 'ngay_hl');
    if ($get(b_mien_giochuanId).value == 'C')
        b_ngay_hl.disabled = false;
    else {
        b_ngay_hl.disabled = true;
        b_ngay_hl.value = "";
    }

}