var lvhoan_bai2_lkeCho, b_vungId, b_grlkeId, b_formsId, b_slideId, b_gocId, b_tenId, b_ma_manghe_Id, b_ma_cmon_Id, b_ma_nnnghe_Id,
    b_ma_capbac_Id, b_so_idId, so_id_cbnnId, so_id_cm_Id, lvhoan_bai3_choAct = 0, b_ttId,
    b_cho;
function ns_lvhoan_bai3_P_KD() {
    lvhoan_bai2_lkeCho = setInterval('lvhoan_bai3_P_LKE_CHO()', 200);
}
// Liệt kê
function lvhoan_bai3_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(lvhoan_bai2_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_slideId = $get(b_grlkeId).getAttribute('slideId')
        slide_P_MOI(b_slideId);
        lvhoan_bai3_P_LKE();
    }
}
function lvhoan_bai3_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ngay_tu = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_tu')).value;
        var b_ngay_den = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_den')).value;

        sns_hdns.Fs_LVHOAN_BAI3_LKE(form_Fs_nsd(), b_ngay_tu, b_ngay_den, a_cot, a_tso, lvhoan_bai3_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function lvhoan_bai3_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function form_P_TRA_LIST() {
    var a_cot = GridX_Fdt_cotGtri(b_grlkeId);
    sdg.Fs_TRA_CHON(form_Fs_nsd(), a_cot, form_P_TRA_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function form_P_TRA_LIST_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_TRA_CHON('MA,TEN');
    }
}
function form_dong() {
    location.reload(false);
}
// CHuyển hàng
function lvhoan_bai3_GR_lke_RowChange() {
    if (lvhoan_bai3_choAct != 0) clearTimeout(lvhoan_bai3_choAct);
    lvhoan_bai3_choAct = setTimeout("lvhoan_bai3_P_CHUYEN_HANG()", 300);
    return false;
}
function lvhoan_bai3_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "KXGLNM");
            var b_kytudau = "PB", b_tenbang = "LVHOAN_BAI3", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, lvhoan_bai3_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            sns_hdns.Fs_LVHOAN_BAI3_CT(form_Fs_nsd(),b_ma, lvhoan_bai3_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function lvhoan_bai3_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function lvhoan_bai3_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
// Nhập
function lvhoan_bai3_P_MOI() {
    form_P_MOI(b_vungId, "KGXMN");
    GridX_thoiA(b_grlkeId);
    var b_kytudau = "PB", b_tenbang = "LVHOAN_BAI3", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, lvhoan_bai3_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function lvhoan_bai3_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_LVHOAN_BAI3_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, lvhoan_bai3_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function lvhoan_bai3_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        lvhoan_bai2_P_CHUYEN_HANG();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
function lvhoan_bai3_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0; return false;//Xuất Excel
}
//import file
function nhap_file() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || $get(b_gocId).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_so_the = $get(b_gocId).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_the, "LVHOAN_BAI3", "Import dữ liệu - Hợp đồng"]], null);
    form_P_LOI('');
    return false;
}
// Xóa
function lvhoan_bai3_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == 0) { form_P_LOI('loi:Chọn bản ghi cần xóa:loi'); ns_hdns_ma_vtcdanh_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_hdns.Fs_LVHOAN_BAI3_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, a_cot_ct, lvhoan_bai3_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function lvhoan_bai3_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) lvhoan_bai3_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); lvhoan_bai3_P_CHUYEN_HANG(); }
    }
}