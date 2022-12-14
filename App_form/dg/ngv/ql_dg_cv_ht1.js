var ql_dg_cv_ht_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_lngId, ql_dg_cv_ht_choAct, b_namId, b_ky_dgId, b_ma, b_kq_ht,
    b_kq_chung, b_xl_dg, b_hs_dg, b_grctId, b_ma_nsd, b_namId_tk, b_ky_dgId_tk, b_trangthaiId_tk, b_choAct = 0, b_fcho = 'C', b_trangthaiId;
function ql_dg_cv_ht_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ql_dg_cv_ht_lkeCho, ql_dg_cv_ht_choAct = 0,
    ql_dg_cv_ht_lkeCho = setInterval('ql_dg_cv_ht_P_LKE_CHO()', 200);
}
// Mới
function ql_dg_cv_ht_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    return false;
}
//Nhập
function ql_dg_cv_ht_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            else form_P_LOI("loi:Vui lòng chọn bản ghi đã có sẵn:loi");
            var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
            if (b_trangthai == "1" || b_trangthai == "2") { form_P_LOI("loi:Chọn đúng trạng thái bản ghi:loi"); return false; }
            //var b_nam = lke_Fs_TRA($get(b_namId)); var b_kydg = lke_Fs_TRA($get(b_ky_dgId)); var b_manv = lke_Fs_TRA($get(b_ma));
            //if (b_nam == "" || b_kydg == "" || b_manv == "") form_P_LOI("loi:Chưa chọn năm hoặc kỳ đánh giá, nhân viên:loi");
            sdg.Fs_QL_DG_CV_HT_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, ql_dg_cv_ht_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function ql_dg_cv_ht_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        GridX_datGtriA(b_grlkeId, 'kq_dg', $get(b_xl_dg).value);
        form_P_LOI("Nhập thành công");
        if (b_kq == "") return false;
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        //form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function ql_dg_cv_ht_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa :loi'); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));

    var b_nam = lke_Fs_TRA($get(b_namId)); var b_kydg = lke_Fs_TRA($get(b_ky_dgId)); var b_manv = $get(b_ma).value;
    if (b_nam == "" || b_kydg == "" || b_manv == "") { form_P_LOI("loi:Chưa chọn năm hoặc kỳ đánh giá, nhân viên:loi"); return false; }
    if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    else form_P_LOI("loi:Vui lòng chọn bản ghi đã có sẵn:loi");
    var check = confirm("Bạn có chắc chắn xóa hay không");
    if (check == false) return false;
    if (b_so_id == "") ql_dg_cv_ht_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_QL_DG_CV_HT_XOA(form_Fs_nsd(), b_so_id, b_nam, b_kydg, b_manv, b_trangthai_tk, a_tso, a_cot, ql_dg_cv_ht_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ql_dg_cv_ht_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ql_dg_cv_ht_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ql_dg_cv_ht_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function ql_dg_cv_ht_GR_lke_RowChange() {
    if (ql_dg_cv_ht_choAct != 0) clearTimeout(ql_dg_cv_ht_choAct);
    ql_dg_cv_ht_choAct = setTimeout("ql_dg_cv_ht_P_CHUYEN_HANG()", 300);
    return false;
}
function ql_dg_cv_ht_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_QL_DG_CV_HT_CT(form_Fs_nsd(), b_so_id, a_cot_ct, ql_dg_cv_ht_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function ql_dg_cv_ht_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else { GridX_datBang(b_grctId, a_kq[1]); GridX_sott(b_grctId, 'stt'); }
        return false;
    }
}
// Liệt kê
function ql_dg_cv_ht_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ql_dg_cv_ht_lkeCho != 0) clearTimeout(ql_dg_cv_ht_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_ma = form_Fs_TEN_ID(b_vungId, 'ma');
        b_kq_ht = form_Fs_TEN_ID(b_vungId, 'kq_ht');
        b_kq_chung = form_Fs_TEN_ID(b_vungId, 'kqchung');
        b_xl_dg = form_Fs_TEN_ID(b_vungId, 'xeploai_danhgia');
        b_hs_dg = form_Fs_TEN_ID(b_vungId, 'heso_danhgia');
        b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai');
        b_namId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'nam1'),
        b_ky_dgId_Upa_tk = form_Fs_TEN_ID(b_vungtkId, 'ky_dg1'),
        b_so_idId = form_Fs_VTEN_ID('', 'so_id');
        b_namId_tk = form_Fs_VTEN_ID('', 'nam_tk_an');
        b_ky_dgId_tk = form_Fs_VTEN_ID('', 'ky_dg_tk_an');
        b_trangthaiId_tk = form_Fs_VTEN_ID('', 'trangthai_tk_an');
        b_trangthai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trangthai_tk'),
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ql_dg_cv_ht_P_LKE('K');
        ql_dg_cv_ht_P_CB();
    }
}
function ql_dg_cv_ht_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M') slide_P_MOI(b_slideId);
        var b_trangthai_tk = lke_Fs_TRA($get(b_trangthai_tkId));
        var b_nam_tk = lke_Fs_TRA($get(b_namId_Upa_tk));
        b_nam_tk = CSO_SO(b_nam_tk, 0);
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dgId_Upa_tk));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_QL_DG_CV_HT_LKE(form_Fs_nsd(), b_trangthai_tk, b_nam_tk, b_ky_dg_tk, a_tso, a_cot, ql_dg_cv_ht_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ql_dg_cv_ht_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
//Gửi
function ql_dg_cv_ht_P_XACNHAN() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_hang < 1 || b_so_id == "") { form_P_LOI("loi:Chưa chọn bản ghi cần xác nhận:loi"); return false; }

        var a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai"));
        if (b_trangthai != "0") { form_P_LOI("loi:Bản ghi đã qua xem xét, không thể xác nhận:loi"); return false; }
        else
            sdg.Fs_QL_DG_CV_HT_XACNHAN(form_Fs_nsd(), b_so_id, '1', ql_dg_cv_ht_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ql_dg_cv_ht_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        GridX_datGtriA(b_grlkeId, 'kq_dg', $get(b_xl_dg).value);
        GridX_datGtriA(b_grlkeId, 'trangthai', '1'); GridX_datGtriA(b_grlkeId, 'ten_trangthai', 'Đã xem xét');

        form_P_LOI("loi:Gửi xác nhận thành công:loi");
        ql_dg_cv_ht_P_LKE('K');
    }
    return false;
}

//
function ql_dg_cv_ht_P_CB() {
    try {
        var b_ma_nv = b_ma_nsd;
        sdg.Fs_THONGTIN_CANBO111(b_ma_nv, ql_dg_cv_ht_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ql_dg_cv_ht_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function ql_dg_cv_ht_P_NAM(b_dk) {
    try {
        if (b_dk == 'N') var b_nam = lke_Fs_TRA($get(b_namId));
        if (b_dk == 'F') var b_nam = lke_Fs_TRA($get(b_namId_Upa_tk));
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, ktra, ql_dg_cv_ht_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function ql_dg_cv_ht_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}
function ktra_dulieu() {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_sott = GridX_Fas_layGtri(b_grctId, b_hang, "stt");
    if (b_sott == "") GridX_thoiA(b_grctId, b_hang);
}
var b_kq = 0; var b_kq_nv_tong = 0; var b_kq_ql_tong = 0;
function xulydulieu(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    var b_tyle_ht_nv = GridX_Fas_layGtri(b_grctId, b_hang, "tyle_ht_nv");
    var b_trongso = GridX_Fas_layGtri(b_grctId, b_hang, "trongso");
    var b_tyle_ht_ql = GridX_Fas_layGtri(b_grctId, b_hang, "tyle_ht_ql");
    if (b_trongso == "") return false;


    var b_tylenv = CSO_SO(b_tyle_ht_nv, 0);
    var b_tso = CSO_SO(b_trongso, 0);
    var b_tyleql = CSO_SO(b_tyle_ht_ql, 0);


    if (b_dk == "ts") {
        var tyleXtrongso_nv = SO_CSO(Math.round((b_tylenv / 100) * b_tso));
        var tyleXtrongso_ql = SO_CSO(Math.round(b_tyleql / 100) * b_tso);
        GridX_datGtriA(b_grctId, 'tyle_ht_tso_nv', tyleXtrongso_nv);
        GridX_datGtriA(b_grctId, 'tyle_ht_tso_ql', tyleXtrongso_ql);
    }
    if (b_dk == "nv") {
        var tyleXtrongso_nv = SO_CSO(Math.round((b_tylenv / 100) * b_tso));
        GridX_datGtriA(b_grctId, 'tyle_ht_tso_nv', tyleXtrongso_nv);
    }
    if (b_dk == "ql") {
        var tyleXtrongso_ql = SO_CSO(Math.round((b_tyleql / 100) * b_tso));
        GridX_datGtriA(b_grctId, 'tyle_ht_tso_ql', tyleXtrongso_ql);
    }
    // Tinh tong cac cot
    a_cot_ct = GridX_Fdt_cotGtri(b_grctId);
    for (var i = 0; i < 10; i++) {
        var b_kq_nv = a_cot_ct[1][i][6];
        //var b_ts = a_cot_ct[1][i][2];
        if (CSO_SO(b_kq_nv, 0) > 0) {
            b_kq_nv_tong = b_kq_nv_tong + CSO_SO(b_kq_nv, 0);
        }
        var b_kq_ql = a_cot_ct[1][i][12];
        if (CSO_SO(b_kq_ql, 0) > 0) {
            b_kq_ql_tong = b_kq_ql_tong + CSO_SO(b_kq_ql, 0);
        }
    }
    //b_kq = b_kq_nv_tong + b_kq_ql_tong; 
    $get(b_kq_chung).value = b_kq_ql_tong;
    $get(b_kq_ht).value = b_kq_ql_tong;
    //Lay he so va xep loai.
    sdg.Fs_QL_DG_CV_HT_LAY_HESO_XEPLOAI(form_Fs_nsd(), b_kq_ql_tong, ql_dg_cv_ht_P_LAY_HESO_XEPLOAI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    b_kq = 0; b_kq_nv_tong = 0; b_kq_ql_tong = 0;
}
function ql_dg_cv_ht_P_LAY_HESO_XEPLOAI_KQ(b_kq) {
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_hs_dg).value = a_kq[0];
    $get(b_xl_dg).value = a_kq[1];
}
//Xuất excel
function ns_hdct_P_IN() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_namId_tk).value = lke_Fs_TRA($get(b_namId_Upa_tk));
    $get(b_ky_dgId_tk).value = lke_Fs_TRA($get(b_ky_dgId_Upa_tk));
    $get(b_trangthaiId_tk).value = lke_Fs_TRA($get(b_trangthai_tkId));
    $get(b_btn_excel).click(); form_chay = 0;
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}