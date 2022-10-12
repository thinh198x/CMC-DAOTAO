var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_nhomId, b_ngay_bd_Id, b_ngay_kt_id, b_cho_control = 0, b_nsd, dg_dm_nhom_cauhoi_choAct = 0;
function dg_dm_nhom_cauhoi_P_KD() {
    b_lkeCho = setInterval('dg_dm_nhom_cauhoi_P_LKE_CHO()', 200);
} 
function dg_dm_nhom_cauhoi_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break; 
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        switch (b_maTen) {
            case "MA":
                $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
                var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
                b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
                if (b_hang < 1) { GridX_thoiA(b_grlkeId); dg_dm_nhom_cauhoi_P_MA_KTRA(); }
                else { GridX_datA(b_grlkeId, b_hang); dg_dm_nhom_cauhoi_P_CHUYEN_HANG(); } 
                break;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_nhom_cauhoi_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DG_DM_NHOM_CAUHOI_MA(b_nsd, b_ma, b_TrangKt, a_cot, dg_dm_nhom_cauhoi_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_nhom_cauhoi_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dg_dm_nhom_cauhoi_P_CHUYEN_HANG(); }
}
function dg_dm_nhom_cauhoi_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_congviec).value = "";
    $get(b_gocId).focus();
    return false;
}
function dg_dm_nhom_cauhoi_P_NH() { 
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_DG_DM_NHOM_CAUHOI_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, dg_dm_nhom_cauhoi_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dg_dm_nhom_cauhoi_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function dg_dm_nhom_cauhoi_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); dg_dm_nhom_cauhoi_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_NHOM_CAUHOI_XOA(b_nsd, b_ma, a_tso, a_cot, dg_dm_nhom_cauhoi_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_nhom_cauhoi_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_dm_nhom_cauhoi_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_dm_nhom_cauhoi_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function dg_dm_nhom_cauhoi_GR_lke_RowChange() {
    if (dg_dm_nhom_cauhoi_choAct != 0) clearTimeout(dg_dm_nhom_cauhoi_choAct);
    dg_dm_nhom_cauhoi_choAct = setTimeout("dg_dm_nhom_cauhoi_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_dm_nhom_cauhoi_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL");
        else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_nhom_cauhoi_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); 
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_congviec = form_Fs_TEN_ID(b_vungId, 'trangthai'),
        b_nsd = form_Fs_nsd();
        dg_dm_nhom_cauhoi_P_LKE();
    }
}
function dg_dm_nhom_cauhoi_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_NHOM_CAUHOI_LKE(b_nsd, a_tso, a_cot, dg_dm_nhom_cauhoi_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_nhom_cauhoi_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}  
function form_dong() {
    location.reload(false);
}