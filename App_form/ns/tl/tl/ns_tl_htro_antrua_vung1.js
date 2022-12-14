var ns_tl_htro_antrua_vung_lkeCho, b_vungId, b_grlkeId, b_slideId, b_vungmienId, b_ngay_hlId, b_ngay_het_hlId, ns_tl_htro_antrua_vung_choAct = 0;
function ns_tl_htro_antrua_vung_P_KD() {
    ns_tl_htro_antrua_vung_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_vungmienId = form_Fs_TEN_ID(b_vungId, 'vung');
    b_ngay_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_hl');
    b_ngay_het_hlId = form_Fs_TEN_ID(b_vungId, 'ngay_het_hl');
    b_slideId = $get(b_grlkeId).getAttribute('slideId');
    ns_tl_htro_antrua_vung_lkeCho = setInterval('ns_tl_htro_antrua_vung_P_LKE_CHO()', 200);
}
// Kiêm tra
function ns_tl_htro_antrua_vung_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "NGAY_HL": b_maId = b_ngay_hlId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "NGAY_HL") {
            ns_tl_htro_antrua_vung_P_MA_KTRA()
            $get(b_tenId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_vung_P_MA_KTRA() {
    try {
        var b_vung = C_NVL($get(b_vungmienId).value);
        var b_ngay_hl = C_NVL($get(b_ngay_hlId).value);
        if (b_vung != "" && b_ngay_hl != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_tl.Fs_NS_TL_HTRO_ANTRUA_VUNG_MA(form_Fs_nsd(), b_vung, b_ngay_hl, b_TrangKt, a_cot, ns_tl_htro_antrua_vung_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_vung_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_vung_P_CHUYEN_HANG(); }
}
// Nhập
function ns_tl_htro_antrua_vung_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_vungmienId).focus();
    return false;
}
function ns_tl_htro_antrua_vung_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") {
        form_P_LOI(b_loi);
        return false;
    }
    var ktra = ktra_ngay(parseDate($get(b_ngay_hlId).value).getTime(), parseDate($get(b_ngay_het_hlId).value).getTime(), 1, "Ngày hiệu lực", "Ngày hết hiệu lực");
    if (ktra.length > 0) {
        ns_tl_htro_antrua_vung_P_NH_KQ(ktra);
        return false;
    }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_tl.Fs_NS_TL_HTRO_ANTRUA_VUNG_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_tl_htro_antrua_vung_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_tl_htro_antrua_vung_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI('loi:Nhập thành công!:loi');
        $get(b_vungmienId).focus();
    }
    return false;
}
// Xóa
function ns_tl_htro_antrua_vung_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_HTRO_ANTRUA_VUNG_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, ns_tl_htro_antrua_vung_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_tl_htro_antrua_vung_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_htro_antrua_vung_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_htro_antrua_vung_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
        //return false;
    }
}
// Chuyển hàng
function ns_tl_htro_antrua_vung_GR_lke_RowChange() {
    if (ns_tl_htro_antrua_vung_choAct != 0) clearTimeout(ns_tl_htro_antrua_vung_choAct);
    ns_tl_htro_antrua_vung_choAct = setTimeout("ns_tl_htro_antrua_vung_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_tl_htro_antrua_vung_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "0" || b_so_id == "") ns_tl_htro_antrua_vung_P_MOI();
        else sns_tl.Fs_NS_TL_HTRO_ANTRUA_VUNG_CT(form_Fs_nsd(), b_so_id, ns_tl_htro_antrua_vung_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_tl_htro_antrua_vung_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_kq == '') return;
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//Liệt kê
function ns_tl_htro_antrua_vung_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_tl_htro_antrua_vung_lkeCho != 0) clearTimeout(ns_tl_htro_antrua_vung_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_tl_htro_antrua_vung_P_LKE('K');
    }
}
function ns_tl_htro_antrua_vung_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tl.Fs_NS_TL_HTRO_ANTRUA_VUNG_LKE(form_Fs_nsd(), a_tso, a_cot, ns_tl_htro_antrua_vung_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_tl_htro_antrua_vung_P_MOI();
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_htro_antrua_vung_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
    }
}

function form_dong() {
    location.reload(false);
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