var ns_dt_ma_cket_lkeCho = 0, ns_dt_ma_cket_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_gocId,
    b_hthuc_cketId, b_nnnghiepId, b_thgian_cketId, b_ng_hlucId, b_ng_hhlucId, b_grct, b_cp_tuId, b_cp_denId;
function ns_dt_ma_cket_P_KD() {
    ns_dt_ma_cket_lkeCho = setInterval('ns_dt_ma_cket_P_LKE_CHO()', 200);
}
function ns_dt_ma_cket_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_dt_ma_cket_P_NH() {
    try {
        var b_cp_tu = $get(b_cp_tuId).value;
        if (b_cp_tu == "") { form_P_LOI("loi:Nhập mức chi phí từ:loi"); return false; }
        var ktra = ktra_ngay(parseDate($get(b_ng_hlucId).value).getTime(), parseDate($get(b_ng_hhlucId).value).getTime(), 1, "Ngày hiệu lực", "Ngày hết hiệu lực");
        if (ktra.length > 0) { ns_dt_ma_cket_NH_KQ(ktra); return false; }
        var ktra_cp = '';
        if (C_NVL($get(b_cp_denId).value) != '') {
            if ($get(b_cp_denId).value == 0) {
                form_P_LOI("loi:Mức chi phí đến không được bằng 0:loi"); return false;
            }
            ktra_cp = ktra_cphi(CSO_SO($get(b_cp_tuId).value), CSO_SO($get(b_cp_denId).value));
        }
        if (ktra_cp.length > 0) { ns_dt_ma_cket_NH_KQ(ktra_cp); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId),b_so_id='0';
        if (b_loi != "") form_P_LOI(b_loi);
        else { 
            var b_hang = GridX_Fi_timHangA(b_grlkeId); b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            sns_dt.Fs_NS_DT_MA_CKET_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_lke, ns_dt_ma_cket_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_cket_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).value = a_kq[4];
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_cket_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId,b_hang, "so_id"));
    if (b_so_id == "") ns_dt_ma_cket_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_CKET_XOA(b_so_id, a_tso, a_cot, ns_dt_ma_cket_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_cket_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_cket_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_cket_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_dt_ma_cket_GR_lke_RowChange() {
    if (ns_dt_ma_cket_choAct != 0) clearTimeout(ns_dt_ma_cket_choAct);
    ns_dt_ma_cket_choAct = setTimeout("ns_dt_ma_cket_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_cket_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") form_P_MOI(b_vungId, "GLX");
    else {
        var a_cot = GridX_Fas_tenCot(b_grct);
        sns_dt.Fs_NS_DT_MA_CKET_CT(window.name, b_so_id, a_cot, ns_dt_ma_cket_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_ma_cket_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0])
    if (CSO_SO($get(b_cp_denId).value) == 0) {
        $get(b_cp_denId).value = '';
    }
}
function ns_dt_ma_cket_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grct = form_Fs_VUNG_ID('GR_ct');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'so_id');
        b_thgian_cketId = form_Fs_TEN_ID(b_vungId, 'THGIAN_CKET');
        b_ng_hlucId = form_Fs_TEN_ID(b_vungId, 'NG_HLUC');
        b_ng_hhlucId = form_Fs_TEN_ID(b_vungId, 'ng_hhluc');
        b_cp_tuId = form_Fs_TEN_ID(b_vungId, 'CP_TU');
        b_cp_denId = form_Fs_TEN_ID(b_vungId, 'cp_den');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_dt_ma_cket_lkeCho); ns_dt_ma_cket_P_LKE();
    }
}
function ns_dt_ma_cket_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_CKET_LKE(a_tso, a_cot, ns_dt_ma_cket_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_cket_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_cket_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
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
function ktra_cphi(cphitu, cphiden) {
    if (cphitu > cphiden) {
        return "loi:Mức chi phí đến phải lớn hơn hoặc bằng Mức chi phí từ:loi";
    }
    return "";
}