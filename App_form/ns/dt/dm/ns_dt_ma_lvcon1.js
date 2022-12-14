var ns_dt_ma_lvcon_lkeCho = 0, ns_dt_ma_lvcon_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gocId, b_ma_cha_Id, b_tenId, b_gchuId,
    b_vungHi, b_so_idHi, b_luuday = "", b_ma_cha = "";
function ns_dt_ma_lvcon_P_KD() {
    ns_dt_ma_lvcon_lkeCho = setInterval('ns_dt_ma_lvcon_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_dt_ma_lvcon_P_LKE();
            }
        }
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_ma_cha_Id).value = b_kq;
            b_ma_cha = a_tso[0];
            b_luuday = a_tso[1];
            ns_dt_ma_lvcon_P_LKE();
            $get(b_gocId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_lvcon_P_KTRA(b_maTen) {
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
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); ns_dt_ma_lvcon_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_lvcon_P_CHUYEN_HANG(); }
            b_ten.focus();
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_lvcon_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            var b_so_id = $get(b_so_idHi).value;
            sns_dt.FS_NS_DT_MA_LVCON_MA(b_luuday, b_ma_cha, b_ma, CSO_SO(b_so_id, 0), b_TrangKt, a_cot, ns_dt_ma_lvcon_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_lvcon_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "XL");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_lvcon_P_CHUYEN_HANG(); }
}
function ns_dt_ma_lvcon_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    $get(b_ma).focus();
}
function ns_dt_ma_lvcon_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    var b_kytudau = "LVC", b_tenbang = "NS_DT_MA_LVCON", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_dt_ma_lvcon_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_ma_cha_Id).focus();
    $get(b_so_idHi).value = "";
    list_P_DAT(b_trangthaiId, 'A');
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_dt_ma_lvcon_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
function ns_dt_ma_lvcon_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_so_id = CSO_SO($get(b_so_idHi).value, 0);
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_dt.FS_NS_DT_MA_LVCON_NH(form_Fs_nsd(), b_ma_cha, b_luuday, b_so_id, b_TrangKt, a_dt_ct, a_cot, ns_dt_ma_lvcon_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_dt_ma_lvcon_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_lvcon_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0);
    if (b_so_id == 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.FS_NS_DT_MA_LVCON_XOA(b_luuday, b_ma_cha, b_so_id, a_tso, a_cot, ns_dt_ma_lvcon_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_lvcon_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
            if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) {
                ns_dt_ma_lvcon_P_MOI();
            }
            else {
                GridX_datA(b_grlkeId, b_hang); ns_dt_ma_lvcon_P_CHUYEN_HANG();
            }
        }
        else { ns_dt_ma_lvcon_P_CHUYEN_HANG(); GridX_datA(b_grlkeId, b_hang); }
        form_P_LOI("loi:Xóa thành công!:loi"); return false;
    }
}
function ns_dt_ma_lvcon_GR_lke_RowChange() {
    if (ns_dt_ma_lvcon_choAct != 0) clearTimeout(ns_dt_ma_lvcon_choAct);
    ns_dt_ma_lvcon_choAct = setTimeout("ns_dt_ma_lvcon_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_lvcon_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_ma == "") {
            ns_dt_ma_lvcon_P_MOI();
        }
        else {
            sns_dt.Fs_NS_DT_MA_LVCON_CT(window.name, b_ma, ns_dt_ma_lvcon_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            $get(b_so_idHi).value = b_so_id;
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_lvcon_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_dt_ma_lvcon_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        ns_dt_ma_lvcon_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_Hi');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_ma_cha_Id = form_Fs_TEN_ID(b_vungId, 'MA_CHA');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_trangthaiId = form_Fctr_TEN_DTUONG(b_vungId, 'trangthai');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id');
        b_gchuId = form_Fs_VTEN_ID('', 'ghichu');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        clearTimeout(ns_dt_ma_lvcon_lkeCho); ns_dt_ma_lvcon_P_LKE();
    }
}
function ns_dt_ma_lvcon_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.FS_NS_DT_MA_LVCON_LKE(b_ma_cha, b_luuday, a_tso, a_cot, ns_dt_ma_lvcon_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_lvcon_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_lvcon_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}