var ns_ho_gdinh_lkeCho, ns_ho_gdinh_gchuCho, b_vungId, b_grlkeId, b_slideId, b_so_the_Id, b_ten_Id, b_tinhthanh_Id, b_quanhuyen_Id, b_xaphuong_Id, b_so_idId, b_nsd, ns_ho_gdinh_choAct = 0, b_cho_control = 0, b_doi = 0;
function ns_ho_gdinh_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_qhe'),
    b_so_the_Id = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
    b_ten_Id = form_Fs_TEN_ID(b_vungId, 'ten'),
    b_tinhthanh_Id = form_Fs_TEN_ID(b_vungId, 'tinhthanh'),
    b_quanhuyen_Id = form_Fs_TEN_ID(b_vungId, 'quanhuyen'),
    b_xaphuong_Id = form_Fs_TEN_ID(b_vungId, 'xaphuong'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slide_lke_Id = $get(b_grlkeId).getAttribute('slideId');
    b_nsd = form_Fs_nsd();    
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_so_the_Id).value = a_tso[0];
            $get(b_ten_Id).value = a_tso[1];            
            ns_ho_gdinh_lkeCho = setInterval('ns_ho_gdinh_P_LKE_CHO()', 200);
        }        
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ho_gdinh_P_KTRA(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        b_mt = b_maTen;
        switch (b_maTen) {
            case "TINHTHANH": b_ma = form_Fs_TEN_GTRI(b_vungId, 'tinhthanh'); break;
            case "QUANHUYEN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'quanhuyen'); break;
        }
        if (b_maTen == "TINHTHANH") {
            //var b_tinhThanh = lke_Fs_TRA(b_maId);
            //sns_ma_ch.Fs_DM_QUANHUYEN(b_tinhThanh, "ns_ho_gdinh", ns_ho_gdinh_tt_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_quanhuyen_Id).value = '';
            var b_ktra = "ns_ma_qh,ma,ten,MA_TT," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'quanhuyen')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
            return true;
        }
        else if (b_maTen == "QUANHUYEN") {
            //var b_quanHuyen = lke_Fs_TRA(b_maId);
            //sns_ma_ch.Fs_NS_MA_XP_DR(b_quanHuyen, "ns_ho_gdinh", "NS_HO_GDINH_XP", ns_ho_gdinh_tt_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_xaphuong_Id).value = '';
            var b_ktra = "ns_ma_xp,ma,ten,MA_QH," + b_ma;
            var b_ctr = form_Fctr_TEN_DTUONG(b_vungId, 'xaphuong')
            Attribute_P_DAT(b_ctr, 'ham_list', [b_ktra]);
            return true;
        }        
    }
    catch (err) { form_P_LOI(err); return false; }
}
function ns_ho_gdinh_tt_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_ho_gdinh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grlkeId);
    return false;
}
function ns_ho_gdinh_P_NH() {    
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }       
        var a_dt = form_Faa_TEXT_ROW(b_vungId), a_dt_qhe = GridX_Fdt_cotGtri(b_grlkeId);       
        sns_tt.Fs_NS_HO_GDINH_NH(b_nsd, a_dt, a_dt_qhe, ns_ho_gdinh_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);        
    }
    catch (err) { throw (err); }
    return false;
}
function ns_ho_gdinh_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        //var a_kq = Fas_ChMang(b_kq, '#');        
        //GridX_datBang(b_grlkeId, a_kq[6]);        
        form_P_LOI("loi:Ghi thành công:loi");
    }
    return false;
}
function ns_ho_gdinh_P_XOA() {    
    try {        
        var b_so_the = $get(b_so_the_Id).value;
        sns_tt.Fs_NS_HO_GDINH_XOA(b_nsd, b_so_the, ns_ho_gdinh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ho_gdinh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_ho_gdinh_P_MOI();
        form_P_LOI("loi:Xóa thành công:loi");
    }
    return false;
}

function ns_ho_gdinh_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ho_gdinh_lkeCho); ns_ho_gdinh_P_LKE(); }
}
function ns_ho_gdinh_P_LKE() {
    try {
        var b_so_the = $get(b_so_the_Id).value, a_cot_lke_qhe = GridX_Fas_tenCot(b_grlkeId);
        sns_tt.Fs_NS_HO_GDINH_CT(b_nsd, b_so_the, a_cot_lke_qhe, ns_ho_gdinh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ho_gdinh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang2(b_grlkeId, a_kq[1]);
    slide_P_SOTRANG(b_slide_lke_Id);
}
function ns_ho_gdinh_HangLen() {
    GridX_chuyenHang(b_grlkeId, -1);
    return false;
}
function ns_ho_gdinh_HangXuong() {
    GridX_chuyenHang(b_grlkeId, 1);

    return false;
}
function ns_ho_gdinh_ChenDong(b_dk) {
    if (C_NVL(b_dk) == 'C') {
        var b_dong = GridX_Fi_hangKt(b_grlkeId);
        GridX_P_hangKt(b_grlkeId, b_dong + 1);
        GridX_chenHang(b_grlkeId);
    }
    return false;
}
function ns_ho_gdinh_CatDong() {
    GridX_boChon(b_grlkeId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}
