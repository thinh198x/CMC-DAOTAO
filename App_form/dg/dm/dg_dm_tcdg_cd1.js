var dg_dm_tcdg_cd_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_donviId, b_donvi_tkId, b_nam_tkId, b_lngId, dg_dm_tcdg_cd_choAct, b_nhom_cdanhId, b_cdanhId, b_capbacId
b_choAct = 0, b_fcho = 'C';
function dg_dm_tcdg_cd_P_KD() {
    dg_dm_tcdg_cd_lkeCho, dg_dm_tcdg_cd_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_grctId = form_Fs_VUNG_ID('GR_ct'), b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'), b_namId = form_Fs_TEN_ID(b_vungId, 'nam'), b_ngay_adId = form_Fs_TEN_ID(b_vungId, 'ngay_ad'), b_cdanhId = form_Fs_TEN_ID(b_vungId, 'NCD'),
    b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
    b_ncdanhId = form_Fs_VTEN_ID('UPa_hi', 'Anncdanh'),
   // b_cdanhId = form_Fs_VTEN_ID('UPa_hi', 'Ancdanh');
    b_slideId = b_grlkeId + '_slide';
    dg_dm_tcdg_cd_lkeCho = setInterval('dg_dm_tcdg_cd_P_LKE_CHO()', 200);
}

function dg_dm_tcdg_cd_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KY_DG": b_maId = b_so_idId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        else if (b_maTen == "KY_DG") {
            var b_hang = GridX_Fi_timHangD(b_grlkeId, "ky_dg", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dg_dm_tcdg_cd_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dg_dm_tcdg_cd_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
}
function P_cho(b_so_the, b_ten) {
    try {
        if (b_doi == 0) {
            $get(b_so_theId).value = b_so_the;
            $get(b_tenId).value = b_ten;
            $get(b_gchuId).innerhtml = b_ten;
            $get(b_so_theId).focus();
            b_doi = 1;
            clearTimeout(b_cho_control);
        }
    }
    catch (err) {
        b_doi = 0;
    }
}

// Nhập
function dg_dm_tcdg_cd_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_ky_dgId).value = ""
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    $get(b_namId).value = "";
    return false;
}
function dg_dm_tcdg_cd_P_NH() {
    try {
        //var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        //if (b_nam == "") { form_P_LOI("loi:Phải chọn Năm:loi"); return false; }
        //var b_ky_dg = form_Fs_TEN_GTRI(b_vungId, 'ky_dg');
        //if (b_ky_dg == "") { form_P_LOI("loi:Phải chọn Kỳ đánh giá:loi"); return false; }
        var b_ngay_dg = form_Fs_TEN_GTRI(b_vungId, 'ngay_ad');
        if (b_ngay_dg == "") { form_P_LOI("loi:Phải chọn Ngày đánh giá:loi"); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId); //var b_hang1 = GridX_Fi_timHangA(b_grctId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            //var b_soid_ct = C_NVL(GridX_Fas_layGtri(b_grctId, b_hang1, "so_idct"));
            sdg.Fs_DG_DM_TCDG_CD_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_dm_tcdg_cd_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_dm_tcdg_cd_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        //var a_kq = Fas_ChMang(b_kq, '#');
        //slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        //form_P_LOI("loi:Nhập thành công:loi");
        var a_kq = b_kq.split('#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        form_P_LOI("loi:Nhập thành công:loi");
    }
    b_fcho = 'X';
}
// Xóa
function dg_dm_tcdg_cd_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);

    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_hang < 1 || b_so_id == "") {
        form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false;
    } else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_TCDG_CD_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, dg_dm_tcdg_cd_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_tcdg_cd_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_dm_tcdg_cd_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_dm_tcdg_cd_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function dg_dm_tcdg_cd_GR_lke_RowChange() {
    if (dg_dm_tcdg_cd_choAct != 0) clearTimeout(dg_dm_tcdg_cd_choAct);
    dg_dm_tcdg_cd_choAct = setTimeout("dg_dm_tcdg_cd_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_dm_tcdg_cd_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_DM_TCDG_CD_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_dm_tcdg_cd_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_dm_tcdg_cd_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        //var b_hang = GridX_Fi_timHangA(b_grlkeId);
        //var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam")), b_ky_dg = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "KY_DG")), b_ngay_ad = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ngay_ad"));
        //$get(b_namId).value = b_nam, $get(b_ky_dgId).value = b_ky_dg, $get(b_ngay_adId).value = b_ngay_ad;

        //GridX_datBang(b_grctId, b_kq), GridX_datA(b_grctId, 1);

        //if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        //GridX_datBang(b_grctId, a_kq[1]);
        //GridX_datBang(b_grctId, a_kq[1]);
        var a_kq = b_kq.split('#');
        //form_P_MOI(b_vungId, "GXL"); $get(b_namId).value = "", $get(b_ky_dgId).value = "";
        //drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
// Liệt kê
function dg_dm_tcdg_cd_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_dm_tcdg_cd_lkeCho != 0) clearTimeout(dg_dm_tcdg_cd_lkeCho);
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        dg_dm_tcdg_cd_P_LKE('K');
    }
}
function dg_dm_tcdg_cd_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_TCDG_CD_LKE(form_Fs_nsd(), a_tso, a_cot, dg_dm_tcdg_cd_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_tcdg_cd_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function dg_dm_tcdg_cd_P_NAM() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        sdg.Fdt_NS_DG_MA_KDG_DG_NHL(window.name, b_nam, 'DT_KY_DG', dg_dm_tcdg_cd_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dg_dm_tcdg_cd_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    }
    //ns_dg_cntdg_P_KTRA('tinhtrang');
}
// lấy chức danh theo nhóm chức danh
function ns_cdanh_P_LIST() {
    try {
        var b_nhom_cdanh = C_NVL(lke_Fs_TRA($get(b_cdanhId)));
        a_tso = slide_Faobj_TUDEN(b_slideId);
        if (b_nhom_cdanh != '') {
            sns_ma_ch.Fs_NS_MA_CDANH_DRLKE(b_nhom_cdanh, window.name, "DT_CD", dg_dm_tcdg_cd_P_NCDANH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function dg_dm_tcdg_cd_P_NCDANH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
}
function dg_dm_tcdg_cd_P_NHOM_CDANH(b_tenctr, b_kieu) {
    try {
        b_nhom_cdanhId = form_Fs_TEN_ID('', b_tenctr)
        var b_nam = lke_Fs_TRA($get(b_namId)), b_ky_dg = lke_Fs_TRA($get(b_ky_dgId)), b_nhom_cdanh = lke_Fs_TRA($get(b_nhom_cdanhId));
        var b_ktra = "DT_CD";
        //if (b_tenctr == "N_CHUCDANH_TK") b_ktra = "DT_CHUCDANH_TK";
        if (b_nhom_cdanh != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_CDANH(form_Fs_nsd(), b_nhom_cdanh, a_tso, window.name, b_ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
        //var b_cdanh = lke_Fs_TRA($get(b_matk));
        $get(b_ncdanhId).value = b_nhom_cdanh;
        //$get(b_cdanhId).value = b_cdanh;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// lấy cấp bậc 
function ns_capbac_P_LIST() {
    try {
        var b_ma_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'CDANH'));
        if (b_ma_cdanh != "") {
            sdg.Fs_CAPBAC(form_Fs_nsd(), b_ma_cdanh, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function tieuchi_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var ktra = " ";
        var b_nhom_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC'));
        if (b_nhom_tc != "") {
            var a_tso = lke_Fa_TSO(b_kieu);
            sdg.Fs_TIEUCHI(form_Fs_nsd(), b_nhom_tc, a_tso[3], window.name, ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}

// lấy nội dung theo tiêu chi
function setMota(b_kq) {
    try {
        var b_tieuchi = C_NVL(GridX_Fas_layGtriA(b_grctId, 'mota'));
        var b_nhom_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC'));
        if (b_tieuchi != "") {
            sdg.Fs_MOTA(form_Fs_nsd(), b_tieuchi, b_nhom_tc, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return b_kq;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function thaydoiRow() {
    try {
        var b_tieuchi = C_NVL(GridX_Fas_layGtriA(b_grctId, 'TIEUCHI'));
        var b_nhom_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'NHOM_TC'));
        if (b_tieuchi != "" && b_nhom_tc != "") {
            sdg.Fs_MOTA(form_Fs_nsd(), b_tieuchi, b_nhom_tc, thaydoiRow_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (ex) { form_P_LOI(ex.message); }
}
function checknumber(b_dk) {
    var b_hang = GridX_Fi_timHangA(b_grctId);
    if (b_dk == 'NTC') {
        var b_ntc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'TRONGSO_NTC'));
        if (CSO_SO(b_ntc, 0) > 100) {
            GridX_datGtri(b_grctId, b_hang, "TRONGSO_NTC", 0);
        }
    }
    if (b_dk == 'TC') {
        var b_tc = C_NVL(GridX_Fas_layGtriA(b_grctId, 'TRONGSO_TC'));
        if (CSO_SO(b_tc, 0) > 100) {
            GridX_datGtri(b_grctId, b_hang, "TRONGSO_TC", 0);
        }
    }
}
function thaydoiRow_KQ(b_kq) {
    GridX_datGtriA(b_grctId, 'mota', b_kq);

}
function form_dong() {
    location.reload(false);
}