
var ns_hd_dg_tt_P_KD_lkeCho, ns_hd_dg_tt_P_KD_choAct = 0, ns_hd_dg_tt_choAct = 0, b_cho_control = 0, b_vungId, b_grlkeId,
    b_grnvId, b_grqhcvId, b_ma_cdId, b_slideId, b_loi_id, b_mt, b_so_idId, b_gchuId, b_thangId, b_doi = 0, b_ncdId, b_ncd2Id,
    b_bao_cao_choId, b_quan_he_trong_Id, b_nsd;
function ns_hd_dg_tt_P_KD(b_so_the) {
    ns_hd_dg_tt_P_KD_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_grnvId = form_Fs_VUNG_ID('GR_nv'),
    b_grqhcvId = form_Fs_VUNG_ID('GR_qhcv'),
    b_grlkeId = form_Fs_VUNG_ID('GR_lke'),

    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_gchuId = form_Fs_VTEN_ID('', 'gchu');
    b_nsd = b_so_the;
    ns_hd_dg_tt_P_KD_lkeCho = setInterval('ns_hd_dg_tt_P_KD_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_hd_dg_tt_P_KD_P_LKE();
            }
        }
        else {
            b_dtuong = b_dtuong.toUpperCase();
            var b_kq = a_tso[0];
            b_doi = 0;
            if (b_dtuong.toUpperCase().endsWith("MA_CD") > 0) {
                $get(b_ma_cdId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("BAO_CAO_CHO") > 0) {
                $get(b_bao_cao_choId).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
            else if (b_dtuong.toUpperCase().endsWith("QUAN_HE_TRONG") > 0) {
                $get(b_quan_he_trong_Id).value = a_tso[0];
                $get(b_gchuId).innerHTML = a_tso[1];
            }
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_dg_tt_P_KD_GR_lke_RowChange() {
    if (ns_hd_dg_tt_P_KD_choAct != 0) clearTimeout(ns_hd_dg_tt_P_KD_choAct);
    ns_hd_dg_tt_P_KD_choAct = setTimeout("ns_hd_dg_tt_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_hd_dg_tt_P_KD_P_LKE_CHO() {
    clearTimeout(ns_hd_dg_tt_P_KD_lkeCho); ns_hd_dg_tt_P_KD_P_LKE();
}

function ns_hd_dg_tt_P_MOI() {
    ns_hd_dg_tt_P_KD_P_MOI();
    return false;
}
function ns_hd_dg_tt_P_KD_P_LKE() {
    try {
        var a_cot_nv = GridX_Fas_tenCot(b_grnvId),
            a_cot_qhcv = GridX_Fas_tenCot(b_grqhcvId);
        sns_tt.Fs_NS_HD_DG_TT_LKE(b_nsd, a_cot_nv, a_cot_qhcv, ns_hd_dg_tt_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_dg_tt_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    $get(b_so_idId).value = C_NVL(a_kq[0]);
    form_P_CH_TEXT(b_vungId, a_kq[1]);
    if (a_kq[1] == "") GridX_datTrang(b_grnvId); else GridX_datBang(b_grnvId, a_kq[2]);
    if (a_kq[2] == "") GridX_datTrang(b_grqhcvId); else GridX_datBang(b_grqhcvId, a_kq[3]);
}
function ns_hd_dg_tt_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_nv = GridX_Fdt_cotGtri(b_grnvId), a_cot_qhcn = GridX_Fdt_cotGtri(b_grqhcvId), //, b_TrangKt = GridX_Fi_hangKt(b_grlkeId); //, a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
            b_so_id = CSO_SO($get(b_so_idId).value);
        sns_tt.Fs_NS_HD_DG_TT_NH(b_so_id, b_nsd, b_dt, a_cot_nv, a_cot_qhcn, ns_hd_dg_tt_P_KD_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_dg_tt_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        if (b_kq == 1) form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_hd_dg_tt_P_GUI() {
    try {b_so_id = CSO_SO($get(b_so_idId).value);
        sns_tt.Fs_NS_HD_DG_TT_GUI(b_so_id, ns_hd_dg_tt_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_dg_tt_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    else {
        if (b_kq == 1) form_P_LOI("loi:Gửi thành công:loi");
    }
    return false;
}

function ns_hd_dg_tt_P_KD_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_hang < 1) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, 1, "so_id"));;
    //var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
    if (b_so_id == null || b_so_id == "") {
        form_P_MOI("", "XGL"); GridX_datTrang(b_grnvId);
        GridX_datTrang(b_grqhcvId); $get(b_so_idId).value = 0; $get(b_ma_cdId).value = null;
    }
    else {
        var a_cot_nv = GridX_Fas_tenCot(b_grnvId),
            a_cot_qhcv = GridX_Fas_tenCot(b_grqhcvId);
        sns_tt.Fs_NS_HD_DG_TT_CT(b_so_id, a_cot_nv, a_cot_qhcv, ns_hd_dg_tt_P_KD_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_hd_dg_tt_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    var a_kq = b_kq.split('#');
    form_P_CH_TEXT(b_vungId, a_kq[0]);
    if (a_kq[1] == "") GridX_datTrang(b_grnvId); else GridX_datBang(b_grnvId, a_kq[1]);
    if (a_kq[2] == "") GridX_datTrang(b_grqhcvId); else GridX_datBang(b_grqhcvId, a_kq[2]);
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    $get(b_so_idId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    $get(b_ma_cdId).value = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_cd"));
}
function ns_hd_dg_tt_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") ns_hd_dg_tt_P_KD_P_MOI();
    else {

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_HD_DG_TT_XOA(b_so_id, a_tso, a_cot, ns_hd_dg_tt_P_KD_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}


function ns_hd_dg_tt_GR_lke_RowChange() {
    if (ns_hd_dg_tt_choAct != 0) clearTimeout(ns_hd_dg_tt_choAct);
    ns_hd_dg_tt_choAct = setTimeout("ns_hd_dg_tt_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_hd_dg_tt_P_KD_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hd_dg_tt_P_KD_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_hd_dg_tt_P_KD_P_CHUYEN_HANG();
        }
        //ns_hd_dg_tt_GR_lke_RowChange();
    }
}
function ns_hd_dg_tt_P_KD_P_MOI() {
    form_P_MOI("", "XGL"); GridX_datTrang(b_grnvId);
    GridX_datTrang(b_grqhcvId); $get(b_so_idId).value = 0; $get(b_gchuId).innerHTML = '';
    return false;
}

function ns_hd_dg_tt_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap', '');
}

function ns_hd_dg_tt_Import() {
    var b_tenf = '/App_form/ns/hdns/import_mota_cv.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MOTA_CV_IMP", "MOTA_CV_IMP", "Import mô tả công việc"]], null);
    form_P_LOI('');
    return false;
}


//function ns_hd_dg_tt_HangLen() {
//    GridX_chuyenHang(b_grctId, -1);
//    return false;
//}
//function ns_hd_dg_tt_HangXuong() {
//    GridX_chuyenHang(b_grctId, 1);
//    return false;
//}
//function ns_hd_dg_tt_ChenDong(b_dk) {
//    if (GridX_Fi_timHangC(b_grctId) < 1) {
//        var b_ctr = eval(window.name + '_P_HTOAN');
//        if (b_ctr != null) b_ctr('C');
//    }
//    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
//    return false;
//}
//function ns_hd_dg_tt_CatDong() {
//    GridX_boChon(b_grctId, 'C');
//    return false;
//}
