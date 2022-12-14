var ns_dt_dexuat_lkeCho, b_vungId, b_gchuId, b_ma_nsd, ns_dt_dexuat_choAct = 0, b_grlkeId, b_slideId, b_vungtkId, b_namId, b_so_idId,
    b_cho_control = 0, b_namId, b_khoa_dtId, b_thangId, b_tluong_dtId, b_lydoId, b_muc_tieuId, b_dia_diemId, b_mo_taId, b_trang_thaiId,
    b_trang_thai_tkId;
function ns_dt_dexuat_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ns_dt_dexuat_lkeCho = setInterval('ns_dt_dexuat_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_namId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_namId).focus();
            ns_dt_dexuat_P_LKE('K');
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) { b_doi = 0; }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dexuat_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
            case "KHOA_DT": b_maId = b_khoa_dtId; break;
            case "SO_THE": b_maId = b_namId; form_P_MOI("", "XGL"); break;
        }
        b_chonId = b_maTen;
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if (b_maTen == "NAM") {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            hts_dungchung.P_MA_KDT_NAM(window.name, b_nam, "");
        } else if (b_maTen == "KHOA_DT") {
            var b_kdt = form_Fs_TEN_GTRI(b_vungId, 'KHOA_DT');
            var b_nam = $get(b_namId).value;
            ns_dt_dexuat_NAM_TRA(b_nam, b_kdt);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dexuat_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
// Nhập
function ns_dt_dexuat_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    return false;
}
function ns_dt_dexuat_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_trang_thai = $get(b_trang_thai_tkId).value;
        var b_trangthai2 = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai2 == "CG" || b_trangthai2 == "")
            sns_dt.Fs_NS_DT_DEXUAT_NH(form_Fs_nsd(), b_so_id, b_trang_thai, b_TrangKt, a_dt_ct, a_cot_lke, ns_dt_dexuat_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đề xuất đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { throw (err); }
}
function ns_dt_dexuat_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công!:loi");
    }
    return false;
}
// XÓa
function ns_dt_dexuat_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi để xóa:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi để xóa:loi"); ns_dt_dexuat_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_trang_thai = $get(b_trang_thai_tkId).value;
        var b_trangthai2 = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai2 == "CG" || b_trangthai2 == "")
            sns_dt.Fs_NS_DT_DEXUAT_XOA(form_Fs_nsd(), b_so_id, b_trang_thai, a_tso, a_cot, ns_dt_dexuat_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đề xuất đã được gửi hoặc phê duyệt:loi");
    }
    return false;
}
function ns_dt_dexuat_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_dt_dexuat_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_dt_dexuat_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuyển hàng
function ns_dt_dexuat_GR_lke_RowChange() {
    if (ns_dt_dexuat_choAct != 0) clearTimeout(ns_dt_dexuat_choAct);
    ns_dt_dexuat_choAct = setTimeout("ns_dt_dexuat_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dt_dexuat_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;

    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else sns_dt.Fs_NS_DT_DEXUAT_CT(form_Fs_nsd(), b_so_id, ns_dt_dexuat_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_dt_dexuat_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//Liệt kê
function ns_dt_dexuat_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dt_dexuat_lkeCho != 0) clearTimeout(ns_dt_dexuat_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),

        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_khoa_dtId = form_Fs_TEN_ID(b_vungId, 'khoa_dt'), b_thangId = form_Fs_TEN_ID(b_vungId, 'thang'), b_tluong_dtId = form_Fs_TEN_ID(b_vungId, 'tluong_dt'), b_lydoId = form_Fs_TEN_ID(b_vungId, 'lydo'), b_muc_tieuId = form_Fs_TEN_ID(b_vungId, 'muc_tieu'), b_dia_diemId = form_Fs_TEN_ID(b_vungId, 'dia_diem'), b_mo_taId = form_Fs_TEN_ID(b_vungId, 'mo_ta');
        b_trang_thai_tkId = form_Fs_TEN_ID(b_vungtkId, 'trang_thai_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_dt_dexuat_P_LKE('K');
    }
}
function ns_dt_dexuat_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_trang_thai = form_Fs_TEN_GTRI(b_vungtkId, 'trang_thai_tk');
        //var b_trang_thai = $get(b_trang_thai_tkId).value;
        sns_dt.Fs_NS_DT_DEXUAT_LKE(form_Fs_nsd(), b_trang_thai, a_tso, a_cot, ns_dt_dexuat_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_dt_dexuat_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}

function ns_dt_dexuat_P_GUI() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") { form_P_LOI("loi:Chưa chọn đăng ký cần gửi:loi"); return false; }
        var b_so_the = $get(b_so_idId).value, a_cot = GridX_Fas_tenCot(b_grlkeId);
        var b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "tt"));
        if (b_trangthai == "CG" || b_trangthai == "")
            sns_dt.Fs_NS_DT_DEXUAT_GUI(form_Fs_nsd(), b_so_id, ns_dt_dexuat_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        else
            form_P_LOI("loi:Đăng ký đã được gửi hoặc phê duyệt:loi");
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_dexuat_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else form_P_LOI("loi:Gửi phê duyệt thành công:loi");
    ns_dt_dexuat_P_LKE('K');
    return false;
}
function ns_dt_khdt_nam_TRA(b_nam, b_kdt) {
    try {
        sns_dt.Fs_NS_DT_KHDT_NAM_TRA(b_nam, b_kdt, ns_dt_khdt_nam_TRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dt_khdt_nam_TRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_thoiluongId).value = a_kq[0]; $get(b_ndId).value = a_kq[1];
}
function form_dong() {
    location.reload(false);
}