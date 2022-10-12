var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId;
function ht_macvu_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_lkeCho = setInterval('ht_macvu_P_LKE_CHO()', 200);
}
function ht_macvu_P_KTRA(b_maTen) {
    try {
        var b_ma = form_Fctr_TEN_DTUONG(b_vungId, b_maTen);
        b_maTen = b_maTen.toUpperCase();
        if (C_NVL(b_ma.value) == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "MA") {
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
            else { GridX_datA(b_grlkeId, b_hang,null,"K"); slide_P_vtri(b_slideId, b_hang); ht_macvu_P_CHUYEN_HANG(); }
            form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
        }
        else if (b_hang < 0) form_P_LOI_DICH("Mã quản lý chưa đăng ký");
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macvu_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
}
function ht_macvu_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI_DICH(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            sht_ma.Fs_MA_CVU_NH(form_Fs_nsd(),a_dt, ht_macvu_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macvu_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        a_dt[1] = kytu_locUnicode(a_dt[1]);
        GridX_datGtriT(b_grlkeId, "ma", a_dt);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_vtri(b_slideId, b_hang);
        $get(b_gocId).focus();
    }
}
function ht_macvu_P_XOA() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ht_macvu_P_MOI();
        else sht_ma.Fs_MA_CVU_XOA(form_Fs_nsd(),b_ma, ht_macvu_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macvu_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        slide_P_vtri(b_slideId, b_hang);
        GridX_datA(b_grlkeId, b_hang,null,"K"); ht_macvu_P_CHUYEN_HANG();
    }
}
function ht_macvu_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ht_macvu_P_CHUYEN_HANG()", 300);
    return false;
}
function ht_macvu_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    else form_P_GridX_TEXT(b_vungId, b_grlkeId);
}
function ht_macvu_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); GridX_taoScroll(b_grlkeId); ht_macvu_P_LKE(); }
}
function ht_macvu_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sht_ma.Fs_MA_CVU_LKE(form_Fs_nsd(),a_cot, ht_macvu_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ht_macvu_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId);}
}
