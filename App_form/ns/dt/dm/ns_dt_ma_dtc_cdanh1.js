var ns_dt_ma_dtc_cdanh_lkeCho = 0, ns_dt_ma_dtc_cdanh_choAct = 0, b_vungId, b_grlkeId, b_grctId, b_gchuId, b_slideId, b_gocId, b_nsd,
    b_kdtId, b_cdanhId, b_motaId, b_nhom_nlucId, b_nlucId, b_muc_nlucId, b_grcdanhId, b_trangthaiId, b_slidecdanhId, b_slidectId;
function ns_dt_ma_dtc_cdanh_P_KD() {
    ns_dt_ma_dtc_cdanh_lkeCho = setInterval('ns_dt_ma_dtc_cdanh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("NLUC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, "nluc", a_tso[7]);
            GridX_datGtri(b_grctId, b_hang, "ten_nluc", a_tso[1]);
            GridX_datGtri(b_grctId, b_hang, "nhom_nluc", a_tso[5]);
            GridX_datGtri(b_grctId, b_hang, "ten_muc_nluc", a_tso[2]);
            GridX_datGtri(b_grctId, b_hang, "muc_nluc", a_tso[8]);
            slide_P_SOTRANG(b_slidectId);
        }
        else if (b_dtuong.indexOf("MA_CD") >= 0) {
            ns_dt_ma_dtc_cdanh_P_TRA_CDANH();
            slide_P_SOTRANG(b_slidecdanhId);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtc_cdanh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "GX");
    $get(b_kdtaoId).focus();
}
function ns_dt_ma_dtc_cdanh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grctId);
    GridX_datTrang(b_grcdanhId);
    list_P_DAT(b_trangthaiId, 'A');
    $get(b_gocId).focus();
    return false;
}
function ns_dt_ma_dtc_cdanh_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var b_soid = C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id"));
            var a_dt = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_cdanh = GridX_Fdt_cotGtri(b_grcdanhId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_dt.Fs_NS_DT_MA_DTC_CDANH_NH(form_Fs_nsd(), CSO_SO(b_soid, 0), a_dt, b_TrangKt, a_cot_ct, a_cot_cdanh, a_cot_lke, ns_dt_ma_dtc_cdanh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_dtc_cdanh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).value = a_kq[4];
        $get(b_kdtId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_dtc_cdanh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "" || b_so_id == 0) ns_dt_ma_dtc_cdanh_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_DTC_CDANH_XOA(b_so_id, a_tso, a_cot, ns_dt_ma_dtc_cdanh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_dtc_cdanh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_dtc_cdanh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_dtc_cdanh_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_dt_ma_dtc_cdanh_GR_lke_RowChange() {
    if (ns_dt_ma_dtc_cdanh_choAct != 0) clearTimeout(ns_dt_ma_dtc_cdanh_choAct);
    ns_dt_ma_dtc_cdanh_choAct = setTimeout("ns_dt_ma_dtc_cdanh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_dtc_cdanh_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_soid = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_soid == "") {
        form_P_MOI(b_vungId, "GXL");
        GridX_datTrang(b_grctId);
        GridX_datTrang(b_grcdanhId);
        list_P_DAT(b_trangthaiId, 'A');
        $get(b_gocId).focus();
    }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        var a_cot_cdanh = GridX_Fas_tenCot(b_grcdanhId);
        sns_dt.Fs_NS_DT_MA_DTC_CDANH_CT(window.name, b_soid, a_cot_ct, a_cot_cdanh, ns_dt_ma_dtc_cdanh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_ma_dtc_cdanh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grctId, a_kq[1]);
    GridX_datBang(b_grcdanhId, a_kq[2]);
    slide_P_SOTRANG(b_slidecdanhId);
    slide_P_SOTRANG(b_slidectId);
}
function ns_dt_ma_dtc_cdanh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_grctId = form_Fs_VUNG_ID('GR_ct');
        b_grcdanhId = form_Fs_VUNG_ID('GR_cdanh');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_id');
        b_kdtId = form_Fs_TEN_ID(b_vungId, 'KDT');
        b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
        b_motaId = form_Fs_TEN_ID(b_vungId, 'mota');
        b_nsd = form_Fs_nsd();
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slidectId = $get(b_grctId).getAttribute('slideId'); slide_P_MOI(b_slidectId);
        b_slidecdanhId = $get(b_grcdanhId).getAttribute('slideId'); slide_P_MOI(b_slidecdanhId);
        clearTimeout(ns_dt_ma_dtc_cdanh_lkeCho); ns_dt_ma_dtc_cdanh_P_LKE();
    }
}
function ns_dt_ma_dtc_cdanh_P_LKE() {
    try {
        a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_DTC_CDANH_LKE(a_tso, a_cot, ns_dt_ma_dtc_cdanh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtc_cdanh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_dtc_cdanh_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_dtc_cdanh_HangLen(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_chuyenHang(b_grct, -1);
    return false;
}
function ns_dt_ma_dtc_cdanh_HangXuong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_chuyenHang(b_grct, 1);
    return false;
}
function ns_dt_ma_dtc_cdanh_CatDong(mode) {
    var b_grct;
    if (mode == 1) b_grct = b_grctId;
    else return false;
    GridX_boChon(b_grct, 'C');
    return false;
}
function ns_dt_ma_dtc_cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_dt_ma_dtc_cdanh_P_TRA_CDANH() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grcdanhId);
        sns_hdns.Fs_NS_HDNS_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, ns_dt_ma_dtc_cdanh_P_TRA_CDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_dtc_cdanh_P_TRA_CDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grcdanhId, a_kq[1]);
    slide_P_SOTRANG(b_slidecdanhId);
}
function cdanh_HangLen() {
    GridX_chuyenHang(b_grcdanhId, -1);
    return false;
}
function cdanh_HangXuong() {
    GridX_chuyenHang(b_grcdanhId, 1);
    return false;
}
function cdanh_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grcdanhId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grcdanhId);
    return false;
}
function cdanh_CatDong() {
    GridX_boChon(b_grcdanhId, 'C');
    return false;
}