var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_nhomId, b_ngay_bd_Id, b_ngay_kt_id, b_cho_control = 0, b_nsd, ns_dg_ma_kdg_choAct = 0;
function ns_dg_ma_kdg_P_KD() {
    b_lkeCho = setInterval('ns_dg_ma_kdg_P_LKE_CHO()', 200);
}
function ns_dg_ma_kdg_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = b_ma.value.validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dg_ma_kdg_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dg_ma_kdg_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ma_kdg_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_NS_DG_MA_KDG_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_dg_ma_kdg_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ma_kdg_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dg_ma_kdg_P_CHUYEN_HANG(); }
}
function ns_dg_ma_kdg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_dg_ma_kdg_P_NH() {
    var ktra = ktra_ngay(parseDate($get(b_ngayd).value).getTime(), parseDate($get(b_ngayc).value).getTime(), 1, "Ngày bắt đầu", "Ngày kết thúc");
    var ktra1 = ktra_ngay(parseDate($get(b_ngay_dg_d).value).getTime(), parseDate($get(b_ngay_dg_c).value).getTime(), 1, "Thời gian thực hiện ĐG từ", "Thời gian thực hiện ĐG đến");
    if (ktra.length > 0) {
        ns_dg_ma_kdg_P_NH_KQ(ktra);
        return false;
    }
    if (ktra1.length > 0) {
        ns_dg_ma_kdg_P_NH_KQ(ktra1);
        return false;
    }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_NS_DG_MA_KDG_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, ns_dg_ma_kdg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dg_ma_kdg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
}
function ns_dg_ma_kdg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_dg_ma_kdg_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_MA_KDG_XOA(b_nsd, b_ma, a_tso, a_cot, ns_dg_ma_kdg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dg_ma_kdg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dg_ma_kdg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dg_ma_kdg_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dg_ma_kdg_GR_lke_RowChange() {
    if (ns_dg_ma_kdg_choAct != 0) clearTimeout(ns_dg_ma_kdg_choAct);
    ns_dg_ma_kdg_choAct = setTimeout("ns_dg_ma_kdg_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dg_ma_kdg_P_CHUYEN_HANG() {
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
function ns_dg_ma_kdg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_ngayd = form_Fs_TEN_ID(b_vungId, 'NG_HLUC'),
        b_ngayc = form_Fs_TEN_ID(b_vungId, 'ng_het_hluc'),
        b_ngay_dg_d = form_Fs_TEN_ID(b_vungId, 'ngay_dg_d'),
        b_ngay_dg_c = form_Fs_TEN_ID(b_vungId, 'ngay_dg_c'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_ngay_bd_Id = form_Fs_TEN_ID(b_vungId, 'NG_HLUC');
        b_ngay_kt_id = form_Fs_TEN_ID(b_vungId, 'ng_het_hluc');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_nsd = form_Fs_nsd();
        ns_dg_ma_kdg_P_LKE();
    }
}
function ns_dg_ma_kdg_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_NS_DG_MA_KDG_LKE(b_nsd, a_tso, a_cot, ns_dg_ma_kdg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dg_ma_kdg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function form_dong() {
    location.reload(false);
}