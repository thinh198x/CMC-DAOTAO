
var ns_tlap_email_lkeCho, b_vungId, b_grlkeId, b_slideId, b_tbao_hethopdongId;
function ns_tlap_email_P_KD() {
    ns_tlap_email_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_emailId = form_Fs_TEN_ID(b_vungId, 'EMAIL');
    b_matkhauId = form_Fs_TEN_ID(b_vungId, 'MATKHAU');
    b_smtpId = form_Fs_TEN_ID(b_vungId, 'SMTP');
    b_portId = form_Fs_TEN_ID(b_vungId, 'PORT');
    b_sslId = form_Fs_TEN_ID(b_vungId, 'SSL');
    ns_tlap_email_lkeCho = setInterval('ns_tlap_email_P_LKE_CHO()', 200);
}

var ns_tlap_email_choAct = 0;
function ns_tlap_email_GR_lke_RowChange() {
    if (ns_tlap_email_choAct != 0) clearTimeout(ns_tlap_email_choAct);
    ns_tlap_email_choAct = setTimeout("ns_tlap_email_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_tlap_email_P_LKE_CHO() {
    clearTimeout(ns_tlap_email_lkeCho); ns_tlap_email_P_CHUYEN_HANG();
}

function ns_tlap_email_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_tbao_hethopdongId).focus();
    return false;
}

function ns_tlap_email_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    sns_ma_ch.Fs_NS_TLAP_EMAIL_NH(a_dt_ct, ns_tlap_email_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tlap_email_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
function ns_tlap_email_P_XOA() {
    sns_ma_ch.Fs_NS_TLAP_EMAIL_XOA(ns_tlap_email_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tlap_email_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_tlap_email_MOI();
        form_P_LOI("loi:Xóa thành công:loi");
        return false;
    }
}

function ns_tlap_email_P_CHUYEN_HANG() {
    try {
        sns_ma_ch.Fs_NS_TLAP_EMAIL_CT(ns_tlap_email_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tlap_email_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}


function ns_tlap_email_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_TLAP_EMAIL_LKE(a_tso, a_cot, ns_tlap_email_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tlap_email_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_tlap_email_P_TEST() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        sns_ma_ch.Fs_NS_TLAP_EMAIL_TEST(a_dt_ct, ns_tlap_email_P_TEST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tlap_email_P_TEST_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI("loi:Email không khả thi, vui lòng thử lại hoặc chọn email khác!:loi"); return; }
    else form_P_LOI("loi:Email khả thi, có thể sử dụng thông số thiết lập này, vui lòng nhấn 'Nhập' để lưu lại thông tin!:loi");
}
function form_dong() {
    location.reload(false);
}