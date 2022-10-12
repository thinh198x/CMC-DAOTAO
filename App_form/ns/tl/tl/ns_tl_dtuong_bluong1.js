var ns_tl_dtuong_bluong_lkeCho, ns_tl_dtuong_bluong_choAct = 0, ns_tl_dtuong_bluong_choAct = 0, b_cho_control = 0, b_vungId, b_vungtkId,
    b_grlkeId, b_grkhoiId, b_grdtnvId, b_slideId, b_so_idId, b_gchuId, b_doi = 0, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',
    b_ma_bluong_tkId, b_khoiId;

function ns_tl_dtuong_bluong_P_KD() {
    ns_tl_dtuong_bluong_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grkhoiId = form_Fs_VUNG_ID('GR_khoi'), b_grdtnvId = form_Fs_VUNG_ID('GR_dtnv');
    b_ma_bluong_tkId = form_Fs_VTEN_ID(b_vungtkId, 'ma_bluong_tk'); b_khoiId = form_Fs_VTEN_ID(b_vungId, 'khoi');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'); b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    ns_tl_dtuong_bluong_lkeCho = setInterval('ns_tl_dtuong_bluong_P_LKE_CHO()', 200);
}

function ns_tl_dtuong_bluong_GR_lke_RowChange() {
    if (ns_tl_dtuong_bluong_choAct != 0) clearTimeout(ns_tl_dtuong_bluong_choAct);
    ns_tl_dtuong_bluong_choAct = setTimeout("ns_tl_dtuong_bluong_P_CHUYEN_HANG()", 300);
    return false;
}
// Nhập
function ns_tl_dtuong_bluong_THEM_MOI() {
   
    form_P_MOI(b_vungId, "L"); 
    GridX_datTrang(b_grdtnvId, null, null, "chon_dtnv");
    return false;
}

function ns_tl_dtuong_bluong_P_MOI() {
    $get(b_so_idId).value = 0;
    GridX_thoiA(b_grlkeId);
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grkhoiId);
    GridX_datTrang(b_grdtnvId, null, null, "chon_dtnv");
    return false;
}
function ns_tl_dtuong_bluong_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_khoi = GridX_Fdt_cotGtri(b_grkhoiId), a_cot_dtnv = GridX_Fdt_cotGtri(b_grdtnvId),
            b_so_id = CSO_SO($get(b_so_idId).value), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_ma_kyluong = form_Fs_TEN_GTRI(b_vungtkId, 'ma_bluong_tk');
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_NH(form_Fs_nsd(), b_so_id, b_dt, a_cot_khoi, a_cot_dtnv, b_ma_kyluong, b_TrangKt, a_cot, ns_tl_dtuong_bluong_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_dtuong_bluong_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        GridX_datBang(b_grlkeId, a_kq[3]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        if (b_hang > 0) { GridX_datA(b_grlkeId, b_hang); };
        form_P_LOI('loi:Nhập thành công:loi');
    }
    return false;
}
// Chuyển hàng
function ns_tl_dtuong_bluong_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, 1, "so_id"));
    if (b_so_id == null || b_so_id == "") {
        form_P_MOI("", "XGL");
        GridX_datTrang(b_grkhoiId);
        GridX_datTrang(b_grdtnvId, null, null, "chon_dtnv");
        $get(b_so_idId).value = 0;
    }
    else {
        var a_cot_khoi = GridX_Fas_tenCot(b_grkhoiId);
        var a_cot_dtnv = GridX_Fas_tenCot(b_grdtnvId);
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_CT(form_Fs_nsd(), b_so_id, a_cot_khoi, a_cot_dtnv, ns_tl_dtuong_bluong_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_tl_dtuong_bluong_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[2] == "") GridX_datTrang(b_grkhoiId); else { GridX_datBang(b_grkhoiId, a_kq[2]); }
    //if (a_kq[4] == "") GridX_datTrang(b_grdtnvId); else { GridX_datBang(b_grdtnvId, a_kq[4]); }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
}
// Xóa
function ns_tl_dtuong_bluong_P_XOA() {

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));

    if (b_hang < 1) {
        form_P_LOI('loi:Bạn phải chọn một bản ghi để xóa:loi');
        return false;
    }
    else {
        var message = confirm("Bạn có chắc chắn xóa không?");
        if (message == false) {
            return false;
        }
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma_bluong = form_Fs_TEN_GTRI(b_vungtkId, 'ma_bluong_tk');
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_XOA(form_Fs_nsd(), b_so_id, b_ma_bluong, a_tso, a_cot, ns_tl_dtuong_bluong_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    return false;
}
function ns_tl_dtuong_bluong_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Xóa thành công!:loi");
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_tl_dtuong_bluong_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_tl_dtuong_bluong_P_CHUYEN_HANG(); }
    }
}

// Liệt kê
function ns_tl_dtuong_bluong_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_tl_dtuong_bluong_lkeCho != 0) clearTimeout(ns_tl_dtuong_bluong_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_tl_dtuong_bluong_lke_data();
        ns_tl_dtuong_bluong_P_LKE('K');
    }
}
function ns_tl_dtuong_bluong_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_ma_bluong = form_Fs_TEN_GTRI(b_vungtkId, 'ma_bluong_tk');
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_LKE(form_Fs_nsd(), b_ma_bluong, a_tso, a_cot, ns_tl_dtuong_bluong_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_dtuong_bluong_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    b_fcho = 'X';
}

function ns_tl_dtuong_bluong_them() {
    try {
        var b_khoi = lke_Fs_TRA($get(b_khoiId)), b_ten_khoi = $get(b_khoiId).value;
        if (b_khoi == "") {
            form_P_LOI("loi:Chưa chọn khối để thêm:loi");
            return false;
        }

        var a_cot_khoi = GridX_Fas_tenCot(b_grdtnvId);
        var b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_dtnv = GridX_Fdt_cotGtri(b_grdtnvId), a_cot_khoi = GridX_Fdt_cotGtri(b_grkhoiId);
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_THEM(form_Fs_nsd(), b_khoi, b_ten_khoi, a_cot_dtnv, a_cot_khoi, ns_tl_dtuong_bluong_them_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_dtuong_bluong_them_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "") GridX_datTrang(b_grkhoiId); else { GridX_datBang(b_grkhoiId, a_kq[0]); }
}
// Lấy dữ liệu vào lưới khối và đối tượng nhân viên
function ns_tl_dtuong_bluong_lke_data() {
    try {

        var a_cot_dtnv = GridX_Fas_tenCot(b_grdtnvId);
        sns_tl.Fs_NS_TL_DTUONG_BLUONG_LKE_DATA(form_Fs_nsd(), a_cot_dtnv, ns_tl_dtuong_bluong_lke_data_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_tl_dtuong_bluong_lke_data_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (a_kq[0] == "") GridX_datTrang(b_grdtnvId); else { GridX_datBang(b_grdtnvId, a_kq[0]); }
}

function ns_tl_dtuong_bluong_P_HangLen() {
    GridX_chuyenHang(b_grkhoiId, -1);
    return false;
}
function ns_tl_dtuong_bluong_P_HangXuong() {
    GridX_chuyenHang(b_grkhoiId, 1);
    return false;
}
function ns_tl_dtuong_bluong_P_chenDong(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grkhoiId);
    if (b_hang < 1) return;
    GridX_chenHang(b_grkhoiId, b_hang, 1);
    return false;
}
function ns_tl_dtuong_bluong_P_CatDong() {
    GridX_boChon(b_grkhoiId, 'C');
    return false;
}

function form_dong() {
    location.reload(false);
}