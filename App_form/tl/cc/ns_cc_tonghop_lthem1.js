var ns_cc_tonghop_lthem_lkeCho, ns_cc_tonghop_lthem_lkecbCho, ns_cc_tonghop_lthem_choAct = 0, b_aphongId, b_akyluongId, b_so_theId, b_hotenId, cc_ma_hso_lamthem_cot_lkeCho, b_vungId, b_grlkeId, b_mt,
    b_cotngay29Id, b_cotngay30Id, b_cotngay31Id, b_ctyValue, b_ctrbeforId;
function ns_cc_tonghop_lthem_P_KD(b_tm) {
    b_tmf = b_tm, ns_cc_tonghop_lthem_lkeCho, cc_ma_hso_lamthem_cot_lkeCho, ns_cc_tonghop_lthem_lkecbCho, b_vungId = form_Fs_VUNG_ID('UPa_ct');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the_tk'), b_hotenId = form_Fs_TEN_ID(b_vungId, 'ho_ten_tk'),
        b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
    b_slideId = b_grlkeId + '_slide';
    lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
    ns_cc_tonghop_lthem_lkeCho = setInterval('ns_cc_tonghop_lthem_P_LKE_CHO()', 200);
}
function ns_cc_tonghop_lthem_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "PHONG": b_maId = b_phongId; break;
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null) return;
        if (b_maTen == "PHONG") {
            ns_cc_tonghop_lthem_P_MOI();
            ns_cc_tonghop_lthem_P_LKE();
        } else if (b_maTen == "KYLUONG") {
            var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
            $get(b_aphongId).value = b_ctyValue;
            $get(b_akyluongId).value = b_kyluong;
            ns_cc_tonghop_lthem_P_CHUYEN_HANG();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grlkeId);
}
function ns_cc_tonghop_lthem_P_LKE_CB(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), b_phong = b_ctyValue;
        stl_cc.Fs_NS_CC_TONGHOP_LTHEM_LKE_CB(form_Fs_nsd(), b_phong, a_cot, ns_cc_tonghop_lthem_P_LKE_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_P_LKE_CB_KQ(b_kq) {
    if (b_kq == "") GridX_datTrang(b_grlkeId);
    else {
        var a_kq = b_kq.split('#');
        GridX_dat_hangkt(b_grlkeId, a_kq[2]);
        if (a_kq[0] == "") GridX_datTrang(b_grmaId); else GridX_datBang(b_grmaId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grlkeId); else GridX_datBang(b_grlkeId, a_kq[1]);
        return false;
    }
}
function cc_ma_hso_lamthem_P_COT_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(cc_ma_hso_lamthem_cot_lkeCho); cc_ma_hso_lamthem_P_COT(); }
}
function cc_ma_hso_lamthem_P_COT() {
    try {
        var a_cot_ma = GridX_Fas_tenCot(b_grmaId);
        stl_cc.Fs_CC_LAMTHEM_COT(form_Fs_nsd(), a_cot_ma, cc_ma_hso_lamthem_P_COT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_tonghop_lthem_lkeCho != 0) clearTimeout(ns_cc_tonghop_lthem_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_cc_tonghop_lthem_CT_KYLUONG('K');
    }
}
function ns_cc_tonghop_lthem_CT_KYLUONG() {
    try {
        var b_form = "ns_cc_tonghop_lthem", b_nam = "DT_NAM", b_thang = "DT_KY";
        hts_dungchung.Fs_NS_CC_KY(form_Fs_nsd(), b_form, b_nam, b_thang, ns_cc_tonghop_lthem_CT_KYLUONG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_CT_KYLUONG_KQ(b_kq) {
    if (b_kq != "") {
        form_P_CH_TEXT(b_vungId, b_kq);
    }
    ns_cc_tonghop_lthem_P_LKE('K');
}
function ns_cc_tonghop_lthem_P_LKE_CB_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_tonghop_lthem_lkecbCho != 0) clearTimeout(ns_cc_tonghop_lthem_lkecbCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cc_tonghop_lthem_P_LKE_CB('K');
    }
}
function ns_cc_tonghop_lthem_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_phong = b_ctyValue, a_cot = GridX_Fas_tenCot(b_grlkeId);
        ns_cc_tonghop_lthem_P_CHUYEN_HANG();
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_cc_tonghop_lthem_GR_lke_RowChange() {
    if (ns_cc_tonghop_lthem_choAct != 0) clearTimeout(ns_cc_tonghop_lthem_choAct);
    ns_cc_tonghop_lthem_choAct = setTimeout("ns_cc_tonghop_lthem_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_tonghop_lthem_P_CHUYEN_HANG() {
    var b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_so_the = $get(b_so_theId).value, b_hoten = $get(b_hotenId).value;
    if (b_kyluong == null || b_kyluong == "") { slide_P_SOTRANG(b_slideId, 0); form_P_MOI("", "XGL"); return false }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grlkeId), b_phong = b_ctyValue, a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_cc.Fs_NS_CC_LTHEM_TONGHOP_CT(form_Fs_nsd(), b_phong, b_kyluong, b_so_the, b_hoten, a_cot_ct, a_tso, ns_cc_tonghop_lthem_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_cc_tonghop_lthem_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[0] == "")
        GridX_datTrang(b_grlkeId);
    else GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_cc_tonghop_lthem_TINH() {
    try {
        var b_phong = b_ctyValue, b_kyluong = lke_Fs_TRA($get(b_kyluongId)), b_so_the = $get(b_so_theId).value, b_hoten = $get(b_hotenId).value;
        if (b_kyluong == null || b_kyluong == "") { form_P_LOI("loi:Phải nhập kỳ tính lương:loi"); return false; }
        else {
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            stl_cc.Fs_NS_CC_TONGHOP_LTHEM_TINH(form_Fs_nsd(), b_phong, b_kyluong, b_so_the, b_hoten, a_cot, a_tso, ns_cc_tonghop_lthem_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tonghop_lthem_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    if (a_kq[0] == "") GridX_datTrang(b_grlkeId);
    else GridX_datBang(b_grlkeId, a_kq[1]);

    form_P_LOI("loi:Tổng hợp thành công:loi");
    return false;
}
function ns_cc_tonghop_lthem_P_IN() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    $get(b_aphongId).value = b_ctyValue;
    $get(b_akyluongId).value = lke_Fs_TRA($get(b_kyluongId));
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_tonghop_lthem_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        stl_cc.Fs_DANHSACH_KYLUONG_LT_LKE(form_Fs_nsd(), b_nam, ns_cc_tonghop_lthem_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_tonghop_lthem_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_tonghop_lthem_P_KTRA("KYLUONG");
    }
}
function P_EXCEL_KQ(b_kq) {
    //?md=TT
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_MO(form_Fs_TM() + '/App_form/bc/xexcel.aspx?md=TT', null, null, "C");
}
function ns_cc_tonghop_lthem_P_FILES() {
    var b_tenf = b_tmf + "/khud/khud_Excel.aspx";
    form_P_MO(b_tenf, window.name + ",FILE_CC", null);
    return false;
}
function GridX_dat_hangkt(b_gridx, sodong) {
    try {
        var b_grid = $get(b_gridx);
        b_grid.setAttribute('hangKt', '19');
        var b_hangkt = GridX_Fi_hangKt(b_gridx);
        if (sodong > b_hangkt) {
            b_grid.setAttribute('hangKt', sodong - b_hangkt + 20);
        }
        return false;
    } catch (err) { form_P_LOI(err); }
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
        ns_cc_tonghop_lthem_P_LKE('K');
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