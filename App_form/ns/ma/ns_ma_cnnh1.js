var ns_ma_cnnh_lkeCho = 0, ns_ma_cnnh_choAct = 0, b_vungId, b_vungHi, b_grlkeId, b_slideId, b_gocId, b_so_idHi = "", b_ma_nhId,
    b_trangthaiId, b_luuday = "";
function ns_ma_cnnh_P_KD() {
    ns_ma_cnnh_lkeCho = setInterval('ns_ma_cnnh_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_ma_cnnh_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("TEN_NH") >= 0) {
            $get(b_ma_nhId).value = b_kq;
            $get(b_ten_nhId).value = a_tso[1];
            $get(b_gocId).focus();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_luuday = b_kq;
            ns_ma_cnnh_P_LKE();
            form_P_MOI(b_vungId, "GLX");
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_cnnh_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    $get(b_so_idHi).value = "";
    $get(b_ma_nhId).value = "";
    var b_kytudau = "CNNH", b_tenbang = "NS_MA_CNNH", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_ma_cnnh_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    list_P_DAT(b_trangthaiId, 'A');
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_ma_cnnh_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = $get(b_so_idHi).value;
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ma_ch.Fs_NS_MA_CNNH_NH(form_Fs_nsd(), CSO_SO(b_so_id, 0), b_TrangKt, a_dt_ct, a_cot, ns_ma_cnnh_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ma_cnnh_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        $get(b_gocId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_ma_cnnh_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_CNNH_XOA(b_luuday, b_so_id, a_tso, a_cot, ns_ma_cnnh_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ma_cnnh_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            ns_ma_cnnh_P_MOI();
        }
        else {
            GridX_datA(b_grlkeId, b_hang); ns_ma_cnnh_P_CHUYEN_HANG();
        }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
}
function ns_ma_cnnh_GR_lke_RowChange() {
    if (ns_ma_cnnh_choAct != 0) clearTimeout(ns_ma_cnnh_choAct);
    ns_ma_cnnh_choAct = setTimeout("ns_ma_cnnh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ma_cnnh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "" || b_so_id == 0) {
            ns_ma_cnnh_P_MOI();
            //form_P_MOI(b_vungId, "GLX");
        }
        else {
            sns_ma_ch.Fs_NS_MA_CNNH_CT(window.name, b_so_id, ns_ma_cnnh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_so_idHi).value = b_so_id;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_cnnh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);

}
function ns_ma_cnnh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_ma_cnnh_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_ma_nhId = form_Fs_TEN_ID(b_vungId, 'MA_NH');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'TRANGTHAI');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_ma_cnnh_lkeCho); ns_ma_cnnh_P_LKE();
    }
}
function ns_ma_cnnh_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ma_ch.Fs_NS_MA_CNNH_LKE(b_luuday, a_tso, a_cot, ns_ma_cnnh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ma_cnnh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ma_cnnh_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_ma_cnnh_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}