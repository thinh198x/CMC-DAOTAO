var dg_dm_mdg_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_slidecdId, b_gocId, b_lngId, dg_dm_mdg_choAct, b_nhom_cdanhId, b_cdanhId, b_nam_tkId,
    b_namId, b_ngay_adId, b_ky_dg_tkId, b_cdanh_tkId, b_ky_dgId, b_sttId, b_ma_cauhoiId, b_nd_cauhoiId,
b_choAct = 0, b_fcho = 'C';
function dg_dm_mdg_P_KD() {
    dg_dm_mdg_lkeCho = setInterval('dg_dm_mdg_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "" || a_tso == 'FILE_HTOAN') {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                dg_dm_mdg_P_LKE('K');
            }
        }
        else if (b_dtuong == "TAI_IMPORT") {
            dg_dm_mdg_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}

function dg_dm_mdg_P_KTRA(b_maTen) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grctId);
        if (b_hang > 0) b_values = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang, b_maTen));
        var b_hang_d = GridX_Fi_timHangD(b_grctId, b_maTen, b_values);
        if (b_hang_d > 0 && b_hang != b_hang_d) {
            form_P_LOI("loi:Mã câu hỏi đã tồn tại:loi");
            return false;
        }
        return true;
    }
    catch (err) { form_P_LOI(err); }
}
// Mới
function dg_dm_mdg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    $get(b_namId).value = "";
    $get(b_ky_dgId).value = "";
    $get(b_nhom_cdanhId).value = "";
    //$get(b_cdanhId).value = "";
    //GridX_datTrang(b_grcdanh);
    return false;
}
//Nhập
function dg_dm_mdg_P_NH() {
    try {
        var x = dg_dm_mdg_P_KTRA('MA_CAUHOI');
        if (x == false) return false;
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId),
                //a_cot_cdanh = GridX_Fdt_cotGtri(b_grcdanh),
                a_tso = slide_Faobj_TUDEN(b_slideId);
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sdg.Fs_DG_DM_MDG_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_dm_mdg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_dm_mdg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
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
function dg_dm_mdg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa :loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
    var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
    var b_doituong_dg_tk = lke_Fs_TRA($get(b_doituong_dg_tkId));
    var b_cdanh_tk = lke_Fs_TRA($get(b_cdanh_tkId));
    if (b_so_id == "") dg_dm_mdg_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_MDG_XOA(form_Fs_nsd(), b_so_id, b_nam_tk, b_ky_dg_tk, b_doituong_dg_tk, b_cdanh_tk, a_tso, a_cot, dg_dm_mdg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_mdg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_dm_mdg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_dm_mdg_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function dg_dm_mdg_GR_lke_RowChange() {
    if (dg_dm_mdg_choAct != 0) clearTimeout(dg_dm_mdg_choAct);
    dg_dm_mdg_choAct = setTimeout("dg_dm_mdg_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_dm_mdg_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_DM_MDG_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_dm_mdg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_dm_mdg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL");
        // drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        //Gr chức danh Son fix:
        //var b_cdanh = GridX_Fas_layGtri(b_grcdanh, 1, 'cdanh');
        //if (b_cdanh != "") {
        //    var dong = $get(b_grcdanh).rows.length;
        //    for (var i = 2; i <= dong; i++) {
        //        GridX_datGtri(b_grcdanh, i, "cdanh", "");
        //    }
        //    //GridX_datTrang(b_grcdanh); GridX_datBang(b_grcdanh, a_kq[1]);
        //}
        return false;
    }
}
// Liệt kê
function dg_dm_mdg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_dm_mdg_lkeCho != 0) clearTimeout(dg_dm_mdg_lkeCho);
        dg_dm_mdg_lkeCho, dg_dm_mdg_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grctId = form_Fs_VUNG_ID('GR_ct'),
        //b_grcdanh = form_Fs_VUNG_ID('GR_cdanh'),
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'),
        b_ky_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'ky_dg_tk'),
        b_cdanh_tkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'),
        b_doituong_dg_tkId = form_Fs_TEN_ID(b_vungtkId, 'doituong_dg_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ngay_adId = form_Fs_TEN_ID(b_vungId, 'ngay_ad'),
        b_nhom_cdanhId = form_Fs_TEN_ID(b_vungId, 'nhom_cdanh'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_sttId = form_Fs_TEN_ID(b_grctId, 'stt'),
        b_ma_cauhoiId = form_Fs_TEN_ID(b_grctId, 'ma_cauhoi'),
        b_nd_cauhoiId = form_Fs_TEN_ID(b_grctId, 'nd_cauhoi'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        //b_slidecdId = $get(b_grcdanh).getAttribute('slideId');
        dg_dm_mdg_P_LKE('K');
    }
}
function dg_dm_mdg_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var b_nam_tk = lke_Fs_TRA($get(b_nam_tkId));
        var b_kytk_t = $get(b_ky_dg_tkId).value;
        var b_ky_dg_tk = lke_Fs_TRA($get(b_ky_dg_tkId));
        var b_doituong_dg_tk = lke_Fs_TRA($get(b_doituong_dg_tkId));
        var b_cdanh_tk = lke_Fs_TRA($get(b_cdanh_tkId));
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_MDG_LKE(form_Fs_nsd(), b_nam_tk, b_ky_dg_tk, b_doituong_dg_tk, b_cdanh_tk, a_tso, a_cot, dg_dm_mdg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_mdg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        //GridX_datBang(b_grcdanh, "");
        //slide_P_SOTRANG(b_slidecdId,0);
    }
    b_fcho = 'X';
}

function dg_dm_mdg_P_NAM() {
    try {
        var b_nam = lke_Fs_TRA($get(b_namId));
        var ktra = "DT_KY_DG";
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam, ktra, dg_dm_mdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_dm_mdg_P_NAM_TK() {
    try {
        var ktra = "DT_KY_DG_TK";
        var b_nam_tk = form_Fs_TEN_GTRI(b_vungtkId, 'nam_tk');
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name, b_nam_tk, ktra, dg_dm_mdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_dm_mdg_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
}
// lấy chức danh theo nhóm chức danh
function dg_dm_mdg_P_NHOM_CDANH(b_ctrId, b_kieu, b_vtri) {
    try {
        var b_nhom_cdanh = lke_Fs_TRA($get(b_nhom_cdanhId));
        var b_ktra = "DT_CDANH";
        if (b_nhom_cdanh != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_CDANH(form_Fs_nsd(), b_nhom_cdanh, a_tso[3], window.name, b_ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (ex) { form_P_LOI(err); }
}
function dg_cv_thang_Update(b_event) {
    GridX_sott(b_grctId, 'stt');
    return false;
}
function dg_dm_mdg_HangLen() {
    GridX_chuyenHang(b_grcdanh, -1);
    return false;
}
function dg_dm_mdg_HangXuong() {
    GridX_chuyenHang(b_grcdanh, 1);
    return false;
}
function dg_dm_mdg_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grcdanh) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grcdanh);
    return false;
}
function dg_dm_mdg_CatDong() {
    GridX_boChon(b_grcdanh, 'C');
    return false;
}

function dg_dm_mdg_cauhoi_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function dg_dm_mdg_cauhoi_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function dg_dm_mdg_cauhoi_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function dg_dm_mdg_cauhoi_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}

function dg_dm_mdg_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}
function dg_dm_mdg_FILE_Import() {
    var b_tenf = '/App_form/ns/ma/file_import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'THIETLAP_MAUDANHGIA_IMP', null, "Import thiết lập mẫu đánh giá"]], null);
    form_P_LOI('');
    return false;
}
function form_dong() {
    location.reload(false);
}