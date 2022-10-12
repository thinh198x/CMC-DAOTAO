var ns_ctt_dxdt_lkeCho, ns_ctt_dxdt_gchuCho, b_vungtkId, b_vungId, b_grlkeId, b_vung_phId, b_slideId, b_tt_pdId, b_namId, b_gchuId, b_kdt_htId, b_ma_kdtId, b_kdtId,
    b_so_idId, b_so_the, b_nhap_id, b_xoa_id, b_guipd_id, b_tt_pd, ns_ctt_dxdt_choAct = 0, b_nsd;
function ns_ctt_dxdt_P_KD(b_so_the_cb) {
    b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'), b_vung_phId = form_Fs_VUNG_ID('UPa_ph'),
    b_tt_pdId = form_Fs_VTEN_ID('Upa_tk', 'trthai_pd'),
    b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'),
    b_kdt_htId = form_Fs_TEN_ID(b_vungId, 'kdt_ht'),
    b_ma_kdtId = form_Fs_TEN_ID(b_vungId, 'ma_kdt'),
    b_kdtId = form_Fs_TEN_ID(b_vungId, 'kdt');
    b_slideId = b_grlkeId + '_slide';
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id'),
    b_gchuId = form_Fs_VTEN_ID('UPa_gchu', 'gchu');
    b_nhap_id = form_Fs_VTEN_ID('UPa_nhap', 'nhap'),
    b_xoa_id = form_Fs_VTEN_ID('UPa_nhap', 'xoa'),
    b_guipd_id = form_Fs_VTEN_ID('UPa_nhap', 'guipd');
    b_so_the = b_so_the_cb;
    if (b_so_the == "") {
        form_P_LOI("Không tồn tại số thẻ nhân viên"); return;
    }
    b_nsd = form_Fs_nsd();
    ns_ctt_dxdt_lkeCho = setInterval('ns_ctt_dxdt_P_LKE_CHO()', 200);
}
function ns_ctt_dxdt_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_kdt_htId).value = "C";
    $get(b_so_idId).value = 0;
    b_tt_pd = 0;
    $get(b_vung_phId).style.display = "none";
    thietLapButton();
    return false;
}
function ns_ctt_dxdt_P_NH() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }

    if (!kiemTraNamThang() || !kiemTraKhoaDaoTao())
        return false;

    var b_so_id = $get(b_so_idId).value;
    var b_tt_pd = layTrangThaiPheDuyet();
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sns_ctt.Fs_NS_CTT_DXDT_NH(b_nsd, b_so_id, b_so_the, b_tt_pd, b_TrangKt, a_dt_ct, a_cot_lke, ns_ctt_dxdt_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function ns_ctt_dxdt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_so_idId).value = a_kq[4];
        ns_ctt_dxdt_P_DatGchu(true, "Cập nhật thành công!");
    }
    return false;
}
function ns_ctt_dxdt_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") {
        ns_ctt_dxdt_P_MOI(true);
    }
    else {
        var b_tt_pd = layTrangThaiPheDuyet();
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ctt.Fs_NS_CTT_DXDT_XOA(b_nsd, b_so_id, b_so_the, b_tt_pd, a_tso, a_cot, ns_ctt_dxdt_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ctt_dxdt_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
        GridX_datBang(b_grlkeId, a_kq[1]);

        ns_ctt_dxdt_P_MOI();
        ns_ctt_dxdt_P_DatGchu(true, "Xóa thành công!");
    }
}
function ns_ctt_dxdt_GR_lke_RowChange() {
    if (ns_ctt_dxdt_choAct != 0) clearTimeout(ns_ctt_dxdt_choAct);
    ns_ctt_dxdt_choAct = setTimeout("ns_ctt_dxdt_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_ctt_dxdt_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
        if (b_so_id == "") {
            ns_ctt_dxdt_P_MOI(true);
        }
        else {
            $get(b_so_idId).value = b_so_id;
            sns_ctt.Fs_NS_CTT_DXDT_CT(b_nsd, b_so_id, ns_ctt_dxdt_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ctt_dxdt_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    b_tt_pd = 0;
    if (a_kq[1] != '') b_tt_pd = CSO_SO(a_kq[1]);
    if (b_tt_pd > 1) {
        form_P_CH_TEXT(b_vung_phId, a_kq[0]);
        $get(b_vung_phId).style.display = "inline";
    }
    else
        $get(b_vung_phId).style.display = "none";
    thietLapButton();
}
function ns_ctt_dxdt_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(ns_ctt_dxdt_lkeCho); ns_ctt_dxdt_P_LKE(); }
}
function ns_ctt_dxdt_P_LKE() {
    try {
        var b_tt_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trthai_pd');
        if (b_tt_pd == '') b_tt_pd = -1;
        else b_tt_pd = CSO_SO(b_tt_pd);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_ctt.Fs_NS_CTT_DXDT_LKE(b_nsd, b_so_the, b_tt_pd, a_tso, a_cot, ns_ctt_dxdt_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
    return false;
}
function ns_ctt_dxdt_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function ns_ctt_dxdt_P_DM_KDT() {
    try{
        var b_nam = form_Fs_TEN_GTRI('UPa_ct', 'NAM');
        sns_ctt.Fs_NS_DT_MA_KDT_LKE_NAM(b_nsd, b_nam, 'ns_ctt_dxdt', ns_ctt_dxdt_P_DM_KDT_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_ctt_dxdt_P_DM_KDT_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
}
function ns_ctt_dxdt_P_PD() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") {
        form_P_LOI("Bạn phải chọn một bản ghi để gửi phê duyệt");
    }
    else {
        sns_ctt.Fs_NS_CTT_DXDT_GUI_PD(b_nsd, b_so_id, 1, ns_ctt_dxdt_P_PD_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function ns_ctt_dxdt_P_PD_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        b_tt_pd = 1;
        thietLapButton();
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        GridX_datGtri(b_grlkeId, b_hang, ["TT_PD"], ["Chờ phê duyệt"], 'K');
        ns_ctt_dxdt_P_DatGchu(true, "Gửi phê duyệt thành công!");
    }
    return false;
}
function ns_ctt_dxdt_P_KDT_HT() {
    var kdt_ht = $get(b_kdt_htId).value;
    if (kdt_ht == 'C')
        $get(b_kdtId).value = '';
    else
        lke_P_IdDAT(b_ma_kdtId, '');
}
function ns_ctt_dxdt_P_DatGchu(show, gchu) {
    form_P_DatGchu(b_gchuId, gchu);
    if (show) ns_ctt_dxdt_gchuCho = setInterval('ns_ctt_dxdt_P_DatGchu(false,".")', 2000);
    else if (ns_ctt_dxdt_gchuCho) clearTimeout(ns_ctt_dxdt_gchuCho);
}
function thietLapButton() {
    $get(b_nhap_id).disabled = b_tt_pd != 0;
    $get(b_xoa_id).disabled = b_tt_pd != 0;
    $get(b_guipd_id).disabled = b_tt_pd != 0;
}
function kiemTraNamThang() {
    var b_nam = form_Fs_TEN_GTRI('UPa_ct', 'NAM'), b_thang = form_Fs_TEN_GTRI('UPa_ct', 'THANG');
    if (b_nam == '') {
        form_P_LOI('Bạn chưa chọn năm'); return false;
    }
    if (b_thang == '') {
        form_P_LOI('Bạn chưa chọn tháng mong muốn đào tạo'); return false;
    }
    return true;
}
function kiemTraKhoaDaoTao() {
    var kdt_ht = $get(b_kdt_htId).value;
    var kdt;
    if (kdt_ht == 'C') {
        // check DM KDT
        kdt = form_Fs_TEN_GTRI('UPa_ct', 'ma_kdt');
    }
    else {
        // check KDT user
        kdt = C_NVL($get(b_kdtId).value);
    }
    if (kdt == '') {
        form_P_LOI(kdt_ht == 'C' ? "Bạn chưa chọn khóa đào tạo" : "Bạn chưa nhập khóa đào tạo");
        return false;
    }
    return true;
}
function layTrangThaiPheDuyet() {
    var b_tt_pd = form_Fs_TEN_GTRI(b_vungtkId, 'trthai_pd');
    if (b_tt_pd == '') b_tt_pd = -1;
    else b_tt_pd = CSO_SO(b_tt_pd);
    return b_tt_pd;
}
function form_dong() {
    location.reload(false);
}