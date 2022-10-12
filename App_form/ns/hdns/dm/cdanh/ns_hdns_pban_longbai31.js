// Biến khởi tạo
var ns_hdns_pban_lkeCho, b_vungId, b_grlkeId, b_formsId, b_slideId, b_gocId, b_tenId, b_cho, ns_hdns_pb_choAct = 0;
function ns_hdns_bdlong_bai3_P_KD() {
    ns_hdns_pban_lkeCho = setInterval('ns_hdns_bdlong_bai3_P_LKE_CHO()', 200);
}
// Liệt kê
function ns_hdns_bdlong_bai3_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_hdns_pban_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct');
        b_grlkeId = form_Fs_VUNG_ID('GR_lke');
        b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');

        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
        b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN');
        b_ttId = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu');
        b_slideId = $get(b_grlkeId).getAttribute('slideId')
        slide_P_MOI(b_slideId);

        ns_hdns_bdlong_bai3_P_LKE();
    }
}
function ns_hdns_bdlong_bai3_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ngay_tu = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_tu')).value;
        var b_ngay_den = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_den')).value;

        sns_hdns.Fs_NS_PB_LONGBAI3_LKE(form_Fs_nsd(), b_ngay_tu, b_ngay_den, a_cot, a_tso, ns_hdns_bdlong_bai3_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_bdlong_bai3_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
// CHuyển hàng
function ns_pb_bdlong_bai3_GR_lke_RowChange() {
    if (ns_hdns_pb_choAct != 0) clearTimeout(ns_hdns_pb_choAct);
    ns_hdns_pb_choAct = setTimeout("ns_hdns_bdlong_bai3_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hdns_bdlong_bai3_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));;
        if (b_ma == "") {
            form_P_MOI(b_vungId, "KXGLNM"); 
            var b_kytudau = "PB", b_tenbang = "NS_MA_PBAN_LONGBAI3", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_bdlong_bai3_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {
            sns_hdns.Fs_NS_PB_LONGBAI3_CT(form_Fs_nsd(), b_ma, ns_hdns_bdlong_bai3_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_bdlong_bai3_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// Sinh mã
function ns_hdns_bdlong_bai3_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
// Nhập
function ns_hdns_bdlong_bai3_P_MOI() {
    form_P_MOI(b_vungId, "KGXMN");
    GridX_thoiA(b_grlkeId);
    var b_kytudau = "PB", b_tenbang = "NS_MA_PBAN_LONGBAI3", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_bdlong_bai3_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function ns_hdns_bdlong_bai3_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_PB_LONGBAI3_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_hdns_bdlong_bai3_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_bdlong_bai3_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        ns_hdns_bdlong_bai3_P_CHUYEN_HANG();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
// Xóa
function ns_hdns_bdlong_bai3_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    var b_ngay_tu = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_tu')).value;
    var b_ngay_den = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'ngay_den')).value;
    if (b_ma == 0) { form_P_LOI('loi:Chọn bản ghi cần xóa:loi'); ns_hdns_bdlong_bai3_P_MOI(); }
    else {
        var b_ma = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_hdns.Fs_NS_PB_LONGBAI3_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, a_cot_ct, b_ngay_tu,b_ngay_den, ns_hdns_bdlong_bai3_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_bdlong_bai3_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_bdlong_bai3_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_bdlong_bai3_P_CHUYEN_HANG(); }
    }
}
// Import
function ns_hdns_bdlong_bai3_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HDNS_PBAN_LONGBAI3', null, "Import mã chức danh"]], null);
    form_P_LOI('');
    return false;
}
// Nhập file theo từng phòng ban
function ns_hdns_bdlong_bai3_FILE_NHAP() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1 || $get(b_gocId).value == "") {
        form_P_LOI('loi:Bạn phải chọn 1 bản ghi:loi')
        return false;
    }
    var b_so_the = $get(b_gocId).value;
    var b_tenf = '/App_form/ns/ma/file_Import_chung.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, b_so_the, "NS_HDNS_PBAN_LONGBAI3", "Import dữ liệu - Hợp đồng"]], null);
    form_P_LOI('');
    return false;

}
