var ns_dt_ma_gv_ngoai_lkeCho = 0, ns_dt_ma_gv_ngoai_choAct = 0, b_vungId, b_grlkeId, b_slideId, b_gchuId, b_vungHi, b_grLVDT,
    b_so_idHi, b_dtacId, b_gvienId, b_slidelvchaId;
function ns_dt_ma_gv_ngoai_P_KD() {
    ns_dt_ma_gv_ngoai_lkeCho = setInterval('ns_dt_ma_gv_ngoai_P_LKE_CHO()', 200);
}
function ns_dt_ma_gv_ngoai_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "DTAC": b_maId = b_dtacId; break;
        }
        if (b_maTen == "DTAC") {
            GridX_datTrang(b_grLVDT);
            $get(b_so_idHi).value = "";
            ns_dt_ma_gv_ngoai_P_LVDT();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_ngoai_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_nam = $get(b_namId).value;
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_dt.Fs_NS_DT_MA_GV_NGOAI_MA(b_nam, b_ma, b_TrangKt, a_cot, ns_dt_ma_gv_ngoai_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_ngoai_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_ngoai_P_CHUYEN_HANG(); }
}
function ns_dt_ma_gv_ngoai_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_dt_ma_gv_ngoai_P_MOI() {
    form_P_MOI(b_vungId, "GLX");
    GridX_thoiA(b_grlkeId);
    GridX_datTrang(b_grLVDT);
    $get(b_so_idHi).value = "";
    return false;
}
function ns_dt_ma_gv_ngoai_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            if (ktra_ktdb(C_NVL(form_Fs_TEN_GTRI(b_vungId, 'gvien')))) { form_P_LOI("loi:Đối tượng không được chứa ký tự đặc biệt:loi"); return false; }
            var b_hang = GridX_Fi_timHangA(b_grlkeId); if (b_hang < 1) b_hang = -1;
            var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_so_id = $get(b_so_idHi).value;
            sns_dt.Fs_NS_DT_MA_GV_NGOAI_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, ns_dt_ma_gv_ngoai_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_ma_gv_ngoai_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idHi).value = a_kq[4];
        $get(b_dtacId).focus();
        form_P_LOI("loi:Ghi thành công!:loi");
    }
    return false;
}
function ns_dt_ma_gv_ngoai_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa:loi"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "" || b_so_id == 0) ns_dt_ma_gv_ngoai_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_GV_NGOAI_XOA(b_so_id, a_tso, a_cot, ns_dt_ma_gv_ngoai_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_dt_ma_gv_ngoai_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_ma_gv_ngoai_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_ma_gv_ngoai_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
function ns_dt_ma_gv_ngoai_GR_lke_RowChange() {
    if (ns_dt_ma_gv_ngoai_choAct != 0) clearTimeout(ns_dt_ma_gv_ngoai_choAct);
    ns_dt_ma_gv_ngoai_choAct = setTimeout("ns_dt_ma_gv_ngoai_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_ma_gv_ngoai_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") {
        form_P_MOI(b_vungId, "GLX");
        GridX_datTrang(b_grLVDT);
        $get(b_so_idHi).value = "";
    }
    else {
        var a_cot = GridX_Fas_tenCot(b_grLVDT);
        $get(b_so_idHi).value = b_so_id;
        sns_dt.Fs_NS_DT_MA_GV_NGOAI_CT(window.name, b_so_id, a_cot, ns_dt_ma_gv_ngoai_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_dt_ma_gv_ngoai_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    GridX_datBang(b_grLVDT, a_kq[1]);
    slide_P_SOTRANG(b_slidelvchaId);
}
function ns_dt_ma_gv_ngoai_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vungHi = form_Fs_VUNG_ID('UPa_hi');
        b_grLVDT = form_Fs_VUNG_ID('GR_lvcha');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_dtacId = form_Fs_TEN_ID(b_vungId, 'DTAC');
        b_gvienId = form_Fs_TEN_ID(b_vungId, 'GVIEN');
        b_so_idHi = form_Fs_TEN_ID(b_vungHi, 'so_id')
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        b_slidelvchaId = $get(b_grLVDT).getAttribute('slideId'); slide_P_MOI(b_slidelvchaId);
        clearTimeout(ns_dt_ma_gv_ngoai_lkeCho); ns_dt_ma_gv_ngoai_P_LKE();
    }
}
function ns_dt_ma_gv_ngoai_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_dt.Fs_NS_DT_MA_GV_NGOAI_LKE(a_tso, a_cot, ns_dt_ma_gv_ngoai_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_ngoai_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_dt_ma_gv_ngoai_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function form_dong() {
    location.reload(false);
}
function ns_dt_ma_gv_ngoai_P_LVDT() {
    try {
        var b_dtac = lke_Fs_TRA(b_dtacId);
        var a_cot = GridX_Fas_tenCot(b_grLVDT);
        if (b_dtac != "") { sns_dt.Fs_NS_DT_DTAC_LVDT(b_dtac, a_cot, ns_dt_ma_gv_ngoai_P_LVDT_KQ, P_LOI_CSDL, P_LOI_TGIAN); }
        return false
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_ma_gv_ngoai_P_LVDT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grLVDT, b_kq);
    slide_P_SOTRANG(b_slidelvchaId);
}
function ns_dt_ma_gv_ngoai_FI_NH() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1 || C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")) == "") {
            form_P_LOI('loi:Chọn giảng viên:loi')
            return false;
        }
        var b_tenf = '/App_form/ns/hs/file_hs.aspx';
        form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "NS_DT_MA_GV_NGOAI_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")), "NS_DT_MA_GV_NGOAI_IMP" + C_NVL(GridX_Fas_layGtriA(b_grlkeId, "so_id")), "Lưu file thông tin"]], null);
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}