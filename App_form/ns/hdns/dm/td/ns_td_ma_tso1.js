var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ngay_bdau_Id, b_ngay_kthuc_id, b_nsd, ns_cc_ma_tso_choAct = 0;
function ns_cc_ma_tso_P_KD() {
    b_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
    b_ngay_bdau_Id = form_Fs_TEN_ID(b_vungId, 'NG_BDAU');
    b_ngay_kthuc_id = form_Fs_TEN_ID(b_vungId, 'ng_kthuc');
    b_slideId = b_grlkeId + '_slide';
    b_nsd = form_Fs_nsd();
    b_lkeCho = setInterval('ns_cc_ma_tso_P_LKE_CHO()', 200);
}
function ns_cc_ma_tso_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "NG_BDAU": b_maId = b_ngay_bdau_Id; break;
            case "NG_KTHUC": b_maId = b_ngay_kthuc_id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_cc_ma_tso_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_cc_ma_tso_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
        else if (b_maTen == "NG_BDAU") {
            if (C_NVL($get(b_ngay_kthuc_id)).value == "") return true;
            var b_ngayD = CNG_SO($get(b_ngay_bdau_Id).value), b_ngayC = CNG_SO($get(b_ngay_kthuc_id).value);
            if (b_ngayD > b_ngayC) {
                form_P_LOI("loi:Ngày hiệu lực không được lớn hơn ngày hết hiệu lực:loi");
                return false;
            }
            else
                return true;
        }
        else if (b_maTen == "NG_KTHUC") {
            if (C_NVL($get(b_ngay_bdau_Id)).value == "") return true;
            var b_ngayD = CNG_SO($get(b_ngay_bdau_Id).value), b_ngayC = CNG_SO($get(b_ngay_kthuc_id).value);
            if (b_ngayD > b_ngayC) {
                form_P_LOI("loi:Ngày hết hiệu lực không được nhỏ hơn ngày hiệu lực:loi");
                return false;
            }
            else
                return true;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_tso_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_ma_ch.Fs_NS_CC_MA_TSO_MA(b_nsd, b_ma, b_TrangKt, a_cot, ns_cc_ma_tso_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_tso_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_cc_ma_tso_P_CHUYEN_HANG(); }
}
function ns_cc_ma_tso_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_gocId).focus();    
    return false;
}
function ns_cc_ma_tso_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    if (!ns_cc_ma_tso_P_KTRA('NG_BDAU') || !ns_cc_ma_tso_P_KTRA('ng_kthuc')) return false;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_CC_MA_TSO_NH(b_nsd, b_TrangKt, a_dt_ct, a_cot, ns_cc_ma_tso_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_ma_tso_P_NH_KQ(b_kq) {
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
function ns_cc_ma_tso_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_ma_tso_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_CC_MA_TSO_XOA(b_nsd, b_ma, a_tso, a_cot, ns_cc_ma_tso_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_ma_tso_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_timHangC(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang))
            ns_cc_ma_tso_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang);
            ns_cc_ma_tso_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_cc_ma_tso_GR_lke_RowChange() {
    if (ns_cc_ma_tso_choAct != 0) clearTimeout(ns_cc_ma_tso_choAct);
    ns_cc_ma_tso_choAct = setTimeout("ns_cc_ma_tso_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_ma_tso_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_tso_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(b_lkeCho); ns_cc_ma_tso_P_LKE(); }
}
function ns_cc_ma_tso_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_CC_MA_TSO_LKE(b_nsd, a_tso, a_cot, ns_cc_ma_tso_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_tso_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}