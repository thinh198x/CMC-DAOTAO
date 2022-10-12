﻿var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_loai, b_ma_nhom_Id, b_tt_Id, b_nsd, ns_td_ma_chung_choAct = 0;
function ns_td_ma_chung_P_KD(b_ma_nhom, b_ten_nhom) {
    if (b_ma_nhom != "") {
        list_P_DAT(b_ma_nhom_Id, b_ma_nhom);
    }
    b_lkeCho = setInterval('ns_td_ma_chung_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
        } else if (b_dtuong.indexOf("THAMSO") >= 0) {
            //$get(b_loai).value = b_kq;
            ns_td_ma_chung_P_NHOM(b_kq);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            $get(b_gocId).value = ($get(b_gocId).value).validate_Ma();
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            //var b_nhom_ma = C_NVL(form_Fs_TEN_GTRI(b_vungId, 'NHOM_MA'));
            //b_hang = GridX_Fi_timHangD(b_grlkeId, ["NHOM_MA", "ma"], [b_nhom_ma, b_ma.value]);
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_td_ma_chung_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_td_ma_chung_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_TD_MA_CHUNG_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_td_ma_chung_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_td_ma_chung_P_CHUYEN_HANG(); }
}
function ns_td_ma_chung_P_MOI(ktxoa) {
    form_P_MOI(b_vungId, ktxoa);
    list_P_DAT(b_tt_Id, 'A');
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();
    return false;
}
function ns_td_ma_chung_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else
    {
        if (ktra_ktdb(C_NVL(form_Fs_TEN_GTRI(b_vungId, 'TEN')))) { form_P_LOI("loi:Tên không được chứa ký tự đặc biệt:loi"); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_ma_ch.Fs_NS_TD_MA_CHUNG_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, ns_td_ma_chung_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }

}
function ns_td_ma_chung_P_NH_KQ(b_kq) {
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
    return false;
}
function ns_td_ma_chung_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_td_ma_chung_P_MOI("GXL"); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_TD_MA_CHUNG_XOA(b_nsd, b_ma, a_tso, a_cot, ns_td_ma_chung_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_ma_chung_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = CSO_SO(a_kq[0], 0);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_ma_chung_P_MOI("GXL");
        else { GridX_datA(b_grlkeId, b_hang); ns_td_ma_chung_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_td_ma_chung_GR_lke_RowChange() {
    if (ns_td_ma_chung_choAct != 0) clearTimeout(ns_td_ma_chung_choAct);
    ns_td_ma_chung_choAct = setTimeout("ns_td_ma_chung_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_ma_chung_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL");
            list_P_DAT(b_tt_Id, 'A');
        }
        else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            var b_ma_nhom = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "NHOM_MA"));
            list_P_DAT(b_ma_nhom_Id, b_ma_nhom);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_loai = form_Fs_TEN_ID(b_vungId, 'NHOM_MA'), b_tt_Id = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
        b_ma_nhom_Id = form_Fctr_TEN_DTUONG(b_vungId, 'NHOM_MA');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_nsd = form_Fs_nsd();
        ns_td_ma_chung_P_LKE();
    }
}
function ns_td_ma_chung_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_TD_MA_CHUNG_LKE(b_nsd, a_tso, a_cot, ns_td_ma_chung_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_td_ma_chung_nhom(b_maloai) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nhom_ma = form_Fs_TEN_GTRI(b_vungId, 'NHOM_MA');
        sns_ma_ch.Fs_NS_TD_MA_CHUNG_LKE(b_nsd, a_tso, a_cot, b_nhom_ma, ns_td_ma_chung_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_NHOM(b_ma_nhom) {
    try {
        if (b_ma_nhom != "") {
            sns_ma_ch.Fs_NS_TD_MA_CHUNG_CHON(b_nsd, b_ma_nhom, ns_td_ma_chung_P_NHOM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_ma_chung_P_NHOM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    b_lkeCho = setInterval('ns_td_ma_chung_P_LKE_CHO()', 200);
}
function form_dong() {
    location.reload(false);
}