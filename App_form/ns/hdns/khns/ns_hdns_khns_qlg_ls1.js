var b_cho, b_lkeCho, b_choAct, b_vungId, b_grctId, b_slide_ct_Id, b_nam_Id, b_phong_Id, b_thang_d_Id, b_thang_c_Id, b_nsd;
function ns_hdns_khns_qlg_ls_P_KD() {
    b_lkeCho = setInterval('ns_hdns_khns_qlg_ls_P_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            var b_nam = a_tso[1], b_phong = a_tso[2], b_ten_phong = a_tso[3];
            b_cho = setInterval('P_CHO(' + b_nam + ',"' + b_phong + '", "' + b_ten_phong + '")', 300);            
        }        
    }
    catch (err) { form_P_LOI(err); }
}
function P_CHO(b_nam, b_phong, b_ten_phong) {
    clearTimeout(b_cho);
    if (b_nam != '')
        lke_P_IdDAT(b_nam_Id, b_nam + "{" + b_nam);
    if (b_phong != '') {
        lke_P_IdDAT(b_phong_Id, b_phong + "{" + b_ten_phong);
    }
    if (b_nam != '' && b_phong != '') {
        ns_hdns_khns_qlg_ls_P_LKE();
    }
}
function ns_hdns_khns_qlg_ls_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_nam_Id; break;
            case "PHONG": b_maId = b_phong_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;
        switch (b_maTen) {
            case "NAM":
            case "PHONG":
                var b_nam = lke_Fs_TRA(b_nam_Id), b_phong = lke_Fs_TRA(b_phong_Id);
                if (b_nam == "" || b_phong == "") {
                    ns_hdns_khns_qlg_ls_P_MOI();
                    return;
                }
                else {
                    ns_hdns_khns_qlg_ls_P_LKE();
                }
                break;
            default: break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_ls_P_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_nam_Id = form_Fs_TEN_ID(b_vungId, 'NAM'),
        b_phong_Id = form_Fs_TEN_ID(b_vungId, 'PHONG'),
        //b_thang_d_Id = form_Fs_TEN_ID(b_vungId, 'thang_d'),
        //b_thang_c_Id = form_Fs_TEN_ID(b_vungId, 'thang_c');       
        b_slide_ct_Id = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slide_ct_Id);
        b_nsd = form_Fs_nsd();        
    }
}
function ns_hdns_khns_qlg_ls_P_MOI() {
    form_P_MOI(b_vungId, "X");
    GridX_datTrang(b_grctId);
    slide_P_SOTRANG(b_slide_ct_Id);    
    return false;
}
function ns_hdns_khns_qlg_ls_P_LKE() {
    try {
        var b_nam = CSO_SO(lke_Fs_TRA(b_nam_Id)), b_phong = lke_Fs_TRA(b_phong_Id), a_cot = GridX_Fas_tenCot(b_grctId);
        sns_hdns.Fs_NS_HDNS_KHNS_QLG_LS_CT(b_nsd, b_nam, b_phong, a_cot, ns_hdns_khns_qlg_ls_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_khns_qlg_ls_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slide_ct_Id);
}