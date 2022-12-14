/////// <reference path="cc_ma_cc1.js" />
var cc_ma_cc_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_ttrang, cc_ma_cc_choAct = 0;
function cc_ma_cc_P_KD() {
    cc_ma_cc_lkeCho = setInterval('cc_ma_cc_P_LKE_CHO()', 200);

}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("MAPC") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang > -1) {
                GridX_datGtri(b_grctId, b_hang, "mapc", b_kq);
                GridX_datGtri(b_grctId, b_hang, "tenpc", a_tso[1]);
                GridX_datA(b_grctId, b_hang, "hso");
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); cc_ma_cc_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); cc_ma_cc_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            stl_ma.Fs_CC_MA_CC_MA(b_ma, b_TrangKt, a_cot, cc_ma_cc_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        $get(b_conggioId).value = '1';
        $get(b_conggio2Id).value = '1';
    }
    else { GridX_datA(b_grlkeId, b_hang); cc_ma_cc_P_CHUYEN_HANG(); }
}
function cc_ma_cc_pcap_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    if (b_mt == "MAPC") {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        GridX_datGtri(b_grctId, b_hang, "tenpc", b_kq);
        GridX_datA(b_grctId, b_hang, "hso");
    }
}
function cc_ma_cc_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_conggioId).value = '1';
    $get(b_conggio2Id).value = '1';
    GridX_datTrang(b_grctId);
    GridX_thoiA(b_grctId);
    list_P_DAT(b_ttrang, 'A');
    $get(b_gocId).focus();
    return false;
}
function cc_ma_cc_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
        stl_ma.Fs_CC_MA_CC_NH(b_TrangKt, a_dt_ct, a_cot_ct, a_cot, cc_ma_cc_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    } catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Ghi thành công!:loi");
        $get(b_gocId).focus();
    }
    return false;
}
function cc_ma_cc_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_CC_MA_CC_XOA(b_ma, a_tso, a_cot, cc_ma_cc_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function cc_ma_cc_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) cc_ma_cc_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); cc_ma_cc_P_CHUYEN_HANG();
            form_P_LOI("loi:Xóa thành công!:loi");
        }
    }
}
function cc_ma_cc_GR_lke_RowChange() {
    if (cc_ma_cc_choAct != 0) clearTimeout(cc_ma_cc_choAct);
    cc_ma_cc_choAct = setTimeout("cc_ma_cc_P_CHUYEN_HANG()", 300);
    return false;
}
function cc_ma_cc_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        if (b_ma == "") {
            form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId);
            $get(b_conggioId).value = '1';
            $get(b_conggio2Id).value = '1';
            list_P_DAT(b_ttrang, 'A');
        }
        else stl_ma.Fs_CC_MA_CC_CT(b_ma, a_cot_ct, cc_ma_cc_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    if (a_kq[0] == "") { form_P_MOI("", "X"); return; }
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);

}
function cc_ma_cc_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(cc_ma_cc_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
            b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'); b_slideId = $get(b_grlkeId).getAttribute('slideId'); b_ttrang = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
        b_conggioId = form_Fs_TEN_ID(b_vungId, 'conggio');
        b_conggio2Id = form_Fs_TEN_ID(b_vungId, 'conggio2');
        cc_ma_cc_P_LKE();
    }
}
function cc_ma_cc_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_ma.Fs_CC_MA_CC_LKE(a_tso, a_cot, cc_ma_cc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function cc_ma_cc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function cc_ma_cc_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function cc_ma_cc_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function cc_ma_cc_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function cc_ma_cc_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function cc_ma_cc_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function cc_ma_cc_pcap_Update(b_event) {
    try {
        var b_ctr = form_Fctr_event(b_event), b_hang = GridX_Fi_timHangA(b_grctId);
        var b_value = C_NVL(b_ctr.value), b_cot = b_ctr.getAttribute('ten_goc').toUpperCase();
        b_mt = b_cot;
        if (b_value != "") {
            if (b_cot == "MAPC") {
                skhac.Fs_MA_LOI(form_Fs_nsd(), "Mã phụ cấp", b_value, "ns_tl_tlap_pcap,ma,ten,gtri", cc_ma_cc_pcap_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        if (b_value != "") GridX_ThemHang(b_grctId);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function form_dong() {
    location.reload(false);
}