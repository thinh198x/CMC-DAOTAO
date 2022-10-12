var ns_ctt_dxxn_ct_lkeCho, ns_ctt_dxxn_ct_gchuCho, b_vungtkId, b_vungId, b_vung_phId, b_grlkeId, b_slideId, b_trthai_xnId, b_gchuId,
    b_so_idId, b_so_the, b_nhap_id, b_xoa_id, b_guixn_id, b_trthai_xn = 0, b_nsd, ns_ctt_dxxn_ct_choAct = 0;
function ns_ctt_dxxn_ct_P_KD(b_so_the_cb) {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_vung_phId = form_Fs_VUNG_ID('UPa_ph'),
    b_trthai_xnId = form_Fs_VTEN_ID('Upa_tk', 'trthai_xn'),
    
    b_slideId = b_grlkeId + '_slide';
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');

    b_nhap_id = form_Fs_VTEN_ID('UPa_nhap', 'nhap'),
    b_xoa_id = form_Fs_VTEN_ID('UPa_nhap', 'xoa'),
    b_guixn_id = form_Fs_VTEN_ID('UPa_nhap', 'guixn');

    b_so_the = b_so_the_cb;
    if (b_so_the == "") {
        form_P_LOI("Không tồn tại số thẻ nhân viên"); return;
    }
    b_nsd = form_Fs_nsd();
    ns_ctt_dxxn_ct_lkeCho = setInterval('ns_ctt_dxxn_ct_P_LKE_CHO()', 200);
}
function ns_ctt_dxxn_ct_P_MOI() {
    form_P_MOI(b_vungId, "XL");
    $get(b_so_idId).value = 0;
    b_trthai_xn = 0;
    $get(b_vung_phId).style.display = "none";
    ns_ctt_dxxn_ct_P_TTCB();
    return false;
}
function ns_ctt_dxxn_ct_P_NH() {
    if (b_trthai_xn != 0 && b_trthai_xn != 4) {
        form_P_LOI("Không thao tác được do đã gửi xin xác nhận");
        return false;
    }
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }

        var b_so_id = $get(b_so_idId).value;
        var b_tt_xn = layTrangThaiPheDuyet();
        var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
        sns_ctt.Fs_NS_CTT_DXXN_CT_NH(b_nsd, b_so_id, b_so_the, b_tt_xn, b_TrangKt, a_dt_ct, a_cot_lke, ns_ctt_dxxn_ct_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxxn_ct_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).value = a_kq[4];
        ns_ctt_dxxn_ct_P_DatGchu(true, "Cập nhật thành công!");
    }
    return false;
}
function ns_ctt_dxxn_ct_P_XOA() {
    if (b_trthai_xn != 0 && b_trthai_xn != 4) {
        form_P_LOI("Không thao tác được do đã gửi xin xác nhận");
        return false;
    }
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_ctt_dxxn_ct_P_MOI(true);
        }
        else {
            var b_tt_xn = layTrangThaiPheDuyet();
            var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
            sns_ctt.Fs_NS_CTT_DXXN_CT_XOA(b_nsd, b_so_id, b_so_the, b_tt_xn, a_tso, a_cot, ns_ctt_dxxn_ct_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxxn_ct_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);

        ns_ctt_dxxn_ct_P_MOI();
        ns_ctt_dxxn_ct_P_DatGchu(true, "Xóa thành công!");
    }
}
function ns_ctt_dxxn_ct_GR_lke_RowChange() {
    if (ns_ctt_dxxn_ct_choAct != 0) clearTimeout(ns_ctt_dxxn_ct_choAct);
    ns_ctt_dxxn_ct_choAct = setTimeout("ns_ctt_dxxn_ct_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ctt_dxxn_ct_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_ctt_dxxn_ct_P_MOI(true);
        }
        else {
            $get(b_so_idId).value = b_so_id;
            sns_ctt.Fs_NS_CTT_DXXN_CT_CT(b_nsd, b_so_id, ns_ctt_dxxn_ct_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ctt_dxxn_ct_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    b_trthai_xn = 0;
    if (a_kq[1] != '') b_trthai_xn = CSO_SO(a_kq[1]);
    if (b_trthai_xn > 1) {
        form_P_CH_TEXT(b_vung_phId, a_kq[0]);
        $get(b_vung_phId).style.display = "inline";
    }
    else
        $get(b_vung_phId).style.display = "none";
}
function ns_ctt_dxxn_ct_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) {
        clearTimeout(ns_ctt_dxxn_ct_lkeCho);
        ns_ctt_dxxn_ct_P_LKE();
        ns_ctt_dxxn_ct_P_TTCB();
    }
}
function ns_ctt_dxxn_ct_P_LKE() {
    try {
        var b_tt_xn = form_Fs_TEN_GTRI(b_vungtkId, 'trthai_xn');
        if (b_tt_xn == '') b_tt_xn = -1;
        else b_tt_xn = CSO_SO(b_tt_xn);

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ctt.Fs_NS_CTT_DXXN_CT_LKE(b_nsd, b_so_the, b_tt_xn, a_tso, a_cot, ns_ctt_dxxn_ct_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxxn_ct_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ctt_dxxn_ct_P_TTCB() {
    try {
        sns_ctt.Fs_NS_CTT_DXXN_CT_TTCB(b_nsd, b_so_the, ns_ctt_dxxn_ct_P_TTCB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ctt_dxxn_ct_P_TTCB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
}
function ns_ctt_dxxn_ct_P_PD() {
    if (b_trthai_xn != 0 && b_trthai_xn != 4) {
        form_P_LOI("Không thao tác được do đã gửi xin xác nhận");
        return false;
    }
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để gửi xác nhận");
            return false;
        }
        else {
            sns_ctt.Fs_NS_CTT_DXXN_CT_NH_XN(b_nsd, b_so_id, 1, ns_ctt_dxxn_ct_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxxn_ct_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_trthai_xn = 1;
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ngayGui = new Date(); b_ngayGui = (b_ngayGui.getDate() < 10 ? ("0" + b_ngayGui.getDate()) : b_ngayGui.getDate()) + "/" + (b_ngayGui.getMonth() + 1) + "/" + b_ngayGui.getFullYear();
        GridX_datGtri(b_grlkeId, b_hang, ["ngaygui_xn", "tt_xn"], [b_ngayGui, "Chờ xác nhận"], 'K');
        ns_ctt_dxxn_ct_P_DatGchu(true, "Gửi đề xuất xác nhận thành công!");
    }
    return false;
}
function ns_ctt_dxxn_ct_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_ctt_dxxn_ct_gchuCho = setInterval('ns_ctt_dxxn_ct_P_DatGchu(false,".")', 2000);
    else if (ns_ctt_dxxn_ct_gchuCho) clearTimeout(ns_ctt_dxxn_ct_gchuCho);
}
function thietLapButton() {
    $get(b_nhap_id).disabled = b_trthai_xn != 0;
    $get(b_xoa_id).disabled = b_trthai_xn != 0;
    $get(b_guixn_id).disabled = b_trthai_xn != 0;
}
function layTrangThaiPheDuyet() {
    var b_tt_xn = form_Fs_TEN_GTRI(b_vungtkId, 'trthai_xn');
    if (b_tt_xn == '') b_tt_xn = -1;
    else b_tt_xn = CSO_SO(b_tt_xn);
    return b_tt_xn;
}
function form_dong() {
    location.reload(false);
}