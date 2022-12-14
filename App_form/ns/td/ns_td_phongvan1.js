var ns_td_phongvan_lkeCho, b_vungId, b_grlkeId, b_tm, ns_td_phongvan_ds_lkeCho, b_grctId, b_tinhtrangId, b_slideId, b_nam_tkId, b_ma_dx_tkId, b_namId, b_yeucautd, b_ngay_xeplich, b_ten_cdanhId,
    b_ten_phongId, b_loaithu, b_vongthiId, b_dexuatId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_td_phongvan_P_KD(b_tm) {
    ns_td_phongvan_lkeCho, ns_td_phongvan_ds_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'), b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'), b_ma_dx_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_dx_tk'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_yeucautd = form_Fs_TEN_ID(b_vungId, 'ma_dx'), b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'),
        b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'phongban_ct'),
        b_ngay_xeplich = form_Fs_TEN_ID(b_vungId, 'ngay_xeplich'), b_loaithu = form_Fs_TEN_ID(b_grctId, 'loaithu');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_vongthiId = form_Fs_VTEN_ID(b_vungId, 'vong_thi'), b_dexuatId = form_Fs_VTEN_ID(b_vungId, 'MA_DX');;
    ns_td_phongvan_lkeCho = setInterval('ns_td_phongvan_P_LKE_CHO()', 200);
}
// kiem tra
function ns_td_phongvan_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "NAM": b_maId = b_namId; break;
        case "MA_DX": b_maId = b_yeucautd; break;
    }
    if (b_maTen == "NAM") {
        var b_nam = $get(b_namId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TD', b_nam, ns_td_phongvan_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "NAM_TK") {
        var b_nam = $get(b_nam_tkId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TK_TD', b_nam, ns_td_phongvan_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "VONG_THI") {
        var b_nam = $get(b_namId).value, b_yeucau = lke_Fs_TRA($get(b_yeucautd));
        sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_phongvan_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_td_phongvan_P_LKE_DS();
    }
}
function ns_td_phongvan_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function ns_td_phongvan_P_THONGTIN_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    $get(b_ten_cdanhId).value = a_kq[0];
    $get(b_ten_phongId).value = a_kq[2];
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
            $get(b_yeucautd).value = b_kq;
            $get(b_gchuId).innerHTML = a_tso[1];
            ns_td_phongvan_P_LKE_DS();
        } else if (b_dtuong.indexOf("NGUOI_PV") >= 0) {
            var b_hang = GridX_Fi_timHangA(b_grctId);
            if (b_hang < 0) return;
            GridX_datGtri(b_grctId, b_hang, ["nguoi_pv"], a_tso[1], 'K');
            
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_KET_QUA_KQ() {
    if (b_fcho != 'X') return;
    b_dtuong = b_fdtuong.toUpperCase(); a_tso = Farr_copy(a_ftso); b_kq = a_tso[0];
    clearInterval(b_choAct);
}
// nhập
function ns_td_phongvan_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    return false;
}
function ns_td_phongvan_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        var b_nam_tk = $get(b_nam_tkId).value, b_yeucau_tk = lke_Fs_TRA($get(b_ma_dx_tkId)), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_td.Fs_NS_TD_PHONGVAN_NH(b_nam_tk, b_yeucau_tk, b_TrangKt, a_dt, b_dt_ct, a_cot_lke, ns_td_phongvan_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_td_phongvan_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
        ns_td_phongvan_P_LKE();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
}
// xóa
function ns_td_phongvan_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }

    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma_dx = lke_Fs_TRA($get(b_yeucautd)), b_ngay_xl = $get(b_ngay_xeplich).value, b_vongthi = lke_Fs_TRA($get(b_vongthiId));
    if (b_ma_dx == "" || b_ngay_xl == "") ns_td_phongvan_P_LKE();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam_tk = $get(b_nam_tkId).value, b_yeucau_tk = lke_Fs_TRA($get(b_ma_dx_tkId));
        sns_td.Fs_NS_TD_PHONGVAN_XOA(b_ma_dx, b_vongthi, b_ngay_xl, b_nam_tk, b_yeucau_tk, a_tso, a_cot, ns_td_phongvan_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_phongvan_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        form_P_LOI("loi:Xóa thành công!:loi");
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_phongvan_P_MOI();
        ns_td_phongvan_P_LKE();
        ns_td_phongvan_P_LKE_DS();
    }
}
// chuyển hàng
var ns_td_phongvan_choAct = 0;
function ns_td_phongvan_GR_lke_RowChange() {
    if (ns_td_phongvan_choAct != 0) clearTimeout(ns_td_phongvan_choAct);
    ns_td_phongvan_choAct = setTimeout("ns_td_phongvan_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_phongvan_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_ngay_xl = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_xeplich")), b_mayeucau = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx")), b_vongthi = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "vong_thi"));
    $get(b_ngay_xeplich).value = b_ngay_xl, $get(b_yeucautd).value = b_mayeucau;
    sns_td.Fs_NS_TD_PHONGVAN_CT(b_mayeucau, b_ngay_xl, b_vongthi, a_cot_ct, ns_td_phongvan_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_td_phongvan_P_CHUYEN_HANG_KQ(b_kq) {
    if (b_kq == "#") {
        ns_td_phongvan_P_MOI();
    }
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang2(b_grctId, a_kq[1]);
}
// liệt kê
function ns_td_phongvan_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_phongvan_lkeCho != 0) clearTimeout(ns_td_phongvan_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_phongvan_P_LKE('K');
    }
}
function ns_td_phongvan_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_nam_td = $get(b_nam_tkId).value, b_yeucau_tk = lke_Fs_TRA($get(b_ma_dx_tkId));
        sns_td.Fs_NS_TD_PHONGVAN_LKE(b_nam_td, b_yeucau_tk, a_tso, a_cot, ns_td_phongvan_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_phongvan_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
// danh sách
function ns_td_phongvan_P_LKE_DS() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId),
            b_ma_dx = lke_Fs_TRA($get(b_yeucautd));
        var b_vongthi = lke_Fs_TRA($get(b_vongthiId));
        sns_td.Fs_NS_TD_PHONGVAN_LKE_DS(b_ma_dx, b_vongthi, a_cot, ns_td_phongvan_P_LKE_DS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_phongvan_P_LKE_DS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang2(b_grctId, b_kq);
}
// phê duyệt
function ns_td_phongvan_P_PHEDUYET() {
    var b_dt_ct = GridX_Fdt_cotGtri(b_grlkeId);
    //sns_td.Fs_NS_TD_CV_ONLINE_PHEDUYET(b_dt_ct, ns_td_phongvan_P_PHEDUYET_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_td_phongvan_P_PHEDUYET_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_LOI("loi:Hoàn thành xếp phỏng vấn!:loi");
    return false;
}
function ns_td_phongvan_P_XEM() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    form_P_MO("ns_td_hsuv_online.aspx", null, ["KQ", [b_so_id]]);
    return false;
}
function ns_td_dxuat_CHON() {
    var j = 0;
    var b_ktra = GridX_Fdt_cotGtri(b_grlkeId, ["chon", "so_id"]);
    var b_gt = b_ktra[1];
    for (var i = 0; i < b_gt.length; i++) {
        if (b_gt[i][0] == "X") { j++; }
    }
    if (j == 0) {
        for (var i = 0; i < b_gt.length; i++) {
            if (b_gt[i][1] != "") {
                GridX_datGtri(b_grlkeId, i + 1, ["chon"], ["X"]);
            }
        }
    }
    else {
        for (var i = 0; i < b_gt.length; i++) {
            GridX_datGtri(b_grlkeId, i + 1, ["chon"], [""]);
        }
    }
}
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
//Thuong send mail  

function ns_td_phongvan_P_sendMail(b_kq) {
    var message = confirm("Bạn có chắc chắn gửi mail?");
    if (message == false) { return false; }
    var b_dt_ct = GridX_Fdt_cotGtri(b_grctId), b_vongthi = lke_Fs_TRA($get(b_vongthiId)), b_dexuat = lke_Fs_TRA($get(b_dexuatId));
    sns_td.Fs_NS_TD_PHONGVAN_SENDMAIL(b_vongthi, b_dexuat, b_dt_ct, ns_td_phongvan_P_sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}

function ns_td_phongvan_P_sendMail_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else { form_P_LOI("loi:Gửi mail thành công!:loi"); }
    return false;
}
// them dong vao luoi
function ns_td_phongvan_HangLen() {
    GridX_chuyenHang(b_grctId, -1);
    return false;
}
function ns_td_phongvan_HangXuong() {
    GridX_chuyenHang(b_grctId, 1);
    return false;
}
function ns_td_phongvan_ChenDong(b_dk) {
    if (GridX_Fi_timHangC(b_grctId) < 1) {
        var b_ctr = eval(window.name + '_P_HTOAN');
        if (b_ctr != null) b_ctr('C');
    }
    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
    return false;
}
function ns_td_phongvan_CatDong() {
    GridX_boChon(b_grctId, 'C');
    return false;
}
function ns_td_phongvan_P_HUY() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        //sns_td.Fs_ns_td_phongvan_HUY(a_dt, b_dt_ct, a_cot_lke, ns_td_phongvan_P_HUY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_td_phongvan_P_HUY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        GridX_datBang(b_grlkeId, b_kq);
        var b_ngay_tiepnhan = $get(b_ngay_xeplich).value;
        var b_hang = GridX_Fi_timHangD(b_grlkeId, "ngay_tiepnhan", b_ngay_tiepnhan);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        else return false;
        form_P_LOI("loi:Không tiếp nhận nhân viên thành công:loi");
    }
    return false;
}

function form_dong() {
    location.reload(false);
}