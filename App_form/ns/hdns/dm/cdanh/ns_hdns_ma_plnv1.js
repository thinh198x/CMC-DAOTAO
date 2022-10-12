var b_lkeCho, b_vungId, b_grlkeId, b_gr_chucDanh_Id, b_slideId, b_gocId, b_tt_Id, b_timId, b_nsd, ns_hdns_ma_plnv_choAct = 0;
function ns_hdns_ma_plnv_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_gr_chucDanh_Id = form_Fs_VUNG_ID('GR_nh'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_tt_Id = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_nsd = form_Fs_nsd();
    b_lkeCho = setInterval('ns_hdns_ma_plnv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong.indexOf("MA") >= 0) {
            ns_hdns_ma_plnv_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_plnv_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_plnv_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_HDNS_MA_PLNV_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_hdns_ma_plnv_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_plnv_P_CHUYEN_HANG(); }
}
function ns_hdns_ma_plnv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    list_P_DAT(b_tt_Id, 'A');
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_gr_chucDanh_Id);
    $get(b_gocId).focus();
    return false;
}
function ns_hdns_ma_plnv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_cot_ct = GridX_Fdt_cotGtri(b_gr_chucDanh_Id);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_HDNS_MA_PLNV_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot_ct, a_cot_lke, ns_hdns_ma_plnv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_plnv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        if (b_kq.indexOf("khong ton tai ma chuc danh") >= 0) b_kq = "loi:Không tồn tại mã chức danh:loi";
        form_P_LOI(b_kq);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_hdns_ma_plnv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }

    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_hdns_ma_plnv_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_HDNS_MA_PLNV_XOA(b_nsd, b_ma, a_tso, a_cot, ns_hdns_ma_plnv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_plnv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        if (b_kq.indexOf("DU LIEU CON") >= 0) b_kq = "loi:Bản ghi đã được sử dụng ở chức năng khác, không được xóa:loi";
        form_P_LOI(b_kq);
    }
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[0], 0);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
            ns_hdns_ma_plnv_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_hdns_ma_plnv_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_ma_plnv_GR_lke_RowChange() {
    if (ns_hdns_ma_plnv_choAct != 0) clearTimeout(ns_hdns_ma_plnv_choAct);
    ns_hdns_ma_plnv_choAct = setTimeout("ns_hdns_ma_plnv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_plnv_P_CHUYEN_HANG() {    
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") { ns_hdns_ma_plnv_P_MOI(); GridX_datA(b_grlkeId, b_hang); }
        else {
            var a_cot = GridX_Fas_tenCot(b_gr_chucDanh_Id);
            sns_ma_ch.Fs_NS_HDNS_MA_PLNV_CT(b_nsd, b_ma, a_cot, ns_hdns_ma_plnv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') ns_hdns_ma_plnv_P_MOI();
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        var b_dong = CSO_SO(a_kq[2]);
        if (b_dong < 5) b_dong = 5;
        GridX_P_hangKt(b_gr_chucDanh_Id, b_dong);
        GridX_datBang(b_gr_chucDanh_Id, a_kq[1]);
    }
}
function ns_hdns_ma_plnv_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); ns_hdns_ma_plnv_P_LKE(); }
}
function ns_hdns_ma_plnv_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_HDNS_MA_PLNV_LKE(b_nsd, a_tso, a_cot, ns_hdns_ma_plnv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_plnv_P_LAY() {
    try {
        var a_cot = ["ma_cd", "ten"];// GridX_Fas_tenCot(b_gr_chucDanh_Id);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(b_nsd, a_cot, ns_hdns_ma_plnv_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_plnv_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_dong = CSO_SO(a_kq[0]);
    if (b_dong < 5) b_dong = 5;
    GridX_P_hangKt(b_gr_chucDanh_Id, b_dong);
    GridX_datBang(b_gr_chucDanh_Id, a_kq[1]);
}
function ns_hdns_ma_plnv_CatDong() {
    GridX_boChon(b_gr_chucDanh_Id, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}