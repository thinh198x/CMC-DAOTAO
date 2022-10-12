var ns_hdns_ma_vtcdanh_lkeCho, b_vungId, b_grlkeId, b_formsId, b_slideId, b_gocId, b_tenId, b_ma_manghe_Id, b_ma_cmon_Id, b_ma_nnnghe_Id, b_ma_capbac_Id, b_so_idId, so_id_cbnnId, so_id_cm_Id, ns_hdns_ma_vtcdanh_choAct = 0, b_ttId,
    b_cho;
function ns_hdns_ma_bai2_nhdo_P_KD() {
    ns_hdns_ma_vtcdanh_lkeCho = setInterval('ns_hdns_ma_bt2_nhdo_P_LKE_CHO()', 200);
}
// Kiểm tra
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso == 'FILE_HTOAN') {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hdns_ma_bt2_nhdo_P_LKE();
            }
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            var b_kq = a_tso[0];
            $get(b_ma_nnnghe_Id).value = b_kq;
            ns_hdns_ma_bt2_nhdo_P_LKE(b_kq);
        }
        else
            if (a_tso[0] != "") {
                //b_cho = setInterval('abc("' + a_tso[0] + '")', 500);
            }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_vtcdanh_P_KTRA(b_maTen) {
    try {
        var b_ma = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA_NN": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_NN'); break;
            case "MA_CM": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_CM'); break;
            case "MA_NL": b_ma = form_Fs_TEN_GTRI(b_vungId, 'MA_NNN'); break;
            case "MA_CB": b_ma = form_Fs_TEN_GTRI(b_vungId, 'CBNN'); break;
            case "MA": b_ma = $get(b_gocId).value; break;
        }
        if (b_maTen == "MA_NN") {
            form_P_MOI(b_vungId, "G");
            sns_hdns.Fs_NS_HDNS_MA_CM_DROP_MA(form_Fs_nsd(), b_ma, ns_hdns_ma_vtcdanh_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_CM") {
            var b_mannghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NN'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CM'),
                b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNN'), b_capbac = form_Fs_TEN_GTRI(b_vungId, 'CBNN'), b_ma = $get(b_gocId).value;
            var bid = CSO_SO($get(b_so_idId).value);
            $get(so_id_cm_Id).value = b_ma_cmon;
            if (CSO_SO($get(b_so_idId).value) > 0) { b_capbac = $get(so_id_cbnnId).value; }
            if (C_NVL(b_mannghe) != '' && C_NVL(b_ma_cmon) != '' && C_NVL(b_ma_nngiep) != '' && C_NVL(b_capbac) != '') {
                sns_hdns.Fs_NS_HDNS_MA_VTCD_SINHMA(form_Fs_nsd(), b_mannghe, b_ma_cmon, b_ma_nngiep, b_capbac, ns_hdns_ma_vtcdanh_P_KTRA_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        else if (b_maTen == "MA_NL") {
            form_P_MOI(b_vungId, "M");
            //sns_hdns.Fs_NS_HDNS_MA_CBNN_DROP(form_Fs_nsd(), b_ma, ns_hdns_ma_vtcdanh_P_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNN');
            sns_hdns.Fs_NS_HDNS_MA_VTCD_SINHMA(form_Fs_nsd(), "", "", b_ma_nngiep, "", ns_hdns_ma_vtcdanh_P_KTRA_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else if (b_maTen == "MA_CB") {
            var b_mannghe = form_Fs_TEN_GTRI(b_vungId, 'MA_NN'), b_ma_cmon = form_Fs_TEN_GTRI(b_vungId, 'MA_CM'),
                b_ma_nngiep = form_Fs_TEN_GTRI(b_vungId, 'MA_NNN'), b_capbac = form_Fs_TEN_GTRI(b_vungId, 'CBNN'), b_ma = $get(b_gocId).value;
            var bid = CSO_SO($get(b_so_idId).value);
            if (CSO_SO($get(b_so_idId).value) > 0) b_ma_cmon = $get(so_id_cm_Id).value;
            if (C_NVL(b_mannghe) != '' && C_NVL(b_ma_cmon) != '' && C_NVL(b_ma_nngiep) != '' && C_NVL(b_capbac) != '') {
                sns_hdns.Fs_NS_HDNS_MA_VTCD_SINHMA(form_Fs_nsd(), b_mannghe, b_ma_cmon, b_ma_nngiep, b_capbac, ns_hdns_ma_vtcdanh_P_KTRA_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            }
        }
        else if (b_maTen == "MA") {
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma);
            if (b_hang < 1) {
                GridX_thoiA(b_grlkeId); ns_hdns_ma_vtcdanh_P_MA_KTRA();
            }
            else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG(); }
            $get(b_tenId).focus();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_vtcdanh_P_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_hdns_ma_vtcdanh_P_KTRA_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        $get(b_gocId).value = b_kq;
        ns_hdns_ma_vtcdanh_P_MA_KTRA();
    }
}
function ns_hdns_ma_vtcdanh_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        if (b_ma != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sns_hdns.Fs_NS_HDNS_MA_VTCD_MA(form_Fs_nsd(), b_ma, b_TrangKt, a_cot, ns_hdns_ma_vtcdanh_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_vtcdanh_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    //GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) { GridX_thoiA(b_grlkeId); form_P_MOI(b_vungId, "X"); return false; }//GridX_thoiA(b_grlkeId);
    else { GridX_datA(b_grlkeId, b_hang); } ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG();
}
function ns_hdns_ma_vtcdanh_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    $get(b_gchuId).innerHTML = b_kq;
    form_P_MOI(b_vungId, "X");
}
// Nhập
function ns_hdns_ma_bt2_nhdo_P_MOI() {
    form_P_MOI(b_vungId, "KGXMN");
    GridX_thoiA(b_grlkeId);
    list_P_DAT(b_drop, 'A');
    var b_kytudau = "CD", b_tenbang = "DONH_BAI2", b_tencot = "MA";
    hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_bt2_nhdo_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    $get(b_gocId).focus();
    return false;
}
function ns_hdns_ma_bt2_nhdo_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_hdns.Fs_NS_HDNS_MA_VTCD_NH_NHDO(form_Fs_nsd(), b_TrangKt, a_dt_ct, a_cot, ns_hdns_ma_bt2_nhdo_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_hdns_ma_bt2_nhdo_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
        ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG();
        form_P_LOI('loi:Ghi thành công!:loi');
    }
    return false;
}
// Xóa
function ns_hdns_ma_bt2_nhdo_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    if (b_ma == 0) { form_P_LOI('loi:Chọn bản ghi cần xóa:loi'); ns_hdns_ma_vtcdanh_P_MOI(); }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"), a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sns_hdns.Fs_NS_HDNS_MA_VTCD_XOA_NHDO(form_Fs_nsd(), b_ma, a_tso, a_cot, a_cot_ct, ns_hdns_ma_bt2_nhdo_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_hdns_ma_bt2_nhdo_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hdns_ma_vtcdanh_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG(); }
    }
}
// Export
function ns_hdns_ma_bt2_nhdo_P_IN() {
    var b_ma_nnn = form_Fs_VTEN_ID('UPa_hi', 'c_ma_nnn');
    $get(b_ma_nnn).value = form_Fs_TEN_GTRI(form_Fs_VUNG_ID('UPa_tk'), 'list_nnn');
    var b_btn_excel = form_Fs_VTEN_ID('', 'XuatExcel');
    $get(b_btn_excel).click(); form_chay = 0; return false;//Xuất Excel
}
function ns_hdns_ma_bt2_nhdo_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'FileMau'); $get(b_btn_excel).click(); form_chay = 0; return false;//Xuất file Excel mẫu
}
function ns_hdns_ma_bt2_nhdo_FILE_Import() {//import từ file Excel
    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'NS_HDNS_MA_VTCDANH', null, "Import mã chức danh"]], null);
    form_P_LOI('');
    return false;
}

// CHuyển hàng
function ns_hdns_ma_bt2_nhdo_GR_lke_RowChange() {
    if (ns_hdns_ma_vtcdanh_choAct != 0) clearTimeout(ns_hdns_ma_vtcdanh_choAct);
    ns_hdns_ma_vtcdanh_choAct = setTimeout("ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG()", 300);
    return false;
}

//chuyen hang
function ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return false;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == 0) {
            form_P_MOI(b_vungId, "KXGLNM"); list_P_DAT(b_ttId, 'A'); return false;
            var b_kytudau = "CD", b_tenbang = "DONH_BAI2", b_tencot = "MA";
            hts_dungchung.Fs_AutoGenCode(b_kytudau, b_tenbang, b_tencot, ns_hdns_ma_vtcdanh_P_GENCODE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        else {
            sns_hdns.Fs_NS_HDNS_MA_VTCD_CT_NHDO(form_Fs_nsd(), b_ma, ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hdns_ma_bt2_nhdo_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}

// Liệt kê
function ns_hdns_ma_bt2_nhdo_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        clearTimeout(ns_hdns_ma_vtcdanh_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_drop = form_Fctr_TEN_DTUONG(b_vungId, 'tt');
        b_ma_manghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NN'), b_ma_cmon_Id = form_Fs_TEN_ID(b_vungId, 'MA_CM'), b_so_idId = form_Fs_TEN_ID(b_vungId, 'so_id'), so_id_cbnnId = form_Fs_TEN_ID(b_vungId, 'so_id_cbnn');
        b_ma_nnnghe_Id = form_Fs_TEN_ID(b_vungId, 'MA_NNN'), b_ma_capbac_Id = form_Fs_TEN_ID(b_vungId, 'CBNN'), so_id_cm_Id = form_Fs_TEN_ID(b_vungId, 'so_id_cm');
        b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_tenId = form_Fs_TEN_ID(b_vungId, 'TEN'), b_ttId = form_Fctr_TEN_DTUONG(b_vungId, 'TT');
        b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_slideId = $get(b_grlkeId).getAttribute('slideId'); slide_P_MOI(b_slideId);
        ns_hdns_ma_bt2_nhdo_P_LKE();
    }
}
function ns_hdns_ma_bt2_nhdo_P_LKE(b_nnn) {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_nnn == null) b_nnn = "";
        else b_nnn = form_Fs_TEN_GTRI(form_Fs_VUNG_ID('UPa_tk'), 'list_nnn');
        var ma_cd = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'macd')).value;
        var ten_cd = $get(form_Fs_TEN_ID(form_Fs_VUNG_ID('UPa_tk'), 'tencd')).value;
        console.log(ma_cd);
        sns_hdns.Fs_NS_HDNS_MA_VTCD_LKE_NHDO(form_Fs_nsd(), a_tso, a_cot, b_nnn, ma_cd, ten_cd, ns_hdns_ma_bt2_nhdo_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hdns_ma_bt2_nhdo_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return false; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_hdns_ma_bt2_nhdo_P_GENCODE_KQ(b_kq) {
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

function form_P_TRA_CHON_GRID(b_ten) {
    try {

        var b_grid = $get(b_grlkeId);
        var b_tbo = b_grid.getElementsByTagName('tbody')[0];
        var b_c = b_tbo.rows.length - 1;
        var b_chon = '';
        var b_kq = [], a_kq = [];
        b_kq[0] = "CMC-1M";
        var f = 1;
        b_r = b_tbo.rows[1].cloneNode(true);
        for (var i = b_c; i > 0; i--) {
            b_chon = GridX_Fb_hangChon(b_grlkeId, i);
            if (b_chon == true) {
                b_kq[f] = form_P_TRA_GTRI_GRID(b_ten, i);
                f++;
            }
        }
        var b_l = b_kq.length;
        if (b_l == 2) {
            a_kq = b_kq[1];
            form_P_DONG("ns_hdns_ma_vtcdanh", a_kq);
        }
        else {
            b_kq[0] = "CMC-2M";
            form_P_DONG("ns_hdns_ma_vtcdanh", b_kq);
        }
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten, b_hang) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}