var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_tt = '', b_nhom_cdanhId, b_ten_nhom_cdanhId;

function P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_tk'), b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'NHOM_CDANH'), b_ten_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'TEN_NHOM_CDANH'),
        b_lkeCho = setTimeout('P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "")
            return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NHOM_CDANH") >= 0) {
            $get(b_nhom_cdanhId).value = b_kq;
            $get(b_ten_nhom_cdanhId).value = a_tso[1];
        }
    }
    catch (err) {
        form_P_LOI(err);
    } 
}

function P_LKE_CHO() {
    try {
        if (document.readyState === 'complete') {
            clearTimeout(b_lkeCho);
            b_vungId = form_Fs_VUNG_ID('UPa_tk');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
            b_ma_cchn = form_Fs_TEN_ID(b_vungId, 'MA_CCHN');
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            slide_P_MOI(b_slideId);
            P_LKE();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_LKE(a_tso, a_cot, b_tt, P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function P_LKE_KQ(b_kq) {
    try {

        if (Fb_LOI_KTRA(b_kq)) {
            form_P_LOI(b_kq);
            return;
        }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    catch (err) {
        form_P_LOI(err);
    }
}


function P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_HIEU_BT3_LKE(form_Fs_nsd(), a_tso, a_cot, P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}



function form_dong() {
    location.reload(false);
}