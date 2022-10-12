
var ns_tbao_menu_tlap_lkeCho, b_vungId, b_grlkeId, b_slideId, b_tbao_hethopdongId;
function ns_tbao_menu_tlap_P_KD() {
    ns_tbao_menu_tlap_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_tbao_hethopdongId = form_Fs_TEN_ID(b_vungId, 'tbao_hethopdong');
    ns_tbao_menu_tlap_lkeCho = setInterval('ns_tbao_menu_tlap_P_LKE_CHO()', 200);
}

var ns_tbao_menu_tlap_choAct = 0;
function ns_tbao_menu_tlap_GR_lke_RowChange() {
    if (ns_tbao_menu_tlap_choAct != 0) clearTimeout(ns_tbao_menu_tlap_choAct);
    ns_tbao_menu_tlap_choAct = setTimeout("ns_tbao_menu_tlap_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_tbao_menu_tlap_P_LKE_CHO() {
    clearTimeout(ns_tbao_menu_tlap_lkeCho); ns_tbao_menu_tlap_P_CHUYEN_HANG();
}
function ns_tbao_menu_tlap_MOI()
    {
    form_P_MOI(b_vungId, "GXL");
    $get(b_tbao_hethopdongId).focus();
    return false;
    }

function ns_tbao_menu_tlap_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
    sns_ma_ch.Fs_NS_TBAO_MENU_TLAP_NH(a_dt_ct, ns_tbao_menu_tlap_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tbao_menu_tlap_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}
function ns_tbao_menu_tlap_P_XOA() {
    sns_ma_ch.Fs_ns_tbao_menu_tlap_XOA(ns_tbao_menu_tlap_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tbao_menu_tlap_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_tbao_menu_tlap_MOI();
        form_P_LOI("loi:Xóa thành công:loi");
        return false;
    }
}

function ns_tbao_menu_tlap_P_CHUYEN_HANG() {
    try {
        sns_ma_ch.Fs_NS_TBAO_MENU_TLAP_CT(ns_tbao_menu_tlap_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tbao_menu_tlap_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    form_P_CH_TEXT(b_vungId, b_kq);
}


function ns_tbao_menu_tlap_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_ns_tbao_menu_tlap_LKE(a_tso, a_cot, ns_tbao_menu_tlap_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tbao_menu_tlap_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]); 
}
function form_dong() {
    location.reload(false);
}