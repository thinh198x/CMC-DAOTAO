var ns_dsach_thieu_plenh_lkeCho, b_vungId, b_vungtkId, b_grlkeId, b_slideId, b_slideIdct, b_gocId, b_lngId, ns_dsach_thieu_plenh_choAct, b_ma_ndId, b_ten_ndId,
    b_namId, b_ky_luong_id, b_grctId, b_ma_nsd, b_namtkId, b_kyluong_tkId, b_aky_dgId, b_phongtkId,
    b_choAct = 0, b_fcho = 'C', b_loai_dgId;
function ns_dsach_thieu_plenh_P_KD(b_nsd) {
    b_ma_nsd = b_nsd;
    ns_dsach_thieu_plenh_lkeCho, ns_dsach_thieu_plenh_choAct = 0,
        ns_dsach_thieu_plenh_lkeCho = setInterval('ns_dsach_thieu_plenh_P_LKE_CHO()', 200);
}
// Mới 
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") {
            if (a_tso.length == 0) return;
            if (a_tso[0] == 'FILE_HTOAN') {
                ns_dsach_thieu_plenh_P_LKE(); form_P_MOI(b_vungId, "GLX");
            }
        } else if (b_dtuong = "MA_NHOM") {
            ns_dsach_thieu_plenh_MA_KH(a_tso[0]);
        } else if (b_dtuong.indexOf("TAI_IMPORT") >= 0) {
            ns_dsach_thieu_plenh_P_LKE('K');
        }
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dsach_thieu_plenh_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "KY_DG": b_maId = b_ky_luong_id_Upa_tk; form_P_MOI("", "X"); break;
            case "PHONG_TK": b_maId = b_phongtkId; break;
        }
        var b_ma = $get(b_maId);
        if (b_ma == null || C_NVL(b_ma.value) == "") return;
        if ((b_maTen == "KY_DG") || (b_maTen == "PHONG_TK")) {
            $get(b_aky_dgId).value = lke_Fs_TRA($get(b_ky_luong_id_Upa_tk));
            ns_dsach_thieu_plenh_P_LKE();
        }

    }
    catch (err) { form_P_LOI(err); }
}
function ns_dsach_thieu_plenh_P_NAM(b_dk) {
    try {
        if (b_dk == "TK") {
            var b_nam = form_Fs_TEN_GTRI(b_vungtkId, 'NAM_TK');
            if (b_nam != "")
                hts_dungchung.Fs_NS_KYLUONG_LKE_BYNAM(form_Fs_nsd(), window.name, "DT_KY_LUONG_TK", b_nam);
        } else {
            var b_nam = form_Fs_TEN_GTRI(b_vungId, 'NAM');
            if (b_nam != "")
                hts_dungchung.Fs_NS_KYLUONG_LKE_BYNAM(form_Fs_nsd(), window.name, "DT_KY", b_nam);
        }
    }
    catch (ex) { form_P_LOI(ex.message); }
}
// Chuyển hàng
function ns_dsach_thieu_plenh_GR_lke_RowChange() {
    if (ns_dsach_thieu_plenh_choAct != 0) clearTimeout(ns_dsach_thieu_plenh_choAct);
    ns_dsach_thieu_plenh_choAct = setTimeout("ns_dsach_thieu_plenh_P_CHUYEN_HANG()", 300);
    return false;
}
function ns_dsach_thieu_plenh_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam")), a_cot = GridX_Fas_tenCot(b_grctId);
        var b_ky_luong = GridX_Fas_layGtri(b_grlkeId, b_hang, "ky_luong_id");
        if (b_nam == "") {
            form_P_MOI(b_vungId, "XGL");
            form_P_MOI(b_grctId, "XGL");
        }
        else stl_ch.Fs_NS_DSACH_THIEU_PLENH_CT(b_nam, b_ky_luong, a_cot, ns_dsach_thieu_plenh_P_CHUYEN_HANG_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dsach_thieu_plenh_P_CHUYEN_HANG_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        var b_nam = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "nam"));
        var b_ky_luong = GridX_Fas_layGtri(b_grlkeId, b_hang, "ky_luong_id"); var b_ten_ky_luong = GridX_Fas_layGtri(b_grlkeId, b_hang, "ten_ky_luong_id");
        $get(b_namId).value = b_nam;
        lke_P_DAT($get(b_ky_luong_id), b_ky_luong + '{' + b_ten_ky_luong);
        var a_kq = b_kq.split('#');
        if (a_kq[1] == "") GridX_datTrang(b_grctId); else { slide_P_SOTRANG(b_slideIdct, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grctId, a_kq[1]); }
    }
}
// Liệt kê
function ns_dsach_thieu_plenh_P_LKE_CHO() {
    if (document.readyState === 'complete') {
        if (ns_dsach_thieu_plenh_lkeCho != 0) clearTimeout(ns_dsach_thieu_plenh_lkeCho);
        b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_vungtkId = form_Fs_VUNG_ID('Upa_tk'),
            b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
            b_grctId = form_Fs_VUNG_ID('GR_ct'),
            b_namId = form_Fs_TEN_ID(b_vungId, 'NAM'),
            b_ky_luong_id = form_Fs_TEN_ID(b_vungId, 'KY_LUONG_ID'),
            b_so_idId = form_Fs_VTEN_ID('UPa_hi', 'so_id');
        b_namtkId = form_Fs_TEN_ID(b_vungtkId, 'nam_tk');
        b_kyluong_tkId = form_Fs_TEN_ID(b_vungtkId, 'kyluong_tk');
        b_aky_dgId = form_Fs_VTEN_ID('UPa_hi', 'aky_dg');
        b_slideId = b_grlkeId + '_slide';
        b_slideId = $get(b_grlkeId).getAttribute('slideId');
        b_slideIdct = $get(b_grctId).getAttribute('slideId');
        lke_P_DAT($get(b_namtkId), 0 + '{' + 'Tất cả');
        ns_dsach_thieu_plenh_P_LKE('K');
    }
}
function ns_dsach_thieu_plenh_P_LKE(b_dk) {
    try {
        if (b_dk == 'C' || b_dk == 'M1') slide_P_MOI(b_slideId);
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        var b_nam_tk = lke_Fs_TRA($get(b_namtkId)), b_kyluong_tk = lke_Fs_TRA($get(b_kyluong_tkId))
        stl_ch.Fs_NS_DSACH_THIEU_PLENH_LKE(form_Fs_nsd(), b_nam_tk, b_kyluong_tk, a_tso, a_cot, ns_dsach_thieu_plenh_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        return false;
    }
    catch (err) { form_P_LOI(err); }
}
function ns_dsach_thieu_plenh_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
    }
    b_fcho = 'X';
}

function ns_dsach_thieu_plenh_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    form_P_MOI(b_grctId, "GXL");
    GridX_thoiA(b_grlkeId); GridX_datTrang(b_grctId);
    $get(b_so_idId).value = "";
    return false;
}

function ns_dsach_thieu_plenh_P_MAU() {
    var b_btn_excel = form_Fs_VTEN_ID('', 'btn_excel_mau');
    $get(b_btn_excel).click(); form_chay = 0;
    return false;

}

function ns_dsach_thieu_plenh_FILE_Import() {
    var b_nam = lke_Fs_TRA($get(b_namId)), b_kyluong_id = lke_Fs_TRA($get(b_ky_luong_id));
    if (b_nam == "" || b_kyluong_id == "") { form_P_LOI('loi:Chưa chọn năm hoặc kỳ lương !:loi'); return false; }

    var b_tenf = '/App_form/ns/ma/file_Import.aspx';
    form_P_MO(b_tenf, window.name + ',THAMSO', ['THAMSO', [window.name, 'GIO_LTHEM', null, "Import kết quả thi đua khen thưởng", b_nam, b_kyluong_id]], null);
    form_P_LOI('');
    return false;
}

function form_dong() {
    location.reload(false);
}