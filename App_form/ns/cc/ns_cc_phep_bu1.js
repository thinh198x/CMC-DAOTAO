var ns_cc_phep_bu_lkeCho, b_vungId, b_aphongId, b_phong_tkId, b_akyluongId,b_grlkeId, b_kyluongId, b_namId, b_slideId, b_gocId, b_phongId, b_timId, b_denngayId, b_tungayId;
function ns_cc_phep_bu_P_KD() {
    ns_cc_phep_bu_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungTKId = form_Fs_VUNG_ID('UPa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_kyluongId = form_Fs_TEN_ID(b_vungId, 'KYLUONG'), b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'), b_phongId = form_Fs_TEN_ID(b_vungId, 'PHONG');
    b_aphongId = form_Fs_TEN_ID('UPa_hi', 'aphong'), b_akyluongId = form_Fs_TEN_ID('UPa_hi', 'akyluong');
    b_gocId = form_Fs_TEN_ID(b_vungId, 'SO_THE');
    lke_P_DAT($get(b_phongId), 'TATCA' + '{' + 'Tất cả');
    ns_cc_phep_bu_lkeCho = setInterval('ns_cc_phep_bu_P_LKE_CHO()', 200);
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        if (b_dtuong.indexOf("SO_THE") >= 0) {
            $get(b_gocId).value = b_kq; 
            ns_cc_phep_bu_P_LKE(); 
            ns_cc_phep_bu_P_CB();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_phep_bu_P_KTRA(b_maTen) {
    var b_maId = "";
    b_maTen = b_maTen.toUpperCase();
    switch (b_maTen) {
        case "TINHTRANG": b_maId = b_gocId; break;
        case "KYLUONG": b_maId = b_kyluongId; break;
        case "NAM": b_maId = b_namId; break;
    }
    if (b_maTen == "TINHTRANG") { ns_cc_phep_bu_P_LKE(); }
    else if (b_maTen == "NAM") { form_P_MOI(b_vungId, "G"); var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM'); hts_dungchung.Fs_NS_KT_NAM(window.name, b_nam); }
    else if (b_maTen == "KYLUONG") {
        var b_kyluong = lke_Fs_TRA($get(b_kyluongId));
        $get(b_aphongId).value = lke_Fs_TRA($get(b_phongId));
        $get(b_akyluongId).value = b_kyluong;
        ns_cc_phep_bu_P_LKE();
    }
}

function ns_cc_phep_bu_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_cc_phep_bu_lkeCho != 0) clearTimeout(ns_cc_phep_bu_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        ns_cc_phep_bu_P_LKE();
    }
}
function ns_cc_phep_bu_P_LKE() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId),
            b_kyluong = lke_Fs_TRA($get(b_kyluongId)); b_phong = lke_Fs_TRA($get(b_phongId)),
            b_so_the = $get(b_gocId).value;
        if (b_kyluong == "") {
            slide_P_SOTRANG(b_slideId, 0);
            return false;
        }
        stl_phep.Fs_NS_CC_NGHIBU_LKE(b_phong, b_kyluong, b_so_the, a_tso, a_cot, ns_cc_phep_bu_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_phep_bu_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    if (b_kq == "#") return;
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    return false;
}
function ns_cc_phep_bu_TINH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_phong = lke_Fs_TRA($get(b_phongId)),
        b_kyluong = lke_Fs_TRA($get(b_kyluongId)),
        b_so_the = $get(b_gocId).value;
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        stl_phep.Fs_NS_CC_NGHIBU_TINH(b_phong, b_kyluong, b_so_the, a_cot, a_tso, ns_cc_phep_bu_P_TINH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_phep_bu_P_TINH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
    form_P_LOI("loi:Tổng hợp thành công!:loi");
}  
var ns_cc_phep_bu_choAct = 0;
function ns_cc_phep_bu_GR_lke_RowChange() {
    if (ns_cc_phep_bu_choAct != 0) clearTimeout(ns_cc_phep_bu_choAct);
    ns_cc_phep_bu_choAct = setTimeout("ns_cc_phep_bu_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_cc_phep_bu_P_EXPORT() {
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var b_btn_excel = form_Fs_VTEN_ID('', 'Nhap2');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;
}
function ns_cc_phep_bu_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_the = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_the")),
        b_ngayxn = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayxn")),
        b_ngayd = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngayd"));
    stl_cc.Fs_NS_QT_NGHIPHEP_PD_CT(b_so_the, b_ngayxn, b_ngayd, ns_cc_phep_bu_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    GridX_datA(b_grlkeId, b_hang);
}
function ns_cc_phep_bu_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    $get(b_noidungId).value = b_kq;
}
function ns_cc_phep_bu_P_CB() {
    try {
        var b_so_the = $get(b_gocId).value;
        hts_dungchung.Fs_THONGTIN_CANBO(b_so_the, ns_cc_phep_bu_P_CB_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_cc_phep_bu_P_CB_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    form_P_CH_TEXT(b_vungId, b_kq);
    return false;
}
function form_dong() {
    location.reload(false);
}