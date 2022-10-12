var ns_ds_den_lkeCho, b_vungId, b_so_theId, b_ten_Id, b_phong_Id, b_grlkeId, b_slideId, b_ma_phong_Id, b_nsd, b_ctyValue, b_ctrbeforId;
function ns_ds_den_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_so_the_Id = form_Fs_TEN_ID(b_vungId, 'so_the'),
    b_ten_Id = form_Fs_TEN_ID(b_vungId, 'hoten'), b_phong_Id = form_Fs_TEN_ID(b_vungId, 'dr_phongban'),   
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_ma_phong_Id = form_Fs_VTEN_ID('UPa_hi', 'ma_phong');
    b_nsd = form_Fs_nsd();
    ns_ds_den_lkeCho = setInterval('ns_ds_den_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("DAYPHONG") >= 0) {
            var b_phong_tk = form_Fctr_TEN_DTUONG(b_vungId, 'dr_phongban');
            lke_P_DAT(b_phong_tk, a_tso[0] + "{" + a_tso[1]);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ds_den_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_ds_den_lkeCho != 0) clearTimeout(ns_ds_den_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        form_F_GOC().P_MENUBf(window.name, 'M');
        vb_cctc_P_SL('', 'D', '0', ' ', ' ', 'T');
        b_ctyValue = "TATCA";
        ns_ds_den_P_LKE('K');
    } 
}
function ns_ds_den_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_the = C_NVL($get(b_so_the_Id).value), b_ten = C_NVL($get(b_ten_Id).value), b_phong = lke_Fs_TRA(b_phong_Id);
        sns_qt.Fs_NS_DS_DEN_LKE(b_nsd, a_tso, a_cot, b_so_the, b_ten, b_ctyValue, ns_ds_den_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ds_den_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    
}
function ns_ds_den_P_Phong() {
    try {
        var b_tenf = form_Fs_TM() + '/App_form/ht/ns_hs_cctc_quyen.aspx';
        form_P_MO(b_tenf, null, [window.name, [""]]);
        return false;
    }
    catch (err) { }
}
function ns_ds_den_P_Excel() {
    $get(b_ma_phong_Id).value = lke_Fs_TRA(b_phong_Id);
    var b_btn_excel = form_Fs_VTEN_ID('', 'excel_an');
    $get(b_btn_excel).click();
    form_chay = 0;
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
        ns_ds_den_P_LKE('K'); return false;
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
