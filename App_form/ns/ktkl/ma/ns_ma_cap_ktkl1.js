var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId;
function ns_ma_cap_ktkl_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = b_grlkeId + '_slide';
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_lkeCho = setInterval('ns_ma_cap_ktkl_P_LKE_CHO()', 200);
}
function ns_ma_cap_ktkl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_CT": b_maId = form_Fs_TEN_ID(b_vungId, 'ma_ct'); break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "MA") {
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); }
            else { GridX_datA(b_grlkeId, b_hang, null, "K"); slide_P_vtri(b_slideId, b_hang); ns_ma_cap_ktkl_P_CHUYEN_HANG(); }
            form_Fctr_TEN_DTUONG(b_vungId, 'TEN').focus();
        }
        else if (b_hang < 0) form_P_LOI_DICH("Mã quản lý chưa đăng ký");
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_cap_ktkl_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus();
}
function ns_ma_cap_ktkl_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI_DICH(b_loi);
        else {
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ktkl.Fs_MA_CAP_KTKL_NH(form_Fs_nsd(), a_dt_ct, a_cot, ns_ma_cap_ktkl_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_cap_ktkl_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_ma = $get(b_gocId).value;
        GridX_datBang(b_grlkeId, b_kq);
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma);
        if (b_hang > 0) { slide_P_vtri(b_slideId, b_hang); GridX_datA(b_grlkeId, b_hang, null, "K"); }
        $get(b_gocId).focus();
    }
}
function ns_ma_cap_ktkl_P_XOA() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) { return false; }
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "ma"));
        if (b_ma == "") ns_ma_cap_ktkl_P_MOI();
        else sns_ktkl.Fs_MA_CAP_KTKL_XOA(form_Fs_nsd(), b_ma, ns_ma_cap_ktkl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_cap_ktkl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_boChon(b_grlkeId);
        if (b_hang > 1 && GridX_Fb_hangTrang(b_grlkeId, b_hang)) b_hang--;
        slide_P_vtri(b_slideId, b_hang);
        GridX_datA(b_grlkeId, b_hang, null, "K"); ns_ma_cap_ktkl_P_CHUYEN_HANG();
    }
}
function ns_ma_cap_ktkl_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_ma_cap_ktkl_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_cap_ktkl_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || GridX_Fb_hangTrang(b_grlkeId, b_hang)) form_P_MOI(b_vungId, "GXL");
    else form_P_GridX_TEXT(b_vungId, b_grlkeId);
}
function ns_ma_cap_ktkl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); GridX_taoScroll(b_grlkeId); ns_ma_cap_ktkl_P_LKE(); }
}
function ns_ma_cap_ktkl_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_ktkl.Fs_MA_CAP_KTKL_LKE(form_Fs_nsd(), a_cot, ns_ma_cap_ktkl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_ma_cap_ktkl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { GridX_datBang(b_grlkeId, b_kq); slide_P_SOTRANG(b_slideId); }
}
function form_dong() {
    location.reload(false);
}