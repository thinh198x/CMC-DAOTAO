var b_lkeCho, b_choAct = 0, b_vungId, b_vungtkId, b_kyluongId, b_grlkeId, b_slideId, b_gocId, b_ma_ctId, b_capId, b_ten_ctId, b_ten_form, b_tmf, b_ma_dvi,
    b_imgId, b_no_anhId, b_logoId, b_cdanh_qlId, b_ten_cdanh_qlId, b_gtId, b_phong_qlId, b_all_chonId;
function ns_cc_ma_ccdv_KD() {
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'); b_slideId = $get(b_grlkeId).getAttribute('slideId');
    b_all_chonId = form_Fs_VTEN_ID('UPa_hi', 'all_chon');
    b_lkeCho = setInterval('ns_cc_ma_ccdv_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {

        GridX_taoScroll(b_grlkeId); ns_cc_ma_ccdv_P_LKE('M');
        if (b_dtuong == 'THAMSO') { b_ten_form = C_NVL(a_tso[0]); }
        else { b_ten_form = C_NVL(b_dtuong); }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_ma_ccdv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KYLUONG": b_maId = b_kyluongId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
        if (b_maTen == "KYLUONG") {
            ns_cc_ma_ccdv_P_LKE('M');
        }
        else if (b_hang < 0) form_P_LOI_DICH("loi:Mã quản lý chưa đăng ký:loi");
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ccdv_P_MOI() {
    form_P_MOI(b_vungId, "GXL"); GridX_thoiA(b_grlkeId); $get(b_gocId).focus(); return false;
}
function ns_cc_ma_ccdv_GR_lke_RowChange() {
    if (b_choAct != 0) clearTimeout(b_choAct);
    b_choAct = setTimeout("ns_cc_ma_ccdv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_ma_ccdv_P_CHUYEN_HANG() {
    try {
        var b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        if (b_ma == '') form_P_MOI(b_vungId, 'GXL');
        else sht_ma.Fs_MA_PH_CT(form_Fs_nsd(), b_ma, ns_cc_ma_ccdv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ccdv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else if (b_kq == '') form_P_MOI(b_vungId, 'GXL');
    else form_P_CH_TEXT(b_vungId, b_kq);
    GridX_doiMauInActive(b_grlkeId);
}
function ns_cc_ma_ccdv_P_LKE_CHO() {
    if (b_lkeCho != 0) clearTimeout(b_lkeCho);
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG');
    GridX_taoScroll(b_grlkeId); ns_cc_ma_ccdv_P_LKE('M');
    b_ten_form = "ns_cc_ma_ccdv";
}
function ns_cc_ma_ccdv_P_LKE(b_dk) {
    try {
        if (b_dk == 'M') {
            GridX_thoiA(b_grlkeId);
            slide_P_MOI(b_slideId);
        }
        else if (b_dk == 'T') {
            var b_dk = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'tc'));
            if (b_dk == 'C' || b_dk == '') return false;
        }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma')), b_gt = '';
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'), b_kyluong = form_Fs_TEN_GTRI(b_vungId, 'KYLUONG');
        sht_ma.Fs_NS_CCTC_QUYEN_LKE_CONGCHUAN(form_Fs_nsd(), window.name, b_dk, b_nam, b_kyluong, b_ma, b_gt, a_cot, a_tso, ns_cc_ma_ccdv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ccdv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_ma = C_NVL(GridX_Fas_layGtriA(b_grlkeId, 'ma'));
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        //GridX_luiCot(b_grlkeId, 'ten', 'cap');
        //if (b_ma != '') {
        //    var b_hang = GridX_Fi_timHangD(b_grlkeId, 'ma', b_ma);
        //    if (b_hang > 0) GridX_datA(b_grlkeId, b_hang);
        //}
        //GridX_laiMau(b_grlkeId);
        //GridX_doiMauInActive(b_grlkeId);
        //if (a_kq[1] == '' && C_NVL($get(b_timId).value) != '') form_P_LOI_DICH('loi:Không tìm thấy:loi');
    }
}
function ns_cc_ma_ccdv_P_MOI_CON() {
    var b_cap = CSO_SO(GridX_Fas_layGtriA(gridId, "cap"), -1) + 1;
    if (b_cap == 0) { form_P_LOI("loi:Chưa chọn đơn vị:loi"); }
    else { form_P_MOI(b_vungId, "GXL"); $get(b_capId).value = b_cap; $get(b_ma_ctId).value = GridX_Fas_layGtriA(gridId, "MA"); $get(b_ten_ctId).value = GridX_Fas_layGtriA(gridId, "TEN"); form_P_LOI(''); }
    return false;
}
function ns_cc_ma_ccdv_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

        a_cot_ct = GridX_Fdt_cotGtri(b_grlkeId);
        sht_ma.Fs_NS_CC_MA_CCDV_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_cot_lke, a_cot_ct, ns_cc_ma_ccdv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_cc_ma_ccdv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq)
        return false;
    }
    else {
        ns_cc_ma_ccdv_P_KTRA("KYLUONG");
    }
    form_P_LOI('loi:Ghi thành công:loi'); return false;
}
function GridX_doiMauInActive(gridId) {
    try {
        var b_hang = 0;
        var a_row = $get(gridId).rows, a_cot = GridX_Fas_tenCot(gridId);
        var a_cell, b_nen, b_chu, b_m = '', a_m, a_ctr;
        for (var b_hang = 1; b_hang < a_row.length; b_hang++) {
            a_cell = a_row[b_hang].cells
            for (var i = 1; i < a_cell.length; i++) {
                if (C_NVL(GridX_Fas_layGtri(gridId, b_hang, 'trangthai_ct')) != 'K') {
                    if (b_hang == GridX_Fi_timHangA(b_grlkeId)) {
                        b_nen = 'LightCyan'; b_chu = 'blue';
                    }
                    else {
                        b_nen = 'White'; b_chu = 'Black';
                    }

                } else {
                    b_nen = 'Red'; b_chu = 'Black';
                }
                a_ctr = a_cell[i].getElementsByTagName('input');
                if (a_ctr == null || a_ctr.length < 1) {
                    a_ctr = a_cell[i].getElementsByTagName('span');
                    if (a_ctr == null || a_ctr.length < 1) a_ctr = a_cell[i].getElementsByTagName('select');
                }
                if (a_ctr.length > 0) { a_ctr[0].style.color = b_chu; a_ctr[0].style.backgroundColor = b_nen; }
                a_cell[i].style.color = b_chu; a_cell[i].style.backgroundColor = b_nen;
            }
            b_icot = Fi_vtri_mang(a_cot, 'ccc') + 1;
            if (b_icot > 0) a_cell[b_icot].innerHTML = b_dk;
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function form_P_CHON() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang > 0 && C_NVL($get(b_gocId).value) != '') {
        var b_ma = $get(b_gocId).value, b_ten = $get(b_tenId).value;
        form_P_DAY(window.name, b_ten_form, "DAYPHONG", [b_ma, b_ten]);
        form_P_TRA_CHON('MA,TEN');
    }
    else
        form_P_LOI('loi:Bạn chưa chọn phòng ban:loi');
    return false;
}
function form_P_TRA_CHON_GRID(b_ten) {
    try {
        var a_kq = form_P_TRA_GTRI_GRID(b_ten);
        form_P_DAY(window.name, b_ten_form, "DAYPHONG", a_kq);
        form_P_DONG(window.name, a_kq);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
// Tra mang gia tri theo ten
function form_P_TRA_GTRI_GRID(b_ten) {
    try {
        var a_ten = b_ten.split(','), a_kq = [];
        for (var i = 0; i < a_ten.length; i++) {
            var a_grid = a_ten[i].split(':');
            var b_gridId = form_Fs_VUNG_ID(a_grid[0]);
            var b_hang = GridX_Fi_timHangA(b_gridId);
            a_kq[i] = GridX_Fas_layGtri(b_gridId, b_hang, a_grid[1]);
        }
        return a_kq;
    }
    catch (err) { return null; }
}
function form_dong() {
    location.reload(false);
}
function ns_cc_ma_ccdv_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
        if (b_nam != "")
            stl_cc.Fs_NS_KYLUONG_CHUNG2_LKE(form_Fs_nsd(), window.name, b_nam, ns_cc_ma_ccdv_P_NAM_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_cc_ma_ccdv_P_NAM_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        ns_cc_ma_ccdv_P_KTRA("KYLUONG");
    }
}
function CheckAll(oCheckbox, oTencot) {
    if (oTencot == "CHON") $get(b_all_chonId).value = "ALL"; else $get(b_all_chonId).value = "";
    var b_ten = "";
    if (oCheckbox.checked == true) {
        for (i = 1; i < 999; i++) {
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "TEN"));
            if (b_ten != "")
                GridX_datGtri(b_grlkeId, i, [oTencot], 'X', '');
        }
    }
    else
        for (i = 1; i < 999; i++) {
            b_ten = C_NVL(GridX_Fas_layGtri(b_grlkeId, i, "TEN"));
            if (b_ten != "") GridX_datGtri(b_grlkeId, i, [oTencot], '', '');
        }
}