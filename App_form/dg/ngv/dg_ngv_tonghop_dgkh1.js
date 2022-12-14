var dg_ngv_tonghop_dgkh_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_donviId, b_donvi_tkId, b_nam_tkId, b_lngId, dg_ngv_tonghop_dgkh_choAct, b_nhom_cdanhId, b_cdanhId, b_capbacId
b_choAct = 0, b_fcho = 'C';
function dg_ngv_tonghop_dgkh_P_KD() { 
    dg_ngv_tonghop_dgkh_lkeCho = setInterval('dg_ngv_tonghop_dgkh_P_LKE_CHO()', 200);
}
function dg_ngv_tonghop_dgkh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KY_DG": b_maId = b_ky_dgId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "KY_DG") {
            dg_ngv_tonghop_dgkh_P_LKE()
        }
    }
    catch (err) { form_P_LOI(err); }
} 
// Tổng hợp  
function dg_ngv_tonghop_dgkh_P_NH() {
    try {
        var b_nam = lke_Fs_TRA($get(b_namId));
        var b_ky_dg = lke_Fs_TRA($get(b_ky_dgId));
        if (b_ky_dg == "") { form_P_LOI("loi:Phải chọn kỳ đánh giá để tổng hợp:loi"); return false }
        else {
            var a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DG_NGV_TONGHOP_DGKH_NH(form_Fs_nsd(), b_nam, b_ky_dg, a_tso, a_cot_lke, dg_ngv_tonghop_dgkh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_ngv_tonghop_dgkh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        b_result = CSO_SO(b_kq);
        if (b_result = 0) {
            form_P_LOI("loi:Không có dữ liệu:loi");
        }
        else {
            form_P_LOI("loi:Tổng hợp thành công:loi");
            dg_ngv_tonghop_dgkh_P_LKE_CHO();
        }
    }
    b_fcho = 'X';
}
// Chuyển hàng 
function dg_ngv_tonghop_dgkh_GR_lke_RowChange() {
    if (dg_ngv_tonghop_dgkh_choAct != 0) clearTimeout(dg_ngv_tonghop_dgkh_choAct);
    dg_ngv_tonghop_dgkh_choAct = setTimeout("dg_ngv_tonghop_dgkh_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_ngv_tonghop_dgkh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_sothe = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the"));
    var b_kydg = lke_Fs_TRA($get(b_ky_dgId));
    if (b_sothe == "0" || b_sothe == "") { form_P_MOI(b_vungId, "XL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_NGV_TONGHOP_DGKH_CT(form_Fs_nsd(), b_sothe, b_kydg, a_cot_ct, dg_ngv_tonghop_dgkh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_ngv_tonghop_dgkh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "XL");
        // drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}

// Liệt kê
function dg_ngv_tonghop_dgkh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_ngv_tonghop_dgkh_lkeCho != 0) clearTimeout(dg_ngv_tonghop_dgkh_lkeCho);
        dg_ngv_tonghop_dgkh_lkeCho, dg_ngv_tonghop_dgkh_choAct = 0,
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_ngv_tonghop_dgkh_P_LKE('K');
    } 
}
function dg_ngv_tonghop_dgkh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_kydg = lke_Fs_TRA($get(b_ky_dgId)); 
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_NGV_TONGHOP_DGKH_LKE(form_Fs_nsd(),b_kydg, a_tso, a_cot, dg_ngv_tonghop_dgkh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_tonghop_dgkh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); 
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//lấy kỳ đánh giá theo năm
function dg_ngv_tonghop_dgkh_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        sdg.Fdt_NS_DG_MA_KDG_DGKH(b_nam, dg_ngv_tonghop_dgkh_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_ngv_tonghop_dgkh_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    } 
}
function form_dong() {
    location.reload(false);
}