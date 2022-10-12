var tl_qd_xl_dg_lkeCho, b_vungId, b_loaidgId,b_hesoId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_donviId, b_donvi_tkId, b_nam_tkId, b_lngId, tl_qd_xl_dg_choAct, b_nhom_cdanhId, b_cdanhId, b_capbacId
b_choAct = 0, b_fcho = 'C';
function tl_qd_xl_dg_P_KD() {
    tl_qd_xl_dg_lkeCho, tl_qd_xl_dg_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), //b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct'), //b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'), b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
    b_ngayhieulucId = form_Fs_TEN_ID(b_vungId, 'ngayhieuluc'),
    b_loaidgId = form_Fs_TEN_ID(b_vungId, 'loai_dg'),
    // b_cdanhId = form_Fs_TEN_ID(b_vungId, 'NCD'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_slideId = b_grlkeId + '_slide';
    tl_qd_xl_dg_lkeCho = setInterval('tl_qd_xl_dg_P_LKE_CHO()', 200);
}

function tl_qd_xl_dg_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KY_DG": b_maId = b_so_idId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "KY_DG") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ky_dg", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); tl_qd_xl_dg_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); tl_qd_xl_dg_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_gchuId).innerhtml = b_ten;
            $get(b_so_theId).focus();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
// Nhập
function tl_qd_xl_dg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    //$get(b_ky_dgId).value = ""
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    //$get(b_namId).value = "";
    return false;
}
function tl_qd_xl_dg_P_NH() {
    try {

        var b_ngay_dg = form_Fs_TEN_GTRI(b_vungId, 'ngayhieuluc');
        if (b_ngay_dg == "") { form_P_LOI("loi:Phải chọn ngày hiệu lực:loi"); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId); //var b_hang1 = GridX_Fi_timHangA(b_grctId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            //var b_soid_ct = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang1, "so_idct"));
            sdg.Fs_TL_QD_XL_DG_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, tl_qd_xl_dg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function tl_qd_xl_dg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        //var a_kq = Fas_ChMang(b_kq, '#');
        //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        //form_P_LOI("loi:Nhập thành công:loi");
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function tl_qd_xl_dg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    //var message = confirm("Bạn có chắc chắn xóa không?");
    //if (message == false) { return false; }

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") tl_qd_xl_dg_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_TL_QD_XL_DG_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, tl_qd_xl_dg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function tl_qd_xl_dg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) tl_qd_xl_dg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); tl_qd_xl_dg_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function tl_qd_xl_dg_GR_lke_RowChange() {
    if (tl_qd_xl_dg_choAct != 0) clearTimeout(tl_qd_xl_dg_choAct);
    tl_qd_xl_dg_choAct = setTimeout("tl_qd_xl_dg_P_CHUYEN_HANG()", 300);
    return false;
}
function tl_qd_xl_dg_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_TL_QD_XL_DG_CT(form_Fs_nsd(), b_so_id, a_cot_ct, tl_qd_xl_dg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function tl_qd_xl_dg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {

        var a_kq = b_kq.split('#');
        form_P_GridX_TEXT(b_vungId, b_grlkeId); //form_P_CH_TEXT(b_vungId, b_ngayhieuluc);
        if (a_kq[0] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[0]);
        check_anhien();
        return false;
    }
}
// Liệt kê
function tl_qd_xl_dg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (tl_qd_xl_dg_lkeCho != 0) clearTimeout(tl_qd_xl_dg_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        tl_qd_xl_dg_P_LKE('K');
    }
}
function tl_qd_xl_dg_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_TL_QD_XL_DG_LKE(form_Fs_nsd(), a_tso, a_cot, tl_qd_xl_dg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function tl_qd_xl_dg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function tl_qd_xl_dg_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, 'DT_KY_DG', tl_qd_xl_dg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function tl_qd_xl_dg_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
    //ns_dg_cntdg_P_KTRA('tinhtrang');
}
function tl_qd_xl_dg_P_xeploai() {
    var b_diemdanhgia_tu = C_NVL(GridX_Fas_layGtriA(b_grctId, 'diemdanhgia_tu'));
    var b_diemdanhgia_den = C_NVL(GridX_Fas_layGtriA(b_grctId, 'diemdanhgia_den'));
    if (b_diemdanhgia_tu == "" && b_diemdanhgia_den == "") return false;
    var b_ddg_tu = CSO_SO(b_diemdanhgia_tu, 0);
    var b_ddg_den = CSO_SO(b_diemdanhgia_den, 0);
    switch (b_ddg_tu) {
        case 0:
            if (0 <= b_ddg_den - b_ddg_tu && b_ddg_den - b_ddg_tu < 3) GridX_datGtriA(b_grctId, 'XEPLOAI', 'Không đạt (D)');
            else GridX_datGtriA(b_grctId, 'XEPLOAI', ''); break;
        case 3:
            if (0 <= b_ddg_den - b_ddg_tu && b_ddg_den - b_ddg_tu < 2) GridX_datGtriA(b_grctId, 'XEPLOAI', 'Cần cải thiện (C)');
            else GridX_datGtriA(b_grctId, 'XEPLOAI', ''); break;
        case 5:
            if (0 <= b_ddg_den - b_ddg_tu && b_ddg_den - b_ddg_tu < 2) GridX_datGtriA(b_grctId, 'XEPLOAI', 'Đạt (B)');
            else GridX_datGtriA(b_grctId, 'XEPLOAI', ''); break;
        case 7:
            if (0 <= b_ddg_den - b_ddg_tu && b_ddg_den - b_ddg_tu < 2) GridX_datGtriA(b_grctId, 'XEPLOAI', 'Tốt (A)');
            else GridX_datGtriA(b_grctId, 'XEPLOAI', ''); break;
        case 9:
            if (0 <= b_ddg_den - b_ddg_tu && b_ddg_den - b_ddg_tu < 1) GridX_datGtriA(b_grctId, 'XEPLOAI', 'Xuất sắc (A*)');
            else GridX_datGtriA(b_grctId, 'XEPLOAI', ''); break;
        default:
            GridX_datGtriA(b_grctId, 'XEPLOAI', '');
    }
    return;
}
function Check_sothapphan(e) {
    var keyCode = e.which ? e.which : e.keyCode
    var ret = ((keyCode >= 48 && keyCode <= 57) || keyCode == 190); //|| specialKeys.indexOf(keyCode) != -1);
    if (ret == false) {
        var b_keyCode_ascii = String.fromCharCode(keyCode);
        var b_heso = C_NVL(GridX_Fas_layGtriA(b_grctId, 'heso'));
        b_heso = b_heso.replace(b_keyCode_ascii.toLowerCase(), '');
        GridX_datGtriA(b_grctId, 'heso', b_heso);
    }
}
function check_anhien() {
    var b_loai_dg = $get(b_loaidgId).value;
    if (b_loai_dg == "Đánh giá theo năm") {
        GridX_anCot(b_grctId, 'heso', "none");
    } else {
        GridX_anCot(b_grctId, 'heso', "");
    }
    return false;
}
function form_dong() {
    location.reload(false);
}
