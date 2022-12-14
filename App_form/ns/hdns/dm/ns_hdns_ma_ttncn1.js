var b_lkeCho, b_choAct = 0, b_vungId, b_grlkeId, b_grlctId, b_slideId, b_slidectId, b_doituongId, b_tien_tu, b_tien_den, b_ngay_hl;
function ns_hdns_ma_ttncn_P_KD() {
    b_lkeCho = setInterval('ns_hdns_ma_ttncn_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_doituongId).value = b_kq;
            ns_hdns_ma_ttncn_P_LKE(); form_P_MOI(b_vungId, "GLX");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ttncn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DOITUONG_CUTRU": b_maId = b_doituongId; break;
            case "NGAY_D": b_maId = b_ngay_hl; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return true;
        switch (b_maTen) {
            case "NGAY_D":
                {
                    var b_dtct = $get(b_doituongId).value, b_ngayD = $get(b_ngay_hl).value;
                    if (b_dtct == "" || b_ngayD == "") return;
                    var b_hang = GridX_Fi_timHangD(b_grlkeId, ["ten_doituong_cutru", "ngay_d"], [b_dtct, b_ngayD]);
                    if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_hdns_ma_ttncn_P_MA_KTRA(); }
                    else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ttncn_P_CHUYEN_HANG(); }
                    break;
                }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ttncn_P_MA_KTRA() {
    try {
        var b_dtct = lke_Fs_TRA(b_doituongId), b_ngayD = $get(b_ngay_hl).value;
        var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
        sns_hdns.Fs_NS_HDNS_MA_TTNCN_MA(b_nsd, b_dtct, b_ngayD, b_TrangKt, a_cot, ns_hdns_ma_ttncn_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ttncn_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) {
        form_P_MOI(b_vungId, "X");
        GridX_datTrang(b_grlctId);
        slide_P_SOTRANG(b_slidectId);
    }
    else {
        GridX_datA(b_grlkeId, b_hang);
        ns_hdns_ma_ttncn_P_CHUYEN_HANG();
    }
}
function ns_hdns_ma_ttncn_P_CT_MOI(b_dk) {
    form_P_MOI(b_vungId, b_dk);
    GridX_datTrang(b_grlctId);
    slide_P_SOTRANG(b_slidectId);
    return false;
}
function ns_hdns_ma_ttncn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grlctId);
    slide_P_SOTRANG(b_slidectId);
    return false;
}
function ns_hdns_ma_ttncn_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_cot_ct = GridX_Fdt_cotGtri(b_grlctId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    var b_dtg_ctru = lke_Fs_TRA(b_doituongId), b_ngay_d = CNG_SO($get(b_ngay_hl).value);
    sns_hdns.Fs_NS_HDNS_MA_TTNCN_NH(form_Fs_nsd(), b_dtg_ctru, b_ngay_d, b_TrangKt, a_cot_ct, a_cot, ns_hdns_ma_ttncn_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_ttncn_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        form_P_LOI('loi:Ghi thành công!:loi');
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ttncn_P_CHUYEN_HANG(); }
    }
    return false;
}
function ns_hdns_ma_ttncn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa!:loi"); return false; }
    var b_dtg_ctru = GridX_Fas_layGtri(b_grlkeId, b_hang, "doituong_cutru"), b_ngay_d = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_d");
    if (b_dtg_ctru == "") ns_hdns_ma_ttncn_P_MOI();
    else {
        var b_index = b_dtg_ctru.indexOf("{"); b_dtg_ctru = b_dtg_ctru.substr(0, b_index);
        b_ngay_d = CNG_SO(b_ngay_d);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_TTNCN_XOA(form_Fs_nsd(), b_dtg_ctru, b_ngay_d, a_tso, a_cot, ns_hdns_ma_ttncn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_ttncn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId), b_dong = CSO_SO(a_kq[0], 0);
        slide_P_SOTRANG(b_slideId, b_dong);
        GridX_datBang(b_grlkeId, a_kq[1]);
        if (b_hang > b_dong) b_hang = b_dong;
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_ttncn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_ttncn_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_hdns_ma_ttncn_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_hdns_ma_ttncn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_ma_ttncn_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_dtg_ctru = GridX_Fas_layGtri(b_grlkeId, b_hang, "doituong_cutru"), b_ngay_d = GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_d");
        if (b_dtg_ctru == "") form_P_MOI(b_vungId, "XGL");
        else {
            form_P_GridX_TEXT(b_vungId, b_grlkeId);
            var b_index = b_dtg_ctru.indexOf("{"); b_dtg_ctru = b_dtg_ctru.substr(0, b_index);
            b_ngay_d = CNG_SO(b_ngay_d);
            var a_cot = GridX_Fas_tenCot(b_grlctId);
            sns_hdns.Fs_NS_HDNS_MA_TTNCN_CT(form_Fs_nsd(), b_dtg_ctru, b_ngay_d, a_cot, ns_hdns_ma_ttncn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ttncn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlctId, b_kq);
    slide_P_SOTRANG(b_slidectId);
}
function ns_hdns_ma_ttncn_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(b_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grlctId = form_Fs_VUNG_ID('GR_ct'),
        b_doituongId = form_Fs_TEN_ID(b_vungId, 'DOITUONG_CUTRU'), b_ngay_hl = form_Fs_TEN_ID(b_vungId, 'NGAY_D'),
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slidectId = $get(b_grlctId).getAttribute('slideId'); slide_P_MOI(b_slidectId);
        ns_hdns_ma_ttncn_P_LKE();
    }
}
function ns_hdns_ma_ttncn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NS_HDNS_MA_TTNCN_LKE(form_Fs_nsd(), a_tso, a_cot, ns_hdns_ma_ttncn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_ttncn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_ttncn_P_EXCEL() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2'); $get(b_btn_excel).click(); form_chay = 0; return false;
}
function ns_hdns_ma_ttncn_HangLen() {
    GridX_chuyenHang(b_grlctId, -1);
    return false;
}
function ns_hdns_ma_ttncn_HangXuong() {
    GridX_chuyenHang(b_grlctId, 1);
    return false;
}
function ns_hdns_ma_ttncn_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grlctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grlctId);
    return false;
}
function ns_hdns_ma_ttncn_CatDong() {
    GridX_boChon(b_grlctId, 'C');
    return false;
}
function form_dong() {
    location.reload(false);
}