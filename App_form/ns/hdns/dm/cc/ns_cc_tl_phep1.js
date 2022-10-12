var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_cty_Id, b_ngay_hl_Id, b_thamNienTangPhep_Id, b_ngayCatPhep_Id, b_ngayCatNghiBu_Id, b_chinhThucTu_Id,
    b_nsd, ns_cc_tl_phep_choAct = 0;
function ns_cc_tl_phep_P_KD() {
    b_lkeCho = setInterval('ns_cc_tl_phep_P_LKE_CHO()', 200);
}
function ns_cc_tl_phep_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DVI": b_maId = b_cty_Id; break;
            case "NGAY_HL": b_maId = b_ngay_hl_Id; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "DVI" || b_maTen == "NGAY_HL") {
            var b_dvi = lke_Fs_TRA(b_cty_Id), b_ngay_hl = $get(b_ngay_hl_Id).value;
            if (b_dvi != "" && b_ngay_hl != "") {
                var b_ten_dvi = $get(b_cty_Id).value;
                var b_hang = GridX_Fi_timHangD(b_grlkeId, ['dvi', 'ngay_hl'], [b_dvi + "{" + b_ten_dvi, b_ngay_hl]);
                if (b_hang < 1) {
                    ns_cc_tl_phep_P_MA_KTRA();
                }
                else {
                    GridX_datA(b_grlkeId, b_hang);
                    ns_cc_tl_phep_P_CHUYEN_HANG();
                }
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tl_phep_P_MA_KTRA() {
    try {
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_so_id = CSO_SO($get(b_so_id_Id).value), b_dvi = lke_Fs_TRA(b_cty_Id), b_ngay_hl = CNG_SO($get(b_ngay_hl_Id).value);
        sns_cc.Fs_NS_CC_TL_PHEP_MA(b_nsd, 0, b_dvi, b_ngay_hl, b_TrangKt, a_cot, ns_cc_tl_phep_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tl_phep_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    var b_hangA = GridX_Fi_timHangA(b_grlkeId);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X");
        $get(b_so_id_Id).value = 0;
        //var b_so_id = CSO_SO($get(b_so_id_Id).value);
        //if (b_so_id == 0)
        //    GridX_thoiA(b_grlkeId); //form_P_MOI(b_vungId, "X");
        //else
        //    GridX_datA(b_grlkeId, b_hangA);
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_cc_tl_phep_P_CHUYEN_HANG();
    }
}
function ns_cc_tl_phep_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    list_P_IdDAT(b_chinhThucTu_Id, 'CT');
    $get(b_so_id_Id).value = "0";
    $get(b_cty_Id).focus();
    return false;
}
function ns_cc_tl_phep_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_so_id = CSO_SO($get(b_so_id_Id).value);
    sns_cc.Fs_NS_CC_TL_PHEP_NH(b_nsd, b_so_id, b_TrangKt, a_dt, a_cot, ns_cc_tl_phep_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_cc_tl_phep_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]), b_so_id = CSO_SO(a_kq[4]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        $get(b_so_id_Id).value = b_so_id;
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_cty_Id).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_cc_tl_phep_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); ns_cc_tl_phep_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_CC_TL_PHEP_XOA(b_nsd, b_so_id, a_tso, a_cot, ns_cc_tl_phep_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_cc_tl_phep_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        var b_dong = GridX_Fi_timHangC(b_grlkeId);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_cc_tl_phep_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_cc_tl_phep_P_CHUYEN_HANG();
            form_P_LOI("loi:Xóa thành công!:loi");
        }
    }
}
function ns_cc_tl_phep_GR_lke_RowChange() {
    if (ns_cc_tl_phep_choAct != 0) clearTimeout(ns_cc_tl_phep_choAct);
    ns_cc_tl_phep_choAct = setTimeout("ns_cc_tl_phep_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_tl_phep_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") ns_cc_tl_phep_P_MOI();
        else form_P_GridX_TEXT(b_vungId, b_grlkeId);
        $get(b_so_id_Id).value = b_so_id;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tl_phep_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_cty_Id = form_Fs_TEN_ID(b_vungId, 'DVI');
        b_ngay_hl_Id = form_Fs_TEN_ID(b_vungId, 'NGAY_HL');
        b_thamNienTangPhep_Id = form_Fs_TEN_ID(b_vungId, 'thnien_tang');
        b_ngayCatPhep_Id = form_Fs_TEN_ID(b_vungId, 'ng_cat_ph');
        b_ngayCatNghiBu_Id = form_Fs_TEN_ID(b_vungId, 'ng_cat_nghi_bu');
        b_chinhThucTu_Id = form_Fs_TEN_ID(b_vungId, 'cth_tu');
        b_so_id_Id = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_nsd = form_Fs_nsd();
        clearTimeout(b_lkeCho); ns_cc_tl_phep_P_LKE();
    }
}
function ns_cc_tl_phep_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_cc.Fs_NS_CC_TL_PHEP_LKE(b_nsd, a_tso, a_cot, ns_cc_tl_phep_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_tl_phep_P_LKE_KQ(b_kq) {
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