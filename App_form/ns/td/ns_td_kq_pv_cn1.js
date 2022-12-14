var ns_td_kq_pv_cn_lkeCho, b_vungId, b_sl_cantuyenId, b_cho_control, ns_td_kq_pv_cn_choAct, b_grlkeId, b_gocId, b_sl_dexuat_tuyenId, b_slideId, b_tuoi_tuId, b_grmtId, b_tuoi_denId,
    b_trangthaiyc_pdId,  b_cdanhId, b_gchuId, b_so_idId, b_nam_tkId, b_yeucau_tkId, b_cdanh_tkId;
function ns_td_kq_pv_cn_P_KD() {
    b_cho_control = 0, ns_td_kq_pv_cn_choAct = 0,
    ns_td_kq_pv_cn_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_grmtId = form_Fs_VUNG_ID('Gr_mt'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE'); b_cdanh_tkId = form_Fs_TEN_ID(b_vungtkId, 'cdanh_tk'), b_nam_tkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk'),
    b_yeucau_tkId = form_Fs_TEN_ID(b_vungtkId, 'yeucau_tk');
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_moiId = form_Fs_VTEN_ID('', 'moi');
    b_slideId = b_grlkeId + '_slide';
    ns_td_kq_pv_cn_lkeCho = setInterval('ns_td_kq_pv_cn_P_LKE_CHO()', 200);
}
function P_cho(b_so_the, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_gocId).value = b_so_the;
            $get(b_gchuId).innerHTML = b_ten;
            $get(b_gocId).focus();
            ns_td_kq_pv_cn_P_LKE();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("CDANH_TK") >= 0) {
            $get(b_cdanh_tkId).value = a_tso[0];
            $get(b_cdanh_tkId).focus();
        }
        if (b_dtuong.indexOf("THAMSO") >= 0) {
            b_cho_control = setInterval("P_cho('" + a_tso[0] + "','" + a_tso[1] + "','" + a_tso[2] + "')", 200);
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Kiểm tra
function ns_td_kq_pv_cn_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_t = b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "CDANH": b_maId = b_cdanhId; break;
        }

        var b_ma = $get(b_maId);
        if (b_maTen != "CO_GAP" && b_maTen != "CO_KEHOACH_NAM")
            if (b_ma == null || C_NVL(b_ma.value) == "") return;

    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kq_pv_cn_P_DatGchu(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        if (b_t == 'SO_THE') {
            form_P_DatGchu(b_gchuId, b_kq); $get(b_tenId).value = b_kq;
        }
    }
}
// Nhập
function ns_td_kq_pv_cn_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    GridX_thoiA(b_grlkeId);
    $get(b_so_idId).value = "0";
    $get(b_gocId).focus();
    return false;
}
function ns_td_kq_pv_cn_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId);
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        var a_gt_mt = GridX_Fdt_cotGtri(b_grmtId);
        var a_cot_mt = GridX_Fas_tenCot(b_grmtId);
        sns_td.Fs_NS_TD_KQ_PV_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt_ct, a_gt_mt, a_tso, a_cot_lke, a_cot_mt, ns_td_kq_pv_cn_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { throw (err); }
}
function ns_td_kq_pv_cn_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        if (a_kq[1] != "") GridX_datBang(b_grlkeId, a_kq[1]);
        if (a_kq[2] != "") GridX_datBang(b_grmtId, a_kq[2]);
        form_P_LOI("Nhập thành công");
        $get(b_gocId).focus();
    }
    return false;
}
// Xóa
function ns_td_kq_pv_cn_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"),
        b_nam = $get(b_nam_tkId).value, b_yeucau = $get(b_yeucau_tkId).value, b_cdanh = $get(b_cdanh_tkId).value;
    if (b_so_id == "") ns_td_kq_pv_cn_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_ct = GridX_Fas_tenCot(b_grmtId);
        sns_td.Fs_NS_TD_KQ_PV_XOA(form_Fs_nsd(), b_so_id, b_nam, b_yeucau, b_cdanh, a_tso, a_cot, a_cot_ct, ns_td_kq_pv_cn_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_td_kq_pv_cn_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_td_kq_pv_cn_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); ns_td_kq_pv_cn_P_CHUYEN_HANG(); }
        form_P_LOI("Xóa thành công");
    }
}
// Chuyển hàng
function ns_td_kq_pv_cn_GR_lke_RowChange() {
    if (ns_td_kq_pv_cn_choAct != 0) clearTimeout(ns_td_kq_pv_cn_choAct);
    ns_td_kq_pv_cn_choAct = setTimeout("ns_td_kq_pv_cn_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_td_kq_pv_cn_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    var a_cot = GridX_Fas_tenCot(b_grlkeId), a_cot_ct = GridX_Fas_tenCot(b_grmtId);
    if (b_so_id == "0" || b_so_id == "") form_P_MOI(b_vungId, "XGL");
    else sns_td.Fs_NS_TD_KQ_PV_CT(form_Fs_nsd(), b_so_id, a_cot, a_cot_ct, ns_td_kq_pv_cn_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    form_P_GridX_TEXT(b_vungId, b_grlkeId);
    $get(b_so_idId).value = b_so_id;
}
function ns_td_kq_pv_cn_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] != "") GridX_datBang(b_grmtId, a_kq[1]);
}
// Liệt kê
function ns_td_kq_pv_cn_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_td_kq_pv_cn_lkeCho); ns_td_kq_pv_cn_P_LKE(); }
}
function ns_td_kq_pv_cn_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId), a_cot_ct = GridX_Fas_tenCot(b_grmtId),
            b_nam = $get(b_nam_tkId).value, b_yeucau = $get(b_yeucau_tkId).value, b_cdanh = $get(b_cdanh_tkId).value;
        sns_td.Fs_NS_TD_KQ_PV_LKE(form_Fs_nsd(), b_nam, b_yeucau, b_cdanh, a_tso, a_cot, a_cot_ct, ns_td_kq_pv_cn_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_td_kq_pv_cn_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    GridX_datBang(b_grmtId, a_kq[2]);
    $get(b_gocId).focus();
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
function form_dong() {
    location.reload(false);
}
