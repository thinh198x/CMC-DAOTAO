var ns_td_capnhat_uv_lkeCho, b_vungId, b_gchuId, ns_td_capnhat_uv_choAct = 0, b_grlkeId, b_slideId, b_vungtkId, b_so_idId, b_cho_control = 0,
    b_namId, b_ma_ycId, b_cdanhId, b_phongId, b_so_theId, b_tenId, b_ngaydId, b_thoigian_tvId, b_diadiem_lvId, b_thoigian_lvId,
    b_luong_cbId, b_thuong_cvId, b_thunhapId, b_phantram_tvId, b_trangthaiId, b_lydoId, b_nam_tkId, b_ma_tkId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C',
    b_ma_quanlyId, b_ten_quanlyid, b_ten_cdanhqlId;
function ns_td_capnhat_uv_P_KD() {
    ns_td_capnhat_uv_lkeCho = setInterval('ns_td_capnhat_uv_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_namId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_namId).focus();
            ns_td_capnhat_uv_P_LKE('K');
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
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        } else if (b_dtuong.indexOf("MA_QL") >= 0) {
            ns_thongtin_canbo(a_tso[0], "MA_QUANLY");
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
function ns_td_capnhat_uv_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "NAM": b_maId = b_namId; break;
            case "NAM_TK": b_maId = b_nam_tkId; break;
            case "MAYEUCAU_TD": b_maId = b_ma_ycId; break;
            case "MA_QUANLY": b_maId = b_ma_quanlyId; break;
        }
        var b_ma = $get(b_maId);
        if (b_maTen == "NAM") {
            var b_nam = $get(b_namId).value;
            sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TD', b_nam, ns_td_capnhat_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "NAM_TK") {
            var b_nam = $get(b_nam_tkId).value;
            sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TK_TD', b_nam, ns_td_capnhat_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "MAYEUCAU_TD") {
            var b_nam = $get(b_namId).value, b_yeucau = lke_Fs_TRA($get(b_ma_ycId));
            // lây thông tin mã tuyển dụng theo năm và theo mã
            sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_capnhat_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            // lấy thông tin ứng viên trong mã tuyển dụng
            sns_td.Fs_NS_TD_CAPNHAT_UV_LKE_DS(form_Fs_nsd(), window.name, 'DT_SO_THE', b_yeucau, ns_td_capnhat_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        } else if (b_maTen == "MA_QUANLY") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_td_capnhat_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            ns_thongtin_canbo($get(b_maId).value, b_maTen);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_capnhat_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
        $get(b_ma_quanlyId).value = ""; $get(b_ten_quanlyid).value = ""; $get(b_ten_cdanhqlId).value = "";
    } else form_P_DatGchu(b_gchuId, b_kq);
}
function ns_td_capnhat_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_td_capnhat_P_THONGTIN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_cdanhId).value = a_kq[0];
    $get(b_phongId).value = a_kq[2];
}

function ns_td_capnhat_uv_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq);
    }
    else { form_P_DatGchu(b_gchuId, b_kq); }
}
// Nhập
function ns_td_capnhat_uv_P_MOI() {
    form_P_MOI(b_vungId, "GXLK");
    GridX_thoiA(b_grlkeId);
    $get(b_namId).focus();
    return false;
}
function ns_td_capnhat_uv_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        if (b_hang > 0) {
            b_trangthai = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "trangthai_uv"));
            if (b_trangthai == 'NV') { form_P_LOI('loi:Ứng viên đã là nhân viên không thể chỉnh sửa.:loi'); return false; }
        }
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var b_nam = $get(b_nam_tkId).value, b_ma = lke_Fs_TRA($get(b_ma_tkId));

        sns_td.Fs_NS_TD_CAPNHAT_UV_NH(form_Fs_nsd(), b_so_id, b_nam, b_ma, b_TrangKt, a_dt_ct, a_cot_lke, ns_td_capnhat_uv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { throw (err); }
}
function ns_td_capnhat_uv_P_NH_KQ(b_kq) {
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
// Xóa
function ns_td_capnhat_uv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1) { form_P_LOI("loi:Chọn bản ghi:loi"); return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") { form_P_LOI("loi:Chọn bản ghi:loi"); ns_td_capnhat_uv_P_MOI(); return false; }
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_ma = lke_Fs_TRA($get(b_ma_tkId));
        sns_td.Fs_NS_TD_CAPNHAT_UV_XOA(form_Fs_nsd(), b_so_id, b_nam, b_ma, a_tso, a_cot, ns_td_capnhat_uv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_capnhat_uv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_capnhat_uv_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_capnhat_uv_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công!:loi");
    }
    return false;
}
//Chuyển hàng
function ns_td_capnhat_uv_GR_lke_RowChange() {
    if (ns_td_capnhat_uv_choAct != 0) clearTimeout(ns_td_capnhat_uv_choAct);
    ns_td_capnhat_uv_choAct = setTimeout("ns_td_capnhat_uv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_capnhat_uv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;

    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); }
    else sns_td.Fs_NS_TD_CAPNHAT_UV_CT(form_Fs_nsd(), b_so_id, ns_td_capnhat_uv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
}
function ns_td_capnhat_uv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//Liệt kê
function ns_td_capnhat_uv_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_capnhat_uv_lkeCho != 0) clearTimeout(ns_td_capnhat_uv_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_grlkeId = form_Fs_VUNG_ID('GR_lke'),

        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_vungtkId = form_Fs_VUNG_ID('UPa_tk'),
            b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ma_ycId = form_Fs_TEN_ID(b_vungId, 'ma'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'cdanh'), b_phongId = form_Fs_TEN_ID(b_vungId, 'phongban_ct'),
        b_so_theId = form_Fs_TEN_ID(b_vungId, 'so_the'), b_tenId = form_Fs_TEN_ID(b_vungId, 'ten'), b_ngaydId = form_Fs_TEN_ID(b_vungId, 'ngayd'),
        b_thoigian_tvId = form_Fs_TEN_ID(b_vungId, 'thoigian_tv'),
        b_diadiem_lvId = form_Fs_TEN_ID(b_vungId, 'diadiem_lv'), b_thoigian_lvId = form_Fs_TEN_ID(b_vungId, 'thoigian_lv'), b_ten_cdanhqlId = form_Fs_TEN_ID(b_vungId, 'cdanh_ql'),
        b_ma_quanlyId = form_Fs_TEN_ID(b_vungId, 'ma_ql'), b_ten_quanlyid = form_Fs_TEN_ID(b_vungId, 'ten_ql'), b_luong_cbId = form_Fs_TEN_ID(b_vungId, 'luong_cb'), b_thuong_cvId = form_Fs_TEN_ID(b_vungId, 'thuong_cv'),
        b_thunhapId = form_Fs_TEN_ID(b_vungId, 'thunhap'), b_phantram_tvId = form_Fs_TEN_ID(b_vungId, 'phantram_tv'), b_trangthaiId = form_Fs_TEN_ID(b_vungId, 'trangthai'),
        b_lydoId = form_Fs_TEN_ID(b_vungId, 'lydo');
        b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_ma_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_tk');
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_capnhat_uv_P_LKE('K');
    }
}
function ns_td_capnhat_uv_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_nam_tkId).value, b_ma = lke_Fs_TRA($get(b_ma_tkId));
        sns_td.Fs_NS_TD_CAPNHAT_UV_LKE(form_Fs_nsd(), b_nam, b_ma, a_tso, a_cot, ns_td_capnhat_uv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function ns_td_capnhat_uv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
function ns_td_capnhat_uv_sendMail() {
    try {
        form_P_LOI("Loi:Gửi mail thành công:loi");
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
} 
// thông tin cán bộ
function ns_thongtin_canbo(b_so_the, b_loai) {
    try {
        if (b_so_the == "") return false;
        var b_listcotcu = "", b_listcotmoi = "";
        if (b_loai == "MA_QUANLY") { b_kt_loai = "MA_QUANLY"; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH", b_listcotmoi = "MA_QL,TEN_QL,CDANH_QL" }
        else { b_kt_loai = ""; b_listcotcu = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG", b_listcotmoi = "SO_THE,HO_TEN,TEN_CDANH,TEN_PHONG" }
        hts_dungchung.Fs_THONGTIN_CANBO_HD(b_so_the, b_listcotcu, b_listcotmoi, ns_thongtin_canbo_kq, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_thongtin_canbo_kq(b_kq) {
    if (b_kq == "") {
        if (b_kt_loai == "MA_QUANLY") {
            $get(b_ten_quanlyid).value = ""; $get(b_ten_cdanhqlId).value = "";
        }

    }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
//Kiểm tra ngày tháng
function ns_td_capnhat_uv_P_NGAY(str) {
    var mdy_str = str.split('/');
    var mdy_str = mdy_str[2] + mdy_str[1] + mdy_str[0];
    var mdy_str = parseInt(mdy_str);
    var dateht = new Date();
    var m = "0" + (1 + dateht.getMonth());
    var y = parseInt("2" + dateht.getYear()) - 100;
    var d = parseInt("0" + dateht.getDate());
    var dmy = y + m + d;
    var dmy = parseInt(dmy);
    var kq = mdy_str - dmy;
    if (kq > 0) {
        return 'loi:Ngày c?p không du?c l?n hon ngày hi?n t?i:loi';
    }
    return "";
}
function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không du?c l?n hon " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không du?c l?n hon ho?c b?ng " + ten2 + " :loi";
    }
    return "";
}
function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}
function getDateNow() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var datenow = dd + '/' + mm + '/' + yyyy;
    return datenow;
}
function form_dong() {
    location.reload(false);
}
