var b_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timId, b_choAct = 0, b_tt = '', b_nhom_cdanhId, b_ten_nhom_cdanhId;

function daotao_ma_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_tk'), b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'ma_cd'), b_ten_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten'),
        b_lkeCho = setTimeout('P_LKE_CHO()', 200);
}
//
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "")
            return;
        b_ten_form = b_dtuong;
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("ma_cd") >= 0) {
            $get(b_nhom_cdanhId).value = b_kq;
            $get(b_ten_nhom_cdanhId).value = a_tso[1];
        }
    }
    catch (err) {
        form_P_LOI(err);
    } 
}
//lke
function P_LKE_CHO() {
    try {
        if (document.readyState === 'complete') {
            clearTimeout(b_lkeCho);
            b_vungId = form_Fs_VUNG_ID('UPa_tk');
            b_grlkeId = form_Fs_VUNG_ID('GR_lke');
            b_gocId = form_Fs_TEN_ID(b_vungId, 'MA');
            //b_ma_cchn = form_Fs_TEN_ID(b_vungId, 'MA_CCHN');
            b_slideId = $get(b_grlkeId).getAttribute('slideId');
            slide_P_MOI(b_slideId);
            P_LKE();
        }
    }
    catch (err) {
        form_P_LOI(err);
    }
}
function P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_hdns.Fs_NTDUC_B4_LKE(form_Fs_nsd(), a_tso, a_cot, P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
 ///
// CHuyển hàng
function GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("P_CHUYEN_HANG()", 300);
    return false;
}
function  P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));;
        if (b_ma == "") {
            form_P_MOI(b_vungId, "KXGLNM");
            var b_kytudau = "M", b_tenbang = "daotao_ma", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot,  P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {
            sns_hdns.Fs_NTDUC_B4_CT(form_Fs_nsd(), b_ma,  P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function  P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
//
// Sinh mã
function  P_GENCODE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
    }
}
//
// Nhập
function  P_MOI() {
    form_P_MOI(b_vungId, "KGXMN");
    GridX_thoiA(b_grlkeId);
    var b_kytudau = "M", b_tenbang = "DUC_BAI4", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot,  P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function  P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.NTDUC_BAI4_NH(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot,  P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
//
// Xóa
function P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
    if (b_ma == 0) { form_P_LOI('loi:Chọn bản ghi cần xóa:loi'); ns_hdns_ma_vtcdanh_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_hdns.NTDUC_B4_XOA(form_Fs_nsd(), b_ma, a_tso, a_cot, a_cot_ct, P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
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
//
function daotao_ma_XOA_VUNG_X() {
    try {
        form_P_MOI(b_vungId, 'X');
        form_P_LOI('');
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

function form_dong() {
    location.reload(false);
}