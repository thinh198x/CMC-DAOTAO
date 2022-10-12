
var ns_hd_dg_tt_cbql_P_KD_lkeCho, ns_hd_dg_tt_cbql_P_KD_choAct = 0, ns_hd_dg_tt_cbql_choAct = 0, b_cho_control = 0, b_vungId, b_grlkeId,
    b_grnvId, b_grqhcvId, b_ma_cdId, b_slideId, b_loi_id, b_mt, b_so_idId, b_gchuId, b_thangId, b_doi = 0, b_ncdId, b_ncd2Id,
    b_bao_cao_choId, b_quan_he_trong_Id, b_nsd;
function ns_hd_dg_tt_cbql_P_KD() {
    ns_hd_dg_tt_cbql_P_KD_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
    b_so_theId = form_Fs_TEN_ID(b_vungId, 'SO_THE'),
    b_ten = form_Fs_TEN_ID(b_vungId, 'TEN'),
    b_ten_phong = form_Fs_TEN_ID(b_vungId, 'ten_phong'),
    b_ten_cdanh = form_Fs_TEN_ID(b_vungId, 'ten_cdanh'),
    b_ten_lhd = form_Fs_TEN_ID(b_vungId, 'ten_lhd');
    b_ngayd = form_Fs_TEN_ID(b_vungId, 'ngayd');
    b_ngayc = form_Fs_TEN_ID(b_vungId, 'ngayc');
    b_grdgiaId = form_Fs_VUNG_ID('GR_dgia');
    b_grlkeId = form_Fs_VUNG_ID('GR_lke');
    b_vungnh = form_Fs_VUNG_ID('UPa_nh');
    ns_hd_dg_tt_cbql_P_KD_lkeCho = setInterval('ns_hd_dg_tt_cbql_P_KD_P_LKE_CHO()', 200);
}

function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("THONGKE") >= 0) {
            b_cho_control = setInterval("P_cho2('" + b_kq + "')", 200);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_dg_tt_cbql_P_KTRA(b_maTen) {
    try {
        GridX_datTrang(b_grdgiaId, null, null, "yeu");
        GridX_datTrang(b_grdgiaId, null, null, "kem");
        GridX_datTrang(b_grdgiaId, null, null, "tb");
        GridX_datTrang(b_grdgiaId, null, null, "kha");
        GridX_datTrang(b_grdgiaId, null, null, "xuatsac");
        b_hang = GridX_Fi_timHangA(b_grdgiaId);
        GridX_datGtri(b_grdgiaId, b_hang, [b_maTen], ["X"]);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_dg_tt_cbql_P_KD_GR_lke_RowChange() {
    if (ns_hd_dg_tt_cbql_P_KD_choAct != 0) clearTimeout(ns_hd_dg_tt_cbql_P_KD_choAct);
    ns_hd_dg_tt_cbql_P_KD_choAct = setTimeout("ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_hd_dg_tt_cbql_P_KD_P_LKE_CHO() {
    clearTimeout(ns_hd_dg_tt_cbql_P_KD_lkeCho); ns_hd_dg_tt_cbql_P_KD_P_LKE();
}
function P_cho2(b_so_the) {
    try {
        if (b_doi == 0) {
            sns_tt.Fs_NS_TT_CBQL_DGIA_HDLD_HOI(b_so_the, Fs_NS_TT_CBQL_DGIA_HDLD_HOI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
    return false;
}

function Fs_NS_TT_CBQL_DGIA_HDLD_HOI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = b_kq.split('#');
    $get(b_so_theId).value = a_kq[0];
    $get(b_ten).value = a_kq[1];
    $get(b_ten_phong).value = a_kq[2];
    $get(b_ten_cdanh).value = a_kq[3];
    $get(b_ten_lhd).value = a_kq[4];
    $get(b_ngayd).value = a_kq[5];
    $get(b_ngayc).value = a_kq[6];
}

function ns_hd_dg_tt_cbql_P_MOI() {
    ns_hd_dg_tt_cbql_P_KD_P_MOI();
    return false;
}
function ns_hd_dg_tt_cbql_P_KD_P_LKE() {
    try {
        var a_cot_lke = GridX_Fas_tenCot(b_grlkeId);
        sns_tt.Fs_NS_HD_DG_TT_CBQL_LKE(form_Fs_nsd(), a_cot_lke, ns_hd_dg_tt_cbql_P_KD_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_dg_tt_cbql_P_KD_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    GridX_datBang(b_grlkeId, b_kq);
}
function ns_hd_dg_tt_cbql_P_NH() {
    try {
        var b_loi = form_Fs_TEXT_KTRA(b_vungId);
        if (b_loi != "") { form_P_LOI(b_loi); return false; }
        var b_dt = form_Faa_TEXT_ROW(b_vungnh), a_cot_dgia = GridX_Fdt_cotGtri(b_grdgiaId), a_cot_lke = GridX_Fdt_cotGtri(b_grlkeId);
        var b_ma_cb = $get(b_so_theId).value;
        sns_tt.Fs_NS_HD_DG_TT_CBQL_NH(form_Fs_nsd(),b_ma_cb,b_dt,a_cot_dgia, a_cot_lke, ns_hd_dg_tt_cbql_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_hd_dg_tt_cbql_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        form_P_LOI("loi:Nhập thành công:loi");
    }
    return false;
}

function ns_hd_dg_tt_cbql_P_GUI() {
    try {
        b_so_id = CSO_SO($get(b_so_idId).value);
        sns_tt.Fs_NS_HD_DG_TT_CBQL_GUI(b_so_id, ns_hd_dg_tt_cbql_P_GUI_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}

function ns_hd_dg_tt_cbql_P_GUI_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) {
        form_P_LOI(b_kq); return;
    }
    else {
        if (b_kq == 1) form_P_LOI("loi:Gửi thành công:loi");
    }
    return false;
}

function ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG() {
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
        sns_tt.Fs_NS_HD_DG_TT_CBQL_CT(b_so_id, a_cot_nv, a_cot_qhcv, ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
}
function ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG_KQ(b_kq) {
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
function ns_hd_dg_tt_cbql_P_XOA() {
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) {
        return false;
    }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "") ns_hd_dg_tt_cbql_P_KD_P_MOI();
    else {

        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sns_tt.Fs_NS_HD_DG_TT_CBQL_XOA(b_so_id, a_tso, a_cot, ns_hd_dg_tt_cbql_P_KD_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}


function ns_hd_dg_tt_cbql_GR_lke_RowChange() {
    if (ns_hd_dg_tt_cbql_choAct != 0) clearTimeout(ns_hd_dg_tt_cbql_choAct);
    ns_hd_dg_tt_cbql_choAct = setTimeout("ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG()", 300);
    return false;
}

function ns_hd_dg_tt_cbql_GR_lke_Update(b_event) {
    GridX_sott(b_grdgiaId, 'bt');
    return false;
}

function ns_hd_dg_tt_cbql_P_KD_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) ns_hd_dg_tt_cbql_P_KD_P_MOI();
        else {
            GridX_datA(b_grlkeId, b_hang); ns_hd_dg_tt_cbql_P_KD_P_CHUYEN_HANG();
        }
        //ns_hd_dg_tt_cbql_GR_lke_RowChange();
    }
}
function ns_hd_dg_tt_cbql_P_KD_P_MOI() {
    form_P_MOI("", "XGL"); GridX_datTrang(b_grnvId);
    GridX_datTrang(b_grqhcvId); $get(b_so_idId).value = 0; $get(b_gchuId).innerHTML = '';
    return false;
}

function ns_hd_dg_tt_cbql_Export() {
    __doPostBack('ctl00$ContentPlaceHolder1$Nhap', '');
}

function ns_hd_dg_tt_cbql_Import() {
    var b_tenf = '/App_form/ns/hdns/import_mota_cv.aspx';
    form_P_MO(b_tenf, window.name, ["THAMSO", [window.name, "MOTA_CV_IMP", "MOTA_CV_IMP", "Import mô tả công việc"]], null);
    form_P_LOI('');
    return false;
}


//function ns_hd_dg_tt_cbql_HangLen() {
//    GridX_chuyenHang(b_grctId, -1);
//    return false;
//}
//function ns_hd_dg_tt_cbql_HangXuong() {
//    GridX_chuyenHang(b_grctId, 1);
//    return false;
//}
//function ns_hd_dg_tt_cbql_ChenDong(b_dk) {
//    if (GridX_Fi_timHangC(b_grctId) < 1) {
//        var b_ctr = eval(window.name + '_P_HTOAN');
//        if (b_ctr != null) b_ctr('C');
//    }
//    else if (C_NVL(b_dk) == 'C') GridX_chenHang(b_grctId);
//    return false;
//}
//function ns_hd_dg_tt_cbql_CatDong() {
//    GridX_boChon(b_grctId, 'C');
//    return false;
//}
