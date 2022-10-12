var ns_td_pd_cdanh_td_lkeCho, b_vungId, b_grlkeId, b_tm, ns_td_pd_cdanh_td_ds_lkeCho, b_grctId, b_tinhtrangId, b_slideId, b_nam_tkId, b_ma_dx_tkId, b_namId, b_yeucautd, b_ten_cdanhId,
    b_ten_phongId, b_loaithu, b_dexuatId, b_choAct = 0, b_fdtuong, a_ftso, b_fcho = 'C';
function ns_td_pd_cdanh_td_P_KD(b_tm) {
    ns_td_pd_cdanh_td_lkeCho, ns_td_pd_cdanh_td_ds_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'); b_vungtkId = form_Fs_VUNG_ID('UPa_tk'); b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_grctId = form_Fs_VUNG_ID('GR_ct'); b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'); b_ma_dx_tkId = form_Fs_TEN_ID(b_vungtkId, 'ma_dx_tk');
    b_namId = form_Fs_TEN_ID(b_vungId, 'nam'); b_yeucautd = form_Fs_TEN_ID(b_vungId, 'ma_dx'); b_ten_cdanhId = form_Fs_TEN_ID(b_vungId, 'ten_cdanh');
    b_ten_phongId = form_Fs_TEN_ID(b_vungId, 'ten_phong');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu'); b_dexuatId = form_Fs_VTEN_ID(b_vungId, 'MA_DX');
    ns_td_pd_cdanh_td_lkeCho = setInterval('ns_td_pd_cdanh_td_P_LKE_CHO()', 200);
}
// kiem tra
function ns_td_pd_cdanh_td_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "NAM": b_maId = b_namId; break;
        case "MA_DX": b_maId = b_yeucautd; break;
    }
    if (b_maTen == "NAM") {
        var b_nam = $get(b_namId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TD', b_nam, ns_td_pd_cdanh_td_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "NAM_TK") {
        var b_nam = $get(b_nam_tkId).value;
        sns_td.Fs_NS_TD_DEXUAT_LKE_BY_NAM(form_Fs_nsd(), window.name, 'DT_MAYEUCAU_TK_TD', b_nam, ns_td_pd_cdanh_td_P_KTRA_DR_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    } else if (b_maTen == "MA_DX") {
        var b_nam = $get(form_Fs_TEN_ID(b_vungId, 'nam')).value, b_yeucau = lke_Fs_TRA($get(b_yeucautd));
        sns_td.Fs_TD_DEXUAT_BYMA(form_Fs_nsd(), b_nam, b_yeucau, ns_td_pd_cdanh_td_P_THONGTIN_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        ns_td_pd_cdanh_td_P_LKE_DS();
    }
}
function ns_td_pd_cdanh_td_P_KTRA_DR_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}

function ns_td_pd_cdanh_td_P_THONGTIN_KQ(b_kq) {
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
            ns_td_pd_cdanh_td_P_LKE_DS();
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
function ns_td_pd_cdanh_td_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_datTrang(b_grctId);
    return false;
}
function ns_td_pd_cdanh_td_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    else {
        var a_dt = form_Faa_TEXT_ROW(b_vungId);
        var b_dt_ct = GridX_Fdt_cotGtri(b_grctId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        var b_nam_tk = $get(b_nam_tkId).value, b_yeucau_tk = lke_Fs_TRA($get(b_ma_dx_tkId)), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_td.Fs_NS_TD_PD_CDANH_TD_NH(b_nam_tk, b_yeucau_tk, b_TrangKt, a_dt, b_dt_ct, a_cot_lke, ns_td_pd_cdanh_td_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
}
function ns_td_pd_cdanh_td_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_namId).focus();
        ns_td_pd_cdanh_td_P_LKE();
        form_P_LOI("loi:Nhập thành công!:loi");
    }
}

// chuyển hàng
var ns_td_pd_cdanh_td_choAct = 0;
function ns_td_pd_cdanh_td_GR_lke_RowChange() {
    if (ns_td_pd_cdanh_td_choAct != 0) clearTimeout(ns_td_pd_cdanh_td_choAct);
    ns_td_pd_cdanh_td_choAct = setTimeout("ns_td_pd_cdanh_td_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_pd_cdanh_td_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var a_cot_ct = GridX_Fas_tenCot(b_grctId);
    var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam")), b_mayeucau = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_dx"));
    $get(b_yeucautd).value = b_mayeucau;
    sns_td.Fs_NS_TD_PD_CDANH_TD_CT(b_nam, 0, b_mayeucau, a_cot_ct, ns_td_pd_cdanh_td_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_td_pd_cdanh_td_P_CHUYEN_HANG_KQ(b_kq) {
    if (b_kq == "#") {
        ns_td_pd_cdanh_td_P_MOI();
    }
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang2(b_grctId, a_kq[1]);
}
// liệt kê
function ns_td_pd_cdanh_td_P_LKE_CHO() {
    if (document.readyState == 'complete') {
        if (ns_td_pd_cdanh_td_lkeCho != 0) clearTimeout(ns_td_pd_cdanh_td_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_td_pd_cdanh_td_P_LKE('K');
    }
}
function ns_td_pd_cdanh_td_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_nam_td = $get(b_nam_tkId).value, b_yeucau_tk = lke_Fs_TRA($get(b_ma_dx_tkId));
        sns_td.Fs_NS_TD_PD_CDANH_TD_LKE(b_nam_td, b_yeucau_tk, a_tso, a_cot, ns_td_pd_cdanh_td_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_pd_cdanh_td_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}
// danh sách
function ns_td_pd_cdanh_td_P_LKE_DS() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), a_ma_dx = lke_Fs_TRA($get(b_yeucautd));
        sns_td.Fs_NS_TD_PD_CDANH_TD_LKE_DS(a_ma_dx, a_cot, ns_td_pd_cdanh_td_P_LKE_DS_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_pd_cdanh_td_P_LKE_DS_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang2(b_grctId, b_kq);
}

//function ns_td_pd_cdanh_td_P_sendMail(b_kq) {
//    var message = confirm("Bạn có chắc chắn gửi mail?");
//    if (message == false) { return false; }
//    var b_dt_ct = GridX_Fdt_cotGtri(b_grctId), b_vongthi = lke_Fs_TRA($get(b_vongthiId)), b_dexuat = lke_Fs_TRA($get(b_dexuatId));
//    sns_td.Fs_NS_TD_PD_CDANH_TD_SENDMAIL(b_vongthi, b_dexuat, b_dt_ct, ns_td_pd_cdanh_td_P_sendMail_KQ, P_LOI_CSDL, P_LOI_TGIAN);
//    return false;
//}

//function ns_td_pd_cdanh_td_P_sendMail_KQ(b_kq) {
//    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
//    else { form_P_LOI("loi:Gửi mail thành công!:loi"); }
//    return false;
//}

function form_dong() {
    location.reload(false);
}