var hd_ma_loai_nv_lkeCho, b_vungId, b_grlkeId, b_grnhId, b_slideId, b_gocId, b_capId, hd_ma_loai_nv_choAct = 0;
function hd_ma_loai_nv_P_KD() {
    hd_ma_loai_nv_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grnhId = form_Fs_VUNG_ID('GR_nh');
    b_so_id = form_Fs_TEN_ID(b_vungId, 'so_id');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'ten');
    b_capId = form_Fs_TEN_ID(b_vungId, 'CAP');
    b_slideId = b_grlkeId + '_slide';
    hd_ma_loai_nv_lkeCho = setInterval('hd_ma_loai_nv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            ns_hdns_gan_cdanhdvi_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_loai_nv_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_hd_ma_loai_nv_MA(b_ma, b_TrangKt, a_cot, hd_ma_loai_nv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_loai_nv_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); hd_ma_loai_nv_P_CHUYEN_HANG(); }
}
function hd_ma_loai_nv_GR_lke_RowChange() {
    if (hd_ma_loai_nv_choAct != 0) clearTimeout(hd_ma_loai_nv_choAct);
    hd_ma_loai_nv_choAct = setTimeout("hd_ma_loai_nv_P_CHUYEN_HANG()", 300);
    return false;
}
function hd_ma_loai_nv_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(hd_ma_loai_nv_lkeCho); hd_ma_loai_nv_P_LKE(); }
}
function hd_ma_loai_nv_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.FS_HD_MA_LOAI_NV_LKE(a_tso, a_cot, hd_ma_loai_nv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_loai_nv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq.length > 2) {
        GridX_datBang(b_grlkeId, a_kq[2]);
    }
    else 
    GridX_datBang(b_grlkeId, a_kq[1]);
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    var a_cot = GridX_Fas_tenCot(b_grnhId);
    //sns_hdns.FS_NS_MA_CDANH_LKE_ALL(a_cot, hd_ma_loai_nv_P_LKE_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function hd_ma_loai_nv_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    //GridX_datBang(b_grnhId, b_kq);
}
function hd_ma_loai_nv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
    var a_cot_ct = GridX_Fdt_cotGtri(b_grnhId);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
    var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var a_tso = slide_Faobj_TUDEN(b_slideId);
    sns_hdns.FS_HD_MA_LOAI_NV_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_ct, a_cot_lke, a_tso, hd_ma_loai_nv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function hd_ma_loai_nv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function hd_ma_loai_nv_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thayGtriT(b_grnhId, "chon", "");
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0) { GridX_thoiA(b_grlkeId); }
    $get(b_gocId).focus();
    return false;
}
function hd_ma_loai_nv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (so_id == "") hd_ma_loai_nv_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.FS_HD_MA_LOAI_NV_XOA(so_id, a_tso, a_cot, hd_ma_loai_nv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function hd_ma_loai_nv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) hd_ma_loai_nv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); hd_ma_loai_nv_P_CHUYEN_HANG(); }
    }
}
function hd_ma_loai_nv_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { hd_ma_loai_nv_P_MOI(); }
        else {
            var a_cot = GridX_Fas_tenCot(b_grnhId);
            sns_hdns.FS_HD_MA_LOAI_NV_CT(b_so_id, a_cot, hd_ma_loai_nv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function hd_ma_loai_nv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') hd_ma_loai_nv_P_MOI();
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        GridX_datBang(b_grnhId, a_kq[1]);
    }
}
function hd_ma_loai_nv_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_hdns_gan_cdanhdvi_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grnhId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_hdns_gan_cdanhdvi_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_gan_cdanhdvi_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grnhId, a_kq[1]);
}