var ns_cc_nghibu_lkeCho, b_aphongId, b_vungId, b_akyluongId, b_anamId, b_grlkeId, b_grctId, b_mt, b_namId, b_ctyValue, b_ctrbeforId;
function ns_cc_nghibu_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct');
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG'), b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'),
        b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong'); b_anamId = form_Fs_TEN_ID('UPa_hi', 'anam');
    lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả'); 
    ns_cc_nghibu_lkeCho = setInterval('ns_cc_nghibu_P_LKE_CHO()', 200);
}
function ns_cc_nghibu_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "NAM": b_maId = b_namId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = b_kyluong;
            $get(b_anamId).value = $get(b_namId).value;
            ns_cc_nghibu_P_LKE();
        }
        else if (b_maTen == "NAM") { form_P_MOI(b_vungId, "G"); var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'); hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam); }
        else if (b_maTen == "KYLUONG") {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = b_kyluong;
            $get(b_anamId).value = $get(b_namId).value;
            ns_cc_nghibu_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghibu_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_nghibu_lkeCho != 0) clearTimeout(ns_cc_nghibu_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_nghibu_P_CT_KYLUONG();
    } 
}
function ns_cc_nghibu_P_CT_KYLUONG() {
    try {
        var b_form = "ns_cc_nghibu", b_nam = "DT_NAM", b_thang = "DT_KYLUONG";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_nghibu_P_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghibu_P_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    ns_cc_nghibu_P_KTRA("KYLUONG");
}
function ns_cc_nghibu_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId); 
    ns_cc_nghibu_P_LKE_CB();
}
function ns_cc_nghibu_P_LKE() {
    try {
        var b_phong = b_ctyValue, b_nam = $get(b_namId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        if (b_kyluong == "") {
            slide_P_SOTRANG(b_slideId, 0);
            return false;
        }
        stl_phep.Fs_NS_CC_NGHIBU_LKE(b_phong, b_nam, b_kyluong, a_tso, a_cot, ns_cc_nghibu_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghibu_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_cc_nghibu_TINH() {
    try {
        var b_phong = b_ctyValue,
        b_nam = $get(b_namId).value,
        b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        if (b_kyluong == null || b_kyluong == "") { form_P_LOI("loi:Chưa chọn kỳ tính:loi"); return false; }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            stl_phep.Fs_NS_CC_NGHIBU_TINH(b_phong, b_nam, b_kyluong, a_cot, a_tso, ns_cc_nghibu_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_nghibu_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    form_P_LOI("loi:Tổng hợp thành công:loi");
    return false;
}
function ns_cc_nghibu_P_IN() {
    __doPostBack('ctl00$ContentPlaceHolder1$Xuat2', '');
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
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        $get(b_aphongId).value = b_ctyValue;
        $get(b_akyluongId).value = b_kyluong;
        $get(b_anamId).value = $get(b_namId).value;
        ns_cc_nghibu_P_LKE();
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
function form_dong() {
    location.reload(false);
}