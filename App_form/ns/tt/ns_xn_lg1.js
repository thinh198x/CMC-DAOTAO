var ns_xn_lg_lkeCho, ns_xn_lg_gchuCho, b_vungtkId, b_vungId, b_vung_phId, b_grlkeId, b_slideId, b_trthai_xnId, b_gchuId,
    b_so_idId, b_trthai_xn = 0, b_tt_xn_Id, b_ngayTraKetQua_Id, b_lyDoTuChoi_Id, ns_xn_lg_choAct = 0, b_nsd;
function ns_xn_lg_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_vung_phId = form_Fs_VUNG_ID('UPa_ph'),
    b_trthai_xnId = form_Fs_VTEN_ID('Upa_tk', 'trthai_xn'),
    b_tt_xn_Id = form_Fs_TEN_ID(b_vungId, 'tt_xn'),
    b_ngayTraKetQua_Id = form_Fs_TEN_ID(b_vungId, 'ngay_tra_kq'),
    b_lyDoTuChoi_Id = form_Fs_TEN_ID(b_vungId, 'lydo_tuchoi'),
    b_slideId = b_grlkeId + '_slide';
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_nsd = form_Fs_nsd();
    ns_xn_lg_lkeCho = setInterval('ns_xn_lg_P_LKE_CHO()', 200);
}
function ns_xn_lg_P_NH(b_tt_xn) {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        b_trthai_xn = b_tt_xn;
        var b_so_id = $get(b_so_idId).value, b_ngay_tra_kq = CNG_SO($get(b_ngayTraKetQua_Id).value), b_lydo_tuchoi = C_NVL($get(b_lyDoTuChoi_Id).value);
        if (b_tt_xn == 2 && C_NVL($get(b_ngayTraKetQua_Id).value) == '') {
            form_P_LOI("Bạn chưa nhập ngày trả kết quả");
            return false;
        }
        else if ((b_tt_xn == 3 || b_tt_xn == 4) && b_lydo_tuchoi == "") {
            form_P_LOI("Bạn chưa nhập lý do từ chối");
            return false;
        }
        sns_ctt.Fs_NS_XN_LG_NH(b_nsd, b_so_id, b_tt_xn, b_lydo_tuchoi, b_ngay_tra_kq, ns_xn_lg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_xn_lg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_ttxn = "";
        if (b_trthai_xn == 0) b_ttxn = 'Yêu cầu sửa lại';
        switch (b_trthai_xn) {
            case 2: b_ttxn = 'Được xác nhận'; break;
            case 3: b_ttxn = 'Từ chối'; break;
            case 4: b_ttxn = 'Yêu cầu sửa lại'; break;
            default: break;
        }
        GridX_datGtri(b_grlkeId, b_hang, ["tt_xn"], [b_ttxn], 'K');
        $get(b_tt_xn_Id).value = b_ttxn;
        ns_xn_lg_P_DatGchu(true, "Thao tác thành công!");
    }
    return false;
}
function ns_xn_lg_GR_lke_RowChange() {
    if (ns_xn_lg_choAct != 0) clearTimeout(ns_xn_lg_choAct);
    ns_xn_lg_choAct = setTimeout("ns_xn_lg_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_xn_lg_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_xn_lg_P_MOI(true);
        }
        else {
            $get(b_so_idId).value = b_so_id;
            sns_ctt.Fs_NS_CTT_DXXN_LG_CT(b_nsd, b_so_id, ns_xn_lg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_xn_lg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    b_trthai_xn = 0;
    if (a_kq[1] != '') b_trthai_xn = CSO_SO(a_kq[1]);
    form_P_CH_TEXT(b_vung_phId, a_kq[0]);
}
function ns_xn_lg_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) {
        clearTimeout(ns_xn_lg_lkeCho);
        ns_xn_lg_P_LKE();
    }
}
function ns_xn_lg_P_LKE() {
    try {
        var b_tt_xn = form_Fs_TEN_GTRI(b_vungtkId, 'trthai_xn');
        if (b_tt_xn == '') b_tt_xn = -1;
        else b_tt_xn = CSO_SO(b_tt_xn);

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ctt.Fs_NS_XN_LG_LKE(b_nsd, b_tt_xn, a_tso, a_cot, ns_xn_lg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_xn_lg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_xn_lg_P_IN() {
    try {
        __doPostBack('ctl00$ContentPlaceHolder1$in', '');
        form_P_LOI();
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_xn_lg_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_xn_lg_gchuCho = setInterval('ns_xn_lg_P_DatGchu(false,".")', 2000);
    else if (ns_xn_lg_gchuCho) clearTimeout(ns_xn_lg_gchuCho);
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