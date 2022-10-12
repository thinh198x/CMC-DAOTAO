var ns_ctt_dxdt_ql_pd_lkeCho, ns_ctt_dxdt_ql_pd_gchuCho, b_vungtkId, b_vungId, b_grlkeId, b_grlke_xd_Id, b_slideId, b_DR_trthai_pdId, b_tt_pdId, b_lydoId, b_gchuId,
    b_so_idId, b_ttpd, ns_ctt_dxdt_ql_pd_choAct = 0, b_nsd;
function ns_ctt_dxdt_ql_pd_P_KD() {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grlke_xd_Id = form_Fs_VUNG_ID('GR_dx'),
    b_DR_trthai_pdId = form_Fs_VTEN_ID('Upa_tk', 'DR_trthai_pd'),
    b_slideId = b_grlkeId + '_slide';
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_gchuId = form_Fs_VTEN_ID('UPa_nhap', 'gchu');
    b_lydoId = form_Fs_VTEN_ID('UPa_pd', 'lydo');
    b_tt_pdId = form_Fs_TEN_ID(b_vungId, 'tt_pd');
    b_nsd = form_Fs_nsd();
    ns_ctt_dxdt_ql_pd_lkeCho = setInterval('ns_ctt_dxdt_ql_pd_P_LKE_CHO()', 200);
}
function ns_ctt_dxdt_ql_pd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_so_idId).value = 0;
    return false;
}
function ns_ctt_dxdt_ql_pd_P_PD(b_tt_pd) {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
        if (b_so_id == "") {
            form_P_LOI("Bạn phải chọn một bản ghi để phê duyệt");
        }
        else {
            var b_lydo = C_NVL($get(b_lydoId).value);
            b_ttpd = b_tt_pd;
            sns_ctt.Fs_NS_CTT_DXDT_PQ_NH_PD(b_nsd, b_so_id, b_tt_pd, b_lydo, ns_ctt_dxdt_ql_pd_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxdt_ql_pd_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_trangThaiPD = "Được phê duyệt";
        if (b_ttpd == 3) b_trangThaiPD = "Không phê duyệt";
        $get(b_tt_pdId).value = b_trangThaiPD;
        ns_ctt_dxdt_ql_pd_P_DatGchu(true, "Cập nhật trạng thái phê duyệt thành công!");
    }
    return false;
}
function ns_ctt_dxdt_ql_pd_GR_lke_RowChange() {
    if (ns_ctt_dxdt_ql_pd_choAct != 0) clearTimeout(ns_ctt_dxdt_ql_pd_choAct);
    ns_ctt_dxdt_ql_pd_choAct = setTimeout("ns_ctt_dxdt_ql_pd_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ctt_dxdt_ql_pd_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_ctt_dxdt_ql_pd_P_MOI(true);
        }
        else {
            $get(b_so_idId).value = b_so_id;
            var a_cot_lke_dx = GridX_Fas_tenCot(b_grlke_xd_Id);
            sns_ctt.Fs_NS_CTT_DXDT_QL_PD_CT(b_nsd, b_so_id, a_cot_lke_dx, ns_ctt_dxdt_ql_pd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ctt_dxdt_ql_pd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }

    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);

    var b_dongDx = CSO_SO(a_kq[1]);
    if (b_dongDx < 8) b_dongDx = 8;
    GridX_P_hangKt(b_grlke_xd_Id, b_dongDx);
    GridX_datBang(b_grlke_xd_Id, a_kq[2]);
}
function ns_ctt_dxdt_ql_pd_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ctt_dxdt_ql_pd_lkeCho); ns_ctt_dxdt_ql_pd_P_LKE(); }
}
function ns_ctt_dxdt_ql_pd_P_LKE() {
    try {
        var b_tt_pd = form_Fs_TEN_GTRI(b_vungtkId, 'DR_trthai_pd');
        if (b_tt_pd == '') b_tt_pd = -1;
        else b_tt_pd = CSO_SO(b_tt_pd);

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ctt.Fs_NS_CTT_DXDT_QL_PD_LKE(b_nsd, b_tt_pd, a_tso, a_cot, ns_ctt_dxdt_ql_pd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxdt_ql_pd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ctt_dxdt_ql_pd_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_ctt_dxdt_ql_pd_gchuCho = setInterval('ns_ctt_dxdt_ql_pd_P_DatGchu(false,".")', 2000);
    else if (ns_ctt_dxdt_ql_pd_gchuCho) clearTimeout(ns_ctt_dxdt_ql_pd_gchuCho);
}
function layTrangThaiPheDuyet() {
    var b_tt_pd = form_Fs_TEN_GTRI(b_vungtkId, 'DR_trthai_pd');
    if (b_tt_pd == '') b_tt_pd = -1;
    else b_tt_pd = CSO_SO(b_tt_pd);
    return b_tt_pd;
}
function form_dong() {
    location.reload(false);
}