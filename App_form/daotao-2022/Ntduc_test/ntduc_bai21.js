var ns_hdns_ma_vtcdanh_lkeCho, b_vungId, b_grlkeId, b_formsId, b_slideId, b_gocId, b_tenId, b_ma_manghe_Id, b_ma_cmon_Id, b_ma_nnnghe_Id, b_ma_capbac_Id, b_so_idId, so_id_cbnnId, so_id_cm_Id, ns_hdns_ma_vtcdanh_choAct = 0, b_ttId,
    b_cho;
function P_KD() {
    ns_hdns_ma_vtcdanh_lkeCho = setInterval('P_LKE_CHO()', 200);
}
// Nhập
function P_MOI() {
    form_P_MOI(b_vungId, "KGXMN");
    GridX_thoiA(b_grlkeId);
   /* var b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt'); //Trả đối tượng theo 1 tên của vùng qua ID vùng*/
    list_P_DAT(b_drop, '1');
    var b_kytudau = "CD", b_tenbang = "DAOTAO_BAI2", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_vtcdanh_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_NTDUC_BAI2_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        P_CHUYEN_HANG();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
// Xóa
function P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == 0) { form_P_LOI('loi:Chọn bản ghi cần xóa:loi'); ns_hdns_ma_vtcdanh_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_hdns.Fs_NS_HDNS_NTDUC_BAI2_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, a_cot_ct, P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); P_CHUYEN_HANG(); }
    }
}
// CHuyển hàng
function GR_lke_RowChange() {
    if (ns_hdns_ma_vtcdanh_choAct != 0) clearTimeout(ns_hdns_ma_vtcdanh_choAct);
    ns_hdns_ma_vtcdanh_choAct = setTimeout("P_CHUYEN_HANG()", 300);
    return false;
}
function P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") {
            form_P_MOI(b_vungId, "KGXMN");
            list_P_DAT(b_ttId, '1');
            var b_kytudau = "CD", b_tenbang = "DAOTAO_BAI2", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_vtcdanh_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else {
            sns_hdns.Fs_NS_HDNS_NTDUC_BAI2_CT(form_Fs_nsd(), b_ma, P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
// Liệt kê
function P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_hdns_ma_vtcdanh_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
        b_ma_manghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NN'), b_ma_cmon_Id = form_Fs_TEN_ID(b_vungId, 'MA_CM'), b_so_idId = form_Fs_TEN_ID(b_vungId, 'so_id'), so_id_cbnnId = form_Fs_TEN_ID(b_vungId, 'so_id_cbnn');
        b_ma_nnnghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NNN'), b_ma_capbac_Id = form_Fs_TEN_ID(b_vungId, 'CBNN'), so_id_cm_Id = form_Fs_TEN_ID(b_vungId, 'so_id_cm');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_ttId = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        P_LKE();
    }
}
function P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
         
        sns_hdns.Fs_NS_HDNS_NTDUC_BAI2_LKE(form_Fs_nsd(), a_tso, a_cot, P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);

        return false;
      
    }
    catch (err) { form_P_LOI(err); }
}
function P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_vtcdanh_P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
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
function P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0; return false;//Xuất Excel
}