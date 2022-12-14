var dg_dm_dtdg_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_gocId, b_donviId, b_slidectId,
    b_donvi_tkId, b_nam_tkId, b_lngId, dg_dm_dtdg_choAct, b_nhom_cdanhId, b_cdanhId, b_capbacId
b_choAct = 0, b_fcho = 'C';
function dg_dm_dtdg_P_KD() { 
    dg_dm_dtdg_lkeCho = setInterval('dg_dm_dtdg_P_LKE_CHO()', 200);
} 
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        b_dtuong = b_dtuong.toUpperCase();
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                dg_dm_dtdg_P_LKE('K');
            }
        } else if (b_dtuong.indexOf("MA_CD") >= 0) {
            dg_dm_dtdg_P_LAY();
        }
    }
    catch (err) { form_P_LOI(err); }
}
// Kiểm tra
function dg_dm_dtdg_P_KTRA(b_maTen) {
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
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dg_dm_dtdg_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dg_dm_dtdg_P_CHUYEN_HANG(); }
        }
    }
    catch (err) { form_P_LOI(err); }
} 
// Nhập
function dg_dm_dtdg_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_ky_dgId).value = ""
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "0"; $get(b_so_idId).focus();
    $get(b_namId).value = "";
    return false;
}
function dg_dm_dtdg_P_NH() {
    try {
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        if (b_nam == "") { form_P_LOI("loi:Phải chọn Năm:loi"); return false; }
        var b_ky_dg = form_Fs_TEN_GTRI(b_vungId, 'ky_dg');
        if (b_ky_dg == "") { form_P_LOI("loi:Phải chọn Kỳ đánh giá:loi"); return false; }
        var b_ngay_dg = form_Fs_TEN_GTRI(b_vungId, 'ngay_ad');
        if (b_ngay_dg == "") { form_P_LOI("loi:Phải chọn Ngày đánh giá:loi"); return false; }
        var b_loi = form_Fs_TEXT_KTRA(b_vungId); var b_so_id = 0;
        if (b_loi != "") form_P_LOI(b_loi);
        else {
            var a_dt = form_Faa_TEXT_ROW(b_vungId), a_cot_ct = GridX_Fdt_cotGtri(b_grctId), a_tso = slide_Faobj_TUDEN(b_slideId);;
            var a_cot_lke = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
            var b_hang = GridX_Fi_timHangA(b_grlkeId);
            if (b_hang > 0) b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
            sdg.Fs_DG_DM_DTDG_NH(form_Fs_nsd(), b_so_id, b_TrangKt, a_dt, a_cot_ct, a_tso, a_cot_lke, dg_dm_dtdg_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
        return false;
    }
    catch (err) { throw (err); }
}
function dg_dm_dtdg_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else { 
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
function dg_dm_dtdg_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("loi:Bạn phải chọn một bản ghi để xóa :loi"); return false; } 
    var b_so_id = GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id");
    if (b_so_id == "") dg_dm_dtdg_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_DTDG_XOA(form_Fs_nsd(), b_so_id, a_tso, a_cot, dg_dm_dtdg_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dg_dm_dtdg_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dg_dm_dtdg_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dg_dm_dtdg_P_CHUYEN_HANG(); }
        form_P_LOI("loi:Xóa thành công:loi");
    }
}
// Chuyển hàng
function dg_dm_dtdg_GR_lke_RowChange() {
    if (dg_dm_dtdg_choAct != 0) clearTimeout(dg_dm_dtdg_choAct);
    dg_dm_dtdg_choAct = setTimeout("dg_dm_dtdg_P_CHUYEN_HANG()", 300);
    return false;
}
function dg_dm_dtdg_P_CHUYEN_HANG() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_so_id = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"));
    if (b_so_id == "0" || b_so_id == "") { form_P_MOI(b_vungId, "XGL"); GridX_datTrang(b_grctId); }
    else {
        var a_cot_ct = GridX_Fas_tenCot(b_grctId);
        sdg.Fs_DG_DM_DTDG_CT(form_Fs_nsd(), b_so_id, a_cot_ct, dg_dm_dtdg_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        $get(b_so_idId).value = b_so_id;
    }
    return false;
}
function dg_dm_dtdg_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {   
        if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
        var a_kq = b_kq.split('#');
        form_P_MOI(b_vungId, "GXL"); $get(b_namId).value = "", $get(b_ky_dgId).value = "";
        drop_P_LKE(b_ky_dgId, a_kq[2]);
        form_P_CH_TEXT(b_vungId, a_kq[0]);
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else GridX_datBang(b_grctId, a_kq[1]);
        return false;
    }
}
// Liệt kê
function dg_dm_dtdg_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (dg_dm_dtdg_lkeCho != 0) clearTimeout(dg_dm_dtdg_lkeCho);
        dg_dm_dtdg_lkeCho, dg_dm_dtdg_choAct = 0, b_vungId = form_Fs_VUNG_ID('UPa_ct'),
        b_vungtkId = form_Fs_VUNG_ID('Upa_tk'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
        b_grctId = form_Fs_VUNG_ID('GR_ct'),
        b_ky_dgId = form_Fs_TEN_ID(b_vungId, 'ky_dg'),
        b_namId = form_Fs_TEN_ID(b_vungId, 'nam'),
        b_ngay_adId = form_Fs_TEN_ID(b_vungId, 'ngay_ad'),
        b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_slideId = $get(b_grlkeId).getAttribute('slideId'); b_slidectId = $get(b_grctId).getAttribute('slideId');
        dg_dm_dtdg_P_LKE('K'); slide_P_MOI(b_slidectId);
    } 
}
function dg_dm_dtdg_P_LKE(b_dk) {
    try {
        if (b_dk == 'C') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DG_DM_DTDG_LKE(form_Fs_nsd(), a_tso, a_cot, dg_dm_dtdg_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_dtdg_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function dg_dm_dtdg_P_NAM() {
    try {
        var ktra = "DT_KY_DG";
        var b_nam = form_Fs_TEN_GTRI(b_vungId, 'nam');
        sdg.Fdt_NS_DG_MA_KDG_NHL(window.name ,b_nam,ktra, dg_dm_dtdg_P_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_dtdg_P_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var b_kdgId = form_Fs_TEN_ID(b_vungId, 'ky_dg');
        drop_P_LKE(b_kdgId, b_kq);
    } 
}
// lấy chức danh theo nhóm chức danh
function ns_cdanh_P_LIST(b_ctrId, b_kieu, b_vtri) {
    try {
        var ktra = " ";
        var b_nhom_cdanh = C_NVL(GridX_Fas_layGtriA(b_grctId, 'nhom_cdanh'));
        if (b_nhom_cdanh != '') {
            var a_tso = lke_Fa_TSO(b_kieu);
            //sdg.Fs_CDANH(form_Fs_nsd(), b_nhom_cdanh, a_tso[3], window.name, ktra, form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            sdg.Fs_CDANH(form_Fs_nsd(), b_nhom_cdanh, a_tso[3], form_LIST_KQ, P_LOI_CSDL, P_LOI_TGIAN);
            return false;
        }
    }
    catch (err) { form_P_LOI(err); }
}

function dg_dm_dtdg_P_LAY() {
    try {
        var a_cot = GridX_Fas_tenCot(b_grctId), b_ma = form_Fs_TEN_GTRI(b_vungId, 'PHONG');
        var b_so_id = 0, a_luoi;
        slide_P_SOTRANG(b_slidectId);
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) b_so_id = 0;
        else
            b_so_id = CSO_SO(GridX_Fas_layGtri(b_grlkeId, b_hang, "so_id"), 0),
                GridX_datA(b_grlkeId, 1); a_luoi = GridX_Fdt_cotGtri(b_grctId); GridX_datA(b_grctId, b_hang);
        sns_hdns.Fs_NS_DG_GAN_CDANHDVI_LAY(form_Fs_nsd(), a_cot, b_so_id, a_luoi, dg_dm_dtdg_P_LAY_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function dg_dm_dtdg_P_LAY_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    GridX_datBang(b_grctId, a_kq[1]);
    slide_P_SOTRANG(b_slidectId);
}
function form_dong() {
    location.reload(false);
}