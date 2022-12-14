
var dgnl_dm_nl_lkeCho, b_vungId, b_grlkeId, b_slideId, b_gocId, b_timIdb_nhomId, b_nhomId, b_ngayd, b_ngayc;
function dgnl_dm_nl_P_KD() {
    dgnl_dm_nl_lkeCho, b_vungId = form_Fs_VUNG_ID('UPa_ct'), b_grlkeId = form_Fs_VUNG_ID('GR_lke'),
    b_gocId = form_Fs_TEN_ID(b_vungId, 'MA'), b_nhomId = form_Fs_TEN_ID(b_vungId, 'MA_NHOM'), b_ngayd = form_Fs_TEN_ID(b_vungId, 'NG_BDAU'), b_ngayc = form_Fs_TEN_ID(b_vungId, 'ng_kthuc');
    b_slideId = b_grlkeId + '_slide';
    dgnl_dm_nl_lkeCho = setInterval('dgnl_dm_nl_P_LKE_CHO()', 200);

}
var b_cho_control = 0;
function P_cho(b_ma_nhom, b_ten, b_phong) {
    try {
        if (b_doi == 0) {
            $get(b_nhomId).value = b_ma_nhom;
        }
    }
    catch (err) {
        b_doi = 0;
    }
}
function P_KET_QUA(b_dtuong, a_tso) {
    try {
        if (b_dtuong == null || b_dtuong == "") return;
        b_dtuong = b_dtuong.toUpperCase();
        var b_kq = a_tso[0];
        b_doi = 0;
        if (b_dtuong.indexOf("MA_NHOM") >= 0) {
            $get(b_nhomId).value = b_kq;
            dgnl_dm_nl_P_LKE();
        }
        else if (b_dtuong.indexOf("THAMSO") >= 0) {
            $get(b_nhomId).value = b_kq;
            dgnl_dm_nl_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_nl_P_KTRA(b_maTen) {
    try {
        var b_maId = "";
        b_maTen = b_maTen.toUpperCase();
        switch (b_maTen) {
            case "MA": b_maId = b_gocId; break;
            case "MA_NHOM": b_maId = b_ncdId; break;
        }
        var b_ma = $get(b_maId);
        if (C_NVL(b_ma.value) == "") return;
        if (b_maTen == "MA") {
            var b_ten = form_Fctr_TEN_DTUONG(b_vungId, 'TEN');
            b_hang = GridX_Fi_timHangD(b_grlkeId, "ma", b_ma.value);
            if (b_hang < 1) { GridX_thoiA(b_grlkeId); dgnl_dm_nl_P_MA_KTRA(); }
            else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_nl_P_CHUYEN_HANG(); }
            b_ten.focus();
        }
        if (b_maTen == "MA_NHOM") {
            skhac.Fs_MA_LOI(form_Fs_nsd(), b_ma.getAttribute("ten"), b_ma.value, b_ma.getAttribute("ktra"), ns_ma_cdanh_P_DatGchu, P_LOI_CSDL, P_LOI_TGIAN);
            dgnl_dm_nl_P_LKE();
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_nl_P_MA_KTRA() {
    try {
        var b_ma = C_NVL($get(b_gocId).value);
        var b_nhom = C_NVL($get(b_nhomId).value);
        if (b_ma != "" && b_nhom != "") {
            var b_TrangKt = GridX_Fi_hangKt(b_grlkeId), a_cot = GridX_Fas_tenCot(b_grlkeId);
            sdg.Fs_DGNL_DM_NL_MA(b_nhom, b_ma, b_TrangKt, a_cot, dgnl_dm_nl_P_MA_KTRA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
        }
    }
    catch (err) { form_P_LOI(err); }
}
function dgnl_dm_nl_P_MA_KTRA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
    GridX_datBang(b_grlkeId, a_kq[3]);
    slide_P_MOI(b_slideId, b_trang, b_soDong);
    if (b_hang < 1) form_P_MOI(b_vungId, "X");
    else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_nl_P_CHUYEN_HANG(); }
}

var dgnl_dm_nl_choAct = 0;
function dgnl_dm_nl_GR_lke_RowChange() {
    if (dgnl_dm_nl_choAct != 0) clearTimeout(dgnl_dm_nl_choAct);
    dgnl_dm_nl_choAct = setTimeout("dgnl_dm_nl_P_CHUYEN_HANG()", 300);
    return false;
}

function dgnl_dm_nl_P_LKE_CHO() {
    if ($get(b_grlkeId) != null) { clearTimeout(dgnl_dm_nl_lkeCho); dgnl_dm_nl_P_LKE(); }
}

function dgnl_dm_nl_P_NH() {
    var ktra = ktra_ngay(parseDate($get(b_ngayd).value).getTime(), parseDate($get(b_ngayc).value).getTime(), 1, "Ngày bắt đầu", "ngày kết thúc");
    if (ktra.length > 0) {
        dgnl_dm_nl_P_NH_KQ(ktra);
        return false;
    }
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_loi != "") { form_P_LOI(b_loi); return false; }
    var a_dt_ct = form_Faa_TEXT_ROW(b_vungId), a_cot = GridX_Fas_tenCot(b_grlkeId), b_TrangKt = GridX_Fi_hangKt(b_grlkeId);
    sdg.Fs_DGNL_DM_NL_NH(b_TrangKt, a_dt_ct, a_cot, dgnl_dm_nl_P_NH_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    return false;
}
function dgnl_dm_nl_P_NH_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#');
        var b_hang = CSO_SO(a_kq[0]) + 1, b_trang = CSO_SO(a_kq[1]), b_soDong = CSO_SO(a_kq[2]);
        slide_P_MOI(b_slideId, b_trang, b_soDong);
        GridX_datBang(b_grlkeId, a_kq[3]);
        if (b_hang >= 0) GridX_datA(b_grlkeId, b_hang);
        $get(b_gocId).focus();
    }
    return false;
}
function dgnl_dm_nl_P_MOI() {
    form_P_MOI(b_vungId, "GXL");
    $get(b_gocId).focus();
    return false;
}

function ktra_ngay(tungay, denngay, loai, ten1, ten2) {
    if (denngay == "" || denngay == null) {
        return "";
    }
    if (loai == 1 && tungay > denngay) {
        return "loi: " + ten1 + " không được lớn hơn " + ten2 + " :loi";
    } else if (loai == 2 && tungay >= denngay) {
        return "loi: " + ten1 + " không được lớn hơn hoặc bằng " + ten2 + " :loi";
    }
    return "";
}

function parseDate(str) {
    var mdy = str.split('/');
    return new Date(mdy[2], mdy[1], mdy[0]);
}

function dgnl_dm_nl_P_XOA() {
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    var b_loi = form_Fs_TEXT_KTRA(b_vungId);
    if (b_hang < 1 || b_loi.length > 0) { form_P_LOI("Bạn phải chọn một bản ghi để xóa"); return false; }
    var message = confirm("Bạn có chắc chắn xóa không?");
    if (message == false) { return false; }
    var b_hang = GridX_Fi_timHangA(b_grlkeId);
    if (b_hang < 1) return;
    var b_ma = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma");
    var b_ma_nhom = GridX_Fas_layGtri(b_grlkeId, b_hang, "ma_nhom");
    if (b_ma == "") dgnl_dm_nl_P_MOI();
    else {
        var a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_NL_XOA(b_ma_nhom, b_ma, a_tso, a_cot, dgnl_dm_nl_P_XOA_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    return false;
}
function dgnl_dm_nl_P_XOA_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) form_P_LOI(b_kq);
    else {
        var a_kq = Fas_ChMang(b_kq, '#'), b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang > 1) b_hang--;
        else b_hang = GridX_Fi_hangSo(b_grlkeId);
        slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0)); GridX_datBang(b_grlkeId, a_kq[1]);
        if (GridX_Fb_hangTrang(b_grlkeId, b_hang)) dgnl_dm_nl_P_MOI();
        else { GridX_datA(b_grlkeId, b_hang); dgnl_dm_nl_P_CHUYEN_HANG(); }
    }
}

function dgnl_dm_nl_P_CHUYEN_HANG() {
    try {
        var b_hang = GridX_Fi_timHangA(b_grlkeId);
        if (b_hang < 1) return;
        var b_ma = C_NVL(GridX_Fas_layGtri(b_grlkeId, b_hang, "ma"));
        if (b_ma == "") form_P_MOI(b_vungId, "XGL"); else form_P_GridX_TEXT(b_vungId, b_grlkeId);
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_dm_nl_P_LKE() {
    try {
        var b_ma_nhom = $get(b_nhomId).value, a_cot = GridX_Fas_tenCot(b_grlkeId), a_tso = slide_Faobj_TUDEN(b_slideId);
        sdg.Fs_DGNL_DM_NL_LKE(b_ma_nhom, a_tso, a_cot, dgnl_dm_nl_P_LKE_KQ, P_LOI_CSDL, P_LOI_TGIAN);
    }
    catch (err) { form_P_LOI(err); }
}

function dgnl_dm_nl_P_LKE_KQ(b_kq) {
    if (Fb_LOI_KTRA(b_kq)) { form_P_LOI(b_kq); return; }
    var a_kq = Fas_ChMang(b_kq, '#');
    slide_P_SOTRANG(b_slideId, CSO_SO(a_kq[0], 0));
    GridX_datBang(b_grlkeId, a_kq[1]);
}
function form_dong() {
    location.reload(false);
}