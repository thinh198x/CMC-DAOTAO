var ns_td_chuyen_uv_nv_lkeCho, b_vungId, b_grlkeId, b_tm, ns_td_chuyen_uv_nv_ds_lkeCho, b_grctId, b_ngay_xacnhanId, b_namId, b_yeucau_td, b_slideId, b_grttId, b_nam, b_ma,
    b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C', ns_td_chuyen_uv_nv_choAct = 0, b_cdanhId, b_phongId;
function ns_td_chuyen_uv_nv_P_KD(b_tm) {
    ns_td_chuyen_uv_nv_lkeCho, ns_td_chuyen_uv_nv_ds_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grttId = form_Fs_VUNG_ID('GR_nh'), b_grctId = form_Fs_VUNG_ID('GR_ct'), b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_yeucau_td = form_Fs_TEN_ID(b_vungId, 'MAYEUCAU_TD'), b_namtk = form_Fs_TEN_ID('', 'namtk'), b_matk = form_Fs_TEN_ID('', 'ma_yc_tk'),
        b_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'), b_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong'),
        //b_ngay_xacnhanId = form_Fs_TEN_ID(b_vungId, 'ngay_xacnhan');
        b_slideId = b_grlkeId + '_slide';
    b_nam = form_Fs_TEN_ID(b_vungId, 'NAM');
    ns_td_chuyen_uv_nv_lkeCho = setInterval('ns_td_chuyen_uv_nv_P_LKE_CHO()', 200);
    //ns_td_chuyen_uv_nv_ds_lkeCho = setInterval('ns_td_chuyen_uv_nv_P_LKE_DS_CHO()', 300);
}
//Kiểm tra
function ns_td_chuyen_uv_nv_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "MAYEUCAU_TD": b_maId = b_yeucau_td; break;
    }
    if (b_maTen == "MAYEUCAU_TD") {
        var b_nam = $get(b_namId).value, b_yeucau = lke_Fs_TRA($get(b_yeucau_td));
        // lây thông tin mã tuyển dụng theo năm và theo mã
        sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_capnhat_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_td_chuyen_uv_nv_P_LKE_DS();
    }
}

function ns_td_capnhat_P_THONGTIN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_cdanhId).value = a_kq[0];
    $get(b_phongId).value = a_kq[2];
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        b_fdtuong = b_dtuong; a_ftso = Farr_copy(a_tso);
        if (b_fcho == 'X') P_KET_QUA_KQ();
        else b_choAct = setInterval('P_KET_QUA_KQ()', 500);
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_DX") >= 0) {
            $get(b_yeucau_td).value = b_kq;
            ns_td_chuyen_uv_nv_P_LKE_DS();
        }
        else if (b_dtuong.indexOf("TEN_PHONGBAN") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["PHONGBAN"], [a_tso[0]], 'K');
            GridX_datGtri(b_grctId, b_hang, ["TEN_PHONGBAN"], [a_tso[1]], 'K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// Nhập
function ns_td_chuyen_uv_nv_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    var a_cot = GridX_Fas_tenCot(b_grttId);
    sns_td.FS_NS_TD_THUTUC_LKE_ALL(a_cot, ns_td_thutuc_P_LKE_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_thoiA(b_grlkeId);
    return false;
}
function ns_td_chuyen_uv_nv_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var b_check = GridX_Fdt_layGtri(b_grctId, "trangthai");
        //if (b_check[0] == "NV") {
        //    form_P_LOI("Ứng viên đã là nhân viên không thể chuyển");
        //    return false;
        //}
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var b_dt_tt = GridX_Fdt_cotGtri(b_grttId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_CHUYEN_UV_NV_NH(a_dt, b_dt_ct, b_dt_tt, a_tso, a_cot_lke, ns_td_chuyen_uv_nv_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_td_chuyen_uv_nv_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Chuyển thành công:loi");
    }
    return false;
}
// Chuyển ứng viên về kho
function ns_td_chuyen_uv_kho_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {

        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var b_dt_tt = GridX_Fdt_cotGtri(b_grttId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_CHUYEN_UV_KHO_NH(a_dt, b_dt_ct, b_dt_tt, a_tso, a_cot_lke, ns_td_chuyen_uv_kho_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_td_chuyen_uv_kho_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);
        form_P_LOI("loi:Chuyển thành công:loi");
    }
    return false;
}
// Xóa
function ns_td_chuyen_uv_nv_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_nam = GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"), b_yeucau = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx");
    if (b_nam == "") ns_td_chuyen_uv_nv_P_LKE();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_td.Fs_NS_TD_CHUYEN_UV_NV_XOA(b_nam, b_yeucau, a_tso, a_cot, ns_td_chuyen_uv_nv_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_chuyen_uv_nv_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        ns_td_chuyen_uv_nv_P_MOI();
        ns_td_chuyen_uv_nv_P_LKE();
        ns_td_chuyen_uv_nv_P_LKE_DS();
    }
}

// CHuyển hàng
function ns_td_chuyen_uv_nv_GR_lke_RowChange() {
    if (ns_td_chuyen_uv_nv_choAct != 0) clearTimeout(ns_td_chuyen_uv_nv_choAct);
    ns_td_chuyen_uv_nv_choAct = setTimeout("ns_td_chuyen_uv_nv_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_thutuc_P_CHUYEN_HANG_LKE() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_ma_dx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx"));
    var a_cot = GridX_Fas_tenCot(b_grttId);
    if (a_ma_dx == "") sns_td.FS_NS_TD_THUTUC_LKE_ALL(a_cot, ns_td_thutuc_P_LKE_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    else sns_td.Fs_NS_TD_THUTUC_CT(a_ma_dx, a_cot, ns_td_thutuc_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_thutuc_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}

function ns_td_chuyen_uv_nv_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_ma_dx = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx"));
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    if (b_ma_dx == "") {
        ns_td_chuyen_uv_nv_P_MOI();
    }
    else {
        sns_td.Fs_NS_TD_CHUYEN_UV_NV_CT(b_nam, b_ma_dx, a_cot_ct, ns_td_chuyen_uv_nv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        GridX_datA(b_grlkeId, b_hang);
    }
    //$get(b_ngay_xacnhanId).value = b_ngay_xacnhan, $get(b_yeucau_td).value = b_ma_dx;
    //sns_td.Fs_NS_TD_CHUYEN_UV_NV_CT(b_ma_dx, b_ngay_xacnhan, a_cot_ct, ns_td_chuyen_uv_nv_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);

}
function ns_td_chuyen_uv_nv_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#')
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    GridX_datBang(b_grctId, a_kq[0]);
    ns_td_thutuc_P_CHUYEN_HANG_LKE();
}
// Gửi mail
function sendMail(b_tso) {
    var a_tso = Fas_ChMang(b_tso, ';');
    var b_toAddress = a_tso[0],
        b_subject = a_tso[1],
        b_body = a_tso[2];
    if (b_toAddress == "" || b_toAddress == null || b_toAddress == undefined) return false;
    else {
        sSmtpMail.SendMail(b_toAddress, b_subject, b_body, sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq); return false;
}

function ns_td_chuyen_uv_nv_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
// Liệt kê
function ns_td_chuyen_uv_nv_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_chuyen_uv_nv_lkeCho != 0) clearTimeout(ns_td_chuyen_uv_nv_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_chuyen_uv_nv_P_LKE('K');
    }

}
function ns_td_chuyen_uv_nv_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam = $get(b_namtk).value, b_ma = $get(b_matk).value;
        sns_td.Fs_NS_TD_CHUYEN_UV_NV_LKE(b_nam, b_ma, a_tso, a_cot, ns_td_chuyen_uv_nv_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_chuyen_uv_nv_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        var a_cot = GridX_Fas_tenCot(b_grttId);
        sns_td.FS_NS_TD_THUTUC_LKE_ALL(a_cot, ns_td_thutuc_P_LKE_KQ_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    b_fcho = 'X';
}
function ns_td_thutuc_P_LKE_KQ_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grttId, b_kq);
}
// Danh sách
function ns_td_chuyen_uv_nv_P_LKE_DS_CHO() {
    if ($get(b_grctId) != null) { clearTimeout(ns_td_chuyen_uv_nv_ds_lkeCho); ns_td_chuyen_uv_nv_P_LKE_DS(); }
}
function ns_td_chuyen_uv_nv_P_LKE_DS() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_nam = $get(b_namId).value, b_yeucau = lke_Fs_TRA($get(b_yeucau_td));
        sns_td.Fs_NS_TD_CHUYEN_UV_NV_LKE_DS(b_nam, b_yeucau, a_cot, ns_td_chuyen_uv_nv_P_LKE_DS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_chuyen_uv_nv_P_LKE_DS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grctId, b_kq);
}

function form_dong() {
    location.reload(false);
}