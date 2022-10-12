var ns_cc_th_tts_lkeCho, b_vungId, b_so_theId, b_ten_Id, b_so_theId, b_phong_Id, b_grlkeId, b_slideId, b_nsd, b_an_namId,
    b_an_kyluongId, b_an_sotheId, b_an_phongId, b_kyluong_id, b_nam_Id, b_phong_Id, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', b_ctyValue, b_ctrbeforId;;
function ns_cc_th_tts_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_kyluong_id = form_Fs_TEN_ID(b_vungId, 'KYLUONG_ID'), b_nam_Id = form_Fs_TEN_ID(b_vungId, 'nam'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_phong_Id = form_Fs_TEN_ID(b_vungId, 'phong');
    b_an_namId = form_Fs_TEN_ID('UPa_hi', 'an_nam'), b_an_kyluongId = form_Fs_TEN_ID('UPa_hi', 'an_kyluong_id'), b_an_sotheId = form_Fs_TEN_ID('UPa_hi', 'an_so_the');
    b_an_phongId = form_Fs_TEN_ID('UPa_hi', 'an_phong');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    lke_P_DAT($get(b_phong_Id), 'TATCA' + '{' + 'Tất cả');
    ns_cc_th_tts_lkeCho = setInterval('ns_cc_th_tts_P_LKE_CHO()', 200);
}
function ns_cc_th_tts_P_NAM() {
    try {
        form_P_MOI(b_vungId, "N");
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        hts_dungchung.Fs_NS_KYLUONG_CHUNG_LKE(form_Fs_nsd(), window.name, b_nam);
    }
    catch (ex) { form_P_LOI(ex.message); }
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
// Liệt Kê
function ns_cc_th_tts_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_cc_th_tts_lkeCho != 0) clearTimeout(ns_cc_th_tts_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_th_tts_P_LKE_KYLUONG();
        //ns_cc_th_tts_P_LKE('K');
    }
}
function ns_cc_th_tts_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA(b_nam_Id), b_kyluong = lke_Fs_TRA(b_kyluong_id), b_so_the = $get(b_so_theId).value;
        stl_cc.Fs_NS_CC_TH_TTS_LKE(form_Fs_nsd(), b_nam, b_kyluong, b_so_the, b_ctyValue, a_tso, a_cot, ns_cc_th_tts_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_tts_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
// Tổng hợp
function ns_cc_th_tts_P_TONGHOP() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        if (lke_Fs_TRA($get(b_kyluong_id)) == "") { form_P_LOI("loi:Phải nhập kỳ đánh giá:loi"); return false; }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = lke_Fs_TRA($get(b_nam_Id)), b_ky_dg = lke_Fs_TRA($get(b_kyluong_id)), b_sothe = $get(b_so_theId).value;
        stl_cc.Fs_NS_CC_TH_TTS_TH(form_Fs_nsd(), b_nam, b_ky_dg, b_sothe, b_ctyValue, a_tso, a_cot, ns_cc_th_tts_P_TONGHOP_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_cc_th_tts_P_TONGHOP_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI("loi:Tổng hợp thành công!:loi")
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_cc_th_tts_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_an_namId).value = lke_Fs_TRA($get(b_nam_Id));
    $get(b_an_kyluongId).value = lke_Fs_TRA($get(b_kyluong_id));
    $get(b_an_sotheId).value = $get(b_so_theId).value;
    $get(b_an_phongId).value = lke_Fs_TRA($get(b_phong_Id));
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function vb_cctc_P_CLICK(b_event, b_id) {
    b_event.stopPropagation();
    var b_targetClassNam = b_event.target.className;
    if (b_targetClassNam == "ico_bptt") {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (b_ctrbeforId != null) b_ctrbeforId.style.fontWeight = "100";
        b_ctr.style.fontWeight = "700";
        b_ctrbeforId = b_ctr;
        b_ctyValue = a_tso[3];
        ns_cc_th_tts_P_LKE();
        return false;
    }
    else {
        var b_ctr = $get(b_id), b_div = $get(b_id + '_Div');
        var a_tso = Attribute_Fas_LAY(b_ctr, 'loai,cap,dvi,ma,ma_ct');
        if (a_tso[0] == 'A') return false;
        if (a_tso[0] != 'C') {
            if (b_div == null) vb_cctc_P_SL(b_id, a_tso[0], a_tso[1], a_tso[2], a_tso[3]);
            else {
                b_id = (C_NVL(b_div.style.display) == '') ? '' : b_id;
                vb_cctc_HIEN(a_tso[4], b_id);
            }
        }
    }
    return false;
}

function ns_cc_th_tts_P_LKE_KYLUONG() {
    try {
        var b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), window.name, b_nam, b_thang, "KYLUONG_ID", ns_cc_th_tts_P_LKE_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_th_tts_P_LKE_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
}
function form_dong() {
    location.reload(false);
}
